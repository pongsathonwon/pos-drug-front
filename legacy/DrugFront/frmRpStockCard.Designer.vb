<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRpStockCard
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
    Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.dtgList2 = New System.Windows.Forms.DataGridView
    Me.branchCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.invoNumb = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.sendAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.receAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Button1 = New System.Windows.Forms.Button
    Me.txtUnitDesc = New System.Windows.Forms.TextBox
    Me.Label5 = New System.Windows.Forms.Label
    Me.txtGoodName = New System.Windows.Forms.TextBox
    Me.txtBarCode = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.dtpTo = New System.Windows.Forms.DateTimePicker
    Me.Label4 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.btnShow = New System.Windows.Forms.Button
    Me.dtpFrom = New System.Windows.Forms.DateTimePicker
    Me.Label1 = New System.Windows.Forms.Label
    Me.dtgCard = New System.Windows.Forms.DataGridView
    Me.stockDate = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.stockTime = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.docNumb = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.emplName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.workDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.inStock = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.outStock = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.stockOnhand = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.workType = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
    Me.tbnClear = New System.Windows.Forms.ToolStripButton
    Me.tbnGoodSearch = New System.Windows.Forms.ToolStripButton
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    CType(Me.dtgList2, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dtgCard, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Plum
    Me.SplitContainer1.Panel1.Controls.Add(Me.dtgList2)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtUnitDesc)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtGoodName)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtBarCode)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
    Me.SplitContainer1.Panel1.Controls.Add(Me.dtpTo)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnShow)
    Me.SplitContainer1.Panel1.Controls.Add(Me.dtpFrom)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.dtgCard)
    Me.SplitContainer1.Size = New System.Drawing.Size(949, 530)
    Me.SplitContainer1.SplitterDistance = 86
    Me.SplitContainer1.TabIndex = 0
    Me.SplitContainer1.TabStop = False
    '
    'dtgList2
    '
    Me.dtgList2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgList2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.branchCode, Me.invoNumb, Me.goodName, Me.sendAmou, Me.receAmou})
    Me.dtgList2.Location = New System.Drawing.Point(880, 12)
    Me.dtgList2.Name = "dtgList2"
    Me.dtgList2.Size = New System.Drawing.Size(57, 59)
    Me.dtgList2.TabIndex = 1
    Me.dtgList2.Visible = False
    '
    'branchCode
    '
    Me.branchCode.HeaderText = "branchCode"
    Me.branchCode.Name = "branchCode"
    '
    'invoNumb
    '
    Me.invoNumb.HeaderText = "invoNumb"
    Me.invoNumb.Name = "invoNumb"
    '
    'goodName
    '
    Me.goodName.HeaderText = "goodName"
    Me.goodName.Name = "goodName"
    '
    'sendAmou
    '
    Me.sendAmou.HeaderText = "sendAmou"
    Me.sendAmou.Name = "sendAmou"
    '
    'receAmou
    '
    Me.receAmou.HeaderText = "receAmou"
    Me.receAmou.Name = "receAmou"
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(799, 17)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(75, 23)
    Me.Button1.TabIndex = 11
    Me.Button1.Text = "Button1"
    Me.Button1.UseVisualStyleBackColor = True
    Me.Button1.Visible = False
    '
    'txtUnitDesc
    '
    Me.txtUnitDesc.BackColor = System.Drawing.Color.LavenderBlush
    Me.txtUnitDesc.Location = New System.Drawing.Point(540, 46)
    Me.txtUnitDesc.Name = "txtUnitDesc"
    Me.txtUnitDesc.ReadOnly = True
    Me.txtUnitDesc.Size = New System.Drawing.Size(78, 23)
    Me.txtUnitDesc.TabIndex = 9
    Me.txtUnitDesc.TabStop = False
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(496, 49)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(38, 16)
    Me.Label5.TabIndex = 8
    Me.Label5.Text = "หน่วย"
    '
    'txtGoodName
    '
    Me.txtGoodName.BackColor = System.Drawing.Color.LavenderBlush
    Me.txtGoodName.Location = New System.Drawing.Point(326, 17)
    Me.txtGoodName.Name = "txtGoodName"
    Me.txtGoodName.ReadOnly = True
    Me.txtGoodName.Size = New System.Drawing.Size(420, 23)
    Me.txtGoodName.TabIndex = 7
    Me.txtGoodName.TabStop = False
    '
    'txtBarCode
    '
    Me.txtBarCode.Location = New System.Drawing.Point(88, 17)
    Me.txtBarCode.Name = "txtBarCode"
    Me.txtBarCode.Size = New System.Drawing.Size(164, 23)
    Me.txtBarCode.TabIndex = 0
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(22, 22)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(60, 16)
    Me.Label3.TabIndex = 5
    Me.Label3.Text = "รหัสสินค้า"
    '
    'dtpTo
    '
    Me.dtpTo.Location = New System.Drawing.Point(326, 46)
    Me.dtpTo.Name = "dtpTo"
    Me.dtpTo.Size = New System.Drawing.Size(164, 23)
    Me.dtpTo.TabIndex = 2
    Me.dtpTo.TabStop = False
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(266, 22)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(54, 16)
    Me.Label4.TabIndex = 3
    Me.Label4.Text = "ชื่อสินค้า"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(266, 51)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(45, 16)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "ถึงวันที่"
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(637, 45)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(109, 25)
    Me.btnShow.TabIndex = 1
    Me.btnShow.Text = "แสดงรายการ"
    Me.btnShow.UseVisualStyleBackColor = True
    '
    'dtpFrom
    '
    Me.dtpFrom.Location = New System.Drawing.Point(88, 46)
    Me.dtpFrom.Name = "dtpFrom"
    Me.dtpFrom.Size = New System.Drawing.Size(164, 23)
    Me.dtpFrom.TabIndex = 1
    Me.dtpFrom.TabStop = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(21, 51)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(61, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "ตั้งแต่วันที่"
    '
    'dtgCard
    '
    Me.dtgCard.AllowUserToAddRows = False
    Me.dtgCard.AllowUserToDeleteRows = False
    Me.dtgCard.AllowUserToResizeColumns = False
    Me.dtgCard.AllowUserToResizeRows = False
    Me.dtgCard.BackgroundColor = System.Drawing.Color.LavenderBlush
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgCard.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgCard.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.stockDate, Me.stockTime, Me.docNumb, Me.emplName, Me.workDesc, Me.inStock, Me.outStock, Me.stockOnhand, Me.workType})
    DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LavenderBlush
    DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
    DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.dtgCard.DefaultCellStyle = DataGridViewCellStyle6
    Me.dtgCard.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgCard.Location = New System.Drawing.Point(0, 0)
    Me.dtgCard.Name = "dtgCard"
    Me.dtgCard.ReadOnly = True
    Me.dtgCard.RowHeadersVisible = False
    Me.dtgCard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgCard.Size = New System.Drawing.Size(949, 440)
    Me.dtgCard.TabIndex = 0
    '
    'stockDate
    '
    DataGridViewCellStyle2.Format = "d"
    DataGridViewCellStyle2.NullValue = Nothing
    Me.stockDate.DefaultCellStyle = DataGridViewCellStyle2
    Me.stockDate.HeaderText = "วันที่"
    Me.stockDate.Name = "stockDate"
    Me.stockDate.ReadOnly = True
    '
    'stockTime
    '
    Me.stockTime.HeaderText = "เวลา"
    Me.stockTime.Name = "stockTime"
    Me.stockTime.ReadOnly = True
    Me.stockTime.Width = 50
    '
    'docNumb
    '
    Me.docNumb.HeaderText = "เลขที่เอกสาร"
    Me.docNumb.Name = "docNumb"
    Me.docNumb.ReadOnly = True
    Me.docNumb.Width = 150
    '
    'emplName
    '
    Me.emplName.HeaderText = "พนักงาน"
    Me.emplName.Name = "emplName"
    Me.emplName.ReadOnly = True
    Me.emplName.Width = 150
    '
    'workDesc
    '
    Me.workDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.workDesc.HeaderText = "ทำรายการ"
    Me.workDesc.Name = "workDesc"
    Me.workDesc.ReadOnly = True
    '
    'inStock
    '
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle3.Format = "N0"
    Me.inStock.DefaultCellStyle = DataGridViewCellStyle3
    Me.inStock.HeaderText = "เข้า"
    Me.inStock.Name = "inStock"
    Me.inStock.ReadOnly = True
    Me.inStock.Width = 50
    '
    'outStock
    '
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle4.Format = "N0"
    Me.outStock.DefaultCellStyle = DataGridViewCellStyle4
    Me.outStock.HeaderText = "ออก"
    Me.outStock.Name = "outStock"
    Me.outStock.ReadOnly = True
    Me.outStock.Width = 50
    '
    'stockOnhand
    '
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle5.Format = "n0"
    Me.stockOnhand.DefaultCellStyle = DataGridViewCellStyle5
    Me.stockOnhand.HeaderText = "คงเหลือ"
    Me.stockOnhand.Name = "stockOnhand"
    Me.stockOnhand.ReadOnly = True
    Me.stockOnhand.Width = 80
    '
    'workType
    '
    Me.workType.HeaderText = "workType"
    Me.workType.Name = "workType"
    Me.workType.ReadOnly = True
    Me.workType.Visible = False
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbnClear, Me.tbnGoodSearch})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.ShowItemToolTips = False
    Me.ToolStrip1.Size = New System.Drawing.Size(949, 31)
    Me.ToolStrip1.TabIndex = 2
    Me.ToolStrip1.Text = "ToolStrip1"
    '
    'tbnClear
    '
    Me.tbnClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
    Me.tbnClear.Image = Global.DrugFront.My.Resources.Resources.clear24
    Me.tbnClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
    Me.tbnClear.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnClear.Name = "tbnClear"
    Me.tbnClear.Size = New System.Drawing.Size(66, 28)
    Me.tbnClear.Text = "Clear"
    '
    'tbnGoodSearch
    '
    Me.tbnGoodSearch.Image = Global.DrugFront.My.Resources.Resources.search24
    Me.tbnGoodSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
    Me.tbnGoodSearch.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnGoodSearch.Name = "tbnGoodSearch"
    Me.tbnGoodSearch.Size = New System.Drawing.Size(96, 28)
    Me.tbnGoodSearch.Text = "ค้นหาสินค้า"
    '
    'frmRpStockCard
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(949, 561)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmRpStockCard"
    Me.Text = "รายงานสต๊อคการ์ด"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    CType(Me.dtgList2, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dtgCard, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents dtgCard As System.Windows.Forms.DataGridView
  Friend WithEvents txtBarCode As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtUnitDesc As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents txtGoodName As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents dtgList2 As System.Windows.Forms.DataGridView
  Friend WithEvents branchCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents invoNumb As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents sendAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents receAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents stockDate As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents stockTime As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents docNumb As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents emplName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents workDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents inStock As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents outStock As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents stockOnhand As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents workType As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents tbnClear As System.Windows.Forms.ToolStripButton
  Friend WithEvents tbnGoodSearch As System.Windows.Forms.ToolStripButton
End Class
