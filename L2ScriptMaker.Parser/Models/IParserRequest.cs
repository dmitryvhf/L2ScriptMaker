using System;
using System.Collections.Generic;
using System.Reflection;

namespace L2ScriptMaker.Parsers.Models
{
	public interface IParserRequest
	{
		/// <summary>
		///     Обрабатываемое свойство модели
		/// </summary>
		public PropertyInfo Property { get; }

		/// <summary>
		///		Transmission value
		/// </summary>
		public object? Value { get; }

		/// <summary>
		///     Начальные данные 
		/// </summary>
		// public string[] SplittedString { get; }
		public ParsedData SplittedString { get; }
	}

	public class ParserRequest : IParserRequest
	{
		/// <inheritdoc />
		public PropertyInfo Property { get; }

		/// <inheritdoc />
		// public string[] SplittedString { get; }
		public ParsedData SplittedString { get; set; }

		/// <inheritdoc />
		public object? Value { get; private set; }

		public ParserRequest(PropertyInfo property, ParsedData splittedString)
		{
			Property = property;
			SplittedString = splittedString;
		}

		/// <summary>
		///		Update value
		/// </summary>
		/// <param name="value"></param>
		public void SetValue(object value)
		{
			Value = value;
		}
	}
}
