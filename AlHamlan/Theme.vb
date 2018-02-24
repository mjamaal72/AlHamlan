Imports System.Data.SqlClient
Imports System.Drawing

Public MustInherit Class Theme
    Private sFrmBackGroundImage As String
    Private sFrmTransperncyColor As Color


    Public Property BackGroundImage()
        Get
            Return sFrmBackGroundImage
        End Get
        Set(ByVal Value)
            sFrmBackGroundImage = Value
        End Set
    End Property

    Public Property TransperncyColor()
        Get
            Return sFrmTransperncyColor
        End Get
        Set(ByVal Value)
            sFrmTransperncyColor = Value
        End Set
    End Property

    Public MustOverride Function SetTheme(ByRef frmObj As Form, ThemeName As String) As Boolean

End Class

Public Class ThemeSelector
    Inherits Theme
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet

    Private Sub conn()
        con = New SqlConnection
        Dim abc As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLibrary.dll")
        con.ConnectionString = Replace(abc, "AlHamlan", MainMDI.Label4.Text)
        con.Open()
        cmd = New SqlCommand
        cmd.Connection = con
    End Sub
    Public Overrides Function SetTheme(ByRef frmObj As System.Windows.Forms.Form, ByVal ThemeName As String) As Boolean

        'set the transparency color
        frmObj.TransparencyKey = Me.TransperncyColor

        conn()
        cmd.CommandText = "SELECT * FROM Theming Where TName = '" + ThemeName + "'"
        dr = cmd.ExecuteReader
        dr.Read()
        frmObj.BackColor = ColorTranslator.FromHtml("#" + dr("CodeC"))
        Dim cntl As Control
        For Each cntl In frmObj.Controls
            If TypeOf (cntl) Is Label Or TypeOf (cntl) Is TextBox Or TypeOf (cntl) Is SergeUtils.EasyCompletionComboBox Or TypeOf (cntl) Is DateTimePicker Then
                cntl.ForeColor = ColorTranslator.FromHtml("#" + dr("CodeA"))
            ElseIf TypeOf (cntl) Is Button Then
                cntl.BackColor = ColorTranslator.FromHtml("#" + dr("CodeD"))
            ElseIf TypeOf (cntl) Is DataGridView Then
                DirectCast(cntl, DataGridView).BackgroundColor = ColorTranslator.FromHtml("#FFFFFF")
            ElseIf TypeOf (cntl) Is Panel Then
                cntl.BackColor = ColorTranslator.FromHtml("#" + dr("CodeB"))
                For Each cntl2 In cntl.Controls
                    If TypeOf (cntl2) Is Label Or TypeOf (cntl2) Is TextBox Or TypeOf (cntl2) Is SergeUtils.EasyCompletionComboBox Or TypeOf (cntl2) Is DateTimePicker Then
                        cntl2.ForeColor = ColorTranslator.FromHtml("#" + dr("CodeA"))
                    ElseIf TypeOf (cntl2) Is Button Then
                        cntl2.BackColor = ColorTranslator.FromHtml("#" + dr("CodeD"))
                    ElseIf TypeOf (cntl) Is DataGridView Then
                        DirectCast(cntl, DataGridView).BackgroundColor = ColorTranslator.FromHtml("#FFFFFF")
                    End If
                Next
            End If
        Next
        dr.Close()
        con.Close()
    End Function
End Class