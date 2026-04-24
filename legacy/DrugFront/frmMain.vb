Imports System.Net

Public Class frmMain

  Dim mAnnoText, mAnnoMessage As String
  Dim mShowLength As Integer

  Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    ' หา screen aspect ratio
    Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
    Dim mGCD As Integer
    mGCD = GCD(screenWidth, screenHeight) ' function คำนวณหา screen ratio
    pScreenRatio = (screenWidth / mGCD) & ":" & (screenHeight / mGCD)
    ' ถ้าจอมีขนาด 4:3 ให้ซ่อน toolbar เพื่อให้มีเนื้อที่พอแสดงหน้าขาย
    If pScreenRatio = "4:3" Then
      ToolStrip1.Visible = False
    End If

    Me.Text = Application.ProductName & " " & Application.ProductVersion

    pRegistry = "HKEY_CURRENT_USER\Software\MySoftHouse\DrugPOS\" & pAppName

    ' ตรวจสอบการลงทะเบียนใช้โปรแกรม
    pRegisterNumber = CStr(Microsoft.Win32.Registry.GetValue(pRegistry, "RegisterNumber", ""))
    If pRegisterNumber = "" OrElse CheckRegister(pRegisterNumber) = False Then
      MessageBox.Show("กรุณาลงทะเบียนโปรแกรม ก่อนเข้าใช้งาน", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End
    End If

    pBranchCode = CStr(Microsoft.Win32.Registry.GetValue(pRegistry, "BranchCode", ""))
    If pBranchCode = "" Then
      MessageBox.Show("ข้อมูลการลงทะเบียนโปรแกรมไม่สมบูรณ์ กรุณาลงทะเบียนใหม่", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End
    End If

    pServerAddr = Microsoft.Win32.Registry.GetValue(pRegistry, "ServerAddr", "").ToString
    If pServerAddr = "" Then
      MessageBox.Show("ข้อมูลการลงทะเบียนโปรแกรมไม่สมบูรณ์ กรุณาลงทะเบียนใหม่", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End
    End If

    pServiceAddr = pServerAddr & "/MyService/Service.asmx"
    pGoodImageFolder = pServerAddr & "/DrugPOS/GoodPictures"
    pEmplImageFolder = pServerAddr & "/DrugPOS/EmployeePictures"
    pPrinterPort = Microsoft.Win32.Registry.GetValue(pRegistry, "PrinterPort", "")

    ' เปลี่ยนไปใช้ protocol TLS 1.1 (protocol เดิมเป็น SSL 3 และ TLS 1.0)
    ServicePointManager.Expect100Continue = True
    ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)

    Try
      pService.Url = pServiceAddr
      pServerDateTime = pService.ServerDateTime
    Catch ex As Exception
      MessageBox.Show("ไม่สามารถติดต่อกับ Server ได้ในขณะนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
      End
    End Try

    Dim mGet() As String
    Try
      ' ตรวจสอบการลงทะเบียน ##############
      Dim mRegiNo As Integer
      Dim mRegiStat As String
      mRegiNo = CInt(Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\Software\MySoftHouse\DrugPOS\" & pAppName, "RegiNo", ""))
      mGet = pService.GetData("Drug", "Select regiStat from RegisterInfo where registerNumb = '" & pRegisterNumber & "' and appName = '" & pAppName & "' and regiNo = " & mRegiNo)
      If mGet(0) <> "1" Then
        MessageBox.Show("ไม่มีข้อมูลลงทะเบียน", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End
      Else
        mRegiStat = mGet(1)
        ' ถ้ายังไม่อนุมัติ
        If mRegiStat <> "2" Then
          Select Case mRegiStat
            Case "0"
              MessageBox.Show("ข้อมูลลงทะเบียนถูกยกเลิก ท่านต้องลงทะเบียนใหม่", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
              End
            Case "1"
              MessageBox.Show("ข้อมูลลงทะเบียนยังไม่ได้รับการอนุมัติให้เข้าใช้งานโปรแกรม", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
              End
            Case Else
              MessageBox.Show("ข้อมูลลงทะเบียนผิดพลาด ท่านต้องลงทะเบียนใหม่", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
              End
          End Select
        End If
      End If
      ' ##########################

      ' เลขลำดับเครื่องบันทึกเงินสด default "1"
      pPOSNo = CStr(Microsoft.Win32.Registry.GetValue(pRegistry, "POSNo", "1"))
      ' เลขเครื่องบันทึกเงินสด
      pPOSNumber = CStr(Microsoft.Win32.Registry.GetValue(pRegistry, "POSNumber", "xxxxx"))

      pOffLineFolder = CStr(Microsoft.Win32.Registry.GetValue(pRegistry, "OffLineFolder", ""))
      If pOffLineFolder = "" Then
        pOffLineFolder = "c:\DrugFrontOffLine\"
      Else
        If Mid(pOffLineFolder, pOffLineFolder.Length, 1) <> "\" Then
          pOffLineFolder = pOffLineFolder & "\"
        End If
      End If

      pCurrentVersion = CStr(Microsoft.Win32.Registry.GetValue(pRegistry, "CurrentVersion", ""))
      pDefaultReportPrinterName = CStr(Microsoft.Win32.Registry.GetValue(pRegistry, "DefaultReportPrinterName", ""))

      Dim ds As New DataSet
      Dim dv As DataView

      ds = pService.SelectData("Drug", "Select * from SystInfo")
      If IsNothing(ds) = False Then
        dv = New DataView(ds.Tables(0))
        If dv.Count > 0 Then
          ' ************** Server in Maintenance **************
          If dv.Item(0).Item("inMaintenance") = "1" Then
            MessageBox.Show("ขณะนี้ Server อยู่ในระหว่างปรับปรุงระบบ ไม่สามารถเข้าใช้งานได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End
          End If
          ' ************** Server in Maintenance **************

          With dv.Item(0)
            pCompName = .Item("compName")
            pCompFullName = .Item("compFullName")
            pCompAddress = .Item("compAddress")
            pCompAddr2 = .Item("compAddr2")
            pCompTaxNumber = .Item("compTaxNumber")
            pBreakNumb = .Item("breakNumb")

            pBirthPointPlus = .Item("birthPointPlus")
            pBahtPerPoint = .Item("bahtPerPoint")
            pEmplBuyLimit = .Item("emplBuyLimit")
            ' หารอบวันที่ให้สิทธิซื้อสวัสดิการพนักงาน
            Dim mStartDay As Integer
            Dim mEndDay As Integer
            mStartDay = .Item("startDayLimit")
            mEndDay = .Item("endDayLimit")

            pStartDateLimit = DateSerial(pServerDateTime.Year + 543, pServerDateTime.Month, mStartDay)
            pEndDateLimit = DateSerial(pServerDateTime.Year + 543, pServerDateTime.Month + 1, mEndDay)
            ' ตรวจสอบรอบวัน ต้องอยู่ระหว่างวันที่ปัจจุบัน (วันที่ปัจจุบัน ต้องมากกว่าหรือเท่ากับวันแรกที่กำหนด) ถ้ามากกว่าต้องลดเดือนลง 1 เดือน
            If pStartDateLimit > pServerDateTime.Date Then
              pStartDateLimit = pStartDateLimit.AddMonths(-1)
              pEndDateLimit = pEndDateLimit.AddMonths(-1)
            End If

            pAutoUploadSale = .Item("autoUploadSale")
            pWholeBahtPerPoint = .Item("wholeBahtPerPoint")
            pNewServerAddr = .Item("newServerAddr")
            pPricePerOneBuyExchange = .Item("pricePerOneBuyExchange")
            pDayUseBuyExchange = .Item("dayUseBuyExchange")
            pShiptoPOLifespan = .Item("shiptoPOLifespan")
            pVat = .Item("vat")
            pCompName1 = .Item("compName1")
            pHugName = .Item("HugName")
            pHugAddress = .Item("HugAddress")
            pHugTaxNumber = .Item("HugTaxNumber")
            pPerPrice1ToPrice0 = .Item("perPrice1ToPrice0")

            pMembPrice = .Item("membPrice")
            pMembExtraPoint = .Item("freeMembPoint")
          End With
        Else
          MessageBox.Show("ไม่พบข้อมูลในไฟล์ระบบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
          End
        End If
        dv = Nothing
      Else
        MessageBox.Show("Error when select data from table SystInfo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End
      End If
      ds = Nothing

      ds = pService.SelectData("Drug", "Select * from BranchInfo where branchCode = '" & pBranchCode & "'")
      If IsNothing(ds) = False Then
        dv = New DataView(ds.Tables(0))
        If dv.Count > 0 Then

          With dv.Item(0)
            pBranchIndex = .Item("branchIndex")
            pBranchName = .Item("branchName")
            pBranchAddress = .Item("branchAddress")
            pBranchPhone = .Item("branchPhone")
            pBranchPrice = .Item("branchPrice")
            pBranchTypeCode = .Item("branchTypeCode")
            pAllowDisc = .Item("allowDisc")
            pAllowDiscEnter = .Item("allowDiscEnter")
            If .Item("isShipTo") = "1" Then
              pIsBranchShipTo = True
              mnuShipToRece.Visible = True
            Else
              pIsBranchShipTo = False
              mnuShipToRece.Visible = False
            End If
            pWholePriceLevel = .Item("wholePrice")
            pAllowWholePrice = .Item("allowWholePrice")
            pAllowFingerScan = .Item("allowFingerScan")
            If pAllowFingerScan = "1" Then ' เฉพาะสาขาที่อนุญาตให้ใช้เครื่องสแกนนิ้วมือ
              mnuFingerPrintEnroll.Visible = True
            Else
              mnuFingerPrintEnroll.Visible = False
            End If
            pAllowCheckCostAndPrice = .Item("allowCheckCostAndPrice")
            pBillPrint = .Item("billPrint")
            pOnlinePriceLevel = .Item("onlinePrice")
            pAllowOnlinePrice = .Item("allowOnlinePrice")
            pAllowBuyExchange = .Item("allowBuyExchange")
            pAllowO2OSale = .Item("allowO2OSale")
            pBranchGroupCode = .Item("branchGroupCode")
            pAllowEmplPro = .Item("allowEmplPro")
            pTaxBranchNo = .Item("taxBranchNo")
            pAllowTaxInvoice = .Item("allowTaxInvoice")
            pAllowOnlyMembPrice = .Item("allowOnlyMembPrice")

            pIsFranchise = .Item("isFranchise")
          End With
        Else
          MessageBox.Show("ไม่พบข้อมูลสาขา", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
          End
        End If
        dv = Nothing
      Else
        MessageBox.Show("Error when select data from table BranchInfo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End
      End If
      ds = Nothing

      Dim mDate As Date
      Dim dsBranch As New DataSet
      dsBranch = pService.SelectData("Drug", "SELECT branchIndex, saleDate FROM BranchInfo WHERE branchCode = '" & pBranchCode & "'")
      If IsNothing(dsBranch) = False Then
        Dim dvBranch As New DataView(dsBranch.Tables(0))
        If dvBranch.Count > 0 Then
          mDate = CDate(dvBranch.Item(0).Item("saleDate"))

          If pAllowTaxInvoice = "0" Then
            ' เลขที่ใบขาย ปรับตัวเลขเริ่ม 1 ใหม่ทุกวัน
            If Format(mDate, "yyyyMMdd") < Format(pServerDateTime, "yyyyMMdd") Then
              Dim mSqlText(1) As String
              mSqlText(0) = "UPDATE BranchInfo SET saleNumb = 1, saleDate = '" & MDYStr(pServerDateTime.Date) & "' WHERE branchCode = '" & pBranchCode & "'"
              Dim mRet As String
              mRet = pService.UpdateData("Drug", mSqlText)
              If mRet = "1" Then
                pPreSaleNumb = Mid((1000 + pBranchIndex).ToString, 2, 3) & Format(pServerDateTime.Date, "yyMMdd")

              Else
                MessageBox.Show(mRet, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
              End If
            Else
              pPreSaleNumb = Mid((1000 + pBranchIndex).ToString, 2, 3) & Format(mDate, "yyMMdd")
            End If
          Else
            ' เลขที่ใบกำกับภาษี ปรับตัวเลขเริ่ม 1 ใหม่ทุกเดือน
            If Format(mDate, "yyyyMM") < Format(pServerDateTime, "yyyyMM") Then
              Dim mSqlText(1) As String
              mSqlText(0) = "UPDATE BranchInfo SET saleNumb = 1, taxInvoiceNumb = 1, saleDate = '" & MDYStr(pServerDateTime.Date) & "' WHERE branchCode = '" & pBranchCode & "'"
              Dim mRet As String
              mRet = pService.UpdateData("Drug", mSqlText)
              If mRet = "1" Then
                ' เลขที่ใบกำกับภาษีอย่างย่อ (ใช้แทนเลขที่ใบขาย) => เลขสาขา(4ตำแหน่ง)+P+เลขลำดับเครื่องบันทึกเงินสด+ปี+เดือน+จำนวนนับ(5ตำแหน่ง) เช่น 0001 P1 2301 00001
                pPreSaleNumb = Mid((10000 + pBranchIndex).ToString, 2) & "P" & pPOSNo & pServerDateTime.ToString("yyMM", New System.Globalization.CultureInfo("en-US"))
                ' เลขที่ใบกำกับภาษีเต็มรูปแบบ => ปี+เดือน+B+เลขสาขา(4ตำแหน่ง)+จำนวนนับ(5ตำแหน่ง) เช่น 2301 B0001 00001
                pPreTaxInvoiceNumb = pServerDateTime.ToString("yyMM", New System.Globalization.CultureInfo("en-US")) & "B" & Mid((10000 + pBranchIndex).ToString, 2)
              Else
                MessageBox.Show(mRet, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
              End If
            Else
              pPreSaleNumb = Mid((10000 + pBranchIndex).ToString, 2) & "P" & pPOSNo & mDate.ToString("yyMM", New System.Globalization.CultureInfo("en-US"))
              pPreTaxInvoiceNumb = mDate.ToString("yyMM", New System.Globalization.CultureInfo("en-US")) & "B" & Mid((10000 + pBranchIndex).ToString, 2)
            End If
          End If
        Else
          MessageBox.Show("Error in create sale number", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
          End
        End If
        dvBranch = Nothing
      Else
        MessageBox.Show("Error in create sale number", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End
      End If
      dsBranch = Nothing
    Catch ex As Exception
      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End
    End Try

    GetAnnounce()

    ' สาขา Herbal Tech ให้เปลี่ยน background color
    If pBranchGroupCode = "7" Then
      lblBranchName.BackColor = Color.FromArgb(170, 203, 170)
      lblBranchName.Text = "Herbal Tech : " & pBranchName
    Else
      lblBranchName.BackColor = Color.Red
      lblBranchName.Text = pBranchName
    End If
    ' แสดงไอคอนพิเศษ
    ' ออกใบกำกับภาษี
    If pAllowTaxInvoice = "1" Then
      tssSystemIcon1.Image = My.Resources.tax32
    End If
    ' แยกราคาสมาชิก-ทั่้วไป
    If pAllowOnlyMembPrice = "1" Then
      tssSystemIcon2.Image = My.Resources.member32
    End If
    ' สาขาแฟรนไชน์
    If pIsFranchise = "1" Then
      tssSystemIcon3.Image = My.Resources.franchise32
      mnuRpStockOnhand.Visible = True
      mnuRpFCSale.Visible = True
    Else
      mnuRpStockOnhand.Visible = False
      mnuRpFCSale.Visible = False
    End If

    CheckLogin()
    CheckPriv()

    InitData()
    ShowVersionUpdate(pCurrentVersion)

  End Sub

  ' function คำนวณหา screen ratio
  Private Function GCD(ByVal a As Integer, ByVal b As Integer) As Integer
    If b = 0 Then
      Return a
    Else
      Return GCD(b, a Mod b)
    End If
  End Function

  Private Function CheckRegister(ByVal RegisterCode As String) As Boolean
    Try
      Dim disk As System.Management.ManagementObject = New System.Management.ManagementObject(String.Format("Win32_Logicaldisk='{0}'", "C:"))
      'Dim mVolumeName As String = disk.Properties("VolumeName").Value.ToString
      ' get hard disk serial number
      Dim mSerialNumber As String = disk.Properties("VolumeSerialNumber").Value.ToString
      ' remove -
      RegisterCode = RegisterCode.Replace("-", "")
      ' flip registercode
      RegisterCode = RegisterCode.Substring(8) & RegisterCode.Substring(0, 8)

      Dim mRegisterText As String
      mRegisterText = (CLng(RegisterCode) + 1035024460199703).ToString
      ' convert to character
      Dim mRegisterSerial As String = ""
      For i As Integer = 0 To mRegisterText.Length - 1 Step 2
        mRegisterSerial = mRegisterSerial & Chr(CInt(mRegisterText.Substring(i, 2)))
      Next
      ' compare
      If mRegisterSerial = mSerialNumber Then
        Return True
      Else
        Return False
      End If
    Catch ex As Exception
      'MessageBox.Show(ex.Message)
      Return False
    End Try
  End Function

  Private Sub InitData()
    Dim ds As New DataSet
    Dim dv As DataView
    ' Good Type
    ds = pService.SelectData("Drug", "SELECT typeDesc, typeCode FROM TypeInfo ORDER BY typeDesc")
    If IsNothing(ds) = False Then
      dv = New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        ReDim pGoodType(dv.Count - 1)
        For i As Integer = 0 To dv.Count - 1
          pGoodType(i).Description = dv.Item(i).Item("typeDesc").ToString
          pGoodType(i).Code = dv.Item(i).Item("typeCode").ToString
        Next
      End If
      dv = Nothing
    End If
    ds = Nothing
    ' Good Shelf
    Dim mShelfNoField As String = "shelfNo" & pBranchCode
    ds = pService.SelectData("Drug", "Select distinct " & mShelfNoField & " as shelfNo From GoodInfo where " & mShelfNoField & " <> '' and goodStat <> '0' order by " & mShelfNoField)
    If IsNothing(ds) = False Then
      dv = New DataView(ds.Tables(0))
      ReDim pGoodShelf(dv.Count - 1)
      If dv.Count > 0 Then
        For i As Integer = 0 To dv.Count - 1
          pGoodShelf(i).ShelfNo = dv.Item(i).Item("shelfNo")
        Next
      End If
      dv = Nothing
    End If
    ds = Nothing

  End Sub

  Private Sub CheckLogin()
    Dim LogInWindow As New frmLogIn
    LogInWindow.ShowDialog()
    If LogInWindow.pLogIn = True Then
      tssUserName.Text = "ผู้เข้าระบบ : " & pUserName
      tssUserPosition.Text = "ตำแหน่งงาน : " & pUserPosition
      ' ใช้วันที่และเวลาของ server
      pServerDateTime = pService.ServerDateTime

      tssDate.Text = "เวลาล๊อคอิน : " & ThaiDate(pServerDateTime.Date)
      tssTime.Text = Format(pServerDateTime, "HH:mm")
      ' แสดงรูปผู้ log in
      Try
        Dim mEmplImageURL As String
        mEmplImageURL = pEmplImageFolder & "/" & pUserID & ".png"
        Dim mImage As New DownLoadImage(mEmplImageURL)
        Dim mMemStream As IO.MemoryStream = mImage.BeginDownLoad
        tbnUserPicture.Image = Image.FromStream(mMemStream)
        tbnUserPicture.Visible = True

      Catch ex As Exception
        tbnUserPicture.Visible = False
        'MessageBox.Show(ex.Message)
      End Try
      ' แสดงประกาศ
      If mAnnoText.Length > 0 Then
        pMessageBox = New MyMessageBox(mAnnoText, "ประกาศ-ข่าวสาร", MessageBoxButtons.OK, MessageBoxIcon.Information)
        pMessageBox.ShowDialog()
      End If
    Else
      End
    End If
  End Sub

  Private Sub CheckPriv() ' ตรวจสอบสิทธิใช้โปรแกรม
    For Each mMenu As ToolStripMenuItem In MenuStrip1.Items
      CheckSubMenu(mMenu)
    Next
    ' Toolbar
    CheckToolBarPriv()
  End Sub

  Private Sub CheckSubMenu(ByVal subMenu As ToolStripItem) ' recursive สำหรับวนลูปเมนู เพื่อตรวจสิทธิใช้โปรแกรมในเมนูที่ย่อยลงไป
    If subMenu.GetType().Equals(GetType(ToolStripMenuItem)) Then
      For Each item As ToolStripItem In DirectCast(subMenu, ToolStripMenuItem).DropDownItems
        CheckSubMenu(item)
      Next
      If IsNothing(subMenu.Tag) = False Then
        If InStr(pUserPriv, subMenu.Tag.ToString) > 0 Then
          subMenu.Enabled = True
        Else
          subMenu.Enabled = False
        End If
      End If
    End If
  End Sub

  Private Sub CheckToolBarPriv()
    For Each item As ToolStripItem In ToolStrip1.Items
      If IsNothing(item.Tag) = False Then
        If InStr(pUserPriv, item.Tag.ToString) > 0 Then
          item.Enabled = True
        Else
          item.Enabled = False
        End If
      End If
    Next
  End Sub

  Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
    Me.Close()
  End Sub

  Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    Dim mForm As Form
    For Each mForm In Me.MdiChildren
      ' ตรวจสอบ form ขายหน้าร้าน ต้องไม่มีรายการขายค้างอยู่
      If mForm.Name = "frmSale" Then
        If frmSale.dtgSale.Rows.Count > 0 Then
          e.Cancel = True
          Exit Sub
        End If
      End If
      If mForm.Name = "frmDiarySaleNew" Then
        If frmSale.dtgSale.Rows.Count > 0 Then
          e.Cancel = True
          Exit Sub
        End If
      End If
    Next
    If pOfflineUpdate = True Then
      MessageBox.Show("กรุณายกเลิกการ Update ฐานข้อมูล Offline ก่อนปิดโปรแกรม", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      e.Cancel = True
      Exit Sub
    End If

    pMessageBox = New MyMessageBox("ยืนยันปิดโปรแกรม", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
    If pMessageBox.ShowDialog = Windows.Forms.DialogResult.OK Then
      ' บันทึกเวลา logout
      If pUserCode <> "5" Then
        ' ใช้วันที่และเวลาของ server
        pServerDateTime = pService.ServerDateTime
        Dim mSqlText(1) As String
        mSqlText(0) = "UPDATE LogRecord set logOutDate = '" & MDYStr(pServerDateTime.Date) & "', logOutTime = '" & Format(pServerDateTime, "HH:mm") & "' WHERE logSession = '" & pLogSession & "'"

        Dim mUpdate As String
        mUpdate = pService.UpdateData("Drug", mSqlText)
        If mUpdate <> "1" Then
          MessageBox.Show("Cannot insert login time", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
      End If

      For Each mForm In Me.MdiChildren
        mForm.Close()
      Next
      e.Cancel = False
    Else
      e.Cancel = True
    End If
  End Sub

  Private Sub ShowVersionUpdate(ByVal CurrentVersion As String)
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select * from AppVersionUpdate Where appName = '" & pAppName & "' and appVersion = '" & Application.ProductVersion & "' and appVersion <> '" & CurrentVersion & "'") ' แสดงเฉพาะหลังอัพเดต (ไม่ใช่เวอร์ชั่นก่อนหน้า)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        With dv.Item(0)
          pMessageBox = New MyMessageBox("Version " & .Item("appVersion") & vbCrLf & .Item("upDesc") & vbCrLf & .Item("updateDate"), "Version update", MessageBoxButtons.OK, MessageBoxIcon.Information)
          pMessageBox.ShowDialog()
          ' เก็บข้อมูล version ใหม่
          Microsoft.Win32.Registry.SetValue(pRegistry, "CurrentVersion", Application.ProductVersion)
        End With
      End If
      dv = Nothing
    End If
    ds = Nothing
  End Sub

  Private Sub mnuDiarySale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDiarySale.Click
    If CheckOffLineData() = True Then
      MessageBox.Show("มีข้อมูล Off Line ที่ยังไม่ได้ Upload ไปยัง Server กรุณาทำการ Upload ไปยัง Server ก่อนทำการขายหน้าร้าน", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If

    ' วันที่ที่ได้อัพเดตฐานข้อมูล Offline ล่าสุด
    ' ใช้วันที่และเวลาของ server
    pServerDateTime = pService.ServerDateTime

    Try
      pOfflineDate = CStr(Microsoft.Win32.Registry.GetValue(pRegistry, "OffLineDate", ""))
    Catch ex As Exception
      pOfflineDate = Nothing
    End Try
    ' ถ้าวันสุดท้ายที่อัพเดตน้อยกว่าวันนี้ ให้เตือนอัพเดต
    If pOfflineUpdate = False AndAlso pOfflineDate < pServerDateTime.Date Then
      Dim mAnswer As DialogResult

      pMessageBox = New MyMessageBox("กรุณาอัพเดตฐานข้อมูล Offline ก่อนทำการขาย", "คำเตือน", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
      mAnswer = pMessageBox.ShowDialog
      If mAnswer = Windows.Forms.DialogResult.Yes Then
        mnuUpdateOfflineNew.PerformClick()
        Exit Sub
      ElseIf mAnswer = Windows.Forms.DialogResult.Cancel Then
        Exit Sub
      End If
    End If

    frmSale.MdiParent = Me
    frmSale.Show()
    frmSale.WindowState = FormWindowState.Maximized
    frmSale.Activate()
    frmSale.BringToFront()
  End Sub

  Private Function CheckOffLineData() As Boolean
    ' ตรวจสอบว่ามีข้อมูล off line ที่ยังไม่ได้ upload หรือไม่
    Dim mGet() As String
    Dim mRecordCount As Integer
    If My.Computer.FileSystem.FileExists(pOffLineFolder & "data.mdb") = True Then
      mGet = GetData("SELECT count(*) FROM HistSale WHERE flag = '1'")
      If mGet(0) = "1" Then
        mRecordCount += CInt(mGet(1))
      End If
      mGet = GetData("SELECT count(*) FROM ETimeStamp WHERE flag = '1'")
      If mGet(0) = "1" Then
        mRecordCount += CInt(mGet(1))
      End If

      If mRecordCount > 0 Then
        Return True
      Else
        Return False
      End If
    End If
  End Function

  Private Sub tbnDiarySale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnDiarySale.Click
    mnuDiarySale.PerformClick()
  End Sub

  Private Sub tbnLogInOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnLogInOut.Click
    mnuLogInOut.PerformClick()
  End Sub

  Private Sub mnuSaleCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaleCheck.Click
    frmSaleCheck.MdiParent = Me
    frmSaleCheck.Show()
    frmSaleCheck.Select()
  End Sub

  Private Sub tbnSaleCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnSaleCheck.Click
    mnuSaleCheck.PerformClick()
  End Sub

  Private Sub mnuSaleReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaleReturn.Click
    Dim fSaleReturn As New frmSaleReturn
    fSaleReturn.ShowDialog()
    fSaleReturn = Nothing
  End Sub

  Private Sub mnuGoodCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGoodCheck.Click
    Dim fGoodCheck As New frmGoodCheck
    fGoodCheck.ShowDialog()
    fGoodCheck = Nothing
  End Sub

  Private Sub tbnGoodCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnGoodCheck.Click
    mnuGoodCheck.PerformClick()
  End Sub

  Private Sub tbnCustInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnCustInfo.Click
    mnuMemberInfo.PerformClick()
  End Sub

  Private Sub mnuAccoClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAccoClose.Click
    If CheckOffLineData() = True Then
      MessageBox.Show("มีข้อมูล Off Line ที่ยังไม่ได้ Upload ไปยัง Server กรุณาทำการ Upload ไปยัง Server ก่อนทำการสรุปบัญชี", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If

    frmAccoClose.ShowDialog()
    frmAccoClose = Nothing
  End Sub

  Private Sub mnuGoodRece_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGoodRece.Click
    frmGoodRece.MdiParent = Me
    frmGoodRece.Show()
    frmGoodRece.Focus()
  End Sub

  Private Sub mnuTimeStamp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTimeStamp.Click
    If pAllowFingerScan = "1" Then
      frmTimeFingerStamp.ShowDialog()
      frmTimeFingerStamp = Nothing
    Else
      frmTimeStamp.ShowDialog()
      frmTimeStamp = Nothing
    End If
  End Sub

  Private Sub mnuGoodOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGoodOrder.Click
    frmGoodOrder.MdiParent = Me
    frmGoodOrder.Show()
    frmGoodOrder.WindowState = FormWindowState.Maximized
    frmGoodOrder.Activate()
    frmGoodOrder.BringToFront()
  End Sub

  Private Sub mnuOrderCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOrderCheck.Click
    frmOrderCheck.MdiParent = Me
    frmOrderCheck.Show()
    frmOrderCheck.WindowState = FormWindowState.Maximized
  End Sub

  Private Sub mnuRpAccoClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRpAccoClose.Click
    frmRpAccoGroupClose.MdiParent = Me
    frmRpAccoGroupClose.Show()
    frmRpAccoGroupClose.Select()
  End Sub

  Private Sub mnuReturnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReturnCheck.Click
    frmReturnCheck.MdiParent = Me
    frmReturnCheck.Show()
    frmReturnCheck.Select()
  End Sub

  Private Sub timeAnno_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timAnno.Tick
    If mAnnoText.Length > 0 Then
      ' แสดงข้อความประกาศ โดยเลื่อนจากขวาไปซ้าย
      If mShowLength >= mAnnoText.Length Then
        tssAnno.Text = tssAnno.Text & " "
        ' หากหมดข้อความที่แสดง ให้เริ่มแสดงใหม่
        If Trim(Microsoft.VisualBasic.Right(tssAnno.Text, 150)) = "" Then
          mShowLength = 0
          tssAnno.Text = ""
        End If
      Else
        tssAnno.Text = tssAnno.Text & mAnnoText.Substring(mShowLength, 1)
        mShowLength += 1
      End If
    End If
  End Sub

  Private Sub timCheckAnno_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timCheckAnno.Tick
    Dim mCurrAnno As String
    mCurrAnno = mAnnoText
    GetAnnounce()
    ' ถ้ามีประกาศใหม่ ให้แสดง
    If mAnnoText.Length > 0 AndAlso mAnnoText <> mCurrAnno Then
      pMessageBox = New MyMessageBox(mAnnoText, "ประกาศ-ข่าวสาร", MessageBoxButtons.OK, MessageBoxIcon.Information)
      pMessageBox.ShowDialog()
    End If
  End Sub

  Private Sub GetAnnounce()
    Dim mGet() As String
    mGet = pService.GetData("Drug", "SELECT annoText1, annoText2, annoText3, annoText4, annoText5 FROM SystInfo")
    If mGet(0) = "1" Then
      ' ข้อความประกาศ
      mAnnoText = ""
      mAnnoMessage = ""
      mShowLength = 0
      'tssAnno.Text = ""
      If mGet(1) <> "" OrElse mGet(2) <> "" OrElse mGet(3) <> "" OrElse mGet(4) <> "" OrElse mGet(5) <> "" Then
        If mGet(1) <> "" Then
          mAnnoText = mAnnoText & " - " & mGet(1)
          mAnnoMessage = mAnnoMessage & " - " & mGet(1)
        End If
        If mGet(2) <> "" Then
          mAnnoText = mAnnoText & " - " & mGet(2)
          mAnnoMessage = mAnnoMessage & Microsoft.VisualBasic.vbCrLf & " - " & mGet(2)
        End If
        If mGet(3) <> "" Then
          mAnnoText = mAnnoText & " - " & mGet(3)
          mAnnoMessage = mAnnoMessage & Microsoft.VisualBasic.vbCrLf & " - " & mGet(3)
        End If
        If mGet(4) <> "" Then
          mAnnoText = mAnnoText & " - " & mGet(4)
          mAnnoMessage = mAnnoMessage & Microsoft.VisualBasic.vbCrLf & " - " & mGet(4)
        End If
        If mGet(5) <> "" Then
          mAnnoText = mAnnoText & " - " & mGet(5)
          mAnnoMessage = mAnnoMessage & Microsoft.VisualBasic.vbCrLf & " - " & mGet(5)
        End If
      End If
    End If
  End Sub

  Private Sub tssAnno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tssAnno.Click
    If mAnnoText <> "" Then
      pMessageBox = New MyMessageBox(mAnnoText, "ประกาศ-ข่าวสาร", MessageBoxButtons.OK, MessageBoxIcon.Information)
      pMessageBox.ShowDialog()
    End If
  End Sub

  Private Sub mnuUpdateOfflineNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUpdateOfflineNew.Click
    frmUpdateOffline.ShowDialog()
    frmUpdateOffline = Nothing
  End Sub

  Private Sub mnuUpdateServerNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUpdateServerNew.Click
    frmUploadServer.ShowDialog()
    frmUploadServer = Nothing
  End Sub

  Private Sub mnuPrintAccoClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintAccoClose.Click
    frmPrintAccoClose.ShowDialog()
    frmPrintAccoClose = Nothing
  End Sub

  Private Sub tbnGoodAdjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnGoodAdjust.Click
    Dim fGoodAdjust As New frmGoodAdjust
    fGoodAdjust.pPassCode = pUserCode
    fGoodAdjust.ShowDialog()
    fGoodAdjust = Nothing
  End Sub

  Private Sub mnuCalMiniStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCalMiniStock.Click
    Dim fCalMiniStock As New frmCalMiniStock
    fCalMiniStock.ShowDialog()
    fCalMiniStock = Nothing
  End Sub

  Private Sub mnuCheckStockReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCheckStockReturn.Click
    frmCheckStockReturn.MdiParent = Me
    frmCheckStockReturn.Show()
    frmCheckStockReturn.Activate()
    frmCheckStockReturn.BringToFront()
  End Sub

  Private Sub mnuRpGoodNotMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRpGoodNotMove.Click
    frmRpGoodNotMove.MdiParent = Me
    frmRpGoodNotMove.Show()
    frmRpGoodNotMove.Select()
  End Sub

  Private Sub tbnTimeStamp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnTimeStamp.Click
    Dim fTimeStamp As New frmTimeStamp
    fTimeStamp.ShowDialog()
    fTimeStamp = Nothing
  End Sub

  Private Sub tbnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnExit.Click
    Me.Close()
  End Sub

  Private Sub mnuChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChangePassword.Click
    frmChangePassword.ShowDialog()
  End Sub

  Private Sub mnuMemberInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMemberInfo.Click
    frmMemberInfo.ShowDialog()
    frmMemberInfo = Nothing
  End Sub

  Private Sub mnuRpDialyAccoClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRpDialyAccoClose.Click
    frmRpAccoClose.MdiParent = Me
    frmRpAccoClose.Show()
    frmRpAccoClose.Select()
  End Sub

  Private Sub mnuRpStockCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRpStockCard.Click
    frmRpStockCard.MdiParent = Me
    frmRpStockCard.Show()
    frmRpStockCard.Select()
  End Sub

  Private Sub mnuRpEmplSale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRpEmplSale.Click
    frmRpEmplSale.MdiParent = Me
    frmRpEmplSale.Show()
    frmRpEmplSale.Select()
  End Sub

  Private Sub mnuRpCustUsePoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRpCustUsePoint.Click
    frmRpPointUse.MdiParent = Me
    frmRpPointUse.Show()
    frmRpPointUse.Select()
  End Sub

  Private Sub mnuShelfNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShelfNo.Click
    frmShelfNo.MdiParent = Me
    frmShelfNo.Show()
    frmShelfNo.Select()
  End Sub

  Private Sub mnuRpStockOnhandByShelf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRpStockOnhandByShelf.Click
    frmRpStockOnhandByShelf.MdiParent = Me
    frmRpStockOnhandByShelf.Show()
    frmRpStockOnhandByShelf.Select()
  End Sub

  Private Sub mnuStockCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStockCount.Click
    frmStockCount.ShowDialog()
    frmStockCount = Nothing
  End Sub

  Private Sub mnuRpStockOver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRpStockOver.Click
    frmRpStockOver.MdiParent = Me
    frmRpStockOver.Show()
    frmRpStockOver.Select()
  End Sub

  Private Sub mnuGoodRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGoodRequest.Click
    frmGoodRequest.ShowDialog()
    frmGoodRequest = Nothing
  End Sub

  Private Sub mnuRpHistReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRpHistReturn.Click
    frmRpHistReturn.MdiParent = Me
    frmRpHistReturn.Show()
    frmRpHistReturn.Select()
  End Sub

  Private Sub mnuShipToRece_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShipToRece.Click
    frmShipToRece.ShowDialog()
    frmShipToRece = Nothing
  End Sub

  Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
    Dim fAbout As New AboutBox
    fAbout.ShowDialog()
    fAbout = Nothing
  End Sub

  Private Sub mnuGoodReceCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGoodReceCheck.Click
    frmGoodReceCheck.MdiParent = Me
    frmGoodReceCheck.Show()
    frmGoodReceCheck.Focus()
  End Sub

  Private Sub mnuRpPushConclude_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRpPushConclude.Click
    frmRpPushConclude.MdiParent = Me
    frmRpPushConclude.Show()
    frmRpPushConclude.Select()
  End Sub

  Private Sub mnuRpHistSaleSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRpHistSaleSum.Click
    frmRpHistSaleCustType.MdiParent = Me
    frmRpHistSaleCustType.Show()
    frmRpHistSaleCustType.Select()
  End Sub

  Private Sub mnuRpHistSaleType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRpHistSaleType.Click
    frmRpHistSaleSaleType.MdiParent = Me
    frmRpHistSaleSaleType.Show()
    frmRpHistSaleSaleType.Select()
  End Sub

  Private Sub mnuFingerPrintEnroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFingerPrintEnroll.Click
    frmFingerPrintEnroll.ShowDialog()
    frmFingerPrintEnroll = Nothing
  End Sub

  Private Sub mnuRpCommission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRpCommission.Click
    frmRpCommission.MdiParent = Me
    frmRpCommission.Show()
    frmRpCommission.Select()
  End Sub

  Private Sub mnuRpMonthGoodUse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRpMonthGoodUse.Click
    frmRpMonthGoodUse.MdiParent = Me
    frmRpMonthGoodUse.Show()
    frmRpMonthGoodUse.Select()
  End Sub

  Private Sub tssVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tssVersion.Click
    ShowVersionUpdate("")
  End Sub

  Private Sub mnuBranchTran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBranchTran.Click
    frmBranchTran.MdiParent = Me
    frmBranchTran.Show()
    frmBranchTran.Focus()
  End Sub

  Private Sub mnuSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetting.Click
    frmSetting.ShowDialog()
    frmSetting = Nothing
  End Sub

  Private Sub mnuRpAccoBook11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRpAccoBook11.Click
    frmRpAccoBook11.MdiParent = Me
    frmRpAccoBook11.Show()
    frmRpAccoBook11.Select()
  End Sub

  Private Sub mnuRpAccoBook9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRpAccoBook9.Click
    frmRpAccoBook9.MdiParent = Me
    frmRpAccoBook9.Show()
    frmRpAccoBook9.Select()
  End Sub

  Private Sub mnuRpStockOnhand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRpStockOnhand.Click
    frmRpStockOnhand.MdiParent = Me
    frmRpStockOnhand.Show()
    frmRpStockOnhand.Select()
  End Sub

  Private Sub mnuRpFCSale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRpFCSale.Click
    frmRpFCSale.MdiParent = Me
    frmRpFCSale.Show()
    frmRpFCSale.Select()
  End Sub

  Private Sub mnuUpdateOffline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUpdateOffline.Click
    frmUpdateOffline.ShowDialog()
    frmUpdateOffline = Nothing
  End Sub

  Private Sub mnuUpdateServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUpdateServer.Click
    frmUploadServer.ShowDialog()
    frmUploadServer = Nothing
  End Sub
End Class
