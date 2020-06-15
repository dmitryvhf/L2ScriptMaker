using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2ScriptMaker.Core.Files
{
	public static class FileUtils
	{
		private static readonly Func<string, bool> DataExists =
			(s) => !String.IsNullOrWhiteSpace(s) && !s.StartsWith("//");

		/// <summary>
		/// Opening file for reading as enumerable records.
		/// </summary>
		public static IEnumerable<string> Read(string path)
		{
			return File.ReadLines(path)
				.Select(s => s.Trim())
				.Where(DataExists);
		}

		/// <summary>
		/// Sequential file reading. Tracking file position, uses for progress.
		/// </summary>
		public static IEnumerable<string> Read(string path, IProgress<int> progress)
		{
			int nextProgress = 0;
			int currentProgress = 0;
			int stepProgress = 10;

			using (StreamReader sr = new StreamReader(path))
			{
				long dataLenght = sr.BaseStream.Length;

				while (!sr.EndOfStream)
				{
					string current = sr.ReadLine().Trim();
					currentProgress = (int) (sr.BaseStream.Position * 100 / dataLenght);
					if (currentProgress > nextProgress)
					{
						progress.Report(currentProgress);
						nextProgress = currentProgress + stepProgress;
					}

					if (DataExists(current))
						yield return current;
				}
			}

			progress.Report(100);
		}

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