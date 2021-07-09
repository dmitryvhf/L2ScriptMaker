using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L2ScriptMaker.Core;
using L2ScriptMaker.Models.Ai;
using L2ScriptMaker.Models.Common;
using L2ScriptMaker.Parsers.Core;

namespace L2ScriptMaker.Parsers
{
	public static class AiParserUtils
	{
		public static Maybe<AiClass> ParseClassHeader(string row)
		{
			// class 0 citizen : default_npc
			Maybe<ParsedLine> parsed = ParseService.ParseSimple(row);
			if (parsed.IsNothing)
			{
				return new Maybe<AiClass>();
			}

			AiClass result = new AiClass()
			{
				Type = Convert.ToInt16(parsed.GetValue().Values[1]),
				Name = parsed.GetValue().Values[2],
				BaseClass = parsed.GetValue().Values[4],
				Handlers = new List<AiHandler>(),
				Parameters = new List<AiClassParameter>()
			};

			if (parsed.GetValue().HasComment)
			{
				result.Name = parsed.GetValue().Comment;
			}

			return Maybe<AiClass>.Value(result);
		}

		public static Maybe<AiClassParameter> ParseClassParameter(string row)
		{
			// // int DesirePqSize 50
			Maybe<ParsedLine> test = ParseService.ParseSimple(row);
			if (test.IsNothing || test.GetValue().Values.Length < 3)
			{
				return new Maybe<AiClassParameter>();
			}

			ParsedLine parsed = test.GetValue();
			AiClassParameter result = new AiClassParameter()
			{
				Type = parsed.Values[0],
				Name = parsed.Values[1]
			};

			// exception: waypointdelaystype WayPointDelays
			if (parsed.Values.Length == 3)
			{
				result.Value = parsed.Values[2];
			}

			if (parsed.HasComment)
			{
				result.Name = parsed.Comment;
			}

			return Maybe<AiClassParameter>.Value(result);
		}

		public static Maybe<AiHandler> ParseHandlerHeader(string row)
		{
			// handler 4 13    //  TALK_SELECTED
			Maybe<ParsedLine> parsedLine = ParseService.ParseSimple(row);
			if (parsedLine.IsNothing)
			{
				return Maybe<AiHandler>.Nothing;
			}

			ParsedLine parsed = parsedLine.GetValue();
			AiHandler result = new AiHandler()
			{
				Type = Convert.ToInt16(parsed.Values[1]),
				Lines = Convert.ToInt32(parsed.Values[2]),
				Variables = new List<string>(),
				Code = new List<string>()
			};

			if (parsed.HasComment)
			{
				result.Name = parsed.Comment;
			}

			return Maybe<AiHandler>.Value(result);
		}

		public static Maybe<ParsedLine> ParseHandlerCode(string row)
		{
			return ParseService.ParseSimple(row);
		}
	}
}
