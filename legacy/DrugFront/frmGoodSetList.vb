Public Class frmGoodSetList

  Public pSetNumb As Integer
  Public pOk As Boolean

  Private Sub frmGoodSetList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.Escape Then
      Me.Close()
    End If
  End Sub

  Private Sub frmGoodSetList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    pOk = False
    ShowGoodSet()
  End Sub

  Private Sub ShowGoodSet()
    dtgList.Rows.Clear()
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select * from GoodSet order by setDesc")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        dtgList.Rows.Add()
        dtgList.Item("itemNo", i).Value = i
        dtgList.Item("setNumb", i).Value = dv.Item(i).Item("setNumb")
        dtgList.Item("setDesc", i).Value = dv.Item(i).Item("setDesc")
      Next
      dv = Nothing
    End If
    ds = Nothing
  End Sub

  Private Sub dtgList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgList.CellDoubleClick
    If e.RowIndex > -1 Then
      pSetNumb = dtgList.Item("setNumb", e.RowIndex).Value
      pOk = True
      Me.Close()
    End If
  End Sub

  Private Sub dtgList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgList.KeyDown
    ' ป้องกันการกด Enter แล้วกระโดดไปบรรทัดต่อไป
    If e.KeyCode = Keys.Enter Then
      e.Handled = True
    End If
  End Sub

  Private Sub dtgList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtgList.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      pSetNumb = dtgList.Item("setNumb", dtgList.CurrentRow.Index).Value
      pOk = True
      Me.Close()
    End If
  End Sub
End Class