<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoicePreRece
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
    Me.btnSave = New System.Windows.Forms.Button
    Me.txtUnitDesc = New System.Windows.Forms.TextBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.txtReceAmou = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.txtSendAmou = New System.Windows.Forms.TextBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtGoodName = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SuspendLayout()
    '
    'btnSave
    '
    Me.btnSave.Location = New System.Drawing.Point(147, 16)
    Me.btnSave.Name = "btnSave"
    Me.btnSave.Size = New System.Drawing.Size(145, 25)
    Me.btnSave.TabIndex = 0
    Me.btnSave.Text = "บันทึกรับสินค้าด่วน"
    Me.btnSave.UseVisualStyleBackColor = True
    '
    'txtUnitDesc
    '
    Me.txtUnitDesc.Location = New System.Drawing.Point(113, 56)
    Me.txtUnitDesc.Name = "txtUnitDesc"
    Me.txtUnitDesc.ReadOnly = True
    Me.txtUnitDesc.Size = New System.Drawing.Size(100, 23)
    Me.txtUnitDesc.TabIndex = 7
    Me.txtUnitDesc.TabStop = False
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(32, 59)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(38, 16)
    Me.Label4.TabIndex = 6
    Me.Label4.Text = "หน่วย"
    '
    'txtReceAmou
    '
    Me.txtReceAmou.Location = New System.Drawing.Point(113, 138)
    Me.txtReceAmou.Name = "txtReceAmou"
    Me.txtReceAmou.Size = New System.Drawing.Size(100, 23)
    Me.txtReceAmou.TabIndex = 0
    Me.txtReceAmou.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(32, 141)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(57, 16)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "จำนวนรับ"
    '
    'txtSendAmou
    '
    Me.txtSendAmou.Location = New System.Drawing.Point(113, 109)
    Me.txtSendAmou.Name = "txtSendAmou"
    Me.txtSendAmou.ReadOnly = True
    Me.txtSendAmou.Size = New System.Drawing.Size(100, 23)
    Me.txtSendAmou.TabIndex = 3
    Me.txtSendAmou.TabStop = False
    Me.txtSendAmou.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(32, 112)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(57, 16)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "จำนวนส่ง"
    '
    'txtGoodName
    '
    Me.txtGoodName.Location = New System.Drawing.Point(113, 27)
    Me.txtGoodName.Name = "txtGoodName"
    Me.txtGoodName.ReadOnly = True
    Me.txtGoodName.Size = New System.Drawing.Size(279, 23)
    Me.txtGoodName.TabIndex = 1
    Me.txtGoodName.TabStop = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(32, 30)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(54, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "ชื่อสินค้า"
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
    Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.AliceBlue
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtUnitDesc)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtGoodName)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtReceAmou)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
    Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
    Me.SplitContainer1.Panel1.Controls.Add(Me.txtSendAmou)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.CornflowerBlue
    Me.SplitContainer1.Panel2.Controls.Add(Me.btnSave)
    Me.SplitContainer1.Size = New System.Drawing.Size(433, 263)
    Me.SplitContainer1.SplitterDistance = 202
    Me.SplitContainer1.TabIndex = 1
    Me.SplitContainer1.TabStop = False
    '
    'frmInvoicePreRece
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(433, 263)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmInvoicePreRece"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "รับสินค้าด่วน"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel1.PerformLayout()
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents txtReceAmou As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtSendAmou As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtGoodName As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtUnitDesc As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents btnSave As System.Windows.Forms.Button
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
End Class
