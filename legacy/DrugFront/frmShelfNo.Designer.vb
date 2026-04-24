<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShelfNo
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
    Me.components = New System.ComponentModel.Container
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
    Me.tbnFind = New System.Windows.Forms.ToolStripButton
    Me.tbnSave = New System.Windows.Forms.ToolStripButton
    Me.tbnClear = New System.Windows.Forms.ToolStripButton
    Me.tbnShowNoShelf = New System.Windows.Forms.ToolStripButton
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtBarcode = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.txtNewShelfNo = New System.Windows.Forms.TextBox
    Me.dtgList = New System.Windows.Forms.DataGridView
    Me.itemNo = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.barCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.shelfNo = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
    Me.dtgShelf = New System.Windows.Forms.DataGridView
    Me.shelfNumb = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ToolStrip1.SuspendLayout()
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SplitContainer3.Panel1.SuspendLayout()
    Me.SplitContainer3.Panel2.SuspendLayout()
    Me.SplitContainer3.SuspendLayout()
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer2.Panel1.SuspendLayout()
    Me.SplitContainer2.Panel2.SuspendLayout()
    Me.SplitContainer2.SuspendLayout()
    CType(Me.dtgShelf, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbnFind, Me.tbnSave, Me.tbnClear, Me.tbnShowNoShelf})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.ShowItemToolTips = False
    Me.ToolStrip1.Size = New System.Drawing.Size(876, 31)
    Me.ToolStrip1.TabIndex = 0
    Me.ToolStrip1.Text = "ToolStrip1"
    '
    'tbnFind
    '
    Me.tbnFind.Image = Global.DrugFront.My.Resources.Resources.search24
    Me.tbnFind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
    Me.tbnFind.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnFind.Name = "tbnFind"
    Me.tbnFind.Size = New System.Drawing.Size(100, 28)
    Me.tbnFind.Text = " ค้นหาสินค้า"
    '
    'tbnSave
    '
    Me.tbnSave.Image = Global.DrugFront.My.Resources.Resources.save24
    Me.tbnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
    Me.tbnSave.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnSave.Name = "tbnSave"
    Me.tbnSave.Size = New System.Drawing.Size(69, 28)
    Me.tbnSave.Text = "บันทึก"
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
    Me.tbnClear.Visible = False
    '
    'tbnShowNoShelf
    '
    Me.tbnShowNoShelf.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
    Me.tbnShowNoShelf.Image = Global.DrugFront.My.Resources.Resources.news_subscribe
    Me.tbnShowNoShelf.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnShowNoShelf.Name = "tbnShowNoShelf"
    Me.tbnShowNoShelf.Size = New System.Drawing.Size(183, 28)
    Me.tbnShowNoShelf.Text = "สินค้าที่ยังไม่ได้กำหนดชั้นวาง"
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer1.IsSplitterFixed = True
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer1.Name = "SplitContainer1"
    Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer3)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.dtgList)
    Me.SplitContainer1.Size = New System.Drawing.Size(720, 555)
    Me.SplitContainer1.TabIndex = 1
    Me.SplitContainer1.TabStop = False
    '
    'SplitContainer3
    '
    Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer3.IsSplitterFixed = True
    Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer3.Name = "SplitContainer3"
    '
    'SplitContainer3.Panel1
    '
    Me.SplitContainer3.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(251, Byte), Integer))
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label2)
    Me.SplitContainer3.Panel1.Controls.Add(Me.txtBarcode)
    '
    'SplitContainer3.Panel2
    '
    Me.SplitContainer3.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(251, Byte), Integer))
    Me.SplitContainer3.Panel2.Controls.Add(Me.Label1)
    Me.SplitContainer3.Panel2.Controls.Add(Me.txtNewShelfNo)
    Me.SplitContainer3.Size = New System.Drawing.Size(720, 50)
    Me.SplitContainer3.SplitterDistance = 297
    Me.SplitContainer3.TabIndex = 7
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(25, 17)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(85, 16)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "เพิ่มสินค้า รหัส"
    '
    'txtBarcode
    '
    Me.txtBarcode.Location = New System.Drawing.Point(118, 14)
    Me.txtBarcode.Name = "txtBarcode"
    Me.txtBarcode.Size = New System.Drawing.Size(150, 23)
    Me.txtBarcode.TabIndex = 1
    Me.ToolTip1.SetToolTip(Me.txtBarcode, "ป้อนรหัสสินค้า")
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(29, 17)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(122, 16)
    Me.Label1.TabIndex = 6
    Me.Label1.Text = "กำหนดเลขชั้นวางใหม่"
    '
    'txtNewShelfNo
    '
    Me.txtNewShelfNo.Location = New System.Drawing.Point(157, 14)
    Me.txtNewShelfNo.MaxLength = 10
    Me.txtNewShelfNo.Name = "txtNewShelfNo"
    Me.txtNewShelfNo.Size = New System.Drawing.Size(93, 23)
    Me.txtNewShelfNo.TabIndex = 2
    Me.txtNewShelfNo.TabStop = False
    '
    'dtgList
    '
    Me.dtgList.AllowUserToAddRows = False
    Me.dtgList.AllowUserToResizeColumns = False
    Me.dtgList.AllowUserToResizeRows = False
    Me.dtgList.BackgroundColor = System.Drawing.Color.LightSkyBlue
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemNo, Me.barCode, Me.goodName, Me.shelfNo, Me.goodCode})
    Me.dtgList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgList.Location = New System.Drawing.Point(0, 0)
    Me.dtgList.Name = "dtgList"
    Me.dtgList.ReadOnly = True
    Me.dtgList.RowHeadersVisible = False
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(251, Byte), Integer))
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgList.RowTemplate.Height = 24
    Me.dtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgList.Size = New System.Drawing.Size(720, 501)
    Me.dtgList.TabIndex = 0
    '
    'itemNo
    '
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    Me.itemNo.DefaultCellStyle = DataGridViewCellStyle2
    Me.itemNo.HeaderText = ""
    Me.itemNo.Name = "itemNo"
    Me.itemNo.ReadOnly = True
    Me.itemNo.Width = 40
    '
    'barCode
    '
    Me.barCode.HeaderText = "รหัสสินค้า"
    Me.barCode.Name = "barCode"
    Me.barCode.ReadOnly = True
    Me.barCode.Visible = False
    '
    'goodName
    '
    Me.goodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.goodName.HeaderText = "รายการสินค้า"
    Me.goodName.Name = "goodName"
    Me.goodName.ReadOnly = True
    '
    'shelfNo
    '
    Me.shelfNo.HeaderText = "ชั้นวางปัจจุบัน"
    Me.shelfNo.Name = "shelfNo"
    Me.shelfNo.ReadOnly = True
    Me.shelfNo.Width = 110
    '
    'goodCode
    '
    Me.goodCode.HeaderText = "goodCode"
    Me.goodCode.Name = "goodCode"
    Me.goodCode.ReadOnly = True
    Me.goodCode.Visible = False
    '
    'SplitContainer2
    '
    Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer2.IsSplitterFixed = True
    Me.SplitContainer2.Location = New System.Drawing.Point(0, 31)
    Me.SplitContainer2.Name = "SplitContainer2"
    '
    'SplitContainer2.Panel1
    '
    Me.SplitContainer2.Panel1.Controls.Add(Me.dtgShelf)
    '
    'SplitContainer2.Panel2
    '
    Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
    Me.SplitContainer2.Size = New System.Drawing.Size(876, 555)
    Me.SplitContainer2.SplitterDistance = 152
    Me.SplitContainer2.TabIndex = 2
    Me.SplitContainer2.TabStop = False
    '
    'dtgShelf
    '
    Me.dtgShelf.AllowUserToAddRows = False
    Me.dtgShelf.AllowUserToDeleteRows = False
    Me.dtgShelf.AllowUserToResizeColumns = False
    Me.dtgShelf.AllowUserToResizeRows = False
    Me.dtgShelf.BackgroundColor = System.Drawing.Color.AliceBlue
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgShelf.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
    Me.dtgShelf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgShelf.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.shelfNumb})
    Me.dtgShelf.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgShelf.Location = New System.Drawing.Point(0, 0)
    Me.dtgShelf.Name = "dtgShelf"
    Me.dtgShelf.ReadOnly = True
    Me.dtgShelf.RowHeadersVisible = False
    Me.dtgShelf.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(251, Byte), Integer))
    Me.dtgShelf.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgShelf.RowTemplate.Height = 24
    Me.dtgShelf.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
    Me.dtgShelf.ShowCellToolTips = False
    Me.dtgShelf.Size = New System.Drawing.Size(152, 555)
    Me.dtgShelf.TabIndex = 3
    Me.ToolTip1.SetToolTip(Me.dtgShelf, "ดับเบิ้ลคลิ๊กเพื่อแสดงรายการ")
    '
    'shelfNumb
    '
    Me.shelfNumb.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.shelfNumb.HeaderText = "เลขชั้นวาง"
    Me.shelfNumb.Name = "shelfNumb"
    Me.shelfNumb.ReadOnly = True
    '
    'frmShelfNo
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(876, 586)
    Me.Controls.Add(Me.SplitContainer2)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmShelfNo"
    Me.ShowInTaskbar = False
    Me.Tag = "f2h"
    Me.Text = "กำหนดชั้นวางสินค้า"
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    Me.SplitContainer3.Panel1.ResumeLayout(False)
    Me.SplitContainer3.Panel1.PerformLayout()
    Me.SplitContainer3.Panel2.ResumeLayout(False)
    Me.SplitContainer3.Panel2.PerformLayout()
    Me.SplitContainer3.ResumeLayout(False)
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer2.Panel1.ResumeLayout(False)
    Me.SplitContainer2.Panel2.ResumeLayout(False)
    Me.SplitContainer2.ResumeLayout(False)
    CType(Me.dtgShelf, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents tbnSave As System.Windows.Forms.ToolStripButton
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents dtgList As System.Windows.Forms.DataGridView
  Friend WithEvents tbnFind As System.Windows.Forms.ToolStripButton
  Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
  Friend WithEvents tbnShowNoShelf As System.Windows.Forms.ToolStripButton
  Friend WithEvents txtNewShelfNo As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  Friend WithEvents tbnClear As System.Windows.Forms.ToolStripButton
  Friend WithEvents dtgShelf As System.Windows.Forms.DataGridView
  Friend WithEvents shelfNumb As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents itemNo As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents barCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents shelfNo As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
End Class
