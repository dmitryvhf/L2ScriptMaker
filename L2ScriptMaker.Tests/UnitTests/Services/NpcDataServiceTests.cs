using L2ScriptMaker.Models.Npc;
using L2ScriptMaker.Services.Npc;
using L2ScriptMaker.Services.Parsers.Npc;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace L2ScriptMaker.Tests.UnitTests.Services
{
	public class NpcDataServiceTests
	{
		[Fact]
		public void ParseData()
		{
			IEnumerable<string> rawData = GetNpcData();

			var data1 = NpcDataService.Load(rawData);
			var data2 = NpcDataService.Parse(data1).ToArray();

			Assert.True(data2.Length > 0);
		}

		private IEnumerable<string> GetNpcData()
		{
			NpcDataFactory npcDataParser = new NpcDataFactory();

			// npc_begin       warrior 20001   [gremlin]       category={}     level=1 exp=0 
			IEnumerable<NpcData> npcDataArray = new NpcData[]
			{
				new NpcData{ Id = 20001, Name = "gremlin", Type = "warrior"},
				new NpcData{ Id = 20002, Name = "rabbit", Type = "warrior"},
				new NpcData{ Id = 20003, Name = "goblin", Type = "warrior"}
			};
			IEnumerable<string> data = npcDataArray.Select(npcDataParser.Print);

			return data;
		}
	}
}
