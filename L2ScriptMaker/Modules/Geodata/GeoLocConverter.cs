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

namespace L2ScriptMaker.Modules.Geodata
{
	public partial class GeoLocConverter : Form
	{
		public GeoLocConverter()
		{
			InitializeComponent();
		}


		// $geo_x=20+($game_x-$game_x%32768)/32768; 
		// $geo_y=18+($game_y-$game_y%32768)/32768;

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void XTextBox_TextChanged(object sender, EventArgs e)
		{
			try
			{
				GeonameXTextBox.Text = Conversions.ToString(Conversions.Fix((double)20 + (double)(Conversions.ToInteger(XTextBox.Text) - Conversions.ToInteger(XTextBox.Text) / 32768) / (double)32768));
			}
			catch (Exception ex)
			{
				if (string.IsNullOrEmpty(XTextBox.Text))
					XTextBox.Text = "0";
				else
					GeonameXTextBox.Text = "!";
			}
		}

		private void YTextBox_TextChanged(object sender, EventArgs e)
		{
			try
			{
				GeonameYTextBox.Text = Conversions.ToString(Conversions.Fix((double)18 + (double)(Conversions.ToInteger(YTextBox.Text) - Conversions.ToInteger(YTextBox.Text) / 32768) / (double)32768));
			}
			catch (Exception ex)
			{
				if (string.IsNullOrEmpty(YTextBox.Text))
					YTextBox.Text = "0";
				else
					GeonameYTextBox.Text = "!";
			}
		}

		private void GeonameXTextBox_TextChanged(object sender, EventArgs e)
		{
			GeonameTextBox.Text = GeonameXTextBox.Text + "/" + GeonameYTextBox.Text;
		}

		private void ImportLocButton_Click(object sender, EventArgs e)
		{
			var Locs = new string[3];

			if (string.IsNullOrEmpty(ImportLocTextBox.Text))
				goto WrongType;

			ImportLocTextBox.Text = ImportLocTextBox.Text.Replace(";", ",");
			try
			{
				Locs = ImportLocTextBox.Text.Split(Conversions.ToChar(","));
				if (Locs.Length < 2)
					goto WrongType;
				XTextBox.Text = Locs[0];
				YTextBox.Text = Locs[1];
			}
			catch (Exception ex)
			{
				goto WrongType;
			}

			return;

			WrongType:
			;
			MessageBox.Show("Enter data is not valid. Enter data in format \"XXXX,YYYY,ZZZZ\"", "Invalid data", MessageBoxButtons.OK);
			return;
		}
	}
}
