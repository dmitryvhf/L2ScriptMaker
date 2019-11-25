using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using L2ScriptMaker.Extensions.VbCompatibleHelper;

namespace L2ScriptMaker
{
	public partial class AboutBox : Form
	{
		public AboutBox()
		{
			InitializeComponent();
		}

		private void AboutBox_Load(object sender, EventArgs e)
		{
			// Set the title of the form.
			this.Text = string.Format("About {0}", MyAssemblyInfo.Title);
			this.LabelProductName.Text = MyAssemblyInfo.Product;
			this.LabelVersion.Text = string.Format("Version {0}", MyAssemblyInfo.Version);
			this.LabelCopyright.Text = MyAssemblyInfo.Copyright;
			this.LabelCompanyName.Text = MyAssemblyInfo.Company;
			this.TextBoxDescription.Text = MyAssemblyInfo.Description;
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}