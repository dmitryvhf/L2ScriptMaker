Public Class L2J_NpcPos

    Private Structure NpcSpawn

        '  `id` int(11) NOT NULL auto_increment,
        '  `location` varchar(40) NOT NULL default '',
        '  `count` int(9) NOT NULL default '0',
        '  `npc_templateid` int(9) NOT NULL default '0',
        '  `locx` int(9) NOT NULL default '0',
        '  `locy` int(9) NOT NULL default '0',
        '  `locz` int(9) NOT NULL default '0',
        '  `randomx` int(9) NOT NULL default '0',
        '  `randomy` int(9) NOT NULL default '0',
        '  `heading` int(9) NOT NULL default '0',
        '  `respawn_delay` int(9) NOT NULL default '0',
        '  `loc_id` int(9) NOT NULL default '0',
        '  `periodOfDay` decimal(2,0) default '0',

        Dim npc_templateid As Integer
        Dim locx As Integer
        Dim locy As Integer
        Dim locz As Integer
        Dim heading As Integer
        Dim respawn_delay As Integer
        Dim periodOfDay As Boolean


    End Structure


    Private Sub ButtonPTStoL2J_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPTStoL2J.Click

        Dim sTemp As String
        Dim aTemp() As String


        Dim iCount As Integer = 0, iCountLimit As Integer = 100

        If TextBoxL2JMaxLines.Text <> "" Then
            Try
                iCountLimit = CInt(CUInt(TextBoxL2JMaxLines.Text))
            Catch ex As Exception
                MessageBox.Show("Wrong MaxLines count number")
                Exit Sub
            End Try
        End If

        Dim inSpawnFile As System.IO.StreamReader

        ' LOADING npc_pch.txt
        If System.IO.File.Exists("npc_pch.txt") = False Then
            MessageBox.Show("npc_pch.txt not found", "Need npc_pch.txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim aNpcPch(40000) As String
        inSpawnFile = New System.IO.StreamReader("npc_pch.txt", System.Text.Encoding.Default, True, 1)
        ToolStripProgressBar.Maximum = CInt(inSpawnFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading npc_pch.txt ..."

        While inSpawnFile.EndOfStream <> True

            sTemp = inSpawnFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inSpawnFile.BaseStream.Position)
            If sTemp = "" Or sTemp.StartsWith("//") = True Or sTemp.StartsWith("[") = False Then Continue While

            '[pet_wolf_a] = 1012077
            sTemp = sTemp.Replace(" ", "").Replace(Chr(9), "")
            aTemp = sTemp.Split(CChar("="))
            Try
                aNpcPch(CInt(aTemp(1)) - 1000000) = aTemp(0)
            Catch ex As Exception
                MessageBox.Show("Error in loading npc_pch.txt. Last reading line:" & vbNewLine & sTemp)
                inSpawnFile.Close()
                Exit Sub
            End Try

        End While
        inSpawnFile.Close()
        ToolStripProgressBar.Value = 0

        OpenFileDialog.Filter = "PTS spawn (npcpos.txt)|npcpos.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        inSpawnFile = New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter("spawnlist_new.sql", False, System.Text.Encoding.Unicode, 1)

        ToolStripProgressBar.Maximum = CInt(inSpawnFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading npcpos.txt..."

        Dim sLastZoneName As String, iTemp As Integer
        Dim sTempSpawn As String = "", sTempNpc As String
        Dim bIsNight As Char = CChar("0"), bEventNpc As Boolean = False
        Dim sLastNpcName As String
        
        While inSpawnFile.EndOfStream <> True

            sTemp = inSpawnFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inSpawnFile.BaseStream.Position)
            If sTemp = "" Or sTemp.StartsWith("//") = True Then Continue While

            'npcmaker_ex_begin	[oren22_2219_a01]	name=[oren22_2219_a01m1]	ai=[default_maker]	maximum_npc=50	
            'npcmaker_ex_begin	[rune09_npc2116_05]	name=[rune09_npc2116_0502]	ai=[on_day_night_spawn]	ai_parameters={[IsNight]=1}	maximum_npc=1	
            'npcmaker_ex_begin	[schuttgart03_npc2312_tb02]	name=[schuttgart03_npc2312_tb02m1]	ai=[event_maker]	ai_parameters={[EventName]=[event_treasure_box]}	maximum_npc=9	
            If sTemp.StartsWith("npcmaker_begin") = True Or sTemp.StartsWith("npcmaker_ex_begin") = True Then
                aTemp = sTemp.Split(Chr(9))
                sLastZoneName = aTemp(1).Replace("[", "").Replace("]", "")
                If sTemp.IndexOf("[IsNight]=1") > 0 Then
                    bIsNight = CChar("1")
                Else
                    bIsNight = CChar("0")
                End If
                If Libraries.GetNeedParamFromStr(sTemp, "ai") = "[event_maker]" And sTemp.IndexOf("[EventName]=") > 0 Then
                    bEventNpc = True
                Else
                    bEventNpc = False
                End If
                Continue While
            End If

            'npc_ex_begin	[xel_trainer_mage]	pos={88347;56413;-3495;49152}	total=1	respawn=90sec	ai_parameters={[trainer_id]=1;[direction]=49152}	is_chase_pc=1000	npc_ex_end	
            If sTemp.StartsWith("npc_begin") = True Or sTemp.StartsWith("npc_ex_begin") = True Then
                sTempSpawn = ""
                aTemp = sTemp.Split(Chr(9))
                sTempNpc = aTemp(1).Replace("[", "").Replace("]", "")
                sLastNpcName = aTemp(1)

                ' 1 - area name
                sTempSpawn &= "('" & sLastZoneName & "',"

                ' 2 - total
                sTempNpc = Libraries.GetNeedParamFromStr(sTemp, "total")
                If Libraries.GetNeedParamFromStr(sTemp, "total") = "" Then
                    If CheckBoxShowAll.Checked = True Then outFile.WriteLine("-- npc name " & sLastNpcName & " not found count")
                    Continue While
                End If
                sTempSpawn &= Libraries.GetNeedParamFromStr(sTemp, "total") & ","

                ' 3 - npcname
                iTemp = Array.IndexOf(aNpcPch, aTemp(1))
                If iTemp = -1 Then
                    If CheckBoxShowAll.Checked = True Then outFile.WriteLine("-- npc name " & sLastNpcName & " not found in npc_pch")
                    Continue While
                End If
                sTempSpawn &= iTemp & ","

                ' 4,5,6,7,8,9 - x,y,z,0,0,heading
                sTempNpc = Libraries.GetNeedParamFromStr(sTemp, "pos").Replace("{", "").Replace("}", "")
                If sTempNpc = "anywhere" Then
                    'pos=anywhere
                    If CheckBoxShowAll.Checked = True Then outFile.WriteLine("-- npc name " & sLastNpcName & " use anywhere spawn. No supported.")
                    Continue While
                End If
                aTemp = sTempNpc.Split(CChar(";"))
                sTempSpawn &= aTemp(0) & ","
                sTempSpawn &= aTemp(1) & ","
                sTempSpawn &= aTemp(2) & ","
                sTempSpawn &= "0,0,"
                sTempSpawn &= aTemp(3) & ","

                ' 10 - respawn time
                sTempNpc = Libraries.GetNeedParamFromStr(sTemp, "respawn")

                If sTempNpc = "no" Then
                    'respawn=no
                    If CheckBoxShowAll.Checked = True Then outFile.WriteLine("-- npc name " & sLastNpcName & " respawn=no")
                    Continue While
                End If

                If sTempNpc.IndexOf("sec") > 0 Then
                    sTempNpc = sTempNpc.Replace("sec", "")
                ElseIf sTempNpc.IndexOf("min") > 0 Then
                    sTempNpc = sTempNpc.Replace("min", "")
                    sTempNpc = (CInt(sTempNpc) * 60).ToString
                ElseIf sTempNpc.IndexOf("hour") > 0 Then
                    sTempNpc = sTempNpc.Replace("hour", "")
                    sTempNpc = (CInt(sTempNpc) * 60 * 60).ToString
                End If
                sTempSpawn &= sTempNpc & ","

                ' 10 - loc_id,periodOfDay
                sTempSpawn &= "0,"
                'periodOfDay
                sTempSpawn &= bIsNight
                sTempSpawn &= ")"

                If bEventNpc = True And (CheckBoxSaveEventNpc.Checked = False And CheckBoxShowAll.Checked = True) Then
                    outFile.WriteLine("-- " & sTempSpawn & vbTab & "-- Event npc: " & sLastNpcName)
                    Continue While
                End If

                If iCount = 0 Then sTempSpawn = "INSERT INTO `spawnlist` VALUES" & vbNewLine & sTempSpawn
                iCount += 1
                If iCount >= iCountLimit Then
                    sTempSpawn &= ";"
                    iCount = 0
                Else
                    sTempSpawn &= ","
                End If

                If CheckBoxShowNpcName.Checked = True Then sTempSpawn &= vbTab & "-- " & sLastNpcName

                outFile.WriteLine(sTempSpawn)

            End If


            '  `location` varchar(40) NOT NULL DEFAULT '',
            '  `count` tinyint(1) unsigned NOT NULL DEFAULT '0',
            '  `npc_templateid` smallint(5) unsigned NOT NULL DEFAULT '0',
            '  `locx` mediumint(6) NOT NULL DEFAULT '0',
            '  `locy` mediumint(6) NOT NULL DEFAULT '0',
            '  `locz` mediumint(6) NOT NULL DEFAULT '0',
            '  `randomx` mediumint(6) NOT NULL DEFAULT '0',
            '  `randomy` mediumint(6) NOT NULL DEFAULT '0',
            '  `heading` mediumint(6) NOT NULL DEFAULT '0',
            '  `respawn_delay` mediumint(5) NOT NULL DEFAULT '0',
            '  `loc_id` int(9) NOT NULL DEFAULT '0',
            '  `periodOfDay` tinyint(1) unsigned NOT NULL DEFAULT '0'

            '('partisan_agit_2121_01',1,35372,44768,108604,-2034,0,0,44231,60,0,0),
            '('partisan_agit_2121_01',1,35372,44378,108474,-2034,0,0,39438,60,0,0),


        End While
        ToolStripProgressBar.Value = 0
        inSpawnFile.Close()
        outFile.Close()

        MessageBox.Show("Completed.")

    End Sub

    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click

        Dim sSpawnListFile As String
        Dim sTemp As String
        Dim aTemp() As String

        Dim inSpawnFile As System.IO.StreamReader

        ' LOADING npc_pch.txt
        If System.IO.File.Exists("npc_pch.txt") = False Then
            MessageBox.Show("npc_pch.txt not found", "Need npc_pch.txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim aNpcPch(40000) As String
        inSpawnFile = New System.IO.StreamReader("npc_pch.txt", System.Text.Encoding.Default, True, 1)
        ToolStripProgressBar.Maximum = CInt(inSpawnFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading npc_pch.txt ..."

        While inSpawnFile.EndOfStream <> True

            sTemp = inSpawnFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inSpawnFile.BaseStream.Position)
            If sTemp <> "" And sTemp.StartsWith("//") = False Then

                '[pet_wolf_a] = 1012077
                sTemp = sTemp.Replace(" ", "").Replace(Chr(9), "")
                aTemp = sTemp.Split(CChar("="))
                Try
                    aNpcPch(CInt(aTemp(1)) - 1000000) = aTemp(0)
                Catch ex As Exception
                    MessageBox.Show("Error in loading npc_pch.txt. Last reading line:" & vbNewLine & sTemp)
                    inSpawnFile.Close()
                    Exit Sub
                End Try

            End If

        End While
        inSpawnFile.Close()
        ToolStripProgressBar.Value = 0

        OpenFileDialog.Filter = "L2J Spawn (spawnlist.sql)|spawnlist.sql|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sSpawnListFile = OpenFileDialog.FileName
        inSpawnFile = New System.IO.StreamReader(sSpawnListFile, System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter("npcpos_l2j.txt", False, System.Text.Encoding.Unicode, 1)

        ToolStripProgressBar.Maximum = CInt(inSpawnFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading spawnlist.sql..."

        'Dim aZone() As String = {}
        Dim sCurZoneName As String = "", sPrevZoneName As String = Nothing
        Dim sTempTerritory As String, sTempNpcName As String
        Dim iNpcCount As Integer = 0

        Dim aNpcSpawn(0) As NpcSpawn
        Dim aNpcMiss(0) As Integer
        'Dim iTemp As Integer

        Dim iXMin As Integer, iXMax As Integer
        Dim iYMin As Integer, iYMax As Integer
        Dim iZMin As Integer, iZMax As Integer


        While inSpawnFile.EndOfStream <> True

            sTemp = inSpawnFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inSpawnFile.BaseStream.Position)
            If sTemp <> "" And sTemp.StartsWith("(") = True Then 'sTemp.StartsWith("--")=False

                ' ---------- Prepare for importing
                '  `id` int(11) NOT NULL auto_increment,
                '  `location` varchar(40) NOT NULL default '',
                '  `count` int(9) NOT NULL default '0',
                '  `npc_templateid` int(9) NOT NULL default '0',
                '  `locx` int(9) NOT NULL default '0',
                '  `locy` int(9) NOT NULL default '0',
                '  `locz` int(9) NOT NULL default '0',
                '  `randomx` int(9) NOT NULL default '0',
                '  `randomy` int(9) NOT NULL default '0',
                '  `heading` int(9) NOT NULL default '0',
                '  `respawn_delay` int(9) NOT NULL default '0',
                '  `loc_id` int(9) NOT NULL default '0',
                '  `periodOfDay` decimal(2,0) default '0',
                '(1,'partisan_agit_2121_01',1,35372,44368,107440,-2032,0,0,0,60,0,0),
                '(2,'partisan_agit_2121_01',1,35372,44768,108604,-2034,0,0,44231,60,0,0),

                sTemp = sTemp.Substring(InStr(sTemp, "("), InStr(sTemp, ")") - InStr(sTemp, "(") - 1)
                sTemp = sTemp.Replace("'", "")
                aTemp = sTemp.Split(CChar(","))

                '0   1                      2 3     4     5       6      7 8   9 10 11 12
                '(1,'partisan_agit_2121_01',1,35372,44368,107440,-2032,  0,0,  0,60,0,0),
                sCurZoneName = aTemp(1)

                If sPrevZoneName = Nothing Then sPrevZoneName = sCurZoneName
                If sCurZoneName <> sPrevZoneName Then
                    ' Write new zone with 

                    'territory_begin	[FantasyIsle_0]	{{-59734;-57397;-2532;-1732};{-58734;-57397;-2532;-1732};{-58734;-56397;-2532;-1732};{-59734;-56397;-2532;-1732}}	territory_end
                    'npcmaker_begin	[FantasyIsle_0]	initial_spawn=all	maximum_npc=1

                    'npcmaker_ex_begin	[rune09_npc2116_05]	name=[rune09_npc2116_0502]	ai=[on_day_night_spawn]	ai_parameters={[IsNight]=1}	maximum_npc=1
                    'npc_ex_begin	[maid_of_ridia]	pos={47108;-36189;-1624;-22192}	total=1	respawn=1min	npc_ex_end
                    'npcmaker_ex_end

                    sPrevZoneName = sPrevZoneName.Replace(" ", "_").ToLower

                    ' Generate TERRITORY AREA

                    iXMin = iXMin - 200
                    iXMax = iXMax + 200
                    iYMin = iYMin - 200
                    iYMax = iYMax + 200
                    iZMin = iZMin - 100
                    iZMax = iZMax + 100 + 700

                    sTempTerritory = ""
                    sTempTerritory = sTempTerritory & "{" & iXMin & ";" & iYMin & ";" & iZMin & ";" & iZMax & "};"
                    sTempTerritory = sTempTerritory & "{" & iXMax & ";" & iYMin & ";" & iZMin & ";" & iZMax & "};"
                    sTempTerritory = sTempTerritory & "{" & iXMax & ";" & iYMax & ";" & iZMin & ";" & iZMax & "};"
                    sTempTerritory = sTempTerritory & "{" & iXMin & ";" & iYMax & ";" & iZMin & ";" & iZMax & "}"

                    outFile.WriteLine("territory_begin" & vbTab & "[" & sPrevZoneName & "]" & vbTab & "{" & sTempTerritory & "}" & vbTab & "territory_end")
                    outFile.WriteLine("npcmaker_begin" & vbTab & "[" & sPrevZoneName & "]" & vbTab & "initial_spawn=all" & vbTab & "maximum_npc=" & iNpcCount)


                    For iTemp = 0 To iNpcCount - 1

                        ' Checking exising npc in NpcPch
                        If aNpcPch(CInt(aNpcSpawn(iTemp).npc_templateid)) = Nothing Then
                            'MessageBox.Show("Npc [" & aTemp(3) & "] not found!", "NPC not found", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            If Array.IndexOf(aNpcMiss, aNpcSpawn(iTemp).npc_templateid) = -1 Then
                                aNpcMiss(aNpcMiss.Length - 1) = aNpcSpawn(iTemp).npc_templateid
                                Array.Resize(aNpcMiss, aNpcMiss.Length + 1)
                            End If

                            sTempNpcName = "[_need_" & aNpcSpawn(iTemp).npc_templateid & "_]"
                            'inSpawnFile.Close()
                            'outFile.Close()
                            'Exit Sub
                        Else
                            sTempNpcName = aNpcPch(CInt(aNpcSpawn(iTemp).npc_templateid))
                        End If

                        'npc_begin	[fantasy_isle_paddies]	pos={-59234;-56897;-2032;0}	total=1	respawn=60sec	npc_end
                        outFile.WriteLine("npc_begin" & vbTab & sTempNpcName & vbTab & "pos={" & aNpcSpawn(iTemp).locx & "," & aNpcSpawn(iTemp).locy & "," & aNpcSpawn(iTemp).locz & "," & aNpcSpawn(iTemp).heading & "}" & vbTab & "total=1" & vbTab & "respawn=" & aNpcSpawn(iTemp).respawn_delay & "sec" & vbTab & "npc_end")

                    Next

                    'npcmaker_end
                    outFile.WriteLine("npcmaker_end")
                    iNpcCount = 0
                    Array.Clear(aNpcSpawn, 0, aNpcSpawn.Length)
                    Array.Resize(aNpcSpawn, 1)

                    sPrevZoneName = sCurZoneName

                End If

                ' ADD new Npc to Array
                Array.Resize(aNpcSpawn, iNpcCount + 1)

                'Dim iXMin As Integer, iXMax As Integer
                'Dim iYMin As Integer, iYMax As Integer
                'Dim iZMin As Integer, iZMax As Integer

                aNpcSpawn(iNpcCount).npc_templateid = CInt(aTemp(3))
                aNpcSpawn(iNpcCount).locx = CInt(aTemp(4))
                aNpcSpawn(iNpcCount).locy = CInt(aTemp(5))
                aNpcSpawn(iNpcCount).locz = CInt(aTemp(6))
                aNpcSpawn(iNpcCount).heading = CInt(aTemp(9))
                aNpcSpawn(iNpcCount).respawn_delay = CInt(aTemp(10))

                If iNpcCount = 0 Then iXMin = aNpcSpawn(iNpcCount).locx
                If iNpcCount = 0 Then iXMax = aNpcSpawn(iNpcCount).locx
                If iNpcCount = 0 Then iYMin = aNpcSpawn(iNpcCount).locy
                If iNpcCount = 0 Then iYMax = aNpcSpawn(iNpcCount).locy
                If iNpcCount = 0 Then iZMin = aNpcSpawn(iNpcCount).locz
                If iNpcCount = 0 Then iZMax = aNpcSpawn(iNpcCount).locz


                If aNpcSpawn(iNpcCount).locx < iXMin Then iXMin = aNpcSpawn(iNpcCount).locx
                If aNpcSpawn(iNpcCount).locx > iXMax Then iXMax = aNpcSpawn(iNpcCount).locx

                If aNpcSpawn(iNpcCount).locy < iYMin Then iYMin = aNpcSpawn(iNpcCount).locy
                If aNpcSpawn(iNpcCount).locy > iYMax Then iYMax = aNpcSpawn(iNpcCount).locy

                If aNpcSpawn(iNpcCount).locz < iZMin Then iZMin = aNpcSpawn(iNpcCount).locz
                If aNpcSpawn(iNpcCount).locz > iZMax Then iZMax = aNpcSpawn(iNpcCount).locz

                iNpcCount = iNpcCount + 1


            End If

        End While
        ToolStripProgressBar.Value = 0
        inSpawnFile.Close()
        outFile.Close()

        If aNpcMiss.Length > 0 Then
            outFile = New System.IO.StreamWriter("npcpos_l2j.log", False, System.Text.Encoding.Unicode, 1)
            outFile.WriteLine("Missed NPC. Required for NpcPos:")
            For iNpcCount = 0 To aNpcMiss.Length - 2
                outFile.WriteLine("npc_id=" & aNpcMiss(iNpcCount))
            Next
            outFile.Close()
        End If

        MessageBox.Show("Completed. With [" & iNpcCount & "] missed npc's.")

    End Sub

    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub


End Class