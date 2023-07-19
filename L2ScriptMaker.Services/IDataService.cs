using System;
using System.Collections.Generic;

namespace L2ScriptMaker.Services
{
	/// <summary>
	///		Service can load script data of type <typeparamref name="T"/> and parse to object models collection
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IDataService<out T>
	{
		/// <summary>
		///		Load and parse script
		/// </summary>
		/// <param name="dataFile">Server script file</param>
		/// <returns>Object models collection</returns>
		IEnumerable<T> Get(string dataFile);
	}
}