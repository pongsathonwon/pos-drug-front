Imports System.IO

Public Class frmRpPushConclude

  Dim mGoodCondition As String
  Dim mBranchCondition As String
  Dim mCompCode As String
  Dim mGoodCode As String
  Dim mCustCode As String
  'Dim mThreadReport As Threading.Thread
  Dim ds As DataSet

  Private Sub frmRpPushConclude_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    Me.WindowState = FormWindowState.Normal
  End Sub

  Private Sub frmRp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Icon = frmMain.Icon

    dtpFrom.Value = Date.Today
    dtpTo.Value = Date.Today
  End Sub

  Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
    If pDefaultReportPrinterName <> "" AndAlso pDefaultReportPrinterName <> "no printer" Then
      ShowReport()
    Else
      pMessageBox = New MyMessageBox("ยังไม่ได้กำหนดเครื่องพิมพ์", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      pMessageBox.ShowDialog()
    End If
  End Sub

  Private Sub ShowReport()
    Me.Cursor = Cursors.WaitCursor

    Dim ds As New DataSet("dsDrug")
    Dim dt As New DataTable("dtPushConclude")
    dt.Columns.Add("goodName", Type.GetType("System.String"))
    dt.Columns.Add("groupName", Type.GetType("System.String"))
    dt.Columns.Add("pushType", Type.GetType("System.String"))
    dt.Columns.Add("pushRange", Type.GetType("System.String"))
    dt.Columns.Add("totalPushAmou", Type.GetType("System.Int32"))
    dt.Columns.Add("targetAmou", Type.GetType("System.Double"))
    dt.Columns.Add("monthTarget", Type.GetType("System.Double"))
    dt.Columns.Add("totalSaleAmou", Type.GetType("System.Int32"))
    dt.Columns.Add("saleFactor", Type.GetType("System.Double"))

    ds.Tables.Add(dt)

    Dim mSqlText, mSqlText1, mSqlText2 As String
    Dim mTable As String
    Dim dsPush As New DataSet

    mSqlText1 = "Select sum(SL.goodAmou) as totalSaleAmou, PS.totalPushAmou, PS.groupName, PS.goodName, PS.pushType, PS.startDate, PS.endDate, PS.saleFactor From ("

    mTable = "Select sum(BP.targetAmou) as totalPushAmou, PP.groupName, PP.goodCode, GI.goodName, PP.pushType, PP.startDate, PP.endDate, PP.saleFactor from ProductPush PP inner join BranchPush BP on BP.pushCode = PP.pushCode inner join BranchInfo BI on BI.branchCode = BP.branchCode inner join GoodInfo GI on GI.goodCode = PP.goodCode Where PP.pushStat <> '0' and BI.branchCode = '" & pBranchCode & "' and ((startDate <= '" & MDYStr(dtpFrom.Value) & "' and endDate between '" & MDYStr(dtpFrom.Value) & "' and '" & MDYStr(dtpTo.Value) & "') or (startDate <= '" & MDYStr(dtpFrom.Value) & "' and endDate >= '" & MDYStr(dtpTo.Value) & "') or ((startDate between '" & MDYStr(dtpFrom.Value) & "' and '" & MDYStr(dtpTo.Value) & "') and (endDate between '" & MDYStr(dtpFrom.Value) & "' and '" & MDYStr(dtpTo.Value) & "')) or ((startDate between '" & MDYStr(dtpFrom.Value) & "' and '" & MDYStr(dtpTo.Value) & "') and endDate >= '" & MDYStr(dtpTo.Value) & "')) group by PP.groupName, PP.goodCode, GI.goodName, PP.pushType, PP.startDate, PP.endDate, PP.saleFactor"

    mSqlText2 = ") PS left join SaleList SL on SL.goodCode = PS.goodCode inner join HistSale HS on HS.saleNumb = SL.saleNumb inner join BranchInfo BI on BI.branchCode = HS.branchCode Where HS.branchCode = '" & pBranchCode & "' and (HS.saleDate between '" & MDYStr(dtpFrom.Value) & "' and '" & MDYStr(dtpTo.Value) & "') and (HS.saleDate between PS.startDate and PS.endDate)"

    mSqlText2 = mSqlText2 & " Group by PS.totalPushAmou, PS.groupName, PS.goodName, PS.pushType, PS.startDate, PS.endDate, PS.saleFactor"

    mSqlText = mSqlText1 & mTable & mSqlText2

    dsPush = pService.SelectData("Drug", mSqlText)

    If IsNothing(dsPush) = False Then
      Dim dvPush As New DataView(dsPush.Tables(0))
      If dvPush.Count > 0 Then
        Dim dr As DataRow
        Dim mGroupName As String
        Dim mPushType As String
        Dim mPushStartDate As Date
        Dim mPushEndDate As Date
        Dim mSaleStartDate As Date
        Dim mSaleEndDate As Date
        Dim mTotalPushAmou As Integer
        Dim mTargetAmou As Double
        Dim mMonthTarget As Double
        Dim mTotalSaleAmou As Integer
        Dim mSaleFactor As Double
        For i As Integer = 0 To dvPush.Count - 1
          With dvPush.Item(i)
            mGroupName = .Item("groupName").ToString
            mPushStartDate = CDate(.Item("startDate"))
            mPushEndDate = CDate(.Item("endDate"))
            mTotalPushAmou = CInt(.Item("totalPushAmou"))

            mSaleStartDate = dtpFrom.Value
            mSaleEndDate = dtpTo.Value
            ' เป้าหมายช่วงคิดช่วงเวลาเฉพาะที่อยู่ในขอบเขตของรายการเท่านั้น
            If mSaleStartDate < mPushStartDate Then
              mSaleStartDate = mPushStartDate
            End If
            If mSaleEndDate > mPushEndDate Then
              mSaleEndDate = mPushEndDate
            End If
            mTargetAmou = CDbl((mTotalPushAmou / (DateDiff(DateInterval.Day, mPushStartDate, mPushEndDate) + 1)) * (DateDiff(DateInterval.Day, mSaleStartDate, mSaleEndDate) + 1))

            ' เป้าหมายต่อเดือน
            mMonthTarget = mTotalPushAmou / ((DateDiff(DateInterval.Day, mPushStartDate, mPushEndDate) + 1) / 30)

            mTotalSaleAmou = CInt(.Item("totalSaleAmou")) ' + mTotalAppendAmou
            If .Item("pushType").ToString = "c" Then
              mPushType = "Campaign"
            Else
              mPushType = "Exclusive"
            End If
            mSaleFactor = CDbl(.Item("saleFactor"))

            dr = ds.Tables(0).NewRow
            dr("groupName") = mGroupName
            dr("goodName") = .Item("goodName")
            dr("pushType") = mPushType
            dr("pushRange") = mPushStartDate.ToString("dd/MM/yy") & " - " & mPushEndDate.ToString("dd/MM/yy")
            dr("totalPushAmou") = mTotalPushAmou
            dr("targetAmou") = mTargetAmou
            dr("monthTarget") = mMonthTarget
            dr("totalSaleAmou") = mTotalSaleAmou
            dr("saleFactor") = mSaleFactor

            ds.Tables(0).Rows.Add(dr)
          End With
        Next
      End If
    End If

    Dim mReport As New rpPushConclude
    mReport.SetDataSource(ds)
    mReport.SetParameterValue("prCompFullName", pCompFullName)
    mReport.SetParameterValue("prBranchName", "สาขา " & pBranchName)
    mReport.SetParameterValue("prBetween", "ตั้งแต่วันที่ " & ThaiDate(dtpFrom.Value) & "  ถึงวันที่ " & ThaiDate(dtpTo.Value))
    mReport.PrintOptions.PrinterName = pDefaultReportPrinterName

    Dim mView As New frmViewReport
    mView.MdiParent = frmMain
    mView.pTitle = Me.Text
    mView.ctrView.ReportSource = mReport
    mView.Show()

    If InStr(pUserPriv, Me.Tag.ToString & "P") > 0 Then
      mView.ctrView.ShowPrintButton = True
    Else
      mView.ctrView.ShowPrintButton = False
    End If
    If InStr(pUserPriv, Me.Tag.ToString & "X") > 0 Then
      mView.ctrView.ShowExportButton = True
    Else
      mView.ctrView.ShowExportButton = False
    End If

    Me.Cursor = Cursors.Default

  End Sub

  'Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
  '  Me.Cursor = Cursors.WaitCursor
  '  pgb1.Visible = False

  '  Dim mSqlText, mSqltext1, mSqlText2, mTable As String

  '  mSqltext1 = "Select sum(SL.goodAmou) as totalSaleAmou, PS.totalPushAmou, PS.groupName, PS.goodName, PS.pushType, PS.startDate, PS.endDate, PS.saleFactor From ("

  '  mTable = "Select sum(BP.targetAmou) as totalPushAmou, PP.groupName, PP.goodCode, GI.goodName, PP.pushType, PP.startDate, PP.endDate, PP.saleFactor from ProductPush PP inner join BranchPush BP on BP.pushCode = PP.pushCode inner join BranchInfo BI on BI.branchCode = BP.branchCode inner join GoodInfo GI on GI.goodCode = PP.goodCode Where BI.branchCode = '" & pBranchCode & "' and ((startDate <= '" & MDYStr(dtpFrom.Value) & "' and endDate between '" & MDYStr(dtpFrom.Value) & "' and '" & MDYStr(dtpTo.Value) & "') or (startDate <= '" & MDYStr(dtpFrom.Value) & "' and endDate >= '" & MDYStr(dtpTo.Value) & "') or ((startDate between '" & MDYStr(dtpFrom.Value) & "' and '" & MDYStr(dtpTo.Value) & "') and (endDate between '" & MDYStr(dtpFrom.Value) & "' and '" & MDYStr(dtpTo.Value) & "')) or ((startDate between '" & MDYStr(dtpFrom.Value) & "' and '" & MDYStr(dtpTo.Value) & "') and endDate >= '" & MDYStr(dtpTo.Value) & "')) group by PP.groupName, PP.goodCode, GI.goodName, PP.pushType, PP.startDate, PP.endDate, PP.saleFactor"

  '  mSqlText2 = ") PS left join SaleList SL on SL.goodCode = PS.goodCode inner join HistSale HS on HS.saleNumb = SL.saleNumb inner join BranchInfo BI on BI.branchCode = HS.branchCode Where HS.branchCode = '" & pBranchCode & "' and (HS.saleDate between '" & MDYStr(dtpFrom.Value) & "' and '" & MDYStr(dtpTo.Value) & "') and (HS.saleDate between PS.startDate and PS.endDate)"

  '  mSqlText2 = mSqlText2 & " Group by PS.totalPushAmou, PS.groupName, PS.goodName, PS.pushType, PS.startDate, PS.endDate, PS.saleFactor"

  '  mSqlText = mSqltext1 & mTable & mSqlText2

  '  pgb1.Visible = True
  '  btnShow.Visible = False
  '  btnCancel.Visible = True

  '  mThreadReport = New Threading.Thread(AddressOf ThreadQuery)
  '  mThreadReport.IsBackground = True
  '  mThreadReport.Start(mSqlText)

  '  Me.Cursor = Cursors.Default
  'End Sub

  'Private Sub ThreadQuery(ByVal SqlText As Object)
  '  Dim mSqlText As String
  '  mSqlText = CStr(SqlText)

  '  ds = New DataSet("dsDrug")

  '  Dim dt As New DataTable("dtPushConclude")
  '  Dim dr As DataRow

  '  dt.Columns.Add("goodName", Type.GetType("System.String"))
  '  dt.Columns.Add("groupName", Type.GetType("System.String"))
  '  dt.Columns.Add("pushType", Type.GetType("System.String"))
  '  dt.Columns.Add("pushRange", Type.GetType("System.String"))
  '  dt.Columns.Add("totalPushAmou", Type.GetType("System.Int32"))
  '  dt.Columns.Add("targetAmou", Type.GetType("System.Double"))
  '  dt.Columns.Add("totalSaleAmou", Type.GetType("System.Int32"))
  '  dt.Columns.Add("saleFactor", Type.GetType("System.Double"))

  '  ds.Tables.Add(dt)

  '  Dim ds2 As New DataSet

  '  Try
  '    'pService.Timeout = 2000000
  '    ds2 = pService.SelectData2("Drug", mSqlText)
  '    'pService.Timeout = 100000
  '  Catch ex As Exception
  '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
  '    Exit Sub
  '  Finally
  '    'pService.Timeout = 100000
  '  End Try

  '  If IsNothing(ds2) = False Then
  '    Dim dvPush As New DataView(ds2.Tables(0))
  '    If dvPush.Count > 0 Then
  '      Dim mGroupName As String
  '      Dim mPushType As String
  '      Dim mPushStartDate As Date
  '      Dim mPushEndDate As Date
  '      Dim mSaleStartDate As Date
  '      Dim mSaleEndDate As Date
  '      Dim mTotalPushAmou As Integer
  '      Dim mTargetAmou As Double
  '      Dim mTotalSaleAmou As Integer
  '      Dim mSaleFactor As Double
  '      For i As Integer = 0 To dvPush.Count - 1
  '        With dvPush.Item(i)
  '          mGroupName = .Item("groupName").ToString
  '          mPushStartDate = CDate(.Item("startDate"))
  '          mPushEndDate = CDate(.Item("endDate"))
  '          mTotalPushAmou = CInt(.Item("totalPushAmou"))
  '          mSaleStartDate = dtpFrom.Value
  '          mSaleEndDate = dtpTo.Value
  '          ' เป้าหมายช่วงคิดช่วงเวลาเฉพาะที่อยู่ในขอบเขตของรายการเท่านั้น
  '          If mSaleStartDate < mPushStartDate Then
  '            mSaleStartDate = mPushStartDate
  '          End If
  '          If mSaleEndDate > mPushEndDate Then
  '            mSaleEndDate = mPushEndDate
  '          End If
  '          mTargetAmou = CDbl((mTotalPushAmou / (DateDiff(DateInterval.Day, mPushStartDate, mPushEndDate) + 1)) * (DateDiff(DateInterval.Day, mSaleStartDate, mSaleEndDate) + 1))

  '          mTotalSaleAmou = CInt(.Item("totalSaleAmou")) ' + mTotalAppendAmou
  '          If .Item("pushType").ToString = "c" Then
  '            mPushType = "Campaign"
  '          Else
  '            mPushType = "Exclusive"
  '          End If
  '          mSaleFactor = CDbl(.Item("saleFactor"))

  '          dr = ds.Tables(0).NewRow
  '          dr("groupName") = mGroupName
  '          dr("goodName") = .Item("goodName")
  '          dr("pushType") = mPushType
  '          dr("pushRange") = mPushStartDate.ToString("dd/MM/yy") & " - " & mPushEndDate.ToString("dd/MM/yy")
  '          dr("totalPushAmou") = mTotalPushAmou
  '          dr("targetAmou") = mTargetAmou
  '          dr("totalSaleAmou") = mTotalSaleAmou
  '          dr("saleFactor") = mSaleFactor

  '          ds.Tables(0).Rows.Add(dr)
  '        End With
  '      Next
  '    End If
  '  End If
  '  ds2 = Nothing

  '  Call ViewReport()
  'End Sub

  'Private Sub ViewReport()
  '  ' เพื่อให้ควบคุม control ต่างๆ ได้
  '  If Me.InvokeRequired Then
  '    Me.Invoke(New MethodInvoker(AddressOf ViewReport))
  '  Else
  '    ' สั่งควบคุม control
  '    btnShow.Visible = True
  '    btnCancel.Visible = False

  '    If IsNothing(ds) = False Then
  '      Dim mReport As New rpPushConclude
  '      mReport.SetDataSource(ds)
  '      mReport.SetParameterValue("prCompFullName", pCompFullName)
  '      mReport.SetParameterValue("prBranchName", "สาขา " & pBranchName)
  '      mReport.SetParameterValue("prBetween", "ตั้งแต่วันที่ " & ThaiDate(dtpFrom.Value) & "  ถึงวันที่ " & ThaiDate(dtpTo.Value))

  '      Dim mView As New frmViewReport
  '      mView.pTitle = Me.Text
  '      mView.ctrView.ReportSource = mReport
  '      mView.ctrView.ShowPrintButton = False
  '      mView.ctrView.ShowExportButton = False
  '      mView.ShowDialog()

  '      If InStr(pUserPriv, Me.Tag.ToString & "P") > 0 Then
  '        mView.ctrView.ShowPrintButton = True
  '      Else
  '        mView.ctrView.ShowPrintButton = False
  '      End If
  '      If InStr(pUserPriv, Me.Tag.ToString & "X") > 0 Then
  '        mView.ctrView.ShowExportButton = True
  '      Else
  '        mView.ctrView.ShowExportButton = False
  '      End If
  '    Else
  '      MessageBox.Show("ไม่สามารถรายงานผลได้")
  '    End If
  '  End If
  'End Sub

  'Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
  '  mThreadReport.Abort()

  '  btnShow.Visible = True
  '  btnCancel.Visible = False
  'End Sub
End Class