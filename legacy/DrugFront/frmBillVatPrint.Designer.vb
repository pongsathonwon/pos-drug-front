<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBillVatPrint
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
    Me.btnCancel = New System.Windows.Forms.Button
    Me.GroupBox2 = New System.Windows.Forms.GroupBox
    Me.radTaxTypeMisc = New System.Windows.Forms.RadioButton
    Me.Label4 = New System.Windows.Forms.Label
    Me.txtTaxBranch = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label30 = New System.Windows.Forms.Label
    Me.radTaxTypePassport = New System.Windows.Forms.RadioButton
    Me.txtTaxID = New System.Windows.Forms.TextBox
    Me.txtPhone = New System.Windows.Forms.TextBox
    Me.radTaxTypeGen = New System.Windows.Forms.RadioButton
    Me.Label2 = New System.Windows.Forms.Label
    Me.radTaxTypeLegal = New System.Windows.Forms.RadioButton
    Me.txtEmail = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.txtTaxInvoiceNumb = New System.Windows.Forms.TextBox
    Me.lblTaxInvoiceNumb = New System.Windows.Forms.Label
    Me.btnSave = New System.Windows.Forms.Button
    Me.txtTaxAddr = New System.Windows.Forms.TextBox
    Me.Label35 = New System.Windows.Forms.Label
    Me.txtTaxName = New System.Windows.Forms.TextBox
    Me.Label34 = New System.Windows.Forms.Label
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'btnCancel
    '
    Me.btnCancel.Location = New System.Drawing.Point(200, 480)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(75, 25)
    Me.btnCancel.TabIndex = 1
    Me.btnCancel.Text = "ยกเลิก"
    Me.btnCancel.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.radTaxTypeMisc)
    Me.GroupBox2.Controls.Add(Me.Label4)
    Me.GroupBox2.Controls.Add(Me.txtTaxBranch)
    Me.GroupBox2.Controls.Add(Me.Label3)
    Me.GroupBox2.Controls.Add(Me.Label30)
    Me.GroupBox2.Controls.Add(Me.radTaxTypePassport)
    Me.GroupBox2.Controls.Add(Me.txtTaxID)
    Me.GroupBox2.Controls.Add(Me.txtPhone)
    Me.GroupBox2.Controls.Add(Me.radTaxTypeGen)
    Me.GroupBox2.Controls.Add(Me.Label2)
    Me.GroupBox2.Controls.Add(Me.radTaxTypeLegal)
    Me.GroupBox2.Controls.Add(Me.txtEmail)
    Me.GroupBox2.Controls.Add(Me.Label1)
    Me.GroupBox2.Controls.Add(Me.txtTaxInvoiceNumb)
    Me.GroupBox2.Controls.Add(Me.lblTaxInvoiceNumb)
    Me.GroupBox2.Controls.Add(Me.btnCancel)
    Me.GroupBox2.Controls.Add(Me.btnSave)
    Me.GroupBox2.Controls.Add(Me.txtTaxAddr)
    Me.GroupBox2.Controls.Add(Me.Label35)
    Me.GroupBox2.Controls.Add(Me.txtTaxName)
    Me.GroupBox2.Controls.Add(Me.Label34)
    Me.GroupBox2.Location = New System.Drawing.Point(8, 8)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(368, 528)
    Me.GroupBox2.TabIndex = 1
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "ข้อมูลใบกำกับภาษี ผู้ซื้อ"
    '
    'radTaxTypeMisc
    '
    Me.radTaxTypeMisc.AutoSize = True
    Me.radTaxTypeMisc.Location = New System.Drawing.Point(302, 98)
    Me.radTaxTypeMisc.Name = "radTaxTypeMisc"
    Me.radTaxTypeMisc.Size = New System.Drawing.Size(48, 20)
    Me.radTaxTypeMisc.TabIndex = 5
    Me.radTaxTypeMisc.TabStop = True
    Me.radTaxTypeMisc.Tag = "1"
    Me.radTaxTypeMisc.Text = "อื่นๆ"
    Me.radTaxTypeMisc.UseVisualStyleBackColor = True
    Me.radTaxTypeMisc.Visible = False
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Label4.Location = New System.Drawing.Point(14, 326)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(165, 16)
    Me.Label4.TabIndex = 82
    Me.Label4.Text = "เลขที่สาขาของลูกค้านิติบุคคล"
    '
    'txtTaxBranch
    '
    Me.txtTaxBranch.Location = New System.Drawing.Point(17, 344)
    Me.txtTaxBranch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.txtTaxBranch.MaxLength = 5
    Me.txtTaxBranch.Name = "txtTaxBranch"
    Me.txtTaxBranch.Size = New System.Drawing.Size(334, 23)
    Me.txtTaxBranch.TabIndex = 9
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Label3.Location = New System.Drawing.Point(14, 77)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(89, 16)
    Me.Label3.TabIndex = 80
    Me.Label3.Text = "ประเภทธุรกิจ *"
    '
    'Label30
    '
    Me.Label30.AutoSize = True
    Me.Label30.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Label30.Location = New System.Drawing.Point(14, 127)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(167, 16)
    Me.Label30.TabIndex = 69
    Me.Label30.Text = "เลขประจำตัวผู้เสียภาษีอากร *"
    '
    'radTaxTypePassport
    '
    Me.radTaxTypePassport.AutoSize = True
    Me.radTaxTypePassport.Location = New System.Drawing.Point(191, 98)
    Me.radTaxTypePassport.Name = "radTaxTypePassport"
    Me.radTaxTypePassport.Size = New System.Drawing.Size(105, 20)
    Me.radTaxTypePassport.TabIndex = 4
    Me.radTaxTypePassport.TabStop = True
    Me.radTaxTypePassport.Tag = "4"
    Me.radTaxTypePassport.Text = "หนังสือเดินทาง"
    Me.radTaxTypePassport.UseVisualStyleBackColor = True
    '
    'txtTaxID
    '
    Me.txtTaxID.Location = New System.Drawing.Point(17, 145)
    Me.txtTaxID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.txtTaxID.MaxLength = 20
    Me.txtTaxID.Name = "txtTaxID"
    Me.txtTaxID.Size = New System.Drawing.Size(334, 23)
    Me.txtTaxID.TabIndex = 6
    '
    'txtPhone
    '
    Me.txtPhone.Location = New System.Drawing.Point(17, 430)
    Me.txtPhone.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.txtPhone.MaxLength = 30
    Me.txtPhone.Name = "txtPhone"
    Me.txtPhone.Size = New System.Drawing.Size(334, 23)
    Me.txtPhone.TabIndex = 11
    '
    'radTaxTypeGen
    '
    Me.radTaxTypeGen.AutoSize = True
    Me.radTaxTypeGen.Location = New System.Drawing.Point(97, 98)
    Me.radTaxTypeGen.Name = "radTaxTypeGen"
    Me.radTaxTypeGen.Size = New System.Drawing.Size(88, 20)
    Me.radTaxTypeGen.TabIndex = 3
    Me.radTaxTypeGen.TabStop = True
    Me.radTaxTypeGen.Tag = "3"
    Me.radTaxTypeGen.Text = "บุคคลทั่วไป"
    Me.radTaxTypeGen.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Label2.Location = New System.Drawing.Point(14, 412)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(117, 16)
    Me.Label2.TabIndex = 77
    Me.Label2.Text = "หมายเลขโทรศัพท์ *"
    '
    'radTaxTypeLegal
    '
    Me.radTaxTypeLegal.AutoSize = True
    Me.radTaxTypeLegal.Location = New System.Drawing.Point(17, 98)
    Me.radTaxTypeLegal.Name = "radTaxTypeLegal"
    Me.radTaxTypeLegal.Size = New System.Drawing.Size(74, 20)
    Me.radTaxTypeLegal.TabIndex = 2
    Me.radTaxTypeLegal.TabStop = True
    Me.radTaxTypeLegal.Tag = "2"
    Me.radTaxTypeLegal.Text = "นิติบุคคล"
    Me.radTaxTypeLegal.UseVisualStyleBackColor = True
    '
    'txtEmail
    '
    Me.txtEmail.Location = New System.Drawing.Point(17, 387)
    Me.txtEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.txtEmail.MaxLength = 50
    Me.txtEmail.Name = "txtEmail"
    Me.txtEmail.Size = New System.Drawing.Size(334, 23)
    Me.txtEmail.TabIndex = 10
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Label1.Location = New System.Drawing.Point(14, 369)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(48, 16)
    Me.Label1.TabIndex = 75
    Me.Label1.Text = "อีเมล์ *"
    '
    'txtTaxInvoiceNumb
    '
    Me.txtTaxInvoiceNumb.Location = New System.Drawing.Point(17, 48)
    Me.txtTaxInvoiceNumb.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.txtTaxInvoiceNumb.MaxLength = 100
    Me.txtTaxInvoiceNumb.Name = "txtTaxInvoiceNumb"
    Me.txtTaxInvoiceNumb.ReadOnly = True
    Me.txtTaxInvoiceNumb.Size = New System.Drawing.Size(334, 23)
    Me.txtTaxInvoiceNumb.TabIndex = 73
    Me.txtTaxInvoiceNumb.TabStop = False
    '
    'lblTaxInvoiceNumb
    '
    Me.lblTaxInvoiceNumb.AutoSize = True
    Me.lblTaxInvoiceNumb.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblTaxInvoiceNumb.Location = New System.Drawing.Point(14, 30)
    Me.lblTaxInvoiceNumb.Name = "lblTaxInvoiceNumb"
    Me.lblTaxInvoiceNumb.Size = New System.Drawing.Size(105, 16)
    Me.lblTaxInvoiceNumb.TabIndex = 72
    Me.lblTaxInvoiceNumb.Text = "เลขที่ใบกำกับภาษี"
    '
    'btnSave
    '
    Me.btnSave.Location = New System.Drawing.Point(89, 480)
    Me.btnSave.Name = "btnSave"
    Me.btnSave.Size = New System.Drawing.Size(75, 25)
    Me.btnSave.TabIndex = 0
    Me.btnSave.Text = "บันทึก"
    Me.btnSave.UseVisualStyleBackColor = True
    '
    'txtTaxAddr
    '
    Me.txtTaxAddr.Location = New System.Drawing.Point(17, 240)
    Me.txtTaxAddr.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.txtTaxAddr.MaxLength = 200
    Me.txtTaxAddr.Multiline = True
    Me.txtTaxAddr.Name = "txtTaxAddr"
    Me.txtTaxAddr.Size = New System.Drawing.Size(334, 84)
    Me.txtTaxAddr.TabIndex = 8
    '
    'Label35
    '
    Me.Label35.AutoSize = True
    Me.Label35.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Label35.Location = New System.Drawing.Point(14, 222)
    Me.Label35.Name = "Label35"
    Me.Label35.Size = New System.Drawing.Size(45, 16)
    Me.Label35.TabIndex = 73
    Me.Label35.Text = "ที่อยู่ *"
    '
    'txtTaxName
    '
    Me.txtTaxName.Location = New System.Drawing.Point(17, 197)
    Me.txtTaxName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.txtTaxName.MaxLength = 100
    Me.txtTaxName.Name = "txtTaxName"
    Me.txtTaxName.Size = New System.Drawing.Size(334, 23)
    Me.txtTaxName.TabIndex = 7
    '
    'Label34
    '
    Me.Label34.AutoSize = True
    Me.Label34.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Label34.Location = New System.Drawing.Point(14, 179)
    Me.Label34.Name = "Label34"
    Me.Label34.Size = New System.Drawing.Size(36, 16)
    Me.Label34.TabIndex = 71
    Me.Label34.Text = "ชื่อ *"
    '
    'frmBillVatPrint
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(191, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(386, 548)
    Me.Controls.Add(Me.GroupBox2)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmBillVatPrint"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "บันทึกข้อมูลใบกำกับภาษี"
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents btnCancel As System.Windows.Forms.Button
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents btnSave As System.Windows.Forms.Button
  Friend WithEvents txtTaxAddr As System.Windows.Forms.TextBox
  Friend WithEvents Label35 As System.Windows.Forms.Label
  Friend WithEvents txtTaxName As System.Windows.Forms.TextBox
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents txtTaxID As System.Windows.Forms.TextBox
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents lblTaxInvoiceNumb As System.Windows.Forms.Label
  Friend WithEvents txtTaxInvoiceNumb As System.Windows.Forms.TextBox
  Friend WithEvents txtPhone As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtEmail As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents radTaxTypeMisc As System.Windows.Forms.RadioButton
  Friend WithEvents radTaxTypePassport As System.Windows.Forms.RadioButton
  Friend WithEvents radTaxTypeGen As System.Windows.Forms.RadioButton
  Friend WithEvents radTaxTypeLegal As System.Windows.Forms.RadioButton
  Friend WithEvents txtTaxBranch As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
