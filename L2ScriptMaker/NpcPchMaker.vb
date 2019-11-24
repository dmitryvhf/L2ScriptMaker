Public Class NpcPchMaker

    'Dim TabSymbol As String = Chr(9)
    Dim TabSymbol As String = " "

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim TempStr As String
        'Dim FirstPos, SecondPos As Integer
        Dim NpcDataFile, NpcDataDir As String
        Dim NpcData() As String

        ProgressBar.Value = 0

        OpenFileDialog.InitialDirectory = System.Environment.CurrentDirectory
        OpenFileDialog.Filter = "Lineage II NpcData config|npcdata.txt|All files (*.*)|*.*"
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        NpcDataFile = OpenFileDialog.FileName
        NpcDataDir = System.IO.Path.GetDirectoryName(NpcDataFile)

        Dim inNpcData As New System.IO.StreamReader(NpcDataFile, System.Text.Encoding.Default, True, 1)

        If System.IO.File.Exists(NpcDataDir + "\npc_pch.txt") = True Then
            If MessageBox.Show("File npc_pch.txt exist. Overwrite?", "Overwrite?", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        End If

        Dim oPchFile As System.IO.Stream = New System.IO.FileStream(NpcDataDir + "\npc_pch.txt", _
                IO.FileMode.Create, IO.FileAccess.Write)
        Dim outItemPchData As System.IO.StreamWriter = New System.IO.StreamWriter(oPchFile, _
                System.Text.Encoding.Unicode)

        ' Logging system
        Dim oLogFile As New System.IO.StreamWriter(NpcDataDir + "\npc_pch.log", True, System.Text.Encoding.Unicode, 1)
        oLogFile.WriteLine("L2ScriptMaker NpcData PCH Generator" & vbNewLine & Now & vbTab & "Started")
        Dim isError As Boolean = False


        While inNpcData.BaseStream.Position <> inNpcData.BaseStream.Length

            TempStr = Replace(inNpcData.ReadLine, Chr(9), " ")

            If TempStr <> Nothing Or Mid(TempStr, 1, 2) = "//" Then
                ' tabs and spaces correction
                While InStr(TempStr, "  ") <> 0
                    TempStr = Replace(TempStr, "  ", " ")
                End While
                NpcData = TempStr.Split(Chr(32))

                If InStr(NpcData(0), "npc_begin") <> 0 Then
                    outItemPchData.Write(NpcData(3) & " " & "=" & " ")
                    outItemPchData.WriteLine(CStr(1000000 + CInt(NpcData(2))))

                    If NpcData(3).Replace("[", "").Replace("]", "").Length >= 25 Then
                        ' Logging about wrong file name
                        oLogFile.WriteLine("Npcname too long: " & NpcData(3) & vbTab & "Fixed name is: [" & NpcData(3).Substring(1, 24) & "]")
                        isError = True
                    End If
                Else
                    ' It's set or another/unknown
                End If

            End If

            ProgressBar.Value = CInt(inNpcData.BaseStream.Position * 100 / inNpcData.BaseStream.Length)

        End While
        oLogFile.WriteLine("L2ScriptMaker NpcData PCH Generator" & vbNewLine & Now & vbTab & "Started")
        oLogFile.Close()
        inNpcData.Close()
        outItemPchData.Close()
        System.IO.File.Create(NpcDataDir + "\npc_pch2.txt")

        If isError = False Then
            TempStr = "Complete. Success."
        Else
            TempStr = "Complete. Found errors! Check log file."
        End If

        ProgressBar.Value = 0
        MessageBox.Show(TempStr)

    End Sub

    Private Sub NpcCacheScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NpcCacheScript.Click

        '10      Felim Lizardman Scout

        OpenFileDialog.FileName = ""
        OpenFileDialog.Filter = "Lineage II config (npcdata.txt)|npcdata.txt|All files (*.*)|*.*"
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        Dim inEFile As System.IO.StreamReader
        Try
            inEFile = New System.IO.StreamReader(System.IO.Path.GetDirectoryName(OpenFileDialog.FileName) + "\npcname-e.txt", System.Text.Encoding.Default, True, 1)
        Catch ex As Exception
            MessageBox.Show("You must have npcname-e.txt in work folder for generation npccache.txt file. Put and try again.")
            Exit Sub
        End Try

        ' Initialization
        ProgressBar.Value = 0
        Dim inFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)
        Dim oAiFile As System.IO.Stream = New System.IO.FileStream(System.IO.Path.GetDirectoryName(OpenFileDialog.FileName) + "\npccache.txt", _
            IO.FileMode.Create, IO.FileAccess.Write)
        Dim outAiData As System.IO.StreamWriter = New System.IO.StreamWriter(oAiFile, _
                System.Text.Encoding.Unicode, 1)

        Dim ReadStr As String


        ProgressBar.Value = 0
        ProgressBar.Maximum = CInt(inEFile.BaseStream.Length)
        Dim NpcDB(15000) As String '0- id, 1 - name, 2 - consume, 3 - type (for quest)
        Dim NpcDBMarker As Integer = 0
        Dim CommentName As String

        Dim ReadSplitStr() As String

        ' Creating ID Table from NPCdata.txt
        While inEFile.EndOfStream <> True

            ReadStr = inEFile.ReadLine

            If ReadStr <> Nothing Then
                If Mid(ReadStr, 1, 2) <> "//" Then
                    'ReadSplitStr = ReadStr.Split(Chr(9))
                    NpcDBMarker = CInt(Libraries.GetNeedParamFromStr(ReadStr, "id"))
                    If NpcDBMarker >= NpcDB.Length Then
                        Array.Resize(NpcDB, NpcDBMarker + 1)
                    End If
                    NpcDB(NpcDBMarker) = Libraries.GetNeedParamFromStr(ReadStr, "name") 'ReadSplitStr(4).Replace("name=[", "").Replace("]", "")
                End If
            End If
            ProgressBar.Value = CInt(inFile.BaseStream.Position * 100 / inFile.BaseStream.Length)
        End While

        ProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ProgressBar.Value = 0

        Do While inFile.BaseStream.Position <> inFile.BaseStream.Length

            ReadStr = Replace(inFile.ReadLine, Chr(9), Chr(32))

            If ReadStr.Trim <> "" And ReadStr.StartsWith("//") = False Then
                ' tabs and spaces correction
                While InStr(ReadStr, "  ") <> 0
                    ReadStr = Replace(ReadStr, "  ", Chr(32))
                End While
                ReadSplitStr = ReadStr.Split(Chr(32))

                'Find Npc in Npcname-e
                ReadSplitStr(3) = ReadSplitStr(3).Substring(1, ReadSplitStr(3).Length - 2)
                CommentName = ReadSplitStr(3)

                NpcDBMarker = CInt(ReadSplitStr(2))
                If NpcDBMarker <= NpcDB.Length Then
                    If NpcDB(CInt(ReadSplitStr(2))) <> "" Then
                        CommentName = NpcDB(CInt(ReadSplitStr(2)))
                    End If
                End If

                ReadStr = ReadSplitStr(2) & vbTab & CommentName
                outAiData.WriteLine(ReadStr)
            End If

            ProgressBar.Value = CInt(inFile.BaseStream.Position)
        Loop

        MessageBox.Show("npccache.txt Complete")
        ProgressBar.Value = 0
        inFile.Close()
        outAiData.Close()
    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub
End Class