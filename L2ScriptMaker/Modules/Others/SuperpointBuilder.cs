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
	public partial class SuperpointBuilder : Form
	{
		public SuperpointBuilder()
		{
			InitializeComponent();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			string sBinFile;

			OpenFileDialog.Filter = "Superpoint.bin|Superpoint.bin|All Files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sBinFile = OpenFileDialog.FileName;

			var inFile = new System.IO.StreamReader(sBinFile, System.Text.Encoding.GetEncoding(1250), false, 1);
			var outFile = new System.IO.StreamWriter(sBinFile + ".log", false, System.Text.Encoding.Unicode, 1);

			string sTempStr = "";
			int iTemp = 0;
			int iTempSP;
			int SuperPointsValue;
			int PointsInSuperpoint;

			SuperPointsValue = endian(Conversions.ToShort(4), ref inFile);
			outFile.WriteLine("Amount of Superpoints is: " + Conversions.ToString(SuperPointsValue));
			var loopTo = SuperPointsValue;
			for (iTempSP = 1; iTempSP <= loopTo; iTempSP++)
			{
				sTempStr = textread(Conversions.ToShort(4), ref inFile);

				outFile.WriteLine(Constants.vbNewLine + "[" + sTempStr + "]");
				outFile.WriteLine(endian(Conversions.ToShort(4), ref inFile));
				PointsInSuperpoint = endian(Conversions.ToShort(4), ref inFile);

				// Normal mode
				outFile.WriteLine("Points in this superpoint: " + Conversions.ToString(PointsInSuperpoint));
				var loopTo1 = PointsInSuperpoint - 1;
				for (iTemp = 0; iTemp <= loopTo1; iTemp++)
				{
					outFile.WriteLine("=================================");

					// Normal mode
					outFile.Write("index:" + Conversions.ToString((char)9) + Conversions.ToString(endian(Conversions.ToShort(4), ref inFile)) + ":" + Conversions.ToString((char)9));
					outFile.Write(endian(Conversions.ToShort(4), ref inFile));
					outFile.Write(";" + Conversions.ToString(endian(Conversions.ToShort(4), ref inFile)));
					outFile.WriteLine(";" + Conversions.ToString(endian(Conversions.ToShort(4), ref inFile)));
					outFile.WriteLine("delay:" + Conversions.ToString((char)9) + Conversions.ToString(endian(Conversions.ToShort(4), ref inFile)));
				}

				int iTemp2;
				int ConnMark;
				// Normal mode
				outFile.WriteLine(Constants.vbNewLine + "Connections:");
				var loopTo2 = Conversions.ToInteger(Math.Pow(PointsInSuperpoint, 2) - PointsInSuperpoint);
				for (iTemp = 1; iTemp <= loopTo2; iTemp++)
				{
					ConnMark = Conversions.ToInteger(endian(Conversions.ToShort(4), ref inFile));
					outFile.WriteLine("conn type:" + Conversions.ToString(ConnMark));
					if (ConnMark != 0)
					{
						var loopTo3 = ConnMark;
						for (iTemp2 = 1; iTemp2 <= loopTo3; iTemp2++)
						{
							// Normal mode
							outFile.Write(" index: " + Conversions.ToString(endian(Conversions.ToShort(4), ref inFile)) + ":" + Conversions.ToString((char)9));
							outFile.Write(Conversions.ToString(endian(Conversions.ToShort(4), ref inFile)) + ";");
							outFile.Write(Conversions.ToString(endian(Conversions.ToShort(4), ref inFile)) + ";");
							outFile.Write(endian(Conversions.ToShort(4), ref inFile));
							outFile.WriteLine("");
						}
					}
				}
			}

			inFile.Close();
			outFile.Close();

			MessageBox.Show("Superpoint.bin research finished. Report wrote to " + sBinFile + ".log file.", "Complete", MessageBoxButtons.OK);
		}


		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}


		private int endian(short Bytes, ref System.IO.StreamReader inFile)
		{
			int endianRet = default(int);
			int iByteRead;
			var cReadBuff = new byte[Bytes - 1 + 1];
			string HexDigit = "";

			inFile.BaseStream.Read(cReadBuff, 0, Bytes);

			for (iByteRead = Bytes - 1; iByteRead >= 0; iByteRead += -1)
				HexDigit = HexDigit + Conversions.Hex(cReadBuff[iByteRead]).PadLeft(2, Convert.ToChar("0")).ToString();

			if ((HexDigit ?? "") == "FFFFFFFF")
				endianRet = -1;
			else if (HexDigit.StartsWith("FF"))
				endianRet = Conversions.ToInteger(Conversions.Val("&h" + HexDigit));
			else
				endianRet = Conversions.ToInteger(Conversions.ToLong("&h" + HexDigit));

			// If cReadBuff(Bytes - 1) >= 8 And Bytes > 1 Then
			// endian = -((Not endian) + 1)
			// End If

			return endianRet;
		}

		private bool unendian(int Bytes, int Value, ref System.IO.Stream outFile)
		{
			int iTemp;
			var aMsgByte = new byte[Bytes - 1 + 1];

			if (Value == -1)
			{
				aMsgByte[0] = Conversions.ToByte(255);
				aMsgByte[1] = Conversions.ToByte(255);
				aMsgByte[2] = Conversions.ToByte(255);
				aMsgByte[3] = Conversions.ToByte(255);
				outFile.Write(aMsgByte, 0, 4);
				return true;
			}

			// If Value = 51462 Then Dim asds As Integer = 1281

			string sTemp = Conversions.Hex(Value);
			sTemp = sTemp.PadLeft(Bytes * 2, Convert.ToChar("0"));
			var loopTo = Bytes - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
				// Dim aaa As String = "&H" & Mid(sTemp, (Bytes * 2 - iTemp * 2) - 1, 2)
				// Dim aaass As Integer = CInt("&H" & Mid(sTemp, (Bytes * 2 - iTemp * 2) - 1, 2))
				// Dim aaass2 As Char = Convert.ToChar(CInt("&H" & Mid(sTemp, (Bytes * 2 - iTemp * 2) - 1, 2)))

				aMsgByte[iTemp] = Conversions.ToByte(Conversions.Val("&H" + Strings.Mid(sTemp, Bytes * 2 - iTemp * 2 - 1, 2)));
			outFile.Write(aMsgByte, 0, Bytes);
			return true;
		}


		private string textread(short Bytes, ref System.IO.StreamReader iFile)
		{
			string TempStr = "";
			int iByteRead;
			int iTemp;
			var cReadBuff = new char[2];

			var bReadBuff2 = new byte[2];

			iByteRead = endian(Bytes, ref iFile);
			if (iByteRead == 0)
				return "";
			var loopTo = iByteRead - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				iFile.BaseStream.Read(bReadBuff2, 0, 2);
				TempStr = TempStr + Conversions.ToString((char)bReadBuff2[0]);
			}

			return TempStr;
		}

		private bool textwrite(string Message, ref System.IO.Stream outFile)
		{
			int iTemp;
			var aMsgByte = new byte[1];

			unendian(4, Message.Length, ref outFile);
			if (!string.IsNullOrEmpty(Message))
			{
				var loopTo = Message.Length - 1;
				for (iTemp = 0; iTemp <= loopTo; iTemp++)
				{
					Array.Resize(ref aMsgByte, Message.Length * 2);
					aMsgByte[iTemp * 2] = Conversions.ToByte(Strings.Asc(Message[iTemp]));
					aMsgByte[iTemp * 2 + 1] = Conversions.ToByte(0);
				}
			}
			// Zero end of string
			// aMsgByte(iTemp * 2) = Chr(0)
			outFile.Write(aMsgByte, 0, Message.Length * 2);

			return true;
		}

		private void GenerateButton_Click(object sender, EventArgs e)
		{
			string sBinFile;

			OpenFileDialog.Filter = "Superpoint.bin.log|Superpoint.bin.log|All Files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sBinFile = OpenFileDialog.FileName;

			// If System.IO.File.Exists(sBinFile + ".bin") = True Then
			// If MessageBox.Show("Output file exist. Overwrite?", "Exist file", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then Exit Sub
			// System.IO.File.Delete(sBinFile + ".bin")
			// End If

			var inFile = new System.IO.StreamReader(sBinFile, System.Text.Encoding.Default, true, 1);
			// Dim outFile As New System.IO.StreamWriter(sBinFile + ".bin", False, System.Text.Encoding.GetEncoding(1250), 1)

			// FOR Release 
			sBinFile = sBinFile.Replace(".bin.log", ".bin");
			System.IO.Stream outFile = new System.IO.FileStream(sBinFile, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite);
			// Dim outFile As System.IO.StreamWriter = New System.IO.StreamWriter(outFil)

			string sTemp = "";
			int iTemp;
			var aTemp = new string[3]; // , iTempSP As Integer, SuperPointsValue As Integer, PointsInSuperpoint As Integer

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine().Replace(" ", "").Replace(Conversions.ToString((char)9), "");

				if (Strings.InStr(sTemp, "Superpoints") != 0)
				{
					// Superpoints: 16
					iTemp = Conversions.ToInteger(sTemp.Remove(0, Strings.InStr(sTemp, ":")).Trim());
					unendian(4, iTemp, ref outFile);        // full amount in superpoint.bin
				}

				if (Strings.InStr(sTemp, "[") != 0)
				{
					// [scribe_leandro]
					textwrite(sTemp.Replace("[", "").Replace("]", "").Trim(), ref outFile);     // name of superpoint
					unendian(4, 0, ref outFile);         // unknown param
				}

				if (Strings.InStr(sTemp, "Points") != 0)
				{
					// Points in this superpoint:	11
					iTemp = Conversions.ToInteger(sTemp.Remove(0, Strings.InStr(sTemp, ":")).Trim());
					unendian(4, iTemp, ref outFile);        // full amount in superpoint.bin
				}

				if (Strings.InStr(sTemp, "index:") != 0)
				{
					// index:	0:	-82428;245204;-3712
					aTemp = sTemp.Split(Conversions.ToChar(":"));
					unendian(4, Conversions.ToInteger(aTemp[1]), ref outFile);    // index number
					aTemp = aTemp[2].Split(Conversions.ToChar(";"));
					unendian(4, Conversions.ToInteger(aTemp[0]), ref outFile);    // x
					unendian(4, Conversions.ToInteger(aTemp[1]), ref outFile);    // y
					unendian(4, Conversions.ToInteger(aTemp[2]), ref outFile);    // z
				}

				if (Strings.InStr(sTemp, "delay:") != 0)
				{
					// Points in this superpoint:	11
					iTemp = Conversions.ToInteger(sTemp.Remove(0, Strings.InStr(sTemp, ":")).Trim());
					unendian(4, iTemp, ref outFile);        // delay
				}

				if (Strings.InStr(sTemp, "conntype:") != 0)
				{
					// conn type:2
					iTemp = Conversions.ToInteger(sTemp.Remove(0, Strings.InStr(sTemp, ":")).Trim());
					unendian(4, iTemp, ref outFile);        // conn type
				}
			}

			inFile.Close();
			outFile.Close();

			MessageBox.Show("New Superpoint.bin has been created in '" + sBinFile + "' file.", "Complete", MessageBoxButtons.OK);
		}

		private void MakeNewButton_Click(object sender, EventArgs e)
		{
			int iTemp;
			// dim sTemp as String

			// [scribe_leandro]
			// 0
			// Points in this superpoint: 11
			// =================================
			// index:	0:	-82428;245204;-3712
			// delay:	0

			if (DataGridView.RowCount - 2 < 1)
			{
				MessageBox.Show("SuperPath cant be generate from 1 point. Need enter more them 1 point and try again", "Need more points", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (string.IsNullOrEmpty(StartNumberTextBox.Text))
			{
				MessageBox.Show("Invalid start point number. Try correct number and try again.", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int Counter = Conversions.ToInteger(StartNumberTextBox.Text);

			if (string.IsNullOrEmpty(NpcNameTextBox.Text))
			{
				MessageBox.Show("Invalid npc name. Try correct name and try again.", "Invalid npc name", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (NpcNameTextBox.Text.StartsWith("[") == false)
				NpcNameTextBox.Text = "[" + NpcNameTextBox.Text + "]";

			MakeNewTextBox.Text = "";
			MakeNewTextBox.AppendText(NpcNameTextBox.Text + Constants.vbNewLine);
			MakeNewTextBox.AppendText("0" + Constants.vbNewLine);
			MakeNewTextBox.AppendText("Points in this superpoint: " + (DataGridView.RowCount - 1).ToString() + Constants.vbNewLine);

			var PointList = new string[DataGridView.RowCount - 2 + 1];
			var loopTo = DataGridView.RowCount - 2;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				MakeNewTextBox.AppendText("=================================" + Constants.vbNewLine);
				if (DataGridView[0, iTemp].Value == null)
				{
					MessageBox.Show("Bad value! in 1;" + Conversions.ToString(iTemp) + " cell");
					return;
				}
				if (DataGridView[1, iTemp].Value == null)
				{
					MessageBox.Show("Bad value! in 2;" + Conversions.ToString(iTemp) + " cell");
					return;
				}
				if (DataGridView[2, iTemp].Value == null)
				{
					MessageBox.Show("Bad value! in 3;" + Conversions.ToString(iTemp) + " cell");
					return;
				}
				if (DataGridView[3, iTemp].Value == null)
					DataGridView[3, iTemp].Value = "0";

				PointList[iTemp] = DataGridView[0, iTemp].Value.ToString() + ";" + DataGridView[1, iTemp].Value.ToString() + ";" + DataGridView[2, iTemp].Value.ToString();

				// MakeNewTextBox.AppendText("index:" & vbTab & (Counter + iTemp) & vbTab & _
				// DataGridView.Item(0, iTemp).Value.ToString & ";" & DataGridView.Item(1, iTemp).Value.ToString & ";" & _
				// DataGridView.Item(2, iTemp).Value.ToString & vbNewLine)
				MakeNewTextBox.AppendText("index:" + Constants.vbTab + Conversions.ToString(Counter + iTemp) + ":" + Constants.vbTab + PointList[iTemp] + Constants.vbNewLine);
				MakeNewTextBox.AppendText("delay:" + Constants.vbTab + DataGridView[3, iTemp].Value.ToString() + Constants.vbNewLine);
			}

			// Connections:
			MakeNewTextBox.AppendText(Constants.vbNewLine + "Connections:" + Constants.vbNewLine);
			// conn type:2 --------------------------------> Connection: 11 - 12 (Note: 11 - 11 Never)
			// index: 11: -81926;243894;-3712
			// index: 12: -82134;243600;-3728
			// conn type:0 --------------------------------> Connection: 11 - 13
			int iTemp2;
			var loopTo1 = DataGridView.RowCount - 2;
			for (iTemp = 0; iTemp <= loopTo1; iTemp++)
			{
				var loopTo2 = DataGridView.RowCount - 2;
				for (iTemp2 = 0; iTemp2 <= loopTo2; iTemp2++)
				{
					if (iTemp != iTemp2)
					{
						if (iTemp2 == iTemp - 1 | iTemp2 == iTemp + 1)
						{
							MakeNewTextBox.AppendText("conn type:2" + Constants.vbNewLine);
							if (iTemp2 == iTemp - 1)
							{
								MakeNewTextBox.AppendText(" index:" + Constants.vbTab + Conversions.ToString(Counter + iTemp) + ":" + Constants.vbTab + PointList[iTemp] + Constants.vbNewLine);
								MakeNewTextBox.AppendText(" index:" + Constants.vbTab + Conversions.ToString(Counter + iTemp - 1) + ":" + Constants.vbTab + PointList[iTemp - 1] + Constants.vbNewLine);
							}
							else
							{
								MakeNewTextBox.AppendText(" index:" + Constants.vbTab + Conversions.ToString(Counter + iTemp) + ":" + Constants.vbTab + PointList[iTemp] + Constants.vbNewLine);
								MakeNewTextBox.AppendText(" index:" + Constants.vbTab + Conversions.ToString(Counter + iTemp + 1) + ":" + Constants.vbTab + PointList[iTemp + 1] + Constants.vbNewLine);
							}
						}
						else if (GenAllCheckBox.Checked == false)
							MakeNewTextBox.AppendText("conn type:0" + Constants.vbNewLine);
						else if (iTemp2 < DataGridView.RowCount - 1)
						{
							MakeNewTextBox.AppendText("conn type:2" + Constants.vbNewLine);
							MakeNewTextBox.AppendText(" index:" + Constants.vbTab + Conversions.ToString(Counter + iTemp) + ":" + Constants.vbTab + PointList[iTemp] + Constants.vbNewLine);
							MakeNewTextBox.AppendText(" index:" + Constants.vbTab + Conversions.ToString(Counter + iTemp2) + ":" + Constants.vbTab + PointList[iTemp2] + Constants.vbNewLine);
						}
					}
				}
			}

			TabControl1.SelectedIndex = 4; // "Result"
		}

		private void LoadPointsButton_Click(object sender, EventArgs e)
		{
			DataGridView.Rows.Clear();

			int iTemp;
			string sTemp;
			var aTemp = new string[3];

			int Counter = -1;
			var loopTo = ImportPointsTextBox.Lines.Length - 1;

			// index:	0:	-82428;245204;-3712
			// delay:	0

			// NpcNameTextBox.Text
			// StartNumberTextBox.Text

			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				sTemp = ImportPointsTextBox.Lines.GetValue(iTemp).ToString();

				if (sTemp.StartsWith("["))
					NpcNameTextBox.Text = sTemp;

				if (sTemp.StartsWith("index:"))
				{
					sTemp = sTemp.Replace(" ", "").Replace(Conversions.ToString((char)9), "");
					Counter += 1;
					DataGridView.Rows.Add();

					// Loading points
					aTemp = sTemp.Split(Conversions.ToChar(":"));

					if (Counter == 0)
						StartNumberTextBox.Text = aTemp[1];

					aTemp = aTemp[2].Split(Conversions.ToChar(";"));
					DataGridView[0, Counter].Value = aTemp[0];
					DataGridView[1, Counter].Value = aTemp[1];
					DataGridView[2, Counter].Value = aTemp[2];

					// Loading delay
					sTemp = ImportPointsTextBox.Lines.GetValue(iTemp + 1).ToString().Replace(" ", "").Replace(Conversions.ToString((char)9), "");
					aTemp = sTemp.Split(Conversions.ToChar(":"));

					DataGridView[3, Counter].Value = aTemp[1];

					iTemp += 1;
				}
			}

			TabControl1.SelectedIndex = 2; // "SettingTabPage"
		}
	}
}
