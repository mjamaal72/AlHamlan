Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing

Public Class Listings
    Dim AccessVerify As New VerifyAccess
#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
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
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AccessVerify.LoadingFrm(True)
        conn()
        DataGridView1.DataSource = Nothing

        If ComboBox1.Text = "Supplier" Then
            cmd.CommandText = "Select Sl_Code, SL_Name, '('+SL_GL_CODE+') '+GL_DESC As GLDesc from View_Master_Supplier Where SL_ACC_TYPE = 'AP' Order By Sl_Code"
        ElseIf ComboBox1.Text = "GL Types" Then
            cmd.CommandText = "Select * from Master_GLType"
        ElseIf ComboBox1.Text = "Pay Types" Then
            cmd.CommandText = "Select * from MASTER_PAYMENT_TYPES"
        ElseIf ComboBox1.Text = "Shipment Terms" Then
            cmd.CommandText = "Select * from MASTER_SHIPMENT_TERMS"
        ElseIf ComboBox1.Text = "Currency" Then
            cmd.CommandText = "Select * from MASTER_CURRENCY"
        ElseIf ComboBox1.Text = "General Ledger" Then
            cmd.CommandText = "Select GL_TYPENAME, GL_CODE, GL_DESC from View_Master_GenLedger"
        ElseIf ComboBox1.Text = "Sub Ledger" Then
            cmd.CommandText = "Select Sl_Code, SL_Name, '('+SL_GL_CODE+ ' | '+GL_TYPENAME+') '+GL_DESC As GLDesc from View_MASTER_SUBLEDGER Where SL_ACC_TYPE = 'SL' Order By SL_GL_CODE"
        ElseIf ComboBox1.Text = "Letter Of Credit" Then
            cmd.CommandText = "Select LC_No, Convert(varchar, LC_Date, 107) As LCDate, Convert(varchar, LC_EXPIRY_Date, 107) As ExpDate, LC_BANK As Bank, SL_NAME As Beneficiary, LC_AMOUNT As Amnt from View_LetterOfCredit Where LC_Date >= '" + dtpFDate.Value.Date.ToString + "' and LC_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "'  Order By LC_NO"
        ElseIf ComboBox1.Text = "Purchase Order" Then
            cmd.CommandText = "Select PUR_ORDER_No As PONo, SL_CODE+' | '+SL_NAME As Supplier, PODate, PUR_NET_VALUE as NetAmnt, PUR_POSTED As Posted from View_PO_Main Where Pur_Order_Date >= '" + dtpFDate.Value.Date.ToString + "' and Pur_Order_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Order By PUR_ORDER_NO"
        ElseIf ComboBox1.Text = "IGN" Then
            cmd.CommandText = "Select IGN_No, SL_CODE+' | '+SL_NAME As Supplier, IGNDate, Net, Rec_POSTED As Posted from View_IGN_Main Where Rec_Date >= '" + dtpFDate.Value.Date.ToString + "' and Rec_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Order By IGN_No DESC"
        ElseIf ComboBox1.Text = "Journal Vouchers" Then
            cmd.CommandText = "Select VOUCHER_ID, VOUCHER_NO As JVNo, JVDate, VOU_CUR as Crncy, TotalDebit, TotalCredit, Difference, VOU_POSTED As Posted from View_Voucher_Main Where Voucher_Date >= '" + dtpFDate.Value.Date.ToString + "' and Voucher_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Order By VOUCHER_NO DESC"
        ElseIf ComboBox1.Text = "Division" Then
            cmd.CommandText = "Select * from MASTER_DIVISION"
        ElseIf ComboBox1.Text = "Brand" Then
            cmd.CommandText = "Select BRN_CODE, BRN_DESC, SL_CODE+' | '+SL_NAME As Supplier from View_Master_Brand Order By SL_Code"
        ElseIf ComboBox1.Text = "Category" Then
            cmd.CommandText = "Select * from MASTER_CATEGORY"
        ElseIf ComboBox1.Text = "Areas" Then
            cmd.CommandText = "Select * from MASTER_CUSTOMER_AREAS Order By AREA_CODE"
        ElseIf ComboBox1.Text = "Salesman" Then
            cmd.CommandText = "Select SM_CODE, NameMob, FName As Supervisor, SM_SALES_TYPE from View_Master_Salesman Order By SM_Code"
        ElseIf ComboBox1.Text = "Customer Type" Then
            cmd.CommandText = "Select * from MASTER_CUSTOMER_TYPES Order By CUS_TYPE"
        ElseIf ComboBox1.Text = "Customers" Then
            cmd.CommandText = "Select CUST_CODE as Code, CUST_NAME as Name, CUST_TEL as Tel, CUST_ACTIVE As Actv from View_CustomerMaster Order By CUST_CODE"
        ElseIf ComboBox1.Text = "Trade Channel" Then
            cmd.CommandText = "Select * from MASTER_CUSTOMER_CHANNEL_TYPES Order By CHN_CODE"
        ElseIf ComboBox1.Text = "Measuring Units" Then
            cmd.CommandText = "Select * from Master_Measuring_Units"
        ElseIf ComboBox1.Text = "Invoice" Then
            cmd.CommandText = "Select INV_NO, CUST_CODE+' | '+CUST_NAME As Customer, InvDate, NET as NetAmnt, INV_POSTED As Posted, INV_CANCEL as Cancelled, NameMob as Salesmen from View_SalesInv_Main Where INV_DATE >= '" + dtpFDate.Value.Date.ToString + "' and INV_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Order By INV_NO"
        ElseIf ComboBox1.Text = "Invoice Cost, Sales and Profit" Then
            cmd.CommandText = "with CTE (INV_NO, InvDATE, Cname, Cost, Sales, Profit, ProPerc) As (select INV_NO, (Select Convert(varchar,Inv_Date,106) From View_SalesInv_Main Where INV_NO=T.Inv_NO) As InvDate, (Select Cust_Code + ' | ' + CUST_NAME From View_SalesInv_Main Where INV_NO=T.Inv_NO) As CName, Cost, Sales, Profit, Convert(decimal(18,2),Case When Profit=0 or Cost = 0 Then 0 Else Profit*100/Cost End) As ProPerc from View_SalesInv_Profit T Where Inv_No In (Select Inv_No From SALES_HEADER Where INV_DATE >= '" + dtpFDate.Value.Date.ToString + "' and INV_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "')) Select * From CTE Union all Select '','','Sum Total', Sum(Cost), Sum(Sales), Sum(Profit),Convert(decimal(18,2),Case When Sum(Profit)=0 Then 0 Else Sum(Profit)*100/Sum(Cost) End) from CTE  Order By INV_NO Desc"
        ElseIf ComboBox1.Text = "Invoice Net, Collection and Status" Then
            cmd.CommandText = "with CTE (INV, InvDATE, Customer, Net, Clctn, Status) As (select INV_NO As Inv, Convert(varchar,Inv_Date,106) As InvDate, Customer, Net, Collection As Clctn, Status from View_SalesCollection Where INV_DATE >= '" + dtpFDate.Value.Date.ToString + "' and INV_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "') Select * From CTE Union all Select '','','Sum Total', Sum(Net), Sum(Clctn), Case When Sum(Net) = Sum(Clctn) Then 'Equal' Else case When Sum(Net) > Sum(Clctn) Then 'Deficit' else 'Advance' End End from CTE Order By INV Desc"
        ElseIf ComboBox1.Text = "Customer Cost, Sales and Profit" Then
            cmd.CommandText = "with CTE (Cname, Cost, Sales, Profit, ProPerc) As (SELECT View_SalesInv_Main.CUST_CODE+' | '+View_SalesInv_Main.CUST_NAME As CName, SUM(View_SalesInv_Profit.Cost) AS Cost, SUM(View_SalesInv_Profit.Sales) AS Sales, SUM(View_SalesInv_Profit.Profit) AS Profit, Convert(decimal(18,2),Case When SUM(View_SalesInv_Profit.Profit)=0 or SUM(View_SalesInv_Profit.Cost)=0 Then 0 Else SUM(View_SalesInv_Profit.Profit)*100/SUM(View_SalesInv_Profit.Cost) End) As ProPerc FROM View_SalesInv_Profit INNER JOIN View_SalesInv_Main ON View_SalesInv_Profit.INV_NO =  View_SalesInv_Main.INV_NO Where View_SalesInv_Main.INV_DATE >= '" + dtpFDate.Value.Date.ToString + "' and View_SalesInv_Main.INV_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' GROUP BY View_SalesInv_Main.CUST_NAME,View_SalesInv_Main.CUST_CODE) Select * from CTE Union Select 'Sum Total', Sum(Cost), Sum(Sales), Sum(Profit), Convert(decimal(18,2),Case When Sum(Profit)=0 Then 0 Else Sum(Profit)*100/Sum(Cost) End) from CTE"
        ElseIf ComboBox1.Text = "Customer Net, Collection and Status" Then
            cmd.CommandText = "with CTE (Customer, Net, Collection, Status) As (select Customer, Sum(Net) As Net, Sum(Collection) as Collection, Case When Sum(Collection) is null Then 'Pending' Else Case When Sum(Net) = Sum(Collection) Then 'Equal' Else case When Sum(Net) > Sum(Collection) Then 'Deficit' else 'Advance' End End End As Status from View_SalesCollection Where INV_DATE >= '" + dtpFDate.Value.Date.ToString + "' and INV_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Group By Customer) Select * From CTE Union all Select 'Sum Total', Sum(Net), Sum(Collection), Case When Sum(Net) = Sum(Collection) Then 'Equal' Else case When Sum(Net) > Sum(Collection) Then 'Deficit' else 'Advance' End End from CTE"
        ElseIf ComboBox1.Text = "GRN" Then
            cmd.CommandText = "Select GRN_NO, CUST_CODE+' | '+CUST_NAME As Customer, GrnDate, NET as NetAmnt, Grn_POSTED As Posted, Grn_CANCEL as Cancelled, NameMob as Salesmen from View_GRN_Main Where GRN_DATE >= '" + dtpFDate.Value.Date.ToString + "' and GRN_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Order By GRN_NO"
        ElseIf ComboBox1.Text = "Free Goods" Then
            cmd.CommandText = "Select Ent_No, INV_No, ITEMCODE+' | '+ITEM_DESC As ItemName, Qty, ITM_PRICE As CPrice, Gross from View_SalesInv_Dtls Where InvDATE >= '" + dtpFDate.Value.Date.ToString + "' and InvDATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' And ITM_DISC_PER = 100 Order By Ent_No"
            ' ElseIf ComboBox1.Text = "Store Requisition" Then
        ElseIf ComboBox1.Text = "Reciepts" Then
            cmd.CommandText = "Select RCNo, RCDate, Mode, Remarks, Amnt, Cancel, CUS_CODE+' | '+CNAME As Customer, Initials As RecvBy From View_CustomerReciepts Where CUS_RECIEPT_DATE >= '" + dtpFDate.Value.Date.ToString + "' and CUS_RECIEPT_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Order By RCNo"
        ElseIf ComboBox1.Text = "Items Cost N Sales Pricing" Then
            cmd.CommandText = "Select * From View_Item_CP_SP"
        End If

        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables(0)
        con.Close()

        AccessVerify.DGVPrinting(ComboBox1.Text, "Master and Transaction Listing Module", True, DataGridView1)
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Theming_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles rbFMstr.CheckedChanged, rbFTrans.CheckedChanged, rbITrans.CheckedChanged, rbIMstr.CheckedChanged
        ComboBox1.Items.Clear()
        If rbFMstr.Checked = True Then
            ComboBox1.Items.Add("Supplier")
            ComboBox1.Items.Add("GL Types")
            ComboBox1.Items.Add("Pay Types")
            ComboBox1.Items.Add("Shipment Terms")
            ComboBox1.Items.Add("Currency")
            ComboBox1.Items.Add("General Ledger")
            ComboBox1.Items.Add("Sub Ledger")
        ElseIf rbFTrans.Checked = True Then
            ComboBox1.Items.Add("Letter Of Credit")
            ComboBox1.Items.Add("Purchase Order")
            ComboBox1.Items.Add("IGN")
            ComboBox1.Items.Add("Journal Vouchers")
            ComboBox1.Items.Add("Reciepts")
            ComboBox1.Items.Add("Collection")
        ElseIf rbIMstr.Checked = True Then
            ComboBox1.Items.Add("Division")
            ComboBox1.Items.Add("Brand")
            ComboBox1.Items.Add("Category")
            ComboBox1.Items.Add("Areas")
            ComboBox1.Items.Add("Items Cost N Sales Pricing")
            ComboBox1.Items.Add("Salesman")
            ComboBox1.Items.Add("Customer Type")
            ComboBox1.Items.Add("Customers")
            ComboBox1.Items.Add("Trade Channel")
            ComboBox1.Items.Add("Measuring Units")
        ElseIf rbITrans.Checked = True Then
            ComboBox1.Items.Add("Invoice")
            ComboBox1.Items.Add("Invoice Cost, Sales and Profit")
            ComboBox1.Items.Add("Customer Cost, Sales and Profit")
            ComboBox1.Items.Add("Invoice Net, Collection and Status")
            ComboBox1.Items.Add("Customer Net, Collection and Status")
            ComboBox1.Items.Add("GRN")
            ComboBox1.Items.Add("Free Goods")
            'ComboBox1.Items.Add("Store Requisition")
            ComboBox1.Items.Add("Reciepts")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn()

        If ComboBox1.Text = "Supplier" Then
            cmd.CommandText = "Select Sl_Code, SL_Name, '('+SL_GL_CODE+') '+GL_DESC As GLDesc from View_Master_Supplier Where SL_ACC_TYPE = 'AP' Order By Sl_Code"
        ElseIf ComboBox1.Text = "GL Types" Then
            cmd.CommandText = "Select * from Master_GLType"
        ElseIf ComboBox1.Text = "Pay Types" Then
            cmd.CommandText = "Select * from MASTER_PAYMENT_TYPES"
        ElseIf ComboBox1.Text = "Shipment Terms" Then
            cmd.CommandText = "Select * from MASTER_SHIPMENT_TERMS"
        ElseIf ComboBox1.Text = "Currency" Then
            cmd.CommandText = "Select * from MASTER_CURRENCY"
        ElseIf ComboBox1.Text = "General Ledger" Then
            cmd.CommandText = "Select GL_TYPENAME, GL_CODE, GL_DESC from View_Master_GenLedger"
        ElseIf ComboBox1.Text = "Sub Ledger" Then
            cmd.CommandText = "Select Sl_Code, SL_Name, '('+SL_GL_CODE+ ' | '+GL_TYPENAME+') '+GL_DESC As GLDesc from View_MASTER_SUBLEDGER Where SL_ACC_TYPE = 'SL' Order By SL_GL_CODE"
        ElseIf ComboBox1.Text = "Letter Of Credit" Then
            cmd.CommandText = "Select LC_No, Convert(varchar, LC_Date, 107) As LCDate, Convert(varchar, LC_EXPIRY_Date, 107) As ExpDate, LC_BANK As Bank, SL_NAME As Beneficiary, LC_AMOUNT As Amnt from View_LetterOfCredit Where LC_Date >= '" + dtpFDate.Value.Date.ToString + "' and LC_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "'  Order By LC_NO"
        ElseIf ComboBox1.Text = "Purchase Order" Then
            cmd.CommandText = "Select PUR_ORDER_No As PONo, SL_CODE+' | '+SL_NAME As Supplier, PODate, PUR_NET_VALUE as NetAmnt, PUR_POSTED As Posted from View_PO_Main Where Pur_Order_Date >= '" + dtpFDate.Value.Date.ToString + "' and Pur_Order_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Order By PUR_ORDER_NO"
        ElseIf ComboBox1.Text = "IGN" Then
            cmd.CommandText = "Select IGN_No, SL_CODE+' | '+SL_NAME As Supplier, IGNDate, Net, Rec_POSTED As Posted from View_IGN_Main Where Rec_Date >= '" + dtpFDate.Value.Date.ToString + "' and Rec_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Order By IGN_No DESC"
        ElseIf ComboBox1.Text = "Journal Vouchers" Then
            cmd.CommandText = "Select VOUCHER_ID, VOUCHER_NO As JVNo, JVDate, VOU_CUR as Crncy, TotalDebit, TotalCredit, Difference, VOU_POSTED As Posted from View_Voucher_Main Where Voucher_Date >= '" + dtpFDate.Value.Date.ToString + "' and Voucher_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Order By VOUCHER_NO DESC"
        ElseIf ComboBox1.Text = "Division" Then
            cmd.CommandText = "Select * from MASTER_DIVISION"
        ElseIf ComboBox1.Text = "Brand" Then
            cmd.CommandText = "Select BRN_CODE, BRN_DESC, SL_CODE+' | '+SL_NAME As Supplier from View_Master_Brand Order By SL_Code"
        ElseIf ComboBox1.Text = "Category" Then
            cmd.CommandText = "Select * from MASTER_CATEGORY"
        ElseIf ComboBox1.Text = "Areas" Then
            cmd.CommandText = "Select * from MASTER_CUSTOMER_AREAS Order By AREA_CODE"
        ElseIf ComboBox1.Text = "Salesman" Then
            cmd.CommandText = "Select SM_CODE, NameMob, FName As Supervisor, SM_SALES_TYPE from View_Master_Salesman Order By SM_Code"
        ElseIf ComboBox1.Text = "Customer Type" Then
            cmd.CommandText = "Select * from MASTER_CUSTOMER_TYPES Order By CUS_TYPE"
        ElseIf ComboBox1.Text = "Customers" Then
            cmd.CommandText = "Select CUST_CODE as Code, CUST_NAME as Name, CUST_TEL as Tel, CUST_ACTIVE As Actv from View_CustomerMaster Order By CUST_CODE"
        ElseIf ComboBox1.Text = "Trade Channel" Then
            cmd.CommandText = "Select * from MASTER_CUSTOMER_CHANNEL_TYPES Order By CHN_CODE"
        ElseIf ComboBox1.Text = "Measuring Units" Then
            cmd.CommandText = "Select * from Master_Measuring_Units"
        ElseIf ComboBox1.Text = "Invoice" Then
            cmd.CommandText = "Select INV_NO, CUST_CODE+' | '+CUST_NAME As Customer, InvDate, NET as NetAmnt, INV_POSTED As Posted, INV_CANCEL as Cancelled, NameMob as Salesmen from View_SalesInv_Main Where INV_DATE >= '" + dtpFDate.Value.Date.ToString + "' and INV_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Order By INV_NO"
        ElseIf ComboBox1.Text = "Invoice Cost, Sales and Profit" Then
            cmd.CommandText = "with CTE (INV_NO, InvDATE, Cname, Cost, Sales, Profit, ProPerc) As (select INV_NO, (Select Convert(varchar,Inv_Date,106) From View_SalesInv_Main Where INV_NO=T.Inv_NO) As InvDate, (Select Cust_Code + ' | ' + CUST_NAME From View_SalesInv_Main Where INV_NO=T.Inv_NO) As CName, Cost, Sales, Profit, Convert(decimal(18,2),Case When Profit=0 or Cost = 0 Then 0 Else Profit*100/Cost End) As ProPerc from View_SalesInv_Profit T Where Inv_No In (Select Inv_No From SALES_HEADER Where INV_DATE >= '" + dtpFDate.Value.Date.ToString + "' and INV_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "')) Select * From CTE Union all Select '','','Sum Total', Sum(Cost), Sum(Sales), Sum(Profit),Convert(decimal(18,2),Case When Sum(Profit)=0 Then 0 Else Sum(Profit)*100/Sum(Cost) End) from CTE  Order By INV_NO Desc"
        ElseIf ComboBox1.Text = "Invoice Net, Collection and Status" Then
            cmd.CommandText = "with CTE (INV, InvDATE, Customer, Net, Clctn, Status) As (select INV_NO As Inv, Convert(varchar,Inv_Date,106) As InvDate, Customer, Net, Collection As Clctn, Status from View_SalesCollection Where INV_DATE >= '" + dtpFDate.Value.Date.ToString + "' and INV_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "') Select * From CTE Union all Select '','','Sum Total', Sum(Net), Sum(Clctn), Case When Sum(Net) = Sum(Clctn) Then 'Equal' Else case When Sum(Net) > Sum(Clctn) Then 'Deficit' else 'Advance' End End from CTE Order By INV Desc"
        ElseIf ComboBox1.Text = "Customer Cost, Sales and Profit" Then
            cmd.CommandText = "with CTE (Cname, Cost, Sales, Profit, ProPerc) As (SELECT View_SalesInv_Main.CUST_CODE+' | '+View_SalesInv_Main.CUST_NAME As CName, SUM(View_SalesInv_Profit.Cost) AS Cost, SUM(View_SalesInv_Profit.Sales) AS Sales, SUM(View_SalesInv_Profit.Profit) AS Profit, Convert(decimal(18,2),Case When SUM(View_SalesInv_Profit.Profit)=0 or SUM(View_SalesInv_Profit.Cost)=0 Then 0 Else SUM(View_SalesInv_Profit.Profit)*100/SUM(View_SalesInv_Profit.Cost) End) As ProPerc FROM View_SalesInv_Profit INNER JOIN View_SalesInv_Main ON View_SalesInv_Profit.INV_NO =  View_SalesInv_Main.INV_NO Where View_SalesInv_Main.INV_DATE >= '" + dtpFDate.Value.Date.ToString + "' and View_SalesInv_Main.INV_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' GROUP BY View_SalesInv_Main.CUST_NAME,View_SalesInv_Main.CUST_CODE) Select * from CTE Union Select 'Sum Total', Sum(Cost), Sum(Sales), Sum(Profit), Convert(decimal(18,2),Case When Sum(Profit)=0 Then 0 Else Sum(Profit)*100/Sum(Cost) End) from CTE"
        ElseIf ComboBox1.Text = "Customer Net, Collection and Status" Then
            cmd.CommandText = "with CTE (Customer, Net, Collection, Status) As (select Customer, Sum(Net) As Net, Sum(Collection) as Collection, Case When Sum(Collection) is null Then 'Pending' Else Case When Sum(Net) = Sum(Collection) Then 'Equal' Else case When Sum(Net) > Sum(Collection) Then 'Deficit' else 'Advance' End End End As Status from View_SalesCollection Where INV_DATE >= '" + dtpFDate.Value.Date.ToString + "' and INV_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Group By Customer) Select * From CTE Union all Select 'Sum Total', Sum(Net), Sum(Collection), Case When Sum(Net) = Sum(Collection) Then 'Equal' Else case When Sum(Net) > Sum(Collection) Then 'Deficit' else 'Advance' End End from CTE"
        ElseIf ComboBox1.Text = "GRN" Then
            cmd.CommandText = "Select GRN_NO, CUST_CODE+' | '+CUST_NAME As Customer, GrnDate, NET as NetAmnt, Grn_POSTED As Posted, Grn_CANCEL as Cancelled, NameMob as Salesmen from View_GRN_Main Where GRN_DATE >= '" + dtpFDate.Value.Date.ToString + "' and GRN_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Order By GRN_NO"
        ElseIf ComboBox1.Text = "Free Goods" Then
            cmd.CommandText = "Select Ent_No, INV_No, ITEMCODE+' | '+ITEM_DESC As ItemName, Qty, ITM_PRICE As CPrice, Gross from View_SalesInv_Dtls Where InvDATE >= '" + dtpFDate.Value.Date.ToString + "' and InvDATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' And ITM_DISC_PER = 100 Order By Ent_No"
            ' ElseIf ComboBox1.Text = "Store Requisition" Then
        ElseIf ComboBox1.Text = "Reciepts" Then
            cmd.CommandText = "Select RCNo, RCDate, Mode, Remarks, Amnt, Cancel, CUS_CODE+' | '+CNAME As Customer, Initials As RecvBy From View_CustomerReciepts Where CUS_RECIEPT_DATE >= '" + dtpFDate.Value.Date.ToString + "' and CUS_RECIEPT_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Order By RCNo"
        ElseIf ComboBox1.Text = "Items Cost N Sales Pricing" Then
            cmd.CommandText = "Select * From View_Item_CP_SP"
        End If

        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds)

        Dim objDlg As New SaveFileDialog
        objDlg.Filter = "Excel File|*.xls"
        objDlg.OverwritePrompt = False
        If objDlg.ShowDialog = DialogResult.OK Then
            Dim filepath As String = objDlg.FileName
            AccessVerify.LoadingFrm(True)
            AccessVerify.ExportToExcel(ds.Tables(0), filepath)
        End If
        con.Close()
    End Sub
End Class