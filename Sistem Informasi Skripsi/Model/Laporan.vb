Public Class Laporan
    Inherits Model

    Public Sub loadInto(dgView As DataGridView)
        Dim sql As String = "select * from laporan;"

        runSelect(dgView, sql)
    End Sub
    Public Sub loadIntoByQuery(dgView As DataGridView, query As String)
        Dim sql As String = "select * from laporan where concat_ws(idskripsi, tanggal, nim, nama, jk, fakultas, prodi, nidn_pembimbing1, nama_pembimbing1, nidn_pembimbing2, nama_pembimbing2) LIKE @1;"

        runSelect(dgView, sql, {
            "%" & query & "%"
        })
    End Sub
    Public Function searchByNIM(nim As String)
        Dim sql As String = "select * from laporan where nim = @1;"

        Return runReader(sql, {
            nim
        })
    End Function
    Public Sub loadIntoByNIDN(dgView As DataGridView, nidn As String)
        Dim sql As String = "select * from laporan where nidn_pembimbing1 = @1 or nidn_pembimbing2 = @1;"

        runSelect(dgView, sql, {
            nidn
        })
    End Sub
End Class
