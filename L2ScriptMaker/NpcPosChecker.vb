Public Class NpcPosChecker

    Dim NpcPch(25000) As String

    Private Function ValidPositionInTerriotory(ByVal aZone() As String, ByVal sSpawn As String) As Boolean

        Dim aTempPos() As String
        Dim aTemp() As String
        Dim iTemp As Integer, iTemp2 As Integer

        Dim sTemp As String = sSpawn.Substring(1, InStr(sSpawn, ")") - 2) '( 108681, -101892,   -3544) [maze_gargoyle_lad]
        sTemp = sTemp.Replace(" ", "")
        aTempPos = sTemp.Split(CChar(","))

        Dim XMin As Integer, XMax As Integer
        Dim YMin As Integer, YMax As Integer
        Dim ZMin As Integer, ZMax As Integer

        ' Step1. Scanning Territory for Min,Max
        For iTemp = 0 To aZone.Length - 1

            '{106332;-102753;-4183;-3383}
            aTemp = aZone(iTemp).Split(CChar(";"))
            For iTemp2 = 0 To aTemp.Length - 1

                If iTemp = 0 Then
                    ' Define first coordinates as default
                    XMin = CInt(aTemp(0)) : XMax = CInt(aTemp(0))
                    YMin = CInt(aTemp(1)) : YMax = CInt(aTemp(1))
                    ZMin = CInt(aTemp(2)) : ZMax = CInt(aTemp(3))
                End If

                If XMin > CInt(aTemp(0)) Then XMin = CInt(aTemp(0))
                If XMax < CInt(aTemp(0)) Then XMax = CInt(aTemp(0))

                If YMin > CInt(aTemp(1)) Then YMin = CInt(aTemp(1))
                If YMax < CInt(aTemp(1)) Then YMax = CInt(aTemp(1))

                If ZMin > CInt(aTemp(2)) Then ZMin = CInt(aTemp(2))
                If ZMax < CInt(aTemp(3)) Then ZMax = CInt(aTemp(3))
            Next
        Next

        If XMin > CInt(aTempPos(0)) Then Return False
        If XMax < CInt(aTempPos(0)) Then Return False

        If YMin > CInt(aTempPos(1)) Then Return False
        If YMax < CInt(aTempPos(1)) Then Return False

        If ZMin > CInt(aTempPos(2)) Then Return False
        If ZMax < CInt(aTempPos(2)) Then Return False

        Return True

    End Function

    Private Sub OutsiderButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutsiderButton.Click

        '09/06/2007 21:00:52.015,   MakerLog(       Ice_Merchant_Frozen_162)'s ( 108681, -101892,   -3544) [maze_gargoyle_lad] is outsider.

        'territory_begin	[Ice_Merchant_Frozen_162]	{{106332;-102753;-4183;-3383};{107332;-102753;-4183;-3383};{107332;-101753;-4183;-3383};{106332;-101753;-4183;-3383}}	territory_end
        'npcmaker_begin	[Ice_Merchant_Frozen_162]	initial_spawn=all	maximum_npc=6
        'npc_begin	[maze_gargoyle_lad]	pos={106832;-102253;-3683;59290}	total=1	respawn=60sec	Privates=[maze_gargoyle:maze_gargoyle:1:5sec;maze_gargoyle:maze_gargoyle:1:5sec]	npc_end
        'npcmaker_end

        Dim sTemp As String, sTemp2 As String

        Dim sLogPath As String
        Dim sLogFile() As String
        Dim sPosFile As String

        Dim AreaCursor As Integer = -1
        Dim AreaName(1000) As String
        Dim AreaOutsider(1000) As Integer
        Dim AreaOutsiderSpawn(1000) As String

        Dim iGrow As Integer = CInt(OutsiderOffsetTextBox.Text)

        FolderBrowserDialog.SelectedPath = Application.StartupPath
        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sLogPath = FolderBrowserDialog.SelectedPath
        sLogFile = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath, "*.log", IO.SearchOption.AllDirectories)
        If sLogFile.Length = 0 Then
            MessageBox.Show("Log folder empty. Try again and select another folder.", "Empty folder", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        OpenFileDialog.Filter = "Lineage II Server Position file (npcpos.txt)|npcpos*.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sPosFile = OpenFileDialog.FileName


        Dim iTemp As Integer, iTemp2 As Integer
        Dim aTemp() As String, sAreaName As String, sOutsiderSpawn As String

        Dim inFile As System.IO.StreamReader


        ' STEP 1: Reading Error log
        ToolStripProgressBar.Maximum = sLogFile.Length - 1
        For iTemp = 0 To sLogFile.Length - 1

            inFile = New System.IO.StreamReader(sLogFile(iTemp), System.Text.Encoding.Default, True, 1)
            ToolStripProgressBar.Value = iTemp
            While inFile.EndOfStream <> True
                sTemp = inFile.ReadLine.Trim


                '09/06/2007 21:00:52.015,   MakerLog(       Ice_Merchant_Frozen_162)'s ( 108681, -101892,   -3544) [maze_gargoyle_lad] is outsider.

                If InStr(sTemp, "is outsider.") <> 0 Then

                    ' -- Parsing ---
                    sTemp = sTemp.Remove(0, InStr(sTemp, "MakerLog(") + 8).Replace(" is outsider.", "").Trim
                    'Ice_Merchant_Frozen_162)'s ( 108681, -101892,   -3544) [maze_gargoyle_lad]
                    sAreaName = "[" & sTemp.Substring(0, InStr(sTemp, ")'s") - 1) & "]"
                    'Ice_Merchant_Frozen_162

                    sTemp2 = sTemp.Remove(0, InStr(sTemp, ")'s") + 4)
                    '( 108681, -101892,   -3544) [maze_gargoyle_lad]
                    sOutsiderSpawn = "(" & sTemp2.Replace(" ", "")
                    sTemp2 = sTemp2.Substring(0, InStr(sTemp2, "[") - 3).Replace(" ", "").Trim
                    '108681,-101892,-3544

                    aTemp = sTemp2.Trim.Split(CChar(","))

                    iTemp2 = Array.IndexOf(AreaName, sAreaName)
                    If iTemp2 = -1 Then

                        ' Not found in territory listing. Add new
                        AreaCursor += 1
                        If AreaCursor >= AreaName.Length Then
                            Array.Resize(AreaName, AreaName.Length + 1)
                            Array.Resize(AreaOutsider, AreaOutsider.Length + 1)
                            Array.Resize(AreaOutsiderSpawn, AreaOutsiderSpawn.Length + 1)
                        End If
                        AreaName(AreaCursor) = sAreaName
                        AreaOutsider(AreaCursor) = CInt(aTemp(2))
                        AreaOutsiderSpawn(AreaCursor) = sOutsiderSpawn

                    Else

                        ' Found in territory fix listing. Check quote. More or not.
                        If AreaOutsider(iTemp2) < CDbl(aTemp(2)) Then
                            AreaOutsider(iTemp2) = CInt(aTemp(2))
                        End If

                    End If

                End If
            End While
            inFile.Close()
        Next
        ToolStripProgressBar.Value = 0

        ' STEP 2: Reading and fixing npcpos.txt
        If System.IO.File.Exists(sPosFile & ".bak") = True Then
            If MessageBox.Show("Overwrite previous backup file?", "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        End If
        System.IO.File.Copy(sPosFile, sPosFile & ".bak", True)

        inFile = New System.IO.StreamReader(sPosFile & ".bak", System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter(sPosFile, False, System.Text.Encoding.Unicode, 1)

        Dim outLog As New System.IO.StreamWriter(sPosFile & "_npccheck.log", True, System.Text.Encoding.Unicode, 1)
        outLog.WriteLine("Lineage II ScriptMaker: NpcPos Outsider Checker: Start at " & Now & vbNewLine & "in file: " & sPosFile & vbNewLine)

        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        Dim FixCount As Integer = 0

        Dim aTemp2() As String

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            'territory_begin	[Ice_Merchant_Frozen_162]	{{106332;-102753;-4183;-3383};{107332;-102753;-4183;-3383};{107332;-101753;-4183;-3383};{106332;-101753;-4183;-3383}}	territory_end
            'npcmaker_begin	[Ice_Merchant_Frozen_162]	initial_spawn=all	maximum_npc=6
            'npc_begin	[maze_gargoyle_lad]	pos={106832;-102253;-3683;59290}	total=1	respawn=60sec	Privates=[maze_gargoyle:maze_gargoyle:1:5sec;maze_gargoyle:maze_gargoyle:1:5sec]	npc_end
            'npcmaker_end

            If sTemp.StartsWith("territory_begin") = True Then

                sAreaName = sTemp.Substring(InStr(sTemp, "[") - 1, InStr(sTemp, "]") - InStr(sTemp, "[") + 1)
                iTemp = Array.IndexOf(AreaName, sAreaName)
                If iTemp <> -1 Then

                    sTemp2 = sTemp.Substring(InStr(sTemp, "{"), InStr(sTemp, "territory_end") - 1 - InStr(sTemp, "{"))
                    sTemp2 = sTemp2.Replace("};{", "|").Replace("{", "").Replace("}", "")
                    aTemp = sTemp2.Split(CChar("|"))
                    aTemp2 = aTemp(0).Split(CChar(";"))

                    ' Checking valid territory
                    If ValidPositionInTerriotory(aTemp, AreaOutsiderSpawn(iTemp)) = True Then '(CInt(aTemp2(2)) < AreaOutsider(iTemp)) And (AreaOutsider(iTemp) < CInt(aTemp2(3))) Then
                        '{106332;-102753;-4183;-3383}
                        'pos={106832;-102253;-3683;xxx}
                        '-4183 < -3683 < -3383 - valid

                        ' VALID position

                        AreaOutsider(iTemp) = AreaOutsider(iTemp) + iGrow
                        If CInt(aTemp2(3)) < AreaOutsider(iTemp) Then
                            sTemp = sTemp.Replace(";" & aTemp2(3) & "}", ";" & AreaOutsider(iTemp) & "}")
                            outLog.WriteLine(("Outsider Territory " & sAreaName).PadRight(60, CChar(".")) & " Fixed. Z2 up " & aTemp2(3) & " -> " & AreaOutsider(iTemp) & vbTab & "| Spawn: " & AreaOutsiderSpawn(iTemp))
                            FixCount += 1
                        ElseIf CInt(aTemp2(3)) = AreaOutsider(iTemp) Then
                            ' Already fixed. Ignored

                        ElseIf CInt(aTemp2(3)) > AreaOutsider(iTemp) Then
                            outLog.WriteLine(("Outsider Territory " & sAreaName).PadRight(60, CChar(".")) & " Ignored. Required bigger grow value or analysing spawn. Old Z2: " & aTemp2(3) & " New Z2: " & AreaOutsider(iTemp) & " (with +" & iGrow & ")" & vbTab & "| Spawn: " & AreaOutsiderSpawn(iTemp))
                        End If

                    Else
                        ' InVALID Position
                        outLog.WriteLine(("Outsider Territory " & sAreaName).PadRight(60, CChar(".")) & " Ignored. NPC Spawn not in territory. Required remading territory." & vbTab & "| Spawn: " & AreaOutsiderSpawn(iTemp))
                    End If

                End If
            End If

            outFile.WriteLine(sTemp)
        End While

        outLog.WriteLine()

        ToolStripProgressBar.Value = 0
        outLog.Close()
        outFile.Close()
        inFile.Close()

        MessageBox.Show("Complete. Fixed " & FixCount & " spawn's.")

    End Sub

    Private Sub QuotButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuotButton.Click

        Dim sTemp As String, sTemp2 As String

        Dim sLogPath As String
        Dim sLogFile() As String
        Dim sPosFile As String

        Dim AreaName(0) As String
        Dim AreaQuot(0) As Integer

        FolderBrowserDialog.SelectedPath = Application.StartupPath
        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sLogPath = FolderBrowserDialog.SelectedPath
        sLogFile = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath, "*.log", IO.SearchOption.AllDirectories)
        If sLogFile.Length = 0 Then
            MessageBox.Show("Log folder empty. Try again and select another folder.", "Empty folder", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        OpenFileDialog.Filter = "Lineage II Server Position file (npcpos.txt)|npcpos*.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sPosFile = OpenFileDialog.FileName


        Dim iTemp As Integer, iTemp2 As Integer
        Dim aTemp() As String, sAreaName As String

        Dim inFile As System.IO.StreamReader


        ' STEP 1: Reading Error log
        ToolStripProgressBar.Maximum = sLogFile.Length - 1
        For iTemp = 0 To sLogFile.Length - 1

            inFile = New System.IO.StreamReader(sLogFile(iTemp), System.Text.Encoding.Default, True, 1)
            ToolStripProgressBar.Value = iTemp
            While inFile.EndOfStream <> True
                sTemp = inFile.ReadLine.Trim

                '07/29/2007 23:39:38.283, [Monastery_Silence_177] failed to increase total npc because of npc quota [3 / 2]
                If InStr(sTemp, "because of npc quota") <> 0 Then

                    '[Monastery_Silence_177][3 / 2]
                    sTemp = sTemp.Remove(0, InStr(sTemp, "[") - 1).Replace(" failed to increase total npc because of npc quota ", "")
                    sAreaName = sTemp.Substring(0, InStr(sTemp, "]"))

                    sTemp2 = sTemp.Replace(sAreaName, "").Replace("[", "").Replace("]", "").Replace(" ", "")
                    aTemp = sTemp2.Trim.Split(CChar("/"))

                    iTemp2 = Array.IndexOf(AreaName, sAreaName)
                    If iTemp2 = -1 Then

                        ' Not found in territory listing. Add new
                        Array.Resize(AreaName, AreaName.Length + 1)
                        AreaName(AreaName.Length - 1) = sAreaName


                        Array.Resize(AreaQuot, AreaQuot.Length + 1)
                        AreaQuot(AreaQuot.Length - 1) = CInt(aTemp(0))

                    Else

                        ' Found in territory fix listing. Check quote. More or not.
                        If AreaQuot(iTemp2) < CDbl(aTemp(0)) Then
                            AreaQuot(iTemp2) = CInt(aTemp(0))
                        End If

                    End If

                End If
            End While
            inFile.Close()
        Next
        ToolStripProgressBar.Value = 0

        ' STEP 2: Reading and fixing npcpos.txt
        If System.IO.File.Exists(sPosFile & ".bak") = True Then
            If MessageBox.Show("Overwrite previous backup file?", "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        End If
        System.IO.File.Copy(sPosFile, sPosFile & ".bak", True)

        inFile = New System.IO.StreamReader(sPosFile & ".bak", System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter(sPosFile, False, System.Text.Encoding.Unicode, 1)

        Dim outLog As New System.IO.StreamWriter(sPosFile & "_npccheck.log", True, System.Text.Encoding.Unicode, 1)
        outLog.WriteLine("Lineage II ScriptMaker: NpcPos Quot Checker: Start at " & Now & vbNewLine & "in file: " & sPosFile & vbNewLine)

        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        Dim FixCount As Integer = 0

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            'npcmaker_begin	[primeval_isle_250]	initial_spawn=all	maximum_npc=4
            'npcmaker_end
            'npcmaker_ex_begin	[aden07_tb2519_26]	name=[aden07_tb26_m1]	ai=[random_spawn]	maximum_npc=4
            'npcmaker_ex_end

            If sTemp.StartsWith("npcmaker_") = True Then
                If sTemp.StartsWith("npcmaker_end") = False And sTemp.StartsWith("npcmaker_ex_end") = False Then

                    sTemp2 = sTemp.Substring(InStr(sTemp, "[") - 1, InStr(sTemp, "]") - InStr(sTemp, "[") + 1)
                    iTemp = Array.IndexOf(AreaName, sTemp2)
                    If iTemp <> -1 Then

                        iTemp2 = CInt(Libraries.GetNeedParamFromStr(sTemp, "maximum_npc"))
                        If iTemp2 < AreaQuot(iTemp) Then
                            sTemp = sTemp.Remove(InStr(sTemp, "maximum_npc") + 10, sTemp.Length - (InStr(sTemp, "maximum_npc") + 10))
                            sTemp = sTemp & "=" & AreaQuot(iTemp)

                            outLog.WriteLine(sTemp2 & " increased to " & AreaQuot(iTemp))
                            FixCount += 1
                        End If

                    End If
                End If
            End If

            outFile.WriteLine(sTemp)
        End While

        outLog.WriteLine()

        ToolStripProgressBar.Value = 0
        outLog.Close()
        outFile.Close()
        inFile.Close()

        MessageBox.Show("Complete. Fixed " & FixCount & " spawn's.")


    End Sub


    Private Sub DBNameButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBNameButton.Click

        Dim sTemp As String = ""
        Dim CheckFile As String
        Dim aLine() As String
        Dim DbNames(0) As String
        Dim DbName As String

        OpenFileDialog.Filter = "Lineage II Npcpos script|npcpos.txt"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        CheckFile = OpenFileDialog.FileName

        Dim outLog As New System.IO.StreamWriter(CheckFile & "_npccheck.log", True, System.Text.Encoding.Unicode, 1)
        outLog.WriteLine("Lineage II ScriptMaker: NpcPos DBName Checker: Start at " & Now & vbNewLine & "in file: " & CheckFile & vbNewLine)

        Dim FilePch As New System.IO.StreamReader(CheckFile)
        ToolStripProgressBar.Maximum = CInt(FilePch.BaseStream.Length)
        ToolStripProgressBar.Value = 0
        While FilePch.EndOfStream <> True

            sTemp = FilePch.ReadLine

            'npc_ex_begin	[heart_of_volcano]	pos={189872;-105152;-724;49000}	total=1	respawn=1min
            'dbname=[heart_of_volcano]	ai_parameters={[TelPosX]=[204187];[TelPosY]=[-111864];[TelPosZ]=[34]}	npc_ex_end
            If InStr(sTemp, "dbname") <> 0 Then
                sTemp = sTemp.Replace(" ", " ").Replace(" ", Chr(9))
                aLine = sTemp.Split(Chr(9))
                DbName = Libraries.GetNeedParamFromStr(sTemp, "dbname")

                ' Check duplicate in DB list
                If Array.IndexOf(DbNames, DbName) <> -1 Then
                    outLog.WriteLine(vbNewLine & sTemp)
                    outLog.WriteLine("Found dublicate of DB Name for dbname: " & vbNewLine & "Npc: " & aLine(1) & vbTab & "dbname=" & DbName)
                End If

                ' Add to dbnames list
                DbNames(DbNames.Length - 1) = DbName
                Array.Resize(DbNames, DbNames.Length + 1)

                ' Check name npc and dbname
                If aLine(1) <> DbName Then
                    outLog.WriteLine(vbNewLine & sTemp)
                    outLog.WriteLine("DBName different with NpcName. Perhaps error?" & vbNewLine & "Npc: " & aLine(1) & vbTab & "dbname=" & DbName)
                End If

            End If

            ToolStripProgressBar.Value = CInt(FilePch.BaseStream.Position)

        End While

        MessageBox.Show("Checking complete. See log about found errors.")
        ToolStripProgressBar.Value = 0

        FilePch.Close()
        outLog.WriteLine(vbNewLine & "NpcPos DBName Checker: Finished at " & Now & vbNewLine)
        outLog.Close()

    End Sub

    Private Sub AiPrivatesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AiPrivatesButton.Click

        Dim TempStr As String = ""

        Dim TempStr2(39) As String ' 4 on each private
        Dim CheckFile As String
        Dim iTemp As Integer
        Dim LastClass As String = ""

        OpenFileDialog.Filter = "Lineage II AI.obj config|ai.obj|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        CheckFile = OpenFileDialog.FileName

        If PchLoader() = -1 Then Exit Sub

        Dim outLog As New System.IO.StreamWriter(CheckFile & "_npccheck.log", True, System.Text.Encoding.Unicode, 1)
        outLog.WriteLine("Lineage II ScriptMaker: AI.obj Privates Checker: Start at " & Now & vbNewLine & "in file: " & CheckFile & vbNewLine)

        Dim FilePch As New System.IO.StreamReader(CheckFile)
        ToolStripProgressBar.Maximum = CInt(FilePch.BaseStream.Length)
        ToolStripProgressBar.Value = 0
        Dim iTemp1 As Integer, iTemp2 As Integer
        While FilePch.EndOfStream <> True

            TempStr = FilePch.ReadLine
            If TempStr.StartsWith("class ") = True Then LastClass = TempStr
            'Privates=[talakin_archer:talakin_archer:1:0sec;talakin_raider:talakin_raider:1:0sec]
            'string Privates "orc:party_private:1:20sec"
            iTemp1 = InStr(TempStr, "string Privates """)
            If iTemp1 > 0 Then
                iTemp2 = InStr(iTemp1, TempStr, """")
                TempStr2 = Mid(TempStr, iTemp2 + 1, TempStr.Length - iTemp2 - 1).Replace(";", ":").Split(CChar(":"))

                If TempStr2.Length > 1 Then
                    For iTemp = 0 To TempStr2.Length - 1 Step 4
                        If Array.IndexOf(NpcPch, TempStr2(iTemp)) = -1 Then
                            ' not found
                            outLog.WriteLine("Error in :" & vbNewLine & LastClass)
                            outLog.WriteLine("Not found privates '" & TempStr2(iTemp) & "' in " & vbNewLine & TempStr)
                        End If
                    Next
                End If

                Array.Clear(TempStr2, 0, TempStr2.Length)
            End If
            ToolStripProgressBar.Value = CInt(FilePch.BaseStream.Position)

        End While

        MessageBox.Show("Checking complete. See log about found errors.")
        ToolStripProgressBar.Value = 0

        FilePch.Close()
        outLog.WriteLine(vbNewLine & "AI.obj Privates Checker: Finished at " & Now & vbNewLine)
        outLog.Close()

    End Sub

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim TempStr As String = ""

        Dim TempStr2(39) As String ' 4 on each private
        Dim WorkStr As String = "", CheckFile As String
        Dim iTemp As Integer

        OpenFileDialog.Filter = "Lineage II Npcpos script|npcpos.txt"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        CheckFile = OpenFileDialog.FileName

        If PchLoader() = -1 Then Exit Sub

        Dim outLog As New System.IO.StreamWriter(CheckFile & "_npccheck.log", True, System.Text.Encoding.Unicode, 1)
        outLog.WriteLine("Lineage II ScriptMaker: Npcpos Privates Checker: Start at " & Now & vbNewLine & "in file: " & CheckFile & vbNewLine)

        Dim FilePch As New System.IO.StreamReader(CheckFile)
        ToolStripProgressBar.Maximum = CInt(FilePch.BaseStream.Length)
        ToolStripProgressBar.Value = 0
        Dim iTemp1 As Integer, iTemp2 As Integer
        While FilePch.EndOfStream <> True

            TempStr = FilePch.ReadLine
            'Privates=[talakin_archer:talakin_archer:1:0sec;talakin_raider:talakin_raider:1:0sec]
            '        string Privates "orc:party_private:1:20sec"
            iTemp1 = InStr(TempStr, "Privates=")
            If iTemp1 > 0 Then
                iTemp2 = InStr(iTemp1, TempStr, "]")
                TempStr = Mid(TempStr, iTemp1, iTemp2 - iTemp1 + 1)
                WorkStr = TempStr.Replace("Privates=[", "").Replace("]", "").Replace(";", ":")
                TempStr2 = WorkStr.Split(CChar(":"))

                For iTemp = 0 To TempStr2.Length - 1 Step 4
                    If Array.IndexOf(NpcPch, TempStr2(iTemp)) = -1 Then
                        ' not found
                        outLog.WriteLine("Not found privates '" & TempStr2(iTemp) & "' in " & vbNewLine & TempStr)
                    End If
                Next
                Array.Clear(TempStr2, 0, TempStr2.Length)
            End If
            ToolStripProgressBar.Value = CInt(FilePch.BaseStream.Position)

        End While

        MessageBox.Show("Checking complete. See log about found errors.")
        ToolStripProgressBar.Value = 0

        FilePch.Close()
        outLog.WriteLine(vbNewLine & "Npcpos Privates Checker: Finished at " & Now & vbNewLine)
        outLog.Close()

    End Sub

    Private Sub MakerNameButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MakerNameButton.Click

        OpenFileDialog.Filter = "Lineage II Npcpos script|npcpos.txt"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim outLog As New System.IO.StreamWriter(OpenFileDialog.FileName & "_npccheck.log", True, System.Text.Encoding.Unicode, 1)
        outLog.WriteLine("Lineage II ScriptMaker: Npcpos MakerName Checker: Start at " & Now)


        Dim NpcPosFile As New System.IO.StreamReader(OpenFileDialog.FileName)
        Dim sTemp As String, sName As String, sAiParam As String

        ToolStripProgressBar.Maximum = CInt(NpcPosFile.BaseStream.Length)
        ToolStripProgressBar.Value = 0

        While NpcPosFile.EndOfStream <> True

            'npcmaker_ex_begin	[oren07_npc1819_gd02]	name=[oren_npc1819_gd0201]	ai=[default_maker]	maximum_npc=2
            'npcmaker_ex_begin	[giran08_2124_008]	name=[t21_24_00804]	ai=[maker_instant_spawn_random]	ai_parameters={[maker_name1]=[t21_24_00803];[maker_name2]=[t21_24_00804];[maker_cnt]=2;[respawn_time]=132;[on_start_spawn]=0}	maximum_npc=1

            sTemp = NpcPosFile.ReadLine

            sName = Libraries.GetNeedParamFromStr(sTemp, "name")
            If sName <> "" Then

                sAiParam = Libraries.GetNeedParamFromStr(sTemp, "ai_parameters")
                If sAiParam <> "" And InStr(sAiParam, "[maker_cnt]") <> 0 Then
                    If InStr(sAiParam, sName) = 0 Then
                        outLog.WriteLine(vbNewLine & "Not found definition for maker in line" & vbNewLine & sTemp & vbNewLine & "for maker_name=" & sName)
                    End If
                End If
            End If

            ToolStripProgressBar.Value = CInt(NpcPosFile.BaseStream.Position)

        End While

        MessageBox.Show("Checking complete. See log about found errors.")
        ToolStripProgressBar.Value = 0

        NpcPosFile.Close()
        outLog.WriteLine(vbNewLine & "Npcpos MakerName Checker: Finished at " & Now & vbNewLine)
        outLog.Close()

    End Sub

    Private Function PchLoader() As Short

        Dim TempStr As String = ""
        Dim TempStr2(2) As String

        If System.IO.File.Exists("npc_pch.txt") = False Then
            OpenFileDialog.FileName = ""
            OpenFileDialog.Filter = "Lineage II Server Npc_pch config file|npc_pch.txt"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Return -1
        Else
            OpenFileDialog.FileName = "npc_pch.txt"
        End If

        Array.Clear(NpcPch, 0, NpcPch.Length)

        ' Loading all items
        ToolStripProgressBar.Value = 0
        Dim FilePch As New System.IO.StreamReader(OpenFileDialog.FileName)
        ToolStripProgressBar.Maximum = CInt(FilePch.BaseStream.Length)
        While FilePch.EndOfStream <> True
            TempStr = Trim(FilePch.ReadLine)
            TempStr = Replace(TempStr, " ", "")
            TempStr = Replace(TempStr, Chr(9), "")
            TempStr2 = TempStr.Split(Chr(61)) ' =

            If NpcPch.Length < (CInt(TempStr2(1)) - 1000000) Then
                Array.Resize(NpcPch, (CInt(TempStr2(1)) - 1000000) + 1)
            End If
            NpcPch(CInt(TempStr2(1)) - 1000000) = TempStr2(0).Replace("[", "").Replace("]", "")

            ToolStripProgressBar.Value = CInt(FilePch.BaseStream.Position)
            Me.Update()
        End While
        Me.Update()

        Array.Clear(TempStr2, 0, TempStr2.Length)

        FilePch.Close()

        'MessageBox.Show("All source id's loaded.")
        ToolStripProgressBar.Value = 0
    End Function

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub


End Class