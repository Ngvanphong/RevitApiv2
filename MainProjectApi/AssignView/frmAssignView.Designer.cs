namespace MainProjectApi.AssignView
{
    partial class frmAssignView
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
            this.listViewView = new System.Windows.Forms.ListView();
            this.columnViewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewSelect = new System.Windows.Forms.ListView();
            this.columnViewSelect = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.listSheet = new System.Windows.Forms.ListView();
            this.columnSheetNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSheetName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewView
            // 
            this.listViewView.CheckBoxes = true;
            this.listViewView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnViewName});
            this.listViewView.Location = new System.Drawing.Point(19, 25);
            this.listViewView.Name = "listViewView";
            this.listViewView.Size = new System.Drawing.Size(303, 448);
            this.listViewView.TabIndex = 0;
            this.listViewView.UseCompatibleStateImageBehavior = false;
            this.listViewView.View = System.Windows.Forms.View.Details;
            // 
            // columnViewName
            // 
            this.columnViewName.Text = "View Name";
            this.columnViewName.Width = 300;
            // 
            // listViewSelect
            // 
            this.listViewSelect.CheckBoxes = true;
            this.listViewSelect.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnViewSelect});
            this.listViewSelect.Location = new System.Drawing.Point(425, 25);
            this.listViewSelect.Name = "listViewSelect";
            this.listViewSelect.Size = new System.Drawing.Size(304, 448);
            this.listViewSelect.TabIndex = 1;
            this.listViewSelect.UseCompatibleStateImageBehavior = false;
            this.listViewSelect.View = System.Windows.Forms.View.Details;
            // 
            // columnViewSelect
            // 
            this.columnViewSelect.Text = "View Selection";
            this.columnViewSelect.Width = 300;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(334, 142);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 29);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(334, 187);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 29);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(334, 230);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(75, 29);
            this.btnAssign.TabIndex = 6;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // listSheet
            // 
            this.listSheet.CheckBoxes = true;
            this.listSheet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnSheetNumber,
            this.columnSheetName});
            this.listSheet.Location = new System.Drawing.Point(747, 25);
            this.listSheet.Name = "listSheet";
            this.listSheet.Size = new System.Drawing.Size(316, 446);
            this.listSheet.TabIndex = 8;
            this.listSheet.UseCompatibleStateImageBehavior = false;
            this.listSheet.View = System.Windows.Forms.View.Details;
            this.listSheet.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listSheet_ItemCheck);
            this.listSheet.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listSheet_ItemChecked);
            this.listSheet.SelectedIndexChanged += new System.EventHandler(this.listSheet_SelectedIndexChanged);
            // 
            // columnSheetNumber
            // 
            this.columnSheetNumber.Text = "Sheet Number";
            this.columnSheetNumber.Width = 80;
            // 
            // columnSheetName
            // 
            this.columnSheetName.Text = "Sheet Name";
            this.columnSheetName.Width = 233;
            // 
            // frmAssignView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 499);
            this.Controls.Add(this.listSheet);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.listViewSelect);
            this.Controls.Add(this.listViewView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAssignView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAssignView";
            this.Load += new System.EventHandler(this.frmAssignView_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAssign;
        public System.Windows.Forms.ListView listSheet;
        private System.Windows.Forms.ColumnHeader columnSheetNumber;
        private System.Windows.Forms.ColumnHeader columnSheetName;
        public System.Windows.Forms.ListView listViewSelect;
        public System.Windows.Forms.ListView listViewView;
        private System.Windows.Forms.ColumnHeader columnViewName;
        private System.Windows.Forms.ColumnHeader columnViewSelect;
    }
}