Public Class frmLogIn
  Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call

  End Sub

  'Form overrides dispose to clean up the component list.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents btnLogin As System.Windows.Forms.Button
  Friend WithEvents txtUserPassword As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtUserName As System.Windows.Forms.TextBox
  Friend WithEvents lblAppName As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.lblAppName = New System.Windows.Forms.Label
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.btnLogin = New System.Windows.Forms.Button
    Me.txtUserPassword = New System.Windows.Forms.TextBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.txtUserName = New System.Windows.Forms.TextBox
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SuspendLayout()
    '
    'lblAppName
    '
    Me.lblAppName.BackColor = System.Drawing.Color.Red
    Me.lblAppName.Dock = System.Windows.Forms.DockStyle.Fill
    Me.lblAppName.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblAppName.Location = New System.Drawing.Point(0, 0)
    Me.lblAppName.Name = "lblAppName"
    Me.lblAppName.Size = New System.Drawing.Size(283, 32)
    Me.lblAppName.TabIndex = 4
    Me.lblAppName.Text = "DrugPOS"
    Me.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer1.IsSplitterFixed = True
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer1.Name = "SplitContainer1"
    Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
    Me.SplitContainer1.Panel1.Controls.Add(Me.lblAppName)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.btnLogin)
    Me.SplitContainer1.Panel2.Controls.Add(Me.txtUserPassword)
    Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
    Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
    Me.SplitContainer1.Panel2.Controls.Add(Me.txtUserName)
    Me.SplitContainer1.Size = New System.Drawing.Size(283, 199)
    Me.SplitContainer1.SplitterDistance = 32
    Me.SplitContainer1.TabIndex = 5
    Me.SplitContainer1.TabStop = False
    '
    'btnLogin
    '
    Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
    Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.btnLogin.ForeColor = System.Drawing.SystemColors.ControlText
    Me.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.btnLogin.Location = New System.Drawing.Point(110, 110)
    Me.btnLogin.Name = "btnLogin"
    Me.btnLogin.Size = New System.Drawing.Size(80, 28)
    Me.btnLogin.TabIndex = 2
    Me.btnLogin.Text = "Ok"
    '
    'txtUserPassword
    '
    Me.txtUserPassword.Location = New System.Drawing.Point(128, 56)
    Me.txtUserPassword.Name = "txtUserPassword"
    Me.txtUserPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.txtUserPassword.Size = New System.Drawing.Size(90, 23)
    Me.txtUserPassword.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label4.Location = New System.Drawing.Point(52, 32)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(70, 16)
    Me.Label4.TabIndex = 0
    Me.Label4.Text = "User name"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label3.Location = New System.Drawing.Point(52, 59)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(63, 16)
    Me.Label3.TabIndex = 2
    Me.Label3.Text = "Password"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtUserName
    '
    Me.txtUserName.Location = New System.Drawing.Point(128, 29)
    Me.txtUserName.Name = "txtUserName"
    Me.txtUserName.Size = New System.Drawing.Size(90, 23)
    Me.txtUserName.TabIndex = 0
    '
    'frmLogIn
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(283, 199)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmLogIn"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Log in"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.Panel2.PerformLayout()
    Me.SplitContainer1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region
  Public pLogIn As Boolean

  Private Sub frmLogIn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon
    lblAppName.Text = pAppName
    lblAppName.BackColor = frmMain.lblBranchName.BackColor

    pLogIn = False
  End Sub

  Private Sub textKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserName.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
    If txtUserName.Text.Length > 0 AndAlso txtUserPassword.Text.Length > 0 Then
      Me.Cursor = Cursors.WaitCursor
      ' อนุญาตให้เข้าใช้งานเฉพาะ ผู้จัดการและพนักงานบัญชี
      Dim mGet() As String
      mGet = pService.GetData("Drug", "SELECT EI.emplCode, EI.emplName, EI.emplID, EI.privCode, EP.emplPosiName FROM EmplInfo EI inner join EmplPosition EP on EP.emplPosiCode = EI.emplPosiCode WHERE EI.emplStat = '1' AND EI.userName = '" & txtUserName.Text & "' AND EI.userPWD = '" & txtUserPassword.Text & "'")
      Me.Cursor = Cursors.Default
      If mGet(0) = "1" Then
        If InStr(mGet(4), pProgCode) = 0 Then
          pMessageBox = New MyMessageBox("ท่านไม่ได้รับอนุญาตให้เข้าใช้งาน", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
          pMessageBox.ShowDialog()
        Else
          pUserCode = mGet(1)
          pUserName = RemoveNickName(mGet(2))
          pUserID = mGet(3)
          pUserPriv = mGet(4)
          pUserPosition = mGet(5)
          pLogIn = True

          ' บันทึกเวลา login ยกเว้น admin
          If pUserCode <> "5" Then
            ' ใช้วันที่และเวลาของ server
            pServerDateTime = pService.ServerDateTime
            pLogSession = pBranchCode & pUserCode & Format(pServerDateTime, "ddMMyyHHmmss")
            Dim mSqlText(1) As String
            mSqlText(0) = "INSERT INTO LogRecord (branchCode, logSession, logInDate, logInTime, emplCode, drugFrontVersion) VALUES ('" & pBranchCode & "', '" & pLogSession & "', '" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', '" & pUserCode & "', '" & Application.ProductVersion & "')"
            Dim mUpdate As String
            mUpdate = pService.UpdateData("Drug", mSqlText)
            If mUpdate <> "1" Then
              pMessageBox = New MyMessageBox("Cannot insert login time", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
              pMessageBox.ShowDialog()
              'MessageBox.Show("Cannot insert login time", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
          End If

          Me.Close()
        End If
      Else
        pMessageBox = New MyMessageBox("ชื่อ-รหัสผ่านไม่ถูกต้อง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        pMessageBox.ShowDialog()

        'If mGet(0) = "0" Then
        '  pMessageBox = New MyMessageBox("ชื่อ-รหัสผ่านไม่ถูกต้อง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '  pMessageBox.ShowDialog()
        'Else
        '  pMessageBox = New MyMessageBox(mGet(1), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '  pMessageBox.ShowDialog()
        'End If
    End If
      txtUserName.Text = ""
      txtUserPassword.Text = ""
      txtUserName.Focus()
    End If
  End Sub

  Private Sub txtUserPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserPassword.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      btnLogin.PerformClick()
      'SendKeys.Send("{Tab}")
    End If
  End Sub
End Class
