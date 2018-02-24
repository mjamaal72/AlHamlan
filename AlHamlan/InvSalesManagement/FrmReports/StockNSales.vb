Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing.Printing

Public Class StockNSales
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
        CmdStr = "With CTE (Code, ItemName, Opening, Receives, Sales, Returns, Closing, Enroute) as (SELECT Item_Code as Code, ITEM_DESC As ItemName, CONVERT(int, ITEM_OPN_QTY + ISNULL((SELECT SUM(REC_RECEIVED_QTY) FROM dbo.View_IGN_Dtls WHERE (REC_ITM_CODE = T1.ITEM_CODE) AND REC_DATE >= DATEADD(yy, DATEDIFF(yy,0, '" + dtpFDate.Value.Date.ToString + "'), 0) AND REC_DATE <= '" + dtpFDate.Value.Date.ToString + "'), 0) - ISNULL((SELECT SUM(QTY) FROM dbo.View_SalesInv_Dtls WHERE INV_CANCEL='F' AND (ITEMCODE = T1.ITEM_CODE) AND InvDate >= DATEADD(yy, DATEDIFF(yy,0, '" + dtpFDate.Value.Date.ToString + "'), 0) AND InvDate <= '" + dtpFDate.Value.Date.ToString + "'), 0) + ISNULL((SELECT SUM(QTY) FROM dbo.View_GRN_Dtls WHERE GRN_CANCEL='F' AND (ITEMCODE = T1.ITEM_CODE) AND GRNDate >= DATEADD(yy, DATEDIFF(yy,0, '" + dtpFDate.Value.Date.ToString + "'), 0) AND GRNDate <= '" + dtpFDate.Value.Date.ToString + "'), 0)) As Opening, ISNULL((SELECT SUM(REC_RECEIVED_QTY) FROM dbo.View_IGN_Dtls WHERE (REC_ITM_CODE = T1.ITEM_CODE) AND REC_DATE >= '" + dtpFDate.Value.Date.ToString + "' AND REC_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "'), 0) As Receives, ISNULL((SELECT SUM(QTY) FROM dbo.View_SalesInv_Dtls WHERE INV_CANCEL='F' AND (ITEMCODE = T1.ITEM_CODE) AND InvDate >= '" + dtpFDate.Value.Date.ToString + "' AND InvDate <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "'), 0) As Sales, ISNULL((SELECT SUM(QTY) FROM dbo.View_GRN_Dtls WHERE GRN_CANCEL='F' AND (ITEMCODE = T1.ITEM_CODE) AND GRNDate >= '" + dtpFDate.Value.Date.ToString + "' AND GRNDate <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "'), 0) As Returns, CONVERT(int, ITEM_OPN_QTY + ISNULL((SELECT SUM(REC_RECEIVED_QTY) FROM dbo.View_IGN_Dtls WHERE (REC_ITM_CODE = T1.ITEM_CODE) AND REC_DATE >= DATEADD(yy, DATEDIFF(yy,0, '" + dtpFDate.Value.Date.ToString + "'), 0) AND REC_DATE <= '" + dtpFDate.Value.Date.ToString + "'), 0) - ISNULL((SELECT SUM(QTY) FROM dbo.View_SalesInv_Dtls WHERE (ITEMCODE = T1.ITEM_CODE) AND InvDate >= DATEADD(yy, DATEDIFF(yy,0, '" + dtpFDate.Value.Date.ToString + "'), 0) AND InvDate <= '" + dtpFDate.Value.Date.ToString + "'), 0)) + ISNULL((SELECT SUM(REC_RECEIVED_QTY) FROM dbo.View_IGN_Dtls WHERE (REC_ITM_CODE = T1.ITEM_CODE) AND REC_DATE >= '" + dtpFDate.Value.Date.ToString + "' AND REC_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "'), 0) - ISNULL((SELECT SUM(QTY) FROM dbo.View_SalesInv_Dtls WHERE INV_CANCEL='F' AND (ITEMCODE = T1.ITEM_CODE) AND InvDate >= '" + dtpFDate.Value.Date.ToString + "' AND InvDate <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "'), 0) + ISNULL((SELECT SUM(QTY) FROM dbo.View_GRN_Dtls WHERE GRN_CANCEL='F' AND (ITEMCODE = T1.ITEM_CODE) AND GRNDate >= '" + dtpFDate.Value.Date.ToString + "' AND GRNDate <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "'), 0) As Closing, ISNULL((SELECT SUM(PUR_QTY_BALANCE) FROM dbo.View_PO_Dtls WHERE (PUR_ITM_CODE = T1.ITEM_CODE) AND PUR_ORDER_DATE >= '" + dtpFDate.Value.Date.ToString + "' AND PUR_ORDER_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "'), 0) As Enroute FROM View_Master_Items T1 Where Item_Code Is Not Null "

        If cbitem.SelectedValue <> Nothing Then
            CmdStr = CmdStr + " AND ITEM_CODE = '" + cbitem.SelectedValue + "'"
        End If

        CmdStr = CmdStr + " ) Select * from CTE Union Select 'ZZZZ', 'Sum Total', Sum(Opening), Sum(Receives), Sum (Sales), Sum (Returns), Sum(Closing), Sum(Enroute) from CTE"

        cmd.CommandText = CmdStr
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables(0)
        con.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AccessVerify.DGVPrinting("Stock and Sales", "", True, DataGridView1)
    End Sub

    Private Sub Me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        conn()
        cbitem.Items.Clear()

        cmd.CommandText = "Select Distinct ITEM_CODE +' | '+  ITEM_DESC As ItmDESC, ITEM_CODE from View_Master_Items T2 Where ITEM_CODE <>'' And ITEM_CODE Is Not Null"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "T2")
        cbitem.DisplayMember = "ItmDESC"
        cbitem.ValueMember = "ITEM_CODE"
        cbitem.DataSource = ds.Tables("T2")

        con.Close()

        cbitem.SelectedIndex = -1
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex = DataGridView1.RowCount - 1 Then
            MsgBox("Total Row Cannot Be Detailed.", MsgBoxStyle.Information, "H.F. General Trading CO.")
        Else
            If e.ColumnIndex = DataGridView1.Columns("Receives").Index AndAlso e.RowIndex >= 0 Then
                AccessVerify.LoadSrchGrid("IGN - Details For Item : " + DataGridView1("ItemName", e.RowIndex).Value.ToString, "Select IGN_No, Convert(varchar, Rec_Date, 106) as IGNDate, SL_Code + ' | '+ SL_Name As Supplier, REC_INV_QTY As InvQty, REC_RECEIVED_QTY As RecvQty, Gross, REC_ITM_DISC as Disc, Net from View_IGN_Dtls Where REC_ITM_CODE = '" + DataGridView1("Code", e.RowIndex).Value.ToString + "' And REC_DATE >= '" + dtpFDate.Value.Date.ToString + "' AND REC_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Order By IGN_No, REC_ENT_NO", "IGN", True, "IGN_No", "txtign")
            ElseIf e.ColumnIndex = DataGridView1.Columns("Sales").Index AndAlso e.RowIndex >= 0 Then
                AccessVerify.LoadSrchGrid("SALES - Details For Item : " + DataGridView1("ItemName", e.RowIndex).Value.ToString, "Select Inv_No, INV_DATE as IDate, Cust_Code + ' | '+ Cust_Name As Customer, Qty, ITM_Price As Price, Gross, Net from View_SalesInv_Dtls Where ItemCode = '" + DataGridView1("Code", e.RowIndex).Value.ToString + "' And InvDate >= '" + dtpFDate.Value.Date.ToString + "' AND InvDate <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Order By Inv_No, ENT_NO", "SalesInvView", True, "Inv_No", "txtinvno")
            ElseIf e.ColumnIndex = DataGridView1.Columns("Returns").Index AndAlso e.RowIndex >= 0 Then
                AccessVerify.LoadSrchGrid("GRN - Details For Item : " + DataGridView1("ItemName", e.RowIndex).Value.ToString, "Select GRN_No, GRN_DATE as IDate, Cust_Code + ' | '+ Cust_Name As Customer, Qty, ITM_Price As Price, Gross, Net from View_GRN_Dtls Where ItemCode = '" + DataGridView1("Code", e.RowIndex).Value.ToString + "' And GRNDate >= '" + dtpFDate.Value.Date.ToString + "' AND GRNDate <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Order By GRN_No, ENT_NO", "GRN", True, "GRN_No", "txtgrnno")
            ElseIf e.ColumnIndex = DataGridView1.Columns("Enroute").Index AndAlso e.RowIndex >= 0 Then
                AccessVerify.LoadSrchGrid("PO - Details For Item : " + DataGridView1("ItemName", e.RowIndex).Value.ToString, "Select PUR_ORDER_NO as PONo, Convert(varchar, PUR_ORDER_DATE, 106) as PODate, SL_Code + ' | '+ SL_Name As Supplier, PUR_QTY_ORDERED As OdrQty, PUR_QTY_RECIEVED As RecvQty, PUR_QTY_CANCELLED As CnclQty, PUR_QTY_BALANCE as BalQty from View_PO_Dtls Where PUR_ITM_CODE = '" + DataGridView1("Code", e.RowIndex).Value.ToString + "' And PUR_ORDER_DATE >= '" + dtpFDate.Value.Date.ToString + "' AND PUR_ORDER_DATE <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "' Order By PUR_ORDER_NO, PUR_ENT_NO", "POs", True, "PONo", "txtpono")
            End If
        End If
    End Sub
End Class