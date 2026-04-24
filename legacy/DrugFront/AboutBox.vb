Public NotInheritable Class AboutBox

  Dim mPicNo As Integer

  Private Sub AboutBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.Escape Then
      Me.Close()
    End If
  End Sub

    Private Sub AboutBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    LogoPictureBox.Image = My.Resources.HealthUp4
    mPicNo = 1
    ' Set the title of the form.
    Dim ApplicationTitle As String
    If My.Application.Info.Title <> "" Then
      ApplicationTitle = My.Application.Info.Title
    Else
      ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
    End If

    Me.Text = String.Format("About {0}", ApplicationTitle)
    ' Initialize all of the text displayed on the About Box.
    ' TODO: Customize the application's assembly information in the "Application" pane of the project 
    ' properties dialog (under the "Project" menu).
    Me.LabelProductName.Text = My.Application.Info.ProductName
    Me.LabelVersion.Text = String.Format("Versi0n {0}", Application.ProductVersion)
    Me.LabelCopyright.Text = My.Application.Info.Copyright
    '    Me.LabelCompanyName.Text = My.Application.Info.CompanyName
    Me.lblLicensedTo.Text = "Licensed to : " & pCompName & " สาขา " & pBranchName
    Me.labelDevelopBy.Text = "Developed by : Thana Yanisarapan - thanagrup@gmail.com"
    'Me.TextBoxDescription.Text = My.Application.Info.Description
    End Sub

  Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    If mPicNo = 1 Then
      LogoPictureBox.Image = My.Resources.HealthUp2
      mPicNo = 2
    Else
      If mPicNo = 2 Then
        LogoPictureBox.Image = My.Resources.HealthUp3
        mPicNo = 3
      Else
        If mPicNo = 3 Then
          LogoPictureBox.Image = My.Resources.HealthUp1
          mPicNo = 4
        Else
          If mPicNo = 4 Then
            LogoPictureBox.Image = My.Resources.HealthUp4
            mPicNo = 1
          End If
        End If
      End If
    End If
  End Sub

  Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
    Timer2.Enabled = False
  End Sub

  Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
    If lblLicensedTo.ForeColor = Color.DarkGreen Then
      lblLicensedTo.ForeColor = Color.LimeGreen
    Else
      lblLicensedTo.ForeColor = Color.DarkGreen
      Timer3.Enabled = False
    End If
  End Sub

  Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
    If lblSmile.Visible = False Then
      lblSmile.Visible = True
    Else
      lblSmile.Visible = False
      Timer4.Enabled = False
    End If
  End Sub
End Class
