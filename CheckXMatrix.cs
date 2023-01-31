using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2319. 判断矩阵是否是一个 X 矩阵
    /// </summary>
    internal class CheckXMatrix
    {
        public static bool Run(int[][] grid)
        {
            int len = grid.Length;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (j == i||j == len - i - 1)
                    {
                        if (grid[i][j] == 0) return false;
                    }
                    else
                    {
                        if (grid[i][j] != 0) return false;
                    }
                }
            }

            return true;
        }
    }
}
