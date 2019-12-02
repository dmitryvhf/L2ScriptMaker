using L2ScriptMaker.Models.CachedScript;
using System;

namespace L2ScriptMaker.Services.CachedScript
{
	public interface INpcCacheService : IParserService<NpcCache>
	{
		void Generate(string npcDataDir, string npcDataFile, IProgress<int> progress);
	}
}