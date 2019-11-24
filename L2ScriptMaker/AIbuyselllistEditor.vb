Public Class AIbuyselllistEditor

    Dim ItemPch(30000) As String
    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click

        Dim iTemp As Integer

        BuySellListBox.Text = ""
        BuySellListBox.AppendText(vbTab & "buyselllist_begin " & BuySellListTextBox.Text & vbNewLine)
        For iTemp = 0 To DataGridView.RowCount - 2
            '{6125; 20; 0.000000; 0 }
            BuySellListBox.AppendText(vbTab & vbTab & "{" & Array.IndexOf(ItemPch, DataGridView.Item(0, iTemp).Value).ToString & "; " & DataGridView.Item(1, iTemp).Value.ToString & "; 0.000000; 0 }" & vbNewLine)
        Next
        BuySellListBox.AppendText(vbTab & "buyselllist_end")

        TabControl1.SelectedIndex = 1 'Result page

    End Sub

    Private Sub AIbuyselllistEditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim FileName As String = "item_pch.txt"

        If System.IO.File.Exists("item_pch.txt") = False Then
            OpenFileDialog.FileName = ""
            OpenFileDialog.Title = "Select item_pch.txt file for reading name of items from server file..."
            OpenFileDialog.Filter = "item_pch.txt|item_pch.txt|All files|*.*"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Me.Dispose() 'Exit Sub
            FileName = OpenFileDialog.FileName
        End If

        If ItemPchLoad(FileName) = False Then Exit Sub

    End Sub

    Private Function ItemPchLoad(ByVal FileName As String) As Boolean

        Dim inFile As System.IO.StreamReader
        Try
            inFile = New System.IO.StreamReader(FileName, System.Text.Encoding.Default, True, 1)
        Catch ex As Exception
            Return False
        End Try
        Dim sTempStr As String = ""
        Dim aTemp(1) As String

        While inFile.EndOfStream <> True

            '[small_sword]	=	1
            Try
                sTempStr = inFile.ReadLine
                sTempStr = sTempStr.Replace(" ", "").Replace(Chr(9), "").Replace("[", "").Replace("]", "")
                aTemp = sTempStr.Split(CChar("="))

                ItemPch(CInt(aTemp(1))) = aTemp(0)
                ItemList.Items.Add(aTemp(0))
            Catch ex As Exception
                MessageBox.Show("Import data invalid in line" & vbNewLine & sTempStr, "Import data invalid", MessageBoxButtons.OK, MessageBoxIcon.Error)
                inFile.Close()
                Return False
            End Try

        End While

        inFile.Close()
        Return True

    End Function

    Private Sub ButtonImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImport.Click

        Dim iTemp As Integer

        '{5; 25; 0.000000; 0 }

        DataGridView.Rows.Clear()

        Dim sTempStr As String, aTemp(3) As String

        For iTemp = 0 To BuySellListBox.Lines.Length - 1
            sTempStr = CStr(BuySellListBox.Lines.GetValue(iTemp))

            sTempStr = sTempStr.Replace(" ", "").Replace(Chr(9), "").Trim()
            If sTempStr <> "" Then

                If sTempStr.StartsWith("{") = True Then

                    ' item shop list
                    sTempStr = sTempStr.Replace("{", "").Replace("}", "")
                    aTemp = sTempStr.Split(CChar(";"))

                    Try
                        If ItemPch(CInt(aTemp(0))) = "" Then
                            MessageBox.Show("No exist item with number '" & CInt(aTemp(0)) & "' in server script" & vbNewLine, "No exist item number", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            DataGridView.Rows.Clear()
                            Exit Sub
                        End If
                        DataGridView.Rows.Add(ItemPch(CInt(aTemp(0))), aTemp(1))
                    Catch ex As Exception
                        MessageBox.Show("Import data invalid in line" & vbNewLine & sTempStr, "Import data invalid", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try

                ElseIf sTempStr.StartsWith("buyselllist_begin") = True Then
                    sTempStr = sTempStr.Replace("buyselllist_begin", "")
                    BuySellListTextBox.Text = sTempStr
                End If

            End If
        Next

        'TabDataPage.Select()
        TabControl1.SelectedIndex = 0 'Data page

    End Sub

    Private Sub DataGridView_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.CellEndEdit

        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                If (DataGridView.Item(1, e.RowIndex).Value Is Nothing) Then
                    If e.RowIndex > 0 Then
                        DataGridView.Item(1, e.RowIndex).Value = DataGridView.Item(1, e.RowIndex - 1).Value
                    Else
                        DataGridView.Item(1, e.RowIndex).Value = "0" ' CityTax.Items(0).ToString
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub

End Class