using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L2ScriptMaker.Core.Files;
using L2ScriptMaker.Models.Ai;
using L2ScriptMaker.Parsers;

namespace L2ScriptMaker.Services.Ai
{
	public class AiService : IAiService
	{
		private readonly ParserService<AiClass> _parser = new ParserService<AiClass>();

		#region IProgressService implementation
		private IProgress<int> _progress;
		public void With(IProgress<int> progress) => _progress = progress;
		public void Unbind() => _progress = null;
		#endregion

		#region IDataService implementation

		public IEnumerable<AiClass> GetClassess(string dataFile)
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

		//// npc_begin       warrior 20001   [gremlin]       category={}     level=1 exp=0 
		//public static string Print(AiObj model)
		//{
		//	throw new NotImplementedException();
		//	//return $"npc_begin" +
		//	//       $"\t{model.Type}" +
		//	//       $"\t{model.Id}" +
		//	//       $"\t[{model.Name}]";
		//}
	}
}
