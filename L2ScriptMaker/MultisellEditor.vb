Public Class MultisellEditor

    Dim ItemPch(30000) As String
    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click

        Dim iTemp As Integer

        BuySellListBox.Text = ""
        If MultisellNoteBox.Text <> Nothing Then
            BuySellListBox.AppendText("// " & MultisellNoteBox.Text & vbNewLine)
        End If

        BuySellListBox.AppendText("MultiSell_begin" & vbTab & "[" & BuySellListTextBox.Text & "]" & vbTab & MultisellIDBox.Text & vbNewLine)

        If IsDutyfreeBox.Text <> Nothing Then
            BuySellListBox.AppendText("is_dutyfree = " & IsDutyfreeBox.SelectedIndex.ToString & vbNewLine)
        End If
        If IsShowAllBox.Text <> Nothing Then
            BuySellListBox.AppendText("is_show_all = " & IsShowAllBox.SelectedIndex.ToString & vbNewLine)
        End If
        If KeepEnchantedBox.Text <> Nothing Then
            BuySellListBox.AppendText("keep_enchanted = " & KeepEnchantedBox.SelectedIndex.ToString & vbNewLine)
        End If

        BuySellListBox.AppendText("selllist={" & vbNewLine)
        For iTemp = 0 To DataGridView.RowCount - 2

            '{{{[flamberge];1}};{{[crystal_c];573};{[crystal_d];2865}}};
            If DataGridView.Item(0, iTemp).Value IsNot Nothing Then
                If iTemp > 0 Then
                    ' end of all lines, but not for first and not for last
                    BuySellListBox.AppendText("}};" & vbNewLine)
                End If

                BuySellListBox.AppendText("{{{[" & DataGridView.Item(0, iTemp).Value.ToString & "];" & DataGridView.Item(1, iTemp).Value.ToString & "}}")
                BuySellListBox.AppendText(";{{[" & DataGridView.Item(2, iTemp).Value.ToString & "];" & DataGridView.Item(3, iTemp).Value.ToString & "}")
            Else
                BuySellListBox.AppendText(";{[" & DataGridView.Item(2, iTemp).Value.ToString & "];" & DataGridView.Item(3, iTemp).Value.ToString & "}")
            End If

        Next

        BuySellListBox.AppendText("}}" & vbNewLine & "}" & vbNewLine)
        BuySellListBox.AppendText("MultiSell_end")

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
                ItemsComponentsList.Items.Add(aTemp(0))
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


        '{5; 25; 0.000000; 0 }

        DataGridView.Rows.Clear()

        Dim sTempStr As String, aTemp(3) As String
        Dim iTemp As Integer, iTemp2 As Integer

        For iTemp = 0 To BuySellListBox.Lines.Length - 1
            sTempStr = CStr(BuySellListBox.Lines.GetValue(iTemp))

            sTempStr = sTempStr.Replace(" ", "").Replace(Chr(9), "").Trim()
            If sTempStr <> "" Then

                If sTempStr.StartsWith("//") = True Then
                    MultisellNoteBox.Text = sTempStr.Remove(0, 2)
                End If
                If sTempStr.StartsWith("MultiSell_begin") = True Then
                    'MultiSell_begin	[weapon_variation]	4
                    iTemp2 = InStr(sTempStr, "[")
                    sTempStr = sTempStr.Remove(0, iTemp2)
                    BuySellListTextBox.Text = sTempStr.Substring(0, InStr(sTempStr, "]") - 1)
                    MultisellIDBox.Text = sTempStr.Remove(0, InStr(sTempStr, "]"))
                End If
                If sTempStr.StartsWith("is_dutyfree") = True Then
                    IsDutyfreeBox.Text = CBool(Libraries.GetNeedParamFromStr(sTempStr, "is_dutyfree")).ToString 'IsDutyfreeBox
                End If
                If sTempStr.StartsWith("is_show_all") = True Then
                    IsShowAllBox.Text = CBool(Libraries.GetNeedParamFromStr(sTempStr, "is_show_all")).ToString 'IsShowAllBox
                End If
                If sTempStr.StartsWith("keep_enchanted") = True Then
                    KeepEnchantedBox.Text = CBool(Libraries.GetNeedParamFromStr(sTempStr, "keep_enchanted")).ToString 'KeepEnchantedBox
                End If

                If sTempStr.StartsWith("{") = True Then

                    ' item shop list
                    If sTempStr.EndsWith(";") = True Then sTempStr = sTempStr.Remove(sTempStr.Length - 1, 1)
                    sTempStr = sTempStr.Replace("{", "").Replace("}", "")
                    aTemp = sTempStr.Split(CChar(";"))

                    For iTemp2 = 0 To aTemp.Length - 1 Step 2
                        aTemp(iTemp2) = aTemp(iTemp2).Replace("[", "").Replace("]", "")
                        If iTemp2 = 0 Then
                            aTemp(2) = aTemp(2).Replace("[", "").Replace("]", "")
                        End If
                        Try
                            If Array.IndexOf(ItemPch, aTemp(iTemp2)) = -1 Then
                                MessageBox.Show("No exist item '" & aTemp(iTemp2) & "' in server script" & vbNewLine, "No exist item", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                DataGridView.Rows.Clear()
                                Exit Sub
                            End If
                            If iTemp2 = 0 Then
                                DataGridView.Rows.Add(aTemp(0), aTemp(1), aTemp(2), aTemp(3))
                                'DataGridView.Item(2, 0).Value = aTemp(iTemp2)
                                'DataGridView.Item(3, 0).Value = aTemp(iTemp2 + 1)
                            Else
                                DataGridView.Rows.Add(Nothing, Nothing, aTemp(iTemp2), aTemp(iTemp2 + 1))
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Import data invalid in line" & vbNewLine & sTempStr, "Import data invalid", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End Try
                        If iTemp2 = 0 Then iTemp2 = 2
                    Next

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
                    DataGridView.Item(1, e.RowIndex).Value = "1"
                End If
            End If
            If e.ColumnIndex = 2 Then
                If (DataGridView.Item(3, e.RowIndex).Value Is Nothing) Then
                    DataGridView.Item(3, e.RowIndex).Value = "1"
                End If
            End If
        End If

    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub

End Class