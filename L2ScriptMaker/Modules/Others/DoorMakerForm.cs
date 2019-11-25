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
	public partial class DoorMakerForm : Form
	{
		public DoorMakerForm()
		{
			InitializeComponent();
		}



		// door_begin	[gludio_castle_inner_002]	type=normal_type	editor_id=19210006	open_method=by_npc	height=255	hp=126600	physical_defence=644	magical_defence=518	pos={-17981;110520;-2289}	range={{-18112;110514;-2547};{-17981;110514;-2547};{-17981;110526;-2547};{-18112;110526;-2547}}	door_end

		private void Form1_Load(object sender, EventArgs e)
		{
			TextBoxX.Text = "0";
			TextBoxY.Text = "0";
			TextBoxZ.Text = "0";
			TextBoxXS.Text = "0";
			TextBoxYS.Text = "0";
			TextBoxZS.Text = "0";
			Heights.Text = "0";
			HP.Text = "0";
			PDef.Text = "0";
			MDef.Text = "0";
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			int Pos;
			double TempX = default(double), TempY = default(double), TempZ;

			if (AutoClearBox.Checked == true)
				TextBoxFinal.Text = "";

			if (BestZBox.Checked == true)
				TempZ = Conversions.Val(TextBoxZ.Text);
			else
				TempZ = Conversions.Val(TextBoxZ.Text) + Conversions.Val(TextBoxZS.Text) * 3 / 4;


			// door_begin	[gludio_castle_outter_001]	type=normal_type	static_object_id=19210001	open_method=by_npc	
			TextBoxFinal.AppendText("door_begin" + Constants.vbTab + "[" + DoorName.Text + "]" + Constants.vbTab + "type=" + DoorType.Text + Constants.vbTab + "editor_id=" + StatObjID.Text + Constants.vbTab + "open_method=" + OpenMetod.Text);
			// height=300	hp=316500	physical_defence=644	magical_defence=518	door_end	
			TextBoxFinal.AppendText(Constants.vbTab + "height=" + Heights.Text + Constants.vbTab + "hp=" + HP.Text + Constants.vbTab + "physical_defence=" + PDef.Text + Constants.vbTab + "magical_defence=" + MDef.Text);

			// pos={-18450;113067;-2466}	range={{-18450;113061;-2789};{-18320;113061;-2789};{-18320;113073;-2789};{-18450;113073;-2789}}
			TextBoxFinal.AppendText(Constants.vbTab + "pos={" + TextBoxX.Text + ";" + TextBoxY.Text + ";" + Conversions.Fix(TempZ).ToString() + "}  range={");

			for (Pos = 1; Pos <= 4; Pos++)
			{
				if (Pos > 1)
					TextBoxFinal.AppendText(";");
				switch (Pos)
				{
					case 1:
						{
							TempX = Conversions.Val(TextBoxX.Text) - Conversions.Val(TextBoxXS.Text);
							TempY = Conversions.Val(TextBoxY.Text) - Conversions.Val(TextBoxYS.Text);
							break;
						}

					case 2:
						{
							TempX = Conversions.Val(TextBoxX.Text) + Conversions.Val(TextBoxXS.Text);
							TempY = Conversions.Val(TextBoxY.Text) - Conversions.Val(TextBoxYS.Text);
							break;
						}

					case 3:
						{
							TempX = Conversions.Val(TextBoxX.Text) + Conversions.Val(TextBoxXS.Text);
							TempY = Conversions.Val(TextBoxY.Text) + Conversions.Val(TextBoxYS.Text);
							break;
						}

					case 4:
						{
							TempX = Conversions.Val(TextBoxX.Text) - Conversions.Val(TextBoxXS.Text);
							TempY = Conversions.Val(TextBoxY.Text) + Conversions.Val(TextBoxYS.Text);
							break;
						}
				}
				TextBoxFinal.AppendText("{" + TempX.ToString() + ";" + TempY.ToString() + ";" + TextBoxZ.Text + "}");
			}
			TextBoxFinal.AppendText("}" + Constants.vbTab + "door_end" + Constants.vbNewLine);
		}

		private void ButtonClear_Click(object sender, EventArgs e)
		{
			TextBoxFinal.Text = "";
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			new HowToForm().ShowDialog();
		}

		private void KnowType_TextChanged(object sender, EventArgs e)
		{
			switch (KnowType.Text)
			{
				case "Aden Walls":
					{
						Heights.Text = "640";
						HP.Text = "678840";
						PDef.Text = "837";
						MDef.Text = "674";
						break;
					}

				case "Aden Outer Doors":
					{
						Heights.Text = "512";
						HP.Text = "339420";
						PDef.Text = "837";
						MDef.Text = "674";
						break;
					}

				case "Aden Inner Doors":
					{
						Heights.Text = "256";
						HP.Text = "158250";
						PDef.Text = "837";
						MDef.Text = "674";
						break;
					}

				case "Aden Castle Gates":
					{
						Heights.Text = "256";
						HP.Text = "158250";
						PDef.Text = "837";
						MDef.Text = "674";
						break;
					}

				case "Castle Walls":
					{
						Heights.Text = "500";
						HP.Text = "633000";
						PDef.Text = "644";
						MDef.Text = "518";
						break;
					}

				case "Castle Outer Doors":
					{
						Heights.Text = "300";
						HP.Text = "316500";
						PDef.Text = "644";
						MDef.Text = "518";
						break;
					}

				case "Castle Inner Doors":
					{
						Heights.Text = "256";
						HP.Text = "158250";
						PDef.Text = "644";
						MDef.Text = "518";
						break;
					}

				case "Castle Gate (Station)":
					{
						Heights.Text = "256";
						HP.Text = "158250";
						PDef.Text = "644";
						MDef.Text = "518";
						break;
					}

				case "Lattice":
					{
						Heights.Text = "128";
						HP.Text = "79125";
						PDef.Text = "644";
						MDef.Text = "518";
						break;
					}

				case "Kruma Door":
					{
						Heights.Text = "150";
						HP.Text = "150000";
						PDef.Text = "476";
						MDef.Text = "383";
						break;
					}

				case "Bandit Stronghold Door":
					{
						Heights.Text = "256";
						HP.Text = "158250";
						PDef.Text = "644";
						MDef.Text = "518";
						break;
					}

				case "City and Partisan Doors":
					{
						Heights.Text = "128";
						HP.Text = "79128";
						PDef.Text = "644";
						MDef.Text = "518";
						break;
					}
			}
		}
	}
}
