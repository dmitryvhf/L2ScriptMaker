using System;
using System.Collections.Generic;

namespace L2ScriptMaker.Services
{
	public interface IDataService<out T>
	{
		IEnumerable<T> Get(string dataFile);
	}
}