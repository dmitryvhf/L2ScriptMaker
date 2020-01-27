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

namespace L2ScriptMaker.Modules.Npc
{
	public partial class NpcDataHerbMobs : Form
	{
		public NpcDataHerbMobs()
		{
			InitializeComponent();
		}

		private TerritoryDefine[] aTerra = new TerritoryDefine[1];

		// huntingzone_begin	id=2	hunting_type=1	level=25	unk_1=0	loc_x=50568.000000	loc_y=152408.000000	loc_z=-2656.000000	unk_2=0	affiliated_area_id=1	name=[Execution Grounds]	huntingzone_end
		private struct TerritoryDefine
		{
			public int x;
			public int y;
			public int z;
			public int level;
		}

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			string sNpcNameE = "npcname-e.txt";
			string sNpcdataPch = "npc_pch.txt";
			string sNpcdata = "npcdata.txt";
			string sHuntingzoneE = "huntingzone-e.txt";
			string sNpcpos = "npcpos.txt";

			if (System.IO.File.Exists(sNpcNameE) == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Filter = "Lineage II client text file (npcname-e.txt)|npcname-e.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				sNpcNameE = OpenFileDialog.FileName;
			}

			if (System.IO.File.Exists(sNpcdataPch) == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Filter = "Lineage II server npc config (npc_pch.txt)|npc_pch.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				sNpcdataPch = OpenFileDialog.FileName;
			}

			if (System.IO.File.Exists(sHuntingzoneE) == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Filter = "Lineage II client text file (huntingzone-e.txt)|huntingzone-e.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				sHuntingzoneE = OpenFileDialog.FileName;
			}

			if (System.IO.File.Exists(sNpcpos) == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Filter = "Lineage II server npc config (npcpos.txt)|npcpos*.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				sNpcpos = OpenFileDialog.FileName;
			}
			if (System.IO.File.Exists(sNpcdata) == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Filter = "Lineage II server npc config (npcdata.txt)|npcdata*.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				sNpcdata = OpenFileDialog.FileName;
			}

			string sTemp;
			string[] aTemp = null;
			int iTemp;
			// Dim aNpcId(40000) As Integer
			var aNpcName = new string[40001];
			var aNpcHerb = new bool[40001];

			var aQuestNpc = new string[1];
			System.IO.StreamReader inFile;

			// Dim inHuntingzoneE As New System.IO.StreamReader(sHuntingzoneE, System.Text.Encoding.Default, True, 1)
			// Dim inNpcpos As New System.IO.StreamReader(sNpcpos, System.Text.Encoding.Default, True, 1)
			// Dim inNpcData As New System.IO.StreamReader(sNpcdata, System.Text.Encoding.Default, True, 1)


			// [pet_wolf_a] = 1012077
			inFile = new System.IO.StreamReader(sNpcdataPch, System.Text.Encoding.Default, true, 1);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading npc_pch.txt...";
			StatusStrip.Update();

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);

				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{
					sTemp = sTemp.Replace(" ", "").Replace(Conversions.ToString((char)9), ""); // Replace("[", "").Replace("]", "").
					aTemp = sTemp.Split(Conversions.ToChar("="));
					aNpcName[Conversions.ToInteger(aTemp[1]) - 1000000] = aTemp[0];
				}
			}
			inFile.Close();
			ToolStripProgressBar.Value = 0;


			inFile = new System.IO.StreamReader(sHuntingzoneE, System.Text.Encoding.Default, true, 1);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading huntingzone-e.txt...";
			StatusStrip.Update();

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{
					iTemp = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "level"));

					// huntingzone_begin	id=2	hunting_type=1	level=25	unk_1=0	loc_x=50568.000000	loc_y=152408.000000	loc_z=-2656.000000	unk_2=0	affiliated_area_id=1	name=[Execution Grounds]	huntingzone_end

					// If Libraries.GetNeedParamFromStr(sTemp, "name") = "[Valley of Saints]" Then
					// Dim dskjk As Boolean = True
					// End If

					if (iTemp > 0 & (Libraries.GetNeedParamFromStr(sTemp, "hunting_type") ?? "") == "1")
					{
						iTemp = aTerra.Length;
						Array.Resize(ref aTerra, iTemp + 1);
						aTerra[iTemp - 1].x = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "loc_x"));
						aTerra[iTemp - 1].y = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "loc_y"));
						aTerra[iTemp - 1].z = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "loc_z"));
						aTerra[iTemp - 1].level = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "level"));
					}
				}
			}
			inFile.Close();
			ToolStripProgressBar.Value = 0;


			bool bScanMob = false;
			inFile = new System.IO.StreamReader(sNpcpos, true);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading Npcpos.txt...";
			StatusStrip.Update();

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{
					if (sTemp.StartsWith("territory_begin") == true)
					{
						//if (Strings.InStr(sTemp, "[rune08_2215_23]") > 0)
						//	bool skjak = true;

						sTemp = sTemp.Substring(Strings.InStr(sTemp, "{{") + 1, Strings.InStr(sTemp, "};{") - Strings.InStr(sTemp, "{{") - 2);
						bScanMob = InMyTerritory(sTemp);
					}
					if (bScanMob == true)
					{
						if (sTemp.StartsWith("npc_begin") == true | sTemp.StartsWith("npc_ex_begin") == true)
						{
							// sTemp = sTemp.Substring(InStr(sTemp, "[") - 1, InStr(sTemp, "]") - InStr(sTemp, "[") + 1)
							// [brilliant_legacy], [highprist_partyleader01]
							//if ((sTemp.Substring(Strings.InStr(sTemp, "[") - 1, Strings.InStr(sTemp, "]") - Strings.InStr(sTemp, "[") + 1) ?? "") == "[brilliant_legacy]")
							//	bool skjak = true;

							if (Strings.InStr(sTemp, "Privates=[") == 0 & Strings.InStr(sTemp, "[SSQLoserTeleport]") == 0)
							{
								iTemp = Array.IndexOf(aNpcName, sTemp.Substring(Strings.InStr(sTemp, "[") - 1, Strings.InStr(sTemp, "]") - Strings.InStr(sTemp, "[") + 1));
								if (iTemp != -1)
									aNpcHerb[iTemp] = true;
							}
						}
					}
				}
			}
			inFile.Close();
			ToolStripProgressBar.Value = 0;


			System.IO.File.Copy(sNpcdata, sNpcdata + ".bak", true);
			inFile = new System.IO.StreamReader(sNpcdata + ".bak", System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter(sNpcdata, false, System.Text.Encoding.Unicode, 1);
			var outLog = new System.IO.StreamWriter(sNpcdata + ".log", false, System.Text.Encoding.Unicode, 1);
			outLog.WriteLine("Lineage II ScriptMaker: Herb mob generator. Start of " + Conversions.ToString(DateAndTime.Now) + Constants.vbNewLine);
			outLog.WriteLine("This mob now is " + HerbMobTypeTextBox.Text);

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Rebuilding Npcdata.txt...";
			StatusStrip.Update();

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{

					// npc_begin(0)      pet(1)     12077(2)   [pet_wolf_a](3)    level=15(4)
					aTemp = sTemp.Split((char)9);

					// If aTemp(2) = "21530" Then
					// Dim skjak As Boolean = True
					// End If

					// If aTemp(3) = "[brilliant_legacy]" Then
					// Dim skjak As Boolean = True
					// End If

					// ------ Recovery type for npc before setting

					if (CheckBoxLa2Herb.Checked == true)
					{
						// fix for npcdata from dVampire
						sTemp = sTemp.Replace("herb_warrior", "warrior");
						if (string.IsNullOrEmpty(Libraries.GetNeedParamFromStr(sTemp, "drop_herb")))
							sTemp = sTemp.Replace("npc_end", "drop_herb=0" + Constants.vbTab + "npc_end");
						sTemp = Libraries.SetNeedParamToStr(sTemp, "drop_herb", "0");
					}
					else if ((aTemp[1] ?? "") == (HerbMobTypeTextBox.Text ?? ""))
					{
						aTemp[1] = "warrior";
						sTemp = Strings.Join(aTemp, Conversions.ToString((char)9));
					}

					// MAIN Fix
					if ((aTemp[1] ?? "") == "warrior")
					{

						// CHECKING for Known type no herb mobs
						if ((Libraries.GetNeedParamFromStr(sTemp, "unsowing") ?? "") == "1")
							// npc already unsowing
							goto NoFix;
						if (Strings.InStr(sTemp, "[Privates]") != 0)
							// Checking Privates settings into Npcdata.txt
							goto NoFix;
						if (Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "level").Replace("level=", "")) <= Conversions.ToInteger(HerbMobMinLvlTextBox.Text))
							goto NoFix;
						if (aNpcHerb[Conversions.ToInteger(aTemp[2])] == false)
							goto NoFix;
						// {[HelpHeroSilhouette]=@betrayer_orc_hero};
						if (Strings.InStr(sTemp, "[HelpHeroSilhouette]") != 0)
							goto NoFix;
						// {[silhouette]=@guardian_angel_r}
						if (Strings.InStr(sTemp, "[silhouette]") != 0)
							goto NoFix;
						// {[FeedID1_warrior_silhouette1]=@alpine_kukaburo_2_war_a1}  ??
						// ' HP1x checking
						// 'skill_list={@s_race_magic_creatures;@s_hp_increase10;@
						// If InStr(sTemp, "@s_hp_increase") <> 0 Then
						// If InStr(sTemp, "@s_hp_increase1;") = 0 And InStr(sTemp, "@s_hp_increase1}") = 0 Then
						// GoTo NoFix
						// End If
						// End If
						// clan={@c_dungeon_clan}
						// ai_parameters={[SSQLoserTeleport]=@SEAL_REVELATION;[SSQTelPosX]=[137453];[SSQTelPosY]=[79665];[SSQTelPosZ]=[-3696]}	
						if (Strings.InStr(sTemp, "@c_dungeon_clan") != 0)
							goto NoFix;

						// Mob checked - this Herb mob. Fixing
						if (CheckBoxLa2Herb.Checked == true)
							sTemp = Libraries.SetNeedParamToStr(sTemp, "drop_herb", "1");
						else
						{
							aTemp[1] = HerbMobTypeTextBox.Text;
							sTemp = Strings.Join(aTemp, Conversions.ToString((char)9));
						}
						outLog.WriteLine(aTemp[2] + Constants.vbTab + aTemp[3] + Constants.vbTab + aTemp[4]);

					NoFix:
						;
					}
				}


				outFile.WriteLine(sTemp);
			}

			outLog.WriteLine();
			outLog.WriteLine("End of " + Conversions.ToString(DateAndTime.Now));

			inFile.Close();
			outFile.Close();
			outLog.Close();
			ToolStripProgressBar.Value = 0;

			// inHuntingzoneE.Close()
			// inNpcpos.Close()
			// inNpcData.Close()

			MessageBox.Show("Complete");
		}

		private bool InMyTerritory(string LocXYZ)
		{
			string[] aTemp;
			int iTemp;
			int iTempX;
			int iTempY;
			int iTempZ;

			aTemp = LocXYZ.Split(Conversions.ToChar(";"));
			iTempX = Conversions.ToInteger(aTemp[0]);
			iTempY = Conversions.ToInteger(aTemp[1]);
			iTempZ = Conversions.ToInteger(aTemp[2]);

			int iRadiusXY = Conversions.ToInteger(RaduisXYTextBox.Text);   // 16000
			int iRadiusZ = Conversions.ToInteger(RaduisZTextBox.Text);     // 1000
			var loopTo = aTerra.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				// if (iTemp == 121) bool skjak = true;

				if (iTempX >= aTerra[iTemp].x - iRadiusXY & iTempX <= aTerra[iTemp].x + iRadiusXY)
				{
					if (iTempY >= aTerra[iTemp].y - iRadiusXY & iTempY <= aTerra[iTemp].y + iRadiusXY)
					{
						if (iTempZ >= aTerra[iTemp].z - iRadiusZ & iTempZ <= aTerra[iTemp].z + iRadiusZ)
							return true;
					}
				}
			}
			return false;
		}


		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}

// huntingzone_begin	id=2	hunting_type=1	level=25	unk_1=0	loc_x=50568.000000	loc_y=152408.000000	loc_z=-2656.000000	unk_2=0	affiliated_area_id=1	name=[Execution Grounds]	huntingzone_end

// territory_begin	[rune09_2116_10]	{{59981;-54556;-3515;-2715};{60939;-53182;-3515;-2715};{60726;-52341;-3515;-2715};{59098;-52110;-3515;-2715};{58513;-53596;-3515;-2715}}	territory_end
// npcmaker_ex_begin	[rune09_2116_10]	name=[rune09_10_night]	ai=[on_day_night_spawn]	ai_parameters={[IsNight]=1}	maximum_npc=30
// npc_ex_begin	[beheaded]	pos=anywhere	total=4	respawn=30sec	npc_ex_end
// npc_ex_begin	[devil_bat_a]	pos=anywhere	total=3	respawn=30sec	npc_ex_end
// npc_ex_begin	[skull_animator]	pos=anywhere	total=3	respawn=30sec	npc_ex_end
// npcmaker_ex_end

// territory_begin	[aden06_2518_07]	{{177408;9460;-2768;-2468};{179068;9460;-2768;-2468};{179316;9704;-2768;-2468};{179308;11776;-2768;-2468};{178648;12892;-2768;-2468};{177748;12888;-2768;-2468};{177360;12432;-2768;-2468}}	territory_end
// npcmaker_begin	[aden06_2518_07]	initial_spawn=all	maximum_npc=85
// npc_begin	[bloody_queen]	pos=anywhere	total=2	respawn=25sec	npc_end
// npc_begin	[crimson_drake]	pos=anywhere	total=2	respawn=25sec	npc_end
// npc_begin	[kadios]	pos=anywhere	total=1	respawn=25sec	npc_end
// npcmaker_end
