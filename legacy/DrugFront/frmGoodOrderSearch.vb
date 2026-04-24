Public Class frmGoodOrderSearch

  Public pOrderNumb As String
  Public pOk As Boolean

  Private Sub ShowOrder()
    dtgList.Rows.Clear()
    Dim dsOrder As New DataSet
    dsOrder = pService.SelectData("Drug", "SELECT TOP 20 orderNumb, orderDate, orderStat FROM HistOrder WHERE branchCode = '" & pBranchCode & "' ORDER BY orderNumb desc")
    If IsNothing(dsOrder) = False Then
      Dim dvOrder As New DataView(dsOrder.Tables(0))
      Dim mStatus As String = ""
      For i As Integer = 0 To dvOrder.Count - 1
        With dvOrder.Item(i)
          dtgList.Rows.Add()
          dtgList.Item("orderNumb", dtgList.Rows.Count - 1).Value = .Item("orderNumb")
          dtgList.Item("orderDate", dtgList.Rows.Count - 1).Value = .Item("orderDate")
          Select Case .Item("orderStat").ToString
            Case "0"
              mStatus = "ยกเลิก"
            Case "1"
              mStatus = "อยู่ระหว่างจัดส่ง"
            Case "2"
              mStatus = "ส่งสินค้าแล้ว"
          End Select
          dtgList.Item("orderStat", dtgList.Rows.Count - 1).Value = mStatus
        End With
      Next
      dvOrder = Nothing
    End If
    dsOrder = Nothing
  End Sub

  Private Sub frmGoodOrderSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.Escape Then
      Me.Close()
    End If
  End Sub

  Private Sub frmGoodOrderSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    pOk = False
    ShowOrder()
  End Sub

  Private Sub dtgList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgList.CellDoubleClick
    pOk = True
    pOrderNumb = dtgList.Item("orderNumb", dtgList.CurrentRow.Index).Value.ToString
    Me.Close()
  End Sub

  Private Sub dtgList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgList.KeyDown
    ' ป้องกันการกด Enter แล้วกระโดดไปบรรทัดต่อไป
    If e.KeyCode = Keys.Enter Then
      e.Handled = True
    End If
  End Sub

  Private Sub dtgList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtgList.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      pOk = True
      pOrderNumb = dtgList.Item("orderNumb", dtgList.CurrentRow.Index).Value.ToString
      Me.Close()
    End If
  End Sub
End Class