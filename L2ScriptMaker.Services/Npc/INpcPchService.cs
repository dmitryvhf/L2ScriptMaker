using System.Collections.Generic;
using L2ScriptMaker.Models.Npc;

namespace L2ScriptMaker.Services.Npc
{
	public interface INpcPchService
	{
		IEnumerable<NpcPch> Parse(IEnumerable<string> data);
		void Generate(string NpcDataFile, string NpcDataDir);
	}
}