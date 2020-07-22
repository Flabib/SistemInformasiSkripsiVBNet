Public Class formChildDosen
    Dim dosen As Dosen = New Dosen
    Dim state As String = Nothing
    Private Sub changeState(state As String)
        If state = "insert" Then
            btnSave.Text = "Insert"
            btnInsert.Enabled = False
            btnUpdate.Enabled = True
            txtNIDN.ReadOnly = False
        ElseIf state = "update" Then
            btnSave.Text = "Update"
            btnInsert.Enabled = True
            btnUpdate.Enabled = False
            txtNIDN.ReadOnly = True
        End If

        clearForm()
        Me.state = state
    End Sub
    Private Sub clearForm()
        txtNIDN.Clear()
        txtNama.Clear()
        cbJenisKelamin.SelectedIndex = 0
    End Sub
    Private Sub formChildDosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        changeState("insert")
        dosen.loadInto(dgView)
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
        dosen.nidn = txtNIDN.Text
        dosen.nama = txtNama.Text
        dosen.jk = cbJenisKelamin.Text
        dosen.password = "secret"

        If state = "insert" Then
            dosen.insert()
        ElseIf state = "update" Then
            Dim oldId = dgView(0, dgView.CurrentRow.Index).Value
            dosen.update(oldId)
        End If

        changeState("insert")
        dosen.loadInto(dgView)
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        dosen.nidn = dgView.CurrentRow.Cells(0).Value

        dosen.delete()
        dosen.loadInto(dgView)
    End Sub
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        changeState("insert")
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        changeState("update")

        txtNIDN.Text = dgView(0, dgView.CurrentRow.Index).Value.ToString
        txtNama.Text = dgView(1, dgView.CurrentRow.Index).Value.ToString
        cbJenisKelamin.Text = dgView(2, dgView.CurrentRow.Index).Value.ToString
    End Sub
    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            dosen.loadIntoByQuery(dgView, txtSearch.Text)
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        clearForm()
    End Sub
End Class