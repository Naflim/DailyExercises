using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2312. 卖木头块
    /// </summary>
    internal class SellingWood
    {
        public static long Run(int m, int n, int[][] prices)
        {
            long[,] dp = new long[m + 1, n + 1];

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (int k = 0; k < prices.Length; k++)
                    {
                        var price = prices[k];
                        //判断木块是否能分割
                        if (i < price[0] || j < price[1])
                            continue;

                        //判断木块能否完美分割
                        if(i == price[0] || j == price[1])
                        {
                            //获取余下的块
                            long block;
                            if (i == price[0])
                                block = dp[i, j-price[1]];
                            else
                                block = dp[i - price[0], j];

                            dp[i, j] = Math.Max(dp[i, j], block + price[2]);
                        }
                        else
                        {
                            //如果不能完美分割
                            //先尝试横切一刀
                            long block1 = dp[price[0], j - price[1]];
                            long block2 = dp[i - price[0], j];
                            dp[i,j] = Math.Max(dp[i,j], block1 + block2 + price[2]);

                            //在尝试竖切一刀
                            long block3 = dp[i - price[0], price[1]];
                            long block4 = dp[i, j - price[1]];
                            dp[i, j] = Math.Max(dp[i, j], block3 + block4 + price[2]);
                        }
                    }
                }
            }

            return dp[m, n];
        }
    }
}
