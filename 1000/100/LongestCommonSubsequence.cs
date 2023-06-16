using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1143. 最长公共子序列
    /// </summary>
    internal class LongestCommonSubsequence
    {
        public static int Run(string text1, string text2)
        {
            int len1 = text1.Length;
            int len2 = text2.Length;
            int[,] dp = new int[len2, len1];
            dp[0, 0] = text1[0] == text2[0] ? 1 : 0;

            for (int i = 1; i < len1; i++)
            {
                dp[0, i] = dp[0, i - 1] == 1 || text1[i] == text2[0] ? 1 : 0;
            }

            for (int i = 1; i < len2; i++)
            {
                dp[i, 0] = dp[i - 1, 0] == 1 || text1[0] == text2[i] ? 1 : 0;
            }

            for (int i = 1; i < len2; i++)
            {
                for (int j = 1; j < len1; j++)
                {
                    int max = Math.Max(dp[i - 1, j], dp[i, j - 1]);

                    dp[i, j] =  text2[i] == text1[j] ? dp[i - 1, j - 1] + 1 : max;
                }
            }

            return dp[len2 - 1, len1 - 1];
        }
    }
}
