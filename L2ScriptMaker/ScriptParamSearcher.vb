Public Class ScriptParamSearcher

    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click

        Dim sTemp As String, sTemp2 As String
        Dim sParamName As String
        Dim aParamList(0) As String
        'Dim iTemp As Integer

        If SearchParamTextBox.Text = "" Then
            MessageBox.Show("Required define param name for searching", "Required param name", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        sParamName = SearchParamTextBox.Text

        OpenFileDialog.InitialDirectory = System.Environment.CurrentDirectory
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim inFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)
        ProgressBar.Value = 0
        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        SummaryTextBox.Text = ""

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            sTemp2 = Libraries.GetNeedParamFromStr(sTemp, sParamName)
            If Array.IndexOf(aParamList, sTemp2) = -1 And sTemp2 <> "" Then
                Array.Resize(aParamList, aParamList.Length + 1)
                aParamList(aParamList.Length - 1) = sTemp2
                SummaryTextBox.AppendText(sTemp2 & vbNewLine)
            End If
            ProgressBar.Value = CInt(inFile.BaseStream.Position)
        End While
        inFile.Close()
        ProgressBar.Value = 0

        MessageBox.Show("Searching complete." & vbNewLine & "Found " & SummaryTextBox.Lines.Length - 1 & " definitions.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub
End Class