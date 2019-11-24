Public Class LogDNullPosFixer

    'container NULL pos[123126, 79699] at file [.\world_server.cpp], line 740

    'telposlist_begin Position
    '{"Dion Castle Town"; 15671; 142994; -2704; 8100; 2 }
    'telposlist_end

    'Dim X(1000) As Integer, Y(1000) As Integer
    Dim XY(1000) As String, Z(1000) As String
    Dim XYAi(0) As String
    Dim XYNpcpos(0) As String
    Dim XYSetting(0) As String

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim sTemp As String
        Dim iTemp As Integer

        Dim LogFiles() As String
        'Dim AiFile As String

        Dim CountMark As Integer = -1

        'Array.Clear(X, 0, X.Length)
        'Array.Clear(Y, 0, Y.Length)

        Dim inFile As System.IO.StreamReader

        FolderBrowserDialog.SelectedPath = System.Environment.CurrentDirectory
        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        LogFiles = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath, "*.log", IO.SearchOption.AllDirectories)

        If LogFiles.Length < 1 Then
            MessageBox.Show("No log files in folder. Try again and select correct folder with files from LodD\err server folder", "No log files", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If System.IO.File.Exists("ai.obj") = False Then
            MessageBox.Show("Need file AI.obj for scanning bad teleport positions", "Required AI.obj", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If System.IO.File.Exists("npcpos.txt") = False Then
            MessageBox.Show("Need file npcpos.txt for scanning bad teleport positions", "Required npcpos.txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If System.IO.File.Exists("setting.txt") = False Then
            MessageBox.Show("Need file setting.txt for scanning bad teleport positions", "Required setting.txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ProgressBar.Maximum = LogFiles.Length - 1
        ProgressBar.Value = 0

        For iTemp = 0 To LogFiles.Length - 1

            inFile = New System.IO.StreamReader(LogFiles(iTemp), System.Text.Encoding.Default, True, 1)
            ProgressBar.Value = iTemp
            StatusLabel.Text = "Scanning file... " & System.IO.Path.GetFileName(LogFiles(iTemp)) : StatusLabel.Update()
            While inFile.EndOfStream <> True
                sTemp = inFile.ReadLine

                If InStr(sTemp, "container NULL pos[") <> 0 Then
                    ' Found error
                    '03/26/2007 00:02:55.977, container NULL pos[-12694, 122776] at file [.\world_server.cpp], line [740]
                    sTemp = Mid(sTemp, InStr(sTemp, "pos[") + 4, InStr(sTemp, "]") - InStr(sTemp, "pos[") - 4).Replace(",", ";").Replace(" ", "")

                    If Array.IndexOf(XY, sTemp) = -1 Then
                        CountMark += 1
                        XY(CountMark) = sTemp
                    End If

                End If

            End While
            inFile.Close()

        Next
        ProgressBar.Value = 0

        ' SCANNING Ai.obj for bad telposlist
        'telposlist_begin Position
        '{"Dion Castle Town"; 15671; 142994; -2704; 8100; 2 }
        'telposlist_end
        Dim TelPos(5) As String

        StatusLabel.Text = "Scanning AI.obj for finding bad Z..." : StatusLabel.Update()
        inFile = New System.IO.StreamReader("ai.obj", System.Text.Encoding.Default, True, 1)
        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ProgressBar.Value = 0
        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            If InStr(sTemp, "telposlist_begin") <> 0 Then
                sTemp = inFile.ReadLine
                While InStr(sTemp, "telposlist_end") = 0

                    TelPos = sTemp.Replace(" ", "").Split(CChar(";"))

                    iTemp = Array.IndexOf(XY, (TelPos(1) & ";" & TelPos(2)))
                    If iTemp <> -1 Then
                        'Found teleport in list
                        XYAi(XYAi.Length - 1) = TelPos(1) & "; " & TelPos(2) & "; " & TelPos(3) & vbTab & sTemp.Trim
                        Array.Resize(XYAi, XYAi.Length + 1)
                        'XY(iTemp) = TelPos(1) & "; " & TelPos(2) & "; " & TelPos(3)
                        ' clear status
                        XY(iTemp) = ""
                    End If

                    sTemp = inFile.ReadLine
                End While
                ProgressBar.Value = CInt(inFile.BaseStream.Position)

            End If

        End While
        inFile.Close()
        ProgressBar.Value = 0

        'ai_parameters={[SSQLoserTeleport]=@SEAL_REVELATION;[SSQTelPosX]=[39139];[SSQTelPosY]=[143888];[SSQTelPosZ]=[-3648]}	
        StatusLabel.Text = "Scanning Npcpos.txt for finding bad Z..." : StatusLabel.Update()
        inFile = New System.IO.StreamReader("Npcpos.txt", System.Text.Encoding.Default, True, 1)
        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ProgressBar.Value = 0
        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine

            For iTemp = 0 To CountMark 'XY.Length
                If XY(iTemp) <> "" Then
                    TelPos = XY(iTemp).Replace(" ", "").Split(CChar(";"))
                    If InStr(sTemp, "[" & TelPos(0) & "]") <> 0 And InStr(sTemp, "[" & TelPos(1) & "]") <> 0 Then
                        XYNpcpos(XYNpcpos.Length - 1) = TelPos(0) & "; " & TelPos(1) & vbTab & Libraries.GetNeedParamFromStr(sTemp, "ai_parameters")
                        Array.Resize(XYNpcpos, XYNpcpos.Length + 1)
                        XY(iTemp) = ""
                        Exit For
                    End If
                End If
            Next
            ProgressBar.Value = CInt(inFile.BaseStream.Position)

        End While
        inFile.Close()
        ProgressBar.Value = 0

        'point1 = {-103125;-209047;-3357}
        StatusLabel.Text = "Scanning setting.txt for finding bad Z..." : StatusLabel.Update()
        inFile = New System.IO.StreamReader("setting.txt", System.Text.Encoding.Default, True, 1)
        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ProgressBar.Value = 0
        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine

            For iTemp = 0 To CountMark 'XY.Length
                If XY(iTemp) <> "" Then

                    If InStr(sTemp.Replace(" ", ""), XY(iTemp)) <> 0 Then
                        'TelPos = XY(iTemp).Replace(" ", "").Split(CChar(";"))
                        XYSetting(XYSetting.Length - 1) = XY(iTemp) & vbTab & sTemp.Trim
                        'XYNpcpos(XYNpcpos.Length - 1) = Libraries.GetNeedParamFromStr(sTemp, "ai_parameters")
                        Array.Resize(XYSetting, XYSetting.Length + 1)
                        XY(iTemp) = ""
                        Exit For
                    End If
                End If
            Next
            ProgressBar.Value = CInt(inFile.BaseStream.Position)

        End While
        inFile.Close()
        ProgressBar.Value = 0

        ' Save results
        StatusLabel.Text = "Save bad teleport positions to file... ~contanterNULLpos.log" : StatusLabel.Update()
        Dim outFile As New System.IO.StreamWriter("~contanterNULLpos.log", False, System.Text.Encoding.Unicode, 1)
        outFile.WriteLine("L2ScriptMaker: Error 'container NULL pos[' scanner..." & vbNewLine & Now & vbTab & "Start")

        outFile.WriteLine(vbNewLine & "AI.obj scanning log:")
        For iTemp = 0 To (XYAi.Length - 1)
            outFile.WriteLine(XYAi(iTemp))
        Next
        outFile.WriteLine(vbNewLine & "Npcpos scanning log:")
        For iTemp = 0 To (XYNpcpos.Length - 1)
            outFile.WriteLine(XYNpcpos(iTemp))
        Next
        outFile.WriteLine(vbNewLine & "Setting scanning log:")
        For iTemp = 0 To (XYSetting.Length - 1)
            outFile.WriteLine(XYSetting(iTemp))
        Next
        outFile.WriteLine(vbNewLine & "Undefined positions scanning log:")
        For iTemp = 0 To XY.Length - 1
            If XY(iTemp) <> "" Then outFile.WriteLine(XY(iTemp))
        Next

        outFile.WriteLine(vbNewLine & Now & vbTab & "End")
        outFile.Close()

        StatusLabel.Text = "Step1 complete." : StatusLabel.Update()
        MessageBox.Show("Step1 complete. Open file ~contanterNULLpos.log, teleport to this positions, get correct Z and edit file", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)


    End Sub

    Private Sub ApplyPatchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApplyPatchButton.Click

        If System.IO.File.Exists("ai.obj") = False Then
            MessageBox.Show("Need file AI.obj for fixing bad teleport positions", "Required AI.obj", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim sTemp As String
        Dim iTemp As Integer
        Dim CountMark As Integer = -1
        Dim TelPos(5) As String


        OpenFileDialog.Title = "Select file what have correct coordinates. Plain file with X;Y;Z"
        OpenFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Array.Clear(XY, 0, XY.Length)
        Dim inFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)
        While inFile.EndOfStream <> True
            sTemp = inFile.ReadLine
            If sTemp <> "" Then

                TelPos = sTemp.Replace(" ", "").Split(CChar(";"))
                CountMark += 1
                'XY(CountMark) = Join(TelPos, ";")
                XY(CountMark) = TelPos(0) & ";" & TelPos(1)
                Z(CountMark) = TelPos(2)
            End If

        End While
        inFile.Close()

        System.IO.File.Copy("ai.obj", "ai.obj.bak", True)
        inFile = New System.IO.StreamReader("ai.obj.bak", System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter("ai.obj", False, System.Text.Encoding.Unicode, 1)

        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ProgressBar.Value = 0
        While inFile.EndOfStream <> True
            sTemp = inFile.ReadLine
            outFile.WriteLine(sTemp)
            If InStr(sTemp, "telposlist_begin") <> 0 Then
                sTemp = inFile.ReadLine

                While InStr(sTemp, "telposlist_end") = 0
                    TelPos = sTemp.Replace(" ", "").Split(CChar(";"))
                    iTemp = Array.IndexOf(XY, (TelPos(1) & ";" & TelPos(2)))
                    If iTemp <> -1 Then
                        'Found teleport in list
                        '{"Dion Castle Town"; 15671; 142994; -2704; 8100; 2 }

                        'TelPos(3) = Z(iTemp)
                        'sTemp = TelPos(0) & "; " & XY(iTemp).Replace(";", "; ") & "; " & Z(iTemp) & "; " & TelPos(4) & "; " & TelPos(5)
                        'sTemp = Join(TelPos, " ;")
                        sTemp = sTemp.Replace(TelPos(3), Z(iTemp))
                    End If
                    outFile.WriteLine(sTemp)

                    sTemp = inFile.ReadLine
                End While
                outFile.WriteLine(sTemp)

                ProgressBar.Value = CInt(inFile.BaseStream.Position)

            End If

        End While
        outFile.Close()

        ProgressBar.Value = 0

        StatusLabel.Text = "Step2 complete." : StatusLabel.Update()
        MessageBox.Show("Step2 complete. Fixed file is AI.obj", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)


    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub

End Class