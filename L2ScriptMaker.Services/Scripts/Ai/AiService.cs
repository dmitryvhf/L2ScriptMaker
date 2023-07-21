using System;
using System.Collections.Generic;
using System.Linq;

using L2ScriptMaker.Core;
using L2ScriptMaker.Core.Files;
using L2ScriptMaker.DomainObjects.Constants;
using L2ScriptMaker.DomainObjects.Models.Scripts.Ai;

namespace L2ScriptMaker.Services.Scripts.Ai
{
	public class AiService : IAiService
	{
		#region IProgressService implementation

		private IProgress<int>? _progress;
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

			return Parse(rawData).ToArray();
		}

		private IEnumerable<AiClass> Parse(IEnumerable<string> rawData)
		{
			bool onClassParametersReading = false;
			bool onClassHandlerReading = false;
			bool onClassHandlerVariablesReading = false;

			AiHandler currentHandler = null;
			AiClass currentClass = null;

			foreach (string raw in rawData)
			{
				if (raw.StartsWith(AiConstants.ClassStartPrefix))
				{
					var parsed = AiParserUtils.ParseClassHeader(raw);
					if (parsed.IsNothing)
					{
						continue;
					}

					currentClass = parsed.GetValue();
				}
				if (raw.StartsWith(AiConstants.ClassEndPrefix))
				{
					yield return currentClass;

					currentClass = null;
				}

				if (raw.StartsWith("parameter_define_begin"))
				{
					onClassParametersReading = true;
					continue;
				}

				if (raw.StartsWith("parameter_define_end"))
				{
					onClassParametersReading = false;
					continue;
				}

				if (raw.StartsWith("handler "))
				{
					Maybe<AiHandler> handler = AiParserUtils.ParseHandlerHeader(raw);
					if (handler.IsNothing)
					{
						continue;
					}

					currentHandler = handler.GetValue();
					currentClass.Handlers.Add(currentHandler);

					onClassHandlerReading = true;
					continue;
				}
				if (raw.StartsWith("handler_end"))
				{
					onClassHandlerReading = false;
					continue;
				}

				if (raw.StartsWith("variable_begin"))
				{
					onClassHandlerVariablesReading = true;
					continue;
				}

				if (raw.StartsWith("variable_end"))
				{
					onClassHandlerVariablesReading = false;
					continue;
				}

				if (onClassHandlerVariablesReading)
				{
					currentHandler.Variables.Add(raw);
				}
				else if (onClassHandlerReading)
				{
					currentHandler.Code.Add(raw);
				}
				else if (onClassParametersReading)
				{
					currentClass.Parameters.Add(AiParserUtils.ParseClassParameter(raw).GetValue());
				}
			}
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
