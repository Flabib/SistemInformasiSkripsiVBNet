Public Class formChildMahasiswa
    Dim mahasiswa As Mahasiswa = New Mahasiswa
    Dim skripsi As Skripsi = New Skripsi
    Dim state As String = Nothing
    Private Sub changeState(state As String)
        If state = "insert" Then
            btnSave.Text = "Insert"
            btnInsert.Enabled = False
            btnUpdate.Enabled = True
            txtNIM.ReadOnly = False
        ElseIf state = "update" Then
            btnSave.Text = "Update"
            btnInsert.Enabled = True
            btnUpdate.Enabled = False
            txtNIM.ReadOnly = True
        End If

        clearForm()
        Me.state = state
    End Sub
    Private Sub clearForm()
        txtNIM.Clear()
        txtNama.Clear()
        cbJenisKelamin.SelectedIndex = 0
        txtFakultas.Clear()
        txtProdi.Clear()
    End Sub
    Private Sub formChildMahasiswa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        changeState("insert")
        mahasiswa.loadInto(dgView)
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
        mahasiswa.nim = txtNIM.Text
        mahasiswa.nama = txtNama.Text
        mahasiswa.jk = cbJenisKelamin.Text
        mahasiswa.fakultas = txtFakultas.Text
        mahasiswa.prodi = txtProdi.Text
        mahasiswa.password = "secret"

        If state = "insert" Then
            mahasiswa.insert()

            skripsi.nim = txtNIM.Text
            skripsi.firstInsert()
        ElseIf state = "update" Then
            Dim oldId = dgView(0, dgView.CurrentRow.Index).Value
            mahasiswa.update(oldId)
        End If

        changeState("insert")
        mahasiswa.loadInto(dgView)
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        mahasiswa.nim = dgView.CurrentRow.Cells(0).Value
        skripsi.nim = dgView.CurrentRow.Cells(0).Value

        skripsi.delete()
        mahasiswa.delete()
        mahasiswa.loadInto(dgView)
    End Sub
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        changeState("insert")
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        changeState("update")

        txtNIM.Text = dgView(0, dgView.CurrentRow.Index).Value.ToString
        txtNama.Text = dgView(1, dgView.CurrentRow.Index).Value.ToString
        cbJenisKelamin.Text = dgView(2, dgView.CurrentRow.Index).Value.ToString
        txtFakultas.Text = dgView(3, dgView.CurrentRow.Index).Value.ToString
        txtProdi.Text = dgView(4, dgView.CurrentRow.Index).Value.ToString
    End Sub
    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            mahasiswa.loadIntoByQuery(dgView, txtSearch.Text)
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        clearForm()
    End Sub
End Class