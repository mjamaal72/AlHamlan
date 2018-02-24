Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class Supplier
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
            With ds.Tables("View_Master_Supplier")
                SLCode = .Rows(iRec).Item(0)
                GLCode = .Rows(iRec).Item(3)
                iRec = DataGridView1.CurrentRow.Index
            End With
            If GLCode <> "" And SLCode <> "" Then
                conn()
                cmd.CommandText = "Select * From View_Master_Supplier Where SL_ACC_TYPE = 'AP' AND SL_GL_CODE = '" + GLCode + "' And SL_CODE = '" + SLCode + "'"
                dr = cmd.ExecuteReader
                If dr.Read Then
                    Button1.Text = "Update Selected Supplier"
                    TextBox7.ReadOnly = True

                    TextBox7.Text = CType(dr("SL_CODE"), String).Trim
                    TextBox11.Text = CType(dr("SL_NAME"), String).Trim
                    TextBox2.Text = CType(dr("SL_ADD"), String).Trim
                    TextBox1.Text = CType(dr("SL_ADD1"), String).Trim
                    TextBox13.Text = CType(dr("SL_TEL"), String).Trim
                    TextBox14.Text = CType(dr("SL_FAX"), String).Trim
                    TextBox15.Text = CType(dr("SL_EMAIL"), String).Trim
                    TextBox16.Text = CType(dr("SL_CONTACT"), String).Trim
                    TextBox6.Text = CType(dr("SL_BankACName"), String).Trim
                    TextBox17.Text = CType(dr("SUP_MIN_STK"), String).Trim
                    DateTimePicker1.Value = CType(dr("SL_START_DATE"), String).Trim

                    TextBox3.Text = CType(dr("SL_KD_OPEN_BALANCE"), String).Trim
                    TextBox4.Text = CType(dr("SL_KD_DEBIT_BALANCE"), String).Trim
                    TextBox5.Text = CType(dr("SL_KD_CREDIT_BALANCE"), String).Trim

                    ComboBox3.SelectedValue = CType(dr("SL_CURCODE"), String).Trim
                    TextBox10.Text = CType(dr("SL_FC_OPEN_BALANCE"), String).Trim
                    TextBox9.Text = CType(dr("SL_FC_DEBIT_BALANCE"), String).Trim
                    TextBox8.Text = CType(dr("SL_FC_CREDIT_BALANCE"), String).Trim

                    If CType(dr("SL_Active"), String).Trim = "T" Then
                        CheckBox1.Checked = True
                    Else
                        CheckBox1.Checked = False
                    End If
                    If CType(dr("SL_ONHOLD"), String).Trim = "T" Then
                        CheckBox2.Checked = True
                    Else
                        CheckBox2.Checked = False
                    End If
                    If CType(dr("SL_USER"), String).Trim <> "" Then
                        ComboBox1.SelectedValue = CType(dr("SL_USER"), String).Trim
                    Else
                        ComboBox1.SelectedIndex = -1
                    End If
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
        Button1.Text = "Add New Supplier"
        TextBox7.ReadOnly = False

        TextBox7.Text = ""
        TextBox11.Text = ""
        TextBox2.Text = ""
        TextBox1.Text = ""
        TextBox13.Text = "0"
        TextBox14.Text = ""
        TextBox6.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = "0"

        DateTimePicker1.Value = Date.Now

        TextBox3.Text = "0"
        TextBox4.Text = "0"
        TextBox5.Text = "0"

        ComboBox3.SelectedIndex = -1
        TextBox10.Text = "0"
        TextBox9.Text = "0"
        TextBox8.Text = "0"

        CheckBox1.Checked = True
        CheckBox2.Checked = False
        ComboBox1.SelectedIndex = -1
    End Sub

    Private Sub GeneralLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        conn()
        cmd.CommandText = "Select convert(varchar,[UID]) As UsrID, FName from Master_Users"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "Master_Users")
        ComboBox1.DisplayMember = "FName"
        ComboBox1.ValueMember = "UsrID"
        ComboBox1.DataSource = ds.Tables("Master_Users")

        cmd.CommandText = "Select CUR_CODE, '('+CUR_CODE+') '+CUR_DESC As CDesc from MASTER_CURRENCY"
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "MASTER_CURRENCY")
        ComboBox3.DisplayMember = "CDesc"
        ComboBox3.ValueMember = "CUR_CODE"
        ComboBox3.DataSource = ds.Tables("MASTER_CURRENCY")

        cmd.CommandText = "Select Sl_Code, SL_Name, '('+SL_GL_CODE+') '+GL_DESC As GLDesc, SL_GL_CODE from View_Master_Supplier Where SL_ACC_TYPE = 'AP' Order By Sl_Code"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_Master_Supplier")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("View_Master_Supplier")
        DataGridView1.Columns(DataGridView1.Columns("SL_GL_CODE").Index).Visible = False
        con.Close()

        ClearAll()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox7.Text <> "" Then
            Try
                conn()
                Dim Actv, Hold As String
                If CheckBox1.Checked = True Then
                    Actv = "T"
                Else
                    Actv = "F"
                End If
                If CheckBox2.Checked = True Then
                    Hold = "T"
                Else
                    Hold = "F"
                End If
                If Button1.Text = "Add New Supplier" Then
                    cmd.CommandText = "Insert Into MASTER_SUBLEDGER Values ((Select COALESCE((Select Top 1 SrNo + 1 From MASTER_SUBLEDGER Order By SrNo Desc),1)), 'AP', '251', '" + TextBox7.Text + "', '" + TextBox11.Text + "', '" + TextBox13.Text + "', '" + TextBox14.Text + "', '" + TextBox15.Text + "', '" + TextBox6.Text + "', '" + TextBox16.Text + "', '" + DateTimePicker1.Value + "', '" + TextBox2.Text + "', '" + TextBox1.Text + "', " + TextBox17.Text + ", " + TextBox3.Text + ", " + TextBox4.Text + ", " + TextBox5.Text + ", " + TextBox10.Text + ", '" + ComboBox3.SelectedValue + "', " + TextBox9.Text + ", " + TextBox8.Text + ", '" + Actv + "', '" + Hold + "', (Select UID From Master_Users Where FName = '" + ComboBox1.Text + "'))"
                    cmd.ExecuteNonQuery()
                    MsgBox("New Supplier Added Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
                Else
                    cmd.CommandText = "Update MASTER_SUBLEDGER Set SL_NAME='" + TextBox11.Text + "', SL_START_DATE='" + DateTimePicker1.Value + "', SL_KD_OPEN_BALANCE=" + TextBox3.Text + ", SL_KD_DEBIT_BALANCE=" + TextBox4.Text + ", SL_KD_CREDIT_BALANCE=" + TextBox5.Text + ", SL_FC_OPEN_BALANCE=" + TextBox10.Text + ", SL_FC_DEBIT_BALANCE=" + TextBox9.Text + ", SL_FC_CREDIT_BALANCE=" + TextBox8.Text + ", SL_ACTIVE='" + Actv + "', SL_ADD='" + TextBox2.Text + "', SL_ADD1='" + TextBox1.Text + "', SL_TEL='" + TextBox13.Text + "', SL_FAX='" + TextBox14.Text + "', SL_EMAIL='" + TextBox15.Text + "', SL_CONTACT='" + TextBox16.Text + "', SUP_MIN_STK=" + TextBox17.Text + ", SL_CURCODE='" + ComboBox3.SelectedValue + "', SL_ONHOLD='" + Hold + "', SL_USER='" + ComboBox1.SelectedValue + "', SL_BankACName = '" + TextBox6.Text + "' Where SL_ACC_TYPE='AP' AND SL_GL_CODE='251' AND SL_CODE='" + TextBox7.Text + "'"
                    cmd.ExecuteNonQuery()
                    MsgBox("Selected Supplier Updated Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
                End If
                cmd.CommandText = "Update Master_GenLedger Set GL_KD_OPEN = (Select Sum(SL_KD_OPEN_BALANCE) From View_Master_Supplier) Where GL_CODE = '251'"
                cmd.ExecuteNonQuery()

                ClearAll()
                TextBox12.Text = ""

                cmd.CommandText = "Select Sl_Code, SL_Name, '('+SL_GL_CODE+') '+GL_DESC As GLDesc, SL_GL_CODE from View_Master_Supplier Where SL_ACC_TYPE = 'AP' Order By Sl_Code"
                da = New SqlDataAdapter(cmd)
                ds = New DataSet
                da.Fill(ds, "View_Master_Supplier")
                DataGridView1.ClearSelection()
                DataGridView1.DataSource = ds.Tables("View_Master_Supplier")
                DataGridView1.Columns(DataGridView1.Columns("SL_GL_CODE").Index).Visible = False
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
            End Try
        Else
            MsgBox("Enter Proper Details To Add\Update Supplier.", MsgBoxStyle.Information, "H.F. General Trading CO.")
        End If

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
            cmd.CommandText = "Select Sl_Code, SL_Name, '('+SL_GL_CODE+') '+GL_DESC As GLDesc, SL_GL_CODE from View_Master_Supplier Where SL_ACC_TYPE = 'AP' And (SL_ACTIVE = '" + TextBox12.Text + "' OR SL_ONHOLD = '" + TextBox12.Text + "') Order By Sl_Code"
        Else
            cmd.CommandText = "Select Sl_Code, SL_Name, '('+SL_GL_CODE+') '+GL_DESC As GLDesc, SL_GL_CODE from View_Master_Supplier Where SL_ACC_TYPE = 'AP' And (SL_GL_CODE Like '%" + TextBox12.Text + "%' OR Sl_Code Like '%" + TextBox12.Text + "%' OR SL_Name Like '%" + TextBox12.Text + "%' OR GL_DESC Like '%" + TextBox12.Text + "%') Order By Sl_Code"
        End If
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_Master_Supplier")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("View_Master_Supplier")
        DataGridView1.Columns(DataGridView1.Columns("SL_GL_CODE").Index).Visible = False
        con.Close()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If Button1.Text = "Update Selected Supplier" Then
            GridRowSelect()
        End If
    End Sub

    Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox12.KeyPress
        If (e.KeyChar = (Chr(13))) Then
            Button2.PerformClick()
        End If
    End Sub
End Class