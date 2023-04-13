using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 746. 使用最小花费爬楼梯
    /// </summary>
    public class MinCostClimbingStairs
    {
        public static int Run(int[] cost)
        {
            if (cost.Length == 1) return cost[0];
            else if (cost.Length == 2) return Math.Min(cost[0], cost[1]);

            int[] dp = new int[cost.Length - 1];
            dp[0] = Math.Min(cost[0], cost[1]);

            dp[1] = Math.Min(cost[1], dp[0] + cost[2]);
            for (int i = 2; i < dp.Length; i++)
            {
                dp[i] = Math.Min(dp[i - 1] + cost[i + 1], dp[i - 2]+ cost[i]);
            }

            return dp.Last();
        }
    }
}
