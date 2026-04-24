<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalePaid
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
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.lblTotalNet = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
    Me.dtgPaid = New System.Windows.Forms.DataGridView
    Me.cardCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.cardName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.payAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.refNumb = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.cardColor = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.reqRefNumb = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.btnSave = New System.Windows.Forms.Button
    Me.txtEmplName = New System.Windows.Forms.TextBox
    Me.txtEmplCode = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
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
    Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitContainer1.IsSplitterFixed = True
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer1.Name = "SplitContainer1"
    Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(243, Byte), Integer))
    Me.SplitContainer1.Panel1.Controls.Add(Me.lblTotalNet)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
    Me.SplitContainer1.Size = New System.Drawing.Size(636, 631)
    Me.SplitContainer1.SplitterDistance = 75
    Me.SplitContainer1.TabIndex = 0
    Me.SplitContainer1.TabStop = False
    '
    'lblTotalNet
    '
    Me.lblTotalNet.BackColor = System.Drawing.Color.White
    Me.lblTotalNet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblTotalNet.Location = New System.Drawing.Point(216, 24)
    Me.lblTotalNet.Name = "lblTotalNet"
    Me.lblTotalNet.Size = New System.Drawing.Size(214, 30)
    Me.lblTotalNet.TabIndex = 1
    Me.lblTotalNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(78, 25)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(115, 23)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "ยอดเงินสุทธิ"
    '
    'SplitContainer2
    '
    Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
    Me.SplitContainer2.IsSplitterFixed = True
    Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer2.Name = "SplitContainer2"
    Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer2.Panel1
    '
    Me.SplitContainer2.Panel1.Controls.Add(Me.dtgPaid)
    '
    'SplitContainer2.Panel2
    '
    Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.CornflowerBlue
    Me.SplitContainer2.Panel2.Controls.Add(Me.btnSave)
    Me.SplitContainer2.Panel2.Controls.Add(Me.txtEmplName)
    Me.SplitContainer2.Panel2.Controls.Add(Me.txtEmplCode)
    Me.SplitContainer2.Panel2.Controls.Add(Me.Label3)
    Me.SplitContainer2.Size = New System.Drawing.Size(636, 552)
    Me.SplitContainer2.SplitterDistance = 476
    Me.SplitContainer2.TabIndex = 0
    Me.SplitContainer2.TabStop = False
    '
    'dtgPaid
    '
    Me.dtgPaid.AllowUserToAddRows = False
    Me.dtgPaid.AllowUserToDeleteRows = False
    Me.dtgPaid.AllowUserToResizeColumns = False
    Me.dtgPaid.AllowUserToResizeRows = False
    Me.dtgPaid.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(249, Byte), Integer))
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgPaid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgPaid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgPaid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cardCode, Me.cardName, Me.payAmou, Me.refNumb, Me.cardColor, Me.reqRefNumb})
    Me.dtgPaid.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgPaid.Location = New System.Drawing.Point(0, 0)
    Me.dtgPaid.Name = "dtgPaid"
    Me.dtgPaid.RowHeadersVisible = False
    Me.dtgPaid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(243, Byte), Integer))
    Me.dtgPaid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgPaid.RowTemplate.Height = 30
    Me.dtgPaid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
    Me.dtgPaid.Size = New System.Drawing.Size(636, 476)
    Me.dtgPaid.TabIndex = 0
    '
    'cardCode
    '
    Me.cardCode.HeaderText = "cardCode"
    Me.cardCode.Name = "cardCode"
    Me.cardCode.ReadOnly = True
    Me.cardCode.Visible = False
    '
    'cardName
    '
    Me.cardName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    Me.cardName.DefaultCellStyle = DataGridViewCellStyle2
    Me.cardName.HeaderText = "ประเภทการชำระ"
    Me.cardName.Name = "cardName"
    Me.cardName.ReadOnly = True
    '
    'payAmou
    '
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle3.Format = "N2"
    Me.payAmou.DefaultCellStyle = DataGridViewCellStyle3
    Me.payAmou.HeaderText = "จำนวนเงิน"
    Me.payAmou.Name = "payAmou"
    Me.payAmou.Width = 150
    '
    'refNumb
    '
    Me.refNumb.HeaderText = "เลขอ้างอิง"
    Me.refNumb.Name = "refNumb"
    Me.refNumb.Width = 170
    '
    'cardColor
    '
    Me.cardColor.HeaderText = "cardColor"
    Me.cardColor.Name = "cardColor"
    Me.cardColor.Visible = False
    '
    'reqRefNumb
    '
    Me.reqRefNumb.HeaderText = "reqRefNumb"
    Me.reqRefNumb.Name = "reqRefNumb"
    Me.reqRefNumb.Visible = False
    '
    'btnSave
    '
    Me.btnSave.Location = New System.Drawing.Point(492, 20)
    Me.btnSave.Name = "btnSave"
    Me.btnSave.Size = New System.Drawing.Size(115, 30)
    Me.btnSave.TabIndex = 1
    Me.btnSave.Text = "รับเงิน"
    Me.btnSave.UseVisualStyleBackColor = True
    '
    'txtEmplName
    '
    Me.txtEmplName.BackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(249, Byte), Integer))
    Me.txtEmplName.Location = New System.Drawing.Point(219, 20)
    Me.txtEmplName.Name = "txtEmplName"
    Me.txtEmplName.Size = New System.Drawing.Size(267, 30)
    Me.txtEmplName.TabIndex = 2
    Me.txtEmplName.TabStop = False
    '
    'txtEmplCode
    '
    Me.txtEmplCode.Location = New System.Drawing.Point(138, 20)
    Me.txtEmplCode.Name = "txtEmplCode"
    Me.txtEmplCode.Size = New System.Drawing.Size(75, 30)
    Me.txtEmplCode.TabIndex = 0
    Me.txtEmplCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 22)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(120, 23)
    Me.Label3.TabIndex = 0
    Me.Label3.Text = "พนักงานขาย"
    '
    'frmSalePaid
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 23.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(636, 631)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmSalePaid"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "ชำระเงิน"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    Me.SplitContainer2.Panel1.ResumeLayout(False)
    Me.SplitContainer2.Panel2.ResumeLayout(False)
    Me.SplitContainer2.Panel2.PerformLayout()
    Me.SplitContainer2.ResumeLayout(False)
    CType(Me.dtgPaid, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents lblTotalNet As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
  Friend WithEvents btnSave As System.Windows.Forms.Button
  Friend WithEvents txtEmplName As System.Windows.Forms.TextBox
  Friend WithEvents txtEmplCode As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents dtgPaid As System.Windows.Forms.DataGridView
  Friend WithEvents cardCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents cardName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents payAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents refNumb As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents cardColor As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents reqRefNumb As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
