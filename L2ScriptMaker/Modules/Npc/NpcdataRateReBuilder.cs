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

namespace L2ScriptMaker.Modules.Npc
{
	public partial class NpcdataRateReBuilder : Form
	{
		public NpcdataRateReBuilder()
		{
			InitializeComponent();
		}


		// ItemGroup1(ItemId/name , MinItem, MaxItem, chance)

		private void StartButton_Click(object sender, EventArgs e)
		{
			string sWorkFile;

			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			sWorkFile = OpenFileDialog.FileName;

			System.IO.File.Copy(sWorkFile, sWorkFile + ".bak", true);
			var fInFile = new System.IO.StreamReader(sWorkFile + ".bak", System.Text.Encoding.Default, true, 1);
			var fOutFile = new System.IO.StreamWriter(sWorkFile, false, System.Text.Encoding.Unicode);
			string sTemp;
			var aNpcType = new string[16]; // 15 - params in npcdata npc definition

			ProgressBar.Maximum = Conversions.ToInteger(fInFile.BaseStream.Length);
			ProgressBar.Value = 0;
			while (fInFile.EndOfStream != true)
			{
				sTemp = fInFile.ReadLine();

				if (!string.IsNullOrEmpty(sTemp.Trim()) & sTemp.StartsWith("//") == false)
				{

					// npc_begin(0)	warrior(1)	1(2)	[gremlin](3)	level=1	acquire_exp_rate=29.39
					sTemp = sTemp.Replace("  ", " ").Replace((char)32, (char)9);
					aNpcType = sTemp.Split((char)9);

					// If UseIgnoreListBox.Checked = True And IgnoreNpcCheckedListBox.CheckedItems.IndexOf(aNpcType(1)) <> -1 Then GoTo LeaveWithoutChanges

					if (RadioButton2.Checked == true & IgnoreNpcCheckedListBox.CheckedItems.IndexOf(aNpcType[1]) != -1)
						goto LeaveWithoutChanges;
					if (RadioButton3.Checked == true & IgnoreNpcCheckedListBox.CheckedItems.IndexOf(aNpcType[1]) == -1)
						goto LeaveWithoutChanges;

					if (IgnoreNpcNameCheckBox.Checked == true & Strings.InStr(IgnoreNpcNamesTextBox.Text, aNpcType[3]) != 0)
						goto LeaveWithoutChanges;

					// npc found in ignore list. Nothing happening. Write as is.
					sTemp = ParamChange(sTemp, "acquire_exp_rate", Conversions.ToDouble(MultExpBox.Text));
					sTemp = ParamChange(sTemp, "acquire_sp", Conversions.ToDouble(MultSPBox.Text));
					sTemp = DropChange(sTemp, "additional_make_multi_list", Conversions.ToDouble(MultDropBox.Text));
					sTemp = SpoilChange(sTemp, "corpse_make_list", Conversions.ToDouble(MultSpoilBox.Text));
				LeaveWithoutChanges:
					;
				}

				fOutFile.WriteLine(sTemp);
				ProgressBar.Value = Conversions.ToInteger(fInFile.BaseStream.Position);
			}


			fInFile.Close();
			fOutFile.Close();

			MessageBox.Show("Work complete.", "Complete", MessageBoxButtons.OK);
			ProgressBar.Value = 0;
		}


		private string ParamChange(string StrLine, string ParamName, double RateValue)
		{
			string ParamChangeRet = default(string);
			string sParam;
			// Dim dblChcIn As Double, 
			double dblChcOut;
			;

			// #error Cannot convert OnErrorGoToStatementSyntax - see comment for details

			/* Cannot convert OnErrorGoToStatementSyntax, CONVERSION ERROR: Conversion for OnErrorGoToLabelStatement not implemented, please report this issue in 'On Error GoTo ErrorMessage' at character 2873
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

					On Error GoTo ErrorMessage

			 */

			try
			{
				sParam = Libraries.GetNeedParamFromStr(StrLine, ParamName);
				// dblChcIn = CDbl(sParam )
				dblChcOut = Conversions.ToDouble(Strings.Format(Conversions.ToDouble(sParam) * RateValue, "0.####"));
				if ((ParamName ?? "") == "acquire_exp_rate")
				{
					if (dblChcOut < 0)
						dblChcOut = 0;
				}
				if ((ParamName ?? "") == "acquire_sp")
				{
					if (dblChcOut < 0)
						dblChcOut = 0;
					dblChcOut = Convert.ToInt64(dblChcOut);
				}
				ParamChangeRet = Libraries.SetNeedParamToStr(StrLine, ParamName, Conversions.ToString(dblChcOut));
				// ParamChange = StrLine.Replace(ParamName & "=" & dblChcIn, ParamName & "=" & dblChcOut)

				return ParamChangeRet;
			}
			catch (Exception e)
			{
				MessageBox.Show("Program cause error [" + e.Message + "] in rate process with param:[" + ParamName + "] and keep old value without changes. Last data:" + Constants.vbNewLine + "[" + StrLine + "]");
				return StrLine;
				throw;
			}

			//ErrorMessage:
			//	;
			//	MessageBox.Show("Program cause error [" + Information.Err().Description + "] in rate process with param:[" + ParamName + "] and keep old value without changes. Last data:" + Constants.vbNewLine + "[" + StrLine + "]");
			//	return StrLine;
		}


		private double SumChanges(double[] ItemChances)
		{
			int iTemp;
			var Summ = default(double);
			var loopTo = ItemChances.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
				Summ = Summ + ItemChances[iTemp];

			return Summ;
		}

		private string DropChange(string StrLine, string ParamName, double RateValue)
		{
			string DropChangeRet = default(string);
			string sParam;

			// PROCEDURE

			string sTempParam;
			int iTemp;
			int iForTemp;
			double dblChcIn; // , dblChcOut As Double
			var ItemGroupList = new string[101];
			var ItemGroupListChance = new double[101];
			var AggrMetodDrop = new int[101]; // , AggrMetodSpoil As Integer
			int RateLimit = Conversions.ToInteger(RateLimitTextBox.Text);

			if (RateLimitTextBox.Enabled == true)
				RateLimit = Conversions.ToInteger(RateLimitTextBox.Text);
			else
				RateLimit = 100;

			sParam = Libraries.GetNeedParamFromStr(StrLine, ParamName);

			if ((sParam ?? "") != "{}")
			{
				Array.Clear(ItemGroupList, 0, ItemGroupList.Length);
				Array.Clear(ItemGroupListChance, 0, ItemGroupListChance.Length);
				sTempParam = sParam.Replace("{{{{", "{"); // additional_make_multi_list
				sTempParam = sTempParam.Remove(sTempParam.Length - 1, 1); // additional_make_multi_list

				ItemGroupList = sTempParam.Replace(";{{", "|").Split((char)124); // 124 - | ' additional_make_multi_list
				var loopTo = ItemGroupList.Length - 1;

				// Generating table with chances
				for (iForTemp = 0; iForTemp <= loopTo; iForTemp++)
				{
					iTemp = Strings.InStr(ItemGroupList[iForTemp], "}};");   // additional_make_multi_list
					dblChcIn = Conversions.ToDouble(Strings.Mid(ItemGroupList[iForTemp], iTemp + 3, ItemGroupList[iForTemp].Length - iTemp - 3));
					// ItemGroupList(iForTemp) = ItemGroupList(iForTemp).Replace("}};" & dblChcIn.ToString & "}", "}")
					ItemGroupList[iForTemp] = ItemGroupList[iForTemp].Remove(iTemp, ItemGroupList[iForTemp].Length - iTemp);
					ItemGroupListChance[iForTemp] = dblChcIn;
				}


				// -----  MAke CHANCE for groups
				// NORMAL Metod Chance and 100% max Metod Chance 
				if (NormalRadioButton.Checked == true | Max100RadioButton.Checked == true)
				{
					var loopTo1 = ItemGroupList.Length - 1;
					for (iForTemp = 0; iForTemp <= loopTo1; iForTemp++)
					{
						if (Strings.InStr(ItemGroupList[iForTemp], "[adena]") == 0 & Strings.InStr(ItemGroupList[iForTemp], "sealstone]") == 0)
							ItemGroupListChance[iForTemp] = ItemGroupListChance[iForTemp] * RateValue;
						else
						{
						}
						// 100% correction
						if (Max100RadioButton.Checked == true)
						{
							if (ItemGroupListChance[iForTemp] > RateLimit)
								ItemGroupListChance[iForTemp] = RateLimit;
						}
					}
				}

				// AGRESSIVE Metod Chance 
				if (AgressiveRadioButton.Checked == true)
				{
					var loopTo2 = ItemGroupList.Length - 1;
					for (iForTemp = 0; iForTemp <= loopTo2; iForTemp++)
					{
						// 100% correction
						if (Strings.InStr(ItemGroupList[iForTemp], "[adena]") == 0 & Strings.InStr(ItemGroupList[iForTemp], "sealstone]") == 0)
						{
							ItemGroupListChance[iForTemp] = ItemGroupListChance[iForTemp] * RateValue;
							if (ItemGroupListChance[iForTemp] > RateLimit)
							{
								AggrMetodDrop[iForTemp] = Conversions.ToInteger(Conversions.Fix(ItemGroupListChance[iForTemp] / RateLimit));
								ItemGroupListChance[iForTemp] = RateLimit;
							}
						}
						else
						{
						}
					}
				}

				// BALANCED Metod Chance 
				if (BalancedRadioButton.Checked == true)
				{
					var loopTo3 = ItemGroupList.Length - 1;
					for (iForTemp = 0; iForTemp <= loopTo3; iForTemp++)
					{
						// 100% correction
						if (Strings.InStr(ItemGroupList[iForTemp], "[adena]") == 0 & Strings.InStr(ItemGroupList[iForTemp], "sealstone]") == 0)
						{
							if (ItemGroupListChance[iForTemp] * RateValue > RateLimit)
								AggrMetodDrop[iForTemp] = Conversions.ToInteger(RateValue);
							else
							{
								ItemGroupListChance[iForTemp] = ItemGroupListChance[iForTemp] * RateValue;
								AggrMetodDrop[iForTemp] = 1;
							}
						}
						else
						{
						}
					}
				}

				// "No Low No More" Metod Chance 
				if (NolownomoreRadioButton.Checked == true)
				{
					var loopTo4 = ItemGroupList.Length - 1;
					for (iForTemp = 0; iForTemp <= loopTo4; iForTemp++)
					{
						// 100% correction
						if (Strings.InStr(ItemGroupList[iForTemp], "[adena]") == 0 & Strings.InStr(ItemGroupList[iForTemp], "sealstone]") == 0)
						{
							if (ItemGroupListChance[iForTemp] * RateValue > RateLimit)
								AggrMetodDrop[iForTemp] = Conversions.ToInteger(Conversions.Fix(ItemGroupListChance[iForTemp] * RateValue) / RateLimit);
							else
							{
								ItemGroupListChance[iForTemp] = ItemGroupListChance[iForTemp] * RateValue;
								AggrMetodDrop[iForTemp] = 1;
							}
						}
						else
						{
						}
					}
				}

				sTempParam = "{";
				var loopTo5 = ItemGroupList.Length - 1;
				for (iForTemp = 0; iForTemp <= loopTo5; iForTemp++)
				{
					if (iForTemp > 0 & iForTemp <= ItemGroupList.Length - 1)
						sTempParam = sTempParam + ";";

					// ITEM VALUE FIX
					int isDrop = 0;
					if (Strings.InStr(ItemGroupList[iForTemp], "[adena]") != 0)
						isDrop = 1; // adena
					if (Strings.InStr(ItemGroupList[iForTemp], "sealstone]") != 0)
						isDrop = 2; // sealstone
					switch (isDrop)
					{
						case 0:
							{
								if (BalancedRadioButton.Checked == false & NolownomoreRadioButton.Checked == false)
									ItemGroupList[iForTemp] = FixValueInTable(ItemGroupList[iForTemp], Conversions.ToDouble(AmnDropBox.Text) + (double)AggrMetodDrop[iForTemp]);
								else
									ItemGroupList[iForTemp] = FixValueInTable(ItemGroupList[iForTemp], (double)(Conversions.ToInteger(AmnDropBox.Text) * AggrMetodDrop[iForTemp]));
								break;
							}

						case 1:
							{
								ItemGroupList[iForTemp] = FixValueInTable(ItemGroupList[iForTemp], Conversions.ToDouble(AmnAdenaBox.Text));
								break;
							}

						case 2:
							{
								ItemGroupList[iForTemp] = FixValueInTable(ItemGroupList[iForTemp], Conversions.ToDouble(AmnSStoneBox.Text));
								break;
							}
					}
					// ITEM VALUE FIX END

					// ItemGroupList(iForTemp) = "{{" & ItemGroupList(iForTemp).Replace("}};" & dblChcIn.ToString & "}", "}};" & ItemGroupList(iForTemp).ToString & "}")
					// ItemGroupList(iForTemp) = "{{" & ItemGroupList(iForTemp) '& "}"
					ItemGroupList[iForTemp] = "{{" + ItemGroupList[iForTemp] + "};" + ItemGroupListChance[iForTemp].ToString() + "}";
					sTempParam = sTempParam + ItemGroupList[iForTemp];
				}
				sTempParam = sTempParam + "}";
				DropChangeRet = StrLine.Replace(sParam, sTempParam);
			}
			else
				DropChangeRet = StrLine;
			return DropChangeRet;
		}

		private string FixValueInTable(string ItemGroup, double RateValue)
		{

			// "{[piece_bone_breastplate];1;1;2.2988};{[piece_bone_breastplate_fragment];1;1;36.9195}
			// ;{[bronze_breastplate];1;1;1.4858};{[piece_bone_gaiters];1;1;3.6734};{[piece_bone_gaiters_fragment];1;1;53.2415};
			// {[bronze_gaiters];1;1;2.381}};2.3887}"

			if (RateValue == 1)
				return ItemGroup;

			var ItemGroupList = new string[1];
			var ItemList = new string[1];
			string sTemp;
			int iTemp;
			int iTemp2;
			int iTemp3;
			// for Special list
			bool isSpecialItem;

			// iTemp = InStr(ItemGroup, "}};")
			// dblChanceTemp = CDbl(Mid(ItemGroup, iTemp + 3, ItemGroup.Length - iTemp - 3))
			// sTemp = ItemGroup.Remove(iTemp - 1, (ItemGroup.Length - iTemp + 1)).Remove(0, 1)
			// If RateValue = 1 Then
			// Return "{" & sTemp & "}"
			// End If

			sTemp = ItemGroup.Substring(1, ItemGroup.Length - 2);
			Array.Clear(ItemGroupList, 0, ItemGroupList.Length);
			ItemGroupList = sTemp.Replace("};{", "|").Split(Conversions.ToChar("|"));

			ItemGroup = "";
			var loopTo = ItemGroupList.Length - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				if (iTemp > 0 & iTemp <= ItemGroupList.Length - 1)
					ItemGroup = ItemGroup + ";";

				Array.Clear(ItemList, 0, ItemList.Length);
				ItemList = ItemGroupList[iTemp].Split(Conversions.ToChar(";"));
				var loopTo1 = ItemList.Length - 1;
				for (iTemp2 = 2; iTemp2 <= loopTo1; iTemp2 += 4)
				{
					if (AmnChgItemListBox.Checked == true)
					{
						SpecialItemsListTextBox.Text = SpecialItemsListTextBox.Text.Trim();
						isSpecialItem = false;
						var loopTo2 = SpecialItemsListTextBox.Lines.Length - 1;
						for (iTemp3 = 0; iTemp3 <= loopTo2; iTemp3++)
						{
							if ((ItemList[0] ?? "") == (SpecialItemsListTextBox.Lines[iTemp3] ?? ""))
							{
								isSpecialItem = true;
								break;
							}
						}
						if (isSpecialItem == true)
						{
							ItemList[iTemp2] = Conversions.ToString(Conversions.ToDouble(ItemList[iTemp2]) * RateValue);
							if (AmnChgBothBox.Checked == true)
								ItemList[iTemp2 - 1] = Conversions.ToString(Conversions.ToDouble(ItemList[iTemp2 - 1]) * RateValue);
						}
					}
					else
					{

						// Fix any items
						ItemList[iTemp2] = Conversions.ToString(Conversions.ToDouble(ItemList[iTemp2]) * RateValue);
						if (AmnChgBothBox.Checked == true)
							ItemList[iTemp2 - 1] = Conversions.ToString(Conversions.ToDouble(ItemList[iTemp2 - 1]) * RateValue);
					}
				}
				// Fix for Int amount
				// Fix for Int amount
				if (Conversions.ToInteger(ItemList[1]) < 1)
					ItemList[1] = "1";
				if (Conversions.ToInteger(ItemList[2]) < 1)
					ItemList[2] = "1";
				ItemList[1] = Conversions.ToString(Conversions.ToInteger(ItemList[1])); ItemList[2] = Conversions.ToString(Conversions.ToInteger(ItemList[2]));
				ItemGroupList[iTemp] = Strings.Join(ItemList, ";");
				ItemGroup = ItemGroup + "{" + ItemGroupList[iTemp] + "}";
			}
			return ItemGroup;
		}

		private string SpoilChange(string StrLine, string ParamName, double RateValue)
		{
			string SpoilChangeRet = default(string);
			string sParam;
			string sTempParam;
			int iTemp;
			string[] ItemGroupList;
			string[] ItemGroupItemList;
			// Dim ItemGroupListChance(3) As Double
			int RateLimit = Conversions.ToInteger(RateLimitTextBox.Text);

			if (RateLimitTextBox.Enabled == true)
				RateLimit = Conversions.ToInteger(RateLimitTextBox.Text);
			else
				RateLimit = 100;

			// PROCEDURE
			// corpse_make_list={  {[charcoal];1;1;5.6617};{[magic_ring];1;1;34.3131};{[rp_broad_sword];1;1;4.5293} }
			sParam = Libraries.GetNeedParamFromStr(StrLine, "corpse_make_list");

			if ((sParam ?? "") != "{}")
			{

				// Array.Clear(ItemGroupList, 0, ItemGroupList.Length)

				sTempParam = sParam.Replace("{{", "").Replace("}}", "");  // corpse_make_list
				ItemGroupList = sTempParam.Replace("};{", "|").Split((char)124); // 124 - | ' corpse_make_list
				var ItemGroupListChance = new double[ItemGroupList.Length + 1];
				var loopTo = ItemGroupList.Length - 1;


				// Generating table with chances
				for (iTemp = 0; iTemp <= loopTo; iTemp++)
				{
					ItemGroupItemList = ItemGroupList[iTemp].Split(Conversions.ToChar(";"));
					ItemGroupListChance[iTemp] = Conversions.ToDouble(ItemGroupItemList[3]);
				}

				// -----  MAke CHANCE for groups
				// NORMAL Metod Chance and 100% max metod chance
				if (NormalRadioButton.Checked == true | Max100RadioButton.Checked == true)
				{
					var loopTo1 = ItemGroupList.Length - 1;
					for (iTemp = 0; iTemp <= loopTo1; iTemp++)
					{
						ItemGroupListChance[iTemp] = ItemGroupListChance[iTemp] * RateValue;
						// 100% correction for Normal mode (drop all rates more them 100%)
						if (Max100RadioButton.Checked == true)
						{
							if (ItemGroupListChance[iTemp] > RateLimit)
								ItemGroupListChance[iTemp] = RateLimit;
						}
					}
				}

				// AGRESSIVE Metod Chance 
				var AggrMetodDrop = new int[ItemGroupList.Length + 1]; // , AggrMetodSpoil As Integer
				if (AgressiveRadioButton.Checked == true)
				{
					var loopTo2 = ItemGroupList.Length - 1;
					for (iTemp = 0; iTemp <= loopTo2; iTemp++)
					{
						// 100% correction
						ItemGroupListChance[iTemp] = ItemGroupListChance[iTemp] * RateValue;
						if (ItemGroupListChance[iTemp] > RateLimit)
						{
							AggrMetodDrop[iTemp] = Conversions.ToInteger(Conversions.Fix(ItemGroupListChance[iTemp] / RateLimit));
							ItemGroupListChance[iTemp] = RateLimit;
						}
					}
				}

				// BALANCED Metod Chance 
				if (BalancedRadioButton.Checked == true)
				{
					var loopTo3 = ItemGroupList.Length - 1;
					for (iTemp = 0; iTemp <= loopTo3; iTemp++)
					{
						if (ItemGroupListChance[iTemp] * RateValue > RateLimit)
							AggrMetodDrop[iTemp] = Conversions.ToInteger(RateValue);
						else
						{
							ItemGroupListChance[iTemp] = ItemGroupListChance[iTemp] * RateValue;
							AggrMetodDrop[iTemp] = 1;
						}
					}
				}

				// "Gold Middle" METOD 
				if (GoldMiddleRadioButton.Checked == true)
				{
					var loopTo4 = ItemGroupList.Length - 1;
					for (iTemp = 0; iTemp <= loopTo4; iTemp++)
						ItemGroupListChance[iTemp] = ItemGroupListChance[iTemp] * RateValue;
					double ChanceSumm;
					double ChanceKoeff;
					ChanceSumm = SumChanges(ItemGroupListChance);
					ChanceKoeff = ChanceSumm / RateLimit;
					var loopTo5 = ItemGroupList.Length - 1;

					// 259 - x%
					// 100 - 100%
					for (iTemp = 0; iTemp <= loopTo5; iTemp++)
						ItemGroupListChance[iTemp] = Conversions.ToDouble((ItemGroupListChance[iTemp] / ChanceKoeff).ToString(".0000"));
				}

				// END NEW CODE

				sTempParam = "{";
				var loopTo6 = ItemGroupList.Length - 1;
				for (iTemp = 0; iTemp <= loopTo6; iTemp++)
				{
					if (iTemp > 0 & iTemp <= ItemGroupList.Length - 1)
						sTempParam = sTempParam + ";";

					// NEW CODE

					// AMOUNT SPOIL RATE
					if (BalancedRadioButton.Checked == false)
						ItemGroupList[iTemp] = FixValueInTableSpoil(ItemGroupList[iTemp], Conversions.ToDouble(AmnSpoilBox.Text) + (double)AggrMetodDrop[iTemp]);
					else
						ItemGroupList[iTemp] = FixValueInTableSpoil(ItemGroupList[iTemp], Conversions.ToDouble(AmnSpoilBox.Text) * (double)AggrMetodDrop[iTemp]);
					ItemGroupItemList = ItemGroupList[iTemp].Split(Conversions.ToChar(";"));
					ItemGroupItemList[3] = Conversions.ToString(ItemGroupListChance[iTemp]);

					// ItemGroupList(iForTemp) = "{" & ItemGroupItemList(0) & ";" & ItemGroupItemList(1) & ";" & ItemGroupItemList(2) & ";" & dblChcOut.ToString & "}"
					ItemGroupList[iTemp] = "{" + Strings.Join(ItemGroupItemList, ";") + "}";
					sTempParam = sTempParam + ItemGroupList[iTemp];
				}
				sTempParam = sTempParam + "}";
				SpoilChangeRet = StrLine.Replace(sParam, sTempParam);
			}
			else
				SpoilChangeRet = StrLine;
			return SpoilChangeRet;
		}

		private string FixValueInTableSpoil(string ItemGroup, double RateValue)
		{

			// "{[piece_bone_breastplate];1;1;2.2988};{[piece_bone_breastplate_fragment];1;1;36.9195}
			// ;{[bronze_breastplate];1;1;1.4858};{[piece_bone_gaiters];1;1;3.6734};{[piece_bone_gaiters_fragment];1;1;53.2415};
			// {[bronze_gaiters];1;1;2.381}};2.3887}"

			if (RateValue == 1)
				return ItemGroup;

			var ItemList = new string[1];
			int iTemp3;
			// for Special list
			bool isSpecialItem;

			Array.Clear(ItemList, 0, ItemList.Length);
			ItemList = ItemGroup.Split(Conversions.ToChar(";"));

			ItemGroup = "";

			if (AmnChgItemListBox.Checked == true)
			{
				// SpecialItemsListTextBox
				isSpecialItem = false;
				var loopTo = SpecialItemsListTextBox.Lines.Length - 1;
				for (iTemp3 = 0; iTemp3 <= loopTo; iTemp3++)
				{
					if ((ItemList[0] ?? "") == (SpecialItemsListTextBox.Lines[iTemp3] ?? ""))
					{
						isSpecialItem = true;
						break;
					}
				}
				if (isSpecialItem == true)
				{
					ItemList[2] = Conversions.ToString(Conversions.ToDouble(ItemList[2]) * RateValue);
					if (AmnChgBothBox.Checked == true)
						ItemList[1] = Conversions.ToString(Conversions.ToDouble(ItemList[1]) * RateValue);
				}
			}
			else
			{

				// Fix any items
				ItemList[2] = Conversions.ToString(Conversions.ToDouble(ItemList[2]) * RateValue);
				if (AmnChgBothBox.Checked == true)
					ItemList[1] = Conversions.ToString(Conversions.ToDouble(ItemList[1]) * RateValue);
			}
			// Fix for Int amount
			if (Conversions.ToInteger(ItemList[1]) < 1)
				ItemList[1] = "1";
			if (Conversions.ToInteger(ItemList[2]) < 1)
				ItemList[2] = "1";
			ItemList[1] = Conversions.ToString(Conversions.ToInteger(ItemList[1])); ItemList[2] = Conversions.ToString(Conversions.ToInteger(ItemList[2]));
			ItemGroup = Strings.Join(ItemList, ";");

			return ItemGroup;
		}

		private void AmnDropBox_Validated(object sender, EventArgs e)
		{
			// AmnDropBox.Text = CInt(AmnDropBox.Text).ToString
			if (Conversions.Val(AmnDropBox.Text) <= 0)
				AmnDropBox.Text = "1";
		}

		private void AmnSpoilBox_Validated(object sender, EventArgs e)
		{
			// AmnSpoilBox.Text = CInt(AmnSpoilBox.Text).ToString
			if (Conversions.Val(AmnSpoilBox.Text) <= 0)
				AmnSpoilBox.Text = "1";
		}

		private void AmnAdenaBox_Validated(object sender, EventArgs e)
		{
			// AmnAdenaBox.Text = CInt(AmnAdenaBox.Text).ToString
			if (Conversions.Val(AmnAdenaBox.Text) <= 0)
				AmnAdenaBox.Text = "1";
		}

		private void AmnSStoneBox_Validated(object sender, EventArgs e)
		{
			// AmnSStoneBox.Text = CInt(AmnSStoneBox.Text).ToString
			if (Conversions.Val(AmnSStoneBox.Text) <= 0)
				AmnSStoneBox.Text = "1";
		}



		private void IgnoreNpcSelectAllButton_Click(object sender, EventArgs e)
		{
			int iTemp;
			var loopTo = IgnoreNpcCheckedListBox.Items.Count - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
				IgnoreNpcCheckedListBox.SetItemChecked(iTemp, true);
		}

		private void IgnoreNpcDeselectAllButton_Click(object sender, EventArgs e)
		{
			int iTemp;
			var loopTo = IgnoreNpcCheckedListBox.Items.Count - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
				IgnoreNpcCheckedListBox.SetItemChecked(iTemp, false);
		}

		private void IgnoreNpcSelectionInvertButton_Click(object sender, EventArgs e)
		{
			int iTemp;
			var loopTo = IgnoreNpcCheckedListBox.Items.Count - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				if (IgnoreNpcCheckedListBox.GetItemChecked(iTemp) == false)
					IgnoreNpcCheckedListBox.SetItemChecked(iTemp, true);
				else
					IgnoreNpcCheckedListBox.SetItemChecked(iTemp, false);
			}
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void UseIgnoreListBox_CheckedChanged(object sender, EventArgs e)
		{
			if (RadioButton1.Checked == false)
				IgnoreNpcCheckedListBox.Enabled = true;
			else
				IgnoreNpcCheckedListBox.Enabled = false;
		}

		private void RateLimitCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (RateLimitTextBox.Enabled == false)
				RateLimitTextBox.Enabled = true;
			else
				RateLimitTextBox.Enabled = false;
		}

		private void RateLimitTextBox_Validated(object sender, EventArgs e)
		{
			RateLimitTextBox.Text = Conversions.ToInteger(RateLimitTextBox.Text).ToString();
			if (Conversions.ToInteger(RateLimitTextBox.Text) <= 0)
				RateLimitTextBox.Text = "100";
		}

		private void IgnoreNpcNameCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (IgnoreNpcNameCheckBox.Checked == false)
				IgnoreNpcNamesTextBox.Enabled = false;
			else
				IgnoreNpcNamesTextBox.Enabled = true;
		}

		private void NpcdataRateReBuilder_Load(object sender, EventArgs e)
		{
			MessageBox.Show("Decimal delimiter in 'Regional Settings' must be set to '.'", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
	}
}
