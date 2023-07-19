using System;
using System.IO;
using System.Windows.Forms;

namespace L2ScriptMaker.Forms.Services
{
	/// <summary>
	///		Windows Forms service for file selection
	/// </summary>
	internal class FileDialogService
	{
		#region Public properties

		/// <summary>
		///		Default directory for file selection
		/// </summary>
		public string InitialDirectory { get; set; }

		/// <summary>
		///		Filter for file selection
		/// </summary>
		/// <remarks>Default is *.*</remarks>
		public string Filter { get; set; }

		/// <summary>
		///		Full path to selected file
		/// </summary>
		public string FilePath { get; set; }

		/// <summary>
		///		Selected file name
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		///		Path to selected file
		/// </summary>
		public string FileDirectory { get; set; }

		#endregion

		#region Constructor

		public FileDialogService()
		{
			// InitialDirectory = Environment.CurrentDirectory;
		}

		#endregion

		#region Public methods

		/// <summary>
		///		Dialog for file selection
		/// </summary>
		/// <remarks>Selected file information saved to service properties</remarks>
		/// <returns>True - file is selected; False - dialog canceled</returns>
		public bool OpenFileDialog()
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = Filter;
				openFileDialog.InitialDirectory = InitialDirectory;

				if (openFileDialog.ShowDialog() != DialogResult.OK)
				{
					return false;
				}

				FilePath = openFileDialog.FileName;
				FileName = openFileDialog.SafeFileName;
				FileDirectory = Path.GetDirectoryName(FilePath);
				return true;
			}
		}

		public void ShowMessage(string message)
		{
			MessageBox.Show(message);
		}

		#endregion
	}
}
