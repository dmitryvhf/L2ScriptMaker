using System;
using System.Windows.Forms;

namespace L2ScriptMaker.Core.WinForms
{
	public static class ThreadExtensions
	{
		public static void Invoker(this Form form, Action action)
		{
			if (form.InvokeRequired)
			{
				form.Invoke(action);
			}
			else
			{
				action();
			}
		}

		public static void Invoker(this Control control, Action action)
		{
			if (control.InvokeRequired)
			{
				control.Invoke(action);
			}
			else
			{
				action();
			}
		}

		public static void InvokerAsync(this Control control, Action action)
		{
			if (control.InvokeRequired)
			{
				control.BeginInvoke(action);
			}
			else
			{
				action();
			}
		}
	}
}
