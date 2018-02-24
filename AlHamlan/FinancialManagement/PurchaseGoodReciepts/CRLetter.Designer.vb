<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CRLetter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CRLetter))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintPreviewDialog2 = New System.Windows.Forms.PrintPreviewDialog()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtlccode = New System.Windows.Forms.TextBox()
        Me.txtbank = New System.Windows.Forms.TextBox()
        Me.cbsuplr = New SergeUtils.EasyCompletionComboBox()
        Me.cbpono = New SergeUtils.EasyCompletionComboBox()
        Me.txtlcterm = New System.Windows.Forms.TextBox()
        Me.txtamnt = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cbcrncy = New SergeUtils.EasyCompletionComboBox()
        Me.cbshiptrm = New SergeUtils.EasyCompletionComboBox()
        Me.txtdaprd = New System.Windows.Forms.TextBox()
        Me.dtplcdate = New System.Windows.Forms.DateTimePicker()
        Me.dtpexdate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtdtls = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtpshipdate = New System.Windows.Forms.DateTimePicker()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(820, 217)
        Me.DataGridView1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(832, 37)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Letter Of Credit"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 324)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "LC Code :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 382)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Beneficiary :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(556, 382)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "PO. No. :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(556, 411)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 15)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "DA Period :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(288, 353)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 15)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Currency :"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(7, 544)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(268, 30)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Add New LC"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(684, 37)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(143, 28)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Search"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox12
        '
        Me.TextBox12.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox12.Location = New System.Drawing.Point(539, 38)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(143, 27)
        Me.TextBox12.TabIndex = 16
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(281, 544)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(268, 30)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "Print Grid"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(554, 544)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(268, 30)
        Me.Button4.TabIndex = 15
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
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 353)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 15)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Bank :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(4, 440)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 30)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "LC Terms N" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Conditions :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(288, 324)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 15)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "LC Date :"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(241, 411)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(72, 15)
        Me.Label24.TabIndex = 41
        Me.Label24.Text = "Ship Terms :"
        '
        'txtlccode
        '
        Me.txtlccode.BackColor = System.Drawing.Color.White
        Me.txtlccode.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtlccode.Location = New System.Drawing.Point(82, 321)
        Me.txtlccode.Name = "txtlccode"
        Me.txtlccode.ReadOnly = True
        Me.txtlccode.Size = New System.Drawing.Size(100, 23)
        Me.txtlccode.TabIndex = 0
        '
        'txtbank
        '
        Me.txtbank.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtbank.Location = New System.Drawing.Point(82, 350)
        Me.txtbank.Name = "txtbank"
        Me.txtbank.Size = New System.Drawing.Size(182, 23)
        Me.txtbank.TabIndex = 3
        '
        'cbsuplr
        '
        Me.cbsuplr.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbsuplr.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbsuplr.FormattingEnabled = True
        Me.cbsuplr.Location = New System.Drawing.Point(82, 379)
        Me.cbsuplr.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbsuplr.Name = "cbsuplr"
        Me.cbsuplr.Size = New System.Drawing.Size(426, 23)
        Me.cbsuplr.TabIndex = 6
        '
        'cbpono
        '
        Me.cbpono.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbpono.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbpono.FormattingEnabled = True
        Me.cbpono.Location = New System.Drawing.Point(652, 379)
        Me.cbpono.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbpono.Name = "cbpono"
        Me.cbpono.Size = New System.Drawing.Size(175, 23)
        Me.cbpono.TabIndex = 7
        '
        'txtlcterm
        '
        Me.txtlcterm.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtlcterm.Location = New System.Drawing.Point(82, 437)
        Me.txtlcterm.Multiline = True
        Me.txtlcterm.Name = "txtlcterm"
        Me.txtlcterm.Size = New System.Drawing.Size(315, 99)
        Me.txtlcterm.TabIndex = 11
        '
        'txtamnt
        '
        Me.txtamnt.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtamnt.Location = New System.Drawing.Point(652, 350)
        Me.txtamnt.Name = "txtamnt"
        Me.txtamnt.Size = New System.Drawing.Size(175, 23)
        Me.txtamnt.TabIndex = 5
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(556, 353)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 15)
        Me.Label19.TabIndex = 54
        Me.Label19.Text = "Amount :"
        '
        'cbcrncy
        '
        Me.cbcrncy.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbcrncy.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbcrncy.FormattingEnabled = True
        Me.cbcrncy.Location = New System.Drawing.Point(360, 350)
        Me.cbcrncy.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbcrncy.Name = "cbcrncy"
        Me.cbcrncy.Size = New System.Drawing.Size(148, 23)
        Me.cbcrncy.TabIndex = 4
        Me.cbcrncy.Tag = ""
        '
        'cbshiptrm
        '
        Me.cbshiptrm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbshiptrm.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbshiptrm.FormattingEnabled = True
        Me.cbshiptrm.Location = New System.Drawing.Point(312, 408)
        Me.cbshiptrm.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbshiptrm.Name = "cbshiptrm"
        Me.cbshiptrm.Size = New System.Drawing.Size(196, 23)
        Me.cbshiptrm.TabIndex = 9
        '
        'txtdaprd
        '
        Me.txtdaprd.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtdaprd.Location = New System.Drawing.Point(652, 408)
        Me.txtdaprd.Name = "txtdaprd"
        Me.txtdaprd.Size = New System.Drawing.Size(175, 23)
        Me.txtdaprd.TabIndex = 10
        '
        'dtplcdate
        '
        Me.dtplcdate.CustomFormat = "dd/MMM/yyyy"
        Me.dtplcdate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtplcdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtplcdate.Location = New System.Drawing.Point(358, 321)
        Me.dtplcdate.Name = "dtplcdate"
        Me.dtplcdate.Size = New System.Drawing.Size(148, 23)
        Me.dtplcdate.TabIndex = 1
        '
        'dtpexdate
        '
        Me.dtpexdate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpexdate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpexdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpexdate.Location = New System.Drawing.Point(652, 321)
        Me.dtpexdate.Name = "dtpexdate"
        Me.dtpexdate.Size = New System.Drawing.Size(175, 23)
        Me.dtpexdate.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(556, 324)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 15)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "LC Expiry Date :"
        '
        'txtdtls
        '
        Me.txtdtls.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtdtls.Location = New System.Drawing.Point(512, 437)
        Me.txtdtls.Multiline = True
        Me.txtdtls.Name = "txtdtls"
        Me.txtdtls.Size = New System.Drawing.Size(315, 99)
        Me.txtdtls.TabIndex = 12
        Me.txtdtls.Text = " "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(430, 440)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 15)
        Me.Label14.TabIndex = 67
        Me.Label14.Text = "Description :"
        '
        'dtpshipdate
        '
        Me.dtpshipdate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpshipdate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpshipdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpshipdate.Location = New System.Drawing.Point(82, 408)
        Me.dtpshipdate.Name = "dtpshipdate"
        Me.dtpshipdate.Size = New System.Drawing.Size(148, 23)
        Me.dtpshipdate.TabIndex = 8
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 411)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(65, 15)
        Me.Label21.TabIndex = 68
        Me.Label21.Text = "Ship Date :"
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(282, 285)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(268, 30)
        Me.Button5.TabIndex = 69
        Me.Button5.Text = "Clear Selection"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'CRLetter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 579)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.cbshiptrm)
        Me.Controls.Add(Me.dtpshipdate)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtdtls)
        Me.Controls.Add(Me.dtpexdate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtplcdate)
        Me.Controls.Add(Me.txtdaprd)
        Me.Controls.Add(Me.cbcrncy)
        Me.Controls.Add(Me.txtamnt)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtlcterm)
        Me.Controls.Add(Me.cbpono)
        Me.Controls.Add(Me.cbsuplr)
        Me.Controls.Add(Me.txtbank)
        Me.Controls.Add(Me.txtlccode)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox12)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "CRLetter"
        Me.Text = "IM - Master - Item"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintPreviewDialog2 As PrintPreviewDialog
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents txtlccode As TextBox
    Friend WithEvents txtbank As TextBox
    Private WithEvents cbsuplr As SergeUtils.EasyCompletionComboBox
    Private WithEvents cbpono As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtlcterm As TextBox
    Friend WithEvents txtamnt As TextBox
    Friend WithEvents Label19 As Label
    Private WithEvents cbcrncy As SergeUtils.EasyCompletionComboBox
    Private WithEvents cbshiptrm As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtdaprd As TextBox
    Friend WithEvents dtplcdate As DateTimePicker
    Friend WithEvents dtpexdate As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents txtdtls As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents dtpshipdate As DateTimePicker
    Friend WithEvents Label21 As Label
    Friend WithEvents Button5 As Button
End Class
