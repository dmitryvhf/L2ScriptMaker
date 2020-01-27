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

namespace L2ScriptMaker.Modules.Npc
{
	public partial class NpcposManorZoneGenerator : Form
	{
		public NpcposManorZoneGenerator()
		{
			InitializeComponent();
		}

		private struct GeoMinMax
		{
			public int XMin;
			public int XMax;
			public int YMin;
			public int YMax;
			public int ZMin; // lower then max -3900
			public int ZMax; // more then min +2000
			public string Castle;
			public int CastleId;
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			int iTemp;
			int iTemp1;
			int iTemp2;
			short iDomain;
			int LocationFix = Conversions.ToInteger(SafeRangeTextBox.Text);   // Fix for range to inside for bug fixing with zone links

			var Geos = new GeoMinMax[27, 27];

			if (DataGridView.Rows.Count == 1)
			{
				MessageBox.Show("You need define location and castle for each location before processing.", "Wrong definition", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			OpenFileDialog.FileName = "npcpos.txt";
			if (MetodCheckBox.Checked == true)
			{
				OpenFileDialog.Filter = "Lineage II Server npc spawn config (npcpos.txt)|npcpos*.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
			}

			SaveFileDialog.FileName = System.IO.Path.GetFileNameWithoutExtension(OpenFileDialog.FileName) + "_manor_zone.txt";
			SaveFileDialog.Filter = "Lineage II Server npc spawn config (npcpos.txt)|npcpos*.txt|All files|*.*";
			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			var loopTo = DataGridView.Rows.Count - 2;


			// Loading Castle Names control location (set castle id to each location)
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				Geos[Convert.ToInt32(DataGridView[0, iTemp].Value), Convert.ToInt32(DataGridView[1, iTemp].Value)].Castle = DataGridView[2, iTemp].Value.ToString();
				Geos[Convert.ToInt32(DataGridView[0, iTemp].Value), Convert.ToInt32(DataGridView[1, iTemp].Value)].CastleId = CastleName.Items.IndexOf(DataGridView[2, iTemp].Value.ToString()) + 1;
				if (MetodCheckBox.Checked == false)
				{
					// SIMPLE METOD
					Geos[Convert.ToInt32(DataGridView[0, iTemp].Value), Convert.ToInt32(DataGridView[1, iTemp].Value)].XMin = (Convert.ToInt32(DataGridView[0, iTemp].Value) - 20) * 32768 + LocationFix;
					Geos[Convert.ToInt32(DataGridView[0, iTemp].Value), Convert.ToInt32(DataGridView[1, iTemp].Value)].XMax = (Convert.ToInt32(DataGridView[0, iTemp].Value) - 19) * 32768 - LocationFix;
					Geos[Convert.ToInt32(DataGridView[0, iTemp].Value), Convert.ToInt32(DataGridView[1, iTemp].Value)].YMin = (Convert.ToInt32(DataGridView[1, iTemp].Value) - 18) * 32768 + LocationFix;
					Geos[Convert.ToInt32(DataGridView[0, iTemp].Value), Convert.ToInt32(DataGridView[1, iTemp].Value)].YMax = (Convert.ToInt32(DataGridView[1, iTemp].Value) - 17) * 32768 - LocationFix;
					Geos[Convert.ToInt32(DataGridView[0, iTemp].Value), Convert.ToInt32(DataGridView[1, iTemp].Value)].ZMin = 2500;
					Geos[Convert.ToInt32(DataGridView[0, iTemp].Value), Convert.ToInt32(DataGridView[1, iTemp].Value)].ZMax = -2500;
				}
			}

			if (MetodCheckBox.Checked == false)
			{
			}
			else
			{
				// USE NPCPOS METOD

				// Definition min, max to center location
				for (iTemp1 = 16; iTemp1 <= 26; iTemp1++)
				{
					for (iTemp2 = 10; iTemp2 <= 26; iTemp2++)
					{
						Geos[iTemp1, iTemp2].XMin = (iTemp1 - 20) * 32768 + 16384;
						Geos[iTemp1, iTemp2].XMax = (iTemp1 - 19) * 32768 - 16384;
						Geos[iTemp1, iTemp2].YMin = (iTemp2 - 18) * 32768 + 16384;
						Geos[iTemp1, iTemp2].YMax = (iTemp2 - 17) * 32768 - 16384;
					}
				}

				var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);
				string sTemp;
				string[] aTemp1;
				string[] aTemp2;
				int LocX;
				int LocY;

				int iTempZ;

				ToolStripProgressBar.Value = 0;
				ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
				while (inFile.EndOfStream != true)
				{
					sTemp = inFile.ReadLine();
					ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);

					if (sTemp.StartsWith("territory_begin") == true)
					{
						sTemp = sTemp.Remove(0, Strings.InStr(sTemp, "{") - 1);
						sTemp = sTemp.Replace("territory_end", "").Trim();
						sTemp = sTemp.Replace("};{", "|").Replace("{", "").Replace("}", "");
						aTemp1 = sTemp.Split(Conversions.ToChar("|"));
						var loopTo1 = aTemp1.Length - 1;
						for (iTemp2 = 0; iTemp2 <= loopTo1; iTemp2++)
						{
							aTemp2 = aTemp1[iTemp2].Split(Conversions.ToChar(";"));

							// Define location name
							LocX = Conversions.ToInteger(Conversions.Fix(20 + (Conversions.ToInteger(aTemp2[0]) - Conversions.ToInteger(aTemp2[0]) / 32768) / (double)32768));
							LocY = Conversions.ToInteger(Conversions.Fix(18 + (Conversions.ToInteger(aTemp2[1]) - Conversions.ToInteger(aTemp2[1]) / 32768) / (double)32768));

							// Check each value
							if (Geos[LocX, LocY].XMin > Conversions.ToInteger(aTemp2[0]))
								Geos[LocX, LocY].XMin = Conversions.ToInteger(aTemp2[0]);
							if (Geos[LocX, LocY].XMax < Conversions.ToInteger(aTemp2[0]))
								Geos[LocX, LocY].XMax = Conversions.ToInteger(aTemp2[0]);
							if (Geos[LocX, LocY].YMin > Conversions.ToInteger(aTemp2[1]))
								Geos[LocX, LocY].YMin = Conversions.ToInteger(aTemp2[1]);
							if (Geos[LocX, LocY].YMax < Conversions.ToInteger(aTemp2[1]))
								Geos[LocX, LocY].YMax = Conversions.ToInteger(aTemp2[1]);

							if (Geos[LocX, LocY].ZMin == 0 & Geos[LocX, LocY].ZMax == 0)
							{
								Geos[LocX, LocY].ZMin = Conversions.ToInteger(aTemp2[2]);
								Geos[LocX, LocY].ZMax = Conversions.ToInteger(aTemp2[3]);
							}

							// Fix for MinZ > MaxZ
							if (Conversions.ToInteger(aTemp2[2]) > Conversions.ToInteger(aTemp2[3]))
							{
								iTempZ = Conversions.ToInteger(aTemp2[2]);
								aTemp2[2] = aTemp2[3];
								aTemp2[3] = Conversions.ToString(iTempZ);
							}
							if (Conversions.ToInteger(aTemp2[2]) < Geos[LocX, LocY].ZMin)
								Geos[LocX, LocY].ZMin = Conversions.ToInteger(aTemp2[2]);
							if (Conversions.ToInteger(aTemp2[3]) > Geos[LocX, LocY].ZMax)
								Geos[LocX, LocY].ZMax = Conversions.ToInteger(aTemp2[3]);
						}
					}
				}
				inFile.Close();
				ToolStripProgressBar.Value = 0;
			}


			// ---- Generation Manor Zone file ----
			var outFile = new System.IO.StreamWriter(SaveFileDialog.FileName, false, System.Text.Encoding.Unicode, 1);

			short doUnknown = Conversions.ToShort(1);

			if (DoUnknownCheckBox.Checked == true & MetodCheckBox.Checked == true)
				doUnknown = Conversions.ToShort(0);

			// No use shifts for Autogen file (no use npcpos).
			if (MetodCheckBox.Checked == false)
				LocationFix = 0;

			outFile.WriteLine("// Castle Manor domain generated by L2SciptMaker at " + DateAndTime.Now.ToString());
			for (iDomain = doUnknown; iDomain <= 9; iDomain++)
			{
				if (iDomain > 0)
					outFile.WriteLine("// " + CastleName.Items[(int)iDomain - 1].ToString() + " manor domain");

				for (iTemp = 16; iTemp <= 26; iTemp++)        // X
				{
					for (iTemp2 = 10; iTemp2 <= 26; iTemp2++)   // Y
					{
						if (Geos[iTemp, iTemp2].CastleId == iDomain)
						{
							if (Geos[iTemp, iTemp2].XMin != Geos[iTemp, iTemp2].XMax)
							{
								// domain_begin	[schtgart_2311_001]	domain_id=9	{{98560;-228352;-4672;816};{130816;-228480;-4672;816};{130944;-196736;-4672;816};{98816;-196736;-4672;816}}	domain_end
								outFile.Write("domain_begin" + Constants.vbTab);

								if (iDomain == 0)
									outFile.Write("[location" + "_" + Conversions.ToString(iTemp) + Conversions.ToString(iTemp2) + "_001]" + Constants.vbTab);
								else
									outFile.Write("[" + Geos[iTemp, iTemp2].Castle.ToLower() + "_" + Conversions.ToString(iTemp) + Conversions.ToString(iTemp2) + "_001]" + Constants.vbTab);
								outFile.Write("domain_id=" + Conversions.ToString(iDomain) + Constants.vbTab);
								outFile.Write("{");
								outFile.Write("{" + Conversions.ToString(Geos[iTemp, iTemp2].XMin - LocationFix) + ";" + Conversions.ToString(Geos[iTemp, iTemp2].YMin - LocationFix) + ";" + Conversions.ToString(Geos[iTemp, iTemp2].ZMin) + ";" + Conversions.ToString(Geos[iTemp, iTemp2].ZMax) + "};");
								outFile.Write("{" + Conversions.ToString(Geos[iTemp, iTemp2].XMax + LocationFix) + ";" + Conversions.ToString(Geos[iTemp, iTemp2].YMin - LocationFix) + ";" + Conversions.ToString(Geos[iTemp, iTemp2].ZMin) + ";" + Conversions.ToString(Geos[iTemp, iTemp2].ZMax) + "};");
								outFile.Write("{" + Conversions.ToString(Geos[iTemp, iTemp2].XMax + LocationFix) + ";" + Conversions.ToString(Geos[iTemp, iTemp2].YMax + LocationFix) + ";" + Conversions.ToString(Geos[iTemp, iTemp2].ZMin) + ";" + Conversions.ToString(Geos[iTemp, iTemp2].ZMax) + "};");
								outFile.Write("{" + Conversions.ToString(Geos[iTemp, iTemp2].XMin - LocationFix) + ";" + Conversions.ToString(Geos[iTemp, iTemp2].YMax + LocationFix) + ";" + Conversions.ToString(Geos[iTemp, iTemp2].ZMin) + ";" + Conversions.ToString(Geos[iTemp, iTemp2].ZMax) + "}");
								outFile.Write("}" + Constants.vbTab);
								outFile.Write("domain_end");

								if ((Geos[iTemp, iTemp2].ZMax - Geos[iTemp, iTemp2].ZMin) * Math.Sign(Geos[iTemp, iTemp2].ZMax - Geos[iTemp, iTemp2].ZMin) > 6000)
									outFile.Write(Constants.vbTab + "// Foung big Z range (more then 6000). Required Z splitting.");
								outFile.WriteLine();
							}
						}
					}
				}
			}
			outFile.Close();
			// ---- END OF Generation Manor Zone file ----

			MessageBox.Show("done");
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void LoadCastleControlButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog.Filter = "Manor Castle Control Locations config|*.ini|All files|*.*";
			// OpenFileDialog.FileName = "manor_castle_control_locations.ini"
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			string sTemp;
			int iTemp;
			var aTemp = new string[4];

			var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);
			if ((inFile.ReadLine() ?? "") != "[L2ScriptMaker: Manor Castle Control Locations config]")
			{
				MessageBox.Show("This is not configuration file", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				inFile.Close();
				return;
			}

			DataGridView.Rows.Clear();

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine().Trim();
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{
					aTemp = sTemp.Split(Conversions.ToChar(","));
					try
					{
						iTemp = Conversions.ToInteger(aTemp[0]);
						if (iTemp == 0) throw new Exception("1");       // !! check logic

						// #error Cannot convert ErrorStatementSyntax - see comment for details

						/* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error 1' at character 11890
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
						Error 1

						 */
						iTemp = Conversions.ToInteger(aTemp[1]);
						if (iTemp == 0) throw new Exception("2");		// !! check logic
						
						// #error Cannot convert ErrorStatementSyntax - see comment for details
						/* Cannot convert ErrorStatementSyntax, CONVERSION ERROR: Conversion for ErrorStatement not implemented, please report this issue in 'Error 2' at character 11981
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
						Error 2

						 */
					}
					catch (Exception ex)
					{
						MessageBox.Show("Wrong definition for location id. " + ex.Message, "Wrong geo definition", MessageBoxButtons.OK, MessageBoxIcon.Error);
						inFile.Close();
						return;
					}
					if (CastleName.Items.IndexOf(aTemp[2]) == -1)
					{
						MessageBox.Show("Invalid Castle Town name. Check available names in checkbox, fix config and try again", "Invalid Castle Town name", MessageBoxButtons.OK, MessageBoxIcon.Error);
						inFile.Close();
						return;
					}
					DataGridView.Rows.Add(aTemp[0], aTemp[1], aTemp[2]);
				}
			}
			inFile.Close();
		}

		private void SafeRangeTextBox_Validated(object sender, EventArgs e)
		{
			try
			{
				SafeRangeTextBox.Text = Conversions.ToString(Conversions.ToInteger(SafeRangeTextBox.Text));
			}
			catch (Exception ex)
			{
				SafeRangeTextBox.Text = "2000";
			}
		}
	}
}
