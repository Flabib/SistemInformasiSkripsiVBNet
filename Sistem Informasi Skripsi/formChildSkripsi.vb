Public Class formChildSkripsi
    Dim laporan As Laporan = New Laporan
    Dim skripsi As Skripsi = New Skripsi
    Dim state As String = "update"
    Dim id As String = Nothing

    Private Sub clearForm()
        txtID.Clear()
        txtNIDN1.Clear()
        txtNIDN2.Clear()
        dtpTanggal.Value = DateTime.Now
        dtpWaktu.Value = DateTime.Now
    End Sub
    Private Sub formChildSkripsi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        laporan.loadInto(dgView)
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
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        skripsi.idskripsi = txtID.Text
        skripsi.nidn_pembimbing1 = txtNIDN1.Text
        skripsi.nidn_pembimbing2 = txtNIDN2.Text
        skripsi.tanggal = dtpTanggal.Value.ToString("yyyy-MM-dd")
        skripsi.waktu = dtpWaktu.Value.ToString("HH:mm:ss")

        skripsi.update()

        clearForm()
        laporan.loadInto(dgView)
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        txtID.Text = dgView(0, dgView.CurrentRow.Index).Value.ToString
        txtNIDN1.Text = dgView(9, dgView.CurrentRow.Index).Value.ToString
        txtNIDN2.Text = dgView(11, dgView.CurrentRow.Index).Value.ToString
        dtpTanggal.Value = Convert.ToDateTime(dgView(1, dgView.CurrentRow.Index).Value.ToString)
        dtpWaktu.Value = Convert.ToDateTime(dgView(2, dgView.CurrentRow.Index).Value.ToString)
    End Sub
    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            laporan.loadIntoByQuery(dgView, txtSearch.Text)
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        clearForm()
    End Sub
End Class