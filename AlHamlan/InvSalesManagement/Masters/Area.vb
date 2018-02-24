Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class Area
    
    Dim AccessVerify As New VerifyAccess
#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AccessVerify.DGVPrinting(Label1.Text, "", False, DataGridView1)
    End Sub

    Private Sub GLType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        conn()
        cmd.CommandText = "Select * from MASTER_CUSTOMER_AREAS Order By AREA_CODE"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "MASTER_CUSTOMER_AREAS")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("MASTER_CUSTOMER_AREAS")
        con.Close()
        DataGridView1.Columns(0).ReadOnly = True
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conn()
            For Each row As DataGridViewRow In DataGridView1.Rows
                If IsDBNull(row.Cells("AREA_CODE").Value) Then
                    cmd.CommandText = "Insert Into MASTER_CUSTOMER_AREAS Values ((Select COALESCE((Select Top 1 AREA_CODE + 1 From MASTER_CUSTOMER_AREAS Order By AREA_CODE Desc),1)), '" + CType((row.Cells("AREA_DESC").Value), String).Trim + "')"
                Else
                    cmd.CommandText = "Update MASTER_CUSTOMER_AREAS Set AREA_DESC = '" + CType((row.Cells("AREA_DESC").Value), String).Trim + "' Where AREA_CODE = " + CType((row.Cells("AREA_CODE").Value), String).Trim + ""
                End If
                cmd.ExecuteNonQuery()
            Next
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox("Area Refreshed Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        conn()
        cmd.CommandText = "Select * From MASTER_CUSTOMER_AREAS Where AREA_DESC Like '%" + TextBox1.Text + "%' Order By AREA_CODE"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "MASTER_CUSTOMER_AREAS")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("MASTER_CUSTOMER_AREAS")
        con.Close()
        DataGridView1.Columns(0).ReadOnly = True
    End Sub

End Class