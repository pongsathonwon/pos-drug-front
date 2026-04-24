<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPromotion
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
    Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.TabControl1 = New System.Windows.Forms.TabControl
    Me.TabPage2 = New System.Windows.Forms.TabPage
    Me.dtgGoodPro = New System.Windows.Forms.DataGridView
    Me.TabPage3 = New System.Windows.Forms.TabPage
    Me.dtgCompPro = New System.Windows.Forms.DataGridView
    Me.cCustTypeDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.cCompName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.cBuyPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.cPoint = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.cDisc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.compProNumb = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.cStartDate = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.cEndDate = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.TabPage1 = New System.Windows.Forms.TabPage
    Me.dtgPro = New System.Windows.Forms.DataGridView
    Me.custTypeDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.ProText = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.pStartDate = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.pEndDate = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.extraPoint = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.plusPoint = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.gCustTypeDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.gGoodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.gGoodName2 = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.gAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.gPoint = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.gDisc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.gFixPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.gStartDate = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.gEndDate = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.gBarcode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.TabControl1.SuspendLayout()
    Me.TabPage2.SuspendLayout()
    CType(Me.dtgGoodPro, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TabPage3.SuspendLayout()
    CType(Me.dtgCompPro, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TabPage1.SuspendLayout()
    CType(Me.dtgPro, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TabPage2)
    Me.TabControl1.Controls.Add(Me.TabPage3)
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TabControl1.Location = New System.Drawing.Point(0, 0)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(1153, 614)
    Me.TabControl1.TabIndex = 0
    '
    'TabPage2
    '
    Me.TabPage2.Controls.Add(Me.dtgGoodPro)
    Me.TabPage2.Location = New System.Drawing.Point(4, 25)
    Me.TabPage2.Name = "TabPage2"
    Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage2.Size = New System.Drawing.Size(1145, 585)
    Me.TabPage2.TabIndex = 1
    Me.TabPage2.Text = "โปรโมชั่นสินค้า"
    Me.TabPage2.UseVisualStyleBackColor = True
    '
    'dtgGoodPro
    '
    Me.dtgGoodPro.AllowUserToAddRows = False
    Me.dtgGoodPro.AllowUserToDeleteRows = False
    Me.dtgGoodPro.AllowUserToResizeColumns = False
    Me.dtgGoodPro.AllowUserToResizeRows = False
    Me.dtgGoodPro.BackgroundColor = System.Drawing.Color.LightGreen
    Me.dtgGoodPro.BorderStyle = System.Windows.Forms.BorderStyle.None
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgGoodPro.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgGoodPro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgGoodPro.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gCustTypeDesc, Me.gGoodName, Me.gGoodName2, Me.gAmou, Me.gPoint, Me.gDisc, Me.gFixPrice, Me.gStartDate, Me.gEndDate, Me.gBarcode})
    Me.dtgGoodPro.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgGoodPro.Location = New System.Drawing.Point(3, 3)
    Me.dtgGoodPro.Name = "dtgGoodPro"
    Me.dtgGoodPro.ReadOnly = True
    Me.dtgGoodPro.RowHeadersVisible = False
    Me.dtgGoodPro.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightGreen
    Me.dtgGoodPro.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgGoodPro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgGoodPro.Size = New System.Drawing.Size(1139, 579)
    Me.dtgGoodPro.TabIndex = 1
    '
    'TabPage3
    '
    Me.TabPage3.Controls.Add(Me.dtgCompPro)
    Me.TabPage3.Location = New System.Drawing.Point(4, 25)
    Me.TabPage3.Name = "TabPage3"
    Me.TabPage3.Size = New System.Drawing.Size(1145, 585)
    Me.TabPage3.TabIndex = 2
    Me.TabPage3.Text = "โปรโมชั่นบริษัท"
    Me.TabPage3.UseVisualStyleBackColor = True
    '
    'dtgCompPro
    '
    Me.dtgCompPro.AllowUserToAddRows = False
    Me.dtgCompPro.AllowUserToDeleteRows = False
    Me.dtgCompPro.AllowUserToResizeColumns = False
    Me.dtgCompPro.AllowUserToResizeRows = False
    Me.dtgCompPro.BackgroundColor = System.Drawing.Color.Plum
    Me.dtgCompPro.BorderStyle = System.Windows.Forms.BorderStyle.None
    DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgCompPro.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
    Me.dtgCompPro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgCompPro.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCustTypeDesc, Me.cCompName, Me.cBuyPrice, Me.cPoint, Me.cDisc, Me.compProNumb, Me.cStartDate, Me.cEndDate})
    Me.dtgCompPro.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgCompPro.Location = New System.Drawing.Point(0, 0)
    Me.dtgCompPro.Name = "dtgCompPro"
    Me.dtgCompPro.ReadOnly = True
    Me.dtgCompPro.RowHeadersVisible = False
    Me.dtgCompPro.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Plum
    Me.dtgCompPro.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgCompPro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgCompPro.Size = New System.Drawing.Size(1145, 585)
    Me.dtgCompPro.TabIndex = 1
    '
    'cCustTypeDesc
    '
    Me.cCustTypeDesc.HeaderText = "ประเภทลูกค้า"
    Me.cCustTypeDesc.Name = "cCustTypeDesc"
    Me.cCustTypeDesc.ReadOnly = True
    Me.cCustTypeDesc.Width = 120
    '
    'cCompName
    '
    Me.cCompName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.cCompName.HeaderText = "ชื่อบริษัท"
    Me.cCompName.Name = "cCompName"
    Me.cCompName.ReadOnly = True
    '
    'cBuyPrice
    '
    DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle9.Format = "N0"
    Me.cBuyPrice.DefaultCellStyle = DataGridViewCellStyle9
    Me.cBuyPrice.HeaderText = "ยอดซื้อ"
    Me.cBuyPrice.Name = "cBuyPrice"
    Me.cBuyPrice.ReadOnly = True
    '
    'cPoint
    '
    DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle10.Format = "N0"
    DataGridViewCellStyle10.NullValue = Nothing
    Me.cPoint.DefaultCellStyle = DataGridViewCellStyle10
    Me.cPoint.HeaderText = "เพิ่มแต้ม"
    Me.cPoint.Name = "cPoint"
    Me.cPoint.ReadOnly = True
    '
    'cDisc
    '
    DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle11.Format = "N2"
    Me.cDisc.DefaultCellStyle = DataGridViewCellStyle11
    Me.cDisc.HeaderText = "ส่วนลด"
    Me.cDisc.Name = "cDisc"
    Me.cDisc.ReadOnly = True
    '
    'compProNumb
    '
    Me.compProNumb.HeaderText = "compProNumb"
    Me.compProNumb.Name = "compProNumb"
    Me.compProNumb.ReadOnly = True
    Me.compProNumb.Visible = False
    '
    'cStartDate
    '
    DataGridViewCellStyle12.Format = "d"
    DataGridViewCellStyle12.NullValue = Nothing
    Me.cStartDate.DefaultCellStyle = DataGridViewCellStyle12
    Me.cStartDate.HeaderText = "ตั้งแต่วันที่"
    Me.cStartDate.Name = "cStartDate"
    Me.cStartDate.ReadOnly = True
    Me.cStartDate.Width = 90
    '
    'cEndDate
    '
    DataGridViewCellStyle13.Format = "d"
    DataGridViewCellStyle13.NullValue = Nothing
    Me.cEndDate.DefaultCellStyle = DataGridViewCellStyle13
    Me.cEndDate.HeaderText = "ถึงวันที่"
    Me.cEndDate.Name = "cEndDate"
    Me.cEndDate.ReadOnly = True
    Me.cEndDate.Width = 80
    '
    'TabPage1
    '
    Me.TabPage1.Controls.Add(Me.dtgPro)
    Me.TabPage1.Location = New System.Drawing.Point(4, 25)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(1145, 585)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "โปรโมชั่นทั่วไป"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'dtgPro
    '
    Me.dtgPro.AllowUserToAddRows = False
    Me.dtgPro.AllowUserToDeleteRows = False
    Me.dtgPro.AllowUserToResizeColumns = False
    Me.dtgPro.AllowUserToResizeRows = False
    Me.dtgPro.BackgroundColor = System.Drawing.Color.LightSkyBlue
    Me.dtgPro.BorderStyle = System.Windows.Forms.BorderStyle.None
    DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgPro.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
    Me.dtgPro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    Me.dtgPro.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.custTypeDesc, Me.ProText, Me.pStartDate, Me.pEndDate, Me.extraPoint, Me.plusPoint})
    Me.dtgPro.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgPro.Location = New System.Drawing.Point(3, 3)
    Me.dtgPro.Name = "dtgPro"
    Me.dtgPro.ReadOnly = True
    Me.dtgPro.RowHeadersVisible = False
    Me.dtgPro.RowHeadersWidth = 30
    DataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.White
    DataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgPro.RowsDefaultCellStyle = DataGridViewCellStyle17
    Me.dtgPro.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightSkyBlue
    Me.dtgPro.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgPro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgPro.Size = New System.Drawing.Size(1139, 579)
    Me.dtgPro.TabIndex = 1
    Me.dtgPro.TabStop = False
    '
    'custTypeDesc
    '
    Me.custTypeDesc.HeaderText = "ประเภทลูกค้า"
    Me.custTypeDesc.Name = "custTypeDesc"
    Me.custTypeDesc.ReadOnly = True
    Me.custTypeDesc.Width = 120
    '
    'ProText
    '
    Me.ProText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.ProText.HeaderText = "รายการ"
    Me.ProText.Name = "ProText"
    Me.ProText.ReadOnly = True
    Me.ProText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
    '
    'pStartDate
    '
    DataGridViewCellStyle15.Format = "d"
    DataGridViewCellStyle15.NullValue = Nothing
    Me.pStartDate.DefaultCellStyle = DataGridViewCellStyle15
    Me.pStartDate.HeaderText = "ตั้งแต่วันที่"
    Me.pStartDate.Name = "pStartDate"
    Me.pStartDate.ReadOnly = True
    Me.pStartDate.Width = 80
    '
    'pEndDate
    '
    DataGridViewCellStyle16.Format = "d"
    DataGridViewCellStyle16.NullValue = Nothing
    Me.pEndDate.DefaultCellStyle = DataGridViewCellStyle16
    Me.pEndDate.HeaderText = "ถึงวันที่"
    Me.pEndDate.Name = "pEndDate"
    Me.pEndDate.ReadOnly = True
    Me.pEndDate.Width = 80
    '
    'extraPoint
    '
    Me.extraPoint.HeaderText = "แต้มพิเศษ"
    Me.extraPoint.Name = "extraPoint"
    Me.extraPoint.ReadOnly = True
    Me.extraPoint.Visible = False
    '
    'plusPoint
    '
    Me.plusPoint.HeaderText = "แต้มเบิ้ล"
    Me.plusPoint.Name = "plusPoint"
    Me.plusPoint.ReadOnly = True
    Me.plusPoint.Visible = False
    '
    'gCustTypeDesc
    '
    Me.gCustTypeDesc.HeaderText = "ประเภทลูกค้า"
    Me.gCustTypeDesc.Name = "gCustTypeDesc"
    Me.gCustTypeDesc.ReadOnly = True
    Me.gCustTypeDesc.Width = 120
    '
    'gGoodName
    '
    Me.gGoodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.gGoodName.HeaderText = "ชื่อสินค้า"
    Me.gGoodName.Name = "gGoodName"
    Me.gGoodName.ReadOnly = True
    '
    'gGoodName2
    '
    Me.gGoodName2.HeaderText = "สินค้าจับคู่"
    Me.gGoodName2.Name = "gGoodName2"
    Me.gGoodName2.ReadOnly = True
    Me.gGoodName2.Width = 180
    '
    'gAmou
    '
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle2.Format = "N0"
    Me.gAmou.DefaultCellStyle = DataGridViewCellStyle2
    Me.gAmou.HeaderText = "จำนวนซื้อ"
    Me.gAmou.Name = "gAmou"
    Me.gAmou.ReadOnly = True
    '
    'gPoint
    '
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle3.Format = "N0"
    DataGridViewCellStyle3.NullValue = Nothing
    Me.gPoint.DefaultCellStyle = DataGridViewCellStyle3
    Me.gPoint.HeaderText = "เพิ่มแต้ม"
    Me.gPoint.Name = "gPoint"
    Me.gPoint.ReadOnly = True
    Me.gPoint.Width = 80
    '
    'gDisc
    '
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle4.Format = "N2"
    Me.gDisc.DefaultCellStyle = DataGridViewCellStyle4
    Me.gDisc.HeaderText = "ส่วนลด"
    Me.gDisc.Name = "gDisc"
    Me.gDisc.ReadOnly = True
    Me.gDisc.Width = 80
    '
    'gFixPrice
    '
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle5.Format = "N2"
    Me.gFixPrice.DefaultCellStyle = DataGridViewCellStyle5
    Me.gFixPrice.HeaderText = "ราคาโปร"
    Me.gFixPrice.Name = "gFixPrice"
    Me.gFixPrice.ReadOnly = True
    Me.gFixPrice.Width = 80
    '
    'gStartDate
    '
    DataGridViewCellStyle6.Format = "d"
    DataGridViewCellStyle6.NullValue = Nothing
    Me.gStartDate.DefaultCellStyle = DataGridViewCellStyle6
    Me.gStartDate.HeaderText = "ตั้งแต่วันที่"
    Me.gStartDate.Name = "gStartDate"
    Me.gStartDate.ReadOnly = True
    Me.gStartDate.Width = 90
    '
    'gEndDate
    '
    DataGridViewCellStyle7.Format = "d"
    DataGridViewCellStyle7.NullValue = Nothing
    Me.gEndDate.DefaultCellStyle = DataGridViewCellStyle7
    Me.gEndDate.HeaderText = "ถึงวันที่"
    Me.gEndDate.Name = "gEndDate"
    Me.gEndDate.ReadOnly = True
    Me.gEndDate.Width = 80
    '
    'gBarcode
    '
    Me.gBarcode.HeaderText = "รหัสสินค้า"
    Me.gBarcode.Name = "gBarcode"
    Me.gBarcode.ReadOnly = True
    Me.gBarcode.Visible = False
    '
    'frmPromotion
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1153, 614)
    Me.Controls.Add(Me.TabControl1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmPromotion"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "โปรโมชั่น"
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage2.ResumeLayout(False)
    CType(Me.dtgGoodPro, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TabPage3.ResumeLayout(False)
    CType(Me.dtgCompPro, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TabPage1.ResumeLayout(False)
    CType(Me.dtgPro, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
  Friend WithEvents dtgPro As System.Windows.Forms.DataGridView
  Friend WithEvents dtgGoodPro As System.Windows.Forms.DataGridView
  Friend WithEvents custTypeDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ProText As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents pStartDate As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents pEndDate As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents extraPoint As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents plusPoint As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents dtgCompPro As System.Windows.Forms.DataGridView
  Friend WithEvents cCustTypeDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents cCompName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents cBuyPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents cPoint As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents cDisc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents compProNumb As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents cStartDate As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents cEndDate As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents gCustTypeDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents gGoodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents gGoodName2 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents gAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents gPoint As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents gDisc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents gFixPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents gStartDate As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents gEndDate As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents gBarcode As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
