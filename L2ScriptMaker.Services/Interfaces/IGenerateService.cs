using System;

namespace L2ScriptMaker.Services.Interfaces
{
	/// <summary>
	///		Command service for generate server script file
	/// </summary>
	public interface IGenerateService
	{
		/// <summary>
		///		Generate script file
		/// </summary>
		/// <param name="dataDir">Script file folder</param>
		/// <param name="dataFile">Script file name</param>
		/// <returns>Generation result model</returns>
		CommandResult Generate(string dataDir, string dataFile);
	}
}
