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

Public Class GRN

#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da, da2 As SqlDataAdapter
    Dim ds, ds2 As DataSet
    Dim iRec As Integer
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
    Dim RevTab As Boolean = False
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
        ElseIf e.Alt And e.KeyCode = Keys.G Then
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

    Public Sub LoadItemData(GrnNO As String, LoadMode As String)
        DataGridView1.Columns.Clear()
        DataGridView1.AutoGenerateColumns = False
        Dim abc As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLibrary.dll")
        connectionString = abc
        sqlConnection = New SqlConnection(connectionString)
        sqlConnection.Open()

        If GrnNO <> "" And LoadMode = "INV" Then
            selectQueryString = "Select '' as ENT_NO, ITEMCODE, REMARKS, PACK, QTY, ITM_PRICE, Gross, ITM_DISC_PER, Net from View_SalesInv_Dtls WHERE Inv_NO = " + GrnNO + " Order By ENT_NO"
        Else
            selectQueryString = "Select ENT_NO, ITEMCODE, REMARKS, PACK, QTY, ITM_PRICE, Gross, ITM_DISC_PER, Net from View_GRN_Dtls WHERE GRN_NO = " + GrnNO + " Order By ENT_NO"
        End If
        sqlDataAdapter = New SqlDataAdapter(selectQueryString, sqlConnection)
        sqlCommandBuilder = New SqlCommandBuilder(sqlDataAdapter)
        dataTable = New DataTable()
        sqlDataAdapter.Fill(dataTable)
        bindingSource = New BindingSource()
        bindingSource.DataSource = dataTable

        'Item Data Source
        Dim selectQueryStringItem As String = "SELECT I.ITEM_CODE, I.ITEM_DESC + ' (Bal: '+ Case When s.BalanceAll<>s.BalancePstd Then convert(varchar,S.BalancePstd) + '\' + convert(varchar,S.BalanceAll) Else convert(varchar,S.BalanceAll) End+')' AS ItemName FROM MASTER_ITEM I INNER JOIN View_StockStatusLIVE  S ON I.ITEM_CODE = S.ITEM_CODE WHERE (I.ITEM_ACTIVE = N'T') Order By I.ITEM_DESC"
        Dim sqlDataAdapterItem As New SqlDataAdapter(selectQueryStringItem, sqlConnection)
        Dim sqlCommandBuilderItem As New SqlCommandBuilder(sqlDataAdapterItem)
        Dim dataTableItem As New DataTable()
        sqlDataAdapterItem.Fill(dataTableItem)
        Dim bindingSourceItem As New BindingSource()
        bindingSourceItem.DataSource = dataTableItem


        ''Adding  Item Code
        'Dim ColumnItemCode As New DataGridViewComboBoxColumn()
        'ColumnItemCode.Name = "ITEMCODE"
        'ColumnItemCode.DataPropertyName = "ITEMCODE"
        'ColumnItemCode.HeaderText = "ICode"
        'ColumnItemCode.Width = 110
        'ColumnItemCode.DataSource = bindingSourceItem
        'ColumnItemCode.ValueMember = "ITEM_CODE"
        'ColumnItemCode.DisplayMember = "ITEM_CODE"
        'ColumnItemCode.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        ''ColumnItem.AutoComplete = True
        'DataGridView1.Columns.Add(ColumnItemCode)

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
        ColumnItem.Width = 460
        ColumnItem.DataSource = bindingSourceItem
        ColumnItem.ValueMember = "ITEM_CODE"
        ColumnItem.DisplayMember = "Itemname"
        ColumnItem.DropDownWidth = 600
        ColumnItem.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        DataGridView1.Columns.Add(ColumnItem)

        'Adding  Remarks TextBox
        Dim ColumnREMARKS As New DataGridViewTextBoxColumn()
        ColumnREMARKS.Name = "REMARKS"
        ColumnREMARKS.HeaderText = "REMARKS"
        ColumnREMARKS.Width = 100
        ColumnREMARKS.DataPropertyName = "REMARKS"
        DataGridView1.Columns.Add(ColumnREMARKS)

        'Adding  Prevoius Price Button
        Dim ColumnPrePrice As New DataGridViewButtonColumn()
        ColumnPrePrice.Name = "PrePrice"
        ColumnPrePrice.HeaderText = "O.Pr"
        ColumnPrePrice.Width = 45
        ColumnPrePrice.Text = "O.Pr"
        ColumnPrePrice.UseColumnTextForButtonValue = True
        DataGridView1.Columns.Add(ColumnPrePrice)

        'Adding  Pack TextBox
        Dim ColumnPack As New DataGridViewTextBoxColumn()
        ColumnPack.Name = "Pack"
        ColumnPack.HeaderText = "Pack"
        ColumnPack.Width = 80
        ColumnPack.DataPropertyName = "PACK"
        DataGridView1.Columns.Add(ColumnPack)

        'Adding  QTY TextBox
        Dim ColumnQty As New DataGridViewTextBoxColumn()
        ColumnQty.Name = "QTY"
        ColumnQty.HeaderText = "QTY"
        ColumnQty.Width = 60
        ColumnQty.DataPropertyName = "QTY"
        DataGridView1.Columns.Add(ColumnQty)

        'Adding  Price TextBox
        Dim ColumnPrc As New DataGridViewTextBoxColumn()
        ColumnPrc.Name = "Price"
        ColumnPrc.HeaderText = "Price"
        ColumnPrc.Width = 60
        ColumnPrc.ReadOnly = True
        ColumnPrc.DataPropertyName = "ITM_PRICE"
        DataGridView1.Columns.Add(ColumnPrc)

        'Adding  Gross TextBox
        Dim ColumnGrs As New DataGridViewTextBoxColumn()
        ColumnGrs.Name = "GROSS"
        ColumnGrs.HeaderText = "GROSS"
        ColumnGrs.Width = 60
        ColumnGrs.DataPropertyName = "GROSS"
        ColumnGrs.ReadOnly = True
        DataGridView1.Columns.Add(ColumnGrs)

        'Adding  Disc% TextBox
        Dim ColumnDisc As New DataGridViewTextBoxColumn()
        ColumnDisc.Name = "Disc"
        ColumnDisc.HeaderText = "Chrgs%"
        ColumnDisc.Width = 60
        ColumnDisc.DataPropertyName = "ITM_DISC_PER"
        DataGridView1.Columns.Add(ColumnDisc)

        'Adding  Net TextBox
        Dim ColumnNet As New DataGridViewTextBoxColumn()
        ColumnNet.Name = "NET"
        ColumnNet.HeaderText = "NET"
        ColumnNet.Width = 60
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
            LoadItemData(txtgrnno.Text, "GRN")

            conn()
            cmd.CommandText = "Select * From View_GRN_Main Where GRN_NO = '" + txtgrnno.Text + "'"
            dr = cmd.ExecuteReader
            If dr.Read Then
                Button1.Text = "Update Selected GRN"
                txtgrnno.Text = CType(dr("GRN_NO"), String).Trim
                txtinst.Text = CType(dr("DELIVERY_NOTE"), String).Trim
                dtpdate.Value = CType(dr("GRN_DATE"), String).Trim
                cbcust.SelectedValue = CType(dr("CUST_CODE"), String).Trim
                cbslsmen.SelectedValue = CType(dr("SMANCODE"), String).Trim
                If CType(dr("GRN_POSTED"), String).Trim = "T" Then
                    chbposted.Checked = True
                Else
                    chbposted.Checked = False
                End If
                If CType(dr("GRN_CANCEL"), String).Trim = "T" Then
                    chbcncl.Checked = True
                Else
                    chbcncl.Checked = False
                End If

                txtdisc.Text = CType(dr("GRN_FOOT_DISC"), String).Trim
                txtchrgs.Text = CType(dr("GRN_CHRGS_AMT"), String).Trim

                lblInvLoad.Visible = False
                txtInvLoad.Visible = False
                btnInvLoad.Visible = False
                btnSrcInv.Visible = False
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
        DataGridView1.AllowUserToAddRows = True
        DataGridView1.AllowUserToDeleteRows = True

        Button1.Text = "Add New GRN"
        txtgrnno.Text = "Auto Number"
        txtinst.Text = ""
        cbcust.SelectedIndex = -1
        txtgross.Text = "0"
        dtpdate.Value = Date.Now
        cbslsmen.SelectedIndex = -1
        chbposted.Checked = False
        chbcncl.Checked = False
        txtchrgs.Text = "0"
        txtdisc.Text = "0"
        txtnet.Text = "0"

        lblInvLoad.Visible = True
        txtInvLoad.Visible = True
        btnInvLoad.Visible = True
        btnSrcInv.Visible = True

        LoadItemData(0, "GRN")
        dtpdate.Focus()
    End Sub

    Private Sub ME_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Dim Pstsd, GrnID, Cncled As String
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
            If Button1.Text = "Add New GRN" Then
                Try
                    cmd.CommandText = "Insert Into GRN_HEADER Values ((Select COALESCE((Select Top 1 GRN_NO + 1 From GRN_HEADER Order By GRN_NO Desc),1)), '" + cbcust.SelectedValue.ToString + "', " + cbslsmen.SelectedValue.ToString + ", '" + dtpdate.Value + "', '" + txtinst.Text + "', " + txtchrgs.Text + ", " + txtdisc.Text + ", '" + Cncled + "', '" + Pstsd + "', Null, Null)"
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    con.Close()
                    MsgBox("Cannot Create New GRN. Enter Details Properly.", MsgBoxStyle.Critical, "H.F. General Trading CO.")
                    Exit Sub
                End Try

                cmd.CommandText = "Select Top 1 GRN_NO From GRN_HEADER Order By GRN_NO Desc"
                dr = cmd.ExecuteReader
                If dr.Read Then
                    GrnID = CType(dr("GRN_NO"), String).Trim
                    If Prnt = True Then
                        xyz = CType(dr("GRN_NO"), String).Trim
                    Else
                        xyz = ""
                    End If
                End If
                dr.Close()

                Try
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        cmd.CommandText = "Insert Into GRN_DETAIL Values ((Select COALESCE((Select Top 1 ENT_NO + 1 From GRN_DETAIL Order By ENT_NO Desc),1)), " + GrnID + ", '" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', '" + DataGridView1.Rows(i).Cells("REMARKS").Value.ToString + "', '" + DataGridView1.Rows(i).Cells("Pack").Value.ToString + "', " + DataGridView1.Rows(i).Cells("QTY").Value.ToString + ", " + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", " + DataGridView1.Rows(i).Cells("Disc").Value.ToString + ")"
                        cmd.ExecuteNonQuery()
                    Next
                Catch ez As Exception
                End Try
                EmailMode = "Add"
                MsgBox("New GRN Added Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            Else
                cmd.CommandText = "Update GRN_HEADER Set CUST_CODE='" + cbcust.SelectedValue.ToString + "', SMANCODE=" + cbslsmen.SelectedValue.ToString + ", GRN_DATE='" + dtpdate.Value + "', DELIVERY_NOTE='" + txtinst.Text + "', GRN_FOOT_DISC=" + txtdisc.Text + ", GRN_CHRGS_AMT=" + txtchrgs.Text + ", GRN_CANCEL='" + Cncled + "', GRN_POSTED='" + Pstsd + "' Where GRN_NO = " + txtgrnno.Text + ""
                cmd.ExecuteNonQuery()

                Try
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        If DataGridView1.Rows(i).Cells("SrNo").Value.ToString = "" Then
                            cmd.CommandText = "Insert Into GRN_DETAIL Values ((Select COALESCE((Select Top 1 ENT_NO + 1 From GRN_DETAIL Order By ENT_NO Desc),1)), " + txtgrnno.Text + ", '" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', '" + DataGridView1.Rows(i).Cells("REMARKS").Value.ToString + "', '" + DataGridView1.Rows(i).Cells("Pack").Value.ToString + "', " + DataGridView1.Rows(i).Cells("QTY").Value.ToString + ", " + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", " + DataGridView1.Rows(i).Cells("Disc").Value.ToString + ")"
                        Else
                            cmd.CommandText = "Update GRN_DETAIL Set GRN_NO=" + txtgrnno.Text + ", ITEMCODE='" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', PACK='" + DataGridView1.Rows(i).Cells("Pack").Value.ToString + "', QTY=" + DataGridView1.Rows(i).Cells("QTY").Value.ToString + ", ITM_PRICE=" + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", ITM_DISC_PER=" + DataGridView1.Rows(i).Cells("Disc").Value.ToString + ", REMARKS='" + DataGridView1.Rows(i).Cells("REMARKS").Value.ToString + "' Where ENT_NO=" + DataGridView1.Rows(i).Cells("SrNo").Value.ToString + ""
                        End If
                        cmd.ExecuteNonQuery()
                    Next
                Catch ez As Exception
                End Try
                EmailMode = "Update"
                SrNo = txtgrnno.Text
                If Prnt = True Then
                    xyz = txtgrnno.Text
                Else
                    xyz = ""
                End If
                MsgBox("Selected GRN Updated Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
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
        LoadItemData(0, "GRN")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Prnt = True
            AccessVerify.LoadingFrm(True)
            If (txtgrnno.Text = "Auto Number" And DataGridView1.RowCount > 1) Or (txtgrnno.Text <> "Auto Number") Then
                Button1.PerformClick()
            End If

            conn()
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd.CommandText = "Select * from View_GRN_Main where GRN_No = " + xyz + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_GRN_Main")
            cmd.CommandText = "Select * from View_GRN_Dtls where GRN_No = " + xyz + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_GRN_Dtls")

            Dim cr As New GRNRep
            AccessVerify.LoadReports(cr, ds, MainMDI.lblFrmDtls.Text)

            cmd.CommandText = "Update GRN_HEADER Set GRN_POSTED = 'T', GRN_PRINTED = GetDate() Where  GRN_No = " + xyz + ""
            cmd.ExecuteNonQuery()
            con.Close()
            xyz = ""
            Prnt = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AccessVerify.LoadSrchGrid("Search Goods Return Notes", "Select GRN_NO, CUST_CODE+' | '+CUST_NAME As Customer, GrnDate, NET as NetAmnt, Grn_POSTED As Posted, Grn_CANCEL as Cancelled, NameMob as Salesmen from View_GRN_Main Order By GRN_NO DESC", Me.Name, True, "GRN_NO", "txtgrnno")
    End Sub

    Private Sub txtdisc_TextChanged(sender As Object, e As EventArgs) Handles txtdisc.TextChanged, txtgross.TextChanged, txtchrgs.TextChanged
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
                    cmd.CommandText = "IF EXISTS (Select * from GRNPurcahsePrice('" + DataGridView1("Item", e.RowIndex).Value + "', '" + cbcust.SelectedValue.ToString + "')) BEGIN SELECT ITM_PRICE As CP from GRNPurcahsePrice ('" + DataGridView1("Item", e.RowIndex).Value + "', '" + cbcust.SelectedValue.ToString + "') END ELSE BEGIN SELECT ITEM_PRICE As CP From MASTER_ITEM Where ITEM_CODE = '" + DataGridView1("Item", e.RowIndex).Value + "' END"
                    dr = cmd.ExecuteReader
                    dr.Read()
                    DataGridView1("Price", e.RowIndex).Value = CType(dr("CP"), String).Trim
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

        If chbposted.Checked = True Then
            MsgBox("You cannot delete items from POSTED Invoice.", MsgBoxStyle.Critical)
            e.Cancel = True
            Exit Sub
        End If

        Try
            If MsgBox("Are you sure you want to Delete !", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                Dim eno As String = e.Row.Cells("SrNo").Value.ToString
                conn()
                If Button1.Text <> "Add New GRN" Then
                    Try
                        For i As Integer = 0 To DataGridView1.Rows.Count - 1
                            If DataGridView1.Rows(i).Cells("SrNo").Value.ToString = "" Then
                                cmd.CommandText = "Insert Into GRN_DETAIL Values ((Select COALESCE((Select Top 1 ENT_NO + 1 From GRN_DETAIL Order By ENT_NO Desc),1)), " + txtgrnno.Text + ", '" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', '" + DataGridView1.Rows(i).Cells("REMARKS").Value.ToString + "', " + DataGridView1.Rows(i).Cells("Pack").Value.ToString + ", " + DataGridView1.Rows(i).Cells("QTY").Value.ToString + ", " + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", " + DataGridView1.Rows(i).Cells("Disc").Value.ToString + ")"
                            Else
                                cmd.CommandText = "Update GRN_DETAIL Set GRN_NO=" + txtgrnno.Text + ", ITEMCODE='" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', PACK=" + DataGridView1.Rows(i).Cells("Pack").Value.ToString + ", QTY=" + DataGridView1.Rows(i).Cells("QTY").Value.ToString + ", ITM_PRICE=" + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", ITM_DISC_PER=" + DataGridView1.Rows(i).Cells("Disc").Value.ToString + ", REMARKS='" + DataGridView1.Rows(i).Cells("REMARKS").Value.ToString + "' Where ENT_NO=" + DataGridView1.Rows(i).Cells("SrNo").Value.ToString + ""
                            End If
                            cmd.ExecuteNonQuery()
                        Next
                    Catch ez As Exception
                    End Try
                End If

                cmd.CommandText = "Delete From GRN_DETAIL Where ENT_NO = " + eno + ""
                cmd.ExecuteNonQuery()
                con.Close()
                If eno <> "" Then
                    LoadItemData(txtgrnno.Text, "GRN")
                End If
                AccessVerify.NotifyChanges(Me.Name.ToString, "Delete", txtgrnno.Text)
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
        LoadItemData(0, "GRN")
    End Sub

    Private Sub DataGridView1_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridView1.UserDeletedRow
        Try
            CntAmnt()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub cbcust_SelectedIndexChanged()
        If cbcust.Text = "" Or Button1.Text = "Update Selected GRN" Then
            Exit Sub
        End If

        Dim Pstd As String = ""
        If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Update") = False Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
        conn()
        cmd.CommandText = "Select Top 1 GRN_NO From GRN_HEADER Where GRN_Posted <> 'T' And CUST_Code = '" + cbcust.SelectedValue.ToString + "' Order By GRN_NO Desc"
        dr = cmd.ExecuteReader
        If dr.Read Then
            Pstd = CType(dr("GRN_NO"), String).Trim
        End If
        dr.Close()
        If cbcust.SelectedValue.ToString = "786" And Pstd <> "" Then
            Pstd = ""
            MsgBox("There is an unposted GRN for this Customer." & vbNewLine & "But as for CASH Counter you can proceed.", MsgBoxStyle.Information, "H.F. General Trading CO.")
        End If

        If Pstd <> "" Then
            txtgrnno.Text = Pstd
            MsgBox("There is an unposted GRN for this Customer.", MsgBoxStyle.Information, "H.F. General Trading CO.")
        End If

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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            If e.ColumnIndex = DataGridView1.Columns("PrePrice").Index AndAlso e.RowIndex >= 0 Then
                AccessVerify.LoadSrchGrid("Previuos Price For : " + DataGridView1("Item", e.RowIndex).FormattedValue.ToString, "Select INV_NO, INV_DATE, ITM_PRICE As UnitPrice, ITM_DISC_PER As DiscPer from View_SalesInv_Dtls Where ITEMCODE = '" + DataGridView1("Item", e.RowIndex).Value.ToString + "' And Cust_Code = '" + cbcust.SelectedValue.ToString + "' Order By INV_NO DESC", Me.Name, False)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chbposted_Click(sender As Object, e As EventArgs) Handles chbposted.Click
        Try
            If chbposted.CheckState = CheckState.Unchecked Then
                conn()
                cmd.CommandText = "Select Count(*) As cnt from GRN_HEADER Where GRN_NO = " + txtgrnno.Text + " And GRN_Printed IS Null"
                dr = cmd.ExecuteReader
                dr.Read()
                Dim cnt As Integer = dr("cnt")
                dr.Close()
                con.Close()
                If cnt = 0 Then
                    If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Unpost") = False Then
                        chbposted.Checked = True
                        MsgBox("You cannot unpost this GRN as its already Printed.", MsgBoxStyle.Critical, "H.F. General Trading CO.")
                        Exit Sub
                    Else
                        If MsgBox("Are you sure you want to unpost printed GRN !", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
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

    Private Sub txtgrnno_TextChanged(sender As Object, e As EventArgs) Handles txtgrnno.TextChanged
        If txtgrnno.Text <> "Auto Number" Then
            DataGridView1.DataSource = Nothing
            GridRowSelect()
        End If
    End Sub

    Private Sub chbcncl_LostFocus(sender As Object, e As EventArgs) Handles chbcncl.LostFocus
        DataGridView1.Focus()
    End Sub

    Private Sub DataGridView1_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellLeave
        Try
            If e.ColumnIndex = DataGridView1.Columns("Price").Index And RevTab = False Then
                WishedForCell = DataGridView1.Item("ITEMCODE", e.RowIndex + 1)
            End If
            If e.ColumnIndex = DataGridView1.Columns("REMARKS").Index And RevTab = False Then 'Or e.ColumnIndex = DataGridView1.Columns("ITEMCODE").Index Then
                WishedForCell = DataGridView1.Item("QTY", e.RowIndex)
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Prnt = True
            AccessVerify.LoadingFrm(True)
            If (txtgrnno.Text = "Auto Number" And DataGridView1.RowCount > 1) Or (txtgrnno.Text <> "Auto Number") Then
                Button1.PerformClick()
            End If

            conn()
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd.CommandText = "Select * from View_GRN_Main where GRN_No = " + xyz + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_GRN_Main")
            cmd.CommandText = "Select * from View_GRN_Dtls where GRN_No = " + xyz + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_GRN_Dtls")

            Dim cr As New GRNRepThermal
            AccessVerify.LoadReports(cr, ds)

            cmd.CommandText = "Update GRN_HEADER Set GRN_POSTED = 'T', GRN_PRINTED = GetDate() Where  GRN_No = " + xyz + ""
            cmd.ExecuteNonQuery()
            con.Close()
            xyz = ""
            Prnt = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnInvLoad_Click(sender As Object, e As EventArgs) Handles btnInvLoad.Click
        If MsgBox("Loading Invoice will overwrite all enetered Items." + vbNewLine + "Are you sure you want to proceed." + vbNewLine + "Do you want to overwrite with it ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
            DataGridView1.DataSource = Nothing

            Try
                LoadItemData(txtInvLoad.Text, "INV")

                conn()
                cmd.CommandText = "Select * From View_SalesInv_Main Where Inv_NO = " + txtInvLoad.Text + ""
                dr = cmd.ExecuteReader
                If dr.Read Then
                    txtinst.Text = CType(dr("DELIVERY_NOTE"), String).Trim
                    dtpdate.Value = CType(dr("INV_DATE"), String).Trim
                    txtdisc.Text = CType(dr("INV_FOOT_DISC"), String).Trim
                    txtchrgs.Text = CType(dr("INV_CHRGS"), String).Trim
                    cbslsmen.SelectedValue = CType(dr("SMANCODE"), String).Trim
                    cbcust.SelectedValue = CType(dr("CUST_CODE"), String).Trim
                End If
                dr.Close()
                con.Close()

                MsgBox("Invoice Loaded Successfully In GRN." + vbNewLine + "Remove Item Rows, Except for what you want to create GRN.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
            End Try
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btnSrcInv.Click
        Dim Qry As String = "Select INV_NO, CUST_CODE+' | '+CUST_NAME As Customer, CONVERT(VARCHAR(24), Inv_Date,100) As InvDate, LPO, NET as NetAmnt, INV_POSTED As Posted, INV_CANCEL as Cancelled, NameMob as Salesmen from View_SalesInv_Main Order By INV_NO DESC"
        AccessVerify.LoadSrchGrid("Search Invoice", Qry, Me.Name, True, "Inv_No", "txtInvLoad")
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        Try
            If (e.Modifiers = Keys.Shift AndAlso e.KeyCode = Keys.Tab) Or e.KeyCode = Keys.Left Then
                WishedForCell = Nothing
                RevTab = True
            ElseIf e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Right Then
                RevTab = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
        Try
            If e.ColumnIndex = DataGridView1.Columns("Price").Index Then
                If CType(DataGridView1("Price", e.RowIndex).Value, Double) < 0.001 Then
                    If flag = False Then
                        MsgBox("Price Cannot Be Zero" + vbNewLine + "System will not respond untill you update the price.", MsgBoxStyle.Information, "H.F. General Trading CO.")
                    End If
                    flag = True
                    e.Cancel = True
                Else
                    flag = False
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class