namespace ProjectApiV3.RevisionCloud
{
    partial class frmRevisionCloud
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
            this.listViewRevisionCloud = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSelectRevisionCloud = new System.Windows.Forms.Button();
            this.checkBoxCheckAllRevisionCloud = new System.Windows.Forms.CheckBox();
            this.btnReloadRevisionCloud = new System.Windows.Forms.Button();
            this.dropChooseFilterCloud = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewRevisionCloud
            // 
            this.listViewRevisionCloud.CheckBoxes = true;
            this.listViewRevisionCloud.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listViewRevisionCloud.Location = new System.Drawing.Point(12, 42);
            this.listViewRevisionCloud.Name = "listViewRevisionCloud";
            this.listViewRevisionCloud.Size = new System.Drawing.Size(1146, 352);
            this.listViewRevisionCloud.TabIndex = 0;
            this.listViewRevisionCloud.UseCompatibleStateImageBehavior = false;
            this.listViewRevisionCloud.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Revision Number";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Revision Date";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Issued By";
            this.columnHeader3.Width = 110;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Issued To";
            this.columnHeader4.Width = 110;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Sheet Number";
            this.columnHeader5.Width = 110;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Sheet Name";
            this.columnHeader6.Width = 264;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Commnents";
            this.columnHeader7.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Mark";
            this.columnHeader8.Width = 200;
            // 
            // btnSelectRevisionCloud
            // 
            this.btnSelectRevisionCloud.Location = new System.Drawing.Point(13, 5);
            this.btnSelectRevisionCloud.Name = "btnSelectRevisionCloud";
            this.btnSelectRevisionCloud.Size = new System.Drawing.Size(75, 31);
            this.btnSelectRevisionCloud.TabIndex = 1;
            this.btnSelectRevisionCloud.Text = "Select";
            this.btnSelectRevisionCloud.UseVisualStyleBackColor = true;
            this.btnSelectRevisionCloud.Click += new System.EventHandler(this.btnSelectRevisionCloud_Click);
            // 
            // checkBoxCheckAllRevisionCloud
            // 
            this.checkBoxCheckAllRevisionCloud.AutoSize = true;
            this.checkBoxCheckAllRevisionCloud.Location = new System.Drawing.Point(96, 13);
            this.checkBoxCheckAllRevisionCloud.Name = "checkBoxCheckAllRevisionCloud";
            this.checkBoxCheckAllRevisionCloud.Size = new System.Drawing.Size(71, 17);
            this.checkBoxCheckAllRevisionCloud.TabIndex = 2;
            this.checkBoxCheckAllRevisionCloud.Text = "Check All";
            this.checkBoxCheckAllRevisionCloud.UseVisualStyleBackColor = true;
            // 
            // btnReloadRevisionCloud
            // 
            this.btnReloadRevisionCloud.Location = new System.Drawing.Point(172, 5);
            this.btnReloadRevisionCloud.Name = "btnReloadRevisionCloud";
            this.btnReloadRevisionCloud.Size = new System.Drawing.Size(75, 31);
            this.btnReloadRevisionCloud.TabIndex = 3;
            this.btnReloadRevisionCloud.Text = "Reload";
            this.btnReloadRevisionCloud.UseVisualStyleBackColor = true;
            this.btnReloadRevisionCloud.Click += new System.EventHandler(this.btnReloadRevisionCloud_Click);
            // 
            // dropChooseFilterCloud
            // 
            this.dropChooseFilterCloud.FormattingEnabled = true;
            this.dropChooseFilterCloud.Location = new System.Drawing.Point(303, 9);
            this.dropChooseFilterCloud.Name = "dropChooseFilterCloud";
            this.dropChooseFilterCloud.Size = new System.Drawing.Size(184, 21);
            this.dropChooseFilterCloud.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filter:";
            // 
            // frmRevisionCloud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 406);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dropChooseFilterCloud);
            this.Controls.Add(this.btnReloadRevisionCloud);
            this.Controls.Add(this.checkBoxCheckAllRevisionCloud);
            this.Controls.Add(this.btnSelectRevisionCloud);
            this.Controls.Add(this.listViewRevisionCloud);
            this.MaximizeBox = false;
            this.Name = "frmRevisionCloud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRevisionCloud";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmRevisionCloud_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        public System.Windows.Forms.Button btnSelectRevisionCloud;
        public System.Windows.Forms.CheckBox checkBoxCheckAllRevisionCloud;
        public System.Windows.Forms.Button btnReloadRevisionCloud;
        public System.Windows.Forms.ListView listViewRevisionCloud;
        public System.Windows.Forms.ComboBox dropChooseFilterCloud;
        private System.Windows.Forms.Label label1;
    }
}