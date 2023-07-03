using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 714. 买卖股票的最佳时机含手续费
    /// </summary>
    internal class MaxProfit2
    {
        public static int Run(int[] prices, int fee)
        {
            int buy = int.MinValue;
            int sell = 0;

            int len = prices.Length;
            for (int i = 0; i < len; i++)
            {
                int price = prices[i];
                int newBuy = Math.Max(buy, sell - price - fee);
                int newSell = Math.Max(sell, buy + price);
                buy = newBuy;
                sell = newSell;
            }

            return Math.Max(buy, sell); 
        }
    }
}
