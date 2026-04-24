Public Class frmGoodRequest

  Private Sub frmGoodRequest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    CheckPriv()
    ShowGoodType()
    ShowRequest()
  End Sub

  Private Sub CheckPriv()
    ' Add
    If InStr(pUserPriv, Me.Tag.ToString & "A") > 0 Then
      tbnSave.Enabled = True
    Else
      tbnSave.Enabled = False
    End If
    ' Delete
    If InStr(pUserPriv, Me.Tag.ToString & "D") > 0 Then
      tbnDelete.Enabled = True
    Else
      tbnDelete.Enabled = False
    End If
    '' Level 2 and 3 Only
    'If InStr(pUserPriv, "LEVEL2") > 0 OrElse InStr(pUserPriv, "LEVEL3") > 0 Then
    '  tbnSave.Visible = True
    'Else
    '  tbnSave.Visible = False
    'End If
  End Sub

  Private Sub ShowGoodType()
    cboTypeCode.Items.Clear()
    cboTypeDesc.Items.Clear()

    For i As Integer = 0 To pGoodType.Length - 1
      cboTypeCode.Items.Add(pGoodType(i).Code)
      cboTypeDesc.Items.Add(pGoodType(i).Description)
    Next
  End Sub

  Private Sub cboTypeDesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTypeDesc.SelectedIndexChanged
    cboTypeCode.SelectedIndex = cboTypeDesc.SelectedIndex
  End Sub

  Private Sub ShowRequest()
    Me.Cursor = Cursors.WaitCursor

    dtgRequList.Rows.Clear()
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select GR.*, TI.typeDesc from GoodRequest GR inner join TypeInfo TI on TI.typeCode = GR.typeCode where GR.branchCode = '" & pBranchCode & "' order by GR.requDate desc")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      For i As Integer = 0 To dv.Count - 1
        With dv.Item(i)
          dtgRequList.Rows.Add()
          dtgRequList.Item("requNumb", i).Value = .Item("requNumb")
          dtgRequList.Item("requDate", i).Value = .Item("requDate")
          dtgRequList.Item("typeDesc", i).Value = .Item("typeDesc")
          dtgRequList.Item("goodName", i).Value = .Item("goodName")
          dtgRequList.Item("genericName", i).Value = .Item("genericName")
          dtgRequList.Item("requRema", i).Value = .Item("requRema")
          dtgRequList.Item("saleGuess", i).Value = .Item("saleGuess")
          dtgRequList.Item("emplName", i).Value = .Item("emplName")
          dtgRequList.Item("requStat", i).Value = .Item("requStat")
        End With
      Next
      dv = Nothing
    End If
    ds = Nothing

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnSave.Click
    If cboTypeDesc.Text = "" OrElse txtGoodName.Text.Trim = "" OrElse cboRequRema.Text.Trim = "" OrElse txtEmplName.Text.Trim = "" Then
      MessageBox.Show("กรุณาป้อนข้อมูลให้ครบ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If

    pServerDateTime = pService.ServerDateTime

    Dim mSqlText(1) As String
    mSqlText(0) = "Insert into GoodRequest (requDate, branchCode, emplName, typeCode, goodName, genericName, requRema, saleGuess, requStat) values ('" & MDYStr(pServerDateTime.Date) & "', '" & pBranchCode & "', '" & txtEmplName.Text & "', '" & cboTypeCode.Text & "', '" & txtGoodName.Text & "', '" & txtGenericName.Text & "', '" & cboRequRema.Text & "', '" & txtSaleGuess.Text & "', ' ')"

    Dim mUpdate As String
    mUpdate = pService.UpdateData("Drug", mSqlText)
    If mUpdate = "1" Then
      ClearData()
      ShowRequest()
      txtGoodName.Focus()
    End If
  End Sub

  Private Sub ClearData()
    txtGoodName.Text = ""
    txtGenericName.Text = ""
    cboRequRema.Text = ""
    txtSaleGuess.Text = ""
    txtEmplName.Text = ""
  End Sub

  Private Sub tbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnDelete.Click
    If dtgRequList.Rows.Count > 0 Then
      Dim mGoodName As String
      'Dim mRequDate As Date
      Dim mRequNumb As Long
      mGoodName = dtgRequList.Item("goodName", dtgRequList.CurrentRow.Index).Value.ToString
      'mRequDate = CDate(dtgRequList.Item("requDate", dtgRequList.CurrentRow.Index).Value)
      mRequNumb = CInt(dtgRequList.Item("requNumb", dtgRequList.CurrentRow.Index).Value)

      If MessageBox.Show("ยืนยันลบรายการ : '" & mGoodName & "'", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        Dim mSqlText(1) As String
        'mSqlText(0) = "Delete from GoodRequest where goodName = '" & mGoodName & "' and requDate = '" & MDYStr(mRequDate) & "' and branchCode = '" & pBranchCode & "'"
        mSqlText(0) = "Delete from GoodRequest where requNumb = " & mRequNumb

        Dim mUpdate As String
        mUpdate = pService.UpdateData("Drug", mSqlText)
        If mUpdate = "1" Then
          ClearData()
          ShowRequest()
        Else
          MessageBox.Show(mUpdate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
      End If
    End If
  End Sub

  Private Sub txtGoodName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGoodName.KeyPress, txtGenericName.KeyPress, txtSaleGuess.KeyPress, txtEmplName.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub
End Class