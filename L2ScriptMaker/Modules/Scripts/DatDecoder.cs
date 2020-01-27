using L2ScriptMaker.Extensions.VbCompatibleHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using L2ScriptMaker.Extensions;

namespace L2ScriptMaker.Modules.Scripts
{
	public partial class DatDecoder : Form
	{
		public DatDecoder()
		{
			InitializeComponent();
		}

		private struct L2Asm
		{
			public string Name;
			public string ReadData;
			public string ReadDataNum;
			public string StartTag;
			public string EndTag;
			public bool Unicode;
		}

		private void DatDecoder_Load(object sender, EventArgs e)
		{
			l2asmDDFPathTextBox.Text = System.IO.Directory.GetCurrentDirectory() + @"\DatProject\DDF";
			// DatProject\DDF
			if (System.IO.Directory.Exists(l2asmDDFPathTextBox.Text) == false)
			{
				MessageBox.Show("Not exist DDF folder. Define correct folder and try again.", "Wrong DDF", MessageBoxButtons.OK, MessageBoxIcon.Error);
				l2asmDDFPathTextBox.Text = System.IO.Directory.GetCurrentDirectory();
			}
			else
			{
				string[] DDFList;
				DDFList = System.IO.Directory.GetFiles(l2asmDDFPathTextBox.Text, "*.ddf", System.IO.SearchOption.AllDirectories);
				// DDFList = System.IO.Directory.GetFiles(l2asmDDFPathTextBox.Text.Replace(System.IO.Directory.GetCurrentDirectory & "\", ""), "*.ddf", IO.SearchOption.AllDirectories)
				if (DDFList.Length < 1)
				{
					MessageBox.Show("Not exist DDF files in this folder. Define correct folder and try again.", "Wrong DDF", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				int iTemp;
				var loopTo = DDFList.Length - 1;
				for (iTemp = 0; iTemp <= loopTo; iTemp++)
					DDFList[iTemp] = DDFList[iTemp].Replace(l2asmDDFPathTextBox.Text, "");

				DDFListComboBox.Items.Clear();
				DDFListComboBox.Items.AddRange(DDFList);
			}
		}

		private void l2asmDDFPathTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{

			// FolderBrowserDialog.SelectedPath = l2asmDDFPathTextBox.Text
			FolderBrowserDialog.Tag = "L2Asm DDF file folder (root path)(*.ddf)";
			if (FolderBrowserDialog.ShowDialog() != DialogResult.Cancel)
			{
				l2asmDDFPathTextBox.Text = FolderBrowserDialog.SelectedPath; // .Replace(System.IO.Directory.GetCurrentDirectory & "\", "")

				string[] DDFList;
				DDFList = System.IO.Directory.GetFiles(l2asmDDFPathTextBox.Text, "*.ddf", System.IO.SearchOption.AllDirectories);
				if (DDFList.Length == 0)
				{
					MessageBox.Show("Not exist DDF files in this folder. Define correct folder and try again.", "Wrong DDF", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				int iTemp;
				var loopTo = DDFList.Length - 1;
				for (iTemp = 0; iTemp <= loopTo; iTemp++)
					DDFList[iTemp] = DDFList[iTemp].Replace(l2asmDDFPathTextBox.Text, "");
				DDFListComboBox.Items.Clear();
				DDFListComboBox.Items.AddRange(DDFList);
			}
		}


		// ---------------------- L2Asm -> Dat ----------------------

		private void l2encInFileTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II client file (*.dat)|*.dat|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			l2encInFileTextBox.Text = OpenFileDialog.FileName;

			// Auto define for default values
			l2encOutFileTextBox.Text = System.IO.Path.GetFileName(l2encInFileTextBox.Text);
			l2encOutFileTextBox.Text = l2encInFileTextBox.Text.Replace(l2encOutFileTextBox.Text, "~" + l2encOutFileTextBox.Text);
			l2asmOutFileTextBox.Text = l2encOutFileTextBox.Text.Replace(".dat", ".txt");
		}

		private void l2encOutFileTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			SaveFileDialog.FileName = l2encOutFileTextBox.Text;
			SaveFileDialog.Filter = "Lineage II decoded client file (*.dat)|*.dat|All files|*.*";
			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			l2encOutFileTextBox.Text = SaveFileDialog.FileName;
		}

		private void l2asmOutFileTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			SaveFileDialog.FileName = l2asmOutFileTextBox.Text;
			SaveFileDialog.Filter = "Lineage II client file parsed as plain text (*.txt)|*.txt|All files|*.*";
			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			l2asmOutFileTextBox.Text = SaveFileDialog.FileName;
		}

		private void DecWithL2EncdecButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(DDFListComboBox.Text) | string.IsNullOrEmpty(l2encInFileTextBox.Text) | string.IsNullOrEmpty(l2encOutFileTextBox.Text))
			{
				MessageBox.Show("Not defined all parameters for decrypting", "Must define all params", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string sTemp;
			sTemp = "\"" + l2ancdecPathTextBox.Text + "\"" + " " + l2encParamsComboBox.Text + " ";
			sTemp = sTemp + "\"" + l2encInFileTextBox.Text + "\"" + " ";
			sTemp = sTemp + "\"" + l2encOutFileTextBox.Text + "\"";

			// MessageBox.Show(sTemp)
			Process.Start(sTemp);
			//Interaction.Shell(sTemp, AppWinStyle.NormalFocus, true);

			if (System.IO.File.Exists(l2encOutFileTextBox.Text) == false)
				MessageBox.Show("File not created. Change decrypt option and try again.", "File not created", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				MessageBox.Show("File saved success.", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void DecWithL2AsmButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(l2encOutFileTextBox.Text) | string.IsNullOrEmpty(DDFListComboBox.Text) | string.IsNullOrEmpty(l2asmOutFileTextBox.Text))
			{
				MessageBox.Show("Not defined all parameters for parsing", "Must define all params", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string sTemp;
			sTemp = "\"" + l2disasmPathTextBox.Text + "\"" + " -d " + "\"" + l2asmDDFPathTextBox.Text + DDFListComboBox.Text + "\"" + " ";
			sTemp = sTemp + "\"" + l2encOutFileTextBox.Text + "\"" + " ";
			sTemp = sTemp + "\"" + l2asmOutFileTextBox.Text + "\"";

			// Interaction.Shell(sTemp, AppWinStyle.NormalFocus, true);
			Process.Start(sTemp);

			if (System.IO.File.Exists(l2asmOutFileTextBox.Text) == false)
				MessageBox.Show("File not created. Perhaps you are select wrong DDF type for this file.", "File not created", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				MessageBox.Show("File saved success.", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		// ---------------------- L2Asm -> Dat -> Decrypt ----------------------

		private void TxtToL2asmUseStructureButton_Click(object sender, EventArgs e)
		{
			string inTxtFile;
			string outL2asmFile;
			string inStructFile;

			string sTemp;
			var aTemp = new string[1];
			int iTemp;
			var inStructure = new L2Asm[1];

			// --- Reading structure file ---
			OpenFileDialog.Title = "Select text file with structure definition...";
			OpenFileDialog.Filter = "Text files (*.cfg)|*.cfg|All files (*.*)|*.*";
			OpenFileDialog.FileName = "";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			inStructFile = OpenFileDialog.FileName;
			var inFile = new System.IO.StreamReader(inStructFile, System.Text.Encoding.Default, true, 1);
			if ((inFile.ReadLine() ?? "") != "[L2ScriptMaker: Plain file L2Asm Converter v2]")
			{
				MessageBox.Show("This file is not structure file. Select another file and try again.", "Wrong file", MessageBoxButtons.OK, MessageBoxIcon.Error);
				inFile.Close();
				return;
			}
			outL2asmFile = inFile.ReadLine();

			iTemp = -1;
			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine().Trim();
				if (!string.IsNullOrEmpty(sTemp))
				{
					iTemp += 1;
					Array.Resize(ref inStructure, iTemp + 1);
					try
					{
						aTemp = sTemp.Split(Conversions.ToChar(","));

						inStructure[iTemp].Name = aTemp[0];          // name of column
						inStructure[iTemp].ReadData = aTemp[1];      // read data from name param
						inStructure[iTemp].StartTag = aTemp[2];      // read data from name param
						inStructure[iTemp].EndTag = aTemp[3];        // read data from name param
						inStructure[iTemp].Unicode = Conversions.ToBoolean(aTemp[4]);        // read data from name param
					}
					catch (Exception ex)
					{
						MessageBox.Show("Bad structure in line " + Constants.vbNewLine + sTemp + Constants.vbNewLine + " Select another file and try again.", "Wrong file", MessageBoxButtons.OK, MessageBoxIcon.Error);
						inFile.Close();
						return;
					}
				}
			}
			// Array.IndexOf(inStructure, "asa")
			inFile.Close();

			// --- Reading structure file ---
			OpenFileDialog.Title = "Select file generated by L2Asm for reparsing...";
			OpenFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
			OpenFileDialog.FileName = "";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			inTxtFile = OpenFileDialog.FileName;
			outL2asmFile = System.IO.Path.GetDirectoryName(inTxtFile) + @"\" + outL2asmFile;

			if ((inTxtFile ?? "") == (outL2asmFile ?? ""))
			{
				MessageBox.Show("Source file cant be same as target file. Change source file name and try again.", "Bad source file name file", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (System.IO.File.Exists(outL2asmFile) == true)
			{
				if ((int)MessageBox.Show("Overwrite existing file?", "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (int)DialogResult.No)
				{
					MessageBox.Show("Output file '" + outL2asmFile + "' already exist.", "Output file exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			inFile = new System.IO.StreamReader(inTxtFile, System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter(outL2asmFile, false, System.Text.Encoding.GetEncoding(1250), 1);

			sTemp = "";
			var loopTo = inStructure.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				sTemp = sTemp + inStructure[iTemp].Name;
				if (iTemp < inStructure.Length - 1)
					sTemp = sTemp + Constants.vbTab;
			}
			// Write header for structure
			outFile.WriteLine(sTemp);

			sTemp = ""; string sTempParam = "";
			ProgressBar.Value = 0;
			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			string sTemp2;
			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				aTemp = sTemp.Split((char)9);
				sTemp2 = "";
				var loopTo1 = inStructure.Length - 1;
				for (iTemp = 0; iTemp <= loopTo1; iTemp++)
				{
					sTempParam = Libraries.GetNeedParamFromStr(sTemp, inStructure[iTemp].ReadData);
					if (!string.IsNullOrEmpty(inStructure[iTemp].StartTag))
						sTempParam = sTempParam.Replace(inStructure[iTemp].StartTag, "");
					if (!string.IsNullOrEmpty(inStructure[iTemp].StartTag))
						sTempParam = sTempParam.Replace(inStructure[iTemp].EndTag, "");
					if (inStructure[iTemp].Unicode == true)
					{
						if (sTempParam.Length > 0)
							sTempParam = sTempParam + @"\0";
						sTempParam = "a," + sTempParam;
					}
					sTemp2 = sTemp2 + sTempParam;
					if (iTemp < inStructure.Length - 1)
						sTemp2 = sTemp2 + Constants.vbTab;
				}
				outFile.WriteLine(sTemp2);
				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
			}
			inFile.Close();
			outFile.Close();
			ProgressBar.Value = 0;

			MessageBox.Show("Done", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}


		private void L2asmToTxtUseStructureButton_Click(object sender, EventArgs e)
		{
			string inL2AsmFile;
			string outGoodFile;
			string inStructFile;

			string sTemp;
			var aTemp = new string[1];
			int iTemp;
			var inStructure = new L2Asm[1];

			// --- Reading structure file ---
			OpenFileDialog.Title = "Select text file with structure definition...";
			OpenFileDialog.Filter = "Text files (*.cfg)|*.cfg|All files (*.*)|*.*";
			OpenFileDialog.FileName = "";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			inStructFile = OpenFileDialog.FileName;
			var inFile = new System.IO.StreamReader(inStructFile, System.Text.Encoding.Default, true, 1);
			if ((inFile.ReadLine() ?? "") != "[L2ScriptMaker: L2DisAsm to Plain file Converter v2]")
			{
				MessageBox.Show("This file is not structure file. Select another file and try again.", "Wrong file", MessageBoxButtons.OK, MessageBoxIcon.Error);
				inFile.Close();
				return;
			}
			outGoodFile = inFile.ReadLine();

			iTemp = -1;
			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				iTemp += 1;
				Array.Resize(ref inStructure, iTemp + 1);
				try
				{
					aTemp = sTemp.Split(Conversions.ToChar(","));
					inStructure[iTemp].Name = aTemp[0];
					inStructure[iTemp].ReadData = aTemp[1];
					inStructure[iTemp].ReadDataNum = aTemp[2];
					inStructure[iTemp].StartTag = aTemp[3];
					inStructure[iTemp].EndTag = aTemp[4];
					inStructure[iTemp].Unicode = Conversions.ToBoolean(aTemp[5]);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Bad structure in line " + Constants.vbNewLine + sTemp + Constants.vbNewLine + " Select another file and try again.", "Wrong file", MessageBoxButtons.OK, MessageBoxIcon.Error);
					inFile.Close();
					return;
				}
			}
			inFile.Close();

			// --- Reading structure file ---
			OpenFileDialog.Title = "Select file generated by L2Asm for reparsing...";
			OpenFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
			OpenFileDialog.FileName = "";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			inL2AsmFile = OpenFileDialog.FileName;
			outGoodFile = System.IO.Path.GetDirectoryName(inL2AsmFile) + @"\" + outGoodFile;

			if ((inL2AsmFile ?? "") == (outGoodFile ?? ""))
			{
				MessageBox.Show("Source file cant be same as target file. Change source file name and try again.", "Bad source file name file", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (System.IO.File.Exists(outGoodFile) == true)
			{
				if ((int)MessageBox.Show("Overwrite existing file?", "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (int)DialogResult.No)
				{
					MessageBox.Show("Output file '" + outGoodFile + "' already exist.", "Output file exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			inFile = new System.IO.StreamReader(inL2AsmFile, System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter(outGoodFile, false, System.Text.Encoding.Unicode, 1);

			ProgressBar.Value = 0;
			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			inFile.ReadLine();   // Read structure. Ignore it.
			string sTemp2;
			string sTemp3;
			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				aTemp = sTemp.Split((char)9);
				sTemp = ""; sTemp2 = ""; sTemp3 = "";
				var loopTo = inStructure.Length - 1;
				for (iTemp = 0; iTemp <= loopTo; iTemp++)
				{
					// inStructure(iTemp).Name

					if (inStructure[iTemp].Unicode == true)
					{
						sTemp3 = aTemp[Conversions.ToInteger(inStructure[iTemp].ReadDataNum)];
						if (sTemp3.StartsWith("a,") == true)
							sTemp3 = sTemp3.Remove(0, 2);
						if (sTemp3.EndsWith(@"\0") == true)
							sTemp3 = sTemp3.Remove(sTemp3.Length - 2, 2);
						aTemp[Conversions.ToInteger(inStructure[iTemp].ReadDataNum)] = sTemp3;
					}

					switch (inStructure[iTemp].ReadData)
					{
						case "0":
							{
								break;
							}

						case "1":
							{
								// 1 - only 'name'
								sTemp2 = inStructure[iTemp].Name;
								break;
							}

						case "2":
							{
								// 2 - only data (read data from l2asm generic file (0 - no, 1 - yes))
								sTemp2 = inStructure[iTemp].StartTag + aTemp[Conversions.ToInteger(inStructure[iTemp].ReadDataNum)] + inStructure[iTemp].EndTag;
								break;
							}

						case "3":
							{
								// 3 - name and data (name=[1221])
								sTemp2 = inStructure[iTemp].Name + "=" + inStructure[iTemp].StartTag + aTemp[Conversions.ToInteger(inStructure[iTemp].ReadDataNum)] + inStructure[iTemp].EndTag;
								break;
							}
					}
					if (iTemp < inStructure.Length - 1)
						sTemp = sTemp + sTemp2 + Constants.vbTab;
					else
						sTemp = sTemp + sTemp2;
					sTemp2 = "";
				}
				outFile.WriteLine(sTemp);
				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
			}
			inFile.Close();
			outFile.Close();
			ProgressBar.Value = 0;

			MessageBox.Show("Done", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void L2Adm2NormalButton_Click(object sender, EventArgs e)
		{
			string WorkFile;
			string sTemp;
			int iTemp;
			int iTempLength;
			string[] aStruct;
			string sHeader;
			string sHeaderEnder;

			OpenFileDialog.Title = "Select text file after L2Asm decoding...";
			OpenFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			WorkFile = OpenFileDialog.FileName;

			var inFile = new System.IO.StreamReader(WorkFile, System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter(System.IO.Path.GetDirectoryName(WorkFile) + @"\" + System.IO.Path.GetFileNameWithoutExtension(WorkFile) + "_new.txt", false, System.Text.Encoding.Unicode, 1);

			sTemp = System.IO.Path.GetFileNameWithoutExtension(WorkFile);
			sTemp = sTemp.Replace("dec-", "").Replace("-e", "");
			sHeader = sTemp + "_begin";
			sHeaderEnder = sTemp + "_end";

			// Read structure
			sTemp = inFile.ReadLine();
			aStruct = sTemp.Split((char)9);
			iTempLength = aStruct.Length;
			var aTemp = new string[iTempLength + 1];

			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ProgressBar.Value = 0;
			this.Update();
			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position); this.Update();
				aTemp = sTemp.Split((char)9);
				outFile.Write(sHeader);
				var loopTo = iTempLength - 1;
				for (iTemp = 0; iTemp <= loopTo; iTemp++)
				{
					if ((aTemp[iTemp].ToUpper() ?? "") != (aTemp[iTemp].ToLower() ?? ""))
						aTemp[iTemp] = "[" + aTemp[iTemp] + "]";
					outFile.Write(Constants.vbTab + aStruct[iTemp] + "=" + aTemp[iTemp]);
				}
				outFile.WriteLine(Constants.vbTab + sHeaderEnder);
			}

			outFile.Close();
			inFile.Close();

			ProgressBar.Value = 0;
			MessageBox.Show("Done");
		}

		// ---------------------- Dat -> L2Asm -> Encrypt ----------------------
		private void inl2asmToDatTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			OpenFileDialog.FileName = inl2asmToDatTextBox.Text;
			OpenFileDialog.Filter = "Lineage II plain text client file (*.txt)|*.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() != DialogResult.Cancel)
			{
				inl2asmToDatTextBox.Text = OpenFileDialog.FileName;

				// Auto define for default values
				outl2asmToDatTextBox.Text = inl2asmToDatTextBox.Text.Replace(".txt", ".dat");

				inl2encdecToDatTextBox.Text = System.IO.Path.GetFileName(outl2asmToDatTextBox.Text).Replace("~", "");
				inl2encdecToDatTextBox.Text = outl2asmToDatTextBox.Text.Replace(@"\~" + inl2encdecToDatTextBox.Text, @"\" + inl2encdecToDatTextBox.Text);
			}
		}

		private void outl2asmToDatTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			SaveFileDialog.FileName = outl2asmToDatTextBox.Text;
			SaveFileDialog.Filter = "Lineage II decoded client file (*.dat)|*.dat|All files|*.*";
			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			outl2asmToDatTextBox.Text = SaveFileDialog.FileName;
		}

		private void inl2encdecToDatTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			SaveFileDialog.FileName = inl2encdecToDatTextBox.Text;
			SaveFileDialog.Filter = "Lineage II decoded client file (*.dat)|*.dat|All files|*.*";
			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			inl2encdecToDatTextBox.Text = SaveFileDialog.FileName;
		}

		private void EncWithL2AsmButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(inl2asmToDatTextBox.Text) | string.IsNullOrEmpty(DDFListComboBox.Text) | string.IsNullOrEmpty(outl2asmToDatTextBox.Text))
			{
				MessageBox.Show("Not defined all parameters for packing", "Must define all params", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string sTemp;
			sTemp = "\"" + l2asmPathTextBox.Text + "\" " + TextBoxL2AsmAddComm.Text + " -d " + "\"" + l2asmDDFPathTextBox.Text + DDFListComboBox.Text + "\"" + " ";
			sTemp = sTemp + "\"" + inl2asmToDatTextBox.Text + "\"" + " ";
			sTemp = sTemp + "\"" + outl2asmToDatTextBox.Text + "\"";

			// Interaction.Shell(sTemp, AppWinStyle.NormalFocus, true);
			Process.Start(sTemp);

			if (System.IO.File.Exists(outl2asmToDatTextBox.Text) == false)
				MessageBox.Show("File not created. Perhaps you are select wrong DDF type for this file.", "File not created", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				MessageBox.Show("File saved success.", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void EncWithL2EncdecButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(outl2asmToDatTextBox.Text) | string.IsNullOrEmpty(inl2encdecToDatTextBox.Text))
			{
				MessageBox.Show("Not defined all parameters for encrypting", "Must define all params", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string sTemp;
			sTemp = "\"" + l2ancdecPathTextBox.Text + "\"" + " " + l2endecEncModeComboBox.Text + " " + l2endecEncMetodComboBox.Text + " ";
			sTemp = sTemp + "\"" + outl2asmToDatTextBox.Text + "\"" + " ";
			sTemp = sTemp + "\"" + inl2encdecToDatTextBox.Text + "\"";

			// MessageBox.Show(sTemp)
			// Interaction.Shell(sTemp, AppWinStyle.NormalFocus, true);
			Process.Start(sTemp);

			if (System.IO.File.Exists(inl2encdecToDatTextBox.Text) == false)
				MessageBox.Show("File not created. Change decrypt option and try again.", "File not created", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				MessageBox.Show("File saved success.", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		// ---------------------- End ----------------------

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void LoadDDFButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog.Filter = "L2Disasm text file (~*.txt)|*.txt|All files(*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			string sTemp;
			int iTemp;
			var aTemp = new string[51];

			sTemp = System.IO.Path.GetFileNameWithoutExtension(OpenFileDialog.FileName);
			if (sTemp.StartsWith("~") == true)
				sTemp = sTemp.Remove(0, 1);
			PlainFileNameTextBox.Text = sTemp + ".txt";
			HeadTextBox.Text = sTemp + "_begin";
			EndTextBox.Text = sTemp + "_end";

			DDFDataGridView.Rows.Clear();

			var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);
			sTemp = inFile.ReadLine().Trim();

			// First line -- Structure
			aTemp = sTemp.Split((char)9);
			var loopTo = aTemp.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
				DDFDataGridView.Rows.Add(aTemp[iTemp]);

			sTemp = inFile.ReadLine().Trim();
			inFile.Close();
			// Second line -- Unicode autodetect
			aTemp = sTemp.Split((char)9);
			var loopTo1 = aTemp.Length - 1;
			for (iTemp = 0; iTemp <= loopTo1; iTemp++)
			{
				if (aTemp[iTemp].StartsWith("a,") == true)
					DDFDataGridView[3, iTemp].Value = true;
			}

			MessageBox.Show("File structure loaded. Make required changes in structure and make Generate new config", "Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void MakeConfigsButton_Click(object sender, EventArgs e)
		{
			string sFolderToSave;
			string sFileName;
			System.IO.StreamWriter outFile;
			int iTemp;

			FolderBrowserDialog.SelectedPath = Application.StartupPath;
			if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sFolderToSave = FolderBrowserDialog.SelectedPath;
			sFileName = System.IO.Path.GetFileNameWithoutExtension(PlainFileNameTextBox.Text);

			// l2sm_l2asmtodat_castlename-e.cfg
			// l2sm_dattol2asm_castlename-e.cfg

			// Save L2DisAsm -> Plain cfg
			outFile = new System.IO.StreamWriter(sFolderToSave + @"\l2sm_l2disasmtotxt_" + sFileName + ".cfg", false, System.Text.Encoding.Default, 1);
			outFile.WriteLine("[L2ScriptMaker: L2DisAsm to Plain file Converter v2]");
			outFile.WriteLine(sFileName + ".txt");
			outFile.WriteLine(HeadTextBox.Text + ",1,,,,False");
			var loopTo = DDFDataGridView.Rows.Count - 2;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				outFile.Write(DDFDataGridView[0, iTemp].Value + ",3,");    // param name
				outFile.Write(Conversions.ToString(iTemp) + ",");    // counter
				outFile.Write(DDFDataGridView[1, iTemp].Value + ",");      // start symbol
				outFile.Write(DDFDataGridView[2, iTemp].Value + ",");      // end symbol
				outFile.WriteLine(DDFDataGridView[3, iTemp].FormattedValue.ToString());      // unicode? symbol
			}
			outFile.WriteLine(EndTextBox.Text + ",1,,,,False");
			outFile.Close();

			outFile = new System.IO.StreamWriter(sFolderToSave + @"\l2sm_txttol2asm_" + sFileName + ".cfg", false, System.Text.Encoding.Default, 1);
			outFile.WriteLine("[L2ScriptMaker: Plain file L2Asm Converter v2]");
			outFile.WriteLine("~" + sFileName + ".txt");
			var loopTo1 = DDFDataGridView.Rows.Count - 2;
			for (iTemp = 0; iTemp <= loopTo1; iTemp++)
			{
				outFile.Write(DDFDataGridView[0, iTemp].Value + ",");    // param name
				outFile.Write(DDFDataGridView[0, iTemp].Value + ",");    // param name
				outFile.Write(DDFDataGridView[1, iTemp].Value + ",");     // start symbol
				outFile.Write(DDFDataGridView[2, iTemp].Value + ","); // end symbol
				outFile.WriteLine(DDFDataGridView[3, iTemp].FormattedValue.ToString());        // unicode? symbol
			}
			outFile.Close();

			MessageBox.Show("File structure saved. Now you can use module L2DisAsm->Txt", "Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
