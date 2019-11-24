Public Class ScriptIDShower

    'Dim GlobalSearchText As Integer = -1    ' 0 - ID, 1 - Name, 2 - Pch
    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Close()
    End Sub

    Private Sub IDTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles IDTextBox.KeyPress
        If Asc(e.KeyChar) = 13 Then '13 - Enter
            FindAndResult(0)
        End If
    End Sub

    Private Sub NameTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NameTextBox.KeyPress
        If Asc(e.KeyChar) = 13 Then '13 - Enter
            FindAndResult(1)
        End If
    End Sub


    Private Function FindAndResult(ByVal GlobalSearchText As Integer) As Boolean

        If FileComboBox.Text = "" Then
            'messagebox.Show ("Required select working file")
            Return False
        End If

        If System.IO.File.Exists(FileComboBox.Text) = False Then
            MessageBox.Show("File " & FileComboBox.Text & " not found in current directory. Put this and try again.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Dim inFile As New System.IO.StreamReader(FileComboBox.Text, System.Text.Encoding.Default, True, 1)

        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Maximum = CInt(inFile.BaseStream.Length)

        ToolStripStatusLabel1.Text = "Searching..."

        ' Clear results before new searching
        If ClearBeforeCheckBox.Checked = True Then ResultsTextBox.Text = ""

        Dim sTemp As String, sTempStr As String
        Dim bFlag As Boolean
        Dim iCounter As Integer = 0

        Dim sGoogle As String = ""
        Select Case GlobalSearchText
            Case 0  ' ID
                sGoogle = IDTextBox.Text
            Case 1  'Name
                sGoogle = NameTextBox.Text
            Case Else
                MessageBox.Show("Чё за фигня")
                Return False
        End Select

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            Select Case GlobalSearchText
                Case 0  ' ID
                    sTempStr = Libraries.GetNeedParamFromStr(sTemp, "id")
                    If sTempStr = sGoogle Then bFlag = True
                Case 1  'Name
                    sTempStr = Libraries.GetNeedParamFromStr(sTemp, "name")
                    If FindAsIsCheckBox.Checked = True Then
                        If InStr(sTempStr, sGoogle, CompareMethod.Binary) <> 0 Then bFlag = True
                    Else
                        If InStr(sTempStr, sGoogle, CompareMethod.Text) <> 0 Then bFlag = True
                    End If

            End Select

            If bFlag = True Then
                If ShortResultsCheckBox.Checked = False Then
                    ResultsTextBox.AppendText(sTemp & vbNewLine)
                Else
                    sTempStr = Libraries.GetNeedParamFromStr(sTemp, "description")
                    If sTempStr <> "" Then sTempStr = vbTab & "description=" & sTempStr
                    If FileComboBox.Text.StartsWith("skillname") = False Then
                        ResultsTextBox.AppendText("id=" & Libraries.GetNeedParamFromStr(sTemp, "id") & vbTab & "name=" & Libraries.GetNeedParamFromStr(sTemp, "name") & vbNewLine)
                    Else
                        ResultsTextBox.AppendText("id=" & Libraries.GetNeedParamFromStr(sTemp, "id") & vbTab & "level=" & Libraries.GetNeedParamFromStr(sTemp, "level") & vbTab & "name=" & Libraries.GetNeedParamFromStr(sTemp, "name") & sTempStr & vbNewLine)
                    End If
                End If
                iCounter += 1
            End If
            bFlag = False

            ToolStripProgressBar1.Value = CInt(inFile.BaseStream.Position)
        End While

        ToolStripProgressBar1.Value = 0
        inFile.Close()

        TabControl1.SelectedIndex = 2 'Result page

        ToolStripStatusLabel1.Text = "Founded " & iCounter.ToString & " lines."

        Return True
    End Function

End Class