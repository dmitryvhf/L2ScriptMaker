using L2ScriptMaker.Parsers.Core;
using System;
using L2ScriptMaker.Models.Common;
using Xunit;

namespace L2ScriptMaker.Parsers.Tests
{
	public class InlineParamReaderTests
	{
		[Fact]
		public void Get()
		{
			string raw = "val1=1\tval2=TestMessage";

			ParsedData data = ParseService.ToKeyValueCollection(raw);

			string result1 = data.GetValue<string>("val2");
			Assert.IsType<string>(result1);

			int result2 = data.GetValue<int>("val1");
			Assert.IsType<int>(result2);
		}

		[Fact]
		public void Get_NotExistedParam_Null()
		{
			string raw = "val1=1\tval2=TestMessage";
			ParsedData data = ParseService.ToKeyValueCollection(raw);

			string result1 = data.GetValue<string>("val3");
			Assert.Null(result1);
		}

		[Fact]
		public void Get_ValueWithoutParam()
		{
			string raw = "val1=1\tval2=TestMessage\tval4";
			ParsedData data = ParseService.ToKeyValueCollection(raw);

			string result2 = data.GetValue<string>(3);
			Assert.Equal("val4", result2);
		}

		[Fact]
		public void GetParam_WrongIntParam_Exception()
		{
			string raw = "val1=1\tval2=TestMessage";
			ParsedData data = ParseService.ToKeyValueCollection(raw);

			Assert.Throws<InvalidCastException>(() => data.GetValue<int>("val3"));
		}

		[Fact]
		public void CommentLine_IsEmpty()
		{
			string raw = "// val1=1\tval2=TestMessage";
			ParsedData data = ParseService.ToKeyValueCollection(raw);

			Assert.True(data.IsEmpty);
		}

		[Fact]
		public void EmptyLine_IsEmpty()
		{
			string raw = string.Empty;
			ParsedData data = ParseService.ToKeyValueCollection(raw);

			Assert.True(data.IsEmpty);
		}
	}
}
