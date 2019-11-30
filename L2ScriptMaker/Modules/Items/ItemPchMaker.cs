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
	public partial class ItemPchMaker : Form
	{
		public ItemPchMaker()
		{
			InitializeComponent();
		}


		// Dim TabSymbol As String = Chr(9)
		private string TabSymbol = " ";

		private void StartButton_Click(object sender, EventArgs e)
		{
			string TempStr;
			// Dim FirstPos, SecondPos As Integer
			string[] ItemData;
			string ItemDataFile, ItemDataDir;

			OpenFileDialog.InitialDirectory = Environment.CurrentDirectory;
			OpenFileDialog.Filter = "Lineage II Item config (itemdata.txt)|itemdata.txt|All files (*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;
			ItemDataFile = OpenFileDialog.FileName;
			ItemDataDir = System.IO.Path.GetDirectoryName(ItemDataFile);

			var inItemData = new System.IO.StreamReader(ItemDataFile, System.Text.Encoding.Default, true, 1);

			if (System.IO.File.Exists(ItemDataDir + @"\item_pch.txt") == true)
			{
				if ((int)MessageBox.Show("File item_pch.txt exist. Overwrite?", "Overwrite?", MessageBoxButtons.OKCancel) == (int)DialogResult.Cancel)
					return;
			}

			System.IO.Stream oPchFile = new System.IO.FileStream(ItemDataDir + @"\item_pch.txt", System.IO.FileMode.Create, System.IO.FileAccess.Write);
			var outItemPchData = new System.IO.StreamWriter(oPchFile, System.Text.Encoding.Unicode);

			System.IO.Stream oErrFile = new System.IO.FileStream(ItemDataDir + @"\~item_pch.log", System.IO.FileMode.Create, System.IO.FileAccess.Write);
			var outErrPchData = new System.IO.StreamWriter(oErrFile, System.Text.Encoding.Unicode);

			outErrPchData.WriteLine(DateAndTime.Now);

			while (inItemData.BaseStream.Position != inItemData.BaseStream.Length)
			{

				// ItemData = Replace(inItemData.ReadLine, Chr(9), TabSymbol).Split(Chr(32))
				TempStr = Strings.Replace(inItemData.ReadLine(), "\t", TabSymbol);

				if (!String.IsNullOrWhiteSpace(TempStr) && (Strings.Mid(Strings.Trim(TempStr), 1, 2) ?? "") != "//" & Strings.InStr(TempStr, "set_begin") == 0)
				{

					// tabs and spaces correction
					while (Strings.InStr(TempStr, "  ") != 0)
						TempStr = Strings.Replace(TempStr, "  ", TabSymbol);
					ItemData = TempStr.Split((char)32);


					if (Strings.InStr(ItemData[0], "item_begin") != 0)
					{
						outItemPchData.Write(ItemData[3] + TabSymbol + "=" + TabSymbol);
						outItemPchData.WriteLine(ItemData[2]);
					}
					else
					{
					}
				}

				ProgressBar.Value = Conversions.ToInteger(inItemData.BaseStream.Position * 100 / (double)inItemData.BaseStream.Length);
			}

			inItemData.Close();
			outItemPchData.Close();
			outErrPchData.Close();

			System.IO.File.Create(ItemDataDir + @"\item_pch2.txt");


			ProgressBar.Value = 0;
		}

		private void ItemCacheScript_Click(object sender, EventArgs e)
		{
			// 1      [Short Sword]   [no description]      consume_type_normal     0

			OpenFileDialog.FileName = "";
			OpenFileDialog.Filter = "Lineage II config (itemdata.txt)|itemdata.txt|All files (*.*)|*.*";
			if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			System.IO.StreamReader inEFile;
			try
			{
				inEFile = new System.IO.StreamReader(System.IO.Path.GetDirectoryName(OpenFileDialog.FileName) + @"\itemname-e.txt", System.Text.Encoding.Default, true, 1);
			}
			catch (Exception ex)
			{
				MessageBox.Show("You must have itemdata-e in work folder for generation itemcache file. Put and try again.");
				return;
			}

			// Initialization
			ProgressBar.Value = 0;
			var inFile = new System.IO.StreamReader(OpenFileDialog.FileName, System.Text.Encoding.Default, true, 1);
			System.IO.Stream oAiFile = new System.IO.FileStream(System.IO.Path.GetDirectoryName(OpenFileDialog.FileName) + @"\itemcache.txt", System.IO.FileMode.Create, System.IO.FileAccess.Write);
			var outAiData = new System.IO.StreamWriter(oAiFile, System.Text.Encoding.Unicode, 1);

			string ReadStr, OutStr;
			string[] ReadSplitStr;

			ProgressBar.Value = 0;
			ProgressBar.Maximum = Conversions.ToInteger(inEFile.BaseStream.Length);
			var ItemDB = new string[30001, 4]; // 0- id, 1 - name, 2 - consume, 3 - type (for quest)
			int ItemDBMarker = 0;
			string CommentName;
			string CommentDescription;

			while (inEFile.EndOfStream != true)
			{
				ReadStr = inEFile.ReadLine();

				if (ReadStr != null)
				{
					if ((Strings.Mid(ReadStr, 1, 2) ?? "") != "//")
					{
						ReadSplitStr = ReadStr.Split((char)9);
						ItemDBMarker = Conversions.ToInteger(ReadSplitStr[1].Replace("id=", ""));
						if (ItemDBMarker >= 30000)
						{
							MessageBox.Show("Item ID must be less then 30000. Custom items not supported. Last item_id:" + ItemDBMarker.ToString(), "ItemID above them 30000", MessageBoxButtons.OK, MessageBoxIcon.Error);
							ProgressBar.Value = 0;
							inFile.Close();
							outAiData.Close();
							return;
						}
						ItemDB[ItemDBMarker, 0] = ReadSplitStr[2].Replace("name=", "");
						ItemDB[ItemDBMarker, 1] = ReadSplitStr[5].Replace("description=", "");
					}
				}
				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position * 100 / (double)inFile.BaseStream.Length);
			}

			ProgressBar.Maximum = Conversions.ToInteger(inFile.BaseStream.Length);
			ProgressBar.Value = 0;

			while (inFile.BaseStream.Position != inFile.BaseStream.Length)
			{
				ReadStr = Strings.Replace(inFile.ReadLine(), "\t", " ");


				// tabs and spaces correction
				while (Strings.InStr(ReadStr, "  ") != 0)
					ReadStr = Strings.Replace(ReadStr, "  ", " ");

				if (!String.IsNullOrWhiteSpace(ReadStr))
				{
					if ((Strings.Mid(Strings.Trim(ReadStr), 1, 2) ?? "") != "//")
					{
						ReadSplitStr = ReadStr.Split((char)32);
						if (Strings.InStr(ReadStr, "set_begin") == 0)
						{


							// Find Item in Itemname-e
							CommentName = ReadSplitStr[3];
							CommentDescription = "[no description]";

							ItemDBMarker = Conversions.ToInteger(ReadSplitStr[2]);
							if (ItemDBMarker <= 30000)
							{
								if (!string.IsNullOrEmpty(ItemDB[ItemDBMarker, 0]))
									CommentName = ItemDB[ItemDBMarker, 0];
								if (!string.IsNullOrEmpty(ItemDB[ItemDBMarker, 1]))
									CommentDescription = ItemDB[ItemDBMarker, 1];
							}
							else if (StopError.Checked == false)
							{
								CommentName = "[L2ScriptMaker: Customs skills not supported]";
								CommentDescription = "[L2ScriptMaker: Customs skills not supported]";
							}
							else
							{
								MessageBox.Show("Item ID must be less then 30000. Custom Items not supported. Last item_id:" + ItemDBMarker.ToString(), "ItemID above them 30000", MessageBoxButtons.OK, MessageBoxIcon.Error);
								ProgressBar.Value = 0;
								inFile.Close();
								outAiData.Close();
								return;
							}

							// 500 symbols fix
							if (CommentDescription.Length > 500)
								CommentDescription = CommentDescription.Substring(0, 500) + "]";

							OutStr = ReadSplitStr[2] + Conversions.ToString((char)9) + CommentName + Conversions.ToString((char)9) + CommentDescription + Conversions.ToString((char)9);

							if (Strings.InStr(ReadStr, "consume_type_normal") != 0)
								OutStr += "consume_type_normal" + Conversions.ToString((char)9);
							else if (Strings.InStr(ReadStr, "consume_type_stackable") != 0)
								OutStr += "consume_type_stackable" + Conversions.ToString((char)9);
							else if (Strings.InStr(ReadStr, "consume_type_asset") != 0)
								OutStr += "consume_type_asset" + Conversions.ToString((char)9);
							else
							{
								MessageBox.Show("Unknown consume_type. Please report me about it", "Unknown consume_type", MessageBoxButtons.OK, MessageBoxIcon.Error);
								inFile.Close();
								outAiData.Close();
								return;
							}

							if (Strings.InStr(ReadStr, "questitem") != 0)
								OutStr += "1";
							else
								OutStr += "0";

							outAiData.WriteLine(OutStr);
						}
					}
				}

				ProgressBar.Value = Conversions.ToInteger(inFile.BaseStream.Position * 100 / (double)inFile.BaseStream.Length);
			}

			MessageBox.Show("itemcache.txt Complete");
			ProgressBar.Value = 0;
			inFile.Close();
			outAiData.Close();
		}


		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
