using HW.CAB.Helper.PipeNetwork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    public enum Team
    {
        None,
        Red,
        Blue,
    }

    /// <summary>
    /// 785. 判断二分图
    /// </summary>
    internal class IsBipartite
    {
        public static bool Run(int[][] graph)
        {
            List<Graph<IsBipartiteNode>> graphs = new List<Graph<IsBipartiteNode>>();
            for (int i = 0; i < graph.Length; i++)
            {
                IsBipartiteNode node = new IsBipartiteNode(graph, i);
                if (graphs.Any(g => g.Contains(node)))
                    continue;

                Graph<IsBipartiteNode> g = new Graph<IsBipartiteNode>(node);
                g.StartRetrieval();
                graphs.Add(g);
            }

            return graphs.All(g => IsBipartiteGraph(g));
        }

        public static bool IsBipartiteGraph(Graph<IsBipartiteNode> graph)
        {
            graph.NodeAssociation();
            HashSet<IsBipartiteNode> visited = new HashSet<IsBipartiteNode>();
            Queue<IsBipartiteNode> queue = new Queue<IsBipartiteNode>();
            var start = graph.Origin;
            start.Team = Team.Red;
            visited.Add(start);
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var pointer = queue.Dequeue();
                var nextNodes = graph.GetConnectivity(pointer);
                foreach (var nextNode in nextNodes)
                {
                    if (nextNode.Team == pointer.Team)
                        return false;

                    if(!visited.Contains(nextNode)) 
                    {
                        visited.Add(pointer);
                        queue.Enqueue(nextNode);
                        nextNode.Team = pointer.GetOpponentTeam();
                    }
                }
            }

            return true;
        }
    }

    public class IsBipartiteNode : IGraphNode<IsBipartiteNode>
    {
        private int[][] _graph;

        public IsBipartiteNode(int[][] graph, int val)
        {
            _graph = graph;
            Value = val;
        }

        public int Value { get; }

        public Team Team { get; set; }

        public Team GetOpponentTeam()
        {
            if (Team == Team.Red)
                return Team.Blue;

            if (Team == Team.Blue)
                return Team.Red;

            return Team;
        }

        public IsBipartiteNode[] GetNextNodes()
        {
            return _graph[Value].Select(v => new IsBipartiteNode(_graph, v)).ToArray();
        }

        public override bool Equals(object? obj)
        {
            if (obj is IsBipartiteNode node)
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
