using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2ScriptMaker
{
	public partial class Eula : Form
	{
		public Eula()
		{
			InitializeComponent();
		}

		private void Accept2Button_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void DeclineButton_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void Eula_Load(object sender, EventArgs e)
		{
			TextBox1.Select(0, 0);
		}
	}
}
