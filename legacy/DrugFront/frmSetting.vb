Imports System.Drawing.Printing

Public Class frmSetting

  Private Sub frmSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Icon = frmMain.Icon
    ' หา printer ในระบบ
    cboReportPrinterName.Items.Add("no printer")
    For Each mPrinter As String In PrinterSettings.InstalledPrinters
      cboReportPrinterName.Items.Add(mPrinter)
    Next
    cboReportPrinterName.SelectedIndex = 0

    ShowSetting()

    CheckPriv()
  End Sub

  Private Sub CheckPriv()
    ' Add or Edit
    If InStr(pUserPriv, Me.Tag.ToString & "A") OrElse InStr(pUserPriv, Me.Tag.ToString & "E") > 0 Then
      btnSave.Enabled = True
    Else
      btnSave.Enabled = False
    End If
  End Sub

  Private Sub ShowSetting()
    Dim mReportPrinterName As String

    mReportPrinterName = Microsoft.Win32.Registry.GetValue(pRegistry, "DefaultReportPrinterName", "").ToString
    If mReportPrinterName = "" Then mReportPrinterName = "no printer"
    cboReportPrinterName.Text = mReportPrinterName

    nudPOSNo.Text = Microsoft.Win32.Registry.GetValue(pRegistry, "POSNo", "1")
    txtPOSNumber.Text = Microsoft.Win32.Registry.GetValue(pRegistry, "POSNumber", "xxxxx")
  End Sub

  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    Microsoft.Win32.Registry.SetValue(pRegistry, "DefaultReportPrinterName", cboReportPrinterName.Text)
    Microsoft.Win32.Registry.SetValue(pRegistry, "POSNo", nudPOSNo.Text)
    Microsoft.Win32.Registry.SetValue(pRegistry, "POSNumber", txtPOSNumber.Text)

    pDefaultReportPrinterName = cboReportPrinterName.Text
    pPOSNo = nudPOSNo.Text
    pPOSNumber = txtPOSNumber.Text

    Me.Close()
  End Sub
End Class