Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine

Public Class CancelPndgPO

#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da, da2 As SqlDataAdapter
    Dim ds, ds2 As DataSet
    Dim iRec As Integer
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
        ElseIf e.Alt And e.KeyCode = Keys.X Then
            Button4.PerformClick()
        ElseIf e.Alt And e.KeyCode = Keys.C Then
            Button5.PerformClick()
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

    Public Sub LoadGrid()
        conn()
        cmd.CommandText = "Select *, PUR_ITM_CODE+' | '+Item_Desc As ItmName from View_PO_Dtls Where SL_Code = '" + CBSplr.SelectedValue.ToString + "' and PUR_ORDER_NO = " + cbpono.Text + " and PUR_QTY_ORDERED - PUR_QTY_RECIEVED > 0"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_PO_Dtls")
        DataGridView1.DataSource = ds.Tables("View_PO_Dtls")
        con.Close()
    End Sub
    Public Sub ClearAll()
        cbpono.Items.Clear()
        cbpono.Text = ""
        txtpodate.Text = ""
        txtshipdate.Text = ""
        txtarrdate.Text = ""
        txtIgnList.Text = ""
        txtgross.Text = ""
        txtdisc.Text = ""
        txtchrgs.Text = ""
        txtnet.Text = ""
        DataGridView1.DataSource = Nothing
    End Sub

    Private Sub ME_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        ClearAll()
        CBSplr.SelectedIndex = -1

        conn()
        DataGridView1.AutoGenerateColumns = False
        cmd.CommandText = "Select Distinct SL_Code+' | '+SL_NAME As SlName, SL_Code from View_PO_Dtls Where PUR_QTY_ORDERED - PUR_QTY_RECIEVED > 0 Order By SL_Code"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_PO_Dtls")
        CBSplr.DisplayMember = "SlName"
        CBSplr.ValueMember = "SL_Code"
        CBSplr.DataSource = ds.Tables("View_PO_Dtls")
        CBSplr.SelectedIndex = -1
        con.Close()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cbpono.Text = "" Or CBSplr.SelectedValue.ToString = "" Then
            MsgBox("Please select PO.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            Exit Sub
        End If
        conn()
        For Each row As DataGridViewRow In DataGridView1.Rows
            If CType((row.Cells("Cncld").Value), String).Trim <> "" And CType((row.Cells("Cncld").Value), String).Trim <> 0 Then
                cmd.CommandText = "Update PURCHASE_DETAIL Set PUR_QTY_CANCELLED = " + CType((row.Cells("Cncld").Value), String).Trim + " Where PUR_ENT_NO = " + CType((row.Cells("ID").Value), String).Trim + ""
                cmd.ExecuteNonQuery()
            End If
        Next
        con.Close()
        ClearAll()
        CBSplr.SelectedIndex = -1
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ClearAll()
        CBSplr.SelectedIndex = -1
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Panel2.Visible = True Then
            Panel2.Visible = False
        Else
            Panel2.Visible = True
        End If
    End Sub

    Private Sub cbign_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbpono.SelectedIndexChanged
        If cbpono.Text = "" Then
            Exit Sub
        End If
        LoadGrid()
        conn()
        cmd.CommandText = "Select *, IsNull(convert(varchar, PUR_SHIP_DATE,107), 'Not Shipped Yet') as SDate, IsNull(convert(varchar, PUR_ARR_DATE,107), 'Not Arrived Yet') as ArDate From View_PO_Main Where PUR_ORDER_NO = " + cbpono.Text + ""
        dr = cmd.ExecuteReader
        If dr.Read Then
            txtnet.Text = CType(dr("PUR_NET_VALUE"), String).Trim
            txtchrgs.Text = CType(dr("PUR_FOOT_CHARGES"), String).Trim
            txtpodate.Text = CType(dr("PODate"), String).Trim
            txtshipdate.Text = CType(dr("SDate"), String).Trim
            txtarrdate.Text = CType(dr("ArDate"), String).Trim
            txtIgnList.Text = CType(dr("IGNList"), String).Trim
            txtgross.Text = CType(dr("PUR_GROSS_VALUE"), String).Trim
            txtdisc.Text = CType(dr("PUR_FOOT_DISC"), String).Trim
        End If
        con.Close()
    End Sub

    Private Sub CBSplr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBSplr.SelectedIndexChanged
        Try
            ClearAll()
            conn()
            cbpono.Items.Clear()
            cbpono.Items.Add("")
            cbpono.Text = ""
            cmd.CommandText = "Select Distinct PUR_ORDER_NO From View_PO_Dtls Where SL_CODE = '" + CBSplr.SelectedValue.ToString + "' AND PUR_QTY_ORDERED - PUR_QTY_RECIEVED > 0 Order By PUR_ORDER_NO"
            dr = cmd.ExecuteReader
            While dr.Read
                cbpono.Items.Add(CType(dr("PUR_ORDER_NO"), String).Trim)
            End While
            con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CBSplr_LostFocus(sender As Object, e As EventArgs) Handles CBSplr.LostFocus
        Try
            If CBSplr.Items.Contains(CBSplr.Text) = False And CBSplr.SelectedValue = Nothing Then
                CBSplr.SelectedValue = CBSplr.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Try
            DataGridView1("BQty", e.RowIndex).Value = DataGridView1("Dmnd", e.RowIndex).Value - (DataGridView1("Rcvd", e.RowIndex).Value + DataGridView1("Cncld", e.RowIndex).Value)
        Catch ex As Exception
        End Try
    End Sub
End Class