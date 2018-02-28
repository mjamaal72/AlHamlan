Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.ComponentModel

Public Class MainMDI
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Public mnMenu As New MenuStrip
    Dim KeyComb As String
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
        con.ConnectionString = Replace(abc, "AlHamlan", Label4.Text)
        con.Open()
        cmd = New SqlCommand
        cmd.Connection = con
    End Sub

    Public Sub FrmOpen(ByVal FrmName As String)
        Dim FrmTxt As String
        Dim open As Boolean = True
        For Each frm As Form In MdiChildren
            If frm.Name = FrmName Then
                open = False
            End If
            FrmTxt = frm.Text
        Next

        'If open Then
        Dim FrmStr As New Form
        FrmName = [Assembly].GetEntryAssembly.GetName.Name & "." & FrmName
        FrmStr = DirectCast([Assembly].GetEntryAssembly.CreateInstance(FrmName), Form)
        FrmStr.MdiParent = Me
        FrmStr.MaximizeBox = False
        FrmStr.KeyPreview = True
        If FrmName.Contains("Login") = True Then
            FrmStr.StartPosition = FormStartPosition.Manual
            FrmStr.Location = New Point((Me.ClientSize.Width - FrmStr.Width) / 2, ((Me.ClientSize.Height - FrmStr.Height) / 2) - 50)
        Else
            FrmStr.Left = 0
            FrmStr.Top = 0
        End If
        FrmStr.Show()
        'Else
        '    MessageBox.Show(FrmTxt + " Is Already Open.", "H.F. General Trading CO.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
    End Sub

    Private Sub MDIParent_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim cnt As Integer
        conn()
        cmd.CommandText = "SELECT ((SELECT COUNT(*) AS cnt from GRN_HEADER where GRN_POSTED ='F' AND GRN_CANCEL = 'F')+(Select COUNT(*) from IGN_HEADER where REC_POSTED ='F')+(Select COUNT(*) from VOUCHER_HEADER where VOU_POSTED ='F')+(Select COUNT(*)from PURCHASE_HEADER where PUR_POSTED ='F')+(Select COUNT(*) from PROFORMA_HEADER where INV_POSTED ='F' AND INV_CANCEL = 'F')+(Select COUNT(*) from SALES_HEADER where INV_POSTED ='F' AND INV_CANCEL = 'F')) AS Cnt"
        dr = cmd.ExecuteReader
        dr.Read()
        cnt = dr("Cnt")
        dr.Close()
        con.Close()
        If cnt > 0 Then
            If MsgBox("Before Closing Application" + vbNewLine + "There Are " + CType(cnt, String) + " Unposted Transactions." + vbNewLine + "Do you want to attend ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                e.Cancel = True
                FrmOpen("Dashbrd")
            Else
                Application.Exit()
            End If
        Else
            If MsgBox("Are you sure you want to Exit !", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                Application.Exit()
            Else
                e.Cancel = True
                Exit Sub
            End If
        End If

    End Sub

    Private Sub MDIParent_Load(sender As Object, e As EventArgs) Handles Me.Load
        FrmOpen("Login")
        Dim theMdiClient As Control = Me.Controls(Me.Controls.Count - 1)
        AddHandler theMdiClient.Click, AddressOf MainMDI_Click
    End Sub

    Private Sub MainMenu_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If sender.ToString = "Close All Forms" Then
            For Each frm As Form In Me.MdiChildren
                frm.Close()
            Next
            Exit Sub
        ElseIf sender.ToString = "Cascade Windows" Then
            Me.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade)
        End If

        conn()
        cmd.CommandText = "Select FrmName From MASTER_MENU Where MenuName = '" + sender.ToString.Trim + "'"
        dr = cmd.ExecuteReader
        dr.Read()
        If dr("FrmName") <> "" Then
            AccessVerify.LoadingFrm(True)
            FrmOpen(dr("FrmName"))
        End If
        dr.Close()
        con.Close()
    End Sub

    Private Sub lblUID_TextChanged(sender As Object, e As EventArgs) Handles lblUID.TextChanged
        If lblUID.Text <> "UID" Then

            conn()
            cmd.CommandText = "Select * from UserAccessMenu(" + lblUID.Text + ") Where ParentID = 0 Order By SrNo"
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    mnMenu.Items.Add(dr("MenuName").ToString, Nothing, New System.EventHandler(AddressOf MainMenu_OnClick))
                    Me.Controls.Add(mnMenu)
                End While
            End If
            dr.Close()

            cmd.CommandText = "Select TOP 1 * from FirmMaster"
            dr = cmd.ExecuteReader
            dr.Read()
            lblFrmDtls.Text = "FrmName?" + CType(dr("FrmName"), String).Trim + "?FrmDtlsA?" + CType(dr("FrmDtls"), String).Trim + "?FrmDtlsB?" + CType(dr("FrmDtlsB"), String).Trim + "?FrmDtlsC?" + CType(dr("FrmDtlsC"), String).Trim + "?FrmName2?" + CType(dr("FrmName"), String).Trim + "?FrmDtlsA2?" + CType(dr("FrmDtls"), String).Trim + "?FrmDtlsB2?" + CType(dr("FrmDtlsB"), String).Trim + "?FrmDtlsC2?" + CType(dr("FrmDtlsC"), String).Trim
            dr.Close()

            For Each MyMenu As ToolStripMenuItem In mnMenu.Items
                cmd.CommandText = "Select * from UserAccessMenu(" + lblUID.Text + ") Where ParentID = (Select SrNo From MASTER_MENU Where MenuName = '" + MyMenu.Text + "') Order By SrNo"
                dr = cmd.ExecuteReader
                mnMenu = New MenuStrip
                While dr.Read
                    MyMenu.DropDownItems.Add(dr("MenuName"), Nothing, New System.EventHandler(AddressOf MainMenu_OnClick))
                End While
                dr.Close()

                For Each MyMenuItem As ToolStripMenuItem In MyMenu.DropDownItems
                    cmd.CommandText = "Select * from UserAccessMenu(" + lblUID.Text + ") Where ParentID = (Select SrNo From MASTER_MENU Where MenuName = '" + MyMenuItem.Text + "') Order By SrNo"
                    dr = cmd.ExecuteReader
                    mnMenu = New MenuStrip
                    While dr.Read
                        MyMenuItem.DropDownItems.Add(dr("MenuName"), Nothing, New System.EventHandler(AddressOf MainMenu_OnClick))
                    End While
                    dr.Close()

                    For Each MyMenuItem2 As ToolStripMenuItem In MyMenuItem.DropDownItems
                        cmd.CommandText = "Select * from UserAccessMenu(" + lblUID.Text + ") Where ParentID = (Select SrNo From MASTER_MENU Where MenuName = '" + MyMenuItem2.Text + "') Order By SrNo"
                        dr = cmd.ExecuteReader
                        mnMenu = New MenuStrip
                        While dr.Read
                            MyMenuItem2.DropDownItems.Add(dr("MenuName"), Nothing, New System.EventHandler(AddressOf MainMenu_OnClick))
                        End While
                        dr.Close()
                    Next
                Next
            Next
            con.Close()
        End If
    End Sub

    Private Sub MainMDI_Click(sender As Object, e As EventArgs) Handles Me.Click
        TextBox1.Focus()
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If TextBox1.Text.Contains("," + CType(e.KeyCode, String)) = True Then
            Exit Sub
        Else
            TextBox1.Text = TextBox1.Text + "," + CType(e.KeyCode, String)
        End If
    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        Try
            Dim KeyValue As String = TextBox1.Text
            conn()
            cmd.CommandText = "Select * from ShortKeysCode Where KeyName<>''"
            dr = cmd.ExecuteReader
            While dr.Read
                KeyValue = Replace(KeyValue, CType(dr("KeyCode"), String), "+" + CType(dr("KeyName"), String))
            End While
            dr.Close()
            cmd.CommandText = "Select FrmName From UserAccessMenu(" + lblUID.Text + ") Where SCKeyComb = '" + KeyValue.Substring(1) + "'"
            dr = cmd.ExecuteReader
            If dr.Read Then
                AccessVerify.LoadingFrm(True)
                FrmOpen(CType(dr("FrmName"), String))
            Else
                MsgBox("No Form Found.", MsgBoxStyle.Information, "H.F. General Trading CO.")
            End If
            dr.Close()
            con.Close()
            TextBox1.Text = ""
        Catch ex As Exception
            con.Close()
        End Try
    End Sub

    Private Sub lbltheme_TextChanged(sender As Object, e As EventArgs) Handles lbltheme.TextChanged
        Me.Text = "Al Hamlan & Fakhruddin General Trading CO. (User : " + Label1.Text + " | Current Theme : " + lbltheme.Text + ")"
    End Sub
End Class
