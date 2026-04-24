<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangePassword
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtOldName = New System.Windows.Forms.TextBox
    Me.txtOldPassword = New System.Windows.Forms.TextBox
    Me.Label5 = New System.Windows.Forms.Label
    Me.txtNewName = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.txtNewPassword = New System.Windows.Forms.TextBox
    Me.btnSave = New System.Windows.Forms.Button
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.Label7 = New System.Windows.Forms.Label
    Me.Label6 = New System.Windows.Forms.Label
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(64, 31)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(71, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "User Name"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(64, 60)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(63, 16)
    Me.Label2.TabIndex = 1
    Me.Label2.Text = "Password"
    '
    'txtOldName
    '
    Me.txtOldName.Location = New System.Drawing.Point(151, 28)
    Me.txtOldName.Name = "txtOldName"
    Me.txtOldName.Size = New System.Drawing.Size(100, 23)
    Me.txtOldName.TabIndex = 0
    '
    'txtOldPassword
    '
    Me.txtOldPassword.Location = New System.Drawing.Point(151, 57)
    Me.txtOldPassword.Name = "txtOldPassword"
    Me.txtOldPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.txtOldPassword.Size = New System.Drawing.Size(100, 23)
    Me.txtOldPassword.TabIndex = 1
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.ForeColor = System.Drawing.Color.DarkRed
    Me.Label5.Location = New System.Drawing.Point(23, 94)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(301, 16)
    Me.Label5.TabIndex = 2
    Me.Label5.Text = "อักษรที่ใช้ได้ เลข 0 ถึง 9  A ถึง Z ทั้งตัวเล็กและตัวใหญ๋"
    '
    'txtNewName
    '
    Me.txtNewName.Location = New System.Drawing.Point(151, 27)
    Me.txtNewName.MaxLength = 20
    Me.txtNewName.Name = "txtNewName"
    Me.txtNewName.Size = New System.Drawing.Size(100, 23)
    Me.txtNewName.TabIndex = 0
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(64, 30)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(71, 16)
    Me.Label3.TabIndex = 0
    Me.Label3.Text = "User Name"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(64, 59)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(63, 16)
    Me.Label4.TabIndex = 1
    Me.Label4.Text = "Password"
    '
    'txtNewPassword
    '
    Me.txtNewPassword.Location = New System.Drawing.Point(151, 56)
    Me.txtNewPassword.MaxLength = 10
    Me.txtNewPassword.Name = "txtNewPassword"
    Me.txtNewPassword.Size = New System.Drawing.Size(100, 23)
    Me.txtNewPassword.TabIndex = 1
    '
    'btnSave
    '
    Me.btnSave.Location = New System.Drawing.Point(137, 122)
    Me.btnSave.Name = "btnSave"
    Me.btnSave.Size = New System.Drawing.Size(75, 23)
    Me.btnSave.TabIndex = 2
    Me.btnSave.Text = "บันทึก"
    Me.btnSave.UseVisualStyleBackColor = True
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
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Honeydew
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtOldName)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtOldPassword)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.PaleGreen
    Me.SplitContainer1.Panel2.Controls.Add(Me.Label6)
    Me.SplitContainer1.Panel2.Controls.Add(Me.Label5)
    Me.SplitContainer1.Panel2.Controls.Add(Me.btnSave)
    Me.SplitContainer1.Panel2.Controls.Add(Me.txtNewName)
    Me.SplitContainer1.Panel2.Controls.Add(Me.txtNewPassword)
    Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
    Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
    Me.SplitContainer1.Size = New System.Drawing.Size(345, 271)
    Me.SplitContainer1.SplitterDistance = 106
    Me.SplitContainer1.TabIndex = 0
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.ForeColor = System.Drawing.Color.Blue
    Me.Label7.Location = New System.Drawing.Point(10, 8)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(50, 16)
    Me.Label7.TabIndex = 2
    Me.Label7.Text = "รหัสเดิม"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.ForeColor = System.Drawing.Color.Blue
    Me.Label6.Location = New System.Drawing.Point(9, 8)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(52, 16)
    Me.Label6.TabIndex = 2
    Me.Label6.Text = "รหัสใหม่"
    '
    'frmChangePassword
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(345, 271)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmChangePassword"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "เปลี่ยนข้อมูลรหัสผ่าน"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.Panel2.PerformLayout()
    Me.SplitContainer1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtOldName As System.Windows.Forms.TextBox
  Friend WithEvents txtOldPassword As System.Windows.Forms.TextBox
  Friend WithEvents txtNewName As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents txtNewPassword As System.Windows.Forms.TextBox
  Friend WithEvents btnSave As System.Windows.Forms.Button
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
