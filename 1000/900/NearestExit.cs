using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1926. 迷宫中离入口最近的出口
    /// </summary>
    internal class NearestExit
    {
        public static int Run(char[][] maze, int[] entrance)
        {
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(entrance);
            Dictionary<int[], int[]> access = new Dictionary<int[], int[]>(new NearestExitComparer())
            {
                { entrance, Array.Empty<int>() }
            };
            int[] pointer = entrance;
            while (queue.Count > 0)
            {
                pointer = queue.Dequeue();

                if (pointer != entrance && IsTarget(pointer, maze))
                    break;

                int x = pointer[1];
                int y = pointer[0];

                void AddNewPointer(int[] newPointer) 
                {
                    if (!access.ContainsKey(newPointer) && CanWalk(newPointer, maze))
                    {
                        queue.Enqueue(newPointer);
                        access[newPointer] = pointer;
                    }
                }

                if (x > 0) 
                {
                    var newPointer = new int[] { y , x - 1 };
                    AddNewPointer(newPointer);
                }

                if (x < maze[0].Length - 1)
                {
                    var newPointer = new int[] { y , x + 1 };
                    AddNewPointer(newPointer);
                }

                if (y > 0)
                {
                    var newPointer = new int[] { y - 1, x };
                    AddNewPointer(newPointer);
                }

                if (y < maze.Length - 1)
                {
                    var newPointer = new int[] {y + 1, x };
                    AddNewPointer(newPointer);
                }
            }

            if(pointer == entrance || !IsTarget(pointer,maze)) 
            {
                return -1;
            }
            else
            {
                int count = 0;
                while(pointer != entrance) 
                {
                    pointer = access[pointer];
                    count++;
                }

                return count;
            }

        }

        public static bool IsTarget(int[] local, char[][] maze)
        {
            var y = local[0];
            var x = local[1];
            return (y == 0 || y == maze.Length - 1 || x == 0 || x == maze[0].Length - 1);
        }

        public static bool CanWalk(int[] local, char[][] maze)
        {
            return maze[local[0]][local[1]] == '.';
        }
    }

    public class NearestExitComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[]? x, int[]? y)
        {
            return x?.SequenceEqual(y) ?? false;
        }

        public int GetHashCode(int[] obj)
        {
            return string.Join(",", obj).GetHashCode();
        }
    }
}
