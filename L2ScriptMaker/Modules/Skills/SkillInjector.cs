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

namespace L2ScriptMaker.Modules.Skills
{
	public partial class SkillInjector : Form
	{
		public SkillInjector()
		{
			InitializeComponent();
		}

		// Dim TabSymbol As String = " "
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

		private void Inject_Click(object sender, EventArgs e)
		{

			// MessageBox.Show("Please, use Merge function for it", "Use Merge", MessageBoxButtons.OK, MessageBoxIcon.Information)
			// Exit Sub

			System.IO.StreamReader inFile;
			System.IO.StreamReader inInjectFile = null;
			System.IO.StreamWriter outFile;
			System.IO.StreamWriter outLogFile;

			string sTemp;
			int iTemp;

			int iInjectValue = -1;
			var aInject1 = new int[1];  // skill id
			var aInject2 = new bool[1]; // skill file name

			string sSkillData;
			string sSkillInjectData;
			// Dim sTempFolder As String

			// FolderBrowserDialog.SelectedPath = System.Environment.CurrentDirectory

			OpenFileDialog.InitialDirectory = Environment.CurrentDirectory;

			StatusBox.Text = "Definition for working objects...";
			OpenFileDialog.Filter = "Lineage II Skill Config (skilldata.txt)|skilldata*.txt|All files (*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sSkillData = OpenFileDialog.FileName;

			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II inject skills file (.txt)|*.txt|All files (*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sSkillInjectData = OpenFileDialog.FileName;

			if (System.IO.Directory.Exists("~l2smtemp"))
				System.IO.Directory.Delete("~l2smtemp", true);
			System.IO.Directory.CreateDirectory("~l2smtemp");

			outLogFile = new System.IO.StreamWriter("l2scriptmaker_skillinjector.log", true, System.Text.Encoding.Unicode, 1);
			outLogFile.WriteLine("L2ScriptMaker: SkillData Injector module");
			outLogFile.WriteLine(Conversions.ToString(DateAndTime.Now) + " Start" + Constants.vbNewLine);

			outLogFile.WriteLine("Fixed file :" + Constants.vbTab + sSkillData);
			outLogFile.WriteLine("Inject file:" + Constants.vbTab + sSkillInjectData);

			// START: UPLOAD Inject skills to file's
			inFile = new System.IO.StreamReader(sSkillInjectData, System.Text.Encoding.Default, true, 1);
			ProgressBar.Value = 0;
			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			StatusBox.Text = "Loading and preparing inject file...";
			this.Update();

			outLogFile.WriteLine();

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine().Trim();
				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);

				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{
					iTemp = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "skill_id"));
					if (Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "level")) == 1 & System.IO.File.Exists(@"~l2smtemp\" + Libraries.GetNeedParamFromStr(sTemp, "skill_id") + ".txt") == true)
					{
						outLogFile.WriteLine("[ATTENTION] Skill ID: " + Conversions.ToString(iTemp) + Constants.vbTab + "name=" + Libraries.GetNeedParamFromStr(sTemp, "skill_name") + Constants.vbTab);
						MessageBox.Show("Inject skill already exist. Skill: " + Libraries.GetNeedParamFromStr(sTemp, "skill_id") + ":" + Libraries.GetNeedParamFromStr(sTemp, "skill_name") + Constants.vbNewLine + "Continue loading?", "Inject exist", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						ProgressBar.Value = 0;
						StatusBox.Text = "Aborted...";
						if (System.IO.Directory.Exists("~l2smtemp"))
							System.IO.Directory.Delete("~l2smtemp", true);
						inFile.Close();
						outLogFile.WriteLine(Constants.vbNewLine + "Aborted" + Constants.vbNewLine + Conversions.ToString(DateAndTime.Now) + " End" + Constants.vbNewLine);
						outLogFile.Close();
						return;
					}

					outFile = new System.IO.StreamWriter(@"~l2smtemp\" + Libraries.GetNeedParamFromStr(sTemp, "skill_id") + ".txt", true, System.Text.Encoding.Unicode, 1);
					outFile.WriteLine(sTemp);
					outFile.Close();

					if (Array.IndexOf(aInject1, iTemp) == -1)
					{
						iInjectValue = iInjectValue + 1;
						if (aInject1.Length <= iInjectValue)
						{
							Array.Resize(ref aInject1, iInjectValue + 1);
							Array.Resize(ref aInject2, iInjectValue + 1);
						}
						aInject1[iInjectValue] = iTemp;
						aInject2[iInjectValue] = false;
					}
				}
			}
			inFile.Close();
			ProgressBar.Value = 0;
			// END: UPLOAD Inject skills to file

			// START2: INJECT skills to SkillData
			System.IO.File.Copy(sSkillData, sSkillData + ".bak", true);
			// inFile = New System.IO.StreamReader(sSkillData, System.Text.Encoding.Default, True, 1)
			inFile = new System.IO.StreamReader(sSkillData + ".bak", System.Text.Encoding.Default, true, 1);
			outFile = new System.IO.StreamWriter(sSkillData, false, System.Text.Encoding.Unicode, 1);

			outLogFile.WriteLine();

			ProgressBar.Value = 0;
			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			StatusBox.Text = "Inject skills to skilldata file...";
			this.Update();

			var iLastFixSkill = default(int);

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine().Trim();
				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);

				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{
					iTemp = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "skill_id"));
					if (Array.IndexOf(aInject1, iTemp) != -1)
					{
						if (iLastFixSkill != iTemp)
						{
							outLogFile.WriteLine("[UPDATED  ] Skill ID: " + Conversions.ToString(iTemp) + Constants.vbTab + "name=" + Libraries.GetNeedParamFromStr(sTemp, "skill_name"));

							inInjectFile = new System.IO.StreamReader(@"~l2smtemp\" + Conversions.ToString(iTemp) + ".txt", System.Text.Encoding.Default, true, 1);
							sTemp = inInjectFile.ReadToEnd().Trim();
							outFile.WriteLine(sTemp);
							sTemp = "";
							inInjectFile.Close();

							// DUMMY Cycle
							iLastFixSkill = iTemp;
							aInject2[Array.IndexOf(aInject1, iTemp)] = true;
						}
						else
							sTemp = "";
					}
				}
				if (!string.IsNullOrEmpty(sTemp))
					outFile.WriteLine(sTemp);
			}
			ProgressBar.Value = 0;
			inFile.Close();
			// END2: INJECT skills to SkillData

			// START3: Uploading left injections
			StatusBox.Text = "Inject New skills to skilldata file...";
			this.Update();
			if (CheckBoxWriteNew.Checked == true)
			{
				iTemp = Array.IndexOf(aInject2, false);
				while (iTemp != -1)
				{
					inInjectFile = new System.IO.StreamReader(@"~l2smtemp\" + Conversions.ToString(aInject1[iTemp]) + ".txt", System.Text.Encoding.Default, true, 1);
					sTemp = inInjectFile.ReadToEnd().Trim();
					outFile.WriteLine(sTemp);

					outLogFile.WriteLine("[ADDED    ] Skill ID: " + Conversions.ToString(aInject1[iTemp]) + Constants.vbTab + "name=" + Libraries.GetNeedParamFromStr(sTemp, "skill_name"));

					sTemp = "";
					inInjectFile.Close();
					aInject2[iTemp] = true;

					iTemp = Array.IndexOf(aInject2, false);
				}
			}
			// END3: Uploading left injections

			outFile.Close();
			outLogFile.WriteLine(Constants.vbNewLine + Conversions.ToString(DateAndTime.Now) + " End" + Constants.vbNewLine);
			outLogFile.Close();

			if (System.IO.Directory.Exists("~l2smtemp"))
				System.IO.Directory.Delete("~l2smtemp", true);

			StatusBox.Text = "Done.";
			MessageBox.Show("Done.");
		}

		private void SplitButton_Click(object sender, EventArgs e)
		{

			// Define file
			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II config (skilldata.txt)|skilldata.txt|All files (*.*)|*.*";
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
			var Digit = new[] { Conversions.ToChar("1"), Conversions.ToChar("2"), Conversions.ToChar("3"), Conversions.ToChar("4"), Conversions.ToChar("5"), Conversions.ToChar("6"), Conversions.ToChar("6"), Conversions.ToChar("7"), Conversions.ToChar("8"), Conversions.ToChar("9"), Conversions.ToChar("0") };
			// Dim DigitPos As Integer
			string FileName, FileDirName;
			string SkillName, SkillLvl, SkillID;

			while (inFile.BaseStream.Position != inFile.BaseStream.Length)
			{
				ReadStr = SymbolCorrection(Strings.Replace(inFile.ReadLine(), Conversions.ToString((char)9), " "));
				// SkillData or not
				if ((Strings.Mid(ReadStr, 1, 11) ?? "") != "skill_begin")
				{
					MessageBox.Show("File format is not npcdata. Invalid record is: " + Conversions.ToString((char)13)
+ Conversions.ToString((char)13) + ReadStr, "Invalid format", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				SkillName = GetNeedParamFromStr(ReadStr, "skill_name");
				SkillName = Strings.Mid(SkillName, 2, Strings.Len(SkillName) - 2);
				SkillID = GetNeedParamFromStr(ReadStr, "skill_id");
				SkillLvl = GetNeedParamFromStr(ReadStr, "level");

				SkillID = SkillID.PadLeft(4, Conversions.ToChar("0"));

				if (SkillName.IndexOfAny(Digit, Strings.Len(SkillName) - 3) > 0)
					SkillName = Strings.Mid(SkillName, 1, SkillName.IndexOfAny(Digit, Strings.Len(SkillName) - 3));
				FileName = SkillID + "-" + SkillName + ".txt";

				FileDirName = FolderBrowserDialog.SelectedPath + @"\skill_begin\" + SkillID + "-" + SkillName;


				StatusBox.Text = "Please wait... Split skill: " + SkillName;
				this.Refresh();

				// == ART Correction ==
				ReadStr = SymbolCorrection(ReadStr);
				ReadStr = Strings.Replace(ReadStr, " = ", "=");
				ReadStr = Strings.Replace(ReadStr, Conversions.ToString((char)32), Conversions.ToString((char)9));

				int TempRemPos = Strings.InStr(ReadStr, "/*");
				string Temp1;
				while (TempRemPos != 0)
				{
					Temp1 = Strings.Mid(ReadStr, TempRemPos, Strings.InStr(TempRemPos, ReadStr, "*/") - TempRemPos + 2);
					ReadStr = Strings.Replace(ReadStr, Temp1, Strings.Replace(Temp1, Conversions.ToString((char)9), Conversions.ToString((char)32)));
					TempRemPos = Strings.InStr(TempRemPos + 1, ReadStr, "/*");
				}


				// If last Skill or not?
				if (System.IO.Directory.Exists(FileDirName) == false)
				{
					System.IO.Directory.CreateDirectory(FileDirName);
					System.IO.Stream oAiFile = new System.IO.FileStream(FileDirName + @"\" + FileName, System.IO.FileMode.Create);
					var outAiData = new System.IO.StreamWriter(oAiFile, System.Text.Encoding.Unicode, 1);
					outAiData.WriteLine(ReadStr);
					outAiData.Close();
				}
				else
				{
					System.IO.Stream oAiFile = new System.IO.FileStream(FileDirName + @"\" + FileName, System.IO.FileMode.Append, System.IO.FileAccess.Write);
					var outAiData = new System.IO.StreamWriter(oAiFile, System.Text.Encoding.Unicode, 1);
					outAiData.WriteLine(ReadStr);
					outAiData.Close();
				}

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
			if (System.IO.File.Exists(FolderBrowserDialog.SelectedPath + @"\skilldata.txt") == true)
			{
				if ((int)MessageBox.Show("File skilldata.txt exist in directory. Continue and overwrite?", "File exist", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == (int)DialogResult.No)
					return;
				else
					System.IO.File.Copy(FolderBrowserDialog.SelectedPath + @"\skilldata.txt", FolderBrowserDialog.SelectedPath + @"\skilldata.txt.bak", true);
			}
			TargetFile.Text = FolderBrowserDialog.SelectedPath + @"\skilldata.txt";

			System.IO.Stream oFile = new System.IO.FileStream(FolderBrowserDialog.SelectedPath + @"\skilldata.txt", System.IO.FileMode.Create, System.IO.FileAccess.Write);
			var outData = new System.IO.StreamWriter(oFile, System.Text.Encoding.Unicode, 1);

			int TempFileNum;
			string[] FileList;

			// Dim TempFileList() As String

			FileList = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath + @"\skill_begin", "*.*", System.IO.SearchOption.AllDirectories);
			if (FileList.Length == 0)
			{
				MessageBox.Show("Source directory empty!", "Empty directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string TempStr;
			for (TempFileNum = FileList.Length - 1; TempFileNum >= 0; TempFileNum += -1)
			{
				StatusBox.Text = "Merging file: " + System.IO.Path.GetFileName(FileList[TempFileNum]);
				this.Refresh();

				var inFile = new System.IO.StreamReader(FileList[TempFileNum], System.Text.Encoding.Default, true, 1);
				while (inFile.BaseStream.Position != inFile.BaseStream.Length)
				{
					TempStr = inFile.ReadLine();

					// == ART Correction ==
					TempStr = SymbolCorrection(TempStr);
					TempStr = Strings.Replace(TempStr, " = ", "=");
					TempStr = Strings.Replace(TempStr, Conversions.ToString((char)32), Conversions.ToString((char)9));

					int TempRemPos = Strings.InStr(TempStr, "/*");
					string Temp1;
					while (TempRemPos != 0)
					{
						Temp1 = Strings.Mid(TempStr, TempRemPos, Strings.InStr(TempRemPos, TempStr, "*/") - TempRemPos + 2);
						TempStr = Strings.Replace(TempStr, Temp1, Strings.Replace(Temp1, Conversions.ToString((char)9), Conversions.ToString((char)32)));
						TempRemPos = Strings.InStr(TempRemPos + 1, TempStr, "/*");
					}

					if (!string.IsNullOrEmpty(TempStr))
						outData.WriteLine(TempStr);
				}
				inFile.Close();

				ProgressBar.Value = Conversions.ToInteger(TempFileNum * 100 / (double)FileList.Length);
			}

			outData.Close();
			ProgressBar.Value = 0;
			StatusBox.Text = "Merging done.";
		}

		public string GetNeedParamFromStr(string SourceStr, string MaskStr)
		{
			string GetNeedParamFromStrRet = default(string);

			// Update 15.01.2007 00:05

			int FirstPos, SecondPos;
			GetNeedParamFromStrRet = "";

			// PreWorking string
			SourceStr = SourceStr.Replace(Conversions.ToString((char)9), " ");
			SourceStr = SourceStr.Replace(" = ", "=");
			while (Strings.InStr(SourceStr, "  ") > 0)
				SourceStr = SourceStr.Replace("  ", " ");

			FirstPos = Strings.InStr(1, SourceStr, MaskStr + "=");
			if (FirstPos == default(int))
			{
				GetNeedParamFromStrRet = "";
				return GetNeedParamFromStrRet;
			}
			FirstPos += MaskStr.Length;
			SecondPos = FirstPos + 1;
			SecondPos = Strings.InStr(SecondPos, SourceStr, " ");
			if (SecondPos == 0)
				SecondPos = SourceStr.Length;

			GetNeedParamFromStrRet = Strings.Trim(Strings.Mid(SourceStr, FirstPos + 1, SecondPos - FirstPos));
			return GetNeedParamFromStrRet;
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
