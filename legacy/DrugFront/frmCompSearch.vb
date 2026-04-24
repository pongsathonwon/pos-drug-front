Public Class frmCompSearch

  Public pCompCode As String
  Public pCompName As String
  Public pOk As Boolean

  Private Sub frmCompSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Icon = frmMain.Icon
  End Sub

  Private Sub textKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub txtName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.LostFocus
    If txtName.Text.Length > 0 Then
      StartSearch(txtName.Text)
    End If
  End Sub

  Private Sub StartSearch(ByVal mName As String)
    dtgList.Rows.Clear()
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "SELECT compCode, compName FROM CompInfo WHERE compName like '%" & mName & "%' order by compName")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dtgList.Rows.Add()
          dtgList.Item("compCode", dtgList.Rows.Count - 1).Value = .Item("compCode")
          dtgList.Item("compName", dtgList.Rows.Count - 1).Value = .Item("compName")
        End With
      Next
      dv = Nothing
    End If
    ds = Nothing
    If dtgList.Rows.Count > 0 Then
      dtgList.Focus()
    Else
      txtName.Text = ""
      txtName.Focus()
    End If
  End Sub

  Private Sub frmCompSearch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    pOk = False
    txtName.Text = ""
    txtName.Focus()
  End Sub

  Private Sub frmCompSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.Escape Then
      Me.Close()
    End If
  End Sub

  Private Sub dtgList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgList.CellDoubleClick
    pOk = True
    pCompCode = dtgList.Item("compCode", dtgList.CurrentRow.Index).Value.ToString
    pCompName = dtgList.Item("compName", dtgList.CurrentRow.Index).Value.ToString
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
      pCompCode = dtgList.Item("compCode", dtgList.CurrentRow.Index).Value.ToString
      pCompName = dtgList.Item("compName", dtgList.CurrentRow.Index).Value.ToString
      Me.Close()
    End If
  End Sub
End Class