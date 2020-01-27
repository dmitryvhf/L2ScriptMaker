using L2ScriptMaker.Extensions.VbCompatibleHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using L2ScriptMaker.Extensions;

namespace L2ScriptMaker.Modules.ZeroScripts.L2J
{
	public partial class L2J_NpcData : Form
	{
		public L2J_NpcData()
		{
			InitializeComponent();
		}

		private struct Items
		{
			public string name;
			public string item_type;         // item_type=armor,shield,weapon
			public string weapon_type;       // weapon_type=none,dagger, pole,dual ({lrhand})
			public string shield_defense;
			public string shield_defense_rate;
			public string critical;
			public string hit_modify;
			public string avoid_modify;
			public string attack_range;
			public string damage_range;
			public string reuse_delay;
			public string random_damage;
		}



		private void ButtonExpSP_Click(object sender, EventArgs e)
		{
			string sTemp;
			string sNpcFile;
			System.IO.StreamReader inNpcFile;

			OpenFileDialog.Filter = "NpcData.txt|npcdata.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sNpcFile = OpenFileDialog.FileName;

			System.IO.File.Copy(sNpcFile, sNpcFile + ".bak", true);
			inNpcFile = new System.IO.StreamReader(sNpcFile + ".bak", System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter(sNpcFile, false, System.Text.Encoding.Unicode, 1);

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inNpcFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading/Writing npcdata.txt...";
			string dExp;
			string sSP;
			string sSkill;

			while (inNpcFile.EndOfStream != true)
			{
				sTemp = inNpcFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inNpcFile.BaseStream.Position);

				if (sTemp.StartsWith("npc_begin") == true)
				{
					// npc_begin	warrior	20761	[pytan]	level=69	acquire_exp_rate=8.3592	acquire_sp=3894	unsowing=0	clan={@MALRUK_CLAN}	ignore_clan_list={}	clan_help_range=500	slot_chest=[]	slot_rhand=[]	slot_lhand=[]	
					// shield_defense_rate=0	shield_defense=0	skill_list={}	

					sSkill = Libraries.GetNeedParamFromStr(sTemp, "skill_list");
					dExp = Libraries.GetNeedParamFromStr(sTemp, "acquire_exp_rate");
					sSP = Libraries.GetNeedParamFromStr(sTemp, "acquire_sp");

					// s_hp_increase10 - hp*2 = exp*2,sp*2
					// s_hp_increase11 - hp*3 = exp*3,sp*3
					// s_hp_increase12 - hp*4 = exp*4,sp*4
					// s_hp_increase13 - hp*5 = exp*5,sp*5
					// s_hp_increase14 - hp*6 = exp*6,sp*6
					// s_hp_increase15 - hp*7 = exp*7,sp*7
					// s_hp_increase16 - hp*8 = exp*8,sp*8
					// s_hp_increase17 - hp*9 = exp*9,sp*9
					// s_hp_increase18 - hp*10 = exp*10,sp*10
					// s_hp_increase19 - hp*11 = exp*11,sp*11
					// s_hp_increase20 - hp*12 = exp*12,sp*12

					if (Strings.InStr(sTemp, "s_hp_increase10") > 0)
					{
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Strings.Format(Conversions.ToDouble(dExp) * 2, "0.####"));
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", Conversions.ToString(Conversions.ToInteger(sSP) * 2));
					}
					if (Strings.InStr(sTemp, "s_hp_increase11") > 0)
					{
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Strings.Format(Conversions.ToDouble(dExp) * 3, "0.####"));
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", Conversions.ToString(Conversions.ToInteger(sSP) * 3));
					}
					if (Strings.InStr(sTemp, "s_hp_increase12") > 0)
					{
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Strings.Format(Conversions.ToDouble(dExp) * 4, "0.####"));
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", Conversions.ToString(Conversions.ToInteger(sSP) * 4));
					}
					if (Strings.InStr(sTemp, "s_hp_increase13") > 0)
					{
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Strings.Format(Conversions.ToDouble(dExp) * 5, "0.####"));
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", Conversions.ToString(Conversions.ToInteger(sSP) * 5));
					}
					if (Strings.InStr(sTemp, "s_hp_increase14") > 0)
					{
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Strings.Format(Conversions.ToDouble(dExp) * 6, "0.####"));
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", Conversions.ToString(Conversions.ToInteger(sSP) * 6));
					}
					if (Strings.InStr(sTemp, "s_hp_increase15") > 0)
					{
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Strings.Format(Conversions.ToDouble(dExp) * 7, "0.####"));
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", Conversions.ToString(Conversions.ToInteger(sSP) * 7));
					}
					if (Strings.InStr(sTemp, "s_hp_increase16") > 0)
					{
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Strings.Format(Conversions.ToDouble(dExp) * 8, "0.####"));
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", Conversions.ToString(Conversions.ToInteger(sSP) * 8));
					}
					if (Strings.InStr(sTemp, "s_hp_increase17") > 0)
					{
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Strings.Format(Conversions.ToDouble(dExp) * 9, "0.####"));
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", Conversions.ToString(Conversions.ToInteger(sSP) * 9));
					}
					if (Strings.InStr(sTemp, "s_hp_increase18") > 0)
					{
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Strings.Format(Conversions.ToDouble(dExp) * 10, "0.####"));
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", Conversions.ToString(Conversions.ToInteger(sSP) * 10));
					}
					if (Strings.InStr(sTemp, "s_hp_increase19") > 0)
					{
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Strings.Format(Conversions.ToDouble(dExp) * 11, "0.####"));
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", Conversions.ToString(Conversions.ToInteger(sSP) * 11));
					}
					if (Strings.InStr(sTemp, "s_hp_increase20") > 0)
					{
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Strings.Format(Conversions.ToDouble(dExp) * 12, "0.####"));
						sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", Conversions.ToString(Conversions.ToInteger(sSP) * 12));
					}
				}
				outFile.WriteLine(sTemp);
			}
			outFile.Close();
			inNpcFile.Close();
			ToolStripProgressBar.Value = 0;


			MessageBox.Show("Completed.");
		}

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			string sNpcFile;
			string sTemp;
			string sTempForWrite = "";
			int iTemp;
			string[] aTemp;

			System.IO.StreamReader inNpcFile;

			// LOADING itemdata.txt
			if (System.IO.File.Exists("itemdata.txt") == false)
			{
				MessageBox.Show("itemdata.txt not found", "Need itemdata.txt", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var aItemPch = new Items[25001];
			inNpcFile = new System.IO.StreamReader("itemdata.txt", System.Text.Encoding.Default, true, 1);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inNpcFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading itemdata.txt ...";

			aItemPch[0].shield_defense = "0";
			aItemPch[0].shield_defense_rate = "0";
			aItemPch[0].damage_range = "0";
			aItemPch[0].random_damage = "0";
			aItemPch[0].critical = "0";
			aItemPch[0].hit_modify = "0";
			aItemPch[0].reuse_delay = "0";
			aItemPch[0].weapon_type = "";

			while (inNpcFile.EndOfStream != true)
			{
				sTemp = inNpcFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inNpcFile.BaseStream.Position);
				if (sTemp.StartsWith("item_begin") == true)
				{

					// [small_sword] = 1
					// 0          1       2       3
					// item_begin	armor	6721	[shield_of_imperial_warlord_zombie]	item_type=armor	slot_bit_type={lhand}	armor_type=shield	etcitem_type=none	recipe_id=0	blessed=0	weight=1430	
					// default_action=action_equip	consume_type=consume_type_normal	initial_count=1	maximum_count=1	soulshot_count=0	spiritshot_count=0	reduced_soulshot={}	reduced_spiritshot={}	
					// reduced_mp_consume={}	immediate_effect=1	price=0	default_price=39	item_skill=[none]	critical_attack_skill=[none]	attack_skill=[none]	magic_skill=[none]	item_skill_enchanted_four=[none]	
					// material_type=leather	crystal_type=none	crystal_count=0	is_trade=1	is_drop=1	is_destruct=1	physical_damage=0	random_damage=0	weapon_type=none	can_penetrate=0	critical=0	hit_modify=0	
					// avoid_modify=-8	dual_fhit_rate=0	shield_defense=47	shield_defense_rate=20	attack_range=0	damage_range={}	attack_speed=0	reuse_delay=0	mp_consume=0	magical_damage=0	
					// durability=90	damaged=0	physical_defense=0	magical_defense=0	mp_bonus=0	category={}	enchanted=0	html=[item_default.htm]	equip_pet={0}	magic_weapon=0	enchant_enable=0	mana=0	
					// base_attribute_attack={attr_none;0}	base_attribute_defend={0;0;0;0;0;0}	elemental_enable=0	is_deposit=1	equip_cond = {{ec_race;{@RACE_KAMAEL};0}}	item_end

					sTemp = sTemp.Replace(" ", Conversions.ToString((char)9));
					aTemp = sTemp.Split((char)9);

					iTemp = Conversions.ToInteger(aTemp[2]);
					try
					{
						aItemPch[iTemp].name = aTemp[3];
						aItemPch[iTemp].item_type = Libraries.GetNeedParamFromStr(sTemp, "item_type");
						aItemPch[iTemp].weapon_type = Libraries.GetNeedParamFromStr(sTemp, "weapon_type");
						aItemPch[iTemp].attack_range = Libraries.GetNeedParamFromStr(sTemp, "attack_range");
						aItemPch[iTemp].damage_range = Libraries.GetNeedParamFromStr(sTemp, "damage_range");
						aItemPch[iTemp].random_damage = Libraries.GetNeedParamFromStr(sTemp, "random_damage");
						aItemPch[iTemp].critical = Libraries.GetNeedParamFromStr(sTemp, "critical");
						aItemPch[iTemp].hit_modify = Libraries.GetNeedParamFromStr(sTemp, "hit_modify");
						aItemPch[iTemp].avoid_modify = Libraries.GetNeedParamFromStr(sTemp, "avoid_modify");
						aItemPch[iTemp].reuse_delay = Libraries.GetNeedParamFromStr(sTemp, "reuse_delay");
						aItemPch[iTemp].shield_defense = Libraries.GetNeedParamFromStr(sTemp, "shield_defense");
						aItemPch[iTemp].shield_defense_rate = Libraries.GetNeedParamFromStr(sTemp, "shield_defense_rate");
					}
					// aItemPch(iTemp).slot_bit_type = Libraries.GetNeedParamFromStr(sTemp, "slot_bit_type")
					catch (Exception ex)
					{
						MessageBox.Show("Error in loading itemdata.txt. Last reading line:" + Constants.vbNewLine + sTemp);
						inNpcFile.Close();
						return;
					}
				}
			}
			inNpcFile.Close();
			ToolStripProgressBar.Value = 0;

			// LOADING npc_exp_table.txt
			if (System.IO.File.Exists("npc_exp_table.txt") == false)
			{
				MessageBox.Show("npc_exp_table.txt not found", "Need itemdata.txt", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var aNpcExp = new string[101];
			int iExpCounter = 0;
			inNpcFile = new System.IO.StreamReader("npc_exp_table.txt", System.Text.Encoding.Default, true, 1);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inNpcFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading npc_exp_table.txt ...";

			while (inNpcFile.EndOfStream != true)
			{
				sTemp = inNpcFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inNpcFile.BaseStream.Position);
				sTemp = sTemp.Trim();
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{

					// 804225364.0
					iExpCounter = iExpCounter + 1;
					try
					{
						aNpcExp[iExpCounter] = sTemp;
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error in loading npc_exp_table.txt. Last reading line:" + Constants.vbNewLine + sTemp);
						inNpcFile.Close();
						return;
					}
				}
			}
			inNpcFile.Close();
			ToolStripProgressBar.Value = 0;

			// LOADING npc_exp_table.txt
			if (System.IO.File.Exists("npc_exp_table.txt") == false)
			{
				MessageBox.Show("npc_exp_table.txt not found", "Need itemdata.txt", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var aLevelBonus = new string[101];
			iExpCounter = 0;

			inNpcFile = new System.IO.StreamReader("npc_level_bonus_table.txt", System.Text.Encoding.Default, true, 1);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inNpcFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading npc_level_bonus_table.txt ...";

			while (inNpcFile.EndOfStream != true)
			{
				sTemp = inNpcFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inNpcFile.BaseStream.Position);
				sTemp = sTemp.Trim();
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{

					// 804225364.0
					iExpCounter = iExpCounter + 1;
					try
					{
						aLevelBonus[iExpCounter] = sTemp;
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error in loading npc_level_bonus_table.txt. Last reading line:" + Constants.vbNewLine + sTemp);
						inNpcFile.Close();
						return;
					}
				}
			}
			inNpcFile.Close();
			ToolStripProgressBar.Value = 0;


			// LOADING npc_exp_table.txt
			if (System.IO.File.Exists("NpcName-e.txt") == false)
			{
				MessageBox.Show("NpcName-e.txt not found", "Need NpcName-e.txt", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var aNpcRaid = new bool[40001];
			iExpCounter = 0;

			inNpcFile = new System.IO.StreamReader("NpcName-e.txt", System.Text.Encoding.Default, true, 1);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inNpcFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading NpcName-e.txt ...";
			// Dim iSpecialBoss() As Integer = {18465, 22326, 22341, 25539, 29021, 12532, 12533, 12534, 12539, 12540, 12541, 12542, 12543, 29045, 29046}

			while (inNpcFile.EndOfStream != true)
			{
				sTemp = inNpcFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inNpcFile.BaseStream.Position);
				sTemp = sTemp.Trim();
				
				// if (Strings.InStr(sTemp, "id=25563") > 0) bool assd = true;
				
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{

					// npcname_begin	id=25001	name=[Greyclaw Kutus]	description=[Raid Boss]	            rgb[0]=[3F]	rgb[1]=[8B]	rgb[2]=[FE]	reserved1=-1	npcname_end
					// npcname_begin	id=25563	name=[Beautiful Atrielle]	description=[Forsaken Prisoner]	rgb[0]=[3F]	rgb[1]=[8B]	rgb[2]=[FE]	reserved1=-1	npcname_end
					// npcname_begin	id=20001	name=[Gremlin]	        description=[]	                    rgb[0]=[9C]	rgb[1]=[E8]	rgb[2]=[A9]	reserved1=-1	npcname_end
					if ((Libraries.GetNeedParamFromStr(sTemp, "rgb[0]") ?? "") == "[3F]")
					{
						try
						{
							aNpcRaid[Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "id"))] = true;
						}
						catch (Exception ex)
						{
							MessageBox.Show("Error in loading NpcName-e.txt. Last reading line:" + Constants.vbNewLine + sTemp);
							inNpcFile.Close();
							return;
						}
					}
				}
			}
			inNpcFile.Close();
			ToolStripProgressBar.Value = 0;

			OpenFileDialog.Filter = "L2J Npc (npc.sql)|npc.sql|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sNpcFile = OpenFileDialog.FileName;

			inNpcFile = new System.IO.StreamReader(sNpcFile, System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter("npcdata_l2j.txt", false, System.Text.Encoding.Unicode, 1);

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inNpcFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading npc.sql...";

			int iSlotWeapon;
			int iSlotArmor;

			while (inNpcFile.EndOfStream != true)
			{
				sTemp = inNpcFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inNpcFile.BaseStream.Position);
				if (sTemp.StartsWith("(") == true)
				{

					// 0     1     2       3  4 5  6                             7    8     9  10        11         12  13   14  15    16   17 18 19 20 21 22 23   24  25   26  27  28  29  30  31  32 33 34 35 36 37  38 39 40          41
					// (20761,20761,'Pytan',0,'',0,'LineageMonster.bloody_queen',14.00,40.00,69,'female','L2Monster',40,3784,1458,35.55,2.78,40,43,30,21,20,10,6633,649,1392,418,746,373,278,500,333,0,  0, 0, 0,88,191, 0,10,'LAST_HIT','false'),
					sTemp = sTemp.Substring(Strings.InStr(sTemp, "("), Strings.InStr(sTemp, ")") - Strings.InStr(sTemp, "(") - 1);
					aTemp = sTemp.Split(Conversions.ToChar(","));

					iSlotWeapon = Conversions.ToInteger(aTemp[32]);
					iSlotArmor = Conversions.ToInteger(aTemp[33]);


					// npc_begin	warrior	20761	[pytan]	level=69	acquire_exp_rate=8.3592	acquire_sp=3894	unsowing=0	clan={@MALRUK_CLAN}	ignore_clan_list={}	clan_help_range=500	slot_chest=[]	slot_rhand=[]	slot_lhand=[]	
					// shield_defense_rate=0	shield_defense=0	skill_list={}	
					// npc_ai={[pytan];{[MoveAroundSocial]=60};{[MoveAroundSocial1]=60};{[MoveAroundSocial2]=60};{[ShoutTarget]=1};{[SetHateGroup]=@attacker_group};{[SetHateGroupRatio]=20};{[DDMagic]=@s_blood_sucking6}}	
					// category={}	race=demonic	sex=female	undying=0	can_be_attacked=1	corpse_time=7	no_sleep_mode=0	agro_range=1000	ground_high={171.9;0;0}	ground_low={79.2;0;0}	
					// exp=387199547.925	org_hp=2395	org_hp_regen=35.55	org_mp=1458	org_mp_regen=2.78	collision_radius={14;14}	collision_height={40;40}	
					// str=40	int=21	dex=30	wit=20	con=43	men=10	base_attack_type=fist	base_attack_range=40	base_damage_range={0;0;80;120}	base_rand_dam=7	base_physical_attack=779.52	base_critical=12	
					// physical_hit_modify=-3.75	base_attack_speed=247.42	base_reuse_delay=0	base_magic_attack=507.28	base_defend=280.06	base_magic_defend=227.53	
					// physical_avoid_modify=0	soulshot_count=0	spiritshot_count=0	hit_time_factor=0.5	item_make_list={}	
					// corpse_make_list={{[rp_soulshot_a];1;1;2.2134};{[oriharukon_ore];1;1;100};{[stone_of_purity];1;1;100}}	additional_make_list={}	
					// additional_make_multi_list={}	hp_increase=0	mp_increase=0	safe_height=100	drop_herb=0	npc_end

					outFile.Write("npc_begin" + Constants.vbTab);

					/* TODO ERROR: Skipped IfDirectiveTrivia */
					// if ((aTemp[0] ?? "") == "25563")  bool assd2 = true;
					/* TODO ERROR: Skipped EndIfDirectiveTrivia */

					aTemp[11] = aTemp[11].Replace("'", "");
					switch (aTemp[11])
					{
						case "L2Npc":
							{
								aTemp[11] = "citizen";
								break;
							}

						case "L2Auctioneer":
							{
								aTemp[11] = "citizen";
								break;
							}

						case "L2PetManager":
							{
								aTemp[11] = "citizen";
								break;
							}

						case "L2MercenaryManager":
							{
								aTemp[11] = "citizen";
								break;
							}

						case "L2FameManager":
							{
								aTemp[11] = "citizen";
								break;
							}

						case "L2Monster":
							{
								aTemp[11] = "warrior";
								break;
							}

						case "L2GrandBoss":
							{
								aTemp[11] = "boss";
								break;
							}

						case "L2RaidBoss":
							{
								aTemp[11] = "boss";
								break;
							}

						case "L2Minion":
							{
								aTemp[11] = "zzoldagu";
								break;
							}

						case "L2Pet":
							{
								aTemp[11] = "summon";
								break;
							}

						case "L2Merchant":
							{
								aTemp[11] = "merchant";
								break;
							}

						case "L2Trainer":
							{
								aTemp[11] = "guild_coach";
								break;
							}

						case "L2Warehouse":
							{
								aTemp[11] = "warehouse_keeper";
								break;
							}

						case "L2Teleporter":
							{
								aTemp[11] = "teleporter";
								break;
							}

						case "L2Guard":
							{
								aTemp[11] = "guard";
								break;
							}

						case "L2Decoy":
							{
								aTemp[11] = "doppelganger";
								break;
							}

						case "L2SiegeSummon":
							{
								aTemp[11] = "summon";
								break;
							}

						case "L2BabyPet":
							{
								aTemp[11] = "pet";
								break;
							}

						case "L2Chest":
							{
								aTemp[11] = "treasure";
								break;
							}

						default:
							{
								aTemp[11] = "warrior";
								if (aTemp[11].StartsWith("L2VillageMaster") == true)
									aTemp[11] = "guild_master";
								break;
							}
					}


					// BOSS/Mobs Stats bug fix!
					if (CheckBoxFixStats.Checked == true)
					{

						// aTemp(9) - level
						if (CheckBoxZzoldagu74.Checked == true)
						{
							if ((aTemp[11] ?? "") == "zzoldagu" & Conversions.ToInteger(aTemp[9]) >= 73)
								aTemp[11] = "boss";
						}

						if (aNpcRaid[Conversions.ToInteger(aTemp[0])] == true)
						{
							if ((aTemp[11] ?? "") != "boss" & (aTemp[11] ?? "") != "zzoldagu")
								aTemp[11] = "boss";
						}

						// BOSS/Mobs Stats bug fix!
						// doppelganger, pc_trap
						switch (aTemp[11])
						{
							case "boss":
								{
									// str=60	int=76	dex=73	wit=70	con=57	men=80  boss
									aTemp[17] = "60";
									aTemp[20] = "76";
									aTemp[19] = "73";
									aTemp[21] = "70";
									aTemp[18] = "57";
									aTemp[22] = "80";
									break;
								}

							case "zzoldagu":
								{
									// str=40	int=41	dex=30	wit=20	con=43	men=10  zzoldagu
									aTemp[17] = "40";
									aTemp[20] = "41";
									aTemp[19] = "30";
									aTemp[21] = "20";
									aTemp[18] = "43";
									aTemp[22] = "10";
									break;
								}

							case "warrior":
								{
									// str=40	int=21	dex=30	wit=20	con=43	men=10  warrior
									aTemp[17] = "40";
									aTemp[20] = "21";
									aTemp[19] = "30";
									aTemp[21] = "20";
									aTemp[18] = "43";
									aTemp[22] = "10";
									// 12762	[dawn_hero_sword_move], 12763	[dawn_hero_wizard_move]
									if ((aTemp[2] ?? "") == "12762" | (aTemp[2] ?? "") == "12763")
									{
										sTemp = Libraries.SetNeedParamToStr(sTemp, "str", "84");
										sTemp = Libraries.SetNeedParamToStr(sTemp, "int", "76");
										sTemp = Libraries.SetNeedParamToStr(sTemp, "dex", "73");
										sTemp = Libraries.SetNeedParamToStr(sTemp, "wit", "70");
										sTemp = Libraries.SetNeedParamToStr(sTemp, "con", "71");
										sTemp = Libraries.SetNeedParamToStr(sTemp, "men", "80");
									}

									break;
								}

							case "pet":
								{
									// str=40	int=21	dex=30	wit=20	con=43	men=25  pet,summon
									aTemp[17] = "40";
									aTemp[20] = "21";
									aTemp[19] = "30";
									aTemp[21] = "20";
									aTemp[18] = "43";
									aTemp[22] = "25";
									// pet 12564 [sin_eater]
									if ((aTemp[2] ?? "") == "12564")
										sTemp = Libraries.SetNeedParamToStr(sTemp, "con", "1");
									break;
								}

							case "summon":
								{
									// str=40	int=21	dex=30	wit=20	con=43	men=25  pet,summon
									aTemp[17] = "40";
									aTemp[20] = "21";
									aTemp[19] = "30";
									aTemp[21] = "20";
									aTemp[18] = "43";
									aTemp[22] = "25";
									break;
								}

							default:
								{
									// str=40	int=21	dex=30	wit=20	con=43	men=10  citizen and etc
									aTemp[17] = "40";
									aTemp[20] = "21";
									aTemp[19] = "30";
									aTemp[21] = "20";
									aTemp[18] = "43";
									aTemp[22] = "10";
									break;
								}
						}
					}

					// warrior
					outFile.Write(aTemp[11] + Constants.vbTab);

					// 20761
					outFile.Write(aTemp[0] + Constants.vbTab);

					// [pytan]
					sTempForWrite = aTemp[2];
					sTempForWrite = sTempForWrite.ToLower();
					sTempForWrite = sTempForWrite.Replace(@"\", "").Replace("'", "").Replace("-", "").Replace(" ", "_").Replace(".", "_");
					if (string.IsNullOrEmpty(sTempForWrite))
						sTempForWrite = "_noname_" + aTemp[0];
					outFile.Write("[" + sTempForWrite + "]" + Constants.vbTab);

					// level=69
					// If aTemp(1) = "20761" Then
					// Dim asd As Boolean = False
					// End If
					outFile.Write("level=" + aTemp[9] + Constants.vbTab);
					outFile.Write("acquire_exp_rate=" + Conversions.ToString(Conversions.ToDouble(Strings.Format(Conversions.ToDouble(aTemp[23]) / Math.Pow(Conversions.ToDouble(aTemp[9]), 2), "0.####"))) + Constants.vbTab);     // acquire_exp_rate= EXP/lvl^2      'CDbl(Format(iSumChance, "0.####"))     CDbl(CDbl(aTemp(23)) / (CDbl(aTemp(9)) ^ 2))
					outFile.Write("acquire_sp=" + Conversions.ToString(Conversions.ToInteger(Conversions.ToDouble(aTemp[24]))) + Constants.vbTab);

					if ((aTemp[11] ?? "") == "warrior" | (aTemp[11] ?? "") == "boss" | (aTemp[11] ?? "") == "zzoldagu")
						sTempForWrite = "0";
					else
						sTempForWrite = "1";
					outFile.Write("unsowing=" + sTempForWrite + Constants.vbTab);

					outFile.Write("clan={}" + Constants.vbTab);                // not defined
					outFile.Write("ignore_clan_list={}" + Constants.vbTab);
					outFile.Write("clan_help_range=500" + Constants.vbTab);    // not defined

					// slot_rhand=[apprentice_s_rod]	
					// slot_rhand=[doll_knife]	slot_lhand=[doll_knife]	
					sTempForWrite = "[]"; // : If aTemp(34) <> "0" And aTemp(34) <> "NULL" Then sTempForWrite = aItemPch(CInt(aTemp(34)))
					outFile.Write("slot_chest=" + sTempForWrite + "" + Constants.vbTab);          // aTemp(34)
					sTempForWrite = "[]"; if ((aTemp[32] ?? "") != "0" & (aTemp[34] ?? "") != "NULL")
						sTempForWrite = aItemPch[iSlotWeapon].name;
					outFile.Write("slot_rhand=" + sTempForWrite + "" + Constants.vbTab);          // aTemp(32)
					sTempForWrite = "[]"; if ((aTemp[33] ?? "") != "0" & (aTemp[34] ?? "") != "NULL")
						sTempForWrite = aItemPch[iSlotArmor].name;
					outFile.Write("slot_lhand=" + sTempForWrite + "" + Constants.vbTab);          // aTemp(33)

					// item_begin	armor	6721	[shield_of_imperial_warlord_zombie]	item_type=armor	slot_bit_type={lhand}	armor_type=shield	etcitem_type=none	recipe_id=0	blessed=0	weight=1430	default_action=action_equip	consume_type=consume_type_normal	initial_count=1	maximum_count=1	soulshot_count=0	spiritshot_count=0	reduced_soulshot={}	reduced_spiritshot={}	reduced_mp_consume={}	immediate_effect=1	price=0	default_price=39	item_skill=[none]	critical_attack_skill=[none]	attack_skill=[none]	magic_skill=[none]	item_skill_enchanted_four=[none]	material_type=leather	crystal_type=none	crystal_count=0	is_trade=1	is_drop=1	is_destruct=1	physical_damage=0	random_damage=0	weapon_type=none	can_penetrate=0	critical=0	hit_modify=0	avoid_modify=-8	dual_fhit_rate=0	shield_defense=47	shield_defense_rate=20	attack_range=0	damage_range={}	attack_speed=0	reuse_delay=0	mp_consume=0	magical_damage=0	durability=90	damaged=0	physical_defense=0	magical_defense=0	mp_bonus=0	category={}	enchanted=0	html=[item_default.htm]	equip_pet={0}	magic_weapon=0	enchant_enable=0	mana=0	base_attribute_attack={attr_none;0}	base_attribute_defend={0;0;0;0;0;0}	elemental_enable=0	is_deposit=1	equip_cond = {{ec_race;{@RACE_KAMAEL};0}}	item_end

					outFile.Write("shield_defense_rate=" + aItemPch[iSlotArmor].shield_defense_rate + Constants.vbTab);
					outFile.Write("shield_defense=" + aItemPch[iSlotArmor].shield_defense + Constants.vbTab);
					outFile.Write("skill_list={}" + Constants.vbTab);

					sTempForWrite = aTemp[6].Substring(Strings.InStr(aTemp[6], "."), aTemp[6].Length - Strings.InStr(aTemp[6], ".") - 1);
					outFile.Write("npc_ai={[" + sTempForWrite + "]}" + Constants.vbTab);

					outFile.Write("category={}" + Constants.vbTab);
					outFile.Write("race=human" + Constants.vbTab);

					outFile.Write("sex=" + aTemp[10].Replace("'", "") + Constants.vbTab);

					if ((aTemp[11] ?? "") == "citizen" | (aTemp[11] ?? "") == "merchant" | (aTemp[11] ?? "") == "guild_coach" | (aTemp[11] ?? "") == "warehouse_keeper" | (aTemp[11] ?? "") == "teleporter" | (aTemp[11] ?? "") == "blacksmith" | (aTemp[11] ?? "") == "package_keeper" | (aTemp[11] ?? "") == "guild_master" | (aTemp[11] ?? "") == "trainer" | (aTemp[11] ?? "") == "mrkeeper" | (aTemp[11] ?? "") == "monrace" | (aTemp[11] ?? "") == "xmastree" | (aTemp[11] ?? "") == "house_master" | (aTemp[11] ?? "") == "newbie_guide")
					{
						outFile.Write("undying=1" + Constants.vbTab);                  // not defined
						outFile.Write("can_be_attacked=0" + Constants.vbTab);          // not defined
						outFile.Write("corpse_time=7" + Constants.vbTab);              // not defined
						outFile.Write("no_sleep_mode=1" + Constants.vbTab);            // not defined
					}
					else
					{
						outFile.Write("undying=0" + Constants.vbTab);                  // not defined
						outFile.Write("can_be_attacked=1" + Constants.vbTab);          // not defined
						outFile.Write("corpse_time=7" + Constants.vbTab);              // not defined
						outFile.Write("no_sleep_mode=0" + Constants.vbTab);            // not defined
					}

					outFile.Write("agro_range=" + aTemp[30] + Constants.vbTab);
					outFile.Write("ground_high={" + aTemp[37] + ";0;0}" + Constants.vbTab);
					outFile.Write("ground_low={" + aTemp[36] + ";0;0}" + Constants.vbTab);
					outFile.Write("exp=" + aNpcExp[Conversions.ToInteger(aTemp[9])] + Constants.vbTab);
					outFile.Write("org_hp=" + Conversions.ToString(Conversions.ToInteger(Conversions.ToDouble(aTemp[13]) / (Conversions.ToDouble(aTemp[18]) / 100 + 1))) + Constants.vbTab);              // HP=org_hp * (CON_attr/100+1)
					outFile.Write("org_hp_regen=" + aTemp[15] + Constants.vbTab);
					outFile.Write("org_mp=" + Conversions.ToString(Conversions.ToInteger(Conversions.ToDouble(aTemp[14]) / (Conversions.ToDouble(aTemp[22]) / 100 + 1))) + Constants.vbTab);              // MP=org_mp*(MEN_attr/100+1)
					outFile.Write("org_mp_regen=" + aTemp[16] + Constants.vbTab);
					outFile.Write("collision_radius={" + Conversions.ToString(Conversions.ToInteger(aTemp[7])) + ";" + Conversions.ToString(Conversions.ToInteger(aTemp[7])) + "}" + Constants.vbTab);
					outFile.Write("collision_height={" + Conversions.ToString(Conversions.ToInteger(aTemp[8])) + ";" + Conversions.ToString(Conversions.ToInteger(aTemp[8])) + "}" + Constants.vbTab);
					outFile.Write("str=" + aTemp[17] + Constants.vbTab);
					outFile.Write("int=" + aTemp[20] + Constants.vbTab);
					outFile.Write("dex=" + aTemp[19] + Constants.vbTab);
					outFile.Write("wit=" + aTemp[21] + Constants.vbTab);
					outFile.Write("con=" + aTemp[18] + Constants.vbTab);
					outFile.Write("men=" + aTemp[22] + Constants.vbTab);

					// 0     1      2                     3  4 5     6                              7    8    9      10     11         12  13  14   15   16   17 18 19 20   21 22  23   24  25  26 27  28  29  30     31  32 33 34 35 36 37  38 39  40         41
					// (20574,20574,'Elder Tarlk Basilisk',0,'',0,'LineageMonster.lesser_basilisk',34.00,25.00,51,   'male','L2Monster',40,2323,861,10.27,2.45,40,43,30,21,  20,10,3820,291,593,260,281,232,278,500,   333,0,  0,0,  0,35,174,0,  0,'LAST_HIT','true'),


					sTempForWrite = aItemPch[iSlotWeapon].weapon_type;
					if (string.IsNullOrEmpty(sTempForWrite))
						sTempForWrite = "fist";
					outFile.Write("base_attack_type=" + sTempForWrite + Constants.vbTab);                   // from itemdata
					outFile.Write("base_attack_range=" + aTemp[12] + Constants.vbTab);
					if (iSlotWeapon > 0)
					{
						outFile.Write("base_damage_range=" + aItemPch[iSlotWeapon].damage_range + Constants.vbTab);          // from itemdata 'base_damage_range={0;0;80;120}
						outFile.Write("base_rand_dam=" + aItemPch[iSlotWeapon].random_damage + Constants.vbTab);                         // from itemdatabase_rand_dam=7
						outFile.Write("base_physical_attack=" + aTemp[25] + Constants.vbTab);
						outFile.Write("base_critical=" + aItemPch[iSlotWeapon].critical + Constants.vbTab);                   // from itemdata base_critical=12
						outFile.Write("physical_hit_modify=" + aItemPch[iSlotWeapon].hit_modify + Constants.vbTab);          // from itemdata physical_hit_modify=-3.75
					}
					else
					{
						outFile.Write("base_damage_range={0;0;80;120}" + Constants.vbTab);          // from itemdata 'base_damage_range={0;0;80;120}
						outFile.Write("base_rand_dam=7" + Constants.vbTab);                         // from itemdatabase_rand_dam=7
																									// Patk=base_p_attack*(STR_attr/100+1)*lvl_bonus
						outFile.Write("base_physical_attack=" + Conversions.ToString(Conversions.ToDouble(Strings.Format(Conversions.ToDouble(aTemp[25]) / ((Conversions.ToDouble(aTemp[17]) / 100 + 1) * Conversions.ToDouble(aLevelBonus[Conversions.ToInteger(aTemp[9])])), "0.####"))) + Constants.vbTab);
						outFile.Write("base_critical=12" + Constants.vbTab);                   // from itemdata base_critical=12
						outFile.Write("physical_hit_modify=-3.75" + Constants.vbTab);          // from itemdata physical_hit_modify=-3.75
					}
					outFile.Write("base_attack_speed=" + aTemp[29] + Constants.vbTab);
					outFile.Write("base_reuse_delay=" + aItemPch[iSlotWeapon].reuse_delay + Constants.vbTab);                 // from itemdata base_reuse_delay=0

					// outFile.Write("base_magic_attack=" & aTemp(27) & vbTab)             'Matk=base_m_attack*(INT_attr/100+1)*lvl_bonus
					outFile.Write("base_magic_attack=" + Conversions.ToString(Conversions.ToDouble(Strings.Format(Conversions.ToDouble(aTemp[27]) / ((Conversions.ToDouble(aTemp[20]) / 100 + 1) * Conversions.ToDouble(aLevelBonus[Conversions.ToInteger(aTemp[9])])), "#.0000"))) + Constants.vbTab);

					outFile.Write("base_defend=" + Conversions.ToString(Conversions.ToDouble(Strings.Format(Conversions.ToDouble(aTemp[26]) / ((Conversions.ToInteger(aTemp[9]) + 89) / (double)100), "0.####"))) + Constants.vbTab);         // Pdef=base_defend*(level+89)/100
																																																											  // 260
																																																											  // outFile.Write("base_defend=" & aTemp(26) & vbTab)      'Mdef=base_magic_defend*(MEN_attr/100+1)*(level+89)/100
					outFile.Write("base_magic_defend=" + Conversions.ToString(Conversions.ToDouble(Strings.Format(Conversions.ToDouble(aTemp[28]) / ((Conversions.ToInteger(aTemp[22]) / (double)100 + 1) * (Conversions.ToInteger(aTemp[9]) + 89) / 100), "0.####"))) + Constants.vbTab);
					// outFile.Write("base_magic_defend=" & aTemp(28) & vbTab)
					outFile.Write("physical_avoid_modify=0" + Constants.vbTab);
					outFile.Write("soulshot_count=0" + Constants.vbTab);
					outFile.Write("spiritshot_count=0" + Constants.vbTab);
					outFile.Write("hit_time_factor=0.5" + Constants.vbTab);
					outFile.Write("item_make_list={}" + Constants.vbTab);
					outFile.Write("corpse_make_list={}" + Constants.vbTab);
					outFile.Write("additional_make_list={}" + Constants.vbTab);
					outFile.Write("additional_make_multi_list={}" + Constants.vbTab);
					outFile.Write("hp_increase=0" + Constants.vbTab);
					outFile.Write("mp_increase=0" + Constants.vbTab);
					outFile.Write("safe_height=100" + Constants.vbTab);
					outFile.Write("safe_height=100" + Constants.vbTab);

					if ((aTemp[41].Replace("'", "").ToLower() ?? "") == "false")
						sTempForWrite = "0";
					else
						sTempForWrite = "1";
					outFile.Write("drop_herb=" + sTempForWrite + Constants.vbTab);

					outFile.WriteLine("npc_end" + Constants.vbTab);
				}
			}
			outFile.Close();
			inNpcFile.Close();
			ToolStripProgressBar.Value = 0;


			MessageBox.Show("Completed.");
		}

		// npc_begin	warrior	20761	[pytan]	level=69	acquire_exp_rate=8.3592	acquire_sp=3894	unsowing=0	clan={@MALRUK_CLAN}	ignore_clan_list={}	clan_help_range=500	slot_chest=[]	slot_rhand=[]	slot_lhand=[]	
		// shield_defense_rate=0	shield_defense=0	skill_list={}	
		// npc_ai={[pytan];{[MoveAroundSocial]=60};{[MoveAroundSocial1]=60};{[MoveAroundSocial2]=60};{[ShoutTarget]=1};{[SetHateGroup]=@attacker_group};{[SetHateGroupRatio]=20};{[DDMagic]=@s_blood_sucking6}}	
		// category={}	race=demonic	sex=female	undying=0	can_be_attacked=1	corpse_time=7	no_sleep_mode=0	agro_range=1000	ground_high={171.9;0;0}	ground_low={79.2;0;0}	
		// exp=387199547.925	org_hp=2395	org_hp_regen=35.55	org_mp=1458	org_mp_regen=2.78	collision_radius={14;14}	collision_height={40;40}	
		// str=40	int=21	dex=30	wit=20	con=43	men=10	base_attack_type=fist	base_attack_range=40	base_damage_range={0;0;80;120}	base_rand_dam=7	base_physical_attack=779.52	base_critical=12	
		// physical_hit_modify=-3.75	base_attack_speed=247.42	base_reuse_delay=0	base_magic_attack=507.28	base_defend=280.06	base_magic_defend=227.53	
		// physical_avoid_modify=0	soulshot_count=0	spiritshot_count=0	hit_time_factor=0.5	item_make_list={}	
		// corpse_make_list={{[rp_soulshot_a];1;1;2.2134};{[oriharukon_ore];1;1;100};{[stone_of_purity];1;1;100}}	additional_make_list={}	
		// additional_make_multi_list={}	hp_increase=0	mp_increase=0	safe_height=100	drop_herb=0	npc_end


		// 0     1     2       3  4 5  6                             7    8     9  10           11         12  13   14  15    16   17 18 19 20    21 22 23   24  25   26  27  28  29  30    31  32 33 34 35 36 37  38 39 40          41
		// (20761,20761,'Pytan',0,'',0,'LineageMonster.bloody_queen',14.00,40.00,69,'female',    'L2Monster',40,3784,1458,35.55,2.78,40,43,30,21,  20,10,6633,649,1392,418,746,373,278,500,  333, 0, 0, 0, 0,88,191, 0,10,'LAST_HIT','false'),

		// id` decimal(11,0) NOT NULL default '0',

		// idTemplate` int(11) NOT NULL default '0',
		// name` varchar(200) default NULL,
		// serverSideName` int(1) default '0',
		// title` varchar(45) default '',
		// serverSideTitle` int(1) default '0',
		// class` varchar(200) default NULL,
		// collision_radius` decimal(5,2) default NULL,
		// collision_height` decimal(5,2) default NULL,
		// level` decimal(2,0) default NULL,
		// sex` varchar(6) default NULL,

		// type` varchar(22) default NULL,
		// attackrange` int(11) default NULL,
		// hp` decimal(8,0) default NULL,
		// mp` decimal(8,0) default NULL,
		// hpreg` decimal(8,2) default NULL,
		// mpreg` decimal(5,2) default NULL,
		// str` decimal(7,0) default NULL,
		// con` decimal(7,0) default NULL,
		// dex` decimal(7,0) default NULL,
		// int` decimal(7,0) default NULL,

		// wit` decimal(7,0) default NULL,
		// men` decimal(7,0) default NULL,
		// exp` decimal(9,0) default NULL,
		// sp` decimal(8,0) default NULL,
		// patk` decimal(5,0) default NULL,
		// pdef` decimal(5,0) default NULL,
		// matk` decimal(5,0) default NULL,
		// mdef` decimal(5,0) default NULL,
		// atkspd` decimal(3,0) default NULL,
		// aggro` decimal(6,0) default NULL,

		// matkspd` decimal(4,0) default NULL,
		// rhand` decimal(5,0) default NULL,
		// lhand` decimal(5,0) default NULL,
		// armor` decimal(1,0) default NULL,
		// enchant` int(11) NOT NULL default '0',
		// walkspd` decimal(3,0) default NULL,
		// runspd` decimal(3,0) default NULL,
		// isUndead` int(11) default 0,
		// absorb_level` decimal(2,0) default 0,
		// absorb_type` enum('FULL_PARTY','LAST_HIT','PARTY_ONE_RANDOM') DEFAULT 'LAST_HIT' NOT NULL,

		// drop_herbs` enum('true','false') DEFAULT 'false' NOT NULL,


		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
