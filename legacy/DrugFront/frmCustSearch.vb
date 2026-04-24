Public Class frmCustSearch

  Public pCustCode As String
  Public pCustName As String
  Public pOk As Boolean

  Private Sub frmCustSearch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    txtName.Text = ""
    txtName.Select()
  End Sub

  Private Sub frmCustSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    pOk = False
  End Sub

  Private Sub textKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      StartSearch(txtName.Text)
      'SendKeys.Send("{Tab}")
    End If
  End Sub

  'Private Sub txtName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.LostFocus
  '  If txtName.Text.Length > 0 Then
  '    StartSearch(txtName.Text)
  '  End If
  'End Sub

  Private Sub StartSearch(ByVal mName As String)
    If mName.Trim = "" Then
      Exit Sub
    End If
    Me.Cursor = Cursors.WaitCursor
    dtgList.Rows.Clear()
    Dim dsList As New DataSet
    'dsList = pService.SelectData("Drug", "SELECT custName, custCode FROM CustInfo WHERE custName like '%" & mName & "%' AND custCode <> '0' AND custStat = '1' order by custName")
    dsList = pService.SelectData("Drug", "SELECT CI.custName, CI.custCode, CT.custTypeDesc FROM CustInfo CI inner join CustType CT on CT.custTypeCode = CI.custType WHERE CI.custName like '%" & mName & "%' AND CI.custCode <> '0' AND CI.custStat = '1' order by CI.custName")
    If IsNothing(dsList) = False Then
      Dim dvList As New DataView(dsList.Tables(0))
      For i As Integer = 0 To dvList.Count - 1
        With dvList.Item(i)
          dtgList.Rows.Add(.Item("custName"), .Item("custCode"), .Item("custTypeDesc"))
        End With
      Next
      dvList = Nothing
    End If
    dsList = Nothing
    If dtgList.Rows.Count > 0 Then
      dtgList.Focus()
    Else
      txtName.Text = ""
      txtName.Focus()
    End If
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub frmCustSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.Escape Then
      Me.Close()
    End If
  End Sub

  Private Sub dtgList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgList.CellDoubleClick
    pOk = True
    pCustCode = dtgList.Item("custCode", dtgList.CurrentRow.Index).Value.ToString
    pCustName = dtgList.Item("custName", dtgList.CurrentRow.Index).Value.ToString
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
      pCustCode = dtgList.Item("custCode", dtgList.CurrentRow.Index).Value.ToString
      pCustName = dtgList.Item("custName", dtgList.CurrentRow.Index).Value.ToString
      Me.Close()
    End If
  End Sub

  Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
    If txtName.Text <> "" Then
      StartSearch(txtName.Text)
    End If
  End Sub
End Class