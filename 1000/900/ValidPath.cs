using DailyExercises.Helper.Graph;
using DailyExercises.Utils;

namespace DailyExercises
{
    /// <summary>
    /// 1971. 寻找图中是否存在路径
    /// </summary>
    internal class ValidPath
    {
        public static bool Run(int n, int[][] edges, int source, int destination)
        {
            AdjacencyList<int> list = new();
            for (int i=0; i<n; i++) 
            {
                list.AddVertex(i);
            }

            for(int i=0;i<edges.Length; i++) 
            {
                list.AddEdge(edges[i][0], edges[i][1]);
            }

            var path = ToolUtils.BFS(list.GetVertex(source), destination);

            return path.Count > 0;
        }
    }


}
