<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRpHistReturn
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
    Me.dtpFrom = New System.Windows.Forms.DateTimePicker
    Me.dtpTo = New System.Windows.Forms.DateTimePicker
    Me.Label2 = New System.Windows.Forms.Label
    Me.btnShow = New System.Windows.Forms.Button
    Me.btnCancel = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(70, 45)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(61, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "ตั้งแต่วันที่"
    '
    'dtpFrom
    '
    Me.dtpFrom.Location = New System.Drawing.Point(137, 40)
    Me.dtpFrom.Name = "dtpFrom"
    Me.dtpFrom.Size = New System.Drawing.Size(183, 23)
    Me.dtpFrom.TabIndex = 1
    '
    'dtpTo
    '
    Me.dtpTo.Location = New System.Drawing.Point(137, 69)
    Me.dtpTo.Name = "dtpTo"
    Me.dtpTo.Size = New System.Drawing.Size(183, 23)
    Me.dtpTo.TabIndex = 2
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(70, 74)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(45, 16)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "ถึงวันที่"
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(164, 153)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(117, 30)
    Me.btnShow.TabIndex = 0
    Me.btnShow.Text = "แสดงรายงาน"
    Me.btnShow.UseVisualStyleBackColor = True
    '
    'btnCancel
    '
    Me.btnCancel.Location = New System.Drawing.Point(345, 153)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(82, 23)
    Me.btnCancel.TabIndex = 5
    Me.btnCancel.Text = "ยกเลิก"
    Me.btnCancel.UseVisualStyleBackColor = True
    Me.btnCancel.Visible = False
    '
    'frmRpHistReturn
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.Plum
    Me.ClientSize = New System.Drawing.Size(439, 208)
    Me.Controls.Add(Me.btnShow)
    Me.Controls.Add(Me.dtpTo)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.dtpFrom)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.btnCancel)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmRpHistReturn"
    Me.Tag = "f3j"
    Me.Text = "รายงานการส่งคืนสินค้า"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
