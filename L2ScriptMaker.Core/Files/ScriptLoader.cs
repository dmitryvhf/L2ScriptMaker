using System;
using System.Collections.Generic;

namespace L2ScriptMaker.Core.Files
{
	public static class ScriptLoader
	{
		/// <summary>
		/// Collect one, from multiple, line record with start and end prefixies.
		/// If prefixies empty, line return as-is.
		/// </summary>
		public static IEnumerable<string> Collect(IEnumerable<string> lines, string startPrefix, string endPrefix)
		{
			IEnumerator<string> enumerator = lines.GetEnumerator();
			string completeRecord = String.Empty;

			bool withoutPrefixes = !String.IsNullOrWhiteSpace(startPrefix) || !String.IsNullOrWhiteSpace(endPrefix);

			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				if(withoutPrefixes) yield return current;

				if (String.IsNullOrWhiteSpace(current))
				{
					continue;
				}

				if (String.IsNullOrWhiteSpace(completeRecord))
				{
					if(!current.StartsWith(startPrefix)) continue;
				}
				else
				{
					completeRecord += "\n";
				}

				completeRecord += current;
				if (completeRecord.EndsWith(endPrefix))
				{
					yield return completeRecord;
					completeRecord = String.Empty;
				}
			}

			enumerator.Dispose();
		}
	}
}
