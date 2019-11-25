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

namespace L2ScriptMaker.Modules.Npc
{
	public partial class NpcDataPassiveSkillFix : Form
	{
		public NpcDataPassiveSkillFix()
		{
			InitializeComponent();
		}


		// npcdata.txt:	skill_list={@s_race_demonic;@s_evil_attack;@s_npc_resist_unholy3}
		// npcgrp.txt:	property_list={4298;4278;4333}
		// [s_power_strike11]	=	769

		private void StartButton_Click(object sender, EventArgs e)
		{
			string NpcGrpFile;        // Name/path of npcgrp.txt file
			var aNpcSkill = new string[30001];   // Skilllist on each mob from npcgrp.txt file
			string SkillPchFile;        // Name/path of skillpch.txt file
			var aSkillPch = new string[10001];   // Skilllist on each mob from npcgrp.txt file
			string NpcDataFile;        // Name/path of npcgrp.txt file
			string TempStr;
			string TempStr2;
			string[] TempData;
			int iTemp;


			OpenFileDialog.Filter = "Lineage client text file (npcgrp.txt)|npcgrp.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			NpcGrpFile = OpenFileDialog.FileName;

			OpenFileDialog.Filter = "Lineage server script file (skill_pch.txt)|skill_pch.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			SkillPchFile = OpenFileDialog.FileName;

			OpenFileDialog.Filter = "Lineage server script file (npcdata.txt)|npcdata.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			NpcDataFile = OpenFileDialog.FileName;

			// ---- Loading NpcSkills ---- 
			var iNpcGrpFile = new System.IO.StreamReader(NpcGrpFile, System.Text.Encoding.Default, true);
			ProgressBar.Maximum = Conversions.ToInteger(iNpcGrpFile.BaseStream.Length);
			ProgressBar.Value = 0;
			while (iNpcGrpFile.EndOfStream != true)
			{
				TempStr = iNpcGrpFile.ReadLine();
				if (TempStr != null & TempStr.StartsWith("//") == false)
				{
					TempStr2 = Libraries.GetNeedParamFromStr(TempStr, "property_list");
					if ((TempStr2 ?? "") != "{0}")
						aNpcSkill[Conversions.ToInteger(Libraries.GetNeedParamFromStr(TempStr, "npc_id"))] = Libraries.GetNeedParamFromStr(TempStr, "property_list").Replace("{", "").Replace("}", "");
				}
				ProgressBar.Value = Conversions.ToInteger(iNpcGrpFile.BaseStream.Position * 100 / (double)iNpcGrpFile.BaseStream.Length);
				this.Update();
			}
			iNpcGrpFile.Close();
			ProgressBar.Value = 0;
			// End of Loading NpcSkills

			// ---- Loading Skills ---- 
			// [s_power_strike11]	=	769
			var iSkillPchFile = new System.IO.StreamReader(SkillPchFile, System.Text.Encoding.Default, true);
			ProgressBar.Maximum = Conversions.ToInteger(iSkillPchFile.BaseStream.Length);
			ProgressBar.Value = 0;
			while (iSkillPchFile.EndOfStream != true)
			{
				TempStr = Strings.Replace(iSkillPchFile.ReadLine(), Conversions.ToString((char)9), " ");
				if (TempStr != null & TempStr.StartsWith("//") == false)
				{

					// tabs and spaces correction
					TempStr = Strings.Replace(TempStr, " ", "");
					TempData = TempStr.Split(Conversions.ToChar("="));

					iTemp = Conversions.ToInteger(Conversions.Fix(Conversions.ToInteger(TempData[1]) / (double)256));
					if (iTemp > aSkillPch.Length)
						Array.Resize(ref aSkillPch, iTemp);

					// Fix with LvlSklBox
					if (LvlSklBox.Checked == true & aSkillPch[iTemp] != null)
					{
						var argName = aSkillPch[iTemp];
						aSkillPch[iTemp] = ClearDigit(ref argName);
					}
					else
						aSkillPch[iTemp] = TempData[0].Replace("[", "").Replace("]", "");
				}
				ProgressBar.Value = Conversions.ToInteger(iSkillPchFile.BaseStream.Position * 100 / (double)iSkillPchFile.BaseStream.Length);
				this.Update();
			}
			iSkillPchFile.Close();
			ProgressBar.Value = 0;
			// End of Loading Skills

			// ---- Main module ----

			var iNpcDataFile = new System.IO.StreamReader(NpcDataFile, System.Text.Encoding.Default, true);
			var oNpcDataFile = new System.IO.StreamWriter(NpcDataFile + ".fixed.txt", false, System.Text.Encoding.Unicode, 1);
			var outFile = new System.IO.StreamWriter(NpcDataFile + "_scriptCheck.log", true, System.Text.Encoding.Unicode, 1);

			ProgressBar.Maximum = Conversions.ToInteger(iNpcDataFile.BaseStream.Length);
			ProgressBar.Value = 0;

			// npc_begin	warrior	1	[gremlin]	level=1
			// npcdata.txt:	skill_list={@s_race_demonic;@s_evil_attack;@s_npc_resist_unholy3}
			// npcgrp.txt:	property_list={4298;4278;4333}  aNpcSkill
			// aSkillPch

			int NpcId;
			string OldSkillList;
			string NewSkillList;
			var aOldSkill = new string[0];
			var aNewSkill = new string[0];

			outFile.WriteLine(Constants.vbNewLine + "L2ScriptMaker. Npcdata skill_list fixer.");
			outFile.WriteLine(Conversions.ToString(DateAndTime.Now) + " Start" + Constants.vbNewLine);

			while (iNpcDataFile.EndOfStream != true)
			{
				TempStr = Strings.Replace(iNpcDataFile.ReadLine(), Conversions.ToString((char)9), " ");
				if (TempStr != null & TempStr.StartsWith("//") == false)
				{

					// tabs and spaces correction
					while (Strings.InStr(TempStr, "  ") != 0)
						TempStr = Strings.Replace(TempStr, "  ", " ");
					TempData = TempStr.Split((char)32);

					// Preparing
					Array.Clear(aNewSkill, 0, aNewSkill.Length);
					Array.Clear(aOldSkill, 0, aOldSkill.Length);
					OldSkillList = ""; NewSkillList = "";

					NpcId = Conversions.ToInteger(TempData[2]);

					OldSkillList = Libraries.GetNeedParamFromStr(TempStr, "skill_list");

					if (aNpcSkill[NpcId] != null)
					{
						aNewSkill = aNpcSkill[NpcId].Split(Conversions.ToChar(";"));

						NewSkillList = "{";
						var loopTo = aNewSkill.Length - 1;
						for (iTemp = 0; iTemp <= loopTo; iTemp++)
						{
							// npcdata.txt:	skill_list={@s_race_demonic;@s_evil_attack;@s_npc_resist_unholy3}
							if (iTemp > 0 & iTemp <= aNewSkill.Length - 1)
								NewSkillList += ";";

							// ----- Fix with LvlSklBox ----
							string sTemp1 = "";
							if (LvlSklBox.Checked == true)
							{
								aOldSkill = OldSkillList.Replace("{", "").Replace("}", "").Replace("@", "").Split(Conversions.ToChar(";"));
								int iTemp1;
								int iTemp2;
								iTemp1 = Conversions.ToInteger(aNewSkill[iTemp]);
								var argName1 = aSkillPch[iTemp1];
								sTemp1 = ClearDigit(ref argName1);
								var loopTo1 = aOldSkill.Length - 1;
								for (iTemp2 = 0; iTemp2 <= loopTo1; iTemp2++)
								{
									if (Strings.InStr(aOldSkill[iTemp2], sTemp1) != 0)
									{
										sTemp1 = aOldSkill[iTemp2];
										break;
									}
								}
							}
							else
								sTemp1 = aSkillPch[Conversions.ToInteger(aNewSkill[iTemp])];
							// ---- end of fix ---------

							NewSkillList += "@" + sTemp1;
						}
						NewSkillList += "}";
					}
					else
						NewSkillList = "{}";

					// ---- @s_full_magic_defence fix ----
					if (SFullMagicDefBox.Checked == true)
					{
						var loopTo2 = SkillIgnorListBox.Lines.Length - 1;
						for (iTemp = 0; iTemp <= loopTo2; iTemp++)
						{
							if (OldSkillList.Contains(SkillIgnorListBox.Lines[iTemp]) == true & NewSkillList.Contains(SkillIgnorListBox.Lines[iTemp]) == false)
							{

								// fix for s_npc_high_level_1 and s_npc_high_level_10
								if (iTemp == SkillIgnorListBox.Lines.Length - 1 & OldSkillList.Contains("@s_npc_high_level_10") == true)
									break;

								if ((NewSkillList ?? "") != "{}")
									NewSkillList = NewSkillList.Replace("}", ";}");
								NewSkillList = NewSkillList.Replace("}", SkillIgnorListBox.Lines[iTemp] + "}");
							}
						}
					}
					// end of @s_full_magic_defence fix

					if ((OldSkillList ?? "") != (NewSkillList ?? ""))
					{
						TempStr = TempStr.Replace(OldSkillList, NewSkillList).Replace((char)32, (char)9);
						outFile.WriteLine("Fixing npc: " + TempData[0] + Constants.vbTab + TempData[1] + Constants.vbTab + TempData[2] + Constants.vbTab + TempData[3]);
						outFile.WriteLine(OldSkillList + Constants.vbNewLine + "-->" + Constants.vbNewLine + NewSkillList + Constants.vbNewLine);
					}
				}
				TempStr = TempStr.Replace((char)32, (char)9);
				oNpcDataFile.WriteLine(TempStr);

				ProgressBar.Value = Conversions.ToInteger(iNpcDataFile.BaseStream.Position);
				ProgressBar.Update();
			}

			outFile.WriteLine(Conversions.ToString(DateAndTime.Now) + " End");
			outFile.Close();
			oNpcDataFile.Close();
			ProgressBar.Value = 0;

			MessageBox.Show("Done.");
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private string ClearDigit(ref string Name)
		{
			string ClearDigitRet = default(string);

			// ClearDigit = Name.Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "").Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "").Replace("0", "")
			// Dim cTemp() As Char = {CChar("1"), CChar("2"), CChar("3"), CChar("4"), CChar("5"), CChar("6"), CChar("7"), CChar("8"), CChar("9"), CChar("0")}
			int iTemp;
			for (iTemp = Name.Length - 1; iTemp >= 0; iTemp += -1)
			{
				if (char.IsDigit(Name[iTemp]) == true)
					Name = Name.Remove(iTemp, 1);
				else
					break;
			}
			ClearDigitRet = Name;
			return ClearDigitRet;
		}
	}
}
