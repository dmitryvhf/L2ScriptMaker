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
	public partial class QuestPchMaker : Form
	{
		public QuestPchMaker()
		{
			InitializeComponent();
		}

		private void QuestPchButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II config (itemdata.txt)|itemdata.txt|All files (*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			string QuestDataDir = System.IO.Path.GetDirectoryName(OpenFileDialog.FileName);
			if (System.IO.File.Exists("ai.obj") == false | System.IO.File.Exists("questname-e.txt") == false)
			{
				MessageBox.Show("Required all files (itemdata.txt and ai.obj and questname-e.txt) for generation", "Required files not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Initialization

			// quest_begin	id=257	level=1	name=[The Guard is Busy]
			// quest_begin	id=1	level=1	name=[Letters of Love]
			var QuestPchName = new string[2001];
			// [guard_is_busy1]	257
			// [letters_of_love1](1)

			var QuestPch2Name = new string[2001];
			// 257 4 1084 752 1085 1086  QuestPch2Name(257)
			// 1 4 687 688 1079 1080     QuestPch2Name(1)

			var UnDestrItems = new string[30001];

			// Dim inQuestEFile As New System.IO.StreamReader("questname-e.txt", System.Text.Encoding.Default, True, 1)
			// Dim inItemFile As New System.IO.StreamReader("itemdata.txt", System.Text.Encoding.Default, True, 1)
			// Dim inAiFile As New System.IO.StreamReader("ai.obj", System.Text.Encoding.Default, True, 1)

			// Dim outQuestPchFile As New System.IO.StreamWriter(QuestDataDir + "\quest_pch.txt", False, System.Text.Encoding.Unicode, 1)
			// Dim outQuestPch2File As New System.IO.StreamWriter(QuestDataDir + "\quest_pch2.txt", False, System.Text.Encoding.Unicode, 1)
			var outLogFile = new System.IO.StreamWriter(QuestDataDir + @"\quest_pch.log", true, System.Text.Encoding.Unicode, 1);
			outLogFile.WriteLine("L2ScriptMaker QuestPch/Pch2 Builder" + Constants.vbNewLine + DateAndTime.Now.ToString() + " Start" + Constants.vbNewLine);

			string sTemp;
			var aTemp = new string[0];
			int iTemp;

			var inQuestEFile = new System.IO.StreamReader("questname-e.txt", System.Text.Encoding.Default, true, 1);
			ProgressBar.Maximum = Conversions.ToInteger(inQuestEFile.BaseStream.Length);
			ProgressBar.Value = 0;
			StatusLabel.Text = "Loading quest names and generate quest_pch.txt ...";
			StatusLabel.Refresh();

			// Loading Quests Name to QuestPchName and Generate quest_pch
			// quest_begin	id=257	level=1	name=[The Guard is Busy]
			// quest_begin	id=1	level=1	name=[Letters of Love]
			// Dim QuestPchName(2000) As String
			// [guard_is_busy1]	257
			// [letters_of_love1] 1

			while (inQuestEFile.EndOfStream != true)
			{
				sTemp = inQuestEFile.ReadLine();
				// aTemp = sTemp.Split(Chr(9))
				// iTemp = CInt(aTemp(1).Remove(0, 3))
				iTemp = Conversions.ToInteger(Libraries.GetNeedParamFromStr(sTemp, "quest_id"));
				if (string.IsNullOrEmpty(QuestPchName[iTemp]))
				{
					// QuestPchName(iTemp) = aTemp(3).Remove(0, 5)
					QuestPchName[iTemp] = Libraries.GetNeedParamFromStr(sTemp, "main_name");
					QuestPchName[iTemp] = QuestPchName[iTemp].Replace("  ", " ").Replace(" ", "_").ToLower().Trim();
					QuestPchName[iTemp] = QuestPchName[iTemp].Replace("'", "").Replace("!", "").Replace(".", "").Replace(",", "").Replace("?", "");
				}

				ProgressBar.Value = Conversions.ToInteger(inQuestEFile.BaseStream.Position);
			}
			inQuestEFile.Close();
			ProgressBar.Value = 0;

			// item_begin	weapon	1	[small_sword]	item_type=weapon	slot_bit_type={rhand}	armor_type=none	etcitem_type=none	recipe_id=0	blessed=0	weight=1600	default_action=action_equip	consume_type=consume_type_normal	initial_count=1	maximum_count=1	soulshot_count=1	spiritshot_count=1	reduced_soulshot={}	reduced_spiritshot={}	reduced_mp_consume={}	immediate_effect=1	price=0	default_price=768	item_skill=[none]	critical_attack_skill=[none]	attack_skill=[none]	magic_skill=[none]	item_skill_enchanted_four=[none]	material_type=steel	crystal_type=none	crystal_count=0	is_trade=1	is_drop=1	
			// is_destruct=1	physical_damage=8	random_damage=10	weapon_type=sword	can_penetrate=0	critical=8	hit_modify=0	avoid_modify=0	dual_fhit_rate=0	shield_defense=0	shield_defense_rate=0	attack_range=40	damage_range={0;0;40;120}	attack_speed=379	reuse_delay=0	mp_consume=0	magical_damage=6	durability=95	damaged=0	physical_defense=0	magical_defense=0	mp_bonus=0	category={}	enchanted=0	html=[item_default.htm]	equip_pet={0}	magic_weapon=0	enchant_enable=0	can_equip_sex=-1	can_equip_race={}	can_equip_change_class=-1	can_equip_class={}	can_equip_agit=-1	can_equip_castle=-1	can_equip_castle_num={}	can_equip_clan_leader=-1	can_equip_clan_level=-1	can_equip_hero=-1	can_equip_nobless=-1	can_equip_chaotic=-1	item_end
			// Dim UnDestrItems(30000) As String

			Array.Clear(aTemp, 0, aTemp.Length);
			var inItemFile = new System.IO.StreamReader("itemdata.txt", System.Text.Encoding.Default, true, 1);
			ProgressBar.Maximum = Conversions.ToInteger(inItemFile.BaseStream.Length);
			ProgressBar.Value = 0;
			StatusLabel.Text = "Loading itemdata and find all quest items ...";
			StatusLabel.Refresh();
			while (inItemFile.EndOfStream != true)
			{
				sTemp = inItemFile.ReadLine();
				if ((Libraries.GetNeedParamFromStr(sTemp, "item_type") ?? "") == "questitem")
				{
					// If Libraries.GetNeedParamFromStr(sTemp, "is_destruct") = "0" Then
					sTemp = sTemp.Replace(" = ", "=").Replace("  ", " ").Replace(" ", Conversions.ToString((char)9));
					aTemp = sTemp.Split((char)9);
					iTemp = Conversions.ToInteger(aTemp[2]);
					// array protect
					if (iTemp > UnDestrItems.Length)
					{
						MessageBox.Show("Itemdata use item with id >30000", "Big ItemID", MessageBoxButtons.OK, MessageBoxIcon.Error);
						inItemFile.Close();
						return;
					}
					UnDestrItems[iTemp] = aTemp[3];
				}

				ProgressBar.Value = Conversions.ToInteger(inItemFile.BaseStream.Position);
			}
			ProgressBar.Value = 0;
			inItemFile.Close();

			// quest_begin	id=257	level=1	name=[The Guard is Busy]
			// quest_begin	id=1	level=1	name=[Letters of Love]
			// Dim QuestPchName(2000) As String
			// [guard_is_busy1]	257
			// [letters_of_love1] 1

			// push_const 337
			// func_call 184680547	//  func[GetMemoState]
			// push_const 337
			// func_call 184680543	//  func[HaveMemo]
			// push_const 337
			// func_call 184615017	//  func[SetCurrentQuestID]
			// push_const 3856
			// func_call 184680579	//  func[OwnItemCount]

			// Dim QuestPch2Name(2000) As String
			// 257 4 1084 752 1085 1086  QuestPch2Name(257)
			// 1 4 687 688 1079 1080     QuestPch2Name(1)

			Array.Clear(aTemp, 0, aTemp.Length);
			string sLastPushConst = "";
			string sLastPushConst2 = "";
			string sLastQuestID = "";
			string sLastPushConstForOwnItem = "";
			string sLastClass = "";

			var inAiFile = new System.IO.StreamReader("ai.obj", System.Text.Encoding.Default, true, 1);
			ProgressBar.Maximum = Conversions.ToInteger(inAiFile.BaseStream.Length);
			ProgressBar.Value = 0;
			StatusLabel.Text = "Loading Ai.obj and find all quests ...";
			StatusLabel.Refresh();

			while (inAiFile.EndOfStream != true)
			{
				sTemp = inAiFile.ReadLine();

				if (sTemp.StartsWith("class ") == true)
					sLastClass = sTemp;
				if (Strings.InStr(sTemp, "push_parameter ") != 0)
					sLastPushConst2 = sLastPushConst;
				if (Strings.InStr(sTemp, "push_const ") != 0)
				{
					sLastPushConst2 = sLastPushConst;
					sLastPushConst = sTemp.Replace("push_const", "").Replace(Conversions.ToString((char)9), "").Replace(" ", "");
				}

				if (Strings.InStr(sTemp, "func_call") != 0)
				{
					if (Strings.InStr(sTemp, "[SetCurrentQuestID]") != 0)
					{

						// Bug fix ">0" againts 'Song of Hunter' quest
						if (Conversions.ToInteger(sLastPushConst) > 0)
							sLastQuestID = sLastPushConst;
						else
							MessageBox.Show("Wrong Number into :" + sLastClass);
					}

					if (Strings.InStr(sTemp, "[DeleteItem1]") != 0 | Strings.InStr(sTemp, "[OwnItemCount]") != 0)
					{
						// Or InStr(sTemp, "[GiveItem1]") <> 0
						// Or InStr(sTemp, "[OwnItemCount]") <> 0
						if (!string.IsNullOrEmpty(sLastQuestID))
						{
							sLastPushConstForOwnItem = sLastPushConst;

							if (Strings.InStr(sTemp, "[DeleteItem1]") != 0)
								sLastPushConstForOwnItem = sLastPushConst2;

							// PROCEDURE
							if (Conversions.ToInteger(sLastPushConstForOwnItem) <= UnDestrItems.Length)
							{
								if (!string.IsNullOrEmpty(UnDestrItems[Conversions.ToInteger(sLastPushConstForOwnItem)]))
								{
									if (!string.IsNullOrEmpty(sLastQuestID))
									{
										if (string.IsNullOrEmpty(QuestPchName[Conversions.ToInteger(sLastQuestID)]))
										{

											// Undefined quest in questname-e
											outLogFile.WriteLine(Constants.vbNewLine + "Last class: " + sLastClass + Constants.vbNewLine + "Undefined QuestId: " + sLastQuestID + " for Item " + sLastPushConstForOwnItem + " " + UnDestrItems[Conversions.ToInteger(sLastPushConstForOwnItem)]);
											// quest not exist in Questdata-e and not created in new list. Maybe later...
											if (MakeUndefinedBox.Checked == true)
											{
												QuestPchName[Conversions.ToInteger(sLastQuestID)] = "[autoquestgen_" + Conversions.ToInteger(sLastQuestID).ToString() + "]";
												QuestPch2Name[Conversions.ToInteger(sLastQuestID)] = sLastPushConstForOwnItem;
											}
										}
										else if (string.IsNullOrEmpty(QuestPch2Name[Conversions.ToInteger(sLastQuestID)]))
											// Quest exist in quest_pch list, but no items
											QuestPch2Name[Conversions.ToInteger(sLastQuestID)] = sLastPushConstForOwnItem;
										else
										{
											// Quest exist in quest_pch list, quest_pch2 record exist. check item in list
											Array.Clear(aTemp, 0, aTemp.Length);
											aTemp = QuestPch2Name[Conversions.ToInteger(sLastQuestID)].Split(Conversions.ToChar(" "));
											if (Array.IndexOf(aTemp, sLastPushConstForOwnItem) == -1)
												QuestPch2Name[Conversions.ToInteger(sLastQuestID)] = QuestPch2Name[Conversions.ToInteger(sLastQuestID)] + " " + sLastPushConstForOwnItem;
										}
									}
								}
							}
							else
								// check - bad item id
								outLogFile.WriteLine(Constants.vbNewLine + "Last class: " + sLastClass + Constants.vbNewLine + "Bad value for item: " + sLastPushConstForOwnItem);
						}
					}
				}

				if (Strings.InStr(sTemp, "handler_end") != 0)
				{
					sLastPushConst = "";
					sLastQuestID = "";
					sLastPushConstForOwnItem = "";
				}

				ProgressBar.Value = Conversions.ToInteger(inAiFile.BaseStream.Position);
			}
			ProgressBar.Value = 0;
			inAiFile.Close();

			StatusLabel.Text = "Writing quest_pch.txt file ...";
			var outQuestPchFile = new System.IO.StreamWriter(QuestDataDir + @"\quest_pch.txt", false, System.Text.Encoding.Unicode, 1);
			var loopTo = QuestPchName.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				if (!string.IsNullOrEmpty(QuestPchName[iTemp]))
					outQuestPchFile.WriteLine(QuestPchName[iTemp] + Constants.vbTab + iTemp.ToString());
			}
			outQuestPchFile.Close();

			StatusLabel.Text = "Writing quest_pch2.txt file ...";
			var outQuestPch2File = new System.IO.StreamWriter(QuestDataDir + @"\quest_pch2.txt", false, System.Text.Encoding.Unicode, 1);
			var loopTo1 = QuestPch2Name.Length - 1;
			for (iTemp = 0; iTemp <= loopTo1; iTemp++)
			{
				if (!string.IsNullOrEmpty(QuestPch2Name[iTemp]))
					outQuestPch2File.WriteLine(iTemp.ToString() + " " + QuestPch2Name[iTemp].Split(Conversions.ToChar(" ")).Length.ToString() + " " + QuestPch2Name[iTemp]);
			}
			outQuestPch2File.Close();

			outLogFile.WriteLine(Constants.vbNewLine + DateAndTime.Now.ToString() + " End" + Constants.vbNewLine);
			outLogFile.Close();

			StatusLabel.Text = "Work complete ...";
		}

		private void QuestCacheScript_Click(object sender, EventArgs e)
		{
			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II config (quest_pch.txt)|quest_pch.txt|All files (*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			string QuestDataDir = System.IO.Path.GetDirectoryName(OpenFileDialog.FileName);
			if (System.IO.File.Exists("quest_pch2.txt") == false)
			{
				MessageBox.Show("Required all files (quest_pch.txt and quest_pch2.txt) for generation", "quest_pch2.txt not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Initialization
			ProgressBar.Value = 0;
			var inPchFile = new System.IO.StreamReader("quest_pch.txt", System.Text.Encoding.Default, true, 1);
			var inPch2File = new System.IO.StreamReader("quest_pch2.txt", System.Text.Encoding.Default, true, 1);
			var outData = new System.IO.StreamWriter("questcomp.txt", false, System.Text.Encoding.Unicode, 1);
			// Dim outData As New System.IO.StreamWriter(oFile, System.Text.Encoding.Unicode, 1)

			string ReadStr;
			string[] ReadSplitStr;

			// quest_pch.txt      -   1 4 687 688 1079 1080 
			// quest_pch2.txt     -   [gourd_event]	997
			// questcomp.txt    -   [0001]	letters_of_love1	{687;688;1079;1080}

			ProgressBar.Value = 0;
			ProgressBar.Maximum = Conversions.ToInteger(inPchFile.BaseStream.Length);
			var QuestDB = new string[1001];
			while (inPchFile.EndOfStream != true)
			{
				ReadStr = inPchFile.ReadLine().Replace((char)9, (char)32);
				if (ReadStr != null)
				{
					if ((Strings.Mid(ReadStr, 1, 2) ?? "") != "//")
					{
						ReadSplitStr = ReadStr.Trim().Split();
						QuestDB[Conversions.ToInteger(ReadSplitStr[1])] = ReadSplitStr[0].Replace("[", "").Replace("]", "");
					}
				}
				ProgressBar.Value = Conversions.ToInteger(inPchFile.BaseStream.Position * 100 / (double)inPchFile.BaseStream.Length);
			}

			// quest_pch.txt      -   1 4 687 688 1079 1080 
			// quest_pch2.txt     -   [gourd_event]	997
			// questcomp-e.txt    -   [0001]	letters_of_love1	{687;688;1079;1080}

			ProgressBar.Maximum = Conversions.ToInteger(inPch2File.BaseStream.Length);
			ProgressBar.Value = 0;
			while (inPch2File.BaseStream.Position != inPch2File.BaseStream.Length)
			{
				ReadStr = inPch2File.ReadLine().Replace((char)9, (char)32);

				if (ReadStr != null)
				{
					if ((Strings.Mid(Strings.Trim(ReadStr), 1, 2) ?? "") != "//")
					{
						ReadSplitStr = ReadStr.Trim().Split((char)32);

						outData.Write("[" + Conversions.ToInteger(ReadSplitStr[0]).ToString().PadLeft(4, Conversions.ToChar("0")) + "]" + Conversions.ToString((char)9));
						outData.Write(QuestDB[Conversions.ToInteger(ReadSplitStr[0])] + Conversions.ToString((char)9));

						outData.Write("{");
						int Marker;
						var loopTo = ReadSplitStr.Length - 1;
						for (Marker = 2; Marker <= loopTo; Marker++)
						{
							if (Marker > 2)
								outData.Write(";");
							outData.Write(ReadSplitStr[Marker]);
						}

						outData.WriteLine("}");
					}
				}

				ProgressBar.Value = Conversions.ToInteger(inPch2File.BaseStream.Position * 100 / (double)inPch2File.BaseStream.Length);
			}

			MessageBox.Show("questcomp-e Complete");
			ProgressBar.Value = 0;
			inPchFile.Close();
			inPch2File.Close();
			outData.Close();
		}

		private void ButtonExit_Click(object sender, EventArgs e)
		{
			// Me.Dispose()
			this.Close();
		}
	}
}
