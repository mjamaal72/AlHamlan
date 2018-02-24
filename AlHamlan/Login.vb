Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail

Public Class Login
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim AccessVerify As New VerifyAccess

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

    Function GenerateOTP()
        Dim alphabets As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim small_alphabets As String = "abcdefghijklmnopqrstuvwxyz"
        Dim numbers As String = "1234567890"

        Dim characters As String = numbers
        characters += Convert.ToString(alphabets & small_alphabets) & numbers

        Dim length As Integer = Integer.Parse(8)
        Dim otp As String = String.Empty
        For i As Integer = 0 To length - 1
            Dim character As String = String.Empty
            Do
                Dim index As Integer = New Random().Next(0, characters.Length)
                character = characters.ToCharArray()(index).ToString()
            Loop While otp.IndexOf(character) <> -1
            otp += character
        Next
        Return otp
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (txtotp.Text = txtotp.Tag And txtotp.Visible = True) Or txtotp.Visible = False Then
            AccessVerify.LoadingFrm(True)
            conn()
            cmd.CommandText = "Select * from Master_Users Where UName = '" + TextBox1.Text + "' and Pass = '" + TextBox2.Text + "' And Active = 1"
            dr = cmd.ExecuteReader
            If dr.Read Then
                MainMDI.Text = "Al Hamlan & Fakhruddin General Trading CO. (User : " + CType(dr("FName"), String).Trim + " | Current Theme : " + CType(dr("Theme"), String).Trim + ")"
                MainMDI.Label1.Text = CType(dr("FName"), String).Trim
                MainMDI.lbltheme.Text = CType(dr("Theme"), String).Trim
                MainMDI.lblUID.Text = CType(dr("UID"), String).Trim
                MainMDI.LblInitials.Text = CType(dr("Initials"), String).Trim
                MainMDI.TextBox1.Enabled = True
                Dim FrmSCList As New SCList
                FrmSCList.MdiParent = MainMDI
                FrmSCList.Show()
                Me.Close()
            Else
                Label3.Visible = True
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox1.Focus()
            End If
            dr.Close()
            con.Close()
            AccessVerify.LoadingFrm(False)
        End If
    End Sub

    Private Sub TextBox2_GotFocus(sender As Object, e As EventArgs) Handles TextBox2.GotFocus
        Label3.Visible = False
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If (e.KeyChar = (Chr(13))) Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If (e.KeyChar = (Chr(13))) Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        conn()
        cmd.CommandText = "SELECT[name] as hdbname FROM master..sysdatabases where name like '%AlHamlan%'"
        dr = cmd.ExecuteReader
        While dr.Read()
            ComboBox1.Items.Add(dr("hdbname"))
        End While
        dr.Close()
        con.Close()
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        MainMDI.Label4.Text = ComboBox1.Text
        If ComboBox1.SelectedIndex = 0 Then
            lblotp.Visible = False
            txtotp.Visible = False
        Else
            Dim Hotp, EID, SEID, SPass As String
            Hotp = GenerateOTP()
            conn()
            cmd.CommandText = "Update SMSEMail Set OTP = '" + Hotp + "'"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "Select Top 1 * From SMSEMail"
            dr = cmd.ExecuteReader
            dr.Read()
            EID = dr("EMailID")
            SEID = dr("SenderMail")
            SPass = dr("SenderPass")
            dr.Close()
            con.Close()

            Try
                Dim SmtpServer As New SmtpClient()
                Dim mail As New MailMessage()
                SmtpServer.Credentials = New Net.NetworkCredential(SEID, SPass)
                SmtpServer.Port = 587
                SmtpServer.EnableSsl = True
                SmtpServer.Host = "smtp.gmail.com"
                mail = New MailMessage()
                mail.From = New MailAddress(SEID)
                mail.To.Add(EID)
                mail.Subject = "OTP For Hamlan Login : " + Hotp
                mail.Body = "OTP For Hamlan Login : " + Hotp
                SmtpServer.Send(mail)
                MsgBox("mail send")
                lblotp.Visible = True
                txtotp.Visible = True
                txtotp.Tag = Hotp
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

End Class