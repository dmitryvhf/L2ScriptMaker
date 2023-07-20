using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using L2ScriptMaker.Core.Logger;
using L2ScriptMaker.Core.WinForms;
using L2ScriptMaker.Forms.Services;
using L2ScriptMaker.Services.Manual;
using L2ScriptMaker.Services.Skill;

namespace L2ScriptMaker.Forms.Modules.Skills
{
	public partial class SkillPch2MakerForm : Form
	{
		private readonly FileDialogService _fileDialogService;

		private ISkillPchService _skillPchService;
		private readonly ILogger _logger;
		// private readonly ISkillCacheService _skillCacheService;

		private readonly SkillPchOptions _options;

		public SkillPch2MakerForm()
		{
			InitializeComponent();

			_options = new SkillPchOptions();

			_logger = new Logger("SkillPch2Maker");

			_fileDialogService = new FileDialogService();
			// _skillPchService = new SkillPchService(_options);
			// _skillCacheService = new SkillCacheService();
		}

		private void SkillPch2Maker_Load(object sender, EventArgs e)
		{
			// Select ManualPch File
			string manualPchFile = ManualPchContants.ManualPchFileName;
			if (File.Exists(manualPchFile) == false)
			{
				_fileDialogService.Filter = "Lineage II ManualPch config|" + manualPchFile + "|All files (*.*)|*.*";
				if (!_fileDialogService.OpenFileDialog()) return;

				manualPchFile = _fileDialogService.FilePath;
			}

			_options.ManualPchFile = manualPchFile;
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			_fileDialogService.InitialDirectory = Environment.CurrentDirectory;
			_fileDialogService.Filter = "Lineage II SkillData config|" + SkillContants.SkillDataFileName +
										"|All files (*.*)|*.*";
			if (!_fileDialogService.OpenFileDialog()) return;

			string skillDataFile = _fileDialogService.FileName;
			string skillDataDir = _fileDialogService.FileDirectory;

			if (File.Exists(skillDataDir + "\\" + SkillContants.SkillPchFileName))
			{
				if (MessageBox.Show($"File {SkillContants.SkillPchFileName} exist. Overwrite?",
						"Overwrite?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
					return;
			}

			_skillPchService = new SkillPchService(_options);

			//_options.IsChaoticThronesCronicles = CheckBoxKamaelIDStandart.Checked;
			//_options.UseNamesAsIs = CheckBoxAsIs.Checked;
			//_options.SetUnknown = IgnoreCustomAbnormalsCheckBox.Checked;
			//_options.ManualPchAttributes = AbnormalListTextBox.Lines;

			IProgress<int> progress = new Progress<int>(a => { ProgressBar.Value = a; });
			StartButton.Enabled = false;
			SkillCacheScriptButton.Enabled = false;

			Task.Run(() =>
				{
					_logger.Write(LogLevel.Information, new string[]
					{
						"SkillPch generation started", "Output: " + SkillContants.SkillPchFileName
					});

					_skillPchService.With(progress);
					return _skillPchService.Generate(skillDataDir, skillDataFile);
				})
				.ContinueWith(task =>
				{
					this.Invoker(() =>
					{
						StartButton.Enabled = true;
						SkillCacheScriptButton.Enabled = true;
						ProgressBar.Value = 0;
					});


					if (task.IsFaulted)
					{
						_logger.Write(LogLevel.Error, "Crash with unhandled exception.");
						_logger.Write(LogLevel.Error, task.Exception);

						MessageBox.Show("Crash with unhandled exception.", "Crash");
					}
					else if (task.Result.HasErrors)
					{
						_logger.Write(LogLevel.Error, "Complete finished with errors.");
						_logger.Write(LogLevel.Error, task.Result.Errors.ToArray());

						MessageBox.Show("Complete finished with errors.\n" + String.Join(";", task.Result.Errors),
							"Failed completition");
					}
					else
					{
						_logger.Write(LogLevel.Information, "SkillPch generation completed");

						MessageBox.Show("Success.", "Success completition");
					}
				});
		}

		private void SkillCacheScript_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}


//private void SkillCacheScript_Click(object sender, EventArgs e)
//{
//	OpenFileDialog.FileName = "";
//	OpenFileDialog.Filter = "Lineage II config (skilldata.txt)|skilldata.txt|All files (*.*)|*.*";
//	if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
//		return;

//	System.IO.StreamReader inEFile;
//	try
//	{
//		inEFile = new System.IO.StreamReader(System.IO.Path.GetDirectoryName(OpenFileDialog.FileName) + @"\skillname-e.txt", System.Text.Encoding.Default, true, 1);
//	}
//	catch (Exception ex)
//	{
//		MessageBox.Show("You must have skillname-e in work folder for generation itemcache file. Put and try again.");
//		return;
//	}

//	// Initialization
//	ProgressBar.Value = 0;
//	var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);
//	System.IO.Stream oAiFile = new System.IO.FileStream(System.IO.Path.GetDirectoryName(OpenFileDialog.FileName) + @"\gmskilldata.txt", System.IO.FileMode.Create, System.IO.FileAccess.Write);
//	var outAiData = new System.IO.StreamWriter(oAiFile, System.Text.Encoding.Unicode, 1);

//	string ReadStr;
//	string[] ReadSplitStr;

//	ProgressBar.Value = 0;
//	ProgressBar.Maximum = Conversions.ToInteger(inEFile.BaseStream.Length);
//	// SkillId, SkillLevel
//	// 0 - name, 1 - desc
//	var SkillDB = new string[55001, 701, 2];
//	int SkillDBMarker1 = 0;
//	int SkillDBMarker2 = 0;


//	while (inEFile.EndOfStream != true)
//	{
//		ReadStr = inEFile.ReadLine().Replace(" = ", "=");

//		if (ReadStr != null)
//		{
//			if ((Strings.Mid(ReadStr, 1, 2) ?? "") != "//")
//			{
//				ReadSplitStr = ReadStr.Split((char)9);
//				SkillDBMarker1 = Conversions.ToInteger(ReadSplitStr[1].Replace("id=", ""));
//				SkillDBMarker2 = Conversions.ToInteger(ReadSplitStr[2].Replace("level=", ""));
//				if (SkillDBMarker1 > 55000)
//				{
//					MessageBox.Show("Skill ID must be less then 55000. Custom skills not supported. Last skill_id:" + SkillDBMarker1.ToString() + " skill_level: " + SkillDBMarker2.ToString(), "SkillID above them 30000", MessageBoxButtons.OK, MessageBoxIcon.Error);
//					ProgressBar.Value = 0;
//					inFile.Close();
//					outAiData.Close();
//					return;
//				}

//				// 4	1	[Dash]	[Temporary burst of speed. Effect 1.]	0	A2
//				SkillDB[SkillDBMarker1, SkillDBMarker2, 0] = ReadSplitStr[3].Replace("name=", "");
//				SkillDB[SkillDBMarker1, SkillDBMarker2, 1] = ReadSplitStr[4].Replace("description=", "");
//			}
//		}
//		ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position * 100 / (double)inFile.BaseStream.Length);
//	}

//	int SkillId;
//	int SkillLevel;
//	string SkillName;
//	string SkillDesc;
//	short SkillMagic;
//	string SkillOp;

//	ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
//	ProgressBar.Value = 0;
//	while (inFile.BaseStream.Position != inFile.BaseStream.Length)
//	{
//		ReadStr = Strings.Replace(inFile.ReadLine(), Conversions.ToString((char)9), Conversions.ToString((char)32));
//		// tabs and spaces correction
//		while (Strings.InStr(ReadStr, "  ") != 0)
//			ReadStr = Strings.Replace(ReadStr, "  ", Conversions.ToString((char)32));
//		// ReadStr = Replace(inFile.ReadLine, Chr(32), Chr(9))
//		// 21      3       [s_poison_recovery3]    []      1       A1

//		if (!string.IsNullOrEmpty(ReadStr))
//		{
//			if (ReadStr.StartsWith("//") == false)
//			{
//				if (Strings.InStr(ReadStr, "/*") != 0)
//					// Commentarie exist
//					// Dim commentarie As String = Mid(ReadStr, InStr(ReadStr, "/*"), InStr(ReadStr, "*/") - InStr(ReadStr, "/*") + 2)
//					ReadStr = ReadStr.Replace(Strings.Mid(ReadStr, Strings.InStr(ReadStr, "/*"), Strings.InStr(ReadStr, "*/") - Strings.InStr(ReadStr, "/*") + 2), "");
//				ReadStr = Strings.Replace(ReadStr, " = ", "=");

//				ReadSplitStr = ReadStr.Split((char)32);

//				SkillId = Conversions.ToInteger(Libraries.GetNeedParamFromStr(ReadStr, "skill_id"));
//				SkillLevel = Conversions.ToInteger(Libraries.GetNeedParamFromStr(ReadStr, "level"));
//				SkillName = Libraries.GetNeedParamFromStr(ReadStr, "skill_name");
//				SkillDesc = "[no description]";
//				if (!string.IsNullOrEmpty(Libraries.GetNeedParamFromStr(ReadStr, "is_magic")))
//					SkillMagic = Conversions.ToShort(Libraries.GetNeedParamFromStr(ReadStr, "is_magic"));
//				else
//					SkillMagic = Conversions.ToShort(0);
//				SkillOp = Libraries.GetNeedParamFromStr(ReadStr, "operate_type");

//				if (SkillId <= 55000)
//				{
//					if (!string.IsNullOrEmpty(SkillDB[SkillId, SkillLevel, 0]))
//						SkillName = SkillDB[SkillId, SkillLevel, 0];
//					if (!string.IsNullOrEmpty(SkillDB[SkillId, SkillLevel, 1]))
//						SkillDesc = SkillDB[SkillId, SkillLevel, 1];
//				}
//				else if (IgnoreCustomSkillBox.Checked == true)
//				{
//					SkillName = "[L2ScriptMaker: Customs skills not supported]";
//					SkillDesc = "[L2ScriptMaker: Customs skills not supported]";
//				}
//				else
//				{
//					MessageBox.Show("Skill ID must be less then 55000. Custom skills not supported. Last skill_id:" + SkillId.ToString() + " skill_level: " + SkillLevel.ToString(), "SkillID above them 30000", MessageBoxButtons.OK, MessageBoxIcon.Error);
//					ProgressBar.Value = 0;
//					inFile.Close();
//					outAiData.Close();
//					return;
//				}

//				// 4	1	[Dash]	[Temporary burst of speed. Effect 1.]	0	A2
//				// 500 symbols fix
//				if (SkillDesc.Length > 255)
//					SkillDesc = SkillDesc.Substring(0, 255) + "]";

//				outAiData.WriteLine(SkillId.ToString() + Conversions.ToString((char)9) + SkillLevel.ToString() + Conversions.ToString((char)9) + SkillName + Conversions.ToString((char)9) + SkillDesc + Conversions.ToString((char)9) + SkillMagic.ToString() + Conversions.ToString((char)9) + SkillOp);
//			}
//		}

//		ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
//	}

//	MessageBox.Show("gmskilldata.txt Complete");
//	ProgressBar.Value = 0;
//	inFile.Close();
//	outAiData.Close();
//}