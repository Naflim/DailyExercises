using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 790. 多米诺和托米诺平铺
    /// </summary>
    internal class NumTilings
    {
        const int MOD = 0x3b9aca07;

        public static int Run(int n)
        {
            int[][] dp = new int[n + 1][];
            for (int i = 0; i <= n; i++)
            {
                dp[i] = new int[4];
            }
            dp[0][3] = 1;
            for (int i = 1; i <= n; i++)
            {
                dp[i][0] = dp[i - 1][3];
                dp[i][1] = (dp[i - 1][0] + dp[i - 1][2]) % MOD;
                dp[i][2] = (dp[i - 1][0] + dp[i - 1][1]) % MOD;
                dp[i][3] = (((dp[i - 1][0] + dp[i - 1][1]) % MOD + dp[i - 1][2]) % MOD + dp[i - 1][3]) % MOD;
            }
            return dp[n][3];
        }
    }
}
