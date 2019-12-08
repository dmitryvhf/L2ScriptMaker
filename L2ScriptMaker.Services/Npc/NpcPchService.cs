using L2ScriptMaker.Core.Files;
using L2ScriptMaker.Models.Npc;
using L2ScriptMaker.Parsers.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace L2ScriptMaker.Services.Npc
{
	public class NpcPchService : INpcPchService
	{
		private readonly NpcDataService _npcDataService = new NpcDataService();

		#region WinForms service
		public ServiceResult Generate(string NpcDataDir, string NpcDataFile, IProgress<int> progress)
		{
			string inNpcdataFile = Path.Combine(NpcDataDir, NpcDataFile);
			string outPchFile = Path.Combine(NpcDataDir, NpcContants.NpcPchFileName);
			string outPch2File = Path.Combine(NpcDataDir, NpcContants.NpcPch2FileName);

			IEnumerable<string> rawNpcData = FileUtils.Read(inNpcdataFile);
			List<NpcDataDto> npcData = _npcDataService.Parse(rawNpcData).ToList();

			using (StreamWriter sw = new StreamWriter(outPchFile, false, Encoding.Unicode))
			{
				for (var index = 0; index < npcData.Count; index++)
				{
					NpcDataDto npcDataDto = npcData[index];
					sw.WriteLine(Print(Map(npcDataDto)));
					progress.Report((int) (index * 100 / npcData.Count));
				}
			}

			File.Create(outPch2File).Close();

			return new ServiceResult { HasErrors = false };
		}
		#endregion

		#region Private methods
		private static NpcPch Map(NpcDataDto data)
		{
			return new NpcPch
			{
				Name = data.Name,
				Id = NpcContants.NpcPchPrefix + data.Id
			};
		}

		// [gremlin]       =       1020001
		private static string Print(NpcPch model)
		{
			return $"[{model.Name}] = {model.Id}";
		}
		#endregion
	}
}
