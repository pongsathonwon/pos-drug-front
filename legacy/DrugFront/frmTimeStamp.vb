Public Class frmTimeStamp

  Dim mNow As Date

  Private Sub frmTimeStamp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    lblEmplName.Text = ""
    lblTimeStamp.Text = ""
    lblPosition.Text = ""

    ShowTime()
  End Sub

  Private Sub frmTimeStamp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.Escape Then
      e.Handled = True
      Me.Close()
    End If
  End Sub

  Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmplID.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      'Call ShowData()
      txtEmplID.Enabled = False
      SaveData()
    End If
  End Sub

  Private Sub SaveData()
    ' Add
    If InStr(pUserPriv, Me.Tag.ToString & "A") <= 0 Then
      Exit Sub
    End If

    If txtEmplID.Text <> "" Then
      Dim ds As New DataSet
      ds = pService.SelectData("Drug", "SELECT EI.emplCode, EI.emplName, EI.dateStamp, EI.inTime, EI.inBranchCode, EP.emplPosiName FROM EmplInfo EI inner join EmplPosition EP on EP.emplPosiCode = EI.emplPosiCode WHERE emplID = '" & txtEmplID.Text & "' AND emplStat = '1'")
      If IsNothing(ds) = False Then
        Dim dv As New DataView(ds.Tables(0))
        If dv.Count > 0 Then
          Dim mEmplCode, mEmplName, mEmplPosition As String
          Dim mDate, mInDate As Date
          Dim mTime, mInTime As String
          Dim mInBranchCode As String
          pServerDateTime = pService.ServerDateTime
          mDate = CDate(pServerDateTime)
          mTime = Format(pServerDateTime, "HH:mm")

          mEmplCode = dv.Item(0).Item("emplCode").ToString
          mEmplName = dv.Item(0).Item("emplName").ToString
          mEmplPosition = dv.Item(0).Item("emplPosiName").ToString
          mInDate = CDate(dv.Item(0).Item("dateStamp"))
          mInTime = dv.Item(0).Item("inTime").ToString
          mInBranchCode = dv.Item(0).Item("inBranchCode").ToString

          Dim mTimeStamp As String
          Dim mColor As Color
          Dim mSqlText(1) As String
          Dim mUpdate As String

          If mInDate <> mDate.Date Or mInTime = "" Or mInBranchCode <> pBranchCode Then ' เข้า เพิ่ม record ใหม่ กรณียังไม่ได้เข้า หรือเข้าแล้วแต่เป็นวันที่อื่น หรือเข้าแล้วแต่คนละสาขา
            mSqlText(0) = "INSERT INTO ETimeStamp (emplCode, branchCode, dateStamp, inTime, outTime, inStampType) VALUES ('" & mEmplCode & "', '" & pBranchCode & "', '" & MDYStr(mDate) & "', '" & mTime & "', '', 'K')"
            mSqlText(1) = "UPDATE EmplInfo SET dateStamp = '" & MDYStr(mDate) & "', inTime = '" & mTime & "', inBranchCode = '" & pBranchCode & "' WHERE emplCode = '" & mEmplCode & "'"

            mTimeStamp = "เข้า " & mTime & " น."
            mColor = Color.DarkBlue
          Else ' ออก
            mSqlText(0) = "UPDATE ETimeStamp SET outTime = '" & mTime & "', outStampType = 'K' WHERE emplCode = '" & mEmplCode & "' AND dateStamp = '" & MDYStr(mInDate) & "' AND inTime = '" & mInTime & "'"
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
              mEmplImageURL = pEmplImageFolder & "/" & txtEmplID.Text & ".png"
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
            txtEmplID.Focus()
          End If
        Else
          MessageBox.Show("ไม่มีข้อมูลพนักงาน", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
          ClearField()
          txtEmplID.Focus()
        End If
        dv = Nothing
      End If
      ds = Nothing


      'Dim mGet() As String
      'mGet = pService.GetData("Drug", "SELECT emplCode, emplName, emplPosition, dateStamp, inTime, inBranchCode FROM EmplInfo WHERE emplID = '" & txtEmplID.Text & "' AND emplStat = '1'")
      'If mGet(0) = "1" Then
      '  Dim mEmplCode, mEmplName, mEmplPosition As String
      '  Dim pServerDateTime As Date
      '  Dim mDate, mInDate As Date
      '  Dim mTime, mInTime As String
      '  Dim mInBranchCode As String
      '  pServerDateTime = pService.ServerDateTime
      '  mDate = CDate(pServerDateTime)
      '  mTime = Format(pServerDateTime, "HH:mm")

      '  mEmplCode = mGet(1)
      '  mEmplName = mGet(2)
      '  mEmplPosition = mGet(3)
      '  mInDate = CDate(mGet(4))
      '  mInTime = mGet(5)
      '  mInBranchCode = mGet(6)

      '  Dim mTimeStamp As String
      '  Dim mColor As Color
      '  Dim mSqlText(1) As String
      '  Dim mUpdate As String

      '  If mInDate <> mDate.Date Or mInTime = "" Or mInBranchCode <> pBranchCode Then ' เข้า เพิ่ม record ใหม่ กรณียังไม่ได้เข้า หรือเข้าแล้วแต่เป็นวันที่อื่น หรือเข้าแล้วแต่คนละสาขา
      '    mSqlText(0) = "INSERT INTO ETimeStamp (emplCode, branchCode, dateStamp, inTime, outTime) VALUES ('" & mEmplCode & "', '" & pBranchCode & "', '" & MDYStr(mDate) & "', '" & mTime & "', '')"
      '    mSqlText(1) = "UPDATE EmplInfo SET dateStamp = '" & MDYStr(mDate) & "', inTime = '" & mTime & "', inBranchCode = '" & pBranchCode & "' WHERE emplCode = '" & mEmplCode & "'"

      '    mTimeStamp = "เข้า " & mTime & " น."
      '    mColor = Color.DarkBlue
      '  Else ' ออก
      '    mSqlText(0) = "UPDATE ETimeStamp SET outTime = '" & mTime & "' WHERE emplCode = '" & mEmplCode & "' AND dateStamp = '" & MDYStr(mInDate) & "' AND inTime = '" & mInTime & "'"
      '    mSqlText(1) = "UPDATE EmplInfo SET dateStamp = '" & MDYStr(mDate) & "', inTime = '', inBranchCode = '' WHERE emplCode = '" & mEmplCode & "'"

      '    mTimeStamp = "ออก " & mTime & " น."
      '    mColor = Color.DarkRed
      '  End If

      '  mUpdate = pService.UpdateData("Drug", mSqlText)
      '  If mUpdate = "1" Then
      '    lblEmplName.Text = mEmplName
      '    lblPosition.Text = mEmplPosition
      '    lblTimeStamp.ForeColor = mColor
      '    lblTimeStamp.Text = mTimeStamp
      '    ' แสดงรูปถ่าย
      '    Try
      '      Dim mEmplImageURL As String
      '      mEmplImageURL = pEmplImageFolder & "/" & txtEmplID.Text & ".png"
      '      Dim mImage As New DownLoadImage(mEmplImageURL)
      '      Dim mMemStream As IO.MemoryStream = mImage.BeginDownLoad
      '      picEmpl.Image = Image.FromStream(mMemStream)
      '    Catch ex As Exception
      '      If Not (picEmpl.Image Is Nothing) Then
      '        picEmpl.Image.Dispose()
      '        picEmpl.Image = Nothing
      '      End If
      '    End Try
      '    Timer1.Enabled = True
      '  Else
      '    MessageBox.Show("ไม่สามารถบันทึกเวลาเข้า-ออกได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
      '    ClearField()
      '    txtEmplID.Focus()
      '  End If
      'Else
      '  MessageBox.Show("ไม่มีข้อมูลพนักงาน", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      '  ClearField()
      '  txtEmplID.Focus()
      'End If
    End If
  End Sub

  'Private Sub ShowData()
  '  If txtEmplID.Text.Length > 0 Then
  '    Dim dsEmplInfo As New DataSet
  '    'dsEmplInfo = pService.SelectData("Drug", "SELECT * FROM EmplInfo WHERE emplID = '" & txtEmplID.Text & "' AND branchCode = '" & pBranchCode & "' AND emplStat = '1'")
  '    dsEmplInfo = pService.SelectData("Drug", "SELECT * FROM EmplInfo WHERE emplID = '" & txtEmplID.Text & "' AND emplStat = '1'")
  '    If dsEmplInfo IsNot Nothing Then
  '      Dim dvEmplInfo As New DataView(dsEmplInfo.Tables(0))
  '      If dvEmplInfo.Count > 0 Then
  '        With dvEmplInfo.Item(0)
  '          'If .Item("branchCode").ToString <> pBranchCode AndAlso InStr(.Item("emplPriv").ToString, "SPVS") = 0 Then
  '          '  MessageBox.Show("ไม่ใช่พนักงานสาขา", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
  '          '  txtEmplID.Text = ""
  '          '  txtEmplID.Focus()
  '          '  Exit Sub
  '          'End If

  '          lblEmplName.Text = .Item("emplName").ToString
  '          lblPosition.Text = .Item("emplPosition").ToString
  '          Try
  '            'Dim mFileLocation As String = .Item("imageFileFolder").ToString
  '            'Dim mIndex As Integer = mFileLocation.LastIndexOf("\")
  '            'Dim mFile As String = mFileLocation.Substring(mIndex + 1)
  '            Dim mEmplImageURL As String
  '            mEmplImageURL = pEmplImageFolder & "/" & txtEmplID.Text & ".png"
  '            Dim mImage As New DownLoadImage(mEmplImageURL)
  '            Dim mMemStream As IO.MemoryStream = mImage.BeginDownLoad
  '            picEmpl.Image = Image.FromStream(mMemStream)
  '            'picEmpl.ImageLocation = pEmplImageFolder & "/" & txtEmplID.Text & ".png"
  '            'picEmpl.Load()
  '          Catch ex As Exception
  '            If Not (picEmpl.Image Is Nothing) Then
  '              picEmpl.Image.Dispose()
  '              picEmpl.Image = Nothing
  '            End If
  '          End Try

  '          ' ตรวจว่าลงเวลาเข้าแล้วหรือยัง (ยังไม่ได้ลงเวลาออก)
  '          Dim dsTimeStamp As New DataSet
  '          'dsTimeStamp = pService.SelectData("Drug", "SELECT * FROM TimeStamp WHERE emplCode = '" & .Item("emplCode").ToString & "' AND outTime = ''")
  '          dsTimeStamp = pService.SelectData("Drug", "SELECT * FROM TimeStamp WHERE emplCode = '" & .Item("emplCode").ToString & "' AND dateStamp = '" & MDYStr(Date.Today) & "' AND outTime = '' AND branchCode = '" & pBranchCode & "'")
  '          If dsTimeStamp IsNot Nothing Then
  '            Dim dvTimeStamp As New DataView(dsTimeStamp.Tables(0))
  '            Dim mServerDate As Date
  '            Dim sqlText(0) As String
  '            Dim retValue As String

  '            mServerDate = pService.ServerDateTime
  '            If dvTimeStamp.Count = 0 Then
  '              lblTimeStamp.ForeColor = Color.DarkBlue
  '              lblTimeStamp.Text = "เข้า  " & mServerDate.ToShortTimeString & " น."
  '              ' save การลงเวลา เข้า
  '              sqlText(0) = "INSERT INTO TimeStamp (emplCode, dateStamp, inTime, outTime, branchCode) VALUES ('" & .Item("emplcode").ToString & "', '" & MDYStr(mServerDate) & "', '" & Format(mServerDate, "HH:mm") & "', '', '" & pBranchCode & "')"
  '              retValue = pService.UpdateData("Drug", sqlText)
  '              If retValue <> "1" Then
  '                MessageBox.Show("ไม่สามารถบันทึกการลงเวลา 'เข้า' ได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
  '                Call ClearField()
  '                Exit Sub
  '              End If
  '            Else
  '              'If dvTimeStamp.Item(0).Item("outTime").ToString = "" Then
  '              lblTimeStamp.ForeColor = Color.DarkRed
  '              lblTimeStamp.Text = "ออก  " & mServerDate.ToShortTimeString & " น."
  '              ' save การลงเวลา ออก
  '              sqlText(0) = "UPDATE TimeStamp SET outTime = '" & Format(mServerDate, "HH:mm") & "' WHERE emplCode = '" & .Item("emplCode").ToString & "' AND dateStamp = '" & MDYStr(mServerDate) & "'"
  '              retValue = pService.UpdateData("Drug", sqlText)
  '              If retValue <> "1" Then
  '                MessageBox.Show("ไม่สามารถบันทึกการลงเวลา 'ออก' ได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
  '                Call ClearField()
  '                txtEmplID.Focus()
  '                Exit Sub
  '              End If
  '              'Else
  '              '  MessageBox.Show("ลงเวลาซ้ำ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
  '              '  Call ClearField()
  '              '  Exit Sub
  '              'End If
  '            End If
  '            dvTimeStamp = Nothing
  '          Else
  '            MessageBox.Show("ไม่สามารถติดต่อกับฐานข้อมูลได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
  '          End If
  '          dsTimeStamp = Nothing
  '        End With
  '        txtEmplID.Text = ""
  '        txtEmplID.ReadOnly = True
  '        Timer1.Enabled = True
  '      Else
  '        MessageBox.Show("ไม่มีข้อมูลพนักงาน", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
  '        Call ClearField()
  '        txtEmplID.Focus()
  '      End If
  '    Else
  '      MessageBox.Show("ไม่สามารถติดต่อกับฐานข้อมูลได้", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
  '    End If
  '  End If
  'End Sub

  Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    Timer1.Enabled = False
    ClearField()
    txtEmplID.Focus()
  End Sub

  Private Sub ClearField()
    txtEmplID.Text = ""
    lblEmplName.Text = ""
    lblTimeStamp.Text = ""
    lblPosition.Text = ""
    If picEmpl.Image IsNot Nothing Then
      picEmpl.Image.Dispose()
      picEmpl.Image = Nothing
    End If
    txtEmplID.Enabled = True
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
End Class