Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class AssignSC

#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim iRec As Integer
    
    Dim AccessVerify As New VerifyAccess
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

    Public Sub GridRowSelect()
        Button1.Text = "Update"
        iRec = DataGridView1.CurrentRow.Index
        Try
            With ds.Tables("MASTER_MENU")
                TextBox1.Text = .Rows(iRec).Item(0)
                TextBox2.Text = .Rows(iRec).Item(1)
                iRec = DataGridView1.CurrentRow.Index
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
        End Try
    End Sub

    Private Sub GeneralLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        conn()
        cmd.CommandText = "Select MenuName, SCKeyComb From MASTER_MENU Where MenuType = 'Form'  Order By MenuName"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "MASTER_MENU")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("MASTER_MENU")
        con.Close()
        TextBox1.Text = ""
        TextBox2.Text = ""
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conn()

            cmd.CommandText = "Update MASTER_MENU Set SCKeyComb = '" + TextBox2.Text + "' Where MenuName = '" + TextBox1.Text + "'"
            cmd.ExecuteNonQuery()
            MsgBox("Selected Menu Updated Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")

            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox12.Text = ""

            cmd.CommandText = "Select MenuName, SCKeyComb From MASTER_MENU Where MenuType = 'Form'  Order By MenuName"
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "MASTER_MENU")
            DataGridView1.ClearSelection()
            DataGridView1.DataSource = ds.Tables("MASTER_MENU")
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
        End Try
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        GridRowSelect()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AccessVerify.DGVPrinting(Label1.Text, "", False, DataGridView1)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        conn()
        cmd.CommandText = "Select MenuName, SCKeyComb From MASTER_MENU Where MenuType = 'Form' And MenuName Like '%" + TextBox12.Text + "%' Order By MenuName"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "MASTER_MENU")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("MASTER_MENU")
        con.Close()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If Button1.Text = "Update" Then
            GridRowSelect()
        End If
    End Sub

    Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox12.KeyPress
        If (e.KeyChar = (Chr(13))) Then
            Button2.PerformClick()
        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If TextBox2.Text.Contains("," + CType(e.KeyCode, String)) = True Then
            Exit Sub
        Else
            TextBox2.Text = TextBox2.Text + "," + CType(e.KeyCode, String)
        End If
    End Sub

    Private Sub TextBox2_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyUp
        Dim KeyValue As String = TextBox2.Text
        conn()
        cmd.CommandText = "Select * from ShortKeysCode Where KeyName<>''"
        dr = cmd.ExecuteReader
        While dr.Read
            KeyValue = Replace(KeyValue, CType(dr("KeyCode"), String), "+" + CType(dr("KeyName"), String))
        End While
        dr.Close()
        con.Close()
        TextBox2.Text = KeyValue.TrimStart("+"c)
    End Sub

    Private Sub TextBox2_GotFocus(sender As Object, e As EventArgs) Handles TextBox2.GotFocus
        TextBox2.Text = ""
    End Sub
End Class