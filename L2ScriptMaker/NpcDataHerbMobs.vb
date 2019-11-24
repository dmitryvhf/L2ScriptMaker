Public Class NpcDataHerbMobs

    Dim aTerra(0) As TerritoryDefine

    'huntingzone_begin	id=2	hunting_type=1	level=25	unk_1=0	loc_x=50568.000000	loc_y=152408.000000	loc_z=-2656.000000	unk_2=0	affiliated_area_id=1	name=[Execution Grounds]	huntingzone_end
    Private Structure TerritoryDefine
        Dim x As Integer
        Dim y As Integer
        Dim z As Integer
        Dim level As Integer
    End Structure

    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click

        Dim sNpcNameE As String = "npcname-e.txt"
        Dim sNpcdataPch As String = "npc_pch.txt"
        Dim sNpcdata As String = "npcdata.txt"
        Dim sHuntingzoneE As String = "huntingzone-e.txt"
        Dim sNpcpos As String = "npcpos.txt"

        If System.IO.File.Exists(sNpcNameE) = False Then
            OpenFileDialog.FileName = ""
            OpenFileDialog.Filter = "Lineage II client text file (npcname-e.txt)|npcname-e.txt|All files|*.*"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            sNpcNameE = OpenFileDialog.FileName
        End If

        If System.IO.File.Exists(sNpcdataPch) = False Then
            OpenFileDialog.FileName = ""
            OpenFileDialog.Filter = "Lineage II server npc config (npc_pch.txt)|npc_pch.txt|All files|*.*"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            sNpcdataPch = OpenFileDialog.FileName
        End If

        If System.IO.File.Exists(sHuntingzoneE) = False Then
            OpenFileDialog.FileName = ""
            OpenFileDialog.Filter = "Lineage II client text file (huntingzone-e.txt)|huntingzone-e.txt|All files|*.*"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            sHuntingzoneE = OpenFileDialog.FileName
        End If

        If System.IO.File.Exists(sNpcpos) = False Then
            OpenFileDialog.FileName = ""
            OpenFileDialog.Filter = "Lineage II server npc config (npcpos.txt)|npcpos*.txt|All files|*.*"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            sNpcpos = OpenFileDialog.FileName
        End If
        If System.IO.File.Exists(sNpcdata) = False Then
            OpenFileDialog.FileName = ""
            OpenFileDialog.Filter = "Lineage II server npc config (npcdata.txt)|npcdata*.txt|All files|*.*"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            sNpcdata = OpenFileDialog.FileName
        End If

        Dim sTemp As String
        Dim aTemp() As String = Nothing
        Dim iTemp As Integer
        'Dim aNpcId(40000) As Integer
        Dim aNpcName(40000) As String
        Dim aNpcHerb(40000) As Boolean

        Dim aQuestNpc(0) As String
        Dim inFile As System.IO.StreamReader

        'Dim inHuntingzoneE As New System.IO.StreamReader(sHuntingzoneE, System.Text.Encoding.Default, True, 1)
        'Dim inNpcpos As New System.IO.StreamReader(sNpcpos, System.Text.Encoding.Default, True, 1)
        'Dim inNpcData As New System.IO.StreamReader(sNpcdata, System.Text.Encoding.Default, True, 1)


        '[pet_wolf_a] = 1012077
        inFile = New System.IO.StreamReader(sNpcdataPch, System.Text.Encoding.Default, True, 1)
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading npc_pch.txt..."
        StatusStrip.Update()

        While inFile.EndOfStream <> True
            sTemp = inFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)

            If sTemp <> "" And sTemp.StartsWith("//") = False Then
                sTemp = sTemp.Replace(" ", "").Replace(Chr(9), "") 'Replace("[", "").Replace("]", "").
                aTemp = sTemp.Split(CChar("="))
                aNpcName(CInt(aTemp(1)) - 1000000) = aTemp(0)
                ' aNpcHerb(iTemp) = False
            End If

        End While
        inFile.Close()
        ToolStripProgressBar.Value = 0


        inFile = New System.IO.StreamReader(sHuntingzoneE, System.Text.Encoding.Default, True, 1)
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading huntingzone-e.txt..."
        StatusStrip.Update()

        While inFile.EndOfStream <> True
            sTemp = inFile.ReadLine
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            If sTemp <> "" And sTemp.StartsWith("//") = False Then

                iTemp = CInt(Libraries.GetNeedParamFromStr(sTemp, "level"))

                'huntingzone_begin	id=2	hunting_type=1	level=25	unk_1=0	loc_x=50568.000000	loc_y=152408.000000	loc_z=-2656.000000	unk_2=0	affiliated_area_id=1	name=[Execution Grounds]	huntingzone_end

                'If Libraries.GetNeedParamFromStr(sTemp, "name") = "[Valley of Saints]" Then
                'Dim dskjk As Boolean = True
                'End If

                If iTemp > 0 And (Libraries.GetNeedParamFromStr(sTemp, "hunting_type") = "1") Then
                    iTemp = aTerra.Length
                    Array.Resize(aTerra, iTemp + 1)
                    aTerra(iTemp - 1).x = CInt(Libraries.GetNeedParamFromStr(sTemp, "loc_x"))
                    aTerra(iTemp - 1).y = CInt(Libraries.GetNeedParamFromStr(sTemp, "loc_y"))
                    aTerra(iTemp - 1).z = CInt(Libraries.GetNeedParamFromStr(sTemp, "loc_z"))
                    aTerra(iTemp - 1).level = CInt(Libraries.GetNeedParamFromStr(sTemp, "level"))
                End If

            End If
        End While
        inFile.Close()
        ToolStripProgressBar.Value = 0


        Dim bScanMob As Boolean = False
        inFile = New System.IO.StreamReader(sNpcpos, True)
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading Npcpos.txt..."
        StatusStrip.Update()

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            If sTemp <> "" And sTemp.StartsWith("//") = False Then



                If sTemp.StartsWith("territory_begin") = True Then
                    If InStr(sTemp, "[rune08_2215_23]") > 0 Then
                        Dim skjak As Boolean = True
                    End If
                    sTemp = sTemp.Substring(InStr(sTemp, "{{") + 1, InStr(sTemp, "};{") - InStr(sTemp, "{{") - 2)
                    bScanMob = InMyTerritory(sTemp)
                End If
                If bScanMob = True Then
                    If sTemp.StartsWith("npc_begin") = True Or sTemp.StartsWith("npc_ex_begin") = True Then
                        'sTemp = sTemp.Substring(InStr(sTemp, "[") - 1, InStr(sTemp, "]") - InStr(sTemp, "[") + 1)
                        '[brilliant_legacy], [highprist_partyleader01]
                        If sTemp.Substring(InStr(sTemp, "[") - 1, InStr(sTemp, "]") - InStr(sTemp, "[") + 1) = "[brilliant_legacy]" Then
                            Dim skjak As Boolean = True
                        End If

                        If InStr(sTemp, "Privates=[") = 0 And InStr(sTemp, "[SSQLoserTeleport]") = 0 Then
                            iTemp = Array.IndexOf(aNpcName, sTemp.Substring(InStr(sTemp, "[") - 1, InStr(sTemp, "]") - InStr(sTemp, "[") + 1))
                            If iTemp <> -1 Then
                                aNpcHerb(iTemp) = True
                            End If
                        End If
                    End If
                End If

            End If

        End While
        inFile.Close()
        ToolStripProgressBar.Value = 0


        System.IO.File.Copy(sNpcdata, sNpcdata & ".bak", True)
        inFile = New System.IO.StreamReader(sNpcdata & ".bak", System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter(sNpcdata, False, System.Text.Encoding.Unicode, 1)
        Dim outLog As New System.IO.StreamWriter(sNpcdata & ".log", False, System.Text.Encoding.Unicode, 1)
        outLog.WriteLine("Lineage II ScriptMaker: Herb mob generator. Start of " & Now & vbNewLine)
        outLog.WriteLine("This mob now is " & HerbMobTypeTextBox.Text)

        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Rebuilding Npcdata.txt..."
        StatusStrip.Update()

        While inFile.EndOfStream <> True
            sTemp = inFile.ReadLine
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            If sTemp <> "" And sTemp.StartsWith("//") = False Then

                'npc_begin(0)      pet(1)     12077(2)   [pet_wolf_a](3)    level=15(4)
                aTemp = sTemp.Split(Chr(9))

                'If aTemp(2) = "21530" Then
                '    Dim skjak As Boolean = True
                'End If

                'If aTemp(3) = "[brilliant_legacy]" Then
                '    Dim skjak As Boolean = True
                'End If

                ' ------ Recovery type for npc before setting

                If CheckBoxLa2Herb.Checked = True Then
                    ' fix for npcdata from dVampire
                    sTemp = sTemp.Replace("herb_warrior", "warrior")
                    If Libraries.GetNeedParamFromStr(sTemp, "drop_herb") = "" Then
                        sTemp = sTemp.Replace("npc_end", "drop_herb=0" & vbTab & "npc_end")
                    End If
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "drop_herb", "0")
                Else
                    If aTemp(1) = HerbMobTypeTextBox.Text Then
                        aTemp(1) = "warrior"
                        sTemp = Join(aTemp, Chr(9))
                    End If
                End If

                ' MAIN Fix
                If aTemp(1) = "warrior" Then

                    ' CHECKING for Known type no herb mobs
                    If Libraries.GetNeedParamFromStr(sTemp, "unsowing") = "1" Then
                        ' npc already unsowing
                        GoTo NoFix
                    End If
                    If InStr(sTemp, "[Privates]") <> 0 Then
                        ' Checking Privates settings into Npcdata.txt
                        GoTo NoFix
                    End If
                    If CInt(Libraries.GetNeedParamFromStr(sTemp, "level").Replace("level=", "")) <= CInt(HerbMobMinLvlTextBox.Text) Then
                        GoTo NoFix
                    End If
                    If aNpcHerb(CInt(aTemp(2))) = False Then
                        GoTo NoFix
                    End If
                    '{[HelpHeroSilhouette]=@betrayer_orc_hero};
                    If InStr(sTemp, "[HelpHeroSilhouette]") <> 0 Then
                        GoTo NoFix
                    End If
                    '{[silhouette]=@guardian_angel_r}
                    If InStr(sTemp, "[silhouette]") <> 0 Then
                        GoTo NoFix
                    End If
                    '{[FeedID1_warrior_silhouette1]=@alpine_kukaburo_2_war_a1}  ??
                    '' HP1x checking
                    ''skill_list={@s_race_magic_creatures;@s_hp_increase10;@
                    'If InStr(sTemp, "@s_hp_increase") <> 0 Then
                    '    If InStr(sTemp, "@s_hp_increase1;") = 0 And InStr(sTemp, "@s_hp_increase1}") = 0 Then
                    '        GoTo NoFix
                    '    End If
                    'End If
                    'clan={@c_dungeon_clan}
                    'ai_parameters={[SSQLoserTeleport]=@SEAL_REVELATION;[SSQTelPosX]=[137453];[SSQTelPosY]=[79665];[SSQTelPosZ]=[-3696]}	
                    If InStr(sTemp, "@c_dungeon_clan") <> 0 Then
                        GoTo NoFix
                    End If

                    ' Mob checked - this Herb mob. Fixing
                    If CheckBoxLa2Herb.Checked = True Then
                        sTemp = Libraries.SetNeedParamToStr(sTemp, "drop_herb", "1")
                    Else
                        aTemp(1) = HerbMobTypeTextBox.Text
                        sTemp = Join(aTemp, Chr(9))
                    End If
                    outLog.WriteLine(aTemp(2) & vbTab & aTemp(3) & vbTab & aTemp(4))

NoFix:

                End If


            End If


            outFile.WriteLine(sTemp)
        End While

        outLog.WriteLine()
        outLog.WriteLine("End of " & Now)

        inFile.Close()
        outFile.Close()
        outLog.Close()
        ToolStripProgressBar.Value = 0

        'inHuntingzoneE.Close()
        'inNpcpos.Close()
        'inNpcData.Close()

        MessageBox.Show("Complete")

    End Sub

    Private Function InMyTerritory(ByVal LocXYZ As String) As Boolean

        Dim aTemp() As String
        Dim iTemp As Integer
        Dim iTempX As Integer
        Dim iTempY As Integer
        Dim iTempZ As Integer

        aTemp = LocXYZ.Split(CChar(";"))
        iTempX = CInt(aTemp(0))
        iTempY = CInt(aTemp(1))
        iTempZ = CInt(aTemp(2))

        Dim iRadiusXY As Integer = CInt(RaduisXYTextBox.Text)   '16000
        Dim iRadiusZ As Integer = CInt(RaduisZTextBox.Text)     '1000
        For iTemp = 0 To aTerra.Length - 1

            If iTemp = 121 Then
                Dim skjak As Boolean = True
            End If

            If (iTempX >= aTerra(iTemp).x - iRadiusXY) And (iTempX <= aTerra(iTemp).x + iRadiusXY) Then
                If (iTempY >= aTerra(iTemp).y - iRadiusXY) And (iTempY <= aTerra(iTemp).y + iRadiusXY) Then
                    If (iTempZ >= aTerra(iTemp).z - iRadiusZ) And (iTempZ <= aTerra(iTemp).z + iRadiusZ) Then
                        Return True
                    End If
                End If
            End If
        Next
        Return False

    End Function


    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub
End Class

'huntingzone_begin	id=2	hunting_type=1	level=25	unk_1=0	loc_x=50568.000000	loc_y=152408.000000	loc_z=-2656.000000	unk_2=0	affiliated_area_id=1	name=[Execution Grounds]	huntingzone_end

'territory_begin	[rune09_2116_10]	{{59981;-54556;-3515;-2715};{60939;-53182;-3515;-2715};{60726;-52341;-3515;-2715};{59098;-52110;-3515;-2715};{58513;-53596;-3515;-2715}}	territory_end
'npcmaker_ex_begin	[rune09_2116_10]	name=[rune09_10_night]	ai=[on_day_night_spawn]	ai_parameters={[IsNight]=1}	maximum_npc=30
'npc_ex_begin	[beheaded]	pos=anywhere	total=4	respawn=30sec	npc_ex_end
'npc_ex_begin	[devil_bat_a]	pos=anywhere	total=3	respawn=30sec	npc_ex_end
'npc_ex_begin	[skull_animator]	pos=anywhere	total=3	respawn=30sec	npc_ex_end
'npcmaker_ex_end

'territory_begin	[aden06_2518_07]	{{177408;9460;-2768;-2468};{179068;9460;-2768;-2468};{179316;9704;-2768;-2468};{179308;11776;-2768;-2468};{178648;12892;-2768;-2468};{177748;12888;-2768;-2468};{177360;12432;-2768;-2468}}	territory_end
'npcmaker_begin	[aden06_2518_07]	initial_spawn=all	maximum_npc=85
'npc_begin	[bloody_queen]	pos=anywhere	total=2	respawn=25sec	npc_end
'npc_begin	[crimson_drake]	pos=anywhere	total=2	respawn=25sec	npc_end
'npc_begin	[kadios]	pos=anywhere	total=1	respawn=25sec	npc_end
'npcmaker_end
