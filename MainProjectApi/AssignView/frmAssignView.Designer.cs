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
            this.checkBoxFixPosition = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSheetNumber = new System.Windows.Forms.TextBox();
            this.checkBoxFixPositionNotBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listViewView
            // 
            this.listViewView.CheckBoxes = true;
            this.listViewView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnViewName});
            this.listViewView.Location = new System.Drawing.Point(12, 25);
            this.listViewView.Name = "listViewView";
            this.listViewView.Size = new System.Drawing.Size(355, 448);
            this.listViewView.TabIndex = 0;
            this.listViewView.UseCompatibleStateImageBehavior = false;
            this.listViewView.View = System.Windows.Forms.View.Details;
            // 
            // columnViewName
            // 
            this.columnViewName.Text = "View Name";
            this.columnViewName.Width = 350;
            // 
            // listViewSelect
            // 
            this.listViewSelect.CheckBoxes = true;
            this.listViewSelect.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnViewSelect});
            this.listViewSelect.Location = new System.Drawing.Point(462, 25);
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
            this.btnSelect.Location = new System.Drawing.Point(377, 142);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 29);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(377, 187);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 29);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(377, 230);
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
            this.listSheet.Location = new System.Drawing.Point(784, 96);
            this.listSheet.Name = "listSheet";
            this.listSheet.Size = new System.Drawing.Size(292, 375);
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
            this.columnSheetName.Width = 207;
            // 
            // checkBoxFixPosition
            // 
            this.checkBoxFixPosition.AutoSize = true;
            this.checkBoxFixPosition.Location = new System.Drawing.Point(784, 25);
            this.checkBoxFixPosition.Name = "checkBoxFixPosition";
            this.checkBoxFixPosition.Size = new System.Drawing.Size(214, 17);
            this.checkBoxFixPosition.TabIndex = 9;
            this.checkBoxFixPosition.Text = "Fix position and crop box similar for view";
            this.checkBoxFixPosition.UseVisualStyleBackColor = true;
            this.checkBoxFixPosition.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.checkBoxFixPosition.Click += new System.EventHandler(this.checkBoxFixPosition_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(781, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Sheet Number Start";
            // 
            // txtSheetNumber
            // 
            this.txtSheetNumber.Location = new System.Drawing.Point(887, 70);
            this.txtSheetNumber.Name = "txtSheetNumber";
            this.txtSheetNumber.Size = new System.Drawing.Size(186, 20);
            this.txtSheetNumber.TabIndex = 11;
            // 
            // checkBoxFixPositionNotBox
            // 
            this.checkBoxFixPositionNotBox.AutoSize = true;
            this.checkBoxFixPositionNotBox.Location = new System.Drawing.Point(784, 49);
            this.checkBoxFixPositionNotBox.Name = "checkBoxFixPositionNotBox";
            this.checkBoxFixPositionNotBox.Size = new System.Drawing.Size(171, 17);
            this.checkBoxFixPositionNotBox.TabIndex = 12;
            this.checkBoxFixPositionNotBox.Text = "Fix position but not fix crop box";
            this.checkBoxFixPositionNotBox.UseVisualStyleBackColor = true;
            this.checkBoxFixPositionNotBox.CheckedChanged += new System.EventHandler(this.checkBoxFixPositionNotBox_CheckedChanged);
            this.checkBoxFixPositionNotBox.Click += new System.EventHandler(this.checkBoxFixPositionNotBox_Click);
            // 
            // frmAssignView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 499);
            this.Controls.Add(this.checkBoxFixPositionNotBox);
            this.Controls.Add(this.txtSheetNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxFixPosition);
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
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAssignView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        public System.Windows.Forms.CheckBox checkBoxFixPosition;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtSheetNumber;
        public System.Windows.Forms.CheckBox checkBoxFixPositionNotBox;
    }
}