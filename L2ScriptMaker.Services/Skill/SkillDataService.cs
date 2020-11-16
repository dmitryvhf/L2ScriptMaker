using System;
using System.Collections.Generic;
using L2ScriptMaker.Core.Files;
using L2ScriptMaker.Parsers;
using L2ScriptMaker.Models.Skill;

namespace L2ScriptMaker.Services.Skill
{
	public class SkillDataService : ISkillDataService
	{
		private readonly ParserService<SkillData> _parser = new ParserService<SkillData>();

		#region IDataService implementation

		public IEnumerable<SkillData> Get(string dataFile)
		{
			IEnumerable<string> rawData = FileUtils.Read(dataFile);
			return _parser.Do(rawData);
		}

		public IEnumerable<SkillData> Get(string dataFile, IProgress<int> progress)
		{
			IEnumerable<string> rawData = FileUtils.Read(dataFile, progress);
			return _parser.Do(rawData);
		}
		#endregion
	}
}
