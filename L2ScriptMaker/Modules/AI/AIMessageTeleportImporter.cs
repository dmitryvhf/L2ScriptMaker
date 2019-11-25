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
	public partial class AIMessageTeleportImporter : Form
	{
		public AIMessageTeleportImporter()
		{
			InitializeComponent();
		}

		private void ButtonExport_Click(object sender, EventArgs e)
		{
			string AiFile;
			string AiExport;
			string TempStr;

			OpenFileDialog.Filter = "Ai.obj file|*.obj|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			else
			{
				AiFile = OpenFileDialog.FileName;
				AiFileBox.Text = AiFile;
			}

			AiExport = System.IO.Path.GetDirectoryName(OpenFileDialog.FileName) + @"\ai_teleport_exports.txt";
			if (System.IO.File.Exists(AiExport))
			{
				MessageBox.Show("Export file 'ai_teleport_exports.txt' exist. Delete and try again", "File exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var inAiFile = new System.IO.StreamReader(AiFile, System.Text.Encoding.Default, true, 1);
			var inExpFile = new System.IO.StreamWriter(AiExport, false, System.Text.Encoding.Unicode, 1);

			string AiClassName = "";
			ProgressBar.Maximum = Conversions.ToInteger(inAiFile.BaseStream.Length);
			ProgressBar.Value = 0;

			while (inAiFile.EndOfStream != true)
			{
				TempStr = inAiFile.ReadLine();
				if (TempStr.StartsWith("class ") == true)
					AiClassName = TempStr;

				if (Strings.InStr(TempStr, "telposlist_begin") != 0)
				{
					inExpFile.WriteLine(AiClassName);
					StatusText.Text = "Export :" + AiClassName;
					StatusText.Update();

					// TempStr = inAiFile.ReadLine
					while (Strings.InStr(TempStr, "property_define_end") == 0)
					{
						if (Strings.InStr(TempStr, "telposlist_begin") != 0)
						{
							TempStr = inAiFile.ReadLine();
							while (Strings.InStr(TempStr, "telposlist_end") == 0)
							{
								int FirstPoint = Strings.InStr(TempStr, Conversions.ToString((char)34));
								int SecondPoint = Strings.InStr(FirstPoint + 1, TempStr, Conversions.ToString((char)34));
								TempStr = Strings.Mid(TempStr, FirstPoint + 1, SecondPoint - FirstPoint - 1);

								inExpFile.WriteLine(Conversions.ToString((char)34) + TempStr + Conversions.ToString((char)34));
								if (string.IsNullOrEmpty(TempStr))
									MessageBox.Show("You cant have empty teleport name. Use <br> for new line", "Empty name");
								TempStr = inAiFile.ReadLine();
							}
						}
						TempStr = inAiFile.ReadLine();
					}
					StatusText.Text = "Finding new teleport list...";
				}

				ProgressBar.Value = Conversions.ToInteger(inAiFile.BaseStream.Position * 100 / (double)inAiFile.BaseStream.Length);
				this.Update();
			}

			ProgressBar.Value = 0;
			MessageBox.Show("Export complete. Target file is 'ai_teleport_exports.txt'.", "Complete.", MessageBoxButtons.OK, MessageBoxIcon.Information);
			StatusText.Text = "Done.";

			inAiFile.Close();
			inExpFile.Close();
		}

		private void ButtonImport_Click(object sender, EventArgs e)
		{
			string AiFile;
			string AiImport;
			string TempStr;
			string TempStr2;

			OpenFileDialog.Filter = "Ai.obj file|*.obj|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			else
			{
				AiFile = OpenFileDialog.FileName;
				AiFileBox.Text = AiFile;
			}

			OpenFileDialog.Filter = "Ai.obj teleport name list file|*.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			else
			{
				AiImport = OpenFileDialog.FileName;
				AiImportBox.Text = AiImport;
			}

			var TeleportListNpc = new string[1];
			int iTemp = -1;
			System.IO.StreamReader TelListFile;
			TelListFile = new System.IO.StreamReader(AiImport, System.Text.Encoding.Default, true, 1);
			while (TelListFile.EndOfStream != true)
			{
				TempStr = TelListFile.ReadLine();
				if (TempStr.StartsWith("class ") == true)
				{
					iTemp += 1;
					Array.Resize(ref TeleportListNpc, iTemp + 1);
					TeleportListNpc[iTemp] = TempStr;
				}
			}
			TelListFile.Close();

			System.IO.File.Copy(AiFile, System.IO.Path.GetFileNameWithoutExtension(AiFile) + ".bak", true);
			var inAiFile = new System.IO.StreamReader(System.IO.Path.GetFileNameWithoutExtension(AiFile) + ".bak", System.Text.Encoding.Default, true, 1);
			var oAiFile = new System.IO.StreamWriter(AiFile, false, System.Text.Encoding.Unicode, 1);

			string AiClassName = "";
			ProgressBar.Maximum = Conversions.ToInteger(inAiFile.BaseStream.Length);
			ProgressBar.Value = 0;

			while (inAiFile.EndOfStream != true)
			{
				TempStr = inAiFile.ReadLine();
				if (TempStr.StartsWith("class ") == true)
				{
					AiClassName = TempStr;

					// Enter to Import Engine
					iTemp = Array.IndexOf(TeleportListNpc, TempStr);
					if (iTemp != -1)
					{
						oAiFile.WriteLine(TempStr);

						StatusText.Text = "Import :" + AiClassName;
						StatusText.Update();

						TelListFile = new System.IO.StreamReader(AiImport, System.Text.Encoding.Default, true, 1);
						while ((TelListFile.ReadLine() ?? "") != (TempStr ?? ""))
						{
						}

						// finding of teleport list in ai.obj
						while (Strings.InStr(TempStr, "telposlist_begin") == 0)
						{
							TempStr = inAiFile.ReadLine();
							oAiFile.WriteLine(TempStr);
						}

						// start fixing
						if (Strings.InStr(TempStr, "telposlist_begin") != 0)
						{

							// TempStr = inAiFile.ReadLine
							while (Strings.InStr(TempStr, "property_define_end") == 0)
							{
								if (Strings.InStr(TempStr, "telposlist_begin") != 0)
								{
									TempStr = inAiFile.ReadLine();
									while (Strings.InStr(TempStr, "telposlist_end") == 0)
									{
										int FirstPoint = Strings.InStr(TempStr, Conversions.ToString((char)34));
										int SecondPoint = Strings.InStr(FirstPoint + 1, TempStr, Conversions.ToString((char)34));
										TempStr2 = Strings.Mid(TempStr, FirstPoint + 1, SecondPoint - FirstPoint - 1);
										TempStr = TempStr.Replace(TempStr2, TelListFile.ReadLine().Replace(Conversions.ToString((char)34), ""));
										oAiFile.WriteLine(TempStr);
										TempStr = inAiFile.ReadLine();
									}
									oAiFile.WriteLine(TempStr);
								}
								TempStr = inAiFile.ReadLine();
								oAiFile.WriteLine(TempStr);
							}
							StatusText.Text = "Finding new teleport list...";
						}
						TelListFile.Close();
					}
					else
						oAiFile.WriteLine(TempStr);
				}
				else
					oAiFile.WriteLine(TempStr);

				ProgressBar.Value = Conversions.ToInteger(inAiFile.BaseStream.Position * 100 / (double)inAiFile.BaseStream.Length);
				this.Update();
			}

			ProgressBar.Value = 0;
			MessageBox.Show("Import complete.", "Complete.", MessageBoxButtons.OK, MessageBoxIcon.Information);
			StatusText.Text = "Done.";

			inAiFile.Close();
			oAiFile.Close();
		}


		private void ButtonAbout_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Module for creating file with teleport list and import to another file." + Constants.vbNewLine + "Use for teleport name translation", "About module", MessageBoxButtons.OK);
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
