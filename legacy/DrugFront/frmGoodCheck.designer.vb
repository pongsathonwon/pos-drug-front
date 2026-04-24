<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGoodCheck
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGoodCheck))
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
    Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
    Me.lblGoodName = New System.Windows.Forms.Label
    Me.txtBarCode = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.picGood = New System.Windows.Forms.PictureBox
    Me.dtgDetail = New System.Windows.Forms.DataGridView
    Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SplitContainer4 = New System.Windows.Forms.SplitContainer
    Me.txtPromotion = New System.Windows.Forms.TextBox
    Me.lblAppName = New System.Windows.Forms.Label
    Me.dtgPrice = New System.Windows.Forms.DataGridView
    Me.barCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SaleAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.membPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.membUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.genPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.genUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.wholePrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
    Me.tbnGoodSearch = New System.Windows.Forms.ToolStripButton
    Me.tbnMimbSearch = New System.Windows.Forms.ToolStripButton
    Me.ttbSearch = New System.Windows.Forms.ToolStripTextBox
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SplitContainer2.Panel1.SuspendLayout()
    Me.SplitContainer2.Panel2.SuspendLayout()
    Me.SplitContainer2.SuspendLayout()
    Me.SplitContainer3.Panel1.SuspendLayout()
    Me.SplitContainer3.Panel2.SuspendLayout()
    Me.SplitContainer3.SuspendLayout()
    CType(Me.picGood, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dtgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer4.Panel1.SuspendLayout()
    Me.SplitContainer4.Panel2.SuspendLayout()
    Me.SplitContainer4.SuspendLayout()
    CType(Me.dtgPrice, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer4)
    Me.SplitContainer1.Size = New System.Drawing.Size(808, 646)
    Me.SplitContainer1.SplitterDistance = 475
    Me.SplitContainer1.TabIndex = 0
    Me.SplitContainer1.TabStop = False
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
    Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer3)
    '
    'SplitContainer2.Panel2
    '
    Me.SplitContainer2.Panel2.Controls.Add(Me.dtgDetail)
    Me.SplitContainer2.Size = New System.Drawing.Size(808, 475)
    Me.SplitContainer2.SplitterDistance = 115
    Me.SplitContainer2.TabIndex = 2
    Me.SplitContainer2.TabStop = False
    '
    'SplitContainer3
    '
    Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
    Me.SplitContainer3.IsSplitterFixed = True
    Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer3.Name = "SplitContainer3"
    '
    'SplitContainer3.Panel1
    '
    Me.SplitContainer3.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(191, Byte), Integer))
    Me.SplitContainer3.Panel1.Controls.Add(Me.lblGoodName)
    Me.SplitContainer3.Panel1.Controls.Add(Me.txtBarCode)
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label1)
    '
    'SplitContainer3.Panel2
    '
    Me.SplitContainer3.Panel2.Controls.Add(Me.picGood)
    Me.SplitContainer3.Size = New System.Drawing.Size(808, 115)
    Me.SplitContainer3.SplitterDistance = 628
    Me.SplitContainer3.TabIndex = 2
    Me.SplitContainer3.TabStop = False
    '
    'lblGoodName
    '
    Me.lblGoodName.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblGoodName.Location = New System.Drawing.Point(23, 49)
    Me.lblGoodName.Name = "lblGoodName"
    Me.lblGoodName.Size = New System.Drawing.Size(493, 65)
    Me.lblGoodName.TabIndex = 2
    '
    'txtBarCode
    '
    Me.txtBarCode.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.txtBarCode.Location = New System.Drawing.Point(109, 12)
    Me.txtBarCode.Name = "txtBarCode"
    Me.txtBarCode.Size = New System.Drawing.Size(169, 27)
    Me.txtBarCode.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Label1.Location = New System.Drawing.Point(24, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(79, 19)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "รหัสสินค้า"
    '
    'picGood
    '
    Me.picGood.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(133, Byte), Integer))
    Me.picGood.Dock = System.Windows.Forms.DockStyle.Fill
    Me.picGood.Location = New System.Drawing.Point(0, 0)
    Me.picGood.Name = "picGood"
    Me.picGood.Size = New System.Drawing.Size(176, 115)
    Me.picGood.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
    Me.picGood.TabIndex = 107
    Me.picGood.TabStop = False
    '
    'dtgDetail
    '
    Me.dtgDetail.AllowUserToAddRows = False
    Me.dtgDetail.AllowUserToDeleteRows = False
    Me.dtgDetail.AllowUserToResizeColumns = False
    Me.dtgDetail.AllowUserToResizeRows = False
    Me.dtgDetail.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
    Me.dtgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgDetail.ColumnHeadersVisible = False
    Me.dtgDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
    Me.dtgDetail.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgDetail.Location = New System.Drawing.Point(0, 0)
    Me.dtgDetail.Name = "dtgDetail"
    Me.dtgDetail.ReadOnly = True
    Me.dtgDetail.RowHeadersVisible = False
    Me.dtgDetail.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(212, Byte), Integer))
    Me.dtgDetail.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgDetail.Size = New System.Drawing.Size(808, 356)
    Me.dtgDetail.StandardTab = True
    Me.dtgDetail.TabIndex = 0
    '
    'Column1
    '
    Me.Column1.HeaderText = "Column1"
    Me.Column1.Name = "Column1"
    Me.Column1.ReadOnly = True
    Me.Column1.Width = 150
    '
    'Column2
    '
    Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.Column2.HeaderText = "Column2"
    Me.Column2.Name = "Column2"
    Me.Column2.ReadOnly = True
    '
    'SplitContainer4
    '
    Me.SplitContainer4.BackColor = System.Drawing.SystemColors.Control
    Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer4.IsSplitterFixed = True
    Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer4.Name = "SplitContainer4"
    '
    'SplitContainer4.Panel1
    '
    Me.SplitContainer4.Panel1.Controls.Add(Me.txtPromotion)
    Me.SplitContainer4.Panel1.Controls.Add(Me.lblAppName)
    '
    'SplitContainer4.Panel2
    '
    Me.SplitContainer4.Panel2.Controls.Add(Me.dtgPrice)
    Me.SplitContainer4.Size = New System.Drawing.Size(808, 167)
    Me.SplitContainer4.SplitterDistance = 289
    Me.SplitContainer4.TabIndex = 1
    Me.SplitContainer4.TabStop = False
    '
    'txtPromotion
    '
    Me.txtPromotion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(133, Byte), Integer))
    Me.txtPromotion.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtPromotion.Dock = System.Windows.Forms.DockStyle.Fill
    Me.txtPromotion.Location = New System.Drawing.Point(0, 24)
    Me.txtPromotion.Multiline = True
    Me.txtPromotion.Name = "txtPromotion"
    Me.txtPromotion.ReadOnly = True
    Me.txtPromotion.Size = New System.Drawing.Size(289, 143)
    Me.txtPromotion.TabIndex = 6
    '
    'lblAppName
    '
    Me.lblAppName.BackColor = System.Drawing.Color.White
    Me.lblAppName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblAppName.Dock = System.Windows.Forms.DockStyle.Top
    Me.lblAppName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblAppName.Location = New System.Drawing.Point(0, 0)
    Me.lblAppName.Name = "lblAppName"
    Me.lblAppName.Size = New System.Drawing.Size(289, 24)
    Me.lblAppName.TabIndex = 5
    Me.lblAppName.Text = "โปรโมชั่น"
    Me.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'dtgPrice
    '
    Me.dtgPrice.AllowUserToAddRows = False
    Me.dtgPrice.AllowUserToDeleteRows = False
    Me.dtgPrice.AllowUserToResizeColumns = False
    Me.dtgPrice.AllowUserToResizeRows = False
    Me.dtgPrice.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(212, Byte), Integer))
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgPrice.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgPrice.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.barCode, Me.SaleAmou, Me.UnitDesc, Me.membPrice, Me.membUnitPrice, Me.genPrice, Me.genUnitPrice, Me.wholePrice})
    Me.dtgPrice.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgPrice.Location = New System.Drawing.Point(0, 0)
    Me.dtgPrice.Name = "dtgPrice"
    Me.dtgPrice.ReadOnly = True
    Me.dtgPrice.RowHeadersVisible = False
    Me.dtgPrice.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(212, Byte), Integer))
    Me.dtgPrice.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(191, Byte), Integer))
    Me.dtgPrice.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgPrice.Size = New System.Drawing.Size(515, 167)
    Me.dtgPrice.StandardTab = True
    Me.dtgPrice.TabIndex = 0
    '
    'barCode
    '
    Me.barCode.HeaderText = "รหัสสินค้า"
    Me.barCode.Name = "barCode"
    Me.barCode.ReadOnly = True
    '
    'SaleAmou
    '
    Me.SaleAmou.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.SaleAmou.HeaderText = "จำนวน"
    Me.SaleAmou.Name = "SaleAmou"
    Me.SaleAmou.ReadOnly = True
    '
    'UnitDesc
    '
    Me.UnitDesc.HeaderText = "หน่วย"
    Me.UnitDesc.Name = "UnitDesc"
    Me.UnitDesc.ReadOnly = True
    Me.UnitDesc.Visible = False
    Me.UnitDesc.Width = 42
    '
    'membPrice
    '
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle2.Format = "N2"
    Me.membPrice.DefaultCellStyle = DataGridViewCellStyle2
    Me.membPrice.HeaderText = "สมาชิก"
    Me.membPrice.Name = "membPrice"
    Me.membPrice.ReadOnly = True
    Me.membPrice.Width = 70
    '
    'membUnitPrice
    '
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle3.Format = "N2"
    Me.membUnitPrice.DefaultCellStyle = DataGridViewCellStyle3
    Me.membUnitPrice.HeaderText = "@"
    Me.membUnitPrice.Name = "membUnitPrice"
    Me.membUnitPrice.ReadOnly = True
    Me.membUnitPrice.Width = 50
    '
    'genPrice
    '
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle4.Format = "N2"
    Me.genPrice.DefaultCellStyle = DataGridViewCellStyle4
    Me.genPrice.HeaderText = "ทั่วไป"
    Me.genPrice.Name = "genPrice"
    Me.genPrice.ReadOnly = True
    Me.genPrice.Width = 70
    '
    'genUnitPrice
    '
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle5.Format = "N2"
    Me.genUnitPrice.DefaultCellStyle = DataGridViewCellStyle5
    Me.genUnitPrice.HeaderText = "@"
    Me.genUnitPrice.Name = "genUnitPrice"
    Me.genUnitPrice.ReadOnly = True
    Me.genUnitPrice.Width = 50
    '
    'wholePrice
    '
    DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle6.Format = "N2"
    Me.wholePrice.DefaultCellStyle = DataGridViewCellStyle6
    Me.wholePrice.HeaderText = "ส่ง"
    Me.wholePrice.Name = "wholePrice"
    Me.wholePrice.ReadOnly = True
    Me.wholePrice.Width = 70
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbnGoodSearch, Me.tbnMimbSearch, Me.ttbSearch})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.ShowItemToolTips = False
    Me.ToolStrip1.Size = New System.Drawing.Size(808, 25)
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
    'tbnMimbSearch
    '
    Me.tbnMimbSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
    Me.tbnMimbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.tbnMimbSearch.Image = CType(resources.GetObject("tbnMimbSearch.Image"), System.Drawing.Image)
    Me.tbnMimbSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
    Me.tbnMimbSearch.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnMimbSearch.Name = "tbnMimbSearch"
    Me.tbnMimbSearch.Size = New System.Drawing.Size(85, 28)
    Me.tbnMimbSearch.Text = "MIMS Search"
    Me.tbnMimbSearch.Visible = False
    '
    'ttbSearch
    '
    Me.ttbSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
    Me.ttbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.ttbSearch.Name = "ttbSearch"
    Me.ttbSearch.Size = New System.Drawing.Size(150, 25)
    Me.ttbSearch.Visible = False
    '
    'frmGoodCheck
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(808, 671)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmGoodCheck"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Tag = "f1f"
    Me.Text = "ตรวจสอบสินค้า"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    Me.SplitContainer2.Panel1.ResumeLayout(False)
    Me.SplitContainer2.Panel2.ResumeLayout(False)
    Me.SplitContainer2.ResumeLayout(False)
    Me.SplitContainer3.Panel1.ResumeLayout(False)
    Me.SplitContainer3.Panel1.PerformLayout()
    Me.SplitContainer3.Panel2.ResumeLayout(False)
    Me.SplitContainer3.ResumeLayout(False)
    CType(Me.picGood, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dtgDetail, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer4.Panel1.ResumeLayout(False)
    Me.SplitContainer4.Panel1.PerformLayout()
    Me.SplitContainer4.Panel2.ResumeLayout(False)
    Me.SplitContainer4.ResumeLayout(False)
    CType(Me.dtgPrice, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents txtBarCode As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
  Friend WithEvents dtgDetail As System.Windows.Forms.DataGridView
  Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents dtgPrice As System.Windows.Forms.DataGridView
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents tbnGoodSearch As System.Windows.Forms.ToolStripButton
  Friend WithEvents tbnMimbSearch As System.Windows.Forms.ToolStripButton
  Friend WithEvents ttbSearch As System.Windows.Forms.ToolStripTextBox
  Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
  Friend WithEvents picGood As System.Windows.Forms.PictureBox
  Friend WithEvents lblGoodName As System.Windows.Forms.Label
  Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
  Friend WithEvents lblAppName As System.Windows.Forms.Label
  Friend WithEvents txtPromotion As System.Windows.Forms.TextBox
  Friend WithEvents barCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SaleAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents membPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents membUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents genPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents genUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents wholePrice As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
