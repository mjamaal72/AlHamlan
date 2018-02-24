Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing

Public Class Salesman
    Dim AccessVerify As New VerifyAccess
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
    Dim flag As Boolean
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

    Public Sub LoadItemData(filter As Boolean)

        DataGridView1.Columns.Clear()
        Dim abc As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLibrary.dll")
        connectionString = abc
        sqlConnection = New SqlConnection(connectionString)
        sqlConnection.Open()

        'DataGridView Source
        If filter = True Then
            selectQueryString = "Select SM_CODE, SM_NAME, SM_DIV, SM_MOBILE, SM_RES_NO, SM_SUPERVISOR, SM_SALES_TYPE from View_Master_Salesman Where SM_NAME Like '%" + TextBox1.Text + "%' Or SM_MOBILE Like '%" + TextBox1.Text + "%' Or SM_RES_NO Like '%" + TextBox1.Text + "%' Or FName Like '%" + TextBox1.Text + "%' Or TYPE_NAME Like '%" + TextBox1.Text + "%' Order By SM_Code"
        Else
            selectQueryString = "Select SM_CODE, SM_NAME, SM_DIV, SM_MOBILE, SM_RES_NO, SM_SUPERVISOR, SM_SALES_TYPE from View_Master_Salesman Order By SM_Code"
        End If
        sqlDataAdapter = New SqlDataAdapter(selectQueryString, sqlConnection)
        sqlCommandBuilder = New SqlCommandBuilder(sqlDataAdapter)
        dataTable = New DataTable()
        sqlDataAdapter.Fill(dataTable)
        bindingSource = New BindingSource()
        bindingSource.DataSource = dataTable

        'DIV Data Source
        Dim selectQueryStringDIV As String = "SELECT DIV_CODE, DIV_DESC FROM MASTER_DIVISION Union Select '', '' Order By DIV_DESC"
        Dim sqlDataAdapterDIV As New SqlDataAdapter(selectQueryStringDIV, sqlConnection)
        Dim sqlCommandBuilderDIV As New SqlCommandBuilder(sqlDataAdapterDIV)
        Dim dataTableDIV As New DataTable()
        sqlDataAdapterDIV.Fill(dataTableDIV)
        Dim bindingSourceDIV As New BindingSource()
        bindingSourceDIV.DataSource = dataTableDIV

        'Supervisor Data Source
        Dim selectQueryStringSprvsr As String = "Select UID, FName From Master_Users Order By FName"
        Dim sqlDataAdapterSprvsr As New SqlDataAdapter(selectQueryStringSprvsr, sqlConnection)
        Dim sqlCommandBuilderSprvsr As New SqlCommandBuilder(sqlDataAdapterSprvsr)
        Dim dataTableSprvsr As New DataTable()
        sqlDataAdapterSprvsr.Fill(dataTableSprvsr)
        Dim bindingSourceSprvsr As New BindingSource()
        bindingSourceSprvsr.DataSource = dataTableSprvsr

        'Supervisor Data Source
        Dim selectQueryStringType As String = "WITH TransMode AS (Select 'V' As TypeCode, 'Van Sales' As TypeName Union Select 'F' As TypeCode, 'Field Sales' As TypeName) SELECT * from TransMode"
        Dim sqlDataAdapterType As New SqlDataAdapter(selectQueryStringType, sqlConnection)
        Dim sqlCommandBuilderType As New SqlCommandBuilder(sqlDataAdapterType)
        Dim dataTableType As New DataTable()
        sqlDataAdapterType.Fill(dataTableType)
        Dim bindingSourceType As New BindingSource()
        bindingSourceType.DataSource = dataTableType

        'Adding  SM_CODE TextBox
        Dim ColumnCode As New DataGridViewTextBoxColumn()
        ColumnCode.Name = "SM_CODE"
        ColumnCode.HeaderText = "Code"
        ColumnCode.ReadOnly = True
        ColumnCode.Width = 40
        ColumnCode.DataPropertyName = "SM_CODE"
        DataGridView1.Columns.Add(ColumnCode)

        'Adding  SM_NAME TextBox
        Dim ColumnName As New DataGridViewTextBoxColumn()
        ColumnName.Name = "SM_NAME"
        ColumnName.HeaderText = "Full Name"
        ColumnName.Width = 220
        ColumnName.DataPropertyName = "SM_NAME"
        DataGridView1.Columns.Add(ColumnName)

        'Adding  DIV Combo
        Dim ColumnDIV As New DataGridViewComboBoxColumn()
        ColumnDIV.Name = "DIV"
        ColumnDIV.DataPropertyName = "SM_DIV"
        ColumnDIV.HeaderText = "DIV"
        ColumnDIV.Width = 100
        ColumnDIV.DataSource = bindingSourceDIV
        ColumnDIV.ValueMember = "DIV_CODE"
        ColumnDIV.DisplayMember = "DIV_DESC"
        ColumnDIV.DropDownWidth = 150
        DataGridView1.Columns.Add(ColumnDIV)

        'Adding  Mobile TextBox
        Dim ColumnMob As New DataGridViewTextBoxColumn()
        ColumnMob.Name = "SM_MOBILE"
        ColumnMob.HeaderText = "MobileNo"
        ColumnMob.Width = 80
        ColumnMob.DataPropertyName = "SM_MOBILE"
        DataGridView1.Columns.Add(ColumnMob)

        'Adding  ResNo TextBox
        Dim ColumnRes As New DataGridViewTextBoxColumn()
        ColumnRes.Name = "SM_RES_NO"
        ColumnRes.HeaderText = "Residence"
        ColumnRes.Width = 80
        ColumnRes.DataPropertyName = "SM_RES_NO"
        DataGridView1.Columns.Add(ColumnRes)

        'Adding  SalesType Combo
        Dim ColumnType As New DataGridViewComboBoxColumn()
        ColumnType.Name = "Type"
        ColumnType.DataPropertyName = "SM_SALES_TYPE"
        ColumnType.HeaderText = "Type"
        ColumnType.Width = 80
        ColumnType.DataSource = bindingSourceType
        ColumnType.ValueMember = "TypeCode"
        ColumnType.DisplayMember = "TypeName"
        DataGridView1.Columns.Add(ColumnType)

        'Adding  Supervisor Combo
        Dim ColumnSprvsr As New DataGridViewComboBoxColumn()
        ColumnSprvsr.Name = "SM_SUPERVISOR"
        ColumnSprvsr.DataPropertyName = "SM_SUPERVISOR"
        ColumnSprvsr.HeaderText = "Supervisor"
        ColumnSprvsr.Width = 160
        ColumnSprvsr.DataSource = bindingSourceSprvsr
        ColumnSprvsr.ValueMember = "UID"
        ColumnSprvsr.DisplayMember = "FName"
        DataGridView1.Columns.Add(ColumnSprvsr)

        'Setting Data Source for DataGridView
        DataGridView1.DataSource = bindingSource

        sqlConnection.Close()
    End Sub

    Private Sub Salesman_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        'AddRows()
        LoadItemData(False)
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AccessVerify.DGVPrinting(Label1.Text, "", False, DataGridView1)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conn()
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                Dim DivCB As String
                If DataGridView1.Rows(i).Cells("DIV").Value.ToString = "" Then
                    DivCB = ""
                Else
                    DivCB = DataGridView1.Rows(i).Cells("DIV").Value.ToString
                End If
                If DataGridView1.Rows(i).Cells("SM_CODE").Value.ToString = "" Then
                    cmd.CommandText = "Insert Into MASTER_SALESMAN Values ((Select COALESCE((Select Top 1 SM_CODE + 1 From MASTER_SALESMAN Order By SM_CODE Desc),1)), '" + DataGridView1.Rows(i).Cells("SM_NAME").Value + "', '" + DivCB + "', '" + DataGridView1.Rows(i).Cells("SM_RES_NO").Value + "', '" + DataGridView1.Rows(i).Cells("SM_MOBILE").Value + "', " + DataGridView1.Rows(i).Cells("SM_SUPERVISOR").Value.ToString + ", '" + DataGridView1.Rows(i).Cells("Type").Value + "')"
                Else
                    cmd.CommandText = "Update MASTER_SALESMAN Set SM_NAME='" + DataGridView1.Rows(i).Cells("SM_NAME").Value + "', SM_DIV='" + DivCB + "', SM_RES_NO='" + DataGridView1.Rows(i).Cells("SM_RES_NO").Value + "', SM_MOBILE='" + DataGridView1.Rows(i).Cells("SM_MOBILE").Value + "', SM_SUPERVISOR=" + DataGridView1.Rows(i).Cells("SM_SUPERVISOR").Value.ToString + ", SM_SALES_TYPE='" + DataGridView1.Rows(i).Cells("Type").Value + "' Where SM_CODE=" + DataGridView1.Rows(i).Cells("SM_CODE").Value.ToString + ""
                End If
                cmd.ExecuteNonQuery()
            Next
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox("Salesman Refreshed Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            LoadItemData(False)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadItemData(True)
    End Sub

End Class