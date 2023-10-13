using HW.CAB.Helper.PipeNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 200. 岛屿数量
    /// </summary>
    internal class NumIslands
    {
        public static int Run(char[][] grid)
        {
            List<Graph<NumIslandsNode>> graphs = new List<Graph<NumIslandsNode>>();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] != '1')
                        continue;

                    NumIslandsNode node = new NumIslandsNode(j, i, grid);
                    if (graphs.Any(g => g.Contains(node)))
                        continue;

                    Graph<NumIslandsNode> graph = new Graph<NumIslandsNode>(node);
                    graph.StartRetrieval();
                    graphs.Add(graph);
                }
            }

            return graphs.Count;
        }

        public static int Run2(char[][] grid)
        {
            HashSet<NumIslandsNode> visited = new HashSet<NumIslandsNode>();
            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] != '1')
                        continue;

                    NumIslandsNode node = new NumIslandsNode(j, i, grid);
                    if (visited.Contains(node))
                        continue;

                    Graph<NumIslandsNode> graph = new Graph<NumIslandsNode>(node);
                    graph.StartRetrieval();
                    visited.UnionWith(graph);
                    count++;
                }
            }

            return count;
        }
    }

    public class NumIslandsNode : IGraphNode<NumIslandsNode>
    {
        private readonly char[][] _grid;

        public NumIslandsNode(int x, int y, char[][] grid)
        {
            _grid = grid;
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public bool IsLand(int x, int y)
        {
            return _grid[y][x] == '1';
        }

        public NumIslandsNode[] GetNextNodes()
        {
            List<NumIslandsNode> nextNodes = new List<NumIslandsNode>();
            if (X > 0)
            {
                if (IsLand(X - 1, Y))
                {
                    nextNodes.Add(new NumIslandsNode(X - 1, Y, _grid));
                }
            }

            if (X < _grid[Y].Length - 1)
            {
                if (IsLand(X + 1, Y))
                {
                    nextNodes.Add(new NumIslandsNode(X + 1, Y, _grid));
                }
            }

            if (Y > 0)
            {
                if (IsLand(X, Y - 1))
                {
                    nextNodes.Add(new NumIslandsNode(X, Y - 1, _grid));
                }
            }

            if (Y < _grid.Length - 1)
            {
                if (IsLand(X, Y + 1))
                {
                    nextNodes.Add(new NumIslandsNode(X, Y + 1, _grid));
                }
            }

            return nextNodes.ToArray();
        }

        public override bool Equals(object? obj)
        {
            if (obj is NumIslandsNode node)
            {
                return X == node.X && Y == node.Y;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return $"{X},{Y}".GetHashCode();
        }
    }
}
