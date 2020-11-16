using System.Collections.Generic;

namespace L2ScriptMaker.Parsers.Core
{
	internal class ParsedData
	{
		//public string Raw { get; set; }
		public bool IsEmpty { get; set; }
		public IReadOnlyCollection<KeyValuePair<string, string>> Values { get; set; }
	}
}
