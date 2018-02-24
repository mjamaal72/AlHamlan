<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GRN
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GRN))
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
        Me.txtgrnno = New System.Windows.Forms.TextBox()
        Me.txtinst = New System.Windows.Forms.TextBox()
        Me.cbcust = New SergeUtils.EasyCompletionComboBox()
        Me.txtgross = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dtpdate = New System.Windows.Forms.DateTimePicker()
        Me.cbslsmen = New SergeUtils.EasyCompletionComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chbposted = New System.Windows.Forms.CheckBox()
        Me.txtchrgs = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtdisc = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtnet = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtcnt = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chbcncl = New System.Windows.Forms.CheckBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.lblInvLoad = New System.Windows.Forms.Label()
        Me.txtInvLoad = New System.Windows.Forms.TextBox()
        Me.btnInvLoad = New System.Windows.Forms.Button()
        Me.btnSrcInv = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 141)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.Size = New System.Drawing.Size(1167, 387)
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
        Me.Label1.Size = New System.Drawing.Size(1177, 37)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Goods Return Notes (GRN)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "GRN No :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(484, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Customer :"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(0, 565)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(174, 30)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Add New GRN"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(870, 39)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(303, 30)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Search GRN"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(411, 565)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(174, 30)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Print GRN"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(1003, 565)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(174, 30)
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
        Me.Label16.Location = New System.Drawing.Point(346, 36)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 19)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Instructions :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(253, 7)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 19)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Date :"
        '
        'txtgrnno
        '
        Me.txtgrnno.BackColor = System.Drawing.Color.White
        Me.txtgrnno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgrnno.Location = New System.Drawing.Point(93, 4)
        Me.txtgrnno.Name = "txtgrnno"
        Me.txtgrnno.ReadOnly = True
        Me.txtgrnno.Size = New System.Drawing.Size(100, 26)
        Me.txtgrnno.TabIndex = 10000
        '
        'txtinst
        '
        Me.txtinst.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinst.Location = New System.Drawing.Point(437, 33)
        Me.txtinst.Name = "txtinst"
        Me.txtinst.Size = New System.Drawing.Size(554, 26)
        Me.txtinst.TabIndex = 4
        '
        'cbcust
        '
        Me.cbcust.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcust.FormattingEnabled = True
        Me.cbcust.Location = New System.Drawing.Point(565, 4)
        Me.cbcust.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbcust.Name = "cbcust"
        Me.cbcust.Size = New System.Drawing.Size(606, 27)
        Me.cbcust.TabIndex = 2
        '
        'txtgross
        '
        Me.txtgross.BackColor = System.Drawing.Color.White
        Me.txtgross.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgross.Location = New System.Drawing.Point(339, 456)
        Me.txtgross.Name = "txtgross"
        Me.txtgross.ReadOnly = True
        Me.txtgross.Size = New System.Drawing.Size(80, 26)
        Me.txtgross.TabIndex = 7
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(265, 462)
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
        Me.dtpdate.Location = New System.Drawing.Point(304, 4)
        Me.dtpdate.Name = "dtpdate"
        Me.dtpdate.Size = New System.Drawing.Size(148, 26)
        Me.dtpdate.TabIndex = 1
        '
        'cbslsmen
        '
        Me.cbslsmen.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbslsmen.FormattingEnabled = True
        Me.cbslsmen.Location = New System.Drawing.Point(93, 33)
        Me.cbslsmen.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbslsmen.Name = "cbslsmen"
        Me.cbslsmen.Size = New System.Drawing.Size(249, 27)
        Me.cbslsmen.TabIndex = 3
        Me.cbslsmen.Tag = ""
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
        'chbposted
        '
        Me.chbposted.AutoSize = True
        Me.chbposted.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbposted.Location = New System.Drawing.Point(1103, 112)
        Me.chbposted.Name = "chbposted"
        Me.chbposted.Size = New System.Drawing.Size(70, 23)
        Me.chbposted.TabIndex = 1
        Me.chbposted.Text = "P&osted"
        Me.chbposted.UseVisualStyleBackColor = True
        '
        'txtchrgs
        '
        Me.txtchrgs.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtchrgs.Location = New System.Drawing.Point(609, 456)
        Me.txtchrgs.Name = "txtchrgs"
        Me.txtchrgs.Size = New System.Drawing.Size(65, 26)
        Me.txtchrgs.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(526, 462)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 19)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Charges :"
        '
        'txtdisc
        '
        Me.txtdisc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdisc.Location = New System.Drawing.Point(844, 456)
        Me.txtdisc.Name = "txtdisc"
        Me.txtdisc.Size = New System.Drawing.Size(80, 26)
        Me.txtdisc.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(753, 462)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 19)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Discount :"
        '
        'txtnet
        '
        Me.txtnet.BackColor = System.Drawing.Color.White
        Me.txtnet.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnet.Location = New System.Drawing.Point(1051, 456)
        Me.txtnet.Name = "txtnet"
        Me.txtnet.ReadOnly = True
        Me.txtnet.Size = New System.Drawing.Size(80, 26)
        Me.txtnet.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(990, 462)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 19)
        Me.Label10.TabIndex = 86
        Me.Label10.Text = "Net :"
        '
        'txtcnt
        '
        Me.txtcnt.BackColor = System.Drawing.Color.White
        Me.txtcnt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcnt.Location = New System.Drawing.Point(118, 456)
        Me.txtcnt.Name = "txtcnt"
        Me.txtcnt.ReadOnly = True
        Me.txtcnt.Size = New System.Drawing.Size(80, 26)
        Me.txtcnt.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(43, 462)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 19)
        Me.Label13.TabIndex = 90
        Me.Label13.Text = "Count :"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.Panel1.Controls.Add(Me.txtgrnno)
        Me.Panel1.Controls.Add(Me.txtdisc)
        Me.Panel1.Controls.Add(Me.cbcust)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.txtchrgs)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.dtpdate)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cbslsmen)
        Me.Panel1.Location = New System.Drawing.Point(1, 75)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1176, 488)
        Me.Panel1.TabIndex = 0
        '
        'chbcncl
        '
        Me.chbcncl.AutoSize = True
        Me.chbcncl.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbcncl.Location = New System.Drawing.Point(997, 36)
        Me.chbcncl.Name = "chbcncl"
        Me.chbcncl.Size = New System.Drawing.Size(88, 23)
        Me.chbcncl.TabIndex = 5
        Me.chbcncl.Text = "Cancelled"
        Me.chbcncl.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
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
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(591, 565)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(174, 30)
        Me.Button6.TabIndex = 8
        Me.Button6.Text = "Print GRN Thermal"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'lblInvLoad
        '
        Me.lblInvLoad.AutoSize = True
        Me.lblInvLoad.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvLoad.Location = New System.Drawing.Point(377, 43)
        Me.lblInvLoad.Name = "lblInvLoad"
        Me.lblInvLoad.Size = New System.Drawing.Size(117, 19)
        Me.lblInvLoad.TabIndex = 10001
        Me.lblInvLoad.Text = "Load By Invoice :"
        '
        'txtInvLoad
        '
        Me.txtInvLoad.BackColor = System.Drawing.Color.White
        Me.txtInvLoad.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvLoad.Location = New System.Drawing.Point(500, 41)
        Me.txtInvLoad.Name = "txtInvLoad"
        Me.txtInvLoad.Size = New System.Drawing.Size(100, 26)
        Me.txtInvLoad.TabIndex = 10002
        '
        'btnInvLoad
        '
        Me.btnInvLoad.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInvLoad.Location = New System.Drawing.Point(606, 39)
        Me.btnInvLoad.Name = "btnInvLoad"
        Me.btnInvLoad.Size = New System.Drawing.Size(89, 30)
        Me.btnInvLoad.TabIndex = 10003
        Me.btnInvLoad.Text = "Load Invoice"
        Me.btnInvLoad.UseVisualStyleBackColor = True
        '
        'btnSrcInv
        '
        Me.btnSrcInv.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSrcInv.Location = New System.Drawing.Point(701, 39)
        Me.btnSrcInv.Name = "btnSrcInv"
        Me.btnSrcInv.Size = New System.Drawing.Size(98, 30)
        Me.btnSrcInv.TabIndex = 10004
        Me.btnSrcInv.Text = "Search Invoice"
        Me.btnSrcInv.UseVisualStyleBackColor = True
        '
        'GRN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1177, 596)
        Me.Controls.Add(Me.btnSrcInv)
        Me.Controls.Add(Me.btnInvLoad)
        Me.Controls.Add(Me.lblInvLoad)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.txtInvLoad)
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
        Me.Name = "GRN"
        Me.Text = "IM - Transactions - Goods Return Notes"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
    Friend WithEvents txtgrnno As TextBox
    Friend WithEvents txtinst As TextBox
    Private WithEvents cbcust As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtgross As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents dtpdate As DateTimePicker
    Private WithEvents cbslsmen As SergeUtils.EasyCompletionComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents chbposted As CheckBox
    Friend WithEvents txtchrgs As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtdisc As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtnet As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtcnt As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Button5 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents chbcncl As CheckBox
    Friend WithEvents Button6 As Button
    Friend WithEvents lblInvLoad As Label
    Friend WithEvents txtInvLoad As TextBox
    Friend WithEvents btnInvLoad As Button
    Friend WithEvents btnSrcInv As Button
End Class
