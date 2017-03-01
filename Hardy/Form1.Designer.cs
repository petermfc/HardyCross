namespace Hardy
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNode = new System.Windows.Forms.Button();
            this.btnAddPipe = new System.Windows.Forms.Button();
            this.btnRemovePipe = new System.Windows.Forms.Button();
            this.btnRemoveNode = new System.Windows.Forms.Button();
            this.panelDesign = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageDesign = new System.Windows.Forms.TabPage();
            this.panelToolbox = new System.Windows.Forms.Panel();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.checkAntiAlias = new System.Windows.Forms.CheckBox();
            this.btnCount = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.tabPageCalc = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPdfExport = new System.Windows.Forms.Button();
            this.btnExcelExport = new System.Windows.Forms.Button();
            this.resultControl = new Hardy.ResultControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.tabPageDesign.SuspendLayout();
            this.panelToolbox.SuspendLayout();
            this.tabPageCalc.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNode
            // 
            this.btnNode.Location = new System.Drawing.Point(0, 32);
            this.btnNode.Name = "btnNode";
            this.btnNode.Size = new System.Drawing.Size(90, 23);
            this.btnNode.TabIndex = 0;
            this.btnNode.Text = "Add Node";
            this.btnNode.UseVisualStyleBackColor = true;
            this.btnNode.Click += new System.EventHandler(this.btnNode_Click);
            // 
            // btnAddPipe
            // 
            this.btnAddPipe.Location = new System.Drawing.Point(0, 87);
            this.btnAddPipe.Name = "btnAddPipe";
            this.btnAddPipe.Size = new System.Drawing.Size(90, 23);
            this.btnAddPipe.TabIndex = 1;
            this.btnAddPipe.Text = "Add Pipe";
            this.btnAddPipe.UseVisualStyleBackColor = true;
            this.btnAddPipe.Click += new System.EventHandler(this.btnAddPipe_Click);
            // 
            // btnRemovePipe
            // 
            this.btnRemovePipe.Location = new System.Drawing.Point(0, 116);
            this.btnRemovePipe.Name = "btnRemovePipe";
            this.btnRemovePipe.Size = new System.Drawing.Size(90, 23);
            this.btnRemovePipe.TabIndex = 2;
            this.btnRemovePipe.Text = "Remove Pipe";
            this.btnRemovePipe.UseVisualStyleBackColor = true;
            this.btnRemovePipe.Click += new System.EventHandler(this.btnRemovePipe_Click);
            // 
            // btnRemoveNode
            // 
            this.btnRemoveNode.Location = new System.Drawing.Point(0, 58);
            this.btnRemoveNode.Name = "btnRemoveNode";
            this.btnRemoveNode.Size = new System.Drawing.Size(90, 23);
            this.btnRemoveNode.TabIndex = 3;
            this.btnRemoveNode.Text = "Remove Node";
            this.btnRemoveNode.UseVisualStyleBackColor = true;
            this.btnRemoveNode.Click += new System.EventHandler(this.btnRemoveNode_Click);
            // 
            // panelDesign
            // 
            this.panelDesign.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelDesign.BackColor = System.Drawing.Color.White;
            this.panelDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesign.Location = new System.Drawing.Point(3, 3);
            this.panelDesign.Name = "panelDesign";
            this.panelDesign.Size = new System.Drawing.Size(983, 377);
            this.panelDesign.TabIndex = 4;
            this.panelDesign.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesign_Paint);
            this.panelDesign.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelDesign_MouseClick);
            this.panelDesign.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelDesign_MouseDoubleClick);
            this.panelDesign.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelDesign_MouseMove);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageDesign);
            this.tabControl.Controls.Add(this.tabPageCalc);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(997, 409);
            this.tabControl.TabIndex = 5;
            // 
            // tabPageDesign
            // 
            this.tabPageDesign.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageDesign.Controls.Add(this.panelToolbox);
            this.tabPageDesign.Controls.Add(this.panelDesign);
            this.tabPageDesign.Location = new System.Drawing.Point(4, 22);
            this.tabPageDesign.Name = "tabPageDesign";
            this.tabPageDesign.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDesign.Size = new System.Drawing.Size(989, 383);
            this.tabPageDesign.TabIndex = 0;
            this.tabPageDesign.Text = "Design";
            // 
            // panelToolbox
            // 
            this.panelToolbox.Controls.Add(this.btnCalculate);
            this.panelToolbox.Controls.Add(this.checkAntiAlias);
            this.panelToolbox.Controls.Add(this.btnCount);
            this.panelToolbox.Controls.Add(this.btnSelect);
            this.panelToolbox.Controls.Add(this.btnNode);
            this.panelToolbox.Controls.Add(this.btnRemoveNode);
            this.panelToolbox.Controls.Add(this.btnRemovePipe);
            this.panelToolbox.Controls.Add(this.btnAddPipe);
            this.panelToolbox.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelToolbox.Location = new System.Drawing.Point(3, 3);
            this.panelToolbox.Name = "panelToolbox";
            this.panelToolbox.Size = new System.Drawing.Size(94, 377);
            this.panelToolbox.TabIndex = 5;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(0, 238);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(94, 54);
            this.btnCalculate.TabIndex = 7;
            this.btnCalculate.Text = "Calculate!";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // checkAntiAlias
            // 
            this.checkAntiAlias.AutoSize = true;
            this.checkAntiAlias.Checked = true;
            this.checkAntiAlias.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAntiAlias.Location = new System.Drawing.Point(5, 355);
            this.checkAntiAlias.Name = "checkAntiAlias";
            this.checkAntiAlias.Size = new System.Drawing.Size(83, 17);
            this.checkAntiAlias.TabIndex = 6;
            this.checkAntiAlias.Text = "Anti Aliasing";
            this.checkAntiAlias.UseVisualStyleBackColor = true;
            this.checkAntiAlias.CheckedChanged += new System.EventHandler(this.checkAntiAlias_CheckedChanged);
            // 
            // btnCount
            // 
            this.btnCount.Enabled = false;
            this.btnCount.Location = new System.Drawing.Point(0, 169);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(90, 23);
            this.btnCount.TabIndex = 5;
            this.btnCount.Text = "Count!";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(0, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(90, 23);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // tabPageCalc
            // 
            this.tabPageCalc.Controls.Add(this.panel1);
            this.tabPageCalc.Controls.Add(this.resultControl);
            this.tabPageCalc.Location = new System.Drawing.Point(4, 22);
            this.tabPageCalc.Name = "tabPageCalc";
            this.tabPageCalc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCalc.Size = new System.Drawing.Size(989, 383);
            this.tabPageCalc.TabIndex = 1;
            this.tabPageCalc.Text = "Calculations";
            this.tabPageCalc.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPdfExport);
            this.panel1.Controls.Add(this.btnExcelExport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(983, 30);
            this.panel1.TabIndex = 1;
            // 
            // btnPdfExport
            // 
            this.btnPdfExport.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPdfExport.Enabled = false;
            this.btnPdfExport.Location = new System.Drawing.Point(716, 4);
            this.btnPdfExport.Name = "btnPdfExport";
            this.btnPdfExport.Size = new System.Drawing.Size(138, 23);
            this.btnPdfExport.TabIndex = 1;
            this.btnPdfExport.Text = "Export As PDF...";
            this.btnPdfExport.UseVisualStyleBackColor = true;
            this.btnPdfExport.Click += new System.EventHandler(this.btnPdfExport_Click);
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExcelExport.Location = new System.Drawing.Point(860, 4);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(118, 23);
            this.btnExcelExport.TabIndex = 0;
            this.btnExcelExport.Text = "Export as Excel file...";
            this.btnExcelExport.UseVisualStyleBackColor = true;
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // resultControl
            // 
            this.resultControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.resultControl.Location = new System.Drawing.Point(3, 35);
            this.resultControl.Name = "resultControl";
            this.resultControl.Size = new System.Drawing.Size(983, 345);
            this.resultControl.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(997, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 433);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Cross - Hardy v0.1";
            this.tabControl.ResumeLayout(false);
            this.tabPageDesign.ResumeLayout(false);
            this.panelToolbox.ResumeLayout(false);
            this.panelToolbox.PerformLayout();
            this.tabPageCalc.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNode;
        private System.Windows.Forms.Button btnAddPipe;
        private System.Windows.Forms.Button btnRemovePipe;
        private System.Windows.Forms.Button btnRemoveNode;
        private System.Windows.Forms.Panel panelDesign;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageDesign;
        private System.Windows.Forms.TabPage tabPageCalc;
        private System.Windows.Forms.Panel panelToolbox;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.CheckBox checkAntiAlias;
        private System.Windows.Forms.Button btnCalculate;
        private ResultControl resultControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExcelExport;
        private System.Windows.Forms.Button btnPdfExport;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
    }
}

