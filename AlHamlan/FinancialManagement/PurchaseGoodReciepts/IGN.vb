Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine

Public Class IGN

#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da, da2 As SqlDataAdapter
    Dim ds, ds2 As DataSet
    Dim iRec As Integer
    Dim Splr, Pono As String
    
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
    Dim XYZ As String
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
        ElseIf e.Alt And e.KeyCode = Keys.M Then
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
        txtcnt.Text = CellSum("RecvQTY").ToString()
        txtgross.Text = [String].Format("{0:0.000}", CellSum("NET"))
    End Sub

    Public Sub LoadItemData(IGNNo As String, editmode As Boolean, QueryMode As String)
        DataGridView1.Columns.Clear()
        DataGridView1.DataSource = Nothing
        Dim abc As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLibrary.dll")
        connectionString = abc
        sqlConnection = New SqlConnection(connectionString)
        sqlConnection.Open()

        'DataGridView Source
        If QueryMode = "NewIGN" Then
            selectQueryString = "Select 0 As REC_ENT_NO, Pur_Ent_No AS REC_PO_ENT_NO, PUR_ITM_CODE+'|'+ITEM_DESC+ ' (Bal: '+ (Select Case When BalanceAll<>BalancePstd Then convert(varchar,BalancePstd) + '\' + convert(varchar,BalanceAll) Else convert(varchar,BalanceAll) End From View_StockStatusLIVE Where ITEM_CODE = View_PO_Dtls.PUR_ITM_CODE)+')' As ItemName, PUR_Pack As REC_PACK, PUR_QTY_ORDERED As DmdQTY, PUR_QTY_ORDERED As RecvQTY, 0 As CnclQTY, PUR_ITM_FRN_PRICE as REC_ITM_FRN_PRICE, GROSS, PUR_ITM_DISC As REC_ITM_DISC, NET from View_PO_Dtls WHERE PUR_ORDER_NO = " + IGNNo + " Order By Pur_Ent_No"
        ElseIf QueryMode = "MergeNewFromPO" Then
            'selectQueryString = "Select REC_ENT_NO, REC_PO_ENT_NO, REC_ITM_CODE+'|'+ITEM_DESC As ItemName, REC_PACK, REC_INV_QTY As DmdQTY, REC_RECEIVED_QTY As RecvQTY, REC_CANCEL_QTY As CnclQTY, REC_ITM_FRN_PRICE, GROSS, REC_ITM_DISC, NET from View_IGN_Dtls WHERE IGN_NO = " + IGNNo + " Order By REC_ENT_NO"
            selectQueryString = "Select REC_ENT_NO, REC_PO_ENT_NO, REC_ITM_CODE+'|'+ITEM_DESC+ ' (Bal: '+ (Select Case When BalanceAll<>BalancePstd Then convert(varchar,BalancePstd) + '\' + convert(varchar,BalanceAll) Else convert(varchar,BalanceAll) End From View_StockStatusLIVE Where ITEM_CODE = View_IGN_Dtls.REC_ITM_CODE)+')' As ItemName, REC_PACK, REC_INV_QTY As DmdQTY, REC_RECEIVED_QTY As RecvQTY, REC_CANCEL_QTY As CnclQTY, REC_ITM_FRN_PRICE, GROSS, REC_ITM_DISC, NET from View_IGN_Dtls WHERE IGN_NO = " + IGNNo + " Union Select 0 As REC_ENT_NO, Pur_Ent_No AS REC_PO_ENT_NO, PUR_ITM_CODE+'|'+ITEM_DESC+ ' (Bal: '+ (Select Case When BalanceAll<>BalancePstd Then convert(varchar,BalancePstd) + '\' + convert(varchar,BalanceAll) Else convert(varchar,BalanceAll) End From View_StockStatusLIVE Where ITEM_CODE = View_PO_Dtls.PUR_ITM_CODE)+')' As ItemName, PUR_Pack As REC_PACK, PUR_QTY_ORDERED As DmdQTY, PUR_QTY_ORDERED As RecvQTY, 0 As CnclQTY, PUR_ITM_FRN_PRICE as REC_ITM_FRN_PRICE, GROSS, PUR_ITM_DISC As REC_ITM_DISC, NET from View_PO_Dtls WHERE PUR_ORDER_NO = (Select Pur_NO From IGN_HEADER Where IGN_NO = " + IGNNo + ") And Pur_Ent_No Not In (Select REC_PO_ENT_NO from View_IGN_Dtls WHERE IGN_NO = " + IGNNo + ")"
        Else
            selectQueryString = "Select REC_ENT_NO, REC_PO_ENT_NO, REC_ITM_CODE+'|'+ITEM_DESC+ ' (Bal: '+ (Select Case When BalanceAll<>BalancePstd Then convert(varchar,BalancePstd) + '\' + convert(varchar,BalanceAll) Else convert(varchar,BalanceAll) End From View_StockStatusLIVE Where ITEM_CODE = View_IGN_Dtls.REC_ITM_CODE)+')' As ItemName, REC_PACK, REC_INV_QTY As DmdQTY, REC_RECEIVED_QTY As RecvQTY, REC_CANCEL_QTY As CnclQTY, REC_ITM_FRN_PRICE, GROSS, REC_ITM_DISC, NET from View_IGN_Dtls WHERE IGN_NO = " + IGNNo + " Order By REC_ENT_NO"
        End If
        sqlDataAdapter = New SqlDataAdapter(selectQueryString, sqlConnection)
        sqlCommandBuilder = New SqlCommandBuilder(sqlDataAdapter)
        dataTable = New DataTable()
        sqlDataAdapter.Fill(dataTable)
        bindingSource = New BindingSource()
        bindingSource.DataSource = dataTable

        'Adding  SrNO TextBox
        Dim ColumnSrNo As New DataGridViewTextBoxColumn()
        ColumnSrNo.Name = "SrNo"
        ColumnSrNo.HeaderText = "SrNo"
        ColumnSrNo.Width = 15
        ColumnSrNo.Visible = False
        ColumnSrNo.DataPropertyName = "REC_ENT_NO"
        DataGridView1.Columns.Add(ColumnSrNo)

        'Adding  PO SrNO TextBox
        Dim ColumnPSrNo As New DataGridViewTextBoxColumn()
        ColumnPSrNo.Name = "PSrNo"
        ColumnPSrNo.HeaderText = "PSrNo"
        ColumnPSrNo.Width = 15
        ColumnPSrNo.Visible = False
        ColumnPSrNo.DataPropertyName = "REC_PO_ENT_NO"
        DataGridView1.Columns.Add(ColumnPSrNo)

        'Adding  Item TextBox
        Dim ColumnItem As New DataGridViewTextBoxColumn()
        ColumnItem.Name = "Item"
        ColumnItem.HeaderText = "Item"
        ColumnItem.Width = 550
        ColumnItem.DataPropertyName = "ItemName"
        ColumnItem.ReadOnly = True
        DataGridView1.Columns.Add(ColumnItem)

        'Adding  Pack TextBox
        Dim ColumnPack As New DataGridViewTextBoxColumn()
        ColumnPack.Name = "Pack"
        ColumnPack.HeaderText = "Pack"
        ColumnPack.Width = 40
        ColumnPack.DataPropertyName = "REC_PACK"
        DataGridView1.Columns.Add(ColumnPack)

        'Adding  DmdQTY TextBox
        Dim ColumnDQty As New DataGridViewTextBoxColumn()
        ColumnDQty.Name = "DmdQTY"
        ColumnDQty.HeaderText = "DmdQTY"
        ColumnDQty.Width = 70
        ColumnDQty.DataPropertyName = "DmdQTY"
        ColumnDQty.ReadOnly = True
        DataGridView1.Columns.Add(ColumnDQty)

        'Adding  RecvQTY TextBox
        Dim ColumnRQty As New DataGridViewTextBoxColumn()
        ColumnRQty.Name = "RecvQTY"
        ColumnRQty.HeaderText = "RecvQTY"
        ColumnRQty.Width = 70
        ColumnRQty.DataPropertyName = "RecvQTY"
        DataGridView1.Columns.Add(ColumnRQty)

        'Adding  CnclQTY TextBox
        Dim ColumnCQty As New DataGridViewTextBoxColumn()
        ColumnCQty.Name = "CnclQTY"
        ColumnCQty.HeaderText = "CnclQTY"
        ColumnCQty.Width = 70
        ColumnCQty.DataPropertyName = "CnclQTY"
        DataGridView1.Columns.Add(ColumnCQty)

        'Adding  Price TextBox
        Dim ColumnPrc As New DataGridViewTextBoxColumn()
        ColumnPrc.Name = "Price"
        ColumnPrc.HeaderText = "Price"
        ColumnPrc.Width = 70
        ColumnPrc.ReadOnly = True
        ColumnPrc.DataPropertyName = "REC_ITM_FRN_PRICE"
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
        ColumnDisc.Width = 70
        ColumnDisc.DataPropertyName = "REC_ITM_DISC"
        DataGridView1.Columns.Add(ColumnDisc)

        'Adding  Net TextBox
        Dim ColumnNet As New DataGridViewTextBoxColumn()
        ColumnNet.Name = "NET"
        ColumnNet.HeaderText = "NET"
        ColumnNet.Width = 80
        ColumnNet.DataPropertyName = "NET"
        ColumnNet.ReadOnly = True
        DataGridView1.Columns.Add(ColumnNet)

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
            LoadItemData(txtign.Text, True, "")
            Splr = ""

            conn()
            cmd.CommandText = "Select * From View_IGN_Main Where IGN_NO = '" + txtign.Text + "'"
            dr = cmd.ExecuteReader
            If dr.Read Then
                txtign.Text = CType(dr("IGN_NO"), String).Trim
                txtnotes.Text = CType(dr("Remarks"), String).Trim
                txtinvno.Text = CType(dr("INVOICE_NO"), String).Trim
                dtpdate.Value = CType(dr("REC_DATE"), String).Trim
                Splr = CType(dr("SL_CODE"), String).Trim
                Pono = CType(dr("PUR_NO"), String).Trim
                dtpinvdate.Value = CType(dr("INVOICE_DATE"), String).Trim
                If CType(dr("REC_POSTED"), String).Trim = "T" Then
                    chbignpost.Checked = True
                Else
                    chbignpost.Checked = False
                End If
                txtperc.Text = CType(dr("REC_FOOT_DISC_PER"), String).Trim
                txtdisc.Text = CType(dr("REC_FOOT_DISC"), String).Trim
                txtchrgs.Text = CType(dr("REC_FOOT_CHARGES"), String).Trim
                txtadjust.Text = CType(dr("REC_FOOT_ADJUST"), String).Trim
            End If
            dr.Close()
            con.Close()

            If Splr <> "" Then
                Button1.Text = "Update Selected IGN"
            End If
            cbsuplr.SelectedValue = Splr
            cbsuplr.AllowDrop = False
            cbpono.SelectedValue = Pono
            cbpono.AllowDrop = False
            cbsuplr.DropDownStyle = ComboBoxStyle.Simple
            cbpono.DropDownStyle = ComboBoxStyle.Simple

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
        Button1.Text = "Add New IGN"
        txtign.Text = "Auto Number"
        txtnotes.Text = ""
        txtgross.Text = "0" '
        dtpdate.Value = Date.Now
        txtinvno.Text = ""
        cbpono.SelectedIndex = -1
        chbpopost.Checked = False
        chbignpost.Checked = False
        txtperc.Text = "0"
        txtdisc.Text = "0"
        txtchrgs.Text = "0"
        txtnet.Text = "0"
        txtinvnet.Text = "0"
        txtadjust.Text = "0"
        cbsuplr.DropDownStyle = ComboBoxStyle.DropDown
        cbpono.DropDownStyle = ComboBoxStyle.DropDown

        conn()
        cmd.CommandText = "Select  Distinct SL_Code+' | '+SL_NAME As SlName, SL_Code from View_PO_Dtls Where PUR_ENT_NO Not in (Select rec_po_ent_no from View_IGN_Dtls) Or PUR_ENT_NO in (Select rec_po_ent_no from View_IGN_Dtls where REC_INV_QTY-(REC_RECEIVED_QTY + REC_CANCEL_QTY)>0)"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_PO_Dtls")
        cbsuplr.DisplayMember = "SlName"
        cbsuplr.ValueMember = "SL_Code"
        cbsuplr.DataSource = ds.Tables("View_PO_Dtls")
        cbsuplr.Text = ""
        cbsuplr.SelectedIndex = -1
        con.Close()
        ChbCash.Focus()
        LoadItemData(0, False, "")
    End Sub

    Private Sub ME_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        ClearAll()
        AddHandler cbsuplr.SelectedIndexChanged, AddressOf cbsuplr_SelectedIndexChanged
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SrNo As String = ""
        Dim EmailMode As String = ""
        Try
            Dim Pstsd, IGNID, CashIGN As String
            If chbignpost.Checked = True Then
                Pstsd = "T"
            Else
                Pstsd = "F"
            End If
            If ChbCash.Checked = True Then
                CashIGN = "1"
            Else
                CashIGN = "0"
            End If
            conn()
            If Button1.Text = "Add New IGN" Then
                Try
                    cmd.CommandText = "Insert Into IGN_HEADER Values ((Select COALESCE((Select Top 1 IGN_NO + 1 From IGN_HEADER Order By IGN_NO Desc),1)), " + cbpono.SelectedValue.ToString + ", '" + txtinvno.Text + "', '" + dtpinvdate.Value.ToString + "', " + txtinvnet.Text + ",'" + dtpdate.Value.ToString + "', " + txtdisc.Text + ", " + txtperc.Text + ", " + txtchrgs.Text + ", " + txtadjust.Text + ", 'T',  '" + txtnotes.Text + "'," + MainMDI.lblUID.Text + ", Null, " + CashIGN + ")"
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    con.Close()
                    MsgBox("Cannot Create New IGN. Enter Details Properly.", MsgBoxStyle.Critical, "H.F. General Trading CO.")
                    Exit Sub
                End Try

                cmd.CommandText = "Select Top 1 IGN_NO From IGN_HEADER Order By IGN_NO Desc"
                dr = cmd.ExecuteReader
                If dr.Read Then
                    IGNID = CType(dr("IGN_NO"), String).Trim
                    XYZ = CType(dr("IGN_NO"), String).Trim
                Else
                    IGNID = "1"
                    XYZ = "1"
                End If
                dr.Close()

                Try
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        Dim absString As String() = DataGridView1.Rows(i).Cells("Item").Value.ToString.Split("|")
                        cmd.CommandText = "Insert Into IGN_DTLS Values ((Select COALESCE((Select Top 1 REC_ENT_NO + 1 From IGN_DTLS Order By REC_ENT_NO Desc),1)), " + IGNID + ", " + DataGridView1.Rows(i).Cells("PSrNo").Value.ToString + ", '" + absString(0) + "', " + DataGridView1.Rows(i).Cells("Pack").Value.ToString + ", " + DataGridView1.Rows(i).Cells("RecvQTY").Value.ToString + ", '" + DataGridView1.Rows(i).Cells("Price").Value.ToString + "', " + DataGridView1.Rows(i).Cells("Disc").Value.ToString + ")"
                        cmd.ExecuteNonQuery()
                        If DataGridView1.Rows(i).Cells("CnclQTY").Value.ToString <> "" And DataGridView1.Rows(i).Cells("CnclQTY").Value.ToString <> "0" Then
                            cmd.CommandText = "Update PURCHASE_DETAIL Set PUR_QTY_CANCELLED = " + DataGridView1.Rows(i).Cells("CnclQTY").Value.ToString + " Where PUR_ENT_NO = " + DataGridView1.Rows(i).Cells("PSrNo").Value.ToString
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                Catch ez As Exception
                End Try
                EmailMode = "Add"
                MsgBox("New IGNID Added Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            Else
                cmd.CommandText = "Update IGN_HEADER SET INVOICE_NO = '" + txtinvno.Text + "', INVOICE_DATE = '" + dtpinvdate.Value.ToString + "', INV_NET = " + txtinvnet.Text + ", REC_FOOT_DISC = " + txtdisc.Text + ", REC_FOOT_DISC_PER = " + txtperc.Text + ", REC_FOOT_CHARGES = " + txtchrgs.Text + ", REC_FOOT_ADJUST = " + txtadjust.Text + ", REC_POSTED = '" + Pstsd + "', Remarks = '" + txtnotes.Text + "', CashIGN = " + CashIGN + ", REC_DATE = '" + dtpdate.Value.ToString + "' Where IGN_NO = " + txtign.Text + ""
                cmd.ExecuteNonQuery()
                Try
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        If DataGridView1.Rows(i).Cells("SrNo").Value.ToString = "0" Then
                            Dim absString As String() = DataGridView1.Rows(i).Cells("Item").Value.ToString.Split("|")
                            cmd.CommandText = "Insert Into IGN_DTLS Values ((Select COALESCE((Select Top 1 REC_ENT_NO + 1 From IGN_DTLS Order By REC_ENT_NO Desc),1)), " + txtign.Text + ", " + DataGridView1.Rows(i).Cells("PSrNo").Value.ToString + ", '" + absString(0) + "', " + DataGridView1.Rows(i).Cells("Pack").Value.ToString + ", " + DataGridView1.Rows(i).Cells("RecvQTY").Value.ToString + ", '" + DataGridView1.Rows(i).Cells("Price").Value.ToString + "', " + DataGridView1.Rows(i).Cells("Disc").Value.ToString + ")"
                        Else
                            cmd.CommandText = "Update IGN_DTLS Set REC_PACK=" + DataGridView1.Rows(i).Cells("Pack").Value.ToString + ", REC_RECEIVED_QTY=" + DataGridView1.Rows(i).Cells("RecvQTY").Value.ToString + ", REC_ITM_FRN_PRICE=" + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", REC_ITM_DISC=" + DataGridView1.Rows(i).Cells("Disc").Value.ToString + " Where REC_ENT_NO=" + DataGridView1.Rows(i).Cells("SrNo").Value.ToString + ""
                        End If
                        cmd.ExecuteNonQuery()
                        If DataGridView1.Rows(i).Cells("CnclQTY").Value.ToString <> "" And DataGridView1.Rows(i).Cells("CnclQTY").Value.ToString <> "0" Then
                            cmd.CommandText = "Update PURCHASE_DETAIL Set PUR_QTY_CANCELLED = " + DataGridView1.Rows(i).Cells("CnclQTY").Value.ToString + " Where PUR_ENT_NO = " + DataGridView1.Rows(i).Cells("PSrNo").Value.ToString
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                Catch ez As Exception
                End Try
                EmailMode = "Update"
                SrNo = txtign.Text
                XYZ = txtign.Text
                MsgBox("Selected IGN Updated Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
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
        LoadItemData(0, False, "")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AccessVerify.LoadingFrm(True)
        If (txtign.Text = "Auto Number" And DataGridView1.RowCount > 1) Or (txtign.Text <> "Auto Number") Then
            Button1.PerformClick()
        End If

        conn()

        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        cmd.CommandText = "Select * from View_IGN_Main where IGN_No = " + XYZ + ""
        da.SelectCommand = cmd
        da.Fill(ds, "View_IGN_Main")
        cmd.CommandText = "Select * from View_IGN_Dtls where IGN_No = " + XYZ + ""
        da.SelectCommand = cmd
        da.Fill(ds, "View_IGN_Dtls")

        Dim cr As New PrntIGN
        AccessVerify.LoadReports(cr, ds, MainMDI.lblFrmDtls.Text)

        cmd.CommandText = "Update IGN_HEADER Set REC_POSTED = 'T', Prntd = GetDate() Where IGN_NO = " + XYZ + ""
        cmd.ExecuteNonQuery()
        con.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AccessVerify.LoadSrchGrid("Search Incoming Goods Notes", "Select IGN_No, SL_CODE+' | '+SL_NAME As Supplier, IGNDate, Net, Rec_POSTED As Posted from View_IGN_Main Order By IGN_No DESC", Me.Name, True, "IGN_No", "txtign")
    End Sub

    Private Sub txtperc_TextChanged(sender As Object, e As EventArgs) Handles txtperc.TextChanged
        Try
            txtdisc.Text = txtgross.Text * txtperc.Text / 100
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtdisc_TextChanged(sender As Object, e As EventArgs) Handles txtdisc.TextChanged, txtchrgs.TextChanged, txtgross.TextChanged, txtadjust.TextChanged
        Try
            txtnet.Text = [String].Format("{0:0.000}", txtgross.Text - txtdisc.Text + txtchrgs.Text + txtadjust.Text)
            txtinvnet.Text = [String].Format("{0:0.000}", txtgross.Text - txtdisc.Text + txtchrgs.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        DataGridView1("Price", e.RowIndex).ReadOnly = True
        If DataGridView1.CurrentCell.ColumnIndex.ToString = "1" Then
            Try
                conn()
                cmd.CommandText = "Select * from View_Master_Items Where ITEM_CODE = '" + DataGridView1("Item", e.RowIndex).Value + "'"
                dr = cmd.ExecuteReader
                dr.Read()
                DataGridView1("Price", e.RowIndex).Value = CType(dr("Cost"), String).Trim
                dr.Close()
                con.Close()
                DataGridView1("Pack", e.RowIndex).Value = "1"
            Catch ei As Exception
            End Try
        End If

        Try
            Try
                DataGridView1("Gross", e.RowIndex).Value = [String].Format("{0:0.000}", DataGridView1("RecvQTY", e.RowIndex).Value * DataGridView1("Price", e.RowIndex).Value)
            Catch ez As Exception
                DataGridView1("RecvQTY", e.RowIndex).Value = "1"
                DataGridView1("Gross", e.RowIndex).Value = [String].Format("{0:0.000}", DataGridView1("RecvQTY", e.RowIndex).Value * DataGridView1("Price", e.RowIndex).Value)
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
        CntAmnt()
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
                If Button1.Text <> "Add New IGN" Then
                    Try
                        For i As Integer = 0 To DataGridView1.Rows.Count - 1
                            If DataGridView1.Rows(i).Cells("SrNo").Value.ToString = "0" Then
                                Dim absString As String() = DataGridView1.Rows(i).Cells("Item").Value.ToString.Split("|")
                                cmd.CommandText = "Insert Into IGN_DTLS Values ((Select COALESCE((Select Top 1 REC_ENT_NO + 1 From IGN_DTLS Order By REC_ENT_NO Desc),1)), " + txtign.Text + ", " + DataGridView1.Rows(i).Cells("PSrNo").Value.ToString + ", '" + absString(0) + "', " + DataGridView1.Rows(i).Cells("Pack").Value.ToString + ", " + DataGridView1.Rows(i).Cells("RecvQTY").Value.ToString + ", '" + DataGridView1.Rows(i).Cells("Price").Value.ToString + "', " + DataGridView1.Rows(i).Cells("Disc").Value.ToString + ")"
                            Else
                                cmd.CommandText = "Update IGN_DTLS Set REC_PACK=" + DataGridView1.Rows(i).Cells("Pack").Value.ToString + ", REC_RECEIVED_QTY=" + DataGridView1.Rows(i).Cells("RecvQTY").Value.ToString + ", REC_ITM_FRN_PRICE=" + DataGridView1.Rows(i).Cells("Price").Value.ToString + ", REC_ITM_DISC=" + DataGridView1.Rows(i).Cells("Disc").Value.ToString + " Where REC_ENT_NO=" + DataGridView1.Rows(i).Cells("SrNo").Value.ToString + ""
                            End If
                            cmd.ExecuteNonQuery()
                            If DataGridView1.Rows(i).Cells("CnclQTY").Value.ToString <> "" And DataGridView1.Rows(i).Cells("CnclQTY").Value.ToString <> "0" Then
                                cmd.CommandText = "Update PURCHASE_DETAIL Set PUR_QTY_CANCELLED = " + DataGridView1.Rows(i).Cells("CnclQTY").Value.ToString + " Where PUR_ENT_NO = " + DataGridView1.Rows(i).Cells("PSrNo").Value.ToString
                                cmd.ExecuteNonQuery()
                            End If
                        Next
                    Catch ez As Exception
                    End Try
                End If

                cmd.CommandText = "Delete From IGN_DTLS Where REC_ENT_NO = " + eno + ""
                cmd.ExecuteNonQuery()
                If eno <> "" Then
                    LoadItemData(txtign.Text, True, "")
                End If
                AccessVerify.NotifyChanges(Me.Name.ToString, "Delete", txtinvno.Text)
            End If
            e.Cancel = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chbignpost_CheckedChanged(sender As Object, e As EventArgs) Handles chbignpost.CheckedChanged
        If chbignpost.Checked = True Then
            Panel1.Enabled = False
            DataGridView1.ReadOnly = True
        Else
            Panel1.Enabled = True
            DataGridView1.ReadOnly = False
            DataGridView1.Columns("Item").ReadOnly = True
            DataGridView1.Columns("DmdQty").ReadOnly = True
            DataGridView1.Columns("PRICE").ReadOnly = True
            DataGridView1.Columns("GROSS").ReadOnly = True
            DataGridView1.Columns("NET").ReadOnly = True
        End If
    End Sub

    Private Sub cbsuplr_SelectedIndexChanged(sender As Object, e As EventArgs)
        conn()
        If Button1.Text = "Update Selected IGN" Then
            cmd.CommandText = "Select distinct PUR_ORDER_NO from View_PO_Dtls Where SL_CODE = '" + cbsuplr.SelectedValue + "'"
        Else
            cmd.CommandText = "Select distinct PUR_ORDER_NO from View_PO_Dtls Where (PUR_ENT_NO Not in (Select rec_po_ent_no from View_IGN_Dtls) Or PUR_ENT_NO in (Select rec_po_ent_no from View_IGN_Dtls where REC_INV_QTY-(REC_RECEIVED_QTY + REC_CANCEL_QTY)>0)) and SL_CODE = '" + cbsuplr.SelectedValue + "'"
        End If
        da = New SqlDataAdapter(cmd)
        ds2 = New DataSet
        da.Fill(ds2, "View_PO_Dtls")
        cbpono.DisplayMember = "PUR_ORDER_NO"
        cbpono.ValueMember = "PUR_ORDER_NO"
        cbpono.DataSource = ds2.Tables("View_PO_Dtls")
        con.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Panel2.Visible = False Then
            Panel2.Visible = True
        Else
            Panel2.Visible = False
        End If
    End Sub

    Private Sub cbpono_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbpono.SelectedIndexChanged
        Try
            If txtign.Text = "Auto Number" Then
                LoadItemData(cbpono.SelectedValue.ToString, True, "NewIGN")
            End If
            conn()
            cmd.CommandText = "Select * from View_PO_Main Where PUR_ORDER_NO = " + cbpono.SelectedValue.ToString + ""
            dr = cmd.ExecuteReader
            dr.Read()
            If CType(dr("PUR_POSTED"), String).Trim = "T" Then
                chbpopost.Checked = True
            Else
                chbpopost.Checked = False
            End If
            txtponet.Text = CType(dr("PUR_NET_VALUE"), String).Trim
            txtpocrncy.Text = CType(dr("CUR_DESC"), String).Trim
            txtpotype.Text = CType(dr("PAY_DESC"), String).Trim
            txtpodiv.Text = CType(dr("PUR_DIV"), String).Trim
            txtpogross.Text = CType(dr("PUR_GROSS_VALUE"), String).Trim
            txtLnkIGN.Text = CType(dr("IGNList"), String).Trim
            dr.Close()
            con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ClearAll()
        LoadItemData(0, False, "")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        LoadItemData(txtign.Text, True, "MergeNewFromPO")
    End Sub

    Private Sub DataGridView1_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridView1.UserDeletedRow
        CntAmnt()
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        If DataGridView1.CurrentCell.ColumnIndex.ToString = "7" Then
            If MsgBox("Are you sure you want to change price ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                DataGridView1("Price", e.RowIndex).ReadOnly = False
            End If
        End If
    End Sub

    Private Sub cbsuplr_GotFocus(sender As Object, e As EventArgs) Handles cbsuplr.GotFocus, cbpono.GotFocus
        If Button1.Text = "Update Selected IGN" Then
            txtnotes.Focus()
        End If
    End Sub

    Private Sub txtign_TextChanged(sender As Object, e As EventArgs) Handles txtign.TextChanged
        If txtign.Text <> "Auto Number" Then
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

    Private Sub cbslsmen_Leave(sender As Object, e As EventArgs) Handles cbsuplr.Leave, cbpono.Leave
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


    Private Sub Button1_TextChanged(sender As Object, e As EventArgs) Handles Button1.TextChanged
        If Button1.Text = "Update Selected IGN" Then
            Button6.Enabled = True
            conn()
            cmd.CommandText = "Select  Distinct SL_Code+' | '+SL_NAME As SlName, SL_Code from View_PO_Main"
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "View_PO_Main")
            cbsuplr.DisplayMember = "SlName"
            cbsuplr.ValueMember = "SL_Code"
            cbsuplr.DataSource = ds.Tables("View_PO_Main")
            con.Close()
        Else
            Button6.Enabled = False
        End If
    End Sub

    Private Sub cbsuplr_MouseWheel(sender As Object, e As MouseEventArgs) Handles cbsuplr.MouseWheel, cbpono.MouseWheel
        Dim mwe As HandledMouseEventArgs = DirectCast(e, HandledMouseEventArgs)
        If Button1.Text = "Update Selected IGN" Then
            mwe.Handled = True
        Else
            mwe.Handled = False
        End If
    End Sub

    Private Sub cbsuplr_KeyDown(sender As Object, e As KeyEventArgs) Handles cbsuplr.KeyDown, cbpono.KeyDown
        Dim bHandled As Boolean = False
        If Button1.Text = "Update Selected IGN" Then
            e.SuppressKeyPress = True
            Select Case e.KeyCode
                Case Keys.Right
                    'do stuff
                    e.Handled = True
                Case Keys.Left
                    'do other stuff
                    e.Handled = True
                Case Keys.Up
                    'do more stuff
                    e.Handled = True
                Case Keys.Down
                    'do more stuff
                    e.Handled = True
            End Select
        End If
    End Sub

    Private Sub chbignpost_Click(sender As Object, e As EventArgs) Handles chbignpost.Click
        Try
            If chbignpost.CheckState = CheckState.Unchecked Then
                conn()
                cmd.CommandText = "Select Count(*) As cnt from IGN_HEADER Where IGN_NO = " + txtign.Text + " And Prntd Is Null"
                dr = cmd.ExecuteReader
                dr.Read()
                Dim cnt As Integer = dr("cnt")
                dr.Close()
                con.Close()
                If cnt = 0 Then
                    If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Unpost") = False Then
                        chbignpost.Checked = True
                        MsgBox("You cannot unpost this IGN as its already Printed.", MsgBoxStyle.Critical, "H.F. General Trading CO.")
                        Exit Sub
                    Else
                        If MsgBox("Are you sure you want to unpost printed IGN !", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                            chbignpost.Checked = False
                        Else
                            chbignpost.Checked = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
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