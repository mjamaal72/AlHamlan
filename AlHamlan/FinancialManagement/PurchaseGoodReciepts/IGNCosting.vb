Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine

Public Class IGNCosting

#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da, da2 As SqlDataAdapter
    Dim ds, ds2 As DataSet
    Dim iRec As Integer
    
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
#End Region
    Private Sub Me_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.SendWait("{TAB}")
        End If

        If e.Alt And e.KeyCode = Keys.S Then
            Button1.PerformClick()
        ElseIf e.Alt And e.KeyCode = Keys.P Then
            Button3.PerformClick()
        ElseIf e.Alt And e.KeyCode = Keys.X Then
            Button4.PerformClick()
        ElseIf e.Alt And e.KeyCode = Keys.C Then
            Button5.PerformClick()
        ElseIf e.Alt And e.KeyCode = Keys.E Then
            Button2.PerformClick()
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

    Private Function CellSum(cname As String) As Double
        Dim sum As Double = 0
        Try
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                Dim d As Double = 0
                [Double].TryParse(DataGridView1.Rows(i).Cells(cname).Value.ToString(), d)
                sum += d
            Next
        Catch ex As Exception
        End Try
        Return sum
    End Function

    Public Sub CntAmnt()
        txtcosttotal.Text = [String].Format("{0:0.000}", CellSum("Amnt"))
    End Sub

    Public Sub LoadItemData(CSNO As String, editmode As Boolean)
        DataGridView1.Columns.Clear()
        Dim abc As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLibrary.dll")
        connectionString = abc
        sqlConnection = New SqlConnection(connectionString)
        sqlConnection.Open()

        'DataGridView Source
        selectQueryString = "Select SrNo, Loc_Code, Amnt from View_IGNCSDtls WHERE CSNo = " + CSNO + " Order By SrNo"
        sqlDataAdapter = New SqlDataAdapter(selectQueryString, sqlConnection)
        sqlCommandBuilder = New SqlCommandBuilder(sqlDataAdapter)
        dataTable = New DataTable()
        sqlDataAdapter.Fill(dataTable)
        bindingSource = New BindingSource()
        bindingSource.DataSource = dataTable

        'Item Data Source
        Dim selectQueryStringItem As String = "SELECT LOC_CODE As LCode, LOC_DESC From LOCAL_EXPENSE_MASTER Order By LOC_CODE"
        Dim sqlDataAdapterItem As New SqlDataAdapter(selectQueryStringItem, sqlConnection)
        Dim sqlCommandBuilderItem As New SqlCommandBuilder(sqlDataAdapterItem)
        Dim dataTableItem As New DataTable()
        sqlDataAdapterItem.Fill(dataTableItem)
        Dim bindingSourceItem As New BindingSource()
        bindingSourceItem.DataSource = dataTableItem

        'Adding  Item Combo
        Dim ColumnItem As New DataGridViewComboBoxColumn()
        ColumnItem.Name = "Item"
        ColumnItem.DataPropertyName = "Loc_Code"
        ColumnItem.HeaderText = "Expense Type"
        ColumnItem.Width = 450
        ColumnItem.DataSource = bindingSourceItem
        ColumnItem.ValueMember = "LCODE"
        ColumnItem.DisplayMember = "LOC_DESC"
        ColumnItem.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        DataGridView1.Columns.Add(ColumnItem)

        'Adding  Net TextBox
        Dim ColumnNet As New DataGridViewTextBoxColumn()
        ColumnNet.Name = "Amnt"
        ColumnNet.HeaderText = "Amnt"
        ColumnNet.Width = 100
        ColumnNet.DataPropertyName = "Amnt"
        DataGridView1.Columns.Add(ColumnNet)

        'Adding  SrNO TextBox
        Dim ColumnSrNo As New DataGridViewTextBoxColumn()
        ColumnSrNo.Name = "SrNo"
        ColumnSrNo.HeaderText = "SrNo"
        ColumnSrNo.Visible = False
        ColumnSrNo.DataPropertyName = "SrNo"
        DataGridView1.Columns.Add(ColumnSrNo)

        DataGridView1.DataSource = bindingSource

        sqlConnection.Close()
        CntAmnt()
    End Sub

    Public Sub GridRowSelect()
        Try
            If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Update") = False Then
                Button1.Visible = False
            Else
                Button1.Visible = True
            End If
            LoadItemData(txtcostno.Text, True)
            conn()
            cmd.CommandText = "Select * From View_IGNCSMain Where CSNo = '" + txtcostno.Text + "'"
            dr = cmd.ExecuteReader
            If dr.Read Then
                Button1.Text = "Update Selected CS"
                txtcostno.Text = CType(dr("CSNo"), String).Trim
                dtpdate.Value = CType(dr("Rec_Date"), String).Trim
                If CType(dr("POSTED"), String).Trim = "T" Then
                    chbposted.Checked = True
                Else
                    chbposted.Checked = False
                End If
                cbign.Items.Clear()
                cbign.Text = CType(dr("IGNNo"), String).Trim
                cbign.Enabled = False
                txtsuplr.Text = CType(dr("SL_Name"), String).Trim
                txtignnet.Text = CType(dr("Net"), String).Trim
                txtignchrgs.Text = CType(dr("REC_FOOT_CHARGES"), String).Trim
                txtpono.Text = CType(dr("PUR_NO"), String).Trim
                txtinvno.Text = CType(dr("INVOICE_NO"), String).Trim
                txtinvdate.Text = CType(dr("InvDate"), String).Trim
                txtigndate.Text = CType(dr("IGNDate"), String).Trim
                txtigngross.Text = CType(dr("Gross"), String).Trim
                txtigndisc.Text = CType(dr("REC_FOOT_DISC"), String).Trim
                txtignadj.Text = CType(dr("REC_FOOT_ADJUST"), String).Trim
            End If
            dr.Close()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
        End Try
    End Sub

    Public Sub ClearAll()
        If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Add") = False Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
        Button1.Text = "Add New CS"
        txtcostno.Text = "Auto Number"
        txtsuplr.Text = ""
        cbign.Enabled = True
        txtignchrgs.Text = "0"
        dtpdate.Value = Date.Now
        chbposted.Checked = False
        txtcosttotal.Text = "0"
        txtignnet.Text = "0"
        txtpono.Text = ""
        txtigndate.Text = ""
        txtinvno.Text = ""
        txtinvdate.Text = ""
        txtigngross.Text = ""
        txtigndisc.Text = ""
        txtignadj.Text = ""

        conn()
        cmd.CommandText = "Select Distinct IGN_NO from IGN_HEADER Where IGN_NO Not In (Select distinct IGNNo From IGNCostSheetMain) Order By IGN_NO"
        dr = cmd.ExecuteReader
        While dr.Read
            cbign.Items.Add(CType(dr("IGN_NO"), String).Trim)
        End While
        dr.Close()
        AddHandler cbign.SelectedIndexChanged, AddressOf cbign_SelectedIndexChanged
        AddHandler cbign.TextChanged, AddressOf cbign_TextChanged
        con.Close()
        cbign.SelectedIndex = -1

        LoadItemData(0, False)
    End Sub

    Private Sub ME_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        ClearAll()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SrNo As String = ""
        Dim EmailMode As String = ""
        Try
            Dim Pstsd, CSID, Cncled As String
            If chbposted.Checked = True Then
                Pstsd = "T"
            Else
                Pstsd = "F"
            End If

            conn()
            If MsgBox("This will update CHARGES Field in selected IGN." & vbNewLine & "Do you want to proceed ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                cmd.CommandText = "Update IGN_HEADER Set REC_FOOT_CHARGES = " + txtcosttotal.Text + " Where IGN_No = " + cbign.Text + ""
                cmd.ExecuteNonQuery()
            Else
                con.Close()
                Exit Sub
            End If

            If Button1.Text = "Add New CS" Then
                cmd.CommandText = "Insert Into IGNCostSheetMain Values ((Select COALESCE((Select Top 1 CSNo + 1 From IGNCostSheetMain Order By CSNo Desc),1)), '" + cbign.Text + "', '" + dtpdate.Value + "', 'T')"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "Select Top 1 CSNo From IGNCostSheetMain Order By CSNo Desc"
                dr = cmd.ExecuteReader
                If dr.Read Then
                    CSID = CType(dr("CSNo"), String).Trim
                Else
                    CSID = "1"
                End If
                dr.Close()

                Try
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        cmd.CommandText = "Insert Into IGNCostSheetDtls Values ((Select COALESCE((Select Top 1 SrNo + 1 From IGNCostSheetDtls Order By SrNo Desc),1)), " + CSID + ", '" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', " + DataGridView1.Rows(i).Cells("Amnt").Value.ToString + ")"
                        cmd.ExecuteNonQuery()
                    Next
                Catch ez As Exception
                End Try
                EmailMode = "Add"
                MsgBox("New Cost Sheet Added Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            Else
                cmd.CommandText = "Update IGNCostSheetMain Set CSDate='" + dtpdate.Value + "', POSTED='" + Pstsd + "' Where CSNo = " + txtcostno.Text + ""
                cmd.ExecuteNonQuery()

                Try
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        If DataGridView1.Rows(i).Cells("SrNo").Value.ToString = "" Then
                            cmd.CommandText = "Insert Into IGNCostSheetDtls Values ((Select COALESCE((Select Top 1 SrNo + 1 From IGNCostSheetDtls Order By SrNo Desc),1)), " + txtcostno.Text + ", '" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', " + DataGridView1.Rows(i).Cells("Amnt").Value.ToString + ")"
                        Else
                            cmd.CommandText = "Update IGNCostSheetDtls Set Loc_CODE='" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', Amnt=" + DataGridView1.Rows(i).Cells("Amnt").Value.ToString + " Where SrNo=" + DataGridView1.Rows(i).Cells("SrNo").Value.ToString + ""
                        End If
                        cmd.ExecuteNonQuery()
                    Next
                Catch ez As Exception
                End Try
                EmailMode = "Update"
                SrNo = txtcostno.Text
                MsgBox("Selected Cost Sheet Updated Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            End If
            ClearAll()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
        End Try
        If EmailMode <> "" Then
            AccessVerify.NotifyChanges(Me.Name.ToString, EmailMode, SrNo)
        End If
        LoadItemData(0, False)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AccessVerify.LoadingFrm(True)

        'conn()
        'Dim da As New SqlDataAdapter
        'Dim ds As New DataSet
        'cmd.CommandText = "Select * from View_GRN_Main where GRN_No = " + txtcostno.Text + ""
        'da.SelectCommand = cmd
        'da.Fill(ds, "View_GRN_Main")
        'cmd.CommandText = "Select * from View_GRN_Dtls where GRN_No = " + txtcostno.Text + ""
        'da.SelectCommand = cmd
        'da.Fill(ds, "View_GRN_Dtls")

        'Dim cr As New GRNRep
        'AccessVerify.LoadReports(cr, ds, MainMDI.lblFrmDtls.Text)

        'cmd.CommandText = "Update GRN_HEADER Set GRN_PRINTED = GetDate() Where  GRN_No = " + txtcostno.Text + ""
        'cmd.ExecuteNonQuery()
        'con.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AccessVerify.LoadSrchGrid("Search IGN Cost Sheet", "Select CSNo, CSDate, Convert(Varchar(max),IGNNo)+'(Net: '+Convert(Varchar(max),Net)+' | Charges: '+Convert(Varchar(max),REC_FOOT_CHARGES)+')' As IGNDtls, SL_Name As Supplier, CSTotal, POSTED As Posted from View_IGNCSMain Order By CSNo DESC", Me.Name, True, "CSNo", "txtcostno")
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Try
            DataGridView1("Amnt", e.RowIndex).Value = [String].Format("{0:0.000}", DataGridView1("Amnt", e.RowIndex).Value)
        Catch ez As Exception
        End Try
        Try
            CntAmnt()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles DataGridView1.UserDeletingRow
        If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Delete") = False Then
            MsgBox("You dont have access to delete.", MsgBoxStyle.Critical)
            e.Cancel = True
            Exit Sub
        End If
        Try
            If MsgBox("Are you sure you want to Delete !", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                Dim eno As String = e.Row.Cells("SrNo").Value.ToString
                conn()
                If Button1.Text <> "Add New CS" Then
                    Try
                        For i As Integer = 0 To DataGridView1.Rows.Count - 1
                            If DataGridView1.Rows(i).Cells("SrNo").Value.ToString = "" Then
                                cmd.CommandText = "Insert Into IGNCostSheetDtls Values ((Select COALESCE((Select Top 1 SrNo + 1 From IGNCostSheetDtls Order By SrNo Desc),1)), " + txtcostno.Text + ", '" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', " + DataGridView1.Rows(i).Cells("Amnt").Value.ToString + ")"
                            Else
                                cmd.CommandText = "Update IGNCostSheetDtls Set Loc_CODE='" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', Amnt=" + DataGridView1.Rows(i).Cells("Amnt").Value.ToString + " Where SrNo=" + DataGridView1.Rows(i).Cells("SrNo").Value.ToString + ""
                            End If
                            cmd.ExecuteNonQuery()
                        Next
                    Catch ez As Exception
                    End Try
                End If

                cmd.CommandText = "Delete From IGNCostSheetDtls Where SrNo = " + eno + ""
                cmd.ExecuteNonQuery()
                con.Close()
                If eno <> "" Then
                    LoadItemData(txtcostno.Text, True)
                End If
                AccessVerify.NotifyChanges(Me.Name.ToString, "Delete", txtcostno.Text)
            End If
        Catch ex As Exception
        End Try
        e.Cancel = True
    End Sub

    Private Sub chbposted_CheckedChanged(sender As Object, e As EventArgs) Handles chbposted.CheckedChanged
        If chbposted.Checked = True Then
            Panel1.Enabled = False
            DataGridView1.ReadOnly = True
        Else
            Panel1.Enabled = True
            DataGridView1.ReadOnly = False
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ClearAll()
        LoadItemData(0, False)
    End Sub

    Private Sub DataGridView1_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridView1.UserDeletedRow
        CntAmnt()
    End Sub

    Protected Sub cbign_SelectedIndexChanged()
        If cbign.Text = "" Or Button1.Text = "Update Selected CS" Then
            Exit Sub
        End If

        Dim Pstd As String = ""
        If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Update") = False Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
        conn()
        cmd.CommandText = "Select * From View_IGN_Main Where IGN_No = " + cbign.Text + ""
        dr = cmd.ExecuteReader
        If dr.Read Then
            txtsuplr.Text = CType(dr("SL_Name"), String).Trim
            txtignnet.Text = CType(dr("Net"), String).Trim
            txtignchrgs.Text = CType(dr("REC_FOOT_CHARGES"), String).Trim
            txtpono.Text = CType(dr("PUR_NO"), String).Trim
            txtigndate.Text = CType(dr("IGNDate"), String).Trim
            txtinvno.Text = CType(dr("INVOICE_NO"), String).Trim
            txtinvdate.Text = CType(dr("INVOICE_DATE"), String).Trim
            txtigngross.Text = CType(dr("Gross"), String).Trim
            txtigndisc.Text = CType(dr("REC_FOOT_DISC"), String).Trim
            txtignadj.Text = CType(dr("REC_FOOT_ADJUST"), String).Trim
        End If
        con.Close()
    End Sub

    Protected Sub cbign_TextChanged()
        cbign_SelectedIndexChanged()
    End Sub

    Private Sub chbposted_Click(sender As Object, e As EventArgs) Handles chbposted.Click
        'Try
        '    If chbposted.CheckState = CheckState.Unchecked Then
        '        conn()
        '        cmd.CommandText = "Select Count(*) As cnt from GRN_HEADER Where GRN_NO = " + txtcostno.Text + " And GRN_Printed IS Null"
        '        dr = cmd.ExecuteReader
        '        dr.Read()
        '        Dim cnt As Integer = dr("cnt")
        '        dr.Close()
        '        con.Close()
        '        If cnt = 0 Then
        '            chbposted.Checked = True
        '            MsgBox("You cannot unpost this GRN as its already Printed.", MsgBoxStyle.Information, "H.F. General Trading CO.")
        '        End If
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Panel2.Visible = True Then
            Panel2.Visible = False
        Else
            Panel2.Visible = True
        End If
    End Sub

    Private Sub cbign_LostFocus(sender As Object, e As EventArgs) Handles cbign.LostFocus
        Try
            If cbign.Items.Contains(cbign.Text) = False And cbign.SelectedValue = Nothing Then
                cbign.SelectedValue = cbign.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtgrnno_TextChanged(sender As Object, e As EventArgs) Handles txtcostno.TextChanged
        If txtcostno.Text <> "Auto Number" Then
            DataGridView1.DataSource = Nothing
            GridRowSelect()
        End If
    End Sub
End Class