Public Class frmRpAccoGroupClose

  Dim mDate As Date

  Private Sub frmRpAccoGroupClose_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    Me.WindowState = FormWindowState.Normal
  End Sub

  Private Sub frmRpAccoClose_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    mDate = CDate("3/6/2552") ' วันที่เริ่มใช้การคำนวนสรุปแบบใหม่
    dtpFrom.Value = pServerDateTime.Date
    dtpTo.Value = pServerDateTime.Date

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
    ' พิมพ์ใบสรุปส่ง
    If dtgGroup.Rows.Count > 0 Then
      pdc1.Print()
    End If
  End Sub

  Private Sub pdc1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdc1.PrintPage
    Me.Cursor = Cursors.WaitCursor

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
    mText = "รายงานสรุปยอดขายแยกตามกลุ่มสินค้า"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' ตั้งแต่วันที่
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    If dtpFrom.Value = dtpTo.Value Then
      mText = Format(dtpFrom.Value, "dd/MM/yyyy")
    Else
      mText = "วันที่  " & Format(dtpFrom.Value, "dd/MM/yyyy") & "  ถึง  " & Format(dtpTo.Value, "dd/MM/yyyy")
    End If
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' --------
    mRect = New RectangleF(mLeftMargin, mRowPos + 15, 260.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    Dim ds As New DataSet
    Dim mTotal As Double
    Dim mAllTotal As Double = 0
    '' ถ้าพิมพ์รายงานย้อนหลัง หลังวันที่ 3 มิย. 52 ซึ่งเปลี่ยนวิธีการสรุปใหม่ ให้พิมพ์โดยใช้ระบบเดิม
    'If dtpFrom.Value < mDate Then
    '  'รายงานยอดขาย(แยกตามกลุ่มสินค้า)
    '  dtgGroup.Rows.Clear()
    '  ds = pService.SelectData("Drug", "SELECT GR.groupDesc, SUM(((SL.unitPrice * SL.goodAmou - SL.subDisc) - ((SL.unitPrice * SL.goodAmou - SL.subDisc) * HS.totalDisc / HS.totalPrice)) - (((SL.unitPrice * SL.goodAmou - SL.subDisc) - ((SL.unitPrice * SL.goodAmou - SL.subDisc) * HS.totalDisc / totalPrice)) * HS.perCharge)) totalPrice FROM SaleList SL INNER JOIN GoodInfo GI ON SL.goodCode = GI.goodCode INNER JOIN GroupInfo GR ON GI.groupCode = GR.groupCode INNER JOIN HistSale HS ON SL.saleNumb = HS.saleNumb INNER JOIN CustInfo CI ON HS.custCode = CI.custCode INNER JOIN AccoClose AC ON HS.closeNumb = AC.closeNumb WHERE HS.branchCode = '" & pBranchCode & "' AND AC.closeDate >= '" & MDYStr(dtpFrom.Value) & "' AND AC.closeDate <= '" & MDYStr(dtpTo.Value) & "' AND HS.saleStat <> '0' AND CI.custType <> '2' GROUP BY GR.groupDesc")
    '  If IsNothing(ds) = False Then
    '    Dim dvHistSale As New DataView(ds.Tables(0))
    '    Dim mTotalPrice As Double
    '    For i As Integer = 0 To dvHistSale.Count - 1
    '      dtgGroup.Rows.Add()
    '      mTotalPrice = CDbl(Format(dvHistSale.Item(i).Item("totalPrice"), "###0.00"))
    '      dtgGroup.Item("GroupDesc", i).Value = dvHistSale.Item(i).Item("groupdesc")
    '      dtgGroup.Item("TotalPrice", i).Value = mTotalPrice
    '    Next
    '    dvHistSale = Nothing
    '  Else
    '    MessageBox.Show("Error in open sale data", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '  End If
    '  ds = Nothing

    '  ' รายงานสินค้าคืน แยกตามกลุ่มสินค้า
    '  ds = pService.SelectData("Drug", "SELECT GR.groupDesc, SUM(RL.unitPrice * RL.goodAmou) totalPrice FROM ReturnList RL INNER JOIN GoodInfo GI ON RL.goodCode = GI.goodCode INNER JOIN GroupInfo GR ON GI.groupCode = GR.groupCode INNER JOIN HistReturn HR ON RL.returnNumb = HR.returnNumb INNER JOIN AccoClose AC ON HR.closeNumb = AC.closeNumb WHERE HR.branchCode = '" & pBranchCode & "' AND AC.closeDate >= '" & MDYStr(dtpFrom.Value) & "' AND AC.closeDate <= '" & MDYStr(dtpTo.Value) & "' AND HR.returnStat <> '0' GROUP BY GR.groupDesc")
    '  If IsNothing(ds) = False Then
    '    Dim mTotalPrice As Double
    '    Dim dvHistReturn As New DataView(ds.Tables(0))
    '    For i As Integer = 0 To dvHistReturn.Count - 1
    '      For m As Integer = 0 To dtgGroup.Rows.Count - 1
    '        mTotalPrice = CDbl(Format(dvHistReturn.Item(i).Item("totalPrice"), "###0.00"))
    '        If dtgGroup.Item("GroupDesc", m).Value.ToString = dvHistReturn.Item(i).Item("groupDesc").ToString Then
    '          dtgGroup.Item("TotalPrice", m).Value = CDbl(dtgGroup.Item("TotalPrice", m).Value) - mTotalPrice
    '        End If
    '      Next
    '    Next
    '    dvHistReturn = Nothing
    '  Else
    '    MessageBox.Show("Error in open return data", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '  End If
    '  ds = Nothing

    '  For i As Integer = 0 To dtgGroup.Rows.Count - 1
    '    mTotal = CDbl(dtgGroup.Item("TotalPrice", i).Value)

    '    mLineNo = mLineNo + 1
    '    mRowPos = mLineNo * mLineSpace
    '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    '    mAlign.Alignment = StringAlignment.Near
    '    mText = dtgGroup.Item("GroupDesc", i).Value.ToString
    '    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    '    mAlign.Alignment = StringAlignment.Far
    '    mText = mTotal.ToString("#,##0.00") ' CDbl(dtgGroup.Item("TotalPrice", i).Value).ToString("#,##0.00")
    '    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    '    mAllTotal += mTotal
    '  Next
    'Else
    '  ds = pService.SelectData("Drug", "SELECT groupDesc, SUM(totalPrice) AS totalPrice FROM AccoGroupClose WHERE closeDate >= '" & MDYStr(dtpFrom.Value) & "' AND closeDate <= '" & MDYStr(dtpTo.Value) & "' AND branchCode = '" & pBranchCode & "' GROUP BY groupDesc ORDER BY groupDesc")
    '  If IsNothing(ds) = False Then
    '    Dim dv As New DataView(ds.Tables(0))
    '    Dim mGroupDesc As String
    '    For i As Integer = 0 To dv.Count - 1
    '      mTotal = CDbl(dv.Item(i).Item("totalPrice"))
    '      mGroupDesc = dv.Item(i).Item("groupDesc").ToString

    '      mLineNo = mLineNo + 1
    '      mRowPos = mLineNo * mLineSpace
    '      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    '      mAlign.Alignment = StringAlignment.Near
    '      mText = mGroupDesc
    '      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    '      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    '      mAlign.Alignment = StringAlignment.Far
    '      mText = mTotal.ToString("#,##0.00")
    '      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    '      mAllTotal += mTotal
    '    Next

    '  End If
    '  ds = Nothing
    'End If

    For i As Integer = 0 To dtgGroup.Rows.Count - 1
      mTotal = CDbl(dtgGroup.Item("TotalPrice", i).Value)
      ' กลุ่ม
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = dtgGroup.Item("GroupDesc", i).Value.ToString
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      '' %
      'mRect = New RectangleF(120, mRowPos, 50.0F, 20.0F)
      'mAlign.Alignment = StringAlignment.Far
      'mText = Format(dtgGroup.Item("perTotal", i).Value, "#,##0.00") & "%"
      'e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' จำนวนเงิน
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotal.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mAllTotal += mTotal
    Next

    mRowPos = mRowPos + 15
    mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' ยอดรวม
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "รวมทั้งสิ้น"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = (mAllTotal).ToString("#,##0.00")
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' --------
    mRowPos = mRowPos + 15
    mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    Dim ds As New DataSet
    Dim mAllTotal As Double = 0

    Me.Cursor = Cursors.WaitCursor

    ds = pService.SelectData("Drug", "Select groupDesc, sum(totalPrice) as totalPrice from AccoGroupClose where branchCode = '" & pBranchCode & "' and closeDate >= '" & MDYStr(dtpFrom.Value) & "' and closeDate <= '" & MDYStr(dtpTo.Value) & "' group by groupDesc")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      ' เก็บรายการโดยแสดงเป็น 3 กลุ่ม โดยรวมกลุ่ม 3 4 5 6 เป็นกลุ่มเดียวกัน เพื่อพิมพ์ส่ง
      Dim mSum As Double
      mSum = 0
      dtgGroup.Rows.Clear()
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          If .Item("groupDesc").ToString <> "แผนกโปรโมชั่น 1" And .Item("groupDesc").ToString <> "แผนกโปรโมชั่น 2" Then
            mSum = mSum + .Item("totalPrice")
          Else
            dtgGroup.Rows.Add()
            dtgGroup.Item("groupDesc", dtgGroup.Rows.Count - 1).Value = .Item("groupDesc")
            dtgGroup.Item("totalPrice", dtgGroup.Rows.Count - 1).Value = .Item("totalPrice")
          End If
        End With
      Next
      ' เพิ่มรายการสุดท้าย จากการรวมกลุ่ม 3 4 5 6
      dtgGroup.Rows.Add()
      dtgGroup.Item("groupDesc", dtgGroup.Rows.Count - 1).Value = "แผนกโปรโมชั่น 3"
      dtgGroup.Item("totalPrice", dtgGroup.Rows.Count - 1).Value = mSum



      ' แสดงรายการที่พิมพ์ตามกลุ่มทั้งหมด เพื่อให้ดูก่อนพิมพ์เป็น 3 กลุ่ม
      dtgGroup2.Rows.Clear()
      For i As Integer = 0 To dv.Count - 1
        dtgGroup2.Rows.Add()
        dtgGroup2.Item("groupDesc2", i).Value = dv.Item(i).Item("groupDesc")
        dtgGroup2.Item("totalPrice2", i).Value = dv.Item(i).Item("totalPrice")
      Next
      dv = Nothing
    End If
    ds = Nothing

    'ds = pService.SelectData("Drug", "SELECT GR.groupDesc, SUM(((SL.unitPrice * SL.goodAmou - SL.subDisc) - ((SL.unitPrice * SL.goodAmou - SL.subDisc) * HS.totalDisc / HS.totalPrice)) - (((SL.unitPrice * SL.goodAmou - SL.subDisc) - ((SL.unitPrice * SL.goodAmou - SL.subDisc) * HS.totalDisc / totalPrice)) * HS.perCharge)) totalPrice FROM SaleList SL INNER JOIN GoodInfo GI ON SL.goodCode = GI.goodCode INNER JOIN GroupInfo GR ON GI.groupCode = GR.groupCode INNER JOIN HistSale HS ON SL.saleNumb = HS.saleNumb INNER JOIN CustInfo CI ON HS.custCode = CI.custCode INNER JOIN AccoClose AC ON HS.closeNumb = AC.closeNumb WHERE HS.branchCode = '" & pBranchCode & "' AND AC.closeDate >= '" & MDYStr(dtpFrom.Value) & "' AND AC.closeDate <= '" & MDYStr(dtpTo.Value) & "' AND HS.saleStat <> '0' AND CI.custType <> '2' GROUP BY GR.groupDesc")
    'If IsNothing(ds) = False Then
    '  Dim dvHistSale As New DataView(ds.Tables(0))
    '  Dim mTotalPrice As Double
    '  For i As Integer = 0 To dvHistSale.Count - 1
    '    dtgGroup.Rows.Add()
    '    mTotalPrice = CDbl(Format(dvHistSale.Item(i).Item("totalPrice"), "###0.00"))
    '    dtgGroup.Item("GroupDesc", i).Value = dvHistSale.Item(i).Item("groupdesc")
    '    dtgGroup.Item("TotalPrice", i).Value = mTotalPrice
    '  Next
    '  dvHistSale = Nothing
    'Else
    '  MessageBox.Show("Error in open sale data", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    'End If
    'ds = Nothing

    '' รายงานสินค้าคืน แยกตามกลุ่มสินค้า
    'ds = pService.SelectData("Drug", "SELECT GR.groupDesc, SUM(RL.unitPrice * RL.goodAmou) totalPrice FROM ReturnList RL INNER JOIN GoodInfo GI ON RL.goodCode = GI.goodCode INNER JOIN GroupInfo GR ON GI.groupCode = GR.groupCode INNER JOIN HistReturn HR ON RL.returnNumb = HR.returnNumb INNER JOIN AccoClose AC ON HR.closeNumb = AC.closeNumb WHERE HR.branchCode = '" & pBranchCode & "' AND AC.closeDate >= '" & MDYStr(dtpFrom.Value) & "' AND AC.closeDate <= '" & MDYStr(dtpTo.Value) & "' AND HR.returnStat <> '0' GROUP BY GR.groupDesc")
    'If IsNothing(ds) = False Then
    '  Dim mTotalPrice As Double
    '  Dim dvHistReturn As New DataView(ds.Tables(0))
    '  For i As Integer = 0 To dvHistReturn.Count - 1
    '    For m As Integer = 0 To dtgGroup.Rows.Count - 1
    '      mTotalPrice = CDbl(Format(dvHistReturn.Item(i).Item("totalPrice"), "###0.00"))
    '      If dtgGroup.Item("GroupDesc", m).Value.ToString = dvHistReturn.Item(i).Item("groupDesc").ToString Then
    '        dtgGroup.Item("TotalPrice", m).Value = CDbl(dtgGroup.Item("TotalPrice", m).Value) - mTotalPrice
    '      End If
    '    Next
    '  Next
    '  dvHistReturn = Nothing
    'Else
    '  MessageBox.Show("Error in open return data", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    'End If
    'ds = Nothing

    ' คำนวณ %
    Dim mTotal As Double
    ' ยอดรวม
    For Each mRow As DataGridViewRow In dtgGroup2.Rows
      mTotal += dtgGroup2.Item("TotalPrice2", mRow.Index).Value
    Next
    ' %
    For Each mRow As DataGridViewRow In dtgGroup2.Rows
      dtgGroup2.Item("perTotal2", mRow.Index).Value = dtgGroup2.Item("TotalPrice2", mRow.Index).Value * 100 / mTotal
    Next

    Me.Cursor = Cursors.Default
  End Sub
End Class