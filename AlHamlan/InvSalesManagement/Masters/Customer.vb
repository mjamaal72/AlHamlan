Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO

Public Class Customer
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
        PictureBox1.Image = Nothing
        Dim data As Byte()
        iRec = DataGridView1.CurrentRow.Index
        Dim SLCode As String
        Try
            With ds.Tables("View_CustomerMaster")
                SLCode = .Rows(iRec).Item(0)
                iRec = DataGridView1.CurrentRow.Index
            End With
            If SLCode <> "" Then
                conn()
                cmd.CommandText = "Select * From View_CustomerMaster Where CUST_CODE = '" + SLCode + "'"
                dr = cmd.ExecuteReader
                If dr.Read Then
                    Button1.Text = "Update Selected Customer"

                    txtcode.Text = CType(dr("CUST_CODE"), String).Trim
                    txtname.Text = CType(dr("CUST_NAME"), String).Trim
                    txtadd1.Text = CType(dr("CUST_ADD"), String).Trim
                    txtadd2.Text = CType(dr("CUST_ADD1"), String).Trim
                    txttel.Text = CType(dr("CUST_TEL"), String).Trim
                    txtfax.Text = CType(dr("CUST_FAX"), String).Trim
                    txtemail.Text = CType(dr("CUST_EMAIL"), String).Trim
                    txtcntct.Text = CType(dr("CUST_CONTACT"), String).Trim
                    dtpsdate.Value = CType(dr("CUST_START_DATE"), String).Trim
                    txtlmtamnt.Text = CType(dr("CUST_LIMIT_AMT"), String).Trim
                    txtopenbal.Text = CType(dr("CUST_OPEN_BALANCE"), String).Trim
                    txtlmtdays.Text = CType(dr("CUST_LIMIT_DAYS"), String).Trim

                    If CType(dr("CUST_ACTIVE"), String).Trim = "T" Then
                        chbactive.Checked = True
                    Else
                        chbactive.Checked = False
                    End If
                    If CType(dr("CUST_ONHOLD"), String).Trim = "T" Then
                        chbhold.Checked = True
                    Else
                        chbhold.Checked = False
                    End If
                    Try
                        data = CType(dr("IDImg"), Byte())
                        PictureBox1.Image = Image.FromStream(New MemoryStream(data))
                    Catch ez As Exception
                        PictureBox1.ImageLocation = Application.StartupPath + "\default.png"
                    End Try
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
        Button1.Text = "Add New Customer"

        txtcode.Text = "Auto Number"
        txtname.Text = ""
        txtadd1.Text = ""
        txtadd2.Text = ""
        txttel.Text = "0"
        txtfax.Text = ""
        txtemail.Text = ""
        txtcntct.Text = ""
        PictureBox1.Image = Nothing
        dtpsdate.Value = Date.Now
        txtlmtamnt.Text = "0"
        txtopenbal.Text = "0"
        txtlmtdays.Text = "0"

        chbactive.Checked = True
        chbhold.Checked = False

        PictureBox1.ImageLocation = Application.StartupPath + "\default.png"
    End Sub

    Private Sub GeneralLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        conn()
        cmd.CommandText = "Select CUST_CODE, CUST_NAME, CUST_TEL, CUST_ACTIVE As Actv from View_CustomerMaster Order By CUST_CODE"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_CustomerMaster")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("View_CustomerMaster")
        'DataGridView1.Columns(DataGridView1.Columns("CUST_CODE").Index).Visible = False
        DataGridView1.Columns(0).Width = 120
        DataGridView1.Columns(1).Width = 510
        DataGridView1.Columns(2).Width = 120
        DataGridView1.Columns(3).Width = 70
        con.Close()

        ClearAll()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtname.Text <> "" Then
            Try
                conn()
                Dim Actv, Hold, rcpttype As String
                If chbactive.Checked = True Then
                    Actv = "T"
                Else
                    Actv = "F"
                End If
                If chbhold.Checked = True Then
                    Hold = "T"
                Else
                    Hold = "F"
                End If

                Dim ms As New MemoryStream()
                PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                Dim data As Byte() = ms.GetBuffer()

                If Button1.Text = "Add New Customer" Then
                    cmd.CommandText = "Insert Into CUSTOMER_MASTER Values ((Select COALESCE((Select Top 1 CUST_CODE + 1 From CUSTOMER_MASTER Order By CUST_CODE Desc),1)),'" + txtname.Text + "', '" + txttel.Text + "', '" + txtfax.Text + "', '" + txtemail.Text + "', '" + txtcntct.Text + "', '" + dtpsdate.Value + "', '" + txtadd1.Text + "', '" + txtadd2.Text + "', " + txtopenbal.Text + ", " + txtlmtamnt.Text + ", " + txtlmtdays.Text + ", '" + Actv + "', '" + Hold + "', @photo)"
                    Dim p As New SqlParameter("@photo", SqlDbType.Image)
                    p.Value = data
                    cmd.Parameters.Add(p)
                    cmd.ExecuteNonQuery()
                    MsgBox("New Customer Added Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
                Else
                    cmd.CommandText = "Update CUSTOMER_MASTER Set CUST_NAME='" + txtname.Text + "', CUST_TEL='" + txttel.Text + "', CUST_FAX='" + txtfax.Text + "', CUST_EMAIL='" + txtemail.Text + "', CUST_CONTACT='" + txtcntct.Text + "', CUST_START_DATE='" + dtpsdate.Value + "', CUST_ADD='" + txtadd1.Text + "', CUST_ADD1='" + txtadd2.Text + "', CUST_OPEN_BALANCE=" + txtopenbal.Text + ", CUST_LIMIT_AMT=" + txtlmtamnt.Text + ", CUST_LIMIT_DAYS=" + txtlmtdays.Text + ", CUST_ACTIVE='" + Actv + "', CUST_ONHOLD='" + Hold + "', IDImg = @photo Where CUST_CODE=" + txtcode.Text + ""
                    Dim p As New SqlParameter("@photo", SqlDbType.Image)
                    p.Value = data
                    cmd.Parameters.Add(p)
                    cmd.ExecuteNonQuery()
                    MsgBox("Selected Customer Updated Successfully.", MsgBoxStyle.Information, "H.F. General Trading CO.")
                End If
                cmd.CommandText = "Update Master_GenLedger Set GL_KD_OPEN = (Select Sum(CUST_OPEN_BALANCE) From CUSTOMER_MASTER) Where GL_CODE = '199-000'"
                cmd.ExecuteNonQuery()

                ClearAll()
                TextBox12.Text = ""

                cmd.CommandText = "Select CUST_CODE, CUST_NAME, CUST_TEL, CUST_ACTIVE As Actv from View_CustomerMaster Order By CUST_CODE"
                da = New SqlDataAdapter(cmd)
                ds = New DataSet
                da.Fill(ds, "View_CustomerMaster")
                DataGridView1.ClearSelection()
                DataGridView1.DataSource = ds.Tables("View_CustomerMaster")
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message, MsgBoxStyle.Information, "H.F. General Trading CO.")
            End Try
        Else
            MsgBox("Enter Proper Details To Add\Update Customer.", MsgBoxStyle.Information, "H.F. General Trading CO.")
        End If
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
        ClearAll()

        If TextBox12.Text = "T" Or TextBox12.Text = "F" Then
            cmd.CommandText = "Select CUST_CODE, CUST_NAME, CUST_TEL, CUST_ACTIVE As Actv from View_CustomerMaster Where CUST_ACTIVE = '" + TextBox12.Text + "' Order By CUST_CODE"
        Else
            cmd.CommandText = "Select CUST_CODE, CUST_NAME, CUST_TEL, CUST_ACTIVE As Actv from View_CustomerMaster Where convert(varchar, CUST_CODE) = '" + TextBox12.Text + "' OR CUST_NAME Like '%" + TextBox12.Text + "%' OR CUST_TEL Like '%" + TextBox12.Text + "%' Order By CUST_CODE"
        End If
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "View_CustomerMaster")
        DataGridView1.ClearSelection()
        DataGridView1.DataSource = ds.Tables("View_CustomerMaster")
        con.Close()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If Button1.Text = "Update Selected Customer" Then
            GridRowSelect()
        End If
    End Sub

    Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox12.KeyPress
        If (e.KeyChar = (Chr(13))) Then
            Button2.PerformClick()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ClearAll()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub
End Class