<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGoodOrder
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
    Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.sct1 = New System.Windows.Forms.SplitContainer
    Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
    Me.SplitContainer4 = New System.Windows.Forms.SplitContainer
    Me.lblShipTo = New System.Windows.Forms.Label
    Me.lblShipTo1 = New System.Windows.Forms.Label
    Me.lblPackSale = New System.Windows.Forms.Label
    Me.lblOrderUnitDesc = New System.Windows.Forms.Label
    Me.Label11 = New System.Windows.Forms.Label
    Me.lblPackDesc = New System.Windows.Forms.Label
    Me.txtBarcode = New System.Windows.Forms.TextBox
    Me.lblGoodName = New System.Windows.Forms.Label
    Me.lblUrgentOrder = New System.Windows.Forms.Label
    Me.lblGoodRema = New System.Windows.Forms.Label
    Me.Label5 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.lblMiniStock = New System.Windows.Forms.Label
    Me.lblBranchOnhand = New System.Windows.Forms.Label
    Me.Label6 = New System.Windows.Forms.Label
    Me.btnAdd = New System.Windows.Forms.Button
    Me.Label10 = New System.Windows.Forms.Label
    Me.Label8 = New System.Windows.Forms.Label
    Me.txtGoodAmou = New System.Windows.Forms.TextBox
    Me.Label7 = New System.Windows.Forms.Label
    Me.lblUnitDesc = New System.Windows.Forms.Label
    Me.dtgList = New System.Windows.Forms.DataGridView
    Me.Label4 = New System.Windows.Forms.Label
    Me.lblTotalPrice = New System.Windows.Forms.Label
    Me.txtRemark = New System.Windows.Forms.TextBox
    Me.Label12 = New System.Windows.Forms.Label
    Me.lblAvaiOnhand = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
    Me.chkMiniStock = New System.Windows.Forms.CheckBox
    Me.btnShow = New System.Windows.Forms.Button
    Me.Label9 = New System.Windows.Forms.Label
    Me.cboTypeCode = New System.Windows.Forms.ComboBox
    Me.cboTypeDesc = New System.Windows.Forms.ComboBox
    Me.txtName = New System.Windows.Forms.TextBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.dtgGoodSearch = New System.Windows.Forms.DataGridView
    Me.SBarCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SGoodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.STypeDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SUnitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SMiniStock = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SStockOnhand = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SPackDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SGoodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SGoodRema = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SStockOnhand0 = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SStockOnhandDN = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SUnitCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SPrice1 = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SPackAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
    Me.tbnPendOrder = New System.Windows.Forms.ToolStripButton
    Me.tbnUrgentOrder = New System.Windows.Forms.ToolStripButton
    Me.tbnTempSave = New System.Windows.Forms.ToolStripButton
    Me.tbnSave = New System.Windows.Forms.ToolStripButton
    Me.tbnRefresh = New System.Windows.Forms.ToolStripButton
    Me.tbnImportList = New System.Windows.Forms.ToolStripButton
    Me.tbnPrint = New System.Windows.Forms.ToolStripButton
    Me.pdc1 = New System.Drawing.Printing.PrintDocument
    Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.BarCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.TypeDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.MiniStock = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.StockOnhand = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.avaiOnhand = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodRema = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.StockOnhand0 = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.stockOnhandDN = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.shipTo = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitFactor = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.isPending = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.packFactor = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.sct1.Panel1.SuspendLayout()
    Me.sct1.Panel2.SuspendLayout()
    Me.sct1.SuspendLayout()
    Me.SplitContainer2.Panel1.SuspendLayout()
    Me.SplitContainer2.Panel2.SuspendLayout()
    Me.SplitContainer2.SuspendLayout()
    Me.SplitContainer4.Panel1.SuspendLayout()
    Me.SplitContainer4.Panel2.SuspendLayout()
    Me.SplitContainer4.SuspendLayout()
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer3.Panel1.SuspendLayout()
    Me.SplitContainer3.Panel2.SuspendLayout()
    Me.SplitContainer3.SuspendLayout()
    CType(Me.dtgGoodSearch, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ToolStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'sct1
    '
    Me.sct1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.sct1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
    Me.sct1.IsSplitterFixed = True
    Me.sct1.Location = New System.Drawing.Point(0, 31)
    Me.sct1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.sct1.Name = "sct1"
    Me.sct1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'sct1.Panel1
    '
    Me.sct1.Panel1.BackColor = System.Drawing.SystemColors.Control
    Me.sct1.Panel1.Controls.Add(Me.SplitContainer2)
    '
    'sct1.Panel2
    '
    Me.sct1.Panel2.Controls.Add(Me.SplitContainer3)
    Me.sct1.Size = New System.Drawing.Size(1143, 617)
    Me.sct1.SplitterDistance = 385
    Me.sct1.SplitterWidth = 5
    Me.sct1.TabIndex = 0
    Me.sct1.TabStop = False
    '
    'SplitContainer2
    '
    Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
    Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer2.Name = "SplitContainer2"
    Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer2.Panel1
    '
    Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer4)
    '
    'SplitContainer2.Panel2
    '
    Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.Violet
    Me.SplitContainer2.Panel2.Controls.Add(Me.Label4)
    Me.SplitContainer2.Panel2.Controls.Add(Me.lblTotalPrice)
    Me.SplitContainer2.Panel2.Controls.Add(Me.txtRemark)
    Me.SplitContainer2.Panel2.Controls.Add(Me.Label12)
    Me.SplitContainer2.Panel2.Controls.Add(Me.lblAvaiOnhand)
    Me.SplitContainer2.Panel2.Controls.Add(Me.Label1)
    Me.SplitContainer2.Size = New System.Drawing.Size(1143, 385)
    Me.SplitContainer2.SplitterDistance = 340
    Me.SplitContainer2.TabIndex = 0
    Me.SplitContainer2.TabStop = False
    '
    'SplitContainer4
    '
    Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer4.IsSplitterFixed = True
    Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer4.Name = "SplitContainer4"
    Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer4.Panel1
    '
    Me.SplitContainer4.Panel1.BackColor = System.Drawing.Color.Violet
    Me.SplitContainer4.Panel1.Controls.Add(Me.lblShipTo)
    Me.SplitContainer4.Panel1.Controls.Add(Me.lblShipTo1)
    Me.SplitContainer4.Panel1.Controls.Add(Me.lblPackSale)
    Me.SplitContainer4.Panel1.Controls.Add(Me.lblOrderUnitDesc)
    Me.SplitContainer4.Panel1.Controls.Add(Me.Label11)
    Me.SplitContainer4.Panel1.Controls.Add(Me.lblPackDesc)
    Me.SplitContainer4.Panel1.Controls.Add(Me.txtBarcode)
    Me.SplitContainer4.Panel1.Controls.Add(Me.lblGoodName)
    Me.SplitContainer4.Panel1.Controls.Add(Me.lblUrgentOrder)
    Me.SplitContainer4.Panel1.Controls.Add(Me.lblGoodRema)
    Me.SplitContainer4.Panel1.Controls.Add(Me.Label5)
    Me.SplitContainer4.Panel1.Controls.Add(Me.Label3)
    Me.SplitContainer4.Panel1.Controls.Add(Me.lblMiniStock)
    Me.SplitContainer4.Panel1.Controls.Add(Me.lblBranchOnhand)
    Me.SplitContainer4.Panel1.Controls.Add(Me.Label6)
    Me.SplitContainer4.Panel1.Controls.Add(Me.btnAdd)
    Me.SplitContainer4.Panel1.Controls.Add(Me.Label10)
    Me.SplitContainer4.Panel1.Controls.Add(Me.Label8)
    Me.SplitContainer4.Panel1.Controls.Add(Me.txtGoodAmou)
    Me.SplitContainer4.Panel1.Controls.Add(Me.Label7)
    Me.SplitContainer4.Panel1.Controls.Add(Me.lblUnitDesc)
    '
    'SplitContainer4.Panel2
    '
    Me.SplitContainer4.Panel2.Controls.Add(Me.dtgList)
    Me.SplitContainer4.Size = New System.Drawing.Size(1143, 340)
    Me.SplitContainer4.SplitterDistance = 84
    Me.SplitContainer4.TabIndex = 0
    Me.SplitContainer4.TabStop = False
    '
    'lblShipTo
    '
    Me.lblShipTo.BackColor = System.Drawing.Color.LavenderBlush
    Me.lblShipTo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblShipTo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblShipTo.Location = New System.Drawing.Point(627, 47)
    Me.lblShipTo.Name = "lblShipTo"
    Me.lblShipTo.Size = New System.Drawing.Size(64, 23)
    Me.lblShipTo.TabIndex = 33
    Me.lblShipTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lblShipTo1
    '
    Me.lblShipTo1.AutoSize = True
    Me.lblShipTo1.Location = New System.Drawing.Point(559, 50)
    Me.lblShipTo1.Name = "lblShipTo1"
    Me.lblShipTo1.Size = New System.Drawing.Size(52, 16)
    Me.lblShipTo1.TabIndex = 31
    Me.lblShipTo1.Text = "Ship To"
    '
    'lblPackSale
    '
    Me.lblPackSale.AutoSize = True
    Me.lblPackSale.ForeColor = System.Drawing.Color.DarkRed
    Me.lblPackSale.Location = New System.Drawing.Point(890, 19)
    Me.lblPackSale.Name = "lblPackSale"
    Me.lblPackSale.Size = New System.Drawing.Size(71, 16)
    Me.lblPackSale.TabIndex = 32
    Me.lblPackSale.Text = "ขายยกแพ็ค"
    Me.lblPackSale.Visible = False
    '
    'lblOrderUnitDesc
    '
    Me.lblOrderUnitDesc.AutoSize = True
    Me.lblOrderUnitDesc.Location = New System.Drawing.Point(890, 50)
    Me.lblOrderUnitDesc.Name = "lblOrderUnitDesc"
    Me.lblOrderUnitDesc.Size = New System.Drawing.Size(38, 16)
    Me.lblOrderUnitDesc.TabIndex = 30
    Me.lblOrderUnitDesc.Text = "หน่วย"
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(559, 19)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(62, 16)
    Me.Label11.TabIndex = 29
    Me.Label11.Text = "หน่วยย่อย"
    '
    'lblPackDesc
    '
    Me.lblPackDesc.BackColor = System.Drawing.Color.LavenderBlush
    Me.lblPackDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblPackDesc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblPackDesc.Location = New System.Drawing.Point(768, 16)
    Me.lblPackDesc.Name = "lblPackDesc"
    Me.lblPackDesc.Size = New System.Drawing.Size(116, 23)
    Me.lblPackDesc.TabIndex = 26
    Me.lblPackDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'txtBarcode
    '
    Me.txtBarcode.Location = New System.Drawing.Point(106, 16)
    Me.txtBarcode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtBarcode.Name = "txtBarcode"
    Me.txtBarcode.Size = New System.Drawing.Size(116, 23)
    Me.txtBarcode.TabIndex = 0
    '
    'lblGoodName
    '
    Me.lblGoodName.BackColor = System.Drawing.Color.LavenderBlush
    Me.lblGoodName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblGoodName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblGoodName.Location = New System.Drawing.Point(318, 16)
    Me.lblGoodName.Name = "lblGoodName"
    Me.lblGoodName.Size = New System.Drawing.Size(235, 23)
    Me.lblGoodName.TabIndex = 17
    Me.lblGoodName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lblUrgentOrder
    '
    Me.lblUrgentOrder.AutoSize = True
    Me.lblUrgentOrder.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblUrgentOrder.ForeColor = System.Drawing.Color.DarkRed
    Me.lblUrgentOrder.Location = New System.Drawing.Point(1074, 50)
    Me.lblUrgentOrder.Name = "lblUrgentOrder"
    Me.lblUrgentOrder.Size = New System.Drawing.Size(57, 16)
    Me.lblUrgentOrder.TabIndex = 25
    Me.lblUrgentOrder.Text = "สั่งด่วน !"
    Me.lblUrgentOrder.Visible = False
    '
    'lblGoodRema
    '
    Me.lblGoodRema.AutoSize = True
    Me.lblGoodRema.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblGoodRema.ForeColor = System.Drawing.Color.DarkRed
    Me.lblGoodRema.Location = New System.Drawing.Point(1004, 16)
    Me.lblGoodRema.Name = "lblGoodRema"
    Me.lblGoodRema.Size = New System.Drawing.Size(127, 18)
    Me.lblGoodRema.TabIndex = 18
    Me.lblGoodRema.Text = "สินค้าขาดชั่วคราว"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(18, 19)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(60, 16)
    Me.Label5.TabIndex = 8
    Me.Label5.Text = "รหัสสินค้า"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(18, 50)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(54, 16)
    Me.Label3.TabIndex = 19
    Me.Label3.Text = "จุดสั่งซื้อ"
    '
    'lblMiniStock
    '
    Me.lblMiniStock.BackColor = System.Drawing.Color.LavenderBlush
    Me.lblMiniStock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblMiniStock.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblMiniStock.Location = New System.Drawing.Point(106, 47)
    Me.lblMiniStock.Name = "lblMiniStock"
    Me.lblMiniStock.Size = New System.Drawing.Size(116, 23)
    Me.lblMiniStock.TabIndex = 24
    Me.lblMiniStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'lblBranchOnhand
    '
    Me.lblBranchOnhand.BackColor = System.Drawing.Color.LavenderBlush
    Me.lblBranchOnhand.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblBranchOnhand.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblBranchOnhand.Location = New System.Drawing.Point(318, 47)
    Me.lblBranchOnhand.Name = "lblBranchOnhand"
    Me.lblBranchOnhand.Size = New System.Drawing.Size(116, 23)
    Me.lblBranchOnhand.TabIndex = 20
    Me.lblBranchOnhand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(233, 19)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(54, 16)
    Me.Label6.TabIndex = 12
    Me.Label6.Text = "ชื่อสินค้า"
    '
    'btnAdd
    '
    Me.btnAdd.Location = New System.Drawing.Point(987, 44)
    Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnAdd.Name = "btnAdd"
    Me.btnAdd.Size = New System.Drawing.Size(81, 28)
    Me.btnAdd.TabIndex = 2
    Me.btnAdd.TabStop = False
    Me.btnAdd.Text = "เพิ่มรายการ"
    Me.btnAdd.UseVisualStyleBackColor = True
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(234, 50)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(78, 16)
    Me.Label10.TabIndex = 23
    Me.Label10.Text = "สาขาคงเหลือ"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(697, 19)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(65, 16)
    Me.Label8.TabIndex = 21
    Me.Label8.Text = "หน่วยบรรจุ"
    '
    'txtGoodAmou
    '
    Me.txtGoodAmou.Location = New System.Drawing.Point(768, 47)
    Me.txtGoodAmou.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtGoodAmou.Name = "txtGoodAmou"
    Me.txtGoodAmou.Size = New System.Drawing.Size(116, 23)
    Me.txtGoodAmou.TabIndex = 1
    Me.txtGoodAmou.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(697, 50)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(57, 16)
    Me.Label7.TabIndex = 13
    Me.Label7.Text = "จำนวนสั่ง"
    '
    'lblUnitDesc
    '
    Me.lblUnitDesc.BackColor = System.Drawing.Color.LavenderBlush
    Me.lblUnitDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblUnitDesc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblUnitDesc.Location = New System.Drawing.Point(627, 16)
    Me.lblUnitDesc.Name = "lblUnitDesc"
    Me.lblUnitDesc.Size = New System.Drawing.Size(64, 23)
    Me.lblUnitDesc.TabIndex = 22
    Me.lblUnitDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'dtgList
    '
    Me.dtgList.AllowUserToAddRows = False
    Me.dtgList.AllowUserToOrderColumns = True
    Me.dtgList.AllowUserToResizeRows = False
    Me.dtgList.BackgroundColor = System.Drawing.Color.LavenderBlush
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.BarCode, Me.GoodName, Me.TypeDesc, Me.GoodCode, Me.MiniStock, Me.StockOnhand, Me.avaiOnhand, Me.GoodAmou, Me.UnitDesc, Me.goodRema, Me.UnitCode, Me.StockOnhand0, Me.stockOnhandDN, Me.unitPrice, Me.shipTo, Me.unitFactor, Me.isPending, Me.packFactor})
    Me.dtgList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
    Me.dtgList.Location = New System.Drawing.Point(0, 0)
    Me.dtgList.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dtgList.Name = "dtgList"
    Me.dtgList.ReadOnly = True
    Me.dtgList.RowHeadersWidth = 30
    Me.dtgList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Plum
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgList.Size = New System.Drawing.Size(1143, 252)
    Me.dtgList.StandardTab = True
    Me.dtgList.TabIndex = 0
    Me.dtgList.TabStop = False
    '
    'Label4
    '
    Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(952, 12)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(66, 16)
    Me.Label4.TabIndex = 18
    Me.Label4.Text = "รวมเป็นเงิน"
    '
    'lblTotalPrice
    '
    Me.lblTotalPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblTotalPrice.Location = New System.Drawing.Point(1024, 9)
    Me.lblTotalPrice.Name = "lblTotalPrice"
    Me.lblTotalPrice.Size = New System.Drawing.Size(107, 23)
    Me.lblTotalPrice.TabIndex = 17
    Me.lblTotalPrice.Text = "0.00"
    Me.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtRemark
    '
    Me.txtRemark.BackColor = System.Drawing.SystemColors.Window
    Me.txtRemark.Location = New System.Drawing.Point(106, 9)
    Me.txtRemark.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtRemark.MaxLength = 100
    Me.txtRemark.Name = "txtRemark"
    Me.txtRemark.Size = New System.Drawing.Size(557, 23)
    Me.txtRemark.TabIndex = 3
    Me.txtRemark.TabStop = False
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(719, 12)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(129, 16)
    Me.Label12.TabIndex = 28
    Me.Label12.Text = "ส่วนกลางคงเหลือสั่งได้"
    Me.Label12.Visible = False
    '
    'lblAvaiOnhand
    '
    Me.lblAvaiOnhand.BackColor = System.Drawing.Color.LavenderBlush
    Me.lblAvaiOnhand.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblAvaiOnhand.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblAvaiOnhand.Location = New System.Drawing.Point(854, 9)
    Me.lblAvaiOnhand.Name = "lblAvaiOnhand"
    Me.lblAvaiOnhand.Size = New System.Drawing.Size(57, 23)
    Me.lblAvaiOnhand.TabIndex = 27
    Me.lblAvaiOnhand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    Me.lblAvaiOnhand.Visible = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(15, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(58, 16)
    Me.Label1.TabIndex = 16
    Me.Label1.Text = "หมายเหตุ"
    '
    'SplitContainer3
    '
    Me.SplitContainer3.BackColor = System.Drawing.SystemColors.Control
    Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer3.IsSplitterFixed = True
    Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer3.Name = "SplitContainer3"
    Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer3.Panel1
    '
    Me.SplitContainer3.Panel1.BackColor = System.Drawing.Color.Lavender
    Me.SplitContainer3.Panel1.Controls.Add(Me.chkMiniStock)
    Me.SplitContainer3.Panel1.Controls.Add(Me.btnShow)
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label9)
    Me.SplitContainer3.Panel1.Controls.Add(Me.cboTypeCode)
    Me.SplitContainer3.Panel1.Controls.Add(Me.cboTypeDesc)
    Me.SplitContainer3.Panel1.Controls.Add(Me.txtName)
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label2)
    '
    'SplitContainer3.Panel2
    '
    Me.SplitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control
    Me.SplitContainer3.Panel2.Controls.Add(Me.dtgGoodSearch)
    Me.SplitContainer3.Size = New System.Drawing.Size(1143, 227)
    Me.SplitContainer3.SplitterDistance = 47
    Me.SplitContainer3.TabIndex = 0
    Me.SplitContainer3.TabStop = False
    '
    'chkMiniStock
    '
    Me.chkMiniStock.AutoSize = True
    Me.chkMiniStock.Location = New System.Drawing.Point(538, 15)
    Me.chkMiniStock.Name = "chkMiniStock"
    Me.chkMiniStock.Size = New System.Drawing.Size(200, 20)
    Me.chkMiniStock.TabIndex = 12
    Me.chkMiniStock.TabStop = False
    Me.chkMiniStock.Text = "แสดงเฉพาะสินค้าต่ำกว่าจุดสั่งซื้อ"
    Me.chkMiniStock.UseVisualStyleBackColor = True
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(744, 12)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(107, 24)
    Me.btnShow.TabIndex = 1
    Me.btnShow.Text = "แสดงรายการ"
    Me.btnShow.UseVisualStyleBackColor = True
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(212, 16)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(109, 16)
    Me.Label9.TabIndex = 8
    Me.Label9.Text = "แสดงสินค้าประเภท"
    '
    'cboTypeCode
    '
    Me.cboTypeCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboTypeCode.FormattingEnabled = True
    Me.cboTypeCode.Location = New System.Drawing.Point(869, 13)
    Me.cboTypeCode.Name = "cboTypeCode"
    Me.cboTypeCode.Size = New System.Drawing.Size(21, 24)
    Me.cboTypeCode.TabIndex = 5
    Me.cboTypeCode.Visible = False
    '
    'cboTypeDesc
    '
    Me.cboTypeDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboTypeDesc.FormattingEnabled = True
    Me.cboTypeDesc.Location = New System.Drawing.Point(327, 13)
    Me.cboTypeDesc.Name = "cboTypeDesc"
    Me.cboTypeDesc.Size = New System.Drawing.Size(205, 24)
    Me.cboTypeDesc.TabIndex = 4
    Me.cboTypeDesc.TabStop = False
    '
    'txtName
    '
    Me.txtName.Location = New System.Drawing.Point(74, 13)
    Me.txtName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtName.Name = "txtName"
    Me.txtName.Size = New System.Drawing.Size(132, 23)
    Me.txtName.TabIndex = 0
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(14, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(54, 16)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "ชื่อสินค้า"
    '
    'dtgGoodSearch
    '
    Me.dtgGoodSearch.AllowUserToAddRows = False
    Me.dtgGoodSearch.AllowUserToDeleteRows = False
    Me.dtgGoodSearch.AllowUserToResizeRows = False
    Me.dtgGoodSearch.BackgroundColor = System.Drawing.Color.Lavender
    DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgGoodSearch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
    Me.dtgGoodSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgGoodSearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SBarCode, Me.SGoodName, Me.STypeDesc, Me.SUnitDesc, Me.SUnitPrice, Me.SMiniStock, Me.SStockOnhand, Me.SPackDesc, Me.SGoodCode, Me.SGoodRema, Me.SStockOnhand0, Me.SStockOnhandDN, Me.SUnitCode, Me.SPrice1, Me.SPackAmou})
    Me.dtgGoodSearch.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgGoodSearch.Location = New System.Drawing.Point(0, 0)
    Me.dtgGoodSearch.Name = "dtgGoodSearch"
    Me.dtgGoodSearch.ReadOnly = True
    Me.dtgGoodSearch.RowHeadersWidth = 30
    Me.dtgGoodSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.dtgGoodSearch.Size = New System.Drawing.Size(1143, 176)
    Me.dtgGoodSearch.StandardTab = True
    Me.dtgGoodSearch.TabIndex = 1
    '
    'SBarCode
    '
    Me.SBarCode.HeaderText = "รหัสสินค้า"
    Me.SBarCode.Name = "SBarCode"
    Me.SBarCode.ReadOnly = True
    '
    'SGoodName
    '
    Me.SGoodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.SGoodName.HeaderText = "รายการ"
    Me.SGoodName.Name = "SGoodName"
    Me.SGoodName.ReadOnly = True
    '
    'STypeDesc
    '
    Me.STypeDesc.HeaderText = "ประเภทสินค้า"
    Me.STypeDesc.Name = "STypeDesc"
    Me.STypeDesc.ReadOnly = True
    Me.STypeDesc.Width = 110
    '
    'SUnitDesc
    '
    Me.SUnitDesc.HeaderText = "หน่วยขาย"
    Me.SUnitDesc.Name = "SUnitDesc"
    Me.SUnitDesc.ReadOnly = True
    '
    'SUnitPrice
    '
    DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle8.Format = "N2"
    Me.SUnitPrice.DefaultCellStyle = DataGridViewCellStyle8
    Me.SUnitPrice.HeaderText = "ราคาขาย"
    Me.SUnitPrice.Name = "SUnitPrice"
    Me.SUnitPrice.ReadOnly = True
    Me.SUnitPrice.Width = 80
    '
    'SMiniStock
    '
    DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle9.Format = "N0"
    Me.SMiniStock.DefaultCellStyle = DataGridViewCellStyle9
    Me.SMiniStock.HeaderText = "จุดสั่งซื้อ"
    Me.SMiniStock.Name = "SMiniStock"
    Me.SMiniStock.ReadOnly = True
    Me.SMiniStock.Width = 80
    '
    'SStockOnhand
    '
    DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle10.Format = "N0"
    Me.SStockOnhand.DefaultCellStyle = DataGridViewCellStyle10
    Me.SStockOnhand.HeaderText = "สาขาคงเหลือ"
    Me.SStockOnhand.Name = "SStockOnhand"
    Me.SStockOnhand.ReadOnly = True
    Me.SStockOnhand.Width = 110
    '
    'SPackDesc
    '
    Me.SPackDesc.HeaderText = "หน่วยบรรจุ"
    Me.SPackDesc.Name = "SPackDesc"
    Me.SPackDesc.ReadOnly = True
    '
    'SGoodCode
    '
    Me.SGoodCode.HeaderText = "goodCode"
    Me.SGoodCode.Name = "SGoodCode"
    Me.SGoodCode.ReadOnly = True
    Me.SGoodCode.Visible = False
    '
    'SGoodRema
    '
    Me.SGoodRema.HeaderText = "สถานะ"
    Me.SGoodRema.Name = "SGoodRema"
    Me.SGoodRema.ReadOnly = True
    Me.SGoodRema.Width = 180
    '
    'SStockOnhand0
    '
    Me.SStockOnhand0.HeaderText = "stockOnhand0"
    Me.SStockOnhand0.Name = "SStockOnhand0"
    Me.SStockOnhand0.ReadOnly = True
    Me.SStockOnhand0.Visible = False
    '
    'SStockOnhandDN
    '
    Me.SStockOnhandDN.HeaderText = "stockOnhandDN"
    Me.SStockOnhandDN.Name = "SStockOnhandDN"
    Me.SStockOnhandDN.ReadOnly = True
    Me.SStockOnhandDN.Visible = False
    '
    'SUnitCode
    '
    Me.SUnitCode.HeaderText = "unitCode"
    Me.SUnitCode.Name = "SUnitCode"
    Me.SUnitCode.ReadOnly = True
    Me.SUnitCode.Visible = False
    '
    'SPrice1
    '
    Me.SPrice1.HeaderText = "price1"
    Me.SPrice1.Name = "SPrice1"
    Me.SPrice1.ReadOnly = True
    Me.SPrice1.Visible = False
    '
    'SPackAmou
    '
    Me.SPackAmou.HeaderText = "packAmou"
    Me.SPackAmou.Name = "SPackAmou"
    Me.SPackAmou.ReadOnly = True
    Me.SPackAmou.Visible = False
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbnPendOrder, Me.tbnUrgentOrder, Me.tbnTempSave, Me.tbnSave, Me.tbnRefresh, Me.tbnImportList, Me.tbnPrint})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.ShowItemToolTips = False
    Me.ToolStrip1.Size = New System.Drawing.Size(1143, 31)
    Me.ToolStrip1.TabIndex = 1
    Me.ToolStrip1.Text = "ToolStrip1"
    '
    'tbnPendOrder
    '
    Me.tbnPendOrder.Image = Global.DrugFront.My.Resources.Resources.news_subscribe
    Me.tbnPendOrder.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnPendOrder.Name = "tbnPendOrder"
    Me.tbnPendOrder.Size = New System.Drawing.Size(102, 28)
    Me.tbnPendOrder.Text = "รายการค้างส่ง"
    '
    'tbnUrgentOrder
    '
    Me.tbnUrgentOrder.Image = Global.DrugFront.My.Resources.Resources.express24
    Me.tbnUrgentOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
    Me.tbnUrgentOrder.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnUrgentOrder.Name = "tbnUrgentOrder"
    Me.tbnUrgentOrder.Size = New System.Drawing.Size(102, 28)
    Me.tbnUrgentOrder.Text = "สั่งสินค้าด่วน"
    '
    'tbnTempSave
    '
    Me.tbnTempSave.Image = Global.DrugFront.My.Resources.Resources.save_temp24
    Me.tbnTempSave.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnTempSave.Name = "tbnTempSave"
    Me.tbnTempSave.Size = New System.Drawing.Size(101, 28)
    Me.tbnTempSave.Text = "บันทึกชั่วคราว"
    '
    'tbnSave
    '
    Me.tbnSave.Image = Global.DrugFront.My.Resources.Resources.save24
    Me.tbnSave.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnSave.Name = "tbnSave"
    Me.tbnSave.Size = New System.Drawing.Size(105, 28)
    Me.tbnSave.Text = "บันทึกสั่งสินค้า"
    '
    'tbnRefresh
    '
    Me.tbnRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
    Me.tbnRefresh.Image = Global.DrugFront.My.Resources.Resources.filenew
    Me.tbnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnRefresh.Name = "tbnRefresh"
    Me.tbnRefresh.Size = New System.Drawing.Size(58, 28)
    Me.tbnRefresh.Text = "Clear"
    '
    'tbnImportList
    '
    Me.tbnImportList.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
    Me.tbnImportList.ForeColor = System.Drawing.Color.DarkRed
    Me.tbnImportList.Image = Global.DrugFront.My.Resources.Resources.import24
    Me.tbnImportList.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnImportList.Name = "tbnImportList"
    Me.tbnImportList.Size = New System.Drawing.Size(100, 28)
    Me.tbnImportList.Text = "นำเข้ารายการ"
    '
    'tbnPrint
    '
    Me.tbnPrint.Image = Global.DrugFront.My.Resources.Resources.printer1
    Me.tbnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnPrint.Name = "tbnPrint"
    Me.tbnPrint.Size = New System.Drawing.Size(112, 28)
    Me.tbnPrint.Text = "พิมพ์ใบสั่งสินค้า"
    Me.tbnPrint.Visible = False
    '
    'pdc1
    '
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
    'BarCode
    '
    Me.BarCode.HeaderText = "รหัสสินค้า"
    Me.BarCode.Name = "BarCode"
    Me.BarCode.ReadOnly = True
    '
    'GoodName
    '
    Me.GoodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.GoodName.HeaderText = "รายการสั่ง"
    Me.GoodName.Name = "GoodName"
    Me.GoodName.ReadOnly = True
    '
    'TypeDesc
    '
    Me.TypeDesc.HeaderText = "ประเภทสินค้า"
    Me.TypeDesc.Name = "TypeDesc"
    Me.TypeDesc.ReadOnly = True
    Me.TypeDesc.Width = 110
    '
    'GoodCode
    '
    Me.GoodCode.HeaderText = "goodCode"
    Me.GoodCode.Name = "GoodCode"
    Me.GoodCode.ReadOnly = True
    Me.GoodCode.Visible = False
    '
    'MiniStock
    '
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle3.Format = "N0"
    Me.MiniStock.DefaultCellStyle = DataGridViewCellStyle3
    Me.MiniStock.HeaderText = "จุดสั่งซื้อ"
    Me.MiniStock.Name = "MiniStock"
    Me.MiniStock.ReadOnly = True
    '
    'StockOnhand
    '
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle4.Format = "N0"
    Me.StockOnhand.DefaultCellStyle = DataGridViewCellStyle4
    Me.StockOnhand.HeaderText = "สาขาคงเหลือ"
    Me.StockOnhand.Name = "StockOnhand"
    Me.StockOnhand.ReadOnly = True
    Me.StockOnhand.Width = 110
    '
    'avaiOnhand
    '
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle5.Format = "N0"
    Me.avaiOnhand.DefaultCellStyle = DataGridViewCellStyle5
    Me.avaiOnhand.HeaderText = "สต๊อคกลางคงเหลือสุทธิ"
    Me.avaiOnhand.Name = "avaiOnhand"
    Me.avaiOnhand.ReadOnly = True
    Me.avaiOnhand.Visible = False
    '
    'GoodAmou
    '
    DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle6.Format = "N0"
    Me.GoodAmou.DefaultCellStyle = DataGridViewCellStyle6
    Me.GoodAmou.HeaderText = "จำนวนสั่ง"
    Me.GoodAmou.Name = "GoodAmou"
    Me.GoodAmou.ReadOnly = True
    Me.GoodAmou.Width = 90
    '
    'UnitDesc
    '
    Me.UnitDesc.HeaderText = "หน่วย"
    Me.UnitDesc.Name = "UnitDesc"
    Me.UnitDesc.ReadOnly = True
    '
    'goodRema
    '
    Me.goodRema.HeaderText = "สถานะ"
    Me.goodRema.Name = "goodRema"
    Me.goodRema.ReadOnly = True
    '
    'UnitCode
    '
    Me.UnitCode.HeaderText = "unitCode"
    Me.UnitCode.Name = "UnitCode"
    Me.UnitCode.ReadOnly = True
    Me.UnitCode.Visible = False
    '
    'StockOnhand0
    '
    Me.StockOnhand0.HeaderText = "stockOnhand0"
    Me.StockOnhand0.Name = "StockOnhand0"
    Me.StockOnhand0.ReadOnly = True
    Me.StockOnhand0.Visible = False
    Me.StockOnhand0.Width = 60
    '
    'stockOnhandDN
    '
    Me.stockOnhandDN.HeaderText = "stockOnhandDN"
    Me.stockOnhandDN.Name = "stockOnhandDN"
    Me.stockOnhandDN.ReadOnly = True
    Me.stockOnhandDN.Visible = False
    Me.stockOnhandDN.Width = 60
    '
    'unitPrice
    '
    Me.unitPrice.HeaderText = "unitPrice"
    Me.unitPrice.Name = "unitPrice"
    Me.unitPrice.ReadOnly = True
    Me.unitPrice.Visible = False
    '
    'shipTo
    '
    Me.shipTo.HeaderText = "ShipTo"
    Me.shipTo.Name = "shipTo"
    Me.shipTo.ReadOnly = True
    Me.shipTo.Width = 50
    '
    'unitFactor
    '
    Me.unitFactor.HeaderText = "unitFactor"
    Me.unitFactor.Name = "unitFactor"
    Me.unitFactor.ReadOnly = True
    Me.unitFactor.Visible = False
    '
    'isPending
    '
    Me.isPending.HeaderText = "isPending"
    Me.isPending.Name = "isPending"
    Me.isPending.ReadOnly = True
    Me.isPending.Visible = False
    '
    'packFactor
    '
    Me.packFactor.HeaderText = "packFactor"
    Me.packFactor.Name = "packFactor"
    Me.packFactor.ReadOnly = True
    Me.packFactor.Visible = False
    '
    'frmGoodOrder
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1143, 648)
    Me.Controls.Add(Me.sct1)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmGoodOrder"
    Me.Tag = "f2a"
    Me.Text = "ออกใบสั่งสินค้า"
    Me.sct1.Panel1.ResumeLayout(False)
    Me.sct1.Panel2.ResumeLayout(False)
    Me.sct1.ResumeLayout(False)
    Me.SplitContainer2.Panel1.ResumeLayout(False)
    Me.SplitContainer2.Panel2.ResumeLayout(False)
    Me.SplitContainer2.Panel2.PerformLayout()
    Me.SplitContainer2.ResumeLayout(False)
    Me.SplitContainer4.Panel1.ResumeLayout(False)
    Me.SplitContainer4.Panel1.PerformLayout()
    Me.SplitContainer4.Panel2.ResumeLayout(False)
    Me.SplitContainer4.ResumeLayout(False)
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer3.Panel1.ResumeLayout(False)
    Me.SplitContainer3.Panel1.PerformLayout()
    Me.SplitContainer3.Panel2.ResumeLayout(False)
    Me.SplitContainer3.ResumeLayout(False)
    CType(Me.dtgGoodSearch, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents sct1 As System.Windows.Forms.SplitContainer
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents dtgList As System.Windows.Forms.DataGridView
  Friend WithEvents tbnSave As System.Windows.Forms.ToolStripButton
  Friend WithEvents tbnRefresh As System.Windows.Forms.ToolStripButton
  Friend WithEvents tbnTempSave As System.Windows.Forms.ToolStripButton
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtRemark As System.Windows.Forms.TextBox
  Friend WithEvents btnAdd As System.Windows.Forms.Button
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents txtGoodAmou As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents lblGoodName As System.Windows.Forms.Label
  Friend WithEvents tbnPrint As System.Windows.Forms.ToolStripButton
  Friend WithEvents pdc1 As System.Drawing.Printing.PrintDocument
  Friend WithEvents lblGoodRema As System.Windows.Forms.Label
  Friend WithEvents lblBranchOnhand As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents lblMiniStock As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents lblUnitDesc As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
  Friend WithEvents tbnPendOrder As System.Windows.Forms.ToolStripButton
  Friend WithEvents tbnUrgentOrder As System.Windows.Forms.ToolStripButton
  Friend WithEvents lblUrgentOrder As System.Windows.Forms.Label
  Friend WithEvents txtName As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents dtgGoodSearch As System.Windows.Forms.DataGridView
  Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
  Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
  Friend WithEvents cboTypeCode As System.Windows.Forms.ComboBox
  Friend WithEvents cboTypeDesc As System.Windows.Forms.ComboBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents chkMiniStock As System.Windows.Forms.CheckBox
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents tbnImportList As System.Windows.Forms.ToolStripButton
  Friend WithEvents lblTotalPrice As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents lblPackDesc As System.Windows.Forms.Label
  Friend WithEvents lblAvaiOnhand As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents SBarCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SGoodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents STypeDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SUnitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SMiniStock As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SStockOnhand As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SPackDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SGoodCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SGoodRema As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SStockOnhand0 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SStockOnhandDN As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SUnitCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SPrice1 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SPackAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents lblOrderUnitDesc As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents lblShipTo1 As System.Windows.Forms.Label
  Friend WithEvents lblPackSale As System.Windows.Forms.Label
  Friend WithEvents lblShipTo As System.Windows.Forms.Label
  Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents BarCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents TypeDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents MiniStock As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents StockOnhand As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents avaiOnhand As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodRema As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents StockOnhand0 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents stockOnhandDN As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents shipTo As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitFactor As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents isPending As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents packFactor As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
