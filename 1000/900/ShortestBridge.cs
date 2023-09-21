using HW.CAB.Helper.PipeNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 934. 最短的桥
    /// </summary>
    internal class ShortestBridge
    {
        public static int Run(int[][] grid)
        {
            int len = grid.Length;
            int[] def = new int[] { -1, -1 };
            int[] start = def;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        start = new int[] { i, j };
                        break;
                    }
                }

                if (!start.SequenceEqual(def))
                    break;
            }

            if (start.SequenceEqual(def))
                return -1;

            ShortestBridgeNode origin = new ShortestBridgeNode(start[1], start[0],grid);
            Graph<ShortestBridgeNode> graph = new Graph<ShortestBridgeNode>(origin);
            graph.StartRetrieval();

            var coastline = graph.Where(n => n.GetNearbyLocation().Any(v => !v.IsLand()));

            HashSet<ShortestBridgeNode> access = new HashSet<ShortestBridgeNode>(graph);
            Queue<ShortestBridgeNode> queue = new Queue<ShortestBridgeNode>(coastline);
            Dictionary<ShortestBridgeNode, ShortestBridgeNode> pathMap = new();

            ShortestBridgeNode? pointer = null;

            while (queue.Count > 0)
            {
                pointer = queue.Dequeue();

                if (!graph.Contains(pointer) && pointer.IsLand())
                    break;

                var nextNodes = pointer.GetNearbyLocation().Where(n => !access.Contains(n));
                foreach(var nextNode in nextNodes)
                {
                    queue.Enqueue(nextNode);
                    access.Add(nextNode);
                    pathMap.Add(nextNode, pointer);
                }
            }

            if (pointer == null || !pointer.IsLand())
                return -1;

            int result = -1;
            while (!graph.Contains(pointer))
            {
                result++;
                pointer = pathMap[pointer];
            }

            return result;
        }
    }

    public class ShortestBridgeNode : IGraphNode<ShortestBridgeNode>
    {
        private readonly int[][] _grid;
        private readonly int _length;

        public ShortestBridgeNode(int x, int y, int[][] grid)
        {
            _grid = grid;
            _length = grid.Length;
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public bool IsLand(int x, int y)
        {
            return _grid[y][x] == 1;
        }

        public bool IsLand() 
        {
            return _grid[Y][X] == 1;
        }

        public ShortestBridgeNode[] GetNearbyLocation()
        {
            List<ShortestBridgeNode> nextNodes = new List<ShortestBridgeNode>();
            if (X > 0)
            {
                nextNodes.Add(new ShortestBridgeNode(X - 1, Y, _grid));
            }

            if (X < _length - 1)
            {
                nextNodes.Add(new ShortestBridgeNode(X + 1, Y, _grid));
            }

            if (Y > 0)
            {
                nextNodes.Add(new ShortestBridgeNode(X, Y - 1, _grid));
            }

            if (Y < _length - 1)
            {
                nextNodes.Add(new ShortestBridgeNode(X, Y + 1, _grid));
            }

            return nextNodes.ToArray();
        }

        public ShortestBridgeNode[] GetNextNodes()
        {
            List<ShortestBridgeNode> nextNodes = new List<ShortestBridgeNode>();
            if (X > 0)
            {
                if (IsLand(X - 1, Y)) 
                {
                    nextNodes.Add(new ShortestBridgeNode(X - 1, Y, _grid));
                }
            }

            if (X < _length - 1)
            {
                if (IsLand(X + 1, Y))
                {
                    nextNodes.Add(new ShortestBridgeNode(X + 1, Y, _grid));
                }
            }

            if (Y > 0)
            {
                if (IsLand(X, Y - 1))
                {
                    nextNodes.Add(new ShortestBridgeNode(X, Y - 1, _grid));
                }
            }

            if (Y < _length - 1)
            {
                if (IsLand(X, Y + 1))
                {
                    nextNodes.Add(new ShortestBridgeNode(X, Y + 1, _grid));
                }
            }

            return nextNodes.ToArray();
        }

        public override bool Equals(object? obj)
        {
            if(obj is ShortestBridgeNode node) 
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
