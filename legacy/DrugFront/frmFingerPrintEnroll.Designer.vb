<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFingerPrintEnroll
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFingerPrintEnroll))
    Me.ZKFPEngX1 = New AxZKFPEngXControl.AxZKFPEngX
    Me.txtSensorCount = New System.Windows.Forms.TextBox
    Me.txtSensorIndex = New System.Windows.Forms.TextBox
    Me.txtSensorSN = New System.Windows.Forms.TextBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.Label5 = New System.Windows.Forms.Label
    Me.cmdEnroll = New System.Windows.Forms.Button
    Me.Label1 = New System.Windows.Forms.Label
    Me.lblStatusBar = New System.Windows.Forms.Label
    Me.cboFingerName = New System.Windows.Forms.ComboBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.txtIDCardNumber = New System.Windows.Forms.TextBox
    Me.txtEmplName = New System.Windows.Forms.TextBox
    Me.Label6 = New System.Windows.Forms.Label
    Me.picFingerPrint = New System.Windows.Forms.PictureBox
    Me.spc1 = New System.Windows.Forms.SplitContainer
    Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
    Me.picEmpl = New System.Windows.Forms.PictureBox
    Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
    Me.pan1 = New System.Windows.Forms.Panel
    Me.btnInitSensor = New System.Windows.Forms.Button
    CType(Me.ZKFPEngX1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.picFingerPrint, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.spc1.Panel1.SuspendLayout()
    Me.spc1.Panel2.SuspendLayout()
    Me.spc1.SuspendLayout()
    Me.SplitContainer3.Panel1.SuspendLayout()
    Me.SplitContainer3.Panel2.SuspendLayout()
    Me.SplitContainer3.SuspendLayout()
    CType(Me.picEmpl, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer2.Panel1.SuspendLayout()
    Me.SplitContainer2.Panel2.SuspendLayout()
    Me.SplitContainer2.SuspendLayout()
    Me.pan1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ZKFPEngX1
    '
    Me.ZKFPEngX1.Enabled = True
    Me.ZKFPEngX1.Location = New System.Drawing.Point(290, 17)
    Me.ZKFPEngX1.Name = "ZKFPEngX1"
    Me.ZKFPEngX1.OcxState = CType(resources.GetObject("ZKFPEngX1.OcxState"), System.Windows.Forms.AxHost.State)
    Me.ZKFPEngX1.Size = New System.Drawing.Size(24, 24)
    Me.ZKFPEngX1.TabIndex = 22
    '
    'txtSensorCount
    '
    Me.txtSensorCount.AcceptsReturn = True
    Me.txtSensorCount.Cursor = System.Windows.Forms.Cursors.IBeam
    Me.txtSensorCount.ForeColor = System.Drawing.SystemColors.WindowText
    Me.txtSensorCount.Location = New System.Drawing.Point(109, 234)
    Me.txtSensorCount.MaxLength = 0
    Me.txtSensorCount.Name = "txtSensorCount"
    Me.txtSensorCount.ReadOnly = True
    Me.txtSensorCount.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.txtSensorCount.Size = New System.Drawing.Size(65, 23)
    Me.txtSensorCount.TabIndex = 25
    Me.txtSensorCount.TabStop = False
    Me.txtSensorCount.Visible = False
    '
    'txtSensorIndex
    '
    Me.txtSensorIndex.AcceptsReturn = True
    Me.txtSensorIndex.Cursor = System.Windows.Forms.Cursors.IBeam
    Me.txtSensorIndex.ForeColor = System.Drawing.SystemColors.WindowText
    Me.txtSensorIndex.Location = New System.Drawing.Point(269, 234)
    Me.txtSensorIndex.MaxLength = 0
    Me.txtSensorIndex.Name = "txtSensorIndex"
    Me.txtSensorIndex.ReadOnly = True
    Me.txtSensorIndex.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.txtSensorIndex.Size = New System.Drawing.Size(57, 23)
    Me.txtSensorIndex.TabIndex = 24
    Me.txtSensorIndex.TabStop = False
    Me.txtSensorIndex.Visible = False
    '
    'txtSensorSN
    '
    Me.txtSensorSN.AcceptsReturn = True
    Me.txtSensorSN.Cursor = System.Windows.Forms.Cursors.IBeam
    Me.txtSensorSN.ForeColor = System.Drawing.SystemColors.WindowText
    Me.txtSensorSN.Location = New System.Drawing.Point(109, 205)
    Me.txtSensorSN.MaxLength = 0
    Me.txtSensorSN.Name = "txtSensorSN"
    Me.txtSensorSN.ReadOnly = True
    Me.txtSensorSN.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.txtSensorSN.Size = New System.Drawing.Size(217, 23)
    Me.txtSensorSN.TabIndex = 23
    Me.txtSensorSN.TabStop = False
    Me.txtSensorSN.Visible = False
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.BackColor = System.Drawing.SystemColors.Control
    Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label2.Location = New System.Drawing.Point(24, 234)
    Me.Label2.Name = "Label2"
    Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label2.Size = New System.Drawing.Size(79, 16)
    Me.Label2.TabIndex = 28
    Me.Label2.Text = "จำนวนหัวอ่าน"
    Me.Label2.Visible = False
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.BackColor = System.Drawing.SystemColors.Control
    Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label4.Location = New System.Drawing.Point(214, 237)
    Me.Label4.Name = "Label4"
    Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label4.Size = New System.Drawing.Size(44, 16)
    Me.Label4.TabIndex = 27
    Me.Label4.Text = "หัวอ่าน"
    Me.Label4.Visible = False
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.BackColor = System.Drawing.SystemColors.Control
    Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label5.Location = New System.Drawing.Point(24, 208)
    Me.Label5.Name = "Label5"
    Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label5.Size = New System.Drawing.Size(68, 16)
    Me.Label5.TabIndex = 26
    Me.Label5.Text = "Sensor SN"
    Me.Label5.Visible = False
    '
    'cmdEnroll
    '
    Me.cmdEnroll.Location = New System.Drawing.Point(108, 164)
    Me.cmdEnroll.Name = "cmdEnroll"
    Me.cmdEnroll.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.cmdEnroll.Size = New System.Drawing.Size(125, 25)
    Me.cmdEnroll.TabIndex = 0
    Me.cmdEnroll.Text = "เริ่มเก็บลายนิ้วมือ"
    Me.cmdEnroll.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label1.Location = New System.Drawing.Point(24, 21)
    Me.Label1.Name = "Label1"
    Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label1.Size = New System.Drawing.Size(38, 16)
    Me.Label1.TabIndex = 31
    Me.Label1.Text = "ชื่อนิ้ว"
    '
    'lblStatusBar
    '
    Me.lblStatusBar.BackColor = System.Drawing.Color.White
    Me.lblStatusBar.Cursor = System.Windows.Forms.Cursors.Default
    Me.lblStatusBar.ForeColor = System.Drawing.SystemColors.ControlText
    Me.lblStatusBar.Location = New System.Drawing.Point(24, 54)
    Me.lblStatusBar.Name = "lblStatusBar"
    Me.lblStatusBar.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.lblStatusBar.Size = New System.Drawing.Size(302, 97)
    Me.lblStatusBar.TabIndex = 32
    Me.lblStatusBar.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'cboFingerName
    '
    Me.cboFingerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboFingerName.FormattingEnabled = True
    Me.cboFingerName.Items.AddRange(New Object() {"นิ้วหัวแม่มือ", "นิ้วชี้", "นิ้วกลาง", "นิ้วนาง", "นิ้วก้อย"})
    Me.cboFingerName.Location = New System.Drawing.Point(112, 17)
    Me.cboFingerName.Name = "cboFingerName"
    Me.cboFingerName.Size = New System.Drawing.Size(121, 24)
    Me.cboFingerName.TabIndex = 1
    Me.cboFingerName.TabStop = False
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(27, 35)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(147, 16)
    Me.Label3.TabIndex = 35
    Me.Label3.Text = "เลขประจำตัวบัตรประชาชน"
    '
    'txtIDCardNumber
    '
    Me.txtIDCardNumber.Location = New System.Drawing.Point(30, 54)
    Me.txtIDCardNumber.Name = "txtIDCardNumber"
    Me.txtIDCardNumber.Size = New System.Drawing.Size(294, 23)
    Me.txtIDCardNumber.TabIndex = 0
    '
    'txtEmplName
    '
    Me.txtEmplName.Location = New System.Drawing.Point(30, 109)
    Me.txtEmplName.Name = "txtEmplName"
    Me.txtEmplName.ReadOnly = True
    Me.txtEmplName.Size = New System.Drawing.Size(294, 23)
    Me.txtEmplName.TabIndex = 38
    Me.txtEmplName.TabStop = False
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(27, 90)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(75, 16)
    Me.Label6.TabIndex = 37
    Me.Label6.Text = "ชื่อ-นามสกุล"
    '
    'picFingerPrint
    '
    Me.picFingerPrint.BackColor = System.Drawing.Color.SeaShell
    Me.picFingerPrint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.picFingerPrint.Dock = System.Windows.Forms.DockStyle.Fill
    Me.picFingerPrint.Location = New System.Drawing.Point(0, 0)
    Me.picFingerPrint.Name = "picFingerPrint"
    Me.picFingerPrint.Size = New System.Drawing.Size(250, 273)
    Me.picFingerPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
    Me.picFingerPrint.TabIndex = 33
    Me.picFingerPrint.TabStop = False
    '
    'spc1
    '
    Me.spc1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.spc1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.spc1.IsSplitterFixed = True
    Me.spc1.Location = New System.Drawing.Point(0, 0)
    Me.spc1.Name = "spc1"
    Me.spc1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'spc1.Panel1
    '
    Me.spc1.Panel1.Controls.Add(Me.SplitContainer3)
    '
    'spc1.Panel2
    '
    Me.spc1.Panel2.Controls.Add(Me.SplitContainer2)
    Me.spc1.Size = New System.Drawing.Size(603, 483)
    Me.spc1.SplitterDistance = 206
    Me.spc1.TabIndex = 40
    Me.spc1.TabStop = False
    '
    'SplitContainer3
    '
    Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer3.IsSplitterFixed = True
    Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer3.Name = "SplitContainer3"
    '
    'SplitContainer3.Panel1
    '
    Me.SplitContainer3.Panel1.Controls.Add(Me.picEmpl)
    '
    'SplitContainer3.Panel2
    '
    Me.SplitContainer3.Panel2.BackColor = System.Drawing.Color.LightSalmon
    Me.SplitContainer3.Panel2.Controls.Add(Me.Label3)
    Me.SplitContainer3.Panel2.Controls.Add(Me.Label6)
    Me.SplitContainer3.Panel2.Controls.Add(Me.txtIDCardNumber)
    Me.SplitContainer3.Panel2.Controls.Add(Me.txtEmplName)
    Me.SplitContainer3.Size = New System.Drawing.Size(603, 206)
    Me.SplitContainer3.SplitterDistance = 250
    Me.SplitContainer3.TabIndex = 0
    Me.SplitContainer3.TabStop = False
    '
    'picEmpl
    '
    Me.picEmpl.BackColor = System.Drawing.Color.SeaShell
    Me.picEmpl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.picEmpl.Dock = System.Windows.Forms.DockStyle.Fill
    Me.picEmpl.Location = New System.Drawing.Point(0, 0)
    Me.picEmpl.Name = "picEmpl"
    Me.picEmpl.Size = New System.Drawing.Size(250, 206)
    Me.picEmpl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.picEmpl.TabIndex = 34
    Me.picEmpl.TabStop = False
    '
    'SplitContainer2
    '
    Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer2.IsSplitterFixed = True
    Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer2.Name = "SplitContainer2"
    '
    'SplitContainer2.Panel1
    '
    Me.SplitContainer2.Panel1.Controls.Add(Me.picFingerPrint)
    '
    'SplitContainer2.Panel2
    '
    Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.LightSalmon
    Me.SplitContainer2.Panel2.Controls.Add(Me.cboFingerName)
    Me.SplitContainer2.Panel2.Controls.Add(Me.txtSensorCount)
    Me.SplitContainer2.Panel2.Controls.Add(Me.cmdEnroll)
    Me.SplitContainer2.Panel2.Controls.Add(Me.txtSensorIndex)
    Me.SplitContainer2.Panel2.Controls.Add(Me.Label1)
    Me.SplitContainer2.Panel2.Controls.Add(Me.txtSensorSN)
    Me.SplitContainer2.Panel2.Controls.Add(Me.Label2)
    Me.SplitContainer2.Panel2.Controls.Add(Me.lblStatusBar)
    Me.SplitContainer2.Panel2.Controls.Add(Me.Label4)
    Me.SplitContainer2.Panel2.Controls.Add(Me.ZKFPEngX1)
    Me.SplitContainer2.Panel2.Controls.Add(Me.Label5)
    Me.SplitContainer2.Size = New System.Drawing.Size(603, 273)
    Me.SplitContainer2.SplitterDistance = 250
    Me.SplitContainer2.TabIndex = 0
    Me.SplitContainer2.TabStop = False
    '
    'pan1
    '
    Me.pan1.BackColor = System.Drawing.Color.LightSalmon
    Me.pan1.Controls.Add(Me.btnInitSensor)
    Me.pan1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.pan1.Location = New System.Drawing.Point(0, 0)
    Me.pan1.Name = "pan1"
    Me.pan1.Size = New System.Drawing.Size(603, 483)
    Me.pan1.TabIndex = 41
    '
    'btnInitSensor
    '
    Me.btnInitSensor.Location = New System.Drawing.Point(233, 231)
    Me.btnInitSensor.Name = "btnInitSensor"
    Me.btnInitSensor.Size = New System.Drawing.Size(127, 30)
    Me.btnInitSensor.TabIndex = 1
    Me.btnInitSensor.Text = "เริ่มระบบสแกน"
    Me.btnInitSensor.UseVisualStyleBackColor = True
    '
    'frmFingerPrintEnroll
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(603, 483)
    Me.Controls.Add(Me.spc1)
    Me.Controls.Add(Me.pan1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmFingerPrintEnroll"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Tag = "b1h"
    Me.Text = "ลงทะเบียนข้อมูลลายนิ้วมือ"
    CType(Me.ZKFPEngX1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.picFingerPrint, System.ComponentModel.ISupportInitialize).EndInit()
    Me.spc1.Panel1.ResumeLayout(False)
    Me.spc1.Panel2.ResumeLayout(False)
    Me.spc1.ResumeLayout(False)
    Me.SplitContainer3.Panel1.ResumeLayout(False)
    Me.SplitContainer3.Panel2.ResumeLayout(False)
    Me.SplitContainer3.Panel2.PerformLayout()
    Me.SplitContainer3.ResumeLayout(False)
    CType(Me.picEmpl, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer2.Panel1.ResumeLayout(False)
    Me.SplitContainer2.Panel2.ResumeLayout(False)
    Me.SplitContainer2.Panel2.PerformLayout()
    Me.SplitContainer2.ResumeLayout(False)
    Me.pan1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents ZKFPEngX1 As AxZKFPEngXControl.AxZKFPEngX
  Public WithEvents txtSensorCount As System.Windows.Forms.TextBox
  Public WithEvents txtSensorIndex As System.Windows.Forms.TextBox
  Public WithEvents Label2 As System.Windows.Forms.Label
  Public WithEvents Label4 As System.Windows.Forms.Label
  Public WithEvents Label5 As System.Windows.Forms.Label
  Public WithEvents Label1 As System.Windows.Forms.Label
  Public WithEvents lblStatusBar As System.Windows.Forms.Label
  Friend WithEvents picFingerPrint As System.Windows.Forms.PictureBox
  Friend WithEvents cboFingerName As System.Windows.Forms.ComboBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtIDCardNumber As System.Windows.Forms.TextBox
  Friend WithEvents txtEmplName As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents txtSensorSN As System.Windows.Forms.TextBox
  Friend WithEvents spc1 As System.Windows.Forms.SplitContainer
  Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
  Friend WithEvents cmdEnroll As System.Windows.Forms.Button
  Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
  Friend WithEvents picEmpl As System.Windows.Forms.PictureBox
  Friend WithEvents pan1 As System.Windows.Forms.Panel
  Friend WithEvents btnInitSensor As System.Windows.Forms.Button
End Class
