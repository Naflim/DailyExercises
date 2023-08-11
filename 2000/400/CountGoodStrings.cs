using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2466. 统计构造好字符串的方案数
    /// </summary>
    internal class CountGoodStrings
    {
        const int MOD = 0x3b9aca07;

        public static int Run(int low, int high, int zero, int one)
        {
            int[] dp = new int[high + 1];
            dp[0] = 1;

            for (int i = 1; i <= high; i++)
            {
                if(i >= zero)
                    dp[i] = (dp[i] + dp[i - zero]) % MOD;

                if (i >= one)
                    dp[i] = (dp[i] + dp[i - one]) % MOD;
            }
            int result = 0;
            for (int i = low; i <= high; i++)
            {
                result = (result + dp[i]) % MOD;
            }

            return result;
        }
    }
}
