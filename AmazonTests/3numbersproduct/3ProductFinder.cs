using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonTests._3numbersproduct
{
	class ThreeProductFinder
	{
		Stack<Number> resultValues = new Stack<Number>();
		static PriorityQueue priorityQueue = new PriorityQueue();
		public static IEnumerable<int> Find(int[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				Number number = new Number(array[i],i);
				priorityQueue.Enqueue(number,number);
			}


		}


		struct Number : IComparable, IComparable<Number>
		{
			public int Value;

			public int Position;

			public Number(int value, int position)
			{
				Value = value;
				Position = position;
			}


			public int CompareTo(object obj)
			{
				return CompareTo((Number)obj);
			}

			public int CompareTo(Number other)
			{
				return this.Value - other.Value;
			}
		}

	}
}
