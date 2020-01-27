using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace L2ScriptMaker.Core.Files
{
	public static class FileUtils
	{
		private static readonly Func<string, bool> DataExists =
			(s) => !String.IsNullOrWhiteSpace(s) && !s.StartsWith("//");

		public static IEnumerable<string> Read(string path)
		{
			return File.ReadLines(path)
				.Select(s => s.Trim())
				.Where(DataExists);
		}

		public static IEnumerable<string> Read(string path, IProgress<int> progress)
		{
			using (StreamReader sr = new StreamReader(path))
			{
				long dataLenght = sr.BaseStream.Length;

				while (!sr.EndOfStream)
				{
					string current = sr.ReadLine();
					progress.Report((int)(sr.BaseStream.Position * 100 / dataLenght));

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
			FileInfo res = new FileInfo(file);
			return res;
		}
	}
}