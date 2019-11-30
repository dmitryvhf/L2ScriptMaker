namespace L2ScriptMaker.Parsers.Parsers.Inline
{
	public interface IInlineParser
	{
		void Initialize();
		TOut Parse<TOut>(string raw);
	}
}