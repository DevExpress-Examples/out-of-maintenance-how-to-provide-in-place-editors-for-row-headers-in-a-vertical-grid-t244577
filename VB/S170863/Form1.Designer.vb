Namespace S170863
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.vGridControl1 = New DevExpress.XtraVerticalGrid.VGridControl()
            Me.row = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.row1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.row2 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.row3 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            DirectCast(Me.vGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' vGridControl1
            ' 
            Me.vGridControl1.Cursor = System.Windows.Forms.Cursors.SizeNS
            Me.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.vGridControl1.Location = New System.Drawing.Point(0, 0)
            Me.vGridControl1.Name = "vGridControl1"
            Me.vGridControl1.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() { Me.row, Me.row1, Me.row2, Me.row3})
            Me.vGridControl1.Size = New System.Drawing.Size(429, 261)
            Me.vGridControl1.TabIndex = 0
            ' 
            ' row
            ' 
            Me.row.Appearance.BackColor = System.Drawing.Color.White
            Me.row.Appearance.Options.UseBackColor = True
            Me.row.Name = "row"
            Me.row.Properties.Caption = "Name"
            Me.row.Properties.FieldName = "Name"
            ' 
            ' row1
            ' 
            Me.row1.Expanded = False
            Me.row1.Name = "row1"
            Me.row1.Properties.Caption = "ID"
            Me.row1.Properties.FieldName = "ID"
            ' 
            ' row2
            ' 
            Me.row2.Expanded = False
            Me.row2.Name = "row2"
            Me.row2.Properties.Caption = "Check"
            Me.row2.Properties.FieldName = "Check"
            ' 
            ' row3
            ' 
            Me.row3.Name = "row3"
            Me.row3.Properties.Caption = "Date"
            Me.row3.Properties.FieldName = "Date"
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(429, 261)
            Me.Controls.Add(Me.vGridControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            DirectCast(Me.vGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private vGridControl1 As DevExpress.XtraVerticalGrid.VGridControl
        Private row As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Private row1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Private row2 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Private row3 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    End Class
End Namespace

