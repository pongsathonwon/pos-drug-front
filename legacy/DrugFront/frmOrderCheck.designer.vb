<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrderCheck
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
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
    Me.Label6 = New System.Windows.Forms.Label
    Me.btnShow = New System.Windows.Forms.Button
    Me.dtpTo = New System.Windows.Forms.DateTimePicker
    Me.dtpFrom = New System.Windows.Forms.DateTimePicker
    Me.Label1 = New System.Windows.Forms.Label
    Me.SplitContainer4 = New System.Windows.Forms.SplitContainer
    Me.dtgHistOrder = New System.Windows.Forms.DataGridView
    Me.OrderDate = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.OrderNumb = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.shipTo = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Stat = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.OrderRema = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.OrderTime = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.EmplName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.OrderStat = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.totalPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.OrderDay = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Label3 = New System.Windows.Forms.Label
    Me.lblTotalPrice = New System.Windows.Forms.Label
    Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
    Me.Label5 = New System.Windows.Forms.Label
    Me.lblOrderDate = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.lblOrderNumb = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.lblEmplName = New System.Windows.Forms.Label
    Me.dtgOrderList = New System.Windows.Forms.DataGridView
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
    Me.tbnCancel = New System.Windows.Forms.ToolStripButton
    Me.tbnRefresh = New System.Windows.Forms.ToolStripButton
    Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodRema = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.itemTypeDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitFactor = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.isBooking = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SplitContainer2.Panel1.SuspendLayout()
    Me.SplitContainer2.Panel2.SuspendLayout()
    Me.SplitContainer2.SuspendLayout()
    Me.SplitContainer4.Panel1.SuspendLayout()
    Me.SplitContainer4.Panel2.SuspendLayout()
    Me.SplitContainer4.SuspendLayout()
    CType(Me.dtgHistOrder, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer3.Panel1.SuspendLayout()
    Me.SplitContainer3.Panel2.SuspendLayout()
    Me.SplitContainer3.SuspendLayout()
    CType(Me.dtgOrderList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ToolStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer1.IsSplitterFixed = True
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
    Me.SplitContainer1.Name = "SplitContainer1"
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
    Me.SplitContainer1.Size = New System.Drawing.Size(1184, 512)
    Me.SplitContainer1.SplitterDistance = 492
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
    Me.SplitContainer2.Panel1.Controls.Add(Me.Label6)
    Me.SplitContainer2.Panel1.Controls.Add(Me.btnShow)
    Me.SplitContainer2.Panel1.Controls.Add(Me.dtpTo)
    Me.SplitContainer2.Panel1.Controls.Add(Me.dtpFrom)
    Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
    '
    'SplitContainer2.Panel2
    '
    Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer4)
    Me.SplitContainer2.Size = New System.Drawing.Size(492, 512)
    Me.SplitContainer2.SplitterDistance = 34
    Me.SplitContainer2.TabIndex = 0
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(206, 9)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(22, 16)
    Me.Label6.TabIndex = 4
    Me.Label6.Text = "ถึง"
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(386, 6)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(95, 23)
    Me.btnShow.TabIndex = 3
    Me.btnShow.Text = "แสดงรายการ"
    Me.btnShow.UseVisualStyleBackColor = True
    '
    'dtpTo
    '
    Me.dtpTo.Location = New System.Drawing.Point(234, 6)
    Me.dtpTo.Name = "dtpTo"
    Me.dtpTo.Size = New System.Drawing.Size(146, 23)
    Me.dtpTo.TabIndex = 2
    '
    'dtpFrom
    '
    Me.dtpFrom.Location = New System.Drawing.Point(54, 6)
    Me.dtpFrom.Name = "dtpFrom"
    Me.dtpFrom.Size = New System.Drawing.Size(146, 23)
    Me.dtpFrom.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(10, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(38, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "ตั้งแต่"
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
    Me.SplitContainer4.Panel1.Controls.Add(Me.dtgHistOrder)
    '
    'SplitContainer4.Panel2
    '
    Me.SplitContainer4.Panel2.BackColor = System.Drawing.Color.Plum
    Me.SplitContainer4.Panel2.Controls.Add(Me.Label3)
    Me.SplitContainer4.Panel2.Controls.Add(Me.lblTotalPrice)
    Me.SplitContainer4.Size = New System.Drawing.Size(492, 474)
    Me.SplitContainer4.SplitterDistance = 428
    Me.SplitContainer4.TabIndex = 2
    '
    'dtgHistOrder
    '
    Me.dtgHistOrder.AllowUserToAddRows = False
    Me.dtgHistOrder.AllowUserToDeleteRows = False
    Me.dtgHistOrder.AllowUserToResizeColumns = False
    Me.dtgHistOrder.AllowUserToResizeRows = False
    Me.dtgHistOrder.BackgroundColor = System.Drawing.Color.LavenderBlush
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgHistOrder.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgHistOrder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrderDate, Me.OrderNumb, Me.shipTo, Me.Stat, Me.OrderRema, Me.OrderTime, Me.EmplName, Me.OrderStat, Me.totalPrice, Me.OrderDay})
    Me.dtgHistOrder.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgHistOrder.Location = New System.Drawing.Point(0, 0)
    Me.dtgHistOrder.Name = "dtgHistOrder"
    Me.dtgHistOrder.ReadOnly = True
    Me.dtgHistOrder.RowHeadersVisible = False
    Me.dtgHistOrder.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Plum
    Me.dtgHistOrder.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgHistOrder.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.dtgHistOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgHistOrder.Size = New System.Drawing.Size(492, 428)
    Me.dtgHistOrder.TabIndex = 0
    '
    'OrderDate
    '
    DataGridViewCellStyle2.Format = "d"
    DataGridViewCellStyle2.NullValue = Nothing
    Me.OrderDate.DefaultCellStyle = DataGridViewCellStyle2
    Me.OrderDate.HeaderText = "วันที่"
    Me.OrderDate.Name = "OrderDate"
    Me.OrderDate.ReadOnly = True
    '
    'OrderNumb
    '
    Me.OrderNumb.HeaderText = "เลขที่ใบสั่ง"
    Me.OrderNumb.Name = "OrderNumb"
    Me.OrderNumb.ReadOnly = True
    Me.OrderNumb.Width = 75
    '
    'shipTo
    '
    Me.shipTo.HeaderText = "Ship To"
    Me.shipTo.Name = "shipTo"
    Me.shipTo.ReadOnly = True
    Me.shipTo.Width = 80
    '
    'Stat
    '
    Me.Stat.HeaderText = "สถานะ"
    Me.Stat.Name = "Stat"
    Me.Stat.ReadOnly = True
    Me.Stat.Width = 120
    '
    'OrderRema
    '
    Me.OrderRema.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.OrderRema.HeaderText = "หมายเหตุ"
    Me.OrderRema.Name = "OrderRema"
    Me.OrderRema.ReadOnly = True
    '
    'OrderTime
    '
    Me.OrderTime.HeaderText = "เวลา"
    Me.OrderTime.Name = "OrderTime"
    Me.OrderTime.ReadOnly = True
    Me.OrderTime.Visible = False
    Me.OrderTime.Width = 60
    '
    'EmplName
    '
    Me.EmplName.HeaderText = "emplName"
    Me.EmplName.Name = "EmplName"
    Me.EmplName.ReadOnly = True
    Me.EmplName.Visible = False
    '
    'OrderStat
    '
    Me.OrderStat.HeaderText = "orderStat"
    Me.OrderStat.Name = "OrderStat"
    Me.OrderStat.ReadOnly = True
    Me.OrderStat.Visible = False
    '
    'totalPrice
    '
    Me.totalPrice.HeaderText = "totalPrice"
    Me.totalPrice.Name = "totalPrice"
    Me.totalPrice.ReadOnly = True
    Me.totalPrice.Visible = False
    '
    'OrderDay
    '
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    Me.OrderDay.DefaultCellStyle = DataGridViewCellStyle3
    Me.OrderDay.HeaderText = "วันที่"
    Me.OrderDay.Name = "OrderDay"
    Me.OrderDay.ReadOnly = True
    Me.OrderDay.Visible = False
    Me.OrderDay.Width = 40
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(146, 14)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(66, 16)
    Me.Label3.TabIndex = 2
    Me.Label3.Text = "รวมเป็นเงิน"
    '
    'lblTotalPrice
    '
    Me.lblTotalPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblTotalPrice.Location = New System.Drawing.Point(375, 11)
    Me.lblTotalPrice.Name = "lblTotalPrice"
    Me.lblTotalPrice.Size = New System.Drawing.Size(106, 22)
    Me.lblTotalPrice.TabIndex = 1
    Me.lblTotalPrice.Text = "0.00"
    Me.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label5)
    Me.SplitContainer3.Panel1.Controls.Add(Me.lblOrderDate)
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label4)
    Me.SplitContainer3.Panel1.Controls.Add(Me.lblOrderNumb)
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label2)
    Me.SplitContainer3.Panel1.Controls.Add(Me.lblEmplName)
    '
    'SplitContainer3.Panel2
    '
    Me.SplitContainer3.Panel2.Controls.Add(Me.dtgOrderList)
    Me.SplitContainer3.Size = New System.Drawing.Size(688, 512)
    Me.SplitContainer3.SplitterDistance = 34
    Me.SplitContainer3.TabIndex = 0
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(305, 9)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(30, 16)
    Me.Label5.TabIndex = 4
    Me.Label5.Text = "ผู้สั่ง"
    '
    'lblOrderDate
    '
    Me.lblOrderDate.ForeColor = System.Drawing.Color.Navy
    Me.lblOrderDate.Location = New System.Drawing.Point(218, 9)
    Me.lblOrderDate.Name = "lblOrderDate"
    Me.lblOrderDate.Size = New System.Drawing.Size(81, 19)
    Me.lblOrderDate.TabIndex = 3
    Me.lblOrderDate.Text = "20/12/2551 10:15"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(181, 9)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(31, 16)
    Me.Label4.TabIndex = 2
    Me.Label4.Text = "วันที่"
    '
    'lblOrderNumb
    '
    Me.lblOrderNumb.ForeColor = System.Drawing.Color.Navy
    Me.lblOrderNumb.Location = New System.Drawing.Point(85, 9)
    Me.lblOrderNumb.Name = "lblOrderNumb"
    Me.lblOrderNumb.Size = New System.Drawing.Size(90, 19)
    Me.lblOrderNumb.TabIndex = 1
    Me.lblOrderNumb.Text = "1234567890"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(14, 9)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(65, 16)
    Me.Label2.TabIndex = 0
    Me.Label2.Text = "เลขที่ใบสั่ง"
    '
    'lblEmplName
    '
    Me.lblEmplName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblEmplName.ForeColor = System.Drawing.Color.Navy
    Me.lblEmplName.Location = New System.Drawing.Point(341, 9)
    Me.lblEmplName.Name = "lblEmplName"
    Me.lblEmplName.Size = New System.Drawing.Size(335, 16)
    Me.lblEmplName.TabIndex = 11
    Me.lblEmplName.Text = "ประภา มีลาภ"
    '
    'dtgOrderList
    '
    Me.dtgOrderList.AllowUserToAddRows = False
    Me.dtgOrderList.AllowUserToDeleteRows = False
    Me.dtgOrderList.AllowUserToResizeColumns = False
    Me.dtgOrderList.AllowUserToResizeRows = False
    Me.dtgOrderList.BackgroundColor = System.Drawing.Color.LavenderBlush
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgOrderList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
    Me.dtgOrderList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.GoodName, Me.goodRema, Me.GoodAmou, Me.UnitDesc, Me.itemTypeDesc, Me.goodCode, Me.unitFactor, Me.isBooking})
    Me.dtgOrderList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgOrderList.Location = New System.Drawing.Point(0, 0)
    Me.dtgOrderList.Name = "dtgOrderList"
    Me.dtgOrderList.ReadOnly = True
    Me.dtgOrderList.RowHeadersVisible = False
    Me.dtgOrderList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Plum
    Me.dtgOrderList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgOrderList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.dtgOrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgOrderList.Size = New System.Drawing.Size(688, 474)
    Me.dtgOrderList.TabIndex = 1
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbnCancel, Me.tbnRefresh})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.ShowItemToolTips = False
    Me.ToolStrip1.Size = New System.Drawing.Size(1184, 25)
    Me.ToolStrip1.TabIndex = 1
    Me.ToolStrip1.Text = "ToolStrip1"
    '
    'tbnCancel
    '
    Me.tbnCancel.ForeColor = System.Drawing.Color.DarkRed
    Me.tbnCancel.Image = Global.DrugFront.My.Resources.Resources.delete
    Me.tbnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnCancel.Name = "tbnCancel"
    Me.tbnCancel.Size = New System.Drawing.Size(92, 22)
    Me.tbnCancel.Text = "ยกเลิกใบสั่ง"
    '
    'tbnRefresh
    '
    Me.tbnRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
    Me.tbnRefresh.Image = Global.DrugFront.My.Resources.Resources.reload
    Me.tbnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnRefresh.Name = "tbnRefresh"
    Me.tbnRefresh.Size = New System.Drawing.Size(72, 22)
    Me.tbnRefresh.Text = "Refresh"
    Me.tbnRefresh.Visible = False
    '
    'Item
    '
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    Me.Item.DefaultCellStyle = DataGridViewCellStyle5
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
    'goodRema
    '
    Me.goodRema.HeaderText = "หมายเหตุ"
    Me.goodRema.Name = "goodRema"
    Me.goodRema.ReadOnly = True
    Me.goodRema.Width = 150
    '
    'GoodAmou
    '
    DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    Me.GoodAmou.DefaultCellStyle = DataGridViewCellStyle6
    Me.GoodAmou.HeaderText = "จำนวน"
    Me.GoodAmou.Name = "GoodAmou"
    Me.GoodAmou.ReadOnly = True
    Me.GoodAmou.Width = 70
    '
    'UnitDesc
    '
    Me.UnitDesc.HeaderText = "หน่วย"
    Me.UnitDesc.Name = "UnitDesc"
    Me.UnitDesc.ReadOnly = True
    '
    'itemTypeDesc
    '
    Me.itemTypeDesc.HeaderText = "หมายเหตุ"
    Me.itemTypeDesc.Name = "itemTypeDesc"
    Me.itemTypeDesc.ReadOnly = True
    Me.itemTypeDesc.Width = 80
    '
    'goodCode
    '
    Me.goodCode.HeaderText = "goodCode"
    Me.goodCode.Name = "goodCode"
    Me.goodCode.ReadOnly = True
    Me.goodCode.Visible = False
    '
    'unitFactor
    '
    Me.unitFactor.HeaderText = "unitFactor"
    Me.unitFactor.Name = "unitFactor"
    Me.unitFactor.ReadOnly = True
    Me.unitFactor.Visible = False
    '
    'isBooking
    '
    Me.isBooking.HeaderText = "isBooking"
    Me.isBooking.Name = "isBooking"
    Me.isBooking.ReadOnly = True
    Me.isBooking.Visible = False
    '
    'frmOrderCheck
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1184, 537)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmOrderCheck"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Tag = "f2d"
    Me.Text = "ตรวจสอบการสั่งสินค้า"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    Me.SplitContainer2.Panel1.ResumeLayout(False)
    Me.SplitContainer2.Panel1.PerformLayout()
    Me.SplitContainer2.Panel2.ResumeLayout(False)
    Me.SplitContainer2.ResumeLayout(False)
    Me.SplitContainer4.Panel1.ResumeLayout(False)
    Me.SplitContainer4.Panel2.ResumeLayout(False)
    Me.SplitContainer4.Panel2.PerformLayout()
    Me.SplitContainer4.ResumeLayout(False)
    CType(Me.dtgHistOrder, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer3.Panel1.ResumeLayout(False)
    Me.SplitContainer3.Panel1.PerformLayout()
    Me.SplitContainer3.Panel2.ResumeLayout(False)
    Me.SplitContainer3.ResumeLayout(False)
    CType(Me.dtgOrderList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents dtgHistOrder As System.Windows.Forms.DataGridView
  Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
  Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents lblOrderDate As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents lblOrderNumb As System.Windows.Forms.Label
  Friend WithEvents dtgOrderList As System.Windows.Forms.DataGridView
  Friend WithEvents lblEmplName As System.Windows.Forms.Label
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents tbnCancel As System.Windows.Forms.ToolStripButton
  Friend WithEvents lblTotalPrice As System.Windows.Forms.Label
  Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents tbnRefresh As System.Windows.Forms.ToolStripButton
  Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents OrderDate As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents OrderNumb As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents shipTo As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Stat As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents OrderRema As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents OrderTime As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents EmplName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents OrderStat As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents totalPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents OrderDay As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodRema As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents itemTypeDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitFactor As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents isBooking As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
