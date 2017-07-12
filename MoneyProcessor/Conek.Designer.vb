<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Conek
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.host = New System.Windows.Forms.TextBox()
        Me.nama = New System.Windows.Forms.TextBox()
        Me.port = New System.Windows.Forms.NumericUpDown()
        Me.user = New System.Windows.Forms.TextBox()
        Me.pass = New System.Windows.Forms.TextBox()
        Me.s = New System.Windows.Forms.Button()
        Me.mlaku1 = New System.ComponentModel.BackgroundWorker()
        Me.mlaku2 = New System.ComponentModel.BackgroundWorker()
        CType(Me.port, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Host"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "DB Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Port"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "User"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Sandi"
        '
        'host
        '
        Me.host.Location = New System.Drawing.Point(112, 6)
        Me.host.Name = "host"
        Me.host.Size = New System.Drawing.Size(182, 20)
        Me.host.TabIndex = 5
        '
        'nama
        '
        Me.nama.Location = New System.Drawing.Point(112, 30)
        Me.nama.Name = "nama"
        Me.nama.Size = New System.Drawing.Size(182, 20)
        Me.nama.TabIndex = 6
        '
        'port
        '
        Me.port.Location = New System.Drawing.Point(112, 58)
        Me.port.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.port.Minimum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.port.Name = "port"
        Me.port.Size = New System.Drawing.Size(182, 20)
        Me.port.TabIndex = 7
        Me.port.Value = New Decimal(New Integer() {3306, 0, 0, 0})
        '
        'user
        '
        Me.user.Location = New System.Drawing.Point(112, 81)
        Me.user.Name = "user"
        Me.user.Size = New System.Drawing.Size(182, 20)
        Me.user.TabIndex = 8
        '
        'pass
        '
        Me.pass.Location = New System.Drawing.Point(112, 108)
        Me.pass.Name = "pass"
        Me.pass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.pass.Size = New System.Drawing.Size(182, 20)
        Me.pass.TabIndex = 9
        '
        's
        '
        Me.s.Enabled = False
        Me.s.Location = New System.Drawing.Point(15, 134)
        Me.s.Name = "s"
        Me.s.Size = New System.Drawing.Size(279, 23)
        Me.s.TabIndex = 10
        Me.s.Text = "Simpan Dan Hubungkan"
        Me.s.UseVisualStyleBackColor = True
        '
        'mlaku1
        '
        Me.mlaku1.WorkerSupportsCancellation = True
        '
        'mlaku2
        '
        Me.mlaku2.WorkerSupportsCancellation = True
        '
        'Conek
        '
        Me.AcceptButton = Me.s
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 166)
        Me.Controls.Add(Me.s)
        Me.Controls.Add(Me.pass)
        Me.Controls.Add(Me.user)
        Me.Controls.Add(Me.port)
        Me.Controls.Add(Me.nama)
        Me.Controls.Add(Me.host)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Conek"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configurasi basis data"
        CType(Me.port, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents host As TextBox
    Friend WithEvents nama As TextBox
    Friend WithEvents port As NumericUpDown
    Friend WithEvents user As TextBox
    Friend WithEvents pass As TextBox
    Friend WithEvents s As Button
    Friend WithEvents mlaku1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents mlaku2 As System.ComponentModel.BackgroundWorker
End Class
