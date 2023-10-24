using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1155. 掷骰子等于目标和的方法数
    /// </summary>
    internal class NumRollsToTarget
    {
        public static int Run(int n, int k, int target)
        {
            if(n == 1)
            {
                if (target <= k)
                    return 1;
                else
                    return 0;
            }

            int[] dp = new int[target + 1];
            for (int i = 1; i <= target && i <= k; i++)
            {
                dp[i] = 1;
            }

            for (int i = 0; i < n - 1; i++)
            {
                int[] newDp = new int[target + 1];
                for (int j = 1; j <= k; j++)
                {
                    for (int k2 = j + 1; k2 <= target; k2++)
                    {
                        newDp[k2] =  (newDp[k2] + dp[k2 - j]) % 1000000007;
                    }
                }

                dp = newDp;
            }

            return dp[^1];
        }
    }
}
