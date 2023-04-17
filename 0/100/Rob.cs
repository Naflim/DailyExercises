using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 198. 打家劫舍
    /// </summary>
    internal class Rob
    {
        public static int Run(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            else if (nums.Length == 2) return Math.Max(nums[0], nums[1]);

            int[] dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            int max = dp[0];

            for (int i = 2; i < dp.Length; i++)
            {
                dp[i] = nums[i] + max;
                max = Math.Max(max, dp[i - 1]);
            }

            return dp.Max();
        }
    }
}
