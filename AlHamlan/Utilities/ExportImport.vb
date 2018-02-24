Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.Office.Interop

Public Class ExportImport

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

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        Dim fdlg As New OpenFileDialog()
        fdlg.Title = "Select file"
        fdlg.InitialDirectory = "c:\"
        fdlg.FileName = TextBox1.Text
        fdlg.Multiselect = False
        fdlg.Filter = "Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*"
        fdlg.FilterIndex = 1
        fdlg.RestoreDirectory = True
        If fdlg.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = fdlg.FileName
            Import()
            Application.DoEvents()
        End If
    End Sub

    Private Sub Import()
        Dim theConnection As OleDb.OleDbConnection
        Try
            theConnection = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = '" + TextBox1.Text + "'; Extended Properties = ""Excel 8.0;HDR=Yes;IMEX=1"";")
            theConnection.Open()
            Dim theDataAdapter As New OleDb.OleDbDataAdapter("SELECT * FROM [Sheet1$]", theConnection)
            Dim theDS As New DataSet()
            Dim dt As New DataTable()
            theDataAdapter.Fill(dt)
            Me.DataGridView1.DataSource = dt.DefaultView
        Catch ex As Exception
            theConnection = New OleDb.OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source = '" + TextBox1.Text + "'; Extended Properties = ""Excel 12.0;HDR=Yes;IMEX=1"";")
            theConnection.Open()
            Dim theDataAdapter As New OleDb.OleDbDataAdapter("SELECT * FROM [Sheet1$]", theConnection)
            Dim theDS As New DataSet()
            Dim dt As New DataTable()
            theDataAdapter.Fill(dt)
            Me.DataGridView1.DataSource = dt.DefaultView
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("Are you sure you want to CLEAR DATA !" + vbNewLine + "THIS CANT ROLLBACK", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
            Try
                conn()
                cmd.CommandText = "BACKUP DATABASE AlHamlan TO  DISK = 'D:\AlHamlan_DB_BackUp\" + Format(Date.Now, "dd-MMM-yyyy hh-mm-ss") + " " + MainMDI.LblInitials.Text + " " + "CD-" + ComboBox1.Text + ".bak '"
                cmd.ExecuteNonQuery()

                If ComboBox1.Text = "Items" Then
                    cmd.CommandText = "Truncate Table MASTER_ITEM"
                ElseIf ComboBox1.Text = "Customers" Then
                    cmd.CommandText = "Truncate Table CUSTOMER_MASTER"
                ElseIf ComboBox1.Text = "Suppliers" Then
                    cmd.CommandText = "Delete From MASTER_SUBLEDGER Where SL_ACC_TYPE = N'AP'"
                Else
                    MsgBox("Select Proper Module To Proceed.", MsgBoxStyle.Information, "H.F. General Trading CO.")
                    con.Close()
                    Exit Sub
                End If
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Previuos Data Cleared Successfully", MsgBoxStyle.Information, "H.F. General Trading CO.")
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
            End Try
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        'Try
        If DataGridView1.RowCount < 1 Then
                MsgBox("No Data To Upload", MsgBoxStyle.Information, "H.F. General Trading CO.")
                Exit Sub
            End If
            conn()
            AccessVerify.LoadingFrm(True)
            cmd.CommandText = "BACKUP DATABASE AlHamlan TO  DISK = 'D:\AlHamlan_DB_BackUp\" + Format(Date.Now, "dd-MMM-yyyy hh-mm-ss") + " " + MainMDI.LblInitials.Text + " " + "UP-" + ComboBox1.Text + ".bak '"
            cmd.ExecuteNonQuery()

            For Each row As DataGridViewRow In DataGridView1.Rows
                If ComboBox1.Text = "Items" Then
                    cmd.CommandText = "Insert Into MASTER_ITEM (ITEM_CODE, ITEM_DESC, ITM_TERMS, DIV_CODE, ITEM_PRICE, COST, OPNCOST, PRVCOST, ITEM_FR_PRICE, ITEM_OPN_QTY, ITEM_AUNIT) Values (N'" + CType((row.Cells("ITEM_CODE").FormattedValue), String).Trim + "', N'" + CType((row.Cells("ITEM_DESC").FormattedValue), String).Trim + "', N'" + CType((row.Cells("ITM_TERMS").FormattedValue), String).Trim + "', N'" + CType((row.Cells("DIV_CODE").FormattedValue), String).Trim + "', " + CType((row.Cells("ITEM_PRICE").FormattedValue), String).Trim + ", " + CType((row.Cells("COST").FormattedValue), String).Trim + ", " + CType((row.Cells("COST").FormattedValue), String).Trim + ", " + CType((row.Cells("COST").FormattedValue), String).Trim + ", " + CType((row.Cells("COST").FormattedValue), String).Trim + ", " + CType((row.Cells("ITEM_OPN_QTY").FormattedValue), String).Trim + ", N'" + CType((row.Cells("ITEM_AUNIT").FormattedValue), String).Trim + "')"
                ElseIf ComboBox1.Text = "Customers" Then
                    cmd.CommandText = "Insert Into CUSTOMER_MASTER (CUST_CODE, CUST_NAME, CUST_TEL, CUST_FAX, CUST_EMAIL, CUST_CONTACT, CUST_ADD, CUST_OPEN_BALANCE) Values (" + CType((row.Cells("CUST_CODE").FormattedValue), String).Trim + ", N'" + CType((row.Cells("CUST_NAME").FormattedValue), String).Trim + "', '" + CType((row.Cells("CUST_TEL").FormattedValue), String).Trim + "', '" + CType((row.Cells("CUST_FAX").FormattedValue), String).Trim + "', '" + CType((row.Cells("CUST_EMAIL").FormattedValue), String).Trim + "', N'" + CType((row.Cells("CUST_CONTACT").FormattedValue), String).Trim + "', N'" + CType((row.Cells("CUST_ADD").FormattedValue), String).Trim + "', " + CType((row.Cells("CUST_OPEN_BALANCE").FormattedValue), String).Trim + ")"
                ElseIf ComboBox1.Text = "Suppliers" Then
                    cmd.CommandText = "Insert Into MASTER_SUBLEDGER (SrNo, SL_ACC_TYPE, SL_GL_CODE, SL_CODE, SL_NAME, SL_BankACName, SL_TEL, SL_FAX, SL_EMAIL, SL_CONTACT, SL_ADD, SL_KD_OPEN_BALANCE, SL_USER) Values ((Select COALESCE((Select Top 1 SrNo + 1 From MASTER_SUBLEDGER Order By SrNo Desc),1)), N'AP', '251', N'" + CType((row.Cells("SL_CODE").FormattedValue), String).Trim + "', N'" + CType((row.Cells("SL_NAME").FormattedValue), String).Trim + "', N'" + CType((row.Cells("SL_BankACName").FormattedValue), String).Trim + "', N'" + CType((row.Cells("SL_TEL").FormattedValue), String).Trim + "', N'" + CType((row.Cells("SL_FAX").FormattedValue), String).Trim + "', N'" + CType((row.Cells("SL_EMAIL").FormattedValue), String).Trim + "', N'" + CType((row.Cells("SL_CONTACT").FormattedValue), String).Trim + "', N'" + CType((row.Cells("SL_ADD").FormattedValue), String).Trim + "', " + CType((row.Cells("SL_KD_OPEN_BALANCE").FormattedValue), String).Trim + ", " + MainMDI.lblUID.Text + ")"
                Else
                    MsgBox("Select Proper Module To Proceed.", MsgBoxStyle.Information, "H.F. General Trading CO.")
                    con.Close()
                    AccessVerify.LoadingFrm(False)
                    Exit Sub
                End If
                cmd.ExecuteNonQuery()
            Next
            If ComboBox1.Text = "Items" Then
                cmd.CommandText = "Update Master_GenLedger Set GL_KD_OPEN = (Select Sum(ITEM_OPN_QTY*COST) From MASTER_ITEM) Where GL_CODE = '200-000'"
            ElseIf ComboBox1.Text = "Suppliers" Then
                cmd.CommandText = "Update Master_GenLedger Set GL_KD_OPEN = (Select Sum(SL_KD_OPEN_BALANCE) From View_Master_Supplier) Where GL_CODE = '251'"
            ElseIf ComboBox1.Text = "Customers" Then
                cmd.CommandText = "Update Master_GenLedger Set GL_KD_OPEN = (Select Sum(CUST_OPEN_BALANCE) From CUSTOMER_MASTER) Where GL_CODE = '199-000'"
            End If
            cmd.ExecuteNonQuery()
            MsgBox("Upload Completed Successfully", MsgBoxStyle.Information, "H.F. General Trading CO.")
            con.Close()
            AccessVerify.LoadingFrm(False)
        'Catch ex As Exception
        '    AccessVerify.LoadingFrm(False)
        '    con.Close()
        '    MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
        'End Try
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        conn()
        If ComboBox1.Text = "Items" Then
            cmd.CommandText = "Select ITEM_CODE, ITEM_DESC, ITM_TERMS, DIV_CODE, ITEM_PRICE, COST, ITEM_OPN_QTY, ITEM_AUNIT, (Select BalanceAll From View_StockStatusLIVE Where Item_Code = T1.Item_Code) From MASTER_ITEM T1 Order By ITEM_CODE"
        ElseIf ComboBox1.Text = "Customers" Then
            cmd.CommandText = "Select CUST_CODE, CUST_NAME, CUST_TEL, CUST_FAX, CUST_EMAIL, CUST_CONTACT, CUST_ADD, CUST_OPEN_BALANCE From CUSTOMER_MASTER T1 order By CUST_CODE"
        ElseIf ComboBox1.Text = "Suppliers" Then
            cmd.CommandText = "Select SL_CODE, SL_NAME, SL_BankACName, SL_TEL, SL_FAX, SL_EMAIL, SL_CONTACT, SL_ADD, SL_KD_OPEN_BALANCE From View_Master_Supplier T1 order By SL_CODE"
        End If
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "T1")

        Dim objDlg As New SaveFileDialog
        objDlg.Filter = "Excel File|*.xls"
        objDlg.OverwritePrompt = False
        If objDlg.ShowDialog = DialogResult.OK Then
            Dim filepath As String = objDlg.FileName
            AccessVerify.LoadingFrm(True)
            AccessVerify.ExportToExcel(ds.Tables("T1"), filepath)
        End If
        con.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        DataGridView1.DataSource = Nothing
        TextBox1.Text = ""
    End Sub
End Class