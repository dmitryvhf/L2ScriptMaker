Public Class AIMessageTeleportImporter

    Private Sub ButtonExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExport.Click

        Dim AiFile As String
        Dim AiExport As String
        Dim TempStr As String

        OpenFileDialog.Filter = "Ai.obj file|*.obj|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            AiFile = OpenFileDialog.FileName
            AiFileBox.Text = AiFile
        End If

        AiExport = System.IO.Path.GetDirectoryName(OpenFileDialog.FileName) + "\ai_teleport_exports.txt"
        If System.IO.File.Exists(AiExport) Then
            MessageBox.Show("Export file 'ai_teleport_exports.txt' exist. Delete and try again", "File exist", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim inAiFile As New System.IO.StreamReader(AiFile, System.Text.Encoding.Default, True, 1)
        Dim inExpFile As New System.IO.StreamWriter(AiExport, False, System.Text.Encoding.Unicode, 1)

        Dim AiClassName As String = ""
        ProgressBar.Maximum = CInt(inAiFile.BaseStream.Length)
        ProgressBar.Value = 0

        While inAiFile.EndOfStream <> True

            TempStr = inAiFile.ReadLine
            If TempStr.StartsWith("class ") = True Then
                AiClassName = TempStr
            End If

            If InStr(TempStr, "telposlist_begin") <> 0 Then
                inExpFile.WriteLine(AiClassName)
                StatusText.Text = "Export :" + AiClassName
                StatusText.Update()

                'TempStr = inAiFile.ReadLine
                While InStr(TempStr, "property_define_end") = 0

                    If InStr(TempStr, "telposlist_begin") <> 0 Then
                        TempStr = inAiFile.ReadLine
                        While InStr(TempStr, "telposlist_end") = 0

                            Dim FirstPoint As Integer = InStr(TempStr, Chr(34))
                            Dim SecondPoint As Integer = InStr(FirstPoint + 1, TempStr, Chr(34))
                            TempStr = Mid(TempStr, FirstPoint + 1, SecondPoint - FirstPoint - 1)

                            inExpFile.WriteLine(Chr(34) + TempStr + Chr(34))
                            If TempStr = "" Then
                                MessageBox.Show("You cant have empty teleport name. Use <br> for new line", "Empty name")
                            End If
                            TempStr = inAiFile.ReadLine
                        End While
                    End If
                    TempStr = inAiFile.ReadLine

                End While
                StatusText.Text = "Finding new teleport list..."

            End If

            ProgressBar.Value = CInt(inAiFile.BaseStream.Position * 100 / inAiFile.BaseStream.Length)
            Me.Update()
        End While

        ProgressBar.Value = 0
        MessageBox.Show("Export complete. Target file is 'ai_teleport_exports.txt'.", "Complete.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        StatusText.Text = "Done."

        inAiFile.Close()
        inExpFile.Close()

    End Sub

    Private Sub ButtonImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImport.Click

        Dim AiFile As String
        Dim AiImport As String
        Dim TempStr As String, TempStr2 As String

        OpenFileDialog.Filter = "Ai.obj file|*.obj|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            AiFile = OpenFileDialog.FileName
            AiFileBox.Text = AiFile
        End If

        OpenFileDialog.Filter = "Ai.obj teleport name list file|*.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            AiImport = OpenFileDialog.FileName
            AiImportBox.Text = AiImport
        End If

        Dim TeleportListNpc(0) As String
        Dim iTemp As Integer = -1
        Dim TelListFile As System.IO.StreamReader
        TelListFile = New System.IO.StreamReader(AiImport, System.Text.Encoding.Default, True, 1)
        While TelListFile.EndOfStream <> True
            TempStr = TelListFile.ReadLine
            If TempStr.StartsWith("class ") = True Then
                iTemp += 1
                Array.Resize(TeleportListNpc, iTemp + 1)
                TeleportListNpc(iTemp) = TempStr
            End If
        End While
        TelListFile.Close()

        System.IO.File.Copy(AiFile, System.IO.Path.GetFileNameWithoutExtension(AiFile) + ".bak", True)
        Dim inAiFile As New System.IO.StreamReader(System.IO.Path.GetFileNameWithoutExtension(AiFile) + ".bak", System.Text.Encoding.Default, True, 1)
        Dim oAiFile As New System.IO.StreamWriter(AiFile, False, System.Text.Encoding.Unicode, 1)

        Dim AiClassName As String = ""
        ProgressBar.Maximum = CInt(inAiFile.BaseStream.Length)
        ProgressBar.Value = 0

        While inAiFile.EndOfStream <> True

            TempStr = inAiFile.ReadLine
            If TempStr.StartsWith("class ") = True Then
                AiClassName = TempStr

                ' Enter to Import Engine
                iTemp = Array.IndexOf(TeleportListNpc, TempStr)
                If iTemp <> -1 Then

                    oAiFile.WriteLine(TempStr)

                    StatusText.Text = "Import :" + AiClassName
                    StatusText.Update()

                    TelListFile = New System.IO.StreamReader(AiImport, System.Text.Encoding.Default, True, 1)
                    While TelListFile.ReadLine <> TempStr
                        'nothing. Only find of teleport list in fix file
                    End While

                    'finding of teleport list in ai.obj
                    While InStr(TempStr, "telposlist_begin") = 0
                        TempStr = inAiFile.ReadLine
                        oAiFile.WriteLine(TempStr)
                    End While

                    ' start fixing
                    If InStr(TempStr, "telposlist_begin") <> 0 Then

                        'TempStr = inAiFile.ReadLine
                        While InStr(TempStr, "property_define_end") = 0

                            If InStr(TempStr, "telposlist_begin") <> 0 Then
                                TempStr = inAiFile.ReadLine
                                While InStr(TempStr, "telposlist_end") = 0

                                    Dim FirstPoint As Integer = InStr(TempStr, Chr(34))
                                    Dim SecondPoint As Integer = InStr(FirstPoint + 1, TempStr, Chr(34))
                                    TempStr2 = Mid(TempStr, FirstPoint + 1, SecondPoint - FirstPoint - 1)
                                    TempStr = TempStr.Replace(TempStr2, TelListFile.ReadLine.Replace(Chr(34), ""))
                                    oAiFile.WriteLine(TempStr)
                                    TempStr = inAiFile.ReadLine
                                End While
                                oAiFile.WriteLine(TempStr)
                            End If
                            TempStr = inAiFile.ReadLine
                            oAiFile.WriteLine(TempStr)
                        End While
                        StatusText.Text = "Finding new teleport list..."

                    End If
                    TelListFile.Close()
                Else
                    oAiFile.WriteLine(TempStr)
                End If

            Else
                oAiFile.WriteLine(TempStr)

            End If

            ProgressBar.Value = CInt(inAiFile.BaseStream.Position * 100 / inAiFile.BaseStream.Length)
            Me.Update()
        End While

        ProgressBar.Value = 0
        MessageBox.Show("Import complete.", "Complete.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        StatusText.Text = "Done."

        inAiFile.Close()
        oAiFile.Close()

    End Sub


    Private Sub ButtonAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAbout.Click
        MessageBox.Show("Module for creating file with teleport list and import to another file." + vbNewLine + "Use for teleport name translation", "About module", MessageBoxButtons.OK)
    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Close()
    End Sub

End Class