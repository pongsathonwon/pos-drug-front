<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangeSalePaid
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
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
    Me.lblTotalPrice = New System.Windows.Forms.Label
    Me.dtgPaid = New System.Windows.Forms.DataGridView
    Me.cardName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.payAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.cardCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.btnSave = New System.Windows.Forms.Button
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SplitContainer2.Panel1.SuspendLayout()
    Me.SplitContainer2.Panel2.SuspendLayout()
    Me.SplitContainer2.SuspendLayout()
    CType(Me.dtgPaid, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
    Me.SplitContainer1.IsSplitterFixed = True
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer1.Name = "SplitContainer1"
    Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(117, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(145, Byte), Integer))
    Me.SplitContainer1.Panel2.Controls.Add(Me.btnSave)
    Me.SplitContainer1.Size = New System.Drawing.Size(331, 437)
    Me.SplitContainer1.SplitterDistance = 385
    Me.SplitContainer1.TabIndex = 0
    Me.SplitContainer1.TabStop = False
    '
    'SplitContainer2
    '
    Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer2.IsSplitterFixed = True
    Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer2.Name = "SplitContainer2"
    Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer2.Panel1
    '
    Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(163, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(181, Byte), Integer))
    Me.SplitContainer2.Panel1.Controls.Add(Me.lblTotalPrice)
    '
    'SplitContainer2.Panel2
    '
    Me.SplitContainer2.Panel2.Controls.Add(Me.dtgPaid)
    Me.SplitContainer2.Size = New System.Drawing.Size(331, 385)
    Me.SplitContainer2.TabIndex = 31
    Me.SplitContainer2.TabStop = False
    '
    'lblTotalPrice
    '
    Me.lblTotalPrice.Location = New System.Drawing.Point(34, 14)
    Me.lblTotalPrice.Name = "lblTotalPrice"
    Me.lblTotalPrice.Size = New System.Drawing.Size(271, 24)
    Me.lblTotalPrice.TabIndex = 0
    Me.lblTotalPrice.Text = "รวมเงินสุทธิ"
    Me.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'dtgPaid
    '
    Me.dtgPaid.AllowUserToAddRows = False
    Me.dtgPaid.AllowUserToDeleteRows = False
    Me.dtgPaid.AllowUserToResizeColumns = False
    Me.dtgPaid.AllowUserToResizeRows = False
    Me.dtgPaid.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(218, Byte), Integer))
    Me.dtgPaid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgPaid.ColumnHeadersVisible = False
    Me.dtgPaid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cardName, Me.payAmou, Me.cardCode})
    Me.dtgPaid.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgPaid.Location = New System.Drawing.Point(0, 0)
    Me.dtgPaid.Name = "dtgPaid"
    Me.dtgPaid.RowHeadersVisible = False
    Me.dtgPaid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(243, Byte), Integer))
    Me.dtgPaid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgPaid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
    Me.dtgPaid.Size = New System.Drawing.Size(331, 331)
    Me.dtgPaid.TabIndex = 30
    '
    'cardName
    '
    Me.cardName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.cardName.HeaderText = "ประเภทการชำระเงิน"
    Me.cardName.Name = "cardName"
    Me.cardName.ReadOnly = True
    '
    'payAmou
    '
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle4.Format = "N2"
    Me.payAmou.DefaultCellStyle = DataGridViewCellStyle4
    Me.payAmou.HeaderText = "จำนวนเงิน"
    Me.payAmou.Name = "payAmou"
    Me.payAmou.Width = 60
    '
    'cardCode
    '
    Me.cardCode.HeaderText = "cardCode"
    Me.cardCode.Name = "cardCode"
    Me.cardCode.ReadOnly = True
    Me.cardCode.Visible = False
    '
    'btnSave
    '
    Me.btnSave.Location = New System.Drawing.Point(129, 12)
    Me.btnSave.Name = "btnSave"
    Me.btnSave.Size = New System.Drawing.Size(75, 25)
    Me.btnSave.TabIndex = 0
    Me.btnSave.Text = "บันทึก"
    Me.btnSave.UseVisualStyleBackColor = True
    '
    'frmChangeSalePaid
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(331, 437)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmChangeSalePaid"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "แก้ไชการชำระเงิน"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    Me.SplitContainer2.Panel1.ResumeLayout(False)
    Me.SplitContainer2.Panel2.ResumeLayout(False)
    Me.SplitContainer2.ResumeLayout(False)
    CType(Me.dtgPaid, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents dtgPaid As System.Windows.Forms.DataGridView
  Friend WithEvents btnSave As System.Windows.Forms.Button
  Friend WithEvents cardName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents payAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents cardCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
  Friend WithEvents lblTotalPrice As System.Windows.Forms.Label
End Class
