Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Imports DGMCCBD.Controls

Public Class JV

#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da, da2 As SqlDataAdapter
    Dim ds, ds2 As DataSet
    Dim iRec As Integer
    Dim VoucherID As String
    Dim dtTable As New DataTable("Items")
    Private connectionString As [String] = Nothing
    Private sqlConnection As SqlConnection = Nothing
    Private sqlDataAdapter As SqlDataAdapter = Nothing
    Private sqlCommandBuilder As SqlCommandBuilder = Nothing
    Private dataTable As DataTable = Nothing
    Private bindingSource As BindingSource = Nothing
    Private selectQueryString As [String] = Nothing
    Dim flag, flag2 As Boolean
    Dim AccessVerify As New VerifyAccess
    Dim WishedForCell As DataGridViewCell = Nothing
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
        ElseIf e.Alt And e.KeyCode = Keys.J Then
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

    Private Function CellSum(cname As String, mode As String) As Double
        Dim sum As Double = 0
        Try
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(i).Cells("Type").Value.ToString = mode Then
                    Dim d As Double = 0
                    [Double].TryParse(DataGridView1.Rows(i).Cells(cname).Value.ToString(), d)
                    sum += d
                End If
            Next
        Catch ex As Exception
        End Try
        Return sum
    End Function

    Public Sub CntAmnt()
        Dim c, d As Double
        c = CellSum("Amnt", "C")
        d = CellSum("Amnt", "D")
        txtdebit.Text = [String].Format("{0:0.000}", d)
        txtcredit.Text = [String].Format("{0:0.000}", c)
        txtdiff.Text = [String].Format("{0:0.000}", d - c)
    End Sub

    Public Sub LoadItemData(vid As String, editmode As Boolean)
        DataGridView1.Columns.Clear()
        DataGridView1.AutoGenerateColumns = False
        Dim abc As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLibrary.dll")
        connectionString = abc
        sqlConnection = New SqlConnection(connectionString)
        sqlConnection.Open()

        selectQueryString = "Select [ID] As SrNo, GL_CODE, SL_SrNo, VOU_DIV, REFERENCE_NO, NARRATION, TRAN_TYPE, AMNT from View_Voucher_Dtls WHERE VOUCHER_ID = " + vid + " Order By [ID]"
        sqlDataAdapter = New SqlDataAdapter(selectQueryString, sqlConnection)
        sqlCommandBuilder = New SqlCommandBuilder(sqlDataAdapter)
        dataTable = New DataTable()
        sqlDataAdapter.Fill(dataTable)
        bindingSource = New BindingSource()
        bindingSource.DataSource = dataTable

        'GLCode Data Source
        Dim selectQueryStringGlCode As String = "SELECT GL_CODE, GL_DESC FROM Master_GenLedger Where ACTIVE = 'T' Order By GL_DESC"
        Dim sqlDataAdapterGLCode As New SqlDataAdapter(selectQueryStringGlCode, sqlConnection)
        Dim sqlCommandBuilderGLCode As New SqlCommandBuilder(sqlDataAdapterGLCode)
        Dim dataTableGlCode As New DataTable()
        sqlDataAdapterGLCode.Fill(dataTableGlCode)
        Dim bindingSourceGLCode As New BindingSource()
        bindingSourceGLCode.DataSource = dataTableGlCode

        'SLCode Data Source
        Dim selectQueryStringSLCode As String = "SELECT SrNo, SL_NAME, SL_CODE FROM MASTER_SUBLEDGER Where SL_ACTIVE = 'T' Union Select 0, '', '' Order By SL_NAME"
        Dim sqlDataAdapterSLCode As New SqlDataAdapter(selectQueryStringSLCode, sqlConnection)
        Dim sqlCommandBuilderSLCode As New SqlCommandBuilder(sqlDataAdapterSLCode)
        Dim dataTableSLCode As New DataTable()
        sqlDataAdapterSLCode.Fill(dataTableSLCode)
        Dim bindingSourceSLCode As New BindingSource()
        bindingSourceSLCode.DataSource = dataTableSLCode

        'SLCode Data Source
        Dim selectQueryStringDIV As String = "SELECT DIV_CODE, DIV_DESC FROM MASTER_DIVISION Union Select '', '' Order By DIV_DESC"
        Dim sqlDataAdapterDIV As New SqlDataAdapter(selectQueryStringDIV, sqlConnection)
        Dim sqlCommandBuilderDIV As New SqlCommandBuilder(sqlDataAdapterDIV)
        Dim dataTableDIV As New DataTable()
        sqlDataAdapterDIV.Fill(dataTableDIV)
        Dim bindingSourceDIV As New BindingSource()
        bindingSourceDIV.DataSource = dataTableDIV

        'Type Data Source
        Dim selectQueryStringType As String = "WITH TransMode AS (SELECT 'C' As CodeType, 'Credit' As NameType Union SELECT 'D' As CodeType, 'Debit' As NameType) SELECT * from TransMode"
        Dim sqlDataAdapterType As New SqlDataAdapter(selectQueryStringType, sqlConnection)
        Dim sqlCommandBuilderType As New SqlCommandBuilder(sqlDataAdapterType)
        Dim dataTableType As New DataTable()
        sqlDataAdapterType.Fill(dataTableType)
        Dim bindingSourceType As New BindingSource()
        bindingSourceType.DataSource = dataTableType

        'Adding  GLCode Combo
        Dim ColumnGlCode As New DataGridViewMultiColumnComboBoxColumn
        ColumnGlCode.Name = "GLCode"
        ColumnGlCode.DataPropertyName = "GL_CODE"
        ColumnGlCode.HeaderText = "GLCode"
        ColumnGlCode.Width = 100
        ColumnGlCode.DataSource = bindingSourceGLCode
        ColumnGlCode.ValueMember = "GL_CODE"
        'ColumnGlCode.DisplayMember = "GL_DESC"
        ColumnGlCode.DisplayMember = "GL_CODE"
        ColumnGlCode.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        ColumnGlCode.AutoComplete = True
        ColumnGlCode.DropDownWidth = 600
        ColumnGlCode.ColumnNames.Add("GL_CODE")
        ColumnGlCode.ColumnNames.Add("GL_DESC")
        ColumnGlCode.ColumnWidths.Add("100")
        ColumnGlCode.ColumnWidths.Add("500")

        DataGridView1.Columns.Add(ColumnGlCode)

        'Adding  SLCode Combo
        Dim ColumnSlCode As New DataGridViewMultiColumnComboBoxColumn()
        ColumnSlCode.Name = "SLNAME"
        ColumnSlCode.DataPropertyName = "SL_SrNo"
        ColumnSlCode.HeaderText = "SLNAME"
        ColumnSlCode.Width = 100
        ColumnSlCode.DataSource = bindingSourceSLCode
        ColumnSlCode.ValueMember = "SrNo"
        ColumnSlCode.DisplayMember = "SL_CODE"
        'ColumnSlCode.DisplayMember = "SL_NAME"
        ColumnSlCode.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        ColumnSlCode.AutoComplete = True
        ColumnSlCode.DropDownWidth = 600
        ColumnSlCode.ColumnNames.Add("SL_CODE")
        ColumnSlCode.ColumnNames.Add("SL_NAME")
        ColumnSlCode.ColumnWidths.Add("100")
        ColumnSlCode.ColumnWidths.Add("500")
        DataGridView1.Columns.Add(ColumnSlCode)

        'Adding  DIV Combo
        Dim ColumnDIV As New DataGridViewComboBoxColumn()
        ColumnDIV.Name = "DIV"
        ColumnDIV.DataPropertyName = "VOU_DIV"
        ColumnDIV.HeaderText = "DIV"
        ColumnDIV.Width = 100
        ColumnDIV.DataSource = bindingSourceDIV
        ColumnDIV.ValueMember = "DIV_CODE"
        ColumnDIV.DisplayMember = "DIV_DESC"
        ColumnDIV.DropDownWidth = 150
        DataGridView1.Columns.Add(ColumnDIV)

        'Adding  Ref# TextBox
        Dim ColumnRef As New DataGridViewTextBoxColumn()
        ColumnRef.Name = "Ref"
        ColumnRef.HeaderText = "Ref"
        ColumnRef.Width = 120
        ColumnRef.DataPropertyName = "REFERENCE_NO"
        DataGridView1.Columns.Add(ColumnRef)

        'Adding  Narration TextBox
        Dim ColumnNar As New DataGridViewTextBoxColumn()
        ColumnNar.Name = "NARRATION"
        ColumnNar.HeaderText = "NARRATION"
        ColumnNar.Width = 380
        ColumnNar.DataPropertyName = "NARRATION"
        DataGridView1.Columns.Add(ColumnNar)

        'Adding  Type Combo
        Dim ColumnType As New DataGridViewComboBoxColumn()
        ColumnType.Name = "Type"
        ColumnType.DataPropertyName = "TRAN_TYPE"
        ColumnType.HeaderText = "Type"
        ColumnType.Width = 75
        ColumnType.DataSource = bindingSourceType
        ColumnType.ValueMember = "CodeType"
        ColumnType.DisplayMember = "NameType"
        DataGridView1.Columns.Add(ColumnType)

        'Adding  Price TextBox
        Dim ColumnPrc As New DataGridViewTextBoxColumn()
        ColumnPrc.Name = "AMNT"
        ColumnPrc.HeaderText = "AMNT"
        ColumnPrc.Width = 75
        ColumnPrc.DataPropertyName = "AMNT"
        ColumnPrc.DefaultCellStyle.NullValue = "0.000"
        DataGridView1.Columns.Add(ColumnPrc)

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
            LoadItemData(txtvid.Text, True)

            conn()
            cmd.CommandText = "Select * From View_Voucher_Main Where Voucher_ID = " + txtvid.Text + ""
            dr = cmd.ExecuteReader
            If dr.Read Then
                Button1.Text = "Update Selected JV"
                txtjvno.Text = CType(dr("VOUCHER_NO"), String).Trim
                txtnotes.Text = CType(dr("NOTES"), String).Trim
                cbcrncy.SelectedValue = CType(dr("VOU_CUR"), String).Trim
                dtpjvdate.Value = CType(dr("VOUCHER_DATE"), String).Trim
                If CType(dr("VOU_POSTED"), String).Trim = "T" Then
                    chbposted.Checked = True
                Else
                    chbposted.Checked = False
                End If
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
        Button1.Text = "Add New JV"
        txtjvno.Text = "Auto Number"
        txtnotes.Text = ""
        txtvid.Text = ""
        cbcrncy.SelectedValue = "KD"
        dtpjvdate.Value = Date.Now
        chbposted.Checked = False
        txtdebit.Text = "0"
        txtdiff.Text = "0"
        txtcredit.Text = "0"
        LoadItemData(0, False)
    End Sub

    Private Sub JV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        'AddRows()
        conn()
        cmd.CommandText = "Select CUR_CODE, '('+CUR_CODE+') '+CUR_DESC As CDesc from MASTER_CURRENCY"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "MASTER_CURRENCY")
        cbcrncy.DisplayMember = "CDesc"
        cbcrncy.ValueMember = "CUR_CODE"
        cbcrncy.DataSource = ds.Tables("MASTER_CURRENCY")
        con.Close()

        ClearAll()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SrNo As String = ""
        Dim EmailMode As String = ""
        Try
            Dim Pstsd, JVID As String
            If chbposted.Checked = True Then
                Pstsd = "T"
            Else
                Pstsd = "F"
            End If

            If txtcredit.Text <> txtdebit.Text Then
                MsgBox("JV Cannot Be Saved." + vbNewLine + "Credit and Debit Amount should Be Same.", MsgBoxStyle.Critical, "H.F. General Trading CO.")
                Exit Sub
            End If

            conn()
            If Button1.Text = "Add New JV" Then
                Try
                    cmd.CommandText = "Insert Into VOUCHER_HEADER Values ((Select COALESCE((Select Top 1 VOUCHER_ID + 1 From VOUCHER_HEADER Order By VOUCHER_ID Desc),1)), 'JV', (Select COALESCE((Select Top 1 Voucher_No+1 From VOUCHER_HEADER Order By Voucher_ID Desc),1)), '" + cbcrncy.SelectedValue + "', N'" + txtnotes.Text + "', '" + dtpjvdate.Value + "', 'T')"
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    con.Close()
                    MsgBox("Cannot Create New JV. Enter Details Properly.", MsgBoxStyle.Critical, "H.F. General Trading CO.")
                    Exit Sub
                End Try

                cmd.CommandText = "Select Top 1 VOUCHER_ID From VOUCHER_HEADER Order By VOUCHER_ID Desc"
                dr = cmd.ExecuteReader
                If dr.Read Then
                    JVID = CType(dr("VOUCHER_ID"), String).Trim
                Else
                    JVID = "1"
                End If
                dr.Close()

                Try
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        Dim SLnameCB As String
                        If row.Cells("SLNAME").Value.ToString = "" Then
                            SLnameCB = "0"
                        Else
                            SLnameCB = row.Cells("SLNAME").Value.ToString
                        End If
                        cmd.CommandText = "Insert Into VOUCHER_DETAIL Values ((Select COALESCE((Select Top 1 [ID] + 1 From VOUCHER_DETAIL Order By [ID] Desc),1)), " + JVID + ", '" + row.Cells("GLCode").Value.ToString + "', (Select SL_CODE From MASTER_SUBLEDGER Where SrNo = " + SLnameCB + "), '" + row.Cells("DIV").Value + "', '" + row.Cells("Ref").Value + "', N'" + row.Cells("NARRATION").Value + "', '" + row.Cells("Type").Value + "', " + row.Cells("AMNT").Value.ToString + ", 0)"
                        cmd.ExecuteNonQuery()
                    Next
                Catch ez As Exception
                End Try
                EmailMode = "Add"
                MsgBox("New JV Added Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            Else
                cmd.CommandText = "Update VOUCHER_HEADER Set VOU_CUR='" + cbcrncy.SelectedValue + "', NOTES='" + txtnotes.Text + "', VOUCHER_DATE='" + dtpjvdate.Value + "', VOU_POSTED='" + Pstsd + "' Where VOUCHER_ID = " + txtvid.Text + ""
                cmd.ExecuteNonQuery()

                Try
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        Dim SLnameCB As String
                        If row.Cells("SLNAME").Value.ToString = "" Then
                            SLnameCB = 0
                        Else
                            SLnameCB = row.Cells("SLNAME").Value.ToString
                        End If
                        If row.Cells("SrNo").Value.ToString = "" Then
                            cmd.CommandText = "Insert Into VOUCHER_DETAIL Values ((Select COALESCE((Select Top 1 [ID] + 1 From VOUCHER_DETAIL Order By [ID] Desc),1)), " + txtvid.Text + ", '" + row.Cells("GLCode").Value + "', (Select SL_CODE From MASTER_SUBLEDGER Where SrNo = " + SLnameCB + "), '" + row.Cells("DIV").Value + "', '" + row.Cells("Ref").Value + "', N'" + row.Cells("NARRATION").Value + "', '" + row.Cells("Type").Value + "', " + row.Cells("AMNT").Value.ToString + ", 0)"
                        Else
                            cmd.CommandText = "Update VOUCHER_DETAIL Set GL_CODE='" + row.Cells("GLCode").Value + "', SL_CODE=(Select SL_CODE From MASTER_SUBLEDGER Where SrNo = " + SLnameCB + "), VOU_DIV='" + row.Cells("DIV").Value + "', REFERENCE_NO='" + row.Cells("Ref").Value + "', NARRATION=N'" + row.Cells("NARRATION").Value + "', TRAN_TYPE='" + row.Cells("Type").Value + "', Amnt=" + row.Cells("AMNT").Value.ToString + " Where [ID]=" + row.Cells("SrNo").Value.ToString + ""
                        End If
                        cmd.ExecuteNonQuery()
                    Next
                Catch ez As Exception
                End Try
                EmailMode = "Update"
                SrNo = txtvid.Text
                MsgBox("Selected JV Updated Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            End If
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
        End Try
        ClearAll()
        'If EmailMode <> "" Then
        '    AccessVerify.NotifyChanges(Me.Name.ToString, EmailMode, SrNo)
        'End If
        LoadItemData(0, False)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AccessVerify.DGVPrinting(Label1.Text, "", True, DataGridView1)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AccessVerify.LoadSrchGrid("Search Journal Vouchers", "Select VOUCHER_NO As JVNo, JVDate, VOU_CUR as Crncy, TotalDebit, TotalCredit, Difference, VOU_POSTED As Posted from View_Voucher_Main Order By VOUCHER_NO DESC", Me.Name, True, "JVNo", "txtvid")
    End Sub

    Private Sub txt_TextChanged(sender As Object, e As EventArgs) Handles txtdebit.TextChanged, txtcredit.TextChanged
        Try
            txtdiff.Text = [String].Format("{0:0.000}", txtdebit.Text - txtcredit.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If e.ColumnIndex = DataGridView1.Columns("GLCode").Index Then
            Try
                DirectCast(DataGridView1("SLNAME", e.RowIndex), DataGridViewMultiColumnComboBoxCell).Value = "0"

                Dim abc As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLibrary.dll")
                connectionString = abc
                sqlConnection = New SqlConnection(connectionString)
                sqlConnection.Open()
                'SLCode Data Source
                Dim selectQueryStringSLCode As String = "SELECT SrNo, SL_NAME, SL_CODE FROM MASTER_SUBLEDGER Union Select 0, '', '' Order By SL_NAME"
                Dim sqlDataAdapterSLCode As New SqlDataAdapter(selectQueryStringSLCode, sqlConnection)
                Dim sqlCommandBuilderSLCode As New SqlCommandBuilder(sqlDataAdapterSLCode)
                Dim dataTableSLCode As New DataTable()
                sqlDataAdapterSLCode.Fill(dataTableSLCode)
                Dim bindingSourceSLCode As New BindingSource()
                bindingSourceSLCode.DataSource = dataTableSLCode

                DirectCast(DataGridView1("SLNAME", e.RowIndex), DataGridViewMultiColumnComboBoxCell).DataSource = bindingSourceSLCode
                'DirectCast(DataGridView1("GLCode", e.RowIndex), DataGridViewMultiColumnComboBoxCell).DisplayMember = "GL_DESC"


                Dim selectQueryStringSLCode2 As String = "SELECT SrNo, SL_NAME, SL_CODE FROM MASTER_SUBLEDGER Where SL_GL_CODE = '" + DataGridView1("GLCode", e.RowIndex).Value + "' Union Select 0, '', '' Order By SL_NAME"
                Dim sqlDataAdapterSLCode2 As New SqlDataAdapter(selectQueryStringSLCode2, sqlConnection)
                Dim sqlCommandBuilderSLCode2 As New SqlCommandBuilder(sqlDataAdapterSLCode2)
                Dim dataTableSLCode2 As New DataTable()
                sqlDataAdapterSLCode2.Fill(dataTableSLCode2)
                Dim bindingSourceSLCode2 As New BindingSource()
                bindingSourceSLCode2.DataSource = dataTableSLCode2

                DirectCast(DataGridView1("SLNAME", e.RowIndex), DataGridViewMultiColumnComboBoxCell).DataSource = bindingSourceSLCode2
                sqlConnection.Close()
            Catch ei As Exception
            End Try
        End If

        If e.ColumnIndex = DataGridView1.Columns("GLCode").Index Or e.ColumnIndex = DataGridView1.Columns("SLNAME").Index Then
            DataGridView1("Amnt", e.RowIndex).Value = "0"
            DataGridView1("DIV", e.RowIndex).Value = "GEN"
        End If

        'If e.ColumnIndex = DataGridView1.Columns("SLNAME").Index Then
        '    DirectCast(DataGridView1("SLNAME", e.RowIndex), DataGridViewMultiColumnComboBoxCell).DisplayMember = "SL_NAME"
        'End If
        Try
            Try
                DataGridView1("Amnt", e.RowIndex).Value = [String].Format("{0:0.000}", DataGridView1("Amnt", e.RowIndex).Value)
            Catch ez As Exception
                DataGridView1("Amnt", e.RowIndex).Value = "0"
                DataGridView1("Amnt", e.RowIndex).Value = [String].Format("{0:0.000}", DataGridView1("Amnt", e.RowIndex).Value)
            End Try
        Catch ex As Exception
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
        If chbposted.Checked = True Then
            MsgBox("You cannot delete items from POSTED JV.", MsgBoxStyle.Critical)
            e.Cancel = True
            Exit Sub
        End If

        Try
            If MsgBox("Are you sure you want to Delete !", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                Dim eno As String = e.Row.Cells("SrNo").Value.ToString
                conn()
                If Button1.Text <> "Add New JV" Then
                    Try
                        For Each row As DataGridViewRow In DataGridView1.Rows
                            If row.Index <> e.Row.Index Then
                                Dim SLnameCB As String
                                If row.Cells("SLNAME").Value.ToString = "" Then
                                    SLnameCB = 0
                                Else
                                    SLnameCB = row.Cells("SLNAME").Value.ToString
                                End If
                                If row.Cells("SrNo").Value.ToString = "" Then
                                    cmd.CommandText = "Insert Into VOUCHER_DETAIL Values ((Select COALESCE((Select Top 1 [ID] + 1 From VOUCHER_DETAIL Order By [ID] Desc),1)), " + txtvid.Text + ", '" + row.Cells("GLCode").Value + "', (Select SL_CODE From MASTER_SUBLEDGER Where SrNo = " + SLnameCB + "), '" + row.Cells("DIV").Value + "', '" + row.Cells("Ref").Value + "', N'" + row.Cells("NARRATION").Value + "', '" + row.Cells("Type").Value + "', " + row.Cells("AMNT").Value.ToString + ", 0)"
                                Else
                                    cmd.CommandText = "Update VOUCHER_DETAIL Set GL_CODE='" + row.Cells("GLCode").Value + "', SL_CODE=(Select SL_CODE From MASTER_SUBLEDGER Where SrNo = " + SLnameCB + "), VOU_DIV='" + row.Cells("DIV").Value + "', REFERENCE_NO='" + row.Cells("Ref").Value + "', NARRATION=N'" + row.Cells("NARRATION").Value + "', TRAN_TYPE='" + row.Cells("Type").Value + "', Amnt=" + row.Cells("AMNT").Value.ToString + " Where [ID]=" + row.Cells("SrNo").Value.ToString + ""
                                End If
                                cmd.ExecuteNonQuery()
                            End If
                        Next
                    Catch ez As Exception
                    End Try
                End If

                Try
                    If eno <> "" Then
                        cmd.CommandText = "Delete From VOUCHER_DETAIL Where [ID] = " + eno + ""
                        cmd.ExecuteNonQuery()
                    End If
                Catch iz As Exception
                End Try
                con.Close()
                'AccessVerify.NotifyChanges(Me.Name.ToString, "Delete", txtvid.Text)
            Else
                e.Cancel = True
                Exit Sub
            End If
            Try
                If txtjvno.Text <> "Auto Number" Then
                    Timer1.Enabled = True
                    Exit Sub
                End If
            Catch ik As Exception
            End Try
        Catch ex As Exception
            con.Close()
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        LoadItemData(txtjvno.Text, True)
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

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs)
        Dim b As New Bitmap(Panel1.Width, Panel1.Height)
        Panel1.DrawToBitmap(b, Panel1.ClientRectangle)

        e.Graphics.DrawImage(b, New Point(0, 0))
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ClearAll()
        LoadItemData(0, False)
    End Sub

    Private Sub DataGridView1_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridView1.UserDeletedRow
        CntAmnt()
    End Sub

    Private Sub txtvid_TextChanged(sender As Object, e As EventArgs) Handles txtvid.TextChanged
        If txtvid.Text <> "" Then
            DataGridView1.DataSource = Nothing
            GridRowSelect()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            conn()
            If e.ColumnIndex = DataGridView1.Columns("SLNAME").Index Then
                cmd.CommandText = "Select SL_Name From MASTER_SUBLEDGER Where SrNo = " + CType(DataGridView1("SLNAME", e.RowIndex).Value, String) + ""
                dr = cmd.ExecuteReader
                dr.Read()
                lbldtls.Text = DataGridView1("SLNAME", e.RowIndex).FormattedValue + " | " + CType(dr("SL_Name"), String).Trim
                dr.Close()
            End If
            If e.ColumnIndex = DataGridView1.Columns("GLCode").Index Then
                cmd.CommandText = "Select GL_DESC From Master_GenLedger Where GL_CODE = '" + DataGridView1("GLCode", e.RowIndex).Value + "'"
                dr = cmd.ExecuteReader
                dr.Read()
                lbldtls.Text = DataGridView1("GLCode", e.RowIndex).FormattedValue + " | " + CType(dr("GL_DESC"), String).Trim
                dr.Close()
            End If
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        MsgBox("Input\Select Proper Data." + vbNewLine + "Problem Details : " & e.Context.ToString(), MsgBoxStyle.Critical, "H.F. General Trading CO.")
        'If (e.Context = DataGridViewDataErrorContexts.Commit) Then
        '    MsgBox("Input\Select Proper Data." + vbNewLine + "Commit error", MsgBoxStyle.Critical, "H.F. General Trading CO.")
        'End If
        'If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
        '    MsgBox("Input\Select Proper Data." + vbNewLine + "Cell change", MsgBoxStyle.Critical, "H.F. General Trading CO.")
        'End If
        'If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
        '    MsgBox("Input\Select Proper Data." + vbNewLine + "parsing error", MsgBoxStyle.Critical, "H.F. General Trading CO.")
        'End If
        'If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
        '    MsgBox("Input\Select Proper Data." + vbNewLine + "leave control error", MsgBoxStyle.Critical, "H.F. General Trading CO.")
        'End If

        'If (TypeOf (e.Exception) Is ConstraintException) Then
        '    Dim view As DataGridView = CType(sender, DataGridView)
        '    view.Rows(e.RowIndex).ErrorText = "an error"
        '    view.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "an error"
        '    e.ThrowException = False
        'End If
    End Sub


    'Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
    '    If e.ColumnIndex = DataGridView1.Columns("SLNAME").Index Then
    '        DirectCast(DataGridView1("SLNAME", e.RowIndex), DataGridViewMultiColumnComboBoxCell).DisplayMember = "SL_CODE"
    '    End If
    '    If e.ColumnIndex = DataGridView1.Columns("GLCode").Index Then
    '        DirectCast(DataGridView1("GLCode", e.RowIndex), DataGridViewMultiColumnComboBoxCell).DisplayMember = "GL_CODE"
    '    End If
    'End Sub

    'Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
    '    If e.ColumnIndex = DataGridView1.Columns("SLNAME").Index Then
    '        DirectCast(DataGridView1("SLNAME", e.RowIndex), DataGridViewMultiColumnComboBoxCell).DisplayMember = "SL_Name"
    '    End If
    '    If e.ColumnIndex = DataGridView1.Columns("GLCode").Index Then
    '        DirectCast(DataGridView1("GLCode", e.RowIndex), DataGridViewMultiColumnComboBoxCell).DisplayMember = "GL_DESC"
    '    End If
    'End Sub

    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        Try
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
        Try
            If e.ColumnIndex = DataGridView1.Columns("AMNT").Index Then
                If CType(DataGridView1("AMNT", e.RowIndex).Value, Double) < 0.001 Then
                    If flag = False Then
                        MsgBox("Amount Cannot Be Zero" + vbNewLine + "System will not respond untill you update the amount.", MsgBoxStyle.Information, "H.F. General Trading CO.")
                    End If
                    flag = True
                    e.Cancel = True
                Else
                    flag = False
                End If
            ElseIf e.ColumnIndex = DataGridView1.Columns("Type").Index Then
                If DataGridView1("Type", e.RowIndex).FormattedValue = "" Then
                    If flag2 = False Then
                        MsgBox("Select Proper JV Type" + vbNewLine + "System will not respond untill you update.", MsgBoxStyle.Information, "H.F. General Trading CO.")
                    End If
                    flag2 = True
                    e.Cancel = True
                Else
                    flag2 = False
                End If
                'ElseIf e.ColumnIndex = DataGridView1.Columns("SLNAME").Index Then
                '    If DataGridView1("SLNAME", e.RowIndex).FormattedValue = "" Then
                '        If flag2 = False Then
                '            MsgBox("SubLedger Code cannot be left blank." + vbNewLine + "Select proper ledger from the dropdown.", MsgBoxStyle.Information, "H.F. General Trading CO.")
                '        End If
                '        flag2 = True
                '        e.Cancel = True
                '    Else
                '        flag2 = False
                '    End If
                'ElseIf e.ColumnIndex = DataGridView1.Columns("GLCode").Index Then
                '    If DataGridView1("GLCode", e.RowIndex).FormattedValue = "" Then
                '        If flag2 = False Then
                '            MsgBox("General Ledger Code cannot be left blank." + vbNewLine + "Select proper ledger from the dropdown.", MsgBoxStyle.Information, "H.F. General Trading CO.")
                '        End If
                '        flag2 = True
                '        e.Cancel = True
                '    Else
                '        flag2 = False
                '    End If
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class