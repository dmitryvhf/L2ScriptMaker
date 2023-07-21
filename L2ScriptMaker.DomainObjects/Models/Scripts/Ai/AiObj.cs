using System;
using System.Collections.Generic;

namespace L2ScriptMaker.DomainObjects.Models.Scripts.Ai
{
	public class AiObj
	{
		public List<string> Header { get; set; }
		public List<AiClass> Classes { get; set; }
	}
}
