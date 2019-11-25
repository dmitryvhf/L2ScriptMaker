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

namespace L2ScriptMaker.Modules.ZeroScripts
{
	public partial class ScriptFromDat : Form
	{
		public ScriptFromDat()
		{
			InitializeComponent();
		}

		public struct ScriptStruct
		{
			public string Name;
			public string Import;
			public string DefValue;
			public string Symbols;
			public string Autoname;
			public string Unique;
		}


		private void StartButton_Click(object sender, EventArgs e)
		{
			string sCfgFile;

			string sDatFile;
			string sSaveFile;

			// SaveFileDialog

			OpenFileDialog.InitialDirectory = Application.StartupPath;
			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "L2ScriptMaker Script Generator config file v2|*.ini";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sCfgFile = OpenFileDialog.FileName;

			// OpenFileDialog.InitialDirectory = Application.StartupPath
			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II Client Dat text file (..-e.txt)|*.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sDatFile = OpenFileDialog.FileName;

			// SaveFileDialog.InitialDirectory = Application.StartupPath
			SaveFileDialog.FileName = "";
			SaveFileDialog.Filter = "Lineage II Server Script file|*.txt|All files|*.*";
			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sSaveFile = SaveFileDialog.FileName;

			string sTemp;
			var aParams = new ScriptStruct[1];
			var aUnique = new string[1];

			var inFile = new System.IO.StreamReader(sCfgFile, System.Text.Encoding.Default, true, 1);
			if ((inFile.ReadLine() ?? "") != "L2ScriptMaker Visual Script Editor config file v2")
			{
				MessageBox.Show("Config file incompatible with this module." + Constants.vbNewLine + "Required 'L2ScriptMaker Script Generator config file v2'", "Incorrect config", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine().Trim();
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{

					// Name
					if (sTemp.StartsWith("[") == true)
					{
						aParams[aParams.Length - 1].Name = sTemp.Substring(1, sTemp.Length - 2);
						Array.Resize(ref aParams, aParams.Length + 1);
					}

					if (sTemp.StartsWith("import") == true)
						aParams[aParams.Length - 2].Import = sTemp.Replace("import", "").Replace("=", "");

					if (sTemp.StartsWith("defvalue") == true)
						aParams[aParams.Length - 2].DefValue = sTemp.Replace("defvalue", "").Replace("=", "");

					if (sTemp.StartsWith("symbols") == true)
						aParams[aParams.Length - 2].Symbols = sTemp.Replace("symbols", "").Replace("=", "");

					if (sTemp.StartsWith("autogenname") == true)
						aParams[aParams.Length - 2].Autoname = sTemp.Replace("autogenname", "").Replace("=", "");

					if (sTemp.StartsWith("unique") == true)
						aParams[aParams.Length - 2].Unique = sTemp.Replace("unique", "").Replace("=", "");

					if (sTemp.StartsWith("<") == true)
					{
						while (inFile.ReadLine().Trim().StartsWith(">") == false)
						{
						}
					}
				}
			}
			inFile.Close();


			inFile = new System.IO.StreamReader(sDatFile, System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter(sSaveFile, false, System.Text.Encoding.Unicode, 1);

			// Dim aTemp() As String
			// Reading Npcdata-e config...

			// Dim Name As String
			// Dim Import As String
			// Dim DefValue As String
			// Dim Symbols As String

			int iTemp;
			string sTemp2;

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripProgressBar.Value = 0;

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				var loopTo = aParams.Length - 1;
				for (iTemp = 0; iTemp <= loopTo; iTemp++)
				{
					if (!string.IsNullOrEmpty(aParams[iTemp].Name))
						outFile.Write(aParams[iTemp].Name + "=");

					if (string.IsNullOrEmpty(aParams[iTemp].Import))
					{
						if (!string.IsNullOrEmpty(aParams[iTemp].Symbols))
							outFile.Write(aParams[iTemp].Symbols[0]);
						outFile.Write(aParams[iTemp].DefValue);
						if (!string.IsNullOrEmpty(aParams[iTemp].Symbols))
							outFile.Write(aParams[iTemp].Symbols[1]);
					}
					else
					{
						sTemp2 = Libraries.GetNeedParamFromStr(sTemp, aParams[iTemp].Import).ToLower();
						if (!string.IsNullOrEmpty(aParams[iTemp].Symbols))
							sTemp2 = sTemp2.Replace(Conversions.ToString(aParams[iTemp].Symbols[0]), "").Replace(Conversions.ToString(aParams[iTemp].Symbols[1]), "");
						sTemp2 = sTemp2.Replace(" ", "_").Replace("&", "").Replace(":", "").Replace("(", "").Replace(")", "").Replace("_-_", "_");
						sTemp2 = sTemp2.Replace("_of_", "_").Replace("_the_", "_").Replace("!", "").Replace(".", "").Replace(",", "");
						// Fix for Empty Npc names
						if (string.IsNullOrEmpty(sTemp2))
							sTemp2 = "npcid_" + Libraries.GetNeedParamFromStr(sTemp, aParams[iTemp].Autoname).ToLower();

						// Fix for Unique Name
						if ((aParams[iTemp].Unique ?? "") == "on")
						{
							if (Array.IndexOf(aUnique, sTemp2) != -1)
								sTemp2 = sTemp2 + "_" + Libraries.GetNeedParamFromStr(sTemp, aParams[iTemp].Autoname).ToLower();
							aUnique[aUnique.Length - 1] = sTemp2;
							Array.Resize(ref aUnique, aUnique.Length + 1);
						}

						// Finishing of writing param
						if (!string.IsNullOrEmpty(aParams[iTemp].Symbols))
							outFile.Write(aParams[iTemp].Symbols[0]);
						outFile.Write(sTemp2);
						if (!string.IsNullOrEmpty(aParams[iTemp].Symbols))
							outFile.Write(aParams[iTemp].Symbols[1]);
					}

					if (iTemp < aParams.Length - 1)
						outFile.Write(Constants.vbTab);
				}
				outFile.Write(Constants.vbNewLine);
			}
			inFile.Close();
			outFile.Close();
			ToolStripProgressBar.Value = 0;

			MessageBox.Show("Generation complete", "Complete", MessageBoxButtons.OK);
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
