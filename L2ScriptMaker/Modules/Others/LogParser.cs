using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using L2ScriptMaker.Extensions.VbCompatibleHelper;
using Microsoft.Win32;

namespace L2ScriptMaker.Modules.Others
{
	public partial class LogParser : Form
	{
		public LogParser()
		{
			InitializeComponent();
		}

		private void LoadPaths()
		{
			Main.Paths.LogIDs = Registry.GetValue(@"HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "LogIDs", "").ToString();
			Main.Paths.ItemName = Registry.GetValue(@"HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "ItemName", "").ToString();
			Main.Paths.Logs = Registry.GetValue(@"HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "Logs", "").ToString();
			Main.Paths.Skills = Registry.GetValue(@"HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "Skills", "").ToString();
			Main.Paths.Quests = Registry.GetValue(@"HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "Quests", "").ToString();
			Main.Paths.NPC = Registry.GetValue(@"HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "NPC", "").ToString();

			Main.LoadNamesOnLaunch = Registry.GetValue(@"HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "Load", "0").ToString();

			Main.MaxRows = Convert.ToInt32(Registry.GetValue(@"HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "MaxRows", 5000));
		}

		public void LoadSecFiles()
		{
			if (!string.IsNullOrEmpty(Main.Paths.ItemName))
				Main.Items = new cItems(Main.Paths.ItemName);

			if (!string.IsNullOrEmpty(Main.Paths.LogIDs))
				Main.LogIDs = new cLogIDs(Main.Paths.LogIDs);

			if (!string.IsNullOrEmpty(Main.Paths.Skills))
				Main.locSkills = new cSkills(Main.Paths.Skills);

			if (!string.IsNullOrEmpty(Main.Paths.Quests))
				Main.Quests = new cQuests(Main.Paths.Quests);

			if (!string.IsNullOrEmpty(Main.Paths.NPC))
				Main.NPC = new cNPC(Main.Paths.NPC);
		}

		private void LoadLogIDS()
		{
			if (!string.IsNullOrEmpty(Main.Paths.LogIDs))
			{
				Main.LogIDs = new cLogIDs(Main.Paths.LogIDs);
				var argCombo = cActions;
				Main.LogIDs.FillCombo(ref argCombo);
			}
		}

		public void Main2()
		{
		}




		private void textLogIDs_DoubleClick(object sender, EventArgs e)
		{
			Open.Filter = "Текстовый файл (*.txt)|*.txt";
			Open.InitialDirectory = textLogIDs.Text;
			if (Open.ShowDialog() == DialogResult.OK)
				textLogIDs.Text = Open.FileName;
		}

		private void textItemName_DoubleClick(object sender, EventArgs e)
		{
			Open.Filter = "Текстовый файл (*.txt)|*.txt";
			Open.InitialDirectory = textItemName.Text;
			if (Open.ShowDialog() == DialogResult.OK)
				textItemName.Text = Open.FileName;
		}

		private void textLogs_DoubleClick(object sender, EventArgs e)
		{
			if (System.IO.Directory.Exists(textLogs.Text) == false)
				textLogs.Text = Environment.CurrentDirectory;
			Folder.SelectedPath = textLogs.Text;
			if (Folder.ShowDialog() == DialogResult.OK)
				textLogs.Text = Folder.SelectedPath;
		}


		private void textSkillName_DoubleClick(object sender, EventArgs e)
		{
			Open.Filter = "Текстовый файл (*.txt)|*.txt";
			Open.InitialDirectory = textSkillName.Text;
			if (Open.ShowDialog() == DialogResult.OK)
				textSkillName.Text = Open.FileName;
		}

		public void textQuestName_DoubleClick(object sender, EventArgs e)
		{
			Open.Filter = "Текстовый файл (*.txt)|*.txt";
			Open.InitialDirectory = textQuestName.Text;
			if (Open.ShowDialog() == DialogResult.OK)
				textQuestName.Text = Open.FileName;
		}

		public void textNPC_DoubleClick(object sender, EventArgs e)
		{
			Open.Filter = "Текстовый файл (*.txt)|*.txt";
			Open.InitialDirectory = textNPC.Text;
			if (Open.ShowDialog() == DialogResult.OK)
				textNPC.Text = Open.FileName;
		}

		public void bSave_Click(object sender, EventArgs e)
		{
			Registry.SetValue(@"HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "LogIDs", textLogIDs.Text);
			Registry.SetValue(@"HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "ItemName", textItemName.Text);
			Registry.SetValue(@"HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "Logs", textLogs.Text);
			Registry.SetValue(@"HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "Skills", textSkillName.Text);
			Registry.SetValue(@"HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "Quests", textQuestName.Text);
			Registry.SetValue(@"HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "NPC", textNPC.Text);

			Main.Paths.LogIDs = textLogIDs.Text;
			Main.Paths.ItemName = textItemName.Text;
			Main.Paths.Logs = textLogs.Text;
			Main.Paths.Skills = textSkillName.Text;
			Main.Paths.Quests = textQuestName.Text;
			Main.Paths.NPC = textNPC.Text;

			LoadSecFiles();

			MessageBox.Show("Config's reloaded successfuly", "Reloaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void Container_Load(object sender, EventArgs e)
		{
			LoadPaths();

			Main.FillParametersString();

			Main.Logs = new cLogs();

			LoadLogIDS();

			if ((Main.LoadNamesOnLaunch ?? "") == "1")
				LoadSecFiles();

			textLogIDs.Text = Main.Paths.LogIDs;
			textItemName.Text = Main.Paths.ItemName;
			textLogs.Text = Main.Paths.Logs;
			textSkillName.Text = Main.Paths.Skills;
			textQuestName.Text = Main.Paths.Quests;
			textNPC.Text = Main.Paths.NPC;
			textMaxRows.Text = Conversions.ToString(Conversions.ToInteger(Main.MaxRows));

			if ((Main.LoadNamesOnLaunch ?? "") == "1")
				checkLoadOnLaunch.Checked = true;

			if (string.IsNullOrEmpty(textLogIDs.Text))
			{
				textLogIDs.Text = Environment.CurrentDirectory;
				Main.Paths.LogIDs = Environment.CurrentDirectory;
			}

			if (string.IsNullOrEmpty(textItemName.Text))
			{
				textItemName.Text = Environment.CurrentDirectory;
				Main.Paths.ItemName = Environment.CurrentDirectory;
			}

			if (string.IsNullOrEmpty(textLogs.Text))
			{
				textLogs.Text = Environment.CurrentDirectory;
				Main.Paths.Logs = Environment.CurrentDirectory;
			}

			Control.CheckForIllegalCrossThreadCalls = false;

			int i;
			var loopTo = Main.ParametersString.GetUpperBound(0);
			for (i = 1; i <= loopTo; i++)
				colParam.Items.Add(Main.ParametersString[i]);

			colOperation.Items.Add("=");
			colOperation.Items.Add(">");
			colOperation.Items.Add("<");
			colOperation.Items.Add("<>");
		}


		private void FillGrid()
		{
			var argCont = this;
			Main.Logs.FillGrid(ref argCont);
		}

		private void bFillGrid_Click(object sender, EventArgs e)
		{
			FillGrid();
		}

		private void InMemory_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Загрузить логи в память?", "", MessageBoxButtons.YesNo) == DialogResult.No)
				return;
			var argCont = this;
			Main.Logs.LoadInMemory(textLogs.Text, ref argCont);
			MessageBox.Show("Loaded successfuly", "Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
			tab1.SelectedIndex = 0;
		}

		private void textLogToSave_DoubleClick(object sender, EventArgs e)
		{
			Save.Filter = "Файл логов (*.log)|*.log";
			if (Save.ShowDialog() == DialogResult.OK)
				textLogToSave.Text = Save.FileName;
		}

		private void bSaveToFile_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textLogToSave.Text))
			{
				MessageBox.Show("Enter correct file name for save data and try again.", "No name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			var argCont = this;
			Main.Logs.SaveToFile(ref argCont, textLogToSave.Text);
			MessageBox.Show("Saved successfuly", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void checkLoadOnLaunch_CheckedChanged(object sender, EventArgs e)
		{
			if (checkLoadOnLaunch.Checked)
				Registry.SetValue(@"HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "Load", "1");
			else
				Registry.SetValue(@"HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "Load", "0");
		}


		private void Button1_Click(object sender, EventArgs e)
		{
			Main.MaxRows = Conversions.ToInteger(textMaxRows.Text);
			Registry.SetValue(@"HKEY_CURRENT_USER\Software\L2ScriptMaker\LogParser", "MaxRows", textMaxRows.Text);
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}

	public class cLogs
	{
		public struct Log
		{
			internal string act_time;
			internal string log_id;
			internal string actor;
			internal string actor_account;
			internal string target;
			internal string target_account;
			internal string location_x;
			internal string location_y;
			internal string location_z;
			internal string etc_str1;
			internal string etc_str2;
			internal string etc_str3;
			internal string etc_num1;
			internal string etc_num2;
			internal string etc_num3;
			internal string etc_num4;
			internal string etc_num5;
			internal string etc_num6;
			internal string etc_num7;
			internal string etc_num8;
			internal string etc_num9;
			internal string etc_num10;
			internal string STR_actor;
			internal string STR_actor_account;
			internal string STR_target;
			internal string STR_target_account;
			internal string item_id;
			internal string STR_item;
			internal string STR_action;
			internal string Str;
		}

		private string pPath;

		public Log[] L;

		private LogParser lC;

		public string[] Actions;
		public string[] Actors;
		public string[] Targets;
		// Public DBitems() As String

		private bool LogsLoaded = false;

		private CompareRow[] C;

		private struct CompareRow
		{
			internal string Parameter;
			internal string Operation;
			internal string Value;
		}

		private void UpdateMass(ref string[] Mass, string Val)
		{
			bool Update;
			int i;

			if (Val == null)
				return;

			Update = true;
			if (Mass.GetUpperBound(0) > 0)
			{
				var loopTo = Mass.GetUpperBound(0);
				for (i = 1; i <= loopTo; i++)
				{
					if ((Mass[i] ?? "") == (Val ?? ""))
					{
						Update = false;
						break;
					}
				}
			}
			if (Update == true)
			{
				var oldMass = Mass;
				Mass = new string[Mass.GetUpperBound(0) + 1 + 1];
				if (oldMass != null)
					Array.Copy(oldMass, Mass, Math.Min(Mass.GetUpperBound(0) + 1 + 1, oldMass.Length));
				Mass[Mass.GetUpperBound(0)] = Val;
			}
		}

		private void UpdateMasses(Log S)
		{
			UpdateMass(ref Actions, S.STR_action);
			UpdateMass(ref Actors, S.STR_actor);
			UpdateMass(ref Targets, S.STR_target);
		}

		private void MakeNum(ref string Num, string Str)
		{
			// #error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 12116
			   at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<DefaultVisit>d__24.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<CreateLocals>d__7.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<AddLocalVariables>d__6.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<ConvertWithTrivia>d__4.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisit>d__3.MoveNext()

			Input: 

					On Error Resume Next

			 */
			if (Str == null)
				Num = "";
			else
				// Num = WordWrap(Str, ".", "Left")
				Num = Str.Replace(".", ",");
		}

		private Log LogFromString(string Str)
		{
			Log LogFromStringRet = default(Log);
			string[] S;
			// S = Words(Str, ",")
			S = Str.Split(Conversions.ToChar(","));
			var L = default(Log);

			L.Str = Str;
			L.act_time = S[0];
			L.STR_action = Main.LogIDs.get_Name(S[1]);
			L.log_id = S[1];
			L.actor = S[2];
			L.actor_account = S[3];
			L.target = S[4];
			L.target_account = S[5];
			L.location_x = S[6];
			L.location_y = S[7];
			L.location_z = S[8];
			L.etc_str1 = S[9];
			L.etc_str2 = S[10];
			L.etc_str3 = S[11];

			L.etc_num1 = S[12];
			L.etc_num2 = S[13];
			L.etc_num3 = S[14];
			L.etc_num4 = S[15];
			L.etc_num5 = S[16];
			L.etc_num6 = S[17];
			L.etc_num7 = S[18];
			L.etc_num8 = S[19];
			L.etc_num9 = S[20];
			L.etc_num10 = S[21];

			L.STR_actor = S[22];
			L.STR_actor_account = S[23];
			L.STR_target = S[24];
			L.STR_target_account = S[25];
			L.item_id = S[26];
			// If Items Is Nothing Then
			// Else
			// L.STR_item = Items.Name((L.etc_num8))
			// End If


			if (S.GetUpperBound(0) != 26)
			{
			}

			LogFromStringRet = L;
			return LogFromStringRet;
		}

		private void FromFiles(ref LogParser Cont, string SavePath = "")
		{
			string[] Files;
			Files = System.IO.Directory.GetFiles(Cont.textLogs.Text, "*.log");
			int i;
			System.IO.StreamReader F;
			var F2 = default(System.IO.StreamWriter);
			string Str;
			Log L;
			bool Add;

			int RowsCount = 0;

			Cont.Grid.Rows.Clear();

			if (!string.IsNullOrEmpty(SavePath))
				F2 = new System.IO.StreamWriter(SavePath, false);
			var loopTo = Files.GetUpperBound(0);
			for (i = 0; i <= loopTo; i++)
			{
				F = System.IO.File.OpenText(Files[i]);
				while (!F.EndOfStream)
				{
					Str = F.ReadLine();


					L = LogFromString(Str);

					Add = true;
					if ((Cont.cActions.Text ?? "") != ">>Без фильтра")
					{
						if ((Cont.cActions.Text ?? "") != (L.STR_action ?? ""))
							Add = false;
					}
					if (!string.IsNullOrEmpty(Cont.cActors.Text))
					{
						if ((Cont.cActors.Text ?? "") != (L.STR_actor ?? ""))
							Add = false;
					}
					if (!string.IsNullOrEmpty(Cont.cTarget.Text))
					{
						if ((Cont.cTarget.Text ?? "") != (L.STR_target ?? ""))
							Add = false;
					}
					// If (Cont.cDBitem.Text <> "") Then
					// If Cont.cDBitem.Text <> L.item_id Then
					// Add = False
					// End If
					// End If

					if (Add == true)
					{
						if (Cont.checkEnableExtraFilter.Checked == true)
							Add = CheckLogByGrid(L);
						if (Add == true)
						{
							if (!string.IsNullOrEmpty(SavePath))
								F2.WriteLine(L.Str);
							else
							{
								RowsCount = RowsCount + 1;
								if (RowsCount == Main.MaxRows)
								{
									MessageBox.Show("Превышено максимальное количество строк");
									break;
								}
								GridFromLog(ref Cont, L);
							}
						}
					}
				}

				F.Close();
			}

			if (!string.IsNullOrEmpty(SavePath))
				F2.Close();
		}

		private AppDomain LoadLogs()
		{
			string[] Files;
			int i;
			int j = 0;
			int CurLog = 0;
			System.IO.StreamReader F;
			string[] S;

			Actions = new string[1];
			Actors = new string[1];
			Targets = new string[1];
			// ReDim DBitems(0)

			Files = System.IO.Directory.GetFiles(pPath, "*.log");
			var loopTo = Files.GetUpperBound(0);
			for (i = 0; i <= loopTo; i++)
			{
				F = System.IO.File.OpenText(Files[i]);
				while (!F.EndOfStream)
				{
					j = j + 1;

					string Str = F.ReadLine();
					if (j / (double)1000 == Conversions.ToInteger(j / (double)1000))
						lC.Status.Text = "Загрузка логов (1-" + Conversions.ToString(i) + "-" + Conversions.ToString(j) + ")";
				}

				F.Close();
			}

			L = new Log[j + 1];
			j = 0;
			var loopTo1 = Files.GetUpperBound(0);
			for (i = 0; i <= loopTo1; i++)
			{
				F = System.IO.File.OpenText(Files[i]);
				while (!F.EndOfStream)
				{
					j = j + 1;

					string Str = F.ReadLine();

					L[j] = LogFromString(Str);

					UpdateMasses(L[j]);

					if (j / (double)1000 == Conversions.ToInteger(j / (double)1000))
						lC.Status.Text = "Загрузка логов (2-" + Conversions.ToString(i) + "-" + Conversions.ToString(j) + ")";
				}

				F.Close();
			}

			lC.Status.Text = "Готово";
			return default(AppDomain);
		}

		private void UpdateCombo(ref ComboBox Combo, string[] Mass)
		{
			int i;

			if (Mass.GetUpperBound(0) > 2000)
				return;

			Combo.Items.Clear();
			Combo.Items.Add(">>Без фильтра");
			if (Mass.GetUpperBound(0) > 0)
			{
				var loopTo = Mass.GetUpperBound(0);
				for (i = 1; i <= loopTo; i++)
					Combo.Items.Add(Mass[i]);
			}
			Combo.Sorted = true;
			var loopTo1 = Combo.Items.Count - 1;
			// Combo.SelectedIndex = 0

			for (i = 0; i <= loopTo1; i++)
			{
				if ((Combo.Items[i].ToString() ?? "") == ">>Без фильтра")
				{
					Combo.SelectedIndex = i;
					break;
				}
			}
		}

		public void LoadInMemory(string Path, ref LogParser Cont)
		{
			pPath = Path;
			lC = Cont;

			LoadLogs();
			var argCombo = lC.cActors;

			// UpdateCombo(lC.cActions, Actions)
			UpdateCombo(ref argCombo, Actors);
			var argCombo1 = lC.cTarget;
			// UpdateCombo(lC.cDBitem, DBitems)
			UpdateCombo(ref argCombo1, Targets);

			LogsLoaded = true;
		}

		private bool CheckLogByGrid(Log L)
		{
			bool CheckLogByGridRet = default(bool);
			bool Add = true;
			bool EnFilter;
			int j;

			if (C.GetUpperBound(0) > 0)
			{
				var loopTo = C.GetUpperBound(0);
				for (j = 1; j <= loopTo; j++)
				{
					EnFilter = true;
					if (C[j].Parameter == null)
						EnFilter = false;
					if (C[j].Operation == null)
						EnFilter = false;
					if (EnFilter == true)
					{
						try
						{
							double valToCompare = Conversions.ToDouble(Main.ValueFromLog(L, C[j].Parameter));
							double valToCompare2 = Conversions.ToDouble(C[j].Value);

							switch (C[j].Operation)
							{
								case ">":
									{
										//if (Information.IsNumeric(valToCompare) & Information.IsNumeric(valToCompare2))
										{
											if (valToCompare <= valToCompare2)
												Add = false;
										}
										//else
										//	Add = false;
										break;
									}

								case "<":
									{
										//if (Information.IsNumeric(valToCompare) & Information.IsNumeric(valToCompare2))
										{
											if (valToCompare >= valToCompare2)
												Add = false;
										}
										//else
										//	Add = false;
										break;
									}

								case "=":
									{
										if (valToCompare == valToCompare2)
										{
										}
										else
											Add = false;
										break;
									}

								case "<>":
									{
										if (valToCompare == valToCompare2)
											Add = false;
										break;
									}
							}
						}
						catch (Exception ex)
						{
							Add = false;
						}
					}
					if (Add == false)
						break;
				}
			}

			CheckLogByGridRet = Add;
			return CheckLogByGridRet;
		}

		private void FillCompareTable(ref LogParser Cont)
		{
			int i;

			if (Cont.gridFilter.Rows.Count > 1)
			{
				C = new CompareRow[Cont.gridFilter.Rows.Count - 1 + 1];
				var loopTo = C.GetUpperBound(0) - 1;
				for (i = 0; i <= loopTo; i++)
				{
					C[i + 1].Parameter = Cont.gridFilter.Rows[i].Cells[0].Value.ToString();
					C[i + 1].Operation = Cont.gridFilter.Rows[i].Cells[1].Value.ToString();
					C[i + 1].Value = Cont.gridFilter.Rows[i].Cells[2].Value.ToString();
				}
			}
			else
				C = new CompareRow[1];
		}

		private void FillTunableCells(ref LogParser Cont, Log L)
		{
		}

		private void GridFromLog(ref LogParser Cont, Log L)
		{
			int sdvig = 6;
			int i; // 
			string[] s;

			Cont.Grid.Rows.Add();
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[0].Value = L.act_time;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[1].Value = L.STR_action;

			if (Main.LogIDs.get_IsTunable(Conversions.ToInteger(L.log_id)))
			{
				for (i = 1; i <= 5; i++)
					Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[1 + i].Value = Main.LogIDs.get_TunableValue(Conversions.ToInteger(L.log_id), i, L);
			}

			s = L.Str.Split(Conversions.ToChar(","));
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 1].Value = L.actor;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 2].Value = L.actor_account;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 3].Value = L.target;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 4].Value = L.target_account;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 5].Value = L.location_x;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 6].Value = L.location_y;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 7].Value = L.location_z;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 8].Value = L.etc_str1;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 9].Value = L.etc_str2;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 10].Value = L.etc_str3;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 11].Value = L.etc_num1;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 12].Value = L.etc_num2;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 13].Value = L.etc_num3;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 14].Value = L.etc_num4;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 15].Value = L.etc_num5;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 16].Value = L.etc_num6;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 17].Value = L.etc_num7;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 18].Value = L.etc_num8;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 19].Value = L.etc_num9;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 20].Value = L.etc_num10;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 21].Value = L.STR_actor;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 22].Value = L.STR_actor_account;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 23].Value = L.STR_target;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 24].Value = L.STR_target_account;
			Cont.Grid.Rows[Cont.Grid.Rows.Count - 1].Cells[sdvig + 25].Value = L.item_id;
		}

		private void FromMemory(ref LogParser Cont, string SavePath = "")
		{
			int i;
			bool Add;
			var F = default(System.IO.StreamWriter);

			int RowsCount = 0;

			Cont.Status.Text = "Заполняется таблица";
			Cont.Update();

			Cont.Grid.Rows.Clear();

			if (Main.Logs.L.GetUpperBound(0) > 0)
			{
				if (!string.IsNullOrEmpty(SavePath))
					F = new System.IO.StreamWriter(SavePath, false);
				var loopTo = Main.Logs.L.GetUpperBound(0);
				for (i = 1; i <= loopTo; i++)
				{
					Add = true;
					if ((Cont.cActions.SelectedItem.ToString() ?? "") != ">>Без фильтра")
					{
						if ((Cont.cActions.SelectedItem.ToString() ?? "") != (Main.Logs.L[i].STR_action ?? ""))
							Add = false;
					}
					if ((Cont.cActors.SelectedItem.ToString() ?? "") != ">>Без фильтра")
					{
						if ((Cont.cActors.SelectedItem.ToString() ?? "") != (Main.Logs.L[i].STR_actor ?? ""))
							Add = false;
					}
					if ((Cont.cTarget.SelectedItem.ToString() ?? "") != ">>Без фильтра")
					{
						if ((Cont.cTarget.SelectedItem.ToString() ?? "") != (Main.Logs.L[i].STR_target ?? ""))
							Add = false;
					}
					// If Cont.cDBitem.SelectedItem.ToString <> ">>Без фильтра" Then
					// If Cont.cDBitem.SelectedItem.ToString <> Logs.L(i).item_id Then
					// Add = False
					// End If
					// End If

					if (Add == true)
					{
						if (Cont.checkEnableExtraFilter.Checked == true)
							Add = CheckLogByGrid(L[i]);
					}

					if (Add == true)
					{
						if (string.IsNullOrEmpty(SavePath))
						{
							RowsCount = RowsCount + 1;
							if (RowsCount == Main.MaxRows)
							{
								MessageBox.Show("Превышено максимальное количество строк");
								break;
							}
							GridFromLog(ref Cont, L[i]);
						}
						else
							F.WriteLine(L[i].Str);
					}
				}
			}

			if (!string.IsNullOrEmpty(SavePath))
				F.Close();


			Cont.Status.Text = "Готово";
			Cont.Update();
		}

		public void FillGrid(ref LogParser Cont)
		{
			FillCompareTable(ref Cont);

			if (LogsLoaded == true)
				FromMemory(ref Cont);
			else
				FromFiles(ref Cont);
		}


		public bool SaveToFile(ref LogParser Cont, string PathToSave)
		{
			if (string.IsNullOrEmpty(PathToSave))
				return false;

			FillCompareTable(ref Cont);

			if (LogsLoaded == true)
				FromMemory(ref Cont, PathToSave);
			else
				FromFiles(ref Cont, PathToSave);
			return true;
		}
	}

	public class cItems
	{
		private int[] IDs;
		private string[] Names;

		private int[] idxIDs;

		public void LoadItems(string Path)
		{
			System.IO.StreamReader F;
			string Str;
			string[] Str2;

			var MaxID = default(int);
			int i;
			var CountID = default(int);

			IDs = new int[1];
			Names = new string[1];
			
			// #error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 28220
			   at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<DefaultVisit>d__24.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<CreateLocals>d__7.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<AddLocalVariables>d__6.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<ConvertWithTrivia>d__4.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisit>d__3.MoveNext()

			Input: 

					'Exit Sub

					On Error Resume Next

			 */
			F = System.IO.File.OpenText(Path);
			//if (Information.Err().Number != 0)
			//{
			//}
			//else
			{
				while (!F.EndOfStream)
				{
					Str = F.ReadLine();
					CountID = CountID + 1;
				}
				F.Close();
				IDs = new int[CountID + 1];
				Names = new string[CountID + 1];
				CountID = 0;
				F = System.IO.File.OpenText(Path);
				while (!F.EndOfStream)
				{
					Str = F.ReadLine();
					CountID = CountID + 1;
					// Str2 = Words(Str, Chr(9))
					Str2 = Str.Split((char)9);
					IDs[CountID] = Conversions.ToInteger(Strings.WordWrap(Str2[1], "=", "Right"));
					Names[CountID] = Strings.WordWrap(Str2[2], "=", "Right"); // .Replace("[", "").Replace("]", "")
					MaxID = Conversions.ToInteger(IDs[CountID] > MaxID ? IDs[CountID] : MaxID);
				}

				idxIDs = new int[MaxID + 1];
				var loopTo = IDs.GetUpperBound(0);
				for (i = 1; i <= loopTo; i++)
					idxIDs[IDs[i]] = i;

				F.Close();
			}
		}

		public cItems(string Path)
		{
			LoadItems(Path);
		}

		public int Count
		{
			get
			{
				int CountRet = default(int);
				CountRet = Names.GetUpperBound(0);
				return CountRet;
			}
		}

		public string get_Name(string ID)
		{
			try
			{
				return Names[idxIDs[Conversions.ToInteger(ID)]];
			}
			catch (Exception e)
			{
				return ID;
			}
		}

		public int get_ID(string Name)
		{
			int IDRet = default(int);
			int i;
			var loopTo = Names.GetUpperBound(0);
			for (i = 1; i <= loopTo; i++)
			{
				if ((Names[i] ?? "") == (Name ?? ""))
				{
					IDRet = IDs[i];
					break;
				}
			}
			IDRet = 0;
			return IDRet;
		}
	}

	public class cLogIDs
	{
		private int[] IDs;
		private string[] Names;


		private string[,] kolonki;
		private string[,] kolids;

		private int[] idxIDs;

		public void LoadIDs(string Path)
		{
			System.IO.StreamReader F;
			string Str;
			string[] Str2;

			var MaxID = default(int);
			int i;

			IDs = new int[1];
			Names = new string[1];
			kolonki = new string[6, 1];
			kolids = new string[6, 1];
			;
//#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 30688
			   at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<DefaultVisit>d__24.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<CreateLocals>d__7.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<AddLocalVariables>d__6.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<ConvertWithTrivia>d__4.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisit>d__3.MoveNext()

			Input: 

					On Error Resume Next

			 */
			F = System.IO.File.OpenText(Path);
			//if (Information.Err().Number != 0)
			//{
			//}
			//else
			{
				while (!F.EndOfStream)
				{
					Str = F.ReadLine();
					// Str2 = Words(Str, " ")
					Str2 = Str.Split(Conversions.ToChar(" "));
					var oldDs = IDs;
					IDs = new int[IDs.GetUpperBound(0) + 1 + 1];
					if (oldDs != null)
						Array.Copy(oldDs, IDs, Math.Min(IDs.GetUpperBound(0) + 1 + 1, oldDs.Length));
					var oldNames = Names;
					Names = new string[Names.GetUpperBound(0) + 1 + 1];
					if (oldNames != null)
						Array.Copy(oldNames, Names, Math.Min(Names.GetUpperBound(0) + 1 + 1, oldNames.Length));
					var oldKolonki = kolonki;
					kolonki = new string[6, kolonki.GetUpperBound(1) + 1 + 1];
					if (oldKolonki != null)
						for (var i1 = 0; i1 <= oldKolonki.Length / oldKolonki.GetLength(1) - 1; ++i1)
							Array.Copy(oldKolonki, i1 * oldKolonki.GetLength(1), kolonki, i1 * kolonki.GetLength(1), Math.Min(oldKolonki.GetLength(1), kolonki.GetLength(1)));
					var oldKolids = kolids;
					kolids = new string[6, kolids.GetUpperBound(1) + 1 + 1];
					if (oldKolids != null)
						for (var i2 = 0; i2 <= oldKolids.Length / oldKolids.GetLength(1) - 1; ++i2)
							Array.Copy(oldKolids, i2 * oldKolids.GetLength(1), kolids, i2 * kolids.GetLength(1), Math.Min(oldKolids.GetLength(1), kolids.GetLength(1)));
					IDs[IDs.GetUpperBound(0)] = Conversions.ToInteger(Str2[0]);
					Names[Names.GetUpperBound(0)] = Str2[1];
					MaxID = Conversions.ToInteger(IDs[IDs.GetUpperBound(0)] > MaxID ? IDs[IDs.GetUpperBound(0)] : MaxID);
					if (Str2.GetUpperBound(0) > 1)
					{
						var loopTo = Str2.GetUpperBound(0);
						for (i = 2; i <= loopTo; i++)
						{
							if (Str2[i].Contains("="))
							{
								kolonki[i - 1, kolonki.GetUpperBound(1)] = Strings.WordWrap(Str2[i], "=", "Left");
								kolids[i - 1, kolids.GetUpperBound(1)] = Strings.WordWrap(Str2[i], "=", "Right");
							}
							else
								kolonki[i - 1, kolonki.GetUpperBound(1)] = Str2[i];
						}
					}
				}

				idxIDs = new int[MaxID + 1];
				var loopTo1 = IDs.GetUpperBound(0);
				for (i = 1; i <= loopTo1; i++)
					idxIDs[IDs[i]] = i;
			}
		}

		public cLogIDs(string Path)
		{
			LoadIDs(Path);
		}

		public int Count
		{
			get
			{
				int CountRet = default(int);
				CountRet = Names.GetUpperBound(0);
				return CountRet;
			}
		}

		public string get_Name(string ID)
		{
			try
			{
				return Names[idxIDs[Conversions.ToInteger(ID)]];
			}
			catch (Exception e)
			{
				return ID;
			}
		}

		public int get_ID(string Name)
		{
			int IDRet = default(int);
			int i;
			var loopTo = Names.GetUpperBound(0);
			for (i = 1; i <= loopTo; i++)
			{
				if ((Names[i] ?? "") == (Name ?? ""))
				{
					IDRet = IDs[i];
					break;
				}
			}
			IDRet = 0;
			return IDRet;
		}
		public int get_ID(ComboBox Combo)
		{
			int IDRet = default(int);
			IDRet = IDs[Combo.SelectedIndex + 1];
			return IDRet;
		}

		public void FillCombo(ref ComboBox Combo)
		{
			int i;

			Combo.Items.Clear();

			Combo.Items.Add(">>Без фильтра");
			var loopTo = Count;
			for (i = 1; i <= loopTo; i++)
				Combo.Items.Add(Names[i]);

			Combo.Sorted = true;
			var loopTo1 = Combo.Items.Count - 1;
			for (i = 0; i <= loopTo1; i++)
			{
				if ((Combo.Items[i].ToString() ?? "") == ">>Без фильтра")
				{
					Combo.SelectedIndex = i;
					break;
				}
			}
		}

		public bool get_IsTunable(int ID)
		{
			bool IsTunableRet = default(bool);
			int i = idxIDs[ID];
			string j = kolonki[1, idxIDs[ID]];
			if (!string.IsNullOrEmpty(kolonki[1, idxIDs[ID]]))
				IsTunableRet = true;
			else
				IsTunableRet = false;
			return IsTunableRet;
		}

		public string get_TunableValue(int ID, int num, cLogs.Log L)
		{
			string TunableValueRet = default(string);
			if (get_IsTunable(ID) == false)
			{
				// TunableValueRet = "";
				return "";
			}
			if (string.IsNullOrEmpty(kolids[num, idxIDs[ID]]))
			{
				if (!string.IsNullOrEmpty(kolonki[num, idxIDs[ID]]))
					TunableValueRet = Main.ValueFromLog(L, kolonki[num, idxIDs[ID]]).ToString();
				else
					TunableValueRet = "";
			}
			else
				switch (kolids[num, idxIDs[ID]])
				{
					case "item":
						{
							if (Main.Items == null)
								TunableValueRet = Conversions.ToString(ID);
							else
								TunableValueRet = Main.Items.get_Name(Main.ValueFromLog(L, kolonki[num, idxIDs[ID]]));
							break;
						}

					case "skill":
						{
							if (Main.locSkills == null)
								TunableValueRet = Conversions.ToString(ID);
							else
								TunableValueRet = Main.locSkills.get_Name(Main.ValueFromLog(L, kolonki[num, idxIDs[ID]]));
							break;
						}

					case "quest":
						{
							if (Main.Quests == null)
								TunableValueRet = Conversions.ToString(ID);
							else
								TunableValueRet = Main.Quests.get_Name(Main.ValueFromLog(L, kolonki[num, idxIDs[ID]]));
							break;
						}

					case "npc":
						{
							if (Main.NPC == null)
								TunableValueRet = Conversions.ToString(ID);
							else
								// TunableValue = NPC.Name((ValueFromLog(L, kolonki(num, idxIDs(ID))).ToString.Substring(2)))
								TunableValueRet = Main.NPC.get_Name(Main.ValueFromLog(L, kolonki[num, idxIDs[ID]]));
							break;
						}
				}

			return TunableValueRet;
		}
	}

	public class cNPC
	{
		private int[] IDs;
		private string[] Names;

		private int[] idxIDs;

		public void LoadNPC(string Path)
		{
			System.IO.StreamReader F;
			string Str;
			string[] Str2;

			var MaxID = default(int);
			int i;
			var CountID = default(int);

			IDs = new int[1];
			Names = new string[1];
			;
//#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 36565
			   at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<DefaultVisit>d__24.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<CreateLocals>d__7.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<AddLocalVariables>d__6.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<ConvertWithTrivia>d__4.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisit>d__3.MoveNext()

			Input: 

					On Error Resume Next

			 */
			F = System.IO.File.OpenText(Path);
			//if (Information.Err().Number != 0)
			//{
			//}
			//else
			{
				while (!F.EndOfStream)
				{
					Str = F.ReadLine();
					CountID = CountID + 1;
				}
				IDs = new int[CountID + 1];
				Names = new string[CountID + 1];
				CountID = 0;
				F.Close();
				F = System.IO.File.OpenText(Path);
				while (!F.EndOfStream)
				{
					Str = F.ReadLine();
					// Str2 = Words(Str, Chr(9))
					Str2 = Str.Split((char)9);
					CountID = CountID + 1;
					IDs[CountID] = Conversions.ToInteger(Strings.WordWrap(Str2[1], "=", "Right")) + 1000000;
					Names[CountID] = Strings.WordWrap(Str2[2], "=", "Right"); // .Replace("[", "").Replace("]", "")
					MaxID = Conversions.ToInteger(IDs[CountID] > MaxID ? IDs[CountID] : MaxID);
				}

				idxIDs = new int[MaxID + 1];
				var loopTo = IDs.GetUpperBound(0);
				for (i = 1; i <= loopTo; i++)
					idxIDs[IDs[i]] = i;

				F.Close();
			}
		}

		public cNPC(string Path)
		{
			LoadNPC(Path);
		}

		public int Count
		{
			get
			{
				int CountRet = default(int);
				CountRet = Names.GetUpperBound(0);
				return CountRet;
			}
		}

		public string get_Name(string ID)
		{
			try
			{
				return Names[idxIDs[Conversions.ToInteger(ID)]];
			}
			catch (Exception e)
			{
				return ID;
			}
		}

		public int get_ID(string Name)
		{
			int IDRet = default(int);
			int i;
			var loopTo = Names.GetUpperBound(0);
			for (i = 1; i <= loopTo; i++)
			{
				if ((Names[i] ?? "") == (Name ?? ""))
				{
					IDRet = IDs[i];
					break;
				}
			}
			IDRet = 0;
			return IDRet;
		}
	}

	public class cQuests
	{
		private int[] IDs;
		private string[] Names;

		private int[] idxIDs;

		public void LoadQuests(string Path)
		{
			System.IO.StreamReader F;
			string Str;
			string[] Str2;

			var MaxID = default(int);
			int i;
			var CountID = default(int);

			IDs = new int[1];
			Names = new string[1];
			;
//#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 38949
			   at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<DefaultVisit>d__24.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<CreateLocals>d__7.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<AddLocalVariables>d__6.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<ConvertWithTrivia>d__4.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisit>d__3.MoveNext()

			Input: 

					On Error Resume Next

			 */
			F = System.IO.File.OpenText(Path);
			//if (Information.Err().Number != 0)
			//{
			//}
			//else
			{
				while (!F.EndOfStream)
				{
					Str = F.ReadLine();
					CountID = CountID + 1;
				}
				IDs = new int[CountID + 1];
				Names = new string[CountID + 1];
				CountID = 0;
				F.Close();
				F = System.IO.File.OpenText(Path);
				while (!F.EndOfStream)
				{
					Str = F.ReadLine();
					// Str2 = Words(Str, Chr(9))
					Str2 = Str.Split((char)9);
					CountID = CountID + 1;
					IDs[CountID] = Conversions.ToInteger(Strings.WordWrap(Str2[2], "=", "Right"));
					Names[CountID] = Strings.WordWrap(Str2[4], "=", "Right"); // .Replace("[", "").Replace("]", "")
					MaxID = Conversions.ToInteger(IDs[CountID] > MaxID ? IDs[CountID] : MaxID);
				}

				idxIDs = new int[MaxID + 1];
				var loopTo = IDs.GetUpperBound(0);
				for (i = 1; i <= loopTo; i++)
					idxIDs[IDs[i]] = i;

				F.Close();
			}
		}

		public cQuests(string Path)
		{
			LoadQuests(Path);
		}

		public int Count
		{
			get
			{
				int CountRet = default(int);
				CountRet = Names.GetUpperBound(0);
				return CountRet;
			}
		}

		public string get_Name(string ID)
		{
			try
			{
				return Names[idxIDs[Conversions.ToInteger(ID)]];
			}
			catch (Exception e)
			{
				return ID;
			}
		}

		public int get_ID(string Name)
		{
			int IDRet = default(int);
			int i;
			var loopTo = Names.GetUpperBound(0);
			for (i = 1; i <= loopTo; i++)
			{
				if ((Names[i] ?? "") == (Name ?? ""))
				{
					IDRet = IDs[i];
					break;
				}
			}
			IDRet = 0;
			return IDRet;
		}
	}

	public class cSkills
	{
		private int[] IDs;
		private string[] Names;



		private int[] idxIDs;



		public void LoadSkills(string Path)
		{
			System.IO.StreamReader F;
			string Str;
			string[] Str2;

			var MaxID = default(int);
			int i;
			int CountID = 0;

			IDs = new int[1];
			Names = new string[1];
			;
//#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
			/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 41336
			   at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<DefaultVisit>d__24.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<CreateLocals>d__7.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<AddLocalVariables>d__6.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<ConvertWithTrivia>d__4.MoveNext()
			--- End of stack trace from previous location where exception was thrown ---
			   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
			   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
			   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisit>d__3.MoveNext()

			Input: 

					On Error Resume Next

			 */
			F = System.IO.File.OpenText(Path);
			//if (Information.Err().Number != 0)
			//{
			//}
			//else
			{
				while (!F.EndOfStream)
				{
					Str = F.ReadLine();
					Str2 = Str.Split((char)9);
					if ((Strings.WordWrap(Str2[2], "=", "Right") ?? "") == "1")
						CountID = CountID + 1;
				}
				F.Close();
				IDs = new int[CountID + 1];
				Names = new string[CountID + 1];
				CountID = 0;
				F = System.IO.File.OpenText(Path);
				while (!F.EndOfStream)
				{
					Str = F.ReadLine();
					// Str2 = Words(Str, Chr(9))
					Str2 = Str.Split((char)9);
					if ((Strings.WordWrap(Str2[2], "=", "Right") ?? "") == "1")
					{
						CountID = CountID + 1;
						IDs[CountID] = Conversions.ToInteger(Strings.WordWrap(Str2[1], "=", "Right"));
						Names[CountID] = Strings.WordWrap(Str2[3], "=", "Right"); // .Replace("[", "").Replace("]", "")
						MaxID = Conversions.ToInteger(IDs[CountID] > MaxID ? IDs[CountID] : MaxID);
					}
				}

				idxIDs = new int[MaxID + 1];
				var loopTo = IDs.GetUpperBound(0);
				for (i = 1; i <= loopTo; i++)
					idxIDs[IDs[i]] = i;

				F.Close();
			}
		}

		public cSkills(string Path)
		{
			LoadSkills(Path);
		}

		public int Count
		{
			get
			{
				int CountRet = default(int);
				CountRet = Names.GetUpperBound(0);
				return CountRet;
			}
		}

		public string get_Name(string ID)
		{
			try
			{
				return Names[idxIDs[Conversions.ToInteger(ID)]];
			}
			catch (Exception e)
			{
				return ID;
			}
		}

		public int get_ID(string Name)
		{
			int IDRet = default(int);
			int i;
			var loopTo = Names.GetUpperBound(0);
			for (i = 1; i <= loopTo; i++)
			{
				if ((Names[i] ?? "") == (Name ?? ""))
				{
					IDRet = IDs[i];
					break;
				}
			}
			IDRet = 0;
			return IDRet;
		}
	}

	static class Main
	{
		public static string[] ParametersString = new string[31];

		public static int MaxRows;

		public struct sPaths
		{
			internal string LogIDs;
			internal string ItemName;
			internal string Logs;
			internal string Skills;
			internal string Quests;
			internal string NPC;
		}



		public static sPaths Paths;

		public static cItems Items;
		public static cLogIDs LogIDs;

		public static cLogs Logs;

		public static cSkills locSkills;

		public static cQuests Quests;

		public static cNPC NPC;

		public static string LoadNamesOnLaunch = "0";
		public static string ValueFromLog(cLogs.Log L, string pName)
		{
			string ValueFromLogRet = default(string);
			switch (pName)
			{
				case "act_time":
					{
						ValueFromLogRet = L.act_time;
						break;
					}

				case "log_id":
					{
						ValueFromLogRet = L.log_id;
						break;
					}

				case "actor":
					{
						ValueFromLogRet = L.actor;
						break;
					}

				case "actor_account":
					{
						ValueFromLogRet = L.actor_account;
						break;
					}

				case "target":
					{
						ValueFromLogRet = L.target;
						break;
					}

				case "target_account":
					{
						ValueFromLogRet = L.target_account;
						break;
					}

				case "location_x":
					{
						ValueFromLogRet = L.location_x;
						break;
					}

				case "location_y":
					{
						ValueFromLogRet = L.location_y;
						break;
					}

				case "location_z":
					{
						ValueFromLogRet = L.location_z;
						break;
					}

				case "etc_str1":
					{
						ValueFromLogRet = L.etc_str1;
						break;
					}

				case "etc_str2":
					{
						ValueFromLogRet = L.etc_str2;
						break;
					}

				case "etc_str3":
					{
						ValueFromLogRet = L.etc_str3;
						break;
					}

				case "etc_num1":
					{
						ValueFromLogRet = L.etc_num1;
						break;
					}

				case "etc_num2":
					{
						ValueFromLogRet = L.etc_num2;
						break;
					}

				case "etc_num3":
					{
						ValueFromLogRet = L.etc_num3;
						break;
					}

				case "etc_num4":
					{
						ValueFromLogRet = L.etc_num4;
						break;
					}

				case "etc_num5":
					{
						ValueFromLogRet = L.etc_num5;
						break;
					}

				case "etc_num6":
					{
						ValueFromLogRet = L.etc_num6;
						break;
					}

				case "etc_num7":
					{
						ValueFromLogRet = L.etc_num7;
						break;
					}

				case "etc_num8":
					{
						ValueFromLogRet = L.etc_num8;
						break;
					}

				case "etc_num9":
					{
						ValueFromLogRet = L.etc_num9;
						break;
					}

				case "etc_num10":
					{
						ValueFromLogRet = L.etc_num10;
						break;
					}

				case "STR_actor":
					{
						ValueFromLogRet = L.STR_actor;
						break;
					}

				case "STR_actor_account":
					{
						ValueFromLogRet = L.STR_actor_account;
						break;
					}

				case "STR_target":
					{
						ValueFromLogRet = L.STR_target;
						break;
					}

				case "STR_target_account":
					{
						ValueFromLogRet = L.STR_target_account;
						break;
					}

				case "item_id":
					{
						ValueFromLogRet = L.item_id;
						break;
					}

				case "STR_item":
					{
						ValueFromLogRet = L.STR_item;
						break;
					}

				case "STR_action":
					{
						ValueFromLogRet = L.STR_action;
						break;
					}

				case "Str":
					{
						ValueFromLogRet = L.Str;
						break;
					}
			}

			return ValueFromLogRet;
		}

		public static void FillParametersString()
		{
			ParametersString[1] = "act_time";
			ParametersString[2] = "log_id";
			ParametersString[3] = "actor";
			ParametersString[4] = "actor_account";
			ParametersString[5] = "target";
			ParametersString[6] = "target_account";
			ParametersString[7] = "location_x";
			ParametersString[8] = "location_y";
			ParametersString[9] = "location_z";
			ParametersString[10] = "etc_str1";
			ParametersString[11] = "etc_str2";
			ParametersString[12] = "etc_str3";
			ParametersString[13] = "etc_num1";
			ParametersString[14] = "etc_num2";
			ParametersString[15] = "etc_num3";
			ParametersString[16] = "etc_num4";
			ParametersString[17] = "etc_num5";
			ParametersString[18] = "etc_num6";
			ParametersString[19] = "etc_num7";
			ParametersString[20] = "etc_num8";
			ParametersString[21] = "etc_num9";
			ParametersString[22] = "etc_num10";
			ParametersString[23] = "STR_actor";
			ParametersString[24] = "STR_actor_account";
			ParametersString[25] = "STR_target";
			ParametersString[26] = "STR_target_account";
			ParametersString[27] = "item_id";
			ParametersString[28] = "STR_item";
			ParametersString[29] = "STR_action";
			ParametersString[30] = "Str";
		}
	}

	//static class Strings
	//{
	//	public static int WordCount(string Str, string Razd = " ")
	//	{
	//		int WordCountRet = default(int);
	//		// Возвращает количество слов в строке

	//		int i;

	//		Str = Str.Trim();
	//		var loopTo = Str.Length - 1;
	//		for (i = 1; i <= loopTo; i++)
	//		{
	//			if ((Str.Substring(i, 1) ?? "") == (Razd ?? ""))
	//				WordCountRet = WordCountRet + 1;
	//			else if (i == Str.Length - 1)
	//				WordCountRet = WordCountRet + 1;
	//		}

	//		return WordCountRet;
	//	}

	//	public static string WordWrap(string Str, string Symb, string Pos = "Left")
	//	{
	//		string WordWrapRet = default(string);
	//		// Обрезает строку вплоть до символа (либо несколькх символов) symb включительно
	//		// Pos может быть Left или Right. Он задает с какой стороны от символа вернуть строку

	//		int i;
	//		var loopTo = Str.Length - 1;
	//		for (i = 0; i <= loopTo; i++)
	//		{
	//			if ((Str.Substring(i, Symb.Length) ?? "") == (Symb ?? ""))
	//			{
	//				if ((Pos ?? "") == "Left")
	//					WordWrapRet = Microsoft.VisualBasic.Strings.Trim(Str.Substring(0, i + Symb.Length - 1));
	//				else
	//					WordWrapRet = Microsoft.VisualBasic.Strings.Trim(Str.Substring(i + Symb.Length, Str.Length - i - Symb.Length));
	//				return WordWrapRet;
	//			}
	//		}

	//		WordWrapRet = Str;
	//		return WordWrapRet;
	//	}

	//	public static string[] Words(string Str, string Razd)
	//	{
	//		string[] WordsRet = default(string[]);
	//		int wCount;
	//		int i;
	//		int j = 0;
	//		int WordStart = 0;
	//		string[] tWords;

	//		wCount = WordCount(Str, Razd);

	//		tWords = new string[wCount + 1];
	//		var loopTo = Str.Length - 1;
	//		for (i = 1; i <= loopTo; i++)
	//		{
	//			if ((Str.Substring(i, 1) ?? "") == (Razd ?? "") | Str.Length - 1 == i)
	//			{
	//				j = j + 1;
	//				if (i == Str.Length - 1)
	//				{
	//					if (WordStart == i)
	//					{
	//					}
	//					else
	//						tWords[j] = Str.Substring(WordStart, i - WordStart + 1);
	//				}
	//				else if (i == WordStart)
	//				{
	//				}
	//				else
	//					tWords[j] = Str.Substring(WordStart, i - WordStart);
	//				WordStart = i + 1;
	//			}
	//		}

	//		WordsRet = tWords;
	//		return WordsRet;
	//	}
	//}
}
