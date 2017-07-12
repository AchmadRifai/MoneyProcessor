Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class DIalogAset1

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        jalan.RunWorkerAsync()
        Cursor = Cursors.WaitCursor
        OK_Button.Enabled = False
        Cancel_Button.Enabled = False
        kode.Enabled = False
        nama.Enabled = False
        jumlah.Enabled = False
    End Sub

    Private Sub yo()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
        Me.Visible = False
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DIalogAset1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DialogResult = DialogResult.None
    End Sub

    Private Sub jumlah_TextChanged(sender As Object, e As EventArgs) Handles jumlah.TextChanged
        Dim l As Long
        If Long.TryParse(jumlah.Text, l) Then
            If l >= 0 Then
                jumlah.ForeColor = SystemColors.WindowText
            Else
                jumlah.ForeColor = Color.Red
            End If
        End If
        cekValidasi()
    End Sub

    Private Sub cekValidasi()
        Dim l As Long
        OK_Button.Enabled = Long.TryParse(jumlah.Text, l) AndAlso jumlah.
            ForeColor = SystemColors.WindowText AndAlso nama.Text <> "" AndAlso kode.Text <> ""
    End Sub

    Private Sub kode_TextChanged(sender As Object, e As EventArgs) Handles kode.TextChanged
        cekValidasi()

    End Sub

    Private Sub nama_TextChanged(sender As Object, e As EventArgs) Handles nama.TextChanged
        cekValidasi()

    End Sub

    Private Sub jalan_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles jalan.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            MsgBox(e.Error.Message)
            Cancel_Button.Enabled = True
            kode.Text = ""
            kode.Enabled = True
            nama.Text = ""
            nama.Enabled = True
            jumlah.Text = ""
            jumlah.Enabled = True
            Cursor = Cursors.Default
            bantuan.Work.hindar(e.Error)
        Else
            yo()
        End If
    End Sub

    Private Sub jalan_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles jalan.DoWork
        asetInput(bantuan.Work.getConection())
        iniSialisasi(bantuan.Work.getConection())
    End Sub

    Private Sub iniSialisasi(c As MySqlConnection)
        Dim p As New bantuan.entity.Pemasukan
        p.Deleted = False
        p.Tgl = DateTime.Now
        p.Jumlah = New bantuan.Uang(Long.Parse(jumlah.Text))
        p.Ket = "Modal awal"
        p.Kode = kode.Text & CStr(p.Tgl)
        Dim dao As New bantuan.entity.dao.DAOPemasukan(c)
        dao.insert(p)
        c.Close()
    End Sub

    Private Sub asetInput(c As MySqlConnection)
        Dim a As New bantuan.entity.Aset
        a.Deleted = False
        a.Jumlah = New bantuan.Uang(Long.Parse(jumlah.Text))
        a.Kode = kode.Text
        a.Nama = nama.Text
        a.Tipe = "lancar"
        Dim dao As New bantuan.entity.dao.DAOAset(c)
        dao.insert(a)
        c.Close()
    End Sub
End Class
