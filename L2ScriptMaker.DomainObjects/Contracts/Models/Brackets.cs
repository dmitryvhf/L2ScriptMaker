using System;

namespace L2ScriptMaker.DomainObjects.Contracts.Models
{
	/// <summary>
	///		Обрамляющие символы
	/// </summary>
	public enum Brackets
	{
		/// <summary>
		///		Без обрамления
		/// </summary>
		None,

		/// <summary>
		///		Квадратные скобки
		/// </summary>
		Square,

		/// <summary>
		///		Круглые скобки
		/// </summary>
		Round,

		/// <summary>
		///		Фигурные скобки
		/// </summary>
		Decorative
	}
}
