<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRequTran
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
    Me.txtToBranchName = New System.Windows.Forms.TextBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.Button1 = New System.Windows.Forms.Button
    Me.txtEmplName = New System.Windows.Forms.TextBox
    Me.txtEmplCode = New System.Windows.Forms.TextBox
    Me.Label5 = New System.Windows.Forms.Label
    Me.txtFromBranchName = New System.Windows.Forms.TextBox
    Me.txtBranchCode = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
    Me.btnGoodSearch = New System.Windows.Forms.Button
    Me.btnAdd = New System.Windows.Forms.Button
    Me.lblUnitDesc = New System.Windows.Forms.Label
    Me.txtGoodAmou = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.txtGoodName = New System.Windows.Forms.TextBox
    Me.txtBarcode = New System.Windows.Forms.TextBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.dtgList = New System.Windows.Forms.DataGridView
    Me.barCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitCost = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
    Me.tbnSave = New System.Windows.Forms.ToolStripButton
    Me.pdc1 = New System.Drawing.Printing.PrintDocument
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SplitContainer2.Panel1.SuspendLayout()
    Me.SplitContainer2.Panel2.SuspendLayout()
    Me.SplitContainer2.SuspendLayout()
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
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(133, Byte), Integer))
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtToBranchName)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtEmplName)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtEmplCode)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtFromBranchName)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtBranchCode)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
    Me.SplitContainer1.Size = New System.Drawing.Size(661, 438)
    Me.SplitContainer1.SplitterDistance = 118
    Me.SplitContainer1.TabIndex = 0
    Me.SplitContainer1.TabStop = False
    '
    'txtToBranchName
    '
    Me.txtToBranchName.Location = New System.Drawing.Point(246, 46)
    Me.txtToBranchName.Name = "txtToBranchName"
    Me.txtToBranchName.ReadOnly = True
    Me.txtToBranchName.Size = New System.Drawing.Size(302, 23)
    Me.txtToBranchName.TabIndex = 8
    Me.txtToBranchName.TabStop = False
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(12, 49)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(51, 16)
    Me.Label4.TabIndex = 7
    Me.Label4.Text = "ไปสาขา"
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(569, 42)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(80, 30)
    Me.Button1.TabIndex = 6
    Me.Button1.Text = "Button1"
    Me.Button1.UseVisualStyleBackColor = True
    Me.Button1.Visible = False
    '
    'txtEmplName
    '
    Me.txtEmplName.Location = New System.Drawing.Point(246, 77)
    Me.txtEmplName.Name = "txtEmplName"
    Me.txtEmplName.ReadOnly = True
    Me.txtEmplName.Size = New System.Drawing.Size(302, 23)
    Me.txtEmplName.TabIndex = 5
    Me.txtEmplName.TabStop = False
    '
    'txtEmplCode
    '
    Me.txtEmplCode.Location = New System.Drawing.Point(157, 77)
    Me.txtEmplCode.Name = "txtEmplCode"
    Me.txtEmplCode.Size = New System.Drawing.Size(83, 23)
    Me.txtEmplCode.TabIndex = 1
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(12, 80)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(108, 16)
    Me.Label5.TabIndex = 3
    Me.Label5.Text = "ผู้ขอโอน(รหัสขาย)"
    '
    'txtFromBranchName
    '
    Me.txtFromBranchName.Location = New System.Drawing.Point(246, 17)
    Me.txtFromBranchName.Name = "txtFromBranchName"
    Me.txtFromBranchName.ReadOnly = True
    Me.txtFromBranchName.Size = New System.Drawing.Size(302, 23)
    Me.txtFromBranchName.TabIndex = 2
    Me.txtFromBranchName.TabStop = False
    '
    'txtBranchCode
    '
    Me.txtBranchCode.Location = New System.Drawing.Point(157, 17)
    Me.txtBranchCode.Name = "txtBranchCode"
    Me.txtBranchCode.Size = New System.Drawing.Size(83, 23)
    Me.txtBranchCode.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 20)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(117, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "จากสาขา(รหัสสาขา)"
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
    Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(173, Byte), Integer))
    Me.SplitContainer2.Panel1.Controls.Add(Me.btnGoodSearch)
    Me.SplitContainer2.Panel1.Controls.Add(Me.btnAdd)
    Me.SplitContainer2.Panel1.Controls.Add(Me.lblUnitDesc)
    Me.SplitContainer2.Panel1.Controls.Add(Me.txtGoodAmou)
    Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
    Me.SplitContainer2.Panel1.Controls.Add(Me.txtGoodName)
    Me.SplitContainer2.Panel1.Controls.Add(Me.txtBarcode)
    Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
    '
    'SplitContainer2.Panel2
    '
    Me.SplitContainer2.Panel2.Controls.Add(Me.dtgList)
    Me.SplitContainer2.Size = New System.Drawing.Size(661, 316)
    Me.SplitContainer2.SplitterDistance = 95
    Me.SplitContainer2.TabIndex = 0
    Me.SplitContainer2.TabStop = False
    '
    'btnGoodSearch
    '
    Me.btnGoodSearch.Image = Global.DrugFront.My.Resources.Resources.search
    Me.btnGoodSearch.Location = New System.Drawing.Point(521, 20)
    Me.btnGoodSearch.Name = "btnGoodSearch"
    Me.btnGoodSearch.Size = New System.Drawing.Size(23, 23)
    Me.btnGoodSearch.TabIndex = 7
    Me.btnGoodSearch.UseVisualStyleBackColor = True
    '
    'btnAdd
    '
    Me.btnAdd.Location = New System.Drawing.Point(359, 52)
    Me.btnAdd.Name = "btnAdd"
    Me.btnAdd.Size = New System.Drawing.Size(110, 25)
    Me.btnAdd.TabIndex = 2
    Me.btnAdd.Text = "เพิ่มรายการ"
    Me.btnAdd.UseVisualStyleBackColor = True
    '
    'lblUnitDesc
    '
    Me.lblUnitDesc.AutoSize = True
    Me.lblUnitDesc.Location = New System.Drawing.Point(210, 52)
    Me.lblUnitDesc.Name = "lblUnitDesc"
    Me.lblUnitDesc.Size = New System.Drawing.Size(38, 16)
    Me.lblUnitDesc.TabIndex = 6
    Me.lblUnitDesc.Text = "หน่วย"
    '
    'txtGoodAmou
    '
    Me.txtGoodAmou.Location = New System.Drawing.Point(78, 49)
    Me.txtGoodAmou.Name = "txtGoodAmou"
    Me.txtGoodAmou.Size = New System.Drawing.Size(126, 23)
    Me.txtGoodAmou.TabIndex = 1
    Me.txtGoodAmou.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 52)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(43, 16)
    Me.Label3.TabIndex = 3
    Me.Label3.Text = "จำนวน"
    '
    'txtGoodName
    '
    Me.txtGoodName.Location = New System.Drawing.Point(213, 20)
    Me.txtGoodName.Name = "txtGoodName"
    Me.txtGoodName.ReadOnly = True
    Me.txtGoodName.Size = New System.Drawing.Size(302, 23)
    Me.txtGoodName.TabIndex = 5
    Me.txtGoodName.TabStop = False
    '
    'txtBarcode
    '
    Me.txtBarcode.Location = New System.Drawing.Point(78, 20)
    Me.txtBarcode.Name = "txtBarcode"
    Me.txtBarcode.Size = New System.Drawing.Size(127, 23)
    Me.txtBarcode.TabIndex = 0
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 23)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(60, 16)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "รหัสสินค้า"
    '
    'dtgList
    '
    Me.dtgList.AllowUserToAddRows = False
    Me.dtgList.AllowUserToResizeColumns = False
    Me.dtgList.AllowUserToResizeRows = False
    Me.dtgList.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(227, Byte), Integer))
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.barCode, Me.goodName, Me.goodAmou, Me.unitDesc, Me.goodCode, Me.unitCost})
    Me.dtgList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgList.Location = New System.Drawing.Point(0, 0)
    Me.dtgList.Name = "dtgList"
    Me.dtgList.ReadOnly = True
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(173, Byte), Integer))
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgList.Size = New System.Drawing.Size(661, 217)
    Me.dtgList.TabIndex = 0
    '
    'barCode
    '
    Me.barCode.HeaderText = "รหัสสินค้า"
    Me.barCode.Name = "barCode"
    Me.barCode.ReadOnly = True
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
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle2.Format = "N0"
    Me.goodAmou.DefaultCellStyle = DataGridViewCellStyle2
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
    'unitCost
    '
    Me.unitCost.HeaderText = "unitCost"
    Me.unitCost.Name = "unitCost"
    Me.unitCost.ReadOnly = True
    Me.unitCost.Visible = False
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbnSave})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.ShowItemToolTips = False
    Me.ToolStrip1.Size = New System.Drawing.Size(661, 31)
    Me.ToolStrip1.TabIndex = 2
    Me.ToolStrip1.Text = "ToolStrip1"
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
    'pdc1
    '
    '
    'frmRequTran
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(661, 469)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmRequTran"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "ขอโอนสินค้า"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    Me.SplitContainer2.Panel1.ResumeLayout(False)
    Me.SplitContainer2.Panel1.PerformLayout()
    Me.SplitContainer2.Panel2.ResumeLayout(False)
    Me.SplitContainer2.ResumeLayout(False)
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents txtFromBranchName As System.Windows.Forms.TextBox
  Friend WithEvents txtBranchCode As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
  Friend WithEvents btnAdd As System.Windows.Forms.Button
  Friend WithEvents lblUnitDesc As System.Windows.Forms.Label
  Friend WithEvents txtGoodAmou As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtGoodName As System.Windows.Forms.TextBox
  Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtEmplName As System.Windows.Forms.TextBox
  Friend WithEvents txtEmplCode As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents dtgList As System.Windows.Forms.DataGridView
  Friend WithEvents btnGoodSearch As System.Windows.Forms.Button
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents tbnSave As System.Windows.Forms.ToolStripButton
  Friend WithEvents pdc1 As System.Drawing.Printing.PrintDocument
  Friend WithEvents barCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitCost As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents txtToBranchName As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
