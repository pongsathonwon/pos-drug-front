<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRpPointUse
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
    Me.dtpFrom = New System.Windows.Forms.DateTimePicker
    Me.dtpTo = New System.Windows.Forms.DateTimePicker
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.btnShow = New System.Windows.Forms.Button
    Me.Label9 = New System.Windows.Forms.Label
    Me.txtCustName = New System.Windows.Forms.TextBox
    Me.txtCustCode = New System.Windows.Forms.TextBox
    Me.Label5 = New System.Windows.Forms.Label
    Me.btnCustSearch = New System.Windows.Forms.Button
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.Label1 = New System.Windows.Forms.Label
    Me.txtHugPoint = New System.Windows.Forms.TextBox
    Me.dtgList = New System.Windows.Forms.DataGridView
    Me.saleDate = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.saleNumb = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.totalPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.thisPoint = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.usePoint = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.custPoint = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'dtpFrom
    '
    Me.dtpFrom.Location = New System.Drawing.Point(95, 23)
    Me.dtpFrom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dtpFrom.Name = "dtpFrom"
    Me.dtpFrom.Size = New System.Drawing.Size(180, 23)
    Me.dtpFrom.TabIndex = 2
    '
    'dtpTo
    '
    Me.dtpTo.Location = New System.Drawing.Point(354, 23)
    Me.dtpTo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dtpTo.Name = "dtpTo"
    Me.dtpTo.Size = New System.Drawing.Size(180, 23)
    Me.dtpTo.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(21, 28)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(61, 16)
    Me.Label2.TabIndex = 23
    Me.Label2.Text = "ตั้งแต่วันที่"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(286, 28)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(45, 16)
    Me.Label3.TabIndex = 24
    Me.Label3.Text = "ถึงวันที่"
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(634, 85)
    Me.btnShow.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(87, 28)
    Me.btnShow.TabIndex = 1
    Me.btnShow.Text = "แสดงรายงาน"
    Me.btnShow.UseVisualStyleBackColor = True
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(21, 60)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(68, 16)
    Me.Label9.TabIndex = 80
    Me.Label9.Text = "รหัสสมาชิก"
    '
    'txtCustName
    '
    Me.txtCustName.BackColor = System.Drawing.Color.White
    Me.txtCustName.Location = New System.Drawing.Point(95, 88)
    Me.txtCustName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtCustName.Name = "txtCustName"
    Me.txtCustName.ReadOnly = True
    Me.txtCustName.Size = New System.Drawing.Size(180, 23)
    Me.txtCustName.TabIndex = 2
    Me.txtCustName.TabStop = False
    '
    'txtCustCode
    '
    Me.txtCustCode.BackColor = System.Drawing.Color.White
    Me.txtCustCode.Location = New System.Drawing.Point(95, 57)
    Me.txtCustCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtCustCode.Name = "txtCustCode"
    Me.txtCustCode.Size = New System.Drawing.Size(180, 23)
    Me.txtCustCode.TabIndex = 0
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(21, 91)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(62, 16)
    Me.Label5.TabIndex = 80
    Me.Label5.Text = "ชื่อสมาชิก"
    '
    'btnCustSearch
    '
    Me.btnCustSearch.Image = Global.DrugFront.My.Resources.Resources.search
    Me.btnCustSearch.Location = New System.Drawing.Point(281, 85)
    Me.btnCustSearch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnCustSearch.Name = "btnCustSearch"
    Me.btnCustSearch.Size = New System.Drawing.Size(30, 28)
    Me.btnCustSearch.TabIndex = 4
    Me.btnCustSearch.TabStop = False
    Me.btnCustSearch.UseVisualStyleBackColor = True
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.SplitContainer1.IsSplitterFixed = True
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.SplitContainer1.Name = "SplitContainer1"
    Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Plum
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtHugPoint)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnCustSearch)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnShow)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtCustName)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtCustCode)
    Me.SplitContainer1.Panel1.Controls.Add(Me.dtpFrom)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
    Me.SplitContainer1.Panel1.Controls.Add(Me.dtpTo)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.dtgList)
    Me.SplitContainer1.Size = New System.Drawing.Size(779, 601)
    Me.SplitContainer1.SplitterDistance = 128
    Me.SplitContainer1.SplitterWidth = 5
    Me.SplitContainer1.TabIndex = 0
    Me.SplitContainer1.TabStop = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(318, 91)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(70, 16)
    Me.Label1.TabIndex = 82
    Me.Label1.Text = "แต้มปัจจุบัน"
    '
    'txtHugPoint
    '
    Me.txtHugPoint.BackColor = System.Drawing.Color.White
    Me.txtHugPoint.Location = New System.Drawing.Point(394, 88)
    Me.txtHugPoint.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtHugPoint.Name = "txtHugPoint"
    Me.txtHugPoint.ReadOnly = True
    Me.txtHugPoint.Size = New System.Drawing.Size(140, 23)
    Me.txtHugPoint.TabIndex = 81
    Me.txtHugPoint.TabStop = False
    Me.txtHugPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'dtgList
    '
    Me.dtgList.AllowUserToAddRows = False
    Me.dtgList.AllowUserToDeleteRows = False
    Me.dtgList.AllowUserToResizeColumns = False
    Me.dtgList.AllowUserToResizeRows = False
    Me.dtgList.BackgroundColor = System.Drawing.Color.LavenderBlush
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.saleDate, Me.saleNumb, Me.totalPrice, Me.thisPoint, Me.usePoint, Me.custPoint})
    Me.dtgList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgList.Location = New System.Drawing.Point(0, 0)
    Me.dtgList.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dtgList.Name = "dtgList"
    Me.dtgList.ReadOnly = True
    Me.dtgList.RowHeadersVisible = False
    Me.dtgList.Size = New System.Drawing.Size(779, 468)
    Me.dtgList.TabIndex = 37
    Me.dtgList.TabStop = False
    '
    'saleDate
    '
    DataGridViewCellStyle2.Format = "d"
    DataGridViewCellStyle2.NullValue = Nothing
    Me.saleDate.DefaultCellStyle = DataGridViewCellStyle2
    Me.saleDate.HeaderText = "วันที่"
    Me.saleDate.Name = "saleDate"
    Me.saleDate.ReadOnly = True
    '
    'saleNumb
    '
    Me.saleNumb.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.saleNumb.HeaderText = "เลขที่ใบขาย"
    Me.saleNumb.Name = "saleNumb"
    Me.saleNumb.ReadOnly = True
    '
    'totalPrice
    '
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle3.Format = "N2"
    Me.totalPrice.DefaultCellStyle = DataGridViewCellStyle3
    Me.totalPrice.HeaderText = "จำนวนเงิน"
    Me.totalPrice.Name = "totalPrice"
    Me.totalPrice.ReadOnly = True
    '
    'thisPoint
    '
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle4.Format = "N0"
    Me.thisPoint.DefaultCellStyle = DataGridViewCellStyle4
    Me.thisPoint.HeaderText = "แต้มที่ได้"
    Me.thisPoint.Name = "thisPoint"
    Me.thisPoint.ReadOnly = True
    '
    'usePoint
    '
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle5.Format = "N0"
    Me.usePoint.DefaultCellStyle = DataGridViewCellStyle5
    Me.usePoint.HeaderText = "แต้มที่ใช้"
    Me.usePoint.Name = "usePoint"
    Me.usePoint.ReadOnly = True
    '
    'custPoint
    '
    DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle6.Format = "N0"
    Me.custPoint.DefaultCellStyle = DataGridViewCellStyle6
    Me.custPoint.HeaderText = "แต้มคงเหลือ"
    Me.custPoint.Name = "custPoint"
    Me.custPoint.ReadOnly = True
    '
    'frmRpPointUse
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(779, 601)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmRpPointUse"
    Me.Tag = "f3g"
    Me.Text = "รายงานประวัติแต้มของสมาชิก"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents btnCustSearch As System.Windows.Forms.Button
  Friend WithEvents txtCustName As System.Windows.Forms.TextBox
  Friend WithEvents txtCustCode As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents dtgList As System.Windows.Forms.DataGridView
  Friend WithEvents saleDate As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents saleNumb As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents totalPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents thisPoint As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents usePoint As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents custPoint As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtHugPoint As System.Windows.Forms.TextBox
End Class
