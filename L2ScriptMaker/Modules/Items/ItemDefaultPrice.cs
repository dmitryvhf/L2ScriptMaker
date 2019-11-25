using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using L2ScriptMaker.Extensions.VbCompatibleHelper;

namespace L2ScriptMaker.Modules.Items
{
	public partial class ItemDefaultPrice : Form
	{
		public ItemDefaultPrice()
		{
			InitializeComponent();
		}

		private void DefaultPrice_Load(object sender, EventArgs e)
		{
			TownTax.Text = "0";
			CastleTax.Text = "0";
			ShopPrice.Text = "0";
			DefaultItemPrice.Text = "0";
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ShopPrice_Leave(object sender, EventArgs e)
		{
			DefaultItemPrice.Text = Conversions.ToInteger(Conversions.Val(ShopPrice.Text) * (double)100 / ((double)100 + Conversions.Val(TownTax.Text) + Conversions.Val(CastleTax.Text))).ToString();  // =(A5*100)/(100+$H$4+$I$4)
		}

		private void DefaultItemPrice_Leave(object sender, EventArgs e)
		{
			ShopPrice.Text = Conversions.ToInteger(Conversions.Val(DefaultItemPrice.Text) + Conversions.Val(DefaultItemPrice.Text) / (double)100 * Conversions.Val(TownTax.Text) + Conversions.Val(DefaultItemPrice.Text) / (double)100 * Conversions.Val(CastleTax.Text)).ToString(); // =B5+B5/100*$H$4+B5/100*$I$4
		}

		private void TownTax_Leave(object sender, EventArgs e)
		{
			DefaultItemPrice.Text = Conversions.ToInteger(Conversions.Val(ShopPrice.Text) * (double)100 / ((double)100 + Conversions.Val(TownTax.Text) + Conversions.Val(CastleTax.Text))).ToString();  // =(A5*100)/(100+$H$4+$I$4)
		}

		private void CastleTax_Leave(object sender, EventArgs e)
		{
			DefaultItemPrice.Text = Conversions.ToInteger(Conversions.Val(ShopPrice.Text) * (double)100 / ((double)100 + Conversions.Val(TownTax.Text) + Conversions.Val(CastleTax.Text))).ToString();  // =(A5*100)/(100+$H$4+$I$4)
		}
	}
}
