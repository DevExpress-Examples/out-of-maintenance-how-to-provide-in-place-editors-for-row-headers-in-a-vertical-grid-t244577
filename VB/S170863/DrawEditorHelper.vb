Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraVerticalGrid.Events
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq

Namespace S170863
    Public NotInheritable Class DrawEditorHelper

        Private Sub New()
        End Sub

        Public Shared Sub DrawEdit(ByVal g As Graphics, ByVal edit As RepositoryItem, ByVal r As Rectangle, ByVal value As Object)
            Dim info As BaseEditViewInfo = edit.CreateViewInfo()
            info.EditValue = value
            info.Bounds = r
            info.CalcViewInfo(g)
            Dim args As New ControlGraphicsInfoArgs(info, New GraphicsCache(g), r)
            edit.CreatePainter().Draw(args)
            args.Cache.Dispose()
        End Sub

        Public Shared Sub DrawRowInplaceEditor(ByVal e As CustomDrawRowHeaderCellEventArgs, ByVal item As RepositoryItem, ByVal value As Object)
            Dim targetRect As Rectangle = e.Bounds
            DrawEdit(e.Graphics, item, targetRect, value)
        End Sub
    End Class
End Namespace
