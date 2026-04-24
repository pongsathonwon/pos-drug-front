Public Class frmRequTran

  Public pOk As Boolean
  Dim mGoodCode As String
  Dim mUnitCostField As String
  Dim mUnitCost As Double
  Dim mRequNumb As String

  Private Sub frmRequTran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Icon = frmMain.Icon
    txtToBranchName.Text = pBranchName
    pOk = False
    mUnitCostField = "unitCost" & pBranchCode
  End Sub

  Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBranchCode.KeyPress, txtBarcode.KeyPress, txtGoodAmou.KeyPress, txtEmplCode.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub txtBranchCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBranchCode.LostFocus
    If txtBranchCode.Text <> "" Then
      Dim mGet() As String
      mGet = pService.GetData("Drug", "Select branchName from BranchInfo where branchCode = '" & txtBranchCode.Text & "' and  branchStat <> '0' and branchIndex > -2 and branchCode <> '" & pBranchCode & "'")
      If mGet(0) = "1" Then
        txtFromBranchName.Text = mGet(1)
      Else
        pMessageBox = New MyMessageBox("ไม่มีข้อมูลสาขา", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        pMessageBox.ShowDialog()
        txtBranchCode.Text = ""
        txtFromBranchName.Text = ""
        txtBranchCode.Focus()
      End If
    Else
      txtFromBranchName.Text = ""
    End If
  End Sub

  Private Sub txtEmplCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmplCode.LostFocus
    If txtEmplCode.Text <> "" Then
      Dim mGet() As String
      mGet = pService.GetData("Drug", "Select emplName from EmplInfo where emplCode = '" & txtEmplCode.Text & "' and  emplStat <> '0' and branchCode = '" & pBranchCode & "'")
      If mGet(0) = "1" Then
        txtEmplName.Text = mGet(1)
      Else
        pMessageBox = New MyMessageBox("ไม่มีข้อมูลพนักงาน", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        pMessageBox.ShowDialog()
        txtEmplCode.Text = ""
        txtEmplName.Text = ""
        txtEmplCode.Focus()
      End If
    Else
      txtEmplName.Text = ""
    End If
  End Sub

  Private Sub txtBarcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.LostFocus
    If txtBarcode.Text <> "" Then
      ShowGood(txtBarcode.Text)
    End If
  End Sub

  Private Sub txtBarcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.TextChanged
    If txtBarcode.Text.Length > 1 Then
      Select Case Mid(txtBarcode.Text, txtBarcode.Text.Length, 1)
        Case "+" ' ถ้าตัวอักษรท้ายเป็น + แสดงว่าต้องการค้นหารหัส barcode
          Dim mPreName As String
          ' แปลงตัวเลขเป็นตัวอักษร
          mPreName = NumbToChar(Mid(txtBarcode.Text, 1, txtBarcode.Text.Length - 1))
          txtBarcode.Text = ""

          frmGoodSearch.pPreName = mPreName
          frmGoodSearch.ShowDialog()
          If frmGoodSearch.pOk = True Then
            txtBarcode.Focus()
            txtBarcode.Text = frmGoodSearch.pBarcode
            SendKeys.Send("{Enter}")
          End If
        Case "-" ' ถ้าตัวอักษรท้ายเป็น - ให้เปิดหน้าต่างค้นหาตามชื่อ
          Dim mText As String
          mText = Mid(txtBarcode.Text, 1, txtBarcode.Text.Length - 1)
          txtBarcode.Text = ""

          frmGoodSearch.pPreName = mText
          frmGoodSearch.ShowDialog()
          If frmGoodSearch.pOk = True Then
            txtBarcode.Focus()
            txtBarcode.Text = frmGoodSearch.pBarcode
            SendKeys.Send("{Enter}")
          End If
      End Select
    End If
  End Sub

  Private Sub ShowGood(ByVal Barcode As String)
    If Barcode <> "" Then
      Dim mGet() As String
      'mGet = pService.GetData("Drug", "Select GI.goodCode, GI.goodName, UI.unitDesc, GI." & mUnitCostField & " from GoodInfo GI inner join UnitInfo UI on UI.unitCode = GI.unitCode where barCode = '" & Barcode & "' and goodStat <> '0'")
      mGet = pService.GetData("Drug", "Select GI.goodCode, GI.goodName, UI.unitDesc, GI." & mUnitCostField & " from GoodInfo GI inner join UnitInfo UI on UI.unitCode = GI.unitCode inner join GoodBarcode GB on GB.goodCode = GI.goodCode where GB.barCode = '" & Barcode & "' and GB.goodAmou = 1 and GI.goodStat <> '0'")
      If mGet(0) = "1" Then
        mGoodCode = mGet(1)
        txtGoodName.Text = mGet(2)
        lblUnitDesc.Text = mGet(3)
        mUnitCost = mGet(4)
      Else
        pMessageBox = New MyMessageBox("ไม่พบข้อมูลสินค้า", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        pMessageBox.ShowDialog()
        ClearGoodField()
        txtBarcode.Focus()
      End If
    End If
  End Sub

  Private Sub btnGoodSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoodSearch.Click
    frmGoodSearch.ShowDialog()
    If frmGoodSearch.pOk = True Then
      txtBarcode.Text = frmGoodSearch.pBarcode
      ShowGood(txtBarcode.Text)
      txtGoodAmou.Focus()
    End If
  End Sub

  Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    If txtBarcode.Text <> "" Then
      If Val(txtGoodAmou.Text) <= 0 Then
        pMessageBox = New MyMessageBox("กรุณาป้อนจำนวนสินค้า", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        pMessageBox.ShowDialog()
        Exit Sub
      End If

      dtgList.Rows.Add()
      dtgList.Item("barCode", dtgList.Rows.Count - 1).Value = txtBarcode.Text
      dtgList.Item("goodCode", dtgList.Rows.Count - 1).Value = mGoodCode
      dtgList.Item("goodName", dtgList.Rows.Count - 1).Value = txtGoodName.Text
      dtgList.Item("goodAmou", dtgList.Rows.Count - 1).Value = CInt(Val(txtGoodAmou.Text))
      dtgList.Item("unitDesc", dtgList.Rows.Count - 1).Value = lblUnitDesc.Text
      dtgList.Item("unitCost", dtgList.Rows.Count - 1).Value = mUnitCost
      dtgList.ClearSelection()

      ClearGoodField()
      txtBarcode.Focus()
    End If
  End Sub

  Private Sub ClearGoodField()
    mGoodCode = ""
    mUnitCost = 0
    txtBarcode.Text = ""
    txtGoodName.Text = ""
    txtGoodAmou.Text = ""
    lblUnitDesc.Text = "หน่วย"
  End Sub

  Private Sub tbnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnSave.Click
    If dtgList.Rows.Count > 0 Then
      If txtBranchCode.Text = "" Then
        pMessageBox = New MyMessageBox("กรุณาป้อนรหัสจากสาขา", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        pMessageBox.ShowDialog()
        Exit Sub
      End If

      If txtEmplCode.Text = "" Then
        pMessageBox = New MyMessageBox("กรุณาป้อนรหัสผู้ขอโอน", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        pMessageBox.ShowDialog()
        Exit Sub
      End If

      pMessageBox = New MyMessageBox("ยืนยันออกใบขอโอนสินค้า", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
      If pMessageBox.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
        Exit Sub
      End If

      ' เลขที่ใบขอโอน
      Dim mGet() As String
      mGet = pService.GetData("Drug", "Select branchIndex, requNumb from BranchInfo where branchCode = '" & pBranchCode & "'")
      If mGet(0) = "1" Then
        mRequNumb = "RQ" & Mid(1000 + Val(mGet(1)), 2, 3) & Mid(10000 + Val(mGet(2)), 2, 4)
      Else
        MessageBox.Show(mGet(1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      End If

      Dim mSqlText(dtgList.Rows.Count + 2) As String
      Dim mLine As Integer = 0

      pServerDateTime = pService.ServerDateTime

      mSqlText(mLine) = "Insert into RequTranMast (requNumb, requDate, fromBranchCode, toBranchCode, requEmplCode) values ('" & mRequNumb & "', '" & MDYStr(pServerDateTime.Date) & "', '" & txtBranchCode.Text & "', '" & pBranchCode & "', '" & txtEmplCode.Text & "')"
      mLine += 1

      mSqlText(mLine) = "Update BranchInfo set requNumb = requNumb + 1 where branchCode = '" & pBranchCode & "'"
      mLine += 1

      For Each mRow As DataGridViewRow In dtgList.Rows
        mSqlText(mLine) = "Insert into RequTranList (requNumb, goodCode, goodAmou, unitCost) values ('" & mRequNumb & "', '" & dtgList.Item("goodCode", mRow.Index).Value & "', " & dtgList.Item("goodAmou", mRow.Index).Value & ", 0)"
        mLine += 1
      Next

      Dim mUpdate As String
      mUpdate = pService.UpdateData("Drug", mSqlText)
      If mUpdate = "1" Then
        pdc1.Print()
        pOk = True
        Me.Close()
      Else
        pMessageBox = New MyMessageBox(mUpdate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        pMessageBox.ShowDialog()
      End If
    End If
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
    mText = "ใบขอโอนสินค้า"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' เลขที่
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "เลขที่ " & mRequNumb
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' วันที่-เวลา
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = pServerDateTime.ToString("dd'/'MM'/'yy  HH:mm")
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' จากสาขา
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "จาก " & txtFromBranchName.Text
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' --------
    mRect = New RectangleF(mLeftMargin, mRowPos + 15, 255.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    Dim mGoodAmou As Integer
    Dim mGoodName As String
    Dim mUnitDesc As String
    Dim mBarcode As String

    For Each row As DataGridViewRow In dtgList.Rows
      mGoodName = dtgList.Item("goodName", row.Index).Value
      mGoodAmou = dtgList.Item("goodAmou", row.Index).Value
      mBarcode = dtgList.Item("barCode", row.Index).Value
      mUnitDesc = dtgList.Item("unitDesc", row.Index).Value
      ' รายการ
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 160.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = mGoodName ' & "-" & mBarcode
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' จำนวน
      mRect = New RectangleF(165, mRowPos, 30.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mGoodAmou
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' หน่วย
      mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mUnitDesc
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    Next
    ' เพิ่มบรรทัดว่าง ให้ครบ 10 บรรทัด
    If dtgList.Rows.Count < 10 Then
      For i As Integer = 1 To 10 - dtgList.Rows.Count
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = ""
        e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      Next
    End If
    ' --------
    mRowPos += 15
    mRect = New RectangleF(mLeftMargin, mRowPos, 255.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' ผู้ขอโอน
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace + 15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ผู้ขอโอน " & txtEmplName.Text
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    pdc1.Print()
  End Sub
End Class