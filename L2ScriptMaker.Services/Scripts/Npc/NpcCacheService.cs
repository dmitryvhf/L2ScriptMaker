using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using L2ScriptMaker.DomainObjects.Constants;
using L2ScriptMaker.DomainObjects.Models.Scripts;

namespace L2ScriptMaker.Services.Scripts.Npc
{
	public class NpcCacheService : INpcCacheService
	{
		private readonly INpcDataService _npcDataService = new NpcDataService();

		#region IProgressService implementation
		private IProgress<int> _progress;
		public void With(IProgress<int> progress) => _progress = progress;
		public void Unbind() => _progress = null;
		#endregion

		#region WinForms service
		public CommandResult Generate(string dataDir, string dataFile)
		{
			string inNpcdataFile = Path.Combine(dataDir, dataFile);
			string outPchFile = Path.Combine(dataDir, NpcConstants.NpcCacheFileName);

			_npcDataService.With(_progress);
			List<NpcData> npcDatas = _npcDataService.Get(inNpcdataFile).ToList();

			using (StreamWriter sw = new StreamWriter(outPchFile, false, Encoding.Unicode))
			{
				for (var index = 0; index < npcDatas.Count; index++)
				{
					NpcData npcData = npcDatas[index];
					sw.WriteLine(Print(Map(npcData)));
					_progress.Report(index * 100 / npcDatas.Count);
				}
			}

			return CommandResult.Success();
		}
		#endregion

		#region Private methods
		private static NpcCache Map(NpcData data)
		{
			return new NpcCache
			{
				Name = data.Name,
				Id = data.Id
			};
		}

		// 1        Gremlin
		static string Print(NpcCache model)
		{
			string formattedId = model.Id.ToString().PadRight(5);
			return $"{formattedId}\t{model.Name}";
		}

		#endregion
	}
}
