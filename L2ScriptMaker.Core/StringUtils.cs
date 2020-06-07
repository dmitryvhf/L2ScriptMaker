using System;
using System.Collections.Generic;
using System.Text;

namespace L2ScriptMaker.Core
{
	public static class StringUtils
	{
		public static string CutBrackets(string value)
		{
			return value.Substring(1, value.Length - 2);
		}
	}
}
