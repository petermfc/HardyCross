namespace Hardy
{
    partial class InitialNodeDialog
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
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblCycle = new System.Windows.Forms.Label();
            this.cbNode = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(13, 13);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(167, 13);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Please provide start pipe for loop: ";
            // 
            // lblCycle
            // 
            this.lblCycle.AutoSize = true;
            this.lblCycle.Location = new System.Drawing.Point(13, 30);
            this.lblCycle.Name = "lblCycle";
            this.lblCycle.Size = new System.Drawing.Size(35, 13);
            this.lblCycle.TabIndex = 1;
            this.lblCycle.Text = "label2";
            // 
            // cbNode
            // 
            this.cbNode.FormattingEnabled = true;
            this.cbNode.Location = new System.Drawing.Point(16, 46);
            this.cbNode.Name = "cbNode";
            this.cbNode.Size = new System.Drawing.Size(168, 21);
            this.cbNode.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(87, 115);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // InitialNodeDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 150);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbNode);
            this.Controls.Add(this.lblCycle);
            this.Controls.Add(this.lblQuestion);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InitialNodeDialog";
            this.Text = "InitialNodeDialog";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label lblCycle;
        private System.Windows.Forms.ComboBox cbNode;
        private System.Windows.Forms.Button btnOK;
    }
}