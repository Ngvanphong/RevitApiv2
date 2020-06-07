namespace MainProjectApi.ViewSheetAsign
{
    partial class frmViewToSheet
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
            this.listViewSheetAssignView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.listViewViewAssignTo = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewSheetAssignView
            // 
            this.listViewSheetAssignView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSheetAssignView.CheckBoxes = true;
            this.listViewSheetAssignView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewSheetAssignView.Location = new System.Drawing.Point(496, 12);
            this.listViewSheetAssignView.Name = "listViewSheetAssignView";
            this.listViewSheetAssignView.Size = new System.Drawing.Size(360, 534);
            this.listViewSheetAssignView.TabIndex = 0;
            this.listViewSheetAssignView.UseCompatibleStateImageBehavior = false;
            this.listViewSheetAssignView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "SheetNumber";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 455;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(781, 552);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listViewViewAssignTo
            // 
            this.listViewViewAssignTo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewViewAssignTo.CheckBoxes = true;
            this.listViewViewAssignTo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listViewViewAssignTo.Location = new System.Drawing.Point(18, 12);
            this.listViewViewAssignTo.Name = "listViewViewAssignTo";
            this.listViewViewAssignTo.Size = new System.Drawing.Size(472, 534);
            this.listViewViewAssignTo.TabIndex = 2;
            this.listViewViewAssignTo.UseCompatibleStateImageBehavior = false;
            this.listViewViewAssignTo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ViewName";
            this.columnHeader3.Width = 1500;
            // 
            // frmViewToSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 594);
            this.Controls.Add(this.listViewViewAssignTo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listViewSheetAssignView);
            this.Name = "frmViewToSheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmViewToSheet";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmViewToSheet_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView listViewSheetAssignView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        public System.Windows.Forms.ListView listViewViewAssignTo;
    }
}