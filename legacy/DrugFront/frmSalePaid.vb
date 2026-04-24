Public Class frmSalePaid

  Public pGridPay As DataGridView

  Public pTotalPrice As Double
  'Public pTotalDisc As Double
  Public pCashPaid As Double
  Public pCashAmou As Double
  'Public pCardAmou As Double
  'Public pCardCode As String
  'Public pCardName As String
  'Public pCardNumb As String
  'Public pQueueEmplCode As String
  Public pEmplCode As String
  Public pEmplName As String
  Public pOk As Boolean
  'Public pCanPon As Boolean
  'Public pNotPaid As Double
  'ublic pDepoAmou As Double
  Public pChangeAmou As Double
  Public pCustTypeCode As String

  Dim mTotalNet As Double
  'Dim mNotPaid As Double
  Dim mColorConv As New ColorConverter

  Private Sub frmSalePaid_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
    Me.Icon = frmMain.Icon
      pOk = False
    mTotalNet = pTotalPrice
    lblTotalNet.Text = mTotalNet.ToString("#,##0.00")
    ' focus ที่ datagridview (เฉพาะยอดขายที่มากกว่า 0)
    If mTotalNet > 0 Then
        SendKeys.Send("{Tab}")
      'SendKeys.Send("{Right}")
    End If

    For i As Integer = 0 To dtgPaid.Columns.Count - 1
      dtgPaid.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
    Next

    ShowCardInfo()
  End Sub

  Private Sub ShowCardInfo()
    dtgPaid.Rows.Clear()
    Dim ds As New DataSet
    Dim mSqlText As String

    Select Case pCustTypeCode
      Case "2" ' พนักงาน
        mSqlText = "Select * from CardInfo where showCard = '1' and cardCode = '16'"
      Case "9" ' pharcare
        mSqlText = "Select * from CardInfo where showCard = '1' and cardCode = '18'"
      Case Else ' อื่นๆ
        mSqlText = "Select * from CardInfo where showCard = '1' and cardCode <> '16' and cardCode  <> '18'"
    End Select

    mSqlText = mSqlText & " order by cardOrder, cardCode"

    'mSqlText = "Select * from CardInfo where showCard = '1'"
    '' ขายพนักงาน ให้แสดงประเภทชำระเป็น สวัสดิการพนักงาน อย่างเดียว
    'If pCustTypeCode = "2" Then
    '  mSqlText = "Select * from CardInfo where showCard = '1' and cardCode = '16'"
    'Else ' ไม่ต้องแสดงประเภทชำระ สวัสดิการพนักงาน
    '  mSqlText = mSqlText & " and cardCode <> '16'"
    'End If
    '' ลูกค้า PharmCare
    'If pCustTypeCode = "9" Then
    '  mSqlText = "Select * from CardInfo where showCard = '1' and cardCode = '18'"
    'Else
    '  mSqlText = mSqlText & " and cardCode <> '18'"
    'End If

    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        For i As Integer = 0 To dv.Count - 1
          With dv.Item(i)
            dtgPaid.Rows.Add()
            dtgPaid.Item("cardCode", i).Value = .Item("cardCode")
            'dtgPaid.Item("cardNumber", i).Value = ""
            dtgPaid.Item("payAmou", i).Value = ""
            dtgPaid.Item("refNumb", i).Value = ""
            dtgPaid.Item("reqRefNumb", i).Value = .Item("reqRefNumb")
            If .Item("reqRefNumb") = "1" Then
              dtgPaid.Item("cardName", i).Value = .Item("cardName") & " **"
            Else
              dtgPaid.Item("cardName", i).Value = .Item("cardName")
            End If
            dtgPaid.Item("cardColor", i).Value = .Item("cardColor")
            ' แสดงสี
            Try
              dtgPaid.Item("cardName", i).Style.BackColor = mColorConv.ConvertFromString(.Item("cardColor"))
            Catch ex As Exception

            End Try
            'dtgPaid.Item("enterNumber", i).Value = .Item("enterNumber")
          End With
        Next
      End If
      dv = Nothing
    End If
    ds = Nothing
    dtgPaid.ClearSelection()
    ' ถ้ายอดขายติดลบหรือเท่ากับศูนย์ ไม่ให้ป้อนข้อมูลในรายการ
    If mTotalNet <= 0 Then
      dtgPaid.Enabled = False
      txtEmplCode.Focus()
    End If
  End Sub

  Private Sub txtEmplCode_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtEmplCode.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub frmSalePaid_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        Me.Close()
    End Select
  End Sub

  Private Sub txtEmplCode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmplCode.GotFocus
    txtEmplCode.Text = ""
    txtEmplName.Text = ""
  End Sub

  Private Sub ShowEmplInfo(ByVal EmplCode As String)
    Dim mGet() As String
    mGet = pService.GetData("Drug", "Select emplName from EmplInfo where emplCode = '" & EmplCode & "'")
    If mGet(0) = "1" Then
      txtEmplName.Text = RemoveNickName(mGet(1))
    Else
      pMessageBox = New MyMessageBox("รหัสพนักงานไม่ถูกต้อง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Stop)
      pMessageBox.ShowDialog()
      txtEmplCode.Focus()
    End If
  End Sub

  Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
    ' เช็คบังคับป้อนหมายเลขอ้างอิง
    For Each mRow As DataGridViewRow In dtgPaid.Rows
      If dtgPaid.Rows(mRow.Index).Visible = True Then
        If Val(dtgPaid.Item("payAmou", mRow.Index).Value) > 0 AndAlso dtgPaid.Item("reqRefNumb", mRow.Index).Value = "1" AndAlso dtgPaid.Item("refNumb", mRow.Index).Value.ToString.Trim = "" Then
          pMessageBox = New MyMessageBox("กรุณาป้อนเลขอ้างอิง", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
          pMessageBox.ShowDialog()
          Exit Sub
        End If
      End If
    Next

    Dim mCashPaid As Double = 0 ' จำนวนเงินสดที่ชำระ เช่น 500
    Dim mCashAmou As Double = 0 ' จำนวนเงินสดจริง
    Dim mOtherAmou As Double = 0
    For Each mRow As DataGridViewRow In dtgPaid.Rows
      ' ช่องเงินสด
      If dtgPaid.Item("cardCode", mRow.Index).Value = "0" Then
        mCashPaid = Val(dtgPaid.Item("payAmou", mRow.Index).Value)
      Else ' รวมช่องอื่นๆ
        mOtherAmou += Val(dtgPaid.Item("payAmou", mRow.Index).Value)
      End If
    Next

    If pTotalPrice > 0 AndAlso mOtherAmou > pTotalPrice Then
      pMessageBox = New MyMessageBox("จำนวนเงินชำระ(ไม่รวมเงินสด)มากกว่าราคาสินค้า", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      pMessageBox.ShowDialog()
      Exit Sub
    End If

    If (mCashPaid + mOtherAmou) < pTotalPrice Then
      pMessageBox = New MyMessageBox("จำนวนเงินชำระน้อยกว่าราคาสินค้า", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      pMessageBox.ShowDialog()
      Exit Sub
    End If

    If txtEmplCode.Text = "" Then
      pMessageBox = New MyMessageBox("กรุณาป้อนรหัสพนักงานขาย", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      pMessageBox.ShowDialog()
      txtEmplCode.Focus()
      Exit Sub
    End If

    mCashAmou = mTotalNet - mOtherAmou
    ' ปรับช่องเงินสด ให้เท่ากับจำนวนเงินสดที่ต้องจ่ายจริง
    For Each mRow As DataGridViewRow In dtgPaid.Rows
      ' ช่องเงินสด
      If dtgPaid.Item("cardCode", mRow.Index).Value = "0" Then
        If mCashAmou <> 0 Then
          dtgPaid.Item("payAmou", mRow.Index).Value = mCashAmou
        Else
          dtgPaid.Item("payAmou", mRow.Index).Value = ""
        End If
        Exit For
      End If
    Next

    pGridPay = dtgPaid
    pCashPaid = mCashPaid
    pCashAmou = mCashAmou
    pChangeAmou = mCashPaid - mCashAmou

    pEmplCode = txtEmplCode.Text
    pEmplName = txtEmplName.Text
    pOk = True

    Me.Close()
  End Sub

  Private Sub txtEmplCode_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtEmplCode.LostFocus
    If txtEmplCode.Text <> "" Then
      ShowEmplInfo(txtEmplCode.Text)
    End If
  End Sub

  Private Sub dtgPaid_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles dtgPaid.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("^{Tab}") ' Ctrl+Tab เพื่อให้ lostfocus จาก grid
      ' ซ่อนรายการที่ไม่ได้ชำระ
      For Each mRow As DataGridViewRow In dtgPaid.Rows
        If MyVal(dtgPaid.Item("payAmou", mRow.Index).Value) <= 0 Then
          dtgPaid.Rows(mRow.Index).Visible = False
        End If
      Next
    End If
  End Sub

  Private Sub dtgPaid_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles dtgPaid.LostFocus
    dtgPaid.ClearSelection()
  End Sub

  Private Sub dtgPaid_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dtgPaid.CellEndEdit
    Select Case dtgPaid.Columns(e.ColumnIndex).Name
      'Case "cardNumber"
      '  ' ลบช่องว่าง
      '  dtgPaid.Item("cardNumber", e.RowIndex).Value = Replace(dtgPaid.Item("cardNumber", e.RowIndex).Value, " ", "")
      Case "payAmou"
        ' หากป้อนติดลบ ให้เปลี่ยนเป็นบวก
        Dim mPayAmou As Double
        mPayAmou = MyVal(dtgPaid.Item("payAmou", e.RowIndex).Value)
        dtgPaid.Item("payAmou", e.RowIndex).Value = Math.Abs(mPayAmou)
        dtgPaid.Item("payAmou", e.RowIndex).Style.BackColor = mColorConv.ConvertFromString(dtgPaid.Item("cardColor", e.RowIndex).Value)

        '' ปรับสีตัวอักษร
        'If IsNothing(dtgPaid.Item("payAmou", e.RowIndex).Value) = False AndAlso dtgPaid.Item("payAmou", e.RowIndex).Value > 0 Then
        '  dtgPaid.Rows(e.RowIndex).DefaultCellStyle.ForeColor = mColorConv.ConvertFromString(dtgPaid.Item("fontColor", e.RowIndex).Value) ' Color.Blue
        'Else
        '  dtgPaid.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
        'End If

        'If dtgPaid.Item("enterNumber", e.RowIndex).Value = "1" Then
        SendKeys.Send("{Right}")
        If e.RowIndex <> dtgPaid.Rows.Count - 1 Then
          SendKeys.Send("{Up}")
        End If
        'End If
    End Select
  End Sub
End Class