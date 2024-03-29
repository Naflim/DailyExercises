﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1137. 第 N 个泰波那契数
    /// </summary>
    public class Tribonacci
    {
        public static int Run(int n)
        {
            if (n == 0) return 0;
            else if (n == 1) return 1;
            else if (n == 2) return 1;
            else
            {
                int[] dp = new int[n + 1];
                dp[0] = 0;
                dp[1] = 1;
                dp[2] = 1;

                for (int i = 3; i <= n; i++)
                {
                    dp[i] = dp[i-1] + dp[i-2] + dp[i - 3];
                }

                return dp[n];
            }
        }
    }
}
