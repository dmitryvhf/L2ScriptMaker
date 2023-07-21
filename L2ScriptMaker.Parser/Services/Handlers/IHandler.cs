using L2ScriptMaker.Parsers.Models;

namespace L2ScriptMaker.Parsers.Services.Handlers
{
	/// <summary>
	///		Интерфейс Обработчика объявляет метод построения цепочки обработчиков.
	///		Он также объявляет метод для выполнения запроса.
	/// </summary>
	public interface IHandler
	{
		IHandler Next(IHandler handler);

		void Handle(ParserRequest request, ParserResponse response, ParserOptions options);
	}

	internal abstract class AbstractParseHandler : IHandler
	{
		private IHandler? _nextHandler;

		public IHandler Next(IHandler handler)
		{
			_nextHandler = handler;
			return _nextHandler;
		}

		public virtual void Handle(ParserRequest request, ParserResponse response, ParserOptions options)
		{
			_nextHandler?.Handle(request, response, options);
		}
	}
}
