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
	public partial class ExecInjector : Form
	{
		public ExecInjector()
		{
			InitializeComponent();
		}

		private void InjectButton_Click(object sender, EventArgs e)
		{
			string ExecFile, FixFile;
			string ReadStr;

			// Select source and target files
			OpenFileDialog1.Title = "Select Exec file to fix:";
			OpenFileDialog1.FileName = "";
			OpenFileDialog1.Filter = "L2Server.exe|L2Server.exe|All files (*.*)|*.*";
			if (OpenFileDialog1.ShowDialog() == DialogResult.Cancel)
				return;
			else
			{
				ExecFile = OpenFileDialog1.FileName;
				ExecName.Text = ExecFile;
			}

			OpenFileDialog1.Title = "Select Fix file:";
			OpenFileDialog1.FileName = "";
			OpenFileDialog1.Filter = "Text file format|*.txt|All files|*.*";
			if (OpenFileDialog1.ShowDialog() == DialogResult.Cancel)
				return;
			else
			{
				FixFile = OpenFileDialog1.FileName;
				FixName.Text = FixFile;
			}

			// Make backup for exec
			System.IO.File.Copy(ExecFile, ExecFile + ".bak", true);

			// Start fix
			var InFixFile = new System.IO.StreamReader(FixFile, System.Text.Encoding.Default, true, 1);
			System.IO.Stream OExecFile = new System.IO.FileStream(ExecFile, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite);
			var OutExecFile = new System.IO.StreamWriter(OExecFile);

			if (System.IO.File.Exists(FixFile + ".bak") == true & RecoveryBox.Checked == true)
			{
				if ((int)MessageBox.Show("Backup file already exist. Owerwrite last good recovery backup?", "Owerwrite backup?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (int)DialogResult.No)
					return;
			}


			System.IO.Stream OExecFileBak = null;
			System.IO.StreamWriter OutExecFileBak = null;

			if (RecoveryBox.Checked == true)
			{
				// System.IO.Path.GetDirectoryName()
				OExecFileBak = new System.IO.FileStream(System.IO.Path.GetDirectoryName(FixFile) + @"\backup~" + System.IO.Path.GetFileName(FixFile), System.IO.FileMode.Create, System.IO.FileAccess.Write);
				OutExecFileBak = new System.IO.StreamWriter(OExecFileBak);
			}

			int WriteOffset, WriteLenght, tempOff;

			ReadStr = Strings.Trim(InFixFile.ReadLine());
			while (ReadStr != null)
			{
				WriteOffset = Conversions.ToInteger(Conversions.Val("&H" + Strings.Mid(ReadStr, 1, Strings.InStr(ReadStr, ":"))));
				if (IsOffset.Checked == true)
				{
					WriteOffset -= 0x400000;

					if (WriteOffset < 0)
					{
						MessageBox.Show("This fix no required inject offset", "No required offset", MessageBoxButtons.OK, MessageBoxIcon.Error);
						OExecFile.Close();
						InFixFile.Close();
						if (RecoveryBox.Checked == true)
							OutExecFileBak.Close();
						return;
					}
				}

				ReadStr = Strings.Mid(ReadStr, Strings.InStr(ReadStr, ":") + 1, ReadStr.Length).TrimStart();

				string[] TempArr;
				TempArr = ReadStr.Split((char)32);

				var FixStr = new byte[TempArr.Length - 1 + 1];

				if (RecoveryBox.Checked == true)
				{
					var BackupArr = new byte[TempArr.Length - 1 + 1];

					OExecFile.Position = WriteOffset;
					OExecFile.Read(BackupArr, 0, TempArr.Length);

					OutExecFileBak.Write(Conversions.Hex(WriteOffset) + ":");

					//byte tChr;
					foreach (byte tChr in BackupArr)
						OutExecFileBak.Write(" " + Conversions.Hex(tChr).PadLeft(2, Convert.ToChar("0")));
					OutExecFileBak.WriteLine("");
					OutExecFileBak.Flush();
				}

				var loopTo = TempArr.Length - 1;
				for (tempOff = 0; tempOff <= loopTo; tempOff++)
				{
					try
					{
						FixStr[tempOff] = Conversions.ToByte(Conversions.Val("&H" + TempArr[tempOff]));
					}
					catch (Exception ex)
					{
						MessageBox.Show("Fix file have incorrect format. Make recovery fix from backup (.bak) file.", "Incorrect fix", MessageBoxButtons.OK, MessageBoxIcon.Error);
						OExecFile.Close();
						InFixFile.Close();
						if (RecoveryBox.Checked == true)
							OutExecFileBak.Close();
						return;
					}
				}
				WriteLenght = tempOff;

				OExecFile.Position = WriteOffset;
				OExecFile.Write(FixStr, 0, WriteLenght);
				OutExecFile.Flush();

				ReadStr = Strings.Trim(InFixFile.ReadLine());
			}

			OExecFile.Close();
			InFixFile.Close();
			if (RecoveryBox.Checked == true)
				OutExecFileBak.Close();

			MessageBox.Show("Injection success.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			return;
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
		}

		private void HelpButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Fix file format is:" + Conversions.ToString((char)10) + Conversions.ToString((char)10) + "[hex offset]: [binary code or text code]" + Conversions.ToString((char)10) + "Example:" + Conversions.ToString((char)10) + "26A63: E9 35 EC 0F 00 90 90 90 90");
		}
	}
}
