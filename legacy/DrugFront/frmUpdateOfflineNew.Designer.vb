<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdateOfflineNew
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
    Me.btnCancel = New System.Windows.Forms.Button
    Me.btnUpdate = New System.Windows.Forms.Button
    Me.pgb1 = New System.Windows.Forms.ProgressBar
    Me.pgb2 = New System.Windows.Forms.ProgressBar
    Me.lblCount = New System.Windows.Forms.Label
    Me.lblComment = New System.Windows.Forms.Label
    Me.SuspendLayout()
    '
    'btnCancel
    '
    Me.btnCancel.Location = New System.Drawing.Point(159, 121)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(75, 23)
    Me.btnCancel.TabIndex = 1
    Me.btnCancel.Text = "ยกเลิก"
    Me.btnCancel.UseVisualStyleBackColor = True
    '
    'btnUpdate
    '
    Me.btnUpdate.Location = New System.Drawing.Point(159, 121)
    Me.btnUpdate.Name = "btnUpdate"
    Me.btnUpdate.Size = New System.Drawing.Size(75, 25)
    Me.btnUpdate.TabIndex = 0
    Me.btnUpdate.Text = "อัพเดต"
    Me.btnUpdate.UseVisualStyleBackColor = True
    '
    'pgb1
    '
    Me.pgb1.Location = New System.Drawing.Point(45, 57)
    Me.pgb1.Name = "pgb1"
    Me.pgb1.Size = New System.Drawing.Size(304, 21)
    Me.pgb1.TabIndex = 2
    '
    'pgb2
    '
    Me.pgb2.Location = New System.Drawing.Point(45, 84)
    Me.pgb2.Name = "pgb2"
    Me.pgb2.Size = New System.Drawing.Size(304, 21)
    Me.pgb2.TabIndex = 3
    '
    'lblCount
    '
    Me.lblCount.AutoSize = True
    Me.lblCount.Location = New System.Drawing.Point(42, 38)
    Me.lblCount.Name = "lblCount"
    Me.lblCount.Size = New System.Drawing.Size(45, 16)
    Me.lblCount.TabIndex = 5
    Me.lblCount.Text = "Label1"
    Me.lblCount.Visible = False
    '
    'lblComment
    '
    Me.lblComment.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblComment.ForeColor = System.Drawing.Color.Red
    Me.lblComment.Location = New System.Drawing.Point(12, 22)
    Me.lblComment.Name = "lblComment"
    Me.lblComment.Size = New System.Drawing.Size(371, 16)
    Me.lblComment.TabIndex = 5
    Me.lblComment.Text = "comment"
    Me.lblComment.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'frmUpdateOfflineNew
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.PaleGreen
    Me.ClientSize = New System.Drawing.Size(395, 162)
    Me.Controls.Add(Me.lblCount)
    Me.Controls.Add(Me.pgb2)
    Me.Controls.Add(Me.lblComment)
    Me.Controls.Add(Me.btnUpdate)
    Me.Controls.Add(Me.pgb1)
    Me.Controls.Add(Me.btnCancel)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmUpdateOfflineNew"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Tag = "f5a"
    Me.Text = "อัพเดตฐานข้อมูล Offline"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents pgb1 As System.Windows.Forms.ProgressBar
  Friend WithEvents btnUpdate As System.Windows.Forms.Button
  Friend WithEvents btnCancel As System.Windows.Forms.Button
  Friend WithEvents lblCount As System.Windows.Forms.Label
  Friend WithEvents pgb2 As System.Windows.Forms.ProgressBar
  Friend WithEvents lblComment As System.Windows.Forms.Label
End Class
