<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsePoint
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
    Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.dtgPoint = New System.Windows.Forms.DataGridView
    Me.hugPoint = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.cashValue = New System.Windows.Forms.DataGridViewTextBoxColumn
    CType(Me.dtgPoint, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'dtgPoint
    '
    Me.dtgPoint.AllowUserToAddRows = False
    Me.dtgPoint.AllowUserToDeleteRows = False
    Me.dtgPoint.AllowUserToResizeColumns = False
    Me.dtgPoint.AllowUserToResizeRows = False
    Me.dtgPoint.BackgroundColor = System.Drawing.Color.LavenderBlush
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgPoint.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
    Me.dtgPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgPoint.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.hugPoint, Me.cashValue})
    Me.dtgPoint.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgPoint.Location = New System.Drawing.Point(0, 0)
    Me.dtgPoint.Name = "dtgPoint"
    Me.dtgPoint.ReadOnly = True
    Me.dtgPoint.RowHeadersVisible = False
    Me.dtgPoint.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.dtgPoint.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Thistle
    Me.dtgPoint.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgPoint.RowTemplate.Height = 30
    Me.dtgPoint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgPoint.ShowCellToolTips = False
    Me.dtgPoint.Size = New System.Drawing.Size(308, 248)
    Me.dtgPoint.TabIndex = 0
    '
    'hugPoint
    '
    Me.hugPoint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle5.Format = "N0"
    DataGridViewCellStyle5.NullValue = Nothing
    Me.hugPoint.DefaultCellStyle = DataGridViewCellStyle5
    Me.hugPoint.HeaderText = "HUG Points"
    Me.hugPoint.Name = "hugPoint"
    Me.hugPoint.ReadOnly = True
    '
    'cashValue
    '
    DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle6.Format = "N0"
    DataGridViewCellStyle6.NullValue = Nothing
    Me.cashValue.DefaultCellStyle = DataGridViewCellStyle6
    Me.cashValue.HeaderText = "แทนเงินสดมูลค่า"
    Me.cashValue.Name = "cashValue"
    Me.cashValue.ReadOnly = True
    Me.cashValue.Width = 120
    '
    'frmUsePoint
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(308, 248)
    Me.Controls.Add(Me.dtgPoint)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmUsePoint"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "ใช้แต้มแทนเงินสด"
    CType(Me.dtgPoint, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents dtgPoint As System.Windows.Forms.DataGridView
  Friend WithEvents hugPoint As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents cashValue As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
