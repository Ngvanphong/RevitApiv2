namespace MainProjectApi.NoNumberSheet
{
    partial class frmNoNumberSheet
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
            this.txtNoStartNumber = new System.Windows.Forms.TextBox();
            this.btnStartNoNumber = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Number:";
            // 
            // txtNoStartNumber
            // 
            this.txtNoStartNumber.Location = new System.Drawing.Point(99, 20);
            this.txtNoStartNumber.Name = "txtNoStartNumber";
            this.txtNoStartNumber.Size = new System.Drawing.Size(107, 20);
            this.txtNoStartNumber.TabIndex = 1;
            this.txtNoStartNumber.Text = "001";
            // 
            // btnStartNoNumber
            // 
            this.btnStartNoNumber.Location = new System.Drawing.Point(236, 15);
            this.btnStartNoNumber.Name = "btnStartNoNumber";
            this.btnStartNoNumber.Size = new System.Drawing.Size(75, 29);
            this.btnStartNoNumber.TabIndex = 2;
            this.btnStartNoNumber.Text = "Start";
            this.btnStartNoNumber.UseVisualStyleBackColor = true;
            this.btnStartNoNumber.Click += new System.EventHandler(this.btnStartNoNumber_Click);
            // 
            // frmNoNumberSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 65);
            this.Controls.Add(this.btnStartNoNumber);
            this.Controls.Add(this.txtNoStartNumber);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNoNumberSheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNoNumberSheet";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmNoNumberSheet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtNoStartNumber;
        public System.Windows.Forms.Button btnStartNoNumber;
    }
}