Imports System.IO

Public Class frmRpPointUse

  Dim mCustCode As String

  Private Sub frmRpPointUse_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    Me.WindowState = FormWindowState.Normal
  End Sub

  Private Sub frmRp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon
    dtpFrom.Value = Date.Today
    dtpTo.Value = Date.Today
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    ShowData()
  End Sub

  Private Sub ShowData()
    Me.Cursor = Cursors.WaitCursor

    dtgList.Rows.Clear()
    Dim mSqlText As String
    Dim ds As New DataSet
    mSqlText = "Select HS.saleDate, HS.totalPrice, HP.* From HistSalePro HP Inner Join HistSale HS On HP.saleNumb = HS.saleNumb Where HS.saleStat <> '0' and HS.saleDate >= '" & MDYStr(dtpFrom.Value) & "' And HS.saleDate <= '" & MDYStr(dtpTo.Value) & "' And HS.custCode = '" & txtCustCode.Text & "' Order by HS.saleDate, HS.saleNumb"

    ds = pService.SelectData("Drug", mSqlText)

    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dtgList.Rows.Add()
          dtgList.Item("saleNumb", i).Value = .Item("saleNumb")
          dtgList.Item("saleDate", i).Value = .Item("saleDate")
          dtgList.Item("totalPrice", i).Value = .Item("totalPrice")
          dtgList.Item("usePoint", i).Value = .Item("usePoint")
          dtgList.Item("thisPoint", i).Value = .Item("thisPoint")
          dtgList.Item("custPoint", i).Value = .Item("remainPoint") + .Item("thisPoint")
        End With
      Next
      dv = Nothing
    End If
    ds = Nothing

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub btnCustSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustSearch.Click
    frmCustSearch.ShowDialog()
    If frmCustSearch.pOk = True Then
      txtCustCode.Text = frmCustSearch.pCustCode
      txtCustName.Text = frmCustSearch.pCustName
    End If
  End Sub

  Private Sub txtCustCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCustCode.KeyPress, txtCustName.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub txtCustCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustCode.LostFocus
    If txtCustCode.Text <> "" Then
      Dim mGet() As String
      mGet = pService.GetData("Drug", "Select custName, hugPoint from CustInfo where custCode = '" & txtCustCode.Text & "' and custStat <> '0'")
      If mGet(0) = "1" Then
        txtCustName.Text = mGet(1)
        txtHugPoint.Text = Format(CInt(mGet(2)), "#,##0")
        dtgList.Rows.Clear()
      Else
        MessageBox.Show("ไม่มีข้อมูลลูกค้า", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        txtCustCode.Text = ""
        txtCustName.Text = ""
        txtHugPoint.Text = ""
        dtgList.Rows.Clear()
        txtCustCode.Focus()
      End If
    End If
  End Sub
End Class