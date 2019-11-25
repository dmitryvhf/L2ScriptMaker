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
	public partial class ToolIncrementer : Form
	{
		public ToolIncrementer()
		{
			InitializeComponent();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			ResultTextBox.Text = "";
			double StartLevel;
			double EndLevel;
			double Increment;
			double Variable;

			try
			{
				StartLevel = Conversions.ToDouble(StartLevelTextBox.Text);
				EndLevel = Conversions.ToDouble(EndLevelTextBox.Text);
				if (Use1RadioButton.Checked == true)
					Increment = Conversions.ToDouble(IncValueTextBox.Text);
				else
					Increment = Conversions.ToDouble(MultValueTextBox.Text);
				Variable = Conversions.ToDouble(StartValueTextBox.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			string ParamName = ParamNameTextBox.Text;
			string LeftSym = LeftTextBox.Text;
			string RightSym = RightTextBox.Text;

			double iTemp;
			var loopTo = EndLevel;
			for (iTemp = StartLevel; iTemp <= loopTo; iTemp++)
			{
				ResultTextBox.AppendText(ParamName);
				if (ParamAddNameCheckBox.Checked == true)
					ResultTextBox.AppendText(Conversions.ToString(iTemp));
				ResultTextBox.AppendText(" = " + LeftSym);
				ResultTextBox.AppendText(Variable.ToString() + RightSym + Constants.vbNewLine);
				if (Use1RadioButton.Checked == true)
					Variable = Variable + Increment;
				else
				{
					if (Variable < 0)
						Increment = -Increment;
					else if (Increment < 0)
						Increment = Increment;
					Variable = Variable + Variable * Increment;
				}
			}

			TabControl1.SelectedIndex = 1;
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}


		private void Use2RadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (Use2RadioButton.Checked == false)
			{
				IncValueTextBox.ReadOnly = false;
				MultValueTextBox.ReadOnly = true;
			}
			else
			{
				IncValueTextBox.ReadOnly = true;
				MultValueTextBox.ReadOnly = false;
			}
		}
	}
}
