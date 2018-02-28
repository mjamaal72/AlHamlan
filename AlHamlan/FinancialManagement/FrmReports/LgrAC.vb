Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine

Public Class LgrAC
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
        Dim cr As New ReportDocument
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet

        If RadioButton1.Checked = True Then
            cr = New LSGenLegr
            cmd.CommandText = "Truncate table DummyLS Insert Into DummyLS (GLCode, GLDesc, SLCode, VDate, VOUCHER_DATE, Ref, Narration, VNo, Credit, Debit)(SELECT * from dbo.LS_Gen_Ledger ('" + dtpFDate.Value.Date.ToString + "', '" + dtpToDate.Value.Date.AddDays(1).ToString + "') UNION ALL SELECT GL_CODE, GL_DESC, '', '', null, '', 'Opening Balance', 0, CASE WHEN GL_KD_OPEN+ISNULL((SELECT SUM(debit)-SUM(credit) FROM LS_Gen_Ledger (DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0),'" + dtpFDate.Value.Date.ToString + "') WHERE GLCode = View_Master_GenLedger.GL_CODE),0) >= 0 THEN 0 ELSE (GL_KD_OPEN+ISNULL((SELECT SUM(debit)-SUM(credit) FROM LS_Gen_Ledger (DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0),'" + dtpFDate.Value.Date.ToString + "') WHERE GLCode = View_Master_GenLedger.GL_CODE),0)) * - 1 END, CASE WHEN GL_KD_OPEN+ISNULL((SELECT SUM(debit)-SUM(credit) FROM LS_Gen_Ledger (DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0),'" + dtpFDate.Value.Date.ToString + "') WHERE GLCode = View_Master_GenLedger.GL_CODE),0) >= 0 THEN GL_KD_OPEN+ISNULL((SELECT SUM(debit)-SUM(credit) FROM LS_Gen_Ledger (DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0),'" + dtpFDate.Value.Date.ToString + "') WHERE GLCode = View_Master_GenLedger.GL_CODE),0) ELSE 0 END FROM View_Master_GenLedger)"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Select * from DummyLS Order By GLCODE, VOUCHER_DATE"
        Else
            cr = New LSSubLegr
            cmd.CommandText = "Truncate table DummyLS Insert Into DummyLS (GLCode, GLDesc, SLCode, SLDesc, VDate, VOUCHER_DATE, Ref, Narration, VNo, Credit, Debit)(SELECT * from dbo.LS_Sub_Ledger ('" + dtpFDate.Value.Date.ToString + "', '" + dtpToDate.Value.Date.AddDays(1).ToString + "') UNION ALL SELECT SL_GL_CODE, GL_DESC, SL_CODE, SL_NAME,'', '', null, 'Opening Balance', 0, CASE WHEN SL_KD_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM LS_Sub_Ledger (DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0),'" + dtpFDate.Value.Date.ToString + "') WHERE SLCODE = View_Master_SubLedger.SL_CODE AND GLCode = View_Master_SubLedger.SL_GL_CODE),0) >= 0 THEN 0 ELSE (SL_KD_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM LS_Sub_Ledger (DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0),'" + dtpFDate.Value.Date.ToString + "') WHERE SLCODE = View_Master_SubLedger.SL_CODE AND GLCode = View_Master_SubLedger.SL_GL_CODE),0)) * - 1 END, CASE WHEN SL_KD_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM LS_Sub_Ledger (DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0),'" + dtpFDate.Value.Date.ToString + "') WHERE SLCODE = View_Master_SubLedger.SL_CODE AND GLCode = View_Master_SubLedger.SL_GL_CODE),0) >= 0 THEN SL_KD_OPEN_BALANCE+ISNULL((SELECT SUM(debit)-SUM(credit) FROM LS_Sub_Ledger (DATEADD(yy, DATEDIFF(yy,0,'" + dtpFDate.Value.Date.ToString + "'), 0),'" + dtpFDate.Value.Date.ToString + "') WHERE SLCODE = View_Master_SubLedger.SL_CODE AND GLCode = View_Master_SubLedger.SL_GL_CODE),0) ELSE 0 END FROM View_Master_SubLedger)"
            cmd.ExecuteNonQuery()
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Select * from DummyLS Order By GLCode, SLCode, VOUCHER_DATE"
        End If
        da.SelectCommand = cmd
        da.Fill(ds, "DummyLS")

        AccessVerify.LoadReports(cr, ds, "RepDuration?" + dtpFDate.Text + " To " + dtpToDate.Text + "?" + MainMDI.lblFrmDtls.Text)
        con.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub TrialBalance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        AccessVerify.LoadingFrm(False)
    End Sub
End Class