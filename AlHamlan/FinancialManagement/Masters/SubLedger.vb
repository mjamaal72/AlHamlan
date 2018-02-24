Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class SubLedger
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
        Dim GLCode, SLCode As String
        Try
            With ds.Tables("View_Master_SubLedger")
                SLCode = .Rows(iRec).Item(0)
                GLCode = .Rows(iRec).Item(3)
                iRec = DataGridView1.CurrentRow.Index
            End With
            If GLCode <> "" And SLCode <> "" Then
                conn()
                cmd.CommandText = "Select * From View_Master_SubLedger Where SL_GL_CODE = '" + GLCode + "' And SL_CODE = '" + SLCode + "'"
                dr = cmd.ExecuteReader
                If dr.Read Then
                    Button1.Text = "Update Selected Sub Ledger"
                    TextBox2.ReadOnly = True
                    ComboBox1.Enabled = False

                    ComboBox1.SelectedValue = CType(dr("SL_GL_CODE"), String).Trim
                    TextBox2.Text = CType(dr("SL_CODE"), String).Trim
                    TextBox1.Text = CType(dr("SL_NAME"), String).Trim
                    DateTimePicker1.Value = CType(dr("SL_START_DATE"), String).Trim
                    If CType(dr("SL_USER"), String).Trim <> "" Then
                        ComboBox2.SelectedValue = CType(dr("SL_USER"), String).Trim
                    Else
                        ComboBox2.SelectedIndex = -1
                    End If
                    If CType(dr("SL_Active"), String).Trim = "T" Then
                        CheckBox1.Checked = True
                    Else
                        CheckBox1.Checked = False
                    End If
                    TextBox3.Text = CType(dr("SL_KD_OPEN_BALANCE"), String).Trim
                    TextBox4.Text = CType(dr("SL_KD_DEBIT_BALANCE"), String).Trim
                    TextBox5.Text = CType(dr("SL_KD_CREDIT_BALANCE"), String).Trim
                    TextBox10.Text = CType(dr("SL_FC_OPEN_BALANCE"), String).Trim
                    TextBox9.Text = CType(dr("SL_FC_DEBIT_BALANCE"), String).Trim
                    TextBox8.Text = CType(dr("SL_FC_CREDIT_BALANCE"), String).Trim
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
        Button1.Text = "Add New Sub Ledger"
        TextBox2.ReadOnly = False
        ComboBox1.Enabled = True

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
        cmd.CommandText = "Select '('+GL_Code+') '+GL_DESC AS GLDESC, GL_CODE from Master_GenLedger"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "Master_GenLedger")
        ComboBox1.DisplayMember = "GLDESC"
        ComboBox1.ValueMember = "GL_CODE"
        ComboBox1.DataSource = ds.Tables("Master_GenLedger")

        cmd.CommandText = "Select convert(varchar,[UID]) As UsrID, FName from Master_Users"
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "Master_Users")
        ComboBox2.DisplayMember = "FName"
        ComboBox2.ValueMember = "UsrID"
        ComboBox2.DataSource = ds.Tables("Master_Users")

        cmd.CommandText = "Select Sl_Code, SL_Name, '('+SL_GL_CODE+ ' | '+GL_TYPENAME+') '+GL_DESC As GLDesc, SL_GL_CODE from View_MASTER_SUBLEDGER Where SL_ACC_TYPE = 'SL' Order By SL_GL_CODE"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_MASTER_SUBLEDGER")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("View_MASTER_SUBLEDGER")
        DataGridView1.Columns(DataGridView1.Columns("SL_GL_CODE").Index).Visible = False
        con.Close()

        ClearAll()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Or TextBox1.Text = "" Then
            MsgBox("Cannot Submit Blank SubLedger. Enter Details Properly.", MsgBoxStyle.Critical, "H.F. General Trading CO.")
            Exit Sub
        End If
        Try
            conn()
            Dim Actv As String
            If CheckBox1.Checked = True Then
                Actv = "T"
            Else
                Actv = "F"
            End If

            If Button1.Text = "Add New Sub Ledger" Then
                cmd.CommandText = "Insert Into MASTER_SUBLEDGER (SrNo, SL_ACC_TYPE, SL_GL_CODE, SL_CODE, SL_NAME, SL_START_DATE, SL_KD_OPEN_BALANCE, SL_KD_DEBIT_BALANCE, SL_KD_CREDIT_BALANCE, SL_FC_OPEN_BALANCE, SL_FC_DEBIT_BALANCE, SL_FC_CREDIT_BALANCE, SL_ACTIVE, SL_USER) Values ((Select COALESCE((Select Top 1 SrNo + 1 From MASTER_SUBLEDGER Order By SrNo Desc),1)), 'SL', '" + ComboBox1.SelectedValue + "', '" + TextBox2.Text + "', '" + TextBox1.Text + "', '" + DateTimePicker1.Value + "', " + TextBox3.Text + ", " + TextBox4.Text + ", " + TextBox5.Text + ", " + TextBox10.Text + ", " + TextBox9.Text + ", " + TextBox8.Text + ", '" + Actv + "', (Select UID From Master_Users Where FName = '" + ComboBox2.Text + "'))"
                cmd.ExecuteNonQuery()
                MsgBox("New General Ledger Added Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            Else
                cmd.CommandText = "Update MASTER_SUBLEDGER Set SL_NAME='" + TextBox1.Text + "', SL_START_DATE='" + DateTimePicker1.Value + "', SL_KD_OPEN_BALANCE=" + TextBox3.Text + ", SL_KD_DEBIT_BALANCE=" + TextBox4.Text + ", SL_KD_CREDIT_BALANCE=" + TextBox5.Text + ", SL_FC_OPEN_BALANCE=" + TextBox10.Text + ", SL_FC_DEBIT_BALANCE=" + TextBox9.Text + ", SL_FC_CREDIT_BALANCE=" + TextBox8.Text + ", SL_ACTIVE='" + Actv + "', SL_USER='" + ComboBox2.SelectedValue + "' Where SL_ACC_TYPE='SL' AND SL_GL_CODE='" + ComboBox1.SelectedValue + "' AND SL_CODE='" + TextBox2.Text + "'"
                cmd.ExecuteNonQuery()
                MsgBox("Selected Sub Ledger Updated Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            End If

            ClearAll()
            TextBox12.Text = ""

            cmd.CommandText = "Select Sl_Code, SL_Name, '('+SL_GL_CODE+ ' | '+GL_TYPENAME+') '+GL_DESC As GLDesc, SL_GL_CODE from View_MASTER_SUBLEDGER Where SL_ACC_TYPE = 'SL' Order By SL_GL_CODE"
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "View_MASTER_SUBLEDGER")
            DataGridView1.ClearSelection()
            DataGridView1.DataSource = ds.Tables("View_MASTER_SUBLEDGER")
            DataGridView1.Columns(DataGridView1.Columns("SL_GL_CODE").Index).Visible = False
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
            cmd.CommandText = "Select Sl_Code, SL_Name, '('+SL_GL_CODE+ ' | '+GL_TYPENAME+') '+GL_DESC As GLDesc, SL_GL_CODE from View_MASTER_SUBLEDGER Where SL_ACC_TYPE = 'SL' And SL_ACTIVE = '" + TextBox12.Text + "' Order By SL_GL_CODE"
        Else
            cmd.CommandText = "Select Sl_Code, SL_Name, '('+SL_GL_CODE+ ' | '+GL_TYPENAME+') '+GL_DESC As GLDesc, SL_GL_CODE from View_MASTER_SUBLEDGER Where SL_ACC_TYPE = 'SL' And (SL_GL_CODE Like '%" + TextBox12.Text + "%' OR Sl_Code Like '%" + TextBox12.Text + "%' OR SL_Name Like '%" + TextBox12.Text + "%' OR GL_TYPENAME Like '%" + TextBox12.Text + "%') Order By SL_GL_CODE"
        End If
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_MASTER_SUBLEDGER")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("View_MASTER_SUBLEDGER")
        DataGridView1.Columns(DataGridView1.Columns("SL_GL_CODE").Index).Visible = False
        con.Close()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If Button1.Text = "Update Selected Sub Ledger" Then
            GridRowSelect()
        End If
    End Sub

    Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox12.KeyPress
        If (e.KeyChar = (Chr(13))) Then
            Button2.PerformClick()
        End If
    End Sub
End Class