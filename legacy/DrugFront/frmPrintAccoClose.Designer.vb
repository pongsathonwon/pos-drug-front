<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintAccoClose
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
    Me.dtpAcco = New System.Windows.Forms.DateTimePicker
    Me.Label1 = New System.Windows.Forms.Label
    Me.btnPrint = New System.Windows.Forms.Button
    Me.pdc1 = New System.Drawing.Printing.PrintDocument
    Me.dtgGroup = New System.Windows.Forms.DataGridView
    Me.GroupDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.TotalPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.dtgGroup2 = New System.Windows.Forms.DataGridView
    Me.groupDesc2 = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.totalPrice2 = New System.Windows.Forms.DataGridViewTextBoxColumn
    CType(Me.dtgGroup, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dtgGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'dtpAcco
    '
    Me.dtpAcco.Location = New System.Drawing.Point(87, 23)
    Me.dtpAcco.Name = "dtpAcco"
    Me.dtpAcco.Size = New System.Drawing.Size(162, 23)
    Me.dtpAcco.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(17, 26)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "ประจำวันที่"
    '
    'btnPrint
    '
    Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
    Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.btnPrint.Image = Global.DrugFront.My.Resources.Resources.printer1
    Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.btnPrint.Location = New System.Drawing.Point(130, 59)
    Me.btnPrint.Name = "btnPrint"
    Me.btnPrint.Size = New System.Drawing.Size(70, 27)
    Me.btnPrint.TabIndex = 0
    Me.btnPrint.Text = "พิมพ์"
    Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.btnPrint.UseVisualStyleBackColor = True
    '
    'pdc1
    '
    '
    'dtgGroup
    '
    Me.dtgGroup.AllowUserToAddRows = False
    Me.dtgGroup.AllowUserToDeleteRows = False
    Me.dtgGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgGroup.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GroupDesc, Me.TotalPrice})
    Me.dtgGroup.Location = New System.Drawing.Point(44, 108)
    Me.dtgGroup.Name = "dtgGroup"
    Me.dtgGroup.ReadOnly = True
    Me.dtgGroup.RowHeadersVisible = False
    Me.dtgGroup.Size = New System.Drawing.Size(260, 110)
    Me.dtgGroup.TabIndex = 34
    '
    'GroupDesc
    '
    Me.GroupDesc.HeaderText = "กลุ่มสินค้า"
    Me.GroupDesc.Name = "GroupDesc"
    Me.GroupDesc.ReadOnly = True
    '
    'TotalPrice
    '
    Me.TotalPrice.HeaderText = "จำนวนเงิน"
    Me.TotalPrice.Name = "TotalPrice"
    Me.TotalPrice.ReadOnly = True
    '
    'dtgGroup2
    '
    Me.dtgGroup2.AllowUserToAddRows = False
    Me.dtgGroup2.AllowUserToDeleteRows = False
    Me.dtgGroup2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgGroup2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.groupDesc2, Me.totalPrice2})
    Me.dtgGroup2.Location = New System.Drawing.Point(44, 224)
    Me.dtgGroup2.Name = "dtgGroup2"
    Me.dtgGroup2.ReadOnly = True
    Me.dtgGroup2.RowHeadersVisible = False
    Me.dtgGroup2.Size = New System.Drawing.Size(260, 110)
    Me.dtgGroup2.TabIndex = 35
    '
    'groupDesc2
    '
    Me.groupDesc2.HeaderText = "กลุ่มสินค้า"
    Me.groupDesc2.Name = "groupDesc2"
    Me.groupDesc2.ReadOnly = True
    '
    'totalPrice2
    '
    Me.totalPrice2.HeaderText = "จำนวนเงิน"
    Me.totalPrice2.Name = "totalPrice2"
    Me.totalPrice2.ReadOnly = True
    '
    'frmPrintAccoClose
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.Plum
    Me.ClientSize = New System.Drawing.Size(310, 101)
    Me.Controls.Add(Me.dtgGroup2)
    Me.Controls.Add(Me.dtgGroup)
    Me.Controls.Add(Me.btnPrint)
    Me.Controls.Add(Me.dtpAcco)
    Me.Controls.Add(Me.Label1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmPrintAccoClose"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Tag = "f3b"
    Me.Text = "พิมพ์ใบสรุปบัญชี ย้อนหลัง"
    CType(Me.dtgGroup, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dtgGroup2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents dtpAcco As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents btnPrint As System.Windows.Forms.Button
  Friend WithEvents pdc1 As System.Drawing.Printing.PrintDocument
  Friend WithEvents dtgGroup As System.Windows.Forms.DataGridView
  Friend WithEvents GroupDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents TotalPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents dtgGroup2 As System.Windows.Forms.DataGridView
  Friend WithEvents groupDesc2 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents totalPrice2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
