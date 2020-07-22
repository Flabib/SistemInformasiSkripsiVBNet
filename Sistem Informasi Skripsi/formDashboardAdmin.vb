Public Class formDashboardAdmin
    Private Sub DosenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DosenToolStripMenuItem.Click
        formChildDosen.MdiParent = Me
        formChildDosen.Show()
    End Sub
    Private Sub MahasiswaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MahasiswaToolStripMenuItem.Click
        formChildMahasiswa.MdiParent = Me
        formChildMahasiswa.Show()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        formLogin.Show()
        Close()
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        formDialogAbout.ShowDialog()
    End Sub
    Private Sub SkripsiToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SkripsiToolStripMenuItem1.Click
        formChildSkripsi.MdiParent = Me
        formChildSkripsi.Show()
    End Sub

    Private Sub JadwalSkripsiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JadwalSkripsiToolStripMenuItem.Click
        formChildLaporan.MdiParent = Me
        formChildLaporan.Show()
    End Sub
End Class