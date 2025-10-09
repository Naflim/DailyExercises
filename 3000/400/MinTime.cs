using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 3494. 酿造药水需要的最少总时间
    /// </summary>
    internal class MinTime
    {
        public static long Run(int[] skill, int[] mana)
        {
            int n = skill.Length;
            long[] dp = new long[n];

            for (int i = 0; i < mana.Length; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == 0)
                    {
                        dp[j] = dp[j] + skill[j] * mana[i];
                    }
                    else
                    {
                        dp[j] = Math.Max(dp[j], dp[j - 1]) + skill[j] * mana[i];
                    }
                }

                for (int j = n - 2; j >= 0; j--)
                {
                    dp[j] = dp[j + 1] - skill[j + 1] * mana[i];
                }
            }

            return dp.Last();
        }
    }
}
