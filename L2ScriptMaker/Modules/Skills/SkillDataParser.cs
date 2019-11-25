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
	public partial class SkillDataParser : Form
	{
		public SkillDataParser()
		{
			InitializeComponent();
		}

		private void ScanButton_Click(object sender, EventArgs e)
		{
			string sSkillFile;

			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II C4 Skill Script (skilldata.txt)|skilldata.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sSkillFile = OpenFileDialog.FileName;

			if (string.IsNullOrEmpty(ScanParamComboBox.Text.Trim()))
			{
				MessageBox.Show("Enter param name for researching and try again.", "No param", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var inFile = new System.IO.StreamReader(sSkillFile, System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter(sSkillFile + ".log", true, System.Text.Encoding.Unicode, 1);
			string sTemp;
			string sTemp2;

			string[] aTemp;   // Use for temporary splitting skill effect to parts
			string[] aTemp2;   // Use for temporary splitting effect to effects
			var aEffect = new string[1];
			var aEffectSkill = new string[1];
			var aEffectExample = new string[1];

			// skill_name=[s_stun_attack_boss_b_1a_8]
			// effect={}
			// {{p_block_act}}
			// {{i_m_attack;57}}
			// {{i_spoil};{p_attack_speed;{all};-23;per}}

			int iTemp;

			outFile.WriteLine("//------------------------------------------------------");
			outFile.WriteLine("// L2ScriptMaker: Lineage II Skilldata Effect Researcher");
			outFile.WriteLine("//------------------------------------------------------");
			outFile.WriteLine("// Researching for [" + ScanParamComboBox.Text + "] start at " + Conversions.ToString(DateAndTime.Now));
			outFile.WriteLine();

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				sTemp2 = Libraries.GetNeedParamFromStr(sTemp, ScanParamComboBox.Text);
				if (!string.IsNullOrEmpty(sTemp2) & sTemp2.StartsWith("//") == false & (sTemp2 ?? "") != "{}")
				{
					sTemp2 = sTemp2.Substring(1, sTemp2.Length - 2).Replace("};{", "}|{");
					aTemp = sTemp2.Split(Conversions.ToChar("|"));
					var loopTo = aTemp.Length - 1;
					for (iTemp = 0; iTemp <= loopTo; iTemp++)
					{
						aTemp2 = aTemp[iTemp].Substring(1, aTemp[iTemp].Length - 2).Split(Conversions.ToChar(";"));
						if (Array.IndexOf(aEffect, aTemp2[0]) == -1)
						{
							aEffect[aEffect.Length - 1] = aTemp2[0];
							aEffectSkill[aEffectSkill.Length - 1] = aTemp[iTemp];
							aEffectExample[aEffectExample.Length - 1] = Libraries.GetNeedParamFromStr(sTemp, "skill_name");

							outFile.WriteLine("------------------");
							outFile.WriteLine("Skill effect     : " + aTemp2[0]);
							outFile.WriteLine("Example for skill: " + Libraries.GetNeedParamFromStr(sTemp, "skill_name") + Constants.vbTab
							+ Libraries.GetNeedParamFromStr(sTemp, "operate_type") + Constants.vbTab + aTemp[iTemp]);
							outFile.WriteLine("Description      :");
							outFile.Flush();

							Array.Resize(ref aEffect, aEffect.Length + 1);
							Array.Resize(ref aEffectSkill, aEffectSkill.Length + 1);
							Array.Resize(ref aEffectExample, aEffectExample.Length + 1);
						}
						if ((aTemp2[0] ?? "") == "i_restoration_random")
							break;
						if ((aTemp2[0] ?? "") == "op_not_territory")
							break;
					}
				}
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
			}

			ToolStripProgressBar.Value = 0;

			outFile.WriteLine();
			outFile.WriteLine("Researching stop at " + Conversions.ToString(DateAndTime.Now) + Constants.vbTab + "Founded at " + Conversions.ToString(aEffect.Length) + " effects of skill.");
			outFile.Close();
			inFile.Close();

			MessageBox.Show("Complete.");
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
