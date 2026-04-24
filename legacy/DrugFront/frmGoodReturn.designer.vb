<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGoodReturn
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
    Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.lblUnitDesc2 = New System.Windows.Forms.Label
    Me.Label9 = New System.Windows.Forms.Label
    Me.txtStockOnhand = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.txtRemark = New System.Windows.Forms.TextBox
    Me.cboRetuCause = New System.Windows.Forms.ComboBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.dtpExpi = New System.Windows.Forms.DateTimePicker
    Me.btnNoExpi = New System.Windows.Forms.Button
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtLotNo = New System.Windows.Forms.TextBox
    Me.txtGoodName = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.btnAdd = New System.Windows.Forms.Button
    Me.lblUnitDesc = New System.Windows.Forms.Label
    Me.Label7 = New System.Windows.Forms.Label
    Me.txtGoodAmou = New System.Windows.Forms.TextBox
    Me.Label6 = New System.Windows.Forms.Label
    Me.txtBarcode = New System.Windows.Forms.TextBox
    Me.Label5 = New System.Windows.Forms.Label
    Me.dtgList = New System.Windows.Forms.DataGridView
    Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.BarCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.lotNo = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.expiDate = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.RetuRema = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.NoBranchStock = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.stockOnhand = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
    Me.tbnGoodSearch = New System.Windows.Forms.ToolStripButton
    Me.tbnClear = New System.Windows.Forms.ToolStripButton
    Me.tbnSave = New System.Windows.Forms.ToolStripButton
    Me.pdc1 = New System.Drawing.Printing.PrintDocument
    Me.cboLotNumber = New System.Windows.Forms.ComboBox
    Me.cboExpiDate = New System.Windows.Forms.ComboBox
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
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
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.SandyBrown
    Me.SplitContainer1.Panel1.Controls.Add(Me.cboExpiDate)
    Me.SplitContainer1.Panel1.Controls.Add(Me.cboLotNumber)
    Me.SplitContainer1.Panel1.Controls.Add(Me.lblUnitDesc2)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtStockOnhand)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtRemark)
    Me.SplitContainer1.Panel1.Controls.Add(Me.cboRetuCause)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
    Me.SplitContainer1.Panel1.Controls.Add(Me.dtpExpi)
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnNoExpi)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtLotNo)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtGoodName)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnAdd)
    Me.SplitContainer1.Panel1.Controls.Add(Me.lblUnitDesc)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtGoodAmou)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtBarcode)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.dtgList)
    Me.SplitContainer1.Size = New System.Drawing.Size(851, 438)
    Me.SplitContainer1.SplitterDistance = 145
    Me.SplitContainer1.SplitterWidth = 5
    Me.SplitContainer1.TabIndex = 0
    '
    'lblUnitDesc2
    '
    Me.lblUnitDesc2.AutoSize = True
    Me.lblUnitDesc2.Location = New System.Drawing.Point(205, 51)
    Me.lblUnitDesc2.Name = "lblUnitDesc2"
    Me.lblUnitDesc2.Size = New System.Drawing.Size(38, 16)
    Me.lblUnitDesc2.TabIndex = 29
    Me.lblUnitDesc2.Text = "หน่วย"
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(564, 20)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(50, 16)
    Me.Label9.TabIndex = 28
    Me.Label9.Text = "คงเหลือ"
    '
    'txtStockOnhand
    '
    Me.txtStockOnhand.Location = New System.Drawing.Point(629, 17)
    Me.txtStockOnhand.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtStockOnhand.Name = "txtStockOnhand"
    Me.txtStockOnhand.ReadOnly = True
    Me.txtStockOnhand.Size = New System.Drawing.Size(116, 23)
    Me.txtStockOnhand.TabIndex = 27
    Me.txtStockOnhand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(18, 112)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(58, 16)
    Me.Label3.TabIndex = 26
    Me.Label3.Text = "หมายเหตุ"
    '
    'txtRemark
    '
    Me.txtRemark.BackColor = System.Drawing.SystemColors.Window
    Me.txtRemark.Location = New System.Drawing.Point(83, 110)
    Me.txtRemark.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtRemark.MaxLength = 69
    Me.txtRemark.Name = "txtRemark"
    Me.txtRemark.Size = New System.Drawing.Size(473, 23)
    Me.txtRemark.TabIndex = 25
    '
    'cboRetuCause
    '
    Me.cboRetuCause.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboRetuCause.FormattingEnabled = True
    Me.cboRetuCause.Location = New System.Drawing.Point(392, 79)
    Me.cboRetuCause.Name = "cboRetuCause"
    Me.cboRetuCause.Size = New System.Drawing.Size(164, 24)
    Me.cboRetuCause.TabIndex = 5
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(318, 51)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(68, 16)
    Me.Label4.TabIndex = 24
    Me.Label4.Text = "วันหมดอายุ"
    '
    'dtpExpi
    '
    Me.dtpExpi.CustomFormat = ""
    Me.dtpExpi.Location = New System.Drawing.Point(392, 48)
    Me.dtpExpi.Name = "dtpExpi"
    Me.dtpExpi.Size = New System.Drawing.Size(164, 23)
    Me.dtpExpi.TabIndex = 4
    '
    'btnNoExpi
    '
    Me.btnNoExpi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.btnNoExpi.Location = New System.Drawing.Point(562, 48)
    Me.btnNoExpi.Name = "btnNoExpi"
    Me.btnNoExpi.Size = New System.Drawing.Size(19, 23)
    Me.btnNoExpi.TabIndex = 22
    Me.btnNoExpi.TabStop = False
    Me.btnNoExpi.Text = "x"
    Me.btnNoExpi.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(18, 81)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(47, 16)
    Me.Label2.TabIndex = 20
    Me.Label2.Text = "Lot no."
    '
    'txtLotNo
    '
    Me.txtLotNo.BackColor = System.Drawing.SystemColors.Window
    Me.txtLotNo.Location = New System.Drawing.Point(657, 63)
    Me.txtLotNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtLotNo.MaxLength = 15
    Me.txtLotNo.Name = "txtLotNo"
    Me.txtLotNo.Size = New System.Drawing.Size(73, 23)
    Me.txtLotNo.TabIndex = 2
    Me.txtLotNo.Visible = False
    '
    'txtGoodName
    '
    Me.txtGoodName.Location = New System.Drawing.Point(265, 17)
    Me.txtGoodName.Name = "txtGoodName"
    Me.txtGoodName.ReadOnly = True
    Me.txtGoodName.Size = New System.Drawing.Size(291, 23)
    Me.txtGoodName.TabIndex = 18
    Me.txtGoodName.TabStop = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(318, 82)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(67, 16)
    Me.Label1.TabIndex = 16
    Me.Label1.Text = "สาเหตุที่คืน"
    '
    'btnAdd
    '
    Me.btnAdd.Location = New System.Drawing.Point(580, 106)
    Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnAdd.Name = "btnAdd"
    Me.btnAdd.Size = New System.Drawing.Size(81, 28)
    Me.btnAdd.TabIndex = 3
    Me.btnAdd.Text = "เพิ่มรายการ"
    Me.btnAdd.UseVisualStyleBackColor = True
    '
    'lblUnitDesc
    '
    Me.lblUnitDesc.AutoSize = True
    Me.lblUnitDesc.Location = New System.Drawing.Point(751, 20)
    Me.lblUnitDesc.Name = "lblUnitDesc"
    Me.lblUnitDesc.Size = New System.Drawing.Size(38, 16)
    Me.lblUnitDesc.TabIndex = 14
    Me.lblUnitDesc.Text = "หน่วย"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(18, 51)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(59, 16)
    Me.Label7.TabIndex = 13
    Me.Label7.Text = "จำนวนคืน"
    '
    'txtGoodAmou
    '
    Me.txtGoodAmou.Location = New System.Drawing.Point(83, 48)
    Me.txtGoodAmou.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtGoodAmou.Name = "txtGoodAmou"
    Me.txtGoodAmou.Size = New System.Drawing.Size(116, 23)
    Me.txtGoodAmou.TabIndex = 1
    Me.txtGoodAmou.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(205, 20)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(54, 16)
    Me.Label6.TabIndex = 12
    Me.Label6.Text = "ชื่อสินค้า"
    '
    'txtBarcode
    '
    Me.txtBarcode.Location = New System.Drawing.Point(83, 17)
    Me.txtBarcode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtBarcode.Name = "txtBarcode"
    Me.txtBarcode.Size = New System.Drawing.Size(116, 23)
    Me.txtBarcode.TabIndex = 0
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(15, 20)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(60, 16)
    Me.Label5.TabIndex = 8
    Me.Label5.Text = "รหัสสินค้า"
    '
    'dtgList
    '
    Me.dtgList.AllowUserToAddRows = False
    Me.dtgList.AllowUserToResizeColumns = False
    Me.dtgList.AllowUserToResizeRows = False
    Me.dtgList.BackgroundColor = System.Drawing.Color.AntiqueWhite
    DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
    Me.dtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.GoodName, Me.GoodCode, Me.BarCode, Me.GoodAmou, Me.UnitDesc, Me.unitPrice, Me.lotNo, Me.expiDate, Me.RetuRema, Me.UnitCode, Me.UnitCost, Me.NoBranchStock, Me.stockOnhand})
    Me.dtgList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgList.Location = New System.Drawing.Point(0, 0)
    Me.dtgList.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dtgList.Name = "dtgList"
    Me.dtgList.ReadOnly = True
    Me.dtgList.RowHeadersVisible = False
    Me.dtgList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SandyBrown
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgList.Size = New System.Drawing.Size(851, 288)
    Me.dtgList.StandardTab = True
    Me.dtgList.TabIndex = 0
    Me.dtgList.TabStop = False
    '
    'Item
    '
    DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    Me.Item.DefaultCellStyle = DataGridViewCellStyle14
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
    Me.BarCode.Visible = False
    '
    'GoodAmou
    '
    DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle15.Format = "N0"
    Me.GoodAmou.DefaultCellStyle = DataGridViewCellStyle15
    Me.GoodAmou.HeaderText = "จำนวน"
    Me.GoodAmou.Name = "GoodAmou"
    Me.GoodAmou.ReadOnly = True
    Me.GoodAmou.Width = 80
    '
    'UnitDesc
    '
    Me.UnitDesc.HeaderText = "หน่วย"
    Me.UnitDesc.Name = "UnitDesc"
    Me.UnitDesc.ReadOnly = True
    '
    'unitPrice
    '
    DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle16.Format = "N0"
    Me.unitPrice.DefaultCellStyle = DataGridViewCellStyle16
    Me.unitPrice.HeaderText = "ขายต่อหน่วย"
    Me.unitPrice.Name = "unitPrice"
    Me.unitPrice.ReadOnly = True
    Me.unitPrice.Visible = False
    '
    'lotNo
    '
    Me.lotNo.HeaderText = "Lot no."
    Me.lotNo.Name = "lotNo"
    Me.lotNo.ReadOnly = True
    '
    'expiDate
    '
    DataGridViewCellStyle17.Format = "d"
    DataGridViewCellStyle17.NullValue = Nothing
    Me.expiDate.DefaultCellStyle = DataGridViewCellStyle17
    Me.expiDate.HeaderText = "วันหมดอายุ"
    Me.expiDate.Name = "expiDate"
    Me.expiDate.ReadOnly = True
    '
    'RetuRema
    '
    Me.RetuRema.HeaderText = "สาเหตุที่คืน"
    Me.RetuRema.Name = "RetuRema"
    Me.RetuRema.ReadOnly = True
    Me.RetuRema.Width = 150
    '
    'UnitCode
    '
    Me.UnitCode.HeaderText = "unitCode"
    Me.UnitCode.Name = "UnitCode"
    Me.UnitCode.ReadOnly = True
    Me.UnitCode.Visible = False
    '
    'UnitCost
    '
    DataGridViewCellStyle18.NullValue = Nothing
    Me.UnitCost.DefaultCellStyle = DataGridViewCellStyle18
    Me.UnitCost.HeaderText = "unitCost"
    Me.UnitCost.Name = "UnitCost"
    Me.UnitCost.ReadOnly = True
    Me.UnitCost.Visible = False
    '
    'NoBranchStock
    '
    Me.NoBranchStock.HeaderText = "noBranchStock"
    Me.NoBranchStock.Name = "NoBranchStock"
    Me.NoBranchStock.ReadOnly = True
    Me.NoBranchStock.Visible = False
    '
    'stockOnhand
    '
    Me.stockOnhand.HeaderText = "stockOnhand"
    Me.stockOnhand.Name = "stockOnhand"
    Me.stockOnhand.ReadOnly = True
    Me.stockOnhand.Visible = False
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbnGoodSearch, Me.tbnClear, Me.tbnSave})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.ShowItemToolTips = False
    Me.ToolStrip1.Size = New System.Drawing.Size(851, 25)
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
    'tbnClear
    '
    Me.tbnClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
    Me.tbnClear.Image = Global.DrugFront.My.Resources.Resources.filenew
    Me.tbnClear.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnClear.Name = "tbnClear"
    Me.tbnClear.Size = New System.Drawing.Size(83, 22)
    Me.tbnClear.Text = "Clear F12"
    '
    'tbnSave
    '
    Me.tbnSave.Image = Global.DrugFront.My.Resources.Resources.filesave
    Me.tbnSave.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnSave.Name = "tbnSave"
    Me.tbnSave.Size = New System.Drawing.Size(125, 22)
    Me.tbnSave.Text = "บันทึกคืนสินค้า F8"
    '
    'pdc1
    '
    '
    'cboLotNumber
    '
    Me.cboLotNumber.FormattingEnabled = True
    Me.cboLotNumber.Location = New System.Drawing.Point(83, 78)
    Me.cboLotNumber.Name = "cboLotNumber"
    Me.cboLotNumber.Size = New System.Drawing.Size(116, 24)
    Me.cboLotNumber.TabIndex = 30
    '
    'cboExpiDate
    '
    Me.cboExpiDate.FormattingEnabled = True
    Me.cboExpiDate.Location = New System.Drawing.Point(736, 63)
    Me.cboExpiDate.Name = "cboExpiDate"
    Me.cboExpiDate.Size = New System.Drawing.Size(75, 24)
    Me.cboExpiDate.TabIndex = 31
    Me.cboExpiDate.Visible = False
    '
    'frmGoodReturn
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(851, 463)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmGoodReturn"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Tag = "f2c"
    Me.Text = "ส่งคืนสินค้า"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
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
  Friend WithEvents tbnClear As System.Windows.Forms.ToolStripButton
  Friend WithEvents tbnGoodSearch As System.Windows.Forms.ToolStripButton
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents btnAdd As System.Windows.Forms.Button
  Friend WithEvents lblUnitDesc As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents txtGoodAmou As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents pdc1 As System.Drawing.Printing.PrintDocument
  Friend WithEvents txtGoodName As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtLotNo As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents dtpExpi As System.Windows.Forms.DateTimePicker
  Friend WithEvents btnNoExpi As System.Windows.Forms.Button
  Friend WithEvents cboRetuCause As System.Windows.Forms.ComboBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtRemark As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents txtStockOnhand As System.Windows.Forms.TextBox
  Friend WithEvents lblUnitDesc2 As System.Windows.Forms.Label
  Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents BarCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents lotNo As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents expiDate As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents RetuRema As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents NoBranchStock As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents stockOnhand As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents cboExpiDate As System.Windows.Forms.ComboBox
  Friend WithEvents cboLotNumber As System.Windows.Forms.ComboBox

End Class
