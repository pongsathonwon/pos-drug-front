Public Class frmUploadServer

  Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
    If My.Computer.FileSystem.FileExists(pOffLineFolder & "data.mdb") = False Then
      MessageBox.Show("ไม่มีไฟล์ฐานข้อมูล Off line ไม่สามารถทำการอัพโหลดได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If
    ' check if DrugFront Offline is running
    Dim mProcess() As Process
    mProcess = Process.GetProcesses
    Dim mInstance As Process
    For Each mInstance In mProcess
      If mInstance.ProcessName = "DrugFrontOffLine" Then
        MessageBox.Show("กรุณาปิดโปรแกรม DrugFront Offline ก่อนทำการอัพโหลด", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Exit Sub
      End If
    Next

    Dim mAllRecordCount As Integer = 0
    Dim mGet() As String

    ' ตรวจสอบว่ามีรายการขายที่ต้อง upload หรือไม่
    'Dim mSaleRecordCount As Integer
    mGet = GetData("SELECT count(*) FROM HistSale WHERE flag = '1'")
    If mGet(0) = "1" AndAlso CInt(mGet(1)) > 0 Then
      'mSaleRecordCount = CInt(mGet(1))
      mAllRecordCount += CInt(mGet(1))
    End If

    ' ตรวจสอบว่ามีรายการบันทึกเวลาเข้าออกที่ต้อง upload หรือไม่
    'Dim mTimeRecordCount As Integer
    mGet = GetData("SELECT count(*) FROM ETimeStamp WHERE flag = '1'")
    If mGet(0) = "1" AndAlso CInt(mGet(1)) > 0 Then
      'mTimeRecordCount = CInt(mGet(1))
      mAllRecordCount += CInt(mGet(1))
    End If

    '' ตรวจสอบว่ามีรายการยกเลิกรายการขายหรือไม่
    'mGet = GetData("SELECT count(*) FROM HistSaleCancel WHERE flag = '1'")
    'If mGet(0) = "1" AndAlso CInt(mGet(1)) > 0 Then
    '  'mTimeRecordCount = CInt(mGet(1))
    '  mAllRecordCount += CInt(mGet(1))
    'End If

    'mAllRecordCount = mSaleRecordCount + mTimeRecordCount
    If mAllRecordCount <= 0 Then
      MessageBox.Show("ไม่มีข้อมูล Off Line ที่ต้องอัพโหลดไปยัง Server", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If

    If MessageBox.Show("ยืนยันอัพโหลดข้อมูล Off Line ไปยัง Server", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
      Exit Sub
    End If

    btnStart.Enabled = False
    Me.Cursor = Cursors.WaitCursor
    Application.DoEvents()

    pgb1.Maximum = mAllRecordCount
    pgb1.Value = 0

    ' ใช้วันที่และเวลาของ server
    pServerDateTime = pService.ServerDateTime

    ' upload ข้อมูลขาย
    Dim dsHistSale As New DataSet
    dsHistSale = SelectData("SELECT * FROM HistSale WHERE flag = '1'")
    If IsNothing(dsHistSale) = False Then
      Dim dvHistSale As New DataView(dsHistSale.Tables(0))
      If dvHistSale.Count > 0 Then
        Dim mNumb As Integer
        Dim getValue() As String
        getValue = pService.GetData("Drug", "SELECT saleNumb FROM BranchInfo WHERE branchCode = '" & pBranchCode & "'")
        If getValue(0) = "1" Then
          mNumb = CInt(getValue(1))
        Else
          MessageBox.Show("ไม่สามารถกำหนดเลขที่ใบขายได้" & "(" & getValue(1) & ")", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
          Exit Sub
        End If

        Dim mStockOnhandField, mLastSaleField, mUnitCostField As String
        mStockOnhandField = "stockOnhand" & pBranchCode
        mLastSaleField = "lastSale" & pBranchCode
        mUnitCostField = "unitCost" & pBranchCode

        Dim mSqlText(300) As String
        Dim mDataText(1) As String
        Dim mLine As Integer = 0
        Dim mSaleNumb As String
        Dim mUpdate As String
        Dim mDataUpdate As String
        Dim mEmplName As String

        Dim dsSaleList As New DataSet
        Dim dvSaleList As DataView
        Dim mSaleDate As Date
        Dim mTotalPrice, mTotalCash, mTotalCredit As Double
        Dim mCardCode As String = "0"
        Dim mCreditNumb As String = ""
        Dim mPayAmou As Double

        For i As Integer = 0 To dvHistSale.Count - 1
          '' clear array
          'For m As Integer = 0 To mSqlText.Length - 1
          '  mSqlText(m) = ""
          'Next
          ReDim mSqlText(500)

          With dvHistSale.Item(i)
            '' หมายเลขใบขาย + "F" + เลขใบขาย off line
            'mSaleNumb = pPreSaleNumb & Mid((10000 + mNumb).ToString, 2) & "F"

            ' กพ 2566
            ' หมายเลขใบขาย รองรับใบกำกับภาษี ให้หมายเหตุใน saleRema = 'offline' แทนการเพิ่ม "F" ต่อท้าย เนื่องจากเกินขนาด saleNumb (15 ตัวอักษร)
            mSaleNumb = pPreSaleNumb & Mid((100000 + mNumb).ToString, 2)

            mSaleDate = CDate(.Item("saleDate"))

            mTotalPrice = CDbl(.Item("totalPrice"))
            'If .Item("creditCode") = "0" Then
            '  mTotalCash = mTotalPrice
            '  mTotalCredit = 0
            'Else
            '  mTotalCash = 0
            '  mTotalCredit = mTotalPrice
            'End If
            'mCardCode = .Item("creditCode")
            'mCreditNumb = .Item("creditNumb")
            'mPayAmou = mTotalPrice

            If .Item("payType").ToString = "C" Then
              mTotalCash = CDbl(.Item("totalPrice"))
              mCardCode = "0"
              mCreditNumb = ""
              mPayAmou = mTotalCash
            Else
              mTotalCash = 0
            End If
            If .Item("payType").ToString = "D" Then
              mTotalCredit = CDbl(.Item("totalPrice"))
              mCardCode = .Item("creditCode")
              mCreditNumb = .Item("creditNumb")
              mPayAmou = mTotalCredit
            Else
              mTotalCredit = 0
            End If
            ' ชื่อพนักงานขายเพื่อนำไปบันทึกใน stock card
            mGet = pService.GetData("Drug", "Select emplName from EmplInfo where emplCode = '" & .Item("emplCode").ToString & "'")
            If mGet(0) = "1" Then
              mEmplName = mGet(1)
            Else
              mEmplName = ""
            End If

            mSqlText(mLine) = "INSERT INTO HistSale (saleNumb, saleDate, saleTime, branchCode, custCode, emplCode, cashCode, totalPrice, totalDisc, totalCost, totalPay, totalCash, totalCredit, totalDebt, totalCupong, perCharge, payType, creditNumb, saleStat, creditCode, saleRema) values ('" & mSaleNumb & "', '" & MDYStr(mSaleDate) & "', '" & .Item("saleTime").ToString & "', '" & pBranchCode & "', '" & .Item("custCode").ToString & "', '" & .Item("emplCode").ToString & "', '" & .Item("cashCode").ToString & "', " & CDbl(.Item("totalPrice")) & ", " & CDbl(.Item("totalDisc")) & ", " & CDbl(.Item("totalCost")) & ", " & CDbl(.Item("totalPay")) & ", " & mTotalCash & ", " & mTotalCredit & ", 0, 0, " & CDbl(.Item("perCharge")) & ", '" & .Item("payType").ToString & "', '" & .Item("creditNumb").ToString & "', '1', '" & .Item("creditCode").ToString & "', 'offline')"
            mLine += 1

            ' ข้อมูลประเภทการชำระเงิน
            mSqlText(mLine) = "Insert into SalePaidList (saleNumb, cardCode, payAmou, refNumb) values ('" & mSaleNumb & "', '" & mCardCode & "', " & mPayAmou & ", '" & mCreditNumb & "')"
            mLine += 1
          End With

          dsSaleList = SelectData("SELECT * FROM SaleList WHERE saleNumb = '" & dvHistSale.Item(i).Item("saleNumb").ToString & "'")
          If IsNothing(dsSaleList) = False Then
            dvSaleList = New DataView(dsSaleList.Tables(0))
            Dim mGetValue() As String
            Dim mTotalGoodAmou As Integer
            Dim mStockOnhand As Integer
            Dim mUnitCost As Double
            ' *****************
            ' เก็บข้อมูลรายการขายไว้ใน dtgTemp เพื่อหา stockOnhand ของแต่ละรายการ สำหรับเก็บใน stockCard
            ' และใช้ราคาทุนของสินค้าแต่ละสาขาจาก server โดยตรง ป้องกันปัญหาราคาทุนเป็น 0 จากข้อมูล offline ซึ่งกระทบกับการคำนวณ GP
            dtgTemp.Rows.Clear()
            For x As Integer = 0 To dvSaleList.Count - 1
              With dvSaleList.Item(x)
                mTotalGoodAmou = CInt(.Item("goodAmou")) * CInt(.Item("unitFactor"))
                dtgTemp.Rows.Add()
                dtgTemp.Item("barCode", x).Value = .Item("barCode")
                dtgTemp.Item("goodCode", x).Value = .Item("goodCode")
                dtgTemp.Item("goodAmou", x).Value = .Item("goodAmou")
                dtgTemp.Item("unitCode", x).Value = .Item("unitCode")
                dtgTemp.Item("unitPrice", x).Value = .Item("unitPrice")
                'dtgTemp.Item("unitCost", x).Value = .Item("unitCost")
                dtgTemp.Item("subDisc", x).Value = .Item("subDisc")
                dtgTemp.Item("totalGoodAmou", x).Value = mTotalGoodAmou

                mGetValue = pService.GetData("Drug", "Select " & mStockOnhandField & ", " & mUnitCostField & " from GoodInfo where goodCode = '" & .Item("goodCode") & "'")
                If mGetValue(0) = "1" Then
                  mStockOnhand = mGetValue(1)
                  mUnitCost = mGetValue(2) ' ราคาทุนจาก server
                Else
                  mStockOnhand = 0
                  mUnitCost = .Item("unitCost") ' ราคาทุนจาก offline
                End If
                dtgTemp.Item("stockOnhand", x).Value = mStockOnhand
                dtgTemp.Item("unitCost", x).Value = mUnitCost
              End With
            Next
            dvSaleList = Nothing

            ' นำข้อมูลใน dtgTemp ไปอัพเดตข้อมูลใน server
            For Each mRow As DataGridViewRow In dtgTemp.Rows
              With dtgTemp
                mSqlText(mLine) = "INSERT INTO SaleList (saleNumb, barCode, goodCode, goodAmou, unitCode, unitPrice, unitCost, subDisc)VALUES ('" & mSaleNumb & "', '" & .Item("barCode", mRow.Index).Value & "', '" & .Item("goodCode", mRow.Index).Value & "', " & CInt(.Item("goodAmou", mRow.Index).Value) & ", '" & .Item("unitCode", mRow.Index).Value & "', " & CSng(.Item("unitPrice", mRow.Index).Value) & ", " & CSng(.Item("unitCost", mRow.Index).Value) & ", " & CSng(.Item("subDisc", mRow.Index).Value) & ")"
                mLine += 1
                ' ตัดสต๊อครวม
                mSqlText(mLine) = "UPDATE GoodInfo set " & mStockOnhandField & " = " & mStockOnhandField & " - " & .Item("totalGoodAmou", mRow.Index).Value & ", " & mLastSaleField & " = '" & MDYStr(CDate(dvHistSale.Item(i).Item("saleDate"))) & "' WHERE goodCode = '" & .Item("goodCode", mRow.Index).Value & "'"
                mLine += 1

                ' Front card
                mSqlText(mLine) = "Insert into FrontCard (stockDate, stockTime, workType, branchCode, docNumb, emplName, goodCode, goodAmou, stockOnhand) Values ('" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', 'OSL', '" & pBranchCode & "', '" & mSaleNumb & "', '" & Mid(mEmplName, 1, 10) & "', '" & .Item("goodCode", mRow.Index).Value & "', " & .Item("totalGoodAmou", mRow.Index).Value & ", " & (.Item("stockOnhand", mRow.Index).Value - .Item("totalGoodAmou", mRow.Index).Value) & ")"
                mLine += 1
              End With
            Next
            ' *****************
          End If
          dsSaleList = Nothing

          mSqlText(mLine) = "UPDATE BranchInfo set saleNumb = saleNumb + 1 WHERE branchCode = '" & pBranchCode & "'"
          mLine += 1

          mUpdate = pService.UpdateData("Drug", mSqlText)
          If mUpdate = "1" Then
            ' update flag ของข้อมูลการขาย
            mDataText(0) = "UPDATE HistSale SET flag = '2' WHERE saleNumb = '" & dvHistSale.Item(i).Item("saleNumb").ToString & "'"
            mDataUpdate = UpdateData(mDataText, "data.mdb")
            If mDataUpdate <> "1" Then
              MessageBox.Show(mDataUpdate, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
          Else
            MessageBox.Show(mUpdate, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
          End If


          mLine = 0
          pgb1.Value += 1
          mNumb += 1
        Next
      End If
    End If
    dsHistSale = Nothing

    Dim mText(1) As String
    Dim mRet As String
    Dim mDateStampIn As Date
    ' update ข้อมูลบันทึกเวลาเข้า
    Dim dsInTime As New DataSet
    dsInTime = SelectData("SELECT * FROM ETimeStamp WHERE inTime <> '' AND flag = '1' ORDER BY dateStamp, inTime")
    If IsNothing(dsInTime) = False Then
      Dim dvInTime As New DataView(dsInTime.Tables(0))
      If dvInTime.Count > 0 Then
        For i As Integer = 0 To dvInTime.Count - 1
          With dvInTime.Item(i)
            mDateStampIn = CDate(.Item("dateStamp"))
            mText(0) = "INSERT INTO ETimeStamp (emplCode, dateStamp, inTime, outTime, branchCode) VALUES ('" & .Item("emplcode").ToString & "', '" & MDYStr(mDateStampIn) & "', '" & .Item("inTime").ToString & "', '', '" & pBranchCode & "')"
            mText(1) = "UPDATE EmplInfo SET dateStamp = '" & MDYStr(mDateStampIn) & "', inTime = '" & .Item("inTime").ToString & "', inBranchCode = '" & pBranchCode & "' WHERE emplCode = '" & .Item("emplCode").ToString & "'"

            mRet = pService.UpdateData("Drug", mText)
          End With
          pgb1.Value += 1
        Next
      End If
      dvInTime = Nothing
    End If
    dsInTime = Nothing

    ' upload ข้อมูลบันทึกเวลาออก
    Dim dsOutTime As New DataSet
    dsOutTime = SelectData("SELECT * FROM ETimeStamp WHERE outTime <> '' AND flag = '1' ORDER BY dateStamp, outTime")
    If IsNothing(dsOutTime) = False Then
      Dim dvOutTime As New DataView(dsOutTime.Tables(0))
      Dim dsIn As New DataSet
      'Dim dvIn As DataView
      'Dim mDateStampOut As Date
      'Dim mGetIn() As String
      If dvOutTime.Count > 0 Then
        For i As Integer = 0 To dvOutTime.Count - 1
          With dvOutTime.Item(i)
            mText(0) = "UPDATE ETimeStamp SET outTime = '" & .Item("outTime").ToString & "' WHERE emplCode = '" & .Item("emplCode").ToString & "' AND dateStamp = '" & MDYStr(CDate(.Item("dateStamp"))) & "' AND outTime = '' and branchCode = '" & pBranchCode & "'"
            mText(1) = "UPDATE EmplInfo SET dateStamp = '" & MDYStr(pServerDateTime.Date) & "', inTime = '', inBranchCode = '' WHERE emplCode = '" & .Item("emplCode").ToString & "' AND dateStamp = '" & MDYStr(CDate(.Item("dateStamp"))) & "'"

            '' ตรวจสอบว่ามีการลงเวลาเข้าหรือยัง
            'dsIn = pService.SelectData("Drug", "SELECT emplCode, dateStamp, inTime, inBranchCode FROM EmplInfo WHERE emplCode = '" & .Item("emplCode").ToString & "' AND emplStat = '1'")
            'If IsNothing(dsIn) = False Then
            '  dvIn = New DataView(dsIn.Tables(0))
            '  If dvIn.Count > 0 Then
            '    mDateStampOut = CDate(dvIn.Item(0).Item("dateStamp"))
            '    mText(0) = "UPDATE ETimeStamp SET outTime = '" & .Item("outTime").ToString & "' WHERE emplCode = '" & .Item("emplCode").ToString & "' AND dateStamp = '" & MDYStr(mDateStampOut) & "' AND inTime = '" & dvIn.Item(0).Item("inTime").ToString & "'"
            '    ' clear ข้อมูลใหม่
            '    mText(1) = "UPDATE EmplInfo SET dateStamp = '" & MDYStr(pServerDateTime.Date) & "', inTime = '', inBranchCode = '' WHERE emplCode = '" & .Item("emplCode").ToString & "'"
            '  End If
            '  dvIn = Nothing
            'End If
            'dsIn = Nothing

            mRet = pService.UpdateData("Drug", mText)
          End With
          pgb1.Value += 1
        Next
      End If
    End If
    dsInTime = Nothing
    ' update flag ของข้อมูลบันทึกลงเวลาเข้าออก
    mText(0) = "UPDATE ETimeStamp SET flag = '2'"
    mText(1) = ""
    mRet = UpdateData(mText, "data.mdb")
    If mRet <> "1" Then
      MessageBox.Show(mRet, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End If
    '' **************************
    '' upload ข้อมูลการยกเลิกรายการขาย
    'Dim dsCancel As New DataSet
    'Dim mCancelText(1) As String
    'Dim mCancelDate As Date
    'dsCancel = SelectData("SELECT * FROM HistSaleCancel WHERE flag = '1'")
    'If IsNothing(dsCancel) = False Then
    '  Dim dvCancel As New DataView(dsCancel.Tables(0))
    '  If dvCancel.Count > 0 Then
    '    For i As Integer = 0 To dvCancel.Count - 1
    '      With dvCancel.Item(i)
    '        mCancelDate = CDate(.Item("cancelDate"))
    '        mCancelText(0) = "INSERT INTO HistSaleCancel (cancelDate, cancelTime, goodCode, goodAmou, unitCode, unitPrice, emplCode, branchCode) VALUES ('" & MDYStr(mCancelDate) & "', '" & .Item("cancelTime").ToString & "', '" & .Item("goodCode").ToString & "', " & CInt(.Item("goodAmou")) & ", '" & .Item("unitCode").ToString & "', " & CDbl(.Item("unitPrice")) & ", '" & .Item("emplCode").ToString & "', '" & .Item("branchCode").ToString & "')"
    '        mRet = pService.UpdateData("Drug", mCancelText)
    '      End With
    '      pgb1.Value += 1
    '    Next
    '  End If
    '  dvCancel = Nothing
    'End If
    'dsCancel = Nothing
    '' update flag ของข้อมูลการยกเลิกขาย
    'mCancelText(0) = "UPDATE HistSaleCancel SET flag = '2' WHERE flag = '1'"
    'mRet = UpdateData(mCancelText, "data.mdb")
    'If mRet <> "1" Then
    '  'MessageBox.Show(mRet, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    'End If
    '' **************************

    Me.Cursor = Cursors.Default

    MessageBox.Show("อัพโหลดเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    Me.Close()
  End Sub

  'Private Sub frmUpdateServer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
  ' เลขที่ใบขาย ประกอบด้วย เลขที่สาขา+1(ขาย)หรือ0(คืน)+ปีเดือนวัน+ลำดับที่
  ' หากวันที่ปัจจุบันเปลี่ยนเป็นวันที่ใหม่ ให้เริ่มเลข 1
  'Dim mDate As Date
  'Dim dsBranch As New DataSet
  'dsBranch = pService.SelectData("Drug", "SELECT saleDate FROM BranchInfo WHERE branchCode = '" & pBranchCode & "'")
  'If IsNothing(dsBranch) = False Then
  '  Dim dvBranch As New DataView(dsBranch.Tables(0))
  '  If dvBranch.Count > 0 Then
  '    mDate = CDate(dvBranch.Item(0).Item("saleDate"))
  '    If Format(mDate, "yyyyMMdd") < Format(Date.Today, "yyyyMMdd") Then
  '      Dim mSqlText(1) As String
  '      mSqlText(0) = "UPDATE BranchInfo SET saleNumb = 1, saleDate = '" & MDYStr(Date.Today) & "' WHERE branchCode = '" & pBranchCode & "'"
  '      Dim mRet As String
  '      mRet = pService.UpdateData("Drug", mSqlText)
  '      If mRet = "1" Then
  '        pPreSaleNumb = pBranchCode & Format(Date.Today, "yyMMdd")
  '      Else
  '        MessageBox.Show(mRet, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '        End
  '      End If
  '    Else
  '      pPreSaleNumb = pBranchCode & Format(mDate, "yyMMdd")
  '    End If
  '  Else
  '    MessageBox.Show("Error in create sale number", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '    End
  '  End If
  '  dvBranch = Nothing
  'Else
  '  MessageBox.Show("Error in create sale number", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '  End
  'End If
  'dsBranch = Nothing
  'End Sub

  Private Sub frmUploadServer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    CheckPriv()
  End Sub

  Private Sub CheckPriv()
    ' Add
    If InStr(pUserPriv, Me.Tag.ToString & "A") > 0 Then
      btnStart.Enabled = True
    Else
      btnStart.Enabled = False
    End If
  End Sub
End Class