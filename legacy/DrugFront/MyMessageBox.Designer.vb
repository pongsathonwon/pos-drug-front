<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyMessageBox
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MyMessageBox))
    Me.btnOk = New System.Windows.Forms.Button
    Me.btnCancel = New System.Windows.Forms.Button
    Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
    Me.btnNo = New System.Windows.Forms.Button
    Me.btnYes = New System.Windows.Forms.Button
    Me.lblMessage = New System.Windows.Forms.Label
    Me.picShow = New System.Windows.Forms.PictureBox
    Me.picQuestion = New System.Windows.Forms.PictureBox
    Me.picWarning = New System.Windows.Forms.PictureBox
    Me.picError = New System.Windows.Forms.PictureBox
    Me.picInformation = New System.Windows.Forms.PictureBox
    Me.picStop = New System.Windows.Forms.PictureBox
    Me.FlowLayoutPanel1.SuspendLayout()
    CType(Me.picShow, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.picQuestion, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.picWarning, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.picError, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.picInformation, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.picStop, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'btnOk
    '
    Me.btnOk.Location = New System.Drawing.Point(207, 3)
    Me.btnOk.Name = "btnOk"
    Me.btnOk.Size = New System.Drawing.Size(75, 25)
    Me.btnOk.TabIndex = 1
    Me.btnOk.Text = "Ok"
    Me.btnOk.UseVisualStyleBackColor = True
    '
    'btnCancel
    '
    Me.btnCancel.Location = New System.Drawing.Point(288, 3)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(75, 25)
    Me.btnCancel.TabIndex = 0
    Me.btnCancel.Text = "Cancel"
    Me.btnCancel.UseVisualStyleBackColor = True
    '
    'FlowLayoutPanel1
    '
    Me.FlowLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.FlowLayoutPanel1.Controls.Add(Me.btnCancel)
    Me.FlowLayoutPanel1.Controls.Add(Me.btnOk)
    Me.FlowLayoutPanel1.Controls.Add(Me.btnNo)
    Me.FlowLayoutPanel1.Controls.Add(Me.btnYes)
    Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
    Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 111)
    Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
    Me.FlowLayoutPanel1.Size = New System.Drawing.Size(366, 32)
    Me.FlowLayoutPanel1.TabIndex = 4
    '
    'btnNo
    '
    Me.btnNo.Location = New System.Drawing.Point(126, 3)
    Me.btnNo.Name = "btnNo"
    Me.btnNo.Size = New System.Drawing.Size(75, 25)
    Me.btnNo.TabIndex = 2
    Me.btnNo.Text = "No"
    Me.btnNo.UseVisualStyleBackColor = True
    '
    'btnYes
    '
    Me.btnYes.Location = New System.Drawing.Point(45, 3)
    Me.btnYes.Name = "btnYes"
    Me.btnYes.Size = New System.Drawing.Size(75, 25)
    Me.btnYes.TabIndex = 3
    Me.btnYes.Text = "Yes"
    Me.btnYes.UseVisualStyleBackColor = True
    '
    'lblMessage
    '
    Me.lblMessage.AutoSize = True
    Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.lblMessage.Location = New System.Drawing.Point(75, 16)
    Me.lblMessage.MaximumSize = New System.Drawing.Size(300, 0)
    Me.lblMessage.Name = "lblMessage"
    Me.lblMessage.Size = New System.Drawing.Size(59, 16)
    Me.lblMessage.TabIndex = 5
    Me.lblMessage.Text = "message"
    '
    'picShow
    '
    Me.picShow.Location = New System.Drawing.Point(12, 12)
    Me.picShow.Name = "picShow"
    Me.picShow.Size = New System.Drawing.Size(48, 48)
    Me.picShow.TabIndex = 6
    Me.picShow.TabStop = False
    '
    'picQuestion
    '
    Me.picQuestion.Image = CType(resources.GetObject("picQuestion.Image"), System.Drawing.Image)
    Me.picQuestion.Location = New System.Drawing.Point(59, 174)
    Me.picQuestion.Name = "picQuestion"
    Me.picQuestion.Size = New System.Drawing.Size(48, 48)
    Me.picQuestion.TabIndex = 7
    Me.picQuestion.TabStop = False
    Me.picQuestion.Visible = False
    '
    'picWarning
    '
    Me.picWarning.Image = CType(resources.GetObject("picWarning.Image"), System.Drawing.Image)
    Me.picWarning.Location = New System.Drawing.Point(113, 174)
    Me.picWarning.Name = "picWarning"
    Me.picWarning.Size = New System.Drawing.Size(48, 48)
    Me.picWarning.TabIndex = 8
    Me.picWarning.TabStop = False
    Me.picWarning.Visible = False
    '
    'picError
    '
    Me.picError.Image = CType(resources.GetObject("picError.Image"), System.Drawing.Image)
    Me.picError.Location = New System.Drawing.Point(167, 174)
    Me.picError.Name = "picError"
    Me.picError.Size = New System.Drawing.Size(48, 48)
    Me.picError.TabIndex = 9
    Me.picError.TabStop = False
    Me.picError.Visible = False
    '
    'picInformation
    '
    Me.picInformation.Image = CType(resources.GetObject("picInformation.Image"), System.Drawing.Image)
    Me.picInformation.Location = New System.Drawing.Point(221, 174)
    Me.picInformation.Name = "picInformation"
    Me.picInformation.Size = New System.Drawing.Size(48, 48)
    Me.picInformation.TabIndex = 10
    Me.picInformation.TabStop = False
    Me.picInformation.Visible = False
    '
    'picStop
    '
    Me.picStop.Image = CType(resources.GetObject("picStop.Image"), System.Drawing.Image)
    Me.picStop.Location = New System.Drawing.Point(275, 174)
    Me.picStop.Name = "picStop"
    Me.picStop.Size = New System.Drawing.Size(48, 48)
    Me.picStop.TabIndex = 11
    Me.picStop.TabStop = False
    Me.picStop.Visible = False
    '
    'MyMessageBox
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(183, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(394, 146)
    Me.Controls.Add(Me.picStop)
    Me.Controls.Add(Me.picInformation)
    Me.Controls.Add(Me.picError)
    Me.Controls.Add(Me.picWarning)
    Me.Controls.Add(Me.picQuestion)
    Me.Controls.Add(Me.picShow)
    Me.Controls.Add(Me.lblMessage)
    Me.Controls.Add(Me.FlowLayoutPanel1)
    Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "MyMessageBox"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Title"
    Me.FlowLayoutPanel1.ResumeLayout(False)
    CType(Me.picShow, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.picQuestion, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.picWarning, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.picError, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.picInformation, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.picStop, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents btnOk As System.Windows.Forms.Button
  Friend WithEvents btnCancel As System.Windows.Forms.Button
  Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
  Friend WithEvents lblMessage As System.Windows.Forms.Label
  Friend WithEvents picShow As System.Windows.Forms.PictureBox
  Friend WithEvents picQuestion As System.Windows.Forms.PictureBox
  Friend WithEvents picWarning As System.Windows.Forms.PictureBox
  Friend WithEvents picError As System.Windows.Forms.PictureBox
  Friend WithEvents picInformation As System.Windows.Forms.PictureBox
  Friend WithEvents picStop As System.Windows.Forms.PictureBox
  Friend WithEvents btnNo As System.Windows.Forms.Button
  Friend WithEvents btnYes As System.Windows.Forms.Button
End Class
