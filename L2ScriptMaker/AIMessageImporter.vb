Public Class AIMessageImporter

    Private Sub ButtonExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExport.Click

        Dim AiFile As String
        Dim AiExport As String
        Dim TempStr As String

        OpenFileDialog.Filter = "Ai.obj file |*.obj|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            AiFile = OpenFileDialog.FileName
        End If
        AiExport = System.IO.Path.GetDirectoryName(OpenFileDialog.FileName) + "\ai_exports.txt"
        If System.IO.File.Exists(AiExport) Then
            MessageBox.Show("Export file 'ai_exports.txt' exist. Delete and try again", "File exist", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim inAiFile As New System.IO.StreamReader(AiFile, System.Text.Encoding.Default, True, 1)
        Dim inExpFile As New System.IO.StreamWriter(AiExport, False, System.Text.Encoding.Unicode, 1)

        While inAiFile.EndOfStream <> True

            TempStr = inAiFile.ReadLine
            If TempStr <> "" Then
                If Mid(TempStr, 1, 1) = "S" And InStr(TempStr, ".") <> 0 Then
                    inExpFile.WriteLine(TempStr)

                End If
            End If

        End While

        MessageBox.Show("Export complete. Target file is 'ai_exports.txt'", "Complete.", MessageBoxButtons.OK, MessageBoxIcon.Information)

        inAiFile.Close()
        inExpFile.Close()
    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Close()
    End Sub

    Private Sub ButtonImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImport.Click

        Dim AiFile As String
        Dim AiFixFile As String
        Dim WorkDir As String
        Dim TempStr As String

        OpenFileDialog.Filter = "Ai.obj file |*.obj|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        AiFile = OpenFileDialog.FileName

        OpenFileDialog.Filter = "Ai.obj Sxxx fix file |*.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        AiFixFile = OpenFileDialog.FileName

        WorkDir = System.IO.Path.GetDirectoryName(OpenFileDialog.FileName)

        System.IO.File.Copy(AiFile, System.IO.Path.GetFileNameWithoutExtension(AiFile) + ".bak", True)
        Dim inAiFile As New System.IO.StreamReader(System.IO.Path.GetFileNameWithoutExtension(AiFile) + ".bak", System.Text.Encoding.Default, True, 1)
        Dim inImpFile As New System.IO.StreamReader(AiFixFile, System.Text.Encoding.Default, True, 1)
        Dim outAiFile As New System.IO.StreamWriter(AiFile, False, System.Text.Encoding.Unicode, 1)

        ' Loading S.. table
        'S1042.  "pccafe_notpoint001.htm"
        Dim STable(50000) As String
        Dim TempRead(1) As String
        Dim value1 As Integer
        Dim value2 As String

        While inImpFile.EndOfStream <> True

            TempStr = inImpFile.ReadLine

            value1 = CInt(Mid(TempStr, 2, InStr(TempStr, ".") - 2))
            value2 = Mid(TempStr, InStr(TempStr, Chr(34)) + 1, TempStr.Length - (InStr(TempStr, Chr(34)) + 1))

            If STable(value1) <> Nothing Then
                MessageBox.Show("Duplicate value: S" + value1.ToString + ".", "Duplicate value", MessageBoxButtons.OK, MessageBoxIcon.Error)
                inAiFile.Close()
                inImpFile.Close()
                outAiFile.Close()
                Exit Sub
            End If

            If STable.Length < value1 Then
                MessageBox.Show("Very big index for array. Contact with tool owner for increase array support", "Array full", MessageBoxButtons.OK, MessageBoxIcon.Error)
                inAiFile.Close()
                inImpFile.Close()
                outAiFile.Close()
                Exit Sub
            End If

            STable(value1) = value2
        End While

        'MessageBox.Show("Loading complete. Working...")

        While inAiFile.EndOfStream <> True

            TempStr = inAiFile.ReadLine
            If TempStr <> "" Then
                If Mid(TempStr, 1, 1) = "S" And InStr(TempStr, ".") <> 0 Then
                    value1 = CInt(Mid(TempStr, 2, InStr(TempStr, ".") - 2))
                    If value1 <= STable.Length Then

                        If STable(value1) = Nothing Then
                            'MessageBox.Show("Your import file no have value: S" + value1.ToString + "." + vbNewLine + "Ignored...", "No value", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            'value2 = Mid(TempStr, InStr(TempStr, Chr(34)) + 1, TempStr.Length - (InStr(TempStr, Chr(34)) + 1))
                            TempStr = "S" + value1.ToString + "." + Chr(9) + Chr(34) + STable(value1) + Chr(34)
                        End If
                    End If
                End If
            End If
            outAiFile.WriteLine(TempStr)

        End While

        MessageBox.Show("Export complete. Target file is ai_fixed.obj", "Complete.", MessageBoxButtons.OK, MessageBoxIcon.Information)

        inAiFile.Close()
        inImpFile.Close()
        outAiFile.Close()


    End Sub

    Private Sub ButtonAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAbout.Click
        MessageBox.Show("Module for creating file with Sxxx messages from one file to export to another file." + vbNewLine + "Use for Sxxx message translation", "About module", MessageBoxButtons.OK)
    End Sub
End Class
