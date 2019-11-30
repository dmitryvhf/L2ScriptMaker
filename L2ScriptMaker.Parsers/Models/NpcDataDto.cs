using L2ScriptMaker.Parsers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace L2ScriptMaker.Parsers.Models
{
	[InlineScript]
	public class NpcDataDto
	{
		[InlineScriptParam(1)]
		public string Type { get; set; }

		[InlineScriptParam(2)]
		public string Id { get; set; }

		[InlineScriptParam(3, TrimLR = true)]
		public string Name { get; set; }
	}
}
