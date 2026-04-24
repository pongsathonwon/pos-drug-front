Imports CrystalDecisions.Shared

Public Class frmRpGoodNotMove
  Dim mFirstLine, mLastLine As Integer
  Dim mTotalPage As Integer
  Dim mTotalLine As Integer
  Const mLinePerPage As Integer = 30

  Private Sub frmRpGoodNotMove_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    Me.WindowState = FormWindowState.Normal
  End Sub

  Private Sub frmRpGoodNotMove_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    CheckPriv()
  End Sub

  Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    Dim mDay As Integer
    If radNotMove.Checked = True AndAlso Val(txtDay.Text) <= 0 Then
      MessageBox.Show("กรุณาป้อนจำนวนวัน", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
      'Else
      '  mDay = CInt(Val(txtDay.Text))
    End If

    Me.Cursor = Cursors.WaitCursor

    dtgView.Rows.Clear()
    lblSubTotal.Text = "รวมเป็นเงิน"
    txtPage.Text = ""

    Dim mLastSaleField As String = "lastSale" & pBranchCode
    Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
    Dim mUnitCostField As String = "unitCost" & pBranchCode
    Dim mPriceField As String = "price" & pBranchPrice
    Dim mDate As Date
    'mDate = Date.Today.AddDays(-mDay)

    Dim mSqlText As String
    mSqlText = "SELECT GI.goodName, GB.barCode, GI." & mStockOnhandField & " AS goodAmou, UI.unitDesc, GI." & mLastSaleField & " AS lastSale, GI." & mUnitCostField & " AS unitCost, GB." & mPriceField & " As unitPrice FROM GoodInfo GI INNER JOIN (SELECT * FROM GoodBarcode WHERE len(barCode) = 6 AND goodAmou = 1) GB ON GI.goodCode = GB.goodCode INNER JOIN UnitInfo UI ON GI.unitCode = UI.unitCode"

    If radNotMove.Checked = True Then
      ' ใช้วันที่และเวลาของ server
      pServerDateTime = pService.ServerDateTime

      mDay = CInt(Val(txtDay.Text))
      mDate = pServerDateTime.Date.AddDays(-mDay)
      mSqlText = mSqlText & " WHERE GI." & mLastSaleField & " <= '" & MDYStr(mDate) & "'"
    Else
      mSqlText = mSqlText & " WHERE GI." & mLastSaleField & " is null"
    End If

    mSqlText = mSqlText & " AND GI." & mStockOnhandField & " > 0 AND GI.goodStat <> '0' Order by GI.goodName"

    Dim ds As New DataSet
    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        Dim mAllTotal As Double = 0
        Dim mSubTotal As Double = 0
        For i As Integer = 0 To dv.Count - 1
          With dv.Item(i)
            dtgView.Rows.Add()
            dtgView.Item("itemLine", i).Value = i + 1
            dtgView.Item("goodName", i).Value = .Item("goodName")
            dtgView.Item("barCode", i).Value = .Item("barCode")
            dtgView.Item("goodAmou", i).Value = .Item("goodAmou")
            dtgView.Item("unitDesc", i).Value = .Item("unitDesc")
            dtgView.Item("lastSale", i).Value = .Item("lastSale")
            dtgView.Item("unitPrice", i).Value = .Item("unitPrice")
            mSubTotal = CDbl(.Item("unitPrice")) * CInt(.Item("goodAmou"))
            mAllTotal = mAllTotal + mSubTotal
            dtgView.Item("subTotal", i).Value = mSubTotal
          End With
        Next
        lblSubTotal.Text = "รวมเป็นเงิน " & mAllTotal.ToString("#,##0.00")
      Else
        MessageBox.Show("ไม่มีข้อมูล", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
      dv = Nothing
    End If
    ds = Nothing

    mTotalLine = dtgView.Rows.Count
    mTotalPage = CInt(Math.Ceiling(mTotalLine / mLinePerPage)) ' เศษปัดขึ้นเป็นหนึ่งหน้า
    txtPage.Text = "1-" & mTotalPage.ToString

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub pdc1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdc1.PrintPage
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
    mText = "รายการสินค้าที่ไม่มีความเคลื่อนไหว"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' ภายในเงื่อนไข
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "เป็นเวลา " & Val(txtDay.Text).ToString("#,##0") & " วันขึ้นไป"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' วันที่-เวลา
    ' ใช้วันที่และเวลาของ server
    pServerDateTime = pService.ServerDateTime

    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = pServerDateTime.ToString("dd/MM/yyyy  HH:mm")
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' --------
    mRect = New RectangleF(mLeftMargin, mRowPos + 15, 260.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    'For Each row As DataGridViewRow In dtgView.Rows
    '  ' รายการสินค้า
    '  mLineNo = mLineNo + 1
    '  mRowPos = mLineNo * mLineSpace
    '  mRect = New RectangleF(mLeftMargin, mRowPos, 150.0F, 20.0F)
    '  mAlign.Alignment = StringAlignment.Near
    '  mText = dtgView.Item("goodName", row.Index).Value.ToString
    '  e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    '  ' คงเหลือ
    '  mRect = New RectangleF(205, mRowPos, 50.0F, 20.0F)
    '  mAlign.Alignment = StringAlignment.Near
    '  mText = dtgView.Item("goodAmou", row.Index).Value.ToString
    '  e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    '  ' หน่วย
    '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    '  mAlign.Alignment = StringAlignment.Far
    '  mText = dtgView.Item("unitDesc", row.Index).Value.ToString
    '  e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    'Next
    For i As Integer = mFirstLine To mLastLine
      ' รายการสินค้า
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 30.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = i.ToString & "."
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' รายการสินค้า
      mRect = New RectangleF(30, mRowPos, 150.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = dtgView.Item("goodName", i - 1).Value.ToString
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' คงเหลือ
      mRect = New RectangleF(195, mRowPos, 50.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = dtgView.Item("goodAmou", i - 1).Value.ToString
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' หน่วย
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = dtgView.Item("unitDesc", i - 1).Value.ToString
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    Next
    ' --------
    mRowPos = mRowPos + 15
    mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

  End Sub

  Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
    If dtgView.Rows.Count > 0 AndAlso txtPage.Text <> "" Then
      ' ตรวจสอบเลขหน้าที่ต้องการพิมพ์
      Dim mPage() As String
      mPage = txtPage.Text.Split(CChar("-"))

      Dim mFirstPage, mLastPage As Integer
      mFirstPage = CInt(Val(mPage(0)))
      If mFirstPage <= 0 Then
        mFirstPage = 1
      End If
      If mFirstPage > mTotalPage Then
        mFirstPage = mTotalPage
      End If
      ' ถ้าระบุถึงหน้า
      If mPage.Length > 1 Then
        mLastPage = CInt(Val(mPage(1)))
        If mLastPage < mFirstPage Then
          mLastPage = mFirstPage
        End If
        ' ถ้าหน้าสุดท้ายที่ต้องการพิมพ์มากกว่าหน้าทั้งหมดหรือไม่ได้ระบุหน้าสุดท้าย ให้พิมพ์จนหมด
        If mLastPage > mTotalPage Or mPage(1) = "" Then
          mLastPage = mTotalPage
        End If
      Else
        mLastPage = mFirstPage
      End If

      mFirstLine = 0
      mLastLine = 0
      For i As Integer = mFirstPage To mLastPage
        'If i >= mFirstPage AndAlso i <= mLastPage Then
        mFirstLine = (mLinePerPage * (i - 1)) + 1
        mLastLine = mLinePerPage * i
        ' ถ้าบรรทัดสุดท้ายที่คำนวณได้มากกว่าจำนวนบรรทัดจริงทั้งหมด ให้ปรับค่าเท่ากับจำนวนบรรทัดจริง
        If mLastLine > mTotalLine Then
          mLastLine = mTotalLine
        End If
        pdc1.Print()

        'End If
      Next
    End If
  End Sub

  Private Sub CheckPriv()
    ' Print
    If InStr(pUserPriv, Me.Tag.ToString & "P") > 0 Then
      btnPrint.Enabled = True
    Else
      btnPrint.Enabled = False
    End If
  End Sub
End Class