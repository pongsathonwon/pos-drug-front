Public Class frmBillVatPrint

  Public pCustCode As String
  Public pSaleNumb As String
  Public pTaxName As String
  Public pTaxAddr As String
  Public pTaxID As String
  Public pTaxInvoiceNumb As String
  Public pOk As Boolean

  Dim mFound As Boolean

  Private Sub frmBillVatPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Icon = frmMain.Icon

    pOk = False

    ShowTaxInfo(pSaleNumb)
  End Sub

  Private Sub ShowTaxInfo(ByVal SaleNumb As String)
    Dim mGet() As String
    mGet = pService.GetData("Drug", "Select custName, custAddr, taxID, taxInvoiceNumb, custEmail, custPhone, taxIDTypeID, taxBranchCode from HistSaleTaxInfo where saleNumb = '" & SaleNumb & "'")
    If mGet(0) = "1" Then
      txtTaxName.Text = mGet(1)
      txtTaxAddr.Text = mGet(2)
      txtTaxID.Text = mGet(3)
      txtTaxInvoiceNumb.Text = mGet(4)
      txtEmail.Text = mGet(5)
      txtPhone.Text = mGet(6)
      Select Case Val(mGet(7))
        Case 1
          radTaxTypeMisc.Checked = True
        Case 2
          radTaxTypeLegal.Checked = True
        Case 3
          radTaxTypeGen.Checked = True
        Case 4
          radTaxTypePassport.Checked = True
      End Select
      txtTaxBranch.Text = mGet(8)
      mFound = True
    Else
      mFound = False
      txtTaxInvoiceNumb.Text = ""
      ' กรณีเป็นใบภาษีใหม่ ให้ค้นหาข้อมูลชื่อที่อยู่ผู้เสียภาษีมาป้อนเป็นค่า default
      If pCustCode <> "0" Then ' ยกเว้นลูกค้าทั่วไป
        Dim ds As New DataSet
        ds = pService.SelectData("Drug", "Select top 1 ST.* from HistSaleTaxInfo ST inner join HistSale HS on HS.saleNumb = ST.saleNumb where HS.saleStat <> '0' and HS.custCode = '" & pCustCode & "' order by HS.saleDate desc")
        If IsNothing(ds) = False Then
          Dim dv As New DataView(ds.Tables(0))
          If dv.Count > 0 Then
            With dv.Item(0)
              txtTaxName.Text = .Item("custName")
              txtTaxAddr.Text = .Item("custAddr")
              txtTaxID.Text = .Item("taxID")
              Select Case .Item("taxIDTypeID")
                Case 1
                  radTaxTypeMisc.Checked = True
                Case 2
                  radTaxTypeLegal.Checked = True
                Case 3
                  radTaxTypeGen.Checked = True
                Case 4
                  radTaxTypePassport.Checked = True
              End Select
              txtTaxBranch.Text = .Item("taxBranchCode")

              txtTaxInvoiceNumb.Text = ""
              txtEmail.Text = ""
              txtPhone.Text = ""
            End With
          Else
            txtTaxName.Text = ""
            txtTaxAddr.Text = ""
            txtTaxID.Text = ""
            txtTaxInvoiceNumb.Text = ""
            txtEmail.Text = ""
            txtPhone.Text = ""
            radTaxTypeLegal.Checked = False
            radTaxTypeGen.Checked = False
            radTaxTypePassport.Checked = False
            radTaxTypeMisc.Checked = False
            txtTaxBranch.Text = ""
          End If
          dv = Nothing
        End If
        ds = Nothing
      Else
        txtTaxName.Text = ""
        txtTaxAddr.Text = ""
        txtTaxID.Text = ""
        txtTaxInvoiceNumb.Text = ""
        txtEmail.Text = ""
        txtPhone.Text = ""
        radTaxTypeLegal.Checked = False
        radTaxTypeGen.Checked = False
        radTaxTypePassport.Checked = False
        radTaxTypeMisc.Checked = False
        txtTaxBranch.Text = ""
      End If
    End If

    'If txtTaxInvoiceNumb.Text = "" Then
    '  mGet = pService.GetData("Drug", "SELECT taxInvoiceNumb FROM BranchInfo WHERE branchCode = '" & pBranchCode & "'")
    '  If mGet(0) = "1" Then
    '    txtTaxInvoiceNumb.Text = pPreTaxInvoiceNumb & Mid((100000 + CInt(mGet(1))).ToString, 2)
    '  Else
    '    MessageBox.Show(mGet(1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '  End If
    'End If
  End Sub

  Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    pOk = False
    Me.Close()
  End Sub

  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    If Trim(txtTaxName.Text) = "" Or Trim(txtTaxAddr.Text) = "" Or Trim(txtTaxID.Text) = "" Or Trim(txtEmail.Text) = "" Or Trim(txtPhone.Text) = "" Or (radTaxTypeLegal.Checked = False And radTaxTypeGen.Checked = False And radTaxTypePassport.Checked = False) Then
      pMessageBox = New MyMessageBox("กรุณาป้อนข้อมูลให้ครบ (เครื่องหมาย * คือข้อมูลที่จำเป็นต้องป้อน)", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      pMessageBox.ShowDialog()
      Exit Sub
    End If

    'If txtTaxInvoiceNumb.Text = "" Then
    '  pMessageBox = New MyMessageBox("ไม่สามารถกำหนดเลขที่ใบกำกับภาษีได้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '  pMessageBox.ShowDialog()
    '  Exit Sub
    'End If

    If txtEmail.Text <> "" AndAlso IsValidEmailFormat(txtEmail.Text) = False Then
      pMessageBox = New MyMessageBox("รูปแบบอีเมล์ไม่ถูกต้อง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      pMessageBox.ShowDialog()
      Exit Sub
    End If

    ' ประเภทธุรกิจ
    Dim mTaxTypeID As Integer
    If radTaxTypeLegal.Checked = True Then
      mTaxTypeID = 2 ' นิติบุคคล
    Else
      If radTaxTypeGen.Checked = True Then
        mTaxTypeID = 3 ' บุคคลทั่วไป
      Else
        If radTaxTypePassport.Checked = True Then
          mTaxTypeID = 4 ' พาสปอร์ต
        Else
          mTaxTypeID = 1 ' อื่นๆ
        End If
      End If
    End If

    Dim mSqlText(1) As String
    ' แก้ไขข้อมูลเดิม
    If mFound = True Then
      mSqlText(0) = "Update HistSaleTaxInfo set custName = '" & txtTaxName.Text & "', custAddr = '" & txtTaxAddr.Text & "', taxID = '" & txtTaxID.Text & "', taxInvoiceNumb = '" & txtTaxInvoiceNumb.Text & "', custEmail = '" & txtEmail.Text & "', custPhone = '" & txtPhone.Text & "', taxIDTypeID = " & mTaxTypeID & ", taxBranchCode = '" & txtTaxBranch.Text & "' Where saleNumb = '" & pSaleNumb & "'"
    Else
      ' เพิ่มใบกำกับภาษีใหม่
      Dim mGet() As String
      mGet = pService.GetData("Drug", "SELECT taxInvoiceNumb FROM BranchInfo WHERE branchCode = '" & pBranchCode & "'")
      If mGet(0) = "1" Then
        txtTaxInvoiceNumb.Text = pPreTaxInvoiceNumb & Mid((100000 + CInt(mGet(1))).ToString, 2)
      Else
        MessageBox.Show(mGet(1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      End If

      mSqlText(0) = "Insert into HistSaleTaxInfo (saleNumb, custName, custAddr, taxID, taxInvoiceNumb, custEmail, custPhone, taxIDTypeID, taxBranchCode) values ('" & pSaleNumb & "', '" & txtTaxName.Text & "', '" & txtTaxAddr.Text & "', '" & txtTaxID.Text & "', '" & txtTaxInvoiceNumb.Text & "', '" & txtEmail.Text & "', '" & txtPhone.Text & "', " & mTaxTypeID & ", '" & txtTaxBranch.Text & "')"
      mSqlText(1) = "Update BranchInfo set taxInvoiceNumb = taxInvoiceNumb + 1 where branchCode = '" & pBranchCode & "'"
    End If

    Dim mUpdate As String
    mUpdate = pService.UpdateData("Drug", mSqlText)
    If mUpdate <> "1" Then
      MessageBox.Show(mUpdate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End If

    pTaxName = txtTaxName.Text
    pTaxAddr = txtTaxAddr.Text
    pTaxID = txtTaxID.Text
    pTaxInvoiceNumb = txtTaxInvoiceNumb.Text
    pOk = True
    Me.Close()
  End Sub

  Private Sub txtTaxName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTaxName.KeyPress, txtTaxAddr.KeyPress, txtTaxID.KeyPress, txtEmail.KeyPress, txtPhone.KeyPress, txtTaxBranch.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  'Private Sub InitTaxTypeInfo()
  '  cboTaxTypeID.Items.Clear()
  '  cboTaxIDTypeDesc.Items.Clear()

  '  Dim ds As New DataSet
  '  ds = pService.SelectData("Drug", "Select * from TaxTypeInfo order by taxIDTypeDesc")
  '  If IsNothing(ds) = False Then
  '    Dim dv As New DataView(ds.Tables(0))
  '    For i As Integer = 0 To dv.Count - 1
  '      cboTaxTypeID.Items.Add(dv.Item(i).Item("taxIDTypeCode"))
  '      cboTaxIDTypeDesc.Items.Add(dv.Item(i).Item("id"))
  '    Next
  '  End If
  '  ds = Nothing
  'End Sub

  'Private Sub cboTaxIDTypeCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTaxTypeID.SelectedIndexChanged
  '  cboTaxIDTypeDesc.SelectedIndex = cboTaxTypeID.SelectedIndex
  'End Sub

  'Private Sub cboTaxIDTypeDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTaxIDTypeDesc.SelectedIndexChanged
  '  cboTaxTypeID.SelectedIndex = cboTaxIDTypeDesc.SelectedIndex
  'End Sub

End Class