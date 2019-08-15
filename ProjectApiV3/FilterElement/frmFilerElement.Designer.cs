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
            this.btnFilterElement3 = new System.Windows.Forms.Button();
            this.btnFilterElement4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewCategory
            // 
            this.listViewCategory.CheckBoxes = true;
            this.listViewCategory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewCategory.Location = new System.Drawing.Point(8, 9);
            this.listViewCategory.Name = "listViewCategory";
            this.listViewCategory.Size = new System.Drawing.Size(164, 323);
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
            this.listViewValueParameter.CheckBoxes = true;
            this.listViewValueParameter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.listViewValueParameter.Location = new System.Drawing.Point(610, 9);
            this.listViewValueParameter.Name = "listViewValueParameter";
            this.listViewValueParameter.Size = new System.Drawing.Size(173, 323);
            this.listViewValueParameter.TabIndex = 4;
            this.listViewValueParameter.UseCompatibleStateImageBehavior = false;
            this.listViewValueParameter.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Value Parameter";
            this.columnHeader5.Width = 250;
            // 
            // checkBoxCategoryAll
            // 
            this.checkBoxCategoryAll.AutoSize = true;
            this.checkBoxCategoryAll.Location = new System.Drawing.Point(35, 341);
            this.checkBoxCategoryAll.Name = "checkBoxCategoryAll";
            this.checkBoxCategoryAll.Size = new System.Drawing.Size(37, 17);
            this.checkBoxCategoryAll.TabIndex = 5;
            this.checkBoxCategoryAll.Text = "All";
            this.checkBoxCategoryAll.UseVisualStyleBackColor = true;
            this.checkBoxCategoryAll.CheckedChanged += new System.EventHandler(this.checkBoxCategoryAll_CheckedChanged);
            // 
            // checkBoxTypeNameAll
            // 
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
            this.btnFilterElement.Location = new System.Drawing.Point(78, 337);
            this.btnFilterElement.Name = "btnFilterElement";
            this.btnFilterElement.Size = new System.Drawing.Size(51, 23);
            this.btnFilterElement.TabIndex = 6;
            this.btnFilterElement.Text = "Select";
            this.btnFilterElement.UseVisualStyleBackColor = true;
            this.btnFilterElement.Click += new System.EventHandler(this.btnFilterElement_Click);
            // 
            // btnFilterElement2
            // 
            this.btnFilterElement2.Location = new System.Drawing.Point(307, 337);
            this.btnFilterElement2.Name = "btnFilterElement2";
            this.btnFilterElement2.Size = new System.Drawing.Size(51, 23);
            this.btnFilterElement2.TabIndex = 6;
            this.btnFilterElement2.Text = "Select";
            this.btnFilterElement2.UseVisualStyleBackColor = true;
            this.btnFilterElement2.Click += new System.EventHandler(this.btnFilterElement2_Click);
            // 
            // btnFilterElement3
            // 
            this.btnFilterElement3.Location = new System.Drawing.Point(510, 337);
            this.btnFilterElement3.Name = "btnFilterElement3";
            this.btnFilterElement3.Size = new System.Drawing.Size(51, 23);
            this.btnFilterElement3.TabIndex = 6;
            this.btnFilterElement3.Text = "Select";
            this.btnFilterElement3.UseVisualStyleBackColor = true;
            this.btnFilterElement3.Click += new System.EventHandler(this.btnFilterElement3_Click);
            // 
            // btnFilterElement4
            // 
            this.btnFilterElement4.Location = new System.Drawing.Point(672, 337);
            this.btnFilterElement4.Name = "btnFilterElement4";
            this.btnFilterElement4.Size = new System.Drawing.Size(51, 23);
            this.btnFilterElement4.TabIndex = 6;
            this.btnFilterElement4.Text = "Select";
            this.btnFilterElement4.UseVisualStyleBackColor = true;
            this.btnFilterElement4.Click += new System.EventHandler(this.btnFilterElement4_Click);
            // 
            // frmFilerElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 366);
            this.Controls.Add(this.btnFilterElement4);
            this.Controls.Add(this.btnFilterElement3);
            this.Controls.Add(this.btnFilterElement2);
            this.Controls.Add(this.btnFilterElement);
            this.Controls.Add(this.checkBoxTypeNameAll);
            this.Controls.Add(this.checkBoxCategoryAll);
            this.Controls.Add(this.listViewValueParameter);
            this.Controls.Add(this.listViewParameter);
            this.Controls.Add(this.listViewTypeName);
            this.Controls.Add(this.listViewCategory);
            this.MaximizeBox = false;
            this.Name = "frmFilerElement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFilerElement";
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
        private System.Windows.Forms.Button btnFilterElement3;
        private System.Windows.Forms.Button btnFilterElement4;
    }
}