using FluentAssertions;
using L2ScriptMaker.Parsers.Models;
using L2ScriptMaker.Parsers.Parsers.Inline;
using Xunit;

namespace L2ScriptMaker.Tests.UnitTests.InlineParser
{
	public class InlineParserTests
	{
		string testLine = "val1=1	val2=TestMessage";
		readonly IInlineParser _parser = new InlineParser<NpcDataDto>();

		public InlineParserTests()
		{
			_parser.Initialize();
		}

		[Fact]
		public void NormalModel()
		{
			TestModel model = new TestModel
			{
				Id = "1", Name = "TestMessage"
			};
			
			TestModel result = _parser.Parse<TestModel>(testLine);

			model.Should().BeEquivalentTo(result);
		}

		[Fact]
		public void MissedFieldsModel()
		{
			MissedFieldsModel model = new MissedFieldsModel()
			{
				Id = "1",
				Names = null
			};

			MissedFieldsModel result = _parser.Parse<MissedFieldsModel>(testLine);

			model.Should().BeEquivalentTo(result);
		}

		[Fact]
		public void TargetTypeModel()
		{
			TargetTypeModel model = new TargetTypeModel()
			{
				Id = 1,
				Name = "TestMessage"
			};

			TargetTypeModel result = _parser.Parse<TargetTypeModel>(testLine);

			model.Should().BeEquivalentTo(result);
		}
	}

	class TestModel
	{
		public string Id { get; set; }

		public string Name { get; set; }
	}

	class MissedFieldsModel
	{
		public string Id { get; set; }

		public string Names { get; set; }
	}

	class TargetTypeModel
	{
		public int Id { get; set; }

		public string Name { get; set; }
	}
}
