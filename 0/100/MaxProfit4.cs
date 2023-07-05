using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 188. 买卖股票的最佳时机 IV
    /// </summary>
    internal class MaxProfit4
    {
        public static int Run(int k, int[] prices)
        {
            int[] dp = new int[k * 2];
            Array.Fill(dp, int.MinValue);

            int len = prices.Length;

            for (int i = 0; i < len; i++)
            {
                int[] newdp = new int[k * 2];
                Array.Fill(newdp, int.MinValue);
                for (int j = 0; j < k * 2; j++)
                {
                    if (j > i)
                        break;

                    if (j == 0)
                    {
                        newdp[0] = Math.Max(-prices[i], dp[0]);
                    }
                    else
                    {
                        int profit;
                        if (j % 2 == 0)
                            profit = dp[j - 1] - prices[i];
                        else
                            profit = dp[j - 1] + prices[i];
                        newdp[j] = Math.Max(dp[j], profit);
                    }
                }

                dp = newdp;
            }

            var result = dp.Max();
            return result > 0 ? result : 0;
        }
    }
}
