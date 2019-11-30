namespace L2ScriptMaker.Parsers
{
	internal interface IScriptReader<T> where T : IScript
	{
		T Read(string raw);
	}
}
