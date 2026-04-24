Imports CrystalDecisions.Shared

Public Class frmRpStockOnhand

  Dim mGoodCode As String

  Private Sub frmRpStockOnhand_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    Me.WindowState = FormWindowState.Normal
  End Sub

  Private Sub frmRpStockOnhand_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    ShowType()
    ShowGroup()
    ShowCate()

    CheckPriv()
  End Sub

  Private Sub CheckPriv()
    If InStr(pUserPriv, Me.Tag.ToString & "V") > 0 Then
      btnShow.Enabled = True
    Else
      btnShow.Enabled = False
    End If
  End Sub

  Private Sub ShowType()
    cboTypeCode.Items.Clear()
    cboTypeDesc.Items.Clear()
    cboTypeDesc.Items.Add("ทั้งหมด")
    cboTypeCode.Items.Add("000")
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "SELECT * FROM TypeInfo ORDER BY typeDesc")
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

  Private Sub ShowCate()
    cboCateCode.Items.Clear()
    cboCateDesc.Items.Clear()
    cboCateDesc.Items.Add("ทั้งหมด")
    cboCateCode.Items.Add("000")
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "SELECT * FROM CateInfo ORDER BY cateDesc")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        cboCateCode.Items.Add(dv.Item(i).Item("cateCode"))
        cboCateDesc.Items.Add(dv.Item(i).Item("cateDesc"))
      Next
      dv = Nothing
    End If
    ds = Nothing
    cboCateDesc.SelectedIndex = 0
  End Sub

  Private Sub ShowGroup()
    cboGroupCode.Items.Clear()
    cboGroupDesc.Items.Clear()
    cboGroupDesc.Items.Add("ทั้งหมด")
    cboGroupCode.Items.Add("000")
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "SELECT groupCode, groupDesc FROM GroupInfo ORDER BY toGP DESC")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        cboGroupCode.Items.Add(dv.Item(i).Item("GroupCode"))
        cboGroupDesc.Items.Add(dv.Item(i).Item("GroupDesc"))
      Next
      dv = Nothing
    End If
    ds = Nothing
    cboGroupDesc.SelectedIndex = 0
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    ViewReport()
  End Sub

  Private Sub cboTypeDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTypeDesc.SelectedIndexChanged
    cboTypeCode.SelectedIndex = cboTypeDesc.SelectedIndex
  End Sub

  Private Sub cboGroupDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGroupDesc.SelectedIndexChanged
    cboGroupCode.SelectedIndex = cboGroupDesc.SelectedIndex
  End Sub

  Private Sub cboCateDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCateDesc.SelectedIndexChanged
    cboCateCode.SelectedIndex = cboCateDesc.SelectedIndex
  End Sub

  'Private Sub btnGoodSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoodSearch.Click
  '  frmGoodSearch.ShowDialog()
  '  If frmGoodSearch.pOk = True Then
  '    mGoodCode = frmGoodSearch.pGoodCode
  '    txtGoodName.Text = frmGoodSearch.pGoodName
  '  End If
  'End Sub

  Private Sub ViewReport()
    Me.Cursor = Cursors.WaitCursor

    Dim ds As New DataSet("dsDrug")
    Dim dt As New DataTable("dtStockOnhand")
    Dim dr As DataRow

    dt.Columns.Add("goodName", Type.GetType("System.String"))
    dt.Columns.Add("unitDesc", Type.GetType("System.String"))
    dt.Columns.Add("typeDesc", Type.GetType("System.String"))
    dt.Columns.Add("stockOnhand", Type.GetType("System.Int32"))
    dt.Columns.Add("totalCost", Type.GetType("System.Double"))
    dt.Columns.Add("barCode", Type.GetType("System.String"))
    dt.Columns.Add("unitCost", Type.GetType("System.Double"))
    dt.Columns.Add("unitPrice", Type.GetType("System.Double"))
    dt.Columns.Add("GP", Type.GetType("System.Double"))
    dt.Columns.Add("shelfNo", Type.GetType("System.String"))

    ds.Tables.Add(dt)

    Dim mSqlText As String
    Dim ds2 As New DataSet

    Dim mShelfNoField As String = "shelfNo" & pBranchCode
    Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
    Dim mUnitCostField As String = "unitCost" & pBranchCode
    Dim mBranchPriceField As String = "price" & pBranchPrice

    mSqlText = "SELECT GI.goodName, TI.typeDesc, GI." & mShelfNoField & " as shelfNo, UI.unitDesc, GI." & mStockOnhandField & " as stockOnhand, GI." & mUnitCostField & " as unitCost, GI.fcCostFactor, GI.barCode, GB." & mBranchPriceField & " AS unitPrice FROM GoodInfo GI INNER JOIN UnitInfo UI ON GI.unitCode = UI.unitCode inner join TypeInfo TI on TI.typeCode = GI.typeCode Left Outer JOIN (SELECT DISTINCT goodCode, barCode, " & mBranchPriceField & " FROM GoodBarcode WHERE LEN(barCode) = '6' AND goodAmou = 1) GB ON GI.goodCode = GB.goodCode WHERE GI.goodStat <> '0'"

    If chkOnlyHaveStock.Checked = True Then
      mSqlText = mSqlText & " and GI." & mStockOnhandField & " > 0"
    End If
    If cboCateDesc.Text <> "ทั้งหมด" Then
      mSqlText = mSqlText & " And GI.cateCode = '" & cboCateCode.Text & "'"
    End If
    If cboTypeDesc.Text <> "ทั้งหมด" Then
      mSqlText = mSqlText & " And GI.typeCode = '" & cboTypeCode.Text & "'"
    End If
    If cboGroupDesc.Text <> "ทั้งหมด" Then
      mSqlText = mSqlText & " And GI.groupCode = '" & cboGroupCode.Text & "'"
    End If

    mSqlText = mSqlText & " order by GI.goodName"

    ds2 = pService.SelectData("Drug", mSqlText)

    If IsNothing(ds2) = False Then
      Dim dv As New DataView(ds2.Tables(0))
      Dim mUnitCost As Double
      Dim mGP As Double
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dr = ds.Tables(0).NewRow
          dr("goodName") = .Item("goodName")
          dr("unitDesc") = .Item("unitDesc")
          dr("typeDesc") = .Item("typeDesc")
          dr("stockOnhand") = .Item("stockOnhand")
          dr("barCode") = .Item("barCode")

          If pIsFranchise = "1" And pBranchTypeCode = "2" Then ' เฉพาะสาขาแฟรนไชส์ partner ship
            mUnitCost = .Item("unitCost") * .Item("fcCostFactor")
          Else
            mUnitCost = .Item("unitCost")
          End If
          dr("unitCost") = mUnitCost
          dr("unitPrice") = .Item("unitPrice")
          dr("totalCost") = .Item("stockOnhand") * mUnitCost

          If IsDBNull(.Item("unitPrice")) = False AndAlso CDbl(.Item("unitPrice")) > 0 Then
            mGP = (CDbl(.Item("unitPrice")) - mUnitCost) * 100 / CDbl(.Item("unitPrice"))
          Else
            mGP = 0
          End If
          dr("GP") = mGP

          dr("shelfNo") = .Item("shelfNo")
        End With
        ds.Tables(0).Rows.Add(dr)
      Next
      dv = Nothing
    End If
    ds2 = Nothing

    Dim mReport As New rpStockOnhand
    mReport.SetDataSource(ds)
    mReport.SetParameterValue("prCompFullName", pCompFullName)
    mReport.SetParameterValue("prBranchName", "สาขา - " & pBranchName)
    'If pIsFranchise = True Then
    '  mReport.SetParameterValue("prBranchName", "สาขา - " & pBranchName & "FC")
    'Else
    '  mReport.SetParameterValue("prBranchName", "สาขา - " & pBranchName)
    'End If
    mReport.SetParameterValue("prCondition", "หมวด " & cboCateDesc.Text & " / กลุ่ม " & cboGroupDesc.Text & " / ประเภท " & cboTypeDesc.Text)

    Dim mView As New frmViewReport
    mView.MdiParent = frmMain
    mView.Text = Me.Text
    mView.ctrView.ReportSource = mReport
    mView.Show()

    Me.Cursor = Cursors.Default
  End Sub
End Class