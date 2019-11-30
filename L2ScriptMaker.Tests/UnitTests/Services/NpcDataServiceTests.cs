using L2ScriptMaker.Models.Npc;
using L2ScriptMaker.Services.Npc;
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
			INpcDataService npcDataService = new NpcDataService();
			IEnumerable<string> rawData = GetNpcData();

			IEnumerable<NpcData> result = npcDataService.Parse(rawData).ToArray();

			Assert.True(result.Any());
		}

		private IEnumerable<string> GetNpcData()
		{
			// npc_begin       warrior 20001   [gremlin]       category={}     level=1 exp=0 
			IEnumerable<NpcData> npcDataArray = new NpcData[]
			{
				new NpcData{ Id = 20001, Name = "gremlin", Type = "warrior"},
				new NpcData{ Id = 20002, Name = "rabbit", Type = "warrior"},
				new NpcData{ Id = 20003, Name = "goblin", Type = "warrior"}
			};
			IEnumerable<string> data = npcDataArray.Select(NpcDataService.Print);

			return data;
		}
	}
}
