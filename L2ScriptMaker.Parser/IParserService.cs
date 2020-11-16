using System.Collections.Generic;

namespace L2ScriptMaker.Parsers
{
	internal interface IParserService<out T>
	{
		IEnumerable<T> Do(IEnumerable<string> data);
	}
}