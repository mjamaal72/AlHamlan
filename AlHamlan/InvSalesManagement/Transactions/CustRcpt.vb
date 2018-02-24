Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing

Public Class CustRcpt

#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da, da2 As SqlDataAdapter
    Dim ds, ds2 As DataSet
    Dim iRec As Integer
    Dim pono As String
    Dim DiscAmnt As String

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
            Button1.PerformClick()
        ElseIf e.Alt And e.KeyCode = Keys.A Then
            Button4.PerformClick()
        ElseIf e.Alt And e.KeyCode = Keys.R Then
            Button3.PerformClick()
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

            If RadioButton1.Checked = True Then
                cmd.CommandText = "Select CUS_RECIEPT_NO as RCNo, convert(varchar, CUS_RECIEPT_DATE, 106) as RCDate, (CASE WHEN CUS_PAY_TYPE = 'CA' THEN 'Cash' ELSE CASE WHEN CUS_PAY_TYPE = 'CH' THEN 'Cheque' ELSE 'K-Net' END END) As Mode, Remarks, AMOUNT, convert(bit, (CASE WHEN Cancel is Null THEN 0 ELSE 1 END)) As Cancel from CUSTOMER_RECIEPTS Where Cus_Code = '" + cbcust.SelectedValue.ToString + "' Order By CUS_RECIEPT_NO DESC"
            ElseIf RadioButton2.Checked = True Then
                cmd.CommandText = "Select Inv_No, InvDate, Net, NameMob As Salesmen from View_SalesInv_Main Where Cust_Code = '" + cbcust.SelectedValue.ToString + "' Order By Inv_No DESC"
            Else
                cmd.CommandText = "Select CUS_RECIEPT_NO as RCNo, convert(varchar, CUS_RECIEPT_DATE, 106) as RCDate, (CASE WHEN CUS_PAY_TYPE = 'CA' THEN 'Cash' ELSE CASE WHEN CUS_PAY_TYPE = 'CH' THEN 'Cheque' ELSE 'K-Net' END END) As Mode, Remarks, (Select Net from View_SalesInv_Main Where Inv_No = " + Replace(txtbarcode.Text, ",", "") + ") As InvAmnt, AMOUNT, convert(bit, (CASE WHEN Cancel is Null THEN 0 ELSE 1 END)) As Cancel from CUSTOMER_RECIEPTS Where Ref_No=" + Replace(txtbarcode.Text, ",", "") + " Order By CUS_RECIEPT_NO DESC"
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
            cmd.CommandText = "Select RCNo, RCDate, CName, Mode, Remarks, Amnt, Initials from View_CustomerReciepts Where Cancel Is Null Order By RCNo Desc"
        Else
            Dim cmdstr = "Select RCNo, RCDate, CName, Mode, Remarks, Amnt, Initials from View_CustomerReciepts Where Cancel Is Null"
            Dim strsrng As String()
            strsrng = txtSearch.Text.Split(",")
            For Each para As String In strsrng
                cmdstr = cmdstr + " and (convert(varchar, RCNO) like '%" + para.Trim + "%' or RCDate Like '%" + para.Trim + "%' Or CName Like '%" + para.Trim + "%' Or Mode Like '%" + para.Trim + "%' Or Remarks Like '%" + para.Trim + "%' Or Initials = '" + para.Trim + "' OR convert(varchar, Amnt) Like '%" + para.Trim + "%')"
            Next
            cmdstr = cmdstr + " Order By RCNo Desc"
            cmd.CommandText = cmdstr
        End If

        da = New SqlDataAdapter(cmd)
        dataTable = New DataTable()
        da.Fill(dataTable)
        bindingSource = New BindingSource()
        bindingSource.DataSource = dataTable

        'Adding  SrNO TextBox
        Dim ColumnRCNo As New DataGridViewTextBoxColumn()
        ColumnRCNo.Name = "RCNo"
        ColumnRCNo.HeaderText = "RCNo"
        ColumnRCNo.ReadOnly = True
        ColumnRCNo.DataPropertyName = "RCNo"
        DataGridView1.Columns.Add(ColumnRCNo)

        'Adding  RCDate TextBox
        Dim ColumnRCDate As New DataGridViewTextBoxColumn()
        ColumnRCDate.Name = "RCDate"
        ColumnRCDate.HeaderText = "RCDate"
        ColumnRCDate.ReadOnly = True
        ColumnRCDate.DataPropertyName = "RCDate"
        DataGridView1.Columns.Add(ColumnRCDate)

        'Adding  CName TextBox
        Dim ColumnCName As New DataGridViewTextBoxColumn()
        ColumnCName.Name = "CName"
        ColumnCName.HeaderText = "Customer"
        ColumnCName.Width = 70
        ColumnCName.ReadOnly = True
        ColumnCName.DataPropertyName = "CName"
        DataGridView1.Columns.Add(ColumnCName)

        'Adding  Mode TextBox
        Dim ColumnMode As New DataGridViewTextBoxColumn()
        ColumnMode.Name = "Mode"
        ColumnMode.HeaderText = "Mode"
        ColumnMode.Width = 60
        ColumnMode.ReadOnly = True
        ColumnMode.DataPropertyName = "Mode"
        DataGridView1.Columns.Add(ColumnMode)

        'Adding  Remarks TextBox
        Dim ColumnRemarks As New DataGridViewTextBoxColumn()
        ColumnRemarks.Name = "REMARKS"
        ColumnRemarks.HeaderText = "REMARKS"
        ColumnRemarks.Width = 70
        ColumnRemarks.ReadOnly = True
        ColumnRemarks.DataPropertyName = "REMARKS"
        DataGridView1.Columns.Add(ColumnRemarks)

        'Adding  Amnt TextBox
        Dim ColumnAmnt As New DataGridViewTextBoxColumn()
        ColumnAmnt.Name = "Amnt"
        ColumnAmnt.HeaderText = "Amnt"
        ColumnAmnt.Width = 60
        ColumnAmnt.ReadOnly = True
        ColumnAmnt.DataPropertyName = "Amnt"
        DataGridView1.Columns.Add(ColumnAmnt)

        'Adding  RecvBy TextBox
        Dim ColumnRcvdBy As New DataGridViewTextBoxColumn()
        ColumnRcvdBy.Name = "RcvdBy"
        ColumnRcvdBy.HeaderText = "RcvdBy"
        ColumnRcvdBy.Width = 70
        ColumnRcvdBy.ReadOnly = True
        ColumnRcvdBy.DataPropertyName = "Initials"
        DataGridView1.Columns.Add(ColumnRcvdBy)

        'Adding  Modify Button
        Dim ColumnModify As New DataGridViewButtonColumn()
        ColumnModify.Name = "Modify"
        ColumnModify.HeaderText = "Modify"
        ColumnModify.Width = 25
        ColumnModify.Text = "Modify"
        If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "ModifyPayment") = False Then
            ColumnModify.Visible = False
        Else
            ColumnModify.Visible = True
        End If
        ColumnModify.UseColumnTextForButtonValue = True
        DataGridView1.Columns.Add(ColumnModify)

        'Adding  Reprint Button
        Dim ColumnReprint As New DataGridViewButtonColumn()
        ColumnReprint.Name = "Reprint"
        ColumnReprint.HeaderText = "Reprint"
        ColumnReprint.Width = 25
        ColumnReprint.Text = "Reprint"
        If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Reprint") = False Then
            ColumnReprint.Visible = False
        Else
            ColumnReprint.Visible = True
        End If
        ColumnReprint.UseColumnTextForButtonValue = True
        DataGridView1.Columns.Add(ColumnReprint)

        'Adding  Slip Thermal Print Button
        Dim ColumnReprintThrml As New DataGridViewButtonColumn()
        ColumnReprintThrml.Name = "SlipPrnt"
        ColumnReprintThrml.HeaderText = "SlipPrnt"
        ColumnReprintThrml.Width = 25
        ColumnReprintThrml.Text = "SlipPrnt"
        If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Reprint") = False Then
            ColumnReprintThrml.Visible = False
        Else
            ColumnReprintThrml.Visible = True
        End If
        ColumnReprintThrml.UseColumnTextForButtonValue = True
        DataGridView1.Columns.Add(ColumnReprintThrml)

        'Adding  Cancel Button
        Dim ColumnCancel As New DataGridViewButtonColumn()
        ColumnCancel.Name = "Cancel"
        ColumnCancel.HeaderText = "Cancel"
        ColumnCancel.Width = 25
        ColumnCancel.Text = "Cancel"
        If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "CancelPayment") = False Then
            ColumnCancel.Visible = False
        Else
            ColumnCancel.Visible = True
        End If
        ColumnCancel.UseColumnTextForButtonValue = True
        DataGridView1.Columns.Add(ColumnCancel)

        DataGridView1.DataSource = bindingSource
        con.Close()
    End Sub

    Public Sub ClearAll()
        txtrefno.Text = "0"
        txtRmrks.Text = ""
        cbcust.SelectedIndex = -1
        cbcust.Enabled = True
        cbpaymode.SelectedValue = "CA"
        txtrefnet.Text = "0"
        txtPndgAmnt.Text = ""
        txtpayAmnt.Text = "0"
        txtInvDisc.Text = 0
        txtInvDisc.ReadOnly = True
        LoadItemData(False)
        lblrcno.Visible = False
        txtrcno.Text = ""
        txtrcno.Visible = False
        'txtrefno.ReadOnly = False
        'txtrefnet.ReadOnly = False
        Label6.Visible = True
        txtbarcode.Visible = True
        Button1.Text = "Submit"
        dtpdate.Value = DateTime.Now
    End Sub

    Private Sub CustRcpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        cmd.CommandText = "With PayMode As (Select 'Cash' As Mode, 'CA' As Abrv Union Select 'Cheque' As Mode, 'CH' As Abrv Union Select 'K-Net' As Mode, 'NT' As Abrv) Select * From PayMode"
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "PayMode")
        cbpaymode.DisplayMember = "Mode"
        cbpaymode.ValueMember = "Abrv"
        cbpaymode.DataSource = ds.Tables("PayMode")
        con.Close()

        If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Add") = False Then
            Button1.Visible = False
        End If

        ClearAll()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pamnt As Decimal = txtpayAmnt.Text
        If pamnt < 1 And pamnt > -1 Then
            If MsgBox("Are you sure you want to enter 0 as an amount ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
            Else
                Exit Sub
            End If
        End If

        Dim EmailMode As String = ""
        Try
            Dim RCNo As String = If(txtrcno.Text = "", 0, txtrcno.Text)
            conn()
            cmd.CommandText = "EXEC Sp_CustRcptFrm " + RCNo + ", '" + dtpdate.Value + "', '" + cbcust.SelectedValue.ToString + "', '" + cbpaymode.SelectedValue.ToString + "', " + txtrefno.Text + ", '" + txtRmrks.Text + "', " + txtpayAmnt.Text + ", " + MainMDI.lblUID.Text + ", 0"
            cmd.ExecuteNonQuery()

            If txtInvDisc.Text <> "" And txtInvDisc.Text <> 0 Then
                cmd.CommandText = "Update SALES_HEADER SET INV_DISC_AMT = " + txtInvDisc.Text + " Where INV_NO = " + txtrefno.Text + ""
                cmd.ExecuteNonQuery()
            End If

            'cmd.CommandText = "Select Top 1 CUS_RECIEPT_NO From CUSTOMER_RECIEPTS Order By CUS_RECIEPT_NO Desc"
            'dr = cmd.ExecuteReader
            'If dr.Read Then
            '    RCNo = CType(dr("CUS_RECIEPT_NO"), String).Trim
            'Else
            '    RCNo = "1"
            'End If
            'dr.Close()

            'Dim da As New SqlDataAdapter
            'Dim ds As New DataSet
            'cmd.CommandText = "Select * from View_CustomerReciepts where RCNo = " + RCNo + ""
            'da.SelectCommand = cmd
            'da.Fill(ds, "View_CustomerReciepts")

            'Dim Cr As New CustRC
            'AccessVerify.LoadReports(Cr, ds, MainMDI.lblFrmDtls.Text)

            'cmd.CommandText = "Update CUSTOMER_RECIEPTS Set PRNTD = GetDate() Where CUS_RECIEPT_NO = " + RCNo + ""
            'cmd.ExecuteNonQuery()


            txtSearch.Text = ""

            cmd.CommandText = "Select Top 500 RCNo, RCDate, CName, Mode , Remarks, Amnt, RcvBy from View_CustomerReciepts Order By CUS_RECIEPT_DATE DESC"
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "View_CustomerReciepts")
            DataGridView2.ClearSelection()
            DataGridView2.DataSource = ds.Tables("View_CustomerReciepts")
            con.Close()
            ClearAll()
            AccessVerify.NotifyChanges(Me.Name.ToString, "Add", RCNo)
            txtbarcode.Text = ""
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Panel1.Visible = True Then
            Panel1.Visible = False
            Button4.Text = "View All Reciepts"
        Else
            Panel1.Visible = True
            Button4.Text = "Hide All Reciepts"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadItemData(True)
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbarcode.KeyPress
        If (e.KeyChar = (Chr(13))) Then
            ClearAll()
            RadioButton1.Enabled = True
            RadioButton2.Enabled = True

            conn()
            Dim Cnt As Integer
            RadioButton3.Text = "Reciepts for InvNo : " + Replace(txtbarcode.Text, ",", "")
            cmd.CommandText = "Select count(*) as Cnt from CUSTOMER_RECIEPTS Where Ref_No =" + Replace(txtbarcode.Text, ",", "") + " and Cancel Is Null"
            dr = cmd.ExecuteReader
            dr.Read()
            Cnt = dr("Cnt")
            dr.Close()

            If Cnt > 0 Then
                If MsgBox("You had already generated " + CType(Cnt, String) + " Reciepts for InvNo: " + Replace(txtbarcode.Text, ",", "") + vbNewLine + "Do you still want to proceed ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                    cmd.CommandText = "Select *, (Select Pending From View_CustPendingAmnt Where Cust_Code = View_SalesInv_Main.Cust_Code) As Pending from View_SalesInv_Main Where Inv_No = " + Replace(txtbarcode.Text, ",", "") + ""
                    dr = cmd.ExecuteReader
                    dr.Read()
                    txtrefno.Text = CType(dr("Inv_No"), String).Trim
                    txtrefnet.Text = CType(dr("Net"), String).Trim
                    cbcust.SelectedValue = CType(dr("Cust_Code"), String).Trim
                    cbcust.Enabled = False
                    txtPndgAmnt.Text = "Pending Amount : " + CType(dr("Pending"), String).Trim
                    txtpayAmnt.Text = CType(dr("Net"), String).Trim
                    txtInvDisc.Text = CType(dr("INV_DISC_AMT"), String).Trim
                    DiscAmnt = CType(dr("INV_DISC_AMT"), String).Trim
                    txtInvDisc.ReadOnly = False
                    txtRmrks.Text = "RC Payment Against InvoiceNo: " + CType(dr("Inv_No"), String).Trim
                    cbpaymode.SelectedIndex = 0
                    dr.Close()
                    RadioButton3.Checked = True
                Else
                    RadioButton3.Checked = True
                    RadioButton1.Enabled = False
                    RadioButton2.Enabled = False
                End If
            Else
                cmd.CommandText = "Select *, (Select Pending From View_CustPendingAmnt Where Cust_Code = View_SalesInv_Main.Cust_Code) As Pending from View_SalesInv_Main Where Inv_No = " + Replace(txtbarcode.Text, ",", "") + ""
                dr = cmd.ExecuteReader
                dr.Read()
                txtrefno.Text = CType(dr("Inv_No"), String).Trim
                txtrefnet.Text = CType(dr("Net"), String).Trim
                cbcust.SelectedValue = CType(dr("Cust_Code"), String).Trim
                cbcust.Enabled = False
                txtPndgAmnt.Text = "Pending Amount : " + CType(dr("Pending"), String).Trim
                txtpayAmnt.Text = CType(dr("Net"), String).Trim
                txtInvDisc.Text = CType(dr("INV_DISC_AMT"), String).Trim
                DiscAmnt = CType(dr("INV_DISC_AMT"), String).Trim
                txtInvDisc.ReadOnly = False
                txtRmrks.Text = "RC Payment Against InvoiceNo: " + CType(dr("Inv_No"), String).Trim
                cbpaymode.SelectedIndex = 0
                dr.Close()
            End If

            LoadGrid2()
            con.Close()
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        conn()
        LoadGrid2()
        con.Close()
    End Sub

    Private Sub cbcust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbcust.SelectedIndexChanged
        If txtrefno.Text = "" Or txtrefno.Text = "0" Then
            txtRmrks.Text = "RC Payment Against Advance OR Settlement"
            txtInvDisc.ReadOnly = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ClearAll()
    End Sub

    Private Sub DataGridView1_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles DataGridView1.UserDeletingRow
        If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "CancelPayment") = False Then
            MsgBox("You dont have access to cancel payment.", MsgBoxStyle.Critical)
            e.Cancel = True
            Exit Sub
        End If
        Try
            If MsgBox("Are you sure you want to Cancel !", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                conn()
                cmd.CommandText = "Update CUSTOMER_RECIEPTS Set Cancel = GetDate() Where CUS_RECIEPT_NO = " + e.Row.Cells(0).Value.ToString + ""
                cmd.ExecuteNonQuery()
                con.Close()

                If txtSearch.Text = "" Then
                    LoadItemData(False)
                Else
                    LoadItemData(True)
                End If
                'AccessVerify.NotifyChanges(Me.Name.ToString, "CancelPayment", e.Row.Cells(0).Value.ToString)
            End If
        Catch ex As Exception
        End Try
        e.Cancel = True
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = DataGridView1.Columns("Cancel").Index AndAlso e.RowIndex >= 0 Then
            Try
                If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "CancelPayment") = False Then
                    MsgBox("You dont have access to cancel payment.", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Are you sure you want to Cancel !", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                    conn()
                    cmd.CommandText = "Update CUSTOMER_RECIEPTS Set Cancel = GetDate() Where CUS_RECIEPT_NO = " + DataGridView1("RCNo", e.RowIndex).Value.ToString + ""
                    cmd.ExecuteNonQuery()
                    con.Close()

                    If txtSearch.Text = "" Then
                        LoadItemData(False)
                    Else
                        LoadItemData(True)
                    End If
                    AccessVerify.NotifyChanges(Me.Name.ToString, "CancelPayment", DataGridView1("RCNo", e.RowIndex).Value.ToString)
                End If
            Catch ex As Exception
            End Try
        ElseIf e.ColumnIndex = DataGridView1.Columns("Reprint").Index AndAlso e.RowIndex >= 0 Then
            conn()
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd.CommandText = "Select * from View_CustomerReciepts where RCNo = " + DataGridView1("RCNo", e.RowIndex).Value.ToString + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_CustomerReciepts")

            Dim Cr As New CustRC
            AccessVerify.LoadReports(Cr, ds, MainMDI.lblFrmDtls.Text)

            cmd.CommandText = "Update CUSTOMER_RECIEPTS Set PRNTD = GetDate() Where CUS_RECIEPT_NO = " + DataGridView1("RCNo", e.RowIndex).Value.ToString + ""
            cmd.ExecuteNonQuery()
            con.Close()
        ElseIf e.ColumnIndex = DataGridView1.Columns("SlipPrnt").Index AndAlso e.RowIndex >= 0 Then
            conn()
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd.CommandText = "Select * from View_CustomerReciepts where RCNo = " + DataGridView1("RCNo", e.RowIndex).Value.ToString + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_CustomerReciepts")

            Dim Cr As New CustRCThermal
            AccessVerify.LoadReports(Cr, ds)

            cmd.CommandText = "Update CUSTOMER_RECIEPTS Set PRNTD = GetDate() Where CUS_RECIEPT_NO = " + DataGridView1("RCNo", e.RowIndex).Value.ToString + ""
            cmd.ExecuteNonQuery()
            con.Close()
        ElseIf e.ColumnIndex = DataGridView1.Columns("Modify").Index AndAlso e.RowIndex >= 0 Then
            conn()
            cmd.CommandText = "Select * From View_CustomerReciepts Where RCNo = " + DataGridView1("RCNo", e.RowIndex).Value.ToString + ""
            dr = cmd.ExecuteReader
            dr.Read()
            dtpdate.Value = CType(dr("CUS_RECIEPT_DATE"), String).Trim
            txtrcno.Text = CType(dr("RCNo"), String).Trim
            cbcust.SelectedValue = CType(dr("CUS_CODE"), String).Trim
            txtrefno.Text = CType(dr("RefNo"), String).Trim
            txtrefnet.Text = CType(dr("Net"), String).Trim
            cbpaymode.SelectedValue = CType(dr("CUS_PAY_TYPE"), String).Trim
            txtpayAmnt.Text = CType(dr("Amnt"), String).Trim
            txtInvDisc.Text = CType(dr("INV_DISC_AMT"), String).Trim
            DiscAmnt = CType(dr("INV_DISC_AMT"), String).Trim
            txtInvDisc.ReadOnly = False
            txtRmrks.Text = CType(dr("REMARKS"), String).Trim
            cbcust.Enabled = False

            Button1.Text = "Modify"
            Label6.Visible = False
            txtbarcode.Visible = False
            lblrcno.Visible = True
            txtrcno.Visible = True
            dr.Close()
            con.Close()
        End If
    End Sub

    Private Sub txtpayAmnt_LostFocus(sender As Object, e As EventArgs) Handles txtpayAmnt.LostFocus
        Try
            txtpayAmnt.Text = [String].Format("{0:0.000}", txtpayAmnt.Text)
        Catch ez As Exception
        End Try
    End Sub

    Private Sub txtInvDisc_LostFocus(sender As Object, e As EventArgs) Handles txtInvDisc.LostFocus
        If txtInvDisc.Text <> DiscAmnt Then
            If CType(txtInvDisc.Text, Decimal) > CType(txtrefnet.Text, Decimal) Then
                MsgBox("Discount Cannot be Greater than Invoice Net Amount.", MsgBoxStyle.Critical)
                txtInvDisc.Text = DiscAmnt
                Exit Sub
            End If
            If MsgBox("Are you sure you want to Edit Discount for this invoice ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                Dim diff = txtInvDisc.Text - DiscAmnt
                txtpayAmnt.Text = txtpayAmnt.Text - diff
                txtpayAmnt.Text = [String].Format("{0:0.000}", txtpayAmnt.Text)
            Else
                txtInvDisc.Text = DiscAmnt
            End If
        End If
    End Sub
End Class