using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using L2ScriptMaker.Extensions;
using L2ScriptMaker.Extensions.VbCompatibleHelper;

namespace L2ScriptMaker.Modules.Others
{
    public partial class MultisellEditor : Form
    {
        public MultisellEditor()
        {
            InitializeComponent();
        }

        private string[] ItemPch = new string[30001];

        private readonly object[] _trueFalseItems  = new object[]
        {
            new SelectedItem { Text = "", Value = "" },
            new SelectedItem { Text = "false", Value = "0" },
            new SelectedItem { Text = "true", Value = "1" }
        };

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

            IsDutyfreeBox.DisplayMember = "Text";
            IsDutyfreeBox.ValueMember = "Value";
            IsDutyfreeBox.Items.AddRange(_trueFalseItems);
            IsDutyfreeBox.SelectedIndex = 0;

            IsShowAllBox.DisplayMember = "Text";
            IsShowAllBox.ValueMember = "Value";
            IsShowAllBox.Items.AddRange(_trueFalseItems);
            IsShowAllBox.SelectedIndex = 0;

            KeepEnchantedBox.DisplayMember = "Text";
            KeepEnchantedBox.ValueMember = "Value";
            KeepEnchantedBox.Items.AddRange(_trueFalseItems);
            KeepEnchantedBox.SelectedIndex = 0;

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

            // ItemList.Items.Add(new SelectedItem { Text = "", Value = "" });
            ItemList.Items.Add("");
            ItemsComponentsList.Items.Add("");

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
                    ItemsComponentsList.Items.Add(aTemp[0]);
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
            // {5; 25; 0.000000; 0 }

            DataGridView.Rows.Clear();
            string sTempStr;
            var aTemp = new string[4];
            int iTemp;
            int iTemp2;
            var loopTo = BuySellListBox.Lines.Length - 1;
            for (iTemp = 0; iTemp <= loopTo; iTemp++)
            {
                sTempStr = BuySellListBox.Lines.GetValue(iTemp).ToString();

                sTempStr = sTempStr.Replace(" ", "").Replace("\t", "").Trim();
                if (!string.IsNullOrEmpty(sTempStr))
                {
                    if (sTempStr.StartsWith("//") == true)
                        MultisellNoteBox.Text = sTempStr.Remove(0, 2);
                    if (sTempStr.StartsWith("MultiSell_begin") == true)
                    {
                        // MultiSell_begin	[weapon_variation]	4
                        iTemp2 = Strings.InStr(sTempStr, "[");
                        sTempStr = sTempStr.Remove(0, iTemp2);
                        BuySellListTextBox.Text = sTempStr.Substring(0, Strings.InStr(sTempStr, "]") - 1);
                        MultisellIDBox.Text = sTempStr.Remove(0, Strings.InStr(sTempStr, "]"));
                    }
                    if (sTempStr.StartsWith("is_dutyfree"))
                    {
                        IsDutyfreeBox.SelectItembyValue(Libraries.GetNeedParamFromStr(sTempStr, "is_dutyfree"));
                    }
                    if (sTempStr.StartsWith("is_show_all"))
                    {
                        IsShowAllBox.SelectItembyValue(Libraries.GetNeedParamFromStr(sTempStr, "is_show_all"));
                    }
                    if (sTempStr.StartsWith("keep_enchanted"))
                    {
                        KeepEnchantedBox.SelectItembyValue(Libraries.GetNeedParamFromStr(sTempStr, "keep_enchanted"));
                    }

                    if (sTempStr.StartsWith("{") == true)
                    {

                        // item shop list
                        if (sTempStr.EndsWith(";") == true)
                            sTempStr = sTempStr.Remove(sTempStr.Length - 1, 1);
                        sTempStr = sTempStr.Replace("{", "").Replace("}", "");
                        aTemp = sTempStr.Split(Conversions.ToChar(";"));
                        var loopTo1 = aTemp.Length - 1;
                        for (iTemp2 = 0; iTemp2 <= loopTo1; iTemp2 += 2)
                        {
                            aTemp[iTemp2] = aTemp[iTemp2].Replace("[", "").Replace("]", "");
                            if (iTemp2 == 0)
                                aTemp[2] = aTemp[2].Replace("[", "").Replace("]", "");
                            try
                            {
                                if (Array.IndexOf(ItemPch, aTemp[iTemp2]) == -1)
                                {
                                    MessageBox.Show("No exist item '" + aTemp[iTemp2] + "' in server script" + Constants.vbNewLine, "No exist item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    DataGridView.Rows.Clear();
                                    return;
                                }
                                if (iTemp2 == 0)
                                    DataGridView.Rows.Add(aTemp[0], aTemp[1], aTemp[2], aTemp[3]);
                                else
                                    DataGridView.Rows.Add(null, null, aTemp[iTemp2], aTemp[iTemp2 + 1]);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Import data invalid in line" + Constants.vbNewLine + sTempStr, "Import data invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (iTemp2 == 0)
                                iTemp2 = 2;
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

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            int iTemp;

            BuySellListBox.Text = "";
            if (MultisellNoteBox.Text != "")
                BuySellListBox.AppendText("// " + MultisellNoteBox.Text + Constants.vbNewLine);

            BuySellListBox.AppendText("MultiSell_begin" + Constants.vbTab + "[" + BuySellListTextBox.Text + "]" + Constants.vbTab + MultisellIDBox.Text + Constants.vbNewLine);

            if (IsDutyfreeBox.SelectedIndex > 0)
                BuySellListBox.AppendText("is_dutyfree = " + ((SelectedItem)IsDutyfreeBox.SelectedItem).Value + Constants.vbNewLine);
            if (IsShowAllBox.SelectedIndex > 0)
                BuySellListBox.AppendText("is_show_all = " + ((SelectedItem)IsShowAllBox.SelectedItem).Value + Constants.vbNewLine);
            if (KeepEnchantedBox.SelectedIndex > 0)
                BuySellListBox.AppendText("keep_enchanted = " + ((SelectedItem)KeepEnchantedBox.SelectedItem).Value + Constants.vbNewLine);

            BuySellListBox.AppendText("selllist={" + Constants.vbNewLine);
            var loopTo = DataGridView.RowCount - 2;
            for (iTemp = 0; iTemp <= loopTo; iTemp++)
            {

                // {{{[flamberge];1}};{{[crystal_c];573};{[crystal_d];2865}}};
                if (DataGridView[0, iTemp].Value != null)
                {
                    if (iTemp > 0)
                        BuySellListBox.AppendText("}};" + Constants.vbNewLine);

                    BuySellListBox.AppendText("{{{[" + DataGridView[0, iTemp].Value + "];" +
                                              DataGridView[1, iTemp].Value + "}}");
                }

                if (DataGridView[3, iTemp].Value == null)
                {
                    MessageBox.Show("Required component item", "Required component value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // BuySellListBox.AppendText("{{{[" + DataGridView[0, iTemp].Value.ToString() + "];" + DataGridView[1, iTemp].Value.ToString() + "}}");

                BuySellListBox.AppendText(";{[" + DataGridView[2, iTemp].Value.ToString() + "];" + DataGridView[3, iTemp].Value.ToString() + "}");

                if (iTemp == loopTo)
                    BuySellListBox.AppendText("}}" + Constants.vbNewLine);


                //if (DataGridView[0, iTemp].Value.ToString() == "")
                //{
                //	if (iTemp > 0)
                //		// end of all lines, but not for first and not for last
                //		BuySellListBox.AppendText("}};" + Constants.vbNewLine);

                //	BuySellListBox.AppendText("{{{[" + DataGridView[0, iTemp].Value.ToString() + "];" + DataGridView[1, iTemp].Value.ToString() + "}}");
                //	BuySellListBox.AppendText(";{{[" + DataGridView[2, iTemp].Value.ToString() + "];" + DataGridView[3, iTemp].Value.ToString() + "}");
                //}
                //else
                //	BuySellListBox.AppendText(";{[" + DataGridView[2, iTemp].Value.ToString() + "];" + DataGridView[3, iTemp].Value.ToString() + "}");
            }

            // BuySellListBox.AppendText("}}" + Constants.vbNewLine + "}" + Constants.vbNewLine);
            BuySellListBox.AppendText("}" + Constants.vbNewLine);
            BuySellListBox.AppendText("MultiSell_end");

            TabControl1.SelectedIndex = 1; // Result page
        }

        private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 & e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    if (DataGridView[1, e.RowIndex].Value == null)
                        DataGridView[1, e.RowIndex].Value = "1";
                }
                if (e.ColumnIndex == 2)
                {
                    if (DataGridView[3, e.RowIndex].Value == null)
                        DataGridView[3, e.RowIndex].Value = "1";
                }
            }
        }

        private void ButtonQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
