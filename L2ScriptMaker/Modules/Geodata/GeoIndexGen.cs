using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2ScriptMaker.Modules.Geodata
{
	public partial class GeoIndexGen : Form
	{
		public GeoIndexGen()
		{
			InitializeComponent();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			string[] GeoFiles = new string[] { };
			string[] GeoFilesControl = new string[] { };
			int iTemp;

			FolderBrowserDialog.SelectedPath = Environment.CurrentDirectory;
			FolderBrowserDialog.Description = "Select folder with geodata *.dat files";
			if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
				return;
			else
			{
			}

			GeoFiles = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath, "*.dat", System.IO.SearchOption.AllDirectories);
			if (GeoFiles.Length < 1)
			{
				MessageBox.Show("No Geofiles into this folder. Select correct folder", "No geodata", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var outGeoFile = new System.IO.StreamWriter(FolderBrowserDialog.SelectedPath + @"\geo_index.txt", false, System.Text.Encoding.ASCII, 1);
			int GeoId;
			outGeoFile.WriteLine(GeoFiles.Length);
			Array.Resize(ref GeoFilesControl, GeoFiles.Length);
			var loopTo = GeoFiles.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				GeoId = Array.IndexOf(GeoFilesControl, System.IO.Path.GetFileName(GeoFiles[iTemp]));
				GeoFilesControl[iTemp] = System.IO.Path.GetFileName(GeoFiles[iTemp]);
				if (GeoId != -1 & GeoId != iTemp)
				{
					outGeoFile.Close();
					MessageBox.Show("Geodata " + GeoFilesControl[iTemp] + " already exist in geo_index. Remove duplicate geo and try again", "Duplicate geodata", MessageBoxButtons.OK, MessageBoxIcon.Error);
					System.IO.File.Delete(FolderBrowserDialog.SelectedPath + @"\geo_index.txt");
					return;
				}
				outGeoFile.WriteLine(GeoFiles[iTemp].Replace(FolderBrowserDialog.SelectedPath + @"\", ""));
			}

			outGeoFile.Close();
			MessageBox.Show("Generation complete.", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
