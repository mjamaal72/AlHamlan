<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ShipStatus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ShipStatus))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbsuplr = New SergeUtils.EasyCompletionComboBox()
        Me.cbdiv = New SergeUtils.EasyCompletionComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.SDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PONo = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Supplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Div = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Terms = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Crn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Net = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.Label1.Size = New System.Drawing.Size(930, 37)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Shipment Status"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(741, 54)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(189, 27)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Statement"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Button4.Location = New System.Drawing.Point(741, 91)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(189, 27)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Print"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 66)
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
        Me.dtpFDate.Location = New System.Drawing.Point(87, 62)
        Me.dtpFDate.Name = "dtpFDate"
        Me.dtpFDate.Size = New System.Drawing.Size(158, 23)
        Me.dtpFDate.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 97)
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
        Me.dtpToDate.Location = New System.Drawing.Point(87, 93)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(158, 23)
        Me.dtpToDate.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(267, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 15)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "Supplier :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(267, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 15)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Division :"
        '
        'cbsuplr
        '
        Me.cbsuplr.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbsuplr.FormattingEnabled = True
        Me.cbsuplr.Location = New System.Drawing.Point(332, 94)
        Me.cbsuplr.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbsuplr.Name = "cbsuplr"
        Me.cbsuplr.Size = New System.Drawing.Size(331, 23)
        Me.cbsuplr.TabIndex = 3
        '
        'cbdiv
        '
        Me.cbdiv.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbdiv.FormattingEnabled = True
        Me.cbdiv.Location = New System.Drawing.Point(332, 63)
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SDate, Me.ADate, Me.PONo, Me.Supplier, Me.Div, Me.Terms, Me.Mode, Me.Crn, Me.Net})
        Me.DataGridView1.Location = New System.Drawing.Point(4, 134)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.Size = New System.Drawing.Size(926, 580)
        Me.DataGridView1.TabIndex = 6
        '
        'SDate
        '
        Me.SDate.DataPropertyName = "PUR_SHIP_DATE"
        DataGridViewCellStyle2.Format = "dd-MMM-yyyy"
        Me.SDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.SDate.HeaderText = "Shipment"
        Me.SDate.Name = "SDate"
        Me.SDate.ReadOnly = True
        '
        'ADate
        '
        Me.ADate.DataPropertyName = "PUR_ARR_DATE"
        DataGridViewCellStyle3.Format = "dd-MMM-yyyy"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.ADate.DefaultCellStyle = DataGridViewCellStyle3
        Me.ADate.HeaderText = "Arrival"
        Me.ADate.Name = "ADate"
        Me.ADate.ReadOnly = True
        '
        'PONo
        '
        Me.PONo.DataPropertyName = "PUR_ORDER_NO"
        Me.PONo.HeaderText = "PO"
        Me.PONo.Name = "PONo"
        Me.PONo.ReadOnly = True
        Me.PONo.Width = 70
        '
        'Supplier
        '
        Me.Supplier.DataPropertyName = "SL_NAME"
        Me.Supplier.HeaderText = "Supplier"
        Me.Supplier.Name = "Supplier"
        Me.Supplier.ReadOnly = True
        Me.Supplier.Width = 290
        '
        'Div
        '
        Me.Div.DataPropertyName = "PUR_DIV"
        Me.Div.HeaderText = "Div"
        Me.Div.Name = "Div"
        Me.Div.ReadOnly = True
        Me.Div.Width = 60
        '
        'Terms
        '
        Me.Terms.DataPropertyName = "PUR_SHIP_TERMS"
        Me.Terms.HeaderText = "Terms"
        Me.Terms.Name = "Terms"
        Me.Terms.ReadOnly = True
        Me.Terms.Width = 60
        '
        'Mode
        '
        Me.Mode.DataPropertyName = "PUR_PAY_TYPE"
        Me.Mode.HeaderText = "Mode"
        Me.Mode.Name = "Mode"
        Me.Mode.ReadOnly = True
        Me.Mode.Width = 60
        '
        'Crn
        '
        Me.Crn.DataPropertyName = "PUR_CUR_CODE"
        Me.Crn.HeaderText = "Crn"
        Me.Crn.Name = "Crn"
        Me.Crn.ReadOnly = True
        Me.Crn.Width = 60
        '
        'Net
        '
        Me.Net.DataPropertyName = "PUR_NET_VALUE"
        Me.Net.HeaderText = "Net"
        Me.Net.Name = "Net"
        Me.Net.ReadOnly = True
        '
        'ShipStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 717)
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
        Me.Name = "ShipStatus"
        Me.Text = "Supplier Statement"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents Label11 As Label
    Friend WithEvents dtpFDate As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Private WithEvents cbsuplr As SergeUtils.EasyCompletionComboBox
    Private WithEvents cbdiv As SergeUtils.EasyCompletionComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents SDate As DataGridViewTextBoxColumn
    Friend WithEvents ADate As DataGridViewTextBoxColumn
    Friend WithEvents PONo As DataGridViewLinkColumn
    Friend WithEvents Supplier As DataGridViewTextBoxColumn
    Friend WithEvents Div As DataGridViewTextBoxColumn
    Friend WithEvents Terms As DataGridViewTextBoxColumn
    Friend WithEvents Mode As DataGridViewTextBoxColumn
    Friend WithEvents Crn As DataGridViewTextBoxColumn
    Friend WithEvents Net As DataGridViewTextBoxColumn
End Class
