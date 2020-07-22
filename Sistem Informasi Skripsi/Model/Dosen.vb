Public Class Dosen
    Inherits Model

    Private _nidn As String
    Private _nama As String
    Private _jk As String
    Private _password As String

    Public Property nidn()
        Get
            Return _nidn
        End Get
        Set(value)
            _nidn = value
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
    Public Property password()
        Get
            Return _password
        End Get
        Set(value)
            _password = value
        End Set
    End Property

    Public Sub loadInto(dgView As DataGridView)
        Dim sql As String = "select * from dosen;"

        runSelect(dgView, sql)
    End Sub
    Public Sub loadIntoByQuery(dgView As DataGridView, query As String)
        Dim sql As String = "select * from dosen where concat_ws(nidn, nama, jk, password) LIKE @1;"

        runSelect(dgView, sql, {
            "%" & query & "%"
        })
    End Sub
    Public Function insert() As Object
        Dim sql As String = "insert into dosen(nidn, nama, jk, password) values(@1, @2, @3, @4); select last_insert_id();"

        Return runScalar(sql, {
            _nidn,
            _nama,
            _jk,
            GetHash(_password)
        })
    End Function
    Public Sub update(oldId As String)
        Dim sql As String = "update dosen set nidn = @1, nama = @2, jk = @3, password = @4 where nidn = @5;"

        runExecuteNonQuery(sql, {
            _nidn,
            _nama,
            _jk,
            GetHash(_password),
            oldId
        })
    End Sub
    Public Sub delete()
        Dim sql As String = "delete from dosen where nidn = @1;"

        runExecuteNonQuery(sql, {
            _nidn
        })
    End Sub
End Class
