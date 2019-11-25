using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using L2ScriptMaker.Extensions.VbCompatibleHelper;

namespace L2ScriptMaker.Modules.Npc
{
	public partial class NpcC4toC5IdsConversion : Form
	{
		public NpcC4toC5IdsConversion()
		{
			InitializeComponent();
		}


		// 13846	14829
		private int[] aOldId = new int[1];
		private int[] aNewId = new int[1];
		private string sIDFile;

		private bool IDReloader()
		{
			OpenFileDialog.FileName = sIDFile;
			OpenFileDialog.Filter = "File with ids (2 column)|*.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return false;
			sIDFile = OpenFileDialog.FileName;

			string sTemp;
			var aTemp = new string[3];

			Array.Clear(aOldId, 0, aOldId.Length);
			Array.Clear(aNewId, 0, aNewId.Length);
			Array.Resize(ref aOldId, 0);
			Array.Resize(ref aNewId, 0);

			var inFile = new System.IO.StreamReader(sIDFile, System.Text.Encoding.Default, true, 1);
			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				sTemp = sTemp.Trim();
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{
					while (Strings.InStr(sTemp, "  ") != 0)
						sTemp = sTemp.Replace("  ", " ");
					sTemp = sTemp.Replace((char)32, (char)9);
					while (Strings.InStr(sTemp, Conversions.ToString((char)9) + Conversions.ToString((char)9)) != 0)
						sTemp = sTemp.Replace(Conversions.ToString((char)9) + Conversions.ToString((char)9), Conversions.ToString((char)9));
					aTemp = sTemp.Split((char)9);

					Array.Resize(ref aOldId, aOldId.Length + 1);
					aOldId[aOldId.Length - 1] = Conversions.ToInteger(aTemp[0]);
					Array.Resize(ref aNewId, aNewId.Length + 1);
					aNewId[aNewId.Length - 1] = Conversions.ToInteger(aTemp[1]);
				}
			}

			inFile.Close();
			return true;
		}

		private void NpcC4toC5IdsConversion_Load(object sender, EventArgs e)
		{
			if (IDReloader() == false)
				this.Close();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			string sNpcdataFile = "";
			OpenFileDialog.FileName = sNpcdataFile;
			OpenFileDialog.Filter = "Lineage II C4 server npc config (npcdata.txt)|npcdata*.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sNpcdataFile = OpenFileDialog.FileName;

			string sTemp;
			string[] aTemp;

			if (System.IO.File.Exists(sNpcdataFile + ".bak") == true)
			{
				if ((int)MessageBox.Show("Overwrite last backup file " + sNpcdataFile + ".bak ?", "Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (int)DialogResult.No)
					return;
			}


			System.IO.File.Copy(sNpcdataFile, sNpcdataFile + ".bak", true);
			var inFile = new System.IO.StreamReader(sNpcdataFile + ".bak", System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter(sNpcdataFile, false, System.Text.Encoding.Unicode, 1);
			int iTemp;

			ToolStripProgressBar1.Value = 0;
			ToolStripProgressBar1.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				ToolStripProgressBar1.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				sTemp = sTemp.Trim();
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{
					aTemp = sTemp.Split((char)9);

					// npc_begin(0)      pet(1)     12077(2)   [pet_wolf_a](3)    level=15(4)
					if (InverseDirectionCheckBox.Checked == false)
					{
						iTemp = Array.IndexOf(aOldId, Conversions.ToInteger(aTemp[2]));
						if (iTemp != -1)
						{
							aTemp[2] = Conversions.ToString(aNewId[iTemp]);
							sTemp = Strings.Join(aTemp, Conversions.ToString((char)9));
						}
						else if (DisableCheckBox.Checked == true)
							sTemp = "//" + sTemp;
					}
					else
					{
						iTemp = Array.IndexOf(aNewId, Conversions.ToInteger(aTemp[2]));
						if (iTemp != -1)
						{
							aTemp[2] = Conversions.ToString(aOldId[iTemp]);
							sTemp = Strings.Join(aTemp, Conversions.ToString((char)9));
						}
						else if (DisableCheckBox.Checked == true)
							sTemp = "//" + sTemp;
					}
				}
				outFile.WriteLine(sTemp);
			}
			inFile.Close();
			outFile.Close();
			ToolStripProgressBar1.Value = 0;
			MessageBox.Show("Fixed npcdata file created successfuly", "Complete");
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void C4TextBox_Validated(object sender, EventArgs e)
		{

			// 13846	14829
			int iTemp;
			try
			{
				iTemp = Array.IndexOf(aOldId, Conversions.ToInteger(C4TextBox.Text));
			}
			catch (Exception ex)
			{
				return;
			}
			if (iTemp != -1)
				C6TextBox.Text = Conversions.ToString(aNewId[iTemp]);
			else
				C6TextBox.Text = "Not found";
		}

		private void C6TextBox_Validated(object sender, EventArgs e)
		{
			int iTemp;
			try
			{
				iTemp = Array.IndexOf(aNewId, Conversions.ToInteger(C6TextBox.Text));
			}
			catch (Exception ex)
			{
				return;
			}
			if (iTemp != -1)
				C4TextBox.Text = Conversions.ToString(aOldId[iTemp]);
			else
				C4TextBox.Text = "Not found";
		}

		private void ReloadButton_Click(object sender, EventArgs e)
		{
			if (IDReloader() == true)
				MessageBox.Show("New ID table reloaded", "Complete");
			else
				MessageBox.Show("New ID table NOT reloaded", "Failure");
		}
	}
}
