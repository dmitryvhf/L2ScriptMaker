using System.Collections.Generic;
using L2ScriptMaker.Models.Npc;

namespace L2ScriptMaker.Services.Npc
{
	public interface INpcDataService
	{
		IEnumerable<NpcData> Parse(IEnumerable<string> data);
	}
}