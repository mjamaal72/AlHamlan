Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing

Public Class ScanPay

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

    Public Sub conn()
        con = New SqlConnection
        Dim abc As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLibrary.dll")
        con.ConnectionString = Replace(abc, "AlHamlan", MainMDI.Label4.Text)
        con.Open()
        cmd = New SqlCommand
        cmd.Connection = con
    End Sub

    Private Sub CustRcpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        lblmsg.Text = ""
        txtbarcode.Focus()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbarcode.KeyPress
        If (e.KeyChar = (Chr(13))) Then
            conn()
            Dim Cnt As Integer
            cmd.CommandText = "Select count(*) as Cnt from CUSTOMER_RECIEPTS Where Ref_No =" + Replace(txtbarcode.Text, ",", "") + " and Cancel Is Null"
            dr = cmd.ExecuteReader
            If dr.Read() Then
                Cnt = dr("Cnt")
            Else
                lblmsg.Text = "Invoice No : " + Replace(txtbarcode.Text, ",", "") + " Not Found."
                dr.Close()
                con.Close()
                Exit Sub
            End If
            dr.Close()

            If Cnt > 0 Then
                lblmsg.ForeColor = Color.Red
                lblmsg.Text = "Payment Record Found For Invoice No : " + Replace(txtbarcode.Text, ",", "")
            Else
                Dim EmailMode As String = ""
                Try
                    Dim RCNo As String
                    Dim PMode As String
                    If RadioButton1.Checked = True Then
                        PMode = "Pay"
                    Else
                        PMode = "Settle"
                    End If

                    cmd.CommandText = "DECLARE @ReturnValue INT EXEC @ReturnValue = Sp_CustRcpt " + Replace(txtbarcode.Text, ",", "") + ", " + MainMDI.lblUID.Text + ", '" + PMode + "' SELECT @ReturnValue as RCNo"
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        RCNo = CType(dr("RCNo"), String).Trim
                    Else
                        RCNo = "1"
                    End If
                    dr.Close()

                    Dim da As New SqlDataAdapter
                    Dim ds As New DataSet
                    cmd.CommandText = "Select * from View_CustomerReciepts where RCNo = " + RCNo + ""
                    'da.SelectCommand = cmd
                    'da.Fill(ds, "View_CustomerReciepts")
                    dr = cmd.ExecuteReader
                    dr.Read()
                    lblmsg.ForeColor = Color.DarkGreen
                    lblmsg.Text = "Generated Reciept No : " + Replace(RCNo, ",", "") + vbNewLine + CType(dr("CUS_CODE"), String).Trim + " | " + CType(dr("CName"), String).Trim
                    dr.Close()
                    txtbarcode.Text = ""

                    'Dim Cr As New CustRC
                    'AccessVerify.PrintReports(Cr, ds, MainMDI.lblFrmDtls.Text)

                    'cmd.CommandText = "Update CUSTOMER_RECIEPTS Set PRNTD = GetDate() Where CUS_RECIEPT_NO = " + RCNo + ""
                    'cmd.ExecuteNonQuery()
                    Timer1.Enabled = True

                    'AccessVerify.NotifyChanges(Me.Name.ToString, "Add", RCNo)
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
                End Try
            End If
            con.Close()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        lblmsg.Text = ""
    End Sub

End Class