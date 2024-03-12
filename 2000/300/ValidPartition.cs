using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2369. 检查数组是否存在有效划分
    /// </summary>
    internal class ValidPartition
    {
        public static bool Run(int[] nums)
        {
            if(nums.Length < 2)
                return false;

            bool[] dp = new bool[nums.Length];

            if (nums[0] == nums[1])
            {
                dp[1] = true;
            }


            if(nums.Length  == 2)
                return dp[1];

            for (int i = 2; i < nums.Length; i++)
            {
                int prev1 = nums[i - 2];
                int prev2 = nums[i - 1];
                int now = nums[i];

                if (prev2 == now && dp[i - 2])
                {
                    dp[i] = true;
                    continue;
                }

                if(prev1 == prev2 && prev1 == now)
                {
                    if(i - 3 >= 0)
                    {
                        if (dp[i - 3])
                            dp[i] = true;
                    }
                    else
                    {
                        dp[i] = true;
                    }
                } 

                if(prev1 +1 == prev2 && prev2 +1 == now)
                {
                    if (i - 3 >= 0)
                    {
                        if (dp[i - 3])
                            dp[i] = true;
                    }
                    else
                    {
                        dp[i] = true;
                    }
                }
            }

            return dp.Last();
        }
    }
}
