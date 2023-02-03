using DailyExercises.Helper;
using DailyExercises.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    internal class ShortestAlternatingPaths
    {
        [Flags]
        enum EdgeColor
        {
            None = 0,
            Red = 0x01,
            Blue = 0x04,
        }

        public static int[] Run(int n, int[][] redEdges, int[][] blueEdges)
        {
            Dictionary<int, Dictionary<int, EdgeColor>> vertexs = new();

            foreach(var edge in redEdges) 
            {
                if (!vertexs.ContainsKey(edge[0]))
                {
                    vertexs[edge[0]] = new()
                    {
                        { edge[1],EdgeColor.Red }
                    };
                }
                else vertexs[edge[0]][edge[1]] = EdgeColor.Red;

                if (!vertexs.ContainsKey(edge[1]))
                {
                    vertexs[edge[1]] = new();
                }
            }

            foreach (var edge in blueEdges)
            {
                if (!vertexs.ContainsKey(edge[0]))
                {
                    vertexs[edge[0]] = new()
                    {
                        { edge[1],EdgeColor.Blue }
                    };
                }
                else
                {
                    var vertex = vertexs[edge[0]];
                    if (vertex.ContainsKey(edge[1])) vertex[edge[1]] |= EdgeColor.Blue;
                    else vertex[edge[1]] = EdgeColor.Blue;
                }

                if (!vertexs.ContainsKey(edge[1]))
                {
                    vertexs[edge[1]] = new();
                }
            }

            AdjacencyList<int> list = new(vertexs.Keys);

            foreach (var edge in redEdges)
            {
                list.DirectedEdge(edge[0], edge[1]);
            }

            foreach (var edge in blueEdges)
            {
                list.DirectedEdge(edge[0], edge[1]);
            }

            List<List<int>> paths = new();

            for (int i = 0; i < n; i++)
            {
                paths.Add(ToolUtils.BFS(list.GetVertex(0), i, (path, next) =>
                {
                    if (path.Length < 2) return true;
                    var prev = path[^2];
                    var now = path.Last();
                    var prevType = vertexs[prev][now];

                    return prevType == EdgeColor.Red ? vertexs[now][next].HasFlag(EdgeColor.Blue) : vertexs[now][next].HasFlag(EdgeColor.Red);
                    //return prevType != vertexs[now][next];
                }));
            }

            return paths.Select(v => 
            {
                if (v.Count == 0) return -1;
                else return v.Count - 1;
            }).ToArray();
        }
    }
}
