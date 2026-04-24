Public Class frmUsePoint

  Public pCustPoint As Integer
  Public pUsePoint As Integer
  Public pPointDisc As Double
  Public pTotalPriceNet As Double
  Public pOk As Boolean

  Private Sub frmUsePoint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.Escape Then
      Me.Close()
    End If
  End Sub

  Private Sub frmUsePoint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon
    pOk = False
    ShowCashPoint(pCustPoint)
  End Sub

  Private Sub ShowCashPoint(ByVal HugPoint As Integer)
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select * From PointCash where hugPoint <= " & HugPoint & " And cashValue <= " & pTotalPriceNet & " Order by hugPoint")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      dtgPoint.Rows.Clear()
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dtgPoint.Rows.Add(.Item("hugPoint"), .Item("cashValue"))
        End With
      Next
      dv = Nothing
    End If
    ds = Nothing
  End Sub

  Private Sub dtgPoint_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgPoint.CellDoubleClick
    If e.RowIndex >= 0 Then
      pUsePoint = CInt(dtgPoint.Item("hugPoint", e.RowIndex).Value)
      pPointDisc = CDbl(dtgPoint.Item("cashValue", e.RowIndex).Value)
      pOk = True
      Me.Close()
    End If
  End Sub

  Private Sub dtgPoint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgPoint.KeyDown
    If e.KeyCode = Keys.Enter Then
      e.Handled = True
    Else
      If e.KeyCode = Keys.Escape Then
        e.Handled = True
        Me.Close()
      End If
    End If
  End Sub

  Private Sub dtgPoint_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtgPoint.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      pUsePoint = CInt(dtgPoint.Item("hugPoint", dtgPoint.CurrentRow.Index).Value)
      pPointDisc = CDbl(dtgPoint.Item("cashValue", dtgPoint.CurrentRow.Index).Value)
      pOk = True
      Me.Close()
    End If
  End Sub
End Class