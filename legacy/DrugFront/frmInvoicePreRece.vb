Public Class frmInvoicePreRece

  Public pInvoNumb As String
  Public pGoodCode As String
  Public pGoodName As String
  Public pUnitDesc As String
  Public pUnitCost As Double
  'Public pStockOnhand As Integer
  Public pStockUnitCost As Double
  Public pNoBranchStock As String
  Public pSendAmou As Integer
  Public pReceAmou As Integer
  Public pOk As Boolean

  Private Sub frmInvoicePreRece_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Icon = frmMain.Icon

    txtGoodName.Text = pGoodName
    txtUnitDesc.Text = pUnitDesc
    txtSendAmou.Text = pSendAmou

    pOk = False
  End Sub

  Private Sub txtReceAmou_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReceAmou.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    If txtReceAmou.Text <> "" Then
      If Val(txtReceAmou.Text) <= 0 Then
        pMessageBox = New MyMessageBox("กรุณาป้อนจำนวนรับ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        pMessageBox.ShowDialog()
        Exit Sub
      End If

      If Val(txtReceAmou.Text) <> Val(txtSendAmou.Text) Then
        pMessageBox = New MyMessageBox("จำนวนรับไม่เท่ากับจำนวนส่ง !" & vbCrLf & "ยืนยันรับสินค้า", "คำเตือน", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
        If pMessageBox.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
          Exit Sub
        End If
      Else
        pMessageBox = New MyMessageBox("ยืนยันรับสินค้า", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If pMessageBox.ShowDialog = Windows.Forms.DialogResult.Cancel Then
          Exit Sub
        End If
      End If

      Dim mSqlText(12) As String
      Dim mLine As Integer = 0
      Dim mReceAmou As Integer
      Dim mAvgCost As Double
      Dim mStockOnhand As Integer
      Dim mStockOnhandField As String = "stockOnhand" & pBranchCode
      Dim mUnitCostField As String = "unitCost" & pBranchCode

      pServerDateTime = pService.ServerDateTime
      mReceAmou = CInt(Val(txtReceAmou.Text))
      mStockOnhand = CheckStockOnhand(pGoodCode, mStockOnhandField)

      ' รับตามจำนวนที่ส่ง
      ' Front card
      mSqlText(mLine) = "Insert into FrontCard (stockDate, stockTime, workType, branchCode, docNumb, emplName, goodCode, goodAmou, stockOnhand) Values ('" & MDYStr(pServerDateTime.Date) & "', '" & Format(pServerDateTime, "HH:mm") & "', 'REX', '" & pBranchCode & "', '" & pInvoNumb & "', '" & Mid(pUserName, 1, 10) & "', '" & pGoodCode & "', " & pSendAmou & ", " & (mStockOnhand + pSendAmou) & ")"
      mLine += 1

      If pNoBranchStock = "0" Then ' ตัดสต๊อคเฉพาะสินค้าที่ระบุให้เก็บสตีอค
        ' ราคาทุนเฉลี่ยใหม่ คำนวนจาก (มูลค่าจน.ที่เหลือ + มูลค่าจน.ที่รับ) / จำนวนทั้งหมด
        If mStockOnhand <= 0 Then ' ถ้าสต๊อคเดิมเป็นศูนย์หรือติดลบ ให้ใช้ทุนเฉลี่ยใหม่
          mAvgCost = pUnitCost
        Else
          mAvgCost = ((mStockOnhand * pStockUnitCost) + (pSendAmou * pUnitCost)) / (mStockOnhand + pSendAmou)
        End If

        mSqlText(mLine) = "UPDATE GoodInfo SET " & mStockOnhandField & " = " & mStockOnhandField & " + " & pSendAmou & ", " & mUnitCostField & " = " & mAvgCost & " WHERE goodCode = '" & pGoodCode & "'"
        mLine += 1
      End If
      ' เก็บข้อมูลรับด่วน ตามจำนวนรับจริง
      mSqlText(mLine) = "Insert into InvoicePreRece (invoNumb, goodCode, goodAmou) values ('" & pInvoNumb & "', '" & pGoodCode & "', " & mReceAmou & ")"
      mLine += 1

      Dim mUpdate As String
      mUpdate = pService.UpdateData("Drug", mSqlText)
      If mUpdate(0) = "1" Then
        pReceAmou = mReceAmou
        pOk = True
        Me.Close()
      Else
        pMessageBox = New MyMessageBox(mUpdate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        pMessageBox.ShowDialog()
      End If
    End If
  End Sub

  Private Function CheckStockOnhand(ByVal GoodCode As String, ByVal StockOnhandField As String) As Integer
    Dim mStockOnhand As Integer = 0
    Dim mGet() As String
    mGet = pService.GetData("Drug", "Select " & StockOnhandField & " from GoodInfo where goodCode = '" & GoodCode & "'")
    If mGet(0) = "1" Then
      mStockOnhand = CInt(mGet(1))
    End If
    Return mStockOnhand
  End Function
End Class