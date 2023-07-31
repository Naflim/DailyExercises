using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 377. 组合总和 Ⅳ
    /// </summary>
    internal class CombinationSum4
    {
        public static int Run(int[] nums, int target)
        {
            int[] dp = new int[target + 1];
            dp[0] = 1;
            for (int i = 1; i <= target; i++)
            {
                foreach (int num in nums)
                {
                    if (num <= i)
                    {
                        dp[i] += dp[i - num];
                    }
                }
            }

            return dp[target];
        }
    }
}

 