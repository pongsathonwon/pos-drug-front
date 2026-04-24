<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalMiniStock
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
    Me.btnCal = New System.Windows.Forms.Button
    Me.pgb1 = New System.Windows.Forms.ProgressBar
    Me.btnCancel = New System.Windows.Forms.Button
    Me.lblInformation = New System.Windows.Forms.Label
    Me.lblWarning = New System.Windows.Forms.Label
    Me.SuspendLayout()
    '
    'btnCal
    '
    Me.btnCal.Location = New System.Drawing.Point(105, 139)
    Me.btnCal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnCal.Name = "btnCal"
    Me.btnCal.Size = New System.Drawing.Size(87, 28)
    Me.btnCal.TabIndex = 0
    Me.btnCal.Text = "เริ่มคำนวณ"
    Me.btnCal.UseVisualStyleBackColor = True
    '
    'pgb1
    '
    Me.pgb1.Location = New System.Drawing.Point(14, 94)
    Me.pgb1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.pgb1.Name = "pgb1"
    Me.pgb1.Size = New System.Drawing.Size(265, 28)
    Me.pgb1.TabIndex = 1
    Me.pgb1.Visible = False
    '
    'btnCancel
    '
    Me.btnCancel.Location = New System.Drawing.Point(105, 139)
    Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(87, 28)
    Me.btnCancel.TabIndex = 2
    Me.btnCancel.Text = "ยกเลิก"
    Me.btnCancel.UseVisualStyleBackColor = True
    Me.btnCancel.Visible = False
    '
    'lblInformation
    '
    Me.lblInformation.Location = New System.Drawing.Point(37, 27)
    Me.lblInformation.Name = "lblInformation"
    Me.lblInformation.Size = New System.Drawing.Size(223, 63)
    Me.lblInformation.TabIndex = 3
    Me.lblInformation.Text = "การคำนวณจุดสั่งซื้อ จะคำนวณจากยอดขายสินค้าแต่ละชนิดต่อเดือน ย้อนหลัง 30 วัน นับจา" & _
        "กปัจจุบัน"
    '
    'lblWarning
    '
    Me.lblWarning.ForeColor = System.Drawing.Color.DarkRed
    Me.lblWarning.Location = New System.Drawing.Point(37, 27)
    Me.lblWarning.Name = "lblWarning"
    Me.lblWarning.Size = New System.Drawing.Size(208, 36)
    Me.lblWarning.TabIndex = 17
    Me.lblWarning.Text = "กรุณาอย่าปิดหน้าต่างหรือโปรแกรม จนกว่าการคำนวณจะแล้วเสร็จ !!"
    Me.lblWarning.Visible = False
    '
    'frmCalMiniStock
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(293, 194)
    Me.Controls.Add(Me.pgb1)
    Me.Controls.Add(Me.btnCal)
    Me.Controls.Add(Me.btnCancel)
    Me.Controls.Add(Me.lblInformation)
    Me.Controls.Add(Me.lblWarning)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmCalMiniStock"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Tag = "f2g"
    Me.Text = "คำนวณจุดสั่งซื้อ"
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents btnCal As System.Windows.Forms.Button
  Friend WithEvents pgb1 As System.Windows.Forms.ProgressBar
  Friend WithEvents btnCancel As System.Windows.Forms.Button
  Friend WithEvents lblInformation As System.Windows.Forms.Label
  Friend WithEvents lblWarning As System.Windows.Forms.Label
End Class
