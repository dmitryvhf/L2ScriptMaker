using System;
using System.IO;
using System.Windows.Forms;

namespace L2ScriptMaker.Forms.Services
{
	internal class FileDialogService
	{
		public string InitialDirectory { get; set; }
		public string Filter { get; set; }

		public string FilePath { get; set; }
		public string FileName { get; set; }
		public string FileDirectory { get; set; }

		public FileDialogService()
		{
			// InitialDirectory = Environment.CurrentDirectory;
		}

		public bool OpenFileDialog()
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = Filter;
				openFileDialog.InitialDirectory = InitialDirectory;

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					FilePath = openFileDialog.FileName;
					FileName = openFileDialog.SafeFileName;
					FileDirectory = Path.GetDirectoryName(FilePath);
					return true;
				}
				return false;
			}
		}

		public bool SaveFileDialog()
		{
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					FilePath = saveFileDialog.FileName;
					FileName = Path.GetFileName(FilePath);
					FileDirectory = Path.GetDirectoryName(FilePath);
					return true;
				}
				return false;
			}
		}

		public void ShowMessage(string message)
		{
			MessageBox.Show(message);
		}
	}
}
