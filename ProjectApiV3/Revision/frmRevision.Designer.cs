namespace ProjectApiV3.Revision
{
    partial class frmRevision
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewSheetInfor = new System.Windows.Forms.ListView();
            this.SheetNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewRevisionInfor = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExportRevision = new System.Windows.Forms.Button();
            this.btnRemoveRevision = new System.Windows.Forms.Button();
            this.btnAssignRevision = new System.Windows.Forms.Button();
            this.listViewSheetAssign = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewRevisionAssign = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.listViewSheetInfor);
            this.groupBox1.Controls.Add(this.listViewRevisionInfor);
            this.groupBox1.Location = new System.Drawing.Point(1, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 476);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Revision information";
            // 
            // listViewSheetInfor
            // 
            this.listViewSheetInfor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewSheetInfor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SheetNumber,
            this.columnHeader7,
            this.columnHeader2});
            this.listViewSheetInfor.Location = new System.Drawing.Point(252, 18);
            this.listViewSheetInfor.Name = "listViewSheetInfor";
            this.listViewSheetInfor.Size = new System.Drawing.Size(387, 451);
            this.listViewSheetInfor.TabIndex = 1;
            this.listViewSheetInfor.UseCompatibleStateImageBehavior = false;
            this.listViewSheetInfor.View = System.Windows.Forms.View.Details;
            // 
            // SheetNumber
            // 
            this.SheetNumber.Text = "Sheet Number";
            this.SheetNumber.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Revision Current";
            this.columnHeader7.Width = 119;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Sheet Name";
            this.columnHeader2.Width = 207;
            // 
            // listViewRevisionInfor
            // 
            this.listViewRevisionInfor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewRevisionInfor.CheckBoxes = true;
            this.listViewRevisionInfor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader6});
            this.listViewRevisionInfor.Location = new System.Drawing.Point(6, 18);
            this.listViewRevisionInfor.Name = "listViewRevisionInfor";
            this.listViewRevisionInfor.Size = new System.Drawing.Size(240, 451);
            this.listViewRevisionInfor.TabIndex = 0;
            this.listViewRevisionInfor.UseCompatibleStateImageBehavior = false;
            this.listViewRevisionInfor.View = System.Windows.Forms.View.Details;
            this.listViewRevisionInfor.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewRevisionInfor_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Revision";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Date";
            this.columnHeader6.Width = 150;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btnExportRevision);
            this.groupBox2.Controls.Add(this.btnRemoveRevision);
            this.groupBox2.Controls.Add(this.btnAssignRevision);
            this.groupBox2.Controls.Add(this.listViewSheetAssign);
            this.groupBox2.Controls.Add(this.listViewRevisionAssign);
            this.groupBox2.Location = new System.Drawing.Point(653, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(668, 476);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Assign or remove revision";
            // 
            // btnExportRevision
            // 
            this.btnExportRevision.Location = new System.Drawing.Point(176, 173);
            this.btnExportRevision.Name = "btnExportRevision";
            this.btnExportRevision.Size = new System.Drawing.Size(64, 36);
            this.btnExportRevision.TabIndex = 3;
            this.btnExportRevision.Text = "Export excel";
            this.btnExportRevision.UseVisualStyleBackColor = true;
            this.btnExportRevision.Click += new System.EventHandler(this.btnExportRevision_Click);
            // 
            // btnRemoveRevision
            // 
            this.btnRemoveRevision.Location = new System.Drawing.Point(175, 138);
            this.btnRemoveRevision.Name = "btnRemoveRevision";
            this.btnRemoveRevision.Size = new System.Drawing.Size(65, 28);
            this.btnRemoveRevision.TabIndex = 2;
            this.btnRemoveRevision.Text = "Remove";
            this.btnRemoveRevision.UseVisualStyleBackColor = true;
            this.btnRemoveRevision.Click += new System.EventHandler(this.btnRemoveRevision_Click);
            // 
            // btnAssignRevision
            // 
            this.btnAssignRevision.Location = new System.Drawing.Point(175, 104);
            this.btnAssignRevision.Name = "btnAssignRevision";
            this.btnAssignRevision.Size = new System.Drawing.Size(65, 28);
            this.btnAssignRevision.TabIndex = 2;
            this.btnAssignRevision.Text = "Assign";
            this.btnAssignRevision.UseVisualStyleBackColor = true;
            this.btnAssignRevision.Click += new System.EventHandler(this.btnAssignRevision_Click);
            // 
            // listViewSheetAssign
            // 
            this.listViewSheetAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSheetAssign.CheckBoxes = true;
            this.listViewSheetAssign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader8,
            this.columnHeader5});
            this.listViewSheetAssign.Location = new System.Drawing.Point(251, 18);
            this.listViewSheetAssign.Name = "listViewSheetAssign";
            this.listViewSheetAssign.Size = new System.Drawing.Size(411, 452);
            this.listViewSheetAssign.TabIndex = 1;
            this.listViewSheetAssign.UseCompatibleStateImageBehavior = false;
            this.listViewSheetAssign.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Sheet Number";
            this.columnHeader4.Width = 91;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Revision Current";
            this.columnHeader8.Width = 114;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Sheet Name";
            this.columnHeader5.Width = 1500;
            // 
            // listViewRevisionAssign
            // 
            this.listViewRevisionAssign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewRevisionAssign.CheckBoxes = true;
            this.listViewRevisionAssign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listViewRevisionAssign.Location = new System.Drawing.Point(7, 20);
            this.listViewRevisionAssign.Name = "listViewRevisionAssign";
            this.listViewRevisionAssign.Size = new System.Drawing.Size(158, 450);
            this.listViewRevisionAssign.TabIndex = 0;
            this.listViewRevisionAssign.UseCompatibleStateImageBehavior = false;
            this.listViewRevisionAssign.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Revision";
            this.columnHeader3.Width = 196;
            // 
            // frmRevision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 500);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRevision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRevision";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmRevision_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader SheetNumber;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        public System.Windows.Forms.ListView listViewRevisionInfor;
        public System.Windows.Forms.ListView listViewSheetInfor;
        public System.Windows.Forms.ListView listViewRevisionAssign;
        public System.Windows.Forms.Button btnRemoveRevision;
        public System.Windows.Forms.Button btnAssignRevision;
        public System.Windows.Forms.ListView listViewSheetAssign;
        public System.Windows.Forms.Button btnExportRevision;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}