using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 221. 最大正方形
    /// </summary>
    internal class MaximalSquare
    {
        public static int Run(char[][] matrix)
        {
            int x = matrix[0].Length;
            int y = matrix.Length;
            int[,] dp = new int[y, x];

            int result = int.MinValue;
            for (int i = 0; i < x; i++)
            {
                dp[0, i] = matrix[0][i] - 48;
                result = Math.Max(result, dp[0, i]);
            }

            for (int i = 0; i < y; i++)
            {
                dp[i, 0] = matrix[i][0] - 48;
                result = Math.Max(result, dp[i, 0]);
            }

            for (int i = 1; i < y; i++)
            {
                for (int j = 1; j < x; j++)
                {
                    if (matrix[i][j] == '0') dp[i, j] = 0;
                    else
                    {
                        int min = new int[] { dp[i-1, j], dp[i-1, j-1], dp[i, j-1] }.Min();
                        dp[i, j] = min + 1;
                    }
                    result =  Math.Max(result, dp[i, j]);
                }
            }

            return result * result;
        }
    }
}
