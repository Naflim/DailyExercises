using HW.CAB.Helper.PipeNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1091. 二进制矩阵中的最短路径
    /// </summary>
    internal class ShortestPathBinaryMatrix
    {
        public static int Run(int[][] grid)
        {
            int n = grid.Length;
            int[] entrance = new int[] { 0, 0 };
            int[] export = new int[] { n - 1, n - 1 };

            if (grid[entrance[0]][entrance[1]] != 0 || grid[export[0]][export[1]] != 0)
                return -1;

            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(entrance);
            NearestExitComparer comparer = new NearestExitComparer();
            Dictionary<int[], int[]> access = new Dictionary<int[], int[]>(comparer)
            {
                { entrance, Array.Empty<int>() }
            };

            int[] pointer = entrance;
            while (queue.Count > 0)
            {
                pointer = queue.Dequeue();

                if (comparer.Equals(pointer, export))
                    break;

                int x = pointer[1];
                int y = pointer[0];

                void AddNewPointer(int[] newPointer)
                {
                    if (!access.ContainsKey(newPointer) && grid[newPointer[0]][newPointer[1]] == 0)
                    {
                        queue.Enqueue(newPointer);
                        access[newPointer] = pointer;
                    }
                }

                bool canLeftMove = x > 0;
                bool canRightMove = x < n - 1;
                bool canTopMove = y > 0;
                bool canBottomMove = y < n - 1;

                if (canLeftMove) 
                {
                    var newPointer = new int[] { y, x - 1 };
                    AddNewPointer(newPointer);
                }

                if (canRightMove)
                {
                    var newPointer = new int[] { y, x + 1 };
                    AddNewPointer(newPointer);
                }

                if (canTopMove)
                {
                    var newPointer = new int[] { y - 1, x };
                    AddNewPointer(newPointer);
                }

                if (canBottomMove)
                {
                    var newPointer = new int[] { y + 1, x };
                    AddNewPointer(newPointer);
                }

                if (canLeftMove && canTopMove)
                {
                    var newPointer = new int[] { y - 1, x - 1 };
                    AddNewPointer(newPointer);
                }
                if (canLeftMove && canBottomMove)
                {
                    var newPointer = new int[] { y + 1, x - 1 };
                    AddNewPointer(newPointer);
                }

                if (canRightMove && canTopMove)
                {
                    var newPointer = new int[] { y - 1, x + 1 };
                    AddNewPointer(newPointer);
                }

                if (canRightMove && canBottomMove)
                {
                    var newPointer = new int[] { y + 1, x + 1 };
                    AddNewPointer(newPointer);
                }
            }

            if (!comparer.Equals(pointer, export))
            {
                return -1;
            }
            else
            {
                int count = 1;
                while (pointer != entrance)
                {
                    pointer = access[pointer];
                    count++;
                }

                return count;
            }

        }
    }
}
