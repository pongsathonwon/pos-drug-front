<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRpMonthGoodUse
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
    Me.dtpSale = New System.Windows.Forms.DateTimePicker
    Me.Label1 = New System.Windows.Forms.Label
    Me.cboIndiDesc = New System.Windows.Forms.ComboBox
    Me.cboIndiCode = New System.Windows.Forms.ComboBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtMonthUse = New System.Windows.Forms.TextBox
    Me.btnShow = New System.Windows.Forms.Button
    Me.txtCompName = New System.Windows.Forms.TextBox
    Me.txtGoodName = New System.Windows.Forms.TextBox
    Me.Label6 = New System.Windows.Forms.Label
    Me.cboSortDirection = New System.Windows.Forms.ComboBox
    Me.Label9 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.btnCompSearch = New System.Windows.Forms.Button
    Me.btnGoodSearch = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'dtpSale
    '
    Me.dtpSale.Location = New System.Drawing.Point(212, 31)
    Me.dtpSale.Name = "dtpSale"
    Me.dtpSale.Size = New System.Drawing.Size(183, 23)
    Me.dtpSale.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(59, 36)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(46, 16)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "ณ วันที่"
    '
    'cboIndiDesc
    '
    Me.cboIndiDesc.BackColor = System.Drawing.Color.Honeydew
    Me.cboIndiDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboIndiDesc.FormattingEnabled = True
    Me.cboIndiDesc.Location = New System.Drawing.Point(212, 120)
    Me.cboIndiDesc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.cboIndiDesc.Name = "cboIndiDesc"
    Me.cboIndiDesc.Size = New System.Drawing.Size(183, 24)
    Me.cboIndiDesc.TabIndex = 4
    '
    'cboIndiCode
    '
    Me.cboIndiCode.BackColor = System.Drawing.Color.Honeydew
    Me.cboIndiCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboIndiCode.FormattingEnabled = True
    Me.cboIndiCode.Location = New System.Drawing.Point(403, 120)
    Me.cboIndiCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.cboIndiCode.Name = "cboIndiCode"
    Me.cboIndiCode.Size = New System.Drawing.Size(27, 24)
    Me.cboIndiCode.TabIndex = 57
    Me.cboIndiCode.Visible = False
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(59, 63)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(147, 16)
    Me.Label2.TabIndex = 58
    Me.Label2.Text = "จำนวนเดือนการใช้มากกว่า"
    '
    'txtMonthUse
    '
    Me.txtMonthUse.Location = New System.Drawing.Point(212, 60)
    Me.txtMonthUse.Name = "txtMonthUse"
    Me.txtMonthUse.Size = New System.Drawing.Size(183, 23)
    Me.txtMonthUse.TabIndex = 2
    Me.txtMonthUse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(191, 251)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(125, 25)
    Me.btnShow.TabIndex = 0
    Me.btnShow.Text = "แสดงรายงาน"
    Me.btnShow.UseVisualStyleBackColor = True
    '
    'txtCompName
    '
    Me.txtCompName.BackColor = System.Drawing.Color.White
    Me.txtCompName.Location = New System.Drawing.Point(212, 152)
    Me.txtCompName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtCompName.Name = "txtCompName"
    Me.txtCompName.Size = New System.Drawing.Size(183, 23)
    Me.txtCompName.TabIndex = 5
    Me.txtCompName.TabStop = False
    '
    'txtGoodName
    '
    Me.txtGoodName.BackColor = System.Drawing.Color.White
    Me.txtGoodName.Location = New System.Drawing.Point(212, 183)
    Me.txtGoodName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtGoodName.Name = "txtGoodName"
    Me.txtGoodName.Size = New System.Drawing.Size(183, 23)
    Me.txtGoodName.TabIndex = 6
    Me.txtGoodName.TabStop = False
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(59, 183)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(71, 16)
    Me.Label6.TabIndex = 68
    Me.Label6.Text = "เฉพาะสินค้า"
    '
    'cboSortDirection
    '
    Me.cboSortDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboSortDirection.FormattingEnabled = True
    Me.cboSortDirection.Location = New System.Drawing.Point(212, 89)
    Me.cboSortDirection.Name = "cboSortDirection"
    Me.cboSortDirection.Size = New System.Drawing.Size(183, 24)
    Me.cboSortDirection.TabIndex = 3
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(59, 92)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(53, 16)
    Me.Label9.TabIndex = 70
    Me.Label9.Text = "เรียงจาก"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(59, 155)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(83, 16)
    Me.Label3.TabIndex = 72
    Me.Label3.Text = "ซัพพลายเออร์"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(59, 123)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(90, 16)
    Me.Label4.TabIndex = 73
    Me.Label4.Text = "สรรพคุณการใช้"
    '
    'btnCompSearch
    '
    Me.btnCompSearch.Image = Global.DrugFront.My.Resources.Resources.search16
    Me.btnCompSearch.Location = New System.Drawing.Point(400, 152)
    Me.btnCompSearch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnCompSearch.Name = "btnCompSearch"
    Me.btnCompSearch.Size = New System.Drawing.Size(30, 23)
    Me.btnCompSearch.TabIndex = 7
    Me.btnCompSearch.TabStop = False
    Me.btnCompSearch.UseVisualStyleBackColor = True
    '
    'btnGoodSearch
    '
    Me.btnGoodSearch.Image = Global.DrugFront.My.Resources.Resources.search16
    Me.btnGoodSearch.Location = New System.Drawing.Point(400, 183)
    Me.btnGoodSearch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnGoodSearch.Name = "btnGoodSearch"
    Me.btnGoodSearch.Size = New System.Drawing.Size(30, 23)
    Me.btnGoodSearch.TabIndex = 8
    Me.btnGoodSearch.TabStop = False
    Me.btnGoodSearch.UseVisualStyleBackColor = True
    '
    'frmRpMonthGoodUse
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.Plum
    Me.ClientSize = New System.Drawing.Size(494, 302)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.cboIndiCode)
    Me.Controls.Add(Me.btnCompSearch)
    Me.Controls.Add(Me.txtCompName)
    Me.Controls.Add(Me.cboIndiDesc)
    Me.Controls.Add(Me.cboSortDirection)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.btnGoodSearch)
    Me.Controls.Add(Me.txtGoodName)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.btnShow)
    Me.Controls.Add(Me.txtMonthUse)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.dtpSale)
    Me.Controls.Add(Me.Label1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmRpMonthGoodUse"
    Me.Tag = "f3p"
    Me.Text = "รายงานจำนวนเดือนการใช้"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents dtpSale As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents cboIndiDesc As System.Windows.Forms.ComboBox
  Friend WithEvents cboIndiCode As System.Windows.Forms.ComboBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtMonthUse As System.Windows.Forms.TextBox
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents btnCompSearch As System.Windows.Forms.Button
  Friend WithEvents txtCompName As System.Windows.Forms.TextBox
  Friend WithEvents btnGoodSearch As System.Windows.Forms.Button
  Friend WithEvents txtGoodName As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents cboSortDirection As System.Windows.Forms.ComboBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
