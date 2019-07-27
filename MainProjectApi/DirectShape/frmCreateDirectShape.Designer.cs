namespace MainProjectApi.DirectShape
{
    partial class frmCreateDirectShape
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
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.dropProfileShape = new System.Windows.Forms.ComboBox();
            this.dataGridPointImport = new System.Windows.Forms.DataGridView();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.btnSelectPoint = new System.Windows.Forms.Button();
            this.btnCreateShape = new System.Windows.Forms.Button();
            this.pointX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPointImport)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profile";
            // 
            // dropProfileShape
            // 
            this.dropProfileShape.FormattingEnabled = true;
            this.dropProfileShape.Location = new System.Drawing.Point(88, 31);
            this.dropProfileShape.Name = "dropProfileShape";
            this.dropProfileShape.Size = new System.Drawing.Size(227, 21);
            this.dropProfileShape.TabIndex = 1;
            // 
            // dataGridPointImport
            // 
            this.dataGridPointImport.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridPointImport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pointX,
            this.pointY,
            this.pointZ});
            this.dataGridPointImport.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.dataGridPointImport.Location = new System.Drawing.Point(88, 69);
            this.dataGridPointImport.Name = "dataGridPointImport";
            this.dataGridPointImport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridPointImport.Size = new System.Drawing.Size(644, 156);
            this.dataGridPointImport.TabIndex = 2;
            this.dataGridPointImport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPointImport_CellContentClick);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Location = new System.Drawing.Point(372, 23);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(119, 34);
            this.btnImportExcel.TabIndex = 3;
            this.btnImportExcel.Text = "Import Execel";
            this.btnImportExcel.UseVisualStyleBackColor = true;
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Location = new System.Drawing.Point(412, 264);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(95, 39);
            this.btnSaveFile.TabIndex = 4;
            this.btnSaveFile.Text = "SaveFile";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            // 
            // btnSelectPoint
            // 
            this.btnSelectPoint.Location = new System.Drawing.Point(526, 264);
            this.btnSelectPoint.Name = "btnSelectPoint";
            this.btnSelectPoint.Size = new System.Drawing.Size(95, 39);
            this.btnSelectPoint.TabIndex = 5;
            this.btnSelectPoint.Text = "SelectPoint";
            this.btnSelectPoint.UseVisualStyleBackColor = true;
            // 
            // btnCreateShape
            // 
            this.btnCreateShape.Location = new System.Drawing.Point(637, 264);
            this.btnCreateShape.Name = "btnCreateShape";
            this.btnCreateShape.Size = new System.Drawing.Size(95, 39);
            this.btnCreateShape.TabIndex = 6;
            this.btnCreateShape.Text = "Create";
            this.btnCreateShape.UseVisualStyleBackColor = true;
            // 
            // pointX
            // 
            this.pointX.HeaderText = "X";
            this.pointX.Name = "pointX";
            this.pointX.Width = 150;
            // 
            // pointY
            // 
            this.pointY.HeaderText = "Y";
            this.pointY.Name = "pointY";
            this.pointY.Width = 150;
            // 
            // pointZ
            // 
            this.pointZ.HeaderText = "Z";
            this.pointZ.Name = "pointZ";
            this.pointZ.Width = 150;
            // 
            // frmCreateDirectShape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 329);
            this.Controls.Add(this.btnCreateShape);
            this.Controls.Add(this.btnSelectPoint);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.btnImportExcel);
            this.Controls.Add(this.dataGridPointImport);
            this.Controls.Add(this.dropProfileShape);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreateDirectShape";
            this.Text = "frmCreateDirectShape";
            this.Load += new System.EventHandler(this.frmCreateDirectShape_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPointImport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox dropProfileShape;
        private System.Windows.Forms.DataGridView dataGridPointImport;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnSelectPoint;
        private System.Windows.Forms.Button btnCreateShape;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointX;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointY;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointZ;
    }
}