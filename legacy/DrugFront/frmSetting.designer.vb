<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetting
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
    Me.Label1 = New System.Windows.Forms.Label
    Me.cboReportPrinterName = New System.Windows.Forms.ComboBox
    Me.btnSave = New System.Windows.Forms.Button
    Me.TabControl1 = New System.Windows.Forms.TabControl
    Me.tabPOS = New System.Windows.Forms.TabPage
    Me.nudPOSNo = New System.Windows.Forms.NumericUpDown
    Me.txtPOSNumber = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.tabPrinter = New System.Windows.Forms.TabPage
    Me.TabControl1.SuspendLayout()
    Me.tabPOS.SuspendLayout()
    CType(Me.nudPOSNo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.tabPrinter.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Location = New System.Drawing.Point(50, 46)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(106, 16)
    Me.Label1.TabIndex = 26
    Me.Label1.Text = "เครื่องพิมพ์รายงาน"
    '
    'cboReportPrinterName
    '
    Me.cboReportPrinterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboReportPrinterName.FormattingEnabled = True
    Me.cboReportPrinterName.Location = New System.Drawing.Point(180, 43)
    Me.cboReportPrinterName.Name = "cboReportPrinterName"
    Me.cboReportPrinterName.Size = New System.Drawing.Size(263, 24)
    Me.cboReportPrinterName.TabIndex = 25
    '
    'btnSave
    '
    Me.btnSave.Location = New System.Drawing.Point(222, 221)
    Me.btnSave.Name = "btnSave"
    Me.btnSave.Size = New System.Drawing.Size(75, 26)
    Me.btnSave.TabIndex = 0
    Me.btnSave.Text = "บันทึก"
    Me.btnSave.UseVisualStyleBackColor = True
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.tabPOS)
    Me.TabControl1.Controls.Add(Me.tabPrinter)
    Me.TabControl1.Location = New System.Drawing.Point(12, 12)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(496, 203)
    Me.TabControl1.TabIndex = 36
    '
    'tabPOS
    '
    Me.tabPOS.Controls.Add(Me.nudPOSNo)
    Me.tabPOS.Controls.Add(Me.txtPOSNumber)
    Me.tabPOS.Controls.Add(Me.Label3)
    Me.tabPOS.Controls.Add(Me.Label2)
    Me.tabPOS.Location = New System.Drawing.Point(4, 25)
    Me.tabPOS.Name = "tabPOS"
    Me.tabPOS.Padding = New System.Windows.Forms.Padding(3)
    Me.tabPOS.Size = New System.Drawing.Size(488, 174)
    Me.tabPOS.TabIndex = 3
    Me.tabPOS.Text = "เครื่องบันทึกเงินสด"
    Me.tabPOS.UseVisualStyleBackColor = True
    '
    'nudPOSNo
    '
    Me.nudPOSNo.Location = New System.Drawing.Point(206, 47)
    Me.nudPOSNo.Maximum = New Decimal(New Integer() {9, 0, 0, 0})
    Me.nudPOSNo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.nudPOSNo.Name = "nudPOSNo"
    Me.nudPOSNo.Size = New System.Drawing.Size(45, 23)
    Me.nudPOSNo.TabIndex = 0
    Me.nudPOSNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    Me.nudPOSNo.Value = New Decimal(New Integer() {1, 0, 0, 0})
    '
    'txtPOSNumber
    '
    Me.txtPOSNumber.Location = New System.Drawing.Point(206, 75)
    Me.txtPOSNumber.Name = "txtPOSNumber"
    Me.txtPOSNumber.Size = New System.Drawing.Size(188, 23)
    Me.txtPOSNumber.TabIndex = 1
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(85, 78)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(115, 16)
    Me.Label3.TabIndex = 2
    Me.Label3.Text = "เลขรหัสประจำเครื่อง"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(85, 49)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(90, 16)
    Me.Label2.TabIndex = 0
    Me.Label2.Text = "เลขลำดับเครื่อง"
    '
    'tabPrinter
    '
    Me.tabPrinter.BackColor = System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer))
    Me.tabPrinter.Controls.Add(Me.cboReportPrinterName)
    Me.tabPrinter.Controls.Add(Me.Label1)
    Me.tabPrinter.Location = New System.Drawing.Point(4, 25)
    Me.tabPrinter.Name = "tabPrinter"
    Me.tabPrinter.Size = New System.Drawing.Size(488, 174)
    Me.tabPrinter.TabIndex = 2
    Me.tabPrinter.Text = "เครื่องพิมพ์"
    Me.tabPrinter.UseVisualStyleBackColor = True
    '
    'frmSetting
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.LightCoral
    Me.ClientSize = New System.Drawing.Size(521, 257)
    Me.Controls.Add(Me.TabControl1)
    Me.Controls.Add(Me.btnSave)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmSetting"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Tag = "f1m"
    Me.Text = "ตั้งค่าระบบ"
    Me.TabControl1.ResumeLayout(False)
    Me.tabPOS.ResumeLayout(False)
    Me.tabPOS.PerformLayout()
    CType(Me.nudPOSNo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.tabPrinter.ResumeLayout(False)
    Me.tabPrinter.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents cboReportPrinterName As System.Windows.Forms.ComboBox
  Friend WithEvents btnSave As System.Windows.Forms.Button
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents tabPrinter As System.Windows.Forms.TabPage
  Friend WithEvents tabPOS As System.Windows.Forms.TabPage
  Friend WithEvents txtPOSNumber As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents nudPOSNo As System.Windows.Forms.NumericUpDown
End Class
