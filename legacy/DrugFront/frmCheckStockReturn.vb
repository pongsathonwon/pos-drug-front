Public Class frmCheckStockReturn

  Dim mStatus As String

  Private Sub frmCheckStockReturn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    dtpFrom.Value = Now.Date
    dtpTo.Value = Now.Date

    Call ClearAll()

    CheckPriv()
  End Sub

  Private Sub CheckPriv()
    ' Cancel
    If InStr(pUserPriv, Me.Tag.ToString & "C") > 0 Then
      tbnCancel.Enabled = True
    Else
      tbnCancel.Enabled = False
    End If
    ' Print
    If InStr(pUserPriv, Me.Tag.ToString & "P") > 0 Then
      tbnPrint.Enabled = True
    Else
      tbnPrint.Enabled = False
    End If
  End Sub

  Private Sub ShowStockReturn()
    ClearAll()

    'Dim mFromDate, mToDate As Date
    '' วันแรกของเดือน
    'mFromDate = CDate("01/" & Month(dtpReturn.Value) & "/" & Year(dtpReturn.Value))
    '' หาวันสุดท้ายของเดือน
    'Dim mDay As String
    'mDay = Date.DaysInMonth(dtpReturn.Value.Year, dtpReturn.Value.Month).ToString
    'mToDate = CDate(mDay & "/" & Month(dtpReturn.Value) & "/" & Year(dtpReturn.Value))

    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "SELECT HR.retuNumb, HR.retuDate, HR.retuStat, EI.emplName FROM HistBranchReturn HR INNER JOIN EmplInfo EI ON HR.emplCode = EI.emplCode WHERE HR.retuDate > = '" & MDYStr(dtpFrom.Value) & "' AND HR.retuDate <= '" & MDYStr(dtpTo.Value) & "' AND HR.branchCode = '" & pBranchCode & "' ORDER BY HR.retuNumb")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        For i As Integer = 0 To dv.Count - 1
          With dv.Item(i)
            dtgHistReturn.Rows.Add()
            dtgHistReturn.Item("RetuDate", dtgHistReturn.Rows.Count - 1).Value = CDate(.Item("retuDate"))
            dtgHistReturn.Item("RetuNumb", dtgHistReturn.Rows.Count - 1).Value = .Item("retuNumb").ToString
            dtgHistReturn.Item("EmplName", dtgHistReturn.Rows.Count - 1).Value = .Item("emplName").ToString
            dtgHistReturn.Item("RetuStat", dtgHistReturn.Rows.Count - 1).Value = .Item("retuStat").ToString
            If .Item("retuStat").ToString = "0" Then
              dtgHistReturn.Rows(dtgHistReturn.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Red
            End If
            Select Case .Item("retuStat").ToString
              Case "1"
                dtgHistReturn.Item("statText", dtgHistReturn.Rows.Count - 1).Value = "รอรับคืน"
              Case "2"
                dtgHistReturn.Item("statText", dtgHistReturn.Rows.Count - 1).Value = "คลังตรวจรับแล้ว"
              Case "0"
                dtgHistReturn.Item("statText", dtgHistReturn.Rows.Count - 1).Value = "ยกเลิกส่งคืน"
            End Select
          End With
        Next
        dtgHistReturn.ClearSelection()
      End If
      dv = Nothing
    End If
    ds = Nothing
  End Sub

  Private Sub ClearAll()
    dtgHistReturn.Rows.Clear()
    dtgReturnList.Rows.Clear()
    lblRetuNumb.Text = ""
    lblRetuDate.Text = ""
    lblEmplName.Text = ""
    lblCancel.Visible = False
    txtTotal.Text = ""
  End Sub

  Private Sub dtgHistReturn_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgHistReturn.CellDoubleClick
    If e.RowIndex < 0 Then
      Exit Sub
    End If

    Me.Cursor = Cursors.WaitCursor

    lblRetuNumb.Text = dtgHistReturn.Item("RetuNumb", e.RowIndex).Value.ToString
    lblRetuDate.Text = Format(dtgHistReturn.Item("RetuDate", e.RowIndex).Value, "dd/MM/yyyy")
    lblEmplName.Text = dtgHistReturn.Item("EmplName", e.RowIndex).Value.ToString
    mStatus = dtgHistReturn.Item("RetuStat", e.RowIndex).Value.ToString
    If mStatus = "0" Then ' ยกเลิก
      lblCancel.Visible = True
    Else
      lblCancel.Visible = False
    End If

    Dim ds As New DataSet
    Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
    Dim mPriceField As String = "price" & pBranchPrice
    Dim mSqlText As String

    mSqlText = "SELECT BL.*, GI.barCode, GI.goodName, UI.unitDesc, GI.noBranchStock, GI." & mStockOnhandField & " FROM BranchReturnList BL INNER JOIN GoodInfo GI ON BL.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON BL.unitCode = UI.unitCode WHERE BL.retuNumb = '" & dtgHistReturn.Item("RetuNumb", e.RowIndex).Value.ToString & "' ORDER BY GI.goodName"

    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      dtgReturnList.Rows.Clear()
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        For i As Integer = 0 To dv.Count - 1
          dtgReturnList.Rows.Add()
          With dv.Item(i)
            dtgReturnList.Item("Item", i).Value = (i + 1).ToString
            dtgReturnList.Item("goodName", dtgReturnList.Rows.Count - 1).Value = .Item("goodName")
            dtgReturnList.Item("barCode", dtgReturnList.Rows.Count - 1).Value = .Item("barCode")
            dtgReturnList.Item("goodAmou", dtgReturnList.Rows.Count - 1).Value = .Item("goodAmou")
            dtgReturnList.Item("unitDesc", dtgReturnList.Rows.Count - 1).Value = .Item("unitDesc")
            dtgReturnList.Item("GoodCode", dtgReturnList.Rows.Count - 1).Value = .Item("goodCode")
            dtgReturnList.Item("StockOnhand", dtgReturnList.Rows.Count - 1).Value = .Item(mStockOnhandField)
            dtgReturnList.Item("NoBranchStock", dtgReturnList.Rows.Count - 1).Value = .Item("noBranchStock")
            dtgReturnList.Item("lotNo", dtgReturnList.Rows.Count - 1).Value = .Item("lotNo")
            dtgReturnList.Item("expiDate", dtgReturnList.Rows.Count - 1).Value = .Item("expiDate")
            dtgReturnList.Item("retuRema", dtgReturnList.Rows.Count - 1).Value = .Item("retuRema")
            ' คำนวณเงิน เฉพาะรายการที่ไม่ใช่คืนเพราะคลังส่งเกิน
            If InStr(.Item("retuRema"), "ส่งเกิน") <= 0 Then
              dtgReturnList.Item("subTotal", dtgReturnList.Rows.Count - 1).Value = CInt(.Item("goodAmou") * CDbl(.Item("unitPrice")))
            Else
              dtgReturnList.Item("subTotal", dtgReturnList.Rows.Count - 1).Value = 0
            End If

            Select Case .Item("retuStat")
              Case "1"
                dtgReturnList.Item("retuStatText", dtgReturnList.Rows.Count - 1).Value = ""
              Case "2"
                dtgReturnList.Item("retuStatText", dtgReturnList.Rows.Count - 1).Value = "รับคืน"
              Case "4"
                dtgReturnList.Item("retuStatText", dtgReturnList.Rows.Count - 1).Value = "ไม่รับคืน"
            End Select
            'mGet = pService.GetData("Drug", "Select barCode, " & mPriceField & " From GoodBarcode where goodCode = '" & .Item("goodCode").ToString & "' and goodAmou = 1 and unitCode = '" & .Item("unitCode").ToString & "'")
            'mGet = pService.GetData("Drug", "Select barCode From GoodBarcode where goodCode = '" & .Item("goodCode").ToString & "' and goodAmou = 1 and unitCode = '" & .Item("unitCode").ToString & "'")
            'If mGet(0) = "1" Then
            '  dtgReturnList.Item("barCode", dtgReturnList.Rows.Count - 1).Value = mGet(1)
            '  dtgReturnList.Item("subTotal", dtgReturnList.Rows.Count - 1).Value = CInt(.Item("goodAmou") * CDbl(mGet(2)))
            'Else
            '  dtgReturnList.Item("barCode", dtgReturnList.Rows.Count - 1).Value = "???"
            '  dtgReturnList.Item("subTotal", dtgReturnList.Rows.Count - 1).Value = 0
            'End If
          End With
        Next
        dtgReturnList.ClearSelection()
      End If
      dv = Nothing
    End If
    ds = Nothing

    ' total
    Dim mTotal As Double = 0
    For Each mRow As DataGridViewRow In dtgReturnList.Rows
      mTotal += CDbl(dtgReturnList.Item("subTotal", mRow.Index).Value)
    Next
    txtTotal.Text = mTotal.ToString("#,##0")

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub tbnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnCancel.Click
    If lblCancel.Visible = True Then
      Exit Sub
    End If

    If mStatus <> "1" Then
      pMessageBox = New MyMessageBox("สินค้าคลังรับคืนแล้ว ไม่สามารถยกเลิกได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      pMessageBox.ShowDialog()
      Exit Sub
    End If

    ' Level 2 and 3 Only
    If InStr(pUserPriv, "LEVEL2") = 0 AndAlso InStr(pUserPriv, "LEVEL3") = 0 Then
      Dim fPass As New frmPass
      fPass.ShowDialog()
      If fPass.pOK = True Then
        If InStr(fPass.pPassPriv, "LEVEL2") = 0 AndAlso InStr(fPass.pPassPriv, "LEVEL3") = 0 Then
          pMessageBox = New MyMessageBox("ท่านไม่ได้รับอนุญาตให้เข้าใช้งาน", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
          pMessageBox.ShowDialog()
          Exit Sub
        End If
      Else
        Exit Sub
      End If
    End If

    pMessageBox = New MyMessageBox("ยืนยันยกเลิกใบส่งคืนสินค้า", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
    If pMessageBox.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
      Exit Sub
    End If

    ' ใช้วันที่และเวลาของ server
    pServerDateTime = pService.ServerDateTime

    Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
    Dim mSqlText(dtgReturnList.Rows.Count * 3 + 1) As String
    Dim mLine As Integer = 0
    mSqlText(mLine) = "UPDATE HistBranchReturn SET retuStat = '0' WHERE retuNumb = '" & lblRetuNumb.Text & "'"
    mLine += 1

    Dim mGoodCode As String
    Dim mGoodAmou As Integer
    Dim mStockOnhand As Integer

    For i As Integer = 0 To dtgReturnList.Rows.Count - 1
      With dtgReturnList
        mGoodCode = .Item("goodCode", i).Value
        mGoodAmou = Val(.Item("goodAmou", i).Value)
        mStockOnhand = GetStockOnhand(mGoodCode, mStockOnhandField)

        ' ตัดสต๊อค ยกเว้นเป็นสินค้าที่ไม่เก็บสต๊อค และไม่ใช่สินค้าส่งเกิน
        If .Item("noBranchStock", i).Value.ToString = "0" And InStr(.Item("retuRema", i).Value, "ส่งเกิน") <= 0 Then
          mSqlText(mLine) = "UPDATE GoodInfo set " & mStockOnhandField & " = " & mStockOnhandField & " + " & CInt(.Item("goodAmou", i).Value) & " WHERE goodCode = '" & .Item("goodCode", i).Value.ToString & "'"
          mLine += 1

          ' Front card
          mSqlText(mLine) = "Insert into FrontCard (stockDate, stockTime, workType, branchCode, docNumb, emplName, goodCode, goodAmou, stockOnhand) Values ('" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', 'CRT', '" & pBranchCode & "', '" & lblRetuNumb.Text & "', '" & Mid(pUserName, 1, 10) & "', '" & .Item("goodCode", i).Value & "', " & CInt(.Item("goodAmou", i).Value) & ", " & mStockOnhand + CInt(.Item("goodAmou", i).Value) & ")"
          mLine += 1
        End If
      End With
    Next

    Dim mUpdate As String
    mUpdate = pService.UpdateData("Drug", mSqlText)
    If mUpdate = "1" Then
      pMessageBox = New MyMessageBox("ยกเลิกใบส่งคืนสินค้าเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      pMessageBox.ShowDialog()
      ClearAll()
      ShowStockReturn()
    Else
      MessageBox.Show(mUpdate, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End If
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
    mText = "ใบส่งคืนสินค้า เลขที่ " & lblRetuNumb.Text
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' วันที่-เวลา
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = lblRetuDate.Text
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' --------
    mRowPos = mLineNo * 33
    mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    For i As Integer = 0 To dtgReturnList.Rows.Count - 1
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
      mText = dtgReturnList.Item("goodName", i).Value.ToString
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' จำนวน
      mRect = New RectangleF(170, mRowPos, 35.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = Format(dtgReturnList.Item("goodAmou", i).Value, "#,##0")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' หน่วย
      mRect = New RectangleF(210, mRowPos, 45.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = dtgReturnList.Item("unitDesc", i).Value.ToString
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' หมายเหตุ
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = ""
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
    mText = "ผู้คืน : " & lblEmplName.Text
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
  End Sub

  Private Sub tbnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnPrint.Click
    If lblRetuNumb.Text <> String.Empty Then
      pdc1.Print()
    End If
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    ShowStockReturn()
  End Sub
End Class