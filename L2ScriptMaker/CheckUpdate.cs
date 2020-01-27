using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using L2ScriptMaker.Extensions.VbCompatibleHelper;

namespace L2ScriptMaker
{
	public partial class CheckUpdate : Form
	{
		public CheckUpdate()
		{
			InitializeComponent();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			string sUrlBase = "http://dragon.ur.ru/l2sm/";
			// Dim sUrlBase As String = "http://server/l2sm/"
			string l2tempver = System.IO.Path.GetTempFileName();
			string sVersion;
			string sUrlFile;

			if (GetFileFromHttp(sUrlBase + "l2scriptmaker.txt", l2tempver) == false)
			{
				MessageBox.Show("Can't download version file from site.", "Can't read version", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}


			var VerRead = new System.IO.StreamReader(l2tempver, System.Text.Encoding.Default, true, 1);
			sVersion = VerRead.ReadLine();
			sUrlFile = VerRead.ReadLine();
			CheckStatLabel.Text = "Version detected: " + sVersion;
			CheckStatLinkLabel.Text = VerRead.ReadLine();

			VerRead.Close();
			System.IO.File.Delete(l2tempver);

			if ((Application.ProductVersion ?? "") == (sVersion ?? ""))
			{
				if ((int)MessageBox.Show("You have lastest release" + Constants.vbNewLine + "Want to download again?", "No new", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == (int)DialogResult.No)
					return;
			}
			else if ((int)MessageBox.Show("Found new build! " + sVersion + Constants.vbNewLine + "Want to download new?", "Found update", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == (int)DialogResult.No)
				return;

			if (GetFileFromHttp(sUrlBase + sUrlFile, sUrlFile) == false)
			{
				MessageBox.Show("Can't download file from site.", "Can't download", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			MessageBox.Show("Download new update success. Last build is " + sVersion + Constants.vbNewLine + "Note: close tool, extract new build from file " + sUrlFile + " in your tool folder", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private bool GetFileFromHttp(string FileUrl, string FileDisk)
		{
			var fs = new System.Net.WebClient();

			fs.Encoding = System.Text.Encoding.GetEncoding(1250);

			var CachePol = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
			fs.CachePolicy = CachePol;

			try
			{
				fs.DownloadFile(FileUrl, FileDisk);
			}
			catch (Exception ex)
			{
				if ((ex.Message ?? "") == "The remote server returned an error: (404) Not Found.")
					// MessageBox.Show("Error on Lineage II Update system. Report to support.")
					return false;
				// UpdStatus.Text = ex.Message
				MessageBox.Show(ex.Message);
				return false;
			}


			return true;
		}

		private void SendMailButton_Click(object sender, EventArgs e)
		{
			try
			{
				var Feedback = new System.Net.Mail.MailMessage(MailFromTextBox.Text, "hellfire@reborn.ru", SubjectTextBox.Text, TextBox.Text);
				var Mailclient = new System.Net.Mail.SmtpClient(MailSrvTextBox.Text);
				Mailclient.UseDefaultCredentials = true;
				Mailclient.Send(Feedback);
				MessageBox.Show("Send complete.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (FormatException ex)
			{
				MessageBox.Show(ex.Message);
			}
			catch (System.Net.Mail.SmtpException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void CheckStatLinkLabel_Click(object sender, EventArgs e)
		{
			// Process.Start("iexplore.exe " & CheckStatLinkLabel.Text)
			Process.Start("iexplore.exe", CheckStatLinkLabel.Text);
		}
	}
}
