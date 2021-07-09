using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using L2ScriptMaker.Core.Logger;
using L2ScriptMaker.Core.WinForms;
using L2ScriptMaker.Forms.Services;
using L2ScriptMaker.Models.Ai;
using L2ScriptMaker.Parsers;
using L2ScriptMaker.Services.Ai;

namespace L2ScriptMaker.Forms.Modules.AI
{
	public partial class AIHandlersChecker : Form
	{
		private readonly Logger _logger;
		private readonly IAiService _aiService;


		public AIHandlersChecker()
		{
			InitializeComponent();

			_logger = new Logger(nameof(AIHandlersChecker));
			_aiService = new AiService();
		}

		private void btnCheckLines_Click(object sender, EventArgs e)
		{
			FileDialogService fileDialogService = new FileDialogService
			{
				InitialDirectory = Environment.CurrentDirectory,
				Filter = "Lineage II server AI script|" + AiContants.AiFileName + "|All files (*.*)|*.*"
			};
			if (!fileDialogService.OpenFileDialog()) return;

			string aiFile = fileDialogService.FilePath;
			progressBar1.Value = 0;
			IProgress<int> progress = new Progress<int>(a => { progressBar1.Value = a; });

			btnCheckLines.Enabled = false;
			btnCheckVars.Enabled = false;
			btnQuit.Enabled = false;

			Task.Run(() =>
			{
				_logger.Write(LogLevel.Information, new string[]
				{
					"Handler lines checking started", "Input: " + aiFile
				});

				CheckLinesAsync(aiFile, progress);
			}).ContinueWith(task =>
			{
				this.Invoker(() =>
				{
					btnCheckLines.Enabled = true;
					btnCheckVars.Enabled = true;
					btnQuit.Enabled = true;

					progressBar1.Value = 0;
				});

				_logger.Write(LogLevel.Information, "Handler lines checking started completed");
				MessageBox.Show("Success", "Complete");
			});
		}

		private void CheckLinesAsync(string aiFile, IProgress<int> progress)
		{
			_aiService.With(progress);
			foreach (AiClass aiClass in _aiService.GetClassess(aiFile))
			{
				foreach (AiHandler handler in aiClass.Handlers)
				{
					if (handler.Lines != handler.Code.Count)
					{
						_logger.Write(LogLevel.Warning, new string[]
						{
							"Class [" + aiClass.Name + "]; Handler [" + (handler.HasName ? handler.Name : "-") +
							$"]({handler.Type})",
							$"Expected {handler.Lines} but has {handler.Code.Count}"
						});
					}
				}
			}

			_aiService.Unbind();
		}

		private void btnCheckVars_Click(object sender, EventArgs e)
		{
			FileDialogService fileDialogService = new FileDialogService
			{
				InitialDirectory = Environment.CurrentDirectory,
				Filter = "Lineage II server AI script|" + AiContants.AiFileName + "|All files (*.*)|*.*"
			};
			if (!fileDialogService.OpenFileDialog()) return;

			string aiFile = fileDialogService.FilePath;

			progressBar1.Value = 0;
			IProgress<int> progress = new Progress<int>(a => { progressBar1.Value = a; });

			btnCheckLines.Enabled = false;
			btnCheckVars.Enabled = false;
			btnQuit.Enabled = false;

			Task.Run(() =>
			{
				_logger.Write(LogLevel.Information, new string[]
				{
					"Handler variables checking started", "Input: " + aiFile
				});

				CheckVarsAsync(aiFile, progress);
			}).ContinueWith(task =>
			{
				this.Invoker(() =>
				{
					btnCheckLines.Enabled = true;
					btnCheckVars.Enabled = true;
					btnQuit.Enabled = true;

					progressBar1.Value = 0;
				});

				_logger.Write(LogLevel.Information, "Handler variables checking started completed");
				MessageBox.Show("Success", "Complete");
			});
		}

		private void CheckVarsAsync(string aiFile, IProgress<int> progress)
		{
			_aiService.With(progress);

			bool checkNoUse = chkNoUseLog.Checked;

			foreach (AiClass aiClass in _aiService.GetClassess(aiFile))
			{
				foreach (AiHandler handler in aiClass.Handlers)
				{
					string[] varsList = handler.Variables
						.Select(a => a.Trim('"'))
						.ToArray();

					string[] pushEventsList = handler.Code
						.Select(AiParserUtils.ParseHandlerCode)
						.Where(a => !a.IsNothing)
						.Select(a => a.GetValue())
						.Where(codeLine => !codeLine.IsEmpty && codeLine.Values[0] == "push_event" && codeLine.HasComment)
						.Select(a => a.Comment)
						.Where(a => !String.IsNullOrWhiteSpace(a) && a != "gg").Distinct().ToArray();

					foreach (string varName in varsList)
					{
						if (checkNoUse && pushEventsList.Contains(varName) == false && !varName.StartsWith("_"))
						{
							_logger.Write(LogLevel.Information, new string[]
							{
								"Class [" + aiClass.Name + "]; Handler [" + (handler.HasName ? handler.Name : "-") + $"]({handler.Type})",
								$"Variable [{varName}] is never used"
							});
						}
					}

					foreach (string pushEvent in pushEventsList)
					{
						if (varsList.Contains(pushEvent) == false)
						{
							_logger.Write(LogLevel.Warning, new string[]
							{
								"Class [" + aiClass.Name + "]; Handler [" + (handler.HasName ? handler.Name : "-") +
								$"]({handler.Type})",
								$"PushEvent [{pushEvent}] is not defined into handler variables"
							});
						}
					}
				}
			}

			_aiService.Unbind();
		}

		private void btnQuit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}