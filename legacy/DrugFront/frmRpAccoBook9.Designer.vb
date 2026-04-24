<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRpAccoBook9
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
    Me.btnShow = New System.Windows.Forms.Button
    Me.dtpTo = New System.Windows.Forms.DateTimePicker
    Me.Label3 = New System.Windows.Forms.Label
    Me.dtpFrom = New System.Windows.Forms.DateTimePicker
    Me.Label2 = New System.Windows.Forms.Label
    Me.dtgList = New System.Windows.Forms.DataGridView
    Me.goodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.btnSearch = New System.Windows.Forms.Button
    Me.txtGoodName = New System.Windows.Forms.TextBox
    Me.txtBarcode = New System.Windows.Forms.TextBox
    Me.Label5 = New System.Windows.Forms.Label
    Me.Label6 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.cboMonth = New System.Windows.Forms.ComboBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.cboYear = New System.Windows.Forms.ComboBox
    Me.Label7 = New System.Windows.Forms.Label
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(137, 126)
    Me.btnShow.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(108, 28)
    Me.btnShow.TabIndex = 28
    Me.btnShow.Text = "แสดงรายงาน"
    Me.btnShow.UseVisualStyleBackColor = True
    '
    'dtpTo
    '
    Me.dtpTo.Location = New System.Drawing.Point(137, 326)
    Me.dtpTo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dtpTo.Name = "dtpTo"
    Me.dtpTo.Size = New System.Drawing.Size(180, 23)
    Me.dtpTo.TabIndex = 30
    Me.dtpTo.Visible = False
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(68, 331)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(45, 16)
    Me.Label3.TabIndex = 32
    Me.Label3.Text = "ถึงวันที่"
    Me.Label3.Visible = False
    '
    'dtpFrom
    '
    Me.dtpFrom.Location = New System.Drawing.Point(137, 292)
    Me.dtpFrom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dtpFrom.Name = "dtpFrom"
    Me.dtpFrom.Size = New System.Drawing.Size(180, 23)
    Me.dtpFrom.TabIndex = 29
    Me.dtpFrom.Visible = False
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(68, 297)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(61, 16)
    Me.Label2.TabIndex = 31
    Me.Label2.Text = "ตั้งแต่วันที่"
    Me.Label2.Visible = False
    '
    'dtgList
    '
    Me.dtgList.AllowUserToAddRows = False
    Me.dtgList.AllowUserToDeleteRows = False
    Me.dtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.goodCode, Me.goodName})
    Me.dtgList.Location = New System.Drawing.Point(19, 357)
    Me.dtgList.Name = "dtgList"
    Me.dtgList.ReadOnly = True
    Me.dtgList.Size = New System.Drawing.Size(80, 43)
    Me.dtgList.TabIndex = 44
    Me.dtgList.Visible = False
    '
    'goodCode
    '
    Me.goodCode.HeaderText = "goodCode"
    Me.goodCode.Name = "goodCode"
    Me.goodCode.ReadOnly = True
    '
    'goodName
    '
    Me.goodName.HeaderText = "goodName"
    Me.goodName.Name = "goodName"
    Me.goodName.ReadOnly = True
    '
    'btnSearch
    '
    Me.btnSearch.Location = New System.Drawing.Point(347, 357)
    Me.btnSearch.Name = "btnSearch"
    Me.btnSearch.Size = New System.Drawing.Size(27, 23)
    Me.btnSearch.TabIndex = 43
    Me.btnSearch.TabStop = False
    Me.btnSearch.Text = ".."
    Me.btnSearch.UseVisualStyleBackColor = True
    Me.btnSearch.Visible = False
    '
    'txtGoodName
    '
    Me.txtGoodName.Location = New System.Drawing.Point(194, 388)
    Me.txtGoodName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtGoodName.Name = "txtGoodName"
    Me.txtGoodName.ReadOnly = True
    Me.txtGoodName.Size = New System.Drawing.Size(180, 23)
    Me.txtGoodName.TabIndex = 42
    Me.txtGoodName.TabStop = False
    Me.txtGoodName.Visible = False
    '
    'txtBarcode
    '
    Me.txtBarcode.Location = New System.Drawing.Point(194, 357)
    Me.txtBarcode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtBarcode.Name = "txtBarcode"
    Me.txtBarcode.Size = New System.Drawing.Size(147, 23)
    Me.txtBarcode.TabIndex = 39
    Me.txtBarcode.Visible = False
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(125, 360)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(60, 16)
    Me.Label5.TabIndex = 40
    Me.Label5.Text = "รหัสสินค้า"
    Me.Label5.Visible = False
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(125, 391)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(54, 16)
    Me.Label6.TabIndex = 41
    Me.Label6.Text = "ชื่อสินค้า"
    Me.Label6.Visible = False
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(193, 52)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(33, 16)
    Me.Label4.TabIndex = 48
    Me.Label4.Text = "พ.ศ."
    '
    'cboMonth
    '
    Me.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboMonth.FormattingEnabled = True
    Me.cboMonth.Location = New System.Drawing.Point(137, 48)
    Me.cboMonth.Name = "cboMonth"
    Me.cboMonth.Size = New System.Drawing.Size(43, 24)
    Me.cboMonth.TabIndex = 45
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(62, 52)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(69, 16)
    Me.Label1.TabIndex = 47
    Me.Label1.Text = "ประจำเดือน"
    '
    'cboYear
    '
    Me.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboYear.FormattingEnabled = True
    Me.cboYear.Location = New System.Drawing.Point(232, 48)
    Me.cboYear.Name = "cboYear"
    Me.cboYear.Size = New System.Drawing.Size(89, 24)
    Me.cboYear.TabIndex = 46
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Label7.Location = New System.Drawing.Point(167, 9)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(59, 23)
    Me.Label7.TabIndex = 49
    Me.Label7.Text = "ข.ย.๙"
    '
    'frmRpAccoBook9
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(384, 211)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.cboMonth)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.cboYear)
    Me.Controls.Add(Me.dtgList)
    Me.Controls.Add(Me.btnSearch)
    Me.Controls.Add(Me.txtGoodName)
    Me.Controls.Add(Me.txtBarcode)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.btnShow)
    Me.Controls.Add(Me.dtpTo)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.dtpFrom)
    Me.Controls.Add(Me.Label2)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmRpAccoBook9"
    Me.Tag = "f3q"
    Me.Text = "บัญชีการซื้อยา (แบบ ข.ย.๙)"
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents dtgList As System.Windows.Forms.DataGridView
  Friend WithEvents goodCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents btnSearch As System.Windows.Forms.Button
  Friend WithEvents txtGoodName As System.Windows.Forms.TextBox
  Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents cboYear As System.Windows.Forms.ComboBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
