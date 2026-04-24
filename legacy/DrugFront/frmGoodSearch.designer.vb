<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGoodSearch
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
    Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.txtGoodDesc = New System.Windows.Forms.TextBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.cboShelfNo = New System.Windows.Forms.ComboBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.cboTypeCode = New System.Windows.Forms.ComboBox
    Me.cboTypeDesc = New System.Windows.Forms.ComboBox
    Me.btnSearch = New System.Windows.Forms.Button
    Me.txtName = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.dtgList = New System.Windows.Forms.DataGridView
    Me.goodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.barCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.shelfNo = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.stockOnhand = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.miniStock = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodRema = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.IsSplitterFixed = True
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.SplitContainer1.Name = "SplitContainer1"
    Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.DarkSeaGreen
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtGoodDesc)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
    Me.SplitContainer1.Panel1.Controls.Add(Me.cboShelfNo)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
    Me.SplitContainer1.Panel1.Controls.Add(Me.cboTypeCode)
    Me.SplitContainer1.Panel1.Controls.Add(Me.cboTypeDesc)
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnSearch)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtName)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.dtgList)
    Me.SplitContainer1.Size = New System.Drawing.Size(1175, 453)
    Me.SplitContainer1.SplitterDistance = 80
    Me.SplitContainer1.SplitterWidth = 5
    Me.SplitContainer1.TabIndex = 0
    '
    'txtGoodDesc
    '
    Me.txtGoodDesc.Location = New System.Drawing.Point(112, 44)
    Me.txtGoodDesc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtGoodDesc.Name = "txtGoodDesc"
    Me.txtGoodDesc.Size = New System.Drawing.Size(229, 23)
    Me.txtGoodDesc.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(14, 47)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(92, 16)
    Me.Label4.TabIndex = 7
    Me.Label4.Text = "ชื่อสามัญทางยา"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(347, 16)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(79, 16)
    Me.Label3.TabIndex = 6
    Me.Label3.Text = "ประเภทสินค้า"
    '
    'cboShelfNo
    '
    Me.cboShelfNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboShelfNo.FormattingEnabled = True
    Me.cboShelfNo.Location = New System.Drawing.Point(432, 43)
    Me.cboShelfNo.Name = "cboShelfNo"
    Me.cboShelfNo.Size = New System.Drawing.Size(186, 24)
    Me.cboShelfNo.TabIndex = 4
    Me.cboShelfNo.TabStop = False
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(347, 47)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(42, 16)
    Me.Label2.TabIndex = 4
    Me.Label2.Text = "ชั้นวาง"
    '
    'cboTypeCode
    '
    Me.cboTypeCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboTypeCode.FormattingEnabled = True
    Me.cboTypeCode.Location = New System.Drawing.Point(930, 13)
    Me.cboTypeCode.Name = "cboTypeCode"
    Me.cboTypeCode.Size = New System.Drawing.Size(36, 24)
    Me.cboTypeCode.TabIndex = 3
    Me.cboTypeCode.TabStop = False
    Me.cboTypeCode.Visible = False
    '
    'cboTypeDesc
    '
    Me.cboTypeDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboTypeDesc.FormattingEnabled = True
    Me.cboTypeDesc.Location = New System.Drawing.Point(432, 14)
    Me.cboTypeDesc.Name = "cboTypeDesc"
    Me.cboTypeDesc.Size = New System.Drawing.Size(186, 24)
    Me.cboTypeDesc.TabIndex = 3
    Me.cboTypeDesc.TabStop = False
    '
    'btnSearch
    '
    Me.btnSearch.Location = New System.Drawing.Point(660, 41)
    Me.btnSearch.Name = "btnSearch"
    Me.btnSearch.Size = New System.Drawing.Size(110, 26)
    Me.btnSearch.TabIndex = 2
    Me.btnSearch.Text = "ค้นหา"
    Me.btnSearch.UseVisualStyleBackColor = True
    '
    'txtName
    '
    Me.txtName.Location = New System.Drawing.Point(112, 13)
    Me.txtName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtName.Name = "txtName"
    Me.txtName.Size = New System.Drawing.Size(229, 23)
    Me.txtName.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(14, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(58, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "ชื่อการค้า"
    '
    'dtgList
    '
    Me.dtgList.AllowUserToAddRows = False
    Me.dtgList.AllowUserToDeleteRows = False
    Me.dtgList.AllowUserToOrderColumns = True
    Me.dtgList.AllowUserToResizeColumns = False
    Me.dtgList.AllowUserToResizeRows = False
    Me.dtgList.BackgroundColor = System.Drawing.Color.Honeydew
    DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
    Me.dtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.goodName, Me.goodDesc, Me.unitDesc, Me.barCode, Me.shelfNo, Me.goodPrice, Me.stockOnhand, Me.GoodCode, Me.miniStock, Me.goodRema})
    Me.dtgList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
    Me.dtgList.Location = New System.Drawing.Point(0, 0)
    Me.dtgList.Name = "dtgList"
    Me.dtgList.ReadOnly = True
    Me.dtgList.RowHeadersVisible = False
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkSeaGreen
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.dtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgList.Size = New System.Drawing.Size(1175, 368)
    Me.dtgList.StandardTab = True
    Me.dtgList.TabIndex = 0
    '
    'goodName
    '
    Me.goodName.HeaderText = "ชื่อการค้า"
    Me.goodName.Name = "goodName"
    Me.goodName.ReadOnly = True
    Me.goodName.Width = 200
    '
    'goodDesc
    '
    Me.goodDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.goodDesc.HeaderText = "ชื่อสามัญทางยา"
    Me.goodDesc.Name = "goodDesc"
    Me.goodDesc.ReadOnly = True
    '
    'unitDesc
    '
    Me.unitDesc.HeaderText = "หน่วย"
    Me.unitDesc.Name = "unitDesc"
    Me.unitDesc.ReadOnly = True
    '
    'barCode
    '
    Me.barCode.HeaderText = "รหัสสินค้า"
    Me.barCode.Name = "barCode"
    Me.barCode.ReadOnly = True
    '
    'shelfNo
    '
    Me.shelfNo.HeaderText = "ชั้นวาง"
    Me.shelfNo.Name = "shelfNo"
    Me.shelfNo.ReadOnly = True
    '
    'goodPrice
    '
    DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle10.Format = "N2"
    Me.goodPrice.DefaultCellStyle = DataGridViewCellStyle10
    Me.goodPrice.HeaderText = "ราคาขาย"
    Me.goodPrice.Name = "goodPrice"
    Me.goodPrice.ReadOnly = True
    Me.goodPrice.Width = 80
    '
    'stockOnhand
    '
    DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle11.Format = "N0"
    Me.stockOnhand.DefaultCellStyle = DataGridViewCellStyle11
    Me.stockOnhand.HeaderText = "คงเหลือ"
    Me.stockOnhand.Name = "stockOnhand"
    Me.stockOnhand.ReadOnly = True
    Me.stockOnhand.Width = 80
    '
    'GoodCode
    '
    Me.GoodCode.HeaderText = "goodCode"
    Me.GoodCode.Name = "GoodCode"
    Me.GoodCode.ReadOnly = True
    Me.GoodCode.Visible = False
    '
    'miniStock
    '
    DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle12.Format = "N0"
    Me.miniStock.DefaultCellStyle = DataGridViewCellStyle12
    Me.miniStock.HeaderText = "จุดสั่งซื้อ"
    Me.miniStock.Name = "miniStock"
    Me.miniStock.ReadOnly = True
    Me.miniStock.Width = 80
    '
    'goodRema
    '
    Me.goodRema.HeaderText = "สถานะ"
    Me.goodRema.Name = "goodRema"
    Me.goodRema.ReadOnly = True
    Me.goodRema.Width = 120
    '
    'frmGoodSearch
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1175, 453)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmGoodSearch"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "ค้นหาสินค้า"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents txtName As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents dtgList As System.Windows.Forms.DataGridView
  Friend WithEvents btnSearch As System.Windows.Forms.Button
  Friend WithEvents cboTypeCode As System.Windows.Forms.ComboBox
  Friend WithEvents cboTypeDesc As System.Windows.Forms.ComboBox
  Friend WithEvents cboShelfNo As System.Windows.Forms.ComboBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtGoodDesc As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents goodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents barCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents shelfNo As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents stockOnhand As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents miniStock As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodRema As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
