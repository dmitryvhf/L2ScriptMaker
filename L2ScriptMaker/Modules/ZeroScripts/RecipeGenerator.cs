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
	public partial class RecipeGenerator : Form
	{
		public RecipeGenerator()
		{
			InitializeComponent();
		}

		private string[] ItemPch = new string[1];

		private void StartButton_Click(object sender, EventArgs e)
		{
			string sItemPch = "item_pch.txt";
			OpenFileDialog.InitialDirectory = Application.StartupPath;
			if (System.IO.File.Exists(sItemPch) == false)
			{
				OpenFileDialog.FileName = "item_pch.txt";
				OpenFileDialog.Filter = "Lineage II Server Item_pch file(item_pch.txt)|item_pch.txt|All files|*.*";
				if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
					return;
				sItemPch = OpenFileDialog.FileName;
			}
			if (ItemPchLoad(sItemPch) == false)
				return;

			string sRecipeE;
			OpenFileDialog.FileName = "recipe-c.txt";
			OpenFileDialog.Filter = "Lineage II Client Recipe file(recipe-c.txt)|recipe-c.txt|All files|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sRecipeE = OpenFileDialog.FileName;

			if (System.IO.File.Exists("recipe.txt") == true)
			{
				if ((int)MessageBox.Show("Backup and overwrite exist 'recipe.txt' file?", "Overwrite", MessageBoxButtons.YesNo) == (int)DialogResult.No)
					return;
				System.IO.File.Copy("recipe.txt", "recipe.txt.bak", true);
			}

			var inFile = new System.IO.StreamReader(sRecipeE, System.Text.Encoding.Default, true, 1);
			var outFile = new System.IO.StreamWriter("recipe.txt", false, System.Text.Encoding.Unicode, 1);
			string sTemp;
			string sGen = "";
			// Dim aTemp() As String
			int iTemp;

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripProgressBar.Value = 0;

			while (inFile.EndOfStream != true)
			{
				sTemp = inFile.ReadLine();
				// recipe_begin	name=[mk_brigandine]	id_mk=79	id_recipe=2186	level=3	id_item=352	count=1	mp_cost=120	success_rate=100	materials_cnt=5	materials_m[0]_id=1941	materials_m[0]_cnt=7	materials_m[1]_id=1883	materials_m[1]_cnt=3	materials_m[2]_id=1880	materials_m[2]_cnt=54	materials_m[3]_id=1458	materials_m[3]_cnt=90	materials_m[4]_id=2130	materials_m[4]_cnt=24	materials_m[5]_id=	materials_m[5]_cnt=	materials_m[6]_id=	materials_m[6]_cnt=	materials_m[7]_id=	materials_m[7]_cnt=	materials_m[8]_id=	materials_m[8]_cnt=	materials_m[9]_id=	materials_m[9]_cnt=	recipe_end
				// recipe_begin	[mk_brigandine]	79	level=3	material={{[brigandine_temper];7};{[steel_mold];3};{[steel];54};{[crystal_d];90};{[gemstone_d];24}}	catalyst={}	product={{[brigandine];1}}	npc_fee={{[rp_brigandine];1};{[adena];59800}}	mp_consume=120	success_rate=100	item_id=2186	iscommonrecipe=0	recipe_end
				// aTemp = sTemp.Split(Chr(9))

				// recipe_begin
				outFile.Write("recipe_begin" + Constants.vbTab);

				// [mk_brigandine]
				outFile.Write(Libraries.GetNeedParamFromStr(sTemp, "name") + Constants.vbTab);

				// 79
				outFile.Write(Libraries.GetNeedParamFromStr(sTemp, "id_mk") + Constants.vbTab);

				// level=3
				outFile.Write("level=" + Libraries.GetNeedParamFromStr(sTemp, "level") + Constants.vbTab);
				var loopTo = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "materials_cnt")) - 1;

				// material={{[brigandine_temper];7};{[steel_mold];3};{[steel];54};{[crystal_d];90};{[gemstone_d];24}}

				// materials_cnt=5	materials_m[0]_id=1941	materials_m[0]_cnt=7
				for (iTemp = 0; iTemp <= loopTo; iTemp++)
				{
					if (Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "materials_m[" + iTemp.ToString() + "]_id")) > ItemPch.Length)
					{
						if (IgnoreUnknownCheckBox.Checked == false)
						{
							MessageBox.Show("Recipe " + Libraries.GetNeedParamFromStr(sTemp, "name") + " have item with unknown id " + Libraries.GetNeedParamFromStr(sTemp, "materials_m[" + iTemp.ToString() + "]_id") + Constants.vbNewLine + "Check itemdata.txt for this item or regenerate item_pch.txt." + Constants.vbNewLine + "Generation aborted.", "Unknown ItemID", MessageBoxButtons.OK, MessageBoxIcon.Error);
							break;
						}
						else
						{
							sGen = "";
							break;
						}
					}
					else
						sGen = sGen + "{" + ItemPch[Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "materials_m[" + iTemp.ToString() + "]_id"))] + ";" + Libraries.GetNeedParamFromStr(sTemp, "materials_m[" + iTemp.ToString() + "]_cnt") + "}";

					// if ItemPch(CInt(Libraries.GetNeedParamFromStr(sTemp, "materials_m[" & iTemp.ToString & "]_id")) = "" then
					if (iTemp < Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "materials_cnt")) - 1)
						sGen = sGen + ";";
				}
				outFile.Write("material={" + sGen + "}" + Constants.vbTab); sGen = "";

				// catalyst={}
				outFile.Write("catalyst={}" + Constants.vbTab);

				// product={{[brigandine];1}}
				if (Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "id_item")) > ItemPch.Length)
				{
					if (IgnoreUnknownCheckBox.Checked == false)
					{
						MessageBox.Show("Recipe " + Libraries.GetNeedParamFromStr(sTemp, "name") + " have record with unknown itemid " + Libraries.GetNeedParamFromStr(sTemp, "id_item") + Constants.vbNewLine + "Check itemdata.txt for this item or regenerate item_pch.txt.", "Unknown ItemID" + Constants.vbNewLine + "Generation aborted.", MessageBoxButtons.OK, MessageBoxIcon.Error);
						break;
					}
					else
						sGen = "";
				}
				else
				{

					// sGen = "{" & ItemPch(CInt(Libraries.GetNeedParamFromStr(sTemp, "id_item"))) & ";" & Libraries.GetNeedParamFromStr(sTemp, "count") & "}"
					sGen = "{" + ItemPch[Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "id_item"))] + ";" + Libraries.GetNeedParamFromStr(sTemp, "count");

					// product={{[soulshot_c];952;100}}	
					// product={{[dynasty_staff];1;96};{[fnd_dyn_staff];1;4}}	
					if (CheckBoxDevnextSupport.Checked == true)
						sGen = sGen + ";100";
					sGen = sGen + "}";
				}

				outFile.Write("product={" + sGen + "}" + Constants.vbTab); sGen = "";

				// npc_fee={{[rp_brigandine];1};{[adena];59800}}
				outFile.Write("npc_fee={}" + Constants.vbTab);

				// mp_consume=120
				outFile.Write("mp_consume=" + Libraries.GetNeedParamFromStr(sTemp, "mp_cost") + Constants.vbTab);

				// success_rate=100
				outFile.Write("success_rate=" + Libraries.GetNeedParamFromStr(sTemp, "success_rate") + Constants.vbTab);

				// item_id=2186
				outFile.Write("item_id=" + Libraries.GetNeedParamFromStr(sTemp, "id_recipe") + Constants.vbTab);

				// iscommonrecipe=0
				outFile.Write("iscommonrecipe=0" + Constants.vbTab);

				// recipe_end
				outFile.WriteLine("recipe_end");

				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position); this.Update();
			}

			ToolStripProgressBar.Value = 0;

			inFile.Close();
			outFile.Close();

			MessageBox.Show("Generation complete", "Complete", MessageBoxButtons.OK);
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

			ToolStripProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ToolStripProgressBar.Value = 0;
			while (inFile.EndOfStream != true)
			{

				// [small_sword]	=	1
				try
				{
					sTempStr = inFile.ReadLine();
					sTempStr = sTempStr.Replace(" ", "").Replace(Conversions.ToString((char)9), ""); // .Replace("[", "").Replace("]", "")
					aTemp = sTempStr.Split(Conversions.ToChar("="));

					iTemp = Conversions.ToInteger(aTemp[1]);
					if (ItemPch.Length <= iTemp)
						Array.Resize(ref ItemPch, iTemp + 1);
					ItemPch[iTemp] = aTemp[0];
				}
				catch (Exception ex)
				{
					MessageBox.Show("Import data invalid in line" + Constants.vbNewLine + sTempStr, "Import data invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
					inFile.Close();
					return false;
				}

				ToolStripProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position); this.Update();
			}

			ToolStripProgressBar.Value = 0;
			inFile.Close();
			return true;
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
