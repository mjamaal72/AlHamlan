<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Proforma
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Proforma))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtgross = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbcust = New SergeUtils.EasyCompletionComboBox()
        Me.dtpdate = New System.Windows.Forms.DateTimePicker()
        Me.chbcncl = New System.Windows.Forms.CheckBox()
        Me.txtinst = New System.Windows.Forms.TextBox()
        Me.txtcnt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtnet = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtchrgs = New System.Windows.Forms.TextBox()
        Me.txtquotno = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtdisc = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtperc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbslsmen = New SergeUtils.EasyCompletionComboBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.chbposted = New System.Windows.Forms.CheckBox()
        Me.PrintPreviewDialog2 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtgross
        '
        Me.txtgross.BackColor = System.Drawing.Color.White
        Me.txtgross.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgross.Location = New System.Drawing.Point(431, 461)
        Me.txtgross.Name = "txtgross"
        Me.txtgross.ReadOnly = True
        Me.txtgross.Size = New System.Drawing.Size(80, 26)
        Me.txtgross.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cbcust)
        Me.Panel1.Controls.Add(Me.dtpdate)
        Me.Panel1.Controls.Add(Me.chbcncl)
        Me.Panel1.Controls.Add(Me.txtgross)
        Me.Panel1.Controls.Add(Me.txtinst)
        Me.Panel1.Controls.Add(Me.txtcnt)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.txtnet)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtchrgs)
        Me.Panel1.Controls.Add(Me.txtquotno)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtdisc)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.txtperc)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cbslsmen)
        Me.Panel1.Location = New System.Drawing.Point(0, 71)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1176, 492)
        Me.Panel1.TabIndex = 95
        '
        'cbcust
        '
        Me.cbcust.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcust.FormattingEnabled = True
        Me.cbcust.Location = New System.Drawing.Point(557, 4)
        Me.cbcust.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbcust.Name = "cbcust"
        Me.cbcust.Size = New System.Drawing.Size(613, 27)
        Me.cbcust.TabIndex = 2
        '
        'dtpdate
        '
        Me.dtpdate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpdate.Location = New System.Drawing.Point(273, 3)
        Me.dtpdate.Name = "dtpdate"
        Me.dtpdate.Size = New System.Drawing.Size(131, 26)
        Me.dtpdate.TabIndex = 1
        '
        'chbcncl
        '
        Me.chbcncl.AutoSize = True
        Me.chbcncl.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbcncl.Location = New System.Drawing.Point(989, 35)
        Me.chbcncl.Name = "chbcncl"
        Me.chbcncl.Size = New System.Drawing.Size(88, 23)
        Me.chbcncl.TabIndex = 5
        Me.chbcncl.Text = "Cancelled"
        Me.chbcncl.UseVisualStyleBackColor = True
        '
        'txtinst
        '
        Me.txtinst.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinst.Location = New System.Drawing.Point(557, 33)
        Me.txtinst.Name = "txtinst"
        Me.txtinst.Size = New System.Drawing.Size(426, 26)
        Me.txtinst.TabIndex = 4
        '
        'txtcnt
        '
        Me.txtcnt.BackColor = System.Drawing.Color.White
        Me.txtcnt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcnt.Location = New System.Drawing.Point(274, 461)
        Me.txtcnt.Name = "txtcnt"
        Me.txtcnt.ReadOnly = True
        Me.txtcnt.Size = New System.Drawing.Size(80, 26)
        Me.txtcnt.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Quote No :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(215, 464)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 19)
        Me.Label13.TabIndex = 90
        Me.Label13.Text = "Count :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(466, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Customer :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(466, 36)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 19)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Instructions :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(230, 6)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 19)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Date :"
        '
        'txtnet
        '
        Me.txtnet.BackColor = System.Drawing.Color.White
        Me.txtnet.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnet.Location = New System.Drawing.Point(1089, 461)
        Me.txtnet.Name = "txtnet"
        Me.txtnet.ReadOnly = True
        Me.txtnet.Size = New System.Drawing.Size(80, 26)
        Me.txtnet.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(1044, 464)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 19)
        Me.Label10.TabIndex = 86
        Me.Label10.Text = "Net :"
        '
        'txtchrgs
        '
        Me.txtchrgs.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtchrgs.Location = New System.Drawing.Point(950, 461)
        Me.txtchrgs.Name = "txtchrgs"
        Me.txtchrgs.Size = New System.Drawing.Size(80, 26)
        Me.txtchrgs.TabIndex = 10
        '
        'txtquotno
        '
        Me.txtquotno.BackColor = System.Drawing.Color.White
        Me.txtquotno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtquotno.Location = New System.Drawing.Point(93, 4)
        Me.txtquotno.Name = "txtquotno"
        Me.txtquotno.ReadOnly = True
        Me.txtquotno.Size = New System.Drawing.Size(89, 26)
        Me.txtquotno.TabIndex = 10000
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(878, 464)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 19)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "Charges :"
        '
        'txtdisc
        '
        Me.txtdisc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdisc.Location = New System.Drawing.Point(783, 461)
        Me.txtdisc.Name = "txtdisc"
        Me.txtdisc.Size = New System.Drawing.Size(80, 26)
        Me.txtdisc.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(708, 464)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 19)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Discount :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(373, 464)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 19)
        Me.Label19.TabIndex = 54
        Me.Label19.Text = "Gross :"
        '
        'txtperc
        '
        Me.txtperc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtperc.Location = New System.Drawing.Point(625, 461)
        Me.txtperc.Name = "txtperc"
        Me.txtperc.Size = New System.Drawing.Size(65, 26)
        Me.txtperc.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(533, 464)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 19)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Discount % :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 19)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "Salesman :"
        '
        'cbslsmen
        '
        Me.cbslsmen.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbslsmen.FormattingEnabled = True
        Me.cbslsmen.Location = New System.Drawing.Point(93, 33)
        Me.cbslsmen.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbslsmen.Name = "cbslsmen"
        Me.cbslsmen.Size = New System.Drawing.Size(311, 27)
        Me.cbslsmen.TabIndex = 3
        Me.cbslsmen.Tag = ""
        '
        'PrintDocument1
        '
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(-1, 39)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(326, 30)
        Me.Button5.TabIndex = 104
        Me.Button5.Text = "Clear Selection"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.RadioButton2)
        Me.Panel2.Controls.Add(Me.RadioButton1)
        Me.Panel2.Location = New System.Drawing.Point(694, 38)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 32)
        Me.Panel2.TabIndex = 106
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.RadioButton2.Location = New System.Drawing.Point(63, 5)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(132, 23)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Overwrite N Edit"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.RadioButton1.Location = New System.Drawing.Point(3, 4)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(58, 23)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "View"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'chbposted
        '
        Me.chbposted.AutoSize = True
        Me.chbposted.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbposted.Location = New System.Drawing.Point(1101, 108)
        Me.chbposted.Name = "chbposted"
        Me.chbposted.Size = New System.Drawing.Size(70, 23)
        Me.chbposted.TabIndex = 96
        Me.chbposted.Text = "P&osted"
        Me.chbposted.UseVisualStyleBackColor = True
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
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(5, 135)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.Size = New System.Drawing.Size(1167, 392)
        Me.DataGridView1.TabIndex = 97
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(1049, 563)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(128, 30)
        Me.Button4.TabIndex = 103
        Me.Button4.Text = "Exit Form"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(368, 563)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(183, 30)
        Me.Button3.TabIndex = 99
        Me.Button3.Text = "Print Performa"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(901, 38)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(275, 32)
        Me.Button2.TabIndex = 105
        Me.Button2.Text = "Search Quotation/Performa"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(0, 563)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(183, 30)
        Me.Button1.TabIndex = 98
        Me.Button1.Text = "Add New Proforma"
        Me.Button1.UseVisualStyleBackColor = True
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
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "Performa Invoice \Quotaions"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(557, 563)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(251, 30)
        Me.Button6.TabIndex = 107
        Me.Button6.Text = "Print Performa Thermal"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Proforma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1177, 592)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.chbposted)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Proforma"
        Me.Text = "IM - Transactions - Proforma Invoice"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtgross As TextBox
    Friend WithEvents Panel1 As Panel
    Private WithEvents cbcust As SergeUtils.EasyCompletionComboBox
    Friend WithEvents dtpdate As DateTimePicker
    Friend WithEvents chbcncl As CheckBox
    Friend WithEvents txtinst As TextBox
    Friend WithEvents txtcnt As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtnet As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtchrgs As TextBox
    Friend WithEvents txtquotno As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtdisc As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txtperc As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Private WithEvents cbslsmen As SergeUtils.EasyCompletionComboBox
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Button5 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents chbposted As CheckBox
    Friend WithEvents PrintPreviewDialog2 As PrintPreviewDialog
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button6 As Button
End Class
