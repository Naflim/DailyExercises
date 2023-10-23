
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1557. 可以到达所有点的最少点数目
    /// </summary>
    internal class FindSmallestSetOfVertices
    {
        public static IList<int> Run(int n, IList<IList<int>> edges)
        {
            HashSet<int> hasIndegreeNodes = new HashSet<int>();
            foreach (var edge in edges) 
            {
                hasIndegreeNodes.Add(edge[1]);
            }

            List<int> result = new List<int>(); 
            for (int i = 0; i < n; i++)
            {
                if(!hasIndegreeNodes.Contains(i))
                    result.Add(i);
            }

            return result;
        }

        public static bool[,] GetAdjacencyMatrix(IList<IList<int>> edges, int n) 
        {
            bool[,] matrix = new bool[n, n];

            for (int i = 0; i < edges.Count; i++)
            {
                matrix[edges[i][0], edges[i][1]] = true;
            }

            return matrix;
        }
    }
}
