using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 931. 下降路径最小和
    /// </summary>
    internal class MinFallingPathSum
    {
        public static int Run(int[][] matrix)
        {
            int n = matrix.Length;

            int[][] dp = new int[n][];
            dp[0] = new int[n];
            for (int i = 0; i < n; i++) 
            {
                dp[0][i] = matrix[0][i];
            }

            for (int i = 1; i < n; i++) 
            {
                dp[i] = new int[n];
                int[] possibility = new int[] { int.MaxValue, int.MaxValue, int.MaxValue };

                for (int j = 0; j < n; j++)
                {
                    if (j != 0) possibility[0] = dp[i - 1][j - 1];
                    if(j != n - 1) possibility[2] = dp[i - 1][j + 1];
                    possibility[1] = dp[i - 1][j];

                    dp[i][j] = possibility.Min() + matrix[i][j];
                }
            }

            return dp.Last().Min();
        }
    }
}
