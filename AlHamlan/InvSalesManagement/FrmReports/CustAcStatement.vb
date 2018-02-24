Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class CustAcStatement
    
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
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        If cbCust.Text = "" Then
            cmd.CommandText = "Select * from View_CustAcntStatement WHERE ((TransDate >= '" + dtpFDate.Value.Date.ToString + "' AND  TransDate <='" + dtpToDate.Value.Date.AddDays(1).ToString + "') OR (TransDate IS NULL)) UNION SELECT CUST_CODE, CUST_NAME, NULL, 'OPENING BALANCE', '', 'OB', '', CASE WHEN CUST_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM View_CustAcntStatement WHERE ((TransDate >= DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0) AND  TransDate <='" + dtpFDate.Value.Date.ToString + "') OR (TransDate IS NULL)) And Code = View_CustomerMaster.CUST_CODE),0) >= 0 THEN CUST_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM View_CustAcntStatement WHERE ((TransDate >= DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0) AND  TransDate <='" + dtpFDate.Value.Date.ToString + "') OR (TransDate IS NULL)) And Code = View_CustomerMaster.CUST_CODE),0) ELSE 0 END, CASE WHEN CUST_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM View_CustAcntStatement WHERE ((TransDate >= DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0) AND  TransDate <='" + dtpFDate.Value.Date.ToString + "') OR (TransDate IS NULL)) And Code = View_CustomerMaster.CUST_CODE),0) >= 0 THEN 0 ELSE (CUST_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM View_CustAcntStatement WHERE ((TransDate >= DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0) AND  TransDate <='" + dtpFDate.Value.Date.ToString + "') OR (TransDate IS NULL)) And Code = View_CustomerMaster.CUST_CODE),0)) * - 1 END FROM View_CustomerMaster Where CUST_CODE In (Select Code from View_CustAcntStatement WHERE ((TransDate >= '" + dtpFDate.Value.Date.ToString + "' AND  TransDate <='" + dtpToDate.Value.Date.AddDays(1).ToString + "') OR (TransDate IS NULL))) ORDER By TransDate, Credit, RefNo"
        Else
            cmd.CommandText = "Select * from View_CustAcntStatement WHERE ((TransDate >= '" + dtpFDate.Value.Date.ToString + "' AND  TransDate <='" + dtpToDate.Value.Date.AddDays(1).ToString + "') OR (TransDate IS NULL)) And Code = '" + cbCust.SelectedValue.ToString + "' UNION SELECT CUST_CODE, CUST_NAME, NULL, 'OPENING BALANCE', '', 'OB', '', CASE WHEN CUST_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM View_CustAcntStatement WHERE ((TransDate >= DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0) AND  TransDate <='" + dtpFDate.Value.Date.ToString + "') OR (TransDate IS NULL)) And Code = '" + cbCust.SelectedValue.ToString + "'),0) >= 0 THEN CUST_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM View_CustAcntStatement WHERE ((TransDate >= DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0) AND  TransDate <='" + dtpFDate.Value.Date.ToString + "') OR (TransDate IS NULL)) And Code = '" + cbCust.SelectedValue.ToString + "'),0) ELSE 0 END, CASE WHEN CUST_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM View_CustAcntStatement WHERE ((TransDate >= DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0) AND  TransDate <='" + dtpFDate.Value.Date.ToString + "') OR (TransDate IS NULL)) And Code = '" + cbCust.SelectedValue.ToString + "'),0) >= 0 THEN 0 ELSE (CUST_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM View_CustAcntStatement WHERE ((TransDate >= DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0) AND  TransDate <='" + dtpFDate.Value.Date.ToString + "') OR (TransDate IS NULL)) And Code = '" + cbCust.SelectedValue.ToString + "'),0)) * - 1 END FROM View_CustomerMaster WHERE CUST_CODE='" + cbCust.SelectedValue.ToString + "' ORDER By TransDate, Credit, RefNo"
        End If
        da.SelectCommand = cmd
        da.Fill(ds, "View_CustAcntStatement")

        Dim cr As New CustAcntStatement
        AccessVerify.LoadReports(cr, ds, "RepDuration?Customer Statement Of Account : " + dtpFDate.Text + " To " + dtpToDate.Text)
        con.Close()
    End Sub

    Private Sub GLType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        conn()
        cmd.CommandText = "Select Distinct Convert(varchar,Cust_Code)+' | '+Cust_NAME As CName, Cust_Code from View_CustomerMaster Order By Cust_Code"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_CustomerMaster")
        cbCust.DisplayMember = "CName"
        cbCust.ValueMember = "Cust_Code"
        cbCust.DataSource = ds.Tables("View_CustomerMaster")
        con.Close()
        cbCust.SelectedIndex = -1
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

End Class