Public Class AIRaidPosGenerator

    Private Structure RaidBoss
        Dim Id As Integer
        Dim Level As Integer
        Dim PchName As String  'from npcpch.txt
        Dim Name As String  'from npcname-e.txt
        Dim Privates As String
        Dim LocX As Integer
        Dim LocY As Integer
        Dim LocZ As Integer
    End Structure

    'raiddata-e.txt
    'raiddata_begin	id=1	npc_id=29001	npc_level=40	affiliated_area_id=30	loc_x=-21610.000000	loc_y=181594.000000	loc_z=-5734.000000	raid_desc=[]	raiddata_end
    '-> raiddata_begin	id=139	npc_id=25333	npc_level=28	affiliated_area_id=179	loc_x=0.000000	loc_y=0.000000	loc_z=0.000000	raid_desc=[A being that tries to invade the real world by crossing the Dimensional Rift along with the otherworldly devils. Its shape is very unstable because of the Rift's distortion of time and space.]	raiddata_end

    'npcname-e.txt
    'npcname_begin	id=25001	name=[Greyclaw Kutus]	description=[Raid Boss]	rgb[0]=3F	rgb[1]=8B	rgb[2]=FE	reserved1=-1	npcname_end
    'npcname_begin	id=25002	name=[Guard of Kutus]	description=[Raid Fighter]	rgb[0]=3F	rgb[1]=8B	rgb[2]=FE	reserved1=-1	npcname_end
    'npc_pch.txt
    '[hatchling_of_wind] = 1012311


    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Dim sRBFile As String = "raiddata-e.txt"
        Dim sNpcNameFile As String = "npcname-e.txt"
        Dim sNpcPchFile As String = "npc_pch.txt"

        Dim sRBAIFile As String = "announce_raid_boss_position_all_rb.txt"
        Dim sRBNpcPos As String = "npcpos_all_rb.txt"

        OpenFileDialog.FileName = sRBFile
        OpenFileDialog.Filter = "Lineage II client Raid Boss position file (raiddata-e.txt)|raiddata*.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sRBFile = OpenFileDialog.FileName

        OpenFileDialog.FileName = sNpcNameFile
        OpenFileDialog.Filter = "Lineage II client npcname file (npcname-e.txt)|npcname*.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sNpcNameFile = OpenFileDialog.FileName

        OpenFileDialog.FileName = sNpcPchFile
        OpenFileDialog.Filter = "Lineage II server npc file (npc_pch.txt)|npc_pch.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sNpcPchFile = OpenFileDialog.FileName

        SaveFileDialog.FileName = sRBAIFile
        SaveFileDialog.Filter = "Lineage II Raid Boss AI.obj class (announce_raid_boss_position_all_rb.txt)|*.txt|All files|*.*"
        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sRBAIFile = SaveFileDialog.FileName

        SaveFileDialog.FileName = sRBNpcPos
        SaveFileDialog.Filter = "Lineage II Raid Boss Npcpos(announce_raid_boss_position_all_rb.txt)|*.txt|All files|*.*"
        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sRBNpcPos = SaveFileDialog.FileName

        Dim inFile As System.IO.StreamReader '= Nothing
        Dim outFile As System.IO.StreamWriter

        Dim aNpcPch(0) As String    ' storage for ids (29001,25001,...)
        Dim aBase(0) As RaidBoss

        Dim sTemp As String
        Dim iTemp As Integer
        Dim aTemp() As String

        ' Reading NpcPch file
        inFile = New System.IO.StreamReader(sNpcPchFile, System.Text.Encoding.Default, True, 1)
        ToolStripProgressBar.Value = 0
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            sTemp = sTemp.Trim.Replace(" ", "")
            aTemp = sTemp.Split(CChar("="))

            'npc_pch.txt
            '[hatchling_of_wind] = 1012311

            If CInt(aTemp(1).Substring(2, 5)) >= aNpcPch.Length Then
                Array.Resize(aNpcPch, CInt(aTemp(1).Substring(2, 5)) + 1)
            End If
            aNpcPch(aNpcPch.Length - 1) = aTemp(0)

            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
        End While
        ToolStripProgressBar.Value = 0
        inFile.Close()

        ' Reading raiddata-e.txt file
        inFile = New System.IO.StreamReader(sRBFile, System.Text.Encoding.Default, True, 1)
        ToolStripProgressBar.Value = 0
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine

            'raiddata-e.txt
            'raiddata_begin	id=1	npc_id=29001	npc_level=40	affiliated_area_id=30	loc_x=-21610.000000	loc_y=181594.000000	loc_z=-5734.000000	raid_desc=[]	raiddata_end
            '-> raiddata_begin	id=139	npc_id=25333	npc_level=28	affiliated_area_id=179	loc_x=0.000000	loc_y=0.000000	loc_z=0.000000	raid_desc=[A being that tries to invade the real world by crossing the Dimensional Rift along with the otherworldly devils. Its shape is very unstable because of the Rift's distortion of time and space.]	raiddata_end

            iTemp = CInt(Libraries.GetNeedParamFromStr(sTemp, "npc_id"))
            If aNpcPch(iTemp) <> "" Then
                Array.Resize(aBase, aBase.Length + 1)
                aBase(aBase.Length - 1).PchName = aNpcPch(iTemp)
                aBase(aBase.Length - 1).Id = iTemp
                iTemp = aBase.Length - 1
                aBase(iTemp).Level = CInt(Libraries.GetNeedParamFromStr(sTemp, "npc_level"))
                aBase(iTemp).LocX = CInt(Libraries.GetNeedParamFromStr(sTemp, "loc_x"))
                aBase(iTemp).LocY = CInt(Libraries.GetNeedParamFromStr(sTemp, "loc_y"))
                aBase(iTemp).LocZ = CInt(Libraries.GetNeedParamFromStr(sTemp, "loc_z"))
            End If

            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
        End While
        ToolStripProgressBar.Value = 0
        inFile.Close()

        ' Reading npcname-e.txt file
        inFile = New System.IO.StreamReader(sNpcNameFile, System.Text.Encoding.Default, True, 1)
        ToolStripProgressBar.Value = 0
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        Dim iTempLevel As Integer
        Dim iPrevBossId As Integer = -1
        Dim sTemp2 As String

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            
            'npcname-e.txt
            'npcname_begin	id=25001	name=[Greyclaw Kutus]	description=[Raid Boss]	rgb[0]=3F	rgb[1]=8B	rgb[2]=FE	reserved1=-1	npcname_end
            'npcname_begin	id=25002	name=[Guard of Kutus]	description=[Raid Fighter]	rgb[0]=3F	rgb[1]=8B	rgb[2]=FE	reserved1=-1	npcname_end
            iTemp = CInt(Libraries.GetNeedParamFromStr(sTemp, "id"))
            For iTempLevel = 0 To aBase.Length - 1
                If aBase(iTempLevel).Id = iTemp Then
                    aBase(iTempLevel).Name = Libraries.GetNeedParamFromStr(sTemp, "name").Replace("[", "").Replace("]", "")
                    'aBase(aBase.Length - 1).Privates = Libraries.GetNeedParamFromStr(sTemp, "description")
                    iPrevBossId = iTempLevel
                End If
            Next

            If GenPrivatesCheckBox.Checked = True Then
                'iPrevBossId
                sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "description")
                If sTemp2.StartsWith("[Raid ") = True And sTemp2.StartsWith("[Raid Boss") = False Then
                    ' Found privates
                    iTemp = CInt(Libraries.GetNeedParamFromStr(sTemp, "id"))
                    If iTemp <> -1 Then
                        If aBase(iPrevBossId).Privates <> "" Then
                            aBase(iPrevBossId).Privates = aBase(iPrevBossId).Privates & ";"
                        End If
                        aBase(iPrevBossId).Privates = aBase(iPrevBossId).Privates & aNpcPch(iTemp).Replace("[", "").Replace("]", "")
                    End If
                End If
            End If

            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
        End While
        ToolStripProgressBar.Value = 0
        inFile.Close()


        ' WRITE AI class 'announce_raid_boss_position.txt'
        outFile = New System.IO.StreamWriter(sRBAIFile, False, System.Text.Encoding.Unicode, 1)

        ' Write header to AI class
        outFile.WriteLine("class 1 announce_raid_boss_position : citizen")
        outFile.WriteLine("parameter_define_begin")
        outFile.WriteLine(vbTab & "string fnHiPCCafe ""pc.htm""")
        outFile.WriteLine("parameter_define_end")
        outFile.WriteLine("property_define_begin")
        Dim iTempLevel2 As Integer

        For iTempLevel = 20 To 90 Step 10

            'telposlist_begin RaidBossList20_29
            outFile.WriteLine(vbTab & "telposlist_begin RaidBossList{0}_{1}", iTempLevel, iTempLevel + 9)

            For iTempLevel2 = 0 To 9 ' Step 10
                For iTemp = 0 To aBase.Length - 1
                    If aBase(iTemp).Level = (iTempLevel + iTempLevel2) Then
                        '{"Madness Beast (lv20)"; -54096; 84288; -3512; 0; 0 }
                        If aBase(iTemp).LocX <> 0 Then
                            'outFile.WriteLine(vbTab & vbTab & "{""" & aBase(iTemp).Name & " (lv" & aBase(iTemp).Level & ")""; " & aBase(iTemp).LocX & "; " & aBase(iTemp).LocY & "; " & aBase(iTemp).LocZ & "; 0; 0}")
                            outFile.WriteLine(vbTab & vbTab & "{""" & aBase(iTemp).Name & " (lv" & aBase(iTemp).Level & ")""; " & aBase(iTemp).LocX & "; " & aBase(iTemp).LocY & "; " & aBase(iTemp).LocZ & "; 0; 0}")
                        End If
                    End If
                Next
            Next

            outFile.WriteLine(vbTab & "telposlist_end")
        Next
        outFile.WriteLine("property_define_end")
        outFile.Close()


        ' WRITE NpcPos'
        If GenPosCheckBox.Checked = True Then

            outFile = New System.IO.StreamWriter(sRBNpcPos, False, System.Text.Encoding.Unicode, 1)

            ' Write header to AI class

            'territory_begin	[aden24_mb2320_04]	{{123340;93852;-2464;-1864};{124204;93488;-2464;-1864};{124684;93960;-2464;-1864};{124512;94308;-2464;-1864};{123572;94656;-2464;-1864}}	territory_end					
            'npcmaker_begin	[aden24_mb2320_04]	initial_spawn=all	maximum_npc=10					
            'npc_begin	[kelbar]	pos=anywhere	total=1	respawn=36hour	respawn_rand=24hour	dbname=[kelbar]	dbsaving={death_time;parameters}	npc_end
            'npcmaker_end	

            Dim iTemp2 As Integer

            For iTemp = 0 To aBase.Length - 1
                If aBase(iTemp).LocX <> 0 Then
                    'territory_begin	[aden24_mb2320_04]	{{123340;93852;-2464;-1864};{124204;93488;-2464;-1864};{124684;93960;-2464;-1864};{124512;94308;-2464;-1864};{123572;94656;-2464;-1864}}	territory_end					
                    outFile.Write("territory_begin" & vbTab)
                    outFile.Write("[raidboss" & iTemp & "_" & aBase(iTemp).PchName.Replace("[", "").Replace("]", "") & "]" & vbTab)
                    outFile.Write("{{" & aBase(iTemp).LocX - 200 & ";" & aBase(iTemp).LocY - 200 & ";" & (aBase(iTemp).LocZ - 100) & ";" & aBase(iTemp).LocZ + 300 & "};")
                    outFile.Write("{" & aBase(iTemp).LocX + 200 & ";" & aBase(iTemp).LocY - 200 & ";" & (aBase(iTemp).LocZ - 100) & ";" & aBase(iTemp).LocZ + 300 & "};")
                    outFile.Write("{" & aBase(iTemp).LocX + 200 & ";" & aBase(iTemp).LocY + 200 & ";" & (aBase(iTemp).LocZ - 100) & ";" & aBase(iTemp).LocZ + 300 & "};")
                    outFile.Write("{" & aBase(iTemp).LocX - 200 & ";" & aBase(iTemp).LocY + 200 & ";" & (aBase(iTemp).LocZ - 100) & ";" & aBase(iTemp).LocZ + 300 & "}")
                    outFile.WriteLine("}}" & vbTab & "territory_end")

                    'npcmaker_begin	[aden24_mb2320_04]	initial_spawn=all	maximum_npc=10					
                    outFile.Write("npcmaker_begin" & vbTab)
                    outFile.Write("[raidboss" & iTemp & "_" & aBase(iTemp).PchName.Replace("[", "").Replace("]", "") & "]" & vbTab)
                    outFile.Write("initial_spawn=all" & vbTab)
                    outFile.WriteLine("maximum_npc=10")

                    'npc_begin	[kelbar]	pos=anywhere	total=1	respawn=36hour	respawn_rand=24hour	dbname=[kelbar]	dbsaving={death_time;parameters}	npc_end
                    'Privates=[talakin_archer:talakin_archer:1:0sec;talakin_raider:talakin_raider:1:0sec]
                    outFile.Write("npc_begin" & vbTab)
                    outFile.Write(aBase(iTemp).PchName & vbTab & "pos=anywhere" & vbTab & "total=1" & vbTab & "respawn=36hour" & vbTab & "respawn_rand=24hour" & vbTab & "dbname=" & aBase(iTemp).PchName & vbTab & "dbsaving={death_time;parameters}" & vbTab)

                    ' Generate Privates list
                    If GenPrivatesCheckBox.Checked = True Then
                        If aBase(iTemp).Privates <> "" Then
                            outFile.Write("Privates=[")
                            aTemp = aBase(iTemp).Privates.Split(CChar(";"))
                            For iTemp2 = 0 To aTemp.Length - 1
                                outFile.Write(aTemp(iTemp2) & ":")
                                outFile.Write(aTemp(iTemp2) & ":")
                                outFile.Write("1:0sec")
                                If iTemp2 < aTemp.Length - 1 Then
                                    outFile.Write(";")
                                End If
                            Next
                            outFile.Write("]" & vbTab)
                        End If

                    End If

                    outFile.WriteLine("npc_end")

                    'npcmaker_end	
                    outFile.WriteLine("npcmaker_end" & vbNewLine)
                End If
            Next
            outFile.Close()
        End If


        MessageBox.Show("Complete.")

    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub


    Private Sub GenPosCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenPosCheckBox.CheckedChanged

        If GenPosCheckBox.Checked = False Then
            GenPrivatesCheckBox.Enabled = False
        Else
            GenPrivatesCheckBox.Enabled = True
        End If

    End Sub
End Class