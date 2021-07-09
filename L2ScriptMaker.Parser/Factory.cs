using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using L2ScriptMaker.Core.Logger;
using L2ScriptMaker.Models.Ai;
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

			ILogger logger = new Logger();

			if (typeof(T) == typeof(AiClass))
			{
				_parser = (IParserService<T>)new AiClassParser();
			}
			else if (typeof(T) == typeof(NpcData))
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
				logger.Write(LogLevel.Critical, $"Not supported parser for type {typeof(T)}");
				throw new NotSupportedException($"Not supported parser for type {typeof(T)}");
			}
		}

		public IEnumerable<T> Do(IEnumerable<string> data)
		{
			return _parser.Do(data);
		}
	}
}
