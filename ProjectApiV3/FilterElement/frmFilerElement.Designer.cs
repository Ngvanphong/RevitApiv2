namespace ProjectApiV3.FilterElement
{
    partial class frmFilerElement
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
            this.listViewCategory = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewTypeName = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewParameter = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewValueParameter = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkBoxCategoryAll = new System.Windows.Forms.CheckBox();
            this.checkBoxTypeNameAll = new System.Windows.Forms.CheckBox();
            this.btnFilterElement = new System.Windows.Forms.Button();
            this.btnFilterElement2 = new System.Windows.Forms.Button();
            this.btnFilterElement4 = new System.Windows.Forms.Button();
            this.checkBoxParameterNone = new System.Windows.Forms.CheckBox();
            this.checkBoxValueParameterNone = new System.Windows.Forms.CheckBox();
            this.btnUpdateValueParameter = new System.Windows.Forms.Button();
            this.checkBoxFamilyAndTypeNone = new System.Windows.Forms.CheckBox();
            this.checkBoxCategoryNone = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listViewCategory
            // 
            this.listViewCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewCategory.CheckBoxes = true;
            this.listViewCategory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewCategory.Location = new System.Drawing.Point(2, 9);
            this.listViewCategory.Name = "listViewCategory";
            this.listViewCategory.Size = new System.Drawing.Size(170, 323);
            this.listViewCategory.TabIndex = 0;
            this.listViewCategory.UseCompatibleStateImageBehavior = false;
            this.listViewCategory.View = System.Windows.Forms.View.Details;
            this.listViewCategory.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewCategory_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Category";
            this.columnHeader1.Width = 200;
            // 
            // listViewTypeName
            // 
            this.listViewTypeName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewTypeName.CheckBoxes = true;
            this.listViewTypeName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listViewTypeName.Location = new System.Drawing.Point(178, 9);
            this.listViewTypeName.Name = "listViewTypeName";
            this.listViewTypeName.Size = new System.Drawing.Size(268, 323);
            this.listViewTypeName.TabIndex = 2;
            this.listViewTypeName.UseCompatibleStateImageBehavior = false;
            this.listViewTypeName.View = System.Windows.Forms.View.Details;
            this.listViewTypeName.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewTypeName_ItemChecked);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Family/TypeName";
            this.columnHeader3.Width = 300;
            // 
            // listViewParameter
            // 
            this.listViewParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewParameter.CheckBoxes = true;
            this.listViewParameter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.listViewParameter.Location = new System.Drawing.Point(452, 9);
            this.listViewParameter.Name = "listViewParameter";
            this.listViewParameter.Size = new System.Drawing.Size(151, 323);
            this.listViewParameter.TabIndex = 3;
            this.listViewParameter.UseCompatibleStateImageBehavior = false;
            this.listViewParameter.View = System.Windows.Forms.View.Details;
            this.listViewParameter.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewParameter_ItemChecked);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Parameter";
            this.columnHeader4.Width = 200;
            // 
            // listViewValueParameter
            // 
            this.listViewValueParameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewValueParameter.CheckBoxes = true;
            this.listViewValueParameter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.listViewValueParameter.Location = new System.Drawing.Point(610, 9);
            this.listViewValueParameter.Name = "listViewValueParameter";
            this.listViewValueParameter.Size = new System.Drawing.Size(187, 323);
            this.listViewValueParameter.TabIndex = 4;
            this.listViewValueParameter.UseCompatibleStateImageBehavior = false;
            this.listViewValueParameter.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Value Parameter";
            this.columnHeader5.Width = 500;
            // 
            // checkBoxCategoryAll
            // 
            this.checkBoxCategoryAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxCategoryAll.AutoSize = true;
            this.checkBoxCategoryAll.Location = new System.Drawing.Point(64, 341);
            this.checkBoxCategoryAll.Name = "checkBoxCategoryAll";
            this.checkBoxCategoryAll.Size = new System.Drawing.Size(37, 17);
            this.checkBoxCategoryAll.TabIndex = 5;
            this.checkBoxCategoryAll.Text = "All";
            this.checkBoxCategoryAll.UseVisualStyleBackColor = true;
            this.checkBoxCategoryAll.CheckedChanged += new System.EventHandler(this.checkBoxCategoryAll_CheckedChanged);
            // 
            // checkBoxTypeNameAll
            // 
            this.checkBoxTypeNameAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxTypeNameAll.AutoSize = true;
            this.checkBoxTypeNameAll.Location = new System.Drawing.Point(264, 341);
            this.checkBoxTypeNameAll.Name = "checkBoxTypeNameAll";
            this.checkBoxTypeNameAll.Size = new System.Drawing.Size(37, 17);
            this.checkBoxTypeNameAll.TabIndex = 5;
            this.checkBoxTypeNameAll.Text = "All";
            this.checkBoxTypeNameAll.UseVisualStyleBackColor = true;
            this.checkBoxTypeNameAll.CheckedChanged += new System.EventHandler(this.checkBoxTypeNameAll_CheckedChanged);
            // 
            // btnFilterElement
            // 
            this.btnFilterElement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilterElement.Location = new System.Drawing.Point(105, 337);
            this.btnFilterElement.Name = "btnFilterElement";
            this.btnFilterElement.Size = new System.Drawing.Size(51, 23);
            this.btnFilterElement.TabIndex = 6;
            this.btnFilterElement.Text = "Select";
            this.btnFilterElement.UseVisualStyleBackColor = true;
            this.btnFilterElement.Click += new System.EventHandler(this.btnFilterElement_Click);
            // 
            // btnFilterElement2
            // 
            this.btnFilterElement2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilterElement2.Location = new System.Drawing.Point(307, 337);
            this.btnFilterElement2.Name = "btnFilterElement2";
            this.btnFilterElement2.Size = new System.Drawing.Size(51, 23);
            this.btnFilterElement2.TabIndex = 6;
            this.btnFilterElement2.Text = "Select";
            this.btnFilterElement2.UseVisualStyleBackColor = true;
            this.btnFilterElement2.Click += new System.EventHandler(this.btnFilterElement2_Click);
            // 
            // btnFilterElement4
            // 
            this.btnFilterElement4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilterElement4.Location = new System.Drawing.Point(736, 337);
            this.btnFilterElement4.Name = "btnFilterElement4";
            this.btnFilterElement4.Size = new System.Drawing.Size(51, 23);
            this.btnFilterElement4.TabIndex = 6;
            this.btnFilterElement4.Text = "Select";
            this.btnFilterElement4.UseVisualStyleBackColor = true;
            this.btnFilterElement4.Click += new System.EventHandler(this.btnFilterElement4_Click);
            // 
            // checkBoxParameterNone
            // 
            this.checkBoxParameterNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxParameterNone.AutoSize = true;
            this.checkBoxParameterNone.Location = new System.Drawing.Point(508, 341);
            this.checkBoxParameterNone.Name = "checkBoxParameterNone";
            this.checkBoxParameterNone.Size = new System.Drawing.Size(52, 17);
            this.checkBoxParameterNone.TabIndex = 5;
            this.checkBoxParameterNone.Text = "None";
            this.checkBoxParameterNone.UseVisualStyleBackColor = true;
            this.checkBoxParameterNone.CheckedChanged += new System.EventHandler(this.checkBoxParameterNone_CheckedChanged);
            // 
            // checkBoxValueParameterNone
            // 
            this.checkBoxValueParameterNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxValueParameterNone.AutoSize = true;
            this.checkBoxValueParameterNone.Location = new System.Drawing.Point(684, 341);
            this.checkBoxValueParameterNone.Name = "checkBoxValueParameterNone";
            this.checkBoxValueParameterNone.Size = new System.Drawing.Size(52, 17);
            this.checkBoxValueParameterNone.TabIndex = 5;
            this.checkBoxValueParameterNone.Text = "None";
            this.checkBoxValueParameterNone.UseVisualStyleBackColor = true;
            this.checkBoxValueParameterNone.CheckedChanged += new System.EventHandler(this.checkBoxValueParameterNone_CheckedChanged);
            // 
            // btnUpdateValueParameter
            // 
            this.btnUpdateValueParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdateValueParameter.Location = new System.Drawing.Point(610, 337);
            this.btnUpdateValueParameter.Name = "btnUpdateValueParameter";
            this.btnUpdateValueParameter.Size = new System.Drawing.Size(62, 23);
            this.btnUpdateValueParameter.TabIndex = 7;
            this.btnUpdateValueParameter.Text = "Update";
            this.btnUpdateValueParameter.UseVisualStyleBackColor = true;
            this.btnUpdateValueParameter.Click += new System.EventHandler(this.btnUpdateValueParameter_Click);
            // 
            // checkBoxFamilyAndTypeNone
            // 
            this.checkBoxFamilyAndTypeNone.AutoSize = true;
            this.checkBoxFamilyAndTypeNone.Location = new System.Drawing.Point(206, 341);
            this.checkBoxFamilyAndTypeNone.Name = "checkBoxFamilyAndTypeNone";
            this.checkBoxFamilyAndTypeNone.Size = new System.Drawing.Size(52, 17);
            this.checkBoxFamilyAndTypeNone.TabIndex = 8;
            this.checkBoxFamilyAndTypeNone.Text = "None";
            this.checkBoxFamilyAndTypeNone.UseVisualStyleBackColor = true;
            this.checkBoxFamilyAndTypeNone.CheckedChanged += new System.EventHandler(this.checkBoxFamilyAndTypeNone_CheckedChanged);
            // 
            // checkBoxCategoryNone
            // 
            this.checkBoxCategoryNone.AutoSize = true;
            this.checkBoxCategoryNone.Location = new System.Drawing.Point(8, 341);
            this.checkBoxCategoryNone.Name = "checkBoxCategoryNone";
            this.checkBoxCategoryNone.Size = new System.Drawing.Size(52, 17);
            this.checkBoxCategoryNone.TabIndex = 9;
            this.checkBoxCategoryNone.Text = "None";
            this.checkBoxCategoryNone.UseVisualStyleBackColor = true;
            this.checkBoxCategoryNone.CheckedChanged += new System.EventHandler(this.checkBoxCategoryNone_CheckedChanged);
            // 
            // frmFilerElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 366);
            this.Controls.Add(this.checkBoxCategoryNone);
            this.Controls.Add(this.checkBoxFamilyAndTypeNone);
            this.Controls.Add(this.btnUpdateValueParameter);
            this.Controls.Add(this.btnFilterElement4);
            this.Controls.Add(this.btnFilterElement2);
            this.Controls.Add(this.btnFilterElement);
            this.Controls.Add(this.checkBoxValueParameterNone);
            this.Controls.Add(this.checkBoxParameterNone);
            this.Controls.Add(this.checkBoxTypeNameAll);
            this.Controls.Add(this.checkBoxCategoryAll);
            this.Controls.Add(this.listViewValueParameter);
            this.Controls.Add(this.listViewParameter);
            this.Controls.Add(this.listViewTypeName);
            this.Controls.Add(this.listViewCategory);
            this.MaximizeBox = false;
            this.Name = "frmFilerElement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFilterElement";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmFilerElement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        public System.Windows.Forms.CheckBox checkBoxCategoryAll;
        public System.Windows.Forms.CheckBox checkBoxTypeNameAll;
        public System.Windows.Forms.ListView listViewCategory;
        public System.Windows.Forms.ListView listViewTypeName;
        public System.Windows.Forms.ListView listViewParameter;
        public System.Windows.Forms.ListView listViewValueParameter;
        private System.Windows.Forms.Button btnFilterElement;
        private System.Windows.Forms.Button btnFilterElement2;
        private System.Windows.Forms.Button btnFilterElement4;
        public System.Windows.Forms.CheckBox checkBoxParameterNone;
        public System.Windows.Forms.CheckBox checkBoxValueParameterNone;
        private System.Windows.Forms.Button btnUpdateValueParameter;
        public System.Windows.Forms.CheckBox checkBoxFamilyAndTypeNone;
        public System.Windows.Forms.CheckBox checkBoxCategoryNone;
    }
}