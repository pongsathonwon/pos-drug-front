<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaleReturnTest
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
    Me.lblCashName = New System.Windows.Forms.Label
    Me.lblEmplName = New System.Windows.Forms.Label
    Me.Label14 = New System.Windows.Forms.Label
    Me.Label12 = New System.Windows.Forms.Label
    Me.lblCustName = New System.Windows.Forms.Label
    Me.Label5 = New System.Windows.Forms.Label
    Me.lblSaleDate = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.txtSaleNumb = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
    Me.dtgSaleList = New System.Windows.Forms.DataGridView
    Me.GoodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Returned = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.ReturnAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitCost = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.stockOnhand = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitFactor = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Label2 = New System.Windows.Forms.Label
    Me.lblCardName = New System.Windows.Forms.Label
    Me.lblTotal = New System.Windows.Forms.Label
    Me.Label10 = New System.Windows.Forms.Label
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
    Me.tbnSave = New System.Windows.Forms.ToolStripButton
    Me.tbnClear = New System.Windows.Forms.ToolStripButton
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SplitContainer2.Panel1.SuspendLayout()
    Me.SplitContainer2.Panel2.SuspendLayout()
    Me.SplitContainer2.SuspendLayout()
    CType(Me.dtgSaleList, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(243, Byte), Integer))
    Me.SplitContainer1.Panel1.Controls.Add(Me.lblCashName)
    Me.SplitContainer1.Panel1.Controls.Add(Me.lblEmplName)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label14)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label12)
    Me.SplitContainer1.Panel1.Controls.Add(Me.lblCustName)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
    Me.SplitContainer1.Panel1.Controls.Add(Me.lblSaleDate)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtSaleNumb)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
    Me.SplitContainer1.Size = New System.Drawing.Size(820, 394)
    Me.SplitContainer1.SplitterDistance = 75
    Me.SplitContainer1.TabIndex = 0
    Me.SplitContainer1.TabStop = False
    '
    'lblCashName
    '
    Me.lblCashName.BackColor = System.Drawing.Color.WhiteSmoke
    Me.lblCashName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblCashName.Location = New System.Drawing.Point(316, 40)
    Me.lblCashName.Name = "lblCashName"
    Me.lblCashName.Size = New System.Drawing.Size(133, 23)
    Me.lblCashName.TabIndex = 19
    Me.lblCashName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lblEmplName
    '
    Me.lblEmplName.BackColor = System.Drawing.Color.WhiteSmoke
    Me.lblEmplName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblEmplName.Location = New System.Drawing.Point(91, 40)
    Me.lblEmplName.Name = "lblEmplName"
    Me.lblEmplName.Size = New System.Drawing.Size(133, 23)
    Me.lblEmplName.TabIndex = 18
    Me.lblEmplName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.Location = New System.Drawing.Point(12, 41)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(75, 16)
    Me.Label14.TabIndex = 16
    Me.Label14.Text = "พนักงานขาย"
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(252, 41)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(58, 16)
    Me.Label12.TabIndex = 14
    Me.Label12.Text = "แคชเชียร์"
    '
    'lblCustName
    '
    Me.lblCustName.BackColor = System.Drawing.Color.WhiteSmoke
    Me.lblCustName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblCustName.Location = New System.Drawing.Point(499, 11)
    Me.lblCustName.Name = "lblCustName"
    Me.lblCustName.Size = New System.Drawing.Size(214, 23)
    Me.lblCustName.TabIndex = 9
    Me.lblCustName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(455, 14)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(38, 16)
    Me.Label5.TabIndex = 8
    Me.Label5.Text = "ลูกค้า"
    '
    'lblSaleDate
    '
    Me.lblSaleDate.BackColor = System.Drawing.Color.WhiteSmoke
    Me.lblSaleDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblSaleDate.Location = New System.Drawing.Point(316, 11)
    Me.lblSaleDate.Name = "lblSaleDate"
    Me.lblSaleDate.Size = New System.Drawing.Size(133, 23)
    Me.lblSaleDate.TabIndex = 7
    Me.lblSaleDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(252, 14)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(31, 16)
    Me.Label4.TabIndex = 6
    Me.Label4.Text = "วันที่"
    '
    'txtSaleNumb
    '
    Me.txtSaleNumb.Location = New System.Drawing.Point(91, 9)
    Me.txtSaleNumb.Name = "txtSaleNumb"
    Me.txtSaleNumb.Size = New System.Drawing.Size(133, 23)
    Me.txtSaleNumb.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(73, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "เลขที่ใบขาย"
    '
    'SplitContainer2
    '
    Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer2.IsSplitterFixed = True
    Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer2.Name = "SplitContainer2"
    Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer2.Panel1
    '
    Me.SplitContainer2.Panel1.Controls.Add(Me.dtgSaleList)
    '
    'SplitContainer2.Panel2
    '
    Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(243, Byte), Integer))
    Me.SplitContainer2.Panel2.Controls.Add(Me.Label2)
    Me.SplitContainer2.Panel2.Controls.Add(Me.lblCardName)
    Me.SplitContainer2.Panel2.Controls.Add(Me.lblTotal)
    Me.SplitContainer2.Panel2.Controls.Add(Me.Label10)
    Me.SplitContainer2.Size = New System.Drawing.Size(820, 315)
    Me.SplitContainer2.SplitterDistance = 265
    Me.SplitContainer2.TabIndex = 0
    Me.SplitContainer2.TabStop = False
    '
    'dtgSaleList
    '
    Me.dtgSaleList.AllowUserToAddRows = False
    Me.dtgSaleList.AllowUserToDeleteRows = False
    Me.dtgSaleList.AllowUserToResizeColumns = False
    Me.dtgSaleList.AllowUserToResizeRows = False
    Me.dtgSaleList.BackgroundColor = System.Drawing.Color.AliceBlue
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgSaleList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgSaleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    Me.dtgSaleList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GoodName, Me.GoodAmou, Me.UnitDesc, Me.UnitPrice, Me.Returned, Me.ReturnAmou, Me.SubTotal, Me.goodCode, Me.unitCode, Me.unitCost, Me.stockOnhand, Me.unitFactor})
    Me.dtgSaleList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgSaleList.Location = New System.Drawing.Point(0, 0)
    Me.dtgSaleList.MultiSelect = False
    Me.dtgSaleList.Name = "dtgSaleList"
    Me.dtgSaleList.RowHeadersVisible = False
    Me.dtgSaleList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
    Me.dtgSaleList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Lavender
    Me.dtgSaleList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgSaleList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.dtgSaleList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
    Me.dtgSaleList.Size = New System.Drawing.Size(820, 265)
    Me.dtgSaleList.TabIndex = 0
    '
    'GoodName
    '
    Me.GoodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.GoodName.HeaderText = "รายการ"
    Me.GoodName.Name = "GoodName"
    Me.GoodName.ReadOnly = True
    '
    'GoodAmou
    '
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    Me.GoodAmou.DefaultCellStyle = DataGridViewCellStyle2
    Me.GoodAmou.HeaderText = "จำนวน"
    Me.GoodAmou.Name = "GoodAmou"
    Me.GoodAmou.ReadOnly = True
    Me.GoodAmou.Width = 50
    '
    'UnitDesc
    '
    Me.UnitDesc.HeaderText = "หน่วย"
    Me.UnitDesc.Name = "UnitDesc"
    Me.UnitDesc.ReadOnly = True
    Me.UnitDesc.Width = 80
    '
    'UnitPrice
    '
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle3.Format = "N2"
    Me.UnitPrice.DefaultCellStyle = DataGridViewCellStyle3
    Me.UnitPrice.HeaderText = "@"
    Me.UnitPrice.Name = "UnitPrice"
    Me.UnitPrice.ReadOnly = True
    Me.UnitPrice.Width = 60
    '
    'Returned
    '
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle4.Format = "N0"
    Me.Returned.DefaultCellStyle = DataGridViewCellStyle4
    Me.Returned.HeaderText = "คืนแล้ว"
    Me.Returned.Name = "Returned"
    Me.Returned.ReadOnly = True
    Me.Returned.Width = 80
    '
    'ReturnAmou
    '
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle5.Format = "N0"
    Me.ReturnAmou.DefaultCellStyle = DataGridViewCellStyle5
    Me.ReturnAmou.HeaderText = "จำนวนคืน"
    Me.ReturnAmou.Name = "ReturnAmou"
    Me.ReturnAmou.Width = 80
    '
    'SubTotal
    '
    DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle6.Format = "N2"
    Me.SubTotal.DefaultCellStyle = DataGridViewCellStyle6
    Me.SubTotal.HeaderText = "เป็นเงิน"
    Me.SubTotal.Name = "SubTotal"
    Me.SubTotal.Width = 80
    '
    'goodCode
    '
    Me.goodCode.HeaderText = "goodCode"
    Me.goodCode.Name = "goodCode"
    Me.goodCode.Visible = False
    '
    'unitCode
    '
    Me.unitCode.HeaderText = "unitCode"
    Me.unitCode.Name = "unitCode"
    Me.unitCode.Visible = False
    '
    'unitCost
    '
    Me.unitCost.HeaderText = "unitCost"
    Me.unitCost.Name = "unitCost"
    Me.unitCost.Visible = False
    '
    'stockOnhand
    '
    Me.stockOnhand.HeaderText = "stockOnhand"
    Me.stockOnhand.Name = "stockOnhand"
    Me.stockOnhand.Visible = False
    '
    'unitFactor
    '
    Me.unitFactor.HeaderText = "unitFactor"
    Me.unitFactor.Name = "unitFactor"
    Me.unitFactor.Visible = False
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 12)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(56, 16)
    Me.Label2.TabIndex = 12
    Me.Label2.Text = "ชำระโดย"
    '
    'lblCardName
    '
    Me.lblCardName.BackColor = System.Drawing.Color.WhiteSmoke
    Me.lblCardName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblCardName.Location = New System.Drawing.Point(91, 11)
    Me.lblCardName.Name = "lblCardName"
    Me.lblCardName.Size = New System.Drawing.Size(192, 23)
    Me.lblCardName.TabIndex = 11
    Me.lblCardName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lblTotal
    '
    Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblTotal.BackColor = System.Drawing.Color.WhiteSmoke
    Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblTotal.Location = New System.Drawing.Point(720, 11)
    Me.lblTotal.Name = "lblTotal"
    Me.lblTotal.Size = New System.Drawing.Size(88, 23)
    Me.lblTotal.TabIndex = 9
    Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(652, 12)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(62, 16)
    Me.Label10.TabIndex = 8
    Me.Label10.Text = "รวมคืนเงิน"
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbnSave, Me.tbnClear})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.ShowItemToolTips = False
    Me.ToolStrip1.Size = New System.Drawing.Size(820, 25)
    Me.ToolStrip1.TabIndex = 1
    Me.ToolStrip1.Text = "ToolStrip1"
    '
    'tbnSave
    '
    Me.tbnSave.Image = Global.DrugFront.My.Resources.Resources.filesave
    Me.tbnSave.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnSave.Name = "tbnSave"
    Me.tbnSave.Size = New System.Drawing.Size(109, 22)
    Me.tbnSave.Text = "บันทึกรับคืน F8"
    '
    'tbnClear
    '
    Me.tbnClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
    Me.tbnClear.Image = Global.DrugFront.My.Resources.Resources.clear24
    Me.tbnClear.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnClear.Name = "tbnClear"
    Me.tbnClear.Size = New System.Drawing.Size(58, 22)
    Me.tbnClear.Text = "Clear"
    '
    'frmSaleReturn
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(820, 419)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmSaleReturn"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Tag = "f1b"
    Me.Text = "รับคืนสินค้า"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    Me.SplitContainer2.Panel1.ResumeLayout(False)
    Me.SplitContainer2.Panel2.ResumeLayout(False)
    Me.SplitContainer2.Panel2.PerformLayout()
    Me.SplitContainer2.ResumeLayout(False)
    CType(Me.dtgSaleList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents txtSaleNumb As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
  Friend WithEvents dtgSaleList As System.Windows.Forms.DataGridView
  Friend WithEvents lblCustName As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents lblSaleDate As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents lblTotal As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents tbnSave As System.Windows.Forms.ToolStripButton
  Friend WithEvents GoodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Returned As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ReturnAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SubTotal As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitCost As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents stockOnhand As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitFactor As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents tbnClear As System.Windows.Forms.ToolStripButton
  Friend WithEvents lblCashName As System.Windows.Forms.Label
  Friend WithEvents lblEmplName As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents lblCardName As System.Windows.Forms.Label
End Class
