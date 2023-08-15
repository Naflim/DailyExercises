using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 983. 最低票价
    /// </summary>
    internal class MincostTickets
    {
        public static int Run(int[] days, int[] costs)
        {
            int len = days.Length;
            int[] dp = new int[len];

            dp[0] = costs.Min();
            for (int i = 1; i < len; i++)
            {
                dp[i] = dp[i - 1] + costs[0];

                int payDay = days[i] - 7;
                if (payDay < days[0])
                {
                    dp[i] = Math.Min(dp[i], costs[1]);
                }
                else
                {
                    var index = FindDayIndex(days, payDay);
                    dp[i] = Math.Min(dp[i], dp[index] + costs[1]);
                }

                payDay = days[i] - 30;
                if (payDay < days[0])
                {
                    dp[i] = Math.Min(dp[i], costs[2]);
                }
                else
                {
                    var index = FindDayIndex(days, payDay);
                    dp[i] = Math.Min(dp[i], dp[index] + costs[2]);
                }
            }

            return dp[^1];
        }

        public static int FindDayIndex(int[] days,int day) 
        {
            int left = -1;
            int right = days.Length;

            while(left + 1 != right)
            {
                int pointer = (left + right) / 2;
                if (days[pointer] > day)
                    right = pointer;
                else if (days[pointer] < day)
                    left = pointer;
                else
                    return pointer;
            }

            return left;
        }
    }
}
