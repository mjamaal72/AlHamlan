Imports System.Data.SqlClient
Public Class MstrGrid
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet

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

    Private Sub MastersGrid_Load(sender As Object, e As EventArgs) Handles Me.Load
        conn()
        Label1.Text = MainMDI.Label3.Text
        cmd.CommandText = "Select * from " + MainMDI.Label2.Text
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, MainMDI.Label2.Text)
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables(MainMDI.Label2.Text)
        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conn()
            Dim sql, sql2 As String
            For Each row As DataGridViewRow In DataGridView1.Rows
                sql = "Update " + MainMDI.Label2.Text + " Set "
                cmd.CommandText = "SELECT COLUMN_NAME, ORDINAL_POSITION, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + MainMDI.Label2.Text + "' order by ORDINAL_POSITION"
                dr = cmd.ExecuteReader
                While dr.Read
                    If CType(dr("ORDINAL_POSITION"), String).Trim <> "1" Then
                        If CType(dr("DATA_TYPE"), String).Trim = "varchar" Or CType(dr("DATA_TYPE"), String).Trim = "nvarchar" Or CType(dr("DATA_TYPE"), String).Trim = "text" Then
                            sql = sql + " " + CType(dr("COLUMN_NAME"), String).Trim + " = '" + CType((row.Cells(CType(dr("COLUMN_NAME"), String).Trim).Value), String).Trim + "', "
                        Else
                            sql = sql + " " + CType(dr("COLUMN_NAME"), String).Trim + " = " + CType((row.Cells(CType(dr("COLUMN_NAME"), String).Trim).Value), String).Trim + ", "
                        End If
                    Else
                        If CType(dr("DATA_TYPE"), String).Trim = "varchar" Or CType(dr("DATA_TYPE"), String).Trim = "nvarchar" Or CType(dr("DATA_TYPE"), String).Trim = "text" Then
                            sql2 = "Where " + CType(dr("COLUMN_NAME"), String).Trim + " = '" + CType((row.Cells(CType(dr("COLUMN_NAME"), String).Trim).Value), String).Trim + "'"
                        Else
                            sql2 = "Where " + CType(dr("COLUMN_NAME"), String).Trim + " = " + CType((row.Cells(CType(dr("COLUMN_NAME"), String).Trim).Value), String).Trim
                        End If
                    End If
                End While
                dr.Close()
                sql = Replace(sql + sql2, ", Where", " Where")

                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
            Next
            con.Close()
            MessageBox.Show("Data Updated Successfully.", "H.F. General Trading CO.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            con.Close()
        End Try
    End Sub
End Class