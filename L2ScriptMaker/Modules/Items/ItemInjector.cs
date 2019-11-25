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

namespace L2ScriptMaker.Modules.Items
{
	public partial class ItemInjector : Form
	{
		public ItemInjector()
		{
			InitializeComponent();
		}

		// Dim TabSymbol As String = Chr(9)

		private void Quit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void AiInjector_Load(object sender, EventArgs e)
		{
			SourceFile.Text = "";
			TargetFile.Text = "";
		}


		private void SplitButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II config (itemdata.txt)|itemdata.txt|All files (*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			else
				SourceFile.Text = OpenFileDialog.FileName;

			// Select folder to work
			if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
				return;

			string[] str;
			str = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath, "*.*", System.IO.SearchOption.AllDirectories);
			if (str.Length != 0 & OverwriteBox.Checked == false)
			{
				if ((int)MessageBox.Show("Source directory no empty! Continue?", "No empty directory", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == (int)DialogResult.No)
					return;
			}
			TargetFile.Text = FolderBrowserDialog.SelectedPath;

			// Initialization
			ProgressBar.Value = 0;
			var inFile = new System.IO.StreamReader(SourceFile.Text, System.Text.Encoding.Default, true, 1);

			string ReadStr;
			string[] ReadSplitStr;
			string FileName = String.Empty, FileDirName = String.Empty;

			while (inFile.BaseStream.Position != inFile.BaseStream.Length)
			{
				ReadStr = Strings.Replace(inFile.ReadLine(), Conversions.ToString((char)9), Conversions.ToString((char)32));

				// tabs and spaces correction
				while (Strings.InStr(ReadStr, "  ") != 0)
					ReadStr = Strings.Replace(ReadStr, "  ", Conversions.ToString((char)32));

				// fix for comments and empty string in itemdata
				if (ReadStr.Length == default(int))
					goto nextitem;
				if ((Strings.Mid(ReadStr, 1, 2) ?? "") == "//")
					goto nextitem;

				ReadSplitStr = ReadStr.Split((char)32);

				StatusBox.Text = "Please wait... Split item: " + ReadSplitStr[3];
				this.Refresh();

				switch (ReadSplitStr[0])
				{
					case "item_begin":
						{
							// error symbols correction
							ReadSplitStr[3] = Strings.Replace(ReadSplitStr[3], ":", "_");
							ReadSplitStr[3] = Strings.Replace(ReadSplitStr[3], "*", "_");
							ReadSplitStr[3] = Strings.Mid(ReadSplitStr[3], 2, Strings.Len(ReadSplitStr[3]) - 2);

							ReadSplitStr[2] = ReadSplitStr[2].PadLeft(5, Conversions.ToChar("0"));

							FileDirName = FolderBrowserDialog.SelectedPath + @"\item_begin\" + ReadSplitStr[2] + "-" + ReadSplitStr[3];
							FileName = ReadSplitStr[2] + "-" + ReadSplitStr[3] + ".txt";
							break;
						}

					case "set_begin":
						{
							ReadSplitStr[1] = ReadSplitStr[1].PadLeft(5, Conversions.ToChar("0"));
							FileDirName = FolderBrowserDialog.SelectedPath + @"\set_begin\" + ReadSplitStr[1];
							FileName = ReadSplitStr[1] + ".txt";
							break;
						}

					default:
						{
							MessageBox.Show("Unknown/bad file format for :" + Conversions.ToString((char)13) + Conversions.ToString((char)10) + Conversions.ToString((char)13) + Conversions.ToString((char)10) + ReadStr, "Unknown/bad file format", MessageBoxButtons.OK, MessageBoxIcon.Error);
							break;
							break;
						}
				}

				// FileDirName = FileDirName + "\" + ReadSplitStr(2) + "-" + ReadSplitStr(3) + "\" + ReadSplitStr(2) + "-" + ReadSplitStr(3) + ".txt"
				System.IO.Directory.CreateDirectory(FileDirName);

				System.IO.Stream oAiFile = new System.IO.FileStream(FileDirName + @"\" + FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
				var outAiData = new System.IO.StreamWriter(oAiFile, System.Text.Encoding.Unicode, 1);

				// == ART Correction ==
				SymbolCorrection(ReadStr);
				ReadStr = Strings.Replace(ReadStr, " = ", "=");
				ReadStr = Strings.Replace(ReadStr, Conversions.ToString((char)32), Conversions.ToString((char)9));

				outAiData.WriteLine(ReadStr);
				outAiData.Close();
			nextitem:
				;
				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position * 100 / (double)inFile.BaseStream.Length);
			}

			StatusBox.Text = "Splitting done.";
			ProgressBar.Value = 0;
			inFile.Close();
		}

		private void MergeButton_Click(object sender, EventArgs e)
		{
			string WorkDirName;

			// Select folder to work
			FolderBrowserDialog.Description = "Select where source file's with item/npc";
			if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
				return;

			SourceFile.Text = FolderBrowserDialog.SelectedPath;
			WorkDirName = FolderBrowserDialog.SelectedPath;

			// check file exist
			if (System.IO.File.Exists(FolderBrowserDialog.SelectedPath + @"\itemdata.txt") == true)
			{
				if ((int)MessageBox.Show("File exist in directory. Continue and overwrite?", "File exist", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == (int)DialogResult.No)
					return;
				else
					System.IO.File.Copy(FolderBrowserDialog.SelectedPath + @"\itemdata.txt", FolderBrowserDialog.SelectedPath + @"\itemdata.txt.bak", true);
			}
			TargetFile.Text = FolderBrowserDialog.SelectedPath + @"\itemdata.txt";

			System.IO.Stream oFile = new System.IO.FileStream(FolderBrowserDialog.SelectedPath + @"\itemdata.txt", System.IO.FileMode.Create, System.IO.FileAccess.Write);
			var outData = new System.IO.StreamWriter(oFile, System.Text.Encoding.Unicode, 1);

			int TempFileNum;
			string[] FileList;

			FileList = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath + @"\item_begin", "*.*", System.IO.SearchOption.AllDirectories);
			if (FileList.Length == 0)
			{
				MessageBox.Show("Source directory empty!", "Empty directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			for (TempFileNum = FileList.Length - 1; TempFileNum >= 0; TempFileNum += -1)
			{
				StatusBox.Text = "Merging file: " + System.IO.Path.GetFileName(FileList[TempFileNum]);
				this.Refresh();

				var inFile = new System.IO.StreamReader(FileList[TempFileNum], System.Text.Encoding.Default, true, 1);

				// == ART Correction ==
				string ReadStr;
				ReadStr = inFile.ReadLine();
				SymbolCorrection(ReadStr);
				ReadStr = Strings.Replace(ReadStr, " = ", "=");
				ReadStr = Strings.Replace(ReadStr, Conversions.ToString((char)32), Conversions.ToString((char)9));

				outData.WriteLine(ReadStr);
				inFile.Close();

				ProgressBar.Value = Conversions.ToInteger(TempFileNum * 100 / (double)FileList.Length);
			}


			// ====== Set begin =========
			FileList = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath + @"\set_begin", "*.*", System.IO.SearchOption.AllDirectories);
			if (FileList.Length == 0)
			{
				MessageBox.Show("Source directory empty!", "Empty directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			for (TempFileNum = FileList.Length - 1; TempFileNum >= 0; TempFileNum += -1)
			{
				StatusBox.Text = "Merging file: " + FileList[TempFileNum];
				this.Refresh();

				var inFile = new System.IO.StreamReader(FileList[TempFileNum], System.Text.Encoding.Default, true, 1);
				outData.WriteLine(inFile.ReadLine());
				inFile.Close();

				ProgressBar.Value = Conversions.ToInteger(TempFileNum * 100 / (double)FileList.Length);
			}


			outData.Close();
			ProgressBar.Value = 0;
			StatusBox.Text = "Merging done.";
		}

		private void Inject_Click(object sender, EventArgs e)
		{

			// Define fix file
			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II item fix file (*.txt)|*.txt|All files (*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			else
				SourceFile.Text = OpenFileDialog.FileName;

			// Define target file to fix
			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II itemdata config (itemdata.txt)|itemdata.txt|All files (*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			else
				TargetFile.Text = OpenFileDialog.FileName;

			byte InjectStatus = Conversions.ToByte(0);
			string WorkDataDir = System.IO.Path.GetDirectoryName(SourceFile.Text);
			string SrcFile = SourceFile.Text;
			string TarFile = TargetFile.Text;

			// fix from
			var inSrcFile = new System.IO.StreamReader(SrcFile, System.Text.Encoding.Default, true, 1);
			// fix to 
			System.IO.File.Copy(TarFile, TarFile + ".bak", true);
			var inTarFile = new System.IO.StreamReader(TarFile + ".bak", System.Text.Encoding.Default, true, 1);

			System.IO.Stream oTarFile = new System.IO.FileStream(TarFile, System.IO.FileMode.Create, System.IO.FileAccess.Write);
			var outTarData = new System.IO.StreamWriter(oTarFile, System.Text.Encoding.Unicode);

			StatusBox.Text = "Finding string to fix...";
			this.Refresh();

			string TempFixStr;
			string[] SrcID;
			string TempStr;
			string[] TarID;

			TempFixStr = Strings.Replace(inSrcFile.ReadLine(), Conversions.ToString((char)9), " ");
			if ((Strings.Mid(TempFixStr, 1, 9) ?? "") == "set_begin")
			{
				MessageBox.Show("Injection for Set item no supported. Use Merge", "Set no support", MessageBoxButtons.OK, MessageBoxIcon.Error);
				inSrcFile.Close();
				inTarFile.Close();
				outTarData.Close();
				return;
			}
			// tabs and spaces correction
			while (Strings.InStr(TempFixStr, "  ") != 0)
				TempFixStr = Strings.Replace(TempFixStr, "  ", " ");
			SrcID = TempFixStr.Split((char)32);

			while (inTarFile.BaseStream.Position != inTarFile.BaseStream.Length)
			{
				TempStr = Strings.Replace(inTarFile.ReadLine(), Conversions.ToString((char)9), " ");
				// tabs and spaces correction
				while (Strings.InStr(TempStr, "  ") != 0)
					TempStr = Strings.Replace(TempStr, "  ", " ");
				TarID = TempStr.Split((char)32);

				if ((SrcID[2] ?? "") == (TarID[2] ?? ""))
				{
					if ((TempFixStr ?? "") == (TempStr ?? ""))
						// nothing
						outTarData.WriteLine(Strings.Replace(TempStr, " ", Conversions.ToString((char)9)));
					else if ((int)MessageBox.Show("Different item define. ID is: " + TarID[2] + Conversions.ToString((char)13) + Conversions.ToString((char)10) + "Original string :" + Conversions.ToString((char)13) + Conversions.ToString((char)10) + TempStr + Conversions.ToString((char)13) + Conversions.ToString((char)10) + "New string :" + Conversions.ToString((char)13) + Conversions.ToString((char)10) + TempFixStr + Conversions.ToString((char)13) + Conversions.ToString((char)10) + "Write new fix?", "", MessageBoxButtons.YesNo) == (int)DialogResult.No)
					{
						outTarData.WriteLine(Strings.Replace(TempStr, " ", Conversions.ToString((char)9)));
						InjectStatus = Conversions.ToByte(3);
					}
					else
					{
						outTarData.WriteLine(Strings.Replace(TempFixStr, " ", Conversions.ToString((char)9)));
						InjectStatus = Conversions.ToByte(1);
						outTarData.WriteLine(inTarFile.ReadToEnd());
					}
				}
				else
					outTarData.WriteLine(Strings.Replace(TempStr, " ", Conversions.ToString((char)9)));

				ProgressBar.Value = Conversions.ToInteger(inTarFile.BaseStream.Position * 100 / (double)inTarFile.BaseStream.Length);
			}

			if (InjectStatus == 0)
			{
				outTarData.WriteLine(Strings.Replace(TempFixStr, " ", Conversions.ToString((char)9)));
				InjectStatus = Conversions.ToByte(2);
			}

			inSrcFile.Close();
			inTarFile.Close();
			outTarData.Close();

			StatusBox.Text = "Injection done...";
			ProgressBar.Value = 0;

			switch (InjectStatus)
			{
				case var @case when @case == Conversions.ToByte(0
			   ):
					{
						MessageBox.Show("Big error. Send me your file to test", "Nothing", MessageBoxButtons.OK, MessageBoxIcon.Error);
						break;
					}

				case var case1 when case1 == Conversions.ToByte(1
		 ):
					{
						MessageBox.Show("Injection done. Fix integrity to file. Old code has been replaced", "Old code replaced", MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					}

				case var case2 when case2 == Conversions.ToByte(2
		 ):
					{
						MessageBox.Show("Injection done. Fix integrity to file. New code has been added", "New code added", MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					}

				case var case3 when case3 == Conversions.ToByte(3
		 ):
					{
						MessageBox.Show("Injection done. Nothing changed", "Nothing changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					}
			}
		}

		public string SymbolCorrection(string SourceStr)
		{
			// tabs and spaces correction
			while (Strings.InStr(SourceStr, "  ") != 0)
				SourceStr = Strings.Replace(SourceStr, "  ", " ");
			return SourceStr;
		}
	}
}
