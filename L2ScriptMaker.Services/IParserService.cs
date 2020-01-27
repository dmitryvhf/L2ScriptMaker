using System.Collections.Generic;

namespace L2ScriptMaker.Services
{
	public interface IParserService<T>
	{
		IEnumerable<T> Parse(IEnumerable<string> data);
	}
}