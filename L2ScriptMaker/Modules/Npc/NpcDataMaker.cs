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
	public partial class NpcDataMaker : Form
	{
		public NpcDataMaker()
		{
			InitializeComponent();
		}

		private void NpcDataMaker_Load(object sender, EventArgs e)
		{
			DataGridView1.Rows.Add(1, 1, 1, 1, 1, 1, 1);
		}

		private void ButtonGenerate_Click(object sender, EventArgs e)
		{
			int iTemp = 0;
			string sTemp = "";

			double iTempVal;

			FinalTextBox.Text = CommonStatTextBox.Text + Constants.vbNewLine;
			var loopTo = DataGridView1.ColumnCount - 1;
			for (iTemp = 0; iTemp <= loopTo; iTemp++)
			{
				iTempVal = Convert.ToDouble(DataGridView1[iTemp, 0].Value);

				switch (NpcTypeComboBox.Text)
				{
					case "warrior":
						{
							switch (DataGridView1.Columns[iTemp].Name)
							{
								case "org_hp":
									{
										iTempVal = Conversions.ToInteger(iTempVal / 1.58);
										break;
									}

								case "org_mp":
									{
										iTempVal = Conversions.ToInteger(iTempVal / 1.1);
										break;
									}

								case "base_physical_attack":
									{
										iTempVal = Conversions.ToDouble((iTempVal / 1.91).ToString(".##"));
										break;
									}

								case "base_attack_speed":
									{
										iTempVal = Conversions.ToDouble((iTempVal / 1.095).ToString(".##"));
										break;
									}

								case "base_magic_attack":
									{
										iTempVal = Conversions.ToDouble((iTempVal / 1.66).ToString(".##"));
										break;
									}

								case "base_defend":
									{
										iTempVal = Conversions.ToDouble((iTempVal / 1.58).ToString(".##"));
										break;
									}

								case "base_magic_defend":
									{
										iTempVal = Conversions.ToDouble((iTempVal / 1.76).ToString(".##"));
										break;
									}
							}

							break;
						}

					case "boss":
						{
							switch (DataGridView1.Columns[iTemp].Name)
							{
								case "org_hp":
									{
										iTempVal = Conversions.ToInteger(iTempVal / 2.38);
										break;
									}

								case "org_mp":
									{
										iTempVal = Conversions.ToInteger(iTempVal / 2.21);
										break;
									}

								case "base_physical_attack":
									{
										iTempVal = Conversions.ToDouble((iTempVal / 3.935).ToString(".##"));
										break;
									}

								case "base_attack_speed":
									{
										iTempVal = Conversions.ToDouble((iTempVal / 1.62).ToString(".##"));
										break;
									}

								case "base_magic_attack":
									{
										iTempVal = Conversions.ToDouble((iTempVal / 15.37).ToString(".##"));
										break;
									}

								case "base_defend":
									{
										iTempVal = Conversions.ToDouble((iTempVal / 1.62).ToString(".##"));
										break;
									}

								case "base_magic_defend":
									{
										iTempVal = Conversions.ToDouble((iTempVal / 3.6).ToString(".##"));
										break;
									}
							}

							break;
						}
				}

				sTemp = DataGridView1.Columns[iTemp].Name + "=" + Conversions.ToString(iTempVal) + Constants.vbTab;

				FinalTextBox.AppendText(sTemp);
			}

			TabControl1.SelectedIndex = 1;
		}

		private void ButtonClear_Click(object sender, EventArgs e)
		{
			FinalTextBox.Text = "";
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void NpcTypeComboBox_TextChanged(object sender, EventArgs e)
		{
			switch (NpcTypeComboBox.SelectedIndex)
			{
				case 0:
					{
						CommonStatTextBox.Text = "str=40	int=21	dex=30	wit=20	con=43	men=10";
						break;
					}

				case 1:
					{
						CommonStatTextBox.Text = "str=60	int=76	dex=73	wit=70	con=57	men=80";
						break;
					}
			}
		}
	}
}
