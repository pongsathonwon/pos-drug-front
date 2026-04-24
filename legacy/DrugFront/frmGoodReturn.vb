Public Class frmGoodReturn

  Dim mGoodCode As String
  Dim mBarCode As String
  Dim mUnitCode As String
  Dim mUnitDesc As String
  Dim mUnitCost As Double
  Dim mUnitPrice As Double
  Dim mUnitFactor As Integer
  Dim mRetuNumb As String
  Dim mNoBranchStock As String
  Dim mStockOnhand As Integer

  Structure GoodLot
    Dim LotNumber As String
    Dim ExpiDate As Date
  End Structure

  Dim mGoodLot As GoodLot

  Private Sub frmGoodReturn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    txtGoodName.Text = ""
    lblUnitDesc.Text = ""
    dtpExpi.Format = DateTimePickerFormat.Custom
    dtpExpi.CustomFormat = " "

    CheckPriv()
    InitReturnCause()
  End Sub

  Private Sub frmGoodOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.F4
        tbnGoodSearch.PerformClick()
      Case Keys.F8
        tbnSave.PerformClick()
      Case Keys.F12
        tbnClear.PerformClick()
    End Select
  End Sub

  Private Sub CheckPriv()
    ' Add
    If InStr(pUserPriv, Me.Tag.ToString & "A") > 0 Then
      btnAdd.Enabled = True
      tbnSave.Enabled = True
    Else
      btnAdd.Enabled = False
      tbnSave.Enabled = False
    End If
  End Sub

  Private Sub InitReturnCause()
    cboRetuCause.Items.Clear()
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select * from BranchReturnCause order by retuCauseDesc")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        cboRetuCause.Items.Add(dv.Item(i).Item("retuCauseDesc"))
      Next
    End If
    ds = Nothing
  End Sub

  Private Sub ShowGood(ByVal BarCode As String)
    Dim mUnitCostField As String = "unitCost" & pBranchCode
    Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
    Dim mPriceField As String = "price" & pBranchPrice
    'Dim getValue() As String

    Dim ds As New DataSet
    Dim mSqlText As String

    'mSqlText = "SELECT GB.goodCode, GI.goodName, GB.unitCode, UI.unitDesc, GI." & mUnitCostField & ", GI.noBranchStock, GI." & mStockOnhandField & ", GB." & mPriceField & ", UI.unitFactor FROM GoodBarcode GB INNER JOIN GoodInfo GI ON GB.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON GB.unitCode = UI.unitCode WHERE GB.barCode = '" & BarCode & "' and GB.goodAmou = 1"

    mSqlText = "SELECT GB.goodCode, GI.goodName, GI.unitCode, UI.unitDesc, UI2.unitDesc as packUnitDesc, GI." & mUnitCostField & ", GI.noBranchStock, GI." & mStockOnhandField & ", GB." & mPriceField & ", UI2.unitFactor FROM GoodBarcode GB INNER JOIN GoodInfo GI ON GB.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON GI.unitCode = UI.unitCode INNER JOIN UnitInfo UI2 ON GB.unitCode = UI2.unitCode WHERE GB.barCode = '" & BarCode & "' and GB.goodAmou = 1"

    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        With dv.Item(0)
          mBarCode = BarCode
          txtBarcode.Text = BarCode
          mGoodCode = .Item("goodCode")
          txtGoodName.Text = .Item("goodName")
          mUnitCode = .Item("unitCode")
          mUnitDesc = .Item("unitDesc")
          lblUnitDesc.Text = .Item("packUnitDesc")
          lblUnitDesc2.Text = .Item("packUnitDesc")
          mNoBranchStock = .Item("noBranchStock")
          mStockOnhand = .Item(mStockOnhandField)
          mUnitCost = .Item(mUnitCostField)

          txtStockOnhand.Text = Format(mStockOnhand, "#,##0")
          mUnitFactor = .Item("unitFactor")
          mUnitPrice = .Item(mPriceField) / .Item("unitFactor")

          FindLotNumber2(mGoodCode)
          txtGoodAmou.Focus()
        End With
      Else
        MessageBox.Show("ไม่พบข้อมูลสินค้า", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ClearGoodField()
        txtBarcode.Focus()
      End If
      dv = Nothing
    Else
      MessageBox.Show("Select data error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      ClearGoodField()
      txtBarcode.Focus()
    End If
    ds = Nothing
  End Sub

  Private Function FindLotNumber(ByVal GoodCode As String) As String
    Dim mLotNumber As String = ""
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "select distinct lotNumber, expiDate from BranchOrderCount BC inner join (select top 3 HI.orderNumb from HistInvoice HI inner join InvoiceList IL on IL.invoNumb = HI.invoNumb where HI.branchCode = '" & pBranchCode & "' and  IL.goodCode = '" & GoodCode & "' order by HI.invoDate desc) HV on HV.orderNumb = BC.orderNumb where BC.goodCode = '" & GoodCode & "'")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        mLotNumber = dv.Item(0).Item("lotNumber")
      End If
      dv = Nothing
    End If
    ds = Nothing
    Return mLotNumber
  End Function

  Private Sub FindLotNumber2(ByVal GoodCode As String)
    cboLotNumber.Items.Clear()
    cboExpiDate.Items.Clear()

    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "select distinct lotNumber, expiDate from BranchOrderCount BC inner join (select top 3 HI.orderNumb from HistInvoice HI inner join InvoiceList IL on IL.invoNumb = HI.invoNumb where HI.branchCode = '" & pBranchCode & "' and  IL.goodCode = '" & GoodCode & "' order by HI.invoDate desc) HV on HV.orderNumb = BC.orderNumb where BC.goodCode = '" & GoodCode & "'")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        For i As Integer = 0 To dv.Count - 1
          cboLotNumber.Items.Add(dv.Item(i).Item("lotNumber"))
          cboExpiDate.Items.Add(dv.Item(i).Item("expiDate"))
        Next
      End If
      dv = Nothing
    End If
    ds = Nothing
  End Sub

  Private Sub textKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress, txtGoodAmou.KeyPress, txtLotNo.KeyPress, txtRemark.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub ClearAll()
    txtBarcode.Text = ""
    txtGoodName.Text = ""
    txtGoodAmou.Text = ""
    lblUnitDesc.Text = ""
    lblUnitDesc2.Text = ""
    txtStockOnhand.Text = ""
    txtLotNo.Text = ""
    txtRemark.Text = ""
    dtpExpi.Format = DateTimePickerFormat.Custom
    dtpExpi.CustomFormat = " "
    InitReturnCause()
    dtgList.Rows.Clear()
    cboLotNumber.Items.Clear()
  End Sub

  Private Sub ClearGoodField()
    mBarCode = ""
    mGoodCode = ""
    txtBarcode.Text = ""
    txtGoodName.Text = ""
    txtGoodAmou.Text = ""
    lblUnitDesc.Text = ""
    txtLotNo.Text = ""
    txtRemark.Text = ""
    dtpExpi.Format = DateTimePickerFormat.Custom
    dtpExpi.CustomFormat = " "
    cboLotNumber.Items.Clear()
    InitReturnCause()
  End Sub

  Private Sub txtBarcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.LostFocus
    If txtBarcode.Text <> "" Then
      ShowGood(txtBarcode.Text)
    End If
  End Sub

  Private Sub AddList()
    If Val(txtGoodAmou.Text) <= 0 Then
      MessageBox.Show("กรุณาป้อนจำนวนคืน", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      txtGoodAmou.Text = ""
      txtGoodAmou.Focus()
      Exit Sub
    End If

    ' คืนเกินสต๊อคคงเหลือ ยกเว้นกรณีคลังส่งเกิน
    If Val(txtGoodAmou.Text) > mStockOnhand And mNoBranchStock = "0" And InStr(cboRetuCause.Text, "ส่งเกิน") <= 0 Then
      MessageBox.Show("สินค้าคืนเกินจำนวนสต๊อคคงเหลือ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If

    If cboRetuCause.Text = "" Then
      MessageBox.Show("กรุณาเลือกสาเหตุการคืนสินค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If
    ' ถ้าเลือกสาเหตุเกี่ยวกับอายุ และไม่ได้ป้อนวันหมดอายุ
    If InStr(cboRetuCause.Text, "อายุ") > 0 And dtpExpi.CustomFormat = " " Then
      MessageBox.Show("กรุณาป้อนวันหมดอายุ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If

    Dim mDup As Boolean = False
    '' หากรายการซ้ำ ให้บวกเพิ่ม
    'For i As Integer = 0 To dtgList.Rows.Count - 1
    '  If dtgList.Item("goodCode", i).Value.ToString = mGoodCode Then
    '    dtgList.Item("goodAmou", i).Value = dtgList.Item("goodAmou", i).Value + CInt(Val(txtGoodAmou.Text))
    '    dtgList.Item("unitDesc", i).Value = lblUnitDesc.Text
    '    dtgList.Item("unitCode", i).Value = mUnitCode
    '    dtgList.Item("unitCost", i).Value = mUnitCost
    '    dtgList.Item("unitPrice", i).Value = mUnitPrice
    '    dtgList.Item("lotNo", i).Value = txtLotNo.Text
    '    dtgList.Item("retuRema", i).Value = (cboRetuCause.Text & " " & txtRemark.Text).Trim

    '    If dtpExpi.CustomFormat = "" Then
    '      dtgList.Item("expiDate", i).Value = ThaiShortDate(dtpExpi.Value)
    '    Else
    '      dtgList.Item("expiDate", i).Value = ""
    '    End If

    '    dtgList.FirstDisplayedScrollingRowIndex = i
    '    dtgList.ClearSelection()
    '    'dtgList.Rows(i).Selected = True
    '    mDup = True
    '    Exit For
    '  End If
    'Next

    If mDup = False Then
      dtgList.Rows.Add()
      dtgList.Item("item", dtgList.Rows.Count - 1).Value = dtgList.Rows.Count
      dtgList.Item("goodCode", dtgList.Rows.Count - 1).Value = mGoodCode
      dtgList.Item("barCode", dtgList.Rows.Count - 1).Value = mBarCode
      dtgList.Item("goodName", dtgList.Rows.Count - 1).Value = txtGoodName.Text
      dtgList.Item("goodAmou", dtgList.Rows.Count - 1).Value = CInt(Val(txtGoodAmou.Text)) * mUnitFactor
      dtgList.Item("unitDesc", dtgList.Rows.Count - 1).Value = mUnitDesc
      dtgList.Item("unitCode", dtgList.Rows.Count - 1).Value = mUnitCode
      dtgList.Item("unitCost", dtgList.Rows.Count - 1).Value = mUnitCost
      dtgList.Item("unitPrice", dtgList.Rows.Count - 1).Value = mUnitPrice
      dtgList.Item("lotNo", dtgList.Rows.Count - 1).Value = cboLotNumber.Text ' txtLotNo.Text
      dtgList.Item("retuRema", dtgList.Rows.Count - 1).Value = (cboRetuCause.Text & "-" & txtRemark.Text).Trim

      If dtpExpi.CustomFormat = "" Then
        dtgList.Item("expiDate", dtgList.Rows.Count - 1).Value = dtpExpi.Value.Date ' ThaiShortDate(dtpExpi.Value)
      Else
        dtgList.Item("expiDate", dtgList.Rows.Count - 1).Value = ""
      End If

      dtgList.Item("noBranchStock", dtgList.Rows.Count - 1).Value = mNoBranchStock
      dtgList.Item("stockOnhand", dtgList.Rows.Count - 1).Value = mStockOnhand

      dtgList.FirstDisplayedScrollingRowIndex = dtgList.Rows.Count - 1
      dtgList.ClearSelection()
      'dtgList.Rows(dtgList.Rows.Count - 1).Selected = True
    End If

    ClearGoodField()
    txtBarcode.Focus()
  End Sub

  Private Sub btnNoExpi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNoExpi.Click
    ' ให้แสดงเป็นช่องว่าง
    dtpExpi.Format = DateTimePickerFormat.Custom
    dtpExpi.CustomFormat = " "
  End Sub

  Private Sub dtpExpi_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpExpi.ValueChanged
    ' ให้แสดงวันที่
    dtpExpi.Format = DateTimePickerFormat.Long
    dtpExpi.CustomFormat = ""
  End Sub

  Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    If mGoodCode <> "" Then
      AddList()
    End If
  End Sub

  Private Sub tbnGoodSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnGoodSearch.Click
    'Dim fGoodSearch As New frmGoodSearch
    frmGoodSearch.ShowDialog()
    If frmGoodSearch.pBarcode <> "" Then
      ShowGood(frmGoodSearch.pBarcode)
    End If
    'fGoodSearch = Nothing
  End Sub

  Private Sub dtgList_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dtgList.ColumnHeaderMouseClick
    ' เรียงเลขบรรทัดใหม่
    For i As Integer = 0 To dtgList.Rows.Count - 1
      dtgList.Item("item", i).Value = i + 1
    Next
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
    If MessageBox.Show("ยืนยันส่งคืนสินค้า", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
      Exit Sub
    End If

    If dtgList.Rows.Count > 0 Then
      Dim getValue() As String
      getValue = pService.GetData("Drug", "SELECT stockRetuNumb FROM BranchInfo WHERE branchCode = '" & pBranchCode & "'")
      If getValue(0) = "1" Then
        mRetuNumb = pBranchCode & "-" & Mid((1000000 + CInt(getValue(1))).ToString, 2)
      Else
        MessageBox.Show(getValue(1), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      End If
      ' ใช้วันที่และเวลาของ server
      pServerDateTime = pService.ServerDateTime

      Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
      Dim mSqlText((dtgList.Rows.Count * 4) + 3) As String
      Dim mLine As Integer = 0

      mSqlText(mLine) = "INSERT INTO HistBranchReturn (retuNumb, retuDate, branchCode, emplCode) VALUES ('" & mRetuNumb & "', '" & MDYStr(pServerDateTime.Date) & "', '" & pBranchCode & "', '" & pUserCode & "')"
      mLine += 1
      For i As Integer = 0 To dtgList.Rows.Count - 1
        With dtgList
          mSqlText(mLine) = "INSERT INTO BranchReturnList (retuNumb, goodCode, goodAmou, unitCode, unitCost, retuRema, unitPrice, lotNo, expiDate) VALUES ('" & mRetuNumb & "', '" & .Item("goodCode", i).Value.ToString & "', " & CInt(.Item("goodAmou", i).Value) & ", '" & .Item("unitCode", i).Value.ToString & "', " & CDbl(.Item("unitCost", i).Value) & ", '" & .Item("retuRema", i).Value.ToString & "', " & CDbl(.Item("unitPrice", i).Value) & ", '" & .Item("lotNo", i).Value.ToString & "', '" & .Item("expiDate", i).Value.ToString & "')"
          mLine += 1
          ' ตัดสต๊อค ยกเว้นเป็นสินค้าที่ไม่เก็บสต๊อค และไม่ใช่สินค้าส่งเกิน
          If .Item("noBranchStock", i).Value.ToString = "0" And InStr(.Item("retuRema", i).Value, "ส่งเกิน") <= 0 Then
            mSqlText(mLine) = "UPDATE GoodInfo set " & mStockOnhandField & " = " & mStockOnhandField & " - " & CInt(.Item("goodAmou", i).Value) & " WHERE goodCode = '" & .Item("goodCode", i).Value.ToString & "'"
            mLine += 1

            ' Front card
            mSqlText(mLine) = "Insert into FrontCard (stockDate, stockTime, workType, branchCode, docNumb, emplName, goodCode, goodAmou, stockOnhand) Values ('" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', 'RET', '" & pBranchCode & "', '" & mRetuNumb & "', '" & Mid(pUserName, 1, 10) & "', '" & .Item("goodCode", i).Value.ToString & "', " & CInt(.Item("goodAmou", i).Value) & ", " & (CInt(.Item("stockOnhand", i).Value) - CInt(.Item("goodAmou", i).Value)) & ")"
            mLine += 1
          End If
        End With
      Next

      mSqlText(mLine) = "UPDATE BranchInfo set stockRetuNumb = stockRetuNumb + 1 WHERE branchCode = '" & pBranchCode & "'"
      mLine += 1

      Dim retValue As String
      retValue = pService.UpdateData("Drug", mSqlText)
      If retValue = "1" Then
        pdc1.Print()
        MessageBox.Show("บันทึกเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        ClearAll()
        txtBarcode.Focus()
      Else
        MessageBox.Show(retValue, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      End If
    End If
  End Sub

  Private Sub tbnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnClear.Click
    ClearAll()
  End Sub

  Private Sub pdc1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdc1.PrintPage
    Dim prnFont As New Font("CordiaUPC", 12, GraphicsUnit.Point)
    Dim prnFontBold As New Font("CordiaUPC", 16, FontStyle.Bold)
    '        e.Graphics.DrawRectangle(Pens.Blue, 0, 0, 30, 10)
    Dim mRowPos As Single
    Dim mLeftMargin As Single = 5.0F
    Dim mCol2Pos As Single = 70.0F
    Dim mCol3Pos As Single = 260.0F

    Dim mLineNo As Integer
    Dim mLineSpace As Integer = 30
    Dim mRect As RectangleF
    Dim mAlign As New StringFormat()
    Dim mText As String
    ' ชื่อบริษัท สาขา
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = pCompName
    e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = " สาขา" & pBranchName
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' หัวเอกสาร
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ใบส่งคืนสินค้า เลขที่ " & mRetuNumb
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' วันที่-เวลา
    ' ใช้วันที่และเวลาของ server
    pServerDateTime = pService.ServerDateTime

    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = pServerDateTime.ToString("dd/MM/yyyy")
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' --------
    mRowPos = mLineNo * 33
    mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    For i As Integer = 0 To dtgList.Rows.Count - 1
      ' ลำดับที่
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 22.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = (i + 1).ToString & "."
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' ชื่อสินค้า
      mRect = New RectangleF(25, mRowPos, 140.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = dtgList.Item("goodName", i).Value.ToString
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' จำนวน
      mRect = New RectangleF(170, mRowPos, 35.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = Format(dtgList.Item("goodAmou", i).Value, "#,##0")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' หน่วย
      mRect = New RectangleF(210, mRowPos, 45.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = dtgList.Item("unitDesc", i).Value.ToString
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' หมายเหตุ
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "(" & dtgList.Item("retuRema", i).Value.ToString & ")"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    Next
    ' --------
    mRowPos = mLineNo * 32
    mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' ผู้ทำคืน
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ผู้คืน : " & pUserName
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
  End Sub

  Private Sub cboLotNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLotNumber.SelectedIndexChanged
    cboExpiDate.SelectedIndex = cboLotNumber.SelectedIndex
    dtpExpi.Value = cboExpiDate.Text
  End Sub
End Class
