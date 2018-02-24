<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchGrid
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DefaultGridFilterFactory2 As GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory = New GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me._extender = New GridViewExtensions.DataGridFilterExtender(Me.components)
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.lblquery = New System.Windows.Forms.Label()
        Me.lblsenderfrm = New System.Windows.Forms.Label()
        Me.lblrspnse = New System.Windows.Forms.Label()
        Me.lblresclm = New System.Windows.Forms.Label()
        Me.lblresfld = New System.Windows.Forms.Label()
        Me.lblheader = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.lblhighlight1 = New System.Windows.Forms.Label()
        Me.lblhighlight2 = New System.Windows.Forms.Label()
        Me.lblhighlight3 = New System.Windows.Forms.Label()
        Me.lblhighlight4 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.BtnCCode = New System.Windows.Forms.Button()
        CType(Me._extender, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_extender
        '
        Me._extender.DataGridView = Me.DGV
        DefaultGridFilterFactory2.CreateDistinctGridFilters = False
        DefaultGridFilterFactory2.DefaultGridFilterType = GetType(GridViewExtensions.GridFilters.TextGridFilter)
        DefaultGridFilterFactory2.DefaultShowDateInBetweenOperator = False
        DefaultGridFilterFactory2.DefaultShowNumericInBetweenOperator = False
        DefaultGridFilterFactory2.HandleEnumerationTypes = True
        DefaultGridFilterFactory2.MaximumDistinctValues = 20
        Me._extender.FilterFactory = DefaultGridFilterFactory2
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.AllowUserToResizeRows = False
        Me.DGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV.DefaultCellStyle = DataGridViewCellStyle6
        Me.DGV.Location = New System.Drawing.Point(0, 99)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DGV.RowHeadersVisible = False
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGV.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.DGV.RowTemplate.Height = 30
        Me.DGV.Size = New System.Drawing.Size(984, 562)
        Me.DGV.TabIndex = 12
        '
        'lblquery
        '
        Me.lblquery.AutoSize = True
        Me.lblquery.Location = New System.Drawing.Point(162, 336)
        Me.lblquery.Name = "lblquery"
        Me.lblquery.Size = New System.Drawing.Size(39, 13)
        Me.lblquery.TabIndex = 3
        Me.lblquery.Text = "Label1"
        Me.lblquery.Visible = False
        '
        'lblsenderfrm
        '
        Me.lblsenderfrm.AutoSize = True
        Me.lblsenderfrm.Location = New System.Drawing.Point(162, 358)
        Me.lblsenderfrm.Name = "lblsenderfrm"
        Me.lblsenderfrm.Size = New System.Drawing.Size(39, 13)
        Me.lblsenderfrm.TabIndex = 4
        Me.lblsenderfrm.Text = "Label2"
        Me.lblsenderfrm.Visible = False
        '
        'lblrspnse
        '
        Me.lblrspnse.AutoSize = True
        Me.lblrspnse.Location = New System.Drawing.Point(162, 384)
        Me.lblrspnse.Name = "lblrspnse"
        Me.lblrspnse.Size = New System.Drawing.Size(39, 13)
        Me.lblrspnse.TabIndex = 5
        Me.lblrspnse.Text = "Label3"
        Me.lblrspnse.Visible = False
        '
        'lblresclm
        '
        Me.lblresclm.AutoSize = True
        Me.lblresclm.Location = New System.Drawing.Point(162, 408)
        Me.lblresclm.Name = "lblresclm"
        Me.lblresclm.Size = New System.Drawing.Size(39, 13)
        Me.lblresclm.TabIndex = 6
        Me.lblresclm.Text = "Label4"
        Me.lblresclm.Visible = False
        '
        'lblresfld
        '
        Me.lblresfld.AutoSize = True
        Me.lblresfld.Location = New System.Drawing.Point(162, 439)
        Me.lblresfld.Name = "lblresfld"
        Me.lblresfld.Size = New System.Drawing.Size(39, 13)
        Me.lblresfld.TabIndex = 7
        Me.lblresfld.Text = "Label5"
        Me.lblresfld.Visible = False
        '
        'lblheader
        '
        Me.lblheader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblheader.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblheader.Font = New System.Drawing.Font("Calibri", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheader.ForeColor = System.Drawing.Color.Blue
        Me.lblheader.Location = New System.Drawing.Point(0, 0)
        Me.lblheader.Name = "lblheader"
        Me.lblheader.Size = New System.Drawing.Size(984, 37)
        Me.lblheader.TabIndex = 8
        Me.lblheader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(676, 37)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(308, 31)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Print Grid"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblhighlight1
        '
        Me.lblhighlight1.AutoSize = True
        Me.lblhighlight1.Location = New System.Drawing.Point(162, 466)
        Me.lblhighlight1.Name = "lblhighlight1"
        Me.lblhighlight1.Size = New System.Drawing.Size(39, 13)
        Me.lblhighlight1.TabIndex = 14
        Me.lblhighlight1.Text = "Label6"
        Me.lblhighlight1.Visible = False
        '
        'lblhighlight2
        '
        Me.lblhighlight2.AutoSize = True
        Me.lblhighlight2.Location = New System.Drawing.Point(162, 489)
        Me.lblhighlight2.Name = "lblhighlight2"
        Me.lblhighlight2.Size = New System.Drawing.Size(39, 13)
        Me.lblhighlight2.TabIndex = 15
        Me.lblhighlight2.Text = "Label7"
        Me.lblhighlight2.Visible = False
        '
        'lblhighlight3
        '
        Me.lblhighlight3.AutoSize = True
        Me.lblhighlight3.Location = New System.Drawing.Point(162, 511)
        Me.lblhighlight3.Name = "lblhighlight3"
        Me.lblhighlight3.Size = New System.Drawing.Size(39, 13)
        Me.lblhighlight3.TabIndex = 16
        Me.lblhighlight3.Text = "Label8"
        Me.lblhighlight3.Visible = False
        '
        'lblhighlight4
        '
        Me.lblhighlight4.AutoSize = True
        Me.lblhighlight4.Location = New System.Drawing.Point(162, 535)
        Me.lblhighlight4.Name = "lblhighlight4"
        Me.lblhighlight4.Size = New System.Drawing.Size(39, 13)
        Me.lblhighlight4.TabIndex = 17
        Me.lblhighlight4.Text = "Label8"
        Me.lblhighlight4.Visible = False
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(0, 37)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(308, 31)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "Export To Excel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'BtnCCode
        '
        Me.BtnCCode.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCCode.Location = New System.Drawing.Point(338, 37)
        Me.BtnCCode.Name = "BtnCCode"
        Me.BtnCCode.Size = New System.Drawing.Size(308, 31)
        Me.BtnCCode.TabIndex = 19
        Me.BtnCCode.Text = "Color Code Next 500"
        Me.BtnCCode.UseVisualStyleBackColor = True
        Me.BtnCCode.Visible = False
        '
        'SearchGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 661)
        Me.Controls.Add(Me.BtnCCode)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.lblhighlight4)
        Me.Controls.Add(Me.lblhighlight3)
        Me.Controls.Add(Me.lblhighlight2)
        Me.Controls.Add(Me.lblhighlight1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblheader)
        Me.Controls.Add(Me.lblresfld)
        Me.Controls.Add(Me.lblresclm)
        Me.Controls.Add(Me.lblsenderfrm)
        Me.Controls.Add(Me.lblquery)
        Me.Controls.Add(Me.lblrspnse)
        Me.Name = "SearchGrid"
        Me.Text = "SearchGrid"
        CType(Me._extender, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents _extender As GridViewExtensions.DataGridFilterExtender
    Friend WithEvents lblquery As Label
    Friend WithEvents lblsenderfrm As Label
    Friend WithEvents lblrspnse As Label
    Friend WithEvents lblresclm As Label
    Friend WithEvents lblresfld As Label
    Friend WithEvents lblheader As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents DGV As DataGridView
    Friend WithEvents lblhighlight1 As Label
    Friend WithEvents lblhighlight2 As Label
    Friend WithEvents lblhighlight3 As Label
    Friend WithEvents lblhighlight4 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents BtnCCode As Button
End Class
