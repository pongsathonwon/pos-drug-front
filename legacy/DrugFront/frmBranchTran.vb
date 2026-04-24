Public Class frmBranchTran

  Dim mRequNumb As String
  Dim mBranchName As String
  Dim mStockOnhandField As String
  Dim mLowerStock As Boolean
  Dim mFromBranchCode As String
  Dim mToBranchCode As String
  Dim mFromStockOnhandField As String
  Dim mToStockOnhandField As String
  Dim mFromUnitCostField As String
  Dim mToUnitCostField As String

  Private Sub frmBranchTran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Icon = frmMain.Icon

    dtpTo.Value = Now.Date
    dtpFrom.Value = Now.Date.AddDays(-30)

    tbnCancel.Enabled = False
    tbnTran.Enabled = False

    ShowRequTran()

    mStockOnhandField = "stockOnhand" & pBranchCode

    CheckPriv()
    'mUnitCostField = "unitCost" & pBranchCode
  End Sub

  Private Sub CheckPriv()
    ' Add
    If InStr(pUserPriv, Me.Tag.ToString & "A") > 0 Then
      tbnRequest.Enabled = True
    Else
      tbnRequest.Enabled = False
    End If
    ' Edit
    If InStr(pUserPriv, Me.Tag.ToString & "E") > 0 Then
      tbnTran.Enabled = True
    Else
      tbnTran.Enabled = False
    End If
    ' Cancel
    If InStr(pUserPriv, Me.Tag.ToString & "C") > 0 Then
      tbnCancel.Enabled = True
    Else
      tbnCancel.Enabled = False
    End If
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    ShowRequTran()
  End Sub

  Private Sub ClearField()
    dtgMast.Rows.Clear()
    dtgList.Rows.Clear()
    txtEmplCode.Text = ""
    txtEmplName.Text = ""
    tbnCancel.Enabled = False
    tbnTran.Enabled = False
  End Sub

  Private Sub ShowRequTran()
    ClearField()

    Dim ds As New DataSet
    Dim mSqlText As String

    mSqlText = "Select RT.*, BI1.branchName as fromBranchName, BI2.branchName as toBranchName, EI1.emplName as requEmplName, EI2.emplName as tranEmplName from RequTranMast RT inner join BranchInfo BI1 on BI1.branchCode = RT.fromBranchCode inner join BranchInfo BI2 on BI2.branchCode = RT.toBranchCode left join EmplInfo EI1 on EI1.emplCode = RT.requEmplCode left join EmplInfo EI2 on EI2.emplCode = RT.tranEmplCode Where (RT.fromBranchCode = '" & pBranchCode & "' or RT.toBranchCode = '" & pBranchCode & "') and (RT.requDate > = '" & MDYStr(dtpFrom.Value) & "' and RT.requDate <= '" & MDYStr(dtpTo.Value) & "')"

    ds = pService.SelectData("Drug", mSqlText)

    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      Dim mRequStatDesc As String
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dtgMast.Rows.Add()
          dtgMast.Item("requNumb", i).Value = .Item("requNumb")
          dtgMast.Item("requDate", i).Value = .Item("requDate")
          dtgMast.Item("fromBranchCode", i).Value = .Item("fromBranchCode")
          dtgMast.Item("toBranchCode", i).Value = .Item("toBranchCode")

          dtgMast.Item("toBranchName", i).Value = .Item("toBranchName")
          dtgMast.Item("fromBranchName", i).Value = .Item("fromBranchName")

          'If .Item("fromBranchCode") = pBranchCode Then
          '  dtgMast.Item("toBranchName", i).Value = .Item("toBranchName")
          '  dtgMast.Item("tranEmplName", i).Value = .Item("tranEmplName")
          'End If

          'If .Item("toBranchCode") = pBranchCode Then
          '  dtgMast.Item("fromBranchName", i).Value = .Item("fromBranchName")
          '  dtgMast.Item("requEmplName", i).Value = .Item("requEmplName")
          'End If

          dtgMast.Item("requEmplName", i).Value = .Item("requEmplName")
          dtgMast.Item("tranEmplName", i).Value = .Item("tranEmplName")

          Select Case .Item("requStat")
            Case "0"
              mRequStatDesc = "ยกเลิก"
            Case "1"
              mRequStatDesc = "อยู่ระหว่าง ขอโอน"
            Case "2"
              mRequStatDesc = "โอนสินค้าเรียบร้อย"
            Case Else
              mRequStatDesc = "???"
          End Select

          dtgMast.Item("requStat", i).Value = .Item("requStat")
          dtgMast.Item("requStatDesc", i).Value = mRequStatDesc
        End With
      Next
      dv = Nothing
      dtgMast.ClearSelection()
    End If
    ds = Nothing
  End Sub

  Private Sub tbnRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnRequest.Click
    frmRequTran.ShowDialog()
    If frmRequTran.pOk = True Then
      ShowRequTran()
    End If
    frmRequTran = Nothing
  End Sub

  Private Sub dtgMast_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgMast.CellClick
    If e.RowIndex < 0 Then
      Exit Sub
    End If

    tbnCancel.Enabled = False
    tbnTran.Enabled = False

    mFromBranchCode = dtgMast.Item("fromBranchCode", e.RowIndex).Value
    mToBranchCode = dtgMast.Item("toBranchCode", e.RowIndex).Value

    mFromStockOnhandField = "stockOnhand" & mFromBranchCode
    mToStockOnhandField = "stockOnhand" & mToBranchCode

    mFromUnitCostField = "unitCost" & mFromBranchCode
    mToUnitCostField = "unitCost" & mToBranchCode

    ' แสดงปุ่มยกเลิก (เฉพาะกรณีที่เป็นใบขอโอนจากสาขาอื่นและสถานะยังอยู่ในระหว่างขอโอน)
    If mToBranchCode = pBranchCode And dtgMast.Item("requStat", e.RowIndex).Value = "1" Then
      tbnCancel.Enabled = True
    End If

    '' แสดงปุ่มรับโอนสินค้า (เฉพาะกรณีที่เป็นใบขอโอนจากสาขาอื่นและสถานะยังอยู่ในระหว่างโอนสินค้า)
    'If dtgMast.Item("toBranchCode", e.RowIndex).Value = pBranchCode And dtgMast.Item("requStat", e.RowIndex).Value = "2" Then
    '  tbnRece.Enabled = True
    'End If

    '' แสดงปุ่มยกเลิก (เฉพาะกรณีที่เป็นใบโอนไปสาขาอื่นและสถานะยังอยู่ในระหว่างโอนสินค้า)
    'If mFromBranchCode = pBranchCode And dtgMast.Item("requStat", e.RowIndex).Value = "2" Then
    '  tbnCancel.Enabled = True
    'End If

    ' แสดงปุ่มอนุมัติโอนสินค้า (เฉพาะกรณีที่เป็นใบโอนไปสาขาอื่นและสถานะยังอยู่ในระหว่างขอโอน)
    If mFromBranchCode = pBranchCode And dtgMast.Item("requStat", e.RowIndex).Value = "1" Then
      tbnTran.Enabled = True
    End If

    dtgList.Rows.Clear()
    mRequNumb = dtgMast.Item("requNumb", e.RowIndex).Value
    mBranchName = dtgMast.Item("toBranchName", e.RowIndex).Value

    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select RL.*, GI.goodName, GI." & mFromStockOnhandField & ", GI." & mToStockOnhandField & ", GI." & mFromUnitCostField & ", GI." & mToUnitCostField & ", UI.unitDesc from RequTranList RL inner join GoodInfo GI on GI.goodCode = RL.goodCode inner join UnitInfo UI on UI.unitCode = GI.unitCode Where RL.requNumb = '" & mRequNumb & "'")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dtgList.Rows.Add()
          dtgList.Item("goodCode", i).Value = .Item("goodCode")
          dtgList.Item("goodName", i).Value = .Item("goodName")
          dtgList.Item("goodAmou", i).Value = .Item("goodAmou")
          dtgList.Item("unitDesc", i).Value = .Item("unitDesc")
          dtgList.Item("fromUnitCost", i).Value = .Item(mFromUnitCostField)
          dtgList.Item("toUnitCost", i).Value = .Item(mToUnitCostField)
          dtgList.Item("fromStockOnhand", i).Value = .Item(mFromStockOnhandField)
          dtgList.Item("toStockOnhand", i).Value = .Item(mToStockOnhandField)
        End With
      Next
      dtgList.ClearSelection()
    End If
    ds = Nothing

    ' แสดงคอลัมน์สต๊อคคงเหลือ เฉพาะใบที่จะโอนให้สาขาอื่น
    If mFromBranchCode = pBranchCode And dtgMast.Item("requStat", e.RowIndex).Value = "1" Then
      dtgList.Columns("fromStockOnhand").Visible = True
    Else
      dtgList.Columns("fromStockOnhand").Visible = False
    End If

    '' ตรวจสอบสต๊อคคงเหลือ (เฉพาะกรณีที่เป็นใบโอนไปสาขาอื่นและสถานะยังอยู่ในระหว่างขอโอน)
    'If mFromBranchCode = pBranchCode And dtgMast.Item("requStat", e.RowIndex).Value = "1" Then
    '  If IsLowerStock() = True Then
    '    pMessageBox = New MyMessageBox("สินค้าไม่เพียงพอต่อการโอน", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    pMessageBox.ShowDialog()
    '  End If
    'End If
  End Sub

  Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmplCode.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
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
    mText = "ใบโอนสินค้า"
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
    mText = "โอนไป " & mBranchName
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' --------
    mRect = New RectangleF(mLeftMargin, mRowPos + 15, 255.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    Dim mGoodAmou As Integer
    Dim mGoodName As String
    Dim mUnitDesc As String

    For Each row As DataGridViewRow In dtgList.Rows
      mGoodName = dtgList.Item("goodName", row.Index).Value
      mGoodAmou = dtgList.Item("goodAmou", row.Index).Value
      mUnitDesc = dtgList.Item("unitDesc", row.Index).Value
      ' รายการ
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 160.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = mGoodName
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
    ' ผู้โอน
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace + 15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ผู้โอน " & txtEmplName.Text
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
  End Sub

  Private Sub tbnTran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnTran.Click
    If dtgList.Rows.Count > 0 Then
      If txtEmplCode.Text = "" Then
        pMessageBox = New MyMessageBox("กรุณาป้อนรหัสผู้โอน", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        pMessageBox.ShowDialog()
        Exit Sub
      End If

      If IsLowerStock() = True Then
        pMessageBox = New MyMessageBox("สินค้าไม่เพียงพอต่อการโอน", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        pMessageBox.ShowDialog()
        Exit Sub
      End If

      pMessageBox = New MyMessageBox("ยืนยันโอนสินค้า", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
      If pMessageBox.ShowDialog = Windows.Forms.DialogResult.Cancel Then
        Exit Sub
      End If

      Dim mSqlText(dtgList.Rows.Count * 7 + 1) As String
      Dim mLine As Integer = 0

      Dim mGoodCode As String
      Dim mGoodAmou As Integer
      Dim mFromUnitCost As Double
      Dim mToUnitCost As Double
      Dim mAvgUnitCost As Double
      Dim mFromStockOnhand As Integer
      Dim mToStockOnhand As Integer

      mFromStockOnhandField = "stockOnhand" & mFromBranchCode
      mToStockOnhandField = "stockOnhand" & mToBranchCode
      mToUnitCostField = "unitCost" & mToBranchCode

      pServerDateTime = pService.ServerDateTime

      For Each mRow As DataGridViewRow In dtgList.Rows
        mGoodCode = dtgList.Item("goodCode", mRow.Index).Value
        mGoodAmou = dtgList.Item("goodAmou", mRow.Index).Value
        mFromUnitCost = dtgList.Item("fromUnitCost", mRow.Index).Value
        mToUnitCost = dtgList.Item("toUnitCost", mRow.Index).Value
        mFromStockOnhand = dtgList.Item("fromStockOnhand", mRow.Index).Value
        mToStockOnhand = dtgList.Item("toStockOnhand", mRow.Index).Value

        ' เก็บราคาทุนจากสาขาที่โอน
        mSqlText(mLine) = "Update RequTranList set unitCost = " & mFromUnitCost & " where requNumb = '" & mRequNumb & "'"
        mLine += 1

        ' ตัดสต๊อคสาขาที่โอน
        mSqlText(mLine) = "Update GoodInfo set " & mFromStockOnhandField & " = " & mFromStockOnhandField & " - " & mGoodAmou & " Where goodCode = '" & mGoodCode & "'"
        mLine += 1

        mSqlText(mLine) = "Insert into FrontCard (stockDate, stockTime, workType, branchCode, docNumb, emplName, goodCode, goodAmou, stockOnhand) Values ('" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', 'BTB', '" & mFromBranchCode & "', '" & mRequNumb & "', '" & Mid(txtEmplName.Text, 1, 10) & "', '" & mGoodCode & "', " & mGoodAmou & ", " & (mFromStockOnhand - mGoodAmou) & ")"
        mLine += 1
        ' เพิ่มสต๊อคสาขาที่รับโอน
        ' ต้นทุนเฉลี่ย
        If mGoodAmou + mToStockOnhand > 0 Then
          mAvgUnitCost = ((mToStockOnhand * mToUnitCost) + (mGoodAmou * mFromUnitCost)) / (mGoodAmou + mToStockOnhand)
        Else
          mAvgUnitCost = mFromUnitCost
        End If

        mSqlText(mLine) = "Update GoodInfo set " & mToStockOnhandField & " = " & mToStockOnhandField & " + " & mGoodAmou & ", " & mToUnitCostField & " = " & mAvgUnitCost & "  Where goodCode = '" & mGoodCode & "'"
        mLine += 1

        mSqlText(mLine) = "Insert into FrontCard (stockDate, stockTime, workType, branchCode, docNumb, emplName, goodCode, goodAmou, stockOnhand) Values ('" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', 'BFB', '" & mToBranchCode & "', '" & mRequNumb & "', '" & Mid(txtEmplName.Text, 1, 10) & "', '" & mGoodCode & "', " & mGoodAmou & ", " & (mToStockOnhand + mGoodAmou) & ")"
        mLine += 1

      Next

      mSqlText(mLine) = "Update RequTranMast set requStat = '2', tranDate = '" & MDYStr(pServerDateTime.Date) & "', tranEmplCode = '" & txtEmplCode.Text & "' where requNumb = '" & mRequNumb & "'"
      mLine += 1

      Dim mUpdate As String
      mUpdate = pService.UpdateData("Drug", mSqlText)
      If mUpdate = "1" Then
        pdc1.Print()

        pMessageBox = New MyMessageBox("โอนสินค้าเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        pMessageBox.ShowDialog()

        ClearField()
        ShowRequTran()
      Else
        pMessageBox = New MyMessageBox(mUpdate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        pMessageBox.ShowDialog()
      End If
    End If
  End Sub

  Private Function IsLowerStock() As Boolean
    Dim mGoodCode As String
    Dim mFromStockOnhand As Integer
    Dim mToStockOnhand As Integer
    Dim mGoodAmou As Integer
    Dim mGet() As String
    mFromStockOnhandField = "stockOnhand" & mFromBranchCode
    mToStockOnhandField = "stockOnhand" & mToBranchCode
    mLowerStock = False

    For Each mRow As DataGridViewRow In dtgList.Rows
      mGoodCode = dtgList.Item("goodCode", mRow.Index).Value
      mGoodAmou = dtgList.Item("goodAmou", mRow.Index).Value

      mGet = pService.GetData("Drug", "Select " & mFromStockOnhandField & " as fromStockOnhand, " & mToStockOnhandField & " as toStockOnhand from GoodInfo where goodCode = '" & mGoodCode & "'")
      If mGet(0) = "1" Then
        mFromStockOnhand = CInt(mGet(1))
        mToStockOnhand = CInt(mGet(2))
        dtgList.Item("fromStockOnhand", mRow.Index).Value = mFromStockOnhand
        dtgList.Item("toStockOnhand", mRow.Index).Value = mToStockOnhand

        If mFromStockOnhand < mGoodAmou Then
          mLowerStock = True
          dtgList.Item("fromStockOnhand", mRow.Index).Style.ForeColor = Color.Red
        End If
      Else
        pMessageBox = New MyMessageBox("ไม่สามารถตรวจสอบสต๊อคคงเหลือได้" & vbCrLf & mGet(0), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        pMessageBox.ShowDialog()
        Exit Function
      End If
    Next

    Return mLowerStock
  End Function

  Private Sub tbnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnCancel.Click
    If dtgMast.Rows.Count > 0 Then
      pMessageBox = New MyMessageBox("ยืนยันยกเลิกใบขอโอน " & mRequNumb, Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
      If pMessageBox.ShowDialog = Windows.Forms.DialogResult.Cancel Then
        Exit Sub
      End If

      Dim mSqlText(1) As String
      mSqlText(0) = "Update RequTranMast set requStat = '0' where requNumb = '" & mRequNumb & "'"

      Dim mUpdate As String
      mUpdate = pService.UpdateData("Drug", mSqlText)
      If mUpdate = "1" Then
        ShowRequTran()
      Else
        pMessageBox = New MyMessageBox(mUpdate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        pMessageBox.ShowDialog()
      End If
    End If
  End Sub
End Class