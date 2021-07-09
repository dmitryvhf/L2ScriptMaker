using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2ScriptMaker.Models.Ai
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
