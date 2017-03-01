namespace Hardy
{
    partial class PropertiesDialog
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
            this.components = new System.ComponentModel.Container();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numLength = new System.Windows.Forms.NumericUpDown();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblLoss = new System.Windows.Forms.Label();
            this.numLoss = new System.Windows.Forms.NumericUpDown();
            this.lblType = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.pnlPipe = new System.Windows.Forms.Panel();
            this.numQe = new System.Windows.Forms.NumericUpDown();
            this.lblQend = new System.Windows.Forms.Label();
            this.numQs = new System.Windows.Forms.NumericUpDown();
            this.lblQs = new System.Windows.Forms.Label();
            this.numDia = new System.Windows.Forms.NumericUpDown();
            this.lblDia = new System.Windows.Forms.Label();
            this.chReversed = new System.Windows.Forms.CheckBox();
            this.numC = new System.Windows.Forms.NumericUpDown();
            this.lblC = new System.Windows.Forms.Label();
            this.numPipeLoss = new System.Windows.Forms.NumericUpDown();
            this.lblFlow = new System.Windows.Forms.Label();
            this.pnlNode = new System.Windows.Forms.Panel();
            this.chStart = new System.Windows.Forms.CheckBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.nodeTypeRepositoryItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rbPlus = new System.Windows.Forms.RadioButton();
            this.rbMinus = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoss)).BeginInit();
            this.pnlPipe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPipeLoss)).BeginInit();
            this.pnlNode.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeTypeRepositoryItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(128, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(47, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // numLength
            // 
            this.numLength.DecimalPlaces = 2;
            this.numLength.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numLength.Location = new System.Drawing.Point(94, 7);
            this.numLength.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numLength.Name = "numLength";
            this.numLength.Size = new System.Drawing.Size(80, 20);
            this.numLength.TabIndex = 2;
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(3, 9);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(43, 13);
            this.lblLength.TabIndex = 5;
            this.lblLength.Text = "Length:";
            // 
            // lblLoss
            // 
            this.lblLoss.AutoSize = true;
            this.lblLoss.Location = new System.Drawing.Point(2, 33);
            this.lblLoss.Name = "lblLoss";
            this.lblLoss.Size = new System.Drawing.Size(57, 13);
            this.lblLoss.TabIndex = 7;
            this.lblLoss.Text = "Node loss:";
            // 
            // numLoss
            // 
            this.numLoss.DecimalPlaces = 2;
            this.numLoss.Location = new System.Drawing.Point(93, 31);
            this.numLoss.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numLoss.Name = "numLoss";
            this.numLoss.Size = new System.Drawing.Size(80, 20);
            this.numLoss.TabIndex = 6;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(2, 5);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "Type:";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(93, 3);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(80, 21);
            this.cbType.TabIndex = 9;
            this.cbType.ValueMemberChanged += new System.EventHandler(this.cbType_ValueMemberChanged);
            // 
            // pnlPipe
            // 
            this.pnlPipe.Controls.Add(this.rbMinus);
            this.pnlPipe.Controls.Add(this.rbPlus);
            this.pnlPipe.Controls.Add(this.numQe);
            this.pnlPipe.Controls.Add(this.lblQend);
            this.pnlPipe.Controls.Add(this.numQs);
            this.pnlPipe.Controls.Add(this.lblQs);
            this.pnlPipe.Controls.Add(this.numDia);
            this.pnlPipe.Controls.Add(this.lblDia);
            this.pnlPipe.Controls.Add(this.chReversed);
            this.pnlPipe.Controls.Add(this.numC);
            this.pnlPipe.Controls.Add(this.lblC);
            this.pnlPipe.Controls.Add(this.numPipeLoss);
            this.pnlPipe.Controls.Add(this.lblFlow);
            this.pnlPipe.Controls.Add(this.numLength);
            this.pnlPipe.Controls.Add(this.lblLength);
            this.pnlPipe.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPipe.Location = new System.Drawing.Point(0, 0);
            this.pnlPipe.Name = "pnlPipe";
            this.pnlPipe.Size = new System.Drawing.Size(206, 215);
            this.pnlPipe.TabIndex = 10;
            // 
            // numQe
            // 
            this.numQe.DecimalPlaces = 2;
            this.numQe.Location = new System.Drawing.Point(94, 152);
            this.numQe.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numQe.Name = "numQe";
            this.numQe.Size = new System.Drawing.Size(80, 20);
            this.numQe.TabIndex = 17;
            // 
            // lblQend
            // 
            this.lblQend.AutoSize = true;
            this.lblQend.Location = new System.Drawing.Point(3, 154);
            this.lblQend.Name = "lblQend";
            this.lblQend.Size = new System.Drawing.Size(39, 13);
            this.lblQend.TabIndex = 18;
            this.lblQend.Text = "Q end:";
            // 
            // numQs
            // 
            this.numQs.DecimalPlaces = 2;
            this.numQs.Location = new System.Drawing.Point(94, 128);
            this.numQs.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numQs.Name = "numQs";
            this.numQs.Size = new System.Drawing.Size(80, 20);
            this.numQs.TabIndex = 15;
            // 
            // lblQs
            // 
            this.lblQs.AutoSize = true;
            this.lblQs.Location = new System.Drawing.Point(3, 130);
            this.lblQs.Name = "lblQs";
            this.lblQs.Size = new System.Drawing.Size(41, 13);
            this.lblQs.TabIndex = 16;
            this.lblQs.Text = "Q start:";
            // 
            // numDia
            // 
            this.numDia.DecimalPlaces = 2;
            this.numDia.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numDia.Location = new System.Drawing.Point(94, 83);
            this.numDia.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numDia.Name = "numDia";
            this.numDia.Size = new System.Drawing.Size(80, 20);
            this.numDia.TabIndex = 13;
            // 
            // lblDia
            // 
            this.lblDia.AutoSize = true;
            this.lblDia.Location = new System.Drawing.Point(3, 85);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(69, 13);
            this.lblDia.TabIndex = 14;
            this.lblDia.Text = "Diameter [m]:";
            // 
            // chReversed
            // 
            this.chReversed.AutoSize = true;
            this.chReversed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chReversed.Location = new System.Drawing.Point(5, 110);
            this.chReversed.Name = "chReversed";
            this.chReversed.Size = new System.Drawing.Size(98, 17);
            this.chReversed.TabIndex = 12;
            this.chReversed.Text = "Draw reversed:";
            this.chReversed.UseVisualStyleBackColor = true;
            // 
            // numC
            // 
            this.numC.DecimalPlaces = 8;
            this.numC.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numC.Location = new System.Drawing.Point(94, 57);
            this.numC.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numC.Name = "numC";
            this.numC.Size = new System.Drawing.Size(80, 20);
            this.numC.TabIndex = 10;
            // 
            // lblC
            // 
            this.lblC.AutoSize = true;
            this.lblC.Location = new System.Drawing.Point(3, 59);
            this.lblC.Name = "lblC";
            this.lblC.Size = new System.Drawing.Size(17, 13);
            this.lblC.TabIndex = 11;
            this.lblC.Text = "C:";
            // 
            // numPipeLoss
            // 
            this.numPipeLoss.DecimalPlaces = 2;
            this.numPipeLoss.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numPipeLoss.Location = new System.Drawing.Point(94, 31);
            this.numPipeLoss.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numPipeLoss.Name = "numPipeLoss";
            this.numPipeLoss.Size = new System.Drawing.Size(80, 20);
            this.numPipeLoss.TabIndex = 6;
            // 
            // lblFlow
            // 
            this.lblFlow.AutoSize = true;
            this.lblFlow.Location = new System.Drawing.Point(3, 33);
            this.lblFlow.Name = "lblFlow";
            this.lblFlow.Size = new System.Drawing.Size(32, 13);
            this.lblFlow.TabIndex = 7;
            this.lblFlow.Text = "Loss:";
            // 
            // pnlNode
            // 
            this.pnlNode.Controls.Add(this.chStart);
            this.pnlNode.Controls.Add(this.lblType);
            this.pnlNode.Controls.Add(this.numLoss);
            this.pnlNode.Controls.Add(this.cbType);
            this.pnlNode.Controls.Add(this.lblLoss);
            this.pnlNode.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNode.Location = new System.Drawing.Point(0, 215);
            this.pnlNode.Name = "pnlNode";
            this.pnlNode.Size = new System.Drawing.Size(206, 100);
            this.pnlNode.TabIndex = 11;
            // 
            // chStart
            // 
            this.chStart.AutoSize = true;
            this.chStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chStart.Location = new System.Drawing.Point(0, 60);
            this.chStart.Name = "chStart";
            this.chStart.Size = new System.Drawing.Size(91, 17);
            this.chStart.TabIndex = 10;
            this.chStart.Text = "Start element:";
            this.chStart.UseVisualStyleBackColor = true;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnOK);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 318);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(206, 31);
            this.pnlButtons.TabIndex = 12;
            // 
            // nodeTypeRepositoryItemBindingSource
            // 
            this.nodeTypeRepositoryItemBindingSource.DataSource = typeof(Hardy.NodeTypeRepositoryItem);
            // 
            // rbPlus
            // 
            this.rbPlus.AutoSize = true;
            this.rbPlus.Location = new System.Drawing.Point(13, 182);
            this.rbPlus.Name = "rbPlus";
            this.rbPlus.Size = new System.Drawing.Size(31, 17);
            this.rbPlus.TabIndex = 19;
            this.rbPlus.Text = "+";
            this.rbPlus.UseVisualStyleBackColor = true;
            // 
            // rbMinus
            // 
            this.rbMinus.AutoSize = true;
            this.rbMinus.Location = new System.Drawing.Point(104, 182);
            this.rbMinus.Name = "rbMinus";
            this.rbMinus.Size = new System.Drawing.Size(28, 17);
            this.rbMinus.TabIndex = 20;
            this.rbMinus.Text = "-";
            this.rbMinus.UseVisualStyleBackColor = true;
            // 
            // PropertiesDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(206, 349);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlNode);
            this.Controls.Add(this.pnlPipe);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertiesDialog";
            this.ShowInTaskbar = false;
            this.Text = "PropertiesDialog";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PropertiesDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoss)).EndInit();
            this.pnlPipe.ResumeLayout(false);
            this.pnlPipe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPipeLoss)).EndInit();
            this.pnlNode.ResumeLayout(false);
            this.pnlNode.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nodeTypeRepositoryItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numLength;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label lblLoss;
        private System.Windows.Forms.NumericUpDown numLoss;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.BindingSource nodeTypeRepositoryItemBindingSource;
        private System.Windows.Forms.Panel pnlPipe;
        private System.Windows.Forms.NumericUpDown numPipeLoss;
        private System.Windows.Forms.Label lblFlow;
        private System.Windows.Forms.Panel pnlNode;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.CheckBox chStart;
        private System.Windows.Forms.NumericUpDown numC;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.CheckBox chReversed;
        private System.Windows.Forms.NumericUpDown numDia;
        private System.Windows.Forms.Label lblDia;
        private System.Windows.Forms.NumericUpDown numQe;
        private System.Windows.Forms.Label lblQend;
        private System.Windows.Forms.NumericUpDown numQs;
        private System.Windows.Forms.Label lblQs;
        private System.Windows.Forms.RadioButton rbMinus;
        private System.Windows.Forms.RadioButton rbPlus;
    }
}