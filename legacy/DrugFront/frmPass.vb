Public Class frmPass

  Public pPassCode As String
  Public pPassName As String
  Public pPassPriv As String
  Public pOK As Boolean

  Private Sub frmLogIn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon
    pOK = False
  End Sub

  Private Sub textKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserName.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
    If txtUserName.Text.Length > 0 AndAlso txtUserPassword.Text.Length > 0 Then
      Dim mGet() As String
      mGet = pService.GetData("Drug", "SELECT emplCode, emplName, privCode FROM EmplInfo WHERE emplStat = '1' AND userName = '" & txtUserName.Text & "' AND userPWD = '" & txtUserPassword.Text & "'")
      If mGet(0) = "1" Then
        pPassCode = mGet(1)
        pPassName = mGet(2)
        pPassPriv = mGet(3)
        pOK = True
        Me.Close()
      Else
        MessageBox.Show("ชื่อ-รหัสผ่านไม่ถูกต้อง", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End If
      txtUserName.Text = ""
      txtUserPassword.Text = ""
      txtUserName.Focus()
    End If
  End Sub

  Private Sub frmPass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        Me.Close()
    End Select
  End Sub

  Private Sub txtUserPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserPassword.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      btnLogin.PerformClick()
      'SendKeys.Send("{Tab}")
    End If
  End Sub
End Class