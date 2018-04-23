Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraVerticalGrid
Imports DevExpress.XtraVerticalGrid.Events
Imports DevExpress.XtraVerticalGrid.Rows
Imports DevExpress.XtraVerticalGrid.ViewInfo
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Namespace S170863
    Public Class RowInplaceEditorHelper
        Private _Item As RepositoryItem
        Private _Row As BaseRow
        Private _VGrid As VGridControlBase

        Private _EditValue As Object
        Public Property EditValue() As Object
            Get
                Return _EditValue
            End Get
            Set(ByVal value As Object)
                _EditValue = value
            End Set
        End Property

        Private _ActiveEditor As BaseEdit
        Public Property ActiveEditor() As BaseEdit
            Get
                Return _ActiveEditor
            End Get
            Set(ByVal value As BaseEdit)
                _ActiveEditor = value
            End Set
        End Property

        Public Sub New(ByVal row As BaseRow, ByVal inplaceEditor As RepositoryItem)
            _Row = row
            _Item = inplaceEditor
            _VGrid = _Row.Grid
            AddHandler _VGrid.CustomDrawRowHeaderCell, AddressOf vGrid_CustomDrawRowHeaderCell
            AddHandler _VGrid.MouseDown, AddressOf vGrid_MouseDown
        End Sub

        Private Sub vGrid_CustomDrawRowHeaderCell(ByVal sender As Object, ByVal e As CustomDrawRowHeaderCellEventArgs)
            If e.Row Is _Row Then
                e.Caption = String.Empty
                e.Handled = True
                DrawEditorHelper.DrawRowInplaceEditor(e, _Item, EditValue)
            End If
        End Sub

        Private Sub vGrid_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            CloseEditor()
            Dim editorBounds As Rectangle = Nothing
            If ClickInEditor(e, editorBounds) Then
                ShowEditor(editorBounds)
                DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End Sub

        Private Function ClickInEditor(ByVal e As MouseEventArgs, ByRef editorBounds As Rectangle) As Boolean
            editorBounds = Rectangle.Empty
            Dim location As Point = e.Location
            Dim hitInfo As VGridHitInfo = _VGrid.CalcHitInfo(location)
            Dim viewInfo As BaseRowViewInfo = _VGrid.ViewInfo(location)
            If hitInfo.HitInfoType = HitInfoTypeEnum.HeaderCell AndAlso _Row Is viewInfo.Row Then
                editorBounds = viewInfo.HeaderInfo.HeaderCellsRect
                Return editorBounds.Contains(location)
            End If
            Return False
        End Function

        Private Sub ShowEditor(ByVal bounds As Rectangle)
            ActiveEditor = _Item.CreateEditor()
            ActiveEditor.Properties.LockEvents()
            ActiveEditor.Parent = _VGrid
            ActiveEditor.Properties.Assign(_Item)
            ActiveEditor.Properties.AutoHeight = False
            ActiveEditor.BackColor = _VGrid.ViewInfo.PaintAppearance.FocusedRow.BackColor
            ActiveEditor.Location = bounds.Location
            ActiveEditor.Size = bounds.Size
            ActiveEditor.CreateControl()
            ActiveEditor.EditValue = EditValue
            ActiveEditor.SendMouse(ActiveEditor.PointToClient(Control.MousePosition), Control.MouseButtons)
            ActiveEditor.Properties.UnLockEvents()
        End Sub

        Private Sub CloseEditor()
            If ActiveEditor IsNot Nothing Then
                EditValue = ActiveEditor.EditValue
                ActiveEditor.Dispose()
                ActiveEditor = Nothing
            End If
        End Sub
    End Class
End Namespace
