Public Class frmViewReport

  Public pTitle As String

  Private Sub frmViewReport_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    Me.WindowState = FormWindowState.Normal
  End Sub

  Private Sub frmViewReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon
    Me.Text = pTitle
  End Sub
End Class