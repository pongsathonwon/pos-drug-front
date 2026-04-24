<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRpHistSaleCustType
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
    Me.cboCustTypeCode = New System.Windows.Forms.ComboBox
    Me.cboCustTypeDesc = New System.Windows.Forms.ComboBox
    Me.Label6 = New System.Windows.Forms.Label
    Me.Panel2 = New System.Windows.Forms.Panel
    Me.radMonth = New System.Windows.Forms.RadioButton
    Me.radDay = New System.Windows.Forms.RadioButton
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.radTotal = New System.Windows.Forms.RadioButton
    Me.radDetail = New System.Windows.Forms.RadioButton
    Me.Panel2.SuspendLayout()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(185, 215)
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
    'cboCustTypeCode
    '
    Me.cboCustTypeCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboCustTypeCode.FormattingEnabled = True
    Me.cboCustTypeCode.Location = New System.Drawing.Point(456, 96)
    Me.cboCustTypeCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.cboCustTypeCode.Name = "cboCustTypeCode"
    Me.cboCustTypeCode.Size = New System.Drawing.Size(28, 24)
    Me.cboCustTypeCode.TabIndex = 54
    Me.cboCustTypeCode.Visible = False
    '
    'cboCustTypeDesc
    '
    Me.cboCustTypeDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboCustTypeDesc.FormattingEnabled = True
    Me.cboCustTypeDesc.Location = New System.Drawing.Point(186, 96)
    Me.cboCustTypeDesc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.cboCustTypeDesc.Name = "cboCustTypeDesc"
    Me.cboCustTypeDesc.Size = New System.Drawing.Size(244, 24)
    Me.cboCustTypeDesc.TabIndex = 6
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(67, 99)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(79, 16)
    Me.Label6.TabIndex = 56
    Me.Label6.Text = "ประเภทลูกค้า"
    '
    'Panel2
    '
    Me.Panel2.Controls.Add(Me.radMonth)
    Me.Panel2.Controls.Add(Me.radDay)
    Me.Panel2.Location = New System.Drawing.Point(186, 128)
    Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(244, 32)
    Me.Panel2.TabIndex = 7
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
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.radTotal)
    Me.Panel1.Controls.Add(Me.radDetail)
    Me.Panel1.Location = New System.Drawing.Point(186, 160)
    Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(244, 33)
    Me.Panel1.TabIndex = 8
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
    'frmRpHistSaleSum
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.Plum
    Me.ClientSize = New System.Drawing.Size(513, 278)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.Panel2)
    Me.Controls.Add(Me.cboCustTypeCode)
    Me.Controls.Add(Me.cboCustTypeDesc)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.btnShow)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.dtpFrom)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.dtpTo)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmRpHistSaleSum"
    Me.Tag = "f3l"
    Me.Text = "รายงานยอดขายสินค้า แยกตามประเภทลูกค้า"
    Me.Panel2.ResumeLayout(False)
    Me.Panel2.PerformLayout()
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents cboCustTypeCode As System.Windows.Forms.ComboBox
  Friend WithEvents cboCustTypeDesc As System.Windows.Forms.ComboBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents radMonth As System.Windows.Forms.RadioButton
  Friend WithEvents radDay As System.Windows.Forms.RadioButton
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents radTotal As System.Windows.Forms.RadioButton
  Friend WithEvents radDetail As System.Windows.Forms.RadioButton
End Class
