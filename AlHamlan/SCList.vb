Imports System.Data.SqlClient
Imports System.Reflection

Public Class SCList
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim mnMenu As MenuStrip
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
        con.ConnectionString = Replace(abc, "AlHamlan", MainMDI.Label4.Text)
        con.Open()
        cmd = New SqlCommand
        cmd.Connection = con
    End Sub

    Private Sub SCList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        Me.Left = 0
        Me.Top = 0
        Dim recNew As New Rectangle
        recNew = ParentForm.ClientRectangle
        recNew.Width = 500
        recNew.Height -= 50
        Me.Size = recNew.Size
        Me.SendToBack()
        recNew.Height -= 20
        DataGridView1.Size = recNew.Size

        conn()
        cmd.CommandText = "Select MenuName, FrmName, SCKeyComb From UserAccessMenu(" + MainMDI.lblUID.Text + ") Where SCKeyComb <> '' Order By MenuName"
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds, "UserAccessMenu")
        DataGridView1.DataSource = ds.Tables(0)
        con.Close()
        DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill

        AccessVerify.LoadingFrm(False)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        AccessVerify.LoadingFrm(True)
        Dim FrmName As String = ""
        FrmName = DataGridView1.Rows(e.RowIndex).Cells("FrmName").Value.ToString()

        Dim FrmStr As New Form
        FrmName = [Assembly].GetEntryAssembly.GetName.Name & "." & FrmName
        FrmStr = DirectCast([Assembly].GetEntryAssembly.CreateInstance(FrmName), Form)
        FrmStr.MdiParent = MainMDI
        FrmStr.Show()
        FrmStr.Left = 0
        FrmStr.Top = 0
    End Sub
End Class