namespace MainProjectApi.DuplicateView
{
    partial class frmDuplicateView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.radioButtonDuplicateDependent = new System.Windows.Forms.RadioButton();
            this.radioButtonDuplicateNormalView = new System.Windows.Forms.RadioButton();
            this.radioButtonDuplicateWithdetailingView = new System.Windows.Forms.RadioButton();
            this.textBoxNumberDuplicate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDuplicateView = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxNumberDuplicate);
            this.groupBox1.Controls.Add(this.radioButtonDuplicateWithdetailingView);
            this.groupBox1.Controls.Add(this.radioButtonDuplicateNormalView);
            this.groupBox1.Controls.Add(this.radioButtonDuplicateDependent);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Duplicate";
            // 
            // radioButtonDuplicateDependent
            // 
            this.radioButtonDuplicateDependent.AutoSize = true;
            this.radioButtonDuplicateDependent.Location = new System.Drawing.Point(200, 19);
            this.radioButtonDuplicateDependent.Name = "radioButtonDuplicateDependent";
            this.radioButtonDuplicateDependent.Size = new System.Drawing.Size(78, 17);
            this.radioButtonDuplicateDependent.TabIndex = 0;
            this.radioButtonDuplicateDependent.Text = "Dependent";
            this.radioButtonDuplicateDependent.UseVisualStyleBackColor = true;
            // 
            // radioButtonDuplicateNormalView
            // 
            this.radioButtonDuplicateNormalView.AutoSize = true;
            this.radioButtonDuplicateNormalView.Location = new System.Drawing.Point(111, 19);
            this.radioButtonDuplicateNormalView.Name = "radioButtonDuplicateNormalView";
            this.radioButtonDuplicateNormalView.Size = new System.Drawing.Size(70, 17);
            this.radioButtonDuplicateNormalView.TabIndex = 0;
            this.radioButtonDuplicateNormalView.Text = "Duplicate";
            this.radioButtonDuplicateNormalView.UseVisualStyleBackColor = true;
            // 
            // radioButtonDuplicateWithdetailingView
            // 
            this.radioButtonDuplicateWithdetailingView.AutoSize = true;
            this.radioButtonDuplicateWithdetailingView.Checked = true;
            this.radioButtonDuplicateWithdetailingView.Location = new System.Drawing.Point(14, 19);
            this.radioButtonDuplicateWithdetailingView.Name = "radioButtonDuplicateWithdetailingView";
            this.radioButtonDuplicateWithdetailingView.Size = new System.Drawing.Size(91, 17);
            this.radioButtonDuplicateWithdetailingView.TabIndex = 0;
            this.radioButtonDuplicateWithdetailingView.TabStop = true;
            this.radioButtonDuplicateWithdetailingView.Text = "With Detailing";
            this.radioButtonDuplicateWithdetailingView.UseVisualStyleBackColor = true;
            // 
            // textBoxNumberDuplicate
            // 
            this.textBoxNumberDuplicate.Location = new System.Drawing.Point(111, 42);
            this.textBoxNumberDuplicate.Name = "textBoxNumberDuplicate";
            this.textBoxNumberDuplicate.Size = new System.Drawing.Size(176, 20);
            this.textBoxNumberDuplicate.TabIndex = 1;
            this.textBoxNumberDuplicate.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Duplicate Count:";
            // 
            // btnDuplicateView
            // 
            this.btnDuplicateView.Location = new System.Drawing.Point(227, 83);
            this.btnDuplicateView.Name = "btnDuplicateView";
            this.btnDuplicateView.Size = new System.Drawing.Size(85, 25);
            this.btnDuplicateView.TabIndex = 1;
            this.btnDuplicateView.Text = "Ok";
            this.btnDuplicateView.UseVisualStyleBackColor = true;
            this.btnDuplicateView.Click += new System.EventHandler(this.btnDuplicateView_Click);
            // 
            // frmDuplicateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 117);
            this.Controls.Add(this.btnDuplicateView);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDuplicateView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDuplicateView";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.RadioButton radioButtonDuplicateWithdetailingView;
        public System.Windows.Forms.RadioButton radioButtonDuplicateNormalView;
        public System.Windows.Forms.RadioButton radioButtonDuplicateDependent;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.Button btnDuplicateView;
        public System.Windows.Forms.TextBox textBoxNumberDuplicate;
    }
}