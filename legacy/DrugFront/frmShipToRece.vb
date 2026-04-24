Public Class frmShipToRece

  Dim mOrderDate As Date
  Dim mStockUnitCostField As String = "unitCost" & pBranchCode
  Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
  Dim mGoodCode As String
  Dim mReceNumb As String

  Private Sub frmGoodRece_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    dtpInvoice.Value = Now.Date
    CheckPriv()
  End Sub

  Private Sub ShowOrder(ByVal OrderNumb As String)
    Dim mSqlText As String
    Dim ds As New DataSet
    mSqlText = "Select SO.orderDate, SL.*, GI.goodName, GI.unitCost0 as unitCost, UI.unitDesc, UI.unitFactor, SO.orderStat, SO.branchOrderNumb, GI." & mStockUnitCostField & ", GI." & mStockOnhandField & ", GI.noBranchStock from StockOrderList SL inner join HistStockOrder SO on SL.orderNumb = SO.orderNumb inner join HistOrder HO on SO.branchOrderNumb = HO.orderNumb inner join GoodInfo GI on SL.goodCode = GI.goodCode inner join UnitInfo UI on SL.unitCode = UI.unitCode Where SL.orderNumb = '" & OrderNumb & "' and HO.branchCode = '" & pBranchCode & "' order by GI.goodName"

    Me.Cursor = Cursors.WaitCursor
    ds = pService.SelectData("Drug", mSqlText)
    Me.Cursor = Cursors.Default

    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        If dv.Item(0).Item("orderStat").ToString = "0" Then
          MessageBox.Show("ใบสั่งซื้อถูกยกเลิก ไม่สามารถรับสินค้าเข้าได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
          txtOrderNumb.Text = ""
          dtgList.Rows.Clear()
          txtOrderNumb.Focus()
          Exit Sub
        End If

        mOrderDate = CDate(dv.Item(0).Item("orderDate"))
        ' ใบ PO ที่อายุเกิดกำหนด
        If mOrderDate.AddDays(pShiptoPOLifespan) < pServerDateTime.Date Then
          pMessageBox = New MyMessageBox("ใบสั่งซื้อนี้ เกินกำหนดรับเข้าแล้ว", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
          pMessageBox.ShowDialog()
          txtOrderNumb.Text = ""
          dtgList.Rows.Clear()
          txtOrderNumb.Focus()
          Exit Sub
        End If

        'If dv.Item(0).Item("orderStat").ToString = "2" Then
        '  MessageBox.Show("ใบสั่งซื้อนี้ ได้ทำการรับเข้าสินค้าเรียบร้อยแล้ว", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '  txtOrderNumb.Text = ""
        '  dtgList.Rows.Clear()
        '  txtOrderNumb.Focus()
        '  Exit Sub
        'End If

        txtBranchOrderNumb.Text = dv.Item(0).Item("branchOrderNumb").ToString

        dtgList.Rows.Clear()
        For i As Integer = 0 To dv.Count - 1
          With dv.Item(i)
            dtgList.Rows.Add()
            dtgList.Item("item", i).Value = i + 1
            dtgList.Item("goodCode", i).Value = .Item("goodCode")
            dtgList.Item("goodName", i).Value = .Item("goodName")
            dtgList.Item("orderAmou", i).Value = .Item("orderAmou")
            dtgList.Item("receAmou", i).Value = .Item("receAmou")
            dtgList.Item("thisRece", i).Value = 0 'CInt(.Item("orderAmou")) - CInt(.Item("receAmou"))
            dtgList.Item("unitCode", i).Value = .Item("unitCode")
            dtgList.Item("unitDesc", i).Value = .Item("unitDesc")
            '' ต้นทุนต่อหน่วย ให้บวก 4% จากราคาสต๊อคกลาง
            'dtgList.Item("unitCost", i).Value = CDbl(.Item("unitCost")) + (CDbl(.Item("unitCost")) * 4 / 100)
            ' ใช้ราคาทุนต่อหน่วยจากใบ PO ไม่บวก 4% (เริ่ม กพ 2566)
            dtgList.Item("unitCost", i).Value = .Item("subTotal") / (.Item("orderAmou") + .Item("freeAmou")) * .Item("unitFactor")

            dtgList.Item("stockOnhand", i).Value = .Item(mStockOnhandField)
            dtgList.Item("stockUnitCost", i).Value = .Item(mStockUnitCostField)
            'If CInt(.Item("goodAmou")) = 0 Then ' จำนวนเป็น 0 ให้แสดงสี
            '  dtgList.Rows(i).DefaultCellStyle.BackColor = Color.Tomato
            'End If
            dtgList.Item("noBranchStock", i).Value = .Item("noBranchStock")
          End With
        Next
        CheckRow()
      Else
        MessageBox.Show("ไม่พบข้อมูลใบสั่งซื้อ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        dtgList.Rows.Clear()
        txtOrderNumb.Text = ""
        txtOrderNumb.Focus()
      End If
      dv = Nothing
    Else
      MessageBox.Show("Error on select data", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      txtOrderNumb.Text = ""
      txtOrderNumb.Focus()
    End If
    ds = Nothing
  End Sub

  Private Sub txtOrderNumb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrderNumb.KeyPress, txtRemark.KeyPress, txtBarcode.KeyPress, txtInvoiceNumb.KeyPress, txtThisRece.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub txtOrderNumb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrderNumb.LostFocus
    If txtOrderNumb.Text <> "" Then
      ShowOrder(txtOrderNumb.Text)
    End If
  End Sub

  Private Sub txtBarcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.LostFocus
    If txtBarcode.Text <> "" Then
      ShowGood("", txtBarcode.Text)
    End If
  End Sub

  Private Sub ShowGood(ByVal GoodCode As String, ByVal BarCode As String)
    Dim getValue() As String
    Dim mSqlText As String
    If GoodCode <> "" Then
      mSqlText = "SELECT goodCode, goodName FROM GoodInfo WHERE goodCode = '" & GoodCode & "'"
    Else
      mSqlText = "SELECT GB.goodCode, GI.goodName FROM GoodBarcode GB INNER JOIN GoodInfo GI ON GB.goodCode = GI.goodCode WHERE GB.barCode = '" & BarCode & "'"
    End If

    getValue = pService.GetData("Drug", mSqlText)

    If getValue(0) = "1" Then
      mGoodCode = getValue(1)
      ' เช็คจำนวนสั่งจากรายการ
      Dim mFound As Boolean = False
      For Each mRow As DataGridViewRow In dtgList.Rows
        If dtgList.Item("goodCode", mRow.Index).Value.ToString = mGoodCode Then
          lblOrderAmou.Text = dtgList.Item("orderAmou", mRow.Index).Value.ToString
          lblUnitDesc.Text = dtgList.Item("unitDesc", mRow.Index).Value.ToString
          txtThisRece.Text = lblOrderAmou.Text
          mFound = True
          Exit For
        End If
      Next
      If mFound = False Then
        MessageBox.Show("ไม่มีรายการสั่ง", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        ClearGoodField()
        txtBarcode.Focus()
        Exit Sub
      End If

      txtBarcode.Text = BarCode
      lblGoodName.Text = getValue(2)
      txtThisRece.Focus()
    Else
      MessageBox.Show("ไม่พบข้อมูลสินค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      ClearGoodField()
      txtBarcode.Focus()
    End If
  End Sub

  Private Sub ClearGoodField()
    mGoodCode = ""
    txtBarcode.Text = ""
    lblGoodName.Text = ""
    txtThisRece.Text = ""
    lblUnitDesc.Text = ""
    lblOrderAmou.Text = ""
  End Sub

  Private Sub tbnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnSave.Click
    If txtOrderNumb.Text <> "" AndAlso dtgList.Rows.Count > 0 Then
      If dtpInvoice.Value < mOrderDate Or dtpInvoice.Value > pServerDateTime.Date Then
        MessageBox.Show("วันที่บิลต้องอยู่ระหว่างวันที่สั่งซื้อและวันรับของ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Exit Sub
      End If

      Dim mIsCorrect As Boolean
      ' เช็คว่ามีรายการรับหรือไม่
      mIsCorrect = False
      For Each mRow As DataGridViewRow In dtgList.Rows
        If CInt(dtgList.Item("thisRece", mRow.Index).Value) > 0 Then
          mIsCorrect = True
          Exit For
        End If
      Next

      If mIsCorrect = False Then
        MessageBox.Show("ไม่มีรายการรับเข้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Exit Sub
        'Else
        '  ' เช็คว่าจำนวนรับไม่เกินจำนวนที่ค้างส่ง
        '  mIsCorrect = True
        '  Dim mPendAmou As Integer
        '  For Each mRow As DataGridViewRow In dtgList.Rows
        '    mPendAmou = CInt(dtgList.Item("orderAmou", mRow.Index).Value) - CInt(dtgList.Item("receAmou", mRow.Index).Value)
        '    If CInt(dtgList.Item("thisRece", mRow.Index).Value) > 0 AndAlso CInt(dtgList.Item("thisRece", mRow.Index).Value) > mPendAmou Then
        '      mIsCorrect = False
        '      Exit For
        '    End If
        '  Next
        '  If mIsCorrect = False Then
        '    MessageBox.Show("จำนวนรับเกินจำนวนสั่ง", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Exit Sub
        '  End If
      End If

      If txtInvoiceNumb.Text = "" Then
        MessageBox.Show("กรุณาป้อนเลขที่ใบส่งสินค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Exit Sub
      End If
      '' ถ้าวันที่บิลต้องไม่เกินวันที่ปัจจุบัน
      'If dtpInvoice.Value > Now.Date Then
      '  MessageBox.Show("วันที่บิลไม่ถูกต้อง", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      '  Exit Sub
      'End If

      If MessageBox.Show("ยืนยันรับสินค้า", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        ' disable ปุ่มบันทึก ป้องกันการคลิ๊กซ้ำ
        tbnSave.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        lblPleaseWait.Visible = True
        Application.DoEvents()

        Dim getValue() As String
        getValue = pService.GetData("Drug", "SELECT receNumb FROM BranchInfo WHERE branchCode = '" & pBranchCode & "'")
        If getValue(0) = "1" Then
          mReceNumb = pBranchCode & "-" & Mid((1000000 + CInt(getValue(1))).ToString, 2)
        Else
          MessageBox.Show(getValue(1), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
          Me.Cursor = Cursors.Default
          lblPleaseWait.Visible = False
          tbnSave.Enabled = True
          Exit Sub
        End If
        '' invoNumb นำไปสร้างใบ invoice เพื่อนำไปออกรายงานซื้อ
        ''#############################
        'Dim mInvoNumb As String
        'getValue = pService.GetData("Drug", "SELECT invoNumb FROM SystInfo")
        'If getValue(0) = "1" Then
        '  mInvoNumb = Mid((1000000 + CInt(getValue(1))).ToString, 2)
        'Else
        '  MessageBox.Show(getValue(1), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '  Exit Sub
        'End If
        ''#############################

        ' ใช้วันที่และเวลาของ server
        pServerDateTime = pService.ServerDateTime

        Dim mSqlText((dtgList.Rows.Count * 6) + 7) As String
        Dim mLine As Integer = 0

        mSqlText(mLine) = "INSERT INTO HistRece (receNumb, receDate, receTime, branchCode, emplCode, receRema, orderNumb, branchOrderNumb, invoiceNumb, invoiceDate) VALUES ('" & mReceNumb & "', '" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', '" & pBranchCode & "', '" & pUserCode & "', '" & Replace(txtRemark.Text, "'", "''") & "', '" & txtOrderNumb.Text & "', '" & txtBranchOrderNumb.Text & "', '" & txtInvoiceNumb.Text & "', '" & MDYStr(dtpInvoice.Value) & "')"
        mLine += 1
        '' สร้าง invoice เพื่อนำไปออกรายงานการซื้อ
        ''#######################
        'mSqlText(mLine) = "INSERT INTO HistInvoice (invoNumb, invoDate, invoTime, branchCode, emplCode, invoRema, invoStat, orderNumb, receNumb, newGood, isShipTo, receDate, receTime, receEmplCode) VALUES ('" & mInvoNumb & "', '" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', '" & pBranchCode & "', '" & pUserCode & "', '" & Replace(txtRemark.Text, "'", "''") & "', '2', '" & txtOrderNumb.Text & "', '" & mReceNumb & "', '0', '1', '" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', '" & pUserCode & "')"
        'mLine += 1
        ''#######################

        'mSqlText(mLine) = "UPDATE HistStockOrder set orderStat = '2' WHERE OrderNumb = '" & txtOrderNumb.Text & "'"
        'mLine += 1

        mSqlText(mLine) = "UPDATE HistOrder set orderStat = '9', invoNumb = '" & mReceNumb & "' WHERE OrderNumb = '" & txtBranchOrderNumb.Text & "'"
        mLine += 1

        Dim mAvgCost As Single
        'Dim mReceAmou As Integer
        Dim mThisRece As Integer
        Dim mStockOnhand As Integer
        Dim mStockUnitCost As Single
        Dim mUnitCost As Single
        For i As Integer = 0 To dtgList.Rows.Count - 1
          'mReceAmou = CInt(dtgList.Item("ReceAmou", i).Value)
          mThisRece = CInt(dtgList.Item("thisRece", i).Value)
          ' บันทึกเฉพาะรายการที่มีจำนวนรับเท่านั้น
          If mThisRece > 0 Then
            mStockOnhand = CInt(dtgList.Item("StockOnhand", i).Value)
            mStockUnitCost = CSng(dtgList.Item("StockUnitCost", i).Value)
            mUnitCost = CSng(dtgList.Item("UnitCost", i).Value)

            mSqlText(mLine) = "INSERT INTO ReceList (receNumb, goodCode, goodAmou, unitCode, unitCost) VALUES ('" & mReceNumb & "', '" & dtgList.Item("goodCode", i).Value.ToString & "', " & mThisRece & ", '" & dtgList.Item("unitCode", i).Value.ToString & "', " & mUnitCost & ")"
            mLine += 1
            '' สร้าง invoice เพื่อนำไปออกรายงานซื้อ
            ''##########################
            'mSqlText(mLine) = "INSERT INTO InvoiceList (invoNumb, goodCode, goodAmou, receAmou, orderAmou, unitCode, unitCost, seriesNo) VALUES ('" & mInvoNumb & "', '" & dtgList.Item("goodCode", i).Value.ToString & "', " & mThisRece & ", " & mThisRece & ", " & dtgList.Item("orderAmou", i).Value & ", '" & dtgList.Item("unitCode", i).Value.ToString & "', " & mUnitCost & ", 1)"
            'mLine += 1
            ''##########################
            ' update ใบสั่ง
            mSqlText(mLine) = "UPDATE StockOrderList SET receNumb = '" & mReceNumb & "', receAmou = receAmou + " & mThisRece & ", itemStat = '3' WHERE orderNumb = '" & txtOrderNumb.Text & "' AND goodCode = '" & dtgList.Item("goodCode", i).Value.ToString & "'"
            mLine += 1
            ' Front card
            mSqlText(mLine) = "Insert into FrontCard (stockDate, stockTime, workType, branchCode, docNumb, emplName, goodCode, goodAmou, stockOnhand) Values ('" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', 'REC', '" & pBranchCode & "', '" & mReceNumb & "', '" & Mid(pUserName, 1, 10) & "', '" & dtgList.Item("goodCode", i).Value.ToString & "', " & mThisRece & ", " & (mStockOnhand + mThisRece) & ")"
            mLine += 1

            If dtgList.Item("noBranchStock", i).Value.ToString = "0" Then
              ' ราคาทุนเฉลี่ยใหม่ คำนวนจาก (มูลค่าจน.ที่เหลือ + มูลค่าจน.ที่รับ) / จำนวนทั้งหมด
              If mStockOnhand <= 0 Then ' ถ้าสต๊อคเดิมเป็นศูนย์หรือติดลบ ให้ใช้ทุนเฉลี่ยใหม่
                mAvgCost = mUnitCost
              Else
                mAvgCost = ((mStockOnhand * mStockUnitCost) + (mThisRece * mUnitCost)) / (mStockOnhand + mThisRece)
              End If

              mSqlText(mLine) = "UPDATE GoodInfo SET " & mStockOnhandField & " = " & mStockOnhandField & " + " & mThisRece & ", " & mStockUnitCostField & " = " & mAvgCost & " WHERE goodCode = '" & dtgList.Item("goodCode", i).Value.ToString & "'"
              mLine += 1
            End If
          End If
        Next

        ' ปรับสถานะใบสั่งซื้อเป็นรับครบหรือรับบางส่วน
        Dim mOrderStat As String = "3"
        For Each mRow As DataGridViewRow In dtgList.Rows
          If (dtgList.Item("receAmou", mRow.Index).Value + dtgList.Item("thisRece", mRow.Index).Value) < dtgList.Item("orderAmou", mRow.Index).Value Then
            mOrderStat = "2"
            Exit For
          End If
        Next
        mSqlText(mLine) = "Update HistStockOrder set orderStat = '" & mOrderStat & "' Where orderNumb = '" & txtOrderNumb.Text & "'"
        mLine += 1

        mSqlText(mLine) = "UPDATE BranchInfo set receNumb = receNumb + 1 WHERE branchCode = '" & pBranchCode & "'"
        mLine += 1

        mSqlText(mLine) = "Update SystInfo set invoNumb = invoNumb + 1"
        mLine += 1

        Application.DoEvents()

        Dim retValue As String
        retValue = pService.UpdateData("Drug", mSqlText)
        If retValue = "1" Then
          ' ################
          ' พิมพ์ใบรับสินค้า
          'pdc1.Print()
          ' ################

          lblPleaseWait.Visible = False
          MessageBox.Show("บันทึกรับสินค้าเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
          txtOrderNumb.Text = ""
          txtBranchOrderNumb.Text = ""
          txtInvoiceNumb.Text = ""
          txtRemark.Text = ""
          dtpInvoice.Value = Now.Date
          dtgList.Rows.Clear()
          txtOrderNumb.Focus()
        Else
          MessageBox.Show(retValue, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
          'Exit Sub
        End If
        tbnSave.Enabled = True
        lblPleaseWait.Visible = False
        Me.Cursor = Cursors.Default
      End If
    End If
  End Sub

  Private Sub frmShipToRece_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.F4
        tbnGoodSearch.PerformClick()
      Case Keys.F8
        tbnSave.PerformClick()
    End Select
  End Sub

  Private Sub CheckPriv()
    ' Add
    If InStr(pUserPriv, Me.Tag.ToString & "A") OrElse InStr(pUserPriv, Me.Tag.ToString & "E") > 0 Then
      tbnSave.Enabled = True
      dtgList.Columns("thisRece").ReadOnly = False
    Else
      tbnSave.Enabled = False
      dtgList.Columns("thisRece").ReadOnly = True
    End If
  End Sub

  Private Sub dtgList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgList.CellDoubleClick
    If e.RowIndex > -1 Then
      ShowGood(dtgList.Item("goodCode", e.RowIndex).Value.ToString, "")

    End If
  End Sub

  Private Sub dtgList_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgList.CellEndEdit
    CheckRow()
  End Sub

  Private Sub CheckRow()
    ' เช็ครายการที่ไม่มีจำนวนรับ ให้แสดงสีแดง
    Dim mThisRece As Integer
    Dim mOrderAmou As Integer
    Dim mReceAmou As Integer
    Dim mColor As Color
    Dim mReceCount As Integer = 0
    For Each mRow As DataGridViewRow In dtgList.Rows
      mThisRece = CInt(dtgList.Item("thisRece", mRow.Index).Value)
      mOrderAmou = CInt(dtgList.Item("orderAmou", mRow.Index).Value)
      mReceAmou = CInt(dtgList.Item("receAmou", mRow.Index).Value)

      If mThisRece <= 0 Then
        mColor = Color.Red
        'dtgList.Rows(mRow.Index).DefaultCellStyle.ForeColor = Color.Red
      Else
        If mThisRece > mOrderAmou - mReceAmou Then
          mColor = Color.Blue
          'dtgList.Rows(mRow.Index).DefaultCellStyle.ForeColor = Color.Blue
        Else
          If mThisRece < mOrderAmou - mReceAmou Then
            mColor = Color.Green
            'dtgList.Rows(mRow.Index).DefaultCellStyle.ForeColor = Color.Green
          Else
            mColor = Color.Black
            'dtgList.Rows(mRow.Index).DefaultCellStyle.ForeColor = Color.Black
          End If
        End If
      End If
      dtgList.Rows(mRow.Index).DefaultCellStyle.ForeColor = mColor

      If mThisRece > 0 Then
        mReceCount += 1
      End If
    Next
    lblTotalItem.Text = "รวมรับ " & mReceCount.ToString & " รายการ"
  End Sub

  Private Sub tbnGoodSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnGoodSearch.Click
    frmGoodSearch.ShowDialog()
    If frmGoodSearch.pBarcode <> "" Then
      ShowGood("", frmGoodSearch.pBarcode)
    End If
  End Sub

  Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    If mGoodCode <> "" Then 'AndAlso CInt(Val(txtReceAmou.Text)) > 0 Then
      Dim mOrderAmou, mReceAmou, mThisRece As Integer

      For Each mRow As DataGridViewRow In dtgList.Rows
        If dtgList.Item("goodCode", mRow.Index).Value.ToString = mGoodCode Then
          mOrderAmou = dtgList.Item("orderAmou", mRow.Index).Value
          mReceAmou = dtgList.Item("receAmou", mRow.Index).Value
          mThisRece = Val(txtThisRece.Text)
          If mThisRece <> mOrderAmou - mReceAmou Then
            If MessageBox.Show("จำนวนรับไม่เท่ากับจำนวนสั่ง ยืนยันรับสินค้า..", "ยืนยัน", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then
              Exit Sub
            End If
          End If

          dtgList.Item("thisRece", mRow.Index).Value = mThisRece
          Exit For
        End If
      Next
      CheckRow()
      ClearGoodField()
      txtBarcode.Focus()
    End If
  End Sub

  Private Sub dtgList_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgList.Sorted
    For i As Integer = 0 To dtgList.Rows.Count - 1
      dtgList.Item("item", i).Value = i + 1
    Next
  End Sub

  Private Sub pdc1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdc1.PrintPage
    Dim prnFont As New Font("CordiaUPC", 12, GraphicsUnit.Point)
    Dim prnFontSmall As New Font("CordiaUPC", 10, GraphicsUnit.Point)
    Dim prnFontBold As New Font("CordiaUPC", 14, FontStyle.Bold)
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
    'mReceNumb = "100-001886"
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select * from HistRece where receNumb = '" & mReceNumb & "'")
    If IsNothing(ds) = True Then
      MessageBox.Show("ไม่สามารถพิมพ์ใบรับสินค้าได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If

    Dim dv As New DataView(ds.Tables(0))
    If dv.Count = 0 Then
      MessageBox.Show("ไม่มีข้อมูลใบรับสินค้าได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If

    Dim mOrderNumb As String
    Dim mInvoiceNumb As String
    Dim mReceDate As Date
    Dim mInvoiceDate As Date

    With dv.Item(0)
      mOrderNumb = .Item("orderNumb").ToString
      mInvoiceNumb = .Item("invoiceNumb").ToString
      mReceDate = CDate(.Item("receDate"))
      mInvoiceDate = CDate(.Item("invoiceDate"))
    End With

    '' ชื่อบริษัท
    'mLineNo = mLineNo + 1
    'mRowPos = mLineNo * mLineSpace
    'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    'mAlign.Alignment = StringAlignment.Center
    'mText = pCompName
    'e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
    ' ชื่อสาขา
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = pBranchName
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' หัวเอกสาร
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "ใบรับสินค้า Shipto"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' เลขที่ใบรับ
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "เลขที่ใบรับสินค้า " & mReceNumb
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' วันที่รับ
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = mReceDate '.ToString("dd/MM/yyyy")
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' เลขที่ใบส่งสินค้า
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "เลขที่ใบส่งสินค้า " & mInvoiceNumb
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' วันที่ใบส่งสินค้า
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = mInvoiceDate '.ToString("dd/MM/yyyy")
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' เลขที่ใบสั่งซื้อ
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "เลขที่ใบสั่งสินค้า " & mOrderNumb
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' --------
    mRect = New RectangleF(mLeftMargin, mRowPos + 15, 260.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    Dim mItemCount As Integer = 0
    Dim dsReceList As New DataSet
    dsReceList = pService.SelectData("Drug", "Select GI.goodName, RL.goodAmou, UI.unitDesc from ReceList RL inner join GoodInfo GI on GI.goodCode = RL.goodCode inner join UnitInfo UI on UI.unitCode = RL.unitCode where RL.receNumb = '" & mReceNumb & "' order by GI.goodName")
    If IsNothing(dsReceList) = False Then
      Dim dvReceList As New DataView(dsReceList.Tables(0))
      For i As Integer = 0 To dvReceList.Count - 1
        With dvReceList.Item(i)
          ' ชื่อสินค้า
          mLineNo = mLineNo + 1
          mRowPos = mLineNo * mLineSpace
          mRect = New RectangleF(mLeftMargin, mRowPos, 150.0F, 20.0F)
          mAlign.Alignment = StringAlignment.Near
          mText = .Item("goodName").ToString
          e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
          ' จำนวน
          mRect = New RectangleF(mLeftMargin + 150, mRowPos, 50.0F, 20.0F)
          mAlign.Alignment = StringAlignment.Far
          mText = .Item("goodAmou").ToString
          e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
          ' หน่วย
          mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
          mAlign.Alignment = StringAlignment.Far
          mText = .Item("unitDesc").ToString
          e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
        End With
        mItemCount += 1
      Next
    End If
    dsReceList = Nothing
    ' --------
    mRowPos = mRowPos + 15
    mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' รวม...รายการ
    mRowPos = mRowPos + 15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "รวม " & mItemCount.ToString & " รายการ"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' ผู้รับ
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = "ผู้รับเข้า " & Mid(pUserName, 1, pUserName.LastIndexOf(" ")) ' แสดงเฉพาะชื่อ
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' print date
    mRowPos = mRowPos + 15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = Now.ToString("dd'/'MM'/'yyyy HH:mm")
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    pdc1.Print()
  End Sub
End Class