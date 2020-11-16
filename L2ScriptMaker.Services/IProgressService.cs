using System;

namespace L2ScriptMaker.Services
{
	public interface IProgressService
	{
		void WithProgress(IProgress<int> progress);
	}
}