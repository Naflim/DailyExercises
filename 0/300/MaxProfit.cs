using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 309. 最佳买卖股票时机含冷冻期
    /// </summary>
    internal class MaxProfit
    {
        public static int Run(int[] prices)
        {
            int buy = int.MinValue;
            int sell = 0;
            int cd = 0;

            int len = prices.Length;
            for (int i = 0;i < len; i++)
            {
                int price = prices[i];
                int newBuy = Math.Max(buy, cd - price);
                int newSell = Math.Max(sell, buy + price);
                cd = sell;
                buy = newBuy;
                sell = newSell;
            }

            return new int[] { buy, sell, cd }.Max();
        }
    }
}
