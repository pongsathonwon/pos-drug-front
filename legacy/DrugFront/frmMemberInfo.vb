Public Class frmMemberInfo

  Public pIsNewMemb As Boolean
  Public pFreeMember As Boolean
  Public pOk As Boolean
  Public pNewMembCode As String
  Public pCustTypeCode As String

  'Dim mMembPrice As Double
  'Dim mMembExtraPoint As Integer
  Dim mCustType As String
  Dim mGridPay As New DataGridView
  Dim mTotalCashPay As Double
  Dim mTotalCash As Double
  Dim mTotalChange As Double
  Dim mSaleNumb As String

  Private Sub frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    'mMembPrice = 0
    'mMembExtraPoint = 0

    CheckPriv()

    EnableEdit(False)

    ShowIncomePeriod()
    ShowJobInfo()
    ShowMediaInfo()
    ShowActivityInfo()
    ShowCustTypeInfo()

    txtCustCode.Enabled = True

    dtpBirthDay.Value = pServerDateTime.Date

    pOk = False
    If pIsNewMemb = True Then
      tbnEdit.Visible = False
      tbnCancel.Visible = False
      tbnSearch.Visible = False
      tbnClear.Visible = False
      TabControl1.TabPages.Remove(tabHistSale)
      tbnAdd.PerformClick()
      tbnAdd.Visible = False
      If pFreeMember = False Then
        txtMembPrice.Text = pMembPrice
        txtExtraPoint.Text = pMembExtraPoint
      End If
    Else
      tbnAdd.Visible = False
    End If
  End Sub

  Private Sub frmMemberInfo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.F2
        tbnEdit.PerformClick()
      Case Keys.F3
        tbnSearch.PerformClick()
      Case Keys.F7
        tbnCancel.PerformClick()
      Case Keys.F8
        tbnSave.PerformClick()
      Case Keys.F12
        tbnClear.PerformClick()
      Case Keys.Escape
        Me.Close()
    End Select
  End Sub

  Private Sub ShowCustInfo(ByVal CustCode As String)
    Me.Cursor = Cursors.WaitCursor

    ClearAll()

    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select CI.*, BI.branchName, EI.emplName From CustInfo CI Inner Join BranchInfo BI On BI.branchCode = CI.branchCode left outer Join EmplInfo EI On EI.emplCode = CI.emplCode Where CI.custStat <> '0' and CI.custCode = '" & CustCode & "'")
    'ds = pService.SelectData("Drug", "Select CI.*, BI.branchName, EI.emplName From CustInfo CI Left Outer Join BranchInfo BI On BI.branchCode = CI.branchCode Left Outer Join EmplInfo EI On EI.emplCode = CI.emplCode Where CI.custCode = '" & CustCode & "'")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        Dim mSplit() As String
        Dim mCustName As String
        With dv.Item(0)
          txtCustCode.Text = CustCode

          mCustName = System.Text.RegularExpressions.Regex.Replace(.Item("custName"), " {2,}", " ").Trim

          mSplit = Split(mCustName, " ")

          txtFirstName.Text = mSplit(0) ' .Item("custName").ToString
          'txtLastName.Text = mSplit(1)
          txtLastName.Text = ""
          For m As Integer = 1 To mSplit.Length - 1
            txtLastName.Text = txtLastName.Text & " " & mSplit(m)
          Next
          txtLastName.Text = txtLastName.Text.Trim

          txtIDCard.Text = .Item("idCard").ToString
          txtCustAddr.Text = .Item("custAddr").ToString
          txtHomePhone.Text = .Item("custPhone").ToString
          txtMobilePhone.Text = .Item("custMBPhone").ToString
          txtCustEmail.Text = .Item("custEmail").ToString
          txtCustRemark.Text = .Item("custRemark").ToString
          txtCongenDise.Text = .Item("congenDise").ToString

          Select Case .Item("custSex").ToString
            Case "m"
              radMale.Checked = True
            Case "f"
              radFemale.Checked = True
          End Select
          ' เฉพาะสมาชิก VIP

          'If .Item("custType").ToString = "6" Then
          mCustType = .Item("custType")
          cboCustTypeCode.Text = mCustType
          Try
            dtpBirthDay.Value = CDate(.Item("birthDay"))
            lblEnrollDate.Text = ThaiDate(CDate(.Item("enrollDate")))
            ' อายุสมาชิก คำนวณเทียบกับวันที่และเวลาของ server
            pServerDateTime = pService.ServerDateTime
            lblAge.Text = GetAge(CDate(.Item("enrollDate")), pServerDateTime.Date)

          Catch ex As Exception

          End Try
          cboIncomeValue.Text = .Item("incomeValue").ToString
          cboJob.Text = .Item("jobDesc").ToString
          cboMedia1.Text = .Item("mediaDesc1").ToString
          cboMedia2.Text = .Item("mediaDesc2").ToString
          cboActivity1.Text = .Item("actiDesc1").ToString
          cboActivity2.Text = .Item("actiDesc2").ToString

          lblEnrollBranch.Text = .Item("branchName").ToString
          lblEnrollEmpl.Text = .Item("emplName").ToString
          lblTotalBuy.Text = Format(.Item("totalBuy"), "#,##0.00")
          If CInt(.Item("totalSlip")) > 0 Then
            lblAverBuy.Text = Format(CDbl(.Item("totalBuy")) / CInt(.Item("totalSlip")), "#,##0.00")
          Else
            lblAverBuy.Text = ""
          End If
          lblTotalPoint.Text = Format(.Item("hugPoint"), "#,##0.00")
          'End If
        End With

        EnableEdit(False)
        ShowAllergic(CustCode)
        txtCustCode.Enabled = False
        dtgAller.Focus()
      Else
        pMessageBox = New MyMessageBox("ไม่มีข้อมูลลูกค้า", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        pMessageBox.ShowDialog()
        ClearAll()
        txtCustCode.Focus()
      End If
    Else
      pMessageBox = New MyMessageBox("ไม่มีข้อมูลลูกค้า", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      pMessageBox.ShowDialog()
      ClearAll()
      txtCustCode.Focus()
    End If
    ds = Nothing

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub ShowAllergic(ByVal CustCode As String)
    dtgAller.Rows.Clear()
    Dim dsAller As New DataSet
    dsAller = pService.SelectData("Drug", "SELECT DG.drugCode, Dg.drugDesc FROM DrugAllergic DA INNER JOIN DrugGroup DG ON DA.drugCode = DG.drugCode WHERE DA.custCode = '" & CustCode & "'")
    If IsNothing(dsAller) = False Then
      Dim dvAller As New DataView(dsAller.Tables(0))
      For i As Integer = 0 To dvAller.Count - 1
        dtgAller.Rows.Add(dvAller.Item(i).Item("drugDesc").ToString, dvAller.Item(i).Item("drugCode"))
      Next
      dvAller = Nothing
    End If
    dsAller = Nothing
  End Sub

  Private Sub ClearAll()
    txtCustCode.Text = ""
    txtIDCard.Text = ""
    txtFirstName.Text = ""
    txtLastName.Text = ""
    txtCustAddr.Text = ""
    txtHomePhone.Text = ""
    txtCustRemark.Text = ""
    txtMobilePhone.Text = ""
    txtCustEmail.Text = ""
    txtCongenDise.Text = ""
    txtMembPrice.Text = ""
    txtExtraPoint.Text = ""

    dtgAller.Rows.Clear()
    dtgHist.Rows.Clear()
    lblNew.Visible = False
    radNormal.Checked = True
    'ChangeTextBackColor(Color.PapayaWhip)
    'TabControl1.SelectTab("TabInfo")

    lblEnrollDate.Text = ""
    lblEnrollBranch.Text = ""
    lblEnrollEmpl.Text = ""
    lblAge.Text = ""
    lblTotalBuy.Text = ""
    lblAverBuy.Text = ""
    lblTotalPoint.Text = ""
    lblTotalDisc.Text = ""

    pnlMembPrice.Visible = False

    dtpBirthDay.Value = Now.Date
  End Sub

  Private Sub ChangeTextBackColor(ByVal mColor As Color)
    txtFirstName.BackColor = mColor
    txtLastName.BackColor = mColor
    txtIDCard.BackColor = mColor
    txtCustAddr.BackColor = mColor
    txtHomePhone.BackColor = mColor
    txtCustRemark.BackColor = mColor
    txtMobilePhone.BackColor = mColor
    txtCustEmail.BackColor = mColor
  End Sub

  'Private Sub frmCustHistSale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
  '  Select Case e.KeyCode
  '    Case Keys.F2
  '      tbnAdd.PerformClick()
  '    Case Keys.F3
  '      tbnSearch.PerformClick()
  '    Case Keys.F4
  '      tbnEdit.PerformClick()
  '    Case Keys.F6
  '      tbnDrugAller.PerformClick()
  '    Case Keys.F8
  '      tbnSave.PerformClick()
  '    Case Keys.Escape
  '      Me.Close()
  '  End Select
  'End Sub

  Private Sub CheckPriv()
    ' Add
    If InStr(pUserPriv, Me.Tag.ToString & "A") > 0 Then
      tbnAdd.Enabled = True
    Else
      tbnAdd.Enabled = False
    End If
    ' Edit
    If InStr(pUserPriv, Me.Tag.ToString & "E") > 0 Then
      tbnEdit.Enabled = True
    Else
      tbnEdit.Enabled = False
    End If
    ' Delete
    If InStr(pUserPriv, Me.Tag.ToString & "D") > 0 Then
      tbnCancel.Enabled = True
    Else
      tbnCancel.Enabled = False
    End If
  End Sub

  Private Sub ShowCustTypeInfo()
    cboCustTypeCode.Items.Clear()
    cboCustTypeDesc.Items.Clear()
    Dim ds As New DataSet
    Dim mSqlText As String
    ' แสดงเฉพาะลูกค้า HUG Club
    mSqlText = "Select * from CustType where custTypeCode = '6'"
    ' และลูกค้าส่ง (เฉพาะสาขาที่เปิดระบบขายส่ง)
    If pAllowWholePrice = "1" Then
      mSqlText = mSqlText & " or custTypeCode = '4'"
    End If
    ' และลูกค้า online (เฉพาะสาขาที่เปิดระบบขายออนไลน์)
    If pAllowOnlinePrice = "1" Then
      mSqlText = mSqlText & " or custTypeCode = '8'"
    End If

    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        cboCustTypeCode.Items.Add(dv.Item(i).Item("custTypeCode"))
        cboCustTypeDesc.Items.Add(dv.Item(i).Item("custTypeDesc"))
      Next
      dv = Nothing
    End If
    ds = Nothing
  End Sub

  Private Sub ShowIncomePeriod()
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select * from IncomePeriod Order by periodNo")
    If IsNothing(ds) = False Then
      cboIncome.Items.Clear()
      cboIncomeValue.Items.Clear()
      Dim dv As New DataView(ds.Tables(0))
      Dim mIncomeValue As Long
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          mIncomeValue = CLng(Fix((Val(.Item("fromIncome")) + Val(.Item("toIncome"))) / 2))
          cboIncome.Items.Add(.Item("incomeDesc"))
          cboIncomeValue.Items.Add(mIncomeValue)
        End With
      Next
      dv = Nothing
    End If
    ds = Nothing
  End Sub

  Private Sub ShowJobInfo()
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select * from JobInfo")
    If IsNothing(ds) = False Then
      cboJob.Items.Clear()
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        cboJob.Items.Add(dv.Item(i).Item("jobDesc"))
      Next
      dv = Nothing
    End If
    ds = Nothing
  End Sub

  Private Sub ShowMediaInfo()
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select * from MediaInfo")
    If IsNothing(ds) = False Then
      cboMedia1.Items.Clear()
      cboMedia2.Items.Clear()
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        cboMedia1.Items.Add(dv.Item(i).Item("mediaDesc"))
        cboMedia2.Items.Add(dv.Item(i).Item("mediaDesc"))
      Next
      dv = Nothing
    End If
    ds = Nothing
  End Sub

  Private Sub ShowActivityInfo()
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select * from ActivityInfo")
    If IsNothing(ds) = False Then
      cboActivity1.Items.Clear()
      cboActivity2.Items.Clear()
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        cboActivity1.Items.Add(dv.Item(i).Item("actiDesc"))
        cboActivity2.Items.Add(dv.Item(i).Item("actiDesc"))
      Next
      dv = Nothing
    End If
    ds = Nothing
  End Sub

  Private Sub tbnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnAdd.Click
    ClearAll()
    EnableEdit(True)
    lblNew.Visible = True
    pnlMembPrice.Visible = True
    ShowCustTypeInfo()
    cboCustTypeCode.Text = "6"
    txtCustCode.Text = "ลูกค้าใหม่"
    txtCustCode.Enabled = False
    txtFirstName.Focus()
  End Sub

  Private Sub tbnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnSave.Click
    If txtFirstName.Text.Trim = "" Or txtLastName.Text.Trim = "" Then
      pMessageBox = New MyMessageBox("กรุณาป้อนชื่อ-นามสกุล", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      pMessageBox.ShowDialog()
      Exit Sub
    End If
    If cboCustTypeDesc.Text = "" Then
      pMessageBox = New MyMessageBox("กรุณาเลือกประเภทลูกค้า", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      pMessageBox.ShowDialog()
      Exit Sub
    End If
    If txtMobilePhone.Text = "" Then
      pMessageBox = New MyMessageBox("กรุณาป้อนหมายเลขโทรศัพท์มือถือ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      pMessageBox.ShowDialog()
      Exit Sub
    End If
    If dtpBirthDay.Value = Now.Date Then
      pMessageBox = New MyMessageBox("กรุณาป้อนวันเดือนปีเกิด", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      pMessageBox.ShowDialog()
      Exit Sub
    End If

    SaveData()

  End Sub

  Private Sub SaveData()
    Dim mCustSex As String
    If radMale.Checked = True Then
      mCustSex = "m"
    Else
      mCustSex = "f"
    End If

    Dim mCustName As String
    Dim mMBPhone As String
    Dim mIDCard As String

    mCustName = txtFirstName.Text.Trim & " " & txtLastName.Text.Trim
    mMBPhone = Replace(txtMobilePhone.Text, " ", vbNullString)
    mIDCard = Replace(txtIDCard.Text, " ", vbNullString)

    If lblNew.Visible = True Then ' สมาชิกใหม่
      Dim mRet() As String
      '' ตรวจสอบซ้ำ
      '' รหัสซ้ำ
      'mRet = pService.GetData("Drug", "Select custName From CustInfo Where custCode = '" & txtCustCode.Text & "'")
      'If mRet(0) = "1" Then
      '  MessageBox.Show("รหัสสมาชิกซ้ำ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      '  Exit Sub
      'End If
      ' หมายเลขบัตร ปชช ซ้ำ
      If mIDCard <> "" Then
        mRet = pService.GetData("Drug", "Select custName From CustInfo Where idCard = '" & mIDCard & "'")
        If mRet(0) = "1" Then
          pMessageBox = New MyMessageBox("เลขที่บัตรประชาชนซ้ำ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
          pMessageBox.ShowDialog()
          Exit Sub
        End If
      End If
      ' หมายเลขโทร.มือถือ ซ้ำ
      If mMBPhone <> "" Then
        mRet = pService.GetData("Drug", "Select custName From CustInfo Where custMBPhone = '" & mMBPhone & "'")
        If mRet(0) = "1" Then
          pMessageBox = New MyMessageBox("หมายเลขโทรศัพท์มือถือซ้ำกับสมาชิกชื่อ " & mRet(1), "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
          pMessageBox.ShowDialog()
          Exit Sub
        End If
      End If
      ' ชื่อใกล้เคียง
      mRet = pService.GetData("Drug", "Select custName, custCode From CustInfo where custName like '" & Replace(mCustName, " ", "%") & "%' order by custName")
      If mRet(0) = "1" Then
        If mRet(1) = mCustName Then
          pMessageBox = New MyMessageBox("ชื่อ-นามสกุลซ้ำ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
          pMessageBox.ShowDialog()
          Exit Sub
        End If

        pMessageBox = New MyMessageBox("ชื่อซ้ำหรือใกล้เคียงกับสมาชิกชื่อ '" & mRet(1) & "(" & mRet(2) & ")' ยืนยันเพิ่มสมาชิกใหม่หรือไม่", "คำเตือน", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If pMessageBox.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
          Exit Sub
        End If
      End If

      'pMessageBox = New MyMessageBox("ยืนยันสมัครสมาชิกใหม่ (ค่าสมัคร : " & mMembPrice & " บาท)", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
      pMessageBox = New MyMessageBox("ยืนยันสมัครสมาชิกใหม่", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
      If pMessageBox.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
        Exit Sub
      End If
      ' $$$$$$$$$$$$$$$$$$  
      ' ลูกค้าใหม่ ชำระเงินค่าสมัคร
      If pFreeMember = False And pMembPrice > 0 Then
        frmSalePaid.pTotalPrice = pMembPrice
        frmSalePaid.pCustTypeCode = mCustType
        frmSalePaid.ShowDialog()
        If frmSalePaid.pOk = True Then
          mTotalCashPay = frmSalePaid.pCashPaid
          mTotalCash = frmSalePaid.pCashAmou
          mTotalChange = frmSalePaid.pChangeAmou
          mGridPay = frmSalePaid.pGridPay
        Else
          frmSalePaid = Nothing
          Exit Sub
        End If
      End If
      ' $$$$$$$$$$$$$$$$$$

      ' ใช้วันที่และเวลาของ server
      pServerDateTime = pService.ServerDateTime

      Dim mSqlText(dtgAller.Rows.Count + 25) As String
      Dim mLine As Integer = 0

      ' สร้างรหัสใหม่ รหัสสมาชิกมี 6 หลัก โดยหลักที่ 1 เป็นอักษร A-Z หลักที่ 2 A-Z หลักที่ 3-6 เป็นจำนวนนับ
      ' เมื่อจำนวนเกิน 10000 รายในแต่ละหลักที่ 1-2 ให้เปลี่ยนอักษรเป็นตัวต่อไปอัตโนมัติ
      ' วิธีนี้จะได้จำนวนสมาชิกรวมทั้งสิ้น 26x26x10000=6,760,000 ราย
      ' AA0000....AA9999
      ' AB0000....AB9999
      ' .
      ' .
      ' AY0000....AY9999
      ' AZ0000....AZ9999
      '
      ' ZA0000....ZA9999
      ' ZB0000....ZB9999
      ' .
      ' .
      ' ZY0000....ZY9999
      ' ZZ0000....ZZ9999

      Dim mNewCode As String
      ' ##################
      mRet = pService.GetData("Drug", "Select preCustCode1, preCustCode2, countCustCode from SystInfo")
      If mRet(0) = "1" Then
        Dim mPreCustCode1, mPreCustCode2 As String
        Dim mCountCustCode As Integer
        mPreCustCode1 = mRet(1)
        mPreCustCode2 = mRet(2)
        mCountCustCode = CInt(mRet(3))

        If mCountCustCode > 9999 Then
          mCountCustCode = 0
          mPreCustCode2 = Chr(CInt(Asc(mPreCustCode2)) + 1)
          If Asc(mPreCustCode2) > Asc("Z") Then
            mPreCustCode2 = "A"

            mPreCustCode1 = Chr(CInt(Asc(mPreCustCode1)) + 1)
            If Asc(mPreCustCode1) > Asc("Z") Then
              MessageBox.Show("Over limit new customer code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
              Exit Sub
            End If
          End If
          mSqlText(mLine) = "Update SystInfo set preCustCode1 = '" & mPreCustCode1 & "', preCustCode2 = '" & mPreCustCode2 & "', countCustCode = 1"
          mLine += 1
        Else
          mSqlText(mLine) = "Update SystInfo set countCustCode = countCustCode + 1"
          mLine += 1
        End If

        mNewCode = mPreCustCode1 & mPreCustCode2 & Mid((10000 + mCountCustCode).ToString, 2)

      Else
        MessageBox.Show("ไม่สามารถสร้างรหัสสมาชิกใหม่ได้" & vbCrLf & mRet(0), "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      End If
      ' ##################

      '' %%%%%%%%%%%%%%%%
      'mRet = pService.GetData("Drug", "Select preCustCode, countCustCode from SystInfo")
      'If mRet(0) = "1" Then
      '  Dim mPreCustCode As String
      '  Dim mCountCustCode As Integer
      '  mPreCustCode = mRet(1)
      '  mCountCustCode = CInt(mRet(2))
      '  ' รหัสสมาชิกมีขนาด 6 ตัวอักษร นำหน้าด้วยอักษรอังกฤษตามด้วยตัวเลข 5 หลัก เช่น B00001
      '  ' เมื่อใช้เต็มจำนวน (99,999 ราย) ให้ตัวอักษรนำหน้าเปลี่ยนเป็นตัวอักษรลำดับถัดไป เช่น A->B->C
      '  If mCountCustCode > 99999 Then ' 
      '    mCountCustCode = 1
      '    mPreCustCode = Chr(CInt(Asc(mPreCustCode)) + 1)

      '    ' ยกเว้นอักษร W ซึ่งถูกใช้ไปแล้ว
      '    If mPreCustCode = "W" Then mPreCustCode = "X"
      '    ' ใช้อักษรได้ไม่เกิน Z
      '    If Asc(mPreCustCode) > Asc("Z") Then
      '      MessageBox.Show("Over limit new customer code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      '      Exit Sub
      '    End If

      '    mSqlText(mLine) = "Update SystInfo set preCustCode = '" & mPreCustCode & "', countCustCode = 2"
      '    mLine += 1
      '  Else
      '    mSqlText(mLine) = "Update SystInfo set countCustCode = countCustCode + 1"
      '    mLine += 1
      '  End If

      '  mNewCode = mPreCustCode & Mid((100000 + mCountCustCode).ToString, 2)
      '  ' %%%%%%%%%%%%%%%%

      'Else
      '  MessageBox.Show("ไม่สามารถสร้างรหัสสมาชิกใหม่ได้" & vbCrLf & mRet(0), "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error)
      '  Exit Sub
      'End If

      ' สมัครฟรี ไม่ได้แต้ม
      Dim mExtraPoint As Integer
      If pFreeMember = True Then
        mExtraPoint = 0
      Else
        mExtraPoint = pMembExtraPoint
      End If

      mSqlText(mLine) = "Insert into CustInfo (custCode, custName, custAddr, custPhone, custType, custRemark, custMBPhone, custEmail, custSex, idCard, birthDay, jobDesc, mediaDesc1, mediaDesc2, actiDesc1, actiDesc2, enrollDate, emplCode, branchCode, congenDise, incomeValue, membPrice, hugPoint, firstName, lastName) values ('" & mNewCode & "', '" & mCustName & "', '" & txtCustAddr.Text & "', '" & txtHomePhone.Text & "', '" & cboCustTypeCode.Text & "', '" & txtCustRemark.Text & "', '" & mMBPhone & "', '" & txtCustEmail.Text & "', '" & mCustSex & "', '" & mIDCard & "', '" & MDYStr(dtpBirthDay.Value) & "', '" & cboJob.Text & "', '" & cboMedia1.Text & "', '" & cboMedia2.Text & "', '" & cboActivity1.Text & "', '" & cboActivity2.Text & "', '" & MDYStr(pServerDateTime.Date) & "', '" & pUserCode & "', '" & pBranchCode & "', '" & txtCongenDise.Text & "', " & CInt(Val(cboIncomeValue.Text)) & ", " & pMembPrice & ", " & mExtraPoint & ", '" & txtFirstName.Text & "', '" & txtLastName.Text & "')"
      mLine += 1
      ' รายการแพ้ยา
      mSqlText(mLine) = "DELETE FROM DrugAllergic WHERE custCode = '" & mNewCode & "'"
      mLine += 1
      For i As Integer = 0 To dtgAller.Rows.Count - 1
        mSqlText(mLine) = "INSERT INTO DrugAllergic (custCode, goodCode) values ('" & mNewCode & "', '" & dtgAller.Item("goodCode", i).Value.ToString & "')"
        mLine += 1
      Next

      ' $$$$$$$$$$$$$$$$$$
      ' ลูกค้าใหม่และเสียค่าสมัครสมาชิก ให้ออกใบขาย ค่าสมัครสมาชิก (ยกเว้นได้รับสิทธิ์ฟรีค่าสมัคร)
      If pFreeMember = False And pMembPrice > 0 Then
        Dim getValue() As String
        getValue = pService.GetData("Drug", "SELECT saleNumb FROM BranchInfo WHERE branchCode = '" & pBranchCode & "'")
        If getValue(0) = "1" Then
          mSaleNumb = pPreSaleNumb & Mid((100000 + CInt(getValue(1))).ToString, 2)
        Else
          pMessageBox = New MyMessageBox("ไม่สามารถกำหนดเลขที่ใบขายค่าสมัครสมาชิกได้" & "(" & getValue(1) & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
          pMessageBox.ShowDialog()
          Exit Sub
        End If

        mSqlText(mLine) = "Update CustInfo set totalBuy = totalBuy + " & pMembPrice & " where custCode = '" & mNewCode & "'"
        mLine += 1

        mSqlText(mLine) = "INSERT INTO HistSale (saleNumb, saleDate, saleTime, branchCode, custCode, emplCode, cashCode, totalPrice, totalDisc, totalCost, totalPay, totalCash, totalCredit, totalDebt, totalCupong, perCharge, payType, creditNumb, saleStat, creditCode, custType, saleRema, pointDisc, salePriceType)VALUES ('" & mSaleNumb & "', '" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', '" & pBranchCode & "', '" & mNewCode & "', '" & pUserCode & "', '" & pUserCode & "', " & pMembPrice & ", 0, 0, " & mTotalCashPay & ", " & mTotalCash & ", 0, 0, 0, 0, '', '', '1', '', '" & cboCustTypeCode.Text & "', '', 0, 'R')"
        mLine += 1

        mSqlText(mLine) = "INSERT INTO SaleList (saleNumb, barCode, goodCode, goodAmou, unitCode, unitPrice, unitCost, subDisc)VALUES ('" & mSaleNumb & "', '066', '11755', 1, '13', " & pMembPrice & ", 0, 0)"
        mLine += 1

        mSqlText(mLine) = "Insert into HistSalePro (saleNumb, saleDate, thisPoint, usePoint, remainPoint, selectPro) Values ('" & mSaleNumb & "', '" & MDYStr(pServerDateTime.Date) & "', " & pMembExtraPoint & ", 0, 0, '')"
        mLine = mLine + 1

        mSqlText(mLine) = "UPDATE BranchInfo set saleNumb = saleNumb + 1 WHERE branchCode = '" & pBranchCode & "'"
        mLine += 1

        ' ข้อมูลการชำระเงิน
        Dim mPayAmou As Double
        For Each mRow As DataGridViewRow In mGridPay.Rows
          If IsNothing(mGridPay.Item("payAmou", mRow.Index).Value) = False Then
            mPayAmou = Val(mGridPay.Item("payAmou", mRow.Index).Value)
          Else
            mPayAmou = 0
          End If

          If mPayAmou > 0 Then
            mSqlText(mLine) = "Insert into SalePaidList (saleNumb, cardCode, payAmou, refNumb) values ('" & mSaleNumb & "', '" & mGridPay.Item("cardCode", mRow.Index).Value & "', " & Val(mGridPay.Item("payAmou", mRow.Index).Value) & ", '" & mGridPay.Item("refNumb", mRow.Index).Value & "')"
            mLine += 1
          End If
        Next

      End If
      ' $$$$$$$$$$$$$$$$$$

      Dim mRetVal As String
      mRetVal = pService.UpdateData("Drug", mSqlText)
      If mRetVal = "1" Then
        ' สมัครใหม่ และเสียค่าสมัคร ให้พิมพ์ใบเสร็จ
        If pFreeMember = False And pMembPrice > 0 Then
          pdcAbbBillVat.Print()
          ' แสดงเงินทอน
          Dim fReturn As New frmCashChange
          fReturn.pReturn = mTotalChange
          fReturn.ShowDialog()
        End If
        ' สมัครใหม่ ให้ปิดหน้าต่างกลับไปหน้าเมนูที่เรียก และก๊อปรหัสไว้ใน clip board
        My.Computer.Clipboard.SetText(mNewCode)
        pOk = True
        pNewMembCode = mNewCode
        pCustTypeCode = cboCustTypeCode.Text
        Me.Close()

        'If mMembPrice > 0 Then ' ถ้ามีค่าสมัครสมาชิก ให้พิมพ์ใบเสร็จ
        '  pdc2.Print()
        'End If

        'pMessageBox = New MyMessageBox("สมาชิกใหม่ :" & vbCrLf & "รหัส : " & mNewCode & vbCrLf & "ชื่อ : " & mCustName, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        'pMessageBox.ShowDialog()

        'ClearAll()
        'txtCustCode.Focus()
      Else
        MessageBox.Show(mRetVal, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Exit Sub
      End If
    Else ' สมาชิกเก่า
      ' ตรวจสอบชื่อซ้ำ ยกเว้นถ้าเป็น record เดิม
      Dim mRet() As String
      ' หมายเลขบัตร ปชช ซ้ำ
      If mIDCard <> "" Then
        mRet = pService.GetData("Drug", "Select custName From CustInfo Where idCard = '" & mIDCard & "' And custCode <> '" & txtCustCode.Text & "'")
        If mRet(0) = "1" Then
          pMessageBox = New MyMessageBox("เลขที่บัตรประชาชนซ้ำ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
          pMessageBox.ShowDialog()
          Exit Sub
        End If
      End If
      ' หมายเลขโทร.มือถือ ซ้ำ
      If mMBPhone <> "" Then
        mRet = pService.GetData("Drug", "Select custName, custCode From CustInfo Where custMBPhone = '" & mMBPhone & "' And custCode <> '" & txtCustCode.Text & "'")
        If mRet(0) = "1" Then
          pMessageBox = New MyMessageBox("หมายเลขโทรศัพท์ซ้ำกับสมาชิกชื่อ " & mRet(1) & "(" & mRet(2) & ")", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
          pMessageBox.ShowDialog()
          Exit Sub
        End If
      End If
      ' ชื่อใกล้เคียง
      mRet = pService.GetData("Drug", "Select custName, custCode From CustInfo where custName like '" & Replace(mCustName, " ", "%") & "%' and custCode <> '" & txtCustCode.Text & "'")
      If mRet(0) = "1" Then
        If mRet(1) = mCustName Then
          pMessageBox = New MyMessageBox("ชื่อ-นามสกุลซ้ำ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
          pMessageBox.ShowDialog()
          Exit Sub
        End If

        pMessageBox = New MyMessageBox("ชื่อใกล้เคียงกับสมาชิกชื่อ '" & mRet(1) & "(" & mRet(2) & ")' ยืนยันบันทึกการแก้ไขหรือไม่", "คำเตือน", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If pMessageBox.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
          Exit Sub
        End If
      End If

      Dim mSqlText(dtgAller.Rows.Count + 2) As String
      Dim mLine As Integer = 0
      mSqlText(mLine) = "Update CustInfo set custName = '" & mCustName & "', custAddr = '" & txtCustAddr.Text & "', custPhone = '" & txtHomePhone.Text & "', custRemark = '" & txtCustRemark.Text & "', custMBPhone = '" & mMBPhone & "', custEmail = '" & txtCustEmail.Text & "', custSex = '" & mCustSex & "', idCard = '" & mIDCard & "', birthDay = '" & MDYStr(dtpBirthDay.Value) & "', jobDesc = '" & cboJob.Text & "', mediaDesc1 = '" & cboMedia1.Text & "', mediaDesc2 = '" & cboMedia2.Text & "', actiDesc1 = '" & cboActivity1.Text & "', actiDesc2 = '" & cboActivity2.Text & "', congenDise = '" & txtCongenDise.Text & "', incomeValue = " & CInt(Val(cboIncomeValue.Text)) & ", firstName = '" & txtFirstName.Text & "', lastName = '" & txtLastName.Text & "' where custCode = '" & txtCustCode.Text & "'"
      mLine += 1
      ' รายการแพ้ยา
      mSqlText(mLine) = "DELETE FROM DrugAllergic WHERE custCode = '" & txtCustCode.Text & "'"
      mLine += 1
      For i As Integer = 0 To dtgAller.Rows.Count - 1
        mSqlText(mLine) = "INSERT INTO DrugAllergic (custCode, drugCode) values ('" & txtCustCode.Text & "', '" & dtgAller.Item("drugCode", i).Value.ToString & "')"
        mLine += 1
      Next

      Dim mRetVal As String
      mRetVal = pService.UpdateData("Drug", mSqlText)

      If mRetVal = "1" Then
        ClearAll()
        txtCustCode.Focus()
      Else
        MessageBox.Show(mRetVal, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Exit Sub
      End If
    End If

    ClearAll()
    EnableEdit(False)
    txtCustCode.Enabled = True
    txtCustCode.Focus()
  End Sub

  Private Sub pdcAbbBillVat_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcAbbBillVat.PrintPage
    PrintAbbBillVat(mSaleNumb, e)
  End Sub

  Private Sub tbnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnEdit.Click
    ' ลูกค้าประเภทพนักงาน (2) ไม่สามารถแก้ไขได้
    If lblNew.Visible = False AndAlso txtCustCode.Text <> "" And mCustType <> "2" Then
      EnableEdit(True)
      'cboCustTypeDesc.Enabled = False
      txtCustCode.Enabled = False
      cboCustTypeDesc.Enabled = False
      'radMembPrice.Enabled = False
      'radMembFree.Enabled = False
      'txtCustName.ReadOnly = False
      'txtCustAddr.ReadOnly = False
      'txtCustRemark.ReadOnly = False
      'txtCustPhone.ReadOnly = False
      'txtCustMBPhone.ReadOnly = False
      'txtCustEmail.ReadOnly = False

      'txtCustName.Enabled = True
      'txtCustAddr.Enabled = True
      'txtCustPhone.Enabled = True
      'txtCustRemark.Enabled = True
      'txtCustMBPhone.Enabled = True
      'txtCustEmail.Enabled = True
      '' ไม่อนุญาตให้แก้ไขประเภทสมาชิก
      'radNormal.Enabled = False
      'radEmpl.Enabled = False
      'radMemb.Enabled = False
      'ChangeTextBackColor(Color.White)
      txtFirstName.Focus()
    End If
  End Sub

  Private Sub tbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnSearch.Click
    'Dim fcustsearch As New frmCustSearch
    frmMembSearch.ShowDialog()
    If frmMembSearch.pOk = True Then
      txtCustCode.Text = frmMembSearch.pCustCode
      ShowCustInfo(txtCustCode.Text)
      'TabControl1.SelectTab("TabInfo")
    End If
    'fcustsearch = Nothing
  End Sub

  Private Sub textKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCustCode.KeyPress, txtFirstName.KeyPress, txtLastName.KeyPress, txtCustAddr.KeyPress, txtHomePhone.KeyPress, txtCustRemark.KeyPress, txtMobilePhone.KeyPress, txtCustEmail.KeyPress, txtIDCard.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub btnDrugAller_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrugAller.Click
    'If lblNew.Visible = True OrElse txtCustCode.Text = "" Then
    '  Exit Sub
    'End If

    Dim fGoodSearch As New frmGoodSearch
    fGoodSearch.ShowDialog()
    If fGoodSearch.pOk = True Then
      ' หารหัสกลุ่มยาที่แพ้
      Dim mGet() As String
      Dim mDrugCode, mDrugName As String
      mGet = pService.GetData("Drug", "SELECT DG.drugDesc, GI.drugCode FROM GoodInfo GI INNER JOIN DrugGroup DG ON GI.drugCode = DG.drugCode WHERE GI.goodCode = '" & fGoodSearch.pGoodCode & "'")
      If mGet(0) = "1" Then
        mDrugName = mGet(1)
        mDrugCode = mGet(2)
      Else
        pMessageBox = New MyMessageBox("สินค้ายังไม่ได้กำหนดว่าอยู่ในกลุ่มยาใด", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        pMessageBox.ShowDialog()
        Exit Sub
      End If
      ' หากรหัสกลุ่มยาเป็น 0 แสดงว่ายังไม่ได้กำหนดกลุ่มยา
      If mDrugCode = "0" Then
        pMessageBox = New MyMessageBox("สินค้ายังไม่ได้กำหนดว่าอยู่ในกลุ่มยาใด", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        pMessageBox.ShowDialog()
        Exit Sub
      End If

      ' ตรวจสอบรายการซ้ำ
      Dim mDup As Boolean = False
      For i As Integer = 0 To dtgAller.Rows.Count - 1
        If dtgAller.Item("drugCode", i).Value.ToString = mDrugCode Then
          pMessageBox = New MyMessageBox("กลุ่มยาซ้ำ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
          pMessageBox.ShowDialog()
          mDup = True
          Exit For
        End If
      Next
      If mDup = False Then
        dtgAller.Rows.Add(mDrugName, mDrugCode)
      End If
    End If
    fGoodSearch = Nothing

  End Sub

  Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnClear.Click
    ClearAll()
    ShowCustTypeInfo()
    EnableEdit(False)
    txtCustCode.Enabled = True
    txtCustCode.Focus()
  End Sub

  Private Sub txtCustCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustCode.LostFocus
    If txtCustCode.Text <> "" AndAlso lblNew.Visible = False Then
      ShowCustInfo(txtCustCode.Text)
    End If
  End Sub

  Private Sub tbnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnCancel.Click
    If lblNew.Visible = False AndAlso txtCustCode.Text <> "" Then
      pMessageBox = New MyMessageBox("ยืนยันยกเลิกข้อมูลลูกค้า", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
      If pMessageBox.ShowDialog = Windows.Forms.DialogResult.OK Then
        Dim mSqlText(1) As String
        mSqlText(0) = "Update CustInfo set custStat = '0' where custCode = '" & txtCustCode.Text & "'"
        'mSqlText(0) = "DELETE FROM CustInfo WHERE custCode = '" & txtCustCode.Text & "'"
        Dim mUpdate As String
        mUpdate = pService.UpdateData("Drug", mSqlText)
        If mUpdate = "1" Then
          pMessageBox = New MyMessageBox("ยกเลิกเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
          pMessageBox.ShowDialog()
          ClearAll()
          EnableEdit(False)
          txtCustCode.Enabled = True
          txtCustCode.Focus()
        Else
          MessageBox.Show(mUpdate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
      End If
    End If
  End Sub

  Private Sub EnableEdit(ByVal Flag As Boolean)
    txtCustCode.Enabled = Flag
    txtFirstName.Enabled = Flag
    txtLastName.Enabled = Flag
    txtIDCard.Enabled = Flag
    txtCustAddr.Enabled = Flag
    txtCustRemark.Enabled = Flag
    txtHomePhone.Enabled = Flag
    txtMobilePhone.Enabled = Flag
    txtCustEmail.Enabled = Flag
    txtCongenDise.Enabled = Flag
    dtpBirthDay.Enabled = Flag
    radMale.Enabled = Flag
    radFemale.Enabled = Flag
    cboIncome.Enabled = Flag
    cboJob.Enabled = Flag
    cboMedia1.Enabled = Flag
    cboMedia2.Enabled = Flag
    cboActivity1.Enabled = Flag
    cboActivity2.Enabled = Flag
    cboCustTypeDesc.Enabled = Flag

    'radMembPrice.Enabled = Flag
    'radMembFree.Enabled = Flag
    'radNormal.Enabled = Flag
    'radEmpl.Enabled = Flag
    'radMemb.Enabled = Flag
    'radDebt.Enabled = Flag
    'radWhole.Enabled = Flag
    tbnSave.Enabled = Flag
    btnDrugAller.Enabled = Flag
  End Sub

  'Private Sub tbnShowHistBuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnShowHistBuy.Click
  '  If txtCustCode.Text <> "" And lblNew.Visible = False Then
  '    TabControl1.SelectTab("TabHistSale")
  '    ShowHistSale(txtCustCode.Text)
  '  End If
  'End Sub

  'Private Sub ShowHistSale(ByVal CustCode As String)
  '  Me.Cursor = Cursors.WaitCursor

  '  dtgHist.Rows.Clear()
  '  Dim dsHist As New DataSet
  '  dsHist = pService.SelectData("Drug", "SELECT HS.saleDate, HS.saleTime, GI.goodName, SL.goodAmou, UI.unitDesc, SL.unitPrice, SL.subDisc FROM HistSale HS INNER JOIN SaleList SL ON HS.saleNumb = SL.saleNumb INNER JOIN GoodInfo GI ON SL.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON SL.unitCode = UI.unitCode WHERE HS.custCode = '" & CustCode & "' ORDER BY HS.saleNumb desc")
  '  If IsNothing(dsHist) = False Then
  '    Dim dvHist As New DataView(dsHist.Tables(0))
  '    Dim mSaleDateTime As String
  '    Dim mDateTime As String = ""
  '    If dvHist.Count > 0 Then
  '      For i As Integer = 0 To dvHist.Count - 1
  '        With dvHist.Item(i)
  '          If mDateTime = Format(.Item("saleDate"), "dd/MM/yyyy") & " " & .Item("saleTime").ToString & " (" & pBranchCode & ")" Then
  '            mSaleDateTime = ""
  '          Else
  '            mSaleDateTime = Format(.Item("saleDate"), "dd/MM/yyyy") & " " & .Item("saleTime").ToString & " (" & pBranchCode & ")"
  '          End If

  '          dtgHist.Rows.Add(mSaleDateTime, .Item("goodName").ToString, CInt(.Item("goodAmou")).ToString & " " & .Item("unitDesc").ToString, CSng(.Item("unitPrice")) * CInt(.Item("goodAmou")) - CSng(.Item("subDisc")))

  '          mDateTime = Format(.Item("saleDate"), "dd/MM/yyyy") & " " & .Item("saleTime").ToString & " (" & pBranchCode & ")"
  '        End With
  '      Next

  '    End If
  '    dvHist = Nothing
  '  End If
  '  dsHist = Nothing

  '  Me.Cursor = Cursors.Default
  'End Sub

  Private Sub cboIncome_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIncome.SelectedIndexChanged
    cboIncomeValue.SelectedIndex = cboIncome.SelectedIndex
  End Sub

  Private Sub cboIncomeValue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIncomeValue.SelectedIndexChanged
    cboIncome.SelectedIndex = cboIncomeValue.SelectedIndex
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
    mText = "ใบเสร็จรับเงิน"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' วันที่-เวลา
    ' ใช้วันที่และเวลาของ server
    pServerDateTime = pService.ServerDateTime

    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = pServerDateTime.ToString("dd/MM/yyyy  HH:mm")
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' --------
    mRect = New RectangleF(mLeftMargin, mRowPos + 15, 260.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' จำนวน
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "1"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' ชื่อรายการ
    mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ค่าสมัครสมาชิก"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' ราคาขาย
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = Format(pMembPrice, "#,##0.00")
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' --------
    mRowPos = mRowPos + 15
    mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' รวม
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(120, mRowPos, 90.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "รวมเป็นเงิน"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = pMembPrice.ToString("#,##0.00")
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' cashier แสดงเฉพาะชื่อไม่รวมนามสกุล (แยกชื่อ-นามสกุลออกจากกันโดยเช็คช่องว่าง)
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "Cashier : " & Mid(pUserName, 1, pUserName.LastIndexOf(" "))
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' ขอบคุณ
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = "ขอบคุณที่ใช้บริการ"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
  End Sub

  Private Sub cboCustTypeDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustTypeDesc.SelectedIndexChanged
    cboCustTypeCode.SelectedIndex = cboCustTypeDesc.SelectedIndex
    '' แสดงค่าสมัครลูกค้าประเภทสมาชิก (เฉพาะเพิ่มลูกค้าใหม่)
    'If cboCustTypeCode.Text = "6" And lblNew.Visible = True Then
    '  mMembPrice = pMembPrice
    '  mMembExtraPoint = pMembExtraPoint
    '  txtMembPrice.Text = pMembPrice
    '  txtExtraPoint.Text = pMembExtraPoint
    'Else
    '  mMembPrice = 0
    '  mMembExtraPoint = 0
    '  txtMembPrice.Text = ""
    '  txtExtraPoint.Text = ""
    'End If
  End Sub

  Private Sub cboCustTypeCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustTypeCode.SelectedIndexChanged
    cboCustTypeDesc.SelectedIndex = cboCustTypeCode.SelectedIndex
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    ShowHistSale(txtCustCode.Text)
  End Sub

  Private Sub ShowHistSale(ByVal CustCode As String)
    If CustCode = "" Then
      Exit Sub
    End If

    Me.Cursor = Cursors.WaitCursor

    dtgHist.Rows.Clear()
    Dim dsHist As New DataSet
    dsHist = pService.SelectData("Drug", "SELECT HS.saleDate, GI.goodName, SL.goodAmou, UI.unitDesc, SL.unitPrice, SL.subDisc FROM HistSale HS INNER JOIN SaleList SL ON HS.saleNumb = SL.saleNumb INNER JOIN GoodInfo GI ON SL.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON SL.unitCode = UI.unitCode WHERE HS.custCode = '" & CustCode & "' And HS.saleDate >= '" & MDYStr(dtpFrom.Value) & "' And HS.saleDate <= '" & MDYStr(dtpTo.Value) & "' ORDER BY HS.saleDate, GI.goodName")
    If IsNothing(dsHist) = False Then
      Dim dvHist As New DataView(dsHist.Tables(0))
      Dim mSaleDateTime As String
      Dim mDateTime As String = ""
      If dvHist.Count > 0 Then
        For i As Integer = 0 To dvHist.Count - 1
          With dvHist.Item(i)
            If mDateTime = Format(.Item("saleDate"), "dd/MM/yyyy") Then ' & " " & .Item("saleTime").ToString & " (" & pBranchCode & ")" Then
              mSaleDateTime = ""
            Else
              mSaleDateTime = Format(.Item("saleDate"), "dd/MM/yyyy") ' & " " & .Item("saleTime").ToString & " (" & pBranchCode & ")"
            End If

            dtgHist.Rows.Add(mSaleDateTime, .Item("goodName").ToString, CInt(.Item("goodAmou")).ToString & " " & .Item("unitDesc").ToString, CSng(.Item("unitPrice")) * CInt(.Item("goodAmou")) - CSng(.Item("subDisc")))

            mDateTime = Format(.Item("saleDate"), "dd/MM/yyyy") ' & " " & .Item("saleTime").ToString & " (" & pBranchCode & ")"
          End With
        Next

      End If
      dvHist = Nothing
    End If
    dsHist = Nothing

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub txtFirstName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFirstName.LostFocus
    Dim mSplit() As String

    txtFirstName.Text = System.Text.RegularExpressions.Regex.Replace(txtFirstName.Text, " {2,}", " ").Trim
    mSplit = Split(txtFirstName.Text, " ")

    txtFirstName.Text = mSplit(0)
    ' หากแยกแล้วได้หลายข้อความ ให้นำส่วนที่เหลือไปแสดงในช่องนามสกุล
    If mSplit.Length > 1 Then
      txtLastName.Text = mSplit(1)
    End If

    'If txtFirstName.Text <> "" Then
    '  ' แทนที่ช่องว่างที่มากกว่าหนึ่งช่อง ให้เหลือช่องเดียว และลบช่องว่างหัวท้าย(ถ้ามี)ออกด้วย
    '  txtFirstName.Text = System.Text.RegularExpressions.Regex.Replace(txtFirstName.Text, " {2,}", " ").Trim
    'End If
  End Sub

  Private Sub pdc2_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdc2.PrintPage
    Dim prnFontNormal As New Font("CordiaUPC", 12, GraphicsUnit.Point)
    Dim prnFontNormalBold As New Font("CordiaUPC", 12, FontStyle.Bold)
    Dim prnFontSmall As New Font("CordiaUPC", 10, GraphicsUnit.Point)
    Dim prnFontSmallBold As New Font("CordiaUPC", 10, FontStyle.Bold)
    Dim prnFontVerySmall As New Font("CordiaUPC", 8, GraphicsUnit.Point)
    Dim prnFontBigBold As New Font("CordiaUPC", 14, FontStyle.Bold)

    Dim mRowPos As Single
    Dim mLeftMargin As Single = 5.0F
    Dim mCol2Pos As Single = 70.0F
    Dim mCol3Pos As Single = 260.0F

    Dim mLineNo As Integer
    Dim mLineSpace As Integer = 30
    Dim mLineSpace15 As Integer = 15
    Dim mLineSpace10 As Integer = 10
    Dim mRect As RectangleF
    Dim mAlign As New StringFormat()
    Dim mText As String

    ' ใบกำกับภาษีอย่างย่อ

    ' ชื่อบริษัท
    mLineNo = mLineNo + 1
    mRowPos = mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = pHugName
    e.Graphics.DrawString(mText, prnFontBigBold, Brushes.Black, mRect, mAlign)
    ' เลขประจำตัวผู้เสียภาษี
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "TAX#" & pHugTaxNumber
    e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
    ' ชื่อสาขา
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "สาขา " & pBranchName
    e.Graphics.DrawString(mText, prnFontSmallBold, Brushes.Black, mRect, mAlign)
    ' เลข POS
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "POS#" & pPOSNumber
    e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
    ' หัวเอกสาร
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "ใบเสร็จรับเงิน/ใบกำกับภาษีอย่างย่อ"
    e.Graphics.DrawString(mText, prnFontSmallBold, Brushes.Black, mRect, mAlign)
    ' เลขที่ขาย
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "No. " '& SplitSaleNumb(mSaleNumb)
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' วันที่-เวลา
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = pServerDateTime.ToString("dd'/'MM'/'yy  HH:mm")
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' --------
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = StrDup(80, "-")
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

    ' จำนวน
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "1"
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' ชื่อรายการ
    mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ค่าสมัครสมาชิก"
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' จำนวนเงิน
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = Format(pMembPrice, "#,##0.00")
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' --------
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = StrDup(80, "-")
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' จำนวนเงินรวมทั้งสิ้น
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "จำนวนเงินรวมทั้งสิ้น"
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

    mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = Format(pMembPrice, "#,##0.00")
    e.Graphics.DrawString(mText, prnFontNormalBold, Brushes.Black, mRect, mAlign)

    ' --------
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = StrDup(80, "-")
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' พนักงาน
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "พนักงานขาย " & RemoveNickName(pUserName)
    e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
    ' Cashier
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ผู้รับเงิน " & RemoveNickName(pUserName)
    e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)

    ' VAT INCLUDED
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "*** VAT INCLUDED ***"
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  End Sub
End Class