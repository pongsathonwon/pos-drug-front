<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRpHistSaleSaleType
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
    Me.dtpTo = New System.Windows.Forms.DateTimePicker
    Me.Label3 = New System.Windows.Forms.Label
    Me.dtpFrom = New System.Windows.Forms.DateTimePicker
    Me.Label2 = New System.Windows.Forms.Label
    Me.Panel2 = New System.Windows.Forms.Panel
    Me.radQuarter = New System.Windows.Forms.RadioButton
    Me.radMonth = New System.Windows.Forms.RadioButton
    Me.radDay = New System.Windows.Forms.RadioButton
    Me.Panel3 = New System.Windows.Forms.Panel
    Me.radTotal = New System.Windows.Forms.RadioButton
    Me.radDetail = New System.Windows.Forms.RadioButton
    Me.chkIncludeDisc = New System.Windows.Forms.CheckBox
    Me.chkWelFare = New System.Windows.Forms.CheckBox
    Me.Panel2.SuspendLayout()
    Me.Panel3.SuspendLayout()
    Me.SuspendLayout()
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(186, 259)
    Me.btnShow.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(123, 28)
    Me.btnShow.TabIndex = 0
    Me.btnShow.Text = "แสดงรายงาน"
    Me.btnShow.UseVisualStyleBackColor = True
    '
    'dtpTo
    '
    Me.dtpTo.Location = New System.Drawing.Point(186, 65)
    Me.dtpTo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dtpTo.Name = "dtpTo"
    Me.dtpTo.Size = New System.Drawing.Size(244, 23)
    Me.dtpTo.TabIndex = 2
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(67, 70)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(45, 16)
    Me.Label3.TabIndex = 6
    Me.Label3.Text = "ถึงวันที่"
    '
    'dtpFrom
    '
    Me.dtpFrom.Location = New System.Drawing.Point(186, 34)
    Me.dtpFrom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dtpFrom.Name = "dtpFrom"
    Me.dtpFrom.Size = New System.Drawing.Size(244, 23)
    Me.dtpFrom.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(67, 39)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(61, 16)
    Me.Label2.TabIndex = 4
    Me.Label2.Text = "ตั้งแต่วันที่"
    '
    'Panel2
    '
    Me.Panel2.Controls.Add(Me.radQuarter)
    Me.Panel2.Controls.Add(Me.radMonth)
    Me.Panel2.Controls.Add(Me.radDay)
    Me.Panel2.Location = New System.Drawing.Point(186, 96)
    Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(244, 32)
    Me.Panel2.TabIndex = 7
    '
    'radQuarter
    '
    Me.radQuarter.AutoSize = True
    Me.radQuarter.Location = New System.Drawing.Point(150, 4)
    Me.radQuarter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.radQuarter.Name = "radQuarter"
    Me.radQuarter.Size = New System.Drawing.Size(89, 20)
    Me.radQuarter.TabIndex = 2
    Me.radQuarter.Text = "รายไตรมาส"
    Me.radQuarter.UseVisualStyleBackColor = True
    '
    'radMonth
    '
    Me.radMonth.AutoSize = True
    Me.radMonth.Location = New System.Drawing.Point(70, 4)
    Me.radMonth.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.radMonth.Name = "radMonth"
    Me.radMonth.Size = New System.Drawing.Size(74, 20)
    Me.radMonth.TabIndex = 1
    Me.radMonth.Text = "รายเดือน"
    Me.radMonth.UseVisualStyleBackColor = True
    '
    'radDay
    '
    Me.radDay.AutoSize = True
    Me.radDay.Checked = True
    Me.radDay.Location = New System.Drawing.Point(4, 4)
    Me.radDay.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.radDay.Name = "radDay"
    Me.radDay.Size = New System.Drawing.Size(60, 20)
    Me.radDay.TabIndex = 0
    Me.radDay.TabStop = True
    Me.radDay.Text = "รายวัน"
    Me.radDay.UseVisualStyleBackColor = True
    '
    'Panel3
    '
    Me.Panel3.Controls.Add(Me.radTotal)
    Me.Panel3.Controls.Add(Me.radDetail)
    Me.Panel3.Location = New System.Drawing.Point(186, 136)
    Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Panel3.Name = "Panel3"
    Me.Panel3.Size = New System.Drawing.Size(244, 33)
    Me.Panel3.TabIndex = 53
    '
    'radTotal
    '
    Me.radTotal.AutoSize = True
    Me.radTotal.Location = New System.Drawing.Point(128, 4)
    Me.radTotal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.radTotal.Name = "radTotal"
    Me.radTotal.Size = New System.Drawing.Size(102, 20)
    Me.radTotal.TabIndex = 1
    Me.radTotal.Text = "แสดงยอดสรุป"
    Me.radTotal.UseVisualStyleBackColor = True
    '
    'radDetail
    '
    Me.radDetail.AutoSize = True
    Me.radDetail.Checked = True
    Me.radDetail.Location = New System.Drawing.Point(4, 4)
    Me.radDetail.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.radDetail.Name = "radDetail"
    Me.radDetail.Size = New System.Drawing.Size(118, 20)
    Me.radDetail.TabIndex = 0
    Me.radDetail.TabStop = True
    Me.radDetail.Text = "แสดงรายละเอียด"
    Me.radDetail.UseVisualStyleBackColor = True
    '
    'chkIncludeDisc
    '
    Me.chkIncludeDisc.AutoSize = True
    Me.chkIncludeDisc.Location = New System.Drawing.Point(186, 201)
    Me.chkIncludeDisc.Name = "chkIncludeDisc"
    Me.chkIncludeDisc.Size = New System.Drawing.Size(210, 20)
    Me.chkIncludeDisc.TabIndex = 55
    Me.chkIncludeDisc.Text = "คำนวณ GP โดยไม่หักส่วนลดสินค้า"
    Me.chkIncludeDisc.UseVisualStyleBackColor = True
    '
    'chkWelFare
    '
    Me.chkWelFare.AutoSize = True
    Me.chkWelFare.Location = New System.Drawing.Point(186, 177)
    Me.chkWelFare.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.chkWelFare.Name = "chkWelFare"
    Me.chkWelFare.Size = New System.Drawing.Size(143, 20)
    Me.chkWelFare.TabIndex = 54
    Me.chkWelFare.Text = "รวมยอดขายสวัสดิการ"
    Me.chkWelFare.UseVisualStyleBackColor = True
    '
    'frmRpHistSaleType
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.Plum
    Me.ClientSize = New System.Drawing.Size(513, 322)
    Me.Controls.Add(Me.chkIncludeDisc)
    Me.Controls.Add(Me.chkWelFare)
    Me.Controls.Add(Me.Panel3)
    Me.Controls.Add(Me.Panel2)
    Me.Controls.Add(Me.btnShow)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.dtpFrom)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.dtpTo)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmRpHistSaleType"
    Me.Tag = "f3m"
    Me.Text = "รายงานยอดขายสินค้า แยกตามลักษณะการขาย"
    Me.Panel2.ResumeLayout(False)
    Me.Panel2.PerformLayout()
    Me.Panel3.ResumeLayout(False)
    Me.Panel3.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents radMonth As System.Windows.Forms.RadioButton
  Friend WithEvents radDay As System.Windows.Forms.RadioButton
  Friend WithEvents radQuarter As System.Windows.Forms.RadioButton
  Friend WithEvents Panel3 As System.Windows.Forms.Panel
  Friend WithEvents radTotal As System.Windows.Forms.RadioButton
  Friend WithEvents radDetail As System.Windows.Forms.RadioButton
  Friend WithEvents chkIncludeDisc As System.Windows.Forms.CheckBox
  Friend WithEvents chkWelFare As System.Windows.Forms.CheckBox
End Class
