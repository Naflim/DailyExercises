using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 463. 岛屿的周长
    /// </summary>
    internal class IslandPerimeter
    {
        public static int Run(int[][] grid)
        {
            int result = 0;

            int n = grid.Length;
            int m = grid[0].Length;
            for (int i = 0; i < n; i++) 
            {
                for(int j = 0; j < m; j++)
                {
                    if (grid[i][j] != 1)
                        continue;

                    int count = 0;
                    int top = i - 1;
                    int bottom = i + 1;
                    int left = j - 1;
                    int right = j + 1;

                    if(top >= 0 && grid[top][j] == 1)
                        count++;

                    if (bottom < n && grid[bottom][j] == 1)
                        count++;

                    if (left >= 0 && grid[i][left] == 1)
                        count++;

                    if (right < m && grid[i][right] == 1)
                        count++;

                    result += 4 - count;
                }
            }

            return result;
        }
    }
}
