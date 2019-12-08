using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("L2ScriptMaker.Tests")]
namespace L2ScriptMaker.Parsers.Parsers.Inline
{
	internal class InlineDataReader : IScriptReader<InlineData>
	{
		private char Splitter { get; } = '\t';
		public bool SkipComment { get; } = true;

		public InlineData Read(string raw)
		{
			if (String.IsNullOrWhiteSpace(raw))
			{
				return new InlineData { IsEmpty = true };
			}

			if (raw.StartsWith("//") && SkipComment)
			{
				return new InlineData { IsEmpty = true };
			}

			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			int indexLeft = 0, indexRight = 0;
			bool canRead = true;

			indexRight = raw.IndexOf(Splitter);
			if (indexRight > -1)
			{
				string headerColumn = raw.Substring(indexLeft, indexRight);
				KeyValuePair<string, string> sss = GetPair(headerColumn);
				list.Add(sss);
			}
			else
				canRead = false;

			while (canRead)
			{
				indexLeft = raw.IndexOf(Splitter, indexRight);
				if (indexLeft == -1) break;

				indexRight = raw.IndexOf(Splitter, ++indexLeft);
				if (indexRight == -1)
				{
					indexRight = raw.Length;
					canRead = false;
				}
				if (indexLeft == indexRight) break;

				string candidateColumn = raw.Substring(indexLeft, indexRight - indexLeft);
				KeyValuePair<string, string> keyvalue = GetPair(candidateColumn);
				list.Add(keyvalue);
			}

			return new InlineData
			{
				Values = list.ToDictionary(a => a.Key, s => s.Value)
			};
		}

		private KeyValuePair<string, string> GetPair(string value)
		{
			string[] parts = value.Split('=');

			string leftPart = parts[0].Trim();
			string rightPart = null;

			if (parts.Length > 1) rightPart = value.Remove(0, leftPart.Length + 1).TrimStart(new char[] { ' ', '=' }).Trim();

			return new KeyValuePair<string, string>(leftPart, rightPart);
		}
	}
}
