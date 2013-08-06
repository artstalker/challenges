using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonTests
{
	class LongestRunningCharacterSequence
	{
		private char _longestCharacter;

		private int _longestSequence;

		char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

		public int Length
		{
			get
			{
				return _longestSequence;
			}
		}

		public char Character
		{
			get
			{
				return _longestCharacter;
			}
		}

		public void Process(string[] inputs)
		{
			_longestSequence = 0;
			_longestCharacter = ' ';

			Dictionary<char,int> prefixes = new Dictionary<char, int>();
			Dictionary<char, int> sufixes = new Dictionary<char, int>();
			Dictionary<char,int> body = new Dictionary<char, int>();
			foreach (var input in inputs.Select(x => x.ToUpper()))
			{
				var firstCharacter = input[0];
				var lastCharacter = input.Last();

				int count = StartCharacterLength(input);

				if (count == input.Length)
				{
					if (!body.ContainsKey(firstCharacter))
					{
						body[firstCharacter] = 0;
					}
					body[firstCharacter] += count;
					continue;
				}
				
				if (!prefixes.ContainsKey(firstCharacter))
				{
					prefixes[firstCharacter] = 0;
				}
				prefixes[firstCharacter] = Math.Max(prefixes[firstCharacter], count);

				count = StartCharacterLength(new string(input.Reverse().ToArray()));

				if (!sufixes.ContainsKey(lastCharacter))
				{
					sufixes[lastCharacter] = 0;
				}
				sufixes[lastCharacter] = Math.Max(sufixes[lastCharacter], count);
			}

			
			foreach (var character in alpha)
			{
				int prefix;
				prefixes.TryGetValue(character, out prefix);

				int inner;
				body.TryGetValue(character, out inner);

				int suffix;
				sufixes.TryGetValue(character, out suffix);

				int sumOfSequence = prefix + inner + suffix;
				if (sumOfSequence >= _longestSequence)
				{
					_longestSequence = sumOfSequence;
					_longestCharacter = character;
				}
			}
			
		}

		

		private int StartCharacterLength(string input)
		{
			int count = 0;
			foreach (var character in input)
			{
				
				if (character != input[0])
				{
					break;
				}
				count++;
			}

			return count;
		}
	}
}
