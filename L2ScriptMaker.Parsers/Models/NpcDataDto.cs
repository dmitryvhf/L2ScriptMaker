using L2ScriptMaker.Parsers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace L2ScriptMaker.Parsers.Models
{
	[Script]
	public class NpcDataDto
	{
		[ScriptParam(1)]
		public string Type { get; set; }

		[ScriptParam(2)]
		public int Id { get; set; }

		[ScriptParam(3, TrimLR = true)]
		public string Name { get; set; }
	}
}
