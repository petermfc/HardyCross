using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Hardy
{
    public partial class PropertiesDialog : Form
    {
        public decimal Length;
        public decimal PipeLoss;
        public decimal C;
        public decimal Diameter;
        public decimal Qs;
        public decimal Qe;
        public decimal NodeLoss;
        public NodeType Type;
        public bool IsStartElement;
        public bool Reversed;
        public int Sign;
        private List<NumericUpDown> numIns, numOuts;
        private List<NodeTypeRepositoryItem> typeItems;
        private BindingList<NodeTypeRepositoryItem> typeItemsBindingList = new BindingList<NodeTypeRepositoryItem>();

        public PropsMode Mode;

        public bool StartElementCheckboxLock
        {
            get; set;
        }

        public PropertiesDialog()
        {
            InitializeComponent();
            numOuts = new List<NumericUpDown>();
            numIns = new List<NumericUpDown>();
        }

        public PropertiesDialog(decimal _nodeLoss, NodeType type, bool _isStartElement)
        {
            NodeLoss = _nodeLoss;
            Type = type;
            IsStartElement = _isStartElement;
            Mode = PropsMode.Node;
            typeItems = NodeTypeRepositoryItem.GetStockItems();
            typeItems.ForEach(x => typeItemsBindingList.Add(x));
            InitializeComponent();
            cbType.ValueMember = "Val";
            cbType.DisplayMember = "Name";
            cbType.DataSource = typeItemsBindingList;
            cbType.SelectedValue = Type;
        }

        public PropertiesDialog(decimal _length, decimal _pipeLoss, decimal _c, decimal _diameter, decimal _qs, decimal _qe, int _sign, bool _reversed)
        {
            numOuts = new List<NumericUpDown>();
            numIns = new List<NumericUpDown>();
            Length = _length;
            PipeLoss = _pipeLoss;
            C = _c;
            Diameter = _diameter;
            Qs = _qs;
            Qe = _qe;
            Reversed = _reversed;
            Sign = _sign;
            Mode = PropsMode.Pipe;
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Length = this.numLength.Value;
            PipeLoss = numPipeLoss.Value;
            Diameter = numDia.Value;
            C = numC.Value;
            Qs = numQs.Value;
            Qe = numQe.Value;
            Sign = rbPlus.Checked ? 1 : -1;
            NodeLoss = this.numLoss.Value;
            if(cbType.SelectedValue != null)
                Type = (NodeType)(cbType.SelectedValue);
            IsStartElement = chStart.Checked;
            Reversed = chReversed.Checked;
            Mode = PropsMode.Node;
        }

        private void cbType_ValueMemberChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb != null && cb.SelectedValue != null)
            {
                NodeType t = (NodeType)cb.SelectedValue;
              
            }
        }

        private void PropertiesDialog_Load(object sender, EventArgs e)
        {
            numLength.Value = Length;
            numPipeLoss.Value = PipeLoss;
            numDia.Value = Diameter;
            numC.Value = C;
            numQs.Value = Qs;
            numQe.Value = Qe;
            rbMinus.Checked = Sign < 0;
            rbPlus.Checked = Sign > 0;
            chStart.Checked = IsStartElement;
            chReversed.Checked = Reversed;
            if (StartElementCheckboxLock)
                chStart.Enabled = false;
            numLoss.Value = NodeLoss;
            if (Mode == PropsMode.Node)
            {
                pnlPipe.Visible = false;
            }
            else if(Mode == PropsMode.Pipe)
            {
                pnlNode.Visible = false;
            }
        }
    }
    public enum PropsMode { Pipe, Node, Both }
}
