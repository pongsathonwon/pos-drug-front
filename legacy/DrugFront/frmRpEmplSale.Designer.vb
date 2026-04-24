<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRpEmplSale
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
    Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.btnCompSearch = New System.Windows.Forms.Button
    Me.txtCompName = New System.Windows.Forms.TextBox
    Me.Label6 = New System.Windows.Forms.Label
    Me.txtCompCode = New System.Windows.Forms.TextBox
    Me.Label7 = New System.Windows.Forms.Label
    Me.btnGoodSearch = New System.Windows.Forms.Button
    Me.txtGoodName = New System.Windows.Forms.TextBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.txtBarcode = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.btnShow = New System.Windows.Forms.Button
    Me.Label2 = New System.Windows.Forms.Label
    Me.dtpTo = New System.Windows.Forms.DateTimePicker
    Me.dtpFrom = New System.Windows.Forms.DateTimePicker
    Me.Label3 = New System.Windows.Forms.Label
    Me.dtgList = New System.Windows.Forms.DataGridView
    Me.goodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.emplName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.saleAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.retuAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.totalAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.totalSale = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnCompSearch)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtCompName)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtCompCode)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnGoodSearch)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtGoodName)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtBarcode)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnShow)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
    Me.SplitContainer1.Panel1.Controls.Add(Me.dtpTo)
    Me.SplitContainer1.Panel1.Controls.Add(Me.dtpFrom)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.dtgList)
    Me.SplitContainer1.Size = New System.Drawing.Size(842, 523)
    Me.SplitContainer1.SplitterDistance = 160
    Me.SplitContainer1.TabIndex = 0
    Me.SplitContainer1.TabStop = False
    '
    'btnCompSearch
    '
    Me.btnCompSearch.Image = Global.DrugFront.My.Resources.Resources.search
    Me.btnCompSearch.Location = New System.Drawing.Point(588, 84)
    Me.btnCompSearch.Name = "btnCompSearch"
    Me.btnCompSearch.Size = New System.Drawing.Size(29, 23)
    Me.btnCompSearch.TabIndex = 5
    Me.btnCompSearch.UseVisualStyleBackColor = True
    '
    'txtCompName
    '
    Me.txtCompName.Location = New System.Drawing.Point(338, 84)
    Me.txtCompName.Name = "txtCompName"
    Me.txtCompName.ReadOnly = True
    Me.txtCompName.Size = New System.Drawing.Size(244, 23)
    Me.txtCompName.TabIndex = 20
    Me.txtCompName.TabStop = False
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(278, 87)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(57, 16)
    Me.Label6.TabIndex = 19
    Me.Label6.Text = "ชื่อบริษัท"
    '
    'txtCompCode
    '
    Me.txtCompCode.Location = New System.Drawing.Point(92, 84)
    Me.txtCompCode.Name = "txtCompCode"
    Me.txtCompCode.Size = New System.Drawing.Size(180, 23)
    Me.txtCompCode.TabIndex = 2
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(25, 87)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(63, 16)
    Me.Label7.TabIndex = 18
    Me.Label7.Text = "รหัสบริษัท"
    '
    'btnGoodSearch
    '
    Me.btnGoodSearch.Image = Global.DrugFront.My.Resources.Resources.search
    Me.btnGoodSearch.Location = New System.Drawing.Point(588, 113)
    Me.btnGoodSearch.Name = "btnGoodSearch"
    Me.btnGoodSearch.Size = New System.Drawing.Size(29, 23)
    Me.btnGoodSearch.TabIndex = 6
    Me.btnGoodSearch.UseVisualStyleBackColor = True
    '
    'txtGoodName
    '
    Me.txtGoodName.Location = New System.Drawing.Point(338, 113)
    Me.txtGoodName.Name = "txtGoodName"
    Me.txtGoodName.ReadOnly = True
    Me.txtGoodName.Size = New System.Drawing.Size(244, 23)
    Me.txtGoodName.TabIndex = 13
    Me.txtGoodName.TabStop = False
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(278, 116)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(54, 16)
    Me.Label4.TabIndex = 12
    Me.Label4.Text = "ชื่อสินค้า"
    '
    'txtBarcode
    '
    Me.txtBarcode.Location = New System.Drawing.Point(92, 113)
    Me.txtBarcode.Name = "txtBarcode"
    Me.txtBarcode.Size = New System.Drawing.Size(180, 23)
    Me.txtBarcode.TabIndex = 3
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(25, 116)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(60, 16)
    Me.Label1.TabIndex = 12
    Me.Label1.Text = "รหัสสินค้า"
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(658, 110)
    Me.btnShow.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(93, 28)
    Me.btnShow.TabIndex = 4
    Me.btnShow.Text = "แสดงรายการ"
    Me.btnShow.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(25, 28)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(61, 16)
    Me.Label2.TabIndex = 10
    Me.Label2.Text = "ตั้งแต่วันที่"
    '
    'dtpTo
    '
    Me.dtpTo.Location = New System.Drawing.Point(92, 54)
    Me.dtpTo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dtpTo.Name = "dtpTo"
    Me.dtpTo.Size = New System.Drawing.Size(180, 23)
    Me.dtpTo.TabIndex = 1
    '
    'dtpFrom
    '
    Me.dtpFrom.Location = New System.Drawing.Point(92, 23)
    Me.dtpFrom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dtpFrom.Name = "dtpFrom"
    Me.dtpFrom.Size = New System.Drawing.Size(180, 23)
    Me.dtpFrom.TabIndex = 0
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(25, 59)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(45, 16)
    Me.Label3.TabIndex = 11
    Me.Label3.Text = "ถึงวันที่"
    '
    'dtgList
    '
    Me.dtgList.AllowUserToAddRows = False
    Me.dtgList.AllowUserToDeleteRows = False
    Me.dtgList.AllowUserToResizeColumns = False
    Me.dtgList.AllowUserToResizeRows = False
    Me.dtgList.BackgroundColor = System.Drawing.Color.LavenderBlush
    DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
    Me.dtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.goodName, Me.unitDesc, Me.emplName, Me.saleAmou, Me.retuAmou, Me.totalAmou, Me.totalSale})
    DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LavenderBlush
    DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
    DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.dtgList.DefaultCellStyle = DataGridViewCellStyle12
    Me.dtgList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgList.Location = New System.Drawing.Point(0, 0)
    Me.dtgList.Name = "dtgList"
    Me.dtgList.ReadOnly = True
    Me.dtgList.RowHeadersVisible = False
    Me.dtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgList.Size = New System.Drawing.Size(842, 359)
    Me.dtgList.TabIndex = 0
    Me.dtgList.TabStop = False
    '
    'goodName
    '
    Me.goodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.goodName.HeaderText = "ชื่อสินค้า"
    Me.goodName.Name = "goodName"
    Me.goodName.ReadOnly = True
    '
    'unitDesc
    '
    Me.unitDesc.HeaderText = "หน่วย"
    Me.unitDesc.Name = "unitDesc"
    Me.unitDesc.ReadOnly = True
    Me.unitDesc.Width = 60
    '
    'emplName
    '
    Me.emplName.HeaderText = "พนักงานขาย"
    Me.emplName.Name = "emplName"
    Me.emplName.ReadOnly = True
    Me.emplName.Width = 200
    '
    'saleAmou
    '
    DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle8.Format = "N0"
    Me.saleAmou.DefaultCellStyle = DataGridViewCellStyle8
    Me.saleAmou.HeaderText = "ขาย"
    Me.saleAmou.Name = "saleAmou"
    Me.saleAmou.ReadOnly = True
    Me.saleAmou.Width = 80
    '
    'retuAmou
    '
    DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle9.Format = "N0"
    Me.retuAmou.DefaultCellStyle = DataGridViewCellStyle9
    Me.retuAmou.HeaderText = "คืน"
    Me.retuAmou.Name = "retuAmou"
    Me.retuAmou.ReadOnly = True
    Me.retuAmou.Width = 80
    '
    'totalAmou
    '
    DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle10.Format = "N0"
    Me.totalAmou.DefaultCellStyle = DataGridViewCellStyle10
    Me.totalAmou.HeaderText = "รวม"
    Me.totalAmou.Name = "totalAmou"
    Me.totalAmou.ReadOnly = True
    Me.totalAmou.Width = 80
    '
    'totalSale
    '
    DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle11.Format = "N2"
    Me.totalSale.DefaultCellStyle = DataGridViewCellStyle11
    Me.totalSale.HeaderText = "เป็นเงิน"
    Me.totalSale.Name = "totalSale"
    Me.totalSale.ReadOnly = True
    '
    'frmRpEmplSale
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(842, 523)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmRpEmplSale"
    Me.Text = "รายงานสรุปปริมาณการขาย"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents txtGoodName As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents dtgList As System.Windows.Forms.DataGridView
  Friend WithEvents btnGoodSearch As System.Windows.Forms.Button
  Friend WithEvents btnCompSearch As System.Windows.Forms.Button
  Friend WithEvents txtCompName As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents txtCompCode As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents goodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents emplName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents saleAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents retuAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents totalAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents totalSale As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
