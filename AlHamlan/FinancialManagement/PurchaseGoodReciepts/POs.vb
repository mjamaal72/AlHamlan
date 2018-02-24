Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Imports DGMCCBD.Controls
Imports System.Text.RegularExpressions

Public Class POs

#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da, da2 As SqlDataAdapter
    Dim ds, ds2 As DataSet
    Dim iRec As Integer
    Dim pono As String
    Dim Prnt As Boolean = False
    Dim xyz As String

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
        ElseIf e.Alt And e.KeyCode = Keys.O Then
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
        txtcnt.Text = CellSum("QTY").ToString()
        txtgross.Text = [String].Format("{0:0.000}", CellSum("NET"))
    End Sub

    Public Sub LoadItemData(pono As String, editmode As Boolean)
        DataGridView1.Columns.Clear()
        DataGridView1.AutoGenerateColumns = False

        Dim abc As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLibrary.dll")
        connectionString = abc
        sqlConnection = New SqlConnection(connectionString)
        sqlConnection.Open()

        selectQueryString = "Select PUR_ENT_NO, PUR_ITM_CODE, PUR_PACK, PUR_TYPE, PUR_QTY_ORDERED, PUR_ITM_FRN_PRICE, GROSS, PUR_ITM_DISC, NET from View_PO_Dtls WHERE PUR_ORDER_NO = " + pono + " Order By PUR_ORDER_No"
        sqlDataAdapter = New SqlDataAdapter(selectQueryString, sqlConnection)
        sqlCommandBuilder = New SqlCommandBuilder(sqlDataAdapter)
        dataTable = New DataTable()
        sqlDataAdapter.Fill(dataTable)
        bindingSource = New BindingSource()
        bindingSource.DataSource = dataTable

        ''Currency Data Source
        'Dim selectQueryStringCrncy As String = "SELECT CUR_CODE, CUR_CODE+' | '+CUR_DESC As Crncy FROM MASTER_CURRENCY Order By CUR_DESC"
        'Dim sqlDataAdapterCrncy As New SqlDataAdapter(selectQueryStringCrncy, sqlConnection)
        'Dim sqlCommandBuilderMonth As New SqlCommandBuilder(sqlDataAdapterCrncy)
        'Dim dataTableMonth As New DataTable()
        'sqlDataAdapterCrncy.Fill(dataTableMonth)
        'Dim bindingSourceCrncy As New BindingSource()
        'bindingSourceCrncy.DataSource = dataTableMonth

        'Item Data Source
        Dim selectQueryStringItem As String = "SELECT I.ITEM_CODE, I.ITEM_DESC + ' (Bal: '+ Case When s.BalanceAll<>s.BalancePstd Then convert(varchar,S.BalancePstd) + '\' + convert(varchar,S.BalanceAll) Else convert(varchar,S.BalanceAll) End+')' AS ItemName FROM MASTER_ITEM I INNER JOIN View_StockStatusLIVE S ON I.ITEM_CODE = S.ITEM_CODE WHERE (I.ITEM_ACTIVE = N'T') Order By I.ITEM_DESC"
        Dim sqlDataAdapterItem As New SqlDataAdapter(selectQueryStringItem, sqlConnection)
        Dim sqlCommandBuilderItem As New SqlCommandBuilder(sqlDataAdapterItem)
        Dim dataTableItem As New DataTable()
        sqlDataAdapterItem.Fill(dataTableItem)
        Dim bindingSourceItem As New BindingSource()
        bindingSourceItem.DataSource = dataTableItem

        'Adding  Item Code
        Dim ColumnItemCode As New DataGridViewMultiColumnComboBoxColumn
        ColumnItemCode.Name = "ITEMCODE"
        ColumnItemCode.DataPropertyName = "PUR_ITM_CODE"
        ColumnItemCode.HeaderText = "ICode"
        ColumnItemCode.Width = 90
        ColumnItemCode.DataSource = bindingSourceItem
        ColumnItemCode.ValueMember = "ITEM_CODE"
        ColumnItemCode.DisplayMember = "ITEM_CODE"
        ColumnItemCode.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        ColumnItemCode.DropDownWidth = 550
        ColumnItemCode.ColumnNames.Add("ITEM_CODE")
        ColumnItemCode.ColumnNames.Add("Itemname")
        ColumnItemCode.ColumnWidths.Add("110")
        ColumnItemCode.ColumnWidths.Add("590")
        ColumnItemCode.DropDownWidth = 700
        DataGridView1.Columns.Add(ColumnItemCode)


        'Adding  Item Combo
        Dim ColumnItem As New DataGridViewComboBoxColumn()
        ColumnItem.Name = "Item"
        ColumnItem.DataPropertyName = "PUR_ITM_CODE"
        ColumnItem.HeaderText = "Item"
        ColumnItem.Width = 460
        ColumnItem.DataSource = bindingSourceItem
        ColumnItem.ValueMember = "ITEM_CODE"
        ColumnItem.DisplayMember = "Itemname"
        ColumnItem.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        ColumnItem.DropDownWidth = 600
        DataGridView1.Columns.Add(ColumnItem)

        'Adding  Pack TextBox
        Dim ColumnPack As New DataGridViewTextBoxColumn()
        ColumnPack.Name = "Pack"
        ColumnPack.HeaderText = "Pack"
        ColumnPack.Width = 80
        ColumnPack.DataPropertyName = "PUR_PACK"
        DataGridView1.Columns.Add(ColumnPack)

        'Adding  Flag TextBox
        Dim ColumnFlag As New DataGridViewTextBoxColumn()
        ColumnFlag.Name = "Flag"
        ColumnFlag.HeaderText = "Flag"
        ColumnFlag.Width = 40
        ColumnFlag.DataPropertyName = "PUR_TYPE"
        DataGridView1.Columns.Add(ColumnFlag)

        ''Adding  FCrncy Combo
        'Dim ColumnCrncy As New DataGridViewComboBoxColumn()
        'ColumnCrncy.Name = "FCrncy"
        'ColumnCrncy.DataPropertyName = "PUR_ITM_FOREIGN_CUR"
        'ColumnCrncy.HeaderText = "FCrncy"
        'ColumnCrncy.Width = 75
        'ColumnCrncy.DataSource = bindingSourceCrncy
        'ColumnCrncy.ValueMember = "CUR_CODE"
        'ColumnCrncy.DisplayMember = "Crncy"
        'DataGridView1.Columns.Add(ColumnCrncy)

        ''Adding  FPrice TextBox
        'Dim ColumnFPrc As New DataGridViewTextBoxColumn()
        'ColumnFPrc.Name = "FPrice"
        'ColumnFPrc.HeaderText = "FPrice"
        'ColumnFPrc.Width = 70
        'ColumnFPrc.DataPropertyName = "PUR_ITM_FOREIGN_PR"
        'DataGridView1.Columns.Add(ColumnFPrc)

        'Adding  QTY TextBox
        Dim ColumnQty As New DataGridViewTextBoxColumn()
        ColumnQty.Name = "QTY"
        ColumnQty.HeaderText = "QTY"
        ColumnQty.Width = 70
        ColumnQty.DataPropertyName = "PUR_QTY_ORDERED"
        DataGridView1.Columns.Add(ColumnQty)

        'Adding  Price TextBox
        Dim ColumnPrc As New DataGridViewTextBoxColumn()
        ColumnPrc.Name = "Price"
        ColumnPrc.HeaderText = "Price"
        ColumnPrc.Width = 80
        ColumnPrc.ReadOnly = True
        ColumnPrc.DataPropertyName = "PUR_ITM_FRN_PRICE"
        DataGridView1.Columns.Add(ColumnPrc)

        'Adding  Gross TextBox
        Dim ColumnGrs As New DataGridViewTextBoxColumn()
        ColumnGrs.Name = "GROSS"
        ColumnGrs.HeaderText = "GROSS"
        ColumnGrs.Width = 80
        ColumnGrs.DataPropertyName = "GROSS"
        ColumnGrs.ReadOnly = True
        DataGridView1.Columns.Add(ColumnGrs)

        'Adding  Disc% TextBox
        Dim ColumnDisc As New DataGridViewTextBoxColumn()
        ColumnDisc.Name = "Disc"
        ColumnDisc.HeaderText = "Disc%"
        ColumnDisc.Width = 80
        ColumnDisc.DataPropertyName = "PUR_ITM_DISC"
        DataGridView1.Columns.Add(ColumnDisc)

        'Adding  Net TextBox
        Dim ColumnNet As New DataGridViewTextBoxColumn()
        ColumnNet.Name = "NET"
        ColumnNet.HeaderText = "NET"
        ColumnNet.Width = 80
        ColumnNet.DataPropertyName = "NET"
        ColumnNet.ReadOnly = True
        DataGridView1.Columns.Add(ColumnNet)

        'Adding  SrNO TextBox
        Dim ColumnSrNo As New DataGridViewTextBoxColumn()
        ColumnSrNo.Name = "SrNo"
        ColumnSrNo.HeaderText = "SrNo"
        ColumnSrNo.Visible = False
        ColumnSrNo.DataPropertyName = "PUR_ENT_NO"
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
            LoadItemData(txtpono.Text, True)
            conn()
            cmd.CommandText = "Select * From View_PO_Main Where PUR_ORDER_NO = '" + txtpono.Text + "'"
            dr = cmd.ExecuteReader
            If dr.Read Then
                Button1.Text = "Update Selected PO"
                txtpono.Text = CType(dr("PUR_ORDER_NO"), String).Trim
                txtinst.Text = CType(dr("PUR_REMARKS"), String).Trim
                txtlc.Text = CType(dr("LC_Nos"), String).Trim
                cbcrncy.SelectedValue = CType(dr("PUR_CUR_CODE"), String).Trim
                cbshiptrm.SelectedValue = CType(dr("PUR_SHIP_TERMS"), String).Trim
                dtppodate.Value = CType(dr("PUR_ORDER_DATE"), String).Trim
                cbsuplr.SelectedValue = CType(dr("SL_CODE"), String).Trim
                cbdiv.SelectedValue = CType(dr("PUR_DIV"), String).Trim
                If CType(dr("PUR_POSTED"), String).Trim = "T" Then
                    chbposted.Checked = True
                Else
                    chbposted.Checked = False
                End If
                cbpayterm.SelectedValue = CType(dr("PUR_PAY_TYPE"), String).Trim
                txtperc.Text = CType(dr("PUR_FOOT_DISC_PER"), String).Trim
                txtdisc.Text = CType(dr("PUR_FOOT_DISC"), String).Trim
                txtchrgs.Text = CType(dr("PUR_FOOT_CHARGES"), String).Trim
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
        Button1.Text = "Add New PO"
        txtpono.Text = "Auto Number"
        txtinst.Text = ""
        cbsuplr.SelectedIndex = -1
        txtgross.Text = "0"
        cbcrncy.SelectedValue = "KD"
        cbshiptrm.SelectedIndex = -1
        dtppodate.Value = Date.Now
        txtlc.Text = ""
        cbdiv.SelectedIndex = -1
        chbposted.Checked = False
        cbpayterm.SelectedIndex = -1
        txtperc.Text = "0"
        txtdisc.Text = "0"
        txtchrgs.Text = "0"
        txtnet.Text = "0"
        LoadItemData(0, False)
        dtppodate.Focus()
    End Sub

    Private Sub GeneralLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        'AddRows()
        conn()
        cmd.CommandText = "Select Distinct SL_Code+' | '+SL_NAME As SlName, SL_Code from View_Master_Supplier Where SL_ACTIVE = 'T' Order By SL_Code"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_Master_Supplier")
        cbsuplr.DisplayMember = "SlName"
        cbsuplr.ValueMember = "SL_Code"
        cbsuplr.DataSource = ds.Tables("View_Master_Supplier")
        AddHandler cbsuplr.SelectedIndexChanged, AddressOf cbsuplr_SelectedIndexChanged

        cmd.CommandText = "Select CUR_CODE, '('+CUR_CODE+') '+CUR_DESC As CDesc from MASTER_CURRENCY"
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "MASTER_CURRENCY")
        cbcrncy.DisplayMember = "CDesc"
        cbcrncy.ValueMember = "CUR_CODE"
        cbcrncy.DataSource = ds.Tables("MASTER_CURRENCY")

        cmd.CommandText = "Select SHP_CODE+' | '+ SHP_DESC As ShpTerm, SHP_CODE from MASTER_SHIPMENT_TERMS"
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "MASTER_SHIPMENT_TERMS")
        cbshiptrm.DisplayMember = "ShpTerm"
        cbshiptrm.ValueMember = "SHP_CODE"
        cbshiptrm.DataSource = ds.Tables("MASTER_SHIPMENT_TERMS")

        cmd.CommandText = "Select DIV_CODE +' | '+  DIV_DESC As DIVDESC, DIV_CODE from MASTER_DIVISION"
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "MASTER_DIVISION")
        cbdiv.DisplayMember = "DIVDESC"
        cbdiv.ValueMember = "DIV_CODE"
        cbdiv.DataSource = ds.Tables("MASTER_DIVISION")

        cmd.CommandText = "Select PAY_CODE+' | '+ PAY_DESC As PAYTerm, PAY_CODE from MASTER_PAYMENT_TYPES"
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "MASTER_PAYMENT_TYPES")
        cbpayterm.DisplayMember = "PAYTerm"
        cbpayterm.ValueMember = "PAY_CODE"
        cbpayterm.DataSource = ds.Tables("MASTER_PAYMENT_TYPES")
        con.Close()

        ClearAll()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SrNo As String = ""
        Dim EmailMode As String = ""
        Try
            Dim Pstsd, POID As String
            If chbposted.Checked = True Then
                Pstsd = "T"
            Else
                Pstsd = "F"
            End If
            conn()
            If Button1.Text = "Add New PO" Then
                Try
                    cmd.CommandText = "Insert Into PURCHASE_HEADER Values ((Select COALESCE((Select Top 1 PUR_ORDER_NO + 1 From PURCHASE_HEADER Order By PUR_ORDER_NO Desc),1)), '" + cbsuplr.SelectedValue + "', '" + cbdiv.SelectedValue + "', '" + dtppodate.Value + "', '" + cbcrncy.SelectedValue + "', " + txtdisc.Text + ", " + txtperc.Text + ", " + txtchrgs.Text + ", '" + cbshiptrm.SelectedValue + "', '" + cbpayterm.SelectedValue + "', '" + txtinst.Text + "', 'T', 'F', 'F', '')"
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    con.Close()
                    MsgBox("Cannot Create New PO. Enter Details Properly.", MsgBoxStyle.Critical, "H.F. General Trading CO.")
                    Exit Sub
                End Try

                cmd.CommandText = "Select Top 1 PUR_ORDER_NO From PURCHASE_HEADER Order By PUR_ORDER_NO Desc"
                dr = cmd.ExecuteReader
                If dr.Read Then
                    POID = CType(dr("PUR_ORDER_NO"), String).Trim
                    If Prnt = True Then
                        xyz = CType(dr("PUR_ORDER_NO"), String).Trim
                    Else
                        xyz = ""
                    End If
                Else
                    POID = "1"
                    If Prnt = True Then
                        xyz = "1"
                    Else
                        xyz = ""
                    End If
                End If
                dr.Close()

                Try
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        cmd.CommandText = "Insert Into PURCHASE_DETAIL Values ((Select COALESCE((Select Top 1 PUR_ENT_NO + 1 From PURCHASE_DETAIL Order By PUR_ENT_NO Desc),1)), " + POID + ", '" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', '" + DataGridView1.Rows(i).Cells("Pack").Value + "', '" + DataGridView1.Rows(i).Cells("Flag").Value + "', " + DataGridView1.Rows(i).Cells("QTY").Value.ToString + ", 0, " + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", " + DataGridView1.Rows(i).Cells("Disc").Value.ToString + ", '')"
                        cmd.ExecuteNonQuery()
                    Next
                Catch ez As Exception
                End Try
                EmailMode = "Add"
                MsgBox("New PO Added Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            Else
                cmd.CommandText = "Update PURCHASE_HEADER Set SL_CODE='" + cbsuplr.SelectedValue + "', PUR_DIV='" + cbdiv.SelectedValue + "', PUR_ORDER_DATE='" + dtppodate.Value + "', PUR_CUR_CODE='" + cbcrncy.SelectedValue + "', PUR_FOOT_DISC=" + txtdisc.Text + ", PUR_FOOT_DISC_PER=" + txtperc.Text + ", PUR_FOOT_CHARGES=" + txtchrgs.Text + ", PUR_SHIP_TERMS='" + cbshiptrm.SelectedValue + "', PUR_PAY_TYPE='" + cbpayterm.SelectedValue + "', PUR_REMARKS='" + txtinst.Text + "', PUR_POSTED='" + Pstsd + "' Where PUR_ORDER_NO = " + txtpono.Text + ""
                cmd.ExecuteNonQuery()

                Try
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        If DataGridView1.Rows(i).Cells("SrNo").Value.ToString = "" Then
                            cmd.CommandText = "Insert Into PURCHASE_DETAIL Values ((Select COALESCE((Select Top 1 PUR_ENT_NO + 1 From PURCHASE_DETAIL Order By PUR_ENT_NO Desc),1)), " + txtpono.Text + ", '" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', '" + DataGridView1.Rows(i).Cells("Pack").Value + "', '" + DataGridView1.Rows(i).Cells("Flag").Value + "', " + DataGridView1.Rows(i).Cells("QTY").Value.ToString + ", 0, " + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", " + DataGridView1.Rows(i).Cells("Disc").Value.ToString + ", '')"
                        Else
                            cmd.CommandText = "Update PURCHASE_DETAIL Set PUR_ITM_CODE='" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', PUR_PACK='" + DataGridView1.Rows(i).Cells("Pack").Value + "', PUR_TYPE='" + DataGridView1.Rows(i).Cells("Flag").Value + "', PUR_QTY_ORDERED=" + DataGridView1.Rows(i).Cells("QTY").Value.ToString + ", PUR_ITM_FRN_PRICE=" + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", PUR_ITM_DISC=" + DataGridView1.Rows(i).Cells("Disc").Value.ToString + " Where PUR_ENT_NO=" + DataGridView1.Rows(i).Cells("SrNo").Value.ToString + ""
                        End If
                        cmd.ExecuteNonQuery()
                    Next
                Catch ez As Exception
                End Try
                EmailMode = "Update"
                SrNo = txtpono.Text
                If Prnt = True Then
                    xyz = txtpono.Text
                Else
                    xyz = ""
                End If
                MsgBox("Selected PO Updated Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
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
        'AccessVerify.DGVPrinting(Label1.Text, "", True, DataGridView1)
        Try
            Prnt = True
            AccessVerify.LoadingFrm(True)
            If (txtpono.Text = "Auto Number" And DataGridView1.RowCount > 1) Or (txtpono.Text <> "Auto Number") Then
                Button1.PerformClick()
            End If

            conn()

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd.CommandText = "Select * from View_PO_Main where PUR_ORDER_NO = " + xyz + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_PO_Main")
            cmd.CommandText = "Select * from View_PO_Dtls where PUR_ORDER_NO = " + xyz + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_PO_Dtls")

            Dim cr As New PO
            AccessVerify.LoadReports(cr, ds, MainMDI.lblFrmDtls.Text)

            cmd.CommandText = "Update PURCHASE_HEADER Set PUR_POSTED = 'T' Where  PUR_ORDER_NO = " + xyz + ""
            cmd.ExecuteNonQuery()
            con.Close()
            xyz = ""
            Prnt = False
        Catch ex As Exception
            con.Close()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AccessVerify.LoadSrchGrid("Search Purchase Orders", "Select PUR_ORDER_No As PONo, SL_CODE+' | '+SL_NAME As Supplier, PODate, PUR_NET_VALUE as NetAmnt, PUR_POSTED As Posted from View_PO_Main Order By PUR_ORDER_No DESC", Me.Name, True, "PONo", "txtpono")
    End Sub

    Private Sub txtperc_TextChanged(sender As Object, e As EventArgs) Handles txtperc.TextChanged
        Try
            txtdisc.Text = txtgross.Text * txtperc.Text / 100
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtdisc_TextChanged(sender As Object, e As EventArgs) Handles txtdisc.TextChanged, txtchrgs.TextChanged, txtgross.TextChanged
        Try
            txtnet.Text = [String].Format("{0:0.000}", txtgross.Text - txtdisc.Text + txtchrgs.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Try
            Try
                DataGridView1("Price", e.RowIndex).ReadOnly = True
            Catch ex As Exception
            End Try

            Try
                If e.ColumnIndex = DataGridView1.Columns("Pack").Index Then
                    If DataGridView1("Pack", e.RowIndex).Value.ToString.Contains("x") Then
                        Dim r As Decimal = CType(Regex.Replace(DataGridView1("Pack", e.RowIndex).Value.ToString.Split("x")(0), "[^.0-9]", ""), Decimal) * CType(Regex.Replace(DataGridView1("Pack", e.RowIndex).Value.ToString.Split("x")(1), "[^.0-9]", ""), Decimal)
                        DataGridView1("QTY", e.RowIndex).Value = Decimal.Round(r, 2).ToString()
                        DataGridView1("QTY", e.RowIndex).ReadOnly = True
                    ElseIf DataGridView1("Pack", e.RowIndex).Value.ToString.Contains("X") Then
                        Dim r As Decimal = CType(Regex.Replace(DataGridView1("Pack", e.RowIndex).Value.ToString.Split("X")(0), "[^.0-9]", ""), Decimal) * CType(Regex.Replace(DataGridView1("Pack", e.RowIndex).Value.ToString.Split("X")(1), "[^.0-9]", ""), Decimal)
                        DataGridView1("QTY", e.RowIndex).Value = Decimal.Round(r, 2).ToString()
                        DataGridView1("QTY", e.RowIndex).ReadOnly = True
                    Else
                        DataGridView1("QTY", e.RowIndex).ReadOnly = False
                    End If
                End If
            Catch ex As Exception

            End Try

            Try
                If e.ColumnIndex = DataGridView1.Columns("ITEMCODE").Index Then
                    DataGridView1("Item", e.RowIndex).Value = DataGridView1("ITEMCODE", e.RowIndex).Value.ToString
                End If
                If e.ColumnIndex = DataGridView1.Columns("Item").Index Then
                    DataGridView1("ITEMCODE", e.RowIndex).Value = DataGridView1("Item", e.RowIndex).Value.ToString
                    DataGridView1("ITEMCODE", e.RowIndex).Selected = True
                End If
                If e.ColumnIndex = DataGridView1.Columns("Item").Index Or e.ColumnIndex = DataGridView1.Columns("ITEMCODE").Index Then
                    Try
                        conn()
                        cmd.CommandText = "Select * from View_Master_Items Where ITEM_CODE = '" + DataGridView1("Item", e.RowIndex).Value + "'"
                        dr = cmd.ExecuteReader
                        dr.Read()
                        DataGridView1("Price", e.RowIndex).Value = CType(dr("Cost"), String).Trim
                        dr.Close()
                        con.Close()
                        DataGridView1("Pack", e.RowIndex).Value = "1"
                        DataGridView1("Flag", e.RowIndex).Value = "S"
                        DataGridView1("FPrice", e.RowIndex).Value = "0"
                    Catch ei As Exception
                    End Try
                End If
            Catch ex As Exception
                MsgBox("Select Proper Item from The List", MsgBoxStyle.Information, "H.F. General Trading CO.")
            End Try


            Try
                Try
                    DataGridView1("Gross", e.RowIndex).Value = [String].Format("{0:0.000}", DataGridView1("QTY", e.RowIndex).Value * DataGridView1("Price", e.RowIndex).Value)
                Catch ez As Exception
                    DataGridView1("QTY", e.RowIndex).Value = "1"
                    DataGridView1("Gross", e.RowIndex).Value = [String].Format("{0:0.000}", DataGridView1("QTY", e.RowIndex).Value * DataGridView1("Price", e.RowIndex).Value)
                End Try
                Try
                    DataGridView1("Net", e.RowIndex).Value = [String].Format("{0:0.000}", DataGridView1("Gross", e.RowIndex).Value - (DataGridView1("Gross", e.RowIndex).Value * DataGridView1("Disc", e.RowIndex).Value / 100))
                Catch ey As Exception
                    DataGridView1("Disc", e.RowIndex).Value = "0"
                    DataGridView1("Net", e.RowIndex).Value = [String].Format("{0:0.000}", DataGridView1("Gross", e.RowIndex).Value - (DataGridView1("Gross", e.RowIndex).Value * DataGridView1("Disc", e.RowIndex).Value / 100))
                End Try
                Try
                    DataGridView1("Price", e.RowIndex).Value = [String].Format("{0:0.000}", DataGridView1("Price", e.RowIndex).Value)
                Catch ez As Exception
                End Try
            Catch ex As Exception
            End Try
            Try
                CntAmnt()
            Catch ex As Exception
            End Try

        Catch mj As Exception
            con.Close()
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
                If Button1.Text <> "Add New PO" Then
                    Try
                        For i As Integer = 0 To DataGridView1.Rows.Count - 1
                            If DataGridView1.Rows(i).Cells("SrNo").Value.ToString = "" Then
                                cmd.CommandText = "Insert Into PURCHASE_DETAIL Values ((Select COALESCE((Select Top 1 PUR_ENT_NO + 1 From PURCHASE_DETAIL Order By PUR_ENT_NO Desc),1)), " + txtpono.Text + ", '" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', '" + DataGridView1.Rows(i).Cells("Pack").Value + "', '" + DataGridView1.Rows(i).Cells("Flag").Value + "', " + DataGridView1.Rows(i).Cells("QTY").Value.ToString + ", 0, " + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", " + DataGridView1.Rows(i).Cells("Disc").Value.ToString + ", '')"
                            Else
                                cmd.CommandText = "Update PURCHASE_DETAIL Set PUR_ITM_CODE='" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', PUR_PACK='" + DataGridView1.Rows(i).Cells("Pack").Value + "', PUR_TYPE='" + DataGridView1.Rows(i).Cells("Flag").Value + "', PUR_QTY_ORDERED=" + DataGridView1.Rows(i).Cells("QTY").Value.ToString + ", PUR_ITM_FRN_PRICE=" + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", PUR_ITM_DISC=" + DataGridView1.Rows(i).Cells("Disc").Value.ToString + " Where PUR_ENT_NO=" + DataGridView1.Rows(i).Cells("SrNo").Value.ToString + ""
                            End If
                            cmd.ExecuteNonQuery()
                        Next
                    Catch ez As Exception
                    End Try
                End If

                cmd.CommandText = "Delete From PURCHASE_DETAIL Where PUR_ENT_NO = " + eno + ""
                cmd.ExecuteNonQuery()
                con.Close()
                If eno <> "" Then
                    LoadItemData(txtpono.Text, True)
                End If
                AccessVerify.NotifyChanges(Me.Name.ToString, "Delete", txtpono.Text)
            End If
            e.Cancel = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chbposted_CheckedChanged(sender As Object, e As EventArgs) Handles chbposted.CheckedChanged
        If chbposted.Checked = True Then
            Panel1.Enabled = False
            DataGridView1.ReadOnly = True
        Else
            Panel1.Enabled = True
            DataGridView1.ReadOnly = False
            DataGridView1.Columns("PRICE").ReadOnly = True
            DataGridView1.Columns("GROSS").ReadOnly = True
            DataGridView1.Columns("NET").ReadOnly = True
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim b As New Bitmap(Panel1.Width, Panel1.Height)
        Panel1.DrawToBitmap(b, Panel1.ClientRectangle)

        e.Graphics.DrawImage(b, New Point(0, 0))
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ClearAll()
        LoadItemData(0, False)
    End Sub

    Protected Sub cbsuplr_SelectedIndexChanged()
        If cbsuplr.Text = "" Or Button1.Text = "Update Selected PO" Then
            Exit Sub
        End If
        Dim Pstd As String = ""
        If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Update") = False Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
        conn()
        cmd.CommandText = "Select Top 1 PUR_ORDER_NO From PURCHASE_HEADER Where Pur_Posted <> 'T' And SL_Code = '" + cbsuplr.SelectedValue.ToString + "' Order By PUR_ORDER_NO Desc"
        dr = cmd.ExecuteReader
        If dr.Read Then
            Pstd = CType(dr("PUR_ORDER_NO"), String).Trim
        End If
        dr.Close()

        If Pstd <> "" Then
            txtpono.Text = Pstd
            MsgBox("There is an unposted PO for this Supplier.", MsgBoxStyle.Information, "H.F. General Trading CO.")
        End If

    End Sub

    Private Sub DataGridView1_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridView1.UserDeletedRow
        Try
            CntAmnt()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Try
            If e.ColumnIndex = DataGridView1.Columns("Price").Index AndAlso e.RowIndex >= 0 Then
                If MsgBox("Are you sure you want to change price ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                    DataGridView1("Price", e.RowIndex).ReadOnly = False
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chbposted_Click(sender As Object, e As EventArgs) Handles chbposted.Click
        If chbposted.CheckState = CheckState.Unchecked Then
            conn()
            cmd.CommandText = "Select Count(*) As cnt from IGN_HEADER Where Pur_No = " + txtpono.Text
            dr = cmd.ExecuteReader
            dr.Read()
            Dim cnt As Integer = dr("cnt")
            dr.Close()
            con.Close()
            If cnt > 0 Then
                If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Unpost") = False Then
                    chbposted.Checked = True
                    MsgBox("You cannot unpost this PO as it has already refered in IGN.", MsgBoxStyle.Critical, "H.F. General Trading CO.")
                    Exit Sub
                Else
                    If MsgBox("Are you sure you want to unpost refered Purchase Order !", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                        chbposted.Checked = False
                    Else
                        chbposted.Checked = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtpono_TextChanged(sender As Object, e As EventArgs) Handles txtpono.TextChanged
        If txtpono.Text <> "Auto Number" Then
            DataGridView1.DataSource = Nothing
            GridRowSelect()
        End If
    End Sub

    Private Sub DataGridView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DataGridView1.KeyPress
        Try
            If DataGridView1("Price", DataGridView1.CurrentCell.RowIndex).ReadOnly = True Then
                If DataGridView1.CurrentCell.ColumnIndex = DataGridView1.Columns("Price").Index AndAlso DataGridView1.CurrentCell.RowIndex >= 0 AndAlso ((e.KeyChar = (Chr(99))) Or (e.KeyChar = (Chr(67))) Or (e.KeyChar = (Chr(46))) Or (e.KeyChar = (Chr(48))) Or (e.KeyChar = (Chr(49))) Or (e.KeyChar = (Chr(50))) Or (e.KeyChar = (Chr(51))) Or (e.KeyChar = (Chr(52))) Or (e.KeyChar = (Chr(53))) Or (e.KeyChar = (Chr(54))) Or (e.KeyChar = (Chr(55))) Or (e.KeyChar = (Chr(56))) Or (e.KeyChar = (Chr(57)))) Then
                    If MsgBox("Are you sure you want to change price ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                        DataGridView1("Price", DataGridView1.CurrentCell.RowIndex).ReadOnly = False
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cbslsmen_Leave(sender As Object, e As EventArgs) Handles cbsuplr.Leave, cbcrncy.Leave, cbdiv.Leave, cbpayterm.Leave, cbshiptrm.Leave
        If Me.Disposing = False Then
            If TypeOf sender Is SergeUtils.EasyCompletionComboBox Then
                Dim CB As SergeUtils.EasyCompletionComboBox = CType(sender, SergeUtils.EasyCompletionComboBox)
                CB.SelectedIndex = CB.FindString(CB.Text)
                Try
                    If CB.SelectedValue = Nothing Then
                        MsgBox("Select Proper Option From Dropdown.")
                        CB.Focus()
                    End If
                Catch ex As Exception
                End Try
                Try
                    If CB.SelectedValue.ToString <> "" And CB.Name = "cbsuplr" Then
                        conn()
                        cmd.CommandText = "Select Pending From View_Supplier_Pending Where Code = '" + CB.SelectedValue.ToString + "'"
                        dr = cmd.ExecuteReader
                        If dr.Read Then
                            lbldue.Text = "Dues : " + CType(dr("Pending"), String).Trim
                        End If
                        dr.Close()
                        con.Close()
                    End If
                Catch ex As Exception
                End Try
            ElseIf TypeOf sender Is TextBox Then
                Dim TXT As TextBox = CType(sender, TextBox)
                Try
                    If TXT.Text = "" Then
                        MsgBox("Please Enter Proper Details To Proceed")
                        TXT.Focus()
                    End If
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellLeave
        Try
            If e.ColumnIndex = DataGridView1.Columns("Price").Index Then
                WishedForCell = DataGridView1.Item("ITEMCODE", e.RowIndex + 1)
            End If
            If e.ColumnIndex = DataGridView1.Columns("ITEM").Index Then 'Or e.ColumnIndex = DataGridView1.Columns("ITEMCODE").Index Then
                WishedForCell = DataGridView1.Item("Pack", e.RowIndex)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyUp
        Try
            If WishedForCell IsNot Nothing Then
                Me.DataGridView1.CurrentCell = WishedForCell
                WishedForCell = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        Try
            If TypeOf e.Control Is DataGridViewComboBoxEditingControl Then
                CType(e.Control, ComboBox).DropDownStyle = ComboBoxStyle.DropDown
                CType(e.Control, ComboBox).AutoCompleteSource = AutoCompleteSource.ListItems
                If DataGridView1.CurrentCell.ColumnIndex = DataGridView1.Columns("ItemCode").Index Then
                    CType(e.Control, ComboBox).DroppedDown = True
                Else
                    CType(e.Control, ComboBox).DroppedDown = False
                End If
                CType(e.Control, ComboBox).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        Try
            MsgBox("Input\Select Proper Data." + vbNewLine + "Problem Details : " & e.Context.ToString(), MsgBoxStyle.Critical, "H.F. General Trading CO.")

            If (e.Context = DataGridViewDataErrorContexts.Commit) Then
                MsgBox("Input\Select Proper Data." + vbNewLine + "Commit error", MsgBoxStyle.Critical, "H.F. General Trading CO.")
            End If
            If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
                MsgBox("Input\Select Proper Data." + vbNewLine + "Cell change", MsgBoxStyle.Critical, "H.F. General Trading CO.")
            End If
            If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
                MsgBox("Input\Select Proper Data." + vbNewLine + "parsing error", MsgBoxStyle.Critical, "H.F. General Trading CO.")
            End If
            If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
                MsgBox("Input\Select Proper Data." + vbNewLine + "leave control error", MsgBoxStyle.Critical, "H.F. General Trading CO.")
            End If

            If (TypeOf (e.Exception) Is ConstraintException) Then
                Dim view As DataGridView = CType(sender, DataGridView)
                view.Rows(e.RowIndex).ErrorText = "an error"
                view.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "an error"
                e.ThrowException = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        Try
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Catch ex As Exception
        End Try
    End Sub

End Class