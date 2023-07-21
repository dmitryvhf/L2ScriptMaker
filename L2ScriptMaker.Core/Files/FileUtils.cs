using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace L2ScriptMaker.Core.Files
{
	public static class FileUtils
	{
		private static readonly Func<string, bool> IsReadableData =
			([NotNull] s) => !String.IsNullOrWhiteSpace(s) && !s.StartsWith("//");

		/// <summary>
		/// Opening file for reading as enumerable records.
		/// </summary>
		public static IEnumerable<string> Read(string path)
		{
			return File.ReadLines(path)
				.Select(x => x.Trim())
				.Where(IsReadableData);
		}

		/// <summary>
		/// Sequential file reading. Tracking file position, uses for progress.
		/// </summary>
		public static IEnumerable<string> Read(string path, IProgress<int> progress)
		{
			using (StreamReader sr = new StreamReader(path))
			{
				long dataLenght = sr.BaseStream.Length;

				while (!sr.EndOfStream)
				{
					string current = sr.ReadLine()?.Trim();
					int currentProgress = (int)(sr.BaseStream.Position * 100 / dataLenght);
					progress.Report(currentProgress);

					if (IsReadableData(current))
						yield return current;
				}
			}

			progress.Report(100);
		}

		/// <summary>
		/// Create new file and write all text
		/// </summary>
		/// <param name="data">Text strings</param>
		/// <param name="targetPath">Output file path</param>
		/// <param name="encoding">File encoding</param>
		public static void Save(IEnumerable<string> data, string targetPath, Encoding encoding)
		{
			File.WriteAllLines(targetPath, data, encoding);
		}

		public static FileInfo GetInfo(string file)
		{
			return new FileInfo(file);
		}
	}
}