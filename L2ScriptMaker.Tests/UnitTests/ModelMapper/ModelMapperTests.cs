using System;
using FluentAssertions;
using L2ScriptMaker.Core.Attributes;
using L2ScriptMaker.Core.Mapper;
using L2ScriptMaker.Core.Parser;
using Xunit;

namespace L2ScriptMaker.Tests.UnitTests.ModelMapper
{
	public class ModelMapperTests
	{
		private string testLine = "val1=1	val2=TestMessage";

		[Fact]
		public void TestNotScriptModel()
		{
			Assert.Throws<ArgumentException>(() => new ModelMapper<CommonClassModel>());
		}

		[Fact]
		public void TestNormalModel()
		{
			ModelMapper<TestModel> mapper = new ModelMapper<TestModel>();
			TestModel model = new TestModel
			{
				Id = "1",
				Name = "TestMessage"
			};

			ParsedData data = ParseService.Parse(testLine);
			TestModel result = mapper.Map(data);

			result.Should().BeEquivalentTo(model);
		}

		[Fact]
		public void TestMissedFieldsModel()
		{
			ModelMapper<MissedFieldsModel> mapper = new ModelMapper<MissedFieldsModel>();
			MissedFieldsModel model = new MissedFieldsModel()
			{
				Id = "1",
				Name = null
			};

			ParsedData data = ParseService.Parse(testLine);
			MissedFieldsModel result = mapper.Map(data);

			result.Should().BeEquivalentTo(model);
		}

		[Fact]
		public void TestTargetTypeModel()
		{
			ModelMapper<TargetTypeModel> mapper = new ModelMapper<TargetTypeModel>();
			TargetTypeModel model = new TargetTypeModel()
			{
				Id = 1,
				Name = "TestMessage"
			};

			ParsedData data = ParseService.Parse(testLine);
			TargetTypeModel result = mapper.Map(data);

			result.Should().BeEquivalentTo(model);
			Assert.IsType<int>(result.Id);
		}

		private class CommonClassModel
		{
			public string Id { get; set; }

			public string Name { get; set; }
		}

		[Record]
		private class TestModel
		{
			[RecordParam("val1")]
			public string Id { get; set; }

			[RecordParam("val2")]
			public string Name { get; set; }
		}

		[Record]
		private class MissedFieldsModel
		{
			[RecordParam("val1")]
			public string Id { get; set; }

			[RecordParam("val3")]
			public string Name { get; set; }
		}

		[Record]
		private class TargetTypeModel
		{
			[RecordParam("val1")]
			public int Id { get; set; }

			[RecordParam("val2")]
			public string Name { get; set; }
		}
	}
}
