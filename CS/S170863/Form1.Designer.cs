namespace S170863 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.row = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // vGridControl1
            // 
            this.vGridControl1.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.Location = new System.Drawing.Point(0, 0);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.row,
            this.row1,
            this.row2,
            this.row3});
            this.vGridControl1.Size = new System.Drawing.Size(429, 261);
            this.vGridControl1.TabIndex = 0;
            // 
            // row
            // 
            this.row.Appearance.BackColor = System.Drawing.Color.White;
            this.row.Appearance.Options.UseBackColor = true;
            this.row.Name = "row";
            this.row.Properties.Caption = "Name";
            this.row.Properties.FieldName = "Name";
            // 
            // row1
            // 
            this.row1.Expanded = false;
            this.row1.Name = "row1";
            this.row1.Properties.Caption = "ID";
            this.row1.Properties.FieldName = "ID";
            // 
            // row2
            // 
            this.row2.Expanded = false;
            this.row2.Name = "row2";
            this.row2.Properties.Caption = "Check";
            this.row2.Properties.FieldName = "Check";
            // 
            // row3
            // 
            this.row3.Name = "row3";
            this.row3.Properties.Caption = "Date";
            this.row3.Properties.FieldName = "Date";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 261);
            this.Controls.Add(this.vGridControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row2;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row3;
    }
}

