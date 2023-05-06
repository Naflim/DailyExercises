using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 516. 最长回文子序列
    /// </summary>
    internal class LongestPalindromeSubseq
    {
        public static int Run(string s)
        {
            if (s.Length == 0) return 0;
            else if (s.Length == 1) return 1;

            int[][] dp = new int[s.Length][];
            dp[0] = new int[s.Length];
            Array.Fill(dp[0], 1);
            dp[1] = new int[s.Length - 1];
            for (int i = 0; i<s.Length - 1; i++)
            {
                dp[1][i] = s[i] == s[i + 1] ? 2 : 1;
            }

            if (s.Length == 2) return dp[1][0];

            for (int i = 2; i < s.Length; i++)
            {
                dp[i] = new int[s.Length - i];
                for (int j = 0; j < dp[i].Length; j++)
                {
                    dp[i][j] = s[j] == s[j+i] ? 2 + dp[i - 2][j + 1] : Math.Max(dp[i - 1][j],dp[i - 1][j + 1]);
                }
            }

            return dp.Last()[0];
        }
    }
}
