Public Class frmSaleCheck

  Dim mCustCode As String
  Dim mCustTypeCode As String
  Dim mCustTypeDesc As String
  Dim mTaxName As String
  Dim mTaxAddr As String
  Dim mTaxID As String
  Dim mTaxInvoiceNumb As String

  Dim mPayType As String
  Dim mSaleStat As String
  Dim mTotalPrice, mTotalCashPay, mTotalCash, mTotalCredit, mTotalDebt, mTotalCupong, mTotalChange, mPointDisc As Double
  Dim mThisPoint, mUsePoint, mRemainPoint As Integer
  Dim mCustPoint As Integer

  Dim mSaleNumb As String

  Private Sub frmSaleCheck_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon
    ClearAll()
    CheckPriv()

    tbnPrintBillVatFull.Visible = False
    tbnPrintBillVatShort.Visible = False
    tbnPrintBill.Visible = False

    'If pAllowTaxInvoice = "1" Then
    '  tbnPrintBillVatFull.Visible = True
    '  tbnPrintBillVatShort.Visible = True
    '  tbnPrintBill.Visible = False
    'Else
    '  tbnPrintBillVatFull.Visible = False
    '  tbnPrintBillVatShort.Visible = False
    '  tbnPrintBill.Visible = True
    'End If

  End Sub

  Private Sub frmSaleCheck_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.F10
        tbnPrintBill.PerformClick()
      Case Keys.F12
        tbnRefresh.PerformClick()
    End Select
  End Sub

  Private Sub ShowHistSale()
    Me.Cursor = Cursors.WaitCursor

    Dim dsHistSale As New DataSet
    dsHistSale = pService.SelectData("Drug", "SELECT HS.*, CI.custName, CI.hugPoint, EI.emplName, EI2.emplName as cashName, HS.saleStat, HP.thisPoint, HP.usePoint, HP.remainPoint, CT.custTypeDesc FROM HistSale HS INNER JOIN CustInfo CI ON HS.custCode = CI.custCode inner join CustType CT on CT.custTypeCode = HS.custType left join EmplInfo EI ON HS.emplCode = EI.emplCode left join EmplInfo EI2 ON HS.cashCode = EI2.emplCode Left Outer join HistSalePro HP On HP.saleNumb = HS.saleNumb WHERE HS.saleDate = '" & MDYStr(dtpSale.Value) & "' and HS.branchCode = '" & pBranchCode & "' order by HS.saleNumb")

    If IsNothing(dsHistSale) = False Then
      dtgHistSale.Rows.Clear()
      dtgSaleList.Rows.Clear()
      Dim dvHistSale As New DataView(dsHistSale.Tables(0))
      If dvHistSale.Count > 0 Then
        Dim mAllTotal As Double = 0
        Dim mTotalPointDisc As Double = 0
        For i As Integer = 0 To dvHistSale.Count - 1
          With dvHistSale.Item(i)
            dtgHistSale.Rows.Add()
            dtgHistSale.Item("saleNumb", dtgHistSale.Rows.Count - 1).Value = .Item("saleNumb").ToString
            dtgHistSale.Item("saleTime", dtgHistSale.Rows.Count - 1).Value = .Item("saleTime").ToString
            dtgHistSale.Item("saleDate", dtgHistSale.Rows.Count - 1).Value = .Item("saleDate")
            dtgHistSale.Item("custCode", dtgHistSale.Rows.Count - 1).Value = .Item("custCode").ToString
            dtgHistSale.Item("custName", dtgHistSale.Rows.Count - 1).Value = .Item("custName").ToString
            dtgHistSale.Item("custPoint", dtgHistSale.Rows.Count - 1).Value = .Item("hugPoint")
            dtgHistSale.Item("custTypeCode", dtgHistSale.Rows.Count - 1).Value = .Item("custType").ToString
            dtgHistSale.Item("custTypeDesc", dtgHistSale.Rows.Count - 1).Value = .Item("custTypeDesc").ToString
            dtgHistSale.Item("payType", dtgHistSale.Rows.Count - 1).Value = .Item("payType").ToString
            dtgHistSale.Item("emplName", dtgHistSale.Rows.Count - 1).Value = RemoveNickName(.Item("emplName").ToString)
            dtgHistSale.Item("cashName", dtgHistSale.Rows.Count - 1).Value = RemoveNickName(.Item("cashName").ToString)
            dtgHistSale.Item("totalPrice", dtgHistSale.Rows.Count - 1).Value = .Item("totalPrice")
            dtgHistSale.Item("totalDisc", dtgHistSale.Rows.Count - 1).Value = .Item("totalDisc")
            dtgHistSale.Item("totalPay", dtgHistSale.Rows.Count - 1).Value = .Item("totalPay")
            dtgHistSale.Item("totalCash", dtgHistSale.Rows.Count - 1).Value = .Item("totalCash")
            dtgHistSale.Item("totalCredit", dtgHistSale.Rows.Count - 1).Value = .Item("totalCredit")
            dtgHistSale.Item("totalDebt", dtgHistSale.Rows.Count - 1).Value = .Item("totalDebt")
            dtgHistSale.Item("totalCupong", dtgHistSale.Rows.Count - 1).Value = .Item("totalCupong")
            dtgHistSale.Item("pointDisc", dtgHistSale.Rows.Count - 1).Value = .Item("pointDisc")
            dtgHistSale.Item("SaleSubTotal", dtgHistSale.Rows.Count - 1).Value = CDbl(.Item("totalPrice"))
            dtgHistSale.Item("saleRema", dtgHistSale.Rows.Count - 1).Value = .Item("saleRema")
            If .Item("saleStat").ToString <> "0" Then
              mTotalPointDisc += .Item("pointDisc")
              mAllTotal += .Item("totalPrice") ' CSng(.Item("totalCash")) + CSng(.Item("totalcredit")) + CSng(.Item("totalDebt")) + CSng(.Item("totalCupong"))
            End If

            dtgHistSale.Item("saleStat", dtgHistSale.Rows.Count - 1).Value = .Item("saleStat").ToString
            ' ใบที่ยกเลิกแล้วให้แสดงเป็นสีแดง และไม่นำมารวมเงิน
            If .Item("saleStat").ToString = "0" Then
              dtgHistSale.Rows(dtgHistSale.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkRed
            Else
              ' ใบที่มีการคืนสินค้าให้แสดงเป็นสีน้ำเงิน
              If .Item("saleStat").ToString = "3" Then
                dtgHistSale.Rows(dtgHistSale.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkBlue
              Else
                ' ใบที่สรุปบัญชีแล้วให้แสดงเป็นสีเขียว
                If .Item("saleStat").ToString = "2" Then
                  dtgHistSale.Rows(dtgHistSale.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkGreen
                End If
              End If
            End If

            ' แต้ม
            If IsDBNull(.Item("thisPoint")) = False Then
              dtgHistSale.Item("thisPoint", dtgHistSale.Rows.Count - 1).Value = .Item("thisPoint")
            Else
              dtgHistSale.Item("thisPoint", dtgHistSale.Rows.Count - 1).Value = 0
            End If

            If IsDBNull(.Item("usePoint")) = False Then
              dtgHistSale.Item("usePoint", dtgHistSale.Rows.Count - 1).Value = .Item("usePoint")
            Else
              dtgHistSale.Item("usePoint", dtgHistSale.Rows.Count - 1).Value = 0
            End If

            If IsDBNull(.Item("remainPoint")) = False Then
              dtgHistSale.Item("remainPoint", dtgHistSale.Rows.Count - 1).Value = .Item("remainPoint")
            Else
              dtgHistSale.Item("remainPoint", dtgHistSale.Rows.Count - 1).Value = 0
            End If
          End With
        Next
        lblTotalPointDisc.Text = mTotalPointDisc.ToString("#,##0.00")
        lblAllTotal.Text = mAllTotal.ToString("#,##0.00")
      End If
      dvHistSale = Nothing
      dtgHistSale.ClearSelection()
    End If
    dsHistSale = Nothing

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub ClearAll()
    dtgHistSale.Rows.Clear()
    dtgSaleList.Rows.Clear()
    dtgPaid.Rows.Clear()
    mCustCode = ""
    lblSaleNumb.Text = ""
    lblCustName.Text = ""
    lblSaleDate.Text = ""
    lblCustType.Text = ""
    lblPoint.Text = ""
    lblSaleRema.Text = ""
    lblBuyExchange.Text = ""
    lblEmplName.Text = ""
    lblCashName.Text = ""
    lblCancel.Text = ""

    lblAllTotal.Text = ""
    lblTotalPointDisc.Text = ""
  End Sub

  Private Sub ClearSaleList()
    dtgSaleList.Rows.Clear()
    dtgPaid.Rows.Clear()
    lblSaleNumb.Text = ""
    lblCustName.Text = ""
    lblSaleDate.Text = ""
    lblCustType.Text = ""
    lblPoint.Text = ""
    lblSaleRema.Text = ""
    lblBuyExchange.Text = ""
    lblEmplName.Text = ""
    lblCashName.Text = ""
    lblCancel.Text = ""
  End Sub

  Private Sub dtpSale_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpSale.ValueChanged
    ClearAll()
    'ShowHistSale()
  End Sub

  'Private Sub dtgHistSale_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgHistSale.CellClick
  '  If e.RowIndex < 0 Then
  '    Exit Sub
  '  End If

  '  ShowSaleList(dtgHistSale.Item("saleNumb", e.RowIndex).Value)
  'End Sub

  Private Sub ShowSaleList(ByVal SaleNumb As String)
    Me.Cursor = Cursors.WaitCursor

    ClearSaleList()

    Dim ds As New DataSet
    Dim mSqlText As String
    mSqlText = "SELECT HS.*, CI.custName, CI.hugPoint, EI.emplName, EI2.emplName as cashName, HS.saleStat, HP.thisPoint, HP.usePoint, HP.remainPoint, CT.custTypeDesc FROM HistSale HS INNER JOIN CustInfo CI ON HS.custCode = CI.custCode inner join CustType CT on CT.custTypeCode = HS.custType left join EmplInfo EI ON HS.emplCode = EI.emplCode left join EmplInfo EI2 ON HS.cashCode = EI2.emplCode Left Outer join HistSalePro HP On HP.saleNumb = HS.saleNumb WHERE HS.saleNumb = '" & SaleNumb & "'"

    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        With dv.Item(0)
          mSaleNumb = .Item("saleNumb")
          lblSaleNumb.Text = .Item("saleNumb")
          lblSaleDate.Text = .Item("saleDate")

          mSaleStat = .Item("saleStat")
          Select Case mSaleStat
            Case "0"
              lblCancel.Text = "ยกเลิก"
            Case "3"
              lblCancel.Text = "คืนสินค้าบางส่วน"
            Case "2"
              lblCancel.Text = "สรุปบัญชีแล้ว"
            Case Else
              lblCancel.Text = ""
          End Select

          ' ใบขายที่ยกเลิก ไม่สามารถพิมพ์ใบเสร็จได้
          If mSaleStat = "0" Then
            tbnPrintBillVatFull.Visible = False
            tbnPrintBillVatShort.Visible = False
            tbnPrintBill.Visible = False
          Else
            ' ใบขายระบบเดิม (ไม่มีอักษร P) จะไม่สามารถพิมพ์ใบกำกับภาษีได้
            If pAllowTaxInvoice = "1" And InStr(lblSaleNumb.Text, "P") > 0 Then
              tbnPrintBillVatFull.Visible = True
              tbnPrintBillVatShort.Visible = True
              tbnPrintBill.Visible = False
            Else
              tbnPrintBillVatFull.Visible = False
              tbnPrintBillVatShort.Visible = False
              tbnPrintBill.Visible = True
            End If
          End If

          lblCustName.Text = .Item("custName")
          lblCustType.Text = .Item("custTypeDesc")
          If IsDBNull(.Item("emplName")) = False Then
            lblEmplName.Text = .Item("emplName")
          Else
            lblEmplName.Text = ""
          End If
          'lblEmplName.Text = .Item("emplName")
          'lblCashName.Text = .Item("cashName")
          If IsDBNull(.Item("cashName")) = False Then
            lblCashName.Text = .Item("cashName")
          Else
            lblCashName.Text = ""
          End If
          If IsDBNull(.Item("saleRema")) = False Then
            lblSaleRema.Text = .Item("saleRema")
          Else
            lblSaleRema.Text = ""
          End If

          mCustCode = .Item("custCode")
          mCustTypeCode = .Item("custType")
          mCustPoint = .Item("hugPoint")
          mTotalPrice = .Item("totalPrice")
          mTotalCashPay = .Item("totalPay")
          mTotalCash = .Item("totalCash")
          mTotalChange = mTotalCashPay - mTotalCash
          mPointDisc = .Item("pointDisc")

          If IsDBNull(.Item("thisPoint")) = False Then
            mThisPoint = .Item("thisPoint")
          Else
            mThisPoint = 0
          End If

          If IsDBNull(.Item("usePoint")) = False Then
            mUsePoint = .Item("usePoint")
          Else
            mUsePoint = 0
          End If

          If IsDBNull(.Item("remainPoint")) = False Then
            mRemainPoint = .Item("remainPoint")
          Else
            mRemainPoint = 0
          End If

          lblPoint.Text = "แต้มที่ได้ " & mThisPoint.ToString & "  แต้มที่ใช้ " & mUsePoint.ToString
          lblBuyExchange.Text = CheckBuyExchange(lblSaleNumb.Text)
          ' *****************
          Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
          Dim dsSaleList As New DataSet
          dsSaleList = pService.SelectData("Drug", "SELECT SL.*, GI.goodName, GI." & mStockOnhandField & ", UI.unitDesc, UI.unitFactor FROM SaleList SL INNER JOIN GoodInfo GI ON SL.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON SL.unitCode = UI.unitCode WHERE SL.saleNumb = '" & lblSaleNumb.Text & "'")
          If IsNothing(dsSaleList) = False Then
            dtgSaleList.Rows.Clear()
            Dim dvSaleList As New DataView(dsSaleList.Tables(0))
            If dvSaleList.Count > 0 Then
              Dim mSubTotal As Double
              For i As Integer = 0 To dvSaleList.Count - 1
                dtgSaleList.Rows.Add()
                With dvSaleList.Item(i)
                  dtgSaleList.Item("GoodCode", dtgSaleList.Rows.Count - 1).Value = .Item("goodCode")
                  dtgSaleList.Item("barCode", dtgSaleList.Rows.Count - 1).Value = .Item("barCode")
                  dtgSaleList.Item("goodAmou", dtgSaleList.Rows.Count - 1).Value = .Item("goodAmou")
                  dtgSaleList.Item("unitDesc", dtgSaleList.Rows.Count - 1).Value = .Item("unitDesc")
                  dtgSaleList.Item("goodName", dtgSaleList.Rows.Count - 1).Value = .Item("goodName")
                  dtgSaleList.Item("unitPrice", dtgSaleList.Rows.Count - 1).Value = .Item("unitPrice")
                  dtgSaleList.Item("subDisc", dtgSaleList.Rows.Count - 1).Value = .Item("subDisc")
                  mSubTotal = CLng(CInt(.Item("goodAmou")) * CSng(.Item("unitPrice"))) ' ปัดเศษ
                  dtgSaleList.Item("subTotal", dtgSaleList.Rows.Count - 1).Value = mSubTotal - CSng(.Item("subDisc"))
                  dtgSaleList.Item("unitFactor", dtgSaleList.Rows.Count - 1).Value = .Item("unitFactor")
                  dtgSaleList.Item("stockOnhand", dtgSaleList.Rows.Count - 1).Value = .Item(mStockOnhandField)
                End With
              Next
            End If
            dvSaleList = Nothing
            dtgSaleList.ClearSelection()
          End If
          dsSaleList = Nothing
          ' *****************
          ShowSalePaid(lblSaleNumb.Text, mTotalCashPay)
        End With
      End If
      dv = Nothing
    End If
    ds = Nothing

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub ShowSalePaid(ByVal SaleNumb As String, ByVal CashPay As Double)
    dtgPaid.Rows.Clear()
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select distinct PL.cardCode, CD.cardName, CD.cardColor, PL.payAmou from SalePaidList PL inner join CardInfo CD on CD.cardCode = PL.cardCode where PL.saleNumb = '" & SaleNumb & "'")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        Dim mColorConv As New ColorConverter
        Dim mCashAmou As Double = 0
        dtgPaid.Rows.Add("ยอดเงินสุทธิ", mTotalPrice)
        If mPointDisc > 0 Then
          dtgPaid.Rows.Add("ส่วนลดจากแต้ม", mPointDisc)
        End If
        For i As Integer = 0 To dv.Count - 1
          With dv.Item(i)
            dtgPaid.Rows.Add()
            dtgPaid.Item("cardCode", dtgPaid.Rows.Count - 1).Value = .Item("cardCode")
            dtgPaid.Item("cardName", dtgPaid.Rows.Count - 1).Value = .Item("cardName")
            dtgPaid.Item("payAmou", dtgPaid.Rows.Count - 1).Value = .Item("payAmou")
            dtgPaid.Rows(dtgPaid.Rows.Count - 1).DefaultCellStyle.BackColor = mColorConv.ConvertFromString(.Item("cardColor"))
            If .Item("cardCode") = "0" Then
              mCashAmou += .Item("payAmou")
            End If
          End With
        Next
        dtgPaid.Rows.Add("ชำระเงินสด", CashPay)
        dtgPaid.Rows.Add("เงินทอน", (CashPay - mCashAmou))
        dtgPaid.ClearSelection()
      End If
      dv = Nothing
    End If
    ds = Nothing
  End Sub

  Private Sub tbnPrintBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnPrintBill.Click
    If lblSaleNumb.Text = "" Or mSaleStat = "0" Then
      Exit Sub
    End If

    pdcBillVat.Print()
  End Sub

  Private Sub tbnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnRefresh.Click
    ClearAll()
    ShowHistSale()
  End Sub

  Private Sub CheckPriv()
    ' Edit
    If InStr(pUserPriv, Me.Tag.ToString & "E") > 0 Then
      tbnChangeSalePaid.Enabled = True
    Else
      tbnChangeSalePaid.Enabled = False
    End If
    '' Cancel
    'If InStr(pUserPriv, Me.Tag.ToString & "C") > 0 Then
    '  tbnCancel.Enabled = True
    'Else
    '  tbnCancel.Enabled = False
    'End If
    ' Print
    If InStr(pUserPriv, Me.Tag.ToString & "P") > 0 Then
      tbnPrintBill.Enabled = True
    Else
      tbnPrintBill.Enabled = False
    End If
  End Sub

  Private Sub tbnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnCancel.Click
    If lblSaleNumb.Text = "" Or mSaleStat = "0" Then
      Exit Sub
    End If

    If mSaleStat = "2" Then
      pMessageBox = New MyMessageBox("ไม่สามารถยกเลิก ใบขายที่สรุปบัญชีไปแล้วได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
      pMessageBox.ShowDialog()
      Exit Sub
    End If

    If mSaleStat = "3" Then
      pMessageBox = New MyMessageBox("ไม่สามารถยกเลิก ใบขายที่มีการคืนสินค้าไปแล้วได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
      pMessageBox.ShowDialog()
      Exit Sub
    End If

    If mCustTypeCode = "0" Then
      pMessageBox = New MyMessageBox("ไม่สามารถยกเลิก ใบขายลูกค้าออนไลน์ได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
      pMessageBox.ShowDialog()
      Exit Sub
    End If

    If mCustPoint - mThisPoint + mUsePoint < 0 Then
      pMessageBox = New MyMessageBox("ไม่สามารถยกเลิกใบขายได้ เนื่องจากสมาชิกได้ใช้แต้มไปแล้ว", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
      pMessageBox.ShowDialog()
      Exit Sub
    End If

    Dim mPassName As String = ""
    Dim mPassCode As String = ""
    If tbnCancel.Tag = "pwd" Then ' เมนูที่มี tag pwd ต้องป้อนรหัสสิทธิ
      Dim fPass As New frmPass
      fPass.ShowDialog()
      If fPass.pOK = True Then
        If InStr(fPass.pPassPriv, Me.Tag & "C") = 0 Then
          pMessageBox = New MyMessageBox("เฉพาะผู้มีสิทธิเท่านั้น", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
          pMessageBox.ShowDialog()
          Exit Sub
        Else
          mPassName = fPass.pPassName
          mPassCode = fPass.pPassCode
        End If
      Else
        Exit Sub
      End If
    End If
    '' Level 2 and 3 Only
    'If InStr(pUserPriv, "LEVEL2") = 0 AndAlso InStr(pUserPriv, "LEVEL3") = 0 Then
    '  Dim fPass As New frmPass
    '  fPass.ShowDialog()
    '  If fPass.pOK = True Then
    '    If InStr(fPass.pPassPriv, "LEVEL2") = 0 AndAlso InStr(fPass.pPassPriv, "LEVEL3") = 0 Then
    '      MessageBox.Show("ท่านไม่ได้รับอนุญาตให้เข้าใช้งาน", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '      Exit Sub
    '    End If
    '  Else
    '    Exit Sub
    '  End If
    'End If

    ' เช็คเป็นใบขายของสมาชิกใหม่ (มีค่าสมัครสมาชิก goodCode = 11755)
    Dim mIsNewMember As Boolean
    For Each mRow As DataGridViewRow In dtgSaleList.Rows
      If dtgSaleList.Item("goodCode", mRow.Index).Value = "11755" Then
        mIsNewMember = True
        Exit For
      End If
    Next
    If mIsNewMember = True Then
      pMessageBox = New MyMessageBox("ใบขายที่มีค่าสมัครสมาชิก หากยกเลิก ข้อมูลสมาชิกจะถูกยกเลิกด้วย" & vbCrLf & "ต้องการดำเนินการต่อหรือไม่", "คำเตือน", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
      If pMessageBox.ShowDialog = Windows.Forms.DialogResult.Cancel Then
        Exit Sub
      End If
    End If

    pMessageBox = New MyMessageBox("ยืนยันยกเลิกใบขาย", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
    If pMessageBox.ShowDialog = Windows.Forms.DialogResult.OK Then
      Dim mRemark As String
      mRemark = InputBox("สาเหตุการยกเลิก", "ยกเลิกใบขาย")
      If mRemark = "" Then
        Exit Sub
      Else
        mRemark = mRemark & "-" & mPassCode
      End If

      ' ใช้วันที่และเวลาของ server
      pServerDateTime = pService.ServerDateTime

      Dim mSqlText(dtgSaleList.Rows.Count * 4 + 4) As String
      Dim mLine As Integer = 0
      Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
      Dim mGoodCode As String
      Dim mGoodAmou As Integer
      Dim mStockOnhand As Integer

      mRemark = Mid(mRemark, 1, 50) ' เก็บได้ 50 ตัวอักษร
      mSqlText(mLine) = "UPDATE HistSale SET saleStat = '0', saleRema = '" & mRemark & "' WHERE saleNumb = '" & lblSaleNumb.Text & "'"
      mLine += 1

      For i As Integer = 0 To dtgSaleList.Rows.Count - 1
        mGoodCode = dtgSaleList.Item("GoodCode", i).Value
        mGoodAmou = CInt(dtgSaleList.Item("GoodAmou", i).Value) * CInt(dtgSaleList.Item("UnitFactor", i).Value)
        mStockOnhand = dtgSaleList.Item("stockOnhand", i).Value
        ' คืนสต๊อค
        mSqlText(mLine) = "UPDATE GoodInfo set " & mStockOnhandField & " = " & mStockOnhandField & " + " & mGoodAmou & " WHERE goodCode = '" & dtgSaleList.Item("GoodCode", i).Value.ToString & "'"
        mLine += 1

        ' Front card
        mSqlText(mLine) = "Insert into FrontCard (stockDate, stockTime, workType, branchCode, docNumb, emplName, goodCode, goodAmou, stockOnhand) Values ('" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', 'CSL', '" & pBranchCode & "', '" & lblSaleNumb.Text & "', '" & Mid(pUserName, 1, 10) & "', '" & mGoodCode & "', " & mGoodAmou & ", " & (mStockOnhand + mGoodAmou) & ")"
        mLine += 1
      Next

      ' คืนแต้มและยอดซื้อ
      mSqlText(mLine) = "Update CustInfo set hugPoint = hugPoint - " & mThisPoint & " + " & mUsePoint & ", totalBuy = totalBuy - " & mTotalPrice & ", totalSlip = totalSlip - 1 Where custCode = '" & mCustCode & "'"
      mLine += 1

      ' ลบประวัติการได้โปร.
      mSqlText(mLine) = "Delete from HistGetPro where saleNumb = '" & lblSaleNumb.Text & "'"
      mLine += 1

      ' ยกเลิกสิทธิ์แลกซื้อ ถ้ามีและยังไม่ได้ใช้
      mSqlText(mLine) = "Update BuyExchangeInfo set bxStat = '0' where issueSaleNumb = '" & lblSaleNumb.Text & "' and bxStat = '1'"
      mLine += 1

      ' ยกเลิกสมาชิก ถ้าเป็นสมาชิกใหม่
      If mIsNewMember = True Then
        mSqlText(mLine) = "Update CustInfo set custStat = '0' where custCode = '" & mCustCode & "'"
        mLine += 1
      End If

      '' เก็บข้อมูลการคืนแต้ม
      'If mThisPoint > 0 OrElse mUsePoint > 0 Then
      '  mSqlText(mLine) = "Insert into HistSalePro (saleNumb, thisPoint, usePoint, remainPoint, selectPro) Values ('" & lblSaleNumb.Text & "C', " & -mThisPoint & ", " & -mUsePoint & ", " & (mCustPoint - mThisPoint + mUsePoint) & ", 'Cancel sale')"
      '  mLine = mLine + 1
      'End If

      Dim mUpdate As String
      mUpdate = pService.UpdateData("Drug", mSqlText)
      If mUpdate = "1" Then
        'MessageBox.Show("ยกเลิกใบขายเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        ClearAll()
        ShowHistSale()
      Else
        MessageBox.Show(mUpdate, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End If
    End If
    'End If
    'End If
    'fPass = Nothing
  End Sub

  Private Sub dtgHistSale_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgHistSale.CellDoubleClick
    If e.RowIndex < 0 Then
      Exit Sub
    End If

    ShowSaleList(dtgHistSale.Item("saleNumb", e.RowIndex).Value)

  End Sub

  Private Sub dtgHistSale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgHistSale.KeyDown
    ' ป้องกันการกด Enter แล้วกระโดดไปบรรทัดต่อไป
    If e.KeyCode = Keys.Enter Then
      e.Handled = True
    End If
  End Sub

  Private Sub dtgHistSale_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtgHistSale.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      If dtgHistSale.Rows.Count > 0 Then
        ShowSaleList(dtgHistSale.CurrentRow.Index)
      End If
    End If
  End Sub

  Private Sub dtgHistSale_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgHistSale.RowEnter
    If e.RowIndex >= 0 Then
      dtgHistSale.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = dtgHistSale.Rows(e.RowIndex).DefaultCellStyle.ForeColor
    End If
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    ClearSaleList()
    ShowHistSale()
  End Sub

  Private Function CheckBuyExchange(ByVal SaleNumb As String) As String
    Dim mReturn As String = ""
    If SaleNumb <> "" Then
      Dim mSqlText As String
      mSqlText = "Select bxAmou, expireDate, useSaleNumb, bxStat from BuyExchangeInfo where issueSaleNumb = '" & SaleNumb & "'"
      Dim ds As New DataSet
      ds = pService.SelectData("Drug", mSqlText)
      If IsNothing(ds) = False Then
        Dim dv As New DataView(ds.Tables(0))
        If dv.Count > 0 Then
          With dv.Item(0)
            mReturn = .Item("bxAmou").ToString & " สิทธิ์แลกซื้อ"
            If .Item("bxStat").ToString = "0" Then
              mReturn = mReturn & " **ยกเลิก**"
            Else
              If .Item("useSaleNumb").ToString <> "" Then
                mReturn = mReturn & " [แลกซื้อแล้ว ใบขายเลขที่ " & .Item("useSaleNumb").ToString & "]"
              Else
                mReturn = mReturn & " ใช้ได้ถึง " & ThaiDate(CDate(.Item("expireDate")))
              End If
            End If
          End With
        End If
      End If
      ds = Nothing
    End If
    Return mReturn
  End Function

  Private Sub pdcBillVat_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcBillVat.PrintPage
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

    ' ชื่อบริษัท
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = pCompName
    e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
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
    mText = "ใบเสร็จรับเงิน"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' เลขที่ขาย
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "INV-" & lblSaleNumb.Text
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' วันที่-เวลา
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = lblSaleDate.Text
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' --------
    mRect = New RectangleF(mLeftMargin, mRowPos + 15, 255.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    Dim mGoodAmou As Integer
    Dim mGoodName As String
    Dim mBarcode As String
    Dim mUnitPrice As Double
    Dim mSubDisc As Double
    Dim mSubTotal As Double
    Dim mUnitDesc As String
    Dim mTotalDisc As Double
    Dim mTotalPrice As Double

    mTotalPrice = 0
    mTotalDisc = 0
    For Each row As DataGridViewRow In dtgSaleList.Rows
      mGoodName = dtgSaleList.Item("goodName", row.Index).Value
      mGoodAmou = dtgSaleList.Item("goodAmou", row.Index).Value
      mBarcode = dtgSaleList.Item("barCode", row.Index).Value
      mUnitPrice = dtgSaleList.Item("unitPrice", row.Index).Value
      mSubDisc = dtgSaleList.Item("subDisc", row.Index).Value
      mUnitDesc = dtgSaleList.Item("unitDesc", row.Index).Value
      mSubTotal = CLng(mGoodAmou * mUnitPrice)
      mTotalPrice += mSubTotal
      mTotalDisc += mSubDisc
      ' จำนวน
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      'mText = dtgSaleList.Item("goodAmou", row.Index).Value.ToString & " " & dtgSaleList.Item("unitDesc", row.Index).Value.ToString
      mText = mGoodAmou & " " & mUnitDesc
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' ชื่อสินค้า
      mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      'mText = dtgSaleList.Item("goodName", row.Index).Value.ToString
      mText = mGoodName
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' ราคาขาย
      mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      'mText = Format(dtgSaleList.Item("subTotal", row.Index).Value, "#,##0.00")
      mText = Format(mSubTotal, "#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' รหัสสินค้า
      mRect = New RectangleF(55, mRowPos + 12, 260.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      'mText = "[" & dtgSaleList.Item("barCode", row.Index).Value.ToString & "]"
      mText = "[" & mBarcode & "]"
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

      ' แสดงส่วนลดของสินค้าแต่ละตัวที่ได้ลด
      If mSubDisc > 0 Then
        ' จำนวน
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "ส่วนลด"
        e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
        ' ชื่อสินค้า
        mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = mGoodName
        e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
        ' ส่วนลด
        mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = Format(-mSubDisc, "#,##0.00")
        e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
        ' รหัสสินค้า
        mRect = New RectangleF(55, mRowPos + 12, 260.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "[" & mBarcode & "]"
        e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
      End If
    Next
    '' ส่วนลดสินค้า
    'If mTotalDisc > 0 Then
    '  ' จำนวน
    '  mLineNo = mLineNo + 1
    '  mRowPos = mLineNo * mLineSpace
    '  mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
    '  mAlign.Alignment = StringAlignment.Near
    '  mText = "1"
    '  e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    '  ' ส่วนลด
    '  mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
    '  mAlign.Alignment = StringAlignment.Near
    '  mText = "ส่วนลดสินค้า"
    '  e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    '  ' ยอดเงิน
    '  mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
    '  mAlign.Alignment = StringAlignment.Far
    '  mText = mTotalDisc.ToString("#,##0.00")
    '  e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    'End If
    ' ส่วนลดจากแต้ม
    If mPointDisc > 0 Then
      ' จำนวน
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "1"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' ส่วนลด
      mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "ส่วนลดจากแต้ม"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' ยอดเงิน
      mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = Format(-mPointDisc, "#,##0.00") '-mPointDisc.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    End If
    ' --------
    mRowPos += 20
    'mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 255.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    '' จำนวนรายการ
    'mLineNo = mLineNo + 1
    'mRowPos = mLineNo * mLineSpace
    'mRect = New RectangleF(mLeftMargin, mRowPos, 90.0F, 20.0F)
    'mAlign.Alignment = StringAlignment.Near
    'mText = dtgSaleList.Rows.Count.ToString & " รายการ"
    'e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    ' ยอดสินค้ารวม (หักส่วนลด)
    mLineNo = mLineNo + 1
    mRowPos += 20
    'mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(80, mRowPos, 110.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ยอดสินค้ารวม"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = Format(mTotalPrice - mTotalDisc - mPointDisc, "#,##0.00")
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    '' ส่วนลดรวม
    'mLineNo = mLineNo + 1
    'mRowPos += 20
    ''mRowPos = mLineNo * mLineSpace
    'mRect = New RectangleF(80, mRowPos, 110.0F, 20.0F)
    'mAlign.Alignment = StringAlignment.Near
    'mText = "ส่วนลดรวม"
    'e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    'mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
    'mAlign.Alignment = StringAlignment.Far
    'mText = Format(mTotalDisc, "#,##0.00")
    'e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    'If mPointDisc > 0 Then
    '  ' แต้มเงินสดที่ใช้
    '  mLineNo = mLineNo + 1
    '  mRowPos += 20
    '  'mRowPos = mLineNo * mLineSpace
    '  mRect = New RectangleF(80, mRowPos, 110.0F, 20.0F)
    '  mAlign.Alignment = StringAlignment.Near
    '  mText = "ส่วนลดจากการใช้แต้ม"
    '  e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    '  mAlign.Alignment = StringAlignment.Far
    '  mText = mPointDisc.ToString("#,##0.00")
    '  e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    'End If

    '' ยอดชำระสุทธิ
    'mLineNo = mLineNo + 1
    'mRowPos += 20
    ''mRowPos = mLineNo * mLineSpace
    'mRect = New RectangleF(80, mRowPos, 110.0F, 20.0F)
    'mAlign.Alignment = StringAlignment.Near
    'mText = "ยอดชำระสุทธิ"
    'e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    'mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
    'mAlign.Alignment = StringAlignment.Far
    'mText = (mTotalPrice - mPointDisc).ToString("#,##0.00")
    'e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    ' $$$$$$$$$$$$$$$$$
    For Each mRow As DataGridViewRow In dtgPaid.Rows
      ' พิมพ์เฉพาะรายการที่เป็นประเภทการชำระเงิน
      If dtgPaid.Item("cardCode", mRow.Index).Value <> "" And dtgPaid.Item("cardCode", mRow.Index).Value <> "0" Then
        mLineNo = mLineNo + 1
        mRowPos += 20
        mRect = New RectangleF(80, mRowPos, 110.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "ชำระ " & dtgPaid.Item("cardName", mRow.Index).Value
        e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = MyVal(dtgPaid.Item("payAmou", mRow.Index).Value).ToString("#,##0.00")
        e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      End If
    Next
    ' $$$$$$$$$$$$$$$$$
    If mTotalCashPay > 0 Then
      ' ชำระเงินสด
      mLineNo = mLineNo + 1
      mRowPos += 20
      mRect = New RectangleF(80, mRowPos, 110.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "ชำระ เงินสด"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotalCashPay.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' เงินทอน
      mLineNo = mLineNo + 1
      mRowPos += 20
      mRect = New RectangleF(80, mRowPos, 110.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "เงินทอน"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotalChange.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    End If
    ' แสดงแต้ม เฉพาะสมาชิก HUG Club ********
    If mCustTypeCode = "6" Then
      ' --------
      mRowPos += 20
      mRect = New RectangleF(mLeftMargin, mRowPos, 255.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "-------------------------------------------------------------------"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' รหัสสมาชิก
      mRowPos += 20
      mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "สมาชิก " & lblCustName.Text & " [" & mCustCode & "]"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' แต้มที่ได้ครั้งนี้
      mRowPos += 20
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "HUG Cash Points (ครั้งนี้)"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' จำนวนแต้ม
      mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = Format(mThisPoint, "#,##0")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' แต้มที่ใช้
      mRowPos += 20
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "HUG Cash Points (ที่ใช้เป็นส่วนลด)"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' จำนวนแต้ม
      mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = Format(mUsePoint, "#,##0")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' แต้มสะสม
      mRowPos += 20
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "HUG Cash Points (สะสม)"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' จำนวนแต้ม
      mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = Format(mRemainPoint + mThisPoint, "#,##0")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    End If
    ' ***************
    ' --------
    mRowPos += 15
    mRect = New RectangleF(mLeftMargin, mRowPos, 255.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    '############ ส่วนแสดงสิทธิ์แลกซื้อ ไม่ควรพิมพ์ใหม่ได้ เพื่อป้องกันพนักงานแอบพิมพ์ เพื่อนำไปใช้แลกสิทธิ์เอง
    ' สิทธิ์แลกซื้อ
    Dim mGet() As String
    mGet = pService.GetData("Drug", "Select bxAmou, bxCode, expireDate from BuyExchangeInfo where issueSaleNumb = '" & lblSaleNumb.Text & "'")
    If mGet(0) = "1" Then
      mRowPos = mRowPos + 15
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = mGet(1) & " สิทธิ์แลกซื้อ [" & mGet(2) & "]" & " ใช้ได้ถึง " & mGet(3)
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    End If
    '############
    ' แสดงชื่อ cashier และพนักงาน โดยแสดงเฉพาะชื่อไม่รวมนามสกุล (แยกชื่อ-นามสกุลออกจากกันโดยเช็คช่องว่าง)
    mLineNo = mLineNo + 1
    mRowPos += 20
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "CSHR-" & Mid(lblCashName.Text, 1, 15)
    'mText = "CSHR-" & Mid(lblCashName.Text, 1, lblCashName.Text.LastIndexOf(" "))
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' พนักงาน
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    'mText = "EMPL-" & Mid(lblEmplName.Text, 1, lblEmplName.Text.LastIndexOf(" "))
    mText = "EMPL-" & Mid(lblEmplName.Text, 1, 15)
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    '' ขอบคุณ
    'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    'mAlign.Alignment = StringAlignment.Far
    'mText = "ขอบคุณที่ใช้บริการ"
    'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

    '' --------
    'mRowPos = mRowPos + 15
    'mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
    'mAlign.Alignment = StringAlignment.Near
    'mText = "-------------------------------------------------------------------"
    'e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' ท้ายเอกสาร 1
    mLineNo = mLineNo + 1
    mRowPos += 25
    'mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "ขอสงวนสิทธิ์ในการรับเปลี่ยน/คืนสินค้า"
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' ท้ายเอกสาร 2
    mLineNo = mLineNo + 1
    mRowPos += 15
    'mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "หากไม่มีใบเสร็จรับเงินมาแสดง"
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  End Sub

  Private Sub tbnChangeSalePaid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnChangeSalePaid.Click
    If lblSaleNumb.Text = "" Or mSaleStat = "0" Then
      Exit Sub
    End If

    If mSaleStat = "2" Then
      pMessageBox = New MyMessageBox("ไม่สามารถแก้ไข ใบขายที่สรุปบัญชีไปแล้วได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
      pMessageBox.ShowDialog()
      Exit Sub
    End If

    frmChangeSalePaid.pSaleNumb = lblSaleNumb.Text
    frmChangeSalePaid.pTotalPrice = mTotalPrice - mPointDisc
    frmChangeSalePaid.ShowDialog()
    If frmChangeSalePaid.pOk = True Then
      ShowSaleList(lblSaleNumb.Text)
    End If
    frmChangeSalePaid = Nothing

  End Sub

  Private Sub pdcFullBillVat_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcFullBillVat.PrintPage
    Dim prnFontNormal As New Font("CordiaUPC", 12, GraphicsUnit.Point)
    Dim prnFontNormalBold As New Font("CordiaUPC", 12, FontStyle.Bold)
    Dim prnFontSmall As New Font("CordiaUPC", 10, GraphicsUnit.Point)
    Dim prnFontSmallBold As New Font("CordiaUPC", 10, FontStyle.Bold)
    Dim prnFontVerySmall As New Font("CordiaUPC", 8, GraphicsUnit.Point)
    Dim prnFontBigBold As New Font("CordiaUPC", 14, FontStyle.Bold)

    Dim mRowPos As Single
    Dim mLeftMargin As Single = 5.0F
    Dim mCol2Pos As Single = 70.0F
    Dim mCol3Pos As Single = 260.0F

    Dim mLineNo As Integer
    Dim mLineSpace As Integer = 30
    Dim mLineSpace15 As Integer = 15
    Dim mLineSpace10 As Integer = 10
    Dim mRect As RectangleF
    Dim mAlign As New StringFormat()
    Dim mText As String
    Dim mAddrText As List(Of String)
    Dim mWrapText As List(Of String)

    ' ชื่อบริษัท
    mLineNo = mLineNo + 1
    mRowPos = mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = pHugName & " (สำนักงานใหญ่)"
    e.Graphics.DrawString(mText, prnFontNormalBold, Brushes.Black, mRect, mAlign)
    ' ที่อยู่บริษัท
    ' ใช้ฟังชั่นตัดคำ เพื่อแยกข้อความออกเป็นบรรทัด ตามความยาวที่กำหนด เพื่อให้พิมพ์ออกมาได้ทุกบรรทัด ไม่ตกขอบกระดาษ
    mAddrText = WrapText(pHugAddress, 50)
    For x As Integer = 0 To mAddrText.Count - 1
      mLineNo = mLineNo + 1
      mRowPos += 15
      mRect = New RectangleF(mLeftMargin, mRowPos, 245, 20)
      mAlign.Alignment = StringAlignment.Center
      mText = mAddrText(x)
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    Next
    'mLineNo = mLineNo + 1
    'mRowPos += 20
    'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    'mAlign.Alignment = StringAlignment.Center
    'mText = pCompAddress
    'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    '' ที่อยู่ 2
    'mLineNo = mLineNo + 1
    'mRowPos += mLineSpace15
    'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    'mAlign.Alignment = StringAlignment.Center
    'mText = pCompAddr2
    'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' เลขประจำตัวผู้เสียภาษี
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "เลขประจำตัวผู้เสียภาษี " & pHugTaxNumber
    e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
    '' สาขาที่ออกใบกำกับภาษี
    'mLineNo = mLineNo + 1
    'mRowPos += mLineSpace15
    'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    'mAlign.Alignment = StringAlignment.Center
    'mText = "สาขาที่ออกใบกำกับภาษี"
    'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' ชื่อสาขา
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "สาขาที่ออกใบกำกับภาษี " & pTaxBranchNo
    e.Graphics.DrawString(mText, prnFontSmallBold, Brushes.Black, mRect, mAlign)
    ' เลขสาขา, POS
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "Branch#" & Mid((1000 + pBranchIndex).ToString, 2) & "   POS#" & pPOSNumber
    e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)

    ' หัวเอกสาร
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "ใบเสร็จรับเงิน / ใบกำกับภาษี"
    e.Graphics.DrawString(mText, prnFontSmallBold, Brushes.Black, mRect, mAlign)
    ' หัวเอกสาร อังกฤษ
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "RECEIPT / TAX INVOICE"
    e.Graphics.DrawString(mText, prnFontSmallBold, Brushes.Black, mRect, mAlign)
    ' เลขที่ขาย
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "No. " & SplitTaxInvoiceNumber(mTaxInvoiceNumb)
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' วันที่-เวลา
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = lblSaleDate.Text
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' ชื่อผู้ซื้อ
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ชื่อผู้ซื้อ "
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    mWrapText = WrapText(mTaxName, 50)
    For x As Integer = 0 To mWrapText.Count - 1
      If x > 0 Then ' list ที่สองขึ้นไป (ถ้ามี) ให้ขึ้นบรรทัดใหม่
        mLineNo = mLineNo + 1
        mRowPos += mLineSpace15
      End If
      mRect = New RectangleF(mLeftMargin + 30, mRowPos, 245, 20)
      mAlign.Alignment = StringAlignment.Near
      mText = mWrapText(x)
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    Next

    ' ที่อยู่ผู้ซื้อ
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ที่อยู่ "
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' ใช้ฟังชั่นตัดคำ เพื่อแยกข้อความออกเป็นบรรทัด ตามความยาวที่กำหนด เพื่อให้พิมพ์ออกมาได้ทุกบรรทัด ไม่ตกขอบกระดาษ
    ' ตัดรหัส vbLf ซึ่งเป็นรหัสขึ้นบรรทัดใหม่ออก แก้ปัญหาพิมพ์ข้อความได้ไม่หมดบรรทัด
    mAddrText = WrapText(mTaxAddr.Replace(vbLf, ""), 50)
    For x As Integer = 0 To mAddrText.Count - 1
      If x > 0 Then ' list ที่สองขึ้นไป (ถ้ามี) ให้ขึ้นบรรทัดใหม่
        mLineNo = mLineNo + 1
        mRowPos += mLineSpace15
      End If
      mRect = New RectangleF(mLeftMargin + 20, mRowPos, 245, 20)
      mAlign.Alignment = StringAlignment.Near
      mText = mAddrText(x).Trim
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    Next
    'mLineNo = mLineNo + 1
    'mRowPos += mLineSpace15
    'mRect = New RectangleF(mLeftMargin, mRowPos, 245, 50)
    'mAlign.Alignment = StringAlignment.Near
    'mText = "ที่อยู่ " & mTaxAddr
    'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' หมายเลขประจำตัวผู้เสียภาษี
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "หมายเลขประจำตัวผู้เสียภาษี " & mTaxID
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' --------
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = StrDup(80, "-")
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

    Dim mGoodAmou As Integer
    Dim mGoodName As String
    Dim mBarcode As String
    Dim mUnitPrice As Double
    Dim mSubDisc As Double
    Dim mSubTotal As Double
    Dim mUnitDesc As String
    Dim mTotalDisc As Double
    Dim mTotalPrice As Double
    Dim mTotalNet As Double
    Dim mTotalBeforeVat As Double

    mTotalPrice = 0
    mTotalDisc = 0
    For Each row As DataGridViewRow In dtgSaleList.Rows
      mGoodName = dtgSaleList.Item("goodName", row.Index).Value
      mGoodAmou = dtgSaleList.Item("goodAmou", row.Index).Value
      mBarcode = dtgSaleList.Item("barCode", row.Index).Value
      mUnitPrice = dtgSaleList.Item("unitPrice", row.Index).Value
      mSubDisc = dtgSaleList.Item("subDisc", row.Index).Value
      mUnitDesc = dtgSaleList.Item("unitDesc", row.Index).Value
      mSubTotal = CLng(mGoodAmou * mUnitPrice)
      mTotalPrice += mSubTotal
      mTotalDisc += mSubDisc
      ' จำนวน
      mLineNo = mLineNo + 1
      mRowPos += mLineSpace15
      mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = mGoodAmou & " " & mUnitDesc
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
      ' ชื่อสินค้า
      mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = mGoodName
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
      ' ราคาขาย
      mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = Format(mSubTotal, "#,##0.00")
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
      '' รหัสสินค้า
      'mRowPos += mLineSpace15
      'mRect = New RectangleF(55, mRowPos, 260.0F, 20.0F)
      'mAlign.Alignment = StringAlignment.Near
      'mText = "[" & mBarcode & "]"
      'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

      ' แสดงส่วนลดของสินค้าแต่ละตัวที่ได้ลด
      If mSubDisc > 0 Then
        ' จำนวน
        mLineNo = mLineNo + 1
        mRowPos += mLineSpace15
        mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "1"
        e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
        ' ชื่อสินค้า
        mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "ส่วนลด " & mGoodName
        e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
        ' ส่วนลด
        mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = Format(-mSubDisc, "#,##0.00")
        e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
        '' รหัสสินค้า
        'mRowPos += mLineSpace15
        'mRect = New RectangleF(55, mRowPos, 260.0F, 20.0F)
        'mAlign.Alignment = StringAlignment.Near
        'mText = "[" & mBarcode & "]"
        'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
      End If
    Next
    ' ส่วนลดจากแต้ม
    If mPointDisc > 0 Then
      ' จำนวน
      mLineNo = mLineNo + 1
      mRowPos += mLineSpace15
      mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "1"
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
      ' ส่วนลด
      mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "ส่วนลดจากแต้ม"
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
      ' ยอดเงิน
      mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = Format(-mPointDisc, "#,##0.00") '-mPointDisc.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    End If
    ' --------
    mRowPos += mLineSpace15
    'mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = StrDup(80, "-")
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' ยอดสินค้าสุทธิ (หลังหักส่วนลด)
    mTotalNet = mTotalPrice - mTotalDisc - mPointDisc
    ' ยอดเงินก่อนภาษี
    mTotalBeforeVat = mTotalNet * 100 / (100 + pVat)

    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ราคาสินค้าไม่รวมภาษีมูลค่าเพิ่ม"
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

    mRect = New RectangleF(195, mRowPos, 55, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = Format(mTotalBeforeVat, "#,##0.00")
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' ภาษีมูลค่าเพิ่ม
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ภาษีมูลค่าเพิ่ม " & Format(pVat, "#0") & "%"
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

    mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = Format(mTotalNet - mTotalBeforeVat, "#,##0.00")
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' ยอดสินค้าสุทธิ
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "จำนวนเงินรวมทั้งสิ้น"
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

    mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = Format(mTotalNet, "#,##0.00")
    e.Graphics.DrawString(mText, prnFontNormalBold, Brushes.Black, mRect, mAlign)

    ' จำนวนเงินเป็นตัวอักษร
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "(" & MoneyToWord(mTotalNet) & ")"
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

    '' ประเภทการชำระเงิน
    'For Each mRow As DataGridViewRow In dtgPaid.Rows
    '  If dtgPaid.Item("cardCode", mRow.Index).Value <> "" And dtgPaid.Item("cardCode", mRow.Index).Value <> "0" Then
    '    mLineNo = mLineNo + 1
    '    mRowPos += mLineSpace15
    '    mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
    '    mAlign.Alignment = StringAlignment.Near
    '    mText = "ชำระ " & dtgPaid.Item("cardName", mRow.Index).Value
    '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

    '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    '    mAlign.Alignment = StringAlignment.Far
    '    mText = MyVal(dtgPaid.Item("payAmou", mRow.Index).Value).ToString("#,##0.00")
    '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    '  End If
    'Next

    '  ' ชำระเงินสด
    'If mTotalCashPay > 0 Then
    '  mLineNo = mLineNo + 1
    '  mRowPos += mLineSpace15
    '  mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
    '  mAlign.Alignment = StringAlignment.Near
    '  mText = "ชำระ เงินสด"
    '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

    '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    '  mAlign.Alignment = StringAlignment.Far
    '  mText = mTotalCashPay.ToString("#,##0.00")
    '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    '  ' เงินทอน
    '  mLineNo = mLineNo + 1
    '  mRowPos += mLineSpace15
    '  mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
    '  mAlign.Alignment = StringAlignment.Near
    '  mText = "เงินทอน"
    '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

    '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    '  mAlign.Alignment = StringAlignment.Far
    '  mText = mTotalChange.ToString("#,##0.00")
    '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    'End If

    '' แสดงแต้ม เฉพาะสมาชิก HUG Club ********
    'If mCustTypeCode = "6" Then
    '  ' --------
    '  mRowPos += mLineSpace15
    '  mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
    '  mAlign.Alignment = StringAlignment.Near
    '  mText = StrDup(80, "-")
    '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    '  ' รหัสสมาชิก
    '  mRowPos += mLineSpace15
    '  mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
    '  mAlign.Alignment = StringAlignment.Near
    '  mText = "สมาชิก " & lblCustName.Text & " [" & mCustCode & "]"
    '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    '  ' แต้มที่ได้ครั้งนี้
    '  mRowPos += mLineSpace15
    '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    '  mAlign.Alignment = StringAlignment.Near
    '  mText = "HUG Points (ครั้งนี้) " & Format(mThisPoint, "#,##0")
    '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    '  '' จำนวนแต้ม
    '  'mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
    '  'mAlign.Alignment = StringAlignment.Far
    '  'mText = Format(mThisPoint, "#,##0")
    '  'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    '  ' แต้มที่ใช้
    '  mRowPos += mLineSpace15
    '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    '  mAlign.Alignment = StringAlignment.Near
    '  mText = "HUG Points (ใช้เป็นส่วนลด) " & Format(mUsePoint, "#,##0")
    '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    '  '' จำนวนแต้ม
    '  'mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
    '  'mAlign.Alignment = StringAlignment.Far
    '  'mText = Format(mUsePoint, "#,##0")
    '  'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    '  ' แต้มสะสม
    '  mRowPos += mLineSpace15
    '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    '  mAlign.Alignment = StringAlignment.Near
    '  mText = "HUG Points (สะสม) " & Format(mRemainPoint + mThisPoint, "#,##0")
    '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    '  '' จำนวนแต้ม
    '  'mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
    '  'mAlign.Alignment = StringAlignment.Far
    '  'mText = Format(mRemainPoint + mThisPoint, "#,##0")
    '  'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    'End If
    '' ***************

    ' --------
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = StrDup(80, "-")
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' พนักงาน
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "พนักงานขาย " & RemoveNickName(lblEmplName.Text)
    e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
    ' Cashier
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ผู้รับเงิน " & RemoveNickName(lblCashName.Text)
    e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)

    ' ท้ายเอกสาร 1
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ขอสงวนสิทธิ์ในการรับเปลี่ยน/คืนสินค้า หากไม่มีใบเสร็จรับเงินมาแสดง"
    e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
    '' ท้ายเอกสาร 2
    'mLineNo = mLineNo + 1
    'mRowPos += mLineSpace15
    'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    'mAlign.Alignment = StringAlignment.Center
    'mText = "หากไม่มีใบเสร็จรับเงินมาแสดง"
    'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  End Sub

  'Private Sub pdc3_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdc3.PrintPage
  '  Dim prnFontNormal As New Font("CordiaUPC", 12, GraphicsUnit.Point)
  '  Dim prnFontNormalBold As New Font("CordiaUPC", 12, FontStyle.Bold)
  '  Dim prnFontSmall As New Font("CordiaUPC", 10, GraphicsUnit.Point)
  '  Dim prnFontSmallBold As New Font("CordiaUPC", 10, FontStyle.Bold)
  '  Dim prnFontVerySmall As New Font("CordiaUPC", 8, GraphicsUnit.Point)
  '  Dim prnFontBigBold As New Font("CordiaUPC", 14, FontStyle.Bold)

  '  Dim mRowPos As Single
  '  Dim mLeftMargin As Single = 5.0F
  '  Dim mCol2Pos As Single = 70.0F
  '  Dim mCol3Pos As Single = 260.0F

  '  Dim mLineNo As Integer
  '  Dim mLineSpace As Integer = 30
  '  Dim mLineSpace15 As Integer = 15
  '  Dim mLineSpace10 As Integer = 10
  '  Dim mRect As RectangleF
  '  Dim mAlign As New StringFormat()
  '  Dim mText As String
  '  'Dim mAddrText As List(Of String)

  '  ' ชื่อบริษัท
  '  mLineNo = mLineNo + 1
  '  mRowPos = mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Center
  '  'mText = pHugName & " (สำนักงานใหญ่)"
  '  mText = pHugName
  '  e.Graphics.DrawString(mText, prnFontNormalBold, Brushes.Black, mRect, mAlign)
  '  '' ที่อยู่บริษัท
  '  '' ใช้ฟังชั่นตัดคำ เพื่อแยกข้อความออกเป็นบรรทัด ตามความยาวที่กำหนด เพื่อให้พิมพ์ออกมาได้ทุกบรรทัด ไม่ตกขอบกระดาษ
  '  'mAddrText = WrapText(pCompAddress, 50)
  '  'For x As Integer = 0 To mAddrText.Count - 1
  '  '  mLineNo = mLineNo + 1
  '  '  mRowPos += 15
  '  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245, 20)
  '  '  mAlign.Alignment = StringAlignment.Center
  '  '  mText = mAddrText(x)
  '  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  'Next
  '  ' เลขประจำตัวผู้เสียภาษี
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Center
  '  mText = "TAX#" & pHugTaxNumber
  '  e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
  '  '' สาขาที่ออกใบกำกับภาษี
  '  'mLineNo = mLineNo + 1
  '  'mRowPos += mLineSpace15
  '  'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  'mAlign.Alignment = StringAlignment.Center
  '  'mText = "สาขาที่ออกใบกำกับภาษี"
  '  'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  ' ชื่อสาขา
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Center
  '  'mText = "สาขาที่ออกใบกำกับภาษี " & pTaxBranchNo
  '  mText = "สาขา " & pTaxBranchNo
  '  e.Graphics.DrawString(mText, prnFontSmallBold, Brushes.Black, mRect, mAlign)
  '  ' เลข POS
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Center
  '  mText = "POS#" & pPOSNumber
  '  e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
  '  '' เลขสาขา, POS
  '  'mLineNo = mLineNo + 1
  '  'mRowPos += mLineSpace15
  '  'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  'mAlign.Alignment = StringAlignment.Center
  '  'mText = "เลขสาขา:" & pTaxBranchNo & "   POS#" & pTaxBranchPOS
  '  'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '  ' หัวเอกสาร
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Center
  '  mText = "ใบเสร็จรับเงิน/ใบกำกับภาษีอย่างย่อ(ABB.)"
  '  e.Graphics.DrawString(mText, prnFontSmallBold, Brushes.Black, mRect, mAlign)
  '  '' หัวเอกสาร อังกฤษ
  '  'mLineNo = mLineNo + 1
  '  'mRowPos += mLineSpace15
  '  'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  'mAlign.Alignment = StringAlignment.Center
  '  'mText = "RECEIPT / TAX INVOICE"
  '  'e.Graphics.DrawString(mText, prnFontNormalBold, Brushes.Black, mRect, mAlign)
  '  ' เลขที่ขาย
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = "No. " & SplitSaleNumb(lblSaleNumb.Text)
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  ' วันที่-เวลา
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Far
  '  mText = lblSaleDate.Text
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  '' ชื่อผู้ซื้อ
  '  'mLineNo = mLineNo + 1
  '  'mRowPos += mLineSpace15
  '  'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  'mAlign.Alignment = StringAlignment.Near
  '  'mText = "ชื่อผู้ซื้อ " & mTaxName
  '  'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  '' ที่อยู่ผู้ซื้อ
  '  'mLineNo = mLineNo + 1
  '  'mRowPos += mLineSpace15
  '  'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  'mAlign.Alignment = StringAlignment.Near
  '  'mText = "ที่อยู่ "
  '  'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  '' ใช้ฟังชั่นตัดคำ เพื่อแยกข้อความออกเป็นบรรทัด ตามความยาวที่กำหนด เพื่อให้พิมพ์ออกมาได้ทุกบรรทัด ไม่ตกขอบกระดาษ
  '  'mAddrText = WrapText(mTaxAddr, 50)
  '  'For x As Integer = 0 To mAddrText.Count - 1
  '  '  If x > 0 Then ' list ที่สองขึ้นไป (ถ้ามี) ให้ขึ้นบรรทัดใหม่
  '  '    mLineNo = mLineNo + 1
  '  '    mRowPos += mLineSpace15
  '  '  End If
  '  '  mRect = New RectangleF(mLeftMargin + 20, mRowPos, 245, 20)
  '  '  mAlign.Alignment = StringAlignment.Near
  '  '  mText = mAddrText(x)
  '  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  'Next
  '  '' หมายเลขประจำตัวผู้เสียภาษี
  '  'mLineNo = mLineNo + 1
  '  'mRowPos += mLineSpace15
  '  'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  'mAlign.Alignment = StringAlignment.Near
  '  'mText = "หมายเลขประจำตัวผู้เสียภาษี " & "0123456789012345" ' mTaxID
  '  'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  ' --------
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = StrDup(80, "-")
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '  Dim mGoodAmou As Integer
  '  Dim mGoodName As String
  '  Dim mBarcode As String
  '  Dim mUnitPrice As Double
  '  Dim mSubDisc As Double
  '  Dim mSubTotal As Double
  '  Dim mUnitDesc As String
  '  Dim mTotalDisc As Double
  '  Dim mTotalPrice As Double
  '  Dim mTotalNet As Double
  '  'Dim mTotalBeforeVat As Double

  '  mTotalPrice = 0
  '  mTotalDisc = 0
  '  For Each row As DataGridViewRow In dtgSaleList.Rows
  '    mGoodName = dtgSaleList.Item("goodName", row.Index).Value
  '    mGoodAmou = dtgSaleList.Item("goodAmou", row.Index).Value
  '    mBarcode = dtgSaleList.Item("barCode", row.Index).Value
  '    mUnitPrice = dtgSaleList.Item("unitPrice", row.Index).Value
  '    mSubDisc = dtgSaleList.Item("subDisc", row.Index).Value
  '    mUnitDesc = dtgSaleList.Item("unitDesc", row.Index).Value
  '    mSubTotal = CLng(mGoodAmou * mUnitPrice)
  '    mTotalPrice += mSubTotal
  '    mTotalDisc += mSubDisc
  '    ' จำนวน
  '    mLineNo = mLineNo + 1
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = mGoodAmou & " " & mUnitDesc
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' ชื่อสินค้า
  '    mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = mGoodName
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' ราคาขาย
  '    mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Far
  '    mText = Format(mSubTotal, "#,##0.00")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    '' รหัสสินค้า
  '    'mRowPos += mLineSpace15
  '    'mRect = New RectangleF(55, mRowPos, 260.0F, 20.0F)
  '    'mAlign.Alignment = StringAlignment.Near
  '    'mText = "[" & mBarcode & "]"
  '    'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '    ' แสดงส่วนลดของสินค้าแต่ละตัวที่ได้ลด
  '    If mSubDisc > 0 Then
  '      ' จำนวน
  '      mLineNo = mLineNo + 1
  '      mRowPos += mLineSpace15
  '      mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
  '      mAlign.Alignment = StringAlignment.Near
  '      mText = "1"
  '      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '      ' ชื่อสินค้า
  '      mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
  '      mAlign.Alignment = StringAlignment.Near
  '      mText = "ส่วนลด " & mGoodName
  '      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '      ' ส่วนลด
  '      mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
  '      mAlign.Alignment = StringAlignment.Far
  '      mText = Format(-mSubDisc, "#,##0.00")
  '      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '      '' รหัสสินค้า
  '      'mRowPos += mLineSpace15
  '      'mRect = New RectangleF(55, mRowPos, 260.0F, 20.0F)
  '      'mAlign.Alignment = StringAlignment.Near
  '      'mText = "[" & mBarcode & "]"
  '      'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    End If
  '  Next
  '  ' ส่วนลดจากแต้ม
  '  If mPointDisc > 0 Then
  '    ' จำนวน
  '    mLineNo = mLineNo + 1
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "1"
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' ส่วนลด
  '    mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "ส่วนลดจากแต้ม"
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' ยอดเงิน
  '    mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Far
  '    mText = Format(-mPointDisc, "#,##0.00") '-mPointDisc.ToString("#,##0.00")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  End If
  '  ' --------
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = StrDup(80, "-")
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  ' ยอดสินค้าสุทธิ (หลังหักส่วนลด)
  '  mTotalNet = mTotalPrice - mTotalDisc - mPointDisc
  '  '' ยอดเงินก่อนภาษี
  '  'mTotalBeforeVat = mTotalNet * 100 / (100 + pVat)

  '  'mLineNo = mLineNo + 1
  '  'mRowPos += mLineSpace15
  '  'mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
  '  'mAlign.Alignment = StringAlignment.Near
  '  'mText = "ราคาสินค้าไม่รวมภาษีมูลค่าเพิ่ม"
  '  'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '  'mRect = New RectangleF(195, mRowPos, 55, 20.0F)
  '  'mAlign.Alignment = StringAlignment.Far
  '  'mText = Format(mTotalBeforeVat, "#,##0.00")
  '  'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  '' ภาษีมูลค่าเพิ่ม
  '  'mLineNo = mLineNo + 1
  '  'mRowPos += mLineSpace15
  '  'mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
  '  'mAlign.Alignment = StringAlignment.Near
  '  'mText = "ภาษีมูลค่าเพิ่ม " & Format(pVat, "#0") & "%"
  '  'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '  'mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
  '  'mAlign.Alignment = StringAlignment.Far
  '  'mText = Format(mTotalNet - mTotalBeforeVat, "#,##0.00")
  '  'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  ' จำนวนเงินรวมทั้งสิ้น
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = "จำนวนเงินรวมทั้งสิ้น"
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '  mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Far
  '  mText = Format(mTotalNet, "#,##0.00")
  '  e.Graphics.DrawString(mText, prnFontNormalBold, Brushes.Black, mRect, mAlign)

  '  '' จำนวนเงินเป็นตัวอักษร
  '  'mLineNo = mLineNo + 1
  '  'mRowPos += mLineSpace15
  '  'mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
  '  'mAlign.Alignment = StringAlignment.Near
  '  'mText = "(" & MoneyToWord(mTotalNet) & ")"
  '  'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '  ' ประเภทการชำระเงิน
  '  For Each mRow As DataGridViewRow In dtgPaid.Rows
  '    If dtgPaid.Item("cardCode", mRow.Index).Value <> "" And dtgPaid.Item("cardCode", mRow.Index).Value <> "0" Then
  '      mLineNo = mLineNo + 1
  '      mRowPos += mLineSpace15
  '      mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
  '      mAlign.Alignment = StringAlignment.Near
  '      mText = "ชำระ " & dtgPaid.Item("cardName", mRow.Index).Value
  '      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '      mAlign.Alignment = StringAlignment.Far
  '      mText = MyVal(dtgPaid.Item("payAmou", mRow.Index).Value).ToString("#,##0.00")
  '      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    End If
  '  Next

  '  ' ชำระเงินสด
  '  If mTotalCashPay > 0 Then
  '    mLineNo = mLineNo + 1
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "ชำระ เงินสด"
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Far
  '    mText = mTotalCashPay.ToString("#,##0.00")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' เงินทอน
  '    mLineNo = mLineNo + 1
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "เงินทอน"
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Far
  '    mText = mTotalChange.ToString("#,##0.00")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  End If

  '  ' แสดงแต้ม เฉพาะสมาชิก HUG Club ********
  '  If mCustTypeCode = "6" Then
  '    ' --------
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = StrDup(80, "-")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' รหัสสมาชิก
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "สมาชิก " & lblCustName.Text & " [" & mCustCode & "]"
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' แต้มที่ได้ครั้งนี้
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "HUG Points (ครั้งนี้) " & Format(mThisPoint, "#,##0")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    '' จำนวนแต้ม
  '    'mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
  '    'mAlign.Alignment = StringAlignment.Far
  '    'mText = Format(mThisPoint, "#,##0")
  '    'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' แต้มที่ใช้
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "HUG Points (ใช้เป็นส่วนลด) " & Format(mUsePoint, "#,##0")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    '' จำนวนแต้ม
  '    'mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
  '    'mAlign.Alignment = StringAlignment.Far
  '    'mText = Format(mUsePoint, "#,##0")
  '    'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' แต้มสะสม
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "HUG Points (สะสม) " & Format(mRemainPoint + mThisPoint, "#,##0")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    '' จำนวนแต้ม
  '    'mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
  '    'mAlign.Alignment = StringAlignment.Far
  '    'mText = Format(mRemainPoint + mThisPoint, "#,##0")
  '    'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  End If
  '  ' ***************
  '  ' สิทธิ์แลกซื้อ
  '  Dim mGet() As String
  '  mGet = pService.GetData("Drug", "Select bxAmou, bxCode, expireDate from BuyExchangeInfo where issueSaleNumb = '" & lblSaleNumb.Text & "'")
  '  If mGet(0) = "1" Then
  '    mRowPos = mRowPos + 15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = mGet(1) & " สิทธิ์แลกซื้อ [" & mGet(2) & "]" & " ใช้ได้ถึง " & mGet(3)
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  End If

  '  ' --------
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = StrDup(80, "-")
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  ' พนักงาน
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = "พนักงานขาย " & RemoveNickName(lblEmplName.Text)
  '  e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
  '  ' Cashier
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = "ผู้รับเงิน " & RemoveNickName(lblCashName.Text)
  '  e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)

  '  ' ท้ายเอกสาร 1
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = "ขอสงวนสิทธิ์ในการรับเปลี่ยน/คืนสินค้า หากไม่มีใบเสร็จรับเงินมาแสดง"
  '  e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
  '  ' VAT INCLUDED
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Center
  '  mText = "**** VAT INCLUDED ****"
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  'End Sub

  Private Sub tbnPrintBillVatFull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnPrintBillVatFull.Click
    If lblSaleNumb.Text = "" Or mSaleStat = "0" Then
      Exit Sub
    End If

    frmBillVatPrint.pSaleNumb = lblSaleNumb.Text
    frmBillVatPrint.pCustCode = mCustCode
    frmBillVatPrint.ShowDialog()

    If frmBillVatPrint.pOk = True Then
      pMessageBox = New MyMessageBox("ต้องการพิมพ์ใบกำกับภาษีหรือไม่", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      If pMessageBox.ShowDialog = Windows.Forms.DialogResult.Yes Then
        mTaxName = frmBillVatPrint.pTaxName
        mTaxAddr = frmBillVatPrint.pTaxAddr
        mTaxID = frmBillVatPrint.pTaxID
        mTaxInvoiceNumb = frmBillVatPrint.pTaxInvoiceNumb
        pdcFullBillVat.Print()
      End If
    End If

    frmBillVatPrint = Nothing
  End Sub

  Private Sub tbnPrintBillVatShort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnPrintBillVatShort.Click
    If lblSaleNumb.Text = "" Or mSaleStat = "0" Then
      Exit Sub
    End If

    pdcAbbBillVat.Print()
  End Sub

  Private Sub pdcAbbBillVat_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcAbbBillVat.PrintPage
    PrintAbbBillVat(mSaleNumb, e)
  End Sub

  'Private Sub pdc4_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdc4.PrintPage
  '  Dim prnFontNormal As New Font("CordiaUPC", 12, GraphicsUnit.Point)
  '  Dim prnFontNormalBold As New Font("CordiaUPC", 12, FontStyle.Bold)
  '  Dim prnFontSmall As New Font("CordiaUPC", 10, GraphicsUnit.Point)
  '  Dim prnFontSmallBold As New Font("CordiaUPC", 10, FontStyle.Bold)
  '  Dim prnFontVerySmall As New Font("CordiaUPC", 8, GraphicsUnit.Point)
  '  Dim prnFontBigBold As New Font("CordiaUPC", 14, FontStyle.Bold)

  '  Dim mRowPos As Single
  '  Dim mLeftMargin As Single = 5.0F
  '  Dim mCol2Pos As Single = 70.0F
  '  Dim mCol3Pos As Single = 260.0F

  '  Dim mLineNo As Integer
  '  Dim mLineSpace As Integer = 30
  '  Dim mLineSpace15 As Integer = 15
  '  Dim mLineSpace10 As Integer = 10
  '  Dim mRect As RectangleF
  '  Dim mAlign As New StringFormat()
  '  Dim mText As String

  '  ' ชื่อบริษัท
  '  mLineNo = mLineNo + 1
  '  mRowPos = mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Center
  '  mText = pHugName
  '  e.Graphics.DrawString(mText, prnFontNormalBold, Brushes.Black, mRect, mAlign)
  '  ' เลขประจำตัวผู้เสียภาษี
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Center
  '  mText = "TAX#" & pHugTaxNumber
  '  e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
  '  ' ชื่อสาขา
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Center
  '  mText = "สาขา " & pTaxBranchNo
  '  e.Graphics.DrawString(mText, prnFontSmallBold, Brushes.Black, mRect, mAlign)
  '  ' เลข POS
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Center
  '  mText = "POS#" & pPOSNumber
  '  e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
  '  ' หัวเอกสาร
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Center
  '  mText = "ใบเสร็จรับเงิน/ใบกำกับภาษีอย่างย่อ(ABB.)"
  '  e.Graphics.DrawString(mText, prnFontSmallBold, Brushes.Black, mRect, mAlign)

  '  ' ข้อมูลการขาย
  '  Dim ds As New DataSet
  '  Dim dvSale As DataView
  '  Dim dvPaid As DataView
  '  Dim mSqlText As String
  '  ' ข้อมูลขาย
  '  mSqlText = "Select HS.*, SL.*, CI.custName, GI.goodName, UI.unitDesc, HP.thisPoint, HP.usePoint, HP.remainPoint, EI.emplName, EI2.emplName as cashName from HistSale HS inner join CustInfo CI on CI.custCode = HS.custCode inner join SaleList SL on SL.saleNumb = HS.saleNumb inner join GoodInfo GI on GI.goodCode = SL.goodCode inner join UnitInfo UI on UI.unitCode = SL.unitCode left join EmplInfo EI ON HS.emplCode = EI.emplCode left join EmplInfo EI2 ON HS.cashCode = EI2.emplCode left join HistSalePro HP On HP.saleNumb = HS.saleNumb Where HS.saleNumb = '" & mSaleNumb & "'"
  '  ds = pService.SelectData("Drug", mSqlText)
  '  If IsNothing(ds) = False Then
  '    dvSale = New DataView(ds.Tables(0))
  '  Else
  '    dvSale = Nothing
  '  End If
  '  ' ข้อมูลชำระเงิน
  '  mSqlText = "Select distinct PL.cardCode, CD.cardName, CD.cardColor, PL.payAmou from SalePaidList PL inner join CardInfo CD on CD.cardCode = PL.cardCode left join HistSalePro HP On HP.saleNumb = PL.saleNumb where PL.saleNumb = '" & mSaleNumb & "'"
  '  ds = pService.SelectData("Drug", mSqlText)
  '  If IsNothing(ds) = False Then
  '    dvPaid = New DataView(ds.Tables(0))
  '  Else
  '    dvPaid = Nothing
  '  End If

  '  Dim mSaleDate As Date
  '  With dvSale.Item(0)
  '    mSaleDate = .Item("saleDate")
  '  End With

  '  ' เลขที่ขาย
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = "No. " & SplitSaleNumb(mSaleNumb)
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  ' วันที่-เวลา
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Far
  '  mText = mSaleDate
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  ' --------
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = StrDup(80, "-")
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '  Dim mGoodAmou As Integer
  '  Dim mGoodName As String
  '  Dim mBarcode As String
  '  Dim mUnitPrice As Double
  '  Dim mSubDisc As Double
  '  Dim mSubTotal As Double
  '  Dim mUnitDesc As String
  '  Dim mTotalDisc As Double = 0
  '  Dim mTotalPrice As Double = 0
  '  Dim mTotalNet As Double
  '  Dim mPointDisc As Double = 0
  '  Dim mTotalCashPay As Double = 0
  '  Dim mTotalCash As Double
  '  Dim mTotalChange As Double

  '  Dim mCustCode As String = ""
  '  Dim mCustName As String = ""
  '  Dim mCustTypeCode As String = ""

  '  Dim mThisPoint As Integer = 0
  '  Dim mUsePoint As Integer = 0
  '  Dim mRemainPoint As Integer = 0

  '  Dim mEmplName As String = ""
  '  Dim mCashName As String = ""

  '  For i As Integer = 0 To dvSale.Count - 1
  '    With dvSale.Item(i)
  '      mGoodName = .Item("goodName")
  '      mGoodAmou = .Item("goodAmou")
  '      mBarcode = .Item("barCode")
  '      mUnitPrice = .Item("unitPrice")
  '      mSubDisc = .Item("subDisc")
  '      mUnitDesc = .Item("unitDesc")
  '      mPointDisc = .Item("pointDisc")
  '      mTotalCashPay = .Item("totalPay")
  '      mTotalCash = .Item("totalCash")
  '      mTotalChange = mTotalCashPay - mTotalCash

  '      mCustCode = .Item("custCode")
  '      mCustName = .Item("custName")
  '      mCustTypeCode = .Item("custType")

  '      mEmplName = .Item("emplName")
  '      mCashName = .Item("cashName")

  '      If IsDBNull(.Item("thisPoint")) = False Then
  '        mThisPoint = .Item("thisPoint")
  '        mUsePoint = .Item("usePoint")
  '        mRemainPoint = .Item("remainPoint")
  '      End If

  '      mSubTotal = mGoodAmou * mUnitPrice
  '      mTotalPrice += mSubTotal
  '      mTotalDisc += mSubDisc
  '      ' จำนวน
  '      mLineNo = mLineNo + 1
  '      mRowPos += mLineSpace15
  '      mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
  '      mAlign.Alignment = StringAlignment.Near
  '      mText = mGoodAmou & " " & mUnitDesc
  '      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '      ' ชื่อสินค้า
  '      mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
  '      mAlign.Alignment = StringAlignment.Near
  '      mText = mGoodName
  '      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '      ' ราคาขาย
  '      mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
  '      mAlign.Alignment = StringAlignment.Far
  '      mText = Format(mSubTotal, "#,##0.00")
  '      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '      ' แสดงส่วนลดของสินค้าแต่ละตัวที่ได้ลด
  '      If mSubDisc > 0 Then
  '        ' จำนวน
  '        mLineNo = mLineNo + 1
  '        mRowPos += mLineSpace15
  '        mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
  '        mAlign.Alignment = StringAlignment.Near
  '        mText = "1"
  '        e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '        ' ชื่อสินค้า
  '        mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
  '        mAlign.Alignment = StringAlignment.Near
  '        mText = "ส่วนลด " & mGoodName
  '        e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '        ' ส่วนลด
  '        mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
  '        mAlign.Alignment = StringAlignment.Far
  '        mText = Format(-mSubDisc, "#,##0.00")
  '        e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '      End If
  '    End With
  '  Next

  '  ' ส่วนลดจากแต้ม
  '  If mPointDisc > 0 Then
  '    ' จำนวน
  '    mLineNo = mLineNo + 1
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "1"
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' ส่วนลด
  '    mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "ส่วนลดจากแต้ม"
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' ยอดเงิน
  '    mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Far
  '    mText = Format(-mPointDisc, "#,##0.00") '-mPointDisc.ToString("#,##0.00")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  End If
  '  ' --------
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = StrDup(80, "-")
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  ' ยอดสินค้าสุทธิ (หลังหักส่วนลด)
  '  mTotalNet = mTotalPrice - mTotalDisc - mPointDisc
  '  ' จำนวนเงินรวมทั้งสิ้น
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = "จำนวนเงินรวมทั้งสิ้น"
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '  mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Far
  '  mText = Format(mTotalNet, "#,##0.00")
  '  e.Graphics.DrawString(mText, prnFontNormalBold, Brushes.Black, mRect, mAlign)

  '  ' ประเภทการชำระเงิน
  '  For i As Integer = 0 To dvPaid.Count - 1
  '    With dvPaid.Item(i)
  '      If .Item("cardCode") <> "" And .Item("cardCode") <> "0" Then
  '        mLineNo = mLineNo + 1
  '        mRowPos += mLineSpace15
  '        mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
  '        mAlign.Alignment = StringAlignment.Near
  '        mText = "ชำระ " & .Item("cardName")
  '        e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '        mAlign.Alignment = StringAlignment.Far
  '        mText = MyVal(.Item("payAmou")).ToString("#,##0.00")
  '        e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '      End If
  '    End With
  '  Next

  '  ' ชำระเงินสด
  '  If mTotalCashPay > 0 Then
  '    mLineNo = mLineNo + 1
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "ชำระ เงินสด"
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Far
  '    mText = mTotalCashPay.ToString("#,##0.00")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' เงินทอน
  '    mLineNo = mLineNo + 1
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "เงินทอน"
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Far
  '    mText = mTotalChange.ToString("#,##0.00")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  End If

  '  ' แสดงแต้ม เฉพาะสมาชิก HUG Club ********
  '  If mCustTypeCode = "6" Then
  '    ' --------
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = StrDup(80, "-")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' รหัสสมาชิก
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "สมาชิก " & mCustName & " [" & mCustCode & "]"
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' แต้มที่ได้ครั้งนี้
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "HUG Points (ครั้งนี้) " & Format(mThisPoint, "#,##0")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' แต้มที่ใช้
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "HUG Points (ใช้เป็นส่วนลด) " & Format(mUsePoint, "#,##0")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' แต้มสะสม
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "HUG Points (สะสม) " & Format(mRemainPoint + mThisPoint, "#,##0")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  End If
  '  ' ***************
  '  ' สิทธิ์แลกซื้อ
  '  Dim mGet() As String
  '  mGet = pService.GetData("Drug", "Select bxAmou, bxCode, expireDate from BuyExchangeInfo where issueSaleNumb = '" & mSaleNumb & "'")
  '  If mGet(0) = "1" Then
  '    mRowPos = mRowPos + 15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = mGet(1) & " สิทธิ์แลกซื้อ [" & mGet(2) & "]" & " ใช้ได้ถึง " & mGet(3)
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  End If

  '  ' --------
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = StrDup(80, "-")
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  ' พนักงาน
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = "พนักงานขาย " & RemoveNickName(mEmplName)
  '  e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
  '  ' Cashier
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = "ผู้รับเงิน " & RemoveNickName(mCashName)
  '  e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)

  '  ' ท้ายเอกสาร 1
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = "ขอสงวนสิทธิ์ในการรับเปลี่ยน/คืนสินค้า หากไม่มีใบเสร็จรับเงินมาแสดง"
  '  e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
  '  ' VAT INCLUDED
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Center
  '  mText = "**** VAT INCLUDED ****"
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  'End Sub

  Private Sub tbnSaleReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnSaleReturn.Click
    If lblSaleNumb.Text <> "" Then
      frmSaleReturnTest.pSaleNumb = lblSaleNumb.Text
      frmSaleReturnTest.ShowDialog()
      frmSaleReturn = Nothing
    End If
  End Sub
End Class