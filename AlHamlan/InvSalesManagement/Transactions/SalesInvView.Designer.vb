<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SalesInvView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalesInvView))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtLPO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chbcncl = New System.Windows.Forms.CheckBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.cbcust = New SergeUtils.EasyCompletionComboBox()
        Me.dtpdate = New System.Windows.Forms.DateTimePicker()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.txtgross = New System.Windows.Forms.TextBox()
        Me.txtcnt = New System.Windows.Forms.TextBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.txtinst = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtnet = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtchrgs = New System.Windows.Forms.TextBox()
        Me.txtinvno = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtdisc = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtperc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chbposted = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbslsmen = New SergeUtils.EasyCompletionComboBox()
        Me.PrintPreviewDialog2 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button9 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtLPO
        '
        Me.txtLPO.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLPO.Location = New System.Drawing.Point(511, 3)
        Me.txtLPO.Name = "txtLPO"
        Me.txtLPO.Size = New System.Drawing.Size(78, 26)
        Me.txtLPO.TabIndex = 91
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(467, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 19)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "LPO :"
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
        'PrintDocument1
        '
        '
        'cbcust
        '
        Me.cbcust.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcust.FormattingEnabled = True
        Me.cbcust.Location = New System.Drawing.Point(708, 4)
        Me.cbcust.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbcust.Name = "cbcust"
        Me.cbcust.Size = New System.Drawing.Size(462, 27)
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
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(320, 533)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(128, 30)
        Me.Button7.TabIndex = 100
        Me.Button7.Text = "Print Delivery Note"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'txtgross
        '
        Me.txtgross.BackColor = System.Drawing.Color.White
        Me.txtgross.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgross.Location = New System.Drawing.Point(264, 461)
        Me.txtgross.Name = "txtgross"
        Me.txtgross.ReadOnly = True
        Me.txtgross.Size = New System.Drawing.Size(80, 26)
        Me.txtgross.TabIndex = 7
        '
        'txtcnt
        '
        Me.txtcnt.BackColor = System.Drawing.Color.White
        Me.txtcnt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcnt.Location = New System.Drawing.Point(62, 461)
        Me.txtcnt.Name = "txtcnt"
        Me.txtcnt.ReadOnly = True
        Me.txtcnt.Size = New System.Drawing.Size(80, 26)
        Me.txtcnt.TabIndex = 6
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(464, 533)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(152, 30)
        Me.Button8.TabIndex = 102
        Me.Button8.Text = "Print Cash\Credit Memo"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'txtinst
        '
        Me.txtinst.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinst.Location = New System.Drawing.Point(557, 33)
        Me.txtinst.Name = "txtinst"
        Me.txtinst.Size = New System.Drawing.Size(426, 26)
        Me.txtinst.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Invoice No :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 464)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 19)
        Me.Label13.TabIndex = 90
        Me.Label13.Text = "Count :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(635, 7)
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
        Me.txtchrgs.Location = New System.Drawing.Point(915, 461)
        Me.txtchrgs.Name = "txtchrgs"
        Me.txtchrgs.Size = New System.Drawing.Size(80, 26)
        Me.txtchrgs.TabIndex = 10
        '
        'txtinvno
        '
        Me.txtinvno.BackColor = System.Drawing.Color.White
        Me.txtinvno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinvno.Location = New System.Drawing.Point(93, 4)
        Me.txtinvno.Name = "txtinvno"
        Me.txtinvno.ReadOnly = True
        Me.txtinvno.Size = New System.Drawing.Size(89, 26)
        Me.txtinvno.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(843, 464)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 19)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "Charges :"
        '
        'txtdisc
        '
        Me.txtdisc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdisc.Location = New System.Drawing.Point(697, 461)
        Me.txtdisc.Name = "txtdisc"
        Me.txtdisc.Size = New System.Drawing.Size(80, 26)
        Me.txtdisc.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(622, 464)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 19)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Discount :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(206, 464)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 19)
        Me.Label19.TabIndex = 54
        Me.Label19.Text = "Gross :"
        '
        'txtperc
        '
        Me.txtperc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtperc.Location = New System.Drawing.Point(501, 461)
        Me.txtperc.Name = "txtperc"
        Me.txtperc.Size = New System.Drawing.Size(65, 26)
        Me.txtperc.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(409, 464)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 19)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Discount % :"
        '
        'chbposted
        '
        Me.chbposted.AutoSize = True
        Me.chbposted.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbposted.Location = New System.Drawing.Point(1101, 77)
        Me.chbposted.Name = "chbposted"
        Me.chbposted.Size = New System.Drawing.Size(70, 23)
        Me.chbposted.TabIndex = 96
        Me.chbposted.Text = "P&osted"
        Me.chbposted.UseVisualStyleBackColor = True
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
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(5, 104)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.Size = New System.Drawing.Size(1167, 392)
        Me.DataGridView1.TabIndex = 97
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(1049, 532)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(128, 30)
        Me.Button4.TabIndex = 103
        Me.Button4.Text = "E&xit Form"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(176, 533)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(128, 30)
        Me.Button3.TabIndex = 99
        Me.Button3.Text = "&Print Invoice"
        Me.Button3.UseVisualStyleBackColor = True
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
        Me.Label1.Text = "Sales Invoice"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cbcust)
        Me.Panel1.Controls.Add(Me.dtpdate)
        Me.Panel1.Controls.Add(Me.txtLPO)
        Me.Panel1.Controls.Add(Me.Label6)
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
        Me.Panel1.Controls.Add(Me.txtinvno)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtdisc)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.txtperc)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cbslsmen)
        Me.Panel1.Location = New System.Drawing.Point(0, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1176, 492)
        Me.Panel1.TabIndex = 95
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(5, 533)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(155, 30)
        Me.Button9.TabIndex = 104
        Me.Button9.Text = "Print Thermal Invoice"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'SalesInvView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1177, 562)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.chbposted)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "SalesInvView"
        Me.Text = "IM - Transactions - Sales Invoice View Only"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtLPO As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents chbcncl As CheckBox
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Private WithEvents cbcust As SergeUtils.EasyCompletionComboBox
    Friend WithEvents dtpdate As DateTimePicker
    Friend WithEvents Button7 As Button
    Friend WithEvents txtgross As TextBox
    Friend WithEvents txtcnt As TextBox
    Friend WithEvents Button8 As Button
    Friend WithEvents txtinst As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtnet As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtchrgs As TextBox
    Friend WithEvents txtinvno As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtdisc As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txtperc As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chbposted As CheckBox
    Friend WithEvents Label5 As Label
    Private WithEvents cbslsmen As SergeUtils.EasyCompletionComboBox
    Friend WithEvents PrintPreviewDialog2 As PrintPreviewDialog
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button9 As Button
End Class
