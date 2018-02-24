Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine

Public Class ProfitLoss
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
            cr = New GLProfitLoss
            cmd.CommandText = "Truncate table DummyPL Insert Into DummyPL (PLMode, Particular, Amount)(Select Mode, Particular, Amount from GL_ProfitLoss('" + dtpFDate.Value.Date.ToString + "' , '" + dtpToDate.Value.Date.AddDays(1).ToString + "'))"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Select * from DummyPL Order By PLMode, Particular Desc"
        Else
            cr = New SLProfitLoss
            cmd.CommandText = "Truncate table DummyPL Insert Into DummyPL (PLMode, Section, Code, Particular, Amount)(Select Mode, Section, Code, Particular, Amount from SL_ProfitLoss('" + dtpFDate.Value.Date.ToString + "' , '" + dtpToDate.Value.Date.AddDays(1).ToString + "'))"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Select * from DummyPL Order By PLMode, Section Desc, Code"
        End If
        da.SelectCommand = cmd
        da.Fill(ds, "DummyPL")

        AccessVerify.LoadReports(cr, ds, MainMDI.lblFrmDtls.Text + "?RepDuration?" + dtpFDate.Text + " To " + dtpToDate.Text)
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