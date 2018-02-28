Imports System.Data.SqlClient
Imports System.Reflection

Public Class VerHstry
    Dim dr As SqlDataReader
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim mnMenu As MenuStrip
    Dim KeyComb As String
    Dim AccessVerify As New VerifyAccess

    Private Sub VerHstry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = 0
        Me.Top = 0
        Dim recNew As New Rectangle
        recNew = ParentForm.ClientRectangle
        recNew.Width = 800
        recNew.Height -= 50
        Me.Size = recNew.Size
        Me.SendToBack()
        recNew.Height -= 20

        Dim sb = New System.Text.StringBuilder()
        sb.Append("{\rtf1\ansi")
        sb.Append("\b \i Version 6.20 \i0 \b0 \line \line")
        sb.Append("* Fix Error - Rechecked All Listings Formats - Masters & Transactions Listings. \line")
        sb.Append("* Fix Error - Rechecked All Reports Formats For Proper Header and Duration Display - Reports. \line")
        sb.Append("* Fix Error - Minor Code Modification - IGN. \line")
        sb.Append("* Fix Error - Blank Print On X Formulae - Goods Return Note. \line")
        sb.Append("* Modification - Pack Information In GRN Printout - Goods Return Note. \line")
        sb.Append("* Modification - Customer Code In Cash Memo Report - Sales Invoice. \line")
        sb.Append("* Modification - Customer Code In Delivery Challan Report - Sales Invoice. \line \line \line")

        sb.Append("\b \i Version 6.19 \i0 \b0 \line \line")
        sb.Append("* Fix Error - Hide Second Item On Deletion Of First - Sales Invoice. \line")
        sb.Append("* Modification - Auto Post On CashMemo Print - Sales Invoice. \line")
        sb.Append("* Modification - Auto Post On Delivery Note Print - Sales Invoice. \line")
        sb.Append("* Modification - Cannot Proceed Without Entry Type - Journal Voucher. \line")
        sb.Append("* Modification - Other Minor Coding Modifications - Journal Voucher. \line \line \line")

        sb.Append("\b \i Version 6.18 \i0 \b0 \line \line")
        sb.Append("* Fix Error - Multiple Entry - Customer Reciepts. \line")
        sb.Append("* Fix Error - Duplicate Entry - Customer Reciepts. \line")
        sb.Append("* Fix Error - Blank Reciept Generation - Customer Reciepts. \line")
        sb.Append("* Fix Error - Carry Serach Criteria After Updatation - Item Master. \line")
        sb.Append("* Fix Error - Calculations Roundoff On Submit Or Update - Sales Invoice. \line")
        sb.Append("* New Features - Smart Search Option - Customer Reciepts. \line")
        sb.Append("* New Features - Load Proforma With Overwrite Confirmation - Sales Invoice. \line")
        sb.Append("* New Features - Update Invoice Date On Each Update - Sales Invoice. \line")
        sb.Append("* New Features - Track Item Entry Datetime - Sales Invoice. \line")
        sb.Append("* New Features - Pack Calculation Formula Works With Both Upper And Lower Case 'X'- Sales Invoice. \line")
        sb.Append("* New Features - Items Cannot Be Added To Invoice If Stock Balance < 1 (Access can be controlled) - Sales Invoice. \line")
        sb.Append("* New Features - Access Control Feature Which Allow Entries For Item < 1 - Sales Invoice. \line")
        sb.Append("* New Features - Recheck Calculation For Invoice On Submit And Each Update - Sales Invoice. \line")
        sb.Append("* New Features - Show Customer Due Amount On Customer Selection - Sales Invoice. \line")
        sb.Append("* New Features - Show Supplier Due Amount On Supplier Selection - Purchase Order. \line")
        sb.Append("* New Features - Show Customer Due Amount On Customer Selection - Customer Reciepts. \line")
        sb.Append("* New Features - Allow In Grid Update Option (For Fast Modification Process) - Item Master. \line")
        sb.Append("* New Features - Item Stock Balance View In Master Grid - Item Master. \line")
        sb.Append("* New Features - Allow In Grid Update Option (For Fast Modification Process) - Item Master. \line")
        sb.Append("* New Features - Customer Exceception Option - Customer Master. \line")
        sb.Append("* New Features - Invoice Of Customer With Exception Can Be Unposted After Actual Creation Date (Updates Creation Date On Update) - Sales Invoice. \line")
        sb.Append("* New Features - Invoice Cannot Be Unpost After Actual Date Of Creation (Only By Authrorized Personel) - Sales Invoice. \line")
        sb.Append("* New Features - Seperate Option In Drop Down 'Exception Sales' - Dash Board. \line")
        sb.Append("* New Features - Load Invoice By Invoice No. In GRN - Goods Return Note. \line")
        sb.Append("* New Features - View Invoice List And Select Invoice No Directly From Search Form - Goods Return Note. \line")
        sb.Append("* New Features - Confirmation For Adding OR Overwriting Invoice. - Goods Return Note. \line")
        sb.Append("* New Features - Description Along With Code In Tree View In All Ledger Statements And Trial Balance - Reports. \line")
        sb.Append("* New Features - Quantity Shows Decimal Only If It Has Decimal Value - Reports. \line")
        sb.Append("* New Features - Database Backup Option (With Custom Backup Name) - DB Management. \line")
        sb.Append("* New Features - Quick Database Backup Option (With Current Date and Time As Backup Name) - DB Management. \line")
        sb.Append("* New Features - Compress DB Size and Clear Log Data - DB Management. \line \line")
        sb.Append("** New Modules - One Click Year End Process (Features Follows :) \line")
        sb.Append("-Module Features - Auto Backup Before Starting Process - Year End. \line")
        sb.Append("-Module Features - Reset Openings For All Master Tables - Year End. \line")
        sb.Append("-Module Features - Reset Customer and Supplier Opening Balance - Year End. \line")
        sb.Append("-Module Features - Reset Item Costing According To Calculations From IGN and IGN Cost Sheet - Year End. \line")
        sb.Append("-Module Features - Reset All Transaction Tables (All Transactions Starts With 1) - Year End. \line")
        sb.Append("-Module Features - On Year End Replica DB Will Be Created For Previous Year - Year End. \line \line")
        sb.Append("** New Modules - Database Switch Option (Features Follows :) \line")
        sb.Append("-Module Features - Option To Select Account Year To Login From Drop Down At Login Page - DB Switch. \line")
        sb.Append("-Module Features - Enable OTP Option If Other Than Current Year Is Selected - DB Switch. \line")
        sb.Append("-Module Features - OTP Will Be Sent To All Predefined Mailing List - DB Switch. \line")
        sb.Append("-Module Features - New OTP Will Be Generated If Modules Is Closed Before Login - DB Switch. \line \line")
        sb.Append("** New Modules - Theme Management (Features Follows :) \line")
        sb.Append("-Module Features - Unlimited Themes Can Be Created - Theme Management. \line \line")
        sb.Append("** New Modules - Thermal Printing (Features Follows :) \line")
        sb.Append("-Module Features - Implemented In Sales Invoice and Sales Invoice View - Thermal Printing. \line")
        sb.Append("-Module Features - Implemented In Goods Return Note - Thermal Printing. \line")
        sb.Append("-Module Features - Implemented In Customer Reciepts - Thermal Printing. \line")
        sb.Append("-Module Features - Implemented In Proforma\Quotations - Thermal Printing. \line")
        sb.Append("}")
        RichTextBox1.Rtf = sb.ToString()

        AccessVerify.LoadingFrm(False)
    End Sub
End Class