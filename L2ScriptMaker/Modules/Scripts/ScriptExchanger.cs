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
	public partial class ScriptExchanger : Form
	{
		public ScriptExchanger()
		{
			InitializeComponent();
		}

		private string[] ItemPch = new string[25001];
		private string[] NpcPch = new string[25001];
		private string[] SkillPch = new string[3000001];
		private bool PchStat = false;
		private string TempStr = "";

		private string[] ArrNameTemp = new string[51];

		private int StringSplitter(string TempStr)
		{
			int iTemp;
			int Pos1;
			int Pos2;
			int ArrAmount = 0;
			Array.Resize(ref ArrNameTemp, 0);
			Array.Clear(ArrNameTemp, 0, ArrNameTemp.Length);
			var loopTo = TempStr.Length;
			for (iTemp = 1; iTemp <= loopTo; iTemp++)
			{
				// find item and npc

				if (Strings.InStr(iTemp, TempStr, "[") != 0)
				{
					// work with item or npc
					Pos1 = Strings.InStr(iTemp, TempStr, "[");
					if (Pos1 == 0)
						break;
					// var SearchArr = new char[] { (char)93 };
					Pos2 = TempStr.IndexOf((char)93, Pos1) + 1;
					// Pos2 = InStr(Pos1, TempStr, "]")
					if (Pos2 < Pos1)
					{
						MessageBox.Show("No dual []. Check config", "Dual [] error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						Environment.Exit(0);
					}
				}
				else
					break;

				// ~ - check for ai=[~....]
				if (Pos2 > Pos1 + 1 & Strings.InStr(Strings.Mid(TempStr, Pos1 + 1, Pos2 - Pos1 - 1), "~") == 0)
				{
					if (Array.IndexOf(ArrNameTemp, Strings.Mid(TempStr, Pos1, Pos2 - Pos1 + 1)) == -1)
					{
						ArrAmount += 1;
						Array.Resize(ref ArrNameTemp, ArrAmount + 1);
						ArrNameTemp[ArrAmount] = Strings.Mid(TempStr, Pos1, Pos2 - Pos1 + 1);
						if (ArrNameTemp[ArrAmount] == null)
							ArrAmount -= 1;
					}
				}
				iTemp = Pos2;
			}

			var loopTo1 = TempStr.Length;

			// Pos1 = 0 : Pos2 = 0
			// search skills
			for (iTemp = 1; iTemp <= loopTo1; iTemp++)
			{
				// find item and npc

				if (Strings.InStr(iTemp, TempStr, "@") != 0)
				{
					// work with item or npc
					Pos1 = Strings.InStr(iTemp, TempStr, "@");
					if (Pos1 == 0)
						break;
					var SearchArr = new[] { (char)91, (char)59, (char)125 }; // ];}
					Pos2 = TempStr.IndexOfAny(SearchArr, Pos1) + 1;
				}
				else
					break;

				if (Pos2 > Pos1 + 1)
				{
					if (Array.IndexOf(ArrNameTemp, Strings.Mid(TempStr, Pos1 + 1, Pos2 - Pos1 - 1)) == -1)
					{
						ArrAmount += 1;
						Array.Resize(ref ArrNameTemp, ArrAmount + 1);
						ArrNameTemp[ArrAmount] = Strings.Mid(TempStr, Pos1 + 1, Pos2 - Pos1 - 1);
					}
				}
				iTemp = Pos2;
			}

			return ArrAmount;
		}

		private short PchLoader()
		{
			short PchLoaderRet = default(short);
			// Loading all items

			FilePos.Value = 0;
			StatusBox.Text = "";

			string WorkDir = "";
			FolderBrowserDialog.SelectedPath = System.IO.Directory.GetCurrentDirectory();
			FolderBrowserDialog.Description = "Select folder have item/npc/skill -_pch files";
			if (FolderBrowserDialog.ShowDialog() != DialogResult.Cancel)
				WorkDir = FolderBrowserDialog.SelectedPath;
			else
				return -1;

			if (System.IO.File.Exists(WorkDir + @"\item_pch.txt") == false | System.IO.File.Exists(WorkDir + @"\npc_pch.txt") == false | System.IO.File.Exists(WorkDir + @"\skill_pch.txt") == false)
			{
				MessageBox.Show("Need Pch files not exist. Check files in folder", "No PCH in folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return PchLoaderRet;
			}

			Array.Clear(ItemPch, 0, ItemPch.Length);
			Array.Clear(NpcPch, 0, NpcPch.Length);
			Array.Clear(SkillPch, 0, SkillPch.Length);

			var outLog = new System.IO.StreamWriter(WorkDir + @"\ScriptExchanger.log", true, System.Text.Encoding.Unicode, 1);
			outLog.WriteLine(Constants.vbNewLine + Conversions.ToString(DateAndTime.Now) + Constants.vbTab + "ScriptExchanger PCH data duplicate checker..." + Constants.vbNewLine);
			string ErrMsg;

			var FilePch = new System.IO.StreamReader(WorkDir + @"\item_pch.txt");
			var TempStr2 = new string[3];
			FilePos.Maximum = Conversions.ToInteger(FilePch.BaseStream.Length);
			while (FilePch.EndOfStream != true)
			{
				TempStr = FilePch.ReadLine();
				if (Strings.InStr(TempStr, "//") == 0 & Strings.Trim(TempStr) != null & Strings.InStr(TempStr, "set_begin") == 0)
				{
					TempStr = Strings.Replace(TempStr, " ", "");
					TempStr = Strings.Replace(TempStr, Conversions.ToString((char)9), "");
					TempStr2 = TempStr.Split((char)61); // =

					if (ItemPch.Length < Conversions.ToInteger(TempStr2[1]))
						Array.Resize(ref ItemPch, Conversions.ToInteger(TempStr2[1]) + 1);
					if (DuplicateCheckBox.Checked == true)
					{
						if (Array.IndexOf(ItemPch, TempStr2[0]) >= 0)
						{
							ErrMsg = "Duplicate ItemData name: " + TempStr2[0] + " ID: " + TempStr2[1];
							outLog.WriteLine(ErrMsg);
							if (DoIgnore.Checked == false)
							{
								MessageBox.Show(ErrMsg, "Duplicate found", MessageBoxButtons.OK, MessageBoxIcon.Error);
								FilePch.Close();
								outLog.Close();
								return PchLoaderRet;
							}
						}
						if (!string.IsNullOrEmpty(ItemPch[Conversions.ToInteger(TempStr2[1])]))
						{
							ErrMsg = "Duplicate ItemData ID: " + TempStr2[1];
							outLog.WriteLine(ErrMsg);
							if (DoIgnore.Checked == false)
							{
								MessageBox.Show(ErrMsg, "Duplicate found", MessageBoxButtons.OK, MessageBoxIcon.Error);
								FilePch.Close();
								outLog.Close();
								return PchLoaderRet;
							}
						}
					}
					ItemPch[Conversions.ToInteger(TempStr2[1])] = TempStr2[0];
				}
				FilePos.Value = Conversions.ToInteger(FilePch.BaseStream.Position);
				this.Update();
			}
			StatusBox.Text += "Item Id's imported." + Constants.vbNewLine;
			this.Update();
			FilePch.Close();
			Array.Clear(TempStr2, 0, TempStr2.Length);

			// Loading all items
			FilePos.Value = 0;
			FilePch = new System.IO.StreamReader(WorkDir + @"\npc_pch.txt");
			FilePos.Maximum = Conversions.ToInteger(FilePch.BaseStream.Length);
			while (FilePch.EndOfStream != true)
			{
				TempStr = Strings.Trim(FilePch.ReadLine());
				TempStr = Strings.Replace(TempStr, " ", "");
				TempStr = Strings.Replace(TempStr, Conversions.ToString((char)9), "");
				TempStr2 = TempStr.Split((char)61); // =

				if (NpcPch.Length < Conversions.ToInteger(TempStr2[1]) - 1000000)
					Array.Resize(ref NpcPch, Conversions.ToInteger(TempStr2[1]) - 1000000 + 1);
				if (DuplicateCheckBox.Checked == true)
				{
					if (Array.IndexOf(NpcPch, Conversions.ToInteger(TempStr2[1]) - 1000000) >= 0)
					{
						ErrMsg = "Duplicate NpcData name: " + TempStr2[0] + " ID: " + Conversions.ToString(Conversions.ToInteger(TempStr2[1]) - 1000000);
						outLog.WriteLine(ErrMsg);
						if (DoIgnore.Checked == false)
						{
							MessageBox.Show(ErrMsg, "Duplicate found", MessageBoxButtons.OK, MessageBoxIcon.Error);
							FilePch.Close();
							outLog.Close();
							return PchLoaderRet;
						}
					}
					if (!string.IsNullOrEmpty(NpcPch[Conversions.ToInteger(TempStr2[1]) - 1000000]))
					{
						ErrMsg = Conversions.ToString("Duplicate NpcData ID: "[Conversions.ToInteger(TempStr2[1]) - 1000000]);
						outLog.WriteLine(ErrMsg);
						if (DoIgnore.Checked == false)
						{
							MessageBox.Show(ErrMsg, "Duplicate found", MessageBoxButtons.OK, MessageBoxIcon.Error);
							FilePch.Close();
							outLog.Close();
							return PchLoaderRet;
						}
					}
				}
				NpcPch[Conversions.ToInteger(TempStr2[1]) - 1000000] = TempStr2[0];

				FilePos.Value = Conversions.ToInteger(FilePch.BaseStream.Position);
				this.Update();
			}
			StatusBox.Text += "Npc Id's imported." + Constants.vbNewLine;
			this.Update();
			FilePch.Close();
			Array.Clear(TempStr2, 0, TempStr2.Length);

			// Loading all skills
			FilePos.Value = 0;
			FilePch = new System.IO.StreamReader(WorkDir + @"\skill_pch.txt");
			FilePos.Maximum = Conversions.ToInteger(FilePch.BaseStream.Length);
			int SkillArrMarker = 0;
			while (FilePch.EndOfStream != true)
			{
				TempStr = FilePch.ReadLine();
				TempStr = Strings.Replace(TempStr, " ", "");
				TempStr = Strings.Replace(TempStr, Conversions.ToString((char)9), "");
				TempStr2 = TempStr.Split((char)61); // =
				SkillArrMarker += 1;

				if (SkillPch.Length < Conversions.ToInteger(TempStr2[1]))
					Array.Resize(ref SkillPch, Conversions.ToInteger(TempStr2[1]) + 1);
				if (DuplicateCheckBox.Checked == true)
				{
					if (Array.IndexOf(SkillPch, TempStr2[0]) >= 0)
					{
						ErrMsg = "Duplicate SkillData name: " + TempStr2[0] + " ID: " + TempStr2[1];
						outLog.WriteLine(ErrMsg);
						if (DoIgnore.Checked == false)
						{
							MessageBox.Show(ErrMsg, "Duplicate found", MessageBoxButtons.OK, MessageBoxIcon.Error);
							FilePch.Close();
							outLog.Close();
							return PchLoaderRet;
						}
					}
					if (!string.IsNullOrEmpty(SkillPch[Conversions.ToInteger(TempStr2[1])]))
					{
						ErrMsg = "Duplicate SkillData ID: " + TempStr2[1];
						outLog.WriteLine(ErrMsg);
						if (DoIgnore.Checked == false)
						{
							MessageBox.Show(ErrMsg, "Duplicate found", MessageBoxButtons.OK, MessageBoxIcon.Error);
							FilePch.Close();
							outLog.Close();
							return PchLoaderRet;
						}
					}
				}
				SkillPch[Conversions.ToInteger(TempStr2[1])] = TempStr2[0];

				FilePos.Value = Conversions.ToInteger(FilePch.BaseStream.Position);
				this.Update();
			}
			StatusBox.Text += "Skill Id's imported." + Constants.vbNewLine;
			this.Update();
			Array.Clear(TempStr2, 0, TempStr2.Length);
			FilePch.Close();
			outLog.WriteLine(Constants.vbNewLine + Conversions.ToString(DateAndTime.Now) + Constants.vbTab + "ScriptExchanger PCH data duplicate checker finished." + Constants.vbNewLine);
			outLog.Close();

			// MessageBox.Show("All source id's loaded.")
			FilePos.Value = 0;

			PchStat = true; PchLoaderRet = Conversions.ToShort(0);
			return PchLoaderRet;
		}

		private void ButtonImport_Click(object sender, EventArgs e)
		{
			if (PchStat == false)
			{
				MessageBox.Show("It is necessary to load identifiers (ID) all over again", "ID's not loaded", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}

			string SourceFile = "";
			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II script file|*.txt|All files|*.*";
			OpenFileDialog.Title = "Select folder have item/npc/skill -data file for encoding";
			if (OpenFileDialog.ShowDialog() != DialogResult.Cancel)
				SourceFile = OpenFileDialog.FileName;
			else
				return;

			var FilePch = new System.IO.StreamReader(SourceFile);
			FilePos.Maximum = Conversions.ToInteger(FilePch.BaseStream.Length);
			var WorkFile = new System.IO.StreamWriter(SourceFile + ".id.txt", false, System.Text.Encoding.Unicode, 1);

			TimeStart.Text = DateAndTime.Now.ToString();
			TimeEnd.Text = "";

			while (FilePch.EndOfStream != true)
			{
				TempStr = FilePch.ReadLine();
				if ((Strings.Mid(TempStr, 1, 2) ?? "") != "//" & Strings.Trim(TempStr) != null)
				{
					TempStr = TempStr.Replace("npc_ai={[", "npc_ai={[~");
					StringSplitter(TempStr);
					FilePos.Value = Conversions.ToInteger(FilePch.BaseStream.Position);
					StatusBox.Text = TempStr;
					this.Update();


					int iTemp;
					var loopTo = ArrNameTemp.Length - 1;
					for (iTemp = 1; iTemp <= loopTo; iTemp++)
					{
						this.Update();

						// what is it - item, npc, skill
						if (DoItem.Checked == true)
						{
							if (Array.LastIndexOf(ItemPch, ArrNameTemp[iTemp]) != -1)
								// this item
								TempStr = TempStr.Replace(ArrNameTemp[iTemp], "[%i" + Array.LastIndexOf(ItemPch, ArrNameTemp[iTemp]).ToString() + "%]");
						}

						if (DoNpc.Checked == true)
						{
							if (Array.LastIndexOf(NpcPch, ArrNameTemp[iTemp]) != -1)
								// this npc
								TempStr = TempStr.Replace(ArrNameTemp[iTemp], "[%n" + Array.LastIndexOf(NpcPch, ArrNameTemp[iTemp]).ToString() + "%]");
						}

						if (DoSkill.Checked == true)
						{
							if (IsSkillAquire.SelectedIndex == 0)
							{
								if (Array.IndexOf(SkillPch, ArrNameTemp[iTemp]) != -1)
								{
									// this item
									TempStr = TempStr.Replace(ArrNameTemp[iTemp], "[%s" + Array.IndexOf(SkillPch, ArrNameTemp[iTemp]).ToString() + "%]");
									TempStr = TempStr.Replace("@" + ArrNameTemp[iTemp], "%s" + Array.LastIndexOf(SkillPch, "[" + ArrNameTemp[iTemp] + "]").ToString() + "%");
								}
							}
							else if (IsSkillAquire.SelectedIndex == 1)
							{
								if (Array.LastIndexOf(SkillPch, "[" + ArrNameTemp[iTemp] + "]") != -1)
									// this item
									TempStr = TempStr.Replace("@" + ArrNameTemp[iTemp], "%s" + Array.LastIndexOf(SkillPch, "[" + ArrNameTemp[iTemp] + "]").ToString() + "%");
							}
						}
					}
					TempStr = TempStr.Replace("npc_ai={[~", "npc_ai={[");
				}
				WorkFile.WriteLine(TempStr);
				WorkFile.Flush();
			}

			WorkFile.Close();
			FilePch.Close();
			TimeEnd.Text = DateAndTime.Now.ToString();

			MessageBox.Show("Import done. Your friend perfect!", "Import finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void ButtonExport_Click(object sender, EventArgs e)
		{
			if (PchStat == false)
			{
				MessageBox.Show("It is necessary to load identifiers (ID) all over again", "ID's not loaded", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}

			bool IgnoreStat = false;

			string SourceFile = "";
			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II ID script file|*.id.txt|All files|*.*";
			OpenFileDialog.Title = "Select folder have item/npc/skill -data file for decoding";
			if (OpenFileDialog.ShowDialog() != DialogResult.Cancel)
				SourceFile = OpenFileDialog.FileName;
			else
				return;

			var FilePch = new System.IO.StreamReader(SourceFile);
			FilePos.Maximum = Conversions.ToInteger(FilePch.BaseStream.Length);
			SourceFile = System.IO.Path.GetFileName(SourceFile);
			var WorkFile = new System.IO.StreamWriter(Strings.Mid(SourceFile, 1, SourceFile.Length - 3) + "new.txt", false, System.Text.Encoding.Unicode, 1);

			TimeStart.Text = DateAndTime.Now.ToString();
			TimeEnd.Text = "";

			string TempStr;
			int iTemp;
			int Pos1;
			int Pos2;
			string NewVar;

			while (FilePch.EndOfStream != true)
			{
				TempStr = FilePch.ReadLine();
				StatusBox.Text = TempStr;
				iTemp = 1;
				this.Update();

				while (Strings.InStr(iTemp, TempStr, "[%") != 0)
				{

					// work with item or npc
					Pos1 = Strings.InStr(iTemp, TempStr, "[%") + 1;
					// If Pos1 = 0 Then Exit For
					Pos2 = Strings.InStr(Pos1 + 1, TempStr, "%]");
					NewVar = Strings.Mid(TempStr, Pos1 + 1, Pos2 - Pos1 - 1);

					FilePos.Value = Conversions.ToInteger(FilePch.BaseStream.Position);
					this.Update();

					if (Pos2 > Pos1 + 1)
					{
						// what is it - item, npc, skill
						if (DoItem.Checked == true)
						{
							if (Strings.InStr(NewVar, "i") != 0)
							{
								// this item
								NewVar = Strings.Mid(NewVar, 2, NewVar.Length - 1);
								try
								{
									if (!string.IsNullOrEmpty(ItemPch[Conversions.ToInteger(NewVar)]))
										TempStr = TempStr.Replace("[%i" + NewVar + "%]", ItemPch[Conversions.ToInteger(NewVar)]);
									else
										throw new Exception("1");
									// #error Cannot convert ErrorStatementSyntax - see comment for details
									/* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error 1' at character 17467
									   at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<DefaultVisit>d__24.MoveNext()
									--- End of stack trace from previous location where exception was thrown ---
									   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
									   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
									   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<CreateLocals>d__7.MoveNext()
									--- End of stack trace from previous location where exception was thrown ---
									   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
									   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
									   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<AddLocalVariables>d__6.MoveNext()
									--- End of stack trace from previous location where exception was thrown ---
									   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
									   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
									   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<ConvertWithTrivia>d__4.MoveNext()
									--- End of stack trace from previous location where exception was thrown ---
									   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
									   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
									   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisit>d__3.MoveNext()

									Input: 
																		Error 1

									 */
								}
								catch (Exception ex)
								{
									// If ex.Message = "Index was outside the bounds of the array." Then
									IgnoreStat = true;
									if (DoIgnore.Checked != true)
									{
										MessageBox.Show("Your itemdata no have new items.", "unknown id's", MessageBoxButtons.OK, MessageBoxIcon.Error);
										goto ExportEnd;
									}
									else
										iTemp = Strings.InStr(1, TempStr, "%i" + NewVar.ToString() + "%") + NewVar.ToString().Length + 3;
								}
							}
						}
						if (DoNpc.Checked == true)
						{
							if (Strings.InStr(NewVar, "n") != 0)
							{
								// this item
								NewVar = Strings.Mid(NewVar, 2, NewVar.Length - 1);
								try
								{
									if (!string.IsNullOrEmpty(NpcPch[Conversions.ToInteger(NewVar)]))
										TempStr = TempStr.Replace("[%n" + NewVar + "%]", NpcPch[Conversions.ToInteger(NewVar)]);
									else
										throw new Exception("1");
									// #error Cannot convert ErrorStatementSyntax - see comment for details
									/* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error 1' at character 18826
									   at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<DefaultVisit>d__24.MoveNext()
									--- End of stack trace from previous location where exception was thrown ---
									   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
									   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
									   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<CreateLocals>d__7.MoveNext()
									--- End of stack trace from previous location where exception was thrown ---
									   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
									   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
									   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<AddLocalVariables>d__6.MoveNext()
									--- End of stack trace from previous location where exception was thrown ---
									   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
									   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
									   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<ConvertWithTrivia>d__4.MoveNext()
									--- End of stack trace from previous location where exception was thrown ---
									   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
									   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
									   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisit>d__3.MoveNext()

									Input: 
																		Error 1

									 */
								}
								catch (Exception ex)
								{
									// If ex.Message = "Index was outside the bounds of the array." Then
									IgnoreStat = true;
									if (DoIgnore.Checked != true)
									{
										MessageBox.Show("Your npcdata no have new items.", "unknown id's", MessageBoxButtons.OK, MessageBoxIcon.Error);
										goto ExportEnd;
									}
									else
										iTemp = Strings.InStr(1, TempStr, "%" + NewVar.ToString() + "%") + NewVar.ToString().Length;
								}
							}
						}
						if (DoSkill.Checked == true)
						{
							if (Strings.InStr(NewVar, "s") != 0)
							{
								// this item
								NewVar = Strings.Mid(NewVar, 2, NewVar.Length - 1);
								try
								{
									if (!string.IsNullOrEmpty(SkillPch[Conversions.ToInteger(NewVar)]))
									{
										string NewScill = "";
										NewScill = Strings.Replace(SkillPch[Conversions.ToInteger(NewVar)], "[", "");
										NewScill = Strings.Replace(NewScill, "]", "");
										TempStr = TempStr.Replace("%s" + NewVar + "%", NewScill);
									}
									else
										throw new Exception("1");
									// #error Cannot convert ErrorStatementSyntax - see comment for details
									/* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error 1' at character 20398
									   at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<DefaultVisit>d__24.MoveNext()
									--- End of stack trace from previous location where exception was thrown ---
									   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
									   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
									   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<CreateLocals>d__7.MoveNext()
									--- End of stack trace from previous location where exception was thrown ---
									   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
									   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
									   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<AddLocalVariables>d__6.MoveNext()
									--- End of stack trace from previous location where exception was thrown ---
									   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
									   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
									   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<ConvertWithTrivia>d__4.MoveNext()
									--- End of stack trace from previous location where exception was thrown ---
									   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
									   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
									   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisit>d__3.MoveNext()

									Input: 
																		Error 1

									 */
								}
								catch (Exception ex)
								{
									// If ex.Message = "Index was outside the bounds of the array." Then
									IgnoreStat = true;
									if (DoIgnore.Checked != true)
									{
										MessageBox.Show("Your skilldata no have new items.", "unknown id's", MessageBoxButtons.OK, MessageBoxIcon.Error);
										goto ExportEnd;
									}
									else
										iTemp = Strings.InStr(1, TempStr, "%" + NewVar.ToString() + "%") + NewVar.ToString().Length;
								}
							}
						}
					}
					iTemp = Pos2 + 1;
				}
				WorkFile.WriteLine(TempStr);
			}

		ExportEnd:
			;
			if (IgnoreStat == false)
				MessageBox.Show("Export done. Your friend perfect!", "Export finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
			else
				MessageBox.Show("Export done. Finish file have error's, because you use ignore feature. ", "Export finish", MessageBoxButtons.OK, MessageBoxIcon.Warning);

			FilePch.Close();
			WorkFile.Close();
			TimeEnd.Text = DateAndTime.Now.ToString();
		}

		private void ButtonLoadItem_Click(object sender, EventArgs e)
		{
			PchLoader();
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ScriptExchanger_Load(object sender, EventArgs e)
		{
			FilePos.Value = 0;
		}
	}
}
