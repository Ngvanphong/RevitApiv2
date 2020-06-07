namespace ProjectApiV3.CropView
{
    partial class frmCropView
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
            this.listViewViewCrop = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewViewCropSimilar = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCropView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewViewCrop
            // 
            this.listViewViewCrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewViewCrop.CheckBoxes = true;
            this.listViewViewCrop.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewViewCrop.Location = new System.Drawing.Point(12, 41);
            this.listViewViewCrop.Name = "listViewViewCrop";
            this.listViewViewCrop.Size = new System.Drawing.Size(410, 487);
            this.listViewViewCrop.TabIndex = 0;
            this.listViewViewCrop.UseCompatibleStateImageBehavior = false;
            this.listViewViewCrop.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "View Name";
            this.columnHeader1.Width = 1500;
            // 
            // listViewViewCropSimilar
            // 
            this.listViewViewCropSimilar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewViewCropSimilar.CheckBoxes = true;
            this.listViewViewCropSimilar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewViewCropSimilar.Location = new System.Drawing.Point(498, 41);
            this.listViewViewCropSimilar.Name = "listViewViewCropSimilar";
            this.listViewViewCropSimilar.Size = new System.Drawing.Size(454, 487);
            this.listViewViewCropSimilar.TabIndex = 1;
            this.listViewViewCropSimilar.UseCompatibleStateImageBehavior = false;
            this.listViewViewCropSimilar.View = System.Windows.Forms.View.Details;
            this.listViewViewCropSimilar.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewViewCropSimilar_ItemChecked);
            this.listViewViewCropSimilar.SelectedIndexChanged += new System.EventHandler(this.listViewViewCropSimilar_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "View Name";
            this.columnHeader2.Width = 1500;
            // 
            // btnCropView
            // 
            this.btnCropView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCropView.Location = new System.Drawing.Point(428, 227);
            this.btnCropView.Name = "btnCropView";
            this.btnCropView.Size = new System.Drawing.Size(64, 29);
            this.btnCropView.TabIndex = 2;
            this.btnCropView.Text = "Crop View";
            this.btnCropView.UseVisualStyleBackColor = true;
            this.btnCropView.Click += new System.EventHandler(this.btnCropView_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose view crop:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(495, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Choose a view similar:";
            // 
            // frmCropView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 542);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCropView);
            this.Controls.Add(this.listViewViewCropSimilar);
            this.Controls.Add(this.listViewViewCrop);
            this.Name = "frmCropView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCropView";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmCropView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnCropView;
        public System.Windows.Forms.ListView listViewViewCrop;
        public System.Windows.Forms.ListView listViewViewCropSimilar;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}