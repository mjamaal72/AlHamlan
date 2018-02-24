<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class IGN
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IGN))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintPreviewDialog2 = New System.Windows.Forms.PrintPreviewDialog()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtign = New System.Windows.Forms.TextBox()
        Me.txtnotes = New System.Windows.Forms.TextBox()
        Me.cbsuplr = New SergeUtils.EasyCompletionComboBox()
        Me.txtgross = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dtpdate = New System.Windows.Forms.DateTimePicker()
        Me.cbpono = New SergeUtils.EasyCompletionComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chbpopost = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtinvno = New System.Windows.Forms.TextBox()
        Me.txtperc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtdisc = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtchrgs = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtnet = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtcnt = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ChbCash = New System.Windows.Forms.CheckBox()
        Me.txtadjust = New System.Windows.Forms.TextBox()
        Me.txtinvnet = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpinvdate = New System.Windows.Forms.DateTimePicker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtLnkIGN = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtponet = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtpogross = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtpoship = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtpodiv = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtpotype = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtpocrncy = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.chbignpost = New System.Windows.Forms.CheckBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1177, 37)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Incoming Goods Note (IGN)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "IGN No :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Supplier :"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(181, 540)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(268, 30)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Add New IGN"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(985, 40)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(189, 31)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Search IGN"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(455, 540)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(268, 30)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Print Selected IGN"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(728, 540)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(268, 30)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Exit Form"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintPreviewDialog2
        '
        Me.PrintPreviewDialog2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog2.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog2.Enabled = True
        Me.PrintPreviewDialog2.Icon = CType(resources.GetObject("PrintPreviewDialog2.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog2.Name = "PrintPreviewDialog2"
        Me.PrintPreviewDialog2.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(4, 73)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 19)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Notes :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(452, 15)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 19)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Date :"
        '
        'txtign
        '
        Me.txtign.BackColor = System.Drawing.Color.White
        Me.txtign.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtign.Location = New System.Drawing.Point(72, 12)
        Me.txtign.Name = "txtign"
        Me.txtign.ReadOnly = True
        Me.txtign.Size = New System.Drawing.Size(165, 26)
        Me.txtign.TabIndex = 10000
        '
        'txtnotes
        '
        Me.txtnotes.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnotes.Location = New System.Drawing.Point(72, 70)
        Me.txtnotes.Name = "txtnotes"
        Me.txtnotes.Size = New System.Drawing.Size(1099, 26)
        Me.txtnotes.TabIndex = 6
        '
        'cbsuplr
        '
        Me.cbsuplr.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbsuplr.FormattingEnabled = True
        Me.cbsuplr.Location = New System.Drawing.Point(72, 41)
        Me.cbsuplr.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbsuplr.Name = "cbsuplr"
        Me.cbsuplr.Size = New System.Drawing.Size(508, 27)
        Me.cbsuplr.TabIndex = 4
        '
        'txtgross
        '
        Me.txtgross.BackColor = System.Drawing.Color.White
        Me.txtgross.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgross.Location = New System.Drawing.Point(220, 430)
        Me.txtgross.Name = "txtgross"
        Me.txtgross.ReadOnly = True
        Me.txtgross.Size = New System.Drawing.Size(80, 26)
        Me.txtgross.TabIndex = 8
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(169, 433)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 19)
        Me.Label19.TabIndex = 54
        Me.Label19.Text = "Gross :"
        '
        'dtpdate
        '
        Me.dtpdate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpdate.Location = New System.Drawing.Point(501, 12)
        Me.dtpdate.Name = "dtpdate"
        Me.dtpdate.Size = New System.Drawing.Size(168, 26)
        Me.dtpdate.TabIndex = 1
        '
        'cbpono
        '
        Me.cbpono.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbpono.FormattingEnabled = True
        Me.cbpono.Location = New System.Drawing.Point(658, 41)
        Me.cbpono.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbpono.Name = "cbpono"
        Me.cbpono.Size = New System.Drawing.Size(132, 27)
        Me.cbpono.TabIndex = 5
        Me.cbpono.Tag = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(594, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 19)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "PO No :"
        '
        'chbpopost
        '
        Me.chbpopost.AutoSize = True
        Me.chbpopost.BackColor = System.Drawing.Color.Transparent
        Me.chbpopost.Enabled = False
        Me.chbpopost.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbpopost.Location = New System.Drawing.Point(983, 43)
        Me.chbpopost.Name = "chbpopost"
        Me.chbpopost.Size = New System.Drawing.Size(90, 23)
        Me.chbpopost.TabIndex = 15
        Me.chbpopost.Text = "PO Status"
        Me.chbpopost.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(683, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 19)
        Me.Label8.TabIndex = 77
        Me.Label8.Text = "Inv No :"
        '
        'txtinvno
        '
        Me.txtinvno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinvno.Location = New System.Drawing.Point(747, 12)
        Me.txtinvno.Name = "txtinvno"
        Me.txtinvno.Size = New System.Drawing.Size(132, 26)
        Me.txtinvno.TabIndex = 2
        '
        'txtperc
        '
        Me.txtperc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtperc.Location = New System.Drawing.Point(387, 430)
        Me.txtperc.Name = "txtperc"
        Me.txtperc.Size = New System.Drawing.Size(65, 26)
        Me.txtperc.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(303, 433)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 19)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Discount % :"
        '
        'txtdisc
        '
        Me.txtdisc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdisc.Location = New System.Drawing.Point(523, 430)
        Me.txtdisc.Name = "txtdisc"
        Me.txtdisc.Size = New System.Drawing.Size(80, 26)
        Me.txtdisc.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(455, 433)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 19)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Discount :"
        '
        'txtchrgs
        '
        Me.txtchrgs.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtchrgs.Location = New System.Drawing.Point(670, 430)
        Me.txtchrgs.Name = "txtchrgs"
        Me.txtchrgs.Size = New System.Drawing.Size(80, 26)
        Me.txtchrgs.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(606, 433)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 19)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "Charges :"
        '
        'txtnet
        '
        Me.txtnet.BackColor = System.Drawing.Color.White
        Me.txtnet.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnet.Location = New System.Drawing.Point(1090, 430)
        Me.txtnet.Name = "txtnet"
        Me.txtnet.ReadOnly = True
        Me.txtnet.Size = New System.Drawing.Size(80, 26)
        Me.txtnet.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(1049, 433)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 19)
        Me.Label10.TabIndex = 86
        Me.Label10.Text = "Net :"
        '
        'txtcnt
        '
        Me.txtcnt.BackColor = System.Drawing.Color.White
        Me.txtcnt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcnt.Location = New System.Drawing.Point(86, 430)
        Me.txtcnt.Name = "txtcnt"
        Me.txtcnt.ReadOnly = True
        Me.txtcnt.Size = New System.Drawing.Size(80, 26)
        Me.txtcnt.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(4, 433)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 19)
        Me.Label13.TabIndex = 90
        Me.Label13.Text = "Item Count :"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ChbCash)
        Me.Panel1.Controls.Add(Me.txtnet)
        Me.Panel1.Controls.Add(Me.txtadjust)
        Me.Panel1.Controls.Add(Me.txtinvnet)
        Me.Panel1.Controls.Add(Me.txtchrgs)
        Me.Panel1.Controls.Add(Me.txtdisc)
        Me.Panel1.Controls.Add(Me.txtperc)
        Me.Panel1.Controls.Add(Me.txtgross)
        Me.Panel1.Controls.Add(Me.txtcnt)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.chbpopost)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.dtpinvdate)
        Me.Panel1.Controls.Add(Me.txtnotes)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtign)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.cbsuplr)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtinvno)
        Me.Panel1.Controls.Add(Me.dtpdate)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cbpono)
        Me.Panel1.Location = New System.Drawing.Point(1, 74)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1176, 460)
        Me.Panel1.TabIndex = 0
        '
        'ChbCash
        '
        Me.ChbCash.AutoSize = True
        Me.ChbCash.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChbCash.Location = New System.Drawing.Point(353, 14)
        Me.ChbCash.Name = "ChbCash"
        Me.ChbCash.Size = New System.Drawing.Size(91, 23)
        Me.ChbCash.TabIndex = 0
        Me.ChbCash.Text = "Cash IGN"
        Me.ChbCash.UseVisualStyleBackColor = True
        '
        'txtadjust
        '
        Me.txtadjust.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadjust.Location = New System.Drawing.Point(987, 430)
        Me.txtadjust.Name = "txtadjust"
        Me.txtadjust.Size = New System.Drawing.Size(60, 26)
        Me.txtadjust.TabIndex = 13
        '
        'txtinvnet
        '
        Me.txtinvnet.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinvnet.Location = New System.Drawing.Point(813, 430)
        Me.txtinvnet.Name = "txtinvnet"
        Me.txtinvnet.Size = New System.Drawing.Size(88, 26)
        Me.txtinvnet.TabIndex = 12
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Times New Roman", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(807, 40)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(165, 27)
        Me.Button6.TabIndex = 16
        Me.Button6.Text = "Merge New Item From PO"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(903, 433)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 19)
        Me.Label14.TabIndex = 98
        Me.Label14.Text = "Adjustment :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(753, 433)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 19)
        Me.Label12.TabIndex = 96
        Me.Label12.Text = "Inv Net :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(888, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 19)
        Me.Label11.TabIndex = 92
        Me.Label11.Text = "Invoice Date :"
        '
        'dtpinvdate
        '
        Me.dtpinvdate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpinvdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpinvdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpinvdate.Location = New System.Drawing.Point(984, 11)
        Me.dtpinvdate.Name = "dtpinvdate"
        Me.dtpinvdate.Size = New System.Drawing.Size(184, 26)
        Me.dtpinvdate.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtLnkIGN)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.txtponet)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.txtpogross)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.txtpoship)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.txtpodiv)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.txtpotype)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.txtpocrncy)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Location = New System.Drawing.Point(916, 141)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(257, 220)
        Me.Panel2.TabIndex = 10
        Me.Panel2.Visible = False
        '
        'txtLnkIGN
        '
        Me.txtLnkIGN.BackColor = System.Drawing.Color.White
        Me.txtLnkIGN.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtLnkIGN.Location = New System.Drawing.Point(90, 186)
        Me.txtLnkIGN.Name = "txtLnkIGN"
        Me.txtLnkIGN.ReadOnly = True
        Me.txtLnkIGN.Size = New System.Drawing.Size(158, 23)
        Me.txtLnkIGN.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 189)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 15)
        Me.Label15.TabIndex = 113
        Me.Label15.Text = "Linked IGN :"
        '
        'txtponet
        '
        Me.txtponet.BackColor = System.Drawing.Color.White
        Me.txtponet.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtponet.Location = New System.Drawing.Point(90, 157)
        Me.txtponet.Name = "txtponet"
        Me.txtponet.ReadOnly = True
        Me.txtponet.Size = New System.Drawing.Size(158, 23)
        Me.txtponet.TabIndex = 5
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(6, 160)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(31, 15)
        Me.Label23.TabIndex = 111
        Me.Label23.Text = "Net :"
        '
        'txtpogross
        '
        Me.txtpogross.BackColor = System.Drawing.Color.White
        Me.txtpogross.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtpogross.Location = New System.Drawing.Point(90, 128)
        Me.txtpogross.Name = "txtpogross"
        Me.txtpogross.ReadOnly = True
        Me.txtpogross.Size = New System.Drawing.Size(158, 23)
        Me.txtpogross.TabIndex = 4
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(6, 131)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(45, 15)
        Me.Label22.TabIndex = 109
        Me.Label22.Text = "Gross :"
        '
        'txtpoship
        '
        Me.txtpoship.BackColor = System.Drawing.Color.White
        Me.txtpoship.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtpoship.Location = New System.Drawing.Point(90, 99)
        Me.txtpoship.Name = "txtpoship"
        Me.txtpoship.ReadOnly = True
        Me.txtpoship.Size = New System.Drawing.Size(158, 23)
        Me.txtpoship.TabIndex = 3
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 102)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(72, 15)
        Me.Label21.TabIndex = 107
        Me.Label21.Text = "Ship Terms :"
        '
        'txtpodiv
        '
        Me.txtpodiv.BackColor = System.Drawing.Color.White
        Me.txtpodiv.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtpodiv.Location = New System.Drawing.Point(90, 70)
        Me.txtpodiv.Name = "txtpodiv"
        Me.txtpodiv.ReadOnly = True
        Me.txtpodiv.Size = New System.Drawing.Size(158, 23)
        Me.txtpodiv.TabIndex = 2
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 73)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(59, 15)
        Me.Label20.TabIndex = 105
        Me.Label20.Text = "Division :"
        '
        'txtpotype
        '
        Me.txtpotype.BackColor = System.Drawing.Color.White
        Me.txtpotype.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtpotype.Location = New System.Drawing.Point(90, 41)
        Me.txtpotype.Name = "txtpotype"
        Me.txtpotype.ReadOnly = True
        Me.txtpotype.Size = New System.Drawing.Size(158, 23)
        Me.txtpotype.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 44)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 15)
        Me.Label17.TabIndex = 103
        Me.Label17.Text = "Pay Type :"
        '
        'txtpocrncy
        '
        Me.txtpocrncy.BackColor = System.Drawing.Color.White
        Me.txtpocrncy.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtpocrncy.Location = New System.Drawing.Point(90, 12)
        Me.txtpocrncy.Name = "txtpocrncy"
        Me.txtpocrncy.ReadOnly = True
        Me.txtpocrncy.Size = New System.Drawing.Size(158, 23)
        Me.txtpocrncy.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 15)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "Currency :"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(1107, 123)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(63, 15)
        Me.LinkLabel1.TabIndex = 2
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "PO Details"
        '
        'chbignpost
        '
        Me.chbignpost.AutoSize = True
        Me.chbignpost.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbignpost.Location = New System.Drawing.Point(249, 89)
        Me.chbignpost.Name = "chbignpost"
        Me.chbignpost.Size = New System.Drawing.Size(102, 23)
        Me.chbignpost.TabIndex = 10001
        Me.chbignpost.Text = "IGN Posted"
        Me.chbignpost.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(1, 41)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(268, 30)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "Clear Selection"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(5, 173)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.Size = New System.Drawing.Size(1168, 326)
        Me.DataGridView1.TabIndex = 8
        '
        'IGN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1177, 571)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.chbignpost)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "IGN"
        Me.Text = "FM - Purchase - IGN"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintPreviewDialog2 As PrintPreviewDialog
    Friend WithEvents Label16 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtign As TextBox
    Friend WithEvents txtnotes As TextBox
    Private WithEvents cbsuplr As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtgross As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents dtpdate As DateTimePicker
    Private WithEvents cbpono As SergeUtils.EasyCompletionComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents chbpopost As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtinvno As TextBox
    Friend WithEvents txtperc As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtdisc As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtchrgs As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtnet As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtcnt As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents dtpinvdate As DateTimePicker
    Friend WithEvents txtadjust As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtinvnet As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents chbignpost As CheckBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtponet As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtpogross As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtpoship As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtpodiv As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtpotype As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtpocrncy As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtLnkIGN As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents ChbCash As CheckBox
End Class
