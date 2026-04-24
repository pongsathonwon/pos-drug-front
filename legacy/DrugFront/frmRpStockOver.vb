Public Class frmRpStockOver

  Private Sub frmRpStockOver_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    Me.WindowState = FormWindowState.Normal
  End Sub

  Private Sub frmRpStockCard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    dtpFrom.Value = pServerDateTime.Date
    dtpTo.Value = pServerDateTime.Date

    CheckPriv()
  End Sub

  Private Sub CheckPriv()
    ' Print
    If InStr(pUserPriv, Me.Tag.ToString & "P") > 0 Then
      btnShow.Enabled = True
    Else
      btnShow.Enabled = False
    End If
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    Me.Cursor = Cursors.WaitCursor
    dtgOver.Rows.Clear()
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select distinct * from BranchStockCount where countDate >= '" & MDYStr(dtpFrom.Value) & "' and countDate <= '" & MDYStr(dtpTo.Value) & "' and branchCode = '" & pBranchCode & "' order by countDate, goodName")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dtgOver.Rows.Add()
          dtgOver.Item("countDate", i).Value = .Item("countDate")
          dtgOver.Item("goodName", i).Value = .Item("goodName")
          dtgOver.Item("unitDesc", i).Value = .Item("unitDesc")
          dtgOver.Item("stockOnhand", i).Value = .Item("stockOnhand")
          dtgOver.Item("stockCount", i).Value = .Item("stockCount")
          dtgOver.Item("stockOver", i).Value = CInt(.Item("stockCount")) - CInt(.Item("stockOnhand"))
        End With
      Next
      dv = Nothing
    End If
    ds = Nothing
    Me.Cursor = Cursors.Default
  End Sub
End Class