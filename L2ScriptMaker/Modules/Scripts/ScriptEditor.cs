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
	public partial class ScriptEditor : Form
	{
		public ScriptEditor()
		{
			InitializeComponent();
		}

		private string[] MaskCol = new string[101];
		private bool isLoading = false;

		private void ButtonConfig_Click(object sender, EventArgs e)
		{
			OpenFileDialog.Filter = "Visual Script Editor config file|*.ini|All files(*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			var IniFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.GetEncoding(1250), true, 1);
			if ((IniFile.ReadLine() ?? "") != "L2ScriptMaker Visual Script Editor config file v1")
			{
				MessageBox.Show("This file is not L2ScriptMaker Visual Script Editor config file v1" + Constants.vbNewLine + "Buy it or download free :)", "Wrong config file", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				IniFile.Close();
				return;
			}

			int iColIndex = -1;
			for (iColIndex = DataGridView.ColumnCount - 1; iColIndex >= 0; iColIndex += -1)
				DataGridView.Columns.Remove(DataGridView.Columns[iColIndex].Name);
			iColIndex = -1;

			string ColName = "Default";
			int ColWidth = 30;
			string ColToolTip = "";
			bool ColReadOnly = false;
			bool ColList = false;
			string ColDefValue = "";
			string ColBlockSym = "";

			var aTemp = new string[3];
			string TempStr;

			DataGridViewComboBoxColumn comboBoxColumn = null;
			DataGridViewTextBoxColumn textColumn = null;

			isLoading = true;

			while (IniFile.EndOfStream != true)
			{
				TempStr = IniFile.ReadLine();

				// Start working with new column
				if (TempStr.StartsWith("[") == true)
				{
					comboBoxColumn = new DataGridViewComboBoxColumn();
					textColumn = new DataGridViewTextBoxColumn();

					ColName = TempStr.Replace("[", "").Replace("]", "");
					iColIndex += 1;
				}

				// Found List block
				if ((TempStr ?? "") == "<")
				{
					TempStr = IniFile.ReadLine();

					while ((Strings.Mid(TempStr, 1, 1) ?? "") != ">")
					{
						if (ColList == true)
							comboBoxColumn.Items.Add(TempStr);
						TempStr = IniFile.ReadLine();
					}


					// FINISHING and creating new column
					if (ColList == true)
					{
						comboBoxColumn.Name = ColName;
						comboBoxColumn.Width = ColWidth;
						comboBoxColumn.ToolTipText = ColToolTip;
						comboBoxColumn.ReadOnly = ColReadOnly;
						comboBoxColumn.Tag = ColDefValue;
						DataGridView.Columns.Add(comboBoxColumn);
					}
					else
					{
						textColumn.Name = ColName;
						textColumn.Width = ColWidth;
						textColumn.ToolTipText = ColToolTip;
						textColumn.ReadOnly = ColReadOnly;
						textColumn.Tag = ColDefValue;
						DataGridView.Columns.Add(textColumn);
					}
					if (ColDefValue != null)
						DataGridView[iColIndex, 0].Value = ColDefValue;

					// Clean all params for new cycle
					ColName = "Default";
					ColWidth = 30;
					ColList = false;
					ColReadOnly = false;
					ColToolTip = "";
					ColDefValue = "";
					MaskCol[DataGridView.ColumnCount - 1] = ColBlockSym;
					ColBlockSym = "";
				}

				if (Strings.InStr(TempStr, "=") != 0)
				{
					aTemp = TempStr.Split(Conversions.ToChar("="));
					aTemp[0] = aTemp[0].Trim();
					aTemp[1] = aTemp[1].Trim();

					switch (aTemp[0])
					{
						case "width":
							{
								ColWidth = Conversions.ToInteger(aTemp[1]);
								break;
							}

						case "list":
							{
								if ((aTemp[1] ?? "") == "on")
									ColList = true;
								break;
							}

						case "block":
							{
								if ((aTemp[1] ?? "") == "on")
									ColReadOnly = true;
								break;
							}

						case "tooltip":
							{
								if (string.IsNullOrEmpty(aTemp[1]))
									aTemp[1] = ColName;
								ColToolTip = aTemp[1];
								break;
							}

						case "defvalue":
							{
								ColDefValue = aTemp[1];
								break;
							}

						case "symbols":
							{
								ColBlockSym = aTemp[1];
								ColToolTip = ColToolTip + Constants.vbNewLine + "Block symbols: " + aTemp[1];
								break;
							}

						default:
							{
								MessageBox.Show("Unknown params in config file." + Constants.vbNewLine + aTemp[1], "Unknown param", MessageBoxButtons.OK, MessageBoxIcon.Error);
								break;
							}
					}
				}
			}

			isLoading = false;
		}

		private void ButtonGenerate_Click(object sender, EventArgs e)
		{
			int TableCount;
			int RowCounter;
			int iTemp;
			TextBox1.Text = "";

			if (DataGridView.RowCount > 11)
			{
				MessageBox.Show("Use 'Save file' button for generate big project. Only 10 lines will be generation.", "Big project", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				RowCounter = 9;
			}
			else
				RowCounter = DataGridView.RowCount - 2;
			var loopTo = RowCounter;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				var loopTo1 = DataGridView.ColumnCount - 1;
				for (TableCount = 0; TableCount <= loopTo1; TableCount++)
				{
					if (TableCount > 0)
						TextBox1.AppendText(Conversions.ToString((char)9));
					TextBox1.AppendText(DataGridView.Columns[TableCount].Name);

					if (DataGridView[TableCount, iTemp].Value != null | !string.IsNullOrEmpty(MaskCol[TableCount]))
					{
						if (DataGridView.Columns[TableCount].Name != null)
							TextBox1.AppendText("=");
						if (!string.IsNullOrEmpty(MaskCol[TableCount]))
							TextBox1.AppendText(Strings.Mid(MaskCol[TableCount], 1, 1));
						if (DataGridView[TableCount, iTemp].Value != null)
							TextBox1.AppendText(DataGridView[TableCount, iTemp].Value.ToString());
						if (!string.IsNullOrEmpty(MaskCol[TableCount]))
							TextBox1.AppendText(Strings.Mid(MaskCol[TableCount], 2, 1));
					}
				}
				TextBox1.AppendText(Constants.vbNewLine);
			}

			TabControl1.SelectedIndex = 1;
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void ButtonClear_Click(object sender, EventArgs e)
		{
			int TableCount;

			for (TableCount = DataGridView.ColumnCount - 1; TableCount >= 0; TableCount += -1)
				DataGridView.Columns.Remove(DataGridView.Columns[TableCount].Name);
		}

		private void ButtonLoadFile_Click(object sender, EventArgs e)
		{
			if (DataGridView.ColumnCount == 0)
			{
				MessageBox.Show("Empty structure.", "Empty structure", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string sTemp;
			var aTemp = new string[0];
			int iTemp;

			OpenFileDialog.Filter = "Lineage II script-config|*.txt|All files(*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);

			DataGridView.Rows.Clear();
			DataGridView.SuspendLayout();

			ProgressBar.Value = 0;
			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();

				if (!string.IsNullOrEmpty(sTemp.Trim()) & sTemp.StartsWith("//") == false)
				{
					aTemp = sTemp.Split('\t');

					// If aTemp.Length <> DataGridView.ColumnCount Then
					if ((aTemp[0] ?? "") == (DataGridView.Columns[0].Tag.ToString() ?? ""))
					{
						DataGridView.Rows.Add();
						var loopTo = aTemp.Length - 1;
						for (iTemp = 0; iTemp <= loopTo; iTemp++)
						{
							aTemp[iTemp] = aTemp[iTemp].Trim();

							if (Strings.InStr(aTemp[iTemp], "=") != 0)
								aTemp[iTemp] = Libraries.GetNeedParamFromStr(sTemp, DataGridView.Columns[iTemp].Name);
							else
							{
							}
							if (!string.IsNullOrEmpty(MaskCol[iTemp]))
								aTemp[iTemp] = Strings.Mid(aTemp[iTemp].Trim(), 2, aTemp[iTemp].Length - 2);
							DataGridView[iTemp, DataGridView.RowCount - 2].Value = aTemp[iTemp];
						}
					}
					else
					{
					}
				}
				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
			}

			ProgressBar.Value = 0;
			DataGridView.ResumeLayout();
			inFile.Close();
			MessageBox.Show("File loaded.", "Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void ButtonSaveFile_Click(object sender, EventArgs e)
		{
			if (DataGridView.RowCount <= 1)
			{
				MessageBox.Show("Empty project.", "Empty project", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int iTemp;
			int iTemp2;
			string sTemp;

			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			var outFile = new System.IO.StreamWriter(SaveFileDialog.FileName, false, System.Text.Encoding.Unicode, 1);

			ProgressBar.Value = 0;
			ProgressBar.Maximum = DataGridView.RowCount - 2;
			sTemp = "";
			var loopTo = DataGridView.RowCount - 2;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				var loopTo1 = DataGridView.ColumnCount - 1;
				for (iTemp2 = 0; iTemp2 <= loopTo1; iTemp2++)
				{
					if (iTemp2 > 0)
						sTemp = sTemp + Conversions.ToString((char)9);
					sTemp = sTemp + DataGridView.Columns[iTemp2].Name;

					if (DataGridView[iTemp2, iTemp].Value != null | !string.IsNullOrEmpty(MaskCol[iTemp2]))
					{
						if (DataGridView.Columns[iTemp2].Name != null)
							sTemp = sTemp + "=";
						if (!string.IsNullOrEmpty(MaskCol[iTemp2]))
							sTemp = sTemp + Strings.Mid(MaskCol[iTemp2], 1, 1);
						if (DataGridView[iTemp2, iTemp].Value != null)
							sTemp = sTemp + DataGridView[iTemp2, iTemp].Value.ToString();
						if (!string.IsNullOrEmpty(MaskCol[iTemp2]))
							sTemp = sTemp + Strings.Mid(MaskCol[iTemp2], 2, 1);
					}
				}
				outFile.WriteLine(sTemp);
				ProgressBar.Value = iTemp;
				sTemp = "";
			}

			outFile.Close();
			ProgressBar.Value = 0;

			MessageBox.Show("New file saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			// MessageBox.Show("qq")

			if (isLoading == false)
			{
				int iTemp;
				var loopTo = DataGridView.Columns.Count - 1;
				for (iTemp = 0; iTemp <= loopTo; iTemp++)
					DataGridView[iTemp, e.RowIndex].Value = DataGridView.Columns[iTemp].Tag;
			}
		}
	}
}
