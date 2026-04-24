Public Class frmCalMiniStock

  Dim mCancel As Boolean

  Private Sub btnCal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCal.Click
    mCancel = False
    btnCancel.Visible = True
    btnCal.Visible = False
    lblInformation.Visible = False
    lblWarning.Visible = True
    pgb1.Visible = True
    My.Application.DoEvents()

    Me.Cursor = Cursors.WaitCursor

    ' ใช้วันที่และเวลาของ server
    pServerDateTime = pService.ServerDateTime

    Dim mMiniStockField As String = "miniStock" & pBranchCode
    Dim mFromDate As Date
    Dim mText As String
    Dim ds As New DataSet
    mFromDate = pServerDateTime.Date.AddDays(-30) ' Date.Today.AddDays(-30)
    mText = "SELECT SL.goodCode, SUM(SL.goodAmou * UI.unitFactor) AS totalAmou FROM SaleList SL INNER JOIN HistSale HS ON SL.saleNumb = HS.saleNumb inner join UnitInfo UI ON SL.unitCode = UI.unitCode WHERE HS.saleDate >= '" & MDYStr(mFromDate) & "' AND HS.saleDate <= '" & MDYStr(pServerDateTime.Date) & "' and HS.branchCode = '" & pBranchCode & "' AND HS.saleStat <> '0' GROUP BY SL.goodCode"

    'pService.Timeout = 1000000
    ds = pService.SelectData2("Drug", mText)
    'pService.Timeout = 100000
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.tables(0))
      If dv.Count > 0 Then
        Dim mRecordCount As Integer = dv.Count
        pgb1.Maximum = mRecordCount
        pgb1.Value = 0
        pgb1.Visible = True

        Dim mSqlText(1) As String
        Dim mUpdate As String
        Dim mGoodCode As String
        Dim mMonthRate As Integer
        ' clear ค่าจุดสั่งซื้อสินค้าทั้งหมด
        mSqlText(0) = "Update GoodInfo set " & mMiniStockField & " = 0"

        mUpdate = pService.UpdateData("Drug", mSqlText)
        If mUpdate = "1" Then
          ' เริ่มอัพเดตค่าจุดสั่งซื้อ
          For i As Integer = 0 To dv.Count - 1
            If mCancel = True Then
              Me.Cursor = Cursors.Default
              btnCancel.Visible = False
              btnCal.Visible = True
              pgb1.Visible = False
              lblInformation.Visible = True
              lblWarning.Visible = False
              Exit Sub
            End If

            mGoodCode = dv.Item(i).Item("goodCode").ToString
            mMonthRate = CInt(dv.Item(i).Item("totalAmou"))
            mSqlText(0) = "UPDATE GoodInfo SET " & mMiniStockField & " = " & mMonthRate & " WHERE goodCode = '" & mGoodCode & "'"

            ' @@@@@@@@@@@@@@@ ระบบสต๊อคแยกตาราง
            mSqlText(1) = "Update GoodBranchInfo set miniStock = " & mMonthRate & " where goodCode = '" & mGoodCode & "' and branchCode = '" & pBranchCode & "'"
            ' @@@@@@@@@@@@@@@ ระบบสต๊อคแยกตาราง

            mUpdate = pService.UpdateData("Drug", mSqlText)
            If mUpdate <> "1" Then
              MessageBox.Show("Can not update data", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Question)
              Me.Cursor = Cursors.Default
              btnCancel.Visible = False
              btnCal.Visible = True
              pgb1.Visible = False
              lblInformation.Visible = True
              lblWarning.Visible = False
              Exit Sub
            End If
            pgb1.Value += 1
            My.Application.DoEvents()
          Next
          dv = Nothing
          MessageBox.Show("ประมวลผลเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
          Me.Cursor = Cursors.Default
          Me.Close()
        Else
          MessageBox.Show("Cannot clear minimum stock" & vbCrLf & mUpdate, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Question)
        End If
      Else
        MessageBox.Show("ไม่มีข้อมูลสินค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
    Else
      MessageBox.Show("ไม่สามารถคำนวณจุดสั่งซื้อได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End If
    ds = Nothing

    Me.Cursor = Cursors.Default
    btnCancel.Visible = False
    btnCal.Visible = True
    pgb1.Visible = False
    lblInformation.Visible = True
    lblWarning.Visible = False
  End Sub

  Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    mCancel = True
  End Sub

  Private Sub btnCancel_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.MouseHover
    btnCancel.Cursor = Cursors.Default
  End Sub

  Private Sub frmCalMiniStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    CheckPriv()
  End Sub

  Private Sub CheckPriv()
    ' Edit
    If InStr(pUserPriv, Me.Tag.ToString & "E") > 0 Then
      btnCal.Enabled = True
    Else
      btnCal.Enabled = False
    End If
  End Sub
End Class