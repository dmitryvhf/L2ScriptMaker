﻿using System;
using System.Collections.Generic;

using L2ScriptMaker.Core.Files;
using L2ScriptMaker.Models.Npc;
using L2ScriptMaker.Parsers;

namespace L2ScriptMaker.Services.Npc
{
	public class NpcDataService : INpcDataService
	{
		private readonly IParserService<NpcData> _parser = ParserFactory.Get<NpcData>();

		#region IProgressService implementation
		private IProgress<int> _progress;
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
			return _parser.Do(rawData);
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
