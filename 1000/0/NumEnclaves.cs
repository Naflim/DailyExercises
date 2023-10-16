using HW.CAB.Helper.PipeNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1020. 飞地的数量
    /// </summary>
    internal class NumEnclaves
    {
        public static int Run(int[][] grid)
        {
            List<Graph<NumIslandsNode>> islands = new List<Graph<NumIslandsNode>>();
            List<Graph<NumIslandsNode>> enclaves = new List<Graph<NumIslandsNode>>();
            var map = grid.Select(v => v.Select(n => (char)(n + 48)).ToArray()).ToArray();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    var val = grid[i][j];
                    if(val == 1) 
                    {
                        NumIslandsNode node = new NumIslandsNode(j, i, map);
                        if(!islands.Any(g => g.Contains(node)))
                        {
                            Graph<NumIslandsNode> island = new Graph<NumIslandsNode>(node);
                            island.StartRetrieval();
                            if(island.All(n => n.X > 0 && n.X < grid[i].Length - 1 &&  n.Y > 0 && n.Y < grid.Length - 1))
                                enclaves.Add(island);

                            islands.Add(island);
                        }
                    }
                }
            }

            return enclaves.Sum(g => g.Count());
        }

        public static int Run2(int[][] grid)
        {
            HashSet<NumIslandsNode> visited = new HashSet<NumIslandsNode>();
            List<Graph<NumIslandsNode>> enclaves = new List<Graph<NumIslandsNode>>();
            var map = grid.Select(v => v.Select(n => (char)(n + 48)).ToArray()).ToArray();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    var val = grid[i][j];
                    if (val == 1)
                    {
                        NumIslandsNode node = new NumIslandsNode(j, i, map);
                        if (!visited.Contains(node))
                        {
                            Graph<NumIslandsNode> island = new Graph<NumIslandsNode>(node);
                            island.StartRetrieval();
                            if (island.All(n => n.X > 0 && n.X < grid[i].Length - 1 &&  n.Y > 0 && n.Y < grid.Length - 1))
                                enclaves.Add(island);

                            visited.UnionWith(island);
                        }
                    }
                }
            }

            return enclaves.Sum(g => g.Count());
        }
    }
}
