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
using L2ScriptMaker.Extensions.VbCompatibleHelper;

namespace L2ScriptMaker.Modules.AI
{
	public partial class AIDecompiler : Form
	{
		public AIDecompiler()
		{
			InitializeComponent();
		}

		private string[] aLabelsDB = new string[1];

		private System.IO.StreamReader inAIFile;
		private int iGF_FileIndex;
		private long iGF_FilePosition;
		private string[] aGF_FileName = new string[1];
		private bool iGF_ErrorFlag = false;

		private string[] OriginalCode = new string[1];
		private int OriginalCodeFlag;
		private string[] DecompiledCode = new string[1];
		private int DecompiledCodeFlag;

		private object[] Stack = new object[100001]; // full stack
		private int StackFlag = -1; // current marker in stack. It and current stack size
		private object[] StackCache = new object[101]; // cache for getting values from stack

		private string AiCode;
		private long LineStat = 0;

		private string[] sSTable = new string[1];
		private string[] sSTableParam = new string[1];
		private string[] sVarTable = new string[1];

		// Use for handler/fetch_i/push_event/func_call config list
		private string sLastClassType;
		private string sLastHandler;
		private string sLastEvent;

		// ai_functions.txt
		// 167837696|GetSpawnDefine,1,0
		private string[] FuncTable = new string[1];
		private AiFuncCall[] FuncTableParam = new AiFuncCall[1];

		private struct AiFuncCall
		{
			public string FuncId;
			public string FuncName;
			public int FuncInVar;
		}

		// ai_events.txt
		// 40|default|talker
		private string[] AiEventsTable = new string[1];
		private AiEvents[] AiEventsTableParam = new AiEvents[1];

		private struct AiEvents
		{
			public int eventId;
			public string eventHandler;
			public string eventName;
		}

		// ai_fetch_i.txt
		// 16|default|y
		// 16|h0|creature

		private string[] AiFetchTable = new string[1];
		private AiFetch[] AiFetchTableParam = new AiFetch[1];

		private struct AiFetch
		{
			public int fetchId;
			public string fetchEvent;
			public string fetchName;
		}

		// ai_handlers.txt
		// 0|1|NO_DESIRE
		private string[] AiHandlerTable = new string[1];
		private AiHandler[] AiHandlerTableParam = new AiHandler[1];

		private struct AiHandler
		{
			public int handlerId;
			public string handlerClassType;
			public string handlerName;
		}


		private string GetAiVar(string iId, string sType)
		{
			int iTemp;
			string sResult = null;

			switch (sType)
			{
				case "handler":
				{
					iTemp = Array.IndexOf(AiHandlerTable, iId);
					if (iTemp == -1)
						goto ErrExit;
					if ((AiHandlerTableParam[iTemp].handlerClassType ?? "") != (sLastClassType ?? ""))
					{
						iTemp = Array.IndexOf(AiHandlerTable, iId, iTemp + 1);
						if (iTemp == -1)
							goto ErrExit;
					}

					sResult = AiHandlerTableParam[iTemp].handlerName;
					break;
				}

				case "function":
				{
					// 167837696|GetSpawnDefine,1,0
					iTemp = Array.IndexOf(FuncTable, iId);
					if (iTemp == -1)
						goto ErrExit;
					sResult = FuncTableParam[iTemp].FuncName;
					break;
				}

				case "event":
				{
					// '40|default|talker

					// 672|default|lparty
					// 672|ON_NPC_DELETED|deleted_def
					// MAX 2 variance

					// If iId = "656" And sLastHandler = "ON_NPC_DELETED" Then
					// Dim asd As Boolean = False
					// End If

					iTemp = Array.IndexOf(AiEventsTable, iId);
					if (iTemp == -1)
						goto ErrExit;
					sResult = AiEventsTableParam[iTemp].eventName; // example "default" value

					if ((AiEventsTableParam[iTemp].eventHandler ?? "") != "default" &
					    (AiEventsTableParam[iTemp].eventHandler ?? "") != (sLastHandler ?? ""))
					{
						MessageBox.Show(
							"Wrong record into push_event config. 'default' type not defined or placed on not in first position. Decompiling code maybe wrong!" + Constants
								                                                                                                                                    .vbNewLine
							                                                                                                                                    + "Found fetch '// " +
							                                                                                                                                    sResult +
							                                                                                                                                    "' for id:[" +
							                                                                                                                                    iId +
							                                                                                                                                    "] in handler: [" +
							                                                                                                                                    sLastHandler +
							                                                                                                                                    "]",
							"Wrong config", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return sResult;
						break;
					}

					while (iTemp != -1)
					{
						if ((AiEventsTableParam[iTemp].eventHandler ?? "") == (sLastHandler ?? ""))
						{
							sResult = AiEventsTableParam[iTemp].eventName;
							break;
						}

						iTemp = Array.IndexOf(AiEventsTable, iId, iTemp + 1);
					}

					break;
				}

				case "fetch":
				{
					// ai_fetch_i.txt

					// ai_fetch_i.txt
					// 16|default|y
					// 16|h0|creature

					iTemp = Array.IndexOf(AiFetchTable, iId);
					if (iTemp == -1)
						goto ErrExit; // Exit Select 
					sResult = AiFetchTableParam[iTemp].fetchName; // example "default" value
					if ((AiFetchTableParam[iTemp].fetchEvent ?? "") != "default" &
					    (AiFetchTableParam[iTemp].fetchEvent ?? "") != (sLastEvent ?? ""))
					{
						MessageBox.Show(
							"Wrong record into fetch_i config. 'default' type not defined or placed on not in first position. Decompiling code maybe wrong!" + Constants
								                                                                                                                                 .vbNewLine
							                                                                                                                                 +
							                                                                                                                                 "Found fetch '// " +
							                                                                                                                                 sResult +
							                                                                                                                                 "' for id:[" +
							                                                                                                                                 iId +
							                                                                                                                                 "] in handler: [" +
							                                                                                                                                 sLastHandler +
							                                                                                                                                 "] with last push_event: [" +
							                                                                                                                                 sLastEvent +
							                                                                                                                                 "].",
							"Wrong config", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return sResult;
						break;
					}

					while (iTemp != -1)
					{
						if ((AiFetchTableParam[iTemp].fetchEvent ?? "") == (sLastEvent ?? ""))
						{
							sResult = AiFetchTableParam[iTemp].fetchName;
							break;
						}

						iTemp = Array.IndexOf(AiFetchTable, iId, iTemp + 1);
					}

					break;
				}
			}

			return sResult;

			ErrExit: ;
			if ((sType ?? "") == "handler")
				MessageBox.Show(
					"Not found '" + sType + "' for id:[" + iId + "] for class type: [" + sLastClassType + "]",
					"No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				MessageBox.Show("Not found '" + sType + "' for id:[" + iId + "] in handler: [" + sLastHandler + "]",
					"No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return null;
		}

		private bool FuncCallLoader()
		{
			string sTemp;
			var aTemp = new string[11];
			int iTemp = 0;
			int iForTemp = 0;
			string sFolder;
			string sConfigFile;
			var aConfigs = new[] {"ai_functions.txt", "ai_handlers.txt", "ai_events.txt", "ai_fetch_i.txt"};
			System.IO.StreamReader inFile;

			sFolder = System.IO.Path.GetDirectoryName(FuncFileTextBox.Text);

			Array.Clear(FuncTable, 0, FuncTable.Length);
			Array.Clear(FuncTableParam, 0, FuncTableParam.Length);
			Array.Clear(AiHandlerTable, 0, AiHandlerTable.Length);
			Array.Clear(AiHandlerTableParam, 0, AiHandlerTableParam.Length);
			Array.Clear(AiEventsTable, 0, AiEventsTable.Length);
			Array.Clear(AiEventsTableParam, 0, AiEventsTableParam.Length);
			Array.Clear(AiFetchTable, 0, AiFetchTable.Length);
			Array.Clear(AiFetchTableParam, 0, AiFetchTableParam.Length);
			var loopTo = aConfigs.Length - 1;
			for (iForTemp = 0; iForTemp <= loopTo; iForTemp++)
			{
				sConfigFile = sFolder + @"\" + aConfigs[iForTemp];
				if (System.IO.File.Exists(sConfigFile) == false)
				{
					MessageBox.Show(
						"Config file '" + sFolder + aConfigs[iForTemp] + "'not exist. Enter valid path and try again.",
						"File not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}

				inFile = new System.IO.StreamReader(sConfigFile, System.Text.Encoding.Default, true, 1);

				while (inFile.EndOfStream != true)
				{
					sTemp = inFile.ReadLine().Trim();
					if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
					{
						sTemp = sTemp.Trim().Replace("|", ",");
						aTemp = sTemp.Split(Conversions.ToChar(","));


						switch (aConfigs[iForTemp])
						{
							case "ai_functions.txt":
							{
								// 167837696|GetSpawnDefine,1,0
								if (AiVarsCheckBox.Checked == false)
									FuncTable[iTemp] = aTemp[1];
								else
									FuncTable[iTemp] = aTemp[0];
								FuncTableParam[iTemp].FuncId = aTemp[0];
								FuncTableParam[iTemp].FuncName = aTemp[1];
								FuncTableParam[iTemp].FuncInVar = Conversions.ToInteger(aTemp[2]);
								// FuncTableParam(iTemp).FuncOutVar = CInt(aTemp(3))

								iTemp += 1;
								Array.Resize(ref FuncTable, iTemp + 1);
								Array.Resize(ref FuncTableParam, iTemp + 1);
								break;
							}

							case "ai_handlers.txt":
							{
								// 0|1|NO_DESIRE
								// Dim AiHandlerTable(0) As String
								// Dim AiHandlerTableParam(0) As AiHandler

								AiHandlerTable[iTemp] = aTemp[0];
								AiHandlerTableParam[iTemp].handlerId = Conversions.ToInteger(aTemp[0]);
								AiHandlerTableParam[iTemp].handlerClassType = aTemp[1];
								AiHandlerTableParam[iTemp].handlerName = aTemp[2];

								iTemp += 1;
								Array.Resize(ref AiHandlerTable, iTemp + 1);
								Array.Resize(ref AiHandlerTableParam, iTemp + 1);
								break;
							}

							case "ai_events.txt":
							{
								// 40|default|talker
								// Dim AiEventsTable(0) As String
								// Dim AiEventsTableParam(0) As AiEvents
								AiEventsTable[iTemp] = aTemp[0];
								AiEventsTableParam[iTemp].eventId = Conversions.ToInteger(aTemp[0]);
								AiEventsTableParam[iTemp].eventHandler = aTemp[1];
								AiEventsTableParam[iTemp].eventName = aTemp[2];

								iTemp += 1;
								Array.Resize(ref AiEventsTable, iTemp + 1);
								Array.Resize(ref AiEventsTableParam, iTemp + 1);
								break;
							}

							case "ai_fetch_i.txt":
							{
								// 8|default|x
								// Dim AiFetchTable(0) As String
								// Dim AiFetchTableParam(0) As AiFetch
								AiFetchTable[iTemp] = aTemp[0];
								AiFetchTableParam[iTemp].fetchId = Conversions.ToInteger(aTemp[0]);
								AiFetchTableParam[iTemp].fetchEvent = aTemp[1];
								AiFetchTableParam[iTemp].fetchName = aTemp[2];

								iTemp += 1;
								Array.Resize(ref AiFetchTable, iTemp + 1);
								Array.Resize(ref AiFetchTableParam, iTemp + 1);
								break;
							}
						}
					}
				}

				iTemp = 0;
				inFile.Close();
			}

			// FuncCallLoader = True
			return true;
		}


		private string ElseLabel()
		{
			string ElseLabelRet = default(string);
			int iTemp = OriginalCodeFlag;
			while (iTemp > 1)
			{
				if (OriginalCode[iTemp].StartsWith("jump ") == true)
				{
					ElseLabelRet = OriginalCode[iTemp].Replace("jump ", "");
					return ElseLabelRet;
				}

				iTemp = iTemp - 1;
			}

			return "";
		}


		private bool IsLastElse(string sTempLabel)
		{
			sTempLabel = sTempLabel.Replace("jump ", "");

			string sTemp;
			// sTemp = OriginalCode(Array.IndexOf(OriginalCode, OriginalCode(OriginalCodeFlag).Replace("jump ", "")) - 1)
			sTemp = OriginalCode[Array.IndexOf(OriginalCode, sTempLabel) - 1];

			if (sTemp.StartsWith("jump ") == false & sTemp.StartsWith("L") == false)
				return true;

			if ((OriginalCode[OriginalCodeFlag + 2] ?? "") ==
			    (OriginalCode[OriginalCodeFlag].Replace("jump ", "") ?? ""))
				return true;

			return false;
		}

		private string JumpLType(string Label)
		{
			string JumpLTypeRet = default(string);
			JumpLTypeRet = "";

			if (OriginalCode[FindJump("jump " + Label) - 1].StartsWith("L") == true)
				JumpLTypeRet = "L";
			else
				JumpLTypeRet = ".";
			if (OriginalCode[FindJump("jump " + Label) + 1].StartsWith("L") == true)
				JumpLTypeRet = JumpLTypeRet + "L";
			else
				JumpLTypeRet = JumpLTypeRet + ".";

			return JumpLTypeRet;
		}


		private int FindJump(string Label)
		{
			int FindJumpRet = default(int);

			// FindJump = -1
			FindJumpRet = Array.IndexOf(OriginalCode, Label);
			if (Array.LastIndexOf(OriginalCode, Label) != FindJumpRet & Label.StartsWith("branch_false") == true)
				MessageBox.Show("duplicate definition for " + Label);
			return FindJumpRet;
		}


		private bool ToStack(object Value)
		{
			bool ToStackRet = default(bool);
			StackFlag += 1;
			Stack[StackFlag] = Value;

			ToStackRet = true;
			return ToStackRet;
		}

		private bool FromStack(int Value)
		{
			bool FromStackRet = default(bool);
			int iTemp;

			if (Value > 0)
			{
				ErrorStat("Wrong value for getting values from stack", "Stack reading...");
				iGF_ErrorFlag = true;
				return false;
			}

			if (StackFlag == -1)
			{
				ErrorStat("Stack empty", "Stack reading...");
				iGF_ErrorFlag = true;
				return false;
			}

			Value = -Value;

			if (Value > StackFlag + 1)
			{
				ErrorStat("Trying of reading data more them exist", "Stack reading...");
				iGF_ErrorFlag = true;
				return false;
			}


			Array.Clear(StackCache, 0, StackCache.Length);
			var loopTo = Value - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
				StackCache[iTemp] = Stack[StackFlag - Value + 1 + iTemp];

			DeleteStack(Value);

			FromStackRet = true;
			return FromStackRet;
		}

		private bool DeleteStack(int Value)
		{
			bool DeleteStackRet = default(bool);
			int iTemp;
			var loopTo = Value - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
				Stack[StackFlag - iTemp] = "";
			StackFlag -= Value;

			DeleteStackRet = true;
			return DeleteStackRet;
		}

		private string Loader()
		{
			string LoaderRet = default(string);
			LoaderRet = OriginalCode[OriginalCodeFlag];
			// AISrcCodeTextBox.AppendText(Loader & vbNewLine)
			Label2.Text = "line is: " + Conversions.ToString(LineStat);
			Label3.Text = "current code: " + LoaderRet;
			this.Update();
			LineStat += 1;
			LoaderRet = StringPrecompile(LoaderRet, false);
			ProgressBar.Value =
				Conversions.ToInteger(OriginalCodeFlag); // CInt(OriginalCodeFlag / (OriginalCode.Length - 1) * 100)
			ProgressBar.Update();
			return LoaderRet;
		}

		private bool Saver(string Msg, string DebugMsg, bool DebugMsgConfirm)
		{
			// DebugMsgConfirm = False
			DebugMsgConfirm = FullDebugCodeCheckBox.Checked;

			AiCode = Msg;
			if (DebugMsgConfirm == true)
				AiCode = AiCode + "<---" + DebugMsg;

			if (DecompiledCode.Length <= DecompiledCodeFlag)
				Array.Resize(ref DecompiledCode, DecompiledCodeFlag + 1);
			DecompiledCode[DecompiledCodeFlag] = AiCode;
			DecompiledCodeFlag += 1;

			AiCode = "";
			return true;
		}

		private string Tabs(int TabValue)
		{
			string TabsRet = default(string);
			int iTemp;
			TabsRet = "";
			var loopTo = TabValue - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
				TabsRet = TabsRet + Constants.vbTab;
			return TabsRet;
		}

		private string StringPrecompile(string Msg, bool RemoveComma)
		{
			if (RemoveComma == true)
				Msg = Msg.Replace("//", "");

			Msg = Msg.Replace((char) 9, (char) 32).Replace("  ", " ").Trim();
			while (Strings.InStr(Msg, "  ") != 0)
				Msg = Msg.Replace("  ", " ");
			return Msg;
		}

		private bool ErrorStat(string Msg, string EventBlock)
		{
			if (ShowBugLineCheckBox.Checked == true)
			{
				int iTemp;
				AIDebugCodeTextBox.Text = "";
				TabControl.SelectedIndex = 2;
				int UpRange = 5;
				int DownRange = 5;

				if (OriginalCodeFlag <= 5)
					UpRange = OriginalCodeFlag;
				if (OriginalCodeFlag >= OriginalCode.Length - 5)
					DownRange = OriginalCode.Length - OriginalCodeFlag - 1;
				var loopTo = DownRange;
				for (iTemp = -UpRange; iTemp <= loopTo; iTemp++)
				{
					AIDebugCodeTextBox.AppendText((OriginalCodeFlag + iTemp).ToString() + ": ");
					if (iTemp == 0)
						AIDebugCodeTextBox.AppendText("-> ");
					AIDebugCodeTextBox.AppendText(OriginalCode[OriginalCodeFlag + iTemp] + Constants.vbNewLine);
				}
			}

			// If MessageBox.Show("Decompilation error for :" & EventBlock & vbNewLine & Msg & vbNewLine & "Error in : '" & LineStat & "' line" & vbNewLine & vbNewLine & "Stop decompilation or continue?", "Decompilation critical error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
			MessageBox.Show(
				"Decompilation error for :" + EventBlock + Constants.vbNewLine + Msg + Constants.vbNewLine +
				"Error in : '" + Conversions.ToString(LineStat) + "' line", "Decompilation critical error",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
			ShowCode();
			iGF_ErrorFlag = true;
			if (DataFromDebugCheckBox.Checked != true)
				SaveCode();
			MessageBox.Show(
				"Decompilation abort on error line by user." + Constants.vbNewLine + "File saved to 'ai_out_abort.txt'",
				"Abort", MessageBoxButtons.OK, MessageBoxIcon.Information);
			OriginalCodeFlag = OriginalCode.Length - 1;
			ProgressBar.Value = 0;
			GlobalProgressBar.Value = 0;

			if (DataFromDebugCheckBox.Checked == false & LoadFilesCheckBox.Checked == false)
				inAIFile.Close();

			return false;
			// End If

			return true;
		}


		private void C4Decompilator()
		{
			string sTemp; // , sTemp2 As String
			int iTemp;
			var aTemp = new string[101];
			bool IsProperty = true;

			while (LoadCode() == true)
			{
				if (LoadFilesCheckBox.Checked == true)
					GlobalProgressBar.Value = iGF_FileIndex + 1;
				else if (DataFromDebugCheckBox.Checked == true)
					GlobalProgressBar.Value = OriginalCode.Length - 1;
				else if (iGF_FilePosition > 0)
					GlobalProgressBar.Value = Conversions.ToInteger(inAIFile.BaseStream.Position);


				// AIDebugCodeTextBox.Text = ""

				ProgressBar.Maximum = OriginalCode.Length - 1;
				ProgressBar.Value = 0;

				string LabelStack = null;
				var loopTo = OriginalCode.Length - 1;
				for (OriginalCodeFlag = 0; OriginalCodeFlag <= loopTo; OriginalCodeFlag++)
				{
					sTemp = Loader();
					sTemp = StringPrecompile(sTemp, false);

					if (sTemp.StartsWith("L") == true)
					{
						if (OriginalCode[OriginalCodeFlag - 1].StartsWith("L") == true)
						{
						}
						else
							LabelStack = sTemp;
					}

					if (sTemp.StartsWith("L201147") == true)
						AiCode = "";

					// class 1 default_npc : (null)
					if (sTemp.StartsWith("class ") == true)
					{
						// ---------- class ----------
						// Saver(outFile, "", "class", False)
						Saver(sTemp, "class", false);
						Saver("{", "class", false);

						aTemp = sTemp.Split((char) 32);
						sLastClassType = aTemp[1]; // keep class type - 1 or 2
						SavedFileLabel.Text = "Load data from: " +
						                      System.IO.Path.GetFileName(aGF_FileName[iGF_FileIndex]) +
						                      " .... Decompilation class: " + aTemp[2];

						IsProperty = true;
					}
					else if (string.IsNullOrEmpty(sTemp.Trim()))
					{
					}
					else if (sTemp.StartsWith("L") == true)
					{
						// ----------- L02093 -----------

						sTemp = StringPrecompile(sTemp, false);
						aTemp = sTemp.Split((char) 32);

						// bebug breakpoint
						if ((sTemp ?? "") == "L21278")
							AiCode = "L33899";

						// ---- IF block start
						// branch_false L4128
						// L4127
						if (OriginalCode[OriginalCodeFlag - 1].StartsWith("branch_false") == true)
						{
							if (FromStack(-1) == false)
							{
								iGF_ErrorFlag = true;
								goto EndOfL;
							}

							if (Strings.InStr(DecompiledCode[DecompiledCodeFlag - 2], "else ") != 0)
							{
								if (!string.IsNullOrEmpty(ElseLabel()))
								{
									iTemp = Array.IndexOf(aLabelsDB, ElseLabel());
									if (iTemp != -1)
										aLabelsDB[iTemp] = "";
								}

								// --------- test labels db ----
								aTemp = OriginalCode[OriginalCodeFlag - 1].Split((char) 32);

								iTemp = Array.IndexOf(aLabelsDB, aTemp[0]);
								if (iTemp != -1)
								{
									aLabelsDB[iTemp] = "";
									if (Array.IndexOf(aLabelsDB, aTemp[0]) != -1)
										MessageBox.Show("WoW");
								}

								Array.Resize(ref aLabelsDB, aLabelsDB.Length + 1);
								aLabelsDB[aLabelsDB.Length - 1] = aTemp[1];
								// ------------------------------

								// Start ElseIf block
								DecompiledCodeFlag -= 2;
								Saver("elseif ( " + StackCache[0].ToString() + " )", sTemp + "_ElseIf_block", true);
								Saver("{", sTemp + "_ElseIf_block", true);
							}
							else if (Strings.InStr(DecompiledCode[DecompiledCodeFlag - 1], "case :") != 0)
							{
								DecompiledCodeFlag -= 1;
								Saver("case " + StackCache[0].ToString() + ": {", sTemp + "_Case_block", true);

								// -- Empty Case fix ---
								// branch_false L20874
								// L20873
								// jump L20875
								// L20874
								if (OriginalCode[OriginalCodeFlag + 1].StartsWith("jump"))
								{
									if ((OriginalCode[OriginalCodeFlag - 1].Replace("branch_false ", "") ?? "") ==
									    (OriginalCode[OriginalCodeFlag + 2] ?? ""))
									{
										// Empty block found
										Saver("}", sTemp + "_EmptyCase_block", true);
										OriginalCodeFlag = OriginalCodeFlag + 2;
									}
								}
							}
							else
							{
								Saver("if ( " + StackCache[0].ToString() + " )", sTemp + "_IF_block_start", true);
								Saver("{", sTemp + "IF_block_start", true);

								// --------- test labels db ----
								aTemp = OriginalCode[OriginalCodeFlag - 1].Split((char) 32);
								Array.Resize(ref aLabelsDB, aLabelsDB.Length + 1);
								aLabelsDB[aLabelsDB.Length - 1] = aTemp[1];
							}

							goto EndOfL;
						}

						if (Array.IndexOf(aLabelsDB, sTemp) != -1)
						{
							if (FindJump("branch_false " + sTemp) != -1)
							{
								Saver("}", sTemp + "_EndOfBlock_jumpcheck1_1(While,Select,Else1)", true);
								goto EndOfL;
							}

							if (FindJump("jump " + sTemp) != -1)
							{
								Saver("}", sTemp + "_EndOfBlock_jumpcheck1_2(While,Select,Else1)", true);
								goto EndOfL;
							}

							goto EndOfL;

							// If OriginalCode(OriginalCodeFlag - 1).StartsWith("L") = False Then
							// Saver("}", sTemp & "_EndOfBlock_jumpcheck1_1(While,Select,Else2)", True)
							// GoTo EndOfL
							// End If

							if (OriginalCode[OriginalCodeFlag - 1].StartsWith("L") == false &
							    OriginalCode[OriginalCodeFlag + 1].StartsWith("L") == false)
							{
								// 100% filter - Prev and Next is not Label
								if (OriginalCode[OriginalCodeFlag + 1].StartsWith("handler_end") == false &
								    OriginalCode[OriginalCodeFlag + 2].StartsWith("handler_end") == false)
								{
									// 100% filter - Label in end of handler
									Saver("}", sTemp + "_EndOfBlock_jumpcheck1_1(While,Select,Else3)", true);
									goto EndOfL;
								}
							}
							else if (OriginalCode[OriginalCodeFlag - 1].StartsWith("L") == false &
							         OriginalCode[OriginalCodeFlag + 1].StartsWith("L") == true)
							{
								// Prev Null and Next is Branch
								Saver("}", sTemp + "_EndOfBlock_jumpcheck1_1(While,Select,Else3)", true);
								goto EndOfL;
								if (FindJump("branch_false " + OriginalCode[OriginalCodeFlag + 1]) != -1)
									Saver("}", sTemp + "_EndOfBlock_jumpcheck1_1(While,Select,Else3)", true);
							}
							else if (OriginalCode[OriginalCodeFlag - 1].StartsWith("L") == true)
							{
								goto EndOfL;
								if (OriginalCode[OriginalCodeFlag + 1].StartsWith("L") == true)
								{
									if (FindJump("branch_false " + OriginalCode[OriginalCodeFlag + 1]) != -1)
									{
										if (FindJump("branch_false " + LabelStack) == -1)
										{
											Saver("}", sTemp + "_EndOfBlock_jumpcheck1_1(While,Select,Else3)", true);
											goto EndOfL;
										}
									}
								}


								// ----- Confuse filters! -----
								// Label is last in label block
								if (OriginalCode[OriginalCodeFlag + 1].StartsWith("L") == false)
								{
									if (FindJump("branch_false " + LabelStack) == -1)
									{
										Saver("}", sTemp + "_EndOfBlock_jumpcheck1_1(While,Select,Else3)", true);
										goto EndOfL;
									}
								}
							}
						}

						// Start WHILE
						if (FindJump("jump " + sTemp) > OriginalCodeFlag)
						{
							// L118404
							// ...
							// shift_sp -1
							// jump L118404
							// L118405
							if ((OriginalCode[FindJump("jump " + sTemp) - 1] ?? "") == "shift_sp -1")
							{
								if (OriginalCode[FindJump("jump " + sTemp) + 1].StartsWith("L"))
								{
									Saver("WhileFor ( ", sTemp + "WhileFor_block_start", true);
									goto EndOfL;
								}
							}
						}

						if (OriginalCode[OriginalCodeFlag - 2].StartsWith("shift_sp -1") == true &
						    OriginalCode[OriginalCodeFlag - 1].StartsWith("jump ") == true)
						{
							Saver("}", sTemp + "while_block_end", true);
							goto EndOfL;
						}
					}
					else if (Strings.InStr(sTemp, "branch_true") != 0)
					{
						goto EndOfL;
						// ---------------- branch_true ------------------
						AiCode = "";
						sTemp = StringPrecompile(sTemp, false);
						aTemp = sTemp.Split((char) 32);

						if (DecompiledCode[DecompiledCodeFlag - 1].StartsWith("WhileFor ( ") == true)
						{
							if (OriginalCode[OriginalCodeFlag + 1].StartsWith("jump ") == false)
							{
								if (FromStack(-1) == false)
								{
									iGF_ErrorFlag = true;
									goto EndOfL;
								}

								DecompiledCode[DecompiledCodeFlag - 1] = "while ( " + StackCache[0].ToString() + " )";
								Saver("{", sTemp + "_While_Start_Block", false);
							}
							else
							{
							}
						}
					}
					else if (Strings.InStr(sTemp, "branch_false") != 0)
					{
						// ---------------- branch_false ------------------

						sTemp = StringPrecompile(sTemp, false);
						aTemp = sTemp.Split((char) 32);

						if ((sTemp ?? "") == "branch_false L118405")
							AiCode = "";

						if (DecompiledCode[DecompiledCodeFlag - 1].StartsWith("WhileFor ( ") == true)
						{
							if (OriginalCode[OriginalCodeFlag + 1].StartsWith("jump ") == false)
							{
								if (FromStack(-1) == false)
								{
									iGF_ErrorFlag = true;
									goto EndOfL;
								}

								DecompiledCode[DecompiledCodeFlag - 1] = "while ( " + StackCache[0].ToString() + " )";
								Saver("{", sTemp + "_While_Start_Block", false);
							}
						}

						goto EndOfL;
					}
					else if (Strings.InStr(sTemp, "jump") != 0)
					{
						// ----------- jump L207102 -----------
						sTemp = StringPrecompile(sTemp, false);
						aTemp = sTemp.Split((char) 32);

						// if ((sTemp ?? "") == "jump L21278") int aaa = 0;

						if (FindJump(aTemp[1]) < OriginalCodeFlag)
						{
							// End While and etc
							if (DecompiledCode[DecompiledCodeFlag - 2].StartsWith("for ( ") == true)
							{
								// And FOR block

								// FIX
								// If FromStack(-1) = False Then
								// iGF_ErrorFlag = True
								// GoTo EndOfL
								// End If
								// FIX 

								AiCode = DecompiledCode[DecompiledCodeFlag - 2] + " ; " +
								         DecompiledCode[DecompiledCodeFlag - 1].Replace(";", "") + " )";
								DecompiledCodeFlag -= 2;
								// AiCode = AiCode & " ; " & StackCache(0).ToString & " )"
								Saver(AiCode, sTemp + "_FOR_define_finished", true);
								Saver("{", sTemp + "_FOR_define_finished", true);
								OriginalCodeFlag += 1;
							}
						}
						else if (OriginalCode[OriginalCodeFlag + 1].StartsWith("jump "))
						{
							// SelectCase - Case block

							Saver("break;", sTemp + "_oneCaseBlockEnd_jumpjump", true);
							Saver("}", sTemp + "_oneCaseBlockEnd_jumpjump", true);

							OriginalCodeFlag += 1;
						}
						else if (OriginalCode[OriginalCodeFlag - 1].StartsWith("branch_false") &
						         OriginalCode[OriginalCodeFlag + 1].StartsWith("L"))
						{
							// And FOR block
							if (FromStack(-1) == false)
							{
								iGF_ErrorFlag = true;
								goto EndOfL;
							}

							// --------- test labels db ----
							aTemp = OriginalCode[OriginalCodeFlag - 1].Split((char) 32);
							Array.Resize(ref aLabelsDB, aLabelsDB.Length + 1);
							aLabelsDB[aLabelsDB.Length - 1] = aTemp[1];
							// --------- test labels db ----

							if (DecompiledCode[DecompiledCodeFlag - 1].StartsWith("WhileFor ( ") == true)
							{
								StackCache[1] = StackCache[0];
								StackCache[0] = DecompiledCode[DecompiledCodeFlag - 2];
								DecompiledCodeFlag -= 2;
							}
							else
							{
								iGF_ErrorFlag = true;
								goto EndOfL;
							}

							// DecompiledCode(DecompiledCodeFlag - 1) = "for ( " & StackCache(0).ToString & " , " & StackCache(1).ToString
							// Saver("for ( " & StackCache(0).ToString & " ; " & StackCache(1).ToString, sTemp & "_ForStartBlock", True)
							Saver("for ( " + StackCache[0].ToString() + " " + StackCache[1].ToString(),
								sTemp + "_ForStartBlock", true);
							OriginalCodeFlag += 1;
						}
						else if (OriginalCode[OriginalCodeFlag + 1].StartsWith("L") == true)
						{
							// -------- ELSE FIX v2 ----------

							// -- Empty Case fix ---
							// branch_false L22408
							// L22407
							// ....
							// jump L22409 <----
							// L22408
							// L22409
							// jump L22410
							// L22406

							if (OriginalCode[OriginalCodeFlag + 2].StartsWith("L") == true)
							{
								if ((OriginalCode[OriginalCodeFlag].Replace("jump ", "") ?? "") ==
								    (OriginalCode[OriginalCodeFlag + 2] ?? ""))
								{
								}
							}

							// -------- ELSE FIX v1 ----------
							// If IsLastElse(OriginalCode(OriginalCodeFlag)) = True Then
							// --------- test labels db ----
							aTemp = OriginalCode[OriginalCodeFlag + 1].Split((char) 32);
							iTemp = Array.IndexOf(aLabelsDB, aTemp[0]);
							if (iTemp != -1)
							{
								aLabelsDB[iTemp] = "";
								if (Array.IndexOf(aLabelsDB, aTemp[0]) != -1)
									MessageBox.Show("WoW");
							}

							aTemp = sTemp.Split((char) 32);
							Array.Resize(ref aLabelsDB, aLabelsDB.Length + 1);
							aLabelsDB[aLabelsDB.Length - 1] = aTemp[1];
							// ------------------------------

							// End If

							// Else
							Saver("}", sTemp + "_ElseBlock", true);
							Saver("else ", sTemp + "_ElseBlock", true);
							Saver("{", sTemp + "_ElseBlock", true);
							OriginalCodeFlag += 1;
						}
						else if (OriginalCode[OriginalCodeFlag + 1].StartsWith("L") == true &
						         OriginalCode[OriginalCodeFlag - 1].StartsWith("L") == true)
						{
							// -- Empty Case fix ---
							// branch_false L22408
							// L22407
							// ....
							// jump L22409
							// L22408
							// L22409 (jump for empty block)
							// jump L22410 <----
							// L22406 (branch_false)
							if (FindJump("jump " + OriginalCode[OriginalCodeFlag - 1]) != -1 &
							    FindJump("branch_false " + OriginalCode[OriginalCodeFlag + 1]) != -1)
							{
								if (Array.IndexOf(aLabelsDB, OriginalCode[OriginalCodeFlag + 1]) != -1)
								{
									// Array.IndexOf(aLabelsDB, OriginalCode(OriginalCodeFlag - 1)) = -1 And
									// -------- ELSE FIX v1 ----------
									if (IsLastElse(OriginalCode[OriginalCodeFlag]) == true)
									{
										// --------- test labels db ----
										aTemp = OriginalCode[OriginalCodeFlag + 1].Split((char) 32);
										iTemp = Array.IndexOf(aLabelsDB, aTemp[0]);
										if (iTemp != -1)
										{
											aLabelsDB[iTemp] = "";
											if (Array.IndexOf(aLabelsDB, aTemp[0]) != -1)
												MessageBox.Show("WoW");
										}

										aTemp = sTemp.Split((char) 32);
										Array.Resize(ref aLabelsDB, aLabelsDB.Length + 1);
										aLabelsDB[aLabelsDB.Length - 1] = aTemp[1];
									}

									// Else
									Saver("}", sTemp + "_ElseBlock", true);
									Saver("else ", sTemp + "_ElseBlock", true);
									Saver("{", sTemp + "_ElseBlock", true);
									OriginalCodeFlag += 1;
								}
							}
							else if (FindJump("branch_false " + OriginalCode[OriginalCodeFlag - 1]) != -1 &
							         FindJump("branch_false " + OriginalCode[OriginalCodeFlag + 1]) != -1)
							{
							}
						}
					}
					else if (Strings.InStr(sTemp, "push_event") != 0)
					{
						// ---------- push_event ----------
						// push_event      //  myself
						// push_const 111
						// APPROVE 100%

						if (Strings.InStr(OriginalCode[OriginalCodeFlag + 1], "push_const") == 0)
						{
							ErrorStat("[Crit] Required 'push_event' must be 'push_const'", "push_const");
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						if (AiVarsCheckBox.Checked == false)
						{
							if (Strings.InStr(sTemp, "//") == 0)
							{
								ErrorStat("[Crit] Not defined name for this push_event.", "push_event");
								iGF_ErrorFlag = true;
								goto EndOfL;
							}

							sTemp = StringPrecompile(sTemp, true);
							aTemp = sTemp.Split((char) 32);
							ToStack(aTemp[1]);
							sLastEvent = aTemp[1];

							if (DataFromDebugCheckBox.Checked == false & Array.IndexOf(sVarTable, aTemp[1]) == -1 &
							    (aTemp[1] ?? "") != "gg")
							{
								ErrorStat(
									"[Aver] Event '" + aTemp[1] + "' is not defined in variable list for this handler",
									"push_event");
								iGF_ErrorFlag = true;
								goto EndOfL;
							}

							OriginalCodeFlag += 1;
							sTemp = Loader();
						}
						else
						{
							sTemp = StringPrecompile(sTemp, true);
							// aTemp = sTemp.Split(Chr(32))
							OriginalCodeFlag += 1;
							sTemp = Loader();
							// If InStr(sTemp, "push_const") = 0 Then
							// ErrorStat("[Aver] Required push_const next after push_event", "push_const")
							// iGF_ErrorFlag = True
							// GoTo EndOfL
							// End If
							sTemp = StringPrecompile(sTemp, true);
							aTemp = sTemp.Split((char) 32);
							sTemp = GetAiVar(aTemp[1], "event");
							if (sTemp == null)
							{
								iGF_ErrorFlag = true;
								goto EndOfL;
							}

							ToStack(sTemp);
							sLastEvent = sTemp;
						}
					}
					else if (Strings.InStr(sTemp, "fetch_232323232") != 0)
					{
						// ---------- fetch_i ----------
						// APPROVE 100%


						if (Strings.InStr(OriginalCode[OriginalCodeFlag + 1], "push_const") > 0 &
						    (OriginalCode[OriginalCodeFlag + 2] ?? "") == "add")
						{
							sTemp = StringPrecompile(sTemp, true);
							aTemp = sTemp.Split((char) 32);
							sTemp = aTemp[1]; // var name for NoAIVarConfig mode

							if (AiVarsCheckBox.Checked == false)
								Stack[StackFlag] = Stack[StackFlag].ToString() + "." + aTemp[1];
							else
							{
								OriginalCodeFlag += 1;
								sTemp = Loader();
								sTemp = StringPrecompile(sTemp, true);
								aTemp = sTemp.Split((char) 32);
								sTemp = GetAiVar(aTemp[1], "fetch");
								if (sTemp == null)
								{
									iGF_ErrorFlag = true;
									goto EndOfL;
								}

								Stack[StackFlag] = Stack[StackFlag].ToString() + "." + sTemp;
							}
						}
						else
						{
						}
					}
					else if (Strings.InStr(sTemp, "fetch_") != 0)
					{
						if (FreyaAITempFixCheckBox.Checked == true)
						{
							// FREYA FIX
							// push_event	//  myself
							// push_const 784			//ShowPage
							// add
							// fetch_i			//ShowPage
							// push_event	//  talker
							// push_const 40			//talker
							// add
							// fetch_i
							// S11656.	"guide_gcol002.htm"
							// push_string S11656
							// func_call 235012172	//  func[ShowPage]
							// shift_sp -2
							// shift_sp -1

							if (Strings.InStr(sTemp, "//") != 0)
							{
								if (Strings.InStr(OriginalCode[OriginalCodeFlag + 1], "push_const") > 0 &
								    Strings.InStr(OriginalCode[OriginalCodeFlag + 1], "push_const 0") == 0 |
								    Strings.InStr(OriginalCode[OriginalCodeFlag + 1], "push_event") > 0)
								{
									sTemp = StringPrecompile(sTemp, true);
									aTemp = sTemp.Split((char) 32);
									sTemp = aTemp[0];
								}
							}
						}

						if (Strings.InStr(sTemp, "//") != 0 & AiVarsCheckBox.Checked == false)
						{
							sTemp = StringPrecompile(sTemp, true);
							aTemp = sTemp.Split((char) 32);


							if ((OriginalCode[OriginalCodeFlag + 2] ?? "") == "add")
							{
								// push_event	//  myself
								// push_const 704
								// add
								// fetch_i	//  sm
								// push_const 544
								// add
								// fetch_i	//  alive
								// push_const 104
								// add
								// fetch_i4

								// ---> target.alive
								// ---> myself.sm.alive

								if (aTemp.Length == 1)
								{
									ErrorStat("Required name for fetch_i. Example, fetch_i //  alive", "fetch_i");
									iGF_ErrorFlag = true;
									goto EndOfL;
								}

								Stack[StackFlag] = Stack[StackFlag].ToString() + "." + aTemp[1];
							}
							else
								ToStack(aTemp[1]);


							if (FreyaAITempFixCheckBox.Checked == true)
							{
								if (Strings.InStr(OriginalCode[OriginalCodeFlag + 1], "push_const") > 0 |
								    Strings.InStr(OriginalCode[OriginalCodeFlag + 1], "push_parameter 0") > 0)
								{
									OriginalCodeFlag += 1;
									sTemp = Loader();
								}
							}
							else
							{
								OriginalCodeFlag += 1;
								sTemp = Loader();
								if (Strings.InStr(sTemp, "push_const") == 0 &
								    Strings.InStr(sTemp, "push_parameter") == 0)
								{
									// DEBUG
									ErrorStat("Required 'push_const' next after 'fetch_i'", "fetch_i");
									iGF_ErrorFlag = true;
									goto EndOfL;
								}
							}
						}
						else if (AiVarsCheckBox.Checked == true &
						         Strings.InStr(OriginalCode[OriginalCodeFlag + 1], "push_const") > 0)
						{
							// sLastEvent
							// ai_fetch_i.txt
							// 16|default|y
							// 16|h0|creature

							// push_event	//  myself
							// push_const 704
							// add
							// fetch_i	//  sm
							// push_const 544
							// add
							// fetch_i	//  alive
							// push_const 104
							// add
							// fetch_i4

							sTemp = StringPrecompile(sTemp, true);
							aTemp = sTemp.Split((char) 32);
							if ((aTemp[0] ?? "") != "fetch_i")
								goto EndOfL;
							OriginalCodeFlag += 1;
							sTemp = Loader();
							sTemp = StringPrecompile(sTemp, true);
							aTemp = sTemp.Split((char) 32);
							if ((OriginalCode[OriginalCodeFlag + 1].Trim() ?? "") == "add")
							{
								sTemp = GetAiVar(aTemp[1], "fetch");
								if (sTemp == null)
								{
									iGF_ErrorFlag = true;
									goto EndOfL;
								}

								Stack[StackFlag] = Stack[StackFlag].ToString() + "." + sTemp;

								// fix for myself(event).sm(fetch).hp(fetch)
								sLastEvent = sTemp;
							}
							else

								// iGF_ErrorFlag = True : GoTo EndOfL 'iGF_ErrorFlag = True : GoTo EndOfL
								// recovery last line
								OriginalCodeFlag = OriginalCodeFlag - 1;
						}
						else if (1 != 1)
						{
							sTemp = GetAiVar(aTemp[1], "fetch");
							if (sTemp != null)
							{
								if ((OriginalCode[OriginalCodeFlag + 2] ?? "") == "add")
									// push_event	//  target
									// push_const96
									// add
									// fetch_i	//  alive
									// push_const 104

									// ---> target.alive
									Stack[StackFlag] = Stack[StackFlag].ToString() + "." + sTemp;
								else
									ToStack(sTemp);
							}
							else
								// iGF_ErrorFlag = True : GoTo EndOfL 'iGF_ErrorFlag = True : GoTo EndOfL
								// recovery last line
								OriginalCodeFlag = OriginalCodeFlag - 1;
						}
						else
						{
						}
					}
					else if (Strings.InStr(sTemp, "push_const") != 0)
					{
						// ---------- push_const ----------
						// APPROVE 100%
						// push_const 40

						sTemp = StringPrecompile(sTemp, false);
						aTemp = sTemp.Split((char) 32);
						ToStack(aTemp[1]);
					}
					else if (Strings.InStr(sTemp, "fetch_d") != 0)
					{
					}
					else if (Strings.InStr(sTemp, "fetch_f") != 0)
					{
					}
					else if (Strings.InStr(sTemp, "fetch_i4") != 0)
					{
					}
					else if (Strings.InStr(sTemp, "fetch_i") != 0)
					{
					}
					else if (Strings.InStr(sTemp, "assign4") != 0)
					{
						// ---------- assign4 ----------
						// APPROVE 100%

						AiCode = "";
						if (FromStack(-2) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						AiCode = StackCache[0].ToString() + " = " + StackCache[1].ToString();
						ToStack(AiCode);
						AiCode = "";
						goto EndOfL;
					}
					else if (Strings.InStr(sTemp, "assign") != 0)
					{
						// ---------- assign ----------
						AiCode = "";
						// Dim iTemp2 As Integer = StackFlag

						if (FromStack(-2) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						AiCode = StackCache[0].ToString() + " = " + StackCache[1].ToString();
						ToStack(AiCode);
						AiCode = "";
					}
					else if (Strings.InStr(sTemp, "shift_sp") != 0)
					{
						// ---------- shift_sp ----------

						// shift_sp -1; func_call; assign; fetch_
						// If InStr(sTemp, "shift_sp -1") <> 0 Then ' And InStr(sLastLine, "assign") = 0 then
						if ((sTemp ?? "") == "shift_sp -1")
						{
							// if ((OriginalCode[OriginalCodeFlag - 1] ?? "") == "L118406") int sdshdj = 1;

							// Select End Blocker
							if (OriginalCode[OriginalCodeFlag - 1].StartsWith("L") == true)
							{
								if (FindJump("jump " + OriginalCode[OriginalCodeFlag - 1]) != -1 &
								    FindJump("jump " + OriginalCode[OriginalCodeFlag - 1]) < OriginalCodeFlag)
								{
									Saver("}",
										OriginalCode[OriginalCodeFlag - 1] + "_before_shift_sp -1_EndSelectCase_Block",
										true);

									// Clear stack for shift_sp -1 for case Begin value
									if (FromStack(-1) == false)
									{
										iGF_ErrorFlag = true;
										goto EndOfL;
									}

									goto EndOfL;
								}
							}

							// If OriginalCode(OriginalCodeFlag - 1).StartsWith("fetch_") = False Then
							// fetch_ - for FOR
							if (FromStack(-1) == false)
							{
								iGF_ErrorFlag = true;
								goto EndOfL;
							}

							AiCode = StackCache[0].ToString() + ";";
							Saver(AiCode, OriginalCode[OriginalCodeFlag - 1] + "after _shift_sp -1", true);
						}
					}
					else if (Strings.InStr(sTemp, "push_reg_sp") != 0)
					{
						// ---------- push_reg_sp ----------

						// if ((OriginalCode[OriginalCodeFlag - 1] ?? "") == "L118431") int ajhdja = 1;


						if (OriginalCode[OriginalCodeFlag + 4].StartsWith("branch_false") == true)
						{
							// func_call 184615097	//  func[Agit_GetDecoLevel]
							// shift_sp -1
							// push_reg_sp
							if ((DecompiledCode[DecompiledCodeFlag - 2] ?? "") != "break;" &
							    DecompiledCode[DecompiledCodeFlag - 2].StartsWith("case ") == false)
							{
								// If StackFlag > -1 Then
								if (FromStack(-1) == false)
								{
									iGF_ErrorFlag = true;
									goto EndOfL;
								}

								Saver("switch ( " + StackCache[0].ToString() + " )",
									"_SelectCaseStartBlock_(push_reg_sp check)", true);
								Saver("{", "SelectCaseStartBlock_(push_reg_sp check)", true);
								Saver("case :", "SelectCaseStartBlock_(push_reg_sp check)", true);

								// Save last stack for next using
								// USE ONLY in Exception situation, when Previous Jumps use {} emptry block
								ToStack(StackCache[0].ToString());
								// ToStack(StackCache(0).ToString)

								goto EndOfL;
							}
						}

						if (OriginalCode[OriginalCodeFlag - 1].StartsWith("L") == true &
						    OriginalCode[OriginalCodeFlag - 2].StartsWith("jump ") == true)
						{
							Saver("case :", "SelectCase_start_block_(push_reg_sp check)", true);
							goto EndOfL;
						}


						// push_event'//  i2
						// push_const 268
						// add
						// push_reg_sp
						// fetch_i
						// push_reg_sp
						// fetch_i
						// fetch_i4
						// push_const 1
						// add
						// assign4
						// fetch_i4
						// shift_sp -1
						// jump L4140
						// ---------
						// i2=i2+1 = i2++

						if (OriginalCodeFlag + 9 < OriginalCode.Length)
						{
							if (OriginalCode[OriginalCodeFlag + 1].StartsWith("fetch_") == true &
							    OriginalCode[OriginalCodeFlag + 2].StartsWith("push_reg_sp") == true &
							    OriginalCode[OriginalCodeFlag + 3].StartsWith("fetch_i") == true &
							    OriginalCode[OriginalCodeFlag + 5].StartsWith("push_const 1") == true &
							    OriginalCode[OriginalCodeFlag + 6].StartsWith("add") == true &
							    OriginalCode[OriginalCodeFlag + 7].StartsWith("assign") == true &
							    OriginalCode[OriginalCodeFlag + 9].StartsWith("shift_sp -1") == true)
							{
								if (FromStack(-1) == false)
								{
									iGF_ErrorFlag = true;
									goto EndOfL;
								}

								ToStack(StackCache[0].ToString() + "++");
								// ToStack(StackCache(0).ToString)
								OriginalCodeFlag += 8;
								goto EndOfL;
							}
						}

						if (OriginalCode[OriginalCodeFlag + 1].StartsWith("fetch_") == true &
						    OriginalCode[OriginalCodeFlag + 2].StartsWith("fetch_") == true)
						{
							if (FromStack(-1) == false)
							{
								iGF_ErrorFlag = true;
								goto EndOfL;
							}

							ToStack(StackCache[0].ToString());
							ToStack(StackCache[0].ToString());
							OriginalCodeFlag += 1;
							goto EndOfL;
						}
					}
					else if (Strings.InStr(sTemp, "func_call ") != 0)
					{
						string sFuncName;
						// ElseIf InStr(sTemp, "func[") <> 0 Then

						// ---------- func_call ----------
						// func_call 184680516     //  func[ShowPage]
						// APPROVE 100%

						int ParamAmount;
						sTemp = StringPrecompile(sTemp, true);
						aTemp = sTemp.Split((char) 32);

						// AIVARConfig Method
						if (AiVarsCheckBox.Checked == false)
						{
							sFuncName = aTemp[2].Replace("func[", "").Replace("]", "");

							iTemp = Array.IndexOf(FuncTable, sFuncName);
							if (iTemp == -1)
							{
								ErrorStat("Function func[" + sFuncName + "] have not in base", "func[");
								iGF_ErrorFlag = true;
								goto EndOfL;
							}
						}
						else
						{
							// Config method
							sFuncName = GetAiVar(aTemp[1], "function");
							if (sFuncName == null)
							{
								iGF_ErrorFlag = true;
								goto EndOfL;
							}

							iTemp = Array.IndexOf(FuncTable, aTemp[1]);
						}

						// If FuncTableParam(iTemp).FuncName = "GetSpawnDefine" Then
						// Dim test As Integer = 1
						// End If

//#if DEBUG
//						if ((sFuncName ?? "") == "GetTimeOfDay") bool asdsa = false;
//#endif
						// 'shift_sp -2
						// '167837696|GetSpawnDefine,1,0

						// ParamAmount = FuncTableParam(iTemp).FuncInVar
						if (FuncTableParam[iTemp].FuncInVar == 0)
							ParamAmount = 0;
						else
						{
							ParamAmount =
								Conversions.ToInteger(Conversions.Val(OriginalCode[OriginalCodeFlag + 1].Replace("shift_sp ", "")));
							OriginalCodeFlag += 1;
							sTemp = Loader();
						}

						if (FromStack(ParamAmount) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						AiCode = sFuncName + "(";
						var loopTo2 = -ParamAmount - 1;
						for (iTemp = 0; iTemp <= loopTo2; iTemp++)
						{
							if (iTemp > 0)
								AiCode = AiCode + ", ";
							// If InStr(StackCache(iTemp).ToString, " ") <> 0 Then StackCache(iTemp) = "(" & StackCache(iTemp).ToString & ")"
							AiCode = AiCode + StackCache[iTemp].ToString();
						}

						AiCode = AiCode + ")";

						if (FromStack(-1) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						AiCode = StackCache[0].ToString() + "::" + AiCode;
						ToStack(AiCode);
					}
					else if (sTemp.StartsWith("S") == true & Strings.InStr(sTemp, ".") != 0)
					{
						// ---------- Sxxxxxxx ----------
						// S0.     "noquest.htm"

						// sTemp = StringPrecompile(sTemp, False)
						// aTemp = sTemp.Split(Chr(32))
						aTemp[0] = Strings.Mid(sTemp, 1, Strings.InStr(sTemp, "."));
						iTemp = Array.IndexOf(sSTable, aTemp[0]);
						if (iTemp == -1)
						{
							aTemp[1] = sTemp.Remove(0, Strings.InStr(sTemp, "\"") - 1);

							sSTable[sSTable.Length - 1] = aTemp[0];
							sSTableParam[sSTableParam.Length - 1] = aTemp[1];
							Array.Resize(ref sSTable, sSTable.Length + 1);
							Array.Resize(ref sSTableParam, sSTableParam.Length + 1);
						}
					}
					else if ((sTemp ?? "") == "greater_equal")
					{
						// If InStr(sLastLine, "push_const") <> 0 Or InStr(sLastLine, "push_parameter") <> 0 Or InStr(sLastLine, "fetch_") <> 0 Or InStr(sLastLine, "shift_sp") <> 0 Or InStr(sLastLine, "negate") <> 0 Then
						if (FromStack(-2) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						// AiCode = "(" & StackCache(0).ToString & " >= " & StackCache(1).ToString & ")"
						AiCode = StackCache[0].ToString() + " >= " + StackCache[1].ToString();
						// AiCode = "(" & AiCode & ")"
						ToStack(AiCode);
						AiCode = "";
					}
					else if ((sTemp ?? "") == "greater")
					{
						// If InStr(sLastLine, "push_const") <> 0 Or InStr(sLastLine, "push_parameter") <> 0 Or InStr(sLastLine, "fetch_") <> 0 Or InStr(sLastLine, "shift_sp") <> 0 Or InStr(sLastLine, "negate") <> 0 Then
						if (FromStack(-2) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						// AiCode = "(" & StackCache(0).ToString & " > " & StackCache(1).ToString & ")"
						AiCode = StackCache[0].ToString() + " > " + StackCache[1].ToString();
						// AiCode = "(" & AiCode & ")"
						ToStack(AiCode);
						AiCode = "";
					}
					else if ((sTemp ?? "") == "not_equal")
					{
						// If InStr(sLastLine, "push_const") <> 0 Or InStr(sLastLine, "push_parameter") <> 0 Or InStr(sLastLine, "fetch_") <> 0 Or InStr(sLastLine, "shift_sp") <> 0 Or InStr(sLastLine, "negate") <> 0 Then
						if (FromStack(-2) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						// AiCode = "(" & StackCache(0).ToString & " != " & StackCache(1).ToString & ")"
						AiCode = StackCache[0].ToString() + " != " + StackCache[1].ToString();
						// AiCode = "(" & AiCode & ")"
						ToStack(AiCode);
						AiCode = "";
					}
					else if ((sTemp ?? "") == "less_equal")
					{
						// If InStr(sLastLine, "push_const") <> 0 Or InStr(sLastLine, "push_parameter") <> 0 Or InStr(sLastLine, "fetch_") <> 0 Or InStr(sLastLine, "shift_sp") <> 0 Or InStr(sLastLine, "negate") <> 0 Then
						if (FromStack(-2) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						// AiCode = "(" & StackCache(0).ToString & " <= " & StackCache(1).ToString & ")"
						AiCode = StackCache[0].ToString() + " <= " + StackCache[1].ToString();
						// AiCode = "(" & AiCode & ")"
						ToStack(AiCode);
						AiCode = "";
					}
					else if ((sTemp ?? "") == "equal")
					{
						// If InStr(sLastLine, "push_const") <> 0 Or InStr(sLastLine, "push_parameter") <> 0 Or InStr(sLastLine, "fetch_") <> 0 Or InStr(sLastLine, "shift_sp") <> 0 Or InStr(sLastLine, "negate") <> 0 Then
						if (DecompiledCode[DecompiledCodeFlag - 1].StartsWith("case :") == false &
						    DecompiledCode[DecompiledCodeFlag - 2].StartsWith("break;") == false)
						{
							if (FromStack(-2) == false)
							{
								iGF_ErrorFlag = true;
								goto EndOfL;
							}

							// AiCode = "(" & StackCache(0).ToString & " == " & StackCache(1).ToString & ")"
							AiCode = StackCache[0].ToString() + " == " + StackCache[1].ToString();
							// AiCode = "(" & AiCode & ")"
							ToStack(AiCode);
							AiCode = "";
						}
					}
					else if ((sTemp ?? "") == "less")
					{
						// If InStr(sLastLine, "push_const") <> 0 Or InStr(sLastLine, "push_parameter") <> 0 Or InStr(sLastLine, "fetch_") <> 0 Or InStr(sLastLine, "shift_sp") <> 0 Or InStr(sLastLine, "negate") <> 0 Then
						if (FromStack(-2) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						// AiCode = "(" & StackCache(0).ToString & " < " & StackCache(1).ToString & ")"
						AiCode = StackCache[0].ToString() + " < " + StackCache[1].ToString();
						// AiCode = "(" & AiCode & ")"
						ToStack(AiCode);
						AiCode = "";
					}
					else if ((sTemp ?? "") == "call_super")
						// ----------- call_super -----------
						Saver("super;", "call_super", false);
					else if ((sTemp ?? "") == "exit_handler")
						// ----------- exit_handler -----------
						Saver("return;", "exit_handler", false);
					else if ((sTemp ?? "") == "and")
					{
						// ----------- and -----------
						if (FromStack(-2) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						// Dim Symb() As Char = CType(" =", Char())
						// If StackCache(0).ToString.IndexOfAny(Symb) <> -1 Then StackCache(0) = "( " & StackCache(0).ToString & " )"
						// If StackCache(1).ToString.IndexOfAny(Symb) <> -1 Then StackCache(1) = "( " & StackCache(1).ToString & " )"
						if (StackCache[0].ToString().StartsWith("(") == false)
							StackCache[0] = "(" + StackCache[0].ToString() + ")";
						if (StackCache[1].ToString().StartsWith("(") == false)
							StackCache[1] = "(" + StackCache[1].ToString() + ")";
						AiCode = StackCache[0].ToString() + " && " + StackCache[1].ToString();
						// AiCode = "(" & AiCode & ")"
						// push_const 18
						// equal
						// and
						// push_reg_sp
						// fetch_i
						// branch_true L22455
						if ((OriginalCode[OriginalCodeFlag + 1] ?? "") == "push_reg_sp" &
						    (OriginalCode[OriginalCodeFlag + 2] ?? "") == "fetch_i" &
						    OriginalCode[OriginalCodeFlag + 3].StartsWith("branch_true ") == true &
						    OriginalCode[OriginalCodeFlag + 4].StartsWith("L") == false)
						{
						}
						else
							AiCode = "(" + AiCode + ")";

						ToStack(AiCode);
					}
					else if ((sTemp ?? "") == "or")
					{
						// ----------- or -----------
						if (FromStack(-2) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						// Dim Symb() As Char = CType(" =", Char())
						// If StackCache(0).ToString.IndexOfAny(Symb) <> -1 Then StackCache(0) = "( " & StackCache(0).ToString & " )"
						// If StackCache(1).ToString.IndexOfAny(Symb) <> -1 Then StackCache(1) = "( " & StackCache(1).ToString & " )"
						if (StackCache[0].ToString().StartsWith("(") == false)
							StackCache[0] = "(" + StackCache[0].ToString() + ")";
						if (StackCache[1].ToString().StartsWith("(") == false)
							StackCache[1] = "(" + StackCache[1].ToString() + ")";
						AiCode = StackCache[0].ToString() + " || " + StackCache[1].ToString();

						// push_const 18
						// equal
						// or
						// push_reg_sp
						// fetch_i
						// branch_true L22455
						if ((OriginalCode[OriginalCodeFlag + 1] ?? "") == "push_reg_sp" &
						    (OriginalCode[OriginalCodeFlag + 2] ?? "") == "fetch_i" &
						    OriginalCode[OriginalCodeFlag + 3].StartsWith("branch_true ") == true &
						    OriginalCode[OriginalCodeFlag + 4].StartsWith("L") == false)
						{
						}
						else
							AiCode = "(" + AiCode + ")";

						// AiCode = "(" & AiCode & ")"
						ToStack(AiCode);
					}
					else if ((sTemp ?? "") == "add")
					{
						// I
						// push_event	//  reply
						// push_const 164
						// add
						// fetch_i4

						// II
						// push_event	//  myself
						// push_const 704
						// add
						// fetch_i	//  sm
						// push_const 544
						// add
						// fetch_i

						// III
						// push_event	//  myself
						// push_const 704
						// add
						// fetch_i	//  i_ai1
						// push_const 312
						// add
						// push_reg_sp
						// fetch_i

						// IV
						// (180 + 8) < 
						// push_const 180
						// push_const 8
						// add
						// less
						// and
						// push_reg_sp
						// fetch_i
						// branch_false L13394


						// push_event      //  myself
						// push_const 704
						// add
						// fetch_i
						// push_event      //  myself
						// push_const 704
						// add
						// fetch_i //  sm
						// push_const 544
						// add
						// fetch_i
						// push_const 3700
						// push_const 0
						// push_const 3

						// -> myself.sm.hp  myself.sm.max_hp
						// push_event      //  myself
						// push_const 704
						// add
						// fetch_i //  sm
						// push_const 544
						// add
						// fetch_i //  hp
						// push_const 392
						// add
						// fetch_d

						// push_event      //  myself
						// push_const 704
						// add
						// fetch_i //  sm
						// push_const 544
						// add
						// fetch_i //  max_hp
						// push_const 1216
						// add
						// fetch_d
						// push_const 1.000000
						// mul

						// 100% work code/original code for "// detected" version
						// If InStr(OriginalCode(OriginalCodeFlag - 2), "//") = 0 Or InStr(OriginalCode(OriginalCodeFlag - 2), "func_call ") <> 0 Then

						// If InStr(AISrcCodeTextBox.Lines(AISrcCodeTextBox.Lines.Length - 4), "push_event") = 0 And _
						// InStr(AISrcCodeTextBox.Lines(AISrcCodeTextBox.Lines.Length - 4), "fetch_i") = 0 Then
						// If InStr(AISrcCodeTextBox.Lines(AISrcCodeTextBox.Lines.Length - 4), "//") = 0 Then
						// If InStr(OriginalCode(OriginalCodeFlag - 2), "//") = 0 Or InStr(OriginalCode(OriginalCodeFlag - 2), "func_call ") <> 0 Then
						// AiVarsCheckBox.checked
						// (AiVarsCheckBox.Checked = False And InStr(OriginalCode(OriginalCodeFlag - 2), "//") = 0) Or _
						// (AiVarsCheckBox.Checked = True And InStr(OriginalCode(OriginalCodeFlag - 2), "push_event ") > 0 And InStr(OriginalCode(OriginalCodeFlag - 1), "push_const ") > 0) Then

						// If InStr(OriginalCode(OriginalCodeFlag - 2), "func_call ") <> 0 Or _
						// ((InStr(OriginalCode(OriginalCodeFlag - 2), "push_event") > 0 And InStr(OriginalCode(OriginalCodeFlag - 1), "push_const") > 0) = False And _
						// (InStr(OriginalCode(OriginalCodeFlag - 2), "fetch_i") > 0 And InStr(OriginalCode(OriginalCodeFlag - 1), "push_const") > 0) = False) Then

						// If InStr(OriginalCode(OriginalCodeFlag - 2), "func_call") <> 0 Or (InStr(OriginalCode(OriginalCodeFlag - 1), "push_const") <> 0 And _
						// (InStr(OriginalCode(OriginalCodeFlag - 2), "push_event") = 0 And InStr(OriginalCode(OriginalCodeFlag - 2), "fetch_i") = 0)) Then

						// If (AiVarsCheckBox.Checked = False And (InStr(OriginalCode(OriginalCodeFlag - 2), "//") = 0 Or InStr(OriginalCode(OriginalCodeFlag - 2), "func_call ") <> 0)) Or _
						// (AiVarsCheckBox.Checked = True And (InStr(OriginalCode(OriginalCodeFlag - 2), "func_call ") <> 0 Or (InStr(OriginalCode(OriginalCodeFlag - 3), "func_call ") <> 0 And InStr(OriginalCode(OriginalCodeFlag - 2), "shift_sp") <> 0) Or (InStr(OriginalCode(OriginalCodeFlag - 2), "fetch_i") = 0 And InStr(OriginalCode(OriginalCodeFlag - 1), "push_const ") = 0) Or (InStr(OriginalCode(OriginalCodeFlag - 2), "push_event ") = 0 And InStr(OriginalCode(OriginalCodeFlag - 1), "push_const ") = 0))) Then

						// If InStr(OriginalCode(OriginalCodeFlag - 2), "func_call ") <> 0 Or InStr(OriginalCode(OriginalCodeFlag - 1), "func_call ") <> 0 Or _
						// (AiVarsCheckBox.Checked = False And InStr(OriginalCode(OriginalCodeFlag - 2), "//") = 0) Or _
						// (AiVarsCheckBox.Checked = True And _
						// ((InStr(OriginalCode(OriginalCodeFlag - 2), "push_event") = 0 And InStr(OriginalCode(OriginalCodeFlag - 1), "push_const") = 0) Or _
						// (InStr(OriginalCode(OriginalCodeFlag - 2), "fetch_i") = 0 And InStr(OriginalCode(OriginalCodeFlag - 1), "push_const") = 0))) Then

						// Or InStr(OriginalCode(OriginalCodeFlag - 1), "func_call ") <> 0
						if (Strings.InStr(OriginalCode[OriginalCodeFlag - 2], "func_call ") != 0 |
						    AiVarsCheckBox.Checked == false &
						    Strings.InStr(OriginalCode[OriginalCodeFlag - 2], "//") == 0 |
						    AiVarsCheckBox.Checked == true &
						    Strings.InStr(OriginalCode[OriginalCodeFlag - 2], "push_event") == 0 &
						    Strings.InStr(OriginalCode[OriginalCodeFlag - 2], "fetch_i") == 0)
						{
							if (FromStack(-2) == false)
							{
								iGF_ErrorFlag = true;
								goto EndOfL;
							}

							AiCode = StackCache[0].ToString() + " + " + StackCache[1].ToString();
							AiCode = "(" + AiCode + ")";
							ToStack(AiCode);
						}
					}
					else if ((sTemp ?? "") == "sub")
					{
						if (FromStack(-2) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						AiCode = StackCache[0].ToString() + " - " + StackCache[1].ToString();
						AiCode = "(" + AiCode + ")";
						ToStack(AiCode);
					}
					else if ((sTemp ?? "") == "div")
					{
						if (FromStack(-2) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						// var Symb = Conversions.ToCharArrayRankOne(" =");
						// If StackCache(0).ToString.IndexOfAny(Symb) <> -1 Then StackCache(0) = "( " & StackCache(0).ToString & " )"
						// If StackCache(1).ToString.IndexOfAny(Symb) <> -1 Then StackCache(1) = "( " & StackCache(1).ToString & " )"
						AiCode = StackCache[0].ToString() + " / " + StackCache[1].ToString();
						AiCode = "(" + AiCode + ")";
						ToStack(AiCode);
					}
					else if ((sTemp ?? "") == "mul")
					{
						if (FromStack(-2) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						// If StackCache(0).ToString.StartsWith("(") = False Then StackCache(0) = "(" & StackCache(0).ToString & ")"
						// If StackCache(1).ToString.StartsWith("(") = False Then StackCache(1) = "(" & StackCache(1).ToString & ")"
						// Dim Symb() As Char = CType(" =", Char())
						// If StackCache(0).ToString.IndexOfAny(Symb) <> -1 Then StackCache(0) = "( " & StackCache(0).ToString & " )"
						// If StackCache(1).ToString.IndexOfAny(Symb) <> -1 Then StackCache(1) = "( " & StackCache(1).ToString & " )"
						AiCode = StackCache[0].ToString() + " * " + StackCache[1].ToString();
						AiCode = "(" + AiCode + ")";
						ToStack(AiCode);
					}
					else if ((sTemp ?? "") == "negate")
					{
						if (FromStack(-1) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						AiCode = "-" + StackCache[0].ToString();
						ToStack(AiCode);
					}
					else if ((sTemp ?? "") == "bit_or")
					{
						if (FromStack(-2) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						AiCode = StackCache[0].ToString() + " | " + StackCache[1].ToString();
						AiCode = "(" + AiCode + ")";
						ToStack(AiCode);
					}
					else if ((sTemp ?? "") == "bit_and")
					{
						if (FromStack(-2) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						AiCode = StackCache[0].ToString() + " & " + StackCache[1].ToString();
						AiCode = "(" + AiCode + ")";
						ToStack(AiCode);
					}
					else if ((sTemp ?? "") == "xor")
					{
						if (FromStack(-2) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						AiCode = StackCache[0].ToString() + " ^ " + StackCache[1].ToString();
						AiCode = "(" + AiCode + ")";
						ToStack(AiCode);
					}
					else if ((sTemp ?? "") == "not")
					{
						if (FromStack(-1) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						AiCode = "~(" + StackCache[0].ToString() + ")";
						ToStack(AiCode);
					}
					else if ((sTemp ?? "") == "mod")
					{
						if (FromStack(-2) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						AiCode = StackCache[0].ToString() + " % " + StackCache[1].ToString();
						AiCode = "(" + AiCode + ")";
						ToStack(AiCode);
					}
					else if (sTemp.StartsWith("push_string") == true)
					{
						// ---------- push_string ----------
						// S964.   ".htm"
						// push_string S964

						sTemp = StringPrecompile(sTemp, false);
						aTemp = sTemp.Split((char) 32);
						iTemp = Array.IndexOf(sSTable, aTemp[1] + ".");

						if (iTemp == -1)
						{
							ErrorStat("Required definition 'Sxxx.' for " + aTemp[1] + " for push_string",
								"push_string");
							iGF_ErrorFlag = true;
							goto EndOfL;
						}
						else
							ToStack(sSTableParam[iTemp]);
					}
					else if (sTemp.StartsWith("add_string") == true)
					{
						// ---------- add_string ----------
						// add_string 1025

						sTemp = StringPrecompile(sTemp, true);
						aTemp = sTemp.Split((char) 32);
						if (FromStack(-2) == false)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						AiCode = StackCache[0].ToString() + " + " + StackCache[1].ToString();
						ToStack(AiCode);
					}
					else if (sTemp.StartsWith("push_parameter") == true)
					{
						// ---------- push_parameter ----------
						// push_parameter fnNoFeudInfo
						sTemp = StringPrecompile(sTemp, false);
						aTemp = sTemp.Split((char) 32);
						ToStack(aTemp[1]);
					}
					else if (sTemp.StartsWith("push_property") == true)
					{
						// ---------- push_parameter ----------
						// push_parameter fnNoFeudInfo
						sTemp = StringPrecompile(sTemp, false);
						aTemp = sTemp.Split((char) 32);
						ToStack(aTemp[1]);
					}
					else if (sTemp.StartsWith("class_end") == true)
					{
						// ---------- class ----------
						Saver("}", "_class_end", false); // & "Debug: class_end"
						Saver("class_end", "_class_end", false); // & "Debug: class_end"
						Saver("", "_class_end", false); // & "Debug: class_end"

						Array.Clear(aLabelsDB, 0, aLabelsDB.Length);
						Array.Resize(ref aLabelsDB, 0);
					}
					else if (sTemp.StartsWith("parameter_define_begin") == true)
					{
						// ---------- parameter_define_begin ----------

						// sauron fix - Saver("parameter_define_begin", "parameter_define_begin", False)
						Saver("parameter:", "parameter_define_begin", false);
						OriginalCodeFlag += 1;
						sTemp = Loader();
						while ((sTemp ?? "") != "parameter_define_end")
						{
							// string fnHi "chi.htm"
							if (!string.IsNullOrEmpty(sTemp.Trim()))
							{
								sTemp = StringPrecompile(sTemp, true).Replace("{", "").Replace("}", "");
								aTemp = sTemp.Split((char) 32);
								// int	MoveAroundSocial2 = 0;
								if ((aTemp[0] ?? "") == "waypointstype" | (aTemp[0] ?? "") == "waypointdelaystype")
								{
									// waypointstype WayPoints
									// waypointdelaystype WayPointDelays
									sTemp = aTemp[0] + " = " + aTemp[1] + ";";
									Saver(sTemp, "parameter_define_begin", false);
								}
								else
								{
									// Saver(aTemp(0) & " " & aTemp(1) & " = " & aTemp(2) & ";", "parameter_define_end", False)
									// sTemp = StringPrecompile(sTemp, True).Replace("{", "").Replace("}", "")
									sTemp = aTemp[0] + Constants.vbTab + aTemp[1] + " = " + aTemp[2] + ";";
									Saver(sTemp, "parameter_define_begin", false);
								}
							}

							OriginalCodeFlag += 1;
							sTemp = Loader();
						}
					}
					else if (sTemp.StartsWith("property_define_begin") == true)
					{
						// ---------- property_define_begin ----------

						// sauron fix - Saver("property_define_begin", "property_define_begin", False)
						Saver("property:", "property_define_begin", false);
						OriginalCodeFlag += 1;
						sTemp = Loader();
						var PropertyType = default(short);
						string sLine = "";
						// aTemp(0) = ""
						while ((sTemp ?? "") != "property_define_end")
						{
							// telposlist_begin RaidBossList20_29
							if (!string.IsNullOrEmpty(sTemp.Trim()))
							{
								sTemp = StringPrecompile(sTemp, true); // .Replace("{", "").Replace("}", "")
								if (sTemp.StartsWith("buyselllist_begin") == true)
								{
									PropertyType = Conversions.ToShort(1);
									sLine = "BuySellList " + sTemp.Replace("buyselllist_begin ", "") + " = {";
								}

								if (sTemp.StartsWith("telposlist_begin") == true)
								{
									PropertyType = Conversions.ToShort(2);
									sLine = "TelPosList " + sTemp.Replace("telposlist_begin ", "") + " = {";
								}

								if (sTemp.StartsWith("buyselllist_end") == true)
								{
									sLine = sLine + "};";
									Saver(sLine, "buyselllist_end", false);
									sLine = "";
								}

								if (sTemp.StartsWith("telposlist_end") == true)
								{
									sLine = sLine + "};";
									Saver(sLine, "telposlist_end", false);
									sLine = "";
								}

								if (sTemp.StartsWith("buyselllist_") == false &
								    sTemp.StartsWith("telposlist_") == false)
								{
									if (PropertyType == 1)
									{
										aTemp = sTemp.Replace("{", "").Replace("}", "").Replace(" ", "")
											.Split(Conversions.ToChar(";"));
										if (Strings.InStr(sLine, ";") != 0)
											sLine = sLine + ";";
										sLine = sLine + "{" + aTemp[0] + ";" + aTemp[1] + "}";
									}

									if (PropertyType == 2)
									{
										if (Strings.InStr(sLine, ";") != 0)
											sLine = sLine + ";";
										sLine = sLine + sTemp;
									}
								}
							}

							OriginalCodeFlag += 1;
							sTemp = Loader();
						}
					}
					else if (sTemp.StartsWith("handler ") == true)
					{
						// ---------- handler ----------
						// handler 4 13    //  TALK_SELECTED

						if (IsProperty == true)
						{
							IsProperty = false;
							Saver("", "handler_start", false);
							Saver("handler:", "handler_start", false);
						}

						sTemp = StringPrecompile(sTemp, true);
						aTemp = sTemp.Split((char) 32);
						Saver("", "EventHandler", false);
						// sauron fix -- AiCode = aTemp(0) & " " & aTemp(3)

						// AIVARConfig Method
						if (AiVarsCheckBox.Checked == false)
							sLastHandler = aTemp[3];
						else
							// Config method
							sLastHandler = GetAiVar(aTemp[1], "handler");
						if (sLastHandler == null)
						{
							iGF_ErrorFlag = true;
							goto EndOfL;
						}

						AiCode = "EventHandler " + sLastHandler;

						// variable_begin
						AiCode = AiCode + "(";
						iTemp = 0;

						OriginalCodeFlag += 1;
						sTemp = Loader();
						if (sTemp.StartsWith("variable_begin") == true)
						{
							Array.Clear(sVarTable, 0, sVarTable.Length);
							Array.Resize(ref sVarTable, 0);

							// ---------- variable_begin ----------
							OriginalCodeFlag += 1;
							sTemp = Loader();

							while ((sTemp ?? "") != "variable_end")
							{
								// "_from_choice"
								if (!string.IsNullOrEmpty(sTemp.Trim()))
								{
									// sTemp = StringPrecompile(sTemp)
									sTemp = sTemp.Replace("\"", "");

									if (sTemp.StartsWith("_") == false & (sTemp ?? "") != "myself")
									{
										if (iTemp > 0)
											AiCode = AiCode + ", ";
										AiCode = AiCode + sTemp;
										Array.Resize(ref sVarTable, sVarTable.Length + 1);
										sVarTable[sVarTable.Length - 1] = sTemp;
										iTemp += 1;
									}
									else
									{
										Array.Resize(ref sVarTable, sVarTable.Length + 1);
										sVarTable[sVarTable.Length - 1] = sTemp;
									}
								}

								OriginalCodeFlag += 1;
								sTemp = Loader();
							}
						}
						else
						{
						}

						AiCode = AiCode + ")";
						Saver(AiCode, "variable_end", true);
						Saver("{", "EventHandler", true);

						Array.Clear(Stack, 0, Stack.Length);
						Array.Clear(StackCache, 0, StackCache.Length);
						StackFlag = -1;
					}
					else if (sTemp.StartsWith("handler_end") == true)
					{
						// DEBUG: Excess (избыточный) code output
						if (StackFlag > 0)
						{
							var loopTo1 = StackFlag - 1;
							for (iTemp = 0; iTemp <= loopTo1; iTemp++)
							{
								FromStack(-1);
								Saver(
									"// DEBUG: Excess (" + Conversions.ToString(iTemp) + "): " +
									StackCache[0].ToString(), "LeftStack", true);
							}
						}
						// DEBUG: Excess END

						// ---------- handler_end ----------
						// Saver("}", "handler_end_last_autotag", True)
						Saver("}", "handler_end_last_autotag", true);
						// - sauron fix Saver("handler_end", "handler_end_last_autotag", True)
						Saver("", "handler_end_last_autotag", true);
						// SaveClass(outFile)

						Array.Clear(sSTable, 0, sSTable.Length);
						Array.Clear(sSTableParam, 0, sSTableParam.Length);
						Array.Resize(ref sSTable, 1);
						Array.Resize(ref sSTableParam, 1);
					}
					else
					{
					}

					EndOfL: ;
					if (iGF_ErrorFlag == true)
						return;

					this.Update();
				}

				if (DataFromDebugCheckBox.Checked == true)
					break;
				SaveCode();
				this.Refresh();
				this.Update();
			}

			GlobalProgressBar.Value = 0;
			return;

			errorDef: ;
			iGF_ErrorFlag = true;
			ErrorStat("Unkwnown error", "Unkwnown error");
		}

		private bool LoadCode()
		{
			string sTemp;
			// Dim inFile As System.IO.StreamReader = Nothing

			// Clearing array for new code before decompiling
			Array.Clear(OriginalCode, 0, OriginalCode.Length);
			Array.Resize(ref OriginalCode, 0);
			OriginalCodeFlag = 0;
			Array.Clear(DecompiledCode, 0, DecompiledCode.Length);
			Array.Resize(ref DecompiledCode, 0);
			DecompiledCodeFlag = 0;

			// Load Data from Debug window
			if (DataFromDebugCheckBox.Checked == true)
			{
				int iTemp;
				var loopTo = SrcAITextBox.Lines.Length - 1;
				for (iTemp = 0; iTemp <= loopTo; iTemp++)
				{
					sTemp = SrcAITextBox.Lines[iTemp].ToString();
					sTemp = StringPrecompile(sTemp, false);
					if (!string.IsNullOrEmpty(sTemp.Trim()) & sTemp.StartsWith("//") == false)
					{
						Array.Resize(ref OriginalCode, OriginalCodeFlag + 1);
						OriginalCode[OriginalCodeFlag] = sTemp;
						OriginalCodeFlag += 1;
					}
				}

				aGF_FileName[0] = "%SELF_DEVELOPING%";
				iGF_FileIndex = 0;
				GlobalProgressBar.Maximum = OriginalCode.Length;
				return true;
			}

			if (iGF_FilePosition == 0)
			{
				iGF_FileIndex += 1;
				if (iGF_FileIndex == aGF_FileName.Length)
					return false;
				inAIFile = new System.IO.StreamReader(aGF_FileName[iGF_FileIndex], System.Text.Encoding.Default, true,
					1);
				SavedFileLabel.Text = "Load data from: " + System.IO.Path.GetFileName(aGF_FileName[iGF_FileIndex]);
			}

			if (LoadFilesCheckBox.Checked == true)
			{
				GlobalProgressBar.Maximum = aGF_FileName.Length;
				LineStat = 0;
			}
			else
				GlobalProgressBar.Maximum = Conversions.ToInteger(inAIFile.BaseStream.Length);

			while (inAIFile.EndOfStream != true)
			{
				sTemp = inAIFile.ReadLine();
				sTemp = StringPrecompile(sTemp, false);
				if (!string.IsNullOrEmpty(sTemp.Trim()) & sTemp.StartsWith("//") == false)
				{
					Array.Resize(ref OriginalCode, OriginalCodeFlag + 1);
					OriginalCode[OriginalCodeFlag] = sTemp;
					OriginalCodeFlag += 1;
				}

				if ((sTemp ?? "") == "class_end")
					break;
			}


			iGF_FilePosition = inAIFile.BaseStream.Position;
			if (inAIFile.BaseStream.Position == inAIFile.BaseStream.Length)
			{
				iGF_FilePosition = 0;
				inAIFile.Close();
				if (OriginalCode.Length == 0)
					return false;
			}

			OriginalCodeFlag = 0;
			AIDstCodeTextBox.Text = "";
			return true;
		}

		private bool SaveCode()
		{
			// ByVal outAiFile As String

			int iTemp;
			int iTab = 0;

			// Write Header
			System.IO.StreamWriter outFile = null;
			string[] aTemp;


			if (SplitClassCheckBox.Checked == false & iGF_ErrorFlag == false)
				// outFile = New System.IO.StreamWriter(outAiTextBox.Text, AppendFileCheckBox.Checked, System.Text.Encoding.Default, 1)
				// Write code to file
				// outFile.Write(AIDstCodeTextBox.Text)
				SavedFileLabel.Text = outAiTextBox.Text;

			bool OpenFlag = true;


			// Dim sForTemp As String
			string[] aForTemp;
			var loopTo = DecompiledCode.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				if (DecompiledCode[iTemp].StartsWith("class "))
				{
					aTemp = DecompiledCode[iTemp].Split((char) 32);
					// If SplitClassCheckBox.Checked = True Or iGF_ErrorFlag = True Then
					SavedFileLabel.Text = aTemp[2] + ".txt";
					if (iGF_ErrorFlag == true)
						outFile = new System.IO.StreamWriter("~ai_out_abort.txt", false, System.Text.Encoding.Unicode,
							1);
					else if (SplitClassCheckBox.Checked == true)
						outFile = new System.IO.StreamWriter(DecompiledPathTextBox.Text + aTemp[2] + ".txt", false,
							System.Text.Encoding.Unicode, 1);
					else if (SplitClassCheckBox.Checked == false & iGF_ErrorFlag == false)
						outFile = new System.IO.StreamWriter(outAiTextBox.Text, AppendFileCheckBox.Checked,
							System.Text.Encoding.Unicode, 1);
					// Write code to file
					if (outFile.BaseStream.Length == 0)
					{
						outFile.WriteLine("//---------------------------------------------------------");
						outFile.WriteLine("// L2ScriptMaker: Lineage II Cronicles 4 AI.obj Decompiler");
						outFile.WriteLine("//---------------------------------------------------------");
						outFile.WriteLine("// Decompiling: " + Conversions.ToString(DateAndTime.Now));
						outFile.WriteLine("// Decompiler build is: " + MyAssemblyInfo.Version);
						outFile.WriteLine("//---------------------------------------------------------");
						outFile.WriteLine();
					}

					// outFile.Write(AIDstCodeTextBox.Text)
					OpenFlag = true;
					// End If
					iTab = 0;

					if (CheckBoxLa2GuardFormat.Checked == true)
					{
						if (DecompiledCode[iTemp].StartsWith("class 1") == true)
						{
							outFile.WriteLine("set_compiler_opt base_event_type(@NTYPE_NPC_EVENT)");
							DecompiledCode[iTemp] = DecompiledCode[iTemp].Replace("class 1", "class");
						}
						else
						{
							outFile.WriteLine("set_compiler_opt base_event_type(@NTYPE_MAKER_EVENT)");
							DecompiledCode[iTemp] = DecompiledCode[iTemp].Replace("class 2", "class");
						}
					}
				}

				if (DecompiledCode[iTemp].StartsWith("handler:"))
					iTab = 0;
				if (DecompiledCode[iTemp].StartsWith("EventHandler "))
					iTab = 1;
				if (DecompiledCode[iTemp].StartsWith("parameter:"))
					iTab = 0;
				// If DecompiledCode(iTemp).StartsWith("parameter_define_end") Then iTab = 0 : DecompiledCode(iTemp) = ""
				if (DecompiledCode[iTemp].StartsWith("property:"))
					iTab = 0;
				// If DecompiledCode(iTemp).StartsWith("property_define_end") Then iTab = 0 : DecompiledCode(iTemp) = ""
				if (DecompiledCode[iTemp].StartsWith("telposlist_end"))
					iTab = 1;
				if (DecompiledCode[iTemp].StartsWith("buyselllist_end"))
					iTab = 1;
				// If DecompiledCode(iTemp).StartsWith("handler_end") Then iTab = 1 : DecompiledCode(iTemp) = ""
				if (DecompiledCode[iTemp].StartsWith("class_end") == true)
				{
					DecompiledCode[iTemp] = "";
					iTab = 0;
				}

				if (DecompiledCode[iTemp].StartsWith("}") == true)
					iTab -= 1;

				if (CheckBoxLa2GuardFormat.Checked == true)
				{
					if (Strings.InStr(DecompiledCode[iTemp], "switch") > 0)
						DecompiledCode[iTemp] = DecompiledCode[iTemp].Replace("switch", "select");
					if (Strings.InStr(DecompiledCode[iTemp], "elseif") > 0)
						DecompiledCode[iTemp] = DecompiledCode[iTemp].Replace("elseif", "else if");
					if (Strings.InStr(DecompiledCode[iTemp], "gg::") > 0)
						DecompiledCode[iTemp] = DecompiledCode[iTemp].Replace("gg::", "");
					if (Strings.InStr(DecompiledCode[iTemp], "::") > 0)
						DecompiledCode[iTemp] = DecompiledCode[iTemp].Replace("::", ".");

					if (Strings.InStr(DecompiledCode[iTemp], "for (") > 0)
					{
						// for ( i2 = 1; i2 <= 25 ; ++i2  )
						aForTemp = DecompiledCode[iTemp].Split(Conversions.ToChar(";"));
						// aForTemp(2)=" i2++  )"
						aForTemp[2] = aForTemp[2].Replace("++ )", " )");
						aForTemp[2] = aForTemp[2].Replace(" i", " ++i");
						// aForTemp(2)=" ++i2  )"
						DecompiledCode[iTemp] = Strings.Join(aForTemp, ";");
					}
				}

				if (OpenFlag == true)
					outFile.WriteLine(Tabs(iTab) + DecompiledCode[iTemp]);

				if (DecompiledCode[iTemp].StartsWith("class_end") == true & SplitClassCheckBox.Checked == true)
				{
					outFile.Close();
					OpenFlag = false;
				}

				if (DecompiledCode[iTemp].StartsWith("property:"))
					iTab = 1;
				if (DecompiledCode[iTemp].StartsWith("parameter:"))
					iTab = 1;
				if (DecompiledCode[iTemp].StartsWith("telposlist_begin"))
					iTab = 2;
				if (DecompiledCode[iTemp].StartsWith("buyselllist_begin"))
					iTab = 2;
				if (DecompiledCode[iTemp].StartsWith("case "))
					iTab += 1;
				// If DecompiledCode(iTemp).StartsWith("break;") Then iTab -= 1
				if (DecompiledCode[iTemp].StartsWith("{") == true)
					iTab += 1;
			}

			outFile.Close();
			// -------

			if (iGF_ErrorFlag == true)
			{
				outFile = new System.IO.StreamWriter("~ai_out_abort_class.txt", false, System.Text.Encoding.Unicode, 1);
				var loopTo1 = OriginalCode.Length - 1;
				for (iTemp = 0; iTemp <= loopTo1; iTemp++)
					outFile.WriteLine(OriginalCode[iTemp]);
			}

			outFile.Close();

			return true;
		}


		private bool ShowCode()
		{
			if (ShowCodeCheckBox.Checked == false & DataFromDebugCheckBox.Checked == false)
				return false;

			int iTemp;
			int iTab = 0;

			int iMaxLines;

			if (DecompiledCode.Length - 1 > 100)
				iMaxLines = 100;
			else
				iMaxLines = DecompiledCode.Length - 1;

			AIDstCodeTextBox.Text = "";
			AIDstCodeTextBox.SuspendLayout();

			AIDstCodeTextBox.AppendText("//---------------------------------------------------------" +
			                            Constants.vbNewLine);
			AIDstCodeTextBox.AppendText("// L2ScriptMaker: Lineage II Cronicles 4 AI.obj Decompiler" +
			                            Constants.vbNewLine);
			AIDstCodeTextBox.AppendText("//---------------------------------------------------------" +
			                            Constants.vbNewLine);
			AIDstCodeTextBox.AppendText(
				"// Decompiling: " + Conversions.ToString(DateAndTime.Now) + Constants.vbNewLine);
			AIDstCodeTextBox.AppendText("// Decompiler build is: " + MyAssemblyInfo.Version + Constants.vbNewLine);
			AIDstCodeTextBox.AppendText("//---------------------------------------------------------" +
			                            Constants.vbNewLine);
			AIDstCodeTextBox.AppendText(Constants.vbNewLine);
			var loopTo = DecompiledCode.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				if (DecompiledCode[iTemp].StartsWith("class "))
					iTab = 0;
				if (DecompiledCode[iTemp].StartsWith("handler:"))
					iTab = 0;
				if (DecompiledCode[iTemp].StartsWith("EventHandler "))
					iTab = 1;
				if (DecompiledCode[iTemp].StartsWith("parameter:"))
					iTab = 0;
				// If DecompiledCode(iTemp).StartsWith("parameter_define_end") Then iTab = 0
				if (DecompiledCode[iTemp].StartsWith("property:"))
					iTab = 0;
				// If DecompiledCode(iTemp).StartsWith("property_define_end") Then iTab = 0
				// If DecompiledCode(iTemp).StartsWith("telposlist_end") Then iTab = 1
				// If DecompiledCode(iTemp).StartsWith("buyselllist_end") Then iTab = 1
				// If DecompiledCode(iTemp).StartsWith("handler_end") Then iTab = 1
				if (DecompiledCode[iTemp].StartsWith("class_end") == true)
					iTab = 0;
				if (DecompiledCode[iTemp].StartsWith("}") == true)
					iTab -= 1;

				AIDstCodeTextBox.AppendText(Tabs(iTab) + DecompiledCode[iTemp] + Constants.vbNewLine);

				// If DecompiledCode(iTemp).StartsWith("property_define_begin") Then iTab = 1
				// If DecompiledCode(iTemp).StartsWith("parameter_define_begin") Then iTab = 1
				// If DecompiledCode(iTemp).StartsWith("telposlist_begin") Then iTab = 2
				// If DecompiledCode(iTemp).StartsWith("buyselllist_begin") Then iTab = 2
				if (DecompiledCode[iTemp].StartsWith("case "))
					iTab += 1;
				if (DecompiledCode[iTemp].StartsWith("break;"))
					iTab -= 1;
				if (DecompiledCode[iTemp].StartsWith("{") == true)
					iTab += 1;
			}

			AIDstCodeTextBox.ResumeLayout();
			return true;
		}

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			// --- PreWorking Checking Stage ---
			// If FuncTable.Length <= 1 Then
			// 'If FuncCallLoader() = False Then
			// '    Exit Sub
			// 'End If
			// End If

			if (FuncCallLoader() == false)
			{
				MessageBox.Show("Loading ai config's complete failed.", "Failed", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			if (string.IsNullOrEmpty(outAiTextBox.Text))
			{
				MessageBox.Show("Must be define target file name for saving results. Define and try again.",
					"No target file", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (SplitClassCheckBox.Checked == true & (string.IsNullOrEmpty(DecompiledPathTextBox.Text) |
			                                          System.IO.Directory.Exists(DecompiledPathTextBox.Text) == false))
			{
				MessageBox.Show("Must be define target path name for saving results. Define and try again.",
					"No target path", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			iGF_FileIndex = -1;
			iGF_FilePosition = 0;

			if (sSTable.Length > 1)
			{
				Array.Clear(sSTable, 0, sSTable.Length);
				Array.Clear(sSTableParam, 0, sSTableParam.Length);
				Array.Resize(ref sSTable, 1);
				Array.Resize(ref sSTableParam, 1);
			}

			Array.Clear(aGF_FileName, 0, aGF_FileName.Length);
			Array.Resize(ref aGF_FileName, 1);

			if (DataFromDebugCheckBox.Checked == false)
			{
				if (LoadFilesCheckBox.Checked == false)
				{
					if (string.IsNullOrEmpty(inAiTextBox.Text) | System.IO.File.Exists(inAiTextBox.Text) == false)
					{
						MessageBox.Show(
							"Must be define valid source file name for decompilation. Define and try again.",
							"No source file", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					aGF_FileName[0] = inAiTextBox.Text;
				}
				else
				{
					if (System.IO.Directory.Exists(SourcePathTextBox.Text) == false)
					{
						MessageBox.Show("Source folder no exist. Change target path for searching and try again",
							"Folder not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					aGF_FileName = System.IO.Directory.GetFiles(SourcePathTextBox.Text, SrcFileExtTextBox.Text,
						System.IO.SearchOption.AllDirectories);
					if (aGF_FileName.Length == 0)
					{
						MessageBox.Show(
							"Source folder no have data files. Put files or change extention for searching and try again",
							"No sources", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
			}
			else if (SrcAITextBox.Lines.Length == 0)
			{
				MessageBox.Show("No data for decompilation in Debug Window.", "No data", MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				return;
			}

			if (SplitClassCheckBox.Checked == false & AppendFileCheckBox.Checked == false)
			{
				if (System.IO.File.Exists(outAiTextBox.Text) == true)
				{
					if ((int) MessageBox.Show("You sure to overwrite target file?", "Overwrite file?",
						    MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == (int) DialogResult.No)
						return;
					System.IO.File.Delete(outAiTextBox.Text);
				}

				AppendFileCheckBox.Checked = true;
			}

			C4Decompilator();

			if (SplitClassCheckBox.Checked == false | DataFromDebugCheckBox.Checked == true)
				ShowCode();

			ProgressBar.Value = 0;
			MessageBox.Show("Decompilation complete" + Constants.vbNewLine + "I'm finding work in NCSoft. =)",
				"Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			if (ShowFileCheckBox.Checked == true && SplitClassCheckBox.Checked == false &&
			    DataFromDebugCheckBox.Checked == false && iGF_ErrorFlag == false)
			{
				Process.Start("notepad.exe", outAiTextBox.Text);
				// Interaction.Shell("notepad " + outAiTextBox.Text, AppWinStyle.NormalFocus, false);
			}
			iGF_ErrorFlag = false;

			// AIDstCodeTextBox.TabIndex = 0

			if (ShowCodeCheckBox.Checked == true)
				TabControl.SelectedIndex = 2;
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void inAiTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			OpenFileDialog.InitialDirectory = Application.ExecutablePath;
			OpenFileDialog.FileName = inAiTextBox.Text;
			OpenFileDialog.Filter =
				"Lineage II AI.obj script (ai.obj)|*.obj|Lineage II AI.obj scripts (*.txt)|*.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() != DialogResult.Cancel)
				inAiTextBox.Text = OpenFileDialog.FileName;
			outAiTextBox.Text = inAiTextBox.Text + "_decompiled.txt";
		}

		private void outAiTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			SaveFileDialog.FileName = outAiTextBox.Text;
			SaveFileDialog.Filter = "Lineage II AI.obj Decompiled code (ai_out.txt)|*.txt|All files|*.*";
			SaveFileDialog.OverwritePrompt = false;
			if (SaveFileDialog.ShowDialog() != DialogResult.Cancel)
				outAiTextBox.Text = SaveFileDialog.FileName;
		}

		private void LoadFilesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (LoadFilesCheckBox.Checked == false)
				SourcePathTextBox.Enabled = false;
			else
				SourcePathTextBox.Enabled = true;
		}

		private void SourcePathTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (System.IO.Directory.Exists(SourcePathTextBox.Text) == false)
				FolderBrowserDialog.SelectedPath = Application.StartupPath;
			else
				FolderBrowserDialog.SelectedPath = SourcePathTextBox.Text;
			if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
				return;
			SourcePathTextBox.Text = FolderBrowserDialog.SelectedPath;
		}

		private void SourcePathTextBox_Validated(object sender, EventArgs e)
		{

		}

		private void SplitClassCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (SplitClassCheckBox.Checked == false)
				DecompiledPathTextBox.Enabled = false;
			else
			{
				DecompiledPathTextBox.Enabled = true;
				if (System.IO.Directory.Exists(DecompiledPathTextBox.Text) == false)
					System.IO.Directory.CreateDirectory(DecompiledPathTextBox.Text);
			}
		}

		private void DecompiledPathTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (System.IO.Directory.Exists(DecompiledPathTextBox.Text) == false)
				FolderBrowserDialog.SelectedPath = Application.StartupPath;
			else
				FolderBrowserDialog.SelectedPath = DecompiledPathTextBox.Text;
			if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
				return;
			DecompiledPathTextBox.Text = FolderBrowserDialog.SelectedPath;
		}

		private void DecompiledPathTextBox_Validated(object sender, EventArgs e)
		{
			if (DecompiledPathTextBox.Text.EndsWith(@"\") == false)
				DecompiledPathTextBox.Text += @"\";
		}

		private void SaveCodeButton_Click(object sender, EventArgs e)
		{
			if (AIDstCodeTextBox.Lines.Length == 0)
			{
				MessageBox.Show("No more to writing.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			int iTemp;
			var outFile = new System.IO.StreamWriter(outAiTextBox.Text, false, System.Text.Encoding.Unicode, 1);
			var loopTo = AIDstCodeTextBox.Lines.Length - 2;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
				outFile.WriteLine(AIDstCodeTextBox.Lines[iTemp].ToString());
			outFile.Close();

			MessageBox.Show("Decompiled code saved to '" + outAiTextBox.Text + "'", "Saved", MessageBoxButtons.OK);
		}

		private void AboutButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"L2ScriptMaker: Lineage II Cronicles 4 AI.obj Decompiler" + Constants.vbNewLine +
				MyAssemblyInfo.Version, "About", MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}
	}
}