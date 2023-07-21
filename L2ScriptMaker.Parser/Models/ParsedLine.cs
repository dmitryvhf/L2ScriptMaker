﻿using System;

namespace L2ScriptMaker.Parsers.Models
{
	/// <summary>
	/// Data line - splitted data by blocks (values).
	/// Detecting commentary
	/// </summary>
	public class ParsedLine
	{
		public string[] Values { get; set; }
		public string Comment { get; set; }

		public bool IsEmpty => Values.Length == 0;
		public bool HasComment => !string.IsNullOrWhiteSpace(Comment);
	}
}
