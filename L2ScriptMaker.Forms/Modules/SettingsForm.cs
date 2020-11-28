using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using L2ScriptMaker.Core;

namespace L2ScriptMaker.Forms.Modules
{
	public partial class SettingsForm : Form
	{
		private readonly Dictionary<string, bool> _controlErrors = new Dictionary<string, bool>();

		public SettingsForm()
		{
			InitializeComponent();

			this.Load += SettingsForm_Load;
			this.Closing += OnClosing;
			this.Closed += OnClosed;

			lblWorkFolder.Focus();
		}

		#region Private methods. Initialization
		private void SettingsForm_Load(object sender, EventArgs e)
		{
			InitEvents();
			InitBindings();
		}

		private void InitBindings()
		{
			GlobalSettings settings = SettingsUtils.Settings;

			txbWorkFolder.DataBindings.Add("Text", settings, nameof(settings.WorkFolder), false, DataSourceUpdateMode.OnValidation);
			txbLogsFolder.DataBindings.Add("Text", settings, nameof(settings.LogsFolder), false, DataSourceUpdateMode.OnValidation);
		}

		private void InitEvents()
		{
			btnClose.Click += btnClose_Click;

			txbWorkFolder.DoubleClick += txbBoxFolder_DoubleClick;
			txbWorkFolder.TextChanged += txbBoxFolder_TextChanged;

			txbLogsFolder.DoubleClick += txbBoxFolder_DoubleClick;
			txbLogsFolder.TextChanged += txbBoxFolder_TextChanged;
		}
		#endregion

		#region Private methods. Element events
		private void txbBoxFolder_TextChanged(object sender, EventArgs e)
		{
			TextBox textBoxElement = (TextBox)sender;
			string elemName = textBoxElement.Name;

			if (!ValidateSelectedPath(textBoxElement.Text, out string newPath))
			{
				textBoxElement.BackColor = Color.OrangeRed;
				textBoxElement.ForeColor = Color.White;
				_controlErrors[elemName] = true;
			}
			else
			{
				if (_controlErrors[elemName])
				{
					textBoxElement.ResetBackColor();
					textBoxElement.ResetForeColor();
					_controlErrors[elemName] = false;
				}
				textBoxElement.Text = newPath;
			}
		}

		private void txbBoxFolder_DoubleClick(object sender, EventArgs e)
		{
			TextBox textBoxElement = (TextBox)sender;

			string initText = textBoxElement.Text;
			if (!String.IsNullOrWhiteSpace(initText))
			{
				folderBrowserDialog.SelectedPath = initText;
			}
			
			if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;

			textBoxElement.Text = folderBrowserDialog.SelectedPath;
		}
		#endregion

		#region Private methods
		private bool ValidateSelectedPath(string newPath, out string path)
		{
			path = newPath;
			if (!ckbValidFixPath.Checked)
			{
				return true;
			}

			if (String.IsNullOrWhiteSpace(newPath))
			{
				return true;
			}

			if (!Directory.Exists(newPath))
			{
				return false;
			}

			return true;
		}

		private void OnClosing(object sender, CancelEventArgs e)
		{
			if (_controlErrors.ContainsValue(true))
			{
				DialogResult result = MessageBox.Show("Found setting errors. Yes - Save&close, No - exit w/o saving settings, Cancel - continue setuping", "Settings error", MessageBoxButtons.YesNoCancel);
				switch (result)
				{
					case DialogResult.Cancel:
						e.Cancel = true;
						return;
					case DialogResult.No:
						return;
				}
			}
			SettingsUtils.Save();
		}

		private void OnClosed(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion
	}
}
