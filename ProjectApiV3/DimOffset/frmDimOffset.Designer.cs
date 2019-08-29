namespace ProjectApiV3.DimOffset
{
    partial class frmDimOffset
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
            this.btnDimOffsetCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMinimunDistanceDim = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxOffsetTextDimX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxOffsetTextDimY = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDimOffsetCancel
            // 
            this.btnDimOffsetCancel.Location = new System.Drawing.Point(115, 82);
            this.btnDimOffsetCancel.Name = "btnDimOffsetCancel";
            this.btnDimOffsetCancel.Size = new System.Drawing.Size(80, 23);
            this.btnDimOffsetCancel.TabIndex = 3;
            this.btnDimOffsetCancel.Text = "Cancel";
            this.btnDimOffsetCancel.UseVisualStyleBackColor = true;
            this.btnDimOffsetCancel.Click += new System.EventHandler(this.btnDimOffsetCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Minimun distance:";
            // 
            // txtMinimunDistanceDim
            // 
            this.txtMinimunDistanceDim.Location = new System.Drawing.Point(115, 5);
            this.txtMinimunDistanceDim.Name = "txtMinimunDistanceDim";
            this.txtMinimunDistanceDim.Size = new System.Drawing.Size(80, 20);
            this.txtMinimunDistanceDim.TabIndex = 5;
            this.txtMinimunDistanceDim.Text = "500";
            this.txtMinimunDistanceDim.TextChanged += new System.EventHandler(this.txtMinimunDistanceDim_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Offset X:";
            // 
            // textBoxOffsetTextDimX
            // 
            this.textBoxOffsetTextDimX.Location = new System.Drawing.Point(115, 31);
            this.textBoxOffsetTextDimX.Name = "textBoxOffsetTextDimX";
            this.textBoxOffsetTextDimX.Size = new System.Drawing.Size(80, 20);
            this.textBoxOffsetTextDimX.TabIndex = 5;
            this.textBoxOffsetTextDimX.Text = "800";
            this.textBoxOffsetTextDimX.TextChanged += new System.EventHandler(this.textBoxOffsetTextDimX_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Offset Y:";
            // 
            // textBoxOffsetTextDimY
            // 
            this.textBoxOffsetTextDimY.Location = new System.Drawing.Point(115, 56);
            this.textBoxOffsetTextDimY.Name = "textBoxOffsetTextDimY";
            this.textBoxOffsetTextDimY.Size = new System.Drawing.Size(80, 20);
            this.textBoxOffsetTextDimY.TabIndex = 5;
            this.textBoxOffsetTextDimY.Text = "330";
            this.textBoxOffsetTextDimY.TextChanged += new System.EventHandler(this.textBoxOffsetTextDimY_TextChanged);
            // 
            // frmDimOffset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 112);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxOffsetTextDimY);
            this.Controls.Add(this.textBoxOffsetTextDimX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMinimunDistanceDim);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDimOffsetCancel);
            this.MaximizeBox = false;
            this.Name = "frmDimOffset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDimOffset";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmDimOffset_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnDimOffsetCancel;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtMinimunDistanceDim;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxOffsetTextDimX;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBoxOffsetTextDimY;
    }
}