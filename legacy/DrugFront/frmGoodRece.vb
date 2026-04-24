Public Class frmGoodRece

  Dim mStockUnitCostField As String = "unitCost" & pBranchCode
  Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
  Dim mOrderNumb As String

  Private Sub frmGoodRece_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    For Each mCol As DataGridViewColumn In dtgList.Columns
      mCol.SortMode = DataGridViewColumnSortMode.NotSortable
    Next

    CheckPriv()
  End Sub

  Private Sub CheckPriv()
    ' Add
    If InStr(pUserPriv, Me.Tag.ToString & "A") > 0 Then
      tbnSave.Enabled = True
      dtgList.Columns("receAmou").ReadOnly = False
    Else
      tbnSave.Enabled = False
      dtgList.Columns("receAmou").ReadOnly = True
    End If
  End Sub

  Private Sub ShowInvoice(ByVal InvoNumb As String)
    Me.Cursor = Cursors.WaitCursor
    Dim dsInvoice As New DataSet
    Dim mSqlText As String

    mSqlText = "SELECT IL.goodCode, GI.goodName, GI." & mStockUnitCostField & ", GI." & mStockOnhandField & ", IL.orderAmou, IL.goodAmou, IL.unitCode, UI.unitDesc, IL.unitCost, HI.invoStat, GI.noBranchStock, HI.receNumb, HI.orderNumb, IR.goodAmou as preReceAmou FROM HistInvoice HI INNER JOIN InvoiceList IL ON HI.invoNumb = IL.invoNumb INNER JOIN GoodInfo GI ON IL.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON IL.unitCode = UI.unitCode left join InvoicePreRece IR on IR.invoNumb = IL.invoNumb and IR.goodCode = IL.goodCode WHERE HI.invoNumb = '" & InvoNumb & "' AND HI.branchCode = '" & pBranchCode & "' ORDER BY GI.goodName"

    dsInvoice = pService.SelectData("Drug", mSqlText)
    If IsNothing(dsInvoice) = False Then
      Dim dvInvoice As New DataView(dsInvoice.Tables(0))
      If dvInvoice.Count > 0 Then
        If dvInvoice.Item(0).Item("invoStat").ToString = "0" Then
          MessageBox.Show("ใบส่งสินค้าถูกยกเลิก ไม่สามารถรับสินค้าเข้าได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
          txtInvoNumb.Text = ""
          dtgList.Rows.Clear()
          txtInvoNumb.Focus()
          Me.Cursor = Cursors.Default
          Exit Sub
        End If

        If dvInvoice.Item(0).Item("receNumb").ToString <> "" Then
          MessageBox.Show("ใบส่งสินค้านี้ ได้ทำการรับเข้าสินค้าเรียบร้อยแล้ว", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
          txtInvoNumb.Text = ""
          dtgList.Rows.Clear()
          txtInvoNumb.Focus()
          Me.Cursor = Cursors.Default
          Exit Sub
        End If

        mOrderNumb = dvInvoice.Item(0).Item("orderNumb").ToString

        'If dvInvoice.Item(0).Item("invoStat").ToString = "2" OrElse dvInvoice.Item(0).Item("invoStat").ToString = "5" Then
        '  MessageBox.Show("ใบส่งสินค้านี้ ได้ทำการรับเข้าสินค้าเรียบร้อยแล้ว", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '  txtInvoNumb.Text = ""
        '  dtgList.Rows.Clear()
        '  txtInvoNumb.Focus()
        '  Exit Sub
        'End If

        dtgList.Rows.Clear()
        For i As Integer = 0 To dvInvoice.Count - 1
          With dvInvoice.Item(i)
            dtgList.Rows.Add()
            dtgList.Item("item", i).Value = i + 1
            dtgList.Item("goodCode", i).Value = .Item("goodCode")
            dtgList.Item("goodName", i).Value = .Item("goodName")
            dtgList.Item("orderAmou", i).Value = .Item("orderAmou")
            dtgList.Item("goodAmou", i).Value = .Item("goodAmou")
            dtgList.Item("ReceAmou", i).Value = .Item("goodAmou")
            dtgList.Item("unitCode", i).Value = .Item("unitCode")
            dtgList.Item("unitDesc", i).Value = .Item("unitDesc")
            dtgList.Item("unitCost", i).Value = .Item("unitCost")
            dtgList.Item("stockOnhand", i).Value = .Item(mStockOnhandField)
            dtgList.Item("stockUnitCost", i).Value = .Item(mStockUnitCostField)
            dtgList.Item("overAmou", i).Value = ""
            If CInt(.Item("goodAmou")) = 0 Then ' จำนวนเป็น 0 ให้แสดงสี
              dtgList.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
              dtgList.Item("receAmou", i).ReadOnly = True
            End If
            dtgList.Item("noBranchStock", i).Value = .Item("noBranchStock")
            ' รายการที่รับก่อน
            If IsDBNull(.Item("preReceAmou")) = False AndAlso .Item("preReceAmou") > 0 Then
              dtgList.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(249, 213, 249)
              dtgList.Item("receStat", i).Value = "รับด่วน"
              dtgList.Item("receAmou", i).Value = .Item("preReceAmou")
              dtgList.Item("preReceAmou", i).Value = .Item("preReceAmou")
              dtgList.Item("receAmou", i).ReadOnly = True
            Else
              dtgList.Item("preReceAmou", i).Value = 0
            End If
          End With
        Next
        dtgList.ClearSelection()
        CheckReceOver()
      Else
        MessageBox.Show("ไม่พบข้อมูลใบส่งสินค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        dtgList.Rows.Clear()
        txtInvoNumb.Enabled = True
        txtInvoNumb.Text = ""
        txtInvoNumb.Focus()
      End If
      dvInvoice = Nothing
    Else
      MessageBox.Show("Error on select data", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End If
    dsInvoice = Nothing
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub txtInvoNumb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInvoNumb.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub txtInvoNumb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInvoNumb.LostFocus
    If txtInvoNumb.Text <> "" Then
      txtInvoNumb.Enabled = False
      ShowInvoice(txtInvoNumb.Text)
    End If
  End Sub

  Private Sub tbnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnSave.Click
    If txtInvoNumb.Text <> "" AndAlso dtgList.Rows.Count > 0 Then
      If MessageBox.Show("ยืนยันรับสินค้า", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

        CheckStockOnhand(txtInvoNumb.Text, mStockOnhandField)

        ' ตรวจสอบว่าใบส่งสินค้าได้ถูกรับเข้าหรือยัง ป้องกันการรับเข้าซ้ำ (กรณีรับครั้งแรกแล้วเกิดแฮงค์)
        Dim mGet() As String
        mGet = pService.GetData("Drug", "Select invoStat from HistInvoice where invoNumb = '" & txtInvoNumb.Text & "'")
        If mGet(0) = "1" And mGet(1) = "2" Then
          MessageBox.Show("ใบส่งสินค้านี้ ได้ทำการรับเข้าสินค้าเรียบร้อยแล้ว", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
          Exit Sub
        End If

        ' disable ปุ่มบันทึก ป้องกันการคลิ๊กซ้ำ
        tbnSave.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        Dim mReceNumb As String
        Dim getValue() As String
        getValue = pService.GetData("Drug", "SELECT receNumb FROM BranchInfo WHERE branchCode = '" & pBranchCode & "'")
        If getValue(0) = "1" Then
          mReceNumb = pBranchCode & "-" & Mid((1000000 + CInt(getValue(1))).ToString, 2)
        Else
          MessageBox.Show(getValue(1), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
          Me.Cursor = Cursors.Default
          tbnSave.Enabled = True
          Exit Sub
        End If
        ' ใช้วันที่และเวลาของ server
        pServerDateTime = pService.ServerDateTime

        Dim mSqlText((dtgList.Rows.Count * 5) + 7) As String
        Dim mLine As Integer = 0

        mSqlText(mLine) = "INSERT INTO HistRece (receNumb, receDate, receTime, branchCode, emplCode, receRema, invoiceNumb) VALUES ('" & mReceNumb & "', '" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', '" & pBranchCode & "', '" & pUserCode & "', '" & Replace(txtRemark.Text, "'", "''") & "', '" & txtInvoNumb.Text & "')"
        mLine += 1

        mSqlText(mLine) = "UPDATE HistInvoice SET receDate = '" & MDYStr(pServerDateTime.Date) & "', receTime = '" & Format(pServerDateTime, "HH:mm") & "', receEmplCode = '" & pUserCode & "', receNumb = '" & mReceNumb & "', invoStat = '2' WHERE invoNumb = '" & txtInvoNumb.Text & "'"
        mLine += 1

        mSqlText(mLine) = "UPDATE HistOrder set orderStat = '9', invoNumb = '" & txtInvoNumb.Text & "' WHERE OrderNumb = '" & mOrderNumb & "'"
        mLine += 1

        Dim mAvgCost As Single
        Dim mOrderAmou As Integer
        Dim mSendAmou As Integer
        Dim mReceAmou As Integer
        Dim mPreReceAmou As Integer
        Dim mStockOnhand As Integer
        Dim mStockUnitCost As Single
        Dim mUnitCode As String
        Dim mUnitCost As Single
        Dim mGoodCode As String
        For i As Integer = 0 To dtgList.Rows.Count - 1
          mOrderAmou = CInt(dtgList.Item("orderAmou", i).Value)
          mSendAmou = CInt(dtgList.Item("GoodAmou", i).Value)
          mReceAmou = CInt(dtgList.Item("receAmou", i).Value)
          mPreReceAmou = CInt(dtgList.Item("preReceAmou", i).Value)
          mStockOnhand = CInt(dtgList.Item("StockOnhand", i).Value)
          mStockUnitCost = CSng(dtgList.Item("StockUnitCost", i).Value)
          mUnitCode = dtgList.Item("unitCode", i).Value
          mUnitCost = CSng(dtgList.Item("UnitCost", i).Value)
          mGoodCode = dtgList.Item("goodCode", i).Value.ToString

          mSqlText(mLine) = "INSERT INTO ReceList (receNumb, goodCode, goodAmou, unitCode, unitCost) VALUES ('" & mReceNumb & "', '" & mGoodCode & "', " & mSendAmou & ", '" & dtgList.Item("unitCode", i).Value.ToString & "', " & mUnitCost & ")"
          mLine += 1
          ' บันทึกว่ารับจริงเท่าไหร่
          mSqlText(mLine) = "UPDATE InvoiceList SET receAmou = " & mReceAmou & " WHERE invoNumb = '" & txtInvoNumb.Text & "' AND goodCode = '" & mGoodCode & "'"
          mLine += 1
          ' เก็บข้อมูลและตัดสต๊อค (ยกเว้นรายการที่รับด่วนไปแล้ว)
          If mPreReceAmou = 0 Then
            ' Front card
            mSqlText(mLine) = "Insert into FrontCard (stockDate, stockTime, workType, branchCode, docNumb, emplName, goodCode, goodAmou, stockOnhand) Values ('" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', 'REC', '" & pBranchCode & "', '" & txtInvoNumb.Text & "', '" & Mid(pUserName, 1, 10) & "', '" & dtgList.Item("goodCode", i).Value.ToString & "', " & mSendAmou & ", " & (mStockOnhand + mSendAmou) & ")"
            mLine += 1

            If mSendAmou > 0 And dtgList.Item("noBranchStock", i).Value.ToString = "0" Then ' ไม่เก็บสตีอค หากมีการระบุ
              ' ราคาทุนเฉลี่ยใหม่ คำนวนจาก (มูลค่าจน.ที่เหลือ + มูลค่าจน.ที่รับ) / จำนวนทั้งหมด
              If mStockOnhand <= 0 Then ' ถ้าสต๊อคเดิมเป็นศูนย์หรือติดลบ ให้ใช้ทุนเฉลี่ยใหม่
                mAvgCost = mUnitCost
              Else
                mAvgCost = ((mStockOnhand * mStockUnitCost) + (mSendAmou * mUnitCost)) / (mStockOnhand + mSendAmou)
              End If

              mSqlText(mLine) = "UPDATE GoodInfo SET " & mStockOnhandField & " = " & mStockOnhandField & " + " & mSendAmou & ", " & mStockUnitCostField & " = " & mAvgCost & " WHERE goodCode = '" & mGoodCode & "'"
              mLine += 1
            End If
          End If
        Next
        ' ลบข้อมูลรับด่วน (ถ้ามี)
        mSqlText(mLine) = "Delete from InvoicePreRece where invoNumb = '" & txtInvoNumb.Text & "'"
        mLine += 1

        mSqlText(mLine) = "UPDATE BranchInfo set receNumb = receNumb + 1 WHERE branchCode = '" & pBranchCode & "'"
        mLine += 1

        Application.DoEvents()

        Dim retValue As String
        retValue = pService.UpdateData("Drug", mSqlText)
        If retValue = "1" Then
          MessageBox.Show("บันทึกรับสินค้าเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
          ClearField()
          txtInvoNumb.Focus()
        Else
          MessageBox.Show(retValue, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        tbnSave.Enabled = True
        Me.Cursor = Cursors.Default
      End If
    End If
  End Sub

  Private Sub dtgList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgList.CellDoubleClick
    If tbnSave.Enabled = True AndAlso (e.RowIndex >= 0 And dtgList.Item("preReceAmou", e.RowIndex).Value = 0) Then
      frmInvoicePreRece.pInvoNumb = txtInvoNumb.Text
      frmInvoicePreRece.pGoodCode = dtgList.Item("goodCode", e.RowIndex).Value
      frmInvoicePreRece.pGoodName = dtgList.Item("goodName", e.RowIndex).Value
      frmInvoicePreRece.pUnitDesc = dtgList.Item("unitDesc", e.RowIndex).Value
      frmInvoicePreRece.pUnitCost = dtgList.Item("unitCost", e.RowIndex).Value
      'frmInvoicePreRece.pStockOnhand = dtgList.Item("stockOnhand", e.RowIndex).Value
      frmInvoicePreRece.pStockUnitCost = dtgList.Item("stockUnitCost", e.RowIndex).Value
      frmInvoicePreRece.pNoBranchStock = dtgList.Item("noBranchStock", e.RowIndex).Value
      frmInvoicePreRece.pSendAmou = dtgList.Item("goodAmou", e.RowIndex).Value

      frmInvoicePreRece.ShowDialog()
      If frmInvoicePreRece.pOk = True Then
        dtgList.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(249, 213, 249)
        dtgList.Item("receStat", e.RowIndex).Value = "รับด่วน"
        dtgList.Item("receAmou", e.RowIndex).Value = frmInvoicePreRece.pReceAmou
        dtgList.Item("preReceAmou", e.RowIndex).Value = frmInvoicePreRece.pReceAmou
        dtgList.Item("receAmou", e.RowIndex).ReadOnly = True
        CheckReceOver()
      End If
      frmInvoicePreRece = Nothing
    End If
  End Sub

  Private Sub dtgList_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgList.CellEndEdit
    If dtgList.Columns(e.ColumnIndex).Name = "ReceAmou" Then
      Dim mSendAmou, mReceAmou, mOverAmou As Integer
      mSendAmou = CInt(Val(dtgList.Item("GoodAmou", e.RowIndex).Value))
      mReceAmou = CInt(Val(dtgList.Item("ReceAmou", e.RowIndex).Value))
      mOverAmou = mReceAmou - mSendAmou

      dtgList.Item("receAmou", e.RowIndex).Value = mReceAmou
      ' ส่งไม่ครบ
      If mOverAmou <> 0 Then
        dtgList.Item("overAmou", e.RowIndex).Value = mOverAmou
        If mOverAmou < 0 Then ' ส่งขาด
          dtgList.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
          dtgList.Item("receStat", e.RowIndex).Value = "รับขาด"
        Else ' ส่งเกิน
          dtgList.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Blue
          dtgList.Item("receStat", e.RowIndex).Value = "รับเกิน"
        End If
      Else
        dtgList.Item("overAmou", e.RowIndex).Value = ""
        dtgList.Item("receStat", e.RowIndex).Value = ""
        dtgList.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
      End If
      'If mReceAmou < 0 Then
      '  mReceAmou = 0
      'End If
      'dtgList.Item("ReceAmou", e.RowIndex).Value = mReceAmou
      'If mReceAmou <= 0 Then
      '  dtgList.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Tomato
      'Else
      '  If mReceAmou <> mSendAmou Then
      '    dtgList.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.GreenYellow
      '  Else
      '    dtgList.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
      '  End If
      'End If
    End If
  End Sub

  Private Sub tbnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnClear.Click
    If dtgList.Rows.Count > 0 Then
      If MessageBox.Show("ยืนยันเคลียร์หน้าจอ", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
        Exit Sub
      End If
    End If

    ClearField()
    txtInvoNumb.Focus()
  End Sub

  Private Sub ClearField()
    txtInvoNumb.Text = ""
    txtRemark.Text = ""
    dtgList.Rows.Clear()
    txtInvoNumb.Enabled = True
  End Sub

  Private Sub CheckReceOver()
    For Each mRow As DataGridViewRow In dtgList.Rows
      Dim mSendAmou, mReceAmou, mOverAmou As Integer
      mSendAmou = CInt(Val(dtgList.Item("GoodAmou", mRow.Index).Value))
      mReceAmou = CInt(Val(dtgList.Item("ReceAmou", mRow.Index).Value))
      mOverAmou = mReceAmou - mSendAmou

      dtgList.Item("receAmou", mRow.Index).Value = mReceAmou
      ' ส่งไม่ครบ
      If mOverAmou <> 0 Then
        dtgList.Item("overAmou", mRow.Index).Value = mOverAmou
        If mOverAmou < 0 Then ' ส่งขาด
          dtgList.Rows(mRow.Index).DefaultCellStyle.ForeColor = Color.Red
          dtgList.Item("receStat", mRow.Index).Value = "รับขาด" ' & dtgList.Item("receStat", mRow.Index).Value
        Else ' ส่งเกิน
          dtgList.Rows(mRow.Index).DefaultCellStyle.ForeColor = Color.Blue
          dtgList.Item("receStat", mRow.Index).Value = "รับเกิน" ' & dtgList.Item("receStat", mRow.Index).Value
        End If
      Else
        dtgList.Item("overAmou", mRow.Index).Value = ""
        dtgList.Rows(mRow.Index).DefaultCellStyle.ForeColor = Color.Black
        dtgList.Item("receStat", mRow.Index).Value = ""
      End If
    Next
  End Sub

  Private Sub CheckStockOnhand(ByVal InvoNumb As String, ByVal StockOnhandField As String)
    Dim mSqlText As String
    mSqlText = "Select GI.goodCode, GI." & StockOnhandField & " from InvoiceList IL inner join GoodInfo GI on GI.goodCode = IL.goodCode Where iL.invoNumb = '" & InvoNumb & "'"
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        For Each mRow As DataGridViewRow In dtgList.Rows
          If dtgList.Item("goodCode", mRow.Index).Value = dv.Item(i).Item("goodCode") Then
            dtgList.Item("stockOnhand", mRow.Index).Value = dv.Item(i).Item(StockOnhandField)
            Exit For
          End If
        Next
      Next
      dv = Nothing
    End If
    ds = Nothing
  End Sub
End Class