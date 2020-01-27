using L2ScriptMaker.Extensions;
using L2ScriptMaker.Extensions.VbCompatibleHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2ScriptMaker.Modules.Scripts
{
	public partial class ScriptParamSearcher : Form
	{
		public ScriptParamSearcher()
		{
			InitializeComponent();
		}

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			string sTemp;
			string sTemp2;
			string sParamName;
			var aParamList = new string[1];
			// Dim iTemp As Integer

			if (string.IsNullOrEmpty(SearchParamTextBox.Text))
			{
				MessageBox.Show("Required define param name for searching", "Required param name", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			sParamName = SearchParamTextBox.Text;

			OpenFileDialog.InitialDirectory = Environment.CurrentDirectory;
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);
			ProgressBar.Value = 0;
			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			SummaryTextBox.Text = "";

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				sTemp2 = Libraries.GetNeedParamFromStr(sTemp, sParamName);
				if (Array.IndexOf(aParamList, sTemp2) == -1 & !string.IsNullOrEmpty(sTemp2))
				{
					Array.Resize(ref aParamList, aParamList.Length + 1);
					aParamList[aParamList.Length - 1] = sTemp2;
					SummaryTextBox.AppendText(sTemp2 + Constants.vbNewLine);
				}
				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
			}
			inFile.Close();
			ProgressBar.Value = 0;

			MessageBox.Show("Searching complete." + Constants.vbNewLine + "Found " + Conversions.ToString(SummaryTextBox.Lines.Length - 1) + " definitions.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
