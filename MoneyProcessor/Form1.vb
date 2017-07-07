Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bantuan.Work.f.Exists Then
            Dim c As Conek = New Conek
            If c.ShowDialog <> DialogResult.OK Then
                Application.Exit()
            Else
                Try
                    muat()
                Catch ex As Exception
                    bantuan.Work.hindar(ex)
                End Try
            End If
        Else
            Try
                muat()
            Catch ex As Exception
                bantuan.Work.hindar(ex)
            End Try
        End If
    End Sub

    Private Sub muat()
        REM aku
    End Sub
End Class