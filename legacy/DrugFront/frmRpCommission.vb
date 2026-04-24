Public Class frmRpCommission

  Private Sub frmRpCommission_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    Me.WindowState = FormWindowState.Normal
  End Sub

  Private Sub frmRpCommission_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Icon = frmMain.Icon

    Dim mDate As Date
    mDate = Now.AddMonths(-1)

    For i As Integer = 1 To 12
      cboMonth.Items.Add(i)
      cboMonthName.Items.Add(MonthName(i))
    Next
    cboMonthName.Text = MonthName(mDate.Month)

    For i As Integer = Now.Year - 1 To Now.Year
      cboYear.Items.Add(i)
    Next
    cboYear.Text = mDate.Year.ToString
  End Sub

  Private Sub cboMonthName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMonthName.SelectedIndexChanged
    cboMonth.SelectedIndex = cboMonthName.SelectedIndex
    dtgList.Rows.Clear()
  End Sub

  Private Sub ViewReport()
    Me.Cursor = Cursors.WaitCursor

    dtgList.Rows.Clear()

    Dim mSqlText As String
    mSqlText = "Select * from BranchComm Where commMonth = " & cboMonth.Text & " and commYear = " & cboYear.Text & " and branchCode = '" & pBranchCode & "'"

    Dim ds As New DataSet
    ds = pService.SelectData("Drug", mSqlText)

    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        For i As Integer = 0 To dv.Count - 1
          With dv.Item(i)
            dtgList.Rows.Add("ยอดขาย", .Item("totalSale"))
            dtgList.Rows.Add("% Achieve Target", .Item("perAchTar"))
            dtgList.Rows.Add("Achieve Level", .Item("achLevel"))
            dtgList.Rows.Add("GP Level", .Item("gpLevel"))
            dtgList.Rows.Add("Comm Level", .Item("commLevel"))
            dtgList.Rows.Add("Comm Final", .Item("commFinal"))
            dtgList.Rows.Add("Comm Pack", .Item("commPack"))
            dtgList.Rows.Add("Comm Neo", .Item("commNeo"))
            dtgList.Rows.Add("Comm BKD", .Item("commBKD"))
            dtgList.Rows.Add("Comm Target", .Item("commTarget"))
            dtgList.Rows.Add("Comm PP", .Item("commPP"))
            dtgList.Rows.Add("Total Comm", .Item("totalComm"))
            dtgList.Rows.Add("คอมที่ได้รับ", .Item("receComm"))
            dtgList.Rows.Add("คอมที่จ่าย", .Item("paidComm"))
          End With
        Next
      Else
        MessageBox.Show("ไม่มีข้อมูล", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End If
      dv = Nothing
    Else
      MessageBox.Show("dataset error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End If
    ds = Nothing
    dtgList.ClearSelection()

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    If cboMonthName.Text <> "" And cboYear.Text <> "" Then
      ViewReport()
    End If
  End Sub

  Private Sub cboYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYear.SelectedIndexChanged
    dtgList.Rows.Clear()
  End Sub
End Class