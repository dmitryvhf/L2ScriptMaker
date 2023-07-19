using System.Collections.Generic;

namespace L2ScriptMaker.Parsers
{
	/// <summary>
	///		Service can do parse input script to object model
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IParserService<out T>
	{
		/// <summary>
		///		Parse script to object
		/// </summary>
		/// <param name="data">Server script rows</param>
		/// <returns>Object models collection</returns>
		IEnumerable<T> Do(IEnumerable<string> data);
	}
}