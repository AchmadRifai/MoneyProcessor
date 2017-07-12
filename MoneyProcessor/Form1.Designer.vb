<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Home = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.asetView = New System.Windows.Forms.DataGridView()
        Me.pemuat = New System.ComponentModel.BackgroundWorker()
        Me.TabControl1.SuspendLayout()
        Me.Home.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.asetView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Home)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(968, 62)
        Me.TabControl1.TabIndex = 0
        '
        'Home
        '
        Me.Home.Controls.Add(Me.Button2)
        Me.Home.Controls.Add(Me.Button1)
        Me.Home.Location = New System.Drawing.Point(4, 22)
        Me.Home.Name = "Home"
        Me.Home.Padding = New System.Windows.Forms.Padding(3)
        Me.Home.Size = New System.Drawing.Size(960, 36)
        Me.Home.TabIndex = 0
        Me.Home.Text = "Home"
        Me.Home.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Catat Pemasukan"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(118, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(108, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Catat Pengeluaran"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage1)
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Location = New System.Drawing.Point(12, 76)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(964, 403)
        Me.TabControl2.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.asetView)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(956, 377)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Aset"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(956, 377)
        Me.TabPage3.TabIndex = 1
        Me.TabPage3.Text = "Pemasukan"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(956, 377)
        Me.TabPage4.TabIndex = 2
        Me.TabPage4.Text = "Pengeluaran"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'asetView
        '
        Me.asetView.AllowUserToOrderColumns = True
        Me.asetView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.asetView.Location = New System.Drawing.Point(6, 6)
        Me.asetView.MultiSelect = False
        Me.asetView.Name = "asetView"
        Me.asetView.Size = New System.Drawing.Size(944, 365)
        Me.asetView.TabIndex = 0
        '
        'pemuat
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 491)
        Me.Controls.Add(Me.TabControl2)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Meja Kerja"
        Me.TabControl1.ResumeLayout(False)
        Me.Home.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.asetView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Home As TabPage
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents asetView As DataGridView
    Friend WithEvents pemuat As System.ComponentModel.BackgroundWorker
End Class
