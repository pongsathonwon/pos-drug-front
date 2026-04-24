Imports System.Text.RegularExpressions

Public Class frmChangePassword

  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    If txtOldName.Text = "" OrElse txtOldPassword.Text = "" OrElse txtNewName.Text = "" OrElse txtNewPassword.Text = "" Then
      MessageBox.Show("กรุณาป้อนข้อมูลให้ครบ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If

    Dim mOldName As String
    Dim mOldPassword As String
    Dim mGet() As String
    Me.Cursor = Cursors.WaitCursor
    mGet = pService.GetData("Drug", "Select userName, userPWD From EmplInfo Where emplCode = '" & pUserCode & "'")
    Me.Cursor = Cursors.Default
    If mGet(0) = "1" Then
      mOldName = mGet(1)
      mOldPassword = mGet(2)
    Else
      MessageBox.Show(mGet(0), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End If
    ' ตรวจสอบรหัสเดิม
    If txtOldName.Text <> mOldName OrElse txtOldPassword.Text <> mOldPassword Then
      MessageBox.Show("รหัสเดิมไม่ถูกต้อง", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Exit Sub
    End If
    ' ตรวจสอบตัวอักษรในข้อความ
    If TextIsValid(txtNewName.Text) = False OrElse TextIsValid(txtNewPassword.Text) = False Then
      MessageBox.Show("กรุณาใช้ตัวอักษรตามที่กำหนด", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Exit Sub
    End If
    ' ตรวจสอบรหัสซ้ำ
    Me.Cursor = Cursors.WaitCursor
    mGet = pService.GetData("Drug", "Select emplCode From EmplInfo Where userName = '" & txtNewName.Text & "' And emplCode <> '" & pUserCode & "'")
    Me.Cursor = Cursors.Default
    If mGet(0) = "1" Then
      MessageBox.Show("User Name ใหม่ มีผู้ใช้งานแล้ว", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Exit Sub
    End If

    If MessageBox.Show("ยืนยันเปลี่ยนแปลงข้อมูลรหัสผ่าน", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
      Dim mSqlText(1) As String
      mSqlText(0) = "Update EmplInfo set userName = '" & txtNewName.Text & "', userPWD = '" & txtNewPassword.Text & "' Where emplCode = '" & pUserCode & "'"
      Dim mUpdate As String
      mUpdate = pService.UpdateData("Drug", mSqlText)
      If mUpdate = "1" Then
        MessageBox.Show("เปลี่ยนแปลงข้อมูลรหัสผ่านเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
      Else
        MessageBox.Show(mUpdate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
    End If
  End Sub

  Private Sub txtOldName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOldName.KeyPress, txtOldPassword.KeyPress, txtNewName.KeyPress, txtNewPassword.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub frmChangePassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmLogIn.Icon
  End Sub
  ' function ตรวจสอบตัวอักษรในข้อความตามต้องการ
  Private Function TextIsValid(ByVal Text As String) As Boolean
    Dim mPattern As String = "^[A-Za-z0-9]+$" ' เฉพาะตัวอักษร a-z, A-Z และเลข 0-9
    Dim mReg As New Regex(mPattern)
    Return mReg.IsMatch(Text)
  End Function
End Class