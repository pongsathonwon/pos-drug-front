<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRpPushConclude
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
    Me.dtpFrom = New System.Windows.Forms.DateTimePicker
    Me.dtpTo = New System.Windows.Forms.DateTimePicker
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.btnShow = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'dtpFrom
    '
    Me.dtpFrom.Location = New System.Drawing.Point(137, 40)
    Me.dtpFrom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dtpFrom.Name = "dtpFrom"
    Me.dtpFrom.Size = New System.Drawing.Size(183, 23)
    Me.dtpFrom.TabIndex = 1
    '
    'dtpTo
    '
    Me.dtpTo.Location = New System.Drawing.Point(137, 71)
    Me.dtpTo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dtpTo.Name = "dtpTo"
    Me.dtpTo.Size = New System.Drawing.Size(183, 23)
    Me.dtpTo.TabIndex = 2
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(70, 45)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(61, 16)
    Me.Label2.TabIndex = 23
    Me.Label2.Text = "ตั้งแต่วันที่"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(70, 76)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(45, 16)
    Me.Label3.TabIndex = 24
    Me.Label3.Text = "ถึงวันที่"
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(165, 146)
    Me.btnShow.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(117, 25)
    Me.btnShow.TabIndex = 0
    Me.btnShow.Text = "แสดงรายงาน"
    Me.btnShow.UseVisualStyleBackColor = True
    '
    'frmRpPushConclude
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.Lavender
    Me.ClientSize = New System.Drawing.Size(445, 205)
    Me.Controls.Add(Me.btnShow)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.dtpTo)
    Me.Controls.Add(Me.dtpFrom)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmRpPushConclude"
    Me.Tag = "f3k"
    Me.Text = "รายงานสรุปยอดขายสินค้า PP เทียบเป้าหมาย"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents btnShow As System.Windows.Forms.Button
End Class
