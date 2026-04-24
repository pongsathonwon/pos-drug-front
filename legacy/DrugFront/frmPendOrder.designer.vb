<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPendOrder
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
    Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.dtgList = New System.Windows.Forms.DataGridView
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
    Me.tbnCancel = New System.Windows.Forms.ToolStripButton
    Me.goodName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.pendAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.unitDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.orderDate = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.pendStatDetail = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GoodCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.pendStat = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.orderNumb = New System.Windows.Forms.DataGridViewTextBoxColumn
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ToolStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'dtgList
    '
    Me.dtgList.AllowUserToAddRows = False
    Me.dtgList.AllowUserToDeleteRows = False
    Me.dtgList.AllowUserToResizeColumns = False
    Me.dtgList.AllowUserToResizeRows = False
    Me.dtgList.BackgroundColor = System.Drawing.Color.Honeydew
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
    Me.dtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    Me.dtgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.goodName, Me.pendAmou, Me.unitDesc, Me.orderDate, Me.pendStatDetail, Me.GoodCode, Me.pendStat, Me.orderNumb})
    Me.dtgList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
    Me.dtgList.Location = New System.Drawing.Point(0, 25)
    Me.dtgList.Name = "dtgList"
    Me.dtgList.ReadOnly = True
    Me.dtgList.RowHeadersVisible = False
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkSeaGreen
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.dtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgList.Size = New System.Drawing.Size(626, 352)
    Me.dtgList.StandardTab = True
    Me.dtgList.TabIndex = 0
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbnCancel})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.Size = New System.Drawing.Size(626, 25)
    Me.ToolStrip1.TabIndex = 1
    Me.ToolStrip1.Text = "ToolStrip1"
    '
    'tbnCancel
    '
    Me.tbnCancel.Image = Global.DrugFront.My.Resources.Resources.delete
    Me.tbnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tbnCancel.Name = "tbnCancel"
    Me.tbnCancel.Size = New System.Drawing.Size(104, 22)
    Me.tbnCancel.Text = "ยกเลิกรายการ"
    '
    'goodName
    '
    Me.goodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.goodName.HeaderText = "รายการ"
    Me.goodName.Name = "goodName"
    Me.goodName.ReadOnly = True
    '
    'pendAmou
    '
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle5.Format = "n0"
    Me.pendAmou.DefaultCellStyle = DataGridViewCellStyle5
    Me.pendAmou.HeaderText = "จำนวน"
    Me.pendAmou.Name = "pendAmou"
    Me.pendAmou.ReadOnly = True
    Me.pendAmou.Width = 80
    '
    'unitDesc
    '
    DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    Me.unitDesc.DefaultCellStyle = DataGridViewCellStyle6
    Me.unitDesc.HeaderText = "หน่วย"
    Me.unitDesc.Name = "unitDesc"
    Me.unitDesc.ReadOnly = True
    '
    'orderDate
    '
    Me.orderDate.HeaderText = "วันที่สั่ง"
    Me.orderDate.Name = "orderDate"
    Me.orderDate.ReadOnly = True
    Me.orderDate.Visible = False
    '
    'pendStatDetail
    '
    Me.pendStatDetail.HeaderText = "สถานะการจอง"
    Me.pendStatDetail.Name = "pendStatDetail"
    Me.pendStatDetail.ReadOnly = True
    Me.pendStatDetail.Width = 110
    '
    'GoodCode
    '
    Me.GoodCode.HeaderText = "goodCode"
    Me.GoodCode.Name = "GoodCode"
    Me.GoodCode.ReadOnly = True
    Me.GoodCode.Visible = False
    '
    'pendStat
    '
    Me.pendStat.HeaderText = "pendStat"
    Me.pendStat.Name = "pendStat"
    Me.pendStat.ReadOnly = True
    Me.pendStat.Visible = False
    '
    'orderNumb
    '
    Me.orderNumb.HeaderText = "orderNumb"
    Me.orderNumb.Name = "orderNumb"
    Me.orderNumb.ReadOnly = True
    Me.orderNumb.Visible = False
    '
    'frmPendOrder
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(626, 377)
    Me.Controls.Add(Me.dtgList)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmPendOrder"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "รายการสินค้าค้างส่ง"
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents dtgList As System.Windows.Forms.DataGridView
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents tbnCancel As System.Windows.Forms.ToolStripButton
  Friend WithEvents goodName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents pendAmou As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents unitDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents orderDate As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents pendStatDetail As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GoodCode As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents pendStat As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents orderNumb As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
