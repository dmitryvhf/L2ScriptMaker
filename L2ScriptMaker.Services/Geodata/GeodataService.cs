using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2ScriptMaker.Services.Geodata
{
	public static class GeodataService
	{
		private const int XDefaultMap = 20;
		private const int YDefaultMap = 18;

		public static int GetXMapNumber(int xCoordinate)
		{
			int result = XDefaultMap + GetMapShift(xCoordinate);
			return result;
		}

		public static int GetYMapNumber(int yCoordinate)
		{
			int result = YDefaultMap + GetMapShift(yCoordinate);
			return result;
		}

		private static int GetMapShift(int position) => (int)Math.Round((double)position / GeodataConstants.MapLength, MidpointRounding.ToNegativeInfinity);
	}
}
