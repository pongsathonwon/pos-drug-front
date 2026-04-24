<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewReport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.ctrView = New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Me.SuspendLayout()
    '
    'ctrView
    '
    Me.ctrView.ActiveViewIndex = -1
    Me.ctrView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.ctrView.Cursor = System.Windows.Forms.Cursors.Default
    Me.ctrView.DisplayGroupTree = False
    Me.ctrView.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ctrView.Location = New System.Drawing.Point(0, 0)
    Me.ctrView.Name = "ctrView"
    Me.ctrView.SelectionFormula = ""
    Me.ctrView.ShowGroupTreeButton = False
    Me.ctrView.ShowRefreshButton = False
    Me.ctrView.Size = New System.Drawing.Size(884, 461)
    Me.ctrView.TabIndex = 1
    Me.ctrView.ViewTimeSelectionFormula = ""
    '
    'frmViewReport
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(884, 461)
    Me.Controls.Add(Me.ctrView)
    Me.Name = "frmViewReport"
    Me.ShowInTaskbar = False
    Me.Text = "รายงาน"
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents ctrView As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
