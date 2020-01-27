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

namespace L2ScriptMaker.Modules.Scripts
{
	public partial class ClientAggroPatchMaker : Form
	{
		public ClientAggroPatchMaker()
		{
			InitializeComponent();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			string AiFile;
			string NpcFile;
			string NpcFileE;
			string newNpcEFile;

			var aClassName = new string[1];
			var aClassStyle = new string[1];

			var aNpcId = new string[1];
			var aNpcAi = new string[1];
			var aNpcLvl = new string[1];

			OpenFileDialog.FileName = "ai.obj";
			OpenFileDialog.Filter = "Lineage II server npc intelligence file (ai.obj)|ai*.obj|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			AiFile = OpenFileDialog.FileName;

			OpenFileDialog.FileName = "npcdata.txt";
			OpenFileDialog.Filter = "Lineage II server npc file (npcdata.txt)|npcdata*.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			NpcFile = OpenFileDialog.FileName;

			OpenFileDialog.FileName = "npcname-e.txt";
			OpenFileDialog.Filter = "Lineage II client npc file (npcname-e.txt)|npcname-e.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			NpcFileE = OpenFileDialog.FileName;

			SaveFileDialog.FileName = "npcname-e_new.txt";
			SaveFileDialog.Filter = "Lineage II server npc file (npcname-e.txt)|npcname-e*.txt|All files|*.*";
			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			newNpcEFile = SaveFileDialog.FileName;

			System.IO.StreamReader inFile;

			string[] aTemp;
			string sTemp;

			inFile = new System.IO.StreamReader(AiFile, System.Text.Encoding.Default, true, 1);
			ToolStripStatusLabel.Text = "Loading Ai.obj...";
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			StatusStrip.Update();
			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				if (sTemp.StartsWith("class ") == true)
				{
					aTemp = sTemp.Split((char)32);
					// class(0) 1(1) default_npc(2) :(3) (null)(4)
					Array.Resize(ref aClassName, aClassName.Length + 1);
					aClassName[aClassName.Length - 1] = aTemp[2];
					Array.Resize(ref aClassStyle, aClassStyle.Length + 1);
					aClassStyle[aClassStyle.Length - 1] = aTemp[4];
				}
			}
			inFile.Close();
			ToolStripProgressBar.Value = 0;

			string sTemp2;

			inFile = new System.IO.StreamReader(NpcFile, System.Text.Encoding.Default, true, 1);
			ToolStripStatusLabel.Text = "Loading npcdata.txt...";
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			StatusStrip.Update();
			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				if (!string.IsNullOrEmpty(sTemp.Trim()) & sTemp.StartsWith("//") == false)
				{

					// npc_begin      pet     12077   [pet_wolf_a]    level=15
					// npc_ai={[black_leopard];{[MoveAroundSocial]=90};

					aTemp = sTemp.Replace((char)32, (char)9).Split((char)9);

					if ((aTemp[1] ?? "") == "warrior")
					{
						Array.Resize(ref aNpcId, aNpcId.Length + 1);
						aNpcId[aNpcId.Length - 1] = aTemp[2];    // ID
						Array.Resize(ref aNpcLvl, aNpcLvl.Length + 1);
						aNpcLvl[aNpcLvl.Length - 1] = Libraries.GetNeedParamFromStr(sTemp, "level");    // Level

						sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "npc_ai");
						if ((sTemp2 ?? "") != "{}")
						{
							sTemp2 = sTemp2.Substring(2, Strings.InStr(sTemp2, "]") - 3);
							Array.Resize(ref aNpcAi, aNpcAi.Length + 1);
							aNpcAi[aNpcAi.Length - 1] = sTemp2;   // Ai
						}
					}
				}
			}
			inFile.Close();


			// npcname_begin  id=20001        name=[Gremlin]  description=[]

			inFile = new System.IO.StreamReader(NpcFileE, System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter(newNpcEFile, false, System.Text.Encoding.Unicode, 1);
			ToolStripStatusLabel.Text = "Analysing npcname-e.txt...";
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			StatusStrip.Update();
			int iTempId;
			int iTemp;

			string Tag1 = Tag1TextBox.Text;
			string Tag2 = Tag2TextBox.Text;

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);

				iTempId = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, Tag1));
				iTemp = Array.IndexOf(aNpcId, iTempId.ToString());
				if (iTemp != -1)
				{
					if ((Libraries.GetNeedParamFromStr(sTemp, Tag2TextBox.Text) ?? "") == "[]")
					{
						sTemp2 = MaskPassTextBox.Text.Replace("$lvl", aNpcLvl[iTemp]);
						iTemp = Array.IndexOf(aClassName, aNpcAi[iTemp]);

						if (iTemp != -1)
						{
							if (Strings.InStr(aClassStyle[iTemp], "_ag_") != 0 | Strings.InStr(aClassStyle[iTemp], "aggressive") != 0)
								sTemp2 = sTemp2 + MaskAggrTextBox.Text;

							sTemp = sTemp.Replace(" = ", "=");
							sTemp = sTemp.Replace(Tag2 + "=" + Libraries.GetNeedParamFromStr(sTemp, Tag2), Tag2 + "=[" + sTemp2 + "]");
						}
					}
				}
				outFile.WriteLine(sTemp);
			}
			inFile.Close();
			ToolStripProgressBar.Value = 0;

			outFile.Close();

			ToolStripStatusLabel.Text = "Complete";
			ToolStripProgressBar.Value = 0;
			MessageBox.Show("Complete.");
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void MaskPassTextBox_TextChanged(object sender, EventArgs e)
		{
			ExampleTextBox.Text = (MaskPassTextBox.Text + MaskAggrTextBox.Text).Replace("$lvl", "75");
		}

		private void MaskAggrTextBox_TextChanged(object sender, EventArgs e)
		{
			ExampleTextBox.Text = (MaskPassTextBox.Text + MaskAggrTextBox.Text).Replace("$lvl", "75");
		}

	}
}
