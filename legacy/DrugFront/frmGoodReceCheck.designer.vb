<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGoodReceCheck
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
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
    Me.btnShow = New System.Windows.Forms.Button
    Me.dtpRece = New System.Windows.Forms.DateTimePicker
    Me.Label1 = New System.Windows.Forms.Label
    Me.dtgHistRece = New System.Windows.Forms.DataGridView
    Me.receDate = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.receNumb = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.invoNumb = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.EmplName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.ReceDay = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.orderNumb = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
    Me.lblInvoNumb = New System.Windows.Forms.Label
    Me.Label6 = New System.Windows.Forms.Label
    Me.Label5 = New System.Windows.Forms.Label
    Me.lblReceDate = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.lblReceNumb = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.lblEmplName = New System.Windows.Forms.Label
    Me.dtgReceList = New System.Windows.Forms.DataGridView
    Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.UnitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SplitContainer2.Panel1.SuspendLayout()
    Me.SplitContainer2.Panel2.SuspendLayout()
    Me.SplitContainer2.SuspendLayout()
    CType(Me.dtgHistRece, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer3.Panel1.SuspendLayout()
    Me.SplitContainer3.Panel2.SuspendLayout()
    Me.SplitContainer3.SuspendLayout()
    CType(Me.dtgReceList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer1.IsSplitterFixed = True
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer1.Name = "SplitContainer1"
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
    Me.SplitContainer1.Size = New System.Drawing.Size(1075, 537)
    Me.SplitContainer1.SplitterDistance = 380
    Me.SplitContainer1.TabIndex = 0
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
    Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.CornflowerBlue
    Me.SplitContainer2.Panel1.Controls.Add(Me.btnShow)
    Me.SplitContainer2.Panel1.Controls.Add(Me.dtpRece)
    Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
    '
    'SplitContainer2.Panel2
    '
    Me.SplitContainer2.Panel2.Controls.Add(Me.dtgHistRece)
    Me.SplitContainer2.Size = New System.Drawing.Size(380, 537)
    Me.SplitContainer2.SplitterDistance = 34
    Me.SplitContainer2.TabIndex = 0
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(227, 6)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(108, 25)
    Me.btnShow.TabIndex = 0
    Me.btnShow.Text = "แสดงรายการ"
    Me.btnShow.UseVisualStyleBackColor = True
    '
    'dtpRece
    '
    Me.dtpRece.CustomFormat = "MMMM yyyy"
    Me.dtpRece.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.dtpRece.Location = New System.Drawing.Point(86, 6)
    Me.dtpRece.Name = "dtpRece"
    Me.dtpRece.ShowUpDown = True
    Me.dtpRece.Size = New System.Drawing.Size(135, 23)
    Me.dtpRece.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(10, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(69, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "ประจำเดือน"
    '
    'dtgHistRece
    '
    Me.dtgHistRece.AllowUserToAddRows = False
    Me.dtgHistRece.AllowUserToDeleteRows = False
    Me.dtgHistRece.AllowUserToResizeColumns = False
    Me.dtgHistRece.AllowUserToResizeRows = False
    Me.dtgHistRece.BackgroundColor = System.Drawing.Color.AliceBlue
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgHistRece.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgHistRece.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.receDate, Me.receNumb, Me.invoNumb, Me.EmplName, Me.ReceDay, Me.orderNumb})
    Me.dtgHistRece.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgHistRece.Location = New System.Drawing.Point(0, 0)
    Me.dtgHistRece.Name = "dtgHistRece"
    Me.dtgHistRece.ReadOnly = True
    Me.dtgHistRece.RowHeadersVisible = False
    Me.dtgHistRece.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.CornflowerBlue
    Me.dtgHistRece.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgHistRece.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.dtgHistRece.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgHistRece.Size = New System.Drawing.Size(380, 499)
    Me.dtgHistRece.TabIndex = 0
    '
    'receDate
    '
    DataGridViewCellStyle2.Format = "d"
    DataGridViewCellStyle2.NullValue = Nothing
    Me.receDate.DefaultCellStyle = DataGridViewCellStyle2
    Me.receDate.HeaderText = "วันที่"
    Me.receDate.Name = "receDate"
    Me.receDate.ReadOnly = True
    Me.receDate.Width = 80
    '
    'receNumb
    '
    Me.receNumb.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.receNumb.HeaderText = "เลขที่ใบรับ"
    Me.receNumb.Name = "receNumb"
    Me.receNumb.ReadOnly = True
    '
    'invoNumb
    '
    Me.invoNumb.HeaderText = "เลขที่ใบส่งสินค้า"
    Me.invoNumb.Name = "invoNumb"
    Me.invoNumb.ReadOnly = True
    '
    'EmplName
    '
    Me.EmplName.HeaderText = "ผู้รับ"
    Me.EmplName.Name = "EmplName"
    Me.EmplName.ReadOnly = True
    Me.EmplName.Width = 80
    '
    'ReceDay
    '
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    Me.ReceDay.DefaultCellStyle = DataGridViewCellStyle3
    Me.ReceDay.HeaderText = "receDay"
    Me.ReceDay.Name = "ReceDay"
    Me.ReceDay.ReadOnly = True
    Me.ReceDay.Visible = False
    Me.ReceDay.Width = 40
    '
    'orderNumb
    '
    Me.orderNumb.HeaderText = "orderNumb"
    Me.orderNumb.Name = "orderNumb"
    Me.orderNumb.ReadOnly = True
    Me.orderNumb.Visible = False
    '
    'SplitContainer3
    '
    Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer3.IsSplitterFixed = True
    Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer3.Name = "SplitContainer3"
    Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer3.Panel1
    '
    Me.SplitContainer3.Panel1.BackColor = System.Drawing.Color.CornflowerBlue
    Me.SplitContainer3.Panel1.Controls.Add(Me.lblInvoNumb)
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label6)
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label5)
    Me.SplitContainer3.Panel1.Controls.Add(Me.lblReceDate)
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label4)
    Me.SplitContainer3.Panel1.Controls.Add(Me.lblReceNumb)
    Me.SplitContainer3.Panel1.Controls.Add(Me.Label2)
    Me.SplitContainer3.Panel1.Controls.Add(Me.lblEmplName)
    '
    'SplitContainer3.Panel2
    '
    Me.SplitContainer3.Panel2.Controls.Add(Me.dtgReceList)
    Me.SplitContainer3.Size = New System.Drawing.Size(691, 537)
    Me.SplitContainer3.SplitterDistance = 34
    Me.SplitContainer3.TabIndex = 0
    '
    'lblInvoNumb
    '
    Me.lblInvoNumb.AutoSize = True
    Me.lblInvoNumb.ForeColor = System.Drawing.Color.Navy
    Me.lblInvoNumb.Location = New System.Drawing.Point(406, 9)
    Me.lblInvoNumb.Name = "lblInvoNumb"
    Me.lblInvoNumb.Size = New System.Drawing.Size(20, 16)
    Me.lblInvoNumb.TabIndex = 13
    Me.lblInvoNumb.Text = "..."
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(305, 9)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(95, 16)
    Me.Label6.TabIndex = 12
    Me.Label6.Text = "เลขที่ใบส่งสินค้า"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(490, 9)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(30, 16)
    Me.Label5.TabIndex = 4
    Me.Label5.Text = "ผู้รับ"
    '
    'lblReceDate
    '
    Me.lblReceDate.ForeColor = System.Drawing.Color.Navy
    Me.lblReceDate.Location = New System.Drawing.Point(218, 9)
    Me.lblReceDate.Name = "lblReceDate"
    Me.lblReceDate.Size = New System.Drawing.Size(81, 19)
    Me.lblReceDate.TabIndex = 3
    Me.lblReceDate.Text = "..."
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(181, 9)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(31, 16)
    Me.Label4.TabIndex = 2
    Me.Label4.Text = "วันที่"
    '
    'lblReceNumb
    '
    Me.lblReceNumb.ForeColor = System.Drawing.Color.Navy
    Me.lblReceNumb.Location = New System.Drawing.Point(85, 9)
    Me.lblReceNumb.Name = "lblReceNumb"
    Me.lblReceNumb.Size = New System.Drawing.Size(90, 19)
    Me.lblReceNumb.TabIndex = 1
    Me.lblReceNumb.Text = "..."
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(14, 9)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(65, 16)
    Me.Label2.TabIndex = 0
    Me.Label2.Text = "เลขที่ใบรับ"
    '
    'lblEmplName
    '
    Me.lblEmplName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblEmplName.AutoSize = True
    Me.lblEmplName.ForeColor = System.Drawing.Color.Navy
    Me.lblEmplName.Location = New System.Drawing.Point(526, 9)
    Me.lblEmplName.Name = "lblEmplName"
    Me.lblEmplName.Size = New System.Drawing.Size(20, 16)
    Me.lblEmplName.TabIndex = 11
    Me.lblEmplName.Text = "..."
    '
    'dtgReceList
    '
    Me.dtgReceList.AllowUserToAddRows = False
    Me.dtgReceList.AllowUserToDeleteRows = False
    Me.dtgReceList.AllowUserToResizeColumns = False
    Me.dtgReceList.AllowUserToResizeRows = False
    Me.dtgReceList.BackgroundColor = System.Drawing.Color.AliceBlue
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgReceList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
    Me.dtgReceList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.GoodName, Me.GoodAmou, Me.UnitDesc})
    Me.dtgReceList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgReceList.Location = New System.Drawing.Point(0, 0)
    Me.dtgReceList.Name = "dtgReceList"
    Me.dtgReceList.ReadOnly = True
    Me.dtgReceList.RowHeadersVisible = False
    Me.dtgReceList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.CornflowerBlue
    Me.dtgReceList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgReceList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.dtgReceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgReceList.Size = New System.Drawing.Size(691, 499)
    Me.dtgReceList.TabIndex = 1
    '
    'Item
    '
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    Me.Item.DefaultCellStyle = DataGridViewCellStyle5
    Me.Item.HeaderText = ""
    Me.Item.Name = "Item"
    Me.Item.ReadOnly = True
    Me.Item.Width = 35
    '
    'GoodName
    '
    Me.GoodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.GoodName.HeaderText = "รายการ"
    Me.GoodName.Name = "GoodName"
    Me.GoodName.ReadOnly = True
    '
    'GoodAmou
    '
    DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    Me.GoodAmou.DefaultCellStyle = DataGridViewCellStyle6
    Me.GoodAmou.HeaderText = "จำนวน"
    Me.GoodAmou.Name = "GoodAmou"
    Me.GoodAmou.ReadOnly = True
    Me.GoodAmou.Width = 70
    '
    'UnitDesc
    '
    Me.UnitDesc.HeaderText = "หน่วย"
    Me.UnitDesc.Name = "UnitDesc"
    Me.UnitDesc.ReadOnly = True
    '
    'frmGoodReceCheck
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1075, 537)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmGoodReceCheck"
    Me.Tag = "f2d"
    Me.Text = "ตรวจสอบการรับสินค้า"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    Me.SplitContainer2.Panel1.ResumeLayout(False)
    Me.SplitContainer2.Panel1.PerformLayout()
    Me.SplitContainer2.Panel2.ResumeLayout(False)
    Me.SplitContainer2.ResumeLayout(False)
    CType(Me.dtgHistRece, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer3.Panel1.ResumeLayout(False)
    Me.SplitContainer3.Panel1.PerformLayout()
    Me.SplitContainer3.Panel2.ResumeLayout(False)
    Me.SplitContainer3.ResumeLayout(False)
    CType(Me.dtgReceList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents dtgHistRece As System.Windows.Forms.DataGridView
  Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
  Friend WithEvents dtpRece As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents lblReceDate As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents lblReceNumb As System.Windows.Forms.Label
  Friend WithEvents dtgReceList As System.Windows.Forms.DataGridView
  Friend WithEvents lblEmplName As System.Windows.Forms.Label
  Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents UnitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents lblInvoNumb As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents receDate As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents receNumb As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents invoNumb As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents EmplName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents ReceDay As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents orderNumb As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
