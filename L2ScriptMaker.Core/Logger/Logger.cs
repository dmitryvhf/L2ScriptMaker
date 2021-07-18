using System;
using System.Linq;
using System.Text;
using L2ScriptMaker.Core.Settings;

namespace L2ScriptMaker.Core.Logger
{
	public class Logger : ILogger
	{
		private readonly string _logfilePath;

		/// <summary>
		/// Default contructor for common Logger
		/// </summary>
		public Logger() : this("common")
		{
		}

		/// <summary>
		/// Contructor for Logger
		/// </summary>
		/// <param name="serviceName">Name of logging service</param>
		public Logger(string serviceName)
		{
			_logfilePath = System.IO.Path.Combine(SettingsUtils.Settings.LogsFolder, serviceName + ".log");
		}

		/// <inheritdoc />
		public void Write(LogLevel level, string message)
		{
			Write(level, new string[] { message });
		}

		/// <inheritdoc />
		public void Write(LogLevel level, Exception ex)
		{
			string exMessage = ex.Message
			                   + (ex.InnerException == null ? String.Empty : $": " + ex.InnerException.Message);

			Write(level, new string[] { exMessage });
		}

		/// <inheritdoc />
		public void Write(LogLevel level, string[] messages)
		{
			if (messages.Length == 0)
			{
				return;
			}

			DateTime now = DateTime.Now;
			string prefix = $"{now:G}.{now:fff}\t[{level}]\t";

			int shift = prefix.Length;
			messages[0] = prefix + messages[0];
			for (int i = 1; i < messages.Length; i++)
			{
				messages[i] = new string(' ', shift) + '\t' + messages[i];
			}

			System.IO.File.AppendAllLines(_logfilePath, messages, Encoding.UTF8);
		}
	}
}
