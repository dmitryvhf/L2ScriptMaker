using L2ScriptMaker.Extensions;
using L2ScriptMaker.Extensions.VbCompatibleHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2ScriptMaker.Modules.Npc
{
	public partial class NpcDropItemChecker : Form
	{
		public NpcDropItemChecker()
		{
			InitializeComponent();
		}

		private struct GroupItems
		{
			public string name;
			public int minValue;
			public int maxValue;
			public double chance;
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			string sNpcdataFile;
			OpenFileDialog.Filter = "Lineage II npcdata config (npcdata.txt)|npcdata*.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sNpcdataFile = OpenFileDialog.FileName;

			if (System.IO.File.Exists(sNpcdataFile + ".bak"))
			{
				if ((int)MessageBox.Show("Overwrite previous backup file?", "Overwrite", MessageBoxButtons.YesNo) == (int)DialogResult.No)
					return;
			}

			System.IO.File.Copy(sNpcdataFile, sNpcdataFile + ".bak", true);
			var inFile = new System.IO.StreamReader(sNpcdataFile + ".bak", System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter(sNpcdataFile, false, System.Text.Encoding.Unicode, 1);

			var outLogFile = new System.IO.StreamWriter(sNpcdataFile + "_scriptCheck.log", true, System.Text.Encoding.Unicode, 1);
			outLogFile.WriteLine("L2ScriptMaker: Npcdata.txt DropItemChecker.");
			outLogFile.WriteLine(Conversions.ToString(DateAndTime.Now) + " Start" + Constants.vbNewLine);
			int iTemp;
			int iTemp2;
			string sTemp;
			string sTempGroup;

			double iSumChance = 0;
			double iSumChanceInc = 1;

			var aGroup = new string[1];
			var aGroupChance = new string[1];

			string[] aItemInGroup;    // Items list in one group
			var aGroupItem = new string[4];     // One item in one group
			var aTemp2 = new string[4];         // One item splited to name,min,max,chance

			double iItemChanceInc = Conversions.ToDouble(ItemChanceRateTextBox.Text);
			string sTempNewGroup;
			string sTempForNew;

			long iLineCursor = 0;
			bool isSpoil = true;
			bool stopOnError = StopOnErrorCheckBox.Checked;

			// aGroup - all group in mob drop
			// aGroupItem - all items in one group

			if (ClearBadParamCheckBox.Checked == true)
				outLogFile.WriteLine("Cleaning bad drop Activated!" + Constants.vbNewLine);

			ToolStripProgressBar.Value = 0;
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				iLineCursor += 1;
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				if (!string.IsNullOrEmpty(sTemp.Trim()) & sTemp.StartsWith("//") == false)
				{
					if (CheckBoxIgnoreSpoil.Checked == true)
						goto ContinueWorkingDrop;

					// ---- SPOIL checker ---
					sTempGroup = Libraries.GetNeedParamFromStr(sTemp, "corpse_make_list");
					if ((sTempGroup ?? "") != "{}")
					{
						isSpoil = true;

						sTempNewGroup = sTemp;

						// Step 1. remove start/end symbols {...}
						sTempGroup = sTempGroup.Substring(2, sTempGroup.Length - 2);

						// Step 2. Split groups to array
						// {{{[adena];14000000;18000000;100}};100};{{{[dark_legion_s_edge];1;2;25};{[meteor_shower];1;2;25}};100}
						sTempGroup = sTempGroup.Replace("};{", "}|{").Replace("}", "").Replace("{", "");
						// sTempGroup = sTempGroup.Replace("{{{[", "{[")
						// {{{[adena];14000000;18000000;100}};100}|{{{[dark_legion_s_edge];1;2;25};{[meteor_shower];1;2;25}};100}

						aGroup = sTempGroup.Split(Conversions.ToChar("|"));
						Array.Resize(ref aGroupChance, aGroup.Length);
						// {{ {[adena];14000000;18000000;100}};100};
						// {{ {[dark_legion_s_edge];1;2;25};{[meteor_shower];1;2;25}};100}

						sTempNewGroup = "";
						var loopTo = aGroup.Length - 1;
						for (iTemp = 0; iTemp <= loopTo; iTemp++)
						{

							// aGroupChance(iTemp) = aGroup(iTemp).Substring(InStr(aGroup(iTemp), "}};") + 2, aGroup(iTemp).Length - InStr(aGroup(iTemp), "}};") - 3)
							aGroupChance[iTemp] = aGroup[iTemp].Remove(0, aGroup[iTemp].LastIndexOf(";") + 1);
							try
							{
								iTemp2 = Conversions.ToInteger(Conversions.ToDouble(aGroupChance[iTemp]));
							}
							catch (Exception ex)
							{
								bool result = CriticalErrorExit(isSpoil, ref sTemp, outLogFile, iLineCursor, stopOnError, outFile, inFile);
								if (result) return;
								goto ContinueWorkingDrop;
								// goto CriticalErrorExit;
							}

							sTempGroup = aGroup[iTemp].Replace("};{", "}|{").Replace("{{{", "{");
							// {[dark_legion_s_edge];1;2;25}|{[meteor_shower];1;2;25}};100}

							// sTempGroup = sTempGroup.Replace(";", "|")
							// {[dark_legion_s_edge];1;2;25}|{[meteor_shower];1;2;25}
							aItemInGroup = sTempGroup.Split(Conversions.ToChar("|"));
							// If aItemInGroup.Length = 1 Then GoTo CriticalErrorExit
							// [dark_legion_s_edge];1;2;25
							// [meteor_shower];1;2;25

							iSumChance = 0;
							iSumChanceInc = 1;
							var loopTo1 = aItemInGroup.Length - 1;
							// Array.Resize(aGroupItem, aItemInGroup.Length)
							for (iTemp2 = 0; iTemp2 <= loopTo1; iTemp2++)
							{
								aTemp2 = aItemInGroup[iTemp2].Split(Conversions.ToChar(";"));
								if (aTemp2.Length != 4)
								{
									bool result = CriticalErrorExit(isSpoil, ref sTemp, outLogFile, iLineCursor, stopOnError, outFile, inFile);
									if (result) return;
									goto ContinueWorkingDrop;
								}

								aGroupItem[0] = aTemp2[0];
								aGroupItem[1] = aTemp2[1];
								aGroupItem[2] = aTemp2[2];
								if (AdenaSkipCheckBox.Checked == true & iItemChanceInc > 0 & (aGroupItem[0] ?? "") == "[adena]")
									aGroupItem[3] = aTemp2[3];
								else
									aGroupItem[3] = Conversions.ToString(Conversions.ToDouble(aTemp2[3]) * iItemChanceInc);

								iSumChance = iSumChance + Conversions.ToDouble(aGroupItem[3]);
								aItemInGroup[iTemp2] = Strings.Join(aGroupItem, ";");
							}

							iSumChance = Conversions.ToDouble(Strings.Format(iSumChance, "0.####"));

							if (iSumChance > 100)
								// MessageBox.Show("Attention in npc:" & vbNewLine & sTemp.Substring(0, 30) & vbNewLine & "in group:" & vbNewLine & aGroup(iTemp))
								// iSumChanceInc = CDbl(Format((100 / iSumChance), "0.####"))
								iSumChanceInc = 100 / iSumChance;

							// Rebuilding group
							iSumChance = 0;  // Additional control
											 // sTempForNew = "{{"
							sTempForNew = "";
							var loopTo2 = aItemInGroup.Length - 1;
							for (iTemp2 = 0; iTemp2 <= loopTo2; iTemp2++)
							{
								aTemp2 = aItemInGroup[iTemp2].Split(Conversions.ToChar(";"));
								aGroupItem[0] = aTemp2[0];
								aGroupItem[1] = aTemp2[1];
								aGroupItem[2] = aTemp2[2];
								aGroupItem[3] = Strings.Format(Conversions.ToDouble(aTemp2[3]) * iSumChanceInc, "0.####");
								// aGroupItem(3) = CStr(CDbl(aTemp2(3)) * iSumChanceInc)

								iSumChance = iSumChance + Conversions.ToDouble(aTemp2[3]) * iSumChanceInc;

								sTempForNew = sTempForNew + "{" + Strings.Join(aGroupItem, ";") + "}";
								if (iTemp2 < aItemInGroup.Length - 1)
									sTempForNew = sTempForNew + ";";
							}
							iSumChance = Conversions.ToDouble(Strings.Format(iSumChance, "0.####"));
							if (iSumChance > 100)
								MessageBox.Show("Attention in npc:" + Constants.vbNewLine + sTemp.Substring(0, 30) + Constants.vbNewLine + "in group:" + Constants.vbNewLine + aGroup[iTemp]);

							// sTempForNew = sTempForNew & "};" & aGroupChance(iTemp) & "}"
							sTempForNew = sTempForNew; // & aGroupChance(iTemp) & "}"
							aGroup[iTemp] = sTempForNew;
						}
						sTempNewGroup = "{" + Strings.Join(aGroup, ";") + "}";
						sTemp = sTemp.Replace(Libraries.GetNeedParamFromStr(sTemp, "corpse_make_list"), sTempNewGroup);
					}
				// ---- SPOIL checker END ---

				ContinueWorkingDrop:
					;


					// ---- DROP checker ---
					sTempGroup = Libraries.GetNeedParamFromStr(sTemp, "additional_make_multi_list");
					if ((sTempGroup ?? "") != "{}")
					{
						isSpoil = false;

						sTempNewGroup = sTemp;

						// Step 1. remove start/end symbols {...}
						sTempGroup = sTempGroup.Substring(2, sTempGroup.Length - 2);

						// Step 2. Split groups to array
						// {{{[adena];14000000;18000000;100}};100};{{{[dark_legion_s_edge];1;2;25};{[meteor_shower];1;2;25}};100}
						sTempGroup = sTempGroup.Replace("};{{", "}|{{");
						// sTempGroup = sTempGroup.Replace("{{{[", "{[")
						// {{{[adena];14000000;18000000;100}};100}|{{{[dark_legion_s_edge];1;2;25};{[meteor_shower];1;2;25}};100}

						aGroup = sTempGroup.Split(Conversions.ToChar("|"));
						Array.Resize(ref aGroupChance, aGroup.Length);
						// {{ {[adena];14000000;18000000;100}};100};
						// {{ {[dark_legion_s_edge];1;2;25};{[meteor_shower];1;2;25}};100}

						sTempNewGroup = "";
						var loopTo3 = aGroup.Length - 1;
						for (iTemp = 0; iTemp <= loopTo3; iTemp++)
						{

							// aGroupChance(iTemp) = aGroup(iTemp).Substring(InStr(aGroup(iTemp), "}};") + 2, aGroup(iTemp).Length - InStr(aGroup(iTemp), "}};") - 3)
							aGroupChance[iTemp] = aGroup[iTemp].Remove(0, Strings.InStr(aGroup[iTemp], "}};") + 2).Replace("}", "");
							try
							{
								iTemp2 = Conversions.ToInteger(Conversions.ToDouble(aGroupChance[iTemp]));
							}
							catch (Exception ex)
							{
								bool result = CriticalErrorExit(isSpoil, ref sTemp, outLogFile, iLineCursor, stopOnError, outFile, inFile);
								if (result) return;
								goto ContinueWorking;
							}

							sTempGroup = aGroup[iTemp].Replace("};{", "}|{").Replace("{{{", "{");
							// {[dark_legion_s_edge];1;2;25}|{[meteor_shower];1;2;25}};100}


							sTempGroup = sTempGroup.Substring(0, Strings.InStr(sTempGroup, "}};") + 1).Replace("{", "").Replace("}", "");
							// {[dark_legion_s_edge];1;2;25}|{[meteor_shower];1;2;25}
							aItemInGroup = sTempGroup.Split(Conversions.ToChar("|"));
							// If aItemInGroup.Length = 1 Then GoTo CriticalErrorExit
							// [dark_legion_s_edge];1;2;25
							// [meteor_shower];1;2;25

							iSumChance = 0;
							iSumChanceInc = 1;
							var loopTo4 = aItemInGroup.Length - 1;
							// Array.Resize(aGroupItem, aItemInGroup.Length)
							for (iTemp2 = 0; iTemp2 <= loopTo4; iTemp2++)
							{
								aTemp2 = aItemInGroup[iTemp2].Split(Conversions.ToChar(";"));
								if (aTemp2.Length != 4)
								{
									bool result = CriticalErrorExit(isSpoil, ref sTemp, outLogFile, iLineCursor, stopOnError, outFile, inFile);
									if (result) return;
									goto ContinueWorking;
								}

								aGroupItem[0] = aTemp2[0];
								aGroupItem[1] = aTemp2[1];
								aGroupItem[2] = aTemp2[2];
								if (AdenaSkipCheckBox.Checked == true & iItemChanceInc > 0 & (aGroupItem[0] ?? "") == "[adena]")
									aGroupItem[3] = aTemp2[3];
								else
									aGroupItem[3] = Conversions.ToString(Conversions.ToDouble(aTemp2[3]) * iItemChanceInc);

								iSumChance = iSumChance + Conversions.ToDouble(aGroupItem[3]);
								aItemInGroup[iTemp2] = Strings.Join(aGroupItem, ";");
							}

							iSumChance = Conversions.ToDouble(Strings.Format(iSumChance, "0.####"));

							if (iSumChance > 100)
								// MessageBox.Show("Attention in npc:" & vbNewLine & sTemp.Substring(0, 30) & vbNewLine & "in group:" & vbNewLine & aGroup(iTemp))
								// iSumChanceInc = CDbl(Format((100 / iSumChance), "0.####"))
								iSumChanceInc = 100 / iSumChance;

							// Rebuilding group
							iSumChance = 0;  // Additional control
							sTempForNew = "{{";
							var loopTo5 = aItemInGroup.Length - 1;
							for (iTemp2 = 0; iTemp2 <= loopTo5; iTemp2++)
							{
								aTemp2 = aItemInGroup[iTemp2].Split(Conversions.ToChar(";"));
								aGroupItem[0] = aTemp2[0];
								aGroupItem[1] = aTemp2[1];
								aGroupItem[2] = aTemp2[2];
								aGroupItem[3] = Strings.Format(Conversions.ToDouble(aTemp2[3]) * iSumChanceInc, "0.####");
								// aGroupItem(3) = CStr(CDbl(aTemp2(3)) * iSumChanceInc)

								iSumChance = iSumChance + Conversions.ToDouble(aTemp2[3]) * iSumChanceInc;

								sTempForNew = sTempForNew + "{" + Strings.Join(aGroupItem, ";") + "}";
								if (iTemp2 < aItemInGroup.Length - 1)
									sTempForNew = sTempForNew + ";";
							}
							iSumChance = Conversions.ToDouble(Strings.Format(iSumChance, "0.####"));
							if (iSumChance > 100)
								MessageBox.Show("Attention in npc:" + Constants.vbNewLine + sTemp.Substring(0, 30) + Constants.vbNewLine + "in group:" + Constants.vbNewLine + aGroup[iTemp]);

							sTempForNew = sTempForNew + "};" + aGroupChance[iTemp] + "}";
							aGroup[iTemp] = sTempForNew;
						}
						sTempNewGroup = "{" + Strings.Join(aGroup, ";") + "}";
						sTemp = sTemp.Replace(Libraries.GetNeedParamFromStr(sTemp, "additional_make_multi_list"), sTempNewGroup);
					}
				}
			ContinueWorking:
				;
				outFile.WriteLine(sTemp);
			}
			ToolStripProgressBar.Value = 0;

			outLogFile.WriteLine();
			outLogFile.WriteLine(Conversions.ToString(DateAndTime.Now) + " End");
			outLogFile.WriteLine();

			outLogFile.Close();
			outFile.Close();
			inFile.Close();

			ToolStripProgressBar.Value = 0;
			MessageBox.Show("Complete");
			return;

		//CriticalErrorExit:

		//	;
		//	CriticalErrorExit(isSpoil, sTemp, outLogFile, iLineCursor, stopOnError, outFile, inFile);
		//	return;
		}

		private bool CriticalErrorExit(bool isSpoil, ref string sTemp, StreamWriter outLogFile, long iLineCursor, bool stopOnError,
			StreamWriter outFile, StreamReader inFile)
		{
			string sTempGroup;
			if (isSpoil == true)
				sTempGroup = "(Spoil:) " + Libraries.GetNeedParamFromStr(sTemp, "corpse_make_list");
			else
				sTempGroup = "(Drop: ) " + Libraries.GetNeedParamFromStr(sTemp, "additional_make_multi_list");

			outLogFile.WriteLine("Parsing error in line: " + Conversions.ToString(iLineCursor) + Constants.vbTab + sTempGroup);

			if (stopOnError == true)
			{
				outLogFile.WriteLine();
				outLogFile.WriteLine(Conversions.ToString(DateAndTime.Now) + " End");
				outLogFile.WriteLine();

				outLogFile.Close();
				outFile.Close();
				inFile.Close();
				ToolStripProgressBar.Value = 0;
				MessageBox.Show("Parsing error in line: " + Conversions.ToString(iLineCursor) + Constants.vbTab + sTempGroup);
				return true;
			}
			else if (isSpoil == true)
			{
				if (ClearBadParamCheckBox.Checked == true)
					sTemp = Libraries.SetNeedParamToStr(sTemp, "corpse_make_list", "{}");
				return false;
			}
			else
			{
				if (ClearBadParamCheckBox.Checked == true)
					sTemp = Libraries.SetNeedParamToStr(sTemp, "additional_make_multi_list", "{}");
				return false;
			}
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}


		private void ItemChanceRateTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				ItemChanceRateTextBox.Text = ItemChanceRateTextBox.Text.Trim();
				ItemChanceRateTextBox.Text = Conversions.ToString(Conversions.ToDouble(ItemChanceRateTextBox.Text));
			}
			catch (Exception ex)
			{
				ItemChanceRateTextBox.Text = "1";
			}

			if ((ItemChanceRateTextBox.Text ?? "") == "0" | Conversions.ToDouble(ItemChanceRateTextBox.Text) < 0)
				ItemChanceRateTextBox.Text = "1";
		}

		private void ClearBadParamCheckBox_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void StopOnErrorCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (StopOnErrorCheckBox.Checked == true)
			{
				if (ClearBadParamCheckBox.Checked == true)
					ClearBadParamCheckBox.Checked = false;
			}
		}
	}
}
