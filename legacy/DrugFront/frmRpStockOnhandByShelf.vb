Public Class frmRpStockOnhandByShelf

  Dim mShelfNoField As String
  Dim mStockOnhandField As String
  Dim mUnitPriceField As String
  Dim mUnitCostField As String

  Private Sub frmRpStockOnhandByShelf_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    Me.WindowState = FormWindowState.Normal
  End Sub

  Private Sub frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    '' เฉพาะสาขาแฟรนไชส์ ให้แสดงคอลัมน์ ทุนต่อหน่วย (เป็นทุนที่บวก % จากทุนจริงแล้ว)
    'If pIsFranchise = "1" Then
    '  dtgList.Columns("unitCostFC").Visible = True
    'Else
    '  dtgList.Columns("unitCostFC").Visible = False
    'End If

    mShelfNoField = "shelfNo" & pBranchCode
    mStockOnhandField = "stockOnhand" & pBranchCode
    mUnitPriceField = "price" & pBranchPrice
    mUnitCostField = "unitCost" & pBranchCode
    ShowShelfNo()
    CheckPriv()
  End Sub

  Private Sub CheckPriv()
    ' Print
    If InStr(pUserPriv, Me.Tag.ToString & "P") > 0 Then
      tbnprint.Enabled = True
    Else
      tbnPrint.Enabled = False
    End If
  End Sub

  Private Sub ShowShelfNo()
    cboShelfNo.Items.Clear()
    'cboShelfNo.Items.Add("ทั้งหมด")
    For i As Integer = 0 To pGoodShelf.Length - 1
      cboShelfNo.Items.Add(pGoodShelf(i).ShelfNo)
    Next
    'cboShelfNo.SelectedIndex = 0

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
  End Sub

  Private Sub ShowList()
    Me.Cursor = Cursors.WaitCursor
    dtgList.Rows.Clear()

    Dim mSqlText As String
    mSqlText = "Select GI.goodCode, GI.goodName, GI." & mStockOnhandField & " as stockOnhand, " & mShelfNoField & " as shelfNo, GI." & mUnitCostField & " as unitCost, UI.unitDesc, GB.barCode, GB.unitPrice, GB.unitPrice1, GI.fcCostFactor From GoodInfo GI inner join UnitInfo UI on UI.unitCode = GI.unitCode left join (SELECT GB.goodCode, GB.barCode, GB.price1 as unitPrice1, GB." & mUnitPriceField & " as unitPrice FROM GoodBarcode GB inner join GoodInfo GI on GI.goodCode = GB.goodCode WHERE GI.unitCode = GB.unitCode and LEN(GB.barCode) = '6' AND GB.goodAmou = 1) GB on GI.goodCode = GB.goodCode where GI.goodStat <> '0'"
    If cboShelfNo.Text <> "ทั้งหมด" Then
      mSqlText = mSqlText & " and " & mShelfNoField & " = '" & cboShelfNo.Text & "'"
    End If

    mSqlText = mSqlText & " order by goodName"

    Dim ds As New DataSet
    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dtgList.Rows.Add()
          dtgList.Item("goodCode", i).Value = .Item("goodCode")
          dtgList.Item("barCode", i).Value = .Item("barCode")
          dtgList.Item("goodName", i).Value = .Item("goodName")
          dtgList.Item("unitDesc", i).Value = .Item("unitDesc")
          dtgList.Item("unitPrice", i).Value = .Item("unitPrice")
          dtgList.Item("unitCostFC", i).Value = .Item("unitCost") * .Item("fcCostFactor")
          dtgList.Item("shelfNo", i).Value = .Item("shelfNo")
          dtgList.Item("stockOnhand", i).Value = .Item("stockOnhand")
        End With
      Next
      dtgList.ClearSelection()
      dv = Nothing
    End If
    ds = Nothing

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub cboShelfNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboShelfNo.SelectedIndexChanged
    ShowList()
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
    mText = "รายงานสต๊อคคงเหลือ"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' ชั้นวาง
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ชั้นวาง " & cboShelfNo.Text
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' วันที่-เวลา
    ' ใช้วันที่และเวลาของ server
    pServerDateTime = pService.ServerDateTime

    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = pServerDateTime.ToString("dd/MM/yyyy  HH:mm")
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' --------
    mRect = New RectangleF(mLeftMargin, mRowPos + 15, 260.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    For Each row As DataGridViewRow In dtgList.Rows
      ' ชื่อสินค้า
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 120.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = dtgList.Item("goodName", row.Index).Value.ToString
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' รหัสสินค้า
      mRect = New RectangleF(mLeftMargin + 120, mRowPos, 50.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = dtgList.Item("barCode", row.Index).Value.ToString
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' หน่วย
      mRect = New RectangleF(mLeftMargin + 170, mRowPos, 50.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = dtgList.Item("unitDesc", row.Index).Value.ToString
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' คงเหลือ
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = Format(dtgList.Item("stockOnhand", row.Index).Value, "#,##0")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    Next
    ' --------
    mRowPos = mRowPos + 15
    mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

  End Sub

  Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnPrint.Click
    If dtgList.Rows.Count > 0 Then
      pdc1.Print()
    End If
  End Sub
End Class