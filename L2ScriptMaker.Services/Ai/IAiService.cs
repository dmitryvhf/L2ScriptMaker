using System.Collections.Generic;
using L2ScriptMaker.Models.Ai;
using L2ScriptMaker.Models.Npc;

namespace L2ScriptMaker.Services.Ai
{
	public interface IAiService : IProgressService // : IDataService<AiObj>, IProgressService
	{
		IEnumerable<AiClass> GetClassess(string dataFile);
	}
}