<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckStockReturn
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
    Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
    Me.btnShow = New System.Windows.Forms.Button
    Me.dtgHistReturn = New System.Windows.Forms.DataGridView
    Me.RetuDate = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.RetuNumb = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.statText = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.EmplName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.RetuStat = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
    Me.lblCancel = New System.Windows.Forms.Label
    Me.Label5 = New System.Windows.Forms.Label
    Me.lblRetuDate = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.lblRetuNumb = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.lblEmplName = New System.Windows.Forms.Label
    Me.SplitContainer4 = New System.Windows.Forms.SplitContainer
    Me.dtgReturnList = New System.Windows.Forms.DataGridView
    Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.barCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.lotNo = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.expiDate = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.retuRema = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.subTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.retuStatText = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.NoBranchStock = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.stockOnhand = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.txtTotal = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
    Me.pdc1 = New System.Drawing.Printing.PrintDocument
    Me.dtpFrom = New System.Windows.Forms.DateTimePicker
    Me.Label6 = New System.Windows.Forms.Label
    Me.dtpTo = New System.Windows.Forms.DateTimePicker
    Me.Label7 = New System.Windows.Forms.Label
    Me.tbnPrint = New System.Windows.Forms.ToolStripButton
    Me.tbnCancel = New System.Windows.Forms.ToolStripButton
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
    Me.ToolStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 31)
    Me.SplitContainer1.Name = "SplitContainer1"
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
    Me.SplitContainer1.Size = New System.Drawing.Size(1154, 521)
    Me.SplitContainer1.SplitterDistance = 332
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
    Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.Plum
    Me.SplitContainer2.Panel1.Controls.Add(Me.dtpTo)
    Me.SplitContainer2.Panel1.Controls.Add(Me.Label7)
    Me.SplitContainer2.Panel1.Controls.Add(Me.dtpFrom)
    Me.SplitContainer2.Panel1.Controls.Add(Me.Label6)
    Me.SplitContainer2.Panel1.Controls.Add(Me.btnShow)
    '
    'SplitContainer2.Panel2
    '
    Me.SplitContainer2.Panel2.Controls.Add(Me.dtgHistReturn)
    Me.SplitContainer2.Size = New System.Drawing.Size(332, 521)
    Me.SplitContainer2.SplitterDistance = 110
    Me.SplitContainer2.TabIndex = 0
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(86, 72)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(164, 25)
    Me.btnShow.TabIndex = 0
    Me.btnShow.Text = "แสดงรายการ"
    Me.btnShow.UseVisualStyleBackColor = True
    '
    'dtgHistReturn
    '
    Me.dtgHistReturn.AllowUserToAddRows = False
    Me.dtgHistReturn.AllowUserToDeleteRows = False
    Me.dtgHistReturn.AllowUserToResizeColumns = False
    Me.dtgHistReturn.AllowUserToResizeRows = False
    Me.dtgHistReturn.BackgroundColor = System.Drawing.Color.LavenderBlush
    DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgHistReturn.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
    Me.dtgHistReturn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RetuDate, Me.RetuNumb, Me.statText, Me.EmplName, Me.RetuStat})
    Me.dtgHistReturn.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgHistReturn.Location = New System.Drawing.Point(0, 0)
    Me.dtgHistReturn.Name = "dtgHistReturn"
    Me.dtgHistReturn.ReadOnly = True
    Me.dtgHistReturn.RowHeadersVisible = False
    Me.dtgHistReturn.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Plum
    Me.dtgHistReturn.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgHistReturn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.dtgHistReturn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgHistReturn.Size = New System.Drawing.Size(332, 407)
    Me.dtgHistReturn.TabIndex = 0
    '
    'RetuDate
    '
    DataGridViewCellStyle8.Format = "d"
    DataGridViewCellStyle8.NullValue = Nothing
    Me.RetuDate.DefaultCellStyle = DataGridViewCellStyle8
    Me.RetuDate.HeaderText = "วันที่"
    Me.RetuDate.Name = "RetuDate"
    Me.RetuDate.ReadOnly = True
    '
    'RetuNumb
    '
    Me.RetuNumb.HeaderText = "เลขที่ใบคืน"
    Me.RetuNumb.Name = "RetuNumb"
    Me.RetuNumb.ReadOnly = True
    Me.RetuNumb.Width = 130
    '
    'statText
    '
    Me.statText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.statText.HeaderText = "สถานะ"
    Me.statText.Name = "statText"
    Me.statText.ReadOnly = True
    '
    'EmplName
    '
    Me.EmplName.HeaderText = "emplName"
    Me.EmplName.Name = "EmplName"
    Me.EmplName.ReadOnly = True
    Me.EmplName.Visible = False
    '
    'RetuStat
    '
    Me.RetuStat.HeaderText = "retuStat"
    Me.RetuStat.Name = "RetuStat"
    Me.RetuStat.ReadOnly = True
    Me.RetuStat.Visible = False
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
    Me.SplitContainer3.Panel1.BackColor = System.Drawing.Color.Plum
    Me.SplitContainer3.Panel1.Controls.Add(Me.lblCancel)
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label5)
    Me.SplitContainer3.Panel1.Controls.Add(Me.lblRetuDate)
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label4)
    Me.SplitContainer3.Panel1.Controls.Add(Me.lblRetuNumb)
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label2)
    Me.SplitContainer3.Panel1.Controls.Add(Me.lblEmplName)
    '
    'SplitContainer3.Panel2
    '
    Me.SplitContainer3.Panel2.Controls.Add(Me.SplitContainer4)
    Me.SplitContainer3.Size = New System.Drawing.Size(818, 521)
    Me.SplitContainer3.SplitterDistance = 110
    Me.SplitContainer3.TabIndex = 0
    '
    'lblCancel
    '
    Me.lblCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblCancel.AutoSize = True
    Me.lblCancel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblCancel.ForeColor = System.Drawing.Color.DarkRed
    Me.lblCancel.Location = New System.Drawing.Point(289, 17)
    Me.lblCancel.Name = "lblCancel"
    Me.lblCancel.Size = New System.Drawing.Size(51, 19)
    Me.lblCancel.TabIndex = 12
    Me.lblCancel.Text = "ยกเลิก"
    Me.lblCancel.Visible = False
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(14, 76)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(46, 16)
    Me.Label5.TabIndex = 4
    Me.Label5.Text = "ผู้ส่งคืน"
    '
    'lblRetuDate
    '
    Me.lblRetuDate.BackColor = System.Drawing.SystemColors.Window
    Me.lblRetuDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblRetuDate.Location = New System.Drawing.Point(87, 43)
    Me.lblRetuDate.Name = "lblRetuDate"
    Me.lblRetuDate.Size = New System.Drawing.Size(187, 23)
    Me.lblRetuDate.TabIndex = 3
    Me.lblRetuDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(14, 46)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(31, 16)
    Me.Label4.TabIndex = 2
    Me.Label4.Text = "วันที่"
    '
    'lblRetuNumb
    '
    Me.lblRetuNumb.BackColor = System.Drawing.SystemColors.Window
    Me.lblRetuNumb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblRetuNumb.Location = New System.Drawing.Point(87, 14)
    Me.lblRetuNumb.Name = "lblRetuNumb"
    Me.lblRetuNumb.Size = New System.Drawing.Size(187, 23)
    Me.lblRetuNumb.TabIndex = 1
    Me.lblRetuNumb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(14, 17)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(67, 16)
    Me.Label2.TabIndex = 0
    Me.Label2.Text = "เลขที่ใบคืน"
    '
    'lblEmplName
    '
    Me.lblEmplName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblEmplName.BackColor = System.Drawing.SystemColors.Window
    Me.lblEmplName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblEmplName.Location = New System.Drawing.Point(87, 73)
    Me.lblEmplName.Name = "lblEmplName"
    Me.lblEmplName.Size = New System.Drawing.Size(187, 23)
    Me.lblEmplName.TabIndex = 11
    Me.lblEmplName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'SplitContainer4
    '
    Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
    Me.SplitContainer4.IsSplitterFixed = True
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
    Me.SplitContainer4.Panel2.BackColor = System.Drawing.Color.Plum
    Me.SplitContainer4.Panel2.Controls.Add(Me.txtTotal)
    Me.SplitContainer4.Panel2.Controls.Add(Me.Label3)
    Me.SplitContainer4.Size = New System.Drawing.Size(818, 407)
    Me.SplitContainer4.SplitterDistance = 360
    Me.SplitContainer4.TabIndex = 2
    '
    'dtgReturnList
    '
    Me.dtgReturnList.AllowUserToAddRows = False
    Me.dtgReturnList.AllowUserToDeleteRows = False
    Me.dtgReturnList.AllowUserToResizeColumns = False
    Me.dtgReturnList.AllowUserToResizeRows = False
    Me.dtgReturnList.BackgroundColor = System.Drawing.Color.LavenderBlush
    DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgReturnList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
    Me.dtgReturnList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.GoodName, Me.barCode, Me.GoodAmou, Me.UnitDesc, Me.lotNo, Me.expiDate, Me.retuRema, Me.subTotal, Me.retuStatText, Me.GoodCode, Me.NoBranchStock, Me.stockOnhand})
    Me.dtgReturnList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgReturnList.Location = New System.Drawing.Point(0, 0)
    Me.dtgReturnList.Name = "dtgReturnList"
    Me.dtgReturnList.ReadOnly = True
    Me.dtgReturnList.RowHeadersVisible = False
    Me.dtgReturnList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Plum
    Me.dtgReturnList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgReturnList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.dtgReturnList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgReturnList.Size = New System.Drawing.Size(818, 360)
    Me.dtgReturnList.TabIndex = 1
    '
    'Item
    '
    DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    Me.Item.DefaultCellStyle = DataGridViewCellStyle10
    Me.Item.HeaderText = ""
    Me.Item.Name = "Item"
    Me.Item.ReadOnly = True
    Me.Item.Width = 35
    '
    'GoodName
    '
    Me.GoodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.GoodName.HeaderText = "รายการ"
    Me.GoodName.Name = "GoodName"
    Me.GoodName.ReadOnly = True
    '
    'barCode
    '
    Me.barCode.HeaderText = "รหัสสินค้า"
    Me.barCode.Name = "barCode"
    Me.barCode.ReadOnly = True
    '
    'GoodAmou
    '
    DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    Me.GoodAmou.DefaultCellStyle = DataGridViewCellStyle11
    Me.GoodAmou.HeaderText = "จำนวน"
    Me.GoodAmou.Name = "GoodAmou"
    Me.GoodAmou.ReadOnly = True
    Me.GoodAmou.Width = 60
    '
    'UnitDesc
    '
    Me.UnitDesc.HeaderText = "หน่วย"
    Me.UnitDesc.Name = "UnitDesc"
    Me.UnitDesc.ReadOnly = True
    Me.UnitDesc.Width = 80
    '
    'lotNo
    '
    Me.lotNo.HeaderText = "เลขล๊อต"
    Me.lotNo.Name = "lotNo"
    Me.lotNo.ReadOnly = True
    Me.lotNo.Width = 80
    '
    'expiDate
    '
    Me.expiDate.HeaderText = "วันหมดอายุ"
    Me.expiDate.Name = "expiDate"
    Me.expiDate.ReadOnly = True
    '
    'retuRema
    '
    Me.retuRema.HeaderText = "สาเหตุคืน"
    Me.retuRema.Name = "retuRema"
    Me.retuRema.ReadOnly = True
    Me.retuRema.Width = 120
    '
    'subTotal
    '
    DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle12.Format = "N0"
    Me.subTotal.DefaultCellStyle = DataGridViewCellStyle12
    Me.subTotal.HeaderText = "เป็นเงิน"
    Me.subTotal.Name = "subTotal"
    Me.subTotal.ReadOnly = True
    Me.subTotal.Visible = False
    '
    'retuStatText
    '
    Me.retuStatText.HeaderText = "สถานะ"
    Me.retuStatText.Name = "retuStatText"
    Me.retuStatText.ReadOnly = True
    Me.retuStatText.Width = 80
    '
    'GoodCode
    '
    Me.GoodCode.HeaderText = "GoodCode"
    Me.GoodCode.Name = "GoodCode"
    Me.GoodCode.ReadOnly = True
    Me.GoodCode.Visible = False
    '
    'NoBranchStock
    '
    Me.NoBranchStock.HeaderText = "NoBranchStock"
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
    'txtTotal
    '
    Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtTotal.Location = New System.Drawing.Point(706, 8)
    Me.txtTotal.Name = "txtTotal"
    Me.txtTotal.Size = New System.Drawing.Size(100, 23)
    Me.txtTotal.TabIndex = 1
    Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    Me.txtTotal.Visible = False
    '
    'Label3
    '
    Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(672, 11)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(28, 16)
    Me.Label3.TabIndex = 0
    Me.Label3.Text = "รวม"
    Me.Label3.Visible = False
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbnPrint, Me.tbnCancel})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.ShowItemToolTips = False
    Me.ToolStrip1.Size = New System.Drawing.Size(1154, 31)
    Me.ToolStrip1.TabIndex = 1
    Me.ToolStrip1.Text = "ToolStrip1"
    '
    'pdc1
    '
    '
    'dtpFrom
    '
    Me.dtpFrom.Location = New System.Drawing.Point(86, 14)
    Me.dtpFrom.Name = "dtpFrom"
    Me.dtpFrom.Size = New System.Drawing.Size(164, 23)
    Me.dtpFrom.TabIndex = 3
    Me.dtpFrom.TabStop = False
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(19, 19)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(61, 16)
    Me.Label6.TabIndex = 2
    Me.Label6.Text = "ตั้งแต่วันที่"
    '
    'dtpTo
    '
    Me.dtpTo.Location = New System.Drawing.Point(86, 43)
    Me.dtpTo.Name = "dtpTo"
    Me.dtpTo.Size = New System.Drawing.Size(164, 23)
    Me.dtpTo.TabIndex = 4
    Me.dtpTo.TabStop = False
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(19, 48)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(45, 16)
    Me.Label7.TabIndex = 5
    Me.Label7.Text = "ถึงวันที่"
    '
    'tbnPrint
    '
    Me.tbnPrint.Image = Global.DrugFront.My.Resources.Resources.printer_inkjet24
    Me.tbnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
    Me.tbnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnPrint.Name = "tbnPrint"
    Me.tbnPrint.Size = New System.Drawing.Size(106, 28)
    Me.tbnPrint.Text = "พิมพ์ใบส่งคืน"
    '
    'tbnCancel
    '
    Me.tbnCancel.Image = Global.DrugFront.My.Resources.Resources.cancel24
    Me.tbnCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
    Me.tbnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnCancel.Name = "tbnCancel"
    Me.tbnCancel.Size = New System.Drawing.Size(116, 28)
    Me.tbnCancel.Text = "ยกเลิกใบส่งคืน"
    '
    'frmCheckStockReturn
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1154, 552)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmCheckStockReturn"
    Me.Tag = "f2e"
    Me.Text = "ตรวจสอบการส่งคืนสินค้า"
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
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents dtgHistReturn As System.Windows.Forms.DataGridView
  Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
  Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents lblRetuDate As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents lblRetuNumb As System.Windows.Forms.Label
  Friend WithEvents dtgReturnList As System.Windows.Forms.DataGridView
  Friend WithEvents lblEmplName As System.Windows.Forms.Label
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents tbnCancel As System.Windows.Forms.ToolStripButton
  Friend WithEvents tbnPrint As System.Windows.Forms.ToolStripButton
  Friend WithEvents pdc1 As System.Drawing.Printing.PrintDocument
  Friend WithEvents lblCancel As System.Windows.Forms.Label
  Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
  Friend WithEvents txtTotal As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents RetuDate As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents RetuNumb As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents statText As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents EmplName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents RetuStat As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents barCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents lotNo As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents expiDate As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents retuRema As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents subTotal As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents retuStatText As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents NoBranchStock As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents stockOnhand As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
