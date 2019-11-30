using System;
using System.Collections.Generic;
using System.Linq;
using L2ScriptMaker.Parsers.Parsers.Inline;
using Xunit;

namespace L2ScriptMaker.Tests.UnitTests.Core
{
	public class InlineParamReaderTests
	{
		InlineDataReader reader;

		public InlineParamReaderTests()
		{
			reader = new InlineDataReader();
		}

		[Fact]
		public void GetParam()
		{
			string raw = "val1=1 val2=TestMessage";
			InlineData data = reader.Read(raw);

			string result1 = data.GetValue<string>("val2");
			Assert.IsType<string>(result1);

			int result2 = data.GetValue<int>("val1");
			Assert.IsType<int>(result2);
		}

		[Fact]
		public void GetParam_EmptyValue()
		{
			string raw = "val1=1 val2=TestMessage\tval3=\tval4";
			InlineData data = reader.Read(raw);

			string result1 = data.GetValue<string>("val3");
			Assert.Equal("", result1);
			Assert.True(data.IsValuePossible("val3"));
		}

		[Fact]
		public void GetParam_WithoutValue()
		{
			string raw = "val1=1 val2=TestMessage\tval3=\tval4";
			InlineData data = reader.Read(raw);

			string result1 = data.GetValue<string>("val4");
			Assert.Null(result1);
			Assert.True(data.HasParam("val4"));
			Assert.False(data.IsValuePossible("val4"));
		}

		[Fact]
		public void GetParam_WrongStringParam_Null()
		{
			string raw = "val1=1 val2=TestMessage";
			InlineData data = reader.Read(raw);

			string result1 = data.GetValue<string>("val3");
			Assert.Null(result1);
		}

		[Fact]
		public void GetParam_WrongIntParam_Exception()
		{
			string raw = "val1=1 val2=TestMessage";
			InlineData data = reader.Read(raw);

			Assert.Throws<InvalidCastException>(()=> data.GetValue<int>("val3"));
		}
	}
}
