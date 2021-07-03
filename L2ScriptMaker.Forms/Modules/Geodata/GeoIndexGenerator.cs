using System;
using System.Linq;
using System.Windows.Forms;
using L2ScriptMaker.Core.Settings;

namespace L2ScriptMaker.Forms.Modules.Geodata
{
	public partial class GeoIndexGenerator : Form
	{
		public GeoIndexGenerator()
		{
			InitializeComponent();
		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog
			{
				SelectedPath = SettingsUtils.Settings.WorkFolder,
				Description = "Select folder with geodata *.dat files"
			};
			if (folderDialog.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}

			string selectedPath = folderDialog.SelectedPath;
			string[] geoFiles = System.IO.Directory.GetFiles(selectedPath, "*.dat")
				.Select(System.IO.Path.GetFileName)
				.ToArray();
			if (geoFiles.Length < 1)
			{
				MessageBox.Show("No Geofiles into this folder. Select correct folder", "No geodata", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (System.IO.File.Exists(selectedPath + @"\geo_index.txt"))
			{
				if (MessageBox.Show("File geo_index.txt already exists. Replace?", "File already exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
				{
					return;
				}
			}

			System.IO.StreamWriter outGeoFile = new System.IO.StreamWriter(selectedPath + @"\geo_index.txt", false, System.Text.Encoding.ASCII, 1);
			outGeoFile.WriteLine(geoFiles.Length);
			foreach (string geoname in geoFiles)
			{
				outGeoFile.WriteLine(geoname);
			}

			outGeoFile.Close();
			MessageBox.Show("Generation complete.", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnQuit_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
