Public Class frmRpEmplSale

  Dim mGoodCode As String

  Private Sub frmRpEmplSale_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    Me.WindowState = FormWindowState.Normal
  End Sub

  Private Sub frmRpEmplSale_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    pServerDateTime = pService.ServerDateTime

    dtpFrom.Value = pServerDateTime.Date
    dtpTo.Value = pServerDateTime.Date
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    If txtBarcode.Text <> "" OrElse txtCompCode.Text <> "" Then
      ShowList()
    End If
  End Sub

  Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress, txtCompCode.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub ShowGood(ByVal GoodCode As String, ByVal BarCode As String)
    Dim getValue() As String
    Dim mSqlText As String
    If GoodCode <> "" Then
      mSqlText = "SELECT GI.goodCode, GI.goodName FROM GoodInfo GI INNER JOIN UnitInfo UI ON UI.unitCode = GI.unitCode WHERE GI.goodCode = '" & GoodCode & "' And GI.goodStat <> '0'"
    Else
      mSqlText = "SELECT GB.goodCode, GI.goodName FROM GoodBarcode GB INNER JOIN GoodInfo GI ON GI.goodCode = GB.goodCode INNER JOIN UnitInfo UI ON GB.unitCode = UI.unitCode WHERE GB.barCode = '" & BarCode & "' And GI.goodStat <> '0'"
    End If

    getValue = pService.GetData("Drug", mSqlText)

    If getValue(0) = "1" Then
      mGoodCode = getValue(1)
      txtGoodName.Text = getValue(2)
    Else
      MessageBox.Show("ไม่พบข้อมูลสินค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      mGoodCode = ""
      txtBarcode.Text = ""
      txtGoodName.Text = ""
      txtBarcode.Focus()
    End If
  End Sub

  Private Sub ShowList()
    If mGoodCode = "" AndAlso txtCompCode.Text = "" Then
      Exit Sub
    End If

    Me.Cursor = Cursors.WaitCursor
    txtBarcode.Enabled = False
    btnShow.Enabled = False

    Dim mSqltext As String
    Dim mSqlText1 As String
    Dim mSqlText2 As String
    Dim ds As New DataSet

    'mSqlText1 = "SELECT GI.goodName, UI.unitDesc, EI.emplName, SUM(goodAmou) AS totalAmou, SUM((SL.goodAmou * SL.unitPrice)- (SL.goodAmou * SL.unitPrice * HS.perCharge) - SL.subDisc) AS totalSale FROM SaleList SL INNER JOIN HistSale HS on SL.saleNumb = HS.saleNumb INNER JOIN GoodInfo GI ON GI.goodCode = SL.goodCode Inner join EmplInfo EI on EI.emplCode = HS.emplCode Left outer join UnitInfo UI on UI.unitCode = GI.unitCode"
    mSqlText1 = "SELECT GI.goodName, UI.unitDesc, EI.emplName, SUM(SL.goodAmou) AS saleAmou, SUM((SL.goodAmou * SL.unitPrice)- (SL.goodAmou * SL.unitPrice * HS.perCharge) - SL.subDisc) AS salePrice, sum(RL.goodAmou) as retuAmou, sum(RL.goodAmou * RL.unitPrice) as retuPrice FROM SaleList SL INNER JOIN HistSale HS on SL.saleNumb = HS.saleNumb INNER JOIN GoodInfo GI ON GI.goodCode = SL.goodCode Inner join EmplInfo EI on EI.emplCode = HS.emplCode inner join UnitInfo UI on UI.unitCode = GI.unitCode left join (Select RL.goodCode, RL.goodAmou, RL.unitPrice, HR.saleNumb from ReturnList RL inner join HistReturn HR on HR.returnNumb = RL.returnNumb) RL on RL.saleNumb = SL.saleNumb and RL.goodCode = SL.goodCode"

    mSqlText2 = " WHERE HS.saleDate >= '" & MDYStr(dtpFrom.Value) & "' AND HS.saleDate <= '" & MDYStr(dtpTo.Value) & "' and HS.branchCode = '" & pBranchCode & "' and HS.saleStat <> '0'"

    If txtCompCode.Text <> "" Then
      mSqlText1 = mSqlText1 & " inner join CompGood CG on CG.goodCode = SL.goodCode"
      mSqlText2 = mSqlText2 & " and CG.compCode = '" & txtCompCode.Text & "'"
    Else
      If mGoodCode <> "" Then
        mSqlText2 = mSqlText2 & " and SL.goodCode = '" & mGoodCode & "'"
      End If
    End If

    mSqltext = mSqlText1 & mSqlText2
    mSqltext = mSqltext & "  GROUP BY GI.goodName, UI.unitDesc, EI.emplName"

    ds = pService.SelectData("Drug", mSqltext)

    dtgList.Rows.Clear()
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      Dim mTotalAmou As Integer
      Dim mSaleAmou As Integer
      Dim mRetuAmou As Integer
      Dim mSalePrice As Double
      Dim mRetuPrice As Double
      Dim mTotalSale As Double
      Dim mGoodName As String = ""
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dtgList.Rows.Add()
          If mGoodName <> .Item("goodName").ToString Then
            dtgList.Item("goodName", i).Value = .Item("goodName")
            mGoodName = .Item("goodName").ToString
          Else
            dtgList.Item("goodName", i).Value = ""
          End If

          mSaleAmou = .Item("saleAmou")
          If IsDBNull(.Item("retuAmou")) = False Then
            mRetuAmou = .Item("retuAmou")
          Else
            mRetuAmou = 0
          End If

          mSalePrice = .Item("salePrice")
          If IsDBNull(.Item("retuPrice")) = False Then
            mRetuPrice = .Item("retuPrice")
          Else
            mRetuPrice = 0
          End If

          dtgList.Item("unitDesc", i).Value = .Item("unitDesc")
          dtgList.Item("emplName", i).Value = .Item("emplName")
          dtgList.Item("saleAmou", i).Value = mSaleAmou
          dtgList.Item("retuAmou", i).Value = mRetuAmou
          dtgList.Item("totalAmou", i).Value = mSaleAmou - mRetuAmou
          dtgList.Item("totalSale", i).Value = mSalePrice - mRetuPrice
          mTotalAmou += mSaleAmou - mRetuAmou
          mTotalSale += mSalePrice - mRetuPrice
        End With
      Next
      dv = Nothing
      dtgList.Rows.Add()
      dtgList.Item("goodName", dtgList.Rows.Count - 1).Value = "รวม"
      dtgList.Item("emplName", dtgList.Rows.Count - 1).Value = ""
      dtgList.Item("totalAmou", dtgList.Rows.Count - 1).Value = mTotalAmou
      dtgList.Item("totalSale", dtgList.Rows.Count - 1).Value = mTotalSale
      dtgList.Rows(dtgList.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Plum
      'If mTotalAmou > 0 Then
      '  dtgList.Rows.Add()
      '  dtgList.Item("goodName", dtgList.Rows.Count - 1).Value = "รวม"
      '  dtgList.Item("emplName", dtgList.Rows.Count - 1).Value = ""
      '  dtgList.Item("totalAmou", dtgList.Rows.Count - 1).Value = mTotalAmou
      '  dtgList.Item("totalSale", dtgList.Rows.Count - 1).Value = mTotalSale
      '  dtgList.Rows(dtgList.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Plum
      'End If
    End If
    ds = Nothing
    btnShow.Enabled = True
    txtBarcode.Enabled = True
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub txtBarcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.LostFocus
    If txtBarcode.Text <> "" Then
      ShowGood("", txtBarcode.Text)
    Else
      mGoodCode = ""
      txtGoodName.Text = ""
    End If
  End Sub

  Private Sub btnGoodSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoodSearch.Click
    frmGoodSearch.ShowDialog()
    If frmGoodSearch.pBarcode <> "" Then
      txtBarcode.Text = frmGoodSearch.pBarcode
      ShowGood("", txtBarcode.Text)
    End If
  End Sub

  Private Sub txtCompCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCompCode.LostFocus
    If txtCompCode.Text <> "" Then
      Dim mGet() As String
      mGet = pService.GetData("Drug", "Select compName From CompInfo where compCode = '" & txtCompCode.Text & "'")
      If mGet(0) = "1" Then
        txtCompName.Text = mGet(1)
      Else
        MessageBox.Show("ไม่พบข้อมูลบริษัท", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        txtCompCode.Text = ""
        txtCompName.Text = ""
        txtCompCode.Focus()
      End If
    Else
      txtCompName.Text = ""
    End If
  End Sub

  Private Sub btnCompSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompSearch.Click
    frmCompSearch.ShowDialog()
    If frmCompSearch.pCompCode <> "" Then
      txtCompCode.Text = frmCompSearch.pCompCode
      txtCompName.Text = frmCompSearch.pCompName
    End If
  End Sub
End Class