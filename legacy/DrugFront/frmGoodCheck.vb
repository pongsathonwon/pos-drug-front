Public Class frmGoodCheck

  'Dim mGoodCode As String
  Dim mGoodName As String
  Dim mMiniStockField As String = "miniStock" & pBranchCode
  Dim mLastSaleField As String = "lastSale" & pBranchCode
  Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
  Dim mRetailPriceField As String = "price" & pBranchPrice
  Dim mWholePriceField As String = "price" & pWholePriceLevel
  Dim mUnitCostField As String = "unitCost" & pBranchCode
  Dim mShelfNoField As String = "shelfNo" & pBranchCode

  Dim mStickerPrice As Double
  Dim mFixPrice As String

  Private Sub frmGoodCheck_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    mGoodName = ""
    ' แสดงช่องขายส่งเฉพาะสาขาที่เปิดระบบขายส่ง
    If pAllowWholePrice = "1" Then
      dtgPrice.Columns("wholePrice").Visible = True
    Else
      dtgPrice.Columns("wholePrice").Visible = False
    End If
    ' ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑
    ' ซ่อนแสดงคอลันน์สมาชิก
    If pAllowOnlyMembPrice = "1" Then
      dtgPrice.Columns("genPrice").Visible = True
      dtgPrice.Columns("genUnitPrice").Visible = True
      dtgPrice.Columns("membPrice").HeaderText = "สมาชิก"
    Else
      dtgPrice.Columns("genPrice").Visible = False
      dtgPrice.Columns("genUnitPrice").Visible = False
      dtgPrice.Columns("membPrice").HeaderText = "ปลีก"
    End If
    ' ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑
  End Sub

  Private Sub frmGoodCheck_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.F4
        tbnGoodSearch.PerformClick()
      Case Keys.Escape
        Me.Close()
    End Select
  End Sub

  Private Sub ShowDetail(ByVal GoodCode As String)
    If GoodCode <> "" Then
      Me.Cursor = Cursors.WaitCursor

      dtgDetail.Rows.Clear()
      dtgPrice.Rows.Clear()
      txtPromotion.Text = ""
      lblGoodName.Text = ""
      picGood.Image = Nothing
      Application.DoEvents()

      Dim dsGoodPrice As New DataSet
      dsGoodPrice = pService.SelectData("Drug", "SELECT GB.*, UI.unitDesc, UI.unitFactor FROM GoodBarcode GB INNER JOIN GoodInfo GI ON GB.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON GB.unitCode = UI.unitCode WHERE GB.goodCode = '" & GoodCode & "' AND GI.goodStat = '1'")
      If IsNothing(dsGoodPrice) = False Then
        Dim dvGoodPrice As New DataView(dsGoodPrice.Tables(0))
        If dvGoodPrice.Count > 0 Then
          Dim dsGoodInfo As New DataSet
          dsGoodInfo = pService.SelectData("Drug", "SELECT GI.goodName, GI.goodDesc, UI.unitDesc, TI.typeDesc, GP.groupdesc, DG.drugDesc, IG.indiDesc, US.useDesc, RI.recoDesc, GI." & mUnitCostField & " as unitCost, GI." & mMiniStockField & " As miniStock, GI." & mLastSaleField & " As lastSale, GI." & mStockOnhandField & " As stockOnhand, GI.goodRema, GI.fixGroup, GI." & mShelfNoField & " As shelfNo, GI.stickerPrice, GI.fixPrice, GI.fcCostFactor FROM GoodInfo GI INNER JOIN TypeInfo TI ON GI.typeCode = TI.typeCode INNER JOIN GroupInfo GP ON GI.groupCode = GP.groupCode INNER JOIN DrugGroup DG ON GI.drugCode = DG.drugCode INNER JOIN UnitInfo UI ON GI.unitCode = UI.unitCode INNER JOIN IndiGroup IG ON GI.indiCode = IG.indiCode INNER JOIN UseInfo US ON GI.useCode = US.useCode INNER JOIN RecoInfo RI ON GI.recoCode = RI.recoCode WHERE GI.goodCode = '" & GoodCode & "'")
          If IsNothing(dsGoodInfo) = False Then
            Dim dvGoodInfo As New DataView(dsGoodInfo.Tables(0))
            If dvGoodInfo.Count > 0 Then
              Dim mGoodStock As New GoodStock
              With dvGoodInfo.Item(0)
                'dtgDetail.Rows.Add("รหัสสินค้า", .Item("barCode"))
                dtgDetail.Rows.Add("ชื่อการค้า", .Item("goodName"))
                lblGoodName.Text = .Item("goodName")
                '##### เตรียม text สำหรับ search MIMS
                Dim mText() As String
                mText = Split(.Item("goodName"), " ")
                ttbSearch.Text = mText(0)
                '####
                dtgDetail.Rows.Add("ชื่อสามัญทางยา", .Item("goodDesc"))
                dtgDetail.Rows.Add("หน่วยย่อย", .Item("unitDesc"))
                dtgDetail.Rows.Add("ประเภทสินค้า", .Item("typeDesc"))
                ' กลุ่มสินค้า ถ้าไม่มีการ fix group ให้คำนวณตามราคาต้นทุนและราคาขายปัจจุบัน
                If .Item("fixGroup").ToString = "0" Then
                  dtgDetail.Rows.Add("กลุ่มสินค้า", FindGoodGroup(GoodCode))
                Else
                  dtgDetail.Rows.Add("กลุ่มสินค้า", .Item("groupDesc"))
                End If
                dtgDetail.Rows.Add("กลุ่มยา", .Item("drugDesc"))
                dtgDetail.Rows.Add("กลุ่มการรักษา", .Item("indiDesc"))
                dtgDetail.Rows.Add("วิธีใช้", .Item("useDesc"))
                dtgDetail.Rows.Add("คำแนะนำ", .Item("recoDesc"))

                If IsDBNull(.Item("lastSale")) = False Then
                  dtgDetail.Rows.Add("วันที่ขายล่าสุด", ThaiDate(.Item("lastSale")))
                Else
                  dtgDetail.Rows.Add("วันที่ขายล่าสุด", "")
                End If
                dtgDetail.Rows.Add("จุดสั่งซื้อ", .Item("miniStock"))
                dtgDetail.Rows.Add("จำนวนคงเหลือ", .Item("stockOnhand"))
                'dtgDetail.Rows.Add("ทุนต่อหน่วย", .Item("unitCost"))
                ' สาขา FC ให้แสดงทุนต่อหน่วย
                If pIsFranchise = "1" Then
                  If pBranchTypeCode = "2" Then ' เฉพาะสาขาแฟรนไชส์ partner ship ให้คูณ factor
                    dtgDetail.Rows.Add("ทุนต่อหน่วย", .Item("unitCost") * .Item("fcCostFactor"))
                  Else
                    dtgDetail.Rows.Add("ทุนต่อหน่วย", .Item("unitCost"))
                  End If
                End If
                dtgDetail.Rows.Add("ชั้นวาง", .Item("shelfNo"))

                dtgDetail.Rows.Add("สถานะ", .Item("goodRema"))
                mFixPrice = .Item("fixPrice")
                mStickerPrice = .Item("stickerPrice")
                If mStickerPrice > 0 Then
                  dtgDetail.Rows.Add("ราคาป้าย", mStickerPrice.ToString("#,##0.00"))
                Else
                  dtgDetail.Rows.Add("ราคาป้าย ")
                End If

                ' บริษัทจำหน่าย
                Dim mGet() As String
                Dim mCompName As String = ""
                mGet = pService.GetData("Drug", "Select CI.compName from CompGood CG inner join CompInfo CI on CI.compCode = CG.compCode where CG.goodCode = '" & GoodCode & "'")
                If mGet(0) = "1" Then
                  mCompName = mGet(1)
                End If
                dtgDetail.Rows.Add("บริษัทจำหน่าย", mCompName)

                ' แสดงรูป
                Try
                  Dim mGoodImageURL As String
                  mGoodImageURL = pGoodImageFolder & "/" & GoodCode & ".jpg"
                  Dim mImage As New DownLoadImage(mGoodImageURL)
                  Dim mMemStream As IO.MemoryStream = mImage.BeginDownLoad
                  picGood.Image = Image.FromStream(mMemStream)
                Catch ex As Exception
                  If Not (picGood.Image Is Nothing) Then
                    picGood.Image.Dispose()
                    picGood.Image = Nothing
                  End If
                End Try

                ' แสดงราคาขาย
                Dim mUnitFactor As Integer
                Dim mGoodAmou As Integer
                Dim mMembPrice As Double
                Dim mGenPrice As Double
                Dim mWholePrice As Double

                Dim mPrice As Double
                Dim mAmou As Integer

                For i As Integer = 0 To dvGoodPrice.Count - 1
                  With dvGoodPrice.Item(i)
                    dtgPrice.Rows.Add()
                    dtgPrice.Item("barCode", i).Value = .Item("barCode")
                    dtgPrice.Item("saleAmou", i).Value = .Item("goodAmou") & " " & .Item("unitDesc")
                    dtgPrice.Item("unitDesc", i).Value = .Item("unitDesc")

                    mUnitFactor = .Item("unitFactor")
                    mGoodAmou = .Item("goodAmou") * mUnitFactor
                    mMembPrice = .Item(mRetailPriceField)
                    mWholePrice = .Item(mWholePriceField)

                    dtgPrice.Item("membPrice", i).Value = mMembPrice
                    dtgPrice.Item("membUnitPrice", i).Value = mMembPrice / mGoodAmou
                    dtgPrice.Item("wholePrice", i).Value = mWholePrice

                    ' ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑
                    ' คอลัมน์แสดงระดับราคา ลูกค้าทั่วไป GenPrice ปรับราคาเพิ่มเป็นสเต๊ปเช่น 5->3, 3->2
                    If pAllowOnlyMembPrice = "1" Then
                      Select Case mRetailPriceField
                        Case "price1" ' ปรับเพิ่มอีก pPerPrice1ToPrice0% (ยกเว้นรายการที่ fixPrice)
                          If mFixPrice = "1" Then
                            mGenPrice = .Item("price1")
                          Else
                            mPrice = .Item("price1")
                            mAmou = .Item("goodAmou") ' * mUnitFactor
                            mPrice = mPrice / mAmou
                            mPrice = Math.Ceiling(mPrice + (mPrice * (pPerPrice1ToPrice0 / 100)))
                            ' ราคาที่ปรับขึ้นแล้ว ต้องไม่เกินราคาป้าย
                            If mStickerPrice > 0 AndAlso mPrice / (mAmou * mUnitFactor) > mStickerPrice Then
                              mPrice = mStickerPrice * mAmou * mUnitFactor
                            End If

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
                    dtgPrice.Item("genPrice", i).Value = mGenPrice
                    dtgPrice.Item("genUnitPrice", i).Value = mGenPrice / mGoodAmou
                    ' ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑
                  End With
                Next

                ' โปรโมชั่น
                GoodPromotion(GoodCode)

                dtgDetail.ClearSelection()
                dtgPrice.ClearSelection()
              End With
            End If
            dvGoodInfo = Nothing
          Else
            pMessageBox = New MyMessageBox("ไม่พบข้อมูลสินค้า", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            pMessageBox.ShowDialog()
          End If
          dsGoodInfo = Nothing
        Else
          pMessageBox = New MyMessageBox("ไม่พบข้อมูลสินค้า", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
          pMessageBox.ShowDialog()
        End If
        dvGoodPrice = Nothing
      Else
        pMessageBox = New MyMessageBox("cannot select data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        pMessageBox.ShowDialog()
      End If
      dsGoodPrice = Nothing
      txtBarCode.Text = ""
      txtBarCode.Focus()
      Me.Cursor = Cursors.Default
    End If
  End Sub

  Private Sub txtBarCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarCode.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub txtBarCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarCode.LostFocus
    If txtBarCode.Text <> "" Then
      Dim mGet() As String
      mGet = pService.GetData("Drug", "Select goodCode from GoodBarcode where barCode = '" & txtBarCode.Text & "'")
      If mGet(0) = "1" Then
        ShowDetail(mGet(1))
      Else
        pMessageBox = New MyMessageBox("ไม่พบรหัสสินค้า", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        pMessageBox.ShowDialog()
        txtBarCode.Text = ""
        txtBarCode.Focus()
      End If
    End If
  End Sub

  Private Sub tbnGoodSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnGoodSearch.Click
    frmGoodSearch.ShowDialog()
    If frmGoodSearch.pOk = True Then
      txtBarCode.Focus()
      txtBarCode.Text = frmGoodSearch.pBarcode
      SendKeys.Send("{Enter}")
    End If
  End Sub

  Private Function FindGoodGroup(ByVal GoodCode As String) As String
    If GoodCode = "" Then
      Return ""
      Exit Function
    End If

    Dim mGroupDesc As String = ""
    Dim mUnitCost As Double = 0
    Dim mUnitPrice As Double = 0
    Dim mUnitCode As String = ""
    Dim mGP As Double = 0
    ' หาราคาทุนต่อหน่วย
    Dim mGet() As String
    mGet = pService.GetData("Drug", "Select unitCode, " & mUnitCostField & " From GoodInfo Where goodCode = '" & GoodCode & "'")
    If mGet(0) = "1" Then
      mUnitCode = mGet(1)
      mUnitCost = Val(mGet(2))
    End If
    ' หาราคาขายต่อหน่วย
    mGet = pService.GetData("Drug", "Select " & mRetailPriceField & " From GoodBarcode Where goodCode = '" & GoodCode & "' And goodAmou = 1 And unitCode = '" & mUnitCode & "'")
    If mGet(0) = "1" Then
      mUnitPrice = Val(mGet(1))
    End If
    ' คำนวณ %GP
    If mUnitPrice > 0 Then
      mGP = (mUnitPrice - mUnitCost) * 100 / mUnitPrice
      ' จัดกลุ่ม
      mGet = pService.GetData("Drug", "Select groupDesc From GroupInfo Where fromGP <= " & mGP & " And toGP >= " & mGP)
      If mGet(0) = "1" Then
        mGroupDesc = mGet(1)
      End If
    End If

    Return mGroupDesc
  End Function

  Private Sub tbnMimbSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnMimbSearch.Click
    If ttbSearch.Text <> "" Then
      Process.Start("http://www.mims.com/thailand/drug/search?q=" & ttbSearch.Text)
    End If
  End Sub

  Private Sub GoodPromotion(ByVal GoodCode As String)
    Dim mPromotion As String = ""
    Dim mCustTypeDesc As String
    Dim mPriceType As String

    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select GP.*, UI.unitDesc, CT.custTypeDesc From GoodPro GP inner join GoodInfo GI on GI.goodCode = GP.goodCode inner join UnitInfo UI on UI.unitCode = GI.unitCode inner join CustType CT on CT.custTypeCode = GP.custTypeCode Where GP.proStat <> '0' and GP.startDate <= '" & MDYStr(pServerDateTime.Date) & "' And GP.endDate >= '" & MDYStr(pServerDateTime.Date) & "' And GP.compCode = '' and (GP.branchCode = '" & pBranchCode & "' or (GP.branchCode = '0' and GP.branchPrice = '0') or (GP.branchCode = '0' and GP.branchPrice = '" & pBranchPrice & "')) and GP.goodCode = '" & GoodCode & "' order by GP.custTypeCode, GP.goodAmou")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          If .Item("custTypeCode") <> "0" Then ' เฉพาะประเภทลูกค้า
            mCustTypeDesc = .Item("custTypeDesc")
          Else ' ประเภทลูกค้าทั้งหมด ไม่ต้องแสดง
            mCustTypeDesc = ""
          End If
          ' ประเภทการขาย
          Select Case .Item("priceType")
            Case "R"
              mPriceType = "ขายปลีก"
            Case "W"
              mPriceType = "ขายส่ง"
            Case "O"
              mPriceType = "ออนไลน์"
            Case Else
              mPriceType = ""
          End Select

          mPromotion = mPromotion & ": [" & mCustTypeDesc & ": " & mPriceType & "] ซื้อ " & .Item("goodAmou") & " " & .Item("unitDesc") & " ลด " & Format(.Item("discAmou"), "#,##0") & " บาท (" & .Item("startDate") & " - " & .Item("endDate") & ")" & vbCrLf
        End With
      Next

      txtPromotion.Text = mPromotion
      If dv.Count > 4 Then ' เกิน 4 รายการ ให้แสดง scroll bar ด้านข้าง
        txtPromotion.ScrollBars = ScrollBars.Vertical
      Else
        txtPromotion.ScrollBars = ScrollBars.None
      End If
      dv = Nothing
    End If
    ds = Nothing
  End Sub

  Private Function CustType(ByVal CustTypeCode As String) As String
    Dim mCustTypeDesc As String = "???"

    If CustTypeCode = "0" Then
      mCustTypeDesc = "ทั้งหมด"
    Else
      Dim mGet() As String
      mGet = pService.GetData("Drug", "Select custTypeDesc from CustType where custTypeCode = '" & CustTypeCode & "'")
      If mGet(0) = "1" Then
        mCustTypeDesc = mGet(1)
      End If
    End If
    Return mCustTypeDesc
  End Function

  Private Sub txtBarCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarCode.TextChanged
    If txtBarCode.Text.Length > 1 Then
      Select Case Mid(txtBarCode.Text, txtBarCode.Text.Length, 1)
        Case "+" ' ถ้าตัวอักษรท้ายเป็น + แสดงว่าต้องการค้นหารหัส barcode
          Dim mPreName As String
          ' แปลงตัวเลขเป็นตัวอักษร
          mPreName = NumbToChar(Mid(txtBarCode.Text, 1, txtBarCode.Text.Length - 1))
          txtBarCode.Text = ""

          frmGoodSearch.pPreName = mPreName
          frmGoodSearch.ShowDialog()
          If frmGoodSearch.pOk = True Then
            txtBarCode.Focus()
            txtBarCode.Text = frmGoodSearch.pBarcode
            SendKeys.Send("{Enter}")
          End If
        Case "-" ' ถ้าตัวอักษรท้ายเป็น - ให้เปิดหน้าต่างค้นหาตามชื่อ
          Dim mText As String
          mText = Mid(txtBarCode.Text, 1, txtBarCode.Text.Length - 1)
          txtBarCode.Text = ""

          frmGoodSearch.pPreName = mText
          frmGoodSearch.ShowDialog()
          If frmGoodSearch.pOk = True Then
            txtBarCode.Focus()
            txtBarCode.Text = frmGoodSearch.pBarcode
            SendKeys.Send("{Enter}")
          End If
      End Select
    End If
  End Sub

  Private Function CheckHavePro(ByVal GoodCode As String, ByVal SaleAmou As Integer, ByVal CustType As String, ByVal CustPriceType As String) As Boolean
    Dim mHavePro As Boolean = False

    pServerDateTime = pService.ServerDateTime

    Dim ds As New DataSet
    Dim mSqlText As String

    mSqlText = "Select goodAmou From GoodPro Where proStat = '1' and priceType = '" & CustPriceType & "' and goodCode = '" & GoodCode & "' And startDate <= '" & MDYStr(pServerDateTime.Date) & "' And endDate >= '" & MDYStr(pServerDateTime.Date) & "' And compCode = '' and ((branchCode = '0' and custTypeCode = '0' and branchPrice = '0') or (branchCode = '0' and custTypeCode = '" & CustType & "' and branchPrice = '0') or (branchCode = '0' and custTypeCode = '0' and branchPrice = '" & pBranchPrice & "') or (branchCode = '" & pBranchCode & "' and custTypeCode = '0' and branchPrice = '0') or (branchCode = '" & pBranchCode & "' and custTypeCode = '" & CustType & "' and branchPrice = '" & pBranchPrice & "') or (branchCode = '" & pBranchCode & "' and custTypeCode = '" & CustType & "' and branchPrice = '0') or (branchCode = '" & pBranchCode & "' and custTypeCode = '0' and branchPrice = '" & pBranchPrice & "') or (branchCode = '0' and custTypeCode = '" & CustType & "' and branchPrice = '" & pBranchPrice & "'))"

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
End Class