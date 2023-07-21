using System;
using System.Collections.Generic;
using System.Reflection;

namespace L2ScriptMaker.Parsers.Models
{
	/// <summary>
	///     Настройки обработки данных
	/// </summary>
	public class ParserOptions
	{
		/// <summary>
		///     Коллекция свойств модели с атрибутами
		/// </summary>
		public readonly Dictionary<PropertyInfo, Attribute[]> PropCache;

		public ParserOptions(Dictionary<PropertyInfo, Attribute[]> propCache)
		{
			PropCache = propCache;
		}
	}
}
