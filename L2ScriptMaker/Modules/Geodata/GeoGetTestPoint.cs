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

namespace L2ScriptMaker.Modules.Geodata
{
	public partial class GeoGetTestPoint : Form
	{
		public GeoGetTestPoint()
		{
			InitializeComponent();
		}

		private void ScanButton_Click(object sender, EventArgs e)
		{
			string[] aLogFiles;
			string sLogPath;
			string sBugPath;

			ToolStripStatusLabel1.Text = "Select folder with server Error log";
			FolderBrowserDialog.SelectedPath = Application.StartupPath;
			if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sLogPath = FolderBrowserDialog.SelectedPath;

			ToolStripStatusLabel1.Text = "Select folder for geo_bug files";
			FolderBrowserDialog.SelectedPath = Application.StartupPath;
			if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sBugPath = FolderBrowserDialog.SelectedPath;

			aLogFiles = System.IO.Directory.GetFiles(sLogPath, "*.log", System.IO.SearchOption.AllDirectories);
			if (aLogFiles.Length == 0)
			{
				MessageBox.Show("No log in selected folder", "No logs", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			System.IO.StreamReader inFile;
			var outFile = new System.IO.StreamWriter("L2ScriptMaker_GetTestPoint.log", true, System.Text.Encoding.Unicode, 1);
			outFile.WriteLine("L2ScriptMaker: GetTestPoint Finder and Geodata Bug file gererator.");
			outFile.WriteLine(DateAndTime.Now.ToString() + " Start processing... ");

			ProgressBar.Maximum = Conversions.ToInteger(aLogFiles.Length - 1);
			ProgressBar.Value = 0;
			string sTemp;
			string sBugPoint;
			var aBugPoint = new string[1];

			int iTemp;
			var loopTo = aLogFiles.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				inFile = new System.IO.StreamReader(aLogFiles[iTemp], System.Text.Encoding.Default, true, 1);

				ProgressBar.Value = iTemp;
				ToolStripStatusLabel1.Text = "Scan file: " + System.IO.Path.GetFileName(aLogFiles[iTemp]);
				this.Update();

				while (inFile.EndOfStream != true)
				{

					// 02/23/2007 14:07:50.140, [.\User.cpp][1157] Invalid(37384,-33800,-3640) GetTestPoint
					sTemp = inFile.ReadLine();
					if (sTemp.EndsWith(") GetTestPoint") == true)
					{

						// debug log
						outFile.WriteLine(sTemp);

						// Substring point
						sBugPoint = sTemp.Substring(Strings.InStr(sTemp, "Invalid(") + 7, Strings.InStr(sTemp, ")") - Strings.InStr(sTemp, "Invalid(") - 8);
						if (Array.IndexOf(aBugPoint, sBugPoint) == -1)
						{
							aBugPoint[aBugPoint.Length - 1] = sBugPoint;
							Array.Resize(ref aBugPoint, aBugPoint.Length + 1);
						}
					}
				}
				inFile.Close();
			}
			ProgressBar.Value = 0;
			ToolStripStatusLabel1.Text = "Scanning complete.";
			outFile.Flush();

			System.IO.StreamWriter outBugFile;
			string BugX;
			string BugY;
			string[] aTemp;

			Array.Sort(aBugPoint, 0, aBugPoint.Length);

			ProgressBar.Maximum = aBugPoint.Length - 1;
			ProgressBar.Value = 0;

			ToolStripStatusLabel1.Text = "Saving xx_xx_bug.txt files...";
			this.Update();
			var loopTo1 = aBugPoint.Length - 1;
			for (iTemp = 1; iTemp <= loopTo1; iTemp++)
			{
				aTemp = aBugPoint[iTemp].Split(Conversions.ToChar(","));
				BugX = Conversions.ToString(Conversions.Fix(20 + (Conversions.ToInteger(aTemp[0]) - Conversions.ToInteger(aTemp[0]) / 32768) / (double)32768));
				BugY = Conversions.ToString(Conversions.Fix(18 + (Conversions.ToInteger(aTemp[1]) - Conversions.ToInteger(aTemp[1]) / 32768) / (double)32768));
				// 21_16_bug.txt
				// 36304;-37552;-3736

				if (System.IO.File.Exists(sBugPath + @"\" + BugX + "_" + BugY + "_bug.txt") == true)
				{
					inFile = new System.IO.StreamReader(sBugPath + @"\" + BugX + "_" + BugY + "_bug.txt", System.Text.Encoding.ASCII, true, 1);
					sTemp = inFile.ReadToEnd();
					inFile.Close();
					if (Strings.InStr(sTemp, aBugPoint[iTemp].Replace(",", ";") + Constants.vbNewLine) == 0)
					{
						// Point not found. Write this
						outBugFile = new System.IO.StreamWriter(sBugPath + @"\" + BugX + "_" + BugY + "_bug.txt", true, System.Text.Encoding.ASCII, 1);
						outBugFile.WriteLine(aBugPoint[iTemp].Replace(",", ";"));
						outBugFile.Close();
					}
				}
				else
				{
					outBugFile = new System.IO.StreamWriter(sBugPath + @"\" + BugX + "_" + BugY + "_bug.txt", true, System.Text.Encoding.ASCII, 1);
					outBugFile.WriteLine(aBugPoint[iTemp].Replace(",", ";"));
					outBugFile.Close();
				}

				ProgressBar.Value = iTemp;
			}

			outFile.WriteLine(DateAndTime.Now.ToString() + " End of processing... ");
			outFile.Close();
			ProgressBar.Value = 0;
			ToolStripStatusLabel1.Text = "Complete.";

			MessageBox.Show("Scanning and generating complete. Calculated of " + Conversions.ToString(iTemp - 1) + " points.");
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
