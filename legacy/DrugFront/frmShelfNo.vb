Public Class frmShelfNo

  Dim mShelfNoField As String
  Dim mStockOnhandField As String

  Private Sub frmShelfNo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    mShelfNoField = "shelfNo" & pBranchCode
    mStockOnhandField = "stockOnhand" & pBranchCode
    CheckPriv()

    ShowShelf()
  End Sub

  Private Sub ShowShelf()
    Me.Cursor = Cursors.WaitCursor
    dtgShelf.Rows.Clear()

    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select distinct " & mShelfNoField & " from GoodInfo where goodStat <> '0' and " & mShelfNoField & " <> '' order by " & mShelfNoField)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dtgShelf.Rows.Add()
          dtgShelf.Item("shelfNumb", i).Value = .Item(mShelfNoField)
        End With
      Next
      dtgShelf.ClearSelection()
      dv = Nothing
    End If
    ds = Nothing
    Me.Cursor = Cursors.Default
  End Sub

  'Private Sub ShowGoodNoShelf(ByVal ShelfNoField As String)
  '  Me.Cursor = Cursors.WaitCursor
  '  dtgNoShelf.Rows.Clear()
  '  Dim ds As New DataSet
  '  ds = pService.SelectData("Drug", "Select goodCode, goodName From GoodInfo where (" & mShelfNoField & " = '' or " & mShelfNoField & " is null) and goodStat <> '0' and " & mStockOnhandField & " > 0 order by goodName")
  '  If IsNothing(ds) = False Then
  '    Dim dv As New DataView(ds.Tables(0))
  '    For i As Integer = 0 To dv.Count - 1
  '      With dv.Item(i)
  '        dtgNoShelf.Rows.Add()
  '        dtgNoShelf.Item("nGoodCode", i).Value = .Item("goodCode")
  '        dtgNoShelf.Item("nGoodName", i).Value = .Item("goodName")
  '      End With
  '    Next
  '    dtgNoShelf.ClearSelection()
  '    dv = Nothing
  '  End If
  '  ds = Nothing
  '  Me.Cursor = Cursors.Default
  'End Sub

  Private Sub CheckPriv()
    ' Add, Edit
    If InStr(pUserPriv, Me.Tag.ToString & "A") > 0 Or InStr(pUserPriv, Me.Tag.ToString & "E") > 0 Then
      tbnSave.Enabled = True
    Else
      tbnSave.Enabled = False
    End If
  End Sub

  Private Sub AddItem(ByVal BarCode As String)
    Dim mGet() As String
    mGet = pService.GetData("Drug", "Select GI.goodCode, GI.goodName, GI." & mShelfNoField & " as shelfNo From GoodBarcode GB inner join GoodInfo GI on GI.goodCode = GB.goodCode where GB.barCode = '" & BarCode & "' and GI.goodStat <> '0'")
    If mGet(0) = "1" Then
      ' เช็คซ้ำ
      For Each mRow As DataGridViewRow In dtgList.Rows
        If dtgList.Item("goodCode", mRow.Index).Value = mGet(1) Then
          Exit Sub
        End If
      Next

      dtgList.Rows.Add()
      dtgList.Item("goodCode", dtgList.Rows.Count - 1).Value = mGet(1)
      dtgList.Item("barCode", dtgList.Rows.Count - 1).Value = BarCode
      dtgList.Item("goodName", dtgList.Rows.Count - 1).Value = mGet(2)
      dtgList.Item("shelfNo", dtgList.Rows.Count - 1).Value = mGet(3)
      ReOrderList()
      dtgList.FirstDisplayedScrollingRowIndex = dtgList.Rows.Count - 1
      dtgList.ClearSelection()
    Else
      MessageBox.Show("ไม่มีข้อมูลสินค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End If
  End Sub

  Private Sub tbnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnFind.Click
    frmGoodSearch.ShowDialog()
    If frmGoodSearch.pOk = True Then
      AddItem(frmGoodSearch.pBarcode)
      txtBarcode.Text = ""
      txtBarcode.Select()
    End If
  End Sub

  Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      If txtBarcode.Text <> "" Then
        AddItem(txtBarcode.Text)
      End If
      txtBarcode.Text = ""
      txtBarcode.Focus()
    End If
  End Sub

  Private Sub ClearAll()
    dtgList.Rows.Clear()
    txtBarcode.Text = ""
    txtNewShelfNo.Text = ""
  End Sub

  Private Sub ReOrderList()
    For Each mRow As DataGridViewRow In dtgList.Rows
      dtgList.Item("itemNo", mRow.Index).Value = mRow.Index + 1
    Next
  End Sub

  Private Sub tbnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnSave.Click
    If dtgList.Rows.Count > 0 Then
      If txtNewShelfNo.Text = "" Then
        pMessageBox = New MyMessageBox("หากไม่ระบุเลขชั้นวางใหม่ โปรแกรมจะทำการล้างข้อมูลเลขชั้นวางปัจจุบันทั้งหมด", "คำเตือน", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
        If pMessageBox.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
          Exit Sub
        End If
      End If

      pMessageBox = New MyMessageBox("ยืนยันบันทึกเลขชั้นวางใหม่", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
      If pMessageBox.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
        Exit Sub
      End If

      Dim mSqlText(dtgList.Rows.Count * 2 - 1) As String
      Dim mLine As Integer = 0
      Dim mGoodCode As String

      For Each mRow As DataGridViewRow In dtgList.Rows
        mGoodCode = dtgList.Item("goodCode", mRow.Index).Value

        mSqlText(mLine) = "Update GoodInfo set " & mShelfNoField & " = '" & txtNewShelfNo.Text & "' where goodCode = '" & mGoodCode & "'"
        mLine += 1
      Next

      Dim mUpdate As String
      mUpdate = pService.UpdateData("Drug", mSqlText)
      If mUpdate = "1" Then
        ClearAll()
        ShowShelf()
      Else
        MessageBox.Show(mUpdate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
    End If
  End Sub

  Private Sub tbnShowNoShelf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnShowNoShelf.Click
    ShowGoodShelf("", mShelfNoField)
  End Sub

  Private Sub ShowGoodShelf(ByVal ShelfNo As String, ByVal ShelfNoField As String)
    Me.Cursor = Cursors.WaitCursor

    dtgList.Rows.Clear()

    Dim ds As New DataSet
    Dim mSqlText As String
    mSqlText = "Select goodCode, barCode, goodName, " & ShelfNoField & " from GoodInfo where " & ShelfNoField & " = '" & ShelfNo & "' and goodStat <> '0'"
    ' กรณีแสดงรายการที่ยังไม่ได้กำหนดชั้นวาง ให้แสดงเฉพาะรายการที่ยังมีสต๊อคคงเหลืออยู่
    If ShelfNo = "" Then
      mSqlText = mSqlText & " and " & mStockOnhandField & " > 0"
    End If

    mSqlText = mSqlText & " order by goodName"

    ds = pService.SelectData("Drug", mSqlText)

    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        Dim mDup As Boolean
        For i As Integer = 0 To dv.Count - 1
          With dv.Item(i)
            mDup = False
            For Each mRow As DataGridViewRow In dtgList.Rows
              If dtgList.Item("goodCode", mRow.Index).Value = .Item("goodCode") Then
                mDup = True
                Exit For
              End If
            Next

            If mDup = False Then
              dtgList.Rows.Add()
              dtgList.Item("goodCode", dtgList.Rows.Count - 1).Value = .Item("goodCode")
              dtgList.Item("barCode", dtgList.Rows.Count - 1).Value = .Item("barCode")
              dtgList.Item("goodName", dtgList.Rows.Count - 1).Value = .Item("goodName")
              dtgList.Item("shelfNo", dtgList.Rows.Count - 1).Value = .Item(mShelfNoField)
            End If
          End With
        Next
        ReOrderList()
        'dtgList.FirstDisplayedScrollingRowIndex = dtgList.Rows.Count - 1
        dtgList.ClearSelection()
      Else
        pMessageBox = New MyMessageBox("ไม่พบรายการสินค้า", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        pMessageBox.ShowDialog()
      End If
      dv = Nothing
    Else
      MessageBox.Show("Cannot select data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End If
    ds = Nothing

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub dtgList_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dtgList.RowsRemoved
    ReOrderList()
  End Sub

  Private Sub tbnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnClear.Click
    If dtgList.Rows.Count > 0 Then
      pMessageBox = New MyMessageBox("ยืนยันลบรายการทั้งหมด", "คำเตือน", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
      If pMessageBox.ShowDialog = Windows.Forms.DialogResult.OK Then
        ClearAll()
      End If
    Else
      ClearAll()
    End If
  End Sub

  Private Sub dtgShelf_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgShelf.CellDoubleClick
    If e.RowIndex >= 0 Then
      ShowGoodShelf(dtgShelf.Item("shelfNumb", e.RowIndex).Value, mShelfNoField)
    End If
  End Sub
End Class