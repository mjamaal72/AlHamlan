<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainMDI
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
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblUID = New System.Windows.Forms.Label()
        Me.LblInitials = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblFrmDtls = New System.Windows.Forms.Label()
        Me.lbltheme = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 134)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(569, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 19)
        Me.Label1.TabIndex = 9
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Label2"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(52, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Label3"
        Me.Label3.Visible = False
        '
        'lblUID
        '
        Me.lblUID.AutoSize = True
        Me.lblUID.Location = New System.Drawing.Point(518, 110)
        Me.lblUID.Name = "lblUID"
        Me.lblUID.Size = New System.Drawing.Size(26, 13)
        Me.lblUID.TabIndex = 14
        Me.lblUID.Text = "UID"
        Me.lblUID.Visible = False
        '
        'LblInitials
        '
        Me.LblInitials.AutoSize = True
        Me.LblInitials.Location = New System.Drawing.Point(476, 110)
        Me.LblInitials.Name = "LblInitials"
        Me.LblInitials.Size = New System.Drawing.Size(36, 13)
        Me.LblInitials.TabIndex = 16
        Me.LblInitials.Text = "Initials"
        Me.LblInitials.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(0, 1)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(1, 20)
        Me.TextBox1.TabIndex = 18
        '
        'lblFrmDtls
        '
        Me.lblFrmDtls.AutoSize = True
        Me.lblFrmDtls.Location = New System.Drawing.Point(431, 111)
        Me.lblFrmDtls.Name = "lblFrmDtls"
        Me.lblFrmDtls.Size = New System.Drawing.Size(0, 13)
        Me.lblFrmDtls.TabIndex = 20
        Me.lblFrmDtls.Visible = False
        '
        'lbltheme
        '
        Me.lbltheme.AutoSize = True
        Me.lbltheme.Location = New System.Drawing.Point(314, 110)
        Me.lbltheme.Name = "lbltheme"
        Me.lbltheme.Size = New System.Drawing.Size(39, 13)
        Me.lbltheme.TabIndex = 22
        Me.lbltheme.Text = "default"
        Me.lbltheme.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(265, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "AlHamlan"
        Me.Label4.Visible = False
        '
        'MainMDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 156)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbltheme)
        Me.Controls.Add(Me.lblFrmDtls)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.LblInitials)
        Me.Controls.Add(Me.lblUID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.Label1)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Name = "MainMDI"
        Me.Text = "Al Hamlan & Fakhruddin General Trading CO."
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblUID As Label
    Friend WithEvents LblInitials As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lblFrmDtls As Label
    Friend WithEvents lbltheme As Label
    Friend WithEvents Label4 As Label
End Class
