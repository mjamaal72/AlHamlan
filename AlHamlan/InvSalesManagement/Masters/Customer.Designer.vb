<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Customer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Customer))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtadd2 = New System.Windows.Forms.TextBox()
        Me.txtadd1 = New System.Windows.Forms.TextBox()
        Me.txtlmtdays = New System.Windows.Forms.TextBox()
        Me.txtopenbal = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtlmtamnt = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chbactive = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintPreviewDialog2 = New System.Windows.Forms.PrintPreviewDialog()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.chbhold = New System.Windows.Forms.CheckBox()
        Me.txtcode = New System.Windows.Forms.TextBox()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.txttel = New System.Windows.Forms.TextBox()
        Me.txtfax = New System.Windows.Forms.TextBox()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.txtcntct = New System.Windows.Forms.TextBox()
        Me.dtpsdate = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(7, 66)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(820, 146)
        Me.DataGridView1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(829, 37)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Master - Customers"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 228)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Code :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 254)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Name :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 282)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Address :"
        '
        'txtadd2
        '
        Me.txtadd2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd2.Location = New System.Drawing.Point(94, 328)
        Me.txtadd2.Multiline = True
        Me.txtadd2.Name = "txtadd2"
        Me.txtadd2.Size = New System.Drawing.Size(363, 46)
        Me.txtadd2.TabIndex = 9
        '
        'txtadd1
        '
        Me.txtadd1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd1.Location = New System.Drawing.Point(94, 278)
        Me.txtadd1.Multiline = True
        Me.txtadd1.Name = "txtadd1"
        Me.txtadd1.Size = New System.Drawing.Size(363, 46)
        Me.txtadd1.TabIndex = 10
        '
        'txtlmtdays
        '
        Me.txtlmtdays.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlmtdays.Location = New System.Drawing.Point(94, 539)
        Me.txtlmtdays.Name = "txtlmtdays"
        Me.txtlmtdays.Size = New System.Drawing.Size(189, 23)
        Me.txtlmtdays.TabIndex = 15
        '
        'txtopenbal
        '
        Me.txtopenbal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtopenbal.Location = New System.Drawing.Point(94, 512)
        Me.txtopenbal.Name = "txtopenbal"
        Me.txtopenbal.Size = New System.Drawing.Size(189, 23)
        Me.txtopenbal.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 515)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 15)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Open Balnc :"
        '
        'txtlmtamnt
        '
        Me.txtlmtamnt.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlmtamnt.Location = New System.Drawing.Point(94, 486)
        Me.txtlmtamnt.Name = "txtlmtamnt"
        Me.txtlmtamnt.Size = New System.Drawing.Size(189, 23)
        Me.txtlmtamnt.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 489)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 15)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Limit Amount :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 383)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 15)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Telephone :"
        '
        'chbactive
        '
        Me.chbactive.AutoSize = True
        Me.chbactive.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbactive.Location = New System.Drawing.Point(442, 466)
        Me.chbactive.Name = "chbactive"
        Me.chbactive.Size = New System.Drawing.Size(15, 14)
        Me.chbactive.TabIndex = 20
        Me.chbactive.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(275, 381)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 15)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Fax :"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(313, 527)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(143, 30)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "Add New Customer"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(684, 37)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(143, 28)
        Me.Button2.TabIndex = 24
        Me.Button2.Text = "Search"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox12
        '
        Me.TextBox12.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox12.Location = New System.Drawing.Point(465, 38)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(217, 27)
        Me.TextBox12.TabIndex = 25
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(485, 527)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(143, 30)
        Me.Button3.TabIndex = 26
        Me.Button3.Text = "Print Grid"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(683, 527)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(143, 30)
        Me.Button4.TabIndex = 27
        Me.Button4.Text = "E&xit Form"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 44)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(0, 19)
        Me.Label15.TabIndex = 18
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
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 332)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 15)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Address2 :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 411)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 15)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Email :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 436)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 15)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Contact :"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(12, 463)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 15)
        Me.Label20.TabIndex = 37
        Me.Label20.Text = "Start Date :"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(396, 465)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(45, 15)
        Me.Label21.TabIndex = 38
        Me.Label21.Text = "Active :"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(295, 491)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(148, 15)
        Me.Label22.TabIndex = 39
        Me.Label22.Text = "Exception (Invoice Open) :"
        '
        'chbhold
        '
        Me.chbhold.AutoSize = True
        Me.chbhold.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbhold.Location = New System.Drawing.Point(442, 493)
        Me.chbhold.Name = "chbhold"
        Me.chbhold.Size = New System.Drawing.Size(15, 14)
        Me.chbhold.TabIndex = 42
        Me.chbhold.UseVisualStyleBackColor = True
        '
        'txtcode
        '
        Me.txtcode.BackColor = System.Drawing.Color.White
        Me.txtcode.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcode.Location = New System.Drawing.Point(94, 224)
        Me.txtcode.Name = "txtcode"
        Me.txtcode.ReadOnly = True
        Me.txtcode.Size = New System.Drawing.Size(144, 23)
        Me.txtcode.TabIndex = 44
        Me.txtcode.Text = "Auto Number"
        '
        'txtname
        '
        Me.txtname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(94, 251)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(363, 23)
        Me.txtname.TabIndex = 47
        '
        'txttel
        '
        Me.txttel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttel.Location = New System.Drawing.Point(94, 378)
        Me.txttel.Name = "txttel"
        Me.txttel.Size = New System.Drawing.Size(144, 23)
        Me.txttel.TabIndex = 48
        '
        'txtfax
        '
        Me.txtfax.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfax.Location = New System.Drawing.Point(313, 378)
        Me.txtfax.Name = "txtfax"
        Me.txtfax.Size = New System.Drawing.Size(144, 23)
        Me.txtfax.TabIndex = 49
        '
        'txtemail
        '
        Me.txtemail.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtemail.Location = New System.Drawing.Point(94, 405)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(363, 23)
        Me.txtemail.TabIndex = 50
        '
        'txtcntct
        '
        Me.txtcntct.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcntct.Location = New System.Drawing.Point(94, 432)
        Me.txtcntct.Name = "txtcntct"
        Me.txtcntct.Size = New System.Drawing.Size(363, 23)
        Me.txtcntct.TabIndex = 51
        '
        'dtpsdate
        '
        Me.dtpsdate.CustomFormat = "dd/MM/yyyy"
        Me.dtpsdate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpsdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpsdate.Location = New System.Drawing.Point(94, 459)
        Me.dtpsdate.Name = "dtpsdate"
        Me.dtpsdate.Size = New System.Drawing.Size(189, 23)
        Me.dtpsdate.TabIndex = 53
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 542)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 15)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Limit Days :"
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(627, 218)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(201, 28)
        Me.Button5.TabIndex = 63
        Me.Button5.Text = "Clear Selection"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(485, 247)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(341, 208)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 64
        Me.PictureBox1.TabStop = False
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(683, 457)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(143, 30)
        Me.Button6.TabIndex = 65
        Me.Button6.Text = "Browse ID Proof"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Customer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 565)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.txtlmtamnt)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.dtpsdate)
        Me.Controls.Add(Me.txtcntct)
        Me.Controls.Add(Me.txtemail)
        Me.Controls.Add(Me.txtfax)
        Me.Controls.Add(Me.txtadd2)
        Me.Controls.Add(Me.txttel)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.txtcode)
        Me.Controls.Add(Me.chbhold)
        Me.Controls.Add(Me.txtlmtdays)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtopenbal)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox12)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.chbactive)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtadd1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Customer"
        Me.Text = "IM - Master - Customers"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtadd2 As TextBox
    Friend WithEvents txtadd1 As TextBox
    Friend WithEvents txtlmtdays As TextBox
    Friend WithEvents txtopenbal As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtlmtamnt As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents chbactive As CheckBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintPreviewDialog2 As PrintPreviewDialog
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents chbhold As CheckBox
    Friend WithEvents txtcode As TextBox
    Friend WithEvents txtname As TextBox
    Friend WithEvents txttel As TextBox
    Friend WithEvents txtfax As TextBox
    Friend WithEvents txtemail As TextBox
    Friend WithEvents txtcntct As TextBox
    Friend WithEvents dtpsdate As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button6 As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
