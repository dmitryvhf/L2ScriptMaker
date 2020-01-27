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
	public partial class ExecL2AuthKey : Form
	{
		public ExecL2AuthKey()
		{
			InitializeComponent();
		}

		private void LoadButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog.Filter = "Lineage II Server Authentification Service|*L2Auth*.exe|Lineage II Client Library (Engine.dll)|Engine.dll";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			// Dim InFixFile As System.IO.Stream = New System.IO.FileStream(OpenFileDialog.FileName, IO.FileMode.Create, Security.AccessControl.FileSystemRights.FullControl, IO.FileShare.None, 1, IO.FileOptions.None)

			var InFixFile = new System.IO.FileStream(OpenFileDialog.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

			long HexOffset = 0;
			long HexL2AuthOffset = Conversions.ToLong(Conversions.Val("&H06C6B0"));
			long HexEngineOffset = Conversions.ToLong(Conversions.Val("&H62531C"));
			if (Strings.InStr(OpenFileDialog.FileName.ToLower(), "engine") != 0)
				HexOffset = HexEngineOffset;
			else
				HexOffset = HexL2AuthOffset;
			if (HexOffset == 0)
				MessageBox.Show("AHTUNG!");

			int iTemp; // sTemp As String
			var aLoadKey = new byte[20];

			InFixFile.Position = HexOffset;
			InFixFile.Read(aLoadKey, 0, 20);

			KeyLoadBox.Text = ""; LoadKeyHexBox.Text = "";
			for (iTemp = 0; iTemp <= 19; iTemp++)
			{
				KeyLoadBox.Text = KeyLoadBox.Text + Conversions.ToString((char)aLoadKey[iTemp]);
				LoadKeyHexBox.Text = LoadKeyHexBox.Text + Conversions.Hex(aLoadKey[iTemp]) + " ";
			}
			InFixFile.Close();
		}

		private void ButtonExit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void KeyLoadBox_TextChanged(object sender, EventArgs e)
		{
			LoadKeyLabel.Text = KeyLoadBox.Text.Length.ToString();
		}

		private void CopyButton_Click(object sender, EventArgs e)
		{
			NewKeyBox.Text = KeyLoadBox.Text;
		}

		private void NewKeyBox_TextChanged(object sender, EventArgs e)
		{
			LoadKeyHexBox.Text = "";
			int iTemp; var aLoadKey = new byte[20];
			var loopTo = NewKeyBox.Text.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
				LoadKeyHexBox.Text = LoadKeyHexBox.Text + Conversions.Hex(Strings.Asc(NewKeyBox.Text[iTemp])) + " ";

			LoadKeyLabel.Text = NewKeyBox.Text.Length.ToString();
		}

		private void WriteButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(NewKeyBox.Text))
			{
				MessageBox.Show("New key must be defined", "No new key", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (NewKeyBox.Text.Length != 20)
			{
				MessageBox.Show("New Key must have 20 symbols", "Wrong key length", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string outAuth;
			string outEngine;

			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II Server Authentification Service|*L2Auth*.exe";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				outAuth = "";
			else
				outAuth = OpenFileDialog.FileName;

			OpenFileDialog.Filter = "Lineage II Client Library (Engine.dll)|Engine*.dll";
			OpenFileDialog.FileName = "";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				outEngine = "";
			else
				outEngine = OpenFileDialog.FileName;
			long HexL2AuthOffset = Conversions.ToLong(Conversions.Val("&H06C6B0"));
			long HexEngineOffset = Conversions.ToLong(Conversions.Val("&H62531C"));
			System.IO.FileStream outFixFile;

			int iTemp; var aLoadKey = new byte[20];
			for (iTemp = 0; iTemp <= 19; iTemp++)
				aLoadKey[iTemp] = Conversions.ToByte(Strings.AscW(NewKeyBox.Text[iTemp]));

			// Write L2Auth
			if (!string.IsNullOrEmpty(outAuth))
			{
				System.IO.File.Copy(outAuth, outAuth + ".bak", true);
				outFixFile = new System.IO.FileStream(outAuth, System.IO.FileMode.Open, System.IO.FileAccess.Write);
				outFixFile.Position = HexL2AuthOffset;
				outFixFile.Write(aLoadKey, 0, 20);
				outFixFile.Close();
			}

			// Write L2Auth
			if (!string.IsNullOrEmpty(outEngine))
			{
				System.IO.File.Copy(outEngine, outEngine + ".bak", true);
				outFixFile = new System.IO.FileStream(outEngine, System.IO.FileMode.Open, System.IO.FileAccess.Write);
				outFixFile.Position = HexEngineOffset;
				outFixFile.Write(aLoadKey, 0, 20);
				outFixFile.Close();
			}

			MessageBox.Show("New blowfish key has been injected.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
