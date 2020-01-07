using System;
using System.Collections.Generic;
using System.Text;

namespace L2ScriptMaker.Services
{
	public class ServiceResult
	{
		public bool HasErrors { get; set; }
		public List<string> Errors { get; set; }
	}
}
