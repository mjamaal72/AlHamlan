<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class POIGNStatus
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbsuplr = New SergeUtils.EasyCompletionComboBox()
        Me.cbdiv = New SergeUtils.EasyCompletionComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.SDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Div = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Supplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Crn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Net = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbNPstd = New System.Windows.Forms.RadioButton()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.rbPstd = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbIGNs = New System.Windows.Forms.RadioButton()
        Me.rbPOs = New System.Windows.Forms.RadioButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(930, 37)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "PO\IGN Status"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(807, 48)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(123, 27)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Statement"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Button4.Location = New System.Drawing.Point(807, 79)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(123, 27)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "Print"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(2, 50)
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
        Me.dtpFDate.Location = New System.Drawing.Point(71, 46)
        Me.dtpFDate.Name = "dtpFDate"
        Me.dtpFDate.Size = New System.Drawing.Size(158, 23)
        Me.dtpFDate.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 80)
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
        Me.dtpToDate.Location = New System.Drawing.Point(71, 76)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(158, 23)
        Me.dtpToDate.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(235, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 15)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "Supplier :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(235, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 15)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Division :"
        '
        'cbsuplr
        '
        Me.cbsuplr.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbsuplr.FormattingEnabled = True
        Me.cbsuplr.Location = New System.Drawing.Point(296, 77)
        Me.cbsuplr.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbsuplr.Name = "cbsuplr"
        Me.cbsuplr.Size = New System.Drawing.Size(326, 23)
        Me.cbsuplr.TabIndex = 3
        '
        'cbdiv
        '
        Me.cbdiv.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbdiv.FormattingEnabled = True
        Me.cbdiv.Location = New System.Drawing.Point(296, 47)
        Me.cbdiv.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbdiv.Name = "cbdiv"
        Me.cbdiv.Size = New System.Drawing.Size(169, 23)
        Me.cbdiv.TabIndex = 2
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.SDate, Me.Div, Me.Supplier, Me.Crn, Me.Net, Me.Mode})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Location = New System.Drawing.Point(4, 112)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.Size = New System.Drawing.Size(926, 602)
        Me.DataGridView1.TabIndex = 8
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Width = 70
        '
        'SDate
        '
        Me.SDate.DataPropertyName = "DT"
        DataGridViewCellStyle2.Format = "dd-MMM-yyyy"
        Me.SDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.SDate.HeaderText = "Date"
        Me.SDate.Name = "SDate"
        Me.SDate.ReadOnly = True
        Me.SDate.Width = 110
        '
        'Div
        '
        Me.Div.DataPropertyName = "DIV"
        Me.Div.HeaderText = "Div"
        Me.Div.Name = "Div"
        Me.Div.ReadOnly = True
        Me.Div.Width = 60
        '
        'Supplier
        '
        Me.Supplier.DataPropertyName = "SPLR"
        Me.Supplier.HeaderText = "Supplier"
        Me.Supplier.Name = "Supplier"
        Me.Supplier.ReadOnly = True
        Me.Supplier.Width = 410
        '
        'Crn
        '
        Me.Crn.DataPropertyName = "CRN"
        Me.Crn.HeaderText = "Crn"
        Me.Crn.Name = "Crn"
        Me.Crn.ReadOnly = True
        Me.Crn.Width = 60
        '
        'Net
        '
        Me.Net.DataPropertyName = "NET"
        Me.Net.HeaderText = "Net"
        Me.Net.Name = "Net"
        Me.Net.ReadOnly = True
        Me.Net.Width = 120
        '
        'Mode
        '
        Me.Mode.DataPropertyName = "PSTD"
        Me.Mode.HeaderText = "Pstd"
        Me.Mode.Name = "Mode"
        Me.Mode.ReadOnly = True
        Me.Mode.Width = 60
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.rbNPstd)
        Me.Panel1.Controls.Add(Me.rbAll)
        Me.Panel1.Controls.Add(Me.rbPstd)
        Me.Panel1.Location = New System.Drawing.Point(625, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(90, 72)
        Me.Panel1.TabIndex = 4
        '
        'rbNPstd
        '
        Me.rbNPstd.AutoSize = True
        Me.rbNPstd.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.rbNPstd.Location = New System.Drawing.Point(2, 26)
        Me.rbNPstd.Name = "rbNPstd"
        Me.rbNPstd.Size = New System.Drawing.Size(84, 19)
        Me.rbNPstd.TabIndex = 1
        Me.rbNPstd.Text = "Not Posted"
        Me.rbNPstd.UseVisualStyleBackColor = True
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Checked = True
        Me.rbAll.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.rbAll.Location = New System.Drawing.Point(2, 51)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(40, 19)
        Me.rbAll.TabIndex = 2
        Me.rbAll.TabStop = True
        Me.rbAll.Text = "All"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'rbPstd
        '
        Me.rbPstd.AutoSize = True
        Me.rbPstd.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.rbPstd.Location = New System.Drawing.Point(2, 1)
        Me.rbPstd.Name = "rbPstd"
        Me.rbPstd.Size = New System.Drawing.Size(62, 19)
        Me.rbPstd.TabIndex = 0
        Me.rbPstd.Text = "Posted"
        Me.rbPstd.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.rbIGNs)
        Me.Panel2.Controls.Add(Me.rbPOs)
        Me.Panel2.Location = New System.Drawing.Point(715, 38)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(90, 72)
        Me.Panel2.TabIndex = 5
        '
        'rbIGNs
        '
        Me.rbIGNs.AutoSize = True
        Me.rbIGNs.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.rbIGNs.Location = New System.Drawing.Point(7, 38)
        Me.rbIGNs.Name = "rbIGNs"
        Me.rbIGNs.Size = New System.Drawing.Size(54, 19)
        Me.rbIGNs.TabIndex = 1
        Me.rbIGNs.Text = "IGN's"
        Me.rbIGNs.UseVisualStyleBackColor = True
        '
        'rbPOs
        '
        Me.rbPOs.AutoSize = True
        Me.rbPOs.Checked = True
        Me.rbPOs.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.rbPOs.Location = New System.Drawing.Point(7, 13)
        Me.rbPOs.Name = "rbPOs"
        Me.rbPOs.Size = New System.Drawing.Size(50, 19)
        Me.rbPOs.TabIndex = 0
        Me.rbPOs.TabStop = True
        Me.rbPOs.Text = "PO's"
        Me.rbPOs.UseVisualStyleBackColor = True
        '
        'POIGNStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 717)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cbdiv)
        Me.Controls.Add(Me.cbsuplr)
        Me.Controls.Add(Me.Label3)
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
        Me.Name = "POIGNStatus"
        Me.Text = "PO\IGN Status"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
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
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Private WithEvents cbsuplr As SergeUtils.EasyCompletionComboBox
    Private WithEvents cbdiv As SergeUtils.EasyCompletionComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rbNPstd As RadioButton
    Friend WithEvents rbAll As RadioButton
    Friend WithEvents rbPstd As RadioButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rbIGNs As RadioButton
    Friend WithEvents rbPOs As RadioButton
    Friend WithEvents ID As DataGridViewLinkColumn
    Friend WithEvents SDate As DataGridViewTextBoxColumn
    Friend WithEvents Div As DataGridViewTextBoxColumn
    Friend WithEvents Supplier As DataGridViewTextBoxColumn
    Friend WithEvents Crn As DataGridViewTextBoxColumn
    Friend WithEvents Net As DataGridViewTextBoxColumn
    Friend WithEvents Mode As DataGridViewTextBoxColumn
End Class
