Public Class frmRpHistReturn

  Dim mThreadReport As Threading.Thread
  Dim ds As DataSet

  Private Sub frmRpHistReturn_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    Me.WindowState = FormWindowState.Normal
  End Sub

  Private Sub frmRpHistReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Icon = frmMain.Icon

    CheckPriv()
  End Sub

  Private Sub CheckPriv()
    ' Print
    If InStr(pUserPriv, Me.Tag.ToString & "V") > 0 Then
      btnShow.Enabled = True
    Else
      btnShow.Enabled = False
    End If
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    If pDefaultReportPrinterName <> "" AndAlso pDefaultReportPrinterName <> "no printer" Then
      Me.Cursor = Cursors.WaitCursor

      Dim mSqlText As String
      mSqlText = "Select HB.retuNumb, HB.retuDate, GB.barCode, GI.goodName, BL.goodAmou, BL.unitPrice, BL.retuRema  from HistBranchReturn HB inner join BranchReturnList BL on HB.retuNumb = BL.retuNumb inner join GoodInfo GI on BL.goodCode = GI.goodCode inner join UnitInfo UI on BL.unitCode = UI.unitCode left outer join (SELECT DISTINCT goodCode, barCode FROM GoodBarcode WHERE LEN(barCode) = '6' AND goodAmou = 1) GB on GB.goodCode = BL.goodCode Where HB.retuDate >= '" & MDYStr(dtpFrom.Value) & "' and HB.retuDate <= '" & MDYStr(dtpTo.Value) & "' and HB.branchCode = '" & pBranchCode & "'"

      btnShow.Visible = False
      'btnCancel.Visible = True

      mThreadReport = New Threading.Thread(AddressOf ThreadQuery)
      mThreadReport.IsBackground = True
      mThreadReport.Start(mSqlText)

      Me.Cursor = Cursors.Default
    Else
      pMessageBox = New MyMessageBox("ยังไม่ได้กำหนดเครื่องพิมพ์", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      pMessageBox.ShowDialog()
    End If
  End Sub

  Private Sub ThreadQuery(ByVal SqlText As Object)
    Dim mSqlText As String
    mSqlText = CStr(SqlText)

    ds = New DataSet("dsDrug")

    Dim dt As New DataTable("dtHistBranchReturn")
    Dim dr As DataRow

    dt.Columns.Add("retuNumb", Type.GetType("System.String"))
    dt.Columns.Add("retuDate", Type.GetType("System.DateTime"))
    dt.Columns.Add("barCode", Type.GetType("System.String"))
    dt.Columns.Add("goodName", Type.GetType("System.String"))
    dt.Columns.Add("goodAmou", Type.GetType("System.Int32"))
    dt.Columns.Add("unitPrice", Type.GetType("System.Double"))
    dt.Columns.Add("retuRema", Type.GetType("System.String"))

    ds.Tables.Add(dt)

    Dim ds2 As New DataSet

    Try
      ds2 = pService.SelectData("Drug", mSqlText)
    Catch ex As Exception
      MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
      Exit Sub
    Finally
      'pService.Timeout = 100000
    End Try

    If IsNothing(ds2) = False Then
      Dim dv As New DataView(ds2.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dr = ds.Tables(0).NewRow
          dr("retuNumb") = .Item("retuNumb")
          dr("retuDate") = .Item("retuDate")
          dr("barCode") = .Item("barCode")
          dr("goodName") = .Item("goodName")
          dr("goodAmou") = .Item("goodAmou")
          dr("unitPrice") = .Item("unitPrice")
          dr("retuRema") = .Item("retuRema")
        End With
        ds.Tables(0).Rows.Add(dr)
      Next
      dv = Nothing
    End If
    ds2 = Nothing

    Call ViewReport()
  End Sub

  Private Sub ViewReport()
    ' เพื่อให้ควบคุม control ต่างๆ ได้
    If Me.InvokeRequired Then
      Me.Invoke(New MethodInvoker(AddressOf ViewReport))
    Else
      ' สั่งควบคุม control
      btnShow.Visible = True
      btnCancel.Visible = False

      'Call ViewReport()
      If IsNothing(ds) = False Then
        Dim mReport As New rpHistBranchReturn
        mReport.SetDataSource(ds)
        mReport.SetParameterValue("prCompFullName", pCompFullName)
        mReport.SetParameterValue("prBranchName", "สาขา " & pBranchName)
        mReport.SetParameterValue("prBetweenDate", "ตั้งแต่วันที่ " & dtpFrom.Value.ToString("d/M/yyyy") & " ถึงวันที่ " & dtpTo.Value.ToString("d/M/yyyy"))
        mReport.PrintOptions.PrinterName = pDefaultReportPrinterName

        Dim mView As New frmViewReport
        mView.MdiParent = frmMain
        mView.pTitle = Me.Text
        mView.ctrView.ReportSource = mReport
        mView.Show()

        If InStr(pUserPriv, Me.Tag.ToString & "P") > 0 Then
          mView.ctrView.ShowPrintButton = True
        Else
          mView.ctrView.ShowPrintButton = False
        End If
        If InStr(pUserPriv, Me.Tag.ToString & "X") > 0 Then
          mView.ctrView.ShowExportButton = True
        Else
          mView.ctrView.ShowExportButton = False
        End If

      Else
        MessageBox.Show("ไม่สามารถรายงานผลได้")
      End If
    End If
  End Sub

  Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    mThreadReport.Abort()
  End Sub
End Class