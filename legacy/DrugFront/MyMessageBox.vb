Public Class MyMessageBox

  Dim mTitle As String
  Dim mMessage As String
  Dim mButtons As MessageBoxButtons
  Dim mDefaultButton As MessageBoxDefaultButton
  Dim mIcon As MessageBoxIcon

  ' enter parameter when create
  Sub New(ByVal message As String, ByVal title As String, ByVal button As MessageBoxButtons, ByVal icon As MessageBoxIcon, Optional ByVal defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button2)
    InitializeComponent()
    mMessage = message
    mTitle = title
    mButtons = button
    mDefaultButton = defaultButton
    mIcon = icon
  End Sub

  Private Sub MyMessageBox_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    If Me.DialogResult = Windows.Forms.DialogResult.Cancel AndAlso btnNo.Visible = True Then
      Me.DialogResult = Windows.Forms.DialogResult.No
    End If
  End Sub

  Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Icon = frmMain.Icon

    Me.Text = mTitle
    lblMessage.Text = mMessage
    ' adjust form height when label height increase
    Dim mFormHeight As Integer
    mFormHeight = lblMessage.Height + 90
    ' not more than 500 and not less than current height
    If mFormHeight > Me.Height Then
      If mFormHeight > 500 Then
        Me.Height = 500
      Else
        Me.Height = mFormHeight
      End If
    End If

    Select Case mButtons
      Case MessageBoxButtons.OKCancel
        btnYes.Visible = False
        btnNo.Visible = False
        btnOk.Visible = True
        btnCancel.Visible = True
        Select Case mDefaultButton
          Case MessageBoxDefaultButton.Button1
            btnOk.Select()
          Case Else
            btnCancel.Select()
        End Select
      Case MessageBoxButtons.YesNo
        btnYes.Visible = True
        btnNo.Visible = True
        btnOk.Visible = False
        btnCancel.Visible = False
        Select Case mDefaultButton
          Case MessageBoxDefaultButton.Button1
            btnYes.Select()
          Case Else
            btnNo.Select()
        End Select
      Case MessageBoxButtons.YesNoCancel
        btnYes.Visible = True
        btnNo.Visible = True
        btnOk.Visible = False
        btnCancel.Visible = True
        Select Case mDefaultButton
          Case MessageBoxDefaultButton.Button1
            btnYes.Select()
          Case MessageBoxDefaultButton.Button2
            btnNo.Select()
          Case Else
            btnCancel.Select()
        End Select
      Case MessageBoxButtons.OK
        btnYes.Visible = False
        btnNo.Visible = False
        btnOk.Visible = True
        btnCancel.Visible = False
      Case Else
        btnYes.Visible = False
        btnNo.Visible = False
        btnOk.Visible = True
        btnCancel.Visible = False
    End Select

    Select Case mIcon
      Case MessageBoxIcon.Error
        picShow.Image = picError.Image
        Me.BackColor = Color.FromArgb(253, 238, 200)
      Case MessageBoxIcon.Question
        picShow.Image = picQuestion.Image
        Me.BackColor = Color.FromArgb(210, 234, 199)
      Case MessageBoxIcon.Warning
        picShow.Image = picWarning.Image
        Me.BackColor = Color.FromArgb(241, 164, 113)
      Case MessageBoxIcon.Information
        picShow.Image = picInformation.Image
        Me.BackColor = Color.FromArgb(217, 229, 254)
      Case MessageBoxIcon.Stop
        picShow.Image = picStop.Image
        Me.BackColor = Color.FromArgb(242, 194, 193)
      Case MessageBoxIcon.Exclamation
        picShow.Image = picWarning.Image
        Me.BackColor = Color.FromArgb(248, 209, 184)
      Case MessageBoxIcon.None
        picShow.Image = Nothing
      Case Else
        picShow.Image = Nothing
    End Select
  End Sub

  Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
    Me.DialogResult = Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub

  Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    Me.DialogResult = Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click
    Me.DialogResult = Windows.Forms.DialogResult.Yes
    Me.Close()
  End Sub

  Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
    Me.DialogResult = Windows.Forms.DialogResult.No
    Me.Close()
  End Sub
End Class