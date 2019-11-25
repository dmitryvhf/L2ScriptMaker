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
	public partial class EventDataEditor : Form
	{
		public EventDataEditor()
		{
			InitializeComponent();
		}

		private bool ItemsIsNumbers = false;

		private string[] ItemPch = new string[30001];

		private void AIbuyselllistEditor_Load(object sender, EventArgs e)
		{
			string FileName = "item_pch.txt";

			if (System.IO.File.Exists("item_pch.txt") == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Title = "Select item_pch.txt file for reading name of items from server file...";
				OpenFileDialog.Filter = "item_pch.txt|item_pch.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					this.Close();// Exit Sub
				FileName = OpenFileDialog.FileName;
			}

			if ((int)MessageBox.Show("Loading items as names?", "Items as name", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (int)DialogResult.No)
				ItemsIsNumbers = true;
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
					sTempStr = sTempStr.Replace(" ", "").Replace(Conversions.ToString((char)9), "").Replace("[", "").Replace("]", "");
					aTemp = sTempStr.Split(Conversions.ToChar("="));
					ItemPch[Conversions.ToInteger(aTemp[1])] = aTemp[0];
					if (ItemsIsNumbers == false)
						Column1Name.Items.Add(aTemp[0]);
					else
						Column1Name.Items.Add(aTemp[1]);
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

		private void GenerateButton_Click(object sender, EventArgs e)
		{
			int iTemp;

			TabControl1.SelectTab(0);

			FinalBox.Text = "[event]" + Constants.vbNewLine;
			FinalBox.Text += "eventname=" + EventNameBox.Text + Constants.vbNewLine;
			FinalBox.Text += "eventnpcname=" + EventNpcNameBox.Text + Constants.vbNewLine;
			FinalBox.Text += "flagsettingtime=" + FlagSettingTimeBox.Text + Constants.vbNewLine;
			FinalBox.Text += "event_doing=" + EventDoingBox.SelectedIndex.ToString() + Constants.vbNewLine;

			// dropitem_count
			FinalBox.Text += "dropitem_count= " + (DataGridView1.RowCount - 1).ToString() + Constants.vbNewLine;
			var loopTo = DataGridView1.RowCount - 2;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				if (ItemsIsNumbers == false)
					FinalBox.Text += Constants.vbTab + "dropitem" + iTemp.ToString() + "= " + DataGridView1[0, iTemp].Value.ToString() + " " + DataGridView1[1, iTemp].Value.ToString() + Constants.vbNewLine;
				else
					FinalBox.Text += Constants.vbTab + "dropitem" + iTemp.ToString() + "= " + ItemPch[Convert.ToInt32(DataGridView1[0, iTemp].Value)] + " " + DataGridView1[1, iTemp].Value.ToString() + Constants.vbNewLine;
			}
			FinalBox.Text += Constants.vbNewLine;

			// dropitem_count
			FinalBox.Text += "droptime_count= " + (DataGridView2.RowCount - 1).ToString() + Constants.vbNewLine;
			var loopTo1 = DataGridView2.RowCount - 2;
			for (iTemp = 0; iTemp <= loopTo1; iTemp++)
				FinalBox.Text += Constants.vbTab + "droptime" + iTemp.ToString() + "= " + DataGridView2[0, iTemp].Value.ToString() + " ~ " + DataGridView2[1, iTemp].Value.ToString() + Constants.vbNewLine;
			FinalBox.Text += Constants.vbNewLine;

			// dropitem_count
			FinalBox.Text += "npctime_count= " + (DataGridView3.RowCount - 1).ToString() + Constants.vbNewLine;
			var loopTo2 = DataGridView3.RowCount - 2;
			for (iTemp = 0; iTemp <= loopTo2; iTemp++)
				FinalBox.Text += Constants.vbTab + "npctime" + iTemp.ToString() + "= " + DataGridView3[0, iTemp].Value.ToString() + " ~ " + DataGridView3[1, iTemp].Value.ToString() + Constants.vbNewLine;
			FinalBox.Text += Constants.vbNewLine;

			// FinalBox.Text += "timevariable_count= 0" & vbNewLine
			// timevariable_count
			FinalBox.Text += "timevariable_count= " + (DataGridView4.RowCount - 1).ToString() + Constants.vbNewLine;
			var loopTo3 = DataGridView4.RowCount - 2;
			for (iTemp = 0; iTemp <= loopTo3; iTemp++)
				FinalBox.Text += Constants.vbTab + "timevariable" + iTemp.ToString() + "= " + DataGridView4[0, iTemp].Value.ToString() + " ~ " + DataGridView4[1, iTemp].Value.ToString() + ";" + DataGridView4[2, iTemp].Value.ToString() + Constants.vbNewLine;
			FinalBox.Text += Constants.vbNewLine;

			FinalBox.Text += "[npcsetting]" + Constants.vbNewLine;
			FinalBox.Text += "npcsetting_count= 1" + Constants.vbNewLine;
			FinalBox.Text += "npc_eventname0= " + EventNameBox.Text + Constants.vbNewLine;
			FinalBox.Text += Constants.vbNewLine;
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void AboutButton_Click(object sender, EventArgs e)
		{
			new EventDataEditorAbout().Show();
		}

		private void DataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
			{
				if (e.RowIndex == DataGridView2.RowCount - 1)
					DataGridView2.Rows.Add();
				DataGridView2[e.ColumnIndex, e.RowIndex].Value = DateTimePicker2.Text;
			}
		}

		private void DataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
			{
				if (e.RowIndex == DataGridView3.RowCount - 1)
					DataGridView3.Rows.Add();
				DataGridView3[e.ColumnIndex, e.RowIndex].Value = DateTimePicker2.Text;
			}
		}


		private void DataGridView4_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				if (e.ColumnIndex == 0)
				{
					if (DataGridView4[1, e.RowIndex].Value != null)
					{
						if (Convert.ToInt32(DataGridView4[0, e.RowIndex].Value) > Convert.ToInt32(DataGridView4[1, e.RowIndex].Value))
							DataGridView4[0, e.RowIndex].Value = DataGridView4[1, e.RowIndex].Value;
					}
					else
						DataGridView4[1, e.RowIndex].Value = DataGridView4[0, e.RowIndex].Value;
				}

				if (e.ColumnIndex == 1)
				{
					if (DataGridView4[0, e.RowIndex].Value != null)
					{
						if (Convert.ToInt32(DataGridView4[1, e.RowIndex].Value) < Convert.ToInt32(DataGridView4[0, e.RowIndex].Value))
							DataGridView4[1, e.RowIndex].Value = DataGridView4[0, e.RowIndex].Value;
					}
					else
						DataGridView4[0, e.RowIndex].Value = DataGridView4[1, e.RowIndex].Value;
				}

				if (DataGridView4[2, e.RowIndex].Value == null)
					DataGridView4[2, e.RowIndex].Value = "1";
			}
		}

		private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
			{
				if (e.ColumnIndex == 0)
				{
					if (DataGridView1[1, e.RowIndex].Value == null)
						DataGridView1[1, e.RowIndex].Value = "1";
				}
			}
		}
	}
}
