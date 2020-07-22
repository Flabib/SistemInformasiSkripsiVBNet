Public Class Mahasiswa
    Inherits Model

    Private _nim As String
    Private _nama As String
    Private _jk As String
    Private _fakultas As String
    Private _prodi As String
    Private _password As String

    Public Property nim()
        Get
            Return _nim
        End Get
        Set(value)
            _nim = value
        End Set
    End Property
    Public Property nama()
        Get
            Return _nama
        End Get
        Set(value)
            _nama = value
        End Set
    End Property
    Public Property jk()
        Get
            Return _jk
        End Get
        Set(value)
            _jk = value
        End Set
    End Property
    Public Property fakultas()
        Get
            Return _fakultas
        End Get
        Set(value)
            _fakultas = value
        End Set
    End Property
    Public Property prodi()
        Get
            Return _prodi
        End Get
        Set(value)
            _prodi = value
        End Set
    End Property
    Public Property password()
        Get
            Return _password
        End Get
        Set(value)
            _password = value
        End Set
    End Property

    Public Sub loadInto(dgView As DataGridView)
        Dim sql As String = "select * from mahasiswa;"

        runSelect(dgView, sql)
    End Sub
    Public Sub loadIntoByQuery(dgView As DataGridView, query As String)
        Dim sql As String = "select * from mahasiswa where concat_ws(nim, nama, jk, fakultas, prodi, password) LIKE @1;"

        runSelect(dgView, sql, {
            "%" & query & "%"
        })
    End Sub
    Public Function insert() As Object
        Dim sql As String = "insert into mahasiswa(nim, nama, jk, fakultas, prodi, password) values(@1, @2, @3, @4, @5, @6); select last_insert_id();"

        Return runScalar(sql, {
            _nim,
            _nama,
            _jk,
            _fakultas,
            _prodi,
            GetHash(_password)
        })
    End Function
    Public Sub update(oldId As String)
        Dim sql As String = "update mahasiswa set nidm = @1, nama = @2, jk = @3, fakultas = @4, prodi = @5, password = @6 where nim = @7;"

        runExecuteNonQuery(sql, {
            _nim,
            _nama,
            _jk,
            _fakultas,
            _prodi,
            GetHash(_password),
            oldId
        })
    End Sub
    Public Sub delete()
        Dim sql As String = "delete from mahasiswa where nim = @1;"

        runExecuteNonQuery(sql, {
            _nim
        })
    End Sub
End Class
