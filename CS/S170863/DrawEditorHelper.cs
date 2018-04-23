using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraVerticalGrid.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace S170863 {
    public static class DrawEditorHelper {
        public static void DrawEdit(Graphics g, RepositoryItem edit, Rectangle r, object value) {
            BaseEditViewInfo info = edit.CreateViewInfo();
            info.EditValue = value;
            info.Bounds = r;
            info.CalcViewInfo(g);
            ControlGraphicsInfoArgs args = new ControlGraphicsInfoArgs(info, new GraphicsCache(g), r);
            edit.CreatePainter().Draw(args);
            args.Cache.Dispose();
        }

        public static void DrawRowInplaceEditor(CustomDrawRowHeaderCellEventArgs e, RepositoryItem item, object value) {
            Rectangle targetRect = e.Bounds;
            DrawEdit(e.Graphics, item, targetRect, value);
        }
    }
}
