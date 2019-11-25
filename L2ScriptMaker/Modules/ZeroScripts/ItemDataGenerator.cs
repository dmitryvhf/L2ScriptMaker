using System;
using System.Windows.Forms;
using L2ScriptMaker.Extensions;
using L2ScriptMaker.Extensions.VbCompatibleHelper;

namespace L2ScriptMaker.Modules.ZeroScripts
{
	public partial class ItemDataGenerator : Form
	{
		public ItemDataGenerator()
		{
			InitializeComponent();
		}

		private struct ItemBone
		{
			public int id;
			public string name;
			public string namepch;
			public string item_type;         // where found - same type armorgrp (armor), etcitemgrp (etcitem), recipe-e (etcitem), weapongrp (weapon)
			public string slot_bit_type;     // weapongrp, armorgrp
			public string armor_type;        // armorgrp.txt
			public string etcitem_type;      // etcitemgrp.txt
			public int recipe_id;         // recipe-e.txt
			public int blessed;
			public int weight;            // everywhere
			public string default_action;
			public string consume_type;
			public int initial_count;
			public int maximum_count;
			public int soulshot_count;    // weapongrp
			public int spiritshot_count;  // weapongrp
			public string reduced_soulshot;
			public string reduced_spiritshot;
			public string reduced_mp_consume;
			public int immediate_effect;
			public int price;
			public int default_price;
			public string item_skill;
			public string critical_attack_skill;
			public string attack_skill;
			public string magic_skill;
			public string item_skill_enchanted_four;
			public string material_type;             // everywhere
			public string crystal_type;             // everywhere
			public int crystal_count;
			public int is_trade;
			public int is_drop;
			public int is_destruct;
			public int physical_damage;
			public int random_damage;
			public string weapon_type;
			public int can_penetrate;
			public int critical;
			public double hit_modify;
			public int avoid_modify;
			public int dual_fhit_rate;
			public int shield_defense;
			public int shield_defense_rate;
			public int attack_range;
			public string damage_range;
			public int attack_speed;
			public int reuse_delay;
			public int mp_consume;
			public int magical_damage;
			public int durability;
			public int damaged;
			public int physical_defense;
			public int magical_defense;
			public int mp_bonus;
			public string category;
			public int enchanted;
			public string html;
			public string equip_pet;
			public int magic_weapon;
			public int enchant_enable;
			public int can_equip_sex;
			public string can_equip_race;
			public int can_equip_change_class;
			public string can_equip_class;
			public int can_equip_agit;
			public int can_equip_castle;
			public string can_equip_castle_num;
			public int can_equip_clan_leader;
			public int can_equip_clan_level;
			public int can_equip_hero;
			public int can_equip_nobless;
			public int can_equip_chaotic;
		}

		private struct ItemSet
		{
			// Dim ChestId As String       'id=2414	
			// Dim ItemList As String      'set_ids={2381,2417,5722,5738}
			public string SetName;       // name=[Doom Plate Armor]	add_name=[]	description=[Full body armor.]
			public string SetDescription;    // description=[Full body armor.]
			public string SetBonusDesc;    // set_bonus_desc=[Maximum HP +320, Breath Gauge increase, STR-3, and CON+3.]
										   // Dim ItemAdd As String           'set_extra_id=[110]
			public string SetExtraDesc;       // set_extra_desc=[Shield Def +24%.]
			public string SetSpecEnchDesc;       // special_enchant_desc=[a,When all set items are enchanted by 6 or higher, P. Def. and MP regeneration rate will increase.\0]	
		}

		private void StartButton_Click(object sender, EventArgs e)
		{


			// On Error GoTo ErrorScreener

			// Loading known DataBase
			var EtcitemType = new string[28];
			EtcitemType[0] = "none";
			EtcitemType[1] = "scroll";
			EtcitemType[2] = "arrow";
			EtcitemType[3] = "potion";
			EtcitemType[4] = "spellbook";    // C6
			EtcitemType[5] = "recipe";
			EtcitemType[6] = "material";
			EtcitemType[7] = "pet_collar";
			EtcitemType[8] = "castle_guard";
			EtcitemType[9] = "dye";
			EtcitemType[10] = "seed";
			EtcitemType[11] = "seed2";
			EtcitemType[12] = "harvest";
			EtcitemType[13] = "lotto";
			EtcitemType[14] = "race_ticket";
			EtcitemType[15] = "ticket_of_lord";
			EtcitemType[16] = "lure";
			EtcitemType[26] = "bolt";
			// Unknown
			// EtcitemType(0) = "maturecrop"
			// EtcitemType(0) = "crop"
			// EtcitemType(0) = "bless_scrl_enchant_wp"
			// EtcitemType(0) = "scrl_enchant_am"
			// EtcitemType(0) = "bless_scrl_enchant_am"
			// EtcitemType(0) = "scrl_enchant_wp"

			// item_type
			var EtcitemDropAnimType = new string[7];
			EtcitemDropAnimType[0] = "questitem";
			EtcitemDropAnimType[1] = "questitem";
			EtcitemDropAnimType[3] = "etcitem";
			EtcitemDropAnimType[5] = "asset";
			var ArmorGrpDropAnimType = new string[5];
			ArmorGrpDropAnimType[0] = "accessary"; // ""   'armor for pets ?
			ArmorGrpDropAnimType[2] = "armor";       // armor_sigil
			ArmorGrpDropAnimType[3] = "armor";
			var WeaponGrpDropAnimType = new string[5];
			WeaponGrpDropAnimType[0] = "weapon"; // weapon for pets
			WeaponGrpDropAnimType[1] = "weapon";
			WeaponGrpDropAnimType[2] = "armor";
			WeaponGrpDropAnimType[3] = "weapon";

			// timetab<>"[]" durablity<>-1
			// WeaponGrpDropAnimType(4) = "shadowitem"

			// armor_type=none	
			var ArmorGrpType = new string[5];
			ArmorGrpType[0] = "none";
			ArmorGrpType[1] = "light";
			ArmorGrpType[2] = "heavy";
			ArmorGrpType[3] = "magic";
			ArmorGrpType[4] = "sigil";

			// body_part -> slot_bit_type
			// slot_bit_type={none}	
			var ArmorGrpSlotBitType = new string[29];
			ArmorGrpSlotBitType[0] = "{underwear}";          // CT23
			ArmorGrpSlotBitType[1] = "{rear;lear}";          // CT23
			ArmorGrpSlotBitType[3] = "{neck}";               // CT23
			ArmorGrpSlotBitType[4] = "{rfinger;lfinger}";    // CT23
			ArmorGrpSlotBitType[6] = "{head}";               // CT23
			ArmorGrpSlotBitType[8] = "{onepiece}";           // CT23
			ArmorGrpSlotBitType[9] = "{alldress}";           // CT23
			ArmorGrpSlotBitType[10] = "{lrhair}";            // CT23
															 // ArmorGrpSlotBitType(11) = "{legs}"
															 // ArmorGrpSlotBitType(12) = "{feet}"
															 // ArmorGrpSlotBitType(13) = "{back}"
															 // ArmorGrpSlotBitType(15) = "{onepiece}"
															 // ArmorGrpSlotBitType(16) = "{alldress}"
															 // ArmorGrpSlotBitType(17) = "{hair}"
															 // ArmorGrpSlotBitType(18) = "{lrhair}"    'cat_ear {hair2}
			ArmorGrpSlotBitType[19] = "{belt}";              // CT23
															 // CT23
			ArmorGrpSlotBitType[20] = "{gloves}";            // CT23
			ArmorGrpSlotBitType[21] = "{chest}";             // CT23
			ArmorGrpSlotBitType[22] = "{legs}";              // CT23
			ArmorGrpSlotBitType[23] = "{feet}";              // CT23
			ArmorGrpSlotBitType[24] = "{back}";              // CT23
			ArmorGrpSlotBitType[25] = "{rhair}";             // CT23
			ArmorGrpSlotBitType[26] = "{lhair}";             // CT23
			ArmorGrpSlotBitType[28] = "{lhand}";             // CT23
															 // ArmorGrpSlotBitType(610) = "{talisman}"         'CT23   (175609600, 178018768, 339848760)
															 // ArmorGrpSlotBitType(611) = "{rbracelet}"         'CT23
															 // ArmorGrpSlotBitType(612) = "{lbracelet}"         'CT23  (33194848, 33268176)

			var WeaponGrpSlotBitType = new string[29];
			WeaponGrpSlotBitType[0] = "{rhand}"; // weapon for pets
			WeaponGrpSlotBitType[7] = "{lrhand}";             // CT23
															  // WeaponGrpSlotBitType(8) = "{lhand}"
															  // WeaponGrpSlotBitType(14) = "{lrhand}"
			WeaponGrpSlotBitType[27] = "{rhand}";             // CT23
			WeaponGrpSlotBitType[28] = "{lhand}";             // CT23

			var EtcitemCrystalType = new string[9];
			EtcitemCrystalType[0] = "none";
			EtcitemCrystalType[1] = "d";
			EtcitemCrystalType[2] = "c";
			EtcitemCrystalType[3] = "b";
			EtcitemCrystalType[4] = "a";
			EtcitemCrystalType[5] = "s";
			EtcitemCrystalType[6] = "s80";
			EtcitemCrystalType[7] = "s84";
			EtcitemCrystalType[8] = "s84";   // ="event" 13539	[staff_of_master_yogi]
											 // crystal_free

			// material -> material_type
			var EtcitemMaterial = new string[61];
			EtcitemMaterial[0] = "fish";
			EtcitemMaterial[1] = "oriharukon";
			EtcitemMaterial[2] = "mithril";
			EtcitemMaterial[3] = "gold";
			EtcitemMaterial[4] = "silver";
			EtcitemMaterial[5] = "brass";          // C6
			EtcitemMaterial[6] = "bronze";
			EtcitemMaterial[5] = "diamond";       // C6
			EtcitemMaterial[8] = "steel";
			EtcitemMaterial[9] = "damascus_steel";       // C6
			EtcitemMaterial[10] = "bone_of_dragon";       // C6
			EtcitemMaterial[11] = "air";       // C6
			EtcitemMaterial[12] = "water";       // C6
			EtcitemMaterial[13] = "wood";
			EtcitemMaterial[14] = "bone";
			EtcitemMaterial[15] = "branch_of_orbis_arbor";       // C6
			EtcitemMaterial[16] = "branch_of_worldtree";       // C6
			EtcitemMaterial[17] = "cloth";
			EtcitemMaterial[18] = "paper";
			EtcitemMaterial[19] = "leather";
			EtcitemMaterial[20] = "skull";       // C6
			EtcitemMaterial[21] = "feather";     // C6
			EtcitemMaterial[22] = "sand";        // C6
			EtcitemMaterial[23] = "crystal";
			EtcitemMaterial[24] = "fur";         // C6
			EtcitemMaterial[25] = "parchment";        // C6
			EtcitemMaterial[26] = "eyeball";        // C6
			EtcitemMaterial[27] = "insect";        // C6
			EtcitemMaterial[28] = "corpse";        // C6
			EtcitemMaterial[29] = "crow";        // C6
			EtcitemMaterial[30] = "hatching_egg";        // C6
			EtcitemMaterial[31] = "skull_of_wyvern";        // C6
			EtcitemMaterial[32] = "drug";
			EtcitemMaterial[33] = "cotton";
			EtcitemMaterial[34] = "silk";                // C6
			EtcitemMaterial[35] = "wool";                // C6
			EtcitemMaterial[36] = "flax";                  // C6
			EtcitemMaterial[37] = "cobweb";
			EtcitemMaterial[38] = "dyestuff";
			EtcitemMaterial[39] = "leather_of_puma";       // C6
			EtcitemMaterial[40] = "leather_of_lion";       // C6
			EtcitemMaterial[41] = "leather_of_manticore";  // C6
			EtcitemMaterial[42] = "leather_of_drake";    // C6
			EtcitemMaterial[43] = "leather_of_salamander";   // C6
			EtcitemMaterial[44] = "leather_of_unicorn";  // C6
			EtcitemMaterial[45] = "leather_of_dragon";   // C6
			EtcitemMaterial[46] = "scale_of_dragon";
			EtcitemMaterial[47] = "adamantaite";
			EtcitemMaterial[48] = "blood_steel";
			EtcitemMaterial[49] = "chrysolite";
			EtcitemMaterial[50] = "damascus";
			EtcitemMaterial[51] = "fine_steel";
			EtcitemMaterial[52] = "horn";
			EtcitemMaterial[53] = "liquid";

			var EtcitemStackable = new string[7];
			EtcitemStackable[0] = "consume_type_normal";
			// EtcitemStackable(1) = "consume_type_charge"  ' C6 '1141 [q_rusted_bronze_sword2] Only one item
			EtcitemStackable[2] = "consume_type_stackable";
			EtcitemStackable[3] = "consume_type_asset";     // adenas

			// weapon_type -> weapon_type
			var WeaponGrpWeaponType = new string[16];
			WeaponGrpWeaponType[0] = "none";
			WeaponGrpWeaponType[1] = "sword";
			WeaponGrpWeaponType[2] = "blunt";
			WeaponGrpWeaponType[3] = "dagger";
			WeaponGrpWeaponType[4] = "pole";     // etc ??
			WeaponGrpWeaponType[5] = "fist";     // handness=3
												 // WeaponGrpWeaponType(5) = "dualfist" 'handness=7
			WeaponGrpWeaponType[6] = "bow";
			WeaponGrpWeaponType[7] = "etc";
			WeaponGrpWeaponType[8] = "dual";  // handness=1
											  // WeaponGrpWeaponType(8) = "dual" 'handness=3
											  // WeaponGrpWeaponType(8) = "dualfist" 'handness=7
			WeaponGrpWeaponType[10] = "fishingrod";
			WeaponGrpWeaponType[11] = "rapier";
			WeaponGrpWeaponType[12] = "crossbow";
			WeaponGrpWeaponType[13] = "ancientsword";
			WeaponGrpWeaponType[15] = "dualdagger";

			// ----------------------------------------------


			var ItemData = new ItemBone[15001];
			var ItemSets = new ItemSet[1];

			// itemname_begin	id=9141	name=[Redemption Bow]	add_name=[]	description=[Zaken's Curse event item.  Enables you to free cursed pigs.  Allows you to use the active skills Forgiveness and Pardon.  ]	popup=-1	set_ids={}	set_bonus_desc=[]	set_extra_id=[]	set_extra_desc=[]	unk[0]=0	unk[1]=0	special_enchant_amount=0	special_enchant_desc=[]	itemname_end
			string sItemNameFile = "itemname-e.txt";      // Name/path of itemname-e.txt file
			string sEtcitemGrpFile = "etcitemgrp.txt";      // Name/path of etcitemgrp.txt file
			string sRecipeFile = "recipe-c.txt";      // Name/path of recipe-c.txt file
			string sArmorGrpFile = "armorgrp.txt";       // Name/path of armorgrp.txt file
			string sWeaponGrpFile = "weapongrp.txt";      // Name/path of weapongrp.txt file
			string sItemDataFile = "itemdata.txt";

			// ExistPchCheckBox

			// skillgrp_begin	skill_id=1398	skill_level=101	oper_type=0	mp_consume=103	cast_range=900	cast_style=1	hit_time=4.000000	is_magic=1	ani_char=[f]	desc=[skill.su.1069]	icon_name=[icon.skill1398]	extra_eff=0	is_ench=1	ench_skill_id=10	hp_consume=0	UNK_0=9	UNK_1=11	skillgrp_end

			if (System.IO.File.Exists(sItemNameFile) == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Filter = "Lineage II client text file (itemname-e.txt)|itemname-e.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				sItemNameFile = OpenFileDialog.FileName;
			}

			if (System.IO.File.Exists(sEtcitemGrpFile) == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Filter = "Lineage II client text file (etcitemgrp.txt)|etcitemgrp.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				sEtcitemGrpFile = OpenFileDialog.FileName;
			}

			if (System.IO.File.Exists(sRecipeFile) == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Filter = "Lineage II client text file (recipe-c.txt)|recipe-c.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				sRecipeFile = OpenFileDialog.FileName;
			}

			if (System.IO.File.Exists(sArmorGrpFile) == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Filter = "Lineage II client text file (armorgrp.txt)|armorgrp.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				sArmorGrpFile = OpenFileDialog.FileName;
			}

			if (System.IO.File.Exists(sWeaponGrpFile) == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Filter = "Lineage II client text file (weapongrp.txt)|weapongrp.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				sWeaponGrpFile = OpenFileDialog.FileName;
			}

			SaveFileDialog.FileName = sItemDataFile;
			SaveFileDialog.Filter = "Lineage II server enchant skill script (itemdata.txt)|itemdata*.txt|All files|*.*";
			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sItemDataFile = SaveFileDialog.FileName;


			System.IO.StreamReader inFile;
			string sTemp = "";
			string sTemp2;
			int iTemp;
			// Dim iId As Integer

			// ---- Loading 'Skillname-e.txt' ---- 
			inFile = new System.IO.StreamReader(sItemNameFile, true);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading itemname-e.txt...";

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{

					// itemname_begin	id=9141	name=[Redemption Bow]	add_name=[]	description=[Zaken's Curse event item.  Enables you to free cursed pigs.  Allows you to use the active skills Forgiveness and Pardon.  ]	popup=-1	set_ids={}	set_bonus_desc=[]	set_extra_id=[]	set_extra_desc=[]	unk[0]=0	unk[1]=0	special_enchant_amount=0	special_enchant_desc=[]	itemname_end
					iTemp = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "id"));

					if (iTemp >= ItemData.Length)
						Array.Resize(ref ItemData, iTemp + 1);
					ItemData[iTemp].name = Libraries.GetNeedParamFromStr(sTemp, "name").Replace("[", "").Replace("]", "");
					if ((Libraries.GetNeedParamFromStr(sTemp, "add_name") ?? "") != "[]")
						ItemData[iTemp].name = ItemData[iTemp].name + "_" + Libraries.GetNeedParamFromStr(sTemp, "add_name").Replace("[", "").Replace("]", "");
					sTemp2 = ItemData[iTemp].name.ToLower().Replace("'", "").Replace(",", "");
					sTemp2 = sTemp2.Replace("%", "").Replace("/", "").Replace("(", "").Replace(")", "").Replace("/", "_");
					sTemp2 = sTemp2.Replace("+", "").Replace("-", "").Replace("<", "").Replace(">", "").Replace("/", "_");
					sTemp2 = sTemp2.Replace(":", "").Replace(".", "").Replace("  ", " ").Replace(" ", "_").Replace("#", ""); // .Replace("*", "")
					sTemp2 = sTemp2.Replace("{", "").Replace("}", "");
					ItemData[iTemp].namepch = "[" + sTemp2 + "]";

					// SETTING DEFAULT PARAMS
					ItemData[iTemp].item_type = "etcitem";
					ItemData[iTemp].slot_bit_type = "{none}";
					ItemData[iTemp].armor_type = "none";
					ItemData[iTemp].etcitem_type = "etcitem";
					ItemData[iTemp].recipe_id = 0;
					ItemData[iTemp].blessed = 0;
					ItemData[iTemp].weight = 10000;
					ItemData[iTemp].default_action = "action_none";          // !!!! recipe -- action_recipe and etc
					ItemData[iTemp].consume_type = "consume_type_normal";
					ItemData[iTemp].initial_count = 1;
					ItemData[iTemp].maximum_count = 1;
					ItemData[iTemp].soulshot_count = 0;
					ItemData[iTemp].spiritshot_count = 0;
					ItemData[iTemp].reduced_soulshot = "{}";
					ItemData[iTemp].reduced_spiritshot = "{}";
					ItemData[iTemp].reduced_mp_consume = "{}";
					ItemData[iTemp].immediate_effect = 1;
					ItemData[iTemp].price = 0;
					ItemData[iTemp].default_price = 1;
					ItemData[iTemp].item_skill = "[none]";
					ItemData[iTemp].critical_attack_skill = "[none]";
					ItemData[iTemp].attack_skill = "[none]";
					ItemData[iTemp].magic_skill = "[none]";
					ItemData[iTemp].item_skill_enchanted_four = "[none]";
					ItemData[iTemp].material_type = "paper";
					ItemData[iTemp].crystal_type = "none";
					ItemData[iTemp].crystal_count = 0;
					ItemData[iTemp].is_trade = 1;
					ItemData[iTemp].is_drop = 1;
					ItemData[iTemp].is_destruct = 1;
					ItemData[iTemp].physical_damage = 0;
					ItemData[iTemp].random_damage = 0;
					ItemData[iTemp].weapon_type = "none";
					ItemData[iTemp].can_penetrate = 0;
					ItemData[iTemp].critical = 0;
					ItemData[iTemp].hit_modify = 0;
					ItemData[iTemp].avoid_modify = 0;
					ItemData[iTemp].dual_fhit_rate = 0;
					ItemData[iTemp].shield_defense = 0;
					ItemData[iTemp].shield_defense_rate = 0;
					ItemData[iTemp].attack_range = 0;
					ItemData[iTemp].damage_range = "{}";
					ItemData[iTemp].attack_speed = 0;
					ItemData[iTemp].reuse_delay = 0;
					ItemData[iTemp].mp_consume = 0;
					ItemData[iTemp].magical_damage = 0;
					ItemData[iTemp].durability = -1;
					ItemData[iTemp].damaged = 0;
					ItemData[iTemp].physical_defense = 0;
					ItemData[iTemp].magical_defense = 0;
					ItemData[iTemp].mp_bonus = 0;
					ItemData[iTemp].category = "{}";
					ItemData[iTemp].enchanted = 0;
					ItemData[iTemp].html = "[item_default.htm]";
					ItemData[iTemp].equip_pet = "{0}";
					ItemData[iTemp].magic_weapon = 0;
					ItemData[iTemp].enchant_enable = 0;
					ItemData[iTemp].can_equip_sex = -1;
					ItemData[iTemp].can_equip_race = "{}";
					ItemData[iTemp].can_equip_change_class = -1;
					ItemData[iTemp].can_equip_class = "{}";
					ItemData[iTemp].can_equip_agit = -1;
					ItemData[iTemp].can_equip_castle = -1;
					ItemData[iTemp].can_equip_castle_num = "{}";
					ItemData[iTemp].can_equip_clan_leader = -1;
					ItemData[iTemp].can_equip_clan_level = -1;
					ItemData[iTemp].can_equip_hero = -1;
					ItemData[iTemp].can_equip_nobless = -1;
					ItemData[iTemp].can_equip_chaotic = -1;

					// ' MADE SETS
					// Dim sSetInfo As String = Nothing
					iTemp = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "cnt0"));
					if (iTemp > 0)
					{
						iTemp = ItemSets.Length - 1;
						ItemSets[iTemp].SetName = Libraries.GetNeedParamFromStr(sTemp, "name");
						ItemSets[iTemp].SetDescription = Libraries.GetNeedParamFromStr(sTemp, "description");
						ItemSets[iTemp].SetBonusDesc = Libraries.GetNeedParamFromStr(sTemp, "set_bonus_desc");
						if (Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "cnt1")) > 0)
							ItemSets[iTemp].SetExtraDesc = Libraries.GetNeedParamFromStr(sTemp, "set_extra_desc");
						if (Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "special_enchant_amount")) > 0)
							ItemSets[iTemp].SetSpecEnchDesc = Libraries.GetNeedParamFromStr(sTemp, "special_enchant_desc");

						// ' set_ids={1101,1104,44}	set_bonus_desc=[Casting Spd. +15%.]	set_extra_id=[]	set_extra_desc=[]
						// ' set_ids={2381,2417,5722,5738}	set_bonus_desc=[Maximum HP +320, Breath Gauge increase, STR-3, and CON+3.]	set_extra_id=[110]	set_extra_desc=[Shield Def +24%.]

						// 'id=2381	name=[Doom Plate Armor]	add_name=[]	description=[Full body armor.]	popup=-1	
						// 'set_ids={2381,2417,5722,5738}	set_bonus_desc=[Maximum HP +320, Breath Gauge increase, STR-3, and CON+3.]
						// 'set_extra_id=[110]	set_extra_desc=[Shield Def +24%.]	unk[0]=0	unk[1]=0	
						// 'special_enchant_amount=6	special_enchant_desc=[When all set items are enchanted by 6 or higher, P. Def. and MP regeneration rate will increase.]	itemname_end
						// ItemSets(iTemp).ItemList = Libraries.GetNeedParamFromStr(sTemp, "set_ids").Replace("[", "").Replace("]", "")
						// ItemSets(iTemp).ChestId = Libraries.GetNeedParamFromStr(sTemp, "id")
						// ItemSets(iTemp).SetName = Libraries.GetNeedParamFromStr(sTemp, "name").Replace("[", "").Replace("]", "") & ". " & Libraries.GetNeedParamFromStr(sTemp, "description").Replace("[", "").Replace("]", "")
						// ItemSets(iTemp).SetDescription = Libraries.GetNeedParamFromStr(sTemp, "set_bonus_desc").Replace("[", "").Replace("]", "")
						// If ItemSets(iTemp).SetDescription <> "" Then
						// ItemSets(iTemp).SetName = ItemSets(iTemp).SetName & " " & ItemSets(iTemp).SetDescription
						// End If
						// ItemSets(iTemp).ItemAdd = Libraries.GetNeedParamFromStr(sTemp, "set_extra_id").Replace("[", "").Replace("]", "")
						// ItemSets(iTemp).ItemAddDesc = Libraries.GetNeedParamFromStr(sTemp, "set_extra_desc").Replace("[", "").Replace("]", "")
						// 'If ItemSets(iTemp).ItemAdd = "[]" Then ItemSets(iTemp).ItemAdd = "[none]"
						Array.Resize(ref ItemSets, ItemSets.Length + 1);
					}
				}
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				StatusStrip.Update();
			}
			ToolStripProgressBar.Value = 0;
			inFile.Close();
			this.Refresh();


			// ---- Loading 'etcitemgrp.txt' ---- 
			inFile = new System.IO.StreamReader(sEtcitemGrpFile, true);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading etcitemgrp.txt...";

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{

					// etcitemgrp_begin	tag=2	id=17	drop_type=0	drop_anim_type=3	drop_radius=8	drop_height=4	UNK_0=0	drop_mesh=[dropitems.drop_quiver_m00]	drop_tex=[]	icon[0]=[]	icon[1]=[dropitemstex.drop_quiver_t00]	icon[2]=[]	icon[3]=[]	icon[4]=[icon.etc_wooden_quiver_i00]	icon[5]=[]	icon[6]=[]	icon[7]=[]	icon[8]=[]	durability=4294967295	weight=6	material=13	crystallizable=0	type1=0	mesh_tex_pair_cntm=1	mesh_tex_pair_m[0]=[LineageWeapons.wooden_arrow_m00_et]	mesh_tex_pair_cntt=1	mesh_tex_pair_t[0]=[LineageWeaponsTex.wooden_arrow_t00_et]	item_sound=[ItemSound.itemdrop_arrow]	equip_sound=[]	stackable=2	family=2	grade=0	etcitemgrp_end
					iTemp = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "id"));

					if (string.IsNullOrEmpty(ItemData[iTemp].name))
					{
						MessageBox.Show("Found unknown ID. You must do update for your itemdata-e, because etcitemgrp item_id not defined in itemname-e", "Unknown ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
						inFile.Close();
						return;
					}

					// ItemData(iTemp).namepch = ItemData(iTemp).namepch.Replace("[", "[rp_")
					ItemData[iTemp].item_type = EtcitemDropAnimType[Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "drop_anim_type"))];
					if (Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "drop_anim_type")) < 2)
						ItemData[iTemp].namepch = ItemData[iTemp].namepch.Replace("[", "[q_");

					ItemData[iTemp].slot_bit_type = "{none}";
					ItemData[iTemp].armor_type = "none";
					try
					{
						ItemData[iTemp].etcitem_type = EtcitemType[Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "family"))];
					}
					catch (Exception ex)
					{
						if (Conversions.Val(Libraries.GetNeedParamFromStr(sTemp, "family")) > 25)
							ItemData[iTemp].etcitem_type = "none";
						else
							MessageBox.Show("Wrong EctipemTime for..." + Constants.vbNewLine + sTemp, "Wrong EctipemTime", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					if ((ItemData[iTemp].etcitem_type ?? "") == "arrow")
						ItemData[iTemp].slot_bit_type = "{lhand}";

					// Checking for Exceptions! 
					// scrl_enchant_wp, scrl_enchant_am, bless_scrl_enchant_wp, bless_scrl_enchant_am, crop, maturecrop

					if (EnchCropCheckBox.Checked == true)
					{
						// 729, 947, 951, 955, 959    scrl_enchant_wp
						// 730, 948, 952, 956, 960    scrl_enchant_am
						// 6569, 6571, 6573, 6575, 6577   bless_scrl_enchant_wp
						// 6570, 6572, 6574, 6576, 6578   bless_scrl_enchant_am

						// etcitem_type = scrl_inc_enchant_prop_wp
						// etcitem_type = scrl_inc_enchant_prop_am

						if (iTemp == 729 | iTemp == 947 | iTemp == 951 | iTemp == 955 | iTemp == 959)
							ItemData[iTemp].etcitem_type = "scrl_enchant_wp";
						if (iTemp == 730 | iTemp == 948 | iTemp == 952 | iTemp == 956 | iTemp == 960)
							ItemData[iTemp].etcitem_type = "scrl_enchant_am";
						if (iTemp == 6569 | iTemp == 6571 | iTemp == 6573 | iTemp == 6575 | iTemp == 6577)
							ItemData[iTemp].etcitem_type = "bless_scrl_enchant_wp";
						if (iTemp == 6570 | iTemp == 6572 | iTemp == 6574 | iTemp == 6576 | iTemp == 6578)
							ItemData[iTemp].etcitem_type = "bless_scrl_enchant_am";

						// crop
						// maturecrop

						// if (iTemp == 6555) int ajshd = 12;

						if (Strings.InStr(ItemData[iTemp].namepch, "seed") == 0 & (ItemData[iTemp].etcitem_type ?? "") != "seed")
						{
							if (ItemData[iTemp].namepch.EndsWith("_coba]") == true | ItemData[iTemp].namepch.EndsWith("_cobol]") == true | ItemData[iTemp].namepch.EndsWith("_codran]") == true | ItemData[iTemp].namepch.EndsWith("_coda]") == true)
							{
								ItemData[iTemp].namepch = ItemData[iTemp].namepch.Replace("[q_", "[");
								ItemData[iTemp].item_type = "etcitem";
								if (ItemData[iTemp].namepch.StartsWith("[mature_") == true | ItemData[iTemp].namepch.StartsWith("[ripe_") == true)
									ItemData[iTemp].etcitem_type = "maturecrop";
								else
									ItemData[iTemp].etcitem_type = "crop";
							}
						}
						else
							ItemData[iTemp].namepch = ItemData[iTemp].namepch.Replace("[q_", "[");
					}

					ItemData[iTemp].recipe_id = 0;
					ItemData[iTemp].blessed = 0;
					ItemData[iTemp].weight = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "weight"));

					// action_none
					// action_equip
					// action_recipe
					// action_skill_reduce
					// action_capsule
					// action_seed
					// action_show_html
					// action_spiritshot
					// action_skill_maintain
					// action_soulshot
					// action_fishingshot
					// action_dice
					// action_summon_spiritshot
					// action_show_ssq_status
					// action_summon_soulshot
					// action_calc
					// action_harvest
					// action_xmas_open

					// EtcitemType(0) = "none"
					// EtcitemType(1) = "scroll"
					// EtcitemType(2) = "arrow"
					// EtcitemType(3) = "potion"
					// EtcitemType(5) = "recipe"
					// EtcitemType(6) = "material"
					// EtcitemType(7) = "pet_collar"
					// EtcitemType(8) = "castle_guard"
					// EtcitemType(9) = "dye"
					// EtcitemType(10) = "seed"
					// EtcitemType(11) = "seed2"
					// EtcitemType(12) = "harvest"
					// EtcitemType(13) = "lotto"
					// EtcitemType(14) = "race_ticket"
					// EtcitemType(15) = "ticket_of_lord"
					// EtcitemType(16) = "lure"

					switch (ItemData[iTemp].etcitem_type)
					{
						case "scroll":
							{
								ItemData[iTemp].default_action = "action_skill_reduce";
								break;
							}

						case "arrow":
							{
								ItemData[iTemp].default_action = "action_equip";
								break;
							}

						case "potion":
							{
								ItemData[iTemp].default_action = "action_skill_reduce";
								ItemData[iTemp].equip_pet = "{@ALL_PET}";
								break;
							}

						case "pet_collar":
							{
								ItemData[iTemp].default_action = "action_skill_maintain";
								break;
							}

						case "seed":
							{
								ItemData[iTemp].default_action = "action_seed";
								ItemData[iTemp].item_type = "etcitem";
								break;
							}

						case "seed2":
							{
								ItemData[iTemp].default_action = "action_seed";
								ItemData[iTemp].item_type = "etcitem";
								break;
							}

						case "harvest":
							{
								ItemData[iTemp].default_action = "action_harvest";
								break;
							}

						case "lure":
							{
								ItemData[iTemp].namepch = ItemData[iTemp].namepch.Replace("[q_", "[");
								ItemData[iTemp].item_type = "etcitem";
								ItemData[iTemp].slot_bit_type = "{lhand}";
								ItemData[iTemp].default_action = "action_equip";
								break;
							}

						case "castle_guard":
							{
								ItemData[iTemp].namepch = ItemData[iTemp].namepch.Replace("[q_", "[");
								ItemData[iTemp].item_type = "etcitem";
								break;
							}

						case "scrl_enchant_wp":
							{
								ItemData[iTemp].default_action = "action_skill_reduce";
								break;
							}

						case "recipe":
							{
								ItemData[iTemp].default_action = "action_recipe";
								break;
							}

						default:
							{
								// @ALL_PET
								ItemData[iTemp].default_action = "action_none";          // !!!! recipe -- action_recipe and etc

								switch (iTemp)
								{
									case 5555:
										{
											ItemData[iTemp].default_action = "action_xmas_open"; // 5555 [x_mas_2004]
											ItemData[iTemp].item_type = "etcitem";
											break;
										}

									case 5707:
										{
											ItemData[iTemp].default_action = "action_show_ssq_status"; // 5707 [record_of_seven_sign]
											ItemData[iTemp].item_type = "etcitem";
											break;
										}

									case 5708   // 5708    [q_lord_of_the_manors_certificate_of_approval] 
							 :
										{
											// etcitem_type=ticket_of_lord
											ItemData[iTemp].item_type = "etcitem";
											break;
										}

									case 2515   // [food_for_wolves]
							 :
										{
											ItemData[iTemp].default_action = "action_skill_reduce";
											ItemData[iTemp].equip_pet = "{@pet_wolf_a;@sin_eater}";
											break;
										}
								}

								break;
							}
					}
					if (ItemData[iTemp].namepch.EndsWith("_spice]") == true)
					{
						// [pet_food_baby_spice], [golden_spice], [crystal_spice]
						ItemData[iTemp].default_action = "action_skill_reduce";
						ItemData[iTemp].equip_pet = "{0}";
					}

					if (Strings.InStr(ItemData[iTemp].namepch, "soulshot") != 0)
						ItemData[iTemp].default_action = "action_soulshot";
					if (Strings.InStr(ItemData[iTemp].namepch, "spiritshot") != 0)
						ItemData[iTemp].default_action = "action_spiritshot";
					if (Strings.InStr(ItemData[iTemp].namepch, "beast_soul") != 0)
					{
						ItemData[iTemp].default_action = "action_summon_soulshot";
						ItemData[iTemp].equip_pet = "{@ALL_PET}";
					}
					if (Strings.InStr(ItemData[iTemp].namepch, "beast_spirit") != 0)
					{
						ItemData[iTemp].default_action = "action_summon_spiritshot";
						ItemData[iTemp].equip_pet = "{@ALL_PET}";
					}
					if (Strings.InStr(ItemData[iTemp].namepch, "fishing_shot") != 0)
						ItemData[iTemp].default_action = "action_fishingshot";
					if (ItemData[iTemp].namepch.StartsWith("[dice") == true)
						ItemData[iTemp].default_action = "action_dice";
					if (ItemData[iTemp].namepch.StartsWith("[calculator") == true)
						ItemData[iTemp].default_action = "action_calc";

					ItemData[iTemp].consume_type = EtcitemStackable[Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "stackable"))];
					if ((ItemData[iTemp].consume_type ?? "") == "consume_type_stackable")
						// ItemData(iTemp).initial_count = 1
						ItemData[iTemp].maximum_count = 20;

					// ItemData(iTemp).soulshot_count = 0
					// ItemData(iTemp).spiritshot_count = 0
					// ItemData(iTemp).reduced_soulshot = "{}"
					// ItemData(iTemp).reduced_spiritshot = "{}"
					// ItemData(iTemp).reduced_mp_consume = "{}"
					// ItemData(iTemp).immediate_effect = 1
					// ItemData(iTemp).price = 0
					// ItemData(iTemp).default_price = 1
					// ItemData(iTemp).item_skill = "[none]"
					// ItemData(iTemp).critical_attack_skill = "[none]"
					// ItemData(iTemp).attack_skill = "[none]"
					// ItemData(iTemp).magic_skill = "[none]"
					// ItemData(iTemp).item_skill_enchanted_four = "[none]"
					try
					{
						ItemData[iTemp].material_type = EtcitemMaterial[Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "material"))];
					}
					catch (Exception ex)
					{
						ItemData[iTemp].material_type = "paper";
					}// EtcitemMaterial(18)
					if ((ItemData[iTemp].material_type ?? "") == "fish")
						ItemData[iTemp].default_action = "action_capsule";

					ItemData[iTemp].crystal_type = EtcitemCrystalType[Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "grade"))];
					// ItemData(iTemp).crystal_count = 0
					if ((ItemData[iTemp].item_type ?? "") == "questitem")
					{
						ItemData[iTemp].is_trade = 0;
						ItemData[iTemp].is_drop = 0;
					}
					// ItemData(iTemp).physical_damage = 0
					// ItemData(iTemp).random_damage = 0
					// ItemData(iTemp).weapon_type = "none"
					// ItemData(iTemp).can_penetrate = 0
					// ItemData(iTemp).critical = 0
					// ItemData(iTemp).hit_modify = 0
					// ItemData(iTemp).avoid_modify = 0
					// ItemData(iTemp).dual_fhit_rate = 0
					// ItemData(iTemp).shield_defense = 0
					// ItemData(iTemp).shield_defense_rate = 0
					// ItemData(iTemp).attack_range = 0
					// ItemData(iTemp).damage_range = "{}"
					// ItemData(iTemp).attack_speed = 0
					// ItemData(iTemp).reuse_delay = 0
					// ItemData(iTemp).mp_consume = 0
					// ItemData(iTemp).magical_damage = 0
					// ItemData(iTemp).durability = 0
					// ItemData(iTemp).damaged = 0
					// ItemData(iTemp).physical_defense = 0
					// ItemData(iTemp).magical_defense = 0
					// ItemData(iTemp).mp_bonus = 0
					// ItemData(iTemp).category = "{}"
					// ItemData(iTemp).enchanted = 0

					ItemData[iTemp].html = "[item_default.htm]";
					if ((ItemData[iTemp].html ?? "") != "[item_default.htm]")
						ItemData[iTemp].default_action = "action_show_html";
				}
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				StatusStrip.Update();
			}
			ToolStripProgressBar.Value = 0;
			inFile.Close();

			// ---- Loading 'Recipe-c.txt' ---- 
			inFile = new System.IO.StreamReader(sRecipeFile, true);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading recipe-c.txt...";

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{

					// recipe_begin	name=[mk_wooden_arrow]	id_mk=1	id_recipe=1666	level=1	id_item=17	count=500	mp_cost=30	success_rate=100	materials_cnt=2	materials_m[0]_id=1864	materials_m[0]_cnt=4	materials_m[1]_id=1869	materials_m[1]_cnt=2	materials_m[2]_id=	materials_m[2]_cnt=	materials_m[3]_id=	materials_m[3]_cnt=	materials_m[4]_id=	materials_m[4]_cnt=	materials_m[5]_id=	materials_m[5]_cnt=	materials_m[6]_id=	materials_m[6]_cnt=	materials_m[7]_id=	materials_m[7]_cnt=	materials_m[8]_id=	materials_m[8]_cnt=	materials_m[9]_id=	materials_m[9]_cnt=	recipe_end
					iTemp = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "id_recipe"));
					ItemData[iTemp].namepch = ItemData[iTemp].namepch.Replace("[", "[rp_");
					ItemData[iTemp].item_type = "etcitem";
					// ItemData(iTemp).slot_bit_type = "{none}"
					// ItemData(iTemp).armor_type = "none"
					ItemData[iTemp].etcitem_type = "recipe";
					ItemData[iTemp].recipe_id = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "id_mk"));
					// ItemData(iTemp).blessed = 0
					// ItemData(iTemp).weight = 30
					ItemData[iTemp].default_action = "action_recipe";
				}
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				StatusStrip.Update();
			}
			ToolStripProgressBar.Value = 0;
			inFile.Close();
			this.Refresh();


			// ---- Loading 'armorgrp.txt' ---- 
			inFile = new System.IO.StreamReader(sArmorGrpFile, true);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading armorgrp.txt...";

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{

					// armorgrp_begin	tag=1	id=21	drop_type=0	drop_anim_type=3	drop_radius=7	drop_height=0	UNK_0=0	durability=4294967295	weight=4830	material=17	crystallizable=0	UNK_1=0	body_part=10	UNK_2=1	UNK_3=0	armor_type=1	crystal_type=0	avoid_mod=0	pdef=36	mdef=0	mpbonus=0	armorgrp_end
					iTemp = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "id"));

					if (string.IsNullOrEmpty(ItemData[iTemp].name))
					{
						MessageBox.Show("Found unknown ID. You must do update for your itemdata-e, because etcitemgrp item_id not defined in itemname-e", "Unknown ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
						inFile.Close();
						return;
					}

					ItemData[iTemp].item_type = ArmorGrpDropAnimType[Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "drop_anim_type"))];

					// gracelet, talisman big value fix
					if (Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "body_part")) <= 28)
						ItemData[iTemp].slot_bit_type = ArmorGrpSlotBitType[Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "body_part"))];
					else
						ItemData[iTemp].slot_bit_type = "{none}";

					if (Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "body_part")) > 5)
						ItemData[iTemp].item_type = "armor";
					ItemData[iTemp].armor_type = ArmorGrpType[Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "armor_type"))];
					ItemData[iTemp].etcitem_type = "none";
					// ItemData(iTemp).recipe_id = CInt(Libraries.GetNeedParamFromStr(sTemp, "id_mk"))
					// ItemData(iTemp).blessed = 0
					ItemData[iTemp].weight = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "weight"));
					ItemData[iTemp].default_action = "action_equip";
					ItemData[iTemp].consume_type = "consume_type_normal";
					// ItemData(iTemp).initial_count = 1
					// ItemData(iTemp).maximum_count = 1
					// ItemData(iTemp).soulshot_count = 0
					// ItemData(iTemp).spiritshot_count = 0
					// ItemData(iTemp).reduced_soulshot = "{}"
					// ItemData(iTemp).reduced_spiritshot = "{}"
					// ItemData(iTemp).reduced_mp_consume = "{}"
					// ItemData(iTemp).immediate_effect = 1
					// ItemData(iTemp).price = 0
					// ItemData(iTemp).default_price = 1
					// ItemData(iTemp).item_skill = "[none]"
					// ItemData(iTemp).critical_attack_skill = "[none]"
					// ItemData(iTemp).attack_skill = "[none]"
					// ItemData(iTemp).magic_skill = "[none]"
					// ItemData(iTemp).item_skill_enchanted_four = "[none]"
					ItemData[iTemp].material_type = EtcitemMaterial[Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "material"))];
					ItemData[iTemp].crystal_type = EtcitemCrystalType[Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "crystal_type"))];
					if ((ItemData[iTemp].crystal_type ?? "") != "none")
						ItemData[iTemp].crystal_count = 1;
					// ItemData(iTemp).is_trade = 1
					// ItemData(iTemp).is_drop = 1
					// ItemData(iTemp).is_destruct = 1
					// ItemData(iTemp).physical_damage = 0
					// ItemData(iTemp).random_damage = 0
					// ItemData(iTemp).weapon_type = "none"
					// ItemData(iTemp).can_penetrate = 0
					// ItemData(iTemp).critical = 0
					// ItemData(iTemp).hit_modify = 0

					// ItemData(iTemp).avoid_modify = CInt(Libraries.GetNeedParamFromStr(sTemp, "avoid_mod"))
					if ((Libraries.GetNeedParamFromStr(sTemp, "avoid_mod") ?? "") == "0")
						ItemData[iTemp].avoid_modify = 0;
					else
						ItemData[iTemp].avoid_modify = -8;
					// ItemData(iTemp).dual_fhit_rate = 0
					// ItemData(iTemp).shield_defense = 0
					// ItemData(iTemp).shield_defense_rate = 0
					// ItemData(iTemp).attack_range = 0
					// ItemData(iTemp).damage_range = "{}"
					// ItemData(iTemp).attack_speed = 0
					// ItemData(iTemp).reuse_delay = 0
					// ItemData(iTemp).mp_consume = 0
					// ItemData(iTemp).magical_damage = 0
					ItemData[iTemp].durability = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "durability"));
					if (ItemData[iTemp].durability != -1)
					{
						ItemData[iTemp].crystal_count = 0;
						ItemData[iTemp].is_trade = 0;
						ItemData[iTemp].is_drop = 0;
					}
					// ItemData(iTemp).damaged = 0
					ItemData[iTemp].physical_defense = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "pdef"));
					ItemData[iTemp].magical_defense = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "mdef"));
					ItemData[iTemp].mp_bonus = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "mpbonus"));
					// ItemData(iTemp).category = "{}"
					// ItemData(iTemp).enchanted = 0
					// ItemData(iTemp).html = "[item_default.htm]"

					if (Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "drop_anim_type")) == 0)
						// Armor for Pets
						ItemData[iTemp].equip_pet = "{@pet_wolf_a;@wind_strider;@star_strider;@twilight_strider;@hatchling_of_wind;@hatchling_of_star;@hatchling_of_twilight}";

					// ItemData(iTemp).magic_weapon = 0
					if ((ItemData[iTemp].crystal_type ?? "") != "none")
						ItemData[iTemp].enchant_enable = 1;
				}
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				StatusStrip.Update();
			}
			ToolStripProgressBar.Value = 0;
			inFile.Close();
			this.Refresh();



			// ---- Loading 'weapongrp.txt' ---- 
			inFile = new System.IO.StreamReader(sWeaponGrpFile, true);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading weapongrp.txt...";

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{

					// weapon_type
					// handness=5
					// projectile
					// curvature=1000

					// weapongrp_begin	tag=0	id=1	drop_type=1	drop_anim_type=1	drop_radius=7	drop_height=15	UNK_0=0	durability=-1	weight=1600	material=8	crystallizable=0	projectile_?=0	body_part=7	handness=1	mt_pair_cntm=1	mt_pair_m[0]=LineageWeapons.small_sword_m00_wp	mt_pair_m[1]=	mt_pair_cntt=1	mt_pair_t[0]=LineageWeaponsTex.small_sword_t00_wp	mt_pair_t[1]=	mt_pair_t[2]=	item_sound_cnt=4	random_damage=10	patt=8	matt=6	weapon_type=1	crystal_type=0	critical=8	hit_mod=0	avoid_mod=0	shield_pdef=0	shield_rate=0	speed=379	mp_consume=0	SS_count=1	SPS_count=1	curvature=1000	UNK_2=0	is_hero=-1	UNK_3=0	effA=	effB=	junk1A[0]=0.000000	junk1A[1]=0.000000	junk1A[2]=0.000000	junk1A[3]=1.000000	junk1A[4]=1.000000	junk1B[0]=	junk1B[1]=	junk1B[2]=	junk1B[3]=	junk1B[4]=	rangeA=LineageWeapons.rangesample	rangeB=	junk2A[0]=0.950000	junk2A[1]=0.550000	junk2A[2]=0.550000	junk2A[3]=11.000000	junk2A[4]=0.000000	junk2A[5]=0.000000	junk2B[0]=	junk2B[1]=	junk2B[2]=	junk2B[3]=	junk2B[4]=	junk2B[5]=	junk3[0]=-1	junk3[1]=-1	junk3[2]=-1	junk3[3]=-1	icons[0]=	icons[1]=	icons[2]=	icons[3]=	weapongrp_end
					iTemp = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "id"));
					if (string.IsNullOrEmpty(ItemData[iTemp].name))
					{
						MessageBox.Show("Found unknown ID. You must do update for your itemdata-e, because etcitemgrp item_id not defined in itemname-e", "Unknown ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
						inFile.Close();
						return;
					}

					ItemData[iTemp].item_type = WeaponGrpDropAnimType[Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "drop_anim_type"))];
					ItemData[iTemp].slot_bit_type = WeaponGrpSlotBitType[Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "body_part"))];
					// ItemData(iTemp).armor_type = "none"
					ItemData[iTemp].etcitem_type = "none";
					// ItemData(iTemp).recipe_id = CInt(Libraries.GetNeedParamFromStr(sTemp, "id_mk"))
					// ItemData(iTemp).blessed = 0
					ItemData[iTemp].weight = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "weight"));
					ItemData[iTemp].default_action = "action_equip";
					ItemData[iTemp].consume_type = "consume_type_normal";
					// ItemData(iTemp).initial_count = 1
					// ItemData(iTemp).maximum_count = 1
					ItemData[iTemp].soulshot_count = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "SS_count"));
					ItemData[iTemp].spiritshot_count = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "SPS_count"));
					// ItemData(iTemp).reduced_soulshot = "{}"
					// ItemData(iTemp).reduced_spiritshot = "{}"
					// ItemData(iTemp).reduced_mp_consume = "{}"
					// ItemData(iTemp).immediate_effect = 1
					// ItemData(iTemp).price = 0
					// ItemData(iTemp).default_price = 1
					// ItemData(iTemp).item_skill = "[none]"
					// ItemData(iTemp).critical_attack_skill = "[none]"
					// ItemData(iTemp).attack_skill = "[none]"
					// ItemData(iTemp).magic_skill = "[none]"
					// ItemData(iTemp).item_skill_enchanted_four = "[none]"
					ItemData[iTemp].material_type = EtcitemMaterial[Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "material"))];
					ItemData[iTemp].crystal_type = EtcitemCrystalType[Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "crystal_type"))];
					if ((ItemData[iTemp].crystal_type ?? "") != "none")
						ItemData[iTemp].crystal_count = 1;
					// ItemData(iTemp).is_trade = 1
					// ItemData(iTemp).is_drop = 1
					// ItemData(iTemp).is_destruct = 1
					ItemData[iTemp].physical_damage = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "patt"));
					ItemData[iTemp].random_damage = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "random_damage"));

					if (Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "weapon_type")) < 16)
						ItemData[iTemp].weapon_type = WeaponGrpWeaponType[Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "weapon_type"))];
					else
						ItemData[iTemp].weapon_type = "none";
					// WeaponGrpWeaponType(5) = "fist"     'handness=3
					// WeaponGrpWeaponType(5) = "dualfist" 'handness=7
					// WeaponGrpWeaponType(8) = "dual" 'handness=3
					// WeaponGrpWeaponType(8) = "dualfist" 'handness=7

					if ((Libraries.GetNeedParamFromStr(sTemp, "handness") ?? "") == "7")
					{
						if ((ItemData[iTemp].weapon_type ?? "") == "fist" | (ItemData[iTemp].weapon_type ?? "") == "dual")
							ItemData[iTemp].weapon_type = "dualfist";
					}

					// ItemData(iTemp).can_penetrate = 0  ' weapon  15      [short_spear] spear   weapon  71      [flamberge]
					if ((ItemData[iTemp].slot_bit_type ?? "") == "{lrhand}")
					{
						switch (ItemData[iTemp].weapon_type)
						{
							case "pole":
								{
									ItemData[iTemp].can_penetrate = 1;
									break;
								}

							case "sword":
								{
									ItemData[iTemp].can_penetrate = 1;
									break;
								}

							case "dual":
								{
									ItemData[iTemp].can_penetrate = 1;
									break;
								}

							case "ancientsword":
								{
									ItemData[iTemp].can_penetrate = 1;
									break;
								}
						}
					}

					ItemData[iTemp].critical = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "critical"));
					// 8
					// sword
					// pole
					// etc
					// fist
					// dual
					// 4
					// blunt
					// dualfist
					// 12
					// dagger
					// bow
					// 0
					// none
					// fishingrod

					// ItemData(iTemp).hit_modify = CInt(Libraries.GetNeedParamFromStr(sTemp, "hit_mod")) ' no work correcly. Do 4 but need 4.75, 3 - -3.75

					ItemData[iTemp].avoid_modify = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "avoid_mod"));
					// ItemData(iTemp).dual_fhit_rate = 0     ' see in next block
					ItemData[iTemp].shield_defense = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "shield_pdef"));
					ItemData[iTemp].shield_defense_rate = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "shield_rate"));

					// Set Default Settings
					// ItemData(iTemp).hit_modify = 0
					ItemData[iTemp].attack_range = 40;
					ItemData[iTemp].damage_range = "{0;0;40;120}";
					switch (ItemData[iTemp].weapon_type)
					{
						case "none":
							{
								ItemData[iTemp].attack_range = 0;
								ItemData[iTemp].damage_range = "{}";
								break;
							}

						case "fist":
							{
								ItemData[iTemp].hit_modify = 4.75;
								break;
							}

						case "etc":
							{
								ItemData[iTemp].hit_modify = 4.75;
								break;
							}

						case "blunt":
							{
								ItemData[iTemp].hit_modify = 4.75;
								if ((ItemData[iTemp].slot_bit_type ?? "") == "{lrhand}")
									ItemData[iTemp].damage_range = "{0;0;46;120}";
								break;
							}

						case "dagger":
							{
								ItemData[iTemp].hit_modify = -3.75;
								break;
							}

						case "sword":
							{
								if ((ItemData[iTemp].slot_bit_type ?? "") == "{lrhand}")
									ItemData[iTemp].damage_range = "{0;0;44;120}";
								break;
							}

						case "dual":
							{
								ItemData[iTemp].dual_fhit_rate = 50;
								// ItemData(iTemp).attack_range = 40
								// ItemData(iTemp).damage_range = "{0;0;40;120}"
								if ((ItemData[iTemp].slot_bit_type ?? "") == "{lrhand}")
									ItemData[iTemp].damage_range = "{0;0;44;120}";
								break;
							}

						case "dualfist":
							{
								ItemData[iTemp].dual_fhit_rate = 50;
								// ItemData(iTemp).attack_range = 40
								ItemData[iTemp].hit_modify = 4.75;
								if ((ItemData[iTemp].slot_bit_type ?? "") == "{lrhand}")
									ItemData[iTemp].damage_range = "{0;0;44;90}";
								else
									ItemData[iTemp].damage_range = "{0;0;32;120}";
								break;
							}

						case "pole":
							{
								ItemData[iTemp].hit_modify = -3.75;
								ItemData[iTemp].attack_range = 80;
								ItemData[iTemp].damage_range = "{0;0;66;120}";
								break;
							}

						case "fishingrod":
							{
								ItemData[iTemp].hit_modify = -3.75;
								ItemData[iTemp].attack_range = 80;
								ItemData[iTemp].damage_range = "{0;0;66;120}";
								break;
							}

						case "bow":
							{
								ItemData[iTemp].hit_modify = -3.75;
								ItemData[iTemp].attack_range = 500;
								ItemData[iTemp].damage_range = "{0;0;10;0}";
								ItemData[iTemp].reuse_delay = 1500;
								break;
							}

						case "crossbow":
							{
								ItemData[iTemp].hit_modify = -3.75;
								ItemData[iTemp].attack_range = 500;
								ItemData[iTemp].damage_range = "{0;0;10;0}";
								ItemData[iTemp].reuse_delay = 820;
								break;
							}

						case "ancientsword":
							{
								ItemData[iTemp].damage_range = "{0;0;44;120}";
								break;
							}

						case "rapier":
							{
								ItemData[iTemp].damage_range = "{0;0;40;120}";
								break;
							}
					}

					if ((ItemData[iTemp].slot_bit_type ?? "") == "{lrhand}" & (Libraries.GetNeedParamFromStr(sTemp, "handness") ?? "") == "1")
						// Exception! This one hand weapon
						ItemData[iTemp].slot_bit_type = "{rhand}";

					ItemData[iTemp].attack_speed = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "speed"));
					// ItemData(iTemp).reuse_delay = 0
					ItemData[iTemp].mp_consume = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "mp_consume"));
					ItemData[iTemp].magical_damage = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "matt"));
					ItemData[iTemp].durability = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "durability"));    // ItemData(iTemp).durability = 0
																															   // ItemData(iTemp).damaged = 0
																															   // ItemData(iTemp).physical_defense = 0
																															   // ItemData(iTemp).magical_defense = 0
																															   // ItemData(iTemp).mp_bonus = 0
																															   // ItemData(iTemp).category = "{}"
																															   // ItemData(iTemp).enchanted = 0
																															   // ItemData(iTemp).html = "[item_default.htm]"

					switch (Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "body_part")))
					{
						case 0:
							{
								// @pet_wolf_a"
								// @wind_strider;@star_strider;@twilight_strider
								// @hatchling_of_wind;@hatchling_of_star;@hatchling_of_twilight
								ItemData[iTemp].equip_pet = "{@pet_wolf_a;@wind_strider;@star_strider;@twilight_strider;@hatchling_of_wind;@hatchling_of_star;@hatchling_of_twilight}";
								break;
							}
					}

					// ItemData(iTemp).magic_weapon = 0
					if ((ItemData[iTemp].crystal_type ?? "") != "none")
						ItemData[iTemp].enchant_enable = 1;
					// ItemData(iTemp).can_equip_sex = -1
					// ItemData(iTemp).can_equip_race = "{}"
					// ItemData(iTemp).can_equip_change_class = -1
					// ItemData(iTemp).can_equip_class = "{}"
					// ItemData(iTemp).can_equip_agit = -1
					// ItemData(iTemp).can_equip_castle = -1
					// ItemData(iTemp).can_equip_castle_num = "{}"
					// ItemData(iTemp).can_equip_clan_leader = -1
					// ItemData(iTemp).can_equip_clan_level = -1
					ItemData[iTemp].can_equip_hero = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "is_hero"));
				}
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				StatusStrip.Update();
			}
			ToolStripProgressBar.Value = 0;
			inFile.Close();
			this.Refresh();

			// ------- SAVING ITEMDATA.TXT -------
			if (System.IO.File.Exists(sItemDataFile) == true)
				System.IO.File.Copy(sItemDataFile, sItemDataFile + ".bak", true);
			var outFile = new System.IO.StreamWriter(sItemDataFile, false, System.Text.Encoding.Unicode, 1);

			ToolStripProgressBar.Maximum = ItemData.Length - 1;
			ToolStripStatusLabel.Text = "Saving itemdata.txt..."; StatusStrip.Refresh();
			var loopTo = ItemData.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				ToolStripProgressBar.Value = iTemp;

				if (!string.IsNullOrEmpty(ItemData[iTemp].name))
				{
					outFile.Write("item_begin" + Constants.vbTab);
					if (ItemData[iTemp].durability != -1)
						outFile.Write("shadowitem" + Constants.vbTab);
					else
						outFile.Write(ItemData[iTemp].item_type + Constants.vbTab);
					outFile.Write(Conversions.ToString(iTemp) + Constants.vbTab);
					outFile.Write(ItemData[iTemp].namepch + Constants.vbTab); // "[small_sword]"
					outFile.Write("item_type=" + ItemData[iTemp].item_type + Constants.vbTab);
					outFile.Write("slot_bit_type=" + ItemData[iTemp].slot_bit_type + Constants.vbTab);
					outFile.Write("armor_type=" + ItemData[iTemp].armor_type + Constants.vbTab);
					outFile.Write("etcitem_type=" + ItemData[iTemp].etcitem_type + Constants.vbTab);
					outFile.Write("recipe_id=" + Conversions.ToString(ItemData[iTemp].recipe_id) + Constants.vbTab);
					outFile.Write("blessed=" + Conversions.ToString(ItemData[iTemp].blessed) + Constants.vbTab);
					outFile.Write("weight=" + Conversions.ToString(ItemData[iTemp].weight) + Constants.vbTab);
					outFile.Write("default_action=" + ItemData[iTemp].default_action + Constants.vbTab);
					outFile.Write("consume_type=" + ItemData[iTemp].consume_type + Constants.vbTab);
					outFile.Write("initial_count=" + Conversions.ToString(ItemData[iTemp].initial_count) + Constants.vbTab);
					outFile.Write("maximum_count=" + Conversions.ToString(ItemData[iTemp].maximum_count) + Constants.vbTab);
					outFile.Write("soulshot_count=" + Conversions.ToString(ItemData[iTemp].soulshot_count) + Constants.vbTab);
					outFile.Write("spiritshot_count=" + Conversions.ToString(ItemData[iTemp].spiritshot_count) + Constants.vbTab);
					outFile.Write("reduced_soulshot=" + ItemData[iTemp].reduced_soulshot + Constants.vbTab);
					outFile.Write("reduced_spiritshot=" + ItemData[iTemp].reduced_spiritshot + Constants.vbTab);
					outFile.Write("reduced_mp_consume=" + ItemData[iTemp].reduced_mp_consume + Constants.vbTab);
					outFile.Write("immediate_effect=" + Conversions.ToString(ItemData[iTemp].immediate_effect) + Constants.vbTab);
					outFile.Write("price=" + Conversions.ToString(ItemData[iTemp].price) + Constants.vbTab);
					outFile.Write("default_price=" + Conversions.ToString(ItemData[iTemp].default_price) + Constants.vbTab);
					outFile.Write("item_skill=" + ItemData[iTemp].item_skill + Constants.vbTab);
					outFile.Write("critical_attack_skill=" + ItemData[iTemp].critical_attack_skill + Constants.vbTab);
					outFile.Write("attack_skill=" + ItemData[iTemp].attack_skill + Constants.vbTab);
					outFile.Write("magic_skill=" + ItemData[iTemp].magic_skill + Constants.vbTab);
					outFile.Write("item_skill_enchanted_four=" + ItemData[iTemp].item_skill_enchanted_four + Constants.vbTab);
					outFile.Write("material_type=" + ItemData[iTemp].material_type + Constants.vbTab);
					outFile.Write("crystal_type=" + ItemData[iTemp].crystal_type + Constants.vbTab);
					outFile.Write("crystal_count=" + Conversions.ToString(ItemData[iTemp].crystal_count) + Constants.vbTab);
					outFile.Write("is_trade=" + Conversions.ToString(ItemData[iTemp].is_trade) + Constants.vbTab);
					outFile.Write("is_drop=" + Conversions.ToString(ItemData[iTemp].is_drop) + Constants.vbTab);
					outFile.Write("is_destruct=" + Conversions.ToString(ItemData[iTemp].is_destruct) + Constants.vbTab);
					outFile.Write("physical_damage=" + Conversions.ToString(ItemData[iTemp].physical_damage) + Constants.vbTab);
					outFile.Write("random_damage=" + Conversions.ToString(ItemData[iTemp].random_damage) + Constants.vbTab);
					outFile.Write("weapon_type=" + ItemData[iTemp].weapon_type + Constants.vbTab);
					outFile.Write("can_penetrate=" + Conversions.ToString(ItemData[iTemp].can_penetrate) + Constants.vbTab);
					outFile.Write("critical=" + Conversions.ToString(ItemData[iTemp].critical) + Constants.vbTab);
					outFile.Write("hit_modify=" + Conversions.ToString(ItemData[iTemp].hit_modify) + Constants.vbTab);
					outFile.Write("avoid_modify=" + Conversions.ToString(ItemData[iTemp].avoid_modify) + Constants.vbTab);
					outFile.Write("dual_fhit_rate=" + Conversions.ToString(ItemData[iTemp].dual_fhit_rate) + Constants.vbTab);
					outFile.Write("shield_defense=" + Conversions.ToString(ItemData[iTemp].shield_defense) + Constants.vbTab);
					outFile.Write("shield_defense_rate=" + Conversions.ToString(ItemData[iTemp].shield_defense_rate) + Constants.vbTab);
					outFile.Write("attack_range=" + Conversions.ToString(ItemData[iTemp].attack_range) + Constants.vbTab);
					outFile.Write("damage_range=" + ItemData[iTemp].damage_range + Constants.vbTab);
					outFile.Write("attack_speed=" + Conversions.ToString(ItemData[iTemp].attack_speed) + Constants.vbTab);
					outFile.Write("reuse_delay=" + Conversions.ToString(ItemData[iTemp].reuse_delay) + Constants.vbTab);
					outFile.Write("mp_consume=" + Conversions.ToString(ItemData[iTemp].mp_consume) + Constants.vbTab);
					outFile.Write("magical_damage=" + Conversions.ToString(ItemData[iTemp].magical_damage) + Constants.vbTab);
					outFile.Write("durability=0" + Conversions.ToString(ItemData[iTemp].durability) + Constants.vbTab);
					outFile.Write("damaged=" + Conversions.ToString(ItemData[iTemp].damaged) + Constants.vbTab);
					outFile.Write("physical_defense=" + Conversions.ToString(ItemData[iTemp].physical_defense) + Constants.vbTab);
					outFile.Write("magical_defense=" + Conversions.ToString(ItemData[iTemp].magical_defense) + Constants.vbTab);
					outFile.Write("mp_bonus=" + Conversions.ToString(ItemData[iTemp].mp_bonus) + Constants.vbTab);
					outFile.Write("category=" + ItemData[iTemp].category + Constants.vbTab);
					outFile.Write("enchanted=" + Conversions.ToString(ItemData[iTemp].enchanted) + Constants.vbTab);
					outFile.Write("html=" + ItemData[iTemp].html + Constants.vbTab);
					outFile.Write("equip_pet=" + ItemData[iTemp].equip_pet + Constants.vbTab);
					outFile.Write("magic_weapon=" + Conversions.ToString(ItemData[iTemp].magic_weapon) + Constants.vbTab);
					outFile.Write("enchant_enable=" + Conversions.ToString(ItemData[iTemp].enchant_enable) + Constants.vbTab);

					// CT23 + NextDev Ext.dll support
					// equip_cond={}	equip_cond = 
					// outFile.Write("can_equip_sex=" & ItemData(iTemp).can_equip_sex & vbTab)
					// outFile.Write("can_equip_race=" & ItemData(iTemp).can_equip_race & vbTab)
					// outFile.Write("can_equip_change_class=" & ItemData(iTemp).can_equip_change_class & vbTab)
					// outFile.Write("can_equip_class=" & ItemData(iTemp).can_equip_class & vbTab)
					// outFile.Write("can_equip_agit=" & ItemData(iTemp).can_equip_agit & vbTab)
					// outFile.Write("can_equip_castle=" & ItemData(iTemp).can_equip_castle & vbTab)
					// outFile.Write("can_equip_castle_num=" & ItemData(iTemp).can_equip_castle_num & vbTab)
					// outFile.Write("can_equip_clan_leader=" & ItemData(iTemp).can_equip_clan_leader & vbTab)
					// outFile.Write("can_equip_clan_level=" & ItemData(iTemp).can_equip_clan_level & vbTab)
					// outFile.Write("can_equip_hero=" & ItemData(iTemp).can_equip_hero & vbTab)
					// outFile.Write("can_equip_nobless=" & ItemData(iTemp).can_equip_nobless & vbTab)
					// outFile.Write("can_equip_chaotic=" & ItemData(iTemp).can_equip_chaotic & vbTab)

					outFile.Write("equip_cond={");
					bool iCanFlag = false;
					if (ItemData[iTemp].can_equip_hero != -1)
					{
						outFile.Write("{ec_hero;1}"); iCanFlag = true;
					}
					// If iCanFlag = True Then outFile.Write(";" & vbTab)
					outFile.Write("}" + Constants.vbTab);

					if (ItemData[iTemp].durability != -1)
					{
						outFile.Write("mana=" + Conversions.ToString(ItemData[iTemp].durability) + Constants.vbTab);
						outFile.Write("is_augment=0" + Constants.vbTab);
					}
					outFile.WriteLine("item_end");
				}
			}



			// SET Writer
			// '' set_ids={1101,1104,44}	set_bonus_desc=[Casting Spd. +15%.]	set_extra_id=[]	set_extra_desc=[]
			// '' set_ids={2381,2417,5722,5738}	set_bonus_desc=[Maximum HP +320, Breath Gauge increase, STR-3, and CON+3.]	set_extra_id=[110]	set_extra_desc=[Shield Def +24%.]

			// ''id=2381	name=[Doom Plate Armor]	add_name=[]	description=[Full body armor.]	popup=-1	
			// ''set_ids={2381,2417,5722,5738}	set_bonus_desc=[Maximum HP +320, Breath Gauge increase, STR-3, and CON+3.]
			// ''set_extra_id=[110]	set_extra_desc=[Shield Def +24%.]	unk[0]=0	unk[1]=0	
			// ''special_enchant_amount=6	special_enchant_desc=[When all set items are enchanted by 6 or higher, P. Def. and MP regeneration rate will increase.]	itemname_end
			// 'Dim aTemp() As String
			// 'Dim iTemp2 As Integer, iId As Integer
			// 'Dim armorType As Integer ' for six enchants

			// 'For iTemp = 1 To ItemSets.Length - 1
			// '    outFile.WriteLine("// SetID " & iTemp & ": " & ItemSets(iTemp).SetName) '& vbTab & "Additional description: " & ItemSets(iTemp).ItemAddDesc)
			// '    If ItemSets(iTemp).ItemAdd <> "" Then
			// '        outFile.WriteLine("// " & vbTab & ItemData(CInt(ItemSets(iTemp).ItemAdd)).name & ". " & ItemSets(iTemp).ItemAddDesc)
			// '    End If
			// 'Next
			// 'For iTemp = 1 To ItemSets.Length - 1
			// '    'set_begin	13	slot_chest=354	slot_legs=381	slot_head=2413	slot_lhand=2495	slot_additional=[slot_lhand]	set_skill=[s_set_collected]	set_effect_skill=[s_chain_mail_shirt_material]	set_additional_effect_skill=[s_chain_mail_shirt_material_shield]	str_inc={0;0}	con_inc={0;0}	dex_inc={0;0}	int_inc={0;0}	men_inc={0;0}	wit_inc={0;0}	set_end

			// '    outFile.Write("set_begin" & vbTab)
			// '    outFile.Write(iTemp & vbTab)
			// '    outFile.Write("slot_chest=" & ItemSets(iTemp).ChestId & vbTab)
			// '    If GenerateEnch6CheckBox.Checked = True Then
			// '        sTemp = ""
			// '        armorType = 0
			// '        sTemp = sTemp & "slot_chest "
			// '        armorType = CInt(ItemSets(iTemp).ChestId)
			// '    End If

			// '    aTemp = ItemSets(iTemp).ItemList.Split(CChar(","))
			// '    For iTemp2 = 0 To aTemp.Length - 1
			// '        If CInt(aTemp(iTemp2)) <> CInt(ItemSets(iTemp).ChestId) Then
			// '            outFile.Write("slot_" & ItemData(CInt(aTemp(iTemp2))).slot_bit_type.Replace("{", "").Replace("}", "") & "=" & aTemp(iTemp2) & vbTab)

			// '            If GenerateEnch6CheckBox.Checked = True Then
			// '                sTemp = sTemp & "slot_" & ItemData(CInt(aTemp(iTemp2))).slot_bit_type.Replace("{", "").Replace("}", "") & " "
			// '            End If

			// '        End If
			// '    Next
			// '    If ItemSets(iTemp).ItemAdd = "" Then
			// '        outFile.Write("slot_additional=[none]" & vbTab)
			// '    Else
			// '        iId = CInt(ItemSets(iTemp).ItemAdd)
			// '        outFile.Write("slot_" & ItemData(iId).slot_bit_type.Replace("{", "").Replace("}", "") & "=" & iId & vbTab)
			// '        outFile.Write("slot_additional=[slot_" & ItemData(iId).slot_bit_type.Replace("{", "").Replace("}", "") & "]" & vbTab)
			// '    End If

			// '    outFile.Write("set_skill=[s_set_collected]" & vbTab)
			// '    outFile.Write("set_effect_skill=[none]" & vbTab)
			// '    outFile.Write("set_additional_effect_skill=[none]" & vbTab)

			// '    If GenerateEnch6CheckBox.Checked = True Then
			// '        outFile.Write("enchant_six_skill=[s_enchant_six_" & ItemData(armorType).armor_type & "_" & ItemData(armorType).crystal_type & "]" & vbTab)
			// '        sTemp = sTemp.Trim.Replace(" ", ";")
			// '        sTemp = "enchant_six_slots=[" & sTemp & "]"
			// '        outFile.Write(sTemp & vbTab)
			// '    End If

			// '    outFile.Write("str_inc={0;0}" & vbTab)
			// '    outFile.Write("con_inc={0;0}" & vbTab)
			// '    outFile.Write("dex_inc={0;0}" & vbTab)
			// '    outFile.Write("int_inc={0;0}" & vbTab)
			// '    outFile.Write("men_inc={0;0}" & vbTab)
			// '    outFile.Write("wit_inc={0;0}" & vbTab)
			// '    outFile.Write("p_def_inc={0;0}" & vbTab)
			// '    outFile.WriteLine("set_end")
			// 'Next
			// 'ToolStripProgressBar.Value = 0

			// SET WRITER - CT23 FORMAT
			if (ItemSets.Length > 0)
			{
				var loopTo1 = ItemSets.Length - 2;
				for (iTemp = 0; iTemp <= loopTo1; iTemp++)
				{
					outFile.Write("// " + Conversions.ToString(iTemp + 1) + Constants.vbTab);
					outFile.Write(ItemSets[iTemp].SetName);
					if ((ItemSets[iTemp].SetDescription ?? "") != "[]")
						outFile.Write(Constants.vbTab + ItemSets[iTemp].SetDescription);
					if ((ItemSets[iTemp].SetBonusDesc ?? "") != "[]")
						outFile.Write(Constants.vbTab + ItemSets[iTemp].SetBonusDesc);
					if ((ItemSets[iTemp].SetExtraDesc ?? "") != "[]")
						outFile.Write(Constants.vbTab + ItemSets[iTemp].SetExtraDesc);
					if ((ItemSets[iTemp].SetSpecEnchDesc ?? "") != "[]")
						outFile.Write(Constants.vbTab + ItemSets[iTemp].SetSpecEnchDesc);
					outFile.WriteLine("");
				}
			}


			// ' CT23 format
			// cnt0=5	set_ids[0]=[2376]	set_ids[1]=[2379,11375]	set_ids[2]=[2415,11373]	set_ids[3]=[5714,11365]	set_ids[4]=[5730,11370]	
			// cnt1=1	set_extra_ids=[673,11374]
			// set_begin	45	
			// slot_chest={6383;11488}	slot_head={6386;11490}	slot_gloves={6384;11487}	slot_feet={6385;11489}	slot_additional=[none]	

			// set_skill=[s_set_collected]	set_effect_skill=[s_major_arcana_robe]

			// slot_lhand={673}	slot_additional=[slot_lhand]	

			// set_skill=[s_set_collected]	set_effect_skill=[s_avadon_breastplate]	
			// set_additional_effect_skill=[s_avadon_breastplate_shield]	

			// set_enchant_six_skill=[s_ench_heavy_armor_grade_b]

			// str_inc={0;0}	con_inc={0;0}	dex_inc={0;0}	int_inc={1;0}	men_inc={-2;0}	wit_inc={1;0}	set_end

			// set_begin	26	slot_chest={2376}	slot_legs={2379}	slot_head={2415}	slot_gloves={5714}	slot_feet={5730}	

			inFile = new System.IO.StreamReader(sItemNameFile, true);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading itemname-e.txt...";
			int iTemp2;
			int iSetCounter = 0;
			int iTemp3;
			string[] sTemp3;

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{
					iTemp = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "cnt0"));
					if (iTemp > 0)
					{
						outFile.Write("set_begin" + Constants.vbTab);
						iSetCounter = iSetCounter + 1;
						outFile.Write(Conversions.ToString(iSetCounter) + Constants.vbTab);
						var loopTo2 = iTemp - 1;
						for (iTemp2 = 0; iTemp2 <= loopTo2; iTemp2++)
						{
							sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "set_ids[" + Conversions.ToString(iTemp2) + "]");
							sTemp2 = sTemp2.Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "").Replace(",", ";");

							sTemp3 = sTemp2.Split(); iTemp3 = Conversions.ToInteger(sTemp3[0]);

							if ((ItemData[iTemp3].slot_bit_type ?? "") == "{onepiece}")
								ItemData[iTemp3].slot_bit_type = "{chest}";
							outFile.Write("slot_" + ItemData[iTemp3].slot_bit_type.Replace("{", "").Replace("}", "") + "=");

							// Select Case iTemp2
							// Case 0
							// outFile.Write("slot_chest=")
							// Case 1
							// outFile.Write("slot_legs=")
							// Case 2
							// outFile.Write("slot_head=")
							// Case 3
							// outFile.Write("slot_gloves=")
							// Case 4
							// outFile.Write("slot_feet=")
							// End Select
							outFile.Write("{" + sTemp2 + "}" + Constants.vbTab);
						}

						// lhand - shield equip
						iTemp = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "cnt1"));
						if (iTemp > 0)
						{
							var loopTo3 = iTemp - 1;
							for (iTemp2 = 0; iTemp2 <= loopTo3; iTemp2++)
							{
								// cnt1=1	set_extra_ids=[673,11374]
								sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "set_extra_ids");
								sTemp2 = sTemp2.Replace("[", "{").Replace("]", "}");
								// slot_lhand={673,11374}	slot_additional=[slot_lhand]
								outFile.Write("slot_lhand=" + sTemp2 + Constants.vbTab);
								outFile.Write("slot_additional=[slot_lhand]" + Constants.vbTab);
							}
						}
						else
							outFile.Write("slot_additional=[none]" + Constants.vbTab);

						outFile.Write("set_skill=[s_set_collected]" + Constants.vbTab);
						outFile.Write("set_effect_skill=[none]" + Constants.vbTab);
						if (Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "cnt1")) > 0)
							outFile.Write("set_additional_effect_skill=[none]" + Constants.vbTab);
						// set_enchant_six_skill=[s_ench_heavy_armor_grade_b]
						if (Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "special_enchant_amount")) > 0)
							outFile.Write("set_enchant_six_skill=[none]" + Constants.vbTab);


						outFile.Write("str_inc={0;0}" + Constants.vbTab);
						outFile.Write("con_inc={0;0}" + Constants.vbTab);
						outFile.Write("dex_inc={0;0}" + Constants.vbTab);
						outFile.Write("int_inc={0;0}" + Constants.vbTab);
						outFile.Write("men_inc={0;0}" + Constants.vbTab);
						outFile.Write("wit_inc={0;0}" + Constants.vbTab);
						outFile.Write("p_def_inc={0;0}" + Constants.vbTab);
						outFile.WriteLine("set_end");
					}
				}
			}
			inFile.Close();
			outFile.Close();
			ToolStripProgressBar.Value = 0;

			ToolStripStatusLabel.Text = "Complete";
			MessageBox.Show("Complete");

			return;

		ErrorScreener:
			;
			if ((int)MessageBox.Show("Found bad param value in line" + Constants.vbNewLine + sTemp + Constants.vbNewLine + Constants.vbNewLine + "Continue generation or stop? If you continue, this item may be wrong", "Bad value", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == (int)DialogResult.Yes)
			{
			}

			inFile.Close();
			ToolStripProgressBar.Value = 0;

			ToolStripStatusLabel.Text = "Generation aborted";
			MessageBox.Show("Generation aborted", "Stoped", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
