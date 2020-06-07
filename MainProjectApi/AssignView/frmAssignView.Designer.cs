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
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewView
            // 
            this.listViewView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewView.CheckBoxes = true;
            this.listViewView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnViewName});
            this.listViewView.Location = new System.Drawing.Point(12, 25);
            this.listViewView.Name = "listViewView";
            this.listViewView.Size = new System.Drawing.Size(470, 526);
            this.listViewView.TabIndex = 0;
            this.listViewView.UseCompatibleStateImageBehavior = false;
            this.listViewView.View = System.Windows.Forms.View.Details;
            // 
            // columnViewName
            // 
            this.columnViewName.Text = "View Name";
            this.columnViewName.Width = 1500;
            // 
            // listViewSelect
            // 
            this.listViewSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSelect.CheckBoxes = true;
            this.listViewSelect.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnViewSelect});
            this.listViewSelect.Location = new System.Drawing.Point(569, 25);
            this.listViewSelect.Name = "listViewSelect";
            this.listViewSelect.Size = new System.Drawing.Size(344, 526);
            this.listViewSelect.TabIndex = 1;
            this.listViewSelect.UseCompatibleStateImageBehavior = false;
            this.listViewSelect.View = System.Windows.Forms.View.Details;
            // 
            // columnViewSelect
            // 
            this.columnViewSelect.Text = "View Selection";
            this.columnViewSelect.Width = 1500;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(488, 140);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 29);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(488, 185);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 29);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssign.Location = new System.Drawing.Point(488, 228);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(75, 29);
            this.btnAssign.TabIndex = 6;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // listSheet
            // 
            this.listSheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listSheet.CheckBoxes = true;
            this.listSheet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnSheetNumber,
            this.columnSheetName});
            this.listSheet.Location = new System.Drawing.Point(931, 118);
            this.listSheet.Name = "listSheet";
            this.listSheet.Size = new System.Drawing.Size(292, 431);
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
            this.checkBoxFixPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxFixPosition.AutoSize = true;
            this.checkBoxFixPosition.Location = new System.Drawing.Point(931, 25);
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
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(928, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Sheet Number Start";
            // 
            // txtSheetNumber
            // 
            this.txtSheetNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSheetNumber.Location = new System.Drawing.Point(1034, 70);
            this.txtSheetNumber.Name = "txtSheetNumber";
            this.txtSheetNumber.Size = new System.Drawing.Size(186, 20);
            this.txtSheetNumber.TabIndex = 11;
            // 
            // checkBoxFixPositionNotBox
            // 
            this.checkBoxFixPositionNotBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxFixPositionNotBox.AutoSize = true;
            this.checkBoxFixPositionNotBox.Location = new System.Drawing.Point(931, 48);
            this.checkBoxFixPositionNotBox.Name = "checkBoxFixPositionNotBox";
            this.checkBoxFixPositionNotBox.Size = new System.Drawing.Size(171, 17);
            this.checkBoxFixPositionNotBox.TabIndex = 12;
            this.checkBoxFixPositionNotBox.Text = "Fix position but not fix crop box";
            this.checkBoxFixPositionNotBox.UseVisualStyleBackColor = true;
            this.checkBoxFixPositionNotBox.CheckedChanged += new System.EventHandler(this.checkBoxFixPositionNotBox_CheckedChanged);
            this.checkBoxFixPositionNotBox.Click += new System.EventHandler(this.checkBoxFixPositionNotBox_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(928, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Choose a sheet similar:";
            // 
            // frmAssignView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 577);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
    }
}