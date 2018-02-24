Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing.Printing
Imports DGVPrinterHelper

Public Class Dashbrd

#Region "Member Variables"
    Private _source As BindingSource
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da, da2 As SqlDataAdapter
    Dim ds, ds2 As DataSet
    Dim iRec As Boolean = False
    Dim AccessVerify As New VerifyAccess
#End Region

    Private Sub Me_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.SendWait("{TAB}")
        End If
    End Sub

    Public Sub conn()
        con = New SqlConnection
        Dim abc As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLibrary.dll")
        con.ConnectionString = Replace(abc, "AlHamlan", MainMDI.Label4.Text)
        con.Open()
        cmd = New SqlCommand
        cmd.Connection = con
        cmd.CommandTimeout = 0
    End Sub

    Public Sub LoadToday()
        conn()
        cmd.CommandText = "select '1' As SNO, 'Stock Value' As Title, IsNull(sum(balancevalue),0) as val, 'Select * From View_BalanceStockValuation' As Qry from View_BalanceStockValuation Union SELECT  '2', 'Collection' As Title, IsNull(sum(Amount),0) as val, 'Select RCNo, CUS_CODE, CName, Mode, Amnt From View_CustomerReciepts Where CUS_RECIEPT_DATE >= ''" + dtpFDate.Value.Date.ToString + "'' AND CUS_RECIEPT_DATE <= ''" + dtpToDate.Value.Date.AddDays(1).ToString + "'' and CANCEL is null' from CUSTOMER_RECIEPTS Where CUS_RECIEPT_DATE >= '" + dtpFDate.Value.Date.ToString + "' AND CUS_RECIEPT_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' and CANCEL is null Union SELECT  '3', 'GRN Amnt' As Title, IsNull(sum(Net),0) as val, 'Select GRN_NO, CUST_CODE, CUST_NAME, Net from View_GRN_Main Where GRN_DATE >= ''" + dtpFDate.Value.Date.ToString + "'' AND GRN_DATE <= ''" + dtpToDate.Value.Date.AddDays(1).ToString + "'' And GRN_Cancel = ''F'' AND GRN_Posted = ''T''' from View_GRN_Main Where GRN_DATE >= '" + dtpFDate.Value.Date.ToString + "' AND GRN_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' And GRN_Cancel = 'F' AND GRN_Posted = 'T' union SELECT  '4', 'Payments' As Title, IsNull(sum(Amnt),0) as val, 'Select VOUCHER_NO As VNo, ID As EntryNo, SL_CODE, SL_NAME,NARRATION, Amnt from View_Voucher_Dtls  Where TRAN_TYPE = ''D'' And SL_CODE In (Select Distinct SL_CODE From View_Master_Supplier) And VOUCHER_DATE  >= ''" + dtpFDate.Value.Date.ToString + "'' AND VOUCHER_DATE <= ''" + dtpToDate.Value.Date.AddDays(1).ToString + "'' AND VOU_POSTED = ''T''' from View_Voucher_Dtls Where TRAN_TYPE = 'D' And SL_CODE In (Select Distinct SL_CODE From View_Master_Supplier) And VOUCHER_DATE >= '" + dtpFDate.Value.Date.ToString + "' AND VOUCHER_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' AND VOU_POSTED = 'T' union SELECT  '5', 'Expenses' As Title, IsNull(sum(Amnt),0) as val, 'Select VOUCHER_NO As VNo, ID As EntryNo, SL_CODE, SL_NAME,NARRATION, Amnt from View_Voucher_Dtls  Where TRAN_TYPE = ''D'' And SL_CODE Not In (Select Distinct SL_CODE From View_Master_Supplier) And VOUCHER_DATE >= ''" + dtpFDate.Value.Date.ToString + "'' AND VOUCHER_DATE <= ''" + dtpToDate.Value.Date.AddDays(1).ToString + "'' AND VOU_POSTED = ''T''' from View_Voucher_Dtls Where TRAN_TYPE = 'D' And SL_CODE Not In (Select Distinct SL_CODE From View_Master_Supplier) And VOUCHER_DATE >= '" + dtpFDate.Value.Date.ToString + "' AND VOUCHER_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' AND VOU_POSTED = 'T' Union SELECT '6', 'Profit', IsNull(sum(Profit),0), 'select *, (Select Inv_Date From View_SalesInv_Main Where INV_NO=T.Inv_NO) As InvDate, (Select CUST_NAME From View_SalesInv_Main Where INV_NO=T.Inv_NO) As CName from View_SalesInv_Profit T Where Inv_No In (Select Inv_No From SALES_HEADER Where Inv_Date >= ''" + dtpFDate.Value.Date.ToString + "'' AND Inv_Date <= ''" + dtpToDate.Value.Date.AddDays(1).ToString + "'') Order By INV_NO' From View_SalesInv_Profit Where Inv_No In (Select Inv_No From SALES_HEADER Where Inv_Date>= '" + dtpFDate.Value.Date.ToString + "' AND Inv_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "')  Union SELECT '7', 'Sales', IsNull(sum(Net),0), 'Select INV_NO, CUST_CODE+'+ '''|''' +'+CUST_NAME As Customer, CONVERT(VARCHAR(24), Inv_Date,100) As InvDate, LPO, NET as NetAmnt, isnull((Select Profit From View_SalesInv_Profit Where INV_NO=View_SalesInv_Main.INV_NO),0) As Profit, isnull((Select Collection From View_SalesCollection Where INV_NO=View_SalesInv_Main.INV_NO),0) As Collection, INV_POSTED As Posted, INV_CANCEL as Cancelled, NameMob as Salesmen from View_SalesInv_Main Where Inv_Date >= ''" + dtpFDate.Value.Date.ToString + "'' AND Inv_Date <= ''" + dtpToDate.Value.Date.AddDays(1).ToString + "'' AND INV_POSTED = ''T''  AND INV_CANCEL = ''F'' Order By INV_NO DESC' From dbo.View_SalesInv_Main Where Inv_Date >= '" + dtpFDate.Value.Date.ToString + "' AND Inv_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' AND INV_POSTED = 'T' AND INV_CANCEL = 'F'"
        dr = cmd.ExecuteReader
        While dr.Read()
            For Each Ctrl As Control In FlowLayoutPanel2.Controls
                If Ctrl.Name = "Btn" + CType(dr("SNO"), String) Then
                    Ctrl.Text = CType(dr("Title"), String) + " : " + CType(dr("Val"), String)
                    Ctrl.Tag = CType(dr("Qry"), String)
                    Exit For
                End If
            Next
        End While
        dr.Close()
        con.Close()
    End Sub

    Public Sub LoadUnpostTrans()
        AccessVerify.LoadingFrm(True)
        conn()
        If ComboBox4.SelectedIndex = 0 Then
            'GRN
            cmd.CommandText = "Select GRN_NO as Code, GrnDate As GDate, Cust_Code+'|'+Cust_Name as CName, Net, Initials As SMan from View_GRN_Main where GRN_POSTED ='F' AND GRN_CANCEL = 'F' ORDER BY GRN_NO DESC"
        ElseIf ComboBox4.SelectedIndex = 1 Then
            'IGN
            cmd.CommandText = "Select IGN_NO as Code, IGNDate As IDate, SL_CODE+'|'+SL_NAME as SName, Net, Initials As SMan from View_IGN_Main where REC_POSTED ='F' ORDER BY IGN_NO DESC"
        ElseIf ComboBox4.SelectedIndex = 2 Then
            'JV
            cmd.CommandText = "Select VOUCHER_ID as Code, JVDate As JDate, NOTES, TotalDebit AS DEBIT, TotalCredit AS CREDIT from View_Voucher_Main where VOU_POSTED ='F' ORDER BY VOUCHER_ID DESC"
        ElseIf ComboBox4.SelectedIndex = 3 Then
            'PO
            cmd.CommandText = "Select PUR_ORDER_NO as Code, PODate As PDate, SL_CODE+'|'+SL_NAME as SName, PUR_NET_VALUE AS Net, PUR_REMARKS As Note from View_PO_Main where PUR_POSTED ='F' ORDER BY PUR_ORDER_NO DESC"
        ElseIf ComboBox4.SelectedIndex = 4 Then
            'Proforma
            cmd.CommandText = "Select INV_NO as Code, InvDate As PDate, Cust_Code+'|'+Cust_Name as CName, Net, DELIVERY_NOTE As Note from View_Proforma_Main where INV_POSTED ='F' AND INV_CANCEL = 'F' ORDER BY INV_NO DESC"
        ElseIf ComboBox4.SelectedIndex = 5 Then
            'Salses
            cmd.CommandText = "Select INV_NO as Code, InvDate As IDate, Cust_Code+'|'+Cust_Name as CName, Net, Initials As SMan from View_SalesInv_Main where INV_POSTED ='F' AND INV_CANCEL = 'F' And CUST_CODE In (Select CUST_CODE from CUSTOMER_MASTER Where CUST_ONHOLD = 'F') ORDER BY INV_NO DESC"
        ElseIf ComboBox4.SelectedIndex = 6 Then
            'Exception Customers Salses
            cmd.CommandText = "Select INV_NO as Code, InvDate As IDate, Cust_Code+'|'+Cust_Name as CName, Net, Initials As SMan from View_SalesInv_Main where INV_POSTED ='F' AND INV_CANCEL = 'F' And CUST_CODE In (Select CUST_CODE from CUSTOMER_MASTER Where CUST_ONHOLD = 'T') ORDER BY INV_NO DESC"
        End If
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView2.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridView2.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridView2.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        con.Close()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        AccessVerify.LoadingFrm(True)
        conn()
        Chart1.Titles("Title1").Text = ComboBox1.Text
        If ComboBox1.SelectedIndex = 0 Then
            cmd.CommandText = "Select count(PUR_ORDER_NO) As Cnt, Format(PUR_ORDER_DATE, 'MMM') As Mnth From View_PO_Main Where PUR_ORDER_DATE>=DATEADD(yy, DATEDIFF(yy,0, '" + dtpFDate.Value.Date.ToString + "'), 0) Group By Format(PUR_ORDER_DATE, 'MMM') Order By Month(Max(PUR_ORDER_DATE))"
        ElseIf ComboBox1.SelectedIndex = 1 Then
            cmd.CommandText = "Select count(IGN_NO) As Cnt, Format(REC_DATE, 'MMM') As Mnth From View_IGN_Main Where REC_DATE>=DATEADD(yy, DATEDIFF(yy,0, '" + dtpFDate.Value.Date.ToString + "'), 0) Group By Format(REC_DATE, 'MMM') Order By Month(Max(REC_DATE))"
        ElseIf ComboBox1.SelectedIndex = 2 Then
            cmd.CommandText = "Select count(Inv_No) As Cnt, Format(Inv_date, 'MMM') As Mnth From View_SalesInv_Main Where Inv_date>=DATEADD(yy, DATEDIFF(yy,0, '" + dtpFDate.Value.Date.ToString + "'), 0) Group By Format(Inv_date, 'MMM') Order By Month(Max(Inv_date))"
        ElseIf ComboBox1.SelectedIndex = 3 Then
            cmd.CommandText = "Select count(GRN_NO) As Cnt, Format(GRN_DATE, 'MMM') As Mnth From View_GRN_Main Where GRN_DATE>=DATEADD(yy, DATEDIFF(yy,0, '" + dtpFDate.Value.Date.ToString + "'), 0) Group By Format(GRN_DATE, 'MMM') Order By Month(Max(GRN_DATE))"
        ElseIf ComboBox1.SelectedIndex = 4 Then
            cmd.CommandText = "Select count(VOUCHER_ID) As Cnt, Format(VOUCHER_DATE, 'MMM') As Mnth From View_Voucher_Main Where VOUCHER_DATE>=DATEADD(yy, DATEDIFF(yy,0, '" + dtpFDate.Value.Date.ToString + "'), 0) Group By Format(VOUCHER_DATE, 'MMM') Order By Month(Max(VOUCHER_DATE))"
        ElseIf ComboBox1.SelectedIndex = 5 Then
            cmd.CommandText = "Select count(RCNo) As Cnt, Format(CUS_RECIEPT_DATE, 'MMM') As Mnth From View_CustomerReciepts Where CUS_RECIEPT_DATE>=DATEADD(yy, DATEDIFF(yy,0, '" + dtpFDate.Value.Date.ToString + "'), 0) and CANCEL is null Group By Format(CUS_RECIEPT_DATE, 'MMM') Order By Month(Max(CUS_RECIEPT_DATE))"
        End If

        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds)
        Chart1.DataSource = ds
        Chart1.Series("Series1").XValueMember = "Mnth"
        Chart1.Series("Series1").IsValueShownAsLabel = True
        Chart1.Series("Series1").YValueMembers = "Cnt"
        With Chart1.ChartAreas(0)
            .AxisX.MajorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.NotSet
            .AxisY.MajorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.NotSet
        End With
        Chart1.DataBind()
        con.Close()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        AccessVerify.LoadingFrm(True)
        conn()
        Chart2.Titles("Title1").Text = ComboBox2.Text
        If ComboBox2.SelectedIndex = 0 Then
            cmd.CommandText = "Select sum(Pur_Net_Value) As Cnt, Format(PUR_ORDER_DATE, 'MMM') As Mnth From View_PO_Main Where PUR_POSTED = 'T' AND PUR_ORDER_DATE>=DATEADD(yy, DATEDIFF(yy,0, getdate()), 0) Group By Format(PUR_ORDER_DATE, 'MMM') Order By Month(Max(PUR_ORDER_DATE))"
        ElseIf ComboBox2.SelectedIndex = 1 Then
            cmd.CommandText = "Select Sum(Net) As Cnt, Format(REC_DATE, 'MMM') As Mnth From View_IGN_Main Where REC_POSTED = 'T' And REC_DATE>=DATEADD(yy, DATEDIFF(yy,0, getdate()), 0) Group By Format(REC_DATE, 'MMM') Order By Month(Max(REC_DATE))"
        ElseIf ComboBox2.SelectedIndex = 2 Then
            cmd.CommandText = "Select Sum(Net) As Cnt, Format(Inv_date, 'MMM') As Mnth From View_SalesInv_Main Where INV_POSTED = 'T' AND INV_CANCEL = 'F' AND Inv_date>=DATEADD(yy, DATEDIFF(yy,0, getdate()), 0) Group By Format(Inv_date, 'MMM') Order By Month(Max(Inv_date))"
        ElseIf ComboBox2.SelectedIndex = 3 Then
            cmd.CommandText = "Select Sum(Net) As Cnt, Format(GRN_DATE, 'MMM') As Mnth From View_GRN_Main Where GRN_Cancel = 'F' AND GRN_Posted = 'T' AND GRN_DATE>=DATEADD(yy, DATEDIFF(yy,0, getdate()), 0) Group By Format(GRN_DATE, 'MMM') Order By Month(Max(GRN_DATE))"
        ElseIf ComboBox2.SelectedIndex = 4 Then
            cmd.CommandText = "Select Sum(TotalDebit) As Cnt, Format(VOUCHER_DATE, 'MMM') As Mnth From View_Voucher_Main Where VOU_POSTED = 'T' AND VOUCHER_DATE>=DATEADD(yy, DATEDIFF(yy,0, getdate()), 0) Group By Format(VOUCHER_DATE, 'MMM') Order By Month(Max(VOUCHER_DATE))"
        ElseIf ComboBox2.SelectedIndex = 5 Then
            cmd.CommandText = "Select Sum(TotalCredit) As Cnt, Format(VOUCHER_DATE, 'MMM') As Mnth From View_Voucher_Main Where VOU_POSTED = 'T' AND VOUCHER_DATE>=DATEADD(yy, DATEDIFF(yy,0, getdate()), 0) Group By Format(VOUCHER_DATE, 'MMM') Order By Month(Max(VOUCHER_DATE))"
        ElseIf ComboBox2.SelectedIndex = 6 Then
            cmd.CommandText = "Select Sum(Amnt) As Cnt, Format(CUS_RECIEPT_DATE, 'MMM') As Mnth From View_CustomerReciepts Where CUS_RECIEPT_DATE>=DATEADD(yy, DATEDIFF(yy,0, getdate()), 0) and CANCEL is null Group By Format(CUS_RECIEPT_DATE, 'MMM') Order By Month(Max(CUS_RECIEPT_DATE))"
        ElseIf ComboBox2.SelectedIndex = 7 Then
            cmd.CommandText = "Select Sum(Amnt) As Cnt, Format(VOUCHER_DATE, 'MMM') As Mnth From View_Voucher_Dtls Where TRAN_TYPE = 'D' And SL_CODE In (Select Distinct SL_CODE From View_Master_Supplier) And VOU_POSTED = 'T' AND VOUCHER_DATE>=DATEADD(yy, DATEDIFF(yy,0, getdate()), 0) Group By Format(VOUCHER_DATE, 'MMM') Order By Month(Max(VOUCHER_DATE))"
        ElseIf ComboBox2.SelectedIndex = 8 Then
            cmd.CommandText = "Select Sum(Amnt) As Cnt, Format(VOUCHER_DATE, 'MMM') As Mnth From View_Voucher_Dtls Where TRAN_TYPE = 'D' And SL_CODE Not In (Select Distinct SL_CODE From View_Master_Supplier) And VOU_POSTED = 'T' AND VOUCHER_DATE>=DATEADD(yy, DATEDIFF(yy,0, getdate()), 0) Group By Format(VOUCHER_DATE, 'MMM') Order By Month(Max(VOUCHER_DATE))"
        End If

        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds)
        Chart2.DataSource = ds
        Chart2.Series("Series1").XValueMember = "Mnth"
        Chart2.Series("Series1").IsValueShownAsLabel = True
        Chart2.Series("Series1").YValueMembers = "Cnt"
        With Chart2.ChartAreas(0)
            .AxisX.MajorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.NotSet
            .AxisY.MajorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.NotSet
        End With
        Chart2.Series(0).SmartLabelStyle.Enabled = False
        Chart2.Series(0).LabelAngle = 0
        Chart2.DataBind()
        con.Close()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Btn1_Click(sender As Object, e As EventArgs) Handles Btn1.Click, Btn2.Click, Btn3.Click, Btn4.Click, Btn5.Click, Btn6.Click, Btn7.Click
        AccessVerify.LoadSrchGrid(TryCast(sender, Button).Text, TryCast(sender, Button).Tag, Me.Name, False)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadToday()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AccessVerify.DGVPrinting(ComboBox3.Text, "Critical Listing", False, DataGridView1)
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        AccessVerify.LoadingFrm(True)
        conn()
        If ComboBox3.SelectedIndex = 0 Then
            cmd.CommandText = "Select ITEM_CODE as Code, ITEM_DESC As ItemName, BalancePstd As Qty from View_StockStatusLIVE where BalancePstd < 0"
        ElseIf ComboBox3.SelectedIndex = 1 Then
            cmd.CommandText = "Select Cust_Code As Code, Cust_Name As CustomerName, Pending from View_CustPendingAmnt Union Select '999999', 'Total Pending Amount', Sum(Pending) from View_CustPendingAmnt Order By Pending Desc"
        ElseIf ComboBox3.SelectedIndex = 2 Then
            cmd.CommandText = "Select * from View_Supplier_Pending Union Select '999999', 'Total Pending Amount', Sum(pending) From View_Supplier_Pending"
        End If
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridView1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        con.Close()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AccessVerify.DGVPrinting(ComboBox4.Text, "Unposted Transactions", False, DataGridView2)
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        LoadUnpostTrans()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If MsgBox("Are you sure you want to post all " + ComboBox4.Text + " ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
            AccessVerify.LoadingFrm(True)
            conn()
            If ComboBox4.SelectedIndex = 0 Then
                'GRN
                cmd.CommandText = "Update GRN_HEADER Set GRN_POSTED = 'T' where GRN_POSTED ='F' AND GRN_CANCEL = 'F'"
            ElseIf ComboBox4.SelectedIndex = 1 Then
                'IGN
                cmd.CommandText = "Update IGN_HEADER Set REC_POSTED ='T' where REC_POSTED ='F'"
            ElseIf ComboBox4.SelectedIndex = 2 Then
                'JV
                cmd.CommandText = "Update VOUCHER_HEADER Set VOU_POSTED ='T' where VOU_POSTED ='F'"
            ElseIf ComboBox4.SelectedIndex = 3 Then
                'PO
                cmd.CommandText = "Update PURCHASE_HEADER Set PUR_POSTED ='T' where PUR_POSTED ='F'"
            ElseIf ComboBox4.SelectedIndex = 4 Then
                'Proforma
                cmd.CommandText = "Update PROFORMA_HEADER Set INV_POSTED ='T' where INV_POSTED ='F' AND INV_CANCEL = 'F'"
            ElseIf ComboBox4.SelectedIndex = 5 Then
                'Salses
                Dim da As New SqlDataAdapter
                Dim ds As New DataSet
                cmd.CommandText = "Select * from View_SalesInv_Main where Inv_No In (Select Inv_No from SALES_HEADER Where INV_POSTED ='F' AND INV_CANCEL = 'F' And CUST_CODE In (Select CUST_CODE from CUSTOMER_MASTER Where CUST_ONHOLD = 'F'))"
                da.SelectCommand = cmd
                da.Fill(ds, "View_SalesInv_Main")
                cmd.CommandText = "Select * from View_SalesInv_Dtls where Inv_No In (Select Inv_No from SALES_HEADER Where INV_POSTED ='F' AND INV_CANCEL = 'F' And CUST_CODE In (Select CUST_CODE from CUSTOMER_MASTER Where CUST_ONHOLD = 'F'))"
                da.SelectCommand = cmd
                da.Fill(ds, "View_SalesInv_Dtls")

                Dim cr As New OrgInvoice
                AccessVerify.LoadReports(cr, ds)

                cmd.CommandText = "Update SALES_HEADER Set INV_POSTED ='T', INV_PRINTED = GetDate() where INV_POSTED ='F' AND INV_CANCEL = 'F' And CUST_CODE In (Select CUST_CODE from CUSTOMER_MASTER Where CUST_ONHOLD = 'F')"
            ElseIf ComboBox4.SelectedIndex = 6 Then
                'Exception Customer Salses
                Dim da As New SqlDataAdapter
                Dim ds As New DataSet
                cmd.CommandText = "Select * from View_SalesInv_Main where Inv_No In (Select Inv_No from SALES_HEADER Where INV_POSTED ='F' AND INV_CANCEL = 'F' And CUST_CODE In (Select CUST_CODE from CUSTOMER_MASTER Where CUST_ONHOLD = 'T'))"
                da.SelectCommand = cmd
                da.Fill(ds, "View_SalesInv_Main")
                cmd.CommandText = "Select * from View_SalesInv_Dtls where Inv_No In (Select Inv_No from SALES_HEADER Where INV_POSTED ='F' AND INV_CANCEL = 'F' And CUST_CODE In (Select CUST_CODE from CUSTOMER_MASTER Where CUST_ONHOLD = 'T'))"
                da.SelectCommand = cmd
                da.Fill(ds, "View_SalesInv_Dtls")

                Dim cr As New OrgInvoice
                AccessVerify.LoadReports(cr, ds)

                cmd.CommandText = "Update SALES_HEADER Set INV_POSTED ='T', INV_PRINTED = GetDate() where INV_POSTED ='F' AND INV_CANCEL = 'F' And CUST_CODE In (Select CUST_CODE from CUSTOMER_MASTER Where CUST_ONHOLD = 'T')"
            End If
            cmd.ExecuteNonQuery()
            con.Close()
            LoadUnpostTrans()
            AccessVerify.LoadingFrm(False)
        End If
    End Sub

    Private Sub Btn7_Click(sender As Object, e As EventArgs) Handles Btn8.Click
        'Cash IGN JV
        conn()
        cmd.CommandText = "Declare @VID Int Exec @VID = Sp_CashIGNJV Select @VID as VID"
        dr = cmd.ExecuteReader
        dr.Read()
        If dr("VID") = 0 Then
            MsgBox("There is no pending CashIGN to create Journal Voucher.", MsgBoxStyle.Information, "H.F. General Trading CO.")
        Else
            MsgBox("JV No : " + CType(dr("VID"), String).Trim + " is created.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            Dim FrmSV As New JV
            FrmSV.MdiParent = MainMDI
            FrmSV.Show()
            FrmSV.txtvid.Text = CType(dr("VID"), String).Trim
        End If
        dr.Close()
        con.Close()
    End Sub

    Private Sub Me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        ComboBox4.SelectedIndex = 5
        Dock = DockStyle.Fill
        LoadToday()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub FlowLayoutPanel1_SizeChanged(sender As Object, e As EventArgs) Handles FlowLayoutPanel1.SizeChanged
        Panel4.Width = FlowLayoutPanel1.Width - 10
    End Sub
End Class