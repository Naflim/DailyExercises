using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 3963. 构造恰好一条路径的网格
    /// </summary>
    internal class CreateGrid
    {
        public static string[] Run(int m, int n)
        {
            char[][] grid = new char[m][];

            for (int i = 0; i < m; i++)
            {
                grid[i] = new char[n];
                for (int j = 0; j < n; j++)
                {
                    grid[i][j] = '#';
                }
            }

            for (int i = 0; i < m; i++)
            {
                grid[i][0] = '.';
            }

            for (int i = 0; i < n; i++)
            {
                grid[m - 1][i] = '.';
            }

            string[] result = new string[m];

            for (int i = 0; i < m; i++)
            {
                result[i] = new string(grid[i]);
            }

            return result;
        }
    }
}
