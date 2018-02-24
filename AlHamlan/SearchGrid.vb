Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Reflection

Public Class SearchGrid

#Region "Member Variables"
    Private _source As BindingSource
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da, da2 As SqlDataAdapter
    Dim ds, ds2 As DataSet
    Dim iRec As Boolean = False
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

    Public Sub ColorCodeBifurcate()
        If lblhighlight1.Text <> "" Then
            Dim ccnt As Integer = BtnCCode.Tag
            Try
                For i As Integer = (ccnt - 500) To ccnt
                    Try
                        If lblhighlight1.Text.Split(","c)(2).Trim = "G" Then
                            If DGV.Rows(i).Cells(lblhighlight1.Text.Split(","c)(0).Trim).Value > 0 Then
                                DGV.Rows(i).Cells(lblhighlight1.Text.Split(","c)(0).Trim).Style.BackColor = Color.FromName(lblhighlight1.Text.Split(","c)(1).Trim)
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If lblhighlight2.Text.Split(","c)(2).Trim = "G" Then
                            If DGV.Rows(i).Cells(lblhighlight2.Text.Split(","c)(0).Trim).Value > 0 Then
                                DGV.Rows(i).Cells(lblhighlight2.Text.Split(","c)(0).Trim).Style.BackColor = Color.FromName(lblhighlight2.Text.Split(","c)(1).Trim)
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If lblhighlight3.Text.Split(","c)(2).Trim = "G" Then
                            If DGV.Rows(i).Cells(lblhighlight3.Text.Split(","c)(0).Trim).Value > 0 Then
                                DGV.Rows(i).Cells(lblhighlight3.Text.Split(","c)(0).Trim).Style.BackColor = Color.FromName(lblhighlight3.Text.Split(","c)(1).Trim)
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If lblhighlight4.Text.Split(","c)(2).Trim = "G" Then
                            If DGV.Rows(i).Cells(lblhighlight4.Text.Split(","c)(0).Trim).Value > 0 Then
                                DGV.Rows(i).Cells(lblhighlight4.Text.Split(","c)(0).Trim).Style.BackColor = Color.FromName(lblhighlight4.Text.Split(","c)(1).Trim)
                            End If
                        End If
                    Catch ex As Exception
                    End Try

                    Try
                        If lblhighlight1.Text.Split(","c)(2).Trim = "S" Then
                            If DGV.Rows(i).Cells(lblhighlight1.Text.Split(","c)(0).Trim).Value <= 0 Then
                                DGV.Rows(i).Cells(lblhighlight1.Text.Split(","c)(0).Trim).Style.BackColor = Color.FromName(lblhighlight1.Text.Split(","c)(1).Trim)
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If lblhighlight2.Text.Split(","c)(2).Trim = "S" Then
                            If DGV.Rows(i).Cells(lblhighlight2.Text.Split(","c)(0).Trim).Value <= 0 Then
                                DGV.Rows(i).Cells(lblhighlight2.Text.Split(","c)(0).Trim).Style.BackColor = Color.FromName(lblhighlight2.Text.Split(","c)(1).Trim)
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If lblhighlight3.Text.Split(","c)(2).Trim = "S" Then
                            If DGV.Rows(i).Cells(lblhighlight3.Text.Split(","c)(0).Trim).Value <= 0 Then
                                DGV.Rows(i).Cells(lblhighlight3.Text.Split(","c)(0).Trim).Style.BackColor = Color.FromName(lblhighlight3.Text.Split(","c)(1).Trim)
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If lblhighlight4.Text.Split(","c)(2).Trim = "S" Then
                            If DGV.Rows(i).Cells(lblhighlight4.Text.Split(","c)(0).Trim).Value <= 0 Then
                                DGV.Rows(i).Cells(lblhighlight4.Text.Split(","c)(0).Trim).Style.BackColor = Color.FromName(lblhighlight4.Text.Split(","c)(1).Trim)
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            Catch ex As Exception
            End Try
        End If
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
        FrmStr.MdiParent = MainMDI
        FrmStr.MaximizeBox = False
        FrmStr.KeyPreview = True
        FrmStr.Show()
        FrmStr.Left = 0
        FrmStr.Top = 0
        'Else
        '    MessageBox.Show(FrmTxt + " Is Already Open.", "H.F. General Trading CO.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
    End Sub

    Private Sub SearchGrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        conn()
        TryCast(_extender.FilterFactory, GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory).CreateDistinctGridFilters = True
        cmd.CommandText = lblquery.Text
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds)
        DGV.ClearSelection()
        DGV.DataSource = ds.Tables(0)
        DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        con.Close()
        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub SearchGrid_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AccessVerify.DGVPrinting(lblheader.Text, "Search Filter Listing", True, DGV)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim objDlg As New SaveFileDialog
        objDlg.Filter = "Excel File|*.xls"
        objDlg.OverwritePrompt = False
        If objDlg.ShowDialog = DialogResult.OK Then
            Dim filepath As String = objDlg.FileName
            AccessVerify.LoadingFrm(True)
            AccessVerify.ExportToExcel(ds.Tables(0), filepath)
        End If
    End Sub

    Private Sub BtnCCode_Click(sender As Object, e As EventArgs) Handles BtnCCode.Click
        Dim ccnt As Integer = BtnCCode.Tag
        BtnCCode.Tag = CType(ccnt + 500, String)
        ColorCodeBifurcate()
    End Sub

    Private Sub DGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV.CellMouseClick
        iRec = True
        Dim ff As Boolean = False
        Try
            If e.RowIndex >= 0 Then
                If lblrspnse.Text = "True" Then
                    For i As Integer = 0 To Application.OpenForms.Count
                        If Application.OpenForms(i).Name = lblsenderfrm.Text Then
                            ff = True
                            Dim frm = DirectCast(Application.OpenForms(i), Form)
                            Dim tbx As TextBox = TryCast(frm.Controls.Find(lblresfld.Text, True).FirstOrDefault(), TextBox)
                            If frm.Name = "SalesInvoice" Then
                                Dim Rb2 As RadioButton = TryCast(frm.Controls.Find("RadioButton2", True).FirstOrDefault(), RadioButton)
                                If Rb2.Checked = True Then
                                    tbx.Text = DGV(lblresclm.Text, e.RowIndex).Value.ToString
                                Else
                                    Dim a = 0
                                    For z As Integer = 0 To Application.OpenForms.Count - 1
                                        If Application.OpenForms(z).Name = "SalesInvView" Then
                                            a = 1
                                            Dim frm2 = DirectCast(Application.OpenForms(z), Form)
                                            Dim tbx2 As TextBox = TryCast(frm2.Controls.Find(lblresfld.Text, True).FirstOrDefault(), TextBox)
                                            tbx2.Text = DGV(lblresclm.Text, e.RowIndex).Value.ToString
                                            Exit For
                                        End If
                                    Next
                                    If a = 0 Then
                                        AccessVerify.LoadingFrm(True)
                                        Dim FrmSV As New SalesInvView
                                        FrmSV.MdiParent = MainMDI
                                        FrmSV.Show()
                                        FrmSV.txtinvno.Text = DGV(lblresclm.Text, e.RowIndex).Value.ToString
                                    End If
                                End If
                            Else
                                tbx.Text = DGV(lblresclm.Text, e.RowIndex).Value.ToString
                            End If
                            Exit For
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Try
                If ff = False Then
                    FrmOpen(lblsenderfrm.Text)
                    For i As Integer = 0 To Application.OpenForms.Count
                        If Application.OpenForms(i).Name = lblsenderfrm.Text Then
                            ff = True
                            Dim frm = DirectCast(Application.OpenForms(i), Form)
                            Dim tbx As TextBox = TryCast(frm.Controls.Find(lblresfld.Text, True).FirstOrDefault(), TextBox)
                            If frm.Name = "SalesInvoice" Then
                                Dim Rb2 As RadioButton = TryCast(frm.Controls.Find("RadioButton2", True).FirstOrDefault(), RadioButton)
                                If Rb2.Checked = True Then
                                    tbx.Text = DGV(lblresclm.Text, e.RowIndex).Value.ToString
                                Else
                                    Dim a = 0
                                    For z As Integer = 0 To Application.OpenForms.Count - 1
                                        If Application.OpenForms(z).Name = "SalesInvView" Then
                                            a = 1
                                            Dim frm2 = DirectCast(Application.OpenForms(z), Form)
                                            Dim tbx2 As TextBox = TryCast(frm2.Controls.Find(lblresfld.Text, True).FirstOrDefault(), TextBox)
                                            tbx2.Text = DGV(lblresclm.Text, e.RowIndex).Value.ToString
                                            Exit For
                                        End If
                                    Next
                                    If a = 0 Then
                                        AccessVerify.LoadingFrm(True)
                                        Dim FrmSV As New SalesInvView
                                        FrmSV.MdiParent = MainMDI
                                        FrmSV.Show()
                                        FrmSV.txtinvno.Text = DGV(lblresclm.Text, e.RowIndex).Value.ToString
                                    End If
                                End If
                            Else
                                tbx.Text = DGV(lblresclm.Text, e.RowIndex).Value.ToString
                            End If
                            Exit For
                        End If
                    Next
                End If
            Catch ez As Exception
            End Try
        End Try
    End Sub

    Private Sub DGV_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGV.DataBindingComplete
        ColorCodeBifurcate()
    End Sub

    'Private Sub DGV_SelectionChanged(sender As Object, e As EventArgs) Handles DGV.SelectionChanged
    '    If iRec = True Then
    '        Try
    '            If lblrspnse.Text = "True" Then
    '                For i As Integer = 0 To Application.OpenForms.Count
    '                    If Application.OpenForms(i).Name = lblsenderfrm.Text Then
    '                        Dim frm = DirectCast(Application.OpenForms(i), Form)
    '                        Dim tbx As TextBox = TryCast(frm.Controls.Find(lblresfld.Text, True).FirstOrDefault(), TextBox)
    '                        If frm.Name = "SalesInvoice" Then
    '                            Dim Rb2 As RadioButton = TryCast(frm.Controls.Find("RadioButton2", True).FirstOrDefault(), RadioButton)
    '                            If Rb2.Checked = True Then
    '                                tbx.Text = DGV(lblresclm.Text, DGV.CurrentRow.Index).Value.ToString
    '                            Else
    '                                Dim a = 0
    '                                For z As Integer = 0 To Application.OpenForms.Count - 1
    '                                    If Application.OpenForms(z).Name = "SalesInvView" Then
    '                                        a = 1
    '                                        Dim frm2 = DirectCast(Application.OpenForms(z), Form)
    '                                        Dim tbx2 As TextBox = TryCast(frm2.Controls.Find(lblresfld.Text, True).FirstOrDefault(), TextBox)
    '                                        tbx2.Text = DGV(lblresclm.Text, DGV.CurrentRow.Index).Value.ToString
    '                                        Exit For
    '                                    End If
    '                                Next
    '                                If a = 0 Then
    '                                    AccessVerify.LoadingFrm(True)
    '                                    Dim FrmSV As New SalesInvView
    '                                    FrmSV.MdiParent = MainMDI
    '                                    FrmSV.Show()
    '                                    FrmSV.txtinvno.Text = DGV(lblresclm.Text, DGV.CurrentRow.Index).Value.ToString
    '                                End If
    '                            End If
    '                        Else
    '                            tbx.Text = DGV(lblresclm.Text, DGV.CurrentRow.Index).Value.ToString
    '                        End If
    '                        Exit For
    '                    End If
    '                Next
    '            End If
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
End Class