using System;

namespace L2ScriptMaker.Services
{
	public interface IProgressService
	{
		void With(IProgress<int> progress);
	}
}