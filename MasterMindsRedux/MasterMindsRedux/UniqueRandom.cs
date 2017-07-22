using System;
using System.Collections.Generic;
namespace MasterMindsRedux
{
	public class UniqueRandom
	{
		Random rand;
		List<int> nums;
		bool initial;

		public UniqueRandom()
		{
			rand = new Random();
			nums = new List<int>();
			initial = true;

		}

		public int GetUniqueNumber(int min, int max)
		{
			int num;
			if (initial)
			{
				num = rand.Next(min, max);

				initial = false;
				nums.Add(num);
				return num;

			}
			else
			{

				while (true)
				{
					num = rand.Next(min, max);
					if (!nums.Contains(num))
					{
						nums.Add(num);
						return num;
					}
				}
			}

		}


	}
}
