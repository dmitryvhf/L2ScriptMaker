using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using L2ScriptMaker.Core;
using L2ScriptMaker.Core.WinForms;
using L2ScriptMaker.Services.Item;
using L2ScriptMaker.Services.Npc;

namespace L2ScriptMaker.Forms.Modules.AI
{
	public partial class AiBuyselllistEditor : Form
	{
		private List<ListItem> _itemsPch;

		public AiBuyselllistEditor()
		{
			InitializeComponent();

			this.Load += OnLoad;
		}

		private void OnLoad(object sender, EventArgs e)
		{
			if (ItemPchLoad() == false) this.Dispose();
		}

		private bool ItemPchLoad()
		{
			string fileName = ItemContants.ItemPchFileName;

			if (System.IO.File.Exists(fileName) == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Title = "Select item_pch.txt file for reading name of items from server file...";
				OpenFileDialog.Filter = @$"{fileName}|{fileName}|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel) return false;

				fileName = OpenFileDialog.FileName;
			}

			INpcPchService npcPchService = new NpcPchService();
			_itemsPch = npcPchService.GetListItems(fileName).ToList();

			ItemList.DataSource = _itemsPch;
			ItemList.ValueMember = "Value";
			ItemList.DisplayMember = "Text";

			return true;
		}

		private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex != 0 || DataGridView[1, e.RowIndex].Value != null) return;

			// Copy CastleTax from previous row or set default "0"
			if (e.RowIndex > 0)
				DataGridView[1, e.RowIndex].Value = DataGridView[1, e.RowIndex - 1].Value;
			else
				DataGridView[1, e.RowIndex].Value = "0";// CityTax.Items(0).ToString
		}

		private void ButtonImport_Click(object sender, EventArgs e)
		{
			DataGridView.Rows.Clear();
			var loopTo = BuySellListBox.Lines.Length - 1;

			for (int iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				// {5; 25; 0.000000; 0 }
				var sTempStr = BuySellListBox.Lines.GetValue(iTemp).ToString();

				sTempStr = sTempStr.Replace(" ", "").Replace("\t", "").Trim();
				if (!string.IsNullOrEmpty(sTempStr))
				{
					if (sTempStr.StartsWith("buyselllist_begin"))
					{
						sTempStr = sTempStr.Replace("buyselllist_begin", "");
						BuySellListTextBox.Text = sTempStr;
						continue;
					}
					if (sTempStr.StartsWith("buyselllist_end"))
					{
						break;
					}

					if (sTempStr.StartsWith("{") == false) continue;

					sTempStr = StringUtils.CutBrackets(sTempStr);
					var aTemp = sTempStr.Split(';');
					if(aTemp.Length != 4) continue;

					ListItem item = _itemsPch.FirstOrDefault(a => a.Value == aTemp[0]);
					if (item == null)
					{
						MessageBox.Show("No exist item with number '" + aTemp[0] + "' in server script\n",
							"Import error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						
						DataGridView.Rows.Clear();
						return;
					}
					DataGridView.Rows.Add(item.Value, aTemp[1]);
				}
			}

			TabControl1.SelectedIndex = 0; // Data page
		}

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			BuySellListBox.Clear();
			BuySellListBox.AppendText("\tbuyselllist_begin " + BuySellListTextBox.Text);

			foreach (DataGridViewRow row in DataGridView.Rows)
			{
				if (row.IsNewRow || row.Cells[0].Value == null) continue;

				// {6125; 20; 0.000000; 0 }
				BuySellListBox.AppendText(Environment.NewLine + "\t\t{"
										  + row.Cells[0].Value + "; "
										  + row.Cells[1].Value + "; "
										  + "0.000000; 0"
										  + "}");
			}
			BuySellListBox.AppendText(Environment.NewLine + "\tbuyselllist_end");

			TabControl1.SelectedIndex = 1; // Result page
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			Dispose();
		}
	}
}
