Public Class frmUseBuyExchange

  Public pBxCode As String
  Public pBarCode() As String
  Public pGoodCode() As String
  Public pGoodAmou() As Integer
  Public pDiscAmou() As Double
  Public pOk As Boolean
  Dim mBxAmou As Integer

  Private Sub frmUseBuyExchange_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.F4
        tbnGoodExchange.PerformClick()
      Case Keys.F8
        tbnUse.PerformClick()
      Case Keys.Escape
        Me.Close()
    End Select
  End Sub

  Private Sub frmUseBuyExchange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Icon = frmMain.Icon
    mBxAmou = 0
    pOk = False
  End Sub

  Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress, txtBxCode.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub txtBarcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.LostFocus
    If txtBarcode.Text <> "" And txtBxCode.Text <> "" Then
      Dim mSqlText As String
      mSqlText = "Select GI.goodCode, GB.barCode from GoodInfo GI inner join GoodBarcode GB on GB.goodCode = GI.goodCode Where GI.goodStat <> '0' and GB.barCode = '" & txtBarcode.Text & "'"
      Dim mGet() As String
      mGet = pService.GetData("Drug", mSqlText)
      If mGet(0) = "1" Then
        ShowGoodExchange(mGet(1), mGet(2))
      Else
        MessageBox.Show("ไม่พบข้อมูลสินค้า", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
      End If
      txtBarcode.Text = ""
      txtBarcode.Focus()
    End If
  End Sub

  Private Sub ShowGoodExchange(ByVal GoodCode As String, ByVal BarCode As String)
    If dtgList.Rows.Count >= mBxAmou Then
      MessageBox.Show("รายการสินค้าเกินสิทธิ์แลกซื้อ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If

    pServerDateTime = pService.ServerDateTime

    Dim mSqltext As String
    mSqltext = "Select GE.goodCode, GI.goodName, GE.goodAmou, UI.unitDesc, GE.discAmou from GoodBuyExchange GE inner join GoodInfo GI on GI.goodCode = GE.goodCode inner join UnitInfo UI on UI.unitCode = GI.unitCode Where GE.exchangeStat = '1' and GE.startDate <= '" & MDYStr(pServerDateTime.Date) & "' and GE.endDate >= '" & MDYStr(pServerDateTime.Date) & "' and GE.goodCode = '" & GoodCode & "'"
    Dim mGet() As String
    mGet = pService.GetData("Drug", mSqltext)
    If mGet(0) = "1" Then
      dtgList.Rows.Add()
      dtgList.Rows(dtgList.Rows.Count - 1).Cells("goodCode").Value = mGet(1)
      dtgList.Rows(dtgList.Rows.Count - 1).Cells("goodName").Value = mGet(2)
      dtgList.Rows(dtgList.Rows.Count - 1).Cells("goodAmou").Value = CInt(mGet(3))
      dtgList.Rows(dtgList.Rows.Count - 1).Cells("unitDesc").Value = mGet(4)
      dtgList.Rows(dtgList.Rows.Count - 1).Cells("discAmou").Value = CDbl(mGet(5))
      dtgList.Rows(dtgList.Rows.Count - 1).Cells("barCode").Value = BarCode
      dtgList.ClearSelection()
    Else
      MessageBox.Show("สินค้าไม่มีสิทธิ์แลกซื้อ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End If
  End Sub

  'Private Sub txtBxCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBxCode.LostFocus
  '  If txtBxCode.Text <> "" Then
  '    Dim mSqlText As String
  '    mSqlText = "Select branchCode, buyExchangeAmou from HistSale where saleNumb = '" & txtBxCode.Text & "' and saleStat <> '0'"
  '    Dim mGet() As String
  '    mGet = pService.GetData("Drug", mSqlText)
  '    If mGet(0) = "1" Then
  '      If mGet(1) <> pBranchCode Then
  '        MessageBox.Show("ไม่ใช่ใบเสร็จของสาขา", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
  '      Else
  '        mBxAmou = CInt(mGet(2))
  '        If mBxAmou = 0 Then
  '          MessageBox.Show("ใบเสร็จนี้ ไม่มีสิทธิ์แลกซื้อ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
  '        Else
  '          ' เช็คว่ามีประวัติการใช้สิทธิ์หรือยัง
  '          mSqlText = "Select saleNumb from HistBuyExchange where useSaleNumb = '" & txtBxCode.Text & "'"
  '          mGet = pService.GetData("Drug", mSqlText)
  '          If mGet(0) <> "1" Then
  '            lblExchangeAmou.Text = mBxAmou.ToString & " สิทธิ์แลกซื้อ"
  '            lblExchangeAmou.Visible = True
  '            Exit Sub
  '          Else
  '            MessageBox.Show("ใบเสร็จนี้ ใช้สิทธิ์แลกซื้อแล้ว", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
  '          End If
  '        End If
  '      End If
  '    Else
  '      MessageBox.Show("ไม่มีข้อมูลใบเสร็จ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
  '    End If
  '    lblExchangeAmou.Visible = False
  '    dtgList.Rows.Clear()
  '    mBxAmou = 0
  '    txtBxCode.Text = ""
  '    txtBxCode.Focus()
  '  End If
  'End Sub

  Private Sub txtBxCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBxCode.LostFocus
    If txtBxCode.Text <> "" Then
      Dim mSqlText As String
      mSqlText = "Select * from BuyExchangeInfo where bxCode = '" & txtBxCode.Text & "'"

      Dim ds As New DataSet
      ds = pService.SelectData("Drug", mSqlText)
      If IsNothing(ds) = False Then
        Dim dv As New DataView(ds.Tables(0))
        If dv.Count > 0 Then
          With dv.Item(0)
            Select Case .Item("bxStat").ToString
              Case "0"
                MessageBox.Show("รหัสนี้ ถูกยกเลิก", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtBxCode.Text = ""
                txtBxCode.Focus()
                Exit Sub
              Case "2"
                MessageBox.Show("รหัสนี้ ใช้สิทธิ์แลกซื้อแล้ว [เลขที่ใบขาย " & .Item("useSaleNumb").ToString & "]", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtBxCode.Text = ""
                txtBxCode.Focus()
                Exit Sub
            End Select

            mBxAmou = CInt(.Item("bxAmou"))
            lblBxAmou.Text = mBxAmou.ToString & " สิทธิ์แลกซื้อ"
            dtgList.Rows.Clear()
          End With
        Else
          MessageBox.Show("ไม่มีข้อมูลรหัสสิทธิ์แลกซื้อ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
          txtBxCode.Text = ""
          txtBxCode.Focus()
        End If
        dv = Nothing
      End If
      ds = Nothing
    End If
  End Sub

  Private Sub tbnUse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnUse.Click
    If dtgList.Rows.Count > 0 Then
      ReDim pBarCode(dtgList.Rows.Count)
      ReDim pGoodCode(dtgList.Rows.Count)
      ReDim pGoodAmou(dtgList.Rows.Count)
      ReDim pDiscAmou(dtgList.Rows.Count)

      For Each mRow As DataGridViewRow In dtgList.Rows
        pBarCode(mRow.Index) = dtgList.Rows(mRow.Index).Cells("barCode").Value
        pGoodCode(mRow.Index) = dtgList.Rows(mRow.Index).Cells("goodCode").Value
        pGoodAmou(mRow.Index) = dtgList.Rows(mRow.Index).Cells("goodAmou").Value
        pDiscAmou(mRow.Index) = dtgList.Rows(mRow.Index).Cells("discAmou").Value
      Next

      pBxCode = txtBxCode.Text
      pOk = True

      Me.Close()
    End If
  End Sub

  Private Sub tbnGoodExchange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnGoodExchange.Click
    frmGoodBuyExchangeList.ShowDialog()
    If frmGoodBuyExchangeList.pOk = True Then
      ShowGoodExchange(frmGoodBuyExchangeList.pGoodCode, frmGoodBuyExchangeList.pBarcode)
    End If
    frmGoodBuyExchangeList = Nothing
  End Sub
End Class