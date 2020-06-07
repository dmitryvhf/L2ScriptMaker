using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace L2ScriptMaker.Core.Parser
{
	public static class ParseKeyValueService
	{
		//private static readonly char[] SplitChars = new char[] { '\t', '\n' };

		/// <summary>
		/// Split line record to param-value or value-only blocks.
		/// Splitted with knowns symbols: tab or endline.
		/// ParamValue defined with symbol '=' inside.
		/// </summary>
		public static KeyValuePair<string, string> Parse(string raw)
		{
			//ParsedData result = new ParsedData { IsEmpty = true }; //, Raw = raw};

			//if (String.IsNullOrWhiteSpace(raw))
			//{
			//	return null;
			//}

			//if (raw.StartsWith("//"))
			//{
			//	return null;
			//}

			Regex regex = new Regex("\\s*=\\s*");
			string refinedRaw = regex.Replace(raw, "=");

			KeyValuePair<string, string> keyvalue = GetPair(refinedRaw);

			//result.Values = new ReadOnlyCollection<KeyValuePair<string, string>>(keyvalue);
			//result.IsEmpty = false;

			return keyvalue;
		}

		private static KeyValuePair<string, string> GetPair(string value)
		{
			string[] parts = value.Split('=');

			string leftPart = null;
			string rightPart;

			if (parts.Length > 1)
			{
				leftPart = parts[0].Trim();
				rightPart = value.Remove(0, leftPart.Length + 1).TrimStart(new char[] { ' ', '=' }).Trim();
			}
			else
			{
				rightPart = parts[0].Trim();
			}

			return new KeyValuePair<string, string>(leftPart, rightPart);
		}
	}
}

