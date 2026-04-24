<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUploadServer
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
    Me.btnStart = New System.Windows.Forms.Button
    Me.pgb1 = New System.Windows.Forms.ProgressBar
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.dtgTemp = New System.Windows.Forms.DataGridView
    Me.barCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.goodAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitCost = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.subDisc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.totalAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.stockOnhand = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.totalGoodAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GroupBox1.SuspendLayout()
    CType(Me.dtgTemp, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'btnStart
    '
    Me.btnStart.Location = New System.Drawing.Point(112, 60)
    Me.btnStart.Name = "btnStart"
    Me.btnStart.Size = New System.Drawing.Size(85, 25)
    Me.btnStart.TabIndex = 0
    Me.btnStart.Text = "Upload"
    Me.btnStart.UseVisualStyleBackColor = True
    '
    'pgb1
    '
    Me.pgb1.Location = New System.Drawing.Point(16, 33)
    Me.pgb1.Name = "pgb1"
    Me.pgb1.Size = New System.Drawing.Size(269, 21)
    Me.pgb1.TabIndex = 1
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.pgb1)
    Me.GroupBox1.Controls.Add(Me.btnStart)
    Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(6, 12)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(302, 98)
    Me.GroupBox1.TabIndex = 3
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "อัพโหลดข้อมูลการขาย Offline ไปยัง Server"
    '
    'dtgTemp
    '
    Me.dtgTemp.AllowUserToAddRows = False
    Me.dtgTemp.AllowUserToDeleteRows = False
    Me.dtgTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgTemp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.barCode, Me.goodCode, Me.goodAmou, Me.unitCost, Me.unitPrice, Me.unitCode, Me.subDisc, Me.totalAmou, Me.stockOnhand, Me.totalGoodAmou})
    Me.dtgTemp.Location = New System.Drawing.Point(12, 130)
    Me.dtgTemp.Name = "dtgTemp"
    Me.dtgTemp.ReadOnly = True
    Me.dtgTemp.Size = New System.Drawing.Size(661, 116)
    Me.dtgTemp.TabIndex = 4
    '
    'barCode
    '
    Me.barCode.HeaderText = "barCode"
    Me.barCode.Name = "barCode"
    Me.barCode.ReadOnly = True
    '
    'goodCode
    '
    Me.goodCode.HeaderText = "goodCode"
    Me.goodCode.Name = "goodCode"
    Me.goodCode.ReadOnly = True
    '
    'goodAmou
    '
    Me.goodAmou.HeaderText = "goodAmou"
    Me.goodAmou.Name = "goodAmou"
    Me.goodAmou.ReadOnly = True
    '
    'unitCost
    '
    Me.unitCost.HeaderText = "unitCost"
    Me.unitCost.Name = "unitCost"
    Me.unitCost.ReadOnly = True
    '
    'unitPrice
    '
    Me.unitPrice.HeaderText = "unitPrice"
    Me.unitPrice.Name = "unitPrice"
    Me.unitPrice.ReadOnly = True
    '
    'unitCode
    '
    Me.unitCode.HeaderText = "unitCode"
    Me.unitCode.Name = "unitCode"
    Me.unitCode.ReadOnly = True
    '
    'subDisc
    '
    Me.subDisc.HeaderText = "subDisc"
    Me.subDisc.Name = "subDisc"
    Me.subDisc.ReadOnly = True
    '
    'totalAmou
    '
    Me.totalAmou.HeaderText = "totalAmou"
    Me.totalAmou.Name = "totalAmou"
    Me.totalAmou.ReadOnly = True
    '
    'stockOnhand
    '
    Me.stockOnhand.HeaderText = "stockOnhand"
    Me.stockOnhand.Name = "stockOnhand"
    Me.stockOnhand.ReadOnly = True
    '
    'totalGoodAmou
    '
    Me.totalGoodAmou.HeaderText = "totalGoodAmou"
    Me.totalGoodAmou.Name = "totalGoodAmou"
    Me.totalGoodAmou.ReadOnly = True
    Me.totalGoodAmou.Visible = False
    '
    'frmUploadServerNew
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.Violet
    Me.ClientSize = New System.Drawing.Size(318, 116)
    Me.Controls.Add(Me.dtgTemp)
    Me.Controls.Add(Me.GroupBox1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmUploadServerNew"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Tag = "f5b"
    Me.Text = "อัพโหลดข้อมูลการขาย Offline"
    Me.GroupBox1.ResumeLayout(False)
    CType(Me.dtgTemp, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents btnStart As System.Windows.Forms.Button
  Friend WithEvents pgb1 As System.Windows.Forms.ProgressBar
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents dtgTemp As System.Windows.Forms.DataGridView
  Friend WithEvents barCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents goodAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitCost As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents subDisc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents totalAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents stockOnhand As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents totalGoodAmou As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
