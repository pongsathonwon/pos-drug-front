<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBranchTran
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.btnShow = New System.Windows.Forms.Button
    Me.dtpTo = New System.Windows.Forms.DateTimePicker
    Me.Label2 = New System.Windows.Forms.Label
    Me.dtpFrom = New System.Windows.Forms.DateTimePicker
    Me.Label1 = New System.Windows.Forms.Label
    Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
    Me.dtgMast = New System.Windows.Forms.DataGridView
    Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
    Me.dtgList = New System.Windows.Forms.DataGridView
    Me.goodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.fromUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.fromStockOnhand = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.toStockOnhand = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.toUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.txtEmplName = New System.Windows.Forms.TextBox
    Me.txtEmplCode = New System.Windows.Forms.TextBox
    Me.Label5 = New System.Windows.Forms.Label
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
    Me.tbnRequest = New System.Windows.Forms.ToolStripButton
    Me.tbnCancel = New System.Windows.Forms.ToolStripButton
    Me.tbnTran = New System.Windows.Forms.ToolStripButton
    Me.pdc1 = New System.Drawing.Printing.PrintDocument
    Me.requNumb = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.requDate = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.fromBranchName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.toBranchName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.requEmplName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.tranEmplName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.requStatDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.fromBranchCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.toBranchCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.requStat = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SplitContainer2.Panel1.SuspendLayout()
    Me.SplitContainer2.Panel2.SuspendLayout()
    Me.SplitContainer2.SuspendLayout()
    CType(Me.dtgMast, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer3.Panel1.SuspendLayout()
    Me.SplitContainer3.Panel2.SuspendLayout()
    Me.SplitContainer3.SuspendLayout()
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ToolStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer1.IsSplitterFixed = True
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 31)
    Me.SplitContainer1.Name = "SplitContainer1"
    Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(191, Byte), Integer))
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnShow)
    Me.SplitContainer1.Panel1.Controls.Add(Me.dtpTo)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
    Me.SplitContainer1.Panel1.Controls.Add(Me.dtpFrom)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
    Me.SplitContainer1.Size = New System.Drawing.Size(1091, 533)
    Me.SplitContainer1.SplitterDistance = 54
    Me.SplitContainer1.TabIndex = 0
    Me.SplitContainer1.TabStop = False
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(563, 16)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(130, 25)
    Me.btnShow.TabIndex = 0
    Me.btnShow.Text = "แสดงรายการ"
    Me.btnShow.UseVisualStyleBackColor = True
    '
    'dtpTo
    '
    Me.dtpTo.Location = New System.Drawing.Point(355, 16)
    Me.dtpTo.Name = "dtpTo"
    Me.dtpTo.Size = New System.Drawing.Size(180, 23)
    Me.dtpTo.TabIndex = 2
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(304, 21)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(45, 16)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "ถึงวันที่"
    '
    'dtpFrom
    '
    Me.dtpFrom.Location = New System.Drawing.Point(107, 16)
    Me.dtpFrom.Name = "dtpFrom"
    Me.dtpFrom.Size = New System.Drawing.Size(180, 23)
    Me.dtpFrom.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(32, 21)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(69, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "ระหว่างวันที่"
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
    Me.SplitContainer2.Panel1.Controls.Add(Me.dtgMast)
    '
    'SplitContainer2.Panel2
    '
    Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
    Me.SplitContainer2.Size = New System.Drawing.Size(1091, 475)
    Me.SplitContainer2.SplitterDistance = 259
    Me.SplitContainer2.TabIndex = 0
    Me.SplitContainer2.TabStop = False
    '
    'dtgMast
    '
    Me.dtgMast.AllowUserToAddRows = False
    Me.dtgMast.AllowUserToDeleteRows = False
    Me.dtgMast.AllowUserToResizeColumns = False
    Me.dtgMast.AllowUserToResizeRows = False
    Me.dtgMast.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgMast.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgMast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgMast.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.requNumb, Me.requDate, Me.fromBranchName, Me.toBranchName, Me.requEmplName, Me.tranEmplName, Me.requStatDesc, Me.fromBranchCode, Me.toBranchCode, Me.requStat})
    Me.dtgMast.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgMast.Location = New System.Drawing.Point(0, 0)
    Me.dtgMast.Name = "dtgMast"
    Me.dtgMast.ReadOnly = True
    Me.dtgMast.RowHeadersVisible = False
    Me.dtgMast.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(212, Byte), Integer))
    Me.dtgMast.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgMast.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgMast.Size = New System.Drawing.Size(1091, 259)
    Me.dtgMast.TabIndex = 0
    Me.dtgMast.TabStop = False
    '
    'SplitContainer3
    '
    Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
    Me.SplitContainer3.IsSplitterFixed = True
    Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer3.Name = "SplitContainer3"
    Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer3.Panel1
    '
    Me.SplitContainer3.Panel1.Controls.Add(Me.dtgList)
    '
    'SplitContainer3.Panel2
    '
    Me.SplitContainer3.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(191, Byte), Integer))
    Me.SplitContainer3.Panel2.Controls.Add(Me.txtEmplName)
    Me.SplitContainer3.Panel2.Controls.Add(Me.txtEmplCode)
    Me.SplitContainer3.Panel2.Controls.Add(Me.Label5)
    Me.SplitContainer3.Size = New System.Drawing.Size(1091, 212)
    Me.SplitContainer3.SplitterDistance = 166
    Me.SplitContainer3.TabIndex = 2
    Me.SplitContainer3.TabStop = False
    '
    'dtgList
    '
    Me.dtgList.AllowUserToAddRows = False
    Me.dtgList.AllowUserToDeleteRows = False
    Me.dtgList.AllowUserToResizeColumns = False
    Me.dtgList.AllowUserToResizeRows = False
    Me.dtgList.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(212, Byte), Integer))
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
    Me.dtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.goodName, Me.goodAmou, Me.unitDesc, Me.goodCode, Me.fromUnitCost, Me.fromStockOnhand, Me.toStockOnhand, Me.toUnitCost})
    Me.dtgList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgList.Location = New System.Drawing.Point(0, 0)
    Me.dtgList.Name = "dtgList"
    Me.dtgList.ReadOnly = True
    Me.dtgList.RowHeadersVisible = False
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgList.Size = New System.Drawing.Size(1091, 166)
    Me.dtgList.TabIndex = 1
    Me.dtgList.TabStop = False
    '
    'goodName
    '
    Me.goodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.goodName.HeaderText = "รายการ"
    Me.goodName.Name = "goodName"
    Me.goodName.ReadOnly = True
    '
    'goodAmou
    '
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle4.Format = "n0"
    Me.goodAmou.DefaultCellStyle = DataGridViewCellStyle4
    Me.goodAmou.HeaderText = "จำนวน"
    Me.goodAmou.Name = "goodAmou"
    Me.goodAmou.ReadOnly = True
    '
    'unitDesc
    '
    Me.unitDesc.HeaderText = "หน่วย"
    Me.unitDesc.Name = "unitDesc"
    Me.unitDesc.ReadOnly = True
    '
    'goodCode
    '
    Me.goodCode.HeaderText = "goodCode"
    Me.goodCode.Name = "goodCode"
    Me.goodCode.ReadOnly = True
    Me.goodCode.Visible = False
    '
    'fromUnitCost
    '
    Me.fromUnitCost.HeaderText = "ทุนสาขาต้นทาง"
    Me.fromUnitCost.Name = "fromUnitCost"
    Me.fromUnitCost.ReadOnly = True
    Me.fromUnitCost.Visible = False
    '
    'fromStockOnhand
    '
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle5.Format = "N0"
    Me.fromStockOnhand.DefaultCellStyle = DataGridViewCellStyle5
    Me.fromStockOnhand.HeaderText = "สต๊อคคงเหลือ"
    Me.fromStockOnhand.Name = "fromStockOnhand"
    Me.fromStockOnhand.ReadOnly = True
    Me.fromStockOnhand.Visible = False
    Me.fromStockOnhand.Width = 120
    '
    'toStockOnhand
    '
    Me.toStockOnhand.HeaderText = "คงเหลือปลายทาง"
    Me.toStockOnhand.Name = "toStockOnhand"
    Me.toStockOnhand.ReadOnly = True
    Me.toStockOnhand.Visible = False
    '
    'toUnitCost
    '
    Me.toUnitCost.HeaderText = "ทุนสาขาปลายทาง"
    Me.toUnitCost.Name = "toUnitCost"
    Me.toUnitCost.ReadOnly = True
    Me.toUnitCost.Visible = False
    '
    'txtEmplName
    '
    Me.txtEmplName.Location = New System.Drawing.Point(136, 9)
    Me.txtEmplName.Name = "txtEmplName"
    Me.txtEmplName.ReadOnly = True
    Me.txtEmplName.Size = New System.Drawing.Size(302, 23)
    Me.txtEmplName.TabIndex = 8
    Me.txtEmplName.TabStop = False
    '
    'txtEmplCode
    '
    Me.txtEmplCode.Location = New System.Drawing.Point(83, 9)
    Me.txtEmplCode.Name = "txtEmplCode"
    Me.txtEmplCode.Size = New System.Drawing.Size(47, 23)
    Me.txtEmplCode.TabIndex = 6
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(32, 12)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(38, 16)
    Me.Label5.TabIndex = 7
    Me.Label5.Text = "ผู้โอน"
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbnRequest, Me.tbnCancel, Me.tbnTran})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.ShowItemToolTips = False
    Me.ToolStrip1.Size = New System.Drawing.Size(1091, 31)
    Me.ToolStrip1.TabIndex = 1
    Me.ToolStrip1.Text = "ToolStrip1"
    '
    'tbnRequest
    '
    Me.tbnRequest.Image = Global.DrugFront.My.Resources.Resources.adddocument24
    Me.tbnRequest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
    Me.tbnRequest.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnRequest.Name = "tbnRequest"
    Me.tbnRequest.Size = New System.Drawing.Size(112, 28)
    Me.tbnRequest.Text = "ออกใบขอโอน"
    '
    'tbnCancel
    '
    Me.tbnCancel.Image = Global.DrugFront.My.Resources.Resources.close
    Me.tbnCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
    Me.tbnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnCancel.Name = "tbnCancel"
    Me.tbnCancel.Size = New System.Drawing.Size(72, 28)
    Me.tbnCancel.Text = "ยกเลิก"
    '
    'tbnTran
    '
    Me.tbnTran.Image = Global.DrugFront.My.Resources.Resources.approved24
    Me.tbnTran.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
    Me.tbnTran.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnTran.Name = "tbnTran"
    Me.tbnTran.Size = New System.Drawing.Size(121, 28)
    Me.tbnTran.Text = "บันทึกโอนสินค้า"
    '
    'pdc1
    '
    '
    'requNumb
    '
    Me.requNumb.HeaderText = "เลขที่ใบขอโอน"
    Me.requNumb.Name = "requNumb"
    Me.requNumb.ReadOnly = True
    Me.requNumb.Width = 120
    '
    'requDate
    '
    DataGridViewCellStyle2.Format = "D"
    DataGridViewCellStyle2.NullValue = Nothing
    Me.requDate.DefaultCellStyle = DataGridViewCellStyle2
    Me.requDate.HeaderText = "วันที่"
    Me.requDate.Name = "requDate"
    Me.requDate.ReadOnly = True
    Me.requDate.Width = 120
    '
    'fromBranchName
    '
    Me.fromBranchName.HeaderText = "จากสาขา"
    Me.fromBranchName.Name = "fromBranchName"
    Me.fromBranchName.ReadOnly = True
    Me.fromBranchName.Width = 200
    '
    'toBranchName
    '
    Me.toBranchName.HeaderText = "ไปสาขา"
    Me.toBranchName.Name = "toBranchName"
    Me.toBranchName.ReadOnly = True
    Me.toBranchName.Width = 200
    '
    'requEmplName
    '
    Me.requEmplName.HeaderText = "ผู้ขอโอน"
    Me.requEmplName.Name = "requEmplName"
    Me.requEmplName.ReadOnly = True
    Me.requEmplName.Width = 150
    '
    'tranEmplName
    '
    Me.tranEmplName.HeaderText = "ผู้โอน"
    Me.tranEmplName.Name = "tranEmplName"
    Me.tranEmplName.ReadOnly = True
    Me.tranEmplName.Width = 150
    '
    'requStatDesc
    '
    Me.requStatDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.requStatDesc.HeaderText = "สถานะ"
    Me.requStatDesc.Name = "requStatDesc"
    Me.requStatDesc.ReadOnly = True
    '
    'fromBranchCode
    '
    Me.fromBranchCode.HeaderText = "fromBranchCode"
    Me.fromBranchCode.Name = "fromBranchCode"
    Me.fromBranchCode.ReadOnly = True
    Me.fromBranchCode.Visible = False
    '
    'toBranchCode
    '
    Me.toBranchCode.HeaderText = "toBranchCode"
    Me.toBranchCode.Name = "toBranchCode"
    Me.toBranchCode.ReadOnly = True
    Me.toBranchCode.Visible = False
    '
    'requStat
    '
    Me.requStat.HeaderText = "requStat"
    Me.requStat.Name = "requStat"
    Me.requStat.ReadOnly = True
    Me.requStat.Visible = False
    '
    'frmBranchTran
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1091, 564)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmBranchTran"
    Me.Tag = "f2k"
    Me.Text = "โอนสินค้าระหว่างสาขา"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    Me.SplitContainer2.Panel1.ResumeLayout(False)
    Me.SplitContainer2.Panel2.ResumeLayout(False)
    Me.SplitContainer2.ResumeLayout(False)
    CType(Me.dtgMast, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer3.Panel1.ResumeLayout(False)
    Me.SplitContainer3.Panel2.ResumeLayout(False)
    Me.SplitContainer3.Panel2.PerformLayout()
    Me.SplitContainer3.ResumeLayout(False)
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents tbnRequest As System.Windows.Forms.ToolStripButton
  Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
  Friend WithEvents dtgMast As System.Windows.Forms.DataGridView
  Friend WithEvents dtgList As System.Windows.Forms.DataGridView
  Friend WithEvents tbnCancel As System.Windows.Forms.ToolStripButton
  Friend WithEvents tbnTran As System.Windows.Forms.ToolStripButton
  Friend WithEvents pdc1 As System.Drawing.Printing.PrintDocument
  Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
  Friend WithEvents txtEmplName As System.Windows.Forms.TextBox
  Friend WithEvents txtEmplCode As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents goodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents fromUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents fromStockOnhand As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents toStockOnhand As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents toUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents requNumb As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents requDate As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents fromBranchName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents toBranchName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents requEmplName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents tranEmplName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents requStatDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents fromBranchCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents toBranchCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents requStat As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
