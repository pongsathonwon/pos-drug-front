<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUseBuyExchange
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
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.txtBarcode = New System.Windows.Forms.TextBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.lblBxAmou = New System.Windows.Forms.Label
    Me.txtBxCode = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.dtgList = New System.Windows.Forms.DataGridView
    Me.goodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.discAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.barCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
    Me.tbnGoodExchange = New System.Windows.Forms.ToolStripButton
    Me.tbnUse = New System.Windows.Forms.ToolStripButton
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtBarcode)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
    Me.SplitContainer1.Panel1.Controls.Add(Me.lblBxAmou)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtBxCode)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.dtgList)
    Me.SplitContainer1.Size = New System.Drawing.Size(669, 323)
    Me.SplitContainer1.SplitterDistance = 78
    Me.SplitContainer1.TabIndex = 0
    Me.SplitContainer1.TabStop = False
    '
    'txtBarcode
    '
    Me.txtBarcode.Location = New System.Drawing.Point(128, 41)
    Me.txtBarcode.Name = "txtBarcode"
    Me.txtBarcode.Size = New System.Drawing.Size(127, 23)
    Me.txtBarcode.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(14, 44)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(60, 16)
    Me.Label4.TabIndex = 3
    Me.Label4.Text = "รหัสสินค้า"
    '
    'lblBxAmou
    '
    Me.lblBxAmou.AutoSize = True
    Me.lblBxAmou.Location = New System.Drawing.Point(261, 15)
    Me.lblBxAmou.Name = "lblBxAmou"
    Me.lblBxAmou.Size = New System.Drawing.Size(42, 16)
    Me.lblBxAmou.TabIndex = 2
    Me.lblBxAmou.Text = "? สิทธิ์"
    '
    'txtBxCode
    '
    Me.txtBxCode.Location = New System.Drawing.Point(128, 12)
    Me.txtBxCode.Name = "txtBxCode"
    Me.txtBxCode.Size = New System.Drawing.Size(127, 23)
    Me.txtBxCode.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(14, 15)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(95, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "รหัสสิทธิ์แลกซื้อ"
    '
    'dtgList
    '
    Me.dtgList.AllowUserToAddRows = False
    Me.dtgList.AllowUserToResizeColumns = False
    Me.dtgList.AllowUserToResizeRows = False
    Me.dtgList.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.goodName, Me.goodAmou, Me.unitDesc, Me.discAmou, Me.goodCode, Me.barCode})
    Me.dtgList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgList.Location = New System.Drawing.Point(0, 0)
    Me.dtgList.Name = "dtgList"
    Me.dtgList.ReadOnly = True
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgList.Size = New System.Drawing.Size(669, 241)
    Me.dtgList.TabIndex = 0
    '
    'goodName
    '
    Me.goodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.goodName.HeaderText = "ชื่อสินค้า"
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
    'discAmou
    '
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle3.Format = "N2"
    Me.discAmou.DefaultCellStyle = DataGridViewCellStyle3
    Me.discAmou.HeaderText = "ส่วนลด"
    Me.discAmou.Name = "discAmou"
    Me.discAmou.ReadOnly = True
    '
    'goodCode
    '
    Me.goodCode.HeaderText = "goodCode"
    Me.goodCode.Name = "goodCode"
    Me.goodCode.ReadOnly = True
    Me.goodCode.Visible = False
    '
    'barCode
    '
    Me.barCode.HeaderText = "barCode"
    Me.barCode.Name = "barCode"
    Me.barCode.ReadOnly = True
    Me.barCode.Visible = False
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbnGoodExchange, Me.tbnUse})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.ShowItemToolTips = False
    Me.ToolStrip1.Size = New System.Drawing.Size(669, 25)
    Me.ToolStrip1.TabIndex = 1
    Me.ToolStrip1.Text = "ToolStrip1"
    '
    'tbnGoodExchange
    '
    Me.tbnGoodExchange.Image = Global.DrugFront.My.Resources.Resources.list
    Me.tbnGoodExchange.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnGoodExchange.Name = "tbnGoodExchange"
    Me.tbnGoodExchange.Size = New System.Drawing.Size(198, 22)
    Me.tbnGoodExchange.Text = "รายการสินค้าที่มีสิทธิ์แลกซื้อ F4"
    '
    'tbnUse
    '
    Me.tbnUse.Image = Global.DrugFront.My.Resources.Resources.filesave
    Me.tbnUse.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnUse.Name = "tbnUse"
    Me.tbnUse.Size = New System.Drawing.Size(158, 22)
    Me.tbnUse.Text = "บันทึกใช้สิทธิ์แลกซื้อ F8"
    '
    'frmUseBuyExchange
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(669, 348)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmUseBuyExchange"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "ใช้สิทธิ์แลกซื้อ"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents lblBxAmou As System.Windows.Forms.Label
  Friend WithEvents txtBxCode As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents dtgList As System.Windows.Forms.DataGridView
  Friend WithEvents goodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents discAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents barCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents tbnGoodExchange As System.Windows.Forms.ToolStripButton
  Friend WithEvents tbnUse As System.Windows.Forms.ToolStripButton
End Class
