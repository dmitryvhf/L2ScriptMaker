using System;
using System.Collections.Generic;
using System.Text;

namespace L2ScriptMaker.Services
{
	public interface IGenerateService
	{
		void Generate(string DataDir, string DataFile, IProgress<int> progress);
	}
}
