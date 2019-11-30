using System;
using System.Collections.Generic;
using System.Linq;

namespace L2ScriptMaker.Parsers.Parsers.Inline
{
	class InlineData : IScript
	{
		public bool IsEmpty { get; set; }

		public IReadOnlyDictionary<string, string> Values { get; set; } = new Dictionary<string, string>();
	}
}