using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 123. 买卖股票的最佳时机 III
    /// </summary>
    internal class MaxProfit3
    {
        public static int Run(int[] prices)
        {
            if (prices.Length < 4)
                return GetMaximumProfit(prices);

            //购买小于两次的情况
            var profitA = GetMaximumProfit(prices);

            //购买两次的情况
            var dp = GetDpTable(prices[0..^2]);
            var profitB = 0;
            for (var i = 1; i < prices.Length - 2; i++) 
            {
                profitB = Math.Max(profitB, dp[i] + GetMaximumProfit(prices[(i + 1)..]));
            }

            return Math.Max(profitA, profitB);
        }

        /// <summary>
        /// 计算从起始日期向后推演一次购买的最优dp表
        /// </summary>
        /// <param name="prices">股票价值</param>
        /// <returns>dp表</returns>
        public static int[] GetDpTable(int[] prices) 
        {
            int buy = prices[0];
            int[] dp = new int[prices.Length];

            for (int i = 1; i < prices.Length; i++)
            {
                dp[i] = prices[i] - buy;
                buy = Math.Min(buy, prices[i]);
            }

            return dp;
        }

        /// <summary>
        /// 计算从终止日期向前推演一次购买的最优dp表
        /// </summary>
        /// <param name="prices">股票价值</param>
        /// <returns>dp表</returns>
        public static int[] GetReverseDpTable(int[] prices)
        {
            int[] rPrices = prices.Reverse().ToArray();
            int[] dp = new int[prices.Length];
            //最优买入价格
            int buyPrice = rPrices[1];
            //最优卖出价格
            int sellPrice = rPrices[0];
            //利润
            int profit = sellPrice - buyPrice;

            for (int i = 1; i < prices.Length; i++)
            {
                //当此次价格为更优买入价格时
                if (rPrices[i] < buyPrice)
                {
                    //此时买入，利润增加
                    profit += buyPrice - rPrices[i];
                    buyPrice = rPrices[i];
                }
                //记录最优卖出价格
                sellPrice = Math.Max(sellPrice, rPrices[i - 1]);
                //当此时买入最优卖出可达到更大利润时
                if (sellPrice - rPrices[i] > profit) 
                {
                    //此时买入，利润增加
                    buyPrice = rPrices[i];
                    profit = sellPrice - rPrices[i];
                }
                dp[i] = profit;
            }

            Array.Reverse(dp);

            return dp;
        }

        /// <summary>
        /// 获取从起始日期向后推演一次购买的最大利润
        /// </summary>
        /// <param name="prices">股票价值</param>
        /// <returns>最大利润</returns>
        public static int GetMaximumProfit(int[] prices) 
        {
            var dp = GetDpTable(prices);
            return dp.Max();
        }

        public static int Run2(int[] prices)
        {
            if (prices.Length < 4)
                return GetMaximumProfit(prices);

            var dp1 = GetDpTable(prices);
            var dp2 = GetReverseDpTable(prices);

            //购买小于两次的情况
            var profitA = dp1.Max();

            //购买两次的情况
            var profitB = 0;
            for (var i = 1; i < prices.Length - 2; i++)
            {
                profitB = Math.Max(profitB, dp1[i] + dp2[i + 1]);
            }

            return Math.Max(profitA, profitB);
        }
    }
}
