Public Class frmPrintAccoClose

  Dim mTotalCash, mTotalCredit, mTotalDebt, mTotalCupong, mTotalCharge, mTotalDisc, mTotalCashDisc, mTotalCreditDisc, mTotalReturn, mTotalReturnCash, mTotalReturnCredit, mTotalSale, mTotalOver, mTotalExpense, mTotalInDraw, mTotalStart, mTotalMoney, mTotalSend, mAvgSale, mAllTotalCash As Double
  Dim mCloseNumb, mRemark, mCashName, mCloseTime As String
  Dim mCloseDate As Date
  Dim mTotalCust As Integer
  Dim mPrintTitle As String
  Dim mDate As Date

  Private Sub frmRpAccoClose_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    mDate = CDate("3/6/2552") ' วันที่เริ่มใช้การคำนวนสรุปแบบใหม่
    dtpAcco.Value = pServerDateTime.Date

    CheckPriv()
  End Sub

  Private Sub CheckPriv()
    ' Print
    If InStr(pUserPriv, Me.Tag.ToString & "P") > 0 Then
      btnPrint.Enabled = True
    Else
      btnPrint.Enabled = False
    End If
  End Sub

  Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
    Me.Cursor = Cursors.WaitCursor
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "SELECT AC.*, EI.emplName FROM AccoClose AC INNER JOIN EmplInfo EI ON AC.emplCode = EI.emplCode WHERE AC.closeDate = '" & MDYStr(dtpAcco.Value) & "' AND AC.branchCode = '" & pBranchCode & "'")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        For i As Integer = 0 To dv.Count - 1
          With dv.Item(i)
            mCloseNumb = .Item("closeNumb").ToString
            mRemark = .Item("remark").ToString
            mCashName = .Item("emplName").ToString
            mCloseDate = CDate(.Item("closeDate"))
            mCloseTime = .Item("closeTime").ToString
            mTotalCust = CInt(.Item("totalCust"))
            mTotalCash = CDbl(.Item("totalCash"))
            mTotalCredit = CDbl(.Item("totalCredit"))
            mTotalDebt = CDbl(.Item("totalDebt"))
            mTotalCupong = CDbl(.Item("totalCupong"))
            mTotalCharge = CDbl(.Item("totalCharge"))
            mTotalReturn = CDbl(.Item("totalReturn"))
            mTotalDisc = CDbl(.Item("totalDisc"))
            'mTotalCashDisc = CDbl(.Item("totalCashDisc"))
            'mTotalCreditDisc = CDbl(.Item("totalCreditDisc"))
            'mTotalReturnCash = CDbl(.Item("totalReturnCash"))
            'mTotalReturnCredit = CDbl(.Item("totalReturnCredit"))
            mTotalExpense = CDbl(.Item("totalExpense"))
            mTotalInDraw = CDbl(.Item("totalInDraw"))
            mTotalStart = CDbl(.Item("totalStart"))
            mTotalSale = (mTotalCash + mTotalCredit + mTotalDebt + mTotalCupong - mTotalReturn) ' ต้องการไม่หักค่าธรรมเนียม เนื่องจากสาขาโลตัสคิดค่าเช่า fix ไม่ต้องหักเป็น % แล้ว พ.ย. 2561

            'mTotalSale = (mTotalCash + mTotalCredit + mTotalDebt + mTotalCupong - mTotalReturn - mTotalCharge)
            'mTotalSale = (mTotalCash + mTotalCredit - mTotalCharge - mTotalCashDisc - mTotalCreditDisc - mTotalReturnCash - mTotalReturnCredit)
            mTotalSend = mTotalInDraw - mTotalStart
            mTotalOver = mTotalSend - (mTotalCash - mTotalReturn - mTotalExpense)
            'mTotalOver = mTotalSend - (mTotalCash - mTotalReturnCash - mTotalCashDisc - mTotalExpense)
            mAllTotalCash = (mTotalCash - mTotalReturnCash - mTotalCashDisc - mTotalExpense)
            'mTotalOver = mTotalMoney - (mTotalCash - mTotalReturn - mTotalCashDisc - mTotalExpense)
            'mTotalSend = mTotalMoney - mTotalExpense
            If mTotalCust > 0 Then
              mAvgSale = mTotalSale / mTotalCust
            Else
              mAvgSale = 0
            End If
          End With
          mPrintTitle = "1"
          pdc1.Print()
        Next
        dv = Nothing
      End If
    End If
    ds = Nothing

    ' ถ้าพิมพ์ย้อนหลัง หลังวันที่ 3 มิย. 52 ซึ่งเปลี่ยนวิธีการสรุปใหม่ ให้พิมพ์โดยใช้ระบบเดิม
    If dtpAcco.Value < mDate Then
      dtgGroup.Rows.Clear()
      ' รายงานยอดขาย แยกตามกลุ่มสินค้า
      'ds = pService.SelectData("Drug", "SELECT GR.groupDesc, SUM(((SL.unitPrice * SL.goodAmou - SL.subDisc) - ((SL.unitPrice * SL.goodAmou - SL.subDisc) * HS.totalDisc / HS.totalPrice)) - (((SL.unitPrice * SL.goodAmou - SL.subDisc) - ((SL.unitPrice * SL.goodAmou - SL.subDisc) * HS.totalDisc / totalPrice)) * HS.perCharge)) totalPrice FROM SaleList SL INNER JOIN GoodInfo GI ON SL.goodCode = GI.goodCode INNER JOIN GroupInfo GR ON GI.groupCode = GR.groupCode INNER JOIN HistSale HS ON SL.saleNumb = HS.saleNumb INNER JOIN CustInfo CI ON HS.custCode = CI.custCode WHERE HS.branchCode = '" & pBranchCode & "' AND HS.saleDate = '" & MDYStr(dtpAcco.Value) & "' AND HS.saleStat <> '0' AND CI.custType <> '2' GROUP BY GR.groupDesc")
      ds = pService.SelectData("Drug", "SELECT GR.groupDesc, SUM(((SL.unitPrice * SL.goodAmou - SL.subDisc) - ((SL.unitPrice * SL.goodAmou - SL.subDisc) * HS.totalDisc / HS.totalPrice)) - (((SL.unitPrice * SL.goodAmou - SL.subDisc) - ((SL.unitPrice * SL.goodAmou - SL.subDisc) * HS.totalDisc / totalPrice)) * HS.perCharge)) totalPrice FROM SaleList SL INNER JOIN GoodInfo GI ON SL.goodCode = GI.goodCode INNER JOIN GroupInfo GR ON GI.groupCode = GR.groupCode INNER JOIN HistSale HS ON SL.saleNumb = HS.saleNumb INNER JOIN CustInfo CI ON HS.custCode = CI.custCode INNER JOIN AccoClose AC ON HS.closeNumb = AC.closeNumb WHERE HS.branchCode = '" & pBranchCode & "' AND AC.closeDate = '" & MDYStr(dtpAcco.Value) & "' AND HS.saleStat <> '0' AND CI.custType <> '2' GROUP BY GR.groupDesc")
      If IsNothing(ds) = False Then
        Dim dvHistSale As New DataView(ds.Tables(0))
        If dvHistSale.Count > 0 Then
          Dim mTotalPrice As Double
          For i As Integer = 0 To dvHistSale.Count - 1
            dtgGroup.Rows.Add()
            mTotalPrice = CDbl(dvHistSale.Item(i).Item("totalPrice"))
            dtgGroup.Item("GroupDesc", i).Value = dvHistSale.Item(i).Item("groupdesc")
            dtgGroup.Item("TotalPrice", i).Value = mTotalPrice
          Next
          dvHistSale = Nothing
        Else
          MessageBox.Show("ไม่มีข้อมูลสรุปบัญชี", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
          Exit Sub
        End If
      Else
        MessageBox.Show("Error in open sale data", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If

      ds = Nothing

      ' รายงานสินค้าคืน แยกตามกลุ่มสินค้า
      'ds = pService.SelectData("Drug", "SELECT GR.groupDesc, SUM(RL.unitPrice * RL.goodAmou) totalPrice FROM ReturnList RL INNER JOIN GoodInfo GI ON RL.goodCode = GI.goodCode INNER JOIN GroupInfo GR ON GI.groupCode = GR.groupCode INNER JOIN HistReturn HR ON RL.returnNumb = HR.returnNumb WHERE HR.branchCode = '" & pBranchCode & "' AND HR.returnDate = '" & MDYStr(dtpAcco.Value) & "' AND HR.returnStat <> '0' GROUP BY GR.groupDesc")
      ds = pService.SelectData("Drug", "SELECT GR.groupDesc, SUM(RL.unitPrice * RL.goodAmou) totalPrice FROM ReturnList RL INNER JOIN GoodInfo GI ON RL.goodCode = GI.goodCode INNER JOIN GroupInfo GR ON GI.groupCode = GR.groupCode INNER JOIN HistReturn HR ON RL.returnNumb = HR.returnNumb INNER JOIN AccoClose AC ON HR.closeNumb = AC.closeNumb WHERE HR.branchCode = '" & pBranchCode & "' AND AC.closeDate = '" & MDYStr(dtpAcco.Value) & "' AND HR.returnStat <> '0' GROUP BY GR.groupDesc")
      If IsNothing(ds) = False Then
        Dim dvHistReturn As New DataView(ds.Tables(0))
        Dim mTotalPrice As Double
        For i As Integer = 0 To dvHistReturn.Count - 1
          For m As Integer = 0 To dtgGroup.Rows.Count - 1
            mTotalPrice = CDbl(dvHistReturn.Item(i).Item("totalPrice"))
            If dtgGroup.Item("GroupDesc", m).Value.ToString = dvHistReturn.Item(i).Item("groupDesc").ToString Then
              dtgGroup.Item("TotalPrice", m).Value = CDbl(dtgGroup.Item("TotalPrice", m).Value) - mTotalPrice
            End If
          Next
        Next
        dvHistReturn = Nothing
      Else
        MessageBox.Show("Error in open return data", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
      ds = Nothing
    End If

    mPrintTitle = "2"
    pdc1.Print()

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub pdc1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdc1.PrintPage
    Dim prnFont As New Font("CordiaUPC", 12, GraphicsUnit.Point)
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

    Me.Cursor = Cursors.WaitCursor
    ' ยอดสรุปเก็บ
    If mPrintTitle = "1" Then
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
      mText = "ใบสรุปบัญชีประจำวัน"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' วันที่
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = mCloseDate.ToString("dd/MM/yyyy") & "  " & mCloseTime
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' เลขที่
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mCloseNumb
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' ขายเงินสด
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "ขายเงินสด"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotalCash.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' ขายเครดิต
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "ขายเครดิต"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotalCredit.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' ขายเงินเชื่อ
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "ขายเงินเชื่อ"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotalDebt.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' คูปองส่วนลด
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "คูปองส่วนลด"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotalCupong.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' คืนสินค้า
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "คืนสินค้า"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotalReturn.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' ค่าธรรมเนียม
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "ค่าธรรมเนียม"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotalCharge.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' --------
      mRect = New RectangleF(mLeftMargin, mRowPos + 15, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = "-----------------"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' รวมยอดขายจากเครื่อง
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "รวมยอดขายจากเครื่อง"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotalSale.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' --------
      mRect = New RectangleF(mLeftMargin, mRowPos + 15, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = "-----------------"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' ค่าใช้จ่าย
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "ค่าใช้จ่าย"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotalExpense.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' --------
      mRect = New RectangleF(mLeftMargin, mRowPos + 15, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = "-----------------"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' ยอดเงินสดคงเหลือ
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "เงินสดคงเหลือ"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mAllTotalCash.ToString("#,##0.00") ' lblAllTotalCash.Text
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' --------
      mRect = New RectangleF(mLeftMargin, mRowPos + 15, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = "-----------------"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' เงินสดจากการนับ
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "เงินสดจากการนับ"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotalInDraw.ToString("#,##0.00") ' Format(Val(txtTotalInDraw.Text), "#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' เงินต้น
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "เงินต้น"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotalStart.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' --------
      mRect = New RectangleF(mLeftMargin, mRowPos + 15, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = "-----------------"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' เงินนำส่ง
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "เงินนำส่ง"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotalSend.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' --------
      mRect = New RectangleF(mLeftMargin, mRowPos + 15, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = "-----------------"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' ขาด-เกิน
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "ขาด-เกิน"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotalOver.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos + 15, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = "-----------------"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' หมายเหตุ
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "หมายเหตุ : " & mRemark
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      ' จำนวนลูกค้า
      mLineNo = mLineNo + 2
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "จำนวนลูกค้า"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotalCust.ToString("#,##0")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' ขายเฉลี่ย/ใบ
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "ขายเฉลี่ย/ราย"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mAvgSale.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      ' แคชเชียร์
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "แคชเชียร์ : " & pUserName
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    Else ' ยอดสรุปส่ง
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
      mText = "รายงานสรุปยอดขาย"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' วันที่
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Center
      mText = mCloseDate.ToString("dd/MM/yyyy") & "  " & mCloseTime
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos + 15, 260.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "-------------------------------------------------------------------"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      ' ถ้าพิมพ์ย้อนหลัง หลังวันที่ 3 มิย. 52 ซึ่งเปลี่ยนวิธีการสรุปใหม่ ให้พิมพ์โดยใช้ระบบเดิม
      Dim mTotal As Double
      Dim mAllTotal As Double
      If dtpAcco.Value < mDate Then
        For i As Integer = 0 To dtgGroup.Rows.Count - 1
          mTotal = CDbl(dtgGroup.Item("TotalPrice", i).Value)

          mLineNo = mLineNo + 1
          mRowPos = mLineNo * mLineSpace
          mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
          mAlign.Alignment = StringAlignment.Near
          mText = dtgGroup.Item("GroupDesc", i).Value.ToString
          e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

          mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
          mAlign.Alignment = StringAlignment.Far
          mText = mTotal.ToString("#,##0.0000")
          e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

          mAllTotal += mTotal
        Next
      Else
        Dim ds As New DataSet
        ds = pService.SelectData("Drug", "SELECT groupDesc, SUM(totalPrice) AS totalPrice FROM AccoGroupClose WHERE closeDate = '" & MDYStr(dtpAcco.Value) & "' AND branchCode = '" & pBranchCode & "' GROUP BY groupDesc ORDER BY groupDesc")
        If IsNothing(ds) = False Then
          Dim dv As New DataView(ds.Tables(0))
          Dim mGroupDesc As String
          ' พิมพ์แบบใหม่ เริ่ม 9 ต.ค. 2556 โดยรวมกลุ่ม 3 4 5 6 เป็นกลุ่มเดียวกัน โดยนำไปเก็บไว้ใน dtgGroup2 ก่อนพิมพ์
          If dtpAcco.Value >= CDate("9/10/2556") Then
            Dim mSum As Double
            mSum = 0
            dtgGroup2.Rows.Clear()
            For i As Integer = 0 To dv.Count - 1
              With dv.Item(i)
                If .Item("groupDesc").ToString <> "แผนกโปรโมชั่น 1" And .Item("groupDesc").ToString <> "แผนกโปรโมชั่น 2" Then
                  mSum = mSum + .Item("totalPrice")
                Else
                  dtgGroup2.Rows.Add()
                  dtgGroup2.Item("groupDesc2", dtgGroup2.Rows.Count - 1).Value = .Item("groupDesc")
                  dtgGroup2.Item("totalPrice2", dtgGroup2.Rows.Count - 1).Value = .Item("totalPrice")
                End If
              End With
            Next
            ' เพิ่มรายการสุดท้าย จากการรวมกลุ่ม 3 4 5 6
            dtgGroup2.Rows.Add()
            dtgGroup2.Item("groupDesc2", dtgGroup2.Rows.Count - 1).Value = "แผนกโปรโมชั่น 3"
            dtgGroup2.Item("totalPrice2", dtgGroup2.Rows.Count - 1).Value = mSum
            ' นำรายการใน dtgGroup2 ไปพิมพ์
            For Each mRow As DataGridViewRow In dtgGroup2.Rows
              mTotal = CDbl(dtgGroup2.Item("totalPrice2", mRow.Index).Value)
              mGroupDesc = dtgGroup2.Item("groupDesc2", mRow.Index).Value.ToString

              mLineNo = mLineNo + 1
              mRowPos = mLineNo * mLineSpace
              mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
              mAlign.Alignment = StringAlignment.Near
              mText = mGroupDesc
              e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

              mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
              mAlign.Alignment = StringAlignment.Far
              mText = mTotal.ToString("#,##0.0000")
              e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

              mAllTotal += mTotal
            Next
          Else
            ' พิมพ์แบบเดิม แสดงทุกกลุ่ม
            For i As Integer = 0 To dv.Count - 1
              mTotal = CDbl(dv.Item(i).Item("totalPrice"))
              mGroupDesc = dv.Item(i).Item("groupDesc").ToString

              mLineNo = mLineNo + 1
              mRowPos = mLineNo * mLineSpace
              mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
              mAlign.Alignment = StringAlignment.Near
              mText = mGroupDesc
              e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

              mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
              mAlign.Alignment = StringAlignment.Far
              mText = mTotal.ToString("#,##0.0000")
              e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

              mAllTotal += mTotal
            Next
          End If
        End If
        ds = Nothing
      End If

      mRect = New RectangleF(mLeftMargin, mRowPos + 15, 260.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "-------------------------------------------------------------------"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' รวม
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "รวมทั้งสิ้น"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mAllTotal.ToString("#,##0.0000")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos + 15, 260.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "-------------------------------------------------------------------"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    End If
    Me.Cursor = Cursors.Default
  End Sub
End Class