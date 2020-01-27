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
	public partial class NpcPosShifter : Form
	{
		public NpcPosShifter()
		{
			InitializeComponent();
		}

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			string PosFile;
			int XS;
			int YS;
			int ZS;

			XS = Conversions.ToInteger(Conversions.Val(XShift.Text.ToString()));
			YS = Conversions.ToInteger(Conversions.Val(YShift.Text.ToString()));
			ZS = Conversions.ToInteger(Conversions.Val(ZShift.Text.ToString()));
			if ((int)MessageBox.Show("You sure start conversion use this shifting for:" + Constants.vbNewLine + "X: " + Conversions.ToString(XS) + " | Y: " + Conversions.ToString(YS) + " |Z: " + Conversions.ToString(ZS), "Confirm start", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == (int)DialogResult.Cancel)
				return;

			OpenFileDialog.Title = "Select Lineage II npcpos file";
			OpenFileDialog.Filter = "Lineage II npcpos file|npcpos.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			PosFile = OpenFileDialog.FileName;

			var inFile = new System.IO.StreamReader(PosFile);
			var outFile = new System.IO.StreamWriter(PosFile + ".new.txt", false, System.Text.Encoding.Unicode);

			string TempRead;

			var locArr = new string[6];
			int Pos1;
			int Pos2;

			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);

			while (inFile.EndOfStream != true)
			{
				TempRead = inFile.ReadLine();
				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);

				while (Strings.InStr(TempRead, "  ") != 0)
					TempRead = TempRead.Replace("  ", " ");
				TempRead = TempRead.Replace(" = ", "=");
				TempRead = TempRead.Replace(" ", Conversions.ToString((char)9));

				int LastMarker;


				if (TempRead.Length > 1)
				{
					if (Strings.InStr(TempRead, "pos=") != 0)
						LastMarker = Strings.InStr(Strings.InStr(TempRead, "pos=") + 5, TempRead, Conversions.ToString((char)9));
					else
						LastMarker = TempRead.Length;

					// find end of pos

					Pos1 = 1;

					while (Strings.InStr(Pos1, TempRead, "{", CompareMethod.Text) != 0)
					{
						Pos1 = Strings.InStr(Pos1 + 1, TempRead, "{", CompareMethod.Text);
						if (Conversions.ToString(TempRead[Pos1]) == "{")
							Pos1 += 1;
						Pos2 = Strings.InStr(Pos1, TempRead, "}", CompareMethod.Text);

						if (Pos1 > LastMarker)
							break;

						locArr = Strings.Mid(TempRead, Pos1 + 1, Pos2 - Pos1 - 1).Split((char)59);  // 59 - ;

						string NewValue;
						NewValue = (Conversions.ToInteger(locArr[0]) + XS).ToString() + ";" + (Conversions.ToInteger(locArr[1]) + YS).ToString() + ";" + (Conversions.ToInteger(locArr[2]) + ZS).ToString() + ";" + locArr[3];
						if (locArr.Length > 4)
							NewValue = NewValue + ";" + locArr[4];

						TempRead = TempRead.Replace(Strings.Mid(TempRead, Pos1 + 1, Pos2 - Pos1 - 1), NewValue);

						Pos1 += 1;
						Array.Clear(locArr, 0, locArr.Length);
					}
				}

				outFile.WriteLine(TempRead);
			}

			inFile.Close();
			outFile.Close();

			MessageBox.Show("Done.");
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
