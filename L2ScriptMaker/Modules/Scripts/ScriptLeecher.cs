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
	public partial class ScriptLeecher : Form
	{
		public ScriptLeecher()
		{
			InitializeComponent();
		}

		private int WordCount(string Str, string Razd = " ")
		{
			int WordCountRet = default(int);
			// Возвращает количество слов в строке

			int i;

			Str = Str.Trim();
			var loopTo = Str.Length - 1;
			for (i = 1; i <= loopTo; i++)
			{
				if ((Str.Substring(i, 1) ?? "") == (Razd ?? ""))
					WordCountRet = WordCountRet + 1;
				else if (i == Str.Length - 1)
					WordCountRet = WordCountRet + 1;
			}

			return WordCountRet;
		}

		private string WordWrap(string Str, string Symb, string Pos = "Left")
		{
			string WordWrapRet = default(string);
			// Обрезает строку вплоть до символа (либо несколькх символов) symb включительно
			// Pos может быть Left или Right. Он задает с какой стороны от символа вернуть строку

			int i;
			var loopTo = Str.Length - 1;
			for (i = 0; i <= loopTo; i++)
			{
				if ((Str.Substring(i, Symb.Length) ?? "") == (Symb ?? ""))
				{
					if ((Pos ?? "") == "Left")
						WordWrapRet = Strings.Trim(Str.Substring(0, i + Symb.Length - 1));
					else
						WordWrapRet = Strings.Trim(Str.Substring(i + Symb.Length, Str.Length - i - Symb.Length));
					return WordWrapRet;
				}
			}

			WordWrapRet = Str;
			return WordWrapRet;
		}

		private string[] Words(string Str, string Razd)
		{
			string[] WordsRet = default(string[]);
			int wCount;
			int i;
			int j = 0;
			int WordStart = 0;
			string[] tWords;

			wCount = WordCount(Str, Razd);

			tWords = new string[wCount + 1];
			var loopTo = Str.Length - 1;
			for (i = 1; i <= loopTo; i++)
			{
				if ((Str.Substring(i, 1) ?? "") == (Razd ?? "") | Str.Length - 1 == i)
				{
					j = j + 1;
					if (i == Str.Length - 1)
					{
						if (WordStart == i)
						{
						}
						else
							tWords[j] = Str.Substring(WordStart, i - WordStart + 1);
					}
					else if (i == WordStart)
					{
					}
					else
						tWords[j] = Str.Substring(WordStart, i - WordStart);
					WordStart = i + 1;
				}
			}

			WordsRet = tWords;
			return WordsRet;
		}


		public Skills S;

		public Skills S2;

		private void textSource_DoubleClick(object sender, EventArgs e)
		{
			Open.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
			if (Open.ShowDialog() == DialogResult.OK)
			{
				textSource.Text = Open.FileName;

				System.IO.StreamReader F;
				string Str;
				string[] W;
				int i;

				F = System.IO.File.OpenText(textSource.Text);

				ID.Items.Clear();
				Level.Items.Clear();
				ID.Text = "";
				Level.Text = "";

				Str = F.ReadLine();
				W = Words(Str, Conversions.ToString((char)9));
				var loopTo = W.GetUpperBound(0);
				for (i = 1; i <= loopTo; i++)
				{
					if (W[i].Contains("="))
					{
						ID.Items.Add(WordWrap(W[i], "="));
						Level.Items.Add(WordWrap(W[i], "="));
					}
					else
					{
						ID.Items.Add("Field " + Conversions.ToString(i) + " (" + W[i] + ")");
						Level.Items.Add("Field " + Conversions.ToString(i) + " (" + W[i] + ")");
					}
				}
			}
		}

		private void bOpenSource_Click(object sender, EventArgs e)
		{
			if (System.IO.File.Exists(textSource.Text) == true)
			{
				S = new Skills();
				Form argForm = (Form)this;
				var argStatus = Status1;
				var argToolStripProgressBar = ToolStripProgressBar;
				S.LoadFile(textSource.Text, ID.SelectedIndex + 1, Level.SelectedIndex + 1, ref argForm, ref argStatus, ref argToolStripProgressBar);
			}
		}

		private void bSave_Click(object sender, EventArgs e)
		{
			Form argForm = (Form)this;
			var argStatus = Status1;
			var argToolStripProgressBar = ToolStripProgressBar;
			S.Save(textSave.Text, ref argForm, ref argStatus, ref argToolStripProgressBar);
		}

		private void textSave_DoubleClick(object sender, EventArgs e)
		{
			if (Open.ShowDialog() == DialogResult.OK)
				textSave.Text = Open.FileName;
		}


		private void bLoadObraz_Click(object sender, EventArgs e)
		{
			if (System.IO.File.Exists(textSource.Text) == true)
			{
				S2 = new Skills();
				Form argForm = (Form)this;
				var argStatus = Status1;
				var argToolStripProgressBar = ToolStripProgressBar;
				S2.LoadFile(textSource.Text, ID.SelectedIndex + 1, Level.SelectedIndex + 1, ref argForm, ref argStatus, ref argToolStripProgressBar);
			}
		}

		private void rIname_CheckedChanged(object sender, EventArgs e)
		{
			cGrid.Rows.Clear();

			if (rIname.Checked == true)
				S.FillConvertCombo(Skills.FillComboModes.ByName, sParameter);
			else
				S.FillConvertCombo(Skills.FillComboModes.ByNumber, sParameter);
		}

		private void rInumber_CheckedChanged(object sender, EventArgs e)
		{
			cGrid.Rows.Clear();

			if (rIname.Checked == true)
				S.FillConvertCombo(Skills.FillComboModes.ByName, sParameter);
			else
				S.FillConvertCombo(Skills.FillComboModes.ByNumber, sParameter);
		}

		private void rOname_CheckedChanged(object sender, EventArgs e)
		{
			cGrid.Rows.Clear();

			if (rOname.Checked == true)
				S2.FillConvertCombo(Skills.FillComboModes.ByName, oParameter);
			else
				S2.FillConvertCombo(Skills.FillComboModes.ByNumber, oParameter);
		}

		private void rOnumber_CheckedChanged(object sender, EventArgs e)
		{
			cGrid.Rows.Clear();

			if (rOname.Checked == true)
				S2.FillConvertCombo(Skills.FillComboModes.ByName, oParameter);
			else
				S2.FillConvertCombo(Skills.FillComboModes.ByNumber, oParameter);
		}

		private void bCompute_Click(object sender, EventArgs e)
		{
			int i;
			int j;
			Skills.FillComboModes oMode;
			Skills.FillComboModes sMode;
			var loopTo = cGrid.Rows.Count - 2 // бляцтво
			;
			for (i = 0; i <= loopTo; i++)
			{
				var loopTo1 = sParameter.Items.Count - 1;
				for (j = 0; j <= loopTo1; j++)
				{
					if ((cGrid.Rows[i].Cells[0].Value.ToString() ?? "") == (sParameter.Items[j].ToString() ?? ""))
					{
						cGrid.Rows[i].Cells[2].Value = j + 1;
						break;
					}
				}

				var loopTo2 = oParameter.Items.Count - 1;
				for (j = 0; j <= loopTo2; j++)
				{
					if ((cGrid.Rows[i].Cells[1].Value.ToString() ?? "") == (oParameter.Items[j].ToString() ?? ""))
					{
						cGrid.Rows[i].Cells[3].Value = j + 1;
						break;
					}
				}
			}

			if (rIname.Checked == true)
				sMode = Skills.FillComboModes.ByName;
			else
				sMode = Skills.FillComboModes.ByNumber;

			if (rOname.Checked == true)
				oMode = Skills.FillComboModes.ByName;
			else
				oMode = Skills.FillComboModes.ByNumber;
			var argGrid = cGrid;
			Form argForm = (Form)this;
			var argStatus = Status1;
			S.ConvertParameters(ref argGrid, ref S2, sMode, oMode, ref argForm, ref argStatus);
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			Form.ActiveForm.Dispose();
		}
	}

	//static class Main2
	//{
	//	public struct Forms
	//	{
	//		internal ScriptLeecher Cont;
	//	}

	//	public static Forms F;

	//	public static void Main()
	//	{
	//		F.Cont = new ScriptLeecher();

	//		F.Cont.ShowDialog();
	//	}
	//}

	public class Skill
	{
		private int WordCount(string Str, string Razd = " ")
		{
			int WordCountRet = default(int);
			// Возвращает количество слов в строке

			int i;

			Str = Str.Trim();
			var loopTo = Str.Length - 1;
			for (i = 1; i <= loopTo; i++)
			{
				if ((Str.Substring(i, 1) ?? "") == (Razd ?? ""))
					WordCountRet = WordCountRet + 1;
				else if (i == Str.Length - 1)
					WordCountRet = WordCountRet + 1;
			}

			return WordCountRet;
		}

		private string WordWrap(string Str, string Symb, string Pos = "Left")
		{
			string WordWrapRet = default(string);
			// Обрезает строку вплоть до символа (либо несколькх символов) symb включительно
			// Pos может быть Left или Right. Он задает с какой стороны от символа вернуть строку

			int i;
			var loopTo = Str.Length - 1;
			for (i = 0; i <= loopTo; i++)
			{
				if ((Str.Substring(i, Symb.Length) ?? "") == (Symb ?? ""))
				{
					if ((Pos ?? "") == "Left")
						WordWrapRet = Strings.Trim(Str.Substring(0, i + Symb.Length - 1));
					else
						WordWrapRet = Strings.Trim(Str.Substring(i + Symb.Length, Str.Length - i - Symb.Length));
					return WordWrapRet;
				}
			}

			WordWrapRet = Str;
			return WordWrapRet;
		}

		private string[] Words(string Str, string Razd)
		{
			string[] WordsRet = default(string[]);
			int wCount;
			int i;
			int j = 0;
			int WordStart = 0;
			string[] tWords;

			wCount = WordCount(Str, Razd);

			tWords = new string[wCount + 1];
			var loopTo = Str.Length - 1;
			for (i = 1; i <= loopTo; i++)
			{
				if ((Str.Substring(i, 1) ?? "") == (Razd ?? "") | Str.Length - 1 == i)
				{
					j = j + 1;
					if (i == Str.Length - 1)
					{
						if (WordStart == i)
						{
						}
						else
							tWords[j] = Str.Substring(WordStart, i - WordStart + 1);
					}
					else if (i == WordStart)
					{
					}
					else
						tWords[j] = Str.Substring(WordStart, i - WordStart);
					WordStart = i + 1;
				}
			}

			WordsRet = tWords;
			return WordsRet;
		}


		private string sString;

		private int IDfield;
		private int Levelfield;

		private struct Mass
		{
			internal int FieldsCount;
			internal string[] FieldsNames;
			internal string[] FieldsValues;
		}

		private Mass M;

		public Skill(string Str, int skillID, int skillLevel)
		{
			IDfield = skillID;
			Levelfield = skillLevel;
			FileString = Str;
		}

		private void AnalyseString(string Str, int ID, int Level)
		{
			string[] W;
			int i;

			Str = Str.Replace(" ", "").Replace(Conversions.ToString((char)9) + Conversions.ToString((char)9), Conversions.ToString((char)9));
			W = Words(Str, Conversions.ToString((char)9));

			IDfield = ID;
			Levelfield = Level;

			M.FieldsCount = W.GetUpperBound(0);
			M.FieldsNames = new string[M.FieldsCount + 1];
			M.FieldsValues = new string[M.FieldsCount + 1];
			var loopTo = M.FieldsCount;
			for (i = 1; i <= loopTo; i++)
			{
				if (W[i].Contains("=") == true)
				{
					M.FieldsNames[i] = WordWrap(W[i], "=", "Left");
					M.FieldsValues[i] = WordWrap(W[i], "=", "Right");
				}
				else
				{
					M.FieldsNames[i] = "Field " + Conversions.ToString(i);
					M.FieldsValues[i] = W[i];
				}
			}
		}

		public string FileString
		{
			get
			{
				string FileStringRet = default(string);
				FileStringRet = sString;
				return FileStringRet;
			}
			set
			{
				sString = value;
				AnalyseString(sString, IDfield, Levelfield);
			}
		}

		public int FieldsCount
		{
			get
			{
				int FieldsCountRet = default(int);
				FieldsCountRet = M.FieldsCount;
				return FieldsCountRet;
			}
		}

		public string get_FieldValue(int Num)
		{
			string FieldValueRet = default(string);
			if (Num > M.FieldsCount)
				FieldValueRet = "";
			else
				FieldValueRet = M.FieldsValues[Num];
			return FieldValueRet;
		}

		public void set_FieldValue(int Num, string value)
		{
			if (Num < M.FieldsCount)
				M.FieldsValues[Num] = value;
		}

		public string get_FieldValue(string Name)
		{
			string FieldValueRet = default(string);
			int i;
			FieldValueRet = "";
			var loopTo = M.FieldsCount;
			for (i = 1; i <= loopTo; i++)
			{
				if ((M.FieldsNames[i] ?? "") == (Name ?? ""))
				{
					FieldValueRet = M.FieldsValues[i];
					break;
				}
			}

			return FieldValueRet;
		}

		public void set_FieldValue(string Name, string value)
		{
			int i;
			var loopTo = M.FieldsCount;
			for (i = 1; i <= loopTo; i++)
			{
				if ((M.FieldsNames[i] ?? "") == (Name ?? ""))
				{
					M.FieldsValues[i] = value;
					break;
				}
			}
		}


		public string get_FieldName(int Num)
		{
			string FieldNameRet = default(string);
			if (Num > M.FieldsCount)
				FieldNameRet = "";
			else
				FieldNameRet = M.FieldsNames[Num];
			return FieldNameRet;
		}

		public void set_FieldName(int Num, string value)
		{
			if (Num < M.FieldsCount)
				M.FieldsNames[Num] = value;
		}

		public string GetString()
		{
			string GetStringRet = default(string);
			int i;
			string Str = "";
			var loopTo = M.FieldsCount;
			for (i = 1; i <= loopTo; i++)
			{
				if (get_FieldName(i).Length >= 5)
				{
					if ((get_FieldName(i).Substring(0, 5) ?? "") == "Field")
						Str = Str + get_FieldValue(i);
					else
						Str = Str + get_FieldName(i) + "=" + get_FieldValue(i);
				}
				else
					Str = Str + get_FieldName(i) + "=" + get_FieldValue(i);
				if (i < M.FieldsCount)
					Str = Str + Conversions.ToString((char)9);
			}

			GetStringRet = Str;
			return GetStringRet;
		}

		public int ID
		{
			get
			{
				int IDRet = default(int);
				if (IDfield > 0)
					IDRet = Conversions.ToInteger(M.FieldsValues[IDfield]);
				else
					IDRet = 0;
				return IDRet;
			}
		}

		public int Level
		{
			get
			{
				int LevelRet = default(int);
				if (Levelfield > 0)
					LevelRet = Conversions.ToInteger(M.FieldsValues[Levelfield]);
				else
					LevelRet = 0;
				return LevelRet;
			}
		}
	}

	public class Skills
	{
		private Skill[] pSkills;

		private struct skillID
		{
			public int ID;
			public int Level;
		}

		public enum FillComboModes
		{
			ByNumber = 1,
			ByName = 2
		}

		private skillID sID;

		private int[] skillIDsLevels;

		private int[,] Idx = new int[1, 1];

		public void LoadFile(string Path, int ID, int Level, ref Form Form, ref ToolStripStatusLabel Status, ref ToolStripProgressBar ToolStripProgressBar)
		{
			System.IO.StreamReader F;
			string Str = null;
			var sCount = default(int);
			int i;
			int j;
			var D1 = default(int);
			var D2 = default(int);
			var CurP = default(int);
			string Points;

			F = System.IO.File.OpenText(Path);

			sID.ID = ID;
			sID.Level = Level;

			ToolStripProgressBar.Maximum = Conversions.ToInteger(F.BaseStream.Length);
			ToolStripProgressBar.Value = 0;

			while (!F.EndOfStream)
			{
				try
				{
					Str = F.ReadLine();
				}
				catch (Exception ex)
				{
					MessageBox.Show("File reading error. Line :" + Conversions.ToString(sCount) + Constants.vbNewLine + Str, "File error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					ToolStripProgressBar.Value = 0;
					F.Close();
					return;
				}
				ToolStripProgressBar.Value = Conversions.ToInteger(F.BaseStream.Position);

				try
				{
					if (Str.StartsWith("//") == false & !string.IsNullOrEmpty(Str.Trim()))
					{
						sCount = sCount + 1;
						var oldPSkills = pSkills;
						pSkills = new Skill[sCount + 1];
						if (oldPSkills != null)
							Array.Copy(oldPSkills, pSkills, Math.Min(sCount + 1, oldPSkills.Length));
						pSkills[sCount] = new Skill(Str, ID, Level);
						if (D1 < Conversions.ToInteger(pSkills[sCount].get_FieldValue(ID)))
							D1 = Conversions.ToInteger(pSkills[sCount].get_FieldValue(ID));
						if (D2 < Conversions.ToInteger(pSkills[sCount].get_FieldValue(Level)))
							D2 = Conversions.ToInteger(pSkills[sCount].get_FieldValue(Level));
						if (sCount / (double)300 == Conversions.ToInteger(sCount / (double)300))
						{
							CurP = CurP + 1;
							if (CurP == 5)
								CurP = 0;
							Points = "";
							var loopTo = CurP;
							for (i = 0; i <= loopTo; i++)
								Points = Points + ".";
							Status.Text = "Loading file" + Points;
							Form.Update();
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error data conversion. Line Structure must be same like first line. Commentaries existing? Line :" + Conversions.ToString(sCount) + Constants.vbNewLine + Str, "Structure error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					ToolStripProgressBar.Value = 0;
					F.Close();
					return;
				}
			}

			ToolStripProgressBar.Value = 0;
			F.Close();

			Idx = new int[D1 + 1, D2 + 1];
			skillIDsLevels = new int[D1 + 1];
			var loopTo1 = pSkills.GetUpperBound(0);
			for (i = 1; i <= loopTo1; i++)
			{
				Idx[Conversions.ToInteger(pSkills[i].get_FieldValue(ID)), Conversions.ToInteger(pSkills[i].get_FieldValue(Level))] = i;
				if (skillIDsLevels[Conversions.ToInteger(pSkills[i].get_FieldValue(ID))] < Conversions.ToDouble(pSkills[i].get_FieldValue(Level)))
					skillIDsLevels[Conversions.ToInteger(pSkills[i].get_FieldValue(ID))] = Conversions.ToInteger(pSkills[i].get_FieldValue(Level));
				if (i / (double)300 == Conversions.ToInteger(i / (double)300))
				{
					if (CurP == 5)
						CurP = 0;
					Points = "";
					var loopTo2 = CurP;
					for (j = 0; j <= loopTo2; j++)
						Points = Points + ".";
					Status.Text = "Loading file" + Points;
					Form.Update();
				}
			}

			Status.Text = "Ready";
			Form.Update();
		}

		public int Count
		{
			get
			{
				int CountRet = default(int);
				CountRet = pSkills.GetUpperBound(0);
				return CountRet;
			}
		}

		public Skill get_SkillByID(int ID, int Level)
		{
			Skill SkillByIDRet = default(Skill);
			SkillByIDRet = null;
			if (ID <= Idx.GetUpperBound(0))
			{
				if (Level <= Idx.GetUpperBound(1))
				{
					if (Idx[ID, Level] > 0)
						SkillByIDRet = pSkills[Idx[ID, Level]];
				}
			}

			return SkillByIDRet;
		}

		public void set_SkillByID(int ID, int Level, Skill value)
		{
			pSkills[Idx[ID, Level]] = value;
		}

		public void FillIDList(ref ComboBox List)
		{
			int i;
			int j;

			List.Items.Clear();
			var loopTo = Idx.GetUpperBound(0);
			for (i = 1; i <= loopTo; i++)
			{
				var loopTo1 = Idx.GetUpperBound(1);
				for (j = 1; j <= loopTo1; j++)
				{
					if (Idx[i, j] > 0)
					{
						List.Items.Add(i);
						break;
					}
				}
			}
		}

		public void FillLevelList(ref ComboBox List, int ID)
		{
			int i;

			List.Items.Clear();
			var loopTo = skillIDsLevels[ID];
			for (i = 1; i <= loopTo; i++)
				List.Items.Add(i);
		}

		private void AddSkillToGrid(ref DataGridView Grid, Skill cSkill)
		{
			int i;

			Grid.Rows.Add();
			var loopTo = cSkill.FieldsCount;
			for (i = 1; i <= loopTo; i++)
				Grid.Rows[Grid.Rows.Count - 2].Cells[i - 1].Value = cSkill.get_FieldValue(i);
		}

		private void FillGridNames(ref DataGridView Grid, Skill cSkill)
		{
			int i;
			var loopTo = cSkill.FieldsCount;
			for (i = 1; i <= loopTo; i++)
				Grid.Columns.Add(cSkill.get_FieldName(i), cSkill.get_FieldName(i));
		}

		public void FillGridID(ref DataGridView Grid, int ID, int Level = 0)
		{
			int i;

			Grid.Rows.Clear();
			Grid.Columns.Clear();

			if (Level == 0)
			{
				var loopTo = Idx.GetUpperBound(1);
				for (i = 1; i <= loopTo; i++)
				{
					if (Idx[ID, i] > 0)
					{
						FillGridNames(ref Grid, pSkills[Idx[ID, i]]);
						break;
					}
				}
			}
			else
				FillGridNames(ref Grid, pSkills[Idx[ID, Level]]);

			if (Level == 0)
			{
				var loopTo1 = Idx.GetUpperBound(1);
				for (i = 1; i <= loopTo1; i++)
				{
					if (Idx[ID, i] > 0)
						AddSkillToGrid(ref Grid, pSkills[Idx[ID, i]]);
				}
			}
			else
				AddSkillToGrid(ref Grid, pSkills[Idx[ID, Level]]);
		}

		public void UpdateSkill(DataGridView Grid, int Row)
		{
			int i;
			Skill pS;

			pS = pSkills[Idx[Convert.ToInt32(Grid.Rows[Row].Cells[sID.ID - 1].Value), Convert.ToInt32(Grid.Rows[Row].Cells[sID.Level - 1].Value)]];
			var loopTo = pS.FieldsCount;
			for (i = 1; i <= loopTo; i++)
				pS.set_FieldValue(i, Convert.ToString(Grid.Rows[Row].Cells[i - 1].Value));
		}

		public void Save(string Path, ref Form Form, ref ToolStripStatusLabel Status, ref ToolStripProgressBar ToolStripProgressBar)
		{
			System.IO.StreamWriter F2;
			int i;
			int j;
			var CurP = default(int);
			string Points;

			F2 = new System.IO.StreamWriter(Path, false, System.Text.Encoding.Unicode, 1);

			Status.Text = "Saving file";
			Form.Update();

			ToolStripProgressBar.Value = 0;
			ToolStripProgressBar.Maximum = Count;
			var loopTo = Count;
			for (i = 1; i <= loopTo; i++)
			{
				F2.WriteLine(pSkills[i].GetString());
				ToolStripProgressBar.Value = i;
				if (i / (double)300 == Conversions.ToInteger(i / (double)300))
				{
					if (CurP == 5)
						CurP = 0;
					Points = "";
					var loopTo1 = CurP;
					for (j = 0; j <= loopTo1; j++)
						Points = Points + ".";
					Status.Text = "Saving file" + Points;
					Form.Update();
				}
			}

			F2.Close();
			ToolStripProgressBar.Value = 0;

			Status.Text = "Ready";
			Form.Update();
		}

		public void Search(string SearchString, ref DataGridView Grid)
		{
			int i;
			int j;
			var Res = new int[1];

			Grid.Rows.Clear();
			Grid.Columns.Clear();
			var loopTo = Count;
			for (i = 1; i <= loopTo; i++)
			{
				var loopTo1 = pSkills[i].FieldsCount;
				for (j = 1; j <= loopTo1; j++)
				{
					if (pSkills[i].get_FieldValue(j).Contains(SearchString))
					{
						var oldRes = Res;
						Res = new int[Res.GetUpperBound(0) + 1 + 1];
						if (oldRes != null)
							Array.Copy(oldRes, Res, Math.Min(Res.GetUpperBound(0) + 1 + 1, oldRes.Length));
						Res[Res.GetUpperBound(0)] = i;
						break;
					}
				}
			}

			if (Res.GetUpperBound(0) > 0)
				FillGridMass(Res, ref Grid);
		}

		private void FillGridMass(int[] Mass, ref DataGridView Grid)
		{
			int i;
			int MaxCount = 0;
			var loopTo = Mass.GetUpperBound(0);
			for (i = 1; i <= loopTo; i++)
			{
				if (pSkills[Mass[i]].FieldsCount > MaxCount)
					MaxCount = pSkills[Mass[i]].FieldsCount;
			}

			var loopTo1 = MaxCount;
			for (i = 1; i <= loopTo1; i++)
				Grid.Columns.Add("Field" + Conversions.ToString(i), "Field " + Conversions.ToString(i));
			var loopTo2 = Mass.GetUpperBound(0);
			for (i = 1; i <= loopTo2; i++)
				AddSkillToGrid(ref Grid, pSkills[Mass[i]]);
		}

		public void FillConvertCombo(FillComboModes Mode, DataGridViewComboBoxColumn Combo)
		{
			int i;
			int j;
			int k;
			var Str = new string[1];
			var Flag = default(bool);
			int MinFieldCount = 1000000;

			Combo.Items.Clear();

			if ((int)Mode == (int)FillComboModes.ByName)
			{
				var loopTo = pSkills.GetUpperBound(0);
				for (i = 1; i <= loopTo; i++)
				{
					var loopTo1 = pSkills[i].FieldsCount;
					for (j = 1; j <= loopTo1; j++)
					{
						if (pSkills[i].get_FieldName(j).Length >= 5)
						{
							if ((pSkills[i].get_FieldName(j).Substring(0, 5) ?? "") != "Field")
							{
								if (Str.GetUpperBound(0) > 0)
								{
									var loopTo2 = Str.GetUpperBound(0);
									for (k = 1; k <= loopTo2; k++)
									{
										Flag = false;
										if ((pSkills[i].get_FieldName(j) ?? "") == (Str[k] ?? ""))
										{
											Flag = true;
											break;
										}
									}
									if (Flag == false)
									{
										var oldStr = Str;
										Str = new string[Str.GetUpperBound(0) + 1 + 1];
										if (oldStr != null)
											Array.Copy(oldStr, Str, Math.Min(Str.GetUpperBound(0) + 1 + 1, oldStr.Length));
										Str[Str.GetUpperBound(0)] = pSkills[i].get_FieldName(j);
									}
								}
								else
								{
									var oldStr1 = Str;
									Str = new string[Str.GetUpperBound(0) + 1 + 1];
									if (oldStr1 != null)
										Array.Copy(oldStr1, Str, Math.Min(Str.GetUpperBound(0) + 1 + 1, oldStr1.Length));
									Str[Str.GetUpperBound(0)] = pSkills[i].get_FieldName(j);
								}
							}
						}
					}
				}

				var loopTo3 = Str.GetUpperBound(0);
				for (i = 1; i <= loopTo3; i++)
					Combo.Items.Add(Str[i]);
			}

			if ((int)Mode == (int)FillComboModes.ByNumber)
			{
				var loopTo4 = pSkills.GetUpperBound(0);
				for (i = 1; i <= loopTo4; i++)
				{
					if (pSkills[i].FieldsCount < MinFieldCount)
						MinFieldCount = pSkills[i].FieldsCount;
				}

				var loopTo5 = MinFieldCount;
				for (i = 1; i <= loopTo5; i++)
					Combo.Items.Add("Field" + Conversions.ToString(i) + " (" + pSkills[1].get_FieldValue(i) + ")");
			}
		}

		public void ConvertParameters(ref DataGridView Grid, ref Skills S, FillComboModes SourceMode, FillComboModes ObrazMode, ref Form Form, ref ToolStripStatusLabel Status)
		{
			int i;
			int j;
			int k;
			var SourceField = default(int);
			var ObrazField = default(int);
			Skill tempSkill;
			var CurP = default(int);
			string Points;

			Status.Text = "Parameter analyzing";
			Form.Update();
			var loopTo = pSkills.GetUpperBound(0);
			for (i = 1; i <= loopTo; i++)
			{
				if (S.get_SkillByID(pSkills[i].ID, pSkills[i].Level) == null)
				{
				}
				else if (string.IsNullOrEmpty(pSkills[i].FileString) | (Strings.Trim(pSkills[i].FileString).Substring(0, 2) ?? "") == "//")
				{
				}
				else
				{
					var loopTo1 = Grid.Rows.Count - 2;
					for (j = 0; j <= loopTo1; j++)
					{
						if ((int)SourceMode == (int)FillComboModes.ByName)
						{
							SourceField = 0;
							var loopTo2 = pSkills[i].FieldsCount;
							for (k = 1; k <= loopTo2; k++)
							{
								if ((Convert.ToString(pSkills[i].get_FieldName(k)) ?? "") == (Convert.ToString(Grid.Rows[j].Cells[0].Value) ?? ""))
								{
									SourceField = k;
									break;
								}
							}
						}
						else if ((int)SourceMode == (int)FillComboModes.ByNumber)
						{
							if (pSkills[i].FieldsCount < Convert.ToDouble(Grid.Rows[j].Cells[2].Value))
								SourceField = 0;
							else
								SourceField = Convert.ToInt32(Grid.Rows[j].Cells[2].Value);
						}
						if (SourceField > 0)
						{
							tempSkill = S.get_SkillByID(pSkills[i].ID, pSkills[i].Level);
							if ((int)ObrazMode == (int)FillComboModes.ByName)
							{
								ObrazField = 0;
								var loopTo3 = tempSkill.FieldsCount;
								for (k = 1; k <= loopTo3; k++)
								{
									if ((tempSkill.get_FieldName(k) ?? "") == (Convert.ToString(Grid.Rows[j].Cells[1].Value) ?? ""))
									{
										ObrazField = k;
										break;
									}
								}
							}
							else if ((int)ObrazMode == (int)FillComboModes.ByNumber)
							{
								if (tempSkill.FieldsCount < Convert.ToInt32(Grid.Rows[j].Cells[3].Value))
									ObrazField = 0;
								else
									ObrazField = Convert.ToInt32(Grid.Rows[j].Cells[3].Value);
							}
							if (ObrazField > 0)
								pSkills[i].set_FieldValue(SourceField, tempSkill.get_FieldValue(ObrazField));
						}
					}
				}
				if (i / (double)300 == Convert.ToInt32(i / (double)300))
				{
					if (CurP == 5)
						CurP = 0;
					Points = "";
					var loopTo4 = CurP;
					for (j = 0; j <= loopTo4; j++)
						Points = Points + ".";
					Status.Text = "Parameter analyzing" + Points;
					Form.Update();
				}
			}

			Status.Text = "Ready";
			Form.Update();
		}
	}
}
