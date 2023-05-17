using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    internal class MinDifficulty
    {
        public static int Run(int[] jobDifficulty, int d)
        {
            if (jobDifficulty.Length < d) return -1;
            int jobLen = jobDifficulty.Length;

            int[][] dp = new int[d][];
            dp[0] = new int[jobLen];
            dp[0][0] = jobDifficulty[0];

            for (int i = 1; i < jobLen; i++)
            {
                dp[0][i] = Math.Max(dp[0][i-1], jobDifficulty[i]);
            }

            for (int i = 1; i < d; i++) 
            {
                dp[i] = new int[jobLen - i];
                dp[i][0] = jobDifficulty[..(i + 1)].Sum();
                for (int j = 1; j < dp[i].Length; j++) 
                {
                    dp[i][j] = dp[i - 1][j - 1] + jobDifficulty[j+i];
                }
            }

            return dp[^1][^1];
        }
    }
}
