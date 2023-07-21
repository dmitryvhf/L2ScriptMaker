﻿using L2ScriptMaker.Core.WinForms;
using L2ScriptMaker.Forms.Services;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using L2ScriptMaker.Core.Logger;
using L2ScriptMaker.Services.Scripts.Npc;
using L2ScriptMaker.DomainObjects;
using L2ScriptMaker.DomainObjects.Constants;

namespace L2ScriptMaker.Forms.Modules.Npc
{
	public partial class NpcPchMakerForm : Form
	{
		private readonly INpcPchService _npcPchService;
		private readonly INpcCacheService _npcCacheService;
		private readonly ILogger _logger;

		public NpcPchMakerForm()
		{
			InitializeComponent();

			_npcPchService = new NpcPchService();
			_npcCacheService = new NpcCacheService();

			_logger = new Logger("NpcPchMaker");
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			FileDialogService fileDialogService = new FileDialogService
			{
				InitialDirectory = Environment.CurrentDirectory,
				Filter = "Lineage II NpcData config|" + NpcConstants.NpcDataFileName + "|All files (*.*)|*.*"
			};
			if (!fileDialogService.OpenFileDialog()) return;

			string npcDataFile = fileDialogService.FileName;
			string npcDataDir = fileDialogService.FileDirectory;

			if (File.Exists(npcDataDir + "\\" + NpcConstants.NpcPchFileName))
			{
				if (MessageBox.Show($"File {NpcConstants.NpcPchFileName} exist. Overwrite?",
						"Overwrite?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
				{
					return;
				}
			}

			IProgress<int> progress = new Progress<int>(a => { ProgressBar.Value = a; });
			StartButton.Enabled = false;

			Task.Run(() =>
			{
				_logger.Write(LogLevel.Information, new string[]
				{
					"NpcPch generation started", "Output: " + NpcConstants.NpcPchFileName
				});

				_npcPchService.With(progress);
				_npcPchService.Generate(npcDataDir, npcDataFile);
			}).ContinueWith(task =>
			{
				this.Invoker(() =>
				{
					StartButton.Enabled = true;
					ProgressBar.Value = 0;
				});

				_logger.Write(LogLevel.Information, "NpcPch generation completed");
				MessageBox.Show("Success.", "Complete");
			});
		}

		private void NpcCacheScript_Click(object sender, EventArgs e)
		{
			FileDialogService fileDialogService = new FileDialogService
			{
				InitialDirectory = Environment.CurrentDirectory,
				Filter = "Lineage II NpcData config|npcdata.txt|All files (*.*)|*.*"
			};
			if (!fileDialogService.OpenFileDialog()) return;

			string npcCacheFile = fileDialogService.FileName;
			string npcDataDir = fileDialogService.FileDirectory;

			if (File.Exists(npcDataDir + "\\" + NpcConstants.NpcCacheFileName))
			{
				if (MessageBox.Show($"File {NpcConstants.NpcCacheFileName} exist. Overwrite?",
						"Overwrite?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
				{
					return;
				}
			}

			IProgress<int> progress = new Progress<int>(a => { ProgressBar.Value = a; });
			NpcCacheScript.Enabled = false;

			_logger.Write(LogLevel.Information, new string[]
			{
				"NpcCache generation started", "Output: " + NpcConstants.NpcCacheFileName
			});

			Task.Run(() =>
			{
				_npcCacheService.With(progress);
				_npcCacheService.Generate(npcDataDir, npcCacheFile);
			}).ContinueWith(task =>
			{
				this.Invoker(() =>
				{
					NpcCacheScript.Enabled = true;
					ProgressBar.Value = 0;
				});

				_logger.Write(LogLevel.Information, "NpcCache generation completed");
				MessageBox.Show("Success.", "Complete");
			});
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
