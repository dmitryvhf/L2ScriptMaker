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

namespace L2ScriptMaker.Modules.ZeroScripts.L2J
{
	public partial class L2J_MultiSell : Form
	{
		public L2J_MultiSell()
		{
			InitializeComponent();
		}

		private void ButtonStart_Click(object sender, EventArgs e)
		{
			string sTemp;
			string[] aTemp;
			// Dim sSpawnListFile As String

			System.IO.StreamReader inSpawnFile;

			string[] aXMLFiles;
			FolderBrowserDialog.SelectedPath = Application.StartupPath;
			if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
				return;
			aXMLFiles = System.IO.Directory.GetFiles(FolderBrowserDialog.SelectedPath, "*.xml", System.IO.SearchOption.TopDirectoryOnly);
			if (aXMLFiles.Length == 0)
			{
				MessageBox.Show("No XML files into this folder", "No data", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// LOADING item_pch.txt
			if (System.IO.File.Exists("item_pch.txt") == false)
			{
				MessageBox.Show("item_pch.txt not found", "Need item_pch.txt", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var aItemPch = new string[25001];
			inSpawnFile = new System.IO.StreamReader("item_pch.txt", System.Text.Encoding.Default, true, 1);
			ToolStripProgressBar.Maximum = Conversions.ToInteger(inSpawnFile.BaseStream.Length);
			ToolStripStatusLabel.Text = "Loading item_pch.txt ...";

			while (inSpawnFile.EndOfStream != true)
			{
				sTemp = inSpawnFile.ReadLine().Trim();
				ToolStripProgressBar.Value = Conversions.ToInteger(inSpawnFile.BaseStream.Position);
				if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
				{

					// [small_sword] = 1
					sTemp = sTemp.Replace(" ", "").Replace(Conversions.ToString((char)9), "");
					aTemp = sTemp.Split(Conversions.ToChar("="));
					try
					{
						aItemPch[Conversions.ToInteger(aTemp[1])] = aTemp[0];
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error in loading item_pch.txt. Last reading line:" + Constants.vbNewLine + sTemp);
						inSpawnFile.Close();
						return;
					}
				}
			}
			inSpawnFile.Close();
			ToolStripProgressBar.Value = 0;


			var outFile = new System.IO.StreamWriter("multisell_l2j.txt", false, System.Text.Encoding.Unicode, 1);
			var outLogFile = new System.IO.StreamWriter("multisell_l2j.log", false, System.Text.Encoding.Unicode, 1);
			outLogFile.WriteLine("MultiSell clean config generator log. Start working: " + Conversions.ToString(DateAndTime.Now));

			// Dim iNpcCount As Integer = 0
			// Dim sCurNpcName As String = "", sPrevNpcName As String = Nothing
			// Dim sTempNpcName As String, sTempItemName As String
			// Dim sTempDropSpoil As String, sTempDropItems As String
			// Dim bItemCategory As Boolean = False

			int iXMLCount, iXMLCountLine;
			string sTempProduct = "";
			string sTempIngredient = "";
			string sTempGetName;
			string sDuty = "";

			ToolStripProgressBar.Maximum = aXMLFiles.Length - 1;
			var loopTo = aXMLFiles.Length - 1;
			for (iXMLCount = 0; iXMLCount <= loopTo; iXMLCount++)
			{
				inSpawnFile = new System.IO.StreamReader(aXMLFiles[iXMLCount], System.Text.Encoding.Default, true, 1);
				ToolStripStatusLabel.Text = "Loading " + System.IO.Path.GetFileName(aXMLFiles[iXMLCount]) + "...";

				outFile.WriteLine("MultiSell_begin" + Conversions.ToString((char)9) + "[" + System.IO.Path.GetFileNameWithoutExtension(aXMLFiles[iXMLCount]) + "]" + Conversions.ToString((char)9) + System.IO.Path.GetFileNameWithoutExtension(aXMLFiles[iXMLCount]));
				iXMLCountLine = 0;
				while (inSpawnFile.EndOfStream != true)
				{
					sTemp = inSpawnFile.ReadLine().Trim();
					ToolStripProgressBar.Value = iXMLCount;
					if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
					{


						// <?xml version="1.0" encoding="UTF-8"?>
						// <ingredient id="57" count="3390000" isTaxIngredient="true" />
						// {{{[sword_of_damascus_focus];1}};{{[sword_of_damascus];1};{[red_soul_crystal_10];1};{[gemstone_b];339}};{3390000}};

						// applyTaxes
						// maintainEnchantment=false

						// MultiSell_begin	[blackmerchant_weapon]	1
						// is_dutyfree = 1
						// is_show_all = 0
						// keep_enchanted = 1
						// selllist={
						// {{{[heavy_war_axe];1}};{{[crystal_b];579};{[crystal_c];1737}}};
						// {{{[spell_breaker];1}};{{[crystal_b];579};{[crystal_c];1737}}}
						// }
						// MultiSell_end


						// <list applyTaxes="true" maintainEnchantment="true">
						// <list>
						// <item id="1">
						// <ingredient id="2505" count="1" />
						// <ingredient id="2130" count="24" />
						// <production id="3439" count="1" />
						// </item>
						// </list>
						if (sTemp.StartsWith("<list") == true)
						{
							outFile.WriteLine("//is_dutyfree = 1");

							if (Strings.InStr(sTemp, "maintainEnchantment=\"true\"") > 0)
							{
								outFile.WriteLine("is_show_all = 0");
								outFile.WriteLine("keep_enchanted = 1");
							}
							else if (Strings.InStr(sTemp, "maintainEnchantment=\"false\"") > 0)
								outFile.WriteLine("keep_enchanted = 0");

							outFile.WriteLine("selllist={");
						}

						if (sTemp.StartsWith("<item id="))
						{

							// Close previous line
							if (iXMLCountLine > 0)
								outFile.WriteLine(";");
						}


						if (sTemp.StartsWith("<ingredient id="))
						{

							// sTempIngredient = sTempIngredient & "{" & GetValByName(sTemp, "id") & ";" & GetValByName(sTemp, "count") & "}"

							if ((GetValByName(sTemp, "id") ?? "") == "-300")
								sTempGetName = "[pvp_point]";
							else if ((GetValByName(sTemp, "id") ?? "") == "-200")
								sTempGetName = "[pledge_point]";
							else if (aItemPch[Conversions.ToInteger(GetValByName(sTemp, "id"))] == null)
							{
								outLogFile.WriteLine("MISSED ID:[" + GetValByName(sTemp, "id") + "]");
								sTempGetName = "_no_id_" + GetValByName(sTemp, "id");
							}
							else
								sTempGetName = aItemPch[Conversions.ToInteger(GetValByName(sTemp, "id"))];

							// <ingredient id="2135" count="1" mantainIngredient="true" />

							// <ingredient id="57" count="291000" isTaxIngredient="true" />
							if (Strings.InStr(sTemp, "isTaxIngredient=\"true\"") > 0)
								// sTempIngredient = sTempIngredient & "};{" & GetValByName(sTemp, "count") & "}"
								sDuty = "{" + GetValByName(sTemp, "count") + "}";
							else
							{
								if (!string.IsNullOrEmpty(sTempIngredient))
									sTempIngredient = sTempIngredient + ";";
								sTempIngredient = sTempIngredient + "{" + sTempGetName + ";" + GetValByName(sTemp, "count") + "}";
							}
						}

						if (sTemp.StartsWith("<production id="))
						{
							if (!string.IsNullOrEmpty(sTempProduct))
								sTempProduct = sTempProduct + ";";

							if ((GetValByName(sTemp, "id") ?? "") == "-300")
								sTempGetName = "[pvp_point]";
							else if ((GetValByName(sTemp, "id") ?? "") == "-200")
								sTempGetName = "[pledge_point]";
							else if (aItemPch[Conversions.ToInteger(GetValByName(sTemp, "id"))] == null)
							{
								outLogFile.WriteLine("MISSED ID:[" + GetValByName(sTemp, "id") + "]");
								sTempGetName = "_no_id_" + GetValByName(sTemp, "id");
							}
							else
								sTempGetName = aItemPch[Conversions.ToInteger(GetValByName(sTemp, "id"))];

							// sTempProduct = "{" & GetValByName(sTemp, "id") & ";" & GetValByName(sTemp, "count") & "}"
							sTempProduct = "{" + sTempGetName + ";" + GetValByName(sTemp, "count") + "}";
						}

						if (sTemp.StartsWith("</item>"))
						{

							// { { {[heavy_war_axe];1}  };{  {[crystal_b];579}; {[crystal_c];1737} }  };
							outFile.Write("{{" + sTempProduct + "};{" + sTempIngredient + "}");
							if (string.IsNullOrEmpty(sDuty))
								outFile.Write("}");
							else
								outFile.Write(";" + sDuty + "}");

							// SAVING LINE
							// outFile.WriteLine("")
							iXMLCountLine = iXMLCountLine + 1;
							sTempProduct = ""; sTempIngredient = "";
							sDuty = "";
						}

						if (sTemp.StartsWith("</list>"))
							outFile.WriteLine(Constants.vbNewLine + "}");
					}
				}
				outFile.WriteLine("MultiSell_end" + Constants.vbNewLine);
				inSpawnFile.Close();
			}
			ToolStripProgressBar.Value = 0;
			outFile.Close();
			outLogFile.Close();

			MessageBox.Show("Completed.");
		}

		private string GetValByName(string Str, string ParamName)
		{
			string GetValByNameRet = default(string);

			// <ingredient id="2505" count="1" />
			int iTemp, iTemp2;
			iTemp = Strings.InStr(Str, ParamName + "=\"") + (ParamName + "=\"").Length - 1;
			iTemp2 = Strings.InStr(iTemp + 1, Str, "\"") - 1;

			GetValByNameRet = Str.Substring(iTemp, iTemp2 - iTemp);
			return GetValByNameRet;
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
