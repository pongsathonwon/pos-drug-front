Public Class frmChangeSalePaid

  Public pSaleNumb As String
  Public pTotalPrice As Double
  Public pOk As Boolean
  Private mColorConv As New ColorConverter

  Private Sub frmChangeSalePaid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Icon = frmMain.Icon

    pOk = False
    lblTotalPrice.Text = "ยอดเงินสุทธิ " & pTotalPrice.ToString("#,##0.00")
    ShowCardPaid()
  End Sub

  Private Sub ShowCardPaid()
    dtgPaid.Rows.Clear()
    Dim ds As New DataSet
    Dim dv As DataView
    Dim mSqlText As String
    mSqlText = "Select * from CardInfo where showCard = '1' order by cardOrder, cardCode"

    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      dv = New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        For i As Integer = 0 To dv.Count - 1
          With dv.Item(i)
            dtgPaid.Rows.Add()
            dtgPaid.Item("cardCode", i).Value = .Item("cardCode")
            dtgPaid.Item("cardName", i).Value = .Item("cardName")
            dtgPaid.Item("payAmou", i).Value = ""
            ' แสดงสี
            Try
              dtgPaid.Item("cardName", i).Style.BackColor = mColorConv.ConvertFromString(.Item("cardColor"))
            Catch ex As Exception

            End Try
          End With
        Next
      End If
      dv = Nothing
    End If
    ' เติมรายการชำระ
    ds = pService.SelectData("Drug", "Select * from SalePaidList where saleNumb = '" & pSaleNumb & "'")
    If IsNothing(ds) = False Then
      dv = New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          For Each mRow As DataGridViewRow In dtgPaid.Rows
            If dtgPaid.Item("cardCode", mRow.Index).Value = .Item("cardCode") Then
              dtgPaid.Item("payAmou", mRow.Index).Value = .Item("payAmou")
            End If
          Next
        End With
      Next
      dv = Nothing
    End If
    ds = Nothing
    dtgPaid.ClearSelection()
  End Sub

  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    Dim mTotalPrice As Double = 0
    Dim mTotalCash As Double = 0
    For Each mRow As DataGridViewRow In dtgPaid.Rows
      If dtgPaid.Item("cardCode", mRow.Index).Value = "0" Then
        mTotalCash = MyVal(dtgPaid.Item("payAmou", mRow.Index).Value)
      End If
      mTotalPrice += MyVal(dtgPaid.Item("payAmou", mRow.Index).Value)
    Next

    If mTotalPrice <> pTotalPrice Then
      pMessageBox = New MyMessageBox("ยอดเงินรวมไม่เท่ากับยอดเงินสุทธิ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
      pMessageBox.ShowDialog()
      Exit Sub
    End If

    Dim mSqlText(dtgPaid.Rows.Count + 2) As String
    Dim mLine As Integer = 0
    mSqlText(mLine) = "Update HistSale set totalCash = " & mTotalCash & ", totalPay = " & mTotalCash & " Where saleNumb = '" & pSaleNumb & "'"
    mLine += 1
    mSqlText(mLine) = "Delete from SalePaidList where saleNumb = '" & pSaleNumb & "'"
    mLine += 1

    For Each mRow As DataGridViewRow In dtgPaid.Rows
      If MyVal(dtgPaid.Item("payAmou", mRow.Index).Value) > 0 Then
        mSqlText(mLine) = "Insert into SalePaidList (saleNumb, cardCode, payAmou) values ('" & pSaleNumb & "', '" & dtgPaid.Item("cardCode", mRow.Index).Value & "', " & MyVal(dtgPaid.Item("payAmou", mRow.Index).Value) & ")"
        mLine += 1
      End If
    Next

    Dim mUpdate As String
    mUpdate = pService.UpdateData("Drug", mSqlText)
    If mUpdate = "1" Then
      pOk = True
      Me.Close()
    Else
      pMessageBox = New MyMessageBox(mUpdate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      pMessageBox.ShowDialog()
    End If
  End Sub
End Class