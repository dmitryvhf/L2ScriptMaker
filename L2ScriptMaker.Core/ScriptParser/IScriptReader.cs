using System;
using System.Collections.Generic;
using System.Text;

namespace L2ScriptMaker.Core.ScriptParser
{
	public interface IScriptReader<T> where T : IScript
	{
		T Read(string raw);
	}
}
