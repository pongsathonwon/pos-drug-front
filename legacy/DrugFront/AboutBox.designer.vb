<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutBox
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents LabelProductName As System.Windows.Forms.Label
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
  Friend WithEvents LabelCopyright As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
    Me.LogoPictureBox = New System.Windows.Forms.PictureBox
    Me.LabelProductName = New System.Windows.Forms.Label
    Me.LabelVersion = New System.Windows.Forms.Label
    Me.LabelCopyright = New System.Windows.Forms.Label
    Me.lblLicensedTo = New System.Windows.Forms.Label
    Me.labelDevelopBy = New System.Windows.Forms.Label
    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
    Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
    Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
    Me.lblSmile = New System.Windows.Forms.Label
    Me.TableLayoutPanel.SuspendLayout()
    CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TableLayoutPanel
    '
    Me.TableLayoutPanel.ColumnCount = 1
    Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel.Controls.Add(Me.LogoPictureBox, 0, 0)
    Me.TableLayoutPanel.Controls.Add(Me.LabelProductName, 0, 6)
    Me.TableLayoutPanel.Controls.Add(Me.LabelVersion, 0, 7)
    Me.TableLayoutPanel.Controls.Add(Me.LabelCopyright, 0, 8)
    Me.TableLayoutPanel.Controls.Add(Me.lblLicensedTo, 0, 9)
    Me.TableLayoutPanel.Controls.Add(Me.labelDevelopBy, 0, 10)
    Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanel.Location = New System.Drawing.Point(9, 9)
    Me.TableLayoutPanel.Name = "TableLayoutPanel"
    Me.TableLayoutPanel.RowCount = 11
    Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
    Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
    Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
    Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
    Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
    Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
    Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
    Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.TableLayoutPanel.Size = New System.Drawing.Size(313, 216)
    Me.TableLayoutPanel.TabIndex = 0
    '
    'LogoPictureBox
    '
    Me.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LogoPictureBox.Location = New System.Drawing.Point(3, 3)
    Me.LogoPictureBox.Name = "LogoPictureBox"
    Me.TableLayoutPanel.SetRowSpan(Me.LogoPictureBox, 6)
    Me.LogoPictureBox.Size = New System.Drawing.Size(307, 102)
    Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.LogoPictureBox.TabIndex = 0
    Me.LogoPictureBox.TabStop = False
    '
    'LabelProductName
    '
    Me.LabelProductName.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelProductName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.LabelProductName.Location = New System.Drawing.Point(6, 108)
    Me.LabelProductName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
    Me.LabelProductName.MaximumSize = New System.Drawing.Size(0, 17)
    Me.LabelProductName.Name = "LabelProductName"
    Me.LabelProductName.Size = New System.Drawing.Size(304, 17)
    Me.LabelProductName.TabIndex = 0
    Me.LabelProductName.Text = "Product Name"
    Me.LabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LabelVersion
    '
    Me.LabelVersion.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelVersion.Location = New System.Drawing.Point(6, 132)
    Me.LabelVersion.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
    Me.LabelVersion.MaximumSize = New System.Drawing.Size(0, 17)
    Me.LabelVersion.Name = "LabelVersion"
    Me.LabelVersion.Size = New System.Drawing.Size(304, 17)
    Me.LabelVersion.TabIndex = 0
    Me.LabelVersion.Text = "Version"
    Me.LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LabelCopyright
    '
    Me.LabelCopyright.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LabelCopyright.Location = New System.Drawing.Point(6, 152)
    Me.LabelCopyright.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
    Me.LabelCopyright.MaximumSize = New System.Drawing.Size(0, 17)
    Me.LabelCopyright.Name = "LabelCopyright"
    Me.LabelCopyright.Size = New System.Drawing.Size(304, 17)
    Me.LabelCopyright.TabIndex = 0
    Me.LabelCopyright.Text = "Copyright"
    Me.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lblLicensedTo
    '
    Me.lblLicensedTo.Dock = System.Windows.Forms.DockStyle.Fill
    Me.lblLicensedTo.ForeColor = System.Drawing.Color.DarkGreen
    Me.lblLicensedTo.Location = New System.Drawing.Point(6, 172)
    Me.lblLicensedTo.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
    Me.lblLicensedTo.MaximumSize = New System.Drawing.Size(0, 17)
    Me.lblLicensedTo.Name = "lblLicensedTo"
    Me.lblLicensedTo.Size = New System.Drawing.Size(304, 17)
    Me.lblLicensedTo.TabIndex = 1
    Me.lblLicensedTo.Text = "Licensed to"
    Me.lblLicensedTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'labelDevelopBy
    '
    Me.labelDevelopBy.Dock = System.Windows.Forms.DockStyle.Fill
    Me.labelDevelopBy.ForeColor = System.Drawing.Color.Blue
    Me.labelDevelopBy.Location = New System.Drawing.Point(6, 192)
    Me.labelDevelopBy.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
    Me.labelDevelopBy.MaximumSize = New System.Drawing.Size(0, 17)
    Me.labelDevelopBy.Name = "labelDevelopBy"
    Me.labelDevelopBy.Size = New System.Drawing.Size(304, 17)
    Me.labelDevelopBy.TabIndex = 2
    Me.labelDevelopBy.Text = "Developed by"
    Me.labelDevelopBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Timer1
    '
    Me.Timer1.Enabled = True
    Me.Timer1.Interval = 5000
    '
    'Timer2
    '
    Me.Timer2.Interval = 5000
    '
    'Timer3
    '
    Me.Timer3.Enabled = True
    Me.Timer3.Interval = 30000
    '
    'Timer4
    '
    Me.Timer4.Enabled = True
    Me.Timer4.Interval = 45000
    '
    'lblSmile
    '
    Me.lblSmile.AutoSize = True
    Me.lblSmile.Location = New System.Drawing.Point(2, 203)
    Me.lblSmile.Name = "lblSmile"
    Me.lblSmile.Size = New System.Drawing.Size(15, 13)
    Me.lblSmile.TabIndex = 2
    Me.lblSmile.Text = ":)"
    Me.lblSmile.Visible = False
    '
    'AboutBox
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.Moccasin
    Me.ClientSize = New System.Drawing.Size(331, 234)
    Me.Controls.Add(Me.lblSmile)
    Me.Controls.Add(Me.TableLayoutPanel)
    Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "AboutBox"
    Me.Padding = New System.Windows.Forms.Padding(9)
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "AboutBox"
    Me.TableLayoutPanel.ResumeLayout(False)
    CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents lblLicensedTo As System.Windows.Forms.Label
  Friend WithEvents labelDevelopBy As System.Windows.Forms.Label
  Friend WithEvents Timer1 As System.Windows.Forms.Timer
  Friend WithEvents Timer2 As System.Windows.Forms.Timer
  Friend WithEvents Timer3 As System.Windows.Forms.Timer
  Friend WithEvents Timer4 As System.Windows.Forms.Timer
  Friend WithEvents lblSmile As System.Windows.Forms.Label

End Class
