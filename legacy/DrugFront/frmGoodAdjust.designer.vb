<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGoodAdjust
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
    Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.btnClearStockCount = New System.Windows.Forms.Button
    Me.btnImportCount = New System.Windows.Forms.Button
    Me.lblUnitDesc = New System.Windows.Forms.Label
    Me.lblStockOnhand = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.lblGoodName = New System.Windows.Forms.Label
    Me.btnAdd = New System.Windows.Forms.Button
    Me.Label7 = New System.Windows.Forms.Label
    Me.txtGoodCount = New System.Windows.Forms.TextBox
    Me.Label6 = New System.Windows.Forms.Label
    Me.txtBarcode = New System.Windows.Forms.TextBox
    Me.Label5 = New System.Windows.Forms.Label
    Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
    Me.lblInform = New System.Windows.Forms.Label
    Me.dtgList = New System.Windows.Forms.DataGridView
    Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.BarCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.StockOnhand = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodCount = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodAdjust = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.totalCost = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitCost = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.txtAllTotalCost = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
    Me.tbnGoodSearch = New System.Windows.Forms.ToolStripButton
    Me.tbnTempSave = New System.Windows.Forms.ToolStripButton
    Me.tbnSave = New System.Windows.Forms.ToolStripButton
    Me.tbnClear = New System.Windows.Forms.ToolStripButton
    Me.pdc1 = New System.Drawing.Printing.PrintDocument
    Me.txtRemark = New System.Windows.Forms.TextBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SplitContainer2.Panel1.SuspendLayout()
    Me.SplitContainer2.Panel2.SuspendLayout()
    Me.SplitContainer2.SuspendLayout()
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ToolStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer1.IsSplitterFixed = True
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
    Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.SplitContainer1.Name = "SplitContainer1"
    Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.YellowGreen
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnClearStockCount)
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnImportCount)
    Me.SplitContainer1.Panel1.Controls.Add(Me.lblUnitDesc)
    Me.SplitContainer1.Panel1.Controls.Add(Me.lblStockOnhand)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
    Me.SplitContainer1.Panel1.Controls.Add(Me.lblGoodName)
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnAdd)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtGoodCount)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtBarcode)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
    Me.SplitContainer1.Size = New System.Drawing.Size(1063, 619)
    Me.SplitContainer1.SplitterDistance = 83
    Me.SplitContainer1.SplitterWidth = 5
    Me.SplitContainer1.TabIndex = 0
    Me.SplitContainer1.TabStop = False
    '
    'btnClearStockCount
    '
    Me.btnClearStockCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnClearStockCount.Location = New System.Drawing.Point(786, 8)
    Me.btnClearStockCount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnClearStockCount.Name = "btnClearStockCount"
    Me.btnClearStockCount.Size = New System.Drawing.Size(265, 28)
    Me.btnClearStockCount.TabIndex = 24
    Me.btnClearStockCount.Text = "ล้างข้อมูลนับสต๊อคในเครื่อง Handheld"
    Me.btnClearStockCount.UseVisualStyleBackColor = True
    '
    'btnImportCount
    '
    Me.btnImportCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnImportCount.Location = New System.Drawing.Point(786, 37)
    Me.btnImportCount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnImportCount.Name = "btnImportCount"
    Me.btnImportCount.Size = New System.Drawing.Size(265, 28)
    Me.btnImportCount.TabIndex = 23
    Me.btnImportCount.Text = "นำเข้าข้อมูลนับสต๊อคจากเครื่อง Handheld"
    Me.btnImportCount.UseVisualStyleBackColor = True
    '
    'lblUnitDesc
    '
    Me.lblUnitDesc.BackColor = System.Drawing.Color.Honeydew
    Me.lblUnitDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblUnitDesc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblUnitDesc.ForeColor = System.Drawing.SystemColors.WindowText
    Me.lblUnitDesc.Location = New System.Drawing.Point(397, 40)
    Me.lblUnitDesc.Name = "lblUnitDesc"
    Me.lblUnitDesc.Size = New System.Drawing.Size(128, 23)
    Me.lblUnitDesc.TabIndex = 22
    '
    'lblStockOnhand
    '
    Me.lblStockOnhand.BackColor = System.Drawing.Color.Honeydew
    Me.lblStockOnhand.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblStockOnhand.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblStockOnhand.ForeColor = System.Drawing.SystemColors.WindowText
    Me.lblStockOnhand.Location = New System.Drawing.Point(103, 40)
    Me.lblStockOnhand.Name = "lblStockOnhand"
    Me.lblStockOnhand.Size = New System.Drawing.Size(116, 23)
    Me.lblStockOnhand.TabIndex = 20
    Me.lblStockOnhand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 43)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(82, 16)
    Me.Label3.TabIndex = 19
    Me.Label3.Text = "สต๊อคคงเหลือ"
    '
    'lblGoodName
    '
    Me.lblGoodName.BackColor = System.Drawing.Color.Honeydew
    Me.lblGoodName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblGoodName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblGoodName.ForeColor = System.Drawing.SystemColors.WindowText
    Me.lblGoodName.Location = New System.Drawing.Point(317, 13)
    Me.lblGoodName.Name = "lblGoodName"
    Me.lblGoodName.Size = New System.Drawing.Size(208, 23)
    Me.lblGoodName.TabIndex = 17
    '
    'btnAdd
    '
    Me.btnAdd.Location = New System.Drawing.Point(540, 37)
    Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnAdd.Name = "btnAdd"
    Me.btnAdd.Size = New System.Drawing.Size(102, 28)
    Me.btnAdd.TabIndex = 2
    Me.btnAdd.Text = "บันทึกจำนวน"
    Me.btnAdd.UseVisualStyleBackColor = True
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(230, 43)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(81, 16)
    Me.Label7.TabIndex = 13
    Me.Label7.Text = "คงเหลือนับได้"
    '
    'txtGoodCount
    '
    Me.txtGoodCount.Location = New System.Drawing.Point(317, 40)
    Me.txtGoodCount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtGoodCount.Name = "txtGoodCount"
    Me.txtGoodCount.Size = New System.Drawing.Size(74, 23)
    Me.txtGoodCount.TabIndex = 1
    Me.txtGoodCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(230, 16)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(54, 16)
    Me.Label6.TabIndex = 12
    Me.Label6.Text = "ชื่อสินค้า"
    '
    'txtBarcode
    '
    Me.txtBarcode.Location = New System.Drawing.Point(103, 13)
    Me.txtBarcode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtBarcode.Name = "txtBarcode"
    Me.txtBarcode.Size = New System.Drawing.Size(116, 23)
    Me.txtBarcode.TabIndex = 0
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(12, 16)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(60, 16)
    Me.Label5.TabIndex = 8
    Me.Label5.Text = "รหัสสินค้า"
    '
    'SplitContainer2
    '
    Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
    Me.SplitContainer2.IsSplitterFixed = True
    Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer2.Name = "SplitContainer2"
    Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer2.Panel1
    '
    Me.SplitContainer2.Panel1.Controls.Add(Me.lblInform)
    Me.SplitContainer2.Panel1.Controls.Add(Me.dtgList)
    '
    'SplitContainer2.Panel2
    '
    Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.YellowGreen
    Me.SplitContainer2.Panel2.Controls.Add(Me.txtRemark)
    Me.SplitContainer2.Panel2.Controls.Add(Me.Label2)
    Me.SplitContainer2.Panel2.Controls.Add(Me.txtAllTotalCost)
    Me.SplitContainer2.Panel2.Controls.Add(Me.Label1)
    Me.SplitContainer2.Size = New System.Drawing.Size(1063, 531)
    Me.SplitContainer2.SplitterDistance = 488
    Me.SplitContainer2.TabIndex = 1
    Me.SplitContainer2.TabStop = False
    '
    'lblInform
    '
    Me.lblInform.AutoSize = True
    Me.lblInform.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblInform.ForeColor = System.Drawing.Color.DarkRed
    Me.lblInform.Location = New System.Drawing.Point(12, 32)
    Me.lblInform.Name = "lblInform"
    Me.lblInform.Size = New System.Drawing.Size(183, 16)
    Me.lblInform.TabIndex = 0
    Me.lblInform.Text = "กำลังจัดเตรียมข้อมูล โปรดรอ....."
    '
    'dtgList
    '
    Me.dtgList.AllowUserToAddRows = False
    Me.dtgList.AllowUserToResizeRows = False
    Me.dtgList.BackgroundColor = System.Drawing.Color.Honeydew
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    Me.dtgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.GoodName, Me.GoodCode, Me.BarCode, Me.UnitDesc, Me.unitPrice, Me.StockOnhand, Me.GoodCount, Me.GoodAdjust, Me.totalCost, Me.UnitCode, Me.unitCost})
    Me.dtgList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgList.Location = New System.Drawing.Point(0, 0)
    Me.dtgList.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dtgList.Name = "dtgList"
    Me.dtgList.ReadOnly = True
    Me.dtgList.RowHeadersVisible = False
    Me.dtgList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.YellowGreen
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgList.Size = New System.Drawing.Size(1063, 488)
    Me.dtgList.StandardTab = True
    Me.dtgList.TabIndex = 0
    '
    'Item
    '
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    Me.Item.DefaultCellStyle = DataGridViewCellStyle2
    Me.Item.HeaderText = ""
    Me.Item.Name = "Item"
    Me.Item.ReadOnly = True
    Me.Item.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
    Me.Item.Width = 40
    '
    'GoodName
    '
    Me.GoodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.GoodName.HeaderText = "รายการ"
    Me.GoodName.Name = "GoodName"
    Me.GoodName.ReadOnly = True
    '
    'GoodCode
    '
    Me.GoodCode.HeaderText = "goodCode"
    Me.GoodCode.Name = "GoodCode"
    Me.GoodCode.ReadOnly = True
    Me.GoodCode.Visible = False
    '
    'BarCode
    '
    Me.BarCode.HeaderText = "รหัสสินค้า"
    Me.BarCode.Name = "BarCode"
    Me.BarCode.ReadOnly = True
    '
    'UnitDesc
    '
    Me.UnitDesc.HeaderText = "หน่วย"
    Me.UnitDesc.Name = "UnitDesc"
    Me.UnitDesc.ReadOnly = True
    '
    'unitPrice
    '
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle3.Format = "N2"
    Me.unitPrice.DefaultCellStyle = DataGridViewCellStyle3
    Me.unitPrice.HeaderText = "@"
    Me.unitPrice.Name = "unitPrice"
    Me.unitPrice.ReadOnly = True
    '
    'StockOnhand
    '
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle4.Format = "N0"
    Me.StockOnhand.DefaultCellStyle = DataGridViewCellStyle4
    Me.StockOnhand.HeaderText = "สต๊อคคงเหลือ"
    Me.StockOnhand.Name = "StockOnhand"
    Me.StockOnhand.ReadOnly = True
    '
    'GoodCount
    '
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle5.Format = "N0"
    Me.GoodCount.DefaultCellStyle = DataGridViewCellStyle5
    Me.GoodCount.HeaderText = "คงเหลือนับได้"
    Me.GoodCount.Name = "GoodCount"
    Me.GoodCount.ReadOnly = True
    '
    'GoodAdjust
    '
    DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle6.Format = "N0"
    Me.GoodAdjust.DefaultCellStyle = DataGridViewCellStyle6
    Me.GoodAdjust.HeaderText = "ขาด-เกิน"
    Me.GoodAdjust.Name = "GoodAdjust"
    Me.GoodAdjust.ReadOnly = True
    Me.GoodAdjust.Width = 80
    '
    'totalCost
    '
    DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle7.Format = "N2"
    Me.totalCost.DefaultCellStyle = DataGridViewCellStyle7
    Me.totalCost.HeaderText = "มูลค่าสินค้า"
    Me.totalCost.Name = "totalCost"
    Me.totalCost.ReadOnly = True
    '
    'UnitCode
    '
    Me.UnitCode.HeaderText = "unitCode"
    Me.UnitCode.Name = "UnitCode"
    Me.UnitCode.ReadOnly = True
    Me.UnitCode.Visible = False
    '
    'unitCost
    '
    Me.unitCost.HeaderText = "unitCost"
    Me.unitCost.Name = "unitCost"
    Me.unitCost.ReadOnly = True
    Me.unitCost.Visible = False
    '
    'txtAllTotalCost
    '
    Me.txtAllTotalCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtAllTotalCost.Location = New System.Drawing.Point(951, 9)
    Me.txtAllTotalCost.Name = "txtAllTotalCost"
    Me.txtAllTotalCost.ReadOnly = True
    Me.txtAllTotalCost.Size = New System.Drawing.Size(100, 23)
    Me.txtAllTotalCost.TabIndex = 1
    Me.txtAllTotalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label1
    '
    Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(877, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(58, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "รวมมูลค่า"
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbnGoodSearch, Me.tbnTempSave, Me.tbnSave, Me.tbnClear})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.ShowItemToolTips = False
    Me.ToolStrip1.Size = New System.Drawing.Size(1063, 25)
    Me.ToolStrip1.TabIndex = 1
    Me.ToolStrip1.Text = "ToolStrip1"
    '
    'tbnGoodSearch
    '
    Me.tbnGoodSearch.Image = Global.DrugFront.My.Resources.Resources.search
    Me.tbnGoodSearch.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnGoodSearch.Name = "tbnGoodSearch"
    Me.tbnGoodSearch.Size = New System.Drawing.Size(106, 22)
    Me.tbnGoodSearch.Text = "ค้นหาสินค้า F4"
    '
    'tbnTempSave
    '
    Me.tbnTempSave.ForeColor = System.Drawing.Color.DarkRed
    Me.tbnTempSave.Image = Global.DrugFront.My.Resources.Resources.filesave
    Me.tbnTempSave.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnTempSave.Name = "tbnTempSave"
    Me.tbnTempSave.Size = New System.Drawing.Size(185, 22)
    Me.tbnTempSave.Text = "บันทึกจำนวนนับได้ชั่วคราว F6"
    '
    'tbnSave
    '
    Me.tbnSave.Image = Global.DrugFront.My.Resources.Resources.filesave
    Me.tbnSave.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnSave.Name = "tbnSave"
    Me.tbnSave.Size = New System.Drawing.Size(125, 22)
    Me.tbnSave.Text = "บันทึกปรับยอด F8"
    '
    'tbnClear
    '
    Me.tbnClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
    Me.tbnClear.Image = Global.DrugFront.My.Resources.Resources.delete
    Me.tbnClear.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnClear.Name = "tbnClear"
    Me.tbnClear.Size = New System.Drawing.Size(219, 22)
    Me.tbnClear.Text = "ล้างข้อมูลบันทึกจำนวนนับได้ชั่วคราว"
    '
    'txtRemark
    '
    Me.txtRemark.Location = New System.Drawing.Point(88, 9)
    Me.txtRemark.Name = "txtRemark"
    Me.txtRemark.Size = New System.Drawing.Size(510, 23)
    Me.txtRemark.TabIndex = 3
    Me.txtRemark.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(14, 12)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(58, 16)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "หมายเหตุ"
    '
    'frmGoodAdjust
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1063, 644)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmGoodAdjust"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Tag = "f2f"
    Me.Text = "ปรับยอดสต๊อคสินค้า"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    Me.SplitContainer2.Panel1.ResumeLayout(False)
    Me.SplitContainer2.Panel1.PerformLayout()
    Me.SplitContainer2.Panel2.ResumeLayout(False)
    Me.SplitContainer2.Panel2.PerformLayout()
    Me.SplitContainer2.ResumeLayout(False)
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents dtgList As System.Windows.Forms.DataGridView
  Friend WithEvents tbnSave As System.Windows.Forms.ToolStripButton
  Friend WithEvents tbnGoodSearch As System.Windows.Forms.ToolStripButton
  Friend WithEvents btnAdd As System.Windows.Forms.Button
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents txtGoodCount As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents lblGoodName As System.Windows.Forms.Label
  Friend WithEvents pdc1 As System.Drawing.Printing.PrintDocument
  Friend WithEvents lblStockOnhand As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents lblUnitDesc As System.Windows.Forms.Label
  Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
  Friend WithEvents tbnTempSave As System.Windows.Forms.ToolStripButton
  Friend WithEvents tbnClear As System.Windows.Forms.ToolStripButton
  Friend WithEvents btnImportCount As System.Windows.Forms.Button
  Friend WithEvents btnClearStockCount As System.Windows.Forms.Button
  Friend WithEvents lblInform As System.Windows.Forms.Label
  Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents BarCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents StockOnhand As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodCount As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodAdjust As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents totalCost As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitCost As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents txtAllTotalCost As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtRemark As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
