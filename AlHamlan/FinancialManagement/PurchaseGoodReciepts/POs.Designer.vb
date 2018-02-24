<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class POs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POs))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintPreviewDialog2 = New System.Windows.Forms.PrintPreviewDialog()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtpono = New System.Windows.Forms.TextBox()
        Me.txtinst = New System.Windows.Forms.TextBox()
        Me.cbsuplr = New SergeUtils.EasyCompletionComboBox()
        Me.txtgross = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cbcrncy = New SergeUtils.EasyCompletionComboBox()
        Me.cbshiptrm = New SergeUtils.EasyCompletionComboBox()
        Me.dtppodate = New System.Windows.Forms.DateTimePicker()
        Me.cbdiv = New SergeUtils.EasyCompletionComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chbposted = New System.Windows.Forms.CheckBox()
        Me.cbpayterm = New SergeUtils.EasyCompletionComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtlc = New System.Windows.Forms.TextBox()
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
        Me.lbldue = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
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
        Me.Label1.Text = "Puchase Order"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(4, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "PO No. :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(547, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Supplier :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label12.Location = New System.Drawing.Point(278, 36)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 19)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Currency :"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1, 554)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(181, 30)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Add New PO"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(949, 39)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(228, 31)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Search PO"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(435, 554)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(306, 30)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Save and Print"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(996, 554)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(181, 30)
        Me.Button4.TabIndex = 4
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
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label16.Location = New System.Drawing.Point(547, 65)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 19)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Instructions :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label18.Location = New System.Drawing.Point(278, 7)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 19)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Date :"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label24.Location = New System.Drawing.Point(547, 36)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(84, 19)
        Me.Label24.TabIndex = 41
        Me.Label24.Text = "Ship Terms :"
        '
        'txtpono
        '
        Me.txtpono.BackColor = System.Drawing.Color.White
        Me.txtpono.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtpono.Location = New System.Drawing.Point(81, 4)
        Me.txtpono.Name = "txtpono"
        Me.txtpono.ReadOnly = True
        Me.txtpono.Size = New System.Drawing.Size(175, 26)
        Me.txtpono.TabIndex = 10000
        '
        'txtinst
        '
        Me.txtinst.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtinst.Location = New System.Drawing.Point(632, 62)
        Me.txtinst.Name = "txtinst"
        Me.txtinst.Size = New System.Drawing.Size(539, 26)
        Me.txtinst.TabIndex = 7
        '
        'cbsuplr
        '
        Me.cbsuplr.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.cbsuplr.FormattingEnabled = True
        Me.cbsuplr.Location = New System.Drawing.Point(632, 4)
        Me.cbsuplr.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbsuplr.Name = "cbsuplr"
        Me.cbsuplr.Size = New System.Drawing.Size(356, 27)
        Me.cbsuplr.TabIndex = 2
        '
        'txtgross
        '
        Me.txtgross.BackColor = System.Drawing.Color.White
        Me.txtgross.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtgross.Location = New System.Drawing.Point(293, 445)
        Me.txtgross.Name = "txtgross"
        Me.txtgross.ReadOnly = True
        Me.txtgross.Size = New System.Drawing.Size(80, 26)
        Me.txtgross.TabIndex = 11
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label19.Location = New System.Drawing.Point(219, 448)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 19)
        Me.Label19.TabIndex = 54
        Me.Label19.Text = "Gross :"
        '
        'cbcrncy
        '
        Me.cbcrncy.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.cbcrncy.FormattingEnabled = True
        Me.cbcrncy.Location = New System.Drawing.Point(373, 33)
        Me.cbcrncy.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbcrncy.Name = "cbcrncy"
        Me.cbcrncy.Size = New System.Drawing.Size(148, 27)
        Me.cbcrncy.TabIndex = 4
        Me.cbcrncy.Tag = ""
        '
        'cbshiptrm
        '
        Me.cbshiptrm.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.cbshiptrm.FormattingEnabled = True
        Me.cbshiptrm.Location = New System.Drawing.Point(632, 33)
        Me.cbshiptrm.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbshiptrm.Name = "cbshiptrm"
        Me.cbshiptrm.Size = New System.Drawing.Size(356, 27)
        Me.cbshiptrm.TabIndex = 5
        '
        'dtppodate
        '
        Me.dtppodate.CustomFormat = "dd/MMM/yyyy"
        Me.dtppodate.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.dtppodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtppodate.Location = New System.Drawing.Point(373, 4)
        Me.dtppodate.Name = "dtppodate"
        Me.dtppodate.Size = New System.Drawing.Size(148, 26)
        Me.dtppodate.TabIndex = 1
        '
        'cbdiv
        '
        Me.cbdiv.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.cbdiv.FormattingEnabled = True
        Me.cbdiv.Location = New System.Drawing.Point(81, 33)
        Me.cbdiv.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbdiv.Name = "cbdiv"
        Me.cbdiv.Size = New System.Drawing.Size(175, 27)
        Me.cbdiv.TabIndex = 3
        Me.cbdiv.Tag = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(4, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 19)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "Division :"
        '
        'chbposted
        '
        Me.chbposted.AutoSize = True
        Me.chbposted.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.chbposted.Location = New System.Drawing.Point(1099, 110)
        Me.chbposted.Name = "chbposted"
        Me.chbposted.Size = New System.Drawing.Size(70, 23)
        Me.chbposted.TabIndex = 6
        Me.chbposted.Text = "Posted"
        Me.chbposted.UseVisualStyleBackColor = True
        '
        'cbpayterm
        '
        Me.cbpayterm.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.cbpayterm.FormattingEnabled = True
        Me.cbpayterm.Location = New System.Drawing.Point(81, 62)
        Me.cbpayterm.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbpayterm.Name = "cbpayterm"
        Me.cbpayterm.Size = New System.Drawing.Size(175, 27)
        Me.cbpayterm.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label6.Location = New System.Drawing.Point(4, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 19)
        Me.Label6.TabIndex = 75
        Me.Label6.Text = "Pay Terms :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label8.Location = New System.Drawing.Point(278, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 19)
        Me.Label8.TabIndex = 77
        Me.Label8.Text = "Bounded LC :"
        '
        'txtlc
        '
        Me.txtlc.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtlc.Location = New System.Drawing.Point(373, 62)
        Me.txtlc.Name = "txtlc"
        Me.txtlc.Size = New System.Drawing.Size(148, 26)
        Me.txtlc.TabIndex = 9
        '
        'txtperc
        '
        Me.txtperc.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtperc.Location = New System.Drawing.Point(508, 445)
        Me.txtperc.Name = "txtperc"
        Me.txtperc.Size = New System.Drawing.Size(65, 26)
        Me.txtperc.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(399, 448)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 19)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Discount % :"
        '
        'txtdisc
        '
        Me.txtdisc.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtdisc.Location = New System.Drawing.Point(694, 445)
        Me.txtdisc.Name = "txtdisc"
        Me.txtdisc.Size = New System.Drawing.Size(80, 26)
        Me.txtdisc.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label7.Location = New System.Drawing.Point(600, 448)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 19)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Discount :"
        '
        'txtchrgs
        '
        Me.txtchrgs.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtchrgs.Location = New System.Drawing.Point(887, 445)
        Me.txtchrgs.Name = "txtchrgs"
        Me.txtchrgs.Size = New System.Drawing.Size(80, 26)
        Me.txtchrgs.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label9.Location = New System.Drawing.Point(799, 448)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 19)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "Charges :"
        '
        'txtnet
        '
        Me.txtnet.BackColor = System.Drawing.Color.White
        Me.txtnet.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtnet.Location = New System.Drawing.Point(1053, 445)
        Me.txtnet.Name = "txtnet"
        Me.txtnet.ReadOnly = True
        Me.txtnet.Size = New System.Drawing.Size(80, 26)
        Me.txtnet.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label10.Location = New System.Drawing.Point(992, 448)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 19)
        Me.Label10.TabIndex = 86
        Me.Label10.Text = "Net :"
        '
        'txtcnt
        '
        Me.txtcnt.BackColor = System.Drawing.Color.White
        Me.txtcnt.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtcnt.Location = New System.Drawing.Point(114, 445)
        Me.txtcnt.Name = "txtcnt"
        Me.txtcnt.ReadOnly = True
        Me.txtcnt.Size = New System.Drawing.Size(80, 26)
        Me.txtcnt.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label13.Location = New System.Drawing.Point(41, 448)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 19)
        Me.Label13.TabIndex = 90
        Me.Label13.Text = "Count :"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lbldue)
        Me.Panel1.Controls.Add(Me.txtgross)
        Me.Panel1.Controls.Add(Me.txtinst)
        Me.Panel1.Controls.Add(Me.txtcnt)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.txtnet)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.txtchrgs)
        Me.Panel1.Controls.Add(Me.txtpono)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtdisc)
        Me.Panel1.Controls.Add(Me.cbsuplr)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.txtperc)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cbcrncy)
        Me.Panel1.Controls.Add(Me.txtlc)
        Me.Panel1.Controls.Add(Me.dtppodate)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.cbshiptrm)
        Me.Panel1.Controls.Add(Me.cbpayterm)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cbdiv)
        Me.Panel1.Location = New System.Drawing.Point(1, 74)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1176, 476)
        Me.Panel1.TabIndex = 0
        '
        'lbldue
        '
        Me.lbldue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbldue.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldue.ForeColor = System.Drawing.Color.Red
        Me.lbldue.Location = New System.Drawing.Point(994, 4)
        Me.lbldue.Name = "lbldue"
        Me.lbldue.Size = New System.Drawing.Size(177, 28)
        Me.lbldue.TabIndex = 10001
        Me.lbldue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PrintDocument1
        '
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(1, 38)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(268, 30)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Clear Details"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 168)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.Size = New System.Drawing.Size(1167, 343)
        Me.DataGridView1.TabIndex = 1
        '
        'POs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1177, 586)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.chbposted)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "POs"
        Me.Text = "IM - Master - Item"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintPreviewDialog2 As PrintPreviewDialog
    Friend WithEvents Label16 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents txtpono As TextBox
    Friend WithEvents txtinst As TextBox
    Private WithEvents cbsuplr As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtgross As TextBox
    Friend WithEvents Label19 As Label
    Private WithEvents cbcrncy As SergeUtils.EasyCompletionComboBox
    Private WithEvents cbshiptrm As SergeUtils.EasyCompletionComboBox
    Friend WithEvents dtppodate As DateTimePicker
    Private WithEvents cbdiv As SergeUtils.EasyCompletionComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents chbposted As CheckBox
    Private WithEvents cbpayterm As SergeUtils.EasyCompletionComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtlc As TextBox
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
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Button5 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lbldue As Label
End Class
