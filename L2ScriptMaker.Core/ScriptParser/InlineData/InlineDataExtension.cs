using System;
using System.Linq;

namespace L2ScriptMaker.Core.ScriptParser.InlineData
{
	public static class InlineDataExtension
	{
		public static bool HasParam(this InlineData data, string param) => data.Values.ContainsKey(param);
		public static bool IsValuePossible(this InlineData data, string param) => data.Values[param] != null;

		public static T GetParam<T>(this InlineData data, int index) where T : IConvertible
		{
			if (data.IsEmpty) throw new NullReferenceException("Data empty. Use Parse() before.");
			if (data.Values.Count < index) throw new IndexOutOfRangeException();

			string result = data.Values.ElementAt(index).Key;

			return (T)Convert.ChangeType(result, typeof(T));
		}

		public static T GetValue<T>(this InlineData data, string name) where T : IConvertible
		{
			if (data.IsEmpty) throw new NullReferenceException("Data empty. Use Parse() before.");

			data.Values.TryGetValue(name, out string result);
			
			return (T)Convert.ChangeType(result, typeof(T));
		}

		/*
		 * 	Span<string> sss = new Span<string>(data.Split('\t'));
			sss.IndexOf("sds");

			// Create a pattern for a word that starts with letter "M"  
			string pattern = $@"\t?{param}(=?.*)?\t?";
			// Create a Regex  
			Regex rg = new Regex(pattern);
			var res = rg.Matches(data);
			var res2 = rg.Match(data);
		 */
	}
}
