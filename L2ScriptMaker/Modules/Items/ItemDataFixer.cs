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

namespace L2ScriptMaker.Modules.Items
{
	public partial class ItemDataFixer : Form
	{
		public ItemDataFixer()
		{
			InitializeComponent();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			if (CheckedListBox.CheckedItems.Count == 0)
			{
				MessageBox.Show("Select what you want to check and fix and try again", "No select", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string sTemp;
			var aTemp = new string[0];
			string sTemp2;
			int iTemp = 0;
			var ItemNames = new string[1];

			CheckFilesBox.Text = CheckFilesBox.Text.Trim();

			var CheckConfig = new string[CheckFilesBox.Lines.Length + 1];
			var inCheckFiles = new System.IO.StreamReader[CheckFilesBox.Lines.Length + 1];
			var loopTo = CheckFilesBox.Lines.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				inCheckFiles[iTemp] = new System.IO.StreamReader(CheckFilesBox.Lines[iTemp], System.Text.Encoding.Default, true, 1);
				CheckConfig[iTemp] = inCheckFiles[iTemp].ReadToEnd();
				inCheckFiles[iTemp].Close();
				System.IO.File.Copy(CheckFilesBox.Lines[iTemp], CheckFilesBox.Lines[iTemp] + ".bak", true);
			}

			var outCheckFiles = new System.IO.StreamWriter[CheckFilesBox.Lines.Length + 1];
			var loopTo1 = CheckFilesBox.Lines.Length - 1;
			for (iTemp = 0; iTemp <= loopTo1; iTemp++)
				outCheckFiles[iTemp] = new System.IO.StreamWriter(CheckFilesBox.Lines[iTemp], false, System.Text.Encoding.Unicode, 1);


			var aCapsuleSkill = new string[1]; // action_capsule
			if (CheckedListBox.CheckedItems.IndexOf("action_capsule items") != -1)
			{
				OpenFileDialog.FileName = "skilldata.txt";
				if (System.IO.File.Exists("skilldata.txt") == false)
				{
					// OpenFileDialog.FileName = "skilldata.txt"
					OpenFileDialog.Filter = "Lineage II server skill config (skilldata.txt)|skilldata*.txt|All files|*.*";
					if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
						return;
				}

				// ---- Loading 'Skilldata.txt' ---- 
				var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);
				ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
				// ProgressBar.Text = "Loading skilldata.txt..."

				while (inFile.EndOfStream != true)
				{
					sTemp = inFile.ReadLine();
					if (!string.IsNullOrEmpty(sTemp) & sTemp.StartsWith("//") == false)
					{

						// skill_begin	skill_name = [s_quiver_of_arrows_a]	/* [?? ?? ???? - A????] */	skill_id = 323	level = 1	operate_type = A1	magic_level = 66	effect = {{i_restoration_random;{{{{[mithril_arrow];700}};30};{{{[mithril_arrow];1400}};50};{{{[mithril_arrow];2800}};20}}}}	is_magic = 1	mp_consume1 = 366	mp_consume2 = 0	item_consume = {[crystal_a];1}	cast_range = -1	effective_range = -1	skill_hit_time = 3	skill_cool_time = 0	skill_hit_cancel_time = 0.5	reuse_delay = 1800	attribute = attr_none	effect_point = 0	target_type = self	affect_scope = single	affect_limit = {0;0}	next_action = none	ride_state = {@ride_none;@ride_wind;@ride_star;@ride_twilight}	skill_end
						// skill_begin	skill_name = [s_summon_cp_potion]	/* [?? CP ??] */	skill_id = 1324	level = 1	operate_type = A1	magic_level = -1	effect = {{i_restoration;[adv_cp_potion];20}}	is_magic = 1	mp_consume1 = 412	mp_consume2 = 0	item_consume = {[soul_ore];50}	cast_range = -1	effective_range = -1	skill_hit_time = 20	skill_cool_time = 0	skill_hit_cancel_time = 0.5	reuse_delay = 1800	attribute = attr_none	effect_point = 0	target_type = self	affect_scope = single	affect_limit = {0;0}	next_action = none	ride_state = {@ride_none;@ride_wind;@ride_star;@ride_twilight}	skill_end

						if (Strings.InStr(Libraries.GetNeedParamFromStr(sTemp, "effect"), "{i_restoration") > 0)
						{
							// iTemp = CInt(Libraries.GetNeedParamFromStr(sTemp, "skill_id"))
							// If iTemp >= aCapsuleSkill.Length Then
							iTemp = aCapsuleSkill.Length;
							Array.Resize(ref aCapsuleSkill, iTemp + 1);
							// End If
							aCapsuleSkill[iTemp - 1] = Libraries.GetNeedParamFromStr(sTemp, "skill_name"); // .Replace("[", "").Replace("]", "")
						}
					}
					ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position);
					ProgressBar.Update();
				}
				ProgressBar.Value = 0;
				inFile.Close();
				this.Refresh();
			}
			this.Update();

			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II config (itemdata.txt)|itemdata.txt|All files (*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			var inItemFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);
			var outItemFile = new System.IO.StreamWriter(OpenFileDialog.FileName + "_fixed.txt", false, System.Text.Encoding.Unicode, 1);
			var outLogFile = new System.IO.StreamWriter(OpenFileDialog.FileName + "_fixed.log", true, System.Text.Encoding.Unicode, 1);
			outLogFile.WriteLine("L2ScriptMaker ItemData Fixer" + Constants.vbNewLine + DateAndTime.Now.ToString() + " Start" + Constants.vbNewLine);
			ProgressBar.Maximum = Conversions.ToInteger(inItemFile.BaseStream.Length);
			ProgressBar.Value = 0;


			while (inItemFile.EndOfStream != true)
			{
				sTemp = inItemFile.ReadLine();
				sTemp = sTemp.Replace(" = ", "=").Replace("  ", " ").Replace(" ", Conversions.ToString((char)9));

				if (sTemp.StartsWith("item_begin") == true)
				{
					Array.Clear(aTemp, 0, aTemp.Length);
					aTemp = sTemp.Split((char)9);

					// If InStr(sTemp, "questitem") <> 0 Then
					// If Libraries.GetNeedParamFromStr(sTemp, "item_type") ="" Then
					// If aTemp(1) = "questitem" And aTemp(4) <> "item_type=questitem" Then

					// item_begin(0)	questitem(1)	687(2)	[darings_letter](3)	item_type=questitem(4)

					// Duplicate check actived
					if (CheckedListBox.CheckedItems.IndexOf("duplicate names") != -1)
					{
						if (ItemNames.Length < Conversions.ToInteger(aTemp[2]) + 1)
							Array.Resize(ref ItemNames, Conversions.ToInteger(aTemp[2]) + 1);
						if (Array.IndexOf(ItemNames, aTemp[3]) != -1)
						{
							outLogFile.WriteLine("ItemId " + aTemp[2] + " " + aTemp[3] + Constants.vbTab + " is duplicate item for item " + Conversions.ToString(Array.IndexOf(ItemNames, aTemp[3])) + ". Automaticaly renamed to " + aTemp[3].Replace("]", "_" + aTemp[2] + "]"));
							var loopTo2 = CheckFilesBox.Lines.Length - 1;
							for (iTemp = 0; iTemp <= loopTo2; iTemp++)
								CheckConfig[iTemp] = CheckConfig[iTemp].Replace(aTemp[3], aTemp[3].Replace("]", "_" + aTemp[2] + "]"));
							aTemp[3] = aTemp[3].Replace("]", "_" + aTemp[2] + "]");
							sTemp = Strings.Join(aTemp, Conversions.ToString((char)9));
						}
						ItemNames[Conversions.ToInteger(aTemp[2])] = aTemp[3];
					}


					// Items type check actived
					if (CheckedListBox.CheckedItems.IndexOf("item_type=") != -1)
					{
						if ((aTemp[1] ?? "") != (aTemp[4].Replace("item_type=", "") ?? ""))
						{
							outLogFile.WriteLine("ItemId " + aTemp[2] + " " + aTemp[3] + Constants.vbTab + " define as '" + aTemp[1] + "', but '" + aTemp[4] + "'. Header fixed.");
							aTemp[1] = aTemp[4].Replace("item_type=", "");
							sTemp = Strings.Join(aTemp, Conversions.ToString((char)9));
						}
					}

					// QuestItems name check actived
					if (CheckedListBox.CheckedItems.IndexOf("add q_ for questitems") != -1)
					{
						if ((aTemp[4] ?? "") == "item_type=questitem")
						{
							if (aTemp[3].StartsWith("[q_") == false & aTemp[3].StartsWith("[q0") == false)
							{
								// Itemname is questitem but name not q_...
								outLogFile.WriteLine("ItemId " + aTemp[2] + " " + aTemp[3] + Constants.vbTab + " is " + aTemp[1] + ", but named as not quest item. Header fixed.");
								var loopTo3 = CheckFilesBox.Lines.Length - 1;
								for (iTemp = 0; iTemp <= loopTo3; iTemp++)
									CheckConfig[iTemp] = CheckConfig[iTemp].Replace(aTemp[3], aTemp[3].Replace("[", "[q_"));
								aTemp[3] = aTemp[3].Replace("[", "[q_");
								sTemp = Strings.Join(aTemp, Conversions.ToString((char)9));
							}
						}
					}

					// QuestItems name check2 actived
					if (CheckedListBox.CheckedItems.IndexOf("remove q_ from non-questitems") != -1)
					{
						if ((aTemp[4] ?? "") != "item_type=questitem")
						{
							if (aTemp[3].StartsWith("[q_") == true)
							{
								// Itemname is normal item, but named as questitem [q_...]
								outLogFile.WriteLine("ItemId " + aTemp[2] + " " + aTemp[3] + Constants.vbTab + " is " + aTemp[1] + ", but named as quest item. Header removed.");
								var loopTo4 = CheckFilesBox.Lines.Length - 1;
								for (iTemp = 0; iTemp <= loopTo4; iTemp++)
									CheckConfig[iTemp] = CheckConfig[iTemp].Replace(aTemp[3], aTemp[3].Replace("[q_", "["));
								aTemp[3] = aTemp[3].Replace("[q_", "[");
								sTemp = Strings.Join(aTemp, Conversions.ToString((char)9));
							}
						}
					}

					// action_capsule items
					if (CheckedListBox.CheckedItems.IndexOf("action_capsule items") != -1)
					{
						// item_begin	etcitem	5134	[comp_soulshot_none]	default_action=action_capsule	item_skill=[s_restoration1]
						// item_begin(0)	questitem(1)	687(2)	[darings_letter](3)	item_type=questitem(4)
						sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "item_skill");
						if ((sTemp2 ?? "") != "[]")
						{
							if (Array.IndexOf(aCapsuleSkill, sTemp2) != -1)
							{
								if ((Libraries.GetNeedParamFromStr(sTemp, "default_action") ?? "") != "action_capsule")
								{
									sTemp = Libraries.SetNeedParamToStr(sTemp, "default_action", "action_capsule");
									outLogFile.WriteLine("ItemId " + aTemp[2] + " " + aTemp[3] + Constants.vbTab + " now default_action=action_capsule");
								}
							}
						}
					}

					// dual_fhit_rate
					if (CheckedListBox.CheckedItems.IndexOf("dual_fhit_rate") != -1)
					{
						// item_begin	etcitem	5134	[comp_soulshot_none]	default_action=action_capsule	item_skill=[s_restoration1]
						// item_begin(0)	questitem(1)	687(2)	[darings_letter](3)	item_type=questitem(4)
						// weapon_type=dualfist
						sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "weapon_type");
						if ((sTemp2 ?? "") == "dualfist" | (sTemp2 ?? "") == "dual")
						{
							if ((Libraries.GetNeedParamFromStr(sTemp, "dual_fhit_rate") ?? "") == "0")
							{
								sTemp = Libraries.SetNeedParamToStr(sTemp, "dual_fhit_rate", "50");
								outLogFile.WriteLine("ItemId " + aTemp[2] + " " + aTemp[3] + Constants.vbTab + " now dual_fhit_rate=50");
							}
						}
					}

					// polearm multitarget
					if (CheckedListBox.CheckedItems.IndexOf("polearm multitarget") != -1)
					{
						// item_begin	etcitem	5134	[comp_soulshot_none]	default_action=action_capsule	item_skill=[s_restoration1]
						// item_begin(0)	questitem(1)	687(2)	[darings_letter](3)	item_type=questitem(4)
						// weapon_type=dualfist
						sTemp2 = Libraries.GetNeedParamFromStr(sTemp, "weapon_type");
						if ((sTemp2 ?? "") == "pole")
						{
							// item_skill=[s_polearm_multi_attack]
							if ((Libraries.GetNeedParamFromStr(sTemp, "item_skill") ?? "") == "[none]")
							{
								sTemp = Libraries.SetNeedParamToStr(sTemp, "item_skill", "[s_polearm_multi_attack]");
								outLogFile.WriteLine("ItemId " + aTemp[2] + " " + aTemp[3] + Constants.vbTab + " now item_skill=[s_polearm_multi_attack]");
							}
						}
					}
				}

				outItemFile.WriteLine(sTemp);
				ProgressBar.Value = Conversions.ToInteger(inItemFile.BaseStream.Position);
			}
			ProgressBar.Value = 0;
			outLogFile.WriteLine(Constants.vbNewLine + DateAndTime.Now.ToString() + " End" + Constants.vbNewLine);

			inItemFile.Close();
			outItemFile.Close();
			outLogFile.Close();
			var loopTo5 = CheckFilesBox.Lines.Length - 1;
			for (iTemp = 0; iTemp <= loopTo5; iTemp++)
			{
				outCheckFiles[iTemp].Write(CheckConfig[iTemp]);
				outCheckFiles[iTemp].Close();
			}

			MessageBox.Show("Complete");
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
