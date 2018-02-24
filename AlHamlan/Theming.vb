Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class Theming
    
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
        conn()
        cmd.CommandText = "Update Master_Users Set Theme = '" + ComboBox1.Text + "' where UID = " + MainMDI.lblUID.Text
        cmd.ExecuteNonQuery()
        con.Close()

        MainMDI.lbltheme.Text = ComboBox1.Text
        Try
            For i As Integer = 0 To Application.OpenForms.Count
                Dim frm = DirectCast(Application.OpenForms(i), Form)
                AccessVerify.Themeing(frm, MainMDI.lbltheme.Text)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Theming_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        AccessVerify.LoadingFrm(False)
        conn()
        cmd.CommandText = "Select TName From Theming Order By TName"
        dr = cmd.ExecuteReader
        While dr.Read
            ComboBox1.Items.Add(dr("TName"))
        End While
        dr.Close()
        con.Close()
    End Sub
End Class