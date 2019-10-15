namespace MainProjectApi.LegendSheet
{
    partial class frmLegendToSheet
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
            this.listViewLegend = new System.Windows.Forms.ListView();
            this.columnLegendName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewSheetSimilar = new System.Windows.Forms.ListView();
            this.columnSheetNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSheetName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.listViewSheet = new System.Windows.Forms.ListView();
            this.columnSheetNumberChose = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSheetNameChose = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAssignLegend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewLegend
            // 
            this.listViewLegend.CheckBoxes = true;
            this.listViewLegend.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnLegendName});
            this.listViewLegend.Location = new System.Drawing.Point(12, 40);
            this.listViewLegend.Name = "listViewLegend";
            this.listViewLegend.Size = new System.Drawing.Size(254, 458);
            this.listViewLegend.TabIndex = 0;
            this.listViewLegend.UseCompatibleStateImageBehavior = false;
            this.listViewLegend.View = System.Windows.Forms.View.Details;
            // 
            // columnLegendName
            // 
            this.columnLegendName.Text = "Legend Name";
            this.columnLegendName.Width = 250;
            // 
            // listViewSheetSimilar
            // 
            this.listViewSheetSimilar.CheckBoxes = true;
            this.listViewSheetSimilar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnSheetNumber,
            this.columnSheetName});
            this.listViewSheetSimilar.Location = new System.Drawing.Point(659, 40);
            this.listViewSheetSimilar.Name = "listViewSheetSimilar";
            this.listViewSheetSimilar.Size = new System.Drawing.Size(284, 458);
            this.listViewSheetSimilar.TabIndex = 1;
            this.listViewSheetSimilar.UseCompatibleStateImageBehavior = false;
            this.listViewSheetSimilar.View = System.Windows.Forms.View.Details;
            this.listViewSheetSimilar.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listViewSheetSimilar_ItemCheck);
            this.listViewSheetSimilar.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewSheetSimilar_ItemChecked);
            // 
            // columnSheetNumber
            // 
            this.columnSheetNumber.Text = "Sheet Number";
            this.columnSheetNumber.Width = 80;
            // 
            // columnSheetName
            // 
            this.columnSheetName.Text = "Sheet Name";
            this.columnSheetName.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(656, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chose legend of sheet similar";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // listViewSheet
            // 
            this.listViewSheet.CheckBoxes = true;
            this.listViewSheet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnSheetNumberChose,
            this.columnSheetNameChose});
            this.listViewSheet.Location = new System.Drawing.Point(345, 40);
            this.listViewSheet.Name = "listViewSheet";
            this.listViewSheet.Size = new System.Drawing.Size(286, 458);
            this.listViewSheet.TabIndex = 3;
            this.listViewSheet.UseCompatibleStateImageBehavior = false;
            this.listViewSheet.View = System.Windows.Forms.View.Details;
            // 
            // columnSheetNumberChose
            // 
            this.columnSheetNumberChose.Text = "Sheet Number";
            this.columnSheetNumberChose.Width = 80;
            // 
            // columnSheetNameChose
            // 
            this.columnSheetNameChose.Text = "Sheet Name";
            this.columnSheetNameChose.Width = 200;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chose legends to sheet";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Chose sheets to apply legend";
            // 
            // btnAssignLegend
            // 
            this.btnAssignLegend.Location = new System.Drawing.Point(272, 180);
            this.btnAssignLegend.Name = "btnAssignLegend";
            this.btnAssignLegend.Size = new System.Drawing.Size(67, 30);
            this.btnAssignLegend.TabIndex = 6;
            this.btnAssignLegend.Text = "Assign";
            this.btnAssignLegend.UseVisualStyleBackColor = true;
            this.btnAssignLegend.Click += new System.EventHandler(this.btnAssignLegend_Click);
            // 
            // frmLegendToSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 512);
            this.Controls.Add(this.btnAssignLegend);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listViewSheet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewSheetSimilar);
            this.Controls.Add(this.listViewLegend);
            this.MaximizeBox = false;
            this.Name = "frmLegendToSheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLegendToSheet";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmLegendToSheet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ColumnHeader columnLegendName;
        private System.Windows.Forms.ColumnHeader columnSheetNumber;
        private System.Windows.Forms.ColumnHeader columnSheetName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ListView listViewLegend;
        public System.Windows.Forms.ListView listViewSheetSimilar;
        public System.Windows.Forms.ListView listViewSheet;
        private System.Windows.Forms.ColumnHeader columnSheetNumberChose;
        private System.Windows.Forms.ColumnHeader columnSheetNameChose;
        public System.Windows.Forms.Button btnAssignLegend;
    }
}