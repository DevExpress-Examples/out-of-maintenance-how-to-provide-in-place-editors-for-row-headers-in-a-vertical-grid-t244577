using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraVerticalGrid.Rows;
using DevExpress.XtraVerticalGrid.ViewInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace S170863 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            vGridControl1.DataSource = CreateTable(6);
            RepositoryItemCheckEdit riCheckEdit = new RepositoryItemCheckEdit();
            new RowInplaceEditorHelper(vGridControl1.GetRowByFieldName("Check"), riCheckEdit);
            riCheckEdit.AllowFocused = false;
            riCheckEdit.EditValueChanged += riCheckEdit_EditValueChanged;
            RepositoryItemColorEdit riColorEdit = new RepositoryItemColorEdit();
            new RowInplaceEditorHelper(vGridControl1.GetRowByFieldName("Name"), riColorEdit);
            riColorEdit.ColorAlignment = HorzAlignment.Center;
            riColorEdit.EditValueChanged += riColorEdit_EditValueChanged;
        }

        void riColorEdit_EditValueChanged(object sender, EventArgs e) {
                vGridControl1.GetRowByFieldName("Name").Appearance.BackColor2 = (sender as ColorEdit).Color;
        }

        void riCheckEdit_EditValueChanged(object sender, EventArgs e) {
            for(int i = 0; i < vGridControl1.RecordCount; i++) 
                vGridControl1.SetCellValue(vGridControl1.GetRowByFieldName("Check"), i, (sender as CheckEdit).Checked);            
        }

        private DataTable CreateTable(int recordCount) {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Check", typeof(bool));
            dataTable.Columns.Add("Date", typeof(DateTime));
            for(int i = 0; i < recordCount; i++)
                dataTable.Rows.Add(new object[] { String.Format("Name{0}", i), i, (i % 2 == 1 ? true : false), DateTime.Now.AddDays(i) });
            return dataTable;
        }
    }
}