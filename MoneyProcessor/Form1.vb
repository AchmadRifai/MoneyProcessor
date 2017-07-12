Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        While Not bantuan.Work.f.Exists
            Dim c As New Conek
            If c.ShowDialog <> DialogResult.OK Then Application.Exit()
        End While
        Try
            Dim c As MySql.Data.MySqlClient.MySqlConnection = bantuan.Work.getConection
            Dim dao As New bantuan.entity.dao.DAOAset(c)
            If dao.all.LongCount = 0 Then
                dialogAset()
            Else
                muat()
            End If
            c.Close()
        Catch ex As Exception
            bantuan.Work.hindar(ex)
        End Try
    End Sub

    Private Sub dialogAset()
        Dim d As New DIalogAset1
        If d.ShowDialog = DialogResult.OK Then
            muat()
        Else
            Application.Exit()
        End If
    End Sub

    Private Sub muat()
        Cursor = Cursors.WaitCursor
        pemuat.RunWorkerAsync()
        asetView.Columns.Add("kode", "Kode")
        asetView.Columns.Add("nama", "Nama")
        asetView.Columns.Add("tipe", "Tipe")
        asetView.Columns.Add("jumlah", "Jumlah")
    End Sub

    Private Sub pemuat_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles pemuat.DoWork
        Dim c As MySql.Data.MySqlClient.MySqlConnection = bantuan.Work.getConection()
        Dim m As Muatan = New Muatan
        Dim dao1 As bantuan.entity.dao.DAOAset = New bantuan.entity.dao.DAOAset(c)
        m.Asete = dao1.all
        Dim dao2 As bantuan.entity.dao.DAOPemasukan = New bantuan.entity.dao.DAOPemasukan(c)
        m.Masuke = dao2.all
        Dim dao3 As New bantuan.entity.dao.DAOPengeluaran(c)
        m.Keluare = dao3.all
        Dim dao4 As New bantuan.entity.dao.DAOKewajiban(c)
        m.Utange = dao4.all
        Dim dao5 As New bantuan.entity.dao.DAOPiutang(c)
        m.Wonge = dao5.all
        e.Result = m
        c.Close()
    End Sub

    Private Sub pemuat_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles pemuat.RunWorkerCompleted
        If e.Error Is Nothing Then
            Dim m As Muatan = DirectCast(e.Result, Muatan)
            For Each a As bantuan.entity.Aset In m.Asete
                asetView.Rows.Add(New Object() {a.Kode, a.Nama, a.Tipe, a.Jumlah})
            Next
            Cursor = Cursors.Default
        Else
            MsgBox(e.Error.Message)
            bantuan.Work.hindar(e.Error)
        End If
    End Sub
End Class