using System.Collections.Generic;
using AutoMapper;

namespace L2ScriptMaker.Parsers.Core
{
	internal static class AutoMapService
	{
		//internal static TOut Map<TIn, TOut>(TIn data)
		//{
		//	// Создание конфигурации сопоставления
		//	var config = new MapperConfiguration(cfg => cfg.CreateMap<TIn, TOut>());
		//	// Настройка AutoMapper
		//	var mapper = new Mapper(config);
		//	// сопоставление
		//	return mapper.Map<TOut>(data);
		//}

		internal static List<TOut> Map<TIn, TOut>(List<TIn> data)
		{
			// Создание конфигурации сопоставления
			var config = new MapperConfiguration(cfg => cfg.CreateMap<TIn, TOut>());
			// Настройка AutoMapper
			var mapper = new Mapper(config);
			// сопоставление
			return mapper.Map<List<TOut>>(data);
		}
	}
}
