<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRpCommission
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
    Me.Label2 = New System.Windows.Forms.Label
    Me.cboMonthName = New System.Windows.Forms.ComboBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.cboYear = New System.Windows.Forms.ComboBox
    Me.cboMonth = New System.Windows.Forms.ComboBox
    Me.btnShow = New System.Windows.Forms.Button
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.dtgList = New System.Windows.Forms.DataGridView
    Me.itemDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.itemAmou = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(16, 20)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(69, 16)
    Me.Label2.TabIndex = 74
    Me.Label2.Text = "ประจำเดือน"
    '
    'cboMonthName
    '
    Me.cboMonthName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboMonthName.FormattingEnabled = True
    Me.cboMonthName.Location = New System.Drawing.Point(91, 17)
    Me.cboMonthName.Name = "cboMonthName"
    Me.cboMonthName.Size = New System.Drawing.Size(121, 24)
    Me.cboMonthName.TabIndex = 72
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(222, 20)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(16, 16)
    Me.Label3.TabIndex = 75
    Me.Label3.Text = "ปี"
    '
    'cboYear
    '
    Me.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboYear.FormattingEnabled = True
    Me.cboYear.Location = New System.Drawing.Point(244, 17)
    Me.cboYear.Name = "cboYear"
    Me.cboYear.Size = New System.Drawing.Size(92, 24)
    Me.cboYear.TabIndex = 73
    '
    'cboMonth
    '
    Me.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboMonth.FormattingEnabled = True
    Me.cboMonth.Location = New System.Drawing.Point(342, 17)
    Me.cboMonth.Name = "cboMonth"
    Me.cboMonth.Size = New System.Drawing.Size(17, 24)
    Me.cboMonth.TabIndex = 76
    Me.cboMonth.Visible = False
    '
    'btnShow
    '
    Me.btnShow.Location = New System.Drawing.Point(365, 13)
    Me.btnShow.Name = "btnShow"
    Me.btnShow.Size = New System.Drawing.Size(94, 31)
    Me.btnShow.TabIndex = 0
    Me.btnShow.Text = "แสดงข้อมูล"
    Me.btnShow.UseVisualStyleBackColor = True
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
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Violet
    Me.SplitContainer1.Panel1.Controls.Add(Me.cboMonthName)
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnShow)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
    Me.SplitContainer1.Panel1.Controls.Add(Me.cboMonth)
    Me.SplitContainer1.Panel1.Controls.Add(Me.cboYear)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.dtgList)
    Me.SplitContainer1.Size = New System.Drawing.Size(469, 459)
    Me.SplitContainer1.SplitterDistance = 57
    Me.SplitContainer1.TabIndex = 78
    '
    'dtgList
    '
    Me.dtgList.AllowUserToAddRows = False
    Me.dtgList.AllowUserToDeleteRows = False
    Me.dtgList.AllowUserToResizeColumns = False
    Me.dtgList.AllowUserToResizeRows = False
    Me.dtgList.BackgroundColor = System.Drawing.Color.LavenderBlush
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemDesc, Me.itemAmou})
    Me.dtgList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgList.Location = New System.Drawing.Point(0, 0)
    Me.dtgList.Name = "dtgList"
    Me.dtgList.ReadOnly = True
    Me.dtgList.RowHeadersVisible = False
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Violet
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgList.Size = New System.Drawing.Size(469, 398)
    Me.dtgList.TabIndex = 0
    '
    'itemDesc
    '
    Me.itemDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.itemDesc.HeaderText = "รายการ"
    Me.itemDesc.Name = "itemDesc"
    Me.itemDesc.ReadOnly = True
    '
    'itemAmou
    '
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle2.Format = "N2"
    Me.itemAmou.DefaultCellStyle = DataGridViewCellStyle2
    Me.itemAmou.HeaderText = "ค่าที่ได้"
    Me.itemAmou.Name = "itemAmou"
    Me.itemAmou.ReadOnly = True
    Me.itemAmou.Width = 150
    '
    'frmRpCommission
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(469, 459)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "frmRpCommission"
    Me.Tag = "f3o"
    Me.Text = "รายงานค่าคอมมิชชั่น"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents cboMonthName As System.Windows.Forms.ComboBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents cboYear As System.Windows.Forms.ComboBox
  Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
  Friend WithEvents btnShow As System.Windows.Forms.Button
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents dtgList As System.Windows.Forms.DataGridView
  Friend WithEvents itemDesc As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents itemAmou As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
