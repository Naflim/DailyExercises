﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 70. 爬楼梯
    /// </summary>
    public class ClimbStairs
    {
        public static int Run(int n)
        {
            if (n == 0) return 0;
            else if (n == 1) return 1;
            else if(n == 2) return 2;
            else
            {
                int[] dp = new int[n + 1];
                dp[0] = 0;
                dp[1] = 1;
                dp[2] = 2;

                for (int i = 3; i <= n; i++)
                {
                    dp[i] = dp[i-1] + dp[i-2];
                }

                return dp[n];
            }
        }
    }
}
