using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using L2ScriptMaker.Core.Logger;

namespace L2ScriptMaker
{
	public partial class CheckUpdate : Form
	{
		private const string SupportEmail = "DmitryVHF@outlook.com";
		private const string BaseUrl = "http://dragon.ur.ru/l2sm/";

		private readonly ILogger _logger;

		public CheckUpdate()
		{
			InitializeComponent();

			_logger = new Logger(nameof(CheckUpdate));
		}

		private async void StartButton_Click(object sender, EventArgs e)
		{
			string l2Tempver = System.IO.Path.GetTempFileName();
			string sVersion;
			string sFile;
			string sUrlFile;

			_logger.Write(LogLevel.Information, "Check available update from [" + BaseUrl + "]");
			_logger.Write(LogLevel.Information, "Current version [" + Application.ProductVersion + "]");

			if (await GetFileFromHttp(BaseUrl + "l2scriptmaker.txt", l2Tempver) == false)
			{
				_logger.Write(LogLevel.Error, "Check file not exists [l2scriptmaker.txt]");
				MessageBox.Show("Can't download version file from site.", "Can't read version", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}
			
			using (System.IO.StreamReader verRead = new System.IO.StreamReader(l2Tempver, Encoding.Default, true, 1))
			{
				sVersion = verRead.ReadLine();
				sFile = verRead.ReadLine();
				sUrlFile = verRead.ReadLine();

				CheckStatLabel.Text = "Version detected: " + sVersion;
				CheckStatLinkLabel.Text = sUrlFile;

				verRead.Close();
			}

			System.IO.File.Delete(l2Tempver);

			if (Application.ProductVersion == sVersion)
			{
				if (MessageBox.Show("You are already have latest release.\nWant to download again?",
					"Already up-date",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)

					return;
			}
			else if (MessageBox.Show("Found new build! " + sVersion + "\nWant to download new?",
				"Found update",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			if (await GetFileFromHttp(sUrlFile, sFile) == false)
			{
				_logger.Write(LogLevel.Information, "Downloading file is failed");

				MessageBox.Show("Can't download file from site.", "Can't download",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			_logger.Write(LogLevel.Information, new string[]
			{
				"Downloaded is successfully:",
				"[" + sVersion + "][" + sFile + "]"
			});

			MessageBox.Show(
				"Download new update success. Last build is " + sVersion
				+ "\nNote: close tool, extract new build from file, your work folder",
				"Success.",
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private async Task<bool> GetFileFromHttp(string url, string file)
		{
			using (HttpClient httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
				{
					NoCache = true
				};

				_logger.Write(LogLevel.Trace, "Downloading [" + url + "]");

				var result = await httpClient.GetAsync(url);
				try
				{
					result.EnsureSuccessStatusCode();
				}
				catch (Exception ex)
				{
					_logger.Write(LogLevel.Error, new string[]
					{
						"Downloaded is failed:",
						"Remote file [" + url + "]",
						ex.Message
					});
					return false;
				}


				byte[] data = await result.Content.ReadAsByteArrayAsync();
				try
				{
					await System.IO.File.WriteAllBytesAsync(file, data);
					result.Content.Dispose();
				}
				catch (Exception ex)
				{
					_logger.Write(LogLevel.Error, new string[]
					{
						"Write file [" + file + "] error: ",
						ex.Message
					});

					MessageBox.Show(ex.Message);
					return false;
				}
			}

			return true;
		}

		private void SendMailButton_Click(object sender, EventArgs e)
		{
			System.Net.Mail.MailMessage feedback = new System.Net.Mail.MailMessage(MailFromTextBox.Text, SupportEmail, SubjectTextBox.Text,
				TextBox.Text);

			try
			{
				using (System.Net.Mail.SmtpClient mailclient = new System.Net.Mail.SmtpClient(MailSrvTextBox.Text))
				{
					mailclient.UseDefaultCredentials = true;
					mailclient.Send(feedback);
				}
			}
			catch (FormatException ex)
			{
				_logger.Write(LogLevel.Error, new string[]
				{
					"Send mail failed:",
					$"From [{MailFromTextBox.Text}]; To [{SupportEmail}]; Subject [{SubjectTextBox.Text}]",
					$"Text: [{TextBox.Text}]",
					ex.Message
				});

				MessageBox.Show(ex.Message);
			}
			catch (System.Net.Mail.SmtpException ex)
			{
				string exMessage = ex.Message
					+ (ex.InnerException == null ? String.Empty : $": " + ex.InnerException.Message);

				_logger.Write(LogLevel.Error, new string[]
				{
					"Send mail failed:",
					$"From [{MailFromTextBox.Text}]; To [{SupportEmail}]; Subject [{SubjectTextBox.Text}]",
					$"Text: [{TextBox.Text}]"
				});
				_logger.Write(LogLevel.Error, ex);

				MessageBox.Show(exMessage);
			}

			MessageBox.Show("Send complete.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void CheckStatLinkLabel_Click(object sender, EventArgs e)
		{
			Process.Start("iexplore.exe", CheckStatLinkLabel.Text);
		}
	}
}