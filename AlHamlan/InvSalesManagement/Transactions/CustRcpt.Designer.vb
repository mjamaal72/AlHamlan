<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CustRcpt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustRcpt))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintPreviewDialog2 = New System.Windows.Forms.PrintPreviewDialog()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtrefno = New System.Windows.Forms.TextBox()
        Me.txtRmrks = New System.Windows.Forms.TextBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtrefnet = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbpaymode = New SergeUtils.EasyCompletionComboBox()
        Me.txtpayAmnt = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPndgAmnt = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cbcust = New SergeUtils.EasyCompletionComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.txtbarcode = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.dtpdate = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtrcno = New System.Windows.Forms.TextBox()
        Me.lblrcno = New System.Windows.Forms.Label()
        Me.txtInvDisc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(4, 39)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(896, 264)
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
        Me.Label1.Size = New System.Drawing.Size(908, 37)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Customer Reciepts"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "InvoiceNo. :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Customer :"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(299, 274)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 30)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Submit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(191, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(187, 28)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Search Reciepts"
        Me.Button2.UseVisualStyleBackColor = True
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
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 248)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 15)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Remarks :"
        '
        'txtrefno
        '
        Me.txtrefno.BackColor = System.Drawing.Color.White
        Me.txtrefno.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtrefno.Location = New System.Drawing.Point(84, 127)
        Me.txtrefno.Name = "txtrefno"
        Me.txtrefno.ReadOnly = True
        Me.txtrefno.Size = New System.Drawing.Size(107, 23)
        Me.txtrefno.TabIndex = 3
        Me.txtrefno.Text = "0"
        '
        'txtRmrks
        '
        Me.txtRmrks.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtRmrks.Location = New System.Drawing.Point(84, 245)
        Me.txtRmrks.Name = "txtRmrks"
        Me.txtRmrks.Size = New System.Drawing.Size(343, 23)
        Me.txtRmrks.TabIndex = 8
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtSearch.Location = New System.Drawing.Point(3, 10)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(182, 23)
        Me.txtSearch.TabIndex = 0
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(433, 72)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.Size = New System.Drawing.Size(473, 232)
        Me.DataGridView2.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 159)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 15)
        Me.Label13.TabIndex = 90
        Me.Label13.Text = "Invoice Net :"
        '
        'txtrefnet
        '
        Me.txtrefnet.BackColor = System.Drawing.Color.White
        Me.txtrefnet.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtrefnet.Location = New System.Drawing.Point(84, 156)
        Me.txtrefnet.Name = "txtrefnet"
        Me.txtrefnet.ReadOnly = True
        Me.txtrefnet.Size = New System.Drawing.Size(107, 23)
        Me.txtrefnet.TabIndex = 4
        Me.txtrefnet.Text = "0"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Location = New System.Drawing.Point(1, 310)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(905, 308)
        Me.Panel1.TabIndex = 12
        Me.Panel1.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 217)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 15)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "Pay Mode :"
        '
        'cbpaymode
        '
        Me.cbpaymode.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbpaymode.FormattingEnabled = True
        Me.cbpaymode.Location = New System.Drawing.Point(84, 214)
        Me.cbpaymode.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbpaymode.Name = "cbpaymode"
        Me.cbpaymode.Size = New System.Drawing.Size(140, 23)
        Me.cbpaymode.TabIndex = 6
        Me.cbpaymode.Tag = ""
        '
        'txtpayAmnt
        '
        Me.txtpayAmnt.BackColor = System.Drawing.Color.White
        Me.txtpayAmnt.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtpayAmnt.Location = New System.Drawing.Point(320, 214)
        Me.txtpayAmnt.Name = "txtpayAmnt"
        Me.txtpayAmnt.Size = New System.Drawing.Size(107, 23)
        Me.txtpayAmnt.TabIndex = 7
        Me.txtpayAmnt.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(240, 217)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 15)
        Me.Label8.TabIndex = 98
        Me.Label8.Text = "Pay Amount :"
        '
        'txtPndgAmnt
        '
        Me.txtPndgAmnt.BackColor = System.Drawing.SystemColors.Control
        Me.txtPndgAmnt.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtPndgAmnt.ForeColor = System.Drawing.Color.Red
        Me.txtPndgAmnt.Location = New System.Drawing.Point(84, 185)
        Me.txtPndgAmnt.Name = "txtPndgAmnt"
        Me.txtPndgAmnt.ReadOnly = True
        Me.txtPndgAmnt.Size = New System.Drawing.Size(343, 23)
        Me.txtPndgAmnt.TabIndex = 99
        Me.txtPndgAmnt.Text = "Pending Amount : "
        Me.txtPndgAmnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(84, 274)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(128, 30)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = "Hide All Reciepts"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'cbcust
        '
        Me.cbcust.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbcust.FormattingEnabled = True
        Me.cbcust.Location = New System.Drawing.Point(84, 98)
        Me.cbcust.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbcust.Name = "cbcust"
        Me.cbcust.Size = New System.Drawing.Size(343, 23)
        Me.cbcust.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RadioButton3)
        Me.Panel2.Controls.Add(Me.RadioButton2)
        Me.Panel2.Controls.Add(Me.RadioButton1)
        Me.Panel2.Location = New System.Drawing.Point(433, 37)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(473, 34)
        Me.Panel2.TabIndex = 10
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton3.Location = New System.Drawing.Point(263, 6)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(171, 19)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.Text = "Reciepts for InvNo : 000000"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(169, 6)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(88, 19)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Invoice List"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(69, 6)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(94, 19)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Reciepts List"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'txtbarcode
        '
        Me.txtbarcode.BackColor = System.Drawing.Color.White
        Me.txtbarcode.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbarcode.Location = New System.Drawing.Point(299, 40)
        Me.txtbarcode.Name = "txtbarcode"
        Me.txtbarcode.Size = New System.Drawing.Size(128, 27)
        Me.txtbarcode.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(169, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 23)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "Scan Barcode :"
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(9, 41)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(128, 23)
        Me.Button3.TabIndex = 13
        Me.Button3.Text = "Reset"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'dtpdate
        '
        Me.dtpdate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpdate.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpdate.Location = New System.Drawing.Point(84, 69)
        Me.dtpdate.Name = "dtpdate"
        Me.dtpdate.Size = New System.Drawing.Size(131, 23)
        Me.dtpdate.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.Label18.Location = New System.Drawing.Point(12, 72)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 15)
        Me.Label18.TabIndex = 104
        Me.Label18.Text = "Date :"
        '
        'txtrcno
        '
        Me.txtrcno.BackColor = System.Drawing.Color.White
        Me.txtrcno.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtrcno.Location = New System.Drawing.Point(320, 69)
        Me.txtrcno.Name = "txtrcno"
        Me.txtrcno.ReadOnly = True
        Me.txtrcno.Size = New System.Drawing.Size(107, 23)
        Me.txtrcno.TabIndex = 105
        '
        'lblrcno
        '
        Me.lblrcno.AutoSize = True
        Me.lblrcno.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblrcno.Location = New System.Drawing.Point(269, 72)
        Me.lblrcno.Name = "lblrcno"
        Me.lblrcno.Size = New System.Drawing.Size(45, 15)
        Me.lblrcno.TabIndex = 106
        Me.lblrcno.Text = "RC No :"
        '
        'txtInvDisc
        '
        Me.txtInvDisc.BackColor = System.Drawing.Color.White
        Me.txtInvDisc.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtInvDisc.Location = New System.Drawing.Point(320, 156)
        Me.txtInvDisc.Name = "txtInvDisc"
        Me.txtInvDisc.ReadOnly = True
        Me.txtInvDisc.Size = New System.Drawing.Size(107, 23)
        Me.txtInvDisc.TabIndex = 5
        Me.txtInvDisc.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(240, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 15)
        Me.Label4.TabIndex = 108
        Me.Label4.Text = "Inv Discount :"
        '
        'CustRcpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(908, 620)
        Me.Controls.Add(Me.txtInvDisc)
        Me.Controls.Add(Me.txtrefnet)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblrcno)
        Me.Controls.Add(Me.txtrcno)
        Me.Controls.Add(Me.dtpdate)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.txtbarcode)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPndgAmnt)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.txtpayAmnt)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtRmrks)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtrefno)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.cbcust)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cbpaymode)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "CustRcpt"
        Me.Text = "IM - Transactions - Customer Reciepts"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label15 As Label
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintPreviewDialog2 As PrintPreviewDialog
    Friend WithEvents Label16 As Label
    Friend WithEvents txtrefno As TextBox
    Friend WithEvents txtRmrks As TextBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Label13 As Label
    Friend WithEvents txtrefnet As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Private WithEvents cbpaymode As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtpayAmnt As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPndgAmnt As TextBox
    Friend WithEvents Button4 As Button
    Private WithEvents cbcust As SergeUtils.EasyCompletionComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents txtbarcode As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents dtpdate As DateTimePicker
    Friend WithEvents Label18 As Label
    Friend WithEvents txtrcno As TextBox
    Friend WithEvents lblrcno As Label
    Friend WithEvents txtInvDisc As TextBox
    Friend WithEvents Label4 As Label
End Class
