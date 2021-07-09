namespace L2ScriptMaker.Core.Logger
{
	/// <summary>
	/// Simple logger service
	/// </summary>
	/// <remarks>Use logging path from application settings</remarks>
	public interface ILogger
	{
		/// <summary>
		/// Write log record
		/// </summary>
		/// <param name="level">Attention record for logging message</param>
		/// <param name="message">Logging message</param>
		void Write(LogLevel level, string message);

		/// <summary>
		/// Write log record
		/// </summary>
		/// <param name="level">Attention record for logging message</param>
		/// <param name="messages">Logging messages</param>
		void Write(LogLevel level, string[] messages);
	}
}