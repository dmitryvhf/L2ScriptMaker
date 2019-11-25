using L2ScriptMaker.Models.Npc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using L2ScriptMaker.Core.ScriptParser.InlineData;

namespace L2ScriptMaker.Services.Parsers.Npc
{
	public class NpcPchFactory : IFactory<InlineData, NpcPch>
	{
		private const int NpcPchPrefix = 1_000_000;

		// npc_begin       warrior 20001   [gremlin]       category={}     level=1 exp=0 
		public NpcPch Build(InlineData data)
		{
			return new NpcPch
			{
				Id = data.GetParam<int>(2),
				Name = data.GetParam<string>(3).TrimStart('[').TrimEnd(']')
			};
		}

		// [gremlin]       =       1020001
		public string Print(NpcPch model)
		{
			return $"[{model.Name}] = {NpcPchPrefix + model.Id}";
		}
	}
}
