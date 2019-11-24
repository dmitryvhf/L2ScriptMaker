Public Class L2J_NpcData

    Private Structure Items
        Dim name As String
        Dim item_type As String         'item_type=armor,shield,weapon
        Dim weapon_type As String       'weapon_type=none,dagger, pole,dual ({lrhand})
        Dim shield_defense As String
        Dim shield_defense_rate As String
        Dim critical As String
        Dim hit_modify As String
        Dim avoid_modify As String
        Dim attack_range As String
        Dim damage_range As String
        Dim reuse_delay As String
        Dim random_damage As String
        'Dim armor_type As String       'armor_type=shield	
        'Dim slot_bit_type As String     'slot_bit_type={none}, {lhand} - shield, {rhand} - weapon
    End Structure



    Private Sub ButtonExpSP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExpSP.Click

        Dim sTemp As String, sNpcFile As String
        Dim inNpcFile As System.IO.StreamReader

        OpenFileDialog.Filter = "NpcData.txt|npcdata.txt|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sNpcFile = OpenFileDialog.FileName

        System.IO.File.Copy(sNpcFile, sNpcFile & ".bak", True)
        inNpcFile = New System.IO.StreamReader(sNpcFile & ".bak", System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter(sNpcFile, False, System.Text.Encoding.Unicode, 1)

        ToolStripProgressBar.Maximum = CInt(inNpcFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading/Writing npcdata.txt..."

        Dim dExp As String, sSP As String
        Dim sSkill As String

        While inNpcFile.EndOfStream <> True
            sTemp = inNpcFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inNpcFile.BaseStream.Position)

            If sTemp.StartsWith("npc_begin") = True Then
                'npc_begin	warrior	20761	[pytan]	level=69	acquire_exp_rate=8.3592	acquire_sp=3894	unsowing=0	clan={@MALRUK_CLAN}	ignore_clan_list={}	clan_help_range=500	slot_chest=[]	slot_rhand=[]	slot_lhand=[]	
                'shield_defense_rate=0	shield_defense=0	skill_list={}	

                sSkill = Libraries.GetNeedParamFromStr(sTemp, "skill_list")
                dExp = Libraries.GetNeedParamFromStr(sTemp, "acquire_exp_rate")
                sSP = Libraries.GetNeedParamFromStr(sTemp, "acquire_sp")

                's_hp_increase10 - hp*2 = exp*2,sp*2
                's_hp_increase11 - hp*3 = exp*3,sp*3
                's_hp_increase12 - hp*4 = exp*4,sp*4
                's_hp_increase13 - hp*5 = exp*5,sp*5
                's_hp_increase14 - hp*6 = exp*6,sp*6
                's_hp_increase15 - hp*7 = exp*7,sp*7
                's_hp_increase16 - hp*8 = exp*8,sp*8
                's_hp_increase17 - hp*9 = exp*9,sp*9
                's_hp_increase18 - hp*10 = exp*10,sp*10
                's_hp_increase19 - hp*11 = exp*11,sp*11
                's_hp_increase20 - hp*12 = exp*12,sp*12

                If InStr(sTemp, "s_hp_increase10") > 0 Then
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Format((CDbl(dExp) * 2), "0.####"))
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", CStr(CInt(sSP) * 2))
                End If
                If InStr(sTemp, "s_hp_increase11") > 0 Then
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Format((CDbl(dExp) * 3), "0.####"))
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", CStr(CInt(sSP) * 3))
                End If
                If InStr(sTemp, "s_hp_increase12") > 0 Then
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Format((CDbl(dExp) * 4), "0.####"))
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", CStr(CInt(sSP) * 4))
                End If
                If InStr(sTemp, "s_hp_increase13") > 0 Then
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Format((CDbl(dExp) * 5), "0.####"))
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", CStr(CInt(sSP) * 5))
                End If
                If InStr(sTemp, "s_hp_increase14") > 0 Then
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Format((CDbl(dExp) * 6), "0.####"))
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", CStr(CInt(sSP) * 6))
                End If
                If InStr(sTemp, "s_hp_increase15") > 0 Then
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Format((CDbl(dExp) * 7), "0.####"))
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", CStr(CInt(sSP) * 7))
                End If
                If InStr(sTemp, "s_hp_increase16") > 0 Then
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Format((CDbl(dExp) * 8), "0.####"))
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", CStr(CInt(sSP) * 8))
                End If
                If InStr(sTemp, "s_hp_increase17") > 0 Then
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Format((CDbl(dExp) * 9), "0.####"))
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", CStr(CInt(sSP) * 9))
                End If
                If InStr(sTemp, "s_hp_increase18") > 0 Then
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Format((CDbl(dExp) * 10), "0.####"))
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", CStr(CInt(sSP) * 10))
                End If
                If InStr(sTemp, "s_hp_increase19") > 0 Then
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Format((CDbl(dExp) * 11), "0.####"))
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", CStr(CInt(sSP) * 11))
                End If
                If InStr(sTemp, "s_hp_increase20") > 0 Then
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Format((CDbl(dExp) * 12), "0.####"))
                    sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", CStr(CInt(sSP) * 12))
                End If

            End If
            outFile.WriteLine(sTemp)

        End While
        outFile.Close()
        inNpcFile.Close()
        ToolStripProgressBar.Value = 0


        MessageBox.Show("Completed.")


    End Sub

    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click

        Dim sNpcFile As String
        Dim sTemp As String, sTempForWrite As String = ""
        Dim iTemp As Integer
        Dim aTemp() As String

        Dim inNpcFile As System.IO.StreamReader

        ' LOADING itemdata.txt
        If System.IO.File.Exists("itemdata.txt") = False Then
            MessageBox.Show("itemdata.txt not found", "Need itemdata.txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim aItemPch(25000) As Items
        inNpcFile = New System.IO.StreamReader("itemdata.txt", System.Text.Encoding.Default, True, 1)
        ToolStripProgressBar.Maximum = CInt(inNpcFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading itemdata.txt ..."

        aItemPch(0).shield_defense = "0"
        aItemPch(0).shield_defense_rate = "0"
        aItemPch(0).damage_range = "0"
        aItemPch(0).random_damage = "0"
        aItemPch(0).critical = "0"
        aItemPch(0).hit_modify = "0"
        aItemPch(0).reuse_delay = "0"
        aItemPch(0).weapon_type = ""

        While inNpcFile.EndOfStream <> True

            sTemp = inNpcFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inNpcFile.BaseStream.Position)
            If sTemp.StartsWith("item_begin") = True Then

                '[small_sword] = 1
                '0          1       2       3
                'item_begin	armor	6721	[shield_of_imperial_warlord_zombie]	item_type=armor	slot_bit_type={lhand}	armor_type=shield	etcitem_type=none	recipe_id=0	blessed=0	weight=1430	
                'default_action=action_equip	consume_type=consume_type_normal	initial_count=1	maximum_count=1	soulshot_count=0	spiritshot_count=0	reduced_soulshot={}	reduced_spiritshot={}	
                'reduced_mp_consume={}	immediate_effect=1	price=0	default_price=39	item_skill=[none]	critical_attack_skill=[none]	attack_skill=[none]	magic_skill=[none]	item_skill_enchanted_four=[none]	
                'material_type=leather	crystal_type=none	crystal_count=0	is_trade=1	is_drop=1	is_destruct=1	physical_damage=0	random_damage=0	weapon_type=none	can_penetrate=0	critical=0	hit_modify=0	
                'avoid_modify=-8	dual_fhit_rate=0	shield_defense=47	shield_defense_rate=20	attack_range=0	damage_range={}	attack_speed=0	reuse_delay=0	mp_consume=0	magical_damage=0	
                'durability=90	damaged=0	physical_defense=0	magical_defense=0	mp_bonus=0	category={}	enchanted=0	html=[item_default.htm]	equip_pet={0}	magic_weapon=0	enchant_enable=0	mana=0	
                'base_attribute_attack={attr_none;0}	base_attribute_defend={0;0;0;0;0;0}	elemental_enable=0	is_deposit=1	equip_cond = {{ec_race;{@RACE_KAMAEL};0}}	item_end

                sTemp = sTemp.Replace(" ", Chr(9))
                aTemp = sTemp.Split(CChar(Chr(9)))

                iTemp = CInt(aTemp(2))
                Try
                    aItemPch(iTemp).name = aTemp(3)
                    aItemPch(iTemp).item_type = Libraries.GetNeedParamFromStr(sTemp, "item_type")
                    aItemPch(iTemp).weapon_type = Libraries.GetNeedParamFromStr(sTemp, "weapon_type")
                    aItemPch(iTemp).attack_range = Libraries.GetNeedParamFromStr(sTemp, "attack_range")
                    aItemPch(iTemp).damage_range = Libraries.GetNeedParamFromStr(sTemp, "damage_range")
                    aItemPch(iTemp).random_damage = Libraries.GetNeedParamFromStr(sTemp, "random_damage")
                    aItemPch(iTemp).critical = Libraries.GetNeedParamFromStr(sTemp, "critical")
                    aItemPch(iTemp).hit_modify = Libraries.GetNeedParamFromStr(sTemp, "hit_modify")
                    aItemPch(iTemp).avoid_modify = Libraries.GetNeedParamFromStr(sTemp, "avoid_modify")
                    aItemPch(iTemp).reuse_delay = Libraries.GetNeedParamFromStr(sTemp, "reuse_delay")
                    aItemPch(iTemp).shield_defense = Libraries.GetNeedParamFromStr(sTemp, "shield_defense")
                    aItemPch(iTemp).shield_defense_rate = Libraries.GetNeedParamFromStr(sTemp, "shield_defense_rate")
                    'aItemPch(iTemp).slot_bit_type = Libraries.GetNeedParamFromStr(sTemp, "slot_bit_type")
                Catch ex As Exception
                    MessageBox.Show("Error in loading itemdata.txt. Last reading line:" & vbNewLine & sTemp)
                    inNpcFile.Close()
                    Exit Sub
                End Try

            End If

        End While
        inNpcFile.Close()
        ToolStripProgressBar.Value = 0

        ' LOADING npc_exp_table.txt
        If System.IO.File.Exists("npc_exp_table.txt") = False Then
            MessageBox.Show("npc_exp_table.txt not found", "Need itemdata.txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim aNpcExp(100) As String
        Dim iExpCounter As Integer = 0
        inNpcFile = New System.IO.StreamReader("npc_exp_table.txt", System.Text.Encoding.Default, True, 1)
        ToolStripProgressBar.Maximum = CInt(inNpcFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading npc_exp_table.txt ..."

        While inNpcFile.EndOfStream <> True

            sTemp = inNpcFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inNpcFile.BaseStream.Position)
            sTemp = sTemp.Trim
            If sTemp <> "" And sTemp.StartsWith("//") = False Then

                '804225364.0
                iExpCounter = iExpCounter + 1
                Try
                    aNpcExp(iExpCounter) = sTemp
                Catch ex As Exception
                    MessageBox.Show("Error in loading npc_exp_table.txt. Last reading line:" & vbNewLine & sTemp)
                    inNpcFile.Close()
                    Exit Sub
                End Try

            End If

        End While
        inNpcFile.Close()
        ToolStripProgressBar.Value = 0

        ' LOADING npc_exp_table.txt
        If System.IO.File.Exists("npc_exp_table.txt") = False Then
            MessageBox.Show("npc_exp_table.txt not found", "Need itemdata.txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim aLevelBonus(100) As String
        iExpCounter = 0

        inNpcFile = New System.IO.StreamReader("npc_level_bonus_table.txt", System.Text.Encoding.Default, True, 1)
        ToolStripProgressBar.Maximum = CInt(inNpcFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading npc_level_bonus_table.txt ..."

        While inNpcFile.EndOfStream <> True

            sTemp = inNpcFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inNpcFile.BaseStream.Position)
            sTemp = sTemp.Trim
            If sTemp <> "" And sTemp.StartsWith("//") = False Then

                '804225364.0
                iExpCounter = iExpCounter + 1
                Try
                    aLevelBonus(iExpCounter) = sTemp
                Catch ex As Exception
                    MessageBox.Show("Error in loading npc_level_bonus_table.txt. Last reading line:" & vbNewLine & sTemp)
                    inNpcFile.Close()
                    Exit Sub
                End Try

            End If

        End While
        inNpcFile.Close()
        ToolStripProgressBar.Value = 0


        ' LOADING npc_exp_table.txt
        If System.IO.File.Exists("NpcName-e.txt") = False Then
            MessageBox.Show("NpcName-e.txt not found", "Need NpcName-e.txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim aNpcRaid(40000) As Boolean
        iExpCounter = 0

        inNpcFile = New System.IO.StreamReader("NpcName-e.txt", System.Text.Encoding.Default, True, 1)
        ToolStripProgressBar.Maximum = CInt(inNpcFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading NpcName-e.txt ..."
        '        Dim iSpecialBoss() As Integer = {18465, 22326, 22341, 25539, 29021, 12532, 12533, 12534, 12539, 12540, 12541, 12542, 12543, 29045, 29046}

        While inNpcFile.EndOfStream <> True

            sTemp = inNpcFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inNpcFile.BaseStream.Position)
            sTemp = sTemp.Trim
            If InStr(sTemp, "id=25563") > 0 Then
                Dim assd As Boolean = True
            End If
            If sTemp <> "" And sTemp.StartsWith("//") = False Then

                'npcname_begin	id=25001	name=[Greyclaw Kutus]	description=[Raid Boss]	            rgb[0]=[3F]	rgb[1]=[8B]	rgb[2]=[FE]	reserved1=-1	npcname_end
                'npcname_begin	id=25563	name=[Beautiful Atrielle]	description=[Forsaken Prisoner]	rgb[0]=[3F]	rgb[1]=[8B]	rgb[2]=[FE]	reserved1=-1	npcname_end
                'npcname_begin	id=20001	name=[Gremlin]	        description=[]	                    rgb[0]=[9C]	rgb[1]=[E8]	rgb[2]=[A9]	reserved1=-1	npcname_end
                If Libraries.GetNeedParamFromStr(sTemp, "rgb[0]") = "[3F]" Then
                    Try
                        aNpcRaid(CInt(Libraries.GetNeedParamFromStr(sTemp, "id"))) = True
                    Catch ex As Exception
                        MessageBox.Show("Error in loading NpcName-e.txt. Last reading line:" & vbNewLine & sTemp)
                        inNpcFile.Close()
                        Exit Sub
                    End Try
                End If
            End If

        End While
        inNpcFile.Close()
        ToolStripProgressBar.Value = 0

        OpenFileDialog.Filter = "L2J Npc (npc.sql)|npc.sql|All files|*.*"
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sNpcFile = OpenFileDialog.FileName

        inNpcFile = New System.IO.StreamReader(sNpcFile, System.Text.Encoding.Default, True, 1)
        Dim outFile As New System.IO.StreamWriter("npcdata_l2j.txt", False, System.Text.Encoding.Unicode, 1)

        ToolStripProgressBar.Maximum = CInt(inNpcFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading npc.sql..."

        Dim iSlotWeapon As Integer
        Dim iSlotArmor As Integer

        While inNpcFile.EndOfStream <> True

            sTemp = inNpcFile.ReadLine.Trim
            ToolStripProgressBar.Value = CInt(inNpcFile.BaseStream.Position)
            If sTemp.StartsWith("(") = True Then  'sTemp <> "" And sTemp.StartsWith("//") = False

                ' 0     1     2       3  4 5  6                             7    8     9  10        11         12  13   14  15    16   17 18 19 20 21 22 23   24  25   26  27  28  29  30  31  32 33 34 35 36 37  38 39 40          41
                '(20761,20761,'Pytan',0,'',0,'LineageMonster.bloody_queen',14.00,40.00,69,'female','L2Monster',40,3784,1458,35.55,2.78,40,43,30,21,20,10,6633,649,1392,418,746,373,278,500,333,0,  0, 0, 0,88,191, 0,10,'LAST_HIT','false'),
                sTemp = sTemp.Substring(InStr(sTemp, "("), InStr(sTemp, ")") - InStr(sTemp, "(") - 1)
                aTemp = sTemp.Split(CChar(","))

                iSlotWeapon = CInt(aTemp(32))
                iSlotArmor = CInt(aTemp(33))


                'npc_begin	warrior	20761	[pytan]	level=69	acquire_exp_rate=8.3592	acquire_sp=3894	unsowing=0	clan={@MALRUK_CLAN}	ignore_clan_list={}	clan_help_range=500	slot_chest=[]	slot_rhand=[]	slot_lhand=[]	
                'shield_defense_rate=0	shield_defense=0	skill_list={}	
                'npc_ai={[pytan];{[MoveAroundSocial]=60};{[MoveAroundSocial1]=60};{[MoveAroundSocial2]=60};{[ShoutTarget]=1};{[SetHateGroup]=@attacker_group};{[SetHateGroupRatio]=20};{[DDMagic]=@s_blood_sucking6}}	
                'category={}	race=demonic	sex=female	undying=0	can_be_attacked=1	corpse_time=7	no_sleep_mode=0	agro_range=1000	ground_high={171.9;0;0}	ground_low={79.2;0;0}	
                'exp=387199547.925	org_hp=2395	org_hp_regen=35.55	org_mp=1458	org_mp_regen=2.78	collision_radius={14;14}	collision_height={40;40}	
                'str=40	int=21	dex=30	wit=20	con=43	men=10	base_attack_type=fist	base_attack_range=40	base_damage_range={0;0;80;120}	base_rand_dam=7	base_physical_attack=779.52	base_critical=12	
                'physical_hit_modify=-3.75	base_attack_speed=247.42	base_reuse_delay=0	base_magic_attack=507.28	base_defend=280.06	base_magic_defend=227.53	
                'physical_avoid_modify=0	soulshot_count=0	spiritshot_count=0	hit_time_factor=0.5	item_make_list={}	
                'corpse_make_list={{[rp_soulshot_a];1;1;2.2134};{[oriharukon_ore];1;1;100};{[stone_of_purity];1;1;100}}	additional_make_list={}	
                'additional_make_multi_list={}	hp_increase=0	mp_increase=0	safe_height=100	drop_herb=0	npc_end

                outFile.Write("npc_begin" & vbTab)

#If DEBUG Then
                If aTemp(0) = "25563" Then
                    Dim assd2 As Boolean = True
                End If
#End If

                aTemp(11) = aTemp(11).Replace("'", "")
                Select Case aTemp(11)
                    Case "L2Npc"
                        aTemp(11) = "citizen"
                    Case "L2Auctioneer"
                        aTemp(11) = "citizen"
                    Case "L2PetManager"
                        aTemp(11) = "citizen"
                    Case "L2MercenaryManager"
                        aTemp(11) = "citizen"
                    Case "L2FameManager"
                        aTemp(11) = "citizen"
                    Case "L2Monster"
                        aTemp(11) = "warrior"
                    Case "L2GrandBoss"
                        aTemp(11) = "boss"
                    Case "L2RaidBoss"
                        aTemp(11) = "boss"
                    Case "L2Minion"
                        aTemp(11) = "zzoldagu"
                    Case "L2Pet"
                        aTemp(11) = "summon"
                    Case "L2Merchant"
                        aTemp(11) = "merchant"
                    Case "L2Trainer"
                        aTemp(11) = "guild_coach"
                    Case "L2Warehouse"
                        aTemp(11) = "warehouse_keeper"
                    Case "L2Teleporter"
                        aTemp(11) = "teleporter"
                    Case "L2Guard"
                        aTemp(11) = "guard"
                    Case "L2Decoy"
                        aTemp(11) = "doppelganger"
                    Case "L2SiegeSummon"
                        aTemp(11) = "summon"
                    Case "L2BabyPet"
                        aTemp(11) = "pet"
                    Case "L2Chest"
                        aTemp(11) = "treasure"
                    Case Else
                        aTemp(11) = "warrior"
                        If aTemp(11).StartsWith("L2VillageMaster") = True Then aTemp(11) = "guild_master"
                        'L2TamedBeast   - warrior
                        'L2PenaltyMonster - fishing_blocker
                End Select


                ' BOSS/Mobs Stats bug fix!
                If CheckBoxFixStats.Checked = True Then

                    'aTemp(9) - level
                    If CheckBoxZzoldagu74.Checked = True Then
                        If aTemp(11) = "zzoldagu" And CInt(aTemp(9)) >= 73 Then
                            aTemp(11) = "boss"
                        End If
                    End If

                    If (aNpcRaid(CInt(aTemp(0)))) = True Then
                        If aTemp(11) <> "boss" And aTemp(11) <> "zzoldagu" Then aTemp(11) = "boss"
                    End If

                    ' BOSS/Mobs Stats bug fix!
                    'doppelganger, pc_trap
                    Select Case aTemp(11)
                        Case "boss"
                            'str=60	int=76	dex=73	wit=70	con=57	men=80  boss
                            aTemp(17) = "60"
                            aTemp(20) = "76"
                            aTemp(19) = "73"
                            aTemp(21) = "70"
                            aTemp(18) = "57"
                            aTemp(22) = "80"
                        Case "zzoldagu"
                            'str=40	int=41	dex=30	wit=20	con=43	men=10  zzoldagu
                            aTemp(17) = "40"
                            aTemp(20) = "41"
                            aTemp(19) = "30"
                            aTemp(21) = "20"
                            aTemp(18) = "43"
                            aTemp(22) = "10"
                        Case "warrior"
                            'str=40	int=21	dex=30	wit=20	con=43	men=10  warrior
                            aTemp(17) = "40"
                            aTemp(20) = "21"
                            aTemp(19) = "30"
                            aTemp(21) = "20"
                            aTemp(18) = "43"
                            aTemp(22) = "10"
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
                            aTemp(17) = "40"
                            aTemp(20) = "21"
                            aTemp(19) = "30"
                            aTemp(21) = "20"
                            aTemp(18) = "43"
                            aTemp(22) = "25"
                            'pet 12564 [sin_eater]
                            If aTemp(2) = "12564" Then
                                sTemp = Libraries.SetNeedParamToStr(sTemp, "con", "1")
                            End If
                        Case "summon"
                            'str=40	int=21	dex=30	wit=20	con=43	men=25  pet,summon
                            aTemp(17) = "40"
                            aTemp(20) = "21"
                            aTemp(19) = "30"
                            aTemp(21) = "20"
                            aTemp(18) = "43"
                            aTemp(22) = "25"
                        Case Else
                            'str=40	int=21	dex=30	wit=20	con=43	men=10  citizen and etc
                            aTemp(17) = "40"
                            aTemp(20) = "21"
                            aTemp(19) = "30"
                            aTemp(21) = "20"
                            aTemp(18) = "43"
                            aTemp(22) = "10"
                    End Select
                End If

                'warrior
                outFile.Write(aTemp(11) & vbTab)

                '20761
                outFile.Write(aTemp(0) & vbTab)

                '[pytan]
                sTempForWrite = aTemp(2)
                sTempForWrite = sTempForWrite.ToLower
                sTempForWrite = sTempForWrite.Replace("\", "").Replace("'", "").Replace("-", "").Replace(" ", "_").Replace(".", "_")
                If sTempForWrite = "" Then sTempForWrite = "_noname_" & aTemp(0)
                outFile.Write("[" & sTempForWrite & "]" & vbTab)

                'level=69
                'If aTemp(1) = "20761" Then
                '    Dim asd As Boolean = False
                'End If
                outFile.Write("level=" & aTemp(9) & vbTab)
                outFile.Write("acquire_exp_rate=" & CDbl(Format((CDbl(aTemp(23)) / (CDbl(aTemp(9)) ^ 2)), "0.####")) & vbTab)     'acquire_exp_rate= EXP/lvl^2      'CDbl(Format(iSumChance, "0.####"))     CDbl(CDbl(aTemp(23)) / (CDbl(aTemp(9)) ^ 2))
                outFile.Write("acquire_sp=" & CInt(CDbl(aTemp(24))) & vbTab)

                If aTemp(11) = "warrior" Or aTemp(11) = "boss" Or aTemp(11) = "zzoldagu" Then
                    sTempForWrite = "0"
                Else
                    sTempForWrite = "1"
                End If
                outFile.Write("unsowing=" & sTempForWrite & vbTab)

                outFile.Write("clan={}" & vbTab)                ' not defined
                outFile.Write("ignore_clan_list={}" & vbTab)
                outFile.Write("clan_help_range=500" & vbTab)    ' not defined

                'slot_rhand=[apprentice_s_rod]	
                'slot_rhand=[doll_knife]	slot_lhand=[doll_knife]	
                sTempForWrite = "[]" ' : If aTemp(34) <> "0" And aTemp(34) <> "NULL" Then sTempForWrite = aItemPch(CInt(aTemp(34)))
                outFile.Write("slot_chest=" & sTempForWrite & "" & vbTab)          'aTemp(34)
                sTempForWrite = "[]" : If aTemp(32) <> "0" And aTemp(34) <> "NULL" Then sTempForWrite = aItemPch(iSlotWeapon).name
                outFile.Write("slot_rhand=" & sTempForWrite & "" & vbTab)          'aTemp(32)
                sTempForWrite = "[]" : If aTemp(33) <> "0" And aTemp(34) <> "NULL" Then sTempForWrite = aItemPch(iSlotArmor).name
                outFile.Write("slot_lhand=" & sTempForWrite & "" & vbTab)          'aTemp(33)

                'item_begin	armor	6721	[shield_of_imperial_warlord_zombie]	item_type=armor	slot_bit_type={lhand}	armor_type=shield	etcitem_type=none	recipe_id=0	blessed=0	weight=1430	default_action=action_equip	consume_type=consume_type_normal	initial_count=1	maximum_count=1	soulshot_count=0	spiritshot_count=0	reduced_soulshot={}	reduced_spiritshot={}	reduced_mp_consume={}	immediate_effect=1	price=0	default_price=39	item_skill=[none]	critical_attack_skill=[none]	attack_skill=[none]	magic_skill=[none]	item_skill_enchanted_four=[none]	material_type=leather	crystal_type=none	crystal_count=0	is_trade=1	is_drop=1	is_destruct=1	physical_damage=0	random_damage=0	weapon_type=none	can_penetrate=0	critical=0	hit_modify=0	avoid_modify=-8	dual_fhit_rate=0	shield_defense=47	shield_defense_rate=20	attack_range=0	damage_range={}	attack_speed=0	reuse_delay=0	mp_consume=0	magical_damage=0	durability=90	damaged=0	physical_defense=0	magical_defense=0	mp_bonus=0	category={}	enchanted=0	html=[item_default.htm]	equip_pet={0}	magic_weapon=0	enchant_enable=0	mana=0	base_attribute_attack={attr_none;0}	base_attribute_defend={0;0;0;0;0;0}	elemental_enable=0	is_deposit=1	equip_cond = {{ec_race;{@RACE_KAMAEL};0}}	item_end

                outFile.Write("shield_defense_rate=" & aItemPch(iSlotArmor).shield_defense_rate & vbTab)
                outFile.Write("shield_defense=" & aItemPch(iSlotArmor).shield_defense & vbTab)
                outFile.Write("skill_list={}" & vbTab)

                sTempForWrite = aTemp(6).Substring(InStr(aTemp(6), "."), aTemp(6).Length - InStr(aTemp(6), ".") - 1)
                outFile.Write("npc_ai={[" & sTempForWrite & "]}" & vbTab)

                outFile.Write("category={}" & vbTab)
                outFile.Write("race=human" & vbTab)

                outFile.Write("sex=" & aTemp(10).Replace("'", "") & vbTab)

                If aTemp(11) = "citizen" Or aTemp(11) = "merchant" Or aTemp(11) = "guild_coach" Or aTemp(11) = "warehouse_keeper" Or aTemp(11) = "teleporter" Or aTemp(11) = "blacksmith" Or aTemp(11) = "package_keeper" Or _
                    aTemp(11) = "guild_master" Or aTemp(11) = "trainer" Or aTemp(11) = "mrkeeper" Or aTemp(11) = "monrace" Or aTemp(11) = "xmastree" Or aTemp(11) = "house_master" Or aTemp(11) = "newbie_guide" Then

                    outFile.Write("undying=1" & vbTab)                  ' not defined
                    outFile.Write("can_be_attacked=0" & vbTab)          ' not defined
                    outFile.Write("corpse_time=7" & vbTab)              ' not defined
                    outFile.Write("no_sleep_mode=1" & vbTab)            ' not defined
                Else
                    outFile.Write("undying=0" & vbTab)                  ' not defined
                    outFile.Write("can_be_attacked=1" & vbTab)          ' not defined
                    outFile.Write("corpse_time=7" & vbTab)              ' not defined
                    outFile.Write("no_sleep_mode=0" & vbTab)            ' not defined
                End If

                outFile.Write("agro_range=" & aTemp(30) & vbTab)
                outFile.Write("ground_high={" & aTemp(37) & ";0;0}" & vbTab)
                outFile.Write("ground_low={" & aTemp(36) & ";0;0}" & vbTab)
                outFile.Write("exp=" & aNpcExp(CInt(aTemp(9))) & vbTab)
                outFile.Write("org_hp=" & CInt(CDbl(aTemp(13)) / (CDbl(aTemp(18)) / 100 + 1)) & vbTab)              'HP=org_hp * (CON_attr/100+1)
                outFile.Write("org_hp_regen=" & aTemp(15) & vbTab)
                outFile.Write("org_mp=" & CInt(CDbl(aTemp(14)) / (CDbl(aTemp(22)) / 100 + 1)) & vbTab)              'MP=org_mp*(MEN_attr/100+1)
                outFile.Write("org_mp_regen=" & aTemp(16) & vbTab)
                outFile.Write("collision_radius={" & CInt(aTemp(7)) & ";" & CInt(aTemp(7)) & "}" & vbTab)
                outFile.Write("collision_height={" & CInt(aTemp(8)) & ";" & CInt(aTemp(8)) & "}" & vbTab)
                outFile.Write("str=" & aTemp(17) & vbTab)
                outFile.Write("int=" & aTemp(20) & vbTab)
                outFile.Write("dex=" & aTemp(19) & vbTab)
                outFile.Write("wit=" & aTemp(21) & vbTab)
                outFile.Write("con=" & aTemp(18) & vbTab)
                outFile.Write("men=" & aTemp(22) & vbTab)

                ' 0     1      2                     3  4 5     6                              7    8    9      10     11         12  13  14   15   16   17 18 19 20   21 22  23   24  25  26 27  28  29  30     31  32 33 34 35 36 37  38 39  40         41
                '(20574,20574,'Elder Tarlk Basilisk',0,'',0,'LineageMonster.lesser_basilisk',34.00,25.00,51,   'male','L2Monster',40,2323,861,10.27,2.45,40,43,30,21,  20,10,3820,291,593,260,281,232,278,500,   333,0,  0,0,  0,35,174,0,  0,'LAST_HIT','true'),


                sTempForWrite = aItemPch(iSlotWeapon).weapon_type
                If sTempForWrite = "" Then sTempForWrite = "fist"
                outFile.Write("base_attack_type=" & sTempForWrite & vbTab)                   ' from itemdata
                outFile.Write("base_attack_range=" & aTemp(12) & vbTab)
                If iSlotWeapon > 0 Then
                    outFile.Write("base_damage_range=" & aItemPch(iSlotWeapon).damage_range & vbTab)          ' from itemdata 'base_damage_range={0;0;80;120}
                    outFile.Write("base_rand_dam=" & aItemPch(iSlotWeapon).random_damage & vbTab)                         ' from itemdatabase_rand_dam=7
                    outFile.Write("base_physical_attack=" & aTemp(25) & vbTab)
                    outFile.Write("base_critical=" & aItemPch(iSlotWeapon).critical & vbTab)                   ' from itemdata base_critical=12
                    outFile.Write("physical_hit_modify=" & aItemPch(iSlotWeapon).hit_modify & vbTab)          ' from itemdata physical_hit_modify=-3.75
                Else
                    outFile.Write("base_damage_range={0;0;80;120}" & vbTab)          ' from itemdata 'base_damage_range={0;0;80;120}
                    outFile.Write("base_rand_dam=7" & vbTab)                         ' from itemdatabase_rand_dam=7
                    'Patk=base_p_attack*(STR_attr/100+1)*lvl_bonus
                    outFile.Write("base_physical_attack=" & CDbl(Format(CDbl(aTemp(25)) / ((CDbl(aTemp(17)) / 100 + 1) * CDbl(aLevelBonus(CInt(aTemp(9))))), "0.####")) & vbTab)
                    outFile.Write("base_critical=12" & vbTab)                   ' from itemdata base_critical=12
                    outFile.Write("physical_hit_modify=-3.75" & vbTab)          ' from itemdata physical_hit_modify=-3.75
                End If
                outFile.Write("base_attack_speed=" & aTemp(29) & vbTab)
                outFile.Write("base_reuse_delay=" & aItemPch(iSlotWeapon).reuse_delay & vbTab)                 ' from itemdata base_reuse_delay=0

                'outFile.Write("base_magic_attack=" & aTemp(27) & vbTab)             'Matk=base_m_attack*(INT_attr/100+1)*lvl_bonus
                outFile.Write("base_magic_attack=" & CDbl(Format(CDbl(aTemp(27)) / ((CDbl(aTemp(20)) / 100 + 1) * CDbl(aLevelBonus(CInt(aTemp(9))))), "#.0000")) & vbTab)

                outFile.Write("base_defend=" & CDbl(Format(CDbl(aTemp(26)) / ((CInt(aTemp(9)) + 89) / 100), "0.####")) & vbTab)         'Pdef=base_defend*(level+89)/100
                '260
                'outFile.Write("base_defend=" & aTemp(26) & vbTab)      'Mdef=base_magic_defend*(MEN_attr/100+1)*(level+89)/100
                outFile.Write("base_magic_defend=" & CDbl(Format((CDbl(aTemp(28)) / ((CInt(aTemp(22)) / 100 + 1) * (CInt(aTemp(9)) + 89) / 100)), "0.####")) & vbTab)
                'outFile.Write("base_magic_defend=" & aTemp(28) & vbTab)
                outFile.Write("physical_avoid_modify=0" & vbTab)
                outFile.Write("soulshot_count=0" & vbTab)
                outFile.Write("spiritshot_count=0" & vbTab)
                outFile.Write("hit_time_factor=0.5" & vbTab)
                outFile.Write("item_make_list={}" & vbTab)
                outFile.Write("corpse_make_list={}" & vbTab)
                outFile.Write("additional_make_list={}" & vbTab)
                outFile.Write("additional_make_multi_list={}" & vbTab)
                outFile.Write("hp_increase=0" & vbTab)
                outFile.Write("mp_increase=0" & vbTab)
                outFile.Write("safe_height=100" & vbTab)
                outFile.Write("safe_height=100" & vbTab)

                If aTemp(41).Replace("'", "").ToLower = "false" Then
                    sTempForWrite = "0"
                Else
                    sTempForWrite = "1"
                End If
                outFile.Write("drop_herb=" & sTempForWrite & vbTab)

                outFile.WriteLine("npc_end" & vbTab)

            End If

        End While
        outFile.Close()
        inNpcFile.Close()
        ToolStripProgressBar.Value = 0


        MessageBox.Show("Completed.")

    End Sub

    'npc_begin	warrior	20761	[pytan]	level=69	acquire_exp_rate=8.3592	acquire_sp=3894	unsowing=0	clan={@MALRUK_CLAN}	ignore_clan_list={}	clan_help_range=500	slot_chest=[]	slot_rhand=[]	slot_lhand=[]	
    'shield_defense_rate=0	shield_defense=0	skill_list={}	
    'npc_ai={[pytan];{[MoveAroundSocial]=60};{[MoveAroundSocial1]=60};{[MoveAroundSocial2]=60};{[ShoutTarget]=1};{[SetHateGroup]=@attacker_group};{[SetHateGroupRatio]=20};{[DDMagic]=@s_blood_sucking6}}	
    'category={}	race=demonic	sex=female	undying=0	can_be_attacked=1	corpse_time=7	no_sleep_mode=0	agro_range=1000	ground_high={171.9;0;0}	ground_low={79.2;0;0}	
    'exp=387199547.925	org_hp=2395	org_hp_regen=35.55	org_mp=1458	org_mp_regen=2.78	collision_radius={14;14}	collision_height={40;40}	
    'str=40	int=21	dex=30	wit=20	con=43	men=10	base_attack_type=fist	base_attack_range=40	base_damage_range={0;0;80;120}	base_rand_dam=7	base_physical_attack=779.52	base_critical=12	
    'physical_hit_modify=-3.75	base_attack_speed=247.42	base_reuse_delay=0	base_magic_attack=507.28	base_defend=280.06	base_magic_defend=227.53	
    'physical_avoid_modify=0	soulshot_count=0	spiritshot_count=0	hit_time_factor=0.5	item_make_list={}	
    'corpse_make_list={{[rp_soulshot_a];1;1;2.2134};{[oriharukon_ore];1;1;100};{[stone_of_purity];1;1;100}}	additional_make_list={}	
    'additional_make_multi_list={}	hp_increase=0	mp_increase=0	safe_height=100	drop_herb=0	npc_end


    ' 0     1     2       3  4 5  6                             7    8     9  10           11         12  13   14  15    16   17 18 19 20    21 22 23   24  25   26  27  28  29  30    31  32 33 34 35 36 37  38 39 40          41
    '(20761,20761,'Pytan',0,'',0,'LineageMonster.bloody_queen',14.00,40.00,69,'female',    'L2Monster',40,3784,1458,35.55,2.78,40,43,30,21,  20,10,6633,649,1392,418,746,373,278,500,  333, 0, 0, 0, 0,88,191, 0,10,'LAST_HIT','false'),

    'id` decimal(11,0) NOT NULL default '0',

    'idTemplate` int(11) NOT NULL default '0',
    'name` varchar(200) default NULL,
    'serverSideName` int(1) default '0',
    'title` varchar(45) default '',
    'serverSideTitle` int(1) default '0',
    'class` varchar(200) default NULL,
    'collision_radius` decimal(5,2) default NULL,
    'collision_height` decimal(5,2) default NULL,
    'level` decimal(2,0) default NULL,
    'sex` varchar(6) default NULL,

    'type` varchar(22) default NULL,
    'attackrange` int(11) default NULL,
    'hp` decimal(8,0) default NULL,
    'mp` decimal(8,0) default NULL,
    'hpreg` decimal(8,2) default NULL,
    'mpreg` decimal(5,2) default NULL,
    'str` decimal(7,0) default NULL,
    'con` decimal(7,0) default NULL,
    'dex` decimal(7,0) default NULL,
    'int` decimal(7,0) default NULL,

    'wit` decimal(7,0) default NULL,
    'men` decimal(7,0) default NULL,
    'exp` decimal(9,0) default NULL,
    'sp` decimal(8,0) default NULL,
    'patk` decimal(5,0) default NULL,
    'pdef` decimal(5,0) default NULL,
    'matk` decimal(5,0) default NULL,
    'mdef` decimal(5,0) default NULL,
    'atkspd` decimal(3,0) default NULL,
    'aggro` decimal(6,0) default NULL,

    'matkspd` decimal(4,0) default NULL,
    'rhand` decimal(5,0) default NULL,
    'lhand` decimal(5,0) default NULL,
    'armor` decimal(1,0) default NULL,
    'enchant` int(11) NOT NULL default '0',
    'walkspd` decimal(3,0) default NULL,
    'runspd` decimal(3,0) default NULL,
    'isUndead` int(11) default 0,
    'absorb_level` decimal(2,0) default 0,
    'absorb_type` enum('FULL_PARTY','LAST_HIT','PARTY_ONE_RANDOM') DEFAULT 'LAST_HIT' NOT NULL,

    'drop_herbs` enum('true','false') DEFAULT 'false' NOT NULL,


    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQuit.Click
        Me.Dispose()
    End Sub

End Class