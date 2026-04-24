Public Class frmRpAccoBook9

  Dim mGoodCode As String

  Private Sub frmRpAccoBook9_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
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
    'ShowGoodList()
  End Sub

  Private Sub CheckPriv()
    If InStr(pUserPriv, Me.Tag.ToString & "V") > 0 Then
      btnShow.Enabled = True
    Else
      btnShow.Enabled = False
    End If
  End Sub

  'Private Sub ShowGoodList()
  '  Me.Cursor = Cursors.WaitCursor
  '  dtgList.Rows.Clear()
  '  Dim ds As New DataSet
  '  ds = pService.SelectData("Drug", "Select goodCode, goodName from GoodInfo where accoBook9 = '1'")
  '  If IsNothing(ds) = False Then
  '    Dim dv As New DataView(ds.Tables(0))
  '    For i As Integer = 0 To dv.Count - 1
  '      dtgList.Rows.Add(dv.Item(i).Item("goodCode"), dv.Item(i).Item("goodName"))
  '    Next
  '    dv = Nothing
  '  End If
  '  ds = Nothing
  '  Me.Cursor = Cursors.Default
  'End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    ViewReport()
  End Sub

  Private Sub ViewReport()
    Me.Cursor = Cursors.WaitCursor

    Dim mFromDate, mToDate As Date
    mFromDate = DateSerial(cboYear.Text, cboMonth.Text, 1)
    mToDate = DateSerial(cboYear.Text, cboMonth.Text, DateTime.DaysInMonth(cboYear.Text, cboMonth.Text))

    Dim ds As New DataSet("dsDrug")
    Dim dt As New DataTable("dtAccoBook9")
    Dim dr As DataRow

    dt.Columns.Add("receDate", Type.GetType("System.String"))
    dt.Columns.Add("goodName", Type.GetType("System.String"))
    dt.Columns.Add("goodAmou", Type.GetType("System.String"))
    dt.Columns.Add("unitDesc", Type.GetType("System.String"))

    ds.Tables.Add(dt)

    Dim mSqlText As String
    Dim ds2 As New DataSet

    mSqlText = "Select HR.receDate, GI.goodName, RL.goodAmou, UI.unitDesc from ReceList RL inner join HistRece HR on HR.receNumb = RL.receNumb inner join GoodInfo GI on GI.goodCode = RL.goodCode inner join UnitInfo UI on UI.unitCode = RL.unitCode Where HR.receStat <> '0' and HR.receDate >= '" & MDYStr(mFromDate) & "' and HR.receDate <= '" & MDYStr(mToDate) & "' and GI.accoBook9 = '1' and HR.branchCode = '" & pBranchCode & "' order by HR.receDate, GI.goodName"

    ds2 = pService.SelectData("Drug", mSqlText)

    If IsNothing(ds2) = False Then
      Dim dv As New DataView(ds2.Tables(0))
      If dv.Count > 0 Then
        Dim mDate As Date
        For i As Integer = 0 To dv.Count - 1
          With dv.Item(i)
            dr = ds.Tables(0).NewRow
            mDate = CDate(.Item("receDate"))
            dr("receDate") = ThaiNumbDate(CDate(.Item("receDate")))
            dr("goodName") = .Item("goodName")
            dr("goodAmou") = .Item("goodAmou")
            dr("unitDesc") = .Item("unitDesc")
          End With
          ds.Tables(0).Rows.Add(dr)
        Next
      End If
      dv = Nothing
    End If
    ds2 = Nothing

    Dim mReport As New rpAccoBook9
    mReport.SetDataSource(ds)
    mReport.SetParameterValue("pCompName", pCompName)
    mReport.SetParameterValue("pBranchName", pBranchName)

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
    ds = SelectData(mSqlText)
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