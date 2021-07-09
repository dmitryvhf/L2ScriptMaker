using System;

namespace L2ScriptMaker.Services
{
	public interface IProgressService
	{
		/// <summary>
		/// Use progress bar statistic
		/// </summary>
		/// <param name="progress"></param>
		void With(IProgress<int> progress);
		
		/// <summary>
		/// Stop use statistic
		/// </summary>
		/// <remarks>Must be use manualy after operation completed</remarks>
		void Unbind();
	}
}