using HW.CAB.Helper.PipeNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    [Flags]
    public enum Ocean
    {
        Unknown = 0x00,
        Pacific = 0x01,
        Atlantic = 0x02,
    }

    /// <summary>
    /// 417. 太平洋大西洋水流问题
    /// </summary>
    internal class PacificAtlantic
    {
        public static IList<IList<int>> Run(int[][] heights)
        {
            PriorityQueue<int[], int> priorityQueue = new PriorityQueue<int[], int>();
            int m = heights.Length;
            int n = heights[0].Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    priorityQueue.Enqueue(new int[] { i, j }, heights[i][j]);
                }
            }

            NearestExitComparer comparer = new NearestExitComparer();
            Dictionary<int[], Ocean> map = new Dictionary<int[], Ocean>(comparer);

            IList<IList<int>> result = new List<IList<int>>();

            Ocean GetOceanType(int[] pointer)
            {
                Ocean type = Ocean.Unknown;
                if (pointer[0] == 0 || pointer[1] == 0)
                    type |= Ocean.Pacific;

                if (pointer[0] == m - 1 || pointer[1] == n - 1)
                    type |= Ocean.Atlantic;

                return type;
            }

            bool CanWalk(int[] prev,int[] now)
            {
                return heights[now[0]][now[1]] <= heights[prev[0]][prev[1]];
            }

            while (priorityQueue.Count > 0)
            {
                var location = priorityQueue.Dequeue();
                map[location] = Ocean.Unknown;
                Queue<int[]> queue = new Queue<int[]>();
                queue.Enqueue(location);    
                HashSet<int[]> visited = new HashSet<int[]>(comparer);
                while(queue.Count > 0) 
                {
                    var pointer = queue.Dequeue();

                    if (map.ContainsKey(pointer) && !comparer.Equals(pointer,location))
                    {
                        map[location] |= map[pointer];
                        continue;
                    }

                    var type = GetOceanType(pointer);
                    if (type != Ocean.Unknown)
                        map[location] |= type;

                    if (map[location].HasFlag(Ocean.Pacific) && map[location].HasFlag(Ocean.Atlantic))
                        break;

                    int x = pointer[1];
                    int y = pointer[0];

                    void AddNewPointer(int[] newPointer)
                    {
                        if (!visited.Contains(newPointer) && CanWalk(pointer, newPointer))
                        {
                            queue.Enqueue(newPointer);
                            visited.Add(newPointer);
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

                if (map[location].HasFlag(Ocean.Pacific) && map[location].HasFlag(Ocean.Atlantic))
                {
                    result.Add(location);
                }
            }

            return result;
        }
    }
}
