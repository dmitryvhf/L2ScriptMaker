using System;
using L2ScriptMaker.Core.Parser;
using Xunit;

namespace L2ScriptMaker.Tests.UnitTests.Core
{
	public class InlineParamReaderTests
	{
		[Fact]
		public void Get()
		{
			string raw = "val1=1\tval2=TestMessage";

			ParsedData data = ParseService.Parse(raw);

			string result1 = data.GetValue<string>("val2");
			Assert.IsType<string>(result1);

			int result2 = data.GetValue<int>("val1");
			Assert.IsType<int>(result2);
		}

		[Fact]
		public void Get_NotExistedParam_Null()
		{
			string raw = "val1=1\tval2=TestMessage";
			ParsedData data = ParseService.Parse(raw);

			string result1 = data.GetValue<string>("val3");
			Assert.Null(result1);
		}


		[Fact]
		public void Get_ValueWithoutParam()
		{
			string raw = "val1=1\tval2=TestMessage\tval4";
			ParsedData data = ParseService.Parse(raw);

			string result2 = data.GetValue<string>(3);
			Assert.Equal("val4", result2);
		}

		[Fact]
		public void GetParam_WrongIntParam_Exception()
		{
			string raw = "val1=1\tval2=TestMessage";
			ParsedData data = ParseService.Parse(raw);

			Assert.Throws<InvalidCastException>(()=> data.GetValue<int>("val3"));
		}
	}
}
