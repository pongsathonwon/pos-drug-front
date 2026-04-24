<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRpStockOver
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
    Me.dtpTo = New System.Windows.Forms.DateTimePicker
    Me.Label2 = New System.Windows.Forms.Label
    Me.btnShow = New System.Windows.Forms.Button
    Me.dtpFrom = New System.Windows.Forms.DateTimePicker
    Me.Label1 = New System.Windows.Forms.Label
    Me.dtgOver = New System.Windows.Forms.DataGridView
    Me.countDate = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.stockOnhand = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.stockCount = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.stockOver = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.emplName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    CType(Me.dtgOver, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
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
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Plum
    Me.SplitContainer1.Panel1.Controls.Add(Me.dtpTo)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnShow)
    Me.SplitContainer1.Panel1.Controls.Add(Me.dtpFrom)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.dtgOver)
    Me.SplitContainer1.Size = New System.Drawing.Size(918, 555)
    Me.SplitContainer1.SplitterDistance = 63
    Me.SplitContainer1.TabIndex = 0
    Me.SplitContainer1.TabStop = False
    '
    'dtpTo
    '
    Me.dtpTo.Location = New System.Drawing.Point(321, 21)
    Me.dtpTo.Name = "dtpTo"
    Me.dtpTo.Size = New System.Drawing.Size(164, 23)
    Me.dtpTo.TabIndex = 2
    Me.dtpTo.TabStop = False
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(261, 26)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(45, 16)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "ถึงวันที่"
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(504, 21)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(109, 23)
    Me.btnShow.TabIndex = 3
    Me.btnShow.Text = "แสดงรายการ"
    Me.btnShow.UseVisualStyleBackColor = True
    '
    'dtpFrom
    '
    Me.dtpFrom.Location = New System.Drawing.Point(83, 21)
    Me.dtpFrom.Name = "dtpFrom"
    Me.dtpFrom.Size = New System.Drawing.Size(164, 23)
    Me.dtpFrom.TabIndex = 1
    Me.dtpFrom.TabStop = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(16, 26)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(61, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "ตั้งแต่วันที่"
    '
    'dtgOver
    '
    Me.dtgOver.AllowUserToAddRows = False
    Me.dtgOver.AllowUserToDeleteRows = False
    Me.dtgOver.AllowUserToResizeColumns = False
    Me.dtgOver.AllowUserToResizeRows = False
    Me.dtgOver.BackgroundColor = System.Drawing.Color.LavenderBlush
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgOver.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgOver.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgOver.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.countDate, Me.goodName, Me.unitDesc, Me.stockOnhand, Me.stockCount, Me.stockOver, Me.emplName})
    DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LavenderBlush
    DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
    DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.dtgOver.DefaultCellStyle = DataGridViewCellStyle6
    Me.dtgOver.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgOver.Location = New System.Drawing.Point(0, 0)
    Me.dtgOver.Name = "dtgOver"
    Me.dtgOver.ReadOnly = True
    Me.dtgOver.RowHeadersVisible = False
    Me.dtgOver.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(232, Byte), Integer))
    Me.dtgOver.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgOver.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgOver.Size = New System.Drawing.Size(918, 488)
    Me.dtgOver.TabIndex = 0
    '
    'countDate
    '
    DataGridViewCellStyle2.Format = "d"
    DataGridViewCellStyle2.NullValue = Nothing
    Me.countDate.DefaultCellStyle = DataGridViewCellStyle2
    Me.countDate.HeaderText = "วันที่"
    Me.countDate.Name = "countDate"
    Me.countDate.ReadOnly = True
    '
    'goodName
    '
    Me.goodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.goodName.HeaderText = "รายการ"
    Me.goodName.Name = "goodName"
    Me.goodName.ReadOnly = True
    '
    'unitDesc
    '
    Me.unitDesc.HeaderText = "หน่วย"
    Me.unitDesc.Name = "unitDesc"
    Me.unitDesc.ReadOnly = True
    '
    'stockOnhand
    '
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle3.Format = "N0"
    DataGridViewCellStyle3.NullValue = Nothing
    Me.stockOnhand.DefaultCellStyle = DataGridViewCellStyle3
    Me.stockOnhand.HeaderText = "คงเหลือ"
    Me.stockOnhand.Name = "stockOnhand"
    Me.stockOnhand.ReadOnly = True
    '
    'stockCount
    '
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle4.Format = "N0"
    Me.stockCount.DefaultCellStyle = DataGridViewCellStyle4
    Me.stockCount.HeaderText = "นับได้"
    Me.stockCount.Name = "stockCount"
    Me.stockCount.ReadOnly = True
    '
    'stockOver
    '
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle5.Format = "N0"
    Me.stockOver.DefaultCellStyle = DataGridViewCellStyle5
    Me.stockOver.HeaderText = "ขาด-เกิน"
    Me.stockOver.Name = "stockOver"
    Me.stockOver.ReadOnly = True
    '
    'emplName
    '
    Me.emplName.HeaderText = "ผู้บันทึก"
    Me.emplName.Name = "emplName"
    Me.emplName.ReadOnly = True
    Me.emplName.Visible = False
    '
    'frmRpStockOver
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(918, 555)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmRpStockOver"
    Me.Tag = "f3i"
    Me.Text = "รายงานสต๊อคคลาดเคลื่อน"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    CType(Me.dtgOver, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents dtgOver As System.Windows.Forms.DataGridView
  Friend WithEvents countDate As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents stockOnhand As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents stockCount As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents stockOver As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents emplName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
