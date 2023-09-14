using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1466. 重新规划路线
    /// </summary>
    internal class MinReorder
    {
        public static int Run(int n, int[][] connections)
        {
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = -1;
                }
            }

            for (int i = 0; i < connections.Length; i++)
            {
                var connection = connections[i];
                matrix[connection[0], connection[1]] = i;
                matrix[connection[1], connection[0]] = i;
            }

            return BFS(n, 0, matrix, connections, new HashSet<int>());
        }

        public static int Run2(int n, int[][] connections)
        {
            List<int[]>[] table = new List<int[]>[n];
            for (int i = 0; i < n; i++)
            {
                table[i] = new List<int[]>();
            }

            for (int i = 0; i < connections.Length; i++)
            {
                var connection = connections[i];
                table[connection[0]].Add(new int[] { connection[1] , i });
                table[connection[1]].Add(new int[] { connection[0], i });
            }

            return DFS(n, 0, table, connections, new HashSet<int>());
        }

        private static int DFS(int n, int node, List<int[]>[] table, int[][] connections, HashSet<int> accessed)
        {
            var nextNodes = table[node].Where(v => !accessed.Contains(v[0]));
            accessed.Add(node);
            int result = 0;

            foreach (var nextNode in nextNodes)
            {
                var connection = connections[nextNode[1]];
                if (connection[0] == node &&  connection[1] == nextNode[0])
                    result++;

                result += DFS(n, nextNode[0], table, connections, accessed);
            }

            return result;
        }

        private static int DFS(int n, int node, int[,] matrix, int[][] connections, HashSet<int> accessed)
        {
            List<int> nextNodes = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if (!accessed.Contains(i) && matrix[node, i] != -1)
                {
                    nextNodes.Add(i);
                }
            }

            accessed.Add(node);
            int result = 0;

            foreach (var nextNode in nextNodes)
            {
                var connection = connections[matrix[node, nextNode]];
                if (connection[0] == node &&  connection[1] == nextNode)
                    result++;

                result += DFS(n, nextNode, matrix, connections, accessed);
            }

            return result;
        }

        private static int BFS(int n, int origin, int[,] matrix, int[][] connections, HashSet<int> accessed)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(origin);

            int result = 0;
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                for (int i = 0; i < n; i++)
                {
                    if (!accessed.Contains(i) && matrix[node, i] != -1)
                    {
                        var connection = connections[matrix[node, i]];
                        if (connection[0] == node &&  connection[1] == i)
                            result++;

                        stack.Push(i);
                    }
                }

                accessed.Add(node);
            }

            return result;
        }
    }
}
