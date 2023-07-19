using System;
using System.Reflection;

namespace L2ScriptMaker.Forms.Services
{
	public static class AssemblyInfoUtil
	{
		private static Assembly Asm => Assembly.GetEntryAssembly()!;

		public static string Product => GetAssemblyAttribute<AssemblyProductAttribute>().Product;

		public static string Version => GetAssemblyAttribute<AssemblyFileVersionAttribute>().Version;
		public static string Copyright => GetAssemblyAttribute<AssemblyCopyrightAttribute>().Copyright;
		public static string Company => GetAssemblyAttribute<AssemblyCompanyAttribute>().Company;
		public static string Description => GetAssemblyAttribute<AssemblyDescriptionAttribute>().Description;
		public static string Title => GetAssemblyAttribute<AssemblyTitleAttribute>().Title;

		private static T GetAssemblyAttribute<T>() where T : Attribute
		{
			return Asm.GetCustomAttribute<T>()!;
		}
	}
}