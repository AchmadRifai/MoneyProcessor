Imports System.Windows.Forms

Public Class Conek

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Conek_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.DialogResult = DialogResult.Abort
    End Sub

    Private Sub host_TextChanged(sender As Object, e As EventArgs) Handles host.TextChanged
        s.Enabled = "" <> host.Text And "" <> nama.Text And "" <> user.Text
    End Sub

    Private Sub nama_TextChanged(sender As Object, e As EventArgs) Handles nama.TextChanged
        s.Enabled = "" <> host.Text And "" <> nama.Text And "" <> user.Text
    End Sub

    Private Sub user_TextChanged(sender As Object, e As EventArgs) Handles user.TextChanged
        s.Enabled = "" <> host.Text And "" <> nama.Text And "" <> user.Text
    End Sub

    Private Sub s_Click(sender As Object, e As EventArgs) Handles s.Click
        mlaku1.RunWorkerAsync()
        mlaku2.RunWorkerAsync()
        s.Enabled = False
        Cursor = Cursors.WaitCursor
        host.Enabled = False
        nama.Enabled = False
        port.Enabled = False
        user.Enabled = False
        pass.Enabled = False
    End Sub

    Private Sub mlaku1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles mlaku1.DoWork
        bantuan.Work.createDB(host.Text, nama.Text, port.Value, user.Text, pass.Text)
    End Sub

    Private Sub mlaku2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles mlaku2.DoWork
        Dim c As bantuan.DBConfig = New bantuan.DBConfig
        c.Host = host.Text
        c.Nama = nama.Text
        c.Pass = pass.Text
        c.Port = CInt(port.Value)
        c.User = user.Text
        bantuan.Work.simpan(c)
    End Sub

    Private Sub mlaku2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles mlaku2.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            mlaku1.CancelAsync()
            MsgBox(e.Error.Message)
            enableAll()
            bantuan.Work.hindar(e.Error)
        End If
    End Sub

    Private Sub enableAll()
        host.Text = ""
        host.Enabled = True
        nama.Text = ""
        nama.Enabled = True
        port.Enabled = True
        user.Text = ""
        user.Enabled = True
        pass.Text = ""
        pass.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub mlaku1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles mlaku1.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            mlaku2.CancelAsync()
            MsgBox(e.Error.Message)
            enableAll()
            bantuan.Work.hindar(e.Error)
        ElseIf Not e.Cancelled Then
            MsgBox("Setelah ini jalankan aplikasi kembali")
            DialogResult = DialogResult.OK
            Form1.Visible = True
            Close()
        End If
    End Sub
End Class
