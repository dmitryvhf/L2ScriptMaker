using System;

namespace L2ScriptMaker.Extensions.VbCompatibleHelper
{
	public static class Conversions
	{
		public static bool ToBoolean(string value) => Convert.ToBoolean(value);

		public static short ToShort(int value) => Convert.ToInt16(value);
		public static short ToShort(string value) => Convert.ToInt16(value);

		public static int ToInteger(long value) => Convert.ToInt32(value);
		public static int ToInteger(double value) => Convert.ToInt32(value);
		public static int ToInteger(string value) => Convert.ToInt32(value);

		public static double ToDouble(string value) => Convert.ToDouble(value);
		public static double Val(string value) => Convert.ToDouble(value);
		public static double Fix(double value) => Math.Truncate(value);

		public static long ToLong(double value) => Convert.ToInt64(value);
		public static long ToLong(string value) => Convert.ToInt64(value);

		public static char ToChar(string value) => Convert.ToChar(value);

		public static string ToString(DateTime value) => Convert.ToString(value);
		public static string ToString(long value) => Convert.ToString(value);
		public static string ToString(int value) => Convert.ToString(value);
		public static string ToString(double value) => Convert.ToString(value);

		public static byte ToByte(int value) => Convert.ToByte(value);
		public static byte ToByte(double value) => Convert.ToByte(value);

		public static string Hex(int value) => value.ToString("X");

		public static uint ToUInteger(double value) => Convert.ToUInt32(value);
		public static uint ToUInteger(string value) => Convert.ToUInt32(value);

		public static string Str(int value) => Convert.ToString(value);
	}
}
