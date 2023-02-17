using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1139. 最大的以 1 为边界的正方形
    /// </summary>
    internal class Largest1BorderedSquare
    {
        public static int Run(int[][] grid)
        {
            int rowLen = grid.Length;
            int cellLen = grid[0].Length;
            int[][] qbHorizontal = new int[rowLen][];
            int[][] qbVertical = new int[rowLen][];

            for (int i = 0; i < rowLen; i++)
            {
                var row = grid[i];
                qbHorizontal[i] = new int[cellLen];
                qbVertical[i] = new int[cellLen];
                for (int j = 0; j < cellLen; j++)
                {
                    if (row[j] == 1)
                    {
                        if (j == 0) qbHorizontal[i][j] = 1;
                        else qbHorizontal[i][j] = qbHorizontal[i][j - 1] + 1;

                        if (i == 0) qbVertical[i][j] = 1;
                        else qbVertical[i][j] = qbVertical[i - 1][j] + 1;
                    }
                    else
                    {
                        qbHorizontal[i][j] = 0;
                        qbVertical[i][j] = 0;
                    }
                }
            }

            int GetLargestSquare(int i, int j, int side)
            {
                if (qbHorizontal[i - side + 1][j] >= side && qbVertical[i][j - side + 1] >= side) return side * side;
                else return GetLargestSquare(i, j, --side);
            }

            int result = 0;
            for (int i = rowLen - 1; i >= 0; i--)
            {
                for (int j = cellLen - 1; j >= 0; j--)
                {
                    int side = Math.Min(qbHorizontal[i][j], qbVertical[i][j]);
                    if (side == 0) continue;
                    else result = Math.Max(result, GetLargestSquare(i, j, side));
                }
            }

            return result;
        }
    }
}
