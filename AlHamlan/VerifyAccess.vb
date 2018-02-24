Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports CrystalDecisions.CrystalReports.Engine
Imports DGVPrinterHelper
Imports Microsoft.Office.Interop

Public Class VerifyAccess
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Private oTheme As Theme

    Private Sub conn()
        con = New SqlConnection
        Dim abc As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLibrary.dll")
        con.ConnectionString = Replace(abc, "AlHamlan", MainMDI.Label4.Text)
        con.Open()
        cmd = New SqlCommand
        cmd.Connection = con
    End Sub

    Public Sub LoadingFrm(Status As Boolean)
        If Status = True Then
            Dim frm As New Loading
            frm.MdiParent = MainMDI
            frm.Show()
        Else
            For Each frm As Form In MainMDI.MdiChildren
                If frm.Name = "Loading" Then
                    frm.Close()
                End If
            Next
        End If

    End Sub

    Public Sub LoadSrchGrid(Header As String, Query As String, Sndr As String, Rspnce As Boolean, Optional ResClmn As String = "", Optional ResFld As String = "", Optional CCodeCnt As String = "", Optional HighLight1 As String = "", Optional HighLight2 As String = "", Optional HighLight3 As String = "", Optional HighLight4 As String = "")
        LoadingFrm(True)
        Dim frm As New SearchGrid
        frm.lblheader.Text = Header
        frm.lblquery.Text = Query
        frm.lblresclm.Text = ResClmn
        frm.lblresfld.Text = ResFld
        frm.lblrspnse.Text = Rspnce.ToString
        frm.BtnCCode.Tag = CCodeCnt
        If CCodeCnt <> "" Then
            frm.BtnCCode.Visible = True
        Else
            frm.BtnCCode.Visible = False
        End If
        frm.lblhighlight1.Text = HighLight1
        frm.lblhighlight2.Text = HighLight2
        frm.lblhighlight3.Text = HighLight3
        frm.lblhighlight4.Text = HighLight4
        frm.lblsenderfrm.Text = Sndr
        frm.MdiParent = MainMDI
        frm.KeyPreview = True
        frm.Show()
    End Sub

    Public Function FindItemContaining(items As IEnumerable, target As String) As Object
        For Each item As Object In items
            If item.ToString().Contains(target) Then
                Return item
            End If
        Next
        ' Return null;
        Return Nothing
    End Function


    Public Function CheckCtrlAccess(FrmName As String, Desctn As String) As Boolean
        Dim a As Boolean
        conn()
        cmd.CommandText = "Select *From UserControlAccess(1) Where FrmName = (Select MenuName From MASTER_MENU Where FrmName = '" + FrmName + "') And Description = '" + Desctn + "' And Allowed = 1"
        dr = cmd.ExecuteReader
        If dr.Read() Then
            a = True
        Else
            a = False
        End If
        dr.Close()
        con.Close()
        Return a
    End Function

    Private Sub MailSend(Subj As String, EBody As String)
        Try
            cmd.CommandText = "DECLARE	@REID nvarchar(max) Select @REID = (Select Top 1 N_Email from View_NotifyEMail) EXEC Sp_SysEmail 'AlHamlanEMail', @REID, 'Null', 'Null', '" + Subj + "', '" + EBody + "', 'HTML', 'NORMAL', 'NORMAL', ''"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub NotifyChanges(FrmName As String, Task As String, Optional SrNo As String = "", Optional PrvDataSqlQry As String = "")
        conn()
        Dim SqlQry, Rslttable, PrvTable, ESubj, BodyEmail As String

        'Letter Or Credit
        If FrmName = "CRLetter" And Task = "Add" Then
            SqlQry = "Select Top 1 LC_NO, LC_DATE, LC_BANK, LC_EXPIRY_DATE, CUR_DESC As CURRENCY, LC_AMOUNT, SL_NAME As SUPPLIER, LC_INDENT_NO as [PO.NO.], PUR_NET_VALUE as [PO.NetAmnt] From View_LetterOfCredit"
            Rslttable = HtmlData(SqlQry, "LC_NO", "Desc")
            ESubj = "Software Notification : New Letter Of Credit is Added."
            BodyEmail = EmailBody("Details of Letter Of Credit Inserted.", Rslttable, "")
        ElseIf FrmName = "CRLetter" And Task = "Update" Then
            SqlQry = "Select LC_NO, LC_DATE, LC_BANK, LC_EXPIRY_DATE, CUR_DESC As CURRENCY, LC_AMOUNT, SL_NAME As SUPPLIER, LC_INDENT_NO as [PO.NO.], PUR_NET_VALUE as [PO.NetAmnt] From View_LetterOfCredit Where LC_NO = " + SrNo + ""
            Rslttable = HtmlData(SqlQry)
            ESubj = "Software Notification : Existing Letter Of Credit is Modified. LC No : " + SrNo
            BodyEmail = EmailBody("Details of Letter Of Credit Modified.", Rslttable, "")

            ' Purchase Order
        ElseIf FrmName = "POs" And Task = "Add" Then
            SqlQry = "Select Top 1 PUR_ORDER_NO As PoNo, PODate, SL_NAME As Supplier, CUR_DESC As CURRENCY, PUR_GROSS_VALUE As GrossAmnt, PUR_FOOT_DISC As Discount, PUR_FOOT_CHARGES As Charges, PUR_NET_VALUE as NetAmnt, ItemCnt From View_PO_Main"
            Rslttable = HtmlData(SqlQry, "PoNo", "Desc")
            ESubj = "Software Notification : New Purchase Order is Added."
            BodyEmail = EmailBody("Details of Purchase Order Inserted.", Rslttable, "")
        ElseIf FrmName = "POs" And Task = "Update" Then
            SqlQry = "Select PUR_ORDER_NO As PoNo, PODate, SL_NAME As Supplier, CUR_DESC As CURRENCY, PUR_GROSS_VALUE As GrossAmnt, PUR_FOOT_DISC As Discount, PUR_FOOT_CHARGES As Charges, PUR_NET_VALUE as NetAmnt, ItemCnt From View_PO_Main Where PUR_ORDER_NO = " + SrNo + ""
            Rslttable = HtmlData(SqlQry)
            ESubj = "Software Notification : Existing Purchase Order is Modified. PO No : " + SrNo
            BodyEmail = EmailBody("Details of Purchase Order Modified.", Rslttable, "")
        ElseIf FrmName = "POs" And Task = "Delete" Then
            SqlQry = "Select PUR_ORDER_NO As PoNo, PODate, SL_NAME As Supplier, CUR_DESC As CURRENCY, PUR_GROSS_VALUE As GrossAmnt, PUR_FOOT_DISC As Discount, PUR_FOOT_CHARGES As Charges, PUR_NET_VALUE as NetAmnt, ItemCnt From View_PO_Main Where PUR_ORDER_NO = " + SrNo + ""
            Rslttable = HtmlData(SqlQry)
            ESubj = "Software Notification : Item Deleted from Existing Purchase Order. PO No : " + SrNo
            BodyEmail = EmailBody("Details of Purchase Order after Item Deletion.", Rslttable, "")

            ' Journal Vouchers
        ElseIf FrmName = "JV" And Task = "Add" Then
            SqlQry = "Select Top 1 VOUCHER_NO, JVDate, CUR_DESC As CURRENCY, TotalDebit, TotalCredit, Difference, EntryCnt From View_Voucher_Main"
            Rslttable = HtmlData(SqlQry, "VOUCHER_NO", "Desc")
            ESubj = "Software Notification : New Voucher is Added."
            BodyEmail = EmailBody("Details of Voucher Inserted.", Rslttable, "")
        ElseIf FrmName = "JV" And Task = "Update" Then
            SqlQry = "Select VOUCHER_NO, JVDate, CUR_DESC As CURRENCY, TotalDebit, TotalCredit, Difference, EntryCnt From View_Voucher_Main Where VOUCHER_ID = " + SrNo + ""
            Rslttable = HtmlData(SqlQry)
            ESubj = "Software Notification : Existing Voucher is Modified. VOUCHER ID : " + SrNo
            BodyEmail = EmailBody("Details of Voucher Modified.", Rslttable, "")
        ElseIf FrmName = "JV" And Task = "Delete" Then
            SqlQry = "Select VOUCHER_NO, JVDate, CUR_DESC As CURRENCY, TotalDebit, TotalCredit, Difference, EntryCnt From View_Voucher_Main Where VOUCHER_ID = " + SrNo + ""
            Rslttable = HtmlData(SqlQry)
            ESubj = "Software Notification : Entry Deleted from Existing Voucher. VOUCHER ID : " + SrNo
            BodyEmail = EmailBody("Details of Voucher After Entry Deletion.", Rslttable, "")

            ' Proforma Invoice
        ElseIf FrmName = "Proforma" And Task = "Add" Then
            SqlQry = "Select Top 1 INV_NO, CUST_NAME As Customer, InvDate, Gross, INV_FOOT_DISCAMT as Discount, INV_FOOT_CHRGS As Charges, Net, INV_POSTED As Posted, INV_CANCEL as Cancelled, NameMob as Salesmen, ItmCnt From View_Proforma_Main"
            Rslttable = HtmlData(SqlQry, "INV_NO", "Desc")
            ESubj = "Software Notification : New Proforma\Quotation is Added."
            BodyEmail = EmailBody("Details of Proforma\Quotation Inserted.", Rslttable, "")
        ElseIf FrmName = "Proforma" And Task = "Update" Then
            SqlQry = "Select INV_NO, CUST_NAME As Customer, InvDate, Gross, INV_FOOT_DISCAMT as Discount, INV_FOOT_CHRGS As Charges, Net, INV_POSTED As Posted, INV_CANCEL as Cancelled, NameMob as Salesmen, ItmCnt From View_Proforma_Main Where INV_NO = " + SrNo + ""
            Rslttable = HtmlData(SqlQry)
            ESubj = "Software Notification : Existing Proforma\Quotation is Modified. Proforma ID : " + SrNo
            BodyEmail = EmailBody("Details of Proforma\Quotation Modified.", Rslttable, "")
        ElseIf FrmName = "Proforma" And Task = "Delete" Then
            SqlQry = "Select INV_NO, CUST_NAME As Customer, InvDate, Gross, INV_FOOT_DISCAMT as Discount, INV_FOOT_CHRGS As Charges, Net, INV_POSTED As Posted, INV_CANCEL as Cancelled, NameMob as Salesmen, ItmCnt From View_Proforma_Main Where INV_NO = " + SrNo + ""
            Rslttable = HtmlData(SqlQry)
            ESubj = "Software Notification : Entry Deleted from Existing Proforma\Quotation. Proforma ID : " + SrNo
            BodyEmail = EmailBody("Details of Proforma\Quotation After Entry Deletion.", Rslttable, "")

            ' Sales Invoice
        ElseIf FrmName = "SalesInvoice" And Task = "Add" Then
            SqlQry = "Select Top 1 INV_NO, CUST_NAME As Customer, InvDate, Gross, INV_DISC_AMT as Discount, INV_CHRGS As Charges, Net, INV_POSTED As Posted, INV_CANCEL as Cancelled, NameMob as Salesmen, ItmCnt From View_SalesInv_Main"
            Rslttable = HtmlData(SqlQry, "INV_NO", "Desc")
            ESubj = "Software Notification : New Sales Invoice is Added."
            BodyEmail = EmailBody("Details of Sales Invoice Inserted.", Rslttable, "")
        ElseIf FrmName = "SalesInvoice" And Task = "Update" Then
            SqlQry = "Select INV_NO, CUST_NAME As Customer, InvDate, Gross, INV_DISC_AMT as Discount, INV_CHRGS As Charges, Net, INV_POSTED As Posted, INV_CANCEL as Cancelled, NameMob as Salesmen, ItmCnt From View_SalesInv_Main Where INV_NO = " + SrNo + ""
            Rslttable = HtmlData(SqlQry)
            ESubj = "Software Notification : Existing Sales Invoice is Modified. Invoice No : " + SrNo
            BodyEmail = EmailBody("Details of Sales Invoice Modified.", Rslttable, "")
        ElseIf FrmName = "SalesInvoice" And Task = "Delete" Then
            SqlQry = "Select INV_NO, CUST_NAME As Customer, InvDate, Gross, INV_DISC_AMT as Discount, INV_CHRGS As Charges, Net, INV_POSTED As Posted, INV_CANCEL as Cancelled, NameMob as Salesmen, ItmCnt From View_SalesInv_Main Where INV_NO = " + SrNo + ""
            Rslttable = HtmlData(SqlQry)
            ESubj = "Software Notification : Entry Deleted from Existing Sales Invoice. Invoice No : " + SrNo
            BodyEmail = EmailBody("Details of Sales Invoice After Entry Deletion.", Rslttable, "")

            ' Customer Reciepts
        ElseIf FrmName = "CustRcpt" And Task = "Add" Then
            SqlQry = "Select Top 1 RCNo, CName As Customer, RcDate, Amnt, Initials As RcvdBy, Salesman From View_CustomerReciepts"
            Rslttable = HtmlData(SqlQry, "RCNo", "Desc")
            ESubj = "Software Notification : New Customer Reciept is Added."
            BodyEmail = EmailBody("Details of Customer Reciept Inserted.", Rslttable, "")
        ElseIf FrmName = "CustRcpt" And Task = "CancelPayment" Then
            SqlQry = "Select RCNo, CName As Customer, RcDate, Amnt, Initials As RcvdBy, Salesman From View_CustomerReciepts Where RCNo = " + SrNo + ""
            Rslttable = HtmlData(SqlQry)
            ESubj = "Software Notification : Entry Deleted from Existing Customer Reciept. RC No : " + SrNo
            BodyEmail = EmailBody("Details of Customer Reciept After Entry Deletion.", Rslttable, "")

            ' GRN
        ElseIf FrmName = "GRN" And Task = "Add" Then
            SqlQry = "Select Top 1 GRN_NO, CUST_NAME As Customer, GRNDate, Gross, GRN_CHRGS_AMT as Charges, Net, GRN_POSTED As Posted, GRN_CANCEL as Cancelled, NameMob as Salesmen, ItmCnt From View_GRN_Main"
            Rslttable = HtmlData(SqlQry, "GRN_NO", "Desc")
            ESubj = "Software Notification : New GRN is Added."
            BodyEmail = EmailBody("Details of GRN Inserted.", Rslttable, "")
        ElseIf FrmName = "GRN" And Task = "Update" Then
            SqlQry = "Select GRN_NO, CUST_NAME As Customer, GRNDate, Gross, GRN_CHRGS_AMT as Charges, Net, GRN_POSTED As Posted, GRN_CANCEL as Cancelled, NameMob as Salesmen, ItmCnt From View_GRN_Main Where GRN_NO = " + SrNo + ""
            Rslttable = HtmlData(SqlQry)
            ESubj = "Software Notification : Existing GRN is Modified. GRN No : " + SrNo
            BodyEmail = EmailBody("Details of GRN Modified.", Rslttable, "")
        ElseIf FrmName = "GRN" And Task = "Delete" Then
            SqlQry = "Select GRN_NO, CUST_NAME As Customer, GRNDate, Gross, GRN_CHRGS_AMT as Charges, Net, GRN_POSTED As Posted, GRN_CANCEL as Cancelled, NameMob as Salesmen, ItmCnt From View_GRN_Main Where GRN_NO = " + SrNo + ""
            Rslttable = HtmlData(SqlQry)
            ESubj = "Software Notification : Entry Deleted from Existing GRN. GRNNo : " + SrNo
            BodyEmail = EmailBody("Details of GRN After Entry Deletion.", Rslttable, "")
        End If

        MailSend(ESubj, BodyEmail)
        con.Close()
    End Sub

    Private Function HtmlData(Qry As String, Optional Orderby As String = "", Optional Seq As String = "") As String
        If Orderby <> "" Then
            Orderby = " Order by " + Orderby
        End If
        Dim Rslttable As String
        cmd.CommandText = "DECLARE	@html nvarchar(max) EXEC spQueryToHtmlTable N'" + Qry + "','" + Orderby + "', '" + Seq + "', @html OUTPUT SELECT @html as N'htmlData'"
        dr = cmd.ExecuteReader
        dr.Read()
        Rslttable = dr("htmlData")
        dr.Close()
        Return Rslttable
    End Function

    Private Function EmailBody(Header As String, HtmlStr As String, HtmlPrvStr As String) As String
        Dim Rslttable As String = ""
        If HtmlPrvStr = "" Then
            Rslttable = "<strong>" + Header + "</strong><br/><br/>" + HtmlStr + "<br/><br/>Notes : <br/>* This is system generated EMail. Do not reply.<br/>* EMail Generated By : " + MainMDI.Label1.Text + "<br/>* Email Date\Time : " + DateTime.Now.ToString("F")
        Else
            Rslttable = "<strong>" + Header + "</strong><br/><br/>Previous Data : <br/>" + HtmlPrvStr + "<br/><br/>Current Data : <br/>" + HtmlStr + "<br/><br/>Notes : <br/>* This is system generated EMail. Do not reply.<br/>* EMail Generated By : " + MainMDI.Label1.Text + "<br/>* Email Date\Time : " + DateTime.Now.ToString("F")
        End If
        Return Rslttable
    End Function

    Public Sub LoadReports(RptFile As CrystalDecisions.CrystalReports.Engine.ReportDocument, CrDs As DataSet, Optional TextParameter As String = "")
        LoadingFrm(True)
        Dim cr As New ReportDocument
        cr = RptFile

        Try
            If TextParameter <> "" Then
                Dim aryBarCode As String() = TextParameter.Split("?")
                Dim txt As TextObject

                For i As Integer = 0 To aryBarCode.Length - 1
                    txt = DirectCast(cr.ReportDefinition.ReportObjects(aryBarCode(i)), TextObject)
                    i = i + 1
                    txt.Text = aryBarCode(i)
                Next
            End If
        Catch ex As Exception
        End Try


        Dim input As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLibrary.dll")
        Dim ConnPara As String() = input.Split(New [Char]() {"="c, ";"c})

        cr.SetDatabaseLogon(ConnPara(3).Trim, ConnPara(5).Trim, ConnPara(1).Trim, ConnPara(9).Trim)
        cr.SetDataSource(CrDs)
        cr.PrintOptions.PaperSize = RptFile.PrintOptions.PaperSize

        Dim CrView As New CRViewer
        CrView.CrystalReportViewer1.ReportSource = cr
        CrView.MdiParent = MainMDI
        CrView.Show()
    End Sub

    Public Sub PrintReports(RptFile As CrystalDecisions.CrystalReports.Engine.ReportDocument, CrDs As DataSet, Optional TextParameter As String = "")
        LoadingFrm(True)
        Dim cr As New ReportDocument
        cr = RptFile

        If TextParameter <> "" Then
            Dim aryBarCode As String() = TextParameter.Split("?")
            Dim txt As TextObject

            For i As Integer = 0 To aryBarCode.Length - 1
                txt = DirectCast(cr.ReportDefinition.ReportObjects(aryBarCode(i)), TextObject)
                i = i + 1
                txt.Text = aryBarCode(i)
            Next
        End If

        Dim input As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\AxInterop.WMPLibrary.dll")
        Dim ConnPara As String() = input.Split(New [Char]() {"="c, ";"c})

        cr.SetDatabaseLogon(ConnPara(3).Trim, ConnPara(5).Trim, ConnPara(1).Trim, ConnPara(9).Trim)
        cr.SetDataSource(CrDs)
        cr.PrintToPrinter(1, True, 0, 0)
        LoadingFrm(False)
    End Sub

    Public Sub Themeing(FrmName As System.Windows.Forms.Form, ThemeName As String)
        oTheme = New ThemeSelector
        oTheme.SetTheme(FrmName, ThemeName)
    End Sub

    Public Sub DGVPrinting(PTitle As String, PSTitle As String, Orntn As Boolean, DGV As DataGridView)
        Dim Printer = New DGVPrinter
        Printer.Title = PTitle
        Printer.SubTitle = PSTitle
        Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
        Printer.PageNumbers = True
        Printer.PageNumberInHeader = False
        Printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.DataWidth
        Printer.HeaderCellAlignment = StringAlignment.Near
        Printer.TableAlignment = DGVPrinter.Alignment.Center
        Printer.Footer = "Printed By : " + MainMDI.LblInitials.Text + " On : " + DateTime.Now.ToString("MMMM, dd yyyy | HH:mm:ss tt")
        Printer.FooterSpacing = 15
        'Printer.PageSettings.Landscape = Orntn
        Printer.PrintPreviewDataGridView(DGV)
        LoadingFrm(False)
    End Sub

    Public Sub ExportToExcel(ByVal dtTemp As DataTable, ByVal filepath As String)
        Dim strFileName As String = filepath
        If System.IO.File.Exists(strFileName) Then
            If (MessageBox.Show("Do you want to replace from the existing file?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes) Then
                System.IO.File.Delete(strFileName)
            Else
                Return
            End If

        End If
        Dim _excel As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        Dim dt As System.Data.DataTable = dtTemp
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0

        For Each dc In dt.Columns
            colIndex = colIndex + 1
            wSheet.Cells(1, colIndex) = dc.ColumnName
        Next
        For Each dr In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                wSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
            Next
        Next
        wSheet.Columns.AutoFit()
        wBook.SaveAs(strFileName)

        ReleaseObject(wSheet)
        wBook.Close(False)
        ReleaseObject(wBook)
        _excel.Quit()
        ReleaseObject(_excel)
        GC.Collect()
        LoadingFrm(False)
        MessageBox.Show("File Export Successfully!")
    End Sub
    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

End Class
