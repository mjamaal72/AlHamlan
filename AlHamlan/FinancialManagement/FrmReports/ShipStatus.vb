Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing.Printing

Public Class ShipStatus
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
        CmdStr = "Select * from View_PO_Main Where PUR_ARR_DATE >= '" + dtpFDate.Value.Date.ToString + "' AND  PUR_ARR_DATE <='" + dtpToDate.Value.Date.AddDays(1).ToString + "' "

        If cbdiv.SelectedValue <> Nothing Then
            CmdStr = CmdStr + " AND PUR_DIV = '" + cbdiv.SelectedValue + "'"
        End If
        If cbsuplr.SelectedValue <> Nothing Then
            CmdStr = CmdStr + " AND SL_CODE = '" + cbsuplr.SelectedValue + "'"
        End If
        cmd.CommandText = CmdStr
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_PO_Main")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("View_PO_Main")
        con.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AccessVerify.DGVPrinting("Shipment Status", "", False, DataGridView1)
    End Sub

    Private Sub Me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        conn()

        cmd.CommandText = "Select Distinct SL_Code+' | '+SL_NAME As SlName, SL_Code from View_Master_Supplier"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_Master_Supplier")
        cbsuplr.DisplayMember = "SlName"
        cbsuplr.ValueMember = "SL_Code"
        cbsuplr.DataSource = ds.Tables("View_Master_Supplier")

        cmd.CommandText = "Select DIV_CODE +' | '+  DIV_DESC As DIVDESC, DIV_CODE from MASTER_DIVISION"
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "MASTER_DIVISION")
        cbdiv.DisplayMember = "DIVDESC"
        cbdiv.ValueMember = "DIV_CODE"
        cbdiv.DataSource = ds.Tables("MASTER_DIVISION")

        con.Close()

        cbdiv.SelectedIndex = -1
        cbsuplr.SelectedIndex = -1
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = DataGridView1.Columns("PONo").Index AndAlso e.RowIndex >= 0 Then
            AccessVerify.LoadSrchGrid("Details For Purchase Order No : " + DataGridView1("PONo", e.RowIndex).Value.ToString, "Select PUR_ITM_CODE As ItmCode, ITEM_DESC As ItemName, PUR_PACK As Pack, PUR_QTY_ORDERED As QtyOrdered, PUR_QTY_RECIEVED As QtyRcvd, NET from View_PO_Dtls Where PUR_ORDER_NO = '" + DataGridView1("PONo", e.RowIndex).Value.ToString + "' Order By PUR_ENT_NO", Me.Name, False)
        End If
    End Sub
End Class