Public Class frmUpdateOffline

  Dim mCancel As Boolean

  'Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
  '  If My.Computer.FileSystem.FileExists(pOffLineFolder & "datablank.mdb") = False Then
  '    MessageBox.Show("ไม่มีไฟล์ฐานข้อมูล Offline ไม่สามารถทำการ Download ได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
  '    Exit Sub
  '  End If

  '  Dim mGet() As String
  '  ' ถ้ามีไฟล์ข้อมูลเดิมอยู่ ให้ตรวจสอบว่ามีข้อมูลขาย Offline ที่ยังไม่ได้ update หรือไม่ หากมีต้องทำการ update ไปยัง server ก่อน
  '  If My.Computer.FileSystem.FileExists(pOffLineFolder & "data.mdb") = True Then
  '    mGet = GetData("SELECT count(*) FROM HistSale WHERE flag = '1'")
  '    If mGet(0) = "1" AndAlso CInt(mGet(1)) > 0 Then
  '      MessageBox.Show("ท่านต้องทำการ Upload ข้อมูลการขาย Offline ไปยัง Server ก่อน", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
  '      Exit Sub
  '    End If
  '  End If

  '  If MessageBox.Show("ยืนยัน Download ข้อมูลหลักจาก Server เพื่อใช้ในโปรแกรม Offline", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
  '    Exit Sub
  '  End If

  '  btnStart.Enabled = False
  '  Me.Cursor = Cursors.WaitCursor

  '  Application.DoEvents()

  '  ' ลบไฟล์เดิม
  '  'My.Computer.FileSystem.DeleteFile("c:\drugpos\data.mdb")

  '  '' เปลี่ยนชื่อไฟล์เดิมเก็บสำรองไว้
  '  'If My.Computer.FileSystem.FileExists(pOffLineFolder & "data.mdb") = True Then
  '  '  Try
  '  '    My.Computer.FileSystem.RenameFile(pOffLineFolder & "data.mdb", "data" & Format(Now, "yyyyMMddHHmm") & ".mdb")
  '  '  Catch ex As Exception
  '  '    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
  '  '    Me.Cursor = Cursors.Default
  '  '    Exit Sub
  '  '  End Try
  '  'End If

  '  ' ตรวจสอบไฟล์ข้อมูลมาตราฐาน
  '  If My.Computer.FileSystem.FileExists(pOffLineFolder & "dataBlank.mdb") = False Then
  '    MessageBox.Show("Error : ไม่พบไฟล์ข้อมูลมาตราฐาน ไม่สามารถดาวน์โหลดได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '    Exit Sub
  '  Else
  '    ' ลบไฟล์ชั่วคราวที่ค้างอยู่
  '    If My.Computer.FileSystem.FileExists(pOffLineFolder & "dataTemp.mdb") = True Then
  '      My.Computer.FileSystem.DeleteFile(pOffLineFolder & "dataTemp.mdb")
  '    End If

  '    ' สร้างไฟล์ข้อมูลชั่วคราวใหม่จากไฟล์มาตราฐาน
  '    Try
  '      My.Computer.FileSystem.CopyFile(pOffLineFolder & "dataBlank.mdb", pOffLineFolder & "dataTemp.mdb")
  '    Catch ex As Exception
  '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
  '      Me.Cursor = Cursors.Default
  '      Exit Sub
  '    End Try
  '  End If

  '  ' *****************************
  '  ' หาจำนวน record ที่ต้อง update ทั้งหมด
  '  Dim mAllRecord As Integer = 0
  '  Dim mGICount, mGBCount, mUICount, mEICount, mCICount, mCDCount As Integer
  '  Try
  '    mGet = pService.GetData("Drug", "SELECT COUNT(*) FROM GoodInfo WHERE goodStat = '1'")
  '    If mGet(0) = "1" Then
  '      mGICount = CInt(mGet(1))
  '      mAllRecord += mGICount
  '    End If
  '    mGet = pService.GetData("Drug", "SELECT COUNT(*) FROM GoodBarcode")
  '    If mGet(0) = "1" Then
  '      mGBCount = CInt(mGet(1))
  '      mAllRecord += mGBCount
  '    End If
  '    mGet = pService.GetData("Drug", "SELECT COUNT(*) FROM UnitInfo")
  '    If mGet(0) = "1" Then
  '      mUICount = CInt(mGet(1))
  '      mAllRecord += mUICount
  '    End If
  '    mGet = pService.GetData("Drug", "SELECT COUNT(*) FROM EmplInfo WHERE emplStat = '1'")
  '    If mGet(0) = "1" Then
  '      mEICount = CInt(mGet(1))
  '      mAllRecord += mEICount
  '    End If
  '    mGet = pService.GetData("Drug", "SELECT COUNT(*) FROM CustInfo WHERE custStat = '1'")
  '    If mGet(0) = "1" Then
  '      mCICount = CInt(mGet(1))
  '      mAllRecord += mCICount
  '    End If
  '    mGet = pService.GetData("Drug", "SELECT COUNT(*) FROM CreditInfo")
  '    If mGet(0) = "1" Then
  '      mCDCount = CInt(mGet(1))
  '      mAllRecord += mCDCount
  '    End If
  '  Catch ex As Exception
  '    MessageBox.Show("เกิดข้อผิดพลาดระหว่างดาวน์โหลด กรุณาดาวน์โหลดใหม่อีกครั้ง : " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '    Me.Close()
  '  End Try

  '  ' เริ่มต้น download ข้อมูลจาก server
  '  Try
  '    pgb1.Maximum = mAllRecord
  '    pgb1.Value = 0

  '    Dim mSqlText(1) As String
  '    Dim mLine As Integer
  '    Dim mUpdate As String

  '    ' CustInfo
  '    ReDim mSqlText(mCICount)
  '    mLine = 0
  '    Dim dsCustInfo As New DataSet
  '    dsCustInfo = pService.SelectData("Drug", "SELECT custCode, custName, custType FROM CustInfo WHERE custStat = '1'")
  '    If IsNothing(dsCustInfo) = False Then
  '      Dim dvCustInfo As New DataView(dsCustInfo.Tables(0))

  '      For i As Integer = 0 To dvCustInfo.Count - 1
  '        With dvCustInfo.Item(i)
  '          mSqlText(mLine) = "INSERT INTO CustInfo (custCode, custName, custType) VALUES ('" & .Item("custCode").ToString & "', '" & .Item("custName").ToString & "', '" & .Item("custType").ToString & "')"
  '          mLine += 1
  '        End With
  '        pgb1.Value += 1
  '      Next i
  '      dvCustInfo = Nothing

  '      mUpdate = UpdateData(mSqlText, "dataTemp.mdb")
  '      If mUpdate <> "1" Then
  '        MessageBox.Show("Error : เกิดข้อผิดพลาดระหว่างดาวน์โหลดข้อมูล กรุณาดาวน์โหลดใหม่อีกครั้ง (" & mUpdate & ")", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '        Me.Close()
  '      End If
  '    Else
  '      MessageBox.Show("Error : เกิดข้อผิดพลาดระหว่างดาวน์โหลดข้อมูล กรุณาดาวน์โหลดใหม่อีกครั้ง", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '      Me.Close()
  '    End If
  '    dsCustInfo = Nothing

  '    ' EmplInfo
  '    ReDim mSqlText(mEICount)
  '    mLine = 0
  '    Dim dsEmplInfo As New DataSet
  '    dsEmplInfo = pService.SelectData("Drug", "SELECT emplCode, emplName, userName, userPWD, emplID FROM EmplInfo WHERE emplStat = '1'")
  '    If IsNothing(dsEmplInfo) = False Then
  '      Dim dvEmplInfo As New DataView(dsEmplInfo.Tables(0))

  '      For i As Integer = 0 To dvEmplInfo.Count - 1
  '        With dvEmplInfo.Item(i)
  '          mSqlText(mLine) = "INSERT INTO EmplInfo (emplCode, emplName, userName, userPWD, emplID) VALUES ('" & .Item("emplCode").ToString & "', '" & .Item("emplName").ToString & "', '" & .Item("userName").ToString & "', '" & .Item("userPWD").ToString & "', '" & .Item("emplID").ToString & "')"
  '          mLine += 1
  '        End With
  '        pgb1.Value += 1
  '      Next i
  '      dvEmplInfo = Nothing

  '      mUpdate = UpdateData(mSqlText, "dataTemp.mdb")
  '      If mUpdate <> "1" Then
  '        MessageBox.Show("Error : เกิดข้อผิดพลาดระหว่างดาวน์โหลดข้อมูล กรุณาดาวน์โหลดใหม่อีกครั้ง (" & mUpdate & ")", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '        Me.Close()
  '      End If
  '    Else
  '      MessageBox.Show("Error : เกิดข้อผิดพลาดระหว่างดาวน์โหลดข้อมูล กรุณาดาวน์โหลดใหม่อีกครั้ง", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '      Me.Close()
  '    End If
  '    dsEmplInfo = Nothing

  '    ' CreditInfo
  '    ReDim mSqlText(mCDCount - 1)
  '    mLine = 0
  '    Dim dsCreditInfo As New DataSet
  '    dsCreditInfo = pService.SelectData("Drug", "SELECT creditCode, creditName, percCharge FROM CreditInfo")
  '    If IsNothing(dsCreditInfo) = False Then
  '      Dim dvCreditInfo As New DataView(dsCreditInfo.Tables(0))

  '      For i As Integer = 0 To dvCreditInfo.Count - 1
  '        With dvCreditInfo.Item(i)
  '          mSqlText(mLine) = "INSERT INTO CreditInfo (creditCode, creditName, perCharge) VALUES ('" & .Item("creditCode").ToString & "', '" & .Item("creditName").ToString & "', " & CSng(.Item("percCharge")) & ")"
  '          mLine += 1
  '        End With
  '        pgb1.Value += 1
  '      Next i
  '      dvCreditInfo = Nothing

  '      mUpdate = UpdateData(mSqlText, "dataTemp.mdb")
  '      If mUpdate <> "1" Then
  '        MessageBox.Show("Error : เกิดข้อผิดพลาดระหว่างดาวน์โหลดข้อมูล กรุณาดาวน์โหลดใหม่อีกครั้ง (" & mUpdate & ")", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '        Me.Close()
  '      End If
  '    Else
  '      MessageBox.Show("Error : เกิดข้อผิดพลาดระหว่างดาวน์โหลดข้อมูล กรุณาดาวน์โหลดใหม่อีกครั้ง", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '      Me.Close()
  '    End If
  '    dsCreditInfo = Nothing

  '    ' GoodBarcode
  '    ReDim mSqlText(mGBCount)
  '    mLine = 0
  '    Dim mPriceField As String = "price" & pBranchPrice
  '    Dim dsGoodBarcode As New DataSet
  '    dsGoodBarcode = pService.SelectData("Drug", "SELECT barCode, goodCode, goodAmou, unitCode, " & mPriceField & " FROM GoodBarcode")
  '    If IsNothing(dsGoodBarcode) = False Then
  '      Dim dvGoodBarcode As New DataView(dsGoodBarcode.Tables(0))

  '      For i As Integer = 0 To dvGoodBarcode.Count - 1
  '        With dvGoodBarcode.Item(i)
  '          mSqlText(mLine) = "INSERT INTO GoodBarcode (barCode, goodCode, goodAmou, unitCode, price) VALUES ('" & .Item("barCode").ToString & "', '" & .Item("goodCode").ToString & "', " & CInt(.Item("goodAmou")) & ", '" & .Item("unitCode").ToString & "', " & CDbl(.Item(mPriceField)) & ")"
  '          mLine += 1
  '        End With
  '        pgb1.Value += 1
  '      Next i
  '      dvGoodBarcode = Nothing

  '      mUpdate = UpdateData(mSqlText, "dataTemp.mdb")
  '      If mUpdate <> "1" Then
  '        MessageBox.Show("Error : เกิดข้อผิดพลาดระหว่างดาวน์โหลดข้อมูล กรุณาดาวน์โหลดใหม่อีกครั้ง (" & mUpdate & ")", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '        Me.Close()
  '      End If
  '    Else
  '      MessageBox.Show("Error : เกิดข้อผิดพลาดระหว่างดาวน์โหลดข้อมูล กรุณาดาวน์โหลดใหม่อีกครั้ง", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '      Me.Close()
  '    End If
  '    dsGoodBarcode = Nothing

  '    ' GoodInfo
  '    ReDim mSqlText(mGICount)
  '    mLine = 0
  '    Dim mUnitCostField As String = "unitCost" & pBranchCode
  '    Dim dsGoodInfo As New DataSet
  '    dsGoodInfo = pService.SelectData("Drug", "SELECT goodCode, goodName, unitCode, " & mUnitCostField & " FROM GoodInfo WHERE goodStat = '1'")
  '    If IsNothing(dsGoodInfo) = False Then
  '      Dim dvGoodInfo As New DataView(dsGoodInfo.Tables(0))

  '      For i As Integer = 0 To dvGoodInfo.Count - 1
  '        With dvGoodInfo.Item(i)
  '          mSqlText(mLine) = "INSERT INTO GoodInfo (goodCode, goodName, unitCode, unitCost) VALUES ('" & .Item("goodCode").ToString & "', '" & Replace(.Item("goodName").ToString, "'", "''") & "', '" & .Item("unitCode").ToString & "', " & CDbl(.Item(mUnitCostField)) & ")"
  '          mLine += 1
  '        End With
  '        pgb1.Value += 1
  '      Next i
  '      dvGoodInfo = Nothing

  '      mUpdate = UpdateData(mSqlText, "dataTemp.mdb")
  '      If mUpdate <> "1" Then
  '        MessageBox.Show("Error : เกิดข้อผิดพลาดระหว่างดาวน์โหลดข้อมูล กรุณาดาวน์โหลดใหม่อีกครั้ง (" & mUpdate & ")", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '        Me.Close()
  '      End If
  '    Else
  '      MessageBox.Show("Error : เกิดข้อผิดพลาดระหว่างดาวน์โหลดข้อมูล กรุณาดาวน์โหลดใหม่อีกครั้ง", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '      Me.Close()
  '    End If
  '    dsGoodInfo = Nothing

  '    ' UnitInfo
  '    ReDim mSqlText(mUICount)
  '    mLine = 0
  '    Dim dsUnitInfo As New DataSet
  '    dsUnitInfo = pService.SelectData("Drug", "SELECT unitCode, unitDesc, unitFactor FROM UnitInfo")
  '    If IsNothing(dsUnitInfo) = False Then
  '      Dim dvUnitInfo As New DataView(dsUnitInfo.Tables(0))

  '      For i As Integer = 0 To dvUnitInfo.Count - 1
  '        With dvUnitInfo.Item(i)
  '          mSqlText(mLine) = "INSERT INTO UnitInfo (unitCode, unitDesc, unitFactor) VALUES ('" & .Item("unitCode").ToString & "', '" & .Item("unitDesc").ToString & "', " & CInt(.Item("unitFactor")) & ")"
  '          mLine += 1
  '        End With
  '        pgb1.Value += 1
  '      Next i
  '      dvUnitInfo = Nothing

  '      mUpdate = UpdateData(mSqlText, "dataTemp.mdb")
  '      If mUpdate <> "1" Then
  '        MessageBox.Show("Error : เกิดข้อผิดพลาดระหว่างดาวน์โหลดข้อมูล กรุณาดาวน์โหลดใหม่อีกครั้ง (" & mUpdate & ")", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '        Me.Close()
  '      End If
  '    Else
  '      MessageBox.Show("Error : เกิดข้อผิดพลาดระหว่างดาวน์โหลดข้อมูล กรุณาดาวน์โหลดใหม่อีกครั้ง", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '      Me.Close()
  '    End If
  '    dsUnitInfo = Nothing

  '    ' SystInfo
  '    ReDim mSqlText(1)
  '    mSqlText(0) = "INSERT INTO SystInfo (branchCode, compName, branchName) VALUES ('" & pBranchCode & "', '" & pCompName & "', '" & pBranchName & "')"
  '    mUpdate = UpdateData(mSqlText, "dataTemp.mdb")
  '    If mUpdate <> "1" Then
  '      MessageBox.Show("Error : เกิดข้อผิดพลาดระหว่างดาวน์โหลดข้อมูล กรุณาดาวน์โหลดใหม่อีกครั้ง", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '      Me.Close()
  '    End If
  '    ' *****************************
  '    ' เปลี่ยนชื่อไฟล์ข้อมูลหลักเก็บสำรองไว้
  '    If My.Computer.FileSystem.FileExists(pOffLineFolder & "data.mdb") = True Then
  '      Try
  '        My.Computer.FileSystem.RenameFile(pOffLineFolder & "data.mdb", "data" & Format(Now, "yyMMdd-HHmm") & ".mdb")
  '      Catch ex As Exception
  '        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
  '        Me.Cursor = Cursors.Default
  '        Exit Sub
  '      End Try
  '    Else
  '      MessageBox.Show("Error : ไม่พบไฟล์ข้อมูลหลัก", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '    End If
  '    ' เปลี่ยนชื่อไฟล์ข้อมูลชั่วคราวไปเป็นไฟล์ข้อมูลหลักที่นำไปใช้งานได้
  '    If My.Computer.FileSystem.FileExists(pOffLineFolder & "dataTemp.mdb") = True Then
  '      Try
  '        My.Computer.FileSystem.RenameFile(pOffLineFolder & "dataTemp.mdb", "data.mdb")
  '      Catch ex As Exception
  '        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
  '        Me.Cursor = Cursors.Default
  '        Exit Sub
  '      End Try
  '    Else
  '      MessageBox.Show("Error : ไม่พบไฟล์ข้อมูลชั่วคราว ดาวน์โหลดไม่สำเร็จ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '      Me.Close()
  '    End If
  '    ' *****************************
  '    Me.Cursor = Cursors.Default

  '    MessageBox.Show("Download เรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
  '    Me.Close()

  '  Catch ex As Exception
  '    MessageBox.Show("เกิดข้อผิดพลาดระหว่างดาวน์โหลด กรุณาดาวน์โหลดใหม่อีกครั้ง : " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '    Me.Close()
  '  End Try
  'End Sub

  'Dim mAllRecord As Integer = 0
  '' หาจำนวน record ที่ต้อง update ทั้งหมด
  '  mGet = pService.GetData("Drug", "SELECT COUNT(*) FROM GoodInfo WHERE goodStat = '1'")
  '  If mGet(0) = "1" Then
  '    mAllRecord += CInt(mGet(1))
  '  End If
  '  mGet = pService.GetData("Drug", "SELECT COUNT(*) FROM GoodBarcode")
  '  If mGet(0) = "1" Then
  '    mAllRecord += CInt(mGet(1))
  '  End If
  '  mGet = pService.GetData("Drug", "SELECT COUNT(*) FROM UnitInfo")
  '  If mGet(0) = "1" Then
  '    mAllRecord += CInt(mGet(1))
  '  End If
  '  mGet = pService.GetData("Drug", "SELECT COUNT(*) FROM EmplInfo WHERE branchCode = '" & pBranchCode & "' AND emplStat = '1'")
  '  If mGet(0) = "1" Then
  '    mAllRecord += CInt(mGet(1))
  '  End If
  '  mGet = pService.GetData("Drug", "SELECT COUNT(*) FROM CustInfo WHERE custStat = '1'")
  '  If mGet(0) = "1" Then
  '    mAllRecord += CInt(mGet(1))
  '  End If
  '  mGet = pService.GetData("Drug", "SELECT COUNT(*) FROM CreditInfo")
  '  If mGet(0) = "1" Then
  '    mAllRecord += CInt(mGet(1))
  '  End If

  '  pgb1.Maximum = mAllRecord
  '  pgb1.Value = 0

  'Dim mSqlText(1) As String
  'Dim mUpdate As String

  '' GoodBarcode
  'Dim mPriceField As String = "price" & pBranchPrice
  'Dim dsGoodBarcode As New DataSet
  '  dsGoodBarcode = pService.SelectData("Drug", "SELECT barCode, goodCode, goodAmou, unitCode, " & mPriceField & " FROM GoodBarcode")
  '  If IsNothing(dsGoodBarcode) = False Then
  'Dim dvGoodBarcode As New DataView(dsGoodBarcode.Tables(0))

  '    For i As Integer = 0 To dvGoodBarcode.Count - 1
  '      With dvGoodBarcode.Item(i)
  '        mGet = GetData("SELECT barCode, goodCode, goodAmou FROM GoodBarcode WHERE barCode = '" & .Item("barCode").ToString & "' AND goodCode = '" & .Item("goodCode").ToString & "' AND goodAmou = " & CInt(.Item("goodAmou")))
  '        If mGet(0) = "1" Then
  '          mSqlText(0) = "UPDATE GoodBarcode SET unitCode = '" & .Item("unitCode").ToString & "', price = " & CDbl(.Item(mPriceField)) & " WHERE barCode = '" & .Item("barCode").ToString & "' AND goodCode = '" & .Item("goodCode").ToString & "' AND goodAmou = " & CInt(.Item("goodAmou"))
  '        Else
  '          mSqlText(0) = "INSERT INTO GoodBarcode (barCode, goodCode, goodAmou, unitCode, price) VALUES ('" & .Item("barCode").ToString & "', '" & .Item("goodCode").ToString & "', " & CInt(.Item("goodAmou")) & ", '" & .Item("unitCode").ToString & "', " & CDbl(.Item(mPriceField)) & ")"
  '        End If

  '        mUpdate = UpdateData(mSqlText)
  '        If mUpdate <> "1" Then
  '          MessageBox.Show(mUpdate, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '        End If
  '      End With
  '      pgb1.Value += 1
  '    Next i
  '    dvGoodBarcode = Nothing
  '  End If
  '  dsGoodBarcode = Nothing

  '' GoodInfo
  'Dim mUnitCostField As String = "unitCost" & pBranchCode
  'Dim dsGoodInfo As New DataSet
  '  dsGoodInfo = pService.SelectData("Drug", "SELECT goodCode, goodName, unitCode, " & mUnitCostField & " FROM GoodInfo WHERE goodStat = '1'")
  '  If IsNothing(dsGoodInfo) = False Then
  'Dim dvGoodInfo As New DataView(dsGoodInfo.Tables(0))

  '    For i As Integer = 0 To dvGoodInfo.Count - 1
  '      With dvGoodInfo.Item(i)
  '        mGet = GetData("SELECT goodCode FROM GoodInfo WHERE goodCode = '" & .Item("goodCode").ToString & "'")
  '        If mGet(0) = "1" Then
  '          mSqlText(0) = "UPDATE GoodInfo SET goodName = '" & Replace(.Item("goodName").ToString, "'", "''") & "', unitCode = '" & .Item("unitCode").ToString & "', unitCost = " & CDbl(.Item(mUnitCostField)) & " WHERE goodCode = '" & .Item("goodCode").ToString & "'"
  '        Else
  '          mSqlText(0) = "INSERT INTO GoodInfo (goodCode, goodName, unitCode, unitCost) VALUES ('" & .Item("goodCode").ToString & "', '" & Replace(.Item("goodName").ToString, "'", "''") & "', '" & .Item("unitCode").ToString & "', " & CDbl(.Item(mUnitCostField)) & ")"
  '        End If

  '        mUpdate = UpdateData(mSqlText)
  '        If mUpdate <> "1" Then
  '          MessageBox.Show(mUpdate, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '        End If
  '      End With
  '      pgb1.Value += 1
  '    Next i
  '    dvGoodInfo = Nothing
  '  End If
  '  dsGoodInfo = Nothing

  '' UnitInfo
  'Dim dsUnitInfo As New DataSet
  '  dsUnitInfo = pService.SelectData("Drug", "SELECT unitCode, unitDesc, unitFactor FROM UnitInfo")
  '  If IsNothing(dsUnitInfo) = False Then
  'Dim dvUnitInfo As New DataView(dsUnitInfo.Tables(0))

  '    For i As Integer = 0 To dvUnitInfo.Count - 1
  '      With dvUnitInfo.Item(i)
  '        mGet = GetData("SELECT unitCode FROM UnitInfo WHERE unitCode = '" & .Item("unitCode").ToString & "'")
  '        If mGet(0) = "1" Then
  '          mSqlText(0) = "UPDATE UnitInfo SET unitDesc = '" & .Item("unitDesc").ToString & "', unitFactor = " & CInt(.Item("unitFactor")) & " WHERE unitCode = '" & .Item("unitCode").ToString & "'"
  '        Else
  '          mSqlText(0) = "INSERT INTO UnitInfo (unitCode, unitDesc, unitFactor) VALUES ('" & .Item("unitCode").ToString & "', '" & .Item("unitDesc").ToString & "', " & CInt(.Item("unitFactor")) & ")"
  '        End If

  '        mUpdate = UpdateData(mSqlText)
  '        If mUpdate <> "1" Then
  '          MessageBox.Show(mUpdate, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '        End If
  '      End With
  '      pgb1.Value += 1
  '    Next i
  '    dvUnitInfo = Nothing
  '  End If
  '  dsUnitInfo = Nothing
  '' CustInfo
  'Dim dsCustInfo As New DataSet
  '  dsCustInfo = pService.SelectData("Drug", "SELECT custCode, custName, custType FROM CustInfo WHERE custStat = '1'")
  '  If IsNothing(dsCustInfo) = False Then
  'Dim dvCustInfo As New DataView(dsCustInfo.Tables(0))

  '    For i As Integer = 0 To dvCustInfo.Count - 1
  '      With dvCustInfo.Item(i)
  '        mGet = GetData("SELECT custCode FROM CustInfo WHERE custCode = '" & .Item("custCode").ToString & "'")
  '        If mGet(0) = "1" Then
  '          mSqlText(0) = "UPDATE CustInfo SET custName = '" & .Item("custName").ToString & "', custType = '" & .Item("custType").ToString & "' WHERE custCode = '" & .Item("custCode").ToString & "'"
  '        Else
  '          mSqlText(0) = "INSERT INTO CustInfo (custCode, custName, custType) VALUES ('" & .Item("custCode").ToString & "', '" & .Item("custName").ToString & "', '" & .Item("custType").ToString & "')"
  '        End If

  '        mUpdate = UpdateData(mSqlText)
  '        If mUpdate <> "1" Then
  '          MessageBox.Show(mUpdate, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '        End If
  '      End With
  '      pgb1.Value += 1
  '    Next i
  '    dvCustInfo = Nothing
  '  End If
  '  dsCustInfo = Nothing
  '' EmplInfo
  'Dim dsEmplInfo As New DataSet
  '  dsEmplInfo = pService.SelectData("Drug", "SELECT emplCode, emplName, userName, userPWD FROM EmplInfo WHERE emplStat = '1' AND branchCode = '" & pBranchCode & "'")
  '  If IsNothing(dsEmplInfo) = False Then
  'Dim dvEmplInfo As New DataView(dsEmplInfo.Tables(0))

  '    For i As Integer = 0 To dvEmplInfo.Count - 1
  '      With dvEmplInfo.Item(i)
  '        mGet = GetData("SELECT emplCode FROM EmplInfo WHERE emplCode = '" & .Item("emplCode").ToString & "'")
  '        If mGet(0) = "1" Then
  '          mSqlText(0) = "UPDATE EmplInfo SET emplName = '" & .Item("emplName").ToString & "', userName = '" & .Item("userName").ToString & "', userPWD = '" & .Item("userPWD").ToString & "' WHERE emplCode = '" & .Item("emplCode").ToString & "'"
  '        Else
  '          mSqlText(0) = "INSERT INTO EmplInfo (emplCode, emplName, userName, userPWD) VALUES ('" & .Item("emplCode").ToString & "', '" & .Item("emplName").ToString & "', '" & .Item("userName").ToString & "', '" & .Item("userPWD").ToString & "')"
  '        End If

  '        mUpdate = UpdateData(mSqlText)
  '        If mUpdate <> "1" Then
  '          MessageBox.Show(mUpdate, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '        End If
  '      End With
  '      pgb1.Value += 1
  '    Next i
  '    dvEmplInfo = Nothing
  '  End If
  '  dsEmplInfo = Nothing
  '' CreditInfo
  'Dim dsCreditInfo As New DataSet
  '  dsCreditInfo = pService.SelectData("Drug", "SELECT creditCode, creditName, percCharge FROM CreditInfo")
  '  If IsNothing(dsCreditInfo) = False Then
  'Dim dvCreditInfo As New DataView(dsCreditInfo.Tables(0))

  '    For i As Integer = 0 To dvCreditInfo.Count - 1
  '      With dvCreditInfo.Item(i)
  '        mSqlText(0) = "INSERT INTO CreditInfo (creditCode, creditName, perCharge) VALUES ('" & .Item("creditCode").ToString & "', '" & .Item("creditName").ToString & "', " & CSng(.Item("percCharge")) & ")"

  '        mUpdate = UpdateData(mSqlText)
  '        If mUpdate <> "1" Then
  '          MessageBox.Show(mUpdate, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '        End If
  '      End With
  '      pgb1.Value += 1
  '    Next i
  '    dvCreditInfo = Nothing
  '  End If
  '  dsCreditInfo = Nothing
  '' SystInfo
  '  mSqlText(0) = "INSERT INTO SystInfo (compName, branchName) VALUES ('" & pCompName & "', '" & pBranchName & "')"
  '  mUpdate = UpdateData(mSqlText)
  '  If mUpdate <> "1" Then
  '    MessageBox.Show(mUpdate, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '  End If


  Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
    If My.Computer.FileSystem.FileExists(pOffLineFolder & "data.mdb") = False Then
      MessageBox.Show("ไม่มีไฟล์ฐานข้อมูล Offline ไม่สามารถทำการ Update ได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If

    ' check if DrugFront Offline is running
    Dim mProcess() As Process
    mProcess = Process.GetProcesses
    Dim mInstance As Process
    For Each mInstance In mProcess
      If mInstance.ProcessName = "DrugFrontOffLine" Then
        MessageBox.Show("กรุณาปิดโปรแกรม DrugFront Offline ก่อนทำการอัพเดต", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ClearField()
        Exit Sub
      End If
    Next
    Dim mGet() As String
    ' ตรวจสอบข้อมูลในไฟล์ data.mdb ว่าเป็นของสาขาหรือไม่
    mGet = GetData("Select branchCode From SystInfo")
    If mGet(0) = "1" Then
      If mGet(1) <> pBranchCode Then
        MessageBox.Show("ฐานข้อมูล Offline ไม่ใช่ฐานข้อมูลของสาขานี้ ไม่สามารถอัพเดตได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ClearField()
        Exit Sub
      End If
    End If

    ' ถ้ามีไฟล์ข้อมูลเดิมอยู่ ให้ตรวจสอบว่ามีข้อมูลขาย Offline ที่ยังไม่ได้ upload หรือไม่ หากมีต้องทำการ upload ไปยัง server ก่อน
    mGet = GetData("SELECT count(*) FROM HistSale WHERE flag = '1'")
    If mGet(0) = "1" Then
      If CInt(mGet(1)) > 0 Then
        MessageBox.Show("ท่านต้องทำการอัพโหลดข้อมูลการขาย Offline ไปยัง Server ก่อนทำการอัพเดต", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Exit Sub
      End If
    Else
      MessageBox.Show("Error : " & mGet(1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    End If

    If MessageBox.Show("ยืนยันอัพเดตฐานข้อมูล Offline", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
      Exit Sub
    End If

    ' เตรียมข้อมูลที่ต้องการอัพเดต โดย download มาจาก server

    Dim ds As New DataSet
    Dim dvGoodInfo As DataView
    Dim dvGoodBarcode As DataView
    Dim dvUnitInfo As DataView
    Dim dvEmplInfo As DataView
    'Dim dvCustInfo As DataView
    Dim dvCreditInfo As DataView
    Dim dvCardInfo As DataView
    Dim mUnitCostField As String = "unitCost" & pBranchCode
    Dim mPriceField As String = "price" & pBranchPrice

    Dim mAllRecord As Integer = 0

    Me.Cursor = Cursors.WaitCursor
    btnUpdate.Visible = False

    Try
      lblComment.Text = "กำลังเตรียมข้อมูล...GoodInfo"
      Application.DoEvents()
      ds = pService.SelectData("Drug", "SELECT goodCode, goodName, unitCode, " & mUnitCostField & " FROM GoodInfo WHERE goodStat = '1'")
      If IsNothing(ds) = False Then
        dvGoodInfo = New DataView(ds.Tables(0))
        mAllRecord += dvGoodInfo.Count
      End If

      lblComment.Text = "กำลังเตรียมข้อมูล...GoodBarcode"
      Application.DoEvents()
      ds = pService.SelectData("Drug", "SELECT barCode, goodCode, goodAmou, unitCode, " & mPriceField & " FROM GoodBarcode")
      If IsNothing(ds) = False Then
        dvGoodBarcode = New DataView(ds.Tables(0))
        mAllRecord += dvGoodBarcode.Count
      End If

      lblComment.Text = "กำลังเตรียมข้อมูล...UnitInfo"
      Application.DoEvents()
      ds = pService.SelectData("Drug", "SELECT unitCode, unitDesc, unitFactor FROM UnitInfo")
      If IsNothing(ds) = False Then
        dvUnitInfo = New DataView(ds.Tables(0))
        mAllRecord += dvUnitInfo.Count
      End If

      lblComment.Text = "กำลังเตรียมข้อมูล...EmplInfo"
      Application.DoEvents()
      ds = pService.SelectData("Drug", "SELECT emplCode, emplName, userName, userPWD, emplID FROM EmplInfo WHERE emplStat = '1'")
      If IsNothing(ds) = False Then
        dvEmplInfo = New DataView(ds.Tables(0))
        mAllRecord += dvEmplInfo.Count
      End If

      'lblComment.Text = "กำลังเตรียมข้อมูล...CustInfo"
      'Application.DoEvents()
      'ds = pService.SelectData("Drug", "SELECT custCode, custName, custType FROM CustInfo Where custStat = '1'")
      'If IsNothing(ds) = False Then
      '  dvCustInfo = New DataView(ds.Tables(0))
      '  mAllRecord += dvCustInfo.Count
      'End If

      'lblComment.Text = "กำลังเตรียมข้อมูล...CreditInfo"
      'Application.DoEvents()
      'ds = pService.SelectData("Drug", "SELECT creditCode, creditName, percCharge FROM CreditInfo")
      'If IsNothing(ds) = False Then
      '  dvCreditInfo = New DataView(ds.Tables(0))
      '  mAllRecord += dvCreditInfo.Count
      'End If

      ' ใช้ข้อมูลจากตาราง CardInfo แทน CreditInfo
      lblComment.Text = "กำลังเตรียมข้อมูล...CardInfo"
      Application.DoEvents()
      ds = pService.SelectData("Drug", "SELECT cardCode, cardName FROM CardInfo where showOffline = '1'")
      If IsNothing(ds) = False Then
        dvCardInfo = New DataView(ds.Tables(0))
        mAllRecord += dvCardInfo.Count
      End If

    Catch ex As Exception
      MessageBox.Show("เกิดข้อผิดพลาดระหว่างเตรียมข้อมูล (" & ex.Message & ")", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      ClearField()
      Exit Sub
    End Try
    ds = Nothing
    Me.Cursor = Cursors.Default

    pOfflineUpdate = True
    btnCancel.Visible = True
    pgb1.Visible = True
    pgb2.Visible = True
    pgb2.Value = 0
    pgb2.Maximum = mAllRecord
    lblComment.Text = "กำลังอัพเดตข้อมูล โปรดรอ..."

    Dim mUpdate As String
    Dim mSqlText1(1) As String
    Dim mSqlText2(1) As String
    Dim mLine As Integer = 0

    ' ***********************
    ' backup file
    Dim mBackFileName As String
    Try
      mBackFileName = pOffLineFolder & "data" & Format(Now, "yyyyMMddHHmm") & ".mdb"
      My.Computer.FileSystem.CopyFile(pOffLineFolder & "data.mdb", mBackFileName)

    Catch ex As Exception
      MessageBox.Show(ex.Message, "Cannot backup file", MessageBoxButtons.OK, MessageBoxIcon.Stop)
      Exit Sub
    End Try

    ' start update
    Try

      ' ***********************
      ' SystInfo
      mSqlText1(0) = "Delete from SystInfo"
      mSqlText1(1) = "INSERT INTO SystInfo (branchCode, compName, branchName) VALUES ('" & pBranchCode & "', '" & pCompName & "', '" & pBranchName & "')"
      mUpdate = UpdateData(mSqlText1, "data.mdb")
      If mUpdate <> "1" Then
        MessageBox.Show("เกิดข้อผิดพลาดระหว่างอัพเดตข้อมูล (" & mUpdate & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ClearField()
        Exit Sub
      End If
      ' HistSale
      mSqlText1(0) = "Delete from SaleList"
      mSqlText1(1) = "Delete from HistSale"
      mUpdate = UpdateData(mSqlText1, "data.mdb")
      If mUpdate <> "1" Then
        MessageBox.Show("เกิดข้อผิดพลาดระหว่างอัพเดตข้อมูล (" & mUpdate & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ClearField()
        Exit Sub
      End If

      'ReDim mSqlText1(1)
      ' ******************************
      ' EmplInfo
      mSqlText1(0) = "Delete from EmplInfo"
      mSqlText1(1) = ""
      mUpdate = UpdateData(mSqlText1, "data.mdb")
      If mUpdate <> "1" Then
        MessageBox.Show("เกิดข้อผิดพลาดระหว่างอัพเดตข้อมูล (" & mUpdate & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ClearField()
        Exit Sub
      End If

      ReDim mSqlText2(dvEmplInfo.Count)

      pgb1.Maximum = dvEmplInfo.Count
      pgb1.Value = 0
      For i As Integer = 0 To dvEmplInfo.Count - 1
        With dvEmplInfo.Item(i)
          mSqlText2(i) = "INSERT INTO EmplInfo (emplCode, emplName, userName, userPWD, emplID) VALUES ('" & .Item("emplCode").ToString & "', '" & .Item("emplName").ToString & "', '" & .Item("userName").ToString & "', '" & .Item("userPWD").ToString & "', '" & .Item("emplID").ToString & "')"

        End With
        pgb1.Value += 1
        pgb2.Value += 1
        lblCount.Text = "EmplInfo " & pgb1.Value & "/" & pgb1.Maximum
        Application.DoEvents()
        If mCancel = True Then
          ClearField()
          Exit Sub
        End If
      Next i

      Me.Cursor = Cursors.WaitCursor
      btnCancel.Visible = False
      mUpdate = UpdateData(mSqlText2, "data.mdb")
      If mUpdate <> "1" Then
        MessageBox.Show("เกิดข้อผิดพลาดระหว่างอัพเดตข้อมูล (" & mUpdate & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ClearField()
        Exit Sub
      End If
      Me.Cursor = Cursors.Default
      btnCancel.Visible = True

      '' ******************************
      '' CreditInfo
      'mSqlText1(0) = "Delete from CreditInfo"
      'mSqlText1(1) = ""
      'mUpdate = UpdateData(mSqlText1, "data.mdb")
      'If mUpdate <> "1" Then
      '  MessageBox.Show("เกิดข้อผิดพลาดระหว่างอัพเดตข้อมูล (" & mUpdate & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      '  ClearField()
      '  Exit Sub
      'End If

      'ReDim mSqlText2(dvCreditInfo.Count)

      'pgb1.Maximum = dvCreditInfo.Count
      'pgb1.Value = 0
      'For i As Integer = 0 To dvCreditInfo.Count - 1
      '  With dvCreditInfo.Item(i)
      '    mSqlText2(i) = "INSERT INTO CreditInfo (creditCode, creditName, perCharge) VALUES ('" & .Item("creditCode").ToString & "', '" & .Item("creditName").ToString & "', " & Val(.Item("percCharge")) & ")"
      '  End With
      '  pgb1.Value += 1
      '  pgb2.Value += 1
      '  lblCount.Text = "CreditInfo " & pgb1.Value & "/" & pgb1.Maximum
      '  Application.DoEvents()
      '  If mCancel = True Then
      '    ClearField()
      '    Exit Sub
      '  End If
      'Next i

      'Me.Cursor = Cursors.WaitCursor
      'btnCancel.Visible = False
      'mUpdate = UpdateData(mSqlText2, "data.mdb")
      'If mUpdate <> "1" Then
      '  MessageBox.Show("เกิดข้อผิดพลาดระหว่างอัพเดตข้อมูล (" & mUpdate & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      '  ClearField()
      '  Exit Sub
      'End If
      'Me.Cursor = Cursors.Default
      'btnCancel.Visible = True

      ' ******************************
      ' CreditInfo
      mSqlText1(0) = "Delete from CreditInfo"
      mSqlText1(1) = ""
      mUpdate = UpdateData(mSqlText1, "data.mdb")
      If mUpdate <> "1" Then
        MessageBox.Show("เกิดข้อผิดพลาดระหว่างอัพเดตข้อมูล (" & mUpdate & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ClearField()
        Exit Sub
      End If

      ' ใช้ข้อมูลจากตาราง CardInfo แทน CreditInfo
      ReDim mSqlText2(dvCardInfo.Count)

      pgb1.Maximum = dvCardInfo.Count
      pgb1.Value = 0
      For i As Integer = 0 To dvCardInfo.Count - 1
        With dvCardInfo.Item(i)
          mSqlText2(i) = "INSERT INTO CreditInfo (creditCode, creditName, perCharge) VALUES ('" & .Item("cardCode").ToString & "', '" & Mid(.Item("cardName").ToString, 1, 30) & "', 0)"
        End With
        pgb1.Value += 1
        pgb2.Value += 1
        lblCount.Text = "CardInfo " & pgb1.Value & "/" & pgb1.Maximum
        Application.DoEvents()
        If mCancel = True Then
          ClearField()
          Exit Sub
        End If
      Next i

      Me.Cursor = Cursors.WaitCursor
      btnCancel.Visible = False
      mUpdate = UpdateData(mSqlText2, "data.mdb")
      If mUpdate <> "1" Then
        MessageBox.Show("เกิดข้อผิดพลาดระหว่างอัพเดตข้อมูล (" & mUpdate & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ClearField()
        Exit Sub
      End If
      Me.Cursor = Cursors.Default
      btnCancel.Visible = True

      ' ******************************
      ' CustInfo
      mSqlText1(0) = "Delete from CustInfo"
      mSqlText1(1) = "INSERT INTO CustInfo (custCode, custName, custType, flag) VALUES ('0', 'ทั่วไป', '1', '1')"

      mUpdate = UpdateData(mSqlText1, "data.mdb")
      If mUpdate <> "1" Then
        MessageBox.Show("เกิดข้อผิดพลาดระหว่างอัพเดตข้อมูล (" & mUpdate & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ClearField()
        Exit Sub
      End If

      'ReDim mSqlText2(dvCustInfo.Count)

      'pgb1.Maximum = dvCustInfo.Count
      'pgb1.Value = 0
      'For i As Integer = 0 To dvCustInfo.Count - 1
      '  With dvCustInfo.Item(i)
      '    mSqlText2(i) = "INSERT INTO CustInfo (custCode, custName, custType, flag) VALUES ('" & .Item("custCode").ToString & "', '" & .Item("custName").ToString & "', '" & .Item("custType").ToString & "', '1')"
      '  End With

      '  pgb1.Value += 1
      '  pgb2.Value += 1
      '  lblCount.Text = "CustInfo " & pgb1.Value & "/" & pgb1.Maximum
      '  Application.DoEvents()
      '  If mCancel = True Then
      '    ClearField()
      '    Exit Sub
      '  End If
      'Next i

      'Me.Cursor = Cursors.WaitCursor
      'btnCancel.Visible = False
      'mUpdate = UpdateData(mSqlText2, "data.mdb")
      'If mUpdate <> "1" Then
      '  MessageBox.Show("เกิดข้อผิดพลาดระหว่างอัพเดตข้อมูล (" & mUpdate & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      '  ClearField()
      '  Exit Sub
      'End If
      'Me.Cursor = Cursors.Default
      'btnCancel.Visible = True

      ' ******************************
      ' UnitInfo
      mSqlText1(0) = "Delete from UnitInfo"
      mSqlText1(1) = ""
      mUpdate = UpdateData(mSqlText1, "data.mdb")
      If mUpdate <> "1" Then
        MessageBox.Show("เกิดข้อผิดพลาดระหว่างอัพเดตข้อมูล (" & mUpdate & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ClearField()
        Exit Sub
      End If

      ReDim mSqlText2(dvUnitInfo.Count)

      pgb1.Maximum = dvUnitInfo.Count
      pgb1.Value = 0
      For i As Integer = 0 To dvUnitInfo.Count - 1
        With dvUnitInfo.Item(i)
          mSqlText2(i) = "INSERT INTO UnitInfo (unitCode, unitDesc, unitFactor) VALUES ('" & .Item("unitCode").ToString & "', '" & Replace(.Item("unitDesc").ToString, "'", "''") & "', " & CInt(.Item("unitFactor")) & ")"
        End With
        pgb1.Value += 1
        pgb2.Value += 1
        lblCount.Text = "UnitInfo " & pgb1.Value & "/" & pgb1.Maximum
        Application.DoEvents()
        If mCancel = True Then
          ClearField()
          Exit Sub
        End If
      Next i

      Me.Cursor = Cursors.WaitCursor
      btnCancel.Visible = False
      mUpdate = UpdateData(mSqlText2, "data.mdb")
      If mUpdate <> "1" Then
        MessageBox.Show("เกิดข้อผิดพลาดระหว่างอัพเดตข้อมูล (" & mUpdate & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ClearField()
        Exit Sub
      End If
      Me.Cursor = Cursors.Default
      btnCancel.Visible = True

      ' ****************************
      ' GoodInfo
      mSqlText1(0) = "Delete from GoodInfo"
      mSqlText1(1) = ""
      mUpdate = UpdateData(mSqlText1, "data.mdb")
      If mUpdate <> "1" Then
        MessageBox.Show("เกิดข้อผิดพลาดระหว่างอัพเดตข้อมูล (" & mUpdate & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ClearField()
        Exit Sub
      End If

      ReDim mSqlText2(dvGoodInfo.Count)

      pgb1.Maximum = dvGoodInfo.Count
      pgb1.Value = 0
      For i As Integer = 0 To dvGoodInfo.Count - 1
        With dvGoodInfo.Item(i)
          mSqlText2(i) = "INSERT INTO GoodInfo (goodCode, goodName, unitCode, unitCost) VALUES ('" & .Item("goodCode").ToString & "', '" & Replace(.Item("goodName").ToString, "'", "''") & "', '" & .Item("unitCode").ToString & "', " & CDbl(.Item(mUnitCostField)) & ")"
        End With
        pgb1.Value += 1
        pgb2.Value += 1
        lblCount.Text = "GoodInfo " & pgb1.Value & "/" & pgb1.Maximum
        Application.DoEvents()
        If mCancel = True Then
          ClearField()
          Exit Sub
        End If
      Next i

      Me.Cursor = Cursors.WaitCursor
      btnCancel.Visible = False
      mUpdate = UpdateData(mSqlText2, "data.mdb")
      If mUpdate <> "1" Then
        MessageBox.Show("เกิดข้อผิดพลาดระหว่างอัพเดตข้อมูล (" & mUpdate & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ClearField()
        Exit Sub
      End If
      Me.Cursor = Cursors.Default
      btnCancel.Visible = True

      ' ****************************
      ' GoodBarcode
      mSqlText1(0) = "Delete from GoodBarcode"
      mSqlText1(1) = ""
      mUpdate = UpdateData(mSqlText1, "data.mdb")
      If mUpdate <> "1" Then
        MessageBox.Show("เกิดข้อผิดพลาดระหว่างอัพเดตข้อมูล (" & mUpdate & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ClearField()
        Exit Sub
      End If

      ReDim mSqlText2(dvGoodBarcode.Count)

      pgb1.Maximum = dvGoodBarcode.Count
      pgb1.Value = 0
      For i As Integer = 0 To dvGoodBarcode.Count - 1
        With dvGoodBarcode.Item(i)
          mSqlText2(i) = "INSERT INTO GoodBarcode (barCode, goodCode, goodAmou, unitCode, price) VALUES ('" & .Item("barCode").ToString & "', '" & .Item("goodCode").ToString & "', " & CInt(.Item("goodAmou")) & ", '" & .Item("unitCode").ToString & "', " & CDbl(.Item(mPriceField)) & ")"
        End With
        pgb1.Value += 1
        pgb2.Value += 1
        lblCount.Text = "GoodBarcode " & pgb1.Value & "/" & pgb1.Maximum
        Application.DoEvents()
        If mCancel = True Then
          ClearField()
          Exit Sub
        End If
      Next i

      Me.Cursor = Cursors.WaitCursor
      btnCancel.Visible = False
      mUpdate = UpdateData(mSqlText2, "data.mdb")
      If mUpdate <> "1" Then
        MessageBox.Show("เกิดข้อผิดพลาดระหว่างอัพเดตข้อมูล (" & mUpdate & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ClearField()
        Exit Sub
      End If
      Me.Cursor = Cursors.Default
      btnCancel.Visible = True

      ' ลบไฟล์ backup
      If My.Computer.FileSystem.FileExists(mBackFileName) = True Then
        My.Computer.FileSystem.DeleteFile(mBackFileName)
      End If
      'Try
      '  If My.Computer.FileSystem.FileExists(mBackFileName) = True Then
      '    My.Computer.FileSystem.DeleteFile(mBackFileName)
      '  End If
      'Catch ex As Exception
      '  MessageBox.Show(ex.Message, "Cannot backup file", MessageBoxButtons.OK, MessageBoxIcon.Stop)
      '  Exit Sub
      'End Try

      dvEmplInfo = Nothing
      dvGoodInfo = Nothing
      dvGoodBarcode = Nothing
      dvUnitInfo = Nothing
      dvCreditInfo = Nothing
      'dvCustInfo = Nothing

      pOfflineUpdate = False

      btnCancel.Visible = False

      '' ########################
      '' Compact data 
      '' ให้ add references "Microsoft Jet and Replication Objects 2.6 library" ในแทป Component
      '' ถ้าเปิดฟังชั่นนี้ แล้วเครื่องสาขาอัพเดตไม่ได้ requires ADODB ให้เซท copy local เป็น true ในหน้าต่าง properties

      'Me.Cursor = Cursors.WaitCursor
      'btnCancel.Visible = False

      'If My.Computer.FileSystem.FileExists(pOffLineFolder & "data.mdb") = True Then
      '  ' ลบไฟล์เดิมถ้ามี
      '  If My.Computer.FileSystem.FileExists(pOffLineFolder & "newData.mdb") = True Then
      '    My.Computer.FileSystem.DeleteFile(pOffLineFolder & "newData.mdb")
      '  End If

      '  lblCount.Text = "Compact Data..."
      '  Application.DoEvents()

      '  Try
      '    Dim jro As JRO.JetEngine
      '    jro = New JRO.JetEngine()

      '    jro.CompactDatabase("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pOffLineFolder & "data.mdb", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pOffLineFolder & "newdata.mdb" & ";Jet OLEDB:Engine Type=5")

      '    lblCount.Text = "Compact data complete"
      '    Application.DoEvents()
      '  Catch ex As Exception
      '    MessageBox.Show(ex.Message, "Cannot compact data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      '  End Try
      'End If

      '' เปลี่ยนชื่อไฟล์เก่าและไฟล์ใหม่
      'Try
      '  If My.Computer.FileSystem.FileExists(pOffLineFolder & "tempData.mdb") = True Then
      '    My.Computer.FileSystem.DeleteFile(pOffLineFolder & "tempData.mdb")
      '  End If
      '  My.Computer.FileSystem.RenameFile(pOffLineFolder & "data.mdb", "tempData.mdb")
      '  My.Computer.FileSystem.RenameFile(pOffLineFolder & "newData.mdb", "data.mdb")

      '  lblCount.Text = "Change data file complete"
      '  Application.DoEvents()

      'Catch ex As Exception
      '  MessageBox.Show(ex.Message, "Cannot change data file", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      'End Try
      '' ########################

      ' เก็บข้อมูลวันที่ที่อัพเดต
      ' ใช้วันที่และเวลาของ server
      pServerDateTime = pService.ServerDateTime

      Microsoft.Win32.Registry.SetValue(pRegistry, "OfflineDate", pServerDateTime.Date)

      Me.Cursor = Cursors.Default

      MessageBox.Show("อัพเดตฐานข้อมูล Offline เรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Me.Close()

    Catch ex As Exception
      MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      ClearField()
    End Try
  End Sub

  Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    If MessageBox.Show("ยืนยันยกเลิกการอัพเดต", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
      mCancel = True
    End If
  End Sub

  Private Sub frm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    If btnCancel.Visible = True Then
      MessageBox.Show("กรุณายกเลิกการอัพเดต ก่อนปิดหน้าต่าง", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      e.Cancel = True
    End If
  End Sub

  Private Sub frmDownloadData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Icon = frmMain.Icon

    ClearField()

    CheckPriv()
  End Sub

  Private Sub CheckPriv()
    ' Edit
    If InStr(pUserPriv, Me.Tag.ToString & "E") > 0 Then
      btnUpdate.Enabled = True
    Else
      btnUpdate.Enabled = False
    End If
  End Sub

  Private Sub ClearField()
    pOfflineUpdate = False
    mCancel = False
    btnCancel.Visible = False
    pgb1.Value = 0
    pgb2.Value = 0
    btnUpdate.Visible = True
    lblCount.Text = ""
    lblComment.Text = "กรุณาปิดโปรแกรม DrugFront Offline ก่อนทำการอัพเดต"
    Me.Cursor = Cursors.Default
  End Sub

  'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
  '  Dim mGet() As String
  '  mGet = pService.GetData("Drug", "Select privCode From EmplInfo where emplCode = '727'")
  '  Dim mPrivCode As String
  '  mPrivCode = mGet(1)
  '  Dim mSqlText As String
  '  mSqlText = "Select emplCode From EmplInfo3"
  '  Dim objDataSet As New DataSet
  '  Try
  '    Dim objConnect As New OleDb.OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=" & pOffLineFolder & "dbEmpl.mdb;Persist Security Info=False")
  '    objConnect.Open()

  '    Dim objDataAdapter As New OleDb.OleDbDataAdapter
  '    objDataAdapter.SelectCommand = New OleDb.OleDbCommand
  '    objDataAdapter.SelectCommand.Connection = objConnect
  '    objDataAdapter.SelectCommand.CommandText = mSqlText
  '    objDataAdapter.SelectCommand.CommandType = CommandType.Text
  '    objDataAdapter.Fill(objDataSet, "MyTable")
  '  Catch ex As Exception
  '    objDataSet = Nothing
  '  End Try

  '  If IsNothing(objDataSet) = False Then
  '    Dim mEmplCode As String
  '    Dim mUpdate As String
  '    Dim mSql(1) As String
  '    Dim dv As New DataView(objDataSet.Tables(0))
  '    For i As Integer = 0 To dv.Count - 1
  '      mEmplCode = dv.Item(i).Item("emplCode").ToString
  '      mSql(1) = "Update EmplInfo set privCode = '" & mPrivCode & "' where emplCode = '" & mEmplCode & "'"
  '      mUpdate = pService.UpdateData("Drug", mSql)
  '      If mUpdate = "0" Then
  '        MessageBox.Show(mUpdate)
  '      End If
  '    Next
  '    MessageBox.Show("Finish")
  '    dv = Nothing
  '  End If
  '  objDataSet = Nothing
  'End Sub


End Class