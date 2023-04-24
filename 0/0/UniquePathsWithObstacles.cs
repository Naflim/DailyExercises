using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 63. 不同路径 II
    /// </summary>
    internal class UniquePathsWithObstacles
    {
        public static int Run(int[][] obstacleGrid)
        {
            if (obstacleGrid[0][0] == 1) return 0;

            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;
            int[,] dp = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                if (obstacleGrid[i][0] == 0) dp[i, 0] = 1;
                else break;
            }

            for (int i = 0; i < n; i++)
            {
                if (obstacleGrid[0][i] == 0) dp[0, i] = 1;
                else break;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = obstacleGrid[i][j] == 0 ? dp[i - 1, j] + dp[i, j-1] : 0;
                }
            }

            return dp[m - 1, n - 1];
        }
    }
}
