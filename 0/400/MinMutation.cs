using HW.CAB.Helper.PipeNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 433. 最小基因变化
    /// </summary>
    internal class MinMutation
    {
        public static int Run(string startGene, string endGene, string[] bank)
        {
            MinMutationNode start = new MinMutationNode(startGene, bank);
            MinMutationNode end = new MinMutationNode(endGene, bank);
            Graph<MinMutationNode> graph = new Graph<MinMutationNode>(start);
            graph.StartRetrieval();
            if(!graph.Contains(end)) 
            {
                return -1;
            }

            return graph.GetShortestPathByBfs(start, end).Count - 1;
        }
    }

    public class MinMutationNode : IGraphNode<MinMutationNode>
    {
        private string[] _bank;

        public MinMutationNode(string code, string[] bank)
        {
            _bank=bank;
            Code=code;
        }

        public string Code { get; }

        public MinMutationNode[] GetNextNodes()
        {
            List<MinMutationNode> nextNodes = new List<MinMutationNode>();
            for (int i = 0; i < _bank.Length; i++)
            {
                int count = 0;
                var code = _bank[i];
                for (int j = 0; j < Code.Length; j++)
                {
                    if (code[j] != Code[j])
                        count++;
                }

                if (count == 1)
                    nextNodes.Add(new MinMutationNode(code, _bank));
            }

            return nextNodes.ToArray();
        }

        public override bool Equals(object? obj)
        {
            if (obj is MinMutationNode node)
            {
                return node.Code == Code;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }
    }
}
