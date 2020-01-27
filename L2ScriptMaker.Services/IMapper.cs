using System.Collections.Generic;

namespace L2ScriptMaker.Services
{
	public interface IMapper<in TIn, out TOut>
	{
		TOut Map(TIn data);
	}
}