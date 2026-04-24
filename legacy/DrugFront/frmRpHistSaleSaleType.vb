Imports CrystalDecisions.Shared

Public Class frmRpHistSaleSaleType

  Dim mCustCode As String
  Dim mEmplCode As String

  Private Sub frmRpHistSaleSaleType_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    Me.WindowState = FormWindowState.Normal
  End Sub

  Private Sub frmRpHistSaleSaleType_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    dtpFrom.Value = Date.Today
    dtpTo.Value = Date.Today
    CheckPriv()
  End Sub

  Private Sub CheckPriv()
    If InStr(pUserPriv, Me.Tag.ToString & "V") > 0 Then
      btnShow.Enabled = True
    Else
      btnShow.Enabled = False
    End If
  End Sub

  Private Sub ViewReport()
    Me.Cursor = Cursors.WaitCursor

    Dim ds As New DataSet("dsDrug")
    Dim dt As New DataTable("dtHistSaleType")
    Dim dr As DataRow

    dt.Columns.Add("branchZoneDesc", Type.GetType("System.String"))
    dt.Columns.Add("branchName", Type.GetType("System.String"))
    dt.Columns.Add("saleDate", Type.GetType("System.String"))
    dt.Columns.Add("saleDateSort", Type.GetType("System.String"))
    dt.Columns.Add("salePriceType", Type.GetType("System.String"))
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

    mSqlText = "Select BI.branchName as groupName"

    If radDay.Checked = True Then
      mSqlText = mSqlText & ", HS.saleDate, HS.salePriceType"
      mCondition = "รายวัน"
    Else
      If radMonth.Checked = True Then
        mSqlText = mSqlText & ", Month(HS.saleDate) as salemonth, Year(HS.saleDate) as saleYear, HS.salePriceType"
        mCondition = "รายเดือน"
      Else
        mSqlText = mSqlText & ", Datepart(q, HS.saleDate) as saleQuarter, Year(HS.saleDate) as saleYear, HS.salePriceType"
        mCondition = "รายไตรมาส"
      End If
    End If

    'mSqlText = mSqlText & ", SUM((SL.goodAmou * SL.unitPrice) - (SL.goodAmou * SL.unitPrice * HS.perCharge) - SL.subDisc) AS totalSale, SUM(SL.goodAmou * SL.unitCost) As totalCost, Count(Distinct HS.saleNumb) AS totalBill FROM saleList SL INNER JOIN HistSale HS on SL.saleNumb = HS.saleNumb Right outer join BranchInfo BI On BI.branchCode = HS.branchCode inner join BranchZoneInfo BZ on BZ.branchZoneCode = BI.branchZoneCode Where HS.saleDate >= '" & MDYStr(dtpFrom.Value) & "' and HS.saleDate <= '" & MDYStr(dtpTo.Value) & "' and HS.saleStat <> '0' and HS.branchCode = '" & pBranchCode & "'"
    mSqlText = mSqlText & ", SUM((SL.goodAmou * SL.unitPrice) - (SL.goodAmou * SL.unitPrice * HS.perCharge)) AS totalSale, SUM(SL.subDisc) AS totalDisc, SUM(SL.goodAmou * SL.unitCost) As totalCost, Count(Distinct HS.saleNumb) AS totalBill FROM saleList SL INNER JOIN HistSale HS on SL.saleNumb = HS.saleNumb Right outer join BranchInfo BI On BI.branchCode = HS.branchCode inner join BranchZoneInfo BZ on BZ.branchZoneCode = BI.branchZoneCode Where HS.saleDate >= '" & MDYStr(dtpFrom.Value) & "' and HS.saleDate <= '" & MDYStr(dtpTo.Value) & "' and HS.saleStat <> '0' and HS.branchCode = '" & pBranchCode & "'"

    ' รวมสวัสดิการ
    If chkWelFare.Checked = False Then
      mSqlText = mSqlText & " AND HS.custType <> '2'"
    Else
      mCondition = mCondition & " (" & chkWelFare.Text & ")"
    End If

    mSqlText = mSqlText & " Group by BI.branchName"

    If radDay.Checked = True Then
      mSqlText = mSqlText & ", HS.saleDate, HS.salePriceType"
    Else
      If radMonth.Checked = True Then
        mSqlText = mSqlText & ", Month(HS.saleDate), Year(HS.saleDate), HS.salePriceType"
      Else
        mSqlText = mSqlText & ", Datepart(q, HS.saleDate), Year(HS.saleDate), HS.salePriceType"
      End If
    End If

    If chkIncludeDisc.Checked = True Then
      mCondition = mCondition & " (" & chkIncludeDisc.Text & ")"
    End If

    ds2 = pService.SelectData("Drug", mSqlText)

    If IsNothing(ds2) = False Then
      Dim dv As New DataView(ds2.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dr = ds.Tables(0).NewRow

          dr("branchName") = .Item("groupName")

          If radDay.Checked = True Then
            dr("saleDate") = CDate(.Item("saleDate")).ToString("dd'/'MM'/'yyyy")
            dr("saleDateSort") = CDate(.Item("saleDate")).ToString("yyyy'/'MM'/'dd")
          Else
            If radMonth.Checked = True Then
              dr("saleDate") = Format(.Item("saleMonth"), "0#") & " / " & (CInt(.Item("saleYear")) + 543).ToString
              dr("saleDateSort") = (CInt(.Item("saleYear")) + 543).ToString & " / " & Format(.Item("saleMonth"), "0#")
            Else
              dr("saleDate") = Format(.Item("saleQuarter"), "0#") & " - " & (CInt(.Item("saleYear")) + 543).ToString
              dr("saleDateSort") = (CInt(.Item("saleYear")) + 543).ToString & " - " & Format(.Item("saleQuarter"), "0#")
            End If
          End If

          If .Item("salePriceType").ToString = "R" Then
            dr("salePriceType") = "ขายปลีก"
          Else
            dr("salePriceType") = "ขายส่ง"
          End If

          If chkIncludeDisc.Checked = True Then
            dr("totalSale") = .Item("totalSale")
          Else
            dr("totalSale") = CDbl(.Item("totalSale")) - CDbl(.Item("totalDisc"))
          End If

          dr("totalCost") = .Item("totalCost")
          dr("totalBill") = .Item("totalBill")
        End With
        ds.Tables(0).Rows.Add(dr)
      Next
      dv = Nothing
    End If
    ds2 = Nothing

    Dim mReport As New rpHistSaleSaleType
    mReport.SetDataSource(ds)
    mReport.SetParameterValue("prCompFullName", pCompFullName)
    mReport.SetParameterValue("prCondition", mCondition)
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

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select saleNumb, custType from HistSale where saleDate >= '1/1/2017' and branchCode = '150' and custType = '4'")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        Dim mSqlText(dv.Count) As String
        Dim mLine As Integer = 0
        For i As Integer = 0 To dv.Count - 1
          With dv.Item(i)
            mSqlText(mLine) = "Update HistSale set salePriceType = 'W' where saleNumb = '" & .Item("saleNumb").ToString & "'"
            mLine += 1
          End With
        Next
        Dim mUpdate As String
        mUpdate = pService.UpdateData("Drug", mSqlText)
        If mUpdate <> "1" Then
          MessageBox.Show(mUpdate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
      End If
    End If
  End Sub
End Class