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

namespace L2ScriptMaker.Modules.AI
{
	public partial class AiParamsNpcdataChecker : Form
	{
		public AiParamsNpcdataChecker()
		{
			InitializeComponent();
		}

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			string sTemp;

			string CheckFolder;
			FolderBrowserDialog.SelectedPath = Environment.CurrentDirectory;
			FolderBrowserDialog.Description = "Select folder with Ai.obj and Npcdata.txt";
			// FolderBrowserDialog.Filter = "Lineage II Intelligence file|ai.obj|All files|*.*"
			if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
				return;
			CheckFolder = FolderBrowserDialog.SelectedPath;

			if (System.IO.File.Exists(CheckFolder + @"\ai.obj") == false | System.IO.File.Exists(CheckFolder + @"\npcdata.txt") == false)
			{
				MessageBox.Show("Not found Ai.obj or npcdata in this folder. Put and try again", "Files not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var inAiFile = new System.IO.StreamReader(CheckFolder + @"\ai.obj", System.Text.Encoding.Default, true, 1);
			var outLogFile = new System.IO.StreamWriter(CheckFolder + @"\ai.obj_scriptCheck.log", true, System.Text.Encoding.Unicode, 1);

			outLogFile.WriteLine("L2ScriptMaker. Ai params in Npcdata Checker.");
			outLogFile.WriteLine(Conversions.ToString(DateAndTime.Now) + " Start" + Constants.vbNewLine);
			var aClass = new string[10001];
			var aParentClass = new string[10001];

			// class 1 default_npc : (null)
			// parameter_define_begin
			// int MoveAroundSocial2 0
			// float MoveAround_DecayRatio 0.000000
			// string fnFeudInfo "defaultfeudinfo.htm"
			// parameter_define_end

			// -------- Loading and checking AI.obj ---------
			var aParams = new string[10001];
			int ClassMark = -1;
			string sName;
			var aName = new string[5];

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inAiFile.BaseStream.Length);
			ToolStripProgressBar.Value = 0;
			CurActionLabel.Text = "Loading Ai.obj"; CurActionLabel.Update();
			while (inAiFile.EndOfStream != true)
			{
				sTemp = inAiFile.ReadLine();

				// --- Compiling class name
				if (sTemp.StartsWith("class ") == true)
				{
					// ERR check exist or not : in class line
					if (Strings.InStr(sTemp, ":") == 0)
						WriteErrToLog(outLogFile, sTemp + Constants.vbNewLine + "Not found \":\" in class definition");

					sName = FixSymbols(sTemp.Replace(":", "")).Trim();
					// class(0) 1(1) default_npc(2) : (null)(3)
					aName = sName.Split((char)32);

					CurActionLabel.Text = "Loading " + aName[2] + " class"; CurActionLabel.Update();
					ClassMark += 1;
					aClass[ClassMark] = aName[2];
					aParentClass[ClassMark] = aName[3];

					// ERR check exist or not : in class line
					if ((aName[3] ?? "") != "(null)")
					{
						if (Array.IndexOf(aClass, aName[3]) == -1)
							WriteErrToLog(outLogFile, aName[2] + " have not parent class " + aName[3]);
					}
				}
				// ___ Compiling class name

				// class 1 default_npc : (null)
				// parameter_define_begin
				// int MoveAroundSocial2 0
				// float MoveAround_DecayRatio 0.000000
				// string fnFeudInfo "defaultfeudinfo.htm"
				// parameter_define_end

				// --- Compiling parameter_define
				if (sTemp.StartsWith("parameter_define_begin") == true)
				{
					CurActionLabel.Text = "Loading parameters from " + aName[2] + " class"; CurActionLabel.Update();
					sTemp = inAiFile.ReadLine();
					while (sTemp.StartsWith("parameter_define_end") == false)
					{
						sTemp = FixSymbols(sTemp).Trim();
						// string(0) fnFeudInfo(1) "defaultfeudinfo.htm"(2)
						try
						{
							aName = sTemp.Split((char)32);
							if (aParams[ClassMark] != null)
								aParams[ClassMark] += ",";
							aParams[ClassMark] += aName[1];
						}
						catch (Exception ex)
						{
						}

						sTemp = inAiFile.ReadLine();
					}
				}
				// ____ Compiling parameter_define

				ToolStripProgressBar.Value = Conversions.ToInteger(inAiFile.BaseStream.Position);
				this.Update();
			}
			ToolStripProgressBar.Value = 0;
			CurActionLabel.Text = "Loading AI.obj complete"; CurActionLabel.Update();
			inAiFile.Close();
			outLogFile.WriteLine(Constants.vbNewLine + Conversions.ToString(DateAndTime.Now) + " End of Ai.obj loading and checking of " + Conversions.ToString(ClassMark) + " class's.");
			outLogFile.Flush();
			this.Refresh();

			// _______ Loading and checking AI.obj ____________

			string sNpcAi;            // ai class name for this npc
			string sNpcAiParam = "";  // full npc_ai line
			var aNpcAiParam = new string[21];   // all npc_ai params 
			int iTemp1;
			var bFoundStatus = default(bool);
			string sNpcAiParam2;      // temp string for work finding parameter in classes
			var aNpcParam = new string[51];     // list AI parameters

			var inNpcDataFile = new System.IO.StreamReader(CheckFolder + @"\npcdata.txt", System.Text.Encoding.Default, true, 1);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inNpcDataFile.BaseStream.Length);
			ToolStripProgressBar.Value = 0;
			CurActionLabel.Text = "Loading NpcData.txt"; CurActionLabel.Update();
			while (inNpcDataFile.EndOfStream != true)
			{
				sTemp = inNpcDataFile.ReadLine();

				if (sTemp.StartsWith("npc_begin") == true)
				{
					sName = Strings.Mid(sTemp, 1, Strings.InStr(sTemp, "level=") - 1);
					sName = FixSymbols(sName).Trim();
					aName = sName.Split((char)32);

					CurActionLabel.Text = "Compiling " + aName[3] + " npc"; CurActionLabel.Update();
					sNpcAiParam = Libraries.GetNeedParamFromStr(sTemp, "npc_ai");

					// npc_begin(0)	warrior(1)	56(2)	[dre_vanul_disposer](3)	level=22(4)	acquire_exp_rate=1.586508	acquire_sp=36	unsowing=0	clan={@demonic_clan}	ignore_clan_list={}	clan_help_range=300	slot_chest=[]	slot_rhand=[]	slot_lhand=[]	shield_defense_rate=0	shield_defense=0	skill_list={@s_race_demonic;@s_evil_attack;@s_npc_resist_unholy3}	
					// 1) Simple AI
					if ((sNpcAiParam ?? "") == "{}")
						// empty ai class definition
						WriteErrToLog(outLogFile, sName + " have empty ai.");
					else
					{
						// 2) Enchant AI
						// npc_ai={[dre_vanul_disposer];{[MoveAroundSocial]=0};{[MoveAroundSocial1]=0};{[MoveAroundSocial2]=0};{[DDMagic1]=@s_mega_storm_strike2};{[DDMagic2]=@s_blood_sucking2};{[DeBuff]=@s_npc_chill_flame2}}	
						// npc_ai={[varikan_brigand_ldr];{[MoveAroundSocial]=42};{[MoveAroundSocial1]=42};{[MoveAroundSocial2]=42};{[Privates]=[varikan_brigand:varikan_brigand:1:0;varikan_brigand:varikan_brigand:1:0;varikan_brigand:varikan_brigand:1:0;varikan_brigand:varikan_brigand:1:0]};{[ShoutMsg1]=[1000154]};{[ShoutMsg2]=[1000155]};{[ShoutMsg3]=[1000156]};{[ShoutMsg4]=[1000157]}}

						sNpcAi = Strings.Mid(sNpcAiParam, 3, Strings.InStr(sNpcAiParam, "]") - 3);
						// ERR check exist or not : in class line
						if (Array.IndexOf(aClass, sNpcAi) == -1)
							WriteErrToLog(outLogFile, sName + " have not ai class in Ai.obj");
						else

							// Dim aClass(10000) As String, aParentClass(10000) As String, aParams(10000) As String
							// Dim sNpcAi As String            ' ai class name for this npc
							// Dim sNpcAiParam As String = ""  ' full npc_ai line
							// Dim aNpcAiParam(20) As String   ' all npc_ai params 
							// Dim iTemp1 As Integer, iTemp2 As Integer, bFoundStatus As Boolean
							// Dim sNpcAiParam2 As String      ' temp string for work finding parameter in classes
							// Dim aNpcParam(50) As String     'list AI parameters

							// --------- BIG MAIN HARD COMPILING -----------
							if (Strings.InStr(sNpcAiParam, ";") != 0)
						{
							sNpcAiParam = sNpcAiParam.Replace("[" + sNpcAi + "];", ""); // remove npc ai class
							sNpcAiParam = sNpcAiParam.Replace("{{", "").Replace("}}", ""); // remove npc ai class
							sNpcAiParam = sNpcAiParam.Replace("};{", "|");               // make split char one symbol
							Array.Clear(aNpcAiParam, 0, aNpcAiParam.Length);
							aNpcAiParam = sNpcAiParam.Split(Conversions.ToChar("|"));                 // [MoveAroundSocial]=42
							var loopTo = aNpcAiParam.Length - 1;
							for (iTemp1 = 0; iTemp1 <= loopTo; iTemp1++)
							{
								sNpcAiParam2 = Strings.Mid(aNpcAiParam[iTemp1], 2, Strings.InStr(aNpcAiParam[iTemp1], "]") - 2);
								ClassMark = Array.IndexOf(aClass, sNpcAi);

								while (bFoundStatus == false)
								{
									if (ClassMark == -1)
										break;
									Array.Clear(aNpcParam, 0, aNpcParam.Length);
									if (aParams[ClassMark] != null)
									{
										Array.Clear(aNpcParam, 0, aNpcParam.Length);
										aNpcParam = aParams[ClassMark].Split(Conversions.ToChar(","));
										if (Array.IndexOf(aNpcParam, sNpcAiParam2) != -1)
										{
											bFoundStatus = true;
											break;
										}
									}
									ClassMark = Array.IndexOf(aClass, aParentClass[ClassMark]);
								}

								if (bFoundStatus == false)
									WriteErrToLog(outLogFile, sName + Constants.vbTab + Constants.vbTab + "npc_ai=[" + sNpcAi + "] not found parameter " + sNpcAiParam2);
								else
									bFoundStatus = false;
							}
						}
					}
				}
				ToolStripProgressBar.Value = Conversions.ToInteger(inNpcDataFile.BaseStream.Position);
				this.Update();
			}
			outLogFile.WriteLine(Constants.vbNewLine + Conversions.ToString(DateAndTime.Now) + " End of NpcData.txt loading and checking");
			outLogFile.WriteLine(Constants.vbNewLine + Conversions.ToString(DateAndTime.Now) + " End" + Constants.vbNewLine);
			ToolStripProgressBar.Value = 0;
			CurActionLabel.Text = "Work complete.";

			inNpcDataFile.Close();
			outLogFile.Close();
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private bool WriteErrToLog(System.IO.StreamWriter LogName, string ErrMsg)
		{

			// LogName.WriteLine(vbNewLine & "ERR: " & ErrMsg)
			LogName.WriteLine("ERR: " + ErrMsg);
			return default(bool);
		}

		private string FixSymbols(string Msg)
		{
			Msg = Msg.Replace(Conversions.ToString((char)9), " ");
			while (Strings.InStr(Msg, "  ") != 0)
				Msg = Msg.Replace("  ", " ");

			return Msg;
		}
	}
}
