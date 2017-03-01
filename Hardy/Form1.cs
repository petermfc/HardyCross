using ExportToExcel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Hardy
{
    public partial class Form1 : Form
    {
        private SmoothingMode smoothingMode = SmoothingMode.AntiAlias;
        private UndoRedoHelper<Graph<Node>> undoRedo = new UndoRedoHelper<Graph<Node>>();
        private Button currentButtonTool = new Button();
        private PipeModel pipeModel = new PipeModel();
        
        private Tool currentTool = new Tool();
        public Tool CurrentTool
        {
            get { return this.currentTool; }
        }
        private SaveData saveData = new SaveData();
        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered",
               BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
               null, panelDesign, new object[] { true });
        }

        private void SetEnabledDisabledButtons(object sender)
        {
            panelDesign.Cursor = CurrentTool.Cursor;
            (sender as Button).Enabled = false;
            currentButtonTool.Enabled = true;
            currentButtonTool = sender as Button;
        }

        private void panelDesign_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = smoothingMode;
            pipeModel.Draw(e.Graphics);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            panelDesign.MouseMove += panelDesign_MouseMove;
            CurrentTool.Type = Tools.Select;
            SetEnabledDisabledButtons(sender);
        }

        private void btnNode_Click(object sender, EventArgs e)
        {
            panelDesign.MouseMove -= panelDesign_MouseMove;
            CurrentTool.Type = Tools.AddNode;
            panelDesign.Cursor = CurrentTool.Cursor;
            SetEnabledDisabledButtons(sender);
        }

        private void btnRemoveNode_Click(object sender, EventArgs e)
        {
            panelDesign.MouseMove += panelDesign_MouseMove;
            CurrentTool.Type = Tools.DeleteNode;
            panelDesign.Cursor = CurrentTool.Cursor;
            SetEnabledDisabledButtons(sender);
        }

        private void btnAddPipe_Click(object sender, EventArgs e)
        {
            panelDesign.MouseMove += panelDesign_MouseMove;
            CurrentTool.Type = Tools.AddPipe;
            panelDesign.Cursor = CurrentTool.Cursor;
            SetEnabledDisabledButtons(sender);
        }

        private void btnRemovePipe_Click(object sender, EventArgs e)
        {
            panelDesign.MouseMove -= panelDesign_MouseMove;
            CurrentTool.Type = Tools.DeletePipe;
            panelDesign.Cursor = CurrentTool.Cursor;
            SetEnabledDisabledButtons(sender);
        }

        private void panelDesign_MouseClick(object sender, MouseEventArgs e)
        {
            Graph<Node> net = pipeModel.Network.Clone();
            if (CurrentTool.Process(e, pipeModel))
            {
                panelDesign.Invalidate();
                panelDesign.Update();
                saveData.IsModified = true;
                undoRedo.PushUndo(net);
                redoToolStripMenuItem.Enabled = false;
            }
        }

        private void panelDesign_MouseMove(object sender, MouseEventArgs e)
        {
            Tuple<System.Drawing.Rectangle, System.Drawing.Rectangle> rt = pipeModel.TryLockTarget(e);
            /*if (rt.Item1 != Rectangle.Empty)
            {*/
                panelDesign.Invalidate(/*rt.Item1*/);
                panelDesign.Update();
            /*}
            /*if (rt.Item2 != Rectangle.Empty)
            {
                panelDesign.Invalidate(rt.Item2);
                panelDesign.Update();
            }*/
        }

        private void panelDesign_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Graph<Node> net = pipeModel.Network.Clone();
            if (CurrentTool.ShowProperties(e, pipeModel))
            {
                saveData.IsModified = true;
                panelDesign.Invalidate();
                panelDesign.Update();
                undoRedo.PushUndo(net);
                redoToolStripMenuItem.Enabled = false;
            }
        }

        private void panelDesign_MouseDown(object sender, MouseEventArgs e)
        {
            //CurrentTool.Drag(e, pipeModel);
            panelDesign.Invalidate();
            panelDesign.Update();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            pipeModel.DoShit();
        }

        private void checkAntiAlias_CheckedChanged(object sender, EventArgs e)
        {
            smoothingMode = (sender as CheckBox).Checked ? SmoothingMode.AntiAlias : SmoothingMode.None;
            panelDesign.Invalidate();
            panelDesign.Update();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            resultControl.Calculate(pipeModel.Network);
            tabControl.SelectedTab = tabPageCalc;
            
        }

        /// <summary>
        /// Writes the given object instance to a Json file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// <para>Only Public properties and variables will be written to the file. These can be any type though, even other classes.</para>
        /// <para>If there are public properties/variables that you do not want written to the file, decorate them with the [JsonIgnore] attribute.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        /// <summary>
        /// Reads an object instance from an Json file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object to read from the file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the Json file.</returns>
        public static T ReadFromJsonFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(fileContents);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveData.IsModified)
            {
                if(MessageBox.Show("Would you like to save your changes?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    saveAsToolStripMenuItem_Click(this, new EventArgs());
                }
            }
            Application.Exit();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "network.hrd";
            sfd.Filter = "Network files (*.hrd)|*.hrd|All files (*.*)|*.*";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                WriteToJsonFile<Graph<Node>>(sfd.FileName, pipeModel.Network);
                MessageBox.Show("Saved!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                saveData.IsNew = false;
                saveData.IsModified = false;
                saveData.FileName = sfd.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveData.IsNew)
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                WriteToJsonFile<Graph<Node>>(saveData.FileName, pipeModel.Network);
                MessageBox.Show("Saved!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                saveData.IsModified = false;
                saveData.IsNew = false;
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Network files (*.hrd)|*.hrd|All files (*.*)|*.*";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                Graph<Node>  net = (Graph<Node>)ReadFromJsonFile<Graph<Node>>(ofd.FileName);
                saveData.IsNew = false;
                saveData.FileName = ofd.FileName;
                pipeModel.Network = net;
                Invalidate();
                Update();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveData.IsModified && MessageBox.Show("Would you like to save your changes?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                saveToolStripMenuItem_Click(this, new EventArgs());
            }

            pipeModel.Network = new Graph<Node>();
            saveData.IsNew = true;
            saveData.IsModified = true;
            Invalidate();
            Update();

        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "cross-hardy.xlsx";
            sfd.Filter = "Excel spreadsheet (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CreateExcelFile.CreateExcelDocument(resultControl.Table, sfd.FileName);
                    MessageBox.Show("Saved!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Exporting to Excel file failed: \r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPdfExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "cross-hardy.pdf";
            sfd.Filter = "PDF document (*.pdf)|*.pdf|All files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportToPdf(resultControl.Table, sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exporting to PDF file failed: \r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void ExportToPdf(DataTable dt, string fileName)
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
            document.Open();
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);

            PdfPTable table = new PdfPTable(dt.Columns.Count);
            PdfPRow row = null;
            float[] widths = new float[] { 4f, 4f, 4f, 4f };

            table.SetWidths(widths);

            table.WidthPercentage = 100;
            int iCol = 0;
            string colname = "";
            PdfPCell cell = new PdfPCell(new Phrase("Products"));

            cell.Colspan = dt.Columns.Count;

            foreach (DataColumn c in dt.Columns)
            {

                table.AddCell(new Phrase(c.ColumnName, font5));
            }

            foreach (DataRow r in dt.Rows)
            {
                if (dt.Rows.Count > 0)
                {
                    table.AddCell(new Phrase(r[0].ToString(), font5));
                    table.AddCell(new Phrase(r[1].ToString(), font5));
                    table.AddCell(new Phrase(r[2].ToString(), font5));
                    table.AddCell(new Phrase(r[3].ToString(), font5));
                }
            }
            document.Add(table);
            document.Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (undoRedo.AreUndoItems)
            {
                var net = pipeModel.Network.Clone();
                undoRedo.PushRedo(net);
                pipeModel.Network = undoRedo.PopUndo();
                panelDesign.Invalidate();
                panelDesign.Update();
            }
            undoToolStripMenuItem.Enabled = undoRedo.AreUndoItems;
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (undoRedo.AreRedoItems && undoRedo.CanRedo)
            {
                var net = pipeModel.Network.Clone();
                undoRedo.PushUndo(net);
                pipeModel.Network = undoRedo.PopRedo();
                panelDesign.Invalidate();
                panelDesign.Update();
            }
            redoToolStripMenuItem.Enabled = undoRedo.AreRedoItems && undoRedo.CanRedo;
        }
    }

    public class Tool
    {
        private Tools type;
        public Tools Type
        {
            get
            {
                return this.Type;
            }
            set
            {
                this.type = value;
                switch(value)
                {
                    case Tools.None: 
                    case Tools.Select: this.Cursor = Cursors.Default; break;
                    case Tools.AddNode: this.Cursor = Cursors.Cross; break;
                    case Tools.DeleteNode: this.Cursor = Cursors.Cross; break;
                    case Tools.AddPipe: this.Cursor = Cursors.Cross; break;
                    case Tools.DeletePipe: this.Cursor = Cursors.Cross; break;
                }
            }
        }
        public Cursor Cursor { get; set; }
        public bool Process(MouseEventArgs args, PipeModel model)
        {
            bool bRet = false;
            switch (this.type)
            {
                case Tools.None: this.Cursor = Cursors.Default; break;
                case Tools.AddNode: bRet = model.AddNode(args); break;
                case Tools.DeleteNode: bRet = model.DeleteNode(args); break;
                case Tools.Select:
                    break;
                case Tools.AddPipe: bRet = model.AddPipe(args); break;
                case Tools.DeletePipe: bRet = model.DeletePipe(args); break;
            }
            return bRet;
        }
        public bool ShowProperties(MouseEventArgs args, PipeModel model)
        {
            bool ret = false;
            switch (this.type)
            {
                //case Tools.None: this.Cursor = Cursors.Default; break;
                //case Tools.AddNode: model.AddNode(args); break;
                //case Tools.DeleteNode: model.DeleteNode(args); break;
                case Tools.Select: ret = model.ShowProps(args);
                    break;
                //case Tools.AddPipe: model.AddPipe(args); break;
                //case Tools.DeletePipe: model.DeletePipe(args); break;
            }
            return ret;
        }
    }

    public enum Tools { None = 0, Select = 1, AddNode, DeleteNode, AddPipe, DeletePipe}
    
}
