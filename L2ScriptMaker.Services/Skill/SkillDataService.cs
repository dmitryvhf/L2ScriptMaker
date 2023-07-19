﻿using System;
using System.Collections.Generic;
using L2ScriptMaker.Core.Files;
using L2ScriptMaker.Parsers;
using L2ScriptMaker.Models.Skill;

namespace L2ScriptMaker.Services.Skill
{
	public class SkillDataService : ISkillDataService
	{
		private readonly IParserService<SkillData> _parser = ParserFactory.Get<SkillData>();

		#region IProgressService implementation
		private IProgress<int> _progress;
		public void With(IProgress<int> progress) => _progress = progress;
		public void Unbind() => _progress = null;

		#endregion

		#region IDataService implementation
		public IEnumerable<SkillData> Get(string dataFile)
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
	}
}
