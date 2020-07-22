Public Class Skripsi
    Inherits Model

    Private _idskripsi As String
    Private _tanggal As String
    Private _waktu As String
    Private _nim As String
    Private _nidn_pembimbing1 As String
    Private _nidn_pembimbing2 As String
    Private _judul As String

    Public Property idskripsi()
        Get
            Return _idskripsi
        End Get
        Set(value)
            _idskripsi = value
        End Set
    End Property
    Public Property tanggal()
        Get
            Return _tanggal
        End Get
        Set(value)
            _tanggal = value
        End Set
    End Property
    Public Property waktu()
        Get
            Return _waktu
        End Get
        Set(value)
            _waktu = value
        End Set
    End Property
    Public Property nim()
        Get
            Return _nim
        End Get
        Set(value)
            _nim = value
        End Set
    End Property
    Public Property nidn_pembimbing1()
        Get
            Return _nidn_pembimbing1
        End Get
        Set(value)
            _nidn_pembimbing1 = value
        End Set
    End Property
    Public Property nidn_pembimbing2()
        Get
            Return _nidn_pembimbing2
        End Get
        Set(value)
            _nidn_pembimbing2 = value
        End Set
    End Property
    Public Property judul()
        Get
            Return _judul
        End Get
        Set(value)
            _judul = value
        End Set
    End Property

    Public Function update() As Object
        Dim sql As String = "update skripsi set nidn_pembimbing1 = @1, nidn_pembimbing2 = @2, tanggal = @3, waktu = @4 where idskripsi = @5;"

        If _nidn_pembimbing1 = "" Then
            _nidn_pembimbing1 = Nothing
        End If

        If _nidn_pembimbing2 = "" Then
            _nidn_pembimbing2 = Nothing
        End If

        Return runExecuteNonQuery(sql, {
            _nidn_pembimbing1,
            _nidn_pembimbing2,
            _tanggal,
            _waktu,
            _idskripsi
        })
    End Function
    Public Function updateJudul() As Object
        Dim sql As String = "update skripsi set judul = @1 where nim = @2;"

        Return runExecuteNonQuery(sql, {
            _judul,
            _nim
        })
    End Function
    Public Function firstInsert() As Object
        Dim sql As String = "insert into skripsi(nim) values(@1); select last_insert_id();"

        Return runScalar(sql, {
            _nim
        })
    End Function
    Public Function insert() As Object
        Dim sql As String = "insert into skripsi(idskripsi, tanggal, nim, nidn_pembimbing1, nidn_pembimbing1, judul) values(@1, @2, @3, @4, @5, @6); select last_insert_id();"

        Return runScalar(sql, {
            _idskripsi,
            _tanggal,
            _nim,
            _nidn_pembimbing1,
            _nidn_pembimbing2,
            judul
        })
    End Function
    Public Sub update(oldId As String)
        Dim sql As String = "update skripsi set idskripsi = @1, tanggal = @2, nim = @3, nidn_pembimbing1 = @4, nidn_pembimbing2 = @5, judul = @6 where idskripsi = @7;"

        runExecuteNonQuery(sql, {
            _idskripsi,
            _tanggal,
            _nim,
            _nidn_pembimbing1,
            _nidn_pembimbing2,
            judul,
            oldId
        })
    End Sub
    Public Sub delete()
        Dim sql As String = "delete from skripsi where nim = @1;"

        runExecuteNonQuery(sql, {
            _nim
        })
    End Sub
End Class
