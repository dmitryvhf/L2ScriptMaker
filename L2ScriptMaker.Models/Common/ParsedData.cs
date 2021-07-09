using System.Collections.Generic;

namespace L2ScriptMaker.Models.Common
{
	public class ParsedData
	{
		//public string Raw { get; set; }
		public bool IsEmpty { get; set; }
		public IReadOnlyCollection<KeyValuePair<string, string>> Values { get; set; }
	}
}
