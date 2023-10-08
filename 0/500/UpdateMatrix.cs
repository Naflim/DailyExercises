using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 542. 01 矩阵
    /// </summary>
    internal class UpdateMatrix
    {
        public static int[][] Run(int[][] mat)
        {
            int m = mat.Length;
            int n = mat[0].Length;
            Dictionary<int[], int[]> trails = new Dictionary<int[], int[]>(new NearestExitComparer());
            Queue<int[]> queue = new Queue<int[]>();
            int[][] result = new int[m][];

            for (int i = 0; i < m; i++)
            {
                result[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        var pointer = new int[] { i, j };
                        trails[pointer] = Array.Empty<int>();
                        queue.Enqueue(pointer);
                    }
                }
            }

            while (queue.Count > 0)
            {
                var pointer = queue.Dequeue();

                var trail = trails[pointer];
                if (trail.Length != 0)
                {
                    result[pointer[0]][pointer[1]] = result[trail[0]][trail[1]] + 1;
                }

                int x = pointer[1];
                int y = pointer[0];

                void AddNewPointer(int[] newPointer)
                {
                    if (!trails.ContainsKey(newPointer))
                    {
                        queue.Enqueue(newPointer);
                        trails[newPointer] = pointer;
                    }
                }

                if (x > 0)
                {
                    var newPointer = new int[] { y, x - 1 };
                    AddNewPointer(newPointer);
                }

                if (x < n - 1)
                {
                    var newPointer = new int[] { y, x + 1 };
                    AddNewPointer(newPointer);
                }

                if (y > 0)
                {
                    var newPointer = new int[] { y - 1, x };
                    AddNewPointer(newPointer);
                }

                if (y < m - 1)
                {
                    var newPointer = new int[] { y + 1, x };
                    AddNewPointer(newPointer);
                }
            }

            return result;
        }
    }
}
