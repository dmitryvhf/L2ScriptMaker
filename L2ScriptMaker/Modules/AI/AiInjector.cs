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

namespace L2ScriptMaker.Modules.AI
{
	public partial class AiInjector : Form
	{
		public AiInjector()
		{
			InitializeComponent();
		}

		private void Inject_Click(object sender, EventArgs e)
		{
			// Define Ai.obj file
			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II AI config (ai.obj)|*.obj|All files (*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			else
				AiFile.Text = OpenFileDialog.FileName;

			// Dim AIFixDataDir As String = FolderBrowserDialog.SelectedPath
			string AIFixDataDir;
			// Dim AIFixFiles() As String = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath, "*.txt")
			var AIFixFiles = new string[1];

			// Define fix file
			if (FixOneClassBox.Checked == false)
			{
				FolderBrowserDialog.SelectedPath = System.IO.Path.GetDirectoryName(AiFile.Text);
				FolderBrowserDialog.Description = "Select folder with AI.obj fixes (requiered .txt files)";
				if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
					return;
				else
					FixFile.Text = FolderBrowserDialog.SelectedPath;
				AIFixFiles = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath, "*.txt",
					System.IO.SearchOption.AllDirectories);
				AIFixDataDir = FolderBrowserDialog.SelectedPath;
			}
			else
			{
				OpenFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(AiFile.Text);
				OpenFileDialog.Tag = "Select folder with AI.obj fixes (requiered .txt files)";
				OpenFileDialog.Filter = "Ai.obj fixed class file (*.txt)|*.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				else
					FixFile.Text = System.IO.Path.GetDirectoryName(OpenFileDialog.FileName);
				AIFixFiles[0] = OpenFileDialog.FileName;
				AIFixDataDir = FixFile.Text;
			}

			string AIDataDir = System.IO.Path.GetDirectoryName(AiFile.Text);
			string AIObjFile = AiFile.Text;
			var AIFixClasses = new string[AIFixFiles.Length - 1 + 1];

			byte InjectStatus = Conversions.ToByte(0);
			string TempStr;
			string[] NpcName = new string[5];
			int iTemp;

			System.IO.StreamReader inFixFile;
			var loopTo = AIFixFiles.Length - 1;
			// Checking fix files on valid
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				inFixFile = new System.IO.StreamReader(AIFixFiles[iTemp], System.Text.Encoding.Default, true, 1);

				TempStr = inFixFile.ReadLine();
				if (TempStr.StartsWith("class ") == false)
				{
					MessageBox.Show("File '" + System.IO.Path.GetFileName(AIFixFiles[iTemp]) + "' is not AI class",
						"File is not fix", MessageBoxButtons.OK, MessageBoxIcon.Error);
					inFixFile.Close();
					return;
				}

				NpcName = TempStr.Split((char) 32);
				AIFixClasses[iTemp] = NpcName[2];

				inFixFile.Close();
			}

			System.IO.File.Copy(AiFile.Text,
				AIDataDir + @"\" + (System.IO.Path.GetFileNameWithoutExtension(AiFile.Text) + ".bak"), true);
			var inAiFile = new System.IO.StreamReader(
				AIDataDir + @"\" + (System.IO.Path.GetFileNameWithoutExtension(AiFile.Text) + ".bak"),
				System.Text.Encoding.Default, true, 1);
			var oAiFile = new System.IO.FileStream(AiFile.Text, System.IO.FileMode.Create, System.IO.FileAccess.Write);
			var outAiData = new System.IO.StreamWriter(oAiFile, System.Text.Encoding.Unicode);
			var oAiLogData = new System.IO.StreamWriter(
				AIDataDir + @"\" + (System.IO.Path.GetFileNameWithoutExtension(AiFile.Text) + ".log"), true,
				System.Text.Encoding.Unicode, 1);

			oAiLogData.WriteLine("--------------------------------------------" + Constants.vbNewLine +
			                     "L2ScriptMaker AI.obj Injector check and fix.");
			oAiLogData.WriteLine("Start at :" + DateAndTime.Now.ToString() + Constants.vbNewLine);

			string TempInAiStr;
			ProgressBar.Maximum = Conversions.ToInteger(inAiFile.BaseStream.Length);
			ProgressBar.Value = 0;


			while (inAiFile.EndOfStream != true) // (inAiFile.BaseStream.Position > inAiFile.BaseStream.Length)
			{
				TempStr = inAiFile.ReadLine();

				// Enter to class
				if (TempStr.StartsWith("class ") == true)
				{
					// Checking for available fix
					NpcName = TempStr.Split((char) 32);
					iTemp = Array.IndexOf(AIFixClasses, NpcName[2]);
					if (iTemp != -1)
					{
						StatusBox.Text = "Injection...";

						inFixFile = new System.IO.StreamReader(AIFixFiles[iTemp], System.Text.Encoding.Default, true,
							1);
						TempInAiStr = inFixFile.ReadLine();
						InjectStatus = Conversions.ToByte(1);

						if ((TempStr ?? "") != (TempInAiStr ?? ""))
						{
							// If name correct but class different
							if ((int) MessageBox.Show(
								    "Found different description for class in old file:" +
								    Conversions.ToString((char) 13) + Conversions.ToString((char) 10) + TempStr +
								    Conversions.ToString((char) 13) + Conversions.ToString((char) 10) + "new ai:" +
								    Conversions.ToString((char) 13) + Conversions.ToString((char) 10) + TempInAiStr,
								    "Different description" + Conversions.ToString((char) 13) +
								    Conversions.ToString((char) 10) + Conversions.ToString((char) 13) +
								    Conversions.ToString((char) 10) + "Write new ai?", MessageBoxButtons.YesNo) ==
							    (int) DialogResult.No)

								InjectStatus = Conversions.ToByte(0);
						}

						// Main Injection
						if (InjectStatus == 1)
						{
							StatusBox.Text = "Fixing in " +
							                 System.IO.Path.GetFileNameWithoutExtension(AIFixClasses[iTemp] + "...");
							outAiData.WriteLine(TempInAiStr);
							outAiData.Write(inFixFile.ReadToEnd());
							oAiLogData.WriteLine("Fixing class: " + NpcName[2]);
						}
						else
						{
						}

						// find end of fixed class
						do
						{
							TempStr = inAiFile.ReadLine();
							if (InjectStatus == 0)
								outAiData.WriteLine(TempStr);
						} while (TempStr.StartsWith("class_end") == false);

						AIFixClasses[iTemp] = "";
					}
					else
						outAiData.WriteLine(TempStr);

					InjectStatus = Conversions.ToByte(0);
					StatusBox.Text = "Check for new updates...";
				}
				else
					outAiData.WriteLine(TempStr);

				ProgressBar.Value = Conversions.ToInteger(inAiFile.BaseStream.Position);
				this.Update();
			}

			outAiData.WriteLine();

			// Append new AI if exist
			StatusBox.Text = "Checking for available new classes to append.";
			var loopTo1 = AIFixClasses.Length - 1;
			for (iTemp = 0; iTemp <= loopTo1; iTemp++)
			{
				if (!string.IsNullOrEmpty(AIFixClasses[iTemp]))
				{
					// Last class crack fix
					inFixFile = new System.IO.StreamReader(AIFixFiles[iTemp], System.Text.Encoding.Default, true, 1);
					outAiData.WriteLine(inFixFile.ReadToEnd());
					outAiData.WriteLine();
					inFixFile.Close();
					oAiLogData.WriteLine("Add new class :" +
					                     System.IO.Path.GetFileNameWithoutExtension(AIFixClasses[iTemp]));
				}
			}

			oAiLogData.WriteLine(Constants.vbNewLine + "End at :" + DateAndTime.Now.ToString() + Constants.vbNewLine);
			ProgressBar.Value = 0;
			StatusBox.Text = "Done.";
			MessageBox.Show("Work complete. Read log file for full information.", "Complete", MessageBoxButtons.OK,
				MessageBoxIcon.Information);
			inAiFile.Close();
			outAiData.Close();
			oAiLogData.Close();
		}

		private void SplitButton_Click(object sender, EventArgs e)
		{
			string sPath;
			FolderBrowserDialog.SelectedPath = Application.StartupPath;
			FolderBrowserDialog.Tag = "Select empty folder for data uploading";
			StatusBox.Text = "Select emptry folder for data uploading";
			if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sPath = FolderBrowserDialog.SelectedPath;

			string[] aTemp;
			aTemp = System.IO.Directory.GetFiles(sPath);
			if (aTemp.Length > 0)
			{
				MessageBox.Show("Folder not empty. Select different folder or clean directory and try again",
					"Folder not empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II Server Intelligence file (ai.obj)|ai.obj|All files|*.*";
			StatusBox.Text = "Select AI.obj file";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			StatusBox.Text = "Start uploading classes to folder tree";
			if (!string.IsNullOrEmpty(SplitClassTextBox.Text) & CheckBoxUseList.Enabled == false)
				StatusBox.Text = "Searching class '" + SplitClassTextBox.Text + "' for uploading to file...";
			else if (CheckedListBox.CheckedItems.Count > 0 & CheckBoxUseList.Enabled == true)
			{
				StatusBox.Text = "Searching classes for uploading to file...";
				SplitClassTextBox.Text = "";
			}
			else
			{
				MessageBox.Show("Nothing to uploading...");
				return;
			}

			var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);
			System.IO.StreamWriter outFile;
			string sTemp;
			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();

				if (sTemp.StartsWith("class ") == true)
				{
					// Founded class definition
					// class(0) 1(1) default_npc(2) :() (null)(3)
					aTemp = sTemp.Replace(": ", "").Split((char) 32);

					if (string.IsNullOrEmpty(SplitClassTextBox.Text) & CheckBoxUseList.Enabled == false |
					    !string.IsNullOrEmpty(SplitClassTextBox.Text) & CheckBoxUseList.Enabled == false &
					    (aTemp[2] ?? "") == (SplitClassTextBox.Text ?? "") | CheckedListBox.CheckedItems.Count > 0 &
					    CheckBoxUseList.Enabled == true & CheckedListBox.CheckedItems.IndexOf(aTemp[2]) != -1)
					{
						if (System.IO.Directory.Exists(sPath + @"\" + aTemp[3]) == false)
							System.IO.Directory.CreateDirectory(sPath + @"\" + aTemp[3]);
						StatusBox.Text = "Uploading class: " + aTemp[2];
						outFile = new System.IO.StreamWriter(sPath + @"\" + aTemp[3] + @"\" + aTemp[2] + ".txt", false,
							System.Text.Encoding.Unicode, 1);
						while (sTemp.StartsWith("class_end") == false)
						{
							outFile.WriteLine(sTemp);
							sTemp = inFile.ReadLine();
							ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
						}

						outFile.WriteLine(sTemp);
						outFile.Close();

						if (!string.IsNullOrEmpty(SplitClassTextBox.Text) &
						    (aTemp[2] ?? "") == (SplitClassTextBox.Text ?? ""))
							break;
					}
				}

				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				this.Update();
			}

			inFile.Close();
			ProgressBar.Value = 0;
			MessageBox.Show("Uploading successfuly completed", "Complete", MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}

		private void MergeButton_Click(object sender, EventArgs e)
		{
			string sPath;
			FolderBrowserDialog.SelectedPath = Application.StartupPath;
			FolderBrowserDialog.Tag = "Select folder with data (AI class in text file)";
			StatusBox.Text = "Select folder with data (AI class in text file)";
			if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sPath = FolderBrowserDialog.SelectedPath;

			string newAiObj;
			SaveFileDialog.FileName = "";
			SaveFileDialog.Filter = "Lineage II Intelligence File (ai.obj)|ai.obj|All files|*.*";
			SaveFileDialog.OverwritePrompt = true;
			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			newAiObj = SaveFileDialog.FileName;

			System.IO.StreamWriter outLog = null;
			if (MergeCheckBox2.Checked == true)
				outLog = new System.IO.StreamWriter("L2ScriptMaker_AISplitter.log", true, System.Text.Encoding.Unicode,
					1);

			// --- Logger ---
			if (MergeCheckBox2.Checked == true)
				outLog.WriteLine("L2ScriptMaker AI.obj Generator");
			if (MergeCheckBox2.Checked == true)
				outLog.WriteLine(DateAndTime.Now.ToString() + " Start process...");
			if (MergeCheckBox2.Checked == true)
				outLog.WriteLine("");

			string[] aClassFiles;
			aClassFiles = System.IO.Directory.GetFiles(sPath, "*.txt", System.IO.SearchOption.AllDirectories);
			if (aClassFiles.Length == 0)
			{
				MessageBox.Show("Folder empty. Select different folder.", "Folder empty", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			// --- Logger ---
			if (MergeCheckBox2.Checked == true)
				outLog.WriteLine(
					"Loaded " + Conversions.ToString(aClassFiles.Length) + " classes" + Constants.vbNewLine);
			var aClassName = new string[aClassFiles.Length + 1];
			var aParentClass = new string[aClassFiles.Length + 1];
			var aClassDependence = new string[aClassFiles.Length + 1];
			var aClassOrder = new int[aClassFiles.Length + 1];
			string[] aTemp;
			string sTemp;
			int iClassCount = 0;

			// ---- STEP 1: loading data about class and creating array's for working ---

			ProgressBar.Maximum = Conversions.ToInteger(aClassFiles.Length);
			ProgressBar.Value = 0;

			System.IO.StreamReader inFile;

			int iTemp;
			var loopTo = aClassFiles.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				ProgressBar.Value = iTemp;
				StatusBox.Text = "Loading: " + System.IO.Path.GetFileName(aClassFiles[iTemp]);
				this.Update();

				inFile = new System.IO.StreamReader(aClassFiles[iTemp], System.Text.Encoding.Default, true, 1);
				try
				{
					// File can be empty, permission denied and etc
					sTemp = inFile.ReadLine().Trim();
				}
				catch (Exception ex)
				{
					if (MergeCheckBox2.Checked == true)
						outLog.WriteLine("File '" + System.IO.Path.GetFileName(aClassFiles[iTemp]) +
						                 "' crash with exception " + ex.Message);
					else
						MessageBox.Show(
							"File '" + System.IO.Path.GetFileName(aClassFiles[iTemp]) + "' crash with exception " +
							ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
					inFile.Close();
					goto CritExit;
				}

				if (string.IsNullOrEmpty(sTemp))
				{
					// --- Logger ---
					if (MergeCheckBox2.Checked == true)
					{
						outLog.WriteLine("File '" + System.IO.Path.GetFileName(aClassFiles[iTemp]) +
						                 "' empty or have null header");
						outLog.WriteLine("Exit");
					}
					else
						MessageBox.Show(
							"File '" + System.IO.Path.GetFileName(aClassFiles[iTemp]) + "' empty or have null header",
							"Bad input file", MessageBoxButtons.OK, MessageBoxIcon.Error);

					inFile.Close();
					goto CritExit;
				}

				aTemp = sTemp.Replace(": ", "").Split((char) 32);
				// class(0) 1(1) default_npc(2) :() (null)(3)
				aClassName[iTemp] = aTemp[2];
				aParentClass[iTemp] = aTemp[3];
				// aClassDependence(iTemp) = ""
				aClassOrder[iTemp] = -1;
			}

			ProgressBar.Value = 0;

			// ---- STEP 2: find all dependence ---
			int Cursor = 0;
			bool ParentValid = true;

			ProgressBar.Maximum = Conversions.ToInteger(aClassFiles.Length - 1);

			int iTemp2 = 0;
			var loopTo1 = aClassFiles.Length - 1;
			for (iTemp = 0; iTemp <= loopTo1; iTemp++)
			{
				StatusBox.Text = "Searching all dependence for: " + aClassName[iTemp];
				this.Update();

				// find class tree
				Cursor = iTemp; // Array.IndexOf(aClassName, aParentClass(iTemp))
				aClassDependence[iTemp] = aClassName[iTemp];
				while (Cursor != -1)
				{
					sTemp = aParentClass[Cursor];
					aClassDependence[iTemp] = aClassDependence[iTemp] + "|" + sTemp;
					Cursor = Array.IndexOf(aClassName, sTemp);
					if ((sTemp ?? "") != "(null)" & Cursor == -1)
					{
						// Class have not Parent Class
						if (MergeCheckBox2.Checked == true)
							outLog.WriteLine("Class '" + aClassName[iTemp] + "' not have parent class '" + sTemp +
							                 "'.");
						else
							MessageBox.Show("Class '" + aClassName[iTemp] + "' not have parent class '" + sTemp + "'.",
								"No parent class", MessageBoxButtons.OK, MessageBoxIcon.Error);
						ParentValid = false;
					}
				}

				if (ParentValid == true)
				{
					aTemp = aClassDependence[iTemp].Split(Conversions.ToChar("|"));
					aClassOrder[iTemp] = aTemp.Length;
				}
				else
				{
					aClassOrder[iTemp] = 1;
					ParentValid = true;
				}

				ProgressBar.Value = iTemp;
			}

			ProgressBar.Value = 0;

			// ---- STEP 3: saving AI.obj ---

			var outAI = new System.IO.StreamWriter(newAiObj, false, System.Text.Encoding.Unicode, 1);

			// Write AI.obj default header
			outAI.WriteLine("SizeofPointer 8");
			outAI.WriteLine("SharedFactoryVersion 429");
			outAI.WriteLine("NPCHVersion 413");
			outAI.WriteLine("NASCVersion 235");
			outAI.WriteLine("NPCEventHVersion 125");
			outAI.WriteLine("Debug 0" + Constants.vbNewLine);

			iTemp = 2; // Start finding for (null) - ID 2
			ProgressBar.Maximum = Conversions.ToInteger(aClassOrder.Length);

			while (iTemp != -1)
			{
				StatusBox.Text = "Writing " + Conversions.ToString(iTemp - 1) + " dependence tree level...";
				this.Update();

				Cursor = iTemp;
				Cursor = Array.IndexOf(aClassOrder, iTemp);
				if (Cursor == -1)
					break;
				while (Cursor != -1)
				{
					ProgressBar.Value = Cursor;

					// Write class to AI.obj
					inFile = new System.IO.StreamReader(aClassFiles[Cursor], System.Text.Encoding.Default, true, 1);
					outAI.WriteLine(inFile.ReadToEnd());
					inFile.Close();
					iClassCount += 1;

					// Find next class with equal dependence level
					Cursor = Array.IndexOf(aClassOrder, iTemp, Cursor + 1);
				}

				iTemp += 1;
			}

			// Writing classes without dependence
			if (MergeCheckBox1.Checked == true)
			{
				StatusBox.Text = "Writing classes without dependence...";
				this.Update();

				iTemp = 1;
				Cursor = 1;
				Cursor = Array.IndexOf(aClassOrder, iTemp);

				if (Cursor != -1)
				{
					outAI.WriteLine("//----------------------------------------------------------");
					outAI.WriteLine("// ATTENTION!! Here classes without parent class dependence!");
					outAI.WriteLine("//----------------------------------------------------------");
					outAI.WriteLine();

					while (Cursor != -1)
					{
						ProgressBar.Value = Cursor;

						// Write class to AI.obj
						inFile = new System.IO.StreamReader(aClassFiles[Cursor], System.Text.Encoding.Default, true, 1);
						outAI.WriteLine(inFile.ReadToEnd());
						inFile.Close();
						iClassCount += 1;

						// Find next class with equal dependence level
						Cursor = Array.IndexOf(aClassOrder, iTemp, Cursor + 1);
					}
				}
			}

			outAI.Close();
			if (MergeCheckBox2.Checked == true)
			{
				outLog.WriteLine(Constants.vbNewLine + "Saved " + Conversions.ToString(iClassCount) + " classes" +
				                 Constants.vbNewLine);
			}
			CritExit:

			ProgressBar.Value = 0;
			StatusBox.Text = "Complete";
			// --- Logger ---
			if (MergeCheckBox2.Checked == true)
				outLog.WriteLine(Constants.vbNewLine + DateAndTime.Now + " Work complete" + Constants.vbNewLine);
			if (MergeCheckBox2.Checked == true)
				outLog.Close();


			MessageBox.Show("New Ai.obj file gathered complete. Statistics:"
			                + Constants.vbNewLine + "Loaded: " + Conversions.ToString(aClassFiles.Length) + " classes"
			                + Constants.vbNewLine + "Saved:  " + Conversions.ToString(iClassCount) + " classes" +
			                Constants.vbNewLine);
		}


		private void Quit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void ButtonLoadClassList_Click(object sender, EventArgs e)
		{
			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II AI config (ai.obj)|*.obj|All files (*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			string sAIFile;
			sAIFile = OpenFileDialog.FileName;


			var inFile = new System.IO.StreamReader(sAIFile, System.Text.Encoding.Default, true, 1);

			int iTemp = 0;
			string sTemp = "";
			string[] aTemp = null;

			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ProgressBar.Value = 0;

			CheckedListBox.SuspendLayout();

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				this.Update();

				if (sTemp.StartsWith("class ") == true)
				{
					// class 1 party_private : party_private_param
					aTemp = sTemp.Split((char) 32);
					CheckedListBox.Items.Add(aTemp[2]);
				}
			}

			ProgressBar.Value = 0;
			CheckedListBox.ResumeLayout();

			if (CheckedListBox.Items.Count > 0)
				CheckBoxUseList.Enabled = true;
		}


		private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if ((int) e.NewValue == (int) CheckState.Checked)
			{
				if (CheckedListBox.CheckedItems.Count == 0)
				{
					CheckBoxUseList.Checked = true;
					SplitClassTextBox.Enabled = false;
				}
			}

			if (e.NewValue == (int) CheckState.Unchecked)
			{
				if (CheckedListBox.CheckedItems.Count == 1)
				{
					CheckBoxUseList.Checked = false;
					SplitClassTextBox.Enabled = true;
				}
			}
		}

		private void ButtonFindSelect_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(TextBoxFindSelect.Text))
			{
				MessageBox.Show("Nothing to searching.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int iTemp = CheckedListBox.FindString(TextBoxFindSelect.Text);
			if (iTemp != -1)
			{
				CheckedListBox.SetItemCheckState(iTemp, CheckState.Checked);
				CheckedListBox.SetSelected(iTemp, true);
			}
			else
				MessageBox.Show("Nothing founded.", "Nothing", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void ButtonFindExact_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(TextBoxFindSelect.Text))
			{
				MessageBox.Show("Nothing to searching.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int iTemp = CheckedListBox.FindString(TextBoxFindSelect.Text, CheckedListBox.SelectedIndex);
			if (iTemp != -1)
				// CheckedListBox.SetItemCheckState(iTemp, CheckState.Checked)
				CheckedListBox.SetSelected(iTemp, true);
			else
				MessageBox.Show("Nothing founded.", "Nothing", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}