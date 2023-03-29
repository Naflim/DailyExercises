using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    ///  1641. 统计字典序元音字符串的数目
    /// </summary>
    internal class CountVowelStrings
    {
        public static int Run(int n)
        {
            if (n == 1) return 5;

            int[,] dp = new int[n - 1, 4];

            dp[0, 0] = 3;
            for (int i = 1; i < 4; i++)
            {
                dp[0, i] = dp[0, i-1] + i + 2;
            }

            for (int i = 1; i < n - 1; i++)
            {
                dp[i, 0] = i + 3;
            }

            for (int i = 1; i < n - 1; i++)
            {
                for (int j = 1; j<4; j++)
                {
                    dp[i, j] = dp[i-1, j] + dp[i, j-1];
                }
            }

            return dp[n-2, 3];
        }
    }
}
