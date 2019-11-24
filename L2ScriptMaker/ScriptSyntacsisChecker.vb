Public Class ScriptSyntacsisChecker


    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim sFile(0) As String

        Dim inFile As System.IO.StreamReader = Nothing

        Dim sTemp As String
        Dim iTemp As Integer, iTempFiles As Integer
        Dim iLineFlag As Integer = 0

        Dim aSymbols1() As String ' = {"[]", "{}", "<>"}
        Dim aSymbols2() As String '= {""""} ', "'" , "`"

        Dim sTemp1 As String, sTemp2 As String
        Dim iFlag1 As Integer, iFlag2 As Integer

        If UseMetod1CheckBox.Checked = False And UseMetod1CheckBox.Checked = False Then
            MessageBox.Show("No one Mode selected. Select and try again", "No works.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Preparing symbols
        If Metod1TextBox.Text.Length < 2 Then
            MessageBox.Show("Metod1 symbols definition wrong", "Wrong symbols", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        aSymbols1 = Metod1TextBox.Text.Split(CChar(","))
        For iTemp = 0 To aSymbols1.Length - 1
            If aSymbols1(iTemp).Length <> 2 Then
                MessageBox.Show("Metod1 symbols '" & aSymbols1(iTemp) & "' wrong.", "Wrong symbols", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Next
        If Metod2TextBox.Text.Length < 1 Then
            MessageBox.Show("Metod2 symbols definition wrong", "Wrong symbols", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        aSymbols2 = Metod2TextBox.Text.Split(CChar(","))
        For iTemp = 0 To aSymbols2.Length - 1
            If aSymbols2(iTemp).Length <> 1 Then
                MessageBox.Show("Metod2 symbols '" & aSymbols2(iTemp) & "' wrong.", "Wrong symbols", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Next
        ' --------

        ' Folder reading
        If ReadingFolderCheckBox.Checked = False Then
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            sFile(0) = OpenFileDialog.FileName
        Else
            FolderBrowserDialog.SelectedPath = Application.StartupPath
            If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            sFile = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath, "*.*", IO.SearchOption.TopDirectoryOnly)
            If sFile.Length = 0 Then
                MessageBox.Show("Selected directory empty. Try select another directory", "Empty directory", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        Dim outFile As New System.IO.StreamWriter("l2scriptmaker.log", True, System.Text.Encoding.Unicode, 1)
        outFile.WriteLine("L2ScriptMaker. Script Syntax Checker")
        outFile.WriteLine(Now & " Start" & vbNewLine)
        outFile.WriteLine()
        If ReadingFolderCheckBox.Checked = False Then
            outFile.WriteLine("Analyzing: " & sFile(0))
        Else
            outFile.WriteLine("Analyzing: " & FolderBrowserDialog.SelectedPath)
        End If

        If ReadingFolderCheckBox.Checked = True Then
            ToolStripProgressBar.Maximum = CInt(sFile.Length - 1)
        End If

        Me.Update()

        ' MAIN Block
        For iTempFiles = 0 To sFile.Length - 1

            inFile = New System.IO.StreamReader(sFile(iTempFiles), System.Text.Encoding.Default, True, 1)
            ToolStripStatusLabel.Text = sFile(iTempFiles)

            If ReadingFolderCheckBox.Checked = False Then
                ToolStripProgressBar.Value = 0
                ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
            Else
                ToolStripProgressBar.Value = CInt(iTempFiles)
            End If

            While inFile.EndOfStream = False

                If ReadLikeLineCheckBox.Checked = False Then
                    sTemp = inFile.ReadLine
                Else
                    sTemp = inFile.ReadToEnd
                End If
                iLineFlag += 1
                If ReadingFolderCheckBox.Checked = False Then
                    ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
                End If

                StatusStrip.Update()

                ' Analyze type: 1
                If UseMetod1CheckBox.Checked = True Then
                    For iTemp = 0 To aSymbols1.Length - 1
                        sTemp1 = aSymbols1(iTemp)(0)
                        sTemp2 = aSymbols1(iTemp)(1)
                        iFlag1 = sTemp.Length - sTemp.Replace(sTemp1, "").Length
                        iFlag2 = sTemp.Length - sTemp.Replace(sTemp2, "").Length

                        If iFlag1 <> iFlag2 Then
                            ' Found symbol for checking
                            If ReadingFolderCheckBox.Checked = True Then
                                outFile.Write("File: " & System.IO.Path.GetFileName(sFile(iTempFiles)) & vbTab)
                            Else
                                outFile.Write("Line: " & iLineFlag.ToString.PadRight(15) & vbTab)
                            End If
                            outFile.Write("required symbol: ")
                            If iFlag1 < iFlag2 Then
                                outFile.WriteLine(sTemp1)
                            Else
                                outFile.WriteLine(sTemp1)
                            End If
                        End If
                    Next
                End If

                ' Analyze type: 2
                If UseMetod2CheckBox.Checked = True Then
                    For iTemp = 0 To aSymbols2.Length - 1
                        sTemp1 = aSymbols2(iTemp)
                        iFlag1 = sTemp.Length - sTemp.Replace(sTemp1, "").Length

                        If (iFlag1 / 2) <> Fix(iFlag1 / 2) Then
                            ' Found symbol for checking
                            If ReadingFolderCheckBox.Checked = True Then
                                outFile.Write("File: " & System.IO.Path.GetFileName(sFile(iTempFiles)) & vbTab)
                            Else
                                outFile.Write("Line: " & iLineFlag.ToString.PadRight(15) & vbTab)
                            End If
                            outFile.WriteLine("alone symbol: " & sTemp1)
                        End If
                    Next
                End If
            End While

            inFile.Close()
            iLineFlag = 0
        Next


        ToolStripProgressBar.Value = 0

        outFile.WriteLine()
        outFile.WriteLine(Now & " End")
        outFile.WriteLine()
        outFile.Close()

        MessageBox.Show("Complete")

    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub
End Class