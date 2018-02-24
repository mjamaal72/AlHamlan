<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CancelPndgPO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CancelPndgPO))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Narration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dmnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rcvd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cncld = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintPreviewDialog2 = New System.Windows.Forms.PrintPreviewDialog()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbpono = New SergeUtils.EasyCompletionComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CBSplr = New SergeUtils.EasyCompletionComboBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtchrgs = New System.Windows.Forms.TextBox()
        Me.txtnet = New System.Windows.Forms.TextBox()
        Me.txtdisc = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtgross = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtIgnList = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtarrdate = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtshipdate = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtpodate = New System.Windows.Forms.TextBox()
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Narration, Me.Dmnd, Me.Rcvd, Me.Cncld, Me.BQty})
        Me.DataGridView1.Location = New System.Drawing.Point(3, 33)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.Size = New System.Drawing.Size(885, 375)
        Me.DataGridView1.TabIndex = 3
        '
        'ID
        '
        Me.ID.DataPropertyName = "PUR_ENT_NO"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ID.Visible = False
        '
        'Narration
        '
        Me.Narration.DataPropertyName = "ItmName"
        Me.Narration.HeaderText = "Item Name"
        Me.Narration.Name = "Narration"
        Me.Narration.ReadOnly = True
        Me.Narration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Narration.Width = 460
        '
        'Dmnd
        '
        Me.Dmnd.DataPropertyName = "PUR_QTY_ORDERED"
        Me.Dmnd.HeaderText = "Dmnd"
        Me.Dmnd.Name = "Dmnd"
        Me.Dmnd.ReadOnly = True
        Me.Dmnd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Rcvd
        '
        Me.Rcvd.DataPropertyName = "PUR_QTY_RECIEVED"
        Me.Rcvd.HeaderText = "Rcvd"
        Me.Rcvd.Name = "Rcvd"
        Me.Rcvd.ReadOnly = True
        Me.Rcvd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Cncld
        '
        Me.Cncld.DataPropertyName = "PUR_QTY_CANCELLED"
        Me.Cncld.HeaderText = "Cancel"
        Me.Cncld.Name = "Cncld"
        Me.Cncld.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'BQty
        '
        Me.BQty.DataPropertyName = "PUR_QTY_BALANCE"
        Me.BQty.HeaderText = "Blnce"
        Me.BQty.Name = "BQty"
        Me.BQty.ReadOnly = True
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
        Me.Label1.Text = "Cancel Pending Orders"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(639, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "PO No :"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(3, 494)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(152, 30)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Update"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(767, 495)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(128, 30)
        Me.Button4.TabIndex = 2
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
        'cbpono
        '
        Me.cbpono.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbpono.FormattingEnabled = True
        Me.cbpono.Location = New System.Drawing.Point(701, 3)
        Me.cbpono.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbpono.Name = "cbpono"
        Me.cbpono.Size = New System.Drawing.Size(100, 27)
        Me.cbpono.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.CBSplr)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.cbpono)
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
        Me.LinkLabel1.Location = New System.Drawing.Point(811, 6)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(75, 19)
        Me.LinkLabel1.TabIndex = 2
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "PO Details"
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(0, 39)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(268, 30)
        Me.Button5.TabIndex = 92
        Me.Button5.Text = "Clear Selection"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtchrgs)
        Me.Panel2.Controls.Add(Me.txtnet)
        Me.Panel2.Controls.Add(Me.txtdisc)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.txtgross)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.txtIgnList)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.txtarrdate)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.txtshipdate)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.txtpodate)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Location = New System.Drawing.Point(638, 109)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(257, 241)
        Me.Panel2.TabIndex = 0
        Me.Panel2.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 211)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 15)
        Me.Label5.TabIndex = 116
        Me.Label5.Text = "Net :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 182)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "Charges :"
        '
        'txtchrgs
        '
        Me.txtchrgs.BackColor = System.Drawing.Color.White
        Me.txtchrgs.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtchrgs.Location = New System.Drawing.Point(90, 179)
        Me.txtchrgs.Name = "txtchrgs"
        Me.txtchrgs.ReadOnly = True
        Me.txtchrgs.Size = New System.Drawing.Size(158, 23)
        Me.txtchrgs.TabIndex = 13
        '
        'txtnet
        '
        Me.txtnet.BackColor = System.Drawing.Color.White
        Me.txtnet.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtnet.Location = New System.Drawing.Point(90, 208)
        Me.txtnet.Name = "txtnet"
        Me.txtnet.ReadOnly = True
        Me.txtnet.Size = New System.Drawing.Size(158, 23)
        Me.txtnet.TabIndex = 14
        '
        'txtdisc
        '
        Me.txtdisc.BackColor = System.Drawing.Color.White
        Me.txtdisc.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtdisc.Location = New System.Drawing.Point(90, 150)
        Me.txtdisc.Name = "txtdisc"
        Me.txtdisc.ReadOnly = True
        Me.txtdisc.Size = New System.Drawing.Size(158, 23)
        Me.txtdisc.TabIndex = 11
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(6, 153)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(62, 15)
        Me.Label23.TabIndex = 111
        Me.Label23.Text = "Discount :"
        '
        'txtgross
        '
        Me.txtgross.BackColor = System.Drawing.Color.White
        Me.txtgross.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtgross.Location = New System.Drawing.Point(90, 121)
        Me.txtgross.Name = "txtgross"
        Me.txtgross.ReadOnly = True
        Me.txtgross.Size = New System.Drawing.Size(158, 23)
        Me.txtgross.TabIndex = 10
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(6, 124)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(45, 15)
        Me.Label22.TabIndex = 109
        Me.Label22.Text = "Gross :"
        '
        'txtIgnList
        '
        Me.txtIgnList.BackColor = System.Drawing.Color.White
        Me.txtIgnList.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtIgnList.Location = New System.Drawing.Point(90, 92)
        Me.txtIgnList.Name = "txtIgnList"
        Me.txtIgnList.ReadOnly = True
        Me.txtIgnList.Size = New System.Drawing.Size(158, 23)
        Me.txtIgnList.TabIndex = 9
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 95)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(74, 15)
        Me.Label21.TabIndex = 107
        Me.Label21.Text = "Conctd IGN :"
        '
        'txtarrdate
        '
        Me.txtarrdate.BackColor = System.Drawing.Color.White
        Me.txtarrdate.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtarrdate.Location = New System.Drawing.Point(90, 63)
        Me.txtarrdate.Name = "txtarrdate"
        Me.txtarrdate.ReadOnly = True
        Me.txtarrdate.Size = New System.Drawing.Size(158, 23)
        Me.txtarrdate.TabIndex = 8
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 66)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(79, 15)
        Me.Label20.TabIndex = 105
        Me.Label20.Text = "Arrival Date :"
        '
        'txtshipdate
        '
        Me.txtshipdate.BackColor = System.Drawing.Color.White
        Me.txtshipdate.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtshipdate.Location = New System.Drawing.Point(90, 34)
        Me.txtshipdate.Name = "txtshipdate"
        Me.txtshipdate.ReadOnly = True
        Me.txtshipdate.Size = New System.Drawing.Size(158, 23)
        Me.txtshipdate.TabIndex = 7
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 37)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 15)
        Me.Label17.TabIndex = 103
        Me.Label17.Text = "Ship Date :"
        '
        'txtpodate
        '
        Me.txtpodate.BackColor = System.Drawing.Color.White
        Me.txtpodate.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtpodate.Location = New System.Drawing.Point(90, 5)
        Me.txtpodate.Name = "txtpodate"
        Me.txtpodate.ReadOnly = True
        Me.txtpodate.Size = New System.Drawing.Size(158, 23)
        Me.txtpodate.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 15)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "PO Date :"
        '
        'CancelPndgPO
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
        Me.Name = "CancelPndgPO"
        Me.Text = "FM - Amending - Adjust Shortage in IGN"
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
    Private WithEvents cbpono As SergeUtils.EasyCompletionComboBox
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Button5 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtdisc As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtgross As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtIgnList As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtarrdate As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtshipdate As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtpodate As TextBox
    Friend WithEvents Label6 As Label
    Private WithEvents CBSplr As SergeUtils.EasyCompletionComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtchrgs As TextBox
    Friend WithEvents txtnet As TextBox
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Narration As DataGridViewTextBoxColumn
    Friend WithEvents Dmnd As DataGridViewTextBoxColumn
    Friend WithEvents Rcvd As DataGridViewTextBoxColumn
    Friend WithEvents Cncld As DataGridViewTextBoxColumn
    Friend WithEvents BQty As DataGridViewTextBoxColumn
End Class
