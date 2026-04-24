<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShipToRece
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
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
    Me.tbnGoodSearch = New System.Windows.Forms.ToolStripButton
    Me.tbnSave = New System.Windows.Forms.ToolStripButton
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.dtpInvoice = New System.Windows.Forms.DateTimePicker
    Me.Label9 = New System.Windows.Forms.Label
    Me.txtInvoiceNumb = New System.Windows.Forms.TextBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.txtBranchOrderNumb = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.txtOrderNumb = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
    Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
    Me.Button1 = New System.Windows.Forms.Button
    Me.lblUnitDesc = New System.Windows.Forms.Label
    Me.lblOrderAmou = New System.Windows.Forms.Label
    Me.lblPleaseWait = New System.Windows.Forms.Label
    Me.Label5 = New System.Windows.Forms.Label
    Me.lblGoodName = New System.Windows.Forms.Label
    Me.btnAdd = New System.Windows.Forms.Button
    Me.Label7 = New System.Windows.Forms.Label
    Me.txtThisRece = New System.Windows.Forms.TextBox
    Me.Label6 = New System.Windows.Forms.Label
    Me.txtBarcode = New System.Windows.Forms.TextBox
    Me.Label8 = New System.Windows.Forms.Label
    Me.dtgList = New System.Windows.Forms.DataGridView
    Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.orderAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.ReceAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.thisRece = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.StockOnhand = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.StockUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.NoBranchStock = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.lblTotalItem = New System.Windows.Forms.Label
    Me.txtRemark = New System.Windows.Forms.TextBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.pdc1 = New System.Drawing.Printing.PrintDocument
    Me.ToolStrip1.SuspendLayout()
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SplitContainer2.Panel1.SuspendLayout()
    Me.SplitContainer2.Panel2.SuspendLayout()
    Me.SplitContainer2.SuspendLayout()
    Me.SplitContainer3.Panel1.SuspendLayout()
    Me.SplitContainer3.Panel2.SuspendLayout()
    Me.SplitContainer3.SuspendLayout()
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbnGoodSearch, Me.tbnSave})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.ShowItemToolTips = False
    Me.ToolStrip1.Size = New System.Drawing.Size(976, 25)
    Me.ToolStrip1.TabIndex = 0
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
    'tbnSave
    '
    Me.tbnSave.Image = Global.DrugFront.My.Resources.Resources.filesave
    Me.tbnSave.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnSave.Name = "tbnSave"
    Me.tbnSave.Size = New System.Drawing.Size(123, 22)
    Me.tbnSave.Text = "บันทึกรับสินค้า F8"
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer1.IsSplitterFixed = True
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
    Me.SplitContainer1.Name = "SplitContainer1"
    Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Pink
    Me.SplitContainer1.Panel1.Controls.Add(Me.dtpInvoice)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtInvoiceNumb)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtBranchOrderNumb)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtOrderNumb)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
    Me.SplitContainer1.Size = New System.Drawing.Size(976, 546)
    Me.SplitContainer1.SplitterDistance = 41
    Me.SplitContainer1.TabIndex = 1
    Me.SplitContainer1.TabStop = False
    '
    'dtpInvoice
    '
    Me.dtpInvoice.Location = New System.Drawing.Point(786, 8)
    Me.dtpInvoice.Name = "dtpInvoice"
    Me.dtpInvoice.Size = New System.Drawing.Size(179, 23)
    Me.dtpInvoice.TabIndex = 6
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(733, 11)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(47, 16)
    Me.Label9.TabIndex = 5
    Me.Label9.Text = "วันที่บิล"
    '
    'txtInvoiceNumb
    '
    Me.txtInvoiceNumb.Location = New System.Drawing.Point(581, 8)
    Me.txtInvoiceNumb.MaxLength = 15
    Me.txtInvoiceNumb.Name = "txtInvoiceNumb"
    Me.txtInvoiceNumb.Size = New System.Drawing.Size(146, 23)
    Me.txtInvoiceNumb.TabIndex = 2
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(480, 11)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(95, 16)
    Me.Label4.TabIndex = 4
    Me.Label4.Text = "เลขที่ใบส่งสินค้า"
    '
    'txtBranchOrderNumb
    '
    Me.txtBranchOrderNumb.Location = New System.Drawing.Point(375, 8)
    Me.txtBranchOrderNumb.Name = "txtBranchOrderNumb"
    Me.txtBranchOrderNumb.ReadOnly = True
    Me.txtBranchOrderNumb.Size = New System.Drawing.Size(99, 23)
    Me.txtBranchOrderNumb.TabIndex = 1
    Me.txtBranchOrderNumb.TabStop = False
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(240, 11)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(129, 16)
    Me.Label3.TabIndex = 2
    Me.Label3.Text = "อ้างถึงใบสั่งสินค้าเลขที่"
    '
    'txtOrderNumb
    '
    Me.txtOrderNumb.Location = New System.Drawing.Point(113, 8)
    Me.txtOrderNumb.Name = "txtOrderNumb"
    Me.txtOrderNumb.Size = New System.Drawing.Size(116, 23)
    Me.txtOrderNumb.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(22, 11)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(82, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "เลขที่ใบสั่งซื้อ"
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
    Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer3)
    '
    'SplitContainer2.Panel2
    '
    Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.Pink
    Me.SplitContainer2.Panel2.Controls.Add(Me.lblTotalItem)
    Me.SplitContainer2.Panel2.Controls.Add(Me.txtRemark)
    Me.SplitContainer2.Panel2.Controls.Add(Me.Label2)
    Me.SplitContainer2.Size = New System.Drawing.Size(976, 501)
    Me.SplitContainer2.SplitterDistance = 459
    Me.SplitContainer2.TabIndex = 2
    Me.SplitContainer2.TabStop = False
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
    Me.SplitContainer3.Panel1.BackColor = System.Drawing.Color.Pink
    Me.SplitContainer3.Panel1.Controls.Add(Me.Button1)
    Me.SplitContainer3.Panel1.Controls.Add(Me.lblUnitDesc)
    Me.SplitContainer3.Panel1.Controls.Add(Me.lblOrderAmou)
    Me.SplitContainer3.Panel1.Controls.Add(Me.lblPleaseWait)
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label5)
    Me.SplitContainer3.Panel1.Controls.Add(Me.lblGoodName)
    Me.SplitContainer3.Panel1.Controls.Add(Me.btnAdd)
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label7)
    Me.SplitContainer3.Panel1.Controls.Add(Me.txtThisRece)
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label6)
    Me.SplitContainer3.Panel1.Controls.Add(Me.txtBarcode)
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label8)
    '
    'SplitContainer3.Panel2
    '
    Me.SplitContainer3.Panel2.Controls.Add(Me.dtgList)
    Me.SplitContainer3.Size = New System.Drawing.Size(976, 459)
    Me.SplitContainer3.SplitterDistance = 82
    Me.SplitContainer3.TabIndex = 1
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(813, 12)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(75, 23)
    Me.Button1.TabIndex = 33
    Me.Button1.Text = "Button1"
    Me.Button1.UseVisualStyleBackColor = True
    Me.Button1.Visible = False
    '
    'lblUnitDesc
    '
    Me.lblUnitDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblUnitDesc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblUnitDesc.ForeColor = System.Drawing.SystemColors.WindowText
    Me.lblUnitDesc.Location = New System.Drawing.Point(407, 41)
    Me.lblUnitDesc.Name = "lblUnitDesc"
    Me.lblUnitDesc.Size = New System.Drawing.Size(128, 23)
    Me.lblUnitDesc.TabIndex = 32
    '
    'lblOrderAmou
    '
    Me.lblOrderAmou.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblOrderAmou.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblOrderAmou.ForeColor = System.Drawing.SystemColors.WindowText
    Me.lblOrderAmou.Location = New System.Drawing.Point(113, 41)
    Me.lblOrderAmou.Name = "lblOrderAmou"
    Me.lblOrderAmou.Size = New System.Drawing.Size(116, 23)
    Me.lblOrderAmou.TabIndex = 31
    Me.lblOrderAmou.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'lblPleaseWait
    '
    Me.lblPleaseWait.AutoSize = True
    Me.lblPleaseWait.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblPleaseWait.ForeColor = System.Drawing.Color.DarkRed
    Me.lblPleaseWait.Location = New System.Drawing.Point(667, 41)
    Me.lblPleaseWait.Name = "lblPleaseWait"
    Me.lblPleaseWait.Size = New System.Drawing.Size(234, 19)
    Me.lblPleaseWait.TabIndex = 1
    Me.lblPleaseWait.Text = "กำลังบันทึกรับสินค้า..โปรดรอ..."
    Me.lblPleaseWait.Visible = False
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(22, 44)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(57, 16)
    Me.Label5.TabIndex = 30
    Me.Label5.Text = "จำนวนสั่ง"
    '
    'lblGoodName
    '
    Me.lblGoodName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblGoodName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblGoodName.ForeColor = System.Drawing.SystemColors.WindowText
    Me.lblGoodName.Location = New System.Drawing.Point(327, 14)
    Me.lblGoodName.Name = "lblGoodName"
    Me.lblGoodName.Size = New System.Drawing.Size(208, 23)
    Me.lblGoodName.TabIndex = 29
    '
    'btnAdd
    '
    Me.btnAdd.Location = New System.Drawing.Point(550, 38)
    Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnAdd.Name = "btnAdd"
    Me.btnAdd.Size = New System.Drawing.Size(102, 28)
    Me.btnAdd.TabIndex = 2
    Me.btnAdd.Text = "บันทึกรายการ"
    Me.btnAdd.UseVisualStyleBackColor = True
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(240, 44)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(57, 16)
    Me.Label7.TabIndex = 28
    Me.Label7.Text = "จำนวนรับ"
    '
    'txtThisRece
    '
    Me.txtThisRece.Location = New System.Drawing.Point(327, 41)
    Me.txtThisRece.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtThisRece.Name = "txtThisRece"
    Me.txtThisRece.Size = New System.Drawing.Size(74, 23)
    Me.txtThisRece.TabIndex = 1
    Me.txtThisRece.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(240, 17)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(54, 16)
    Me.Label6.TabIndex = 27
    Me.Label6.Text = "ชื่อสินค้า"
    '
    'txtBarcode
    '
    Me.txtBarcode.Location = New System.Drawing.Point(113, 14)
    Me.txtBarcode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtBarcode.Name = "txtBarcode"
    Me.txtBarcode.Size = New System.Drawing.Size(116, 23)
    Me.txtBarcode.TabIndex = 0
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(22, 17)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(60, 16)
    Me.Label8.TabIndex = 26
    Me.Label8.Text = "รหัสสินค้า"
    '
    'dtgList
    '
    Me.dtgList.AllowUserToAddRows = False
    Me.dtgList.AllowUserToDeleteRows = False
    Me.dtgList.AllowUserToResizeColumns = False
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
    Me.dtgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.GoodName, Me.GoodCode, Me.UnitDesc, Me.orderAmou, Me.ReceAmou, Me.thisRece, Me.UnitCode, Me.UnitCost, Me.StockOnhand, Me.StockUnitCost, Me.NoBranchStock})
    Me.dtgList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgList.Location = New System.Drawing.Point(0, 0)
    Me.dtgList.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dtgList.Name = "dtgList"
    Me.dtgList.ReadOnly = True
    Me.dtgList.RowHeadersVisible = False
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Pink
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
    Me.dtgList.Size = New System.Drawing.Size(976, 373)
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
    Me.GoodCode.HeaderText = "รหัสสินค้า"
    Me.GoodCode.Name = "GoodCode"
    Me.GoodCode.ReadOnly = True
    Me.GoodCode.Visible = False
    Me.GoodCode.Width = 80
    '
    'UnitDesc
    '
    Me.UnitDesc.HeaderText = "หน่วย"
    Me.UnitDesc.Name = "UnitDesc"
    Me.UnitDesc.ReadOnly = True
    Me.UnitDesc.Width = 120
    '
    'orderAmou
    '
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle3.Format = "N0"
    Me.orderAmou.DefaultCellStyle = DataGridViewCellStyle3
    Me.orderAmou.HeaderText = "จำนวนสั่ง"
    Me.orderAmou.Name = "orderAmou"
    Me.orderAmou.ReadOnly = True
    '
    'ReceAmou
    '
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle4.Format = "N0"
    Me.ReceAmou.DefaultCellStyle = DataGridViewCellStyle4
    Me.ReceAmou.HeaderText = "รับแล้ว"
    Me.ReceAmou.Name = "ReceAmou"
    Me.ReceAmou.ReadOnly = True
    '
    'thisRece
    '
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle5.Format = "N0"
    Me.thisRece.DefaultCellStyle = DataGridViewCellStyle5
    Me.thisRece.HeaderText = "รับครั้งนี้"
    Me.thisRece.Name = "thisRece"
    Me.thisRece.ReadOnly = True
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
    Me.UnitCost.HeaderText = "unitCost"
    Me.UnitCost.Name = "UnitCost"
    Me.UnitCost.ReadOnly = True
    Me.UnitCost.Visible = False
    '
    'StockOnhand
    '
    Me.StockOnhand.HeaderText = "stockOnhand"
    Me.StockOnhand.Name = "StockOnhand"
    Me.StockOnhand.ReadOnly = True
    Me.StockOnhand.Visible = False
    '
    'StockUnitCost
    '
    Me.StockUnitCost.HeaderText = "stockUnitCost"
    Me.StockUnitCost.Name = "StockUnitCost"
    Me.StockUnitCost.ReadOnly = True
    Me.StockUnitCost.Visible = False
    '
    'NoBranchStock
    '
    Me.NoBranchStock.HeaderText = "noBranchStock"
    Me.NoBranchStock.Name = "NoBranchStock"
    Me.NoBranchStock.ReadOnly = True
    Me.NoBranchStock.Visible = False
    '
    'lblTotalItem
    '
    Me.lblTotalItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblTotalItem.Location = New System.Drawing.Point(823, 7)
    Me.lblTotalItem.Name = "lblTotalItem"
    Me.lblTotalItem.Size = New System.Drawing.Size(141, 23)
    Me.lblTotalItem.TabIndex = 1
    Me.lblTotalItem.Text = "รวม...รายการ"
    Me.lblTotalItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtRemark
    '
    Me.txtRemark.Location = New System.Drawing.Point(72, 7)
    Me.txtRemark.MaxLength = 100
    Me.txtRemark.Name = "txtRemark"
    Me.txtRemark.Size = New System.Drawing.Size(580, 23)
    Me.txtRemark.TabIndex = 0
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(8, 10)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(58, 16)
    Me.Label2.TabIndex = 0
    Me.Label2.Text = "หมายเหตุ"
    '
    'pdc1
    '
    '
    'frmShipToRece
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(976, 571)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmShipToRece"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Tag = "f2j"
    Me.Text = "รับเข้าสินค้าจากบริษัท (Ship to)"
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    Me.SplitContainer2.Panel1.ResumeLayout(False)
    Me.SplitContainer2.Panel2.ResumeLayout(False)
    Me.SplitContainer2.Panel2.PerformLayout()
    Me.SplitContainer2.ResumeLayout(False)
    Me.SplitContainer3.Panel1.ResumeLayout(False)
    Me.SplitContainer3.Panel1.PerformLayout()
    Me.SplitContainer3.Panel2.ResumeLayout(False)
    Me.SplitContainer3.ResumeLayout(False)
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents tbnSave As System.Windows.Forms.ToolStripButton
  Friend WithEvents txtOrderNumb As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents dtgList As System.Windows.Forms.DataGridView
  Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
  Friend WithEvents lblPleaseWait As System.Windows.Forms.Label
  Friend WithEvents txtRemark As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtBranchOrderNumb As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtInvoiceNumb As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
  Friend WithEvents lblUnitDesc As System.Windows.Forms.Label
  Friend WithEvents lblOrderAmou As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents lblGoodName As System.Windows.Forms.Label
  Friend WithEvents btnAdd As System.Windows.Forms.Button
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents txtThisRece As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents tbnGoodSearch As System.Windows.Forms.ToolStripButton
  Friend WithEvents lblTotalItem As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents dtpInvoice As System.Windows.Forms.DateTimePicker
  Friend WithEvents pdc1 As System.Drawing.Printing.PrintDocument
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents orderAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ReceAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents thisRece As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents StockOnhand As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents StockUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents NoBranchStock As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
