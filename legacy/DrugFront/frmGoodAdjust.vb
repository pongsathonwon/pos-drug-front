Public Class frmGoodAdjust

  Public pPassCode As String
  Dim mGoodCode As String
  Dim mBarCode As String
  Dim mUnitCode As String
  Dim mStockOnhand As Integer
  Dim mGoodCount As Integer
  Dim mGoodAdjust As Integer
  Dim mUnitCost As Double
  Dim mUnitPrice As Double
  'Dim mIsOpen As Boolean

  Private Sub frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    lblGoodName.Text = ""
    lblUnitDesc.Text = ""
    btnImportCount.Visible = True
    btnClearStockCount.Visible = True

    CheckPriv()
    ShowAllStock()
  End Sub

  Private Sub frmGoodAdjust_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    'If mIsOpen = False Then
    '  ShowAllStock()
    '  'Me.WindowState = FormWindowState.Maximized
    '  mIsOpen = True
    'End If
  End Sub

  Private Sub frmGoodAdjust_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    Dim mFlag As Boolean = False
    For i As Integer = 0 To dtgList.Rows.Count - 1
      If dtgList.Item("GoodCount", i).Value.ToString <> "" Then
        mFlag = True
        Exit For
      End If
    Next
    If mFlag = True Then
      pMessageBox = New MyMessageBox("ท่านยังไม่ได้บันทึกปรับยอด หากปิดหน้าต่าง ข้อมูลที่บันทึกไว้จะถูกยกเลิกทั้งหมด (ยกเว้นข้อมูลที่ได้บันทึกชั่วคราวไว้) กรุณายืนยันปิดหน้าต่าง", "ประกาศ-ข่าวสาร", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
      If pMessageBox.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
        e.Cancel = True
      End If

      'MyMessageBox.pTitle = "คำเตือน"
      'MyMessageBox.pMessage = "ท่านยังไม่ได้บันทึกปรับยอด หากปิดหน้าต่าง ข้อมูลที่บันทึกไว้จะยกเลิกทั้งหมด (ยกเว้นข้อมูลที่ได้บันทึกชั่วคราวไว้) กรุณายืนยันปิดหน้าต่าง"
      'MyMessageBox.ShowDialog()
      'If MyMessageBox.pOk = False Then
      '  e.Cancel = True
      'End If
      'MyMessageBox = Nothing

      'If MessageBox.Show("ท่านยังไม่ได้บันทึกปรับยอด หากปิดหน้าต่าง ข้อมูลที่บันทึกไว้จะยกเลิกทั้งหมด (ยกเว้นข้อมูลที่ได้บันทึกชั่วคราวไว้) กรุณายืนยันปิดหน้าต่าง", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
      '  e.Cancel = True
      '  'Else
      '  '  ClearCount()
      'End If
    End If
  End Sub

  Private Sub ClearCount()
    Dim mSqlText(1) As String
    Dim mStockCountField As String = "stockCount" & pBranchCode
    mSqlText(0) = "UPDATE GoodInfo SET " & mStockCountField & " = 0"

    Dim mUpdate As String
    mUpdate = pService.UpdateData("Drug", mSqlText)
    If mUpdate <> "1" Then
      MessageBox.Show(mUpdate, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End If
  End Sub

  Private Sub frmGoodOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.F4
        tbnGoodSearch.PerformClick()
      Case Keys.F6
        tbnTempSave.PerformClick()
      Case Keys.F8
        tbnSave.PerformClick()
      Case Keys.Escape
        ClearGoodField()
        txtBarcode.Focus()
        'Me.Close()
    End Select
  End Sub

  Private Sub CheckPriv()
    ' Save
    If InStr(pUserPriv, Me.Tag.ToString & "A") > 0 Then
      btnAdd.Enabled = True
      tbnSave.Enabled = True
      tbnTempSave.Enabled = True
      btnImportCount.Enabled = True
      btnClearStockCount.Enabled = True
    Else
      btnAdd.Enabled = False
      tbnSave.Enabled = False
      tbnTempSave.Enabled = False
      btnImportCount.Enabled = False
      btnClearStockCount.Enabled = False
    End If
  End Sub

  Private Sub ShowGood(ByVal GoodCode As String, ByVal BarCode As String)
    Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
    Dim mUnitCostField As String = "unitCost" & pBranchCode
    Dim mUnitPriceField As String = "price" & pBranchPrice
    Dim getValue() As String
    Dim mSqlText As String
    If GoodCode <> "" Then
      mSqlText = "SELECT GI.goodCode, GI.goodName, GI.unitCode, UI.unitDesc, GI." & mStockOnhandField & ", GI." & mUnitCostField & ", GB.unitPrice FROM GoodInfo GI INNER JOIN UnitInfo UI ON GI.unitCode = UI.unitCode INNER JOIN (SELECT DISTINCT goodCode, " & mUnitPriceField & " AS unitPrice FROM GoodBarcode WHERE goodAmou = 1) GB ON GI.goodCode = GB.goodCode  WHERE GI.goodCode = '" & GoodCode & "'"
    Else
      mSqlText = "SELECT GB.goodCode, GI.goodName, GB.unitCode, UI.unitDesc, GI." & mStockOnhandField & ", GI." & mUnitCostField & ", GB." & mUnitPriceField & " FROM GoodBarcode GB INNER JOIN GoodInfo GI ON GB.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON GB.unitCode = UI.unitCode WHERE GB.goodAmou = 1 AND GB.barCode = '" & BarCode & "'"
    End If

    getValue = pService.GetData("Drug", mSqlText)

    If getValue(0) = "1" Then
      mBarCode = BarCode
      txtBarcode.Text = mBarCode
      mGoodCode = getValue(1)
      lblGoodName.Text = getValue(2)
      mUnitCode = getValue(3)
      lblUnitDesc.Text = getValue(4)
      mStockOnhand = CInt(getValue(5))
      lblStockOnhand.Text = mStockOnhand.ToString("#,##0")
      mUnitCost = CDbl(getValue(6))
      mUnitPrice = CDbl(getValue(7))
      txtGoodCount.Focus()
    Else
      MessageBox.Show("ไม่พบข้อมูลสินค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      ClearGoodField()
      txtBarcode.Focus()
    End If
  End Sub

  Private Sub ShowAllStock()
    Me.Cursor = Cursors.WaitCursor
    lblInform.Visible = True
    Application.DoEvents()
    Dim mSqlText As String
    Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
    Dim mUnitCostField As String = "unitCost" & pBranchCode
    Dim mUnitPriceField As String = "price" & pBranchPrice
    Dim ds As New DataSet

    'Dim mUnitDesc(1) As String
    'ds = pService.SelectData("Drug", "SELECT unitCode, unitDesc FROM UnitInfo")
    'If IsNothing(ds) = False Then
    '  Dim dv As New DataView(ds.Tables(0))
    '  ReDim mUnitDesc(dv.Count)
    '  For i As Integer = 0 To dv.Count - 1
    '    With dv.Item(i)
    '      mUnitDesc(CInt(.Item("unitCode"))) = .Item("unitDesc").ToString
    '    End With
    '  Next
    '  dv = Nothing
    'End If

    mSqlText = "SELECT GI.goodCode, GI.goodName, GI.unitCode, UI.unitDesc, GI." & mStockOnhandField & ", GI." & mUnitCostField & ", GB." & mUnitPriceField & ", GB.barCode FROM GoodInfo GI INNER JOIN UnitInfo UI ON GI.unitCode = UI.unitCode INNER JOIN (SELECT DISTINCT goodCode, barCode, " & mUnitPriceField & " FROM GoodBarcode WHERE LEN(barCode) = '6' AND goodAmou = 1) GB ON GB.goodCode = GI.goodCode WHERE GI.goodStat <> '0' and GI." & mStockOnhandField & " > 0 ORDER BY GI.goodName"

    ds = pService.SelectData("Drug", mSqlText)
    'ds = pService.SelectData("Drug", "SELECT GI.goodCode, GI.goodName, GI.unitCode, GI." & mStockOnhandField & ", GI." & mUnitCostField & ", GB." & mUnitPriceField & ", GB.barCode FROM GoodInfo GI INNER JOIN vGoodBarcode GB ON GB.goodCode = GI.goodCode WHERE GI.goodStat <> '0' ORDER BY GI.goodName")
    'ds = pService.SelectData("Drug", "SELECT GI.goodCode, GI.goodName, GI.unitCode, UI.unitDesc, GI." & mStockOnhandField & ", GI." & mUnitCostField & ", GB." & mUnitPriceField & ", GB.barCode FROM GoodInfo GI INNER JOIN UnitInfo UI ON GI.unitCode = UI.unitCode INNER JOIN vGoodBarcode GB ON GB.goodCode = GI.goodCode WHERE GI.goodStat = '1' ORDER BY GI.goodName")
    If IsNothing(ds) = False Then
      Dim mStockOnhand As Integer
      Dim dv As New DataView(ds.Tables(0))
      dtgList.Rows.Clear()
      If dv.Count > 0 Then
        For i As Integer = 0 To dv.Count - 1
          With dv.Item(i)
            mStockOnhand = CInt(.Item(mStockOnhandField))

            dtgList.Rows.Add()
            dtgList.Item("item", i).Value = i + 1
            dtgList.Item("goodCode", i).Value = .Item("goodCode")
            dtgList.Item("goodName", i).Value = .Item("goodName")
            dtgList.Item("barCode", i).Value = .Item("barCode")
            dtgList.Item("StockOnhand", i).Value = mStockOnhand
            dtgList.Item("GoodCount", i).Value = ""
            dtgList.Item("unitDesc", i).Value = .Item("unitDesc")
            dtgList.Item("unitCode", i).Value = .Item("unitCode")
            dtgList.Item("unitCost", i).Value = .Item(mUnitCostField)
            dtgList.Item("unitPrice", i).Value = .Item(mUnitPriceField)
          End With
        Next
      Else
        MessageBox.Show("ไม่มีข้อมูลรายการสินค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End If
      dv = Nothing
      ' นำข้อมูลการนับที่บันทึกชั่วคราวไว้มาแสดง
      Dim dsCount As New DataSet
      dsCount = pService.SelectData("Drug", "SELECT * FROM StockCount WHERE branchCode = '" & pBranchCode & "'")
      If IsNothing(dsCount) = False Then
        Dim dvCount As New DataView(dsCount.Tables(0))
        Dim mOnhand As Integer
        Dim mStockCount As Integer
        Dim mGoodAdjust As Integer
        Dim mUnitPrice As Double
        Dim mFound As Boolean
        For i As Integer = 0 To dvCount.Count - 1
          mFound = False
          For Each row As DataGridViewRow In dtgList.Rows
            If dtgList.Item("GoodCode", row.Index).Value.ToString = dvCount.Item(i).Item("goodCode").ToString Then
              mOnhand = CInt(Val(dtgList.Item("StockOnhand", row.Index).Value))
              mStockCount = CInt(dvCount.Item(i).Item("stockCount"))
              mUnitPrice = CDbl(dtgList.Item("unitPrice", row.Index).Value)
              mGoodAdjust = mStockCount - mOnhand
              dtgList.Item("GoodCount", row.Index).Value = mStockCount
              dtgList.Item("GoodAdjust", row.Index).Value = mGoodAdjust
              dtgList.Item("totalCost", row.Index).Value = mGoodAdjust * mUnitPrice
              CalTotalCost()
              ' ระบายสีตัวอักษร
              If mGoodAdjust < 0 Then
                dtgList.Rows(row.Index).DefaultCellStyle.ForeColor = Color.Red
              Else
                If mGoodAdjust > 0 Then
                  dtgList.Rows(row.Index).DefaultCellStyle.ForeColor = Color.Blue
                Else
                  dtgList.Rows(row.Index).DefaultCellStyle.ForeColor = Color.Black
                End If
              End If
              mFound = True
              Exit For
            End If
          Next
        Next
      End If
      dsCount = Nothing
    Else
      MessageBox.Show("Cannot select data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End If
    ds = Nothing
    lblInform.Visible = False
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub textKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress, txtGoodCount.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub ClearAll()
    txtBarcode.Text = ""
    lblGoodName.Text = ""
    txtGoodCount.Text = ""
    lblUnitDesc.Text = ""
    lblStockOnhand.Text = ""
    txtAllTotalCost.Text = ""
    dtgList.Rows.Clear()
    txtRemark.Text = ""
  End Sub

  Private Sub ClearGoodField()
    mBarCode = ""
    mGoodCode = ""
    txtBarcode.Text = ""
    lblGoodName.Text = ""
    txtGoodCount.Text = ""
    lblUnitDesc.Text = ""
    lblStockOnhand.Text = ""
    mStockOnhand = 0
    mGoodCount = 0
    mUnitCost = 0
    'mUnitPrice = 0
  End Sub

  Private Sub txtBarcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.LostFocus
    If txtBarcode.Text <> "" Then
      ShowGood("", txtBarcode.Text)
    End If
  End Sub

  Private Sub AddList()
    ' Check Priv
    If InStr(pUserPriv, Me.Tag.ToString & "A") <= 0 Then
      Exit Sub
    End If

    mGoodCount = CInt(Val(txtGoodCount.Text))
    mGoodAdjust = mGoodCount - mStockOnhand

    Dim mDup As Boolean = False
    ' เช็คซ้ำ
    For i As Integer = 0 To dtgList.Rows.Count - 1
      If dtgList.Item("GoodCode", i).Value.ToString = mGoodCode Then
        dtgList.FirstDisplayedScrollingRowIndex = i
        ' รายการซ้ำและมีการบันทึกจำนวนนับสต๊อคแล้ว
        If CLng(Val(dtgList.Item("GoodCount", i).Value)) > 0 Then
          dtgList.FirstDisplayedScrollingRowIndex = i
          If MessageBox.Show("รายการซ้ำ ต้องการเพิ่มจำนวนหรือไม่", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            ClearGoodField()
            txtBarcode.Focus()
            Exit Sub
          End If
        End If

        ' รายการซ้ำ ให้บวกจำนวนเพิ่ม
        Dim mPreCount As Integer
        Dim mUnitPrice As Double
        mPreCount = CInt(Val(dtgList.Item("GoodCount", i).Value))
        mUnitPrice = CDbl(dtgList.Item("unitPrice", i).Value)
        mGoodAdjust = mGoodCount + mPreCount - mStockOnhand

        dtgList.Item("StockOnhand", i).Value = mStockOnhand
        dtgList.Item("GoodCount", i).Value = mGoodCount + mPreCount
        dtgList.Item("GoodAdjust", i).Value = mGoodAdjust
        If mGoodAdjust < 0 Then
          dtgList.Rows(i).DefaultCellStyle.ForeColor = Color.Red
        Else
          If mGoodAdjust > 0 Then
            dtgList.Rows(i).DefaultCellStyle.ForeColor = Color.Blue
          Else
            dtgList.Rows(i).DefaultCellStyle.ForeColor = Color.Black
          End If
        End If
        dtgList.Item("totalCost", i).Value = mGoodAdjust * mUnitPrice
        CalTotalCost()

        dtgList.FirstDisplayedScrollingRowIndex = i
        dtgList.ClearSelection()
        mDup = True
        Exit For
      End If
    Next
    '' ไม่มีรายการ
    'If mDup = False Then
    '  MessageBox.Show("ไม่มีรายการ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '  Exit Sub
    'End If
    ' รายการไม่ซ้ำ ให้เพิ่มรายการต่อท้าย
    If mDup = False Then
      dtgList.Rows.Add()
      dtgList.Item("item", dtgList.Rows.Count - 1).Value = dtgList.Rows.Count
      dtgList.Item("goodCode", dtgList.Rows.Count - 1).Value = mGoodCode
      dtgList.Item("barCode", dtgList.Rows.Count - 1).Value = mBarCode
      dtgList.Item("goodName", dtgList.Rows.Count - 1).Value = lblGoodName.Text
      dtgList.Item("StockOnhand", dtgList.Rows.Count - 1).Value = mStockOnhand
      dtgList.Item("GoodCount", dtgList.Rows.Count - 1).Value = mGoodCount
      dtgList.Item("GoodAdjust", dtgList.Rows.Count - 1).Value = mGoodAdjust
      dtgList.Item("unitDesc", dtgList.Rows.Count - 1).Value = lblUnitDesc.Text
      dtgList.Item("unitCode", dtgList.Rows.Count - 1).Value = mUnitCode
      dtgList.Item("unitCost", dtgList.Rows.Count - 1).Value = mUnitCost
      dtgList.Item("unitPrice", dtgList.Rows.Count - 1).Value = mUnitPrice
      dtgList.Item("totalCost", dtgList.Rows.Count - 1).Value = mGoodAdjust * mUnitPrice

      CalTotalCost()

      If mGoodAdjust < 0 Then
        dtgList.Rows(dtgList.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Red
      Else
        If mGoodAdjust > 0 Then
          dtgList.Rows(dtgList.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Blue
        Else
          dtgList.Rows(dtgList.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Black
        End If
      End If

      dtgList.FirstDisplayedScrollingRowIndex = dtgList.Rows.Count - 1
      dtgList.ClearSelection()
    End If

    ClearGoodField()
    txtBarcode.Focus()
  End Sub

  Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    If mGoodCode <> "" Then
      AddList()
    End If
  End Sub

  Private Sub txtGoodAmou_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGoodCount.LostFocus
    If mGoodCode <> "" AndAlso txtGoodCount.Text <> "" Then
      AddList()
    End If
  End Sub

  Private Sub tbnGoodSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnGoodSearch.Click
    'Dim fGoodSearch As New frmGoodSearch
    frmGoodSearch.ShowDialog()
    If frmGoodSearch.pBarcode <> "" Then
      ShowGood("", frmGoodSearch.pBarcode)
    End If
    'fGoodSearch = Nothing
  End Sub

  Private Sub dtgList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgList.CellDoubleClick
    If e.RowIndex >= 0 Then
      ShowGood("", dtgList.Item("barCode", e.RowIndex).Value.ToString)
    End If
  End Sub

  'Private Sub dtgList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgList.CellDoubleClick
  '  If e.RowIndex >= 0 Then
  '    ShowGood(dtgList.Item("GoodCode", e.RowIndex).Value.ToString, "")
  '  End If
  'End Sub

  Private Sub dtgList_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dtgList.ColumnHeaderMouseClick
    ' เรียงเลขบรรทัดใหม่
    For i As Integer = 0 To dtgList.Rows.Count - 1
      dtgList.Item("item", i).Value = i + 1
    Next
  End Sub

  Private Sub dtgList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgList.KeyDown
    ' ป้องกันการกด Enter แล้วกระโดดไปบรรทัดต่อไป
    If e.KeyCode = Keys.Enter Then
      e.Handled = True
    End If
  End Sub

  Private Sub dtgList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtgList.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      ShowGood("", dtgList.Item("barCode", dtgList.CurrentRow.Index).Value.ToString)
    End If
  End Sub

  Private Sub dtgList_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgList.RowEnter
    If e.RowIndex >= 0 Then
      dtgList.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = dtgList.Rows(e.RowIndex).DefaultCellStyle.ForeColor
    End If
  End Sub

  Private Sub dtgList_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dtgList.RowsRemoved
    ' เรียงเลขบรรทัดใหม่
    For i As Integer = 0 To dtgList.Rows.Count - 1
      dtgList.Item("item", i).Value = i + 1
    Next
  End Sub

  Private Sub tbnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnSave.Click
    If dtgList.Rows.Count <= 0 Then
      Exit Sub
    End If
    ' เช็ครายการที่มีสต๊อคคงเหลือแต่ยังไม่ได้นับ
    For Each mRow As DataGridViewRow In dtgList.Rows
      If dtgList.Item("goodCount", mRow.Index).Value.ToString = "" Then
        pMessageBox = New MyMessageBox("กรุณาป้อนจำนวนนับได้ให้ครบทุกรายการ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        pMessageBox.ShowDialog()
        Exit Sub
      End If
      'If Val(dtgList.Item("stockOnhand", mRow.Index).Value) > 0 And Val(dtgList.Item("goodCount", mRow.Index).Value) = 0 Then
      '  pMessageBox = New MyMessageBox("กรุณาป้อนจำนวนนับได้ให้ครบทุกรายการ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      '  pMessageBox.ShowDialog()
      '  Exit Sub
      'End If
    Next

    If MessageBox.Show("ยืนยันปรับยอดสต๊อคสินค้า", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
      Exit Sub
    End If

    Dim mOnhandField As String
    mOnhandField = "stockOnhand" & pBranchCode

    Dim mAdjNumb As String
    Dim getValue() As String
    getValue = pService.GetData("Drug", "SELECT adjNumb FROM BranchInfo WHERE branchCode = '" & pBranchCode & "'")
    If getValue(0) = "1" Then
      mAdjNumb = pBranchCode & "-" & Mid((1000000 + CInt(getValue(1))).ToString, 2)
    Else
      MessageBox.Show(getValue(1), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End If
    ' ใช้วันที่และเวลาของ server
    pServerDateTime = pService.ServerDateTime

    Dim mSqlText((dtgList.Rows.Count * 4) + 4) As String
    Dim mLine As Integer = 0

    mSqlText(mLine) = "INSERT INTO StockAdjust (adjNumb, adjDate, adjTime, emplCode, branchCode, adjRemark) VALUES ('" & mAdjNumb & "', '" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', '" & pPassCode & "', '" & pBranchCode & "', '" & txtRemark.Text & "')"
    mLine += 1

    Dim mGoodAdjust As Integer
    For i As Integer = 0 To dtgList.Rows.Count - 1
      ' เฉพาะรายการที่มีการนับ
      If dtgList.Item("GoodCount", i).Value.ToString <> "" Then
        mSqlText(mLine) = "INSERT INTO AdjustList (adjNumb, goodCode, unitCode, stockAmou, countAmou, unitCost, unitPrice) VALUES ('" & mAdjNumb & "', '" & dtgList.Item("goodCode", i).Value.ToString & "', '" & dtgList.Item("unitCode", i).Value.ToString & "', " & CInt(dtgList.Item("StockOnhand", i).Value) & ", " & CInt(dtgList.Item("GoodCount", i).Value) & ", " & CDbl(dtgList.Item("unitCost", i).Value) & ", " & CDbl(dtgList.Item("unitPrice", i).Value) & ")"
        mLine += 1

        mGoodAdjust = CInt(dtgList.Item("GoodAdjust", i).Value)
        mSqlText(mLine) = "UPDATE GoodInfo set " & mOnhandField & " = " & mOnhandField & " + " & mGoodAdjust & " WHERE goodCode = '" & dtgList.Item("goodCode", i).Value.ToString & "'"
        mLine += 1

        ' Front card
        mSqlText(mLine) = "Insert into FrontCard (stockDate, stockTime, workType, branchCode, docNumb, emplName, goodCode, goodAmou, stockOnhand) Values ('" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', 'ADJ', '" & pBranchCode & "', '" & mAdjNumb & "', '" & Mid(pUserName, 1, 10) & "', '" & dtgList.Item("goodCode", i).Value.ToString & "', " & mGoodAdjust & ", " & (CInt(dtgList.Item("StockOnhand", i).Value) + mGoodAdjust) & ")"
        mLine += 1
      End If
    Next

    mSqlText(mLine) = "UPDATE BranchInfo set adjNumb = adjNumb + 1 WHERE branchCode = '" & pBranchCode & "'"
    mLine += 1
    ' ลบข้อมูลการบันทึกชั่วคราว
    mSqlText(mLine) = "DELETE FROM StockCount WHERE branchCode = '" & pBranchCode & "'"
    mLine += 1
    ' ลบข้อมูลการนับจาก HH
    mSqlText(mLine) = "Delete From StockHHCount Where branchCode = '" & pBranchCode & "'"
    mLine += 1

    Dim retValue As String
    retValue = pService.UpdateData("Drug", mSqlText)
    If retValue = "1" Then
      MessageBox.Show("บันทึกปรับยอดเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      ClearCount()
      ClearAll()
      Me.Close()
      'txtBarcode.Focus()
    Else
      MessageBox.Show(retValue, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End If
  End Sub

  Private Sub tbnTempSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnTempSave.Click
    If dtgList.Rows.Count > 0 Then
      Dim mStockCountField As String = "stockCount" & pBranchCode
      Dim mSqlText(dtgList.Rows.Count) As String
      Dim mLine As Integer = 0
      Dim mStockCount As Integer
      mSqlText(mLine) = "DELETE FROM StockCount WHERE branchCode = '" & pBranchCode & "'"
      mLine += 1
      For Each row As DataGridViewRow In dtgList.Rows
        With dtgList
          mStockCount = CInt(Val(.Item("GoodCount", row.Index).Value))
          If mStockCount > 0 Then
            'mSqlText(mLine) = "UPDATE GoodInfo SET " & mStockCountField & " = " & mStockCount & " WHERE goodCode = '" & .Item("GoodCode", row.Index).Value.ToString & "'"
            mSqlText(mLine) = "INSERT INTO StockCount (branchCode, goodCode, stockCount) VALUES ('" & pBranchCode & "', '" & .Item("GoodCode", row.Index).Value.ToString & "', " & mStockCount & ")"
            mLine += 1
          End If
        End With
      Next
      Dim mUpdate As String
      mUpdate = pService.UpdateData("Drug", mSqlText)
      If mUpdate = "1" Then
        MessageBox.Show("บันทึกจำนวนนับได้ชั่วคราวเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
    End If
  End Sub

  Private Sub tbnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnClear.Click
    If MessageBox.Show("ยืนยันล้างข้อมูลบันทึกชั่วคราว", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
      Dim mSqlText(1) As String
      mSqlText(0) = "DELETE FROM StockCount WHERE branchCode = '" & pBranchCode & "'"
      Dim mUpdate As String
      mUpdate = pService.UpdateData("Drug", mSqlText)
      If mUpdate <> "1" Then
        MessageBox.Show(mUpdate, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If

      ShowAllStock()
      btnImportCount.Visible = True
      btnClearStockCount.Visible = True
    End If
  End Sub

  Private Sub btnImportCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportCount.Click
    Me.Cursor = Cursors.WaitCursor
    Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
    Dim mUnitCostField As String = "unitCost" & pBranchCode
    Dim mUnitPriceField As String = "price" & pBranchPrice

    Dim ds As New DataSet
    Dim mSqlText As String
    mSqlText = "Select GI.barCode, GI.goodCode, GI.goodName, GI." & mStockOnhandField & " as stockOnhand, GI.unitCode, GI." & mUnitCostField & " as unitCost, UI.unitDesc, GB.unitPrice, sum(SC.countAmou) as countAmou From StockHHCount SC inner join GoodInfo GI on GI.goodCode = SC.goodCode inner join UnitInfo UI on UI.unitCode = GI.unitCode inner join (SELECT DISTINCT goodCode, unitCode, " & mUnitPriceField & " AS unitPrice FROM GoodBarcode WHERE goodAmou = 1) GB ON GB.goodCode = GI.goodCode and GB.unitCode = GI.unitCode Where SC.branchCode = '" & pBranchCode & "'"

    mSqlText = mSqlText & " group by GI.barCode, GI.goodCode, GI.goodName, GI." & mStockOnhandField & ", GI.unitCode, GI." & mUnitCostField & ", UI.unitDesc, GB.unitPrice"

    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        Dim mDup As Boolean = False
        Dim mGoodCode As String
        Dim mBarcode As String
        Dim mGoodName As String
        Dim mUnitDesc As String
        Dim mUnitCode As String
        Dim mUnitCost As Double
        Dim mUnitPrice As Double

        Dim mStockOnhand As Integer
        Dim mStockCount As Integer

        Dim mGoodAdjust As Integer
        'Dim mPreCount As Integer
        For i As Integer = 0 To dv.Count - 1
          With dv.Item(i)
            mGoodCode = .Item("goodCode")
            mBarcode = .Item("barCode")
            mGoodName = .Item("goodName")
            mUnitDesc = .Item("unitDesc")
            mUnitCode = .Item("unitCode")
            mUnitCost = .Item("unitCost")
            mUnitPrice = .Item("unitPrice")
            mStockOnhand = .Item("stockOnhand")
            mStockCount = .Item("countAmou")
            mGoodAdjust = mStockCount - mStockOnhand

            ' เช็คซ้ำ
            For x As Integer = 0 To dtgList.Rows.Count - 1
              If dtgList.Item("GoodCode", x).Value.ToString = mGoodCode Then
                '' รายการซ้ำ ให้บวกจำนวนเพิ่ม
                'mPreCount = CInt(Val(dtgList.Item("GoodCount", x).Value))
                'mGoodAdjust = mGoodAdjust + mPreCount 'mThisCount + mPreCount - mStockOnhand

                dtgList.Item("StockOnhand", x).Value = mStockOnhand
                dtgList.Item("GoodCount", x).Value = mStockCount
                dtgList.Item("GoodAdjust", x).Value = mGoodAdjust
                dtgList.Item("unitPrice", x).Value = mUnitPrice
                dtgList.Item("totalCost", x).Value = mGoodAdjust * mUnitPrice

                If mGoodAdjust < 0 Then
                  dtgList.Rows(x).DefaultCellStyle.ForeColor = Color.Red
                Else
                  If mGoodAdjust > 0 Then
                    dtgList.Rows(x).DefaultCellStyle.ForeColor = Color.Blue
                  Else
                    dtgList.Rows(x).DefaultCellStyle.ForeColor = Color.Black
                  End If
                End If

                'dtgList.ClearSelection()
                mDup = True
                Exit For
              End If
            Next

            ' รายการไม่ซ้ำ ให้เพิ่มรายการต่อท้าย
            If mDup = False Then
              dtgList.Rows.Add()

              dtgList.Item("item", dtgList.Rows.Count - 1).Value = dtgList.Rows.Count
              dtgList.Item("goodCode", dtgList.Rows.Count - 1).Value = mGoodCode
              dtgList.Item("barCode", dtgList.Rows.Count - 1).Value = mBarCode
              dtgList.Item("goodName", dtgList.Rows.Count - 1).Value = mGoodName
              dtgList.Item("StockOnhand", dtgList.Rows.Count - 1).Value = mStockOnhand
              dtgList.Item("GoodCount", dtgList.Rows.Count - 1).Value = mStockCount
              dtgList.Item("GoodAdjust", dtgList.Rows.Count - 1).Value = mGoodAdjust
              dtgList.Item("unitDesc", dtgList.Rows.Count - 1).Value = mUnitDesc
              dtgList.Item("unitCode", dtgList.Rows.Count - 1).Value = mUnitCode

              dtgList.Item("unitCost", dtgList.Rows.Count - 1).Value = mUnitCost
              dtgList.Item("unitPrice", dtgList.Rows.Count - 1).Value = mUnitPrice
              dtgList.Item("totalCost", dtgList.Rows.Count - 1).Value = mGoodAdjust * mUnitPrice

              If mGoodAdjust < 0 Then
                dtgList.Rows(dtgList.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Red
              Else
                If mGoodAdjust > 0 Then
                  dtgList.Rows(dtgList.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Blue
                Else
                  dtgList.Rows(dtgList.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Black
                End If
              End If
              dtgList.ClearSelection()
            End If

          End With
        Next

        CalTotalCost()

        'MessageBox.Show("นำเข้าข้อมูลเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        btnImportCount.Visible = False
        btnClearStockCount.Visible = False
      Else
        MessageBox.Show("ไม่มีข้อมูลการนับสต๊อค", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
      dv = Nothing
    Else
      MessageBox.Show("Cannot import data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End If
    ds = Nothing
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub btnClearStockCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearStockCount.Click
    If MessageBox.Show("ยืนยันล้างข้อมูลการนับสต๊อคในเครื่อง Handheld", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
      Dim mSqlText(0) As String
      mSqlText(0) = "Delete From StockHHCount Where branchCode = '" & pBranchCode & "'"
      Dim mUpdate As String
      mUpdate = pService.UpdateData("Drug", mSqlText)
      If mUpdate = "1" Then
        MessageBox.Show("ล้างข้อมูลเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Else
        MessageBox.Show(mUpdate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
    End If
  End Sub

  Private Sub CalTotalCost()
    Dim mAllTotalCost As Double = 0
    For Each mRow As DataGridViewRow In dtgList.Rows
      mAllTotalCost += Val(dtgList.Item("totalCost", mRow.Index).Value)
    Next
    txtAllTotalCost.Text = mAllTotalCost.ToString("#,##0.00")
  End Sub
End Class
