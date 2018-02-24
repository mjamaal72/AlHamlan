Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO

Public Class DBBackup

#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim AccessVerify As New VerifyAccess
#End Region

    Public Sub conn()
        con = New SqlConnection
        Dim abc As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLibrary.dll")
        con.ConnectionString = Replace(abc, "AlHamlan", MainMDI.Label4.Text)
        con.Open()
        cmd = New SqlCommand
        cmd.Connection = con
    End Sub

    Private Sub GeneralLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn()
            cmd.CommandText = "BACKUP DATABASE AlHamlan TO  DISK = 'D:\AlHamlan_DB_BackUp\" + RegularExpressions.Regex.Replace(DateTime.Now.ToString, "[\/:]", "-") + ".bak'"
            cmd.ExecuteNonQuery()
            con.Close()
            Timer1.Enabled = True
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        AccessVerify.LoadingFrm(False)
        Timer1.Enabled = False
        MsgBox("Backup Created Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
        Me.Close()
    End Sub
End Class