using System;

namespace L2ScriptMaker.Core.Collections
{
	public class LimitedSizeStack<T>
	{
		protected readonly int LimitSize;
		protected StackItem<T> Head { get; private set; }
		protected StackItem<T> Last { get; private set; }
		public int Count { get; private set; }

		public LimitedSizeStack(int limit)
		{
			LimitSize = limit;
		}

		public void Push(T item)
		{
			StackItem<T> newItem = new StackItem<T>(item);
			if (Count == 0)
			{
				Head = newItem;
			}
			else
			{
				newItem.Before = Last;
				Last.Next = newItem;
			}

			Last = newItem;

			if (Count < LimitSize)
			{
				Count++;
				return;
			}

			StackItem<T> headCandidate = Head.Next;
			headCandidate.Before = null;
			Head.Next = null;
			Head = headCandidate;
		}

		public T Pop()
		{
			if (Count == 0)
			{
				throw new NullReferenceException();
			}

			T current = Last.Value;
			StackItem<T> before = Last.Before;
			if (before != null)
			{
				before.Next = null;
				Last = before;
			}

			Count--;
			if (Count == 0)
			{
				Head = null;
				Last = null;
			}
			return current;
		}

		public T Peek()
		{
			if (Count == 0)
			{
				throw new NullReferenceException();
			}

			T current = Last.Value;
			StackItem<T> before = Last.Before;
			if (before != null)
			{
				before.Next = null;
				Last = before;
			}

			Count--;
			if (Count == 0)
			{
				Head = null;
				Last = null;
			}
			return current;
		}

		protected class StackItem<T1>
		{
			public readonly T1 Value;
			public StackItem<T1> Before;
			public StackItem<T1> Next;

			public StackItem(T1 item)
			{
				this.Value = item;
			}
		}
	}

}
