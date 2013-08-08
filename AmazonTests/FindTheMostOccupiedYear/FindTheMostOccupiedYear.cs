using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AmazonTests._3numbersproduct;

namespace AmazonTests.FindTheMostOccupiedYear
{
	//Given life time of different animals. 
	//Find period when maximum number of animals lived. ex [5, 11], [6, 18], [2, 5],[3,12] etc. year in which max no animals exists.

	class FindTheMostOccupiedYear
	{
		static PriorityQueue priorityQueue = new PriorityQueue();

		public static int MaxLivedCount ;

		public static int DateWhenMaxLived;

		public static void Test()
		{
			string input = @"5 11
6 18
2 5
3 12";
			IList<Period> periods = new List<Period>();
			foreach (var s in input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
			{
				

				int start = int.Parse(s.Split(' ')[0]);
				int end = int.Parse(s.Split(' ')[1]);

				Period period = new Period(){Start = start,End = end};
				periods.Add(period);
			}

			Process(periods);

			Console.WriteLine("Number of living animals:{0}", MaxLivedCount);
			Console.WriteLine("Date:{0}", DateWhenMaxLived);
		}

		public static void Process(IEnumerable<Period> periods)
		{
			int maxLived = 0;
			int dateWhenMaxLived = -1;
			foreach (var period in periods)
			{
				Event startEvent = new Event() { Period = period, IsStart = true };
				Event endEvent = new Event() { Period = period, IsStart = false };

				priorityQueue.Enqueue(startEvent, startEvent);
				priorityQueue.Enqueue(endEvent, endEvent);
			}

			HashSet<Period> set = new HashSet<Period>();

			
			while (priorityQueue.Count>0)
			{
				Event @event = (Event)priorityQueue.Dequeue();
				
				if (@event.IsStart)
				{
					set.Add(@event.Period);
					if (set.Count > maxLived)
					{
						maxLived = set.Count;
						dateWhenMaxLived = @event.Date;
					}
				}
				else
				{
					set.Remove(@event.Period);
				}
				
				
			}

			DateWhenMaxLived= dateWhenMaxLived;
			MaxLivedCount = maxLived;

		}

		internal class Period
		{
			public int Start;

			public int End;

			
		}

		class Event : IComparable
		{
			public int Date
			{
				get
				{
					return IsStart? Period.Start : Period.End;
				}
			}

			public Period Period;

			public bool IsStart;

			public int CompareTo(object obj)
			{
				Event other = obj as Event;

				return this.Date - other.Date;
			}
		}
	}

	
}
