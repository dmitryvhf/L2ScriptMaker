using System;
using System.Collections.Generic;
using System.Text;
using L2ScriptMaker.Core.ScriptParser.InlineData;
using L2ScriptMaker.Models.Npc;

namespace L2ScriptMaker.Services.Parsers.Npc
{
	public class NpcDataFactory : IFactory<InlineData, NpcData>
	{
		// npc_begin       warrior 20001   [gremlin]       category={}     level=1 exp=0 
		public NpcData Build(InlineData data)
		{
			return new NpcData
			{
				Id = data.GetParam<int>(2),
				Type = data.GetParam<string>(1),
				Name = data.GetParam<string>(3).TrimStart('[').TrimEnd(']')
			};
		}

		// npc_begin       warrior 20001   [gremlin]       category={}     level=1 exp=0 
		public string Print(NpcData model)
		{
			return $"npc_begin" +
				   $"\t{model.Type}" +
				   $"\t{model.Id}" +
				   $"\t[{model.Name}]";
		}
	}
}

//public NpcData Parse(string input)
//{
//	var data = new InlineData(input);
//	if (data.IsEmpty) return null;

//	data.Parse();

//	return new NpcData
//	{
//		Id = data.GetParam<int>(2),
//		Type = data.GetParam<string>(1),
//		Name = data.GetParam<string>(3).TrimStart('[').TrimEnd(']')
//	};
//}