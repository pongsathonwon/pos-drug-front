Public Class frmPendOrder

  Public pImport As Boolean
  Public pGoodCode As String

  Private Sub frmPendOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    pImport = False

    ShowPendOrder()
  End Sub

  Private Sub ShowPendOrder()
    dtgList.Rows.Clear()
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "SELECT PO.*, GI.goodName, UI.unitDesc FROM PendOrder PO INNER JOIN GoodInfo GI ON PO.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON PO.unitCode = UI.unitCode WHERE branchCode = '" & pBranchCode & "' ORDER BY GI.goodName")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dtgList.Rows.Add()
          dtgList.Item("goodName", i).Value = .Item("goodName")
          dtgList.Item("pendAmou", i).Value = .Item("pendAmou")
          dtgList.Item("unitDesc", i).Value = .Item("unitDesc")
          dtgList.Item("orderNumb", i).Value = .Item("orderNumb")
          dtgList.Item("orderDate", i).Value = .Item("orderDate")
          dtgList.Item("goodCode", i).Value = .Item("goodCode")
          dtgList.Item("pendStat", i).Value = .Item("pendStat")
          Select Case .Item("pendStat").ToString
            Case "1"
              dtgList.Item("pendStatDetail", i).Value = "รอจอง"
            Case "2"
              dtgList.Item("pendStatDetail", i).Value = "จองแล้ว รอจัดส่ง"
            Case Else
              dtgList.Item("pendStatDetail", i).Value = ""
          End Select
          ' สินค้าจัดสรร orderNumb จะขึ้นต้นด้วย AL
          If Mid(.Item("orderNumb"), 1, 2) = "AL" Then
            dtgList.Item("pendStatDetail", i).Value = "สินค้าจัดสรร"
          End If
        End With
      Next
      dv = Nothing
    End If
    ds = Nothing
    dtgList.ClearSelection()
  End Sub

  Private Sub frmPendOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.Delete
        DeleteItem(dtgList.CurrentRow.Index)
      Case Keys.Escape
        Me.Close()
    End Select
  End Sub

  Private Sub DeleteItem(ByVal RowIndex As Integer)
    If MessageBox.Show("ยืนยันยกเลิกรายการ-" & dtgList.Item("goodName", RowIndex).Value.ToString, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
      Dim mGoodCode As String
      Dim mPendStat As String
      Dim mPendAmou As Integer
      Dim mOrderNumb As String

      mGoodCode = dtgList.Item("goodCode", RowIndex).Value
      mPendStat = dtgList.Item("pendStat", RowIndex).Value
      mPendAmou = dtgList.Item("pendAmou", RowIndex).Value
      mOrderNumb = dtgList.Item("orderNumb", RowIndex).Value

      Dim mSqlText(2) As String
      mSqlText(0) = "DELETE FROM PendOrder WHERE goodCode = '" & mGoodCode & "' AND branchCode = '" & pBranchCode & "'"
      ' ถ้าได้รับการจองแล้ว (หลังจากสต๊อคกลางรับยาเข้า) ให้ลบการจองและหักยอดจองออก
      If mPendStat = "2" Then
        mSqlText(1) = "Delete from GoodBooking where docNumb = '" & mOrderNumb & "' and goodCode = '" & mGoodCode & "'"
        mSqlText(2) = "Update GoodInfo set bookAmouBranch = bookAmouBranch - " & mPendAmou & " Where goodCode = '" & mGoodCode & "'"
      End If

      Dim mUpdate As String
      mUpdate = pService.UpdateData("Drug", mSqlText)
      If mUpdate <> "1" Then
        MessageBox.Show("ไม่สามารถลบรายการได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Else
        ShowPendOrder()
      End If
    End If
  End Sub

  'Private Sub tbnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnCancelAll.Click
  '  If MessageBox.Show("ยืนยันยกเลิกรายการค้างส่งทั้งหมด", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
  '    Exit Sub
  '  End If

  '  Dim mSqlText(1) As String
  '  mSqlText(0) = "DELETE FROM PendOrder WHERE branchCode = '" & pBranchCode & "'"
  '  Dim mUpdate As String
  '  mUpdate = pService.UpdateData("Drug", mSqlText)
  '  If mUpdate = "1" Then
  '    Me.Close()
  '  Else
  '    MessageBox.Show(mUpdate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
  '  End If
  'End Sub

  'Private Sub tbnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnImport.Click
  '  If dtgList.Rows.Count > 0 Then
  '    pImport = True
  '    Me.Close()
  '  End If
  'End Sub

  'Private Sub dtgList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgList.DoubleClick
  '  pGoodCode = dtgList.Item("goodCode", dtgList.CurrentRow.Index).Value.ToString
  '  pImport = True
  '  Me.Close()
  'End Sub

  Private Sub tbnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnCancel.Click
    DeleteItem(dtgList.CurrentRow.Index)
  End Sub
End Class