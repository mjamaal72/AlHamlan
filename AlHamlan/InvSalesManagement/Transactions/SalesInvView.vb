Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine

Public Class SalesInvView


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
#End Region

    Private Sub Me_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.SendWait("{TAB}")
        End If

        If e.Alt And e.KeyCode = Keys.P Then
            Button3.PerformClick()
        ElseIf e.Alt And e.KeyCode = Keys.X Then
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

        selectQueryString = "Select ENT_NO, ITEMCODE, REMARKS, PACK, QTY, ITM_PRICE, Gross, ITM_DISC_PER, Net, PROF_ENT_NO from View_SalesInv_Dtls WHERE INV_NO = " + pono + " Order By ENT_NO"
        sqlDataAdapter = New SqlDataAdapter(selectQueryString, sqlConnection)
        sqlCommandBuilder = New SqlCommandBuilder(sqlDataAdapter)
        dataTable = New DataTable()
        sqlDataAdapter.Fill(dataTable)
        bindingSource = New BindingSource()
        bindingSource.DataSource = dataTable

        'Item Data Source
        Dim selectQueryStringItem As String = "SELECT I.ITEM_CODE, I.ITEM_DESC + ' (Bal: '+ Case When s.BalanceAll<>s.BalancePstd Then convert(varchar,S.BalancePstd) + '\' + convert(varchar,S.BalanceAll) Else convert(varchar,S.BalanceAll) End+')' AS ItemName FROM MASTER_ITEM I INNER JOIN View_StockStatusLIVE S ON I.ITEM_CODE = S.ITEM_CODE WHERE (I.ITEM_ACTIVE = N'T')"
        Dim sqlDataAdapterItem As New SqlDataAdapter(selectQueryStringItem, sqlConnection)
        Dim sqlCommandBuilderItem As New SqlCommandBuilder(sqlDataAdapterItem)
        Dim dataTableItem As New DataTable()
        sqlDataAdapterItem.Fill(dataTableItem)
        Dim bindingSourceItem As New BindingSource()
        bindingSourceItem.DataSource = dataTableItem

        'Adding  SrNO TextBox
        Dim ColumnSrNo As New DataGridViewTextBoxColumn()
        ColumnSrNo.Name = "SrNo"
        ColumnSrNo.HeaderText = "SrNo"
        ColumnSrNo.Visible = False
        ColumnSrNo.DataPropertyName = "ENT_NO"
        DataGridView1.Columns.Add(ColumnSrNo)

        'Adding  Item Code
        Dim ColumnItemCode As New DataGridViewComboBoxColumn()
        ColumnItemCode.Name = "ITEMCODE"
        ColumnItemCode.DataPropertyName = "ITEMCODE"
        ColumnItemCode.HeaderText = "ICode"
        ColumnItemCode.Width = 90
        ColumnItemCode.DataSource = bindingSourceItem
        ColumnItemCode.ValueMember = "ITEM_CODE"
        ColumnItemCode.DisplayMember = "ITEM_CODE"
        ColumnItemCode.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        'ColumnItem.AutoComplete = True
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
        ColumnItem.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        ColumnItem.DropDownWidth = 600
        'ColumnItem.AutoComplete = True
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

        DataGridView1.DataSource = bindingSource

        sqlConnection.Close()
        CntAmnt()
        Panel1.Enabled = False
        DataGridView1.ReadOnly = True
    End Sub

    Public Sub GridRowSelect()
        Try
            LoadItemData(txtinvno.Text, True)

            conn()
            cmd.CommandText = "Select * From View_SalesInv_Main Where INV_NO = '" + txtinvno.Text + "'"
            dr = cmd.ExecuteReader
            If dr.Read Then
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
            MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
        End Try
    End Sub

    Public Sub ClearAll()
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
        LoadItemData(0, False)
    End Sub

    Private Sub GeneralLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        'AddRows()
        conn()
        cmd.CommandText = "Select Distinct convert(varchar,CUST_CODE)+' | '+CUST_NAME As CName, CUST_CODE, CUST_NAME from View_CustomerMaster Order By CUST_NAME"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_CustomerMaster")
        cbcust.DisplayMember = "CName"
        cbcust.ValueMember = "CUST_CODE"
        cbcust.DataSource = ds.Tables("View_CustomerMaster")

        cmd.CommandText = "Select SM_Code, NameMob from View_Master_Salesman Order By NameMob"
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "View_Master_Salesman")
        cbslsmen.DisplayMember = "NameMob"
        cbslsmen.ValueMember = "SM_Code"
        cbslsmen.DataSource = ds.Tables("View_Master_Salesman")
        con.Close()

        ClearAll()
        AccessVerify.LoadingFrm(False)

        Panel1.Enabled = False
        DataGridView1.ReadOnly = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AccessVerify.LoadingFrm(True)

        conn()

        Try
            cmd.CommandText = "update SALES_DETAIL Set Qty = convert(decimal(18,2),convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,0,CHARINDEX('x',pack,0)))) * convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,CHARINDEX('x',PACK)+1,LEN(PACK))))) Where (Pack like '%x%' or Pack like '%X%') and qty <> convert(decimal(18,2),convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,0,CHARINDEX('x',pack,0)))) * convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,CHARINDEX('x',PACK)+1,LEN(PACK)))))"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        cmd.CommandText = "Select * from View_SalesInv_Main where Inv_No = " + txtinvno.Text + ""
        da.SelectCommand = cmd
        da.Fill(ds, "View_SalesInv_Main")
        cmd.CommandText = "Select * from View_SalesInv_Dtls where Inv_No = " + txtinvno.Text + ""
        da.SelectCommand = cmd
        da.Fill(ds, "View_SalesInv_Dtls")

        Dim cr As New OrgInvoice
        AccessVerify.LoadReports(cr, ds)

        cmd.CommandText = "Update SALES_HEADER Set INV_POSTED = 'T', INV_PRINTED = GetDate() Where  Inv_No = " + txtinvno.Text + ""
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub txtperc_TextChanged(sender As Object, e As EventArgs) Handles txtperc.TextChanged
        Try
            txtdisc.Text = txtgross.Text * txtperc.Text / 100
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtdisc_TextChanged(sender As Object, e As EventArgs) Handles txtdisc.TextChanged
        Try
            txtnet.Text = [String].Format("{0: 0.000}", txtgross.Text - txtdisc.Text + txtchrgs.Text)
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
    '    DataGridView1("Price", e.RowIndex).ReadOnly = True
    '    If DataGridView1.CurrentCell.ColumnIndex.ToString = "1" Then
    '        DataGridView1("Item", e.RowIndex).Value = DataGridView1("ITEMCODE", e.RowIndex).Value
    '    End If
    '    If DataGridView1.CurrentCell.ColumnIndex.ToString = "1" Or DataGridView1.CurrentCell.ColumnIndex.ToString = "2" Or DataGridView1.CurrentCell.OwningColumn.Name = "Item" Or DataGridView1.CurrentCell.OwningColumn.Name = "ITEMCODE" Then
    '        Try
    '            conn()
    '            ' cmd.CommandText = "IF EXISTS (Select * from UpdatedPurcahsePrice('" + DataGridView1("Item", e.RowIndex).Value + "')) BEGIN SELECT UPChrgd As CP from UpdatedPurcahsePrice ('" + DataGridView1("Item", e.RowIndex).Value + "') END ELSE BEGIN SELECT Cost As CP From MASTER_ITEM Where ITEM_CODE = '" + DataGridView1("Item", e.RowIndex).Value + "' END"
    '            cmd.CommandText = "Select ITEM_PRICE From MASTER_ITEM Where ITEM_CODE = '" + DataGridView1("Item", e.RowIndex).Value + "'"
    '            dr = cmd.ExecuteReader
    '            dr.Read()
    '            DataGridView1("Price", e.RowIndex).Value = CType(dr("ITEM_PRICE"), String).Trim
    '            dr.Close()
    '            con.Close()
    '            DataGridView1("Pack", e.RowIndex).Value = "1"
    '        Catch ei As Exception
    '        End Try
    '    End If

    '    Try
    '        Try
    '            DataGridView1("Gross", e.RowIndex).Value = [String].Format("{0:0.000}", DataGridView1("QTY", e.RowIndex).Value * DataGridView1("Price", e.RowIndex).Value)
    '        Catch ez As Exception
    '            DataGridView1("QTY", e.RowIndex).Value = "1"
    '            DataGridView1("Gross", e.RowIndex).Value = [String].Format("{0:0.000}", DataGridView1("QTY", e.RowIndex).Value * DataGridView1("Price", e.RowIndex).Value)
    '        End Try
    '        Try
    '            DataGridView1("Net", e.RowIndex).Value = [String].Format("{0:0.000}", DataGridView1("Gross", e.RowIndex).Value - (DataGridView1("Gross", e.RowIndex).Value * DataGridView1("Disc", e.RowIndex).Value / 100))
    '        Catch ey As Exception
    '            DataGridView1("Disc", e.RowIndex).Value = "0"
    '            DataGridView1("Net", e.RowIndex).Value = [String].Format("{0:0.000}", DataGridView1("Gross", e.RowIndex).Value - (DataGridView1("Gross", e.RowIndex).Value * DataGridView1("Disc", e.RowIndex).Value / 100))
    '        End Try
    '        CntAmnt()
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim b As New Bitmap(Panel1.Width, Panel1.Height)
        Panel1.DrawToBitmap(b, Panel1.ClientRectangle)

        e.Graphics.DrawImage(b, New Point(0, 0))
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        AccessVerify.LoadingFrm(True)
        conn()

        Try
            cmd.CommandText = "update SALES_DETAIL Set Qty = convert(decimal(18,2),convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,0,CHARINDEX('x',pack,0)))) * convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,CHARINDEX('x',PACK)+1,LEN(PACK))))) Where (Pack like '%x%' or Pack like '%X%') and qty <> convert(decimal(18,2),convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,0,CHARINDEX('x',pack,0)))) * convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,CHARINDEX('x',PACK)+1,LEN(PACK)))))"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        cmd.CommandText = "Select * from View_SalesInv_Main where Inv_No = " + txtinvno.Text + ""
        da.SelectCommand = cmd
        da.Fill(ds, "View_SalesInv_Main")
        cmd.CommandText = "Select * from View_SalesInv_Dtls where Inv_No = " + txtinvno.Text + ""
        da.SelectCommand = cmd
        da.Fill(ds, "View_SalesInv_Dtls")

        Dim cr As New DCInvoice
        AccessVerify.LoadReports(cr, ds, MainMDI.lblFrmDtls.Text)

        cmd.CommandText = "Update SALES_HEADER Set INV_DCPrntd = GetDate() Where  Inv_No = " + txtinvno.Text + ""
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        AccessVerify.LoadingFrm(True)
        conn()

        Try
            cmd.CommandText = "update SALES_DETAIL Set Qty = convert(decimal(18,2),convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,0,CHARINDEX('x',pack,0)))) * convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,CHARINDEX('x',PACK)+1,LEN(PACK))))) Where (Pack like '%x%' or Pack like '%X%') and qty <> convert(decimal(18,2),convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,0,CHARINDEX('x',pack,0)))) * convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,CHARINDEX('x',PACK)+1,LEN(PACK)))))"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        cmd.CommandText = "Select * from View_SalesInv_Main where Inv_No = " + txtinvno.Text + ""
        da.SelectCommand = cmd
        da.Fill(ds, "View_SalesInv_Main")
        cmd.CommandText = "Select * from View_SalesInv_Dtls where Inv_No = " + txtinvno.Text + ""
        da.SelectCommand = cmd
        da.Fill(ds, "View_SalesInv_Dtls")

        Dim Cr As New CashMemo
        AccessVerify.LoadReports(Cr, ds, MainMDI.lblFrmDtls.Text)

        cmd.CommandText = "Update SALES_HEADER Set INV_CCPrntd = GetDate() Where  Inv_No = " + txtinvno.Text + ""
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = DataGridView1.Columns("PrePrice").Index AndAlso e.RowIndex >= 0 Then
            AccessVerify.LoadSrchGrid("Previuos Price For : " + DataGridView1("Item", e.RowIndex).FormattedValue.ToString, "Select INV_NO, INV_DATE, ITM_PRICE As UnitPrice, ITM_DISC_PER As DiscPer from View_SalesInv_Dtls Where ITEMCODE = '" + DataGridView1("Item", e.RowIndex).Value.ToString + "' And Cust_Code = '" + cbcust.SelectedValue.ToString + "' Order By INV_NO DESC", Me.Name, False)
        ElseIf e.ColumnIndex = DataGridView1.Columns("PurPrice").Index AndAlso e.RowIndex >= 0 Then
            AccessVerify.LoadSrchGrid("Purchase Price For : " + DataGridView1("Item", e.RowIndex).FormattedValue.ToString, "Select IGN_NO As IGN, IGNDate As Date, UnitPrice, ChrgsDiv As Chrgs, UPChrgd As CP, RecvQTY from View_UpdatedPurcahsePrice Where REC_ITM_CODE = '" + DataGridView1("Item", e.RowIndex).Value.ToString + "'  Order By IGN_NO DESC", Me.Name, False)
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        AccessVerify.LoadingFrm(True)

        conn()

        Try
            cmd.CommandText = "update SALES_DETAIL Set Qty = convert(decimal(18,2),convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,0,CHARINDEX('x',pack,0)))) * convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,CHARINDEX('x',PACK)+1,LEN(PACK))))) Where (Pack like '%x%' or Pack like '%X%') and qty <> convert(decimal(18,2),convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,0,CHARINDEX('x',pack,0)))) * convert(decimal(18,2),dbo.regexReplace(SUBSTRING(pack,CHARINDEX('x',PACK)+1,LEN(PACK)))))"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        cmd.CommandText = "Select * from View_SalesInv_Main where Inv_No = " + txtinvno.Text + ""
        da.SelectCommand = cmd
        da.Fill(ds, "View_SalesInv_Main")
        cmd.CommandText = "Select * from View_SalesInv_Dtls where Inv_No = " + txtinvno.Text + ""
        da.SelectCommand = cmd
        da.Fill(ds, "View_SalesInv_Dtls")

        Dim cr As New InvoiceThermal
        AccessVerify.LoadReports(cr, ds)

        cmd.CommandText = "Update SALES_HEADER Set INV_POSTED = 'T', INV_PRINTED = GetDate() Where  Inv_No = " + txtinvno.Text + ""
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub txtinvno_TextChanged(sender As Object, e As EventArgs) Handles txtinvno.TextChanged
        If txtinvno.Text <> "Auto Number" Then
            DataGridView1.DataSource = Nothing
            GridRowSelect()
        End If
    End Sub

    Private Sub cbcust_LostFocus(sender As Object, e As EventArgs) Handles cbcust.LostFocus
        Try
            If cbcust.Items.Contains(cbcust.Text) = False And cbcust.SelectedValue = Nothing Then
                cbcust.SelectedValue = cbcust.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class