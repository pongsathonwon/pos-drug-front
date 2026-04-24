<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRpFCSale
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
    Me.btnShow = New System.Windows.Forms.Button
    Me.dtpEnd = New System.Windows.Forms.DateTimePicker
    Me.Label7 = New System.Windows.Forms.Label
    Me.dtpStart = New System.Windows.Forms.DateTimePicker
    Me.Label8 = New System.Windows.Forms.Label
    Me.radDay = New System.Windows.Forms.RadioButton
    Me.radMonth = New System.Windows.Forms.RadioButton
    Me.chkWelFare = New System.Windows.Forms.CheckBox
    Me.radQuarter = New System.Windows.Forms.RadioButton
    Me.SuspendLayout()
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(193, 179)
    Me.btnShow.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(93, 28)
    Me.btnShow.TabIndex = 0
    Me.btnShow.Text = "แสดงรายงาน"
    Me.btnShow.UseVisualStyleBackColor = True
    '
    'dtpEnd
    '
    Me.dtpEnd.Location = New System.Drawing.Point(143, 68)
    Me.dtpEnd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dtpEnd.Name = "dtpEnd"
    Me.dtpEnd.Size = New System.Drawing.Size(242, 23)
    Me.dtpEnd.TabIndex = 6
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(59, 68)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(45, 16)
    Me.Label7.TabIndex = 42
    Me.Label7.Text = "ถึงวันที่"
    '
    'dtpStart
    '
    Me.dtpStart.Location = New System.Drawing.Point(143, 35)
    Me.dtpStart.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dtpStart.Name = "dtpStart"
    Me.dtpStart.Size = New System.Drawing.Size(242, 23)
    Me.dtpStart.TabIndex = 5
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(59, 35)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(61, 16)
    Me.Label8.TabIndex = 41
    Me.Label8.Text = "ตั้งแต่วันที่"
    '
    'radDay
    '
    Me.radDay.AutoSize = True
    Me.radDay.Checked = True
    Me.radDay.Location = New System.Drawing.Point(143, 99)
    Me.radDay.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.radDay.Name = "radDay"
    Me.radDay.Size = New System.Drawing.Size(60, 20)
    Me.radDay.TabIndex = 1
    Me.radDay.TabStop = True
    Me.radDay.Text = "รายวัน"
    Me.radDay.UseVisualStyleBackColor = True
    '
    'radMonth
    '
    Me.radMonth.AutoSize = True
    Me.radMonth.Location = New System.Drawing.Point(212, 99)
    Me.radMonth.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.radMonth.Name = "radMonth"
    Me.radMonth.Size = New System.Drawing.Size(74, 20)
    Me.radMonth.TabIndex = 2
    Me.radMonth.Text = "รายเดือน"
    Me.radMonth.UseVisualStyleBackColor = True
    '
    'chkWelFare
    '
    Me.chkWelFare.AutoSize = True
    Me.chkWelFare.Location = New System.Drawing.Point(143, 127)
    Me.chkWelFare.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.chkWelFare.Name = "chkWelFare"
    Me.chkWelFare.Size = New System.Drawing.Size(119, 20)
    Me.chkWelFare.TabIndex = 8
    Me.chkWelFare.Text = "รวมขายสวัสดิการ"
    Me.chkWelFare.UseVisualStyleBackColor = True
    '
    'radQuarter
    '
    Me.radQuarter.AutoSize = True
    Me.radQuarter.Location = New System.Drawing.Point(296, 99)
    Me.radQuarter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.radQuarter.Name = "radQuarter"
    Me.radQuarter.Size = New System.Drawing.Size(89, 20)
    Me.radQuarter.TabIndex = 3
    Me.radQuarter.Text = "รายไตรมาส"
    Me.radQuarter.UseVisualStyleBackColor = True
    '
    'frmRpFCSale
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(477, 237)
    Me.Controls.Add(Me.radQuarter)
    Me.Controls.Add(Me.chkWelFare)
    Me.Controls.Add(Me.radMonth)
    Me.Controls.Add(Me.radDay)
    Me.Controls.Add(Me.dtpEnd)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.dtpStart)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.btnShow)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmRpFCSale"
    Me.Tag = "f3d"
    Me.Text = "รายงานสรุปยอดขายสินค้า แจกแจงเป็นงวด"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents radDay As System.Windows.Forms.RadioButton
  Friend WithEvents radMonth As System.Windows.Forms.RadioButton
  Friend WithEvents chkWelFare As System.Windows.Forms.CheckBox
  Friend WithEvents radQuarter As System.Windows.Forms.RadioButton
End Class
