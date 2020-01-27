using L2ScriptMaker.Extensions;
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

namespace L2ScriptMaker.Modules.ZeroScripts
{
	public partial class SkillDataGeneratorCT1 : Form
	{
		public SkillDataGeneratorCT1()
		{
			InitializeComponent();
		}

		private struct SkillBone
		{
			public short type;
			public string name;
			public string desc;  // name - name of skill from skillname-e.dat
			public int is_magic;
			public int mp_consume1;
			public int mp_consume2;
			public int hp_consume;
			public int cast_range;
			public double hit_time;
			public short debuff;
			// Dim is_ench As Short
			public int ench_skill_id;
		}

		private string[] aSkillName = new string[2];

		private SkillBone[,] aSkill = new SkillBone[27001, 801];

		private void StartButton_Click(object sender, EventArgs e)
		{

			// Dim EnchantChance() As Integer = {99, 98, 97, 96, 95, 94, 92, 90, 86, 80, 74, 60, 50, 40, 30, 20, 10, 5, 5, 3, 3, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0}
			// Dim EnchantChance() As Integer = {99, 98, 98, 98, 96, 96, 95, 88, 88, 86!!!, 84, 80, 76, 72, 68, 52, 46, 42, 38, 34, 30, 28, 24, 22, 20, 18, 16, 14, 12, 10, 8}
			// CT1 last stable
			// Dim EnchantChance() As Integer = {99, 99, 99, 98, 98, 98, 97, 95, 92, 88, 83, 78, 72, 66, 60, 54, 48, 42, 36, 30, 25, 21, 17, 13, 10, 8, 6, 4, 3, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0}

			var EnchantChance = new[] { 97, 95, 93, 91, 89, 87, 84, 81, 78, 74, 70, 66, 62, 58, 54, 50, 46, 42, 38, 34, 30, 26, 22, 18, 14, 10, 6, 4, 2, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

			var EnchantChance1 = new[] { 98, 88, 78, 68, 58, 48, 38, 28, 18, 8, 7, 6, 5, 4, 3, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

			string sSkillGrpFile = "skillgrp.txt";       // Name/path of skillgrp.txt file
			string sSkillnameEFile = "skillname-e.txt";      // Name/path of skillname-e.txt file
			string sSkillDataFile = "skilldata.txt";      // Name/path of skilldata.txt file
			string sSkillEncFile = "skillenchantdata.txt";      // Name/path of skilldata.txt file
			string sSkillPchFile = "skill_pch.txt";
			string sTemp;

			// ExistPchCheckBox

			// skillgrp_begin	skill_id=1398	skill_level=101	oper_type=0	mp_consume=103	cast_range=900	cast_style=1	hit_time=4.000000	is_magic=1	ani_char=[f]	desc=[skill.su.1069]	icon_name=[icon.skill1398]	extra_eff=0	is_ench=1	ench_skill_id=10	hp_consume=0	UNK_0=9	UNK_1=11	skillgrp_end

			int iTemp;

			if (System.IO.File.Exists(sSkillGrpFile) == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Filter = "Lineage II client text file (skillgrp.txt)|skillgrp.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				sSkillGrpFile = OpenFileDialog.FileName;
			}

			if (System.IO.File.Exists(sSkillnameEFile) == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Filter = "Lineage II client text file (skillname-e.txt)|skillname-e.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				sSkillnameEFile = OpenFileDialog.FileName;
			}

			if (ExistPchCheckBox.Checked == true)
			{
				if (System.IO.File.Exists(sSkillPchFile) == false)
				{
					OpenFileDialog.FileName = "";
					OpenFileDialog.Filter = "Lineage II client text file (skill_pch.txt)|skill_pch.txt|All files|*.*";
					if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
						return;
					sSkillPchFile = OpenFileDialog.FileName;
				}
				if (SkillPchLoad(sSkillPchFile) == false)
					return;
			}

			SaveFileDialog.FileName = sSkillDataFile;
			SaveFileDialog.Filter = "Lineage II server enchant skill script (skilldata.txt)|skilldata*.txt|All files|*.*";
			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sSkillDataFile = SaveFileDialog.FileName;

			SaveFileDialog.FileName = sSkillEncFile;
			SaveFileDialog.Filter = "Lineage II server skill script (skillenchantdata.txt)|skillenchantdata*.txt|All files|*.*";
			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sSkillEncFile = SaveFileDialog.FileName;

			System.IO.StreamReader inFile;
			int iId;
			int iLevel;

			// ---- Loading 'Skillname-e.txt' ---- 
			inFile = new System.IO.StreamReader(sSkillnameEFile, true);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading skilldata-e.txt...";

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{

					// skillname_begin	id=3	level=1	name=[Power Strike]	description=[Gathers power for a fierce strike. Used when equipped with a sword or blunt weapon. Over-hit is possible.  Power 25.]	desc_add1=[none]	desc_add2=[none]	skillname_end
					iId = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "id"));
					iLevel = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "level"));
					aSkill[iId, iLevel].desc = Libraries.GetNeedParamFromStr(sTemp, "name");
				}
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				StatusStrip.Update();
			}
			ToolStripProgressBar.Value = 0;
			inFile.Close();
			this.Refresh();

			// ---- Loading 'Skillgrp.txt' ---- 
			inFile = new System.IO.StreamReader(sSkillGrpFile, true);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading Skillgrp.txt";
			long sTempVar;

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{
					iId = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "skill_id"));
					iLevel = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "skill_level"));

					if (iId >= 27000 | iLevel >= 800)
					{
						MessageBox.Show("Array out:" + Constants.vbNewLine + sTemp);
						ToolStripProgressBar.Value = 0;
						inFile.Close();
						return;
					}

					aSkill[iId, iLevel].type = Conversions.ToShort(Libraries.GetNeedParamFromStr(sTemp, "oper_type"));
					aSkill[iId, iLevel].is_magic = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "is_magic"));
					aSkill[iId, iLevel].mp_consume2 = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "mp_consume"));
					aSkill[iId, iLevel].hp_consume = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "hp_consume"));
					sTempVar = Conversions.ToLong(Libraries.GetNeedParamFromStr(sTemp, "cast_range"));
					if (sTempVar > 1000000)
						sTempVar = -1;
					aSkill[iId, iLevel].cast_range = Conversions.ToInteger(sTempVar);
					aSkill[iId, iLevel].hit_time = Conversions.ToDouble(Libraries.GetNeedParamFromStr(sTemp, "hit_time"));
					aSkill[iId, iLevel].debuff = Conversions.ToShort(Libraries.GetNeedParamFromStr(sTemp, "debuff"));
					if (aSkill[iId, iLevel].debuff == 4)
						aSkill[iId, iLevel].is_magic = 2;
					if (aSkill[iId, iLevel].debuff == 3)
						aSkill[iId, iLevel].debuff = Conversions.ToShort(1);
					else
						aSkill[iId, iLevel].debuff = Conversions.ToShort(0);
					// aSkill(iId, iLevel).is_ench = CShort(Libraries.GetNeedParamFromStr(sTemp, "is_ench"))
					aSkill[iId, iLevel].ench_skill_id = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "ench_skill_id"));
				}
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				StatusStrip.Update();
			}
			ToolStripProgressBar.Value = 0;
			inFile.Close();
			this.Refresh();

			string sTemp2;

			if (System.IO.File.Exists(sSkillDataFile) == true)
				System.IO.File.Copy(sSkillDataFile, sSkillDataFile + ".bak", true);
			var outFile = new System.IO.StreamWriter(sSkillDataFile, false, System.Text.Encoding.Unicode, 1);
			var outEncFile = new System.IO.StreamWriter(sSkillEncFile, false, System.Text.Encoding.Unicode, 1);
			// skill_begin	skill_name=[s_long_range_shot1]	/* [롱 샷] */	skill_id=113	level=1	operate_type=P	magic_level=20	effect={{p_attack_range;{bow};200;diff}}	skill_end

			// skillgrp_begin	skill_id=3	skill_level=1	oper_type=0	mp_consume=10	cast_range=40	hit_time=1.080000	is_magic=0	desc=[]	hp_consume=0	skillgrp_end
			// skillenchantdata.txt
			// enchant_skill_begin	original_skill = [s_hate192]	route_id = 1	enchant_id = 1	skill_level = 101	exp = 3060000	sp = 306000	item_needed = {{[codex_of_giant];1}}	prob_76 = 82	prob_77 = 92	prob_78 = 97	enchant_skill_end

			ToolStripProgressBar.Maximum = 10000;
			ToolStripStatusLabel.Text = "Saving new skilldata.txt...";
			int iRouteId = 0;
			int iEnchId = 0;
			string sEnchName = "";

			for (iId = 0; iId <= 10000; iId++)
			{
				for (iLevel = 0; iLevel <= 700; iLevel++)
				{
					if (aSkill[iId, iLevel].desc != null)
					{
						sTemp = "";

						if (Shema1RadioButton.Checked == true)
						{
							// shema1
							// NPC Spinning Slasher
							sTemp2 = aSkill[iId, iLevel].desc.Trim().ToLower().Replace(" - ", "_").Replace("'", "").Replace(":", "").Replace(".", "").Replace(",", "");
							sTemp2 = sTemp2.Replace("%", "").Replace("!", "").Replace("&", "").Replace("-", "_");
							sTemp2 = sTemp2.Replace(" ", "_").Replace(" ", "_").Replace("[", "").Replace("]", "").Replace("_of_", "_").Replace("_the_", "_");
							sTemp2 = sTemp2.Replace("(", "").Replace(")", "_").Replace("/", "_");
							sTemp2 = "s_" + sTemp2; // & iLevel

							// Fix for first level of skill with more them 1 level
							if (iLevel == 1)
							{

								// s_npc_selfdamage_shield
								// s_npc_self_damage_shield

								if (string.IsNullOrEmpty(aSkill[iId, iLevel + 1].desc) | aSkill[iId, iLevel + 1].desc == null)
								{
									// this skill first and alone in this skill_id
									if (Array.IndexOf(aSkillName, sTemp2) == -1)
										sTemp2 = sTemp2;
									else
										sTemp2 = sTemp2 + "_" + Conversions.ToString(iId);// s_dragon3
									Array.Resize(ref aSkillName, aSkillName.Length + 1);
									aSkillName[aSkillName.Length - 1] = sTemp2;
								}
								else
								{
									if (Array.IndexOf(aSkillName, sTemp2 + Conversions.ToString(iLevel)) == -1)
										sTemp2 = sTemp2 + Conversions.ToString(iLevel);
									else
										sTemp2 = sTemp2 + "_" + Conversions.ToString(iId) + "_" + Conversions.ToString(iLevel);// s_triple_slash3433_1
									Array.Resize(ref aSkillName, aSkillName.Length + 1);
									aSkillName[aSkillName.Length - 1] = sTemp2;
								}
							}
							else
							{
								// Dublicate fix
								if (Array.IndexOf(aSkillName, sTemp2 + Conversions.ToString(iLevel)) == -1)
									sTemp2 = sTemp2 + Conversions.ToString(iLevel);
								else
									// sTemp2 = "s_none_" & iId & "_" & iLevel    ' s_none_3433_1
									sTemp2 = sTemp2 + "_" + Conversions.ToString(iId) + "_" + Conversions.ToString(iLevel);// s_triple_slash3433_1
								Array.Resize(ref aSkillName, aSkillName.Length + 1);
								aSkillName[aSkillName.Length - 1] = sTemp2;
							}
						}
						else
							sTemp2 = "s_" + Conversions.ToString(iId) + "_" + Conversions.ToString(iLevel);

						// --- Exist skill_pch base ---
						if (ExistPchCheckBox.Checked == true)
						{
							if (aSkill[iId, iLevel].name == null)
								aSkill[iId, iLevel].name = "[" + sTemp2 + "]";
							//else
							//	int ajshj = 0;
						}
						else
							aSkill[iId, iLevel].name = "[" + sTemp2 + "]";

						if (AllPassiveCheckBox.Checked == true)
							// Generate all like (P)assive skill
							aSkill[iId, iLevel].type = Conversions.ToShort(2);

						// --- Common Header for all types
						sTemp = sTemp + "skill_begin" + Constants.vbTab;
						sTemp = sTemp + "skill_name=" + aSkill[iId, iLevel].name + Constants.vbTab;
						if (DontDescCheckBox.Checked == false)
							sTemp = sTemp + "/* " + aSkill[iId, iLevel].desc + " */" + Constants.vbTab;
						sTemp = sTemp + "skill_id=" + Conversions.ToString(iId) + Constants.vbTab;
						sTemp = sTemp + "level=" + Conversions.ToString(iLevel) + Constants.vbTab;
						switch (aSkill[iId, iLevel].type)
						{
							case var @case when @case == Conversions.ToShort(0
						   ):
								{
									sTemp = sTemp + "operate_type=A1" + Constants.vbTab;
									break;
								}

							case var case1 when case1 == Conversions.ToShort(1
					 ):
								{
									sTemp = sTemp + "operate_type=A2" + Constants.vbTab;
									break;
								}

							case var case2 when case2 == Conversions.ToShort(2
					 ):
								{
									sTemp = sTemp + "operate_type=P" + Constants.vbTab;
									break;
								}

							case var case3 when case3 == Conversions.ToShort(3
					 ):
								{
									sTemp = sTemp + "operate_type=T" + Constants.vbTab;
									break;
								}

							default:
								{
									MessageBox.Show("Unknown operate_type=: " + Conversions.ToString(aSkill[iId, iLevel].type));
									sTemp = sTemp + "operate_type=P" + Constants.vbTab;
									break;
								}
						}
						sTemp = sTemp + "magic_level=1" + Constants.vbTab;
						sTemp = sTemp + "effect={}" + Constants.vbTab;
						// --- End of Common Header of skill


						// sTemp = sTemp & "=" & aSkill(iId, iLevel).desc & vbTab
						switch (aSkill[iId, iLevel].type)
						{
							case var case4 when case4 == Conversions.ToShort(0  // A1
						   ):
								{
									// is_magic = 1	
									sTemp = sTemp + "is_magic=" + Conversions.ToString(aSkill[iId, iLevel].is_magic) + Constants.vbTab;

									if (aSkill[iId, iLevel].is_magic == 0)
										// hp_consume = 7	
										// mp_consume1 = 7	
										iTemp = 0;
									else
									{
										iTemp = Conversions.ToInteger(aSkill[iId, iLevel].mp_consume2 / (double)5);
										sTemp = sTemp + "mp_consume1=" + Conversions.ToString(iTemp) + Constants.vbTab;
									}
									// mp_consume2 = 28	
									sTemp = sTemp + "mp_consume2=" + Conversions.ToString(aSkill[iId, iLevel].mp_consume2 - iTemp) + Constants.vbTab;

									if (aSkill[iId, iLevel].hp_consume != default(int))
										// hp_consume = 7	
										sTemp = sTemp + "hp_consume=" + Conversions.ToString(aSkill[iId, iLevel].hp_consume) + Constants.vbTab;

									// cast_range = -1	
									sTemp = sTemp + "cast_range=" + Conversions.ToString(aSkill[iId, iLevel].cast_range) + Constants.vbTab;
									// effective_range = -1	
									if (aSkill[iId, iLevel].cast_range == -1)
										sTemp = sTemp + "effective_range=-1" + Constants.vbTab;
									else
										sTemp = sTemp + "effective_range=" + Conversions.ToString(Conversions.ToInteger(aSkill[iId, iLevel].cast_range * 1.5)) + Constants.vbTab;

									// skill_hit_time = 4	
									sTemp = sTemp + "skill_hit_time=" + Conversions.ToString(aSkill[iId, iLevel].hit_time) + Constants.vbTab;
									// skill_cool_time = 0	
									sTemp = sTemp + "skill_cool_time=0" + Constants.vbTab;
									// skill_hit_cancel_time = 0.5	
									sTemp = sTemp + "skill_hit_cancel_time=0" + Constants.vbTab;
									// reuse_delay = 6	
									sTemp = sTemp + "reuse_delay=" + Conversions.ToString(aSkill[iId, iLevel].hit_time) + Constants.vbTab;

									// attribute = attr_none	
									sTemp = sTemp + "attribute=attr_none" + Constants.vbTab;
									// effect_point = 379	
									sTemp = sTemp + "effect_point=0" + Constants.vbTab;

									if (aSkill[iId, iLevel].cast_range == -1)
										// target_type = self
										sTemp = sTemp + "target_type=self" + Constants.vbTab;
									else
										// target_type = self
										sTemp = sTemp + "target_type=target" + Constants.vbTab;
									// affect_scope = single	
									sTemp = sTemp + "affect_scope=single" + Constants.vbTab;

									// affect_limit = {0;0}	
									sTemp = sTemp + "affect_limit={0;0}" + Constants.vbTab;
									// next_action = none	
									sTemp = sTemp + "next_action=none" + Constants.vbTab;

									// ride_state = {@ride_none;@ride_wind;@ride_star;@ride_twilight}	
									if (aSkill[iId, iLevel].is_magic == 0)
										sTemp = sTemp + "ride_state={@ride_none}" + Constants.vbTab;
									else
										sTemp = sTemp + "ride_state={@ride_none;@ride_wind;@ride_star;@ride_twilight}" + Constants.vbTab;
									break;
								}

							case var case5 when case5 == Conversions.ToShort(1  // A2,A3
					 ):
								{
									// is_magic = 1	
									sTemp = sTemp + "is_magic=" + Conversions.ToString(aSkill[iId, iLevel].is_magic) + Constants.vbTab;
									// mp_consume2 = 28	
									sTemp = sTemp + "mp_consume2=" + Conversions.ToString(aSkill[iId, iLevel].mp_consume2) + Constants.vbTab;

									// cast_range = -1	
									sTemp = sTemp + "cast_range=" + Conversions.ToString(aSkill[iId, iLevel].cast_range) + Constants.vbTab;
									// effective_range = -1	
									if (aSkill[iId, iLevel].cast_range == -1)
										sTemp = sTemp + "effective_range=-1" + Constants.vbTab;
									else
										sTemp = sTemp + "effective_range=" + Conversions.ToString(Conversions.ToInteger(aSkill[iId, iLevel].cast_range * 1.5)) + Constants.vbTab;

									// skill_hit_time = 4	
									sTemp = sTemp + "skill_hit_time=" + Conversions.ToString(aSkill[iId, iLevel].hit_time) + Constants.vbTab;
									// skill_cool_time = 0	
									sTemp = sTemp + "skill_cool_time=0" + Constants.vbTab;
									// skill_hit_cancel_time = 0.5	
									sTemp = sTemp + "skill_hit_cancel_time=0" + Constants.vbTab;
									// reuse_delay = 80	
									sTemp = sTemp + "reuse_delay=80" + Constants.vbTab;

									// activate_rate = -1
									sTemp = sTemp + "activate_rate=80" + Constants.vbTab;
									// lv_bonus_rate = 0
									sTemp = sTemp + "lv_bonus_rate=0" + Constants.vbTab;
									// basic_property = none
									sTemp = sTemp + "basic_property=none" + Constants.vbTab;
									// abnormal_time = 15
									sTemp = sTemp + "abnormal_time=15" + Constants.vbTab;
									// abnormal_lv = 1
									sTemp = sTemp + "abnormal_lv=0" + Constants.vbTab;
									// abnormal_type = speed_up_special
									sTemp = sTemp + "abnormal_type=none" + Constants.vbTab;
									// attribute = attr_none
									sTemp = sTemp + "attribute=attr_none" + Constants.vbTab;
									// effect_point = 204
									sTemp = sTemp + "effect_point=0" + Constants.vbTab;

									if (aSkill[iId, iLevel].cast_range == -1)
										// target_type = self
										sTemp = sTemp + "target_type=self" + Constants.vbTab;
									else
										// target_type = self
										sTemp = sTemp + "target_type=target" + Constants.vbTab;
									// affect_scope = single
									sTemp = sTemp + "affect_scope=single" + Constants.vbTab;

									// affect_limit = {0;0}
									sTemp = sTemp + "affect_limit={0;0}" + Constants.vbTab;
									// next_action = none
									sTemp = sTemp + "next_action=none" + Constants.vbTab;
									// debuff = 0
									sTemp = sTemp + "debuff=" + Conversions.ToString(aSkill[iId, iLevel].debuff) + Constants.vbTab; // extra_eff=1
																																	// sTemp = sTemp & "debuff=0" & vbTab 'extra_eff=1

									// ride_state = {@ride_none;@ride_wind;@ride_star;@ride_twilight}	
									if (aSkill[iId, iLevel].is_magic == 0)
										sTemp = sTemp + "ride_state={@ride_none}" + Constants.vbTab;
									else
										sTemp = sTemp + "ride_state={@ride_none;@ride_wind;@ride_star;@ride_twilight}" + Constants.vbTab;
									break;
								}

							case var case6 when case6 == Conversions.ToShort(2  // P
					 ):
								{
									break;
								}

							case var case7 when case7 == Conversions.ToShort(3  // T
				  ):
								{
									// mp_consume1 = 2	
									sTemp = sTemp + "mp_consume1=" + Conversions.ToString(aSkill[iId, iLevel].mp_consume2) + Constants.vbTab;
									// reuse_delay = 0
									sTemp = sTemp + "reuse_delay=0" + Constants.vbTab;
									// target_type = none
									sTemp = sTemp + "target_type=none" + Constants.vbTab;
									// next_action = none
									sTemp = sTemp + "next_action=none" + Constants.vbTab;
									// ride_state = {@ride_none}
									sTemp = sTemp + "ride_state={@ride_none}" + Constants.vbTab;
									break;
								}

							default:
								{
									break;
								}
						}
						sTemp = sTemp + "skill_end";
						outFile.WriteLine(sTemp);
						sTemp = "";

						// ------------ SkillEnchant Module --------------
						if (aSkill[iId, iLevel].ench_skill_id > 0)
						{

							// enchant_skill_begin
							sTemp = "enchant_skill_begin" + Constants.vbTab;
							// original_skill = [s_hate192]
							// FIIXXXX check

							sTemp = sTemp + "original_skill=" + aSkill[iId, aSkill[iId, iLevel].ench_skill_id].name + Constants.vbTab;

							// route_id = 1
							if (Conversions.Str(iLevel).EndsWith("01") == true)
							{
								// If aSkill(iId, iLevel - 1).ench_skill_id = 0 Then
								// this first level for enchant
								// If iRouteId = 1 Then iRouteId = 3 Else iRouteId = 1
								iEnchId = 0;
								if ((sEnchName ?? "") != (aSkill[iId, aSkill[iId, iLevel].ench_skill_id].name ?? ""))
								{
									iRouteId = 1;
									sEnchName = aSkill[iId, aSkill[iId, iLevel].ench_skill_id].name;
								}
							}
							iRouteId = Conversions.ToInteger(iLevel / (double)100);
							sTemp = sTemp + "route_id=" + Conversions.ToString(iRouteId) + Constants.vbTab;

							// enchant_id = 1
							iEnchId += 1;
							sTemp = sTemp + "enchant_id=" + Conversions.ToString(iEnchId) + Constants.vbTab;

							// skill_level = 101
							sTemp = sTemp + "skill_level=" + Conversions.ToString(iLevel) + Constants.vbTab;

							if (aSkill[iId, iLevel].ench_skill_id == 1 & aSkill[iId, Conversions.ToInteger(iLevel / (double)100) * 100 + 30].ench_skill_id == 0)
							{
								// exp = 3060000
								sTemp = sTemp + "exp=37800000" + Constants.vbTab;
								// sp = 306000
								sTemp = sTemp + "sp=3780000" + Constants.vbTab;
							}
							else
							{
								// exp = 3060000
								sTemp = sTemp + "exp=5280000" + Constants.vbTab;
								// sp = 306000
								sTemp = sTemp + "sp=528000" + Constants.vbTab;
							}
							// item_needed = {{[codex_of_giant];1}}
							if (iEnchId == 1)
								// If aSkill(iId, iLevel - 1).ench_skill_id = 0 Then
								// If Str(iLevel).EndsWith("01") = True Then ' level=201 =route2 = start route with book
								// this first level for enchant
								sTemp = sTemp + "item_needed={{[codex_of_giant];1}}" + Constants.vbTab;
							else
								sTemp = sTemp + "item_needed={}" + Constants.vbTab;

							if (aSkill[iId, iLevel].ench_skill_id == 1 & aSkill[iId, Conversions.ToInteger(iLevel / (double)100) * 100 + 30].ench_skill_id == 0)
							{

								// prob_79=97	prob_80=98	prob_81=99	prob_82=99	prob_83=99	prob_84=99	prob_85=99	
								// prob_76 = 82
								sTemp = sTemp + "prob_76=" + Conversions.ToString(EnchantChance1[iEnchId + 8]) + Constants.vbTab;
								// prob_77 = 92
								sTemp = sTemp + "prob_77=" + Conversions.ToString(EnchantChance1[iEnchId + 7]) + Constants.vbTab;
								// prob_78 = 97
								sTemp = sTemp + "prob_78=" + Conversions.ToString(EnchantChance1[iEnchId + 6]) + Constants.vbTab;

								// prob_79 = 97
								sTemp = sTemp + "prob_79=" + Conversions.ToString(EnchantChance1[iEnchId + 5]) + Constants.vbTab;
								// prob_80 = 98
								sTemp = sTemp + "prob_80=" + Conversions.ToString(EnchantChance1[iEnchId + 4]) + Constants.vbTab;
								// prob_81 = 99
								sTemp = sTemp + "prob_81=" + Conversions.ToString(EnchantChance1[iEnchId + 3]) + Constants.vbTab;
								// prob_82 = 99
								sTemp = sTemp + "prob_82=" + Conversions.ToString(EnchantChance1[iEnchId + 2]) + Constants.vbTab;
								// prob_83 = 99
								sTemp = sTemp + "prob_83=" + Conversions.ToString(EnchantChance1[iEnchId + 1]) + Constants.vbTab;
								// prob_84 = 99
								sTemp = sTemp + "prob_84=" + Conversions.ToString(EnchantChance1[iEnchId]) + Constants.vbTab;
								// prob_85 = 99
								sTemp = sTemp + "prob_85=" + Conversions.ToString(EnchantChance1[iEnchId - 1]) + Constants.vbTab;
							}
							else
							{
								// prob_79=97	prob_80=98	prob_81=99	prob_82=99	prob_83=99	prob_84=99	prob_85=99	
								// prob_76 = 82
								sTemp = sTemp + "prob_76=" + Conversions.ToString(EnchantChance[iEnchId + 8]) + Constants.vbTab;
								// prob_77 = 92
								sTemp = sTemp + "prob_77=" + Conversions.ToString(EnchantChance[iEnchId + 7]) + Constants.vbTab;
								// prob_78 = 97
								sTemp = sTemp + "prob_78=" + Conversions.ToString(EnchantChance[iEnchId + 6]) + Constants.vbTab;

								// prob_79 = 97
								sTemp = sTemp + "prob_79=" + Conversions.ToString(EnchantChance[iEnchId + 5]) + Constants.vbTab;
								// prob_80 = 98
								sTemp = sTemp + "prob_80=" + Conversions.ToString(EnchantChance[iEnchId + 4]) + Constants.vbTab;
								// prob_81 = 99
								sTemp = sTemp + "prob_81=" + Conversions.ToString(EnchantChance[iEnchId + 3]) + Constants.vbTab;
								// prob_82 = 99
								sTemp = sTemp + "prob_82=" + Conversions.ToString(EnchantChance[iEnchId + 2]) + Constants.vbTab;
								// prob_83 = 99
								sTemp = sTemp + "prob_83=" + Conversions.ToString(EnchantChance[iEnchId + 1]) + Constants.vbTab;
								// prob_84 = 99
								sTemp = sTemp + "prob_84=" + Conversions.ToString(EnchantChance[iEnchId]) + Constants.vbTab;
								// prob_85 = 99
								sTemp = sTemp + "prob_85=" + Conversions.ToString(EnchantChance[iEnchId - 1]) + Constants.vbTab;
							}

							// enchant_skill_end
							sTemp = sTemp + "enchant_skill_end";

							// Checking for error in skillgrp. Example, enchskill_level=9 but last skilllevel=4
							if (string.IsNullOrEmpty(aSkill[iId, aSkill[iId, iLevel].ench_skill_id].name) | aSkill[iId, aSkill[iId, iLevel].ench_skill_id].name == null)
								sTemp = "//ERR: enchant skill_id:" + Conversions.ToString(iId) + " level:" + Conversions.ToString(iLevel) + Constants.vbTab + sTemp;

							outEncFile.WriteLine(sTemp);
							sTemp = "";
						}
					}
				}
				ToolStripProgressBar.Value = iId;
				StatusStrip.Update();
			}
			outFile.Close();
			outEncFile.Close();
			ToolStripProgressBar.Value = 0;

			ToolStripStatusLabel.Text = "Complete";
			MessageBox.Show("Complete");
		}

		private bool SkillPchLoad(string FileName)
		{
			System.IO.StreamReader inFile;
			try
			{
				inFile = new System.IO.StreamReader(FileName, System.Text.Encoding.Default, true, 1);
			}
			catch (Exception ex)
			{
				return false;
			}
			string sTempStr = "";
			var aTemp = new string[2];

			int iTemp = -1;
			int iId;
			int iLevel;

			while (inFile.EndOfStream != true)
			{

				// [s_power_strike11] = 769
				try
				{
					sTempStr = inFile.ReadLine();
					sTempStr = sTempStr.Replace(" ", "").Replace(Conversions.ToString((char)9), ""); // .Replace("[", "").Replace("]", "")
					aTemp = sTempStr.Split(Conversions.ToChar("="));

					iId = Conversions.ToInteger(Conversions.Fix(Conversions.ToInteger(aTemp[1]) / (double)256));
					iLevel = Conversions.ToInteger(aTemp[1]) - iId * 256;
					aSkill[iId, iLevel].name = aTemp[0];
				}
				catch (Exception ex)
				{
					MessageBox.Show("Import data invalid in line" + Constants.vbNewLine + sTempStr, "Import data invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
					inFile.Close();
					return false;
				}
			}

			inFile.Close();
			return true;
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
