Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class ShipTerms
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
        cmd.CommandText = "Select * from MASTER_SHIPMENT_TERMS"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "MASTER_SHIPMENT_TERMS")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("MASTER_SHIPMENT_TERMS")
        con.Close()
        DataGridView1.Columns(0).ReadOnly = True
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex = DataGridView1.NewRowIndex Then
            DataGridView1.Columns(0).ReadOnly = False
        Else
            DataGridView1.Columns(0).ReadOnly = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conn()
            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim cnt As Integer
                cmd.CommandText = "Select Count(*) As Cnt From MASTER_SHIPMENT_TERMS Where SHP_CODE = '" + CType((row.Cells("SHP_CODE").Value), String).Trim + "'"
                dr = cmd.ExecuteReader
                dr.Read()
                cnt = dr("Cnt")
                dr.Close()

                If cnt = 0 Then
                    cmd.CommandText = "Insert Into MASTER_SHIPMENT_TERMS (SHP_CODE, SHP_DESC) Values ('" + CType((row.Cells("SHP_CODE").Value), String).Trim + "', '" + CType((row.Cells("SHP_DESC").Value), String).Trim + "')"
                Else
                    cmd.CommandText = "Update MASTER_SHIPMENT_TERMS Set SHP_DESC = '" + CType((row.Cells("SHP_DESC").Value), String).Trim + "' Where SHP_CODE = '" + CType((row.Cells("SHP_CODE").Value), String).Trim + "'"
                End If
                cmd.ExecuteNonQuery()
            Next
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox("Shipment Terms Refreshed Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        conn()
        cmd.CommandText = "Select * From MASTER_SHIPMENT_TERMS Where SHP_CODE Like '%" + TextBox1.Text + "%' Or SHP_DESC Like '%" + TextBox1.Text + "%'"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "MASTER_SHIPMENT_TERMS")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("MASTER_SHIPMENT_TERMS")
        con.Close()
        DataGridView1.Columns(0).ReadOnly = True
    End Sub

End Class