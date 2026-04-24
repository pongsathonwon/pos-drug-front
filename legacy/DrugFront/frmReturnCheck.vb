Public Class frmReturnCheck

  Private Sub frmReturnCheck_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon
  End Sub

  Private Sub ShowHistReturn()
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "SELECT HR.*, EI.emplName, CD.cardName FROM HistReturn HR INNER JOIN EmplInfo EI ON HR.cashCode = EI.emplCode inner join CardInfo CD on CD.cardCode = HR.cardCode WHERE HR.returnDate >= '" & MDYStr(dtpFrom.Value) & "' and HR.returnDate <= '" & MDYStr(dtpTo.Value) & "' AND HR.branchCode = '" & pBranchCode & "' ORDER BY HR.returnNumb")
    If IsNothing(ds) = False Then
      dtgHistReturn.Rows.Clear()
      dtgReturnList.Rows.Clear()
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        For i As Integer = 0 To dv.Count - 1
          With dv.Item(i)
            dtgHistReturn.Rows.Add()
            dtgHistReturn.Item("ReturnNumb", i).Value = .Item("returnNumb")
            dtgHistReturn.Item("ReturnTime", i).Value = .Item("returnTime")
            dtgHistReturn.Item("ReturnDate", i).Value = .Item("returnDate")
            dtgHistReturn.Item("CashName", i).Value = .Item("emplName")
            dtgHistReturn.Item("TotalPrice", i).Value = .Item("totalPrice")
            dtgHistReturn.Item("SaleNumb", i).Value = .Item("saleNumb")
            dtgHistReturn.Item("ReturnRema", i).Value = .Item("returnRema")
            dtgHistReturn.Item("cardName", i).Value = .Item("cardName")

            If .Item("closeNumb") <> "0" Then
              dtgHistReturn.Rows(i).DefaultCellStyle.ForeColor = Color.DarkGreen
            End If
          End With
        Next
      End If
      dv = Nothing
      dtgHistReturn.ClearSelection()
    End If
    ds = Nothing
  End Sub

  Private Sub ClearAll()
    dtgHistReturn.Rows.Clear()
    dtgReturnList.Rows.Clear()
    lblReturnNumb.Text = ""
    lblReturnDate.Text = ""
    lblSaleNumb.Text = ""
    lblCashName.Text = ""
    lblTotalPrice.Text = ""
  End Sub

  Private Sub dtgHistSale_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgHistReturn.CellDoubleClick
    If e.RowIndex < 0 Then
      Exit Sub
    End If

    lblReturnNumb.Text = dtgHistReturn.Item("ReturnNumb", e.RowIndex).Value.ToString
    lblReturnDate.Text = dtgHistReturn.Item("ReturnDate", e.RowIndex).Value.ToString & "  " & dtgHistReturn.Item("ReturnTime", e.RowIndex).Value.ToString
    lblCashName.Text = dtgHistReturn.Item("CashName", e.RowIndex).Value.ToString
    lblTotalPrice.Text = CSng(dtgHistReturn.Item("TotalPrice", e.RowIndex).Value).ToString("#,##0.00")
    lblSaleNumb.Text = dtgHistReturn.Item("SaleNumb", e.RowIndex).Value.ToString
    lblReturnRema.Text = dtgHistReturn.Item("ReturnRema", e.RowIndex).Value.ToString
    lblCardName.Text = dtgHistReturn.Item("cardName", e.RowIndex).Value.ToString

    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "SELECT RL.*, GI.goodName, UI.unitDesc FROM ReturnList RL INNER JOIN GoodInfo GI ON RL.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON RL.unitCode = UI.unitCode WHERE RL.returnNumb = '" & dtgHistReturn.Item("returnNumb", e.RowIndex).Value.ToString & "'")
    If IsNothing(ds) = False Then
      dtgReturnList.Rows.Clear()
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        For i As Integer = 0 To dv.Count - 1
          dtgReturnList.Rows.Add()
          With dv.Item(i)
            dtgReturnList.Item("GoodAmou", i).Value = .Item("goodAmou")
            dtgReturnList.Item("UnitDesc", i).Value = .Item("unitDesc")
            dtgReturnList.Item("GoodName", i).Value = .Item("goodName")
            dtgReturnList.Item("UnitPrice", i).Value = .Item("unitPrice")
            dtgReturnList.Item("SubTotal", i).Value = AdjustMoney(CInt(.Item("goodAmou")) * CSng(.Item("unitPrice")))
          End With
        Next
      End If
      dv = Nothing
    End If
    ds = Nothing
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    ClearAll()
    ShowHistReturn()
  End Sub
End Class