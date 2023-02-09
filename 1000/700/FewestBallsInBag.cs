using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1760. 袋子里最少数目的球
    /// </summary>
    internal class FewestBallsInBag
    {
        public static int Run(int[] nums, int maxOperations)
        {
            int left = 1, right = nums.Max();
            int result = right;
            while (left <= right)
            {
                int operations = maxOperations;
                int average = (left + right) / 2;
                foreach (int num in nums)
                {
                    operations -= (num - 1) / average;
                    if (operations < 0) break;
                }

                if (operations >= 0)
                {
                    right = average - 1;
                    result = average;
                }
                else left = average + 1;
            }

            return result;
        }
    }
}
