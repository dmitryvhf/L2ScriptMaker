using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using L2ScriptMaker.Services.Scripts.Geodata;

namespace L2ScriptMaker.Forms.Modules.Geodata
{
	public partial class GeoNumberConverter : Form
	{
		public GeoNumberConverter()
		{
			InitializeComponent();

			InitEvents();
		}

		private readonly Regex _positiionSymbols = new Regex("[0-9-\b]");
		private readonly Regex _positiion = new Regex("^-?[0-9]{1,6}$");

		private void InitEvents()
		{
			txbX.TextChanged += TxbXOnTextChanged;
			txbY.TextChanged += TxbYOnTextChanged;

			txbXMap.TextChanged += TxbXMapOnTextChanged;
			txbYMap.TextChanged += TxbXMapOnTextChanged;

			txbMap.Focus();
		}

		private void TxbXMapOnTextChanged(object sender, EventArgs e)
		{
			txbMap.Text = $"{txbXMap.Text}/{txbYMap.Text}";
		}

		private void TxbXOnTextChanged(object sender, EventArgs e)
		{
			TextBox tx = sender as TextBox;
			if (tx == null || string.IsNullOrWhiteSpace(tx.Text))
			{
				return;
			}

			if (!_positiion.IsMatch(tx.Text))
			{
				txbXMap.Text = string.Empty;
				return;
			}

			int xPosition = int.Parse(tx.Text);
			txbXMap.Text = GeodataService.GetXMapNumber(xPosition).ToString();
		}

		private void TxbYOnTextChanged(object sender, EventArgs e)
		{
			TextBox tx = sender as TextBox;
			if (tx == null || string.IsNullOrWhiteSpace(tx.Text))
			{
				return;
			}

			if (!_positiion.IsMatch(tx.Text))
			{
				txbYMap.Text = string.Empty;
				return;
			}

			int yPosition = int.Parse(tx.Text);
			txbYMap.Text = GeodataService.GetYMapNumber(yPosition).ToString();
		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txbImport.Text))
			{
				MessageBox.Show("Import position is empty. Insert position and try again", "Position empty",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string[] positions = txbImport.Text.Replace(";", ",").Split(',');
			if (positions.Length < 2)
			{
				MessageBox.Show("Required X and Y positions", "Position empty",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			txbX.Text = positions[0];
			txbY.Text = positions[1];

			txbImport.Text = string.Empty;
		}

		private void btnQuit_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
