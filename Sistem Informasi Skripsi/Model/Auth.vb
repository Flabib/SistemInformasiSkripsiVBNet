Public Class Auth
    Inherits Model

    Public Function login(username As String, password As String, type As String)
        Dim sql As String = Nothing

        If type = "admin" Then
            sql = "select count(*) from admin where username = @1 and password = @2;"
        ElseIf type = "dosen" Then
            sql = "select count(*) from dosen where nidn = @1 and password = @2;"
        ElseIf type = "mahasiswa" Then
            sql = "select count(*) from mahasiswa where nim = @1 and password = @2;"
        End If

        Dim num = runScalar(sql, {
            username,
            GetHash(password)
        })

        If num IsNot Nothing And num = 1 Then
            Return True
        End If

        Return False
    End Function
End Class
