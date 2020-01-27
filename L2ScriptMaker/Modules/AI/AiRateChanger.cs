using L2ScriptMaker.Extensions;
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

namespace L2ScriptMaker.Modules.AI
{
	public partial class AiRateChanger : Form
	{
		public AiRateChanger()
		{
			InitializeComponent();
		}

		private string[] QuestPchName = new string[2001];

		private void ButtonQuest_Click(object sender, EventArgs e)
		{
			string AiFile;
			string TempStr;

			if (CheckBoxAdena.Checked == false & CheckBoxExp.Checked == false & CheckBoxSP.Checked == false)
			{
				MessageBox.Show("No more jobs. Select need params and try again.", "No job", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			OpenFileDialog.Filter = "Lineage II AI file|ai.obj|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			AiFile = OpenFileDialog.FileName;

			// Work with ai.obj
			var inAi = new System.IO.StreamReader(AiFile, System.Text.Encoding.Unicode, true, 1);
			var outAi = new System.IO.StreamWriter(AiFile + ".fixed.ai", false, System.Text.Encoding.Unicode, 1);
			var outAiLog = new System.IO.StreamWriter(AiFile + ".fixed.log", false, System.Text.Encoding.Unicode, 1);

			outAiLog.WriteLine("AI Rate Changer: Start at" + Constants.vbTab + Conversions.ToString(DateAndTime.Now) + Constants.vbNewLine);

			ProgressBar.Maximum = Conversions.ToInteger(inAi.BaseStream.Length);
			ProgressBar.Value = 0;

			string tempClass = "";
			string tempHandler = "";
			var ReadBuffer = new string[4];

			// push_const 7586
			// push_const 2
			// func_call 184746111     //  func[GiveItem1]

			// 0 - Exp, 1 - SP
			// push_const 0
			// push_const 3600
			// func_call 184746219 //  func[IncrementParam]

			short HaveNegate = Conversions.ToShort(0);
			int ReadCount = -1;
			int iTemp = 0;
			string sTemp = "";
			double Divider = 0;

			while (inAi.EndOfStream != true)
			{
				TempStr = inAi.ReadLine();

				if ((Strings.Mid(TempStr, 1, 6) ?? "") == "class ")
					tempClass = TempStr;
				if ((Strings.Mid(TempStr, 1, 8) ?? "") == "handler ")
					tempHandler = TempStr;

				if (Strings.InStr(TempStr, "push_const ") != 0)
				{
					ReadCount = 0;
					ReadBuffer[ReadCount] = TempStr;

					// Check first param
					Divider = 0;
					sTemp = ReadBuffer[0].Replace((char)9, (char)32).Trim();

					if ((sTemp ?? "") != ("push_const " + TextBoxItem.Text ?? ""))
					{
						if ((sTemp ?? "") != "push_const 0")
						{
							if ((sTemp ?? "") != "push_const 1")
								goto Unload; // SP
							if (CheckBoxSP.Checked == false)
								goto Unload;
							Divider = Conversions.ToDouble(TextBoxSP.Text);
						}
						else
						{
							if (CheckBoxExp.Checked == false)
								goto Unload;
							Divider = Conversions.ToDouble(TextBoxExp.Text);
						}
					}
					else
					{
						if (CheckBoxAdena.Checked == false)
							goto Unload;
						Divider = Conversions.ToDouble(TextBoxAdena.Text);
					}

					TempStr = inAi.ReadLine();
					ReadCount = 1;
					ReadBuffer[ReadCount] = TempStr;
					if (Strings.InStr(TempStr, "push_const ") != 0)
					{
						TempStr = inAi.ReadLine();
						ReadCount = 2;
						ReadBuffer[ReadCount] = TempStr;
						if (Strings.InStr(TempStr, "negate") != 0)
						{
							TempStr = inAi.ReadLine();
							ReadCount = 3;
							ReadBuffer[ReadCount] = TempStr;
							HaveNegate = Conversions.ToShort(1);
						}

						var loopTo = CheckedListBox.CheckedItems.Count - 1;
						for (iTemp = 0; iTemp <= loopTo; iTemp++)
						{
							if (Strings.InStr(tempHandler, CheckedListBox.CheckedItems[iTemp].ToString()) != 0)
								goto Unload;
						}

						// Check thrird param
						switch (sTemp)
						{
							case var @case when @case == "push_const " + TextBoxItem.Text:
								{
									if (Strings.InStr(TempStr, "func[GiveItem1]") == 0)
										goto Unload;
									break;
								}

							case "push_const 0":
								{
									if (Strings.InStr(TempStr, "func[IncrementParam]") == 0)
										goto Unload;
									break;
								}

							case "push_const 1":
								{
									if (Strings.InStr(TempStr, "func[IncrementParam]") == 0)
										goto Unload;
									break;
								}

							default:
								{
									break;
								}
						}

						// Achtung. Start fixing!
						iTemp = Conversions.ToInteger(ReadBuffer[1].Replace((char)9, (char)32).Trim().Replace("push_const ", ""));
						ReadBuffer[1] = ReadBuffer[1].Replace("push_const " + iTemp.ToString(), "push_const " + Conversions.ToInteger(iTemp * Divider).ToString());
						outAiLog.WriteLine(Constants.vbNewLine + tempClass + Constants.vbNewLine + tempHandler);
						outAiLog.Write("Rebuild: ");
						switch (sTemp)
						{
							case var case1 when case1 == "push_const " + TextBoxItem.Text:
								{
									outAiLog.Write("adena");
									break;
								}

							case "push_const 0":
								{
									outAiLog.Write("exp");
									break;
								}

							case "push_const 1":
								{
									outAiLog.Write("SP");
									break;
								}

							default:
								{
									break;
								}
						}
						outAiLog.WriteLine(Constants.vbTab + "with divider: " + Conversions.ToString(Divider) + Constants.vbTab + "From: " + iTemp.ToString() + Constants.vbTab + "To: " + Conversions.ToInteger(iTemp * Divider).ToString());
					}

					Unload:

					var loopTo1 = ReadCount;

					// Unload all data to dist
					for (iTemp = 0; iTemp <= loopTo1; iTemp++)
						outAi.WriteLine(ReadBuffer[iTemp]);
					Array.Clear(ReadBuffer, 0, 4);
					HaveNegate = Conversions.ToShort(0);
				}

				if (ReadCount != -1)
					ReadCount = -1;
				else
					outAi.WriteLine(TempStr);

				ProgressBar.Value = Conversions.ToInteger(inAi.BaseStream.Position);
				this.Update();
			}

			ProgressBar.Value = 0;
			outAiLog.WriteLine(Constants.vbNewLine + "AI Rate Changer: End at " + DateAndTime.Now.ToString() + Constants.vbNewLine);
			inAi.Close();
			outAi.Close();
			outAiLog.Close();


			MessageBox.Show("Fixing done. Check Log file for full information.", "Complete", MessageBoxButtons.OK);
			// Interaction.Shell("notepad.exe " + AiFile + ".fixed.log", AppWinStyle.NormalFocus);
			Process.Start("notepad.exe", AiFile + ".fixed.log");
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void AiRateChanger_Load(object sender, EventArgs e)
		{
			TextBoxAdena.Enabled = false;
			TextBoxExp.Enabled = false;
			TextBoxSP.Enabled = false;
			CheckBoxAdena.Checked = false;
			CheckBoxExp.Checked = false;
			CheckBoxSP.Checked = false;
			string sTemp;
			var iTemp = default(int);

			OpenFileDialog.FileName = "questname-e.txt";
			if (System.IO.File.Exists("questname-e.txt") == false)
			{
				OpenFileDialog.Title = "Select Questname-e.txt file...";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
			}

			var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);
			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				sTemp = Libraries.GetNeedParamFromStr(sTemp, "name").Replace("[", "").Replace("]", "");
				if (QuestListBox.Items.IndexOf(sTemp) == -1)
				{
					QuestListBox.Items.Add(sTemp);
					QuestPchName[iTemp] = Libraries.GetNeedParamFromStr(sTemp, "id");
				}
			}
			inFile.Close();
		}

		private void CheckBoxAdena_CheckedChanged(object sender, EventArgs e)
		{
			if (CheckBoxAdena.Checked == false)
				TextBoxAdena.Enabled = false;
			else
				TextBoxAdena.Enabled = true;
		}

		private void CheckBoxExp_CheckedChanged(object sender, EventArgs e)
		{
			if (CheckBoxExp.Checked == false)
				TextBoxExp.Enabled = false;
			else
				TextBoxExp.Enabled = true;
		}

		private void CheckBoxSP_CheckedChanged(object sender, EventArgs e)
		{
			if (CheckBoxSP.Checked == false)
				TextBoxSP.Enabled = false;
			else
				TextBoxSP.Enabled = true;
		}

		private void CheckBoxItem_CheckedChanged(object sender, EventArgs e)
		{
			if (CheckBoxItem.Checked == false)
				TextBoxItem.Enabled = false;
			else
				TextBoxItem.Enabled = true;
		}

		private void TextBoxItem_Leave(object sender, EventArgs e)
		{
			TextBoxItem.Text = TextBoxItem.Text.Trim();
			if ((Conversions.ToInteger(TextBoxItem.Text).ToString() ?? "") != (TextBoxItem.Text ?? ""))
			{
				TextBoxItem.Text = "57";
				return;
			}
			if (Conversions.ToInteger(TextBoxItem.Text) < 2 | Conversions.ToInteger(TextBoxItem.Text) > 40000)
			{
				TextBoxItem.Text = "57";
				return;
			}
		}

		private void TextBoxAdena_Leave(object sender, EventArgs e)
		{
			TextBoxAdena.Text = TextBoxAdena.Text.Trim();
			try
			{
				if ((Conversions.ToDouble(TextBoxAdena.Text).ToString() ?? "") != (TextBoxAdena.Text ?? ""))
				{
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Wrong value: 1) is not Digital Value 2) check digital symbol in Regional Setting", "Wrong value", MessageBoxButtons.OK, MessageBoxIcon.Error);
				TextBoxAdena.Text = "1";
				return;
			}
			if (Conversions.ToDouble(TextBoxAdena.Text) < 0 | Conversions.ToDouble(TextBoxAdena.Text) > 101)
				TextBoxAdena.Text = "1";
		}

		private void TextBoxExp_Leave(object sender, EventArgs e)
		{
			TextBoxExp.Text = TextBoxExp.Text.Trim();
			try
			{
				if ((Conversions.ToDouble(TextBoxExp.Text).ToString() ?? "") != (TextBoxExp.Text ?? ""))
				{
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Wrong value: 1) is not Digital Value 2) check digital symbol in Regional Setting", "Wrong value", MessageBoxButtons.OK, MessageBoxIcon.Error);
				TextBoxExp.Text = "1";
				return;
			}

			if (Conversions.ToDouble(TextBoxExp.Text) < 0 | Conversions.ToDouble(TextBoxExp.Text) > 101)
				TextBoxExp.Text = "1";
		}

		private void TextBoxSP_Leave(object sender, EventArgs e)
		{
			TextBoxSP.Text = TextBoxSP.Text.Trim();
			try
			{
				if ((Conversions.ToDouble(TextBoxSP.Text).ToString() ?? "") != (TextBoxSP.Text ?? ""))
				{
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Wrong value: 1) is not Digital Value 2) check digital symbol in Regional Setting", "Wrong value", MessageBoxButtons.OK, MessageBoxIcon.Error);
				TextBoxSP.Text = "1";
				return;
			}
			if (Conversions.ToDouble(TextBoxSP.Text) < 0 | Conversions.ToDouble(TextBoxSP.Text) > 101)
				TextBoxSP.Text = "1";
		}

		private void QuestListCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (QuestListCheckBox.Checked == false)
				QuestListBox.Enabled = false;
			else
				QuestListBox.Enabled = true;
		}

		private void QuestSelectButton_Click(object sender, EventArgs e)
		{
			int iTemp;
			var loopTo = QuestListBox.Items.Count - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
				QuestListBox.SetItemChecked(iTemp, true);
		}

		private void QuestDeSelectButton_Click(object sender, EventArgs e)
		{
			int iTemp;
			var loopTo = QuestListBox.Items.Count - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
				QuestListBox.SetItemChecked(iTemp, false);
		}

		private void SelectAllButton_Click(object sender, EventArgs e)
		{
			int iTemp;
			var loopTo = CheckedListBox.Items.Count - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
				CheckedListBox.SetItemChecked(iTemp, true);
		}

		private void DeselectAllButton_Click(object sender, EventArgs e)
		{
			int iTemp;
			var loopTo = CheckedListBox.Items.Count - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
				CheckedListBox.SetItemChecked(iTemp, false);
		}
	}
}
