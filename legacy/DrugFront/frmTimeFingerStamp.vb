Public Class frmTimeFingerStamp

  Dim mNow As Date

  Dim FTempLen As Short
  Dim FRegTemplate As Object
  Dim FingerCount As Integer
  Dim fpcHandle As Integer
  Dim mEmplCode() As String
  Dim FMatchType As Short
  Dim Fid As Short
  Dim mConnect As Boolean

  Private Sub frmTimeStamp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    pan1.Visible = False
    pan2.Visible = True
  End Sub

  Private Sub frmTimeFingerStamp_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

      fpcHandle = ZKFPEngX1.CreateFPCacheDBEx 'ประกาศให้มีการสร้าง Cache ฐานข้อมูลใน Memory แบบใช้เวอร์ชั่น 9 และ 10 ซึ่งจะมีการ
      'เรียกใช้ข้อมูลของเวอร์ชั่น 9 และ 10 ในเวลาเดียวกัน การใช้งานในรูปแบบ อย่างใดอย่างหนึ่ง โปรดศึกษาด้วยตนเองเพิ่มเติม

      ZKFPEngX1.EnrollCount = 3  'กำหนดให้การเก็บลายนิ้วมือต้นฉบับต้อง วางนิ้ว 3 ครั้ง
      FMatchType = 2

      FingerCount = 0  'กำหนดนิ้วเริ่มต้นของนิ้วที่จะเก็บลงไปใน Memory

      mConnect = True

      ZKFPEngX1.ControlSensor(13, 1)
      ZKFPEngX1.ControlSensor(13, 0)

      pan2.Visible = False
      pan1.Visible = True

      lblEmplName.Text = ""
      lblTimeStamp.Text = ""
      lblPosition.Text = ""
      picEmpl.Image = My.Resources.fingerprint

      ShowTime()

      LoadFromDB()

    Else
      MessageBox.Show("ไม่สามารถติดต่อกับเครื่องสแกนลายนิ้วมือได้", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error)
      ZKFPEngX1.FreeFPCacheDBEx(fpcHandle) 'เคลียร์ cache ที่สร้างไว้
      ZKFPEngX1.EndEngine() 'หยุดการติดต่อกับ หัวอ่าน
      FingerCount = 0

      pan2.Visible = True
      pan1.Visible = False
    End If
  End Sub

  Private Sub LoadFromDB()
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select fpString, fpStringV10, emplCode from EmplInfo where fingerName <> '' and emplStat = '1' and (branchCode = '" & pBranchCode & "' or branchCode = '0')")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      Dim sTemp As String 'ตัวแปรลายนิ้วมือเวอร์ชั้่น 9
      Dim sTempV10 As String  'ตัวแปรลายนิ้วมือเวอร์ชั้่น 10
      For i As Integer = 0 To dv.Count - 1
        sTemp = dv.Item(i).Item("fpstring") 'ฐานข้อมูลนิ้วเก็บในตรงนี้
        sTempV10 = dv.Item(i).Item("fpstringV10") 'ฐานข้อมูลนิ้วเก็บในตรงนี้
        ZKFPEngX1.AddRegTemplateStrToFPCacheDBEx(fpcHandle, FingerCount, sTemp, sTempV10)  'เพิ่ม ลายนิ้วมือเข้าไป โดยมี FingerCount เป็นตัวนับนิ้ว รูปแบบลายนิ้วมือที่ loop เข้าเป็นแบบ string
        ReDim Preserve mEmplCode(FingerCount + 1) 'สร้าง Array ของตัวแปร เพื่อเก็บชื่อ ของนิ้ว เอาไว้เรียกมาแสดงตอนแสดงผล
        mEmplCode(FingerCount) = dv.Item(i).Item("emplCode") 'เอาข้อมูลเข้า
        FingerCount = FingerCount + 1
      Next
    End If
    ds = Nothing
  End Sub

  Private Sub ZKFPEngX1_OnCapture(ByVal sender As Object, ByVal e As AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEvent) Handles ZKFPEngX1.OnCapture
    Dim fi As Long
    Dim Score As Long, ProcessNum As Long
    Dim sTemp As String

    '1:N ค้นหาแบบ 1 ต่อจำนวนที่ เก็บลงใน Mem ตอนแรก
    Score = 8
    sTemp = ZKFPEngX1.GetTemplateAsString
    fi = ZKFPEngX1.IdentificationFromStrInFPCacheDB(fpcHandle, sTemp, Score, ProcessNum) 'ทำการเปรียบเทียบ แบบ 1 ต่อ N
    If fi = -1 Then
      MessageBox.Show("ไม่พบข้อมูลลายนิ้วมือ", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error)
    Else
      SaveData(mEmplCode(fi))
    End If
  End Sub

  Private Sub SaveData(ByVal EmplCode As String)
    ' Add
    If InStr(pUserPriv, Me.Tag.ToString & "A") <= 0 Then
      Exit Sub
    End If

    If EmplCode <> "" Then
      Dim ds As New DataSet
      ds = pService.SelectData("Drug", "SELECT emplCode, emplName, emplPosition, emplID, dateStamp, inTime, inBranchCode FROM EmplInfo WHERE emplCode = '" & EmplCode & "' AND emplStat = '1'")
      If IsNothing(ds) = False Then
        Dim dv As New DataView(ds.Tables(0))
        If dv.Count > 0 Then
          Dim mEmplCode, mEmplName, mEmplPosition, mEmplID As String
          Dim mDate, mInDate As Date
          Dim mTime, mInTime As String
          Dim mInBranchCode As String
          pServerDateTime = pService.ServerDateTime
          mDate = CDate(pServerDateTime)
          mTime = Format(pServerDateTime, "HH:mm")

          mEmplCode = dv.Item(0).Item("emplCode").ToString
          mEmplName = dv.Item(0).Item("emplName").ToString
          mEmplID = dv.Item(0).Item("emplID").ToString
          mEmplPosition = dv.Item(0).Item("emplPosition").ToString
          mInDate = CDate(dv.Item(0).Item("dateStamp"))
          mInTime = dv.Item(0).Item("inTime").ToString
          mInBranchCode = dv.Item(0).Item("inBranchCode").ToString

          Dim mTimeStamp As String
          Dim mColor As Color
          Dim mSqlText(1) As String
          Dim mUpdate As String

          If mInDate <> mDate.Date Or mInTime = "" Or mInBranchCode <> pBranchCode Then ' เข้า เพิ่ม record ใหม่ กรณียังไม่ได้เข้า หรือเข้าแล้วแต่เป็นวันที่อื่น หรือเข้าแล้วแต่คนละสาขา
            mSqlText(0) = "INSERT INTO ETimeStamp (emplCode, branchCode, dateStamp, inTime, outTime, inStampType) VALUES ('" & mEmplCode & "', '" & pBranchCode & "', '" & MDYStr(mDate) & "', '" & mTime & "', '', 'F')"
            mSqlText(1) = "UPDATE EmplInfo SET dateStamp = '" & MDYStr(mDate) & "', inTime = '" & mTime & "', inBranchCode = '" & pBranchCode & "' WHERE emplCode = '" & mEmplCode & "'"

            mTimeStamp = "เข้า " & mTime & " น."
            mColor = Color.DarkBlue
          Else ' ออก
            mSqlText(0) = "UPDATE ETimeStamp SET outTime = '" & mTime & "', outStampType = 'F' WHERE emplCode = '" & mEmplCode & "' AND dateStamp = '" & MDYStr(mInDate) & "' AND inTime = '" & mInTime & "'"
            mSqlText(1) = "UPDATE EmplInfo SET dateStamp = '" & MDYStr(mDate) & "', inTime = '', inBranchCode = '' WHERE emplCode = '" & mEmplCode & "'"

            mTimeStamp = "ออก " & mTime & " น."
            mColor = Color.DarkRed
          End If

          mUpdate = pService.UpdateData("Drug", mSqlText)
          If mUpdate = "1" Then
            lblEmplName.Text = mEmplName
            lblPosition.Text = mEmplPosition
            lblTimeStamp.ForeColor = mColor
            lblTimeStamp.Text = mTimeStamp
            ' แสดงรูปถ่าย
            Try
              Dim mEmplImageURL As String
              mEmplImageURL = pEmplImageFolder & "/" & mEmplID & ".png"
              Dim mImage As New DownLoadImage(mEmplImageURL)
              Dim mMemStream As IO.MemoryStream = mImage.BeginDownLoad
              picEmpl.Image = Image.FromStream(mMemStream)
            Catch ex As Exception
              If Not (picEmpl.Image Is Nothing) Then
                picEmpl.Image.Dispose()
                picEmpl.Image = Nothing
              End If
            End Try
            Timer1.Enabled = True

          Else
            MessageBox.Show("ไม่สามารถบันทึกเวลาเข้า-ออกได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ClearField()
          End If
        Else
          MessageBox.Show("ไม่มีข้อมูลพนักงาน", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
          ClearField()
        End If
        dv = Nothing
      End If
      ds = Nothing

    End If
  End Sub

  Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    Timer1.Enabled = False
    ClearField()
  End Sub

  Private Sub ClearField()
    lblEmplName.Text = ""
    lblTimeStamp.Text = ""
    lblPosition.Text = ""
    picEmpl.Image = My.Resources.fingerprint
    'If picEmpl.Image IsNot Nothing Then
    '  picEmpl.Image.Dispose()
    '  picEmpl.Image = Nothing
    'End If
  End Sub

  Private Sub frmTimeStamp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.F12 ' เรียกหน้าต่างลงเวลาแบบเดิม
        ' Level 2 and 3 Only
        If InStr(pUserPriv, "LEVEL2") = 0 AndAlso InStr(pUserPriv, "LEVEL3") = 0 Then
          Dim fPass As New frmPass
          fPass.ShowDialog()
          If fPass.pOK = True Then
            If InStr(fPass.pPassPriv, "LEVEL2") = 0 AndAlso InStr(fPass.pPassPriv, "LEVEL3") = 0 Then
              MessageBox.Show("ท่านไม่ได้รับอนุญาตให้เข้าใช้งาน", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
              Exit Sub
            End If
          Else
            Exit Sub
          End If
        End If

        frmTimeStamp.ShowDialog()
        frmTimeStamp = Nothing
      Case Keys.Escape
        Me.Close()
    End Select
  End Sub

  Private Sub timeServerDateTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timeServerDateTime.Tick
    ShowTime()
  End Sub

  Private Sub ShowTime()
    ' ใช้วันที่และเวลาของ server
    mNow = pService.ServerDateTime
    lblServerDate.Text = ThaiDate(mNow)
    lblServerTime.Text = Format(mNow, "HH:mm")
  End Sub

  Private Sub ZKFPEngX1_OnFingerTouching(ByVal sender As Object, ByVal e As System.EventArgs) Handles ZKFPEngX1.OnFingerTouching
    ' ส่งเสียง
    ZKFPEngX1.ControlSensor(13, 1)
    ZKFPEngX1.ControlSensor(13, 0)
  End Sub

  Private Sub btnInitSensor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitSensor.Click
    InitSensor()
  End Sub
End Class