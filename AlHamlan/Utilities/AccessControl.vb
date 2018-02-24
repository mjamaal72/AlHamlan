Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class AccessControl
    
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

    Public Sub SwitchAccessGrid(filter As Boolean)
        conn()
        DataGridView1.DataSource = ""
        If RadioButton1.Checked = True Then
            If filter = True Then
                cmd.CommandText = "Select *, Allowed As OrgAllowed From UserAccessController(" + ComboBox2.SelectedValue.ToString + ") Where Parent Like '" + TextBox1.Text + "' Or MenuName Like '" + TextBox1.Text + "' Order By Parent"
            Else
                cmd.CommandText = "Select *, Allowed As OrgAllowed From UserAccessController(" + ComboBox2.SelectedValue.ToString + ") Order By Parent"
            End If
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "UserAccessController")
            DataGridView1.ClearSelection()
            DataGridView1.DataSource = ds.Tables("UserAccessController")
        Else
            If filter = True Then
                cmd.CommandText = "Select *, Allowed As OrgAllowed From UserControlAccess(" + ComboBox2.SelectedValue.ToString + ") Where FrmName Like '" + TextBox1.Text + "' Or Description Like '" + TextBox1.Text + "' Or CtrlType Like '" + TextBox1.Text + "' Order By FrmName, Description"
            Else
                cmd.CommandText = "Select *, Allowed As OrgAllowed From UserControlAccess(" + ComboBox2.SelectedValue.ToString + ") Order By FrmName, Description"
            End If
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "UserControlAccess")
            DataGridView1.ClearSelection()
            DataGridView1.DataSource = ds.Tables("UserControlAccess")
            DataGridView1.Columns(3).ReadOnly = True
        End If
        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).ReadOnly = True
        DataGridView1.Columns("OrgAllowed").Visible = False
        con.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        AccessVerify.DGVPrinting(Label1.Text, "", False, DataGridView1)
    End Sub

    Private Sub GLType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        conn()
        cmd.CommandText = "Select Distinct UID, FName from Master_Users Order By UID"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "Master_Users")
        ComboBox2.DisplayMember = "FName"
        ComboBox2.ValueMember = "UID"
        ComboBox2.DataSource = ds.Tables("Master_Users")
        ComboBox2.SelectedIndex = 0
        con.Close()
        RadioButton1.Checked = True
        SwitchAccessGrid(False)

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
                If CType((row.Cells("Allowed").Value), String).Trim = "True" And CType((row.Cells("OrgAllowed").Value), String).Trim = "False" Then
                    actv = "1"
                    If RadioButton1.Checked = True Then
                        cmd.CommandText = "Insert Into UserAccessControl Values ((Select COALESCE((Select Top 1 SrNo + 1 From UserAccessControl Order By SrNo Desc),1)), " + ComboBox2.SelectedValue.ToString + ", " + CType((row.Cells("MenuID").Value), String).Trim + ", Null)"
                    Else
                        cmd.CommandText = "Insert Into UserAccessControl Values ((Select COALESCE((Select Top 1 SrNo + 1 From UserAccessControl Order By SrNo Desc),1)), " + ComboBox2.SelectedValue.ToString + ", Null, " + CType((row.Cells("AccessID").Value), String).Trim + ")"
                    End If
                    cmd.ExecuteNonQuery()
                ElseIf CType((row.Cells("Allowed").Value), String).Trim = "False" And CType((row.Cells("OrgAllowed").Value), String).Trim = "True" Then
                    actv = "1"
                    If RadioButton1.Checked = True Then
                        cmd.CommandText = "Delete From UserAccessControl Where UID = " + ComboBox2.SelectedValue.ToString + " And MenuID = " + CType((row.Cells("MenuID").Value), String).Trim + ""
                    Else
                        cmd.CommandText = "Delete From UserAccessControl Where UID = " + ComboBox2.SelectedValue.ToString + " And CtrlAccess = " + CType((row.Cells("AccessID").Value), String).Trim + ""
                    End If
                    cmd.ExecuteNonQuery()
                End If
            Next

            TextBox1.Text = ""
            con.Close()
            SwitchAccessGrid(False)
            MsgBox("Access Assigned Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
        Catch ex As Exception
            con.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SwitchAccessGrid(True)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        SwitchAccessGrid(False)
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
        SwitchAccessGrid(False)
    End Sub
End Class