Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class Model
    Protected connDB As MySqlConnection
    Protected myCommand As MySqlCommand
    Protected myAdapter As MySqlDataAdapter
    Protected myData As MySqlDataReader
    Protected myDataTable As DataTable
    Protected Sub connectDB()
        Try
            'This is the server IP/Server name.  If server is intalled on your local machine, your IP should be 127.0.0.1 or you may use localhost
            Dim strServer As String = "127.0.0.1"
            Dim strDbase As String = "ayoskripsi"
            Dim strUser As String = "root"
            Dim strPass As String = ""

            connDB = New MySqlConnection
            myCommand = New MySqlCommand
            myAdapter = New MySqlDataAdapter
            myDataTable = New DataTable

            'MySQL Connection String
            If connDB.State <> ConnectionState.Open Then connDB.ConnectionString = "host=" & strServer.Trim & ";database=" & strDbase.Trim & ";uid=" & strUser.Trim & ";pwd=" & strPass
            If connDB.State <> ConnectionState.Open Then connDB.Open() Else connDB.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub modifyDG(dgView As DataGridView)
        Dim dgvColumnHeaderStyle As New DataGridViewCellStyle()
        dgvColumnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvColumnHeaderStyle.BackColor = Color.CadetBlue

        ' Apply Style
        With dgView
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .ColumnHeadersDefaultCellStyle = dgvColumnHeaderStyle
            .EnableHeadersVisualStyles = False
            .ReadOnly = True
        End With

        ' Header to upper
        For i As Integer = 0 To dgView.Columns.Count - 1
            Dim oldValue = dgView.Columns(i).HeaderText

            dgView.Columns(i).HeaderText = oldValue.ToString.ToUpper
        Next

        ' Fill last column
        ' Dim lastColIndex = dgView.Columns.Count - 1
        ' Dim lastCol = dgView.Columns.Item(lastColIndex)
        '
        ' lastCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub
    Public Function GetHash(theInput As String) As String

        Using hasher As MD5 = MD5.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
             hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString().ToLower
        End Using

    End Function
    Public Function runExecuteNonQuery(sql As String, Optional params() As String = Nothing) As Object
        Dim success = Nothing

        Try
            connectDB()

            myCommand.Connection = connDB
            myCommand.CommandText = sql

            If params IsNot Nothing Then
                For i As Integer = 0 To params.Length - 1
                    myCommand.Parameters.AddWithValue("@" + (i + 1).ToString, params(i))
                Next
            End If

            myCommand.ExecuteNonQuery()
            success = True

            connDB.Close()
        Catch ex As Exception
            success = False

            MsgBox(ex.Message)
        Finally
            myCommand = Nothing
        End Try

        Return success
    End Function
    Public Function runScalar(sql As String, Optional params() As String = Nothing) As Object
        Try
            connectDB()

            myCommand.Connection = connDB
            myCommand.CommandText = sql

            If params IsNot Nothing Then
                For i As Integer = 0 To params.Length - 1
                    myCommand.Parameters.AddWithValue("@" + (i + 1).ToString, params(i))
                Next
            End If

            Dim result = myCommand.ExecuteScalar

            connDB.Close()

            Return result
        Catch ex As Exception
            MsgBox(ex.Message)

            Return Nothing
        Finally
            myCommand = Nothing
        End Try
    End Function
    Public Function runSelect(dgView As DataGridView, sql As String, Optional params() As String = Nothing)
        Try
            connectDB()

            myCommand.Connection = connDB
            myCommand.CommandText = sql

            If params IsNot Nothing Then
                For i As Integer = 0 To params.Length - 1
                    myCommand.Parameters.AddWithValue("@" + (i + 1).ToString, params(i))
                Next
            End If

            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myDataTable)

            dgView.DataSource = myDataTable
            modifyDG(dgView)

            connDB.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myCommand = Nothing
        End Try

        Return Nothing
    End Function
    Public Function runReader(sql As String, Optional params() As String = Nothing)
        Try
            connectDB()

            myCommand.Connection = connDB
            myCommand.CommandText = sql

            If params IsNot Nothing Then
                For i As Integer = 0 To params.Length - 1
                    myCommand.Parameters.AddWithValue("@" + (i + 1).ToString, params(i))
                Next
            End If

            myData = myCommand.ExecuteReader
            myData.Read()

            Return myData

            connDB.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myCommand = Nothing
        End Try

        Return Nothing
    End Function
End Class
