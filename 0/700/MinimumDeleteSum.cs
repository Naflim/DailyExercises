using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 712. 两个字符串的最小ASCII删除和
    /// </summary>
    internal class MinimumDeleteSum
    {
        public static int Run(string s1, string s2)
        {
            int[,] dp = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 1; i <= s1.Length; i++) 
            {
                dp[i, 0] = dp[i - 1, 0] + s1[i - 1];
            }

            for (int i = 1; i <= s2.Length; i++)
            {
                dp[0, i] = dp[0, i - 1] + s2[i - 1];
            }

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i,j] = Math.Min(dp[i-1,j] + s1[i - 1], dp[i,j - 1] + s2[j - 1]);
                    }
                }
            }

            return dp[s1.Length, s2.Length];
        }
    }
}
