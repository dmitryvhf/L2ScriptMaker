using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2ScriptMaker.Core.Logger
{
	public class Logger : ILogger
	{
		private readonly string _serviceName;
		private readonly string _logpath;

		private string LogfilePath => System.IO.Path.Combine(_logpath, "L2ScriptMaker.log");

		/// <summary>
		/// Contructor for Logger
		/// </summary>
		/// <param name="serviceName">Name of logging service</param>
		public Logger(string serviceName)
		{
			_serviceName = serviceName;
			_logpath = SettingsUtils.Settings.LogsFolder;
		}

		/// <inheritdoc />
		public void Write(LogLevel level, string message)
		{
			string prefix = $"{DateTime.Now:G}";

			string[] logStrings = new string[]
			{
				$"{prefix}\t[{level}]\t{_serviceName}",
				new string(' ', prefix.Length) + '\t' + message
			};

			System.IO.File.AppendAllLines(LogfilePath, logStrings, Encoding.UTF8);
		}
	}
}
