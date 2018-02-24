﻿Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine

Public Class SalesValuex
    Dim AccessVerify As New VerifyAccess

#Region "Member Variables"
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet

    Private strFormat As StringFormat
    'Used to format the grid rows.
    Private arrColumnLefts As New ArrayList()
    'Used to save left coordinates of columns
    Private arrColumnWidths As New ArrayList()
    'Used to save column widths
    Private iCellHeight As Integer = 0
    'Used to get/set the datagridview cell height
    Private iTotalWidth As Integer = 0
    '
    Private iRow As Integer = 0
    'Used as counter
    Private bFirstPage As Boolean = False
    'Used to check whether we are printing first page
    Private bNewPage As Boolean = False
    ' Used to check whether we are printing a new page
    Private iHeaderHeight As Integer = 0
    'Used for the header height
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AccessVerify.LoadSrchGrid("Salesman Sales Value", "Select SM_CODE As Code, NameMob As Salesman, IsNull((Select Sum(Net) From View_SalesInv_Main Where NameMob = T.NameMob And Inv_Date >= '" + dtpFDate.Value.Date.ToString + "' and Inv_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "'),0) As Sales, IsNull((Select Sum(Net) From View_GRN_Main Where NameMob = T.NameMob And GRN_Date >= '" + dtpFDate.Value.Date.ToString + "' and GRN_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "'),0) As Returns, IsNull((Select Sum(Net) From View_SalesInv_Main Where NameMob = T.NameMob And Inv_Date >= '" + dtpFDate.Value.Date.ToString + "' and Inv_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "'),0) - IsNull((Select Sum(Net) From View_GRN_Main Where NameMob = T.NameMob And GRN_Date >= '" + dtpFDate.Value.Date.ToString + "' and GRN_Date <= '" + dtpToDate.Value.Date.AddDays(1).ToString + "'),0) As NetSales  from View_Master_Salesman T", Me.Name, False)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        AccessVerify.LoadingFrm(False)
    End Sub
End Class