Public Class formLogin
    Dim auth As Auth = New Auth

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim type As String = Nothing
        Dim targetForm As Form = Nothing

        My.Settings.userid = txtUsername.Text

        If rbAdmin.Checked Then
            type = "admin"
            targetForm = formDashboardAdmin
        ElseIf rbDosen.Checked Then
            type = "dosen"
            targetForm = formDashboardDosen
        ElseIf rbMahasiswa.Checked Then
            type = "mahasiswa"
            targetForm = formDasboardMahasiswa
        End If

        Dim correct As Boolean = auth.login(txtUsername.Text, txtPassword.Text, type)

        If correct Then
            targetForm.Show()
            Close()
        Else
            MsgBox("Data yang dimasukan tidak tersedia!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub formLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.userid = Nothing
    End Sub
End Class