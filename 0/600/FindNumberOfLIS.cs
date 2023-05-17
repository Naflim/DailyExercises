using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 673. 最长递增子序列的个数
    /// </summary>
    internal class FindNumberOfLIS
    {
        public static int Run(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            int[] dp = new int[nums.Length];
            dp[0] = 1;
            int maxans = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
                maxans = Math.Max(maxans, dp[i]);
            }


            List<(int, int)>[] dp2 = new List<(int, int)>[maxans];

            for (int i = 0; i < maxans; i++)
            {
                dp2[i] = new List<(int, int)>();
            }

            for (int i = 0; i < dp.Length; i++)
            {
                var val = dp[i] - 1;

                if (val == 0) dp2[val].Add((nums[i], 1));
                else
                {
                    var last = dp2[val - 1];
                    int count = 0;
                    foreach (var item in last)
                    {
                        if (item.Item1 < nums[i])
                        {
                            count += item.Item2;
                        }
                    }

                    dp2[val].Add((nums[i], count));
                }
            }

            return dp2[^1].Select(v => v.Item2).Sum();
        }
    }
}
