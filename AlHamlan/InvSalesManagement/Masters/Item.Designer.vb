<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Item
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Item))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chbactive = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintPreviewDialog2 = New System.Windows.Forms.PrintPreviewDialog()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.chbhold = New System.Windows.Forms.CheckBox()
        Me.txticode = New System.Windows.Forms.TextBox()
        Me.txtiname = New System.Windows.Forms.TextBox()
        Me.cbdiv = New SergeUtils.EasyCompletionComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbpromo = New System.Windows.Forms.RadioButton()
        Me.rbreg = New System.Windows.Forms.RadioButton()
        Me.txtpack = New System.Windows.Forms.TextBox()
        Me.txtwght = New System.Windows.Forms.TextBox()
        Me.cbuom = New SergeUtils.EasyCompletionComboBox()
        Me.txtuvalue = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtoqty = New System.Windows.Forms.TextBox()
        Me.cbcrncy = New SergeUtils.EasyCompletionComboBox()
        Me.cbshiptrm = New SergeUtils.EasyCompletionComboBox()
        Me.txtcp = New System.Windows.Forms.TextBox()
        Me.txtpp = New System.Windows.Forms.TextBox()
        Me.txtcost = New System.Windows.Forms.TextBox()
        Me.txtsp = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Size = New System.Drawing.Size(820, 217)
        Me.DataGridView1.TabIndex = 24
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
        Me.Label1.Text = "Master - Item"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 292)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Item Code :"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 322)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Division :"
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 408)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 15)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Open Cost :"
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(636, 408)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Selling Price :"
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(464, 408)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 15)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Cost :"
        '
        'Label11
        '
        Me.Label11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(214, 408)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 15)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Purchase Price :"
        '
        'Label12
        '
        Me.Label12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(165, 379)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 15)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Currency :"
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(294, 322)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 15)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Type :"
        '
        'chbactive
        '
        Me.chbactive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbactive.AutoSize = True
        Me.chbactive.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbactive.Location = New System.Drawing.Point(650, 324)
        Me.chbactive.Name = "chbactive"
        Me.chbactive.Size = New System.Drawing.Size(15, 14)
        Me.chbactive.TabIndex = 6
        Me.chbactive.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(9, 434)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(268, 30)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "Add New Item"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(684, 37)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(143, 28)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "Search"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox12
        '
        Me.TextBox12.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox12.Location = New System.Drawing.Point(539, 38)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(143, 27)
        Me.TextBox12.TabIndex = 22
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(283, 434)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(268, 30)
        Me.Button3.TabIndex = 20
        Me.Button3.Text = "Update N Print Grid"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(556, 434)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(268, 30)
        Me.Button4.TabIndex = 21
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
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 379)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 15)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Open Qty :"
        '
        'Label16
        '
        Me.Label16.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(203, 292)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(71, 15)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Item Name :"
        '
        'Label17
        '
        Me.Label17.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 350)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 15)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Pack :"
        '
        'Label18
        '
        Me.Label18.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(165, 350)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(105, 15)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Weight Per Piece :"
        '
        'Label20
        '
        Me.Label20.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(362, 350)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(130, 15)
        Me.Label20.TabIndex = 37
        Me.Label20.Text = "Unit Of Measurement :"
        '
        'Label21
        '
        Me.Label21.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(598, 323)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(45, 15)
        Me.Label21.TabIndex = 38
        Me.Label21.Text = "Active :"
        '
        'Label22
        '
        Me.Label22.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(687, 324)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(58, 15)
        Me.Label22.TabIndex = 39
        Me.Label22.Text = "On Hold :"
        '
        'Label24
        '
        Me.Label24.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(465, 379)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(72, 15)
        Me.Label24.TabIndex = 41
        Me.Label24.Text = "Ship Terms :"
        '
        'chbhold
        '
        Me.chbhold.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbhold.AutoSize = True
        Me.chbhold.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbhold.Location = New System.Drawing.Point(751, 324)
        Me.chbhold.Name = "chbhold"
        Me.chbhold.Size = New System.Drawing.Size(15, 14)
        Me.chbhold.TabIndex = 7
        Me.chbhold.UseVisualStyleBackColor = True
        '
        'txticode
        '
        Me.txticode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txticode.BackColor = System.Drawing.Color.White
        Me.txticode.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txticode.Location = New System.Drawing.Point(79, 289)
        Me.txticode.Name = "txticode"
        Me.txticode.Size = New System.Drawing.Size(100, 23)
        Me.txticode.TabIndex = 0
        '
        'txtiname
        '
        Me.txtiname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtiname.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtiname.Location = New System.Drawing.Point(280, 289)
        Me.txtiname.Name = "txtiname"
        Me.txtiname.Size = New System.Drawing.Size(544, 23)
        Me.txtiname.TabIndex = 1
        '
        'cbdiv
        '
        Me.cbdiv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbdiv.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbdiv.FormattingEnabled = True
        Me.cbdiv.Location = New System.Drawing.Point(80, 318)
        Me.cbdiv.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbdiv.Name = "cbdiv"
        Me.cbdiv.Size = New System.Drawing.Size(195, 23)
        Me.cbdiv.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.rbpromo)
        Me.Panel1.Controls.Add(Me.rbreg)
        Me.Panel1.Location = New System.Drawing.Point(367, 320)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(195, 22)
        Me.Panel1.TabIndex = 5
        '
        'rbpromo
        '
        Me.rbpromo.AutoSize = True
        Me.rbpromo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbpromo.Location = New System.Drawing.Point(110, 1)
        Me.rbpromo.Name = "rbpromo"
        Me.rbpromo.Size = New System.Drawing.Size(82, 19)
        Me.rbpromo.TabIndex = 1
        Me.rbpromo.TabStop = True
        Me.rbpromo.Text = "Promotion"
        Me.rbpromo.UseVisualStyleBackColor = True
        '
        'rbreg
        '
        Me.rbreg.AutoSize = True
        Me.rbreg.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbreg.Location = New System.Drawing.Point(4, 1)
        Me.rbreg.Name = "rbreg"
        Me.rbreg.Size = New System.Drawing.Size(67, 19)
        Me.rbreg.TabIndex = 0
        Me.rbreg.TabStop = True
        Me.rbreg.Text = "Regular"
        Me.rbreg.UseVisualStyleBackColor = True
        '
        'txtpack
        '
        Me.txtpack.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtpack.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtpack.Location = New System.Drawing.Point(80, 347)
        Me.txtpack.Name = "txtpack"
        Me.txtpack.Size = New System.Drawing.Size(69, 23)
        Me.txtpack.TabIndex = 8
        '
        'txtwght
        '
        Me.txtwght.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtwght.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtwght.Location = New System.Drawing.Point(280, 347)
        Me.txtwght.Name = "txtwght"
        Me.txtwght.Size = New System.Drawing.Size(69, 23)
        Me.txtwght.TabIndex = 9
        '
        'cbuom
        '
        Me.cbuom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbuom.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbuom.FormattingEnabled = True
        Me.cbuom.Location = New System.Drawing.Point(498, 347)
        Me.cbuom.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbuom.Name = "cbuom"
        Me.cbuom.Size = New System.Drawing.Size(129, 23)
        Me.cbuom.TabIndex = 10
        '
        'txtuvalue
        '
        Me.txtuvalue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtuvalue.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtuvalue.Location = New System.Drawing.Point(725, 347)
        Me.txtuvalue.Name = "txtuvalue"
        Me.txtuvalue.Size = New System.Drawing.Size(100, 23)
        Me.txtuvalue.TabIndex = 11
        '
        'Label19
        '
        Me.Label19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(648, 350)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 15)
        Me.Label19.TabIndex = 54
        Me.Label19.Text = "Unit Value :"
        '
        'txtoqty
        '
        Me.txtoqty.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtoqty.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtoqty.Location = New System.Drawing.Point(80, 376)
        Me.txtoqty.Name = "txtoqty"
        Me.txtoqty.Size = New System.Drawing.Size(69, 23)
        Me.txtoqty.TabIndex = 12
        '
        'cbcrncy
        '
        Me.cbcrncy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbcrncy.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbcrncy.FormattingEnabled = True
        Me.cbcrncy.Location = New System.Drawing.Point(233, 376)
        Me.cbcrncy.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbcrncy.Name = "cbcrncy"
        Me.cbcrncy.Size = New System.Drawing.Size(211, 23)
        Me.cbcrncy.TabIndex = 13
        Me.cbcrncy.Tag = ""
        '
        'cbshiptrm
        '
        Me.cbshiptrm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbshiptrm.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbshiptrm.FormattingEnabled = True
        Me.cbshiptrm.Location = New System.Drawing.Point(540, 376)
        Me.cbshiptrm.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbshiptrm.Name = "cbshiptrm"
        Me.cbshiptrm.Size = New System.Drawing.Size(285, 23)
        Me.cbshiptrm.TabIndex = 14
        '
        'txtcp
        '
        Me.txtcp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtcp.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtcp.Location = New System.Drawing.Point(80, 405)
        Me.txtcp.Name = "txtcp"
        Me.txtcp.Size = New System.Drawing.Size(100, 23)
        Me.txtcp.TabIndex = 15
        '
        'txtpp
        '
        Me.txtpp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtpp.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtpp.Location = New System.Drawing.Point(315, 405)
        Me.txtpp.Name = "txtpp"
        Me.txtpp.Size = New System.Drawing.Size(100, 23)
        Me.txtpp.TabIndex = 16
        '
        'txtcost
        '
        Me.txtcost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtcost.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtcost.Location = New System.Drawing.Point(507, 405)
        Me.txtcost.Name = "txtcost"
        Me.txtcost.Size = New System.Drawing.Size(100, 23)
        Me.txtcost.TabIndex = 17
        '
        'txtsp
        '
        Me.txtsp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtsp.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtsp.Location = New System.Drawing.Point(725, 405)
        Me.txtsp.Name = "txtsp"
        Me.txtsp.Size = New System.Drawing.Size(100, 23)
        Me.txtsp.TabIndex = 18
        '
        'Item
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 463)
        Me.Controls.Add(Me.txtsp)
        Me.Controls.Add(Me.txtcost)
        Me.Controls.Add(Me.txtpp)
        Me.Controls.Add(Me.txtcp)
        Me.Controls.Add(Me.cbshiptrm)
        Me.Controls.Add(Me.cbcrncy)
        Me.Controls.Add(Me.txtoqty)
        Me.Controls.Add(Me.txtuvalue)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cbuom)
        Me.Controls.Add(Me.txtwght)
        Me.Controls.Add(Me.txtpack)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cbdiv)
        Me.Controls.Add(Me.txtiname)
        Me.Controls.Add(Me.txticode)
        Me.Controls.Add(Me.chbhold)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox12)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.chbactive)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Item"
        Me.Text = "IM - Master - Item"
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
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents chbactive As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintPreviewDialog2 As PrintPreviewDialog
    Friend WithEvents Label9 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents chbhold As CheckBox
    Friend WithEvents txticode As TextBox
    Friend WithEvents txtiname As TextBox
    Private WithEvents cbdiv As SergeUtils.EasyCompletionComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rbpromo As RadioButton
    Friend WithEvents rbreg As RadioButton
    Friend WithEvents txtpack As TextBox
    Friend WithEvents txtwght As TextBox
    Private WithEvents cbuom As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtuvalue As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtoqty As TextBox
    Private WithEvents cbcrncy As SergeUtils.EasyCompletionComboBox
    Private WithEvents cbshiptrm As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtcp As TextBox
    Friend WithEvents txtpp As TextBox
    Friend WithEvents txtcost As TextBox
    Friend WithEvents txtsp As TextBox
End Class
