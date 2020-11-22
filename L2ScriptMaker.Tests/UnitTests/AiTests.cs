using System.Text.RegularExpressions;
using Xunit;

namespace L2ScriptMaker.Tests.UnitTests
{
	public class AiMessagesTests
	{
		private readonly Regex _aiMessageRegex = new Regex("^(S\\d{1,6})\\.\\s(\".*\")$");

		[Theory]
		[InlineData("S1234. \"pet_around_pet_manager\"")]
		[InlineData("S1234.\t\"pet_around_pet_manager\"")]
		public void ImportRegex_Success(string line)
		{
			Assert.Matches(_aiMessageRegex, line);

			Match match = _aiMessageRegex.Match(line);
			Assert.Equal(line, match.Value);
		}

		[Theory]
		[InlineData(" S1234. \"pet_around_pet_manager\"")]
		[InlineData("S1234. pet_around_pet_manager")]
		[InlineData("L1234. \"pet_around_pet_manager\"")]
		[InlineData("")]
		[InlineData(null)]
		public void ImportRegex_Wrong(string line)
		{
			Assert.DoesNotMatch(_aiMessageRegex, line);
		}
	}
}
