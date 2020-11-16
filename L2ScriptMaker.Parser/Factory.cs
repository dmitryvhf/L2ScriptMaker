using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using L2ScriptMaker.Models.Npc;
using L2ScriptMaker.Models.Skill;

[assembly: InternalsVisibleToAttribute("L2ScriptMaker.Parsers.Tests")]

namespace L2ScriptMaker.Parsers
{
	public class ParserService<T>
	{
		readonly IParserService<T> _parser;

		public ParserService()
		{
			if (typeof(T) == typeof(NpcData))
			{
				_parser = (IParserService<T>)new NpcDataParser();
			}
			else if (typeof(T) == typeof(NpcPch))
			{
				_parser = (IParserService<T>)new NpcPchParser();
			}
			else if (typeof(T) == typeof(SkillData))
			{
				_parser = (IParserService<T>)new SkillDataParser();
			}
			else
			{
				throw new NotSupportedException($"Not supported parser for type {typeof(T)}");
			}
		}

		public IEnumerable<T> Do(IEnumerable<string> data)
		{
			return _parser.Do(data);
		}
	}
}
