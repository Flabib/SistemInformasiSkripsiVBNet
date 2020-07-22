Public Class formDasboardMahasiswa
    Dim laporan As Laporan = New Laporan
    Dim skripsi As Skripsi = New Skripsi
    Dim nim As String = My.Settings.userid

    Private Sub DasboardMahasiswa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data = laporan.searchByNIM(nim)

        txtTanggal.Text = Convert.ToString(data("tanggal"))
        txtJudul.Text = Convert.ToString(data("judul"))
        txtNIM.Text = Convert.ToString(data("nim"))
        txtNama.Text = Convert.ToString(data("nama"))
        txtJenisKelamin.Text = Convert.ToString(data("jk"))
        txtFakultas.Text = Convert.ToString(data("fakultas"))
        txtProgramStudi.Text = Convert.ToString(data("prodi"))
        txtPembimbing1.Text = Convert.ToString(data("nama_pembimbing1"))
        txtPembimbing2.Text = Convert.ToString(data("nama_pembimbing2"))
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        skripsi.nim = nim
        skripsi.judul = txtJudul.Text

        If skripsi.updateJudul() Then
            MsgBox("Data berhasil disimpan!")
        Else
            MsgBox("Data gagal disimpan!", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        formLogin.Show()
        Close()
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        formDialogAbout.ShowDialog()
    End Sub
End Class