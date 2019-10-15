namespace MainProjectApi.DuplicateSheet
{
    partial class frmDuplicateSheet
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
            this.listViewSheet = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButtonDuplicatewithdetailing = new System.Windows.Forms.RadioButton();
            this.radioButtonDuplicate = new System.Windows.Forms.RadioButton();
            this.radioButtonDuplicateasdepending = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonSchechuleNone = new System.Windows.Forms.RadioButton();
            this.radioButtonScheduleYes = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonLegnedNone = new System.Windows.Forms.RadioButton();
            this.radioButtonLegendYes = new System.Windows.Forms.RadioButton();
            this.btnStartDuplicate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEndNumber = new System.Windows.Forms.TextBox();
            this.textBoxEndName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewSheet
            // 
            this.listViewSheet.CheckBoxes = true;
            this.listViewSheet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewSheet.Location = new System.Drawing.Point(12, 76);
            this.listViewSheet.Name = "listViewSheet";
            this.listViewSheet.Size = new System.Drawing.Size(421, 199);
            this.listViewSheet.TabIndex = 0;
            this.listViewSheet.UseCompatibleStateImageBehavior = false;
            this.listViewSheet.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sheet Number";
            this.columnHeader1.Width = 111;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Sheet Name";
            this.columnHeader2.Width = 309;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.listViewSheet);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 349);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View And Sheet";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButtonDuplicatewithdetailing);
            this.groupBox4.Controls.Add(this.radioButtonDuplicate);
            this.groupBox4.Controls.Add(this.radioButtonDuplicateasdepending);
            this.groupBox4.Location = new System.Drawing.Point(12, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(421, 47);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "View";
            // 
            // radioButtonDuplicatewithdetailing
            // 
            this.radioButtonDuplicatewithdetailing.AutoSize = true;
            this.radioButtonDuplicatewithdetailing.Checked = true;
            this.radioButtonDuplicatewithdetailing.Location = new System.Drawing.Point(13, 17);
            this.radioButtonDuplicatewithdetailing.Name = "radioButtonDuplicatewithdetailing";
            this.radioButtonDuplicatewithdetailing.Size = new System.Drawing.Size(134, 17);
            this.radioButtonDuplicatewithdetailing.TabIndex = 4;
            this.radioButtonDuplicatewithdetailing.TabStop = true;
            this.radioButtonDuplicatewithdetailing.Text = "Duplicate with detailing";
            this.radioButtonDuplicatewithdetailing.UseVisualStyleBackColor = true;
            // 
            // radioButtonDuplicate
            // 
            this.radioButtonDuplicate.AutoSize = true;
            this.radioButtonDuplicate.Location = new System.Drawing.Point(177, 17);
            this.radioButtonDuplicate.Name = "radioButtonDuplicate";
            this.radioButtonDuplicate.Size = new System.Drawing.Size(70, 17);
            this.radioButtonDuplicate.TabIndex = 5;
            this.radioButtonDuplicate.Text = "Duplicate";
            this.radioButtonDuplicate.UseVisualStyleBackColor = true;
            // 
            // radioButtonDuplicateasdepending
            // 
            this.radioButtonDuplicateasdepending.AutoSize = true;
            this.radioButtonDuplicateasdepending.Location = new System.Drawing.Point(268, 17);
            this.radioButtonDuplicateasdepending.Name = "radioButtonDuplicateasdepending";
            this.radioButtonDuplicateasdepending.Size = new System.Drawing.Size(147, 17);
            this.radioButtonDuplicateasdepending.TabIndex = 6;
            this.radioButtonDuplicateasdepending.Text = "Duplicate as a dependent";
            this.radioButtonDuplicateasdepending.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonSchechuleNone);
            this.groupBox3.Controls.Add(this.radioButtonScheduleYes);
            this.groupBox3.Location = new System.Drawing.Point(238, 281);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(195, 51);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Duplicate with schedule";
            // 
            // radioButtonSchechuleNone
            // 
            this.radioButtonSchechuleNone.AutoSize = true;
            this.radioButtonSchechuleNone.Location = new System.Drawing.Point(108, 19);
            this.radioButtonSchechuleNone.Name = "radioButtonSchechuleNone";
            this.radioButtonSchechuleNone.Size = new System.Drawing.Size(51, 17);
            this.radioButtonSchechuleNone.TabIndex = 1;
            this.radioButtonSchechuleNone.Text = "None";
            this.radioButtonSchechuleNone.UseVisualStyleBackColor = true;
            this.radioButtonSchechuleNone.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // radioButtonScheduleYes
            // 
            this.radioButtonScheduleYes.AutoSize = true;
            this.radioButtonScheduleYes.Checked = true;
            this.radioButtonScheduleYes.Location = new System.Drawing.Point(17, 19);
            this.radioButtonScheduleYes.Name = "radioButtonScheduleYes";
            this.radioButtonScheduleYes.Size = new System.Drawing.Size(43, 17);
            this.radioButtonScheduleYes.TabIndex = 0;
            this.radioButtonScheduleYes.TabStop = true;
            this.radioButtonScheduleYes.Text = "Yes";
            this.radioButtonScheduleYes.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonLegnedNone);
            this.groupBox2.Controls.Add(this.radioButtonLegendYes);
            this.groupBox2.Location = new System.Drawing.Point(12, 281);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 51);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Duplicate with legend";
            // 
            // radioButtonLegnedNone
            // 
            this.radioButtonLegnedNone.AutoSize = true;
            this.radioButtonLegnedNone.Location = new System.Drawing.Point(112, 19);
            this.radioButtonLegnedNone.Name = "radioButtonLegnedNone";
            this.radioButtonLegnedNone.Size = new System.Drawing.Size(51, 17);
            this.radioButtonLegnedNone.TabIndex = 1;
            this.radioButtonLegnedNone.Text = "None";
            this.radioButtonLegnedNone.UseVisualStyleBackColor = true;
            // 
            // radioButtonLegendYes
            // 
            this.radioButtonLegendYes.AutoSize = true;
            this.radioButtonLegendYes.Checked = true;
            this.radioButtonLegendYes.Location = new System.Drawing.Point(18, 19);
            this.radioButtonLegendYes.Name = "radioButtonLegendYes";
            this.radioButtonLegendYes.Size = new System.Drawing.Size(43, 17);
            this.radioButtonLegendYes.TabIndex = 0;
            this.radioButtonLegendYes.TabStop = true;
            this.radioButtonLegendYes.Text = "Yes";
            this.radioButtonLegendYes.UseVisualStyleBackColor = true;
            // 
            // btnStartDuplicate
            // 
            this.btnStartDuplicate.Location = new System.Drawing.Point(385, 370);
            this.btnStartDuplicate.Name = "btnStartDuplicate";
            this.btnStartDuplicate.Size = new System.Drawing.Size(89, 32);
            this.btnStartDuplicate.TabIndex = 5;
            this.btnStartDuplicate.Text = "Start";
            this.btnStartDuplicate.UseVisualStyleBackColor = true;
            this.btnStartDuplicate.Click += new System.EventHandler(this.btnStartDuplicate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "End Sheet Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 380);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "End Shhet Name:";
            // 
            // textBoxEndNumber
            // 
            this.textBoxEndNumber.Location = new System.Drawing.Point(114, 377);
            this.textBoxEndNumber.Name = "textBoxEndNumber";
            this.textBoxEndNumber.Size = new System.Drawing.Size(61, 20);
            this.textBoxEndNumber.TabIndex = 8;
            this.textBoxEndNumber.Text = ".1";
            // 
            // textBoxEndName
            // 
            this.textBoxEndName.Location = new System.Drawing.Point(270, 377);
            this.textBoxEndName.Name = "textBoxEndName";
            this.textBoxEndName.Size = new System.Drawing.Size(109, 20);
            this.textBoxEndName.TabIndex = 9;
            this.textBoxEndName.Text = "-Duplicate";
            // 
            // frmDuplicateSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 416);
            this.Controls.Add(this.textBoxEndName);
            this.Controls.Add(this.textBoxEndNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStartDuplicate);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frmDuplicateSheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDuplicateSheet";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmDuplicateSheet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ListView listViewSheet;
        public System.Windows.Forms.RadioButton radioButtonDuplicateasdepending;
        public System.Windows.Forms.RadioButton radioButtonDuplicate;
        public System.Windows.Forms.RadioButton radioButtonDuplicatewithdetailing;
        public System.Windows.Forms.RadioButton radioButtonLegnedNone;
        public System.Windows.Forms.RadioButton radioButtonLegendYes;
        public System.Windows.Forms.RadioButton radioButtonSchechuleNone;
        public System.Windows.Forms.RadioButton radioButtonScheduleYes;
        public System.Windows.Forms.Button btnStartDuplicate;
        public System.Windows.Forms.TextBox textBoxEndNumber;
        public System.Windows.Forms.TextBox textBoxEndName;
    }
}