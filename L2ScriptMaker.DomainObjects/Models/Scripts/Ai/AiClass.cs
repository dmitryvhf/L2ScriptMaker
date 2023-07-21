using System;
using System.Collections.Generic;

namespace L2ScriptMaker.DomainObjects.Models.Scripts.Ai
{
	public class AiClass
	{
		public string Name { get; set; }
		public short Type { get; set; }
		public string BaseClass { get; set; }   // todo change type -> AiClass

		public List<AiClassParameter> Parameters { get; set; }

		public List<AiHandler> Handlers { get; set; }
	}
}
