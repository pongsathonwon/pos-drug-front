Public Class frmRpAccoClose

  Private Sub frmRpAccoClose_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    Me.WindowState = FormWindowState.Normal
  End Sub

  Private Sub frmRpAccoClose_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    dtpFrom.Value = pServerDateTime.Date
    dtpTo.Value = pServerDateTime.Date

    dtgList.Columns("totalCost").Visible = False
    dtgList.Columns("totalProfit").Visible = False
    dtgList.Columns("totalSaleAndDisc").Visible = False

    '' เฉพาะสาขาแฟรนไชส์
    'If pIsFranchise = "1" Then
    '  dtgList.Columns("totalCost").Visible = True
    '  dtgList.Columns("totalProfit").Visible = True
    'Else
    '  dtgList.Columns("totalCost").Visible = False
    '  dtgList.Columns("totalProfit").Visible = False
    'End If

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
    Me.Cursor = Cursors.WaitCursor

    dtgList.Rows.Clear()
    ' ไม่แสดงขายสวัสดิการ
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "SELECT * FROM AccoClose WHERE closeDate >= '" & MDYStr(dtpFrom.Value) & "' AND closeDate <= '" & MDYStr(dtpTo.Value) & "' AND branchCode = '" & pBranchCode & "' ORDER BY closeNumb")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      Dim mSalePerCust As Double
      Dim mTotalSale As Double
      Dim mTotalCost As Double
      Dim mTotalOver As Double
      Dim mTotalCharge As Double

      Dim mTTSale, mTTCash, mTTCredit, mTTDebt, mTTCupong, mTTReturn, mTTCharge, mTTDisc As Double
      Dim mTTPointDisc, mTTExpense, mTTOver, mTTCost As Double
      Dim mTTBill As Integer
      'Dim mAvgGP As Double

      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          'mTotalSale = .Item("totalCash") + .Item("totalCredit") + .Item("totalDebt") + .Item("totalCupong") - .Item("totalReturn") - .Item("totalCharge") + .Item("totalPointDisc")
          ' (ไม่หักค่าธรรมเนียม 11/2561)
          mTotalSale = .Item("totalCash") + .Item("totalCredit") + .Item("totalDebt") + .Item("totalCupong") - .Item("totalReturn") + .Item("totalPointDisc")

          If pIsFranchise = "1" And pBranchTypeCode = "2" Then ' เฉพาะสาขาแฟรนไชส์ partner ship
            mTotalCost = .Item("totalCostFC")
          Else
            mTotalCost = .Item("totalCost")
          End If

          mSalePerCust = mTotalSale / .Item("totalCust")

          mTotalOver = (.Item("totalIndraw") - .Item("totalStart")) - (.Item("totalCash") - .Item("totalReturn") - .Item("totalExpense"))

          mTotalCharge = .Item("totalCharge")

          dtgList.Rows.Add()
          dtgList.Item("closeDate", dtgList.Rows.Count - 1).Value = .Item("closeDate")
          dtgList.Item("totalSale", dtgList.Rows.Count - 1).Value = mTotalSale
          dtgList.Item("totalCash", dtgList.Rows.Count - 1).Value = .Item("totalCash")
          dtgList.Item("totalCredit", dtgList.Rows.Count - 1).Value = .Item("totalCredit")
          dtgList.Item("totalDebt", dtgList.Rows.Count - 1).Value = .Item("totalDebt")
          dtgList.Item("totalCupong", dtgList.Rows.Count - 1).Value = .Item("totalCupong")
          dtgList.Item("totalReturn", dtgList.Rows.Count - 1).Value = .Item("totalReturn")
          dtgList.Item("totalCharge", dtgList.Rows.Count - 1).Value = .Item("totalCharge")
          dtgList.Item("totalDisc", dtgList.Rows.Count - 1).Value = .Item("totalDisc")
          dtgList.Item("totalPointDisc", dtgList.Rows.Count - 1).Value = .Item("totalPointDisc")
          dtgList.Item("totalExpense", dtgList.Rows.Count - 1).Value = .Item("totalExpense")
          dtgList.Item("remainCash", dtgList.Rows.Count - 1).Value = .Item("totalCash") - .Item("totalReturn") - .Item("totalExpense")
          dtgList.Item("cashCount", dtgList.Rows.Count - 1).Value = .Item("totalIndraw") - .Item("totalStart")
          dtgList.Item("totalOver", dtgList.Rows.Count - 1).Value = mTotalOver
          dtgList.Item("totalBill", dtgList.Rows.Count - 1).Value = .Item("totalCust")
          dtgList.Item("totalPerBill", dtgList.Rows.Count - 1).Value = mSalePerCust
          dtgList.Item("totalCost", dtgList.Rows.Count - 1).Value = mTotalCost
          dtgList.Item("totalSaleAndDisc", dtgList.Rows.Count - 1).Value = mTotalSale + .Item("totalDisc")
          dtgList.Item("totalProfit", dtgList.Rows.Count - 1).Value = mTotalSale - mTotalCost

          'dtgList.Item("perGP", dtgList.Rows.Count - 1).Value = (mTotalSale - mTotalCost) * 100 / mTotalSale
          ' ให้แสดง GP โดยคิดรวมส่วนลดด้วย
          If mTotalSale > 0 And mTotalCost > 0 Then
            'dtgList.Item("perGP", dtgList.Rows.Count - 1).Value = (mTotalSale - mTotalCost) * 100 / mTotalSale
            dtgList.Item("perGP", dtgList.Rows.Count - 1).Value = (mTotalSale + .Item("totalDisc") - mTotalCost) * 100 / (mTotalSale + .Item("totalDisc"))
          Else
            dtgList.Item("perGP", dtgList.Rows.Count - 1).Value = "-"
          End If

          mTTCash += .Item("totalCash")
          mTTCredit += .Item("totalCredit")
          mTTDebt += .Item("totalDebt")
          mTTCupong += .Item("totalCupong")
          mTTReturn += .Item("totalReturn")
          mTTCharge += .Item("totalCharge")
          mTTDisc += .Item("totalDisc")
          mTTPointDisc += .Item("totalPointDisc")
          mTTExpense += .Item("totalExpense")
          mTTBill += .Item("totalCust")
          mTTOver += mTotalOver
          mTTCost += mTotalCost
          mTTSale += mTotalSale

        End With
      Next
      dv = Nothing
      ' รวม
      If dtgList.Rows.Count > 0 Then
        dtgList.Rows.Add()
        dtgList.Item("closeDate", dtgList.Rows.Count - 1).Value = "รวม"
        dtgList.Item("totalSale", dtgList.Rows.Count - 1).Value = mTTSale
        dtgList.Item("totalCash", dtgList.Rows.Count - 1).Value = mTTCash
        dtgList.Item("totalCredit", dtgList.Rows.Count - 1).Value = mTTCredit
        dtgList.Item("totalDebt", dtgList.Rows.Count - 1).Value = mTTDebt
        dtgList.Item("totalCupong", dtgList.Rows.Count - 1).Value = mTTCupong
        dtgList.Item("totalReturn", dtgList.Rows.Count - 1).Value = mTTReturn
        dtgList.Item("totalCharge", dtgList.Rows.Count - 1).Value = mTTCharge
        dtgList.Item("totalDisc", dtgList.Rows.Count - 1).Value = mTTDisc
        dtgList.Item("totalPointDisc", dtgList.Rows.Count - 1).Value = mTTPointDisc
        dtgList.Item("totalExpense", dtgList.Rows.Count - 1).Value = mTTExpense
        dtgList.Item("remainCash", dtgList.Rows.Count - 1).Value = ""
        dtgList.Item("cashCount", dtgList.Rows.Count - 1).Value = ""
        dtgList.Item("totalOver", dtgList.Rows.Count - 1).Value = mTTOver
        dtgList.Item("totalBill", dtgList.Rows.Count - 1).Value = mTTBill
        dtgList.Item("totalPerBill", dtgList.Rows.Count - 1).Value = mTTSale / mTTBill
        dtgList.Item("totalCost", dtgList.Rows.Count - 1).Value = mTTCost
        dtgList.Item("totalSaleAndDisc", dtgList.Rows.Count - 1).Value = mTTSale + mTTDisc
        dtgList.Item("totalProfit", dtgList.Rows.Count - 1).Value = mTTSale + mTTDisc - mTTCost
        If mTTSale > 0 And mTTCost > 0 Then
          'dtgList.Item("perGP", dtgList.Rows.Count - 1).Value = (mTTSale - mTTCost) * 100 / mTTSale
          dtgList.Item("perGP", dtgList.Rows.Count - 1).Value = (mTTSale + mTTDisc - mTTCost) * 100 / (mTTSale + mTTDisc)
        Else
          dtgList.Item("perGP", dtgList.Rows.Count - 1).Value = "-"
        End If
        dtgList.Rows(dtgList.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Plum
      End If
    End If
    ds = Nothing

    Me.Cursor = Cursors.Default
  End Sub
End Class