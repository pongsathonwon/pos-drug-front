Public Class frmGoodSearch

  Public pBarcode As String
  Public pGoodCode As String
  Public pGoodName As String
  Public pOk As Boolean
  Public pPreName As String ' รับอักษรให้ค้นหาทันที จากฟอร์มอื่น

  Private Sub frmGoodSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon
    pBarcode = ""
    pGoodCode = ""
    pGoodName = ""
    pOk = False
    ShowGoodType()
    ShowShelfNo()
    txtName.Text = ""
  End Sub

  Private Sub frmGoodSearch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    txtName.Focus()
    If pPreName <> "" Then
      StartSearch(pPreName, "")
      pPreName = ""
    End If
  End Sub

  Private Sub frmGoodSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.Escape Then
      Me.Close()
    End If
  End Sub

  Private Sub ShowGoodType()
    cboTypeCode.Items.Clear()
    cboTypeDesc.Items.Clear()
    cboTypeCode.Items.Add("0")
    cboTypeDesc.Items.Add("ทั้งหมด")

    For i As Integer = 0 To pGoodType.Length - 1
      cboTypeCode.Items.Add(pGoodType(i).Code)
      cboTypeDesc.Items.Add(pGoodType(i).Description)
    Next
    cboTypeDesc.SelectedIndex = 0

    'Dim ds As New DataSet
    'ds = pService.SelectData("Drug", "Select typeCode, typeDesc From TypeInfo Order by typeDesc")
    'If IsNothing(ds) = False Then
    '  Dim dv As New DataView(ds.Tables(0))
    '  For i As Integer = 0 To dv.Count - 1
    '    cboTypeCode.Items.Add(dv.Item(i).Item("typeCode"))
    '    cboTypeDesc.Items.Add(dv.Item(i).Item("typeDesc"))
    '  Next
    '  dv = Nothing
    'End If
    'ds = Nothing
    'cboTypeDesc.SelectedIndex = 0
  End Sub

  Private Sub ShowShelfNo()
    Dim mShelfNoField As String = "shelfNo" & pBranchCode

    cboShelfNo.Items.Clear()
    cboShelfNo.Items.Add("ทั้งหมด")

    Try
      For i As Integer = 0 To pGoodShelf.Length - 1
        cboShelfNo.Items.Add(pGoodShelf(i).ShelfNo)
      Next

    Catch ex As Exception

    End Try
    cboShelfNo.SelectedIndex = 0

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
    'cboShelfNo.SelectedIndex = 0
  End Sub

  Private Sub textKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress, txtGoodDesc.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      btnSearch.PerformClick()
      'SendKeys.Send("{Tab}")
    End If
  End Sub

  'Private Sub txtName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.LostFocus
  '  If txtName.Text.Length > 0 Then
  '    StartSearch(txtName.Text, "")
  '  Else
  '    If txtGoodDesc.Text <> "" Then
  '      StartSearch("", txtGoodDesc.Text)
  '    End If
  '  End If
  'End Sub

  Private Sub StartSearch(ByVal mName As String, ByVal mGoodDesc As String)
    Me.Cursor = Cursors.WaitCursor

    dtgList.Rows.Clear()
    Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
    Dim mMiniStockField As String = "miniStock" & pBranchCode
    Dim mPriceField As String = "price" & pBranchPrice
    Dim mShelfNoField As String = "shelfNo" & pBranchCode
    Dim mSqlText As String
    Dim dsGood As New DataSet
    'mSqlText = "SELECT GB.goodCode, GI.goodName, GI.goodDesc, GI." & mStockOnhandField & ", " & mMiniStockField & ", " & mShelfNoField & ", GI.goodRema, UI.unitDesc, GB.barCode, GB." & mPriceField & " as unitPrice FROM GoodBarcode GB INNER JOIN GoodInfo GI ON GB.goodCode = GI.goodCode and (GB.goodAmou = 1 and len(GB.barCode) = 6 and GB.unitCode = GI.unitCode) INNER JOIN UnitInfo UI ON GB.unitCode = UI.unitCode WHERE GI.goodStat = '1'"
    mSqlText = "SELECT GB.goodCode, GI.goodName, GI.goodDesc, GI." & mStockOnhandField & ", " & mMiniStockField & ", " & mShelfNoField & ", GI.goodRema, UI.unitDesc, GI.barCode, GB." & mPriceField & " as unitPrice FROM GoodBarcode GB INNER JOIN GoodInfo GI ON GB.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON GB.unitCode = UI.unitCode WHERE GI.goodStat = '1' and GB.goodAmou = 1 and GB.unitCode = GI.unitCode"
    ' ค้นตามชื่อการค้า
    If mName <> "" Then
      ' ถ้ารับอักษรจากฟอร์มอื่นให้ค้นหา ให้ค้นเริ่มจากอักษรตัวแรก
      If pPreName <> "" Then
        mSqlText = mSqlText & " and GI.goodName like '" & mName & "%'"
      Else
        ' ค้นทั้งข้อความ
        mSqlText = mSqlText & " and GI.goodName like '%" & mName & "%'"
      End If
    End If
    ' ค้นตามชื่อสามัญทางยา หากต้องการค้นหลายข้อความให้คั่นด้วยเครื่องหมาย , เช่น paracet,chlorphen
    If mGoodDesc <> "" Then
      Dim mText() As String
      mText = Split(mGoodDesc, ",")

      For i As Integer = 0 To mText.Length - 1
        mSqlText = mSqlText & " and Charindex('" & mText(i) & "', goodDesc) > 0"
      Next
    End If

    If cboTypeDesc.Text <> "ทั้งหมด" Then
      mSqlText = mSqlText & " and GI.typeCode = '" & cboTypeCode.Text & "'"
    End If

    If cboShelfNo.Text <> "ทั้งหมด" Then
      mSqlText = mSqlText & " and GI." & mShelfNoField & " = '" & cboShelfNo.Text & "'"
    End If

    mSqlText = mSqlText & " order by GI.goodName, UI.unitDesc, len(GB.barCode)"

    dsGood = pService.SelectData("Drug", mSqlText)


    If IsNothing(dsGood) = False Then
      Dim dvGood As New DataView(dsGood.Tables(0))
      For i As Integer = 0 To dvGood.Count - 1
        With dvGood.Item(i)
          dtgList.Rows.Add()
          dtgList.Item("goodName", i).Value = .Item("goodName")
          dtgList.Item("goodDesc", i).Value = .Item("goodDesc")
          dtgList.Item("unitDesc", i).Value = .Item("unitDesc")
          dtgList.Item("barCode", i).Value = .Item("barCode")
          dtgList.Item("shelfNo", i).Value = .Item(mShelfNoField)
          dtgList.Item("goodPrice", i).Value = .Item("unitPrice")
          dtgList.Item("stockOnhand", i).Value = .Item(mStockOnhandField)
          dtgList.Item("goodCode", i).Value = .Item("goodCode")
          dtgList.Item("miniStock", i).Value = .Item(mMiniStockField)
          dtgList.Item("goodRema", i).Value = .Item("goodRema")

          'dtgList.Rows.Add(.Item("goodName"), .Item("unitDesc"), .Item("barCode"), .Item(mShelfNoField), .Item("unitPrice"), .Item(mStockOnhandField), .Item("goodCode"), .Item(mMiniStockField), .Item("goodRema"))
        End With
      Next
      dvGood = Nothing
    End If
    dsGood = Nothing
    If dtgList.Rows.Count > 0 Then
      ' แถวที่มีรายการซ้ำ (ชื่อและหน่วยเหมือนกัน) ให้แสดงแถวแรก
      Dim mText1, mText2 As String
      mText1 = dtgList.Item("goodName", 0).Value.ToString & dtgList.Item("unitDesc", 0).Value.ToString
      For i As Integer = 1 To dtgList.Rows.Count - 1
        mText2 = dtgList.Item("goodName", i).Value.ToString & dtgList.Item("unitDesc", i).Value.ToString
        If mText2 = mText1 Then
          dtgList.Rows(i).Visible = False
        Else
          mText1 = mText2
        End If
      Next

      'txtName.Text = ""
      'txtGoodDesc.Text = ""
      dtgList.Focus()
    Else
      'txtName.Text = ""
      'txtGoodDesc.Text = ""
      txtName.Focus()
    End If

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub dtgList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgList.CellDoubleClick
    pOk = True
    pBarcode = dtgList.Item("barCode", dtgList.CurrentRow.Index).Value.ToString
    pGoodCode = dtgList.Item("goodCode", dtgList.CurrentRow.Index).Value.ToString
    pGoodName = dtgList.Item("goodName", dtgList.CurrentRow.Index).Value.ToString
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
      pBarcode = dtgList.Item("barCode", dtgList.CurrentRow.Index).Value.ToString
      pGoodCode = dtgList.Item("goodCode", dtgList.CurrentRow.Index).Value.ToString
      pGoodName = dtgList.Item("goodName", dtgList.CurrentRow.Index).Value.ToString
      Me.Close()
    End If
  End Sub

  Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
    If txtName.Text <> "" Or txtGoodDesc.Text <> "" Then
      StartSearch(txtName.Text, txtGoodDesc.Text)
    End If
  End Sub

  Private Sub cboTypeDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTypeDesc.SelectedIndexChanged
    cboTypeCode.SelectedIndex = cboTypeDesc.SelectedIndex
  End Sub
End Class