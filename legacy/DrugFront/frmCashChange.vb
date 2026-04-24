Public Class frmCashChange
  Public pReturn As Double

  Private Sub frmReturn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Me.Close()
  End Sub

  Private Sub frmSalePay_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    lblReturn.Text = pReturn.ToString("#,##0.00")
  End Sub

End Class