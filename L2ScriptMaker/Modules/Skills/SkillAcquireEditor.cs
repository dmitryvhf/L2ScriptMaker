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

namespace L2ScriptMaker.Modules.Skills
{
	public partial class SkillAcquireEditor : Form
	{
		public SkillAcquireEditor()
		{
			InitializeComponent();
		}


		// fighter_begin
		// skill_begin	/* [럭키] */	skill_name = [s_lucky]	get_lv = 1	lv_up_sp = 0	auto_get = true	item_needed = {}	skill_end
		// skill_begin	/* [엑스퍼티즈 D] */	skill_name = [s_expertise_d]	get_lv = 20	lv_up_sp = 0	auto_get = true	item_needed = {}	skill_end
		// fighter_end
		// include_fighter	


		private bool UpdateCell = true;

		private int PrevSelClass = -1;

		private string[] ItemPch = new string[1];
		private string[] SkillPch = new string[1];

		private struct SkillAcquire
		{
			public string skill_name;
			public int get_lv;
			public int lv_up_sp;
			public bool auto_get;
			public string item_needed1;
			public int item_needed1_value;
			public string item_needed2;
			public int item_needed2_value;
			public string note;
		}

		private int[] ClassAmount = new int[101];
		private string[] ClassInherits = new string[101];
		private SkillAcquire[,] Skillss = new SkillAcquire[101, 1001]; // (1 - number of class's, 2 - amount skills in class)

		private bool LoadAcquire(int Number)
		{
			int iTemp;
			if (PrevSelClass == -1)
				return false;

			DataGridView.Rows.Clear();
			var loopTo = ClassAmount[Number];
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				DataGridView.Rows.Add();

				if (Skillss[Number, iTemp].skill_name != null)
					DataGridView[0, iTemp].Value = Skillss[Number, iTemp].skill_name;
				else
					DataGridView[0, iTemp].Value = skill_name.Items[0].ToString();
				if (Skillss[Number, iTemp].get_lv > 0)
					DataGridView[1, iTemp].Value = Skillss[Number, iTemp].get_lv;
				else
					DataGridView[1, iTemp].Value = 0;
				if (Skillss[Number, iTemp].lv_up_sp > 0)
					DataGridView[2, iTemp].Value = Skillss[Number, iTemp].lv_up_sp;
				else
					DataGridView[2, iTemp].Value = 0;
				if (Skillss[Number, iTemp].auto_get == false | Skillss[Number, iTemp].auto_get == true)
					DataGridView[3, iTemp].Value = Skillss[Number, iTemp].auto_get.ToString();
				else
					DataGridView[3, iTemp].Value = "False";
				if (Skillss[Number, iTemp].item_needed1 != null)
					DataGridView[4, iTemp].Value = Skillss[Number, iTemp].item_needed1;
				else
					DataGridView[4, iTemp].Value = null;
				if (Skillss[Number, iTemp].item_needed1_value != default(int))
					DataGridView[5, iTemp].Value = Skillss[Number, iTemp].item_needed1_value;
				else
					DataGridView[5, iTemp].Value = null;
				if (Skillss[Number, iTemp].item_needed2 != null)
					DataGridView[6, iTemp].Value = Skillss[Number, iTemp].item_needed2;
				else
					DataGridView[6, iTemp].Value = null;
				if (Skillss[Number, iTemp].item_needed2_value != default(int))
					DataGridView[7, iTemp].Value = Skillss[Number, iTemp].item_needed2_value;
				else
					DataGridView[7, iTemp].Value = null;

				if (!string.IsNullOrEmpty(Skillss[Number, iTemp].note))
					DataGridView[8, iTemp].Value = Skillss[Number, iTemp].note;
				else
					DataGridView[8, iTemp].Value = null;
			}

			if (AutoSortCheckBox.Checked == true)
				DataGridView.Sort(DataGridView.Columns[DataGridView.Columns[AutoSortComboBox.Text].Name], System.ComponentModel.ListSortDirection.Ascending);
			return default(bool);
		}

		private bool SaveAcquire(int Number)
		{
			int iTemp;

			if (PrevSelClass == -1)
				return false;


			ClassAmount[Number] = DataGridView.Rows.Count - 2;
			var loopTo = DataGridView.Rows.Count - 2;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				try
				{
					Skillss[Number, iTemp].skill_name = DataGridView[0, iTemp].Value.ToString();
				}
				catch (Exception ex)
				{
					Skillss[Number, iTemp].skill_name = skill_name.Items[0].ToString();
				}
				try
				{
					Skillss[Number, iTemp].get_lv = Convert.ToInt32(DataGridView[1, iTemp].Value);
				}
				catch (Exception ex)
				{
					Skillss[Number, iTemp].get_lv = 0;
				}
				try
				{
					Skillss[Number, iTemp].lv_up_sp = Convert.ToInt32(DataGridView[2, iTemp].Value);
				}
				catch (Exception ex)
				{
					Skillss[Number, iTemp].lv_up_sp = 0;
				}
				try
				{
					Skillss[Number, iTemp].auto_get = Convert.ToBoolean(DataGridView[3, iTemp].Value);
				}
				catch (Exception ex)
				{
					Skillss[Number, iTemp].auto_get = false;
				}
				try
				{
					Skillss[Number, iTemp].item_needed1 = DataGridView[4, iTemp].Value.ToString();
				}
				catch (Exception ex)
				{
					Skillss[Number, iTemp].item_needed1 = null;
				}
				try
				{
					Skillss[Number, iTemp].item_needed1_value = Convert.ToInt32(DataGridView[5, iTemp].Value);
				}
				catch (Exception ex)
				{
					Skillss[Number, iTemp].item_needed1_value = default(int);
				}

				try
				{
					Skillss[Number, iTemp].item_needed2 = DataGridView[6, iTemp].Value.ToString();
				}
				catch (Exception ex)
				{
					Skillss[Number, iTemp].item_needed2 = null;
				}
				try
				{
					Skillss[Number, iTemp].item_needed2_value = Convert.ToInt32(DataGridView[7, iTemp].Value);
				}
				catch (Exception ex)
				{
					Skillss[Number, iTemp].item_needed2_value = default(int);
				}

				try
				{
					Skillss[Number, iTemp].note = DataGridView[8, iTemp].Value.ToString();
				}
				catch (Exception ex)
				{
					Skillss[Number, iTemp].note = "";
				}
			}

			return default(bool);
		}

		private void ClassListBox_SelectedValueChanged(object sender, EventArgs e)
		{
			if (PrevSelClass != -1 & PrevSelClass != ClassListBox.SelectedIndex)
			{
				SaveAcquire(PrevSelClass);
				PrevSelClass = ClassListBox.SelectedIndex;
				LoadAcquire(PrevSelClass);
				InheritsComboBox.Text = ClassInherits[PrevSelClass];
			}
		}

		private void SkillAquireEditor_Load(object sender, EventArgs e)
		{
			PrevSelClass = -1;

			this.Show();

			string sTemp;

			sTemp = "skill_pch.txt";
			if (System.IO.File.Exists("skill_pch.txt") == false)
			{
				OpenFileDialog.Title = "Select skill_pch file...";
				OpenFileDialog.Filter = "Lineage II Server skill definition config|skill_pch.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				{
					this.Dispose(); return;
				}
				sTemp = OpenFileDialog.FileName;
			}
			SkillPchLoad(sTemp);

			sTemp = "item_pch.txt";
			if (System.IO.File.Exists(sTemp) == false)
			{
				OpenFileDialog.Title = "Select Item_pch file...";
				OpenFileDialog.Filter = "Lineage II Server item definition config|item_pch.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				{
					this.Dispose(); return;
				}
				sTemp = OpenFileDialog.FileName;
			}
			ItemPchLoad(sTemp);

			ClassListBox.SelectedIndex = 0;
			PrevSelClass = 0;

			DataGridView.Rows.Clear();
			DataGridView.Rows.Add();
			ClassAmount[0] = 0;
			UpdateCell = false;
		}

		private void LoadSkillAcquireButton_Click(object sender, EventArgs e)
		{

			// Dim ClassAmount(100) As Integer
			// Dim ClassInherits(100) As String
			// Dim Skillss(100, 100) As SkillAcquire ' (1 - number of class's, 2 - amount skills in class)

			int iMarkerInClass = -1;
			string sTemp;
			string sTemp2;
			int iTemp;

			Array.Clear(ClassAmount, 0, ClassAmount.Length);
			Array.Clear(ClassInherits, 0, ClassInherits.Length);
			Array.Clear(Skillss, 0, Skillss.Length);

			OpenFileDialog.Filter = "Lineage II server skills learn script (skillacquire.txt)|skillacquire.txt|All files|*.*";
			OpenFileDialog.FileName = "skillacquire.txt";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			InheritsComboBox.Text = "";
			ClassListBox.Items.Clear();
			InheritsComboBox.Items.Clear();

			var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);

			// fighter_begin
			// skill_begin	/* [럭키] */	skill_name = [s_lucky]	get_lv = 1	lv_up_sp = 0	auto_get = true	item_needed = {}	skill_end
			// skill_begin	/* [엑스퍼티즈 D] */	skill_name = [s_expertise_d]	get_lv = 20	lv_up_sp = 0	auto_get = true	item_needed = {}	skill_end
			// fighter_end
			// include_fighter	

			string[] aTemp;


			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				if (!string.IsNullOrEmpty(sTemp.Trim()) | sTemp.StartsWith("//") == false)
				{
					if (sTemp.Trim().EndsWith("_begin") == true)
					{
						iMarkerInClass += 1;
						ClassAmount[iMarkerInClass] = -1;
						ClassListBox.Items.Add(sTemp.Trim().Replace("_begin", ""));
						InheritsComboBox.Items.Add(sTemp.Trim().Replace("_begin", ""));
					}
					if (sTemp.Trim().StartsWith("include_") == true)
						ClassInherits[iMarkerInClass] = sTemp.Trim().Replace("include_", "");
					if (sTemp.Trim().EndsWith("_end") == true & Strings.InStr(sTemp, " ") == 0)
					{
					}
					if (sTemp.Trim().StartsWith("skill_begin") == true)
					{
						// Loading skills

						ClassAmount[iMarkerInClass] += 1;
						iTemp = ClassAmount[iMarkerInClass];
						Skillss[iMarkerInClass, iTemp].skill_name = Libraries.GetNeedParamFromStr(sTemp, "skill_name");
						Skillss[iMarkerInClass, iTemp].get_lv = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "get_lv"));
						Skillss[iMarkerInClass, iTemp].lv_up_sp = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "lv_up_sp"));
						Skillss[iMarkerInClass, iTemp].auto_get = Conversions.ToBoolean(Libraries.GetNeedParamFromStr(sTemp, "auto_get"));

						sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "item_needed");
						if ((sTemp2 ?? "") == "{}")
						{
							Skillss[iMarkerInClass, iTemp].item_needed1 = null;
							Skillss[iMarkerInClass, iTemp].item_needed2 = null;
						}
						else
						{
							// item_needed = {{[sb_drain_energy1];1}}
							// item_needed = {{[sb_drain_energy1];1};{[adena];2}}
							sTemp2 = sTemp2.Replace("};{", "|").Replace("{", "").Replace("}", "");
							aTemp = sTemp2.Split(Conversions.ToChar("|"));

							// [sb_drain_energy1];1
							Skillss[iMarkerInClass, iTemp].item_needed1 = aTemp[0].Substring(0, Strings.InStr(aTemp[0], "]"));
							Skillss[iMarkerInClass, iTemp].item_needed1_value = Conversions.ToInteger(aTemp[0].Replace(Skillss[iMarkerInClass, iTemp].item_needed1 + ";", ""));


							// Skillss(iMarkerInClass, iTemp).item_needed1 = Mid(aTemp(0), InStr(aTemp(0), "["), InStr(aTemp(0), "]") - InStr(aTemp(0), "[") + 1)
							// Skillss(iMarkerInClass, iTemp).item_needed1_value = CInt(Mid(aTemp(0), InStr(aTemp(0), ";") + 1, InStr(aTemp(0), "}}") - InStr(aTemp(0), ";") - 1))

							if (aTemp.Length > 1)
							{
								// Skillss(iMarkerInClass, iTemp).item_needed2 = Mid(aTemp(1), InStr(sTemp2, "["), InStr(aTemp(1), "]") - InStr(aTemp(1), "[") + 1)
								// Skillss(iMarkerInClass, iTemp).item_needed2_value = CInt(Mid(aTemp(1), InStr(aTemp(1), ";") + 1, InStr(aTemp(1), "}}") - InStr(aTemp(1), ";") - 1))
								Skillss[iMarkerInClass, iTemp].item_needed2 = aTemp[1].Substring(0, Strings.InStr(aTemp[1], "]"));
								Skillss[iMarkerInClass, iTemp].item_needed2_value = Conversions.ToInteger(aTemp[1].Replace(Skillss[iMarkerInClass, iTemp].item_needed2 + ";", ""));
							}
						}
						Skillss[iMarkerInClass, iTemp].note = Strings.Mid(sTemp, Strings.InStr(sTemp, "/*") + 2, Strings.InStr(sTemp, "*/") - Strings.InStr(sTemp, "/*") - 2).Replace("[", "").Replace("]", "").Trim();
					}
				}
			}
			inFile.Close();

			PrevSelClass = 0;
			LoadAcquire(0);
			ClassListBox.SelectedIndex = 0;
		}

		private void SaveSkillAquireButton_Click(object sender, EventArgs e)
		{
			int iTemp;


			// Dim sTemp As String
			int iTemp2;

			SaveAcquire(PrevSelClass);

			SaveFileDialog.FileName = "skillacquire.txt";
			OpenFileDialog.Filter = "Lineage II Server skills learn script (skillacquire.txt)|*.txt|All files|*.*";
			SaveFileDialog.OverwritePrompt = true;
			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			if (System.IO.File.Exists(SaveFileDialog.FileName) == true)
				System.IO.File.Copy(SaveFileDialog.FileName, SaveFileDialog.FileName + ".bak", true);
			var outFile = new System.IO.StreamWriter(SaveFileDialog.FileName, false, System.Text.Encoding.Unicode, 1);

			outFile.WriteLine("//SkillAquire generated by L2ScriptMaker at " + Conversions.ToString(DateAndTime.Now));
			var loopTo = ClassListBox.Items.Count - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				outFile.WriteLine(ClassListBox.Items[iTemp].ToString() + "_begin");

				if (ClassInherits[iTemp] != null)
					outFile.WriteLine("include_" + ClassInherits[iTemp].ToString());
				var loopTo1 = ClassAmount[iTemp];
				for (iTemp2 = 0; iTemp2 <= loopTo1; iTemp2++)
				{

					// skill_begin	/* [모탈 블로우] */	skill_name = [s_mortal_blow33]	get_lv = 15	lv_up_sp = 1300	auto_get = false	item_needed = {}	skill_end

					outFile.Write("skill_begin" + Constants.vbTab);
					outFile.Write("/* [" + Skillss[iTemp, iTemp2].note + "] */" + Constants.vbTab);
					outFile.Write("skill_name=" + Skillss[iTemp, iTemp2].skill_name + Constants.vbTab);
					outFile.Write("get_lv=" + Conversions.ToString(Skillss[iTemp, iTemp2].get_lv) + Constants.vbTab);
					outFile.Write("lv_up_sp=" + Conversions.ToString(Skillss[iTemp, iTemp2].lv_up_sp) + Constants.vbTab);
					outFile.Write("auto_get=" + Skillss[iTemp, iTemp2].auto_get.ToString().ToLower() + Constants.vbTab);

					if (Skillss[iTemp, iTemp2].item_needed1 == null)
						outFile.Write("item_needed={}" + Constants.vbTab);
					else
					{
						// item_needed = {{[sb_drain_energy1];1}}
						outFile.Write("item_needed={");
						outFile.Write("{" + Skillss[iTemp, iTemp2].item_needed1 + ";" + Conversions.ToString(Skillss[iTemp, iTemp2].item_needed1_value) + "}");
						if (Skillss[iTemp, iTemp2].item_needed2 != null | !string.IsNullOrEmpty(Skillss[iTemp, iTemp2].item_needed2))
							outFile.Write(";{" + Skillss[iTemp, iTemp2].item_needed2 + ";" + Conversions.ToString(Skillss[iTemp, iTemp2].item_needed2_value) + "}");
						outFile.Write("}" + Constants.vbTab);
					}
					outFile.WriteLine("skill_end");
				}

				outFile.WriteLine(ClassListBox.Items[iTemp].ToString() + "_end");
			}

			outFile.Close();

			MessageBox.Show("New " + SaveFileDialog.FileName + " saved success.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void InheritsComboBox_Validated(object sender, EventArgs e)
		{
			ClassInherits[PrevSelClass] = InheritsComboBox.Text;
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
			int iTemp = -1;

			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ProgressBar.Value = 0;
			while (inFile.EndOfStream != true)
			{

				// [small_sword]	=	1
				try
				{
					sTempStr = inFile.ReadLine();
					sTempStr = sTempStr.Replace(" ", "").Replace(Conversions.ToString((char)9), ""); // .Replace("[", "").Replace("]", "")
					aTemp = sTempStr.Split(Conversions.ToChar("="));

					// ItemPch(CInt(aTemp(1))) = aTemp(0)
					iTemp += 1;
					Array.Resize(ref ItemPch, iTemp + 1);
					ItemPch[iTemp] = aTemp[0];
				}
				// item_needed.Items.Add(aTemp(0))
				catch (Exception ex)
				{
					MessageBox.Show("Import data invalid in line" + Constants.vbNewLine + sTempStr, "Import data invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
					inFile.Close();
					return false;
				}

				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position); ProgressBar.Update();
			}

			// item_needed.Items.Contains(ItemPch)
			item_needed1.Items.AddRange(ItemPch);
			item_needed2.Items.AddRange(ItemPch);

			ProgressBar.Value = 0;
			inFile.Close();
			return true;
		}

		private bool SkillPchLoad(string FileName)
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

			int iTemp = -1;

			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ProgressBar.Value = 0;

			while (inFile.EndOfStream != true)
			{

				// [s_power_strike11] = 769
				try
				{
					sTempStr = inFile.ReadLine();
					sTempStr = sTempStr.Replace(" ", "").Replace(Conversions.ToString((char)9), ""); // .Replace("[", "").Replace("]", "")
					aTemp = sTempStr.Split(Conversions.ToChar("="));

					// SkillPch(CInt(aTemp(1))) = aTemp(0)
					iTemp += 1;
					Array.Resize(ref SkillPch, iTemp + 1);
					SkillPch[iTemp] = aTemp[0];
				}
				// skill_name.Items.Add(aTemp(0))
				catch (Exception ex)
				{
					MessageBox.Show("Import data invalid in line" + Constants.vbNewLine + sTempStr, "Import data invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
					inFile.Close();
					return false;
				}

				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position); ProgressBar.Update();
			}

			// skill_name.Items.Contains(SkillPch)
			skill_name.Items.AddRange(SkillPch);

			ProgressBar.Value = 0;
			inFile.Close();
			return true;
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void CopyPasteSkillButton_Click(object sender, EventArgs e)
		{

			// Check before pasting
			switch (CopyPasteComboBox.Text)
			{
				case "skill_name":
					{
						if (Array.IndexOf(SkillPch, CopyPasteTextBox.Text) == -1)
						{
							MessageBox.Show("Skill not found. Correct name and try again.", "Skill not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}

						break;
					}

				case "item_needed1":
					{
						if (Array.IndexOf(ItemPch, CopyPasteTextBox.Text) == -1 & !string.IsNullOrEmpty(CopyPasteTextBox.Text))
						{
							MessageBox.Show("Item not found. Correct name and try again.", "Item not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
						if ((DataGridView[5, DataGridView.CurrentRow.Index].ToString() ?? "") == "0")
							DataGridView[5, DataGridView.CurrentRow.Index].Value = "1";
						break;
					}

				case "item_needed2":
					{
						if (Array.IndexOf(ItemPch, CopyPasteTextBox.Text) == -1 & !string.IsNullOrEmpty(CopyPasteTextBox.Text))
						{
							MessageBox.Show("Item not found. Correct name and try again.", "Item not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
						if ((DataGridView[7, DataGridView.CurrentRow.Index].ToString() ?? "") == "0")
							DataGridView[7, DataGridView.CurrentRow.Index].Value = "1";
						break;
					}

				case "note":
					{
						break;
					}

				default:
					{
						CopyPasteComboBox.Text = "skill_name";
						return;
					}
			}
			// CopyPaste skill to cell
			DataGridView[DataGridView.Columns[CopyPasteComboBox.Text].Name, DataGridView.CurrentRow.Index].Value = CopyPasteTextBox.Text;
		}

		private void MoveUpButton_Click(object sender, EventArgs e)
		{

			// UP Line

			var aTemp = new object[8];
			int iTemp;

			// Load upper line to temp array
			if (DataGridView.CurrentRow.Index == 0)
				return;

			UpdateCell = true;
			for (iTemp = 0; iTemp <= 7; iTemp++)
			{
				aTemp[iTemp] = DataGridView[iTemp, DataGridView.CurrentRow.Index - 1].Value;
				DataGridView[iTemp, DataGridView.CurrentRow.Index - 1].Value = DataGridView[iTemp, DataGridView.CurrentRow.Index].Value;
				DataGridView[iTemp, DataGridView.CurrentRow.Index].Value = aTemp[iTemp];
			}
			UpdateCell = false;
		}

		private void MoveDownButton_Click(object sender, EventArgs e)
		{
			// Down Line

			var aTemp = new object[8];
			int iTemp;

			// Load upper line to temp array
			if (DataGridView.CurrentRow.Index >= DataGridView.RowCount - 2)
				return;

			UpdateCell = true;
			for (iTemp = 0; iTemp <= 7; iTemp++)
			{
				aTemp[iTemp] = DataGridView[iTemp, DataGridView.CurrentRow.Index + 1].Value;
				DataGridView[iTemp, DataGridView.CurrentRow.Index + 1].Value = DataGridView[iTemp, DataGridView.CurrentRow.Index].Value;
				DataGridView[iTemp, DataGridView.CurrentRow.Index].Value = aTemp[iTemp];
			}
			UpdateCell = false;
		}

		private void CopyUpButton_Click(object sender, EventArgs e)
		{

			// Copy UP Line

			int iTemp;

			// Load upper line to temp array
			if (DataGridView.CurrentRow.Index == 0)
				return;

			UpdateCell = true;
			for (iTemp = 0; iTemp <= 7; iTemp++)
				DataGridView[iTemp, DataGridView.CurrentRow.Index - 1].Value = DataGridView[iTemp, DataGridView.CurrentRow.Index].Value;
			UpdateCell = false;
		}

		private void CopyDownButton_Click(object sender, EventArgs e)
		{
			// Copy Down Line

			int iTemp;

			// Load upper line to temp array
			if (DataGridView.CurrentRow.Index < DataGridView.RowCount - 2)
			{
			}
			else if (DataGridView.CurrentRow.Index == DataGridView.RowCount - 2)
				DataGridView.Rows.Add();
			else
				return;

			UpdateCell = true;
			for (iTemp = 0; iTemp <= 7; iTemp++)
				DataGridView[iTemp, DataGridView.CurrentRow.Index + 1].Value = DataGridView[iTemp, DataGridView.CurrentRow.Index].Value;
			UpdateCell = false;
		}

		private void CloneUpButton_Click(object sender, EventArgs e)
		{

			// Copy UP Line
			// Load upper line to temp array
			UpdateCell = true;
			DataGridView.Rows.Insert(DataGridView.CurrentRow.Index);
			UpdateCell = true;
			int iTemp;
			for (iTemp = 0; iTemp <= 7; iTemp++)
				DataGridView[iTemp, DataGridView.CurrentRow.Index - 1].Value = DataGridView[iTemp, DataGridView.CurrentRow.Index].Value;
			UpdateCell = false;
		}

		private void CloneDownButton_Click(object sender, EventArgs e)
		{
			if (DataGridView.CurrentRow.Index > DataGridView.RowCount - 2)
				return;
			UpdateCell = true;
			DataGridView.Rows.Insert(DataGridView.CurrentRow.Index + 1);
			int iTemp;
			for (iTemp = 0; iTemp <= 7; iTemp++)
				DataGridView[iTemp, DataGridView.CurrentRow.Index + 1].Value = DataGridView[iTemp, DataGridView.CurrentRow.Index].Value;
			UpdateCell = false;
		}

		private void AddRowBeforeButton_Click(object sender, EventArgs e)
		{
			DataGridView.Rows.Insert(DataGridView.CurrentRow.Index);
		}

		private void AddDownButton_Click(object sender, EventArgs e)
		{
			if (DataGridView.CurrentRow.Index >= DataGridView.RowCount - 2)
				return;
			DataGridView.Rows.Insert(DataGridView.CurrentRow.Index + 1);
		}

		private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			// If Me.Visible = False Then Exit Sub
			if (UpdateCell == true)
				return;
			if (e.ColumnIndex == 4)
			{
				if (DataGridView[e.ColumnIndex, e.RowIndex].Value != null & DataGridView[e.ColumnIndex + 1, e.RowIndex].Value == null)
					DataGridView[e.ColumnIndex + 1, e.RowIndex].Value = "1";
			}
			if (e.ColumnIndex == 6)
			{
				if (DataGridView[e.ColumnIndex, e.RowIndex].Value != null & DataGridView[e.ColumnIndex + 1, e.RowIndex].Value == null)
					DataGridView[e.ColumnIndex + 1, e.RowIndex].Value = "1";
			}
		}

		private void AutoSortCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (AutoSortCheckBox.Checked == true)
				AutoSortComboBox.Enabled = true;
			else
				AutoSortComboBox.Enabled = false;
		}
	}
}
