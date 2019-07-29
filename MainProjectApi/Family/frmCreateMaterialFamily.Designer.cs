namespace MainProjectApi.CreateMaterialFamily
{
    partial class frmCreateMaterialFamily
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer Components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (Components != null))
            {
                Components.Dispose();
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
            this.dropMaterial = new System.Windows.Forms.ComboBox();
            this.btnCreateMaterialComponent = new System.Windows.Forms.Button();
            this.Category = new System.Windows.Forms.Label();
            this.dropCategory = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Material:";
            // 
            // dropMaterial
            // 
            this.dropMaterial.FormattingEnabled = true;
            this.dropMaterial.Location = new System.Drawing.Point(64, 13);
            this.dropMaterial.Name = "dropMaterial";
            this.dropMaterial.Size = new System.Drawing.Size(173, 21);
            this.dropMaterial.TabIndex = 1;
            // 
            // btnCreateMaterialComponent
            // 
            this.btnCreateMaterialComponent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateMaterialComponent.Location = new System.Drawing.Point(498, 42);
            this.btnCreateMaterialComponent.Name = "btnCreateMaterialComponent";
            this.btnCreateMaterialComponent.Size = new System.Drawing.Size(105, 34);
            this.btnCreateMaterialComponent.TabIndex = 2;
            this.btnCreateMaterialComponent.Text = "Create";
            this.btnCreateMaterialComponent.UseVisualStyleBackColor = true;
            this.btnCreateMaterialComponent.Click += new System.EventHandler(this.btnCreateMaterialFamily_Click);
            // 
            // Category
            // 
            this.Category.AutoSize = true;
            this.Category.Location = new System.Drawing.Point(263, 16);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(52, 13);
            this.Category.TabIndex = 3;
            this.Category.Text = "Category:";
            this.Category.Click += new System.EventHandler(this.Category_Click);
            // 
            // dropCategory
            // 
            this.dropCategory.FormattingEnabled = true;
            this.dropCategory.Location = new System.Drawing.Point(318, 13);
            this.dropCategory.Name = "dropCategory";
            this.dropCategory.Size = new System.Drawing.Size(170, 21);
            this.dropCategory.TabIndex = 4;
            // 
            // frmCreateMaterialCompont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 88);
            this.Controls.Add(this.dropCategory);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.btnCreateMaterialComponent);
            this.Controls.Add(this.dropMaterial);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreateMaterialCompont";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCreateMaterialCompont";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmCreateMaterialCompont_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateMaterialComponent;
        private System.Windows.Forms.Label Category;
        public System.Windows.Forms.ComboBox dropMaterial;
        public System.Windows.Forms.ComboBox dropCategory;
    }
}