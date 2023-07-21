﻿using System;
using System.Collections.Generic;

namespace L2ScriptMaker.DomainObjects.Models.Scripts.Ai
{
	public class AiHandler
	{
		public short Type { get; set; }
		public int Lines { get; set; }
		public string Name { get; set; }

		public bool HasName => !String.IsNullOrWhiteSpace(Name);

		public List<string> Variables { get; set; }

		public List<string> Code { get; set; }
	}
}
