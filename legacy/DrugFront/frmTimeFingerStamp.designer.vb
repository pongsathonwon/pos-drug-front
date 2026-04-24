<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTimeFingerStamp
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTimeFingerStamp))
    Me.lblTimeStamp = New System.Windows.Forms.Label
    Me.lblEmplName = New System.Windows.Forms.Label
    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    Me.lblPosition = New System.Windows.Forms.Label
    Me.GroupBox2 = New System.Windows.Forms.GroupBox
    Me.lblServerDate = New System.Windows.Forms.Label
    Me.timeServerDateTime = New System.Windows.Forms.Timer(Me.components)
    Me.lblServerTime = New System.Windows.Forms.Label
    Me.ZKFPEngX1 = New AxZKFPEngXControl.AxZKFPEngX
    Me.picEmpl = New System.Windows.Forms.PictureBox
    Me.pan1 = New System.Windows.Forms.Panel
    Me.pan2 = New System.Windows.Forms.Panel
    Me.btnInitSensor = New System.Windows.Forms.Button
    Me.GroupBox2.SuspendLayout()
    CType(Me.ZKFPEngX1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.picEmpl, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.pan1.SuspendLayout()
    Me.pan2.SuspendLayout()
    Me.SuspendLayout()
    '
    'lblTimeStamp
    '
    Me.lblTimeStamp.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblTimeStamp.Location = New System.Drawing.Point(9, 77)
    Me.lblTimeStamp.Name = "lblTimeStamp"
    Me.lblTimeStamp.Size = New System.Drawing.Size(269, 34)
    Me.lblTimeStamp.TabIndex = 4
    Me.lblTimeStamp.Text = "เข้า  8.00  น."
    Me.lblTimeStamp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'lblEmplName
    '
    Me.lblEmplName.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblEmplName.Location = New System.Drawing.Point(6, 19)
    Me.lblEmplName.Name = "lblEmplName"
    Me.lblEmplName.Size = New System.Drawing.Size(272, 27)
    Me.lblEmplName.TabIndex = 2
    Me.lblEmplName.Text = "ชื่อ - นามสกุล"
    Me.lblEmplName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Timer1
    '
    Me.Timer1.Interval = 5000
    '
    'lblPosition
    '
    Me.lblPosition.Location = New System.Drawing.Point(9, 46)
    Me.lblPosition.Name = "lblPosition"
    Me.lblPosition.Size = New System.Drawing.Size(269, 22)
    Me.lblPosition.TabIndex = 5
    Me.lblPosition.Text = "พนักงานขาย"
    Me.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.lblTimeStamp)
    Me.GroupBox2.Controls.Add(Me.lblEmplName)
    Me.GroupBox2.Controls.Add(Me.lblPosition)
    Me.GroupBox2.Location = New System.Drawing.Point(17, 261)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(284, 137)
    Me.GroupBox2.TabIndex = 8
    Me.GroupBox2.TabStop = False
    '
    'lblServerDate
    '
    Me.lblServerDate.AutoSize = True
    Me.lblServerDate.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblServerDate.Location = New System.Drawing.Point(12, 10)
    Me.lblServerDate.Name = "lblServerDate"
    Me.lblServerDate.Size = New System.Drawing.Size(170, 25)
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
    Me.lblServerTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblServerTime.AutoSize = True
    Me.lblServerTime.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblServerTime.Location = New System.Drawing.Point(232, 10)
    Me.lblServerTime.Name = "lblServerTime"
    Me.lblServerTime.Size = New System.Drawing.Size(72, 25)
    Me.lblServerTime.TabIndex = 10
    Me.lblServerTime.Text = "19:30"
    Me.lblServerTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'ZKFPEngX1
    '
    Me.ZKFPEngX1.Enabled = True
    Me.ZKFPEngX1.Location = New System.Drawing.Point(340, 245)
    Me.ZKFPEngX1.Name = "ZKFPEngX1"
    Me.ZKFPEngX1.OcxState = CType(resources.GetObject("ZKFPEngX1.OcxState"), System.Windows.Forms.AxHost.State)
    Me.ZKFPEngX1.Size = New System.Drawing.Size(24, 24)
    Me.ZKFPEngX1.TabIndex = 23
    '
    'picEmpl
    '
    Me.picEmpl.BackColor = System.Drawing.Color.SeaShell
    Me.picEmpl.Location = New System.Drawing.Point(17, 50)
    Me.picEmpl.Name = "picEmpl"
    Me.picEmpl.Size = New System.Drawing.Size(284, 205)
    Me.picEmpl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
    Me.picEmpl.TabIndex = 2
    Me.picEmpl.TabStop = False
    '
    'pan1
    '
    Me.pan1.Controls.Add(Me.lblServerDate)
    Me.pan1.Controls.Add(Me.lblServerTime)
    Me.pan1.Controls.Add(Me.picEmpl)
    Me.pan1.Controls.Add(Me.GroupBox2)
    Me.pan1.Controls.Add(Me.ZKFPEngX1)
    Me.pan1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.pan1.Location = New System.Drawing.Point(0, 0)
    Me.pan1.Name = "pan1"
    Me.pan1.Size = New System.Drawing.Size(317, 413)
    Me.pan1.TabIndex = 24
    '
    'pan2
    '
    Me.pan2.Controls.Add(Me.btnInitSensor)
    Me.pan2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.pan2.Location = New System.Drawing.Point(0, 0)
    Me.pan2.Name = "pan2"
    Me.pan2.Size = New System.Drawing.Size(317, 413)
    Me.pan2.TabIndex = 25
    '
    'btnInitSensor
    '
    Me.btnInitSensor.Location = New System.Drawing.Point(97, 192)
    Me.btnInitSensor.Name = "btnInitSensor"
    Me.btnInitSensor.Size = New System.Drawing.Size(127, 30)
    Me.btnInitSensor.TabIndex = 0
    Me.btnInitSensor.Text = "เริ่มระบบสแกน"
    Me.btnInitSensor.UseVisualStyleBackColor = True
    '
    'frmTimeFingerStamp
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.LightSalmon
    Me.ClientSize = New System.Drawing.Size(317, 413)
    Me.Controls.Add(Me.pan1)
    Me.Controls.Add(Me.pan2)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmTimeFingerStamp"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Tag = "f4a"
    Me.Text = "บันทึกเวลา เข้า-ออก งาน"
    Me.GroupBox2.ResumeLayout(False)
    CType(Me.ZKFPEngX1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.picEmpl, System.ComponentModel.ISupportInitialize).EndInit()
    Me.pan1.ResumeLayout(False)
    Me.pan1.PerformLayout()
    Me.pan2.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents lblTimeStamp As System.Windows.Forms.Label
  Friend WithEvents lblEmplName As System.Windows.Forms.Label
  Friend WithEvents picEmpl As System.Windows.Forms.PictureBox
  Friend WithEvents Timer1 As System.Windows.Forms.Timer
  Friend WithEvents lblPosition As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents lblServerDate As System.Windows.Forms.Label
  Friend WithEvents timeServerDateTime As System.Windows.Forms.Timer
  Friend WithEvents lblServerTime As System.Windows.Forms.Label
  Friend WithEvents ZKFPEngX1 As AxZKFPEngXControl.AxZKFPEngX
  Friend WithEvents pan1 As System.Windows.Forms.Panel
  Friend WithEvents pan2 As System.Windows.Forms.Panel
  Friend WithEvents btnInitSensor As System.Windows.Forms.Button
End Class
