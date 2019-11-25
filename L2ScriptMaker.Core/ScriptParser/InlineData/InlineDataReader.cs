using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L2ScriptMaker.Core.ScriptParser.InlineData
{
	public class InlineDataReader : IScriptReader<InlineData>
	{
		private char Splitter { get; } = '\t';
		public bool SkipComment { get; } = true;

		public InlineData Read(string raw)
		{
			InlineData data = Parse(raw);
			return data;
		}

		private InlineData Parse(string raw)
		{
			InlineData data = new InlineData();

			if (String.IsNullOrWhiteSpace(raw))
			{
				data.IsEmpty = true;
				return data;
			}

			if (raw.StartsWith("//") && SkipComment)
			{
				data.IsEmpty = true;
				return data;
			}

			data.Values = raw.Trim()
				.Replace(" = ", "=")
				.Replace(' ', Splitter)
				.Split(Splitter)
				.Select(a =>
				{
					(string, string) s = (null, null);
					string[] splitData = a.Split('=');
					s.Item1 = splitData[0];
					if (splitData.Length > 1) s.Item2 = a.Remove(0, s.Item1.Length + 1);
					return s;
				})
				.ToDictionary(a => a.Item1, s => s.Item2);

			// data.IsParsed = true;

			return data;
		}
	}
}
