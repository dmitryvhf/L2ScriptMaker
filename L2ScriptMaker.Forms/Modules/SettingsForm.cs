using L2ScriptMaker.Forms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using L2ScriptMaker.Core;

namespace L2ScriptMaker.Forms.Modules
{
	public partial class SettingsForm : Form
	{
		GlobalSettings _settings;

		public SettingsForm()
		{
			InitializeComponent();

			this.Load += SettingsForm_Load;
		}

		private void SettingsForm_Load(object sender, EventArgs e)
		{
			_settings = SettingsUtils.Settings;
			
			txbWorkFolder.DataBindings.Add("Text", _settings, nameof(_settings.WorkFolder), false, DataSourceUpdateMode.OnPropertyChanged);
		}

		private void txbWorkFolder_DoubleClick(object sender, EventArgs e)
		{
			string initText = txbWorkFolder.Text;
			if (!String.IsNullOrWhiteSpace(initText))
			{
				folderBrowserDialog.SelectedPath = initText;
			}
			if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;

			txbWorkFolder.Text = folderBrowserDialog.SelectedPath;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			SettingsUtils.Save();

			this.Dispose();
		}
	}
}
