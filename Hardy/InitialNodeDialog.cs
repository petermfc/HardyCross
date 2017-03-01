using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Hardy
{
    public partial class InitialNodeDialog : Form
    {
        public List<Pipe> Pipes { get; set; }
        public Pipe SelectedPipe { get; set; }
        private BindingList<Pipe> bindingList;
        public InitialNodeDialog(List<Pipe> pipes)
        {
            InitializeComponent();
            Pipes = pipes;
            bindingList = new BindingList<Pipe>(pipes);
            cbNode.DisplayMember = "Label";
            cbNode.ValueMember = "Label";
            cbNode.DataSource = bindingList;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string val = cbNode.SelectedValue.ToString();
            SelectedPipe = Pipes.Where(p => p.Label == val).First();
        }
    }
}
