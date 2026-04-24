<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTimeStamp
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
    Me.lblTimeStamp = New System.Windows.Forms.Label
    Me.lblEmplName = New System.Windows.Forms.Label
    Me.txtEmplID = New System.Windows.Forms.TextBox
    Me.picEmpl = New System.Windows.Forms.PictureBox
    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    Me.lblPosition = New System.Windows.Forms.Label
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.GroupBox2 = New System.Windows.Forms.GroupBox
    Me.lblServerDate = New System.Windows.Forms.Label
    Me.timeServerDateTime = New System.Windows.Forms.Timer(Me.components)
    Me.lblServerTime = New System.Windows.Forms.Label
    CType(Me.picEmpl, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'lblTimeStamp
    '
    Me.lblTimeStamp.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblTimeStamp.Location = New System.Drawing.Point(15, 103)
    Me.lblTimeStamp.Name = "lblTimeStamp"
    Me.lblTimeStamp.Size = New System.Drawing.Size(190, 22)
    Me.lblTimeStamp.TabIndex = 4
    Me.lblTimeStamp.Text = "เข้า  8.00  น."
    Me.lblTimeStamp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'lblEmplName
    '
    Me.lblEmplName.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblEmplName.Location = New System.Drawing.Point(12, 48)
    Me.lblEmplName.Name = "lblEmplName"
    Me.lblEmplName.Size = New System.Drawing.Size(193, 27)
    Me.lblEmplName.TabIndex = 2
    Me.lblEmplName.Text = "ชื่อ - นามสกุล"
    Me.lblEmplName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'txtEmplID
    '
    Me.txtEmplID.Location = New System.Drawing.Point(12, 22)
    Me.txtEmplID.Name = "txtEmplID"
    Me.txtEmplID.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.txtEmplID.Size = New System.Drawing.Size(193, 23)
    Me.txtEmplID.TabIndex = 0
    Me.txtEmplID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'picEmpl
    '
    Me.picEmpl.BackColor = System.Drawing.Color.DarkGreen
    Me.picEmpl.Location = New System.Drawing.Point(5, 22)
    Me.picEmpl.Name = "picEmpl"
    Me.picEmpl.Size = New System.Drawing.Size(109, 103)
    Me.picEmpl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.picEmpl.TabIndex = 2
    Me.picEmpl.TabStop = False
    '
    'Timer1
    '
    Me.Timer1.Interval = 5000
    '
    'lblPosition
    '
    Me.lblPosition.Location = New System.Drawing.Point(15, 75)
    Me.lblPosition.Name = "lblPosition"
    Me.lblPosition.Size = New System.Drawing.Size(190, 22)
    Me.lblPosition.TabIndex = 5
    Me.lblPosition.Text = "พนักงานขาย"
    Me.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.picEmpl)
    Me.GroupBox1.Location = New System.Drawing.Point(12, 94)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(120, 137)
    Me.GroupBox1.TabIndex = 7
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "ภาพถ่าย"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.lblTimeStamp)
    Me.GroupBox2.Controls.Add(Me.lblEmplName)
    Me.GroupBox2.Controls.Add(Me.lblPosition)
    Me.GroupBox2.Controls.Add(Me.txtEmplID)
    Me.GroupBox2.Location = New System.Drawing.Point(138, 94)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(214, 137)
    Me.GroupBox2.TabIndex = 8
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "เลขประจำตัวพนักงาน"
    '
    'lblServerDate
    '
    Me.lblServerDate.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblServerDate.ForeColor = System.Drawing.Color.DarkBlue
    Me.lblServerDate.Location = New System.Drawing.Point(12, 9)
    Me.lblServerDate.Name = "lblServerDate"
    Me.lblServerDate.Size = New System.Drawing.Size(340, 41)
    Me.lblServerDate.TabIndex = 9
    Me.lblServerDate.Text = "6 มิถุนายน 2556"
    Me.lblServerDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'timeServerDateTime
    '
    Me.timeServerDateTime.Enabled = True
    Me.timeServerDateTime.Interval = 60000
    '
    'lblServerTime
    '
    Me.lblServerTime.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblServerTime.ForeColor = System.Drawing.Color.Firebrick
    Me.lblServerTime.Location = New System.Drawing.Point(12, 50)
    Me.lblServerTime.Name = "lblServerTime"
    Me.lblServerTime.Size = New System.Drawing.Size(340, 41)
    Me.lblServerTime.TabIndex = 10
    Me.lblServerTime.Text = "19:30"
    Me.lblServerTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'frmTimeStamp
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.Honeydew
    Me.ClientSize = New System.Drawing.Size(367, 244)
    Me.Controls.Add(Me.lblServerTime)
    Me.Controls.Add(Me.lblServerDate)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmTimeStamp"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Tag = "f4a"
    Me.Text = "บันทึกเวลา เข้า-ออก งาน"
    CType(Me.picEmpl, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents lblTimeStamp As System.Windows.Forms.Label
  Friend WithEvents lblEmplName As System.Windows.Forms.Label
  Friend WithEvents txtEmplID As System.Windows.Forms.TextBox
  Friend WithEvents picEmpl As System.Windows.Forms.PictureBox
  Friend WithEvents Timer1 As System.Windows.Forms.Timer
  Friend WithEvents lblPosition As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents lblServerDate As System.Windows.Forms.Label
  Friend WithEvents timeServerDateTime As System.Windows.Forms.Timer
  Friend WithEvents lblServerTime As System.Windows.Forms.Label
End Class
