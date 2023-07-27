using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 518. 零钱兑换 II
    /// </summary>
    internal class Change
    {
        public static int Run(int amount, int[] coins)
        {
            if (amount == 0) 
                return 1;

            int[] dp = new int[amount + 1];
            for (int i = 0; i < coins.Length; i++) 
            {
                int[] newDp = new int[dp.Length];
                for (int j = 1; j <= amount; j++)
                {
                    int jVal = j - coins[i];
                    int dpVal = 0;
                    while(jVal >= 0)
                    {
                        if (jVal == 0)
                            dpVal++;
                        else
                            dpVal += dp[jVal];

                        jVal -= coins[i];
                    }

                    dpVal += dp[j];
                    newDp[j] = dpVal;
                }
                dp = newDp;
            }

            return dp[amount];
        }
    }
}
