using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace L2ScriptMaker.Extensions.VbCompatibleHelper
{
	public static class MyAssemblyInfo
	{
		private static Assembly Asm => Assembly.GetExecutingAssembly();

		public static string Product => ((AssemblyProductAttribute) Asm.GetCustomAttribute(typeof(AssemblyProductAttribute))).Product;
		public static string Version => ((AssemblyFileVersionAttribute)Asm.GetCustomAttribute(typeof(AssemblyFileVersionAttribute))).Version;
		public static string Copyright => ((AssemblyCopyrightAttribute)Asm.GetCustomAttribute(typeof(AssemblyCopyrightAttribute))).Copyright;
		public static string Company => ((AssemblyCompanyAttribute)Asm.GetCustomAttribute(typeof(AssemblyCompanyAttribute))).Company;
		public static string Description => ((AssemblyDescriptionAttribute)Asm.GetCustomAttribute(typeof(AssemblyDescriptionAttribute))).Description;
		public static string Title
		{
			get
			{
				if (!string.IsNullOrEmpty(((AssemblyTitleAttribute)Asm.GetCustomAttribute(typeof(AssemblyTitleAttribute)))
					.Title))
					return ((AssemblyTitleAttribute)Asm.GetCustomAttribute(typeof(AssemblyTitleAttribute)))
						.Title;
				return System.IO.Path.GetFileNameWithoutExtension(Asm.GetName().Name);
			}
		}
	}
}
