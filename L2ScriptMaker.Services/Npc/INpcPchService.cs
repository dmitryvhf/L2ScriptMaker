using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using L2ScriptMaker.Models.Npc;

namespace L2ScriptMaker.Services.Npc
{
	public interface INpcPchService
	{
		IEnumerable<NpcPch> Parse(IEnumerable<string> data);
		void Generate(string NpcDataDir, string NpcDataFile, IProgress<int> progress);
	}
}