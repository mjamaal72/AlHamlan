<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Listings
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbITrans = New System.Windows.Forms.RadioButton()
        Me.rbIMstr = New System.Windows.Forms.RadioButton()
        Me.rbFTrans = New System.Windows.Forms.RadioButton()
        Me.rbFMstr = New System.Windows.Forms.RadioButton()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpFDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
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
        Me.Label1.Size = New System.Drawing.Size(386, 37)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Masters and Transactions Listings"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(12, 216)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(112, 38)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Print"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(262, 216)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(112, 38)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "E&xit"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(12, 183)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(362, 27)
        Me.ComboBox1.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(9, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 19)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Select Module :"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.rbITrans)
        Me.Panel1.Controls.Add(Me.rbIMstr)
        Me.Panel1.Controls.Add(Me.rbFTrans)
        Me.Panel1.Controls.Add(Me.rbFMstr)
        Me.Panel1.Location = New System.Drawing.Point(12, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(362, 79)
        Me.Panel1.TabIndex = 10
        '
        'rbITrans
        '
        Me.rbITrans.AutoSize = True
        Me.rbITrans.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbITrans.Location = New System.Drawing.Point(172, 48)
        Me.rbITrans.Name = "rbITrans"
        Me.rbITrans.Size = New System.Drawing.Size(151, 19)
        Me.rbITrans.TabIndex = 3
        Me.rbITrans.TabStop = True
        Me.rbITrans.Text = "InvSales - Transactions"
        Me.rbITrans.UseVisualStyleBackColor = True
        '
        'rbIMstr
        '
        Me.rbIMstr.AutoSize = True
        Me.rbIMstr.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbIMstr.Location = New System.Drawing.Point(171, 11)
        Me.rbIMstr.Name = "rbIMstr"
        Me.rbIMstr.Size = New System.Drawing.Size(125, 19)
        Me.rbIMstr.TabIndex = 2
        Me.rbIMstr.TabStop = True
        Me.rbIMstr.Text = "InvSales - Masters"
        Me.rbIMstr.UseVisualStyleBackColor = True
        '
        'rbFTrans
        '
        Me.rbFTrans.AutoSize = True
        Me.rbFTrans.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFTrans.Location = New System.Drawing.Point(14, 48)
        Me.rbFTrans.Name = "rbFTrans"
        Me.rbFTrans.Size = New System.Drawing.Size(124, 19)
        Me.rbFTrans.TabIndex = 1
        Me.rbFTrans.TabStop = True
        Me.rbFTrans.Text = "FM - Transactions"
        Me.rbFTrans.UseVisualStyleBackColor = True
        '
        'rbFMstr
        '
        Me.rbFMstr.AutoSize = True
        Me.rbFMstr.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFMstr.Location = New System.Drawing.Point(13, 11)
        Me.rbFMstr.Name = "rbFMstr"
        Me.rbFMstr.Size = New System.Drawing.Size(98, 19)
        Me.rbFMstr.TabIndex = 0
        Me.rbFMstr.TabStop = True
        Me.rbFMstr.Text = "FM - Masters"
        Me.rbFMstr.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(314, 78)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(53, 27)
        Me.DataGridView1.TabIndex = 11
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpToDate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(247, 126)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(127, 23)
        Me.dtpToDate.TabIndex = 98
        '
        'dtpFDate
        '
        Me.dtpFDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpFDate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFDate.Location = New System.Drawing.Point(68, 126)
        Me.dtpFDate.Name = "dtpFDate"
        Me.dtpFDate.Size = New System.Drawing.Size(127, 23)
        Me.dtpFDate.TabIndex = 97
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(9, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 19)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "From :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(206, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 19)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "To :"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(137, 216)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 38)
        Me.Button1.TabIndex = 101
        Me.Button1.Text = "Export"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Listings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 256)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpFDate)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Listings"
        Me.Text = "Listings"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rbITrans As RadioButton
    Friend WithEvents rbIMstr As RadioButton
    Friend WithEvents rbFTrans As RadioButton
    Friend WithEvents rbFMstr As RadioButton
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents dtpFDate As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
End Class
