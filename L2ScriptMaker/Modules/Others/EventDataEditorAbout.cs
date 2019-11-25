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
	public partial class EventDataEditorAbout : Form
	{
		public EventDataEditorAbout()
		{
			InitializeComponent();
		}

		private void ButtonQuit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
