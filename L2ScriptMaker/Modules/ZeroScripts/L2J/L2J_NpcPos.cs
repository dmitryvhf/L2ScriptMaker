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

namespace L2ScriptMaker.Modules.ZeroScripts.L2J
{
	public partial class L2J_NpcPos : Form
	{
		public L2J_NpcPos()
		{
			InitializeComponent();
		}

		private struct NpcSpawn
		{

			// `id` int(11) NOT NULL auto_increment,
			// `location` varchar(40) NOT NULL default '',
			// `count` int(9) NOT NULL default '0',
			// `npc_templateid` int(9) NOT NULL default '0',
			// `locx` int(9) NOT NULL default '0',
			// `locy` int(9) NOT NULL default '0',
			// `locz` int(9) NOT NULL default '0',
			// `randomx` int(9) NOT NULL default '0',
			// `randomy` int(9) NOT NULL default '0',
			// `heading` int(9) NOT NULL default '0',
			// `respawn_delay` int(9) NOT NULL default '0',
			// `loc_id` int(9) NOT NULL default '0',
			// `periodOfDay` decimal(2,0) default '0',

			public int npc_templateid;
			public int locx;
			public int locy;
			public int locz;
			public int heading;
			public int respawn_delay;
			public bool periodOfDay;
		}


		private void ButtonPTStoL2J_Click(object sender, EventArgs e)
		{
			string sTemp;
			string[] aTemp;
			int iCount = 0;
			int iCountLimit = 100;

			if (!string.IsNullOrEmpty(TextBoxL2JMaxLines.Text))
			{
				try
				{
					iCountLimit = Conversions.ToInteger(Conversions.ToUInteger(TextBoxL2JMaxLines.Text));
				}
				catch (Exception ex)
				{
					MessageBox.Show("Wrong MaxLines count number");
					return;
				}
			}

			System.IO.StreamReader inSpawnFile;

			// LOADING npc_pch.txt
			if (System.IO.File.Exists("npc_pch.txt") == false)
			{
				MessageBox.Show("npc_pch.txt not found", "Need npc_pch.txt", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var aNpcPch = new string[40001];
			inSpawnFile = new System.IO.StreamReader("npc_pch.txt", System.Text.Encoding.Default, true, 1);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inSpawnFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading npc_pch.txt ...";

			while (inSpawnFile.EndOfStream != true)
			{
				sTemp = inSpawnFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inSpawnFile.BaseStream.Position);
				if (string.IsNullOrEmpty(sTemp) | sTemp.StartsWith("//") == true | sTemp.StartsWith("[") == false)
					continue;

				// [pet_wolf_a] = 1012077
				sTemp = sTemp.Replace(" ", "").Replace(Conversions.ToString((char)9), "");
				aTemp = sTemp.Split(Conversions.ToChar("="));
				try
				{
					aNpcPch[Conversions.ToInteger(aTemp[1]) - 1000000] = aTemp[0];
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error in loading npc_pch.txt. Last reading line:" + Constants.vbNewLine + sTemp);
					inSpawnFile.Close();
					return;
				}
			}
			inSpawnFile.Close();
			ToolStripProgressBar.Value = 0;

			OpenFileDialog.Filter = "PTS spawn (npcpos.txt)|npcpos.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			inSpawnFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter("spawnlist_new.sql", false, System.Text.Encoding.Unicode, 1);

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inSpawnFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading npcpos.txt...";
			var sLastZoneName = default(string);
			int iTemp;
			string sTempSpawn = "";
			string sTempNpc;
			char bIsNight = Conversions.ToChar("0");
			bool bEventNpc = false;
			string sLastNpcName;

			while (inSpawnFile.EndOfStream != true)
			{
				sTemp = inSpawnFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inSpawnFile.BaseStream.Position);
				if (string.IsNullOrEmpty(sTemp) | sTemp.StartsWith("//") == true)
					continue;

				// npcmaker_ex_begin	[oren22_2219_a01]	name=[oren22_2219_a01m1]	ai=[default_maker]	maximum_npc=50	
				// npcmaker_ex_begin	[rune09_npc2116_05]	name=[rune09_npc2116_0502]	ai=[on_day_night_spawn]	ai_parameters={[IsNight]=1}	maximum_npc=1	
				// npcmaker_ex_begin	[schuttgart03_npc2312_tb02]	name=[schuttgart03_npc2312_tb02m1]	ai=[event_maker]	ai_parameters={[EventName]=[event_treasure_box]}	maximum_npc=9	
				if (sTemp.StartsWith("npcmaker_begin") == true | sTemp.StartsWith("npcmaker_ex_begin") == true)
				{
					aTemp = sTemp.Split((char)9);
					sLastZoneName = aTemp[1].Replace("[", "").Replace("]", "");
					if (sTemp.IndexOf("[IsNight]=1") > 0)
						bIsNight = Conversions.ToChar("1");
					else
						bIsNight = Conversions.ToChar("0");
					if ((Libraries.GetNeedParamFromStr(sTemp, "ai") ?? "") == "[event_maker]" & sTemp.IndexOf("[EventName]=") > 0)
						bEventNpc = true;
					else
						bEventNpc = false;
					continue;
				}

				// npc_ex_begin	[xel_trainer_mage]	pos={88347;56413;-3495;49152}	total=1	respawn=90sec	ai_parameters={[trainer_id]=1;[direction]=49152}	is_chase_pc=1000	npc_ex_end	
				if (sTemp.StartsWith("npc_begin") == true | sTemp.StartsWith("npc_ex_begin") == true)
				{
					sTempSpawn = "";
					aTemp = sTemp.Split((char)9);
					sTempNpc = aTemp[1].Replace("[", "").Replace("]", "");
					sLastNpcName = aTemp[1];

					// 1 - area name
					sTempSpawn += "('" + sLastZoneName + "',";

					// 2 - total
					sTempNpc = Libraries.GetNeedParamFromStr(sTemp, "total");
					if (string.IsNullOrEmpty(Libraries.GetNeedParamFromStr(sTemp, "total")))
					{
						if (CheckBoxShowAll.Checked == true)
							outFile.WriteLine("-- npc name " + sLastNpcName + " not found count");
						continue;
					}
					sTempSpawn += Libraries.GetNeedParamFromStr(sTemp, "total") + ",";

					// 3 - npcname
					iTemp = Array.IndexOf(aNpcPch, aTemp[1]);
					if (iTemp == -1)
					{
						if (CheckBoxShowAll.Checked == true)
							outFile.WriteLine("-- npc name " + sLastNpcName + " not found in npc_pch");
						continue;
					}
					sTempSpawn += Conversions.ToString(iTemp) + ",";

					// 4,5,6,7,8,9 - x,y,z,0,0,heading
					sTempNpc = Libraries.GetNeedParamFromStr(sTemp, "pos").Replace("{", "").Replace("}", "");
					if ((sTempNpc ?? "") == "anywhere")
					{
						// pos=anywhere
						if (CheckBoxShowAll.Checked == true)
							outFile.WriteLine("-- npc name " + sLastNpcName + " use anywhere spawn. No supported.");
						continue;
					}
					aTemp = sTempNpc.Split(Conversions.ToChar(";"));
					sTempSpawn += aTemp[0] + ",";
					sTempSpawn += aTemp[1] + ",";
					sTempSpawn += aTemp[2] + ",";
					sTempSpawn += "0,0,";
					sTempSpawn += aTemp[3] + ",";

					// 10 - respawn time
					sTempNpc = Libraries.GetNeedParamFromStr(sTemp, "respawn");

					if ((sTempNpc ?? "") == "no")
					{
						// respawn=no
						if (CheckBoxShowAll.Checked == true)
							outFile.WriteLine("-- npc name " + sLastNpcName + " respawn=no");
						continue;
					}

					if (sTempNpc.IndexOf("sec") > 0)
						sTempNpc = sTempNpc.Replace("sec", "");
					else if (sTempNpc.IndexOf("min") > 0)
					{
						sTempNpc = sTempNpc.Replace("min", "");
						sTempNpc = (Conversions.ToInteger(sTempNpc) * 60).ToString();
					}
					else if (sTempNpc.IndexOf("hour") > 0)
					{
						sTempNpc = sTempNpc.Replace("hour", "");
						sTempNpc = (Conversions.ToInteger(sTempNpc) * 60 * 60).ToString();
					}
					sTempSpawn += sTempNpc + ",";

					// 10 - loc_id,periodOfDay
					sTempSpawn += "0,";
					// periodOfDay
					sTempSpawn += Conversions.ToString(bIsNight);
					sTempSpawn += ")";

					if (bEventNpc == true & (CheckBoxSaveEventNpc.Checked == false & CheckBoxShowAll.Checked == true))
					{
						outFile.WriteLine("-- " + sTempSpawn + Constants.vbTab + "-- Event npc: " + sLastNpcName);
						continue;
					}

					if (iCount == 0)
						sTempSpawn = "INSERT INTO `spawnlist` VALUES" + Constants.vbNewLine + sTempSpawn;
					iCount += 1;
					if (iCount >= iCountLimit)
					{
						sTempSpawn += ";";
						iCount = 0;
					}
					else
						sTempSpawn += ",";

					if (CheckBoxShowNpcName.Checked == true)
						sTempSpawn += Constants.vbTab + "-- " + sLastNpcName;

					outFile.WriteLine(sTempSpawn);
				}
			}
			ToolStripProgressBar.Value = 0;
			inSpawnFile.Close();
			outFile.Close();

			MessageBox.Show("Completed.");
		}

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			string sSpawnListFile;
			string sTemp;
			string[] aTemp;

			System.IO.StreamReader inSpawnFile;

			// LOADING npc_pch.txt
			if (System.IO.File.Exists("npc_pch.txt") == false)
			{
				MessageBox.Show("npc_pch.txt not found", "Need npc_pch.txt", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var aNpcPch = new string[40001];
			inSpawnFile = new System.IO.StreamReader("npc_pch.txt", System.Text.Encoding.Default, true, 1);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inSpawnFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading npc_pch.txt ...";

			while (inSpawnFile.EndOfStream != true)
			{
				sTemp = inSpawnFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inSpawnFile.BaseStream.Position);
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{

					// [pet_wolf_a] = 1012077
					sTemp = sTemp.Replace(" ", "").Replace(Conversions.ToString((char)9), "");
					aTemp = sTemp.Split(Conversions.ToChar("="));
					try
					{
						aNpcPch[Conversions.ToInteger(aTemp[1]) - 1000000] = aTemp[0];
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error in loading npc_pch.txt. Last reading line:" + Constants.vbNewLine + sTemp);
						inSpawnFile.Close();
						return;
					}
				}
			}
			inSpawnFile.Close();
			ToolStripProgressBar.Value = 0;

			OpenFileDialog.Filter = "L2J Spawn (spawnlist.sql)|spawnlist.sql|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sSpawnListFile = OpenFileDialog.FileName;
			inSpawnFile = new System.IO.StreamReader(sSpawnListFile, System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter("npcpos_l2j.txt", false, System.Text.Encoding.Unicode, 1);

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inSpawnFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading spawnlist.sql...";
			string sCurZoneName = "";

			// Dim aZone() As String = {}
			string sPrevZoneName = null;
			string sTempTerritory;
			string sTempNpcName;
			int iNpcCount = 0;

			var aNpcSpawn = new NpcSpawn[1];
			var aNpcMiss = new int[1];
			var iXMin = default(int);
			// Dim iTemp As Integer

			var iXMax = default(int);
			var iYMin = default(int);
			var iYMax = default(int);
			var iZMin = default(int);
			var iZMax = default(int);


			while (inSpawnFile.EndOfStream != true)
			{
				sTemp = inSpawnFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inSpawnFile.BaseStream.Position);
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("(") == true)
				{

					// ---------- Prepare for importing
					// `id` int(11) NOT NULL auto_increment,
					// `location` varchar(40) NOT NULL default '',
					// `count` int(9) NOT NULL default '0',
					// `npc_templateid` int(9) NOT NULL default '0',
					// `locx` int(9) NOT NULL default '0',
					// `locy` int(9) NOT NULL default '0',
					// `locz` int(9) NOT NULL default '0',
					// `randomx` int(9) NOT NULL default '0',
					// `randomy` int(9) NOT NULL default '0',
					// `heading` int(9) NOT NULL default '0',
					// `respawn_delay` int(9) NOT NULL default '0',
					// `loc_id` int(9) NOT NULL default '0',
					// `periodOfDay` decimal(2,0) default '0',
					// (1,'partisan_agit_2121_01',1,35372,44368,107440,-2032,0,0,0,60,0,0),
					// (2,'partisan_agit_2121_01',1,35372,44768,108604,-2034,0,0,44231,60,0,0),

					sTemp = sTemp.Substring(Strings.InStr(sTemp, "("), Strings.InStr(sTemp, ")") - Strings.InStr(sTemp, "(") - 1);
					sTemp = sTemp.Replace("'", "");
					aTemp = sTemp.Split(Conversions.ToChar(","));

					// 0   1                      2 3     4     5       6      7 8   9 10 11 12
					// (1,'partisan_agit_2121_01',1,35372,44368,107440,-2032,  0,0,  0,60,0,0),
					sCurZoneName = aTemp[1];

					if (sPrevZoneName == null)
						sPrevZoneName = sCurZoneName;
					if ((sCurZoneName ?? "") != (sPrevZoneName ?? ""))
					{
						// Write new zone with 

						// territory_begin	[FantasyIsle_0]	{{-59734;-57397;-2532;-1732};{-58734;-57397;-2532;-1732};{-58734;-56397;-2532;-1732};{-59734;-56397;-2532;-1732}}	territory_end
						// npcmaker_begin	[FantasyIsle_0]	initial_spawn=all	maximum_npc=1

						// npcmaker_ex_begin	[rune09_npc2116_05]	name=[rune09_npc2116_0502]	ai=[on_day_night_spawn]	ai_parameters={[IsNight]=1}	maximum_npc=1
						// npc_ex_begin	[maid_of_ridia]	pos={47108;-36189;-1624;-22192}	total=1	respawn=1min	npc_ex_end
						// npcmaker_ex_end

						sPrevZoneName = sPrevZoneName.Replace(" ", "_").ToLower();

						// Generate TERRITORY AREA

						iXMin = iXMin - 200;
						iXMax = iXMax + 200;
						iYMin = iYMin - 200;
						iYMax = iYMax + 200;
						iZMin = iZMin - 100;
						iZMax = iZMax + 100 + 700;

						sTempTerritory = "";
						sTempTerritory = sTempTerritory + "{" + Conversions.ToString(iXMin) + ";" + Conversions.ToString(iYMin) + ";" + Conversions.ToString(iZMin) + ";" + Conversions.ToString(iZMax) + "};";
						sTempTerritory = sTempTerritory + "{" + Conversions.ToString(iXMax) + ";" + Conversions.ToString(iYMin) + ";" + Conversions.ToString(iZMin) + ";" + Conversions.ToString(iZMax) + "};";
						sTempTerritory = sTempTerritory + "{" + Conversions.ToString(iXMax) + ";" + Conversions.ToString(iYMax) + ";" + Conversions.ToString(iZMin) + ";" + Conversions.ToString(iZMax) + "};";
						sTempTerritory = sTempTerritory + "{" + Conversions.ToString(iXMin) + ";" + Conversions.ToString(iYMax) + ";" + Conversions.ToString(iZMin) + ";" + Conversions.ToString(iZMax) + "}";

						outFile.WriteLine("territory_begin" + Constants.vbTab + "[" + sPrevZoneName + "]" + Constants.vbTab + "{" + sTempTerritory + "}" + Constants.vbTab + "territory_end");
						outFile.WriteLine("npcmaker_begin" + Constants.vbTab + "[" + sPrevZoneName + "]" + Constants.vbTab + "initial_spawn=all" + Constants.vbTab + "maximum_npc=" + Conversions.ToString(iNpcCount));


						for (int iTemp = 0, loopTo = iNpcCount - 1; iTemp <= loopTo; iTemp++)
						{

							// Checking exising npc in NpcPch
							if (aNpcPch[Conversions.ToInteger(aNpcSpawn[iTemp].npc_templateid)] == null)
							{
								// MessageBox.Show("Npc [" & aTemp(3) & "] not found!", "NPC not found", MessageBoxButtons.OK, MessageBoxIcon.Error)

								if (Array.IndexOf(aNpcMiss, aNpcSpawn[iTemp].npc_templateid) == -1)
								{
									aNpcMiss[aNpcMiss.Length - 1] = aNpcSpawn[iTemp].npc_templateid;
									Array.Resize(ref aNpcMiss, aNpcMiss.Length + 1);
								}

								sTempNpcName = "[_need_" + Conversions.ToString(aNpcSpawn[iTemp].npc_templateid) + "_]";
							}
							else
								sTempNpcName = aNpcPch[Conversions.ToInteger(aNpcSpawn[iTemp].npc_templateid)];

							// npc_begin	[fantasy_isle_paddies]	pos={-59234;-56897;-2032;0}	total=1	respawn=60sec	npc_end
							outFile.WriteLine("npc_begin" + Constants.vbTab + sTempNpcName + Constants.vbTab + "pos={" + Conversions.ToString(aNpcSpawn[iTemp].locx) + "," + Conversions.ToString(aNpcSpawn[iTemp].locy) + "," + Conversions.ToString(aNpcSpawn[iTemp].locz) + "," + Conversions.ToString(aNpcSpawn[iTemp].heading) + "}" + Constants.vbTab + "total=1" + Constants.vbTab + "respawn=" + Conversions.ToString(aNpcSpawn[iTemp].respawn_delay) + "sec" + Constants.vbTab + "npc_end");
						}

						// npcmaker_end
						outFile.WriteLine("npcmaker_end");
						iNpcCount = 0;
						Array.Clear(aNpcSpawn, 0, aNpcSpawn.Length);
						Array.Resize(ref aNpcSpawn, 1);

						sPrevZoneName = sCurZoneName;
					}

					// ADD new Npc to Array
					Array.Resize(ref aNpcSpawn, iNpcCount + 1);

					// Dim iXMin As Integer, iXMax As Integer
					// Dim iYMin As Integer, iYMax As Integer
					// Dim iZMin As Integer, iZMax As Integer

					aNpcSpawn[iNpcCount].npc_templateid = Conversions.ToInteger(aTemp[3]);
					aNpcSpawn[iNpcCount].locx = Conversions.ToInteger(aTemp[4]);
					aNpcSpawn[iNpcCount].locy = Conversions.ToInteger(aTemp[5]);
					aNpcSpawn[iNpcCount].locz = Conversions.ToInteger(aTemp[6]);
					aNpcSpawn[iNpcCount].heading = Conversions.ToInteger(aTemp[9]);
					aNpcSpawn[iNpcCount].respawn_delay = Conversions.ToInteger(aTemp[10]);

					if (iNpcCount == 0)
						iXMin = aNpcSpawn[iNpcCount].locx;
					if (iNpcCount == 0)
						iXMax = aNpcSpawn[iNpcCount].locx;
					if (iNpcCount == 0)
						iYMin = aNpcSpawn[iNpcCount].locy;
					if (iNpcCount == 0)
						iYMax = aNpcSpawn[iNpcCount].locy;
					if (iNpcCount == 0)
						iZMin = aNpcSpawn[iNpcCount].locz;
					if (iNpcCount == 0)
						iZMax = aNpcSpawn[iNpcCount].locz;


					if (aNpcSpawn[iNpcCount].locx < iXMin)
						iXMin = aNpcSpawn[iNpcCount].locx;
					if (aNpcSpawn[iNpcCount].locx > iXMax)
						iXMax = aNpcSpawn[iNpcCount].locx;

					if (aNpcSpawn[iNpcCount].locy < iYMin)
						iYMin = aNpcSpawn[iNpcCount].locy;
					if (aNpcSpawn[iNpcCount].locy > iYMax)
						iYMax = aNpcSpawn[iNpcCount].locy;

					if (aNpcSpawn[iNpcCount].locz < iZMin)
						iZMin = aNpcSpawn[iNpcCount].locz;
					if (aNpcSpawn[iNpcCount].locz > iZMax)
						iZMax = aNpcSpawn[iNpcCount].locz;

					iNpcCount = iNpcCount + 1;
				}
			}
			ToolStripProgressBar.Value = 0;
			inSpawnFile.Close();
			outFile.Close();

			if (aNpcMiss.Length > 0)
			{
				outFile = new System.IO.StreamWriter("npcpos_l2j.log", false, System.Text.Encoding.Unicode, 1);
				outFile.WriteLine("Missed NPC. Required for NpcPos:");
				var loopTo1 = aNpcMiss.Length - 2;
				for (iNpcCount = 0; iNpcCount <= loopTo1; iNpcCount++)
					outFile.WriteLine("npc_id=" + Conversions.ToString(aNpcMiss[iNpcCount]));
				outFile.Close();
			}

			MessageBox.Show("Completed. With [" + Conversions.ToString(iNpcCount) + "] missed npc's.");
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
