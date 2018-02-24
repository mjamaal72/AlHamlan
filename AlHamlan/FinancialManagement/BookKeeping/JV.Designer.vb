<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class JV
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JV))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtjvno = New System.Windows.Forms.TextBox()
        Me.txtnotes = New System.Windows.Forms.TextBox()
        Me.cbcrncy = New SergeUtils.EasyCompletionComboBox()
        Me.dtpjvdate = New System.Windows.Forms.DateTimePicker()
        Me.chbposted = New System.Windows.Forms.CheckBox()
        Me.txtdebit = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtdiff = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtcredit = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbldtls = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.txtvid = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
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
        Me.Label1.Size = New System.Drawing.Size(1046, 37)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Journal Vouchers"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(4, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 19)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "JV No. :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label12.Location = New System.Drawing.Point(502, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 19)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Currency :"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(116, 561)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(268, 30)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Add New JV"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(791, 38)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(248, 31)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Search JV"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(390, 561)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(268, 30)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Print Grid"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(663, 561)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(268, 30)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Exit Form"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label16.Location = New System.Drawing.Point(4, 38)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 19)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Notes :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label18.Location = New System.Drawing.Point(230, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 19)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Date :"
        '
        'txtjvno
        '
        Me.txtjvno.BackColor = System.Drawing.Color.White
        Me.txtjvno.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtjvno.Location = New System.Drawing.Point(71, 6)
        Me.txtjvno.Name = "txtjvno"
        Me.txtjvno.ReadOnly = True
        Me.txtjvno.Size = New System.Drawing.Size(100, 26)
        Me.txtjvno.TabIndex = 10000
        '
        'txtnotes
        '
        Me.txtnotes.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtnotes.Location = New System.Drawing.Point(71, 35)
        Me.txtnotes.Name = "txtnotes"
        Me.txtnotes.Size = New System.Drawing.Size(966, 26)
        Me.txtnotes.TabIndex = 4
        '
        'cbcrncy
        '
        Me.cbcrncy.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.cbcrncy.FormattingEnabled = True
        Me.cbcrncy.Location = New System.Drawing.Point(575, 6)
        Me.cbcrncy.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbcrncy.Name = "cbcrncy"
        Me.cbcrncy.Size = New System.Drawing.Size(148, 27)
        Me.cbcrncy.TabIndex = 3
        Me.cbcrncy.Tag = ""
        '
        'dtpjvdate
        '
        Me.dtpjvdate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpjvdate.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.dtpjvdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpjvdate.Location = New System.Drawing.Point(279, 6)
        Me.dtpjvdate.Name = "dtpjvdate"
        Me.dtpjvdate.Size = New System.Drawing.Size(148, 26)
        Me.dtpjvdate.TabIndex = 2
        '
        'chbposted
        '
        Me.chbposted.AutoSize = True
        Me.chbposted.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.chbposted.Location = New System.Drawing.Point(892, 83)
        Me.chbposted.Name = "chbposted"
        Me.chbposted.Size = New System.Drawing.Size(70, 23)
        Me.chbposted.TabIndex = 1
        Me.chbposted.Text = "Posted"
        Me.chbposted.UseVisualStyleBackColor = True
        '
        'txtdebit
        '
        Me.txtdebit.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtdebit.Location = New System.Drawing.Point(600, 450)
        Me.txtdebit.Name = "txtdebit"
        Me.txtdebit.Size = New System.Drawing.Size(80, 26)
        Me.txtdebit.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label7.Location = New System.Drawing.Point(547, 453)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 19)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Debit :"
        '
        'txtdiff
        '
        Me.txtdiff.BackColor = System.Drawing.Color.White
        Me.txtdiff.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtdiff.Location = New System.Drawing.Point(957, 450)
        Me.txtdiff.Name = "txtdiff"
        Me.txtdiff.ReadOnly = True
        Me.txtdiff.Size = New System.Drawing.Size(80, 26)
        Me.txtdiff.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label9.Location = New System.Drawing.Point(879, 453)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 19)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "Difference :"
        '
        'txtcredit
        '
        Me.txtcredit.BackColor = System.Drawing.Color.White
        Me.txtcredit.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtcredit.Location = New System.Drawing.Point(770, 450)
        Me.txtcredit.Name = "txtcredit"
        Me.txtcredit.ReadOnly = True
        Me.txtcredit.Size = New System.Drawing.Size(80, 26)
        Me.txtcredit.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label10.Location = New System.Drawing.Point(715, 453)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 19)
        Me.Label10.TabIndex = 86
        Me.Label10.Text = "Credit :"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lbldtls)
        Me.Panel1.Controls.Add(Me.txtcredit)
        Me.Panel1.Controls.Add(Me.txtdiff)
        Me.Panel1.Controls.Add(Me.txtnotes)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtjvno)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtdebit)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.cbcrncy)
        Me.Panel1.Controls.Add(Me.dtpjvdate)
        Me.Panel1.Location = New System.Drawing.Point(1, 74)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1045, 481)
        Me.Panel1.TabIndex = 0
        '
        'lbldtls
        '
        Me.lbldtls.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldtls.ForeColor = System.Drawing.Color.Blue
        Me.lbldtls.Location = New System.Drawing.Point(10, 453)
        Me.lbldtls.Name = "lbldtls"
        Me.lbldtls.Size = New System.Drawing.Size(500, 19)
        Me.lbldtls.TabIndex = 87
        Me.lbldtls.Text = "Description for Selected Cell"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 141)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.Size = New System.Drawing.Size(1033, 378)
        Me.DataGridView1.TabIndex = 2
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
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(0, 38)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(268, 30)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "Clear Selection"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'txtvid
        '
        Me.txtvid.BackColor = System.Drawing.Color.White
        Me.txtvid.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.txtvid.Location = New System.Drawing.Point(329, 42)
        Me.txtvid.Name = "txtvid"
        Me.txtvid.ReadOnly = True
        Me.txtvid.Size = New System.Drawing.Size(100, 26)
        Me.txtvid.TabIndex = 88
        Me.txtvid.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'JV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1046, 592)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtvid)
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
        Me.Name = "JV"
        Me.Text = "FM - Book Keeping - Journal Vouchers"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtjvno As TextBox
    Friend WithEvents txtnotes As TextBox
    Private WithEvents cbcrncy As SergeUtils.EasyCompletionComboBox
    Friend WithEvents dtpjvdate As DateTimePicker
    Friend WithEvents chbposted As CheckBox
    Friend WithEvents txtdebit As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtdiff As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtcredit As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents Button5 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtvid As TextBox
    Friend WithEvents lbldtls As Label
    Friend WithEvents Timer1 As Timer
End Class
