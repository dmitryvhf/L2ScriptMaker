using System;
using System.Windows.Forms;

using L2ScriptMaker.Forms.Services;

namespace L2ScriptMaker.Forms.Modules
{
	public partial class AboutBoxForm : Form
	{
		public AboutBoxForm()
		{
			InitializeComponent();
		}

		private void AboutBox_Load(object sender, EventArgs e)
		{
			this.Text = $"About {AssemblyInfoUtil.Title}";
			this.LabelProductName.Text = AssemblyInfoUtil.Product;
			this.LabelVersion.Text = $"Version {AssemblyInfoUtil.Version}";
			this.LabelCopyright.Text = AssemblyInfoUtil.Copyright;
			this.LabelCompanyName.Text = AssemblyInfoUtil.Company;
			this.TextBoxDescription.Text = AssemblyInfoUtil.Description;
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}