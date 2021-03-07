using L2ScriptMaker.Services.Geodata;
using Xunit;

namespace L2ScriptMaker.Tests.UnitTests.Services
{
	public class GeodataServiceTests
	{
		[Theory]
		[InlineData(0, 20)]
		[InlineData(-1, 19)]
		[InlineData(10000, 20)]     // Dark Elf Village
		[InlineData(-84516, 17)]     // Human Village
		[InlineData(-18511, 19)]    // Gludio
		[InlineData(44721, 21)]     // Giran
		[InlineData(149082, 24)]     // Aden
		public void CalculateXMap(int xPos, int xMap)
		{
			Assert.Equal(xMap, GeodataService.GetXMapNumber(xPos));
		}

		[Theory]
		[InlineData(0, 18)]
		[InlineData(-1, 17)]
		[InlineData(10000, 18)]     // Dark Elf Village
		[InlineData(242971, 25)]     // Human Village
		[InlineData(121836, 21)]     // Gludio
		[InlineData(190698, 23)]     // Giran
		[InlineData(4926, 18)]      // Aden
		public void CalculateYMap(int yPos, int yMap)
		{
			Assert.Equal(yMap, GeodataService.GetYMapNumber(yPos));
		}
	}
}
