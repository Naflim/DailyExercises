using HW.CAB.Helper.PipeNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DailyExercises
{
    /// <summary>
    /// 1192. 查找集群内的关键连接
    /// </summary>
    public class CriticalConnections
    {
        public static IList<IList<int>> Run(int n, IList<IList<int>> connections)
        {
            HashSet<int>[] table = new HashSet<int>[n];

            for (int i = 0; i < n; i++)
            {
                table[i] = new HashSet<int>();
            }

            foreach(var con in connections) 
            {
                table[con[0]].Add(con[1]);
                table[con[1]].Add(con[0]);
            }

            var origin = new CriticalConnectionsNode(0, table);
            Graph<CriticalConnectionsNode> graph = new Graph<CriticalConnectionsNode>(origin);
            graph.StartRetrieval();
            var bridge = graph.GetBridgesByTarjan();

            return bridge.Select(v => new int[] { v.Item1.Value,v.Item2.Value }).ToArray();
        }
    }

    public class CriticalConnectionsNode : IGraphNode<CriticalConnectionsNode>
    {
        private readonly HashSet<int>[] _table;

        public CriticalConnectionsNode(int val, HashSet<int>[] table)
        {
            Value = val;
            _table = table;
        }

        public int Value { get; }

        public CriticalConnectionsNode[] GetNextNodes()
        {
            return _table[Value].Select(v => new CriticalConnectionsNode(v, _table)).ToArray();
        }

        public override bool Equals(object? obj)
        {
            if(obj is CriticalConnectionsNode node)
            {
                return Value == node.Value;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Value;
        }
    }
}
