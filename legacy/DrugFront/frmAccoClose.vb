Public Class frmAccoClose
  Public pUpdate As Boolean

  Dim mTotalSaleCost As Double
  Dim mTotalSaleCostFC As Double
  Dim mTotalReturnCost As Double
  Dim mTotalReturnCostFC As Double
  Dim mTotalCost As Double
  Dim mTotalCostFC As Double
  Dim mTotalCash As Double
  Dim mTotalCredit As Double
  Dim mTotalTran As Double
  Dim mTotalWelfare As Double
  Dim mRemainCash As Double
  Dim mTotalDisc As Double
  Dim mTotalPointDisc As Double
  Dim mTotalReturn As Double
  Dim mTotalSale As Double

  Dim mTotalInDraw As Double
  Dim mTotalStart As Double
  Dim mTotalMoney As Double
  Dim mTotalOver As Double

  Dim mTotalExpense As Double
  Dim mTotalSend As Double

  Dim mTotalCust As Integer
  Dim mAvgSale As Double

  Dim mTotalMembPrice As Double
  Dim mTotalMembCount As Integer

  Dim mCloseNumb As String
  Dim mPrintTitle As String
  Dim mTime As String

  Private Sub frmAccoClose_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Icon = frmMain.Icon

    lblEmplName.Text = pUserName
    pUpdate = False
    ' ใช้วันที่และเวลาของ server
    pServerDateTime = pService.ServerDateTime

    dtpClose.Value = pServerDateTime.Date

    CheckPriv()
  End Sub

  Private Sub frmAccoCloseNew_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.F2
        btnCal.PerformClick()
      Case Keys.F8
        btnSave.PerformClick()
      Case Keys.Escape
        Me.Close()
    End Select
  End Sub

  Private Sub CheckPriv()
    ' Add
    If InStr(pUserPriv, Me.Tag.ToString & "A") > 0 Then
      btnSave.Enabled = True
    Else
      btnSave.Enabled = False
    End If
  End Sub

  Private Sub text_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmplID.KeyPress, txtRemark.KeyPress, txtTotalInDraw.KeyPress, txtTotalStart.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub CalIncome()
    Me.Cursor = Cursors.WaitCursor

    ClearField()

    Dim ds As New DataSet
    Dim dv As DataView
    ' %%%%%%%%%%%%%%%
    ' ยอดขายตามประเภทการชำระเงิน (รวมยอดขายสวัสดิการ แต่ไม่นำไปรวมเป็นยอดขายรวม เริ่ม 1 กค 65)
    mTotalSale = 0
    dtgPaid.Rows.Clear()
    ds = pService.SelectData("Drug", "Select CD.cardOrder, PL.cardCode, CD.cardName, CD.cardColor, sum(PL.payAmou) as payAmou from SalePaidList PL inner join CardInfo CD on CD.cardCode = PL.cardCode inner join HistSale HS on HS.saleNumb = PL.saleNumb where HS.saleStat <> '0' and HS.closeNumb = '0' and HS.saleDate = '" & MDYStr(dtpClose.Value) & "' and HS.branchCode = '" & pBranchCode & "' Group by CD.cardOrder, PL.cardCode, CD.cardName, CD.cardColor Order by CD.cardOrder")
    If IsNothing(ds) = False Then
      dv = New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        Dim mColorConv As New ColorConverter
        For i As Integer = 0 To dv.Count - 1
          With dv.Item(i)
            dtgPaid.Rows.Add()
            dtgPaid.Item("cardCode", dtgPaid.Rows.Count - 1).Value = .Item("cardCode")
            dtgPaid.Item("cardName", dtgPaid.Rows.Count - 1).Value = .Item("cardName")
            dtgPaid.Item("payAmou", dtgPaid.Rows.Count - 1).Value = .Item("payAmou")
            dtgPaid.Rows(dtgPaid.Rows.Count - 1).DefaultCellStyle.BackColor = mColorConv.ConvertFromString(.Item("cardColor"))
            ' รวมยอดขาย (ไม่รวมยอดสวัสดิการ)
            If .Item("cardCode") <> "16" Then
              mTotalSale += .Item("payAmou")
            End If
          End With
        Next
        'dtgPaid.Rows.Add("รวมยอดขาย", mTotalSale)
        'dtgPaid.Rows(dtgPaid.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkBlue
        'dtgPaid.ClearSelection()
      End If
      dv = Nothing
    End If
    ds = Nothing
    ' %%%%%%%%%%%%%%%

    ' ข้อมูลกลุ่มสินค้า
    dtgGroup.Rows.Clear()
    ds = pService.SelectData("Drug", "SELECT groupCode, groupDesc, fromGP, toGP FROM GroupInfo ORDER BY toGP")
    If IsNothing(ds) = False Then
      dv = New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        For i As Integer = 0 To dv.Count - 1
          dtgGroup.Rows.Add()
          dtgGroup.Item("GroupCode", i).Value = dv.Item(i).Item("groupCode")
          dtgGroup.Item("GroupDesc", i).Value = dv.Item(i).Item("groupDesc")
          dtgGroup.Item("FromGP", i).Value = dv.Item(i).Item("FromGP")
          dtgGroup.Item("ToGP", i).Value = dv.Item(i).Item("ToGP")
          dtgGroup.Item("TotalPrice", i).Value = 0
        Next
        dtgGroup.ClearSelection()
      Else
        MessageBox.Show("ไม่มีข้อมูลกลุ่มสินค้า ไม่สามารถสรุปบัญชีได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Me.Cursor = Cursors.Default
        Exit Sub
      End If
      dv = Nothing
    Else
      MessageBox.Show("ไม่มีข้อมูลกลุ่มสินค้า ไม่สามารถสรุปบัญชีได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
      Me.Cursor = Cursors.Default
      Exit Sub
    End If
    ds = Nothing

    ' ยอดสรุปจะไม่รวมการขายที่ยกเลิกหรือเป็นสมาชิก()

    Dim mGet() As String
    ' ส่วนลด
    mGet = pService.GetData("Drug", "SELECT SUM(totalDisc) AS totalDisc, Sum(pointDisc) AS totalPointDisc FROM HistSale WHERE branchCode = '" & pBranchCode & "' AND closeNumb = '0' AND saleDate = '" & MDYStr(dtpClose.Value) & "' AND saleStat <> '0' and custType <> '2'")
    If mGet(0) = "1" Then
      mTotalDisc = Val(mGet(1))
      mTotalPointDisc = Val(mGet(2))
    Else
      mTotalDisc = 0
      mTotalPointDisc = 0
    End If
    dtgPaid.Rows.Add("ส่วนลดจาก HCP", mTotalPointDisc)
    dtgPaid.Rows(dtgPaid.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Gainsboro

    mTotalSale += mTotalPointDisc
    dtgPaid.Rows.Add("รวมยอดขาย (ไม่รวมสวัสดิการ)", mTotalSale)
    dtgPaid.Rows(dtgPaid.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkBlue
    dtgPaid.ClearSelection()

    ' ต้นทุนสินค้าขาย
    mTotalSaleCost = 0
    mTotalSaleCostFC = 0
    mGet = pService.GetData("Drug", "SELECT SUM(SL.goodAmou * UI.unitFactor * SL.unitCost) as totalCostm, SUM(SL.goodAmou * UI.unitFactor * SL.unitCost * GI.fcCostFactor) as totalCostFC FROM HistSale HS INNER JOIN SaleList SL ON SL.saleNumb = HS.saleNumb inner join GoodInfo GI on GI.goodCode = SL.goodCode INNER JOIN UnitInfo UI ON SL.unitCode = UI.unitCode WHERE HS.branchCode = '" & pBranchCode & "' AND HS.closeNumb = '0' AND HS.saleDate = '" & MDYStr(dtpClose.Value) & "' AND HS.saleStat <> '0' and custType <> '2'")
    If mGet(0) = "1" Then
      mTotalSaleCost = Val(mGet(1))
      mTotalSaleCostFC = Val(mGet(2))
      'Else
      '  ' หาก error กลับมาเป็น "Conversion from type 'DBNull' to type 'String' is not valid." แสดงว่าไม่มีรายการสินค้า ให้ต้นทุนเป็น 0
      '  If InStr(mGet(1), "Conversion from type") <> 0 Then
      '    mTotalSaleCost = 0
      '    mTotalSaleCostFC = 0
      '  Else ' error อื่น แสดงว่าไม่สามารถคำนวณได้ ให้คำนวณใหม่
      '    MessageBox.Show("เกิดความผิดพลาดในระหว่างคำนวณสรุปยอดขาย" & vbCrLf & "*** กรุณาสรุปใหม่อีกครั้ง ***", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      '    Me.Cursor = Cursors.Default
      '    Exit Sub
      '  End If
    End If

    ' ต้นทุนสินค้าคืน
    mTotalReturnCost = 0
    mTotalReturnCostFC = 0
    mGet = pService.GetData("Drug", "SELECT sum(RL.goodAmou * RL.unitCost) as totalReturnCost, sum(RL.goodAmou * RL.unitCost * GI.fcCostFactor) as totalReturnCostFC FROM ReturnList RL inner join GoodInfo GI on GI.goodCode = RL.goodCode INNER JOIN HistReturn HR ON HR.returnNumb = RL.returnNumb INNER JOIN HistSale HS ON HR.saleNumb = HS.saleNumb INNER JOIN CustInfo CI ON HS.custCode = CI.custCode WHERE HR.branchCode = '" & pBranchCode & "' AND HR.closeNumb = '0' AND HR.returnDate = '" & MDYStr(dtpClose.Value) & "' AND HR.returnStat = '1' AND CI.custType <> '2'")
    If mGet(0) = "1" Then
      mTotalReturnCost = Val(mGet(1))
      mTotalReturnCostFC = Val(mGet(2))
    End If

    ' รวมต้นทุนทั้งหมด
    mTotalCost = mTotalSaleCost - mTotalReturnCost
    If pIsFranchise = "1" And pBranchTypeCode = "2" Then ' เฉพาะสาขาแฟรนไชส์ partner ship
      mTotalCostFC = mTotalSaleCostFC - mTotalReturnCostFC
    Else
      mTotalCostFC = 0
    End If

    ' คำนวนเงินรับ
    mTotalCash = 0
    mTotalCredit = 0
    mTotalTran = 0
    mTotalWelfare = 0
    ds = pService.SelectData("Drug", "Select CD.cardType, sum(SP.payAmou) as payAmou from SalePaidList SP inner join HistSale HS on HS.saleNumb = SP.saleNumb inner join CardInfo CD on CD.cardCode = SP.cardCode Where HS.saleDate = '" & MDYStr(dtpClose.Value) & "' and HS.branchCode = '" & pBranchCode & "'  and HS.closeNumb = '0' and HS.saleStat <> '0' group by CD.cardType")
    If IsNothing(ds) = False Then
      dv = New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          Select Case .Item("cardType")
            Case "CS" ' เงินสด
              mTotalCash = .Item("payAmou")
            Case "CD"
              mTotalCredit = .Item("payAmou")
            Case "WF"
              mTotalWelfare = .Item("payAmou")
            Case "TO"
              mTotalTran = .Item("payAmou")
          End Select
        End With
      Next
    End If
    ds = Nothing

    ' คืนสินค้า
    mGet = pService.GetData("Drug", "SELECT sum(HR.totalPrice) as totalReturn FROM HistReturn HR INNER JOIN HistSale HS ON HS.saleNumb = HR.saleNumb INNER JOIN CustInfo CI ON CI.custCode = HS.custCode WHERE HR.branchCode = '" & pBranchCode & "' AND HR.closeNumb = '0' AND HR.returnDate = '" & MDYStr(dtpClose.Value) & "' AND HR.returnStat = '1' AND CI.custType <> '2'")
    If mGet(0) = "1" Then
      mTotalReturn = Val(mGet(1))
    Else
      mTotalReturn = 0
    End If
    dtgPaid.Rows.Add("คืนสินค้า", mTotalReturn)
    dtgPaid.Rows(dtgPaid.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkRed

    '' ค่าใช้จ่าย
    'mGet = pService.GetData("Drug", "SELECT SUM(expeAmou) as totalExpense FROM HistExpense WHERE branchCode = '" & pBranchCode & "' AND expeDate = '" & MDYStr(dtpClose.Value) & "' AND closeNumb = '0' AND expeStat <> '0'")
    'If mGet(0) = "1" Then
    '  mTotalExpense = Val(mGet(1))
    'Else
    '  mTotalExpense = 0
    'End If
    'dtgPaid.Rows.Add("ค่าใช้จ่าย", mTotalExpense)
    'dtgPaid.Rows(dtgPaid.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Purple

    ' ไม่คำนวณค่าใช้จ่าย เพื่อไปหักยอดเงินสดคงเหลือ เริ่ม 15 มค 2567
    mTotalExpense = 0

    ' จำนวนลูกค้า
    mGet = pService.GetData("Drug", "SELECT COUNT(saleNumb) FROM HistSale WHERE branchCode = '" & pBranchCode & "' AND closeNumb = '0' AND saleDate = '" & MDYStr(dtpClose.Value) & "' AND saleStat <> '0' AND custType <> '2'")
    If mGet(0) = "1" Then
      mTotalCust = CInt(mGet(1))
    Else
      mTotalCust = 0
    End If

    ' จำนวนสมาชิกใหม่
    mGet = pService.GetData("Drug", "Select Count(custCode) From CustInfo Where custStat <> '0' and enrollDate = '" & MDYStr(dtpClose.Value) & "' And branchCode = '" & pBranchCode & "'")
    If mGet(0) = "1" Then
      mTotalMembCount = CInt(mGet(1))
    Else
      mTotalMembCount = 0
    End If
    ' รวมค่าสมัครสมาชิกใหม่
    mGet = pService.GetData("Drug", "select sum(SL.goodAmou * SL.unitPrice) from SaleList SL inner join HistSale HS on HS.saleNumb = SL.saleNumb where HS.saleStat <> '0' and closeNumb = '0' and HS.branchCode = '" & pBranchCode & "' and HS.saleDate = '" & MDYStr(dtpClose.Value) & "' and SL.goodCode = '11755'")
    If mGet(0) = "1" Then
      mTotalMembPrice = Val(mGet(1))
    Else
      mTotalMembPrice = 0
    End If
    '' รวมค่าสมัครสมาชิกใหม่
    'mGet = pService.GetData("Drug", "Select Sum(membPrice) As totalMembPrice From CustInfo Where custStat <> '0' and enrollDate = '" & MDYStr(dtpClose.Value) & "' And branchCode = '" & pBranchCode & "'")
    'If mGet(0) = "1" Then
    '  mTotalMembPrice = CDbl(mGet(1))
    'Else
    '  mTotalMembPrice = 0
    'End If

    ' เงินสดคงเหลือ
    mRemainCash = (mTotalCash - mTotalReturn - mTotalExpense).ToString("#,##0.00")

    dtgPaid.Rows.Add("เงินสดคงเหลือ", mRemainCash)
    dtgPaid.Rows(dtgPaid.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkGreen

    lblTotalCust.Text = mTotalCust.ToString("#,##0")
    If mTotalCust > 0 Then
      mAvgSale = mTotalSale / mTotalCust
    Else
      mAvgSale = 0
    End If
    lblAvgSale.Text = mAvgSale.ToString("#,##0.00")

    lblTotalMembPrice.Text = mTotalMembPrice.ToString("#,##0.00")
    lblTotalMembCount.Text = mTotalMembCount.ToString("#,##0")

    ' Clear ค่า
    For i As Integer = 0 To dtgGroup.Rows.Count - 1
      dtgGroup.Item("TotalPrice", i).Value = 0
    Next

    ' จัดกลุ่ม GP จากการขาย
    Dim mTotalGroupPrice As Double
    ds = pService.SelectData("Drug", "SELECT SL.goodCode, SL.unitPrice, SL.unitCost, SL.goodAmou, SL.subDisc, HS.perCharge, GI.groupCode, GI.fixGroup, GI.fcCostFactor FROM SaleList SL inner join HistSale HS ON SL.saleNumb = HS.saleNumb inner join GoodInfo GI on SL.goodCode = GI.goodCode WHERE HS.branchCode = '" & pBranchCode & "' AND HS.closeNumb = '0' AND HS.saleDate = '" & MDYStr(dtpClose.Value) & "' AND HS.saleStat <> '0' AND HS.custType <> '2'")
    If IsNothing(ds) = False Then
      dv = New DataView(ds.Tables(0))
      Dim mGoodAmou As Integer
      Dim mUnitPrice, mUnitCost, mSubDisc, mPerCharge As Single
      Dim mPrice, mCost, mGP As Double
      For i As Integer = 0 To dv.Count - 1
        mGoodAmou = CInt(dv.Item(i).Item("goodAmou"))
        mUnitPrice = CSng(dv.Item(i).Item("unitPrice"))
        If pIsFranchise = "1" And pBranchTypeCode = "2" Then ' เฉพาะสาขาแฟรนไชส์ partner ship
          mUnitCost = dv.Item(i).Item("unitCost") * dv.Item(i).Item("fcCostFactor")
        Else
          mUnitCost = dv.Item(i).Item("unitCost")
        End If
        mUnitCost = CSng(dv.Item(i).Item("unitCost"))
        mSubDisc = CSng(dv.Item(i).Item("subDisc"))
        mPerCharge = CSng(dv.Item(i).Item("perCharge"))
        ' ราคาที่ขายได้ = จำนวน * หน่วยละ - ส่วนลด
        mPrice = mGoodAmou * mUnitPrice - mSubDisc
        ' ราคาทุน
        mCost = mGoodAmou * mUnitCost

        ' ถ้า fix group ไม่ต้องคำนวน GP ใหม่ ให้นำจำนวนเงินเข้ากลุ่มเลย
        If dv.Item(i).Item("fixGroup").ToString = "1" Then
          For Each mRow As DataGridViewRow In dtgGroup.Rows
            If dv.Item(i).Item("groupCode").ToString = dtgGroup.Item("groupCode", mRow.Index).Value.ToString Then
              dtgGroup.Item("TotalPrice", mRow.Index).Value = CDbl(dtgGroup.Item("TotalPrice", mRow.Index).Value) + mPrice
              mTotalGroupPrice += mPrice

            End If
          Next
        Else
          ' คำนวน GP เพื่อจัดกลุ่มใหม่
          If mPrice > 0 Then
            mGP = (mPrice - mCost) * 100 / mPrice
          Else
            mGP = 0
          End If
          ' จัดกลุ่มตาม GP ใหม่
          For x As Integer = 0 To dtgGroup.Rows.Count - 1
            If mGP <= CSng(dtgGroup.Item("ToGP", x).Value) Then
              dtgGroup.Item("TotalPrice", x).Value = CDbl(dtgGroup.Item("TotalPrice", x).Value) + mPrice
              mTotalGroupPrice += mPrice
              Exit For
            End If
          Next
        End If
      Next
      dv = Nothing
    End If
    ds = Nothing

    ' จัดกลุ่ม GP จากการคืน
    ds = pService.SelectData("Drug", "SELECT RL.goodCode, RL.unitPrice, RL.unitCost, RL.goodAmou, GI.fcCostFactor FROM ReturnList RL inner join GoodInfo GI on GI.goodCode = RL.goodCode INNER JOIN HistReturn HR ON RL.returnNumb = HR.returnNumb INNER JOIN HistSale HS ON HR.saleNumb = HS.saleNumb INNER JOIN CustInfo CI ON HS.custCode = CI.custCode WHERE HR.branchCode = '" & pBranchCode & "' AND HR.closeNumb = '0' AND HR.returnDate = '" & MDYStr(dtpClose.Value) & "' AND HR.returnStat <> '0' AND CI.custType <> '2'")
    If IsNothing(ds) = False Then
      dv = New DataView(ds.Tables(0))
      Dim mGoodAmou As Integer
      Dim mUnitPrice, mUnitCost As Single
      Dim mPrice, mCost, mGP As Double
      For i As Integer = 0 To dv.Count - 1
        mGoodAmou = CInt(dv.Item(i).Item("goodAmou"))
        mUnitPrice = CSng(dv.Item(i).Item("unitPrice"))
        If pIsFranchise = "1" And pBranchTypeCode = "2" Then ' เฉพาะสาขาแฟรนไชส์ partner ship
          mUnitCost = dv.Item(i).Item("unitCost") * dv.Item(i).Item("fcCostFactor")
        Else
          mUnitCost = dv.Item(i).Item("unitCost")
        End If

        ' ราคาที่ขายได้ = จำนวน * หน่วยละ
        mPrice = Math.Round(mGoodAmou * mUnitPrice, 2)
        mCost = mGoodAmou * mUnitCost
        If mPrice > 0 Then
          mGP = (mPrice - mCost) * 100 / mPrice
        Else
          mGP = 0
        End If
        For x As Integer = 0 To dtgGroup.Rows.Count - 1
          If mGP <= CSng(dtgGroup.Item("ToGP", x).Value) Then
            dtgGroup.Item("TotalPrice", x).Value = CDbl(dtgGroup.Item("TotalPrice", x).Value) - mPrice
            mTotalGroupPrice -= mPrice
            Exit For
          End If
        Next
      Next
      dv = Nothing
    End If
    ds = Nothing
    ' รวม
    'lblTotalGroupPrice.Text = Format(mTotalGroupPrice, "#,##0.0000")
    ' แสดง GP ให้เห็น
    'If mTotalSale > 0 Then
    '  'lblGP.Text = "GP = " & Format((mTotalSale - mTotalCost) * 100 / mTotalSale, "#,##0.00")

    '  ' ต้องการให้คำนวณ GP จากราคาขายรวมกับส่วนลดด้วย เพื่อให้เห็น GP ก่อนลด (1/12/2557)
    '  lblGP.Text = "GP = " & Format((mTotalSale + mTotalDisc - mTotalCost) * 100 / (mTotalSale + mTotalDisc), "#,##0.00")
    'Else
    '  lblGP.Text = "GP = ???"
    'End If

    dtgGroup.Rows.Add()
    If pIsFranchise = "1" And pBranchTypeCode = "2" Then ' เฉพาะสาขาแฟรนไชส์ partner ship ใช้ทุน FC
      dtgGroup.Item("GroupDesc", dtgGroup.Rows.Count - 1).Value = "รวม (GP = " & Format((mTotalSale + mTotalDisc - mTotalCostFC) * 100 / (mTotalSale + mTotalDisc), "#,##0.00" & ")")
    Else
      dtgGroup.Item("GroupDesc", dtgGroup.Rows.Count - 1).Value = "รวม (GP = " & Format((mTotalSale + mTotalDisc - mTotalCost) * 100 / (mTotalSale + mTotalDisc), "#,##0.00" & ")")
    End If
    dtgGroup.Item("TotalPrice", dtgGroup.Rows.Count - 1).Value = mTotalGroupPrice
    dtgGroup.Rows(dtgGroup.Rows.Count - 1).DefaultCellStyle.BackColor = Color.FromArgb(187, 159, 159)

    Me.Cursor = Cursors.Default

    txtTotalInDraw.Focus()
  End Sub

  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    If dtgPaid.Rows.Count = 0 Then
      pMessageBox = New MyMessageBox("กรุณาคำนวณยอดขาย ก่อนสรุปบัญชี", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      pMessageBox.ShowDialog()
      Exit Sub
    End If

    ' ตรวจสอบรายการแยกกลุ่มว่ามีข้อมูลจำนวนเงินหรือไม่
    Dim mTotalPrice As Double
    For Each mRow As DataGridViewRow In dtgGroup.Rows
      mTotalPrice += CDbl(dtgGroup.Item("totalPrice", mRow.Index).Value)
    Next
    If mTotalPrice <= 0 Then
      pMessageBox = New MyMessageBox("ตารางสรุปยอดขายแยกตามกลุ่มไม่มีข้อมูล" & vbCrLf & "กรุณายืนยันต้องการสรุปบัญชี", "คำเตือน", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
      If pMessageBox.ShowDialog = Windows.Forms.DialogResult.Cancel Then
        Exit Sub
      End If
    End If

    If Val(txtTotalInDraw.Text) <= 0 Then
      pMessageBox = New MyMessageBox("ไม่มียอดเงินสดจากการนับ กรุณายืนยันต้องการสรุปบัญชี", "คำเตือน", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
      If pMessageBox.ShowDialog = Windows.Forms.DialogResult.Cancel Then
        Exit Sub
      End If
    End If

    If txtEmplID.Text <> pUserID Then
      pMessageBox = New MyMessageBox("เลขประจำตัวพนักงานไม่ถูกต้อง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      pMessageBox.ShowDialog()
      txtEmplID.Text = ""
      txtEmplID.Focus()
      Exit Sub
    End If

    pMessageBox = New MyMessageBox("ยืนยันสรุปบัญชี-ปิดรอบการทำงาน", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
    If pMessageBox.ShowDialog = Windows.Forms.DialogResult.OK Then
      btnSave.Enabled = False
      Me.Cursor = Cursors.WaitCursor
      'If mTotalCash + mTotalCredit <= 0 Then
      '  If MessageBox.Show("ยอดเงินรวมเป็นศูนย์ กรุณายืนยันอีกครั้ง", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
      '    Exit Sub
      '  End If
      'End If

      Dim mSqlText(dtgGroup.Rows.Count + 5 + dtgPaid.Rows.Count) As String
      Dim mLine As Integer = 0
      Dim mGet() As String

      mGet = pService.GetData("Drug", "SELECT closeNumb FROM BranchInfo WHERE branchCode = '" & pBranchCode & "'")
      If mGet(0) = "1" Then
        mCloseNumb = pBranchCode & "-" & Mid((1000000 + CInt(mGet(1))).ToString, 2)
      Else
        MessageBox.Show(mGet(1), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Exit Sub
      End If

      ' ใช้วันที่และเวลาของ server
      pServerDateTime = pService.ServerDateTime

      ' ถ้าสรุปไม่ตรงวันปัจจุบัน ให้เวลาเป็น 00:00
      If dtpClose.Value <> pServerDateTime.Date Then ' Date.Today Then
        mTime = "00:00"
      Else
        mTime = Format(pServerDateTime, "HH:mm") ' Format(Now, "HH:mm")
      End If

      mSqlText(mLine) = "INSERT INTO AccoClose (closeNumb, closeDate, closeTime, emplCode, remark, branchCode, totalCost, totalCostFC, totalCash, totalCredit, totalDebt, totalCupong, totalCharge, totalDisc, totalReturn, totalInDraw, totalStart, totalExpense, totalCust, totalPointDisc, totalWelfare, totalMembCount, totalMembPrice) VALUES ('" & mCloseNumb & "', '" & MDYStr(dtpClose.Value) & "', '" & mTime & "', '" & pUserCode & "', '" & txtRemark.Text & "', '" & pBranchCode & "', " & mTotalCost & ", " & mTotalCostFC & ", " & mTotalCash & ", " & mTotalCredit & ", " & mTotalTran & ", 0, 0, " & mTotalDisc & ", " & mTotalReturn & ", " & mTotalInDraw & ", " & mTotalStart & ", " & mTotalExpense & ", " & mTotalCust & ", " & mTotalPointDisc & ", " & mTotalWelfare & ", " & mTotalMembCount & ", " & mTotalMembPrice & ")"
      mLine += 1

      mSqlText(mLine) = "UPDATE HistSale SET closeNumb = '" & mCloseNumb & "', saleStat = '2' WHERE branchCode = '" & pBranchCode & "' AND closeNumb = '0' AND saleDate = '" & MDYStr(dtpClose.Value) & "' AND saleStat <> '0'"
      mLine += 1

      mSqlText(mLine) = "UPDATE HistReturn SET closeNumb = '" & mCloseNumb & "' WHERE branchCode = '" & pBranchCode & "' AND closeNumb = '0' AND returnDate = '" & MDYStr(dtpClose.Value) & "' AND returnStat = '1'"
      mLine += 1

      mSqlText(mLine) = "UPDATE HistExpense SET closeNumb = '" & mCloseNumb & "' WHERE branchCode = '" & pBranchCode & "' AND closeNumb = '0' AND expeDate = '" & MDYStr(dtpClose.Value) & "' AND expeStat = '1'"
      mLine += 1

      mSqlText(mLine) = "UPDATE BranchInfo SET closeNumb = closeNumb + 1, closeDate = '" & MDYStr(pServerDateTime.Date) & "', closeTime = '" & Format(pServerDateTime, "HH:mm") & "' WHERE branchCode = '" & pBranchCode & "'"
      mLine += 1
      ' $$$$$$$$$$$$$$$$$$$
      ' เก็บข้อมูลแยกประเภทการชำระ
      For Each mRow As DataGridViewRow In dtgPaid.Rows
        If dtgPaid.Item("cardCode", mRow.Index).Value <> "" Then
          mSqlText(mLine) = "Insert into AccoList (closeNumb, cardCode, payAmou) values ('" & mCloseNumb & "', '" & dtgPaid.Item("cardCode", mRow.Index).Value.ToString & "', " & dtgPaid.Item("payAmou", mRow.Index).Value & ")"
          mLine += 1
        End If
      Next
      ' $$$$$$$$$$$$$$$$$$$
      ' เก็บข้อมูลสรุปแยกตามกลุ่มสินค้า
      For Each mRow As DataGridViewRow In dtgGroup.Rows
        If dtgGroup.Item("groupCode", mRow.Index).Value <> "" Then
          mSqlText(mLine) = "INSERT INTO AccoGroupClose (closeDate, branchCode, groupDesc, totalprice) VALUES ('" & MDYStr(dtpClose.Value) & "', '" & pBranchCode & "', '" & dtgGroup.Item("GroupDesc", mRow.Index).Value.ToString & "', " & Val(dtgGroup.Item("TotalPrice", mRow.Index).Value) & ")"
          mLine += 1
        End If
      Next

      Dim retValue As String
      retValue = pService.UpdateData("Drug", mSqlText)
      If retValue = "1" Then
        Try
          ' พิมพ์ใบสรุปยอดขาย
          mPrintTitle = "1"
          pdc1.Print()
          '' พิมพ์ใบสรุปยอดสมาชิก
          'mPrintTitle = "3"
          'pdc1.Print()
          '' พิมพ์ใบแยกกลุ่มสินค้า
          'mPrintTitle = "2"
          'pdc1.Print()

          'If mTotalMembPrice > 0 OrElse mTotalMembCount > 0 Then
          '  mPrintTitle = "3"
          '  pdc1.Print()
          'End If

          pUpdate = True
        Catch ex As Exception

        End Try
        pMessageBox = New MyMessageBox("บันทึกสรุปบัญชี-ปิดรอบทำงานเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        pMessageBox.ShowDialog()
        Me.Close()
      Else
        pMessageBox = New MyMessageBox("ไม่สามารถสรุปบัญชีได้ -> " & retValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        pMessageBox.ShowDialog()
        Me.Cursor = Cursors.Default
      End If
    End If
  End Sub

  Private Sub pdc1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdc1.PrintPage
    Dim prnFont As New Font("CordiaUPC", 12, GraphicsUnit.Point)
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

    Select Case mPrintTitle
      Case "1" ' ยอดสรุปเก็บ
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
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' หัวเอกสาร
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Center
        mText = "ใบสรุปบัญชีประจำวัน"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' วันที่สรุป
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Center
        mText = dtpClose.Value.ToString("dd/MM/yyyy") & "  " & mTime
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' เลขที่
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = mCloseNumb
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        For Each mRow As DataGridViewRow In dtgPaid.Rows
          mLineNo = mLineNo + 1
          mRowPos = mLineNo * mLineSpace
          mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
          mAlign.Alignment = StringAlignment.Near
          mText = dtgPaid.Item("cardName", mRow.Index).Value
          e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

          mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
          mAlign.Alignment = StringAlignment.Far
          mText = MyVal(dtgPaid.Item("payAmou", mRow.Index).Value).ToString("#,##0.00")
          e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        Next
        ' --------
        mRect = New RectangleF(mLeftMargin, mRowPos + 15, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = "-----------------"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' เงินสดจากการนับ
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "เงินสดจากการนับ"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = mTotalInDraw.ToString("#,##0.00")
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' เงินต้น
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "เงินต้น"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = mTotalStart.ToString("#,##0.00")
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' --------
        mRect = New RectangleF(mLeftMargin, mRowPos + 15, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = "-----------------"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' เงินนำส่ง
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "เงินสดนำส่ง"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = mTotalSend.ToString("#,##0.00")
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' --------
        mRect = New RectangleF(mLeftMargin, mRowPos + 15, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = "-----------------"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' ขาด-เกิน
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "ขาด-เกิน"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = mTotalOver.ToString("#,##0.00")
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        mRect = New RectangleF(mLeftMargin, mRowPos + 15, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = "-----------------"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' หมายเหตุ
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "หมายเหตุ : " & txtRemark.Text
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        ' จำนวนลูกค้ารวม
        mLineNo = mLineNo + 2
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "จำนวนลูกค้ารวม"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = mTotalCust.ToString("#,##0")
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' จำนวนสมาชิกใหม่
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "จำนวนสมาชิกใหม่"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = mTotalMembCount.ToString("#,##0")
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' ค่าสมัครสมาชิกใหม่
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "รวมค่าสมัครสมาชิกใหม่"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = mTotalMembPrice.ToString("#,##0.00")
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        '' ขายเฉลี่ย/ใบ
        'mLineNo = mLineNo + 1
        'mRowPos = mLineNo * mLineSpace
        'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        'mAlign.Alignment = StringAlignment.Near
        'mText = "ขายเฉลี่ย/ราย"
        'e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        'mAlign.Alignment = StringAlignment.Far
        'mText = mAvgSale.ToString("#,##0.00")
        'e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        ' แคชเชียร์
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "แคชเชียร์ : " & pUserName
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' วันที่ที่พิมพ์
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = pServerDateTime.Date.ToString("dd/MM/yyyy") & "  " & Format(pServerDateTime, "HH:mm")
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' ผู้ตรวจสอบ
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "ผู้ตรวจสอบ ________________________ "
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
      Case "2" ' ยอดสรุปแยกตามกลุ่มสินค้า
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
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' หัวเอกสาร
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Center
        mText = "รายงานสรุปยอดขาย"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' วันที่
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Center
        mText = dtpClose.Value.ToString("dd/MM/yyyy") & "  " & mTime
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        mRect = New RectangleF(mLeftMargin, mRowPos + 15, 260.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "-------------------------------------------------------------------"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        ' ################# รวมยอดกลุ่ม 3 4 5 6 เป็นกลุ่มเดียวกัน
        Dim mSum As Double
        mSum = 0
        For i As Integer = 2 To dtgGroup.Rows.Count - 2 '(เว้นบรรทัดสุดท้าย เป็นยอดรวม ไม่นำมาคิด)
          mSum = mSum + CDbl(dtgGroup.Item("TotalPrice", i).Value)
        Next
        Dim mTotal As Double
        Dim mAllTotal As Double
        For i As Integer = 0 To dtgGroup.Rows.Count - 2 '(เว้นบรรทัดสุดท้าย เป็นยอดรวม ไม่นำมาคิด)
          If i < 2 Then ' กลุ่ม 1 2 ให้พิมพ์ตามปกติ
            mTotal = CDbl(dtgGroup.Item("TotalPrice", i).Value)

            mLineNo = mLineNo + 1
            mRowPos = mLineNo * mLineSpace
            mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
            mAlign.Alignment = StringAlignment.Near
            mText = dtgGroup.Item("GroupDesc", i).Value.ToString
            e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

            mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
            mAlign.Alignment = StringAlignment.Far
            mText = mTotal.ToString("#,##0.0000")
            e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
            mAllTotal += mTotal
          Else
            mTotal = mSum

            mLineNo = mLineNo + 1
            mRowPos = mLineNo * mLineSpace
            mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
            mAlign.Alignment = StringAlignment.Near
            mText = dtgGroup.Item("GroupDesc", i).Value.ToString
            e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

            mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
            mAlign.Alignment = StringAlignment.Far
            mText = mTotal.ToString("#,##0.0000")
            e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
            mAllTotal += mTotal
            Exit For ' พิมพ์ถึงกลุ่ม 3 เท่านั้น
          End If
        Next
        ' #####################

        '' พิมพ์ตามกลุ่ม
        'Dim mTotal As Double
        'Dim mAllTotal As Double
        'For i As Integer = 0 To dtgGroup.Rows.Count - 1
        '  mTotal = CDbl(dtgGroup.Item("TotalPrice", i).Value)

        '  mLineNo = mLineNo + 1
        '  mRowPos = mLineNo * mLineSpace
        '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        '  mAlign.Alignment = StringAlignment.Near
        '  mText = dtgGroup.Item("GroupDesc", i).Value.ToString
        '  e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        '  mAlign.Alignment = StringAlignment.Far
        '  mText = mTotal.ToString("#,##0.0000")
        '  e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        '  mAllTotal += mTotal
        'Next

        mRect = New RectangleF(mLeftMargin, mRowPos + 15, 260.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "-------------------------------------------------------------------"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' รวม
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "รวมทั้งสิ้น"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = mAllTotal.ToString("#,##0.0000")
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        mRect = New RectangleF(mLeftMargin, mRowPos + 15, 260.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "-------------------------------------------------------------------"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
      Case "3" ' สรุปยอดสมาชิก
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
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' หัวเอกสาร
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Center
        mText = "ใบสรุปค่าสมัครสมาชิก"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' วันที่
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Center
        mText = dtpClose.Value.ToString("dd/MM/yyyy") & "  " & mTime
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        mRect = New RectangleF(mLeftMargin, mRowPos + 15, 260.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "-------------------------------------------------------------------"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        '' ค่าสมัครสมาชิกใหม่
        'mLineNo = mLineNo + 1
        'mRowPos = mLineNo * mLineSpace
        'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        'mAlign.Alignment = StringAlignment.Near
        'mText = "ค่าสมัครสมาชิก VIP"
        'e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        'mAlign.Alignment = StringAlignment.Far
        'mText = mTotalMembPrice.ToString("#,##0")
        'e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
        ' จำนวนสมาชิกใหม่
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "จำนวนสมาชิก"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = mTotalMembCount.ToString("#,##0")
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

        mRect = New RectangleF(mLeftMargin, mRowPos + 15, 260.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "-------------------------------------------------------------------"
        e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)
    End Select
  End Sub

  Private Sub txtTotalInDraw_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalInDraw.LostFocus
    CalMoney()
  End Sub

  Private Sub txtTotalStart_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalStart.LostFocus
    CalMoney()
  End Sub

  Private Sub CalMoney()
    mTotalInDraw = MyVal(txtTotalInDraw.Text)
    mTotalStart = MyVal(txtTotalStart.Text)
    mTotalSend = mTotalInDraw - mTotalStart
    txtTotalInDraw.Text = mTotalInDraw.ToString("#,##0.00")
    txtTotalStart.Text = mTotalStart.ToString("#,##0.00")
    lblTotalSend.Text = mTotalSend.ToString("#,##0.00")
    'lblTotalMoney.Text = mTotalMoney.ToString("#,##0.00")

    'mTotalOver = mTotalSend - (mTotalCash - mTotalReturn - mTotalExpense)
    ' ไม่หักค่าใช้จ่าย เริ่ม 15 มค 2567
    mTotalOver = mTotalSend - (mTotalCash - mTotalReturn)
    lblTotalOver.Text = mTotalOver.ToString("#,##0.00")
  End Sub

  Private Sub btnCal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCal.Click
    CalIncome()
    btnSave.Enabled = True
    txtTotalInDraw.Select()
  End Sub

  Private Sub dtpClose_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpClose.ValueChanged
    ClearField()
  End Sub

  Private Sub ClearField()
    txtTotalInDraw.Text = ""
    txtTotalStart.Text = ""
    lblTotalSend.Text = ""
    lblTotalOver.Text = ""
    lblTotalCust.Text = ""
    lblAvgSale.Text = ""
    'lblTotalMembPrice.Text = ""
    lblTotalMembCount.Text = ""
    txtEmplID.Text = ""
    txtRemark.Text = ""
    dtgGroup.Rows.Clear()
    dtgPaid.Rows.Clear()

    mTotalSaleCost = 0
    mTotalReturnCost = 0
    mTotalCost = 0
    mTotalCash = 0
    mTotalDisc = 0
    mTotalReturn = 0
    mTotalSale = 0

    mTotalInDraw = 0
    mTotalStart = 0
    mTotalMoney = 0
    mTotalOver = 0

    mTotalExpense = 0
    mTotalSend = 0

    mTotalCust = 0
    mAvgSale = 0

    mTotalMembPrice = 0
    mTotalMembCount = 0

    'tspPgb.Visible = False
  End Sub
End Class