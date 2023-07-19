using System;

using L2ScriptMaker.Core.Logger;
using L2ScriptMaker.Models.Ai;
using L2ScriptMaker.Models.Npc;
using L2ScriptMaker.Models.Skill;
using L2ScriptMaker.Parsers.NpcPch;

namespace L2ScriptMaker.Parsers
{
	public static class ParserFactory
	{
		public static IParserService<T> Get<T>() // where T: IScriptModel
		{
			ILogger logger = new Logger();

			Type modelType = typeof(T);
			if (modelType == typeof(AiClass))
			{
				return (IParserService<T>)new AiClassParser();
			}
			if (modelType == typeof(NpcData))
			{
				return (IParserService<T>)new NpcDataParser();
			}
			if (modelType == typeof(Models.Npc.NpcPch))
			{
				return (IParserService<T>)new NpcPchParser();
			}
			if (modelType == typeof(SkillData))
			{
				return (IParserService<T>)new SkillDataParser();
			}

			logger.Write(LogLevel.Critical, $"Not supported parser for type {modelType}");

			throw new NotSupportedException($"Not supported parser for type {modelType}");
		}
	}
}
