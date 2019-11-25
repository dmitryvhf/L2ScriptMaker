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

namespace L2ScriptMaker.Modules.Geodata
{
	public partial class LogDNullPosFixer : Form
	{
		public LogDNullPosFixer()
		{
			InitializeComponent();
		}


		// container NULL pos[123126, 79699] at file [.\world_server.cpp], line 740

		// telposlist_begin Position
		// {"Dion Castle Town"; 15671; 142994; -2704; 8100; 2 }
		// telposlist_end

		// Dim X(1000) As Integer, Y(1000) As Integer
		private string[] XY = new string[1001];
		private string[] Z = new string[1001];
		private string[] XYAi = new string[1];
		private string[] XYNpcpos = new string[1];
		private string[] XYSetting = new string[1];

		private void StartButton_Click(object sender, EventArgs e)
		{
			string sTemp;
			int iTemp;

			string[] LogFiles;
			// Dim AiFile As String

			int CountMark = -1;

			// Array.Clear(X, 0, X.Length)
			// Array.Clear(Y, 0, Y.Length)

			System.IO.StreamReader inFile;

			FolderBrowserDialog.SelectedPath = Environment.CurrentDirectory;
			if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
				return;
			LogFiles = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath, "*.log", System.IO.SearchOption.AllDirectories);

			if (LogFiles.Length < 1)
			{
				MessageBox.Show(@"No log files in folder. Try again and select correct folder with files from LodD\err server folder", "No log files", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (System.IO.File.Exists("ai.obj") == false)
			{
				MessageBox.Show("Need file AI.obj for scanning bad teleport positions", "Required AI.obj", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (System.IO.File.Exists("npcpos.txt") == false)
			{
				MessageBox.Show("Need file npcpos.txt for scanning bad teleport positions", "Required npcpos.txt", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (System.IO.File.Exists("setting.txt") == false)
			{
				MessageBox.Show("Need file setting.txt for scanning bad teleport positions", "Required setting.txt", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			ProgressBar.Maximum = LogFiles.Length - 1;
			ProgressBar.Value = 0;
			var loopTo = LogFiles.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				inFile = new System.IO.StreamReader(LogFiles[iTemp], System.Text.Encoding.Default, true, 1);
				ProgressBar.Value = iTemp;
				StatusLabel.Text = "Scanning file... " + System.IO.Path.GetFileName(LogFiles[iTemp]); StatusLabel.Update();
				while (inFile.EndOfStream != true)
				{
					sTemp = inFile.ReadLine();

					if (Strings.InStr(sTemp, "container NULL pos[") != 0)
					{
						// Found error
						// 03/26/2007 00:02:55.977, container NULL pos[-12694, 122776] at file [.\world_server.cpp], line [740]
						sTemp = Strings.Mid(sTemp, Strings.InStr(sTemp, "pos[") + 4, Strings.InStr(sTemp, "]") - Strings.InStr(sTemp, "pos[") - 4).Replace(",", ";").Replace(" ", "");

						if (Array.IndexOf(XY, sTemp) == -1)
						{
							CountMark += 1;
							XY[CountMark] = sTemp;
						}
					}
				}
				inFile.Close();
			}
			ProgressBar.Value = 0;

			// SCANNING Ai.obj for bad telposlist
			// telposlist_begin Position
			// {"Dion Castle Town"; 15671; 142994; -2704; 8100; 2 }
			// telposlist_end
			var TelPos = new string[6];

			StatusLabel.Text = "Scanning AI.obj for finding bad Z..."; StatusLabel.Update();
			inFile = new System.IO.StreamReader("ai.obj", System.Text.Encoding.Default, true, 1);
			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ProgressBar.Value = 0;
			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				if (Strings.InStr(sTemp, "telposlist_begin") != 0)
				{
					sTemp = inFile.ReadLine();
					while (Strings.InStr(sTemp, "telposlist_end") == 0)
					{
						TelPos = sTemp.Replace(" ", "").Split(Conversions.ToChar(";"));

						iTemp = Array.IndexOf(XY, TelPos[1] + ";" + TelPos[2]);
						if (iTemp != -1)
						{
							// Found teleport in list
							XYAi[XYAi.Length - 1] = TelPos[1] + "; " + TelPos[2] + "; " + TelPos[3] + Constants.vbTab + sTemp.Trim();
							Array.Resize(ref XYAi, XYAi.Length + 1);
							// XY(iTemp) = TelPos(1) & "; " & TelPos(2) & "; " & TelPos(3)
							// clear status
							XY[iTemp] = "";
						}

						sTemp = inFile.ReadLine();
					}
					ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				}
			}
			inFile.Close();
			ProgressBar.Value = 0;

			// ai_parameters={[SSQLoserTeleport]=@SEAL_REVELATION;[SSQTelPosX]=[39139];[SSQTelPosY]=[143888];[SSQTelPosZ]=[-3648]}	
			StatusLabel.Text = "Scanning Npcpos.txt for finding bad Z..."; StatusLabel.Update();
			inFile = new System.IO.StreamReader("Npcpos.txt", System.Text.Encoding.Default, true, 1);
			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ProgressBar.Value = 0;
			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				var loopTo1 = CountMark // XY.Length
				;
				for (iTemp = 0; iTemp <= loopTo1; iTemp++)
				{
					if (!string.IsNullOrEmpty(XY[iTemp]))
					{
						TelPos = XY[iTemp].Replace(" ", "").Split(Conversions.ToChar(";"));
						if (Strings.InStr(sTemp, "[" + TelPos[0] + "]") != 0 & Strings.InStr(sTemp, "[" + TelPos[1] + "]") != 0)
						{
							XYNpcpos[XYNpcpos.Length - 1] = TelPos[0] + "; " + TelPos[1] + Constants.vbTab + Libraries.GetNeedParamFromStr(sTemp, "ai_parameters");
							Array.Resize(ref XYNpcpos, XYNpcpos.Length + 1);
							XY[iTemp] = "";
							break;
						}
					}
				}
				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
			}
			inFile.Close();
			ProgressBar.Value = 0;

			// point1 = {-103125;-209047;-3357}
			StatusLabel.Text = "Scanning setting.txt for finding bad Z..."; StatusLabel.Update();
			inFile = new System.IO.StreamReader("setting.txt", System.Text.Encoding.Default, true, 1);
			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ProgressBar.Value = 0;
			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				var loopTo2 = CountMark // XY.Length
				;
				for (iTemp = 0; iTemp <= loopTo2; iTemp++)
				{
					if (!string.IsNullOrEmpty(XY[iTemp]))
					{
						if (Strings.InStr(sTemp.Replace(" ", ""), XY[iTemp]) != 0)
						{
							// TelPos = XY(iTemp).Replace(" ", "").Split(CChar(";"))
							XYSetting[XYSetting.Length - 1] = XY[iTemp] + Constants.vbTab + sTemp.Trim();
							// XYNpcpos(XYNpcpos.Length - 1) = Libraries.GetNeedParamFromStr(sTemp, "ai_parameters")
							Array.Resize(ref XYSetting, XYSetting.Length + 1);
							XY[iTemp] = "";
							break;
						}
					}
				}
				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
			}
			inFile.Close();
			ProgressBar.Value = 0;

			// Save results
			StatusLabel.Text = "Save bad teleport positions to file... ~contanterNULLpos.log"; StatusLabel.Update();
			var outFile = new System.IO.StreamWriter("~contanterNULLpos.log", false, System.Text.Encoding.Unicode, 1);
			outFile.WriteLine("L2ScriptMaker: Error 'container NULL pos[' scanner..." + Constants.vbNewLine + Conversions.ToString(DateAndTime.Now) + Constants.vbTab + "Start");

			outFile.WriteLine(Constants.vbNewLine + "AI.obj scanning log:");
			var loopTo3 = XYAi.Length - 1;
			for (iTemp = 0; iTemp <= loopTo3; iTemp++)
				outFile.WriteLine(XYAi[iTemp]);
			outFile.WriteLine(Constants.vbNewLine + "Npcpos scanning log:");
			var loopTo4 = XYNpcpos.Length - 1;
			for (iTemp = 0; iTemp <= loopTo4; iTemp++)
				outFile.WriteLine(XYNpcpos[iTemp]);
			outFile.WriteLine(Constants.vbNewLine + "Setting scanning log:");
			var loopTo5 = XYSetting.Length - 1;
			for (iTemp = 0; iTemp <= loopTo5; iTemp++)
				outFile.WriteLine(XYSetting[iTemp]);
			outFile.WriteLine(Constants.vbNewLine + "Undefined positions scanning log:");
			var loopTo6 = XY.Length - 1;
			for (iTemp = 0; iTemp <= loopTo6; iTemp++)
			{
				if (!string.IsNullOrEmpty(XY[iTemp]))
					outFile.WriteLine(XY[iTemp]);
			}

			outFile.WriteLine(Constants.vbNewLine + Conversions.ToString(DateAndTime.Now) + Constants.vbTab + "End");
			outFile.Close();

			StatusLabel.Text = "Step1 complete."; StatusLabel.Update();
			MessageBox.Show("Step1 complete. Open file ~contanterNULLpos.log, teleport to this positions, get correct Z and edit file", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void ApplyPatchButton_Click(object sender, EventArgs e)
		{
			if (System.IO.File.Exists("ai.obj") == false)
			{
				MessageBox.Show("Need file AI.obj for fixing bad teleport positions", "Required AI.obj", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string sTemp;
			int iTemp;
			int CountMark = -1;
			var TelPos = new string[6];


			OpenFileDialog.Title = "Select file what have correct coordinates. Plain file with X;Y;Z";
			OpenFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			Array.Clear(XY, 0, XY.Length);
			var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);
			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				if (!string.IsNullOrEmpty(sTemp))
				{
					TelPos = sTemp.Replace(" ", "").Split(Conversions.ToChar(";"));
					CountMark += 1;
					// XY(CountMark) = Join(TelPos, ";")
					XY[CountMark] = TelPos[0] + ";" + TelPos[1];
					Z[CountMark] = TelPos[2];
				}
			}
			inFile.Close();

			System.IO.File.Copy("ai.obj", "ai.obj.bak", true);
			inFile = new System.IO.StreamReader("ai.obj.bak", System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter("ai.obj", false, System.Text.Encoding.Unicode, 1);

			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ProgressBar.Value = 0;
			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				outFile.WriteLine(sTemp);
				if (Strings.InStr(sTemp, "telposlist_begin") != 0)
				{
					sTemp = inFile.ReadLine();

					while (Strings.InStr(sTemp, "telposlist_end") == 0)
					{
						TelPos = sTemp.Replace(" ", "").Split(Conversions.ToChar(";"));
						iTemp = Array.IndexOf(XY, TelPos[1] + ";" + TelPos[2]);
						if (iTemp != -1)
							// Found teleport in list
							// {"Dion Castle Town"; 15671; 142994; -2704; 8100; 2 }

							// TelPos(3) = Z(iTemp)
							// sTemp = TelPos(0) & "; " & XY(iTemp).Replace(";", "; ") & "; " & Z(iTemp) & "; " & TelPos(4) & "; " & TelPos(5)
							// sTemp = Join(TelPos, " ;")
							sTemp = sTemp.Replace(TelPos[3], Z[iTemp]);
						outFile.WriteLine(sTemp);

						sTemp = inFile.ReadLine();
					}
					outFile.WriteLine(sTemp);

					ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				}
			}
			outFile.Close();

			ProgressBar.Value = 0;

			StatusLabel.Text = "Step2 complete."; StatusLabel.Update();
			MessageBox.Show("Step2 complete. Fixed file is AI.obj", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
