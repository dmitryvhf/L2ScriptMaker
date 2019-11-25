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
	public partial class ScriptAddDelParam : Form
	{
		public ScriptAddDelParam()
		{
			InitializeComponent();
		}

		private void ButtonDelParamGo_Click(object sender, EventArgs e)
		{
			if (ComboBoxParamList.Text.Trim().Length == 0)
			{
				MessageBox.Show("Clean parameter undefined! Enter name and Go again.", "No param", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string sNewValue = null;
			switch (ComboBoxDelMode.Text)
			{
				case "Delete value":
					{
						if (string.IsNullOrEmpty(TextBoxAddParamValue.Text))
						{
							MessageBox.Show("Default Value undefined! Select mode and Go again.", "No mode", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
						sNewValue = TextBoxAddParamValue.Text;
						break;
					}

				case "Delete param":
					{
						break;
					}

				default:
					{
						MessageBox.Show("Mode for cleaning undefined! Select mode and Go again.", "No mode", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
			}

			string sFileName;
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sFileName = OpenFileDialog.FileName;

			System.IO.StreamReader inFile;
			System.IO.StreamWriter outFile;
			string sTempFS;
			string sTemp;
			string sTempLook = ComboBoxParamList.Text.Trim();

			if (System.IO.File.Exists(sFileName + ".bak") == true)
			{
				if ((int)MessageBox.Show("Backup file already exist. Overwrite this file?", "Overwrite backup?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == (int)DialogResult.No)
					return;
			}

			System.IO.File.Copy(sFileName, sFileName + ".bak", true);
			inFile = new System.IO.StreamReader(sFileName + ".bak", System.Text.Encoding.Default, true, 1);
			outFile = new System.IO.StreamWriter(sFileName, false, System.Text.Encoding.Default, 1);
			while (inFile.EndOfStream != true)
			{
				sTempFS = inFile.ReadLine();
				sTemp = Libraries.GetNeedParamFromStr(sTempFS, sTempLook);
				if (!string.IsNullOrEmpty(sTemp))
				{
					if ((ComboBoxDelMode.Text ?? "") == "Delete value")
						sTempFS = Libraries.SetNeedParamToStr(sTempFS, sTempLook, sNewValue);
					else
					{
						sTempFS = Libraries.SetNeedParamToStr(sTempFS, sTempLook, "");
						sTempFS = sTempFS.Replace(sTempLook, "");
					}
					sTempFS = sTempFS.Replace(Conversions.ToString((char)9) + Conversions.ToString((char)9), Conversions.ToString((char)9));
				}

				outFile.WriteLine(sTempFS);
			}
			outFile.Close();
			inFile.Close();

			MessageBox.Show("Writing complete. Param has been cleaned", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}


		private void ButtonStructLoad_Click(object sender, EventArgs e)
		{
			string sFileName;
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sFileName = OpenFileDialog.FileName;

			var aParamList = new string[1];
			System.IO.StreamReader inFile;
			string sTemp;

			inFile = new System.IO.StreamReader(sFileName, System.Text.Encoding.Default, true, 1);

			sTemp = inFile.ReadLine();
			aParamList = sTemp.Split((char)9);
			int iTemp;
			int iTemp2;
			var loopTo = aParamList.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				iTemp2 = Strings.InStr(aParamList[iTemp], "=");
				if (iTemp2 == 0)
					ComboBoxParamList.Items.Add(aParamList[iTemp]);
				else
					ComboBoxParamList.Items.Add(aParamList[iTemp].Remove(iTemp2 - 1));
			}

			inFile.Close();

			if (iTemp > 1)
				ComboBoxParamList.Text = ComboBoxParamList.Items[0].ToString();
			else
				MessageBox.Show("Empty file? No params?", "No param", MessageBoxButtons.OK, MessageBoxIcon.Question);
		}

		private void ButtonAddParamGo_Click(object sender, EventArgs e)
		{
			if (ComboBoxParamList.Text.Trim().Length == 0)
			{
				MessageBox.Show("New parameter undefined! Enter name and Go again.", "No new param", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (TextBoxAddParam.Text.ToString().Trim().Length == 0 | TextBoxAddParamValue.Text.ToString().Trim().Length == 0)
			{
				MessageBox.Show("Empty new parameter! Enter name and Go again.", "No param", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (ComboBoxEditMode.SelectedIndex == 0 & ComboBoxParamList.SelectedIndex == 0)
			{
				MessageBox.Show("Impossible add before first element", "No param", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string sFileName;
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sFileName = OpenFileDialog.FileName;

			System.IO.StreamReader inFile;
			System.IO.StreamWriter outFile;
			string sTempFS;
			string sTemp;
			string sTempLook;
			string sTempNewParam = TextBoxAddParam.Text;
			string sTempNewParamValue = TextBoxAddParamValue.Text;
			string sTempNewParamFull = sTempNewParam + "=" + sTempNewParamValue;

			// parameter for looking after/before
			sTempLook = ComboBoxParamList.Text;

			if (System.IO.File.Exists(sFileName + ".bak") == true)
			{
				if ((int)MessageBox.Show("Backup file already exist. Overwrite this file?", "Overwrite backup?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == (int)DialogResult.No)
					return;
			}

			System.IO.File.Copy(sFileName, sFileName + ".bak", true);
			inFile = new System.IO.StreamReader(sFileName + ".bak", System.Text.Encoding.Default, true, 1);
			outFile = new System.IO.StreamWriter(sFileName, false, System.Text.Encoding.Default, 1);
			while (inFile.EndOfStream != true)
			{
				sTempFS = inFile.ReadLine();
				sTemp = Libraries.GetNeedParamFromStr(sTempFS, sTempLook);
				if (string.IsNullOrEmpty(sTemp))
				{
					MessageBox.Show("Empty file? No params?", "No param", MessageBoxButtons.OK, MessageBoxIcon.Question);
					outFile.Close();
					inFile.Close();
					return;
				}
				else
				{
					sTemp = Libraries.GetNeedParamFromStr(sTempFS, sTempNewParam);
					if (string.IsNullOrEmpty(sTemp))
					{
						switch (ComboBoxEditMode.SelectedIndex)
						{
							case 0:
								{
									sTempFS = sTempFS.Replace(sTempLook, sTempNewParamFull + Conversions.ToString((char)9) + sTempLook);
									break;
								}

							case 1:
								{
									sTempFS = sTempFS.Replace(sTempLook + "=" + Libraries.GetNeedParamFromStr(sTempFS, sTempLook), sTempLook + "=" + Libraries.GetNeedParamFromStr(sTempFS, sTempLook) + Conversions.ToString((char)9) + sTempNewParamFull);
									break;
								}
						}
					}
					else
					{
						// This parameter already exist. Need to be ignore?
						// New function (future) - rewrite exist param by default value
						if (CheckBoxAddParamOverwrite.Checked == true)
							sTempFS = Libraries.SetNeedParamToStr(sTempFS, sTempNewParam, sTempNewParamValue);
					}
				}

				outFile.WriteLine(sTempFS);
			}
			outFile.Close();
			inFile.Close();

			MessageBox.Show("Writing complete. New param has been added", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
