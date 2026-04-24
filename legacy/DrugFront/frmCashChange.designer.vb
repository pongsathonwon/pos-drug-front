<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashChange
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
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.Label1 = New System.Windows.Forms.Label
    Me.lblReturn = New System.Windows.Forms.Label
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(191, Byte), Integer))
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Controls.Add(Me.lblReturn)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(469, 227)
    Me.Panel1.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Label1.Location = New System.Drawing.Point(3, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(463, 34)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "à§Ô¹·Í¹"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'lblReturn
    '
    Me.lblReturn.Font = New System.Drawing.Font("Tahoma", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblReturn.ForeColor = System.Drawing.Color.Black
    Me.lblReturn.Location = New System.Drawing.Point(3, 50)
    Me.lblReturn.Name = "lblReturn"
    Me.lblReturn.Size = New System.Drawing.Size(463, 161)
    Me.lblReturn.TabIndex = 2
    Me.lblReturn.Text = "0.00"
    Me.lblReturn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'frmCashChange
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 23.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(469, 227)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmCashChange"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "à§Ô¹·Í¹"
    Me.Panel1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents lblReturn As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
