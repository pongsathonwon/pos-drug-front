Public Class frmRpAccoBook11

  Dim mGoodCode As String

  Private Sub frmRpAccoBook11_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    Me.WindowState = FormWindowState.Normal
  End Sub

  Private Sub frmRpAccoutBook11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Icon = frmMain.Icon

    For i As Integer = Now.Year To Now.Year - 3 Step -1
      cboYear.Items.Add(i + 543)
    Next
    cboYear.Text = Now.Year + 543

    For i As Integer = 1 To 12
      cboMonth.Items.Add(i)
    Next
    cboMonth.Text = Now.Month

    'dtpFrom.Value = Now.Date ' New Date(Now.Year, Now.Month, 1)
    'dtpTo.Value = Now.Date

    CheckPriv()
    ShowGoodList()
  End Sub

  Private Sub CheckPriv()
    If InStr(pUserPriv, Me.Tag.ToString & "V") > 0 Then
      btnShow.Enabled = True
    Else
      btnShow.Enabled = False
    End If
  End Sub

  Private Sub ShowGoodList()
    dtgList.Rows.Clear()
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select goodCode, goodName from GoodInfo where accoBook11 = '1'")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        dtgList.Rows.Add(dv.Item(i).Item("goodCode"), dv.Item(i).Item("goodName"))
      Next
      dv = Nothing
    End If
    ds = Nothing
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    'If txtBarcode.Text = "" Then
    '  MessageBox.Show("กรุณาป้อนรหัสสินค้าที่ต้องการออกรายงาน", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '  Exit Sub
    'End If

    ViewReport()
  End Sub

  Private Sub ViewReport()
    Me.Cursor = Cursors.WaitCursor

    Dim mReceAmou As String = ""
    Dim mReceDate As String = ""

    Dim mFromDate, mToDate As Date
    mFromDate = DateSerial(cboYear.Text, cboMonth.Text, 1)
    mToDate = DateSerial(cboYear.Text, cboMonth.Text, DateTime.DaysInMonth(cboYear.Text, cboMonth.Text))

    Dim ds As New DataSet("dsDrug")
    Dim dt As New DataTable("dtAccBook11")
    Dim dr As DataRow

    dt.Columns.Add("goodName", Type.GetType("System.String"))
    dt.Columns.Add("receDate", Type.GetType("System.String"))
    dt.Columns.Add("receAmou", Type.GetType("System.String"))
    dt.Columns.Add("saleDate", Type.GetType("System.String"))
    dt.Columns.Add("custName", Type.GetType("System.String"))
    dt.Columns.Add("goodAmou", Type.GetType("System.Int32"))
    dt.Columns.Add("unitDesc", Type.GetType("System.String"))

    ds.Tables.Add(dt)

    Dim mSqlText As String
    Dim ds2 As New DataSet
    Dim mGoodCode As String
    Dim dsRece As New DataSet
    Dim dvRece As DataView

    For Each mRow As DataGridViewRow In dtgList.Rows
      mGoodCode = dtgList.Item("goodCode", mRow.Index).Value

      mSqlText = "Select HS.saleDate, CI.custName, GI.goodName, SL.goodAmou, UI.unitDesc from SaleList SL inner join HistSale HS on HS.saleNumb = SL.saleNumb inner join GoodInfo GI on GI.goodCode = SL.goodCode inner join UnitInfo UI on UI.unitCode = SL.unitCode inner join CustInfo CI on CI.custCode = HS.custCode where HS.branchCode = '" & pBranchCode & "' and HS.saleDate >= '" & MDYStr(mFromDate) & "' and HS.saleDate <= '" & MDYStr(mToDate) & "' and SL.goodCode = '" & mGoodCode & "' order by HS.saleDate"

      'If txtBarcode.Text <> "" Then
      '  mSqlText = mSqlText & " and SL.goodCode = '" & mGoodCode & "'"
      'End If

      ds2 = pService.SelectData("Drug", mSqlText)

      If IsNothing(ds2) = False Then
        Dim dv As New DataView(ds2.Tables(0))

        ' ข้อมูลรับเข้าล่าสุด
        If dv.Count > 0 Then
          'dsRece = pService.SelectData("Drug", "Select top 1 HR.receDate, RL.goodAmou, UI.unitDesc from HistRece HR inner join ReceList RL on RL.receNumb = HR.receNumb inner join UnitInfo UI on UI.unitCode = RL.unitCode where HR.branchCode = '" & pBranchCode & "' and HR.receStat <> '0' and RL.goodCode = '" & mGoodCode & "' and HR.receDate <= '" & MDYStr(mFromDate) & "' order by HR.receDate desc")
          dsRece = pService.SelectData("Drug", "Select RL.goodCode, UI.unitDesc, sum(RL.goodAmou) as goodAmou from HistRece HR inner join ReceList RL on RL.receNumb = HR.receNumb inner join UnitInfo UI on UI.unitCode = RL.unitCode where HR.branchCode = '" & pBranchCode & "' and HR.receStat <> '0' and RL.goodCode = '" & mGoodCode & "' and HR.receDate >= '" & MDYStr(mFromDate) & "' and HR.receDate <= '" & MDYStr(mToDate) & "' group by RL.goodCode, UI.unitDesc")
          If IsNothing(dsRece) = False Then
            dvRece = New DataView(dsRece.Tables(0))
            If dvRece.Count > 0 Then
              mReceDate = "" 'ThaiNumbDate(CDate(dvRece.Item(0).Item("receDate")))
              mReceAmou = dvRece.Item(0).Item("goodAmou").ToString & " " & dvRece.Item(0).Item("unitDesc")
            Else
              mReceDate = ""
              mReceAmou = ""
            End If
            dvRece = Nothing
          End If
          dsRece = Nothing
        End If

        For i As Integer = 0 To dv.Count - 1
          With dv.Item(i)
            dr = ds.Tables(0).NewRow
            dr("goodName") = .Item("goodName")
            dr("receDate") = mReceDate
            dr("receAmou") = mReceAmou
            dr("saleDate") = ThaiNumbDate(CDate(.Item("saleDate")))
            dr("custName") = .Item("custName")
            dr("goodAmou") = .Item("goodAmou")
            dr("unitDesc") = .Item("unitDesc")
          End With
          ds.Tables(0).Rows.Add(dr)
        Next
        dv = Nothing
      End If
      ds2 = Nothing

    Next


    Dim mReport As New rpAccoBook11
    mReport.SetDataSource(ds)
    mReport.SetParameterValue("pBranchName", pBranchName)
    mReport.SetParameterValue("pSuppName", pCompName)

    Dim mView As New frmViewReport
    mView.MdiParent = frmMain
    mView.Text = Me.Text
    mView.ctrView.ReportSource = mReport
    mView.Show()

    Me.Cursor = Cursors.Default

  End Sub

  Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) AndAlso txtBarcode.Text <> "" Then
      e.Handled = True
      ShowGood("", txtBarcode.Text)
    End If
  End Sub

  Private Sub ShowGood(ByVal GoodCode As String, ByVal BarCode As String)
    Dim mSqlText As String
    If GoodCode <> "" Then
      mSqlText = "SELECT goodCode, goodName, barCode FROM GoodInfo WHERE goodCode = '" & GoodCode & "'"
    Else
      mSqlText = "SELECT GB.goodCode, GB.barCode, GI.goodName FROM GoodBarcode GB INNER JOIN GoodInfo GI ON GB.goodCode = GI.goodCode WHERE GB.barCode = '" & BarCode & "'"
    End If

    Dim ds As New DataSet
    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        With dv.Item(0)
          mGoodCode = .Item("goodCode")
          txtBarcode.Text = .Item("barCode")
          txtGoodName.Text = .Item("goodName")
        End With
        btnShow.Focus()
      Else
        MessageBox.Show("ไม่พบข้อมูลสินค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        txtBarcode.Text = ""
        txtGoodName.Text = ""
        mGoodCode = ""
        txtBarcode.Focus()
      End If
      dv = Nothing
    End If
    ds = Nothing
  End Sub

  Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
    frmGoodSearch.ShowDialog()
    If frmGoodSearch.pOk = True Then
      ShowGood("", frmGoodSearch.pBarcode)
    End If
  End Sub
End Class