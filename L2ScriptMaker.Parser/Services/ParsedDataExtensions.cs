using System;
using System.Linq;

using L2ScriptMaker.Parsers.Models;

namespace L2ScriptMaker.Parsers.Services
{
	internal static class ParsedDataExtensions
	{
		//public static bool HasParam(this ParsedData data, string param) => data.Values.Any(a => a.Key == param);
		// public static bool IsValuePossible(this ParsedData data, string param) => data.Values[param] != null;

		public static string GetValue(this ParsedData data, int index)
		{
			if (data.IsEmpty) throw new NullReferenceException("Data empty. Use Read() before.");
			if (index - 1 < 0 || data.Values.Count < index - 1) throw new IndexOutOfRangeException();

			return data.Values.ElementAt(index - 1).Value;
		}

		public static T GetValue<T>(this ParsedData data, int index) where T : IConvertible
		{
			string result = data.GetValue(index);
			return (T)Convert.ChangeType(result, typeof(T));
		}

		public static string GetValue(this ParsedData data, string name)
		{
			if (data.IsEmpty) throw new NullReferenceException("Data empty. Use Read() before.");

			return data.Values.FirstOrDefault(a => a.Key == name).Value;
		}

		public static T GetValue<T>(this ParsedData data, string name) where T : IConvertible
		{
			string result = data.GetValue(name);
			return (T)Convert.ChangeType(result, typeof(T));
		}
	}
}
