using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 322. 零钱兑换
    /// </summary>
    internal class CoinChange
    {
        public static int Run(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];
            Array.Fill(dp, short.MaxValue);
            dp[0] = 0;

            for (int i = 0; i < coins.Length; i++)
            {
                int coin = coins[i];
                for (int j = coin; j <= amount; j++)
                {
                    dp[j] = Math.Min(dp[j], dp[j - coin] + 1);
                }
            }

            return dp[amount] == short.MaxValue ? -1 : dp[amount];
        }
    }
}
