using L2ScriptMaker.Models.Npc;
using L2ScriptMaker.Services.Parsers.Npc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using L2ScriptMaker.Core.ScriptParser;
using L2ScriptMaker.Core.ScriptParser.InlineData;
using L2ScriptMaker.Services.Parsers;

namespace L2ScriptMaker.Services.Npc
{
	public static class NpcDataService
	{
		private static readonly IFactory<InlineData, NpcData> Factory = new NpcDataFactory();
		private static readonly IScriptReader<InlineData> InlineReader = new InlineDataReader();

		public static IEnumerable<InlineData> Load(IEnumerable<string> data)
		{
			var result = data.Select(InlineReader.Read).Where(a => !a.IsEmpty);
			return result;
		}

		public static IEnumerable<NpcData> Parse(IEnumerable<InlineData> data)
		{
			IEnumerable<NpcData> result = data.Select(Factory.Build);
			return result;
		}
	}
}
