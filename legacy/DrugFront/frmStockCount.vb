Public Class frmStockCount

  Dim mShelfNoField As String
  Dim mStockOnhandField As String
  Dim mUnitPriceField As String

  Private Sub frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    mShelfNoField = "shelfNo" & pBranchCode
    mStockOnhandField = "stockOnhand" & pBranchCode
    mUnitPriceField = "price" & pBranchPrice
    ShowShelfNo()
    CheckPriv()
  End Sub

  Private Sub CheckPriv()
    ' Add Edit
    If InStr(pUserPriv, Me.Tag.ToString & "A") > 0 Or InStr(pUserPriv, Me.Tag.ToString & "E") > 0 Then
      tbnSave.Enabled = True
    Else
      tbnSave.Enabled = False
    End If
  End Sub

  Private Sub ShowShelfNo()
    cboShelfNo.Items.Clear()
    'cboShelfNo.Items.Add("ทั้งหมด")

    For i As Integer = 0 To pGoodShelf.Length - 1
      cboShelfNo.Items.Add(pGoodShelf(i).ShelfNo)
    Next
    If cboShelfNo.Items.Count > 0 Then
      cboShelfNo.SelectedIndex = 0
    End If

    'Dim mSqlText As String
    'mSqlText = "Select distinct " & mShelfNoField & " as shelfNo From GoodInfo where " & mShelfNoField & " <> '' and goodStat <> '0' order by " & mShelfNoField

    'Dim ds As New DataSet
    'ds = pService.SelectData("Drug", mSqlText)
    'If IsNothing(ds) = False Then
    '  Dim dv As New DataView(ds.Tables(0))
    '  For i As Integer = 0 To dv.Count - 1
    '    cboShelfNo.Items.Add(dv.Item(i).Item("shelfNo"))
    '  Next
    '  dv = Nothing
    'End If
    'ds = Nothing
  End Sub

  Private Sub ShowList()
    Me.Cursor = Cursors.WaitCursor
    dtgList.Rows.Clear()

    Dim mSqlText As String
    mSqlText = "Select GI.goodCode, GI.goodName, GI." & mStockOnhandField & " as stockOnhand, " & mShelfNoField & " as shelfNo, UI.unitDesc, GB.barCode, GB.unitPrice From GoodInfo GI inner join UnitInfo UI on UI.unitCode = GI.unitCode inner join (SELECT DISTINCT goodCode, barCode, " & mUnitPriceField & " as unitPrice FROM GoodBarcode WHERE LEN(barCode) = '6' AND goodAmou = 1) GB on GI.goodCode = GB.goodCode where GI.goodStat <> '0'"
    
    If cboShelfNo.Text <> "ทั้งหมด" Then
      mSqlText = mSqlText & " and " & mShelfNoField & " = '" & cboShelfNo.Text & "'"
    End If

    mSqlText = mSqlText & " order by goodName"

    Dim ds As New DataSet
    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        dtgList.Rows.Add()
        dtgList.Item("goodCode", i).Value = dv.Item(i).Item("goodCode")
        dtgList.Item("barCode", i).Value = dv.Item(i).Item("barCode")
        dtgList.Item("goodName", i).Value = dv.Item(i).Item("goodName")
        dtgList.Item("unitDesc", i).Value = dv.Item(i).Item("unitDesc")
        dtgList.Item("unitPrice", i).Value = dv.Item(i).Item("unitPrice")
        dtgList.Item("shelfNo", i).Value = dv.Item(i).Item("shelfNo")
        dtgList.Item("stockOnhand", i).Value = dv.Item(i).Item("stockOnhand")
        dtgList.Item("stockOver", i).Value = ""
      Next
      dtgList.ClearSelection()
      dv = Nothing
    End If
    ds = Nothing

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub cboShelfNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboShelfNo.SelectedIndexChanged
    ShowList()
  End Sub

  Private Sub dtgList_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgList.CellEndEdit
    If dtgList.Columns(e.ColumnIndex).Name = "stockCount" Then
      Dim mOnhandAmou, mCountAmou, mOverAmou As Integer
      mOnhandAmou = CInt(Val(dtgList.Item("stockOnhand", e.RowIndex).Value))
      mCountAmou = CInt(Val(dtgList.Item("stockCount", e.RowIndex).Value))
      dtgList.Item("stockCount", e.RowIndex).Value = mCountAmou

      mOverAmou = mCountAmou - mOnhandAmou
      dtgList.Item("stockOver", e.RowIndex).Value = mOverAmou
      If mOverAmou < 0 Then
        dtgList.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
      Else
        If mOverAmou > 0 Then
          dtgList.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Blue
        Else
          dtgList.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
        End If
      End If
    End If
  End Sub

  Private Sub tbnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnSave.Click
    If dtgList.Rows.Count > 0 Then
      If MessageBox.Show("ยืนยันบันทึกข้อมูล", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
        Exit Sub
      End If
      '' เช็คว่ามีรายการที่ต้องบันทึกหรือไม่ (มีข้อมูลสต๊อคไม่ตรง)
      'Dim mListCount As Integer = 0
      'For Each mRow As DataGridViewRow In dtgList.Rows
      '  If dtgList.Item("stockOver", mRow.Index).Value.ToString <> "" AndAlso CInt(dtgList.Item("stockOver", mRow.Index).Value) <> 0 Then
      '    mListCount = mListCount + 1
      '  End If
      'Next
      'If mListCount > 0 Then
      '  If MessageBox.Show("ยืนยันบันทึกข้อมูล", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
      '    Exit Sub
      '  End If
      'Else
      '  MessageBox.Show("ไม่มีรายการสต๊อคไม่ตรง", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
      '  Exit Sub
      'End If

      Dim mSqlText(dtgList.Rows.Count + 1) As String
      Dim mLine As Integer
      Dim mBarCode As String
      Dim mGoodName As String
      Dim mUnitDesc As String
      Dim mUnitPrice As Double
      Dim mStockOnhand As Integer
      Dim mStockCount As Integer
      ' เช็คจำนวนรายการที่นับ จำนวนรายการที่ไม่ตรง
      Dim mCountItem As Integer
      Dim mOverItem As Integer
      mCountItem = dtgList.Rows.Count
      mOverItem = 0
      For Each mRow As DataGridViewRow In dtgList.Rows
        ' รายการที่ไม่ตรง
        If dtgList.Item("stockOver", mRow.Index).Value.ToString <> "" AndAlso CInt(dtgList.Item("stockOver", mRow.Index).Value) <> 0 Then
          mOverItem = mOverItem + 1
        End If
      Next

      mLine = 0
      mSqlText(mLine) = "Insert into HistBranchStockCount (branchCode, countDate, emplName, countItem, overItem) values ('" & pBranchCode & "', '" & MDYStr(pServerDateTime.Date) & "', '" & pUserName & "', " & mCountItem & ", " & mOverItem & ")"
      mLine += 1

      For Each mRow As DataGridViewRow In dtgList.Rows
        ' เก็บเฉพาะรายการที่ไม่ตรง
        If dtgList.Item("stockOver", mRow.Index).Value.ToString <> "" AndAlso CInt(dtgList.Item("stockOver", mRow.Index).Value) <> 0 Then
          mBarCode = dtgList.Item("barCode", mRow.Index).Value
          mGoodName = dtgList.Item("goodName", mRow.Index).Value
          mUnitDesc = dtgList.Item("unitDesc", mRow.Index).Value
          mUnitPrice = CDbl(dtgList.Item("unitPrice", mRow.Index).Value)
          mStockOnhand = CInt(dtgList.Item("stockOnhand", mRow.Index).Value)
          mStockCount = CInt(dtgList.Item("stockCount", mRow.Index).Value)
          pServerDateTime = pService.ServerDateTime

          mSqlText(mLine) = "Insert into BranchStockCount (countDate, branchCode, barCode, goodName, unitDesc, unitPrice, stockOnhand, stockCount) values ('" & MDYStr(pServerDateTime.Date) & "', '" & pBranchCode & "', '" & mBarCode & "', '" & Replace(mGoodName, "'", "''") & "', '" & mUnitDesc & "', " & mUnitPrice & ", " & mStockOnhand & ", " & mStockCount & ")"
          mLine = mLine + 1
        End If
      Next

      Dim mUpdate As String
      mUpdate = pService.UpdateData("Drug", mSqlText)
      If mUpdate = "1" Then
        MessageBox.Show("บันทึกข้อมูลเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        dtgList.Rows.Clear()
      Else
        MessageBox.Show(mUpdate, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
    End If
  End Sub
End Class