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

namespace L2ScriptMaker.Modules.ZeroScripts.L2J
{
	public partial class L2J_NpcData_Drop : Form
	{
		public L2J_NpcData_Drop()
		{
			InitializeComponent();
		}

		private struct DropList
		{
			public int itemId;
			public int min;
			public int max;
			public int category;
			public double chance;
		}

		private string FixDropBlock(string sTemp)
		{
			if (sTemp.IndexOf(")") == 0)
				return null;
			sTemp = sTemp.Substring(1, sTemp.IndexOf(")") - 1);

			return sTemp;
		}

		private void ButtonDropChanceUpdate_Click(object sender, EventArgs e)
		{
			int iTemp;
			string sTemp;
			string[] aTemp;

			// Constants
			// ----------
			var sealStones = new[] { "6360", "6361", "6362" }; // Blue/Green/Red Seal Stone
			uint iRateAdena = Conversions.ToUInteger(1);
			uint iRateSealstones = Conversions.ToUInteger(1);
			uint iRateDrop = Conversions.ToUInteger(1);
			uint iRateDropRb = Conversions.ToUInteger(1);
			uint iRateSpoil = Conversions.ToUInteger(1);
			uint iRateHerb = Conversions.ToUInteger(1);
			const uint iRateLimit = 1_000_000;    // 100 * 10000
			var aNpcIgnore = new string[1001];   // Raidboss list

			try
			{
				iRateAdena = Conversions.ToUInteger(TextBoxRateAdena.Text);
				iRateSealstones = Conversions.ToUInteger(TextBoxRateSealstones.Text);
				iRateDrop = Conversions.ToUInteger(TextBoxRateDrop.Text);
				iRateDropRb = Conversions.ToUInteger(TextBoxRateDropRB.Text);
				iRateSpoil = Conversions.ToUInteger(TextBoxRateSpoil.Text);
				iRateHerb = Conversions.ToUInteger(TextBoxRateHerb.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Enter only integer numbers to rate value." + Constants.vbNewLine + ex.Message);
				return;
			}

			System.IO.StreamReader inFile;
			System.IO.StreamWriter outFile;

			// LOADING ignorenpclist.txt 
			if (CheckBoxSpecNpcList.Checked == true)
			{
				if (System.IO.File.Exists("raidlist.csv") == false)
				{
					MessageBox.Show("raidlist.csv not found", "raidlist.csv", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				inFile = new System.IO.StreamReader("raidlist.csv", System.Text.Encoding.Default, true, 1);
				ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
				ToolStripStatusLabel.Text = "Loading raidlist.csv ...";

				while (inFile.EndOfStream != true)
				{
					sTemp = inFile.ReadLine().Trim();
					ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);

					if (sTemp.Length == 0)
						continue;
					if (Conversions.ToInteger(sTemp) == 0)
						continue;
					aNpcIgnore[Array.IndexOf(aNpcIgnore, null)] = sTemp;
				}

				// inFile = New System.IO.StreamReader("NpcName-e.txt", System.Text.Encoding.Default, True, 1)
				// ToolStripProgressBar.Maximum = CInt(inFile.BaseStream.Length)
				// ToolStripStatusLabel.Text = "Loading NpcName-e.txt ..."
				// '        Dim iSpecialBoss() As Integer = {18465, 22326, 22341, 25539, 29021, 12532, 12533, 12534, 12539, 12540, 12541, 12542, 12543, 29045, 29046}

				// outFile = New System.IO.StreamWriter("npcignorelist.sql", False, System.Text.Encoding.ASCII, 1)
				// 'outFile.WriteLine ("UPDATE `npc` SET type = '")
				// While inFile.EndOfStream <> True

				// sTemp = inFile.ReadLine.Trim
				// ToolStripProgressBar.Value = CInt(inFile.BaseStream.Position)
				// sTemp = sTemp.Trim
				// If sTemp.StartsWith("npcname_begin") = True Then
				// 'npcname_begin	id=25001	name=[Greyclaw Kutus]	description=[Raid Boss]	            rgb[0]=[3F]	rgb[1]=[8B]	rgb[2]=[FE]	reserved1=-1	npcname_end
				// 'npcname_begin	id=25563	name=[Beautiful Atrielle]	description=[Forsaken Prisoner]	rgb[0]=[3F]	rgb[1]=[8B]	rgb[2]=[FE]	reserved1=-1	npcname_end
				// 'npcname_begin	id=20001	name=[Gremlin]	        description=[]	                    rgb[0]=[9C]	rgb[1]=[E8]	rgb[2]=[A9]	reserved1=-1	npcname_end
				// 'npcname_begin	id=29028	name=[Valakas]	description=[Fire Dragon]	                rgb[0]=[9C]	rgb[1]=[E8]	rgb[2]=[A9]	reserved1=-1	npcname_end
				// If Libraries.GetNeedParamFromStr(sTemp, "rgb[0]") = "[3F]" And Libraries.GetNeedParamFromStr(sTemp, "rgb[1]") = "[8B]" _
				// And Libraries.GetNeedParamFromStr(sTemp, "rgb[2]") = "[FE]" Then
				// aNpcIgnore(Array.IndexOf(aNpcIgnore, Nothing)) = Libraries.GetNeedParamFromStr(sTemp, "id")
				// outFile.WriteLine(Libraries.GetNeedParamFromStr(sTemp, "id"))
				// End If
				// End If

				// End While
				// outFile.Flush()

				inFile.Close();
				ToolStripProgressBar.Value = 0;
			}

			// LOADING itemdata-e.txt
			if (System.IO.File.Exists("ItemName-e.txt") == false)
			{
				MessageBox.Show("ItemName-e.txt not found", "Need ItemName-e.txt", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var aItemdata = new string[30001];
			inFile = new System.IO.StreamReader("ItemName-e.txt", System.Text.Encoding.Default, true, 1);
			inFile = new System.IO.StreamReader("~ItemName-e_new.txt", System.Text.Encoding.Default, true, 1);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading ItemName-e.txt ...";

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				// If sTemp.StartsWith("itemname_begin") = False Then Continue While
				if (sTemp.StartsWith("~ItemName_begin") == false)
					continue;

				// itemname_begin	id=17	name=[Wooden Arrow]	
				iTemp = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "id"));
				sTemp = Libraries.GetNeedParamFromStr(sTemp, "name").Replace("[", "").Replace("]", "");
				try
				{
					aItemdata[iTemp] = sTemp;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error in loading npc_pch.txt. Last reading line:" + Constants.vbNewLine + sTemp);
					inFile.Close();
					return;
				}
			}
			inFile.Close();
			ToolStripProgressBar.Value = 0;

			// --------------
			// MAIN ENGINE 

			if (System.IO.File.Exists("droplist.sql") == false)
			{
				MessageBox.Show("droplist.sql not found", "droplist.sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			System.IO.File.Copy("droplist.sql", "droplist.sql.bak", true);
			inFile = new System.IO.StreamReader("droplist.sql.bak", System.Text.Encoding.Default, true, 1);
			outFile = new System.IO.StreamWriter("droplist.sql", false, System.Text.Encoding.ASCII, 1);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading droplist.sql ...";
			string sPrevNpcId = "";
			string sCurNpcId = "";
			string sPrevCategory = "";
			string sCurCategory = "";
			char sEndSymb = Conversions.ToChar(",");
			string sItemName;

			var iChanceSumm = default(uint);
			var iGroupNum = default(uint);

			while (inFile.EndOfStream != true)
			{

				// (18001,1806,1,1,-1,10868),-- Recipe: Soulshot: B-Grade
				// (18001,57,765,1528,0,700000),-- Adena
				// (18001,4069,1,1,1,2102),-- Tunic of Zubei Fabric
				// mobid , itemid, min, max, category/group , change*10000

				sTemp = inFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);

				if (sTemp.StartsWith("(") == true)
				{
					if (sTemp.IndexOf(";") > 0)
						sEndSymb = Conversions.ToChar(";");
					else
						sEndSymb = Conversions.ToChar(",");

					sTemp = FixDropBlock(sTemp);
					aTemp = sTemp.Split(Conversions.ToChar(","));

					sCurNpcId = aTemp[0];
					sCurCategory = aTemp[4];

					if (string.IsNullOrEmpty(sPrevNpcId))
						sPrevNpcId = sCurNpcId;
					if (string.IsNullOrEmpty(sPrevCategory))
						sPrevCategory = sCurCategory;

					// CHANCE CHECKER ENGINE

					if ((sPrevNpcId ?? "") != (sCurNpcId ?? ""))
						iGroupNum = Conversions.ToUInteger(0);

					if ((sPrevNpcId ?? "") != (sCurNpcId ?? "") | (sCurCategory ?? "") != (sPrevCategory ?? ""))
					{
						if (iChanceSumm > iRateLimit & (sPrevCategory ?? "") != "-1")
							outFile.WriteLine("-- Attention!!! Previous group have wrong group chance: [" + iChanceSumm.ToString() + "]");
						iChanceSumm = Conversions.ToUInteger(0);
					}
					iChanceSumm = iChanceSumm + Conversions.ToUInteger(aTemp[5]);

					if (aItemdata[Conversions.ToInteger(aTemp[1])] != null)
						sItemName = aItemdata[Conversions.ToInteger(aTemp[1])].Replace("'", "");
					else
						sItemName = "undefined item";

					// (18001,4069,1,1,1,2102),-- Tunic of Zubei Fabric
					// mobid , itemid, min, max, category/group , change*10000

					// -------------------
					// RATE CHANCE ENGINE
					// -------------------
					if ((aTemp[1] ?? "") == "57")
					{
						// ADENA RATE

						aTemp[2] = (Conversions.ToUInteger(aTemp[2]) * iRateAdena).ToString();
						aTemp[3] = (Conversions.ToUInteger(aTemp[3]) * iRateAdena).ToString();
					}
					else if (Array.IndexOf(sealStones, aTemp[1]) != -1)
					{
						// SEALSTONES RATE
						aTemp[2] = (Conversions.ToUInteger(aTemp[2]) * iRateSealstones).ToString();
						aTemp[3] = (Conversions.ToUInteger(aTemp[3]) * iRateSealstones).ToString();
					}
					else if ((sCurCategory ?? "") == "-1")
					{
						// SPOIL RATE
						if (Conversions.ToUInteger(aTemp[5]) * iRateSpoil > iRateLimit)
						{
							// aTemp(1) = aTemp(1)
							aTemp[2] = (Conversions.ToUInteger(aTemp[2]) * iRateSpoil).ToString();
							aTemp[3] = (Conversions.ToUInteger(aTemp[3]) * iRateSpoil).ToString();
						}
						else
							// aTemp(5) = CDbl(Format((CDbl(aTemp(5)) * iRateSpoil), "0.######")).ToString
							aTemp[5] = (Conversions.ToUInteger(aTemp[5]) * iRateSpoil).ToString();
					}
					else if (aItemdata[Conversions.ToInteger(aTemp[1])].IndexOf("Herb") != -1)
					{
						// HERB ENGINE
						if (Conversions.ToDouble(aTemp[5]) * iRateHerb <= iRateLimit)
							// aTemp(5) = CDbl(Format((CDbl(aTemp(5)) * iRateHerb), "0.######")).ToString
							aTemp[5] = (Conversions.ToInteger(aTemp[5]) * iRateHerb).ToString();
						else
							aTemp[5] = iRateLimit.ToString();
					}
					else

							 // DROP ENGINE
							 if (CheckBoxSpecNpcList.Checked == false)
					{
						// SIMPLE DROP RATE ENGINE
						if (Conversions.ToUInteger(aTemp[5]) * iRateDrop > iRateLimit)
						{
							// aTemp(1) = aTemp(1)
							aTemp[2] = (Conversions.ToUInteger(aTemp[2]) * iRateDrop).ToString();
							aTemp[3] = (Conversions.ToUInteger(aTemp[3]) * iRateDrop).ToString();
						}
						else
							// aTemp(5) = CDbl(Format((CDbl(aTemp(5)) * iRateDrop), "0.######")).ToString
							aTemp[5] = (Conversions.ToUInteger(aTemp[5]) * iRateDrop).ToString();
					}
					else
					{

						// SPECIAL NPC LIST USE
						iTemp = Array.IndexOf(aNpcIgnore, aTemp[0]);

						// RadioButtonIgnoreDropNpc
						// RadioButtonRateChanceOnly

						// If (RadioButtonIgnoreDropNpc.Checked = True Or RadioButtonRateChanceOnly.Checked = True) And iTemp = -1 Then
						if (iTemp == -1)
						{

							// ALL OTHERS
							if (Conversions.ToUInteger(aTemp[5]) * iRateDrop > iRateLimit)
							{
								aTemp[2] = (Conversions.ToUInteger(aTemp[2]) * iRateDrop).ToString();
								aTemp[3] = (Conversions.ToUInteger(aTemp[3]) * iRateDrop).ToString();
								// int fixation
								aTemp[5] = Conversions.ToUInteger(aTemp[5]).ToString();
							}
							else
								aTemp[5] = (Conversions.ToUInteger(aTemp[5]) * iRateDrop).ToString();
						}
						else if (RadioButtonRateChanceOnly.Checked == true & iTemp != -1)
						{

							// NPC FROM LIST WILL BE Rate ONLY chances
							if (Conversions.ToUInteger(aTemp[5]) * iRateDropRb + iChanceSumm > iRateLimit)
							{
								aTemp[5] = iRateLimit.ToString();
								iGroupNum = Conversions.ToUInteger(iGroupNum + (long)1);
								aTemp[4] = Conversions.ToString(iGroupNum);
							}
							else
							{
								aTemp[5] = (Conversions.ToUInteger(aTemp[5]) * iRateDropRb).ToString();
								if (iGroupNum != Conversions.ToUInteger(aTemp[4]))
								{
									iGroupNum = Conversions.ToUInteger(iGroupNum + (long)1);
									aTemp[4] = Conversions.ToString(iGroupNum);
								}
								else
									iGroupNum = Conversions.ToUInteger(aTemp[4]);
							}
						}
						else
						{
						}
					}

					sTemp = Strings.Join(aTemp, ",");
					sTemp = "(" + sTemp + ")" + Conversions.ToString(sEndSymb) + "-- " + sItemName;
					sPrevNpcId = sCurNpcId;
					sPrevCategory = sCurCategory;
				}

				outFile.WriteLine(sTemp);
			}
			outFile.Flush(); outFile.Close();
			inFile.Close();
			ToolStripProgressBar.Value = 0;

			MessageBox.Show("Done.");
			ToolStripStatusLabel.Text = "Done.";
		}

		private void ButtonStartPTSL2J_Click(object sender, EventArgs e)
		{
			MessageBox.Show("No work yet.");
			return;
		}

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			string sSpawnListFile;
			string sTemp;
			string[] aTemp;

			System.IO.StreamReader inSpawnFile;
			System.IO.StreamWriter outFile;


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

			// LOADING item_pch.txt
			if (System.IO.File.Exists("item_pch.txt") == false)
			{
				MessageBox.Show("item_pch.txt not found", "Need item_pch.txt", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var aItemPch = new string[25001];
			inSpawnFile = new System.IO.StreamReader("item_pch.txt", System.Text.Encoding.Default, true, 1);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inSpawnFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading item_pch.txt ...";

			while (inSpawnFile.EndOfStream != true)
			{
				sTemp = inSpawnFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inSpawnFile.BaseStream.Position);
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{

					// [small_sword] = 1
					sTemp = sTemp.Replace(" ", "").Replace(Conversions.ToString((char)9), "");
					aTemp = sTemp.Split(Conversions.ToChar("="));
					try
					{
						aItemPch[Conversions.ToInteger(aTemp[1])] = aTemp[0];
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error in loading item_pch.txt. Last reading line:" + Constants.vbNewLine + sTemp);
						inSpawnFile.Close();
						return;
					}
				}
			}
			inSpawnFile.Close();
			ToolStripProgressBar.Value = 0;

			// PREPARATION droplist.sql
			OpenFileDialog.Filter = "L2J NpcData Drop (droplist.sql)|droplist.sql|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			ToolStripStatusLabel.Text = "Preparation droplist.sql...";
			this.Update();
			sSpawnListFile = OpenFileDialog.FileName;
			inSpawnFile = new System.IO.StreamReader(sSpawnListFile, System.Text.Encoding.Default, true, 1);
			string sTemp2;

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inSpawnFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading item_pch.txt ...";

			System.IO.Directory.CreateDirectory("~droptmp");
			while (inSpawnFile.EndOfStream != true)
			{
				sTemp = inSpawnFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inSpawnFile.BaseStream.Position);
				this.Update();

				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("(") == true)
				{
					sTemp2 = sTemp.Substring(Strings.InStr(sTemp, "("), Strings.InStr(sTemp, ")") - Strings.InStr(sTemp, "(") - 1);
					sTemp2 = sTemp2.Replace("'", "");
					aTemp = sTemp2.Split(Conversions.ToChar(","));

					// (18001,1806,1,1,-1,10868),-- Recipe: Soulshot: B-Grade
					outFile = new System.IO.StreamWriter(@"~droptmp\" + aTemp[0] + ".txt", true, System.Text.Encoding.Unicode, 1);
					outFile.WriteLine(sTemp);
					outFile.Close();
				}
			}
			inSpawnFile.Close();
			ToolStripProgressBar.Value = 0;
			System.IO.File.Move(sSpawnListFile, sSpawnListFile + ".orig");

			// COLLECT NEW droplist.sql
			int iNpcCount = 0;
			outFile = new System.IO.StreamWriter(sSpawnListFile, false, System.Text.Encoding.Unicode, 1);
			aTemp = System.IO.Directory.GetFiles("~droptmp");
			ToolStripProgressBar.Maximum = Conversions.ToInteger(aTemp.Length - 1);
			ToolStripStatusLabel.Text = "Loading item_pch.txt ...";
			var loopTo = aTemp.Length - 1;
			for (iNpcCount = 0; iNpcCount <= loopTo; iNpcCount++)
			{
				ToolStripProgressBar.Value = iNpcCount;
				inSpawnFile = new System.IO.StreamReader(aTemp[iNpcCount], System.Text.Encoding.Default, true, 1);
				outFile.Write(inSpawnFile.ReadToEnd());
				inSpawnFile.Close();
			}
			outFile.Close();

			System.IO.Directory.Delete("~droptmp", true);

			Array.Clear(aTemp, 0, aTemp.Length);
			Array.Resize(ref aTemp, 0);

			outFile = new System.IO.StreamWriter("npcdata_drop_l2j.txt", false, System.Text.Encoding.Unicode, 1);
			inSpawnFile = new System.IO.StreamReader(sSpawnListFile, System.Text.Encoding.Default, true, 1);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inSpawnFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading droplist.sql...";
			string sCurNpcName = "";
			string sPrevNpcName = null;
			string sTempNpcName;
			string sTempItemName;
			// Dim sTempDropSpoil As String, sTempDropItems As String
			bool bItemCategory = false;

			var aItemList = new DropList[1];
			var aItemCategory = new string[256];
			var aItemMiss = new int[1];
			var aNpcMiss = new int[1];

			while (inSpawnFile.EndOfStream != true)
			{
				sTemp = inSpawnFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inSpawnFile.BaseStream.Position);
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("(") == true)
				{

					// ---------- Prepare for importing
					// `mobId` INT NOT NULL DEFAULT '0',
					// `itemId` INT NOT NULL DEFAULT '0',
					// `min` INT NOT NULL DEFAULT '0',
					// `max` INT NOT NULL DEFAULT '0',
					// `category` INT NOT NULL DEFAULT '0',
					// `chance` INT NOT NULL DEFAULT '0',

					// (18001,1806,1,1,-1,10868),-- Recipe: Soulshot: B-Grade
					// (18001,57,765,1528,0,700000),-- Adena
					// (18001,4069,1,1,1,2102),-- Tunic of Zubei Fabric
					// (18001,4070,1,1,1,3192),-- Stockings of Zubei Fabric
					// (18001,4071,1,1,1,1615),-- Avadon Robe Fabric
					// (18001,1419,1,1,2,200000),-- Blood Mark
					// (18001,1864,1,1,2,166667),-- Stem

					sTemp = sTemp.Substring(Strings.InStr(sTemp, "("), Strings.InStr(sTemp, ")") - Strings.InStr(sTemp, "(") - 1);
					sTemp = sTemp.Replace("'", "");
					aTemp = sTemp.Split(Conversions.ToChar(","));

					// 0     1    2 3 4 5
					// (18001,4069,1,1,1,2102),-- Tunic of Zubei Fabric

					sCurNpcName = aTemp[0];
					if (Conversions.ToInteger(aTemp[1]) > 25000)
					{
						MessageBox.Show("Wrong item_id [" + aTemp[0] + "] in line" + Constants.vbNewLine + sTemp);
						inSpawnFile.Close();
						outFile.Close();
						ToolStripProgressBar.Value = 0;
						return;
					}

					if (sPrevNpcName == null)
						sPrevNpcName = sCurNpcName;
					if ((sCurNpcName ?? "") != (sPrevNpcName ?? ""))
					{

						// Checking exising npc in NpcPch
						if (aNpcPch[Conversions.ToInteger(sPrevNpcName)] == null)
						{
							if (Array.IndexOf(aNpcMiss, sPrevNpcName) == -1)
							{
								aNpcMiss[aNpcMiss.Length - 1] = Conversions.ToInteger(sPrevNpcName);
								Array.Resize(ref aNpcMiss, aNpcMiss.Length + 1);
							}

							sTempNpcName = "[_need_" + sPrevNpcName + "_]";
						}
						else
							sTempNpcName = aNpcPch[Conversions.ToInteger(sPrevNpcName)];

						// Start writing npc
						// npc_begin	warrior	20761	[pytan]
						outFile.Write("npc_begin" + Conversions.ToString((char)9) + "warrior" + Conversions.ToString((char)9) + sPrevNpcName + Conversions.ToString((char)9) + sTempNpcName + Conversions.ToString((char)9));

						for (int iTemp = 0, loopTo1 = iNpcCount - 1; iTemp <= loopTo1; iTemp++)
						{

							// sTempItemName
							// Checking exising Items in ItemPch
							if (aItemPch[aItemList[iTemp].itemId] == null)
							{
								if (Array.IndexOf(aItemMiss, aItemList[iTemp].itemId) == -1)
								{
									aItemMiss[aItemMiss.Length - 1] = aItemList[iTemp].itemId;
									Array.Resize(ref aItemMiss, aItemMiss.Length + 1);
								}
								sTempItemName = "[_need_" + Conversions.ToString(Conversions.ToInteger(aItemList[iTemp].itemId)) + "_]";
							}
							else
								sTempItemName = aItemPch[aItemList[iTemp].itemId];

							// corpse_make_list={
							// {[rp_soulshot_a];1;1;0.9041};{[oriharukon_ore];1;1;45.2069};{[stone_of_purity];1;1;45.2069}  }	

							if (aItemList[iTemp].category == -1)
							{
								if (aItemCategory[255] != null)
									aItemCategory[255] = aItemCategory[255] + ";";
								aItemCategory[255] = aItemCategory[255] + "{" + sTempItemName + ";" + Conversions.ToString(aItemList[iTemp].min) + ";" + Conversions.ToString(aItemList[iTemp].max) + ";" + Conversions.ToString(aItemList[iTemp].chance) + "}";
							}
							else
							{
								if (aItemCategory[aItemList[iTemp].category] != null)
									aItemCategory[aItemList[iTemp].category] = aItemCategory[aItemList[iTemp].category] + ";";
								aItemCategory[aItemList[iTemp].category] = aItemCategory[aItemList[iTemp].category] + "{" + sTempItemName + ";" + Conversions.ToString(aItemList[iTemp].min) + ";" + Conversions.ToString(aItemList[iTemp].max) + ";" + Conversions.ToString(aItemList[iTemp].chance) + "}";
							}
						}

						outFile.Write("corpse_make_list={" + aItemCategory[255] + "}");
						outFile.Write(Conversions.ToString((char)9) + "additional_make_multi_list={");
						for (iNpcCount = 0; iNpcCount <= 254; iNpcCount++)
						{
							if (aItemCategory[iNpcCount] != null)
							{
								if (bItemCategory == true)
									outFile.Write(";");
								outFile.Write("{{" + aItemCategory[iNpcCount] + "};100}");
								bItemCategory = true;
							}
						}
						bItemCategory = false;
						outFile.Write("}" + Conversions.ToString((char)9));
						outFile.WriteLine("npc_end");

						iNpcCount = 0;
						Array.Clear(aItemList, 0, aItemList.Length);
						Array.Resize(ref aItemList, 1);

						Array.Clear(aItemCategory, 0, aItemCategory.Length);

						// sCurNpcName = sPrevNpcName
						// sTempDropSpoil = ""
						// sTempDropItems = ""
						sPrevNpcName = sCurNpcName;
					}

					// ADD new Drop Items to Array
					Array.Resize(ref aItemList, iNpcCount + 1);

					// 0     1    2 3 4 5
					// (18001,4069,1,1,1,2102),-- Tunic of Zubei Fabric

					aItemList[iNpcCount].itemId = Conversions.ToInteger(aTemp[1]);
					aItemList[iNpcCount].min = Conversions.ToInteger(aTemp[2]);
					aItemList[iNpcCount].max = Conversions.ToInteger(aTemp[3]);
					aItemList[iNpcCount].category = Conversions.ToInteger(aTemp[4]);
					aItemList[iNpcCount].chance = Conversions.ToInteger(aTemp[5]) / (double)10000;

					iNpcCount = iNpcCount + 1;
				}
			}
			ToolStripProgressBar.Value = 0;
			inSpawnFile.Close();
			outFile.Close();

			if (aNpcMiss.Length > 0)
			{
				outFile = new System.IO.StreamWriter("npcdata_drop_l2j.log", false, System.Text.Encoding.Unicode, 1);
				outFile.WriteLine("Missed Npc. Required for NpcData drop:");
				var loopTo2 = aNpcMiss.Length - 2;
				for (iNpcCount = 0; iNpcCount <= loopTo2; iNpcCount++)
					outFile.WriteLine("npc_id=" + Conversions.ToString(aNpcMiss[iNpcCount]));
				outFile.Close();
			}
			if (aItemMiss.Length > 0)
			{
				outFile = new System.IO.StreamWriter("npcdata_drop_l2j.log", true, System.Text.Encoding.Unicode, 1);
				outFile.WriteLine("Missed Items. Required for NpcData drop:");
				var loopTo3 = aItemMiss.Length - 2;
				for (iNpcCount = 0; iNpcCount <= loopTo3; iNpcCount++)
					outFile.WriteLine("item_id=" + Conversions.ToString(aItemMiss[iNpcCount]));
				outFile.Close();
			}


			MessageBox.Show("Completed. With [" + Conversions.ToString(aItemMiss.Length - 1) + "] missed item's [" + Conversions.ToString(aNpcMiss.Length - 1) + "] missed npc's.");
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}


		private void OldButtonStart()
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

			// LOADING item_pch.txt
			if (System.IO.File.Exists("item_pch.txt") == false)
			{
				MessageBox.Show("item_pch.txt not found", "Need item_pch.txt", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var aItemPch = new string[25001];
			inSpawnFile = new System.IO.StreamReader("item_pch.txt", System.Text.Encoding.Default, true, 1);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inSpawnFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading item_pch.txt ...";

			while (inSpawnFile.EndOfStream != true)
			{
				sTemp = inSpawnFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inSpawnFile.BaseStream.Position);
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{

					// [small_sword] = 1
					sTemp = sTemp.Replace(" ", "").Replace(Conversions.ToString((char)9), "");
					aTemp = sTemp.Split(Conversions.ToChar("="));
					try
					{
						aItemPch[Conversions.ToInteger(aTemp[1])] = aTemp[0];
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error in loading item_pch.txt. Last reading line:" + Constants.vbNewLine + sTemp);
						inSpawnFile.Close();
						return;
					}
				}
			}
			inSpawnFile.Close();
			ToolStripProgressBar.Value = 0;

			OpenFileDialog.Filter = "L2J NpcData Drop (droplist.sql)|droplist.sql|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sSpawnListFile = OpenFileDialog.FileName;
			inSpawnFile = new System.IO.StreamReader(sSpawnListFile, System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter("npcdata_drop_l2j.txt", false, System.Text.Encoding.Unicode, 1);

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inSpawnFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading droplist.sql...";

			int iNpcCount = 0;
			string sCurNpcName = "";
			string sPrevNpcName = null;
			string sTempNpcName;
			string sTempItemName;
			// Dim sTempDropSpoil As String, sTempDropItems As String
			bool bItemCategory = false;

			var aItemList = new DropList[1];
			var aItemCategory = new string[256];
			var aItemMiss = new int[1];
			var aNpcMiss = new int[1];

			while (inSpawnFile.EndOfStream != true)
			{
				sTemp = inSpawnFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inSpawnFile.BaseStream.Position);
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("(") == true)
				{

					// ---------- Prepare for importing
					// `mobId` INT NOT NULL DEFAULT '0',
					// `itemId` INT NOT NULL DEFAULT '0',
					// `min` INT NOT NULL DEFAULT '0',
					// `max` INT NOT NULL DEFAULT '0',
					// `category` INT NOT NULL DEFAULT '0',
					// `chance` INT NOT NULL DEFAULT '0',

					// (18001,1806,1,1,-1,10868),-- Recipe: Soulshot: B-Grade
					// (18001,57,765,1528,0,700000),-- Adena
					// (18001,4069,1,1,1,2102),-- Tunic of Zubei Fabric
					// (18001,4070,1,1,1,3192),-- Stockings of Zubei Fabric
					// (18001,4071,1,1,1,1615),-- Avadon Robe Fabric
					// (18001,1419,1,1,2,200000),-- Blood Mark
					// (18001,1864,1,1,2,166667),-- Stem

					sTemp = sTemp.Substring(Strings.InStr(sTemp, "("), Strings.InStr(sTemp, ")") - Strings.InStr(sTemp, "(") - 1);
					sTemp = sTemp.Replace("'", "");
					aTemp = sTemp.Split(Conversions.ToChar(","));

					// 0     1    2 3 4 5
					// (18001,4069,1,1,1,2102),-- Tunic of Zubei Fabric

					sCurNpcName = aTemp[0];
					if (Conversions.ToInteger(aTemp[1]) > 25000)
					{
						MessageBox.Show("Wrong item_id [" + aTemp[0] + "] in line" + Constants.vbNewLine + sTemp);
						inSpawnFile.Close();
						outFile.Close();
						ToolStripProgressBar.Value = 0;
						return;
					}

					if (sPrevNpcName == null)
						sPrevNpcName = sCurNpcName;
					if ((sCurNpcName ?? "") != (sPrevNpcName ?? ""))
					{

						// Checking exising npc in NpcPch
						if (aNpcPch[Conversions.ToInteger(sPrevNpcName)] == null)
						{
							if (Array.IndexOf(aNpcMiss, sPrevNpcName) == -1)
							{
								aNpcMiss[aNpcMiss.Length - 1] = Conversions.ToInteger(sPrevNpcName);
								Array.Resize(ref aNpcMiss, aNpcMiss.Length + 1);
							}

							sTempNpcName = "[_need_" + sPrevNpcName + "_]";
						}
						else
							sTempNpcName = aNpcPch[Conversions.ToInteger(sPrevNpcName)];

						// Start writing npc
						// npc_begin	warrior	20761	[pytan]
						outFile.Write("npc_begin" + Conversions.ToString((char)9) + "warrior" + Conversions.ToString((char)9) + sPrevNpcName + Conversions.ToString((char)9) + sTempNpcName + Conversions.ToString((char)9));

						for (int iTemp = 0, loopTo = iNpcCount - 1; iTemp <= loopTo; iTemp++)
						{

							// sTempItemName
							// Checking exising Items in ItemPch
							if (aItemPch[aItemList[iTemp].itemId] == null)
							{
								if (Array.IndexOf(aItemMiss, aItemList[iTemp].itemId) == -1)
								{
									aItemMiss[aItemMiss.Length - 1] = aItemList[iNpcCount].itemId;
									Array.Resize(ref aItemMiss, aItemMiss.Length + 1);
								}
								sTempItemName = "[_need_" + Conversions.ToString(Conversions.ToInteger(aItemList[iTemp].itemId)) + "_]";
							}
							else
								sTempItemName = aItemPch[aItemList[iTemp].itemId];

							// corpse_make_list={
							// {[rp_soulshot_a];1;1;0.9041};{[oriharukon_ore];1;1;45.2069};{[stone_of_purity];1;1;45.2069}  }	

							if (aItemList[iTemp].category == -1)
							{
								if (aItemCategory[255] != null)
									aItemCategory[255] = aItemCategory[255] + ";";
								aItemCategory[255] = aItemCategory[255] + "{" + sTempItemName + ";" + Conversions.ToString(aItemList[iTemp].min) + ";" + Conversions.ToString(aItemList[iTemp].max) + ";" + Conversions.ToString(aItemList[iTemp].chance) + "}";
							}
							else
							{
								if (aItemCategory[aItemList[iTemp].category] != null)
									aItemCategory[aItemList[iTemp].category] = aItemCategory[aItemList[iTemp].category] + ";";
								aItemCategory[aItemList[iTemp].category] = aItemCategory[aItemList[iTemp].category] + "{" + sTempItemName + ";" + Conversions.ToString(aItemList[iTemp].min) + ";" + Conversions.ToString(aItemList[iTemp].max) + ";" + Conversions.ToString(aItemList[iTemp].chance) + "}";
							}
						}

						outFile.Write("corpse_make_list={" + aItemCategory[255] + "}");
						outFile.Write(Conversions.ToString((char)9) + "additional_make_multi_list={");
						for (iNpcCount = 0; iNpcCount <= 254; iNpcCount++)
						{
							if (aItemCategory[iNpcCount] != null)
							{
								if (bItemCategory == true)
									outFile.Write(";");
								outFile.Write("{{" + aItemCategory[iNpcCount] + "};100}");
								bItemCategory = true;
							}
						}
						bItemCategory = false;
						outFile.Write("}" + Conversions.ToString((char)9));
						outFile.WriteLine("npc_end");

						iNpcCount = 0;
						Array.Clear(aItemList, 0, aItemList.Length);
						Array.Resize(ref aItemList, 1);

						Array.Clear(aItemCategory, 0, aItemCategory.Length);

						// sCurNpcName = sPrevNpcName
						// sTempDropSpoil = ""
						// sTempDropItems = ""
						sPrevNpcName = sCurNpcName;
					}

					// ADD new Drop Items to Array
					Array.Resize(ref aItemList, iNpcCount + 1);

					// 0     1    2 3 4 5
					// (18001,4069,1,1,1,2102),-- Tunic of Zubei Fabric

					aItemList[iNpcCount].itemId = Conversions.ToInteger(aTemp[1]);
					aItemList[iNpcCount].min = Conversions.ToInteger(aTemp[2]);
					aItemList[iNpcCount].max = Conversions.ToInteger(aTemp[3]);
					aItemList[iNpcCount].category = Conversions.ToInteger(aTemp[4]);
					aItemList[iNpcCount].chance = Conversions.ToInteger(Conversions.ToDouble(aTemp[5]) / 10000);

					iNpcCount = iNpcCount + 1;
				}
			}
			ToolStripProgressBar.Value = 0;
			inSpawnFile.Close();
			outFile.Close();

			if (aNpcMiss.Length > 0)
			{
				outFile = new System.IO.StreamWriter("npcdata_drop_l2j.log", false, System.Text.Encoding.Unicode, 1);
				outFile.WriteLine("Missed Npc. Required for NpcData drop:");
				var loopTo1 = aNpcMiss.Length - 2;
				for (iNpcCount = 0; iNpcCount <= loopTo1; iNpcCount++)
					outFile.WriteLine("npc_id=" + Conversions.ToString(aNpcMiss[iNpcCount]));
				outFile.Close();
			}
			if (aItemMiss.Length > 0)
			{
				outFile = new System.IO.StreamWriter("npcdata_drop_l2j.log", true, System.Text.Encoding.Unicode, 1);
				outFile.WriteLine("Missed Items. Required for NpcData drop:");
				var loopTo2 = aItemMiss.Length - 2;
				for (iNpcCount = 0; iNpcCount <= loopTo2; iNpcCount++)
					outFile.WriteLine("item_id=" + Conversions.ToString(aItemMiss[iNpcCount]));
				outFile.Close();
			}


			MessageBox.Show("Completed. With [" + Conversions.ToString(aItemMiss.Length - 1) + "] missed item's [" + Conversions.ToString(aNpcMiss.Length - 1) + "] missed npc's.");
		}

		private void RadioButtonRateChanceOnly_CheckedChanged(object sender, EventArgs e)
		{
			TextBoxRateDropRB.Enabled = true;
		}

		private void RadioButtonIgnoreDropNpc_CheckedChanged(object sender, EventArgs e)
		{
			TextBoxRateDropRB.Enabled = false;
		}
	}
}
