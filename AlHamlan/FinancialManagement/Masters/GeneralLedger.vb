Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class GeneralLedger
    Dim AccessVerify As New VerifyAccess
#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim iRec As Integer
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
        iRec = DataGridView1.CurrentRow.Index
        Dim GLCode As String
        Try
            With ds.Tables("View_Master_GenLedger")
                GLCode = .Rows(iRec).Item(1)
                iRec = DataGridView1.CurrentRow.Index
            End With
            If GLCode <> "" Then
                conn()
                cmd.CommandText = "Select * From View_Master_GenLedger Where GL_CODE = '" + GLCode + "'"
                dr = cmd.ExecuteReader
                If dr.Read Then
                    Button1.Text = "Update Selected Ledger"
                    TextBox1.ReadOnly = True

                    TextBox1.Text = CType(dr("GL_CODE"), String).Trim
                    TextBox2.Text = CType(dr("GL_DESC"), String).Trim
                    ComboBox1.Text = CType(dr("GL_TYPENAME"), String).Trim
                    If CType(dr("Active"), String).Trim = "T" Then
                        CheckBox1.Checked = True
                    Else
                        CheckBox1.Checked = False
                    End If
                    ComboBox2.Text = CType(dr("LedgerUser"), String).Trim
                    TextBox3.Text = CType(dr("GL_KD_OPEN"), String).Trim
                    TextBox4.Text = CType(dr("GL_KD_DEBIT"), String).Trim
                    TextBox5.Text = CType(dr("GL_KD_CREDIT"), String).Trim
                    TextBox10.Text = CType(dr("GL_FC_OPEN"), String).Trim
                    TextBox9.Text = CType(dr("GL_FC_DEBIT"), String).Trim
                    TextBox8.Text = CType(dr("GL_FC_CREDIT"), String).Trim
                End If
                dr.Close()
                con.Close()
                Label15.Text = "Selected Record " + CType(iRec + 1, String) + " Of " + CType(DataGridView1.RowCount, String) + " Row(s)."
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
        End Try
    End Sub

    Public Sub ClearAll()
        Button1.Text = "Add New GenLedger"
        TextBox1.ReadOnly = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.SelectedIndex = -1
        CheckBox1.Checked = False
        ComboBox2.SelectedIndex = -1
        TextBox3.Text = "0"
        TextBox4.Text = "0"
        TextBox5.Text = "0"
        TextBox10.Text = "0"
        TextBox9.Text = "0"
        TextBox8.Text = "0"
    End Sub

    Private Sub GeneralLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        conn()
        cmd.CommandText = "Select GL_TYPENAME from Master_GLType"
        dr = cmd.ExecuteReader
        While dr.Read
            ComboBox1.Items.Add(CType(dr("GL_TYPENAME"), String).Trim)
        End While
        dr.Close()

        cmd.CommandText = "Select FName from Master_Users"
        dr = cmd.ExecuteReader
        While dr.Read
            ComboBox2.Items.Add(CType(dr("FName"), String).Trim)
        End While
        dr.Close()

        cmd.CommandText = "Select GL_TYPENAME, GL_CODE, GL_DESC from View_Master_GenLedger"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_Master_GenLedger")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("View_Master_GenLedger")
        con.Close()

        ClearAll()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conn()
            Dim Actv As String
            If CheckBox1.Checked = True Then
                Actv = "T"
            Else
                Actv = "F"
            End If
            If Button1.Text = "Add New GenLedger" Then
                cmd.CommandText = "Insert Into Master_GenLedger Values ('" + TextBox1.Text + "', '" + TextBox2.Text + "', (Select GL_TYPE From Master_GLType Where GL_TYPENAME = '" + ComboBox1.Text + "'), " + TextBox3.Text + ", " + TextBox4.Text + ", " + TextBox5.Text + ", " + TextBox10.Text + ", " + TextBox9.Text + ", " + TextBox8.Text + ", '" + Actv + "', (Select UID From Master_Users Where FName = '" + ComboBox2.Text + "'))"
                cmd.ExecuteNonQuery()
                MsgBox("New General Ledger Added Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            Else
                cmd.CommandText = "Update Master_GenLedger Set GL_DESC = '" + TextBox2.Text + "', GL_TYPE = (Select GL_TYPE From Master_GLType Where GL_TYPENAME = '" + ComboBox1.Text + "'), GL_KD_OPEN=" + TextBox3.Text + ", GL_KD_DEBIT=" + TextBox4.Text + ", GL_KD_CREDIT=" + TextBox5.Text + ", GL_FC_OPEN=" + TextBox10.Text + ", GL_FC_DEBIT=" + TextBox9.Text + ", GL_FC_CREDIT=" + TextBox8.Text + ", ACTIVE='" + Actv + "', GL_USER=(Select UID From Master_Users Where FName = '" + ComboBox2.Text + "') Where GL_CODE = '" + TextBox1.Text + "'"
                cmd.ExecuteNonQuery()
                MsgBox("Selected General Ledger Updated Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            End If

            ClearAll()
            TextBox12.Text = ""

            cmd.CommandText = "Select GL_TYPENAME, GL_CODE, GL_DESC from View_Master_GenLedger"
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "View_Master_GenLedger")
            DataGridView1.ClearSelection()
            DataGridView1.DataSource = ds.Tables("View_Master_GenLedger")
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
        AccessVerify.DGVPrinting(Label1.Text, "", True, DataGridView1)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        conn()
        ClearAll()

        If TextBox12.Text = "T" Or TextBox12.Text = "F" Then
            cmd.CommandText = "Select GL_TYPENAME, GL_CODE, GL_DESC from View_Master_GenLedger Where ACTIVE = '" + TextBox12.Text + "'"
        Else
            cmd.CommandText = "Select GL_TYPENAME, GL_CODE, GL_DESC from View_Master_GenLedger Where GL_CODE Like '%" + TextBox12.Text + "%' Or GL_DESC Like '%" + TextBox12.Text + "%' Or GL_TYPENAME Like '%" + TextBox12.Text + "%'"
        End If
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_Master_GenLedger")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("View_Master_GenLedger")
        con.Close()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If Button1.Text = "Update Selected Ledger" Then
            GridRowSelect()
        End If
    End Sub

    Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox12.KeyPress
        If (e.KeyChar = (Chr(13))) Then
            Button2.PerformClick()
        End If
    End Sub
End Class