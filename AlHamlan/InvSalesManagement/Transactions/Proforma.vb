Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine
Imports DGMCCBD.Controls
Imports System.Text.RegularExpressions

Public Class Proforma


#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da, da2 As SqlDataAdapter
    Dim ds, ds2 As DataSet
    Dim iRec As Integer
    Dim pono As String
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
    Dim Prnt As Boolean = False
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
        ElseIf e.Alt And e.KeyCode = Keys.Q Then
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
        Dim abc As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLibrary.dll")
        connectionString = abc
        sqlConnection = New SqlConnection(connectionString)
        sqlConnection.Open()

        selectQueryString = "Select ENT_NO, ITEMCODE, PACK, QTY, ITM_PRICE, Gross, ITM_DISC_PER, Net from View_Proforma_Dtls WHERE INV_NO = " + pono + " Order By ENT_NO"
        sqlDataAdapter = New SqlDataAdapter(selectQueryString, sqlConnection)
        sqlCommandBuilder = New SqlCommandBuilder(sqlDataAdapter)
        dataTable = New DataTable()
        sqlDataAdapter.Fill(dataTable)
        bindingSource = New BindingSource()
        bindingSource.DataSource = dataTable

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
        ColumnItemCode.DataPropertyName = "ITEMCODE"
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
        ColumnItem.DataPropertyName = "ITEMCODE"
        ColumnItem.HeaderText = "Item"
        ColumnItem.Width = 470
        ColumnItem.DataSource = bindingSourceItem
        ColumnItem.ValueMember = "ITEM_CODE"
        ColumnItem.DisplayMember = "Itemname"
        ColumnItem.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        ColumnItem.DropDownWidth = 600
        DataGridView1.Columns.Add(ColumnItem)

        'Adding  Prevoius Price Button
        Dim ColumnPrePrice As New DataGridViewButtonColumn()
        ColumnPrePrice.Name = "PrePrice"
        ColumnPrePrice.HeaderText = "O.Pr"
        ColumnPrePrice.Width = 45
        ColumnPrePrice.Text = "O.Pr"
        ColumnPrePrice.UseColumnTextForButtonValue = True
        DataGridView1.Columns.Add(ColumnPrePrice)

        'Adding  Purchase Price Button
        Dim ColumnPurPrice As New DataGridViewButtonColumn()
        ColumnPurPrice.Name = "PurPrice"
        ColumnPurPrice.HeaderText = "P.Pr"
        ColumnPurPrice.Width = 45
        ColumnPurPrice.Text = "P.Pr"
        If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "View Purchase Price") = False Then
            ColumnPurPrice.Visible = False
        Else
            ColumnPurPrice.Visible = True
        End If
        ColumnPurPrice.UseColumnTextForButtonValue = True
        DataGridView1.Columns.Add(ColumnPurPrice)

        'Adding  Pack TextBox
        Dim ColumnPack As New DataGridViewTextBoxColumn()
        ColumnPack.Name = "Pack"
        ColumnPack.HeaderText = "Pack"
        ColumnPack.Width = 70
        ColumnPack.DataPropertyName = "PACK"
        DataGridView1.Columns.Add(ColumnPack)

        'Adding  QTY TextBox
        Dim ColumnQty As New DataGridViewTextBoxColumn()
        ColumnQty.Name = "QTY"
        ColumnQty.HeaderText = "QTY"
        ColumnQty.Width = 70
        ColumnQty.DataPropertyName = "QTY"
        DataGridView1.Columns.Add(ColumnQty)

        'Adding  Price TextBox
        Dim ColumnPrc As New DataGridViewTextBoxColumn()
        ColumnPrc.Name = "Price"
        ColumnPrc.HeaderText = "Price"
        ColumnPrc.Width = 70
        ColumnPrc.ReadOnly = True
        ColumnPrc.DataPropertyName = "ITM_PRICE"
        DataGridView1.Columns.Add(ColumnPrc)

        'Adding  Gross TextBox
        Dim ColumnGrs As New DataGridViewTextBoxColumn()
        ColumnGrs.Name = "GROSS"
        ColumnGrs.HeaderText = "GROSS"
        ColumnGrs.Width = 70
        ColumnGrs.DataPropertyName = "GROSS"
        ColumnGrs.ReadOnly = True
        DataGridView1.Columns.Add(ColumnGrs)

        'Adding  Disc% TextBox
        Dim ColumnDisc As New DataGridViewTextBoxColumn()
        ColumnDisc.Name = "Disc"
        ColumnDisc.HeaderText = "Disc%"
        ColumnDisc.Width = 70
        ColumnDisc.DataPropertyName = "ITM_DISC_PER"
        DataGridView1.Columns.Add(ColumnDisc)

        'Adding  Net TextBox
        Dim ColumnNet As New DataGridViewTextBoxColumn()
        ColumnNet.Name = "NET"
        ColumnNet.HeaderText = "NET"
        ColumnNet.Width = 70
        ColumnNet.DataPropertyName = "NET"
        ColumnNet.ReadOnly = True
        DataGridView1.Columns.Add(ColumnNet)

        'Adding  SrNO TextBox
        Dim ColumnSrNo As New DataGridViewTextBoxColumn()
        ColumnSrNo.Name = "SrNo"
        ColumnSrNo.HeaderText = "SrNo"
        ColumnSrNo.Visible = False
        ColumnSrNo.DataPropertyName = "ENT_NO"
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
            LoadItemData(txtquotno.Text, True)

            conn()
            cmd.CommandText = "Select * From View_Proforma_Main Where INV_NO = '" + txtquotno.Text + "'"
            dr = cmd.ExecuteReader
            If dr.Read Then
                Button1.Text = "Update Selected Proforma"
                txtquotno.Text = CType(dr("INV_NO"), String).Trim
                txtinst.Text = CType(dr("DELIVERY_NOTE"), String).Trim
                dtpdate.Value = CType(dr("INV_DATE"), String).Trim
                cbslsmen.SelectedValue = CType(dr("SMANCODE"), String).Trim
                If CType(dr("INV_POSTED"), String).Trim = "T" Then
                    chbposted.Checked = True
                Else
                    chbposted.Checked = False
                End If
                If CType(dr("INV_CANCEL"), String).Trim = "T" Then
                    chbcncl.Checked = True
                Else
                    chbcncl.Checked = False
                End If

                txtperc.Text = CType(dr("INV_FOOT_DISC"), String).Trim
                txtdisc.Text = CType(dr("INV_FOOT_DISCAMT"), String).Trim
                txtchrgs.Text = CType(dr("INV_FOOT_CHRGS"), String).Trim
                cbcust.SelectedValue = CType(dr("CUST_CODE"), String).Trim
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
        Button1.Text = "Add New Proforma"
        txtquotno.Text = "Auto Number"
        txtinst.Text = ""
        cbcust.SelectedIndex = -1
        txtgross.Text = "0"
        dtpdate.Value = Date.Now
        cbslsmen.SelectedIndex = -1
        chbposted.Checked = False
        chbcncl.Checked = False
        txtperc.Text = "0"
        txtdisc.Text = "0"
        txtchrgs.Text = "0"
        txtnet.Text = "0"

        LoadItemData(0, False)
        dtpdate.Focus()
    End Sub

    Private Sub GeneralLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        'AddRows()
        conn()
        cmd.CommandText = "Select Distinct convert(varchar,CUST_CODE)+' | '+CUST_NAME As CName, CUST_CODE, CUST_NAME from View_CustomerMaster Where CUST_ACTIVE = 'T' Order By CUST_NAME"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_CustomerMaster")
        cbcust.DisplayMember = "CName"
        cbcust.ValueMember = "CUST_CODE"
        cbcust.DataSource = ds.Tables("View_CustomerMaster")
        AddHandler cbcust.SelectedIndexChanged, AddressOf cbcust_SelectedIndexChanged

        cmd.CommandText = "Select SM_Code, NameMob from View_Master_Salesman Order By NameMob"
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "View_Master_Salesman")
        cbslsmen.DisplayMember = "NameMob"
        cbslsmen.ValueMember = "SM_Code"
        cbslsmen.DataSource = ds.Tables("View_Master_Salesman")
        con.Close()

        ClearAll()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SrNo As String = ""
        Dim EmailMode As String = ""
        Try
            Dim Pstsd, InvID, Cncled As String
            If chbposted.Checked = True Then
                Pstsd = "T"
            Else
                Pstsd = "F"
            End If
            If chbcncl.Checked = True Then
                Cncled = "T"
            Else
                Cncled = "F"
            End If
            conn()
            If Button1.Text = "Add New Proforma" Then
                Try
                    cmd.CommandText = "Insert Into PROFORMA_HEADER Values ((Select COALESCE((Select Top 1 INV_NO + 1 From PROFORMA_HEADER Order By INV_NO Desc),1)), '" + cbcust.SelectedValue.ToString + "', " + cbslsmen.SelectedValue.ToString + ", '" + dtpdate.Value + "', '" + txtinst.Text + "', " + txtperc.Text + ", " + txtdisc.Text + ", " + txtchrgs.Text + ", '" + Cncled + "', 'T', Null)"
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    con.Close()
                    MsgBox("Cannot Create New Proforma. Enter Details Properly.", MsgBoxStyle.Critical, "H.F. General Trading CO.")
                    Exit Sub
                End Try

                cmd.CommandText = "Select Top 1 INV_NO From PROFORMA_HEADER Order By INV_NO Desc"
                dr = cmd.ExecuteReader
                If dr.Read() Then
                    SrNo = CType(dr("INV_NO"), String).Trim
                    If Prnt = True Then
                        xyz = CType(dr("INV_NO"), String).Trim
                    Else
                        xyz = ""
                    End If
                End If
                dr.Close()

                Try
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        cmd.CommandText = "Insert Into PROFORMA_DETAIL Values ((Select COALESCE((Select Top 1 ENT_NO + 1 From PROFORMA_DETAIL Order By ENT_NO Desc),1)), " + SrNo + ", '" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', " + DataGridView1.Rows(i).Cells("Pack").Value.ToString + ", " + DataGridView1.Rows(i).Cells("QTY").Value.ToString + ", " + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", " + DataGridView1.Rows(i).Cells("Disc").Value.ToString + ")"
                        cmd.ExecuteNonQuery()
                    Next
                Catch ez As Exception
                End Try
                EmailMode = "Add"
                MsgBox("New Proforma Added Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            Else
                cmd.CommandText = "Update PROFORMA_HEADER Set CUST_CODE='" + cbcust.SelectedValue.ToString + "', SMANCODE=" + cbslsmen.SelectedValue.ToString + ", INV_DATE='" + dtpdate.Value + "', DELIVERY_NOTE='" + txtinst.Text + "', INV_FOOT_DISC=" + txtperc.Text + ", INV_FOOT_DISCAMT=" + txtdisc.Text + ", INV_FOOT_CHRGS=" + txtchrgs.Text + ", INV_CANCEL='" + Cncled + "', INV_POSTED='" + Pstsd + "' Where INV_NO = " + txtquotno.Text + ""
                cmd.ExecuteNonQuery()

                Try
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        If DataGridView1.Rows(i).Cells("SrNo").Value.ToString = "" Then
                            cmd.CommandText = "Insert Into PROFORMA_DETAIL Values ((Select COALESCE((Select Top 1 ENT_NO + 1 From PROFORMA_DETAIL Order By ENT_NO Desc),1)), " + txtquotno.Text + ", '" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', " + DataGridView1.Rows(i).Cells("Pack").Value.ToString + ", " + DataGridView1.Rows(i).Cells("QTY").Value.ToString + ", " + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", " + DataGridView1.Rows(i).Cells("Disc").Value.ToString + ")"
                        Else
                            cmd.CommandText = "Update PROFORMA_DETAIL Set INV_NO=" + txtquotno.Text + ", ITEMCODE='" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', PACK=" + DataGridView1.Rows(i).Cells("Pack").Value.ToString + ", QTY=" + DataGridView1.Rows(i).Cells("QTY").Value.ToString + ", ITM_PRICE=" + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", ITM_DISC_PER=" + DataGridView1.Rows(i).Cells("Disc").Value.ToString + " Where ENT_NO=" + DataGridView1.Rows(i).Cells("SrNo").Value.ToString + ""
                        End If
                        cmd.ExecuteNonQuery()
                    Next
                Catch ez As Exception
                End Try
                EmailMode = "Update"
                SrNo = txtquotno.Text
                If Prnt = True Then
                    xyz = txtquotno.Text
                Else
                    xyz = ""
                End If
                MsgBox("Selected Proforma Updated Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
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
        Try
            Prnt = True
            AccessVerify.LoadingFrm(True)
            If (txtquotno.Text = "Auto Number" And DataGridView1.RowCount > 1) Or (txtquotno.Text <> "Auto Number") Then
                Button1.PerformClick()
            End If

            conn()

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd.CommandText = "Select * from View_Proforma_Main where Inv_No = " + xyz + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_Proforma_Main")
            cmd.CommandText = "Select * from View_Proforma_Dtls where Inv_No = " + xyz + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_Proforma_Dtls")

            Dim cr As New Performarep
            AccessVerify.LoadReports(cr, ds, MainMDI.lblFrmDtls.Text)

            cmd.CommandText = "Update PROFORMA_HEADER Set INV_POSTED= 'T', Prntd = GetDate() Where  Inv_No = " + xyz + ""
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
        Dim Qry As String = "Select INV_NO, CUST_CODE+' | '+CUST_NAME As Customer, InvDate, NET as NetAmnt, INV_POSTED As Posted, INV_CANCEL as Cancelled, NameMob as Salesmen from View_Proforma_Main Order By INV_NO DESC"
        AccessVerify.LoadSrchGrid("Search Performa", Qry, Me.Name, True, "Inv_No", "txtquotno")
    End Sub

    Private Sub txtperc_TextChanged(sender As Object, e As EventArgs) Handles txtperc.TextChanged
        Try
            txtdisc.Text = txtgross.Text * txtperc.Text / 100
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtdisc_TextChanged(sender As Object, e As EventArgs) Handles txtgross.TextChanged, txtdisc.TextChanged, txtchrgs.TextChanged
        Try
            txtnet.Text = [String].Format("{0: 0.000}", txtgross.Text - txtdisc.Text + txtchrgs.Text)
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
                        ' cmd.CommandText = "IF EXISTS (Select * from UpdatedPurcahsePrice('" + DataGridView1("Item", e.RowIndex).Value + "')) BEGIN SELECT UPChrgd As CP from UpdatedPurcahsePrice ('" + DataGridView1("Item", e.RowIndex).Value + "') END ELSE BEGIN SELECT Cost As CP From MASTER_ITEM Where ITEM_CODE = '" + DataGridView1("Item", e.RowIndex).Value + "' END"
                        cmd.CommandText = "Select ITEM_PRICE From MASTER_ITEM Where ITEM_CODE = '" + DataGridView1("Item", e.RowIndex).Value + "'"
                        dr = cmd.ExecuteReader
                        dr.Read()
                        DataGridView1("Price", e.RowIndex).Value = CType(dr("ITEM_PRICE"), String).Trim
                        dr.Close()
                        con.Close()
                        DataGridView1("Pack", e.RowIndex).Value = "1"
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
                If Button1.Text <> "Add New Proforma" Then
                    Try
                        For i As Integer = 0 To DataGridView1.Rows.Count - 1
                            If DataGridView1.Rows(i).Cells("SrNo").Value.ToString = "" Then
                                cmd.CommandText = "Insert Into PROFORMA_DETAIL Values ((Select COALESCE((Select Top 1 ENT_NO + 1 From PROFORMA_DETAIL Order By ENT_NO Desc),1)), " + txtquotno.Text + ", '" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', " + DataGridView1.Rows(i).Cells("Pack").Value.ToString + ", " + DataGridView1.Rows(i).Cells("QTY").Value.ToString + ", " + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", " + DataGridView1.Rows(i).Cells("Disc").Value.ToString + ")"
                            Else
                                cmd.CommandText = "Update PROFORMA_DETAIL Set INV_NO=" + txtquotno.Text + ", ITEMCODE='" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', PACK=" + DataGridView1.Rows(i).Cells("Pack").Value.ToString + ", QTY=" + DataGridView1.Rows(i).Cells("QTY").Value.ToString + ", ITM_PRICE=" + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", ITM_DISC_PER=" + DataGridView1.Rows(i).Cells("Disc").Value.ToString + " Where ENT_NO=" + DataGridView1.Rows(i).Cells("SrNo").Value.ToString + ""
                            End If
                            cmd.ExecuteNonQuery()
                        Next
                    Catch ez As Exception
                    End Try
                End If

                cmd.CommandText = "Delete From PROFORMA_DETAIL Where ENT_NO = " + eno + ""
                cmd.ExecuteNonQuery()
                con.Close()
                If eno <> "" Then
                    LoadItemData(txtquotno.Text, True)
                End If
                AccessVerify.NotifyChanges(Me.Name.ToString, "Delete", txtquotno.Text)
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

    Private Sub DataGridView1_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridView1.UserDeletedRow
        CntAmnt()
    End Sub

    Protected Sub cbcust_SelectedIndexChanged()
        If cbcust.Text = "" Or Button1.Text = "Update Selected Performa" Then
            Exit Sub
        End If

        Dim Pstd As String = ""
        If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Update") = False Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
        conn()
        cmd.CommandText = "Select Top 1 INV_NO From PROFORMA_HEADER Where INV_Posted <> 'T' And CUST_Code = '" + cbcust.SelectedValue.ToString + "' Order By INV_NO Desc"
        dr = cmd.ExecuteReader
        If dr.Read Then
            Pstd = CType(dr("INV_NO"), String).Trim
        End If
        dr.Close()
        con.Close()

        If cbcust.SelectedValue.ToString = "786" And Pstd <> "" Then
            Pstd = ""
            MsgBox("There is an unposted PERFORMA for this Customer." & vbNewLine & "But as for CASH Counter you can proceed.", MsgBoxStyle.Information, "H.F. General Trading CO.")
        End If

        If Pstd <> "" Then
            txtquotno.Text = Pstd
            MsgBox("There is an unposted PERFORMA for this Customer.", MsgBoxStyle.Information, "H.F. General Trading CO.")
        End If

    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        If e.ColumnIndex = DataGridView1.Columns("Price").Index AndAlso e.RowIndex >= 0 Then
            If MsgBox("Are you sure you want to change price ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                DataGridView1("Price", e.RowIndex).ReadOnly = False
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = DataGridView1.Columns("PrePrice").Index AndAlso e.RowIndex >= 0 Then
            AccessVerify.LoadSrchGrid("Previuos Price For : " + DataGridView1("Item", e.RowIndex).FormattedValue.ToString, "Select INV_NO As QoutNo, INV_DATE, ITM_PRICE As UnitPrice, ITM_DISC_PER As DiscPer from View_Proforma_Dtls Where ITEMCODE = '" + DataGridView1("Item", e.RowIndex).Value.ToString + "' And Cust_Code = '" + cbcust.SelectedValue.ToString + "' Order By INV_NO DESC", Me.Name, False)
        ElseIf e.ColumnIndex = DataGridView1.Columns("PurPrice").Index AndAlso e.RowIndex >= 0 Then
            AccessVerify.LoadSrchGrid("Purchase Price For : " + DataGridView1("Item", e.RowIndex).FormattedValue.ToString, "Select IGN_NO As IGN, IGNDate As Date, UnitPrice, ChrgsDiv As Chrgs, UPChrgd As CP, RecvQTY from View_UpdatedPurcahsePrice Where REC_ITM_CODE = '" + DataGridView1("Item", e.RowIndex).Value.ToString + "'  Order By IGN_NO DESC", Me.Name, False)
            'ElseIf e.ColumnIndex = DataGridView1.Columns("Item").Index AndAlso e.RowIndex >= 0 Then
            'TextBox1.Text = Replace(DataGridView1("Item", e.RowIndex).FormattedValue.ToString.Split("(Bal: ").Last, ")", "")
            'TextBox1.Text = Replace(TextBox1.Text, "Bal: ", "")
        End If
    End Sub

    Private Sub chbposted_Click(sender As Object, e As EventArgs) Handles chbposted.Click
        Try
            If chbposted.CheckState = CheckState.Unchecked Then
                conn()
                cmd.CommandText = "Select Count(*) As cnt from PROFORMA_HEADER Where INV_NO = " + txtquotno.Text + " And Prntd Is Null"
                dr = cmd.ExecuteReader
                dr.Read()
                Dim cnt As Integer = dr("cnt")
                dr.Close()
                con.Close()
                If cnt = 0 Then
                    If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Unpost") = False Then
                        chbposted.Checked = True
                        MsgBox("You cannot unpost this PERFORMA as its already Printed.", MsgBoxStyle.Critical, "H.F. General Trading CO.")
                        Exit Sub
                    Else
                        If MsgBox("Are you sure you want to unpost printed PERFORMA !", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                            chbposted.Checked = False
                        Else
                            chbposted.Checked = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtinvno_TextChanged(sender As Object, e As EventArgs) Handles txtquotno.TextChanged
        If txtquotno.Text <> "Auto Number" Then
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

    Private Sub chbcncl_LostFocus(sender As Object, e As EventArgs) Handles chbcncl.LostFocus
        DataGridView1.Focus()
    End Sub

    Private Sub cbslsmen_Leave(sender As Object, e As EventArgs) Handles cbslsmen.Leave, cbcust.Leave
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
                WishedForCell = DataGridView1.Item("QTY", e.RowIndex)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyUp
        If WishedForCell IsNot Nothing Then
            Me.DataGridView1.CurrentCell = WishedForCell
            WishedForCell = Nothing
        End If
    End Sub

    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
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
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Prnt = True
            AccessVerify.LoadingFrm(True)
            If (txtquotno.Text = "Auto Number" And DataGridView1.RowCount > 1) Or (txtquotno.Text <> "Auto Number") Then
                Button1.PerformClick()
            End If

            conn()

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd.CommandText = "Select * from View_Proforma_Main where Inv_No = " + xyz + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_Proforma_Main")
            cmd.CommandText = "Select * from View_Proforma_Dtls where Inv_No = " + xyz + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_Proforma_Dtls")

            Dim cr As New PerformaThermal
            AccessVerify.LoadReports(cr, ds, MainMDI.lblFrmDtls.Text)

            cmd.CommandText = "Update PROFORMA_HEADER Set INV_POSTED= 'T', Prntd = GetDate() Where  Inv_No = " + xyz + ""
            cmd.ExecuteNonQuery()
            con.Close()
            xyz = ""
            Prnt = False
        Catch ex As Exception
            con.Close()
        End Try
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError

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
    End Sub

    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        Try
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Catch ex As Exception
        End Try
    End Sub

End Class