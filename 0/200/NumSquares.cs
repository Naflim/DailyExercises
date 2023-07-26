using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 279. 完全平方数
    /// </summary>
    internal class NumSquares
    {
        public static int Run(int n)
        {
            int len = 1;
            while (len * len <= n)
            {
                len++;
            }

            int[,] dp = new int[len, n + 1];

            for (int i = 0; i <= n; i++)
                dp[1, i] = i;

            for (int i = 2; i < len; i++)
            {
                int iVal = (int)Math.Pow(i, 2);

                for (int j = 0; j <= n; j++)
                {
                    if(j < iVal)
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                    else
                    {
                        int count = j / iVal;
                        int remainder = j % iVal;
                        int newVal = count + dp[i - 1, remainder];
                        dp[i, j] = Math.Min(dp[i - 1, j], newVal);
                    }
                } 
            }

            return dp[len - 1, n];
        }
    }
}
