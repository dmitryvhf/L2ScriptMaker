Public Class NpcDataChecker

    Dim aItemPchName(15000) As String
    Dim aItemType(15000) As String

    Private Function LoadItemData() As Boolean

        OpenFileDialog.FileName = "itemdata.txt"

        If System.IO.File.Exists("itemdata.txt") = False Then
            OpenFileDialog.Filter = "Lineage II server item config|itemdata.txt|All files|*.*"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Return False
        End If

        Dim inFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)

        Dim sTemp As String
        Dim aTemp() As String
        Dim iTemp As Integer

        ToolStripProgressBar.Value = 0
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        While inFile.EndOfStream <> True

            'item_begin	weapon	94	[bech_de_corbin]	item_type=weapon
            'weapon_type=pole

            sTemp = inFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            If sTemp <> "" And sTemp.StartsWith("//") = False And sTemp.StartsWith("set_begin") = False Then

                aTemp = sTemp.Split(Chr(9))
                iTemp = CInt(aTemp(2))
                If iTemp >= aItemPchName.Length Then
                    Array.Resize(aItemPchName, iTemp + 1)
                    Array.Resize(aItemType, iTemp + 1)
                End If
                aItemPchName(iTemp) = aTemp(3)
                aItemType(iTemp) = Libraries.GetNeedParamFromStr(sTemp, "weapon_type")
                If aItemType(iTemp) = "etc" Then aItemType(iTemp) = "fist"
                Select Case aItemType(iTemp)
                    Case "etc"
                        aItemType(iTemp) = "fist"
                    Case "fishingrod"
                        aItemType(iTemp) = "fist"
                    Case "dualfist"
                        aItemType(iTemp) = "fist"
                End Select

                'If aItemType(iTemp) = "etc" Then aItemType(iTemp) = "fist"
            End If

        End While
        ToolStripProgressBar.Value = 0
        inFile.Close()

        Return True

    End Function

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        ' Attention Dialogs
        If CheckedListBox.CheckedItems.Count = 0 Then
            MessageBox.Show("Nothing analysing. Select and try again.", "Nothing Analysing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If CheckedListBox.CheckedItems.IndexOf("undying, can_be_attacked") <> -1 Then
            If MessageBox.Show("Attention! You are selected fix on Undying. Some Quest mobs must be Invulerable. Check logs after finishing fixing." & vbNewLine & "Continue fixing?", "undying Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If
        'If UnsowingCheckBox.Checked = True Then
        'If MessageBox.Show("Attention! You are selected fix on Unsowing. Some mobs unavailable for sowing. Check logs after finishing fixing." & vbNewLine & "Continue fixing?", "unsowing Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then Exit Sub
        'End If

        If CheckedListBox.CheckedItems.IndexOf("slot_rhand, base_attack_type") <> -1 Then
            If LoadItemData() = False Then
                MessageBox.Show("Error loading itemdata information. Fix problem and try again", "Error loading itemdata", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        'Dim inFile As New System.IO.StreamReader(OpenFileDialog.FileName & ".bak", System.Text.Encoding.Default, True, 1)
        Dim inFile As System.IO.StreamReader

        Dim sTemp As String, sTemp2 As String
        Dim aTemp() As String, aTemp2() As String
        Dim iTemp As Integer
        Dim dTemp As Double
        Dim aQuestNpc(0) As String

        Dim aRace() As String = {"animal", "dragon", "fairy", "etc", "angel", "construct", "creature", "human", "humanoid", _
                                 "beast", "undead", "elemental", "demonic", "siege_weapon", "divine", "bug", "plant", "giant", _
                                 "kamael", "elf", "dwarf", "darkelf", "orc", "castle_guard", "mercenary"}
        Dim aRaceSkill() As String = {"s_race_animals", "s_race_dragons", "s_race_fairies", "s_race_others", "s_race_angels", "s_race_magic_creatures", "s_race_unknown_creature", "s_race_humans", "s_race_humanoids", _
                                      "s_race_beasts", "s_race_undead", "s_race_spirits", "s_race_demons", "s_race_siege_weapons", "s_race_divine", "s_race_bugs", "s_race_plants", "s_race_giants", _
                                      "s_race_kamaels", "s_race_elves", "s_race_dwarves", "s_race_dark_elves", "s_race_orcs", "s_race_defending_army", "s_race_mercenaries"}

        If CheckedListBox.CheckedItems.IndexOf("unsowing") <> -1 Then
            ' Quest Mobs loader
            Dim sNpcNameE As String = "npcname-e.txt"
            If System.IO.File.Exists(sNpcNameE) = False Then
                OpenFileDialog.FileName = ""
                OpenFileDialog.Filter = "Lineage II client text file (npcname-e.txt)|npcname-e.txt|All files|*.*"
                If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
                sNpcNameE = OpenFileDialog.FileName
            End If
            ' NpcName-e. Finding ' description=[Quest Monster] '
            inFile = New System.IO.StreamReader(sNpcNameE, System.Text.Encoding.Default, True, 1)
            ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
            ToolStripStatusLabel1.Text = "Loading npcname-e.txt..."
            StatusStrip.Update()

            While inFile.EndOfStream <> True
                sTemp = inFile.ReadLine
                ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
                If sTemp <> "" And sTemp.StartsWith("//") = False Then

                    If InStr(sTemp, "Quest Monster") <> 0 Then

                        'npc_begin(0)      pet(1)     12077(2)   [pet_wolf_a](3)    level=15(4)
                        aTemp = sTemp.Split(Chr(9))

                        iTemp = aQuestNpc.Length
                        Array.Resize(aQuestNpc, iTemp + 1)
                        aQuestNpc(iTemp - 1) = aTemp(1).Remove(0, InStr(aTemp(1), "=")).Trim
                    End If

                End If
            End While
            inFile.Close()
            ToolStripProgressBar.Value = 0
        End If
        ' End of reading quest mobs

        OpenFileDialog.FileName = "npcdata.txt"
        'If System.IO.File.Exists("npcdata.txt") = False Then
        OpenFileDialog.Filter = "Lineage II server npc config|npcdata*.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        'End If

        System.IO.File.Copy(OpenFileDialog.FileName, OpenFileDialog.FileName & ".bak", True)
        inFile = New System.IO.StreamReader(OpenFileDialog.FileName & ".bak", System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter(OpenFileDialog.FileName, False, System.Text.Encoding.Unicode, 1)
        Dim outLog As New System.IO.StreamWriter(OpenFileDialog.FileName + "_scriptCheck.log", True, System.Text.Encoding.Unicode, 1)

        outLog.WriteLine("L2ScriptMaker: NpcData Analyser and Fixer.")
        outLog.WriteLine(Now & " Start" & vbNewLine)
        Dim AttackNpc() As String = {"warrior", "herb_warrior", "boss", "zzoldagu", "summon", "pet", "treasure", "siege_unit", "commander", "castle_gate", "temptrainer", "siege_weapon", "mercenary"}
        Dim AgroRangeNpc() As String = {"object", "summon", "pet", "treasure", "citizen", "merchant", "warehouse_keeper", "guild_master", "guild_coach", "blacksmith", "package_keeper"}
        ' Hellbound Boss's - Derek, Hellinark, Keltas, Typhoon, Archangel [29021] (Baium), 12532-12534 (Dietrich, Mikhail, Gustav), 12539-12543 (Beast Farm Boss's), "Scarlet of Halisha" (form1)
            Dim iSpecialBoss() As Integer = {18465, 22326, 22341, 25539, 29021, 12532, 12533, 12534, 12539, 12540, 12541, 12542, 12543, 29045, 29046}

        ' Skill Loaging END
        'Dim aSkillSymbol() As String = {";", "]"}   '{[DDMagic]=@s_blood_sucking6}  'npc_ai={}
        Dim aSkills(0) As String
        Dim iTempPos1 As Integer, iTempPos2 As Integer
        Dim sTempSkillName As String
        If CheckedListBox.CheckedItems.IndexOf("npc active skill") <> -1 Then

            OpenFileDialog.FileName = "skill_pch.txt"
            If System.IO.File.Exists("skill_pch.txt") = False Then
                'OpenFileDialog.FileName = "skilldata.txt"
                OpenFileDialog.Filter = "Lineage II server skill config (skill_pch.txt)|skill_pch.txt|All files|*.*"
                If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
                'sSkillDataFile = OpenFileDialog.FileName
            End If

            ' ---- Loading 'Skilldata.txt' ---- 
            Dim inSkillFile As New System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, True, 1)
            ToolStripProgressBar.Maximum = CInt(inSkillFile.BaseStream.Length)
            'ProgressBar.Text = "Loading skilldata.txt..."

            While inSkillFile.EndOfStream <> True

                sTemp = inSkillFile.ReadLine.Trim
                If sTemp <> "" And sTemp.StartsWith("//") = False Then
                    'skill_begin	skill_name = [s_quiver_of_arrows_a]	/* [?? ?? ???? - A????] */	skill_id = 323	level = 1	operate_type = A1	magic_level = 66	effect = {{i_restoration_random;{{{{[mithril_arrow];700}};30};{{{[mithril_arrow];1400}};50};{{{[mithril_arrow];2800}};20}}}}	is_magic = 1	mp_consume1 = 366	mp_consume2 = 0	item_consume = {[crystal_a];1}	cast_range = -1	effective_range = -1	skill_hit_time = 3	skill_cool_time = 0	skill_hit_cancel_time = 0.5	reuse_delay = 1800	attribute = attr_none	effect_point = 0	target_type = self	affect_scope = single	affect_limit = {0;0}	next_action = none	ride_state = {@ride_none;@ride_wind;@ride_star;@ride_twilight}	skill_end
                    'skill_begin	skill_name = [s_summon_cp_potion]	/* [?? CP ??] */	skill_id = 1324	level = 1	operate_type = A1	magic_level = -1	effect = {{i_restoration;[adv_cp_potion];20}}	is_magic = 1	mp_consume1 = 412	mp_consume2 = 0	item_consume = {[soul_ore];50}	cast_range = -1	effective_range = -1	skill_hit_time = 20	skill_cool_time = 0	skill_hit_cancel_time = 0.5	reuse_delay = 1800	attribute = attr_none	effect_point = 0	target_type = self	affect_scope = single	affect_limit = {0;0}	next_action = none	ride_state = {@ride_none;@ride_wind;@ride_star;@ride_twilight}	skill_end
                    iTemp = aSkills.Length
                    Array.Resize(aSkills, iTemp + 1)
                    'aSkills(iTemp - 1) = Libraries.GetNeedParamFromStr(sTemp, "skill_name").Replace("[", "").Replace("]", "")
                    sTemp2 = sTemp.Substring(0, InStr(sTemp, "=") - 1).Trim.Replace("[", "").Replace("]", "")
                    aSkills(iTemp - 1) = sTemp2
                End If
                ToolStripProgressBar.Value = CInt(inSkillFile.BaseStream.Position)
            End While

            ToolStripProgressBar.Value = 0
            inSkillFile.Close()
            Me.Refresh()
            StatusStrip.Update()

        End If
        ' Skill Loaging END

        ToolStripProgressBar.Value = 0
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripStatusLabel1.Text = "Fixing..."
        Me.Update()

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)

            If sTemp <> "" And sTemp.StartsWith("//") = False Then

                'npc_begin	zzoldagu	12545	[pirates_zombie_b]	level=57
                'slot_rhand=[mithril_dagger]
                'base_attack_type=dagger

                aTemp = sTemp.Split(Chr(9))

                ' Checking: acquire_exp_rate, acquire_sp
                If CheckedListBox.CheckedItems.IndexOf("acquire_exp_rate, acquire_sp") <> -1 Then
                    dTemp = CDbl(Libraries.GetNeedParamFromStr(sTemp, "acquire_exp_rate"))
                    sTemp2 = aTemp(1)

                    If aTemp(1) = "boss" Then
                        If dTemp < 100 Then
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", CStr(dTemp * 100))
                            outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "Now: acquire_exp_rate->" & CStr(dTemp * 100))
                        End If
                    End If

                    If aTemp(1) <> "warrior" And aTemp(1) <> "herb_warrior" And aTemp(1) <> "boss" Then
                        If dTemp > 0 Then
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", "0")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", "0")
                            outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "Now: acquire_exp_rate->0, acquire_sp->0")
                        End If
                    End If

                End If
                ' Checking: acquire_exp_rate END


                ' Checking: Unsowing (unsowing=0)
                'race=castle_guard
                If CheckedListBox.CheckedItems.IndexOf("unsowing") <> -1 Then
                    sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "race")
                    If Libraries.GetNeedParamFromStr(sTemp, "unsowing") = "0" Then
                        If aTemp(1) = "warrior" Or aTemp(1) = "herb_warrior" Then
                            ' Exception for Castle Guard
                            'npc_begin(0)      pet(1)     12077(2)   [pet_wolf_a](3)    level=15(4)
                            aTemp = sTemp.Split(Chr(9))
                            If sTemp2 = "castle_guard" Or sTemp2 = "mercenary" Or Array.IndexOf(aQuestNpc, aTemp(2)) <> -1 Then
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "unsowing", "1")
                                outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "Now: unsowing->1")
                            Else
                                ' Attention!
                                If NoWarriorCheckBox.Checked = False Then 'NoWarriorUndCheckBox
                                    'If UnsowingCheckBox.Checked = True Then
                                    If Libraries.GetNeedParamFromStr(sTemp, "unsowing") = "1" Then
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "unsowing", "0")
                                        outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "Now: unsowing->0")
                                    End If
                                    'End If
                                End If
                            End If
                        Else
                            If Libraries.GetNeedParamFromStr(sTemp, "unsowing") = "0" Then
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "unsowing", "1")
                                outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "Now: unsowing->1")
                            End If
                        End If
                    Else
                        'If Libraries.GetNeedParamFromStr(sTemp, "unsowing") = "1" Then
                    End If
                End If
                ' Checking: Unsowing END


                ' Checking: Weapon Type (slot_rhand, base_attack_type)
                If CheckedListBox.CheckedItems.IndexOf("slot_rhand, base_attack_type") <> -1 Then
                    sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "slot_rhand")
                    If sTemp2 = "[]" Then
                        If Libraries.GetNeedParamFromStr(sTemp, "base_attack_type") <> "fist" Then
                            'sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "fist")
                            'base_attack_type=fist	base_attack_range=40	base_damage_range={0;0;80;120}	base_rand_dam=7
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "fist")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "40")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "base_damage_range", "{0;0;80;120}")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "base_rand_dam", "7")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "base_critical", "4")
                            outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "Now: " & sTemp2 & " base_attack_type -> fist")
                        End If
                    Else
                        iTemp = Array.IndexOf(aItemPchName, sTemp2)
                        If iTemp = -1 Then
                            outLog.WriteLine("Unknown weapon:" & aTemp(1) & vbTab & vbTab & sTemp2 & vbTab & "Npc: " & aTemp(2) & vbTab & aTemp(3))
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "fist")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "40")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "base_damage_range", "{0;0;80;120}")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "base_rand_dam", "7")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "base_critical", "4")
                        Else
                            If Libraries.GetNeedParamFromStr(sTemp, "base_attack_type") <> aItemType(iTemp) Then
                                Select Case aItemType(iTemp)
                                    Case "dual"
                                        'base_attack_type=dual	base_attack_range=40	base_damage_range={0;0;80;120}	base_rand_dam=30
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "dual")
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "40")
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_damage_range", "{0;0;80;120}")
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_rand_dam", "30")
                                    Case "pole"
                                        'base_attack_type=pole	base_attack_range=80	base_damage_range={0;0;300;120}	base_rand_dam=30
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "pole")
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "80")
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_damage_range", "{0;0;300;120}")
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_rand_dam", "30")
                                    Case "bow"
                                        'base_attack_type=bow	base_attack_range=500	base_damage_range={0;0;10;0}	base_rand_dam=5
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "bow")
                                        If Libraries.GetNeedParamFromStr(sTemp, "race") = "castle_guard" Then
                                            sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "1100")
                                        Else
                                            sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "500")
                                        End If
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_damage_range", "{0;0;10;0}")
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_rand_dam", "5")
                                    Case "dagger"
                                        'base_attack_type=dagger	base_attack_range=40	base_damage_range={0;0;80;120}	base_rand_dam=10
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "dagger")
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "40")
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_damage_range", "{0;0;80;120}")
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_rand_dam", "10")
                                    Case "sword"
                                        'base_attack_type=sword	base_attack_range=40	base_damage_range={0;0;80;120}	base_rand_dam=30
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "dagger")
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "40")
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_damage_range", "{0;0;80;120}")
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_rand_dam", "30")
                                    Case "blunt"
                                        'base_attack_type=blunt	base_attack_range=40	base_damage_range={0;0;80;120}	base_rand_dam=50
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "dagger")
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "40")
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_damage_range", "{0;0;80;120}")
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_rand_dam", "50")
                                    Case Else
                                        'base_attack_type=fist	base_attack_range=40	base_damage_range={0;0;80;120}	base_rand_dam=7
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "fist")
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "40")
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_damage_range", "{0;0;80;120}")
                                        sTemp = Libraries.SetNeedParamToStr(sTemp, "base_rand_dam", "7")
                                End Select
                                ' check for fishingrod
                                'sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", aItemType(iTemp))
                                outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "Now: " & sTemp2 & " base_attack_type -> " & aItemType(iTemp))
                            End If
                        End If
                    End If
                End If
                ' Checking: Weapon Type END

                'Checking: no_sleep_mode (no_sleep_mode)
                If CheckedListBox.CheckedItems.IndexOf("no_sleep_mode") <> -1 Then
                    Select Case Libraries.GetNeedParamFromStr(sTemp, "no_sleep_mode")
                        Case "0"
                            If aTemp(1) = "boss" Or aTemp(1) = "zzoldagu" Then
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "no_sleep_mode", "1")
                                outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "Now: no_sleep_mode->1")
                            End If
                        Case "1"
                            If aTemp(1) <> "boss" And aTemp(1) <> "zzoldagu" Then
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "undying", "0")
                                outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "Now: no_sleep_mode->0")
                            End If
                    End Select
                End If
                'Checking: no_sleep_mode END

                'Checking: agro_range (agro_range)
                If CheckedListBox.CheckedItems.IndexOf("agro_range") <> -1 Then
                    Select Case Libraries.GetNeedParamFromStr(sTemp, "agro_range")
                        Case "0"
                            If Array.IndexOf(AgroRangeNpc, aTemp(1)) = -1 Then
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "agro_range", "1000")
                                outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "Now: agro_range->1000")
                            End If
                        Case Else
                            If Array.IndexOf(AgroRangeNpc, aTemp(1)) <> -1 Then
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "agro_range", "0")
                                outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "Now: agro_range->0")
                            End If
                    End Select
                End If
                'Checking: agro_range END

                'Checking: Undying (undying, can_be_attacked)
                If CheckedListBox.CheckedItems.IndexOf("undying, can_be_attacked") <> -1 Then
                    If Array.IndexOf(AttackNpc, aTemp(1)) <> -1 Then
                        ' This a No Peace NPC.

                        If aTemp(1) = "warrior" Or aTemp(1) = "herb_warrior" Then
                            If NoWarriorUndCheckBox.Checked = False Then 'NoWarriorUndCheckBox
                                If Libraries.GetNeedParamFromStr(sTemp, "undying") = "1" Then
                                    sTemp = Libraries.SetNeedParamToStr(sTemp, "undying", "0")
                                    sTemp = Libraries.SetNeedParamToStr(sTemp, "can_be_attacked", "1")
                                    outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "Now: undying->0, can_be_attacked->1")
                                End If
                            End If
                        Else
                            If Libraries.GetNeedParamFromStr(sTemp, "undying") = "1" Then
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "undying", "0")
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "can_be_attacked", "1")
                                outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "Now: undying->0, can_be_attacked->1")
                            End If
                        End If

                    Else
                        ' This a Peace NPC.
                        If aTemp(1) = "guard" Then
                            If Libraries.GetNeedParamFromStr(sTemp, "undying") <> "0" And Libraries.GetNeedParamFromStr(sTemp, "can_be_attacked") <> "0" Then
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "undying", "0")
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "can_be_attacked", "0")
                                outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "Now: undying->0, can_be_attacked->0")
                            End If
                        Else
                            If Libraries.GetNeedParamFromStr(sTemp, "undying") = "0" Then
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "undying", "1")
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "can_be_attacked", "0")
                                outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "Now: undying->1, can_be_attacked->0")
                            End If
                        End If
                    End If
                End If
                'Checking: Undying END

                'Checking: npc active skill
                If CheckedListBox.CheckedItems.IndexOf("npc active skill") <> -1 Then

                    'Dim aSkillSymbol() As String = {";", "]"}   '{[DDMagic]=@s_blood_sucking6}  'npc_ai={}
                    'Dim iTempPos1 As Integer, iTempPos2 As Integer
                    'Dim sTempSkillName As String
                    sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "npc_ai").Replace(Chr(9), "").Replace(" ", "")
                    iTempPos1 = InStr(sTemp2, "]=@s_")
                    While iTempPos1 > 0

                        iTempPos1 += 2
                        iTempPos2 = InStr(iTempPos1, sTemp2, "}") - 1
                        sTempSkillName = sTemp2.Substring(iTempPos1, iTempPos2 - iTempPos1)

                        If Array.IndexOf(aSkills, sTempSkillName) = -1 Then
                            'npc_begin	zzoldagu	12545	[pirates_zombie_b]	level=57
                            outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "Found undefined active skill: " & sTempSkillName)
                        End If

                        iTempPos1 = InStr(iTempPos2, sTemp2, "]=@s_")

                    End While
                    If iTempPos1 > 0 Then

                    End If


                End If
                'Checking: npc active skill


                'Checking: castle bowguard range
                If CheckedListBox.CheckedItems.IndexOf("castle bowguard range") <> -1 Then
                    If Libraries.GetNeedParamFromStr(sTemp, "race") = "castle_guard" Then
                        If Libraries.GetNeedParamFromStr(sTemp, "base_attack_type") = "bow" Then
                            If Libraries.GetNeedParamFromStr(sTemp, "base_attack_range") <> "1100" Then
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "1100")
                                outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "Now: castle bowguard range is 1100")
                            End If
                        End If

                    End If

                End If
                'Checking: castle bowguard range

                'Checking: npc race (Use passive skills for define race)
                If CheckedListBox.CheckedItems.IndexOf("npc race") <> -1 Then

                    'none		- (forms, алтари, агашены)
                    'animal		s_race_animals
                    'dragon		s_race_dragons
                    'fairy		s_race_fairies
                    'etc		s_race_others
                    'angel		s_race_angels
                    'construct	s_race_magic_creatures
                    'creature	s_race_unknown_creature
                    'human		s_race_humans
                    'humanoid	s_race_humanoids
                    'beast		s_race_beasts
                    'undead		s_race_undead
                    'elemental	s_race_spirits
                    'demonic	s_race_demonic
                    'siege_weapon	s_race_siege_weapons
                    'divine		s_race_divine
                    'bug		s_race_bugs
                    'plant		s_race_plants
                    'giant		s_race_giants
                    'kamael		s_race_kamaels
                    'elf		s_race_elves
                    'dwarf		s_race_dwarves
                    'darkelf	s_race_dark_elves
                    'orc		s_race_orcs
                    'castle_guard	s_race_defending_army
                    'mercenary	s_race_mercenaries

                    'skill_list={@s_race_fairies;@s_summon_magic_defence}	
                    aTemp2 = Libraries.GetNeedParamFromStr(sTemp, "skill_list").Replace("{", Nothing).Replace("}", Nothing).Replace("@", Nothing).Split(CChar(";"))
                    If Libraries.GetNeedParamFromStr(sTemp, "skill_list") <> "{}" Then

                        For iTemp = 0 To aTemp2.Length - 1
                            If Array.IndexOf(aRaceSkill, aTemp2(iTemp)) <> -1 Then
                                iTemp = Array.IndexOf(aRaceSkill, aTemp2(iTemp))
                                If aRace(iTemp) <> Libraries.GetNeedParamFromStr(sTemp, "race") Then
                                    ' Fix race
                                    sTempSkillName = Libraries.GetNeedParamFromStr(sTemp, "race")
                                    sTemp = Libraries.SetNeedParamToStr(sTemp, "race", aRace(iTemp))
                                    outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "Now: race=" & sTempSkillName & " -> " & aRace(iTemp) & vbTab & "where skill_list=" & Libraries.GetNeedParamFromStr(sTemp, "skill_list"))
                                End If
                                iTemp = aTemp2.Length
                                Exit For
                            End If
                        Next
                        ' checking: found race or not
                        If iTemp = aTemp2.Length Then
                            sTemp2 = "none"
                        End If
                    Else

                        If Libraries.GetNeedParamFromStr(sTemp, "race") <> "none" Then
                            ' Fix race
                            sTempSkillName = Libraries.GetNeedParamFromStr(sTemp, "race")
                            If aTemp(2) = "warrior" Or aTemp(2) = "boss" Or aTemp(2) = "zzoldagu" Then
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "race", "etc")
                            Else
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "race", "none")
                            End If
                            outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "Now: race=" & sTempSkillName & " -> none")
                        End If

                    End If
                End If
                'Checking: npc race end

                'Checking: stats (str,int,dex,wit,con,men) end
                If CheckedListBox.CheckedItems.IndexOf("stats (str,int,dex,wit,con,men)") <> -1 Then

                    ' BOSS/Mobs Stats bug fix!
                    'doppelganger, pc_trap
                    If CheckBoxZzoldagu74.Checked = True Then
                        If aTemp(1) = "zzoldagu" And CInt(Libraries.GetNeedParamFromStr(sTemp, "level")) >= 74 Then
                            aTemp(1) = "boss"
                        End If
                    End If

                    'Dim iSpecialBoss() As Integer = {18465, 22326, 22341, 25539} ' Hellbound Boss's - Derek, Hellinark, Keltas, Typhoon
                    If Array.IndexOf(iSpecialBoss, CInt(aTemp(2))) <> -1 Then
                        aTemp(1) = "boss"
                    End If

                    sTemp2 = sTemp
                    Select Case aTemp(1)
                        Case "boss"
                            'str=60	int=76	dex=73	wit=70	con=57	men=80  boss
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "str", "60")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "int", "76")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "dex", "73")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "wit", "70")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "con", "57")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "men", "80")
                        Case "zzoldagu"
                            'str=40	int=41	dex=30	wit=20	con=43	men=10  zzoldagu
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "str", "40")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "int", "41")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "dex", "30")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "wit", "20")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "con", "43")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "men", "10")
                        Case "warrior"
                            'str=40	int=41	dex=30	wit=20	con=43	men=10  warrior
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "str", "40")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "int", "21")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "dex", "30")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "wit", "20")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "con", "43")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "men", "10")

                            '12762	[dawn_hero_sword_move], 12763	[dawn_hero_wizard_move]
                            If aTemp(2) = "12762" Or aTemp(2) = "12763" Then
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "str", "84")
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "int", "76")
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "dex", "73")
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "wit", "70")
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "con", "71")
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "men", "80")
                            End If

                        Case "pet"
                            'str=40	int=21	dex=30	wit=20	con=43	men=25  pet,summon
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "str", "40")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "int", "21")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "dex", "30")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "wit", "20")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "con", "43")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "men", "25")

                            'pet 12564 [sin_eater]
                            If aTemp(2) = "12564" Then
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "con", "1")
                            End If

                        Case "summon"
                            'str=40	int=21	dex=30	wit=20	con=43	men=25  pet,summon
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "str", "40")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "int", "21")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "dex", "30")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "wit", "20")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "con", "43")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "men", "25")
                        Case Else
                            'str=40	int=21	dex=30	wit=20	con=43	men=10  citizen and etc
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "str", "40")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "int", "21")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "dex", "30")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "wit", "20")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "con", "43")
                            sTemp = Libraries.SetNeedParamToStr(sTemp, "men", "10")
                    End Select
                    If sTemp2 <> sTemp Then
                        outLog.WriteLine("Fixed: " & aTemp(1) & vbTab & aTemp(2) & vbTab & aTemp(3) & vbTab & "New stats (str,int,dex,wit,con,men) now.")
                    End If

                End If
                'Checking: stats (str,int,dex,wit,con,men) end


            End If
            outFile.WriteLine(sTemp)

        End While


        ToolStripProgressBar.Value = 0
        outLog.WriteLine(Now & " End")
        outLog.WriteLine()

        outLog.Close()
        inFile.Close()
        outFile.Close()

        MessageBox.Show("Complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Dispose()
    End Sub

End Class