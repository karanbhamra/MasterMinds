using System;
using System.Collections.Generic;

namespace MasterMindsRedux
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			char again = 'n';
			do
			{
				const int SIZE = 4;
				List<int> compNums = new List<int>(SIZE); // holds the random gen numbers
				UniqueRandom uRand = new UniqueRandom();    // used to gen ran numbers
				List<int> userNums = new List<int>(SIZE);  // users guesses
				List<bool> rightPosition = new List<bool>(SIZE) { false, false, false, false }; // will hold true if numbers in right position

				// generate the random nums
				for (int i = 0; i < SIZE; i++)
				{
					int num = uRand.GetUniqueNumber(0, 10);

					compNums.Add(num);
					//Console.Write(num); // debug
				}
				Console.WriteLine($"{SIZE} numbers were randomly chosen between 0 and 9");

				// get initial user input 
				for (int k = 0; k < SIZE; k++)
				{
					Console.WriteLine($"Enter num{k + 1}: ");
					int input = int.Parse(Console.ReadLine());
					userNums.Add(input);
				}

				// repeat everything until all numbers are in right position
				while (rightPosition.Contains(false))
				{
					Console.WriteLine();
					// loop through the guesses
					for (int i = 0; i < SIZE; i++)
					{
						// if the guess is inside the computer list
						if (compNums.Contains(userNums[i]))
						{
							// if the guess is in the right position
							if (userNums[i] == compNums[i])
							{
								Console.WriteLine($"num{i + 1} CORRECT position.");
								rightPosition[i] = true;
							}
							else
							{
								Console.WriteLine($"num{i + 1} WRONG position.");
							}
						}
						else
						{
							Console.WriteLine($"num{i + 1} NOT in the list.");
						}
					}

					if (rightPosition.Contains(false))  // if all positions are still not set
					{
						for (int k = 0; k < SIZE; k++)  // reenter wrong element
						{
							if (rightPosition[k] == false)
							{
								Console.WriteLine($"Enter num{k + 1}: ");
								int input = int.Parse(Console.ReadLine());
								userNums[k] = input;
							}
						}
					}
				}


				Console.WriteLine("You win!");
				Console.WriteLine("Play again? (y or n)");
				again = Console.ReadLine()[0];
				Console.WriteLine();
			} while (again == 'y');

			Console.WriteLine("Press any key to exit....");
			Console.ReadKey();


		}
	}
}
