using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace L2ScriptMaker.Core.Files
{
	public static class FileUtils
	{
		private static readonly Func<string, bool> FilterEmptyOrCommentLines =
			(s) => !String.IsNullOrWhiteSpace(s) && !s.StartsWith("//");

		public static IEnumerable<string> Read(string path)
		{
			return File.ReadLines(path).Where(FilterEmptyOrCommentLines);
		}

		/// <exception cref="NullReferenceException">Путь к файлу null или пустое значение</exception>
		/// <exception cref="FileNotFoundException">Файл не существует</exception>
		public static IEnumerable<string> Read(string path, IProgress<int> progress)
		{
			using (StreamReader sw = new StreamReader(path))
			{
				long dataLenght = sw.BaseStream.Length;

				while (!sw.EndOfStream)
				{
					string current = sw.ReadLine();
					progress.Report((int)(sw.BaseStream.Position * 100 / dataLenght));

					if (FilterEmptyOrCommentLines(current))
						yield return sw.ReadLine();
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