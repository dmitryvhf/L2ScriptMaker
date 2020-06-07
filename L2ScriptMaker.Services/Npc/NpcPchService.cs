using L2ScriptMaker.Core.Files;
using L2ScriptMaker.Models.Npc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using L2ScriptMaker.Models.Dto;
using L2ScriptMaker.Core.Parser;
using L2ScriptMaker.Core.Mapper;
using L2ScriptMaker.Core;
using L2ScriptMaker.Core.WinForms;

namespace L2ScriptMaker.Services.Npc
{
	public class NpcPchService : INpcPchService
	{
		private readonly NpcDataService _npcDataService = new NpcDataService();
		private readonly IMapper<NpcDataDto, NpcPch> _modelMapper = new NpcPchMapper();

		#region WinForms service
		public List<ListItem> GetListItems(string fileName)
		{
			var data = FileUtils.Read(fileName);
			return Parse(data).Select(a => new ListItem { Text = a.Name, Value = a.Id }).ToList();

			//var test = npcPchService.Parse(data)
			//	.GroupBy(a => a.Name)
			//	.Where(a => a.Count() > 1)
			//	.ToList();
		}

		public ServiceResult Generate(string NpcDataDir, string NpcDataFile, IProgress<int> progress)
		{
			string inNpcdataFile = Path.Combine(NpcDataDir, NpcDataFile);
			string outPchFile = Path.Combine(NpcDataDir, NpcContants.NpcPchFileName);
			string outPch2File = Path.Combine(NpcDataDir, NpcContants.NpcPch2FileName);

			IEnumerable<string> rawNpcData = FileUtils.Read(inNpcdataFile);
			IEnumerable<string> collectedData = _npcDataService.Collect(rawNpcData);
			List<NpcDataDto> npcData = _npcDataService.Parse(collectedData).ToList();

			using (StreamWriter sw = new StreamWriter(outPchFile, false, Encoding.Unicode))
			{
				for (var index = 0; index < npcData.Count; index++)
				{
					NpcDataDto npcDataDto = npcData[index];
					sw.WriteLine(Print(_modelMapper.Map(npcDataDto)));
					progress.Report((int) (index * 100 / npcData.Count));
				}
			}

			File.Create(outPch2File).Close();

			return new ServiceResult { HasErrors = false };
		}
		#endregion

		#region IParserService implementation
		public NpcPchDto Parse(string record)
		{
			KeyValuePair<string, string> data = ParseKeyValueService.Parse(record);
			NpcPchDto npcDataDto = new NpcPchDto() {Id = data.Value, Name = StringUtils.CutBrackets(data.Key) };
			return npcDataDto;
		}

		public IEnumerable<NpcPchDto> Parse(IEnumerable<string> data)
		{
			IEnumerable<NpcPchDto> result = data.Select(Parse);
			return result;
		}

		#endregion


		#region Private methods
		// [gremlin]       =       1020001
		private static string Print(NpcPch model)
		{
			return $"[{model.Name}] = {model.Id}";
		}
		#endregion
	}
}
