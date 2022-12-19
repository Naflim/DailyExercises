using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DailyExercises
{

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
