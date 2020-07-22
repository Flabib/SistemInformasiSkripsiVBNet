Public Class formChildLaporan
    Private Sub formChildLaporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ayoskripsiDataSet.laporan' table. You can move, or remove it, as needed.
        Me.laporanTableAdapter.Fill(Me.ayoskripsiDataSet.laporan)

        Me.rvLaporan.RefreshReport()
        Me.rvLaporan.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage
    End Sub
End Class