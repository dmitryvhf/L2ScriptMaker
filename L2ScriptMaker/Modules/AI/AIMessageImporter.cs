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
	public partial class AIMessageImporter : Form
	{
		public AIMessageImporter()
		{
			InitializeComponent();
		}

		private void ButtonExport_Click(object sender, EventArgs e)
		{
			string AiFile;
			string AiExport;
			string TempStr;

			OpenFileDialog.Filter = "Ai.obj file |*.obj|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			else
				AiFile = OpenFileDialog.FileName;
			AiExport = System.IO.Path.GetDirectoryName(OpenFileDialog.FileName) + @"\ai_exports.txt";
			if (System.IO.File.Exists(AiExport))
			{
				MessageBox.Show("Export file 'ai_exports.txt' exist. Delete and try again", "File exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var inAiFile = new System.IO.StreamReader(AiFile, System.Text.Encoding.Default, true, 1);
			var inExpFile = new System.IO.StreamWriter(AiExport, false, System.Text.Encoding.Unicode, 1);

			while (inAiFile.EndOfStream != true)
			{
				TempStr = inAiFile.ReadLine();
				if (!string.IsNullOrEmpty(TempStr))
				{
					if ((Strings.Mid(TempStr, 1, 1) ?? "") == "S" & Strings.InStr(TempStr, ".") != 0)
						inExpFile.WriteLine(TempStr);
				}
			}

			MessageBox.Show("Export complete. Target file is 'ai_exports.txt'", "Complete.", MessageBoxButtons.OK, MessageBoxIcon.Information);

			inAiFile.Close();
			inExpFile.Close();
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ButtonImport_Click(object sender, EventArgs e)
		{
			string AiFile;
			string AiFixFile;
			string WorkDir;
			string TempStr;

			OpenFileDialog.Filter = "Ai.obj file |*.obj|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			AiFile = OpenFileDialog.FileName;

			OpenFileDialog.Filter = "Ai.obj Sxxx fix file |*.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			AiFixFile = OpenFileDialog.FileName;

			WorkDir = System.IO.Path.GetDirectoryName(OpenFileDialog.FileName);

			System.IO.File.Copy(AiFile, System.IO.Path.GetFileNameWithoutExtension(AiFile) + ".bak", true);
			var inAiFile = new System.IO.StreamReader(System.IO.Path.GetFileNameWithoutExtension(AiFile) + ".bak", System.Text.Encoding.Default, true, 1);
			var inImpFile = new System.IO.StreamReader(AiFixFile, System.Text.Encoding.Default, true, 1);
			var outAiFile = new System.IO.StreamWriter(AiFile, false, System.Text.Encoding.Unicode, 1);

			// Loading S.. table
			// S1042.  "pccafe_notpoint001.htm"
			var STable = new string[50001];
			var TempRead = new string[2];
			int value1;
			string value2;

			while (inImpFile.EndOfStream != true)
			{
				TempStr = inImpFile.ReadLine();

				value1 = Conversions.ToInteger(Strings.Mid(TempStr, 2, Strings.InStr(TempStr, ".") - 2));
				value2 = Strings.Mid(TempStr, Strings.InStr(TempStr, Conversions.ToString((char)34)) + 1, TempStr.Length - (Strings.InStr(TempStr, Conversions.ToString((char)34)) + 1));

				if (STable[value1] != null)
				{
					MessageBox.Show("Duplicate value: S" + value1.ToString() + ".", "Duplicate value", MessageBoxButtons.OK, MessageBoxIcon.Error);
					inAiFile.Close();
					inImpFile.Close();
					outAiFile.Close();
					return;
				}

				if (STable.Length < value1)
				{
					MessageBox.Show("Very big index for array. Contact with tool owner for increase array support", "Array full", MessageBoxButtons.OK, MessageBoxIcon.Error);
					inAiFile.Close();
					inImpFile.Close();
					outAiFile.Close();
					return;
				}

				STable[value1] = value2;
			}

			// MessageBox.Show("Loading complete. Working...")

			while (inAiFile.EndOfStream != true)
			{
				TempStr = inAiFile.ReadLine();
				if (!string.IsNullOrEmpty(TempStr))
				{
					if ((Strings.Mid(TempStr, 1, 1) ?? "") == "S" & Strings.InStr(TempStr, ".") != 0)
					{
						value1 = Conversions.ToInteger(Strings.Mid(TempStr, 2, Strings.InStr(TempStr, ".") - 2));
						if (value1 <= STable.Length)
						{
							if (STable[value1] == null)
							{
							}
							else
								// value2 = Mid(TempStr, InStr(TempStr, Chr(34)) + 1, TempStr.Length - (InStr(TempStr, Chr(34)) + 1))
								TempStr = "S" + value1.ToString() + "." + Conversions.ToString((char)9) + Conversions.ToString((char)34) + STable[value1] + Conversions.ToString((char)34);
						}
					}
				}
				outAiFile.WriteLine(TempStr);
			}

			MessageBox.Show("Export complete. Target file is ai_fixed.obj", "Complete.", MessageBoxButtons.OK, MessageBoxIcon.Information);

			inAiFile.Close();
			inImpFile.Close();
			outAiFile.Close();
		}

		private void ButtonAbout_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Module for creating file with Sxxx messages from one file to export to another file." + Constants.vbNewLine + "Use for Sxxx message translation", "About module", MessageBoxButtons.OK);
		}
	}
}
