using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 474. 一和零
    /// </summary>
    internal class FindMaxForm
    {
        public static int Run(string[] strs, int m, int n)
        {
            int[,] dp = new int[m + 1, n + 1];

            foreach (var str in strs)
            {
                int mCount = 0;
                int nCount = 0;
                foreach (var c in str)
                {
                    if (c == '0')
                        mCount++;
                    else
                        nCount++;
                }

                for (int i = m; i >= mCount; i--)
                {
                    for (int j = n; j >= nCount; j--)
                    {
                        dp[i, j] = Math.Max(dp[i, j], dp[i-mCount, j-nCount] + 1);
                    }
                }
            }

            return dp[m, n];
        }
    }
}
