<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRpAccoGroupClose
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
    Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.dtpTo = New System.Windows.Forms.DateTimePicker
    Me.Label2 = New System.Windows.Forms.Label
    Me.dtpFrom = New System.Windows.Forms.DateTimePicker
    Me.Label1 = New System.Windows.Forms.Label
    Me.btnPrint = New System.Windows.Forms.Button
    Me.pdc1 = New System.Drawing.Printing.PrintDocument
    Me.dtgGroup = New System.Windows.Forms.DataGridView
    Me.GroupDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.TotalPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.perTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.btnShow = New System.Windows.Forms.Button
    Me.dtgGroup2 = New System.Windows.Forms.DataGridView
    Me.GroupDesc2 = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.TotalPrice2 = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.PerTotal2 = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    CType(Me.dtgGroup, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dtgGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SuspendLayout()
    '
    'dtpTo
    '
    Me.dtpTo.Location = New System.Drawing.Point(97, 47)
    Me.dtpTo.Name = "dtpTo"
    Me.dtpTo.Size = New System.Drawing.Size(162, 23)
    Me.dtpTo.TabIndex = 2
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(19, 50)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(45, 16)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "ถึงวันที่"
    '
    'dtpFrom
    '
    Me.dtpFrom.Location = New System.Drawing.Point(97, 18)
    Me.dtpFrom.Name = "dtpFrom"
    Me.dtpFrom.Size = New System.Drawing.Size(162, 23)
    Me.dtpFrom.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(19, 21)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(61, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "ตั้งแต่วันที่"
    '
    'btnPrint
    '
    Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
    Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.btnPrint.Location = New System.Drawing.Point(278, 47)
    Me.btnPrint.Name = "btnPrint"
    Me.btnPrint.Size = New System.Drawing.Size(122, 27)
    Me.btnPrint.TabIndex = 0
    Me.btnPrint.Text = "พิมพ์"
    Me.btnPrint.UseVisualStyleBackColor = True
    '
    'pdc1
    '
    '
    'dtgGroup
    '
    Me.dtgGroup.AllowUserToAddRows = False
    Me.dtgGroup.AllowUserToDeleteRows = False
    Me.dtgGroup.AllowUserToResizeColumns = False
    Me.dtgGroup.AllowUserToResizeRows = False
    Me.dtgGroup.BackgroundColor = System.Drawing.Color.LavenderBlush
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgGroup.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgGroup.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GroupDesc, Me.TotalPrice, Me.perTotal})
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LavenderBlush
    DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
    DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.dtgGroup.DefaultCellStyle = DataGridViewCellStyle4
    Me.dtgGroup.Location = New System.Drawing.Point(459, 10)
    Me.dtgGroup.Name = "dtgGroup"
    Me.dtgGroup.ReadOnly = True
    Me.dtgGroup.RowHeadersVisible = False
    Me.dtgGroup.Size = New System.Drawing.Size(132, 64)
    Me.dtgGroup.TabIndex = 35
    Me.dtgGroup.Visible = False
    '
    'GroupDesc
    '
    Me.GroupDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.GroupDesc.HeaderText = "กลุ่มสินค้า"
    Me.GroupDesc.Name = "GroupDesc"
    Me.GroupDesc.ReadOnly = True
    '
    'TotalPrice
    '
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle2.Format = "N2"
    Me.TotalPrice.DefaultCellStyle = DataGridViewCellStyle2
    Me.TotalPrice.HeaderText = "จำนวนเงิน"
    Me.TotalPrice.Name = "TotalPrice"
    Me.TotalPrice.ReadOnly = True
    '
    'perTotal
    '
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle3.Format = "N2"
    Me.perTotal.DefaultCellStyle = DataGridViewCellStyle3
    Me.perTotal.HeaderText = "คิดเป็น%"
    Me.perTotal.Name = "perTotal"
    Me.perTotal.ReadOnly = True
    '
    'btnShow
    '
    Me.btnShow.Cursor = System.Windows.Forms.Cursors.Hand
    Me.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.btnShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.btnShow.Location = New System.Drawing.Point(278, 16)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(122, 27)
    Me.btnShow.TabIndex = 0
    Me.btnShow.Text = "แสดงรายงาน"
    Me.btnShow.UseVisualStyleBackColor = True
    '
    'dtgGroup2
    '
    Me.dtgGroup2.AllowUserToAddRows = False
    Me.dtgGroup2.AllowUserToDeleteRows = False
    Me.dtgGroup2.AllowUserToResizeColumns = False
    Me.dtgGroup2.AllowUserToResizeRows = False
    Me.dtgGroup2.BackgroundColor = System.Drawing.Color.LavenderBlush
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgGroup2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
    Me.dtgGroup2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgGroup2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GroupDesc2, Me.TotalPrice2, Me.PerTotal2})
    DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LavenderBlush
    DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
    DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.dtgGroup2.DefaultCellStyle = DataGridViewCellStyle8
    Me.dtgGroup2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgGroup2.Location = New System.Drawing.Point(0, 0)
    Me.dtgGroup2.Name = "dtgGroup2"
    Me.dtgGroup2.ReadOnly = True
    Me.dtgGroup2.RowHeadersVisible = False
    Me.dtgGroup2.Size = New System.Drawing.Size(464, 186)
    Me.dtgGroup2.TabIndex = 36
    '
    'GroupDesc2
    '
    Me.GroupDesc2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.GroupDesc2.HeaderText = "กลุ่มสินค้า"
    Me.GroupDesc2.Name = "GroupDesc2"
    Me.GroupDesc2.ReadOnly = True
    '
    'TotalPrice2
    '
    DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle6.Format = "N2"
    Me.TotalPrice2.DefaultCellStyle = DataGridViewCellStyle6
    Me.TotalPrice2.HeaderText = "จำนวนเงิน"
    Me.TotalPrice2.Name = "TotalPrice2"
    Me.TotalPrice2.ReadOnly = True
    '
    'PerTotal2
    '
    DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle7.Format = "N2"
    Me.PerTotal2.DefaultCellStyle = DataGridViewCellStyle7
    Me.PerTotal2.HeaderText = "คิดเป็น%"
    Me.PerTotal2.Name = "PerTotal2"
    Me.PerTotal2.ReadOnly = True
    '
    'SplitContainer1
    '
    Me.SplitContainer1.BackColor = System.Drawing.SystemColors.Control
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
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
    Me.SplitContainer1.Panel1.Controls.Add(Me.dtgGroup)
    Me.SplitContainer1.Panel1.Controls.Add(Me.dtpFrom)
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnShow)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnPrint)
    Me.SplitContainer1.Panel1.Controls.Add(Me.dtpTo)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.dtgGroup2)
    Me.SplitContainer1.Size = New System.Drawing.Size(464, 276)
    Me.SplitContainer1.SplitterDistance = 86
    Me.SplitContainer1.TabIndex = 37
    '
    'frmRpAccoGroupClose
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.Plum
    Me.ClientSize = New System.Drawing.Size(464, 276)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmRpAccoGroupClose"
    Me.ShowInTaskbar = False
    Me.Tag = "f3a"
    Me.Text = "รายงานสรุปยอดขายแยกตามกลุ่มสินค้า"
    CType(Me.dtgGroup, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dtgGroup2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents btnPrint As System.Windows.Forms.Button
  Friend WithEvents pdc1 As System.Drawing.Printing.PrintDocument
  Friend WithEvents dtgGroup As System.Windows.Forms.DataGridView
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents GroupDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents TotalPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents perTotal As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents dtgGroup2 As System.Windows.Forms.DataGridView
  Friend WithEvents GroupDesc2 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents TotalPrice2 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents PerTotal2 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
End Class
