using System;
using System.Collections.Generic;
using System.Linq;

using L2ScriptMaker.Core.Files;
using L2ScriptMaker.DomainObjects.Constants;
using L2ScriptMaker.DomainObjects.Contracts.Models;
using L2ScriptMaker.DomainObjects.Models.Scripts;
using L2ScriptMaker.Parsers.Services;

namespace L2ScriptMaker.Services.Scripts.Npc
{
	public class NpcDataService : INpcDataService
	{
		private readonly ParserCore<NpcData> _parser = new ParserCore<NpcData>(Chronicles.C0);

		#region IProgressService implementation

		private IProgress<int>? _progress;
		public void With(IProgress<int> progress) => _progress = progress;
		public void Unbind() => _progress = null;

		#endregion

		#region IDataService implementation

		public IEnumerable<NpcData> Get(string dataFile)
		{
			IEnumerable<string> rawData;
			if (_progress == null)
			{
				rawData = FileUtils.Read(dataFile);
			}
			else
			{
				rawData = FileUtils.Read(dataFile, _progress);
			}

			return Parse(rawData).ToArray();
		}

		private IEnumerable<NpcData> Parse(IEnumerable<string> lines)
		{
			IEnumerable<string> npcDataRows =
				ParseService.Collect(lines, NpcConstants.StartPrefix, NpcConstants.EndPrefix);
			foreach (string npcDataRow in npcDataRows)
			{
				yield return _parser.Parse(npcDataRow);
			}
		}

		#endregion

		// npc_begin       warrior 20001   [gremlin]       category={}     level=1 exp=0 
		public static string Print(NpcData model)
		{
			throw new NotImplementedException();
			//return $"npc_begin" +
			//       $"\t{model.Type}" +
			//       $"\t{model.Id}" +
			//       $"\t[{model.Name}]";
		}
	}
}