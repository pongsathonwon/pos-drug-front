Public Class frmPromotion

  Public pBarcode As String

  Private Sub frmPromotion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.Escape Then
      Me.Close()
    End If
  End Sub

  Private Sub frmPromotion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon
    ShowSalePro()
    ShowGoodPro()
    ShowCompPro()
  End Sub

  Private Sub ShowSalePro()
    Me.Cursor = Cursors.WaitCursor

    dtgPro.Rows.Clear()
    Dim ds As New DataSet
    Dim mSqlText As String

    mSqlText = "select * from SalePro Where proStat <> '0' and startDate <= '" & MDYStr(pServerDateTime.Date) & "' And endDate >= '" & MDYStr(pServerDateTime.Date) & "' and (branchCode = '" & pBranchCode & "' or (branchCode = '0' and branchPrice = '0') or (branchCode = '0' and branchPrice = '" & pBranchPrice & "')) order by custTypeCode"

    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          '' อยู่ในช่วงโปร
          'If pServerDateTime.Date >= CDate(.Item("startDate")) AndAlso pServerDateTime.Date <= CDate(.Item("endDate")) Then
          dtgPro.Rows.Add()
          dtgPro.Item("custTypeDesc", dtgPro.Rows.Count - 1).Value = CustType(.Item("custTypeCode"))
          dtgPro.Item("proText", dtgPro.Rows.Count - 1).Value = .Item("proDesc").ToString
          dtgPro.Item("pStartDate", dtgPro.Rows.Count - 1).Value = .Item("startDate")
          dtgPro.Item("pEndDate", dtgPro.Rows.Count - 1).Value = .Item("endDate")
          dtgPro.Item("extraPoint", dtgPro.Rows.Count - 1).Value = .Item("extraPoint")
          dtgPro.Item("plusPoint", dtgPro.Rows.Count - 1).Value = .Item("plusPoint")
          'End If
        End With
      Next
    End If
    ds = Nothing
    dtgPro.ClearSelection()
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub ShowGoodPro()
    Me.Cursor = Cursors.WaitCursor

    dtgGoodPro.Rows.Clear()
    Dim ds As New DataSet
    Dim mSqlText As String

    mSqlText = "Select GP.*, GI.goodName, GI2.goodName as goodName2, CT.custTypeDesc, GI.barCode From GoodPro GP inner join GoodInfo GI on GI.goodCode = GP.goodCode inner join CustType CT on CT.custTypeCode = GP.custTypeCode left outer join GoodInfo GI2 on GI2.goodCode = GP.goodCode2 Where GP.proStat = '1' and GP.startDate <= '" & MDYStr(pServerDateTime.Date) & "' And GP.endDate >= '" & MDYStr(pServerDateTime.Date) & "' And GP.compCode = '' and (GP.branchCode = '" & pBranchCode & "' or (GP.branchCode = '0' and GP.branchPrice = '0') or (GP.branchCode = '0' and GP.branchPrice = '" & pBranchPrice & "')) order by GI.goodName"

    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dtgGoodPro.Rows.Add()
          If .Item("custTypeCode") = "0" Then
            dtgGoodPro.Item("gCustTypeDesc", dtgGoodPro.Rows.Count - 1).Value = "ทั้งหมด"
          Else
            dtgGoodPro.Item("gCustTypeDesc", dtgGoodPro.Rows.Count - 1).Value = .Item("custTypeDesc")
          End If
          'dtgGoodPro.Item("gCustTypeDesc", dtgGoodPro.Rows.Count - 1).Value = CustType(.Item("custTypeCode"))
          dtgGoodPro.Item("gBarcode", dtgGoodPro.Rows.Count - 1).Value = .Item("barCode")
          dtgGoodPro.Item("gGoodName", dtgGoodPro.Rows.Count - 1).Value = .Item("goodName")
          dtgGoodPro.Item("gGoodName2", dtgGoodPro.Rows.Count - 1).Value = .Item("goodName2")
          dtgGoodPro.Item("gAmou", dtgGoodPro.Rows.Count - 1).Value = .Item("goodAmou")

          If .Item("extraPoint") > 0 Then
            dtgGoodPro.Item("gPoint", dtgGoodPro.Rows.Count - 1).Value = .Item("extraPoint")
          End If
          If .Item("discAmou") > 0 Then
            dtgGoodPro.Item("gDisc", dtgGoodPro.Rows.Count - 1).Value = .Item("discAmou")
          End If
          If .Item("fixPrice") > 0 Then
            dtgGoodPro.Item("gFixPrice", dtgGoodPro.Rows.Count - 1).Value = .Item("fixPrice")
          End If

          dtgGoodPro.Item("gStartDate", dtgGoodPro.Rows.Count - 1).Value = .Item("startDate")
          dtgGoodPro.Item("gEndDate", dtgGoodPro.Rows.Count - 1).Value = .Item("endDate")
        End With
      Next
    End If
    ds = Nothing
    dtgGoodPro.ClearSelection()
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub ShowCompPro()
    Me.Cursor = Cursors.WaitCursor
    dtgCompPro.Rows.Clear()
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "select GP.custTypeCode, CI.compName, GP.startDate, GP.endDate, GP.buyAmou, GP.extraPoint, GP.discAmou from GoodPro GP Inner join CompInfo CI On GP.compCode = CI.compCode where GP.startDate <= '" & MDYStr(pServerDateTime.Date) & "' And GP.endDate >= '" & MDYStr(pServerDateTime.Date) & "' and GP.compCode <> '' and (GP.branchCode = '" & pBranchCode & "' or (GP.branchCode = '0' and GP.branchPrice = '0') or (GP.branchCode = '0' and GP.branchPrice = '" & pBranchPrice & "')) group by GP.custTypeCode, CI.compname, GP.startDate, GP.endDate, GP.buyAmou, GP.extraPoint, GP.discAmou")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dtgCompPro.Rows.Add()
          dtgCompPro.Item("cCustTypeDesc", i).Value = CustType(.Item("custTypeCode"))
          dtgCompPro.Item("cCompName", i).Value = .Item("compName")
          dtgCompPro.Item("cBuyPrice", i).Value = .Item("buyAmou")
          dtgCompPro.Item("cPoint", i).Value = .Item("extraPoint")
          dtgCompPro.Item("cDisc", i).Value = .Item("discAmou")
          dtgCompPro.Item("cStartDate", i).Value = .Item("startDate")
          dtgCompPro.Item("cEndDate", i).Value = .Item("endDate")
        End With
      Next
      dv = Nothing
    End If
    ds = Nothing
    dtgCompPro.ClearSelection()
    Me.Cursor = Cursors.Default
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

  Private Sub dtgGoodPro_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgGoodPro.CellDoubleClick
    If e.RowIndex >= 0 Then
      pBarcode = dtgGoodPro.Item("gBarcode", e.RowIndex).Value
      Me.Close()
    End If
  End Sub
End Class