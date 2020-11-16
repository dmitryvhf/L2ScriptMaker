using System;

namespace L2ScriptMaker.Parsers.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	public class RecordAttribute : Attribute
	{
		public bool HasBrackets { get; set; }
		public string StartBracket { get; set; }
		public string EndBracket { get; set; }
	}
}
