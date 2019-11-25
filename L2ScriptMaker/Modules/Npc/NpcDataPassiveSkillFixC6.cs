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
	public partial class NpcDataPassiveSkillFixC6 : Form
	{
		public NpcDataPassiveSkillFixC6()
		{
			InitializeComponent();
		}


		// npcdata.txt:	skill_list={@s_race_demonic;@s_evil_attack;@s_npc_resist_unholy3}
		// npcgrp.txt:	property_list={4298;4278;4333}
		// [s_power_strike11]	=	769

		private struct SkillData
		{
			// Dim skill_id As Integer
			// Dim skill_level As Integer
			public string skill_name;
			public string skill_op;
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			string NpcGrpFile = "npcgrp.txt";    // Name/path of npcgrp.txt file
			var aNpcPassiveSkill = new string[40001];   // Skilllist on each mob from npcgrp.txt file
			var aNpcActiveSkill = new string[40001];   // Skilllist on each mob from npcgrp.txt file
													   // Dim SkillPchFile As String = "skill_pch.txt"     ' Name/path of skillpch.txt file
			string SkillDataFile = "skilldata.txt";     // Name/path of skillpch.txt file

			// Dim aSkillPchId(30000) As String   ' Skilllist on each mob from skill_pch.txt file
			// Dim aSkillPchName(30000) As String   ' Skilllist on each mob from skill_pch.txt file

			var aSkillData = new SkillData[30001, 851];   // Skilllist on each mob from skill_pch.txt file

			string inNpcDataFile = "npcdata.txt";      // Name/path of npcgrp.txt file
			string outNpcDataFile = "npcdata_new.txt";      // Name/path of npcgrp.txt file

			int aRequiredSkillsCursor = -1;
			var aRequiredSkills = new string[101];    // founded skills
			string TempStr;
			string TempStr2;
			string[] TempData;
			int iTemp;
			int iTemp1;
			int iTemp2;

			if (System.IO.File.Exists(NpcGrpFile) == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Filter = "Lineage client text file (npcgrp.txt)|npcgrp.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				NpcGrpFile = OpenFileDialog.FileName;
			}

			// If System.IO.File.Exists(SkillPchFile) = False Then
			// OpenFileDialog.FileName = ""
			// OpenFileDialog.Filter = "Lineage server script file (skill_pch.txt)|skill_pch.txt|All files|*.*"
			// If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
			// SkillPchFile = OpenFileDialog.FileName
			// End If

			if (System.IO.File.Exists(SkillDataFile) == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Filter = "Lineage server script file (skilldata.txt)|skilldata*.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				SkillDataFile = OpenFileDialog.FileName;
			}

			if (System.IO.File.Exists(inNpcDataFile) == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Filter = "Lineage server npc script file (npcdata.txt)|npcdata*.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				inNpcDataFile = OpenFileDialog.FileName;
			}

			SaveFileDialog.FileName = outNpcDataFile;
			SaveFileDialog.Filter = "Lineage II server New npc script (npcdata.txt)|npcdata*.txt|All files|*.*";
			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			outNpcDataFile = SaveFileDialog.FileName;


			// ---- Loading Skills ---- 
			ToolStripStatusLabel.Text = "Loading skilldata file...";
			var iSkillPchFile = new System.IO.StreamReader(SkillDataFile, System.Text.Encoding.Default, true);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(iSkillPchFile.BaseStream.Length);
			ToolStripProgressBar.Value = 0;

			// skill_begin	skill_name=[s_triple_slash1]	/* [Triple Slash] */	skill_id=1	level=1	

			while (iSkillPchFile.EndOfStream != true)
			{
				TempStr = Strings.Replace(iSkillPchFile.ReadLine(), Conversions.ToString((char)9), " ");
				if (TempStr != null == true)
				{
					if (TempStr.StartsWith("//") == false)
					{
						iTemp1 = Conversions.ToInteger(Libraries.GetNeedParamFromStr(TempStr, "skill_id"));
						iTemp2 = Conversions.ToInteger(Libraries.GetNeedParamFromStr(TempStr, "level"));

						aSkillData[iTemp1, iTemp2].skill_name = Libraries.GetNeedParamFromStr(TempStr, "skill_name").Replace("[", "").Replace("]", "");
						aSkillData[iTemp1, iTemp2].skill_op = Libraries.GetNeedParamFromStr(TempStr, "operate_type");
					}
				}
				ToolStripProgressBar.Value = Conversions.ToInteger(iSkillPchFile.BaseStream.Position);
				StatusStrip.Update();
			}
			iSkillPchFile.Close();
			ToolStripProgressBar.Value = 0;
			// End of Loading Skills

			// ---- Loading NpcSkills ---- 
			System.IO.StreamReader iNpcDataFile;
			System.IO.StreamWriter oNpcDataFile;

			var outFile = new System.IO.StreamWriter(inNpcDataFile + "_scriptCheck.log", true, System.Text.Encoding.Unicode, 1);
			outFile.WriteLine(Constants.vbNewLine + "L2ScriptMaker. NpcdataC6 skill_list fixer.");
			outFile.WriteLine(Conversions.ToString(DateAndTime.Now) + " Start" + Constants.vbNewLine);
			string sTemp;

			// ResultsTextBox.Text

			// L2Disasm Format
			// cnt_dtab1=2	dtab1[0]=4416	dtab1[1]=13	dtab1[2]=	dtab1[3]=	
			string sTemp2;

			var aTemp = new string[4];

			ToolStripStatusLabel.Text = "Loading npcgrp file...";
			var iNpcGrpFile = new System.IO.StreamReader(NpcGrpFile, System.Text.Encoding.Default, true);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(iNpcGrpFile.BaseStream.Length);
			ToolStripProgressBar.Value = 0;
			while (iNpcGrpFile.EndOfStream != true)
			{
				TempStr = iNpcGrpFile.ReadLine();
				if (TempStr != null & TempStr.StartsWith("//") == false)
				{
					TempStr2 = Libraries.GetNeedParamFromStr(TempStr, "cnt_dtab1");
					if ((TempStr2 ?? "") != "0" & (TempStr2 ?? "") != "1")
					{
						sTemp = "{"; sTemp2 = "npc_ai={";
						var loopTo = Conversions.ToInteger(TempStr2) - 1;
						for (iTemp = 0; iTemp <= loopTo; iTemp += 2)
						{
							iTemp1 = Conversions.ToInteger(Libraries.GetNeedParamFromStr(TempStr, "dtab1[" + Conversions.ToString(iTemp) + "]"));
							iTemp2 = Conversions.ToInteger(Libraries.GetNeedParamFromStr(TempStr, "dtab1[" + Conversions.ToString(iTemp + 1) + "]"));
							if (string.IsNullOrEmpty(aSkillData[iTemp1, iTemp2].skill_name))
								// MessageBox.Show("Skill pch_id:" & iTemp2 & " not found in skilldata. Update file and try again", "Skill not defined", MessageBoxButtons.OK)
								// ResultsTextBox.AppendText("Npc_id: " & Libraries.GetNeedParamFromStr(TempStr, "tag") & " Skill pch_id:" & iTemp2 & " not found in skilldata. Update file and try again" & vbNewLine)
								outFile.WriteLine("Npc_id: " + Libraries.GetNeedParamFromStr(TempStr, "tag") + Constants.vbTab + "Skill id:" + Conversions.ToString(iTemp1) + Constants.vbTab + "Skill_level:" + Conversions.ToString(iTemp2));
							else
							{
								if (Array.IndexOf(aRequiredSkills, aSkillData[iTemp1, iTemp2].skill_name) == -1)
								{
									aRequiredSkillsCursor += 1;
									if (aRequiredSkillsCursor == aRequiredSkills.Length)
										Array.Resize(ref aRequiredSkills, aRequiredSkillsCursor + 1);
									aRequiredSkills[aRequiredSkillsCursor] = aSkillData[iTemp1, iTemp2].skill_name; // aSkillPch(iTemp2)
								}

								if ((aSkillData[iTemp1, iTemp2].skill_op ?? "") == "P")
								{
									sTemp = sTemp + "@" + aSkillData[iTemp1, iTemp2].skill_name;
									if (iTemp < Conversions.ToInteger(TempStr2) - 2)
										sTemp = sTemp + ";";
								}
								else
								{
									sTemp2 = sTemp2 + "{[DDMagic]=@" + aSkillData[iTemp1, iTemp2].skill_name + "}";
									if (iTemp < Conversions.ToInteger(TempStr2) - 2)
										sTemp2 = sTemp2 + ";";
								}
							}
						}
						sTemp = sTemp + "}"; sTemp2 = sTemp2 + "}";
						aNpcPassiveSkill[Conversions.ToInteger(Libraries.GetNeedParamFromStr(TempStr, "tag"))] = sTemp;
						if ((sTemp2 ?? "") != "npc_ai={}")
							aNpcActiveSkill[Conversions.ToInteger(Libraries.GetNeedParamFromStr(TempStr, "tag"))] = sTemp2;
					}
				}
				ToolStripProgressBar.Value = Conversions.ToInteger(iNpcGrpFile.BaseStream.Position);
				StatusStrip.Update();
			}
			iNpcGrpFile.Close();
			ToolStripProgressBar.Value = 0;
			// End of Loading NpcSkills
			outFile.WriteLine();
			outFile.WriteLine("Start fixing passive skills...");
			outFile.WriteLine();
			outFile.Flush();

			outFile.WriteLine("Required Skills for Mobs:");
			var loopTo1 = aRequiredSkillsCursor;
			for (iTemp2 = 0; iTemp2 <= loopTo1; iTemp2++)
				outFile.WriteLine(Conversions.ToString(iTemp2) + ": " + aRequiredSkills[iTemp2]);// & ": " & aSkillPch(aRequiredSkills(iTemp2)))
			outFile.WriteLine();

			if (CheckBoxSaveActive.Checked == true)
			{
				oNpcDataFile = new System.IO.StreamWriter(outNpcDataFile + "_skills.txt", false, System.Text.Encoding.Unicode, 1);
				var loopTo2 = aNpcActiveSkill.Length - 1;
				for (iTemp = 0; iTemp <= loopTo2; iTemp++)
					oNpcDataFile.WriteLine(aNpcActiveSkill[iTemp]);
				oNpcDataFile.Close();
			}
			if (CheckBoxStopActive.Checked == true)
			{
				outFile.Close();
				ToolStripProgressBar.Value = 0;
				ToolStripStatusLabel.Text = "Complete.";
				MessageBox.Show("Done.");
				return;
			}


			// ---- Main module ----

			ToolStripStatusLabel.Text = "Writing npdata file...";
			this.Update();
			iNpcDataFile = new System.IO.StreamReader(inNpcDataFile, System.Text.Encoding.Default, true);
			if (System.IO.File.Exists(outNpcDataFile))
				System.IO.File.Copy(outNpcDataFile, outNpcDataFile + ".bak", true);
			oNpcDataFile = new System.IO.StreamWriter(outNpcDataFile, false, System.Text.Encoding.Unicode, 1);

			ToolStripProgressBar.Maximum = Conversions.ToInteger(iNpcDataFile.BaseStream.Length);
			ToolStripProgressBar.Value = 0;

			// npc_begin	warrior	1	[gremlin]	level=1
			// npcdata.txt:	skill_list={@s_race_demonic;@s_evil_attack;@s_npc_resist_unholy3}
			// npcgrp.txt:	property_list={4298;4278;4333}  aNpcSkill
			// skillpch.txt   aSkillPch(1130509) = s_race13

			int NpcId;
			string OldSkillList;
			string NewSkillList;

			while (iNpcDataFile.EndOfStream != true)
			{
				TempStr = Strings.Replace(iNpcDataFile.ReadLine(), Conversions.ToString((char)9), " ").Trim();
				if (!string.IsNullOrEmpty(TempStr) & TempStr != null & TempStr.StartsWith("//") == false)
				{

					// tabs and spaces correction
					while (Strings.InStr(TempStr, "  ") != 0)
						TempStr = Strings.Replace(TempStr, "  ", " ");
					TempData = TempStr.Split((char)32);
					NpcId = Conversions.ToInteger(TempData[2]);

					// Preparing
					OldSkillList = ""; NewSkillList = "";

					OldSkillList = Libraries.GetNeedParamFromStr(TempStr, "skill_list");
					NewSkillList = aNpcPassiveSkill[NpcId];
					if (NewSkillList == null)
						NewSkillList = "{}";

					// Magical Defence fix
					if (MagicDefCheckBox.Checked == true)
					{
						NewSkillList = NewSkillList.Replace("}", "");
						// If NewSkillList <> "{" Then NewSkillList = NewSkillList & ";"

						switch (TempData[1])
						{
							case "pet":
								{
									if ((NewSkillList ?? "") != "{")
										NewSkillList = NewSkillList + ";";
									NewSkillList = NewSkillList + "@" + CustomNameTextBox.Lines[0] + "}"; // "@s_summon_magic_defence}"
									break;
								}

							case "summon":
								{
									if ((NewSkillList ?? "") != "{")
										NewSkillList = NewSkillList + ";";
									NewSkillList = NewSkillList + "@" + CustomNameTextBox.Lines[0] + "}"; // "@s_summon_magic_defence}"
									break;
								}

							case "monrace":
								{
									if ((NewSkillList ?? "") != "{")
										NewSkillList = NewSkillList + ";";
									NewSkillList = NewSkillList + "@s_full_magic_defence;@s_npc_abnormal_immunity}"; // "@s_npc_abnormal_immunity}"
									break;
								}

							case "warrior":
								{
									if ((Libraries.GetNeedParamFromStr(TempStr, "race") ?? "") == "castle_guard" | (Libraries.GetNeedParamFromStr(TempStr, "race") ?? "") == "mercenary")
									{
										if (MagicDefCheckBox.Checked == true & AutosetToBossCheckBox.Checked == true)
										{
											if ((NewSkillList ?? "") != "{")
												NewSkillList = NewSkillList + ";";
											NewSkillList = NewSkillList + "@" + CustomNameTextBox.Lines[1]; // & "}" ' "@s_full_magic_defence}"
										}
										else
										{
										}
									}
									else
									{
									}
									NewSkillList = NewSkillList + "}";
									break;
								}

							case "boss":
								{
									if (MagicDefCheckBox.Checked == true & AutosetToBossCheckBox.Checked == true)
									{
										if ((NewSkillList ?? "") != "{")
											NewSkillList = NewSkillList + ";";
										NewSkillList = NewSkillList + "@" + CustomNameTextBox.Lines[1]; // & "}" ' "@s_full_magic_defence}"
									}
									else
									{
									}
									NewSkillList = NewSkillList + "}";
									break;
								}

							case "zzoldagu":
								{
									// NewSkillList = NewSkillList & "}"
									if (MagicDefCheckBox.Checked == true & AutosetToBossCheckBox.Checked == true)
									{
										if ((NewSkillList ?? "") != "{")
											NewSkillList = NewSkillList + ";";
										NewSkillList = NewSkillList + "@" + CustomNameTextBox.Lines[1]; // & "}" ' "@s_full_magic_defence}"
									}
									else
									{
									}
									NewSkillList = NewSkillList + "}";
									break;
								}

							default:
								{
									if ((NewSkillList ?? "") != "{")
										NewSkillList = NewSkillList + ";";
									NewSkillList = NewSkillList + "@" + CustomNameTextBox.Lines[1] + "}"; // "@s_full_magic_defence}"
									break;
								}
						}
					}

					if ((OldSkillList ?? "") != (NewSkillList ?? ""))
					{
						// TempStr = TempStr.Replace(OldSkillList, NewSkillList).Replace(Chr(32), Chr(9))
						TempStr = Libraries.SetNeedParamToStr(TempStr, "skill_list", NewSkillList);
						outFile.WriteLine("Fixing npc: " + TempData[0] + Constants.vbTab + TempData[1] + Constants.vbTab + TempData[2] + Constants.vbTab + TempData[3]);
						outFile.WriteLine(OldSkillList + Constants.vbNewLine + "-->" + Constants.vbNewLine + NewSkillList + Constants.vbNewLine);
					}
				}
				TempStr = TempStr.Replace((char)32, (char)9);
				oNpcDataFile.WriteLine(TempStr);

				ToolStripProgressBar.Value = Conversions.ToInteger(iNpcDataFile.BaseStream.Position);
				StatusStrip.Update();
			}

			outFile.WriteLine();
			outFile.WriteLine(Conversions.ToString(DateAndTime.Now) + " End");
			outFile.WriteLine();
			outFile.Close();
			oNpcDataFile.Close();
			ToolStripProgressBar.Value = 0;

			ToolStripStatusLabel.Text = "Complete.";
			MessageBox.Show("Done.");
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void MagicDefCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (MagicDefCheckBox.Checked == false)
			{
				AutosetToBossCheckBox.Checked = false;
				AutosetToBossCheckBox.Enabled = false;
			}
			else
				AutosetToBossCheckBox.Enabled = true;
		}
	}
}
