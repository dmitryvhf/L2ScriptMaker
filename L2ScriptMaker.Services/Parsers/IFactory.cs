using System;
using System.Collections.Generic;
using System.Text;
using L2ScriptMaker.Core.ScriptParser;

namespace L2ScriptMaker.Services.Parsers
{
	public interface IFactory<TIn, TOut> 
		where TIn: IScript
	{
		TOut Build(TIn data);
		string Print(TOut model);
	}
}
