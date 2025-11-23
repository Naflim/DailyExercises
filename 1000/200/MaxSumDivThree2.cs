using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1262. 可被三整除的最大和
    /// </summary>
    internal class MaxSumDivThree2
    {
        public static int Run(int[] nums)
        {
            List<int>[] map = new List<int>[3];
            for (int i = 0; i < 3; i++)
            {
                map[i] = new List<int>();
            }   

            foreach (var num in nums)
            {
                map[num % 3].Add(num);
            }

            for (int i = 0; i < 3; i++)
            {
                map[i].Sort();
            }

            int sum = nums.Sum();

            if (sum % 3 == 0)
            {
                return sum;
            }
            else if (sum % 3 == 1)
            {
                int option1 = int.MinValue;
                if (map[1].Count >= 1)
                {
                    option1 = sum - map[1][0];
                }

                int option2 = int.MinValue;
                if (map[2].Count >= 2)
                {
                    option2 = sum - map[2][0] - map[2][1];
                }

                return Math.Max(option1, option2);
            }
            else
            {
                int option1 = int.MinValue;
                if (map[2].Count >= 1)
                {
                    option1 = sum - map[2][0];
                }

                int option2 = int.MinValue;
                if (map[1].Count >= 2)
                {
                    option2 = sum - map[1][0] - map[1][1];
                }

                return Math.Max(option1, option2);
            }
        }
    }
}
