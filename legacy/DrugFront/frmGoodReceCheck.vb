Public Class frmGoodReceCheck

  Dim mStatus As String
  Dim mShipTo As String

  Private Sub frmGoodReceCheck_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon
    'CheckPriv()
  End Sub

  'Private Sub CheckPriv()
  '  ' Cancel
  '  If InStr(pUserPriv, Me.Tag.ToString & "C") > 0 Then
  '    tbnCancel.Enabled = True
  '  Else
  '    tbnCancel.Enabled = False
  '  End If
  'End Sub

  Private Sub ShowHistRece()
    Me.Cursor = Cursors.WaitCursor
    Dim mFromDate, mToDate As Date
    ' วันแรกของเดือน
    mFromDate = CDate("01/" & Month(dtpRece.Value) & "/" & Year(dtpRece.Value))
    ' หาวันสุดท้ายของเดือน
    Dim mDay As String
    mDay = Date.DaysInMonth(dtpRece.Value.Year, dtpRece.Value.Month).ToString
    mToDate = CDate(mDay & "/" & Month(dtpRece.Value) & "/" & Year(dtpRece.Value))

    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "SELECT HR.*, EI.emplName FROM HistRece HR INNER JOIN EmplInfo EI ON HR.emplCode = EI.emplCode WHERE HR.receDate >= '" & MDYStr(mFromDate) & "' AND HR.receDate <= '" & MDYStr(mToDate) & "' AND HR.branchCode = '" & pBranchCode & "' and HR.receStat = '1' ORDER BY HR.receNumb")
    If IsNothing(ds) = False Then
      dtgHistRece.Rows.Clear()
      dtgReceList.Rows.Clear()
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        Dim mTotalPrice As Double
        mTotalPrice = 0
        For i As Integer = 0 To dv.Count - 1
          With dv.Item(i)
            dtgHistRece.Rows.Add()
            dtgHistRece.Item("ReceNumb", dtgHistRece.Rows.Count - 1).Value = .Item("receNumb")
            dtgHistRece.Item("receDate", dtgHistRece.Rows.Count - 1).Value = CDate(.Item("receDate"))
            dtgHistRece.Item("receDay", dtgHistRece.Rows.Count - 1).Value = CDate(.Item("receDate")).Day
            dtgHistRece.Item("emplName", dtgHistRece.Rows.Count - 1).Value = .Item("emplName")
            dtgHistRece.Item("orderNumb", dtgHistRece.Rows.Count - 1).Value = .Item("orderNumb")
            dtgHistRece.Item("invoNumb", dtgHistRece.Rows.Count - 1).Value = .Item("invoiceNumb")
          End With
        Next
      End If
      dv = Nothing
    End If
    ds = Nothing
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub ClearAll()
    dtgHistRece.Rows.Clear()
    dtgReceList.Rows.Clear()
    lblReceNumb.Text = ""
    lblReceDate.Text = ""
    lblEmplName.Text = ""
  End Sub

  'Private Sub dtpRece_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRece.ValueChanged
  '  Call ShowHistRece()
  'End Sub

  Private Sub dtgHistRece_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgHistRece.CellClick
    If e.RowIndex < 0 Then
      Exit Sub
    End If

    Me.Cursor = Cursors.WaitCursor

    lblReceNumb.Text = dtgHistRece.Item("receNumb", e.RowIndex).Value.ToString
    lblReceDate.Text = dtgHistRece.Item("receDate", e.RowIndex).Value.ToString
    lblInvoNumb.Text = dtgHistRece.Item("invoNumb", e.RowIndex).Value.ToString
    lblEmplName.Text = dtgHistRece.Item("emplName", e.RowIndex).Value.ToString

    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "SELECT RL.*, GI.goodName, UI.unitDesc FROM ReceList RL INNER JOIN GoodInfo GI ON RL.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON RL.unitCode = UI.unitCode WHERE RL.receNumb = '" & dtgHistRece.Item("receNumb", e.RowIndex).Value.ToString & "' ORDER BY GI.goodName")
    If IsNothing(ds) = False Then
      dtgReceList.Rows.Clear()
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        For i As Integer = 0 To dv.Count - 1
          dtgReceList.Rows.Add()
          With dv.Item(i)
            dtgReceList.Item("Item", i).Value = (i + 1).ToString
            dtgReceList.Item("goodName", dtgReceList.Rows.Count - 1).Value = .Item("goodName")
            dtgReceList.Item("goodAmou", dtgReceList.Rows.Count - 1).Value = .Item("goodAmou")
            dtgReceList.Item("unitDesc", dtgReceList.Rows.Count - 1).Value = .Item("unitDesc")
          End With
        Next
      End If
      dv = Nothing
    End If
    ds = Nothing

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub tbnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ShowHistRece()
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    Call ClearAll()
    Call ShowHistRece()
  End Sub
End Class