using HW.CAB.Helper.PipeNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 547. 省份数量
    /// </summary>
    internal class FindCircleNum
    {
        public static int Run(int[][] isConnected)
        {
            List<Graph<FindCircleNumNode>> maps = new List<Graph<FindCircleNumNode>>();
            int n = isConnected.Length;
            for (int i = 0; i < n; i++)
            {
                var node = new FindCircleNumNode(isConnected, i);
                if(!maps.Any(map => map.Contains(node)))
                {
                    Graph<FindCircleNumNode> graph = new Graph<FindCircleNumNode>(node);
                    graph.StartRetrieval();
                    maps.Add(graph);
                }
            }

            return maps.Count;  
        }
    }

    public class FindCircleNumNode : IGraphNode<FindCircleNumNode>
    {
        private int[][] isConnected;

        public FindCircleNumNode(int[][] isConnected, int value)
        {
            this.isConnected = isConnected;
            Value = value;
        }

        public int Value { get; }

        public FindCircleNumNode[] GetNextNodes()
        {
            var values = isConnected[Value];
            List<FindCircleNumNode> result = new List<FindCircleNumNode>();
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == 1)
                {
                    result.Add(new FindCircleNumNode(isConnected, i));
                }
            }

            return result.ToArray();
        }

        public override bool Equals(object? obj)
        {
            if (obj is FindCircleNumNode node)
                return node.Value == Value;

            return false;
        }

        public override int GetHashCode()
        {
            return Value;
        }
    }
}
