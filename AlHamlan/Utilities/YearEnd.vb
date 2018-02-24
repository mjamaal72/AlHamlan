Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class YearEnd

#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim cmd2 As SqlCommand
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
        cmd.CommandTimeout = 0
        cmd2 = New SqlCommand
        cmd2.Connection = con
        cmd2.CommandTimeout = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim abc As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLib.dll")
        abc = Replace(abc, "BackupNameHere", TextBox1.Text + " " + RegularExpressions.Regex.Replace(DateTime.Now.ToString, "[\/:]", "-"))
        abc = Replace(abc, "TargetDBNameHere", TextBox2.Text)
        abc = Replace(abc, "TargetDBPathHere", TextBox3.Text)
        TextBox4.Text = "Starting up Year End Procedures..."
        conn()
        Try
            cmd.CommandText = abc
            cmd.ExecuteNonQuery()
            TextBox4.Text = TextBox4.Text + vbNewLine + "Source DB Backup Created." + vbNewLine + "Target DB Initialized." + vbNewLine + "DB Cloning Completed."
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()
        Catch ex As Exception
            con.Close()
            TextBox4.Text = TextBox4.Text + vbNewLine + "Error Initializing Target DB." + vbNewLine + "Aborting Year End Process." + vbNewLine + "Reason :" + ex.Message
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()
            Exit Sub
        End Try

        Try
            TextBox4.Text = TextBox4.Text + vbNewLine + "Fetching Customer Data..."
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd.CommandText = "SELECT CUST_CODE, CUST_NAME, ISNULL ((SELECT SUM(Net) AS Expr1 FROM dbo.View_SalesInv_Main AS View_SalesInv_Main_1 WHERE (CUST_CODE = dbo.CUSTOMER_MASTER.CUST_CODE)), 0) + CUST_OPEN_BALANCE - ISNULL ((SELECT SUM(AMOUNT) AS Expr1 FROM dbo.CUSTOMER_RECIEPTS AS CUSTOMER_RECIEPTS_1 WHERE (CUS_CODE = dbo.CUSTOMER_MASTER.CUST_CODE) AND (CANCEL IS NULL)), 0) AS Pending FROM CUSTOMER_MASTER"
            da.SelectCommand = cmd
            da.Fill(ds, "CUSTOMER_MASTER")

            TextBox4.Text = TextBox4.Text + vbNewLine + "Configuring Customer Data..."
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()

            For Each drow As DataRow In ds.Tables(0).Rows
                cmd2.CommandText = "Update CUSTOMER_MASTER Set CUST_OPEN_BALANCE = " + CType(drow("Pending"), String).Trim + " Where CUST_CODE = " + CType(drow("CUST_CODE"), String).Trim + ""
                cmd2.ExecuteNonQuery()
            Next
            TextBox4.Text = TextBox4.Text + vbNewLine + "Customer Data Parsed Successfully."
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()
        Catch ex As Exception
            con.Close()
            TextBox4.Text = TextBox4.Text + vbNewLine + "Error Configuring Customer Data..." + vbNewLine + "Aborting Year End Process." + vbNewLine + "Reason :" + ex.Message
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()
            Exit Sub
        End Try

        Try
            TextBox4.Text = TextBox4.Text + vbNewLine + "Fetching General Ledger Data..."
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd.CommandText = "select *, Obal-credit+debit as FBal from TB_Gen_Ledger ('2017-01-01', GetDate())"
            da.SelectCommand = cmd
            da.Fill(ds, "TB_Gen_Ledger")

            TextBox4.Text = TextBox4.Text + vbNewLine + "Configuring General Ledger Data..."
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()

            For Each drow As DataRow In ds.Tables(0).Rows
                cmd2.CommandText = "Update Master_GenLedger Set GL_KD_OPEN = " + CType(drow("FBal"), String).Trim + " Where GL_CODE = '" + CType(drow("GL_CODE"), String).Trim + "'"
                cmd2.ExecuteNonQuery()
            Next

            TextBox4.Text = TextBox4.Text + vbNewLine + "General Ledger Data Parsed Successfully."
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()
        Catch ex As Exception
            con.Close()
            TextBox4.Text = TextBox4.Text + vbNewLine + "Error Configuring General Ledger Data..." + vbNewLine + "Aborting Year End Process." + vbNewLine + "Reason :" + ex.Message
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()
            Exit Sub
        End Try

        Try
            TextBox4.Text = TextBox4.Text + vbNewLine + "Fetching Sub Ledger Data..."
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd.CommandText = "Select *, OpenBl-credit+debit as FBal from TB_Sub_Ledger ('2017-01-01', GetDate())"
            da.SelectCommand = cmd
            da.Fill(ds, "TB_Sub_Ledger")

            TextBox4.Text = TextBox4.Text + vbNewLine + "Configuring Sub Ledger Data..."
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()

            For Each drow As DataRow In ds.Tables(0).Rows
                cmd2.CommandText = "Update MASTER_SUBLEDGER Set SL_KD_OPEN_BALANCE = " + CType(drow("FBal"), String).Trim + " Where SL_GL_CODE = '" + CType(drow("GLCode"), String).Trim + "' And SL_CODE = '" + CType(drow("SLCode"), String).Trim + "'"
                cmd2.ExecuteNonQuery()
            Next
            TextBox4.Text = TextBox4.Text + vbNewLine + "Sub Ledger Data Parsed Successfully."
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()
        Catch ex As Exception
            con.Close()
            TextBox4.Text = TextBox4.Text + vbNewLine + "Error Configuring Sub Ledger Data..." + vbNewLine + "Aborting Year End Process." + vbNewLine + "Reason :" + ex.Message
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()
            Exit Sub
        End Try

        Try
            TextBox4.Text = TextBox4.Text + vbNewLine + "Fetching Item Quantity..."
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd.CommandText = "select ITEM_CODE, BalanceAll from View_StockStatusLIVE"
            da.SelectCommand = cmd
            da.Fill(ds, "View_StockStatusLIVE")

            TextBox4.Text = TextBox4.Text + vbNewLine + "Configuring Item Quantity..."
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()

            For Each drow As DataRow In ds.Tables(0).Rows
                cmd2.CommandText = "Update MASTER_ITEM Set ITEM_OPN_QTY = " + CType(drow("BalanceAll"), String).Trim + " Where ITEM_CODE = '" + CType(drow("ITEM_CODE"), String).Trim + "'"
                cmd2.ExecuteNonQuery()
            Next

            TextBox4.Text = TextBox4.Text + vbNewLine + "Item Quantity Parsed Successfully."
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()
        Catch ex As Exception
            con.Close()
            TextBox4.Text = TextBox4.Text + vbNewLine + "Error Configuring Item Quantity..." + vbNewLine + "Aborting Year End Process." + vbNewLine + "Reason :" + ex.Message
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()
            Exit Sub
        End Try

        Try
            TextBox4.Text = TextBox4.Text + vbNewLine + "Fetching Item Costing..."
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd.CommandText = "select ITEM_CODE, CP from View_BalanceStockValuation"
            da.SelectCommand = cmd
            da.Fill(ds, "View_BalanceStockValuation")

            TextBox4.Text = TextBox4.Text + vbNewLine + "Configuring Item Costing..."
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()

            For Each drow As DataRow In ds.Tables(0).Rows
                cmd2.CommandText = "Update MASTER_ITEM Set Cost = " + CType(drow("CP"), String).Trim + ", OPNCOST = " + CType(drow("CP"), String).Trim + " Where ITEM_CODE = '" + CType(drow("ITEM_CODE"), String).Trim + "'"
                cmd2.ExecuteNonQuery()
            Next

            TextBox4.Text = TextBox4.Text + vbNewLine + "Item Costing Parsed Successfully."
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()
        Catch ex As Exception
            con.Close()
            TextBox4.Text = TextBox4.Text + vbNewLine + "Error Configuring Item Costing..." + vbNewLine + "Aborting Year End Process." + vbNewLine + "Reason :" + ex.Message
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()
            Exit Sub
        End Try

        Try
            TextBox4.Text = TextBox4.Text + vbNewLine + "Starting Database Renewal..."
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()

            cmd.CommandText = "Truncate Table CUSTOMER_RECIEPTS Truncate Table DummyBS Truncate Table DummyLS Truncate Table DummyPL Truncate Table DummyTB Truncate Table GRN_DETAIL Truncate Table GRN_HEADER Truncate Table IGN_DTLS Truncate Table IGN_HEADER Truncate Table IGNCostSheetDtls Truncate Table IGNCostSheetMain Truncate Table LETTER_OF_CREDIT Truncate Table LogDetails Truncate Table PROFORMA_DETAIL Truncate Table PROFORMA_HEADER Truncate Table PURCHASE_DETAIL Truncate Table PURCHASE_HEADER Truncate Table SALES_DETAIL Truncate Table SALES_HEADER Truncate Table VOUCHER_DETAIL Truncate Table VOUCHER_HEADER Truncate Table VOUCHER_ChequeDtls"
            cmd.ExecuteNonQuery()

            TextBox4.Text = TextBox4.Text + vbNewLine + "Completed Database Renewal..."
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()
        Catch ex As Exception
            con.Close()
            TextBox4.Text = TextBox4.Text + vbNewLine + "Error in Database Renewal..." + vbNewLine + "Aborting Year End Process." + vbNewLine + "Reason :" + ex.Message
            TextBox4.Refresh()
            TextBox4.ScrollToCaret()
            Exit Sub
        End Try

        TextBox4.Text = TextBox4.Text + vbNewLine + "Year End Process Completed Successfully."
        TextBox4.Refresh()
        TextBox4.ScrollToCaret()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
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

    Private Sub Button3_Click(sender As Object, e As EventArgs)
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