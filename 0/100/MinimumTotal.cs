using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 120. 三角形最小路径和
    /// </summary>
    internal class MinimumTotal
    {
        public static int Run(IList<IList<int>> triangle)
        {
            int[][] dp = new int[triangle.Count][];
            dp[0] = new int[] { triangle[0][0] };

            for (int i = 1; i < triangle.Count; i++)
            {
                int rowLen = triangle[i].Count;
                dp[i] = new int[rowLen];
                dp[i][0] = dp[i - 1][0] + triangle[i][0];
                for (int j = 1; j < rowLen; j++)
                {
                    if (j < dp[i-1].Length)
                    {
                        dp[i][j] = Math.Min(dp[i - 1][j], dp[i - 1][j - 1])  + triangle[i][j];
                    }
                    else
                    {
                        dp[i][j] = dp[i - 1][j - 1] + triangle[i][j];
                    }
                }
            }

            return dp.Last().Min();
        }
    }
}
