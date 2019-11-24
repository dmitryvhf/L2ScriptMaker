<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class SkillEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SkillEditor))
        Me.skillname = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.skillid = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.skilllevel = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.magiclevel = New System.Windows.Forms.TextBox
        Me.operatetype = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.effect = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.operatecond = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.mp1 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.itemconsume = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.ismagic = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.mp2 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.castrange = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.effectrange = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.skillhittime = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.reusedelay = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.skillcooltime = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.skillhitcanceltime = New System.Windows.Forms.TextBox
        Me.attribute = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.effectpoint = New System.Windows.Forms.TextBox
        Me.targettype = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.affectscope = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.nextaction = New System.Windows.Forms.ComboBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.affectrange = New System.Windows.Forms.TextBox
        Me.affectobject = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.abnormaltype = New System.Windows.Forms.ComboBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.abnormalviseffect = New System.Windows.Forms.ComboBox
        Me.basicprop = New System.Windows.Forms.ComboBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.lvbonusrate = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.activaterate = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.abnormallv = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.abnormaltime = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.fanrange = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.hp = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.mp_summ = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.unavcond = New System.Windows.Forms.TextBox
        Me.SkillOutBox = New System.Windows.Forms.TextBox
        Me.StartButton = New System.Windows.Forms.Button
        Me.QuitButton = New System.Windows.Forms.Button
        Me.ClearButton = New System.Windows.Forms.Button
        Me.ImportButton = New System.Windows.Forms.Button
        Me.comment = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.AutoClear = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'skillname
        '
        Me.skillname.Location = New System.Drawing.Point(70, 6)
        Me.skillname.Name = "skillname"
        Me.skillname.Size = New System.Drawing.Size(233, 20)
        Me.skillname.TabIndex = 0
        Me.skillname.Text = "s_"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "skill_name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(383, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "skill_id"
        '
        'skillid
        '
        Me.skillid.Location = New System.Drawing.Point(423, 7)
        Me.skillid.Name = "skillid"
        Me.skillid.Size = New System.Drawing.Size(44, 20)
        Me.skillid.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(314, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "level"
        '
        'skilllevel
        '
        Me.skilllevel.Location = New System.Drawing.Point(345, 6)
        Me.skilllevel.Name = "skilllevel"
        Me.skilllevel.Size = New System.Drawing.Size(35, 20)
        Me.skilllevel.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "operate_type"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(473, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "magic_level"
        '
        'magiclevel
        '
        Me.magiclevel.Location = New System.Drawing.Point(538, 6)
        Me.magiclevel.Name = "magiclevel"
        Me.magiclevel.Size = New System.Drawing.Size(37, 20)
        Me.magiclevel.TabIndex = 2
        '
        'operatetype
        '
        Me.operatetype.FormattingEnabled = True
        Me.operatetype.Items.AddRange(New Object() {"A1", "A2", "A3", "P", "T"})
        Me.operatetype.Location = New System.Drawing.Point(82, 32)
        Me.operatetype.Name = "operatetype"
        Me.operatetype.Size = New System.Drawing.Size(45, 21)
        Me.operatetype.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "effect"
        '
        'effect
        '
        Me.effect.Location = New System.Drawing.Point(48, 59)
        Me.effect.Name = "effect"
        Me.effect.Size = New System.Drawing.Size(636, 20)
        Me.effect.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "operate_cond"
        '
        'operatecond
        '
        Me.operatecond.Location = New System.Drawing.Point(90, 160)
        Me.operatecond.Name = "operatecond"
        Me.operatecond.Size = New System.Drawing.Size(181, 20)
        Me.operatecond.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "mp_consume1"
        '
        'mp1
        '
        Me.mp1.Location = New System.Drawing.Point(80, 13)
        Me.mp1.Name = "mp1"
        Me.mp1.Size = New System.Drawing.Size(37, 20)
        Me.mp1.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "item_consume"
        '
        'itemconsume
        '
        Me.itemconsume.Location = New System.Drawing.Point(80, 39)
        Me.itemconsume.Name = "itemconsume"
        Me.itemconsume.Size = New System.Drawing.Size(203, 20)
        Me.itemconsume.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(587, 7)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "is_magic"
        '
        'ismagic
        '
        Me.ismagic.FormattingEnabled = True
        Me.ismagic.Items.AddRange(New Object() {"0", "1"})
        Me.ismagic.Location = New System.Drawing.Point(637, 5)
        Me.ismagic.Name = "ismagic"
        Me.ismagic.Size = New System.Drawing.Size(47, 21)
        Me.ismagic.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(123, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "mp_consume2"
        '
        'mp2
        '
        Me.mp2.Location = New System.Drawing.Point(200, 13)
        Me.mp2.Name = "mp2"
        Me.mp2.Size = New System.Drawing.Size(37, 20)
        Me.mp2.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 189)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "cast_range"
        '
        'castrange
        '
        Me.castrange.Location = New System.Drawing.Point(82, 186)
        Me.castrange.Name = "castrange"
        Me.castrange.Size = New System.Drawing.Size(37, 20)
        Me.castrange.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(131, 189)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 13)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "effective_range"
        '
        'effectrange
        '
        Me.effectrange.Location = New System.Drawing.Point(213, 186)
        Me.effectrange.Name = "effectrange"
        Me.effectrange.Size = New System.Drawing.Size(37, 20)
        Me.effectrange.TabIndex = 12
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 13)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "skill_hit_time"
        '
        'skillhittime
        '
        Me.skillhittime.Location = New System.Drawing.Point(115, 13)
        Me.skillhittime.Name = "skillhittime"
        Me.skillhittime.Size = New System.Drawing.Size(37, 20)
        Me.skillhittime.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.reusedelay)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.skillcooltime)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.skillhitcanceltime)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.skillhittime)
        Me.GroupBox1.Location = New System.Drawing.Point(380, 85)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(284, 69)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Skill use time"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(165, 42)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 13)
        Me.Label19.TabIndex = 35
        Me.Label19.Text = "reuse_delay"
        '
        'reusedelay
        '
        Me.reusedelay.Location = New System.Drawing.Point(241, 39)
        Me.reusedelay.Name = "reusedelay"
        Me.reusedelay.Size = New System.Drawing.Size(37, 20)
        Me.reusedelay.TabIndex = 3
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(165, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(75, 13)
        Me.Label18.TabIndex = 33
        Me.Label18.Text = "skill_cool_time"
        '
        'skillcooltime
        '
        Me.skillcooltime.Location = New System.Drawing.Point(241, 13)
        Me.skillcooltime.Name = "skillcooltime"
        Me.skillcooltime.Size = New System.Drawing.Size(37, 20)
        Me.skillcooltime.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 42)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(104, 13)
        Me.Label17.TabIndex = 31
        Me.Label17.Text = "skill_hit_cancel_time"
        '
        'skillhitcanceltime
        '
        Me.skillhitcanceltime.Location = New System.Drawing.Point(115, 39)
        Me.skillhitcanceltime.Name = "skillhitcanceltime"
        Me.skillhitcanceltime.Size = New System.Drawing.Size(37, 20)
        Me.skillhitcanceltime.TabIndex = 2
        '
        'attribute
        '
        Me.attribute.FormattingEnabled = True
        Me.attribute.Items.AddRange(New Object() {"attr_none", "attr_sword", "attr_blunt", "attr_dagger", "attr_pole", "attr_fist", "attr_bow", "attr_etc", "attr_earth", "attr_water", "attr_wind", "attr_fire", "attr_poison", "attr_holy", "attr_hold", "attr_bleed", "attr_sleep", "attr_shock", "attr_derangement", "attr_unholy", "attr_bug_weakness", "attr_bug_weakness", "attr_animal_weakness", "attr_plant_weakness", "attr_beast_weakness", "attr_dragon_weakness", "attr_paralyze", "attr_dual", "attr_dualfist", "attr_boss", "attr_death", "attr_valakas"})
        Me.attribute.Location = New System.Drawing.Point(312, 186)
        Me.attribute.Name = "attribute"
        Me.attribute.Size = New System.Drawing.Size(86, 21)
        Me.attribute.TabIndex = 13
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(262, 188)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(45, 13)
        Me.Label20.TabIndex = 35
        Me.Label20.Text = "attribute"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(404, 190)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 38
        Me.Label21.Text = "effect_point"
        '
        'effectpoint
        '
        Me.effectpoint.Location = New System.Drawing.Point(469, 187)
        Me.effectpoint.Name = "effectpoint"
        Me.effectpoint.Size = New System.Drawing.Size(37, 20)
        Me.effectpoint.TabIndex = 14
        '
        'targettype
        '
        Me.targettype.FormattingEnabled = True
        Me.targettype.Items.AddRange(New Object() {"none", "self", "target", "others", "enemy", "enemy_only", "item", "summon", "holything", "door_treasure", "pc_body", "npc_body", "wyvern_target"})
        Me.targettype.Location = New System.Drawing.Point(581, 185)
        Me.targettype.Name = "targettype"
        Me.targettype.Size = New System.Drawing.Size(103, 21)
        Me.targettype.TabIndex = 15
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(519, 188)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(60, 13)
        Me.Label22.TabIndex = 39
        Me.Label22.Text = "target_type"
        '
        'affectscope
        '
        Me.affectscope.FormattingEnabled = True
        Me.affectscope.Items.AddRange(New Object() {"none", "single", "range", "dead_pledge", "fan", "party", "pledge", "point_blank", "square_pb"})
        Me.affectscope.Location = New System.Drawing.Point(73, 13)
        Me.affectscope.Name = "affectscope"
        Me.affectscope.Size = New System.Drawing.Size(91, 21)
        Me.affectscope.TabIndex = 0
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(6, 16)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(69, 13)
        Me.Label23.TabIndex = 41
        Me.Label23.Text = "affect_scope"
        '
        'nextaction
        '
        Me.nextaction.FormattingEnabled = True
        Me.nextaction.Items.AddRange(New Object() {"none", "sit", "attack", "fake_death"})
        Me.nextaction.Location = New System.Drawing.Point(627, 303)
        Me.nextaction.Name = "nextaction"
        Me.nextaction.Size = New System.Drawing.Size(57, 21)
        Me.nextaction.TabIndex = 19
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(626, 287)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(62, 13)
        Me.Label24.TabIndex = 43
        Me.Label24.Text = "next_action"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(170, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 13)
        Me.Label15.TabIndex = 46
        Me.Label15.Text = "affect_range"
        '
        'affectrange
        '
        Me.affectrange.Location = New System.Drawing.Point(196, 40)
        Me.affectrange.Name = "affectrange"
        Me.affectrange.Size = New System.Drawing.Size(37, 20)
        Me.affectrange.TabIndex = 2
        '
        'affectobject
        '
        Me.affectobject.FormattingEnabled = True
        Me.affectobject.Items.AddRange(New Object() {"friend", "not_friend", "undead_real_enemy"})
        Me.affectobject.Location = New System.Drawing.Point(73, 40)
        Me.affectobject.Name = "affectobject"
        Me.affectobject.Size = New System.Drawing.Size(91, 21)
        Me.affectobject.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 43)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 13)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "affect_object"
        '
        'abnormaltype
        '
        Me.abnormaltype.FormattingEnabled = True
        Me.abnormaltype.Items.AddRange(New Object() {"none", "pa_up", "pa_up_special", "pa_down", "pd_up", "pd_up_special", "ma_up", "md_up", "md_up_attr", "avoid_up", "avoid_up_special", "hit_up", "hit_down", "fatal_poison", "fly_away", "turn_stone", "casting_time_down", "attack_time_down", "speed_up", "possession", "attack_time_up", "speed_down", "hp_regen_up", "max_mp_up", "antaras_debuff", "critical_prob_up", "cancel_prob_down", "bow_range_up", "max_breath_up", "decrease_weight_penalty", "poison", "bleeding", "dot_attr", "dot_mp", "dmg_shield", "hawk_eye", "resist_shock", "paralyze", "public_slot", "silence", "derangement", "stun", "resist_poison", "resist_derangement", "resist_spiritless", "mp_regen_up", "md_down", "heal_effect_down", "turn_passive", "turn_flee", "vampiric_attack", "duelist_spirit", "hp_recover", "mp_recover", "root", "speed_up_special", "majesty", "pd_up_bow", "attack_speed_up_bow", "max_hp_up", "holy_attack", "sleep", "berserker", "pinch", "life_force", "song_of_earth", "song_of_life", "song_of_water", "song_of_warding", "song_of_wind", "song_of_hunter", "song_of_invocation", "song_of_vitality", "song_of_flame_guard", "song_of_storm_guard", "song_of_renewal", "song_of_meditation", "song_of_champion", "song_of_vengeance", "dance_of_warrior", "dance_of_inspiration", "dance_of_mystic", "dance_of_fire", "dance_of_fury", "dance_of_concentration", "dance_of_light", "dance_of_vampire", "dance_of_aqua_guard", "dance_of_earth_guard", "dance_of_siren", "dance_of_shadow", "dance_of_protection", "detect_weakness", "thrill_fight", "resist_bleeding", "critical_dmg_up", "shield_prob_up", "hp_regen_down", "reuse_delay_up", "pd_down", "big_head", "snipe", "cheap_magic", "magic_critical_up", "shield_defence_up", "rage_might", "ultimate_buff", "reduce_drop_penalty", "heal_effect_up", "ssq_town_curse", "ssq_town_blessing", "big_body", "preserve_abnormal", "spa_disease_a", "spa_disease_b", "spa_disease_c", "spa_disease_d", "avoid_down", "multi_buff", "dragon_breath", "ultimate_debuff", "buff_queen_of_cat", "buff_unicorn_seraphim", "debuff_nightshade", "watcher_gaze", "multi_debuff", "reflect_abnormal", "focus_dagger", "max_hp_down", "resist_holy_unholy", "resist_debuff_dispel", "touch_of_life", "touch_of_death", "silence_physical", "silence_all", "valakas_item"})
        Me.abnormaltype.Location = New System.Drawing.Point(7, 65)
        Me.abnormaltype.Name = "abnormaltype"
        Me.abnormaltype.Size = New System.Drawing.Size(151, 21)
        Me.abnormaltype.TabIndex = 5
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 49)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(76, 13)
        Me.Label25.TabIndex = 49
        Me.Label25.Text = "abnormal_type"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.abnormalviseffect)
        Me.GroupBox2.Controls.Add(Me.basicprop)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.lvbonusrate)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.activaterate)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.abnormallv)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.abnormaltime)
        Me.GroupBox2.Controls.Add(Me.abnormaltype)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 213)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(397, 97)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Abnormal"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(164, 68)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(116, 13)
        Me.Label32.TabIndex = 65
        Me.Label32.Text = "abnormal_visual_effect"
        '
        'abnormalviseffect
        '
        Me.abnormalviseffect.FormattingEnabled = True
        Me.abnormalviseffect.Items.AddRange(New Object() {"ave_none", "ave_dot_bleeding", "ave_dot_poison", "ave_dot_fire", "ave_dot_water", "ave_dot_wind", "ave_dot_soil", "ave_dot_mp", "ave_stun", "ave_silence", "ave_sleep", "ave_root", "ave_paralyze", "ave_flesh_stone", "ave_dot_fire_area", "ave_big_head", "ave_change_texture", "ave_big_body"})
        Me.abnormalviseffect.Location = New System.Drawing.Point(282, 65)
        Me.abnormalviseffect.Name = "abnormalviseffect"
        Me.abnormalviseffect.Size = New System.Drawing.Size(109, 21)
        Me.abnormalviseffect.TabIndex = 6
        '
        'basicprop
        '
        Me.basicprop.FormattingEnabled = True
        Me.basicprop.Items.AddRange(New Object() {"none", "dex", "con", "str", "men"})
        Me.basicprop.Location = New System.Drawing.Point(341, 39)
        Me.basicprop.Name = "basicprop"
        Me.basicprop.Size = New System.Drawing.Size(50, 21)
        Me.basicprop.TabIndex = 4
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(263, 42)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(76, 13)
        Me.Label31.TabIndex = 63
        Me.Label31.Text = "basic_property"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(263, 16)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(74, 13)
        Me.Label30.TabIndex = 61
        Me.Label30.Text = "lv_bonus_rate"
        '
        'lvbonusrate
        '
        Me.lvbonusrate.Location = New System.Drawing.Point(340, 13)
        Me.lvbonusrate.Name = "lvbonusrate"
        Me.lvbonusrate.Size = New System.Drawing.Size(37, 20)
        Me.lvbonusrate.TabIndex = 2
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(140, 42)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(69, 13)
        Me.Label29.TabIndex = 59
        Me.Label29.Text = "activate_rate"
        '
        'activaterate
        '
        Me.activaterate.Location = New System.Drawing.Point(217, 39)
        Me.activaterate.Name = "activaterate"
        Me.activaterate.Size = New System.Drawing.Size(37, 20)
        Me.activaterate.TabIndex = 3
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(6, 16)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(64, 13)
        Me.Label28.TabIndex = 57
        Me.Label28.Text = "abnormal_lv"
        '
        'abnormallv
        '
        Me.abnormallv.Location = New System.Drawing.Point(84, 13)
        Me.abnormallv.Name = "abnormallv"
        Me.abnormallv.Size = New System.Drawing.Size(37, 20)
        Me.abnormallv.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(140, 16)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(75, 13)
        Me.Label27.TabIndex = 55
        Me.Label27.Text = "abnormal_time"
        '
        'abnormaltime
        '
        Me.abnormaltime.Location = New System.Drawing.Point(217, 13)
        Me.abnormaltime.Name = "abnormaltime"
        Me.abnormaltime.Size = New System.Drawing.Size(37, 20)
        Me.abnormaltime.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.affectscope)
        Me.GroupBox3.Controls.Add(Me.affectobject)
        Me.GroupBox3.Controls.Add(Me.affectrange)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Location = New System.Drawing.Point(418, 213)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(239, 67)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Range scope"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.fanrange)
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Location = New System.Drawing.Point(418, 286)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(200, 44)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Fan_range"
        '
        'fanrange
        '
        Me.fanrange.Location = New System.Drawing.Point(66, 18)
        Me.fanrange.Name = "fanrange"
        Me.fanrange.Size = New System.Drawing.Size(116, 20)
        Me.fanrange.TabIndex = 0
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(9, 21)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(55, 13)
        Me.Label26.TabIndex = 50
        Me.Label26.Text = "fan_range"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(290, 16)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(68, 13)
        Me.Label33.TabIndex = 55
        Me.Label33.Text = "hp_consume"
        '
        'hp
        '
        Me.hp.Location = New System.Drawing.Point(318, 39)
        Me.hp.Name = "hp"
        Me.hp.Size = New System.Drawing.Size(37, 20)
        Me.hp.TabIndex = 2
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.mp_summ)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.Label33)
        Me.GroupBox5.Controls.Add(Me.hp)
        Me.GroupBox5.Controls.Add(Me.mp1)
        Me.GroupBox5.Controls.Add(Me.mp2)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.itemconsume)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Location = New System.Drawing.Point(13, 85)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(361, 69)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Consume"
        '
        'mp_summ
        '
        Me.mp_summ.Location = New System.Drawing.Point(244, 13)
        Me.mp_summ.Name = "mp_summ"
        Me.mp_summ.ReadOnly = True
        Me.mp_summ.Size = New System.Drawing.Size(39, 20)
        Me.mp_summ.TabIndex = 56
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(287, 163)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(91, 13)
        Me.Label34.TabIndex = 58
        Me.Label34.Text = "unavailable_cond"
        '
        'unavcond
        '
        Me.unavcond.Location = New System.Drawing.Point(381, 160)
        Me.unavcond.Name = "unavcond"
        Me.unavcond.Size = New System.Drawing.Size(181, 20)
        Me.unavcond.TabIndex = 10
        '
        'SkillOutBox
        '
        Me.SkillOutBox.Location = New System.Drawing.Point(11, 346)
        Me.SkillOutBox.Multiline = True
        Me.SkillOutBox.Name = "SkillOutBox"
        Me.SkillOutBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.SkillOutBox.Size = New System.Drawing.Size(673, 104)
        Me.SkillOutBox.TabIndex = 59
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(90, 316)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 60
        Me.StartButton.Text = "Start"
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(333, 316)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(75, 23)
        Me.QuitButton.TabIndex = 61
        Me.QuitButton.Text = "Quit"
        '
        'ClearButton
        '
        Me.ClearButton.Location = New System.Drawing.Point(247, 316)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(75, 23)
        Me.ClearButton.TabIndex = 62
        Me.ClearButton.Text = "Clear"
        '
        'ImportButton
        '
        Me.ImportButton.Location = New System.Drawing.Point(11, 316)
        Me.ImportButton.Name = "ImportButton"
        Me.ImportButton.Size = New System.Drawing.Size(75, 23)
        Me.ImportButton.TabIndex = 63
        Me.ImportButton.Text = "Import"
        '
        'comment
        '
        Me.comment.Location = New System.Drawing.Point(304, 32)
        Me.comment.Name = "comment"
        Me.comment.Size = New System.Drawing.Size(380, 20)
        Me.comment.TabIndex = 64
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(246, 35)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(54, 13)
        Me.Label35.TabIndex = 65
        Me.Label35.Text = "Comment:"
        '
        'AutoClear
        '
        Me.AutoClear.AutoSize = True
        Me.AutoClear.Checked = True
        Me.AutoClear.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AutoClear.Location = New System.Drawing.Point(171, 320)
        Me.AutoClear.Name = "AutoClear"
        Me.AutoClear.Size = New System.Drawing.Size(74, 17)
        Me.AutoClear.TabIndex = 66
        Me.AutoClear.Text = "Auto clear"
        '
        'SkillEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 462)
        Me.Controls.Add(Me.AutoClear)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.comment)
        Me.Controls.Add(Me.ImportButton)
        Me.Controls.Add(Me.ClearButton)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.SkillOutBox)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.unavcond)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.nextaction)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.targettype)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.effectpoint)
        Me.Controls.Add(Me.attribute)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.effectrange)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.castrange)
        Me.Controls.Add(Me.ismagic)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.operatecond)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.effect)
        Me.Controls.Add(Me.operatetype)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.magiclevel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.skilllevel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.skillid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.skillname)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SkillEditor"
        Me.Text = "SkillEditor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents skillname As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents skillid As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents skilllevel As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents magiclevel As System.Windows.Forms.TextBox
    Friend WithEvents operatetype As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents effect As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents operatecond As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents mp1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents itemconsume As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ismagic As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents mp2 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents castrange As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents effectrange As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents skillhittime As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents reusedelay As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents skillcooltime As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents skillhitcanceltime As System.Windows.Forms.TextBox
    Friend WithEvents attribute As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents effectpoint As System.Windows.Forms.TextBox
    Friend WithEvents targettype As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents affectscope As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents nextaction As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents affectrange As System.Windows.Forms.TextBox
    Friend WithEvents affectobject As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents abnormaltype As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents fanrange As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents abnormallv As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents abnormaltime As System.Windows.Forms.TextBox
    Friend WithEvents basicprop As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lvbonusrate As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents activaterate As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents abnormalviseffect As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents hp As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents unavcond As System.Windows.Forms.TextBox
    Friend WithEvents SkillOutBox As System.Windows.Forms.TextBox
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents QuitButton As System.Windows.Forms.Button
    Friend WithEvents ClearButton As System.Windows.Forms.Button
    Friend WithEvents ImportButton As System.Windows.Forms.Button
    Friend WithEvents comment As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents AutoClear As System.Windows.Forms.CheckBox
    Friend WithEvents mp_summ As System.Windows.Forms.TextBox
End Class
