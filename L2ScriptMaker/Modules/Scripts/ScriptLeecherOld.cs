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
	public partial class ScriptLeecherOld : Form
	{
		public ScriptLeecherOld()
		{
			InitializeComponent();
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void ButtonOpen1_Click(object sender, EventArgs e)
		{
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			File1.Text = OpenFileDialog.FileName;
		}

		private void ButtonOpen2_Click(object sender, EventArgs e)
		{
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			File2.Text = OpenFileDialog.FileName;
		}

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			string TempStr;
			// Debug data. remove this for release!
			// File1.Text = "npcdata_c1.txt"
			// File2.Text = "npcdata_c4.txt"
			// Debug data. remove this for release!

			if (string.IsNullOrEmpty(File1.Text) | string.IsNullOrEmpty(File2.Text))
			{
				MessageBox.Show("I'm ready to suck, but i cant see source and target.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (NpcParam.CheckedItems.Count == 0)
			{
				MessageBox.Show("Gimme list! I wish to suck!", "No list", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var inNpc1 = new System.IO.StreamReader(File1.Text, System.Text.Encoding.Default, true, 1);
			TempStr = System.IO.Path.GetFileName(File1.Text) + "_" + System.IO.Path.GetFileName(File2.Text) + ".txt";
			// Dim NewFile As System.IO.Stream = New System.IO.FileStream(TempStr, _
			// IO.FileMode.Create, IO.FileAccess.Write)
			var NewFile2 = new System.IO.StreamWriter(TempStr, false, System.Text.Encoding.Unicode, 1);

			// Dim outLog As New System.IO.StreamWriter(TempStr & ".log", False, System.Text.Encoding.Unicode, 1)
			// outLog.WriteLine("L2ScriptMaker: ScriptLeacher..." & vbNewLine & Now.ToString & " Start" & vbNewLine)

			string TempStr1;
			string TempStr2;
			string Comment1;
			string Comment2;
			string[] Npc1;
			string[] Npc2;

			int IsData = 0; // 1 - npcdata, 2 - itemdata
			ProgressBar.Maximum = Conversions.ToInteger(inNpc1.BaseStream.Length);

			while (inNpc1.EndOfStream != true)
			{
				ProgressBar.Value = Conversions.ToInteger(inNpc1.BaseStream.Position);
				Comment1 = ""; Comment2 = "";
				this.Update();
				TempStr1 = inNpc1.ReadLine();

				if (!string.IsNullOrEmpty(TempStr1) & TempStr1.StartsWith("//") == false)
				{
					TempStr1 = TextCorrector(TempStr1);

					if (Strings.InStr(TempStr1, "/*") != 0)
					{
						// Comment
						Comment1 = Strings.Mid(TempStr1, Strings.InStr(TempStr1, "/*"), Strings.InStr(TempStr1, "*/") - Strings.InStr(TempStr1, "/*") + 2);
						TempStr1 = TempStr1.Replace(Conversions.ToString((char)9) + Comment1, "");
						Comment1 = Comment1.Replace(Conversions.ToString((char)9), " ");
					}

					Npc1 = TempStr1.Split((char)9);
					switch (Npc1[0])
					{
						case "npc_begin":
							{
								IsData = 2;
								break;
							}

						case "item_begin":
							{
								IsData = 2;
								break;
							}

						case "set_begin":
							{
								IsData = 1;
								break;
							}

						case "skill_begin":
							{
								IsData = 3;
								break;
							}
					}

					TempStr2 = "";
					if (IsData != 3)
					{
						TempStr2 = FindInFile(Npc1[IsData], IsData);  // 2 - NpcId
						TempStr2 = TextCorrector(TempStr2);
					}
					else
					{
						// It's skilldata
						if (SrcSkilldataEButton.Checked == true | SrcSkillgrpButton.Checked == true)
							TempStr2 = FindInFile("skill_id=" + Libraries.GetNeedParamFromStr(TempStr1, "skill_id") + Conversions.ToString((char)9) + "skill_level=" + Libraries.GetNeedParamFromStr(TempStr1, "level"), IsData);  // 2 - NpcId
						else
							// Except skilldata-e.txt and skillgrp.txt
							TempStr2 = FindInFile("skill_id=" + Libraries.GetNeedParamFromStr(TempStr1, "skill_id") + Conversions.ToString((char)9) + "level=" + Libraries.GetNeedParamFromStr(TempStr1, "level"), IsData);// 2 - NpcId
						if (Strings.InStr(TempStr2, "/*") != 0)
						{
							// Comment
							Comment2 = Strings.Mid(TempStr2, Strings.InStr(TempStr2, "/*"), Strings.InStr(TempStr2, "*/") - Strings.InStr(TempStr2, "/*") + 2);
							TempStr2 = TempStr2.Replace(Conversions.ToString((char)9) + Comment2, "");
							Comment2 = Comment2.Replace(Conversions.ToString((char)9), " ");
						}
						else if (SrcSkilldataEButton.Checked == true & !string.IsNullOrEmpty(TempStr2))
						{
							int iTemp = Strings.InStr(TempStr2, "name=[") + 5;
							// Mid(TempStr2, InStr(TempStr2, "desc=[")+6, InStr( InStr(TempStr2, "desc=[") , TempStr2,  InStr(TempStr2, "desc=[")-2)
							// Comment2 = Libraries.GetNeedParamFromStr(TempStr2, "desc")
							Comment2 = "/* " + Strings.Mid(TempStr2, iTemp, Strings.InStr(iTemp, TempStr2, "]") - iTemp + 1).Replace((char)9, (char)32) + " */";
						}

						TempStr2 = TextCorrector(TempStr2);
					}

					if (!string.IsNullOrEmpty(TempStr2))
					{

						// Npc exist. Working...
						Npc2 = TempStr2.Split((char)9);
						int TempInt;
						string TempStr3;
						var loopTo = NpcParam.CheckedItems.Count - 1;
						for (TempInt = 0; TempInt <= loopTo; TempInt++)
						{
							TempStr3 = Libraries.GetNeedParamFromStr(TempStr2, NpcParam.CheckedItems[TempInt].ToString());

							// Correction for new param's
							switch (NpcParam.CheckedItems[TempInt].ToString())
							{
								case "collision_radius":
									{
										// TempStr3 = Mid(TempStr3, 2, TempStr3.Length - InStr(TempStr3, ";") - 1)
										TempStr3 = TempStr3.Replace("collision_radius=", "");
										break;
									}

								case "collision_height":
									{
										// TempStr3 = Mid(TempStr3, 2, TempStr3.Length - InStr(TempStr3, ";") - 1)
										TempStr3 = TempStr3.Replace("collision_height=", "");
										break;
									}

								case "align":
									{
										// Correction for old param 'align'
										int iAlign;
										iAlign = Conversions.ToInteger(Strings.Replace(Npc2[4], "level=", ""));
										iAlign = -iAlign * iAlign;
										if (iAlign < -4900)
											iAlign = -1;
										TempStr3 = iAlign.ToString();
										break;
									}

								case "is_magic":
									{
										if ((Libraries.GetNeedParamFromStr(TempStr1, "is_magic") ?? "") == "2")
											// nothing change if is_magic=2 in original file
											TempStr3 = "";
										break;
									}

								case "mp_consume":
									{
										if (IsData == 3)
										{
											var Mp1 = default(int);

											// It's import from skillgrp.dat to skilldata.txt
											// Dim test As String = ""
											int Mp2;

											Mp2 = Conversions.ToInteger(TempStr3);

											switch (Libraries.GetNeedParamFromStr(TempStr1, "is_magic"))
											{
												case "0":
													{
														if (!string.IsNullOrEmpty(Libraries.GetNeedParamFromStr(TempStr1, "mp_consume1")))
															TempStr1 = TempStr1.Replace("mp_consume1" + "=" + Libraries.GetNeedParamFromStr(TempStr1, "mp_consume1"), "");
														// is_magic=0	mp_consume2=10	
														Mp1 = 0; // not exist
														Mp2 = Mp2 - Mp1;
														if ((Libraries.GetNeedParamFromStr(TempStr1, "operate_type") ?? "") == "T")
														{
															Mp1 = Mp2;
															Mp2 = 0;
														}

														break;
													}

												case "1":
													{
														if (string.IsNullOrEmpty(Libraries.GetNeedParamFromStr(TempStr1, "mp_consume1")))
															TempStr1 = TempStr1.Replace("is_magic=1", "is_magic=1" + Constants.vbTab + "mp_consume1=0");
														if (string.IsNullOrEmpty(Libraries.GetNeedParamFromStr(TempStr1, "mp_consume2")))
															TempStr1 = TempStr1.Replace("is_magic=1", "is_magic=1" + Constants.vbTab + "mp_consume1=0");
														// is_magic=1	mp_consume1=11	mp_consume2=44
														Mp1 = Conversions.ToInteger(Mp2 * 0.2); // MP1 = 20% of Summary
														Mp2 = Mp2 - Mp1;
														break;
													}

												case "2":
													{
														if (string.IsNullOrEmpty(Libraries.GetNeedParamFromStr(TempStr1, "mp_consume1")))
															TempStr1 = TempStr1.Replace("is_magic=2", "is_magic=2" + Constants.vbTab + "mp_consume1=0");
														// is_magic = 2	mp_consume1 = 50	mp_consume2 = 0	
														Mp1 = Mp2;  // MP1 = 20% of Summary
														Mp2 = 0;
														break;
													}

												case var @case when @case == null:
													{
														// T skill or wrong skill type
														Mp1 = Mp2;
														Mp2 = 0;
														break;
													}
											}

											TempStr1 = Libraries.SetNeedParamToStr(TempStr1, "mp_consume1", Conversions.ToString(Mp1));
											TempStr1 = Libraries.SetNeedParamToStr(TempStr1, "mp_consume2", Conversions.ToString(Mp2));
											// TempStr1 = TempStr1.Replace("mp_consume1" & "=" & Libraries.GetNeedParamFromStr(TempStr1, "mp_consume1"), "mp_consume1" & "=" & CInt(Mp1))
											// TempStr1 = TempStr1.Replace("mp_consume2" & "=" & Libraries.GetNeedParamFromStr(TempStr1, "mp_consume2"), "mp_consume2" & "=" & CInt(Mp2))

											// Disable common worker
											TempStr3 = "";
										}

										break;
									}

								case "hit_time":
									{
										// It's import from skillgrp.dat to skilldata.dat

										if (IsData == 3)
										{
											TempStr1 = TempStr1.Replace("skill_hit_time" + "=" + Libraries.GetNeedParamFromStr(TempStr1, "skill_hit_time"), "skill_hit_time" + "=" + double.Parse(TempStr3).ToString());
											TempStr3 = "";
										}

										break;
									}
							}

							if (!string.IsNullOrEmpty(TempStr3))
							{
								if (!string.IsNullOrEmpty(Libraries.GetNeedParamFromStr(TempStr2, NpcParam.CheckedItems[TempInt].ToString())))
									TempStr1 = TempStr1.Replace(NpcParam.CheckedItems[TempInt].ToString() + "=" + Libraries.GetNeedParamFromStr(TempStr1, NpcParam.CheckedItems[TempInt].ToString()), NpcParam.CheckedItems[TempInt].ToString() + "=" + TempStr3);
								else
								{
								}
							}
						}
					}
					else
					{
					}
					if (!string.IsNullOrEmpty(Comment2))
						TempStr1 = TempStr1.Replace(Conversions.ToString((char)9) + "skill_id", Conversions.ToString((char)9) + Comment2 + Conversions.ToString((char)9) + "skill_id");
					else
						TempStr1 = TempStr1.Replace(Conversions.ToString((char)9) + "skill_id", Conversions.ToString((char)9) + Comment1 + Conversions.ToString((char)9) + "skill_id");
				}


				NewFile2.WriteLine(TempStr1);
			}

			ProgressBar.Value = 0;

			// outLog.WriteLine(Now & vbNewLine)
			// outLog.Close()

			inNpc1.Close();
			NewFile2.Close();

			MessageBox.Show("Sucking complete. Thanks NCSoft for good sex.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public string TextCorrector(string SourceText)
		{

			// tabs and spaces correction
			SourceText = Strings.Replace(SourceText, " = ", "=");
			while (Strings.InStr(SourceText, "  ") != 0)
				SourceText = Strings.Replace(SourceText, "  ", " ");
			SourceText = Strings.Replace(SourceText, " ", Conversions.ToString((char)9));

			return SourceText;
		}

		public string FindInFile(string WhatNeed, int IsData)
		{
			string FindInFileRet = default(string);
			var File = new System.IO.StreamReader(File2.Text, System.Text.Encoding.Default, true, 1);

			FindInFileRet = "";

			string TempStr = "";
			// Dim Npc2() As String

			while (File.EndOfStream != true)
			{
				TempStr = File.ReadLine();
				TempStr = TextCorrector(TempStr);
				if (!string.IsNullOrEmpty(TempStr))
				{

					// If IsData <> 3 Then
					// Npc2 = TempStr.Split(Chr(9))
					// If WhatNeed = Npc2(IsData) Then
					// File.Close()
					// Return TempStr
					// End If
					// Else
					// It's skilldata
					if (Strings.InStr(TempStr, "\t" + WhatNeed, CompareMethod.Text) != 0)
					{
						File.Close();
						return TempStr;
					}
				}
			}
			File.Close();
			return FindInFileRet;
		}

		private void ButtonChkAll_Click(object sender, EventArgs e)
		{
			int TempInt;
			var loopTo = NpcParam.Items.Count - 1;
			for (TempInt = 0; TempInt <= loopTo; TempInt++)
				NpcParam.SetItemChecked(TempInt, true);
		}

		private void ButtonDeChkAll_Click(object sender, EventArgs e)
		{
			int TempInt;
			var loopTo = NpcParam.CheckedItems.Count - 1;
			for (TempInt = 0; TempInt <= loopTo; TempInt++)
				NpcParam.SetItemChecked(TempInt, false);
		}

		private void ButtonImportList_Click(object sender, EventArgs e)
		{
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			NpcParam.Items.Clear();

			var LstFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);
			string TempStr;

			while (LstFile.EndOfStream != true)
			{
				TempStr = LstFile.ReadLine().Trim();
				NpcParam.Items.Add(TempStr, true);
			}

			LstFile.Close();
			MessageBox.Show("Import new list complete.", "Import complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
