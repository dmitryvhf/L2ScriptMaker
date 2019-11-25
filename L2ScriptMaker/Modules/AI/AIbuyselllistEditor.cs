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

namespace L2ScriptMaker.Modules.AI
{
	public partial class AIbuyselllistEditor : Form
	{
		public AIbuyselllistEditor()
		{
			InitializeComponent();
		}

		private string[] ItemPch = new string[30001];
		private void ButtonStart_Click(object sender, EventArgs e)
		{
			int iTemp;

			BuySellListBox.Text = "";
			BuySellListBox.AppendText(Constants.vbTab + "buyselllist_begin " + BuySellListTextBox.Text + Constants.vbNewLine);
			var loopTo = DataGridView.RowCount - 2;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
				// {6125; 20; 0.000000; 0 }
				BuySellListBox.AppendText(Constants.vbTab + Constants.vbTab + "{" + Array.IndexOf(ItemPch, DataGridView[0, iTemp].Value).ToString() + "; " + DataGridView[1, iTemp].Value.ToString() + "; 0.000000; 0 }" + Constants.vbNewLine);
			BuySellListBox.AppendText(Constants.vbTab + "buyselllist_end");

			TabControl1.SelectedIndex = 1; // Result page
		}

		private void AIbuyselllistEditor_Load(object sender, EventArgs e)
		{
			string FileName = "item_pch.txt";

			if (System.IO.File.Exists("item_pch.txt") == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Title = "Select item_pch.txt file for reading name of items from server file...";
				OpenFileDialog.Filter = "item_pch.txt|item_pch.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					this.Dispose(); // Exit Sub
				FileName = OpenFileDialog.FileName;
			}

			if (ItemPchLoad(FileName) == false)
				return;
		}

		private bool ItemPchLoad(string FileName)
		{
			System.IO.StreamReader inFile;
			try
			{
				inFile = new System.IO.StreamReader(FileName, System.Text.Encoding.Default, true, 1);
			}
			catch (Exception ex)
			{
				return false;
			}
			string sTempStr = "";
			var aTemp = new string[2];

			while (inFile.EndOfStream != true)
			{

				// [small_sword]	=	1
				try
				{
					sTempStr = inFile.ReadLine();
					sTempStr = sTempStr.Replace(" ", "").Replace("\t", "").Replace("[", "").Replace("]", "");
					aTemp = sTempStr.Split(Conversions.ToChar("="));

					ItemPch[Conversions.ToInteger(aTemp[1])] = aTemp[0];
					ItemList.Items.Add(aTemp[0]);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Import data invalid in line" + Constants.vbNewLine + sTempStr, "Import data invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
					inFile.Close();
					return false;
				}
			}

			inFile.Close();
			return true;
		}

		private void ButtonImport_Click(object sender, EventArgs e)
		{
			int iTemp;

			// {5; 25; 0.000000; 0 }

			DataGridView.Rows.Clear();
			string sTempStr;
			var aTemp = new string[4];
			var loopTo = BuySellListBox.Lines.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				sTempStr = BuySellListBox.Lines.GetValue(iTemp).ToString();

				sTempStr = sTempStr.Replace(" ", "").Replace(Conversions.ToString((char)9), "").Trim();
				if (!string.IsNullOrEmpty(sTempStr))
				{
					if (sTempStr.StartsWith("{") == true)
					{

						// item shop list
						sTempStr = sTempStr.Replace("{", "").Replace("}", "");
						aTemp = sTempStr.Split(Conversions.ToChar(";"));

						try
						{
							if (string.IsNullOrEmpty(ItemPch[Conversions.ToInteger(aTemp[0])]))
							{
								MessageBox.Show("No exist item with number '" + Conversions.ToString(Conversions.ToInteger(aTemp[0])) + "' in server script" + Constants.vbNewLine, "No exist item number", MessageBoxButtons.OK, MessageBoxIcon.Error);
								DataGridView.Rows.Clear();
								return;
							}
							DataGridView.Rows.Add(ItemPch[Conversions.ToInteger(aTemp[0])], aTemp[1]);
						}
						catch (Exception ex)
						{
							MessageBox.Show("Import data invalid in line" + Constants.vbNewLine + sTempStr, "Import data invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
					}
					else if (sTempStr.StartsWith("buyselllist_begin") == true)
					{
						sTempStr = sTempStr.Replace("buyselllist_begin", "");
						BuySellListTextBox.Text = sTempStr;
					}
				}
			}

			// TabDataPage.Select()
			TabControl1.SelectedIndex = 0; // Data page
		}

		private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
			{
				if (e.ColumnIndex == 0)
				{
					if (DataGridView[1, e.RowIndex].Value == null)
					{
						if (e.RowIndex > 0)
							DataGridView[1, e.RowIndex].Value = DataGridView[1, e.RowIndex - 1].Value;
						else
							DataGridView[1, e.RowIndex].Value = "0";// CityTax.Items(0).ToString
					}
				}
			}
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
