Public Class frmOrderCheck

  Dim mStatus As String
  Dim mShipTo As String

  Private Sub frmOrderCheck_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    dtpFrom.Value = Now.Date
    dtpTo.Value = Now.Date

    Call ClearAll()
    'Call ShowHistOrder()

    CheckPriv()
  End Sub

  Private Sub ShowHistOrder()
    'Dim mFromDate, mToDate As Date
    '' วันแรกของเดือน
    'mFromDate = CDate("01/" & Month(dtpFrom.Value) & "/" & Year(dtpFrom.Value))
    '' หาวันสุดท้ายของเดือน
    'Dim mDay As String
    'mDay = Date.DaysInMonth(dtpFrom.Value.Year, dtpFrom.Value.Month).ToString
    'mToDate = CDate(mDay & "/" & Month(dtpFrom.Value) & "/" & Year(dtpFrom.Value))

    Dim dsHistOrder As New DataSet
    dsHistOrder = pService.SelectData("Drug", "SELECT HO.orderNumb, HO.orderDate, HO.orderTime, EI.emplName, HO.orderStat, HO.invoNumb, HO.orderRema, HO.totalPrice,HO.shipTo FROM HistOrder HO INNER JOIN EmplInfo EI ON HO.emplCode = EI.emplCode WHERE HO.orderDate >= '" & MDYStr(dtpFrom.Value) & "' AND HO.orderDate <= '" & MDYStr(dtpTo.Value) & "' AND HO.branchCode = '" & pBranchCode & "' ORDER BY HO.orderNumb desc")
    If IsNothing(dsHistOrder) = False Then
      dtgHistOrder.Rows.Clear()
      dtgOrderList.Rows.Clear()
      Dim dvHistOrder As New DataView(dsHistOrder.Tables(0))
      If dvHistOrder.Count > 0 Then
        Dim mTotalPrice As Double
        mTotalPrice = 0
        For i As Integer = 0 To dvHistOrder.Count - 1
          With dvHistOrder.Item(i)
            dtgHistOrder.Rows.Add()
            dtgHistOrder.Item("OrderNumb", dtgHistOrder.Rows.Count - 1).Value = .Item("orderNumb").ToString
            dtgHistOrder.Item("OrderTime", dtgHistOrder.Rows.Count - 1).Value = .Item("orderTime").ToString
            dtgHistOrder.Item("OrderDate", dtgHistOrder.Rows.Count - 1).Value = CDate(.Item("orderDate"))
            'dtgHistOrder.Item("OrderDay", dtgHistOrder.Rows.Count - 1).Value = CDate(.Item("orderDate")).Day
            dtgHistOrder.Item("emplName", dtgHistOrder.Rows.Count - 1).Value = .Item("emplName").ToString
            dtgHistOrder.Item("OrderStat", dtgHistOrder.Rows.Count - 1).Value = .Item("orderStat").ToString
            Select Case .Item("orderStat").ToString
              Case "1"
                If .Item("shipTo").ToString <> "" Then
                  dtgHistOrder.Item("Stat", dtgHistOrder.Rows.Count - 1).Value = "อยู่ระหว่าง่จัดซื้อ"
                Else
                  dtgHistOrder.Item("Stat", dtgHistOrder.Rows.Count - 1).Value = "อยู่ระหว่างจัดส่ง"
                End If
              Case "2"
                If .Item("shipTo").ToString <> "" Then
                  dtgHistOrder.Item("Stat", dtgHistOrder.Rows.Count - 1).Value = "จัดซื้อ(" & .Item("invoNumb").ToString & ")"
                Else
                  dtgHistOrder.Item("Stat", dtgHistOrder.Rows.Count - 1).Value = "จัดส่ง(" & .Item("invoNumb").ToString & ")"
                End If
              Case "3"
                dtgHistOrder.Item("Stat", dtgHistOrder.Rows.Count - 1).Value = "ยกเลิกการสั่งซื้อ"
                dtgHistOrder.Rows(dtgHistOrder.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Red
                'Case "4"
                '  dtgHistOrder.Item("Stat", dtgHistOrder.Rows.Count - 1).Value = "เก็บเป็นรายการค้างส่ง"
              Case "9"
                dtgHistOrder.Item("Stat", dtgHistOrder.Rows.Count - 1).Value = "รับแล้ว(" & .Item("invoNumb").ToString & ")"
              Case "0"
                dtgHistOrder.Item("Stat", dtgHistOrder.Rows.Count - 1).Value = "ยกเลิกใบสั่งสินค้า"
                dtgHistOrder.Rows(dtgHistOrder.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Red
              Case Else
                dtgHistOrder.Item("Stat", dtgHistOrder.Rows.Count - 1).Value = "???"
            End Select

            dtgHistOrder.Item("OrderRema", dtgHistOrder.Rows.Count - 1).Value = .Item("orderRema").ToString
            dtgHistOrder.Item("shipTo", dtgHistOrder.Rows.Count - 1).Value = .Item("shipTo").ToString
            dtgHistOrder.Item("totalPrice", dtgHistOrder.Rows.Count - 1).Value = .Item("totalPrice")
            mTotalPrice += .Item("totalPrice")
          End With
        Next
        lblTotalPrice.Text = Format(mTotalPrice, "#,##0.00")
      End If
      dvHistOrder = Nothing
    End If
    dsHistOrder = Nothing

    dtgHistOrder.ClearSelection()
  End Sub

  Private Sub CheckPriv()
    ' Cancel
    If InStr(pUserPriv, Me.Tag.ToString & "C") > 0 Then
      tbnCancel.Enabled = True
    Else
      tbnCancel.Enabled = False
    End If
  End Sub

  Private Sub ClearAll()
    dtgHistOrder.Rows.Clear()
    dtgOrderList.Rows.Clear()
    lblOrderNumb.Text = ""
    lblOrderDate.Text = ""
    lblEmplName.Text = ""
    lblTotalPrice.Text = "0.00"
  End Sub

  'Private Sub dtpOrder_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged
  '  Call ShowHistOrder()
  'End Sub

  Private Sub dtgHistOrder_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgHistOrder.CellDoubleClick
    If e.RowIndex < 0 Then
      Exit Sub
    End If

    Me.Cursor = Cursors.WaitCursor

    lblOrderNumb.Text = dtgHistOrder.Item("OrderNumb", e.RowIndex).Value.ToString
    lblOrderDate.Text = dtgHistOrder.Item("OrderDate", e.RowIndex).Value.ToString & "  " & dtgHistOrder.Item("OrderTime", e.RowIndex).Value.ToString
    lblEmplName.Text = dtgHistOrder.Item("emplName", e.RowIndex).Value.ToString
    mStatus = dtgHistOrder.Item("OrderStat", e.RowIndex).Value.ToString
    mShipTo = dtgHistOrder.Item("shipTo", e.RowIndex).Value.ToString

    Dim dsOrderList As New DataSet
    dsOrderList = pService.SelectData("Drug", "SELECT OL.*, GI.goodName, GI.goodRema, UI.unitDesc, UI.unitFactor, GK.bookAmou FROM OrderList OL INNER JOIN GoodInfo GI ON OL.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON OL.unitCode = UI.unitCode left join GoodBooking GK on GK.docNumb = OL.orderNumb and GK.goodCode = OL.goodCode WHERE OL.orderNumb = '" & dtgHistOrder.Item("OrderNumb", e.RowIndex).Value.ToString & "' ORDER BY GI.goodName")
    If IsNothing(dsOrderList) = False Then
      dtgOrderList.Rows.Clear()
      Dim dvOrderList As New DataView(dsOrderList.Tables(0))
      If dvOrderList.Count > 0 Then
        For i As Integer = 0 To dvOrderList.Count - 1
          dtgOrderList.Rows.Add()
          With dvOrderList.Item(i)
            dtgOrderList.Item("Item", i).Value = (i + 1).ToString
            dtgOrderList.Item("goodName", dtgOrderList.Rows.Count - 1).Value = .Item("goodName")
            dtgOrderList.Item("goodRema", dtgOrderList.Rows.Count - 1).Value = .Item("goodRema")
            dtgOrderList.Item("goodAmou", dtgOrderList.Rows.Count - 1).Value = .Item("goodAmou")
            dtgOrderList.Item("unitDesc", dtgOrderList.Rows.Count - 1).Value = .Item("unitDesc")
            dtgOrderList.Item("goodCode", dtgOrderList.Rows.Count - 1).Value = .Item("goodCode")
            dtgOrderList.Item("unitFactor", dtgOrderList.Rows.Count - 1).Value = .Item("unitFactor")
            If IsDBNull(.Item("bookAmou")) = False Then
              dtgOrderList.Item("isBooking", i).Value = "1"
            Else
              dtgOrderList.Item("isBooking", i).Value = "0"
            End If
            Select Case .Item("itemType")
              Case "A"
                dtgOrderList.Item("itemTypeDesc", dtgOrderList.Rows.Count - 1).Value = "จัดสรร"
                dtgOrderList.Rows(dtgOrderList.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Blue
              Case "O"
                dtgOrderList.Item("itemTypeDesc", dtgOrderList.Rows.Count - 1).Value = "สั่งปกติ"
                dtgOrderList.Rows(dtgOrderList.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Black
              Case "P"
                dtgOrderList.Item("itemTypeDesc", dtgOrderList.Rows.Count - 1).Value = "ค้างส่ง"
                dtgOrderList.Rows(dtgOrderList.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Purple
            End Select
          End With
        Next
      End If
      dtgOrderList.ClearSelection()
      dvOrderList = Nothing
    End If
    dsOrderList = Nothing

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub tbnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnCancel.Click
    If mStatus <> "1" Then
      Select Case mStatus
        Case "2"
          If mShipTo <> "" Then
            MessageBox.Show("สินค้าจัดซื้อแล้ว ไม่สามารถยกเลิกได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
          Else
            MessageBox.Show("สินค้าจัดส่งแล้ว ไม่สามารถยกเลิกได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
          End If
        Case "3"
          MessageBox.Show("ใบสั่งถูกยกเลิกการสั่งซื้อแล้ว", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Case "9"
          MessageBox.Show("รับสินค้าแล้ว ไม่สามารถยกเลิกได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Case "0"
          MessageBox.Show("ใบสั่งถูกยกเลิกแล้ว", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End Select

      Exit Sub
    End If

    ' Level 2 and 3 Only
    If InStr(pUserPriv, "LEVEL2") = 0 AndAlso InStr(pUserPriv, "LEVEL3") = 0 Then
      Dim fPass As New frmPass
      fPass.ShowDialog()
      If fPass.pOK = True Then
        If InStr(fPass.pPassPriv, "LEVEL2") = 0 AndAlso InStr(fPass.pPassPriv, "LEVEL3") = 0 Then
          MessageBox.Show("ท่านไม่ได้รับอนุญาตให้เข้าใช้งาน", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
          Exit Sub
        End If
      Else
        Exit Sub
      End If
    End If

    If MessageBox.Show("ยืนยันยกเลิกใบสั่งสินค้า", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
      Dim mSqlText(dtgOrderList.Rows.Count * 2 + 1) As String
      Dim mLine As Integer = 0

      mSqlText(mLine) = "UPDATE HistOrder SET orderStat = '0' WHERE orderNumb = '" & lblOrderNumb.Text & "'"
      mLine += 1

      ' ########## ระบบจอง เฉพาะใบสั่งที่ไม่ใช่ shipto
      If mShipTo = "" Then
        Dim mGoodCode As String
        Dim mOrderAmou As Integer
        Dim mUnitFactor As Integer
        Dim mIsBooking As String
        For Each mRow As DataGridViewRow In dtgOrderList.Rows
          mGoodCode = dtgOrderList.Item("goodCode", mRow.Index).Value
          mOrderAmou = dtgOrderList.Item("goodAmou", mRow.Index).Value
          mUnitFactor = dtgOrderList.Item("unitFactor", mRow.Index).Value
          mIsBooking = dtgOrderList.Item("isBooking", mRow.Index).Value

          If mIsBooking = "1" Then
            ' ปรับยอดจอง
            mSqlText(mLine) = "Update GoodInfo set bookAmouBranch = bookAmouBranch - " & mOrderAmou * mUnitFactor & " Where goodCode = '" & mGoodCode & "'"
            mLine += 1
            ' ลบรายการจอง
            mSqlText(mLine) = "Delete from GoodBooking Where docNumb = '" & lblOrderNumb.Text & "' and goodCode = '" & mGoodCode & "'"
            mLine += 1
          End If
        Next
      End If
      ' ##########

      Dim mUpdate As String
      mUpdate = pService.UpdateData("Drug", mSqlText)
      If mUpdate = "1" Then
        MessageBox.Show("ยกเลิกใบสั่งสินค้าเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        ClearAll()
        ShowHistOrder()
      Else
        MessageBox.Show(mUpdate, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End If
    End If

    'Dim fPass As New frmPass
    'fPass.ShowDialog()
    'If fPass.pOK = True Then
    '  If InStr(fPass.pPassPriv, "LEVEL2") = 0 AndAlso InStr(fPass.pPassPriv, "LEVEL3") = 0 Then
    '    MessageBox.Show("ท่านไม่ได้รับอนุญาตให้เข้าใช้งาน", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '  Else
    '    If MessageBox.Show("ยืนยันยกเลิกใบสั่งสินค้า", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '      Dim mSqlText(1) As String
    '      mSqlText(0) = "UPDATE HistOrder SET orderStat = '0' WHERE orderNumb = '" & lblOrderNumb.Text & "'"

    '      Dim mUpdate As String
    '      mUpdate = pService.UpdateData("Drug", mSqlText)
    '      If mUpdate = "1" Then
    '        MessageBox.Show("ยกเลิกใบสั่งสินค้าเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        ClearAll()
    '        ShowHistOrder()
    '      Else
    '        MessageBox.Show(mUpdate, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '      End If
    '    End If
    '  End If
    'End If
    'fPass = Nothing
  End Sub

  Private Sub tbnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnRefresh.Click
    ShowHistOrder()
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    ShowHistOrder()
  End Sub
End Class