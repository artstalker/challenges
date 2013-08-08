using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonTests
{
	class Program
	{
		private static string test = @"ab
ba
aac";
		static void Main(string[] args)
		{
			//LongestRunningCharacterSequence processor = new LongestRunningCharacterSequence();
			//processor.Process(test.Split(new string[] {Environment.NewLine},StringSplitOptions.RemoveEmptyEntries));

			//Console.WriteLine(processor.Character);
			//Console.WriteLine(processor.Length);


			//FindNumberOccurencesInArray.FindNumberOccurencesInArray.RunTest();

			FindTheMostOccupiedYear.FindTheMostOccupiedYear.Test();

			Console.Read();
		}
	}
}
