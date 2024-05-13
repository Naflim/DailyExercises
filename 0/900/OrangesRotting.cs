using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 994. 腐烂的橘子
    /// </summary>
    internal class OrangesRotting
    {
        public static int Run(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            int orangesCount = 0;
            int rottingsCount = 0;
            List<(int m, int n)> rottings = new List<(int m, int n)>();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] != 0)
                    {
                        orangesCount++;
                        if (grid[i][j] == 2)
                        {
                            rottings.Add((i, j));
                        }
                    }
                }
            }

            int timeCount = 0;
            while (rottings.Any())
            {
                List<(int, int)> newRottings = new List<(int, int)>();

                for (int i = 0; i < rottings.Count; i++)
                {
                    var rotting = rottings[i];
                    var rm = rotting.m;
                    var rn = rotting.n;
                    if(rm > 0 && grid[rm - 1][rn] == 1)
                    {
                        int newRm = rm - 1;
                        newRottings.Add((newRm, rn));
                        grid[newRm][rn] = 2;
                    }

                    if (rm < m - 1 && grid[rm + 1][rn] == 1)
                    {
                        int newRm = rm + 1;
                        newRottings.Add((newRm, rn));
                        grid[newRm][rn] = 2;
                    }

                    if (rn > 0 && grid[rm][rn - 1] == 1)
                    {
                        int newRn = rn - 1;
                        newRottings.Add((rm, newRn));
                        grid[rm][newRn] = 2;
                    }

                    if (rn < n - 1 && grid[rm][rn + 1] == 1)
                    {
                        int newRn = rn + 1;
                        newRottings.Add((rm, newRn));
                        grid[rm][newRn] = 2;
                    }
                }

                timeCount++;
                rottingsCount += rottings.Count;
                rottings = newRottings;
            }

            if(orangesCount == rottingsCount)
            {
                if (timeCount > 0)
                    timeCount--;

                return timeCount;
            }
            else
            {
                return -1;
            }
        }
    }
}
