<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StockNSales
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbitem = New SergeUtils.EasyCompletionComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Opening = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Receives = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Sales = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Returns = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Closing = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Enroute = New System.Windows.Forms.DataGridViewLinkColumn()
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
        Me.Label1.Size = New System.Drawing.Size(1030, 37)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Stock and Sales"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(794, 44)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(236, 27)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Statement"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Button4.Location = New System.Drawing.Point(794, 74)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(236, 27)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "Print"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(22, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 15)
        Me.Label11.TabIndex = 94
        Me.Label11.Text = "From Date :"
        '
        'dtpFDate
        '
        Me.dtpFDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpFDate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFDate.Location = New System.Drawing.Point(91, 45)
        Me.dtpFDate.Name = "dtpFDate"
        Me.dtpFDate.Size = New System.Drawing.Size(158, 23)
        Me.dtpFDate.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 15)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "To Date :"
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpToDate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(91, 75)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(158, 23)
        Me.dtpToDate.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(270, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 15)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Item :"
        '
        'cbitem
        '
        Me.cbitem.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbitem.FormattingEnabled = True
        Me.cbitem.Location = New System.Drawing.Point(313, 60)
        Me.cbitem.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbitem.Name = "cbitem"
        Me.cbitem.Size = New System.Drawing.Size(455, 23)
        Me.cbitem.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Code, Me.ItemName, Me.Opening, Me.Receives, Me.Sales, Me.Returns, Me.Closing, Me.Enroute})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView1.Location = New System.Drawing.Point(4, 112)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.Size = New System.Drawing.Size(1026, 602)
        Me.DataGridView1.TabIndex = 8
        '
        'Code
        '
        Me.Code.DataPropertyName = "Code"
        Me.Code.HeaderText = "Code"
        Me.Code.Name = "Code"
        Me.Code.ReadOnly = True
        '
        'ItemName
        '
        Me.ItemName.DataPropertyName = "ItemName"
        Me.ItemName.HeaderText = "ItemName"
        Me.ItemName.Name = "ItemName"
        Me.ItemName.ReadOnly = True
        Me.ItemName.Width = 300
        '
        'Opening
        '
        Me.Opening.DataPropertyName = "Opening"
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Opening.DefaultCellStyle = DataGridViewCellStyle2
        Me.Opening.HeaderText = "Opening"
        Me.Opening.Name = "Opening"
        Me.Opening.ReadOnly = True
        '
        'Receives
        '
        Me.Receives.DataPropertyName = "Receives"
        DataGridViewCellStyle3.Format = "N0"
        Me.Receives.DefaultCellStyle = DataGridViewCellStyle3
        Me.Receives.HeaderText = "Receives"
        Me.Receives.Name = "Receives"
        Me.Receives.ReadOnly = True
        '
        'Sales
        '
        Me.Sales.DataPropertyName = "Sales"
        DataGridViewCellStyle4.Format = "N0"
        Me.Sales.DefaultCellStyle = DataGridViewCellStyle4
        Me.Sales.HeaderText = "Sales"
        Me.Sales.Name = "Sales"
        Me.Sales.ReadOnly = True
        '
        'Returns
        '
        Me.Returns.DataPropertyName = "Returns"
        DataGridViewCellStyle5.Format = "N0"
        Me.Returns.DefaultCellStyle = DataGridViewCellStyle5
        Me.Returns.HeaderText = "Returns"
        Me.Returns.Name = "Returns"
        Me.Returns.ReadOnly = True
        '
        'Closing
        '
        Me.Closing.DataPropertyName = "Closing"
        DataGridViewCellStyle6.Format = "N0"
        Me.Closing.DefaultCellStyle = DataGridViewCellStyle6
        Me.Closing.HeaderText = "Closing"
        Me.Closing.Name = "Closing"
        Me.Closing.ReadOnly = True
        '
        'Enroute
        '
        Me.Enroute.DataPropertyName = "Enroute"
        DataGridViewCellStyle7.Format = "N0"
        Me.Enroute.DefaultCellStyle = DataGridViewCellStyle7
        Me.Enroute.HeaderText = "Enroute"
        Me.Enroute.Name = "Enroute"
        Me.Enroute.ReadOnly = True
        '
        'StockNSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 717)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cbitem)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dtpFDate)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "StockNSales"
        Me.Text = "Stock and Sales"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Label11 As Label
    Friend WithEvents dtpFDate As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents Label4 As Label
    Private WithEvents cbitem As SergeUtils.EasyCompletionComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Code As DataGridViewTextBoxColumn
    Friend WithEvents ItemName As DataGridViewTextBoxColumn
    Friend WithEvents Opening As DataGridViewTextBoxColumn
    Friend WithEvents Receives As DataGridViewLinkColumn
    Friend WithEvents Sales As DataGridViewLinkColumn
    Friend WithEvents Returns As DataGridViewLinkColumn
    Friend WithEvents Closing As DataGridViewTextBoxColumn
    Friend WithEvents Enroute As DataGridViewLinkColumn
End Class
