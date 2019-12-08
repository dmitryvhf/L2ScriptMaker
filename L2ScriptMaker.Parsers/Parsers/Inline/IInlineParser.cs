using System;

namespace L2ScriptMaker.Parsers.Parsers.Inline
{
	public interface IInlineParser<T>
	{
		/// <summary>
		/// Collect information about source data type.<br />
		/// Must call before parsing.<br />
		/// Method use lazy loading for reduce working with reflection
		/// <para>
		/// Source data type class must use InlineScriptAttribute for class.<br />
		/// Source data type class must use InlineScriptParamAttribute for map properties
		/// </para>
		/// </summary>
		/// <exception cref="ArgumentException">Class is not marked with InlineScriptAttribute</exception>
		void Initialize();

		/// <summary>
		/// Parse source data and map to target data object.<br />
		/// Use conversion to the destination type.
		/// </summary>
		/// <param name="raw">Raw string data from source data type file</param>
		/// <typeparam name="T"></typeparam>
		/// <returns>Target object with mapped properties</returns>
		/// <seealso cref="Convert.ChangeType(object,System.Type)"/>
		T Parse(string raw);
	}
}