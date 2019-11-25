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
	public partial class NpcPchMaker : Form
	{
		public NpcPchMaker()
		{
			InitializeComponent();
		}

		// Dim TabSymbol As String = Chr(9)
		// private const string TabSymbol = " ";

		private void StartButton_Click(object sender, EventArgs e)
		{
			string TempStr;
			// Dim FirstPos, SecondPos As Integer
			string NpcDataFile, NpcDataDir;
			string[] NpcData;

			ProgressBar.Value = 0;

			OpenFileDialog.InitialDirectory = Environment.CurrentDirectory;
			OpenFileDialog.Filter = "Lineage II NpcData config|npcdata.txt|All files (*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			NpcDataFile = OpenFileDialog.FileName;
			NpcDataDir = System.IO.Path.GetDirectoryName(NpcDataFile);

			var inNpcData = new System.IO.StreamReader(NpcDataFile, System.Text.Encoding.Default, true, 1);

			if (System.IO.File.Exists(NpcDataDir + @"\npc_pch.txt") == true)
			{
				if ((int)MessageBox.Show("File npc_pch.txt exist. Overwrite?", "Overwrite?", MessageBoxButtons.OKCancel) == (int)DialogResult.Cancel)
					return;
			}

			System.IO.Stream oPchFile = new System.IO.FileStream(NpcDataDir + @"\npc_pch.txt", System.IO.FileMode.Create, System.IO.FileAccess.Write);
			var outItemPchData = new System.IO.StreamWriter(oPchFile, System.Text.Encoding.Unicode);

			// Logging system
			var oLogFile = new System.IO.StreamWriter(NpcDataDir + @"\npc_pch.log", true, System.Text.Encoding.Unicode, 1);
			oLogFile.WriteLine("L2ScriptMaker NpcData PCH Generator" + Environment.NewLine + DateTime.Now + "\tStarted");
			bool isError = false;


			while (inNpcData.BaseStream.Position != inNpcData.BaseStream.Length)
			{
				TempStr = inNpcData.ReadLine();

				if (!String.IsNullOrWhiteSpace(TempStr) && !TempStr.StartsWith("//"))
				{
					TempStr = TempStr.Replace('\t', ' ');

					// tabs and spaces correction
					while (TempStr.IndexOf("  ") >= 0)
					{
						TempStr = TempStr.Replace("  ", " ");
					}
					NpcData = TempStr.Split((char)32);

					if (NpcData[0].StartsWith("npc_begin"))
					{
						outItemPchData.Write(NpcData[3] + " " + "=" + " ");
						outItemPchData.WriteLine((1000000 + Convert.ToInt32(NpcData[2])).ToString());

						if (NpcData[3].Replace("[", "").Replace("]", "").Length >= 25)
						{
							// Logging about wrong file name
							oLogFile.WriteLine("Npcname too long: " + NpcData[3] + "\tFixed name is: [" + NpcData[3].Substring(1, 24) + "]");
							isError = true;
						}
					}
					else
					{
					}
				}

				ProgressBar.Value = (int)(inNpcData.BaseStream.Position * 100 / (double)inNpcData.BaseStream.Length);
			}
			oLogFile.WriteLine("L2ScriptMaker NpcData PCH Generator" + Environment.NewLine + DateTime.Now + "\tStarted");
			oLogFile.Close();
			inNpcData.Close();
			outItemPchData.Close();
			System.IO.File.Create(NpcDataDir + @"\npc_pch2.txt");

			if (isError == false)
				TempStr = "Complete. Success.";
			else
				TempStr = "Complete. Found errors! Check log file.";

			ProgressBar.Value = 0;
			MessageBox.Show(TempStr);
		}

		private void NpcCacheScript_Click(object sender, EventArgs e)
		{
			// 10      Felim Lizardman Scout

			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II config (npcdata.txt)|npcdata.txt|All files (*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			System.IO.StreamReader inEFile;
			try
			{
				inEFile = new System.IO.StreamReader(System.IO.Path.GetDirectoryName(OpenFileDialog.FileName) + @"\npcname-e.txt", System.Text.Encoding.Default, true, 1);
			}
			catch (Exception ex)
			{
				MessageBox.Show("You must have npcname-e.txt in work folder for generation npccache.txt file. Put and try again.");
				return;
			}

			// Initialization
			ProgressBar.Value = 0;
			var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);
			System.IO.Stream oAiFile = new System.IO.FileStream(System.IO.Path.GetDirectoryName(OpenFileDialog.FileName) + @"\npccache.txt", System.IO.FileMode.Create, System.IO.FileAccess.Write);
			var outAiData = new System.IO.StreamWriter(oAiFile, System.Text.Encoding.Unicode, 1);

			string ReadStr;


			ProgressBar.Value = 0;
			ProgressBar.Maximum = (int)(inEFile.BaseStream.Length);
			var NpcDB = new string[15001]; // 0- id, 1 - name, 2 - consume, 3 - type (for quest)
			int NpcDBMarker = 0;
			string CommentName;

			string[] ReadSplitStr;

			// Creating ID Table from NPCdata.txt
			while (inEFile.EndOfStream != true)
			{
				ReadStr = inEFile.ReadLine();

				if (ReadStr != null)
				{
					if (!ReadStr.StartsWith("//"))
					{
						// ReadSplitStr = ReadStr.Split(Chr(9))
						NpcDBMarker = Convert.ToInt32(Libraries.GetNeedParamFromStr(ReadStr, "id"));
						if (NpcDBMarker >= NpcDB.Length)
							Array.Resize(ref NpcDB, NpcDBMarker + 1);
						NpcDB[NpcDBMarker] = Libraries.GetNeedParamFromStr(ReadStr, "name"); // ReadSplitStr(4).Replace("name=[", "").Replace("]", "")
					}
				}
				ProgressBar.Value = (int)(inFile.BaseStream.Position * 100 / (double)inFile.BaseStream.Length);
			}

			ProgressBar.Maximum = (int)(inFile.BaseStream.Length);
			ProgressBar.Value = 0;

			while (inFile.BaseStream.Position != inFile.BaseStream.Length)
			{
				ReadStr = inFile.ReadLine();
				ReadStr = ReadStr.Replace("\t", " ");

				if (!string.IsNullOrEmpty(ReadStr.Trim()) & ReadStr.StartsWith("//") == false)
				{
					// tabs and spaces correction
					while (ReadStr.IndexOf("  ") >= 0)
					{
						ReadStr = ReadStr.Replace("  ", " ");
					}
					ReadSplitStr = ReadStr.Split((char)32);

					// Find Npc in Npcname-e
					ReadSplitStr[3] = ReadSplitStr[3].Substring(1, ReadSplitStr[3].Length - 2);
					CommentName = ReadSplitStr[3];

					NpcDBMarker = Convert.ToInt32(ReadSplitStr[2]);
					if (NpcDBMarker <= NpcDB.Length)
					{
						if (!string.IsNullOrEmpty(NpcDB[Convert.ToInt32(ReadSplitStr[2])]))
							CommentName = NpcDB[Convert.ToInt32(ReadSplitStr[2])];
					}

					ReadStr = ReadSplitStr[2] + "\t" + CommentName;
					outAiData.WriteLine(ReadStr);
				}

				ProgressBar.Value = (int)(inFile.BaseStream.Position);
			}

			MessageBox.Show("npccache.txt Complete");
			ProgressBar.Value = 0;
			inFile.Close();
			outAiData.Close();
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
