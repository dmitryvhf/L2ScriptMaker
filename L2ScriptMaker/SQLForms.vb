Imports System.Data

Public Class SQLForms

    Dim sQueryFile As String

    Private Sub CheckConnButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckConnButton.Click

        Dim sqlcon As New SqlClient.SqlConnection
        Dim CheckFlag As Boolean = True

        If IntegratedSecurityCheckBox.Checked = True Then
            sqlcon.ConnectionString = "Data Source=" & SQLSrvNameTextBox.Text & ";Integrated Security=true;"
        Else
            sqlcon.ConnectionString = "Data Source=" & SQLSrvNameTextBox.Text & ";User ID =" & SQLUserTextBox.Text & ";Password=" & SQLPasswordMaskedTextBox.Text & ";"
        End If

        Try
            sqlcon.Open()
        Catch ex As Exception
            sqlcon.Close()
            MessageBox.Show(ex.Message)
            CheckFlag = False
        End Try

        MessageBox.Show("Connection to server '" & SQLSrvNameTextBox.Text.ToUpper & "' - " & IIf(CheckFlag = True, "Success", "Failed").ToString, "Checking result", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub QueryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QueryButton.Click

        Dim sqlcon As New SqlClient.SqlConnection
        Dim sqlqueryString As String
        Dim sqlcommand As SqlClient.SqlCommand
        Dim reader As SqlClient.SqlDataReader

        If IntegratedSecurityCheckBox.Checked = True Then
            sqlcon.ConnectionString = "Data Source=" & SQLSrvNameTextBox.Text & ";Database=" & SQLDBNameTextBox.Text & ";Integrated Security=true;"
        Else
            sqlcon.ConnectionString = "Data Source=" & SQLSrvNameTextBox.Text & ";Database=" & SQLDBNameTextBox.Text & ";User ID =" & SQLUserTextBox.Text & ";Password=" & SQLPasswordMaskedTextBox.Text & ";"
        End If

        If SQLQueryTextBox.Text.Trim = "" Then
            MessageBox.Show("Must have any SQL query in query window and try again.", "No query", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        ' Query rebuilding
        Dim iDataGrid As Integer
        Dim sSQLQuery As String = SQLQueryTextBox.Text
        ''[{account_name}]
        For iDataGrid = 0 To DataGridView1.RowCount - 2
            sSQLQuery = sSQLQuery.Replace(DataGridView1.Item(0, iDataGrid).Value.ToString, DataGridView1.Item(1, iDataGrid).Value.ToString)
        Next

        'sqlqueryString = SQLQueryTextBox.Text
        sqlqueryString = sSQLQuery
        sqlcommand = New SqlClient.SqlCommand(sqlqueryString, sqlcon)

        'SQLQueryTextBox.Text = ""
        Try
            sqlcon.Open()
        Catch ex As Exception
            sqlcon.Close()
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try

        Try
            reader = sqlcommand.ExecuteReader()
            reader.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & "Your query is:" & vbNewLine & sSQLQuery)
            Exit Sub
        End Try


        QueryResultTextBox.Clear()
        QueryResultTextBox.AppendText("ServerVersion: " & sqlcon.ServerVersion & vbNewLine)
        QueryResultTextBox.AppendText("DataSource: " & sqlcon.DataSource & vbNewLine)
        QueryResultTextBox.AppendText("Database: " & sqlcon.Database & vbNewLine)
        QueryResultTextBox.AppendText(vbNewLine)

        Dim ReadCount As Integer = 0
        If reader.RecordsAffected = -1 Then
            Dim QueryData As New DataTable
            Dim QueryDA As New System.Data.SqlClient.SqlDataAdapter(sSQLQuery, sqlcon)
            Try
                ReadCount = QueryDA.Fill(QueryData)
            Catch ex As Exception
                sqlcon.Close()
                MessageBox.Show(ex.Message & "Your query is:" & vbNewLine & sSQLQuery)
                sqlcon.Close()
                Exit Sub
            End Try
            SQLDataGridView.DataSource = QueryData
        End If

        sqlcon.Close()
        QueryResultTextBox.AppendText(vbNewLine)
        QueryResultTextBox.AppendText("Readed of '" & ReadCount & "' lines" & vbNewLine & "Affected of '" & reader.RecordsAffected & "' lines")

        'MessageBox.Show("Complete")

    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub

    Private Sub IntegratedSecurityCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IntegratedSecurityCheckBox.CheckedChanged
        If IntegratedSecurityCheckBox.Checked = True Then
            SQLUserTextBox.ReadOnly = True
            SQLPasswordMaskedTextBox.ReadOnly = True
        Else
            SQLUserTextBox.ReadOnly = False
            SQLPasswordMaskedTextBox.ReadOnly = False
        End If
    End Sub

    Private Sub LoadQueryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadQueryButton.Click

        OpenFileDialog.Filter = "L2ScriptMaker SQL Query (*.l2smsql)|*.l2smsql|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim sTemp As String, aTemp() As String
        SQLQueryTextBox.Text = ""
        Dim inFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)
        DataGridView1.Rows.Clear()

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            If sTemp.Trim <> "" And sTemp.StartsWith("//") = False Then

                If sTemp.StartsWith("[Values]") = True Then
                    sTemp = inFile.ReadLine
                    While sTemp <> "[ValuesEnd]"
                        If sTemp.Trim <> "" And sTemp.StartsWith("//") = False Then
                            aTemp = sTemp.Split(Chr(9))
                            DataGridView1.Rows.Add(aTemp(0), aTemp(1))
                            sTemp = inFile.ReadLine
                        End If
                    End While
                End If

                If sTemp.StartsWith("[Query]") = True Then
                    sTemp = inFile.ReadLine
                    While sTemp <> "[QueryEnd]"
                        'If sTemp.Trim <> "" And sTemp.StartsWith("//") = False Then
                        SQLQueryTextBox.AppendText(sTemp & vbNewLine)
                        sTemp = inFile.ReadLine
                        'End If
                    End While
                End If

            End If

        End While
        inFile.Close()

        sQueryFile = OpenFileDialog.FileName


    End Sub

    Private Sub SaveQueryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveQueryButton.Click

        SaveFileDialog.Title = "Save current query to file..."
        SaveFileDialog.FileName = sQueryFile
        SaveFileDialog.Filter = "L2ScriptMaker SQL Query (*.l2smsql)|*.l2smsql|All files|*.*"
        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Dim outFile As New System.IO.StreamWriter(SaveFileDialog.FileName, False, System.Text.Encoding.Unicode, 1)

        Dim iDataGrid As Integer

        outFile.WriteLine("L2ScriptMaker: SQL Query Template Manager")
        outFile.WriteLine("Generated at " & Now & vbNewLine)

        outFile.WriteLine("[Values]")
        For iDataGrid = 0 To DataGridView1.RowCount - 2
            outFile.WriteLine(DataGridView1.Item(0, iDataGrid).Value.ToString & vbTab & DataGridView1.Item(1, iDataGrid).Value.ToString)
        Next
        outFile.WriteLine("[ValuesEnd]")
        outFile.WriteLine()
        outFile.WriteLine("[Query]")
        outFile.WriteLine(SQLQueryTextBox.Text)
        outFile.WriteLine("[QueryEnd]")

        outFile.Close()

        MessageBox.Show("New SQL Query script saved success.")
        sQueryFile = SaveFileDialog.FileName

    End Sub


    Private Sub LoadConSetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadConSetButton.Click

        OpenFileDialog.Filter = "L2ScriptMaker SQL Query Connection Settings (*.l2smsqlini)|*.l2smsqlini|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim sTemp As String, aTemp() As String
        Dim inFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)
        If inFile.ReadLine() <> "[L2ScriptMaker SQL Query Connection Settings]" Then
            MessageBox.Show("File is not 'L2ScriptMaker SQL Query Connection Settings' file.", "Wrong file", MessageBoxButtons.OK, MessageBoxIcon.Error)
            inFile.Close()
            Exit Sub
        End If

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            If sTemp.Trim <> "" And sTemp.StartsWith("//") = False Then

                aTemp = sTemp.Split(CChar("="))
                If aTemp.Length < 2 Then
                    MessageBox.Show("File is not 'L2ScriptMaker SQL Query Connection Settings' file.", "Wrong file", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    inFile.Close()
                    Exit Sub
                End If
                Try
                    Select Case aTemp(0)
                        Case "SQLServerAddress"
                            SQLSrvNameTextBox.Text = aTemp(1)
                        Case "IntegratedSecurity"
                            IntegratedSecurityCheckBox.Checked = CBool(aTemp(1))
                        Case "SQLUserName"
                            SQLUserTextBox.Text = aTemp(1)
                        Case "SQLUserPassword"
                            SQLPasswordMaskedTextBox.Text = aTemp(1)
                        Case "Database"
                            SQLDBNameTextBox.Text = aTemp(1)
                    End Select
                Catch ex As Exception
                    MessageBox.Show("File is not 'L2ScriptMaker SQL Query Connection Settings' file.", "Wrong file", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    inFile.Close()
                    Exit Sub
                End Try
            End If

        End While
        inFile.Close()

    End Sub

    Private Sub SaveConSetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveConSetButton.Click

        SaveFileDialog.Filter = "L2ScriptMaker SQL Query Connection Settings (*.l2smsqlini)|*.l2smsqlini|All files|*.*"
        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim outFile As New System.IO.StreamWriter(SaveFileDialog.FileName, False, System.Text.Encoding.Unicode, 1)
        outFile.WriteLine("[L2ScriptMaker SQL Query Connection Settings]")
        outFile.WriteLine("SQLServerAddress=" & SQLSrvNameTextBox.Text)
        outFile.WriteLine("IntegratedSecurity=" & IntegratedSecurityCheckBox.Checked.ToString)
        outFile.WriteLine("SQLUserName=" & SQLUserTextBox.Text)
        outFile.WriteLine("SQLUserPassword=" & SQLPasswordMaskedTextBox.Text)
        outFile.WriteLine("Database=" & SQLDBNameTextBox.Text)
        outFile.Close()
        MessageBox.Show("New SQL Query Connection Settings saved success.")

    End Sub
End Class