Public Class frmEmplSearch

  Public pEmplCode As String
  Public pEmplName As String
  Public pOk As Boolean

  Private Sub StartSearch()
    dtgList.Rows.Clear()
    Dim dsList As New DataSet
    dsList = pService.SelectData("Drug", "SELECT emplName, emplCode FROM EmplInfo WHERE branchCode = '" & pBranchCode & "' AND emplStat = '1' order by emplName")
    If IsNothing(dsList) = False Then
      Dim dvList As New DataView(dsList.Tables(0))
      For i As Integer = 0 To dvList.Count - 1
        With dvList.Item(i)
          dtgList.Rows.Add(.Item("emplName"), .Item("emplCode"))
        End With
      Next
      dvList = Nothing
    End If
    dsList = Nothing
  End Sub

  Private Sub frmEmplSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.Escape Then
      Me.Close()
    End If
  End Sub

  Private Sub frmEmplSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    pOk = False
    pEmplCode = ""
    pEmplName = ""
    Call StartSearch()
  End Sub

  Private Sub dtgList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgList.CellDoubleClick
    pOk = True
    pEmplCode = dtgList.Item("emplCode", dtgList.CurrentRow.Index).Value.ToString
    pEmplName = dtgList.Item("emplName", dtgList.CurrentRow.Index).Value.ToString
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
      pEmplCode = dtgList.Item("emplCode", dtgList.CurrentRow.Index).Value.ToString
      pEmplName = dtgList.Item("emplName", dtgList.CurrentRow.Index).Value.ToString
      Me.Close()
    End If
  End Sub
End Class