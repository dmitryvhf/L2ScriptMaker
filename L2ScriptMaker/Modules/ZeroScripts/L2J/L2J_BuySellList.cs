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
	public partial class L2J_BuySellList : Form
	{
		public L2J_BuySellList()
		{
			InitializeComponent();
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
						aNpcPch[Conversions.ToInteger(aTemp[1]) - 1000000] = aTemp[0].Replace("[", "").Replace("]", "");
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
						aItemPch[Conversions.ToInteger(aTemp[1])] = aTemp[0].Replace("[", "").Replace("]", "");
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

			// LOADING merchant_shopids.sql
			if (System.IO.File.Exists("merchant_shopids.sql") == false)
			{
				MessageBox.Show("merchant_shopids.sql not found", "Need merchant_shopids.sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var aShopId = new string[1001];
			var aShopNpc = new string[1001];
			inSpawnFile = new System.IO.StreamReader("merchant_shopids.sql", System.Text.Encoding.Default, true, 1);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inSpawnFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading merchant_shopids.sql ...";
			int iTempCount = 0;

			while (inSpawnFile.EndOfStream != true)
			{
				sTemp = inSpawnFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inSpawnFile.BaseStream.Position);
				if (sTemp.StartsWith("(") == true)
				{

					// (3000100,'30001'),
					// (9029,'gm'),
					sTemp = sTemp.Substring(Strings.InStr(sTemp, "("), Strings.InStr(sTemp, ")") - Strings.InStr(sTemp, "(") - 1);
					sTemp = sTemp.Replace("'", "");
					aTemp = sTemp.Split(Conversions.ToChar(","));

					Array.Resize(ref aShopId, iTempCount + 1);
					Array.Resize(ref aShopNpc, iTempCount + 1);
					aShopId[iTempCount] = aTemp[0];
					aShopNpc[iTempCount] = aTemp[1].Replace("'", "").Trim();
					iTempCount = iTempCount + 1;
				}
			}
			inSpawnFile.Close();
			ToolStripProgressBar.Value = 0;


			// -----------------

			OpenFileDialog.Filter = "L2J AI.obj BuySell List config (merchant_buylists.sql)|merchant_buylists.sql|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sSpawnListFile = OpenFileDialog.FileName;
			inSpawnFile = new System.IO.StreamReader(sSpawnListFile, System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter("ai_buysell_list_l2j.txt", false, System.Text.Encoding.Unicode, 1);

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inSpawnFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading merchant_buylists.sql...";

			int iNpcCount = 0;
			string sCurNpcName = "";
			string sPrevNpcName = "";
			string sCurShopId = "";
			string sPrevShopId = "";
			string sItemPch = "";
			string sTempItemName;
			string sTempNpcName;

			var aItemMiss = new int[1];
			var aNpcMiss = new int[1];

			while (inSpawnFile.EndOfStream != true)
			{
				sTemp = inSpawnFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inSpawnFile.BaseStream.Position);
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("(") == true)
				{
					sTemp = sTemp.Substring(Strings.InStr(sTemp, "("), Strings.InStr(sTemp, ")") - Strings.InStr(sTemp, "(") - 1);
					sTemp = sTemp.Replace("'", "");
					aTemp = sTemp.Split(Conversions.ToChar(","));

					// 0           1        2       3
					// `item_id`,`price`,`shop_id`,`order`
					// (1835,      -1,    13128001,  0),

					// class 1 asamah : citizen
					// property_define_begin
					// buyselllist_begin SellList0
					// {8764; 35; 0.000000; 0 }
					// {8763; 35; 0.000000; 0 }
					// buyselllist_end
					// buyselllist_begin SellList1
					// {8764; 35; 0.000000; 0 }
					// {8763; 35; 0.000000; 0 }
					// buyselllist_end
					// property_define_end
					// handler 4 1362  //  TALK_SELECTED

					// class asamah : citizen
					// {
					// property:
					// BuySellList SellList0 = {
					// {"trap_stone"; 35; 0.000000; 0};
					// {"elrokian_trap"; 35; 0.000000; 0}
					// };
					// handler:
					// EventHandler TALK_SELECTED(talker)

					if (Array.IndexOf(aShopId, aTemp[2]) == -1)
						sTempNpcName = "";
					else
					{
						sTempNpcName = aShopNpc[Array.IndexOf(aShopId, aTemp[2])];
						if ((sTempNpcName ?? "") == "gm")
							sTempNpcName = "";
					}
					sItemPch = aTemp[0];
					sCurShopId = aTemp[2];

					if (!string.IsNullOrEmpty(sTempNpcName))
					{
						// Checking exising npc in NpcPch
						if (aNpcPch[Conversions.ToInteger(sTempNpcName)] == null)
						{
							if (Array.IndexOf(aNpcMiss, sTempNpcName) == -1)
							{
								aNpcMiss[aNpcMiss.Length - 1] = Conversions.ToInteger(sTempNpcName);
								Array.Resize(ref aNpcMiss, aNpcMiss.Length + 1);
							}

							sCurNpcName = "[_need_" + sTempNpcName + "_]";
						}
						else
							sCurNpcName = aNpcPch[Conversions.ToInteger(sTempNpcName)];
						if ((sPrevNpcName ?? "") != (sCurNpcName ?? ""))
						{
							if (!string.IsNullOrEmpty(sPrevNpcName))
								outFile.WriteLine(Constants.vbNewLine + Constants.vbTab + "};");
							outFile.WriteLine("class " + sCurNpcName + Constants.vbTab + "// " + sTempNpcName);
							sPrevNpcName = sCurNpcName;
							sPrevShopId = "";
						}
						if ((sCurShopId ?? "") != (sPrevShopId ?? ""))
						{
							// BuySellList SellList1 = {
							if (!string.IsNullOrEmpty(sPrevShopId))
								outFile.WriteLine(Constants.vbNewLine + Constants.vbTab + "};");
							outFile.WriteLine(Constants.vbTab + "BuySellList SellList" + sCurShopId + " = {");
							sPrevShopId = sCurShopId;
						}
						else
							outFile.WriteLine(";");

						if (aItemPch[Conversions.ToInteger(sItemPch)] == null)
						{
							if (Array.IndexOf(aItemMiss, Conversions.ToInteger(sItemPch)) == -1)
							{
								aItemMiss[aItemMiss.Length - 1] = Conversions.ToInteger(sItemPch);
								Array.Resize(ref aItemMiss, aItemMiss.Length + 1);
							}
							sTempItemName = "[_need_" + Conversions.ToString(Conversions.ToInteger(Conversions.ToInteger(sItemPch))) + "_]";
						}
						else
							sTempItemName = aItemPch[Conversions.ToInteger(sItemPch)];
						if (Conversions.ToInteger(sItemPch) > 25000)
						{
							MessageBox.Show("Wrong item_id [" + sItemPch + "] in line" + Constants.vbNewLine + sTemp);
							inSpawnFile.Close();
							outFile.Close();
							ToolStripProgressBar.Value = 0;
							return;
						}

						outFile.Write(Constants.vbTab + Constants.vbTab + "{\"" + sTempItemName + "\"; 15; 0.000000; 0 }");
					}
				}
			}
			ToolStripProgressBar.Value = 0;
			inSpawnFile.Close();
			outFile.Close();

			if (aNpcMiss.Length > 0)
			{
				outFile = new System.IO.StreamWriter("npcdata_drop_l2j.log", false, System.Text.Encoding.Unicode, 1);
				outFile.WriteLine("Missed Npc. Required for NpcData drop:");
				var loopTo = aNpcMiss.Length - 2;
				for (iNpcCount = 0; iNpcCount <= loopTo; iNpcCount++)
					outFile.WriteLine("npc_id=" + Conversions.ToString(aNpcMiss[iNpcCount]));
				outFile.Close();
			}
			if (aItemMiss.Length > 0)
			{
				outFile = new System.IO.StreamWriter("npcdata_drop_l2j.log", true, System.Text.Encoding.Unicode, 1);
				outFile.WriteLine("Missed Items. Required for NpcData drop:");
				var loopTo1 = aItemMiss.Length - 2;
				for (iNpcCount = 0; iNpcCount <= loopTo1; iNpcCount++)
					outFile.WriteLine("item_id=" + Conversions.ToString(aItemMiss[iNpcCount]));
				outFile.Close();
			}

			MessageBox.Show("Completed. With [" + Conversions.ToString(aItemMiss.Length - 1) + "] missed item's [" + Conversions.ToString(aNpcMiss.Length - 1) + "] missed npc's.");
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
