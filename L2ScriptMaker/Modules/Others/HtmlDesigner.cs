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

namespace L2ScriptMaker.Modules.Others
{
	public partial class HtmlDesigner : Form
	{
		public HtmlDesigner()
		{
			InitializeComponent();
		}

		private void ButtonLoad_Click(object sender, EventArgs e)
		{
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);

			string sTemp;
			sTemp = inFile.ReadToEnd();
			inFile.Close();

			sTemp = sTemp.Replace(Constants.vbNewLine, "");
			sTemp = sTemp.Replace("<br>", Constants.vbNewLine + Constants.vbNewLine);
			sTemp = sTemp.Replace("<html>", "");
			sTemp = sTemp.Replace("</html>", "");
			sTemp = sTemp.Replace("<head>", "");
			sTemp = sTemp.Replace("<body>", "");
			sTemp = sTemp.Replace("</body>", "");

			TextBoxEdit.Text = sTemp;
		}

		private void ButtonResult_Click(object sender, EventArgs e)
		{
			// TextBoxEdit.Text = ""
			if (string.IsNullOrEmpty(TextBoxEdit.Text))
				return;
			string sTemp;
			string sTempHtml;

			sTemp = TextBoxEdit.Text;

			// Preparing. Maybe someone paste ready code to this window
			sTemp = sTemp.Replace("<br>", Constants.vbNewLine + Constants.vbNewLine);
			sTemp = sTemp.Replace("<html>", "");
			sTemp = sTemp.Replace("</html>", "");
			sTemp = sTemp.Replace("<head>", "");
			sTemp = sTemp.Replace("<body>", "");
			sTemp = sTemp.Replace("</body>", "");


			sTemp = sTemp.Replace(Constants.vbNewLine + Constants.vbNewLine, Constants.vbNewLine + Constants.vbNewLine + "<br>");
			sTemp = "<html><head><body>" + Constants.vbNewLine + sTemp + Constants.vbNewLine + "</body></html>";
			TextBoxResult.Text = sTemp;

			sTemp = sTemp.Replace("<body>", "<body text=\"#FFFFFF\" bgcolor=\"#000000\">" + Constants.vbNewLine + "<font face=\"Tahoma, Arial, Verdana, Helvetica, Sans-Serif\" size=\"2\">");
			sTemp = sTemp.Replace("<a action=", "<a href=");
			sTemp = sTemp.Replace("<a href=", "<a target=\"_blank\" href=");
			sTemp = sTemp.Replace(Constants.vbNewLine, "");
			sTemp = sTemp.Replace("<br>", Constants.vbNewLine + Constants.vbNewLine + "<br><br>");
			sTemp = sTemp.Replace("<font color=\"LEVEL\">", "<font color=\"FFFF33\">");
			sTempHtml = sTemp;

			var outTempFile = new System.IO.StreamWriter("~temp.htm", false, System.Text.Encoding.Unicode, 1);
			outTempFile.Write(sTemp);
			outTempFile.Close();

			var sUrl = new Uri(Environment.CurrentDirectory + @"\~temp.htm");
			WebBrowserPreview.Url = sUrl;
			WebBrowserPreview.Show();
		}

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(TextBoxResult.Text))
				return;

			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			var outTempFile = new System.IO.StreamWriter(SaveFileDialog.FileName, false, System.Text.Encoding.Unicode, 1);
			outTempFile.Write(TextBoxResult.Text);
			outTempFile.Close();
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			if (System.IO.File.Exists("~temp.htm") == true)
				System.IO.File.Delete("~temp.htm");
			this.Dispose();
		}

		private void ComboBoxShortCuts_SelectedIndexChanged(object sender, EventArgs e)
		{
			TextBoxEdit.AppendText(Constants.vbNewLine + ComboBoxShortCuts.Text);
		}
	}
}
