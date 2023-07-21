using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using L2ScriptMaker.DomainObjects.Constants;
using L2ScriptMaker.Forms.Services;

namespace L2ScriptMaker.Forms.Modules.AI
{
	public partial class AIMessages : Form
	{
		private readonly Regex _aiMessageRegex = new Regex("^(S\\d{1,6})\\.\\s(\".*\")$");

		public AIMessages()
		{
			InitializeComponent();
		}

		private void ButtonAbout_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Module for creating file with Sxxx messages from one file to export to another file.\nUse for Sxxx message translation",
				"About module", MessageBoxButtons.OK);
		}

		private void ButtonExport_Click(object sender, EventArgs e)
		{
			FileDialogService fileDialogService = new FileDialogService
			{
				InitialDirectory = Environment.CurrentDirectory,
				Filter = "Lineage II server AI script|" + AiConstants.AiFileName + "|All files (*.*)|*.*"
			};
			if (!fileDialogService.OpenFileDialog()) return;

			string aiFile = fileDialogService.FileName;
			string aiExportFile = Path.Combine(Path.GetDirectoryName(aiFile), AiConstants.AiExport);
			if (File.Exists(aiExportFile))
			{
				MessageBox.Show($"Export file '{AiConstants.AiExport}' exist. Delete and try again", "File exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var inAiFile = new StreamReader(aiFile, Encoding.Default, true, 1);
			var inExpFile = new StreamWriter(aiExportFile, false, Encoding.Unicode, 1);

			while (inAiFile.EndOfStream != true)
			{
				var tempStr = inAiFile.ReadLine();

				if (!string.IsNullOrEmpty(tempStr) && _aiMessageRegex.IsMatch(tempStr))
				{
					inExpFile.WriteLine(tempStr);
				}
			}

			MessageBox.Show($"Export complete. Target file is '{aiExportFile}'", "Complete.", MessageBoxButtons.OK, MessageBoxIcon.Information);

			inAiFile.Close();
			inExpFile.Close();

		}

		private void ButtonImport_Click(object sender, EventArgs e)
		{
			FileDialogService fileDialogService = new FileDialogService
			{
				InitialDirectory = Environment.CurrentDirectory,
				Filter = "Lineage II server AI script|" + AiConstants.AiFileName + "|All files (*.*)|*.*"
			};
			if (!fileDialogService.OpenFileDialog()) return;
			string aiFile = fileDialogService.FileName;

			fileDialogService = new FileDialogService
			{
				InitialDirectory = Environment.CurrentDirectory,
				Filter = "Lineage II Sxxx import file|" + AiConstants.AiExport + "|All files (*.*)|*.*"
			};
			if (!fileDialogService.OpenFileDialog()) return;

			string aiImportFile = fileDialogService.FileName;
			StreamReader inImpFile = new StreamReader(aiImportFile, Encoding.Default, true, 1);

			Dictionary<string, string> messages = new Dictionary<string, string>();
			long index = 0;
			while (inImpFile.EndOfStream != true)
			{
				string tempStr = inImpFile.ReadLine();
				index++;

				if (string.IsNullOrEmpty(tempStr) || !_aiMessageRegex.IsMatch(tempStr))
				{
					MessageBox.Show($"Wrong record into {index} line.\n{tempStr}", "Wrong data", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
				}

				Match matches = _aiMessageRegex.Match(tempStr);
				string key = matches.Groups[1].Value;

				if (messages.ContainsKey(key))
				{
					MessageBox.Show($"Duplicate record into {index} line.\n{tempStr}", "Duplicate data", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
				}

				messages.Add(key, tempStr);
			}
			inImpFile.Close();

			File.Copy(aiFile, Path.GetFileNameWithoutExtension(aiFile) + ".bak", true);

			StreamReader inAiFile = new StreamReader(Path.GetFileNameWithoutExtension(aiFile) + ".bak", Encoding.Default, true, 1);
			StreamWriter outAiFile = new StreamWriter(aiFile, false, Encoding.Unicode, 1);

			while (inAiFile.EndOfStream != true)
			{
				string readLine = inAiFile.ReadLine();
				string writeLine = readLine;

				if (!string.IsNullOrEmpty(readLine) && _aiMessageRegex.IsMatch(readLine))
				{
					Match matches = _aiMessageRegex.Match(readLine);
					string key = matches.Groups[1].Value;

					if (messages.ContainsKey(key))
					{
						writeLine = messages[key];
					}
					// todo ai file is not consistant with ai_export
				}

				outAiFile.WriteLine(writeLine);
			}

			MessageBox.Show($"Export complete. Target file is {aiFile}. Backup created.", "Complete.", MessageBoxButtons.OK, MessageBoxIcon.Information);

			inAiFile.Close();
			outAiFile.Close();
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
