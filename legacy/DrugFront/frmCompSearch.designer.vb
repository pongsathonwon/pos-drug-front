<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompSearch
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
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.btnSearch = New System.Windows.Forms.Button
    Me.txtName = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.dtgList = New System.Windows.Forms.DataGridView
    Me.CompName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.CompCode = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.IsSplitterFixed = True
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.SplitContainer1.Name = "SplitContainer1"
    Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Tan
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnSearch)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtName)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.dtgList)
    Me.SplitContainer1.Size = New System.Drawing.Size(333, 336)
    Me.SplitContainer1.SplitterDistance = 39
    Me.SplitContainer1.SplitterWidth = 5
    Me.SplitContainer1.TabIndex = 0
    '
    'btnSearch
    '
    Me.btnSearch.Image = Global.DrugFront.My.Resources.Resources.search
    Me.btnSearch.Location = New System.Drawing.Point(237, 7)
    Me.btnSearch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.btnSearch.Name = "btnSearch"
    Me.btnSearch.Size = New System.Drawing.Size(24, 25)
    Me.btnSearch.TabIndex = 1
    Me.btnSearch.UseVisualStyleBackColor = True
    '
    'txtName
    '
    Me.txtName.Location = New System.Drawing.Point(73, 7)
    Me.txtName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.txtName.Name = "txtName"
    Me.txtName.Size = New System.Drawing.Size(166, 23)
    Me.txtName.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(14, 11)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(57, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "ชื่อบริษัท"
    '
    'dtgList
    '
    Me.dtgList.AllowUserToAddRows = False
    Me.dtgList.AllowUserToDeleteRows = False
    Me.dtgList.AllowUserToResizeColumns = False
    Me.dtgList.AllowUserToResizeRows = False
    Me.dtgList.BackgroundColor = System.Drawing.Color.Moccasin
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtgList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.dtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dtgList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CompName, Me.CompCode})
    Me.dtgList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dtgList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
    Me.dtgList.Location = New System.Drawing.Point(0, 0)
    Me.dtgList.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.dtgList.Name = "dtgList"
    Me.dtgList.ReadOnly = True
    Me.dtgList.RowHeadersVisible = False
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Tan
    Me.dtgList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
    Me.dtgList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.dtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtgList.Size = New System.Drawing.Size(333, 292)
    Me.dtgList.StandardTab = True
    Me.dtgList.TabIndex = 0
    '
    'CompName
    '
    Me.CompName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.CompName.HeaderText = "ชื่อบริษัท"
    Me.CompName.Name = "CompName"
    Me.CompName.ReadOnly = True
    '
    'CompCode
    '
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    Me.CompCode.DefaultCellStyle = DataGridViewCellStyle2
    Me.CompCode.HeaderText = "รหัส"
    Me.CompCode.Name = "CompCode"
    Me.CompCode.ReadOnly = True
    '
    'frmCompSearch
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(333, 336)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.KeyPreview = True
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmCompSearch"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "ค้นหาบริษัท"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    CType(Me.dtgList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents txtName As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents dtgList As System.Windows.Forms.DataGridView
  Friend WithEvents btnSearch As System.Windows.Forms.Button
  Friend WithEvents CompName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents CompCode As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
