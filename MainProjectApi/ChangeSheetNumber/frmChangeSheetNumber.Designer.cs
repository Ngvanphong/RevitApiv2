namespace MainProjectApi.ChangeSheetNumber
{
    partial class frmChangeSheetNumber
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSheetNumberStart = new System.Windows.Forms.TextBox();
            this.btnChangeSheetNumber = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sheet Number Start:";
            // 
            // txtSheetNumberStart
            // 
            this.txtSheetNumberStart.Location = new System.Drawing.Point(121, 17);
            this.txtSheetNumberStart.Name = "txtSheetNumberStart";
            this.txtSheetNumberStart.Size = new System.Drawing.Size(126, 20);
            this.txtSheetNumberStart.TabIndex = 1;
            // 
            // btnChangeSheetNumber
            // 
            this.btnChangeSheetNumber.Location = new System.Drawing.Point(265, 12);
            this.btnChangeSheetNumber.Name = "btnChangeSheetNumber";
            this.btnChangeSheetNumber.Size = new System.Drawing.Size(89, 28);
            this.btnChangeSheetNumber.TabIndex = 2;
            this.btnChangeSheetNumber.Text = "Start";
            this.btnChangeSheetNumber.UseVisualStyleBackColor = true;
            this.btnChangeSheetNumber.Click += new System.EventHandler(this.btnChangeSheetNumber_Click);
            // 
            // frmChangeSheetNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 57);
            this.Controls.Add(this.btnChangeSheetNumber);
            this.Controls.Add(this.txtSheetNumberStart);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangeSheetNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChangeSheetNumber";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtSheetNumberStart;
        public System.Windows.Forms.Button btnChangeSheetNumber;
    }
}