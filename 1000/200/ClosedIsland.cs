using HW.CAB.Helper.PipeNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 1254. 统计封闭岛屿的数目
    /// </summary>
    internal class ClosedIsland
    {
        public static int Run(int[][] grid)
        {
            HashSet<ClosedIslandNode> visited = new HashSet<ClosedIslandNode>();
            List<Graph<ClosedIslandNode>> enclaves = new List<Graph<ClosedIslandNode>>();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    var val = grid[i][j];
                    if (val == 0)
                    {
                        ClosedIslandNode node = new ClosedIslandNode(j, i, grid);
                        if (!visited.Contains(node))
                        {
                            Graph<ClosedIslandNode> island = new Graph<ClosedIslandNode>(node);
                            island.StartRetrieval();
                            if (island.All(n => n.X > 0 && n.X < grid[i].Length - 1 &&  n.Y > 0 && n.Y < grid.Length - 1))
                                enclaves.Add(island);

                            visited.UnionWith(island);
                        }
                    }
                }
            }

            return enclaves.Count;
        }
    }

    public class ClosedIslandNode : IGraphNode<ClosedIslandNode>
    {

        private readonly int[][] _grid;

        public ClosedIslandNode(int x, int y, int[][] grid)
        {
            _grid = grid;
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public virtual bool IsLand(int x, int y)
        {
            return _grid[y][x] == 0;
        }

        public ClosedIslandNode[] GetNextNodes()
        {
            List<ClosedIslandNode> nextNodes = new List<ClosedIslandNode>();
            if (X > 0)
            {
                if (IsLand(X - 1, Y))
                {
                    nextNodes.Add(new ClosedIslandNode(X - 1, Y, _grid));
                }
            }

            if (X < _grid[Y].Length - 1)
            {
                if (IsLand(X + 1, Y))
                {
                    nextNodes.Add(new ClosedIslandNode(X + 1, Y, _grid));
                }
            }

            if (Y > 0)
            {
                if (IsLand(X, Y - 1))
                {
                    nextNodes.Add(new ClosedIslandNode(X, Y - 1, _grid));
                }
            }

            if (Y < _grid.Length - 1)
            {
                if (IsLand(X, Y + 1))
                {
                    nextNodes.Add(new ClosedIslandNode(X, Y + 1, _grid));
                }
            }

            return nextNodes.ToArray();
        }

        public override bool Equals(object? obj)
        {
            if (obj is ClosedIslandNode node)
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
