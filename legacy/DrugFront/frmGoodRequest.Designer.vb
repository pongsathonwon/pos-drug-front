<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGoodRequest
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
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.dtgRequList = New System.Windows.Forms.DataGridView
    Me.requNumb = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.requDate = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.typeDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.genericName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.requRema = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.saleGuess = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.emplName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.requStat = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.txtGenericName = New System.Windows.Forms.TextBox
    Me.Label6 = New System.Windows.Forms.Label
    Me.cboRequRema = New System.Windows.Forms.ComboBox
    Me.cboTypeCode = New System.Windows.Forms.ComboBox
    Me.cboTypeDesc = New System.Windows.Forms.ComboBox
    Me.txtEmplName = New System.Windows.Forms.TextBox
    Me.txtSaleGuess = New System.Windows.Forms.TextBox
    Me.Label5 = New System.Windows.Forms.Label
    Me.txtGoodName = New System.Windows.Forms.TextBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
    Me.tbnDelete = New System.Windows.Forms.ToolStripButton
    Me.tbnSave = New System.Windows.Forms.ToolStripButton
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    CType(Me.dtgRequList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ToolStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
    Me.SplitContainer1.IsSplitterFixed = True
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
    Me.SplitContainer1.Name = "SplitContainer1"
    Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.Controls.Add(Me.dtgRequList)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.Snow
    Me.SplitContainer1.Panel2.Controls.Add(Me.txtGenericName)
    Me.SplitContainer1.Panel2.Controls.Add(Me.Label6)
    Me.SplitContainer1.Panel2.Controls.Add(Me.cboRequRema)
    Me.SplitContainer1.Panel2.Controls.Add(Me.cboTypeCode)
    Me.SplitContainer1.Panel2.Controls.Add(Me.cboTypeDesc)
    Me.SplitContainer1.Panel2.Controls.Add(Me.txtEmplName)
    Me.SplitContainer1.Panel2.Controls.Add(Me.txtSaleGuess)
    Me.SplitContainer1.Panel2.Controls.Add(Me.Label5)
    Me.SplitContainer1.Panel2.Controls.Add(Me.txtGoodName)
    Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
    Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
    Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
    Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
    Me.SplitContainer1.Size = New System.Drawing.Size(1211, 599)
    Me.SplitContainer1.SplitterDistance = 354
    Me.SplitContainer1.TabIndex = 1
    '
    'dtgRequList
    '
    Me.dtgRequList.AllowUserToAddRows = False
    Me.dtgRequList.AllowUserToDeleteRows = False
    Me.dtgRequList.AllowUserToResizeColumns = False
    Me.dtgRequList.AllowUserToResizeRows = False
    Me.dtgRequList.BackgroundColor = System.Drawing.Color.MistyRose
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgRequList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgRequList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgRequList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.requNumb, Me.requDate, Me.typeDesc, Me.goodName, Me.genericName, Me.requRema, Me.saleGuess, Me.emplName, Me.requStat})
    Me.dtgRequList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgRequList.Location = New System.Drawing.Point(0, 0)
    Me.dtgRequList.Name = "dtgRequList"
    Me.dtgRequList.ReadOnly = True
    Me.dtgRequList.RowHeadersWidth = 25
    Me.dtgRequList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.MistyRose
    Me.dtgRequList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgRequList.Size = New System.Drawing.Size(1211, 354)
    Me.dtgRequList.TabIndex = 0
    Me.dtgRequList.TabStop = False
    '
    'requNumb
    '
    Me.requNumb.HeaderText = "requNumb"
    Me.requNumb.Name = "requNumb"
    Me.requNumb.ReadOnly = True
    Me.requNumb.Visible = False
    '
    'requDate
    '
    DataGridViewCellStyle2.Format = "d"
    DataGridViewCellStyle2.NullValue = Nothing
    Me.requDate.DefaultCellStyle = DataGridViewCellStyle2
    Me.requDate.HeaderText = "วันที่"
    Me.requDate.Name = "requDate"
    Me.requDate.ReadOnly = True
    Me.requDate.Width = 80
    '
    'typeDesc
    '
    Me.typeDesc.HeaderText = "ประเภทสินค้า"
    Me.typeDesc.Name = "typeDesc"
    Me.typeDesc.ReadOnly = True
    Me.typeDesc.Width = 140
    '
    'goodName
    '
    Me.goodName.HeaderText = "ชื่อการค้า"
    Me.goodName.Name = "goodName"
    Me.goodName.ReadOnly = True
    Me.goodName.Width = 180
    '
    'genericName
    '
    Me.genericName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.genericName.HeaderText = "ชื่อสามัญ"
    Me.genericName.Name = "genericName"
    Me.genericName.ReadOnly = True
    '
    'requRema
    '
    Me.requRema.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.requRema.HeaderText = "สาเหตุที่ต้องการ"
    Me.requRema.Name = "requRema"
    Me.requRema.ReadOnly = True
    '
    'saleGuess
    '
    Me.saleGuess.HeaderText = "คาดการณ์ยอดขาย"
    Me.saleGuess.Name = "saleGuess"
    Me.saleGuess.ReadOnly = True
    Me.saleGuess.Width = 160
    '
    'emplName
    '
    Me.emplName.HeaderText = "ผู้บันทึก"
    Me.emplName.Name = "emplName"
    Me.emplName.ReadOnly = True
    '
    'requStat
    '
    Me.requStat.HeaderText = "สถานะ"
    Me.requStat.Name = "requStat"
    Me.requStat.ReadOnly = True
    Me.requStat.Width = 150
    '
    'txtGenericName
    '
    Me.txtGenericName.Location = New System.Drawing.Point(155, 77)
    Me.txtGenericName.MaxLength = 100
    Me.txtGenericName.Multiline = True
    Me.txtGenericName.Name = "txtGenericName"
    Me.txtGenericName.Size = New System.Drawing.Size(367, 50)
    Me.txtGenericName.TabIndex = 2
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(39, 80)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(57, 16)
    Me.Label6.TabIndex = 9
    Me.Label6.Text = "ชื่อสามัญ"
    '
    'cboRequRema
    '
    Me.cboRequRema.FormattingEnabled = True
    Me.cboRequRema.Items.AddRange(New Object() {"ลูกค้าเรียกหาบ่อย", "คู่แข่งมีขาย", "สินค้ากำลังดัง", "มีกลุ่มลูกค้าเป้าหมาย", "ต้องการไว้บริการลูกค้า", "อื่นๆ โปรดระบุ"})
    Me.cboRequRema.Location = New System.Drawing.Point(155, 133)
    Me.cboRequRema.Name = "cboRequRema"
    Me.cboRequRema.Size = New System.Drawing.Size(367, 24)
    Me.cboRequRema.TabIndex = 3
    '
    'cboTypeCode
    '
    Me.cboTypeCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboTypeCode.FormattingEnabled = True
    Me.cboTypeCode.Location = New System.Drawing.Point(528, 18)
    Me.cboTypeCode.Name = "cboTypeCode"
    Me.cboTypeCode.Size = New System.Drawing.Size(21, 24)
    Me.cboTypeCode.TabIndex = 7
    Me.cboTypeCode.Visible = False
    '
    'cboTypeDesc
    '
    Me.cboTypeDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboTypeDesc.FormattingEnabled = True
    Me.cboTypeDesc.Location = New System.Drawing.Point(155, 18)
    Me.cboTypeDesc.Name = "cboTypeDesc"
    Me.cboTypeDesc.Size = New System.Drawing.Size(367, 24)
    Me.cboTypeDesc.TabIndex = 0
    '
    'txtEmplName
    '
    Me.txtEmplName.Location = New System.Drawing.Point(155, 192)
    Me.txtEmplName.MaxLength = 100
    Me.txtEmplName.Name = "txtEmplName"
    Me.txtEmplName.Size = New System.Drawing.Size(367, 23)
    Me.txtEmplName.TabIndex = 5
    '
    'txtSaleGuess
    '
    Me.txtSaleGuess.Location = New System.Drawing.Point(155, 163)
    Me.txtSaleGuess.MaxLength = 100
    Me.txtSaleGuess.Name = "txtSaleGuess"
    Me.txtSaleGuess.Size = New System.Drawing.Size(367, 23)
    Me.txtSaleGuess.TabIndex = 4
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(39, 195)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(44, 16)
    Me.Label5.TabIndex = 0
    Me.Label5.Text = "ผู้เสนอ"
    '
    'txtGoodName
    '
    Me.txtGoodName.Location = New System.Drawing.Point(155, 48)
    Me.txtGoodName.MaxLength = 50
    Me.txtGoodName.Name = "txtGoodName"
    Me.txtGoodName.Size = New System.Drawing.Size(367, 23)
    Me.txtGoodName.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(39, 166)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(107, 16)
    Me.Label4.TabIndex = 0
    Me.Label4.Text = "คาดการณ์ยอดขาย"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(39, 136)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(93, 16)
    Me.Label3.TabIndex = 0
    Me.Label3.Text = "สาเหตุที่ต้องการ"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(39, 51)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(58, 16)
    Me.Label2.TabIndex = 0
    Me.Label2.Text = "ชื่อการค้า"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(39, 21)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(79, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "ประเภทสินค้า"
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbnDelete, Me.tbnSave})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.ShowItemToolTips = False
    Me.ToolStrip1.Size = New System.Drawing.Size(1211, 25)
    Me.ToolStrip1.TabIndex = 2
    Me.ToolStrip1.Text = "ToolStrip1"
    '
    'tbnDelete
    '
    Me.tbnDelete.Image = Global.DrugFront.My.Resources.Resources.DeleteData
    Me.tbnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnDelete.Name = "tbnDelete"
    Me.tbnDelete.Size = New System.Drawing.Size(84, 22)
    Me.tbnDelete.Text = "ลบรายการ"
    '
    'tbnSave
    '
    Me.tbnSave.Image = Global.DrugFront.My.Resources.Resources.filesave
    Me.tbnSave.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnSave.Name = "tbnSave"
    Me.tbnSave.Size = New System.Drawing.Size(61, 22)
    Me.tbnSave.Text = "บันทึก"
    '
    'frmGoodRequest
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1211, 624)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmGoodRequest"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Tag = "f1k"
    Me.Text = "บันทึกความต้องการสินค้า"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.Panel2.PerformLayout()
    Me.SplitContainer1.ResumeLayout(False)
    CType(Me.dtgRequList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents dtgRequList As System.Windows.Forms.DataGridView
  Friend WithEvents txtGoodName As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents cboTypeCode As System.Windows.Forms.ComboBox
  Friend WithEvents cboTypeDesc As System.Windows.Forms.ComboBox
  Friend WithEvents txtSaleGuess As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtEmplName As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents tbnDelete As System.Windows.Forms.ToolStripButton
  Friend WithEvents tbnSave As System.Windows.Forms.ToolStripButton
  Friend WithEvents cboRequRema As System.Windows.Forms.ComboBox
  Friend WithEvents txtGenericName As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents requNumb As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents requDate As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents typeDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents genericName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents requRema As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents saleGuess As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents emplName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents requStat As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
