using System.Collections.Generic;
using System.Linq;

namespace L2ScriptMaker.Core.WinForms
{
	public class ListItem
	{
		public string Text { get; set; }
		public string Value { get; set; }
		public bool Selected { get; set; }
	}

	public static class WfControlUtils
	{
		public static IEnumerable<ListItem> Convert(IEnumerable<KeyValuePair<string, string>> data)
		{
			return data.Select(a => new ListItem
			{
				Text = a.Key,
				Value = a.Value
			});
		}
	}
}
