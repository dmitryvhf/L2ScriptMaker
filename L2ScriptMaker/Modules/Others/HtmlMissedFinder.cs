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

namespace L2ScriptMaker.Modules.Others
{
	public partial class HtmlMissedFinder : Form
	{
		public HtmlMissedFinder()
		{
			InitializeComponent();
		}

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			string ConfigDir;
			string HtmlDir = "";
			string NewHtmlDir = "";
			var HtmlFiles = new string[1];
			var HtmlMissed = new string[1];
			int iTemp;
			string sTemp;
			string sTemp2;
			int MissCount = -1;

			System.IO.StreamWriter MakeMissed;

			ConfigDir = Application.StartupPath;
			FolderBrowserDialog.SelectedPath = ConfigDir;

			if (CheckedListBox.CheckedItems.Count > 0)
			{
				FolderBrowserDialog.SelectedPath = Environment.CurrentDirectory;
				CurActionLabel.Text = "Select folder with files from checked box..."; CurActionLabel.Update();
				FolderBrowserDialog.Description = "Select folder with files from checked box...";
				if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
					return;
				ConfigDir = FolderBrowserDialog.SelectedPath;
				CurActionLabel.Text = "Loading files to checking..."; CurActionLabel.Update();
				var loopTo = CheckedListBox.CheckedItems.Count - 1;
				for (iTemp = 0; iTemp <= loopTo; iTemp++)
				{
					if (System.IO.File.Exists(ConfigDir + @"\" + CheckedListBox.CheckedItems[iTemp]) == false)
					{
						MessageBox.Show("Not found file '" + CheckedListBox.CheckedItems[iTemp] + "' to checking", "No file", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
			}

			CurActionLabel.Text = "Select server 'html' folder..."; CurActionLabel.Update();
			FolderBrowserDialog.Description = "Select server 'html' folder";
			if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
				return;
			HtmlDir = FolderBrowserDialog.SelectedPath;
			HtmlFiles = System.IO.Directory.GetFiles(HtmlDir, "*.htm", System.IO.SearchOption.AllDirectories);

			if (CreateHtmBox.Checked == true)
			{
				CurActionLabel.Text = "Select folder where tool will be create missed html file..."; CurActionLabel.Update();
				FolderBrowserDialog.Description = "Select folder where tool will be create missed html file";
				if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
					return;
				NewHtmlDir = FolderBrowserDialog.SelectedPath;
			}

			if (HtmlFiles.Length < 1)
			{
				MessageBox.Show("This directory not have Htm files", "No htm files", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			sTemp2 = System.IO.Path.GetDirectoryName(HtmlFiles[0]);
			var loopTo1 = HtmlFiles.Length - 1;
			for (iTemp = 0; iTemp <= loopTo1; iTemp++)
				HtmlFiles[iTemp] = HtmlFiles[iTemp].Replace(sTemp2 + @"\", "");

			Array.Resize(ref HtmlMissed, HtmlFiles.Length);
			var outFile = new System.IO.StreamWriter(ConfigDir + @"\l2scriptmaker_html_missed.log", true, System.Text.Encoding.Unicode, 1);

			outFile.WriteLine("L2ScriptMaker: Missed HTML Checker");
			outFile.WriteLine(Conversions.ToString(DateAndTime.Now) + " Start");

			this.Update();
			System.IO.StreamReader inFile;
			var loopTo2 = CheckedListBox.CheckedItems.Count - 1;
			for (iTemp = 0; iTemp <= loopTo2; iTemp++)
			{
				inFile = new System.IO.StreamReader(ConfigDir + @"\" + CheckedListBox.CheckedItems[iTemp], System.Text.Encoding.Default, true, 1);
				ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
				ProgressBar.Value = 0;
				outFile.WriteLine(Constants.vbNewLine + ("File: " + CheckedListBox.CheckedItems[iTemp]));
				CurActionLabel.Text = "Checking " + CheckedListBox.CheckedItems[iTemp] + " ...";
				this.Update(); // CurActionLabel.Update()

				switch (CheckedListBox.CheckedItems[iTemp])
				{
					case "ai.obj"           // ai.obj
				   :
						{

							// AI.obj Checker
							while (inFile.EndOfStream != true)
							{
								sTemp = inFile.ReadLine();
								ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);

								if (Strings.InStr(sTemp, ".htm") != 0)
								{
									sTemp2 = sTemp.Trim().Remove(0, Strings.InStr(sTemp, "\"") - 1).Replace("\"", "");

									// Common function for write error
									if (Array.IndexOf(HtmlFiles, sTemp2) == -1)
									{
										if (Array.IndexOf(HtmlMissed, sTemp2) == -1)
										{
											MissCount += 1;
											HtmlMissed[MissCount] = sTemp2;
											outFile.WriteLine("Not found html:" + Constants.vbTab + sTemp2);
											if (WriteFullCheckBox.Checked == true)
												outFile.WriteLine("in line:" + Constants.vbNewLine + sTemp + Constants.vbNewLine);
											if (CreateHtmBox.Checked == true)
											{
												MakeMissed = new System.IO.StreamWriter(NewHtmlDir + @"\" + sTemp2, false, System.Text.Encoding.Unicode, 1);
												MakeMissed.WriteLine("<html><head>");
												MakeMissed.WriteLine("<body>");
												MakeMissed.WriteLine("If you see this message: say to Server Administrator about this message and how you open this dialog.");
												MakeMissed.WriteLine("</body></html>");
												MakeMissed.Close();
											}
										}
										else if (IgnoreMissDupCheckBox.Checked == false)
										{
											outFile.WriteLine("Not found html:" + Constants.vbTab + "'" + sTemp2 + "'");
											if (WriteFullCheckBox.Checked == true)
												outFile.WriteLine("in line:" + Constants.vbNewLine + sTemp + Constants.vbNewLine);
										}
									}
								}
							}

							break;
						}

					case "npcdata.txt"      // npcdata.txt
			 :
						{

							// NPCDATA Checker
							// npc_ai={[lector];{[fnHi]=[lector001.htm]};{[fnSell]=[lector002.htm]};{[fnBuy]=[lector003.htm]};{[fnUnableItemSell]=[lector005.htm]};{[fnYouAreChaotic]=[lector006.htm]};{[fnNowSiege]=[lector007.htm]};{[MoveAroundSocial]=0};{[MoveAroundSocial1]=110};{[MoveAroundSocial2]=150}}	

							int iTemp2;
							var aNpcParam = new string[1];

							while (inFile.EndOfStream != true)
							{
								sTemp = inFile.ReadLine();
								ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
								this.Update();
								sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "npc_ai").Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "");

								Array.Clear(aNpcParam, 0, aNpcParam.Length);
								aNpcParam = sTemp2.Split(Conversions.ToChar(";"));
								var loopTo3 = aNpcParam.Length - 1;
								for (iTemp2 = 0; iTemp2 <= loopTo3; iTemp2++)
								{
									if (Strings.InStr(aNpcParam[iTemp2], ".htm") != 0)
									{
										aNpcParam[iTemp2] = aNpcParam[iTemp2].Remove(0, Strings.InStr(aNpcParam[iTemp2], "=")).Replace("\"", "");

										sTemp2 = aNpcParam[iTemp2];
										// Common function for write error
										if (Array.IndexOf(HtmlFiles, sTemp2) == -1)
										{
											if (Array.IndexOf(HtmlMissed, sTemp2) == -1)
											{
												MissCount += 1;
												HtmlMissed[MissCount] = sTemp2;
												outFile.WriteLine("Not found html:" + Constants.vbTab + sTemp2);
												if (WriteFullCheckBox.Checked == true)
													outFile.WriteLine("in line:" + Constants.vbNewLine + sTemp + Constants.vbNewLine);
												if (CreateHtmBox.Checked == true)
												{
													MakeMissed = new System.IO.StreamWriter(NewHtmlDir + @"\" + sTemp2, false, System.Text.Encoding.Unicode, 1);
													MakeMissed.WriteLine("<html><head>");
													MakeMissed.WriteLine("<body>");
													MakeMissed.WriteLine("If you see this message: say to Server Administrator about this message and how you open this dialog.");
													MakeMissed.WriteLine("</body></html>");
													MakeMissed.Close();
												}
											}
											else if (IgnoreMissDupCheckBox.Checked == false)
											{
												outFile.WriteLine("Not found html:" + Constants.vbTab + "'" + sTemp2 + "'");
												if (WriteFullCheckBox.Checked == true)
													outFile.WriteLine("in line:" + Constants.vbNewLine + sTemp + Constants.vbNewLine);
											}
										}
									}
								}
							}

							break;
						}

					case "itemdata.txt"     // itemdata.txt
			 :
						{

							// ITEMDATA Checker
							// ....enchanted=0	html=[item_default.htm]	equip_pet={0}...
							while (inFile.EndOfStream != true)
							{
								sTemp = inFile.ReadLine();
								ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
								this.Update();
								sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "html").Replace("[", "").Replace("]", "");

								if (!string.IsNullOrEmpty(sTemp2))
								{

									// Common function for write error
									if (Array.IndexOf(HtmlFiles, sTemp2) == -1)
									{
										if (Array.IndexOf(HtmlMissed, sTemp2) == -1)
										{
											MissCount += 1;
											HtmlMissed[MissCount] = sTemp2;
											outFile.WriteLine("Not found html:" + Constants.vbTab + sTemp2);
											if (WriteFullCheckBox.Checked == true)
												outFile.WriteLine("in line:" + Constants.vbNewLine + sTemp + Constants.vbNewLine);
											if (CreateHtmBox.Checked == true)
											{
												MakeMissed = new System.IO.StreamWriter(NewHtmlDir + @"\" + sTemp2, false, System.Text.Encoding.Unicode, 1);
												MakeMissed.WriteLine("<html><head>");
												MakeMissed.WriteLine("<body>");
												MakeMissed.WriteLine("If you see this message: say to Server Administrator about this message and how you open this dialog.");
												MakeMissed.WriteLine("</body></html>");
												MakeMissed.Close();
											}
										}
										else if (IgnoreMissDupCheckBox.Checked == false)
										{
											outFile.WriteLine("Not found html:" + Constants.vbTab + "'" + sTemp2 + "'");
											if (WriteFullCheckBox.Checked == true)
												outFile.WriteLine("in line:" + Constants.vbNewLine + sTemp + Constants.vbNewLine);
										}
									}
								}
							}

							break;
						}
				}

				inFile.Close();
				this.Refresh();
			}

			// HTML folder checker
			// <font color="LEVEL">harbor</font>.<br><a action="link abel002.htm">Ask abo
			if (HtmlDirCheckBox.Checked == true)
			{
				int Pos1;
				int Pos2;
				outFile.WriteLine(Constants.vbNewLine + "File: HTML folder ...");
				CurActionLabel.Text = "Checking HTML folder ...";
				this.Update();

				ProgressBar.Maximum = HtmlFiles.Length - 1;
				ProgressBar.Value = 0;
				var loopTo4 = HtmlFiles.Length - 1;
				for (iTemp = 0; iTemp <= loopTo4; iTemp++)
				{
					inFile = new System.IO.StreamReader(HtmlDir + @"\" + HtmlFiles[iTemp], System.Text.Encoding.Default, true, 1);
					ProgressBar.Value = iTemp;

					while (inFile.EndOfStream != true)
					{
						// sTemp = inFile.ReadLine

						sTemp = inFile.ReadToEnd();

						// Pos1 = InStr(1, sTemp, "<a action=")
						Pos1 = Strings.InStr(1, sTemp, "\"link ");
						while (Pos1 > 0)
						{
							Pos2 = Strings.InStr(Pos1 + 1, sTemp, "\"");
							if (Pos2 == 0)
							{
								outFile.WriteLine("HTML parser found error in file: " + HtmlFiles[iTemp] + Constants.vbNewLine);
								break;
							}
							sTemp2 = Strings.Mid(sTemp, Pos1 + 6, Pos2 - Pos1 - 6); // .Trim

							if (Strings.InStr(sTemp2, "#") != 0)
								sTemp2 = sTemp2.Remove(Strings.InStr(sTemp2, "#") - 1, sTemp2.Length - Strings.InStr(sTemp2, "#") + 1);

							if (Strings.InStr(sTemp2, "tutorial_close_") != 0)
								sTemp2 = "";

							// Common function for write error
							if (Array.IndexOf(HtmlFiles, sTemp2) == -1 & !string.IsNullOrEmpty(sTemp2))
							{
								if (Array.IndexOf(HtmlMissed, sTemp2) == -1)
								{
									MissCount += 1;
									HtmlMissed[MissCount] = sTemp2;
									outFile.WriteLine("Not found html:" + Constants.vbTab + "'" + sTemp2 + "'" + Constants.vbTab + "in html file: " + HtmlFiles[iTemp]);
									// outFile.WriteLine("Not found html:" & vbTab & sTemp2)
									// outFile.WriteLine("in html file:" & vbTab & HtmlFiles(iTemp) & vbNewLine)
									if (CreateHtmBox.Checked == true)
									{
										try
										{
											MakeMissed = new System.IO.StreamWriter(NewHtmlDir + @"\" + sTemp2, false, System.Text.Encoding.Unicode, 1);
											MakeMissed.WriteLine("<html><head>");
											MakeMissed.WriteLine("<body>");
											MakeMissed.WriteLine("If you see this message: say to Server Administrator about this message and how you open this dialog.");
											MakeMissed.WriteLine("</body></html>");
											MakeMissed.Close();
										}
										catch (Exception ex)
										{
											outFile.WriteLine("HTML parser found bad html file name: " + HtmlFiles[iTemp]);
											break;
										}
									}
								}
								else if (IgnoreMissDupCheckBox.Checked == false)
									outFile.WriteLine("Not found html:" + Constants.vbTab + "'" + sTemp2 + "'" + Constants.vbTab + "in html file: " + HtmlFiles[iTemp]);
							}
							// Common function for write error

							Pos1 = Strings.InStr(Pos2, sTemp, "\"link ");
						}
						Pos1 = 0; Pos2 = 0;
					}
					inFile.Close();
				}
			}

			outFile.WriteLine(Constants.vbNewLine + "Missed:" + Constants.vbTab + Conversions.ToString(MissCount + 1));
			outFile.WriteLine(Constants.vbNewLine + Conversions.ToString(DateAndTime.Now) + " End of checking." + Constants.vbNewLine);
			outFile.Close();
			ProgressBar.Value = 0;
			CurActionLabel.Text = "Complete.";
			MessageBox.Show("Checking complete.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
