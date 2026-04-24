Imports CrystalDecisions.Shared

Public Class frmRpFCSale

  Private Sub frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    dtpStart.Value = Date.Today
    dtpEnd.Value = Date.Today

    CheckPriv()
  End Sub

  Private Sub CheckPriv()
    If InStr(pUserPriv, Me.Tag.ToString & "V") > 0 Then
      btnShow.Enabled = True
    Else
      btnShow.Enabled = False
    End If
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    ViewReport()
  End Sub

  Private Sub ViewReport()
    Me.Cursor = Cursors.WaitCursor

    Dim ds As New DataSet("dsDrug")
    Dim dt As New DataTable("dtFCSale")
    Dim dr As DataRow

    dt.Columns.Add("salePeriod", Type.GetType("System.String"))
    dt.Columns.Add("totalSale", Type.GetType("System.Double"))
    dt.Columns.Add("totalCost", Type.GetType("System.Double"))
    dt.Columns.Add("totalBill", Type.GetType("System.Int32"))
    dt.Columns.Add("avgBill", Type.GetType("System.Double"))
    dt.Columns.Add("perGP", Type.GetType("System.Double"))

    ds.Tables.Add(dt)

    Dim ds2 As New DataSet
    Dim mSqlText As String
    Dim mPeriod As String

    If radDay.Checked = True Then
      mPeriod = radDay.Text
      mSqlText = mSqlText & "Select HS.saleDate"
    Else
      If radMonth.Checked = True Then
        mPeriod = radMonth.Text
        mSqlText = mSqlText & "Select MONTH(HS.saleDate) AS saleMonth, YEAR(HS.saleDate) AS saleYear"
      Else
        mPeriod = radQuarter.Text
        mSqlText = mSqlText & "Select Datepart(q,HS.saleDate) AS saleQuarter, Year(HS.saleDate) As saleYear"
      End If
    End If

    mSqlText = mSqlText & ", sum(SL.goodAmou * SL.unitPrice - SL.subDisc) as totalSale, sum(SL.goodAmou * UI.unitFactor * SL.unitCost) as totalCost, sum(SL.goodAmou * UI.unitFactor * SL.unitCost * GI.fcCostFactor) as totalFCCost, Count(distinct HS.saleNumb) AS totalBill from SaleList SL inner join GoodInfo GI on GI.goodCode = SL.goodCode inner join UnitInfo UI on UI.unitCode = SL.unitCode inner join HistSale HS on HS.saleNumb = SL.saleNumb inner join BranchInfo BI on BI.branchCode = HS.branchCode Where HS.saleStat <> '0' and HS.saleDate >= '" & MDYStr(dtpStart.Value) & "' AND HS.saleDate <= '" & MDYStr(dtpEnd.Value) & "' and BI.branchCode = '" & pBranchCode & "' and BI.isFranchise = '1'"

    ' รวมสวัสดิการ
    If chkWelFare.Checked = False Then
      mSqlText = mSqlText & " AND HS.custType <> '2'"
    End If

    If radDay.Checked = True Then
      mSqlText = mSqlText & " Group by HS.saleDate"
    Else
      If radMonth.Checked = True Then
        mSqlText = mSqlText & " Group by MONTH(HS.saleDate), YEAR(HS.saleDate)"
      Else
        mSqlText = mSqlText & " Group by Datepart(q,HS.saleDate), Year(HS.saleDate)"
      End If
    End If

    ds2 = pService.SelectData2("Drug", mSqlText)

    If IsNothing(ds2) = False Then
      Dim dv As New DataView(ds2.Tables(0))
      Dim mTotalCost As Double
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dr = ds.Tables(0).NewRow
          If radDay.Checked = True Then
            dr("salePeriod") = CDate(.Item("saleDate")).ToString("dd/MM/yyyy")
          Else
            If radMonth.Checked = True Then
              dr("salePeriod") = .Item("saleMonth").ToString & "-" & (CInt(.Item("saleYear")) + 543).ToString
            Else
              dr("salePeriod") = .Item("saleQuarter").ToString & "-" & (CInt(.Item("saleYear")) + 543).ToString
            End If
          End If

          dr("totalSale") = .Item("totalSale")

          If pIsFranchise = "1" And pBranchTypeCode = "2" Then ' เฉพาะสาขาแฟรนไชส์ partner ship
            mTotalCost = .Item("totalFCCost")
          Else
            mTotalCost = .Item("totalCost")
          End If

          dr("totalCost") = mTotalCost
          If .Item("totalSale") > 0 Then
            dr("perGP") = (.Item("totalSale") - mTotalCost) * 100 / .Item("totalSale")
          End If

          dr("totalBill") = .Item("totalBill")
          If .Item("totalBill") > 0 Then
            dr("avgBill") = .Item("totalSale") / .Item("totalBill")
          Else
            dr("avgBill") = 0
          End If
        End With
        ds.Tables(0).Rows.Add(dr)
      Next
      dv = Nothing
    End If
    ds2 = Nothing

    Dim mreport As New rpFCSale
    mreport.SetDataSource(ds)
    mreport.SetParameterValue("prCompName", pCompFullName)
    mreport.SetParameterValue("prBranchName", "สาขา " & pBranchName)
    mreport.SetParameterValue("prPeriodRange", "งวด " & dtpStart.Value.ToString("d MMMM yyyy") & " - " & dtpEnd.Value.ToString("d MMMM yyyy"))
    mreport.SetParameterValue("prPeriod", mPeriod)
    If chkWelFare.Checked = True Then
      mreport.SetParameterValue("prWelFare", "** รวมสวัสดิการ **")
    Else
      mreport.SetParameterValue("prWelFare", "")
    End If

    Dim mView As New frmViewReport
    mView.MdiParent = frmMain
    mView.pTitle = Me.Text
    mView.ctrView.ReportSource = mreport
    mView.Show()

    'If InStr(pUserPriv, Me.Tag.ToString & "P") > 0 Then
    '  mView.ctrView.ShowPrintButton = True
    'Else
    '  mView.ctrView.ShowPrintButton = False
    'End If
    'If InStr(pUserPriv, Me.Tag.ToString & "X") > 0 Then
    '  mView.ctrView.ShowExportButton = True
    'Else
    '  mView.ctrView.ShowExportButton = False
    'End If

    Me.Cursor = Cursors.Default
  End Sub
End Class