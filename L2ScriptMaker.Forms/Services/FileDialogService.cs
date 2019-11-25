using System;
using System.Windows.Forms;

namespace L2ScriptMaker.Forms.Services
{
	internal class FileDialogService
	{
		public string InitialDirectory { get; set; }
		public string FilePath { get; set; }
		public string Filter { get; set; }

		public FileDialogService()
		{
			// InitialDirectory = Environment.CurrentDirectory;
		}

		public bool OpenFileDialog()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = Filter;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				FilePath = openFileDialog.FileName;
				return true;
			}
			return false;
		}

		public bool SaveFileDialog()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				FilePath = saveFileDialog.FileName;
				return true;
			}
			return false;
		}

		public void ShowMessage(string message)
		{
			MessageBox.Show(message);
		}
	}
}
