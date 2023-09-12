using DailyExercises.Helper.Graph;
using DailyExercises.Utils;
using HW.CAB.Helper.PipeNetwork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1129. 颜色交替的最短路径
    /// </summary>
    internal class ShortestAlternatingPaths
    {
        [Flags]
        enum EdgeColor
        {
            None = 0x01,
            Red = 0x02,
            Blue = 0x04,
        }

        public static int[] Run(int n, int[][] redEdges, int[][] blueEdges)
        {
            int[] result = new int[n];
            for (int i = 1; i < n; i++)
            {
                var pathA = BFS(i, redEdges, blueEdges, EdgeColor.Red);
                var pathB = BFS(i, redEdges, blueEdges, EdgeColor.Blue);

                int val = int.MaxValue;

                if (pathA.Length > 0)
                    val = Math.Min(val, pathA.Length - 1);

                if (pathB.Length > 0)
                    val = Math.Min(val, pathB.Length - 1);

                result[i] = val == int.MaxValue ? -1 : val;
            }

            return result;
        }

        private static int[] BFS(int n, int[][] redEdges, int[][] blueEdges, EdgeColor color)
        {
            List<LinkedList<int>> paths = new List<LinkedList<int>>();
            LinkedList<int> head = new LinkedList<int>();
            head.AddLast(0);
            paths.Add(head);
            Dictionary<int, EdgeColor> accessed = new Dictionary<int, EdgeColor>();
            while (paths.Count > 0)
            {
                var cache = paths.ToArray();
                paths.Clear();

                foreach (var item in cache)
                {
                    var node = item.Last.Value;

                    if (accessed.ContainsKey(node))
                        accessed[node] |= InverseColor(color);
                    else
                        accessed[node] = InverseColor(color);

                    if (node == n)
                    {
                        return item.ToArray();
                    }

                    int[] connectivity;
                    if (color == EdgeColor.Red)
                    {
                        connectivity = GetEdges(node, redEdges);
                    }
                    else
                    {
                        connectivity = GetEdges(node, blueEdges);
                    }

                    foreach (var next in connectivity)
                    {
                        if (accessed.ContainsKey(next) && accessed[next].HasFlag(color))
                            continue;

                        LinkedList<int> newPath = new LinkedList<int>(item);
                        newPath.AddLast(next);
                        paths.Add(newPath);
                    }
                }

                color = InverseColor(color);
            }

            return Array.Empty<int>();
        }

        private static int[] GetEdges(int n, int[][] edges)
        {
            return edges.Where(edge => edge[0] == n).Select(edge => edge[1]).ToArray();
        }

        private static EdgeColor InverseColor(EdgeColor color)
        {
            if (color == EdgeColor.Red)
                return EdgeColor.Blue;

            if (color == EdgeColor.Blue)
                return EdgeColor.Red;

            return color;
        }
    }

}
