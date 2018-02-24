<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dashbrd
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
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title3 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title4 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.lblheader = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpFDate = New System.Windows.Forms.DateTimePicker()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Btn1 = New System.Windows.Forms.Button()
        Me.Btn2 = New System.Windows.Forms.Button()
        Me.Btn3 = New System.Windows.Forms.Button()
        Me.Btn4 = New System.Windows.Forms.Button()
        Me.Btn5 = New System.Windows.Forms.Button()
        Me.Btn6 = New System.Windows.Forms.Button()
        Me.Btn7 = New System.Windows.Forms.Button()
        Me.Btn8 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblheader
        '
        Me.lblheader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblheader.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblheader.Font = New System.Drawing.Font("Calibri", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheader.ForeColor = System.Drawing.Color.Blue
        Me.lblheader.Location = New System.Drawing.Point(0, 0)
        Me.lblheader.Name = "lblheader"
        Me.lblheader.Size = New System.Drawing.Size(1284, 37)
        Me.lblheader.TabIndex = 8
        Me.lblheader.Text = "Dashboard"
        Me.lblheader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel4)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel1)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel3)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel5)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 37)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1284, 702)
        Me.FlowLayoutPanel1.TabIndex = 9
        '
        'Panel4
        '
        Me.Panel4.AutoSize = True
        Me.Panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.dtpToDate)
        Me.Panel4.Controls.Add(Me.dtpFDate)
        Me.Panel4.Controls.Add(Me.FlowLayoutPanel2)
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(716, 224)
        Me.Panel4.TabIndex = 3
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpToDate.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(387, 3)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(158, 29)
        Me.dtpToDate.TabIndex = 10
        '
        'dtpFDate
        '
        Me.dtpFDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpFDate.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFDate.Location = New System.Drawing.Point(218, 3)
        Me.dtpFDate.Name = "dtpFDate"
        Me.dtpFDate.Size = New System.Drawing.Size(158, 29)
        Me.dtpFDate.TabIndex = 9
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel2.Controls.Add(Me.Btn1)
        Me.FlowLayoutPanel2.Controls.Add(Me.Btn2)
        Me.FlowLayoutPanel2.Controls.Add(Me.Btn3)
        Me.FlowLayoutPanel2.Controls.Add(Me.Btn4)
        Me.FlowLayoutPanel2.Controls.Add(Me.Btn5)
        Me.FlowLayoutPanel2.Controls.Add(Me.Btn6)
        Me.FlowLayoutPanel2.Controls.Add(Me.Btn7)
        Me.FlowLayoutPanel2.Controls.Add(Me.Btn8)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(-1, 49)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(1)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(522, 172)
        Me.FlowLayoutPanel2.TabIndex = 8
        '
        'Btn1
        '
        Me.Btn1.Font = New System.Drawing.Font("Times New Roman", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn1.Location = New System.Drawing.Point(3, 3)
        Me.Btn1.Name = "Btn1"
        Me.Btn1.Size = New System.Drawing.Size(255, 37)
        Me.Btn1.TabIndex = 2
        Me.Btn1.Tag = ""
        Me.Btn1.Text = "Button 1"
        Me.Btn1.UseVisualStyleBackColor = True
        '
        'Btn2
        '
        Me.Btn2.Font = New System.Drawing.Font("Times New Roman", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn2.Location = New System.Drawing.Point(264, 3)
        Me.Btn2.Name = "Btn2"
        Me.Btn2.Size = New System.Drawing.Size(255, 37)
        Me.Btn2.TabIndex = 3
        Me.Btn2.Text = "Button 1"
        Me.Btn2.UseVisualStyleBackColor = True
        '
        'Btn3
        '
        Me.Btn3.Font = New System.Drawing.Font("Times New Roman", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn3.Location = New System.Drawing.Point(3, 46)
        Me.Btn3.Name = "Btn3"
        Me.Btn3.Size = New System.Drawing.Size(255, 37)
        Me.Btn3.TabIndex = 4
        Me.Btn3.Text = "Button 1"
        Me.Btn3.UseVisualStyleBackColor = True
        '
        'Btn4
        '
        Me.Btn4.Font = New System.Drawing.Font("Times New Roman", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn4.Location = New System.Drawing.Point(264, 46)
        Me.Btn4.Name = "Btn4"
        Me.Btn4.Size = New System.Drawing.Size(255, 37)
        Me.Btn4.TabIndex = 5
        Me.Btn4.Text = "Button 1"
        Me.Btn4.UseVisualStyleBackColor = True
        '
        'Btn5
        '
        Me.Btn5.Font = New System.Drawing.Font("Times New Roman", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn5.Location = New System.Drawing.Point(3, 89)
        Me.Btn5.Name = "Btn5"
        Me.Btn5.Size = New System.Drawing.Size(255, 37)
        Me.Btn5.TabIndex = 6
        Me.Btn5.Text = "Button 1"
        Me.Btn5.UseVisualStyleBackColor = True
        '
        'Btn6
        '
        Me.Btn6.Font = New System.Drawing.Font("Times New Roman", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn6.Location = New System.Drawing.Point(264, 89)
        Me.Btn6.Name = "Btn6"
        Me.Btn6.Size = New System.Drawing.Size(255, 37)
        Me.Btn6.TabIndex = 7
        Me.Btn6.Text = "Button 1"
        Me.Btn6.UseVisualStyleBackColor = True
        '
        'Btn7
        '
        Me.Btn7.Font = New System.Drawing.Font("Times New Roman", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn7.Location = New System.Drawing.Point(3, 132)
        Me.Btn7.Name = "Btn7"
        Me.Btn7.Size = New System.Drawing.Size(255, 37)
        Me.Btn7.TabIndex = 9
        Me.Btn7.Text = "Button 1"
        Me.Btn7.UseVisualStyleBackColor = True
        '
        'Btn8
        '
        Me.Btn8.Font = New System.Drawing.Font("Times New Roman", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn8.Location = New System.Drawing.Point(264, 132)
        Me.Btn8.Name = "Btn8"
        Me.Btn8.Size = New System.Drawing.Size(255, 37)
        Me.Btn8.TabIndex = 8
        Me.Btn8.Text = "JV For Cash IGNs"
        Me.Btn8.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Button1.Location = New System.Drawing.Point(551, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(160, 30)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Refresh"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(7, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(205, 22)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Dashboard Date Range :"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Chart1)
        Me.Panel1.Location = New System.Drawing.Point(725, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(507, 339)
        Me.Panel1.TabIndex = 1
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Monthly POs Count", "Monthly IGNs Count", "Monthly Sales Count", "Monthly GRNs Count", "Monthly Vouchers Count", "Monthly Reciepts Count"})
        Me.ComboBox1.Location = New System.Drawing.Point(107, 5)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(394, 27)
        Me.ComboBox1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(4, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Count (ALL) :"
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        ChartArea3.AxisX.Interval = 1.0R
        ChartArea3.BackColor = System.Drawing.Color.AntiqueWhite
        ChartArea3.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea3)
        Me.Chart1.Location = New System.Drawing.Point(4, 35)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones
        Series3.ChartArea = "ChartArea1"
        Series3.Name = "Series1"
        Me.Chart1.Series.Add(Series3)
        Me.Chart1.Size = New System.Drawing.Size(498, 300)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        Title3.Font = New System.Drawing.Font("Times New Roman", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title3.ForeColor = System.Drawing.Color.Navy
        Title3.Name = "Title1"
        Title3.Text = "Monthly Sales"
        Me.Chart1.Titles.Add(Title3)
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.ComboBox2)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Chart2)
        Me.Panel2.Location = New System.Drawing.Point(3, 348)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(507, 339)
        Me.Panel2.TabIndex = 3
        '
        'ComboBox2
        '
        Me.ComboBox2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Monthly POs Value", "Monthly IGNs Value", "Monthly Sales Value", "Monthly GRNs Value", "Monthly Vouchers Debit Value", "Monthly Vouchers Credit Value", "Monthly Reciepts Value", "Monthly Payment Value", "Monthly Expenses Value"})
        Me.ComboBox2.Location = New System.Drawing.Point(180, 5)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(324, 27)
        Me.ComboBox2.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(4, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Valuation (Only Posted) :"
        '
        'Chart2
        '
        Me.Chart2.BackColor = System.Drawing.Color.DarkTurquoise
        ChartArea4.AxisX.Interval = 1.0R
        ChartArea4.BackColor = System.Drawing.Color.LightCyan
        ChartArea4.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea4)
        Me.Chart2.Location = New System.Drawing.Point(4, 35)
        Me.Chart2.Name = "Chart2"
        Series4.ChartArea = "ChartArea1"
        Series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar
        Series4.LabelAngle = 90
        Series4.Name = "Series1"
        Me.Chart2.Series.Add(Series4)
        Me.Chart2.Size = New System.Drawing.Size(500, 300)
        Me.Chart2.TabIndex = 0
        Me.Chart2.Text = "Chart2"
        Title4.Font = New System.Drawing.Font("Times New Roman", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title4.ForeColor = System.Drawing.Color.Navy
        Title4.Name = "Title1"
        Title4.Text = "Monthly Sales"
        Me.Chart2.Titles.Add(Title4)
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.DataGridView1)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.ComboBox3)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Location = New System.Drawing.Point(516, 348)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(507, 339)
        Me.Panel3.TabIndex = 4
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(3, 38)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(499, 298)
        Me.DataGridView1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(4, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Critical Listing for :"
        '
        'ComboBox3
        '
        Me.ComboBox3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"Items In Nagetive Stock", "Customer Pending Amount", "Supplier Pending Payment"})
        Me.ComboBox3.Location = New System.Drawing.Point(150, 5)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(255, 27)
        Me.ComboBox3.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Times New Roman", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(411, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(91, 27)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Print"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Button4)
        Me.Panel5.Controls.Add(Me.DataGridView2)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.ComboBox4)
        Me.Panel5.Controls.Add(Me.Button3)
        Me.Panel5.Location = New System.Drawing.Point(3, 693)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(507, 339)
        Me.Panel5.TabIndex = 5
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Times New Roman", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(412, 5)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(91, 27)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "Post All"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(3, 38)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(499, 298)
        Me.DataGridView2.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(4, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(170, 19)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Unposted Transactions :"
        '
        'ComboBox4
        '
        Me.ComboBox4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Items.AddRange(New Object() {"GRN", "IGN", "JV", "PO", "Proforma", "Sales", "Exception Cust Sales"})
        Me.ComboBox4.Location = New System.Drawing.Point(180, 5)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(155, 27)
        Me.ComboBox4.TabIndex = 1
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Times New Roman", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(341, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(70, 27)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Print"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Dashbrd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 739)
        Me.Controls.Add(Me.lblheader)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.MaximizeBox = False
        Me.Name = "Dashbrd"
        Me.Text = "Dashboard"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblheader As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents Panel3 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Btn5 As Button
    Friend WithEvents Btn4 As Button
    Friend WithEvents Btn3 As Button
    Friend WithEvents Btn2 As Button
    Friend WithEvents Btn1 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Btn6 As Button
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Btn8 As Button
    Friend WithEvents Btn7 As Button
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents dtpFDate As DateTimePicker
End Class
