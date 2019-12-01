using L2ScriptMaker.Models.Npc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using L2ScriptMaker.Core.Files;
using L2ScriptMaker.Parsers.Parsers.Inline;
using L2ScriptMaker.Parsers.Models;
using System.IO;

namespace L2ScriptMaker.Services.Npc
{
	public class NpcPchService : INpcPchService
	{
		private const int NpcPchPrefix = 1_000_000;
		private static readonly IInlineParser InlineParser = new InlineParser<NpcDataDto>();

		public NpcPchService()
		{
			InlineParser.Initialize();
		}

		public NpcPch Parse(string data)
		{
			return InlineParser.Parse<NpcPch>(data);
		}

		public IEnumerable<NpcPch> Parse(IEnumerable<string> data)
		{
			IEnumerable<NpcPch> result = data.Select(Parse);
			return result;
		}

		#region WinForms services
		public async void Generate(string NpcDataDir, string NpcDataFile, IProgress<int> progress)
		{
			string inNpcdataFile = Path.Combine(NpcDataDir, NpcDataFile);
			string outPchFile = Path.Combine(NpcDataDir, NpcContants.NpcPchFileName);
			string outPch2File = Path.Combine(NpcDataDir, NpcContants.NpcPch2FileName);

			IEnumerable<string> rawNpcData = FileUtils.Read(inNpcdataFile, progress);

			using (StreamWriter sw = new StreamWriter(outPchFile, false, Encoding.Unicode))
			{
				foreach (string s in rawNpcData)
				{
					NpcPch parsed = InlineParser.Parse<NpcPch>(s);
					sw.WriteLine(Print(parsed));
				}
			}

			File.Create(outPch2File);

		}
		#endregion

		// [gremlin]       =       1020001
		static string Print(NpcPch model)
		{
			return $"[{model.Name}] = {NpcPchPrefix + model.Id}";
		}
	}
}
