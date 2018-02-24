Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class SplrAcStatement
    
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
        If cbsuplr.Text = "" Then
            cmd.CommandText = "Select * from View_SplrAcntStatement WHERE ((TransDate >= '" + dtpFDate.Value.Date.ToString + "' AND  TransDate <='" + dtpToDate.Value.Date.AddDays(1).ToString + "') OR (TransDate IS NULL)) UNION SELECT SL_CODE, SL_NAME, NULL, '', 'OPENING BALANCE', '', CASE WHEN SL_KD_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM View_SplrAcntStatement WHERE ((TransDate >= DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0) AND  TransDate <='" + dtpFDate.Value.Date.ToString + "') OR (TransDate IS NULL)) And SL_CODE = View_Master_Supplier.SL_CODE),0) >= 0 THEN SL_KD_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM View_SplrAcntStatement WHERE ((TransDate >= DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0) AND  TransDate <='" + dtpFDate.Value.Date.ToString + "') OR (TransDate IS NULL)) And SL_CODE = View_Master_Supplier.SL_CODE),0) ELSE 0 END, CASE WHEN SL_KD_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM View_SplrAcntStatement WHERE ((TransDate >= DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0) AND  TransDate <='" + dtpFDate.Value.Date.ToString + "') OR (TransDate IS NULL)) And SL_CODE = View_Master_Supplier.SL_CODE),0) >= 0 THEN 0 ELSE (SL_KD_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM View_SplrAcntStatement WHERE ((TransDate >= DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0) AND  TransDate <='" + dtpFDate.Value.Date.ToString + "') OR (TransDate IS NULL)) And SL_CODE = View_Master_Supplier.SL_CODE),0)) * - 1 END FROM View_Master_Supplier Where SL_CODE In (Select SL_Code from View_SplrAcntStatement WHERE ((TransDate >= '" + dtpFDate.Value.Date.ToString + "' AND  TransDate <='" + dtpToDate.Value.Date.AddDays(1).ToString + "') OR (TransDate IS NULL))) ORDER By TransDate, Debit"
        Else
            cmd.CommandText = "Select * from View_SplrAcntStatement where ((TransDate >= '" + dtpFDate.Value.Date.ToString + "' AND  TransDate <='" + dtpToDate.Value.Date.AddDays(1).ToString + "') OR (TransDate IS NULL)) And SL_CODE = '" + cbsuplr.SelectedValue + "' UNION SELECT SL_CODE, SL_NAME, NULL, '', 'OPENING BALANCE', '', CASE WHEN SL_KD_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM View_SplrAcntStatement WHERE ((TransDate >= DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0) AND  TransDate <='" + dtpFDate.Value.Date.ToString + "') OR (TransDate IS NULL)) And SL_CODE = '" + cbsuplr.SelectedValue + "'),0) >= 0 THEN SL_KD_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM View_SplrAcntStatement WHERE ((TransDate >= DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0) AND  TransDate <='" + dtpFDate.Value.Date.ToString + "') OR (TransDate IS NULL)) And SL_CODE = '" + cbsuplr.SelectedValue + "'),0) ELSE 0 END, CASE WHEN SL_KD_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM View_SplrAcntStatement WHERE ((TransDate >= DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0) AND  TransDate <='" + dtpFDate.Value.Date.ToString + "') OR (TransDate IS NULL)) And SL_CODE = '" + cbsuplr.SelectedValue + "'),0) >= 0 THEN 0 ELSE (SL_KD_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM View_SplrAcntStatement WHERE ((TransDate >= DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0) AND  TransDate <='" + dtpFDate.Value.Date.ToString + "') OR (TransDate IS NULL)) And SL_CODE = '" + cbsuplr.SelectedValue + "'),0)) * - 1 END FROM View_Master_Supplier WHERE SL_CODE = '" + cbsuplr.SelectedValue + "' ORDER By TransDate, Debit"
        End If
        da.SelectCommand = cmd
        da.Fill(ds, "View_SplrAcntStatement")

        Dim cr As New SplrAcntStatement
        AccessVerify.LoadReports(cr, ds, "RepDuration?Supplier Statement Of Account : " + dtpFDate.Text + " To " + dtpToDate.Text)
        con.Close()
        ''Open the PrintDialog
        'Me.PrintDialog1.Document = Me.PrintDocument1
        'Dim dr As DialogResult = Me.PrintDialog1.ShowDialog()
        'If dr = DialogResult.OK Then
        '    'Get the Copy times
        '    Dim nCopy As Integer = Me.PrintDocument1.PrinterSettings.Copies
        '    'Get the number of Start Page
        '    Dim sPage As Integer = Me.PrintDocument1.PrinterSettings.FromPage
        '    'Get the number of End Page
        '    Dim ePage As Integer = Me.PrintDocument1.PrinterSettings.ToPage
        '    Dim PrinterName As String = Me.PrintDocument1.PrinterSettings.PrinterName
        '    Try
        '        cr.PrintOptions.PrinterName = PrinterName
        '        cr.PrintToPrinter(nCopy, False, sPage, ePage)
        '        MessageBox.Show("Send to Printer.")
        '    Catch err As Exception
        '        MessageBox.Show(err.ToString())
        '    End Try
        'End If

    End Sub

    Private Sub GLType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        conn()
        cmd.CommandText = "Select Distinct SL_Code+' | '+SL_NAME As SlName, SL_Code from View_Master_Supplier Order By SL_Code"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_Master_Supplier")
        cbsuplr.DisplayMember = "SlName"
        cbsuplr.ValueMember = "SL_Code"
        cbsuplr.DataSource = ds.Tables("View_Master_Supplier")
        con.Close()
        cbsuplr.SelectedIndex = -1
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

End Class