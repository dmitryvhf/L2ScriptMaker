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
	public partial class AIDecompilerPack : Form
	{
		public AIDecompilerPack()
		{
			InitializeComponent();
		}


		// push_event	//  myself
		// push_const 704

		// 704|default|myself
		// 704|CREATED|myself

		private string[] sEventID = new string[1];
		private string[] sEventName = new string[1];
		private string[] sEventHandlerName = new string[1];

		// fetch_i	//  p_state
		// push_const 280

		// 16|default|value
		// 16|ATTACKED|creature

		// 16|default|y
		// 16|status|value
		// 16|h0|creature

		private string[] sFetchID = new string[1];
		private string[] sFetchName = new string[1];
		private string[] sFetchEventName = new string[1];


		private bool SearchAllEvents(string fID, string fName, string fHandler)
		{
			bool SearchAllEventsRet = default(bool);
			SearchAllEventsRet = false;
			int iTemp1 = 0;
			int iTemp2 = 0;

			iTemp1 = Array.IndexOf(sEventID, fID);
			if (iTemp1 == -1)
				return false;
			if ((sEventName[iTemp1] ?? "") == (fName ?? "") & ((sEventHandlerName[iTemp1] ?? "") == "default" | (sEventHandlerName[iTemp1] ?? "") == (fHandler ?? "")))
				return true;

			iTemp1 = Array.IndexOf(sEventID, fID, iTemp1 + 1);
			while (iTemp1 != -1)
			{
				if ((sEventName[iTemp1] ?? "") == (fName ?? "") & (sEventHandlerName[iTemp1] ?? "") == (fHandler ?? ""))
					return true;
				iTemp1 = Array.IndexOf(sEventID, fID, iTemp1 + 1);
			}

			return SearchAllEventsRet;
		}

		private void CollectEventButton_Click(object sender, EventArgs e)
		{
			string sTemp;
			string sTemp2;

			// 656|default|last_attacker
			// 656|ON_START|myself

			string sFile = "";
			string[] aTemp;
			int iTemp = 0;
			bool iErrFlag = false;

			string sTempEventID = "";
			string sTempEventName = "";
			// Dim sTempEventName As String = ""
			string sTempHandlerName = "";

			int iFuncCounter = 0;

			if (OpenFileDialog.ShowDialog() != DialogResult.Cancel)
				sFile = OpenFileDialog.FileName;
			var inFile = new System.IO.StreamReader(sFile, System.Text.Encoding.Default, true, 1);

			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				sTemp = StrPrepare(sTemp);
				iTemp = iTemp + 1;

				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false & sTemp.StartsWith("handler ") == true)
				{
					// handler(0) 13(1) 289(2)	//(3)  CREATED(4)
					aTemp = sTemp.Split((char)32);
					sTempHandlerName = aTemp[4];
				}

// RepeateRead:

				// fetch_i	//  p_state
				// push_const 280

				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false & sTemp.StartsWith("push_event ") == true)
				{
					aTemp = sTemp.Split((char)32);

					// fetch_i(0)	//(1)  p_state(2)
					// push_const(0) 280(1)

					// 16|default|value
					// 16|ATTACKED|creature

					if (aTemp.Length < 1)
					{
						MessageBox.Show("Not found '//' in " + Conversions.ToString(iTemp) + " line.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
						iErrFlag = true;
						break;
					}

					sTempEventName = aTemp[2];

					// Read next line, waiting push_const 
					sTemp2 = inFile.ReadLine();
					sTemp2 = StrPrepare(sTemp2);
					ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
					iTemp = iTemp + 1;

					if (!string.IsNullOrEmpty(sTemp2) & sTemp2.StartsWith("//") == false)
					{
						if (sTemp2.StartsWith("push_const ") == false)
						{
							MessageBox.Show("Not found 'push_const' after 'fetch_i' in " + Conversions.ToString(iTemp) + " line.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
							iErrFlag = true;
							break;
						}
					}

					aTemp = sTemp2.Split((char)32);
					sTempEventID = aTemp[1];

					if (SearchAllEvents(sTempEventID, sTempEventName, sTempHandlerName) == false)
					{
						Array.Resize(ref sEventID, iFuncCounter + 1);
						Array.Resize(ref sEventName, iFuncCounter + 1);
						Array.Resize(ref sEventHandlerName, iFuncCounter + 1);
						if (Array.IndexOf(sEventID, sTempEventID) == -1)
							sEventHandlerName[iFuncCounter] = "default";
						else
							sEventHandlerName[iFuncCounter] = sTempHandlerName;

						sEventName[iFuncCounter] = sTempEventName;
						sEventID[iFuncCounter] = sTempEventID;
						iFuncCounter = iFuncCounter + 1;

						// Make dublicate previous push_event for default value
						if ((sEventHandlerName[iFuncCounter - 1] ?? "") == "default" & FetchDefaultCopyCheckBox.Checked == true)
						{
							Array.Resize(ref sEventID, iFuncCounter + 1);
							Array.Resize(ref sEventName, iFuncCounter + 1);
							Array.Resize(ref sEventHandlerName, iFuncCounter + 1);

							sEventName[iFuncCounter] = sTempEventName;
							sEventID[iFuncCounter] = sTempEventID;
							sEventHandlerName[iFuncCounter] = sTempHandlerName;
							iFuncCounter = iFuncCounter + 1;
						}
					}
				}
			}

			ProgressBar.Value = 0;
			inFile.Close();

			if (iErrFlag == false)
			{
				MessageBox.Show("Fetch ID's collecting complete. Success." + Constants.vbNewLine + " Found " + Conversions.ToString(iFuncCounter) + " events.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

				SaveFileDialog.FileName = "ai_events.txt";
				if (SaveFileDialog.ShowDialog() != DialogResult.Cancel)
					sFile = SaveFileDialog.FileName;
				else
					return;
				var outFile = new System.IO.StreamWriter(SaveFileDialog.FileName, false, System.Text.Encoding.Default, 1);

				outFile.WriteLine("// --------------------------");
				outFile.WriteLine("// L2ScriptMaker (4.0.46.10+)");
				outFile.WriteLine("// AI Decompiler 'push_event' list");
				outFile.WriteLine("// updated: " + Conversions.ToString(DateAndTime.Now));
				outFile.WriteLine("// --------------------------");
				outFile.WriteLine("// format:");
				outFile.WriteLine("// push_event id|specific HANDLER name|event name");
				var loopTo = iFuncCounter - 1;

				// 656|default|last_attacker
				// 656|ON_START|myself

				for (iTemp = 0; iTemp <= loopTo; iTemp++)
				{
					sTemp = sEventID[iTemp] + "|" + sEventHandlerName[iTemp] + "|" + sEventName[iTemp];
					outFile.WriteLine(sTemp);
				}
				outFile.Close();
			}
		}

		private bool SearchAllFetch(string fID, string fName, string fEvent)
		{
			bool SearchAllFetchRet = default(bool);
			SearchAllFetchRet = false;
			int iTemp1 = 0;
			int iTemp2 = 0;

			iTemp1 = Array.IndexOf(sFetchID, fID);
			if (iTemp1 == -1)
				return false;
			if ((sFetchName[iTemp1] ?? "") == (fName ?? "") & ((sFetchEventName[iTemp1] ?? "") == "default" | (sFetchEventName[iTemp1] ?? "") == (fEvent ?? "")))
				return true;

			iTemp1 = Array.IndexOf(sFetchID, fID, iTemp1 + 1);
			while (iTemp1 != -1)
			{
				if ((sFetchName[iTemp1] ?? "") == (fName ?? "") & (sFetchEventName[iTemp1] ?? "") == (fEvent ?? ""))
					return true;
				iTemp1 = Array.IndexOf(sFetchID, fID, iTemp1 + 1);
			}

			return SearchAllFetchRet;
		}


		private void CollectFetchButton_Click(object sender, EventArgs e)
		{
			string sTemp;
			string sTemp2;
			string sFile = "";
			string[] aTemp;
			int iTemp = 0;
			bool iErrFlag = false;

			string sTempFetchID = "";
			string sTempFetchName = "";
			string sTempEventName = "";
			// Dim sHandlerName As String = ""

			int iFuncCounter = 0;

			if (OpenFileDialog.ShowDialog() != DialogResult.Cancel)
				sFile = OpenFileDialog.FileName;
			var inFile = new System.IO.StreamReader(sFile, System.Text.Encoding.Default, true, 1);

			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				sTemp = StrPrepare(sTemp);
				iTemp = iTemp + 1;

				// If sTemp <> "" And sTemp.StartsWith("//") = False And sTemp.StartsWith("handler ") = True Then
				// 'class 1 default_npc : (null)
				// aTemp = sTemp.Split(Chr(32))
				// sHandlerName = aTemp(4)
				// End If

				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false & sTemp.StartsWith("push_event ") == true & Strings.InStr(sTemp, "//") > 0)
				{
					// push_event	//  myself
					// push_const 704

					aTemp = sTemp.Split((char)32);
					sTempEventName = aTemp[2];
				}

// RepeateRead:

				// fetch_i	//  p_state
				// push_const 280

				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false & sTemp.StartsWith("fetch_i ") == true)
				{
					aTemp = sTemp.Split((char)32);

					// fetch_i(0)	//(1)  p_state(2)
					// push_const(0) 280(1)

					// 16|default|value
					// 16|ATTACKED|creature

					if (aTemp.Length < 1)
					{
						MessageBox.Show("Not found '//' in " + Conversions.ToString(iTemp) + " line.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
						iErrFlag = true;
						break;
					}

					sTempFetchName = aTemp[2];

					// Read next line, waiting push_const 
					sTemp2 = inFile.ReadLine();
					sTemp2 = StrPrepare(sTemp2);
					ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
					iTemp = iTemp + 1;

					if (!string.IsNullOrEmpty(sTemp2) & sTemp2.StartsWith("//") == false)
					{
						if (sTemp2.StartsWith("push_const ") == false)
						{
							MessageBox.Show("Not found 'push_const' after 'fetch_i' in " + Conversions.ToString(iTemp) + " line.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
							iErrFlag = true;
							break;
						}
					}

					aTemp = sTemp2.Split((char)32);
					sTempFetchID = aTemp[1];

					if (SearchAllFetch(sTempFetchID, sTempFetchName, sTempEventName) == false)
					{
						Array.Resize(ref sFetchID, iFuncCounter + 1);
						Array.Resize(ref sFetchName, iFuncCounter + 1);
						Array.Resize(ref sFetchEventName, iFuncCounter + 1);
						if (Array.IndexOf(sFetchID, sTempFetchID) == -1)
							sFetchEventName[iFuncCounter] = "default";
						else
							sFetchEventName[iFuncCounter] = sTempEventName;

						sFetchName[iFuncCounter] = sTempFetchName;
						sFetchID[iFuncCounter] = sTempFetchID;
						iFuncCounter = iFuncCounter + 1;

						// Make dublicate previous push_event for default value
						if ((sFetchEventName[iFuncCounter - 1] ?? "") == "default" & FetchDefaultCopyCheckBox.Checked == true)
						{
							Array.Resize(ref sFetchID, iFuncCounter + 1);
							Array.Resize(ref sFetchName, iFuncCounter + 1);
							Array.Resize(ref sFetchEventName, iFuncCounter + 1);

							sFetchName[iFuncCounter] = sTempFetchName;
							sFetchID[iFuncCounter] = sTempFetchID;
							sFetchEventName[iFuncCounter] = sTempEventName;
							iFuncCounter = iFuncCounter + 1;
						}
					}
				}
			}

			ProgressBar.Value = 0;
			inFile.Close();

			if (iErrFlag == false)
			{
				MessageBox.Show("Fetch ID's collecting complete. Success." + Constants.vbNewLine + " Found " + Conversions.ToString(iFuncCounter) + " events.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

				SaveFileDialog.FileName = "ai_fetch_i.txt";
				if (SaveFileDialog.ShowDialog() != DialogResult.Cancel)
					sFile = SaveFileDialog.FileName;
				else
					return;
				var outFile = new System.IO.StreamWriter(SaveFileDialog.FileName, false, System.Text.Encoding.Default, 1);

				outFile.WriteLine("// --------------------------");
				outFile.WriteLine("// L2ScriptMaker (4.0.46.10+)");
				outFile.WriteLine("// AI Decompiler 'fetch_i' list");
				outFile.WriteLine("// updated: " + Conversions.ToString(DateAndTime.Now));
				outFile.WriteLine("// --------------------------");
				outFile.WriteLine("// format:");
				outFile.WriteLine("// fetch_i id|previous 'push_event // ' name|fetch name");
				var loopTo = iFuncCounter - 1;

				// 656|default|last_attacker
				// 656|ON_START|myself

				for (iTemp = 0; iTemp <= loopTo; iTemp++)
				{
					sTemp = sFetchID[iTemp] + "|" + sFetchEventName[iTemp] + "|" + sFetchName[iTemp];
					outFile.WriteLine(sTemp);
				}
				outFile.Close();
			}
		}



		private void CollectHandlerButton_Click(object sender, EventArgs e)
		{

			// handler 0 9	//  NO_DESIRE

			string sTemp;  // , sFile As String = ""
			string[] aTemp;
			int iTemp = 0;
			bool iErrFlag = false;

			string sClassType = "";

			var sHandlerID = new string[1];
			var sHandlerName = new string[1];
			var sHandlerClassType = new string[1];
			int iFuncCounter = 0;

			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);

			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				sTemp = StrPrepare(sTemp);
				iTemp = iTemp + 1;

				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false & sTemp.StartsWith("class ") == true)
				{
					// class 1 default_npc : (null)
					aTemp = sTemp.Split((char)32);
					sClassType = aTemp[1];
				}

// RepeateRead:
				;
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false & sTemp.StartsWith("handler ") == true)
				{
					aTemp = sTemp.Split((char)32);

					// handler(0) 0(1) 9(2)	//(3)  NO_DESIRE(4)
					if (aTemp.Length < 3)
					{
						MessageBox.Show("Not found '//' in " + Conversions.ToString(iTemp) + " line." + Constants.vbNewLine + "Stream:" + sTemp, "No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
						iErrFlag = true;
						break;
					}

					if (Array.IndexOf(sHandlerName, aTemp[4]) == -1)
					{
						Array.Resize(ref sHandlerID, iFuncCounter + 1);
						Array.Resize(ref sHandlerName, iFuncCounter + 1);
						Array.Resize(ref sHandlerClassType, iFuncCounter + 1);

						sHandlerID[iFuncCounter] = aTemp[1];
						sHandlerName[iFuncCounter] = aTemp[4];
						sHandlerClassType[iFuncCounter] = sClassType;
						iFuncCounter = iFuncCounter + 1;
					}
				}
			}

			ProgressBar.Value = 0;
			inFile.Close();

			if (iErrFlag == false)
			{
				MessageBox.Show("Handler's collecting complete. Success." + Constants.vbNewLine + " Found " + Conversions.ToString(iFuncCounter) + " handlers.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

				SaveFileDialog.FileName = "ai_handlers.txt";
				if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				var outFile = new System.IO.StreamWriter(SaveFileDialog.FileName, false, System.Text.Encoding.Default, 1);

				outFile.WriteLine("// --------------------------");
				outFile.WriteLine("// L2ScriptMaker (4.0.46.10+)");
				outFile.WriteLine("// AI Decompiler 'HANDLER' list");
				outFile.WriteLine("// updated: " + Conversions.ToString(DateAndTime.Now));
				outFile.WriteLine("// --------------------------");
				outFile.WriteLine("// format:");
				outFile.WriteLine("// handler id|specific class type (1,2)|handler name");
				var loopTo = iFuncCounter - 1;

				// 0|1|NO_DESIRE
				for (iTemp = 0; iTemp <= loopTo; iTemp++)
				{
					sTemp = sHandlerID[iTemp] + "|" + sHandlerClassType[iTemp] + "|" + sHandlerName[iTemp];
					outFile.WriteLine(sTemp);
				}
				outFile.Close();
			}
		}

		private void CollectFuncButton_Click(object sender, EventArgs e)
		{
			string sTemp;
			// func_call 184680516	//  func[ShowPage]

			string sFile = "";
			string[] aTemp;
			int iTemp = 0;
			bool iErrFlag = false;

			var sFuncID = new string[1];
			var sFuncName = new string[1];
			var sFuncOut = new string[1];
			int iFuncCounter = 0;

			if (OpenFileDialog.ShowDialog() != DialogResult.Cancel)
				sFile = OpenFileDialog.FileName;
			var inFile = new System.IO.StreamReader(sFile, System.Text.Encoding.Default, true, 1);

			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				sTemp = StrPrepare(sTemp);
				iTemp = iTemp + 1;

				RepeateRead:
				
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false & sTemp.StartsWith("func_call") == true)
				{
					aTemp = sTemp.Split((char)32);

					// func_call(0) 184680516(1)	//(2)  func[ShowPage](3)
					if (aTemp.Length < 2)
					{
						MessageBox.Show("Not found '//' in " + Conversions.ToString(iTemp) + " line.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
						iErrFlag = true;
						break;
					}

					if (Array.IndexOf(sFuncID, aTemp[1]) == -1)
					{
						aTemp[3] = aTemp[3].Replace("func[", "").Replace("]", "");

						Array.Resize(ref sFuncID, iFuncCounter + 1);
						Array.Resize(ref sFuncName, iFuncCounter + 1);
						Array.Resize(ref sFuncOut, iFuncCounter + 1);

						sFuncID[iFuncCounter] = aTemp[1];
						sFuncName[iFuncCounter] = aTemp[3];
						iFuncCounter = iFuncCounter + 1;

						sTemp = inFile.ReadLine();
						ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
						iTemp = iTemp + 1;
						sTemp = StrPrepare(sTemp);

						if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
						{
							if (sTemp.StartsWith("shift_sp") == true)
							{
								// func_call 184745993	//  func[AddAttackDesire]
								// shift_sp(0) -3(1)  - сброс входящих параметров
								// shift_sp(0) -1(1)  - закрытие функции
								// если нет параметров, то сразу идёт -1
								// возможно за параметрами идёт другая функция, а закрытие идёт позже

								aTemp = sTemp.Split((char)32);
								sFuncOut[iFuncCounter - 1] = aTemp[1].Replace("-", "");
							}
							else
							{
								sFuncOut[iFuncCounter - 1] = "0";
								goto RepeateRead;
							}
						}
					}
				}
			}

			ProgressBar.Value = 0;
			inFile.Close();

			if (iErrFlag == false)
			{
				SaveFileDialog.FileName = "ai_functions.txt";
				if (SaveFileDialog.ShowDialog() != DialogResult.Cancel)
					sFile = SaveFileDialog.FileName;
				else
					return;
				var outFile = new System.IO.StreamWriter(SaveFileDialog.FileName, false, System.Text.Encoding.Default, 1);

				outFile.WriteLine("// --------------------------");
				outFile.WriteLine("// L2ScriptMaker (4.0.46.10+)");
				outFile.WriteLine("// AI Decompiler 'func_call' list");
				outFile.WriteLine("// updated: " + Conversions.ToString(DateAndTime.Now));
				outFile.WriteLine("// --------------------------");
				outFile.WriteLine("// format:");
				outFile.WriteLine("// func_id|name|incoming_params_value|output_params_value(nouse)");
				var loopTo = iFuncCounter - 1;
				for (iTemp = 0; iTemp <= loopTo; iTemp++)
				{
					sTemp = sFuncID[iTemp] + "|" + sFuncName[iTemp] + "," + sFuncOut[iTemp] + ",0";
					outFile.WriteLine(sTemp);
				}
				outFile.Close();

				MessageBox.Show("Function ID's collecting complete. Success." + Constants.vbNewLine + " Found " + Conversions.ToString(iFuncCounter) + " functions.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private string StrPrepare(string Msg)
		{
			Msg = Msg.Replace((char)9, (char)32).Replace("  ", " ").Trim();
			while (Strings.InStr(Msg, "  ") != 0)
				Msg = Msg.Replace("  ", " ");
			return Msg;
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

	}
}
