Imports System.Data.SqlClient
Imports System.Net
Imports System.Text.RegularExpressions

Module DrugMod
  Public Const pProgCode As String = "PHFR"
  Public Const pAppName As String = "DrugFront"
  Public pCurrentVersion As String

  Public pBreakNumb As Integer
  Public pRegisterNumber As String
  Public pService As New MyService.Service
  Public pService2 As New MyService2.Service
  Public pService3 As New MyService3.Service
  Public pServiceAddr As String
  Public pServerAddr As String
  Public pNewServerAddr As String
  Public pGoodImageFolder As String
  Public pEmplImageFolder As String
  Public pPrinterPort As String

  Public pCompName As String
  Public pCompName1 As String
  Public pCompAddress As String
  Public pCompAddr1 As String
  Public pCompAddr2 As String
  Public pCompFullName As String
  Public pCompTaxNumber As String
  Public pVat As Single

  Public pHugName As String
  Public pHugAddress As String
  Public pHugTaxNumber As String

  Public pBranchCode As String
  Public pBranchIndex As Integer
  Public pBranchName As String
  Public pBranchAddress As String
  Public pBranchPhone As String
  Public pBranchPrice As String
  Public pTaxBranchNo As String
  Public pBranchTypeCode As String
  'Public pTaxBranchPOS As String
  Public pPOSNo As String ' เครื่องบันทึกเงินสดลำดับที่
  Public pPOSNumber As String ' เลขเครื่องบันทึกเงินสด
  Public pIsFranchise As String ' เป็นสาขาแฟรนไชส์หรือไม่

  Public pWholePriceLevel As String
  Public pOnlinePriceLevel As String
  Public pAllowWholePrice As String
  Public pAllowOnlinePrice As String
  Public pAllowO2OSale As String
  Public pAllowTaxInvoice As String

  Public pPreSaleNumb As String
  Public pPreReturnNumb As String
  Public pPreTaxInvoiceNumb As String

  Public pLogSession As String
  Public pAllowDisc As String
  Public pAllowDiscEnter As String
  Public pAllowFingerScan As String
  Public pAllowCheckCostAndPrice As String
  Public pAllowBuyExchange As String ' สิทธิ์แลกซื้อ
  Public pAllowEmplPro As String ' พนักงานใช้โปรโมชั่นได้
  Public pAllowOnlyMembPrice As String ' ราคาเฉพาะสมาชิก นอกนั้นปรับขึ้นเป็นสเต็ป
  Public pMembPrice As Double ' ค่าสมัครสมาชิก
  Public pMembExtraPoint As Integer ' แต้มพิเศษเมื่อสมัครสมาชิก
  Public pBillPrint As String
  Public pBranchGroupCode As String

  Public pUserCode As String
  Public pUserName As String
  Public pUserPosition As String
  Public pUserID As String
  Public pUserPriv As String
  Public pUserImage As PictureBox

  Public pOffLineFolder As String
  Public pOfflineUpdate As Boolean
  Public pOfflineDate As Date
  Public pRegistry As String

  Public pBirthPointPlus As Integer
  Public pBahtPerPoint As Integer
  Public pWholeBahtPerPoint As Integer
  Public pEmplBuyLimit As Double
  Public pPerPrice1ToPrice0 As Integer

  Public pServerDateTime As Date
  Public pStartDateLimit As Date
  Public pEndDateLimit As Date
  Public pIsBranchShipTo As Boolean
  Public pAutoUploadSale As Boolean
  Public pPricePerOneBuyExchange As Integer ' ยอดซื้อต่อหนึ่งสิทธิ์แลกซื้อ
  Public pDayUseBuyExchange As Integer ' อายุสิทธิ์แลกซื้อ (วัน)
  Public pShiptoPOLifespan As Integer ' อายุใบ PO

  Public pDefaultReportPrinterName As String

  Public pScreenRatio As String
  Public pMessageBox As MyMessageBox


  Structure GoodType
    Dim Description As String
    Dim Code As String
  End Structure

  Public pGoodType() As GoodType

  Structure GoodShelf
    Dim ShelfNo As String
  End Structure

  Public pGoodShelf() As GoodShelf

  ' class for download image file from internet
  Public Class DownLoadImage
    Dim mURL As String

    Public Sub New(ByVal URL As String)
      Me.mURL = URL
    End Sub

    Public Function BeginDownLoad() As IO.MemoryStream
      Dim mImage As IO.MemoryStream
      Dim mWebClient As New WebClient
      mImage = New IO.MemoryStream(mWebClient.DownloadData(mURL))
      Return mImage
    End Function
  End Class

  ' Good Class
  Class GoodStock
    Public stockOnhand As Integer
    Public miniStock As Integer
    Public stockCount As Integer
    Public lastSale As Date
    Public unitCost As Double
    Public shelfNo As String
  End Class

  Public Function MDYStr(ByVal mDate As Date) As String
    Return mDate.Month & "/" & mDate.Day & "/" & mDate.Year
  End Function

  Public Function YMDStr(ByVal mDate As Date) As String
    Return mDate.Year & "/" & mDate.Month & "/" & mDate.Day
  End Function

  Public Function DMYStr(ByVal mDate As Date) As String
    Return mDate.Day & "/" & mDate.Month & "/" & mDate.Year
  End Function

  Public Function MyVal(ByVal mText As String) As Double
    ' ใช้ลบเครื่องหมาย comma ในช่องที่เป็นตัวเลข เพื่อนำไปแปลงค่าเป็นตัวเลขด้วย val() ได้
    If mText = "" Then
      Return 0
    Else
      Return Val(Replace(mText, ",", ""))
    End If
  End Function

  Public Function ThaiDate(ByVal mDate As Date) As String
    Dim retString As String
    Dim ThaiMonth As String = "???"

    Select Case Month(mDate)
      Case 1
        ThaiMonth = "มกราคม"
      Case 2
        ThaiMonth = "กุมภาพันธ์"
      Case 3
        ThaiMonth = "มีนาคม"
      Case 4
        ThaiMonth = "เมษายน"
      Case 5
        ThaiMonth = "พฤษภาคม"
      Case 6
        ThaiMonth = "มิถุนายน"
      Case 7
        ThaiMonth = "กรกฎาคม"
      Case 8
        ThaiMonth = "สิงหาคม"
      Case 9
        ThaiMonth = "กันยายน"
      Case 10
        ThaiMonth = "ตุลาคม"
      Case 11
        ThaiMonth = "พฤศจิกายน"
      Case 12
        ThaiMonth = "ธันวาคม"
    End Select
    retString = mDate.Day.ToString & "  " & ThaiMonth & "  " & (mDate.Year + 543).ToString
    ThaiDate = retString
  End Function

  Public Function ThaiShortDate(ByVal mDate As Date) As String
    Dim retString As String
    Dim ThaiMonth As String = "???"

    Select Case Month(mDate)
      Case 1
        ThaiMonth = "มค."
      Case 2
        ThaiMonth = "กพ."
      Case 3
        ThaiMonth = "มีค."
      Case 4
        ThaiMonth = "เมย."
      Case 5
        ThaiMonth = "พค."
      Case 6
        ThaiMonth = "มิย."
      Case 7
        ThaiMonth = "กค."
      Case 8
        ThaiMonth = "สค."
      Case 9
        ThaiMonth = "กย."
      Case 10
        ThaiMonth = "ตค."
      Case 11
        ThaiMonth = "พย."
      Case 12
        ThaiMonth = "ธค."
    End Select
    retString = mDate.Day.ToString & "  " & ThaiMonth & "  " & (mDate.Year + 543).ToString
    ThaiShortDate = retString
  End Function

  Public Function ThaiNumbDate(ByVal mDate As Date) As String
    Return mDate.Day.ToString("0#") & "/" & mDate.Month.ToString("0#") & "/" & (mDate.Year + 543).ToString
  End Function

  Public Function SayNumb(ByVal mNumber As Long) As String
    Dim mLen As Integer
    Dim mNumb As String = CStr(mNumber)
    Dim mSayNumb As String = ""
    mLen = Len(CStr(mNumb))

    Dim mChar() As String ' แทนตัวเลขที่จะดึงมาพิจารณา
    ReDim mChar(mLen)

    Dim x As Integer
    ' เติมค่าตามหลักต่างใน array mchar
    For x = 0 To mLen - 1
      mChar(x + 1) = Mid(mNumb, mLen - x, 1)
    Next x

    For x = 1 To mLen
      If mChar(x) <> "0" Or x = 7 Then ' ถ้าไม่ใช่เลขศูนย ์หรือเป็นศูนย์แต่หลักที่ 7 (ล้าน)
        ' เพิ่มคำประจำหลักต่าง ๆ
        Select Case x
          Case 2, 8
            mSayNumb = "สิบ" & mSayNumb
          Case 3, 9
            mSayNumb = "ร้อย" & mSayNumb
          Case 4, 10
            mSayNumb = "พัน" & mSayNumb
          Case 5, 11
            mSayNumb = "หมื่น" & mSayNumb
          Case 6, 12
            mSayNumb = "แสน" & mSayNumb
          Case 7, 13
            mSayNumb = "ล้าน" & mSayNumb
        End Select

        ' ใส่คำแทนตัวเลขตามหลัก
        Select Case mChar(x)
          Case "1"
            If (mLen > 1 And x = 1) Or (mLen > 7 And x = 7) Then  ' ถ้าตัวเลขนั้นมีหลักมากกว่าหนึ่งและตอนนี้กำลังพิจารณาหลักสุดท้าย หรือหลักมากกว่าล้านและเป็นหลักที่ 7 (ล้าน)
              mSayNumb = "เอ็ด" & mSayNumb
            Else
              If (x <> 2) And (x <> 8) Then ' หลักท 2 และหลักที่ 8 หลักสิบไม่ต้องใส่คำว่า หนึ่งอีก
                mSayNumb = "หนึ่ง" & mSayNumb
              End If
            End If
          Case "2"
            If x = 2 Or x = 8 Then ' ถ้าเป็นหลักที่ 2 หรือหลักที่ 8 ให้ใช้คำว่ายี่
              mSayNumb = "ยี่" & mSayNumb
            Else
              mSayNumb = "สอง" & mSayNumb
            End If
          Case "3"
            mSayNumb = "สาม" & mSayNumb
          Case "4"
            mSayNumb = "สี่" & mSayNumb
          Case "5"
            mSayNumb = "ห้า" & mSayNumb
          Case "6"
            mSayNumb = "หก" & mSayNumb
          Case "7"
            mSayNumb = "เจ็ด" & mSayNumb
          Case "8"
            mSayNumb = "แปด" & mSayNumb
          Case "9"
            mSayNumb = "เก้า" & mSayNumb
        End Select
      End If
    Next x
    Return mSayNumb
  End Function

  Public Function MoneyToWord(ByVal mNumber As Double) As String
    Dim mBaht As String
    Dim mStang As String
    Dim mReturn As String

    Dim mNumb() As String
    mNumb = Split(mNumber.ToString("#.00"), ".")

    mBaht = SayNumb(CInt(mNumb(0)))
    mStang = SayNumb(CInt(mNumb(1)))

    mReturn = ""
    If mBaht <> "" Then
      mReturn = mBaht & "บาท"
    End If

    If mStang <> "" Then
      mReturn = mReturn & mStang & "สตางค์"
    Else ' ไม่มีเศษสตางค์ ให้เติมคำว่า ถ้วน ต่อท้าย
      mReturn = mReturn & "ถ้วน"
    End If

    Return mReturn
  End Function

  Public Function RoundMoney(ByVal mNumber As Double, ByVal mUp As Boolean) As Double
    ' ปัดเศษเงิน
    Dim mNumb As String
    mNumb = mNumber.ToString("###00.00")
    Dim mNumbText() As String
    mNumbText = Split(mNumb, ".")
    ' ปัดขึ้น
    If mUp = True Then
      If mNumbText(1) <> "00" Then
        If CInt(mNumbText(1)) <= 25 Then
          mNumbText(1) = "25"
        Else
          If CInt(mNumbText(1)) <= 50 Then
            mNumbText(1) = "50"
          Else
            If CInt(mNumbText(1)) <= 75 Then
              mNumbText(1) = "75"
            Else
              If CInt(mNumbText(1)) < 100 Then
                mNumbText(1) = "00"
                mNumbText(0) = (CInt(mNumbText(0)) + 1).ToString
              End If
            End If
          End If
        End If
      End If
    Else ' ปัดลง
      If mNumbText(1) <> "00" Then
        If CInt(mNumbText(1)) <= 25 Then
          mNumbText(1) = "00"
        Else
          If CInt(mNumbText(1)) <= 50 Then
            mNumbText(1) = "25"
          Else
            If CInt(mNumbText(1)) <= 75 Then
              mNumbText(1) = "50"
            Else
              If CInt(mNumbText(1)) < 100 Then
                mNumbText(1) = "75"
              End If
            End If
          End If
        End If
      End If
    End If
    Return CSng(mNumbText(0) & "." & mNumbText(1))
  End Function

  Public Function AdjustMoney(ByVal mNumber As Double) As Double
    ' ปัดเศษเงิน ต่ำกว่า .5 ปัดลง มากกว่า .5 ปัดขึ้น
    Dim mNumb As String
    mNumb = mNumber.ToString("###00.00")
    Dim mNumbText() As String
    mNumbText = Split(mNumb, ".")

    If CInt(mNumbText(1)) >= 50 Then
      mNumbText(0) = (CInt(mNumbText(0)) + 1).ToString
    End If
    mNumbText(1) = "00"

    Return CSng(mNumbText(0) & "." & mNumbText(1))
  End Function

  ' Function for access Microsoft Access DataBase
  Public Function SelectData(ByVal sqlText As String) As DataSet
    Dim objDataSet As New DataSet
    Try
      Dim objConnect As New OleDb.OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=" & pOffLineFolder & "data.mdb;Persist Security Info=False")
      objConnect.Open()

      Dim objDataAdapter As New OleDb.OleDbDataAdapter
      objDataAdapter.SelectCommand = New OleDb.OleDbCommand
      objDataAdapter.SelectCommand.Connection = objConnect
      objDataAdapter.SelectCommand.CommandText = sqlText
      objDataAdapter.SelectCommand.CommandType = CommandType.Text
      objDataAdapter.Fill(objDataSet, "MyTable")
    Catch ex As Exception
      objDataSet = Nothing
    End Try

    Return objDataSet
  End Function

  Public Function GetData(ByVal sqlText As String) As String()
    Dim objDataSet As New DataSet
    Dim objDataView As DataView
    Dim objDataAdapter As New OleDb.OleDbDataAdapter
    Dim objConnect As New OleDb.OleDbConnection
    Dim retString() As String
    Try
      objConnect = New OleDb.OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=" & pOffLineFolder & "data.mdb;Persist Security Info=False")
      objConnect.Open()

      objDataAdapter = New OleDb.OleDbDataAdapter
      objDataAdapter.SelectCommand = New OleDb.OleDbCommand
      objDataAdapter.SelectCommand.Connection = objConnect
      objDataAdapter.SelectCommand.CommandText = sqlText
      objDataAdapter.SelectCommand.CommandType = CommandType.Text
      objDataAdapter.Fill(objDataSet, "MyTable")

      objDataView = New DataView(objDataSet.Tables("MyTable"))
      If objDataView.Count > 0 Then
        Dim intCols As Integer
        intCols = objDataView.Table.Columns.Count
        Dim retValue(intCols) As String
        Dim x As Integer
        retValue(0) = "1"
        For x = 1 To intCols
          retValue(x) = CStr(objDataView.Item(0).Item(x - 1))
        Next
        retString = retValue
      Else
        Dim retNoRecord(2) As String
        retNoRecord(0) = "0"
        retNoRecord(1) = "No record in command '" & sqlText & "'"
        retString = retNoRecord
      End If
    Catch ex As Exception
      Dim retException(2) As String
      retException(0) = "-1"
      retException(1) = ex.Message
      retString = retException
    Finally
      objDataView = Nothing
      objDataSet = Nothing
      objDataAdapter = Nothing
      objConnect.Close()
      objConnect = Nothing
    End Try

    Return retString
  End Function

  Public Function UpdateData(ByVal sqlText() As String, ByVal datafile As String) As String
    Dim retValue As String

    Dim objConnect As New OleDb.OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=" & pOffLineFolder & datafile & ";Persist Security Info=False")
    objConnect.Open()

    Dim objCommand As OleDb.OleDbCommand
    Dim trans As OleDb.OleDbTransaction = objConnect.BeginTransaction(IsolationLevel.ReadCommitted)

    Try
      Dim x As Integer
      Dim mRet As Integer
      For x = 0 To sqlText.Length - 1
        If Not sqlText(x) Is Nothing AndAlso sqlText(x) <> "" Then
          objCommand = New OleDb.OleDbCommand(sqlText(x), objConnect, trans)
          mRet = objCommand.ExecuteNonQuery
        End If
      Next

      trans.Commit()
      retValue = "1"
    Catch ex As Exception
      trans.Rollback()
      retValue = ex.Message
    Finally
      objConnect.Close()
      objConnect = Nothing
    End Try

    Return retValue
  End Function

  ' Function for access Microsoft Access DataBase
  Public Function SelectDataOff(ByVal sqlText As String) As DataSet
    Dim objDataSet As New DataSet
    Try
      Dim objConnect As New OleDb.OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=data.mdb;Persist Security Info=False")
      objConnect.Open()

      Dim objDataAdapter As New OleDb.OleDbDataAdapter
      objDataAdapter.SelectCommand = New OleDb.OleDbCommand
      objDataAdapter.SelectCommand.Connection = objConnect
      objDataAdapter.SelectCommand.CommandText = sqlText
      objDataAdapter.SelectCommand.CommandType = CommandType.Text
      objDataAdapter.Fill(objDataSet, "MyTable")
    Catch ex As Exception
      objDataSet = Nothing
    End Try

    Return objDataSet
  End Function

  Public Function GetDataOff(ByVal sqlText As String) As String()
    Dim objDataSet As New DataSet
    Dim objDataView As DataView
    Dim objDataAdapter As New OleDb.OleDbDataAdapter
    Dim objConnect As New OleDb.OleDbConnection
    Dim retString() As String
    Try
      objConnect = New OleDb.OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=data.mdb;Persist Security Info=False")
      objConnect.Open()

      objDataAdapter = New OleDb.OleDbDataAdapter
      objDataAdapter.SelectCommand = New OleDb.OleDbCommand
      objDataAdapter.SelectCommand.Connection = objConnect
      objDataAdapter.SelectCommand.CommandText = sqlText
      objDataAdapter.SelectCommand.CommandType = CommandType.Text
      objDataAdapter.Fill(objDataSet, "MyTable")

      objDataView = New DataView(objDataSet.Tables("MyTable"))
      If objDataView.Count > 0 Then
        Dim intCols As Integer
        intCols = objDataView.Table.Columns.Count
        Dim retValue(intCols) As String
        Dim x As Integer
        retValue(0) = "1"
        For x = 1 To intCols
          retValue(x) = CStr(objDataView.Item(0).Item(x - 1))
        Next
        retString = retValue
      Else
        Dim retNoRecord(2) As String
        retNoRecord(0) = "0"
        retNoRecord(1) = "No record in command '" & sqlText & "'"
        retString = retNoRecord
      End If
    Catch ex As Exception
      Dim retException(2) As String
      retException(0) = "-1"
      retException(1) = ex.Message
      retString = retException
    Finally
      objDataView = Nothing
      objDataSet = Nothing
      objDataAdapter = Nothing
      objConnect.Close()
      objConnect = Nothing
    End Try

    Return retString
  End Function

  Public Function UpdateDataOff(ByVal sqlText() As String) As String
    Dim retValue As String

    Dim objConnect As New OleDb.OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=data.mdb;Persist Security Info=False")
    objConnect.Open()

    Dim objCommand As OleDb.OleDbCommand
    Dim trans As OleDb.OleDbTransaction = objConnect.BeginTransaction(IsolationLevel.ReadCommitted)

    Try
      Dim x As Integer
      Dim mRet As Integer
      For x = 0 To sqlText.Length - 1
        If Not sqlText(x) Is Nothing Then
          objCommand = New OleDb.OleDbCommand(sqlText(x), objConnect, trans)
          mRet = objCommand.ExecuteNonQuery
        End If
      Next

      trans.Commit()
      retValue = "1"
    Catch ex As Exception
      trans.Rollback()
      retValue = ex.Message
    Finally
      objConnect.Close()
      objConnect = Nothing
    End Try

    Return retValue
  End Function

  ' ฟังชั่นแปลงช่วงของวันเดือนปี 2 ค่าให้อยู่ในรูป ปี เดือน วัน
  ' เช่นต้องการทราบว่าอายุสมาชิกตั้งแต่สมัคร จนถึงปัจจุบันมีอายุเท่าไหร่ - 2 ปี 4 เดือน 12 วัน
  Public Function GetAge(ByVal startDate As Date, ByVal endDate As Date) As String
    If endDate < startDate Then
      Return ""
    End If

    Dim mRetVal As String = ""
    Dim mYear As Integer
    Dim mMonth As Integer
    Dim mDay As Integer
    ' ปี
    If endDate.Year > startDate.Year Then
      mYear = endDate.Year - startDate.Year
      ' ถ้าเดือนน้อยกว่า หรือเดือนเท่ากันแต่วันน้อยกว่า ให้ลบปีออก 1 ปี (แสดงว่ายังไม่ครบปี) เช่น 1/8/2010 กับ 19/3/2012
      If endDate.Month < startDate.Month OrElse (endDate.Month = startDate.Month AndAlso endDate.Day < startDate.Day) Then
        mYear = mYear - 1
      End If
    Else
      mYear = 0
    End If
    ' เดือน
    If endDate.Month > startDate.Month Then
      mMonth = endDate.Month - startDate.Month
      ' ถ้าวันน้อยกว่า ให้ลบเดือนออก 1 เดือน (แสดงว่ายังไม่ถึงเดือน) เช่น 20/8/2010 กับ 6/3/2012
      If endDate.Day < startDate.Day Then
        mMonth = mMonth - 1
      End If
    Else
      If endDate.Month < startDate.Month Then
        mMonth = 12 - startDate.Month + endDate.Month
        ' ถ้าวันน้อยกว่า ให้ลบเดือนออก 1 เดือน (แสดงว่ายังไม่ถึงเดือน) เช่น 20/8/2010 กับ 6/3/2012
        If endDate.Day < startDate.Day Then
          mMonth = mMonth - 1
        End If
      Else
        mMonth = 0
      End If
    End If
    ' วัน
    If endDate.Day > startDate.Day Then
      mDay = endDate.Day - startDate.Day
    Else
      If endDate.Day < startDate.Day Then
        ' ใช้จำนวนวันของเดือนซึ่งอาจเป็น 28 29 30 หรือ 31 แล้วแต่เดือน
        mDay = System.DateTime.DaysInMonth(startDate.Year, startDate.Month) - startDate.Day + endDate.Day
      Else
        mDay = 0
      End If
    End If
    ' ถ้าปีหรือเดือนหรือวัน มีค่าน้อยกว่า 0 ไม่ต้องแสดง
    If mYear > 0 Then
      mRetVal = mYear.ToString & " ปี "
    End If
    If mMonth > 0 Then
      mRetVal = mRetVal & mMonth.ToString & " เดือน "
    End If
    If mDay > 0 Then
      mRetVal = mRetVal & mDay.ToString & " วัน"
    End If

    Return mRetVal
  End Function

  Public Function NumbToChar(ByVal Numb As String) As String
    Dim mReturnChar As String = ""
    Dim mNumb(2) As String
    mNumb(0) = Mid(Numb, 1, 2)
    If mNumb(0).Length <> 2 Then mNumb(0) = ""
    mNumb(1) = Mid(Numb, 3, 2)
    If mNumb(1).Length <> 2 Then mNumb(1) = ""
    mNumb(2) = Mid(Numb, 5, 2)
    If mNumb(2).Length <> 2 Then mNumb(2) = ""

    For i As Integer = 0 To 2
      If mNumb(i) <> "" Then
        ' a-z
        If Val(mNumb(i)) >= 1 And Val(mNumb(i)) <= 26 Then
          mReturnChar = mReturnChar & Chr(Val(mNumb(i)) + 96)
        Else
          ' ก-ฮ
          If Val(mNumb(i)) >= 27 And Val(mNumb(i)) <= 72 Then
            mReturnChar = mReturnChar & Chr(Val(mNumb(i)) + 134)
          End If
        End If
      End If
    Next
    Return mReturnChar
  End Function

  Public Function RemoveNickName(ByVal Name As String) As String
    Dim mName As String
    mName = Name
    ' ตัดชื่อเล่นในวงเล็บออก (ถ้ามี)
    If InStr(Name, "(") > 0 Then
      mName = Mid(Name, 1, InStr(Name, "(") - 1) & Mid(Name, InStr(Name, ")") + 1)
    End If
    Return mName
  End Function

  Public Function FirstName(ByVal Name As String) As String
    Dim mName As String
    mName = Name
    ' ตัดชื่อเล่นในวงเล็บออก (ถ้ามี)
    If InStr(Name, "(") > 0 Then
      mName = Mid(Name, 1, InStr(Name, "(") - 1) & Mid(Name, InStr(Name, ")") + 1)
    End If
    Dim mText() As String
    mText = Split(mName, " ")

    Return mText(0)
  End Function

  Public Function GetFirstName(ByVal Name As String) As String
    Dim mName As String
    mName = Name
    ' ตัดชื่อเล่นในวงเล็บออก (ถ้ามี)
    If InStr(Name, "(") > 0 Then
      mName = Mid(Name, 1, InStr(Name, "(") - 1) & Mid(Name, InStr(Name, ")") + 1)
    End If

    Dim mSplitText() As String
    mSplitText = Split(mName, " ")
    Return mSplitText(0)
  End Function

  Public Function SplitSaleNumb(ByVal SaleNumb As String)
    ' เติมช่องว่างระหว่างเลขเพื่อให้ง่ายต่อการดู -> เลขสาขา(4ตำแหน่ง)+P+เลขลำดับเครื่องบันทึกเงินสด+ปี+เดือน+จำนวนนับ(5ตำแหน่ง) เช่น 00001 P1 6601 00001
    ' แยกเฉพาะเลขใบขายที่เป็นเลขกำกับภาษีอย่างย่อ (15 ตำแหน่ง) เท่านั้น เลขใบขายแบบเดิมไม่แยก
    If Len(SaleNumb) < 15 Then
      Return SaleNumb
    Else
      Return Mid(SaleNumb, 1, 4) & " " & Mid(SaleNumb, 5, 2) & " " & Mid(SaleNumb, 7, 4) & " " & Mid(SaleNumb, 11)
    End If
  End Function

  Public Function SplitTaxInvoiceNumber(ByVal TaxInvoiceNumber As String)
    Return Mid(TaxInvoiceNumber, 1, 4) & " " & Mid(TaxInvoiceNumber, 5, 5) & " " & Mid(TaxInvoiceNumber, 10)
  End Function

  Public Function GetStockOnhand(ByVal GoodCode As String, ByVal StockOnhandField As String) As Integer
    Dim mReturn As Integer
    Dim mGet() As String
    mGet = pService.GetData("Drug", "Select " & StockOnhandField & " from GoodInfo where goodCode = '" & GoodCode & "'")
    If mGet(0) = "1" Then
      mReturn = Val(mGet(1))
    Else
      mReturn = 0
    End If
    Return mReturn
  End Function
  ' ฟังชั่นตัดคำ
  Public Function WrapText(ByVal Text As String, ByVal LineLength As Integer) As List(Of String)
    Dim ReturnValue As New List(Of String)
    ' Remove leading and trailing spaces
    Text = Trim(Text)

    Dim Words As String() = Text.Split(" ")

    If Words.Length = 1 And Words(0).Length > LineLength Then
      ' Text is just one big word that is longer than one line
      ' Split it mercilessly
      Dim lines As Integer = (Int(Text.Length / LineLength) + 1)
      Text = Text.PadRight(lines * LineLength)
      For i As Integer = 0 To lines - 1
        Dim SliceStart As Integer = i * LineLength
        ReturnValue.Add(Text.Substring(SliceStart, LineLength))
      Next
    Else
      Dim CurrentLine As New System.Text.StringBuilder
      For Each Word As String In Words
        ' will this word fit on the current line?
        If CurrentLine.Length + Word.Length < LineLength Then
          CurrentLine.Append(Word & " ")
        Else
          ' is the word too long for one line
          If Word.Length > LineLength Then
            ' hack off the first piece, fill out the current line and start a new line
            Dim Slice As String = Word.Substring(0, LineLength - CurrentLine.Length)
            CurrentLine.Append(Slice)
            ReturnValue.Add(CurrentLine.ToString)

            CurrentLine = New System.Text.StringBuilder()

            ' Remove the first slice from the word
            Word = Word.Substring(Slice.Length, Word.Length - Slice.Length)

            ' How many more lines do we need for this word?

            Dim RemainingSlices As Integer = Int(Word.Length / LineLength) + 1
            For LineNumber As Integer = 1 To RemainingSlices
              If LineNumber = RemainingSlices Then
                'this is the last slice
                CurrentLine.Append(Word & " ")
              Else
                ' this is not the last slice
                ' hack off a slice that is one line long, add that slice
                ' to the output as a line and start a new line
                Slice = Word.Substring(0, LineLength)
                CurrentLine.Append(Slice)
                ReturnValue.Add(CurrentLine.ToString)
                CurrentLine = New System.Text.StringBuilder()

                ' Remove the slice from the 
                Word = Word.Substring(Slice.Length, Word.Length - Slice.Length)
              End If
            Next
          Else
            ' finish the current line and start a new one with the wrapped word
            ReturnValue.Add(CurrentLine.ToString)
            CurrentLine = New System.Text.StringBuilder(Word & " ")
          End If
        End If
      Next

      ' Write the last line to the output
      If CurrentLine.Length > 0 Then
        ReturnValue.Add(CurrentLine.ToString)
      End If
    End If
    Return ReturnValue
  End Function

  'Public Function FranchiseCost(ByVal GoodCode As String, ByVal UnitCost As Double) As Double
  '  ' ใช้คำนวณต้นทุนสำหรับสาขาแฟรนไชส์ โดยบวก % เพิ่ม ขึ้นกับ GP(คำนวณเทียบกับราคาขาย 1)
  '  Dim mGP As Double
  '  Dim mUnitPrice1 As Double
  '  Dim mUnitCostFC As Double

  '  ' หาราคา price1
  '  Dim mGet() As String
  '  mGet = pService.GetData("Drug", "Select top 1 GB.price1 from GoodBarcode GB inner join UnitInfo UI on UI.unitCode = GB.unitCode where GB.goodCode = '" & GoodCode & "' and GB.goodAmou = 1 and UI.unitFactor = 1")
  '  If mGet(0) = "1" Then
  '    mUnitPrice1 = mGet(1)
  '  Else
  '    mUnitPrice1 = 0
  '  End If

  '  If mUnitPrice1 > 0 Then
  '    mGP = ((mUnitPrice1 - UnitCost) / mUnitPrice1) * 100
  '  Else
  '    mGP = 0
  '  End If

  '  Select Case mGP
  '    Case Is > 30
  '      mUnitCostFC = UnitCost * 1.06
  '    Case Is > 25
  '      mUnitCostFC = UnitCost * 1.05
  '    Case Is > 20
  '      mUnitCostFC = UnitCost * 1.04
  '    Case Is > 15
  '      mUnitCostFC = UnitCost * 1.03
  '    Case Is > 10
  '      mUnitCostFC = UnitCost * 1.02
  '    Case Else
  '      mUnitCostFC = UnitCost * 1.01
  '  End Select

  '  Return mUnitCostFC
  'End Function

  Public Sub PrintAbbBillVat(ByVal SaleNumb As String, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
    ' พิมพ์ใบกำกับภาษีอย่างย่อ
    Dim prnFontNormal As New Font("CordiaUPC", 12, GraphicsUnit.Point)
    Dim prnFontNormalBold As New Font("CordiaUPC", 12, FontStyle.Bold)
    Dim prnFontSmall As New Font("CordiaUPC", 10, GraphicsUnit.Point)
    Dim prnFontSmallBold As New Font("CordiaUPC", 10, FontStyle.Bold)
    Dim prnFontVerySmall As New Font("CordiaUPC", 8, GraphicsUnit.Point)
    Dim prnFontBigBold As New Font("CordiaUPC", 14, FontStyle.Bold)

    Dim mRowPos As Single
    Dim mLeftMargin As Single = 5.0F
    Dim mCol2Pos As Single = 70.0F
    Dim mCol3Pos As Single = 260.0F

    Dim mLineNo As Integer
    Dim mLineSpace As Integer = 30
    Dim mLineSpace15 As Integer = 15
    Dim mLineSpace10 As Integer = 10
    Dim mRect As RectangleF
    Dim mAlign As New StringFormat()
    Dim mText As String

    ' ชื่อบริษัท
    mLineNo = mLineNo + 1
    mRowPos = mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = pHugName
    e.Graphics.DrawString(mText, prnFontNormalBold, Brushes.Black, mRect, mAlign)
    ' เลขประจำตัวผู้เสียภาษี
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "TAX#" & pHugTaxNumber
    e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
    ' ชื่อสาขา
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "สาขา " & pTaxBranchNo
    e.Graphics.DrawString(mText, prnFontSmallBold, Brushes.Black, mRect, mAlign)
    ' เลข POS
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "POS#" & pPOSNumber
    e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
    ' หัวเอกสาร
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "ใบเสร็จรับเงิน/ใบกำกับภาษีอย่างย่อ(ABB.)"
    e.Graphics.DrawString(mText, prnFontSmallBold, Brushes.Black, mRect, mAlign)

    ' ข้อมูลการขาย
    Dim ds As New DataSet
    Dim dvSale As DataView
    Dim dvPaid As DataView
    Dim mSqlText As String
    ' ข้อมูลขาย
    mSqlText = "Select HS.*, SL.*, CI.custName, GI.goodName, UI.unitDesc, HP.thisPoint, HP.usePoint, HP.remainPoint, EI.emplName, EI2.emplName as cashName from HistSale HS inner join CustInfo CI on CI.custCode = HS.custCode inner join SaleList SL on SL.saleNumb = HS.saleNumb inner join GoodInfo GI on GI.goodCode = SL.goodCode inner join UnitInfo UI on UI.unitCode = SL.unitCode left join EmplInfo EI ON HS.emplCode = EI.emplCode left join EmplInfo EI2 ON HS.cashCode = EI2.emplCode left join HistSalePro HP On HP.saleNumb = HS.saleNumb Where HS.saleNumb = '" & SaleNumb & "'"
    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      dvSale = New DataView(ds.Tables(0))
    Else
      dvSale = Nothing
    End If
    ' ข้อมูลชำระเงิน
    mSqlText = "Select distinct PL.cardCode, CD.cardName, CD.cardColor, PL.payAmou from SalePaidList PL inner join CardInfo CD on CD.cardCode = PL.cardCode left join HistSalePro HP On HP.saleNumb = PL.saleNumb where PL.saleNumb = '" & SaleNumb & "'"
    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      dvPaid = New DataView(ds.Tables(0))
    Else
      dvPaid = Nothing
    End If

    Dim mSaleDate As Date
    With dvSale.Item(0)
      mSaleDate = .Item("saleDate")
    End With

    ' เลขที่ขาย
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "No. " & SplitSaleNumb(SaleNumb)
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' วันที่-เวลา
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = mSaleDate
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' --------
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = StrDup(80, "-")
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

    Dim mGoodAmou As Integer
    Dim mGoodName As String
    Dim mBarcode As String
    Dim mUnitPrice As Double
    Dim mSubDisc As Double
    Dim mSubTotal As Double
    Dim mUnitDesc As String
    Dim mTotalDisc As Double = 0
    Dim mTotalPrice As Double = 0
    Dim mTotalNet As Double
    Dim mPointDisc As Double = 0
    Dim mTotalCashPay As Double = 0
    Dim mTotalCash As Double
    Dim mTotalChange As Double

    Dim mCustCode As String = ""
    Dim mCustName As String = ""
    Dim mCustTypeCode As String = ""

    Dim mThisPoint As Integer = 0
    Dim mUsePoint As Integer = 0
    Dim mRemainPoint As Integer = 0

    Dim mEmplName As String = ""
    Dim mCashName As String = ""

    For i As Integer = 0 To dvSale.Count - 1
      With dvSale.Item(i)
        mGoodName = .Item("goodName")
        mGoodAmou = .Item("goodAmou")
        mBarcode = .Item("barCode")
        mUnitPrice = .Item("unitPrice")
        mSubDisc = .Item("subDisc")
        mUnitDesc = .Item("unitDesc")
        mPointDisc = .Item("pointDisc")
        mTotalCashPay = .Item("totalPay")
        mTotalCash = .Item("totalCash")
        mTotalChange = mTotalCashPay - mTotalCash

        mCustCode = .Item("custCode")
        mCustName = .Item("custName")
        mCustTypeCode = .Item("custType")

        mEmplName = .Item("emplName")
        mCashName = .Item("cashName")

        If IsDBNull(.Item("thisPoint")) = False Then
          mThisPoint = .Item("thisPoint")
          mUsePoint = .Item("usePoint")
          mRemainPoint = .Item("remainPoint")
        End If

        mSubTotal = CLng(mGoodAmou * mUnitPrice)
        mTotalPrice += mSubTotal
        mTotalDisc += mSubDisc
        ' จำนวน
        mLineNo = mLineNo + 1
        mRowPos += mLineSpace15
        mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = mGoodAmou & " " & mUnitDesc
        e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
        ' ชื่อสินค้า
        mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Near
        mText = mGoodName
        e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
        ' ราคาขาย
        mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
        mAlign.Alignment = StringAlignment.Far
        mText = Format(mSubTotal, "#,##0.00")
        e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

        ' แสดงส่วนลดของสินค้าแต่ละตัวที่ได้ลด
        If mSubDisc > 0 Then
          ' จำนวน
          mLineNo = mLineNo + 1
          mRowPos += mLineSpace15
          mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
          mAlign.Alignment = StringAlignment.Near
          mText = "1"
          e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
          ' ชื่อสินค้า
          mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
          mAlign.Alignment = StringAlignment.Near
          mText = "ส่วนลด " & mGoodName
          e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
          ' ส่วนลด
          mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
          mAlign.Alignment = StringAlignment.Far
          mText = Format(-mSubDisc, "#,##0.00")
          e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
        End If
      End With
    Next

    ' ส่วนลดจากแต้ม
    If mPointDisc > 0 Then
      ' จำนวน
      mLineNo = mLineNo + 1
      mRowPos += mLineSpace15
      mRect = New RectangleF(mLeftMargin, mRowPos, 50.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "1"
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
      ' ส่วนลด
      mRect = New RectangleF(55, mRowPos, 150.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "ส่วนลดจากแต้ม"
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
      ' ยอดเงิน
      mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = Format(-mPointDisc, "#,##0.00") '-mPointDisc.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    End If
    ' --------
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = StrDup(80, "-")
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' ยอดสินค้าสุทธิ (หลังหักส่วนลด)
    mTotalNet = mTotalPrice - mTotalDisc - mPointDisc
    ' จำนวนเงินรวมทั้งสิ้น
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "จำนวนเงินรวมทั้งสิ้น"
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

    mRect = New RectangleF(195, mRowPos, 55.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Far
    mText = Format(mTotalNet, "#,##0.00")
    e.Graphics.DrawString(mText, prnFontNormalBold, Brushes.Black, mRect, mAlign)

    ' ประเภทการชำระเงิน
    For i As Integer = 0 To dvPaid.Count - 1
      With dvPaid.Item(i)
        If .Item("cardCode") <> "" And .Item("cardCode") <> "0" Then
          mLineNo = mLineNo + 1
          mRowPos += mLineSpace15
          mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
          mAlign.Alignment = StringAlignment.Near
          mText = "ชำระ " & .Item("cardName")
          e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

          mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
          mAlign.Alignment = StringAlignment.Far
          mText = MyVal(.Item("payAmou")).ToString("#,##0.00")
          e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
        End If
      End With
    Next

    ' ชำระเงินสด
    If mTotalCashPay > 0 Then
      mLineNo = mLineNo + 1
      mRowPos += mLineSpace15
      mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "ชำระ เงินสด"
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotalCashPay.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
      ' เงินทอน
      mLineNo = mLineNo + 1
      mRowPos += mLineSpace15
      mRect = New RectangleF(mLeftMargin, mRowPos, 150, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "เงินทอน"
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)

      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Far
      mText = mTotalChange.ToString("#,##0.00")
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    End If

    ' แสดงแต้ม เฉพาะสมาชิก HUG Club ********
    If mCustTypeCode = "6" Then
      ' --------
      mRowPos += mLineSpace15
      mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = StrDup(80, "-")
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
      ' รหัสสมาชิก
      mRowPos += mLineSpace15
      mRect = New RectangleF(mLeftMargin, mRowPos, 260.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "สมาชิก " & mCustName & " [" & mCustCode & "]"
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
      ' แต้มที่ได้ครั้งนี้
      mRowPos += mLineSpace15
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "HUG Points (ครั้งนี้) " & Format(mThisPoint, "#,##0")
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
      ' แต้มที่ใช้
      mRowPos += mLineSpace15
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "HUG Points (ใช้เป็นส่วนลด) " & Format(mUsePoint, "#,##0")
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
      ' แต้มสะสม
      mRowPos += mLineSpace15
      mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
      mAlign.Alignment = StringAlignment.Near
      mText = "HUG Points (สะสม) " & Format(mRemainPoint + mThisPoint, "#,##0")
      e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    End If
    ' ***************
    ' สิทธิ์แลกซื้อ
    mSqlText = "Select bxAmou, bxCode, expireDate from BuyExchangeInfo where issueSaleNumb = '" & SaleNumb & "'"
    ds = pService.SelectData("Drug", mSqlText)
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        With dv.Item(0)
          mRowPos = mRowPos + 15
          mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
          mAlign.Alignment = StringAlignment.Near
          mText = .Item("bxAmou") & " สิทธิ์แลกซื้อ [" & .Item("bxCode") & "]" & " ใช้ได้ถึง " & .Item("expireDate")
          e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
        End With
      End If
      dv = Nothing
    End If
    ds = Nothing

    'Dim mGet() As String
    'mGet = pService.GetData("Drug", "Select bxAmou, bxCode, expireDate from BuyExchangeInfo where issueSaleNumb = '" & SaleNumb & "'")
    'If mGet(0) = "1" Then
    '  mRowPos = mRowPos + 15
    '  mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    '  mAlign.Alignment = StringAlignment.Near
    '  mText = mGet(1) & " สิทธิ์แลกซื้อ [" & mGet(2) & "]" & " ใช้ได้ถึง " & mGet(3)
    '  e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    'End If

    ' --------
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 252, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = StrDup(80, "-")
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
    ' พนักงาน
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "พนักงานขาย " & RemoveNickName(mEmplName)
    e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
    ' Cashier
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ผู้รับเงิน " & RemoveNickName(mCashName)
    e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)

    ' ท้ายเอกสาร 1
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Near
    mText = "ขอสงวนสิทธิ์ในการรับเปลี่ยน/คืนสินค้า หากไม่มีใบเสร็จรับเงินมาแสดง"
    e.Graphics.DrawString(mText, prnFontVerySmall, Brushes.Black, mRect, mAlign)
    ' VAT INCLUDED
    mLineNo = mLineNo + 1
    mRowPos += mLineSpace15
    mRect = New RectangleF(mLeftMargin, mRowPos, 245.0F, 20.0F)
    mAlign.Alignment = StringAlignment.Center
    mText = "**** VAT INCLUDED ****"
    e.Graphics.DrawString(mText, prnFontSmall, Brushes.Black, mRect, mAlign)
  End Sub

  ' @@@@@@@@@@@@@@@ ระบบสต๊อคแยกตาราง
  Public Function GetGoodBranchInfo(ByVal GoodCode As String, ByVal BranchCode As String) As GoodStock
    Dim mGood As New GoodStock
    Dim ds As New DataSet
    ds = pService.SelectData("Drug", "Select * from GoodBranchInfo where goodCode = '" & GoodCode & "' and branchCode = '" & BranchCode & "'")
    If IsNothing(ds) = False Then
      Dim dv As New DataView(ds.Tables(0))
      If dv.Count > 0 Then
        With dv.Item(0)
          mGood.stockOnhand = .Item("stockOnhand")
          mGood.stockCount = .Item("stockCount")
          mGood.miniStock = .Item("miniStock")
          mGood.shelfNo = .Item("shelfNo")
          mGood.lastSale = .Item("lastSale")
          mGood.unitCost = .Item("unitCost")
        End With
      Else
        mGood.stockOnhand = 0
        mGood.stockCount = 0
        mGood.miniStock = 0
        mGood.shelfNo = ""
        mGood.lastSale = Nothing
        mGood.unitCost = 0
      End If
    End If
    ds = Nothing

    Return mGood
  End Function

  Public Function IsValidEmailFormat(ByVal emailText As String) As Boolean
    Return Regex.IsMatch(emailText, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
  End Function

End Module