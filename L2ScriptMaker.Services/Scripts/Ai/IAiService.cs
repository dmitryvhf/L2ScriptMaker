using System.Collections.Generic;

using L2ScriptMaker.DomainObjects.Models.Scripts.Ai;
using L2ScriptMaker.Services.Interfaces;

namespace L2ScriptMaker.Services.Scripts.Ai
{
	public interface IAiService : IProgressService // : IDataService<AiObj>, IProgressService
	{
		IEnumerable<AiClass> GetClassess(string dataFile);
	}
}