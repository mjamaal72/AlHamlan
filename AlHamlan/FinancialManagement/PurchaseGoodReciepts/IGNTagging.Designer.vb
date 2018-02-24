<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class IGNTagging
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IGNTagging))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ChbBind = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JVNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Narration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Crncy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amnt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IGN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintPreviewDialog2 = New System.Windows.Forms.PrintPreviewDialog()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbign = New SergeUtils.EasyCompletionComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CBSplr = New SergeUtils.EasyCompletionComboBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtignchrgs = New System.Windows.Forms.TextBox()
        Me.txtignnet = New System.Windows.Forms.TextBox()
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
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ChbBind, Me.ID, Me.JVNo, Me.Narration, Me.Type, Me.Crncy, Me.Amnt, Me.IGN})
        Me.DataGridView1.Location = New System.Drawing.Point(3, 33)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.Size = New System.Drawing.Size(885, 375)
        Me.DataGridView1.TabIndex = 3
        '
        'ChbBind
        '
        Me.ChbBind.HeaderText = "Tick"
        Me.ChbBind.Name = "ChbBind"
        Me.ChbBind.Width = 50
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ID.Visible = False
        '
        'JVNo
        '
        Me.JVNo.DataPropertyName = "Voucher_No"
        Me.JVNo.HeaderText = "JVNo"
        Me.JVNo.Name = "JVNo"
        Me.JVNo.ReadOnly = True
        Me.JVNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.JVNo.Width = 70
        '
        'Narration
        '
        Me.Narration.DataPropertyName = "Narration"
        Me.Narration.HeaderText = "Narration"
        Me.Narration.Name = "Narration"
        Me.Narration.ReadOnly = True
        Me.Narration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Narration.Width = 420
        '
        'Type
        '
        Me.Type.DataPropertyName = "Tran_Type"
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Type.Width = 50
        '
        'Crncy
        '
        Me.Crncy.DataPropertyName = "Vou_Cur"
        Me.Crncy.HeaderText = "Crncy"
        Me.Crncy.Name = "Crncy"
        Me.Crncy.ReadOnly = True
        Me.Crncy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Crncy.Width = 50
        '
        'Amnt
        '
        Me.Amnt.DataPropertyName = "Amnt"
        Me.Amnt.HeaderText = "Amnt"
        Me.Amnt.Name = "Amnt"
        Me.Amnt.ReadOnly = True
        Me.Amnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Amnt.Width = 150
        '
        'IGN
        '
        Me.IGN.DataPropertyName = "IGNBind"
        Me.IGN.HeaderText = "IGN.Ref"
        Me.IGN.Name = "IGN"
        Me.IGN.ReadOnly = True
        Me.IGN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.IGN.Width = 70
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(895, 37)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "IGN Tagging"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(637, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "IGN No:"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(3, 494)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(152, 30)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Update Binding"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(767, 495)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(128, 30)
        Me.Button4.TabIndex = 1
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
        Me.Label16.Location = New System.Drawing.Point(4, 6)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 19)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Supplier :"
        '
        'cbign
        '
        Me.cbign.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbign.FormattingEnabled = True
        Me.cbign.Location = New System.Drawing.Point(701, 3)
        Me.cbign.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbign.Name = "cbign"
        Me.cbign.Size = New System.Drawing.Size(100, 27)
        Me.cbign.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CBSplr)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.cbign)
        Me.Panel1.Location = New System.Drawing.Point(1, 75)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(894, 414)
        Me.Panel1.TabIndex = 0
        '
        'CBSplr
        '
        Me.CBSplr.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBSplr.FormattingEnabled = True
        Me.CBSplr.Location = New System.Drawing.Point(70, 3)
        Me.CBSplr.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.CBSplr.Name = "CBSplr"
        Me.CBSplr.Size = New System.Drawing.Size(553, 27)
        Me.CBSplr.TabIndex = 0
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.LinkLabel1.Location = New System.Drawing.Point(807, 6)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(82, 19)
        Me.LinkLabel1.TabIndex = 2
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "IGN Details"
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(0, 39)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(268, 30)
        Me.Button5.TabIndex = 2
        Me.Button5.Text = "Clear Selection"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.CheckBox1)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtignchrgs)
        Me.Panel2.Controls.Add(Me.txtignnet)
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
        Me.Panel2.Location = New System.Drawing.Point(635, 109)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(257, 305)
        Me.Panel2.TabIndex = 4
        Me.Panel2.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(90, 12)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(152, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Filter By Selected IGN"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 277)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 15)
        Me.Label5.TabIndex = 116
        Me.Label5.Text = "Net :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 248)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "Charges :"
        '
        'txtignchrgs
        '
        Me.txtignchrgs.BackColor = System.Drawing.Color.White
        Me.txtignchrgs.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtignchrgs.Location = New System.Drawing.Point(90, 245)
        Me.txtignchrgs.Name = "txtignchrgs"
        Me.txtignchrgs.ReadOnly = True
        Me.txtignchrgs.Size = New System.Drawing.Size(158, 23)
        Me.txtignchrgs.TabIndex = 8
        '
        'txtignnet
        '
        Me.txtignnet.BackColor = System.Drawing.Color.White
        Me.txtignnet.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtignnet.Location = New System.Drawing.Point(90, 274)
        Me.txtignnet.Name = "txtignnet"
        Me.txtignnet.ReadOnly = True
        Me.txtignnet.Size = New System.Drawing.Size(158, 23)
        Me.txtignnet.TabIndex = 9
        '
        'txtignadj
        '
        Me.txtignadj.BackColor = System.Drawing.Color.White
        Me.txtignadj.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtignadj.Location = New System.Drawing.Point(90, 214)
        Me.txtignadj.Name = "txtignadj"
        Me.txtignadj.ReadOnly = True
        Me.txtignadj.Size = New System.Drawing.Size(158, 23)
        Me.txtignadj.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 217)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 15)
        Me.Label4.TabIndex = 113
        Me.Label4.Text = "Adjust :"
        '
        'txtigndisc
        '
        Me.txtigndisc.BackColor = System.Drawing.Color.White
        Me.txtigndisc.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtigndisc.Location = New System.Drawing.Point(90, 185)
        Me.txtigndisc.Name = "txtigndisc"
        Me.txtigndisc.ReadOnly = True
        Me.txtigndisc.Size = New System.Drawing.Size(158, 23)
        Me.txtigndisc.TabIndex = 6
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(6, 188)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(62, 15)
        Me.Label23.TabIndex = 111
        Me.Label23.Text = "Discount :"
        '
        'txtigngross
        '
        Me.txtigngross.BackColor = System.Drawing.Color.White
        Me.txtigngross.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtigngross.Location = New System.Drawing.Point(90, 156)
        Me.txtigngross.Name = "txtigngross"
        Me.txtigngross.ReadOnly = True
        Me.txtigngross.Size = New System.Drawing.Size(158, 23)
        Me.txtigngross.TabIndex = 5
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(6, 159)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(45, 15)
        Me.Label22.TabIndex = 109
        Me.Label22.Text = "Gross :"
        '
        'txtinvdate
        '
        Me.txtinvdate.BackColor = System.Drawing.Color.White
        Me.txtinvdate.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtinvdate.Location = New System.Drawing.Point(90, 127)
        Me.txtinvdate.Name = "txtinvdate"
        Me.txtinvdate.ReadOnly = True
        Me.txtinvdate.Size = New System.Drawing.Size(158, 23)
        Me.txtinvdate.TabIndex = 4
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 130)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(81, 15)
        Me.Label21.TabIndex = 107
        Me.Label21.Text = "Invoice Date :"
        '
        'txtinvno
        '
        Me.txtinvno.BackColor = System.Drawing.Color.White
        Me.txtinvno.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtinvno.Location = New System.Drawing.Point(90, 98)
        Me.txtinvno.Name = "txtinvno"
        Me.txtinvno.ReadOnly = True
        Me.txtinvno.Size = New System.Drawing.Size(158, 23)
        Me.txtinvno.TabIndex = 3
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 101)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(71, 15)
        Me.Label20.TabIndex = 105
        Me.Label20.Text = "Invoice No :"
        '
        'txtigndate
        '
        Me.txtigndate.BackColor = System.Drawing.Color.White
        Me.txtigndate.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtigndate.Location = New System.Drawing.Point(90, 69)
        Me.txtigndate.Name = "txtigndate"
        Me.txtigndate.ReadOnly = True
        Me.txtigndate.Size = New System.Drawing.Size(158, 23)
        Me.txtigndate.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 72)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 15)
        Me.Label17.TabIndex = 103
        Me.Label17.Text = "IGN Date :"
        '
        'txtpono
        '
        Me.txtpono.BackColor = System.Drawing.Color.White
        Me.txtpono.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtpono.Location = New System.Drawing.Point(90, 40)
        Me.txtpono.Name = "txtpono"
        Me.txtpono.ReadOnly = True
        Me.txtpono.Size = New System.Drawing.Size(158, 23)
        Me.txtpono.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 15)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "PO No :"
        '
        'IGNTagging
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(895, 527)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "IGNTagging"
        Me.Text = "IM - Transactions - Goods Return Notes"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintPreviewDialog2 As PrintPreviewDialog
    Friend WithEvents Label16 As Label
    Private WithEvents cbign As SergeUtils.EasyCompletionComboBox
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
    Private WithEvents CBSplr As SergeUtils.EasyCompletionComboBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtignchrgs As TextBox
    Friend WithEvents txtignnet As TextBox
    Friend WithEvents ChbBind As DataGridViewCheckBoxColumn
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents JVNo As DataGridViewTextBoxColumn
    Friend WithEvents Narration As DataGridViewTextBoxColumn
    Friend WithEvents Type As DataGridViewTextBoxColumn
    Friend WithEvents Crncy As DataGridViewTextBoxColumn
    Friend WithEvents Amnt As DataGridViewTextBoxColumn
    Friend WithEvents IGN As DataGridViewTextBoxColumn
End Class
