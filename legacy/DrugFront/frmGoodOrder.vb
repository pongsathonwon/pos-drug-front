Public Class frmGoodOrder

  Dim mGoodCode As String
  Dim mBarCode As String
  Dim mUnitCode As String
  Dim mTypeDesc As String
  Dim mStockOnhand0, mStockOnhandDN As Integer
  Dim mBookAmouBranch, mBookAmouDN As Integer
  Dim mBranchOnhand, mAvaiOnhand As Integer
  Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
  Dim mMiniStockField As String = "miniStock" & pBranchCode
  Dim mPriceField As String = "price" & pBranchPrice
  Dim mUnitPrice As Double
  Dim mUnitFactor As Integer
  Dim mPackFactor As Integer
  Dim mIsShipTo As Boolean
  Dim mIsPackSale As Boolean
  Dim mSuspendPending As String

  Private Sub frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    lblGoodName.Text = ""
    lblUnitDesc.Text = ""
    lblGoodRema.Text = ""
    lblUrgentOrder.Visible = False

    ShowGoodType()
    ShowTempOrder()
    'ShowPendOrder("")
    'AddPendOrder(pBranchCode)

    CheckPriv()

    If pIsBranchShipTo = False Then
      dtgList.Columns("shipTo").Visible = False
    End If

  End Sub

  'Private Sub frmGoodOrder_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
  '  Me.WindowState = FormWindowState.Maximized
  'End Sub

  'Private Sub frmGoodOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
  '  Select Case e.KeyCode
  '    Case Keys.F5
  '      tbnPendOrder.PerformClick()
  '    Case Keys.F7
  '      tbnUrgentOrder.PerformClick()
  '    Case Keys.F8
  '      tbnTempSave.PerformClick()
  '    Case Keys.F9
  '      tbnSave.PerformClick()
  '    Case Keys.F10
  '      tbnPrint.PerformClick()
  '    Case Keys.F11
  '      tbnImportList.PerformClick()
  '    Case Keys.F12
  '      tbnRefresh.PerformClick()
  '  End Select
  'End Sub

  Private Sub CheckPriv()
    ' Add
    If InStr(pUserPriv, Me.Tag.ToString & "A") > 0 Then
      btnAdd.Enabled = True
      tbnSave.Enabled = True
      tbnTempSave.Enabled = True
      'dtgList.Columns("goodAmou").ReadOnly = False
    Else
      btnAdd.Enabled = False
      tbnSave.Enabled = False
      tbnTempSave.Enabled = False
      'dtgList.Columns("goodAmou").ReadOnly = True
    End If
    ' Print
    If InStr(pUserPriv, Me.Tag.ToString & "P") > 0 Then
      tbnPrint.Enabled = True
    Else
      tbnPrint.Enabled = False
    End If
    ' Level 3 Only
    If InStr(pUserPriv, "LEVEL3") > 0 Then
      tbnImportList.Visible = True
    Else
      tbnImportList.Visible = False
    End If
  End Sub

  'Private Sub ShowPendOrder(ByVal GoodCode As String)
  '  Me.Cursor = Cursors.WaitCursor

  '  Dim dsOrder As New DataSet
  '  Dim mSqlText As String

  '  mSqlText = "SELECT GI.goodCode, GB.barCode, UI.unitCode, (PO.pendAmou * UI2.unitFactor) as pendAmou, GI.goodName, GI.stockOnhand0, GI.stockOnhandDN, GI.bookAmouBranch, GI.bookAmouDN, GI." & mStockOnhandField & " As stockOnhand, GI." & mMiniStockField & " As miniStock, UI.unitDesc, UI.unitFactor, TI.typeDesc, GB." & mPriceField & " as unitPrice FROM PendOrder PO inner join GoodInfo GI on PO.goodCode = GI.goodCode inner join UnitInfo UI on UI.unitCode = GI.unitCode inner join UnitInfo UI2 on UI2.unitCode = PO.unitCode inner join TypeInfo TI on TI.typeCode = GI.typeCode inner join (SELECT DISTINCT goodCode, barCode, " & mPriceField & " FROM GoodBarcode WHERE LEN(barCode) = '6' AND goodAmou = 1) GB on GI.goodCode = GB.goodCode WHERE PO.branchCode = '" & pBranchCode & "'"

  '  If GoodCode <> "" Then
  '    mSqlText = mSqlText & " and PO.goodCode = '" & GoodCode & "'"
  '  End If

  '  dsOrder = pService.SelectData("Drug", mSqlText)
  '  If IsNothing(dsOrder) = False Then
  '    Dim dvOrder As New DataView(dsOrder.Tables(0))
  '    'dtgList.Rows.Clear()
  '    If dvOrder.Count > 0 Then
  '      Dim mGoodCode As String
  '      Dim mOrderAmou As Integer
  '      Dim mStockOnhand0, mStockOnhandDN As Integer
  '      Dim mBookAmouBranch, mBookAmouDN As Integer
  '      Dim mAvaiOnhand As Integer
  '      Dim mUnitFactor As Integer
  '      Dim mIsShipto As Boolean
  '      Dim mDup As Boolean
  '      Dim mNewRowIndex As Integer
  '      For i As Integer = 0 To dvOrder.Count - 1
  '        With dvOrder.Item(i)
  '          mGoodCode = .Item("goodCode")
  '          mOrderAmou = .Item("pendAmou")
  '          mStockOnhand0 = .Item("stockOnhand0")
  '          mStockOnhandDN = .Item("stockOnhandDN")
  '          mBookAmouBranch = .Item("bookAmouBranch")
  '          mBookAmouDN = .Item("bookAmouDN")
  '          mAvaiOnhand = mStockOnhand0 + mStockOnhandDN - mBookAmouBranch - mBookAmouDN
  '          ' ถ้าจำนวนสั่งมากกว่าคงเหลือเบิกได้ ให้เท่ากับยอดคงเหลือ
  '          If mAvaiOnhand > 0 And mOrderAmou > mAvaiOnhand Then
  '            mOrderAmou = mAvaiOnhand
  '          End If
  '          mUnitFactor = .Item("unitFactor")
  '          If IsShipTo(.Item("goodCode").ToString) = "" Then
  '            mIsShipto = False
  '          Else
  '            mIsShipto = True
  '          End If

  '          ' เช็คซ้ำ
  '          mDup = False
  '          For Each mRow As DataGridViewRow In dtgList.Rows
  '            If dtgList.Item("goodCode", mRow.Index).Value.ToString = .Item("goodCode").ToString Then
  '              mDup = True
  '              Exit For
  '            End If
  '          Next

  '          If mDup = False Then
  '            dtgList.Rows.Add()
  '            mNewRowIndex = dtgList.Rows.Count - 1
  '            dtgList.Item("item", mNewRowIndex).Value = mNewRowIndex + 1
  '            dtgList.Item("goodCode", mNewRowIndex).Value = .Item("goodCode")
  '            dtgList.Item("barCode", mNewRowIndex).Value = .Item("barCode")
  '            dtgList.Item("goodName", mNewRowIndex).Value = .Item("goodName")
  '            dtgList.Item("goodAmou", mNewRowIndex).Value = mOrderAmou
  '            dtgList.Item("unitCode", mNewRowIndex).Value = .Item("unitCode")
  '            dtgList.Item("unitDesc", mNewRowIndex).Value = .Item("unitDesc")
  '            dtgList.Item("miniStock", mNewRowIndex).Value = .Item("miniStock")
  '            dtgList.Item("stockOnhand", mNewRowIndex).Value = .Item("stockOnhand")
  '            dtgList.Item("stockOnhand0", mNewRowIndex).Value = mStockOnhand0
  '            dtgList.Item("stockOnhandDN", mNewRowIndex).Value = mStockOnhandDN
  '            If mIsShipto = False Then
  '              dtgList.Item("avaiOnhand", mNewRowIndex).Value = mAvaiOnhand
  '            Else
  '              dtgList.Item("avaiOnhand", mNewRowIndex).Value = ""
  '            End If
  '            dtgList.Item("typeDesc", mNewRowIndex).Value = .Item("typeDesc")
  '            dtgList.Item("unitPrice", mNewRowIndex).Value = .Item("unitPrice")
  '            dtgList.Item("unitFactor", mNewRowIndex).Value = .Item("unitFactor")

  '            ' เฉพาะสาขาที่เซ็ทให้เป็น ship to
  '            If pIsBranchShipTo = True Then
  '              dtgList.Item("shipTo", mNewRowIndex).Value = IsShipTo(.Item("goodCode").ToString)
  '            Else
  '              dtgList.Item("shipTo", dtgList.Rows.Count - 1).Value = ""
  '            End If

  '            dtgList.Item("isPending", mNewRowIndex).Value = "1"

  '            ' ถ้าสต๊อคกลางไม่พอส่ง ให้แสดงอักษรสีแดง ยกเว้นสินค้า ship to
  '            If (mOrderAmou * mUnitFactor) > mAvaiOnhand And mIsShipto = False Then
  '              dtgList.Rows(mNewRowIndex).DefaultCellStyle.ForeColor = Color.Red
  '            Else
  '              dtgList.Rows(mNewRowIndex).DefaultCellStyle.ForeColor = Color.SandyBrown
  '            End If
  '          End If
  '        End With
  '      Next
  '      dtgList.ClearSelection()
  '      CalTotalPrice()
  '    End If
  '    dvOrder = Nothing
  '  End If
  '  dsOrder = Nothing
  '  'If dtgList.Rows.Count > 0 Then
  '  '  dtgList.ClearSelection()
  '  'End If
  '  Me.Cursor = Cursors.Default
  'End Sub

  'Private Sub AddPendOrder(ByVal BranchCode As String)
  '  Me.Cursor = Cursors.WaitCursor

  '  Dim ds As New DataSet
  '  Dim mSqlText As String
  '  mSqlText = "SELECT PO.*, GI.goodName, GI.unitCost0, GI.unitCostDN, GI.stockOnhand0, GI.stockOnhandDN, (GI.shelfNoSub+'/'+GI.shelfNo) as shelfNo, GI.packSize, GK.bookAmou, UI.unitDesc, UI.unitFactor FROM PendOrder PO INNER JOIN GoodInfo GI ON PO.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON PO.unitCode = UI.unitCode left join GoodBooking GK on GK.docNumb = PO.orderNumb and GK.goodCode = PO.goodCode Where PO.pendStat = '2' and PO.branchCode = '" & BranchCode & "' ORDER BY GI.shelfNo, GI.goodName"
  '  ds = pService.SelectData("Drug", mSqlText)

  '  If IsNothing(ds) = False Then
  '    Dim dv As New DataView(ds.Tables(0))
  '    For i As Integer = 0 To dv.Count - 1
  '      With dv.Item(i)
  '        ' แสดงเฉพาะรายการที่ได้รับจอง
  '        If IsDBNull(.Item("bookAmou")) = False Then
  '          dtgList.Rows.Add()
  '          dtgList.Item("item", dtgList.Rows.Count - 1).Value = dtgList.Rows.Count
  '          dtgList.Item("goodCode", dtgList.Rows.Count - 1).Value = .Item("goodCode")
  '          dtgList.Item("goodName", dtgList.Rows.Count - 1).Value = .Item("goodName")
  '          dtgList.Item("goodAmou", dtgList.Rows.Count - 1).Value = .Item("pendAmou")
  '          dtgList.Item("unitCode", dtgList.Rows.Count - 1).Value = .Item("unitCode")
  '          dtgList.Item("unitDesc", dtgList.Rows.Count - 1).Value = .Item("unitDesc")
  '          dtgList.Item("unitFactor", dtgList.Rows.Count - 1).Value = .Item("unitFactor")
  '          'dtgList.Item("bookAmou", dtgList.Rows.Count - 1).Value = .Item("bookAmou")
  '          dtgList.Item("isPending", dtgList.Rows.Count - 1).Value = "1"
  '          dtgList.Rows(dtgList.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Blue
  '        End If
  '      End With
  '    Next
  '    dv = Nothing
  '    'CheckSendAmou()
  '  End If
  '  ds = Nothing

  '  Me.Cursor = Cursors.Default
  'End Sub

  Private Sub ShowTempOrder()
    Me.Cursor = Cursors.WaitCursor

    ' รายการค้างส่ง
    Dim dsPend As New DataSet
    Dim dvPend As New DataView
    dsPend = pService.SelectData("Drug", "Select * from PendOrder where branchCode = '" & pBranchCode & "'")
    If IsNothing(dsPend) = False Then
      dvPend = New DataView(dsPend.Tables(0))
    End If

    Dim dsOrder As New DataSet
    Dim mSqlText As String

    mSqlText = "SELECT distinct TG.goodCode, TG.barCode, TG.unitCode, TG.goodAmou, GI.goodName, GI.stockOnhand0, GI.stockOnhandDN, GI.bookAmouBranch, GI.bookAmouDN, GI." & mStockOnhandField & " As stockOnhand, GI." & mMiniStockField & " As miniStock, UI.unitDesc, UI.unitFactor, TI.typeDesc, GB." & mPriceField & " as unitPrice, GK.totalBookAmou, CC.shipTo FROM TempGoodOrder TG inner join GoodInfo GI on TG.goodCode = GI.goodCode inner join UnitInfo UI on TG.unitCode = UI.unitCode inner join TypeInfo TI on TI.typeCode = GI.typeCode inner join (select GB.goodCode, GB.barCode, GB." & mPriceField & " FROM GoodBarcode GB inner join GoodInfo GI on GI.goodCode = GB.goodCode and GI.unitCode = GB.unitCode WHERE GB.goodAmou = 1) GB on GI.goodCode = GB.goodCode left join (Select goodCode, sum(bookAmou) as totalBookAmou from GoodBooking Group by goodCode) GK on GK.goodCode = TG.goodCode left join (Select CG.goodCode, CI.shipTo from CompInfo CI inner join CompGood CG on CI.compCode = CG.compCode where CG.isShipTo = '1') CC on CC.goodCode = TG.goodCode WHERE TG.branchCode = '" & pBranchCode & "' and GI.suspendBranchOrder <> '1' Order by GI.goodName" ' ยกเว้นรายการที่ถูกระงับการสั่ง

    dsOrder = pService.SelectData("Drug", mSqlText)
    If IsNothing(dsOrder) = False Then
      Dim dvOrder As New DataView(dsOrder.Tables(0))
      dtgList.Rows.Clear()
      If dvOrder.Count > 0 Then
        'Dim mStockOnhand0 As Integer
        Dim mDup As Boolean
        Dim mNewRowIndex As Integer
        Dim mGoodCode As String
        Dim mOrderAmou As Integer
        Dim mStockOnhand0, mStockOnhandDN As Integer
        Dim mBookAmouBranch, mBookAmouDN As Integer
        Dim mTotalBookAmou As Integer
        Dim mAvaiOnhand As Integer
        Dim mUnitFactor As Integer
        Dim mIsShipto As Boolean
        For i As Integer = 0 To dvOrder.Count - 1
          With dvOrder.Item(i)
            ' เช็คซ้ำกับรายการค้างส่ง
            mDup = False
            For x As Integer = 0 To dvPend.Count - 1
              If dvPend.Item(x).Item("goodCode").ToString = .Item("goodCode").ToString Then
                mDup = True
                Exit For
              End If
            Next

            'For Each mRow As DataGridViewRow In dtgList.Rows
            '  If dtgList.Item("goodCode", mRow.Index).Value.ToString = .Item("goodCode").ToString Then
            '    mDup = True
            '    Exit For
            '  End If
            'Next

            If mDup = False Then
              dtgList.Rows.Add()

              mGoodCode = .Item("goodCode")
              mOrderAmou = .Item("goodAmou")
              mStockOnhand0 = .Item("stockOnhand0")
              mStockOnhandDN = .Item("stockOnhandDN")
              mBookAmouBranch = .Item("bookAmouBranch")
              mBookAmouDN = .Item("bookAmouDN")

              'mAvaiOnhand = CheckAvaiOnhand(.Item("goodCode"))
              If IsDBNull(.Item("totalBookAmou")) = False Then
                mTotalBookAmou = .Item("totalBookAmou")
              Else
                mTotalBookAmou = 0
              End If
              mAvaiOnhand = mStockOnhand0 + mStockOnhandDN - mTotalBookAmou

              mUnitFactor = .Item("unitFactor")

              If IsDBNull(.Item("shipTo")) = False Then
                mIsShipto = True
              Else
                mIsShipto = False
              End If
              'If IsShipTo(.Item("goodCode").ToString) = "" Then
              '  mIsShipto = False
              'Else
              '  mIsShipto = True
              'End If

              mNewRowIndex = dtgList.Rows.Count - 1
              dtgList.Item("item", mNewRowIndex).Value = dtgList.Rows.Count
              dtgList.Item("goodCode", mNewRowIndex).Value = .Item("goodCode")
              dtgList.Item("barCode", mNewRowIndex).Value = .Item("barCode")
              dtgList.Item("goodName", mNewRowIndex).Value = .Item("goodName")
              dtgList.Item("goodAmou", mNewRowIndex).Value = mOrderAmou
              dtgList.Item("unitCode", mNewRowIndex).Value = .Item("unitCode")
              dtgList.Item("unitDesc", mNewRowIndex).Value = .Item("unitDesc")
              dtgList.Item("miniStock", mNewRowIndex).Value = .Item("miniStock")
              dtgList.Item("stockOnhand", mNewRowIndex).Value = .Item("stockOnhand")
              dtgList.Item("stockOnhand0", mNewRowIndex).Value = mStockOnhand0
              dtgList.Item("stockOnhandDN", mNewRowIndex).Value = mStockOnhandDN

              If IsDBNull(.Item("shipTo")) = False Then
                'mIsShipto = True
                dtgList.Item("avaiOnhand", mNewRowIndex).Value = ""
                ' เฉพาะสาขาที่เซ็ทให้เป็น ship to
                If pIsBranchShipTo = True Then
                  dtgList.Item("shipTo", mNewRowIndex).Value = .Item("shipTo")
                Else
                  dtgList.Item("shipTo", mNewRowIndex).Value = ""
                End If
              Else
                'mIsShipto = False
                dtgList.Item("avaiOnhand", mNewRowIndex).Value = mAvaiOnhand
                dtgList.Item("shipTo", mNewRowIndex).Value = ""
              End If

              'If mIsShipto = False Then
              '  dtgList.Item("avaiOnhand", mNewRowIndex).Value = mAvaiOnhand
              'Else
              '  dtgList.Item("avaiOnhand", mNewRowIndex).Value = ""
              'End If

              dtgList.Item("typeDesc", mNewRowIndex).Value = .Item("typeDesc")
              dtgList.Item("unitPrice", mNewRowIndex).Value = .Item("unitPrice")
              dtgList.Item("unitFactor", mNewRowIndex).Value = .Item("unitFactor")

              '' เฉพาะสาขาที่เซ็ทให้เป็น ship to
              'If pIsBranchShipTo = True Then
              '  dtgList.Item("shipTo", mNewRowIndex).Value = IsShipTo(.Item("goodCode").ToString)
              'Else
              '  dtgList.Item("shipTo", dtgList.Rows.Count - 1).Value = ""
              'End If

              'MarkItem()

              ' ถ้าสต๊อคกลางไม่พอส่ง ให้แสดงอักษรสีแดง ยกเว้นสินค้า ship to
              If (mOrderAmou * mUnitFactor) > mAvaiOnhand And mIsShipto = False Then
                dtgList.Rows(mNewRowIndex).DefaultCellStyle.ForeColor = Color.Red
              Else
                dtgList.Rows(mNewRowIndex).DefaultCellStyle.ForeColor = Color.Black
              End If
            End If
          End With
        Next

        CalTotalPrice()
      End If
      dvOrder = Nothing
    End If
    dsOrder = Nothing
    If dtgList.Rows.Count > 0 Then
      dtgList.ClearSelection()
    End If
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub ShowGood(ByVal GoodCode As String, ByVal BarCode As String)
    Dim mSqlText As String
    If GoodCode <> "" Then
      mSqlText = "SELECT GI.goodCode, GI.goodName, GI.unitCode, UI.unitDesc, UI.unitFactor, GI.stockOnhand0, GI.goodRema, GI." & mStockOnhandField & " as branchOnhand, GI." & mMiniStockField & " as miniStock, TI.typeDesc, GB." & mPriceField & " as unitPrice, PI.unitFactor as packFactor, PI.unitDesc as packDesc, GI.suspendBranchOrder, GI.stockOnhandDN, GI.bookAmouBranch, GI.bookAmouDN, GI.packSize, GI.isPackSale, GI.suspendPending FROM GoodInfo GI inner join (select goodCode, " & mPriceField & " from GoodBarcode where goodAmou = 1) GB on GI.goodCode = GB.goodCode INNER JOIN UnitInfo UI ON GI.unitCode = UI.unitCode INNER JOIN UnitInfo PI ON GI.packCode = PI.unitCode INNER JOIN TypeInfo TI ON TI.typeCode = GI.typeCode WHERE GI.goodCode = '" & GoodCode & "' And GI.goodStat <> '0'"
    Else
      mSqlText = "SELECT GB.goodCode, GI.goodName, GI.unitCode, UI.unitDesc, UI.unitFactor, GI.stockOnhand0, GI.goodRema, GI." & mStockOnhandField & " as branchOnhand, GI." & mMiniStockField & " as miniStock, TI.typeDesc, GB." & mPriceField & " as unitPrice, PI.unitFactor as packFactor, PI.unitDesc as packDesc, GI.suspendBranchOrder, GI.stockOnhandDN, GI.bookAmouBranch, GI.bookAmouDN, GI.packSize, GI.isPackSale, GI.suspendPending FROM GoodBarcode GB INNER JOIN GoodInfo GI ON GB.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON GI.unitCode = UI.unitCode INNER JOIN UnitInfo PI ON GI.packCode = PI.unitCode INNER JOIN TypeInfo TI ON TI.typeCode = GI.typeCode WHERE GB.barCode = '" & BarCode & "' And GI.goodStat <> '0'"
    End If

    Dim ds As New DataSet
    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        Dim mUnitDesc As String
        With dv.Item(0)
          If .Item("suspendBranchOrder").ToString = "1" Then
            MessageBox.Show("สินค้าถูกระงับการสั่ง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ClearGoodField()
            txtBarcode.Focus()
            Exit Sub
          End If
          mBarCode = BarCode
          mGoodCode = .Item("goodCode").ToString
          lblGoodName.Text = .Item("goodName").ToString
          mUnitCode = .Item("unitCode").ToString
          mUnitDesc = .Item("unitDesc").ToString
          lblUnitDesc.Text = .Item("unitDesc").ToString
          mUnitFactor = CInt(.Item("unitFactor"))

          mBranchOnhand = CInt(.Item("branchOnhand"))
          lblBranchOnhand.Text = CInt(mBranchOnhand).ToString("#,##0") & " " & mUnitDesc
          mStockOnhand0 = CInt(.Item("stockOnhand0"))
          mStockOnhandDN = CInt(.Item("stockOnhandDN"))
          mBookAmouBranch = CInt(.Item("bookAmouBranch"))
          If mBookAmouBranch < 0 Then mBookAmouBranch = 0
          mBookAmouDN = CInt(.Item("bookAmouDN"))
          If mBookAmouDN < 0 Then mBookAmouDN = 0
          ' คงเหลือทั้งหมด หักยอดจอง
          'mAvaiOnhand = mStockOnhand0 + mStockOnhandDN - mBookAmouBranch - mBookAmouDN
          'mAvaiOnhand = mStockOnhand0 + mStockOnhandDN - Math.Max(0, mBookAmouBranch) - Math.Max(0, mBookAmouDN) ' Math.Max ใช้สำหรับเลือกค่าที่มากกว่า เพื่อให้ค่าที่ติดลบเป็น 0

          mAvaiOnhand = CheckAvaiOnhand(mGoodCode)

          lblShipTo.Text = IsShipTo(mGoodCode)

          If lblShipTo.Text = "" Then
            mIsShipTo = False
          Else
            mIsShipTo = True
          End If


          'If IsShipTo(mGoodCode) = "" Then
          '  mIsShipTo = False
          '  lblAvaiOnhand.Text = CInt(mAvaiOnhand).ToString("#,##0") & " " & mUnitDesc
          'Else
          '  mIsShipTo = True
          '  lblAvaiOnhand.Text = "ship to"
          'End If

          lblAvaiOnhand.Text = CInt(mAvaiOnhand).ToString("#,##0") & " " & mUnitDesc

          lblGoodRema.Text = .Item("goodRema").ToString
          lblMiniStock.Text = CInt(.Item("miniStock")).ToString("#,##0") & " " & mUnitDesc
          mTypeDesc = .Item("typeDesc").ToString
          mUnitPrice = CDbl(.Item("unitPrice"))
          mPackFactor = CInt(.Item("packFactor"))
          lblPackDesc.Text = .Item("packDesc").ToString
          lblOrderUnitDesc.Text = mUnitDesc

          If .Item("isPackSale").ToString = "1" Then
            lblPackSale.Visible = True
            'lblOrderUnitDesc.Text = .Item("packDesc")
          Else
            lblPackSale.Visible = False
            'lblOrderUnitDesc.Text = .Item("unitDesc")
          End If
          mSuspendPending = .Item("suspendPending")

          'If lblGoodRema.Text <> "" Then
          '  MessageBox.Show(lblGoodRema.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
          'End If

          txtGoodAmou.Text = OrderAmou(mGoodCode).ToString
          If txtGoodAmou.Text = "0" Then
            txtGoodAmou.Text = mPackFactor
          End If

          txtGoodAmou.Focus()
        End With
      Else
        MessageBox.Show("ไม่พบข้อมูลสินค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ClearGoodField()
        txtBarcode.Focus()
      End If
      dv = Nothing
    Else
      MessageBox.Show("Create dataset error!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      ClearGoodField()
      txtBarcode.Focus()
    End If
    ds = Nothing




    'Dim getValue() As String
    'getValue = pService.GetData("Drug", mSqlText)

    'If getValue(0) = "1" Then
    '  If getValue(13) = "1" Then
    '    MessageBox.Show("สินค้าถูกระงับการสั่งซื้อ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '    ClearGoodField()
    '    txtBarcode.Focus()
    '    Exit Sub
    '  End If

    '  mBarCode = BarCode
    '  mGoodCode = getValue(1)
    '  lblGoodName.Text = getValue(2)
    '  mUnitCode = getValue(3)
    '  lblUnitDesc.Text = getValue(4)
    '  mStockOnhand0 = CInt(getValue(5))
    '  lblGoodRema.Text = getValue(6)
    '  lblStockOnhand.Text = CInt(getValue(7)).ToString("#,##0")
    '  lblMiniStock.Text = CInt(getValue(8)).ToString("#,##0")
    '  mTypeDesc = getValue(9)
    '  mUnitPrice = CDbl(getValue(10))
    '  mPackFactor = CInt(getValue(11))
    '  lblPackDesc.Text = getValue(12)
    '  mStockOnhandDN = CInt(getValue(14))
    '  If lblGoodRema.Text <> "" Then
    '    MessageBox.Show(lblGoodRema.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '  End If
    '  txtGoodAmou.Text = OrderAmou(mGoodCode).ToString
    '  If txtGoodAmou.Text = "0" Then
    '    txtGoodAmou.Text = mPackFactor
    '  End If

    '  txtGoodAmou.Focus()
    'Else
    '  MessageBox.Show("ไม่พบข้อมูลสินค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '  ClearGoodField()
    '  txtBarcode.Focus()
    'End If
  End Sub

  Private Sub textKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress, txtRemark.KeyPress, txtName.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub txtGoodAmou_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGoodAmou.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      'SendKeys.Send("{Tab}")
      If mGoodCode <> "" AndAlso Val(txtGoodAmou.Text) > 0 Then
        AddList()
      End If
    End If
  End Sub

  Private Sub ClearAll()
    txtBarcode.Text = ""
    lblGoodName.Text = ""
    txtGoodAmou.Text = ""
    lblUnitDesc.Text = ""
    lblGoodRema.Text = ""
    lblBranchOnhand.Text = ""
    lblAvaiOnhand.Text = ""
    lblMiniStock.Text = ""
    lblShipTo.Text = ""
    lblPackDesc.Text = ""
    lblOrderUnitDesc.Text = "หน่วย"
    txtRemark.Text = ""
    lblPackSale.Visible = False
    lblUrgentOrder.Visible = False
    tbnTempSave.Enabled = True
    dtgList.Rows.Clear()
    dtgGoodSearch.Rows.Clear()
  End Sub

  Private Sub ClearGoodField()
    mBarCode = ""
    mGoodCode = ""
    txtBarcode.Text = ""
    lblGoodName.Text = ""
    txtGoodAmou.Text = ""
    lblUnitDesc.Text = ""
    lblPackDesc.Text = ""
    lblOrderUnitDesc.Text = "หน่วย"
    lblGoodRema.Text = ""
    lblBranchOnhand.Text = ""
    lblAvaiOnhand.Text = ""
    lblMiniStock.Text = ""
    lblShipTo.Text = ""
    lblPackSale.Visible = False
  End Sub

  Private Sub txtBarcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.LostFocus
    If txtBarcode.Text <> "" Then
      ShowGood("", txtBarcode.Text)
    End If
  End Sub

  Private Sub AddList()
    Dim mOrderAmou As Integer
    mOrderAmou = CInt(Val(txtGoodAmou.Text))

    If mOrderAmou <= 0 Then
      MessageBox.Show("กรุณาป้อนจำนวนสั่ง", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      txtGoodAmou.Text = ""
      txtGoodAmou.Focus()
      Exit Sub
    End If

    ' เตือนเมื่อรายการที่สั่งมากเกินกว่า 10 เท่าของหน่วยบรรจุ
    If mOrderAmou > mPackFactor And (mOrderAmou / mPackFactor) > 10 Then
      pMessageBox = New MyMessageBox("จำนวนสินค้าที่สั่ง มากผิดปกติ" & vbCrLf & vbCrLf & "ยืนยันเพิ่มรายการ", "คำเตือน", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
      If pMessageBox.ShowDialog = Windows.Forms.DialogResult.Cancel Then
        Exit Sub
      End If
    End If

    ' เช็ครายการซ้ำกับรายการค้างส่ง
    Dim mGet() As String
    mGet = pService.GetData("Drug", "Select goodCode from PendOrder where goodCode = '" & mGoodCode & "' and branchCode = '" & pBranchCode & "'")
    If mGet(0) = "1" Then
      MessageBox.Show("สินค้าอยู่ในรายการค้างส่งแล้ว", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If

    '' ########## ระบบจอง ยกเว้นสินค้าที่สั่งแบบ ship to
    'If mAvaiOnhand <= 0 Then
    '  pMessageBox = New MyMessageBox("สินค้าขาดสต๊อค", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '  pMessageBox.ShowDialog()
    '  Exit Sub
    'Else
    '  If mOrderAmou > mAvaiOnhand And mIsShipTo = False Then
    '    pMessageBox = New MyMessageBox("สินค้าไม่พอจัดส่ง (คงเหลือ " & mAvaiOnhand & " " & lblOrderUnitDesc.Text & ")", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    pMessageBox.ShowDialog()
    '    Exit Sub
    '  End If
    'End If
    '' ###########

    ' ปรับจำนวนสั่ง ให้พอดีกับขนาดบรรจุที่กำหนดไว้ (packAmou) เฉพาะสินค้าบังคับขายยกแพ็ค
    If lblPackSale.Visible = True Then
      mOrderAmou = Math.Ceiling(mOrderAmou / mPackFactor) * mPackFactor
      ' ถ้าปรับแล้วได้ 0 ให้จำนวนสั่งเท่ากับขนาดบรรจุที่กำหนด
      If mOrderAmou <= 0 Then
        mOrderAmou = mPackFactor
      End If
    End If

    'If lblPackSale.Visible = True Then
    '  mOrderAmou = mOrderAmou * mPackFactor
    'Else
    '  mOrderAmou = mOrderAmou * mUnitFactor
    'End If
    'Dim mDup As Boolean = False

    ' เช็ครายการซ้ำ
    For Each mRow As DataGridViewRow In dtgList.Rows
      If dtgList.Item("goodCode", mRow.Index).Value = mGoodCode Then
        MessageBox.Show("รายการซ้ำ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        dtgList.FirstDisplayedScrollingRowIndex = mRow.Index
        Exit Sub
      End If
    Next

    dtgList.Rows.Add()
    dtgList.Item("item", dtgList.Rows.Count - 1).Value = dtgList.Rows.Count
    dtgList.Item("goodCode", dtgList.Rows.Count - 1).Value = mGoodCode
    dtgList.Item("barCode", dtgList.Rows.Count - 1).Value = mBarCode
    dtgList.Item("goodName", dtgList.Rows.Count - 1).Value = lblGoodName.Text
    dtgList.Item("goodAmou", dtgList.Rows.Count - 1).Value = mOrderAmou ' Val(txtGoodAmou.Text)
    dtgList.Item("unitDesc", dtgList.Rows.Count - 1).Value = lblUnitDesc.Text
    dtgList.Item("unitCode", dtgList.Rows.Count - 1).Value = mUnitCode
    dtgList.Item("stockOnhand", dtgList.Rows.Count - 1).Value = MyVal(lblBranchOnhand.Text)
    dtgList.Item("stockOnhand0", dtgList.Rows.Count - 1).Value = mStockOnhand0
    dtgList.Item("stockOnhandDN", dtgList.Rows.Count - 1).Value = mStockOnhandDN
    dtgList.Item("avaiOnhand", dtgList.Rows.Count - 1).Value = mAvaiOnhand
    'dtgList.Item("shipTo", dtgList.Rows.Count - 1).Value = lblShipTo.Text
    dtgList.Item("miniStock", dtgList.Rows.Count - 1).Value = MyVal(lblMiniStock.Text)
    dtgList.Item("typeDesc", dtgList.Rows.Count - 1).Value = mTypeDesc
    dtgList.Item("unitPrice", dtgList.Rows.Count - 1).Value = mUnitPrice
    dtgList.Item("unitFactor", dtgList.Rows.Count - 1).Value = mUnitFactor
    dtgList.Item("packFactor", dtgList.Rows.Count - 1).Value = mPackFactor
    dtgList.Item("goodRema", dtgList.Rows.Count - 1).Value = lblGoodRema.Text
    dtgList.FirstDisplayedScrollingRowIndex = dtgList.Rows.Count - 1

    ' เตือนสั่งสินค้าเกินสต๊อค เฉพาะสินค้าที่ไม่ใช่ ship to จะเข้าระบบจอง 
    If lblShipTo.Text = "" And mOrderAmou > mAvaiOnhand Then
      dtgList.Rows(dtgList.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Red
    End If

    ' เฉพาะสาขาที่เซ็ทให้เป็น ship to
    If pIsBranchShipTo = True And lblShipTo.Text <> "" Then
      dtgList.Item("shipTo", dtgList.Rows.Count - 1).Value = lblShipTo.Text
    Else
      dtgList.Item("shipTo", dtgList.Rows.Count - 1).Value = ""
    End If

    'dtgList.ClearSelection()

    CalTotalPrice()

    ClearGoodField()
    CheckListDup()
    txtBarcode.Focus()
  End Sub

  Private Sub MarkItem()
    Dim mStockOnhand As Integer
    Dim mStockOnhand0 As Integer
    Dim mStockOnhandDN As Integer
    Dim mMiniStock As Integer
    Dim mOrderAmou As Integer
    For i As Integer = 0 To dtgList.Rows.Count - 1
      mStockOnhand = CInt(dtgList.Item("stockOnhand", i).Value)
      mStockOnhand0 = CInt(dtgList.Item("stockOnhand0", i).Value)
      mStockOnhandDN = CInt(dtgList.Item("stockOnhandDN", i).Value)
      mMiniStock = CInt(dtgList.Item("miniStock", i).Value)
      mOrderAmou = CInt(dtgList.Item("goodAmou", i).Value)

      dtgList.Rows(i).DefaultCellStyle.ForeColor = Color.Black

      If mOrderAmou <= 0 Then
        dtgList.Rows(i).DefaultCellStyle.ForeColor = Color.Brown
      Else
        If (mStockOnhand0 + mStockOnhandDN) <= 0 Then
          dtgList.Rows(i).DefaultCellStyle.ForeColor = Color.Blue
        Else
          If mStockOnhand > mMiniStock Then
            dtgList.Rows(i).DefaultCellStyle.ForeColor = Color.Purple
          End If
        End If
      End If
    Next
  End Sub

  Private Sub EnableCellEdit()
    For Each mRow As DataGridViewRow In dtgList.Rows
      If dtgList.Item("shipTo", mRow.Index).Value.ToString <> "" Then
        dtgList.Item("goodAmou", mRow.Index).ReadOnly = True
      Else
        dtgList.Item("goodAmou", mRow.Index).ReadOnly = False
      End If
    Next
  End Sub

  Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    If mGoodCode <> "" Then
      If mAvaiOnhand <= 0 And mSuspendPending = "1" Then
        pMessageBox = New MyMessageBox("สินค้ารายการนี้ขาดสต๊อค และระงับการจองล่วงหน้า กรุณาสั่งใหม่ครั้งต่อไป", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        pMessageBox.ShowDialog()
        Exit Sub
      End If

      AddList()
    End If
  End Sub

  Private Sub dtgList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgList.CellDoubleClick
    If e.RowIndex >= 0 Then
      txtBarcode.Text = dtgList.Item("barCode", e.RowIndex).Value.ToString
      ShowGood("", txtBarcode.Text)
    End If
  End Sub

  Private Sub dtgList_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgList.CellEndEdit
    'MarkItem()
  End Sub

  Private Sub dtgList_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dtgList.ColumnHeaderMouseClick
    ' เรียงเลขบรรทัดใหม่
    For i As Integer = 0 To dtgList.Rows.Count - 1
      dtgList.Item("item", i).Value = i + 1
    Next
  End Sub

  Private Sub dtgList_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgList.RowEnter
    If e.RowIndex >= 0 Then
      dtgList.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = dtgList.Rows(e.RowIndex).DefaultCellStyle.ForeColor
    End If
  End Sub

  Private Sub dtgList_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dtgList.RowsRemoved
    ' เรียงเลขบรรทัดใหม่
    For i As Integer = 0 To dtgList.Rows.Count - 1
      dtgList.Item("item", i).Value = i + 1
    Next
    CheckListDup()
  End Sub

  Private Sub tbnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnSave.Click
    If dtgList.Rows.Count = 0 Then
      Exit Sub
    End If

    If CheckDup() = True Then
      Exit Sub
    End If

    If MessageBox.Show("ยืนยันสั่งสินค้า", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
      Exit Sub
    End If

    Me.Cursor = Cursors.WaitCursor

    ' เช็คจำนวนสั่งเป็น 0
    For i As Integer = 0 To dtgList.Rows.Count - 1
      If CInt(dtgList.Item("GoodAmou", i).Value) <= 0 Then
        MessageBox.Show("มีรายการสินค้าที่จำนวนสั่งเป็น 0 ไม่สามารถทำการสั่งสินค้าได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Me.Cursor = Cursors.Default
        Exit Sub
      End If
    Next

    Dim mGoodAmou As Integer
    Dim mAvaiOnhand As Integer
    Dim mGoodShipTo As String
    Dim mGet() As String

    ' @@@@@@@@@@@@@@@@@@@@@@@@@
    ' เช็คสต๊อคคงเหลือหลังหักยอดจองทุกรายการ อีกครั้ง เนื่องจากสต๊อคมีจำนวนเปลี่ยนแปลงตลอดเวลา
    CheckAvaiStock()
    ' รายการที่สั่งไม่ได้ ให้มาร์คว่าเป็นรายการค้างส่ง
    Dim mHaveOrderItem As Boolean = False ' มีรายการสั่ง
    For Each mRow As DataGridViewRow In dtgList.Rows
      If dtgList.Item("shipTo", mRow.Index).Value = "" Then
        mGoodShipTo = dtgList.Item("shipTo", mRow.Index).Value
        mGoodAmou = dtgList.Item("goodAmou", mRow.Index).Value
        mAvaiOnhand = dtgList.Item("avaiOnhand", mRow.Index).Value
        '' เช็คสินค้ากลางคงเหลืออีกครั้ง (ระบบจอง จะทำให้สต๊อคกลางเปลี่ยนแปลงตลอดเวลา)
        'mAvaiOnhand = CheckAvaiOnhand(dtgList.Item("goodCode", mRow.Index).Value)
        'dtgList.Item("avaiOnhand", mRow.Index).Value = mAvaiOnhand

        ' เป็นรายการที่ต้องเก็บเป็นรายการค้างส่ง
        If mGoodShipTo = "" And mGoodAmou > mAvaiOnhand Then
          dtgList.Item("isPending", mRow.Index).Value = "1"
          dtgList.Rows(mRow.Index).DefaultCellStyle.ForeColor = Color.Red
        Else
          dtgList.Item("isPending", mRow.Index).Value = "0"
          dtgList.Rows(mRow.Index).DefaultCellStyle.ForeColor = Color.Black
          mHaveOrderItem = True
        End If
      Else
        dtgList.Item("avaiOnhand", mRow.Index).Value = "0"
        dtgList.Rows(mRow.Index).DefaultCellStyle.ForeColor = Color.Black
        mHaveOrderItem = True
      End If
    Next

    ' ไม่ออกใบสั่ง หากไม่มีรายการที่ส่งได้ (ไม่ใช่รายการค้างส่งทั้งหมด)
    If mHaveOrderItem = False Then
      MessageBox.Show("ต้องมีรายการสั่งสินค้าได้ อย่างน้อยหนึ่งรายการ จึงจะออกใบสั่งสินค้าได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Me.Cursor = Cursors.Default
      Exit Sub
    End If

    ' @@@@@@@@@@@@@@@@@@@@@@@@@

    '' เช็คสินค้าทุกรายการ ว่าสต๊อคเพียงพอจะส่งหรือไม่
    'If CheckAvaiStock() = False Then
    '  Exit Sub
    'End If

    Dim mSqlText() As String
    Dim mLine As Integer

    mLine = 0

    If dtgList.Rows.Count > 0 Then
      ReDim mSqlText(dtgList.Rows.Count * 3)
      Dim mNumb As Integer
      Dim mOrderNumb As String = ""
      Dim getValue() As String
      getValue = pService.GetData("Drug", "SELECT orderNumb FROM BranchInfo WHERE branchCode = '" & pBranchCode & "'")
      If getValue(0) = "1" Then
        mNumb = CInt(getValue(1))
      Else
        MessageBox.Show(getValue(1), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      End If

      If mHaveOrderItem = True Then
        ' ออกใบสั่งโดย group ตาม shipTo ' ถ้าช่อง shipTo เป็นช่องว่าง ถือว่าเป็นการออกใบสั่งแบบปกติ
        Dim ds As New DataSet
        ds = pService.SelectData("Drug", "Select distinct shipTo from CompInfo")
        If IsNothing(ds) = False Then
          Dim dv As New DataView(ds.Tables(0))
          Dim mCompShipTo As String = ""
          Dim mGoodCode As String
          Dim mUnitCode As String
          Dim mUnitPrice As Double
          Dim mTotalPrice As Double
          ReDim mSqlText((dtgList.Rows.Count * 3) + (dv.Count * 2) + 1)
          Dim mItemCount As Integer


          ' ใช้วันที่และเวลาของ server
          pServerDateTime = pService.ServerDateTime

          mLine = 0
          For i As Integer = 0 To dv.Count - 1
            mCompShipTo = dv.Item(i).Item("shipTo").ToString
            mItemCount = 0
            For Each mRow As DataGridViewRow In dtgList.Rows
              If dtgList.Item("isPending", mRow.Index).Value = "1" Then
                Continue For
              End If
              ' ถ้าในตารางมีสินค้าบริษัทที่ shipTo ตรงกัน ให้ออกใบสั่ง
              mGoodShipTo = dtgList.Item("shipTo", mRow.Index).Value.ToString
              If mGoodShipTo = mCompShipTo Then
                mItemCount += 1
              End If
            Next

            If mItemCount > 0 Then
              mOrderNumb = pBranchCode & Mid((1000000 + mNumb).ToString, 2)
              ' ถ้าสั่งด่วน ให้เติมอักษร X ต่อท้ายเลขที่ใบสั่ง
              If lblUrgentOrder.Visible = True Then
                mOrderNumb = mOrderNumb & "X"
              End If

              mSqlText(mLine) = "INSERT INTO HistOrder (orderNumb, orderDate, orderTime, branchCode, emplCode, orderRema, orderStat, totalPrice, shipTo) VALUES ('" & mOrderNumb & "', '" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', '" & pBranchCode & "', '" & pUserCode & "', '" & Replace(txtRemark.Text, "'", "''") & "', '1', 0, '" & mCompShipTo & "')"
              mLine += 1

              mTotalPrice = 0
              For Each xRow As DataGridViewRow In dtgList.Rows
                If dtgList.Item("isPending", xRow.Index).Value = "1" Then
                  Continue For
                End If

                With dtgList
                  mGoodCode = .Item("goodCode", xRow.Index).Value.ToString
                  mUnitCode = .Item("unitCode", xRow.Index).Value.ToString
                  mGoodAmou = CInt(.Item("goodAmou", xRow.Index).Value)
                  mUnitPrice = CDbl(.Item("unitPrice", xRow.Index).Value)
                  mGoodShipTo = .Item("shipTo", xRow.Index).Value.ToString
                  mAvaiOnhand = .Item("avaiOnhand", xRow.Index).Value
                End With

                '' เฉพาะรายการที่สั่งคลัง (ไม่ใช่ shipto) ให้ตรวจสอบจำนวนคงเหลือพอส่ง
                'If mCompShipTo = "" Then
                '  mAvaiOnhand = CheckAvaiOnhand(mGoodCode)
                'End If

                If mGoodShipTo = mCompShipTo Then
                  ' เฉพาะรายการที่สั่ง shipto หรือรายการที่สั่งคลังและมีของพอส่ง
                  If mCompShipTo <> "" Or (mCompShipTo = "" And mGoodAmou <= mAvaiOnhand) Then
                    mSqlText(mLine) = "INSERT INTO OrderList (OrderNumb, goodCode, goodAmou, sendAmou, unitCode, itemType) VALUES ('" & mOrderNumb & "', '" & mGoodCode & "', " & mGoodAmou & ", 0, '" & mUnitCode & "', 'O')"
                    mLine += 1
                    ' ########## ระบบจอง ยกเว้นสินค้าที่สั่งแบบ ship to และเฉพาะรายการที่สั่งไม่เกินจำนวนสต๊อคกลางคงเหลือ
                    If mCompShipTo = "" Then
                      If mGoodAmou <= mAvaiOnhand Then
                        mSqlText(mLine) = "Update GoodInfo set bookAmouBranch = bookAmouBranch + " & mGoodAmou & " Where goodCode = '" & mGoodCode & "'"
                        mLine += 1
                        mSqlText(mLine) = "Insert into GoodBooking (docNumb, docType, goodCode, bookAmou, bookStat) values ('" & mOrderNumb & "', 'BO', '" & mGoodCode & "', " & mGoodAmou & ", '1')"
                        mLine += 1
                      End If
                    End If
                    ' ########## ระบบจอง

                    mTotalPrice += mUnitPrice * mGoodAmou
                  Else

                  End If
                End If
              Next

              mSqlText(mLine) = "Update HistOrder set totalPrice = " & mTotalPrice & " where orderNumb = '" & mOrderNumb & "'"
              mLine += 1

              ' เพิ่มเลขที่ใบสั่งใหม่
              mNumb += 1
            End If
          Next
          '' ลบรายการค้างส่ง
          'mSqlText(mLine) = "DELETE FROM PendOrder WHERE branchCode = '" & pBranchCode & "'"
          'mLine += 1

          '' กรณีมีการใช้เลขใบสั่ง
          'If mNumb <> getValue(1) Then
          '  mSqlText(mLine) = "UPDATE BranchInfo set orderNumb = " & mNumb & " WHERE branchCode = '" & pBranchCode & "'"
          '  mLine += 1
          'End If
        End If
        ds = Nothing
      End If

      ' รายการที่เก็บไว้ค้างส่ง
      'mOrderNumb = pBranchCode & Mid((1000000 + mNumb).ToString, 2)
      For Each mRow As DataGridViewRow In dtgList.Rows
        If dtgList.Item("isPending", mRow.Index).Value <> "1" Then
          Continue For
        End If

        mGoodCode = dtgList.Item("goodCode", mRow.Index).Value.ToString
        mGoodAmou = dtgList.Item("goodAmou", mRow.Index).Value
        mUnitCode = dtgList.Item("unitCode", mRow.Index).Value.ToString
        mPackFactor = dtgList.Item("packFactor", mRow.Index).Value

        '' ยกเว้นรายการที่สั่งมากเกินกว่า 10 เท่าของหน่วยบรรจุ
        'If mGoodAmou > mPackFactor And (mGoodAmou / mPackFactor) > 10 Then
        '  Continue For
        'End If

        ' เช็คว่ามีรายการจองอยู่แล้วหรือไม่
        mGet = pService.GetData("Drug", "Select goodCode from PendOrder where goodCode = '" & mGoodCode & "' and branchCode = '" & pBranchCode & "'")
        If mGet(0) <> "1" Then
          mSqlText(mLine) = "INSERT INTO PendOrder (branchCode, goodCode, orderDate, pendAmou, unitCode, orderNumb) VALUES ('" & pBranchCode & "', '" & mGoodCode & "', '" & MDYStr(pServerDateTime.Date) & "', " & mGoodAmou & ", '" & mUnitCode & "', '" & mOrderNumb & "')"
          mLine += 1
          mNumb += 1
        End If
      Next
      ' กรณีมีการใช้เลขใบสั่ง
      If mNumb <> getValue(1) Then
        mSqlText(mLine) = "UPDATE BranchInfo set orderNumb = " & mNumb & " WHERE branchCode = '" & pBranchCode & "'"
        mLine += 1
      End If
      ' ถ้าไม่ได้เป็นการสั่งด่วน (สั่งจาก order ทั้งหมด) ให้ลบรายการเดิมด้วย
      If lblUrgentOrder.Visible = False Then
        mSqlText(mLine) = "DELETE FROM TempGoodOrder WHERE branchCode = '" & pBranchCode & "'"
        mLine += 1
      End If

      Dim retValue As String
      retValue = pService.UpdateData("Drug", mSqlText)
      If retValue = "1" Then
        MessageBox.Show("บันทึกสั่งสินค้าเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        ClearAll()
        'ShowTempOrder()
        txtBarcode.Focus()
      Else
        MessageBox.Show(retValue, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      End If

      Me.Cursor = Cursors.Default
    End If
  End Sub

  Private Sub tbnTempSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnTempSave.Click
    If dtgList.Rows.Count > 0 Then
      If CheckDup() = True Then
        Exit Sub
      End If

      Dim mSqlText(dtgList.Rows.Count + 1) As String
      Dim mLine As Integer = 0
      mSqlText(mLine) = "DELETE FROM TempGoodOrder WHERE branchCode = '" & pBranchCode & "'"
      mLine += 1
      For i As Integer = 0 To dtgList.Rows.Count - 1
        mSqlText(mLine) = "INSERT INTO TempGoodOrder (goodCode, barCode, goodAmou, unitCode, branchCode) VALUES ('" & dtgList.Item("goodCode", i).Value.ToString & "', '" & dtgList.Item("barCode", i).Value.ToString & "', " & CInt(dtgList.Item("goodAmou", i).Value) & ", '" & dtgList.Item("unitCode", i).Value.ToString & "', '" & pBranchCode & "')"
        mLine += 1
      Next

      Dim mRet As String
      mRet = pService.UpdateData("Drug", mSqlText)
      If mRet = "1" Then
        MessageBox.Show("บันทึกข้อมูลเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        'ClearAll()
        txtBarcode.Focus()
      Else
        MessageBox.Show(mRet, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
    End If
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub tbnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnRefresh.Click
    ClearAll()
    'ShowTempOrder()
    txtBarcode.Focus()
  End Sub

  Private Sub pdc1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdc1.PrintPage
    Dim prnFont As New Font("CordiaUPC", 12, GraphicsUnit.Point)
    Dim prnFontBold As New Font("CordiaUPC", 16, FontStyle.Bold)
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
    ' ชื่อบริษัท สาขา
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = pCompName
    e.Graphics.DrawString(mText, prnFontBold, Brushes.Black, mRect, mAlign)

    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = " สาขา" & pBranchName
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' หัวเอกสาร
    mLineNo = mLineNo + 1
    mRowPos = mLineNo * mLineSpace
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ใบสั่งสินค้า"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' วันที่-เวลา
    ' ใช้วันที่และเวลาของ server
    pServerDateTime = pService.ServerDateTime

    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = pServerDateTime.ToString("dd/MM/yyyy")
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    ' --------
    mRowPos = mLineNo * 33
    mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)

    For i As Integer = 0 To dtgList.Rows.Count - 1
      ' ลำดับที่
      mLineNo = mLineNo + 1
      mRowPos = mLineNo * mLineSpace
      mRect = New RectangleF(mLeftMargin, mRowPos, 22.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = (i + 1).ToString & "."
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' ชื่อสินค้า
      mRect = New RectangleF(25, mRowPos, 140.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = dtgList.Item("goodName", i).Value.ToString
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' จำนวน
      mRect = New RectangleF(170, mRowPos, 35.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = Format(dtgList.Item("goodAmou", i).Value, "#,##0")
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
      ' หน่วย
      mRect = New RectangleF(210, mRowPos, 45.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = dtgList.Item("unitDesc", i).Value.ToString
      e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    Next
    ' --------
    mRowPos = mLineNo * 32
    mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "-------------------------------------------------------------------"
    e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
    '' จำนวนรายการ
    'mLineNo = mLineNo + 1
    'mRowPos = mLineNo * mLineSpace
    'mRect = New RectangleF(mLeftMargin, mRowPos, 90.0F, 20.0F)
    'mAlign.Alignment = StringAlignment.Near
    'mText = dtgList.Rows.Count.ToString & " รายการ"
    'e.Graphics.DrawString(mText, prnFont, Brushes.Black, mRect, mAlign)
  End Sub

  'Private Sub tbnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnPrint.Click
  '  If dtgList.Rows.Count > 0 Then
  '    pdc1.Print()
  '  End If
  'End Sub

  'Private Sub tbnPendOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnPendOrder.Click
  '  Dim fPendOrder As New frmPendOrder
  '  fPendOrder.ShowDialog()
  '  fPendOrder = Nothing
  'End Sub

  Private Sub tbnUrgentOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnUrgentOrder.Click
    ClearAll()
    tbnTempSave.Enabled = False
    lblUrgentOrder.Visible = True
  End Sub

  Private Sub StartSearch(ByVal mCondition As String)
    Me.Cursor = Cursors.WaitCursor
    dtgGoodSearch.Rows.Clear()
    Dim dsGood As New DataSet
    Dim mSqlText As String
    mSqlText = "SELECT GI.goodCode, GI.goodName, UI.unitDesc, GI." & mMiniStockField & " As miniStock, GI." & mStockOnhandField & " As stockOnhand, GI.stockOnhand0, GI.stockOnhandDN, GI.goodRema, GI.unitCode, GB." & mPriceField & " As unitPrice, GB.barCode, UI2.unitDesc as pricePackDesc, TI.typeDesc, PI.unitFactor, PI.unitDesc as packDesc FROM GoodInfo GI INNER JOIN UnitInfo UI ON GI.unitCode = UI.unitCode INNER JOIN UnitInfo PI ON GI.packCode = PI.unitCode INNER JOIN TypeInfo TI ON TI.typeCode = GI.typeCode Left Outer JOIN (SELECT DISTINCT goodCode, barCode, " & mPriceField & ", unitCode FROM GoodBarcode WHERE LEN(barCode) = '6' AND goodAmou = 1) GB ON GB.goodCode = GI.goodCode inner join UnitInfo UI2 on UI2.unitCode = GB.unitCode WHERE " & mCondition & " And GI.noBranchStock = '0' And GI.goodStat = '1' ORDER BY GI.goodName"

    dsGood = pService.SelectData("Drug", mSqlText)
    If IsNothing(dsGood) = False Then
      Dim dvGood As New DataView(dsGood.Tables(0))
      For i As Integer = 0 To dvGood.Count - 1
        With dvGood.Item(i)
          dtgGoodSearch.Rows.Add()
          dtgGoodSearch.Item("SGoodCode", i).Value = .Item("goodCode")
          dtgGoodSearch.Item("SBarCode", i).Value = .Item("barCode")
          dtgGoodSearch.Item("SGoodName", i).Value = .Item("goodName")
          dtgGoodSearch.Item("SUnitCode", i).Value = .Item("unitCode")
          dtgGoodSearch.Item("SUnitDesc", i).Value = .Item("pricePackDesc")
          If IsDBNull(.Item("unitPrice")) = False Then
            dtgGoodSearch.Item("SUnitPrice", i).Value = .Item("unitPrice")
          Else
            dtgGoodSearch.Item("SUnitPrice", i).Value = 0
          End If
          dtgGoodSearch.Item("SStockOnhand", i).Value = .Item("stockOnhand")
          dtgGoodSearch.Item("SMiniStock", i).Value = .Item("miniStock")
          dtgGoodSearch.Item("SGoodRema", i).Value = .Item("goodRema")
          dtgGoodSearch.Item("STypeDesc", i).Value = .Item("typeDesc")
          dtgGoodSearch.Item("SStockOnhand0", i).Value = .Item("stockOnhand0")
          dtgGoodSearch.Item("SStockOnhandDN", i).Value = .Item("stockOnhandDN")
          dtgGoodSearch.Item("SPackAmou", i).Value = .Item("unitFactor")
          dtgGoodSearch.Item("SPackDesc", i).Value = .Item("packDesc")
        End With
      Next
      dvGood = Nothing
    End If
    dsGood = Nothing
    CheckListDup()
    dtgGoodSearch.Focus()
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub dtgGoodSearch_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgGoodSearch.CellDoubleClick
    ShowGood("", dtgGoodSearch.Item("SBarCode", e.RowIndex).Value.ToString)
  End Sub

  'Private Sub AddList2()
  '  ' Check Priv
  '  If InStr(pUserPriv, Me.Tag.ToString & "A") <= 0 Then
  '    Exit Sub
  '  End If
  '  ' เพิ่มรายการอัตโนมัติ
  '  Dim mCurrentRow As Integer
  '  mCurrentRow = dtgGoodSearch.CurrentRow.Index

  '  Dim mDup As Boolean = False
  '  ' เช็ครายการซ้ำ
  '  For i As Integer = 0 To dtgList.Rows.Count - 1
  '    If dtgList.Item("goodCode", i).Value.ToString = dtgGoodSearch.Item("SGoodCode", mCurrentRow).Value.ToString Then
  '      mDup = True
  '      Exit Sub
  '    End If
  '  Next
  '  ' เช็คซ้ำในรายการค้างส่ง
  '  If CheckPendOrder(dtgGoodSearch.Item("SGoodCode", mCurrentRow).Value.ToString) = True Then
  '    If MessageBox.Show("รายการสินค้าซ้ำกับรายการค้างส่ง ต้องการสั่งซ้ำหรือไม่", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
  '      Exit Sub
  '    End If
  '  End If

  '  Dim mGoodCode As String
  '  Dim mOrderAmou As Integer
  '  Dim mPackFactor As Integer

  '  mGoodCode = dtgGoodSearch.Item("SGoodCode", mCurrentRow).Value.ToString
  '  mPackFactor = CInt(dtgGoodSearch.Item("SPackAmou", mCurrentRow).Value)
  '  mOrderAmou = OrderAmou(mGoodCode)

  '  ' ปรับจำนวนสั่ง ให้พอดีกับขนาดบรรจุที่กำหนดไว้ (packAmou) เฉพาะสาขาที่เข้า ship to และสินค้านั้นกำหนดให้ ship to
  '  If pIsBranchShipTo = True And IsShipTo(mGoodCode) <> "" Then
  '    mOrderAmou = CInt(mOrderAmou / mPackFactor) * mPackFactor
  '    ' ถ้าปรับแล้วได้น้อยกว่าขนาดบรรจุ ให้จำนวนสั่งเท่ากับขนาดบรรจุที่กำหนด
  '    If mOrderAmou <= mPackFactor Then
  '      mOrderAmou = mPackFactor
  '    End If
  '  End If

  '  dtgList.Rows.Add()
  '  dtgList.Item("item", dtgList.Rows.Count - 1).Value = dtgList.Rows.Count
  '  dtgList.Item("goodCode", dtgList.Rows.Count - 1).Value = mGoodCode
  '  dtgList.Item("barCode", dtgList.Rows.Count - 1).Value = dtgGoodSearch.Item("SBarCode", mCurrentRow).Value
  '  dtgList.Item("goodName", dtgList.Rows.Count - 1).Value = dtgGoodSearch.Item("SGoodName", mCurrentRow).Value
  '  dtgList.Item("goodAmou", dtgList.Rows.Count - 1).Value = mOrderAmou
  '  dtgList.Item("unitDesc", dtgList.Rows.Count - 1).Value = dtgGoodSearch.Item("SUnitDesc", mCurrentRow).Value
  '  dtgList.Item("unitCode", dtgList.Rows.Count - 1).Value = dtgGoodSearch.Item("SUnitCode", mCurrentRow).Value
  '  dtgList.Item("stockOnhand", dtgList.Rows.Count - 1).Value = dtgGoodSearch.Item("SStockOnhand", mCurrentRow).Value
  '  dtgList.Item("stockOnhand0", dtgList.Rows.Count - 1).Value = dtgGoodSearch.Item("SStockOnhand0", mCurrentRow).Value
  '  dtgList.Item("stockOnhandDN", dtgList.Rows.Count - 1).Value = dtgGoodSearch.Item("SStockOnhandDN", mCurrentRow).Value
  '  dtgList.Item("miniStock", dtgList.Rows.Count - 1).Value = dtgGoodSearch.Item("SMiniStock", mCurrentRow).Value
  '  dtgList.Item("typeDesc", dtgList.Rows.Count - 1).Value = dtgGoodSearch.Item("STypeDesc", mCurrentRow).Value
  '  dtgList.Item("unitPrice", dtgList.Rows.Count - 1).Value = dtgGoodSearch.Item("SUnitPrice", mCurrentRow).Value

  '  ''shipTo
  '  'Dim mGet() As String
  '  'mGet = pService.GetData("Drug", "Select shipTo from CompGood CG inner join CompInfo CI on CG.compCode = CI.compCode where CG.goodCode = '" & mGoodCode & "'")
  '  'If mGet(0) = "1" Then
  '  '  mShipTo = mGet(1)
  '  'Else
  '  '  mShipTo = ""
  '  'End If

  '  ' เฉพาะสาขาที่เซ็ทให้เป็น ship to
  '  If pIsBranchShipTo = True Then
  '    dtgList.Item("shipTo", dtgList.Rows.Count - 1).Value = IsShipTo(mGoodCode)
  '  Else
  '    dtgList.Item("shipTo", dtgList.Rows.Count - 1).Value = ""
  '  End If


  '  'MarkItem()
  '  EnableCellEdit()
  '  CalTotalPrice()

  '  dtgList.FirstDisplayedScrollingRowIndex = dtgList.Rows.Count - 1
  '  dtgList.ClearSelection()

  '  CheckListDup()
  'End Sub

  Private Function IsShipTo(ByVal GoodCode As String) As String
    Dim mShipTo As String
    'shipTo
    Dim mGet() As String
    mGet = pService.GetData("Drug", "Select CI.shipTo from CompInfo CI inner join CompGood CG on CI.compCode = CG.compCode where CG.goodCode = '" & GoodCode & "' and CG.isShipTo = '1'")
    If mGet(0) = "1" Then
      mShipTo = mGet(1)
    Else
      mShipTo = ""
    End If
    Return mShipTo
  End Function

  Private Sub CheckListDup()
    Dim mGoodCode As String
    Dim mStockOnhand As Integer
    Dim mMiniStock As Integer
    For i As Integer = 0 To dtgGoodSearch.Rows.Count - 1
      mGoodCode = dtgGoodSearch.Item("SGoodCode", i).Value.ToString
      mStockOnhand = CInt(dtgGoodSearch.Item("SStockOnhand", i).Value)
      mMiniStock = CInt(dtgGoodSearch.Item("SMiniStock", i).Value)
      dtgGoodSearch.Rows(i).DefaultCellStyle.BackColor = Color.White
      For x As Integer = 0 To dtgList.Rows.Count - 1
        If dtgList.Item("GoodCode", x).Value.ToString = mGoodCode Then
          dtgGoodSearch.Rows(i).DefaultCellStyle.BackColor = Color.Thistle
        End If
      Next
      ' ถ้าคงเหลือน้อยกว่าจุดสั่งซื้อ ให้แสดงเป็นตัวอักษรสีแดง
      If mMiniStock > 0 AndAlso mStockOnhand <= mMiniStock Then
        dtgGoodSearch.Item("SStockOnhand", i).Style.ForeColor = Color.Red
      End If
    Next
  End Sub

  Private Function OrderAmou(ByVal GoodCode As String) As Integer
    If GoodCode = "" Then
      Return 0
    End If

    Me.Cursor = Cursors.WaitCursor
    Dim mOrderAmou As Integer
    Dim mGet() As String
    mGet = pService.GetData("Drug", "select top 1 OL.goodAmou from OrderList OL inner join HistOrder HO on HO.orderNumb = OL.orderNumb Where OL.goodCode = '" & GoodCode & "' and HO.branchCode = '" & pBranchCode & "' Order by HO.orderDate Desc")
    If mGet(0) = "1" Then
      mOrderAmou = CInt(mGet(1))
    Else
      mOrderAmou = 0
    End If
    Me.Cursor = Cursors.Default
    Return mOrderAmou
  End Function

  Private Sub ShowGoodType()
    cboTypeCode.Items.Clear()
    cboTypeDesc.Items.Clear()
    cboTypeCode.Items.Add("0")
    cboTypeDesc.Items.Add("ทั้งหมด")
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select typeCode, typeDesc From TypeInfo Order by typeDesc")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        cboTypeCode.Items.Add(dv.Item(i).Item("typeCode"))
        cboTypeDesc.Items.Add(dv.Item(i).Item("typeDesc"))
      Next
      dv = Nothing
    End If
    ds = Nothing
    cboTypeDesc.SelectedIndex = 0
  End Sub

  Private Sub cboTypeDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTypeDesc.SelectedIndexChanged
    cboTypeCode.SelectedIndex = cboTypeDesc.SelectedIndex
  End Sub

  'Private Function CheckPendOrder(ByVal GoodCode As String) As Boolean
  '  If GoodCode = "" Then
  '    Return False
  '  End If

  '  Dim mGet() As String
  '  mGet = pService.GetData("Drug", "Select goodCode From PendOrder Where goodCode = '" & GoodCode & "' And branchCode = '" & pBranchCode & "'")
  '  If mGet(0) = "1" Then
  '    Return True
  '  Else
  '    Return False
  '  End If
  'End Function

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    Dim mCondition As String = ""

    If txtName.Text <> "" Then
      mCondition = "GI.goodName like '%" & txtName.Text & "%'"
    End If

    If chkMiniStock.Checked = True Then
      If mCondition <> "" Then
        mCondition = mCondition & " And "
      End If
      mCondition = mCondition & "GI." & mMiniStockField & " > 0 AND GI." & mStockOnhandField & " <= GI." & mMiniStockField
    End If

    If cboTypeDesc.Text <> "ทั้งหมด" Then
      If mCondition <> "" Then
        mCondition = mCondition & " And "
      End If
      mCondition = mCondition & "GI.typeCode = '" & cboTypeCode.Text & "'"
    End If

    If mCondition <> "" Then
      StartSearch(mCondition)
    End If
  End Sub

  Private Sub tbnImportList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnImportList.Click
    Dim mOrderNumb As String
    mOrderNumb = InputBox("จากใบสั่งสินค้าเลขที่ :", "นำเข้ารายการ")
    If mOrderNumb = "" Then
      Exit Sub
    End If

    Me.Cursor = Cursors.WaitCursor
    Dim ds As New DataSet
    Dim mSqlText As String
    mSqlText = "Select OL.goodCode, OL.goodAmou, OL.unitCode, GI.goodName, GI.stockOnhand0, GI.stockOnhandDN, GI.bookAmouBranch, GI.bookAmouDN, GI.unitCost0 as unitCost, UI.unitDesc, UI.unitFactor, GI." & mStockOnhandField & " As stockOnhand, GI." & mMiniStockField & " As miniStock, TI.typeDesc, GB.barCode, GB." & mPriceField & " From OrderList OL Inner Join GoodInfo GI On GI.goodCode = OL.goodCode Inner Join UnitInfo UI On UI.unitCode = OL.unitCode Inner Join TypeInfo TI On TI.typeCode = GI.typeCode Left Outer Join (Select goodCode, barCode, " & mPriceField & " From GoodBarCode Where goodAmou = 1 and len(barCode) = 6) GB On GB.goodCode = OL.goodCode Where OL.orderNumb = '" & mOrderNumb & "' Order by GI.goodName"
    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        'dtgList.Rows.Clear()
        Dim mUnitFactor As Integer
        Dim mOrderAmou As Integer
        Dim mStockOnhand0, mStockOnhandDN As Integer
        Dim mBookAmouBranch, mBookAmouDN As Integer
        Dim mAvaiOnhand As Integer

        Dim mDup As Boolean
        For i As Integer = 0 To dv.Count - 1
          mDup = False
          With dv.Item(i)

            ' เช็คซ้ำในรายการสั่ง
            For x As Integer = 0 To dtgList.Rows.Count - 1
              If dtgList.Item("goodCode", x).Value.ToString = .Item("goodCode").ToString Then
                mDup = True
                Exit For
              End If
            Next
            If mDup = False Then
              dtgList.Rows.Add()
              mUnitFactor = .Item("unitFactor")
              mOrderAmou = .Item("goodAmou")
              mStockOnhand0 = .Item("stockOnhand0")
              mStockOnhandDN = .Item("stockOnhandDN")
              mBookAmouBranch = .Item("bookAmouBranch")
              mBookAmouDN = .Item("bookAmouDN")
              mAvaiOnhand = CheckAvaiOnhand(.Item("goodCode"))
              'mAvaiOnhand = mStockOnhand0 + mStockOnhandDN - mBookAmouBranch - mBookAmouDN

              dtgList.Item("item", dtgList.Rows.Count - 1).Value = i + 1
              dtgList.Item("goodCode", dtgList.Rows.Count - 1).Value = .Item("goodCode")
              dtgList.Item("barCode", dtgList.Rows.Count - 1).Value = .Item("barCode")
              dtgList.Item("goodName", dtgList.Rows.Count - 1).Value = .Item("goodName")
              dtgList.Item("goodAmou", dtgList.Rows.Count - 1).Value = .Item("goodAmou")
              dtgList.Item("unitDesc", dtgList.Rows.Count - 1).Value = .Item("unitDesc")
              dtgList.Item("unitCode", dtgList.Rows.Count - 1).Value = .Item("unitCode")
              dtgList.Item("stockOnhand", dtgList.Rows.Count - 1).Value = .Item("stockOnhand")
              dtgList.Item("stockOnhand0", dtgList.Rows.Count - 1).Value = mStockOnhand0
              dtgList.Item("stockOnhandDN", dtgList.Rows.Count - 1).Value = mStockOnhandDN
              dtgList.Item("avaiOnhand", dtgList.Rows.Count - 1).Value = mAvaiOnhand
              dtgList.Item("miniStock", dtgList.Rows.Count - 1).Value = .Item("miniStock")
              dtgList.Item("typeDesc", dtgList.Rows.Count - 1).Value = .Item("typeDesc")
              dtgList.Item("unitPrice", dtgList.Rows.Count - 1).Value = .Item(mPriceField)
              dtgList.Item("shipTo", dtgList.Rows.Count - 1).Value = ""

              ' ถ้าสต๊อคกลางไม่พอส่ง เฉพาะสินค้าที่ไม่ใช่ shipto
              If (mOrderAmou * mUnitFactor) > mAvaiOnhand And IsShipTo(.Item("goodCode").ToString) = "" Then
                dtgList.Rows(dtgList.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Red
              Else
                dtgList.Rows(dtgList.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Black
              End If
            End If
          End With
        Next
        'MarkItem()
        CheckListDup()
      Else
        MessageBox.Show("ไม่มีข้อมูลการสั่งสินค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End If
      dv = Nothing
    Else
      MessageBox.Show("ไม่พบข้อมูลใบสั่งสินค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End If
    ds = Nothing
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub CalTotalPrice()
    Dim mTotalPrice As Double
    mTotalPrice = 0
    For Each mRow As DataGridViewRow In dtgList.Rows
      mTotalPrice += CDbl(dtgList.Item("unitPrice", mRow.Index).Value) * CInt(dtgList.Item("goodAmou", mRow.Index).Value)
    Next
    lblTotalPrice.Text = Format(mTotalPrice, "#,##0.00")
  End Sub

  'Private Function CheckAvaiStock() As Boolean
  '  Dim mGoodCode As String
  '  Dim mOrderAmou As Integer
  '  Dim mUnitFactor As Integer
  '  Dim mAllAvaiStock As Boolean
  '  Dim mAvaiOnhand As Integer
  '  Dim mIsShipTo As Boolean

  '  mAllAvaiStock = True
  '  For i As Integer = 0 To dtgList.Rows.Count - 1
  '    mGoodCode = dtgList.Item("goodCode", i).Value.ToString
  '    mOrderAmou = dtgList.Item("goodAmou", i).Value
  '    mUnitFactor = dtgList.Item("unitFactor", i).Value
  '    mAvaiOnhand = CheckAvaiOnhand(mGoodCode)
  '    dtgList.Item("avaiOnhand", i).Value = mAvaiOnhand

  '    If dtgList.Item("shipTo", i).Value.ToString = "" Then
  '      mIsShipTo = False
  '    Else
  '      mIsShipTo = True
  '    End If
  '    ' เช็คเฉพาะสินค้าที่ไม่ใช่ ship to
  '    If mIsShipTo = False AndAlso (mOrderAmou * mUnitFactor) > mAvaiOnhand Then
  '      dtgList.Rows(i).DefaultCellStyle.ForeColor = Color.Red
  '      mAllAvaiStock = False
  '    Else
  '      dtgList.Rows(i).DefaultCellStyle.ForeColor = Color.Black
  '    End If
  '  Next

  '  If mAllAvaiStock = False Then
  '    pMessageBox = New MyMessageBox("มีสินค้าบางรายการที่สต๊อคไม่เพียงพอจัดส่งได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
  '    pMessageBox.Show()
  '  End If

  '  Return mAllAvaiStock
  'End Function

  Private Function CheckAvaiOnhand(ByVal GoodCode As String) As Integer
    Dim mTotalOnhand As Integer
    Dim mTotalBook As Integer
    'Dim mAvaiOnhand As Integer
    Dim mGet() As String
    ' สต๊อคคงเหลือ HUG + DN
    mGet = pService.GetData("Drug", "Select stockOnhand0 + stockOnhandDN from GoodInfo where goodCode = '" & GoodCode & "'")
    If mGet(0) = "1" Then
      mTotalOnhand = CInt(mGet(1))
    Else
      mTotalOnhand = 0
    End If
    ' ยอดจอง HUG + DN
    mGet = pService.GetData("Drug", "Select sum(bookAmou) from GoodBooking where goodCode = '" & GoodCode & "'")
    If mGet(0) = "1" Then
      mTotalBook = CInt(mGet(1))
    Else
      mTotalBook = 0
    End If

    Return mTotalOnhand - mTotalBook

    'mGet = pService.GetData("Drug", "Select stockOnhand0 + stockOnhandDN - bookAmouBranch - bookAmouDN as avaiOnhand from GoodInfo where goodCode = '" & GoodCode & "'")
    'If mGet(0) = "1" Then
    '  mAvaiOnhand = CInt(mGet(1))
    'Else
    '  mAvaiOnhand = 0
    'End If
    'Return mAvaiOnhand
  End Function

  Private Sub CheckAvaiStock()
    Dim ds As New DataSet
    Dim mSqlText As String
    mSqlText = "Select GI.goodCode, GI.stockOnhand0 + GI.stockOnhandDN as totalOnhand, GK.totalBook from GoodInfo GI left join (select goodCode, sum(bookAmou) as totalBook from GoodBooking where bookStat = '1' group by goodCode) GK on GK.goodCode = GI.goodCode Where GI.goodStat = '1'"

    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        Dim mGoodCode As String
        Dim mAvaiAmou As Integer
        Dim mTotalOnhand As Integer
        Dim mTotalBook As Integer
        For Each mRow As DataGridViewRow In dtgList.Rows
          mGoodCode = dtgList.Item("goodCode", mRow.Index).Value
          mAvaiAmou = 0
          For i As Integer = 0 To dv.Count - 1
            With dv.Item(i)
              If .Item("goodCode") = mGoodCode Then
                mTotalOnhand = .Item("totalOnhand")
                If IsDBNull(.Item("totalBook")) = False Then
                  mTotalBook = .Item("totalBook")
                Else
                  mTotalBook = 0
                End If
                mAvaiAmou = mTotalOnhand - mTotalBook
                Exit For
              End If
            End With
          Next
          dtgList.Item("avaiOnhand", mRow.Index).Value = mAvaiAmou
        Next
      End If
    End If
    ds = Nothing
  End Sub

  Private Sub tbnPendOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnPendOrder.Click
    frmPendOrder.ShowDialog()
    'If frmPendOrder.pImport = True Then
    '  ShowPendOrder(frmPendOrder.pGoodCode)
    'End If
    frmPendOrder = Nothing
  End Sub

  Private Function CheckDup() As Boolean
    Dim mReturn As Boolean = False
    If dtgList.Rows.Count > 0 Then
      Dim mGoodCode As String
      For x As Integer = 0 To dtgList.Rows.Count - 1
        mGoodCode = dtgList.Item("goodCode", x).Value
        For y As Integer = 0 To dtgList.Rows.Count - 1
          If y <> x And dtgList.Item("goodCode", y).Value = mGoodCode Then
            MessageBox.Show("รายการซ้ำ : " & dtgList.Item("goodName", y).Value, "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            mReturn = True
            Exit For
          End If
        Next
        If mReturn = True Then
          Exit For
        End If
      Next
    End If

    Return mReturn
  End Function
End Class
