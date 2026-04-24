<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRpStockOnhand
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
    Me.cboCateCode = New System.Windows.Forms.ComboBox
    Me.cboCateDesc = New System.Windows.Forms.ComboBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.cboGroupCode = New System.Windows.Forms.ComboBox
    Me.cboTypeCode = New System.Windows.Forms.ComboBox
    Me.cboGroupDesc = New System.Windows.Forms.ComboBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.cboTypeDesc = New System.Windows.Forms.ComboBox
    Me.Label5 = New System.Windows.Forms.Label
    Me.btnShow = New System.Windows.Forms.Button
    Me.lblFromShelfNo = New System.Windows.Forms.Label
    Me.cboFromShelfNo = New System.Windows.Forms.ComboBox
    Me.cboToShelfNo = New System.Windows.Forms.ComboBox
    Me.lblToShelfNo = New System.Windows.Forms.Label
    Me.Label11 = New System.Windows.Forms.Label
    Me.btnGoodSearch = New System.Windows.Forms.Button
    Me.txtGoodName = New System.Windows.Forms.TextBox
    Me.chkOnlyHaveStock = New System.Windows.Forms.CheckBox
    Me.SuspendLayout()
    '
    'cboCateCode
    '
    Me.cboCateCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboCateCode.FormattingEnabled = True
    Me.cboCateCode.Location = New System.Drawing.Point(425, 45)
    Me.cboCateCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.cboCateCode.Name = "cboCateCode"
    Me.cboCateCode.Size = New System.Drawing.Size(28, 24)
    Me.cboCateCode.TabIndex = 17
    Me.cboCateCode.Visible = False
    '
    'cboCateDesc
    '
    Me.cboCateDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboCateDesc.FormattingEnabled = True
    Me.cboCateDesc.Location = New System.Drawing.Point(161, 45)
    Me.cboCateDesc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.cboCateDesc.Name = "cboCateDesc"
    Me.cboCateDesc.Size = New System.Drawing.Size(256, 24)
    Me.cboCateDesc.TabIndex = 2
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(74, 48)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(68, 16)
    Me.Label4.TabIndex = 15
    Me.Label4.Text = "หมวดสินค้า"
    '
    'cboGroupCode
    '
    Me.cboGroupCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboGroupCode.FormattingEnabled = True
    Me.cboGroupCode.Location = New System.Drawing.Point(423, 112)
    Me.cboGroupCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.cboGroupCode.Name = "cboGroupCode"
    Me.cboGroupCode.Size = New System.Drawing.Size(28, 24)
    Me.cboGroupCode.TabIndex = 14
    Me.cboGroupCode.Visible = False
    '
    'cboTypeCode
    '
    Me.cboTypeCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboTypeCode.FormattingEnabled = True
    Me.cboTypeCode.Location = New System.Drawing.Point(423, 79)
    Me.cboTypeCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.cboTypeCode.Name = "cboTypeCode"
    Me.cboTypeCode.Size = New System.Drawing.Size(28, 24)
    Me.cboTypeCode.TabIndex = 14
    Me.cboTypeCode.Visible = False
    '
    'cboGroupDesc
    '
    Me.cboGroupDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboGroupDesc.FormattingEnabled = True
    Me.cboGroupDesc.Location = New System.Drawing.Point(161, 111)
    Me.cboGroupDesc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.cboGroupDesc.Name = "cboGroupDesc"
    Me.cboGroupDesc.Size = New System.Drawing.Size(256, 24)
    Me.cboGroupDesc.TabIndex = 4
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(74, 115)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(62, 16)
    Me.Label2.TabIndex = 12
    Me.Label2.Text = "กลุ่มสินค้า"
    '
    'cboTypeDesc
    '
    Me.cboTypeDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboTypeDesc.FormattingEnabled = True
    Me.cboTypeDesc.Location = New System.Drawing.Point(161, 78)
    Me.cboTypeDesc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.cboTypeDesc.Name = "cboTypeDesc"
    Me.cboTypeDesc.Size = New System.Drawing.Size(256, 24)
    Me.cboTypeDesc.TabIndex = 3
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(74, 81)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(79, 16)
    Me.Label5.TabIndex = 10
    Me.Label5.Text = "ประเภทสินค้า"
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(223, 225)
    Me.btnShow.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(115, 28)
    Me.btnShow.TabIndex = 0
    Me.btnShow.Text = "แสดงรายงาน"
    Me.btnShow.UseVisualStyleBackColor = True
    '
    'lblFromShelfNo
    '
    Me.lblFromShelfNo.AutoSize = True
    Me.lblFromShelfNo.Location = New System.Drawing.Point(156, 498)
    Me.lblFromShelfNo.Name = "lblFromShelfNo"
    Me.lblFromShelfNo.Size = New System.Drawing.Size(72, 16)
    Me.lblFromShelfNo.TabIndex = 27
    Me.lblFromShelfNo.Text = "ตั้งแต่ชั้นวาง"
    '
    'cboFromShelfNo
    '
    Me.cboFromShelfNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboFromShelfNo.FormattingEnabled = True
    Me.cboFromShelfNo.Location = New System.Drawing.Point(243, 494)
    Me.cboFromShelfNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.cboFromShelfNo.Name = "cboFromShelfNo"
    Me.cboFromShelfNo.Size = New System.Drawing.Size(180, 24)
    Me.cboFromShelfNo.TabIndex = 29
    '
    'cboToShelfNo
    '
    Me.cboToShelfNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboToShelfNo.FormattingEnabled = True
    Me.cboToShelfNo.Location = New System.Drawing.Point(243, 527)
    Me.cboToShelfNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.cboToShelfNo.Name = "cboToShelfNo"
    Me.cboToShelfNo.Size = New System.Drawing.Size(180, 24)
    Me.cboToShelfNo.TabIndex = 31
    '
    'lblToShelfNo
    '
    Me.lblToShelfNo.AutoSize = True
    Me.lblToShelfNo.Location = New System.Drawing.Point(156, 531)
    Me.lblToShelfNo.Name = "lblToShelfNo"
    Me.lblToShelfNo.Size = New System.Drawing.Size(56, 16)
    Me.lblToShelfNo.TabIndex = 30
    Me.lblToShelfNo.Text = "ถึงชั้นวาง"
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(74, 324)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(54, 16)
    Me.Label11.TabIndex = 63
    Me.Label11.Text = "ชื่อสินค้า"
    Me.Label11.Visible = False
    '
    'btnGoodSearch
    '
    Me.btnGoodSearch.Location = New System.Drawing.Point(387, 317)
    Me.btnGoodSearch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnGoodSearch.Name = "btnGoodSearch"
    Me.btnGoodSearch.Size = New System.Drawing.Size(30, 23)
    Me.btnGoodSearch.TabIndex = 62
    Me.btnGoodSearch.UseVisualStyleBackColor = True
    Me.btnGoodSearch.Visible = False
    '
    'txtGoodName
    '
    Me.txtGoodName.BackColor = System.Drawing.Color.White
    Me.txtGoodName.Location = New System.Drawing.Point(161, 318)
    Me.txtGoodName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtGoodName.Name = "txtGoodName"
    Me.txtGoodName.Size = New System.Drawing.Size(220, 23)
    Me.txtGoodName.TabIndex = 5
    Me.txtGoodName.TabStop = False
    Me.txtGoodName.Visible = False
    '
    'chkOnlyHaveStock
    '
    Me.chkOnlyHaveStock.AutoSize = True
    Me.chkOnlyHaveStock.Location = New System.Drawing.Point(161, 142)
    Me.chkOnlyHaveStock.Name = "chkOnlyHaveStock"
    Me.chkOnlyHaveStock.Size = New System.Drawing.Size(224, 20)
    Me.chkOnlyHaveStock.TabIndex = 64
    Me.chkOnlyHaveStock.Text = "แสดงเฉพาะสินค้าคงเหลือที่มากกว่า 0"
    Me.chkOnlyHaveStock.UseVisualStyleBackColor = True
    '
    'frmRpStockOnhand
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(553, 288)
    Me.Controls.Add(Me.chkOnlyHaveStock)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.btnGoodSearch)
    Me.Controls.Add(Me.txtGoodName)
    Me.Controls.Add(Me.cboToShelfNo)
    Me.Controls.Add(Me.lblToShelfNo)
    Me.Controls.Add(Me.cboFromShelfNo)
    Me.Controls.Add(Me.lblFromShelfNo)
    Me.Controls.Add(Me.btnShow)
    Me.Controls.Add(Me.cboCateCode)
    Me.Controls.Add(Me.cboCateDesc)
    Me.Controls.Add(Me.cboGroupCode)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.cboTypeCode)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.cboTypeDesc)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.cboGroupDesc)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmRpStockOnhand"
    Me.Tag = "f3h2"
    Me.Text = "รายงานสต๊อคสินค้าคงเหลือ ตามหมวด, ประเภท, กลุ่ม"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents cboTypeDesc As System.Windows.Forms.ComboBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents cboGroupCode As System.Windows.Forms.ComboBox
  Friend WithEvents cboTypeCode As System.Windows.Forms.ComboBox
  Friend WithEvents cboGroupDesc As System.Windows.Forms.ComboBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents cboCateCode As System.Windows.Forms.ComboBox
  Friend WithEvents cboCateDesc As System.Windows.Forms.ComboBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents lblFromShelfNo As System.Windows.Forms.Label
  Friend WithEvents cboFromShelfNo As System.Windows.Forms.ComboBox
  Friend WithEvents cboToShelfNo As System.Windows.Forms.ComboBox
  Friend WithEvents lblToShelfNo As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents btnGoodSearch As System.Windows.Forms.Button
  Friend WithEvents txtGoodName As System.Windows.Forms.TextBox
  Friend WithEvents chkOnlyHaveStock As System.Windows.Forms.CheckBox
End Class
