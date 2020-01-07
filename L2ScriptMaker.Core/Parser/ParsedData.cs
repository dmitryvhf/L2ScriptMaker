using System.Collections.Generic;

namespace L2ScriptMaker.Core.Parser
{
	public class ParsedData
	{
		//public string Raw { get; set; }
		public bool IsEmpty { get; set; }
		public IReadOnlyCollection<KeyValuePair<string, string>> Values { get; set; }
	}
}
