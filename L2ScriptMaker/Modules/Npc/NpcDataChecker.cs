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
using L2ScriptMaker.Extensions.VbCompatibleHelper;

namespace L2ScriptMaker.Modules.Npc
{
	public partial class NpcDataChecker : Form
	{
		public NpcDataChecker()
		{
			InitializeComponent();
		}

		private string[] aItemPchName = new string[15001];
		private string[] aItemType = new string[15001];

		private bool LoadItemData()
		{
			OpenFileDialog.FileName = "itemdata.txt";

			if (System.IO.File.Exists("itemdata.txt") == false)
			{
				OpenFileDialog.Filter = "Lineage II server item config|itemdata.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return false;
			}

			var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);

			string sTemp;
			string[] aTemp;
			int iTemp;

			ToolStripProgressBar.Value = 0;
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			while (inFile.EndOfStream != true)
			{

				// item_begin	weapon	94	[bech_de_corbin]	item_type=weapon
				// weapon_type=pole

				sTemp = inFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false & sTemp.StartsWith("set_begin") == false)
				{
					aTemp = sTemp.Split((char)9);
					iTemp = Conversions.ToInteger(aTemp[2]);
					if (iTemp >= aItemPchName.Length)
					{
						Array.Resize(ref aItemPchName, iTemp + 1);
						Array.Resize(ref aItemType, iTemp + 1);
					}
					aItemPchName[iTemp] = aTemp[3];
					aItemType[iTemp] = Libraries.GetNeedParamFromStr(sTemp, "weapon_type");
					if ((aItemType[iTemp] ?? "") == "etc")
						aItemType[iTemp] = "fist";
					switch (aItemType[iTemp])
					{
						case "etc":
							{
								aItemType[iTemp] = "fist";
								break;
							}

						case "fishingrod":
							{
								aItemType[iTemp] = "fist";
								break;
							}

						case "dualfist":
							{
								aItemType[iTemp] = "fist";
								break;
							}
					}
				}
			}
			ToolStripProgressBar.Value = 0;
			inFile.Close();

			return true;
		}

		private void StartButton_Click(object sender, EventArgs e)
		{

			// Attention Dialogs
			if (CheckedListBox.CheckedItems.Count == 0)
			{
				MessageBox.Show("Nothing analysing. Select and try again.", "Nothing Analysing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (CheckedListBox.CheckedItems.IndexOf("undying, can_be_attacked") != -1)
			{
				if ((int)MessageBox.Show("Attention! You are selected fix on Undying. Some Quest mobs must be Invulerable. Check logs after finishing fixing." + Constants.vbNewLine + "Continue fixing?", "undying Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == (int)DialogResult.Cancel)
					return;
			}
			// If UnsowingCheckBox.Checked = True Then
			// If MessageBox.Show("Attention! You are selected fix on Unsowing. Some mobs unavailable for sowing. Check logs after finishing fixing." & vbNewLine & "Continue fixing?", "unsowing Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then Exit Sub
			// End If

			if (CheckedListBox.CheckedItems.IndexOf("slot_rhand, base_attack_type") != -1)
			{
				if (LoadItemData() == false)
				{
					MessageBox.Show("Error loading itemdata information. Fix problem and try again", "Error loading itemdata", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			// Dim inFile As New System.IO.StreamReader(OpenFileDialog.FileName & ".bak", System.Text.Encoding.Default, True, 1)
			System.IO.StreamReader inFile;
			string sTemp;
			string sTemp2;
			string[] aTemp;
			string[] aTemp2;
			int iTemp;
			double dTemp;
			var aQuestNpc = new string[1];

			var aRace = new[] { "animal", "dragon", "fairy", "etc", "angel", "construct", "creature", "human", "humanoid", "beast", "undead", "elemental", "demonic", "siege_weapon", "divine", "bug", "plant", "giant", "kamael", "elf", "dwarf", "darkelf", "orc", "castle_guard", "mercenary" };
			var aRaceSkill = new[] { "s_race_animals", "s_race_dragons", "s_race_fairies", "s_race_others", "s_race_angels", "s_race_magic_creatures", "s_race_unknown_creature", "s_race_humans", "s_race_humanoids", "s_race_beasts", "s_race_undead", "s_race_spirits", "s_race_demons", "s_race_siege_weapons", "s_race_divine", "s_race_bugs", "s_race_plants", "s_race_giants", "s_race_kamaels", "s_race_elves", "s_race_dwarves", "s_race_dark_elves", "s_race_orcs", "s_race_defending_army", "s_race_mercenaries" };

			if (CheckedListBox.CheckedItems.IndexOf("unsowing") != -1)
			{
				// Quest Mobs loader
				string sNpcNameE = "npcname-e.txt";
				if (System.IO.File.Exists(sNpcNameE) == false)
				{
					OpenFileDialog.FileName = "";
					OpenFileDialog.Filter = "Lineage II client text file (npcname-e.txt)|npcname-e.txt|All files|*.*";
					if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
						return;
					sNpcNameE = OpenFileDialog.FileName;
				}
				// NpcName-e. Finding ' description=[Quest Monster] '
				inFile = new System.IO.StreamReader(sNpcNameE, System.Text.Encoding.Default, true, 1);
				ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
				ToolStripStatusLabel1.Text = "Loading npcname-e.txt...";
				StatusStrip.Update();

				while (inFile.EndOfStream != true)
				{
					sTemp = inFile.ReadLine();
					ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
					if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
					{
						if (Strings.InStr(sTemp, "Quest Monster") != 0)
						{

							// npc_begin(0)      pet(1)     12077(2)   [pet_wolf_a](3)    level=15(4)
							aTemp = sTemp.Split((char)9);

							iTemp = aQuestNpc.Length;
							Array.Resize(ref aQuestNpc, iTemp + 1);
							aQuestNpc[iTemp - 1] = aTemp[1].Remove(0, Strings.InStr(aTemp[1], "=")).Trim();
						}
					}
				}
				inFile.Close();
				ToolStripProgressBar.Value = 0;
			}
			// End of reading quest mobs

			OpenFileDialog.FileName = "npcdata.txt";
			// If System.IO.File.Exists("npcdata.txt") = False Then
			OpenFileDialog.Filter = "Lineage II server npc config|npcdata*.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			// End If

			System.IO.File.Copy(OpenFileDialog.FileName, OpenFileDialog.FileName + ".bak", true);
			inFile = new System.IO.StreamReader(OpenFileDialog.FileName + ".bak", System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter(OpenFileDialog.FileName, false, System.Text.Encoding.Unicode, 1);
			var outLog = new System.IO.StreamWriter(OpenFileDialog.FileName + "_scriptCheck.log", true, System.Text.Encoding.Unicode, 1);

			outLog.WriteLine("L2ScriptMaker: NpcData Analyser and Fixer.");
			outLog.WriteLine(Conversions.ToString(DateAndTime.Now) + " Start" + Constants.vbNewLine);
			var AttackNpc = new[] { "warrior", "herb_warrior", "boss", "zzoldagu", "summon", "pet", "treasure", "siege_unit", "commander", "castle_gate", "temptrainer", "siege_weapon", "mercenary" };
			var AgroRangeNpc = new[] { "object", "summon", "pet", "treasure", "citizen", "merchant", "warehouse_keeper", "guild_master", "guild_coach", "blacksmith", "package_keeper" };
			// Hellbound Boss's - Derek, Hellinark, Keltas, Typhoon, Archangel [29021] (Baium), 12532-12534 (Dietrich, Mikhail, Gustav), 12539-12543 (Beast Farm Boss's), "Scarlet of Halisha" (form1)
			var iSpecialBoss = new[] { 18465, 22326, 22341, 25539, 29021, 12532, 12533, 12534, 12539, 12540, 12541, 12542, 12543, 29045, 29046 };

			// Skill Loaging END
			// Dim aSkillSymbol() As String = {";", "]"}   '{[DDMagic]=@s_blood_sucking6}  'npc_ai={}
			var aSkills = new string[1];
			int iTempPos1;
			int iTempPos2;
			string sTempSkillName;
			if (CheckedListBox.CheckedItems.IndexOf("npc active skill") != -1)
			{
				OpenFileDialog.FileName = "skill_pch.txt";
				if (System.IO.File.Exists("skill_pch.txt") == false)
				{
					// OpenFileDialog.FileName = "skilldata.txt"
					OpenFileDialog.Filter = "Lineage II server skill config (skill_pch.txt)|skill_pch.txt|All files|*.*";
					if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
						return;
				}

				// ---- Loading 'Skilldata.txt' ---- 
				var inSkillFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);
				ToolStripProgressBar.Maximum = Conversions.ToInteger(inSkillFile.BaseStream.Length);
				// ProgressBar.Text = "Loading skilldata.txt..."

				while (inSkillFile.EndOfStream != true)
				{
					sTemp = inSkillFile.ReadLine().Trim();
					if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
					{
						// skill_begin	skill_name = [s_quiver_of_arrows_a]	/* [?? ?? ???? - A????] */	skill_id = 323	level = 1	operate_type = A1	magic_level = 66	effect = {{i_restoration_random;{{{{[mithril_arrow];700}};30};{{{[mithril_arrow];1400}};50};{{{[mithril_arrow];2800}};20}}}}	is_magic = 1	mp_consume1 = 366	mp_consume2 = 0	item_consume = {[crystal_a];1}	cast_range = -1	effective_range = -1	skill_hit_time = 3	skill_cool_time = 0	skill_hit_cancel_time = 0.5	reuse_delay = 1800	attribute = attr_none	effect_point = 0	target_type = self	affect_scope = single	affect_limit = {0;0}	next_action = none	ride_state = {@ride_none;@ride_wind;@ride_star;@ride_twilight}	skill_end
						// skill_begin	skill_name = [s_summon_cp_potion]	/* [?? CP ??] */	skill_id = 1324	level = 1	operate_type = A1	magic_level = -1	effect = {{i_restoration;[adv_cp_potion];20}}	is_magic = 1	mp_consume1 = 412	mp_consume2 = 0	item_consume = {[soul_ore];50}	cast_range = -1	effective_range = -1	skill_hit_time = 20	skill_cool_time = 0	skill_hit_cancel_time = 0.5	reuse_delay = 1800	attribute = attr_none	effect_point = 0	target_type = self	affect_scope = single	affect_limit = {0;0}	next_action = none	ride_state = {@ride_none;@ride_wind;@ride_star;@ride_twilight}	skill_end
						iTemp = aSkills.Length;
						Array.Resize(ref aSkills, iTemp + 1);
						// aSkills(iTemp - 1) = Libraries.GetNeedParamFromStr(sTemp, "skill_name").Replace("[", "").Replace("]", "")
						sTemp2 = sTemp.Substring(0, Strings.InStr(sTemp, "=") - 1).Trim().Replace("[", "").Replace("]", "");
						aSkills[iTemp - 1] = sTemp2;
					}
					ToolStripProgressBar.Value = Conversions.ToInteger(inSkillFile.BaseStream.Position);
				}

				ToolStripProgressBar.Value = 0;
				inSkillFile.Close();
				this.Refresh();
				StatusStrip.Update();
			}
			// Skill Loaging END

			ToolStripProgressBar.Value = 0;
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripStatusLabel1.Text = "Fixing...";
			this.Update();

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);

				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{

					// npc_begin	zzoldagu	12545	[pirates_zombie_b]	level=57
					// slot_rhand=[mithril_dagger]
					// base_attack_type=dagger

					aTemp = sTemp.Split((char)9);

					// Checking: acquire_exp_rate, acquire_sp
					if (CheckedListBox.CheckedItems.IndexOf("acquire_exp_rate, acquire_sp") != -1)
					{
						dTemp = Conversions.ToDouble(Libraries.GetNeedParamFromStr(sTemp, "acquire_exp_rate"));
						sTemp2 = aTemp[1];

						if ((aTemp[1] ?? "") == "boss")
						{
							if (dTemp < 100)
							{
								sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", Conversions.ToString(dTemp * 100));
								outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "Now: acquire_exp_rate->" + Conversions.ToString(dTemp * 100));
							}
						}

						if ((aTemp[1] ?? "") != "warrior" & (aTemp[1] ?? "") != "herb_warrior" & (aTemp[1] ?? "") != "boss")
						{
							if (dTemp > 0)
							{
								sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_exp_rate", "0");
								sTemp = Libraries.SetNeedParamToStr(sTemp, "acquire_sp", "0");
								outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "Now: acquire_exp_rate->0, acquire_sp->0");
							}
						}
					}
					// Checking: acquire_exp_rate END


					// Checking: Unsowing (unsowing=0)
					// race=castle_guard
					if (CheckedListBox.CheckedItems.IndexOf("unsowing") != -1)
					{
						sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "race");
						if ((Libraries.GetNeedParamFromStr(sTemp, "unsowing") ?? "") == "0")
						{
							if ((aTemp[1] ?? "") == "warrior" | (aTemp[1] ?? "") == "herb_warrior")
							{
								// Exception for Castle Guard
								// npc_begin(0)      pet(1)     12077(2)   [pet_wolf_a](3)    level=15(4)
								aTemp = sTemp.Split((char)9);
								if ((sTemp2 ?? "") == "castle_guard" | (sTemp2 ?? "") == "mercenary" | Array.IndexOf(aQuestNpc, aTemp[2]) != -1)
								{
									sTemp = Libraries.SetNeedParamToStr(sTemp, "unsowing", "1");
									outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "Now: unsowing->1");
								}
								else
									// Attention!
									if (NoWarriorCheckBox.Checked == false)
								{
									// If UnsowingCheckBox.Checked = True Then
									if ((Libraries.GetNeedParamFromStr(sTemp, "unsowing") ?? "") == "1")
									{
										sTemp = Libraries.SetNeedParamToStr(sTemp, "unsowing", "0");
										outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "Now: unsowing->0");
									}
								}
							}
							else if ((Libraries.GetNeedParamFromStr(sTemp, "unsowing") ?? "") == "0")
							{
								sTemp = Libraries.SetNeedParamToStr(sTemp, "unsowing", "1");
								outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "Now: unsowing->1");
							}
						}
						else
						{
						}
					}
					// Checking: Unsowing END


					// Checking: Weapon Type (slot_rhand, base_attack_type)
					if (CheckedListBox.CheckedItems.IndexOf("slot_rhand, base_attack_type") != -1)
					{
						sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "slot_rhand");
						if ((sTemp2 ?? "") == "[]")
						{
							if ((Libraries.GetNeedParamFromStr(sTemp, "base_attack_type") ?? "") != "fist")
							{
								// sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "fist")
								// base_attack_type=fist	base_attack_range=40	base_damage_range={0;0;80;120}	base_rand_dam=7
								sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "fist");
								sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "40");
								sTemp = Libraries.SetNeedParamToStr(sTemp, "base_damage_range", "{0;0;80;120}");
								sTemp = Libraries.SetNeedParamToStr(sTemp, "base_rand_dam", "7");
								sTemp = Libraries.SetNeedParamToStr(sTemp, "base_critical", "4");
								outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "Now: " + sTemp2 + " base_attack_type -> fist");
							}
						}
						else
						{
							iTemp = Array.IndexOf(aItemPchName, sTemp2);
							if (iTemp == -1)
							{
								outLog.WriteLine("Unknown weapon:" + aTemp[1] + Constants.vbTab + Constants.vbTab + sTemp2 + Constants.vbTab + "Npc: " + aTemp[2] + Constants.vbTab + aTemp[3]);
								sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "fist");
								sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "40");
								sTemp = Libraries.SetNeedParamToStr(sTemp, "base_damage_range", "{0;0;80;120}");
								sTemp = Libraries.SetNeedParamToStr(sTemp, "base_rand_dam", "7");
								sTemp = Libraries.SetNeedParamToStr(sTemp, "base_critical", "4");
							}
							else if ((Libraries.GetNeedParamFromStr(sTemp, "base_attack_type") ?? "") != (aItemType[iTemp] ?? ""))
							{
								switch (aItemType[iTemp])
								{
									case "dual":
										{
											// base_attack_type=dual	base_attack_range=40	base_damage_range={0;0;80;120}	base_rand_dam=30
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "dual");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "40");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_damage_range", "{0;0;80;120}");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_rand_dam", "30");
											break;
										}

									case "pole":
										{
											// base_attack_type=pole	base_attack_range=80	base_damage_range={0;0;300;120}	base_rand_dam=30
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "pole");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "80");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_damage_range", "{0;0;300;120}");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_rand_dam", "30");
											break;
										}

									case "bow":
										{
											// base_attack_type=bow	base_attack_range=500	base_damage_range={0;0;10;0}	base_rand_dam=5
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "bow");
											if ((Libraries.GetNeedParamFromStr(sTemp, "race") ?? "") == "castle_guard")
												sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "1100");
											else
												sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "500");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_damage_range", "{0;0;10;0}");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_rand_dam", "5");
											break;
										}

									case "dagger":
										{
											// base_attack_type=dagger	base_attack_range=40	base_damage_range={0;0;80;120}	base_rand_dam=10
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "dagger");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "40");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_damage_range", "{0;0;80;120}");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_rand_dam", "10");
											break;
										}

									case "sword":
										{
											// base_attack_type=sword	base_attack_range=40	base_damage_range={0;0;80;120}	base_rand_dam=30
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "dagger");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "40");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_damage_range", "{0;0;80;120}");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_rand_dam", "30");
											break;
										}

									case "blunt":
										{
											// base_attack_type=blunt	base_attack_range=40	base_damage_range={0;0;80;120}	base_rand_dam=50
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "dagger");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "40");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_damage_range", "{0;0;80;120}");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_rand_dam", "50");
											break;
										}

									default:
										{
											// base_attack_type=fist	base_attack_range=40	base_damage_range={0;0;80;120}	base_rand_dam=7
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", "fist");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "40");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_damage_range", "{0;0;80;120}");
											sTemp = Libraries.SetNeedParamToStr(sTemp, "base_rand_dam", "7");
											break;
										}
								}
								// check for fishingrod
								// sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_type", aItemType(iTemp))
								outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "Now: " + sTemp2 + " base_attack_type -> " + aItemType[iTemp]);
							}
						}
					}
					// Checking: Weapon Type END

					// Checking: no_sleep_mode (no_sleep_mode)
					if (CheckedListBox.CheckedItems.IndexOf("no_sleep_mode") != -1)
					{
						switch (Libraries.GetNeedParamFromStr(sTemp, "no_sleep_mode"))
						{
							case "0":
								{
									if ((aTemp[1] ?? "") == "boss" | (aTemp[1] ?? "") == "zzoldagu")
									{
										sTemp = Libraries.SetNeedParamToStr(sTemp, "no_sleep_mode", "1");
										outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "Now: no_sleep_mode->1");
									}

									break;
								}

							case "1":
								{
									if ((aTemp[1] ?? "") != "boss" & (aTemp[1] ?? "") != "zzoldagu")
									{
										sTemp = Libraries.SetNeedParamToStr(sTemp, "undying", "0");
										outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "Now: no_sleep_mode->0");
									}

									break;
								}
						}
					}
					// Checking: no_sleep_mode END

					// Checking: agro_range (agro_range)
					if (CheckedListBox.CheckedItems.IndexOf("agro_range") != -1)
					{
						switch (Libraries.GetNeedParamFromStr(sTemp, "agro_range"))
						{
							case "0":
								{
									if (Array.IndexOf(AgroRangeNpc, aTemp[1]) == -1)
									{
										sTemp = Libraries.SetNeedParamToStr(sTemp, "agro_range", "1000");
										outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "Now: agro_range->1000");
									}

									break;
								}

							default:
								{
									if (Array.IndexOf(AgroRangeNpc, aTemp[1]) != -1)
									{
										sTemp = Libraries.SetNeedParamToStr(sTemp, "agro_range", "0");
										outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "Now: agro_range->0");
									}

									break;
								}
						}
					}
					// Checking: agro_range END

					// Checking: Undying (undying, can_be_attacked)
					if (CheckedListBox.CheckedItems.IndexOf("undying, can_be_attacked") != -1)
					{
						if (Array.IndexOf(AttackNpc, aTemp[1]) != -1)
						{
							// This a No Peace NPC.

							if ((aTemp[1] ?? "") == "warrior" | (aTemp[1] ?? "") == "herb_warrior")
							{
								if (NoWarriorUndCheckBox.Checked == false)
								{
									if ((Libraries.GetNeedParamFromStr(sTemp, "undying") ?? "") == "1")
									{
										sTemp = Libraries.SetNeedParamToStr(sTemp, "undying", "0");
										sTemp = Libraries.SetNeedParamToStr(sTemp, "can_be_attacked", "1");
										outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "Now: undying->0, can_be_attacked->1");
									}
								}
							}
							else if ((Libraries.GetNeedParamFromStr(sTemp, "undying") ?? "") == "1")
							{
								sTemp = Libraries.SetNeedParamToStr(sTemp, "undying", "0");
								sTemp = Libraries.SetNeedParamToStr(sTemp, "can_be_attacked", "1");
								outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "Now: undying->0, can_be_attacked->1");
							}
						}
						else
// This a Peace NPC.
if ((aTemp[1] ?? "") == "guard")
						{
							if ((Libraries.GetNeedParamFromStr(sTemp, "undying") ?? "") != "0" & (Libraries.GetNeedParamFromStr(sTemp, "can_be_attacked") ?? "") != "0")
							{
								sTemp = Libraries.SetNeedParamToStr(sTemp, "undying", "0");
								sTemp = Libraries.SetNeedParamToStr(sTemp, "can_be_attacked", "0");
								outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "Now: undying->0, can_be_attacked->0");
							}
						}
						else if ((Libraries.GetNeedParamFromStr(sTemp, "undying") ?? "") == "0")
						{
							sTemp = Libraries.SetNeedParamToStr(sTemp, "undying", "1");
							sTemp = Libraries.SetNeedParamToStr(sTemp, "can_be_attacked", "0");
							outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "Now: undying->1, can_be_attacked->0");
						}
					}
					// Checking: Undying END

					// Checking: npc active skill
					if (CheckedListBox.CheckedItems.IndexOf("npc active skill") != -1)
					{

						// Dim aSkillSymbol() As String = {";", "]"}   '{[DDMagic]=@s_blood_sucking6}  'npc_ai={}
						// Dim iTempPos1 As Integer, iTempPos2 As Integer
						// Dim sTempSkillName As String
						sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "npc_ai").Replace(Conversions.ToString((char)9), "").Replace(" ", "");
						iTempPos1 = Strings.InStr(sTemp2, "]=@s_");
						while (iTempPos1 > 0)
						{
							iTempPos1 += 2;
							iTempPos2 = Strings.InStr(iTempPos1, sTemp2, "}") - 1;
							sTempSkillName = sTemp2.Substring(iTempPos1, iTempPos2 - iTempPos1);

							if (Array.IndexOf(aSkills, sTempSkillName) == -1)
								// npc_begin	zzoldagu	12545	[pirates_zombie_b]	level=57
								outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "Found undefined active skill: " + sTempSkillName);

							iTempPos1 = Strings.InStr(iTempPos2, sTemp2, "]=@s_");
						}
						if (iTempPos1 > 0)
						{
						}
					}
					// Checking: npc active skill


					// Checking: castle bowguard range
					if (CheckedListBox.CheckedItems.IndexOf("castle bowguard range") != -1)
					{
						if ((Libraries.GetNeedParamFromStr(sTemp, "race") ?? "") == "castle_guard")
						{
							if ((Libraries.GetNeedParamFromStr(sTemp, "base_attack_type") ?? "") == "bow")
							{
								if ((Libraries.GetNeedParamFromStr(sTemp, "base_attack_range") ?? "") != "1100")
								{
									sTemp = Libraries.SetNeedParamToStr(sTemp, "base_attack_range", "1100");
									outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "Now: castle bowguard range is 1100");
								}
							}
						}
					}
					// Checking: castle bowguard range

					// Checking: npc race (Use passive skills for define race)
					if (CheckedListBox.CheckedItems.IndexOf("npc race") != -1)
					{

						// none		- (forms, алтари, агашены)
						// animal		s_race_animals
						// dragon		s_race_dragons
						// fairy		s_race_fairies
						// etc		s_race_others
						// angel		s_race_angels
						// construct	s_race_magic_creatures
						// creature	s_race_unknown_creature
						// human		s_race_humans
						// humanoid	s_race_humanoids
						// beast		s_race_beasts
						// undead		s_race_undead
						// elemental	s_race_spirits
						// demonic	s_race_demonic
						// siege_weapon	s_race_siege_weapons
						// divine		s_race_divine
						// bug		s_race_bugs
						// plant		s_race_plants
						// giant		s_race_giants
						// kamael		s_race_kamaels
						// elf		s_race_elves
						// dwarf		s_race_dwarves
						// darkelf	s_race_dark_elves
						// orc		s_race_orcs
						// castle_guard	s_race_defending_army
						// mercenary	s_race_mercenaries

						// skill_list={@s_race_fairies;@s_summon_magic_defence}	
						aTemp2 = Libraries.GetNeedParamFromStr(sTemp, "skill_list").Replace("{", null).Replace("}", null).Replace("@", null).Split(Conversions.ToChar(";"));
						if ((Libraries.GetNeedParamFromStr(sTemp, "skill_list") ?? "") != "{}")
						{
							var loopTo = aTemp2.Length - 1;
							for (iTemp = 0; iTemp <= loopTo; iTemp++)
							{
								if (Array.IndexOf(aRaceSkill, aTemp2[iTemp]) != -1)
								{
									iTemp = Array.IndexOf(aRaceSkill, aTemp2[iTemp]);
									if ((aRace[iTemp] ?? "") != (Libraries.GetNeedParamFromStr(sTemp, "race") ?? ""))
									{
										// Fix race
										sTempSkillName = Libraries.GetNeedParamFromStr(sTemp, "race");
										sTemp = Libraries.SetNeedParamToStr(sTemp, "race", aRace[iTemp]);
										outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "Now: race=" + sTempSkillName + " -> " + aRace[iTemp] + Constants.vbTab + "where skill_list=" + Libraries.GetNeedParamFromStr(sTemp, "skill_list"));
									}
									iTemp = aTemp2.Length;
									break;
								}
							}
							// checking: found race or not
							if (iTemp == aTemp2.Length)
								sTemp2 = "none";
						}
						else if ((Libraries.GetNeedParamFromStr(sTemp, "race") ?? "") != "none")
						{
							// Fix race
							sTempSkillName = Libraries.GetNeedParamFromStr(sTemp, "race");
							if ((aTemp[2] ?? "") == "warrior" | (aTemp[2] ?? "") == "boss" | (aTemp[2] ?? "") == "zzoldagu")
								sTemp = Libraries.SetNeedParamToStr(sTemp, "race", "etc");
							else
								sTemp = Libraries.SetNeedParamToStr(sTemp, "race", "none");
							outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "Now: race=" + sTempSkillName + " -> none");
						}
					}
					// Checking: npc race end

					// Checking: stats (str,int,dex,wit,con,men) end
					if (CheckedListBox.CheckedItems.IndexOf("stats (str,int,dex,wit,con,men)") != -1)
					{

						// BOSS/Mobs Stats bug fix!
						// doppelganger, pc_trap
						if (CheckBoxZzoldagu74.Checked == true)
						{
							if ((aTemp[1] ?? "") == "zzoldagu" & Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "level")) >= 74)
								aTemp[1] = "boss";
						}

						// Dim iSpecialBoss() As Integer = {18465, 22326, 22341, 25539} ' Hellbound Boss's - Derek, Hellinark, Keltas, Typhoon
						if (Array.IndexOf(iSpecialBoss, Conversions.ToInteger(aTemp[2])) != -1)
							aTemp[1] = "boss";

						sTemp2 = sTemp;
						switch (aTemp[1])
						{
							case "boss":
								{
									// str=60	int=76	dex=73	wit=70	con=57	men=80  boss
									sTemp = Libraries.SetNeedParamToStr(sTemp, "str", "60");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "int", "76");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "dex", "73");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "wit", "70");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "con", "57");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "men", "80");
									break;
								}

							case "zzoldagu":
								{
									// str=40	int=41	dex=30	wit=20	con=43	men=10  zzoldagu
									sTemp = Libraries.SetNeedParamToStr(sTemp, "str", "40");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "int", "41");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "dex", "30");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "wit", "20");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "con", "43");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "men", "10");
									break;
								}

							case "warrior":
								{
									// str=40	int=41	dex=30	wit=20	con=43	men=10  warrior
									sTemp = Libraries.SetNeedParamToStr(sTemp, "str", "40");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "int", "21");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "dex", "30");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "wit", "20");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "con", "43");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "men", "10");

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
									sTemp = Libraries.SetNeedParamToStr(sTemp, "str", "40");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "int", "21");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "dex", "30");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "wit", "20");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "con", "43");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "men", "25");

									// pet 12564 [sin_eater]
									if ((aTemp[2] ?? "") == "12564")
										sTemp = Libraries.SetNeedParamToStr(sTemp, "con", "1");
									break;
								}

							case "summon":
								{
									// str=40	int=21	dex=30	wit=20	con=43	men=25  pet,summon
									sTemp = Libraries.SetNeedParamToStr(sTemp, "str", "40");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "int", "21");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "dex", "30");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "wit", "20");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "con", "43");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "men", "25");
									break;
								}

							default:
								{
									// str=40	int=21	dex=30	wit=20	con=43	men=10  citizen and etc
									sTemp = Libraries.SetNeedParamToStr(sTemp, "str", "40");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "int", "21");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "dex", "30");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "wit", "20");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "con", "43");
									sTemp = Libraries.SetNeedParamToStr(sTemp, "men", "10");
									break;
								}
						}
						if ((sTemp2 ?? "") != (sTemp ?? ""))
							outLog.WriteLine("Fixed: " + aTemp[1] + Constants.vbTab + aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + "New stats (str,int,dex,wit,con,men) now.");
					}
				}
				outFile.WriteLine(sTemp);
			}


			ToolStripProgressBar.Value = 0;
			outLog.WriteLine(Conversions.ToString(DateAndTime.Now) + " End");
			outLog.WriteLine();

			outLog.Close();
			inFile.Close();
			outFile.Close();

			MessageBox.Show("Complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
