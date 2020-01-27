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

namespace L2ScriptMaker.Modules.AI
{
	public partial class AiFixer : Form
	{
		public AiFixer()
		{
			InitializeComponent();
		}

		private string[] FuncArr1 = new string[1001]; // id
		private string[] FuncArr2 = new string[1001]; // handler
		private string[] FuncArr3 = new string[1001]; // name

		private void ButtonFetch_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(ComboBoxFixType.Text))
			{
				MessageBox.Show("Select target to fix", "Select target", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string AiFile;
			string AiFuncFile;

			OpenFileDialog.Filter = "Lineage II AI file|*.obj|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			AiFile = OpenFileDialog.FileName;

			OpenFileDialog.Filter = "Lineage II AI " + ComboBoxFixType.Text + " fix file|*.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			AiFuncFile = OpenFileDialog.FileName;

			string TempStr;

			// Loading all func in table
			var TempArr = new string[3];
			int ArrMarker = -1;

			var inAiFix = new System.IO.StreamReader(AiFuncFile, System.Text.Encoding.Default, true, 1);

			if ((inAiFix.ReadLine() ?? "") != ("[" + ComboBoxFixType.Text + "]" ?? ""))
			{
				MessageBox.Show("Wrong file type. Waiting list for '" + ComboBoxFixType.Text + "'. Select valid file",
					"Wrong fix file", MessageBoxButtons.OK, MessageBoxIcon.Error);
				inAiFix.Close();
				return;
			}

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inAiFix.BaseStream.Length);
			ToolStripProgressBar.Value = 0;
			while (inAiFix.EndOfStream != true)
			{
				TempStr = inAiFix.ReadLine().Trim();

				if (!string.IsNullOrEmpty(TempStr) & TempStr.StartsWith("//") == false)
				{
					if ((ComboBoxFixType.Text ?? "") == "func_call")
						TempStr = TempStr.Replace(",", "|");
					TempArr = TempStr.Split((char) 124); // 124 - |

					ArrMarker += 1;
					FuncArr1[ArrMarker] = TempArr[0]; // id
					FuncArr2[ArrMarker] =
						TempArr[1]; // marker ([QUEST_ACCEPTED,default], [0,1,2], [QUEST_ACCEPTED,default])
					FuncArr3[ArrMarker] = TempArr[2]; // name (fetch_i (creature), func (ShowPage), event (704))

					ToolStripProgressBar.Value =
						Conversions.ToInteger(inAiFix.BaseStream.Length / (double) inAiFix.BaseStream.Position * 100);
				}

				this.Update();
			}

			inAiFix.Close();
			ToolStripProgressBar.Value = 0;

			// Work with ai.obj
			System.IO.File.Copy(AiFile,
				System.IO.Path.GetDirectoryName(AiFile) + @"\" + System.IO.Path.GetFileNameWithoutExtension(AiFile) +
				".bak", true);
			var inAi = new System.IO.StreamReader(
				System.IO.Path.GetDirectoryName(AiFile) + @"\" + System.IO.Path.GetFileNameWithoutExtension(AiFile) +
				".bak", System.Text.Encoding.Default, true, 1);
			var outAi = new System.IO.StreamWriter(AiFile, false, System.Text.Encoding.Unicode, 1);
			var outAiLog = new System.IO.StreamWriter(
				System.IO.Path.GetDirectoryName(AiFile) + @"\" + System.IO.Path.GetFileNameWithoutExtension(AiFile) +
				".log", LogOverwriteCheckBox.Checked, System.Text.Encoding.Unicode, 1);

			outAiLog.WriteLine("L2ScriptMaker AI.obj check and fix."
			                   + Constants.vbNewLine + DateAndTime.Now.ToString() + Constants.vbNewLine + "Work with " +
			                   ComboBoxFixType.Text + Constants.vbNewLine);

			string sTemp;
			int iTemp;

			// check controls
			string ClassNameMarker = "";
			string HandlerNameMarker = "";
			string LastPushConstMarker = "";

			long LineNum = 1;

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inAi.BaseStream.Length);
			ToolStripProgressBar.Value = 0;

			while (inAi.EndOfStream != true)
			{
				TempStr = inAi.ReadLine();
				// TempStr = TempStr.Trim
				LineNum += 1;

				ToolStripProgressBar.Value = Conversions.ToInteger(inAi.BaseStream.Position);
				StatusStrip.Update();
				this.Update();

				if (TempStr.StartsWith("class ") == true)
					ClassNameMarker = TempStr;

				if (TempStr.StartsWith("handler ") == true)
					HandlerNameMarker = TempStr.Remove(0, Strings.InStr(TempStr, "//") + 2).Trim();

				if (Strings.InStr(6, TempStr, "//") != 0 & Strings.InStr(TempStr, ComboBoxFixType.Text) == 0)
					// If InStr(6, TempStr, "push_event") <> 0 And (ComboBoxFixType.Text = "func_call" Or ComboBoxFixType.Text = "fetch_i") Then
					// push_event      //  myself
					// push_const 704
					// add
					// fetch_i //  c_ai1
					// push_const 384
					// add
					// fetch_i //  name
					// push_const 104

					// Write previous line
					// outAi.WriteLine(TempStr)
					// TempStr = inAi.ReadLine
					// LastPushConstMarker = TempStr.Replace(Chr(9), Chr(32)).Replace("push_const", "").Trim

					LastPushConstMarker = Strings.Mid(TempStr, Strings.InStr(TempStr, "//") + 2,
						TempStr.Length - (Strings.InStr(TempStr, "//") + 1)).Trim();

				if (Strings.InStr(TempStr, ComboBoxFixType.Text) != 0 & TempStr.Trim().StartsWith("//") == false &
				    Strings.InStr(5, TempStr, "//") != 0)
				{
					switch (ComboBoxFixType.Text)
					{
						case "fetch_i":
						{
							// fetch_i // param2
							// push_const 2272

							// Write previous line
							outAi.WriteLine(TempStr);

							// Define name for fetch_i
							sTemp = Strings.Mid(TempStr, Strings.InStr(TempStr, "//") + 2,
								TempStr.Length - (Strings.InStr(TempStr, "//") + 1)).Trim();

							iTemp = Array.IndexOf(FuncArr3, sTemp);
							if (iTemp == -1)
							{
								// MessageBox.Show(ComboBoxFixType.Text + " not found in table!" + vbNewLine + TempStr, "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error)
								outAiLog.WriteLine(Constants.vbNewLine + "Line: " + Conversions.ToString(LineNum) +
								                   Constants.vbTab + "Class: " + ClassNameMarker + Constants.vbTab +
								                   "Handler: " + HandlerNameMarker);
								outAiLog.WriteLine(">>>>>> Not found :" + Constants.vbNewLine + TempStr +
								                   Constants.vbNewLine);
								break;
							}

							TempStr = inAi.ReadLine();
							LineNum += 1;

							if (Strings.InStr(TempStr, "push_const") == 0)
							{
								outAiLog.WriteLine(Constants.vbNewLine + "Line: " + Conversions.ToString(LineNum) +
								                   Constants.vbTab + "Class: " + ClassNameMarker + Constants.vbTab +
								                   "Handler: " + HandlerNameMarker);
								outAiLog.WriteLine(ComboBoxFixType.Text +
								                   " definition failed. Waiting push_const next after " +
								                   ComboBoxFixType.Text + Constants.vbNewLine + TempStr);
								outAi.WriteLine(TempStr);
								inAi.Close();
								outAi.Close();
								outAiLog.Close();
								MessageBox.Show(
									"Line: " + Conversions.ToString(LineNum) + Constants.vbTab +
									(ComboBoxFixType.Text + " definition failed. Waiting push_const next after " +
									 ComboBoxFixType.Text + Constants.vbNewLine + TempStr), "Definition failed",
									MessageBoxButtons.OK, MessageBoxIcon.Error);
								break;
							}

							iTemp = FindIndex(sTemp, LastPushConstMarker);
							if (iTemp == -1)
							{
								iTemp = FindIndex(sTemp, HandlerNameMarker);

								if (iTemp == -1)
								{
									iTemp = FindIndex(sTemp, "default");
									if (iTemp == -1)
									{
										outAi.WriteLine(TempStr);
										outAiLog.WriteLine(Constants.vbNewLine + "Line: " +
										                   Conversions.ToString(LineNum) + Constants.vbTab + "Class: " +
										                   ClassNameMarker + Constants.vbTab + "Handler: " +
										                   HandlerNameMarker);
										outAiLog.WriteLine("Warning! Required 'default' for '" + sTemp + "'. Ignored.");
										outAiLog.WriteLine("Debug info:" + Constants.vbNewLine + "Fixed class: " +
										                   ClassNameMarker
										                   + Constants.vbNewLine + "Fixed handler: " + HandlerNameMarker
										                   + Constants.vbNewLine + "Last push_const: " +
										                   LastPushConstMarker);
										break;
									}
								}
							}


							if ((TempStr.Trim() ?? "") != ("push_const " + FuncArr1[iTemp] ?? ""))
							{
								outAiLog.WriteLine("Fix to: '" + FuncArr3[iTemp] + "'"
								                   + Constants.vbNewLine + "Fixed class: " + ClassNameMarker
								                   + Constants.vbNewLine + "Fixed handler: " + HandlerNameMarker
								                   + Constants.vbNewLine + "Last push_const: " + LastPushConstMarker);
								outAiLog.WriteLine("Line: " + Conversions.ToString(LineNum) + Constants.vbTab +
								                   "Class: " + ClassNameMarker + Constants.vbTab + "Handler: " +
								                   HandlerNameMarker);
								outAiLog.WriteLine("Fix as:" + TempStr + " --> " + "push_const " + FuncArr1[iTemp] +
								                   Constants.vbNewLine);

								TempStr = Conversions.ToString((char) 9) + "push_const " + FuncArr1[iTemp];
							}

							LastPushConstMarker = sTemp;
							break;
						}

						case "push_event":
						{
							// push_event // myself
							// push_const 704

							// Write previous line
							outAi.WriteLine(TempStr);

							// Define name for push_event
							sTemp = Strings.Mid(TempStr, Strings.InStr(TempStr, "//") + 2,
								TempStr.Length - (Strings.InStr(TempStr, "//") + 1)).Trim();

							iTemp = Array.IndexOf(FuncArr3, sTemp);
							if (iTemp == -1)
							{
								outAiLog.WriteLine(Constants.vbNewLine + "Line: " + Conversions.ToString(LineNum) +
								                   Constants.vbTab + "Class: " + ClassNameMarker + Constants.vbTab +
								                   "Handler: " + HandlerNameMarker);
								outAiLog.WriteLine(">>>>>> Not found :" + Constants.vbNewLine + TempStr +
								                   Constants.vbNewLine);
								break;
							}

							TempStr = inAi.ReadLine();
							LineNum += 1;

							if (Strings.InStr(TempStr, "push_const") == 0)
							{
								outAiLog.WriteLine(Constants.vbNewLine + "Line: " + Conversions.ToString(LineNum) +
								                   Constants.vbTab + "Class: " + ClassNameMarker + Constants.vbTab +
								                   "Handler: " + HandlerNameMarker);
								outAiLog.WriteLine(ComboBoxFixType.Text +
								                   " definition failed. Waiting push_const next after " +
								                   ComboBoxFixType.Text + Constants.vbNewLine + TempStr);
								outAi.WriteLine(TempStr);
								inAi.Close();
								outAi.Close();
								outAiLog.Close();
								MessageBox.Show(
									"Line: " + Conversions.ToString(LineNum) + Constants.vbTab +
									(ComboBoxFixType.Text + " definition failed. Waiting push_const next after " +
									 ComboBoxFixType.Text + Constants.vbNewLine + TempStr), "Definition failed",
									MessageBoxButtons.OK, MessageBoxIcon.Error);
								break;
							}

							iTemp = FindIndex(sTemp, LastPushConstMarker);
							if (iTemp == -1)
							{
								iTemp = FindIndex(sTemp, HandlerNameMarker);

								if (iTemp == -1)
								{
									iTemp = FindIndex(sTemp, "default");
									if (iTemp == -1)
									{
										outAi.WriteLine(TempStr);
										outAiLog.WriteLine(Constants.vbNewLine + "Line: " +
										                   Conversions.ToString(LineNum) + Constants.vbTab + "Class: " +
										                   ClassNameMarker + Constants.vbTab + "Handler: " +
										                   HandlerNameMarker);
										outAiLog.WriteLine("Warning! Required 'default' for '" + sTemp + "'. Ignored.");
										outAiLog.WriteLine("Debug info:" + Constants.vbNewLine + "Fixed class: " +
										                   ClassNameMarker
										                   + Constants.vbNewLine + "Fixed handler: " + HandlerNameMarker
										                   + Constants.vbNewLine + "Last push_const: " +
										                   LastPushConstMarker);
										break;
									}
								}
							}

							if ((TempStr.Trim() ?? "") != ("push_const " + FuncArr1[iTemp] ?? ""))
							{
								outAiLog.WriteLine("Fix to: '" + FuncArr3[iTemp] + "'"
								                   + Constants.vbNewLine + "Fixed class: " + ClassNameMarker
								                   + Constants.vbNewLine + "Fixed handler: " + HandlerNameMarker
								                   + Constants.vbNewLine + "Last push_const: " + LastPushConstMarker);
								outAiLog.WriteLine(Constants.vbNewLine + "Line: " + Conversions.ToString(LineNum) +
								                   Constants.vbTab + "Class: " + ClassNameMarker + Constants.vbTab +
								                   "Handler: " + HandlerNameMarker);
								outAiLog.WriteLine("Fix as:" + TempStr + " --> " + "push_const " + FuncArr1[iTemp] +
								                   Constants.vbNewLine);

								TempStr = Conversions.ToString((char) 9) + "push_const " + FuncArr1[iTemp];
							}

							LastPushConstMarker = FuncArr1[iTemp];
							break;
						}

						case "func_call":
						{
							sTemp = Strings.Mid(TempStr, Strings.InStr(TempStr, "func["),
								Strings.InStr(TempStr, "]") - Strings.InStr(TempStr, "func[") + 1);
							iTemp = Array.IndexOf(FuncArr3, sTemp);

							if (iTemp == -1)
							{
								outAiLog.WriteLine(Constants.vbNewLine + "Line: " + Conversions.ToString(LineNum) +
								                   Constants.vbTab + "Class: " + ClassNameMarker + Constants.vbTab +
								                   "Handler: " + HandlerNameMarker);
								outAiLog.WriteLine("Func not found in table!" + Constants.vbNewLine + TempStr,
									"Func_call not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
								inAi.Close();
								outAi.Close();
								outAiLog.Close();
								MessageBox.Show(
									"Line: " + Conversions.ToString(LineNum) + Constants.vbTab +
									"Func not found in table!" + Constants.vbNewLine + TempStr, "Func_call not found",
									MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}

							iTemp = FindIndex(sTemp, LastPushConstMarker);
							if (iTemp == -1)
							{
								iTemp = FindIndex(sTemp, HandlerNameMarker);

								if (iTemp == -1)
								{
									iTemp = FindIndex(sTemp, "default");
									if (iTemp == -1)
									{
										outAi.WriteLine(TempStr);
										outAiLog.WriteLine(Constants.vbNewLine + "Line: " +
										                   Conversions.ToString(LineNum) + Constants.vbTab + "Class: " +
										                   ClassNameMarker + Constants.vbTab + "Handler: " +
										                   HandlerNameMarker);
										outAiLog.WriteLine("Warning! Required 'default' for '" + sTemp + "'. Ignored.");
										outAiLog.WriteLine("Debug info:" + Constants.vbNewLine + "Fixed class: " +
										                   ClassNameMarker
										                   + Constants.vbNewLine + "Fixed handler: " + HandlerNameMarker
										                   + Constants.vbNewLine + "Last push_const: " +
										                   LastPushConstMarker);
										break;
									}
								}
							}

							if ((Strings.Mid(TempStr, Strings.InStr(TempStr, "func_call ") + 10,
									     Strings.InStr(TempStr, "// ") - Strings.InStr(TempStr, "func_call ") - 10)
								     .Trim() ?? "") != (FuncArr1[iTemp] ?? ""))
							{
								outAiLog.WriteLine(Constants.vbNewLine + "Line: " + Conversions.ToString(LineNum) +
								                   Constants.vbTab + "Class: " + ClassNameMarker + Constants.vbTab +
								                   "Handler: " + HandlerNameMarker);
								outAiLog.WriteLine("Fix to: '" + FuncArr3[iTemp] + "'"
								                   + Constants.vbNewLine + "Fixed class: " + ClassNameMarker
								                   + Constants.vbNewLine + "Fixed handler: " + HandlerNameMarker
								                   + Constants.vbNewLine + "Fix " +
								                   Strings.Mid(TempStr, Strings.InStr(TempStr, "func_call ") + 10,
									                   Strings.InStr(TempStr, "// ") -
									                   Strings.InStr(TempStr, "func_call ") - 10).Trim() + " to " +
								                   FuncArr1[iTemp] + Constants.vbNewLine);

								TempStr = TempStr.Replace(
									Strings.Mid(TempStr, Strings.InStr(TempStr, "func_call ") + 10,
											Strings.InStr(TempStr, "// ") - Strings.InStr(TempStr, "func_call ") - 10)
										.Trim(), FuncArr1[iTemp]);
							}

							break;
						}

						case "handler":
						{
							// handler 3 138   //  TALKED
							// HandlerNameMarker

							// Define name for push_event
							// sTemp = Mid(TempStr, (InStr(TempStr, "//") + 2), TempStr.Length - (InStr(TempStr, "//") + 1)).Trim
							sTemp = HandlerNameMarker;

							iTemp = Array.IndexOf(FuncArr3, sTemp);
							if (iTemp == -1)
							{
								outAiLog.WriteLine(Constants.vbNewLine + "Line: " + Conversions.ToString(LineNum) +
								                   Constants.vbTab + "Class: " + ClassNameMarker + Constants.vbTab +
								                   "Handler: " + HandlerNameMarker);
								outAiLog.WriteLine(">>>>>> Not found :" + Constants.vbNewLine + TempStr +
								                   Constants.vbNewLine);
								break;
							}

							if (TempStr.StartsWith("handler " + FuncArr1[iTemp] + " ") == false)
							{
								string[] tempStr2;
								tempStr2 = TempStr.Replace((char) 9, (char) 32).Split((char) 32);

								TempStr = "handler " + FuncArr1[iTemp] + " " + tempStr2[2] +
								          Conversions.ToString((char) 9) + "//" + Conversions.ToString((char) 9) +
								          FuncArr3[iTemp];
								outAiLog.WriteLine(Constants.vbNewLine + "Line: " + Conversions.ToString(LineNum) +
								                   Constants.vbTab + "Class: " + ClassNameMarker + Constants.vbTab +
								                   "Handler: " + HandlerNameMarker);
								outAiLog.WriteLine("Fix to: '" + FuncArr3[iTemp] + "'"
								                   + Constants.vbNewLine + "Fixed class: " + ClassNameMarker
								                   + Constants.vbNewLine + "Fixed handler: " + HandlerNameMarker
								                   + Constants.vbNewLine + "Fix " + tempStr2[1] + " to " +
								                   FuncArr1[iTemp] + Constants.vbNewLine);
							}

							break;
						}

						default:
						{
							outAi.WriteLine(TempStr);
							break;
						}
					}
				}

				outAi.WriteLine(TempStr);
			}

			outAiLog.WriteLine(Constants.vbNewLine + "Work complete" + Constants.vbNewLine +
			                   DateAndTime.Now.ToString() + Constants.vbNewLine);
			ToolStripProgressBar.Value = 0;
			inAi.Close();
			outAi.Close();
			outAiLog.Close();

			MessageBox.Show("Fixing done. Check Log file for full information.", "Complete", MessageBoxButtons.OK);
		}

		private int FindIndex(string fName, string fHandler)
		{
			int FinalMarker = -1;
			int TempMarker = 0;
			var loopTo = FuncArr3.Length - 1;

			// Dim FuncArr1(500) As String ' id
			// Dim FuncArr2(500) As String ' name
			// Dim FuncArr3(500) As String ' handler


			for (TempMarker = 0; TempMarker <= loopTo; TempMarker++)
			{
				TempMarker = Array.IndexOf(FuncArr3, fName, TempMarker);
				if (TempMarker == -1)
					break;

				if ((FuncArr2[TempMarker] ?? "") == (fHandler ?? ""))
				{
					FinalMarker = TempMarker;
					break;
				}
				else
				{
				}
			}

			return FinalMarker;
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void IncreaseQuestListButton_Click(object sender, EventArgs e)
		{
			if (Conversions.ToInteger(IncQuestTextBox.Text) <= 0)
				return;

			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			System.IO.File.Copy(OpenFileDialog.FileName, OpenFileDialog.FileName + ".bak", true);
			var inFile = new System.IO.StreamReader(OpenFileDialog.FileName + ".bak", System.Text.Encoding.Default,
				true, 1);
			var outFile = new System.IO.StreamWriter(OpenFileDialog.FileName, false, System.Text.Encoding.Unicode, 1);

			var outAiLog = new System.IO.StreamWriter(
				System.IO.Path.GetDirectoryName(OpenFileDialog.FileName) + @"\" +
				System.IO.Path.GetFileNameWithoutExtension(OpenFileDialog.FileName) + ".log", true,
				System.Text.Encoding.Unicode, 1);

			outAiLog.WriteLine("L2ScriptMaker AI.obj Increase Quest List Module" + Constants.vbNewLine);

			string sTemp;
			string[] aTemp;

			string sClass = "";
			string sHandler = "";

			int iTemp;
			int iInc = Conversions.ToInteger(IncQuestTextBox.Text);

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripProgressBar.Value = 0;

			while (inFile.EndOfStream != true)
			{
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				sTemp = inFile.ReadLine();

				if (sTemp.StartsWith("class ") == true)
					sClass = sTemp;
				if (sTemp.StartsWith("handler ") == true)
					sHandler = sTemp;

				// func_call 184615006     //  func[GetMemoCount]
				// shift_sp -1
				// push_const 16

				if (Strings.InStr(sTemp, "func_call 184615006") != 0)
				{
					outFile.WriteLine(sTemp);
					sTemp = inFile.ReadLine();

					if (Strings.InStr(sTemp, "shift_sp -1") != 0)
					{
						outFile.WriteLine(sTemp);

						sTemp = inFile.ReadLine();
						if (Strings.InStr(sTemp, "push_const ") != 0)
						{
							sTemp = sTemp.Replace(Conversions.ToString((char) 9), "").Trim();
							aTemp = sTemp.Split((char) 32);

							if ((aTemp[0] ?? "") == "push_const")
							{
								iTemp = Conversions.ToInteger(aTemp[1]);
								iTemp = iTemp + iInc;

								if (CheckBoxIgnoreAlredy.Checked == false)
								{
									sTemp = Constants.vbTab + "push_const " + Conversions.ToString(iTemp);

									outAiLog.WriteLine(Constants.vbNewLine + sClass + Constants.vbNewLine + sHandler);
									outAiLog.WriteLine(
										"Fixed: " + Conversions.ToString(Conversions.ToInteger(aTemp[1])) + " -> " +
										Conversions.ToString(iTemp));
								}
								else if (CheckBoxIgnoreAlredy.Checked == true & iTemp < 30)
								{
									sTemp = Constants.vbTab + "push_const " + Conversions.ToString(iTemp);

									outAiLog.WriteLine(Constants.vbNewLine + sClass + Constants.vbNewLine + sHandler);
									outAiLog.WriteLine(
										"Fixed: " + Conversions.ToString(Conversions.ToInteger(aTemp[1])) + " -> " +
										Conversions.ToString(iTemp));
								}
								else
									sTemp = Constants.vbTab + sTemp;
							}
							else
								MessageBox.Show(
									"Error in AI.obj. Report about this exception to L2ScriptMaker owner for debuging");
						}
					}
				}

				outFile.WriteLine(sTemp);
			}

			outAiLog.WriteLine(Constants.vbNewLine + "Work complete" + Constants.vbNewLine +
			                   DateAndTime.Now.ToString() + Constants.vbNewLine);
			outAiLog.Close();

			outFile.Close();
			inFile.Close();

			MessageBox.Show("Complete.");
		}
	}
}