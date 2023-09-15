using HW.CAB.Helper.PipeNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 797. 所有可能的路径
    /// </summary>
    internal class AllPathsSourceTarget
    {
        public static IList<IList<int>> Run(int[][] graph)
        {
            AllPathsSourceTargetNode start = new AllPathsSourceTargetNode(0, graph);
            AllPathsSourceTargetNode end = new AllPathsSourceTargetNode(graph.Length - 1, graph);
            Graph<AllPathsSourceTargetNode> g = new Graph<AllPathsSourceTargetNode>(start);
            g.StartRetrieval();
            if (!g.Contains(end)) 
                return new List<IList<int>>();

            var paths = g.GetAllPathsByDfs(start, end);

            return paths.Select(p => p.Select(n => n.Value).ToArray()).ToArray();
        } 
    }

    public class AllPathsSourceTargetNode : IGraphNode<AllPathsSourceTargetNode>
    {
        private int[][] _graph;

        public AllPathsSourceTargetNode(int value, int[][] graph)
        {
            Value = value;
            _graph = graph;
        }

        public int Value { get; }

        public AllPathsSourceTargetNode[] GetNextNodes()
        {
            int len = _graph[Value].Length;

            AllPathsSourceTargetNode[] nextNodes = new AllPathsSourceTargetNode[len];

            for (int i = 0; i < len; i++)
            {
                nextNodes[i] = new AllPathsSourceTargetNode(_graph[Value][i], _graph);
            }

            return nextNodes;
        }

        public override bool Equals(object? obj)
        {
            if (obj is AllPathsSourceTargetNode node)
            {
                return node.Value == Value;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Value;
        }
    }
}
