using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace L2ScriptMaker.Core.Thread
{
	public static class WinFormsExtensions
	{
		public static void Invoker(this Form form, Action action)
		{
			if (form.InvokeRequired)
			{
				form.Invoke(new MethodInvoker(delegate () {
					action();
				}));
			}
			else
			{
				action();
			}
		}
	}
}
