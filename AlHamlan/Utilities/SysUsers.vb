Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class SysUsers
    
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
        cmd.CommandText = "Select * from Master_Users Order By UID"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "Master_Users")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("Master_Users")
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
                Dim actv As String
                If CType((row.Cells("Active").Value), String).Trim = "True" Then
                    actv = "1"
                Else
                    actv = "0"
                End If

                If CType((row.Cells("UID").Value), String).Trim = "" Then
                    cmd.CommandText = "Insert Into Master_Users Values ((Select COALESCE((Select Top 1 UID + 1 From Master_Users Order By UID Desc),1)), '" + CType((row.Cells("UName").Value), String).Trim + "', '" + CType((row.Cells("FName").Value), String).Trim + "', '" + CType((row.Cells("Initials").Value), String).Trim + "', '" + CType((row.Cells("Pass").Value), String).Trim + "', " + actv + ")"
                Else
                    cmd.CommandText = "Update Master_Users Set UName = '" + CType((row.Cells("UName").Value), String).Trim + "', FName = '" + CType((row.Cells("FName").Value), String).Trim + "', Initials = '" + CType((row.Cells("Initials").Value), String).Trim + "', Pass = '" + CType((row.Cells("Pass").Value), String).Trim + "', Active = " + actv + " Where UID = " + CType((row.Cells("UID").Value), String).Trim + ""
                End If
                cmd.ExecuteNonQuery()
            Next
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox("System Users Refreshed Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        conn()
        cmd.CommandText = "Select * From Master_Users Where UName Like '%" + TextBox1.Text + "%' Or Fname Like '%" + TextBox1.Text + "%' Or Initials Like '%" + TextBox1.Text + "%'"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "Master_Users")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("Master_Users")
        con.Close()
        DataGridView1.Columns(0).ReadOnly = True
    End Sub

End Class