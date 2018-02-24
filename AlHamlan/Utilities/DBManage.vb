Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class DBManage

#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim AccessVerify As New VerifyAccess
#End Region
    Private Sub Me_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.SendWait("{TAB}")
        End If
    End Sub

    Private Sub GeneralLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        AccessVerify.LoadingFrm(False)
    End Sub

    Public Sub conn()
        con = New SqlConnection
        Dim abc As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLibrary.dll")
        con.ConnectionString = Replace(abc, "AlHamlan", MainMDI.Label4.Text)
        con.Open()
        cmd = New SqlCommand
        cmd.Connection = con
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conn()

            cmd.CommandText = "BACKUP DATABASE AlHamlan TO  DISK = 'D:\AlHamlan_DB_BackUp\" + TextBox1.Text + ".bak'"
            cmd.ExecuteNonQuery()
            MsgBox("Backup Created Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")

            TextBox1.Text = ""
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            conn()
            cmd.CommandText = "BACKUP DATABASE AlHamlan TO  DISK = 'D:\AlHamlan_DB_BackUp\" + RegularExpressions.Regex.Replace(DateTime.Now.ToString, "[\/:]", "-") + ".bak'"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "Truncate Table [dbo].[CUSTOMER_RECIEPTS] Truncate Table [dbo].[GRN_DETAIL] Truncate Table [dbo].[GRN_HEADER] Truncate Table [dbo].[IGN_DTLS] Truncate Table [dbo].[IGN_HEADER] Truncate Table [dbo].[IGNCostSheetDtls] Truncate Table [dbo].[IGNCostSheetMain] Truncate Table [dbo].[LETTER_OF_CREDIT] Truncate Table [dbo].[LogDetails] Truncate Table [dbo].[PROFORMA_DETAIL] Truncate Table [dbo].[PROFORMA_HEADER] Truncate Table [dbo].[PURCHASE_DETAIL] Truncate Table [dbo].[PURCHASE_HEADER] Truncate Table [dbo].[SALES_DETAIL] Truncate Table [dbo].[SALES_HEADER] Truncate Table [dbo].[VOUCHER_DETAIL] Truncate Table [dbo].[VOUCHER_HEADER] Update [dbo].[CUSTOMER_MASTER] Set [CUST_OPEN_BALANCE] = 0 Update [dbo].[Master_GenLedger] Set [GL_KD_OPEN] = 0, [GL_KD_DEBIT] = 0, [GL_KD_CREDIT] = 0, [GL_FC_OPEN] = 0, [GL_FC_DEBIT] = 0, [GL_FC_CREDIT] = 0 Update [dbo].[MASTER_SUBLEDGER] Set [SUP_MIN_STK] = 0,[SL_KD_OPEN_BALANCE] = 0,[SL_KD_DEBIT_BALANCE] = 0,[SL_KD_CREDIT_BALANCE] = 0,[SL_FC_OPEN_BALANCE] = 0,[SL_FC_DEBIT_BALANCE] = 0,[SL_FC_CREDIT_BALANCE] = 0 Update [dbo].[MASTER_ITEM] Set [ITEM_PRICE] = 0,[COST] = 0,[OPNCOST] = 0,[PHY_STOCK] = 0,[PRVCOST] = 0,[ITEM_FR_PRICE] = 0,[ITEM_OPN_QTY] = 0"
            cmd.ExecuteNonQuery()
            MsgBox("DB Reset Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            conn()
            cmd.CommandText = "ALTER DATABASE AlHamlan SET RECOVERY SIMPLE WITH NO_WAIT DBCC SHRINKFILE(N'AlHamlan_log', 1) ALTER DATABASE AlHamlan SET RECOVERY FULL WITH NO_WAIT"
            cmd.ExecuteNonQuery()
            MsgBox("DB Size Reduces Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
        End Try
    End Sub
End Class