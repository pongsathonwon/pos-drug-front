<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccoClose
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
    Me.pdc1 = New System.Drawing.Printing.PrintDocument
    Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
    Me.dtgGroup = New System.Windows.Forms.DataGridView
    Me.groupCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GroupDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.fromGP = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.toGP = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.TotalPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Label5 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.btnSave = New System.Windows.Forms.Button
    Me.Label1 = New System.Windows.Forms.Label
    Me.lblEmplName = New System.Windows.Forms.Label
    Me.txtEmplID = New System.Windows.Forms.TextBox
    Me.txtRemark = New System.Windows.Forms.TextBox
    Me.btnCal = New System.Windows.Forms.Button
    Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
    Me.dtgPaid = New System.Windows.Forms.DataGridView
    Me.cardName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.payAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.cardCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SplitContainer4 = New System.Windows.Forms.SplitContainer
    Me.dtpClose = New System.Windows.Forms.DateTimePicker
    Me.Label10 = New System.Windows.Forms.Label
    Me.lblTotalSend = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.txtTotalInDraw = New System.Windows.Forms.TextBox
    Me.txtTotalStart = New System.Windows.Forms.TextBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label18 = New System.Windows.Forms.Label
    Me.lblTotalOver = New System.Windows.Forms.Label
    Me.Label16 = New System.Windows.Forms.Label
    Me.lblTotalMembCount = New System.Windows.Forms.Label
    Me.Label11 = New System.Windows.Forms.Label
    Me.Label19 = New System.Windows.Forms.Label
    Me.lblTotalMembPrice = New System.Windows.Forms.Label
    Me.lblTotalCust = New System.Windows.Forms.Label
    Me.Label25 = New System.Windows.Forms.Label
    Me.Label24 = New System.Windows.Forms.Label
    Me.lblAvgSale = New System.Windows.Forms.Label
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.SplitContainer3.Panel1.SuspendLayout()
    Me.SplitContainer3.Panel2.SuspendLayout()
    Me.SplitContainer3.SuspendLayout()
    CType(Me.dtgGroup, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer2.Panel1.SuspendLayout()
    Me.SplitContainer2.Panel2.SuspendLayout()
    Me.SplitContainer2.SuspendLayout()
    CType(Me.dtgPaid, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer4.Panel1.SuspendLayout()
    Me.SplitContainer4.Panel2.SuspendLayout()
    Me.SplitContainer4.SuspendLayout()
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SuspendLayout()
    '
    'pdc1
    '
    '
    'SplitContainer3
    '
    Me.SplitContainer3.BackColor = System.Drawing.SystemColors.Control
    Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer3.IsSplitterFixed = True
    Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer3.Name = "SplitContainer3"
    '
    'SplitContainer3.Panel1
    '
    Me.SplitContainer3.Panel1.Controls.Add(Me.dtgGroup)
    '
    'SplitContainer3.Panel2
    '
    Me.SplitContainer3.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer))
    Me.SplitContainer3.Panel2.Controls.Add(Me.Label5)
    Me.SplitContainer3.Panel2.Controls.Add(Me.Label4)
    Me.SplitContainer3.Panel2.Controls.Add(Me.btnSave)
    Me.SplitContainer3.Panel2.Controls.Add(Me.Label1)
    Me.SplitContainer3.Panel2.Controls.Add(Me.lblEmplName)
    Me.SplitContainer3.Panel2.Controls.Add(Me.txtEmplID)
    Me.SplitContainer3.Panel2.Controls.Add(Me.txtRemark)
    Me.SplitContainer3.Size = New System.Drawing.Size(606, 185)
    Me.SplitContainer3.SplitterDistance = 298
    Me.SplitContainer3.TabIndex = 38
    Me.SplitContainer3.TabStop = False
    '
    'dtgGroup
    '
    Me.dtgGroup.AllowUserToAddRows = False
    Me.dtgGroup.AllowUserToDeleteRows = False
    Me.dtgGroup.AllowUserToResizeColumns = False
    Me.dtgGroup.AllowUserToResizeRows = False
    Me.dtgGroup.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(191, Byte), Integer))
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgGroup.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgGroup.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.groupCode, Me.GroupDesc, Me.fromGP, Me.toGP, Me.TotalPrice})
    Me.dtgGroup.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgGroup.Location = New System.Drawing.Point(0, 0)
    Me.dtgGroup.Name = "dtgGroup"
    Me.dtgGroup.ReadOnly = True
    Me.dtgGroup.RowHeadersVisible = False
    Me.dtgGroup.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer))
    Me.dtgGroup.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgGroup.Size = New System.Drawing.Size(298, 185)
    Me.dtgGroup.TabIndex = 33
    Me.dtgGroup.TabStop = False
    '
    'groupCode
    '
    Me.groupCode.HeaderText = "groupCode"
    Me.groupCode.Name = "groupCode"
    Me.groupCode.ReadOnly = True
    Me.groupCode.Visible = False
    '
    'GroupDesc
    '
    Me.GroupDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.GroupDesc.HeaderText = "กลุ่มสินค้า"
    Me.GroupDesc.Name = "GroupDesc"
    Me.GroupDesc.ReadOnly = True
    '
    'fromGP
    '
    DataGridViewCellStyle2.Format = "N2"
    Me.fromGP.DefaultCellStyle = DataGridViewCellStyle2
    Me.fromGP.HeaderText = "fromGP"
    Me.fromGP.Name = "fromGP"
    Me.fromGP.ReadOnly = True
    Me.fromGP.Visible = False
    '
    'toGP
    '
    DataGridViewCellStyle3.Format = "N2"
    Me.toGP.DefaultCellStyle = DataGridViewCellStyle3
    Me.toGP.HeaderText = "toGP"
    Me.toGP.Name = "toGP"
    Me.toGP.ReadOnly = True
    Me.toGP.Visible = False
    '
    'TotalPrice
    '
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle4.Format = "N4"
    DataGridViewCellStyle4.NullValue = Nothing
    Me.TotalPrice.DefaultCellStyle = DataGridViewCellStyle4
    Me.TotalPrice.HeaderText = "จำนวนเงิน"
    Me.TotalPrice.Name = "TotalPrice"
    Me.TotalPrice.ReadOnly = True
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(17, 41)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(75, 16)
    Me.Label5.TabIndex = 9
    Me.Label5.Text = "เลขประจำตัว"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(17, 69)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(58, 16)
    Me.Label4.TabIndex = 7
    Me.Label4.Text = "หมายเหตุ"
    '
    'btnSave
    '
    Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(159, Byte), Integer))
    Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
    Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.btnSave.Location = New System.Drawing.Point(18, 139)
    Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnSave.Name = "btnSave"
    Me.btnSave.Size = New System.Drawing.Size(271, 28)
    Me.btnSave.TabIndex = 2
    Me.btnSave.Text = "สรุปบัญชี-ปิดรอบการทำงาน F8"
    Me.btnSave.UseVisualStyleBackColor = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(17, 20)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(58, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "แคชเชียร์"
    '
    'lblEmplName
    '
    Me.lblEmplName.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer))
    Me.lblEmplName.Location = New System.Drawing.Point(94, 18)
    Me.lblEmplName.Name = "lblEmplName"
    Me.lblEmplName.Size = New System.Drawing.Size(163, 20)
    Me.lblEmplName.TabIndex = 0
    Me.lblEmplName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'txtEmplID
    '
    Me.txtEmplID.BackColor = System.Drawing.Color.White
    Me.txtEmplID.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtEmplID.Location = New System.Drawing.Point(94, 42)
    Me.txtEmplID.Multiline = True
    Me.txtEmplID.Name = "txtEmplID"
    Me.txtEmplID.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.txtEmplID.Size = New System.Drawing.Size(163, 20)
    Me.txtEmplID.TabIndex = 0
    '
    'txtRemark
    '
    Me.txtRemark.BackColor = System.Drawing.Color.White
    Me.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtRemark.Location = New System.Drawing.Point(94, 66)
    Me.txtRemark.Multiline = True
    Me.txtRemark.Name = "txtRemark"
    Me.txtRemark.Size = New System.Drawing.Size(163, 52)
    Me.txtRemark.TabIndex = 1
    '
    'btnCal
    '
    Me.btnCal.BackColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(191, Byte), Integer))
    Me.btnCal.Cursor = System.Windows.Forms.Cursors.Hand
    Me.btnCal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.btnCal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.btnCal.Location = New System.Drawing.Point(18, 48)
    Me.btnCal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnCal.Name = "btnCal"
    Me.btnCal.Size = New System.Drawing.Size(271, 28)
    Me.btnCal.TabIndex = 10
    Me.btnCal.TabStop = False
    Me.btnCal.Text = "คำนวณสรุปยอดขาย F2"
    Me.btnCal.UseVisualStyleBackColor = False
    '
    'SplitContainer2
    '
    Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer2.IsSplitterFixed = True
    Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer2.Name = "SplitContainer2"
    '
    'SplitContainer2.Panel1
    '
    Me.SplitContainer2.Panel1.Controls.Add(Me.dtgPaid)
    '
    'SplitContainer2.Panel2
    '
    Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer4)
    Me.SplitContainer2.Size = New System.Drawing.Size(606, 484)
    Me.SplitContainer2.SplitterDistance = 298
    Me.SplitContainer2.TabIndex = 32
    Me.SplitContainer2.TabStop = False
    '
    'dtgPaid
    '
    Me.dtgPaid.AllowUserToAddRows = False
    Me.dtgPaid.AllowUserToDeleteRows = False
    Me.dtgPaid.AllowUserToResizeColumns = False
    Me.dtgPaid.AllowUserToResizeRows = False
    Me.dtgPaid.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(191, Byte), Integer))
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgPaid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
    Me.dtgPaid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgPaid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cardName, Me.payAmou, Me.cardCode})
    Me.dtgPaid.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgPaid.Location = New System.Drawing.Point(0, 0)
    Me.dtgPaid.Name = "dtgPaid"
    Me.dtgPaid.ReadOnly = True
    Me.dtgPaid.RowHeadersVisible = False
    Me.dtgPaid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
    Me.dtgPaid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgPaid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgPaid.Size = New System.Drawing.Size(298, 484)
    Me.dtgPaid.TabIndex = 37
    Me.dtgPaid.TabStop = False
    '
    'cardName
    '
    Me.cardName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.cardName.HeaderText = "รายการ"
    Me.cardName.Name = "cardName"
    Me.cardName.ReadOnly = True
    '
    'payAmou
    '
    DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle6.Format = "N2"
    Me.payAmou.DefaultCellStyle = DataGridViewCellStyle6
    Me.payAmou.HeaderText = "จำนวนเงิน"
    Me.payAmou.Name = "payAmou"
    Me.payAmou.ReadOnly = True
    '
    'cardCode
    '
    Me.cardCode.HeaderText = "cardCode"
    Me.cardCode.Name = "cardCode"
    Me.cardCode.ReadOnly = True
    Me.cardCode.Visible = False
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
    Me.SplitContainer4.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
    Me.SplitContainer4.Panel1.Controls.Add(Me.btnCal)
    Me.SplitContainer4.Panel1.Controls.Add(Me.dtpClose)
    Me.SplitContainer4.Panel1.Controls.Add(Me.Label10)
    Me.SplitContainer4.Panel1.Controls.Add(Me.lblTotalSend)
    Me.SplitContainer4.Panel1.Controls.Add(Me.Label3)
    Me.SplitContainer4.Panel1.Controls.Add(Me.txtTotalInDraw)
    Me.SplitContainer4.Panel1.Controls.Add(Me.txtTotalStart)
    Me.SplitContainer4.Panel1.Controls.Add(Me.Label2)
    Me.SplitContainer4.Panel1.Controls.Add(Me.Label18)
    Me.SplitContainer4.Panel1.Controls.Add(Me.lblTotalOver)
    Me.SplitContainer4.Panel1.Controls.Add(Me.Label16)
    '
    'SplitContainer4.Panel2
    '
    Me.SplitContainer4.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
    Me.SplitContainer4.Panel2.Controls.Add(Me.lblTotalMembCount)
    Me.SplitContainer4.Panel2.Controls.Add(Me.Label11)
    Me.SplitContainer4.Panel2.Controls.Add(Me.Label19)
    Me.SplitContainer4.Panel2.Controls.Add(Me.lblTotalMembPrice)
    Me.SplitContainer4.Panel2.Controls.Add(Me.lblTotalCust)
    Me.SplitContainer4.Panel2.Controls.Add(Me.Label25)
    Me.SplitContainer4.Panel2.Controls.Add(Me.Label24)
    Me.SplitContainer4.Panel2.Controls.Add(Me.lblAvgSale)
    Me.SplitContainer4.Size = New System.Drawing.Size(304, 484)
    Me.SplitContainer4.SplitterDistance = 250
    Me.SplitContainer4.TabIndex = 0
    Me.SplitContainer4.TabStop = False
    '
    'dtpClose
    '
    Me.dtpClose.Location = New System.Drawing.Point(97, 13)
    Me.dtpClose.Name = "dtpClose"
    Me.dtpClose.Size = New System.Drawing.Size(192, 23)
    Me.dtpClose.TabIndex = 35
    Me.dtpClose.TabStop = False
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(15, 18)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(64, 16)
    Me.Label10.TabIndex = 34
    Me.Label10.Text = "ประจำวันที่"
    '
    'lblTotalSend
    '
    Me.lblTotalSend.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
    Me.lblTotalSend.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblTotalSend.ForeColor = System.Drawing.Color.Navy
    Me.lblTotalSend.Location = New System.Drawing.Point(188, 140)
    Me.lblTotalSend.Name = "lblTotalSend"
    Me.lblTotalSend.Size = New System.Drawing.Size(87, 20)
    Me.lblTotalSend.TabIndex = 32
    Me.lblTotalSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(20, 142)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(70, 16)
    Me.Label3.TabIndex = 5
    Me.Label3.Text = "เงินสดนำส่ง"
    '
    'txtTotalInDraw
    '
    Me.txtTotalInDraw.BackColor = System.Drawing.Color.White
    Me.txtTotalInDraw.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtTotalInDraw.Location = New System.Drawing.Point(188, 94)
    Me.txtTotalInDraw.Multiline = True
    Me.txtTotalInDraw.Name = "txtTotalInDraw"
    Me.txtTotalInDraw.Size = New System.Drawing.Size(87, 20)
    Me.txtTotalInDraw.TabIndex = 0
    Me.txtTotalInDraw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'txtTotalStart
    '
    Me.txtTotalStart.BackColor = System.Drawing.Color.White
    Me.txtTotalStart.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtTotalStart.Location = New System.Drawing.Point(188, 117)
    Me.txtTotalStart.Multiline = True
    Me.txtTotalStart.Name = "txtTotalStart"
    Me.txtTotalStart.Size = New System.Drawing.Size(87, 20)
    Me.txtTotalStart.TabIndex = 1
    Me.txtTotalStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(21, 94)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(99, 16)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "เงินสดจากการนับ"
    '
    'Label18
    '
    Me.Label18.AutoSize = True
    Me.Label18.Location = New System.Drawing.Point(21, 165)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(55, 16)
    Me.Label18.TabIndex = 27
    Me.Label18.Text = "ขาด-เกิน"
    '
    'lblTotalOver
    '
    Me.lblTotalOver.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
    Me.lblTotalOver.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblTotalOver.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lblTotalOver.Location = New System.Drawing.Point(188, 163)
    Me.lblTotalOver.Name = "lblTotalOver"
    Me.lblTotalOver.Size = New System.Drawing.Size(87, 20)
    Me.lblTotalOver.TabIndex = 28
    Me.lblTotalOver.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.Location = New System.Drawing.Point(21, 117)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(42, 16)
    Me.Label16.TabIndex = 25
    Me.Label16.Text = "เงินต้น"
    '
    'lblTotalMembCount
    '
    Me.lblTotalMembCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
    Me.lblTotalMembCount.Location = New System.Drawing.Point(188, 42)
    Me.lblTotalMembCount.Name = "lblTotalMembCount"
    Me.lblTotalMembCount.Size = New System.Drawing.Size(87, 20)
    Me.lblTotalMembCount.TabIndex = 41
    Me.lblTotalMembCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(22, 44)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(103, 16)
    Me.Label11.TabIndex = 39
    Me.Label11.Text = "จำนวนสมาชิกใหม่"
    '
    'Label19
    '
    Me.Label19.AutoSize = True
    Me.Label19.Location = New System.Drawing.Point(22, 69)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(132, 16)
    Me.Label19.TabIndex = 38
    Me.Label19.Text = "รวมค่าสมัครสมาชิกใหม่"
    '
    'lblTotalMembPrice
    '
    Me.lblTotalMembPrice.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
    Me.lblTotalMembPrice.Location = New System.Drawing.Point(188, 67)
    Me.lblTotalMembPrice.Name = "lblTotalMembPrice"
    Me.lblTotalMembPrice.Size = New System.Drawing.Size(87, 20)
    Me.lblTotalMembPrice.TabIndex = 40
    Me.lblTotalMembPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'lblTotalCust
    '
    Me.lblTotalCust.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
    Me.lblTotalCust.Location = New System.Drawing.Point(188, 18)
    Me.lblTotalCust.Name = "lblTotalCust"
    Me.lblTotalCust.Size = New System.Drawing.Size(87, 20)
    Me.lblTotalCust.TabIndex = 37
    Me.lblTotalCust.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label25
    '
    Me.Label25.AutoSize = True
    Me.Label25.Location = New System.Drawing.Point(22, 20)
    Me.Label25.Name = "Label25"
    Me.Label25.Size = New System.Drawing.Size(73, 16)
    Me.Label25.TabIndex = 35
    Me.Label25.Text = "จำนวนลูกค้า"
    '
    'Label24
    '
    Me.Label24.AutoSize = True
    Me.Label24.Location = New System.Drawing.Point(21, 115)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(79, 16)
    Me.Label24.TabIndex = 34
    Me.Label24.Text = "ขายเฉลี่ย/บิล"
    '
    'lblAvgSale
    '
    Me.lblAvgSale.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
    Me.lblAvgSale.Location = New System.Drawing.Point(188, 113)
    Me.lblAvgSale.Name = "lblAvgSale"
    Me.lblAvgSale.Size = New System.Drawing.Size(87, 20)
    Me.lblAvgSale.TabIndex = 36
    Me.lblAvgSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control
    Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(191, Byte), Integer))
    Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
    Me.SplitContainer1.Size = New System.Drawing.Size(606, 674)
    Me.SplitContainer1.SplitterDistance = 484
    Me.SplitContainer1.SplitterWidth = 5
    Me.SplitContainer1.TabIndex = 10
    Me.SplitContainer1.TabStop = False
    '
    'frmAccoCloseNew
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(606, 674)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmAccoCloseNew"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Tag = "f1h"
    Me.Text = "สรุปบัญชี-ปิดรอบการทำงาน"
    Me.SplitContainer3.Panel1.ResumeLayout(False)
    Me.SplitContainer3.Panel2.ResumeLayout(False)
    Me.SplitContainer3.Panel2.PerformLayout()
    Me.SplitContainer3.ResumeLayout(False)
    CType(Me.dtgGroup, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer2.Panel1.ResumeLayout(False)
    Me.SplitContainer2.Panel2.ResumeLayout(False)
    Me.SplitContainer2.ResumeLayout(False)
    CType(Me.dtgPaid, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer4.Panel1.ResumeLayout(False)
    Me.SplitContainer4.Panel1.PerformLayout()
    Me.SplitContainer4.Panel2.ResumeLayout(False)
    Me.SplitContainer4.Panel2.PerformLayout()
    Me.SplitContainer4.ResumeLayout(False)
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents pdc1 As System.Drawing.Printing.PrintDocument
  Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
  Friend WithEvents dtgGroup As System.Windows.Forms.DataGridView
  Friend WithEvents groupCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GroupDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents fromGP As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents toGP As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents TotalPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents btnCal As System.Windows.Forms.Button
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents btnSave As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents lblEmplName As System.Windows.Forms.Label
  Friend WithEvents txtEmplID As System.Windows.Forms.TextBox
  Friend WithEvents txtRemark As System.Windows.Forms.TextBox
  Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
  Friend WithEvents dtgPaid As System.Windows.Forms.DataGridView
  Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
  Friend WithEvents dtpClose As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents lblTotalSend As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtTotalInDraw As System.Windows.Forms.TextBox
  Friend WithEvents txtTotalStart As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents lblTotalOver As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents lblTotalMembCount As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents lblTotalMembPrice As System.Windows.Forms.Label
  Friend WithEvents lblTotalCust As System.Windows.Forms.Label
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents Label24 As System.Windows.Forms.Label
  Friend WithEvents lblAvgSale As System.Windows.Forms.Label
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents cardName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents payAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents cardCode As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
