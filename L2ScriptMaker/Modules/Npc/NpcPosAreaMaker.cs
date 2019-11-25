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
	public partial class NpcPosAreaMaker : Form
	{
		public NpcPosAreaMaker()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			NpcX.Text = "0";
			NpcY.Text = "0";
			NpcZ.Text = "0";
			ZoneRadius.Text = "100";
			TotalNpc.Text = "1";
			HeightZ.Text = "300";
			RespawnTime.Text = "1";
			RespawnClass.Text = "min";
			LookDirect.Text = "North";
			ImportPosText.Text = "";
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			int Pos;
			int NpcCount;
			var TempX = default(int);
			var TempY = default(int);
			var MinTempX = default(int);
			var MinTempY = default(int);
			var MaxTempX = default(int);
			var MaxTempY = default(int);
			var MinTempZ = default(int);
			var MaxTempZ = default(int);
			string LookDir = "";
			int TempInstr1;

			// Dim dc As DataGridCell
			// dc.RowNumber = 1
			// dc.ColumnNumber = 1
			// DataGrid.Item(1, 1).Value = ""
			// DataGrid.Rows.Count

			int TempInstr2;
			NpcCount = 0;

			if (AutoClearBox.Checked == true | OneZone.Checked == true)
				TextBoxFinal.Text = "";

			ImportPosText.Text = Strings.Replace(ImportPosText.Text, " = ", "=");
			if (CycleImport.Checked == true)
			{
				ImportPosText.Text = Strings.Replace(ImportPosText.Text, "\t", " ");
				// tabs and spaces correction
				while (Strings.InStr(ImportPosText.Text, "  ") != 0)
					ImportPosText.Text = Strings.Replace(ImportPosText.Text, "  ", " ");
			}

			TempInstr2 = 1;

		cycleDo:
			;
			if (CycleImport.Checked == true && Strings.InStr(TempInstr2, ImportPosText.Text, "npc_begin") != 0)
			{
				if (Strings.InStr(1, ImportPosText.Text, "npc_begin") == 0)
					return;

				TempInstr1 = Strings.InStr(TempInstr2, ImportPosText.Text, "[");
				TempInstr2 = Strings.InStr(TempInstr1, ImportPosText.Text, "]");

				NpcName.Text = Strings.Mid(ImportPosText.Text, TempInstr1 + 1, TempInstr2 - TempInstr1 - 1);

				TotalNpc.Text = GetNeedParamFromStr(ImportPosText.Text, "total");

				RespawnTime.Text = GetNeedParamFromStr(Strings.Mid(ImportPosText.Text, TempInstr1), "respawn");
				if (Strings.InStr(RespawnTime.Text, "sec") != 0)
				{
					RespawnClass.Text = "sec"; RespawnTime.Text = Strings.Replace(RespawnTime.Text, "sec", "");
				}
				if (Strings.InStr(RespawnTime.Text, "min") != 0)
				{
					RespawnClass.Text = "min"; RespawnTime.Text = Strings.Replace(RespawnTime.Text, "min", "");
				}
				if (Strings.InStr(RespawnTime.Text, "hour") != 0)
				{
					RespawnClass.Text = "hour"; RespawnTime.Text = Strings.Replace(RespawnTime.Text, "hour", "");
				}

				TempInstr1 = Strings.InStr(TempInstr2, ImportPosText.Text, "pos={") + 5;
				TempInstr2 = Strings.InStr(TempInstr1, ImportPosText.Text, ";");
				NpcX.Text = Strings.Mid(ImportPosText.Text, TempInstr1, TempInstr2 - TempInstr1);

				TempInstr1 = TempInstr2 + 1;
				TempInstr2 = Strings.InStr(TempInstr1, ImportPosText.Text, ";");
				NpcY.Text = Strings.Mid(ImportPosText.Text, TempInstr1, TempInstr2 - TempInstr1);

				TempInstr1 = TempInstr2 + 1;
				TempInstr2 = Strings.InStr(TempInstr1, ImportPosText.Text, ";");
				NpcZ.Text = Strings.Mid(ImportPosText.Text, TempInstr1, TempInstr2 - TempInstr1);

				TempInstr1 = TempInstr2 + 1;
				TempInstr2 = Strings.InStr(TempInstr1, ImportPosText.Text, "}");
				LookDirect.Text = Strings.Mid(ImportPosText.Text, TempInstr1, TempInstr2 - TempInstr1);

				if (NpcCount == 0)
				{
					MinTempX = Conversions.ToInteger(NpcX.Text);
					MinTempY = Conversions.ToInteger(NpcY.Text);
					MinTempZ = Conversions.ToInteger(NpcZ.Text);
					MaxTempX = Conversions.ToInteger(NpcX.Text);
					MaxTempY = Conversions.ToInteger(NpcY.Text);
					MaxTempZ = Conversions.ToInteger(NpcZ.Text);
				}
			}

			switch (LookDirect.Text)
			{
				case "North":
					{
						LookDir = "49152";
						break;
					}

				case "East":
					{
						LookDir = "0";
						break;
					}

				case "South":
					{
						LookDir = "16384";
						break;
					}

				case "West":
					{
						LookDir = "32768";
						break;
					}

				default:
					{
						LookDir = LookDirect.Text;
						break;
					}
			}


			// If AutoClearBox.Checked = True And CycleImport.Checked = False Then TextBoxFinal.Text = ""

			// territory_begin	[20_22_NPC_031130_01]	{{19900;146109;-3224;-3024};{20100;146109;-3224;-3024};{20100;146309;-3224;-3024};{19900;146309;-3224;-3024}}	territory_end
			if (CycleImport.Checked == true)
			{
				if (OneZone.Checked == true)
				{
				}
				else
					TextBoxFinal.Text += "territory_begin" + "\t" + "[" + NpcName.Text + "_auto_gen_zone" + "]" + "\t" + "{";
			}
			else
				TextBoxFinal.Text += "territory_begin" + "\t" + "[" + ZoneName.Text + "]" + "\t" + "{";

			for (Pos = 1; Pos <= 4; Pos++)
			{
				if (OneZone.Checked == false)
				{
					if (Pos > 1)
						TextBoxFinal.Text += ";";
				}
				switch (Pos)
				{
					case 1:
						{
							TempX = Conversions.ToInteger(NpcX.Text) - Conversions.ToInteger(ZoneRadius.Text);
							TempY = Conversions.ToInteger(NpcY.Text) - Conversions.ToInteger(ZoneRadius.Text);
							if (MinTempX > TempX)
								MinTempX = TempX;
							if (MinTempY > TempY)
								MinTempY = TempY;
							break;
						}

					case 2:
						{
							TempX = Conversions.ToInteger(NpcX.Text) + Conversions.ToInteger(ZoneRadius.Text);
							TempY = Conversions.ToInteger(NpcY.Text) - Conversions.ToInteger(ZoneRadius.Text);
							if (MaxTempX < TempX)
								MaxTempX = TempX;
							if (MinTempY > TempY)
								MinTempY = TempY;
							break;
						}

					case 3:
						{
							TempX = Conversions.ToInteger(NpcX.Text) + Conversions.ToInteger(ZoneRadius.Text);
							TempY = Conversions.ToInteger(NpcY.Text) + Conversions.ToInteger(ZoneRadius.Text);
							if (MaxTempX < TempX)
								MaxTempX = TempX;
							if (MaxTempY < TempY)
								MaxTempY = TempY;
							break;
						}

					case 4:
						{
							TempX = Conversions.ToInteger(NpcX.Text) - Conversions.ToInteger(ZoneRadius.Text);
							TempY = Conversions.ToInteger(NpcY.Text) + Conversions.ToInteger(ZoneRadius.Text);
							if (MinTempX > TempX)
								MinTempX = TempX;
							if (MaxTempY < TempY)
								MaxTempY = TempY;
							break;
						}
				}
				if (OneZone.Checked == false)
					TextBoxFinal.Text += "{" + TempX.ToString() + ";" + TempY.ToString() + ";" + (Conversions.ToInteger(NpcZ.Text) - 20).ToString() + ";" + (Conversions.ToInteger(NpcZ.Text) + Conversions.ToInteger(HeightZ.Text)).ToString() + "}";
			}

			if (OneZone.Checked == false)
				TextBoxFinal.Text += "}" + "\t" + "territory_end" + "\r\n";

			// npcmaker_begin	[20_22_NPC_031130_01]	initial_spawn = all	maximum_npc = 1

			if (CycleImport.Checked == true)
			{
				if (OneZone.Checked == true)
					NpcCount += 1;
				else
					TextBoxFinal.Text += "npcmaker_begin" + "\t" + "[" + NpcName.Text + "_auto_gen_zone]" + "\t" + "initial_spawn=all" + "\t" + "maximum_npc=1" + "\r\n";
			}
			else
				TextBoxFinal.Text += "npcmaker_begin" + "\t" + "[" + ZoneName.Text + "]" + "\t" + "initial_spawn=all" + "\t" + "maximum_npc=1" + "\r\n";

			string PrivText = "";
			if (PrivChkBox.Checked == true)
			{

				// make Privates pos
				int TempVal;
				PrivText += "Privates=[";

				if (Conversions.ToInteger(Priv1Quantity.Text) > 0)
				{
					var loopTo = Conversions.ToInteger(Priv1Quantity.Text);
					for (TempVal = 1; TempVal <= loopTo; TempVal++)
					{
						PrivText += Priv1Name.Text + ":" + Priv1Ai.Text + ":" + "1:" + PrivRespawn.Text + PrivRespawnTime.Text;
						if (TempVal != Conversions.ToInteger(Priv1Quantity.Text))
							PrivText += ";";
					}
				}
				if (Conversions.ToInteger(Priv2Quantity.Text) > 0)
				{
					PrivText += ";";
					var loopTo1 = Conversions.ToInteger(Priv2Quantity.Text);
					for (TempVal = 1; TempVal <= loopTo1; TempVal++)
					{
						PrivText += Priv2Name.Text + ":" + Priv2Ai.Text + ":" + "1:" + PrivRespawn.Text + PrivRespawnTime.Text;
						if (TempVal != Conversions.ToInteger(Priv2Quantity.Text))
							PrivText += ";";
					}
				}

				PrivText += "]" + "\t";
			}

			// npc_begin	[seth]	pos = {19996;146216;-3111;57344}	total=1	respawn = 1min	npc_end
			TextBoxFinal.Text += "npc_begin" + "\t" + "[" + NpcName.Text.ToLower() + "]" + "\t" + "pos={" + NpcX.Text + ";" + NpcY.Text + ";" + NpcZ.Text + ";" + LookDir + "}" + "\t" + "total=" + TotalNpc.Text + "\t" + "respawn=" + RespawnTime.Text + RespawnClass.Text + "\t" + PrivText + "npc_end" + "\r\n";

			if (MinTempZ > Conversions.ToInteger(NpcZ.Text))
				MinTempZ = Conversions.ToInteger(NpcZ.Text);
			if (MaxTempZ < Conversions.ToInteger(NpcZ.Text))
				MaxTempZ = Conversions.ToInteger(NpcZ.Text);

			// npcmaker_end
			// If OneZone.Checked = False Then TextBoxFinal.Text += "npcmaker_end"

			if (CycleImport.Checked == true)
			{
				if (Strings.InStr(TempInstr2, ImportPosText.Text, "npc_begin") != 0)
				{
					if (OneZone.Checked == false)
						TextBoxFinal.Text += "npcmaker_end" + "\r\n";
					goto cycleDo;
				}
				else
				{
					TextBoxFinal.Text += "npcmaker_end";
					if (OneZone.Checked == true)
					{
						// TextBoxFinal.Text += "npcmaker_end"
						string ZoneDefine;
						ZoneDefine = "{" + MinTempX.ToString() + ";" + MinTempY.ToString() + ";" + (MinTempZ - 20).ToString() + ";" + (MaxTempZ + Conversions.ToInteger(HeightZ.Text)).ToString() + "}";
						ZoneDefine += ";{" + MaxTempX.ToString() + ";" + MinTempY.ToString() + ";" + (MinTempZ - 20).ToString() + ";" + (MaxTempZ + Conversions.ToInteger(HeightZ.Text)).ToString() + "}";
						ZoneDefine += ";{" + MaxTempX.ToString() + ";" + MaxTempY.ToString() + ";" + (MinTempZ - 20).ToString() + ";" + (MaxTempZ + Conversions.ToInteger(HeightZ.Text)).ToString() + "}";
						ZoneDefine += ";{" + MinTempX.ToString() + ";" + MaxTempY.ToString() + ";" + (MinTempZ - 20).ToString() + ";" + (MaxTempZ + Conversions.ToInteger(HeightZ.Text)).ToString() + "}";

						TextBoxFinal.Text = "npcmaker_begin" + "\t" + "[" + ZoneName.Text + "]" + "\t" + "initial_spawn=all" + "\t" + "maximum_npc=" + Conversions.ToString(NpcCount) + "\r\n" + TextBoxFinal.Text;
						TextBoxFinal.Text = "territory_begin" + "\t" + "[" + ZoneName.Text + "]" + "\t" + "{" + ZoneDefine + "}" + "\t" + "territory_end" + "\r\n" + TextBoxFinal.Text;
					}
					return;
				}
			}
			else
			{
				// If OneZone.Checked = True Then
				TextBoxFinal.Text += "npcmaker_end";
				return;
			}

			return;
		}

		private void ButtonClear_Click(object sender, EventArgs e)
		{
			TextBoxFinal.Text = "";
		}

		public string GetNeedParamFromStr(string SourceStr, string MaskStr)
		{
			string GetNeedParamFromStrRet = default(string);

			// Update 15.01.2007 00:05

			int FirstPos, SecondPos;
			GetNeedParamFromStrRet = "";

			// PreWorking string
			SourceStr = SourceStr.Replace("\t", " ");
			SourceStr = SourceStr.Replace(" = ", "=");
			while (Strings.InStr(SourceStr, "  ") > 0)
				SourceStr = SourceStr.Replace("  ", " ");

			FirstPos = Strings.InStr(1, SourceStr, MaskStr + "=");
			if (FirstPos == default(int))
			{
				GetNeedParamFromStrRet = "";
				return GetNeedParamFromStrRet;
			}
			FirstPos += MaskStr.Length;
			SecondPos = FirstPos + 1;
			SecondPos = Strings.InStr(SecondPos, SourceStr, " ");
			if (SecondPos == 0)
				SecondPos = SourceStr.Length;

			GetNeedParamFromStrRet = Strings.Trim(Strings.Mid(SourceStr, FirstPos + 1, SecondPos - FirstPos));
			return GetNeedParamFromStrRet;
		}

		private void ImportPos_Click(object sender, EventArgs e)
		{
			int TempInstr1;
			int TempInstr2;

			if (Strings.InStr(1, ImportPosText.Text, "npc_begin") == 0)
				return;

			ImportPosText.Text = Strings.Replace(ImportPosText.Text, "\t", " ");
			// tabs and spaces correction
			while (Strings.InStr(ImportPosText.Text, "  ") != 0)
				ImportPosText.Text = Strings.Replace(ImportPosText.Text, "  ", " ");

			TempInstr1 = Strings.InStr(ImportPosText.Text, "[");
			TempInstr2 = Strings.InStr(TempInstr1, ImportPosText.Text, "]");

			NpcName.Text = Strings.Mid(ImportPosText.Text, TempInstr1 + 1, TempInstr2 - TempInstr1 - 1);

			TotalNpc.Text = GetNeedParamFromStr(ImportPosText.Text, "total");

			RespawnTime.Text = GetNeedParamFromStr(ImportPosText.Text, "respawn");
			if (Strings.InStr(RespawnTime.Text, "sec") != 0)
			{
				RespawnClass.Text = "sec"; RespawnTime.Text = Strings.Replace(RespawnTime.Text, "sec", "");
			}
			if (Strings.InStr(RespawnTime.Text, "min") != 0)
			{
				RespawnClass.Text = "min"; RespawnTime.Text = Strings.Replace(RespawnTime.Text, "min", "");
			}
			if (Strings.InStr(RespawnTime.Text, "hour") != 0)
			{
				RespawnClass.Text = "hour"; RespawnTime.Text = Strings.Replace(RespawnTime.Text, "hour", "");
			}

			TempInstr1 = Strings.InStr(TempInstr2, ImportPosText.Text, "{") + 1;
			TempInstr2 = Strings.InStr(TempInstr1, ImportPosText.Text, ";");
			NpcX.Text = Strings.Mid(ImportPosText.Text, TempInstr1, TempInstr2 - TempInstr1);

			TempInstr1 = TempInstr2 + 1;
			TempInstr2 = Strings.InStr(TempInstr1, ImportPosText.Text, ";");
			NpcY.Text = Strings.Mid(ImportPosText.Text, TempInstr1, TempInstr2 - TempInstr1);

			TempInstr1 = TempInstr2 + 1;
			TempInstr2 = Strings.InStr(TempInstr1, ImportPosText.Text, ";");
			NpcZ.Text = Strings.Mid(ImportPosText.Text, TempInstr1, TempInstr2 - TempInstr1);

			TempInstr1 = TempInstr2 + 1;
			TempInstr2 = Strings.InStr(TempInstr1, ImportPosText.Text, "}");
			LookDirect.Text = Strings.Mid(ImportPosText.Text, TempInstr1, TempInstr2 - TempInstr1);
		}

		private void OneZone_CheckedChanged(object sender, EventArgs e)
		{
			if (OneZone.Checked == true)
			{
				CycleImport.Checked = true;
				CycleImport.Enabled = false;
				AutoClearBox.Checked = true;
			}
			else
				CycleImport.Enabled = true;
		}

		// ------------------------ MultiSpawn Module -------------------

		private void CalculateButton_Click(object sender, EventArgs e)
		{
			if (DataGrid.RowCount < 2)
				return;

			// Dim dc As DataGridCell
			// dc.RowNumber = 1
			// dc.ColumnNumber = 1

			int iTemp; int Summ = 0;

			// Calculate full change summ
			var aChange = new int[DataGrid.RowCount - 2 + 1];
		again:
			;
			var loopTo = DataGrid.RowCount - 2;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				if (Convert.ToInt32(DataGrid[4, iTemp].Value) < 0)
				{
					MessageBox.Show("Negative chance! Edit and calculate again.", "Wrong chance", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				Summ += Convert.ToInt32(DataGrid[4, iTemp].Value);
			}

			switch (Summ)
			{
				case object _ when Summ < 0:
					{
						MessageBox.Show("Somewhere wrong chance", "Wrong chance", MessageBoxButtons.OK);
						return;
					}

				case object _ when Summ < 100:
					{
						DataGrid[4, 0].Value = Convert.ToInt32(DataGrid[4, 0].Value) + (100 - Summ);
						break;
					}

				case object _ when Summ > 100:
					{
						double Divider = Convert.ToDouble(100 / (double)Summ);
						var loopTo1 = DataGrid.RowCount - 2;
						for (iTemp = 0; iTemp <= loopTo1; iTemp++)
							DataGrid[4, iTemp].Value = Conversions.ToInteger(Convert.ToInt32(DataGrid[4, iTemp].Value) * Divider);
						Summ = 0;
						goto again;
						break;
					}

				case 100:
					{
						return;
					}
			}
		}

		private void GenerateMultiSpawnButton_Click(object sender, EventArgs e)
		{
			MultiSpawnTextBox.Text = "";
			var aChange = new int[DataGrid.RowCount - 2 + 1];
			int iTemp; int Summ = 0;

			MultiSpawnTextBox.Text += "{";
			var loopTo = DataGrid.RowCount - 2;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				if (iTemp > 0)
					MultiSpawnTextBox.Text += ";";
				MultiSpawnTextBox.Text += "{";
				try
				{
					MultiSpawnTextBox.Text += DataGrid[0, iTemp].Value.ToString() + ";";
					MultiSpawnTextBox.Text += DataGrid[1, iTemp].Value.ToString() + ";";
					MultiSpawnTextBox.Text += DataGrid[2, iTemp].Value.ToString() + ";";
					MultiSpawnTextBox.Text += DataGrid[3, iTemp].Value.ToString() + ";";
					MultiSpawnTextBox.Text += DataGrid[4, iTemp].Value.ToString() + "%";
				}
				catch (Exception ex)
				{
					MessageBox.Show("Enter values to all cells and try again", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
					MultiSpawnTextBox.Text = "";
					return;
				}
				MultiSpawnTextBox.Text += "}";
			}
			MultiSpawnTextBox.Text += "}";
		}
	}
}
