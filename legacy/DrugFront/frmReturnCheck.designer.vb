<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReturnCheck
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
    Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
    Me.btnShow = New System.Windows.Forms.Button
    Me.dtpTo = New System.Windows.Forms.DateTimePicker
    Me.Label5 = New System.Windows.Forms.Label
    Me.dtpFrom = New System.Windows.Forms.DateTimePicker
    Me.Label1 = New System.Windows.Forms.Label
    Me.dtgHistReturn = New System.Windows.Forms.DataGridView
    Me.ReturnDate = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.ReturnTime = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.ReturnNumb = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SaleNumb = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.CashName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.TotalPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.ReturnRema = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.cardName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
    Me.lblSaleNumb = New System.Windows.Forms.Label
    Me.Label6 = New System.Windows.Forms.Label
    Me.lblReturnDate = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.lblReturnNumb = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.SplitContainer4 = New System.Windows.Forms.SplitContainer
    Me.dtgReturnList = New System.Windows.Forms.DataGridView
    Me.GoodAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Label7 = New System.Windows.Forms.Label
    Me.lblCardName = New System.Windows.Forms.Label
    Me.lblReturnRema = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.lblCashName = New System.Windows.Forms.Label
    Me.Label12 = New System.Windows.Forms.Label
    Me.lblTotalPrice = New System.Windows.Forms.Label
    Me.Label10 = New System.Windows.Forms.Label
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SplitContainer2.Panel1.SuspendLayout()
    Me.SplitContainer2.Panel2.SuspendLayout()
    Me.SplitContainer2.SuspendLayout()
    CType(Me.dtgHistReturn, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer3.Panel1.SuspendLayout()
    Me.SplitContainer3.Panel2.SuspendLayout()
    Me.SplitContainer3.SuspendLayout()
    Me.SplitContainer4.Panel1.SuspendLayout()
    Me.SplitContainer4.Panel2.SuspendLayout()
    Me.SplitContainer4.SuspendLayout()
    CType(Me.dtgReturnList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer1.IsSplitterFixed = True
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer1.Name = "SplitContainer1"
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
    Me.SplitContainer1.Size = New System.Drawing.Size(947, 527)
    Me.SplitContainer1.SplitterDistance = 290
    Me.SplitContainer1.TabIndex = 0
    '
    'SplitContainer2
    '
    Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer2.IsSplitterFixed = True
    Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer2.Name = "SplitContainer2"
    Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer2.Panel1
    '
    Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.PeachPuff
    Me.SplitContainer2.Panel1.Controls.Add(Me.btnShow)
    Me.SplitContainer2.Panel1.Controls.Add(Me.dtpTo)
    Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
    Me.SplitContainer2.Panel1.Controls.Add(Me.dtpFrom)
    Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
    '
    'SplitContainer2.Panel2
    '
    Me.SplitContainer2.Panel2.Controls.Add(Me.dtgHistReturn)
    Me.SplitContainer2.Size = New System.Drawing.Size(290, 527)
    Me.SplitContainer2.SplitterDistance = 98
    Me.SplitContainer2.TabIndex = 0
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(91, 67)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(115, 25)
    Me.btnShow.TabIndex = 0
    Me.btnShow.Text = "แสดงรายการ"
    Me.btnShow.UseVisualStyleBackColor = True
    '
    'dtpTo
    '
    Me.dtpTo.Location = New System.Drawing.Point(91, 38)
    Me.dtpTo.Name = "dtpTo"
    Me.dtpTo.Size = New System.Drawing.Size(166, 23)
    Me.dtpTo.TabIndex = 2
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(26, 38)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(45, 16)
    Me.Label5.TabIndex = 2
    Me.Label5.Text = "ถึงวันที่ี"
    '
    'dtpFrom
    '
    Me.dtpFrom.Location = New System.Drawing.Point(91, 9)
    Me.dtpFrom.Name = "dtpFrom"
    Me.dtpFrom.Size = New System.Drawing.Size(166, 23)
    Me.dtpFrom.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(26, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(61, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "ตั้งแต่วันที่"
    '
    'dtgHistReturn
    '
    Me.dtgHistReturn.AllowUserToAddRows = False
    Me.dtgHistReturn.AllowUserToDeleteRows = False
    Me.dtgHistReturn.AllowUserToResizeColumns = False
    Me.dtgHistReturn.AllowUserToResizeRows = False
    Me.dtgHistReturn.BackgroundColor = System.Drawing.Color.SeaShell
    DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgHistReturn.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
    Me.dtgHistReturn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReturnDate, Me.ReturnTime, Me.ReturnNumb, Me.SaleNumb, Me.CashName, Me.TotalPrice, Me.ReturnRema, Me.cardName})
    Me.dtgHistReturn.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgHistReturn.Location = New System.Drawing.Point(0, 0)
    Me.dtgHistReturn.Name = "dtgHistReturn"
    Me.dtgHistReturn.ReadOnly = True
    Me.dtgHistReturn.RowHeadersVisible = False
    Me.dtgHistReturn.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.PeachPuff
    Me.dtgHistReturn.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgHistReturn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.dtgHistReturn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgHistReturn.Size = New System.Drawing.Size(290, 425)
    Me.dtgHistReturn.TabIndex = 0
    '
    'ReturnDate
    '
    DataGridViewCellStyle9.Format = "d"
    DataGridViewCellStyle9.NullValue = Nothing
    Me.ReturnDate.DefaultCellStyle = DataGridViewCellStyle9
    Me.ReturnDate.HeaderText = "วันที่"
    Me.ReturnDate.Name = "ReturnDate"
    Me.ReturnDate.ReadOnly = True
    '
    'ReturnTime
    '
    Me.ReturnTime.HeaderText = "เวลา"
    Me.ReturnTime.Name = "ReturnTime"
    Me.ReturnTime.ReadOnly = True
    Me.ReturnTime.Width = 60
    '
    'ReturnNumb
    '
    Me.ReturnNumb.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.ReturnNumb.HeaderText = "เลขที่ใบคืน"
    Me.ReturnNumb.Name = "ReturnNumb"
    Me.ReturnNumb.ReadOnly = True
    '
    'SaleNumb
    '
    Me.SaleNumb.HeaderText = "saleNumb"
    Me.SaleNumb.Name = "SaleNumb"
    Me.SaleNumb.ReadOnly = True
    Me.SaleNumb.Visible = False
    '
    'CashName
    '
    Me.CashName.HeaderText = "cashName"
    Me.CashName.Name = "CashName"
    Me.CashName.ReadOnly = True
    Me.CashName.Visible = False
    '
    'TotalPrice
    '
    DataGridViewCellStyle10.Format = "N2"
    Me.TotalPrice.DefaultCellStyle = DataGridViewCellStyle10
    Me.TotalPrice.HeaderText = "totalPrice"
    Me.TotalPrice.Name = "TotalPrice"
    Me.TotalPrice.ReadOnly = True
    Me.TotalPrice.Visible = False
    '
    'ReturnRema
    '
    Me.ReturnRema.HeaderText = "returnRema"
    Me.ReturnRema.Name = "ReturnRema"
    Me.ReturnRema.ReadOnly = True
    Me.ReturnRema.Visible = False
    '
    'cardName
    '
    Me.cardName.HeaderText = "cardName"
    Me.cardName.Name = "cardName"
    Me.cardName.ReadOnly = True
    Me.cardName.Visible = False
    '
    'SplitContainer3
    '
    Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer3.IsSplitterFixed = True
    Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer3.Name = "SplitContainer3"
    Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer3.Panel1
    '
    Me.SplitContainer3.Panel1.BackColor = System.Drawing.Color.PeachPuff
    Me.SplitContainer3.Panel1.Controls.Add(Me.lblSaleNumb)
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label6)
    Me.SplitContainer3.Panel1.Controls.Add(Me.lblReturnDate)
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label4)
    Me.SplitContainer3.Panel1.Controls.Add(Me.lblReturnNumb)
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label2)
    '
    'SplitContainer3.Panel2
    '
    Me.SplitContainer3.Panel2.Controls.Add(Me.SplitContainer4)
    Me.SplitContainer3.Size = New System.Drawing.Size(653, 527)
    Me.SplitContainer3.SplitterDistance = 38
    Me.SplitContainer3.TabIndex = 0
    '
    'lblSaleNumb
    '
    Me.lblSaleNumb.BackColor = System.Drawing.Color.White
    Me.lblSaleNumb.Location = New System.Drawing.Point(433, 9)
    Me.lblSaleNumb.Name = "lblSaleNumb"
    Me.lblSaleNumb.Size = New System.Drawing.Size(141, 19)
    Me.lblSaleNumb.TabIndex = 5
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(354, 9)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(73, 16)
    Me.Label6.TabIndex = 4
    Me.Label6.Text = "เลขที่ใบขาย"
    '
    'lblReturnDate
    '
    Me.lblReturnDate.BackColor = System.Drawing.Color.White
    Me.lblReturnDate.Location = New System.Drawing.Point(239, 9)
    Me.lblReturnDate.Name = "lblReturnDate"
    Me.lblReturnDate.Size = New System.Drawing.Size(109, 19)
    Me.lblReturnDate.TabIndex = 3
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(202, 9)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(31, 16)
    Me.Label4.TabIndex = 2
    Me.Label4.Text = "วันที่"
    '
    'lblReturnNumb
    '
    Me.lblReturnNumb.BackColor = System.Drawing.Color.White
    Me.lblReturnNumb.Location = New System.Drawing.Point(87, 9)
    Me.lblReturnNumb.Name = "lblReturnNumb"
    Me.lblReturnNumb.Size = New System.Drawing.Size(109, 19)
    Me.lblReturnNumb.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(14, 9)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(67, 16)
    Me.Label2.TabIndex = 0
    Me.Label2.Text = "เลขที่ใบคืน"
    '
    'SplitContainer4
    '
    Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
    Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer4.Name = "SplitContainer4"
    Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer4.Panel1
    '
    Me.SplitContainer4.Panel1.Controls.Add(Me.dtgReturnList)
    '
    'SplitContainer4.Panel2
    '
    Me.SplitContainer4.Panel2.BackColor = System.Drawing.Color.PeachPuff
    Me.SplitContainer4.Panel2.Controls.Add(Me.Label7)
    Me.SplitContainer4.Panel2.Controls.Add(Me.lblCardName)
    Me.SplitContainer4.Panel2.Controls.Add(Me.lblReturnRema)
    Me.SplitContainer4.Panel2.Controls.Add(Me.Label3)
    Me.SplitContainer4.Panel2.Controls.Add(Me.lblCashName)
    Me.SplitContainer4.Panel2.Controls.Add(Me.Label12)
    Me.SplitContainer4.Panel2.Controls.Add(Me.lblTotalPrice)
    Me.SplitContainer4.Panel2.Controls.Add(Me.Label10)
    Me.SplitContainer4.Size = New System.Drawing.Size(653, 485)
    Me.SplitContainer4.SplitterDistance = 385
    Me.SplitContainer4.TabIndex = 0
    '
    'dtgReturnList
    '
    Me.dtgReturnList.AllowUserToAddRows = False
    Me.dtgReturnList.AllowUserToDeleteRows = False
    Me.dtgReturnList.AllowUserToResizeColumns = False
    Me.dtgReturnList.AllowUserToResizeRows = False
    Me.dtgReturnList.BackgroundColor = System.Drawing.Color.SeaShell
    DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgReturnList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
    Me.dtgReturnList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GoodAmou, Me.UnitDesc, Me.GoodName, Me.UnitPrice, Me.SubTotal})
    Me.dtgReturnList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgReturnList.Location = New System.Drawing.Point(0, 0)
    Me.dtgReturnList.Name = "dtgReturnList"
    Me.dtgReturnList.ReadOnly = True
    Me.dtgReturnList.RowHeadersVisible = False
    Me.dtgReturnList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.PeachPuff
    Me.dtgReturnList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgReturnList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.dtgReturnList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgReturnList.Size = New System.Drawing.Size(653, 385)
    Me.dtgReturnList.TabIndex = 1
    '
    'GoodAmou
    '
    DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    Me.GoodAmou.DefaultCellStyle = DataGridViewCellStyle12
    Me.GoodAmou.HeaderText = "จำนวน"
    Me.GoodAmou.Name = "GoodAmou"
    Me.GoodAmou.ReadOnly = True
    Me.GoodAmou.Width = 50
    '
    'UnitDesc
    '
    Me.UnitDesc.HeaderText = "หน่วย"
    Me.UnitDesc.Name = "UnitDesc"
    Me.UnitDesc.ReadOnly = True
    Me.UnitDesc.Width = 80
    '
    'GoodName
    '
    Me.GoodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.GoodName.HeaderText = "รายการ"
    Me.GoodName.Name = "GoodName"
    Me.GoodName.ReadOnly = True
    '
    'UnitPrice
    '
    DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle13.Format = "N2"
    Me.UnitPrice.DefaultCellStyle = DataGridViewCellStyle13
    Me.UnitPrice.HeaderText = "หน่วยละ"
    Me.UnitPrice.Name = "UnitPrice"
    Me.UnitPrice.ReadOnly = True
    Me.UnitPrice.Width = 60
    '
    'SubTotal
    '
    DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle14.Format = "N2"
    Me.SubTotal.DefaultCellStyle = DataGridViewCellStyle14
    Me.SubTotal.HeaderText = "เป็นเงิน"
    Me.SubTotal.Name = "SubTotal"
    Me.SubTotal.ReadOnly = True
    Me.SubTotal.Width = 80
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(408, 69)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(46, 16)
    Me.Label7.TabIndex = 13
    Me.Label7.Text = "คืนโดย"
    '
    'lblCardName
    '
    Me.lblCardName.BackColor = System.Drawing.Color.White
    Me.lblCardName.Location = New System.Drawing.Point(503, 68)
    Me.lblCardName.Name = "lblCardName"
    Me.lblCardName.Size = New System.Drawing.Size(138, 19)
    Me.lblCardName.TabIndex = 12
    Me.lblCardName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lblReturnRema
    '
    Me.lblReturnRema.BackColor = System.Drawing.Color.White
    Me.lblReturnRema.Location = New System.Drawing.Point(93, 39)
    Me.lblReturnRema.Name = "lblReturnRema"
    Me.lblReturnRema.Size = New System.Drawing.Size(289, 48)
    Me.lblReturnRema.TabIndex = 11
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(14, 39)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(58, 16)
    Me.Label3.TabIndex = 10
    Me.Label3.Text = "หมายเหตุ"
    '
    'lblCashName
    '
    Me.lblCashName.BackColor = System.Drawing.Color.White
    Me.lblCashName.Location = New System.Drawing.Point(93, 12)
    Me.lblCashName.Name = "lblCashName"
    Me.lblCashName.Size = New System.Drawing.Size(289, 19)
    Me.lblCashName.TabIndex = 9
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(14, 12)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(58, 16)
    Me.Label12.TabIndex = 8
    Me.Label12.Text = "แคชเชียร์"
    '
    'lblTotalPrice
    '
    Me.lblTotalPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblTotalPrice.BackColor = System.Drawing.Color.White
    Me.lblTotalPrice.Location = New System.Drawing.Point(503, 12)
    Me.lblTotalPrice.Name = "lblTotalPrice"
    Me.lblTotalPrice.Size = New System.Drawing.Size(138, 19)
    Me.lblTotalPrice.TabIndex = 7
    Me.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label10
    '
    Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(408, 12)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(62, 16)
    Me.Label10.TabIndex = 6
    Me.Label10.Text = "รวมคืนเงิน"
    '
    'frmReturnCheck
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(947, 527)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmReturnCheck"
    Me.Tag = "f1e"
    Me.Text = "ตรวจสอบการรับคืน"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    Me.SplitContainer2.Panel1.ResumeLayout(False)
    Me.SplitContainer2.Panel1.PerformLayout()
    Me.SplitContainer2.Panel2.ResumeLayout(False)
    Me.SplitContainer2.ResumeLayout(False)
    CType(Me.dtgHistReturn, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer3.Panel1.ResumeLayout(False)
    Me.SplitContainer3.Panel1.PerformLayout()
    Me.SplitContainer3.Panel2.ResumeLayout(False)
    Me.SplitContainer3.ResumeLayout(False)
    Me.SplitContainer4.Panel1.ResumeLayout(False)
    Me.SplitContainer4.Panel2.ResumeLayout(False)
    Me.SplitContainer4.Panel2.PerformLayout()
    Me.SplitContainer4.ResumeLayout(False)
    CType(Me.dtgReturnList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents dtgHistReturn As System.Windows.Forms.DataGridView
  Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
  Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
  Friend WithEvents lblReturnDate As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents lblReturnNumb As System.Windows.Forms.Label
  Friend WithEvents dtgReturnList As System.Windows.Forms.DataGridView
  Friend WithEvents lblCashName As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents lblTotalPrice As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents lblReturnRema As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents lblSaleNumb As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents GoodAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SubTotal As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents lblCardName As System.Windows.Forms.Label
  Friend WithEvents ReturnDate As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ReturnTime As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ReturnNumb As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SaleNumb As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents CashName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents TotalPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ReturnRema As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents cardName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
