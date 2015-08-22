using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine("Pleas input: ");
			//int TestCaseNumber = int.Parse(Console.ReadLine());

			//if (TestCaseNumber > 0 && TestCaseNumber <= 10)
			//{
			//	for (int idx = 0; idx <= TestCaseNumber; idx++)
			//	{
			//		OutPutResult();
			//	}
			//}
			//else
			//{
			//	Console.WriteLine("1<=T<=10");
			//}	

			DateTime startTime = DateTime.Now;
			long number =0;
			number = CalculateWays(4);

			Console.WriteLine(string.Format("1. End Time {0} -- {1}", (DateTime.Now - startTime).TotalSeconds, number));

			number = 0;

			startTime = DateTime.Now;
			number = FibonacciSeries(0);
			
			Console.WriteLine(string.Format("2. End Time {0} -- {1}",(DateTime.Now-startTime).TotalSeconds,number ));
			
			number = 0;
			number = FibonacciNumber(0);
			Console.WriteLine(string.Format("3. End Time {0} -- {1}", (DateTime.Now - startTime).TotalSeconds, number));
			//bool flag = AreStringsAnagrams("aba", "baba");
			//Console.WriteLine(flag);

			PrintPascalTriangle();
			Console.ReadLine();
		}

		/// <summary>
		/// An anagram is a word formed from another by rearranging its letters, using all the original letters exactly once; 
		/// for example, orchestra can be rearranged into carthorse. Write a function that checks if two words are each other's anagrams.
		/// For example, AreStringsAnagrams("momdad", "dadmom") should return true as arguments are anagrams.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static bool AreStringsAnagrams(string a, string b)
		{
			Regex rgx = new Regex("[^a-zA-Z]");
			a = rgx.Replace(a, string.Empty);
			b = rgx.Replace(b, string.Empty);

			List<KeyValuePair<char, int>> kvp_a = new List<KeyValuePair<char,int>>();
			List<KeyValuePair<char, int>> kvp_b = new List<KeyValuePair<char,int>>();

			var sa = a.Where(c => char.IsLetter(c)).OrderBy(c => c).ToArray();
			var sb = b.Where(x => char.IsLetter(x)).OrderBy(x => x).ToArray();

			foreach (char c in sb)
			{
				KeyValuePair<char, int> pairB=new KeyValuePair<char,int>();
				if (kvp_b.Where(x => x.Key == c).Count() == 0)
				{
					pairB = new KeyValuePair<char, int>(c, 1);
					kvp_b.Add(pairB);
				}
				else
				{
					var newpairB = new KeyValuePair<char, int>(pairB.Key, pairB.Value + 1);
					kvp_b.Remove(pairB);
					kvp_b.Add(newpairB);
				}
			}

			foreach (char c in sa)
			{
				KeyValuePair<char, int> pairA = new KeyValuePair<char, int>();

				if (kvp_a.Where(x => x.Key == c).Count() == 0)
				{
					pairA = new KeyValuePair<char, int>(c, 1);
					kvp_a.Add(pairA);
				}
				else
				{
					var newpairA = new KeyValuePair<char, int>(pairA.Key, pairA.Value+1);
					kvp_a.Remove(pairA);
					kvp_a.Add(newpairA);
				}
			}

			if (kvp_a.Count != kvp_b.Count)
			{
				return false;
			}
			else
			{
				foreach (var aa in kvp_a)
				{
					if (kvp_b.Where(x => x.Key == aa.Key && x.Value == aa.Value).Count() == 0)
					{
						return false;
					}
				}
			}

			return true;
		}
		/// <summary>
		/// A frog only moves forward, but it can move in steps 1 inch long or in jumps 2 inches long. A frog can cover the same distance using different combinations of steps and jumps.
		/// Write a function that calculates the number of different combinations a frog can use to cover a given distance.
		/// For example, a distance of 3 inches can be covered in three ways: step-step-step, step-jump, and jump-step.
		/// </summary>
		static int num = 0;

		public static long FibonacciNumber(int n)
		{
			int f0 = 0;
			int f1 = 1;
			int f2 = 2;

			int first = f1;
			int second = f2;

			int result=0;

			if (n == 0)
				result = f0;

			if (n == 1)
				result = f1;

			if (n == 2)
				result = f2;

			for (int idx = 3; idx <= n; idx++)
			{
				result = first + second;
				
				first = second;
				second = result;
			}

			return result;
		}

		public static long FibonacciSeries(int n)
		{						
			long a = 0;
			long b = 1;

			for (int i = 0; i <= n; i++)
			{
				long temp = a;
				a = b;
				b = temp + b;
			}
			return a;

			
		}

		public static int CalculateWays(int number)
		{
			//Console.WriteLine(string.Format("current deal with {0}", number));
			if (number == 0)
			{
				++num;
			}
			else if (number < 0)
			{
				return num;
			}

			if(number -1 >=0)
				CalculateWays(number - 1);

			if(number -2 >=0)
				CalculateWays(number - 2);

			return num;
		}

		/// <summary>
		/// By using two-dimensional array of C# language, write C# program to display a table that 
		/// represents a Pascal triangle of any size. 
		/// In Pascal triangle, the first and the second rows are set to 1. 
		/// Each element of the triangle (from the third row downward) is the sum of the element directly above it and 
		/// the element to the left of the element directly above it. See the example Pascal triangle(size=5) below:
		/// 1				
		/// 1	1			
		/// 1	2	1		
		/// 1	3	3	1	
		/// 1	4	6	4	1
		/// </summary>
		public static void PrintPascalTriangle()
		{
			System.Console.WriteLine("Pascal Triangle Program");
			System.Console.Write("Enter the number of rows: ");
			string input = System.Console.ReadLine();

			int n = Convert.ToInt32(input);
			// row number=n
			for (int y = 0; y < n; y++)
			{
				int c = 1;
				//for (int q = 0; q < n - y; q++)
				//{
				//	System.Console.Write("   ");
				//}

				//print column for each row
				for (int x = 0; x <= y; x++)
				{
					System.Console.Write("   {0:D}  ", c);
					//calculate the number
					c = c * (y - x) / (x + 1);
				}
				System.Console.WriteLine();
				System.Console.WriteLine();
			}
			System.Console.WriteLine();
		}

		/// <summary>
		/// Write a function that checks if a given sentence is a palindrome. A palindrome is a word, phrase, verse, or 
		/// sentence that reads the same backward or forward. Only the order of English alphabet letters (A-Z and a-z) should be considered, other characters should be ignored.
		/// For example, IsPalindrome("Noel sees Leon.") should return true as spaces, period, and 
		/// case should be ignored resulting with "noelseesleon" which is a palindrome since it reads same backward and forward.
		/// </summary>
		/// <param name="s"></param>
		private static bool IsPalindrome(string s)
		{
			Regex rgx = new Regex("[^a-zA-Z]");
			s = rgx.Replace(s, "").ToUpper();
			bool result = true;

			if (!string.IsNullOrEmpty(s))
			{
				int startPnt = 0;
				int endPnt = s.Length - 1;

				while (startPnt <= endPnt)
				{
					if (s[startPnt] == s[endPnt])
					{
						startPnt++;
						endPnt--;
					}
					else
					{
						result = false;
						break;
					}
				}

				return result;
			}
			else
			{
				return false;
			}
		}

		static private void OutPutResult()
		{
			string inputString = Console.ReadLine();
			string[] values = inputString.Split(' ');
			if(values.Length ==2)
			{
				int StudentNumber = int.Parse(values[0]);
				int RequiredNumber = int.Parse(values[1]);
				bool cancelled = true;
				int arrivedNumber = 0;
				string StudentArriveTime = Console.ReadLine();
				string[] arriveValues = StudentArriveTime.Split(' ');

				for (int i = 0; i < StudentNumber; i++)
				{
					if (int.Parse(arriveValues[i]) <= 0)
						arrivedNumber++;

					if (arrivedNumber >= RequiredNumber)
					{
						cancelled = false;
						break;
					}
				}

				if (cancelled)
				{
					Console.WriteLine("YES");
				}
				else
					Console.WriteLine("NO");
			}
		}
	}
}
