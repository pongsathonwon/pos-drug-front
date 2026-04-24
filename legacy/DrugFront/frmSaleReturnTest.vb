Public Class frmSaleReturnTest

  Public pSaleNumb As String

  Dim mItemReturn As Double
  Dim mTotal As Double
  Dim mPayType As String
  Dim mCardCode As String
  Dim mCloseNumb As String

  Private Sub frmSaleReturn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    'Call ClearAll()
    ' เลขที่ใบคืน ประกอบด้วย เลขที่สาขา+1(ขาย)หรือ0(คืน)+ปีเดือนวัน+ลำดับที่
    ' หากวันที่ปัจจุบันเปลี่ยนเป็นวันที่ใหม่ ให้เริ่มเลข 1
    Dim mDate As Date
    Dim dsBranch As New DataSet
    dsBranch = pService.SelectData("Drug", "SELECT saleDate FROM BranchInfo WHERE branchCode = '" & pBranchCode & "'")
    If IsNothing(dsBranch) = False Then
      Dim dvBranch As New DataView(dsBranch.Tables(0))
      If dvBranch.Count > 0 Then
        mDate = CDate(dvBranch.Item(0).Item("saleDate"))
        ' ใช้วันที่และเวลาของ server
        pServerDateTime = pService.ServerDateTime
        If mDate < pServerDateTime.Date Then

          Dim mSqlText(1) As String
          mSqlText(0) = "UPDATE BranchInfo SET returnNumb = 1, saleDate = '" & MDYStr(pServerDateTime.Date) & "' WHERE branchCode = '" & pBranchCode & "'"
          Dim mRet As String
          mRet = pService.UpdateData("Drug", mSqlText)
          If mRet = "1" Then
            pPreReturnNumb = pBranchCode & Format(pServerDateTime.Date, "yyMMdd")
          Else
            MessageBox.Show(mRet, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
          End If
        Else
          pPreReturnNumb = pBranchCode & Format(mDate, "yyMMdd")
        End If
      Else
        MessageBox.Show("Error in create return number", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End
      End If
      dvBranch = Nothing
    Else
      MessageBox.Show("Error in create return number", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End
    End If
    dsBranch = Nothing

    CheckPriv()

    If pSaleNumb <> "" Then
      txtSaleNumb.Text = pSaleNumb
      ShowSaleList(pSaleNumb)
    End If
  End Sub

  Private Sub frmSaleReturn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.F8
        tbnSave.PerformClick()
      Case Keys.Escape
        Me.Close()
      Case Keys.D ' focus ช่องจำนวนคืน
        If Control.ModifierKeys = Keys.Control AndAlso dtgSaleList.Rows.Count > 0 Then
          dtgSaleList.Rows(dtgSaleList.Rows.Count - 1).Cells("ReturnAmou").Selected = True
          dtgSaleList.SelectionMode = DataGridViewSelectionMode.CellSelect
          dtgSaleList.Columns("ReturnAmou").ReadOnly = False
          dtgSaleList.Focus()
        End If
    End Select
  End Sub

  Private Sub ShowSaleList1(ByVal SaleNumb As String)
    Me.Cursor = Cursors.WaitCursor

    Dim getValue() As String
    getValue = pService.GetData("Drug", "SELECT HS.saleDate, HS.saleTime, CI.custName, HS.payType, EI.emplName, EI2.emplName as cashName, HS.custType FROM HistSale HS INNER JOIN CustInfo CI ON HS.custCode = CI.custCode INNER JOIN EmplInfo EI ON HS.emplCode = EI.emplCode INNER JOIN EmplInfo EI2 ON HS.cashCode = EI2.emplCode WHERE HS.saleNumb = '" & SaleNumb & "' AND HS.branchCode = '" & pBranchCode & "' AND HS.saleStat <> '0'")
    If getValue(0) = "1" Then
      lblSaleDate.Text = getValue(1) & " " & getValue(2)
      lblCustName.Text = getValue(3)
      mPayType = getValue(4)
      'If mPayType = "C" Then
      '  lblPayType.Text = "เงินสด"
      'Else
      '  lblPayType.Text = "เครดิต"
      'End If
      lblEmplName.Text = getValue(5)
      lblCashName.Text = getValue(6)
    Else
      MessageBox.Show("ไม่มีข้อมูลการขายสินค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      'txtSaleNumb.Text = ""
      'txtSaleNumb.Focus()
      Exit Sub
    End If

    Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
    Dim dsSaleList As New DataSet
    'dsSaleList = pService.SelectData("Drug", "SELECT * FROM vSaleList WHERE saleNumb = '" & txtSaleNumb.Text & "'")
    dsSaleList = pService.SelectData("Drug", "SELECT SL.*, GI.goodName, GI." & mStockOnhandField & ", UI.unitDesc, UI.unitFactor FROM SaleList SL INNER JOIN GoodInfo GI ON SL.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON SL.unitCode = UI.unitCode WHERE SL.saleNumb = '" & SaleNumb & "' order by GI.goodName")
    If IsNothing(dsSaleList) = False Then
      dtgSaleList.Rows.Clear()
      Dim dvSaleList As New DataView(dsSaleList.Tables(0))
      Dim mUnitPrice As Double
      If dvSaleList.Count > 0 Then
        For i As Integer = 0 To dvSaleList.Count - 1
          dtgSaleList.Rows.Add()
          With dvSaleList.Item(i)
            ' คำนวณราคาต่อหน่วยใหม่ หากมีส่วนลด ((จำนวนขาย x ราคาต่อหน่วย) - ส่วนลด) / จำนวนขาย
            mUnitPrice = ((CInt(.Item("goodAmou")) * CDbl(.Item("unitPrice"))) - CDbl(.Item("subDisc"))) / CInt(.Item("goodAmou"))
            dtgSaleList.Item("goodCode", dtgSaleList.Rows.Count - 1).Value = .Item("goodCode")
            dtgSaleList.Item("goodAmou", dtgSaleList.Rows.Count - 1).Value = .Item("goodAmou")
            dtgSaleList.Item("unitDesc", dtgSaleList.Rows.Count - 1).Value = .Item("unitDesc")
            dtgSaleList.Item("goodName", dtgSaleList.Rows.Count - 1).Value = .Item("goodName")
            dtgSaleList.Item("unitPrice", dtgSaleList.Rows.Count - 1).Value = mUnitPrice '.Item("unitPrice")
            dtgSaleList.Item("returned", dtgSaleList.Rows.Count - 1).Value = ""
            dtgSaleList.Item("returnAmou", dtgSaleList.Rows.Count - 1).Value = ""
            dtgSaleList.Item("subTotal", dtgSaleList.Rows.Count - 1).Value = ""
            dtgSaleList.Item("unitCode", dtgSaleList.Rows.Count - 1).Value = .Item("unitCode")
            dtgSaleList.Item("unitCost", dtgSaleList.Rows.Count - 1).Value = .Item("unitCost")
            dtgSaleList.Item("unitFactor", dtgSaleList.Rows.Count - 1).Value = .Item("unitFactor")
            dtgSaleList.Item("stockOnhand", dtgSaleList.Rows.Count - 1).Value = .Item(mStockOnhandField)
          End With
        Next
      End If
      dvSaleList = Nothing
    End If
    dsSaleList = Nothing

    ' รายการที่คืนแล้วสำหรับใบขายนี้
    Dim dsHistRetu As New DataSet
    dsHistRetu = pService.SelectData("Drug", "SELECT RL.goodCode, RL.goodAmou FROM ReturnList RL INNER JOIN HistReturn HR ON RL.returnNumb = HR.returnNumb WHERE HR.saleNumb = '" & SaleNumb & "'")
    If IsNothing(dsHistRetu) = False Then
      Dim dvHistRetu As New DataView(dsHistRetu.Tables(0))
      Dim mGoodCode As String
      Dim mGoodAmou As Integer
      For i As Integer = 0 To dvHistRetu.Count - 1
        mGoodCode = dvHistRetu.Item(i).Item("goodCode").ToString
        mGoodAmou = CInt(dvHistRetu.Item(i).Item("goodAmou"))
        For x As Integer = 0 To dtgSaleList.Rows.Count - 1
          If dtgSaleList.Item("goodCode", x).Value.ToString = mGoodCode AndAlso CInt(Val(dtgSaleList.Item("returned", x).Value)) < CInt(dtgSaleList.Item("goodAmou", x).Value) Then
            dtgSaleList.Item("returned", x).Value = CInt(Val(dtgSaleList.Item("returned", x).Value)) + mGoodAmou
            Exit For
          End If
        Next
      Next
      dvHistRetu = Nothing
    End If
    dsHistRetu = Nothing

    txtSaleNumb.Enabled = False

    dtgSaleList.ClearSelection()
    dtgSaleList.Rows(0).Cells("ReturnAmou").Selected = True
    dtgSaleList.SelectionMode = DataGridViewSelectionMode.CellSelect
    dtgSaleList.Focus()

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub ShowSaleList(ByVal SaleNumb As String)
    Me.Cursor = Cursors.WaitCursor

    Dim mSqltext As String
    Dim ds As New DataSet
    Dim dv As DataView

    mSqltext = "SELECT HS.saleDate, HS.closeNumb, CI.custName, EI.emplName, EI2.emplName as cashName, PL.cardCode, CD.cardName FROM HistSale HS INNER JOIN CustInfo CI ON HS.custCode = CI.custCode INNER JOIN EmplInfo EI ON HS.emplCode = EI.emplCode INNER JOIN EmplInfo EI2 ON HS.cashCode = EI2.emplCode inner join SalePaidList PL on PL.saleNumb = HS.saleNumb inner join CardInfo CD on CD.cardCode = PL.cardCode WHERE HS.saleNumb = '" & SaleNumb & "' AND HS.branchCode = '" & pBranchCode & "' AND HS.saleStat <> '0'"

    ds = pService.SelectData("Drug", mSqltext)
    If IsNothing(ds) = False Then
      dv = New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        With dv.Item(0)
          lblSaleDate.Text = .Item("saleDate")
          lblCustName.Text = .Item("custName")
          lblEmplName.Text = .Item("emplName")
          lblCashName.Text = .Item("cashName")
          mCardCode = .Item("cardCode")
          mCloseNumb = .Item("closeNumb")
        End With
      Else
        MessageBox.Show("ไม่พบข้อมูลการขาย", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Exit Sub
      End If
      dv = Nothing
    End If
    ds = Nothing

    Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
    ds = pService.SelectData("Drug", "SELECT SL.*, GI.goodName, GI." & mStockOnhandField & ", UI.unitDesc, UI.unitFactor FROM SaleList SL INNER JOIN GoodInfo GI ON SL.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON SL.unitCode = UI.unitCode WHERE SL.saleNumb = '" & SaleNumb & "' order by GI.goodName")
    If IsNothing(ds) = False Then
      dtgSaleList.Rows.Clear()
      dv = New DataView(ds.Tables(0))
      Dim mUnitPrice As Double
      If dv.Count > 0 Then
        For i As Integer = 0 To dv.Count - 1
          dtgSaleList.Rows.Add()
          With dv.Item(i)
            ' คำนวณราคาต่อหน่วยใหม่ หากมีส่วนลด ((จำนวนขาย x ราคาต่อหน่วย) - ส่วนลด) / จำนวนขาย
            mUnitPrice = ((CInt(.Item("goodAmou")) * CDbl(.Item("unitPrice"))) - CDbl(.Item("subDisc"))) / CInt(.Item("goodAmou"))
            dtgSaleList.Item("goodCode", dtgSaleList.Rows.Count - 1).Value = .Item("goodCode")
            dtgSaleList.Item("goodAmou", dtgSaleList.Rows.Count - 1).Value = .Item("goodAmou")
            dtgSaleList.Item("unitDesc", dtgSaleList.Rows.Count - 1).Value = .Item("unitDesc")
            dtgSaleList.Item("goodName", dtgSaleList.Rows.Count - 1).Value = .Item("goodName")
            dtgSaleList.Item("unitPrice", dtgSaleList.Rows.Count - 1).Value = mUnitPrice '.Item("unitPrice")
            dtgSaleList.Item("returned", dtgSaleList.Rows.Count - 1).Value = ""
            dtgSaleList.Item("returnAmou", dtgSaleList.Rows.Count - 1).Value = ""
            dtgSaleList.Item("subTotal", dtgSaleList.Rows.Count - 1).Value = ""
            dtgSaleList.Item("unitCode", dtgSaleList.Rows.Count - 1).Value = .Item("unitCode")
            dtgSaleList.Item("unitCost", dtgSaleList.Rows.Count - 1).Value = .Item("unitCost")
            dtgSaleList.Item("unitFactor", dtgSaleList.Rows.Count - 1).Value = .Item("unitFactor")
            dtgSaleList.Item("stockOnhand", dtgSaleList.Rows.Count - 1).Value = .Item(mStockOnhandField)
          End With
        Next
      End If
      dv = Nothing
    End If
    ds = Nothing

    ' รายการที่คืนแล้วสำหรับใบขายนี้
    ds = pService.SelectData("Drug", "SELECT RL.goodCode, RL.goodAmou FROM ReturnList RL INNER JOIN HistReturn HR ON RL.returnNumb = HR.returnNumb WHERE HR.saleNumb = '" & SaleNumb & "'")
    If IsNothing(ds) = False Then
      dv = New DataView(ds.Tables(0))
      Dim mGoodCode As String
      Dim mGoodAmou As Integer
      For i As Integer = 0 To dv.Count - 1
        mGoodCode = dv.Item(i).Item("goodCode").ToString
        mGoodAmou = CInt(dv.Item(i).Item("goodAmou"))
        For x As Integer = 0 To dtgSaleList.Rows.Count - 1
          If dtgSaleList.Item("goodCode", x).Value.ToString = mGoodCode AndAlso CInt(Val(dtgSaleList.Item("returned", x).Value)) < CInt(dtgSaleList.Item("goodAmou", x).Value) Then
            dtgSaleList.Item("returned", x).Value = CInt(Val(dtgSaleList.Item("returned", x).Value)) + mGoodAmou
            Exit For
          End If
        Next
      Next
      dv = Nothing
    End If
    ds = Nothing

    txtSaleNumb.Enabled = False

    dtgSaleList.ClearSelection()
    dtgSaleList.Rows(0).Cells("ReturnAmou").Selected = True
    dtgSaleList.SelectionMode = DataGridViewSelectionMode.CellSelect
    dtgSaleList.Focus()

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub textKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSaleNumb.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub txtSaleNumb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSaleNumb.LostFocus
    If txtSaleNumb.Text <> "" Then
      Call ShowSaleList(txtSaleNumb.Text)
    End If
  End Sub

  Private Sub dtgSaleList_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgSaleList.CellEndEdit
    Dim mGoodAmou As Integer
    Dim mAlreadyReturn As Integer
    Dim mNotReturn As Integer
    Dim mThisReturn As Integer

    mGoodAmou = CInt(Val(dtgSaleList.Item("goodAmou", e.RowIndex).Value))
    mAlreadyReturn = CInt(Val(dtgSaleList.Item("returned", e.RowIndex).Value))
    mThisReturn = CInt(Val(dtgSaleList.Item("returnAmou", e.RowIndex).Value))

    If mThisReturn > 0 Then
      mNotReturn = mGoodAmou - mAlreadyReturn
      If mThisReturn > mNotReturn Then
        MessageBox.Show("คืนเกินจำนวนซื้อ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        dtgSaleList.Item("returnAmou", e.RowIndex).Value = ""
        dtgSaleList.Item("subTotal", e.RowIndex).Value = ""
      Else
        dtgSaleList.Item("subTotal", e.RowIndex).Value = CInt(dtgSaleList.Item("returnAmou", e.RowIndex).Value * dtgSaleList.Item("unitPrice", e.RowIndex).Value)
      End If
    Else
      dtgSaleList.Item("returnAmou", e.RowIndex).Value = ""
      dtgSaleList.Item("subTotal", e.RowIndex).Value = ""
    End If

    CalTotal()



    'Dim mReturnAmou As Integer
    'If IsNothing(dtgSaleList.Item("returnAmou", e.RowIndex).Value) = False Then
    '  mReturnAmou = CInt(Val(dtgSaleList.Item("returnAmou", e.RowIndex).Value))
    'Else
    '  mReturnAmou = 0
    'End If

    ''If mReturnAmou <> 0 AndAlso mReturnAmou <= (CInt(dtgSaleList.Item("goodAmou", e.RowIndex).Value) - CInt(Val(dtgSaleList.Item("returned", e.RowIndex).Value))) Then
    ''  dtgSaleList.Item("subTotal", e.RowIndex).Value = CInt(dtgSaleList.Item("returnAmou", e.RowIndex).Value * dtgSaleList.Item("unitPrice", e.RowIndex).Value)
    ''Else
    ''  dtgSaleList.Item("returnAmou", e.RowIndex).Value = ""
    ''  dtgSaleList.Item("subTotal", e.RowIndex).Value = ""
    ''End If

    'If mReturnAmou > 0 Then
    '  If mReturnAmou <= (CInt(dtgSaleList.Item("goodAmou", e.RowIndex).Value) - CInt(Val(dtgSaleList.Item("returned", e.RowIndex).Value))) Then
    '    dtgSaleList.Item("subTotal", e.RowIndex).Value = CInt(dtgSaleList.Item("returnAmou", e.RowIndex).Value * dtgSaleList.Item("unitPrice", e.RowIndex).Value)
    '    Call CalTotal()
    '  Else
    '    MessageBox.Show("คืนครบตามจำนวนซื้อแล้ว", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    dtgSaleList.Item("returnAmou", e.RowIndex).Value = ""
    '    dtgSaleList.Item("subTotal", e.RowIndex).Value = ""
    '  End If
    'Else
    '  dtgSaleList.Item("returnAmou", e.RowIndex).Value = ""
    '  dtgSaleList.Item("subTotal", e.RowIndex).Value = ""

    'End If
  End Sub

  Private Sub CalTotal()
    mTotal = 0
    mItemReturn = 0
    For i As Integer = 0 To dtgSaleList.Rows.Count - 1
      mTotal += CSng(Val(dtgSaleList.Item("subTotal", i).Value))
      If Val(dtgSaleList.Item("returnAmou", i).Value) > 0 Then
        mItemReturn += 1
      End If
    Next
    lblTotal.Text = mTotal.ToString("#,##0.00")
  End Sub

  Private Sub ClearAll()
    dtgSaleList.Rows.Clear()
    txtSaleNumb.Enabled = True
    txtSaleNumb.Text = ""
    lblSaleDate.Text = ""
    lblCustName.Text = ""
    'lblPayType.Text = ""
    lblEmplName.Text = ""
    lblCashName.Text = ""
    lblTotal.Text = ""
    mItemReturn = 0
  End Sub

  Private Sub CheckPriv()
    ' Edit
    If InStr(pUserPriv, Me.Tag.ToString & "E") > 0 Then
      tbnSave.Enabled = True
      dtgSaleList.Columns("returnAmou").ReadOnly = False
    Else
      tbnSave.Enabled = False
      dtgSaleList.Columns("returnAmou").ReadOnly = True
    End If
  End Sub


  Private Sub tbnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnSave.Click
    If txtSaleNumb.Text <> "" AndAlso mItemReturn > 0 Then
      If MessageBox.Show("ยืนยันรับคืนสินค้า", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
        Exit Sub
      End If

      Dim mReturnRema As String
      mReturnRema = InputBox("สาเหตุการรับคืนสินค้า", Me.Text)
      If mReturnRema = "" Then
        Exit Sub
      End If

      Dim mStockOnhandField As String
      mStockOnhandField = "stockOnhand" & pBranchCode

      Dim mReturnNumb As String
      Dim getValue() As String
      getValue = pService.GetData("Drug", "SELECT returnNumb FROM BranchInfo WHERE branchCode = '" & pBranchCode & "'")
      If getValue(0) = "1" Then
        mReturnNumb = pPreReturnNumb & Mid((1000 + CInt(getValue(1))).ToString, 2)
      Else
        MessageBox.Show("ไม่สามารถกำหนดเลขที่ใบคืนได้" & "(" & getValue(1) & ")", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      End If

      ' ใช้วันที่และเวลาของ server
      pServerDateTime = pService.ServerDateTime

      Dim mReturnCardCode As String
      If mCloseNumb = "0" Then
        ' รับคืนใบขายที่ยังไม่ได้สรุปยอด ให้คืนตามประเภทการชำระ
        mReturnCardCode = mCardCode
      Else
        ' รับคืนใบขายที่สรุปยอดไปแล้ว ให้คืนเป็นเงินสด
        mReturnCardCode = "0" ' เงินสด
      End If

      Dim mSqlText(dtgSaleList.Rows.Count * 4 + 4) As String
      Dim mLine As Integer = 0
      mSqlText(mLine) = "INSERT INTO HistReturn (returnNumb, returnDate, returnTime" & ", branchCode, cashCode, totalPrice, saleNumb, returnRema, returnType, cardCode, returnStat, closeNumb)" & " values ('" & mReturnNumb & "', '" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', '" & pBranchCode & "', '" & pUserCode & "', " & mTotal & ", '" & txtSaleNumb.Text & "', '" & mReturnRema & "', '" & mPayType & "', '" & mReturnCardCode & "', '1', '0')"
      mLine += 1

      mSqlText(mLine) = "UPDATE HistSale SET saleStat = '3' WHERE saleNumb = '" & txtSaleNumb.Text & "'"
      mLine += 1

      ' ยกเลิกสิทธิ์แลกซื้อ ถ้ามีและยังไม่ได้ใช้
      mSqlText(mLine) = "Update BuyExchangeInfo set bxStat = '0' where issueSaleNumb = '" & txtSaleNumb.Text & "' and bxStat = '1'"
      mLine += 1

      Dim mGoodCode As String
      Dim mReturnAmou As Integer
      Dim mUnitCode As String
      Dim mUnitPrice As Double
      Dim mUnitCost As Double
      Dim mUnitFactor As Integer
      Dim mStockOnhand As Integer
      For i As Integer = 0 To dtgSaleList.Rows.Count - 1
        mGoodCode = dtgSaleList.Item("goodCode", i).Value
        mReturnAmou = CInt(Val(dtgSaleList.Item("returnAmou", i).Value))
        mUnitCode = dtgSaleList.Item("unitCode", i).Value
        mUnitPrice = dtgSaleList.Item("unitPrice", i).Value
        mUnitCost = dtgSaleList.Item("unitCost", i).Value
        mUnitFactor = dtgSaleList.Item("unitFactor", i).Value
        mStockOnhand = dtgSaleList.Item("stockOnhand", i).Value

        If IsNothing(dtgSaleList.Item("returnAmou", i).Value) = False AndAlso CInt(Val(dtgSaleList.Item("returnAmou", i).Value)) > 0 Then
          mSqlText(mLine) = "INSERT INTO ReturnList (returnNumb, goodCode, goodAmou, unitCode, unitPrice, unitCost) values ('" & mReturnNumb & "', '" & mGoodCode & "', " & mReturnAmou & ", '" & mUnitCode & "', " & mUnitPrice & ", " & (mUnitCost * mUnitFactor) & ")"
          mLine += 1

          ' รับคืนสต๊อค (คำนวณเป็นหน่วยย่อย)
          mSqlText(mLine) = "UPDATE GoodInfo set " & mStockOnhandField & " = " & mStockOnhandField & " + " & (mReturnAmou * mUnitFactor) & " WHERE goodCode = '" & mGoodCode & "'"
          mLine += 1

          ' Front card
          mSqlText(mLine) = "Insert into FrontCard (stockDate, stockTime, workType, branchCode, docNumb, emplName, goodCode, goodAmou, stockOnhand) Values ('" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', 'RSL', '" & pBranchCode & "', '" & mReturnNumb & "', '" & Mid(pUserName, 1, 10) & "', '" & mGoodCode & "', " & (mReturnAmou * mUnitFactor) & ", " & (mStockOnhand + (mReturnAmou * mUnitFactor)) & ")"
          mLine += 1
        End If
      Next

      mSqlText(mLine) = "UPDATE BranchInfo set returnNumb = returnNumb + 1 WHERE branchCode = '" & pBranchCode & "'"
      mLine += 1

      Dim retValue As String
      retValue = pService.UpdateData("Drug", mSqlText)
      If retValue = "1" Then
        MessageBox.Show("บันทึกรับคืนเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        'Call ClearAll()
        'txtSaleNumb.Focus()
      Else
        MessageBox.Show(retValue, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If

    End If
  End Sub

  Private Sub tbnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnClear.Click
    ClearAll()
    txtSaleNumb.Select()
  End Sub
End Class