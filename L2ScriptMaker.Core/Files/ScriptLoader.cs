using System;
using System.Collections.Generic;

namespace L2ScriptMaker.Core.Files
{
	public static class ScriptLoader
	{
		public static IEnumerable<string> Collect(IEnumerable<string> lines, string startPrefix, string endPrefix)
		{
			IEnumerator<string> enumerator = lines.GetEnumerator();
			string completeRecord = String.Empty;

			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
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
