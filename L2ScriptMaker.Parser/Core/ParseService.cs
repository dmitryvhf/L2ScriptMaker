using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using L2ScriptMaker.Core;
using L2ScriptMaker.Models.Common;

namespace L2ScriptMaker.Parsers.Core
{
	internal static class ParseService
	{
		private static readonly char[] SplitChars = new char[] { '\t', '\n' };

		/// <summary>
		/// Collect one, from multiple, line record with start and end prefixies.
		/// If prefixies empty, line return as-is.
		/// </summary>
		internal static IEnumerable<string> Collect(IEnumerable<string> lines, string startPrefix, string endPrefix)
		{
			IEnumerator<string> enumerator = lines.GetEnumerator();
			string completeRecord = String.Empty;

			bool withoutPrefixes = String.IsNullOrWhiteSpace(startPrefix) || String.IsNullOrWhiteSpace(endPrefix);

			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				if (withoutPrefixes)
				{
					yield return current;
					continue;
				}

				if (String.IsNullOrWhiteSpace(current))
				{
					continue;
				}

				if (String.IsNullOrWhiteSpace(completeRecord))
				{
					if (!current.StartsWith(startPrefix)) continue;
				}
				else
				{
					completeRecord += "\n";
				}

				completeRecord += current;
				if (completeRecord.EndsWith(endPrefix))
				{
					yield return completeRecord;
					completeRecord = String.Empty;
				}
			}

			enumerator.Dispose();
		}

		/// <summary>
		/// Split line record to param-value or value-only blocks.
		/// Splitted with knowns symbols: tab or endline.
		/// ParamValue defined with symbol '=' inside.
		/// </summary>
		internal static ParsedData ToKeyValueCollection(string raw)
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

			string[] splited = refinedRaw.Split(SplitChars, StringSplitOptions.RemoveEmptyEntries);
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

		/// <summary>
		/// Split line record to param-value or value-only blocks.
		/// Splitted with knowns symbols: tab or endline.
		/// ParamValue defined with symbol '=' inside.
		/// </summary>
		internal static KeyValuePair<string, string> ToKeyValue(string raw) => GetPair(raw);

		private static KeyValuePair<string, string> GetPair(string value)
		{
			Regex regex = new Regex("\\s*=\\s*");
			string refinedRaw = regex.Replace(value, "=");

			string[] parts = refinedRaw.Split('=');

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

		/// <summary>
		/// Parser of simple line.
		/// Detecting empty or commented line.
		/// Spliting data by blocks.
		/// </summary>
		/// <param name="row"></param>
		/// <returns></returns>
		public static Maybe<ParsedLine> ParseSimple(string row)
		{
			if (String.IsNullOrWhiteSpace(row) || row.StartsWith("//"))
			{
				return Maybe<ParsedLine>.Nothing;
			}

			ParsedLine result = new ParsedLine();
			string cleanedRaw = row.Trim();

			int commentIndex = cleanedRaw.IndexOf("//", StringComparison.Ordinal);
			if (commentIndex != -1)
			{
				// extract commentary
				result.Comment = cleanedRaw.Remove(0, commentIndex + 2).Trim();
				cleanedRaw = cleanedRaw.Remove(commentIndex);
			}

			result.Values = cleanedRaw
				.Split(Constants.SpaceSplitChars, StringSplitOptions.RemoveEmptyEntries);

			return Maybe<ParsedLine>.Value(result);
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

