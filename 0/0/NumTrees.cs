using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 96. 不同的二叉搜索树
    /// </summary>
    internal class NumTrees
    {
        public static int Run(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                int[] dp = new int[n + 1];
                dp[0] = 1;
                dp[1] = 1;
                for (int i = 2; i <= n; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        dp[i] += dp[j] * dp[i - 1 - j];
                    }
                }

                return dp[^1];
            }
        }

        public static int Run2(int n)
        {
            int C = 1;
            for (int i = 0; i < n; ++i)
            {
                C = C * 2 * (2 * i + 1) / (i + 2);
            }
            return C;
        }
    }
}
