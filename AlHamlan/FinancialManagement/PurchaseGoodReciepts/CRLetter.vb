Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class CRLetter

#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da, da2 As SqlDataAdapter
    Dim ds, ds2 As DataSet
    Dim iRec As Integer
    Dim pono As String
    
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
        iRec = DataGridView1.CurrentRow.Index
        Dim SLCode As String
        Try
            With ds.Tables("View_LetterOfCredit")
                SLCode = .Rows(iRec).Item(0)
                iRec = DataGridView1.CurrentRow.Index
            End With
            If SLCode <> "" Then
                If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Update") = False Then
                    Button1.Visible = False
                Else
                    Button1.Visible = True
                End If

                conn()
                cmd.CommandText = "Select * From View_LetterOfCredit Where LC_No = '" + SLCode + "'"
                dr = cmd.ExecuteReader
                If dr.Read Then
                    Button1.Text = "Update Selected LC"
                    txtlccode.Text = CType(dr("LC_NO"), String).Trim
                    txtbank.Text = CType(dr("LC_BANK"), String).Trim
                    pono = CType(dr("LC_INDENT_NO"), String).Trim
                    txtlcterm.Text = CType(dr("LC_TERMS"), String).Trim
                    txtamnt.Text = CType(dr("LC_AMOUNT"), String).Trim
                    cbcrncy.SelectedValue = CType(dr("LC_CURRENCY"), String).Trim
                    cbshiptrm.SelectedValue = CType(dr("LC_SHIPMENT_TERMS"), String).Trim
                    txtdaprd.Text = CType(dr("LC_DA_PEROID"), String).Trim
                    dtplcdate.Value = CType(dr("LCDATE"), String).Trim
                    dtpexdate.Value = CType(dr("LCExpDATE"), String).Trim
                    dtpshipdate.Value = CType(dr("LCSDATE"), String).Trim
                    txtdtls.Text = CType(dr("LC_MEMO"), String).Trim
                    cbsuplr.SelectedValue = CType(dr("LC_BENEFICIARY"), String).Trim
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
        If AccessVerify.CheckCtrlAccess(Me.Name.ToString, "Add") = False Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
        Button1.Text = "Add New LC"
        txtlccode.Text = "Auto Number"
        txtbank.Text = ""
        cbsuplr.SelectedIndex = -1
        cbpono.SelectedIndex = -1
        txtlcterm.Text = ""
        txtamnt.Text = "0"
        cbcrncy.SelectedValue = "KD"
        cbshiptrm.SelectedIndex = -1
        txtdaprd.Text = ""
        txtdtls.Text = ""
        dtplcdate.Value = Date.Now
        dtpexdate.Value = Date.Now
        dtpshipdate.Value = Date.Now
    End Sub

    Private Sub GeneralLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        conn()
        cmd.CommandText = "Select Distinct SL_Code+' | '+SL_NAME As SlName, SL_Code from View_Master_Supplier"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_Master_Supplier")
        cbsuplr.DisplayMember = "SlName"
        cbsuplr.ValueMember = "SL_Code"
        cbsuplr.DataSource = ds.Tables("View_Master_Supplier")

        cmd.CommandText = "Select CUR_CODE, '('+CUR_CODE+') '+CUR_DESC As CDesc from MASTER_CURRENCY"
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "MASTER_CURRENCY")
        cbcrncy.DisplayMember = "CDesc"
        cbcrncy.ValueMember = "CUR_CODE"
        cbcrncy.DataSource = ds.Tables("MASTER_CURRENCY")

        cmd.CommandText = "Select SHP_CODE+' | '+ SHP_DESC As ShpTerm, SHP_CODE from MASTER_SHIPMENT_TERMS"
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "MASTER_SHIPMENT_TERMS")
        cbshiptrm.DisplayMember = "ShpTerm"
        cbshiptrm.ValueMember = "SHP_CODE"
        cbshiptrm.DataSource = ds.Tables("MASTER_SHIPMENT_TERMS")

        cmd.CommandText = "Select LC_No, Convert(varchar, LC_Date, 107) As LCDate, Convert(varchar, LC_EXPIRY_Date, 107) As ExpDate, LC_BANK As Bank, SL_NAME As Beneficiary, LC_AMOUNT As Amnt from View_LetterOfCredit Order By LC_NO"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_LetterOfCredit")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("View_LetterOfCredit")
        con.Close()

        ClearAll()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub CBDrawItem(sender As Object, e As System.Windows.Forms.DrawItemEventArgs)
        Dim myCB As ComboBox = CType(sender, ComboBox)

        Dim x, y As Integer
        x = 0
        If myCB.Tag = "" Then
            y = 0
        Else
            y = CType(myCB.Tag, Integer)
        End If
        ' Draw the default background
        e.DrawBackground()

        ' The ComboBox is bound to a DataTable,
        ' so the items are DataRowView objects.
        Dim drv As DataRowView = CType(myCB.Items(e.Index), DataRowView)

        For i As Integer = y To drv.Row.Table.Columns.Count - 1
            Dim r1 As Rectangle = e.Bounds
            If x = 0 Then
                r1.Width = r1.Width / (drv.Row.Table.Columns.Count - y)
            Else
                r1.X = e.Bounds.Width / ((drv.Row.Table.Columns.Count - y) / x)
                r1.Width = r1.Width / (drv.Row.Table.Columns.Count - y)
            End If

            ' Draw the text on the first column
            Using sb As SolidBrush = New SolidBrush(e.ForeColor)
                e.Graphics.DrawString(drv(i).ToString(), e.Font, sb, r1)
            End Using

            ' Draw a line to isolate the columns 
            Using p As Pen = New Pen(Color.Black)
                e.Graphics.DrawLine(p, r1.Right, 0, r1.Right, r1.Bottom)
            End Using
            x = x + 1
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SrNo As String = ""
        Dim EmailMode As String = ""
        Try
            conn()
            If Button1.Text = "Add New LC" Then
                cmd.CommandText = "Insert Into LETTER_OF_CREDIT Values ((Select COALESCE((Select Top 1 LC_NO + 1 From LETTER_OF_CREDIT Order By LC_NO Desc),1)), '" + dtplcdate.Value + "', '" + txtbank.Text + "', '" + dtpexdate.Text + "', '" + cbcrncy.SelectedValue + "', '" + cbpono.SelectedValue.ToString + "', '" + txtlcterm.Text + "', '" + cbsuplr.SelectedValue.ToString + "', " + txtamnt.Text + ", '" + cbshiptrm.SelectedValue + "', '" + txtdaprd.Text + "', '" + dtpshipdate.Value + "', '" + txtdtls.Text + "', '" + MainMDI.lblUID.Text + "')"
                cmd.ExecuteNonQuery()
                EmailMode = "Add"
                MsgBox("New LC Added Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            Else
                cmd.CommandText = "Update LETTER_OF_CREDIT Set LC_DATE='" + dtplcdate.Value + "', LC_BANK='" + txtbank.Text + "', LC_EXPIRY_DATE='" + dtpexdate.Text + "', LC_CURRENCY='" + cbcrncy.SelectedValue + "', LC_INDENT_NO='" + cbpono.SelectedValue.ToString + "', LC_TERMS='" + txtlcterm.Text + "', LC_BENEFICIARY='" + cbsuplr.SelectedValue.ToString + "', LC_AMOUNT=" + txtamnt.Text + ", LC_SHIPMENT_TERMS='" + cbshiptrm.SelectedValue + "', LC_DA_PEROID='" + txtdaprd.Text + "', LC_SHIPMENT_DATE='" + dtpshipdate.Value + "', LC_MEMO='" + txtdtls.Text + "' Where LC_NO='" + txtlccode.Text + "'"
                cmd.ExecuteNonQuery()
                SrNo = txtlccode.Text
                EmailMode = "Update"
                MsgBox("Selected LC Updated Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            End If

            ClearAll()
            TextBox12.Text = ""

            cmd.CommandText = "Select LC_No, Convert(varchar, LC_Date, 107) As LCDate, Convert(varchar, LC_EXPIRY_Date, 107) As ExpDate, LC_BANK As Bank, SL_NAME As Beneficiary, LC_AMOUNT As Amnt from View_LetterOfCredit Order By LC_NO"
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "View_LetterOfCredit")
            DataGridView1.ClearSelection()
            DataGridView1.DataSource = ds.Tables("View_LetterOfCredit")
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
        End Try
        If EmailMode <> "" Then
            AccessVerify.NotifyChanges(Me.Name.ToString, EmailMode, SrNo)
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

        cmd.CommandText = "Select LC_No, LC_Date As LCDate, LC_EXPIRY_Date As ExpDate, LC_BANK As Bank, SL_NAME As Beneficiary, LC_AMOUNT As Amnt from View_LetterOfCredit Where LC_No Like '%" + TextBox12.Text + "%' OR LC_Date Like '%" + TextBox12.Text + "%' OR LC_EXPIRY_Date Like '%" + TextBox12.Text + "%' OR LC_BANK Like '%" + TextBox12.Text + "%' OR SL_NAME Like '%" + TextBox12.Text + "%' Order By LC_NO "
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_LetterOfCredit")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("View_LetterOfCredit")
        con.Close()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If Button1.Text = "Update Selected LC" Then
            GridRowSelect()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ClearAll()
    End Sub

    Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox12.KeyPress
        If (e.KeyChar = (Chr(13))) Then
            Button2.PerformClick()
        End If
    End Sub

    Private Sub cbsuplr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbsuplr.SelectedIndexChanged
        If cbsuplr.Text <> "" Then

            conn()
            cmd.CommandText = "Select Distinct convert(varchar,PUR_ORDER_NO)+' | PO Amount : '+Convert(varchar,PUR_NET_VALUE) As POName, PUR_ORDER_NO from View_PO_Main Where SL_CODE = '" + cbsuplr.SelectedValue.ToString + "'"
            da2 = New SqlDataAdapter(cmd)
            ds2 = New DataSet
            da2.Fill(ds2, "View_PO_Main")
            cbpono.DisplayMember = "POName"
            cbpono.ValueMember = "PUR_ORDER_NO"
            cbpono.DataSource = ds2.Tables("View_PO_Main")
            If pono <> "" Then
                cbpono.SelectedValue = pono
            End If
            pono = ""
            con.Close()
        End If

    End Sub

End Class