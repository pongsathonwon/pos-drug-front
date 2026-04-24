<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGoodRece
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
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
    Me.tbnSave = New System.Windows.Forms.ToolStripButton
    Me.tbnClear = New System.Windows.Forms.ToolStripButton
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.txtInvoNumb = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
    Me.dtgList = New System.Windows.Forms.DataGridView
    Me.Label5 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.txtRemark = New System.Windows.Forms.TextBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.orderAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.ReceAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.overAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.receStat = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.StockOnhand = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.StockUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.NoBranchStock = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.preReceAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.ToolStrip1.SuspendLayout()
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SplitContainer2.Panel1.SuspendLayout()
    Me.SplitContainer2.Panel2.SuspendLayout()
    Me.SplitContainer2.SuspendLayout()
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbnSave, Me.tbnClear})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.ShowItemToolTips = False
    Me.ToolStrip1.Size = New System.Drawing.Size(799, 25)
    Me.ToolStrip1.TabIndex = 0
    Me.ToolStrip1.Text = "ToolStrip1"
    '
    'tbnSave
    '
    Me.tbnSave.Image = Global.DrugFront.My.Resources.Resources.filesave
    Me.tbnSave.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnSave.Name = "tbnSave"
    Me.tbnSave.Size = New System.Drawing.Size(105, 22)
    Me.tbnSave.Text = "บันทึกรับสินค้า"
    '
    'tbnClear
    '
    Me.tbnClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
    Me.tbnClear.Image = Global.DrugFront.My.Resources.Resources.filenew
    Me.tbnClear.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnClear.Name = "tbnClear"
    Me.tbnClear.Size = New System.Drawing.Size(58, 22)
    Me.tbnClear.Text = "Clear"
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
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.CornflowerBlue
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtInvoNumb)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
    Me.SplitContainer1.Size = New System.Drawing.Size(799, 571)
    Me.SplitContainer1.SplitterDistance = 41
    Me.SplitContainer1.TabIndex = 1
    Me.SplitContainer1.TabStop = False
    '
    'txtInvoNumb
    '
    Me.txtInvoNumb.Location = New System.Drawing.Point(113, 9)
    Me.txtInvoNumb.Name = "txtInvoNumb"
    Me.txtInvoNumb.Size = New System.Drawing.Size(99, 23)
    Me.txtInvoNumb.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(95, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "เลขที่ใบส่งสินค้า"
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
    Me.SplitContainer2.Panel1.Controls.Add(Me.dtgList)
    '
    'SplitContainer2.Panel2
    '
    Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.CornflowerBlue
    Me.SplitContainer2.Panel2.Controls.Add(Me.Label5)
    Me.SplitContainer2.Panel2.Controls.Add(Me.Label4)
    Me.SplitContainer2.Panel2.Controls.Add(Me.Label3)
    Me.SplitContainer2.Panel2.Controls.Add(Me.txtRemark)
    Me.SplitContainer2.Panel2.Controls.Add(Me.Label2)
    Me.SplitContainer2.Size = New System.Drawing.Size(799, 526)
    Me.SplitContainer2.SplitterDistance = 480
    Me.SplitContainer2.TabIndex = 2
    Me.SplitContainer2.TabStop = False
    '
    'dtgList
    '
    Me.dtgList.AllowUserToAddRows = False
    Me.dtgList.AllowUserToDeleteRows = False
    Me.dtgList.AllowUserToResizeColumns = False
    Me.dtgList.AllowUserToResizeRows = False
    Me.dtgList.BackgroundColor = System.Drawing.Color.AliceBlue
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.GoodName, Me.GoodCode, Me.UnitDesc, Me.orderAmou, Me.GoodAmou, Me.ReceAmou, Me.overAmou, Me.receStat, Me.UnitCode, Me.UnitCost, Me.StockOnhand, Me.StockUnitCost, Me.NoBranchStock, Me.preReceAmou})
    Me.dtgList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgList.Location = New System.Drawing.Point(0, 0)
    Me.dtgList.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dtgList.Name = "dtgList"
    Me.dtgList.RowHeadersVisible = False
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightSteelBlue
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
    Me.dtgList.ShowCellToolTips = False
    Me.dtgList.Size = New System.Drawing.Size(799, 480)
    Me.dtgList.StandardTab = True
    Me.dtgList.TabIndex = 0
    Me.dtgList.TabStop = False
    '
    'Label5
    '
    Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label5.BackColor = System.Drawing.Color.White
    Me.Label5.ForeColor = System.Drawing.Color.Blue
    Me.Label5.Location = New System.Drawing.Point(729, 9)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(56, 25)
    Me.Label5.TabIndex = 4
    Me.Label5.Text = "=รับเกิน"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label4
    '
    Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label4.BackColor = System.Drawing.Color.White
    Me.Label4.ForeColor = System.Drawing.Color.Red
    Me.Label4.Location = New System.Drawing.Point(667, 9)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(56, 25)
    Me.Label4.TabIndex = 3
    Me.Label4.Text = "=รับขาด"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label3
    '
    Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(249, Byte), Integer))
    Me.Label3.Location = New System.Drawing.Point(605, 9)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(56, 25)
    Me.Label3.TabIndex = 2
    Me.Label3.Text = "=รับด่วน"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'txtRemark
    '
    Me.txtRemark.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtRemark.Location = New System.Drawing.Point(76, 9)
    Me.txtRemark.MaxLength = 100
    Me.txtRemark.Name = "txtRemark"
    Me.txtRemark.Size = New System.Drawing.Size(523, 23)
    Me.txtRemark.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 12)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(58, 16)
    Me.Label2.TabIndex = 1
    Me.Label2.Text = "หมายเหตุ"
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
    '
    'orderAmou
    '
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle3.Format = "N0"
    Me.orderAmou.DefaultCellStyle = DataGridViewCellStyle3
    Me.orderAmou.HeaderText = "จำนวนสั่ง"
    Me.orderAmou.Name = "orderAmou"
    Me.orderAmou.ReadOnly = True
    Me.orderAmou.Width = 80
    '
    'GoodAmou
    '
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle4.Format = "N0"
    Me.GoodAmou.DefaultCellStyle = DataGridViewCellStyle4
    Me.GoodAmou.HeaderText = "จำนวนส่ง"
    Me.GoodAmou.Name = "GoodAmou"
    Me.GoodAmou.ReadOnly = True
    Me.GoodAmou.Width = 80
    '
    'ReceAmou
    '
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle5.Format = "N0"
    Me.ReceAmou.DefaultCellStyle = DataGridViewCellStyle5
    Me.ReceAmou.HeaderText = "จำนวนรับ"
    Me.ReceAmou.Name = "ReceAmou"
    Me.ReceAmou.Width = 80
    '
    'overAmou
    '
    DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle6.Format = "N0"
    Me.overAmou.DefaultCellStyle = DataGridViewCellStyle6
    Me.overAmou.HeaderText = "ขาด-เกิน"
    Me.overAmou.Name = "overAmou"
    Me.overAmou.ReadOnly = True
    Me.overAmou.Width = 80
    '
    'receStat
    '
    Me.receStat.HeaderText = "สถานะ"
    Me.receStat.Name = "receStat"
    Me.receStat.Visible = False
    '
    'UnitCode
    '
    Me.UnitCode.HeaderText = "unitCode"
    Me.UnitCode.Name = "UnitCode"
    Me.UnitCode.Visible = False
    '
    'UnitCost
    '
    Me.UnitCost.HeaderText = "unitCost"
    Me.UnitCost.Name = "UnitCost"
    Me.UnitCost.Visible = False
    '
    'StockOnhand
    '
    Me.StockOnhand.HeaderText = "stockOnhand"
    Me.StockOnhand.Name = "StockOnhand"
    Me.StockOnhand.Visible = False
    '
    'StockUnitCost
    '
    Me.StockUnitCost.HeaderText = "stockUnitCost"
    Me.StockUnitCost.Name = "StockUnitCost"
    Me.StockUnitCost.Visible = False
    '
    'NoBranchStock
    '
    Me.NoBranchStock.HeaderText = "noBranchStock"
    Me.NoBranchStock.Name = "NoBranchStock"
    Me.NoBranchStock.Visible = False
    '
    'preReceAmou
    '
    Me.preReceAmou.HeaderText = "preReceAmou"
    Me.preReceAmou.Name = "preReceAmou"
    Me.preReceAmou.Visible = False
    '
    'frmGoodRece
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(799, 596)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmGoodRece"
    Me.Tag = "f2b"
    Me.Text = "รับเข้าสินค้าจากสต๊อคกลาง"
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
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents tbnSave As System.Windows.Forms.ToolStripButton
  Friend WithEvents txtInvoNumb As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents dtgList As System.Windows.Forms.DataGridView
  Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
  Friend WithEvents txtRemark As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents tbnClear As System.Windows.Forms.ToolStripButton
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents orderAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ReceAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents overAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents receStat As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents StockOnhand As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents StockUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents NoBranchStock As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents preReceAmou As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
