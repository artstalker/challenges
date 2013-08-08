using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonTests.FindNumberOccurencesInArray
{
	class FindNumberOccurencesInArray
	{

		public static void RunTest()
		{
			string input = "1 2 1 3 5 9 1 5 5 6 9 1";
			var array = input.Split(' ').Select(x => int.Parse(x));

			var output = Process(array.ToArray());
			Console.WriteLine(string.Join(" ",output));
		}
		public static int[] Process(int[] array)
		{
			int cursor = 0;
			while (cursor< array.Length)
			{
				int number = array[cursor];

				if (number <= 0)
				{
					cursor++;
					continue;
				}
				int number_index = number - 1;

				
				if (array[number_index] > 0)
				{
					cursor = array[number_index];
					array[cursor] = 0;
					array[number_index] = -1;
				}
				else
				{
					array[number_index]-=1;
					array[cursor] = 0;
					cursor++;
				}
			}

			return array;
		}

	}
}
