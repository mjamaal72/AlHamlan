Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class InvPrntng
    
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

    Private Sub InvPrntng_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AccessVerify.LoadingFrm(True)

        conn()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        cmd.CommandText = "Select * from View_SalesInv_Main where Inv_No >= " + txtfrom.Text + " and Inv_No <= " + txtto.Text
        da.SelectCommand = cmd
        da.Fill(ds, "View_SalesInv_Main")
        cmd.CommandText = "Select * from View_SalesInv_Dtls where Inv_No >= " + txtfrom.Text + " and Inv_No <= " + txtto.Text
        da.SelectCommand = cmd
        da.Fill(ds, "View_SalesInv_Dtls")

        Dim cr As New OrgInvoice
        AccessVerify.LoadReports(cr, ds)

        cmd.CommandText = "Update SALES_HEADER Set INV_PRINTED = GetDate() Where  Inv_No >= " + txtfrom.Text + " and Inv_No <= " + txtto.Text
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        AccessVerify.LoadingFrm(True)
        conn()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        cmd.CommandText = "Select * from View_SalesInv_Main where Inv_No >= " + txtfrom.Text + " and Inv_No <= " + txtto.Text
        da.SelectCommand = cmd
        da.Fill(ds, "View_SalesInv_Main")
        cmd.CommandText = "Select * from View_SalesInv_Dtls where Inv_No >= " + txtfrom.Text + " and Inv_No <= " + txtto.Text
        da.SelectCommand = cmd
        da.Fill(ds, "View_SalesInv_Dtls")

        Dim cr As New DCInvoice
        cr.SetDataSource(ds)
        AccessVerify.LoadReports(cr, ds, MainMDI.lblFrmDtls.Text)

        cmd.CommandText = "Update SALES_HEADER Set INV_DCPrntd = GetDate() Where  Inv_No >= " + txtfrom.Text + " and Inv_No <= " + txtto.Text
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        AccessVerify.LoadingFrm(True)
        conn()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        cmd.CommandText = "Select * from View_SalesInv_Main where Inv_No >= " + txtfrom.Text + " and Inv_No <= " + txtto.Text
        da.SelectCommand = cmd
        da.Fill(ds, "View_SalesInv_Main")
        cmd.CommandText = "Select * from View_SalesInv_Dtls where Inv_No >= " + txtfrom.Text + " and Inv_No <= " + txtto.Text
        da.SelectCommand = cmd
        da.Fill(ds, "View_SalesInv_Dtls")

        Dim Cr As New CashMemo
        AccessVerify.LoadReports(Cr, ds, MainMDI.lblFrmDtls.Text)

        cmd.CommandText = "Update SALES_HEADER Set INV_CCPrntd = GetDate() Where  Inv_No >= " + txtfrom.Text + " and Inv_No <= " + txtto.Text
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
End Class