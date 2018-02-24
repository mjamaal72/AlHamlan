<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class IGNCosting
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IGNCosting))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
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
        Me.txtcostno = New System.Windows.Forms.TextBox()
        Me.txtsuplr = New System.Windows.Forms.TextBox()
        Me.cbign = New SergeUtils.EasyCompletionComboBox()
        Me.txtignchrgs = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dtpdate = New System.Windows.Forms.DateTimePicker()
        Me.chbposted = New System.Windows.Forms.CheckBox()
        Me.txtcosttotal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtignnet = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtignadj = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtigndisc = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtigngross = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtinvdate = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtinvno = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtigndate = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtpono = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 139)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.Size = New System.Drawing.Size(608, 186)
        Me.DataGridView1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(623, 37)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "IGN Cost Sheet"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Cost No :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "IGN No:"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(3, 362)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(152, 30)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Add New CS"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(458, 41)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(164, 28)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Search Cost Sheet"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(247, 363)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(128, 30)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Print Cost"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(494, 363)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(128, 30)
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
        Me.Label16.Location = New System.Drawing.Point(200, 36)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 19)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Supplier :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(200, 7)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 19)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Date :"
        '
        'txtcostno
        '
        Me.txtcostno.BackColor = System.Drawing.Color.White
        Me.txtcostno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcostno.Location = New System.Drawing.Point(78, 4)
        Me.txtcostno.Name = "txtcostno"
        Me.txtcostno.ReadOnly = True
        Me.txtcostno.Size = New System.Drawing.Size(100, 26)
        Me.txtcostno.TabIndex = 0
        '
        'txtsuplr
        '
        Me.txtsuplr.BackColor = System.Drawing.Color.White
        Me.txtsuplr.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsuplr.Location = New System.Drawing.Point(272, 33)
        Me.txtsuplr.Name = "txtsuplr"
        Me.txtsuplr.ReadOnly = True
        Me.txtsuplr.Size = New System.Drawing.Size(339, 26)
        Me.txtsuplr.TabIndex = 3
        '
        'cbign
        '
        Me.cbign.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbign.FormattingEnabled = True
        Me.cbign.Location = New System.Drawing.Point(78, 33)
        Me.cbign.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbign.Name = "cbign"
        Me.cbign.Size = New System.Drawing.Size(100, 27)
        Me.cbign.TabIndex = 2
        '
        'txtignchrgs
        '
        Me.txtignchrgs.BackColor = System.Drawing.Color.White
        Me.txtignchrgs.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtignchrgs.Location = New System.Drawing.Point(260, 252)
        Me.txtignchrgs.Name = "txtignchrgs"
        Me.txtignchrgs.ReadOnly = True
        Me.txtignchrgs.Size = New System.Drawing.Size(80, 26)
        Me.txtignchrgs.TabIndex = 5
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(164, 255)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 19)
        Me.Label19.TabIndex = 54
        Me.Label19.Text = "IGN Charges :"
        '
        'dtpdate
        '
        Me.dtpdate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpdate.Location = New System.Drawing.Point(272, 4)
        Me.dtpdate.Name = "dtpdate"
        Me.dtpdate.Size = New System.Drawing.Size(148, 26)
        Me.dtpdate.TabIndex = 1
        '
        'chbposted
        '
        Me.chbposted.AutoSize = True
        Me.chbposted.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbposted.Location = New System.Drawing.Point(544, 81)
        Me.chbposted.Name = "chbposted"
        Me.chbposted.Size = New System.Drawing.Size(70, 23)
        Me.chbposted.TabIndex = 1
        Me.chbposted.Text = "P&osted"
        Me.chbposted.UseVisualStyleBackColor = True
        '
        'txtcosttotal
        '
        Me.txtcosttotal.BackColor = System.Drawing.Color.White
        Me.txtcosttotal.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcosttotal.Location = New System.Drawing.Point(532, 252)
        Me.txtcosttotal.Name = "txtcosttotal"
        Me.txtcosttotal.ReadOnly = True
        Me.txtcosttotal.Size = New System.Drawing.Size(80, 26)
        Me.txtcosttotal.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(426, 255)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 19)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Total Charges :"
        '
        'txtignnet
        '
        Me.txtignnet.BackColor = System.Drawing.Color.White
        Me.txtignnet.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtignnet.Location = New System.Drawing.Point(73, 252)
        Me.txtignnet.Name = "txtignnet"
        Me.txtignnet.ReadOnly = True
        Me.txtignnet.Size = New System.Drawing.Size(80, 26)
        Me.txtignnet.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 255)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 19)
        Me.Label13.TabIndex = 90
        Me.Label13.Text = "IGN Net :"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtignchrgs)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.txtsuplr)
        Me.Panel1.Controls.Add(Me.txtignnet)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.txtcostno)
        Me.Panel1.Controls.Add(Me.txtcosttotal)
        Me.Panel1.Controls.Add(Me.cbign)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.dtpdate)
        Me.Panel1.Location = New System.Drawing.Point(1, 75)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(621, 284)
        Me.Panel1.TabIndex = 0
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.LinkLabel1.Location = New System.Drawing.Point(444, 7)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(82, 19)
        Me.LinkLabel1.TabIndex = 101
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "IGN Details"
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(0, 39)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(268, 30)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "Clear Selection"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtignadj)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.txtigndisc)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.txtigngross)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.txtinvdate)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.txtinvno)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.txtigndate)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.txtpono)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Location = New System.Drawing.Point(357, 105)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(257, 220)
        Me.Panel2.TabIndex = 102
        Me.Panel2.Visible = False
        '
        'txtignadj
        '
        Me.txtignadj.BackColor = System.Drawing.Color.White
        Me.txtignadj.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtignadj.Location = New System.Drawing.Point(90, 186)
        Me.txtignadj.Name = "txtignadj"
        Me.txtignadj.ReadOnly = True
        Me.txtignadj.Size = New System.Drawing.Size(158, 23)
        Me.txtignadj.TabIndex = 114
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 189)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 15)
        Me.Label4.TabIndex = 113
        Me.Label4.Text = "Adjust :"
        '
        'txtigndisc
        '
        Me.txtigndisc.BackColor = System.Drawing.Color.White
        Me.txtigndisc.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtigndisc.Location = New System.Drawing.Point(90, 157)
        Me.txtigndisc.Name = "txtigndisc"
        Me.txtigndisc.ReadOnly = True
        Me.txtigndisc.Size = New System.Drawing.Size(158, 23)
        Me.txtigndisc.TabIndex = 112
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(6, 160)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(62, 15)
        Me.Label23.TabIndex = 111
        Me.Label23.Text = "Discount :"
        '
        'txtigngross
        '
        Me.txtigngross.BackColor = System.Drawing.Color.White
        Me.txtigngross.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtigngross.Location = New System.Drawing.Point(90, 128)
        Me.txtigngross.Name = "txtigngross"
        Me.txtigngross.ReadOnly = True
        Me.txtigngross.Size = New System.Drawing.Size(158, 23)
        Me.txtigngross.TabIndex = 110
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
        'txtinvdate
        '
        Me.txtinvdate.BackColor = System.Drawing.Color.White
        Me.txtinvdate.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtinvdate.Location = New System.Drawing.Point(90, 99)
        Me.txtinvdate.Name = "txtinvdate"
        Me.txtinvdate.ReadOnly = True
        Me.txtinvdate.Size = New System.Drawing.Size(158, 23)
        Me.txtinvdate.TabIndex = 108
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 102)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(81, 15)
        Me.Label21.TabIndex = 107
        Me.Label21.Text = "Invoice Date :"
        '
        'txtinvno
        '
        Me.txtinvno.BackColor = System.Drawing.Color.White
        Me.txtinvno.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtinvno.Location = New System.Drawing.Point(90, 70)
        Me.txtinvno.Name = "txtinvno"
        Me.txtinvno.ReadOnly = True
        Me.txtinvno.Size = New System.Drawing.Size(158, 23)
        Me.txtinvno.TabIndex = 106
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 73)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(71, 15)
        Me.Label20.TabIndex = 105
        Me.Label20.Text = "Invoice No :"
        '
        'txtigndate
        '
        Me.txtigndate.BackColor = System.Drawing.Color.White
        Me.txtigndate.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtigndate.Location = New System.Drawing.Point(90, 41)
        Me.txtigndate.Name = "txtigndate"
        Me.txtigndate.ReadOnly = True
        Me.txtigndate.Size = New System.Drawing.Size(158, 23)
        Me.txtigndate.TabIndex = 104
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 44)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 15)
        Me.Label17.TabIndex = 103
        Me.Label17.Text = "IGN Date :"
        '
        'txtpono
        '
        Me.txtpono.BackColor = System.Drawing.Color.White
        Me.txtpono.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtpono.Location = New System.Drawing.Point(90, 12)
        Me.txtpono.Name = "txtpono"
        Me.txtpono.ReadOnly = True
        Me.txtpono.Size = New System.Drawing.Size(158, 23)
        Me.txtpono.TabIndex = 102
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 15)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "PO No :"
        '
        'IGNCosting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(623, 394)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.chbposted)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "IGNCosting"
        Me.Text = "IM - Transactions - Goods Return Notes"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
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
    Friend WithEvents txtcostno As TextBox
    Friend WithEvents txtsuplr As TextBox
    Private WithEvents cbign As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtignchrgs As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents dtpdate As DateTimePicker
    Friend WithEvents chbposted As CheckBox
    Friend WithEvents txtcosttotal As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtignnet As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Button5 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtignadj As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtigndisc As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtigngross As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtinvdate As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtinvno As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtigndate As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtpono As TextBox
    Friend WithEvents Label6 As Label
End Class
