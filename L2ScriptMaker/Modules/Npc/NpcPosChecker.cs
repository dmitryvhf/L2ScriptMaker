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
	public partial class NpcPosChecker : Form
	{
		public NpcPosChecker()
		{
			InitializeComponent();
		}

		private string[] NpcPch = new string[25001];

		private bool ValidPositionInTerriotory(string[] aZone, string sSpawn)
		{
			string[] aTempPos;
			string[] aTemp;
			int iTemp;
			int iTemp2;

			string sTemp = sSpawn.Substring(1, Strings.InStr(sSpawn, ")") - 2); // ( 108681, -101892,   -3544) [maze_gargoyle_lad]
			sTemp = sTemp.Replace(" ", "");
			aTempPos = sTemp.Split(Conversions.ToChar(","));
			var XMin = default(int);
			var XMax = default(int);
			var YMin = default(int);
			var YMax = default(int);
			var ZMin = default(int);
			var ZMax = default(int);
			var loopTo = aZone.Length - 1;

			// Step1. Scanning Territory for Min,Max
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{

				// {106332;-102753;-4183;-3383}
				aTemp = aZone[iTemp].Split(Conversions.ToChar(";"));
				var loopTo1 = aTemp.Length - 1;
				for (iTemp2 = 0; iTemp2 <= loopTo1; iTemp2++)
				{
					if (iTemp == 0)
					{
						// Define first coordinates as default
						XMin = Conversions.ToInteger(aTemp[0]); XMax = Conversions.ToInteger(aTemp[0]);
						YMin = Conversions.ToInteger(aTemp[1]); YMax = Conversions.ToInteger(aTemp[1]);
						ZMin = Conversions.ToInteger(aTemp[2]); ZMax = Conversions.ToInteger(aTemp[3]);
					}

					if (XMin > Conversions.ToInteger(aTemp[0]))
						XMin = Conversions.ToInteger(aTemp[0]);
					if (XMax < Conversions.ToInteger(aTemp[0]))
						XMax = Conversions.ToInteger(aTemp[0]);

					if (YMin > Conversions.ToInteger(aTemp[1]))
						YMin = Conversions.ToInteger(aTemp[1]);
					if (YMax < Conversions.ToInteger(aTemp[1]))
						YMax = Conversions.ToInteger(aTemp[1]);

					if (ZMin > Conversions.ToInteger(aTemp[2]))
						ZMin = Conversions.ToInteger(aTemp[2]);
					if (ZMax < Conversions.ToInteger(aTemp[3]))
						ZMax = Conversions.ToInteger(aTemp[3]);
				}
			}

			if (XMin > Conversions.ToInteger(aTempPos[0]))
				return false;
			if (XMax < Conversions.ToInteger(aTempPos[0]))
				return false;

			if (YMin > Conversions.ToInteger(aTempPos[1]))
				return false;
			if (YMax < Conversions.ToInteger(aTempPos[1]))
				return false;

			if (ZMin > Conversions.ToInteger(aTempPos[2]))
				return false;
			if (ZMax < Conversions.ToInteger(aTempPos[2]))
				return false;

			return true;
		}

		private void OutsiderButton_Click(object sender, EventArgs e)
		{
			string sTemp;

			// 09/06/2007 21:00:52.015,   MakerLog(       Ice_Merchant_Frozen_162)'s ( 108681, -101892,   -3544) [maze_gargoyle_lad] is outsider.

			// territory_begin	[Ice_Merchant_Frozen_162]	{{106332;-102753;-4183;-3383};{107332;-102753;-4183;-3383};{107332;-101753;-4183;-3383};{106332;-101753;-4183;-3383}}	territory_end
			// npcmaker_begin	[Ice_Merchant_Frozen_162]	initial_spawn=all	maximum_npc=6
			// npc_begin	[maze_gargoyle_lad]	pos={106832;-102253;-3683;59290}	total=1	respawn=60sec	Privates=[maze_gargoyle:maze_gargoyle:1:5sec;maze_gargoyle:maze_gargoyle:1:5sec]	npc_end
			// npcmaker_end

			string sTemp2;

			string sLogPath;
			string[] sLogFile;
			string sPosFile;

			int AreaCursor = -1;
			var AreaName = new string[1001];
			var AreaOutsider = new int[1001];
			var AreaOutsiderSpawn = new string[1001];

			int iGrow = Conversions.ToInteger(OutsiderOffsetTextBox.Text);

			FolderBrowserDialog.SelectedPath = Application.StartupPath;
			if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sLogPath = FolderBrowserDialog.SelectedPath;
			sLogFile = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath, "*.log", System.IO.SearchOption.AllDirectories);
			if (sLogFile.Length == 0)
			{
				MessageBox.Show("Log folder empty. Try again and select another folder.", "Empty folder", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			OpenFileDialog.Filter = "Lineage II Server Position file (npcpos.txt)|npcpos*.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sPosFile = OpenFileDialog.FileName;
			int iTemp;
			int iTemp2;
			string[] aTemp;
			string sAreaName;
			string sOutsiderSpawn;

			System.IO.StreamReader inFile;


			// STEP 1: Reading Error log
			ToolStripProgressBar.Maximum = sLogFile.Length - 1;
			var loopTo = sLogFile.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				inFile = new System.IO.StreamReader(sLogFile[iTemp], System.Text.Encoding.Default, true, 1);
				ToolStripProgressBar.Value = iTemp;
				while (inFile.EndOfStream != true)
				{
					sTemp = inFile.ReadLine().Trim();


					// 09/06/2007 21:00:52.015,   MakerLog(       Ice_Merchant_Frozen_162)'s ( 108681, -101892,   -3544) [maze_gargoyle_lad] is outsider.

					if (Strings.InStr(sTemp, "is outsider.") != 0)
					{

						// -- Parsing ---
						sTemp = sTemp.Remove(0, Strings.InStr(sTemp, "MakerLog(") + 8).Replace(" is outsider.", "").Trim();
						// Ice_Merchant_Frozen_162)'s ( 108681, -101892,   -3544) [maze_gargoyle_lad]
						sAreaName = "[" + sTemp.Substring(0, Strings.InStr(sTemp, ")'s") - 1) + "]";
						// Ice_Merchant_Frozen_162

						sTemp2 = sTemp.Remove(0, Strings.InStr(sTemp, ")'s") + 4);
						// ( 108681, -101892,   -3544) [maze_gargoyle_lad]
						sOutsiderSpawn = "(" + sTemp2.Replace(" ", "");
						sTemp2 = sTemp2.Substring(0, Strings.InStr(sTemp2, "[") - 3).Replace(" ", "").Trim();
						// 108681,-101892,-3544

						aTemp = sTemp2.Trim().Split(Conversions.ToChar(","));

						iTemp2 = Array.IndexOf(AreaName, sAreaName);
						if (iTemp2 == -1)
						{

							// Not found in territory listing. Add new
							AreaCursor += 1;
							if (AreaCursor >= AreaName.Length)
							{
								Array.Resize(ref AreaName, AreaName.Length + 1);
								Array.Resize(ref AreaOutsider, AreaOutsider.Length + 1);
								Array.Resize(ref AreaOutsiderSpawn, AreaOutsiderSpawn.Length + 1);
							}
							AreaName[AreaCursor] = sAreaName;
							AreaOutsider[AreaCursor] = Conversions.ToInteger(aTemp[2]);
							AreaOutsiderSpawn[AreaCursor] = sOutsiderSpawn;
						}
						else

							// Found in territory fix listing. Check quote. More or not.
							if (AreaOutsider[iTemp2] < Conversions.ToDouble(aTemp[2]))
							AreaOutsider[iTemp2] = Conversions.ToInteger(aTemp[2]);
					}
				}
				inFile.Close();
			}
			ToolStripProgressBar.Value = 0;

			// STEP 2: Reading and fixing npcpos.txt
			if (System.IO.File.Exists(sPosFile + ".bak") == true)
			{
				if ((int)MessageBox.Show("Overwrite previous backup file?", "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (int)DialogResult.No)
					return;
			}
			System.IO.File.Copy(sPosFile, sPosFile + ".bak", true);

			inFile = new System.IO.StreamReader(sPosFile + ".bak", System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter(sPosFile, false, System.Text.Encoding.Unicode, 1);

			var outLog = new System.IO.StreamWriter(sPosFile + "_npccheck.log", true, System.Text.Encoding.Unicode, 1);
			outLog.WriteLine("Lineage II ScriptMaker: NpcPos Outsider Checker: Start at " + Conversions.ToString(DateAndTime.Now) + Constants.vbNewLine + "in file: " + sPosFile + Constants.vbNewLine);

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			int FixCount = 0;

			string[] aTemp2;

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				// territory_begin	[Ice_Merchant_Frozen_162]	{{106332;-102753;-4183;-3383};{107332;-102753;-4183;-3383};{107332;-101753;-4183;-3383};{106332;-101753;-4183;-3383}}	territory_end
				// npcmaker_begin	[Ice_Merchant_Frozen_162]	initial_spawn=all	maximum_npc=6
				// npc_begin	[maze_gargoyle_lad]	pos={106832;-102253;-3683;59290}	total=1	respawn=60sec	Privates=[maze_gargoyle:maze_gargoyle:1:5sec;maze_gargoyle:maze_gargoyle:1:5sec]	npc_end
				// npcmaker_end

				if (sTemp.StartsWith("territory_begin") == true)
				{
					sAreaName = sTemp.Substring(Strings.InStr(sTemp, "[") - 1, Strings.InStr(sTemp, "]") - Strings.InStr(sTemp, "[") + 1);
					iTemp = Array.IndexOf(AreaName, sAreaName);
					if (iTemp != -1)
					{
						sTemp2 = sTemp.Substring(Strings.InStr(sTemp, "{"), Strings.InStr(sTemp, "territory_end") - 1 - Strings.InStr(sTemp, "{"));
						sTemp2 = sTemp2.Replace("};{", "|").Replace("{", "").Replace("}", "");
						aTemp = sTemp2.Split(Conversions.ToChar("|"));
						aTemp2 = aTemp[0].Split(Conversions.ToChar(";"));

						// Checking valid territory
						if (ValidPositionInTerriotory(aTemp, AreaOutsiderSpawn[iTemp]) == true)
						{
							// {106332;-102753;-4183;-3383}
							// pos={106832;-102253;-3683;xxx}
							// -4183 < -3683 < -3383 - valid

							// VALID position

							AreaOutsider[iTemp] = AreaOutsider[iTemp] + iGrow;
							if (Conversions.ToInteger(aTemp2[3]) < AreaOutsider[iTemp])
							{
								sTemp = sTemp.Replace(";" + aTemp2[3] + "}", ";" + Conversions.ToString(AreaOutsider[iTemp]) + "}");
								outLog.WriteLine(("Outsider Territory " + sAreaName).PadRight(60, Conversions.ToChar(".")) + " Fixed. Z2 up " + aTemp2[3] + " -> " + Conversions.ToString(AreaOutsider[iTemp]) + Constants.vbTab + "| Spawn: " + AreaOutsiderSpawn[iTemp]);
								FixCount += 1;
							}
							else if (Conversions.ToInteger(aTemp2[3]) == AreaOutsider[iTemp])
							{
							}
							else if (Conversions.ToInteger(aTemp2[3]) > AreaOutsider[iTemp])
								outLog.WriteLine(("Outsider Territory " + sAreaName).PadRight(60, Conversions.ToChar(".")) + " Ignored. Required bigger grow value or analysing spawn. Old Z2: " + aTemp2[3] + " New Z2: " + Conversions.ToString(AreaOutsider[iTemp]) + " (with +" + Conversions.ToString(iGrow) + ")" + Constants.vbTab + "| Spawn: " + AreaOutsiderSpawn[iTemp]);
						}
						else
							// InVALID Position
							outLog.WriteLine(("Outsider Territory " + sAreaName).PadRight(60, Conversions.ToChar(".")) + " Ignored. NPC Spawn not in territory. Required remading territory." + Constants.vbTab + "| Spawn: " + AreaOutsiderSpawn[iTemp]);
					}
				}

				outFile.WriteLine(sTemp);
			}

			outLog.WriteLine();

			ToolStripProgressBar.Value = 0;
			outLog.Close();
			outFile.Close();
			inFile.Close();

			MessageBox.Show("Complete. Fixed " + Conversions.ToString(FixCount) + " spawn's.");
		}

		private void QuotButton_Click(object sender, EventArgs e)
		{
			string sTemp;
			string sTemp2;

			string sLogPath;
			string[] sLogFile;
			string sPosFile;

			var AreaName = new string[1];
			var AreaQuot = new int[1];

			FolderBrowserDialog.SelectedPath = Application.StartupPath;
			if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sLogPath = FolderBrowserDialog.SelectedPath;
			sLogFile = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath, "*.log", System.IO.SearchOption.AllDirectories);
			if (sLogFile.Length == 0)
			{
				MessageBox.Show("Log folder empty. Try again and select another folder.", "Empty folder", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			OpenFileDialog.Filter = "Lineage II Server Position file (npcpos.txt)|npcpos*.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sPosFile = OpenFileDialog.FileName;
			int iTemp;
			int iTemp2;
			string[] aTemp;
			string sAreaName;

			System.IO.StreamReader inFile;


			// STEP 1: Reading Error log
			ToolStripProgressBar.Maximum = sLogFile.Length - 1;
			var loopTo = sLogFile.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				inFile = new System.IO.StreamReader(sLogFile[iTemp], System.Text.Encoding.Default, true, 1);
				ToolStripProgressBar.Value = iTemp;
				while (inFile.EndOfStream != true)
				{
					sTemp = inFile.ReadLine().Trim();

					// 07/29/2007 23:39:38.283, [Monastery_Silence_177] failed to increase total npc because of npc quota [3 / 2]
					if (Strings.InStr(sTemp, "because of npc quota") != 0)
					{

						// [Monastery_Silence_177][3 / 2]
						sTemp = sTemp.Remove(0, Strings.InStr(sTemp, "[") - 1).Replace(" failed to increase total npc because of npc quota ", "");
						sAreaName = sTemp.Substring(0, Strings.InStr(sTemp, "]"));

						sTemp2 = sTemp.Replace(sAreaName, "").Replace("[", "").Replace("]", "").Replace(" ", "");
						aTemp = sTemp2.Trim().Split(Conversions.ToChar("/"));

						iTemp2 = Array.IndexOf(AreaName, sAreaName);
						if (iTemp2 == -1)
						{

							// Not found in territory listing. Add new
							Array.Resize(ref AreaName, AreaName.Length + 1);
							AreaName[AreaName.Length - 1] = sAreaName;


							Array.Resize(ref AreaQuot, AreaQuot.Length + 1);
							AreaQuot[AreaQuot.Length - 1] = Conversions.ToInteger(aTemp[0]);
						}
						else

							// Found in territory fix listing. Check quote. More or not.
							if (AreaQuot[iTemp2] < Conversions.ToDouble(aTemp[0]))
							AreaQuot[iTemp2] = Conversions.ToInteger(aTemp[0]);
					}
				}
				inFile.Close();
			}
			ToolStripProgressBar.Value = 0;

			// STEP 2: Reading and fixing npcpos.txt
			if (System.IO.File.Exists(sPosFile + ".bak") == true)
			{
				if ((int)MessageBox.Show("Overwrite previous backup file?", "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (int)DialogResult.No)
					return;
			}
			System.IO.File.Copy(sPosFile, sPosFile + ".bak", true);

			inFile = new System.IO.StreamReader(sPosFile + ".bak", System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter(sPosFile, false, System.Text.Encoding.Unicode, 1);

			var outLog = new System.IO.StreamWriter(sPosFile + "_npccheck.log", true, System.Text.Encoding.Unicode, 1);
			outLog.WriteLine("Lineage II ScriptMaker: NpcPos Quot Checker: Start at " + Conversions.ToString(DateAndTime.Now) + Constants.vbNewLine + "in file: " + sPosFile + Constants.vbNewLine);

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			int FixCount = 0;

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				// npcmaker_begin	[primeval_isle_250]	initial_spawn=all	maximum_npc=4
				// npcmaker_end
				// npcmaker_ex_begin	[aden07_tb2519_26]	name=[aden07_tb26_m1]	ai=[random_spawn]	maximum_npc=4
				// npcmaker_ex_end

				if (sTemp.StartsWith("npcmaker_") == true)
				{
					if (sTemp.StartsWith("npcmaker_end") == false & sTemp.StartsWith("npcmaker_ex_end") == false)
					{
						sTemp2 = sTemp.Substring(Strings.InStr(sTemp, "[") - 1, Strings.InStr(sTemp, "]") - Strings.InStr(sTemp, "[") + 1);
						iTemp = Array.IndexOf(AreaName, sTemp2);
						if (iTemp != -1)
						{
							iTemp2 = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "maximum_npc"));
							if (iTemp2 < AreaQuot[iTemp])
							{
								sTemp = sTemp.Remove(Strings.InStr(sTemp, "maximum_npc") + 10, sTemp.Length - (Strings.InStr(sTemp, "maximum_npc") + 10));
								sTemp = sTemp + "=" + Conversions.ToString(AreaQuot[iTemp]);

								outLog.WriteLine(sTemp2 + " increased to " + Conversions.ToString(AreaQuot[iTemp]));
								FixCount += 1;
							}
						}
					}
				}

				outFile.WriteLine(sTemp);
			}

			outLog.WriteLine();

			ToolStripProgressBar.Value = 0;
			outLog.Close();
			outFile.Close();
			inFile.Close();

			MessageBox.Show("Complete. Fixed " + Conversions.ToString(FixCount) + " spawn's.");
		}


		private void DBNameButton_Click(object sender, EventArgs e)
		{
			string sTemp = "";
			string CheckFile;
			string[] aLine;
			var DbNames = new string[1];
			string DbName;

			OpenFileDialog.Filter = "Lineage II Npcpos script|npcpos.txt";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			CheckFile = OpenFileDialog.FileName;

			var outLog = new System.IO.StreamWriter(CheckFile + "_npccheck.log", true, System.Text.Encoding.Unicode, 1);
			outLog.WriteLine("Lineage II ScriptMaker: NpcPos DBName Checker: Start at " + Conversions.ToString(DateAndTime.Now) + Constants.vbNewLine + "in file: " + CheckFile + Constants.vbNewLine);

			var FilePch = new System.IO.StreamReader(CheckFile);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(FilePch.BaseStream.Length);
			ToolStripProgressBar.Value = 0;
			while (FilePch.EndOfStream != true)
			{
				sTemp = FilePch.ReadLine();

				// npc_ex_begin	[heart_of_volcano]	pos={189872;-105152;-724;49000}	total=1	respawn=1min
				// dbname=[heart_of_volcano]	ai_parameters={[TelPosX]=[204187];[TelPosY]=[-111864];[TelPosZ]=[34]}	npc_ex_end
				if (Strings.InStr(sTemp, "dbname") != 0)
				{
					sTemp = sTemp.Replace(" ", " ").Replace(" ", Conversions.ToString((char)9));
					aLine = sTemp.Split((char)9);
					DbName = Libraries.GetNeedParamFromStr(sTemp, "dbname");

					// Check duplicate in DB list
					if (Array.IndexOf(DbNames, DbName) != -1)
					{
						outLog.WriteLine(Constants.vbNewLine + sTemp);
						outLog.WriteLine("Found dublicate of DB Name for dbname: " + Constants.vbNewLine + "Npc: " + aLine[1] + Constants.vbTab + "dbname=" + DbName);
					}

					// Add to dbnames list
					DbNames[DbNames.Length - 1] = DbName;
					Array.Resize(ref DbNames, DbNames.Length + 1);

					// Check name npc and dbname
					if ((aLine[1] ?? "") != (DbName ?? ""))
					{
						outLog.WriteLine(Constants.vbNewLine + sTemp);
						outLog.WriteLine("DBName different with NpcName. Perhaps error?" + Constants.vbNewLine + "Npc: " + aLine[1] + Constants.vbTab + "dbname=" + DbName);
					}
				}

				ToolStripProgressBar.Value = Conversions.ToInteger(FilePch.BaseStream.Position);
			}

			MessageBox.Show("Checking complete. See log about found errors.");
			ToolStripProgressBar.Value = 0;

			FilePch.Close();
			outLog.WriteLine(Constants.vbNewLine + "NpcPos DBName Checker: Finished at " + Conversions.ToString(DateAndTime.Now) + Constants.vbNewLine);
			outLog.Close();
		}

		private void AiPrivatesButton_Click(object sender, EventArgs e)
		{
			string TempStr = "";

			var TempStr2 = new string[40]; // 4 on each private
			string CheckFile;
			int iTemp;
			string LastClass = "";

			OpenFileDialog.Filter = "Lineage II AI.obj config|ai.obj|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			CheckFile = OpenFileDialog.FileName;

			if (PchLoader() == -1)
				return;

			var outLog = new System.IO.StreamWriter(CheckFile + "_npccheck.log", true, System.Text.Encoding.Unicode, 1);
			outLog.WriteLine("Lineage II ScriptMaker: AI.obj Privates Checker: Start at " + Conversions.ToString(DateAndTime.Now) + Constants.vbNewLine + "in file: " + CheckFile + Constants.vbNewLine);

			var FilePch = new System.IO.StreamReader(CheckFile);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(FilePch.BaseStream.Length);
			ToolStripProgressBar.Value = 0;
			int iTemp1;
			int iTemp2;
			while (FilePch.EndOfStream != true)
			{
				TempStr = FilePch.ReadLine();
				if (TempStr.StartsWith("class ") == true)
					LastClass = TempStr;
				// Privates=[talakin_archer:talakin_archer:1:0sec;talakin_raider:talakin_raider:1:0sec]
				// string Privates "orc:party_private:1:20sec"
				iTemp1 = Strings.InStr(TempStr, "string Privates \"");
				if (iTemp1 > 0)
				{
					iTemp2 = Strings.InStr(iTemp1, TempStr, "\"");
					TempStr2 = Strings.Mid(TempStr, iTemp2 + 1, TempStr.Length - iTemp2 - 1).Replace(";", ":").Split(Conversions.ToChar(":"));

					if (TempStr2.Length > 1)
					{
						var loopTo = TempStr2.Length - 1;
						for (iTemp = 0; iTemp <= loopTo; iTemp += 4)
						{
							if (Array.IndexOf(NpcPch, TempStr2[iTemp]) == -1)
							{
								// not found
								outLog.WriteLine("Error in :" + Constants.vbNewLine + LastClass);
								outLog.WriteLine("Not found privates '" + TempStr2[iTemp] + "' in " + Constants.vbNewLine + TempStr);
							}
						}
					}

					Array.Clear(TempStr2, 0, TempStr2.Length);
				}
				ToolStripProgressBar.Value = Conversions.ToInteger(FilePch.BaseStream.Position);
			}

			MessageBox.Show("Checking complete. See log about found errors.");
			ToolStripProgressBar.Value = 0;

			FilePch.Close();
			outLog.WriteLine(Constants.vbNewLine + "AI.obj Privates Checker: Finished at " + Conversions.ToString(DateAndTime.Now) + Constants.vbNewLine);
			outLog.Close();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			string TempStr = "";

			var TempStr2 = new string[40]; // 4 on each private
			string WorkStr = "";
			string CheckFile;
			int iTemp;

			OpenFileDialog.Filter = "Lineage II Npcpos script|npcpos.txt";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			CheckFile = OpenFileDialog.FileName;

			if (PchLoader() == -1)
				return;

			var outLog = new System.IO.StreamWriter(CheckFile + "_npccheck.log", true, System.Text.Encoding.Unicode, 1);
			outLog.WriteLine("Lineage II ScriptMaker: Npcpos Privates Checker: Start at " + Conversions.ToString(DateAndTime.Now) + Constants.vbNewLine + "in file: " + CheckFile + Constants.vbNewLine);

			var FilePch = new System.IO.StreamReader(CheckFile);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(FilePch.BaseStream.Length);
			ToolStripProgressBar.Value = 0;
			int iTemp1;
			int iTemp2;
			while (FilePch.EndOfStream != true)
			{
				TempStr = FilePch.ReadLine();
				// Privates=[talakin_archer:talakin_archer:1:0sec;talakin_raider:talakin_raider:1:0sec]
				// string Privates "orc:party_private:1:20sec"
				iTemp1 = Strings.InStr(TempStr, "Privates=");
				if (iTemp1 > 0)
				{
					iTemp2 = Strings.InStr(iTemp1, TempStr, "]");
					TempStr = Strings.Mid(TempStr, iTemp1, iTemp2 - iTemp1 + 1);
					WorkStr = TempStr.Replace("Privates=[", "").Replace("]", "").Replace(";", ":");
					TempStr2 = WorkStr.Split(Conversions.ToChar(":"));
					var loopTo = TempStr2.Length - 1;
					for (iTemp = 0; iTemp <= loopTo; iTemp += 4)
					{
						if (Array.IndexOf(NpcPch, TempStr2[iTemp]) == -1)
							// not found
							outLog.WriteLine("Not found privates '" + TempStr2[iTemp] + "' in " + Constants.vbNewLine + TempStr);
					}
					Array.Clear(TempStr2, 0, TempStr2.Length);
				}
				ToolStripProgressBar.Value = Conversions.ToInteger(FilePch.BaseStream.Position);
			}

			MessageBox.Show("Checking complete. See log about found errors.");
			ToolStripProgressBar.Value = 0;

			FilePch.Close();
			outLog.WriteLine(Constants.vbNewLine + "Npcpos Privates Checker: Finished at " + Conversions.ToString(DateAndTime.Now) + Constants.vbNewLine);
			outLog.Close();
		}

		private void MakerNameButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog.Filter = "Lineage II Npcpos script|npcpos.txt";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			var outLog = new System.IO.StreamWriter(OpenFileDialog.FileName + "_npccheck.log", true, System.Text.Encoding.Unicode, 1);
			outLog.WriteLine("Lineage II ScriptMaker: Npcpos MakerName Checker: Start at " + Conversions.ToString(DateAndTime.Now));


			var NpcPosFile = new System.IO.StreamReader(OpenFileDialog.FileName);
			string sTemp;
			string sName;
			string sAiParam;

			ToolStripProgressBar.Maximum = Conversions.ToInteger(NpcPosFile.BaseStream.Length);
			ToolStripProgressBar.Value = 0;

			while (NpcPosFile.EndOfStream != true)
			{

				// npcmaker_ex_begin	[oren07_npc1819_gd02]	name=[oren_npc1819_gd0201]	ai=[default_maker]	maximum_npc=2
				// npcmaker_ex_begin	[giran08_2124_008]	name=[t21_24_00804]	ai=[maker_instant_spawn_random]	ai_parameters={[maker_name1]=[t21_24_00803];[maker_name2]=[t21_24_00804];[maker_cnt]=2;[respawn_time]=132;[on_start_spawn]=0}	maximum_npc=1

				sTemp = NpcPosFile.ReadLine();

				sName = Libraries.GetNeedParamFromStr(sTemp, "name");
				if (!string.IsNullOrEmpty(sName))
				{
					sAiParam = Libraries.GetNeedParamFromStr(sTemp, "ai_parameters");
					if (!string.IsNullOrEmpty(sAiParam) & Strings.InStr(sAiParam, "[maker_cnt]") != 0)
					{
						if (Strings.InStr(sAiParam, sName) == 0)
							outLog.WriteLine(Constants.vbNewLine + "Not found definition for maker in line" + Constants.vbNewLine + sTemp + Constants.vbNewLine + "for maker_name=" + sName);
					}
				}

				ToolStripProgressBar.Value = Conversions.ToInteger(NpcPosFile.BaseStream.Position);
			}

			MessageBox.Show("Checking complete. See log about found errors.");
			ToolStripProgressBar.Value = 0;

			NpcPosFile.Close();
			outLog.WriteLine(Constants.vbNewLine + "Npcpos MakerName Checker: Finished at " + Conversions.ToString(DateAndTime.Now) + Constants.vbNewLine);
			outLog.Close();
		}

		private short PchLoader()
		{
			string TempStr = "";
			var TempStr2 = new string[3];

			if (System.IO.File.Exists("npc_pch.txt") == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Filter = "Lineage II Server Npc_pch config file|npc_pch.txt";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return -1;
			}
			else
				OpenFileDialog.FileName = "npc_pch.txt";

			Array.Clear(NpcPch, 0, NpcPch.Length);

			// Loading all items
			ToolStripProgressBar.Value = 0;
			var FilePch = new System.IO.StreamReader(OpenFileDialog.FileName);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(FilePch.BaseStream.Length);
			while (FilePch.EndOfStream != true)
			{
				TempStr = Strings.Trim(FilePch.ReadLine());
				TempStr = Strings.Replace(TempStr, " ", "");
				TempStr = Strings.Replace(TempStr, Conversions.ToString((char)9), "");
				TempStr2 = TempStr.Split((char)61); // =

				if (NpcPch.Length < Conversions.ToInteger(TempStr2[1]) - 1000000)
					Array.Resize(ref NpcPch, Conversions.ToInteger(TempStr2[1]) - 1000000 + 1);
				NpcPch[Conversions.ToInteger(TempStr2[1]) - 1000000] = TempStr2[0].Replace("[", "").Replace("]", "");

				ToolStripProgressBar.Value = Conversions.ToInteger(FilePch.BaseStream.Position);
				this.Update();
			}
			this.Update();

			Array.Clear(TempStr2, 0, TempStr2.Length);

			FilePch.Close();

			// MessageBox.Show("All source id's loaded.")
			ToolStripProgressBar.Value = 0;
			return default(short);
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
