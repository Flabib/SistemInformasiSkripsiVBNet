Public Class formDashboardDosen
    Dim laporan As Laporan = New Laporan
    Dim nidn As String = My.Settings.userid
    Private Sub DashboardAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        laporan.loadIntoByNIDN(dgView, nidn)
    End Sub
    Private Sub dgView_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgView.DataBindingComplete
        dgView.ClearSelection()
    End Sub
    Private Sub dgView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgView.CellFormatting
        Dim header As DataGridViewRowHeaderCell = dgView.Rows(e.RowIndex).HeaderCell

        If e.ColumnIndex = 0 Then
            header.Value = [String].Format("{0}", e.RowIndex + 1)
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