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

Public Class SalesInvoice

#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da, da2 As SqlDataAdapter
    Dim ds, ds2, dsitems As DataSet
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
    Dim track As Integer = 0
    Dim WishedForCell As DataGridViewCell = Nothing
    Dim RevTab As Boolean = False
    Dim abc As String
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
        ElseIf e.Alt And e.KeyCode = Keys.V Then
            Button6.PerformClick()
        ElseIf e.Alt And e.KeyCode = Keys.I Then
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

    Public Sub LoadItemData(pono As String, editmode As Boolean, LoadMode As String)
        DataGridView1.Columns.Clear()
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.AllowUserToAddRows = True

        Dim abc As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLibrary.dll")
        connectionString = abc
        sqlConnection = New SqlConnection(connectionString)
        sqlConnection.Open()

        If LoadMode = "Proforma" Then
            selectQueryString = "Select 0 As ENT_NO, ITEMCODE, '' As REMARKS, PACK, QTY, ITM_PRICE, Gross, ITM_DISC_PER, Net, ENT_NO As PROF_ENT_NO from View_Proforma_Dtls WHERE INV_NO = " + pono + " Order By ENT_NO"
        Else
            selectQueryString = "Select ENT_NO, ITEMCODE, REMARKS, PACK, QTY, ITM_PRICE, Gross, ITM_DISC_PER, Net, PROF_ENT_NO from View_SalesInv_Dtls WHERE INV_NO = " + pono + " Order By ENT_NO"
        End If
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


        'Adding  GLCode Combo
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
        ColumnItem.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        ColumnItem.DropDownWidth = 600
        DataGridView1.Columns.Add(ColumnItem)

        'Adding  Remarks TextBox
        Dim ColumnREMARKS As New DataGridViewTextBoxColumn()
        ColumnREMARKS.Name = "REMARKS"
        ColumnREMARKS.HeaderText = "REMARKS"
        ColumnREMARKS.Width = 100
        'ColumnREMARKS.MaxInputLength = 30
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
        ColumnPack.Width = 65
        ColumnPack.DataPropertyName = "PACK"
        DataGridView1.Columns.Add(ColumnPack)

        'Adding  QTY TextBox
        Dim ColumnQty As New DataGridViewTextBoxColumn()
        ColumnQty.Name = "QTY"
        ColumnQty.HeaderText = "QTY"
        ColumnQty.Width = 55
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
        ColumnDisc.HeaderText = "Disc%"
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

        'Adding  PROF_ENT_NO TextBox
        Dim ColumnPEN As New DataGridViewTextBoxColumn()
        ColumnPEN.Name = "PROF_ENT_NO"
        ColumnPEN.HeaderText = "PROF_ENT_NO"
        ColumnPEN.DataPropertyName = "PROF_ENT_NO"
        ColumnPEN.ReadOnly = True
        ColumnPEN.Visible = False
        DataGridView1.Columns.Add(ColumnPEN)

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
            LoadItemData(txtinvno.Text, True, "Sales")

            conn()
            cmd.CommandText = "Select * From View_SalesInv_Main Where INV_NO = '" + txtinvno.Text + "'"
            dr = cmd.ExecuteReader
            If dr.Read Then
                Button1.Text = "Update Selected Invoice"
                txtinvno.Text = CType(dr("INV_NO"), String).Trim
                txtinst.Text = CType(dr("DELIVERY_NOTE"), String).Trim
                txtLPO.Text = CType(dr("LPO"), String).Trim
                dtpdate.Value = CType(dr("INV_DATE"), String).Trim
                cbcust.SelectedValue = CType(dr("CUST_CODE"), String).Trim
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
                txtdisc.Text = CType(dr("INV_DISC_AMT"), String).Trim
                txtchrgs.Text = CType(dr("INV_CHRGS"), String).Trim
            End If
            dr.Close()
            con.Close()
        Catch ex As Exception
            con.Close()
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
        Button1.Text = "Add New Invoice"
        txtinvno.Text = "Auto Number"
        txtinst.Text = ""
        txtLPO.Text = ""
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
        txtproforma.Text = ""

        LoadItemData(0, False, "Sales")
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
            If Button1.Text = "Add New Invoice" Then
                Try
                    cmd.CommandText = "Insert Into SALES_HEADER Values ((Select COALESCE((Select Top 1 INV_NO + 1 From SALES_HEADER Order By INV_NO Desc),1)), 0, '', '" + cbcust.SelectedValue.ToString + "', " + cbslsmen.SelectedValue.ToString + ", '" + dtpdate.Value + "', '" + txtinst.Text + "', '" + txtLPO.Text + "', " + txtdisc.Text + ", " + txtperc.Text + ", " + txtchrgs.Text + ", '" + Cncled + "', '" + Pstsd + "', NULL, NULL, NULL, NULL)"
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    con.Close()
                    MsgBox("Cannot Create New Invoice. Enter Details Properly.", MsgBoxStyle.Critical, "H.F. General Trading CO.")
                    Exit Sub
                End Try

                cmd.CommandText = "Select Top 1 INV_NO From SALES_HEADER Order By INV_NO Desc"
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
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        Dim PerENo As String
                        If row.Cells("PROF_ENT_NO").Value.ToString = Nothing Or row.Cells("PROF_ENT_NO").Value.ToString = "" Then
                            PerENo = "0"
                        Else
                            PerENo = row.Cells("PROF_ENT_NO").Value.ToString
                        End If
                        cmd.CommandText = "Insert Into SALES_DETAIL Values ((Select COALESCE((Select Top 1 ENT_NO + 1 From SALES_DETAIL Order By ENT_NO Desc),1)), " + SrNo + ", '" + row.Cells("Item").Value.ToString + "', " + PerENo + ", '" + row.Cells("REMARKS").Value.ToString + "', '" + row.Cells("Pack").Value.ToString + "', " + row.Cells("QTY").Value.ToString + ", " + row.Cells("Price").Value.ToString + ", " + row.Cells("Disc").Value.ToString + ", GetDate())"
                        cmd.ExecuteNonQuery()
                    Next
                    'For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    '    Dim PerENo As String
                    '    If DataGridView1.Rows(i).Cells("PROF_ENT_NO").Value.ToString = Nothing Or DataGridView1.Rows(i).Cells("PROF_ENT_NO").Value.ToString = "" Then
                    '        PerENo = "0"
                    '    Else
                    '        PerENo = DataGridView1.Rows(i).Cells("PROF_ENT_NO").Value.ToString
                    '    End If
                    '    cmd.CommandText = "Insert Into SALES_DETAIL Values ((Select COALESCE((Select Top 1 ENT_NO + 1 From SALES_DETAIL Order By ENT_NO Desc),1)), " + SrNo + ", '" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', " + PerENo + ", '" + DataGridView1.Rows(i).Cells("REMARKS").Value.ToString + "', '" + DataGridView1.Rows(i).Cells("Pack").Value.ToString + "', " + DataGridView1.Rows(i).Cells("QTY").Value.ToString + ", " + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", " + DataGridView1.Rows(i).Cells("Disc").Value.ToString + ")"
                    '    cmd.ExecuteNonQuery()
                    'Next
                Catch ez As Exception
                End Try
                EmailMode = "Add"
                MsgBox("New Invoice Added Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            ElseIf Button1.Text = "Update Selected Invoice" Then
                Dim ExCust As String = "F"
                cmd.CommandText = "Select CUST_ONHOLD from CUSTOMER_MASTER Where CUST_CODE='" + cbcust.SelectedValue.ToString + "'"
                dr = cmd.ExecuteReader
                If dr.Read Then
                    ExCust = dr("CUST_ONHOLD")
                End If
                dr.Close()

                If ExCust = "F" Then
                    cmd.CommandText = "Update SALES_HEADER Set CUST_CODE='" + cbcust.SelectedValue.ToString + "', SMANCODE=" + cbslsmen.SelectedValue.ToString + ", INV_DATE='" + dtpdate.Value + "', DELIVERY_NOTE='" + txtinst.Text + "', LPO = '" + txtLPO.Text + "', INV_FOOT_DISC=" + txtperc.Text + ", INV_DISC_AMT=" + txtdisc.Text + ", INV_CHRGS=" + txtchrgs.Text + ", INV_CANCEL='" + Cncled + "', INV_POSTED='" + Pstsd + "' Where INV_NO = " + txtinvno.Text + ""
                Else
                    cmd.CommandText = "Update SALES_HEADER Set CUST_CODE='" + cbcust.SelectedValue.ToString + "', SMANCODE=" + cbslsmen.SelectedValue.ToString + ", INV_DATE = GetDate(), DELIVERY_NOTE='" + txtinst.Text + "', LPO = '" + txtLPO.Text + "', INV_FOOT_DISC=" + txtperc.Text + ", INV_DISC_AMT=" + txtdisc.Text + ", INV_CHRGS=" + txtchrgs.Text + ", INV_CANCEL='" + Cncled + "', INV_POSTED='" + Pstsd + "' Where INV_NO = " + txtinvno.Text + ""
                End If
                cmd.ExecuteNonQuery()

                Try
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        If row.Cells("SrNo").Value.ToString = "" Then
                            cmd.CommandText = "Insert Into SALES_DETAIL Values ((Select COALESCE((Select Top 1 ENT_NO + 1 From SALES_DETAIL Order By ENT_NO Desc),1)), " + txtinvno.Text + ", '" + row.Cells("Item").Value.ToString + "', 0, '" + row.Cells("REMARKS").Value.ToString + "', '" + row.Cells("Pack").Value.ToString + "', " + row.Cells("QTY").Value.ToString + ", " + row.Cells("Price").Value.ToString + ", " + row.Cells("Disc").Value.ToString + ", GetDate())"
                        Else
                            cmd.CommandText = "Update SALES_DETAIL Set INV_NO=" + txtinvno.Text + ", ITEMCODE='" + row.Cells("Item").Value.ToString + "', PACK='" + row.Cells("Pack").Value.ToString + "', QTY=" + row.Cells("QTY").Value.ToString + ", ITM_PRICE=" + row.Cells("Price").Value.ToString + ", ITM_DISC_PER=" + row.Cells("Disc").Value.ToString + ", REMARKS='" + row.Cells("REMARKS").Value.ToString + "' Where ENT_NO=" + row.Cells("SrNo").Value.ToString + ""
                        End If
                        cmd.ExecuteNonQuery()
                    Next
                    'For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    '    If DataGridView1.Rows(i).Cells("SrNo").Value.ToString = "" Then
                    '        cmd.CommandText = "Insert Into SALES_DETAIL Values ((Select COALESCE((Select Top 1 ENT_NO + 1 From SALES_DETAIL Order By ENT_NO Desc),1)), " + txtinvno.Text + ", '" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', 0, '" + DataGridView1.Rows(i).Cells("REMARKS").Value.ToString + "', '" + DataGridView1.Rows(i).Cells("Pack").Value.ToString + "', " + DataGridView1.Rows(i).Cells("QTY").Value.ToString + ", " + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", " + DataGridView1.Rows(i).Cells("Disc").Value.ToString + ")"
                    '    Else
                    '        cmd.CommandText = "Update SALES_DETAIL Set INV_NO=" + txtinvno.Text + ", ITEMCODE='" + DataGridView1.Rows(i).Cells("Item").Value.ToString + "', PACK='" + DataGridView1.Rows(i).Cells("Pack").Value.ToString + "', QTY=" + DataGridView1.Rows(i).Cells("QTY").Value.ToString + ", ITM_PRICE=" + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", ITM_DISC_PER=" + DataGridView1.Rows(i).Cells("Disc").Value.ToString + ", REMARKS='" + DataGridView1.Rows(i).Cells("REMARKS").Value.ToString + "' Where ENT_NO=" + DataGridView1.Rows(i).Cells("SrNo").Value.ToString + ""
                    '    End If
                    '    cmd.ExecuteNonQuery()
                    'Next
                Catch ez As Exception
                End Try
                EmailMode = "Update"
                SrNo = txtinvno.Text
                If Prnt = True Then
                    xyz = txtinvno.Text
                Else
                    xyz = ""
                End If
                MsgBox("Selected Invoice Updated Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            End If
            ' Reset X Calculation In Complete Table.
            Try
                cmd.CommandText = "Update SALES_DETAIL Set Qty = convert(decimal(18,2),convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,0,CHARINDEX('x',pack,0)))) * convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,CHARINDEX('x',PACK)+1,LEN(PACK))))) Where (Pack like '%x%' or Pack like '%X%') and qty <> convert(decimal(18,2),convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,0,CHARINDEX('x',pack,0)))) * convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,CHARINDEX('x',PACK)+1,LEN(PACK)))))"
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try

            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
        End Try
        'If EmailMode <> "" Then
        '    AccessVerify.NotifyChanges(Me.Name.ToString, EmailMode, SrNo)
        'End If
        ClearAll()
        LoadItemData(0, False, "Sales")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Prnt = True
            AccessVerify.LoadingFrm(True)
            If (txtinvno.Text = "Auto Number" And DataGridView1.RowCount > 1) Or (txtinvno.Text <> "Auto Number") Then
                Button1.PerformClick()
            End If

            conn()

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd.CommandText = "Select * from View_SalesInv_Main where Inv_No = " + xyz + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_SalesInv_Main")
            cmd.CommandText = "Select * from View_SalesInv_Dtls where Inv_No = " + xyz + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_SalesInv_Dtls")

            cmd.CommandText = "Update SALES_HEADER Set INV_POSTED = 'T', INV_PRINTED = GetDate() Where  Inv_No = " + xyz + ""
            cmd.ExecuteNonQuery()
            con.Close()

            Dim cr As New OrgInvoice
            AccessVerify.LoadReports(cr, ds)

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
        Dim Qry As String = "Select INV_NO, CUST_CODE+' | '+CUST_NAME As Customer, CONVERT(VARCHAR(24), Inv_Date,100) As InvDate, LPO, NET as NetAmnt"
        If CheckBox1.Checked = True Then
            Qry = Qry + ", isnull((Select Profit From View_SalesInv_Profit Where INV_NO=View_SalesInv_Main.INV_NO),0) As Profit"
        End If
        If CheckBox2.Checked = True Then
            Qry = Qry + ", isnull((Select Collection From View_SalesCollection Where INV_NO=View_SalesInv_Main.INV_NO),0) As Collection, isnull((Select Status From View_SalesCollection Where INV_NO=View_SalesInv_Main.INV_NO),0) As Status"
        End If
        Qry = Qry + ", INV_POSTED As Posted, INV_CANCEL as Cancelled, NameMob as Salesmen from View_SalesInv_Main Order By INV_NO DESC"

        If CheckBox3.Checked = True Then
            If CheckBox1.Checked = True And CheckBox2.Checked = True Then
                AccessVerify.LoadSrchGrid("Search Invoice", Qry, Me.Name, True, "Inv_No", "txtinvno", "500", "Profit, Red, S", "Profit, Green, G", "Collection, Red, S", "Collection, Green, G")
            ElseIf CheckBox1.Checked = True And CheckBox2.Checked = False Then
                AccessVerify.LoadSrchGrid("Search Invoice", Qry, Me.Name, True, "Inv_No", "txtinvno", "500", "Profit, Red, S", "Profit, Green, G")
            ElseIf CheckBox1.Checked = False And CheckBox2.Checked = True Then
                AccessVerify.LoadSrchGrid("Search Invoice", Qry, Me.Name, True, "Inv_No", "txtinvno", "500", "Collection, Red, S", "Collection, Green, G")
            Else
                AccessVerify.LoadSrchGrid("Search Invoice", Qry, Me.Name, True, "Inv_No", "txtinvno")
            End If
        Else
            AccessVerify.LoadSrchGrid("Search Invoice", Qry, Me.Name, True, "Inv_No", "txtinvno")
        End If

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
                If e.ColumnIndex = DataGridView1.Columns("ITEMCODE").Index And AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Allow 0 Qty Invoice") = False Then
                    conn()
                    cmd.CommandText = "Select ITEM_CODE From View_StockStatusLIVE Where BalanceAll <= 0"
                    dr = cmd.ExecuteReader
                    While dr.Read
                        If dr("ITEM_CODE") = DataGridView1("ITEMCODE", e.RowIndex).Value.ToString Then
                            DataGridView1.Rows.RemoveAt(e.RowIndex)
                            dr.Close()
                            con.Close()
                            MsgBox("Quantity Not Available.", MsgBoxStyle.Critical)
                            Exit Sub
                        End If
                    End While
                    dr.Close()
                    con.Close()

                    DataGridView1("Item", e.RowIndex).Value = DataGridView1("ITEMCODE", e.RowIndex).Value.ToString
                ElseIf e.ColumnIndex = DataGridView1.Columns("ITEMCODE").Index Then
                    DataGridView1("Item", e.RowIndex).Value = DataGridView1("ITEMCODE", e.RowIndex).Value.ToString
                End If

                If e.ColumnIndex = DataGridView1.Columns("Item").Index And AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Allow 0 Qty Invoice") = False Then
                    conn()
                    cmd.CommandText = "Select ITEM_CODE From View_StockStatusLIVE Where BalanceAll <= 0"
                    dr = cmd.ExecuteReader
                    While dr.Read
                        If dr("ITEM_CODE") = DataGridView1("Item", e.RowIndex).Value.ToString Then
                            DataGridView1.Rows.RemoveAt(e.RowIndex)
                            dr.Close()
                            con.Close()
                            MsgBox("Quantity Not Available.", MsgBoxStyle.Critical)
                            Exit Sub
                        End If
                    End While
                    dr.Close()
                    con.Close()

                    DataGridView1("ITEMCODE", e.RowIndex).Value = DataGridView1("Item", e.RowIndex).Value.ToString
                    DataGridView1("ITEMCODE", e.RowIndex).Selected = True
                ElseIf e.ColumnIndex = DataGridView1.Columns("Item").Index Then
                    DataGridView1("ITEMCODE", e.RowIndex).Value = DataGridView1("Item", e.RowIndex).Value.ToString
                    DataGridView1("ITEMCODE", e.RowIndex).Selected = True
                End If

                If e.ColumnIndex = DataGridView1.Columns("Item").Index Or e.ColumnIndex = DataGridView1.Columns("ITEMCODE").Index Then
                    Try
                        conn()
                        'cmd.CommandText = "IF EXISTS (Select * from UpdatedPurcahsePrice('" + DataGridView1("Item", e.RowIndex).Value + "')) BEGIN SELECT UPChrgd As CP from UpdatedPurcahsePrice ('" + DataGridView1("Item", e.RowIndex).Value + "') END ELSE BEGIN SELECT Cost As CP From MASTER_ITEM Where ITEM_CODE = '" + DataGridView1("Item", e.RowIndex).Value + "' END"
                        cmd.CommandText = "Select ITEM_PRICE From MASTER_ITEM Where ITEM_CODE = '" + DataGridView1("Item", e.RowIndex).Value + "'"
                        dr = cmd.ExecuteReader
                        dr.Read()
                        DataGridView1("Price", e.RowIndex).Value = CType(dr("ITEM_PRICE"), String).Trim
                        dr.Close()
                        con.Close()
                        DataGridView1("Pack", e.RowIndex).Value = "1"
                    Catch ei As Exception
                        con.Close()
                    End Try
                End If
            Catch ex As Exception
                MsgBox("Select Proper Item from The List", MsgBoxStyle.Information, "H.F. General Trading CO.")
                con.Close()
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
                'For Each row As DataGridViewRow In DataGridView1.SelectedRows
                '    Dim eno As String = e.Row.Cells("SrNo").Value.ToString
                '    conn()
                '    cmd.CommandText = "Delete From SALES_DETAIL Where ENT_NO = " + e.Row.Cells("SrNo").Value.ToString + ""
                '    cmd.ExecuteNonQuery()
                '    con.Close()
                '    If eno <> "" Then
                '        LoadItemData(txtinvno.Text, True, "Sales")
                '    End If
                'Next
                Dim eno As String = e.Row.Cells("SrNo").Value.ToString
                conn()
                If Button1.Text <> "Add New Invoice" Then
                    Try
                        For Each row As DataGridViewRow In DataGridView1.Rows
                            If row.Index <> e.Row.Index Then
                                If row.Cells("SrNo").Value.ToString = "" Then
                                    cmd.CommandText = "Insert Into SALES_DETAIL Values ((Select COALESCE((Select Top 1 ENT_NO + 1 From SALES_DETAIL Order By ENT_NO Desc),1)), " + txtinvno.Text + ", '" + row.Cells("Item").Value.ToString + "', 0, '" + row.Cells("REMARKS").Value.ToString + "', '" + row.Cells("Pack").Value.ToString + "', " + row.Cells("QTY").Value.ToString + ", " + row.Cells("Price").Value.ToString + ", " + row.Cells("Disc").Value.ToString + ", GetDate())"
                                Else
                                    cmd.CommandText = "Update SALES_DETAIL Set INV_NO=" + txtinvno.Text + ", ITEMCODE='" + row.Cells("Item").Value.ToString + "', PACK='" + row.Cells("Pack").Value.ToString + "', QTY=" + row.Cells("QTY").Value.ToString + ", ITM_PRICE=" + row.Cells("Price").Value.ToString + ", ITM_DISC_PER=" + row.Cells("Disc").Value.ToString + ", REMARKS='" + row.Cells("REMARKS").Value.ToString + "' Where ENT_NO=" + row.Cells("SrNo").Value.ToString + ""
                                End If
                                cmd.ExecuteNonQuery()
                            End If
                        Next
                    Catch ez As Exception
                    End Try
                End If
                Try
                    If eno <> "" Then
                        cmd.CommandText = "Delete From SALES_DETAIL Where ENT_NO = " + eno + ""
                        cmd.ExecuteNonQuery()
                    End If
                Catch iz As Exception
                End Try
                con.Close()
                'AccessVerify.NotifyChanges(Me.Name.ToString, "Delete", txtinvno.Text)
            Else
                e.Cancel = True
                Exit Sub
            End If
            Try
                If txtinvno.Text <> "Auto Number" Then
                    Timer1.Enabled = True
                    Exit Sub
                End If
            Catch ik As Exception
            End Try
        Catch ex As Exception
            con.Close()
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
        LoadItemData(0, False, "Sales")
    End Sub

    Private Sub DataGridView1_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridView1.UserDeletedRow
        Try
            CntAmnt()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            Prnt = True
            AccessVerify.LoadingFrm(True)
            If (txtinvno.Text = "Auto Number" And DataGridView1.RowCount > 1) Or (txtinvno.Text <> "Auto Number") Then
                Button1.PerformClick()
            End If

            conn()

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd.CommandText = "Select * from View_SalesInv_Main where Inv_No = " + xyz + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_SalesInv_Main")
            cmd.CommandText = "Select * from View_SalesInv_Dtls where Inv_No = " + xyz + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_SalesInv_Dtls")

            cmd.CommandText = "Update SALES_HEADER Set INV_POSTED = 'T', INV_DCPrntd = GetDate() Where  Inv_No = " + xyz + ""
            cmd.ExecuteNonQuery()
            con.Close()

            Dim cr As New DCInvoice
            AccessVerify.LoadReports(cr, ds, MainMDI.lblFrmDtls.Text)

            xyz = ""
            Prnt = False
        Catch ex As Exception
            con.Close()
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            Prnt = True
            AccessVerify.LoadingFrm(True)
            If (txtinvno.Text = "Auto Number" And DataGridView1.RowCount > 1) Or (txtinvno.Text <> "Auto Number") Then
                Button1.PerformClick()
            End If

            conn()

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd.CommandText = "Select * from View_SalesInv_Main where Inv_No = " + xyz + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_SalesInv_Main")
            cmd.CommandText = "Select * from View_SalesInv_Dtls where Inv_No = " + xyz + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_SalesInv_Dtls")

            cmd.CommandText = "Update SALES_HEADER Set INV_POSTED = 'T', INV_CCPrntd = GetDate() Where  Inv_No = " + xyz + ""
            cmd.ExecuteNonQuery()
            con.Close()

            Dim Cr As New CashMemo
            AccessVerify.LoadReports(Cr, ds, MainMDI.lblFrmDtls.Text)

            xyz = ""
            Prnt = False
        Catch ex As Exception
            con.Close()
        End Try

    End Sub

    Protected Sub cbcust_SelectedIndexChanged()
        If cbcust.Text = "" Or Button1.Text = "Update Selected Invoice" Then
            Exit Sub
        End If

        Dim Pstd As String = ""
        If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Update") = False Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
        conn()
        cmd.CommandText = "Select Top 1 INV_NO From SALES_HEADER Where INV_Posted <> 'T' And CUST_Code = '" + cbcust.SelectedValue.ToString + "' Order By INV_NO Desc"
        dr = cmd.ExecuteReader
        If dr.Read Then
            Pstd = CType(dr("INV_NO"), String).Trim
        End If
        dr.Close()
        con.Close()

        If cbcust.SelectedValue.ToString = "786" And Pstd <> "" Then
            Pstd = ""
            MsgBox("There is an unposted INVOICE for this Customer." & vbNewLine & "But as for CASH Counter you can proceed.", MsgBoxStyle.Information, "H.F. General Trading CO.")
        End If

        If Pstd <> "" Then
            If MsgBox("There is an unposted INVOICE for this Customer." + vbNewLine + "Invoice NO. : " + Pstd + vbNewLine + "Do you want to overwrite with it ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                txtinvno.Text = Pstd
            Else
                Pstd = ""
                cbcust.Focus()
                cbcust.SelectedIndex = -1
                Exit Sub
            End If
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
            ElseIf e.ColumnIndex = DataGridView1.Columns("PurPrice").Index AndAlso e.RowIndex >= 0 Then
                AccessVerify.LoadSrchGrid("Purchase Price For : " + DataGridView1("Item", e.RowIndex).FormattedValue.ToString, "Select IGN_NO As IGN, IGNDate As Date, SLName, UnitPrice, ChrgsDiv As Chrgs, UPChrgd As CP, RecvQTY from View_UpdatedPurcahsePrice Where REC_ITM_CODE = '" + DataGridView1("Item", e.RowIndex).Value.ToString + "'  Order By IGN_NO DESC", Me.Name, False)
            ElseIf e.ColumnIndex = DataGridView1.Columns("Item").Index AndAlso e.RowIndex >= 0 Then
                TextBox1.Text = Replace(DataGridView1("Item", e.RowIndex).FormattedValue.ToString.Split("(Bal: ").Last, ")", "")
                TextBox1.Text = Replace(TextBox1.Text, "Bal: ", "")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chbposted_Click(sender As Object, e As EventArgs) Handles chbposted.Click
        Try
            If chbposted.CheckState = CheckState.Unchecked Then
                conn()
                cmd.CommandText = "Select Count(*) As cnt from SALES_HEADER Where INV_NO = " + txtinvno.Text + " And Inv_Printed Is Null"
                dr = cmd.ExecuteReader
                dr.Read()
                Dim cnt As Integer = dr("cnt")
                dr.Close()
                con.Close()
                If cnt = 0 Then
                    If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Unpost") = False Then
                        If dtpdate.Value.ToString("dd\MMM\yy") = DateTime.Now.ToString("dd\MMM\yy") Then
                            If MsgBox("Are you sure you want to unpost printed invoice !", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                                chbposted.Checked = False
                            Else
                                chbposted.Checked = True
                            End If
                        Else
                            chbposted.Checked = True
                            MsgBox("You cannot unpost this INVOICE as its already Printed.", MsgBoxStyle.Critical, "H.F. General Trading CO.")
                            Exit Sub
                        End If
                    Else
                        If MsgBox("Are you sure you want to unpost printed invoice !", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                            chbposted.Checked = False
                        Else
                            chbposted.Checked = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            con.Close()
        End Try
    End Sub

    Private Sub txtinvno_TextChanged(sender As Object, e As EventArgs) Handles txtinvno.TextChanged
        If txtinvno.Text <> "Auto Number" Then
            DataGridView1.DataSource = Nothing
            GridRowSelect()
            txtproforma.Visible = False
            BtnProforma.Visible = False
        Else
            txtproforma.Visible = True
            BtnProforma.Visible = True
        End If
    End Sub

    Private Sub BtnProforma_Click(sender As Object, e As EventArgs) Handles BtnProforma.Click
        If MsgBox("Loading Proforma will overwrite all enetered Items." + vbNewLine + "Are you sure you want to proceed." + vbNewLine + "Do you want to overwrite with it ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
            Try
                LoadItemData(txtproforma.Text, True, "Proforma")
                conn()
                cmd.CommandText = "Select * From View_Proforma_Main Where INV_NO = '" + txtproforma.Text + "'"
                dr = cmd.ExecuteReader
                If dr.Read Then
                    txtinst.Text = CType(dr("DELIVERY_NOTE"), String).Trim
                    dtpdate.Value = CType(dr("INV_DATE"), String).Trim
                    cbslsmen.SelectedValue = CType(dr("SMANCODE"), String).Trim

                    txtperc.Text = CType(dr("INV_FOOT_DISC"), String).Trim
                    txtdisc.Text = CType(dr("INV_FOOT_DISCAMT"), String).Trim
                    txtchrgs.Text = CType(dr("INV_FOOT_CHRGS"), String).Trim
                    cbcust.SelectedValue = CType(dr("CUST_CODE"), String).Trim
                End If
                dr.Close()
                con.Close()
                MsgBox("Proforma:" + txtproforma.Text + " Loaded Successfully", MsgBoxStyle.Information, "H.F. General Trading CO.")
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
            End Try
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim Qry As String = "Select INV_NO, CUST_CODE+' | '+CUST_NAME As Customer, InvDate, NET as NetAmnt, INV_POSTED As Posted, INV_CANCEL as Cancelled, NameMob as Salesmen from View_Proforma_Main Order By INV_NO DESC"
        AccessVerify.LoadSrchGrid("Search Performa\Quotation", Qry, Me.Name, False)
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
                Try
                    If CB.SelectedValue.ToString <> "" And CB.Name = "cbcust" Then
                        conn()
                        cmd.CommandText = "Select Pending From View_CustPendingAmnt Where Cust_Code = " + CB.SelectedValue.ToString + ""
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
            'If e.ColumnIndex = DataGridView1.Columns("REMARKS").Index Then
            '    RevTab = True
            'End If

            If e.ColumnIndex = DataGridView1.Columns("Price").Index And RevTab = False Then
                WishedForCell = DataGridView1.Item("ITEMCODE", e.RowIndex + 1)
                'RevTab = False
            End If
            If e.ColumnIndex = DataGridView1.Columns("REMARKS").Index And RevTab = False Then 'Or e.ColumnIndex = DataGridView1.Columns("ITEMCODE").Index Then
                WishedForCell = DataGridView1.Item("Pack", e.RowIndex)
            End If
            'If e.ColumnIndex = DataGridView1.Columns("ITEM").Index And RevTab = True Then
            '    RevTab = False
            'End If
            'If DataGridView1.IsCurrentCellDirty Or DataGridView1.IsCurrentRowDirty Or DataGridView1.IsCurrentCellInEditMode Then
            '    DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            '    DataGridView1.EndEdit()
            'End If
            'If abc <> "" Then
            '    DataGridView1("REMARKS", e.RowIndex).Value = abc
            '    DataGridView1.EndEdit()
            'End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyUp
        Try
            If Me.DataGridView1.CurrentRow.Index >= 15 Then
                Try
                    Me.DataGridView1.Rows.RemoveAt(15)
                Catch ex As Exception
                End Try
                DataGridView1.AllowUserToAddRows = False
                MsgBox("Max Item Limit Per Invoice Reached.", MsgBoxStyle.Information, "H.F. General Trading CO.")
                Exit Sub
            End If
            If WishedForCell IsNot Nothing Then
                If WishedForCell.RowIndex >= 15 Then
                    DataGridView1.AllowUserToAddRows = False
                    MsgBox("Max Item Limit Per Invoice Reached.", MsgBoxStyle.Information, "H.F. General Trading CO.")
                    WishedForCell = Nothing
                    Exit Sub
                End If
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
        'If TypeOf e.Control Is DataGridViewTextBoxEditingControl Then
        '    Dim tb As DataGridViewTextBoxEditingControl = TryCast(e.Control, DataGridViewTextBoxEditingControl)
        '    AddHandler tb.KeyDown, AddressOf DataGridView1_KeyDown
        'End If
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        Try
            MsgBox("Input\Select Proper Data." + vbNewLine + "Problem Details : " & e.Context.ToString(), MsgBoxStyle.Critical, "H.F. General Trading CO.")

            If (e.Context = DataGridViewDataErrorContexts.Commit) Or (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Or (e.Context = DataGridViewDataErrorContexts.Parsing) Or (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
                MsgBox("Input\Select Proper Data.", MsgBoxStyle.Critical, "H.F. General Trading CO.")
                Exit Sub
            End If
            If (TypeOf (e.Exception) Is ConstraintException) Then
                Dim view As DataGridView = CType(sender, DataGridView)
                view.Rows(e.RowIndex).ErrorText = "an error"
                view.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "an error"
                e.ThrowException = False
                Exit Sub
            End If
        Catch ex As Exception
            con.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        Try
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Catch ex As Exception
            con.Close()
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            Prnt = True
            AccessVerify.LoadingFrm(True)
            If (txtinvno.Text = "Auto Number" And DataGridView1.RowCount > 1) Or (txtinvno.Text <> "Auto Number") Then
                Button1.PerformClick()
            End If

            conn()

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd.CommandText = "Select * from View_SalesInv_Main where Inv_No = " + xyz + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_SalesInv_Main")
            cmd.CommandText = "Select * from View_SalesInv_Dtls where Inv_No = " + xyz + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_SalesInv_Dtls")

            cmd.CommandText = "Update SALES_HEADER Set INV_POSTED = 'T', INV_PRINTED = GetDate() Where  Inv_No = " + xyz + ""
            cmd.ExecuteNonQuery()
            con.Close()

            Dim cr As New InvoiceThermal
            AccessVerify.LoadReports(cr, ds, "Thermal")

            xyz = ""
            Prnt = False
        Catch ex As Exception
            con.Close()
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        LoadItemData(txtinvno.Text, True, "Sales")
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        Try
            '        If (e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control) Then
            '            DataGridView1.Select()
            '            DataGridView1.CurrentCell = DataGridView1(DataGridView1.CurrentCell.ColumnIndex, DataGridView1.CurrentCell.RowIndex)
            '            DataGridView1.BeginEdit(True)

            '            DataGridView1.CurrentCell.Value = DataGridView1(DataGridView1.CurrentCell.ColumnIndex, DataGridView1.CurrentCell.RowIndex - 1).Value
            '            abc = "Test"
            '            DataGridView1.EndEdit()
            '        End If
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

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Using b As New SolidBrush(DataGridView1.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

End Class