Public Class frmFingerPrintEnroll

  Dim mEmplCode As String
  Dim FTempLen As Short
  Dim FRegTemplate As Object
  Dim FingerCount As Integer
  Dim fpcHandle As Integer
  Dim mEmplName() As String
  Dim FMatchType As Short
  Dim Fid As Short
  Dim mConnect As Boolean
  Dim strTemp As String

  Private Sub frmFingerPrintEnroll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    pan1.Visible = True
    spc1.Visible = False

    'InitSensor()
    'LoadFromDB()
  End Sub

  Private Sub frmFingerPrintEnroll_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    If mConnect = True Then
      Me.Cursor = Cursors.WaitCursor

      ZKFPEngX1.FreeFPCacheDBEx(fpcHandle) 'เคลียร์ cache ที่สร้างไว้
      ZKFPEngX1.EndEngine() 'หยุดการติดต่อกับ หัวอ่าน
      FingerCount = 0

      Me.Cursor = Cursors.Default
    End If
  End Sub

  Private Sub InitSensor()
    ZKFPEngX1.SensorIndex = 0
    If ZKFPEngX1.InitEngine = 0 Then  'ทำการค้นหาหัวอ่านที่อยู่ในเครื่อง

      'ZKFPEngX1.FPEngineVersion = "10" 'ใช้รูปแบบค้นหาลายนิ้วมือแบบเวอร์ชั่น 10

      fpcHandle = ZKFPEngX1.CreateFPCacheDBEx 'ประกาศให้มีการสร้าง Cache ฐานข้อมูลใน Memory แบบใช้เวอร์ชั่น 9 และ 10 ซึ่งจะมีการ
      'เรียกใช้ข้อมูลของเวอร์ชั่น 9 และ 10 ในเวลาเดียวกัน การใช้งานในรูปแบบ อย่างใดอย่างหนึ่ง โปรดศึกษาด้วยตนเองเพิ่มเติม

      'MsgBox("การเชื่อมต่อหัวอ่านสำเร็จ", vbDefaultButton1, "สำเร็จ")
      'StatusBar.Text = "Sensor เชื่อมต่อแล้ว"
      txtSensorCount.Text = ZKFPEngX1.SensorCount & ""  'นับหัวอ่าน
      txtSensorIndex.Text = ZKFPEngX1.SensorIndex & ""    'เลือกใช้ตัวไหน
      txtSensorSN.Text = ZKFPEngX1.SensorSN  'ค่า Serial Number ของหัวอ่าน

      ZKFPEngX1.EnrollCount = 3  'กำหนดให้การเก็บลายนิ้วมือต้นฉบับต้อง วางนิ้ว 3 ครั้ง
      'cmdInit.Enabled = False
      FMatchType = 2

      FingerCount = 0  'กำหนดนิ้วเริ่มต้นของนิ้วที่จะเก็บลงไปใน Memory

      strTemp = ""

      'โหลดลายนิ้วมือเข้าระบบจากฐานข้อมูลที่ถูกเก็บไว้ก่อนหน้านี้()
      'LoadDB()

      mConnect = True

      ZKFPEngX1.ControlSensor(13, 1)
      ZKFPEngX1.ControlSensor(13, 0)


      LoadFromDB()

      spc1.Visible = True
      pan1.Visible = False
      txtIDCardNumber.Focus()

    Else
      MessageBox.Show("ไม่สามารถติดต่อกับเครื่องสแกนลายนิ้วมือได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error)
      ZKFPEngX1.FreeFPCacheDBEx(fpcHandle) 'เคลียร์ cache ที่สร้างไว้
      ZKFPEngX1.EndEngine() 'หยุดการติดต่อกับ หัวอ่าน
      FingerCount = 0

      pan1.Visible = True
      spc1.Visible = False
    End If
  End Sub

  Private Sub cmdEnroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnroll.Click
    If txtIDCardNumber.Text = "" Then
      MessageBox.Show("กรุณาป้อนเลขที่บัตรประชาชน", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If
    If cboFingerName.Text = "" Then
      MessageBox.Show("กรุณาเลือกนิ้วมือที่ต้องการเก็บ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End If
    'เริ่มสั่งให้เก็บลายนิ้วมือ
    ZKFPEngX1.BeginEnroll()
    lblStatusBar.Text = "กรุณาวางนิ้วบนแท่นสแกน"
  End Sub

  Private Sub ZKFPEngX1_OnImageReceived(ByVal sender As Object, ByVal e As AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEvent) Handles ZKFPEngX1.OnImageReceived
    Dim hDC As Integer
    hDC = picFingerPrint.CreateGraphics.GetHdc.ToInt64
    ZKFPEngX1.PrintImageAt(hDC, 0, 0, 250, 400) 'กำหนดความกว้าง ยาวและตำแหน่งที่จะให้แสดงบน PictureBox สามารถกำหนดค่าให้ได้ตรงกับต้องการ
  End Sub

  Private Sub ZKFPEngX1_OnFeatureInfo(ByVal sender As Object, ByVal e As AxZKFPEngXControl.IZKFPEngXEvents_OnFeatureInfoEvent) Handles ZKFPEngX1.OnFeatureInfo
    If ZKFPEngX1.IsRegister Then
      strTemp = strTemp & "สแกนนิ้วครั้งที่ " & ZKFPEngX1.EnrollIndex & " : "
    End If
    If e.aQuality <> 0 Then
      strTemp = strTemp & " ไม่ผ่าน " & e.aQuality 'ในบางครั้ง หาก ชุดหัวอ่านที่เอามาต่อใช้งานไม่มี licens จะขึ้นข้อความ Bad
    Else
      strTemp = strTemp & " ผ่าน "
    End If
    strTemp = strTemp & vbCrLf

    lblStatusBar.Text = strTemp

  End Sub

  Private Sub ZKFPEngX1_OnEnroll(ByVal sender As Object, ByVal e As AxZKFPEngXControl.IZKFPEngXEvents_OnEnrollEvent) Handles ZKFPEngX1.OnEnroll
    Dim sTemp As String
    Dim sTempV10 As String

    If Not e.actionResult Then
      MessageBox.Show("บันทึกผิดพลาด", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error)
      lblStatusBar.Text = ""
    Else
      FRegTemplate = e.aTemplate

      sTempV10 = ZKFPEngX1.GetTemplateAsStringEx("10") 'เก็บข้อมูลแบบ String เข้าไว้ที่ตัวแปร โดยเป็นเวอร์ชั่น 10
      sTemp = ZKFPEngX1.GetTemplateAsStringEx("9") 'เก็บข้อมูลแบบ String เข้าไว้ที่ตัวแปร โดยเป็นเวอร์ชั่น 10

      ' บันทึก
      SaveToDB(0, cboFingerName.Text, sTemp, sTempV10, mEmplCode)

      ZKFPEngX1.AddRegTemplateStrToFPCacheDBEx(fpcHandle, FingerCount, sTemp, sTempV10) 'เพิ่มนิ้วที่เก็บใหม่เข้า Cache ในรูปแบบสตริง

      ReDim Preserve mEmplName(FingerCount + 1)
      mEmplName(FingerCount) = txtEmplName.Text
      FingerCount = FingerCount + 1
    End If
  End Sub

  Private Sub LoadFromDB()
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select fpString, fpStringV10, emplName from EmplInfo where fingerName <> '' and emplStat = '1'")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      Dim sTemp As String 'ตัวแปรลายนิ้วมือเวอร์ชั้่น 9
      Dim sTempV10 As String  'ตัวแปรลายนิ้วมือเวอร์ชั้่น 10
      For i As Integer = 0 To dv.Count - 1
        sTemp = dv.Item(i).Item("fpstring") 'ฐานข้อมูลนิ้วเก็บในตรงนี้
        sTempV10 = dv.Item(i).Item("fpstringV10") 'ฐานข้อมูลนิ้วเก็บในตรงนี้
        ZKFPEngX1.AddRegTemplateStrToFPCacheDBEx(fpcHandle, FingerCount, sTemp, sTempV10)  'เพิ่ม ลายนิ้วมือเข้าไป โดยมี FingerCount เป็นตัวนับนิ้ว รูปแบบลายนิ้วมือที่ loop เข้าเป็นแบบ string
        ReDim Preserve mEmplName(FingerCount + 1) 'สร้าง Array ของตัวแปร เพื่อเก็บชื่อ ของนิ้ว เอาไว้เรียกมาแสดงตอนแสดงผล
        mEmplName(FingerCount) = dv.Item(i).Item("emplName") 'เอาข้อมูลเข้า
        FingerCount = FingerCount + 1
      Next
    End If
    ds = Nothing
  End Sub

  Private Sub SaveToDB(ByVal inID As Long, ByVal fingerName As String, ByVal fpString As String, ByVal fpStringV10 As String, ByVal EmplCode As String)
    Dim mSqlText(1) As String
    mSqlText(0) = "Update EmplInfo set fingerName = '" & fingerName & "', fpString = '" & fpString & "', fpStringV10 = '" & fpStringV10 & "' Where emplCode = '" & EmplCode & "'"
    Dim mUpdate As String
    mUpdate = pService.UpdateData("Drug", mSqlText)
    If mUpdate = "1" Then
      MessageBox.Show("บันทึกข้อมูลเรียบร้อย", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      txtIDCardNumber.Text = ""
      txtEmplName.Text = ""
      lblStatusBar.Text = ""
      picEmpl.Image = Nothing
      picFingerPrint.Image = Nothing
      txtIDCardNumber.Focus()
    Else
      MessageBox.Show(mUpdate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End If
  End Sub

  Private Sub txtIDCardNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIDCardNumber.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{Tab}")
    End If
  End Sub

  Private Sub txtIDCardNumber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIDCardNumber.LostFocus
    If txtIDCardNumber.Text <> "" Then
      Dim mGet() As String
      mGet = pService.GetData("Drug", "Select emplCode, emplName from EmplInfo where emplID = '" & txtIDCardNumber.Text & "' and emplStat = '1'")
      If mGet(0) = "1" Then
        mEmplCode = mGet(1)
        txtEmplName.Text = mGet(2)
        ' แสดงรูปถ่าย
        Try
          Dim mEmplImageURL As String
          mEmplImageURL = pEmplImageFolder & "/" & txtIDCardNumber.Text & ".png"
          Dim mImage As New DownLoadImage(mEmplImageURL)
          Dim mMemStream As IO.MemoryStream = mImage.BeginDownLoad
          picEmpl.Image = Image.FromStream(mMemStream)
        Catch ex As Exception
          If Not (picEmpl.Image Is Nothing) Then
            picEmpl.Image.Dispose()
            picEmpl.Image = Nothing
          End If
        End Try
      Else
        MessageBox.Show("ไม่พบข้อมูลพนักงาน", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        txtIDCardNumber.Text = ""
        txtEmplName.Text = ""
        picEmpl.Image = Nothing
        txtIDCardNumber.Focus()
      End If
    End If
  End Sub

  Private Sub ZKFPEngX1_OnCapture(ByVal sender As Object, ByVal e As AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEvent) Handles ZKFPEngX1.OnCapture
    Dim fi As Long
    Dim Score As Long, ProcessNum As Long
    Dim RegChanged As Boolean
    Dim strSQL As String
    Dim sTemp As String
    Dim sTemp1 As String

    lblStatusBar.Text = "ข้อมูลของลายนิ้วมือ"
    If FMatchType = 1 Then  '1:1 ค้นหาแบบ 1 ต่อ 1 คือ มีการ โหลดลายนิ้วมือต้นแบบ มาเปรียบเทียบกับลายนิ้วมือที่วางลงไป

      'Dim mGet() As String
      strSQL = "select fpstring from fptable where name='" & cboFingerName.Text & "'"
      'sTemp = FingerFromDB(strSQL) 'ดึงลายนิ้วมือที่จะเปรียบเทียบจากฐานข้อมูล


      sTemp1 = ZKFPEngX1.GetTemplateAsString  'ขอค่าลายนิ้วมือในรูปแบบ string ที่ได้จากการวาง 'ขอค่าลายนิ้วมือในรูปแบบ string ที่ได้จากการวาง
      'sTemp2 = ZKFPEngX1.GetTemplateAsStringEx("9")
      'sTemp3 = ZKFPEngX1.GetTemplateAsStringEx("10")

      If ZKFPEngX1.VerFingerFromStr(sTemp, sTemp1, False, RegChanged) Then  'ทำการเปรียบเทียบแบบ 1 ต่อ 1 คือนิ้วมือที่เก็บจากฐานข้อมูล และลายนิ้วมือที่วางลงไปใหม่
        'โดยใช้การเปรียบเทียบใน เวอร์ชั่น 9
        MsgBox(cboFingerName.Text & " การค้นหาสำเร็จ", MsgBoxStyle.DefaultButton1, "ผ่าน")
      Else
        MsgBox("ไม่ใช่นิ้วของ " & cboFingerName.Text, vbCritical, "ไม่ผ่าน")
      End If

    ElseIf FMatchType = 2 Then '1:N ค้นหาแบบ 1 ต่อจำนวนที่ เก็บลงใน Mem ตอนแรก
      Score = 8
      sTemp = ZKFPEngX1.GetTemplateAsString
      fi = ZKFPEngX1.IdentificationFromStrInFPCacheDB(fpcHandle, sTemp, Score, ProcessNum) 'ทำการเปรียบเทียบ แบบ 1 ต่อ N
      If fi = -1 Then
        'MsgBox "ค้นหาไม่เจอ", vbCritical, "ผิดพลาด"
        lblStatusBar.Text = "ค้นหาไม่เจอ"
      Else
        'ส่วนสำคัญที่จะนำไปใช้ในการเขียนโปรแกรมต่อ
        'MsgBox "การค้นหาสำเร็จ ชื่อ =" & FFingerNames(fi) & " Score = " & Score & " Processed Number = " & ProcessNum, vbMsgBoxRight, "ผ่าน"  'คืนค่าการค้นหาออกมาให้ ซึ่งตรงนี้ สามารถเอาไปเรียกข้อมูลอื่นๆ มาใช้งานต่อ <- จุดสำคัญที่จะนำเอาไปใช้งาน
        lblStatusBar.Text = "การค้นหาสำเร็จ " & mEmplName(fi) & " Score = " & Score & " Processed Number = " & ProcessNum

      End If
    End If
  End Sub

  Private Sub btnInitSensor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitSensor.Click
    InitSensor()
  End Sub
End Class