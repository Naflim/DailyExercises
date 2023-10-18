using HW.CAB.Helper.PipeNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 695. 岛屿的最大面积
    /// </summary>
    internal class MaxAreaOfIsland
    {
        public static int Run(int[][] grid)
        {
            HashSet<MaxAreaOfIslandNode> visited = new HashSet<MaxAreaOfIslandNode>();
            int result = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    var val = grid[i][j];
                    if (val == 1)
                    {
                        MaxAreaOfIslandNode node = new MaxAreaOfIslandNode(j, i, grid);
                        if (!visited.Contains(node))
                        {
                            Graph<MaxAreaOfIslandNode> island = new Graph<MaxAreaOfIslandNode>(node);
                            island.StartRetrieval();
                            result = Math.Max(result, island.Count());

                            visited.UnionWith(island);
                        }
                    }
                }
            }

            return result;
        }
    }


    public class MaxAreaOfIslandNode : IGraphNode<MaxAreaOfIslandNode>
    {

        private readonly int[][] _grid;

        public MaxAreaOfIslandNode(int x, int y, int[][] grid)
        {
            _grid = grid;
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public bool IsLand(int x, int y)
        {
            return _grid[y][x] == 1;
        }

        public MaxAreaOfIslandNode[] GetNextNodes()
        {
            List<MaxAreaOfIslandNode> nextNodes = new List<MaxAreaOfIslandNode>();
            if (X > 0)
            {
                if (IsLand(X - 1, Y))
                {
                    nextNodes.Add(new MaxAreaOfIslandNode(X - 1, Y, _grid));
                }
            }

            if (X < _grid[Y].Length - 1)
            {
                if (IsLand(X + 1, Y))
                {
                    nextNodes.Add(new MaxAreaOfIslandNode(X + 1, Y, _grid));
                }
            }

            if (Y > 0)
            {
                if (IsLand(X, Y - 1))
                {
                    nextNodes.Add(new MaxAreaOfIslandNode(X, Y - 1, _grid));
                }
            }

            if (Y < _grid.Length - 1)
            {
                if (IsLand(X, Y + 1))
                {
                    nextNodes.Add(new MaxAreaOfIslandNode(X, Y + 1, _grid));
                }
            }

            return nextNodes.ToArray();
        }

        public override bool Equals(object? obj)
        {
            if (obj is MaxAreaOfIslandNode node)
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
