Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine

Public Class IGNTagging

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
        If CheckBox1.Checked = True Then
            cmd.CommandText = "Select * from View_Voucher_Dtls Where SL_Code = '" + CBSplr.SelectedValue.ToString + "' And IGNBind = " + cbign.Text + ""
        Else
            cmd.CommandText = "Select * from View_Voucher_Dtls Where SL_Code = '" + CBSplr.SelectedValue.ToString + "'"
        End If
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_Voucher_Dtls")
        DataGridView1.DataSource = ds.Tables("View_Voucher_Dtls")
        con.Close()

        If CheckBox1.Checked = True Then
            For Each row As DataGridViewRow In DataGridView1.Rows
                DirectCast(row.Cells(0), DataGridViewCheckBoxCell).Value = True
            Next
        Else
            For Each row As DataGridViewRow In DataGridView1.Rows
                If CType((row.Cells("IGN").Value), String).Trim <> "0" Then
                    row.Cells(0).Style.BackColor = Color.DarkGray
                    row.Cells(0).ReadOnly = True
                End If
            Next
        End If
    End Sub
    Public Sub ClearAll()
        If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "AllowBind") = False Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
        CBSplr.SelectedIndex = -1
        cbign.Items.Clear()
        cbign.Text = ""
        CheckBox1.Checked = False
        txtpono.Text = ""
        txtigndate.Text = ""
        txtinvno.Text = ""
        txtinvdate.Text = ""
        txtigngross.Text = ""
        txtigndisc.Text = ""
        txtignadj.Text = ""
        txtignchrgs.Text = ""
        txtignnet.Text = ""
        DataGridView1.DataSource = Nothing
    End Sub

    Private Sub ME_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        ClearAll()
        conn()
        DataGridView1.AutoGenerateColumns = False
        cmd.CommandText = "Select Distinct SL_Code+' | '+SL_NAME As SlName, SL_Code from View_Voucher_Dtls Where Tran_Type = 'D' Order By SL_Code"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_Voucher_Dtls")
        CBSplr.DisplayMember = "SlName"
        CBSplr.ValueMember = "SL_Code"
        CBSplr.DataSource = ds.Tables("View_Voucher_Dtls")
        con.Close()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cbign.Text = "" Or CBSplr.SelectedValue.ToString = "" Then
            MsgBox("Please select IGN.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            Exit Sub
        End If
        conn()
        For Each row As DataGridViewRow In DataGridView1.Rows
            If DirectCast(row.Cells(0), DataGridViewCheckBoxCell).Value = True Then
                cmd.CommandText = "Update VOUCHER_DETAIL Set IGNBind = " + cbign.Text + " Where ID = " + CType((row.Cells("ID").Value), String).Trim + ""
                cmd.ExecuteNonQuery()
            Else
                If CheckBox1.Checked = True Then
                    cmd.CommandText = "Update VOUCHER_DETAIL Set IGNBind = 0 Where ID = " + CType((row.Cells("ID").Value), String).Trim + ""
                    cmd.ExecuteNonQuery()
                End If
            End If
        Next
        con.Close()
        LoadGrid()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ClearAll()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Panel2.Visible = True Then
            Panel2.Visible = False
        Else
            Panel2.Visible = True
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        LoadGrid()
    End Sub

    Private Sub cbign_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbign.SelectedIndexChanged
        If cbign.Text = "" Then
            Exit Sub
        End If

        conn()
        cmd.CommandText = "Select * From View_IGN_Main Where IGN_No = " + cbign.Text + ""
        dr = cmd.ExecuteReader
        If dr.Read Then
            txtignnet.Text = CType(dr("Net"), String).Trim
            txtignchrgs.Text = CType(dr("REC_FOOT_CHARGES"), String).Trim
            txtpono.Text = CType(dr("PUR_NO"), String).Trim
            txtigndate.Text = CType(dr("IGNDate"), String).Trim
            txtinvno.Text = CType(dr("INVOICE_NO"), String).Trim
            txtinvdate.Text = CType(dr("INVOICE_DATE"), String).Trim
            txtigngross.Text = CType(dr("Gross"), String).Trim
            txtigndisc.Text = CType(dr("REC_FOOT_DISC"), String).Trim
            txtignadj.Text = CType(dr("REC_FOOT_ADJUST"), String).Trim
        End If
        con.Close()
    End Sub

    Private Sub CBSplr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBSplr.SelectedIndexChanged
        LoadGrid()

        conn()
        cbign.Items.Clear()
        cbign.Items.Add("")
        cbign.Text = ""
        cmd.CommandText = "Select Distinct IGN_NO From View_IGN_Main Where SL_CODE = '" + CBSplr.SelectedValue.ToString + "'"
        dr = cmd.ExecuteReader
        While dr.Read
            cbign.Items.Add(CType(dr("IGN_No"), String).Trim)
        End While
        con.Close()
    End Sub

    Private Sub CBSplr_LostFocus(sender As Object, e As EventArgs) Handles CBSplr.LostFocus
        Try
            If CBSplr.Items.Contains(CBSplr.Text) = False And CBSplr.SelectedValue = Nothing Then
                CBSplr.SelectedValue = CBSplr.Text
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class