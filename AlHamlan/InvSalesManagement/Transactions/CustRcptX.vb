Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing

Public Class CustRcptX

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
                cmd.CommandText = "Select CUS_RECIEPT_NO as RCNo, convert(varchar, CUS_RECIEPT_DATE, 106) as RCDate, (CASE WHEN CUS_PAY_TYPE = 'CA' THEN 'Cash' ELSE CASE WHEN CUS_PAY_TYPE = 'CH' THEN 'Cheque' ELSE 'Net Transfer' END END) As Mode, Remarks, AMOUNT, convert(bit, (CASE WHEN Cancel is Null THEN 0 ELSE 1 END)) As Cancel from CUSTOMER_RECIEPTS Where Cus_Code = '" + cbcust.SelectedValue.ToString + "' Order By CUS_RECIEPT_NO DESC"
            ElseIf RadioButton2.Checked = True Then
                cmd.CommandText = "Select Inv_No, InvDate, Net, NameMob As Salesmen from View_SalesInv_Main Where Cust_Code = '" + cbcust.SelectedValue.ToString + "' Order By Inv_No DESC"
            Else
                cmd.CommandText = "Select CUS_RECIEPT_NO as RCNo, convert(varchar, CUS_RECIEPT_DATE, 106) as RCDate, (CASE WHEN CUS_PAY_TYPE = 'CA' THEN 'Cash' ELSE CASE WHEN CUS_PAY_TYPE = 'CH' THEN 'Cheque' ELSE 'Net Transfer' END END) As Mode, Remarks, (Select Net from View_SalesInv_Main Where Inv_No = " + Replace(aryBarCode(0), ",", "") + ") As InvAmnt, AMOUNT, convert(bit, (CASE WHEN Cancel is Null THEN 0 ELSE 1 END)) As Cancel from CUSTOMER_RECIEPTS Where Ref_No=" + Replace(aryBarCode(0), ",", "") + " Order By CUS_RECIEPT_NO DESC"
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
            cmd.CommandText = "Select RCNo, RCDate, CName, Mode, Remarks, Amnt, Initials from View_CustomerReciepts Where Cancel Is Null and (convert(varchar, RCNO) = '" + txtSearch.Text + "' or RCDate Like '%" + txtSearch.Text + "%' Or CName Like '%" + txtSearch.Text + "%' Or Mode Like '%" + txtSearch.Text + "%' Or Remarks Like '%" + txtSearch.Text + "%' Or Initials = '" + txtSearch.Text + "') Order By RCNo Desc"
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
        ColumnMode.Width = 70
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
        ColumnAmnt.Width = 70
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

        'Adding  Reprint Button
        Dim ColumnReprint As New DataGridViewButtonColumn()
        ColumnReprint.Name = "Reprint"
        ColumnReprint.HeaderText = "Reprint"
        ColumnReprint.Width = 45
        ColumnReprint.Text = "Reprint"
        If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Reprint") = False Then
            ColumnReprint.Visible = False
        Else
            ColumnReprint.Visible = True
        End If
        ColumnReprint.UseColumnTextForButtonValue = True
        DataGridView1.Columns.Add(ColumnReprint)

        'Adding  Cancel Button
        Dim ColumnCancel As New DataGridViewButtonColumn()
        ColumnCancel.Name = "Cancel"
        ColumnCancel.HeaderText = "Cancel"
        ColumnCancel.Width = 45
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
        txtrefno.Text = ""
        txtRmrks.Text = ""
        cbcust.SelectedIndex = -1
        cbcust.Enabled = True
        cbpaymode.SelectedIndex = -1
        txtrefnet.Text = "0"
        txtPndgAmnt.Text = ""
        txtpayAmnt.Text = "0"
        LoadItemData(False)
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

        cmd.CommandText = "With PayMode As (Select 'Cash' As Mode, 'CA' As Abrv Union Select 'Cheque' As Mode, 'CH' As Abrv Union Select 'Net Transfer' As Mode, 'NT' As Abrv) Select * From PayMode"
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
        Dim EmailMode As String = ""
        Try
            Dim RCNo As String

            conn()

            cmd.CommandText = "Insert Into CUSTOMER_RECIEPTS Values (GetDate(), '" + cbcust.SelectedValue.ToString + "', '" + cbpaymode.SelectedValue.ToString + "', " + txtrefno.Text + ", '" + txtRmrks.Text + "', " + txtpayAmnt.Text + ", " + MainMDI.lblUID.Text + ", Null, Null)"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "Select Top 1 CUS_RECIEPT_NO From CUSTOMER_RECIEPTS Order By CUS_RECIEPT_NO Desc"
            dr = cmd.ExecuteReader
            If dr.Read Then
                RCNo = CType(dr("CUS_RECIEPT_NO"), String).Trim
            Else
                RCNo = "1"
            End If
            dr.Close()

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cmd.CommandText = "Select * from View_CustomerReciepts where RCNo = " + RCNo + ""
            da.SelectCommand = cmd
            da.Fill(ds, "View_CustomerReciepts")

            Dim Cr As New CustRC
            AccessVerify.LoadReports(Cr, ds, MainMDI.lblFrmDtls.Text)

            cmd.CommandText = "Update CUSTOMER_RECIEPTS Set PRNTD = GetDate() Where CUS_RECIEPT_NO = " + RCNo + ""
            cmd.ExecuteNonQuery()


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
            aryBarCode = Nothing
            aryBarCode = txtbarcode.Text.Split("--")
            RadioButton3.Text = "Reciepts for InvNo : " + Replace(aryBarCode(0), ",", "")
            cmd.CommandText = "Select count(*) as Cnt from CUSTOMER_RECIEPTS Where Ref_No =" + Replace(aryBarCode(0), ",", "") + " and Cancel Is Null"
            dr = cmd.ExecuteReader
            dr.Read()
            Cnt = dr("Cnt")
            dr.Close()

            If Cnt > 0 Then
                If MsgBox("You had already generated " + CType(Cnt, String) + " Reciepts for InvNo: " + Replace(aryBarCode(0), ",", "") + vbNewLine + "Do you still want to proceed ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                    cmd.CommandText = "Select *, (Select Pending From View_CustPendingAmnt Where Cust_Code = View_SalesInv_Main.Cust_Code) As Pending from View_SalesInv_Main Where Inv_No = " + Replace(aryBarCode(0), ",", "") + ""
                    dr = cmd.ExecuteReader
                    dr.Read()
                    txtrefno.Text = CType(dr("Inv_No"), String).Trim
                    txtrefnet.Text = CType(dr("Net"), String).Trim
                    cbcust.SelectedValue = CType(dr("Cust_Code"), String).Trim
                    txtPndgAmnt.Text = "Pending Amount : " + CType(dr("Pending"), String).Trim
                    txtpayAmnt.Text = CType(dr("Net"), String).Trim
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
                cmd.CommandText = "Select *, (Select Pending From View_CustPendingAmnt Where Cust_Code = View_SalesInv_Main.Cust_Code) As Pending from View_SalesInv_Main Where Inv_No = " + Replace(aryBarCode(0), ",", "") + ""
                dr = cmd.ExecuteReader
                dr.Read()
                txtrefno.Text = CType(dr("Inv_No"), String).Trim
                txtrefnet.Text = CType(dr("Net"), String).Trim
                cbcust.SelectedValue = CType(dr("Cust_Code"), String).Trim
                txtPndgAmnt.Text = "Pending Amount : " + CType(dr("Pending"), String).Trim
                txtpayAmnt.Text = CType(dr("Net"), String).Trim
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

    Private Sub DataGridView1_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles DataGridView1.UserDeletingRow
        If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "CancelPayment") = False Then
            MsgBox("You dont have access to cencel payment.", MsgBoxStyle.Critical)
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
        End If
    End Sub
End Class