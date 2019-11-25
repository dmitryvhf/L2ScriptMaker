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
	public partial class NpcDataCollisionFix : Form
	{
		public NpcDataCollisionFix()
		{
			InitializeComponent();
		}

		private struct Collision
		{
			public string Radius;
			public string Height;
		}

		private int[] NpcId = new int[1];
		private Collision[] NpcParam = new Collision[1];

		// collision_radius={13;13}	collision_height={11.5;11.5}	

		private void ImportButton_Click(object sender, EventArgs e)
		{
			string sImportData;
			string sNpcData;

			OpenFileDialog.Title = "Select collision table file";
			OpenFileDialog.Filter = "Collision table file|*.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sImportData = OpenFileDialog.FileName;

			OpenFileDialog.FileName = "npcdata.txt";
			OpenFileDialog.Filter = "Lineage II Server Npc config|npcdata*.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sNpcData = OpenFileDialog.FileName;

			System.IO.StreamReader inFile;
			string[] aTemp;
			string sTemp;
			int iTemp;

			// Loading Collision data
			inFile = new System.IO.StreamReader(sImportData, System.Text.Encoding.Default, true, 1);

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripProgressBar.Value = 0;
			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{
					aTemp = sTemp.Split((char)9);

					iTemp = NpcId.Length;
					Array.Resize(ref NpcId, iTemp + 1);
					Array.Resize(ref NpcParam, iTemp + 1);

					// 12077	collision_radius={13;13}	collision_height={11.5;11.5}
					NpcId[iTemp - 1] = Conversions.ToInteger(aTemp[0]);
					if (UseFirstCheckBox.Checked == false)
					{
						NpcParam[iTemp - 1].Radius = aTemp[1].Replace("collision_radius=", "");
						NpcParam[iTemp - 1].Height = aTemp[2].Replace("collision_height=", "");
					}
					else
					{
						// Required fix only first param
						NpcParam[iTemp - 1].Radius = aTemp[1].Substring(Strings.InStr(aTemp[1], "{"), Strings.InStr(aTemp[1], ";") - Strings.InStr(aTemp[1], "{") - 1);
						NpcParam[iTemp - 1].Height = aTemp[2].Substring(Strings.InStr(aTemp[2], "{"), Strings.InStr(aTemp[2], ";") - Strings.InStr(aTemp[2], "{") - 1);
					}
				}
			}
			inFile.Close();
			ToolStripProgressBar.Value = 0;

			// UseFirstCheckBox

			// Fixing current file
			System.IO.File.Copy(sNpcData, sNpcData + ".bak", true);
			inFile = new System.IO.StreamReader(sNpcData + ".bak", System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter(sNpcData, false, System.Text.Encoding.Unicode, 1);

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripProgressBar.Value = 0;

			string sTemp2;

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);

				if (!string.IsNullOrEmpty(sTemp.Trim()) & sTemp.StartsWith("//") == false)
				{
					aTemp = sTemp.Split((char)9);
					// npc_begin      warrior 20761   [pytan] level=69
					iTemp = Array.IndexOf(NpcId, Conversions.ToInteger(aTemp[2]));
					if (iTemp != -1)
					{
						if (UseFirstCheckBox.Checked == false)
						{
							sTemp = Libraries.SetNeedParamToStr(sTemp, "collision_radius", NpcParam[iTemp].Radius);
							sTemp = Libraries.SetNeedParamToStr(sTemp, "collision_height", NpcParam[iTemp].Height);
						}
						else
						{

							// Required fix only first param
							// 12077	collision_radius={13;13}	collision_height={11.5;11.5}

							sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "collision_radius");
							sTemp2 = sTemp2.Substring(Strings.InStr(sTemp2, ";"), Strings.InStr(sTemp2, "}") - Strings.InStr(sTemp2, ";") - 1);
							if (Conversions.ToInteger(sTemp2) < Conversions.ToInteger(NpcParam[iTemp].Radius))
								sTemp2 = NpcParam[iTemp].Radius;
							sTemp2 = "{" + NpcParam[iTemp].Radius + ";" + sTemp2 + "}";
							sTemp = Libraries.SetNeedParamToStr(sTemp, "collision_radius", sTemp2);

							sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "collision_height");
							sTemp2 = sTemp2.Substring(Strings.InStr(sTemp2, ";"), Strings.InStr(sTemp2, "}") - Strings.InStr(sTemp2, ";") - 1);
							if (Conversions.ToInteger(sTemp2) < Conversions.ToInteger(NpcParam[iTemp].Height))
								sTemp2 = NpcParam[iTemp].Height;
							sTemp2 = "{" + NpcParam[iTemp].Height + ";" + sTemp2 + "}";
							sTemp = Libraries.SetNeedParamToStr(sTemp, "collision_height", sTemp2);
						}
					}
				}
				outFile.WriteLine(sTemp);
			}
			inFile.Close();
			outFile.Close();
			ToolStripProgressBar.Value = 0;

			MessageBox.Show("Import complete.");
		}

		private void ExportButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog.Title = "Enter file name export collision table list";
			SaveFileDialog.Filter = "collision table text file|*.txt|All files|*.*";
			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			OpenFileDialog.FileName = "npcdata.txt";
			OpenFileDialog.Filter = "Lineage II Server Npc config|npcdata*.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			// sNpcData = OpenFileDialog.FileName

			string[] aTemp;
			string sTemp;

			var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter(SaveFileDialog.FileName, false, System.Text.Encoding.Unicode, 1);

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripProgressBar.Value = 0;

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);

				if (!string.IsNullOrEmpty(sTemp.Trim()) & sTemp.StartsWith("//") == false)
				{
					aTemp = sTemp.Split((char)9);
					// npc_begin      warrior 20761   [pytan] level=69
					outFile.Write(aTemp[2] + Constants.vbTab);
					outFile.Write("collision_radius=" + Libraries.GetNeedParamFromStr(sTemp, "collision_radius") + Constants.vbTab);
					outFile.WriteLine("collision_height=" + Libraries.GetNeedParamFromStr(sTemp, "collision_height") + Constants.vbTab);
				}
			}
			outFile.Close();
			inFile.Close();
			ToolStripProgressBar.Value = 0;
			MessageBox.Show("Export complete.");
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
