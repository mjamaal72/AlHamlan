Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing.Printing

Public Class SalesValue
    Dim AccessVerify As New VerifyAccess

#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet

    Private strFormat As StringFormat
    'Used to format the grid rows.
    Private arrColumnLefts As New ArrayList()
    'Used to save left coordinates of columns
    Private arrColumnWidths As New ArrayList()
    'Used to save column widths
    Private iCellHeight As Integer = 0
    'Used to get/set the datagridview cell height
    Private iTotalWidth As Integer = 0
    '
    Private iRow As Integer = 0
    'Used as counter
    Private bFirstPage As Boolean = False
    'Used to check whether we are printing first page
    Private bNewPage As Boolean = False
    ' Used to check whether we are printing a new page
    Private iHeaderHeight As Integer = 0
    'Used for the header height
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
        conn()
        DataGridView1.AutoGenerateColumns = False
        Dim CmdStr As String = ""
        CmdStr = "With CTE (Code, Salesman, Sales, Returns, NetSales, Collection) as (SELECT convert(varchar,SM_CODE), NameMob, ISNULL((SELECT SUM(net) FROM dbo.View_SalesInv_Main WHERE (SMANCODE = SM.SM_Code) AND Inv_Date >= '" + dtpFDate.Value.Date.ToString + "' AND Inv_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "'), 0.000) As Sales, ISNULL((SELECT SUM(net) FROM dbo.View_GRN_Main WHERE (SMANCODE = SM.SM_Code) AND GRN_DATE >= '" + dtpFDate.Value.Date.ToString + "' AND GRN_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "'), 0.000) As Returns, ISNULL((SELECT SUM(net) FROM dbo.View_SalesInv_Main WHERE (SMANCODE = SM.SM_Code) AND Inv_Date >= '" + dtpFDate.Value.Date.ToString + "' AND Inv_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "'), 0.000) - ISNULL((SELECT SUM(net) FROM dbo.View_GRN_Main WHERE (SMANCODE = SM.SM_Code) AND GRN_DATE >= '" + dtpFDate.Value.Date.ToString + "' AND GRN_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "'), 0.000) As NetSales, ISNULL((SELECT SUM(Net) FROM dbo.View_SalesCollection WHERE Status IN ('Settled') And Inv_No IN (SELECT Inv_No FROM dbo.View_SalesInv_Main WHERE (SMANCODE = SM.SM_Code) AND Inv_Date >= '" + dtpFDate.Value.Date.ToString + "' AND Inv_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "')), 0.000) + ISNULL((SELECT SUM(Collection) FROM dbo.View_SalesCollection WHERE Status IN ('Paid', 'Partial', 'Over Paid', 'Pending') And Inv_No IN (SELECT Inv_No FROM dbo.View_SalesInv_Main WHERE (SMANCODE = SM.SM_Code) AND Inv_Date >= '" + dtpFDate.Value.Date.ToString + "' AND Inv_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "')), 0.000) AS Collection FROM dbo.View_Master_Salesman SM Where SM_CODE Is Not Null "

        If cbSMan.SelectedValue <> Nothing Then
            CmdStr = CmdStr + " AND SM_CODE = " + cbSMan.SelectedValue.ToString + ""
        End If

        CmdStr = CmdStr + " ) Select * from CTE Union Select 'ZZZZ', 'Sum Total', Sum(Sales), Sum (Returns), Sum(NetSales), Sum(Collection) from CTE"

        cmd.CommandText = CmdStr
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables(0)
        con.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AccessVerify.DGVPrinting("Salesmen Sales Value", "", True, DataGridView1)
    End Sub

    Private Sub Me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        conn()
        cbSMan.Items.Clear()

        cmd.CommandText = "Select Distinct convert(varchar,SM_CODE) +' | '+  NameMob As Salesman, SM_CODE from View_Master_Salesman Where SM_CODE Is Not Null"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_Master_Salesman")
        cbSMan.DisplayMember = "Salesman"
        cbSMan.ValueMember = "SM_CODE"
        cbSMan.DataSource = ds.Tables("View_Master_Salesman")

        con.Close()

        cbSMan.SelectedIndex = -1
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex = DataGridView1.RowCount - 1 Then
            MsgBox("Total Row Cannot Be Detailed.", MsgBoxStyle.Information, "H.F. General Trading CO.")
        Else
            If e.ColumnIndex = DataGridView1.Columns("Returns").Index AndAlso e.RowIndex >= 0 Then
                AccessVerify.LoadSrchGrid("IGN - Details For Salesman : " + DataGridView1("Salesman", e.RowIndex).Value.ToString, "SELECT GRN_NO, GrnDate AS GDate, Cust_Code + ' | '+ Cust_Name As Customer, Gross, Net FROM dbo.View_GRN_Main Where SMANCODE = '" + DataGridView1("Code", e.RowIndex).Value.ToString + "' And GRN_Date >= '" + dtpFDate.Value.Date.ToString + "' AND GRN_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Order By GRN_NO", "GRN", True, "GRN_NO", "txtgrnno")
            ElseIf e.ColumnIndex = DataGridView1.Columns("Sales").Index AndAlso e.RowIndex >= 0 Then
                AccessVerify.LoadSrchGrid("SALES - Details For Salesman : " + DataGridView1("Salesman", e.RowIndex).Value.ToString, "Select Inv_No, INVDATE as IDate, Cust_Code + ' | '+ Cust_Name As Customer, Gross, Net from View_SalesInv_Main Where SMANCODE = '" + DataGridView1("Code", e.RowIndex).Value.ToString + "' And Inv_Date >= '" + dtpFDate.Value.Date.ToString + "' AND Inv_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Order By Inv_No", "SalesInvView", True, "Inv_No", "txtinvno")
            ElseIf e.ColumnIndex = DataGridView1.Columns("Collection").Index AndAlso e.RowIndex >= 0 Then
                AccessVerify.LoadSrchGrid("Collection - Details For Salesman : " + DataGridView1("Salesman", e.RowIndex).Value.ToString, "Select INV_NO, CUST_CODE+' | '+CUST_NAME As Customer, CONVERT(VARCHAR(24), Inv_Date,100) As InvDate, LPO, NET as NetAmnt,  isnull((Select Collection From View_SalesCollection Where INV_NO=View_SalesInv_Main.INV_NO),0) As Collection, isnull((Select Status From View_SalesCollection Where INV_NO=View_SalesInv_Main.INV_NO),0) As Status from View_SalesInv_Main Where SMANCODE = '" + DataGridView1("Code", e.RowIndex).Value.ToString + "' And Inv_Date >= '" + dtpFDate.Value.Date.ToString + "' AND Inv_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Order By INV_NO DESC", "SalesInvView", True, "Inv_No", "txtinvno")
            End If
        End If
    End Sub
End Class