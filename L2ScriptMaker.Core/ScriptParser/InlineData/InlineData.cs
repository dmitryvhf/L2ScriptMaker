using System;
using System.Collections.Generic;
using System.Linq;

namespace L2ScriptMaker.Core.ScriptParser.InlineData
{
	public class InlineData : IScript
	{
		// private char Splitter { get; } = '\t';
		//public bool SkipComment { get; } = true;
		public bool IsEmpty { get; set; }
		//public string Raw { get; set; }

		// public bool IsParsed { get; set; }
		public IReadOnlyDictionary<string, string> Values { get; set; } = new Dictionary<string, string>();

		//public InlineData(string raw)
		//{
		//	if (String.IsNullOrWhiteSpace(raw))
		//	{
		//		IsEmpty = true;
		//		return;
		//	}

		//	//if (SkipComment)
		//	//{
		//	//	if (raw.StartsWith("//"))
		//	//	{
		//	//		IsEmpty = true;
		//	//		return;
		//	//	}
		//	//}

		//	Raw = raw;
		//}

		//public void Parse()
		//{
		//	if (IsEmpty || IsParsed) return;

		//	if (SkipComment)
		//	{
		//		if (raw.StartsWith("//"))
		//		{
		//			IsEmpty = true;
		//			return;
		//		}
		//	}

		//	Values = Raw.Trim()
		//		.Replace(' ', Splitter)
		//		.Split(Splitter)
		//		.Select(a =>
		//		{
		//			(string, string) s = (null, null);
		//			string[] data = a.Split('=');
		//			s.Item1 = data[0];
		//			if (data.Length > 1) s.Item2 = data[1];
		//			return s;
		//		})
		//		.ToDictionary(a => a.Item1, s => s.Item2);

		//	IsParsed = true;
		//}
	}
}