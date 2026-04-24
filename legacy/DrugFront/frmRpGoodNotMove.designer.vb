<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRpGoodNotMove
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
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.btnShow = New System.Windows.Forms.Button
    Me.txtDay = New System.Windows.Forms.TextBox
    Me.dtgView = New System.Windows.Forms.DataGridView
    Me.itemLine = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.barCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.lastSale = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.radNotSale = New System.Windows.Forms.RadioButton
    Me.radNotMove = New System.Windows.Forms.RadioButton
    Me.Label1 = New System.Windows.Forms.Label
    Me.btnPrint = New System.Windows.Forms.Button
    Me.pdc1 = New System.Drawing.Printing.PrintDocument
    Me.lblSubTotal = New System.Windows.Forms.Label
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtPage = New System.Windows.Forms.TextBox
    Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
    CType(Me.dtgView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SplitContainer2.Panel1.SuspendLayout()
    Me.SplitContainer2.Panel2.SuspendLayout()
    Me.SplitContainer2.SuspendLayout()
    Me.SuspendLayout()
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(377, 13)
    Me.btnShow.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(93, 28)
    Me.btnShow.TabIndex = 1
    Me.btnShow.Text = "แสดงรายงาน"
    Me.btnShow.UseVisualStyleBackColor = True
    '
    'txtDay
    '
    Me.txtDay.Location = New System.Drawing.Point(236, 13)
    Me.txtDay.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtDay.Name = "txtDay"
    Me.txtDay.Size = New System.Drawing.Size(55, 23)
    Me.txtDay.TabIndex = 0
    Me.txtDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'dtgView
    '
    Me.dtgView.AllowUserToAddRows = False
    Me.dtgView.AllowUserToDeleteRows = False
    Me.dtgView.BackgroundColor = System.Drawing.Color.LavenderBlush
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemLine, Me.goodName, Me.barCode, Me.lastSale, Me.goodAmou, Me.unitDesc, Me.unitPrice, Me.SubTotal})
    Me.dtgView.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgView.Location = New System.Drawing.Point(0, 0)
    Me.dtgView.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dtgView.Name = "dtgView"
    Me.dtgView.ReadOnly = True
    Me.dtgView.RowHeadersWidth = 30
    Me.dtgView.Size = New System.Drawing.Size(969, 427)
    Me.dtgView.TabIndex = 1
    '
    'itemLine
    '
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    Me.itemLine.DefaultCellStyle = DataGridViewCellStyle2
    Me.itemLine.HeaderText = ""
    Me.itemLine.Name = "itemLine"
    Me.itemLine.ReadOnly = True
    Me.itemLine.Width = 30
    '
    'goodName
    '
    Me.goodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.goodName.HeaderText = "รายการสินค้า"
    Me.goodName.Name = "goodName"
    Me.goodName.ReadOnly = True
    '
    'barCode
    '
    Me.barCode.HeaderText = "รหัสสินค้า"
    Me.barCode.Name = "barCode"
    Me.barCode.ReadOnly = True
    '
    'lastSale
    '
    DataGridViewCellStyle3.Format = "d"
    DataGridViewCellStyle3.NullValue = Nothing
    Me.lastSale.DefaultCellStyle = DataGridViewCellStyle3
    Me.lastSale.HeaderText = "ขายล่าสุด"
    Me.lastSale.Name = "lastSale"
    Me.lastSale.ReadOnly = True
    '
    'goodAmou
    '
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle4.Format = "N0"
    DataGridViewCellStyle4.NullValue = Nothing
    Me.goodAmou.DefaultCellStyle = DataGridViewCellStyle4
    Me.goodAmou.HeaderText = "คงเหลือ"
    Me.goodAmou.Name = "goodAmou"
    Me.goodAmou.ReadOnly = True
    Me.goodAmou.Width = 80
    '
    'unitDesc
    '
    Me.unitDesc.HeaderText = "หน่วย"
    Me.unitDesc.Name = "unitDesc"
    Me.unitDesc.ReadOnly = True
    '
    'unitPrice
    '
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle5.Format = "N2"
    Me.unitPrice.DefaultCellStyle = DataGridViewCellStyle5
    Me.unitPrice.HeaderText = "ราคาขาย"
    Me.unitPrice.Name = "unitPrice"
    Me.unitPrice.ReadOnly = True
    '
    'SubTotal
    '
    DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle6.Format = "N2"
    Me.SubTotal.DefaultCellStyle = DataGridViewCellStyle6
    Me.SubTotal.HeaderText = "เป็นเงิน"
    Me.SubTotal.Name = "SubTotal"
    Me.SubTotal.ReadOnly = True
    '
    'radNotSale
    '
    Me.radNotSale.AutoSize = True
    Me.radNotSale.Location = New System.Drawing.Point(30, 50)
    Me.radNotSale.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.radNotSale.Name = "radNotSale"
    Me.radNotSale.Size = New System.Drawing.Size(213, 20)
    Me.radNotSale.TabIndex = 21
    Me.radNotSale.Text = "สินค้าที่ไม่มีการจำหน่ายตั้งแต่รับเข้า"
    Me.radNotSale.UseVisualStyleBackColor = True
    '
    'radNotMove
    '
    Me.radNotMove.AutoSize = True
    Me.radNotMove.Checked = True
    Me.radNotMove.Location = New System.Drawing.Point(30, 18)
    Me.radNotMove.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.radNotMove.Name = "radNotMove"
    Me.radNotMove.Size = New System.Drawing.Size(195, 20)
    Me.radNotMove.TabIndex = 20
    Me.radNotMove.TabStop = True
    Me.radNotMove.Text = "สินค้าที่ไม่มีการจำหน่ายเป็นเวลา"
    Me.radNotMove.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(299, 21)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(57, 16)
    Me.Label1.TabIndex = 22
    Me.Label1.Text = "วัน ขึ้นไป"
    '
    'btnPrint
    '
    Me.btnPrint.Location = New System.Drawing.Point(478, 15)
    Me.btnPrint.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnPrint.Name = "btnPrint"
    Me.btnPrint.Size = New System.Drawing.Size(93, 28)
    Me.btnPrint.TabIndex = 2
    Me.btnPrint.Text = "พิมพ์"
    Me.btnPrint.UseVisualStyleBackColor = True
    '
    'pdc1
    '
    '
    'lblSubTotal
    '
    Me.lblSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblSubTotal.Location = New System.Drawing.Point(422, 8)
    Me.lblSubTotal.Name = "lblSubTotal"
    Me.lblSubTotal.Size = New System.Drawing.Size(531, 16)
    Me.lblSubTotal.TabIndex = 2
    Me.lblSubTotal.Text = "รวมเป็นเงิน"
    Me.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer1.IsSplitterFixed = True
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.SplitContainer1.Name = "SplitContainer1"
    Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Plum
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtPage)
    Me.SplitContainer1.Panel1.Controls.Add(Me.radNotSale)
    Me.SplitContainer1.Panel1.Controls.Add(Me.radNotMove)
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnShow)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtDay)
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnPrint)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
    Me.SplitContainer1.Size = New System.Drawing.Size(969, 561)
    Me.SplitContainer1.SplitterDistance = 87
    Me.SplitContainer1.SplitterWidth = 5
    Me.SplitContainer1.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(583, 21)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(30, 16)
    Me.Label2.TabIndex = 24
    Me.Label2.Text = "หน้า"
    '
    'txtPage
    '
    Me.txtPage.Location = New System.Drawing.Point(620, 16)
    Me.txtPage.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtPage.Name = "txtPage"
    Me.txtPage.Size = New System.Drawing.Size(67, 23)
    Me.txtPage.TabIndex = 23
    '
    'SplitContainer2
    '
    Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
    Me.SplitContainer2.IsSplitterFixed = True
    Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.SplitContainer2.Name = "SplitContainer2"
    Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer2.Panel1
    '
    Me.SplitContainer2.Panel1.Controls.Add(Me.dtgView)
    '
    'SplitContainer2.Panel2
    '
    Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.Plum
    Me.SplitContainer2.Panel2.Controls.Add(Me.lblSubTotal)
    Me.SplitContainer2.Size = New System.Drawing.Size(969, 469)
    Me.SplitContainer2.SplitterDistance = 427
    Me.SplitContainer2.SplitterWidth = 5
    Me.SplitContainer2.TabIndex = 0
    '
    'frmRpGoodNotMove
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(969, 561)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmRpGoodNotMove"
    Me.Tag = "f3c"
    Me.Text = "รายงานสินค้าที่ไม่มีความเคลื่อนไหว"
    CType(Me.dtgView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    Me.SplitContainer2.Panel1.ResumeLayout(False)
    Me.SplitContainer2.Panel2.ResumeLayout(False)
    Me.SplitContainer2.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents txtDay As System.Windows.Forms.TextBox
  Friend WithEvents dtgView As System.Windows.Forms.DataGridView
  Friend WithEvents btnPrint As System.Windows.Forms.Button
  Friend WithEvents pdc1 As System.Drawing.Printing.PrintDocument
  Friend WithEvents radNotSale As System.Windows.Forms.RadioButton
  Friend WithEvents radNotMove As System.Windows.Forms.RadioButton
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents lblSubTotal As System.Windows.Forms.Label
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
  Friend WithEvents txtPage As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents itemLine As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents barCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents lastSale As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SubTotal As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
