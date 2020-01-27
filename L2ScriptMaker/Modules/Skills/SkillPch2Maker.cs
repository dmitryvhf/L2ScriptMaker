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

namespace L2ScriptMaker.Modules.Skills
{
	public partial class SkillPch2Maker : Form
	{
		public SkillPch2Maker()
		{
			InitializeComponent();
		}


		// Dim TabSymbol As String = Chr(9)
		private string TabSymbol = " ";

		private bool LoadingManual(string FileName)
		{
			string sTemp;
			var inAbFile = new System.IO.StreamReader(FileName, System.Text.Encoding.Default, true, 1);

			AbnormalListTextBox.Text = "";

			// [none] = -1
			while (inAbFile.EndOfStream != true)
			{
				sTemp = inAbFile.ReadLine().Trim().ToLower();
				if (sTemp.StartsWith("[ab_") == true)
				{
					sTemp = sTemp.Replace(Conversions.ToString((char)32), "").Replace(Conversions.ToString((char)9), "");  // .Replace("[ab_", "[")
					AbnormalListTextBox.AppendText(sTemp + Constants.vbNewLine);
				}

				if (sTemp.StartsWith("[attr_") == true | sTemp.StartsWith("[trait_") == true)
				{
					sTemp = sTemp.Replace(Conversions.ToString((char)32), "").Replace(Conversions.ToString((char)9), "");  // .Replace("[ab_", "[")
					AbnormalListTextBox.AppendText(sTemp + Constants.vbNewLine);
				}
			}

			inAbFile.Close();
			return true;
		}

		private void LoadAbListButton_Click(object sender, EventArgs e)
		{
			string sAbFile;
			OpenFileDialog.InitialDirectory = Environment.CurrentDirectory;
			OpenFileDialog.Filter = "Lineage II definition config (manual_pch.txt)|manual_pch.txt|All files (*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sAbFile = OpenFileDialog.FileName;

			LoadingManual(sAbFile);

			MessageBox.Show("Abnormal list loaded success. Made required correction in listist and use Pch/Pch2 generator", "Load success", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}


		private void StartButton_Click(object sender, EventArgs e)
		{
			string TempStr;
			string sAttr;
			string sAttr2; // sAttr1 As String, 
			string SkillDataFile, SkillDataDir;

			// Dim aAbnList(0) As String

			var aAbList = new string[1];
			var aAttrList = new string[1];

			if (UseCustomAbnormalsCheckBox.Checked == true)
			{
				if (AbnormalListTextBox.Lines.Length == 0)
				{
					MessageBox.Show("No abnormals and attributes in text window. Load from manual_pch file or enter manualy with format [abnormal_name] = abnormal_id", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				int iTemp;
				string[] aTemp;
				var loopTo = AbnormalListTextBox.Lines.Length - 1;
				for (iTemp = 0; iTemp <= loopTo; iTemp++)
				{
					aTemp = AbnormalListTextBox.Lines[iTemp].ToLower().Split(Conversions.ToChar("="));


					if (aTemp[0].StartsWith("[ab_") == true)
					{
						// Preparing text to parsing.
						if (CheckBoxAsIs.Checked == false)
							aTemp[0] = aTemp[0].Replace("[ab_", "[");
						aTemp[0] = aTemp[0].Replace("[", "").Replace("]", "").Replace(" ", "").Replace(Conversions.ToString((char)9), "");
						if (Conversions.ToInteger(aTemp[1]) >= aAbList.Length)
							Array.Resize(ref aAbList, Conversions.ToInteger(aTemp[1]) + 1);
						if (Conversions.ToInteger(aTemp[1]) > -1)
							aAbList[Conversions.ToInteger(aTemp[1])] = aTemp[0];
					}

					if (aTemp[0].StartsWith("[attr_") == true | aTemp[0].StartsWith("[trait_") == true)
					{

						// Preparing text to parsing.
						if (CheckBoxAsIs.Checked == false)
							aTemp[0] = aTemp[0].Replace("[ab_", "[");
						aTemp[0] = aTemp[0].Replace("[", "").Replace("]", "").Replace(" ", "").Replace(Conversions.ToString((char)9), "");

						if (Conversions.ToInteger(aTemp[1]) >= aAttrList.Length)
							Array.Resize(ref aAttrList, Conversions.ToInteger(aTemp[1]) + 1);
						if (Conversions.ToInteger(aTemp[1]) > -1)
							aAttrList[Conversions.ToInteger(aTemp[1])] = aTemp[0];
					}
				}
			}

			OpenFileDialog.InitialDirectory = Environment.CurrentDirectory;
			OpenFileDialog.Filter = "Lineage II skill config|skilldata*.txt|All files (*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			SkillDataFile = OpenFileDialog.FileName;
			SkillDataDir = System.IO.Path.GetDirectoryName(SkillDataFile);

			var inScillData = new System.IO.StreamReader(SkillDataFile, System.Text.Encoding.Default, true, 1);
			System.IO.Stream oPchFile = new System.IO.FileStream(SkillDataDir + @"\skill_pch.txt", System.IO.FileMode.Create, System.IO.FileAccess.Write);
			var outScillPchData = new System.IO.StreamWriter(oPchFile, System.Text.Encoding.Unicode);

			System.IO.Stream oPch2File = new System.IO.FileStream(SkillDataDir + @"\skill_pch2.txt", System.IO.FileMode.Create, System.IO.FileAccess.Write);
			var outScillPch2Data = new System.IO.StreamWriter(oPch2File, System.Text.Encoding.Unicode);

			ProgressBar.Maximum = Conversions.ToInteger(inScillData.BaseStream.Length);
			ProgressBar.Value = 0;

			int iT1id = 0;
			if (CheckBoxKamaelIDStandart.Checked == false)
				iT1id = 256;
			else
				iT1id = 65536;

			while (inScillData.BaseStream.Position != inScillData.BaseStream.Length)
			{
				TempStr = Strings.Replace(inScillData.ReadLine(), Conversions.ToString((char)9), TabSymbol);
				TempStr = Strings.Replace(TempStr, " = ", "=");

				// null string fix
				if (!string.IsNullOrEmpty(TempStr))
				{
					if ((Strings.Mid(TempStr, 1, 2) ?? "") != "//")
					{

						// check: skill_begin or not?
						if ((Strings.Mid(TempStr, 1, 11) ?? "") != "skill_begin" & (Strings.Mid(TempStr, 1, 2) ?? "") != "//")
						{
							MessageBox.Show("File is not Skilldata or bad data." + Conversions.ToString((char)13) + Conversions.ToString((char)10) + TempStr, "Bad data", MessageBoxButtons.OK, MessageBoxIcon.Error);
							break;
						}

						outScillPchData.WriteLine(Libraries.GetNeedParamFromStr(TempStr, "skill_name") + TabSymbol + "=" + TabSymbol + (Conversions.Val(Libraries.GetNeedParamFromStr(TempStr, "skill_id")) * (double)iT1id + Conversions.Val(Libraries.GetNeedParamFromStr(TempStr, "level"))).ToString());

						// Stage 1 (Ready from Pch file) ! Need make ID generator
						// 769=ID from skill_pch ----ok
						outScillPch2Data.Write((Conversions.Val(Libraries.GetNeedParamFromStr(TempStr, "skill_id")) * (double)iT1id + Conversions.Val(Libraries.GetNeedParamFromStr(TempStr, "level"))).ToString() + TabSymbol);

						// Stage 2 (Ready)
						// 50=cast_range ------ok  cast_range = 400 
						// outScillPch2Data.Write(Libraries.GetNeedParamFromStr(TempStr, "cast_range") & TabSymbol)
						switch (Libraries.GetNeedParamFromStr(TempStr, "cast_range"))
						{
							case object _ when Libraries.GetNeedParamFromStr(TempStr, "cast_range") != "":
								{
									outScillPch2Data.Write(Libraries.GetNeedParamFromStr(TempStr, "cast_range") + TabSymbol);
									break;
								}

							default:
								{
									outScillPch2Data.Write("0" + TabSymbol);
									break;
								}
						}

						// Stage 3 (Ready)
						// 0=hp_consume ------ok
						// outScillPch2Data.Write(Libraries.GetNeedParamFromStr(TempStr, "hp_consume") & TabSymbol)
						switch (Libraries.GetNeedParamFromStr(TempStr, "hp_consume"))
						{
							case object _ when Libraries.GetNeedParamFromStr(TempStr, "hp_consume") != "":
								{
									outScillPch2Data.Write(Conversions.ToInteger(Conversions.Val(Libraries.GetNeedParamFromStr(TempStr, "hp_consume"))).ToString() + TabSymbol);
									break;
								}

							default:
								{
									outScillPch2Data.Write("0" + TabSymbol);
									break;
								}
						}

						// Stage 4 (Ready)
						// 10=mp_consume2 ------problem here,if there's CONSUME1 it should be(mp_consume 1+2)
						double Mp_consume1, Mp_consume2;
						Mp_consume1 = Conversions.Val(Libraries.GetNeedParamFromStr(TempStr, "mp_consume1"));
						Mp_consume2 = Conversions.Val(Libraries.GetNeedParamFromStr(TempStr, "mp_consume2"));
						outScillPch2Data.Write(Conversions.ToInteger(Mp_consume1 + Mp_consume2).ToString() + TabSymbol);

						// Stage 5 (Ready)
						// 3=target_type ------ok

						// [STGT_SELF]			=	0
						// [STGT_TARGET]			=	1
						// [STGT_OTHERS]			=	2
						// [STGT_ENEMY]			=	3
						// [STGT_ENEMY_ONLY]		=	4
						// [STGT_REAL_ENEMY_ONLY]		=	4
						// [STGT_ITEM]			=	5
						// [STGT_SUMMON]			=	6
						// [STGT_HOLYTHING]		=	7
						// [STGT_MY_PLEDGE]		=	8
						// [STGT_DOOR_TREASURE]		=	9
						// [STGT_PC_BODY]			=	10
						// [STGT_NPC_BODY]			=	11
						// [STGT_WYVERN_TARGET]		=	12
						// [STGT_GROUND]			=	13
						// [STGT_NONE] = 14
						// default metod from old configs and etc
						switch (Libraries.GetNeedParamFromStr(TempStr, "target_type"))
						{
							case "self":
								{
									outScillPch2Data.Write("0" + TabSymbol);
									break;
								}

							case "target":
								{
									outScillPch2Data.Write("1" + TabSymbol);
									break;
								}

							case "others":
								{
									outScillPch2Data.Write("2" + TabSymbol);
									break;
								}

							case "enemy":
								{
									outScillPch2Data.Write("3" + TabSymbol);
									break;
								}

							case "enemy_only":
								{
									outScillPch2Data.Write("4" + TabSymbol);
									break;
								}

							case "real_enemy_only":
								{
									outScillPch2Data.Write("4" + TabSymbol);
									break;
								}

							case "item":
								{
									outScillPch2Data.Write("5" + TabSymbol);
									break;
								}

							case "summon":
								{
									outScillPch2Data.Write("6" + TabSymbol);
									break;
								}

							case "holything":
								{
									// NPC_ENEMY_ONLY_BUT_SIEGE
									outScillPch2Data.Write("7" + TabSymbol);
									break;
								}

							case "my_pledge":
								{
									outScillPch2Data.Write("8" + TabSymbol);
									break;
								}

							case "door_treasure":
								{
									outScillPch2Data.Write("9" + TabSymbol);
									break;
								}

							case "pc_body":
								{
									outScillPch2Data.Write("10" + TabSymbol);
									break;
								}

							case "npc_body":
								{
									outScillPch2Data.Write("11" + TabSymbol);
									break;
								}

							case "wyvern_target":
								{
									outScillPch2Data.Write("12" + TabSymbol);
									break;
								}

							case "ground":
								{
									outScillPch2Data.Write("13" + TabSymbol);
									break;
								}

							case "pvp_target":
								{
									outScillPch2Data.Write("14" + TabSymbol);
									break;
								}

							case "none":
								{
									outScillPch2Data.Write("15" + TabSymbol);
									break;
								}

							case "":
								{
									outScillPch2Data.Write("15" + TabSymbol);
									break;
								}

							default:
								{
									// outScillPch2Data.Write("0" & TabSymbol)
									MessageBox.Show("Unknown target_type: " + Libraries.GetNeedParamFromStr(TempStr, "target_type"), "Unknown target_type", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
						}

						// Stage 6 (Ready)
						// -52=effect_point -----ok
						// outScillPch2Data.Write(Libraries.GetNeedParamFromStr(TempStr, "effect_point") & TabSymbol)
						switch (Libraries.GetNeedParamFromStr(TempStr, "effect_point"))
						{
							case object _ when Libraries.GetNeedParamFromStr(TempStr, "effect_point") != "":
								{
									outScillPch2Data.Write(Libraries.GetNeedParamFromStr(TempStr, "effect_point") + TabSymbol);
									break;
								}

							default:
								{
									outScillPch2Data.Write("0" + TabSymbol);
									break;
								}
						}

						// Stage 7 (Ready)
						// 29=attribute -----ok
						// default metod from old configs and etc
						if (La2GuardAttrCheckBox.Checked == false)
						{
							if (Array.IndexOf(aAttrList, Libraries.GetNeedParamFromStr(TempStr, "attribute")) == -1 & !string.IsNullOrEmpty(Libraries.GetNeedParamFromStr(TempStr, "attribute")))
							{
								MessageBox.Show("Unknown attribute: " + Libraries.GetNeedParamFromStr(TempStr, "attribute") + Constants.vbNewLine + "into skill_name:" + Libraries.GetNeedParamFromStr(TempStr, "skill_name") + "skill_id:" + Libraries.GetNeedParamFromStr(TempStr, "skill_id") + " level" + Libraries.GetNeedParamFromStr(TempStr, "level"), "Unknown attribute", MessageBoxButtons.OK, MessageBoxIcon.Error);
								ProgressBar.Value = 0;
								inScillData.Close();
								outScillPchData.Close();
								outScillPch2Data.Close();
								return;
							}
							outScillPch2Data.Write(Conversions.ToString(Array.IndexOf(aAttrList, Libraries.GetNeedParamFromStr(TempStr, "attribute"))) + TabSymbol);
						}
						else
						{
							sAttr = "attr_none";

							// If Libraries.GetNeedParamFromStr(TempStr, "skill_id") = "113" Then
							// Dim asd As Boolean = True
							// End If

							// sAttr1 = Libraries.GetNeedParamFromStr(TempStr, "attribute")
							// If sAttr1.Length > 1 Then sAttr1 = sAttr1.Substring(1, sAttr1.IndexOf(";") - 1)
							// If Array.IndexOf(aAttrList, sAttr1) = -1 And sAttr1 <> "" Then
							// MessageBox.Show("Unknown attribute: " & sAttr1 & vbNewLine & _
							// "into skill_name:" & Libraries.GetNeedParamFromStr(TempStr, "skill_name") & "skill_id:" & Libraries.GetNeedParamFromStr(TempStr, "skill_id") & " level" & Libraries.GetNeedParamFromStr(TempStr, "level"), _
							// "Unknown attribute", MessageBoxButtons.OK, MessageBoxIcon.Error)
							// ProgressBar.Value = 0
							// inScillData.Close()
							// outScillPchData.Close()
							// outScillPch2Data.Close()
							// Exit Sub
							// Else
							// ' Attribute now is 'attribute' param
							// If sAttr1 <> "" Then sAttr = sAttr1
							// End If

							sAttr2 = Libraries.GetNeedParamFromStr(TempStr, "trait");
							if (sAttr2.Length > 1)
								sAttr2 = sAttr2.Substring(1, sAttr2.IndexOf("}") - 1);
							if (Array.IndexOf(aAttrList, sAttr2) == -1 & !string.IsNullOrEmpty(sAttr2))
							{
								MessageBox.Show("Unknown trait: " + sAttr2 + Constants.vbNewLine + "into skill_name:" + Libraries.GetNeedParamFromStr(TempStr, "skill_name") + "skill_id:" + Libraries.GetNeedParamFromStr(TempStr, "skill_id") + " level" + Libraries.GetNeedParamFromStr(TempStr, "level"), "Unknown trait", MessageBoxButtons.OK, MessageBoxIcon.Error);
								ProgressBar.Value = 0;
								inScillData.Close();
								outScillPchData.Close();
								outScillPch2Data.Close();
								return;
							}
							else if ((sAttr2 ?? "") != "trait_none")
							{
								bool asd = true;
								if (!string.IsNullOrEmpty(sAttr2))
									sAttr = sAttr2;
							}
							outScillPch2Data.Write(Conversions.ToString(Array.IndexOf(aAttrList, sAttr)) + TabSymbol);
						}

						// Stage 8
						// -1=abnormal_type -----ok
						// default metod from old configs and etc
						// metod from manual_pch

						if (UseCustomAbnormalsCheckBox.Checked == true)
						{
							switch (Libraries.GetNeedParamFromStr(TempStr, "abnormal_type"))
							{
								case "none":
									{
										outScillPch2Data.Write("-1" + TabSymbol);
										break;
									}

								case "":
									{
										outScillPch2Data.Write("-1" + TabSymbol);
										break;
									}

								default:
									{
										if (Array.IndexOf(aAbList, Libraries.GetNeedParamFromStr(TempStr, "abnormal_type")) == -1)
										{
											if (IgnoreCustomAbnormalsCheckBox.Checked == false)
											{
												MessageBox.Show("Unknown abnormal_type: " + Libraries.GetNeedParamFromStr(TempStr, "abnormal_type") + Constants.vbNewLine + "into skill_name:" + Libraries.GetNeedParamFromStr(TempStr, "skill_name") + "skill_id:" + Libraries.GetNeedParamFromStr(TempStr, "skill_id") + " level" + Libraries.GetNeedParamFromStr(TempStr, "level"), "Unknown abnormal_type", MessageBoxButtons.OK, MessageBoxIcon.Error);
												ProgressBar.Value = 0;
												inScillData.Close();
												outScillPchData.Close();
												outScillPch2Data.Close();
												return;
											}
										}
										outScillPch2Data.Write(Conversions.ToString(Array.IndexOf(aAbList, Libraries.GetNeedParamFromStr(TempStr, "abnormal_type"))) + TabSymbol);
										break;
									}
							}
						}
						else
							switch (Libraries.GetNeedParamFromStr(TempStr, "abnormal_type"))
							{
								case "none":
									{
										outScillPch2Data.Write("-1" + TabSymbol);
										break;
									}

								case "pa_up":
									{
										outScillPch2Data.Write("0" + TabSymbol);
										break;
									}

								case "pa_up_special":
									{
										outScillPch2Data.Write("1" + TabSymbol);
										break;
									}

								case "pa_down":
									{
										outScillPch2Data.Write("2" + TabSymbol);
										break;
									}

								case "pd_up":
									{
										outScillPch2Data.Write("3" + TabSymbol);
										break;
									}

								case "pd_up_special":
									{
										outScillPch2Data.Write("4" + TabSymbol);
										break;
									}

								case "ma_up":
									{
										outScillPch2Data.Write("5" + TabSymbol);
										break;
									}

								case "md_up":
									{
										outScillPch2Data.Write("6" + TabSymbol);
										break;
									}

								case "md_up_attr":
									{
										outScillPch2Data.Write("7" + TabSymbol);
										break;
									}

								case "avoid_up":
									{
										outScillPch2Data.Write("8" + TabSymbol);
										break;
									}

								case "avoid_up_special":
									{
										outScillPch2Data.Write("9" + TabSymbol);
										break;
									}

								case "hit_up":
									{
										outScillPch2Data.Write("10" + TabSymbol);
										break;
									}

								case "hit_down":
									{
										outScillPch2Data.Write("11" + TabSymbol);
										break;
									}

								case "fatal_poison":
									{
										outScillPch2Data.Write("12" + TabSymbol);
										break;
									}

								case "fly_away":
									{
										outScillPch2Data.Write("13" + TabSymbol);
										break;
									}

								case "turn_stone":
									{
										outScillPch2Data.Write("14" + TabSymbol);
										break;
									}

								case "casting_time_down":
									{
										outScillPch2Data.Write("15" + TabSymbol);
										break;
									}

								case "attack_time_down":
									{
										outScillPch2Data.Write("16" + TabSymbol);
										break;
									}

								case "speed_up":
									{
										outScillPch2Data.Write("17" + TabSymbol);
										break;
									}

								case "possession":
									{
										outScillPch2Data.Write("18" + TabSymbol);
										break;
									}

								case "attack_time_up":
									{
										outScillPch2Data.Write("19" + TabSymbol);
										break;
									}

								case "speed_down":
									{
										outScillPch2Data.Write("20" + TabSymbol);
										break;
									}

								case "hp_regen_up":
									{
										outScillPch2Data.Write("21" + TabSymbol);
										break;
									}

								case "max_mp_up":
									{
										outScillPch2Data.Write("22" + TabSymbol);
										break;
									}

								case "antaras_debuff":
									{
										outScillPch2Data.Write("23" + TabSymbol);
										break;
									}

								case "critical_prob_up":
									{
										outScillPch2Data.Write("24" + TabSymbol);
										break;
									}

								case "cancel_prob_down":
									{
										outScillPch2Data.Write("25" + TabSymbol);
										break;
									}

								case "bow_range_up":
									{
										outScillPch2Data.Write("26" + TabSymbol);
										break;
									}

								case "max_breath_up":
									{
										outScillPch2Data.Write("27" + TabSymbol);
										break;
									}

								case "decrease_weight_penalty":
									{
										outScillPch2Data.Write("28" + TabSymbol);
										break;
									}

								case "poison":
									{
										outScillPch2Data.Write("29" + TabSymbol);
										break;
									}

								case "bleeding":
									{
										outScillPch2Data.Write("30" + TabSymbol);
										break;
									}

								case "dot_attr":
									{
										outScillPch2Data.Write("31" + TabSymbol);
										break;
									}

								case "dot_mp":
									{
										outScillPch2Data.Write("32" + TabSymbol);
										break;
									}

								case "dmg_shield":
									{
										outScillPch2Data.Write("33" + TabSymbol);
										break;
									}

								case "hawk_eye":
									{
										outScillPch2Data.Write("34" + TabSymbol);
										break;
									}

								case "resist_shock":
									{
										outScillPch2Data.Write("35" + TabSymbol);
										break;
									}

								case "paralyze":
									{
										outScillPch2Data.Write("36" + TabSymbol);
										break;
									}

								case "public_slot":
									{
										outScillPch2Data.Write("37" + TabSymbol);
										break;
									}

								case "silence":
									{
										outScillPch2Data.Write("38" + TabSymbol);
										break;
									}

								case "derangement":
									{
										outScillPch2Data.Write("39" + TabSymbol);
										break;
									}

								case "stun":
									{
										outScillPch2Data.Write("40" + TabSymbol);
										break;
									}

								case "resist_poison":
									{
										outScillPch2Data.Write("41" + TabSymbol);
										break;
									}

								case "resist_derangement":
									{
										outScillPch2Data.Write("42" + TabSymbol);
										break;
									}

								case "resist_spiritless":
									{
										outScillPch2Data.Write("43" + TabSymbol);
										break;
									}

								case "mp_regen_up":
									{
										outScillPch2Data.Write("44" + TabSymbol);
										break;
									}

								case "md_down":
									{
										outScillPch2Data.Write("45" + TabSymbol);
										break;
									}

								case "heal_effect_down":
									{
										outScillPch2Data.Write("46" + TabSymbol);
										break;
									}

								case "turn_passive":
									{
										outScillPch2Data.Write("47" + TabSymbol);
										break;
									}

								case "turn_flee":
									{
										outScillPch2Data.Write("48" + TabSymbol);
										break;
									}

								case "vampiric_attack":
									{
										outScillPch2Data.Write("49" + TabSymbol);
										break;
									}

								case "duelist_spirit":
									{
										outScillPch2Data.Write("50" + TabSymbol);
										break;
									}

								case "hp_recover":
									{
										outScillPch2Data.Write("51" + TabSymbol);
										break;
									}

								case "mp_recover":
									{
										outScillPch2Data.Write("52" + TabSymbol);
										break;
									}

								case "root":
									{
										outScillPch2Data.Write("53" + TabSymbol);
										break;
									}

								case "speed_up_special":
									{
										outScillPch2Data.Write("54" + TabSymbol);
										break;
									}

								case "majesty":
									{
										outScillPch2Data.Write("55" + TabSymbol);
										break;
									}

								case "pd_up_bow":
									{
										outScillPch2Data.Write("56" + TabSymbol);
										break;
									}

								case "attack_speed_up_bow":
									{
										outScillPch2Data.Write("57" + TabSymbol);
										break;
									}

								case "max_hp_up":
									{
										outScillPch2Data.Write("58" + TabSymbol);
										break;
									}

								case "holy_attack":
									{
										outScillPch2Data.Write("59" + TabSymbol);
										break;
									}

								case "sleep":
									{
										outScillPch2Data.Write("60" + TabSymbol);
										break;
									}

								case "berserker":
									{
										outScillPch2Data.Write("61" + TabSymbol);
										break;
									}

								case "pinch":
									{
										outScillPch2Data.Write("62" + TabSymbol);
										break;
									}

								case "life_force":
									{
										outScillPch2Data.Write("63" + TabSymbol);
										break;
									}

								case "song_of_earth":
									{
										outScillPch2Data.Write("64" + TabSymbol);
										break;
									}

								case "song_of_life":
									{
										outScillPch2Data.Write("65" + TabSymbol);
										break;
									}

								case "song_of_water":
									{
										outScillPch2Data.Write("66" + TabSymbol);
										break;
									}

								case "song_of_warding":
									{
										outScillPch2Data.Write("67" + TabSymbol);
										break;
									}

								case "song_of_wind":
									{
										outScillPch2Data.Write("68" + TabSymbol);
										break;
									}

								case "song_of_hunter":
									{
										outScillPch2Data.Write("69" + TabSymbol);
										break;
									}

								case "song_of_invocation":
									{
										outScillPch2Data.Write("70" + TabSymbol);
										break;
									}

								case "song_of_vitality":
									{
										outScillPch2Data.Write("71" + TabSymbol);
										break;
									}

								case "song_of_flame_guard":
									{
										outScillPch2Data.Write("72" + TabSymbol);
										break;
									}

								case "song_of_storm_guard":
									{
										outScillPch2Data.Write("73" + TabSymbol);
										break;
									}

								case "song_of_vengeance"                          // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("74" + TabSymbol);
										break;
									}

								case "dance_of_warrior"                         // 75 in Manual_pch
						 :
									{
										outScillPch2Data.Write("75" + TabSymbol);
										break;
									}

								case "dance_of_inspiration"                     // 76 in manual_pch
						 :
									{
										outScillPch2Data.Write("76" + TabSymbol);
										break;
									}

								case "dance_of_mystic"                          // 77 in manual
						 :
									{
										outScillPch2Data.Write("77" + TabSymbol);
										break;
									}

								case "dance_of_fire"                            // 78 in Manual_pch
						 :
									{
										outScillPch2Data.Write("78" + TabSymbol);
										break;
									}

								case "dance_of_fury"                            // 79 in Manual_pch
						 :
									{
										outScillPch2Data.Write("79" + TabSymbol);
										break;
									}

								case "dance_of_concentration"                   // 80 in manual_pch
						 :
									{
										outScillPch2Data.Write("80" + TabSymbol);
										break;
									}

								case "dance_of_light"                           // 81 in manual_pch
						 :
									{
										outScillPch2Data.Write("81" + TabSymbol);
										break;
									}

								case "dance_of_vampire"                      // 83 in manual_pch
						 :
									{
										outScillPch2Data.Write("82" + TabSymbol);
										break;
									}

								case "dance_of_aqua_guard"                      // 83 in manual_pch
						 :
									{
										outScillPch2Data.Write("83" + TabSymbol);
										break;
									}

								case "dance_of_earth_guard"                     // 84 in Manual_pch
						 :
									{
										outScillPch2Data.Write("84" + TabSymbol);
										break;
									}

								case "dance_of_protection"                      // 85 in Manual_pch
						 :
									{
										outScillPch2Data.Write("85" + TabSymbol);
										break;
									}

								case "detect_weakness"                          // 86 in Manual_pch
						 :
									{
										outScillPch2Data.Write("86" + TabSymbol);
										break;
									}

								case "thrill_fight"                             // 87 in Manual_pch
						 :
									{
										outScillPch2Data.Write("87" + TabSymbol);
										break;
									}

								case "resist_bleeding"                          // 88 in Manual_pch
						 :
									{
										outScillPch2Data.Write("88" + TabSymbol);
										break;
									}

								case "critical_dmg_up"                          // 89 in Manual_pch
						 :
									{
										outScillPch2Data.Write("89" + TabSymbol);
										break;
									}

								case "shield_prob_up"                           // 90 in Manual_pch
						 :
									{
										outScillPch2Data.Write("90" + TabSymbol);
										break;
									}

								case "hp_regen_down"                            // 91 in Manual_pch
						 :
									{
										outScillPch2Data.Write("91" + TabSymbol);
										break;
									}

								case "reuse_delay_up"                           // 92 in Manual_pch
						 :
									{
										outScillPch2Data.Write("92" + TabSymbol);
										break;
									}

								case "pd_down"                                  // 93 in Manual_pch
						 :
									{
										outScillPch2Data.Write("93" + TabSymbol);
										break;
									}

								case "big_head"                                 // 94 in Manual_pch
						 :
									{
										outScillPch2Data.Write("94" + TabSymbol);
										break;
									}

								case "snipe"                                    // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("95" + TabSymbol);
										break;
									}

								case "cheap_magic"                              // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("96" + TabSymbol);
										break;
									}

								case "magic_critical_up"                        // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("97" + TabSymbol);
										break;
									}

								case "shield_defence_up"                        // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("98" + TabSymbol);
										break;
									}

								case "rage_might"                               // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("99" + TabSymbol);
										break;
									}

								case "ultimate_buff"                            // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("100" + TabSymbol);
										break;
									}

								case "reduce_drop_penalty"                      // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("101" + TabSymbol);
										break;
									}

								case "heal_effect_up"                           // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("102" + TabSymbol);
										break;
									}

								case "ssq_town_curse"                           // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("103" + TabSymbol);
										break;
									}

								case "ssq_town_blessing"                        // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("104" + TabSymbol);
										break;
									}

								case "big_body"                                 // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("105" + TabSymbol);
										break;
									}

								case "preserve_abnormal"                        // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("106" + TabSymbol);
										break;
									}

								case "spa_disease_a"                            // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("107" + TabSymbol);
										break;
									}

								case "spa_disease_b"                            // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("108" + TabSymbol);
										break;
									}

								case "spa_disease_c"                            // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("109" + TabSymbol);
										break;
									}

								case "spa_disease_d"                            // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("110" + TabSymbol);
										break;
									}

								case "avoid_down"                               // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("111" + TabSymbol);
										break;
									}

								case "multi_buff"                               // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("112" + TabSymbol);
										break;
									}

								case "dragon_breath"                            // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("113" + TabSymbol);
										break;
									}

								case "ultimate_debuff"                          // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("114" + TabSymbol);
										break;
									}

								case "buff_queen_of_cat"                        // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("115" + TabSymbol);
										break;
									}

								case "buff_unicorn_seraphim"                    // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("116" + TabSymbol);
										break;
									}

								case "debuff_nightshade"                        // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("117" + TabSymbol);
										break;
									}

								case "watcher_gaze"                             // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("118" + TabSymbol);
										break;
									}

								case "song_of_renewal"                             // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("119" + TabSymbol);
										break;
									}

								case "song_of_champion"                             // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("120" + TabSymbol);
										break;
									}

								case "song_of_meditation"                             // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("121" + TabSymbol);
										break;
									}

								case "dance_of_siren"                             // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("122" + TabSymbol);
										break;
									}

								case "dance_of_shadow"                             // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("123" + TabSymbol);
										break;
									}

								case "multi_debuff"                             // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("124" + TabSymbol);
										break;
									}

								case "reflect_abnormal"                         // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("125" + TabSymbol);
										break;
									}

								case "focus_dagger"                             // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("126" + TabSymbol);
										break;
									}

								case "max_hp_down"                              // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("127" + TabSymbol);
										break;
									}

								case "resist_holy_unholy"                       // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("128" + TabSymbol);
										break;
									}

								case "resist_debuff_dispel"                     // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("129" + TabSymbol);
										break;
									}

								case "touch_of_life"                            // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("130" + TabSymbol);
										break;
									}

								case "touch_of_death"                           // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("131" + TabSymbol);
										break;
									}

								case "silence_physical"                         // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("132" + TabSymbol);
										break;
									}

								case "silence_all"                              // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("133" + TabSymbol);
										break;
									}

								case "valakas_item"                             // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("134" + TabSymbol);
										break;
									}

								case "gara"                                     // No in Manual_pch
						 :
									{
										outScillPch2Data.Write("135" + TabSymbol);
										break;
									}

								case "":
									{
										outScillPch2Data.Write("-1" + TabSymbol);
										break;
									}

								default:
									{
										MessageBox.Show("Unknown abnormal_type: " + Libraries.GetNeedParamFromStr(TempStr, "abnormal_type"), "Unknown abnormal_type", MessageBoxButtons.OK, MessageBoxIcon.Error);
										return;
									}
							}


						// Stage 9 (Ready)
						// 0=abnormal_lv -----ok
						// ----- what's below are just guess/estimate, it's skills for groups for 4-5 people
						switch (Libraries.GetNeedParamFromStr(TempStr, "abnormal_lv"))
						{
							case object _ when Libraries.GetNeedParamFromStr(TempStr, "abnormal_lv") != "":
								{
									outScillPch2Data.Write(Libraries.GetNeedParamFromStr(TempStr, "abnormal_lv") + TabSymbol);
									break;
								}

							default:
								{
									outScillPch2Data.Write("0" + TabSymbol);
									break;
								}
						}

						// Stage 10 
						// 2= -----this is skill_hit_time, note, it's meant for a group for 4-5 people 1.5=2
						double skill_hit_time, skill_hit_cancel_time, reuse_delay, skill_cool_time;
						double dTemp;

						reuse_delay = Conversions.Val(Libraries.GetNeedParamFromStr(TempStr, "reuse_delay"));
						skill_hit_time = Conversions.Val(Libraries.GetNeedParamFromStr(TempStr, "skill_hit_time"));
						skill_hit_cancel_time = Conversions.Val(Libraries.GetNeedParamFromStr(TempStr, "skill_hit_cancel_time"));
						skill_cool_time = Conversions.Val(Libraries.GetNeedParamFromStr(TempStr, "skill_cool_time"));

						switch (Libraries.GetNeedParamFromStr(TempStr, "skill_hit_time"))
						{
							case object _ when Libraries.GetNeedParamFromStr(TempStr, "skill_hit_time") != "":
								{
									dTemp = Math.Round(skill_hit_time + skill_cool_time, MidpointRounding.AwayFromZero);
									outScillPch2Data.Write(Conversions.ToInteger(dTemp).ToString() + TabSymbol);
									break;
								}

							default:
								{
									outScillPch2Data.Write("0" + TabSymbol);
									break;
								}
						}

						// Stage 11 (Ready)
						// 11= -----[reuse_delay - (skill_hit_time - skill_hit_cancel_time)]\
						// skill_hit_time = 1.08 skill_hit_cancel_time = 0.5 reuse_delay = 13 (skill_cool_time = 0.72 )

						// dTemp = reuse_delay - (skill_hit_time - skill_hit_cancel_time) ' original
						// aas = Int(reuse_delay - (skill_hit_time - skill_hit_cancel_time) - skill_cool_time) ' ideal work
						// dTemp = reuse_delay - (skill_hit_time - skill_hit_cancel_time) - skill_cool_time
						// dTemp = reuse_delay - (skill_hit_time - skill_hit_cancel_time + skill_cool_time)
						// dTemp = reuse_delay - (skill_hit_time + skill_cool_time)

						dTemp = reuse_delay - skill_hit_time - skill_cool_time;
						dTemp = Math.Round(dTemp, MidpointRounding.AwayFromZero);
						if (dTemp < 0)
							dTemp += 1;
						// --- old code ----
						// --- old code ----

						// dTemp = Fix(Int(dTemp))
						dTemp = Conversions.ToInteger(dTemp);
						// aas = Val(Libraries.GetNeedParamFromStr(TempStr, "reuse_delay")) - Val(Libraries.GetNeedParamFromStr(TempStr, "skill_hit_time")) - Val(Libraries.GetNeedParamFromStr(TempStr, "skill_hit_cancel_time"))
						outScillPch2Data.Write(dTemp.ToString() + TabSymbol);

						// Stage 12 (Ready)
						// 0= -----if IS_magic 1 else 0
						// outScillPch2Data.Write(Libraries.GetNeedParamFromStr(TempStr, "is_magic") & TabSymbol)
						switch (Libraries.GetNeedParamFromStr(TempStr, "is_magic"))
						{
							case object _ when Libraries.GetNeedParamFromStr(TempStr, "is_magic") != "":
								{
									outScillPch2Data.Write(Libraries.GetNeedParamFromStr(TempStr, "is_magic") + TabSymbol);
									break;
								}

							default:
								{
									outScillPch2Data.Write("0" + TabSymbol);
									break;
								}
						}

						// Stage 13 (Ready)
						outScillPch2Data.Write("-12345" + Conversions.ToString((char)13) + Conversions.ToString((char)10));

						ProgressBar.Value = Conversions.ToInteger(inScillData.BaseStream.Position);
					}
					else
					{
					}
				}
			}

			inScillData.Close();
			outScillPchData.Close();
			outScillPch2Data.Close();

			System.IO.File.Create(SkillDataDir + @"\skill_pch3.txt");

			MessageBox.Show("Skill Pch/Pch2/Pch3 generation complete", "Complete", MessageBoxButtons.OK);

			ProgressBar.Value = 0;
		}

		private void SkillCacheScript_Click(object sender, EventArgs e)
		{
			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II config (skilldata.txt)|skilldata.txt|All files (*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			System.IO.StreamReader inEFile;
			try
			{
				inEFile = new System.IO.StreamReader(System.IO.Path.GetDirectoryName(OpenFileDialog.FileName) + @"\skillname-e.txt", System.Text.Encoding.Default, true, 1);
			}
			catch (Exception ex)
			{
				MessageBox.Show("You must have skillname-e in work folder for generation itemcache file. Put and try again.");
				return;
			}

			// Initialization
			ProgressBar.Value = 0;
			var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);
			System.IO.Stream oAiFile = new System.IO.FileStream(System.IO.Path.GetDirectoryName(OpenFileDialog.FileName) + @"\gmskilldata.txt", System.IO.FileMode.Create, System.IO.FileAccess.Write);
			var outAiData = new System.IO.StreamWriter(oAiFile, System.Text.Encoding.Unicode, 1);

			string ReadStr;
			string[] ReadSplitStr;

			ProgressBar.Value = 0;
			ProgressBar.Maximum = Conversions.ToInteger(inEFile.BaseStream.Length);
			// SkillId, SkillLevel
			// 0 - name, 1 - desc
			var SkillDB = new string[55001, 701, 2];
			int SkillDBMarker1 = 0;
			int SkillDBMarker2 = 0;


			while (inEFile.EndOfStream != true)
			{
				ReadStr = inEFile.ReadLine().Replace(" = ", "=");

				if (ReadStr != null)
				{
					if ((Strings.Mid(ReadStr, 1, 2) ?? "") != "//")
					{
						ReadSplitStr = ReadStr.Split((char)9);
						SkillDBMarker1 = Conversions.ToInteger(ReadSplitStr[1].Replace("id=", ""));
						SkillDBMarker2 = Conversions.ToInteger(ReadSplitStr[2].Replace("level=", ""));
						if (SkillDBMarker1 > 55000)
						{
							MessageBox.Show("Skill ID must be less then 55000. Custom skills not supported. Last skill_id:" + SkillDBMarker1.ToString() + " skill_level: " + SkillDBMarker2.ToString(), "SkillID above them 30000", MessageBoxButtons.OK, MessageBoxIcon.Error);
							ProgressBar.Value = 0;
							inFile.Close();
							outAiData.Close();
							return;
						}

						// 4	1	[Dash]	[Temporary burst of speed. Effect 1.]	0	A2
						SkillDB[SkillDBMarker1, SkillDBMarker2, 0] = ReadSplitStr[3].Replace("name=", "");
						SkillDB[SkillDBMarker1, SkillDBMarker2, 1] = ReadSplitStr[4].Replace("description=", "");
					}
				}
				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position * 100 / (double)inFile.BaseStream.Length);
			}

			int SkillId;
			int SkillLevel;
			string SkillName;
			string SkillDesc;
			short SkillMagic;
			string SkillOp;

			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ProgressBar.Value = 0;
			while (inFile.BaseStream.Position != inFile.BaseStream.Length)
			{
				ReadStr = Strings.Replace(inFile.ReadLine(), Conversions.ToString((char)9), Conversions.ToString((char)32));
				// tabs and spaces correction
				while (Strings.InStr(ReadStr, "  ") != 0)
					ReadStr = Strings.Replace(ReadStr, "  ", Conversions.ToString((char)32));
				// ReadStr = Replace(inFile.ReadLine, Chr(32), Chr(9))
				// 21      3       [s_poison_recovery3]    []      1       A1

				if (!string.IsNullOrEmpty(ReadStr))
				{
					if (ReadStr.StartsWith("//") == false)
					{
						if (Strings.InStr(ReadStr, "/*") != 0)
							// Commentarie exist
							// Dim commentarie As String = Mid(ReadStr, InStr(ReadStr, "/*"), InStr(ReadStr, "*/") - InStr(ReadStr, "/*") + 2)
							ReadStr = ReadStr.Replace(Strings.Mid(ReadStr, Strings.InStr(ReadStr, "/*"), Strings.InStr(ReadStr, "*/") - Strings.InStr(ReadStr, "/*") + 2), "");
						ReadStr = Strings.Replace(ReadStr, " = ", "=");

						ReadSplitStr = ReadStr.Split((char)32);

						SkillId = Conversions.ToInteger(Libraries.GetNeedParamFromStr(ReadStr, "skill_id"));
						SkillLevel = Conversions.ToInteger(Libraries.GetNeedParamFromStr(ReadStr, "level"));
						SkillName = Libraries.GetNeedParamFromStr(ReadStr, "skill_name");
						SkillDesc = "[no description]";
						if (!string.IsNullOrEmpty(Libraries.GetNeedParamFromStr(ReadStr, "is_magic")))
							SkillMagic = Conversions.ToShort(Libraries.GetNeedParamFromStr(ReadStr, "is_magic"));
						else
							SkillMagic = Conversions.ToShort(0);
						SkillOp = Libraries.GetNeedParamFromStr(ReadStr, "operate_type");

						if (SkillId <= 55000)
						{
							if (!string.IsNullOrEmpty(SkillDB[SkillId, SkillLevel, 0]))
								SkillName = SkillDB[SkillId, SkillLevel, 0];
							if (!string.IsNullOrEmpty(SkillDB[SkillId, SkillLevel, 1]))
								SkillDesc = SkillDB[SkillId, SkillLevel, 1];
						}
						else if (IgnoreCustomSkillBox.Checked == true)
						{
							SkillName = "[L2ScriptMaker: Customs skills not supported]";
							SkillDesc = "[L2ScriptMaker: Customs skills not supported]";
						}
						else
						{
							MessageBox.Show("Skill ID must be less then 55000. Custom skills not supported. Last skill_id:" + SkillId.ToString() + " skill_level: " + SkillLevel.ToString(), "SkillID above them 30000", MessageBoxButtons.OK, MessageBoxIcon.Error);
							ProgressBar.Value = 0;
							inFile.Close();
							outAiData.Close();
							return;
						}

						// 4	1	[Dash]	[Temporary burst of speed. Effect 1.]	0	A2
						// 500 symbols fix
						if (SkillDesc.Length > 255)
							SkillDesc = SkillDesc.Substring(0, 255) + "]";

						outAiData.WriteLine(SkillId.ToString() + Conversions.ToString((char)9) + SkillLevel.ToString() + Conversions.ToString((char)9) + SkillName + Conversions.ToString((char)9) + SkillDesc + Conversions.ToString((char)9) + SkillMagic.ToString() + Conversions.ToString((char)9) + SkillOp);
					}
				}

				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
			}

			MessageBox.Show("gmskilldata.txt Complete");
			ProgressBar.Value = 0;
			inFile.Close();
			outAiData.Close();
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void SkillPch2Maker_Load(object sender, EventArgs e)
		{
			if (System.IO.File.Exists("manual_pch.txt") == true)
				LoadingManual("manual_pch.txt");
		}
	}
}
