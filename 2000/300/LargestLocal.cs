using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2373. 矩阵中的局部最大值
    /// </summary>
    internal class LargestLocal
    {
        //public int[][] LargestLocal(int[][] grid)
        //{
        //    int n = grid.Length;
        //    int[][] res = new int[n - 2][];
        //    for (int i = 0; i < n - 2; i++)
        //    {
        //        res[i] = new int[n - 2];
        //        for (int j = 0; j < n - 2; j++)
        //        {
        //            for (int x = i; x < i + 3; x++)
        //            {
        //                for (int y = j; y < j + 3; y++)
        //                {
        //                    res[i][j] = Math.Max(res[i][j], grid[x][y]);
        //                }
        //            }
        //        }
        //    }
        //    return res;
        //}

        public static int[][] Run(int[][] grid)
        {
            int len = grid.Length;

            Queue<int>[][] matrixs = new Queue<int>[len - 2][];

            for (int i = 0; i < len - 2; i++)
            {
                matrixs[i] = new Queue<int>[3];
                for (int j = 0; j < 3; j++)
                {
                    matrixs[i][j] = new Queue<int>(grid[i + j].Take(3));
                }
            }

            int[][] result = new int[len - 2][];
            for (int i = 0; i < len - 2; i++)
            {
                result[i] = new int[len - 2];
            }

            for (int i = 0; i < matrixs.Length; i++)
            {
                Queue<int>[] operMatrix = matrixs[i];
                result[i][0] = operMatrix.Max(v => v.Max());

                int pointer = 1;

                for (; pointer < len - 2; pointer++)
                {
                    int start = pointer + 2;

                    for (int j = 0; j < 3; j++)
                    {
                        var item = operMatrix[j];
                        item.Enqueue(grid[i + j][start]);
                        item.Dequeue();
                    }

                    result[i][pointer] = operMatrix.Max(v => v.Max());
                }
            }

            return result;
        }
    }
}
