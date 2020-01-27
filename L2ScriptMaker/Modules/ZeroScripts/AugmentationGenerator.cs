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

namespace L2ScriptMaker.Modules.ZeroScripts
{
	public partial class AugmentationGenerator : Form
	{
		public AugmentationGenerator()
		{
			InitializeComponent();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			string sTemp;
			int iTemp;

			System.IO.StreamReader inFile;
			System.IO.StreamWriter outFile;

			string sAughEFile = "optiondata_client-e.txt";
			string sAughDataFile = "augmentation.txt";


			if (System.IO.File.Exists(sAughEFile) == false)
			{
				OpenFileDialog.FileName = "";
				OpenFileDialog.Filter = "Lineage II client text file (optiondata_client-e.txt)|optiondata_client*.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				sAughEFile = OpenFileDialog.FileName;
			}

			SaveFileDialog.FileName = sAughDataFile;
			SaveFileDialog.Filter = "Lineage II server Augmentation script (La2Guard Ext) (augmentation.txt)|augmentation*.txt|All files|*.*";
			if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sAughDataFile = SaveFileDialog.FileName;


			inFile = new System.IO.StreamReader(sAughEFile, System.Text.Encoding.Default, true, 1);
			outFile = new System.IO.StreamWriter(sAughDataFile, false, System.Text.Encoding.Unicode, 1);

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading optiondata_client-e.txt...";
			string sTempVal = "";
			string sNewData = "";

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);

				if (!string.IsNullOrEmpty(sTemp.Trim()) & sTemp.Trim() != null & sTemp.StartsWith("//") == false)
				{
					sNewData = "augmentation_begin" + Constants.vbTab;
					sNewData = sNewData + Libraries.GetNeedParamFromStr(sTemp, "id") + Constants.vbTab;

					// optiondata_client-e_begin	id=1	level?=1	var_of_level?=1	effect1_desc=[P. Def. +15.4]	effect2_desc=[]	effect3_desc?=[]	optiondata_client-e_end
					// optiondata_client-e_begin	id=5810	level?=3	var_of_level?=1	effect1_desc=[HP Recovery +0.2]	effect2_desc=[MP Recovery +0.1]	effect3_desc?=[]	optiondata_client-e_end
					// optiondata_client-e_begin	id=15024	level?=3	var_of_level?=2	effect1_desc=[Chance: Has a chance to increase your PVP power wh\\nen you take damage in PvP.]	effect2_desc=[]	effect3_desc?=[]	optiondata_client-e_end

					// augmentation_begin	1	p_def=15.4	augmentation_end
					// augmentation_begin	5810	hp_recovery=0.2	mp_recovery=0.1	augmentation_end
					// augmentation_begin	15024	skill_id=3217	skill_level=3	augmentation_end

					// effect1_desc=[P. Def. +15.4]

					for (iTemp = 1; iTemp <= 2; iTemp++)
					{
						if (iTemp == 1)
							sTempVal = Libraries.GetNeedParamFromStr(sTemp, "effect1_desc");
						if (iTemp == 2)
							sTempVal = Libraries.GetNeedParamFromStr(sTemp, "effect2_desc");
						if (iTemp == 3)
							sTempVal = Libraries.GetNeedParamFromStr(sTemp, "effect3_desc?");

						if (sTempVal.StartsWith("[Active:") == true | sTempVal.StartsWith("[Chance:") == true | sTempVal.StartsWith("[Passive:") == true)
							// [Active:  [Passive:
							sTempVal = "skill_id=1" + Constants.vbTab + "skill_level=1" + Constants.vbTab;
						else
						{

							// La2Guard standart
							sTempVal = sTempVal.Replace("[P. Atk. ", "p_atk");
							sTempVal = sTempVal.Replace("[P. Def.", "p_def");
							sTempVal = sTempVal.Replace("[M. Atk.", "m_atk");
							sTempVal = sTempVal.Replace("[M. Def.", "m_def");
							sTempVal = sTempVal.Replace("[Accuracy", "accuracy");
							sTempVal = sTempVal.Replace("[Dodge", "dodge");
							sTempVal = sTempVal.Replace("[Critical", "critical");

							sTempVal = sTempVal.Replace("[HP Recovery", "hp_recovery");
							sTempVal = sTempVal.Replace("[MP Recovery", "mp_recovery");
							sTempVal = sTempVal.Replace("[CP Recovery", "cp_recovery");
							sTempVal = sTempVal.Replace("[Maximum HP", "max_hp");
							sTempVal = sTempVal.Replace("[Maximum MP", "max_mp");
							sTempVal = sTempVal.Replace("[Maximum CP", "max_cp");

							sTempVal = sTempVal.Replace("[STR", "str");
							sTempVal = sTempVal.Replace("[CON", "con");
							sTempVal = sTempVal.Replace("[DEX", "dex");
							sTempVal = sTempVal.Replace("[INT", "int");
							sTempVal = sTempVal.Replace("[MEN", "men");
							sTempVal = sTempVal.Replace("[WIT", "wit");

							// dVampire standart

							// level?=4
							// sTempVal = sTempVal.Replace("[P. Atk. ", "pAtk_inc")
							// sTempVal = sTempVal.Replace("[P. Def.", "pDef_inc")
							// sTempVal = sTempVal.Replace("[M. Atk.", "matk_inc")
							// sTempVal = sTempVal.Replace("[M. Def.", "mdef_inc")
							// sTempVal = sTempVal.Replace("[Accuracy", "accuracy_inc")
							// sTempVal = sTempVal.Replace("[Dodge", "evasion_inc")
							// sTempVal = sTempVal.Replace("[Critical", "critical_atk_inc")

							// sTempVal = sTempVal.Replace("[HP Recovery", "hp_regen")
							// sTempVal = sTempVal.Replace("[MP Recovery", "mp_regen")
							// sTempVal = sTempVal.Replace("[CP Recovery", "cp_regen")
							// sTempVal = sTempVal.Replace("[Maximum HP", "max_hp")
							// sTempVal = sTempVal.Replace("[Maximum MP", "max_mp")
							// sTempVal = sTempVal.Replace("[Maximum CP", "max_cp")

							// sTempVal = sTempVal.Replace("[STR", "str_inc")
							// sTempVal = sTempVal.Replace("[CON", "con_inc")
							// sTempVal = sTempVal.Replace("[DEX", "dex_inc")
							// sTempVal = sTempVal.Replace("[INT", "int_inc")
							// sTempVal = sTempVal.Replace("[MEN", "men_inc")
							// sTempVal = sTempVal.Replace("[WIT", "wit_inc")

							sTempVal = sTempVal.Replace(" ", "").Replace("+", "=").Replace("[", "").Replace("]", "");
						}

						if (!string.IsNullOrEmpty(sTempVal))
							sNewData = sNewData + sTempVal + Constants.vbTab;
					}

					sNewData = sNewData + "augmentation_end";
				}

				outFile.WriteLine(sNewData);
				sNewData = "";
			}

			inFile.Close();
			outFile.Close();
			ToolStripProgressBar.Value = 0;

			MessageBox.Show("Done");
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
