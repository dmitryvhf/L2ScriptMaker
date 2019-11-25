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
	public partial class AIHandlersChecker : Form
	{
		public AIHandlersChecker()
		{
			InitializeComponent();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			string CheckFile;

			OpenFileDialog.Filter = "Lineage II Intelligence file|ai.obj|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			CheckFile = OpenFileDialog.FileName;

			var inFile = new System.IO.StreamReader(CheckFile, System.Text.Encoding.Default, true, 1);
			var outFile =
				new System.IO.StreamWriter(CheckFile + "_scriptCheck.log", true, System.Text.Encoding.Unicode, 1);

			outFile.WriteLine("L2ScriptMaker: AI Handlers Checker");
			outFile.WriteLine(Conversions.ToString(DateAndTime.Now) + " Start");
			outFile.WriteLine("File: " + CheckFile);
			outFile.WriteLine();

			string sTemp = "";
			string[] sTemp2;
			string FlagClassName = "";
			string FlagHandlerName = "";
			int FlagHandlerLenght1 = 0;
			int FlagHandlerLenght2 = 0;
			long LineNum = 0;
			long LineNumHandler;

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			this.Refresh();
			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				LineNum += 1;
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
				this.Update();

				if (sTemp.StartsWith("class "))
					FlagClassName = sTemp;
				if (sTemp.StartsWith("handler "))
				{
					LineNumHandler = LineNum;
					FlagHandlerName = sTemp;
					sTemp2 = sTemp.Split();
					FlagHandlerLenght1 = Conversions.ToInteger(sTemp2[2]);

					// Start Handler Reading
					FlagHandlerLenght2 = 0;
					sTemp = inFile.ReadLine();
					LineNum += 1;
					while (sTemp.StartsWith("handler_end") != true)
					{
						sTemp = sTemp.Replace((char) 9, (char) 32).Trim();

						if (sTemp.StartsWith("variable_") == true)
							goto nextItem;
						if (sTemp.StartsWith(Conversions.ToString((char) 34)) == true)
							goto nextItem;
						if (sTemp.StartsWith("//") == true)
							goto nextItem;
						if (sTemp.StartsWith("L") == true)
						{
							// HR and Kvoxi counting metod without label Lxxx
							if (NoLabelsCheckBox.Checked == true)
								goto nextItem;
						}

						if (sTemp == null)
							goto nextItem;

						FlagHandlerLenght2 += 1;
						nextItem:
						sTemp = inFile.ReadLine();
						LineNum += 1;
					}

					if (FlagHandlerLenght1 != FlagHandlerLenght2)
					{
						outFile.WriteLine("");
						outFile.WriteLine("Class  : " + FlagClassName);
						outFile.WriteLine("Handler: " + FlagHandlerName);
						outFile.WriteLine("Line: [" + LineNumHandler.ToString() + "]");
						outFile.WriteLine("Class value:" + FlagHandlerLenght1.ToString() +
						                  Conversions.ToString((char) 9) + "Real value: " +
						                  FlagHandlerLenght2.ToString());
					}
				}
			}

			outFile.WriteLine(Conversions.ToString(DateAndTime.Now) + Constants.vbNewLine);
			ToolStripProgressBar.Value = 0;
			MessageBox.Show("Done.");
			outFile.WriteLine();

			inFile.Close();
			outFile.Close();
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void HandlerVariableCheckButton_Click(object sender, EventArgs e)
		{
			string AiFile;

			OpenFileDialog.Filter = "Lineage II AI file|*.obj|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			AiFile = OpenFileDialog.FileName;

			var inAi = new System.IO.StreamReader(AiFile, System.Text.Encoding.Default, true, 1);
			var outAiLog =
				new System.IO.StreamWriter(AiFile + "_scriptCheck.log", true, System.Text.Encoding.Unicode, 1);
			outAiLog.WriteLine("L2ScriptMaker: AI.obj Handler Variable Checker. Start time: " +
			                   DateAndTime.Now.ToString() + Constants.vbNewLine);
			outAiLog.Flush();

			var aVar = new string[1];
			string sTemp;
			int iTemp;

			// check controls
			string ClassNameMarker = "";
			string HandlerNameMarker = "";
			string LastPushConstMarker = "";

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inAi.BaseStream.Length);

			while (inAi.EndOfStream != true)
			{
				sTemp = inAi.ReadLine().Trim();
				// TempStr = TempStr.Trim

				ToolStripProgressBar.Value = Conversions.ToInteger(inAi.BaseStream.Position);
				StatusStrip.Update();
				this.Update();


				if (sTemp.StartsWith("class ") == true)
					ClassNameMarker = sTemp;

				if (sTemp.StartsWith("handler ") == true)
					HandlerNameMarker = sTemp.Remove(0, Strings.InStr(sTemp, "//") + 2).Trim();

				if (sTemp.StartsWith("variable_begin") == true)
				{
					Array.Clear(aVar, 0, aVar.Length);
					Array.Resize(ref aVar, 0);

					sTemp = inAi.ReadLine().Trim();
					while ((sTemp ?? "") != "variable_end")
					{
						// "_from_choice"
						if (!string.IsNullOrEmpty(sTemp.Trim()))
						{
							sTemp = sTemp.Replace("\"", "");
							Array.Resize(ref aVar, aVar.Length + 1);
							aVar[aVar.Length - 1] = sTemp;
						}

						sTemp = inAi.ReadLine().Trim();
					}
				}

				if (sTemp.StartsWith("push_event") == true & Strings.InStr(sTemp, "//") > 1)
				{
					// sTemp = sTemp.Replace(Chr(9), "").Replace(Chr(32), "")
					sTemp = sTemp.Remove(0, Strings.InStr(sTemp, "//") + 2).Trim();
					if ((sTemp ?? "") != "gg")
					{
						iTemp = Array.IndexOf(aVar, sTemp);
						if (iTemp == -1)
						{
							outAiLog.WriteLine(Constants.vbTab + "Class: " + ClassNameMarker + Constants.vbTab +
							                   "Handler: " + HandlerNameMarker);
							outAiLog.WriteLine(">>>>>> Not found variable:" + sTemp + Constants.vbNewLine);
						}
					}
				}
			}

			ToolStripProgressBar.Value = 0;

			outAiLog.WriteLine("L2ScriptMaker: AI.obj Handler Variable Checker. End time: " +
			                   DateAndTime.Now.ToString() + Constants.vbNewLine);
			outAiLog.WriteLine();
			outAiLog.Close();
			inAi.Close();

			MessageBox.Show("Complete.");
		}
	}
}