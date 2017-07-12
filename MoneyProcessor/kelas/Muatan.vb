Public Class Muatan
    Private aset As List(Of bantuan.entity.Aset)
    Private masuk As List(Of bantuan.entity.Pemasukan)
    Private keluar As List(Of bantuan.entity.Pengeluaran)
    Private utang As List(Of bantuan.entity.Kewajiban)
    Private wong As List(Of bantuan.entity.Piutang)

    Property Asete As List(Of bantuan.entity.Aset)
        Get
            Return aset
        End Get
        Set(value As List(Of bantuan.entity.Aset))
            aset = value
        End Set
    End Property
    Property Masuke As List(Of bantuan.entity.Pemasukan)
        Get
            Return masuk
        End Get
        Set(value As List(Of bantuan.entity.Pemasukan))
            masuk = value
        End Set
    End Property
    Property Keluare As List(Of bantuan.entity.Pengeluaran)
        Get
            Return keluar
        End Get
        Set(value As List(Of bantuan.entity.Pengeluaran))
            keluar = value
        End Set
    End Property
    Property Utange As List(Of bantuan.entity.Kewajiban)
        Get
            Return utang
        End Get
        Set(value As List(Of bantuan.entity.Kewajiban))
            utang = value
        End Set
    End Property
    Property Wonge As List(Of bantuan.entity.Piutang)
        Get
            Return wong
        End Get
        Set(value As List(Of bantuan.entity.Piutang))
            wong = value
        End Set
    End Property
End Class