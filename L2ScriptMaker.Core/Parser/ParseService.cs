using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace L2ScriptMaker.Core.Parser
{
	public static class ParseService
	{
		private static readonly char[] SplitChars = new char[] { '\t', '\n' };

		public static ParsedData Parse(string raw)
		{
			ParsedData result = new ParsedData { IsEmpty = true }; //, Raw = raw};

			if (String.IsNullOrWhiteSpace(raw))
			{
				return result;
			}

			if (raw.StartsWith("//"))
			{
				return result;
			}

			Regex regex = new Regex("\\s*=\\s*");
			string refinedRaw = regex.Replace(raw, "=");

			var splited = refinedRaw.Split(SplitChars, StringSplitOptions.RemoveEmptyEntries);
			if (splited.Length == 0) return result;

			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			for (var index = 0; index < splited.Length; index++)
			{
				string current = splited[index];
				KeyValuePair<string, string> keyvalue;

				if (index > 0 && current.EndsWith("_begin"))
				{
					string collectSubData = current;
					while (!current.EndsWith("_end"))
					{
						index++;
						current = splited[index];

						if (!String.IsNullOrWhiteSpace(collectSubData)) collectSubData += '\t';
						collectSubData += current;
					}
					keyvalue = new KeyValuePair<string, string>(null, collectSubData);
				}
				else
				{
					keyvalue = GetPair(current);
				}
				list.Add(keyvalue);
			}

			result.Values = new ReadOnlyCollection<KeyValuePair<string, string>>(list);
			result.IsEmpty = false;

			return result;
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

		//public InlineData Read(string raw)
		//{
		//	if (String.IsNullOrWhiteSpace(raw))
		//	{
		//		return new InlineData { IsEmpty = true };
		//	}

		//	if (raw.StartsWith("//") && SkipComment)
		//	{
		//		return new InlineData { IsEmpty = true };
		//	}

		//	List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
		//	int indexLeft = 0, indexRight = 0;
		//	bool canRead = true;

		//	indexRight = raw.IndexOf(Splitter);
		//	if (indexRight > -1)
		//	{
		//		string headerColumn = raw.Substring(indexLeft, indexRight);
		//		KeyValuePair<string, string> sss = GetPair(headerColumn);
		//		list.Add(sss);
		//	}
		//	else
		//		canRead = false;

		//	while (canRead)
		//	{
		//		indexLeft = raw.IndexOf(Splitter, indexRight);
		//		if (indexLeft == -1) break;

		//		indexRight = raw.IndexOf(Splitter, ++indexLeft);
		//		if (indexRight == -1)
		//		{
		//			indexRight = raw.Length;
		//			canRead = false;
		//		}
		//		if (indexLeft == indexRight) break;

		//		string candidateColumn = raw.Substring(indexLeft, indexRight - indexLeft);
		//		KeyValuePair<string, string> keyvalue = GetPair(candidateColumn);
		//		list.Add(keyvalue);
		//	}

		//	return new InlineData
		//	{
		//		Values = list.ToDictionary(a => a.Key, s => s.Value)
		//	};
		//}
	}
}

