Imports CrystalDecisions.Shared

Public Class frmRpHistSaleCustType

  Dim mCustCode As String
  Dim mEmplCode As String

  Private Sub frmRpHistSaleCustType_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    Me.WindowState = FormWindowState.Normal
  End Sub

  Private Sub frmRpHistSaleCustType_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    dtpFrom.Value = Date.Today
    dtpTo.Value = Date.Today
    ShowCustType()
    CheckPriv()
  End Sub

  Private Sub CheckPriv()
    If InStr(pUserPriv, Me.Tag.ToString & "V") > 0 Then
      btnShow.Enabled = True
    Else
      btnShow.Enabled = False
    End If
  End Sub

  Private Sub ShowCustType()
    cboCustTypeDesc.Items.Clear()
    cboCustTypeCode.Items.Clear()
    cboCustTypeDesc.Items.Add("ทั้งหมด")
    cboCustTypeCode.Items.Add("0")
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "SELECT * FROM CustType ORDER BY custTypeDesc")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        For i As Integer = 0 To dv.Count - 1
          cboCustTypeDesc.Items.Add(dv.Item(i).Item("custTypeDesc").ToString)
          cboCustTypeCode.Items.Add(dv.Item(i).Item("custTypeCode").ToString)
        Next
      End If
      dv = Nothing
    End If
    ds = Nothing
    cboCustTypeDesc.SelectedIndex = 0
  End Sub

  Private Sub cboCustTypeDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustTypeDesc.SelectedIndexChanged
    cboCustTypeCode.SelectedIndex = cboCustTypeDesc.SelectedIndex
  End Sub

  Private Sub ViewReport()
    Me.Cursor = Cursors.WaitCursor

    Dim ds As New DataSet("dsDrug")
    Dim dt As New DataTable("dtHistSaleSum")
    Dim dr As DataRow

    dt.Columns.Add("branchName", Type.GetType("System.String"))
    dt.Columns.Add("saleDate", Type.GetType("System.String"))
    dt.Columns.Add("saleDateSort", Type.GetType("System.String"))
    dt.Columns.Add("custTypeDesc", Type.GetType("System.String"))
    dt.Columns.Add("totalSale", Type.GetType("System.Double"))
    dt.Columns.Add("totalCost", Type.GetType("System.Double"))
    dt.Columns.Add("totalBill", Type.GetType("System.Int32"))

    ds.Tables.Add(dt)

    Dim mSqlText As String
    Dim mCondition As String = ""
    Dim mSuppress As String
    Dim ds2 As New DataSet

    If radTotal.Checked = True Then
      mSuppress = "1"
    Else
      mSuppress = "0"
    End If

    If radDay.Checked = True Then
      mSqlText = "SELECT BI.branchName , HS.saleDate, CT.custTypeDesc, SUM((SL.goodAmou * SL.unitPrice) - (SL.goodAmou * SL.unitPrice * HS.perCharge) - SL.subDisc) AS totalSale, SUM(SL.goodAmou * SL.unitCost) As totalCost, Count(Distinct HS.saleNumb) AS totalBill FROM saleList SL INNER JOIN HistSale HS on SL.saleNumb = HS.saleNumb Right outer join BranchInfo BI On BI.branchCode = HS.branchCode inner join CustType CT on CT.custTypeCode = HS.custType Where HS.saleDate >= '" & MDYStr(dtpFrom.Value) & "' and HS.saleDate <= '" & MDYStr(dtpTo.Value) & "' and HS.saleStat <> '0' and HS.branchCode = '" & pBranchCode & "'"
    Else
      mSqlText = "SELECT BI.branchName , Month(HS.saleDate) as salemonth, Year(HS.saleDate) as saleYear, CT.custTypeDesc, SUM((SL.goodAmou * SL.unitPrice) - (SL.goodAmou * SL.unitPrice * HS.perCharge) - SL.subDisc) AS totalSale, SUM(SL.goodAmou * SL.unitCost) As totalCost, Count(Distinct HS.saleNumb) AS totalBill FROM saleList SL INNER JOIN HistSale HS on SL.saleNumb = HS.saleNumb Right outer join BranchInfo BI On BI.branchCode = HS.branchCode inner join CustType CT on CT.custTypeCode = HS.custType Where HS.saleDate >= '" & MDYStr(dtpFrom.Value) & "' and HS.saleDate <= '" & MDYStr(dtpTo.Value) & "' and HS.saleStat <> '0' and HS.branchCode = '" & pBranchCode & "'"
    End If

    If cboCustTypeDesc.Text <> "ทั้งหมด" Then
      mSqlText = mSqlText & " and CT.custTypeCode = '" & cboCustTypeCode.Text & "'"
    End If

    If radDay.Checked = True Then
      mSqlText = mSqlText & " GROUP BY BI.branchName, HS.saleDate, CT.custTypeDesc"
    Else
      mSqlText = mSqlText & " GROUP BY BI.branchName, Month(HS.saleDate), Year(HS.saleDate), CT.custTypeDesc"
    End If

    pService.Timeout = 2000000
    ds2 = pService.SelectData2("Drug", mSqlText)
    pService.Timeout = 200000

    If IsNothing(ds2) = False Then
      Dim dv As New DataView(ds2.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dr = ds.Tables(0).NewRow

          dr("branchName") = .Item("branchName")

          If radDay.Checked = True Then
            dr("saleDate") = CDate(.Item("saleDate")).ToString("dd'/'MM'/'yyyy")
            dr("saleDateSort") = CDate(.Item("saleDate")).ToString("yyyy'/'MM'/'dd")
          Else
            dr("saleDate") = Format(.Item("saleMonth"), "0#") & " / " & (CInt(.Item("saleYear")) + 543).ToString
            dr("saleDateSort") = (CInt(.Item("saleYear")) + 543).ToString & " / " & Format(.Item("saleMonth"), "0#")
          End If

          dr("custTypeDesc") = .Item("custTypeDesc")
          dr("totalSale") = .Item("totalSale")
          dr("totalCost") = .Item("totalCost")
          dr("totalBill") = .Item("totalBill")
        End With
        ds.Tables(0).Rows.Add(dr)
      Next
      dv = Nothing
    End If
    ds2 = Nothing

    Dim mReport As New rpHistSaleCustType
    mReport.SetDataSource(ds)
    mReport.SetParameterValue("prCompFullName", pCompFullName)
    mReport.SetParameterValue("prBetween", "ตั้งแต่วันที่ " & ThaiDate(dtpFrom.Value) & "  ถึงวันที่ " & ThaiDate(dtpTo.Value))
    mReport.SetParameterValue("prSuppress", mSuppress)

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

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub btnShow_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    If pDefaultReportPrinterName <> "" AndAlso pDefaultReportPrinterName <> "no printer" Then
      ViewReport()
    Else
      pMessageBox = New MyMessageBox("ยังไม่ได้กำหนดเครื่องพิมพ์", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      pMessageBox.ShowDialog()
    End If
  End Sub
End Class