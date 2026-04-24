Public Class frmSale

  Public pDVCredit As DataView
  Public pDVEmpl As DataView

  Dim mSaleNumb As String
  Dim mSaleAmou As Integer
  Dim mUnitPrice As Double = 0
  Dim mTotalPrice As Double
  Dim mTotalPriceNet As Double
  Dim mTotalGoodProPrice As Double
  Dim mTotalCost As Single
  Dim mTotalDisc As Double
  Dim mTotalCashPay, mTotalCash, mTotalCredit, mTotalDebt, mTotalCupong As Double
  Dim mTotalChange As Double
  Dim mPerCharge As Double
  Dim mPayType As String
  Dim mCreditNumb As String
  Dim mEmplCode As String
  Dim mEmplName As String
  Dim mTempCustCode As String
  Dim mCustType As String
  Dim mCustPriceType As String
  Dim mMembPrice As Double
  Dim mNoBuyLimit As Boolean
  Dim mCreditCode As String
  Dim mGridPay As DataGridView
  'Dim mExtraPoint As Integer
  'Dim mPlusPoint As Integer
  Dim mBuyPoint As Integer
  Dim mPointDisc As Double
  Dim mBirthPointPlus As Integer
  Dim mThisPoint As Integer
  Dim mUsePoint As Integer
  Dim mCustPoint As Integer
  Dim mRemainPoint As Integer
  Dim mVIP As Boolean
  'Dim mTotalProDisc As Single
  Dim mTotalThisMonthBuy As Double
  Dim mAllowOverBuyLimit As Boolean
  Dim mProcessSuccess As Boolean

  Dim mCommandText As String

  Dim mSalePriceType As String ' ประเภทราคาขาย R=ปลีก W=ส่ง O=ออนไลน์
  Dim mRetailPriceField As String = "price" & pBranchPrice
  Dim mWholePriceField As String = "price" & pWholePriceLevel
  ' ตัวแปรสิทธิ์แลกซื้อ
  Dim mBxCode As String
  Dim mBxAmou As Integer
  Dim mExExpireDate As Date
  ' ตัวแปรสมัครสมาชิกฟรี
  Dim mProFreeMemberBuyPrice As Double
  Dim mProFreeMember As String

  Private Sub frmDiarySale_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon
    Call ClearAll()
    mEmplCode = pUserCode
    lblEmplName.Text = pUserName
    txtGoodAmou.Text = mSaleAmou.ToString

    PrepCreditInfo()
    PrepEmplInfo()

    ' แสดงช่องขายส่งเฉพาะสาขาที่เปิดระบบขายส่ง
    If pAllowWholePrice = "1" Then
      dtgPrice.Columns("pWholePrice").Visible = True
      'dtgPrice.Columns("pWholeUnitPrice").Visible = True
    Else
      dtgPrice.Columns("pWholePrice").Visible = False
      'dtgPrice.Columns("pWholeUnitPrice").Visible = False
    End If
    ' แสดงปุ่มใช้สิทธิ์แลกซื้อและคอลัมน์รหัสสิทธิ์แลกซื้อ เฉพาะสาขาที่เปิดระบบสิทธิ์แลกซื้อ
    If pAllowBuyExchange = "1" Then
      'tbnUseBuyExchange.Visible = True
      dtgSale.Columns("bxCode").Visible = True
    Else
      'tbnUseBuyExchange.Visible = False
      dtgSale.Columns("bxCode").Visible = False
    End If

    ' ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑
    ' ซ่อนแสดงคอลันน์สมาชิก
    If pAllowOnlyMembPrice = "1" Then
      dtgPrice.Columns("pGenPrice").Visible = True
      dtgPrice.Columns("pGenUnitPrice").Visible = True
      dtgPrice.Columns("pMembPrice").HeaderText = "สมาชิก"
      'dtgPrice.Columns("pMembUnitPrice").Visible = True
    Else
      dtgPrice.Columns("pGenPrice").Visible = False
      dtgPrice.Columns("pGenUnitPrice").Visible = False
      dtgPrice.Columns("pMembPrice").HeaderText = "ปลีก"
      'dtgPrice.Columns("pMembUnitPrice").Visible = True
    End If
    ' ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑

    '' ซ่อนช่องแสดงรูปภาพสินค้า กรณีหน้าจอมีขนาด 4:3 เนื่องจากหน้าจอเล็ก ไม่พอแสดง
    'If pScreenRatio = "4:3" Then
    '  sctGoodPicture.Panel1Collapsed = True
    'End If

    '' ตรวจสอบว่ามีข้อมูลขาย off line ที่ยังไม่ได้ upload หรือไม่
    'Dim mGet() As String
    'If My.Computer.FileSystem.FileExists("c:\drugpos\data.mdb") = True Then
    '  mGet = GetData("SELECT count(*) FROM HistSale WHERE flag = '1'")
    '  If mGet(0) = "1" AndAlso CInt(mGet(1)) > 0 Then
    '    MessageBox.Show("มีข้อมูลการขาย Off Line ที่ยังไม่ได้ Upload ไปยัง Server กรุณาทำการ Upload ไปยัง Server ก่อนทำการขายหน้าร้าน", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '  End If
    'End If

    CheckPriv()

    ' เตรียมข้่อมูลโปรทั่วไป
    Me.Cursor = Cursors.WaitCursor
    mProFreeMember = "0"
    mProFreeMemberBuyPrice = 0
    Dim ds As New DataSet
    Dim dv As DataView
    dtgProTemp.Rows.Clear()
    pServerDateTime = pService.ServerDateTime
    mProFreeMember = "0"
    mProFreeMemberBuyPrice = 0

    ds = pService.SelectData("Drug", "select * from SalePro Where proStat <> '0' and ((branchCode = '" & pBranchCode & "' and branchPrice = '0') or (branchCode = '0' and branchPrice = '0') or (branchCode = '0' and branchPrice = '" & pBranchPrice & "')) and startDate <= '" & MDYStr(pServerDateTime.Date) & "' And endDate >= '" & MDYStr(pServerDateTime.Date) & "' order by buyPrice desc")
    If IsNothing(ds) = False Then
      dv = New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dtgProTemp.Rows.Add()
          dtgProTemp.Item("tRowCheck", i).Value = False
          dtgProTemp.Item("tProText", i).Value = .Item("proDesc").ToString
          dtgProTemp.Item("tProPeriod", i).Value = Format(.Item("startDate"), "d/M/yyyy") & "-" & Format(.Item("endDate"), "d/M/yyyy")
          dtgProTemp.Item("tExtraPoint", i).Value = .Item("extraPoint")
          dtgProTemp.Item("tPlusPoint", i).Value = .Item("plusPoint")
          dtgProTemp.Item("tProNo", i).Value = .Item("proNo")
          dtgProTemp.Item("tBuyPrice", i).Value = .Item("buyPrice")
          dtgProTemp.Item("tCustTypeCode", i).Value = .Item("custTypeCode")
          dtgProTemp.Item("tStartDate", i).Value = .Item("startDate")
          dtgProTemp.Item("tEndDate", i).Value = .Item("endDate")
          dtgProTemp.Item("tFreeMember", i).Value = .Item("freeMember")
          ' โปรสมัครสมาชิกฟรี
          If .Item("freeMember") = "1" Then
            mProFreeMember = "1"
            mProFreeMemberBuyPrice = .Item("buyPrice")
          End If
        End With
      Next
      dv = Nothing
    End If
    ds = Nothing

    '' เตรียมข้อมูลส่วนลด
    'dtgDiscTemp.Rows.Clear()
    'ds = pService.SelectData("Drug", "Select * from CustTypeDisc where discStat = '1' and startDate <= '" & MDYStr(pServerDateTime) & "' and endDate >= '" & MDYStr(pServerDateTime) & "' order by startDate desc, endDate desc")
    'If IsNothing(ds) = False Then
    '  dv = New DataView(ds.Tables(0))
    '  For i As Integer = 0 To dv.Count - 1
    '    With dv.Item(i)
    '      dtgDiscTemp.Rows.Add()
    '      dtgDiscTemp.Item("tCustType", i).Value = .Item("custTypeCode")
    '      dtgDiscTemp.Item("tCateCode", i).Value = .Item("cateCode")
    '      dtgDiscTemp.Item("tTypeCode", i).Value = .Item("typeCode")
    '      dtgDiscTemp.Item("tGroupCode", i).Value = .Item("groupCode")
    '      dtgDiscTemp.Item("tCustDisc", i).Value = .Item("custDisc")
    '    End With
    '  Next
    '  dv = Nothing
    'End If
    'ds = Nothing

    Me.Cursor = Cursors.Default
  End Sub

  'Private Sub txtCustCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCustCode.KeyPress
  '  If e.KeyChar = ChrW(Keys.Enter) Then
  '    e.Handled = True
  '    txtBarcode.Focus()
  '  End If
  'End Sub

  Private Sub txtBarcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.GotFocus
    txtBarcode.SelectionStart = 0
    txtBarcode.SelectionLength = txtBarcode.Text.Length
  End Sub

  Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub txtBarcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.LostFocus
    If txtBarcode.Text <> "" Then
      ShowGood(txtBarcode.Text, CInt(Val(txtGoodAmou.Text)), 0, "")
    End If
  End Sub

  Private Sub ShowGood(ByVal Barcode As String, ByVal SaleAmou As Integer, ByVal BxDisc As Double, ByVal BxCode As String)
    ' Check Priv -> Add
    If InStr(pUserPriv, Me.Tag.ToString & "A") <= 0 Then
      Exit Sub
    End If

    If SaleAmou <= 0 Then
      SaleAmou = 1
    End If

    Dim mSqlText As String
    Dim mUnitCostField As String = "unitCost" & pBranchCode
    Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
    Dim mMiniStockField As String = "miniStock" & pBranchCode
    Dim dsGoodPrice As New DataSet
    Dim mGoodCode As String
    Dim mUnitCode As String
    Dim mCateCode As String
    Dim mTypeCode As String
    Dim mGroupCode As String
    Dim mNoBranchStock As String
    Dim mAllowUnderCost As String
    Dim mHavePro As Boolean

    Dim mStickerPrice As Double
    Dim mFixPrice As String

    Me.Cursor = Cursors.WaitCursor

    Dim mGet() As String

    mGet = pService.GetData("Drug", "Select top 1 goodCode, unitCode from GoodBarcode where barCode = '" & Barcode & "'")
    If mGet(0) = "1" Then
      mGoodCode = mGet(1)
      mUnitCode = mGet(2)
    Else
      MessageBox.Show("ไม่พบข้อมูลสินค้า", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
      txtBarcode.Text = ""
      txtBarcode.Select()
      Me.Cursor = Cursors.Default
      Exit Sub
    End If

    ' รวมรายการเดียวกัน
    ' ####### ตรวจสอบว่ามีรายการในตารางแล้วหรือไม่ ถ้ามีให้นำจำนวนขายมารวมกัน และลบรายการเดิมออก เพื่อให้มีแค่รายการเดียว (เฉพาะรายการที่มีหน่วยเหมือนกัน)
    For Each mRow As DataGridViewRow In dtgSale.Rows
      If dtgSale.Item("goodCode", mRow.Index).Value.ToString = mGoodCode AndAlso dtgSale.Item("unitCode", mRow.Index).Value.ToString = mUnitCode Then
        SaleAmou = SaleAmou + CInt(dtgSale.Item("saleAmou", mRow.Index).Value)
        dtgSale.Rows.RemoveAt(mRow.Index)
        Exit For
      End If
    Next
    ' #######

    mSqlText = "SELECT GB.*, GI.goodName, GI." & mUnitCostField & " as unitCost, GI." & mStockOnhandField & " as stockOnhand, GI." & mMiniStockField & " as miniStock, UI.unitDesc, UI.unitFactor, GP.membDisc, GP.emplDisc, GP.wholeDisc, GI.drugCode, GI.cateCode, GI.typeCode, GI.groupCode, GI.noBranchStock, GI.allowUnderCost, GI.stickerPrice, GI.fixPrice FROM GoodBarcode GB INNER JOIN GoodInfo GI ON GB.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON GB.unitCode = UI.unitCode INNER JOIN GroupInfo GP ON GI.groupCode = GP.groupCode WHERE GB.barCode = '" & Barcode & "' AND GI.goodStat = '1'"
    ' $$$$$$$$$$$$$$
    ' เช็คว่ามีโปรหรือไม่ ถ้ามีโปร จะไม่นำ pack value มาคิด (ใช้ราคา 1 หน่วย ราคาเดียว) เพื่อป้องกันการลดซ้ำซ้อน
    mHavePro = CheckHavePro(mGoodCode, SaleAmou, mCustType, mCustPriceType)
    If mHavePro = True Then
      mSqlText = mSqlText & " and GB.goodAmou = 1"
    End If
    ' $$$$$$$$$$$$$$

    mSqlText = mSqlText & " ORDER BY GB.goodAmou DESC"

    dsGoodPrice = pService.SelectData("Drug", mSqlText)

    If IsNothing(dsGoodPrice) = False Then
      Dim dvGoodPrice As New DataView(dsGoodPrice.Tables(0))

      If dvGoodPrice.Count > 0 Then
        mStickerPrice = dvGoodPrice.Item(0).Item("stickerPrice").ToString
        mFixPrice = dvGoodPrice.Item(0).Item("fixPrice")

        ' แสดงราคาขาย
        Dim mUnitFactor As Integer
        Dim mGoodAmou As Integer
        Dim mMembPrice As Double
        Dim mGenPrice As Double
        Dim mWholePrice As Double

        Dim mPrice As Double
        Dim mAmou As Integer

        dtgPrice.Rows.Clear()
        For i As Integer = 0 To dvGoodPrice.Count - 1
          With dvGoodPrice.Item(i)
            dtgPrice.Rows.Add()
            dtgPrice.Item("pGoodAmou", i).Value = .Item("goodAmou")
            dtgPrice.Item("pUnitDesc", i).Value = .Item("goodAmou").ToString & " " & .Item("unitDesc")

            mUnitFactor = .Item("unitFactor")
            mGoodAmou = .Item("goodAmou") * mUnitFactor
            mMembPrice = .Item(mRetailPriceField)
            mWholePrice = .Item(mWholePriceField)

            dtgPrice.Item("pMembPrice", i).Value = mMembPrice
            dtgPrice.Item("pMembUnitPrice", i).Value = mMembPrice / mGoodAmou
            dtgPrice.Item("pWholePrice", i).Value = mWholePrice
            dtgPrice.Item("pWholeUnitPrice", i).Value = mWholePrice / mGoodAmou

            ' ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑
            ' คอลัมน์แสดงระดับราคา ลูกค้าทั่วไป ปรับราคาเพิ่มเป็นสเต๊ปเช่น 5->3, 3->2
            If pAllowOnlyMembPrice = "1" Then
              Select Case mRetailPriceField
                Case "price1" ' ปรับเพิ่มอีก pPerPrice1ToPrice0% (เฉพาะรายการที่ไม่ fixprice)
                  If mFixPrice = "1" Then
                    mGenPrice = .Item("price1")
                  Else
                    mPrice = .Item("price1")
                    mAmou = .Item("goodAmou") ' * munitfactor
                    mPrice = mPrice / mAmou
                    mPrice = Math.Ceiling(mPrice + (mPrice * (pPerPrice1ToPrice0 / 100)))
                    ' ราคาที่ปรับขึ้นแล้ว ต้องไม่เกินราคาป้าย
                    If mStickerPrice > 0 AndAlso mPrice > mStickerPrice Then
                      mPrice = mStickerPrice
                    End If
                    '' ราคาที่ปรับขึ้นแล้ว ต้องไม่เกินราคาป้าย
                    'If mStickerPrice > 0 AndAlso mPrice / (mAmou * mUnitFactor) > mStickerPrice Then
                    '  mPrice = mStickerPrice * mAmou * mUnitFactor
                    'End If
                    mGenPrice = mPrice * mAmou
                  End If
                Case "price2"
                  mGenPrice = .Item("price1")
                Case "price3"
                  mGenPrice = .Item("price2")
                Case "price4"
                  mGenPrice = .Item("price3")
                Case "price5" ' เฉพาะระดับ 5 ให้ใช้ระดับ 3
                  mGenPrice = .Item("price3")
                Case "price6"
                  mGenPrice = .Item("price5")
              End Select
            End If
            dtgPrice.Item("pGenPrice", i).Value = mGenPrice
            dtgPrice.Item("pGenUnitPrice", i).Value = mGenPrice / mGoodAmou
            ' ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑


            'If .Item("goodAmou") > 0 Then
            '  dtgPrice.Item("pRetailUnitPrice", i).Value = .Item(mRetailPriceField) / .Item("goodAmou")
            '  dtgPrice.Item("pWholeUnitPrice", i).Value = .Item(mWholePriceField) / .Item("goodAmou")
            'Else
            '  dtgPrice.Item("pRetailUnitPrice", i).Value = 0
            '  dtgPrice.Item("pWholeUnitPrice", i).Value = 0
            'End If

            'dtgPrice.Rows.Add(.Item("goodAmou"), .Item("unitDesc"), .Item(mRetailPriceField), .Item(mWholePriceField))
          End With
        Next
        dtgPrice.Sort(dtgPrice.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        dtgPrice.ClearSelection()

        mGoodCode = dvGoodPrice.Item(0).Item("goodCode").ToString
        mUnitCode = dvGoodPrice.Item(0).Item("unitCode").ToString
        mCateCode = dvGoodPrice.Item(0).Item("cateCode").ToString
        mTypeCode = dvGoodPrice.Item(0).Item("typeCode").ToString
        mGroupCode = dvGoodPrice.Item(0).Item("groupCode").ToString
        mNoBranchStock = dvGoodPrice.Item(0).Item("noBranchStock").ToString
        mAllowUnderCost = dvGoodPrice.Item(0).Item("allowUnderCost").ToString

        ' ตรวจสอบการแพ้ยา ไม่รวมลูกค้าทั่วไป
        If txtCustCode.Text <> "0" AndAlso txtCustCode.Text <> "" Then
          Dim getValue() As String
          getValue = pService.GetData("Drug", "SELECT DG.drugDesc FROM DrugAllergic DA INNER JOIN DrugGroup DG ON DA.drugCode = DG.drugCode WHERE DA.custCode = '" & txtCustCode.Text & "' AND DA.drugCode = '" & dvGoodPrice.Item(0).Item("drugCode").ToString & "'")
          If getValue(0) = "1" Then
            pMessageBox = New MyMessageBox("ลูกค้ามีประวัติแพ้ยากลุ่ม : " & getValue(1) & vbCrLf & "กรุณายืนยันการจ่ายยา : " & dvGoodPrice.Item(0).Item("goodName").ToString, "คำเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If pMessageBox.ShowDialog() = Windows.Forms.DialogResult.No Then
              dsGoodPrice = Nothing
              dvGoodPrice = Nothing
              txtBarcode.Text = ""
              txtBarcode.Focus()
              Me.Cursor = Cursors.Default
              Exit Sub
            End If
          End If
        End If

        Dim mStockOnhand As Integer
        Dim mStockAfterSale As Integer
        Dim mMiniStock As Integer
        'Dim mUnitFactor As Integer
        Dim mSubTotal As Double
        Dim mSubDisc As Double = 0
        'Dim mGet() As String
        Dim mHugPoint As Integer = 0
        Dim mExtraPoint As Integer

        Dim mGoodProNumb As String
        Dim mPromotion As String
        Dim mCompCode As String
        Dim mProBuyAmou As Double
        Dim mProPoint As Integer
        Dim mProFlag As String
        Dim mProDiscAmou As Double
        Dim mProPercentDisc As Double
        Dim mSubProDisc As Double
        Dim mGoodDisc As Double
        Dim mCompDisc As Double
        Dim mCompProDisc As Double = 0 ' ส่วนลดบริษัท
        Dim mProPlus As Integer ' ตัวเลขเป็นจำนวนเท่าของแต้มหรือส่วนลดที่ได้ เช่นกำหนดว่าซื้อ 1 ชิ้นได้แต้ม 5 ถ้าซื้อ 3 ชิ้น ก็ต้องได้ 3 เท่าคือ 15 แต้ม

        Dim mGoodCode2 As String = ""
        'Dim mPrice5 As Double
        Dim mEmplPrice As Double
        Dim mUnitCost As Double

        '' รวมรายการเดียวกัน
        '' ####### ตรวจสอบว่ามีรายการในตารางแล้วหรือไม่ ถ้ามีให้นำจำนวนขายมารวมกัน และลบรายการเดิมออก เพื่อให้มีแค่รายการเดียว (เฉพาะรายการที่มีหน่วยเหมือนกัน)
        'For Each mRow As DataGridViewRow In dtgSale.Rows
        '  If dtgSale.Item("goodCode", mRow.Index).Value.ToString = mGoodCode AndAlso dtgSale.Item("unitCode", mRow.Index).Value.ToString = mUnitCode Then
        '    SaleAmou = SaleAmou + CInt(dtgSale.Item("saleAmou", mRow.Index).Value)
        '    dtgSale.Rows.RemoveAt(mRow.Index)
        '    Exit For
        '  End If
        'Next
        '' #######

        For i As Integer = 0 To dvGoodPrice.Count - 1
          With dvGoodPrice.Item(i)
            mGoodAmou = .Item("goodAmou")
            mUnitFactor = .Item("unitFactor")
            'mGoodAmou = mGoodAmou * mUnitFactor
            'mGoodCode = .Item("goodCode").ToString

            'หากจำนวนขายมากกว่าหรือเท่ากับจำนวนที่ตั้งราคาขาย ให้ใช้ราคานี้
            If SaleAmou >= .Item("goodAmou") Then
              mStockOnhand = .Item("stockOnhand")
              mUnitFactor = .Item("unitFactor")
              mMiniStock = .Item("miniStock")
              ' ###############
              ' ระงับการขาย  ถ้าจำนวนขายมากกว่าสต๊อค
              ' หักสต๊อคคงเหลือ จากรายการที่ขายก่อนหน้า (ถ้ามี)
              ' ยกเว้นสินค้าที่ ไม่เก็บสต๊อคสาขา
              If mNoBranchStock = "0" Then
                For Each mRow As DataGridViewRow In dtgSale.Rows
                  If dtgSale.Item("goodCode", mRow.Index).Value = .Item("goodCode") Then
                    mStockOnhand = mStockOnhand - (dtgSale.Item("saleAmou", mRow.Index).Value * dtgSale.Item("unitFactor", mRow.Index).Value)
                  End If
                Next

                If SaleAmou * mUnitFactor > mStockOnhand Then
                  'MessageBox.Show("สินค้าไม่เพียงพอต่อการจำหน่าย", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                  pMessageBox = New MyMessageBox("สินค้าไม่เพียงพอต่อการจำหน่าย", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                  pMessageBox.ShowDialog()

                  ClearGoodField()
                  If Not (picGood.Image Is Nothing) Then
                    picGood.Image.Dispose()
                    picGood.Image = Nothing
                  End If
                  lblGoodName.Text = ""
                  lblGoodPrice.Text = ""
                  lblPromotion.Text = ""
                  dtgPrice.Rows.Clear()
                  txtBarcode.Focus()
                  Me.Cursor = Cursors.Default
                  Exit Sub
                End If
              End If
              ' ###############

              ' ลูกค้าพนักงาน ให้คิดราคาขายแบบใหม่ 13/1/2564
              If mCustType = "2" Then ' And pAllowEmplPro <> "1" Then ' ยกเว้นสาขาที่อนุญาตให้พนักงานใช้โปรโมชั่นสินค้าได้ ให้ใช้ราคาขายตามปกติ 20/9/2564
                ' ราคสวัสดิการ ให้ใช้ราคา 6 เริ่ม กพ.65
                mEmplPrice = .Item("price6") / .Item("goodAmou")
                mUnitCost = .Item("unitCost") * .Item("unitFactor")

                ' ถ้าราคาขายน้อยกว่าทุน ให้ขายเท่าราคาทุน
                If mEmplPrice < mUnitCost Then
                  mUnitPrice = Math.Ceiling(mUnitCost)
                Else
                  mUnitPrice = Math.Ceiling(mEmplPrice)
                End If

                '' ราคาทุนน้อยกว่า 0 ไม่คิดส่วนลด
                'If mUnitCost < 0 Then
                '  mUnitPrice = Math.Ceiling(mPrice5)
                'Else
                '  ' ถ้าราคาขายน้อยกว่าทุน ให้ขายเท่าราคาทุน
                '  If mPrice5 < mUnitCost Then
                '    mUnitPrice = Math.Ceiling(mUnitCost)
                '  Else
                '    ' ส่วนลด 10% ของกำไร โดยคำนวณราคาขาย จากราคา 5 นำมาหากำไร (GP)จากต้นทุน แล้วลดกำไร 10%
                '    mUnitPrice = Math.Ceiling(mUnitCost + ((mPrice5 - mUnitCost) - (mPrice5 - mUnitCost) * 0.1))
                '  End If
                'End If
              Else
                ' ลูกค้าส่ง เฉพาะสาขาที่อนุญาตให้ขายส่งได้
                If mCustPriceType = "W" AndAlso pAllowWholePrice = "1" Then
                  Select Case pWholePriceLevel
                    Case "A"
                      mUnitPrice = Math.Round(.Item("priceA") / .Item("goodAmou"), 2)
                    Case "B"
                      mUnitPrice = Math.Round(.Item("priceB") / .Item("goodAmou"), 2)
                    Case "C"
                      mUnitPrice = Math.Round(.Item("priceC") / .Item("goodAmou"), 2)
                  End Select
                  mSalePriceType = "W"
                Else
                  ' ลูกค้าออนไลน์ เฉพาะสาขาที่อนุญาตให้ขายออนไลน์ ได้
                  If mCustPriceType = "O" AndAlso pAllowOnlinePrice = "1" Then
                    Select Case pOnlinePriceLevel
                      Case "1"
                        mUnitPrice = Math.Round(.Item("priceO1") / .Item("goodAmou"), 2)
                      Case "2"
                        mUnitPrice = Math.Round(.Item("priceO2") / .Item("goodAmou"), 2)
                      Case "3"
                        mUnitPrice = Math.Round(.Item("priceO3") / .Item("goodAmou"), 2)
                      Case "4"
                        mUnitPrice = Math.Round(.Item("priceO4") / .Item("goodAmou"), 2)
                      Case "5"
                        mUnitPrice = Math.Round(.Item("priceO5") / .Item("goodAmou"), 2)
                    End Select
                    mSalePriceType = "O"
                  Else
                    ' ลูกค้าปลีก
                    ' ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑
                    ' ลูกค้าสมาชิก HUG Club ให้ใช้ระดับราคาของสาขาตามปกติ
                    ' ลูกค้าทั่วไป และลูกค้าอื่นๆ ให้ใช้ระดับราคาที่สูงกว่าระดับราคาสาขาปกติ 1 สเต๊ป เช่น price3->price2, price2->price1
                    ' เริ่มใช้ มีค 2566
                    ' ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑
                    ' สมาชิก HUG Club
                    If mCustType = "6" Or pAllowOnlyMembPrice = "0" Then
                      Select Case pBranchPrice
                        Case "1"
                          mUnitPrice = Math.Round(.Item("price1") / .Item("goodAmou"), 2)
                        Case "2"
                          mUnitPrice = Math.Round(.Item("price2") / .Item("goodAmou"), 2)
                        Case "3"
                          mUnitPrice = Math.Round(.Item("price3") / .Item("goodAmou"), 2)
                        Case "4"
                          mUnitPrice = Math.Round(.Item("price4") / .Item("goodAmou"), 2)
                        Case "5"
                          mUnitPrice = Math.Round(.Item("price5") / .Item("goodAmou"), 2)
                        Case "6"
                          mUnitPrice = Math.Round(.Item("price6") / .Item("goodAmou"), 2)
                      End Select
                    Else ' ลูกค้าประเภทอื่น
                      Select Case pBranchPrice
                        Case "1" ' 1->0 เนื่องจากไม่มีราคาระดับ 0 ให้ใข้ราคาระดับ 1 เพิ่มราคาอีก 3% แต่ต้องไม่เกินราคาป้าย (เฉพาะรายการที่ไม่ fixprice)
                          If mFixPrice = "1" Then
                            mUnitPrice = Math.Round(.Item("price1") / .Item("goodAmou"), 2)
                          Else
                            mUnitPrice = .Item("price1") / .Item("goodAmou")
                            mUnitPrice = Math.Ceiling(mUnitPrice + (mUnitPrice * (pPerPrice1ToPrice0 / 100)))
                            ' ราคาที่ปรับขึ้นแล้ว ต้องไม่เกินราคาป้าย
                            If mStickerPrice > 0 AndAlso mUnitPrice > mStickerPrice Then
                              mUnitPrice = mStickerPrice
                            End If
                          End If
                        Case "2" ' 2->3
                          mUnitPrice = Math.Round(.Item("price1") / .Item("goodAmou"), 2)
                        Case "3" ' 3->2
                          mUnitPrice = Math.Round(.Item("price2") / .Item("goodAmou"), 2)
                        Case "4" ' 4->3
                          mUnitPrice = Math.Round(.Item("price3") / .Item("goodAmou"), 2)
                        Case "5" ' 5->3 เฉพาะราคาระดับ 5 ให้ใช้ราคาระดับ 3
                          mUnitPrice = Math.Round(.Item("price3") / .Item("goodAmou"), 2)
                        Case "6" ' 6->5
                          mUnitPrice = Math.Round(.Item("price5") / .Item("goodAmou"), 2)
                      End Select
                    End If
                    mSalePriceType = "R"
                  End If
                End If
              End If

              ' ถ้าขายปลีกหรือออนไลน์ ให้ปัดเศษสตางค์ทิ้ง
              If mSalePriceType = "R" Or mSalePriceType = "O" Then
                mSubTotal = CLng(SaleAmou * mUnitPrice)
              Else
                ' ขายส่ง ไม่ปัดเศษ
                mSubTotal = SaleAmou * mUnitPrice
              End If

              '' คำนวณส่วนลด เฉพาะสาขาที่อนุญาตให้คิดส่วนลด
              'If pAllowDisc = "1" Then
              '  ' ส่วนลดแบบเดิม
              '  ' ให้ส่วนลดสำหรับ
              '  Select Case mCustType
              '    ' ยกเลิกการให้ส่วนลดพนักงานแบบเดิม เปลี่ยนเป็นคำนวณส่วนลดจากราคาขายแบบใหม่ 13/1/2564
              '    'Case "2" ' พนักงาน
              '    '  ' เทียบ % ส่วนลดของพนักงาน กับ %GP ของสินค้า ให้ลดได้ไม่เกิน %GP ของสินค้า
              '    '  mGoodGP = (mUnitPrice - .Item("unitCost")) * 100 / mUnitPrice
              '    '  If CSng(.Item("emplDisc")) > mGoodGP Then
              '    '    mSubDisc = Fix(mSubTotal * mGoodGP / 100)
              '    '  Else
              '    '    mSubDisc = Fix(mSubTotal * CSng(.Item("emplDisc")) / 100)
              '    '  End If
              '    '  'mSubDisc = Fix(mSubTotal * CSng(.Item("emplDisc")) / 100)
              '    '  mSubTotal = mSubTotal - mSubDisc
              '    '  'dtgSale.Columns("SubDisc").Visible = True
              '    Case "3" ' สมาชิก
              '      mSubDisc = Fix(mSubTotal * CSng(.Item("membDisc")) / 100)
              '      mSubTotal = mSubTotal - mSubDisc
              '      'dtgSale.Columns("SubDisc").Visible = True
              '    Case "4" ' ลูกค้าส่ง
              '      mSubDisc = Fix(mSubTotal * CSng(.Item("wholeDisc")) / 100)
              '      mSubTotal = mSubTotal - mSubDisc
              '      'dtgSale.Columns("SubDisc").Visible = True
              '    Case Else
              '      'dtgSale.Columns("SubDisc").Visible = False
              '  End Select
              'End If
              '########################################

              'mStockOnhand = CInt(.Item("stockOnhand"))
              ' หากมีรายการซ้ำก่อนหน้าให้หักสต๊อคคงเหลือออก เพื่อให้แสดงสต๊อคคงเหลือถูกต้อง
              'For Each mRow As DataGridViewRow In dtgSale.Rows
              '  If dtgSale.Item("goodCode", mRow.Index).Value = .Item("goodCode") Then
              '    mStockOnhand = mStockOnhand - (dtgSale.Item("saleAmou", mRow.Index).Value * dtgSale.Item("unitFactor", mRow.Index).Value)
              '  End If
              'Next


              ' #####################
              ' เช็คโปร.เพิ่มแต้ม
              mPromotion = ""
              mHugPoint = 0
              mProPoint = 0
              mCompCode = ""
              mProBuyAmou = 0
              mProFlag = ""
              mProDiscAmou = 0
              mProPercentDisc = 0
              mSubProDisc = 0
              mProPlus = 1
              mGoodProNumb = ""

              lblPromotion.Text = ""
              ' โปรโมชั่น (รวมลูกค้าทุกประเภท)
              If mCustType <> "0" Then ' Or (mCustType = "2" And pAllowEmplPro = "1") Then
                ' ใช้วันที่และเวลาของ server
                pServerDateTime = pService.ServerDateTime

                '' %%%%%%%%%%%%%%% คำนวณส่วนลดจากโปรโมชั่น แบบ recursive
                'mProDiscAmou = CalProDisc(.Item("goodCode"), SaleAmou)
                '' %%%%%%%%%%%%%%%

                ' โปร.สินค้าแต่ละตัว ขึ้นอยู่กับโปร.ว่าสำหรับขายปลีก ส่ง หรือออนไลน์ priceType
                mSqlText = "Select proName, goodProNumb, extraPoint, goodAmou, goodCode2, discAmou, startDate, endDate, allowEmpl, fixPrice From GoodPro Where proStat = '1' and priceType = '" & mCustPriceType & "' and goodCode = '" & .Item("goodCode").ToString & "' And startDate <= '" & MDYStr(pServerDateTime.Date) & "' And endDate >= '" & MDYStr(pServerDateTime.Date) & "' And compCode = '' and ((branchCode = '0' and custTypeCode = '0' and branchPrice = '0') or (branchCode = '0' and custTypeCode = '" & mCustType & "' and branchPrice = '0') or (branchCode = '0' and custTypeCode = '0' and branchPrice = '" & pBranchPrice & "') or (branchCode = '" & pBranchCode & "' and custTypeCode = '0' and branchPrice = '0') or (branchCode = '" & pBranchCode & "' and custTypeCode = '" & mCustType & "' and branchPrice = '" & pBranchPrice & "') or (branchCode = '" & pBranchCode & "' and custTypeCode = '" & mCustType & "' and branchPrice = '0') or (branchCode = '" & pBranchCode & "' and custTypeCode = '0' and branchPrice = '" & pBranchPrice & "') or (branchCode = '0' and custTypeCode = '" & mCustType & "' and branchPrice = '" & pBranchPrice & "'))"

                ' ลูกค้าประเภทพนักงาน ให้คิวรี่เฉพาะรายการที่ รวมขายสวัสดิการ ด้วย
                If mCustType = "2" Then
                  mSqlText = mSqlText & " and allowEmpl = '1'"
                End If

                mSqlText = mSqlText & " order by goodAmou desc"

                ' ***********************
                Dim mFlag As Boolean
                Dim ds As New DataSet
                ds = pService.SelectData("Drug", mSqlText)
                If IsNothing(ds) = False Then
                  Dim dv As New DataView(ds.Tables(0))
                  If dv.Count > 0 Then
                    ' @@@@@@@@@@@@@@@@@@@@
                    ' ลูกค้าประเภทพนักงาน ที่จะใช้โปรที่มี ให้กลับไปใช้ราคาขายตามระดับราคาของสาขานั้น
                    If mCustType = "2" Then
                      Select Case pBranchPrice
                        Case "1"
                          mUnitPrice = Math.Round(.Item("price1") / .Item("goodAmou"), 2)
                        Case "2"
                          mUnitPrice = Math.Round(.Item("price2") / .Item("goodAmou"), 2)
                        Case "3"
                          mUnitPrice = Math.Round(.Item("price3") / .Item("goodAmou"), 2)
                        Case "4"
                          mUnitPrice = Math.Round(.Item("price4") / .Item("goodAmou"), 2)
                        Case "5"
                          mUnitPrice = Math.Round(.Item("price5") / .Item("goodAmou"), 2)
                        Case "6"
                          mUnitPrice = Math.Round(.Item("price6") / .Item("goodAmou"), 2)
                      End Select
                      ' ถ้าขายปลีกหรือออนไลน์ ให้ปัดเศษสตางค์ทิ้ง
                      If mSalePriceType = "R" Or mSalePriceType = "O" Then
                        mSubTotal = CLng(SaleAmou * mUnitPrice)
                      Else
                        ' ขายส่ง ไม่ปัดเศษ
                        mSubTotal = SaleAmou * mUnitPrice
                      End If
                    End If
                    ' @@@@@@@@@@@@@@@@@@@@
                    ' %%%%%%%%%%%%%%% คำนวณส่วนลดจากโปรโมชั่น แบบ recursive
                    mProDiscAmou = CalPromotionDisc(.Item("goodCode"), SaleAmou, mUnitPrice, dv)
                    ' %%%%%%%%%%%%%%%

                    '' ถ้าเป็นโปรที่มีการ fix ราคาขาย ให้คำนวณส่วนลด
                    'If .Item("unitPrice") > 0 Then
                    '  mProDiscAmou = mUnitPrice - .Item("unitPrice")
                    'Else
                    '  ' %%%%%%%%%%%%%%% คำนวณส่วนลดจากโปรโมชั่น แบบ recursive
                    '  mProDiscAmou = CalPromotionDisc(.Item("goodCode"), SaleAmou, dv)
                    '  ' %%%%%%%%%%%%%%%
                    'End If

                    mFlag = False
                    For m As Integer = 0 To dv.Count - 1
                      With dv.Item(m)
                        If lblPromotion.Text = "" Then
                          lblPromotion.Text = .Item("proName").ToString & "  (" & CDate(.Item("startDate")).ToString("d MMM yyyy") & "-" & CDate(.Item("endDate")).ToString("d MMM yyyy") & ")"
                        Else
                          lblPromotion.Text = lblPromotion.Text & vbCrLf & .Item("proName").ToString & "  (" & CDate(.Item("startDate")).ToString("d MMM yyyy") & "-" & CDate(.Item("endDate")).ToString("d MMM yyyy") & ")"

                        End If
                        ' คิดโปร เฉพาะรายการที่มีจำนวนซื้อ เป็นจำนวนเท่า ของจำนวนในโปร
                        If SaleAmou Mod CInt(.Item("goodAmou")) = 0 Then
                          If CInt(.Item("goodAmou")) > 0 Then
                            mProPlus = CInt(Fix(SaleAmou / CInt(.Item("goodAmou"))))
                          Else
                            mProPlus = 0
                          End If

                          mExtraPoint = CInt(.Item("extraPoint")) * mProPlus
                          'mProDiscAmou = CDbl(.Item("discAmou")) ใช้ค่าจากการคำนวณแบบ recursive
                          ' ตรวจสอบว่าเป็นรายการที่มีการจับคู่ให้แต้มหรือไม่ goodCode2 มีค่ารหัสสินค้าที่จับคู่
                          If .Item("goodCode2").ToString = "" Then ' ไม่มี
                            mHugPoint = mExtraPoint
                            mPromotion = "แต้มพิเศษสินค้าทั่วไป"
                            ' ถ้ามีส่วนลด
                            If mProDiscAmou > 0 Then
                              mGoodProNumb = .Item("goodProNumb")
                              mSubProDisc = mProDiscAmou '* mProPlus ไม่ต้องคูณ เพราะคำนวณแบบ recursive
                              mSubDisc = mSubDisc + mSubProDisc
                              mGoodDisc = mSubDisc
                              mSubTotal = mSubTotal - mSubProDisc
                              mPromotion = "ลดพิเศษสินค้าทั่วไป"
                              mProFlag = "2"
                            End If
                            Exit For
                          Else
                            For Each mRow As DataGridViewRow In dtgSale.Rows
                              If dtgSale.Item("goodCode", mRow.Index).Value.ToString = .Item("goodCode2").ToString AndAlso CInt(dtgSale.Item("saleAmou", mRow.Index).Value) = SaleAmou AndAlso dtgSale.Item("goodCode2", mRow.Index).Value.ToString = "" Then
                                mProFlag = "2"
                                ' มี ให้คิดแต้มพิเศษ
                                mHugPoint = mExtraPoint
                                mPromotion = "แต้มพิเศษสินค้าจับคู่"
                                ' ให้รายการที่เป็นคู่นั้น มีแต้มหรือส่วนลดด้วย
                                dtgSale.Item("hugPoint", mRow.Index).Value = mExtraPoint
                                ' ถ้ามีส่วนลด
                                If mProDiscAmou > 0 Then
                                  mGoodProNumb = .Item("goodProNumb")
                                  mSubProDisc = mProDiscAmou '* mProPlus ไม่ต้องคูณ เพราะคำนวณแบบ recursive
                                  mSubDisc = mSubDisc + mSubProDisc
                                  mGoodDisc = mSubDisc
                                  mSubTotal = mSubTotal - mSubProDisc
                                  mPromotion = "ลดพิเศษสินค้าจับคู่"
                                End If
                                ' คำนวณส่วนลดและ subtotal ใหม่ สำหรับรายการนี้
                                dtgSale.Item("goodDisc", mRow.Index).Value = mProDiscAmou
                                dtgSale.Item("subDisc", mRow.Index).Value = mProDiscAmou ' ไม่ต้องคูณ เพราะคำนวณแบบ recursive '* (CInt(Fix(dtgSale.Item("saleAmou", mRow.Index).Value / CInt(.Item("goodAmou")))))
                                dtgSale.Item("subTotal", mRow.Index).Value = CDbl(dtgSale.Item("saleAmou", mRow.Index).Value) * CDbl(dtgSale.Item("unitPrice", mRow.Index).Value) - CDbl(dtgSale.Item("subDisc", mRow.Index).Value)

                                mGoodCode2 = dtgSale.Item("goodCode", mRow.Index).Value.ToString
                                dtgSale.Item("goodCode2", mRow.Index).Value = mGoodCode '.Item("goodCode").ToString
                                dtgSale.Item("promotion", mRow.Index).Value = mPromotion
                                dtgSale.Item("proFlag", mRow.Index).Value = mProFlag
                                dtgSale.Item("subProDisc", mRow.Index).Value = dtgSale.Item("subDisc", mRow.Index).Value
                                dtgSale.Item("goodProNumb", mRow.Index).Value = mGoodProNumb
                                mFlag = True
                                Exit For
                              End If
                            Next
                          End If

                        End If
                      End With
                      If mFlag = True Then
                        Exit For
                      End If
                    Next
                  End If
                  dv = Nothing
                End If
                ds = Nothing
                ' ***********************

                ' &&&&&&&&&&&&&&&&&&&&&&
                ' โปร.สินค้าบริษัทเดียวกัน
                mProPlus = 1
                mSqlText = "Select extraPoint, buyAmou, compCode, discAmou, percentDisc, goodProNumb From GoodPro Where proStat = '1' and priceType = '" & mCustPriceType & "' and goodCode = '" & .Item("goodCode").ToString & "' And startDate <= '" & MDYStr(pServerDateTime.Date) & "' And endDate >= '" & MDYStr(pServerDateTime.Date) & "' And compCode <> '' and ((branchCode = '0' and custTypeCode = '0' and branchPrice = '0') or (branchCode = '0' and custTypeCode = '" & mCustType & "' and branchPrice = '0')or (branchCode = '0' and custTypeCode = '0' and branchPrice = '" & pBranchPrice & "') or (branchCode = '" & pBranchCode & "' and custTypeCode = '0' and branchPrice = '0') or (branchCode = '" & pBranchCode & "' and custTypeCode = '" & mCustType & "' and branchPrice = '" & pBranchPrice & "') or (branchCode = '" & pBranchCode & "' and custTypeCode = '" & mCustType & "' and branchPrice = '0') or (branchCode = '" & pBranchCode & "' and custTypeCode = '0' and branchPrice = '" & pBranchPrice & "') or (branchCode = '0' and custTypeCode = '" & mCustType & "' and branchPrice = '" & pBranchPrice & "')) order by discAmou desc"
                ds = pService.SelectData("Drug", mSqlText)
                If IsNothing(ds) = False Then
                  Dim dv As New DataView(ds.Tables(0))
                  If dv.Count > 0 Then
                    Dim mTotalBuyAmou As Double
                    Dim mPerCompDisc As Double
                    Dim mItemAmou As Integer
                    Dim mItemPrice As Double
                    Dim mItemDisc As Double
                    Dim mItemSubTotal As Double
                    Dim mItemGoodDisc As Double
                    Dim mItemCompDisc As Double

                    For x As Integer = 0 To dv.Count - 1
                      With dv.Item(x)
                        mProPoint = .Item("extraPoint")
                        mProBuyAmou = .Item("buyAmou")
                        mCompCode = .Item("compCode")
                        mProDiscAmou = .Item("discAmou")
                        mProPercentDisc = .Item("percentDisc")
                        mTotalBuyAmou = 0
                        For Each mRow As DataGridViewRow In dtgSale.Rows
                          If dtgSale.Item("compCode", mRow.Index).Value.ToString = mCompCode Then
                            mItemAmou = dtgSale.Item("saleAmou", mRow.Index).Value
                            mItemPrice = dtgSale.Item("unitPrice", mRow.Index).Value
                            mItemGoodDisc = dtgSale.Item("goodDisc", mRow.Index).Value
                            mTotalBuyAmou += (mItemAmou * mItemPrice) - mItemGoodDisc
                            'mTotalBuyAmou += CDbl(dtgSale.Item("subTotal", mRow.Index).Value)
                          End If
                        Next
                        ' บวกจำนวนเงินสำหรับรายการนี้
                        mTotalBuyAmou += mSubTotal
                        If mTotalBuyAmou > 0 AndAlso mTotalBuyAmou >= mProBuyAmou Then
                          mCompProDisc = mProDiscAmou ' ส่วนลดเฉพาะโปรบริษัท เก็บไว้ในตาราง เพื่อใช้ตรวจสอบ
                          ' ถ้าให้แต้มพิเศษ
                          If mProPoint > 0 Then
                            mProPlus = CInt(Fix(mTotalBuyAmou / mProBuyAmou))
                            mHugPoint = mProPoint * mProPlus
                            mPromotion = "แต้มพิเศษสินค้าบริษัท"
                            mProFlag = "1"
                            '  และ flag ทุกรายการไว้เพื่อให้รู้ว่านำไปคิดโปร.แล้ว (clear ช่องแต้มทั้งหมด เพราะจะนำแต้มที่ได้รวมไปใส่ไว้ในรายการสุดท้ายของโปร.นี้)
                            For Each mRow As DataGridViewRow In dtgSale.Rows
                              If dtgSale.Item("compCode", mRow.Index).Value.ToString = mCompCode Then
                                dtgSale.Item("hugPoint", mRow.Index).Value = 0
                                dtgSale.Item("proFlag", mRow.Index).Value = "1"
                                dtgSale.Item("promotion", mRow.Index).Value = mPromotion
                                'dtgSale.Rows(mRow.Index).DefaultCellStyle.ForeColor = Color.DarkGreen
                              End If
                            Next
                          End If
                          ' ถ้าให้ % ส่วนลด
                          If mProPercentDisc > 0 Then
                            mGoodProNumb = .Item("goodProNumb")
                            If mSubTotal > 0 Then
                              mSubProDisc = Fix(mSubTotal * mProPercentDisc / 100)
                            End If
                            mSubDisc = mSubDisc + mSubProDisc
                            mGoodDisc = mSubDisc
                            mSubTotal = mSubTotal - mSubProDisc
                            mPromotion = "ลด%สินค้าบริษัท"
                            mProFlag = "2"
                          End If
                          ' ถ้าให้ส่วนลดพิเศษ ให้นำไปเฉลี่ยลดแต่ละรายการของบริษัทนั้น
                          If mProDiscAmou > 0 Then
                            mGoodProNumb = .Item("goodProNumb")
                            mPromotion = "ลดพิเศษสินค้าบริษัท"
                            mProFlag = "2"
                            '############
                            ' คำนวณหา % ส่วนลด เพื่อนำไปเฉลี่ยลดแต่ละรายการ
                            mPerCompDisc = mProDiscAmou * 100 / mTotalBuyAmou
                            ' คำนวณส่วนลดโปร.บริษัท สำหรับสินค้าที่ทำรายการซื้อไว้ก่อนหน้า
                            For Each mRow As DataGridViewRow In dtgSale.Rows
                              If dtgSale.Item("compCode", mRow.Index).Value.ToString = mCompCode Then
                                mItemDisc = dtgSale.Item("subDisc", mRow.Index).Value
                                mItemSubTotal = dtgSale.Item("subTotal", mRow.Index).Value
                                mItemAmou = dtgSale.Item("saleAmou", mRow.Index).Value
                                mItemPrice = dtgSale.Item("unitPrice", mRow.Index).Value
                                mItemGoodDisc = dtgSale.Item("goodDisc", mRow.Index).Value
                                ' ส่วนลดซัพ ก่อนคำนวณใหม่
                                mItemCompDisc = dtgSale.Item("compDisc", mRow.Index).Value
                                ' ส่วนลดซัพ คำนวณใหม่ (คิด % จากราคาสินค้า - ส่วนลดสินค้า (หรือช่องเป็นเงิน + ส่วนลดซัพ)
                                mItemCompDisc = Math.Round((mItemSubTotal + mItemCompDisc) * mPerCompDisc / 100)
                                dtgSale.Item("compDisc", mRow.Index).Value = mItemCompDisc
                                dtgSale.Item("subDisc", mRow.Index).Value = mItemGoodDisc + mItemCompDisc
                                dtgSale.Item("subTotal", mRow.Index).Value = (mItemAmou * mItemPrice) - mItemGoodDisc - mItemCompDisc
                                dtgSale.Item("proFlag", mRow.Index).Value = mProFlag
                                dtgSale.Item("promotion", mRow.Index).Value = mPromotion
                                dtgSale.Item("goodProNumb", mRow.Index).Value = mGoodProNumb
                                dtgSale.Item("compProDisc", mRow.Index).Value = 0 ' ล้างเพื่อไม่ต้องนำไปคิดซ้ำ
                              End If
                            Next
                            ' ส่วนลดโปร.บริษัท สำหรับรายการที่จะเพิ่มใหม่
                            mCompDisc = Math.Round(mSubTotal * mPerCompDisc / 100)
                            '############
                            mSubProDisc = mProDiscAmou * mProPlus
                            mSubDisc = mSubDisc + mCompDisc
                            ' ยอดรวม หักส่วนลดปกติและส่วนลดโปร.บริษัท
                            mSubTotal = mSubTotal - mCompDisc
                          End If
                          mHavePro = True
                          Exit For
                        End If
                      End With
                    Next
                  End If
                  dv = Nothing
                End If
                ds = Nothing
                ' &&&&&&&&&&&&&&&&&&&&&&
              End If
              ' ####################
              ' ถ้ามีราคาขายต่ำกว่าต้นทุน ให้ฟ้องและไม่ให้ขาย ยกเว้น เป็นสินค้าที่เซ็ทให้ขายต่ำกว่าทุนได้ หรือเป็นสินค้าที่ตั้งราคาขายต่ำกว่า 0 เช่นรายการส่วนลด
              If mAllowUnderCost <> "1" And pAllowCheckCostAndPrice = "1" And (mUnitPrice > 0 AndAlso (mUnitPrice * SaleAmou) - mSubDisc < (.Item("unitCost") * SaleAmou)) And mHavePro = False Then
                pMessageBox = New MyMessageBox("ราคาขายต่ำกว่าต้นทุน ไม่สามารถทำการขายได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                pMessageBox.ShowDialog()
                'MessageBox.Show("ราคาขายต่ำกว่าต้นทุน ไม่สามารถทำการขายได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBarcode.Text = ""
                txtGoodAmou.Text = "1"
                lblPromotion.Text = ""
                dtgPrice.Rows.Clear()
                txtBarcode.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
              End If
              ' ####################

              ' เพิ่มรายการขาย
              dtgSale.Rows.Add()
              'dtgSale.Item("item", dtgSale.Rows.Count - 1).Value = dtgSale.Rows.Count & "."
              'dtgSale.Item("goodItem", dtgSale.Rows.Count - 1).Value = NextLineNo() & "."
              dtgSale.Item("barCode", dtgSale.Rows.Count - 1).Value = Barcode
              dtgSale.Item("goodName", dtgSale.Rows.Count - 1).Value = .Item("goodName").ToString
              ' แสดงรหัสสิทธิ์แลกซื้อ
              If BxCode <> "" Then
                dtgSale.Item("bxCode", dtgSale.Rows.Count - 1).Value = BxCode
              Else
                dtgSale.Item("bxCode", dtgSale.Rows.Count - 1).Value = CheckBuyExchange(mGoodCode, SaleAmou)
              End If

              dtgSale.Item("saleAmou", dtgSale.Rows.Count - 1).Value = SaleAmou
              dtgSale.Item("unitDesc", dtgSale.Rows.Count - 1).Value = .Item("unitDesc").ToString
              dtgSale.Item("unitPrice", dtgSale.Rows.Count - 1).Value = mUnitPrice

              'For Each mRow As DataGridViewRow In dtgPrice.Rows
              '  If dtgPrice.Item("pGoodAmou", mRow.Index).Value = SaleAmou Then
              '    dtgSale.Item("genUnitPrice", dtgSale.Rows.Count - 1).Value = dtgPrice.Item("pGenUnitPrice", mRow.Index).Value
              '    Exit For
              '  End If
              'Next

              ' @@@@@@@@@@@@@@@ req 2/2567 ต้องการลิงค์กับ ซิเมติค
              ' เก็บราคาลูกค้าทั่วไป ต่อ 1 ชิ้น จากตารางปรับราคา
              dtgSale.Item("genUnitPrice", dtgSale.Rows.Count - 1).Value = 0
              For x As Integer = dtgPrice.Rows.Count - 1 To 0 Step -1
                If dtgPrice.Item("pGoodAmou", x).Value = 1 Then
                  dtgSale.Item("genUnitPrice", dtgSale.Rows.Count - 1).Value = dtgPrice.Item("pGenUnitPrice", x).Value
                  Exit For
                End If
              Next

              ' เก็บราคา pack value ลูกค้าทั่วไป ต่อ 1 ชิ้น จากตารางปรับราคา
              dtgSale.Item("genVpUnitPrice", dtgSale.Rows.Count - 1).Value = 0
              For x As Integer = dtgPrice.Rows.Count - 1 To 0 Step -1
                If dtgPrice.Item("pGoodAmou", x).Value <= SaleAmou Then
                  dtgSale.Item("genVpUnitPrice", dtgSale.Rows.Count - 1).Value = dtgPrice.Item("pGenUnitPrice", x).Value
                  Exit For
                End If
              Next
              ' @@@@@@@@@@@@@@@

              dtgSale.Item("bxDisc", dtgSale.Rows.Count - 1).Value = BxDisc
              dtgSale.Item("goodDisc", dtgSale.Rows.Count - 1).Value = mGoodDisc
              dtgSale.Item("subDisc", dtgSale.Rows.Count - 1).Value = mSubDisc + BxDisc ' + ส่วนลดจากสิทธิ์แลกซื้อ
              dtgSale.Item("subTotal", dtgSale.Rows.Count - 1).Value = mSubTotal - BxDisc ' - ส่วนลดจากสิทธิ์แลกซื้อ
              dtgSale.Item("goodCode", dtgSale.Rows.Count - 1).Value = .Item("goodCode").ToString
              dtgSale.Item("goodCode2", dtgSale.Rows.Count - 1).Value = mGoodCode2
              dtgSale.Item("unitCode", dtgSale.Rows.Count - 1).Value = .Item("unitCode").ToString
              dtgSale.Item("unitCost", dtgSale.Rows.Count - 1).Value = CSng(.Item("unitCost"))
              dtgSale.Item("unitFactor", dtgSale.Rows.Count - 1).Value = CSng(.Item("unitFactor"))
              dtgSale.Item("subTotalCost", dtgSale.Rows.Count - 1).Value = SaleAmou * CSng(.Item("unitFactor")) * CSng(.Item("unitCost"))
              ' เก็บแต้มพิเศษและข้อมูลที่เกี่ยวข้อง
              dtgSale.Item("hugPoint", dtgSale.Rows.Count - 1).Value = mHugPoint
              dtgSale.Item("proPoint", dtgSale.Rows.Count - 1).Value = mProPoint
              dtgSale.Item("compCode", dtgSale.Rows.Count - 1).Value = mCompCode
              dtgSale.Item("proFlag", dtgSale.Rows.Count - 1).Value = mProFlag
              dtgSale.Item("promotion", dtgSale.Rows.Count - 1).Value = mPromotion
              dtgSale.Item("goodProNumb", dtgSale.Rows.Count - 1).Value = mGoodProNumb
              dtgSale.Item("subProDisc", dtgSale.Rows.Count - 1).Value = mSubProDisc
              dtgSale.Item("compDisc", dtgSale.Rows.Count - 1).Value = mCompDisc
              dtgSale.Item("compProDisc", dtgSale.Rows.Count - 1).Value = mCompProDisc ' เก็บส่วนลดโปรบริษัท (ถ้ามี) เพื่อไว้ใช้ตรวจสอบ
              dtgSale.Item("stockOnhand", dtgSale.Rows.Count - 1).Value = mStockOnhand

              ' แสดงคงเหลือหลังขาย เฉพาะสินค้าที่่ตัดสต๊อค
              If mNoBranchStock = "0" Then
                mStockAfterSale = mStockOnhand - (SaleAmou * mUnitFactor)
                dtgSale.Item("stockAfterSale", dtgSale.Rows.Count - 1).Value = mStockAfterSale
                ' เปลี่ยนสีอักษร ถ้าน้อยกว่าจุดสั่งซื้อ หรือต่ำกว่า 0
                If mStockAfterSale <= 0 Then
                  dtgSale.Item("stockAfterSale", dtgSale.Rows.Count - 1).Style.ForeColor = Color.Red
                Else
                  If mStockAfterSale <= mMiniStock And mMiniStock > 0 Then
                    dtgSale.Item("stockAfterSale", dtgSale.Rows.Count - 1).Style.ForeColor = Color.Blue
                  Else
                    dtgSale.Item("stockAfterSale", dtgSale.Rows.Count - 1).Style.ForeColor = Color.Black
                  End If
                End If
              End If

              dtgSale.Item("noBranchStock", dtgSale.Rows.Count - 1).Value = mNoBranchStock
              dtgSale.Item("useBxAmou", dtgSale.Rows.Count - 1).Value = 0

              ' หากสต๊อค <= 0 หรือสต๊อคมีไม่พอขาย ให้แสดงเป็นตัวอักษรสีแดง
              If mStockOnhand <= 0 OrElse mStockOnhand < SaleAmou Then
                dtgSale.Rows(dtgSale.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkRed
              End If

              '' ถ้ามีแต้มพิเศษ ให้ตัวอักษรแสดงสี
              'If mHugPoint > 0 Then
              '  If mGoodCode2 <> "" Then ' ถ้าได้แต้มจากการจับคู่
              '    dtgSale.Rows(dtgSale.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Blue
              '  Else
              '    If mProFlag = "1" Then ' ถ้าเป็นแต้มจากโปร.บริษัท
              '      dtgSale.Rows(dtgSale.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkGreen
              '    Else
              '      If mProDiscAmou > 0 Then ' โปร.สินค้าลดราคาพิเศษ
              '        dtgSale.Rows(dtgSale.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.SaddleBrown
              '      Else ' โปร.ได้แต้มทั่วไป
              '        dtgSale.Rows(dtgSale.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkMagenta
              '      End If
              '    End If
              '  End If
              'End If

              ' แสดงรูป
              Try
                Dim mGoodImageURL As String
                mGoodImageURL = pGoodImageFolder & "/" & .Item("goodCode").ToString & ".jpg"
                Dim mImage As New DownLoadImage(mGoodImageURL)
                Dim mMemStream As IO.MemoryStream = mImage.BeginDownLoad
                picGood.Image = Image.FromStream(mMemStream)
              Catch ex As Exception
                If Not (picGood.Image Is Nothing) Then
                  picGood.Image.Dispose()
                  picGood.Image = Nothing
                End If
              End Try

              dtgSale.FirstDisplayedScrollingRowIndex = dtgSale.Rows.Count - 1
              dtgSale.ClearSelection()
              ' ป้อนเลขลำดับที่
              For Each mRow As DataGridViewRow In dtgSale.Rows
                dtgSale.Item("goodItem", mRow.Index).Value = mRow.Index + 1 & "."
              Next

              lblGoodName.Text = .Item("goodName").ToString & "  " & SaleAmou.ToString & "  " & .Item("unitDesc").ToString '& " = " & mSubTotal.ToString("#,##0.00")
              lblGoodPrice.Text = mSubTotal.ToString("#,##0.00")

              Exit For
            End If
          End With
        Next
        '' ถ้าเป็นสินค้าชุด ให้หารายการสินค้าที่เป็นส่วนประกอบย่อย
        'If dvGoodPrice.Item(0).Item("flag").ToString = "s" Then
        '  dtgSale.Item("flag", dtgSale.Rows.Count - 1).Value = "S"
        '  Dim ds As New DataSet
        '  ds = pService.SelectData("Drug", "Select childBarCode, goodAmou From GoodSetList Where goodCode = '" & dvGoodPrice.Item(0).Item("goodCode").ToString & "'")
        '  If IsNothing(ds) = False Then
        '    Dim dv As New DataView(ds.Tables(0))
        '    For i As Integer = 0 To dv.Count - 1
        '      ' เพิ่มบรรทัดสินค้าย่อยแบบพิเศษ
        '      ShowChildGood(dv.Item(i).Item("childBarCode").ToString, CInt(dv.Item(i).Item("goodAmou")) * SaleAmou)
        '    Next
        '    dv = Nothing
        '  End If
        '  ds = Nothing
        'End If

        Call ClearGoodField()
        Call CalTotal()

        '' แสดงโปรโมชั่น
        'If lblPromotion.Text <> "" Then
        '  MessageBox.Show(lblPromotion.Text, "โปรโมชั่น", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If

        txtBarcode.Focus()
      Else
        ClearGoodField()
        pMessageBox = New MyMessageBox("ไม่พบข้อมูลสินค้า", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        pMessageBox.ShowDialog()
        'MessageBox.Show("ไม่พบข้อมูลสินค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        txtBarcode.Focus()
      End If
      dvGoodPrice = Nothing
    Else
      pMessageBox = New MyMessageBox("Error in select data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      pMessageBox.ShowDialog()
      'MessageBox.Show("Error in select data", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Call ClearGoodField()
    End If
    dsGoodPrice = Nothing
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub ShowChildGood(ByVal BarCode As String, ByVal GoodAmou As Integer)
    Dim mUnitCostField As String = "unitCost" & pBranchCode
    Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
    Dim dsGoodPrice As New DataSet
    dsGoodPrice = pService.SelectData("Drug", "SELECT GB.*, GI.goodName, GI." & mUnitCostField & ", GI." & mStockOnhandField & ", UI.unitDesc, UI.unitFactor, GP.membDisc, GP.emplDisc, GP.wholeDisc, GI.drugCode, GI.isSet FROM GoodBarcode GB INNER JOIN GoodInfo GI ON GB.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON GB.unitCode = UI.unitCode INNER JOIN GroupInfo GP ON GI.groupCode = GP.groupCode WHERE GB.barCode = '" & BarCode & "' AND GI.goodStat = '1' ORDER BY GB.goodAmou DESC")

    If IsNothing(dsGoodPrice) = False Then
      Dim dvGoodPrice As New DataView(dsGoodPrice.Tables(0))

      If dvGoodPrice.Count > 0 Then
        Dim mStockOnhand As Integer
        For i As Integer = 0 To dvGoodPrice.Count - 1
          With dvGoodPrice.Item(i)
            'หากจำนวนขายมากกว่าหรือเท่ากับจำนวนที่ตั้งราคาขาย ให้ใช้ราคานี้
            If GoodAmou >= CInt(.Item("goodAmou")) Then
              ' ใช้ราคาตามระดับราคาของสาขา
              Select Case pBranchPrice
                Case "1"
                  mUnitPrice = CSng(.Item("price1")) / CInt(.Item("goodAmou"))
                Case "2"
                  mUnitPrice = CSng(.Item("price2")) / CInt(.Item("goodAmou"))
                Case "3"
                  mUnitPrice = CSng(.Item("price3")) / CInt(.Item("goodAmou"))
                Case "4"
                  mUnitPrice = CSng(.Item("price4")) / CInt(.Item("goodAmou"))
                Case "5"
                  mUnitPrice = CSng(.Item("price5")) / CInt(.Item("goodAmou"))
                Case "6"
                  mUnitPrice = CSng(.Item("price6")) / CInt(.Item("goodAmou"))
              End Select

              mStockOnhand = CInt(.Item(mStockOnhandField))
              ' เพิ่มรายการขาย
              dtgSale.Rows.Add()
              dtgSale.Item("goodItem", dtgSale.Rows.Count - 1).Value = ""
              dtgSale.Item("barCode", dtgSale.Rows.Count - 1).Value = BarCode
              dtgSale.Item("goodName", dtgSale.Rows.Count - 1).Value = .Item("goodName").ToString
              dtgSale.Item("saleAmou", dtgSale.Rows.Count - 1).Value = GoodAmou
              dtgSale.Item("unitDesc", dtgSale.Rows.Count - 1).Value = .Item("unitDesc").ToString
              dtgSale.Item("unitPrice", dtgSale.Rows.Count - 1).Value = mUnitPrice
              dtgSale.Item("subDisc", dtgSale.Rows.Count - 1).Value = 0
              dtgSale.Item("subTotal", dtgSale.Rows.Count - 1).Value = 0
              dtgSale.Item("goodCode", dtgSale.Rows.Count - 1).Value = .Item("goodCode").ToString
              dtgSale.Item("unitCode", dtgSale.Rows.Count - 1).Value = .Item("unitCode").ToString
              dtgSale.Item("unitCost", dtgSale.Rows.Count - 1).Value = CSng(.Item(mUnitCostField))
              dtgSale.Item("unitFactor", dtgSale.Rows.Count - 1).Value = CSng(.Item("unitFactor"))
              dtgSale.Item("subTotalCost", dtgSale.Rows.Count - 1).Value = GoodAmou * CSng(.Item("unitFactor")) * CSng(.Item(mUnitCostField))
              dtgSale.Item("stockOnhand", dtgSale.Rows.Count - 1).Value = mStockOnhand
              ' หากสต๊อค <= 0 หรือสต๊อคมีไม่พอขาย ให้แสดงเป็นตัวอักษรสีแดง
              If mStockOnhand <= 0 OrElse mStockOnhand < GoodAmou Then
                dtgSale.Rows(dtgSale.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkRed
              End If
              'dtgSale.Item("flag", dtgSale.Rows.Count - 1).Value = "C"
              ' ซ่อนรายการที่เป็นส่วนประกอบ
              'dtgSale.Rows(dtgSale.Rows.Count - 1).Visible = False
              Exit For
            End If
          End With
        Next
      End If
      dvGoodPrice = Nothing
    End If
    dsGoodPrice = Nothing
  End Sub

  Private Sub ClearGoodField()
    txtBarcode.Text = ""
    txtGoodAmou.Text = "1"
    mSaleAmou = 1
  End Sub

  Private Sub ClearAll()
    txtCustCode.Enabled = True
    txtBarcode.Text = ""
    txtGoodAmou.Text = "1"
    txtCustCode.Text = ""
    lblCustName.Text = ""
    lblGoodName.Text = ""
    lblPromotion.Text = ""
    lblGoodPrice.Text = ""
    lblTotal.Text = "0.00"
    lblTotalNet.Text = "0.00"
    txtSaleRema.Text = ""
    lblThisPoint.Text = "0"
    lblPointDisc.Text = "0.00"

    lblCustType.Text = ""
    lblCustPoint.Text = ""
    lblRemainPoint.Text = ""
    lblDrugAller.Text = ""
    lblCongenDise.Text = ""

    If Not (picGood.Image Is Nothing) Then
      picGood.Image.Dispose()
      picGood.Image = Nothing
    End If

    dtgSale.Rows.Clear()
    dtgPro.Rows.Clear()
    dtgCustTypeDisc.Rows.Clear()
    dtgPrice.Rows.Clear()
    mSaleAmou = 1
    mSaleNumb = ""
    mSalePriceType = "R"
    mCustType = "1"
    mCustPriceType = "R"
    mNoBuyLimit = False
    mAllowOverBuyLimit = False
    mBuyPoint = 0
    'mExtraPoint = 0
    'mPlusPoint = 0
    mPointDisc = 0
    mBirthPointPlus = 1
    mThisPoint = 0
    mUsePoint = 0
    mCustPoint = 0
    mRemainPoint = 0
    lblBirthPointPlus.Visible = False
    mVIP = False
    'mTotalProDisc = 0
    mBxCode = ""
    mBxAmou = 0
    tbnTempSave.Enabled = False
    tbnTempCall.Enabled = False

    'Dim getValue() As String
    'Try
    '  getValue = pService.GetData("Drug", "SELECT saleNumb FROM BranchInfo WHERE branchCode = '" & pBranchCode & "'")
    '  If getValue(0) = "1" Then
    '    mSaleNumb = pPreSaleNumb & Mid((10000 + CInt(getValue(1))).ToString, 2)
    '  Else
    '    MessageBox.Show("ไม่สามารถกำหนดเลขที่ใบขายได้" & "(" & getValue(1) & ")", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    mSaleNumb = ""
    '    'Exit Sub
    '  End If
    'Catch ex As Exception
    '  MessageBox.Show("ไม่สามารถติดต่อกับ Server ได้ในขณะนี้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '  Exit Sub
    'End Try
    'lblSaleNumb.Text = mSaleNumb
  End Sub

  Private Sub frmDiarySale_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    If dtgSale.Rows.Count > 0 Then
      pMessageBox = New MyMessageBox("กรุณาดำเนินการขายให้เสร็จสิ้น ก่อนปิดหน้าต่าง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      pMessageBox.ShowDialog()
      e.Cancel = True
      'Else
      '  ' ถ้ามีข้อมูลขายที่พักไว้แต่ยังไม่ได้ขาย ให้ถือว่ายกเลิก
      '  ' เก็บข้อมูลที่ถูกยกเลิก
      '  If dtgTemp.Rows.Count > 0 Then
      '    Dim mSqlText(dtgTemp.Rows.Count) As String
      '    Dim mLine As Integer = 0
      '    ' ใช้วันที่และเวลาของ server
      '    pServerDateTime = pService.ServerDateTime

      '    For i As Integer = 0 To dtgTemp.Rows.Count - 1
      '      mSqlText(mLine) = "INSERT INTO HistSaleCancel (cancelDate, cancelTime, goodCode, goodAmou, unitCode, unitPrice, emplCode, branchCode) VALUES ('" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', '" & dtgTemp.Item("tgoodCode", i).Value.ToString & "', " & CInt(dtgTemp.Item("tsaleAmou", i).Value) & ", '" & dtgTemp.Item("tunitCode", i).Value.ToString & "', " & CDbl(dtgTemp.Item("tunitPrice", i).Value) & ", '" & pUserCode & "', '" & pBranchCode & "')"
      '      mLine += 1
      '    Next

      '    Dim retValue As String
      '    retValue = pService.UpdateData("Drug", mSqlText)
      '    If retValue <> "1" Then
      '      MessageBox.Show(retValue, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '    End If
      '    dtgTemp.Rows.Clear()
      '  End If
    End If
  End Sub

  Private Sub frmDiarySale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      'Case Keys.Space
      '  If pnlChange.Visible = True AndAlso mProcessSuccess = True Then
      '    ClearSale()
      '  End If
      Case Keys.F3
        tbnCustSearch.PerformClick()
      Case Keys.F4
        tbnGoodSearch.PerformClick()
        'Case Keys.F5
        '  tbnEmplSearch.PerformClick()
      Case Keys.F6
        tbnTempSave.PerformClick()
      Case Keys.F7
        tbnTempCall.PerformClick()
      Case Keys.F8
        tbnSave.PerformClick()
        'Case Keys.F9
        '  tbnUseBuyExchange.PerformClick()
      Case Keys.F10
        If mVIP = True Then
          tbnUsePoint.PerformClick()
        End If
        e.Handled = True
      Case Keys.F11
        tbnPromotion.PerformClick()
      Case Keys.F12
        tbnCancel.PerformClick()
      Case Keys.K ' เปิดลิ้นชัก
        If Control.ModifierKeys = Keys.Control Then
          OpenCashDrawer(pPrinterPort)
        End If
      Case Keys.D ' บันทึกส่วนลด
        If Control.ModifierKeys = Keys.Control AndAlso dtgSale.Rows.Count > 0 AndAlso pAllowDiscEnter = "1" Then
          dtgSale.Rows(dtgSale.Rows.Count - 1).Cells("subDisc").Selected = True
          dtgSale.SelectionMode = DataGridViewSelectionMode.CellSelect
          dtgSale.Columns("subDisc").ReadOnly = False
          dtgSale.Focus()
        End If
        'Case Keys.X ' ใช้สิทธิ์แลกซื้อ
        '  If Control.ModifierKeys = Keys.Control Then
        '    frmUseBuyExchange.ShowDialog()
        '    If frmUseBuyExchange.pOk = True Then
        '      ' เพิ่มรายการขาย จากรายการที่เลือกจากการใช้สิทธิ์แลกซื้อ
        '      Dim mListCount As Integer
        '      mListCount = frmUseBuyExchange.pBarCode.Length - 1
        '      For i As Integer = 0 To mListCount - 1
        '        ShowGood(frmUseBuyExchange.pBarCode(i), frmUseBuyExchange.pGoodAmou(i), frmUseBuyExchange.pDiscAmou(i), frmUseBuyExchange.pSaleNumb)
        '      Next
        '    End If
        '    frmUseBuyExchange = Nothing
        '  End If
    End Select
  End Sub

  Private Sub CheckPriv()
    ' Add
    If InStr(pUserPriv, Me.Tag.ToString & "A") > 0 Then
      tbnSave.Enabled = True
    Else
      tbnSave.Enabled = False
    End If
    '' Cancel
    'If InStr(pUserPriv, Me.Tag.ToString & "C") > 0 Then
    '  tbnCancel.Enabled = True
    'Else
    '  tbnCancel.Enabled = False
    'End If
  End Sub

  Private Sub PrepCreditInfo()
    Me.Cursor = Cursors.WaitCursor
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "SELECT * FROM CreditInfo ORDER BY creditName")
    If IsNothing(ds) = False Then
      pDVCredit = New DataView(ds.Tables(0))
    End If
    ds = Nothing
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub PrepEmplInfo()
    Me.Cursor = Cursors.WaitCursor
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "SELECT emplCode, emplName FROM EmplInfo WHERE emplStat <> '0'") ' AND (branchCode = '" & pBranchCode & "' OR branchCode = '00')")
    If IsNothing(ds) = False Then
      pDVEmpl = New DataView(ds.Tables(0))
    End If
    ds = Nothing
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub txtGoodAmou_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGoodAmou.GotFocus
    txtGoodAmou.SelectionStart = 0
    txtGoodAmou.SelectionLength = txtGoodAmou.Text.Length
  End Sub

  Private Sub CalTotal()
    mTotalPrice = 0
    mTotalPriceNet = 0
    mTotalCost = 0
    mTotalDisc = 0
    mTotalGoodProPrice = 0
    'mTotalProDisc = 0
    For i As Integer = 0 To dtgSale.Rows.Count - 1
      mSaleAmou = CInt(dtgSale.Item("saleAmou", i).Value)
      mUnitPrice = CDbl(dtgSale.Item("unitPrice", i).Value)

      mTotalPrice += dtgSale.Item("subTotal", i).Value
      mTotalCost += CSng(dtgSale.Item("subTotalCost", i).Value)
      mTotalDisc += CSng(dtgSale.Item("subDisc", i).Value)
      'mTotalProDisc += CSng(dtgSale.Item("subProDisc", i).Value)
      '' รวมยอดเงินเฉพาะรายการที่ได้แต้มแล้ว เพื่อนำไปหักออกจากยอดทั้งหมด ก่อนคิดแต้ม
      'If CInt(dtgSale.Item("hugPoint", i).Value) > 0 OrElse dtgSale.Item("proFlag", i).Value.ToString <> "" Then
      '  mTotalGoodProPrice += CSng(dtgSale.Item("subTotal", i).Value)
      'End If
      ' เปลี่ยนสีตัวอักษร ถ้ามีส่วนลดซัพฯ
      If dtgSale.Item("compDisc", i).Value > 0 Then
        dtgSale.Item("compDisc", i).Style.ForeColor = Color.Purple
      Else
        dtgSale.Item("compDisc", i).Style.ForeColor = Color.Black
      End If
      ' เปลี่ยนสีตัวอักษร ส่วนลดสินค้า
      If dtgSale.Item("goodDisc", i).Value > 0 Then
        dtgSale.Item("goodDisc", i).Style.ForeColor = Color.Purple
      Else
        dtgSale.Item("goodDisc", i).Style.ForeColor = Color.Black
      End If
      ' เปลี่ยนสีตัวอักษร ถ้ามีส่วนลดรวม
      If dtgSale.Item("subDisc", i).Value > 0 Then
        dtgSale.Item("subDisc", i).Style.ForeColor = Color.Red
      Else
        dtgSale.Item("subDisc", i).Style.ForeColor = Color.Black
      End If
      ' เปลี่ยนสีตัวอักษร ถ้าใช้สิทธิแลกซื้อ
      If dtgSale.Item("useBxAmou", i).Value > 0 Then
        dtgSale.Item("bxCode", i).Style.ForeColor = Color.Blue
      Else
        dtgSale.Item("bxCode", i).Style.ForeColor = Color.Black
      End If
    Next
    mTotalPriceNet = mTotalPrice - mPointDisc
    lblTotal.Text = mTotalPrice.ToString("#,##0.00")
    lblTotalNet.Text = mTotalPriceNet.ToString("#,##0.00")

    ' เฉพาะสมาชิก VIP ให้คิดแต้ม
    If mVIP = True Then
      ' แต้มจากการซื้อสินค้า (ไม่หักรายการที่ได้แต้มพิเศษไปแล้ว)
      ' ลูกค้าปลีก
      If mCustPriceType = "R" Then
        If pBahtPerPoint > 0 Then
          mBuyPoint = CInt(Fix(mTotalPriceNet / pBahtPerPoint))
        Else
          mBuyPoint = 0
        End If
      Else
        ' ลูกค้าส่ง
        If pWholeBahtPerPoint > 0 Then
          mBuyPoint = CInt(Fix(mTotalPriceNet / pWholeBahtPerPoint))
        Else
          mBuyPoint = 0
        End If
      End If
      '' แต้มจากการซื้อสินค้า (หักรายการที่ได้แต้มพิเศษไปแล้ว)
      'mBuyPoint = CInt(Fix((mTotalPriceNet - mTotalGoodProPrice) / pBahtPerPoint))
      ' แต้มจากโปร.สินค้าพิเศษแต่ละรายการ
      Dim mExtraGoodPoint As Integer = 0
      For Each mRow As DataGridViewRow In dtgSale.Rows
        mExtraGoodPoint = mExtraGoodPoint + CInt(dtgSale.Item("hugPoint", mRow.Index).Value)
      Next
      ' แต้มจากโปร.ทั่วไป
      Dim mTTExtraPoint, mTTPlusPoint As Integer
      Dim mExtraPoint, mPlusPoint As Integer
      Dim mBuyPrice As Integer
      'Dim mRowCheck As Boolean
      mTTExtraPoint = 0
      mTTPlusPoint = 0
      For Each mRow As DataGridViewRow In dtgPro.Rows
        'mRowCheck = CBool(dtgPro.Item("rowCheck", mRow.Index).Value)
        'If mRowCheck = True Then
        mBuyPrice = CInt(dtgPro.Item("buyPrice", mRow.Index).Value)
        mExtraPoint = CInt(dtgPro.Item("extraPoint", mRow.Index).Value)
        mPlusPoint = CInt(dtgPro.Item("plusPoint", mRow.Index).Value)
        ' ถ้ายอดซื้อตรงตามเงื่อนไข
        If mTotalPrice >= mBuyPrice Then
          mTTExtraPoint = mTTExtraPoint + mExtraPoint
          mTTPlusPoint = mTTPlusPoint + mPlusPoint
          Exit For
        End If

        '' ถ้าให้แต้มทุก ๆ ยอดซื้อ
        'If mEveryPrice = 0 Then
        '  mTTExtraPoint = mTTExtraPoint + mExtraPoint
        '  mTTPlusPoint = mTTPlusPoint + mPlusPoint
        'Else ' ให้แต้มเฉพาะยอดซื้อตามที่กำหนด
        '  If mTotalPrice >= mBuyPrice Then
        '    mTTExtraPoint = mTTExtraPoint + (mExtraPoint * CInt(Fix(mTotalPrice / mEveryPrice)))
        '    mTTPlusPoint = mTTPlusPoint + (mPlusPoint * CInt(Fix(mTotalPrice / mEveryPrice)))

        '  End If
        'End If
        'End If
      Next

      ' รวมแต้ม = แต้มเบิ้ลจากวันเกิด + แต้มพิเศษจากโปร.ทั่วไป + แต้มเบิ้ลจากโปร.ทั่้วไป + แต้มจากโปร.สินค้าแต่ละรายการ
      mThisPoint = (mBuyPoint * mBirthPointPlus) + mTTExtraPoint + (mBuyPoint * mTTPlusPoint) + mExtraGoodPoint
      lblThisPoint.Text = mThisPoint.ToString
    End If
  End Sub

  Private Sub tbnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnCancel.Click
    If dtgSale.Rows.Count > 0 Then
      pMessageBox = New MyMessageBox("ยืนยันยกเลิกการขาย", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      If pMessageBox.ShowDialog = Windows.Forms.DialogResult.No Then
        Exit Sub
      End If
      'If MessageBox.Show("ยืนยันยกเลิกการขาย", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
      '  Exit Sub
      'End If
      '' เก็บข้อมูลที่ถูกยกเลิก
      'Dim mSqlText(dtgSale.Rows.Count) As String
      'Dim mLine As Integer = 0
      '' ใช้วันที่และเวลาของ server
      'pServerDateTime = pService.ServerDateTime

      'For i As Integer = 0 To dtgSale.Rows.Count - 1
      '  mSqlText(mLine) = "INSERT INTO HistSaleCancel (cancelDate, cancelTime, goodCode, goodAmou, unitCode, unitPrice, emplCode, branchCode) VALUES ('" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', '" & dtgSale.Item("goodCode", i).Value.ToString & "', " & CInt(dtgSale.Item("saleAmou", i).Value) & ", '" & dtgSale.Item("unitCode", i).Value.ToString & "', " & CDbl(dtgSale.Item("unitPrice", i).Value) & ", '" & pUserCode & "', '" & pBranchCode & "')"
      '  mLine += 1
      'Next

      'Dim retValue As String
      'retValue = pService.UpdateData("Drug", mSqlText)
      'If retValue <> "1" Then
      '  MessageBox.Show(retValue, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      'End If

    End If
    ClearAll()
    txtCustCode.Focus()

  End Sub

  Private Sub txtGoodAmou_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGoodAmou.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      txtBarcode.Focus()
    End If
  End Sub

  Private Sub txtCustCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCustCode.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
      'If txtCustCode.Text = "" Then
      '  txtCustCode.Text = "0"
      'End If
      'ShowCust(txtCustCode.Text)
    End If
  End Sub

  Private Sub txtCustCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustCode.LostFocus
    If txtCustCode.Text.Trim = "" Then
      txtCustCode.Text = "0"
    End If
    ShowCust(txtCustCode.Text)
  End Sub

  Private Sub ClearCustField()
    txtCustCode.Text = ""
    lblCustName.Text = ""
    lblCustType.Text = ""
    lblRemainPoint.Text = ""
    lblCustPoint.Text = ""
    lblCongenDise.Text = ""
    lblDrugAller.Text = ""
    lblBirthPointPlus.Visible = False
  End Sub

  Private Sub ShowCust(ByVal CustCode As String)
    Me.Cursor = Cursors.WaitCursor

    ' ลูกค้าทั่วไป รหัส 0
    If CustCode = "0" Then
      lblCustName.Text = "ลูกค้าทั่วไป"
      lblCustType.Text = "ทั่วไป"
      lblRemainPoint.Text = ""
      lblCustPoint.Text = ""
      lblCongenDise.Text = ""
      lblDrugAller.Text = ""
      lblBirthPointPlus.Visible = False

      mCustType = "1"
      mCustPriceType = "R" ' ลูกค้าปลีก
      mCustPoint = 0
      mRemainPoint = 0
      mBirthPointPlus = 1
      mVIP = False
    Else
      Dim dsCust As New DataSet
      ' ค้นหาข้อมูลลูกค้า
      ' ถ้าป้อนหมายเลขโทรศัพท์มือถือ (ตัวเลข 10 หลัก)
      If txtCustCode.Text.Length = 10 Then
        dsCust = pService.SelectData("Drug", "Select CI.*, CT.custTypeDesc, CT.priceType from CustInfo CI inner join CustType CT on CT.custTypeCode = CI.custType Where CI.custMBPhone = '" & txtCustCode.Text & "'")
      Else
        ' ถ้าป้อนหมายเลขบัตร ปชช (ตัวเลข 13 หลัก)
        If txtCustCode.Text.Length = 13 Then
          dsCust = pService.SelectData("Drug", "Select CI.*, CT.custTypeDesc, CT.priceType from CustInfo CI inner join CustType CT on CT.custTypeCode = CI.custType Where CI.idCard = '" & txtCustCode.Text & "'")
        Else
          dsCust = pService.SelectData("Drug", "Select CI.*, CT.custTypeDesc, CT.priceType from CustInfo CI inner join CustType CT on CT.custTypeCode = CI.custType Where CI.custCode = '" & txtCustCode.Text & "'")
        End If
      End If
      If IsNothing(dsCust) = False Then
        Dim dvCust As New DataView(dsCust.Tables(0))
        If dvCust.Count > 0 Then
          With dvCust.Item(0)
            If .Item("custStat").ToString = "0" Then
              pMessageBox = New MyMessageBox("สมาชิกรายนี้ ถูกยกเลิกแล้ว", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
              pMessageBox.ShowDialog()
              'MessageBox.Show("สมาชิกรายนี้ ถูกยกเลิกแล้ว", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
              ClearCustField()
              Me.Cursor = Cursors.Default
              Exit Sub
            End If

            txtCustCode.Text = .Item("custCode").ToString
            lblCustName.Text = .Item("custName").ToString
            lblCustType.Text = .Item("custTypeDesc").ToString

            mCustType = .Item("custType").ToString
            mCustPriceType = .Item("priceType").ToString
            If mCustPriceType = "W" AndAlso pAllowWholePrice = "0" Then
              pMessageBox = New MyMessageBox("ไม่สามารถทำการขายให้ลูกค้าขายส่งได้ เนื่องจากสาขานี้ยังไม่ได้เปิดระบบขายส่ง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
              pMessageBox.ShowDialog()
              'MessageBox.Show("ไม่สามารถทำการขายให้ลูกค้าขายส่งได้ เนื่องจากสาขานี้ยังไม่ได้เปิดระบบขายส่ง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
              txtCustCode.Text = ""
              lblCustName.Text = ""
              lblCustType.Text = ""
              txtCustCode.Focus()
              Me.Cursor = Cursors.Default
              Exit Sub
            Else
              If mCustPriceType = "O" AndAlso pAllowOnlinePrice = "0" Then
                pMessageBox = New MyMessageBox("ไม่สามารถทำการขายให้ลูกค้า Online ได้ เนื่องจากสาขานี้ยังไม่ได้เปิดระบบขาย Online", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                pMessageBox.ShowDialog()
                'MessageBox.Show("ไม่สามารถทำการขายให้ลูกค้า Online ได้ เนื่องจากสาขานี้ยังไม่ได้เปิดระบบขาย Online", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCustCode.Text = ""
                lblCustName.Text = ""
                lblCustType.Text = ""
                txtCustCode.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
              Else
                ' ลูกค้า O2O
                If mCustType = "7" AndAlso pAllowO2OSale = "0" Then
                  pMessageBox = New MyMessageBox("ไม่สามารถทำการขายให้ลูกค้า O2O ได้ เนื่องจากสาขานี้ยังไม่ได้เปิดระบบขาย O2O", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                  pMessageBox.ShowDialog()
                  'MessageBox.Show("ไม่สามารถทำการขายให้ลูกค้า O2O ได้ เนื่องจากสาขานี้ยังไม่ได้เปิดระบบขาย O2O", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                  txtCustCode.Text = ""
                  lblCustName.Text = ""
                  lblCustType.Text = ""
                  txtCustCode.Focus()
                  Me.Cursor = Cursors.Default
                  Exit Sub
                End If
              End If
            End If

            mNoBuyLimit = IIf(.Item("noBuyLimit").ToString = "1", True, False)
            mCustPoint = CInt(.Item("hugPoint"))
            mRemainPoint = mCustPoint
            mMembPrice = .Item("membPrice")

            lblCustPoint.Text = mCustPoint.ToString("#,##0")
            lblRemainPoint.Text = mRemainPoint.ToString("#,##0")
            lblCongenDise.Text = .Item("congenDise").ToString

            ' เฉพาะพนักงาน หายอดซื้อแล้วในเดือนนี้ แล้วแสดงผล
            If mCustType = "2" Then
              Dim ds As New DataSet
              'ds = pService.SelectData("Drug", "Select totalPrice, saleStat from HistSale where custCode = '" & txtCustCode.Text & "' and saleDate >= '" & MDYStr(pStartDateLimit) & "' and saleDate <= '" & MDYStr(pEndDateLimit) & "'")
              mCommandText = "Select custCode, sum(totalPrice) as totalPrice from HistSale where saleStat <> '0' and custCode = '" & txtCustCode.Text & "' and saleDate >= '" & MDYStr(pStartDateLimit) & "' and saleDate <= '" & MDYStr(pEndDateLimit) & "' Group by custCode"

              ds = pService.SelectData("Drug", mCommandText)
              If IsNothing(ds) = False Then
                Dim dv As New DataView(ds.Tables(0))
                If dv.Count > 0 Then
                  mTotalThisMonthBuy = dv.Item(0).Item("totalPrice")
                  'mTotalThisMonthBuy = 0
                  'For i As Integer = 0 To dv.Count - 1
                  '  If dv.Item(i).Item("saleStat").ToString <> "0" Then
                  '    mTotalThisMonthBuy += dv.Item(i).Item("totalPrice")
                  '  End If
                  'Next
                Else
                  mTotalThisMonthBuy = 0
                End If
                dv = Nothing
              Else
                pMessageBox = New MyMessageBox("ระบบค้นหาข้อมูลยอดซื้อไม่สำเร็จ กรุณาลองใหม่อีกครั้ง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                pMessageBox.ShowDialog()
                'MessageBox.Show("ระบบค้นหาข้อมูลยอดซื้อไม่สำเร็จ กรุณาลองใหม่อีกครั้ง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCustCode.Text = ""
                lblCustName.Text = ""
                lblCustType.Text = ""
                lblCustPoint.Text = ""
                lblRemainPoint.Text = ""
                lblCongenDise.Text = ""
                txtCustCode.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
              End If
              ds = Nothing

              'Dim mGet() As String
              'mGet = pService.GetData("Drug", "Select sum(totalPrice) as totalBuy from HistSale where custCode = '" & txtCustCode.Text & "' and saleDate >= '" & MDYStr(pStartDateLimit) & "' and saleDate <= '" & MDYStr(pEndDateLimit) & "' and saleStat <> '0'")
              'If mGet(0) = "1" Then
              '  mTotalThisMonthBuy = CDbl(Val(mGet(1)))
              'Else
              '  If mGet(0) = "-1" Then ' ไม่มียอดซื้อ
              '    mTotalThisMonthBuy = 0
              '  Else
              '    MessageBox.Show("ระบบค้นหาข้อมูลลูกค้าไม่สำเร็จ กรุณาลองใหม่อีกครั้ง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
              '    txtCustCode.Text = ""
              '    lblCustName.Text = ""
              '    lblCustType.Text = ""
              '    lblCustPoint.Text = ""
              '    lblRemainPoint.Text = ""
              '    lblCongenDise.Text = ""
              '    txtCustCode.Focus()
              '    Me.Cursor = Cursors.Default
              '    Exit Sub
              '  End If
              'End If

              ' ยืม control lblcustpoint ให้แสดงยอดซื้อเดือนนี้
              lblCustLabel6.Text = "ยอดซื้อรอบนี้"
              lblCustPoint.Text = mTotalThisMonthBuy.ToString
              lblCustLabel7.Visible = False
              lblRemainPoint.Visible = False
            Else ' ลูกค้าประเภทอื่น แสดงแต้มสะสม
              lblCustLabel6.Text = "แต้มสะสมปัจจุบัน"
              lblCustLabel7.Visible = True
              lblRemainPoint.Visible = True
            End If

            ' เฉพาะสมาชิก HUG Club ลูกค้าส่ง
            If mCustType = "6" Or mCustType = "4" Then
              mVIP = True
              ' เพิ่มแต้มพิเศษเดือนเกิด
              Dim mBirthDay As Date
              Try
                mBirthDay = CDate(.Item("birthDay"))
                ' เพิ่มแต้ม ? เท่าในเดือนเกิด เฉพาะบิลแรก(เช็คจากฟิลด์ birthProYear ของลูกค้า
                If mBirthDay.Month = pServerDateTime.Date.Month AndAlso pServerDateTime.Date.Year > CInt(.Item("birthProYear")) Then
                  lblBirthPointPlus.Text = "*แต้ม " & pBirthPointPlus.ToString & " เท่าของบิลแรกในเดือนเกิด*"
                  lblBirthPointPlus.Visible = True
                  mBirthPointPlus = pBirthPointPlus
                Else
                  lblBirthPointPlus.Text = ""
                  lblBirthPointPlus.Visible = False
                  mBirthPointPlus = 1
                End If

              Catch ex As Exception

              End Try
            Else
              mVIP = False
            End If
          End With

          ' แสดงการแพ้ยา
          lblDrugAller.Text = ""
          If txtCustCode.Text <> "0" Then
            Dim dsAller As New DataSet
            dsAller = pService.SelectData("Drug", "Select DG.drugDesc From DrugAllergic DA Inner Join DrugGroup DG On DG.drugCode = DA.drugCode Where DA.custCode = '" & txtCustCode.Text & "'")
            If IsNothing(dsAller) = False Then
              Dim dvAller As New DataView(dsAller.Tables(0))
              For x As Integer = 0 To dvAller.Count - 1
                lblDrugAller.Text = lblDrugAller.Text & dvAller.Item(x).Item("drugDesc").ToString & ", "
              Next
              dvAller = Nothing
            End If
            dsAller = Nothing
          End If
        Else
          txtCustCode.Text = ""
          lblCustName.Text = ""
          lblCustType.Text = ""
          pMessageBox = New MyMessageBox("ไม่พบข้อมูลลูกค้า", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
          pMessageBox.ShowDialog()
          'MessageBox.Show("ไม่พบข้อมูลลูกค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
          txtCustCode.Focus()
          Me.Cursor = Cursors.Default
          Exit Sub
        End If
        dvCust = Nothing
      Else
        txtCustCode.Text = ""
        lblCustName.Text = ""
        lblCustType.Text = ""
        pMessageBox = New MyMessageBox("ไม่พบข้อมูลลูกค้า", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        pMessageBox.ShowDialog()
        'MessageBox.Show("ไม่พบข้อมูลลูกค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        txtCustCode.Focus()
        Me.Cursor = Cursors.Default
        Exit Sub
      End If
      dsCust = Nothing
    End If

    lblThisPoint.Text = "0"
    mThisPoint = 0
    mUsePoint = 0
    mPointDisc = 0
    lblPointDisc.Text = "0.00"
    '' ใช้วันที่และเวลาของ server
    'pServerDateTime = pService.ServerDateTime

    '' เตรียมตารางส่วนลดลูกค้า ตามประเภทลูกค้า
    '' หากมีรายการซ้ำ ให้เรียงตามลำดับวันที่มีผลบังคับใช้และวันสิ้นสุดบังคับใช้ล่าสุด
    'dtgCustTypeDisc.Rows.Clear()
    'For Each mRow As DataGridViewRow In dtgDiscTemp.Rows
    '  If dtgDiscTemp.Item("custTypeCode", mRow.Index).Value.ToString = mCustType Then
    '    dtgCustTypeDisc.Rows.Add()
    '    dtgCustTypeDisc.Item("custType", dtgCustTypeDisc.Rows.Count - 1).Value = dtgDiscTemp.Item("tCustTypeCode", mRow.Index).Value.ToString
    '    dtgCustTypeDisc.Item("cateCode", dtgCustTypeDisc.Rows.Count - 1).Value = dtgDiscTemp.Item("tCateCode", mRow.Index).Value.ToString
    '    dtgCustTypeDisc.Item("typeCode", dtgCustTypeDisc.Rows.Count - 1).Value = dtgDiscTemp.Item("tTypeCode", mRow.Index).Value.ToString
    '    dtgCustTypeDisc.Item("groupCode", dtgCustTypeDisc.Rows.Count - 1).Value = dtgDiscTemp.Item("tGroupCode", mRow.Index).Value.ToString
    '    dtgCustTypeDisc.Item("custDisc", dtgCustTypeDisc.Rows.Count - 1).Value = dtgDiscTemp.Item("tCustDisc", mRow.Index).Value.ToString
    '  End If
    'Next

    ' เตรียมตารางโปรทั่วไป (แต้มพิเศษ) ยกเว้นลูกค้าทั่วไปรหัส 0
    If CustCode <> "00" Then
      dtgPro.Rows.Clear()
      For Each mRow As DataGridViewRow In dtgProTemp.Rows
        If dtgProTemp.Item("tCustTypeCode", mRow.Index).Value.ToString = mCustType Or dtgProTemp.Item("tCustTypeCode", mRow.Index).Value.ToString = "0" Then
          ' อยู่ในช่วงโปร
          If pServerDateTime.Date >= CDate(dtgProTemp.Item("tStartDate", mRow.Index).Value) AndAlso pServerDateTime.Date <= CDate(dtgProTemp.Item("tEndDate", mRow.Index).Value) Then
            dtgPro.Rows.Add()
            dtgPro.Item("rowCheck", dtgPro.Rows.Count - 1).Value = False
            dtgPro.Item("proText", dtgPro.Rows.Count - 1).Value = dtgProTemp.Item("tProtext", mRow.Index).Value
            dtgPro.Item("proPeriod", dtgPro.Rows.Count - 1).Value = dtgProTemp.Item("tProPeriod", mRow.Index).Value
            dtgPro.Item("extraPoint", dtgPro.Rows.Count - 1).Value = dtgProTemp.Item("tExtraPoint", mRow.Index).Value
            dtgPro.Item("plusPoint", dtgPro.Rows.Count - 1).Value = dtgProTemp.Item("tPlusPoint", mRow.Index).Value
            dtgPro.Item("proNo", dtgPro.Rows.Count - 1).Value = dtgProTemp.Item("tProNo", mRow.Index).Value
            dtgPro.Item("buyPrice", dtgPro.Rows.Count - 1).Value = dtgProTemp.Item("tBuyPrice", mRow.Index).Value
            dtgPro.Item("freeMember", dtgPro.Rows.Count - 1).Value = dtgProTemp.Item("tFreeMember", mRow.Index).Value
          End If
        End If
      Next
    End If

    dtgSale.Rows.Clear()
    dtgPrice.Rows.Clear()
    lblGoodName.Text = ""
    lblGoodPrice.Text = ""
    lblPromotion.Text = ""
    lblTotal.Text = "0.00"
    lblTotalNet.Text = "0.00"
    mTotalPrice = 0
    mTotalPriceNet = 0

    If Not (picGood.Image Is Nothing) Then
      picGood.Image.Dispose()
      picGood.Image = Nothing
    End If

    tbnTempSave.Enabled = True
    If dtgTemp.Rows.Count > 0 Then
      tbnTempCall.Enabled = True
    Else
      tbnTempCall.Enabled = False
    End If

    'If mMembPrice > 0 Then
    '  ShowGood("066", 1, 0, "")
    'End If

    CalTotal()
    txtCustCode.Enabled = False
    txtBarcode.Focus()

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub tbnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnSave.Click
    SalePaid()
  End Sub

  Private Sub SalePaid()
    If dtgSale.Rows.Count > 0 Then
      If Trim(txtCustCode.Text) = "" Then
        pMessageBox = New MyMessageBox("กรุณาป้อนรหัสลูกค้าก่อนทำการขาย", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        pMessageBox.ShowDialog()
        Exit Sub
      End If
      ' ลูกค้าประเภทพนักงานสวัสดิการ (ยกเว้นรายที่ไม่จำกัดวงเงิน) ให้ตรวจสอบยอดเงินรวมที่ซื้อในเดือนนี้ว่าเกินวงเงินหรือไม่
      If mCustType = "2" And Not mNoBuyLimit Then
        Dim mGet() As String
        ' ยอดเงินซื้อแล้วเดือนนี้ + ยอดเงินจะซื้อครั้งนี้ ต้องไม่เกินวงเงินที่กำหนด
        If mTotalThisMonthBuy + mTotalPriceNet > pEmplBuyLimit Then
          ' เช็คว่าอยู่ในรายชื่อเพิ่มสิทธิซื้อหรือไม่
          mGet = pService.GetData("Drug", "Select custCode from OverLimitList where custCode = '" & txtCustCode.Text & "' and overStat = '1'")
          If mGet(0) <> "1" Then
            pMessageBox = New MyMessageBox("ยอดซื้อเกินวงเงินที่กำหนด", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            pMessageBox.ShowDialog()
            mAllowOverBuyLimit = False
            Exit Sub
          Else
            mAllowOverBuyLimit = True
          End If
        End If
      End If

      frmSalePaid.pTotalPrice = mTotalPriceNet
      frmSalePaid.pCustTypeCode = mCustType
      frmSalePaid.ShowDialog()
      If frmSalePaid.pOk = True Then
        mTotalCashPay = frmSalePaid.pCashPaid
        mTotalCash = frmSalePaid.pCashAmou
        mTotalChange = frmSalePaid.pChangeAmou
        mGridPay = frmSalePaid.pGridPay
        mEmplCode = frmSalePaid.pEmplCode
        mEmplName = frmSalePaid.pEmplName

        SaveData()
      End If
      frmSalePaid = Nothing
    End If
  End Sub

  Private Sub SaveData()
    ' เช็คตารางการขาย (แก้ไข error ขายสินค้าแต่ไม่มีการบันทึกรายการขาย)
    If dtgSale.Rows.Count <= 0 Then
      pMessageBox = New MyMessageBox("ไม่พบรายการขายสินค้า กรุณาทำการขายใหม่", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
      pMessageBox.ShowDialog()
      Exit Sub
    End If

    Dim getValue() As String
    Try
      getValue = pService.GetData("Drug", "SELECT saleNumb FROM BranchInfo WHERE branchCode = '" & pBranchCode & "'")
      If getValue(0) = "1" Then
        mSaleNumb = pPreSaleNumb & Mid((100000 + CInt(getValue(1))).ToString, 2)
      Else
        pMessageBox = New MyMessageBox("ไม่สามารถกำหนดเลขที่ใบขายได้" & "(" & getValue(1) & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        pMessageBox.ShowDialog()
        Exit Sub
      End If
    Catch ex As Exception
      pMessageBox = New MyMessageBox("ไม่สามารถติดต่อกับ Server ได้ในขณะนี้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      pMessageBox.ShowDialog()
      Exit Sub
    End Try

    Me.Cursor = Cursors.WaitCursor

    Dim mStockOnhandField, mLastSaleField As String
    mStockOnhandField = "stockOnhand" & pBranchCode
    mLastSaleField = "lastSale" & pBranchCode

    Dim mSqlText((dtgSale.Rows.Count * 7) + 15 + mGridPay.Rows.Count) As String
    Dim mLine As Integer = 0

    pServerDateTime = pService.ServerDateTime

    If txtCustCode.Text = "" Then txtCustCode.Text = "0"

    mSqlText(mLine) = "INSERT INTO HistSale (saleNumb, saleDate, saleTime, branchCode, custCode, emplCode, cashCode, totalPrice, totalDisc, totalCost, totalPay, totalCash, totalCredit, totalDebt, totalCupong, perCharge, payType, creditNumb, saleStat, creditCode, custType, saleRema, pointDisc, salePriceType, closeNumb) VALUES ('" & mSaleNumb & "', '" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', '" & pBranchCode & "', '" & txtCustCode.Text & "', '" & mEmplCode & "', '" & pUserCode & "', " & mTotalPrice & ", " & mTotalDisc & ", " & mTotalCost & ", " & mTotalCashPay & ", " & mTotalCash & ", " & mTotalCredit & ", " & mTotalDebt & ", " & mTotalCupong & ", " & mPerCharge & ", '" & mPayType & "', '" & mCreditNumb & "', '1', '" & mCreditCode & "', '" & mCustType & "', '" & txtSaleRema.Text & "', " & mPointDisc & ", '" & mSalePriceType & "', '0')"
    mLine += 1

    mSqlText(mLine) = "UPDATE BranchInfo set saleNumb = saleNumb + 1 WHERE branchCode = '" & pBranchCode & "'"
    mLine += 1

    'Dim dsGoodStock As New DataSet
    Dim mBarCode As String
    Dim mGoodCode As String
    Dim mTotalGoodAmou As Integer
    Dim mStockOnhand As Integer
    Dim mStockAfterSale As Integer
    Dim mNoBranchStock As String

    Dim mGenUnitPrice As Double
    Dim mGenVpUnitPrice As Double

    For Each row As DataGridViewRow In dtgSale.Rows
      mBarCode = dtgSale.Item("barCode", row.Index).Value.ToString
      mGoodCode = dtgSale.Item("goodCode", row.Index).Value.ToString
      mNoBranchStock = dtgSale.Item("noBranchStock", row.Index).Value
      mGenUnitPrice = Val(dtgSale.Item("genUnitPrice", row.Index).Value)
      mGenVpUnitPrice = Val(dtgSale.Item("genVpUnitPrice", row.Index).Value)
      ' เช็คสต๊อคคงเหลือล่าสุด
      mStockOnhand = GetStockOnhand(mGoodCode, pBranchCode) ' dtgSale.Item("stockOnhand", row.Index).Value
      mTotalGoodAmou = CInt(dtgSale.Item("saleAmou", row.Index).Value) * CInt(dtgSale.Item("unitFactor", row.Index).Value)
      mStockAfterSale = mStockOnhand - mTotalGoodAmou

      mSqlText(mLine) = "INSERT INTO SaleList (saleNumb, barCode, goodCode, goodAmou, unitCode, unitPrice, unitCost, subDisc, NormUnitPrice, ValuePackNormUnitPrice) VALUES ('" & mSaleNumb & "', '" & mBarCode & "', '" & mGoodCode & "', " & CInt(dtgSale.Item("saleAmou", row.Index).Value) & ", '" & dtgSale.Item("unitCode", row.Index).Value.ToString & "', " & CSng(dtgSale.Item("unitPrice", row.Index).Value) & ", " & CSng(dtgSale.Item("unitCost", row.Index).Value) & ", " & CSng(dtgSale.Item("subDisc", row.Index).Value) & ", " & mGenUnitPrice & ", " & mGenVpUnitPrice & ")"
      mLine += 1
      ' ตัดสต๊อครวม ยกเว้นสินค้าที่ไม่เก็บสต๊อคสาขา
      If mNoBranchStock = "0" Then
        mSqlText(mLine) = "UPDATE GoodInfo set " & mStockOnhandField & " = " & mStockOnhandField & " - " & mTotalGoodAmou & ", " & mLastSaleField & " = '" & MDYStr(pServerDateTime.Date) & "' WHERE goodCode = '" & mGoodCode & "'"
        mLine += 1
        ' Front card
        mSqlText(mLine) = "Insert into FrontCard (stockDate, stockTime, workType, branchCode, docNumb, emplName, goodCode, goodAmou, stockOnhand) Values ('" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', 'SAL', '" & pBranchCode & "', '" & mSaleNumb & "', '" & Mid(mEmplName, 1, 10) & "', '" & mGoodCode & "', " & mTotalGoodAmou & ", " & mStockAfterSale & ")" '(mStockOnhand - mTotalGoodAmou) & ")"
        mLine += 1
      End If
      ' เก็บประวัติการได้ส่วนลดโปร.สินค้า
      If dtgSale.Item("goodProNumb", row.Index).Value.ToString <> "" Then
        mSqlText(mLine) = "Insert into HistGetPro (getDate, goodProNumb, saleNumb, goodCode, goodAmou, discAmou, branchCode) values ('" & MDYStr(pServerDateTime.Date) & "', '" & dtgSale.Item("goodProNumb", row.Index).Value.ToString & "', '" & mSaleNumb & "', '" & mGoodCode & "', " & CInt(dtgSale.Item("saleAmou", row.Index).Value) & ", " & CSng(dtgSale.Item("subProDisc", row.Index).Value) & ", '" & pBranchCode & "')"
        mLine += 1
      End If
      '###############
      ' เก็บข้อมูลการใช้สิทธิ์แลกซื้อ ถ้ามีการใช้สิทธิ์ เฉพาะสาขาที่เปิดระบบสิทธิ์แลกซื้อ
      If pAllowBuyExchange = "1" Then
        If dtgSale.Item("bxCode", row.Index).Value.ToString <> "" And dtgSale.Item("bxCode", row.Index).Value.ToString <> "มีสิทธิ์แลกซื้อ" Then
          ' อัพเดตการใช้
          mSqlText(mLine) = "Update BuyExchangeInfo set useSaleNumb = '" & mSaleNumb & "', useDate = '" & MDYStr(pServerDateTime.Date) & "', useBranchCode = '" & pBranchCode & "', bxStat = '2' Where bxCode = '" & dtgSale.Item("bxCode", row.Index).Value.ToString & "'"
          mLine += 1
          ' เก็บรายการสินค้าที่ใช้แลกซื้อ
          mSqlText(mLine) = "Insert into BuyExchangeList (bxCode, goodCode, goodPrice, discAmou, goodAmou, unitCode) values ('" & dtgSale.Item("bxCode", row.Index).Value.ToString & "', '" & mGoodCode & "', " & (CInt(dtgSale.Item("saleAmou", row.Index).Value) * CDbl(dtgSale.Item("unitPrice", row.Index).Value)) & ", " & CDbl(dtgSale.Item("bxDisc", row.Index).Value) & ", " & CInt(dtgSale.Item("saleAmou", row.Index).Value) & ", '" & dtgSale.Item("unitCode", row.Index).Value.ToString & "')"
          mLine += 1
        End If
      End If
      '###############
    Next
    ' $$$$$$$$$$$$$$$$
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
    ' $$$$$$$$$$$$$$$$

    ' เฉพาะลูกค้าที่เป็นสมาชิก HUG Club 6 ให้อัพเดตข้อมูลที่เกี่ยวข้อง
    If mVIP = True Then 'mCustType = "6" Then
      mSqlText(mLine) = "Insert into HistSalePro (saleNumb, saleDate, thisPoint, usePoint, remainPoint, selectPro) Values ('" & mSaleNumb & "', '" & MDYStr(pServerDateTime.Date) & "', " & mThisPoint & ", " & mUsePoint & ", " & mRemainPoint & ", '')"
      mLine = mLine + 1

      ' update แต้มลูกค้า
      mSqlText(mLine) = "Update CustInfo set hugPoint = hugPoint + " & mThisPoint - mUsePoint & ", totalBuy = totalBuy + " & mTotalPrice & ", totalSlip = totalSlip + 1 Where custCode = '" & txtCustCode.Text & "'"
      mLine = mLine + 1
      ' มีการใช้แต้มพิเศษ ? เท่าในเดือนเกิด ให้บันทึกปีไว้ เพื่อใช้ตรวจสอบว่าปีนี้ใช้สิทธิแล้ว
      If mBirthPointPlus > 1 Then
        mSqlText(mLine) = "Update CustInfo set birthProYear = " & pServerDateTime.Date.Year & " Where custCode = '" & txtCustCode.Text & "'"
        mLine = mLine + 1
      End If
    Else
      ' เฉพาะลูกค้าออนไลน์
      If mCustType = "8" Then
        mSqlText(mLine) = "Update CustInfo set totalBuy = totalBuy + " & mTotalPrice & ", totalSlip = totalSlip + 1 Where custCode = '" & txtCustCode.Text & "'"
        mLine = mLine + 1
      End If
    End If

    ' อัพเดตพนักงานซื้อสวัสดิการที่ได้สิทธิซื้อเกินวงเงิน (ถ้าได้สิทธิ) พร้อมเปลี่ยนสถานะ เพื่อให้สามารถซื้อเกินได้เพียงครั้งเดียว
    If mAllowOverBuyLimit = True Then
      mSqlText(mLine) = "Update OverLimitList set totalBuy = " & (mTotalThisMonthBuy + mTotalPriceNet) & ", buyDate = '" & MDYStr(pServerDateTime.Date) & "', overStat = '0' where custCode = '" & txtCustCode.Text & "' and totalBuy = 0"
      mLine += 1
    End If

    '################
    ' สิทธิ์แลกซื้อ
    ' เช็คได้สิทธิ์ (เฉพาะสาขาที่เปิดระบบสิทธิ์แลกซื้อ)
    If pAllowBuyExchange = "1" And pPricePerOneBuyExchange > 0 Then
      mBxAmou = Math.Floor(mTotalPrice / pPricePerOneBuyExchange) ' จำนวนสิทธิ์ที่ได้ จากยอดซื้อต่อหนึ่งสิทธิ์
      ' สร้างรหัสสิทธิ์ 1 รหัสต่อจำนวนสิทธิ์ทั้งหมด
      If mBxAmou > 0 Then
        ' สร้างรหัสสิทธิ์ 10 หลัก
        Dim mRandom As Random = New Random
        Dim mNum As Integer
        Dim mGet() As String
        ' วนลูปจนกว่าจะได้รหัสสิทธิ์ที่ไม่ซ้ำ
        Do
          mBxCode = ""
          For i As Integer = 1 To 10
            mNum = mRandom.Next(1, 10)
            mBxCode = mBxCode & mNum.ToString
          Next
          ' ตรวจสอบรหัสสิทธิ์ซ้ำ
          mGet = pService.GetData("Drug", "Select bxCode from BuyExchangeInfo where bxCode = '" & mBxCode & "'")
          If mGet(0) <> "1" Then
            Exit Do
          End If
        Loop

        mExExpireDate = pServerDateTime.Date.AddDays(pDayUseBuyExchange)
        ' เก็บรหัสสิทธิ์ไว้ในฐานข้อมูล
        mSqlText(mLine) = "Insert into BuyExchangeInfo (bxCode, bxAmou, issueDate, expireDate, issueSaleNumb, useSaleNumb, bxStat) values ('" & mBxCode & "', " & mBxAmou & ", '" & MDYStr(pServerDateTime.Date) & "', '" & MDYStr(mExExpireDate) & "', '" & mSaleNumb & "', '', '1')"
        mLine += 1

      End If
    End If
    '################

    Application.DoEvents()

    Dim retValue As String
    Try
      retValue = pService.UpdateData("Drug", mSqlText)
    Catch ex As Exception
      pMessageBox = New MyMessageBox(ex.Message, "บันทึกข้อมูลไม่สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
      pMessageBox.ShowDialog()
      Me.Cursor = Cursors.Default
      Exit Sub
    End Try

    If retValue = "1" Then
      ' เปิดลิ้นชักเก็บเงิน
      OpenCashDrawer(pPrinterPort)
      ' พิมพ์ใบเสร็จ เฉพาะสาขาที่กำหนดให้พิมพ์ได้
      If pBillPrint = "1" Then
        If pAllowTaxInvoice = "0" Then
          ' พิมพ์ใบเสร็จระบบเดิม
          pdcSaleBill.Print()
        Else
          ' พิมพ์ใบเสร็จ/ใบกำกับภาษีอย่างย่อ
          pdcAbbBillVat.Print()
        End If
      End If
      ' แสดงเงินทอน
      Dim fReturn As New frmCashChange
      fReturn.pReturn = mTotalChange
      fReturn.ShowDialog()

      ' @@@@@@@@@@@@@@@@@@@@@@@@
      ' ลูกค้าทั่วไป เช็คโปรสิทธิ์สมัครสมาชิกฟรี
      If mCustType = "1" And mProFreeMember = "1" And mTotalPrice >= mProFreeMemberBuyPrice Then
        pMessageBox = New MyMessageBox("ท่านได้รับสิทธิ์ สมัครสมาชิกฟรี" & vbCrLf & "ยืนยันสมัครสมาชิก", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If pMessageBox.ShowDialog = Windows.Forms.DialogResult.Yes Then
          frmMemberInfo.pIsNewMemb = True
          frmMemberInfo.pFreeMember = True
          frmMemberInfo.ShowDialog()
          If frmMemberInfo.pOk = True Then
            Dim mCmdText(3) As String
            ' เพิ่มรายการสมัครสมาชิกต่อท้ายรายการซื้อ โดยค่าสมัคร = 0
            mCmdText(0) = "INSERT INTO SaleList (saleNumb, barCode, goodCode, goodAmou, unitCode, unitPrice, unitCost, subDisc)VALUES ('" & mSaleNumb & "', '066', '11755', 1, '13', 0, 0, 0)"

            ' เปลี่ยนรหัสลูกค้าจากทั่วไปเป็นรหัสสมาชิกที่สมัครใหม่
            mCmdText(1) = "Update HistSale set custCode = '" & frmMemberInfo.pNewMembCode & "', custType = '" & frmMemberInfo.pCustTypeCode & "' where saleNumb = '" & mSaleNumb & "'"

            mCmdText(2) = "Update CustInfo set totalBuy = totalBuy + " & mTotalPrice & " Where custCode = '" & frmMemberInfo.pNewMembCode & "'"

            Dim mUpdate As String
            mUpdate = pService.UpdateData("Drug", mCmdText)
            If mUpdate = "1" Then
              pMessageBox = New MyMessageBox("หมายเลขสมาชิก : " & frmMemberInfo.pNewMembCode, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
              pMessageBox.ShowDialog()
            Else
              MessageBox.Show("ไม่สามารถเพิ่มรายการสมัครสมาชิกฟรีได้" & vbCrLf & mUpdate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
          End If
          frmMemberInfo = Nothing
        End If
      End If
      ' @@@@@@@@@@@@@@@@@@@@@@@@

      Call ClearAll()
      txtCustCode.Focus()
    Else
      pMessageBox = New MyMessageBox(retValue, "บันทึกข้อมูลไม่สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
      pMessageBox.ShowDialog()
    End If
    Me.Cursor = Cursors.Default
  End Sub


  'Private Sub SaveData()
  '  If dtgSale.Rows.Count <= 0 Then
  '    pMessageBox = New MyMessageBox("ไม่มีรายการขายสินค้า ไม่สามารถดำเนินการบันทึกการขายได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
  '    pMessageBox.ShowDialog()
  '    'MessageBox.Show("ไม่มีรายการขายสินค้า ไม่สามารถดำเนินการบันทึกการขายได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
  '    Exit Sub
  '  End If

  '  Dim mStockOnhandField, mLastSaleField As String
  '  mStockOnhandField = "stockOnhand" & pBranchCode
  '  mLastSaleField = "lastSale" & pBranchCode

  '  Dim mSqlText((dtgSale.Rows.Count * 6) + 15) As String
  '  Dim mLine As Integer = 0

  '  If txtCustCode.Text = "" Then txtCustCode.Text = "0"

  '  mSqlText(mLine) = "INSERT INTO HistSale (saleNumb, saleDate, saleTime, branchCode, custCode, emplCode, cashCode, totalPrice, totalDisc, totalCost, totalPay, totalCash, totalCredit, totalDebt, totalCupong, perCharge, payType, creditNumb, saleStat, creditCode, custType, saleRema, pointDisc, salePriceType)VALUES ('" & mSaleNumb & "', '" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', '" & pBranchCode & "', '" & txtCustCode.Text & "', '" & mEmplCode & "', '" & pUserCode & "', " & mTotalPrice & ", " & mTotalDisc & ", " & mTotalCost & ", " & mTotalCashPay & ", " & mTotalCash & ", " & mTotalCredit & ", " & mTotalDebt & ", " & mTotalCupong & ", " & mPerCharge & ", '" & mPayType & "', '" & mCreditNumb & "', '1', '" & mCreditCode & "', '" & mCustType & "', '" & txtSaleRema.Text & "', " & mPointDisc & ", '" & mSalePriceType & "')"
  '  mLine += 1

  '  mSqlText(mLine) = "UPDATE BranchInfo set saleNumb = saleNumb + 1 WHERE branchCode = '" & pBranchCode & "'"
  '  mLine += 1

  '  'Dim dsGoodStock As New DataSet
  '  Dim mBarCode As String
  '  Dim mGoodCode As String
  '  Dim mTotalGoodAmou As Integer
  '  Dim mStockOnhand As Integer
  '  Dim mStockAfterSale As Integer
  '  Dim mNoBranchStock As String

  '  For Each row As DataGridViewRow In dtgSale.Rows
  '    mBarCode = dtgSale.Item("barCode", row.Index).Value.ToString
  '    mGoodCode = dtgSale.Item("goodCode", row.Index).Value.ToString
  '    mNoBranchStock = dtgSale.Item("noBranchStock", row.Index).Value
  '    mStockOnhand = dtgSale.Item("stockOnhand", row.Index).Value
  '    mStockAfterSale = dtgSale.Item("stockAfterSale", row.Index).Value
  '    mTotalGoodAmou = CInt(dtgSale.Item("saleAmou", row.Index).Value) * CInt(dtgSale.Item("unitFactor", row.Index).Value)

  '    mSqlText(mLine) = "INSERT INTO SaleList (saleNumb, barCode, goodCode, goodAmou, unitCode, unitPrice, unitCost, subDisc)VALUES ('" & mSaleNumb & "', '" & mBarCode & "', '" & mGoodCode & "', " & CInt(dtgSale.Item("saleAmou", row.Index).Value) & ", '" & dtgSale.Item("unitCode", row.Index).Value.ToString & "', " & CSng(dtgSale.Item("unitPrice", row.Index).Value) & ", " & CSng(dtgSale.Item("unitCost", row.Index).Value) & ", " & CSng(dtgSale.Item("subDisc", row.Index).Value) & ")"
  '    mLine += 1
  '    ' ตัดสต๊อครวม ยกเว้นสินค้าที่ไม่เก็บสต๊อคสาขา
  '    If mNoBranchStock = "0" Then
  '      mSqlText(mLine) = "UPDATE GoodInfo set " & mStockOnhandField & " = " & mStockOnhandField & " - " & mTotalGoodAmou & ", " & mLastSaleField & " = '" & MDYStr(pServerDateTime.Date) & "' WHERE goodCode = '" & mGoodCode & "'"
  '      mLine += 1
  '      ' Front card
  '      mSqlText(mLine) = "Insert into FrontCard (stockDate, stockTime, workType, branchCode, docNumb, emplName, goodCode, goodAmou, stockOnhand) Values ('" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', 'SAL', '" & pBranchCode & "', '" & mSaleNumb & "', '" & Mid(mEmplName, 1, 10) & "', '" & mGoodCode & "', " & mTotalGoodAmou & ", " & mStockAfterSale & ")" '(mStockOnhand - mTotalGoodAmou) & ")"
  '      mLine += 1
  '    End If
  '    ' เก็บประวัติการได้ส่วนลดโปร.สินค้า
  '    If dtgSale.Item("goodProNumb", row.Index).Value.ToString <> "" Then
  '      mSqlText(mLine) = "Insert into HistGetPro (getDate, goodProNumb, saleNumb, goodCode, goodAmou, discAmou, branchCode) values ('" & MDYStr(pServerDateTime.Date) & "', '" & dtgSale.Item("goodProNumb", row.Index).Value.ToString & "', '" & mSaleNumb & "', '" & mGoodCode & "', " & CInt(dtgSale.Item("saleAmou", row.Index).Value) & ", " & CSng(dtgSale.Item("subProDisc", row.Index).Value) & ", '" & pBranchCode & "')"
  '      mLine += 1
  '    End If
  '    '###############
  '    ' เก็บข้อมูลการใช้สิทธิ์แลกซื้อ ถ้ามีการใช้สิทธิ์ เฉพาะสาขาที่เปิดระบบสิทธิ์แลกซื้อ
  '    If pAllowBuyExchange = "1" Then
  '      If dtgSale.Item("bxCode", row.Index).Value.ToString <> "" And dtgSale.Item("bxCode", row.Index).Value.ToString <> "มีสิทธิ์แลกซื้อ" Then
  '        ' อัพเดตการใช้
  '        mSqlText(mLine) = "Update BuyExchangeInfo set useSaleNumb = '" & mSaleNumb & "', useDate = '" & MDYStr(pServerDateTime.Date) & "', useBranchCode = '" & pBranchCode & "', bxStat = '2' Where bxCode = '" & dtgSale.Item("bxCode", row.Index).Value.ToString & "'"
  '        mLine += 1
  '        ' เก็บรายการสินค้าที่ใช้แลกซื้อ
  '        mSqlText(mLine) = "Insert into BuyExchangeList (bxCode, goodCode, goodPrice, discAmou, goodAmou, unitCode) values ('" & dtgSale.Item("bxCode", row.Index).Value.ToString & "', '" & mGoodCode & "', " & (CInt(dtgSale.Item("saleAmou", row.Index).Value) * CDbl(dtgSale.Item("unitPrice", row.Index).Value)) & ", " & CDbl(dtgSale.Item("bxDisc", row.Index).Value) & ", " & CInt(dtgSale.Item("saleAmou", row.Index).Value) & ", '" & dtgSale.Item("unitCode", row.Index).Value.ToString & "')"
  '        mLine += 1
  '      End If
  '    End If
  '    '###############
  '  Next

  '  ' เฉพาะลูกค้าที่เป็นสมาชิก HUG Club 6 ให้อัพเดตข้อมูลที่เกี่ยวข้อง
  '  If mVIP = True Then 'mCustType = "6" Then
  '    mSqlText(mLine) = "Insert into HistSalePro (saleNumb, saleDate, thisPoint, usePoint, remainPoint, selectPro) Values ('" & mSaleNumb & "', '" & MDYStr(pServerDateTime.Date) & "', " & mThisPoint & ", " & mUsePoint & ", " & mRemainPoint & ", '')"
  '    mLine = mLine + 1

  '    ' update แต้มลูกค้า
  '    mSqlText(mLine) = "Update CustInfo set hugPoint = hugPoint + " & mThisPoint - mUsePoint & ", totalBuy = totalBuy + " & mTotalPrice & ", totalSlip = totalSlip + 1 Where custCode = '" & txtCustCode.Text & "'"
  '    mLine = mLine + 1
  '    ' มีการใช้แต้มพิเศษ ? เท่าในเดือนเกิด ให้บันทึกปีไว้ เพื่อใช้ตรวจสอบว่าปีนี้ใช้สิทธิแล้ว
  '    If mBirthPointPlus > 1 Then
  '      mSqlText(mLine) = "Update CustInfo set birthProYear = " & pServerDateTime.Date.Year & " Where custCode = '" & txtCustCode.Text & "'"
  '      mLine = mLine + 1
  '    End If
  '  Else
  '    ' เฉพาะลูกค้าออนไลน์
  '    If mCustType = "8" Then
  '      mSqlText(mLine) = "Update CustInfo set totalBuy = totalBuy + " & mTotalPrice & ", totalSlip = totalSlip + 1 Where custCode = '" & txtCustCode.Text & "'"
  '      mLine = mLine + 1
  '    End If
  '  End If

  '  ' อัพเดตพนักงานซื้อสวัสดิการที่ได้สิทธิซื้อเกินวงเงิน (ถ้าได้สิทธิ) พร้อมเปลี่ยนสถานะ เพื่อให้สามารถซื้อเกินได้เพียงครั้งเดียว
  '  If mAllowOverBuyLimit = True Then
  '    mSqlText(mLine) = "Update OverLimitList set totalBuy = " & (mTotalThisMonthBuy + mTotalPriceNet) & ", buyDate = '" & MDYStr(pServerDateTime.Date) & "', overStat = '0' where custCode = '" & txtCustCode.Text & "' and totalBuy = 0"
  '    mLine += 1
  '  End If

  '  '################
  '  ' สิทธิ์แลกซื้อ
  '  ' เช็คได้สิทธิ์ (เฉพาะสาขาที่เปิดระบบสิทธิ์แลกซื้อ)
  '  If pAllowBuyExchange = "1" And pPricePerOneBuyExchange > 0 Then
  '    mBxAmou = Math.Floor(mTotalPrice / pPricePerOneBuyExchange) ' จำนวนสิทธิ์ที่ได้ จากยอดซื้อต่อหนึ่งสิทธิ์
  '    ' สร้างรหัสสิทธิ์ 1 รหัสต่อจำนวนสิทธิ์ทั้งหมด
  '    If mBxAmou > 0 Then
  '      ' สร้างรหัสสิทธิ์ 10 หลัก
  '      Dim mRandom As Random = New Random
  '      Dim mNum As Integer
  '      Dim mGet() As String
  '      ' วนลูปจนกว่าจะได้รหัสสิทธิ์ที่ไม่ซ้ำ
  '      Do
  '        mBxCode = ""
  '        For i As Integer = 1 To 10
  '          mNum = mRandom.Next(1, 10)
  '          mBxCode = mBxCode & mNum.ToString
  '        Next
  '        ' ตรวจสอบรหัสสิทธิ์ซ้ำ
  '        mGet = pService.GetData("Drug", "Select bxCode from BuyExchangeInfo where bxCode = '" & mBxCode & "'")
  '        If mGet(0) <> "1" Then
  '          Exit Do
  '        End If
  '      Loop

  '      mExExpireDate = pServerDateTime.Date.AddDays(pDayUseBuyExchange)
  '      ' เก็บรหัสสิทธิ์ไว้ในฐานข้อมูล
  '      mSqlText(mLine) = "Insert into BuyExchangeInfo (bxCode, bxAmou, issueDate, expireDate, issueSaleNumb, useSaleNumb, bxStat) values ('" & mBxCode & "', " & mBxAmou & ", '" & MDYStr(pServerDateTime.Date) & "', '" & MDYStr(mExExpireDate) & "', '" & mSaleNumb & "', '', '1')"
  '      mLine += 1

  '    End If
  '  End If
  '  '################

  '  Application.DoEvents()

  '  Dim retValue As String
  '  Try
  '    Me.Cursor = Cursors.WaitCursor
  '    retValue = pService.UpdateData("Drug", mSqlText)
  '    Me.Cursor = Cursors.Default
  '  Catch ex As Exception
  '    pMessageBox = New MyMessageBox("บันทึกข้อมูลไม่สำเร็จ กรุณาลองใหม่อีกครั้ง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
  '    pMessageBox.ShowDialog()
  '    Me.Cursor = Cursors.Default
  '    pnlChange.Visible = False
  '    sctMain.Enabled = True
  '    ToolStrip1.Enabled = True
  '    Exit Sub
  '  End Try

  '  If retValue = "1" Then
  '    ' สาขาที่เปิดระบบสิทธิ์แลกซื้อแล้ว ให้กลับไปใช้วิธีบันทึกแบบเดิม คือบันทึกข้อมูลก่อน แล้วเปิดลิ้นชักและพิมพ์ใบเสร็จ
  '    If pAllowBuyExchange = "1" Then
  '      ' เปิดลิ้นชักเก็บเงิน
  '      OpenCashDrawer(pPrinterPort)
  '      ' พิมพ์ใบเสร็จ เฉพาะสาขาที่กำหนดให้พิมพ์ได้
  '      If pBillPrint = "1" Then
  '        pdc1.Print()
  '      End If
  '      ' แสดงเงินทอน
  '      Dim fReturn As New frmCashChange
  '      fReturn.pReturn = mTotalChange
  '      fReturn.ShowDialog()

  '      Call ClearAll()
  '      txtCustCode.Focus()
  '    Else
  '      lblProcess.Text = "บันทึกข้อมูลสำเร็จ"
  '      lblProcess.ForeColor = Color.Black
  '      mProcessSuccess = True
  '    End If
  '  Else
  '    pMessageBox = New MyMessageBox("บันทึกข้อมูลไม่สำเร็จ กรุณาลองใหม่อีกครั้ง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
  '    pMessageBox.ShowDialog()
  '    Me.Cursor = Cursors.Default
  '    pnlChange.Visible = False
  '    sctMain.Enabled = True
  '    ToolStrip1.Enabled = True
  '  End If
  'End Sub

  Private Sub tbnGoodSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnGoodSearch.Click
    frmGoodSearch.ShowDialog()
    If frmGoodSearch.pOk = True Then
      txtBarcode.Focus()
      txtBarcode.Text = frmGoodSearch.pBarcode
      SendKeys.Send("{Enter}")
      'Call ShowGood()
    End If

    'Dim fGoodSearch As New frmGoodSearch
    'fGoodSearch.ShowDialog()
    'If fGoodSearch.pOk = True Then
    '  txtBarcode.Focus()
    '  txtBarcode.Text = fGoodSearch.pBarcode
    '  SendKeys.Send("{Enter}")
    '  'Call ShowGood()
    'End If
    'fGoodSearch = Nothing
  End Sub

  Private Sub txtGoodAmou_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGoodAmou.LostFocus
    If Val(txtGoodAmou.Text) <= 0 Then
      txtGoodAmou.Text = "1"
    End If
  End Sub

  Private Sub tbnCustSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbnCustSearch.Click
    frmCustSearch.ShowDialog()
    If frmCustSearch.pOk = True Then
      txtCustCode.Text = frmCustSearch.pCustCode
      Call ShowCust(txtCustCode.Text)
    End If

    'Dim fCustSearch As New frmCustSearch
    'fCustSearch.ShowDialog()
    'If fCustSearch.pOk = True Then
    '  txtCustCode.Text = fCustSearch.pCustCode
    '  Call ShowCust(txtCustCode.Text)
    'End If
    'fCustSearch = Nothing
  End Sub

  Private Sub tbnTempSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnTempSave.Click
    If dtgSale.Rows.Count > 0 Then
      If dtgTemp.Rows.Count > 0 Then
        pMessageBox = New MyMessageBox("มีรายการพักการขายค้างอยู่ ต้องการแทนที่หรือไม่", "คำเตือน", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If pMessageBox.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
          Exit Sub
        End If
        'If MessageBox.Show("มีรายการพักการขายค้างอยู่ ต้องการแทนที่หรือไม่", "คำเตือน", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then
        '  Exit Sub
        'End If
      End If

      mTempCustCode = txtCustCode.Text
      dtgTemp.Rows.Clear()
      For i As Integer = 0 To dtgSale.Rows.Count - 1
        dtgTemp.Rows.Add()
        dtgTemp.Item("titem", dtgTemp.Rows.Count - 1).Value = dtgSale.Item("goodItem", i).Value
        dtgTemp.Item("tbarCode", dtgTemp.Rows.Count - 1).Value = dtgSale.Item("barCode", i).Value
        dtgTemp.Item("tgoodName", dtgTemp.Rows.Count - 1).Value = dtgSale.Item("goodName", i).Value
        dtgTemp.Item("tsaleAmou", dtgTemp.Rows.Count - 1).Value = dtgSale.Item("saleAmou", i).Value
        dtgTemp.Item("tunitDesc", dtgTemp.Rows.Count - 1).Value = dtgSale.Item("unitDesc", i).Value
        dtgTemp.Item("tunitPrice", dtgTemp.Rows.Count - 1).Value = dtgSale.Item("unitPrice", i).Value
        dtgTemp.Item("tsubDisc", dtgTemp.Rows.Count - 1).Value = dtgSale.Item("subDisc", i).Value
        dtgTemp.Item("tsubTotal", dtgTemp.Rows.Count - 1).Value = dtgSale.Item("subTotal", i).Value
        dtgTemp.Item("tgoodCode", dtgTemp.Rows.Count - 1).Value = dtgSale.Item("goodCode", i).Value
        dtgTemp.Item("tunitCode", dtgTemp.Rows.Count - 1).Value = dtgSale.Item("unitCode", i).Value
        dtgTemp.Item("tunitCost", dtgTemp.Rows.Count - 1).Value = dtgSale.Item("unitCost", i).Value
        dtgTemp.Item("tunitFactor", dtgTemp.Rows.Count - 1).Value = dtgSale.Item("unitFactor", i).Value
      Next

      Call ClearAll()
      txtCustCode.Focus()
      'tbnTempSave.Enabled = False
      'tbnTempCall.Visible = True
      tbnTempCall.Enabled = False
    End If
  End Sub

  Private Sub tbnTempCall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnTempCall.Click
    'If dtgSale.Rows.Count > 0 Then
    '  MessageBox.Show("กรุณาดำเนินการขายให้เสร็จสิ้น ก่อนเรียกรายการพัก", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '  Exit Sub
    'End If

    For i As Integer = 0 To dtgTemp.Rows.Count - 1
      txtBarcode.Text = dtgTemp.Item("tbarCode", i).Value.ToString
      txtGoodAmou.Text = dtgTemp.Item("tsaleAmou", i).Value.ToString
      ShowGood(txtBarcode.Text, CInt(Val(txtGoodAmou.Text)), 0, "")
      'dtgSale.Rows.Add()
      'dtgSale.Item("item", dtgSale.Rows.Count - 1).Value = dtgSale.Rows.Count & "."
      'dtgSale.Item("barCode", dtgSale.Rows.Count - 1).Value = dtgTemp.Item("tbarCode", i).Value
      'dtgSale.Item("goodName", dtgSale.Rows.Count - 1).Value = dtgTemp.Item("tgoodName", i).Value
      'dtgSale.Item("saleAmou", dtgSale.Rows.Count - 1).Value = dtgTemp.Item("tsaleAmou", i).Value
      'dtgSale.Item("unitDesc", dtgSale.Rows.Count - 1).Value = dtgTemp.Item("tunitDesc", i).Value
      'dtgSale.Item("unitPrice", dtgSale.Rows.Count - 1).Value = dtgTemp.Item("tunitPrice", i).Value
      'dtgSale.Item("subDisc", dtgSale.Rows.Count - 1).Value = dtgTemp.Item("tsubDisc", i).Value
      'dtgSale.Item("subTotal", dtgSale.Rows.Count - 1).Value = dtgTemp.Item("tsubTotal", i).Value
      'dtgSale.Item("goodCode", dtgSale.Rows.Count - 1).Value = dtgTemp.Item("tgoodCode", i).Value
      'dtgSale.Item("unitCode", dtgSale.Rows.Count - 1).Value = dtgTemp.Item("tunitCode", i).Value
      'dtgSale.Item("unitCost", dtgSale.Rows.Count - 1).Value = dtgTemp.Item("tunitCost", i).Value
      'dtgSale.Item("unitFactor", dtgSale.Rows.Count - 1).Value = dtgTemp.Item("tunitFactor", i).Value
    Next
    dtgSale.ClearSelection()
    dtgTemp.Rows.Clear()
    Call CalTotal()
    tbnTempCall.Enabled = False
    'tbnTempSave.Visible = True
  End Sub

  Private Sub dtgSale_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgSale.CellEndEdit
    If e.RowIndex >= 0 Then
      Select Case dtgSale.Columns(e.ColumnIndex).Name
        Case "SubDisc" ' ช่องส่วนลด
          Dim mSaleAmou As Integer
          Dim mUnitPrice As Double
          Dim mSubPrice As Double
          Dim mSubDisc As Double
          mSaleAmou = CInt(dtgSale.Item("saleAmou", e.RowIndex).Value)
          mUnitPrice = CDbl(dtgSale.Item("unitPrice", e.RowIndex).Value)
          mSubPrice = mSaleAmou * mUnitPrice
          mSubDisc = CDbl(Val(dtgSale.Item("subDisc", e.RowIndex).Value))
          ' ส่วนลดต้องไม่เกินราคาขาย
          If mSubDisc > mSubPrice Then
            mSubDisc = 0
          End If
          dtgSale.Item("subDisc", e.RowIndex).Value = mSubDisc
          dtgSale.Item("subTotal", e.RowIndex).Value = mSubPrice - mSubDisc
          CalTotal()
          dtgSale.ClearSelection()
          txtBarcode.Focus()
        Case "bxCode" ' ช่องสิทธิ์แลกซื้อ
          ' clear ข้อมูลส่วนลดเดิมก่อน (ถ้ามี)
          dtgSale.Rows(e.RowIndex).Cells("subDisc").Value = CDbl(dtgSale.Rows(e.RowIndex).Cells("subDisc").Value) - CDbl(dtgSale.Rows(e.RowIndex).Cells("bxDisc").Value)
          dtgSale.Rows(e.RowIndex).Cells("subTotal").Value = CDbl(dtgSale.Rows(e.RowIndex).Cells("subTotal").Value) + CDbl(dtgSale.Rows(e.RowIndex).Cells("bxDisc").Value)
          dtgSale.Rows(e.RowIndex).Cells("bxDisc").Value = 0
          CalTotal()

          If IsNothing(dtgSale.Rows(e.RowIndex).Cells("bxCode").Value) = False Then
            Dim mBxCode2 As String
            Dim mBxDisc As Double ' ส่วนลดต่อ 1 สิทธิ
            Dim mBxAmou As Integer ' จำนวนสิทธิแลกซื้อ
            Dim mAmouPerExchange As Integer ' จำนวนสินค้าแลกซื้อได้ต่อ 1 สิทธิ

            mBxCode2 = dtgSale.Rows(e.RowIndex).Cells("bxCode").Value.ToString.Trim
            mBxDisc = 0
            mBxAmou = 0

            If mBxCode2 <> "" Then
              ' เช็ครหัสสิทธิ์
              Dim mSqltext As String
              mSqltext = "Select * from BuyExchangeInfo where bxCode = '" & mBxCode2 & "'"
              Dim ds As New DataSet
              ds = pService.SelectData("Drug", mSqltext)
              If IsNothing(ds) = False Then
                Dim dv As New DataView(ds.Tables(0))
                If dv.Count > 0 Then
                  mBxAmou = CInt(dv.Item(0).Item("bxAmou"))
                  With dv.Item(0)
                    Select Case .Item("bxStat").ToString
                      Case "0"
                        pMessageBox = New MyMessageBox("รหัสนี้ ถูกยกเลิก", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        pMessageBox.ShowDialog()
                        'MessageBox.Show("รหัสนี้ ถูกยกเลิก", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        dtgSale.Rows(e.RowIndex).Cells("bxCode").Value = ""
                        dtgSale.Rows(e.RowIndex).Cells("useBxAmou").Value = 0
                        Exit Sub
                      Case "2"
                        pMessageBox = New MyMessageBox("รหัสนี้ ใช้สิทธิ์แลกซื้อแล้ว [" & .Item("useSaleNumb").ToString & "]", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        pMessageBox.ShowDialog()
                        'MessageBox.Show("รหัสนี้ ใช้สิทธิ์แลกซื้อแล้ว [" & .Item("useSaleNumb").ToString & "]", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        dtgSale.Rows(e.RowIndex).Cells("bxCode").Value = ""
                        dtgSale.Rows(e.RowIndex).Cells("useBxAmou").Value = 0
                        Exit Sub
                    End Select
                  End With
                Else
                  pMessageBox = New MyMessageBox("ไม่มีข้อมูลรหัสสิทธิ์แลกซื้อ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                  pMessageBox.ShowDialog()
                  'MessageBox.Show("ไม่มีข้อมูลรหัสสิทธิ์แลกซื้อ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                  dtgSale.Rows(e.RowIndex).Cells("bxCode").Value = ""
                  dtgSale.Rows(e.RowIndex).Cells("useBxAmou").Value = 0
                  Exit Sub
                End If
                dv = Nothing
              Else
                pMessageBox = New MyMessageBox("Select data error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                pMessageBox.ShowDialog()
                'MessageBox.Show("Select data error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtgSale.Rows(e.RowIndex).Cells("bxCode").Value = ""
                dtgSale.Rows(e.RowIndex).Cells("useBxAmou").Value = 0
                Exit Sub
              End If
              ds = Nothing
              ' เช็คเกินจำนวนสิทธิ์
              Dim mUseBxAmou As Integer = 0
              For Each mRow As DataGridViewRow In dtgSale.Rows
                If dtgSale.Rows(mRow.Index).Cells("bxCode").Value.ToString = mBxCode2 Then
                  mUseBxAmou += dtgSale.Item("useBxAmou", mRow.Index).Value ' 1
                End If
              Next
              If mUseBxAmou >= mBxAmou Then
                pMessageBox = New MyMessageBox("ใช้สิทธิ์เกินจำนวน", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                pMessageBox.ShowDialog()
                'MessageBox.Show("ใช้สิทธิ์เกินจำนวน", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dtgSale.Rows(e.RowIndex).Cells("bxCode").Value = ""
                dtgSale.Rows(e.RowIndex).Cells("useBxAmou").Value = 0
                Exit Sub
              End If

              ' เช็๋คสินค้ามีสิทธิ์แลกซื้อ
              Dim mGoodCode As String
              Dim mSaleAmou As Integer
              mGoodCode = dtgSale.Rows(e.RowIndex).Cells("goodCode").Value.ToString
              mSaleAmou = CInt(dtgSale.Rows(e.RowIndex).Cells("saleAmou").Value)
              pServerDateTime = pService.ServerDateTime

              mSqltext = "Select GE.discAmou, GE.goodAmou from GoodBuyExchange GE inner join GoodInfo GI on GI.goodCode = GE.goodCode inner join UnitInfo UI on UI.unitCode = GI.unitCode Where GE.exchangeStat = '1' and GE.startDate <= '" & MDYStr(pServerDateTime.Date) & "' and GE.endDate >= '" & MDYStr(pServerDateTime.Date) & "' and GE.goodCode = '" & mGoodCode & "' and GE.goodAmou <= " & mSaleAmou

              Dim mGet() As String
              Dim mTotalDisc As Double = 0
              Dim mAmouCanChange As Integer
              mGet = pService.GetData("Drug", mSqltext)
              If mGet(0) = "1" Then
                mBxDisc = CDbl(mGet(1))
                mAmouPerExchange = mGet(2)
                ' จำนวนสิทธิที่ได้
                mAmouCanChange = mSaleAmou / mAmouPerExchange
                ' ใช้สิทธิได้ไม่เกินสิทธิที่เหลือ
                If mAmouCanChange > (mBxAmou - mUseBxAmou) Then
                  mAmouCanChange = (mBxAmou - mUseBxAmou)
                End If
                mTotalDisc = mAmouCanChange * mBxDisc
                ' ส่วนลดมากกว่ายอดซื้อ
                If mTotalDisc > dtgSale.Rows(e.RowIndex).Cells("subTotal").Value Then
                  pMessageBox = New MyMessageBox("ส่วนลดมากกว่ายอดซื้อ ไม่สามารถใช้สิทธิ์ได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                  pMessageBox.ShowDialog()
                  dtgSale.Rows(e.RowIndex).Cells("bxCode").Value = ""
                  dtgSale.Rows(e.RowIndex).Cells("bxDisc").Value = 0
                  dtgSale.Rows(e.RowIndex).Cells("useBxAmou").Value = 0
                  Exit Sub
                End If

                dtgSale.Rows(e.RowIndex).Cells("useBxAmou").Value = mAmouCanChange
                dtgSale.Rows(e.RowIndex).Cells("bxDisc").Value = mTotalDisc
                dtgSale.Rows(e.RowIndex).Cells("subDisc").Value = CDbl(dtgSale.Rows(e.RowIndex).Cells("subDisc").Value) + mTotalDisc
                dtgSale.Rows(e.RowIndex).Cells("subTotal").Value = CDbl(dtgSale.Rows(e.RowIndex).Cells("subTotal").Value) - mTotalDisc
                CalTotal()
              Else
                pMessageBox = New MyMessageBox("สินค้าไม่มีสิทธิ์แลกซื้อ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                pMessageBox.ShowDialog()
                dtgSale.Rows(e.RowIndex).Cells("bxCode").Value = ""
                dtgSale.Rows(e.RowIndex).Cells("useBxAmou").Value = 0
                CalTotal()
                Exit Sub
              End If
            End If
          Else
            dtgSale.Rows(e.RowIndex).Cells("bxCode").Value = ""
            dtgSale.Rows(e.RowIndex).Cells("useBxAmou").Value = 0
            CalTotal()
            Exit Sub
          End If
      End Select
    End If
  End Sub

  Private Sub dtgSale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgSale.KeyDown
    If dtgSale.Rows.Count > 0 Then
      Select Case e.KeyCode
        Case Keys.Delete
          Dim mCurrentRow As Integer
          Dim mCurrGoodCode As String
          Dim mCurrProPoint As Integer
          Dim mCurrCompCode As String
          Dim mCurrProFlag As String

          mCurrentRow = dtgSale.CurrentRow.Index

          mCurrProFlag = dtgSale.Item("proFlag", mCurrentRow).Value.ToString
          ' ถ้าเป็นรายการที่ได้โปร.บริษัท ไม่อนุญาตให้ลบรายการ ต้องทำการยกเลิกใบขายทั้งใบแทน
          If mCurrProFlag <> "" Then
            pMessageBox = New MyMessageBox("ไม่สามารถลบรายการที่ได้คำนวณโปรโมชั่นสินค้าบริษัทไปแล้วได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            pMessageBox.ShowDialog()
            'MessageBox.Show("ไม่สามารถลบรายการที่ได้คำนวณโปรโมชั่นสินค้าบริษัทไปแล้วได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
          End If

          '' ใช้วันที่และเวลาของ server
          'pServerDateTime = pService.ServerDateTime

          '' เก็บรายการที่ถูกลบออก
          'Dim mSqlText(1) As String
          'mSqlText(0) = "INSERT INTO HistSaleCancel (cancelDate, cancelTime, goodCode, goodAmou, unitCode, unitPrice, emplCode, branchCode) VALUES ('" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', '" & dtgSale.Item("goodCode", mCurrentRow).Value.ToString & "', " & CInt(dtgSale.Item("saleAmou", mCurrentRow).Value) & ", '" & dtgSale.Item("unitCode", mCurrentRow).Value.ToString & "', " & CDbl(dtgSale.Item("unitPrice", mCurrentRow).Value) & ", '" & pUserCode & "', '" & pBranchCode & "')"
          'Dim retValue As String
          'retValue = pService.UpdateData("Drug", mSqlText)
          'If retValue <> "1" Then
          '  MessageBox.Show(retValue, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
          'End If

          ' เก็บข้อมูลที่สำคัญก่อนลบรายการ
          mCurrGoodCode = dtgSale.Item("goodCode", mCurrentRow).Value.ToString
          mCurrProPoint = CInt(dtgSale.Item("proPoint", mCurrentRow).Value)
          mCurrCompCode = dtgSale.Item("compCode", mCurrentRow).Value.ToString

          ' ลบรายการ
          dtgSale.Rows.Remove(dtgSale.CurrentRow)

          ' เรียงลำดับรายการใหม่
          For i As Integer = 0 To dtgSale.Rows.Count - 1
            dtgSale.Item("goodItem", i).Value = (i + 1).ToString & "."
            'If dtgSale.Item("flag", i).Value.ToString <> "C" Then
            '  dtgSale.Item("goodItem", i).Value = (i + 1).ToString & "."
            'End If
          Next
          ' reset การใช้แต้ม
          mPointDisc = 0
          mThisPoint = 0
          mUsePoint = 0
          mRemainPoint = mCustPoint

          lblPointDisc.Text = "0.00"
          lblRemainPoint.Text = mRemainPoint.ToString("#,##0")
          ' ลบแต้มรายการที่มีการจับคู่ได้แต้ม
          For Each mRow As DataGridViewRow In dtgSale.Rows
            If dtgSale.Item("goodCode2", mRow.Index).Value.ToString = mCurrGoodCode Then
              dtgSale.Item("hugPoint", mRow.Index).Value = 0
              dtgSale.Item("goodCode2", mRow.Index).Value = ""
              ' เปลี่ยนสีคืน
              If CInt(dtgSale.Item("stockOnhand", mRow.Index).Value) <= 0 OrElse CInt(dtgSale.Item("stockOnhand", mRow.Index).Value) < CInt(dtgSale.Item("saleAmou", mRow.Index).Value) Then
                dtgSale.Rows(mRow.Index).DefaultCellStyle.ForeColor = Color.DarkRed
              Else
                dtgSale.Rows(mRow.Index).DefaultCellStyle.ForeColor = Color.Black
              End If
              Exit For
            End If
          Next

          ' ปรับช่องสต๊อคคงเหลือหลังขาย กรณีที่มีรายการซ้ำ
          Dim mBranchStockOnhand As Integer
          Dim mSaleAmou As Integer
          mBranchStockOnhand = BranchStockOnhand(mCurrGoodCode, pBranchCode)
          For Each mRow As DataGridViewRow In dtgSale.Rows
            If dtgSale.Item("goodCode", mRow.Index).Value = mCurrGoodCode Then
              mSaleAmou = dtgSale.Item("saleAmou", mRow.Index).Value * dtgSale.Item("unitFactor", mRow.Index).Value
              mBranchStockOnhand = mBranchStockOnhand - mSaleAmou
              dtgSale.Item("stockAfterSale", mRow.Index).Value = mBranchStockOnhand
            End If
          Next

          '' ถ้ารายการที่ลบออกนี้ทำให้ได้แต้มจากโปร.บริษัท ให้ clear ค่ารายการอื่นที่เป็นโปร.เดียวกัน
          'If mCurrProFlag = "1" Then
          '  For Each mRow As DataGridViewRow In dtgSale.Rows
          '    If dtgSale.Item("compCode", mRow.Index).Value.ToString = mCurrCompCode AndAlso CInt(dtgSale.Item("proPoint", mRow.Index).Value) = mCurrProPoint Then
          '      dtgSale.Item("hugPoint", mRow.Index).Value = 0
          '      dtgSale.Item("proFlag", mRow.Index).Value = ""
          '      ' เปลี่ยนสีคืน
          '      If CInt(dtgSale.Item("stockOnhand", mRow.Index).Value) <= 0 OrElse CInt(dtgSale.Item("stockOnhand", mRow.Index).Value) < CInt(dtgSale.Item("saleAmou", mRow.Index).Value) Then
          '        dtgSale.Rows(mRow.Index).DefaultCellStyle.ForeColor = Color.DarkRed
          '      Else
          '        dtgSale.Rows(mRow.Index).DefaultCellStyle.ForeColor = Color.Black
          '      End If
          '    End If
          '  Next
          'End If

          Call CalTotal()
      End Select
    End If
  End Sub

  Private Function BranchStockOnhand(ByVal GoodCode As String, ByVal BranchCode As String) As Integer
    Dim mGet() As String
    mGet = pService.GetData("Drug", "Select stockOnhand" & BranchCode & " from GoodInfo where goodCode = '" & GoodCode & "'")
    If mGet(0) = "1" Then
      Return CInt(mGet(1))
    Else
      Return 0
    End If
  End Function

  Private Function NextLineNo() As Integer
    Dim mTotalLine As Integer = 0
    For i As Integer = 0 To dtgSale.Rows.Count - 2 ' ไม่นับบรรทัดสุดท้ายที่เพิ่งเพิ่มใหม่
      If dtgSale.Item("goodItem", i).Value.ToString <> "" Then
        mTotalLine = mTotalLine + 1
      End If
    Next
    Return mTotalLine + 1
  End Function

  Private Sub OpenCashDrawer(ByVal PrinterPort As String)
    Try
      Shell(Application.StartupPath & "\OpenCashDrawer.exe " & PrinterPort, AppWinStyle.Hide)
    Catch ex As Exception

    End Try
  End Sub

  Private Sub dtgSale_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgSale.Leave
    dtgSale.Columns("subDisc").ReadOnly = True
  End Sub

  Private Sub dtgSale_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgSale.LostFocus
    dtgSale.ClearSelection()
  End Sub

  Private Sub dtgSale_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgSale.RowEnter
    If e.RowIndex >= 0 Then
      dtgSale.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = dtgSale.Rows(e.RowIndex).DefaultCellStyle.ForeColor
    End If
  End Sub

  Private Sub dtgPro_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgPro.CellContentClick
    If e.RowIndex < 0 OrElse e.ColumnIndex <> 0 Then
      Exit Sub
    End If

    dtgPro.EndEdit()
    CalTotal()
  End Sub

  Private Sub tbnUsePoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnUsePoint.Click
    If mRemainPoint > 0 AndAlso mTotalPrice > 0 Then 'AndAlso mVIP = True Then
      frmUsePoint.pCustPoint = mRemainPoint
      frmUsePoint.pTotalPriceNet = mTotalPriceNet
      frmUsePoint.ShowDialog()
      If frmUsePoint.pOk = True Then
        mPointDisc = mPointDisc + frmUsePoint.pPointDisc
        mRemainPoint = mRemainPoint - frmUsePoint.pUsePoint
        mUsePoint = mUsePoint + frmUsePoint.pUsePoint
        lblPointDisc.Text = mPointDisc.ToString("#,##0.00")
        lblRemainPoint.Text = mRemainPoint.ToString("#,##0")
        CalTotal()
      End If
    End If
  End Sub

  'Private Sub frmDiarySale_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
  '  pnlChange.Parent = Me
  '  pnlChange.Left = (Me.Width - pnlChange.Width) / 2
  '  pnlChange.Top = (Me.Height - pnlChange.Height) / 2
  'End Sub

  'Private Sub ClearSale()
  '  pnlChange.Visible = False
  '  sctMain.Enabled = True
  '  ToolStrip1.Enabled = True
  '  ClearAll()
  '  txtCustCode.Focus()
  'End Sub

  Private Sub tbnPromotion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnPromotion.Click
    frmPromotion.ShowDialog()
    If frmPromotion.pBarcode <> "" Then
      ShowGood(frmPromotion.pBarcode, CInt(Val(txtGoodAmou.Text)), 0, "")
    End If
    frmPromotion = Nothing
  End Sub

  Private Sub tbnGoodSetList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnGoodSetList.Click
    frmGoodSetList.ShowDialog()
    If frmGoodSetList.pOk = True Then
      Dim ds As New DataSet
      ds = pService.SelectData("Drug", "Select * from GoodSetList where setNumb = " & frmGoodSetList.pSetNumb)
      If IsNothing(ds) = False Then
        Dim dv As New DataView(ds.Tables(0))
        If dv.Count > 0 Then
          Dim mBarcode As String
          Dim mRatioAmou As Integer
          Dim mGoodAmou As Integer
          Dim mSaleAmou As Integer

          mGoodAmou = CInt(Val(txtGoodAmou.Text))

          For i As Integer = 0 To dv.Count - 1
            mBarcode = dv.Item(i).Item("barCode")
            mRatioAmou = dv.Item(i).Item("goodAmou")

            mSaleAmou = mGoodAmou * mRatioAmou

            ShowGood(mBarcode, mSaleAmou, 0, "")
          Next
        End If
        dv = Nothing
      End If
      ds = Nothing
    End If
  End Sub

  Private Sub txtBarcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.TextChanged
    If txtBarcode.Text.Length > 1 Then
      Select Case Mid(txtBarcode.Text, txtBarcode.Text.Length, 1)
        Case "*" ' ถ้าตัวอักษรท้ายเป็น * แสดงว่าป้อนจำนวนสินค้า
          mSaleAmou = CInt(Val(txtBarcode.Text.Substring(0, txtBarcode.Text.Length - 1)))
          If mSaleAmou <= 0 Then mSaleAmou = 1
          txtGoodAmou.Text = mSaleAmou
          txtBarcode.Text = ""
          txtBarcode.Focus()
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

  'Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
  '  ClearSale()
  'End Sub

  'Private Sub tbnUseBuyExchange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnUseBuyExchange.Click
  '  frmUseBuyExchange.ShowDialog()
  '  If frmUseBuyExchange.pOk = True Then
  '    ' ลบรายการที่มีใช้สิทธิ์เดียวกันออกก่อนเพิ่มใหม่
  '    ' ต้องลบจากท้ายรายการไปยังรายการแรก เพื่อหลีกเลี่ยงปัญหา index เลื่อนขึ้น เมื่อใช้วิธีลบจากรายการแรก ซึ่งจะทำให้ลบออกไม่หมด
  '    For i As Integer = dtgSale.Rows.Count - 1 To 0 Step -1
  '      If dtgSale.Item("bxCode", i).Value.ToString = frmUseBuyExchange.pBxCode Then
  '        dtgSale.Rows.RemoveAt(i)
  '      End If
  '    Next

  '    ' เพิ่มรายการขาย จากรายการที่เลือกจากการใช้สิทธิ์แลกซื้อ
  '    Dim mListCount As Integer
  '    mListCount = frmUseBuyExchange.pBarCode.Length - 1
  '    For i As Integer = 0 To mListCount - 1
  '      ShowGood(frmUseBuyExchange.pBarCode(i), frmUseBuyExchange.pGoodAmou(i), frmUseBuyExchange.pDiscAmou(i), frmUseBuyExchange.pBxCode)
  '    Next
  '    ' เรียงลำดับรายการใหม่
  '    For i As Integer = 0 To dtgSale.Rows.Count - 1
  '      dtgSale.Item("goodItem", i).Value = (i + 1).ToString & "."
  '    Next
  '  End If
  '  frmUseBuyExchange = Nothing
  'End Sub

  Private Function CheckBuyExchange(ByVal GoodCode As String, ByVal GoodAmou As Integer) As String
    Dim mSqlText As String
    mSqlText = "Select goodCode from GoodBuyExchange where exchangeStat <> '0' and startDate <= '" & MDYStr(pServerDateTime.Date) & "' and endDate >= '" & MDYStr(pServerDateTime.Date) & "' and goodCode = '" & GoodCode & "' and goodAmou <= " & GoodAmou
    Dim mGet() As String
    mGet = pService.GetData("Drug", mSqlText)
    If mGet(0) = "1" Then
      Return "มีสิทธิ์แลกซื้อ"
    Else
      Return ""
    End If
  End Function

  Private Sub tbnGoodBuyExchangeList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnGoodBuyExchangeList.Click
    frmGoodBuyExchangeList.ShowDialog()
    frmGoodBuyExchangeList = Nothing
  End Sub

  'Private Sub dtgSale_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dtgSale.UserDeletedRow
  '  If MessageBox.Show("ยืนยันลบรายการ " & dtgSale.Item("goodName", e.Row.Index).Value, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
  '    For Each mRow As DataGridViewRow In dtgSale.Rows

  '    Next
  '  End If
  'End Sub

  'Private Function CalProDisc(ByVal GoodCode As String, ByVal SaleAmou As Integer) As Double
  '  Dim mProDisc As Double = 0
  '  Dim mRemainAmou As Integer = 0

  '  Dim ds As New DataSet
  '  Dim mSqlText As String
  '  mSqlText = "Select proName, goodProNumb, extraPoint, goodAmou, goodCode2, discAmou, startDate, endDate From GoodPro Where priceType = '" & mCustPriceType & "' and goodCode = '" & GoodCode & "' And startDate <= '" & MDYStr(pServerDateTime.Date) & "' And endDate >= '" & MDYStr(pServerDateTime.Date) & "' And compCode = '' and ((branchCode = '0' and custTypeCode = '0' and branchPrice = '0') or (branchCode = '0' and custTypeCode = '" & mCustType & "' and branchPrice = '0') or (branchCode = '0' and custTypeCode = '0' and branchPrice = '" & pBranchPrice & "') or (branchCode = '" & pBranchCode & "' and custTypeCode = '0' and branchPrice = '0') or (branchCode = '" & pBranchCode & "' and custTypeCode = '" & mCustType & "' and branchPrice = '" & pBranchPrice & "') or (branchCode = '" & pBranchCode & "' and custTypeCode = '" & mCustType & "' and branchPrice = '0') or (branchCode = '" & pBranchCode & "' and custTypeCode = '0' and branchPrice = '" & pBranchPrice & "') or (branchCode = '0' and custTypeCode = '" & mCustType & "' and branchPrice = '" & pBranchPrice & "')) order by goodAmou desc"

  '  ds = pService.SelectData("Drug", mSqlText)
  '  If IsNothing(ds) = False Then
  '    Dim dv As New DataView(ds.Tables(0))
  '    If dv.Count > 0 Then
  '      For i As Integer = 0 To dv.Count - 1
  '        With dv.Item(i)
  '          If SaleAmou >= .Item("goodAmou") Then
  '            mProDisc = .Item("discAmou")
  '            mRemainAmou = SaleAmou - .Item("goodAmou")
  '            Exit For
  '          End If
  '        End With
  '      Next
  '      If mRemainAmou > 0 Then
  '        mProDisc = mProDisc + CalProDisc(GoodCode, mRemainAmou)
  '      End If
  '    End If
  '    dv = Nothing
  '  End If
  '  ds = Nothing

  '  Return mProDisc
  'End Function

  Private Function CalPromotionDisc(ByVal GoodCode As String, ByVal SaleAmou As Integer, ByVal UnitPrice As Double, ByVal dv As DataView) As Double
    Dim mProDisc As Double = 0
    Dim mRemainAmou As Integer = 0

    For i As Integer = 0 To dv.Count - 1
      With dv.Item(i)
        If SaleAmou >= .Item("goodAmou") Then
          ' หากโปรกำหนดราคาขายตายตัว (fix price) ให้หาส่วนลดจาก fix price 
          ' ฉะนั้นส่วนลดของแต่ละสาขาอาจไม่เท่ากัน แต่ราคาขายจะเท่ากันทุกสาขา ตามราคา fix price
          If .Item("fixPrice") > 0 Then
            mProDisc = (UnitPrice * .Item("goodAmou")) - .Item("fixPrice")
          Else
            mProDisc = .Item("discAmou")
          End If
          mRemainAmou = SaleAmou - .Item("goodAmou")
          Exit For
        End If
      End With
    Next
    If mRemainAmou > 0 Then
      mProDisc = mProDisc + CalPromotionDisc(GoodCode, mRemainAmou, UnitPrice, dv)
    End If

    Return mProDisc
  End Function

  Private Function CheckHavePro(ByVal GoodCode As String, ByVal SaleAmou As Integer, ByVal CustType As String, ByVal CustPriceType As String) As Boolean
    Dim mHavePro As Boolean = False

    'Dim mGet() As String
    'Dim mGoodCode As String

    'mGet = pService.GetData("Drug", "Select top 1 goodCode from GoodBarcode where barCode = '" & BarCode & "'")
    'If mGet(0) = "1" Then
    '  mGoodCode = mGet(1)
    'Else
    '  Return False
    'End If

    pServerDateTime = pService.ServerDateTime

    Dim ds As New DataSet
    Dim mSqlText As String

    mSqlText = "Select goodAmou From GoodPro Where proStat = '1' and priceType = '" & CustPriceType & "' and goodCode = '" & GoodCode & "' And startDate <= '" & MDYStr(pServerDateTime.Date) & "' And endDate >= '" & MDYStr(pServerDateTime.Date) & "' And compCode = '' and ((branchCode = '0' and custTypeCode = '0' and branchPrice = '0') or (branchCode = '0' and custTypeCode = '" & CustType & "' and branchPrice = '0') or (branchCode = '0' and custTypeCode = '0' and branchPrice = '" & pBranchPrice & "') or (branchCode = '" & pBranchCode & "' and custTypeCode = '0' and branchPrice = '0') or (branchCode = '" & pBranchCode & "' and custTypeCode = '" & CustType & "' and branchPrice = '" & pBranchPrice & "') or (branchCode = '" & pBranchCode & "' and custTypeCode = '" & CustType & "' and branchPrice = '0') or (branchCode = '" & pBranchCode & "' and custTypeCode = '0' and branchPrice = '" & pBranchPrice & "') or (branchCode = '0' and custTypeCode = '" & CustType & "' and branchPrice = '" & pBranchPrice & "'))"

    ' ลูกค้าประเภทพนักงาน ให้คิวรี่เฉพาะรายการที่ รวมขายสวัสดิการ ด้วย
    If mCustType = "2" Then
      mSqlText = mSqlText & " and allowEmpl = '1'"
    End If

    ds = pService.SelectData("Drug", mSqlText)

    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        Dim mGoodAmou As Integer
        For i As Integer = 0 To dv.Count - 1
          mGoodAmou = dv.Item(i).Item("goodAmou")
          If mGoodAmou > 0 AndAlso SaleAmou Mod mGoodAmou = 0 Then
            mHavePro = True
            Exit For
          End If
        Next
      End If
    End If
    ds = Nothing

    Return mHavePro
  End Function

  Private Sub pdcSaleBill_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcSaleBill.PrintPage
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
    ' เลขที่ขาย
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "INV-" & mSaleNumb
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' วันที่-เวลา
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = pServerDateTime.ToString("dd'/'MM'/'yy  HH:mm")
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' --------
    mRect = New RectangleF(mLeftMargin, mRowPos + 15, 255.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    Dim mGoodAmou As Integer
    Dim mGoodName As String
    Dim mBarcode As String
    Dim mUnitPrice As Double
    Dim mSubDisc As Double
    Dim mSubTotal As Double
    Dim mUnitDesc As String
    Dim mTotalDisc As Double
    Dim mTotalPrice As Double

    mTotalPrice = 0
    mTotalDisc = 0
    For Each row As DataGridViewRow In dtgSale.Rows
      mGoodName = dtgSale.Item("goodName", row.Index).Value
      mGoodAmou = dtgSale.Item("saleAmou", row.Index).Value
      mBarcode = dtgSale.Item("barCode", row.Index).Value
      mUnitPrice = dtgSale.Item("unitPrice", row.Index).Value
      mSubDisc = dtgSale.Item("subDisc", row.Index).Value
      mUnitDesc = dtgSale.Item("unitDesc", row.Index).Value
      mSubTotal = CLng(mGoodAmou * mUnitPrice)
      mTotalPrice += mSubTotal
      mTotalDisc += mSubDisc
      ' จำนวน
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = mGoodAmou & " " & mUnitDesc
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' ชื่อสินค้า
      mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = mGoodName
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' ราคาขาย
      mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = Format(mSubTotal, "#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' รหัสสินค้า
      mRect = New RectangleF(55, mRowPos + 12, 260.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "[" & mBarcode & "]"
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

      ' แสดงส่วนลดของสินค้าแต่ละตัวที่ได้ลด
      If mSubDisc > 0 Then
        ' จำนวน
        mLineNo = mLineNo + 1
        mRowPos = mLineNo * mLineSpace
        mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "ส่วนลด"
        e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
        ' ชื่อสินค้า
        mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = mGoodName
        e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
        ' ส่วนลด
        mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = Format(-mSubDisc, "#,##0.00")
        e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
        ' รหัสสินค้า
        mRect = New RectangleF(55, mRowPos + 12, 260.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = "[" & mBarcode & "]"
        e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
      End If
    Next
    ' --------
    mRowPos += 20
    'mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 255.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    '' จำนวนรายการ
    'mLineNo = mLineNo + 1
    'mRowPos = mLineNo * mLineSpace
    'mRect = New RectangleF(mLeftMargin, mRowPos, 90.0F, 20.0F)
    'mAlign.Alignment = StringAlignment.Near
    'mText = dtgSaleList.Rows.Count.ToString & " รายการ"
    'e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    ' ยอดสินค้ารวม
    mLineNo = mLineNo + 1
    mRowPos += 20
    'mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(80, mRowPos, 110.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ยอดสินค้ารวม"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = Format(mTotalPrice, "#,##0.00")
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' ส่วนลดรวม
    mLineNo = mLineNo + 1
    mRowPos += 20
    'mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(80, mRowPos, 110.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ส่วนลดรวม"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = Format(mTotalDisc, "#,##0.00")
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    If mPointDisc > 0 Then
      ' แต้มเงินสดที่ใช้
      mLineNo = mLineNo + 1
      mRowPos += 20
      'mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(80, mRowPos, 110.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "ส่วนลดจากการใช้แต้ม"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mPointDisc.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    End If

    ' ยอดชำระสุทธิ
    mLineNo = mLineNo + 1
    mRowPos += 20
    'mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(80, mRowPos, 110.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ยอดชำระสุทธิ"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = mTotalPriceNet.ToString("#,##0.00")
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    ' $$$$$$$$$$$$$$$$$
    For Each mRow As DataGridViewRow In mGridPay.Rows
      If MyVal(mGridPay.Item("payAmou", mRow.Index).Value) > 0 Then
        mLineNo = mLineNo + 1
        mRowPos += 20
        mRect = New RectangleF(90, mRowPos, 110.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = mGridPay.Item("cardName", mRow.Index).Value
        e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

        mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = MyVal(mGridPay.Item("payAmou", mRow.Index).Value).ToString("#,##0.00")
        e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      End If
    Next
    ' $$$$$$$$$$$$$$$$$

    If mTotalCashPay > 0 Then
      ' ชำระด้วยเงินสด
      mLineNo = mLineNo + 1
      mRowPos += 20
      mRect = New RectangleF(80, mRowPos, 110.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "ชำระเงินสด"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotalCashPay.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' เงินทอน
      mLineNo = mLineNo + 1
      mRowPos += 20
      mRect = New RectangleF(80, mRowPos, 110.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "เงินทอน"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotalChange.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    End If
    ' แสดงแต้ม เฉพาะสมาชิก HUG Club ********
    If mCustType = "6" Then
      ' --------
      mRowPos += 20
      mRect = New RectangleF(mLeftMargin, mRowPos, 255.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "-------------------------------------------------------------------"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' รหัสสมาชิก
      mRowPos += 20
      mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "สมาชิก " & lblCustName.Text & " [" & txtCustCode.Text & "]"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' แต้มที่ได้ครั้งนี้
      mRowPos += 20
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "HUG Cash Points (ครั้งนี้)"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' จำนวนแต้ม
      mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = Format(mThisPoint, "#,##0")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' แต้มที่ใช้
      mRowPos += 20
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "HUG Cash Points (ที่ใช้เป็นส่วนลด)"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' จำนวนแต้ม
      mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = Format(mUsePoint, "#,##0")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' แต้มสะสม
      mRowPos += 20
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "HUG Cash Points (สะสม)"
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' จำนวนแต้ม
      mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = Format(mRemainPoint + mThisPoint, "#,##0")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    End If
    ' ***************
    ' --------
    mRowPos += 15
    mRect = New RectangleF(mLeftMargin, mRowPos, 255.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' สิทธิ์แลกซื้อ
    If mBxCode <> "" Then
      mRowPos = mRowPos + 15
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = mBxAmou.ToString & " สิทธิ์แลกซื้อ [" & mBxCode & "]" & " ใช้ได้ถึง " & mExExpireDate.ToString("dd'/'MM'/'yyyy")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    End If
    ' แสดงชื่อ cashier และพนักงาน โดยแสดงเฉพาะชื่อไม่รวมนามสกุล(แยกชื่อ - นามสกุลออกจากกันโดยเช็คช่องว่าง)
    mLineNo = mLineNo + 1
    mRowPos += 20
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "CSHR-" & Mid(pUserName, 1, 15)
    'mText = "CSHR-" & Mid(pUserName, 1, pUserName.LastIndexOf(" "))
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' พนักงาน
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = "EMPL-" & Mid(mEmplName, 1, 15)
    'mText = "EMPL-" & Mid(mEmplName, 1, mEmplName.LastIndexOf(" "))
    'mText = "ขอบคุณที่ใช้บริการ"
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    '' ขอบคุณ
    'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    'mAlign.Alignment = StringAlignment.Far
    'mText = "ขอบคุณที่ใช้บริการ"
    'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

    '' --------
    'mRowPos = mRowPos + 15
    'mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
    'mAlign.Alignment = StringAlignment.Near
    'mText = "-------------------------------------------------------------------"
    'e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' ท้ายเอกสาร 1
    mLineNo = mLineNo + 1
    mRowPos += 25
    'mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "ขอสงวนสิทธิ์ในการรับเปลี่ยน/คืนสินค้า"
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' ท้ายเอกสาร 2
    mLineNo = mLineNo + 1
    mRowPos += 15
    'mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "หากไม่มีใบเสร็จรับเงินมาแสดง"
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  End Sub

  'Private Sub pdc3_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcAbbBillVat.PrintPage
  '  Dim prnFontNormal As New Font("CordiaUPC", 12, GraphicsUnit.Point)
  '  Dim prnFontNormalBold As New Font("CordiaUPC", 12, FontStyle.Bold)
  '  Dim prnFontSmall As New Font("CordiaUPC", 10, GraphicsUnit.Point)
  '  Dim prnFontSmallBold As New Font("CordiaUPC", 10, FontStyle.Bold)
  '  Dim prnFontVerySmall As New Font("CordiaUPC", 8, GraphicsUnit.Point)
  '  Dim prnFontBigBold As New Font("CordiaUPC", 14, FontStyle.Bold)

  '  Dim mRowPos As Single
  '  Dim mLeftMargin As Single = 5.0F
  '  Dim mCol2Pos As Single = 70.0F
  '  Dim mCol3Pos As Single = 260.0F

  '  Dim mLineNo As Integer
  '  Dim mLineSpace As Integer = 30
  '  Dim mLineSpace15 As Integer = 15
  '  Dim mLineSpace10 As Integer = 10
  '  Dim mRect As RectangleF
  '  Dim mAlign As New StringFormat()
  '  Dim mText As String

  '  ' ใบกำกับภาษีอย่างย่อ

  '  ' ชื่อบริษัท
  '  mLineNo = mLineNo + 1
  '  mRowPos = mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Center
  '  'mText = pHugName & " (สำนักงานใหญ่)"
  '  mText = pHugName
  '  e.Graphics.DrawString(mText, prnFontBigBold, Brushes.Black, mRect, mAlign)
  '  '' ที่อยู่บริษัท
  '  '' ใช้ฟังชั่นตัดคำ เพื่อแยกข้อความออกเป็นบรรทัด ตามความยาวที่กำหนด เพื่อให้พิมพ์ออกมาได้ทุกบรรทัด ไม่ตกขอบกระดาษ
  '  'mAddrText = WrapText(pCompAddress, 50)
  '  'For x As Integer = 0 To mAddrText.Count - 1
  '  '  mLineNo = mLineNo + 1
  '  '  mRowPos += 15
  '  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245, 20)
  '  '  mAlign.Alignment = StringAlignment.Center
  '  '  mText = mAddrText(x)
  '  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  'Next
  '  ' เลขประจำตัวผู้เสียภาษี
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Center
  '  mText = "TAX#" & pHugTaxNumber
  '  e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
  '  '' สาขาที่ออกใบกำกับภาษี
  '  'mLineNo = mLineNo + 1
  '  'mRowPos += mLineSpace15
  '  'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  'mAlign.Alignment = StringAlignment.Center
  '  'mText = "สาขาที่ออกใบกำกับภาษี"
  '  'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  ' ชื่อสาขา
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Center
  '  'mText = "สาขาที่ออกใบกำกับภาษี " & pTaxBranchNo
  '  mText = "สาขา " & pTaxBranchNo
  '  e.Graphics.DrawString(mText, prnFontSmallBold, Brushes.Black, mRect, mAlign)
  '  ' เลข POS
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Center
  '  mText = "POS#" & pPOSNumber
  '  e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
  '  '' เลขสาขา, POS
  '  'mLineNo = mLineNo + 1
  '  'mRowPos += mLineSpace15
  '  'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  'mAlign.Alignment = StringAlignment.Center
  '  'mText = "เลขสาขา:" & pTaxBranchNo & "   POS#" & pTaxBranchPOS
  '  'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '  ' หัวเอกสาร
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Center
  '  mText = "ใบเสร็จรับเงิน/ใบกำกับภาษีอย่างย่อ(ABB.)"
  '  e.Graphics.DrawString(mText, prnFontSmallBold, Brushes.Black, mRect, mAlign)
  '  '' หัวเอกสาร อังกฤษ
  '  'mLineNo = mLineNo + 1
  '  'mRowPos += mLineSpace15
  '  'mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  'mAlign.Alignment = StringAlignment.Center
  '  'mText = "RECEIPT / TAX INVOICE"
  '  'e.Graphics.DrawString(mText, prnFontNormalBold, Brushes.Black, mRect, mAlign)
  '  ' เลขที่ขาย
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = "No. " & SplitSaleNumb(mSaleNumb)
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  ' วันที่-เวลา
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Far
  '  mText = pServerDateTime.ToString("dd'/'MM'/'yy  HH:mm")
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  ' --------
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = StrDup(80, "-")
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '  Dim mGoodAmou As Integer
  '  Dim mGoodName As String
  '  Dim mBarcode As String
  '  Dim mUnitPrice As Double
  '  Dim mSubDisc As Double
  '  Dim mSubTotal As Double
  '  Dim mUnitDesc As String
  '  Dim mTotalDisc As Double
  '  Dim mTotalPrice As Double
  '  Dim mTotalNet As Double
  '  'Dim mTotalBeforeVat As Double

  '  mTotalPrice = 0
  '  mTotalDisc = 0
  '  For Each row As DataGridViewRow In dtgSale.Rows
  '    mGoodName = dtgSale.Item("goodName", row.Index).Value
  '    mGoodAmou = dtgSale.Item("saleAmou", row.Index).Value
  '    mBarcode = dtgSale.Item("barCode", row.Index).Value
  '    mUnitPrice = dtgSale.Item("unitPrice", row.Index).Value
  '    mSubDisc = dtgSale.Item("subDisc", row.Index).Value
  '    mUnitDesc = dtgSale.Item("unitDesc", row.Index).Value
  '    mSubTotal = CLng(mGoodAmou * mUnitPrice)
  '    mTotalPrice += mSubTotal
  '    mTotalDisc += mSubDisc
  '    ' จำนวน
  '    mLineNo = mLineNo + 1
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = mGoodAmou & " " & mUnitDesc
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' ชื่อสินค้า
  '    mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = mGoodName
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' ราคาขาย
  '    mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Far
  '    mText = Format(mSubTotal, "#,##0.00")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    '' รหัสสินค้า
  '    'mRowPos += mLineSpace15
  '    'mRect = New RectangleF(55, mRowPos, 260.0F, 20.0F)
  '    'mAlign.Alignment = StringAlignment.Near
  '    'mText = "[" & mBarcode & "]"
  '    'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '    ' แสดงส่วนลดของสินค้าแต่ละตัวที่ได้ลด
  '    If mSubDisc > 0 Then
  '      ' จำนวน
  '      mLineNo = mLineNo + 1
  '      mRowPos += mLineSpace15
  '      mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
  '      mAlign.Alignment = StringAlignment.Near
  '      mText = "1"
  '      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '      ' ชื่อสินค้า
  '      mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
  '      mAlign.Alignment = StringAlignment.Near
  '      mText = "ส่วนลด " & mGoodName
  '      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '      ' ส่วนลด
  '      mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
  '      mAlign.Alignment = StringAlignment.Far
  '      mText = Format(-mSubDisc, "#,##0.00")
  '      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '      '' รหัสสินค้า
  '      'mRowPos += mLineSpace15
  '      'mRect = New RectangleF(55, mRowPos, 260.0F, 20.0F)
  '      'mAlign.Alignment = StringAlignment.Near
  '      'mText = "[" & mBarcode & "]"
  '      'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    End If
  '  Next
  '  ' ส่วนลดจากแต้ม
  '  If mPointDisc > 0 Then
  '    ' จำนวน
  '    mLineNo = mLineNo + 1
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "1"
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' ส่วนลด
  '    mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "ส่วนลดจากแต้ม"
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' ยอดเงิน
  '    mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Far
  '    mText = Format(-mPointDisc, "#,##0.00") '-mPointDisc.ToString("#,##0.00")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  End If
  '  ' --------
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = StrDup(80, "-")
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  ' ยอดสินค้าสุทธิ (หลังหักส่วนลด)
  '  mTotalNet = mTotalPrice - mTotalDisc - mPointDisc
  '  ' จำนวนเงินรวมทั้งสิ้น
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = "จำนวนเงินรวมทั้งสิ้น"
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '  mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Far
  '  mText = Format(mTotalNet, "#,##0.00")
  '  e.Graphics.DrawString(mText, prnFontNormalBold, Brushes.Black, mRect, mAlign)

  '  '' จำนวนเงินเป็นตัวอักษร
  '  'mLineNo = mLineNo + 1
  '  'mRowPos += mLineSpace15
  '  'mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
  '  'mAlign.Alignment = StringAlignment.Near
  '  'mText = "(" & MoneyToWord(mTotalNet) & ")"
  '  'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '  ' ประเภทการชำระเงิน
  '  For Each mRow As DataGridViewRow In mGridPay.Rows
  '    If Val(mGridPay.Item("payAmou", mRow.Index).Value) > 0 And mGridPay.Item("cardCode", mRow.Index).Value <> "" And mGridPay.Item("cardCode", mRow.Index).Value <> "0" Then
  '      mLineNo = mLineNo + 1
  '      mRowPos += mLineSpace15
  '      mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
  '      mAlign.Alignment = StringAlignment.Near
  '      mText = "ชำระ " & mGridPay.Item("cardName", mRow.Index).Value
  '      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '      mAlign.Alignment = StringAlignment.Far
  '      mText = MyVal(mGridPay.Item("payAmou", mRow.Index).Value).ToString("#,##0.00")
  '      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    End If
  '  Next

  '  ' ชำระเงินสด
  '  If mTotalCashPay > 0 Then
  '    mLineNo = mLineNo + 1
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "ชำระ เงินสด"
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Far
  '    mText = mTotalCashPay.ToString("#,##0.00")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' เงินทอน
  '    mLineNo = mLineNo + 1
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "เงินทอน"
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

  '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Far
  '    mText = mTotalChange.ToString("#,##0.00")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  End If

  '  ' แสดงแต้ม เฉพาะสมาชิก HUG Club ********
  '  If mCustType = "6" Then
  '    ' --------
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = StrDup(80, "-")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' รหัสสมาชิก
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "สมาชิก " & lblCustName.Text & " [" & txtCustCode.Text & "]"
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' แต้มที่ได้ครั้งนี้
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "HUG Points (ครั้งนี้) " & Format(mThisPoint, "#,##0")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    '' จำนวนแต้ม
  '    'mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
  '    'mAlign.Alignment = StringAlignment.Far
  '    'mText = Format(mThisPoint, "#,##0")
  '    'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' แต้มที่ใช้
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "HUG Points (ใช้เป็นส่วนลด) " & Format(mUsePoint, "#,##0")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    '' จำนวนแต้ม
  '    'mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
  '    'mAlign.Alignment = StringAlignment.Far
  '    'mText = Format(mUsePoint, "#,##0")
  '    'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    ' แต้มสะสม
  '    mRowPos += mLineSpace15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = "HUG Points (สะสม) " & Format(mRemainPoint + mThisPoint, "#,##0")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '    '' จำนวนแต้ม
  '    'mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
  '    'mAlign.Alignment = StringAlignment.Far
  '    'mText = Format(mRemainPoint + mThisPoint, "#,##0")
  '    'e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  End If
  '  ' ***************
  '  ' สิทธิ์แลกซื้อ
  '  If mBxCode <> "" Then
  '    mRowPos = mRowPos + 15
  '    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '    mAlign.Alignment = StringAlignment.Near
  '    mText = mBxAmou.ToString & " สิทธิ์แลกซื้อ [" & mBxCode & "]" & " ใช้ได้ถึง " & mExExpireDate.ToString("dd'/'MM'/'yyyy")
  '    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  End If

  '  ' --------
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = StrDup(80, "-")
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  '  ' พนักงาน
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = "พนักงานขาย " & RemoveNickName(lblEmplName.Text)
  '  e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
  '  ' Cashier
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = "ผู้รับเงิน " & RemoveNickName(pUserName)
  '  e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)

  '  ' ท้ายเอกสาร 1
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Near
  '  mText = "ขอสงวนสิทธิ์ในการรับเปลี่ยน/คืนสินค้า หากไม่มีใบเสร็จรับเงินมาแสดง"
  '  e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
  '  ' VAT INCLUDED
  '  mLineNo = mLineNo + 1
  '  mRowPos += mLineSpace15
  '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
  '  mAlign.Alignment = StringAlignment.Center
  '  mText = "*** VAT INCLUDED ***"
  '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  'End Sub

  Private Function GetStockOnhand(ByVal GoodCode As String, ByVal BranchCode As String)
    Dim mStockOnhand As Integer = 0
    Dim mFieldStockOnhand As String
    mFieldStockOnhand = "stockOnhand" & BranchCode
    Dim mGet() As String
    mGet = pService.GetData("Drug", "Select " & mFieldStockOnhand & " from GoodInfo where goodCode = '" & GoodCode & "'")
    If mGet(0) = "1" Then
      mStockOnhand = Val(mGet(1))
    End If
    Return mStockOnhand
  End Function

  Private Sub tbnNewMemb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnNewMemb.Click
    frmMemberInfo.pIsNewMemb = True
    frmMemberInfo.pFreeMember = False
    frmMemberInfo.ShowDialog()
    If frmMemberInfo.pOk = True Then
      ' ป้อนรหัสสมาชิกใหม่อัตโนมัติ
      txtCustCode.Text = frmMemberInfo.pNewMembCode
      ShowCust(txtCustCode.Text)
      'If frmMemberInfo.pFreeMember = False Then
      '  ' ถ้าเป็นลูกค้าสมาชิก HUG Club ให้คิดค่าสมาชิก (ตามราคาของรหัสสินค้า 066 ค่าสมัครสมาชิก)
      '  ' ยกเว้น ค่าสมัคร = 0
      '  If mCustType = "6" And GetGoodPrice("066", pBranchPrice) > 0 Then
      '    txtBarcode.Text = "066"
      '    ' ป้อนรายการค่าสมัครอัตโนมัติ
      '    ShowGood(txtBarcode.Text, 1, 0, "")
      '  End If
      'End If
    End If
    frmMemberInfo = Nothing
  End Sub

  Private Function GetGoodPrice(ByVal Barcode As String, ByVal PriceLevel As String)
    Dim mPrice As Double
    Dim mGet() As String
    mGet = pService.GetData("Drug", "Select price" & PriceLevel & " from GoodBarcode where barCode = '" & Barcode & "'")
    If mGet(0) = "1" Then
      mPrice = CDbl(mGet(1))
    Else
      mPrice = 0
    End If
    Return mPrice
  End Function

  Private Sub pdcAbbBillVat_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcAbbBillVat.PrintPage
    PrintAbbBillVat(mSaleNumb, e)
  End Sub
End Class