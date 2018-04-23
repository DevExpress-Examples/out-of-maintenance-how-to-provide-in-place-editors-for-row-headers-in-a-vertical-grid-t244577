using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraVerticalGrid.Rows;
using DevExpress.XtraVerticalGrid.ViewInfo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace S170863 {
    public class RowInplaceEditorHelper {
        private RepositoryItem _Item;
        private BaseRow _Row;
        private VGridControlBase _VGrid;

        private object _EditValue;
        public object EditValue {
            get { return _EditValue; }
            set { _EditValue = value; }
        }

        private BaseEdit _ActiveEditor;
        public BaseEdit ActiveEditor {
            get { return _ActiveEditor; }
            set { _ActiveEditor = value; }
        }

        public RowInplaceEditorHelper(BaseRow row, RepositoryItem inplaceEditor) {
            _Row = row;
            _Item = inplaceEditor;
            _VGrid = _Row.Grid;
            _VGrid.CustomDrawRowHeaderCell += vGrid_CustomDrawRowHeaderCell;
            _VGrid.MouseDown += vGrid_MouseDown;
        }

        void vGrid_CustomDrawRowHeaderCell(object sender, CustomDrawRowHeaderCellEventArgs e) {
            if(e.Row == _Row) {
                e.Caption = string.Empty;
                e.Handled = true;
                DrawEditorHelper.DrawRowInplaceEditor(e, _Item, EditValue);
            }
        }

        void vGrid_MouseDown(object sender, MouseEventArgs e) {
            CloseEditor();
            Rectangle editorBounds;
            if(ClickInEditor(e, out editorBounds)) {
                ShowEditor(editorBounds);
                DXMouseEventArgs.GetMouseArgs(e).Handled = true;
            }
        }

        private bool ClickInEditor(MouseEventArgs e, out Rectangle editorBounds) {
            editorBounds = Rectangle.Empty;
            Point location = e.Location;
            VGridHitInfo hitInfo = _VGrid.CalcHitInfo(location);
            BaseRowViewInfo viewInfo = _VGrid.ViewInfo[location];
            if(hitInfo.HitInfoType == HitInfoTypeEnum.HeaderCell && _Row == viewInfo.Row) {
                editorBounds = viewInfo.HeaderInfo.HeaderCellsRect;
                return editorBounds.Contains(location);
            }
            return false;
        }

        private void ShowEditor(Rectangle bounds) {
            ActiveEditor = _Item.CreateEditor();
            ActiveEditor.Properties.LockEvents();
            ActiveEditor.Parent = _VGrid;
            ActiveEditor.Properties.Assign(_Item);
            ActiveEditor.Properties.AutoHeight = false;
            ActiveEditor.BackColor = _VGrid.ViewInfo.PaintAppearance.FocusedRow.BackColor;
            ActiveEditor.Location = bounds.Location;
            ActiveEditor.Size = bounds.Size;
            ActiveEditor.CreateControl();
            ActiveEditor.EditValue = EditValue;
            ActiveEditor.SendMouse(ActiveEditor.PointToClient(Control.MousePosition), Control.MouseButtons);
            ActiveEditor.Properties.UnLockEvents();
        }

        private void CloseEditor() {
            if(ActiveEditor != null) {
                EditValue = ActiveEditor.EditValue;
                ActiveEditor.Dispose();
                ActiveEditor = null;
            }
        }
    }
}
