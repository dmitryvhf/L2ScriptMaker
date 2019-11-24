Public Class ItemDataGenerator

    Private Structure ItemBone
        Dim id As Integer
        Dim name As String
        Dim namepch As String
        Dim item_type As String         ' where found - same type armorgrp (armor), etcitemgrp (etcitem), recipe-e (etcitem), weapongrp (weapon)
        Dim slot_bit_type As String     ' weapongrp, armorgrp
        Dim armor_type As String        ' armorgrp.txt
        Dim etcitem_type As String      ' etcitemgrp.txt
        Dim recipe_id As Integer         ' recipe-e.txt
        Dim blessed As Integer
        Dim weight As Integer            ' everywhere
        Dim default_action As String
        Dim consume_type As String
        Dim initial_count As Integer
        Dim maximum_count As Integer
        Dim soulshot_count As Integer    ' weapongrp
        Dim spiritshot_count As Integer  ' weapongrp
        Dim reduced_soulshot As String
        Dim reduced_spiritshot As String
        Dim reduced_mp_consume As String
        Dim immediate_effect As Integer
        Dim price As Integer
        Dim default_price As Integer
        Dim item_skill As String
        Dim critical_attack_skill As String
        Dim attack_skill As String
        Dim magic_skill As String
        Dim item_skill_enchanted_four As String
        Dim material_type As String             ' everywhere
        Dim crystal_type As String             ' everywhere
        Dim crystal_count As Integer
        Dim is_trade As Integer
        Dim is_drop As Integer
        Dim is_destruct As Integer
        Dim physical_damage As Integer
        Dim random_damage As Integer
        Dim weapon_type As String
        Dim can_penetrate As Integer
        Dim critical As Integer
        Dim hit_modify As Double
        Dim avoid_modify As Integer
        Dim dual_fhit_rate As Integer
        Dim shield_defense As Integer
        Dim shield_defense_rate As Integer
        Dim attack_range As Integer
        Dim damage_range As String
        Dim attack_speed As Integer
        Dim reuse_delay As Integer
        Dim mp_consume As Integer
        Dim magical_damage As Integer
        Dim durability As Integer
        Dim damaged As Integer
        Dim physical_defense As Integer
        Dim magical_defense As Integer
        Dim mp_bonus As Integer
        Dim category As String
        Dim enchanted As Integer
        Dim html As String
        Dim equip_pet As String
        Dim magic_weapon As Integer
        Dim enchant_enable As Integer
        Dim can_equip_sex As Integer
        Dim can_equip_race As String
        Dim can_equip_change_class As Integer
        Dim can_equip_class As String
        Dim can_equip_agit As Integer
        Dim can_equip_castle As Integer
        Dim can_equip_castle_num As String
        Dim can_equip_clan_leader As Integer
        Dim can_equip_clan_level As Integer
        Dim can_equip_hero As Integer
        Dim can_equip_nobless As Integer
        Dim can_equip_chaotic As Integer

    End Structure

    Private Structure ItemSet
        'Dim ChestId As String       'id=2414	
        'Dim ItemList As String      'set_ids={2381,2417,5722,5738}
        Dim SetName As String       'name=[Doom Plate Armor]	add_name=[]	description=[Full body armor.]
        Dim SetDescription As String    'description=[Full body armor.]
        Dim SetBonusDesc As String    'set_bonus_desc=[Maximum HP +320, Breath Gauge increase, STR-3, and CON+3.]
        'Dim ItemAdd As String           'set_extra_id=[110]
        Dim SetExtraDesc As String       'set_extra_desc=[Shield Def +24%.]
        Dim SetSpecEnchDesc As String       'special_enchant_desc=[a,When all set items are enchanted by 6 or higher, P. Def. and MP regeneration rate will increase.\0]	
    End Structure

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click


        'On Error GoTo ErrorScreener

        ' Loading known DataBase
        Dim EtcitemType(27) As String
        EtcitemType(0) = "none"
        EtcitemType(1) = "scroll"
        EtcitemType(2) = "arrow"
        EtcitemType(3) = "potion"
        EtcitemType(4) = "spellbook"    ' C6
        EtcitemType(5) = "recipe"
        EtcitemType(6) = "material"
        EtcitemType(7) = "pet_collar"
        EtcitemType(8) = "castle_guard"
        EtcitemType(9) = "dye"
        EtcitemType(10) = "seed"
        EtcitemType(11) = "seed2"
        EtcitemType(12) = "harvest"
        EtcitemType(13) = "lotto"
        EtcitemType(14) = "race_ticket"
        EtcitemType(15) = "ticket_of_lord"
        EtcitemType(16) = "lure"
        EtcitemType(26) = "bolt"
        ' Unknown
        'EtcitemType(0) = "maturecrop"
        'EtcitemType(0) = "crop"
        'EtcitemType(0) = "bless_scrl_enchant_wp"
        'EtcitemType(0) = "scrl_enchant_am"
        'EtcitemType(0) = "bless_scrl_enchant_am"
        'EtcitemType(0) = "scrl_enchant_wp"

        'item_type
        Dim EtcitemDropAnimType(6) As String
        EtcitemDropAnimType(0) = "questitem"
        EtcitemDropAnimType(1) = "questitem"
        EtcitemDropAnimType(3) = "etcitem"
        EtcitemDropAnimType(5) = "asset"
        Dim ArmorGrpDropAnimType(4) As String
        ArmorGrpDropAnimType(0) = "accessary" '""   'armor for pets ?
        ArmorGrpDropAnimType(2) = "armor"       'armor_sigil
        ArmorGrpDropAnimType(3) = "armor"
        Dim WeaponGrpDropAnimType(4) As String
        WeaponGrpDropAnimType(0) = "weapon" 'weapon for pets
        WeaponGrpDropAnimType(1) = "weapon"
        WeaponGrpDropAnimType(2) = "armor"
        WeaponGrpDropAnimType(3) = "weapon"

        'timetab<>"[]" durablity<>-1
        'WeaponGrpDropAnimType(4) = "shadowitem"

        'armor_type=none	
        Dim ArmorGrpType(4) As String
        ArmorGrpType(0) = "none"
        ArmorGrpType(1) = "light"
        ArmorGrpType(2) = "heavy"
        ArmorGrpType(3) = "magic"
        ArmorGrpType(4) = "sigil"

        'body_part -> slot_bit_type
        'slot_bit_type={none}	
        Dim ArmorGrpSlotBitType(28) As String
        ArmorGrpSlotBitType(0) = "{underwear}"          'CT23
        ArmorGrpSlotBitType(1) = "{rear;lear}"          'CT23
        ArmorGrpSlotBitType(3) = "{neck}"               'CT23
        ArmorGrpSlotBitType(4) = "{rfinger;lfinger}"    'CT23
        ArmorGrpSlotBitType(6) = "{head}"               'CT23
        ArmorGrpSlotBitType(8) = "{onepiece}"           'CT23
        ArmorGrpSlotBitType(9) = "{alldress}"           'CT23
        ArmorGrpSlotBitType(10) = "{lrhair}"            'CT23
        'ArmorGrpSlotBitType(11) = "{legs}"
        'ArmorGrpSlotBitType(12) = "{feet}"
        'ArmorGrpSlotBitType(13) = "{back}"
        'ArmorGrpSlotBitType(15) = "{onepiece}"
        'ArmorGrpSlotBitType(16) = "{alldress}"
        'ArmorGrpSlotBitType(17) = "{hair}"
        'ArmorGrpSlotBitType(18) = "{lrhair}"    'cat_ear {hair2}
        ArmorGrpSlotBitType(19) = "{belt}"              'CT23
        'CT23
        ArmorGrpSlotBitType(20) = "{gloves}"            'CT23
        ArmorGrpSlotBitType(21) = "{chest}"             'CT23
        ArmorGrpSlotBitType(22) = "{legs}"              'CT23
        ArmorGrpSlotBitType(23) = "{feet}"              'CT23
        ArmorGrpSlotBitType(24) = "{back}"              'CT23
        ArmorGrpSlotBitType(25) = "{rhair}"             'CT23
        ArmorGrpSlotBitType(26) = "{lhair}"             'CT23
        ArmorGrpSlotBitType(28) = "{lhand}"             'CT23
        'ArmorGrpSlotBitType(610) = "{talisman}"         'CT23   (175609600, 178018768, 339848760)
        'ArmorGrpSlotBitType(611) = "{rbracelet}"         'CT23
        'ArmorGrpSlotBitType(612) = "{lbracelet}"         'CT23  (33194848, 33268176)

        Dim WeaponGrpSlotBitType(28) As String
        WeaponGrpSlotBitType(0) = "{rhand}" 'weapon for pets
        WeaponGrpSlotBitType(7) = "{lrhand}"             'CT23
        'WeaponGrpSlotBitType(8) = "{lhand}"
        'WeaponGrpSlotBitType(14) = "{lrhand}"
        WeaponGrpSlotBitType(27) = "{rhand}"             'CT23
        WeaponGrpSlotBitType(28) = "{lhand}"             'CT23

        Dim EtcitemCrystalType(8) As String
        EtcitemCrystalType(0) = "none"
        EtcitemCrystalType(1) = "d"
        EtcitemCrystalType(2) = "c"
        EtcitemCrystalType(3) = "b"
        EtcitemCrystalType(4) = "a"
        EtcitemCrystalType(5) = "s"
        EtcitemCrystalType(6) = "s80"
        EtcitemCrystalType(7) = "s84"
        EtcitemCrystalType(8) = "s84"   '="event" 13539	[staff_of_master_yogi]
        'crystal_free

        'material -> material_type
        Dim EtcitemMaterial(60) As String
        EtcitemMaterial(0) = "fish"
        EtcitemMaterial(1) = "oriharukon"
        EtcitemMaterial(2) = "mithril"
        EtcitemMaterial(3) = "gold"
        EtcitemMaterial(4) = "silver"
        EtcitemMaterial(5) = "brass"          'C6
        EtcitemMaterial(6) = "bronze"
        EtcitemMaterial(5) = "diamond"       'C6
        EtcitemMaterial(8) = "steel"
        EtcitemMaterial(9) = "damascus_steel"       'C6
        EtcitemMaterial(10) = "bone_of_dragon"       'C6
        EtcitemMaterial(11) = "air"       'C6
        EtcitemMaterial(12) = "water"       'C6
        EtcitemMaterial(13) = "wood"
        EtcitemMaterial(14) = "bone"
        EtcitemMaterial(15) = "branch_of_orbis_arbor"       'C6
        EtcitemMaterial(16) = "branch_of_worldtree"       'C6
        EtcitemMaterial(17) = "cloth"
        EtcitemMaterial(18) = "paper"
        EtcitemMaterial(19) = "leather"
        EtcitemMaterial(20) = "skull"       'C6
        EtcitemMaterial(21) = "feather"     'C6
        EtcitemMaterial(22) = "sand"        'C6
        EtcitemMaterial(23) = "crystal"
        EtcitemMaterial(24) = "fur"         'C6
        EtcitemMaterial(25) = "parchment"        'C6
        EtcitemMaterial(26) = "eyeball"        'C6
        EtcitemMaterial(27) = "insect"        'C6
        EtcitemMaterial(28) = "corpse"        'C6
        EtcitemMaterial(29) = "crow"        'C6
        EtcitemMaterial(30) = "hatching_egg"        'C6
        EtcitemMaterial(31) = "skull_of_wyvern"        'C6
        EtcitemMaterial(32) = "drug"
        EtcitemMaterial(33) = "cotton"
        EtcitemMaterial(34) = "silk"                'C6
        EtcitemMaterial(35) = "wool"                'C6
        EtcitemMaterial(36) = "flax"                  'C6
        EtcitemMaterial(37) = "cobweb"
        EtcitemMaterial(38) = "dyestuff"
        EtcitemMaterial(39) = "leather_of_puma"       'C6
        EtcitemMaterial(40) = "leather_of_lion"       'C6
        EtcitemMaterial(41) = "leather_of_manticore"  'C6
        EtcitemMaterial(42) = "leather_of_drake"    'C6
        EtcitemMaterial(43) = "leather_of_salamander"   'C6
        EtcitemMaterial(44) = "leather_of_unicorn"  'C6
        EtcitemMaterial(45) = "leather_of_dragon"   'C6
        EtcitemMaterial(46) = "scale_of_dragon"
        EtcitemMaterial(47) = "adamantaite"
        EtcitemMaterial(48) = "blood_steel"
        EtcitemMaterial(49) = "chrysolite"
        EtcitemMaterial(50) = "damascus"
        EtcitemMaterial(51) = "fine_steel"
        EtcitemMaterial(52) = "horn"
        EtcitemMaterial(53) = "liquid"

        Dim EtcitemStackable(6) As String
        EtcitemStackable(0) = "consume_type_normal"
        'EtcitemStackable(1) = "consume_type_charge"  ' C6 '1141 [q_rusted_bronze_sword2] Only one item
        EtcitemStackable(2) = "consume_type_stackable"
        EtcitemStackable(3) = "consume_type_asset"     ' adenas

        'weapon_type -> weapon_type
        Dim WeaponGrpWeaponType(15) As String
        WeaponGrpWeaponType(0) = "none"
        WeaponGrpWeaponType(1) = "sword"
        WeaponGrpWeaponType(2) = "blunt"
        WeaponGrpWeaponType(3) = "dagger"
        WeaponGrpWeaponType(4) = "pole"     'etc ??
        WeaponGrpWeaponType(5) = "fist"     'handness=3
        'WeaponGrpWeaponType(5) = "dualfist" 'handness=7
        WeaponGrpWeaponType(6) = "bow"
        WeaponGrpWeaponType(7) = "etc"
        WeaponGrpWeaponType(8) = "dual"  'handness=1
        'WeaponGrpWeaponType(8) = "dual" 'handness=3
        'WeaponGrpWeaponType(8) = "dualfist" 'handness=7
        WeaponGrpWeaponType(10) = "fishingrod"
        WeaponGrpWeaponType(11) = "rapier"
        WeaponGrpWeaponType(12) = "crossbow"
        WeaponGrpWeaponType(13) = "ancientsword"
        WeaponGrpWeaponType(15) = "dualdagger"

        ' ----------------------------------------------


        Dim ItemData(15000) As ItemBone
        Dim ItemSets(0) As ItemSet

        'itemname_begin	id=9141	name=[Redemption Bow]	add_name=[]	description=[Zaken's Curse event item.  Enables you to free cursed pigs.  Allows you to use the active skills Forgiveness and Pardon.  ]	popup=-1	set_ids={}	set_bonus_desc=[]	set_extra_id=[]	set_extra_desc=[]	unk[0]=0	unk[1]=0	special_enchant_amount=0	special_enchant_desc=[]	itemname_end
        Dim sItemNameFile As String = "itemname-e.txt"      ' Name/path of itemname-e.txt file
        Dim sEtcitemGrpFile As String = "etcitemgrp.txt"      ' Name/path of etcitemgrp.txt file
        Dim sRecipeFile As String = "recipe-c.txt"      ' Name/path of recipe-c.txt file
        Dim sArmorGrpFile As String = "armorgrp.txt"       ' Name/path of armorgrp.txt file
        Dim sWeaponGrpFile As String = "weapongrp.txt"      ' Name/path of weapongrp.txt file
        Dim sItemDataFile As String = "itemdata.txt"

        'ExistPchCheckBox

        ' skillgrp_begin	skill_id=1398	skill_level=101	oper_type=0	mp_consume=103	cast_range=900	cast_style=1	hit_time=4.000000	is_magic=1	ani_char=[f]	desc=[skill.su.1069]	icon_name=[icon.skill1398]	extra_eff=0	is_ench=1	ench_skill_id=10	hp_consume=0	UNK_0=9	UNK_1=11	skillgrp_end

        If System.IO.File.Exists(sItemNameFile) = False Then
            OpenFileDialog.FileName = ""
            OpenFileDialog.Filter = "Lineage II client text file (itemname-e.txt)|itemname-e.txt|All files|*.*"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            sItemNameFile = OpenFileDialog.FileName
        End If

        If System.IO.File.Exists(sEtcitemGrpFile) = False Then
            OpenFileDialog.FileName = ""
            OpenFileDialog.Filter = "Lineage II client text file (etcitemgrp.txt)|etcitemgrp.txt|All files|*.*"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            sEtcitemGrpFile = OpenFileDialog.FileName
        End If

        If System.IO.File.Exists(sRecipeFile) = False Then
            OpenFileDialog.FileName = ""
            OpenFileDialog.Filter = "Lineage II client text file (recipe-c.txt)|recipe-c.txt|All files|*.*"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            sRecipeFile = OpenFileDialog.FileName
        End If

        If System.IO.File.Exists(sArmorGrpFile) = False Then
            OpenFileDialog.FileName = ""
            OpenFileDialog.Filter = "Lineage II client text file (armorgrp.txt)|armorgrp.txt|All files|*.*"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            sArmorGrpFile = OpenFileDialog.FileName
        End If

        If System.IO.File.Exists(sWeaponGrpFile) = False Then
            OpenFileDialog.FileName = ""
            OpenFileDialog.Filter = "Lineage II client text file (weapongrp.txt)|weapongrp.txt|All files|*.*"
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            sWeaponGrpFile = OpenFileDialog.FileName
        End If

        SaveFileDialog.FileName = sItemDataFile
        SaveFileDialog.Filter = "Lineage II server enchant skill script (itemdata.txt)|itemdata*.txt|All files|*.*"
        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        sItemDataFile = SaveFileDialog.FileName


        Dim inFile As System.IO.StreamReader
        Dim sTemp As String = "", sTemp2 As String
        Dim iTemp As Integer
        'Dim iId As Integer

        ' ---- Loading 'Skillname-e.txt' ---- 
        inFile = New System.IO.StreamReader(sItemNameFile, True)
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading itemname-e.txt..."

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            If sTemp <> "" And sTemp.StartsWith("//") = False Then

                'itemname_begin	id=9141	name=[Redemption Bow]	add_name=[]	description=[Zaken's Curse event item.  Enables you to free cursed pigs.  Allows you to use the active skills Forgiveness and Pardon.  ]	popup=-1	set_ids={}	set_bonus_desc=[]	set_extra_id=[]	set_extra_desc=[]	unk[0]=0	unk[1]=0	special_enchant_amount=0	special_enchant_desc=[]	itemname_end
                iTemp = CInt(Libraries.GetNeedParamFromStr(sTemp, "id"))

                If iTemp >= ItemData.Length Then
                    Array.Resize(ItemData, iTemp + 1)
                End If
                ItemData(iTemp).name = Libraries.GetNeedParamFromStr(sTemp, "name").Replace("[", "").Replace("]", "")
                If Libraries.GetNeedParamFromStr(sTemp, "add_name") <> "[]" Then
                    ItemData(iTemp).name = ItemData(iTemp).name & "_" & Libraries.GetNeedParamFromStr(sTemp, "add_name").Replace("[", "").Replace("]", "")
                End If
                sTemp2 = ItemData(iTemp).name.ToLower.Replace("'", "").Replace(",", "")
                sTemp2 = sTemp2.Replace("%", "").Replace("/", "").Replace("(", "").Replace(")", "").Replace("/", "_")
                sTemp2 = sTemp2.Replace("+", "").Replace("-", "").Replace("<", "").Replace(">", "").Replace("/", "_")
                sTemp2 = sTemp2.Replace(":", "").Replace(".", "").Replace("  ", " ").Replace(" ", "_").Replace("#", "") ' .Replace("*", "")
                sTemp2 = sTemp2.Replace("{", "").Replace("}", "")
                ItemData(iTemp).namepch = "[" & sTemp2 & "]"

                ' SETTING DEFAULT PARAMS
                ItemData(iTemp).item_type = "etcitem"
                ItemData(iTemp).slot_bit_type = "{none}"
                ItemData(iTemp).armor_type = "none"
                ItemData(iTemp).etcitem_type = "etcitem"
                ItemData(iTemp).recipe_id = 0
                ItemData(iTemp).blessed = 0
                ItemData(iTemp).weight = 10000
                ItemData(iTemp).default_action = "action_none"          ' !!!! recipe -- action_recipe and etc
                ItemData(iTemp).consume_type = "consume_type_normal"
                ItemData(iTemp).initial_count = 1
                ItemData(iTemp).maximum_count = 1
                ItemData(iTemp).soulshot_count = 0
                ItemData(iTemp).spiritshot_count = 0
                ItemData(iTemp).reduced_soulshot = "{}"
                ItemData(iTemp).reduced_spiritshot = "{}"
                ItemData(iTemp).reduced_mp_consume = "{}"
                ItemData(iTemp).immediate_effect = 1
                ItemData(iTemp).price = 0
                ItemData(iTemp).default_price = 1
                ItemData(iTemp).item_skill = "[none]"
                ItemData(iTemp).critical_attack_skill = "[none]"
                ItemData(iTemp).attack_skill = "[none]"
                ItemData(iTemp).magic_skill = "[none]"
                ItemData(iTemp).item_skill_enchanted_four = "[none]"
                ItemData(iTemp).material_type = "paper"
                ItemData(iTemp).crystal_type = "none"
                ItemData(iTemp).crystal_count = 0
                ItemData(iTemp).is_trade = 1
                ItemData(iTemp).is_drop = 1
                ItemData(iTemp).is_destruct = 1
                ItemData(iTemp).physical_damage = 0
                ItemData(iTemp).random_damage = 0
                ItemData(iTemp).weapon_type = "none"
                ItemData(iTemp).can_penetrate = 0
                ItemData(iTemp).critical = 0
                ItemData(iTemp).hit_modify = 0
                ItemData(iTemp).avoid_modify = 0
                ItemData(iTemp).dual_fhit_rate = 0
                ItemData(iTemp).shield_defense = 0
                ItemData(iTemp).shield_defense_rate = 0
                ItemData(iTemp).attack_range = 0
                ItemData(iTemp).damage_range = "{}"
                ItemData(iTemp).attack_speed = 0
                ItemData(iTemp).reuse_delay = 0
                ItemData(iTemp).mp_consume = 0
                ItemData(iTemp).magical_damage = 0
                ItemData(iTemp).durability = -1
                ItemData(iTemp).damaged = 0
                ItemData(iTemp).physical_defense = 0
                ItemData(iTemp).magical_defense = 0
                ItemData(iTemp).mp_bonus = 0
                ItemData(iTemp).category = "{}"
                ItemData(iTemp).enchanted = 0
                ItemData(iTemp).html = "[item_default.htm]"
                ItemData(iTemp).equip_pet = "{0}"
                ItemData(iTemp).magic_weapon = 0
                ItemData(iTemp).enchant_enable = 0
                ItemData(iTemp).can_equip_sex = -1
                ItemData(iTemp).can_equip_race = "{}"
                ItemData(iTemp).can_equip_change_class = -1
                ItemData(iTemp).can_equip_class = "{}"
                ItemData(iTemp).can_equip_agit = -1
                ItemData(iTemp).can_equip_castle = -1
                ItemData(iTemp).can_equip_castle_num = "{}"
                ItemData(iTemp).can_equip_clan_leader = -1
                ItemData(iTemp).can_equip_clan_level = -1
                ItemData(iTemp).can_equip_hero = -1
                ItemData(iTemp).can_equip_nobless = -1
                ItemData(iTemp).can_equip_chaotic = -1

                '' MADE SETS
                'Dim sSetInfo As String = Nothing
                iTemp = CInt(Libraries.GetNeedParamFromStr(sTemp, "cnt0"))
                If iTemp > 0 Then

                    iTemp = ItemSets.Length - 1
                    ItemSets(iTemp).SetName = Libraries.GetNeedParamFromStr(sTemp, "name")
                    ItemSets(iTemp).SetDescription = Libraries.GetNeedParamFromStr(sTemp, "description")
                    ItemSets(iTemp).SetBonusDesc = Libraries.GetNeedParamFromStr(sTemp, "set_bonus_desc")
                    If CInt(Libraries.GetNeedParamFromStr(sTemp, "cnt1")) > 0 Then ItemSets(iTemp).SetExtraDesc = Libraries.GetNeedParamFromStr(sTemp, "set_extra_desc")
                    If CInt(Libraries.GetNeedParamFromStr(sTemp, "special_enchant_amount")) > 0 Then ItemSets(iTemp).SetSpecEnchDesc = Libraries.GetNeedParamFromStr(sTemp, "special_enchant_desc")

                '    ' set_ids={1101,1104,44}	set_bonus_desc=[Casting Spd. +15%.]	set_extra_id=[]	set_extra_desc=[]
                '    ' set_ids={2381,2417,5722,5738}	set_bonus_desc=[Maximum HP +320, Breath Gauge increase, STR-3, and CON+3.]	set_extra_id=[110]	set_extra_desc=[Shield Def +24%.]

                '    'id=2381	name=[Doom Plate Armor]	add_name=[]	description=[Full body armor.]	popup=-1	
                '    'set_ids={2381,2417,5722,5738}	set_bonus_desc=[Maximum HP +320, Breath Gauge increase, STR-3, and CON+3.]
                '    'set_extra_id=[110]	set_extra_desc=[Shield Def +24%.]	unk[0]=0	unk[1]=0	
                '    'special_enchant_amount=6	special_enchant_desc=[When all set items are enchanted by 6 or higher, P. Def. and MP regeneration rate will increase.]	itemname_end
                '    ItemSets(iTemp).ItemList = Libraries.GetNeedParamFromStr(sTemp, "set_ids").Replace("[", "").Replace("]", "")
                '    ItemSets(iTemp).ChestId = Libraries.GetNeedParamFromStr(sTemp, "id")
                '    ItemSets(iTemp).SetName = Libraries.GetNeedParamFromStr(sTemp, "name").Replace("[", "").Replace("]", "") & ". " & Libraries.GetNeedParamFromStr(sTemp, "description").Replace("[", "").Replace("]", "")
                '    ItemSets(iTemp).SetDescription = Libraries.GetNeedParamFromStr(sTemp, "set_bonus_desc").Replace("[", "").Replace("]", "")
                '    If ItemSets(iTemp).SetDescription <> "" Then
                '        ItemSets(iTemp).SetName = ItemSets(iTemp).SetName & " " & ItemSets(iTemp).SetDescription
                '    End If
                '    ItemSets(iTemp).ItemAdd = Libraries.GetNeedParamFromStr(sTemp, "set_extra_id").Replace("[", "").Replace("]", "")
                '    ItemSets(iTemp).ItemAddDesc = Libraries.GetNeedParamFromStr(sTemp, "set_extra_desc").Replace("[", "").Replace("]", "")
                '    'If ItemSets(iTemp).ItemAdd = "[]" Then ItemSets(iTemp).ItemAdd = "[none]"
                    Array.Resize(ItemSets, ItemSets.Length + 1)
                End If


            End If
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            StatusStrip.Update()
        End While
        ToolStripProgressBar.Value = 0
        inFile.Close()
        Me.Refresh()


        ' ---- Loading 'etcitemgrp.txt' ---- 
        inFile = New System.IO.StreamReader(sEtcitemGrpFile, True)
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading etcitemgrp.txt..."

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            If sTemp <> "" And sTemp.StartsWith("//") = False Then

                'etcitemgrp_begin	tag=2	id=17	drop_type=0	drop_anim_type=3	drop_radius=8	drop_height=4	UNK_0=0	drop_mesh=[dropitems.drop_quiver_m00]	drop_tex=[]	icon[0]=[]	icon[1]=[dropitemstex.drop_quiver_t00]	icon[2]=[]	icon[3]=[]	icon[4]=[icon.etc_wooden_quiver_i00]	icon[5]=[]	icon[6]=[]	icon[7]=[]	icon[8]=[]	durability=4294967295	weight=6	material=13	crystallizable=0	type1=0	mesh_tex_pair_cntm=1	mesh_tex_pair_m[0]=[LineageWeapons.wooden_arrow_m00_et]	mesh_tex_pair_cntt=1	mesh_tex_pair_t[0]=[LineageWeaponsTex.wooden_arrow_t00_et]	item_sound=[ItemSound.itemdrop_arrow]	equip_sound=[]	stackable=2	family=2	grade=0	etcitemgrp_end
                iTemp = CInt(Libraries.GetNeedParamFromStr(sTemp, "id"))

                If ItemData(iTemp).name = "" Then
                    MessageBox.Show("Found unknown ID. You must do update for your itemdata-e, because etcitemgrp item_id not defined in itemname-e", "Unknown ID", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    inFile.Close()
                    Exit Sub
                End If

                'ItemData(iTemp).namepch = ItemData(iTemp).namepch.Replace("[", "[rp_")
                ItemData(iTemp).item_type = EtcitemDropAnimType(CInt(Libraries.GetNeedParamFromStr(sTemp, "drop_anim_type")))
                If CInt(Libraries.GetNeedParamFromStr(sTemp, "drop_anim_type")) < 2 Then
                    ItemData(iTemp).namepch = ItemData(iTemp).namepch.Replace("[", "[q_")
                End If

                ItemData(iTemp).slot_bit_type = "{none}"
                ItemData(iTemp).armor_type = "none"
                Try
                    ItemData(iTemp).etcitem_type = EtcitemType(CInt(Libraries.GetNeedParamFromStr(sTemp, "family")))
                Catch ex As Exception
                    If Val(Libraries.GetNeedParamFromStr(sTemp, "family")) > 25 Then
                        ItemData(iTemp).etcitem_type = "none"
                    Else
                        MessageBox.Show("Wrong EctipemTime for..." & vbNewLine & sTemp, "Wrong EctipemTime", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Try
                If ItemData(iTemp).etcitem_type = "arrow" Then
                    ItemData(iTemp).slot_bit_type = "{lhand}"
                End If

                ' Checking for Exceptions! 
                'scrl_enchant_wp, scrl_enchant_am, bless_scrl_enchant_wp, bless_scrl_enchant_am, crop, maturecrop

                If EnchCropCheckBox.Checked = True Then
                    '729, 947, 951, 955, 959    scrl_enchant_wp
                    '730, 948, 952, 956, 960    scrl_enchant_am
                    '6569, 6571, 6573, 6575, 6577   bless_scrl_enchant_wp
                    '6570, 6572, 6574, 6576, 6578   bless_scrl_enchant_am

                    'etcitem_type = scrl_inc_enchant_prop_wp
                    'etcitem_type = scrl_inc_enchant_prop_am

                    If iTemp = 729 Or iTemp = 947 Or iTemp = 951 Or iTemp = 955 Or iTemp = 959 Then
                        ItemData(iTemp).etcitem_type = "scrl_enchant_wp"
                    End If
                    If iTemp = 730 Or iTemp = 948 Or iTemp = 952 Or iTemp = 956 Or iTemp = 960 Then
                        ItemData(iTemp).etcitem_type = "scrl_enchant_am"
                    End If
                    If iTemp = 6569 Or iTemp = 6571 Or iTemp = 6573 Or iTemp = 6575 Or iTemp = 6577 Then
                        ItemData(iTemp).etcitem_type = "bless_scrl_enchant_wp"
                    End If
                    If iTemp = 6570 Or iTemp = 6572 Or iTemp = 6574 Or iTemp = 6576 Or iTemp = 6578 Then
                        ItemData(iTemp).etcitem_type = "bless_scrl_enchant_am"
                    End If

                    'crop
                    'maturecrop

                    If iTemp = 6555 Then
                        Dim ajshd As Integer = 12
                    End If
                    If InStr(ItemData(iTemp).namepch, "seed") = 0 And ItemData(iTemp).etcitem_type <> "seed" Then
                        If ItemData(iTemp).namepch.EndsWith("_coba]") = True Or ItemData(iTemp).namepch.EndsWith("_cobol]") = True Or _
                                ItemData(iTemp).namepch.EndsWith("_codran]") = True Or ItemData(iTemp).namepch.EndsWith("_coda]") = True Then

                            ItemData(iTemp).namepch = ItemData(iTemp).namepch.Replace("[q_", "[")
                            ItemData(iTemp).item_type = "etcitem"
                            If ItemData(iTemp).namepch.StartsWith("[mature_") = True Or ItemData(iTemp).namepch.StartsWith("[ripe_") = True Then
                                ItemData(iTemp).etcitem_type = "maturecrop"
                            Else
                                ItemData(iTemp).etcitem_type = "crop"
                            End If
                        End If
                    Else
                        ItemData(iTemp).namepch = ItemData(iTemp).namepch.Replace("[q_", "[")
                    End If

                End If

                ItemData(iTemp).recipe_id = 0
                ItemData(iTemp).blessed = 0
                ItemData(iTemp).weight = CInt(Libraries.GetNeedParamFromStr(sTemp, "weight"))

                'action_none
                'action_equip
                'action_recipe
                'action_skill_reduce
                'action_capsule
                'action_seed
                'action_show_html
                'action_spiritshot
                'action_skill_maintain
                'action_soulshot
                'action_fishingshot
                'action_dice
                'action_summon_spiritshot
                'action_show_ssq_status
                'action_summon_soulshot
                'action_calc
                'action_harvest
                'action_xmas_open

                'EtcitemType(0) = "none"
                'EtcitemType(1) = "scroll"
                'EtcitemType(2) = "arrow"
                'EtcitemType(3) = "potion"
                'EtcitemType(5) = "recipe"
                'EtcitemType(6) = "material"
                'EtcitemType(7) = "pet_collar"
                'EtcitemType(8) = "castle_guard"
                'EtcitemType(9) = "dye"
                'EtcitemType(10) = "seed"
                'EtcitemType(11) = "seed2"
                'EtcitemType(12) = "harvest"
                'EtcitemType(13) = "lotto"
                'EtcitemType(14) = "race_ticket"
                'EtcitemType(15) = "ticket_of_lord"
                'EtcitemType(16) = "lure"

                Select Case ItemData(iTemp).etcitem_type
                    Case "scroll"
                        ItemData(iTemp).default_action = "action_skill_reduce"
                    Case "arrow"
                        ItemData(iTemp).default_action = "action_equip"
                    Case "potion"
                        ItemData(iTemp).default_action = "action_skill_reduce"
                        ItemData(iTemp).equip_pet = "{@ALL_PET}"
                    Case "pet_collar"
                        ItemData(iTemp).default_action = "action_skill_maintain"
                    Case "seed"
                        ItemData(iTemp).default_action = "action_seed"
                        ItemData(iTemp).item_type = "etcitem"
                    Case "seed2"
                        ItemData(iTemp).default_action = "action_seed"
                        ItemData(iTemp).item_type = "etcitem"
                    Case "harvest"
                        ItemData(iTemp).default_action = "action_harvest"
                    Case "lure"
                        ItemData(iTemp).namepch = ItemData(iTemp).namepch.Replace("[q_", "[")
                        ItemData(iTemp).item_type = "etcitem"
                        ItemData(iTemp).slot_bit_type = "{lhand}"
                        ItemData(iTemp).default_action = "action_equip"
                    Case "castle_guard"
                        ItemData(iTemp).namepch = ItemData(iTemp).namepch.Replace("[q_", "[")
                        ItemData(iTemp).item_type = "etcitem"
                    Case "scrl_enchant_wp"
                        ItemData(iTemp).default_action = "action_skill_reduce"
                    Case "scrl_enchant_wp"
                        ItemData(iTemp).default_action = "action_skill_reduce"
                    Case "recipe"
                        ItemData(iTemp).default_action = "action_recipe"
                    Case Else
                        '@ALL_PET
                        ItemData(iTemp).default_action = "action_none"          ' !!!! recipe -- action_recipe and etc

                        Select Case iTemp
                            Case 5555
                                ItemData(iTemp).default_action = "action_xmas_open" '5555 [x_mas_2004]
                                ItemData(iTemp).item_type = "etcitem"
                            Case 5707
                                ItemData(iTemp).default_action = "action_show_ssq_status" '5707 [record_of_seven_sign]
                                ItemData(iTemp).item_type = "etcitem"
                            Case 5708   '5708    [q_lord_of_the_manors_certificate_of_approval] 
                                'etcitem_type=ticket_of_lord
                                ItemData(iTemp).item_type = "etcitem"
                            Case 2515   '[food_for_wolves]
                                ItemData(iTemp).default_action = "action_skill_reduce"
                                ItemData(iTemp).equip_pet = "{@pet_wolf_a;@sin_eater}"
                        End Select

                End Select
                If ItemData(iTemp).namepch.EndsWith("_spice]") = True Then
                    '[pet_food_baby_spice], [golden_spice], [crystal_spice]
                    ItemData(iTemp).default_action = "action_skill_reduce"
                    ItemData(iTemp).equip_pet = "{0}"
                End If

                If InStr(ItemData(iTemp).namepch, "soulshot") <> 0 Then
                    ItemData(iTemp).default_action = "action_soulshot"
                End If
                If InStr(ItemData(iTemp).namepch, "spiritshot") <> 0 Then
                    ItemData(iTemp).default_action = "action_spiritshot"
                End If
                If InStr(ItemData(iTemp).namepch, "beast_soul") <> 0 Then
                    ItemData(iTemp).default_action = "action_summon_soulshot"
                    ItemData(iTemp).equip_pet = "{@ALL_PET}"
                End If
                If InStr(ItemData(iTemp).namepch, "beast_spirit") <> 0 Then
                    ItemData(iTemp).default_action = "action_summon_spiritshot"
                    ItemData(iTemp).equip_pet = "{@ALL_PET}"
                End If
                If InStr(ItemData(iTemp).namepch, "fishing_shot") <> 0 Then
                    ItemData(iTemp).default_action = "action_fishingshot"
                End If
                If ItemData(iTemp).namepch.StartsWith("[dice") = True Then
                    ItemData(iTemp).default_action = "action_dice"
                End If
                If ItemData(iTemp).namepch.StartsWith("[calculator") = True Then
                    ItemData(iTemp).default_action = "action_calc"
                End If

                ItemData(iTemp).consume_type = EtcitemStackable(CInt(Libraries.GetNeedParamFromStr(sTemp, "stackable")))
                If ItemData(iTemp).consume_type = "consume_type_stackable" Then
                    'ItemData(iTemp).initial_count = 1
                    ItemData(iTemp).maximum_count = 20
                    'Else
                    'ItemData(iTemp).initial_count = 1
                    'ItemData(iTemp).maximum_count = 1
                End If

                'ItemData(iTemp).soulshot_count = 0
                'ItemData(iTemp).spiritshot_count = 0
                'ItemData(iTemp).reduced_soulshot = "{}"
                'ItemData(iTemp).reduced_spiritshot = "{}"
                'ItemData(iTemp).reduced_mp_consume = "{}"
                'ItemData(iTemp).immediate_effect = 1
                'ItemData(iTemp).price = 0
                'ItemData(iTemp).default_price = 1
                'ItemData(iTemp).item_skill = "[none]"
                'ItemData(iTemp).critical_attack_skill = "[none]"
                'ItemData(iTemp).attack_skill = "[none]"
                'ItemData(iTemp).magic_skill = "[none]"
                'ItemData(iTemp).item_skill_enchanted_four = "[none]"
                Try
                    ItemData(iTemp).material_type = EtcitemMaterial(CInt(Libraries.GetNeedParamFromStr(sTemp, "material")))
                Catch ex As Exception
                    ItemData(iTemp).material_type = "paper" ' EtcitemMaterial(18)
                End Try
                If ItemData(iTemp).material_type = "fish" Then
                    ItemData(iTemp).default_action = "action_capsule"
                End If

                ItemData(iTemp).crystal_type = EtcitemCrystalType(CInt(Libraries.GetNeedParamFromStr(sTemp, "grade")))
                'ItemData(iTemp).crystal_count = 0
                If ItemData(iTemp).item_type = "questitem" Then
                    ItemData(iTemp).is_trade = 0
                    ItemData(iTemp).is_drop = 0
                    ' ItemData(iTemp).is_destruct = 0  ??
                End If
                'ItemData(iTemp).physical_damage = 0
                'ItemData(iTemp).random_damage = 0
                'ItemData(iTemp).weapon_type = "none"
                'ItemData(iTemp).can_penetrate = 0
                'ItemData(iTemp).critical = 0
                'ItemData(iTemp).hit_modify = 0
                'ItemData(iTemp).avoid_modify = 0
                'ItemData(iTemp).dual_fhit_rate = 0
                'ItemData(iTemp).shield_defense = 0
                'ItemData(iTemp).shield_defense_rate = 0
                'ItemData(iTemp).attack_range = 0
                'ItemData(iTemp).damage_range = "{}"
                'ItemData(iTemp).attack_speed = 0
                'ItemData(iTemp).reuse_delay = 0
                'ItemData(iTemp).mp_consume = 0
                'ItemData(iTemp).magical_damage = 0
                'ItemData(iTemp).durability = 0
                'ItemData(iTemp).damaged = 0
                'ItemData(iTemp).physical_defense = 0
                'ItemData(iTemp).magical_defense = 0
                'ItemData(iTemp).mp_bonus = 0
                'ItemData(iTemp).category = "{}"
                'ItemData(iTemp).enchanted = 0

                ItemData(iTemp).html = "[item_default.htm]"
                If ItemData(iTemp).html <> "[item_default.htm]" Then
                    ItemData(iTemp).default_action = "action_show_html"
                End If
                'ItemData(iTemp).equip_pet = "{0}"
                'ItemData(iTemp).magic_weapon = 0
                'ItemData(iTemp).enchant_enable = 0
                'ItemData(iTemp).can_equip_sex = -1
                'ItemData(iTemp).can_equip_race = "{}"
                'ItemData(iTemp).can_equip_change_class = -1
                'ItemData(iTemp).can_equip_class = "{}"
                'ItemData(iTemp).can_equip_agit = -1
                'ItemData(iTemp).can_equip_castle = -1
                'ItemData(iTemp).can_equip_castle_num = "{}"
                'ItemData(iTemp).can_equip_clan_leader = -1
                'ItemData(iTemp).can_equip_clan_level = -1
                'ItemData(iTemp).can_equip_hero = -1
                'ItemData(iTemp).can_equip_nobless = -1
                'ItemData(iTemp).can_equip_chaotic = -1

            End If
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            StatusStrip.Update()
        End While
        ToolStripProgressBar.Value = 0
        inFile.Close()

        ' ---- Loading 'Recipe-c.txt' ---- 
        inFile = New System.IO.StreamReader(sRecipeFile, True)
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading recipe-c.txt..."

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            If sTemp <> "" And sTemp.StartsWith("//") = False Then

                'recipe_begin	name=[mk_wooden_arrow]	id_mk=1	id_recipe=1666	level=1	id_item=17	count=500	mp_cost=30	success_rate=100	materials_cnt=2	materials_m[0]_id=1864	materials_m[0]_cnt=4	materials_m[1]_id=1869	materials_m[1]_cnt=2	materials_m[2]_id=	materials_m[2]_cnt=	materials_m[3]_id=	materials_m[3]_cnt=	materials_m[4]_id=	materials_m[4]_cnt=	materials_m[5]_id=	materials_m[5]_cnt=	materials_m[6]_id=	materials_m[6]_cnt=	materials_m[7]_id=	materials_m[7]_cnt=	materials_m[8]_id=	materials_m[8]_cnt=	materials_m[9]_id=	materials_m[9]_cnt=	recipe_end
                iTemp = CInt(Libraries.GetNeedParamFromStr(sTemp, "id_recipe"))
                ItemData(iTemp).namepch = ItemData(iTemp).namepch.Replace("[", "[rp_")
                ItemData(iTemp).item_type = "etcitem"
                'ItemData(iTemp).slot_bit_type = "{none}"
                'ItemData(iTemp).armor_type = "none"
                ItemData(iTemp).etcitem_type = "recipe"
                ItemData(iTemp).recipe_id = CInt(Libraries.GetNeedParamFromStr(sTemp, "id_mk"))
                'ItemData(iTemp).blessed = 0
                'ItemData(iTemp).weight = 30
                ItemData(iTemp).default_action = "action_recipe"
                'ItemData(iTemp).consume_type = "consume_type_stackable"
                'ItemData(iTemp).initial_count = 1
                'ItemData(iTemp).maximum_count = 1
                'ItemData(iTemp).soulshot_count = 0
                'ItemData(iTemp).spiritshot_count = 0
                'ItemData(iTemp).reduced_soulshot = "{}"
                'ItemData(iTemp).reduced_spiritshot = "{}"
                'ItemData(iTemp).reduced_mp_consume = "{}"
                'ItemData(iTemp).immediate_effect = 1
                'ItemData(iTemp).price = 0
                'ItemData(iTemp).default_price = 1
                'ItemData(iTemp).item_skill = "[none]"
                'ItemData(iTemp).critical_attack_skill = "[none]"
                'ItemData(iTemp).attack_skill = "[none]"
                'ItemData(iTemp).magic_skill = "[none]"
                'ItemData(iTemp).item_skill_enchanted_four = "[none]"
                'ItemData(iTemp).material_type = "liquid"
                'ItemData(iTemp).crystal_type = "none"
                'ItemData(iTemp).crystal_count = 0
                'ItemData(iTemp).is_trade = 1
                'ItemData(iTemp).is_drop = 1
                'ItemData(iTemp).is_destruct = 1
                'ItemData(iTemp).physical_damage = 0
                'ItemData(iTemp).random_damage = 0
                'ItemData(iTemp).weapon_type = "none"
                'ItemData(iTemp).can_penetrate = 0
                'ItemData(iTemp).critical = 0
                'ItemData(iTemp).hit_modify = 0
                'ItemData(iTemp).avoid_modify = 0
                'ItemData(iTemp).dual_fhit_rate = 0
                'ItemData(iTemp).shield_defense = 0
                'ItemData(iTemp).shield_defense_rate = 0
                'ItemData(iTemp).attack_range = 0
                'ItemData(iTemp).damage_range = "{}"
                'ItemData(iTemp).attack_speed = 0
                'ItemData(iTemp).reuse_delay = 0
                'ItemData(iTemp).mp_consume = 0
                'ItemData(iTemp).magical_damage = 0
                'ItemData(iTemp).durability = 0
                'ItemData(iTemp).damaged = 0
                'ItemData(iTemp).physical_defense = 0
                'ItemData(iTemp).magical_defense = 0
                'ItemData(iTemp).mp_bonus = 0
                'ItemData(iTemp).category = "{}"
                'ItemData(iTemp).enchanted = 0
                'ItemData(iTemp).html = "[item_default.htm]"
                'ItemData(iTemp).equip_pet = "{0}"
                'ItemData(iTemp).magic_weapon = 0
                'ItemData(iTemp).enchant_enable = 0
                'ItemData(iTemp).can_equip_sex = -1
                'ItemData(iTemp).can_equip_race = "{}"
                'ItemData(iTemp).can_equip_change_class = -1
                'ItemData(iTemp).can_equip_class = "{}"
                'ItemData(iTemp).can_equip_agit = -1
                'ItemData(iTemp).can_equip_castle = -1
                'ItemData(iTemp).can_equip_castle_num = "{}"
                'ItemData(iTemp).can_equip_clan_leader = -1
                'ItemData(iTemp).can_equip_clan_level = -1
                'ItemData(iTemp).can_equip_hero = -1
                'ItemData(iTemp).can_equip_nobless = -1
                'ItemData(iTemp).can_equip_chaotic = -1
            End If
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            StatusStrip.Update()
        End While
        ToolStripProgressBar.Value = 0
        inFile.Close()
        Me.Refresh()


        ' ---- Loading 'armorgrp.txt' ---- 
        inFile = New System.IO.StreamReader(sArmorGrpFile, True)
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading armorgrp.txt..."

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            If sTemp <> "" And sTemp.StartsWith("//") = False Then

                'armorgrp_begin	tag=1	id=21	drop_type=0	drop_anim_type=3	drop_radius=7	drop_height=0	UNK_0=0	durability=4294967295	weight=4830	material=17	crystallizable=0	UNK_1=0	body_part=10	UNK_2=1	UNK_3=0	armor_type=1	crystal_type=0	avoid_mod=0	pdef=36	mdef=0	mpbonus=0	armorgrp_end
                iTemp = CInt(Libraries.GetNeedParamFromStr(sTemp, "id"))

                If ItemData(iTemp).name = "" Then
                    MessageBox.Show("Found unknown ID. You must do update for your itemdata-e, because etcitemgrp item_id not defined in itemname-e", "Unknown ID", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    inFile.Close()
                    Exit Sub
                End If

                ItemData(iTemp).item_type = ArmorGrpDropAnimType(CInt(Libraries.GetNeedParamFromStr(sTemp, "drop_anim_type")))

                ' gracelet, talisman big value fix
                If CInt(Libraries.GetNeedParamFromStr(sTemp, "body_part")) <= 28 Then
                    ItemData(iTemp).slot_bit_type = ArmorGrpSlotBitType(CInt(Libraries.GetNeedParamFromStr(sTemp, "body_part")))
                Else
                    ItemData(iTemp).slot_bit_type = "{none}"
                End If

                If CInt(Libraries.GetNeedParamFromStr(sTemp, "body_part")) > 5 Then
                    ItemData(iTemp).item_type = "armor"
                End If
                ItemData(iTemp).armor_type = ArmorGrpType(CInt(Libraries.GetNeedParamFromStr(sTemp, "armor_type")))
                ItemData(iTemp).etcitem_type = "none"
                'ItemData(iTemp).recipe_id = CInt(Libraries.GetNeedParamFromStr(sTemp, "id_mk"))
                'ItemData(iTemp).blessed = 0
                ItemData(iTemp).weight = CInt(Libraries.GetNeedParamFromStr(sTemp, "weight"))
                ItemData(iTemp).default_action = "action_equip"
                ItemData(iTemp).consume_type = "consume_type_normal"
                'ItemData(iTemp).initial_count = 1
                'ItemData(iTemp).maximum_count = 1
                'ItemData(iTemp).soulshot_count = 0
                'ItemData(iTemp).spiritshot_count = 0
                'ItemData(iTemp).reduced_soulshot = "{}"
                'ItemData(iTemp).reduced_spiritshot = "{}"
                'ItemData(iTemp).reduced_mp_consume = "{}"
                'ItemData(iTemp).immediate_effect = 1
                'ItemData(iTemp).price = 0
                'ItemData(iTemp).default_price = 1
                'ItemData(iTemp).item_skill = "[none]"
                'ItemData(iTemp).critical_attack_skill = "[none]"
                'ItemData(iTemp).attack_skill = "[none]"
                'ItemData(iTemp).magic_skill = "[none]"
                'ItemData(iTemp).item_skill_enchanted_four = "[none]"
                ItemData(iTemp).material_type = EtcitemMaterial(CInt(Libraries.GetNeedParamFromStr(sTemp, "material")))
                ItemData(iTemp).crystal_type = EtcitemCrystalType(CInt(Libraries.GetNeedParamFromStr(sTemp, "crystal_type")))
                If ItemData(iTemp).crystal_type <> "none" Then
                    ItemData(iTemp).crystal_count = 1
                End If
                'ItemData(iTemp).is_trade = 1
                'ItemData(iTemp).is_drop = 1
                'ItemData(iTemp).is_destruct = 1
                'ItemData(iTemp).physical_damage = 0
                'ItemData(iTemp).random_damage = 0
                'ItemData(iTemp).weapon_type = "none"
                'ItemData(iTemp).can_penetrate = 0
                'ItemData(iTemp).critical = 0
                'ItemData(iTemp).hit_modify = 0

                'ItemData(iTemp).avoid_modify = CInt(Libraries.GetNeedParamFromStr(sTemp, "avoid_mod"))
                If Libraries.GetNeedParamFromStr(sTemp, "avoid_mod") = "0" Then
                    ItemData(iTemp).avoid_modify = 0
                Else
                    ItemData(iTemp).avoid_modify = -8
                End If
                'ItemData(iTemp).dual_fhit_rate = 0
                'ItemData(iTemp).shield_defense = 0
                'ItemData(iTemp).shield_defense_rate = 0
                'ItemData(iTemp).attack_range = 0
                'ItemData(iTemp).damage_range = "{}"
                'ItemData(iTemp).attack_speed = 0
                'ItemData(iTemp).reuse_delay = 0
                'ItemData(iTemp).mp_consume = 0
                'ItemData(iTemp).magical_damage = 0
                ItemData(iTemp).durability = CInt(Libraries.GetNeedParamFromStr(sTemp, "durability"))
                If ItemData(iTemp).durability <> -1 Then
                    ItemData(iTemp).crystal_count = 0
                    ItemData(iTemp).is_trade = 0
                    ItemData(iTemp).is_drop = 0
                End If
                'ItemData(iTemp).damaged = 0
                ItemData(iTemp).physical_defense = CInt(Libraries.GetNeedParamFromStr(sTemp, "pdef"))
                ItemData(iTemp).magical_defense = CInt(Libraries.GetNeedParamFromStr(sTemp, "mdef"))
                ItemData(iTemp).mp_bonus = CInt(Libraries.GetNeedParamFromStr(sTemp, "mpbonus"))
                'ItemData(iTemp).category = "{}"
                'ItemData(iTemp).enchanted = 0
                'ItemData(iTemp).html = "[item_default.htm]"

                If CInt(Libraries.GetNeedParamFromStr(sTemp, "drop_anim_type")) = 0 Then
                    ' Armor for Pets
                    ItemData(iTemp).equip_pet = "{@pet_wolf_a;@wind_strider;@star_strider;@twilight_strider;@hatchling_of_wind;@hatchling_of_star;@hatchling_of_twilight}"
                End If

                'ItemData(iTemp).magic_weapon = 0
                If ItemData(iTemp).crystal_type <> "none" Then
                    ItemData(iTemp).enchant_enable = 1
                End If
                'ItemData(iTemp).enchant_enable = 0
                'ItemData(iTemp).can_equip_sex = -1
                'ItemData(iTemp).can_equip_race = "{}"
                'ItemData(iTemp).can_equip_change_class = -1
                'ItemData(iTemp).can_equip_class = "{}"
                'ItemData(iTemp).can_equip_agit = -1
                'ItemData(iTemp).can_equip_castle = -1
                'ItemData(iTemp).can_equip_castle_num = "{}"
                'ItemData(iTemp).can_equip_clan_leader = -1
                'ItemData(iTemp).can_equip_clan_level = -1
                'ItemData(iTemp).can_equip_hero = -1
                'ItemData(iTemp).can_equip_nobless = -1
                'ItemData(iTemp).can_equip_chaotic = -1
            End If
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            StatusStrip.Update()
        End While
        ToolStripProgressBar.Value = 0
        inFile.Close()
        Me.Refresh()



        ' ---- Loading 'weapongrp.txt' ---- 
        inFile = New System.IO.StreamReader(sWeaponGrpFile, True)
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading weapongrp.txt..."

        While inFile.EndOfStream <> True

            sTemp = inFile.ReadLine
            If sTemp <> "" And sTemp.StartsWith("//") = False Then

                'weapon_type
                'handness=5
                'projectile
                'curvature=1000

                'weapongrp_begin	tag=0	id=1	drop_type=1	drop_anim_type=1	drop_radius=7	drop_height=15	UNK_0=0	durability=-1	weight=1600	material=8	crystallizable=0	projectile_?=0	body_part=7	handness=1	mt_pair_cntm=1	mt_pair_m[0]=LineageWeapons.small_sword_m00_wp	mt_pair_m[1]=	mt_pair_cntt=1	mt_pair_t[0]=LineageWeaponsTex.small_sword_t00_wp	mt_pair_t[1]=	mt_pair_t[2]=	item_sound_cnt=4	random_damage=10	patt=8	matt=6	weapon_type=1	crystal_type=0	critical=8	hit_mod=0	avoid_mod=0	shield_pdef=0	shield_rate=0	speed=379	mp_consume=0	SS_count=1	SPS_count=1	curvature=1000	UNK_2=0	is_hero=-1	UNK_3=0	effA=	effB=	junk1A[0]=0.000000	junk1A[1]=0.000000	junk1A[2]=0.000000	junk1A[3]=1.000000	junk1A[4]=1.000000	junk1B[0]=	junk1B[1]=	junk1B[2]=	junk1B[3]=	junk1B[4]=	rangeA=LineageWeapons.rangesample	rangeB=	junk2A[0]=0.950000	junk2A[1]=0.550000	junk2A[2]=0.550000	junk2A[3]=11.000000	junk2A[4]=0.000000	junk2A[5]=0.000000	junk2B[0]=	junk2B[1]=	junk2B[2]=	junk2B[3]=	junk2B[4]=	junk2B[5]=	junk3[0]=-1	junk3[1]=-1	junk3[2]=-1	junk3[3]=-1	icons[0]=	icons[1]=	icons[2]=	icons[3]=	weapongrp_end
                iTemp = CInt(Libraries.GetNeedParamFromStr(sTemp, "id"))
                If ItemData(iTemp).name = "" Then
                    MessageBox.Show("Found unknown ID. You must do update for your itemdata-e, because etcitemgrp item_id not defined in itemname-e", "Unknown ID", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    inFile.Close()
                    Exit Sub
                End If

                ItemData(iTemp).item_type = WeaponGrpDropAnimType(CInt(Libraries.GetNeedParamFromStr(sTemp, "drop_anim_type")))
                ItemData(iTemp).slot_bit_type = WeaponGrpSlotBitType(CInt(Libraries.GetNeedParamFromStr(sTemp, "body_part")))
                'ItemData(iTemp).armor_type = "none"
                ItemData(iTemp).etcitem_type = "none"
                'ItemData(iTemp).recipe_id = CInt(Libraries.GetNeedParamFromStr(sTemp, "id_mk"))
                'ItemData(iTemp).blessed = 0
                ItemData(iTemp).weight = CInt(Libraries.GetNeedParamFromStr(sTemp, "weight"))
                ItemData(iTemp).default_action = "action_equip"
                ItemData(iTemp).consume_type = "consume_type_normal"
                'ItemData(iTemp).initial_count = 1
                'ItemData(iTemp).maximum_count = 1
                ItemData(iTemp).soulshot_count = CInt(Libraries.GetNeedParamFromStr(sTemp, "SS_count"))
                ItemData(iTemp).spiritshot_count = CInt(Libraries.GetNeedParamFromStr(sTemp, "SPS_count"))
                'ItemData(iTemp).reduced_soulshot = "{}"
                'ItemData(iTemp).reduced_spiritshot = "{}"
                'ItemData(iTemp).reduced_mp_consume = "{}"
                'ItemData(iTemp).immediate_effect = 1
                'ItemData(iTemp).price = 0
                'ItemData(iTemp).default_price = 1
                'ItemData(iTemp).item_skill = "[none]"
                'ItemData(iTemp).critical_attack_skill = "[none]"
                'ItemData(iTemp).attack_skill = "[none]"
                'ItemData(iTemp).magic_skill = "[none]"
                'ItemData(iTemp).item_skill_enchanted_four = "[none]"
                ItemData(iTemp).material_type = EtcitemMaterial(CInt(Libraries.GetNeedParamFromStr(sTemp, "material")))
                ItemData(iTemp).crystal_type = EtcitemCrystalType(CInt(Libraries.GetNeedParamFromStr(sTemp, "crystal_type")))
                If ItemData(iTemp).crystal_type <> "none" Then
                    ItemData(iTemp).crystal_count = 1
                End If
                'ItemData(iTemp).is_trade = 1
                'ItemData(iTemp).is_drop = 1
                'ItemData(iTemp).is_destruct = 1
                ItemData(iTemp).physical_damage = CInt(Libraries.GetNeedParamFromStr(sTemp, "patt"))
                ItemData(iTemp).random_damage = CInt(Libraries.GetNeedParamFromStr(sTemp, "random_damage"))

                If CInt(Libraries.GetNeedParamFromStr(sTemp, "weapon_type")) < 16 Then
                    ItemData(iTemp).weapon_type = WeaponGrpWeaponType(CInt(Libraries.GetNeedParamFromStr(sTemp, "weapon_type")))
                Else
                    ItemData(iTemp).weapon_type = "none"
                End If
                'WeaponGrpWeaponType(5) = "fist"     'handness=3
                'WeaponGrpWeaponType(5) = "dualfist" 'handness=7
                'WeaponGrpWeaponType(8) = "dual" 'handness=3
                'WeaponGrpWeaponType(8) = "dualfist" 'handness=7

                If Libraries.GetNeedParamFromStr(sTemp, "handness") = "7" Then
                    If ItemData(iTemp).weapon_type = "fist" Or ItemData(iTemp).weapon_type = "dual" Then
                        ItemData(iTemp).weapon_type = "dualfist"
                    End If
                End If

                'ItemData(iTemp).can_penetrate = 0  ' weapon  15      [short_spear] spear   weapon  71      [flamberge]
                If ItemData(iTemp).slot_bit_type = "{lrhand}" Then
                    Select Case ItemData(iTemp).weapon_type
                        Case "pole"
                            ItemData(iTemp).can_penetrate = 1
                        Case "sword"
                            ItemData(iTemp).can_penetrate = 1
                        Case "dual"
                            ItemData(iTemp).can_penetrate = 1
                        Case "ancientsword"
                            ItemData(iTemp).can_penetrate = 1
                    End Select
                End If

                ItemData(iTemp).critical = CInt(Libraries.GetNeedParamFromStr(sTemp, "critical"))
                '   8
                'sword
                'pole
                'etc
                'fist
                'dual
                '   4
                'blunt
                'dualfist
                '   12
                'dagger
                'bow
                '   0
                'none
                'fishingrod

                'ItemData(iTemp).hit_modify = CInt(Libraries.GetNeedParamFromStr(sTemp, "hit_mod")) ' no work correcly. Do 4 but need 4.75, 3 - -3.75

                ItemData(iTemp).avoid_modify = CInt(Libraries.GetNeedParamFromStr(sTemp, "avoid_mod"))
                'ItemData(iTemp).dual_fhit_rate = 0     ' see in next block
                ItemData(iTemp).shield_defense = CInt(Libraries.GetNeedParamFromStr(sTemp, "shield_pdef"))
                ItemData(iTemp).shield_defense_rate = CInt(Libraries.GetNeedParamFromStr(sTemp, "shield_rate"))

                ' Set Default Settings
                'ItemData(iTemp).hit_modify = 0
                ItemData(iTemp).attack_range = 40
                ItemData(iTemp).damage_range = "{0;0;40;120}"
                Select Case ItemData(iTemp).weapon_type

                    Case "none"
                        ItemData(iTemp).attack_range = 0
                        ItemData(iTemp).damage_range = "{}"
                    Case "fist"
                        ItemData(iTemp).hit_modify = 4.75
                    Case "etc"
                        ItemData(iTemp).hit_modify = 4.75
                    Case "blunt"
                        ItemData(iTemp).hit_modify = 4.75
                        If ItemData(iTemp).slot_bit_type = "{lrhand}" Then ItemData(iTemp).damage_range = "{0;0;46;120}"
                    Case "dagger"
                        ItemData(iTemp).hit_modify = -3.75
                        'ItemData(iTemp).attack_range = 40
                        'ItemData(iTemp).damage_range = "{0;0;40;120}"
                    Case "sword"
                        If ItemData(iTemp).slot_bit_type = "{lrhand}" Then ItemData(iTemp).damage_range = "{0;0;44;120}"
                    Case "dual"
                        ItemData(iTemp).dual_fhit_rate = 50
                        'ItemData(iTemp).attack_range = 40
                        'ItemData(iTemp).damage_range = "{0;0;40;120}"
                        If ItemData(iTemp).slot_bit_type = "{lrhand}" Then ItemData(iTemp).damage_range = "{0;0;44;120}"
                    Case "dualfist"
                        ItemData(iTemp).dual_fhit_rate = 50
                        'ItemData(iTemp).attack_range = 40
                        ItemData(iTemp).hit_modify = 4.75
                        If ItemData(iTemp).slot_bit_type = "{lrhand}" Then
                            ItemData(iTemp).damage_range = "{0;0;44;90}"
                        Else
                            ItemData(iTemp).damage_range = "{0;0;32;120}"
                        End If
                    Case "pole"
                        ItemData(iTemp).hit_modify = -3.75
                        ItemData(iTemp).attack_range = 80
                        ItemData(iTemp).damage_range = "{0;0;66;120}"
                        ' ?? If ItemData(iTemp).slot_bit_type = "{lrhand}" Then ItemData(iTemp).damage_range = "{0;0;80;120}"
                    Case "fishingrod"
                        ItemData(iTemp).hit_modify = -3.75
                        ItemData(iTemp).attack_range = 80
                        ItemData(iTemp).damage_range = "{0;0;66;120}"
                    Case "bow"
                        ItemData(iTemp).hit_modify = -3.75
                        ItemData(iTemp).attack_range = 500
                        ItemData(iTemp).damage_range = "{0;0;10;0}"
                        ItemData(iTemp).reuse_delay = 1500
                    Case "crossbow"
                        ItemData(iTemp).hit_modify = -3.75
                        ItemData(iTemp).attack_range = 500
                        ItemData(iTemp).damage_range = "{0;0;10;0}"
                        ItemData(iTemp).reuse_delay = 820
                    Case "ancientsword"
                        ItemData(iTemp).damage_range = "{0;0;44;120}"
                    Case "rapier"
                        ItemData(iTemp).damage_range = "{0;0;40;120}"

                        'Case Else
                        'ItemData(iTemp).attack_range = 40
                        'ItemData(iTemp).damage_range = "{0;0;40;120}"
                End Select

                If ItemData(iTemp).slot_bit_type = "{lrhand}" And Libraries.GetNeedParamFromStr(sTemp, "handness") = "1" Then
                    ' Exception! This one hand weapon
                    ItemData(iTemp).slot_bit_type = "{rhand}"
                End If

                ItemData(iTemp).attack_speed = CInt(Libraries.GetNeedParamFromStr(sTemp, "speed"))
                'ItemData(iTemp).reuse_delay = 0
                ItemData(iTemp).mp_consume = CInt(Libraries.GetNeedParamFromStr(sTemp, "mp_consume"))
                ItemData(iTemp).magical_damage = CInt(Libraries.GetNeedParamFromStr(sTemp, "matt"))
                ItemData(iTemp).durability = CInt(Libraries.GetNeedParamFromStr(sTemp, "durability"))    'ItemData(iTemp).durability = 0
                'ItemData(iTemp).damaged = 0
                'ItemData(iTemp).physical_defense = 0
                'ItemData(iTemp).magical_defense = 0
                'ItemData(iTemp).mp_bonus = 0
                'ItemData(iTemp).category = "{}"
                'ItemData(iTemp).enchanted = 0
                'ItemData(iTemp).html = "[item_default.htm]"

                Select Case CInt(Libraries.GetNeedParamFromStr(sTemp, "body_part"))
                    Case 0
                        '@pet_wolf_a"
                        '@wind_strider;@star_strider;@twilight_strider
                        '@hatchling_of_wind;@hatchling_of_star;@hatchling_of_twilight
                        ItemData(iTemp).equip_pet = "{@pet_wolf_a;@wind_strider;@star_strider;@twilight_strider;@hatchling_of_wind;@hatchling_of_star;@hatchling_of_twilight}"
                End Select

                'ItemData(iTemp).magic_weapon = 0
                If ItemData(iTemp).crystal_type <> "none" Then
                    ItemData(iTemp).enchant_enable = 1
                End If
                'ItemData(iTemp).can_equip_sex = -1
                'ItemData(iTemp).can_equip_race = "{}"
                'ItemData(iTemp).can_equip_change_class = -1
                'ItemData(iTemp).can_equip_class = "{}"
                'ItemData(iTemp).can_equip_agit = -1
                'ItemData(iTemp).can_equip_castle = -1
                'ItemData(iTemp).can_equip_castle_num = "{}"
                'ItemData(iTemp).can_equip_clan_leader = -1
                'ItemData(iTemp).can_equip_clan_level = -1
                ItemData(iTemp).can_equip_hero = CInt(Libraries.GetNeedParamFromStr(sTemp, "is_hero"))
                'ItemData(iTemp).can_equip_nobless = -1
                'ItemData(iTemp).can_equip_chaotic = -1
            End If
            ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
            StatusStrip.Update()
        End While
        ToolStripProgressBar.Value = 0
        inFile.Close()
        Me.Refresh()

        ' ------- SAVING ITEMDATA.TXT -------
        If System.IO.File.Exists(sItemDataFile) = True Then System.IO.File.Copy(sItemDataFile, sItemDataFile & ".bak", True)
        Dim outFile As New System.IO.StreamWriter(sItemDataFile, False, System.Text.Encoding.Unicode, 1)

        ToolStripProgressBar.Maximum = ItemData.Length - 1
        ToolStripStatusLabel.Text = "Saving itemdata.txt..." : StatusStrip.Refresh()

        For iTemp = 0 To ItemData.Length - 1

            ToolStripProgressBar.Value = iTemp

            If ItemData(iTemp).name <> "" Then
                outFile.Write("item_begin" & vbTab)
                If ItemData(iTemp).durability <> -1 Then
                    outFile.Write("shadowitem" & vbTab)
                Else
                    outFile.Write(ItemData(iTemp).item_type & vbTab)
                End If
                outFile.Write(iTemp & vbTab)
                outFile.Write(ItemData(iTemp).namepch & vbTab) '"[small_sword]"
                outFile.Write("item_type=" & ItemData(iTemp).item_type & vbTab)
                outFile.Write("slot_bit_type=" & ItemData(iTemp).slot_bit_type & vbTab)
                outFile.Write("armor_type=" & ItemData(iTemp).armor_type & vbTab)
                outFile.Write("etcitem_type=" & ItemData(iTemp).etcitem_type & vbTab)
                outFile.Write("recipe_id=" & ItemData(iTemp).recipe_id & vbTab)
                outFile.Write("blessed=" & ItemData(iTemp).blessed & vbTab)
                outFile.Write("weight=" & ItemData(iTemp).weight & vbTab)
                outFile.Write("default_action=" & ItemData(iTemp).default_action & vbTab)
                outFile.Write("consume_type=" & ItemData(iTemp).consume_type & vbTab)
                outFile.Write("initial_count=" & ItemData(iTemp).initial_count & vbTab)
                outFile.Write("maximum_count=" & ItemData(iTemp).maximum_count & vbTab)
                outFile.Write("soulshot_count=" & ItemData(iTemp).soulshot_count & vbTab)
                outFile.Write("spiritshot_count=" & ItemData(iTemp).spiritshot_count & vbTab)
                outFile.Write("reduced_soulshot=" & ItemData(iTemp).reduced_soulshot & vbTab)
                outFile.Write("reduced_spiritshot=" & ItemData(iTemp).reduced_spiritshot & vbTab)
                outFile.Write("reduced_mp_consume=" & ItemData(iTemp).reduced_mp_consume & vbTab)
                outFile.Write("immediate_effect=" & ItemData(iTemp).immediate_effect & vbTab)
                outFile.Write("price=" & ItemData(iTemp).price & vbTab)
                outFile.Write("default_price=" & ItemData(iTemp).default_price & vbTab)
                outFile.Write("item_skill=" & ItemData(iTemp).item_skill & vbTab)
                outFile.Write("critical_attack_skill=" & ItemData(iTemp).critical_attack_skill & vbTab)
                outFile.Write("attack_skill=" & ItemData(iTemp).attack_skill & vbTab)
                outFile.Write("magic_skill=" & ItemData(iTemp).magic_skill & vbTab)
                outFile.Write("item_skill_enchanted_four=" & ItemData(iTemp).item_skill_enchanted_four & vbTab)
                outFile.Write("material_type=" & ItemData(iTemp).material_type & vbTab)
                outFile.Write("crystal_type=" & ItemData(iTemp).crystal_type & vbTab)
                outFile.Write("crystal_count=" & ItemData(iTemp).crystal_count & vbTab)
                outFile.Write("is_trade=" & ItemData(iTemp).is_trade & vbTab)
                outFile.Write("is_drop=" & ItemData(iTemp).is_drop & vbTab)
                outFile.Write("is_destruct=" & ItemData(iTemp).is_destruct & vbTab)
                outFile.Write("physical_damage=" & ItemData(iTemp).physical_damage & vbTab)
                outFile.Write("random_damage=" & ItemData(iTemp).random_damage & vbTab)
                outFile.Write("weapon_type=" & ItemData(iTemp).weapon_type & vbTab)
                outFile.Write("can_penetrate=" & ItemData(iTemp).can_penetrate & vbTab)
                outFile.Write("critical=" & ItemData(iTemp).critical & vbTab)
                outFile.Write("hit_modify=" & ItemData(iTemp).hit_modify & vbTab)
                outFile.Write("avoid_modify=" & ItemData(iTemp).avoid_modify & vbTab)
                outFile.Write("dual_fhit_rate=" & ItemData(iTemp).dual_fhit_rate & vbTab)
                outFile.Write("shield_defense=" & ItemData(iTemp).shield_defense & vbTab)
                outFile.Write("shield_defense_rate=" & ItemData(iTemp).shield_defense_rate & vbTab)
                outFile.Write("attack_range=" & ItemData(iTemp).attack_range & vbTab)
                outFile.Write("damage_range=" & ItemData(iTemp).damage_range & vbTab)
                outFile.Write("attack_speed=" & ItemData(iTemp).attack_speed & vbTab)
                outFile.Write("reuse_delay=" & ItemData(iTemp).reuse_delay & vbTab)
                outFile.Write("mp_consume=" & ItemData(iTemp).mp_consume & vbTab)
                outFile.Write("magical_damage=" & ItemData(iTemp).magical_damage & vbTab)
                outFile.Write("durability=0" & ItemData(iTemp).durability & vbTab)
                outFile.Write("damaged=" & ItemData(iTemp).damaged & vbTab)
                outFile.Write("physical_defense=" & ItemData(iTemp).physical_defense & vbTab)
                outFile.Write("magical_defense=" & ItemData(iTemp).magical_defense & vbTab)
                outFile.Write("mp_bonus=" & ItemData(iTemp).mp_bonus & vbTab)
                outFile.Write("category=" & ItemData(iTemp).category & vbTab)
                outFile.Write("enchanted=" & ItemData(iTemp).enchanted & vbTab)
                outFile.Write("html=" & ItemData(iTemp).html & vbTab)
                outFile.Write("equip_pet=" & ItemData(iTemp).equip_pet & vbTab)
                outFile.Write("magic_weapon=" & ItemData(iTemp).magic_weapon & vbTab)
                outFile.Write("enchant_enable=" & ItemData(iTemp).enchant_enable & vbTab)

                ' CT23 + NextDev Ext.dll support
                'equip_cond={}	equip_cond = 
                'outFile.Write("can_equip_sex=" & ItemData(iTemp).can_equip_sex & vbTab)
                'outFile.Write("can_equip_race=" & ItemData(iTemp).can_equip_race & vbTab)
                'outFile.Write("can_equip_change_class=" & ItemData(iTemp).can_equip_change_class & vbTab)
                'outFile.Write("can_equip_class=" & ItemData(iTemp).can_equip_class & vbTab)
                'outFile.Write("can_equip_agit=" & ItemData(iTemp).can_equip_agit & vbTab)
                'outFile.Write("can_equip_castle=" & ItemData(iTemp).can_equip_castle & vbTab)
                'outFile.Write("can_equip_castle_num=" & ItemData(iTemp).can_equip_castle_num & vbTab)
                'outFile.Write("can_equip_clan_leader=" & ItemData(iTemp).can_equip_clan_leader & vbTab)
                'outFile.Write("can_equip_clan_level=" & ItemData(iTemp).can_equip_clan_level & vbTab)
                'outFile.Write("can_equip_hero=" & ItemData(iTemp).can_equip_hero & vbTab)
                'outFile.Write("can_equip_nobless=" & ItemData(iTemp).can_equip_nobless & vbTab)
                'outFile.Write("can_equip_chaotic=" & ItemData(iTemp).can_equip_chaotic & vbTab)

                outFile.Write("equip_cond={")
                Dim iCanFlag As Boolean = False
                If ItemData(iTemp).can_equip_hero <> -1 Then outFile.Write("{ec_hero;1}") : iCanFlag = True
                'If iCanFlag = True Then outFile.Write(";" & vbTab)
                outFile.Write("}" & vbTab)

                If ItemData(iTemp).durability <> -1 Then
                    outFile.Write("mana=" & ItemData(iTemp).durability & vbTab)
                    outFile.Write("is_augment=0" & vbTab)
                End If
                outFile.WriteLine("item_end")
            End If
        Next



        ' SET Writer
        ' '' set_ids={1101,1104,44}	set_bonus_desc=[Casting Spd. +15%.]	set_extra_id=[]	set_extra_desc=[]
        ' '' set_ids={2381,2417,5722,5738}	set_bonus_desc=[Maximum HP +320, Breath Gauge increase, STR-3, and CON+3.]	set_extra_id=[110]	set_extra_desc=[Shield Def +24%.]

        ' ''id=2381	name=[Doom Plate Armor]	add_name=[]	description=[Full body armor.]	popup=-1	
        ' ''set_ids={2381,2417,5722,5738}	set_bonus_desc=[Maximum HP +320, Breath Gauge increase, STR-3, and CON+3.]
        ' ''set_extra_id=[110]	set_extra_desc=[Shield Def +24%.]	unk[0]=0	unk[1]=0	
        ' ''special_enchant_amount=6	special_enchant_desc=[When all set items are enchanted by 6 or higher, P. Def. and MP regeneration rate will increase.]	itemname_end
        ''Dim aTemp() As String
        ''Dim iTemp2 As Integer, iId As Integer
        ''Dim armorType As Integer ' for six enchants

        ''For iTemp = 1 To ItemSets.Length - 1
        ''    outFile.WriteLine("// SetID " & iTemp & ": " & ItemSets(iTemp).SetName) '& vbTab & "Additional description: " & ItemSets(iTemp).ItemAddDesc)
        ''    If ItemSets(iTemp).ItemAdd <> "" Then
        ''        outFile.WriteLine("// " & vbTab & ItemData(CInt(ItemSets(iTemp).ItemAdd)).name & ". " & ItemSets(iTemp).ItemAddDesc)
        ''    End If
        ''Next
        ''For iTemp = 1 To ItemSets.Length - 1
        ''    'set_begin	13	slot_chest=354	slot_legs=381	slot_head=2413	slot_lhand=2495	slot_additional=[slot_lhand]	set_skill=[s_set_collected]	set_effect_skill=[s_chain_mail_shirt_material]	set_additional_effect_skill=[s_chain_mail_shirt_material_shield]	str_inc={0;0}	con_inc={0;0}	dex_inc={0;0}	int_inc={0;0}	men_inc={0;0}	wit_inc={0;0}	set_end

        ''    outFile.Write("set_begin" & vbTab)
        ''    outFile.Write(iTemp & vbTab)
        ''    outFile.Write("slot_chest=" & ItemSets(iTemp).ChestId & vbTab)
        ''    If GenerateEnch6CheckBox.Checked = True Then
        ''        sTemp = ""
        ''        armorType = 0
        ''        sTemp = sTemp & "slot_chest "
        ''        armorType = CInt(ItemSets(iTemp).ChestId)
        ''    End If

        ''    aTemp = ItemSets(iTemp).ItemList.Split(CChar(","))
        ''    For iTemp2 = 0 To aTemp.Length - 1
        ''        If CInt(aTemp(iTemp2)) <> CInt(ItemSets(iTemp).ChestId) Then
        ''            outFile.Write("slot_" & ItemData(CInt(aTemp(iTemp2))).slot_bit_type.Replace("{", "").Replace("}", "") & "=" & aTemp(iTemp2) & vbTab)

        ''            If GenerateEnch6CheckBox.Checked = True Then
        ''                sTemp = sTemp & "slot_" & ItemData(CInt(aTemp(iTemp2))).slot_bit_type.Replace("{", "").Replace("}", "") & " "
        ''            End If

        ''        End If
        ''    Next
        ''    If ItemSets(iTemp).ItemAdd = "" Then
        ''        outFile.Write("slot_additional=[none]" & vbTab)
        ''    Else
        ''        iId = CInt(ItemSets(iTemp).ItemAdd)
        ''        outFile.Write("slot_" & ItemData(iId).slot_bit_type.Replace("{", "").Replace("}", "") & "=" & iId & vbTab)
        ''        outFile.Write("slot_additional=[slot_" & ItemData(iId).slot_bit_type.Replace("{", "").Replace("}", "") & "]" & vbTab)
        ''    End If

        ''    outFile.Write("set_skill=[s_set_collected]" & vbTab)
        ''    outFile.Write("set_effect_skill=[none]" & vbTab)
        ''    outFile.Write("set_additional_effect_skill=[none]" & vbTab)

        ''    If GenerateEnch6CheckBox.Checked = True Then
        ''        outFile.Write("enchant_six_skill=[s_enchant_six_" & ItemData(armorType).armor_type & "_" & ItemData(armorType).crystal_type & "]" & vbTab)
        ''        sTemp = sTemp.Trim.Replace(" ", ";")
        ''        sTemp = "enchant_six_slots=[" & sTemp & "]"
        ''        outFile.Write(sTemp & vbTab)
        ''    End If

        ''    outFile.Write("str_inc={0;0}" & vbTab)
        ''    outFile.Write("con_inc={0;0}" & vbTab)
        ''    outFile.Write("dex_inc={0;0}" & vbTab)
        ''    outFile.Write("int_inc={0;0}" & vbTab)
        ''    outFile.Write("men_inc={0;0}" & vbTab)
        ''    outFile.Write("wit_inc={0;0}" & vbTab)
        ''    outFile.Write("p_def_inc={0;0}" & vbTab)
        ''    outFile.WriteLine("set_end")
        ''Next
        ''ToolStripProgressBar.Value = 0

        ' SET WRITER - CT23 FORMAT
        If ItemSets.Length > 0 Then
            For iTemp = 0 To (ItemSets.Length - 2)
                outFile.Write("// " & (iTemp + 1) & vbTab)
                outFile.Write(ItemSets(iTemp).SetName)
                If ItemSets(iTemp).SetDescription <> "[]" Then outFile.Write(vbTab & ItemSets(iTemp).SetDescription)
                If ItemSets(iTemp).SetBonusDesc <> "[]" Then outFile.Write(vbTab & ItemSets(iTemp).SetBonusDesc)
                If ItemSets(iTemp).SetExtraDesc <> "[]" Then outFile.Write(vbTab & ItemSets(iTemp).SetExtraDesc)
                If ItemSets(iTemp).SetSpecEnchDesc <> "[]" Then outFile.Write(vbTab & ItemSets(iTemp).SetSpecEnchDesc)
                outFile.WriteLine("")
            Next
        End If


        '    ' CT23 format
        'cnt0=5	set_ids[0]=[2376]	set_ids[1]=[2379,11375]	set_ids[2]=[2415,11373]	set_ids[3]=[5714,11365]	set_ids[4]=[5730,11370]	
        'cnt1=1	set_extra_ids=[673,11374]
        'set_begin	45	
        '           slot_chest={6383;11488}	slot_head={6386;11490}	slot_gloves={6384;11487}	slot_feet={6385;11489}	slot_additional=[none]	

        '           set_skill=[s_set_collected]	set_effect_skill=[s_major_arcana_robe]

        '           slot_lhand={673}	slot_additional=[slot_lhand]	

        '           set_skill=[s_set_collected]	set_effect_skill=[s_avadon_breastplate]	
        '           set_additional_effect_skill=[s_avadon_breastplate_shield]	

        '           set_enchant_six_skill=[s_ench_heavy_armor_grade_b]

        '           str_inc={0;0}	con_inc={0;0}	dex_inc={0;0}	int_inc={1;0}	men_inc={-2;0}	wit_inc={1;0}	set_end

        'set_begin	26	slot_chest={2376}	slot_legs={2379}	slot_head={2415}	slot_gloves={5714}	slot_feet={5730}	

        inFile = New System.IO.StreamReader(sItemNameFile, True)
        ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
        ToolStripStatusLabel.Text = "Loading itemname-e.txt..."
        Dim iTemp2 As Integer, iSetCounter As Integer = 0
        Dim iTemp3 As Integer, sTemp3() As String
        
        While inFile.EndOfStream <> True
            sTemp = inFile.ReadLine
            If sTemp <> "" And sTemp.StartsWith("//") = False Then

                iTemp = CInt(Libraries.GetNeedParamFromStr(sTemp, "cnt0"))
                If iTemp > 0 Then

                    outFile.Write("set_begin" & vbTab)
                    iSetCounter = iSetCounter + 1
                    outFile.Write(iSetCounter & vbTab)

                    For iTemp2 = 0 To iTemp - 1
                        sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "set_ids[" & iTemp2 & "]")
                        sTemp2 = sTemp2.Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "").Replace(",", ";")

                        sTemp3 = sTemp2.Split : iTemp3 = CInt(sTemp3(0))

                        If ItemData(iTemp3).slot_bit_type = "{onepiece}" Then ItemData(iTemp3).slot_bit_type = "{chest}"
                        outFile.Write("slot_" & ItemData(iTemp3).slot_bit_type.Replace("{", "").Replace("}", "") & "=")

                        'Select Case iTemp2
                        '    Case 0
                        '        outFile.Write("slot_chest=")
                        '    Case 1
                        '        outFile.Write("slot_legs=")
                        '    Case 2
                        '        outFile.Write("slot_head=")
                        '    Case 3
                        '        outFile.Write("slot_gloves=")
                        '    Case 4
                        '        outFile.Write("slot_feet=")
                        'End Select
                        outFile.Write("{" & sTemp2 & "}" & vbTab)

                    Next

                    'lhand - shield equip
                    iTemp = CInt(Libraries.GetNeedParamFromStr(sTemp, "cnt1"))
                    If iTemp > 0 Then
                        For iTemp2 = 0 To iTemp - 1
                            'cnt1=1	set_extra_ids=[673,11374]
                            sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "set_extra_ids")
                            sTemp2 = sTemp2.Replace("[", "{").Replace("]", "}")
                            'slot_lhand={673,11374}	slot_additional=[slot_lhand]
                            outFile.Write("slot_lhand=" & sTemp2 & vbTab)
                            outFile.Write("slot_additional=[slot_lhand]" & vbTab)
                        Next
                    Else
                        outFile.Write("slot_additional=[none]" & vbTab)
                    End If

                    outFile.Write("set_skill=[s_set_collected]" & vbTab)
                    outFile.Write("set_effect_skill=[none]" & vbTab)
                    If CInt(Libraries.GetNeedParamFromStr(sTemp, "cnt1")) > 0 Then outFile.Write("set_additional_effect_skill=[none]" & vbTab)
                    'set_enchant_six_skill=[s_ench_heavy_armor_grade_b]
                    If CInt(Libraries.GetNeedParamFromStr(sTemp, "special_enchant_amount")) > 0 Then outFile.Write("set_enchant_six_skill=[none]" & vbTab)


                    outFile.Write("str_inc={0;0}" & vbTab)
                    outFile.Write("con_inc={0;0}" & vbTab)
                    outFile.Write("dex_inc={0;0}" & vbTab)
                    outFile.Write("int_inc={0;0}" & vbTab)
                    outFile.Write("men_inc={0;0}" & vbTab)
                    outFile.Write("wit_inc={0;0}" & vbTab)
                    outFile.Write("p_def_inc={0;0}" & vbTab)
                    outFile.WriteLine("set_end")
                End If

            End If

        End While
        inFile.Close()
        outFile.Close()
        ToolStripProgressBar.Value = 0

        ToolStripStatusLabel.Text = "Complete"
        MessageBox.Show("Complete")

        Exit Sub

ErrorScreener:

        If MessageBox.Show("Found bad param value in line" & vbNewLine & sTemp & vbNewLine & vbNewLine & "Continue generation or stop? If you continue, this item may be wrong", "Bad value", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            'Resume Next
        End If

        inFile.Close()
        ToolStripProgressBar.Value = 0

        ToolStripStatusLabel.Text = "Generation aborted"
        MessageBox.Show("Generation aborted", "Stoped", MessageBoxButtons.OK, MessageBoxIcon.Stop)

    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        Me.Close()
    End Sub
End Class