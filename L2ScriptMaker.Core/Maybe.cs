using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2ScriptMaker.Core
{
	public readonly struct Maybe<T>
	{
		public readonly bool IsNothing;

		private readonly T _value;

		private Maybe(bool isNothing, T value)
		{
			this.IsNothing = isNothing;
			this._value = value;
		}

		public static Maybe<T> Value(T value) => new Maybe<T>(false, value);
		public static readonly Maybe<T> Nothing = new Maybe<T>(true, default);

		public T GetValue() => this.IsNothing ? throw new Exception("Nothing") : this._value;

		public static implicit operator Maybe<T>(T value) => Value(value);
	}
}