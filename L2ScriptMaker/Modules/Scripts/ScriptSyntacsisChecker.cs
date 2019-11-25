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
	public partial class ScriptSyntacsisChecker : Form
	{
		public ScriptSyntacsisChecker()
		{
			InitializeComponent();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			var sFile = new string[1];

			System.IO.StreamReader inFile = null;

			string sTemp;
			int iTemp;
			int iTempFiles;
			int iLineFlag = 0;

			string[] aSymbols1; // = {"[]", "{}", "<>"}
			string[] aSymbols2; // = {""""} ', "'" , "`"
			string sTemp1;
			string sTemp2;
			int iFlag1;
			int iFlag2;

			if (UseMetod1CheckBox.Checked == false & UseMetod1CheckBox.Checked == false)
			{
				MessageBox.Show("No one Mode selected. Select and try again", "No works.", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Preparing symbols
			if (Metod1TextBox.Text.Length < 2)
			{
				MessageBox.Show("Metod1 symbols definition wrong", "Wrong symbols", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			aSymbols1 = Metod1TextBox.Text.Split(Conversions.ToChar(","));
			var loopTo = aSymbols1.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				if (aSymbols1[iTemp].Length != 2)
				{
					MessageBox.Show("Metod1 symbols '" + aSymbols1[iTemp] + "' wrong.", "Wrong symbols", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			if (Metod2TextBox.Text.Length < 1)
			{
				MessageBox.Show("Metod2 symbols definition wrong", "Wrong symbols", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			aSymbols2 = Metod2TextBox.Text.Split(Conversions.ToChar(","));
			var loopTo1 = aSymbols2.Length - 1;
			for (iTemp = 0; iTemp <= loopTo1; iTemp++)
			{
				if (aSymbols2[iTemp].Length != 1)
				{
					MessageBox.Show("Metod2 symbols '" + aSymbols2[iTemp] + "' wrong.", "Wrong symbols", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			// --------

			// Folder reading
			if (ReadingFolderCheckBox.Checked == false)
			{
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				sFile[0] = OpenFileDialog.FileName;
			}
			else
			{
				FolderBrowserDialog.SelectedPath = Application.StartupPath;
				if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
					return;
				sFile = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath, "*.*", System.IO.SearchOption.TopDirectoryOnly);
				if (sFile.Length == 0)
				{
					MessageBox.Show("Selected directory empty. Try select another directory", "Empty directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			var outFile = new System.IO.StreamWriter("l2scriptmaker.log", true, System.Text.Encoding.Unicode, 1);
			outFile.WriteLine("L2ScriptMaker. Script Syntax Checker");
			outFile.WriteLine(Conversions.ToString(DateAndTime.Now) + " Start" + Constants.vbNewLine);
			outFile.WriteLine();
			if (ReadingFolderCheckBox.Checked == false)
				outFile.WriteLine("Analyzing: " + sFile[0]);
			else
				outFile.WriteLine("Analyzing: " + FolderBrowserDialog.SelectedPath);

			if (ReadingFolderCheckBox.Checked == true)
				ToolStripProgressBar.Maximum = Conversions.ToInteger(sFile.Length - 1);

			this.Update();
			var loopTo2 = sFile.Length - 1;

			// MAIN Block
			for (iTempFiles = 0; iTempFiles <= loopTo2; iTempFiles++)
			{
				inFile = new System.IO.StreamReader(sFile[iTempFiles], System.Text.Encoding.Default, true, 1);
				ToolStripStatusLabel.Text = sFile[iTempFiles];

				if (ReadingFolderCheckBox.Checked == false)
				{
					ToolStripProgressBar.Value = 0;
					ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
				}
				else
					ToolStripProgressBar.Value = Conversions.ToInteger(iTempFiles);

				while (inFile.EndOfStream == false)
				{
					if (ReadLikeLineCheckBox.Checked == false)
						sTemp = inFile.ReadLine();
					else
						sTemp = inFile.ReadToEnd();
					iLineFlag += 1;
					if (ReadingFolderCheckBox.Checked == false)
						ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);

					StatusStrip.Update();

					// Analyze type: 1
					if (UseMetod1CheckBox.Checked == true)
					{
						var loopTo3 = aSymbols1.Length - 1;
						for (iTemp = 0; iTemp <= loopTo3; iTemp++)
						{
							sTemp1 = Conversions.ToString(aSymbols1[iTemp][0]);
							sTemp2 = Conversions.ToString(aSymbols1[iTemp][1]);
							iFlag1 = sTemp.Length - sTemp.Replace(sTemp1, "").Length;
							iFlag2 = sTemp.Length - sTemp.Replace(sTemp2, "").Length;

							if (iFlag1 != iFlag2)
							{
								// Found symbol for checking
								if (ReadingFolderCheckBox.Checked == true)
									outFile.Write("File: " + System.IO.Path.GetFileName(sFile[iTempFiles]) + Constants.vbTab);
								else
									outFile.Write("Line: " + iLineFlag.ToString().PadRight(15) + Constants.vbTab);
								outFile.Write("required symbol: ");
								if (iFlag1 < iFlag2)
									outFile.WriteLine(sTemp1);
								else
									outFile.WriteLine(sTemp1);
							}
						}
					}

					// Analyze type: 2
					if (UseMetod2CheckBox.Checked == true)
					{
						var loopTo4 = aSymbols2.Length - 1;
						for (iTemp = 0; iTemp <= loopTo4; iTemp++)
						{
							sTemp1 = aSymbols2[iTemp];
							iFlag1 = sTemp.Length - sTemp.Replace(sTemp1, "").Length;

							if (iFlag1 / (double)2 != Conversions.Fix(iFlag1 / (double)2))
							{
								// Found symbol for checking
								if (ReadingFolderCheckBox.Checked == true)
									outFile.Write("File: " + System.IO.Path.GetFileName(sFile[iTempFiles]) + Constants.vbTab);
								else
									outFile.Write("Line: " + iLineFlag.ToString().PadRight(15) + Constants.vbTab);
								outFile.WriteLine("alone symbol: " + sTemp1);
							}
						}
					}
				}

				inFile.Close();
				iLineFlag = 0;
			}


			ToolStripProgressBar.Value = 0;

			outFile.WriteLine();
			outFile.WriteLine(Conversions.ToString(DateAndTime.Now) + " End");
			outFile.WriteLine();
			outFile.Close();

			MessageBox.Show("Complete");
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
