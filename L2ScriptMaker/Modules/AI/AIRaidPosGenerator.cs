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

namespace L2ScriptMaker.Modules.AI
{
	public partial class AIRaidPosGenerator : Form
	{
		public AIRaidPosGenerator()
		{
			InitializeComponent();
		}

		private struct RaidBoss
		{
			public int Id;
			public int Level;
			public string PchName;  // from npcpch.txt
			public string Name;  // from npcname-e.txt
			public string Privates;
			public int LocX;
			public int LocY;
			public int LocZ;
		}

		// raiddata-e.txt
		// raiddata_begin	id=1	npc_id=29001	npc_level=40	affiliated_area_id=30	loc_x=-21610.000000	loc_y=181594.000000	loc_z=-5734.000000	raid_desc=[]	raiddata_end
		// -> raiddata_begin	id=139	npc_id=25333	npc_level=28	affiliated_area_id=179	loc_x=0.000000	loc_y=0.000000	loc_z=0.000000	raid_desc=[A being that tries to invade the real world by crossing the Dimensional Rift along with the otherworldly devils. Its shape is very unstable because of the Rift's distortion of time and space.]	raiddata_end

		// npcname-e.txt
		// npcname_begin	id=25001	name=[Greyclaw Kutus]	description=[Raid Boss]	rgb[0]=3F	rgb[1]=8B	rgb[2]=FE	reserved1=-1	npcname_end
		// npcname_begin	id=25002	name=[Guard of Kutus]	description=[Raid Fighter]	rgb[0]=3F	rgb[1]=8B	rgb[2]=FE	reserved1=-1	npcname_end
		// npc_pch.txt
		// [hatchling_of_wind] = 1012311


		private void StartButton_Click(object sender, EventArgs e)
		{
			string sRBFile = "raiddata-e.txt";
			string sNpcNameFile = "npcname-e.txt";
			string sNpcPchFile = "npc_pch.txt";

			string sRBAIFile = "announce_raid_boss_position_all_rb.txt";
			string sRBNpcPos = "npcpos_all_rb.txt";

			OpenFileDialog.FileName = sRBFile;
			OpenFileDialog.Filter = "Lineage II client Raid Boss position file (raiddata-e.txt)|raiddata*.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sRBFile = OpenFileDialog.FileName;

			OpenFileDialog.FileName = sNpcNameFile;
			OpenFileDialog.Filter = "Lineage II client npcname file (npcname-e.txt)|npcname*.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sNpcNameFile = OpenFileDialog.FileName;

			OpenFileDialog.FileName = sNpcPchFile;
			OpenFileDialog.Filter = "Lineage II server npc file (npc_pch.txt)|npc_pch.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sNpcPchFile = OpenFileDialog.FileName;

			SaveFileDialog.FileName = sRBAIFile;
			SaveFileDialog.Filter = "Lineage II Raid Boss AI.obj class (announce_raid_boss_position_all_rb.txt)|*.txt|All files|*.*";
			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sRBAIFile = SaveFileDialog.FileName;

			SaveFileDialog.FileName = sRBNpcPos;
			SaveFileDialog.Filter = "Lineage II Raid Boss Npcpos(announce_raid_boss_position_all_rb.txt)|*.txt|All files|*.*";
			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sRBNpcPos = SaveFileDialog.FileName;

			System.IO.StreamReader inFile; // = Nothing
			System.IO.StreamWriter outFile;

			var aNpcPch = new string[1];    // storage for ids (29001,25001,...)
			var aBase = new RaidBoss[1];

			string sTemp;
			int iTemp;
			string[] aTemp;

			// Reading NpcPch file
			inFile = new System.IO.StreamReader(sNpcPchFile, System.Text.Encoding.Default, true, 1);
			ToolStripProgressBar.Value = 0;
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				sTemp = sTemp.Trim().Replace(" ", "");
				aTemp = sTemp.Split(Conversions.ToChar("="));

				// npc_pch.txt
				// [hatchling_of_wind] = 1012311

				if (Conversions.ToInteger(aTemp[1].Substring(2, 5)) >= aNpcPch.Length)
					Array.Resize(ref aNpcPch, Conversions.ToInteger(aTemp[1].Substring(2, 5)) + 1);
				aNpcPch[aNpcPch.Length - 1] = aTemp[0];

				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
			}
			ToolStripProgressBar.Value = 0;
			inFile.Close();

			// Reading raiddata-e.txt file
			inFile = new System.IO.StreamReader(sRBFile, System.Text.Encoding.Default, true, 1);
			ToolStripProgressBar.Value = 0;
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();

				// raiddata-e.txt
				// raiddata_begin	id=1	npc_id=29001	npc_level=40	affiliated_area_id=30	loc_x=-21610.000000	loc_y=181594.000000	loc_z=-5734.000000	raid_desc=[]	raiddata_end
				// -> raiddata_begin	id=139	npc_id=25333	npc_level=28	affiliated_area_id=179	loc_x=0.000000	loc_y=0.000000	loc_z=0.000000	raid_desc=[A being that tries to invade the real world by crossing the Dimensional Rift along with the otherworldly devils. Its shape is very unstable because of the Rift's distortion of time and space.]	raiddata_end

				iTemp = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "npc_id"));
				if (!string.IsNullOrEmpty(aNpcPch[iTemp]))
				{
					Array.Resize(ref aBase, aBase.Length + 1);
					aBase[aBase.Length - 1].PchName = aNpcPch[iTemp];
					aBase[aBase.Length - 1].Id = iTemp;
					iTemp = aBase.Length - 1;
					aBase[iTemp].Level = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "npc_level"));
					aBase[iTemp].LocX = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "loc_x"));
					aBase[iTemp].LocY = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "loc_y"));
					aBase[iTemp].LocZ = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "loc_z"));
				}

				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
			}
			ToolStripProgressBar.Value = 0;
			inFile.Close();

			// Reading npcname-e.txt file
			inFile = new System.IO.StreamReader(sNpcNameFile, System.Text.Encoding.Default, true, 1);
			ToolStripProgressBar.Value = 0;
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			int iTempLevel;
			int iPrevBossId = -1;
			string sTemp2;

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();

				// npcname-e.txt
				// npcname_begin	id=25001	name=[Greyclaw Kutus]	description=[Raid Boss]	rgb[0]=3F	rgb[1]=8B	rgb[2]=FE	reserved1=-1	npcname_end
				// npcname_begin	id=25002	name=[Guard of Kutus]	description=[Raid Fighter]	rgb[0]=3F	rgb[1]=8B	rgb[2]=FE	reserved1=-1	npcname_end
				iTemp = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "id"));
				var loopTo = aBase.Length - 1;
				for (iTempLevel = 0; iTempLevel <= loopTo; iTempLevel++)
				{
					if (aBase[iTempLevel].Id == iTemp)
					{
						aBase[iTempLevel].Name = Libraries.GetNeedParamFromStr(sTemp, "name").Replace("[", "").Replace("]", "");
						// aBase(aBase.Length - 1).Privates = Libraries.GetNeedParamFromStr(sTemp, "description")
						iPrevBossId = iTempLevel;
					}
				}

				if (GenPrivatesCheckBox.Checked == true)
				{
					// iPrevBossId
					sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "description");
					if (sTemp2.StartsWith("[Raid ") == true & sTemp2.StartsWith("[Raid Boss") == false)
					{
						// Found privates
						iTemp = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "id"));
						if (iTemp != -1)
						{
							if (!string.IsNullOrEmpty(aBase[iPrevBossId].Privates))
								aBase[iPrevBossId].Privates = aBase[iPrevBossId].Privates + ";";
							aBase[iPrevBossId].Privates = aBase[iPrevBossId].Privates + aNpcPch[iTemp].Replace("[", "").Replace("]", "");
						}
					}
				}

				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
			}
			ToolStripProgressBar.Value = 0;
			inFile.Close();


			// WRITE AI class 'announce_raid_boss_position.txt'
			outFile = new System.IO.StreamWriter(sRBAIFile, false, System.Text.Encoding.Unicode, 1);

			// Write header to AI class
			outFile.WriteLine("class 1 announce_raid_boss_position : citizen");
			outFile.WriteLine("parameter_define_begin");
			outFile.WriteLine(Constants.vbTab + "string fnHiPCCafe \"pc.htm\"");
			outFile.WriteLine("parameter_define_end");
			outFile.WriteLine("property_define_begin");
			int iTempLevel2;

			for (iTempLevel = 20; iTempLevel <= 90; iTempLevel += 10)
			{

				// telposlist_begin RaidBossList20_29
				outFile.WriteLine(Constants.vbTab + "telposlist_begin RaidBossList{0}_{1}", iTempLevel, iTempLevel + 9);

				for (iTempLevel2 = 0; iTempLevel2 <= 9; iTempLevel2++) // Step 10
				{
					var loopTo1 = aBase.Length - 1;
					for (iTemp = 0; iTemp <= loopTo1; iTemp++)
					{
						if (aBase[iTemp].Level == iTempLevel + iTempLevel2)
						{
							// {"Madness Beast (lv20)"; -54096; 84288; -3512; 0; 0 }
							if (aBase[iTemp].LocX != 0)
								// outFile.WriteLine(vbTab & vbTab & "{""" & aBase(iTemp).Name & " (lv" & aBase(iTemp).Level & ")""; " & aBase(iTemp).LocX & "; " & aBase(iTemp).LocY & "; " & aBase(iTemp).LocZ & "; 0; 0}")
								outFile.WriteLine(Constants.vbTab + Constants.vbTab + "{\"" + aBase[iTemp].Name + " (lv" + Conversions.ToString(aBase[iTemp].Level) + ")\"; " + Conversions.ToString(aBase[iTemp].LocX) + "; " + Conversions.ToString(aBase[iTemp].LocY) + "; " + Conversions.ToString(aBase[iTemp].LocZ) + "; 0; 0}");
						}
					}
				}

				outFile.WriteLine(Constants.vbTab + "telposlist_end");
			}
			outFile.WriteLine("property_define_end");
			outFile.Close();


			// WRITE NpcPos'
			if (GenPosCheckBox.Checked == true)
			{
				outFile = new System.IO.StreamWriter(sRBNpcPos, false, System.Text.Encoding.Unicode, 1);

				// Write header to AI class

				// territory_begin	[aden24_mb2320_04]	{{123340;93852;-2464;-1864};{124204;93488;-2464;-1864};{124684;93960;-2464;-1864};{124512;94308;-2464;-1864};{123572;94656;-2464;-1864}}	territory_end					
				// npcmaker_begin	[aden24_mb2320_04]	initial_spawn=all	maximum_npc=10					
				// npc_begin	[kelbar]	pos=anywhere	total=1	respawn=36hour	respawn_rand=24hour	dbname=[kelbar]	dbsaving={death_time;parameters}	npc_end
				// npcmaker_end	

				int iTemp2;
				var loopTo2 = aBase.Length - 1;
				for (iTemp = 0; iTemp <= loopTo2; iTemp++)
				{
					if (aBase[iTemp].LocX != 0)
					{
						// territory_begin	[aden24_mb2320_04]	{{123340;93852;-2464;-1864};{124204;93488;-2464;-1864};{124684;93960;-2464;-1864};{124512;94308;-2464;-1864};{123572;94656;-2464;-1864}}	territory_end					
						outFile.Write("territory_begin" + Constants.vbTab);
						outFile.Write("[raidboss" + Conversions.ToString(iTemp) + "_" + aBase[iTemp].PchName.Replace("[", "").Replace("]", "") + "]" + Constants.vbTab);
						outFile.Write("{{" + Conversions.ToString(aBase[iTemp].LocX - 200) + ";" + Conversions.ToString(aBase[iTemp].LocY - 200) + ";" + Conversions.ToString(aBase[iTemp].LocZ - 100) + ";" + Conversions.ToString(aBase[iTemp].LocZ + 300) + "};");
						outFile.Write("{" + Conversions.ToString(aBase[iTemp].LocX + 200) + ";" + Conversions.ToString(aBase[iTemp].LocY - 200) + ";" + Conversions.ToString(aBase[iTemp].LocZ - 100) + ";" + Conversions.ToString(aBase[iTemp].LocZ + 300) + "};");
						outFile.Write("{" + Conversions.ToString(aBase[iTemp].LocX + 200) + ";" + Conversions.ToString(aBase[iTemp].LocY + 200) + ";" + Conversions.ToString(aBase[iTemp].LocZ - 100) + ";" + Conversions.ToString(aBase[iTemp].LocZ + 300) + "};");
						outFile.Write("{" + Conversions.ToString(aBase[iTemp].LocX - 200) + ";" + Conversions.ToString(aBase[iTemp].LocY + 200) + ";" + Conversions.ToString(aBase[iTemp].LocZ - 100) + ";" + Conversions.ToString(aBase[iTemp].LocZ + 300) + "}");
						outFile.WriteLine("}}" + Constants.vbTab + "territory_end");

						// npcmaker_begin	[aden24_mb2320_04]	initial_spawn=all	maximum_npc=10					
						outFile.Write("npcmaker_begin" + Constants.vbTab);
						outFile.Write("[raidboss" + Conversions.ToString(iTemp) + "_" + aBase[iTemp].PchName.Replace("[", "").Replace("]", "") + "]" + Constants.vbTab);
						outFile.Write("initial_spawn=all" + Constants.vbTab);
						outFile.WriteLine("maximum_npc=10");

						// npc_begin	[kelbar]	pos=anywhere	total=1	respawn=36hour	respawn_rand=24hour	dbname=[kelbar]	dbsaving={death_time;parameters}	npc_end
						// Privates=[talakin_archer:talakin_archer:1:0sec;talakin_raider:talakin_raider:1:0sec]
						outFile.Write("npc_begin" + Constants.vbTab);
						outFile.Write(aBase[iTemp].PchName + Constants.vbTab + "pos=anywhere" + Constants.vbTab + "total=1" + Constants.vbTab + "respawn=36hour" + Constants.vbTab + "respawn_rand=24hour" + Constants.vbTab + "dbname=" + aBase[iTemp].PchName + Constants.vbTab + "dbsaving={death_time;parameters}" + Constants.vbTab);

						// Generate Privates list
						if (GenPrivatesCheckBox.Checked == true)
						{
							if (!string.IsNullOrEmpty(aBase[iTemp].Privates))
							{
								outFile.Write("Privates=[");
								aTemp = aBase[iTemp].Privates.Split(Conversions.ToChar(";"));
								var loopTo3 = aTemp.Length - 1;
								for (iTemp2 = 0; iTemp2 <= loopTo3; iTemp2++)
								{
									outFile.Write(aTemp[iTemp2] + ":");
									outFile.Write(aTemp[iTemp2] + ":");
									outFile.Write("1:0sec");
									if (iTemp2 < aTemp.Length - 1)
										outFile.Write(";");
								}
								outFile.Write("]" + Constants.vbTab);
							}
						}

						outFile.WriteLine("npc_end");

						// npcmaker_end	
						outFile.WriteLine("npcmaker_end" + Constants.vbNewLine);
					}
				}
				outFile.Close();
			}


			MessageBox.Show("Complete.");
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}


		private void GenPosCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (GenPosCheckBox.Checked == false)
				GenPrivatesCheckBox.Enabled = false;
			else
				GenPrivatesCheckBox.Enabled = true;
		}
	}
}
