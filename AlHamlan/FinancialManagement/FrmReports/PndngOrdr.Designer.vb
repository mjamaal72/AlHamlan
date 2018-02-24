<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PndngOrdr
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbsuplr = New SergeUtils.EasyCompletionComboBox()
        Me.cbdiv = New SergeUtils.EasyCompletionComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PONo = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.PODate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Div = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ICode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RcvQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BalQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbitem = New SergeUtils.EasyCompletionComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbMore = New System.Windows.Forms.RadioButton()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.rbCncl = New System.Windows.Forms.RadioButton()
        Me.rbCmplt = New System.Windows.Forms.RadioButton()
        Me.rbPndng = New System.Windows.Forms.RadioButton()
        Me.txtpono = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        Me.Label1.Text = "PO Status Report"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(729, 40)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(189, 27)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Statement"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Button4.Location = New System.Drawing.Point(729, 94)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(189, 27)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Print"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 15)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "Supplier :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 15)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Division :"
        '
        'cbsuplr
        '
        Me.cbsuplr.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbsuplr.FormattingEnabled = True
        Me.cbsuplr.Location = New System.Drawing.Point(69, 69)
        Me.cbsuplr.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbsuplr.Name = "cbsuplr"
        Me.cbsuplr.Size = New System.Drawing.Size(453, 23)
        Me.cbsuplr.TabIndex = 2
        '
        'cbdiv
        '
        Me.cbdiv.DropDownWidth = 350
        Me.cbdiv.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbdiv.FormattingEnabled = True
        Me.cbdiv.Location = New System.Drawing.Point(69, 40)
        Me.cbdiv.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbdiv.Name = "cbdiv"
        Me.cbdiv.Size = New System.Drawing.Size(200, 23)
        Me.cbdiv.TabIndex = 0
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PONo, Me.PODate, Me.Div, Me.ICode, Me.Item, Me.POQty, Me.RcvQty, Me.CanQty, Me.BalQty})
        Me.DataGridView1.Location = New System.Drawing.Point(4, 127)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.Size = New System.Drawing.Size(926, 587)
        Me.DataGridView1.TabIndex = 7
        '
        'PONo
        '
        Me.PONo.DataPropertyName = "PUR_ORDER_NO"
        Me.PONo.HeaderText = "PO"
        Me.PONo.Name = "PONo"
        Me.PONo.ReadOnly = True
        Me.PONo.Width = 60
        '
        'PODate
        '
        Me.PODate.DataPropertyName = "PUR_ORDER_DATE"
        DataGridViewCellStyle2.Format = "dd-MMM-yyyy"
        Me.PODate.DefaultCellStyle = DataGridViewCellStyle2
        Me.PODate.HeaderText = "Date"
        Me.PODate.Name = "PODate"
        Me.PODate.ReadOnly = True
        '
        'Div
        '
        Me.Div.DataPropertyName = "PUR_DIV"
        Me.Div.HeaderText = "Div"
        Me.Div.Name = "Div"
        Me.Div.ReadOnly = True
        Me.Div.Width = 50
        '
        'ICode
        '
        Me.ICode.DataPropertyName = "PUR_ITM_CODE"
        Me.ICode.HeaderText = "ICode"
        Me.ICode.Name = "ICode"
        Me.ICode.ReadOnly = True
        Me.ICode.Width = 70
        '
        'Item
        '
        Me.Item.DataPropertyName = "ITEM_DESC"
        Me.Item.HeaderText = "Item"
        Me.Item.Name = "Item"
        Me.Item.ReadOnly = True
        Me.Item.Width = 290
        '
        'POQty
        '
        Me.POQty.DataPropertyName = "PUR_QTY_ORDERED"
        Me.POQty.HeaderText = "POQty"
        Me.POQty.Name = "POQty"
        Me.POQty.ReadOnly = True
        Me.POQty.Width = 80
        '
        'RcvQty
        '
        Me.RcvQty.DataPropertyName = "PUR_QTY_RECIEVED"
        Me.RcvQty.HeaderText = "RcvQty"
        Me.RcvQty.Name = "RcvQty"
        Me.RcvQty.ReadOnly = True
        Me.RcvQty.Width = 80
        '
        'CanQty
        '
        Me.CanQty.DataPropertyName = "PUR_QTY_CANCELLED"
        Me.CanQty.HeaderText = "CanQty"
        Me.CanQty.Name = "CanQty"
        Me.CanQty.ReadOnly = True
        Me.CanQty.Width = 80
        '
        'BalQty
        '
        Me.BalQty.DataPropertyName = "PUR_QTY_BALANCE"
        Me.BalQty.HeaderText = "BalQty"
        Me.BalQty.Name = "BalQty"
        Me.BalQty.ReadOnly = True
        Me.BalQty.Width = 80
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(341, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 15)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "PO No :"
        '
        'cbitem
        '
        Me.cbitem.DropDownWidth = 453
        Me.cbitem.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbitem.FormattingEnabled = True
        Me.cbitem.Location = New System.Drawing.Point(69, 98)
        Me.cbitem.MatchingMethod = SergeUtils.StringMatchingMethod.UseWildcards
        Me.cbitem.Name = "cbitem"
        Me.cbitem.Size = New System.Drawing.Size(453, 23)
        Me.cbitem.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 15)
        Me.Label6.TabIndex = 106
        Me.Label6.Text = "Item :"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.rbMore)
        Me.Panel1.Controls.Add(Me.rbAll)
        Me.Panel1.Controls.Add(Me.rbCncl)
        Me.Panel1.Controls.Add(Me.rbCmplt)
        Me.Panel1.Controls.Add(Me.rbPndng)
        Me.Panel1.Location = New System.Drawing.Point(528, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(195, 81)
        Me.Panel1.TabIndex = 4
        '
        'rbMore
        '
        Me.rbMore.AutoSize = True
        Me.rbMore.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.rbMore.Location = New System.Drawing.Point(3, 30)
        Me.rbMore.Name = "rbMore"
        Me.rbMore.Size = New System.Drawing.Size(134, 19)
        Me.rbMore.TabIndex = 1
        Me.rbMore.TabStop = True
        Me.rbMore.Text = "More than Required"
        Me.rbMore.UseVisualStyleBackColor = True
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.rbAll.Location = New System.Drawing.Point(101, 58)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(40, 19)
        Me.rbAll.TabIndex = 4
        Me.rbAll.TabStop = True
        Me.rbAll.Text = "All"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'rbCncl
        '
        Me.rbCncl.AutoSize = True
        Me.rbCncl.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.rbCncl.Location = New System.Drawing.Point(3, 57)
        Me.rbCncl.Name = "rbCncl"
        Me.rbCncl.Size = New System.Drawing.Size(79, 19)
        Me.rbCncl.TabIndex = 2
        Me.rbCncl.TabStop = True
        Me.rbCncl.Text = "Cancelled"
        Me.rbCncl.UseVisualStyleBackColor = True
        '
        'rbCmplt
        '
        Me.rbCmplt.AutoSize = True
        Me.rbCmplt.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.rbCmplt.Location = New System.Drawing.Point(101, 3)
        Me.rbCmplt.Name = "rbCmplt"
        Me.rbCmplt.Size = New System.Drawing.Size(83, 19)
        Me.rbCmplt.TabIndex = 3
        Me.rbCmplt.TabStop = True
        Me.rbCmplt.Text = "Completed"
        Me.rbCmplt.UseVisualStyleBackColor = True
        '
        'rbPndng
        '
        Me.rbPndng.AutoSize = True
        Me.rbPndng.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.rbPndng.Location = New System.Drawing.Point(3, 3)
        Me.rbPndng.Name = "rbPndng"
        Me.rbPndng.Size = New System.Drawing.Size(69, 19)
        Me.rbPndng.TabIndex = 0
        Me.rbPndng.TabStop = True
        Me.rbPndng.Text = "Pending"
        Me.rbPndng.UseVisualStyleBackColor = True
        '
        'txtpono
        '
        Me.txtpono.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtpono.Location = New System.Drawing.Point(394, 40)
        Me.txtpono.Name = "txtpono"
        Me.txtpono.Size = New System.Drawing.Size(128, 23)
        Me.txtpono.TabIndex = 1
        '
        'PndngOrdr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 717)
        Me.Controls.Add(Me.txtpono)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cbitem)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cbdiv)
        Me.Controls.Add(Me.cbsuplr)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "PndngOrdr"
        Me.Text = "Supplier Statement"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Private WithEvents cbsuplr As SergeUtils.EasyCompletionComboBox
    Private WithEvents cbdiv As SergeUtils.EasyCompletionComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label2 As Label
    Private WithEvents cbitem As SergeUtils.EasyCompletionComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rbAll As RadioButton
    Friend WithEvents rbCncl As RadioButton
    Friend WithEvents rbCmplt As RadioButton
    Friend WithEvents rbPndng As RadioButton
    Friend WithEvents txtpono As TextBox
    Friend WithEvents rbMore As RadioButton
    Friend WithEvents PONo As DataGridViewLinkColumn
    Friend WithEvents PODate As DataGridViewTextBoxColumn
    Friend WithEvents Div As DataGridViewTextBoxColumn
    Friend WithEvents ICode As DataGridViewTextBoxColumn
    Friend WithEvents Item As DataGridViewTextBoxColumn
    Friend WithEvents POQty As DataGridViewTextBoxColumn
    Friend WithEvents RcvQty As DataGridViewTextBoxColumn
    Friend WithEvents CanQty As DataGridViewTextBoxColumn
    Friend WithEvents BalQty As DataGridViewTextBoxColumn
End Class
