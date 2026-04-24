Imports CrystalDecisions.Shared

Public Class frmRpMonthGoodUse

  Dim mSqlText As String
  Dim mStockOnhandField As String
  Dim mLastSaleField As String
  Dim mUnitPriceField As String
  Dim mCompCode As String
  Dim dvOnhand As DataView

  Private Sub frmRpMonthGoodUse_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    Me.WindowState = FormWindowState.Normal
  End Sub

  Private Sub frmRpGoodUsePerMonth_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Icon = frmMain.Icon

    dtpSale.Value = Date.Today

    ShowIndi()
    ' เรียงจาก
    cboSortDirection.Items.Clear()
    cboSortDirection.Items.Add("น้อยไปมาก")
    cboSortDirection.Items.Add("มากไปน้อย")
    cboSortDirection.SelectedIndex = 0

  End Sub

  Private Sub ShowIndi()
    Me.Cursor = Cursors.WaitCursor
    cboIndiCode.Items.Clear()
    cboIndiDesc.Items.Clear()
    cboIndiCode.Items.Add("0")
    cboIndiDesc.Items.Add("ทั้งหมด")
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "SELECT * FROM IndiGroup ORDER BY IndiDesc")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        cboIndiCode.Items.Add(dv.Item(i).Item("IndiCode"))
        cboIndiDesc.Items.Add(dv.Item(i).Item("IndiDesc"))
      Next
      dv = Nothing
    End If
    ds = Nothing
    cboIndiDesc.SelectedIndex = 0

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub cboIndiDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIndiDesc.SelectedIndexChanged
    cboIndiCode.SelectedIndex = cboIndiDesc.SelectedIndex
  End Sub

  Private Sub ViewReport()
    Me.Cursor = Cursors.WaitCursor

    mStockOnhandField = "stockOnhand" & pBranchCode
    mLastSaleField = "lastSale" & pBranchCode
    mUnitPriceField = "price" & pBranchPrice

    ' ถ้าต้องการดูรายงานย้อนหลัง ให้ใช้สต๊อคคงเหลือจาก StockOnhandBack
    If dtpSale.Value <> Date.Today Then
      Dim dsOnhand As New DataSet
      mSqlText = "Select GI.goodName, SB." & mStockOnhandField & " as stockOnhand from StockOnhandBack SB inner join GoodInfo GI on GI.goodCode = SB.goodCode Where SB.stockDate = '" & MDYStr(dtpSale.Value) & "'"
      If cboIndiDesc.Text <> "ทั้งหมด" Then
        mSqlText = mSqlText & " and GI.indiCode = '" & cboIndiCode.Text & "'"
      End If
      If txtGoodName.Text <> "" Then
        mSqlText = mSqlText & " and GI.goodName = '" & Replace(txtGoodName.Text, "'", "''") & "'"
      End If

      dsOnhand = pService.SelectData("Drug", mSqlText)
      If IsNothing(dsOnhand) = False Then
        dvOnhand = New DataView(dsOnhand.Tables(0))
        If dvOnhand.Count <= 0 Then
          MessageBox.Show("ไม่พบข้อมูลสต๊อคคงเหลือ ณ วันที่ " & ThaiDate(dtpSale.Value) & vbCrLf & " ไม่สามารถออกรายงานได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
          Me.Cursor = Cursors.Default
          Exit Sub
        End If
      Else
        MessageBox.Show("ไม่พบข้อมูลสต๊อคคงเหลือ ณ วันที่ " & ThaiDate(dtpSale.Value) & vbCrLf & " ไม่สามารถออกรายงานได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Exit Sub
      End If
    End If

    Dim ds As New DataSet

    ds = New DataSet("dsDrug")

    Dim dt As New DataTable("dtMonthGoodUse")
    Dim dr As DataRow

    dt.Columns.Add("groupName", Type.GetType("System.String"))
    dt.Columns.Add("goodName", Type.GetType("System.String"))
    dt.Columns.Add("stockOnhand", Type.GetType("System.Int32"))
    dt.Columns.Add("stockCost", Type.GetType("System.Double"))
    dt.Columns.Add("salePerMonth", Type.GetType("System.Double"))
    dt.Columns.Add("monthUseIndex", Type.GetType("System.Double"))
    dt.Columns.Add("lastSale", Type.GetType("System.DateTime"))
    dt.Columns.Add("noSale", Type.GetType("System.Boolean"))

    ds.Tables.Add(dt)

    Dim ds2 As New DataSet
    Dim mFromDate As Date
    Dim mToDate As Date
    Dim mSalePerMonth As Double
    Dim mStockOnhand As Integer
    Dim mUnitPrice As Double
    Dim mMonthUseIndex As Double
    Dim mNoSale As Boolean

    mToDate = dtpSale.Value
    mFromDate = mToDate.AddMonths(-3) ' คำนวณย้อนหลัง 3 เดือน

    'If txtCompName.Text <> "" Then
    '  ' แยกตามซัพพลายเออร์
    '  mSqlText = "SELECT CG.compName as groupName, GI.goodName, GI." & mLastSaleField & " as lastSale, GB.unitPrice, GI." & mStockOnhandField & " as stockOnhand, sum(SL.goodAmou * SL.unitFactor) as totalSaleAmou from GoodInfo GI inner join IndiGroup IG on IG.indiCode = GI.indiCode inner join (select distinct GB.goodCode, GB." & mUnitPriceField & " as unitPrice FROM GoodBarcode GB inner join GoodInfo GI on GI.goodCode = GB.goodCode WHERE GI.unitCode = GB.unitCode and GB.goodAmou = 1) GB on GB.goodCode = GI.goodCode right join (Select distinct CI.compName, CG.goodCode from CompGood CG inner join CompInfo CI on CI.compCode = CG.compCode where CI.compCode = '" & mCompCode & "') CG on CG.goodCode = GI.goodCode left join (select SL.goodCode, SL.goodAmou, UI.unitFactor, HS.saleStat from SaleList SL inner join HistSale HS on HS.saleNumb = SL.saleNumb inner join UnitInfo UI on UI.unitCode = SL.unitCode where HS.saleStat <> '0' and HS.saleDate >= '" & MDYStr(mFromDate) & "' and HS.saleDate <= '" & MDYStr(mToDate) & "' and HS.branchCode = '" & pBranchCode & "') SL on SL.goodCode = GI.goodCode where SL.saleStat <> '0'"

    '  If cboIndiDesc.Text <> "ทั้งหมด" Then
    '    mSqlText = mSqlText & " and GI.indiCode = '" & cboIndiCode.Text & "'"
    '  End If

    '  If txtGoodName.Text <> "" Then
    '    mSqlText = mSqlText & " and GI.goodName like '" & Replace(txtGoodName.Text, "'", "''") & "%'"
    '  End If

    '  mSqlText = mSqlText & " group by CG.compName, GI.goodName, GI." & mLastSaleField & ", GB.unitPrice, GI." & mStockOnhandField

    'Else
    '  mSqlText = "SELECT IG.indiDesc as groupName, GI.goodName, GI." & mLastSaleField & " as lastSale, GB.unitPrice, GI." & mStockOnhandField & " as stockOnhand, sum(SL.goodAmou * SL.unitFactor) as totalSaleAmou from GoodInfo GI inner join IndiGroup IG on IG.indiCode = GI.indiCode inner join (select distinct GB.goodCode, GB." & mUnitPriceField & " as unitPrice FROM GoodBarcode GB inner join GoodInfo GI on GI.goodCode = GB.goodCode WHERE GI.unitCode = GB.unitCode and GB.goodAmou = 1) GB on GB.goodCode = GI.goodCode left join (select SL.goodCode, SL.goodAmou, UI.unitFactor, HS.saleStat from SaleList SL inner join HistSale HS on HS.saleNumb = SL.saleNumb inner join UnitInfo UI on UI.unitCode = SL.unitCode where HS.saleDate >= '" & MDYStr(mFromDate) & "' and HS.saleDate <= '" & MDYStr(mToDate) & "' and HS.branchCode = '" & pBranchCode & "') SL on SL.goodCode = GI.goodCode where SL.saleStat <> '0'"

    '  If cboIndiDesc.Text <> "ทั้งหมด" Then
    '    mSqlText = mSqlText & " and GI.indiCode = '" & cboIndiCode.Text & "'"
    '  End If

    '  If txtGoodName.Text <> "" Then
    '    mSqlText = mSqlText & " and GI.goodName like '%" & Replace(txtGoodName.Text, "'", "''") & "%'"
    '  End If

    '  mSqlText = mSqlText & " group by IG.indiDesc, GI.goodName, GI." & mLastSaleField & ", GB.unitPrice, GI." & mStockOnhandField

    'End If

    mSqlText = "SELECT IG.indiDesc as groupName, GI.goodName, GI." & mLastSaleField & " as lastSale, GB.unitPrice, GI." & mStockOnhandField & " as stockOnhand, sum(SL.goodAmou * SL.unitFactor) as totalSaleAmou from GoodInfo GI inner join IndiGroup IG on IG.indiCode = GI.indiCode inner join (select distinct GB.goodCode, GB." & mUnitPriceField & " as unitPrice FROM GoodBarcode GB inner join GoodInfo GI on GI.goodCode = GB.goodCode WHERE GI.unitCode = GB.unitCode and GB.goodAmou = 1) GB on GB.goodCode = GI.goodCode"

    If txtCompName.Text <> "" Then
      mSqlText = mSqlText & " right join (Select distinct CI.compName, CG.goodCode from CompGood CG inner join CompInfo CI on CI.compCode = CG.compCode where CI.compCode = '" & mCompCode & "') CG on CG.goodCode = GI.goodCode"
    End If

    mSqlText = mSqlText & " left join (select SL.goodCode, SL.goodAmou, UI.unitFactor, HS.saleStat from SaleList SL inner join HistSale HS on HS.saleNumb = SL.saleNumb inner join UnitInfo UI on UI.unitCode = SL.unitCode where HS.saleDate >= '" & MDYStr(mFromDate) & "' and HS.saleDate <= '" & MDYStr(mToDate) & "' and HS.branchCode = '" & pBranchCode & "') SL on SL.goodCode = GI.goodCode where SL.saleStat <> '0'"

    If cboIndiDesc.Text <> "ทั้งหมด" Then
      mSqlText = mSqlText & " and GI.indiCode = '" & cboIndiCode.Text & "'"
    End If

    If txtGoodName.Text <> "" Then
      mSqlText = mSqlText & " and GI.goodName like '%" & Replace(txtGoodName.Text, "'", "''") & "%'"
    End If

    mSqlText = mSqlText & " group by IG.indiDesc, GI.goodName, GI." & mLastSaleField & ", GB.unitPrice, GI." & mStockOnhandField

    ds2 = pService.SelectData2("Drug", mSqlText)

    If IsNothing(ds2) = False Then
      Dim dv As New DataView(ds2.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          ' แสดงเฉพาะรายการที่สต๊อคคงเหลือมากกว่า 0 หรือมียอดขายย้อนหลังสามเดือน
          If (IsDBNull(.Item("stockOnhand")) = False AndAlso .Item("stockOnhand") > 0) Or IsDBNull(.Item("totalSaleAmou")) = False Then
            If IsDBNull(.Item("totalSaleAmou")) = True Then
              mSalePerMonth = 0
            Else
              mSalePerMonth = CInt(.Item("totalSaleAmou")) / 3
            End If

            ' ถ้ารายงาน ณ วันที่ย้อนหลัง ให้ใช้สต๊อคคงเหลือจากข้อมูลแบ็คอัพ
            If dtpSale.Value <> Date.Today Then
              mStockOnhand = 0
              For m As Integer = 0 To dvOnhand.Count - 1
                If dvOnhand.Item(m).Item("goodName").ToString = .Item("goodName").ToString Then
                  mStockOnhand = dvOnhand.Item(m).Item("stockOnhand")
                  Exit For
                End If
              Next
            Else
              mStockOnhand = CInt(.Item("stockOnhand"))
            End If

            mUnitPrice = CDbl(.Item("unitPrice"))

            If mSalePerMonth > 0 Then
              mMonthUseIndex = mStockOnhand / mSalePerMonth
              mNoSale = False
            Else
              mMonthUseIndex = 0
              mNoSale = True
            End If

            If txtMonthUse.Text = "" Or (txtMonthUse.Text <> "" AndAlso mMonthUseIndex >= Val(txtMonthUse.Text)) Then
              dr = ds.Tables(0).NewRow
              'If cboIndiDesc.Text = "ทั้งหมด" Then
              '  dr("groupName") = "ทั้งหมด"
              'Else
              '  dr("groupName") = .Item("groupName")
              'End If

              dr("groupName") = .Item("groupName")

              dr("goodName") = .Item("goodName")
              dr("stockOnhand") = mStockOnhand
              dr("stockCost") = mStockOnhand * mUnitPrice ' มูลค่าคงเหลือ ให้คำนวณจากราคาขาย
              dr("salePerMonth") = mSalePerMonth
              dr("monthUseIndex") = mMonthUseIndex
              dr("lastSale") = .Item("lastSale")
              dr("noSale") = mNoSale
              ds.Tables(0).Rows.Add(dr)
            End If
          End If
        End With
      Next
      dv = Nothing
    End If
    ds2 = Nothing

    Dim mReport As New rpMonthGoodUse
    mReport.SetDataSource(ds)
    mReport.SetParameterValue("prCompFullName", pCompFullName)
    mReport.SetParameterValue("prBranchName", "สาขา " & pBranchName)
    mReport.SetParameterValue("prBetween", "ณ วันที่ " & ThaiDate(dtpSale.Value))
    mReport.PrintOptions.PrinterName = pDefaultReportPrinterName

    If txtMonthUse.Text <> "" Then
      mReport.SetParameterValue("prCondition", "เงื่อนไข : จำนวนเดือนการใช้มากกว่า " & Val(txtMonthUse.Text).ToString)
    Else
      mReport.SetParameterValue("prCondition", "")
    End If

    If cboSortDirection.Text = "น้อยไปมาก" Then
      mReport.DataDefinition.SortFields.Item(1).SortDirection = SortDirection.AscendingOrder
    Else
      mReport.DataDefinition.SortFields.Item(1).SortDirection = SortDirection.DescendingOrder
    End If

    Dim mView As New frmViewReport
    mView.MdiParent = frmMain
    mView.pTitle = Me.Text
    mView.ctrView.ReportSource = mReport
    mView.Show()

    If InStr(pUserPriv, Me.Tag.ToString & "P") > 0 Then
      mView.ctrView.ShowPrintButton = True
    Else
      mView.ctrView.ShowPrintButton = False
    End If
    If InStr(pUserPriv, Me.Tag.ToString & "X") > 0 Then
      mView.ctrView.ShowExportButton = True
    Else
      mView.ctrView.ShowExportButton = False
    End If

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    If pDefaultReportPrinterName <> "" AndAlso pDefaultReportPrinterName <> "no printer" Then
      ViewReport()
    Else
      pMessageBox = New MyMessageBox("ยังไม่ได้กำหนดเครื่องพิมพ์", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      pMessageBox.ShowDialog()
    End If
  End Sub

  Private Sub btnCompSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompSearch.Click
    frmCompSearch.ShowDialog()
    If frmCompSearch.pCompCode <> "" Then
      mCompCode = frmCompSearch.pCompCode
      txtCompName.Text = frmCompSearch.pCompName
    End If
  End Sub

  Private Sub btnGoodSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoodSearch.Click
    frmGoodSearch.ShowDialog()
    If frmGoodSearch.pOk = True Then
      txtGoodName.Text = frmGoodSearch.pGoodName
    End If
  End Sub
End Class