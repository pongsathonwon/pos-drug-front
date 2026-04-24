Public Class frmGoodBuyExchangeList

  Public pGoodCode As String
  Public pBarcode As String
  Public pOk As Boolean

  Private Sub frmGoodExchangeList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Icon = frmMain.Icon

    pOk = False
    ShowGoodExchangeList()
  End Sub

  'Private Sub frmGoodBuyExchangeList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
  '  If e.KeyCode = Keys.Escape Then
  '    Me.Close()
  '  End If
  'End Sub

  Private Sub ShowGoodExchangeList()
    dtgList.Rows.Clear()

    Dim mSqlText As String
    mSqlText = "Select GE.*, GI.goodName, UI.unitDesc, GB.barCode from GoodBuyExchange GE inner join GoodInfo GI on GI.goodCode = GE.goodCode inner join UnitInfo UI on UI.unitCode = GI.unitCode Cross Apply (select top 1 * from GoodBarcode where goodCode = GI.goodCode) GB Where GE.exchangeStat = '1' and GE.endDate >= '" & MDYStr(pServerDateTime.Date) & "' order by GE.startDate, GI.goodName" ' ใช้ Cross Apply เพื่อเลือกมาแค่ 1 รายการจาก GoodBarcode เลี่ยงรายการซ้ำ

    Dim ds As New DataSet
    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      Dim mStartDate As Date
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dtgList.Rows.Add()
          ' เช็ควันเริ่มใช้สิทธิ์ ถ้ายังไม่ถึงเวลา ให้เว้นคอลัมน์ goodCode ไว้ เพื่อใช้ตรวจสอบเวลาเลือก
          mStartDate = CDate(.Item("startDate"))
          If mStartDate <= pServerDateTime.Date Then
            dtgList.Rows(i).Cells("goodCode").Value = .Item("goodCode")
          Else
            dtgList.Rows(i).Cells("goodCode").Value = ""
            dtgList.Rows(i).DefaultCellStyle.ForeColor = Color.DarkGray
          End If

          dtgList.Rows(i).Cells("goodName").Value = .Item("goodName")
          dtgList.Rows(i).Cells("goodAmou").Value = .Item("goodAmou")
          dtgList.Rows(i).Cells("unitDesc").Value = .Item("unitDesc")
          dtgList.Rows(i).Cells("discAmou").Value = .Item("discAmou")
          dtgList.Rows(i).Cells("barCode").Value = .Item("barCode")
          dtgList.Rows(i).Cells("betweenDate").Value = ThaiShortDate(CDate(.Item("startDate"))) & " - " & ThaiShortDate(CDate(.Item("endDate")))
        End With
      Next
      dtgList.ClearSelection()
    End If
    ds = Nothing
  End Sub

  'Private Sub dtgList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgList.CellDoubleClick
  '  If e.RowIndex > -1 Then
  '    Dim mGoodCode, mBarcode As String
  '    mGoodCode = dtgList.Rows(e.RowIndex).Cells("goodCode").Value.ToString
  '    mBarcode = dtgList.Rows(e.RowIndex).Cells("barCode").Value.ToString
  '    ' เฉพาะรายการที่อยู่ในช่วงใช้สิทธิ์ได้ (goodCode มีข้อมูล)
  '    If mGoodCode <> "" Then
  '      pGoodCode = mGoodCode
  '      pBarcode = mBarcode
  '      pOk = True
  '      Me.Close()
  '    Else
  '      MessageBox.Show("สินค้าไม่อยู่ในช่วงเวลาให้แลกซื้อ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
  '    End If
  '  End If
  'End Sub

  'Private Sub dtgList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtgList.KeyPress
  '  If e.KeyChar = ChrW(Keys.Enter) Then
  '    Dim mGoodCode, mBarcode As String
  '    mGoodCode = dtgList.Rows(dtgList.CurrentRow.Index).Cells("goodCode").Value.ToString
  '    mBarcode = dtgList.Rows(dtgList.CurrentRow.Index).Cells("barCode").Value.ToString
  '    ' เฉพาะรายการที่อยู่ในช่วงใช้สิทธิ์ได้ (goodCode มีข้อมูล)
  '    If mGoodCode <> "" Then
  '      pGoodCode = mGoodCode
  '      pBarcode = mBarcode
  '      pOk = True
  '      Me.Close()
  '    Else
  '      MessageBox.Show("สินค้าไม่อยู่ในช่วงเวลาให้แลกซื้อ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
  '    End If
  '  End If
  'End Sub

  'Private Sub dtgList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgList.KeyDown
  '  ' ป้องกันการกด Enter แล้วกระโดดไปบรรทัดต่อไป
  '  If e.KeyCode = Keys.Enter Then
  '    e.Handled = True
  '  End If
  'End Sub
End Class