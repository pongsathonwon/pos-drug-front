Public Class frmRpStockCard

  Dim mGoodCode As String

  Private Sub frmRpStockCard_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    Me.WindowState = FormWindowState.Normal
  End Sub

  Private Sub frmRpStockCard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    dtpFrom.Value = pServerDateTime.Date
    dtpTo.Value = pServerDateTime.Date
  End Sub

  Private Sub frmRpStockCard_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
    btnShow.Select()
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    Me.Cursor = Cursors.WaitCursor
    dtgCard.Rows.Clear()
    Dim ds As New DataSet
    Dim mSqlText As String
    mSqlText = "Select * from FrontCard where stockDate >= '" & MDYStr(dtpFrom.Value) & "' and stockDate <= '" & MDYStr(dtpTo.Value) & "' and goodCode = '" & mGoodCode & "' and branchCode = '" & pBranchCode & "' Order by stockDate, stockTime, docNumb, stockOnhand desc"

    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      Dim mWorkDesc As String = ""
      Dim mGet() As String

      If dv.Count > 0 Then
        For i As Integer = 0 To dv.Count - 1
          With dv.Item(i)
            dtgCard.Rows.Add()
            dtgCard.Item("stockDate", i).Value = .Item("stockDate")
            dtgCard.Item("stockTime", i).Value = .Item("stockTime")
            dtgCard.Item("docNumb", i).Value = .Item("docNumb")
            dtgCard.Item("emplName", i).Value = .Item("emplName")

            dtgCard.Item("workType", i).Value = .Item("workType")
            Select Case .Item("workType").ToString
              Case "SAL" ' ขายหน้าร้าน
                mWorkDesc = "ขายหน้าร้าน"
                dtgCard.Item("outStock", i).Value = .Item("goodAmou")
              Case "OSL" ' ขาย offline
                mWorkDesc = "ขายออฟไลน์"
                dtgCard.Item("outStock", i).Value = .Item("goodAmou")
              Case "HOS" ' ขายออนไลน์ ผ่านแอพ
                mWorkDesc = "ขายผ่านแอพ"
                dtgCard.Item("outStock", i).Value = .Item("goodAmou")
              Case "REC" ' รับเข้า
                mWorkDesc = "รับเข้า"
                dtgCard.Item("inStock", i).Value = .Item("goodAmou")
              Case "REX" ' รับเข้า
                mWorkDesc = "รับเข้า(ด่วน)"
                dtgCard.Item("inStock", i).Value = .Item("goodAmou")
              Case "RET" ' ส่งคืน
                mWorkDesc = "ส่งคืนคลัง"
                dtgCard.Item("outStock", i).Value = .Item("goodAmou")
              Case "REW" ' อยู่ระหว่างส่งคืนคลัง
                mWorkDesc = "อยู่ระหว่างส่งคืนคลัง"
              Case "RER" ' ส่งคืน
                mWorkDesc = "คลังรับคืน"
              Case "CRT" ' ยกเลิกส่งคืน
                mWorkDesc = "ยกเลิกส่งคืน"
                dtgCard.Item("inStock", i).Value = .Item("goodAmou")
              Case "RSL" ' คืนจากการขาย
                mWorkDesc = "รับคืนจากการขาย"
                dtgCard.Item("inStock", i).Value = .Item("goodAmou")
              Case "SRJ" ' สต๊อคกลางไม่รับคืน
                mWorkDesc = "คลังไม่รับคืน"
                dtgCard.Item("inStock", i).Value = .Item("goodAmou")
              Case "CSL" ' ยกเลิกใบขาย
                mWorkDesc = "ยกเลิกใบขาย"
                dtgCard.Item("inStock", i).Value = .Item("goodAmou")
              Case "HOR" ' ยกเลิกใบขายออนไลน์
                mWorkDesc = "ยกเลิกใบขายออนไลน์"
                dtgCard.Item("inStock", i).Value = .Item("goodAmou")
              Case "ADJ" ' ปรับยอด
                mWorkDesc = "ปรับยอด"
              Case "BTB"
                mWorkDesc = "โอนไปสาขา "
                dtgCard.Item("outStock", i).Value = .Item("goodAmou")
                ' หาสาขาที่โอนไปและผู้โอน จากเลขที่ใบโอน
                mGet = pService.GetData("Drug", "Select BI.branchName, EI.emplName from RequTranMast RM inner join BranchInfo BI on BI.branchCode = RM.toBranchCode inner join EmplInfo EI on EI.emplCode = RM.tranEmplCode Where RM.requNumb = '" & .Item("docNumb") & "'")
                If mGet(0) = "1" Then
                  mWorkDesc = mWorkDesc & mGet(1)
                  dtgCard.Item("emplName", i).Value = mGet(2)
                End If
              Case "BFB"
                mWorkDesc = "โอนมาจากสาขา "
                dtgCard.Item("inStock", i).Value = .Item("goodAmou")
                ' หาสาขาที่โอนมาและผู้ขอโอน จากเลขที่ใบโอน
                mGet = pService.GetData("Drug", "Select BI.branchName, EI.emplName from RequTranMast RM inner join BranchInfo BI on BI.branchCode = RM.fromBranchCode inner join EmplInfo EI on EI.emplCode = RM.requEmplCode Where RM.requNumb = '" & .Item("docNumb") & "'")
                If mGet(0) = "1" Then
                  mWorkDesc = mWorkDesc & mGet(1)
                  dtgCard.Item("emplName", i).Value = mGet(2)
                End If
            End Select

            dtgCard.Item("workDesc", i).Value = mWorkDesc
            dtgCard.Item("stockOnhand", i).Value = .Item("stockOnhand")
          End With
        Next
        ChangeForeColor()
        dtgCard.ClearSelection()
      Else
        pMessageBox = New MyMessageBox("ไม่มีรายการ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        pMessageBox.ShowDialog()
      End If
      dv = Nothing
    End If
    ds = Nothing
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub ChangeForeColor()
    Dim mForeColor As Color
    For Each mRow As DataGridViewRow In dtgCard.Rows
      Select Case dtgCard.Item("workType", mRow.Index).Value
        Case "SAL" ' ขายหน้าร้าน
          mForeColor = Color.Black
        Case "OSL" ' ขาย offline
          mForeColor = Color.Black
        Case "HOS" ' ขายออนไลน์ ผ่านแอพ
          mForeColor = Color.Black
        Case "REC" ' รับเข้า
          mForeColor = Color.Blue
        Case "REX" ' รับเข้า
          mForeColor = Color.Blue
        Case "RET" ' ส่งคืน
          mForeColor = Color.Purple
        Case "CRT" ' ยกเลิกส่งคืน
          mForeColor = Color.Purple
        Case "RSL" ' คืนจากการขาย
          mForeColor = Color.Purple
        Case "SRJ" ' สต๊อคกลางไม่รับคืน
          mForeColor = Color.Purple
        Case "CSL" ' ยกเลิกใบขาย
          mForeColor = Color.Red
        Case "HOR" ' ยกเลิกใบขายออนไลน์
          mForeColor = Color.Red
        Case "ADJ" ' ปรับยอด
          mForeColor = Color.DarkGreen
        Case "BTB" ' โอนไปสาขา
          mForeColor = Color.SaddleBrown
        Case "BFB" ' โอนมาจากสาขา
          mForeColor = Color.SaddleBrown
        Case Else
          mForeColor = Color.Black
      End Select
      dtgCard.Rows(mRow.Index).DefaultCellStyle.ForeColor = mForeColor
    Next
  End Sub

  Private Sub ShowGood(ByVal GoodCode As String, ByVal BarCode As String)
    Dim getValue() As String
    Dim mSqlText As String
    If GoodCode <> "" Then
      mSqlText = "SELECT GI.goodCode, GI.goodName, UI.unitDesc FROM GoodInfo GI INNER JOIN UnitInfo UI ON GI.unitCode = UI.unitCode WHERE GI.goodCode = '" & GoodCode & "'"
    Else
      mSqlText = "SELECT GB.goodCode, GI.goodName, UI.unitDesc FROM GoodBarcode GB INNER JOIN GoodInfo GI ON GB.goodCode = GI.goodCode INNER JOIN UnitInfo UI ON GB.unitCode = UI.unitCode WHERE GB.barCode = '" & BarCode & "'"
    End If

    getValue = pService.GetData("Drug", mSqlText)

    If getValue(0) = "1" Then
      mGoodCode = getValue(1)
      txtGoodName.Text = getValue(2)
      txtUnitDesc.Text = getValue(3)
      txtBarCode.Enabled = False
    Else
      MessageBox.Show("ไม่พบข้อมูลสินค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      mGoodCode = ""
      txtBarCode.Text = ""
      txtGoodName.Text = ""
      txtUnitDesc.Text = ""
      txtBarCode.Focus()
    End If
  End Sub

  Private Sub textKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarCode.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub txtBarCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarCode.LostFocus
    If txtBarCode.Text <> "" Then
      ShowGood("", txtBarCode.Text)
    End If
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "select * from FrontCard where workType = 'REX'")
    Dim dv As New DataView(ds.Tables(0))
    Dim mDocNumb As String
    Dim mGoodCode As String
    Dim mBranchCode As String
    Dim ds2 As New DataSet
    'Dim dv2 As DataView
    Dim mGet() As String
    For i As Integer = 0 To dv.Count - 1
      mBranchCode = dv.Item(i).Item("branchCode")
      mDocNumb = dv.Item(i).Item("docNumb")
      mGoodCode = dv.Item(i).Item("goodCode")
      mGet = pService.GetData("Drug", "Select IL.invoNumb, GI.goodName, IL.goodAmou, IL.receAmou from InvoiceList IL inner join GoodInfo GI on GI.goodCode = IL.goodCode where IL.invoNumb = '" & mDocNumb & "' and IL.goodCode = '" & mGoodCode & "' and IL.receAmou > 0 and IL.goodAmou <> IL.receAmou")
      If mGet(0) = "1" Then
        dtgList2.Rows.Add(mBranchCode, mGet(1), mGet(2), mGet(3), mGet(4))
      End If
    Next
  End Sub

  Private Sub tbnGoodSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnGoodSearch.Click
    frmGoodSearch.ShowDialog()
    If frmGoodSearch.pBarcode <> "" Then
      txtBarCode.Text = frmGoodSearch.pBarcode
      ShowGood("", frmGoodSearch.pBarcode)
    End If
  End Sub

  Private Sub tbnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnClear.Click
    txtBarCode.Text = ""
    txtGoodName.Text = ""
    txtUnitDesc.Text = ""
    dtgCard.Rows.Clear()
    txtBarCode.Enabled = True
    txtBarCode.Select()
  End Sub
End Class