Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing

Public Class ChqPrnt

#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da, da2 As SqlDataAdapter
    Dim ds, ds2 As DataSet
    Dim iRec As Integer
    Dim pono As String

    Dim dtTable As New DataTable("Items")
    Private connectionString As [String] = Nothing
    Private sqlConnection As SqlConnection = Nothing
    Private sqlDataAdapter As SqlDataAdapter = Nothing
    Private sqlCommandBuilder As SqlCommandBuilder = Nothing
    Private dataTable As DataTable = Nothing
    Private bindingSource As BindingSource = Nothing
    Private selectQueryString As [String] = Nothing
    Dim flag As Boolean
    Dim AccessVerify As New VerifyAccess
    Dim aryBarCode() As String

#End Region
    Private Sub Me_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.SendWait("{TAB}")
        End If

        If e.Alt And e.KeyCode = Keys.S Then
            Button1.PerformClick()
        ElseIf e.Alt And e.KeyCode = Keys.P Then
            Button1.PerformClick()
        ElseIf e.Alt And e.KeyCode = Keys.A Then
            Button4.PerformClick()
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

    Public Sub LoadGrid2()
        Try
            If RadioButton3.Checked = True Then
                cmd.CommandText = "Select BName, Convert(varchar, CDate, 106) As CDate, ChqNo, PayTo, Amnt From View_Voucher_ChequeDtls Where JVRef = " + txtJVRef.Text + " Order By SrNo Desc"
            ElseIf RadioButton2.Checked = True Then
                cmd.CommandText = "Select BName, Convert(varchar, CDate, 106) As CDate, ChqNo, PayTo, Amnt From View_Voucher_ChequeDtls Where BID = " + cbBank.SelectedValue.ToString + " Order By SrNo Desc"
            Else
                cmd.CommandText = "Select BName, Convert(varchar, CDate, 106) As CDate, ChqNo, PayTo, Amnt From View_Voucher_ChequeDtls Where SplrRef = '" + cbPayTo.SelectedValue.ToString + "' Order By SrNo Desc"
            End If

            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds)
            DataGridView2.ClearSelection()
            DataGridView2.DataSource = ds.Tables(0)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub LoadItemData(Condition As Boolean)
        DataGridView1.Columns.Clear()
        conn()

        'DataGridView Source
        If Condition = False Then
            cmd.CommandText = "Select Srno, BName, Convert(varchar, CDate, 106) As CDate, ChqNo, PayTo, Amnt, JVRef, Dtls From View_Voucher_ChequeDtls Where Cncld = 0"
        Else
            cmd.CommandText = "Select SrNo, BName, Convert(varchar, CDate, 106) As CDate, ChqNo, PayTo, Amnt, JVRef, Dtls From View_Voucher_ChequeDtls Where Cncld = 0 and ChqNo = '" + txtSearch.Text + "' or Convert(varchar, CDate, 106) Like '%" + txtSearch.Text + "%' Or BName Like '%" + txtSearch.Text + "%' Or PayTo Like '%" + txtSearch.Text + "%' Or convert(varchar(20),Amnt) = '" + txtSearch.Text + "' Or convert(varchar(20),JVRef) = '" + txtSearch.Text + "') Order By SrNo Desc"
        End If

        da = New SqlDataAdapter(cmd)
        dataTable = New DataTable()
        da.Fill(dataTable)
        bindingSource = New BindingSource()
        bindingSource.DataSource = dataTable

        'Adding  SrNO TextBox
        Dim ColumnBName As New DataGridViewTextBoxColumn()
        ColumnBName.Name = "BName"
        ColumnBName.HeaderText = "BName"
        ColumnBName.ReadOnly = True
        ColumnBName.DataPropertyName = "BName"
        DataGridView1.Columns.Add(ColumnBName)

        'Adding  RCDate TextBox
        Dim ColumnCDate As New DataGridViewTextBoxColumn()
        ColumnCDate.Name = "CDate"
        ColumnCDate.HeaderText = "CDate"
        ColumnCDate.ReadOnly = True
        ColumnCDate.DataPropertyName = "CDate"
        DataGridView1.Columns.Add(ColumnCDate)

        'Adding  CName TextBox
        Dim ColumnChqNo As New DataGridViewTextBoxColumn()
        ColumnChqNo.Name = "ChqNo"
        ColumnChqNo.HeaderText = "ChqNo"
        ColumnChqNo.Width = 70
        ColumnChqNo.ReadOnly = True
        ColumnChqNo.DataPropertyName = "ChqNo"
        DataGridView1.Columns.Add(ColumnChqNo)

        'Adding  Mode TextBox
        Dim ColumnPayTo As New DataGridViewTextBoxColumn()
        ColumnPayTo.Name = "PayTo"
        ColumnPayTo.HeaderText = "PayTo"
        ColumnPayTo.Width = 70
        ColumnPayTo.ReadOnly = True
        ColumnPayTo.DataPropertyName = "PayTo"
        DataGridView1.Columns.Add(ColumnPayTo)

        'Adding  Amnt TextBox
        Dim ColumnAmnt As New DataGridViewTextBoxColumn()
        ColumnAmnt.Name = "Amnt"
        ColumnAmnt.HeaderText = "Amnt"
        ColumnAmnt.Width = 70
        ColumnAmnt.ReadOnly = True
        ColumnAmnt.DataPropertyName = "Amnt"
        DataGridView1.Columns.Add(ColumnAmnt)

        'Adding  Remarks TextBox
        Dim ColumnRemarks As New DataGridViewTextBoxColumn()
        ColumnRemarks.Name = "Dtls"
        ColumnRemarks.HeaderText = "REMARKS"
        ColumnRemarks.Width = 70
        ColumnRemarks.ReadOnly = True
        ColumnRemarks.DataPropertyName = "Dtls"
        DataGridView1.Columns.Add(ColumnRemarks)

        'Adding  RecvBy TextBox
        Dim ColumnJVRef As New DataGridViewTextBoxColumn()
        ColumnJVRef.Name = "JVRef"
        ColumnJVRef.HeaderText = "JVRef"
        ColumnJVRef.Width = 70
        ColumnJVRef.ReadOnly = True
        ColumnJVRef.DataPropertyName = "JVRef"
        DataGridView1.Columns.Add(ColumnJVRef)

        'Adding  Reprint Button
        Dim ColumnReprint As New DataGridViewButtonColumn()
        ColumnReprint.Name = "Reprint"
        ColumnReprint.HeaderText = "Reprint"
        ColumnReprint.Width = 45
        ColumnReprint.Text = "Reprint"
        ColumnReprint.UseColumnTextForButtonValue = True
        DataGridView1.Columns.Add(ColumnReprint)

        'Adding  Cancel Button
        Dim ColumnCancel As New DataGridViewButtonColumn()
        ColumnCancel.Name = "Cancel"
        ColumnCancel.HeaderText = "Cancel"
        ColumnCancel.Width = 45
        ColumnCancel.Text = "Cancel"
        ColumnCancel.UseColumnTextForButtonValue = True
        DataGridView1.Columns.Add(ColumnCancel)

        'Adding  SrNO TextBox
        Dim ColumnSrno As New DataGridViewTextBoxColumn()
        ColumnSrno.Name = "Srno"
        ColumnSrno.HeaderText = "Srno"
        ColumnSrno.ReadOnly = True
        ColumnSrno.Visible = False
        ColumnSrno.DataPropertyName = "Srno"
        DataGridView1.Columns.Add(ColumnSrno)

        DataGridView1.DataSource = bindingSource
        con.Close()
    End Sub

    Public Sub ClearAll()
        txtJVRef.Text = ""
        txtRmrks.Text = ""
        cbBank.SelectedIndex = -1
        txtchqNo.Text = ""
        txtAmnt.Text = "0"
        LoadItemData(False)
        cbPayTo.Items.Clear()
    End Sub

    Private Sub CustRcpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        'AddRows()
        conn()
        cmd.CommandText = "Select * From MASTER_BANK Where Active = 1"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "MASTER_BANK")
        cbBank.DisplayMember = "BName"
        cbBank.ValueMember = "BID"
        cbBank.DataSource = ds.Tables("MASTER_BANK")
        con.Close()

        ClearAll()
        AccessVerify.LoadingFrm(False)
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim EmailMode As String = ""
        Try
            Dim RCNo, SplrID As String

            conn()
            If cbPayTo.SelectedValue = Nothing Then
                SplrID = ""
            Else
                SplrID = cbPayTo.SelectedValue.ToString
            End If
            cmd.CommandText = "Insert Into VOUCHER_ChequeDtls Values ((Select COALESCE((Select Top 1 SrNo + 1 From VOUCHER_ChequeDtls Order By SrNo Desc),1)), " + cbBank.SelectedValue.ToString + ", " + txtJVRef.Text + ", '" + txtchqNo.Text + "', '" + dtpdate.Value + "', '" + SplrID + "', '" + cbPayTo.Text + "', " + txtAmnt.Text + ", '" + txtRmrks.Text + "', 0, GetDate(), Null)"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "Select Top 1 SrNo From VOUCHER_ChequeDtls Order By SrNo Desc"
            dr = cmd.ExecuteReader
            If dr.Read Then
                RCNo = CType(dr("SrNo"), String).Trim
            Else
                RCNo = "1"
            End If
            dr.Close()

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd.CommandText = "Select * from VOUCHER_ChequeDtls where SrNo = " + RCNo + ""
            da.SelectCommand = cmd
            da.Fill(ds, "VOUCHER_ChequeDtls")

            If cbBank.SelectedValue.ToString = 1 Then
                Dim Cr As New BankKFH
                AccessVerify.LoadReports(Cr, ds)
            ElseIf cbBank.SelectedValue.ToString = 2 Then
                Dim Cr As New BankAhli
                AccessVerify.LoadReports(Cr, ds)
            End If

            txtSearch.Text = ""

            con.Close()
            ClearAll()
            'AccessVerify.NotifyChanges(Me.Name.ToString, "Add", RCNo)
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Panel1.Visible = True Then
            Panel1.Visible = False
            Button4.Text = "View All Cheques"
        Else
            Panel1.Visible = True
            Button4.Text = "Hide All Cheques"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadItemData(True)
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged
        conn()
        LoadGrid2()
        con.Close()
    End Sub

    Private Sub txtrefno_TextChanged(sender As Object, e As EventArgs) Handles txtJVRef.TextChanged
        Try
            RadioButton3.Text = "Cheques for JV:" + txtJVRef.Text
            conn()
            cmd.CommandText = "Select Distinct SL_Code, SL_BankACName From View_Voucher_Dtls Where VOUCHER_NO = " + txtJVRef.Text + " and SL_Code <> '0' and SL_BankACName Is Not Null And Sl_Code In (Select SL_Code From View_Master_Supplier)"
            da = New SqlDataAdapter(cmd)
            da.Fill(ds, "View_Voucher_Dtls")
            cbPayTo.DisplayMember = "SL_BankACName"
            cbPayTo.ValueMember = "SL_Code"
            cbPayTo.DataSource = ds.Tables("View_Voucher_Dtls")
            con.Close()
            If cbPayTo.Items.Count = 0 Then
                MsgBox("No JV OR Supplier reference exist on mentioned JV No.")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles DataGridView1.UserDeletingRow
        Try
            If MsgBox("Are you sure you want to Cancel !", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                conn()
                cmd.CommandText = "Update VOUCHER_ChequeDtls Set CnclDT = GetDate(), Cncld = 1 Where SrNo = " + e.Row.Cells("SrNo").Value.ToString + ""
                cmd.ExecuteNonQuery()
                con.Close()

                If txtSearch.Text = "" Then
                    LoadItemData(False)
                Else
                    LoadItemData(True)
                End If
            End If
        Catch ex As Exception
        End Try
        e.Cancel = True
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = DataGridView1.Columns("Cancel").Index AndAlso e.RowIndex >= 0 Then
            Try
                If MsgBox("Are you sure you want to Cancel !", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                    conn()
                    cmd.CommandText = "Update VOUCHER_ChequeDtls Set CnclDT = GetDate(), Cncld = 1 Where SrNo = " + DataGridView1("SrNo", e.RowIndex).Value.ToString + ""
                    cmd.ExecuteNonQuery()
                    con.Close()

                    If txtSearch.Text = "" Then
                        LoadItemData(False)
                    Else
                        LoadItemData(True)
                    End If
                End If
            Catch ex As Exception
            End Try
        ElseIf e.ColumnIndex = DataGridView1.Columns("Reprint").Index AndAlso e.RowIndex >= 0 Then
            conn()
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd.CommandText = "Select * from VOUCHER_ChequeDtls where SrNo = " + DataGridView1("SrNo", e.RowIndex).Value.ToString + ""
            da.SelectCommand = cmd
            da.Fill(ds, "VOUCHER_ChequeDtls")

            If DataGridView1("BName", e.RowIndex).Value.ToString = "Kuwait Finance House" Then
                Dim Cr As New BankKFH
                AccessVerify.LoadReports(Cr, ds)
            ElseIf DataGridView1("BName", e.RowIndex).Value.ToString = "Ahli United Bank" Then
                Dim Cr As New BankAhli
                AccessVerify.LoadReports(Cr, ds)
            End If
            con.Close()
        End If
    End Sub

    Private Sub txtAmnt_LostFocus(sender As Object, e As EventArgs) Handles txtAmnt.LostFocus
        Try
            txtAmnt.Text = [String].Format("{0:0.000}", txtAmnt.Text)
        Catch ez As Exception
        End Try
    End Sub
End Class