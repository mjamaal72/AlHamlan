Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Dashboard
    Private GridPrinter As DataGridViewPrinter
#Region "Member Variables"
    Private _source As BindingSource
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da, da2 As SqlDataAdapter
    Dim ds, ds2 As DataSet
    Dim iRec As Boolean = False
    Dim AccessVerify As New VerifyAccess

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        conn()
        Chart1.Titles("Title1").Text = ComboBox1.Text
        If ComboBox1.SelectedIndex = 0 Then
            cmd.CommandText = "Select count(PUR_ORDER_NO) As Cnt, Format(PUR_ORDER_DATE, 'MMM') As Mnth From View_PO_Main Where PUR_ORDER_DATE>=DATEADD(yy, DATEDIFF(yy,0, '2015-09-09'), 0) Group By Format(PUR_ORDER_DATE, 'MMM') Order By Month(Max(PUR_ORDER_DATE))"
        ElseIf ComboBox1.SelectedIndex = 1 Then
            cmd.CommandText = "Select count(IGN_NO) As Cnt, Format(REC_DATE, 'MMM') As Mnth From View_IGN_Main Where REC_DATE>=DATEADD(yy, DATEDIFF(yy,0, '2015-09-09'), 0) Group By Format(REC_DATE, 'MMM') Order By Month(Max(REC_DATE))"
        ElseIf ComboBox1.SelectedIndex = 2 Then
            cmd.CommandText = "Select count(Inv_No) As Cnt, Format(Inv_date, 'MMM') As Mnth From View_SalesInv_Main Where Inv_date>=DATEADD(yy, DATEDIFF(yy,0, '2015-09-09'), 0) Group By Format(Inv_date, 'MMM') Order By Month(Max(Inv_date))"
        ElseIf ComboBox1.SelectedIndex = 3 Then
            cmd.CommandText = "Select count(GRN_NO) As Cnt, Format(GRN_DATE, 'MMM') As Mnth From View_GRN_Main Where GRN_DATE>=DATEADD(yy, DATEDIFF(yy,0, '2015-09-09'), 0) Group By Format(GRN_DATE, 'MMM') Order By Month(Max(GRN_DATE))"
        ElseIf ComboBox1.SelectedIndex = 4 Then
            cmd.CommandText = "Select count(VOUCHER_ID) As Cnt, Format(VOUCHER_DATE, 'MMM') As Mnth From View_Voucher_Main Where VOUCHER_DATE>=DATEADD(yy, DATEDIFF(yy,0, '2015-09-09'), 0) Group By Format(VOUCHER_DATE, 'MMM') Order By Month(Max(VOUCHER_DATE))"
        ElseIf ComboBox1.SelectedIndex = 5 Then
            cmd.CommandText = "Select count(RCNo) As Cnt, Format(CUS_RECIEPT_DATE, 'MMM') As Mnth From View_CustomerReciepts Where CUS_RECIEPT_DATE>=DATEADD(yy, DATEDIFF(yy,0, '2015-09-09'), 0) Group By Format(CUS_RECIEPT_DATE, 'MMM') Order By Month(Max(CUS_RECIEPT_DATE))"
        End If

        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds)
        Chart1.DataSource = ds
        Chart1.Series("Series1").XValueMember = "Mnth"
        Chart1.Series("Series1").IsValueShownAsLabel = True
        Chart1.Series("Series1").YValueMembers = "Cnt"
        With Chart1.ChartAreas(0)
            .AxisX.MajorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.NotSet
            .AxisY.MajorGrid.LineDashStyle = ChartDashStyle.NotSet
        End With
        Chart1.DataBind()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        conn()
        Chart2.Titles("Title1").Text = ComboBox2.Text
        If ComboBox2.SelectedIndex = 0 Then
            cmd.CommandText = "Select sum(Pur_Net_Value) As Cnt, Format(PUR_ORDER_DATE, 'MMM') As Mnth From View_PO_Main Where PUR_ORDER_DATE>=DATEADD(yy, DATEDIFF(yy,0, '2015-09-09'), 0) Group By Format(PUR_ORDER_DATE, 'MMM') Order By Month(Max(PUR_ORDER_DATE))"
        ElseIf ComboBox2.SelectedIndex = 1 Then
            cmd.CommandText = "Select Sum(Net) As Cnt, Format(REC_DATE, 'MMM') As Mnth From View_IGN_Main Where REC_DATE>=DATEADD(yy, DATEDIFF(yy,0, '2015-09-09'), 0) Group By Format(REC_DATE, 'MMM') Order By Month(Max(REC_DATE))"
        ElseIf ComboBox2.SelectedIndex = 2 Then
            cmd.CommandText = "Select Sum(Net) As Cnt, Format(Inv_date, 'MMM') As Mnth From View_SalesInv_Main Where Inv_date>=DATEADD(yy, DATEDIFF(yy,0, '2015-09-09'), 0) Group By Format(Inv_date, 'MMM') Order By Month(Max(Inv_date))"
        ElseIf ComboBox2.SelectedIndex = 3 Then
            cmd.CommandText = "Select Sum(Net) As Cnt, Format(GRN_DATE, 'MMM') As Mnth From View_GRN_Main Where GRN_DATE>=DATEADD(yy, DATEDIFF(yy,0, '2015-09-09'), 0) Group By Format(GRN_DATE, 'MMM') Order By Month(Max(GRN_DATE))"
        ElseIf ComboBox2.SelectedIndex = 4 Then
            cmd.CommandText = "Select Sum(TotalDebit) As Cnt, Format(VOUCHER_DATE, 'MMM') As Mnth From View_Voucher_Main Where VOUCHER_DATE>=DATEADD(yy, DATEDIFF(yy,0, '2015-09-09'), 0) Group By Format(VOUCHER_DATE, 'MMM') Order By Month(Max(VOUCHER_DATE))"
        ElseIf ComboBox2.SelectedIndex = 5 Then
            cmd.CommandText = "Select Sum(TotalCredit) As Cnt, Format(VOUCHER_DATE, 'MMM') As Mnth From View_Voucher_Main Where VOUCHER_DATE>=DATEADD(yy, DATEDIFF(yy,0, '2015-09-09'), 0) Group By Format(VOUCHER_DATE, 'MMM') Order By Month(Max(VOUCHER_DATE))"
        ElseIf ComboBox2.SelectedIndex = 6 Then
            cmd.CommandText = "Select Sum(Amnt) As Cnt, Format(CUS_RECIEPT_DATE, 'MMM') As Mnth From View_CustomerReciepts Where CUS_RECIEPT_DATE>=DATEADD(yy, DATEDIFF(yy,0, '2015-09-09'), 0) Group By Format(CUS_RECIEPT_DATE, 'MMM') Order By Month(Max(CUS_RECIEPT_DATE))"
        End If

        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds)
        Chart2.DataSource = ds
        Chart2.Series("Series1").XValueMember = "Mnth"
        Chart2.Series("Series1").IsValueShownAsLabel = True
        Chart2.Series("Series1").YValueMembers = "Cnt"
        With Chart2.ChartAreas(0)
            .AxisX.MajorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.NotSet
            .AxisY.MajorGrid.LineDashStyle = ChartDashStyle.NotSet
        End With
        Chart2.Series(0).SmartLabelStyle.Enabled = False
        Chart2.Series(0).LabelAngle = 0
        Chart2.DataBind()
    End Sub
#End Region

    Public Sub conn()
        con = New SqlConnection
        Dim abc As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLibrary.dll")
        con.ConnectionString = abc
        con.Open()
        cmd = New SqlCommand
        cmd.Connection = con
    End Sub

    Private Sub SearchGrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        AccessVerify.LoadingFrm(False)
    End Sub

End Class