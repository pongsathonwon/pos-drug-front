<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPass
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
    Me.components = New System.ComponentModel.Container
    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    Me.txtUserPassword = New System.Windows.Forms.TextBox
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.lblCompName = New System.Windows.Forms.Label
    Me.btnLogin = New System.Windows.Forms.Button
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtUserName = New System.Windows.Forms.TextBox
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Timer1
    '
    Me.Timer1.Interval = 5000
    '
    'txtUserPassword
    '
    Me.txtUserPassword.Location = New System.Drawing.Point(90, 46)
    Me.txtUserPassword.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.txtUserPassword.Name = "txtUserPassword"
    Me.txtUserPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.txtUserPassword.Size = New System.Drawing.Size(78, 21)
    Me.txtUserPassword.TabIndex = 1
    '
    'SplitContainer1
    '
    Me.SplitContainer1.BackColor = System.Drawing.SystemColors.Control
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.IsSplitterFixed = True
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer1.Name = "SplitContainer1"
    Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
    Me.SplitContainer1.Panel1.Controls.Add(Me.lblCompName)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.AliceBlue
    Me.SplitContainer1.Panel2.Controls.Add(Me.btnLogin)
    Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
    Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
    Me.SplitContainer1.Panel2.Controls.Add(Me.txtUserPassword)
    Me.SplitContainer1.Panel2.Controls.Add(Me.txtUserName)
    Me.SplitContainer1.Size = New System.Drawing.Size(243, 145)
    Me.SplitContainer1.SplitterDistance = 25
    Me.SplitContainer1.TabIndex = 6
    Me.SplitContainer1.TabStop = False
    '
    'lblCompName
    '
    Me.lblCompName.BackColor = System.Drawing.Color.CornflowerBlue
    Me.lblCompName.Dock = System.Windows.Forms.DockStyle.Fill
    Me.lblCompName.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblCompName.Location = New System.Drawing.Point(0, 0)
    Me.lblCompName.Name = "lblCompName"
    Me.lblCompName.Size = New System.Drawing.Size(243, 25)
    Me.lblCompName.TabIndex = 4
    Me.lblCompName.Text = "เฉพาะผู้มีสิทธิใช้งานเท่านั้น"
    Me.lblCompName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'btnLogin
    '
    Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
    Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.btnLogin.ForeColor = System.Drawing.SystemColors.ControlText
    Me.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.btnLogin.Location = New System.Drawing.Point(101, 73)
    Me.btnLogin.Name = "btnLogin"
    Me.btnLogin.Size = New System.Drawing.Size(48, 23)
    Me.btnLogin.TabIndex = 2
    Me.btnLogin.Text = "Ok"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label1.Location = New System.Drawing.Point(26, 23)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(58, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "User name"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label2.Location = New System.Drawing.Point(26, 49)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(53, 13)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "Password"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtUserName
    '
    Me.txtUserName.Location = New System.Drawing.Point(90, 20)
    Me.txtUserName.Name = "txtUserName"
    Me.txtUserName.Size = New System.Drawing.Size(78, 21)
    Me.txtUserName.TabIndex = 0
    '
    'frmPass
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(243, 145)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmPass"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "กรุณาแจ้งรหัสผ่าน"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.Panel2.PerformLayout()
    Me.SplitContainer1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Timer1 As System.Windows.Forms.Timer
  Friend WithEvents txtUserPassword As System.Windows.Forms.TextBox
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents lblCompName As System.Windows.Forms.Label
  Friend WithEvents btnLogin As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtUserName As System.Windows.Forms.TextBox
End Class
