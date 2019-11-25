using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using L2ScriptMaker.Core.Files;
using Xunit;

namespace L2ScriptMaker.Tests.IntegrationTests.Core
{
	public class FileUtilsTests
	{
		string[] GetFileData()
		{
			return new string[]
			{
				"aaaaa1",
				"zzzzz2",
				"ббббб3",
				"яяяяя4"
			};
		}

		[Fact]
		public void SaveAndLoadFile()
		{
			string testFile = Path.GetTempFileName();
			string[] data = GetFileData();

			// Save test
			FileUtils.SaveFile(data, testFile, Encoding.Default);

			FileInfo fileInfo = FileUtils.GetFileInfo(testFile);

			Assert.True(fileInfo.Exists); 
			Assert.True(fileInfo.Length > 0);

			// Read test
			IEnumerable<string> rawData = FileUtils.ReadFile(testFile);

			var readData = rawData.ToArray();
			int saveDataLength = String.Join(String.Empty, data).Length + data.Length * 2;
			int readDataLength = String.Join(String.Empty, data).Length + data.Length * 2;

			Assert.True(data.Length > 0);
			Assert.Equal(saveDataLength, readDataLength);
			Assert.Equal(data[3], readData[3]);

			// Finally
			File.Delete(testFile);
		}
	}
}
