using L2ScriptMaker.Extensions.VbCompatibleHelper;
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

namespace L2ScriptMaker.Modules.Others
{
	public partial class HtmlButtonDesigner : Form
	{
		public HtmlButtonDesigner()
		{
			InitializeComponent();
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{

			// check input params
			if (string.IsNullOrEmpty(WidthValue.Text))
			{
				MessageBox.Show("No Width param", "No param", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
			}
			if (string.IsNullOrEmpty(HeightValue.Text))
			{
				MessageBox.Show("No Height param", "No param", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
			}
			if (string.IsNullOrEmpty(BackValue.Text))
			{
				MessageBox.Show("No Back param", "No param", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
			}
			if (string.IsNullOrEmpty(ForeValue.Text))
			{
				MessageBox.Show("No Fore param", "No param", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
			}

			// - Select work directory -
			ProgressBar.Value = 0;
			ScanFile.Text = "";
			string WorkDirName;

			// Select folder to work
			FolderBrowserDialog.Description = "Select where source html file's";
			if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
				return;
			WorkDirName = FolderBrowserDialog.SelectedPath;

			if (System.IO.Directory.Exists(WorkDirName + @"\fixed_html") == false)
				System.IO.Directory.CreateDirectory(WorkDirName + @"\fixed_html");
			else
			{
				MessageBox.Show("Fixed folder already exist. Delete it or rename", "Exist output folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Read files list
			string[] FileList;
			FileList = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath + @"\", "*.htm", System.IO.SearchOption.TopDirectoryOnly);
			if (FileList.Length == 0)
			{
				MessageBox.Show("Source directory empty!", "Empty directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string ReadStr;

			int TempFileNum;
			string InLink;
			var loopTo = FileList.Length - 1;
			for (TempFileNum = 0; TempFileNum <= loopTo; TempFileNum++)
			{
				ScanFile.Text = System.IO.Path.GetFileName(FileList[TempFileNum]);
				this.Refresh();


			TryAgain:
				;
				var InFixFile = new System.IO.StreamReader(FileList[TempFileNum], System.Text.Encoding.Default, true, 1);
				ReadStr = InFixFile.ReadToEnd();
				bool FixStatus = false;

				while (Strings.InStr(ReadStr, "<a action=") != 0)
				{
					int Temp1;
					int Temp2;
					Temp1 = Strings.InStr(ReadStr, "<a action=");
					Temp2 = Strings.InStr(Temp1, ReadStr, "</a>") + 4;
					if (Temp2 < Temp1)
					{
						InFixFile.Close();
						// Interaction.Shell("notepad.exe " + FileList[TempFileNum], AppWinStyle.NormalFocus);
						Process.Start("notepad.exe", FileList[TempFileNum]);
						MessageBox.Show("Fix file and press OK to try again");
						goto TryAgain;
					}

					InLink = Strings.Mid(ReadStr, Temp1, Temp2 - Temp1);
					if (!string.IsNullOrEmpty(StartTag.Text) & !string.IsNullOrEmpty(EndTag.Text))
						ReadStr = Strings.Replace(ReadStr, InLink, StartTag.Text + ChgHtmlButStl(InLink) + EndTag.Text);
					else
						ReadStr = Strings.Replace(ReadStr, InLink, ChgHtmlButStl(InLink));
					FixStatus = true;
				}
				InFixFile.Close();

				if (FixStatus == true)
				{
					System.IO.Stream oExecFile = new System.IO.FileStream(WorkDirName + @"\fixed_html\" + System.IO.Path.GetFileName(FileList[TempFileNum]), System.IO.FileMode.Create, System.IO.FileAccess.Write);
					var outExecFile = new System.IO.StreamWriter(oExecFile, System.Text.Encoding.Unicode);
					outExecFile.Write(ReadStr);
					outExecFile.Flush();
					outExecFile.Close();
				}

				ProgressBar.Value = Conversions.ToInteger((TempFileNum + 1) * 100 / (double)FileList.Length);
			}

			ProgressBar.Value = 0;
			ScanFile.Text = "";
			MessageBox.Show("Html directory now +" + Conversions.ToString(FileList.Length) + " enchant.");
		}

		private string ChgHtmlButStl(string InLink)
		{
			string ChgHtmlButStlRet = default(string);
			var InStrArr = new string[2];
			int Temp1;
			int Temp2;

			// 1. link 
			Temp1 = Strings.InStr(InLink, "<a action=") + 11;
			Temp2 = Strings.InStr(Temp1, InLink, Conversions.ToString((char)34));
			InStrArr[0] = Strings.Mid(InLink, Temp1, Temp2 - Temp1);

			// 2. link text
			Temp1 = Temp2 + 2;
			Temp2 = Strings.InStr(Temp1, InLink, "</a>");
			InStrArr[1] = Strings.Mid(InLink, Temp1, Temp2 - Temp1);

			// <button action="link hello.html" value="Hello Chat" width=200 height=50 back="background.jpg" fore="foreground.jpg">
			ChgHtmlButStlRet = "<button action=" + Conversions.ToString((char)34) + InStrArr[0] + Conversions.ToString((char)34) + " value=" + Conversions.ToString((char)34) + InStrArr[1] + Conversions.ToString((char)34) + " width=" + WidthValue.Text + " height=" + HeightValue.Text + " back=" + Conversions.ToString((char)34) + BackValue.Text + Conversions.ToString((char)34) + " fore=" + Conversions.ToString((char)34) + ForeValue.Text + Conversions.ToString((char)34) + ">";
			return ChgHtmlButStlRet;
		}

		private void AboutButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Tool for convert html to new C3 design. Idea by Virgi"
		   + Constants.vbNewLine + "Tool change standart button to button with user define style (size, background and etc). Example. This message in html file"
		   + Constants.vbNewLine
		   + Constants.vbNewLine + "<center><a action=" + Conversions.ToString((char)34) + "bypass -h recipe?id=159" + Conversions.ToString((char)34) + ">[Create]</a><br><br></center></body></html>"
		   + Constants.vbNewLine
		   + Constants.vbNewLine + "will be this after updating:" + Constants.vbNewLine
		   + Constants.vbNewLine + "<center><td><button action=" + Conversions.ToString((char)34) + "bypass -h recipe?id=159" + Conversions.ToString((char)34) + " value=" + Conversions.ToString((char)34) + "[Create]" + Conversions.ToString((char)34) + " width=111 height=222 back=" + Conversions.ToString((char)34) + "L2UI_CH3.Btn1_normalOn" + Conversions.ToString((char)34) + " fore=" + Conversions.ToString((char)34) + "L2UI_CH3.Btn1_normal" + Conversions.ToString((char)34) + "></td><br><br></center></body></html>"
		   + Constants.vbNewLine
		   + Constants.vbNewLine + "with using: width=111 height=222 back=L2UI_CH3.Btn1_normalOn fore=L2UI_CH3.Btn1_normal in tool dialog starttag=<td> endtag=</td>");
		}
	}
}
